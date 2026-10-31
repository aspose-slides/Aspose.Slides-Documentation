"""Compare two immutable worker archives using separate native processes."""
import argparse
from datetime import datetime, timezone
import json
import os
from pathlib import Path
import platform
import re
import shutil
import subprocess
import time
import zipfile
import io

from verify import extract_archive, inspect_archive, normalized_architecture, sha

ARTICLE='application-integration/background-worker'
EXPECTED_RESULT={'mixed_jobs':4,'successful_jobs':3,'failed_jobs':1,'shutdown_accounted_for_every_job':True,'cancellation_recorded':True,'active_conversion_cancelled':True,'partial_output_removed':True,'queue_capacity':2,'concurrency':2}


def exact_int(value,name,expected):
    return type(value.get(name)) is int and value[name]==expected


def assess_process(code,execution,result,sdk,trial,architecture):
    errors=[]
    if code!=0:errors.append('process_exit_nonzero')
    if not execution:errors.append('execution_report_missing')
    else:
        actions=execution.get('actions',[])
        if execution.get('status')!='passed' or len(actions)!=1 or actions[0].get('action_id')!=ARTICLE+'/block-001' or actions[0].get('status')!='passed' or not actions[0].get('checks') or not all(v is True for v in actions[0]['checks'].values()):errors.append('original_execution_checks_invalid')
        for action in actions:
            runtime=action.get('runtime',{})
            if not runtime.get('version','').startswith('10.') or normalized_architecture(runtime.get('architecture',''))!=normalized_architecture(architecture):errors.append('native_runtime_invalid')
    if json.dumps(result,sort_keys=True,separators=(',',':'))!=json.dumps(EXPECTED_RESULT,sort_keys=True,separators=(',',':')):errors.append('original_result_changed')
    if trial:
        if not sdk:errors.append('sdk_observation_missing')
        else:
            if not all(exact_int(sdk,name,value) for name,value in [('sdk_concurrency_bound',1),('maximum_sdk_active',1),('sdk_active',0)]):errors.append('sdk_concurrency_invalid')
            runs=sdk.get('runs',[])
            if {r.get('phase') for r in runs}!={'normal-output','shutdown-output','active-output'} or len(runs)!=3:errors.append('sdk_phase_coverage_invalid')
            if any(not all(exact_int(r.get('metrics',{}),name,value) for name,value in [('sdk_concurrency_bound',1),('maximum_sdk_active',1),('sdk_active',0)]) for r in runs):errors.append('sdk_phase_concurrency_invalid')
    return errors


def read_json(path):
    return json.loads(path.read_text(encoding='utf-8-sig')) if path.is_file() else None


def main():
    p=argparse.ArgumentParser(description=__doc__)
    p.add_argument('--baseline-sha',required=True);p.add_argument('--candidate-sha',required=True)
    p.add_argument('--baseline-archive-sha256',required=True);p.add_argument('--iterations',type=int,default=20)
    p.add_argument('--dotnet',default='dotnet');p.add_argument('--checkout',type=Path,default=Path('.'))
    p.add_argument('--work-root',type=Path,required=True);p.add_argument('--out',type=Path,required=True)
    p.add_argument('--require-architecture',default='ARM64');args=p.parse_args()
    if not all(re.fullmatch('[a-f0-9]{40}',s) for s in (args.baseline_sha,args.candidate_sha)) or not 1<=args.iterations<=100:p.error('Use full immutable commit IDs and 1..100 iterations')
    if normalized_architecture(platform.machine())!=normalized_architecture(args.require_architecture):p.error('The process host must match the required native architecture')
    work=args.work_root.resolve();work.mkdir(parents=True,exist_ok=False)
    args.out=args.out.resolve();args.out.parent.mkdir(parents=True,exist_ok=True)
    retained=args.out.parent/'worker-native-runs';retained.mkdir(exist_ok=True)
    env={**os.environ,'NUGET_PACKAGES':str(work/'packages'),'DOTNET_CLI_HOME':str(work/'dotnet-home'),'DOTNET_CLI_TELEMETRY_OPTOUT':'1','DOTNET_GENERATE_ASPNET_CERTIFICATE':'false'};env.pop('ASPOSE_LICENSE_PATH',None)
    def git_data(commit,path):
        return subprocess.check_output(['git','-C',str(args.checkout),'show',commit+':'+path])
    record={'schema_version':1,'started_utc':datetime.now(timezone.utc).isoformat(),'candidate_commit':args.candidate_sha,'baseline_commit':args.baseline_sha,'mode':'evaluation','host':{'system':platform.system(),'machine':platform.machine(),'release':platform.release(),'libc':platform.libc_ver()},'iterations_per_archive':args.iterations,'sources':{},'runs':[],'setup_errors':[],'license_files_mounted':False}
    def save():args.out.write_text(json.dumps(record,indent=2)+'\n',encoding='utf-8',newline='\n')
    info=subprocess.run([args.dotnet,'--info'],env=env,capture_output=True,text=True,timeout=90);record['sdk_info']={'exit_code':info.returncode,'stdout':info.stdout,'stderr':info.stderr}
    save()
    for label,commit in [('baseline',args.baseline_sha),('candidate',args.candidate_sha)]:
        data=git_data(commit,'en/net/examples/'+ARTICLE+'/example.zip');manifest=inspect_archive(data)
        if manifest['article_id']!=ARTICLE:raise ValueError('Foreign archive identity')
        if label=='baseline' and sha(data)!=args.baseline_archive_sha256:raise ValueError('Baseline archive hash differs')
        with zipfile.ZipFile(io.BytesIO(data)) as z:program=z.read('Program.cs');bootstrap=z.read('ExampleBootstrap.cs')
        page=git_data(commit,'en/net/examples/'+ARTICLE+'/_index.md').decode('utf-8-sig')
        blocks=re.findall(r'```(?:csharp|cs|c#)\s*\n(.*?)```',page,re.S)
        canonical=lambda s:s.replace('\r\n','\n').strip()
        if len(blocks)!=1 or canonical(blocks[0])!=canonical(program.decode('utf-8-sig')):raise ValueError('Printed and compiled worker source differ')
        project=work/(label+' project (1)');extract_archive(data,project)
        source={'commit':commit,'archive_sha256':sha(data),'program_sha256':sha(program),'bootstrap_sha256':sha(bootstrap),'project':str(project),'actions':manifest['actions'],'setup':[]};record['sources'][label]=source
        for argv in ([args.dotnet,'restore','Example.sln'],[args.dotnet,'build','Example.sln','-c','Release','--no-restore']):
            run=subprocess.run(argv,cwd=project,env=env,capture_output=True,text=True,timeout=420)
            source['setup'].append({'argv':argv,'exit_code':run.returncode,'stdout':run.stdout,'stderr':run.stderr})
            if run.returncode:record['setup_errors'].append(label+' '+argv[1]);save();return 1
        save()
    for iteration in range(1,args.iterations+1):
        for label in ('baseline','candidate'):
            project=Path(record['sources'][label]['project']);output=work/'outputs'/(label+'-'+str(iteration));proof=retained/(label+'-'+str(iteration));proof.mkdir()
            command=[args.dotnet,str(project/'bin/Release/net8.0/Example.dll'),'--mode','evaluation','--output',str(output),'--self-test'];started=time.monotonic()
            try:
                run=subprocess.run(command,cwd=project,env=env,capture_output=True,text=True,timeout=240)
                code=run.returncode;stdout=run.stdout;stderr=run.stderr;timed_out=False
            except subprocess.TimeoutExpired as error:
                code=None;stdout=error.stdout or b'';stderr=error.stderr or b'';timed_out=True
                if isinstance(stdout,bytes):stdout=stdout.decode('utf-8',errors='replace')
                if isinstance(stderr,bytes):stderr=stderr.decode('utf-8',errors='replace')
            (proof/'stdout.log').write_text(stdout,encoding='utf-8');(proof/'stderr.log').write_text(stderr,encoding='utf-8')
            execution=read_json(output/'execution.json');result=read_json(output/'result.json');sdk=read_json(output/'sdk-concurrency.json')
            errors=assess_process(code,execution,result,sdk,label=='candidate',args.require_architecture)
            if timed_out:errors.append('process_timeout')
            for name in ('execution.json','result.json','sdk-concurrency.json'):
                if (output/name).is_file():shutil.copyfile(output/name,proof/name)
            pdfs=[]
            for pdf in sorted((output/'normal-output').glob('*.pdf')):
                content=pdf.read_bytes();pdfs.append({'name':pdf.name,'sha256':sha(content),'bytes':len(content),'pdf_header_valid':content.startswith(b'%PDF-')})
            if len(pdfs)!=3 or any(not row['pdf_header_valid'] for row in pdfs):errors.append('normal_pdf_outputs_invalid')
            observation={'label':label,'iteration':iteration,'archive_sha256':record['sources'][label]['archive_sha256'],'exit_code':code,'seconds':round(time.monotonic()-started,3),'timed_out':timed_out,'execution':execution,'original_result':result,'sdk_observation':sdk,'normal_pdfs':pdfs,'stdout_sha256':sha(stdout.encode()),'stderr_sha256':sha(stderr.encode()),'retained_logs':str(proof),'errors':errors,'passed':not errors}
            record['runs'].append(observation);save();print(json.dumps({k:observation[k] for k in ('label','iteration','exit_code','passed','errors')}),flush=True)
    record['finished_utc']=datetime.now(timezone.utc).isoformat();record['baseline_failures']=sum(not r['passed'] for r in record['runs'] if r['label']=='baseline');record['candidate_failures']=sum(not r['passed'] for r in record['runs'] if r['label']=='candidate');record['baseline_fault_reproduced']=record['baseline_failures']>0;record['result']='pass' if record['candidate_failures']==0 else 'fail';record['interpretation']='Bounded separate-process comparison; a passing candidate is mitigation evidence, not proof that every native fault is eliminated.';save();return int(record['result']!='pass')


if __name__=='__main__':raise SystemExit(main())
