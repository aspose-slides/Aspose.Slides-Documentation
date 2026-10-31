"""Verify and run fresh .NET example downloads on the current native machine."""
import argparse
from concurrent.futures import ThreadPoolExecutor, as_completed
from datetime import datetime, timezone
import hashlib
import io
import json
import os
from pathlib import Path, PurePosixPath, PureWindowsPath
import platform
import re
import shutil
import stat
import subprocess
import tempfile
import time
import xml.etree.ElementTree as ET
import zipfile

REQUIRED={'Program.cs','Example.csproj','Example.sln','ExampleBootstrap.cs','global.json','NuGet.Config','README.txt','.vscode/launch.json','.vscode/tasks.json','Fonts/NotoSans-Regular.ttf','Fonts/OFL.txt','example-manifest.json'}
GENERATED={'bin','obj','output','.git','.vs','.idea','__pycache__'}
SECRET_EXTENSIONS={'.lic','.pfx','.p12','.pem','.key'}
CATALOG=json.loads((Path(__file__).with_name('catalog.json')).read_text(encoding='utf-8'))


def validate_catalog(catalog):
    articles=catalog['articles'];elements={name:row for name,row in articles.items() if name.startswith('elements/')}
    actual={'article_count':len(articles),'original_block_count':sum(len(row['actions']) for row in articles.values()),'elements_article_count':len(elements),'elements_block_count':sum(len(row['actions']) for row in elements.values())}
    expected={'article_count':77,'original_block_count':143,'elements_article_count':24,'elements_block_count':90}
    if actual!=expected or any(catalog.get(key)!=value for key,value in expected.items()):raise ValueError('Collection catalog denominator differs')
    if sum(len(row.get('legacy_downloads',[])) for row in articles.values())!=16 or catalog.get('legacy_download_count')!=16:raise ValueError('Legacy download denominator differs')


validate_catalog(CATALOG)


def sha(data):return hashlib.sha256(data).hexdigest()


def safe_member(name):
    path=PurePosixPath(name.replace('\\','/'))
    if not path.parts or path.is_absolute() or PureWindowsPath(name).is_absolute() or '..' in path.parts or ':' in name:
        raise ValueError('Unsafe archive path: '+name)
    if any(part in GENERATED for part in path.parts) or path.suffix.lower() in SECRET_EXTENSIONS or path.name.lower().startswith('.env'):
        raise ValueError('Generated output or secret in archive: '+name)
    return path


def inspect_archive(data):
    with zipfile.ZipFile(io.BytesIO(data)) as archive:
        members=archive.infolist();names=[m.filename for m in members]
        if len(names)!=len(set(names)):raise ValueError('Duplicate archive member')
        if not REQUIRED<=set(names):raise ValueError('Archive missing required files: '+str(sorted(REQUIRED-set(names))))
        if len(members)>1500 or sum(m.file_size for m in members)>150_000_000:raise ValueError('Archive exceeds download limits')
        for member in members:
            safe_member(member.filename)
            if stat.S_ISLNK(member.external_attr>>16):raise ValueError('Archive contains a symbolic link')
        manifest=json.loads(archive.read('example-manifest.json'))
        expected={row['path']:row for row in manifest['files']}
        if len(expected)!=len(manifest['files']) or set(names)!=(set(expected)|{'example-manifest.json'}):raise ValueError('Archive manifest membership differs')
        for name,row in expected.items():
            if sha(archive.read(name))!=row['sha256']:raise ValueError('Archive member hash differs: '+name)
        if not manifest.get('article_id') or not manifest.get('actions'):raise ValueError('Article/action identity missing')
        actions=manifest['actions'];article=manifest['article_id']
        if len(actions)!=len(set(actions)) or any(not isinstance(action,str) or not action.startswith(article+'/') for action in actions):raise ValueError('Duplicate or foreign archive action identity')
        return manifest


def extract_archive(data,folder):
    inspect_archive(data);folder=Path(folder).resolve();folder.mkdir(parents=True,exist_ok=True)
    with zipfile.ZipFile(io.BytesIO(data)) as archive:
        for member in archive.infolist():
            target=folder/str(safe_member(member.filename))
            if not target.resolve().is_relative_to(folder):raise ValueError('Archive leaves extraction directory')
            target.parent.mkdir(parents=True,exist_ok=True);target.write_bytes(archive.read(member.filename))


def summarize_execution(report,expected,exit_code,allow_prerequisite):
    if not expected or len(expected)!=len(set(expected)):raise ValueError('Missing or duplicate expected action identity')
    rows=report.get('actions',[]);by_id={row.get('action_id'):row for row in rows}
    if len(by_id)!=len(rows):raise ValueError('Duplicate action result')
    if exit_code==2 and allow_prerequisite:
        if report.get('status')!='prerequisite_required' or not rows:raise ValueError('Missing prerequisite report')
        if any(row.get('status')!='prerequisite_required' or row.get('evidence_kind')!='prerequisite_diagnostic' or not row.get('unmet_prerequisites') for row in rows):raise ValueError('A diagnostic was misreported as functional success')
        if not set(expected)<=set(by_id):raise ValueError('Missing action prerequisite result')
        return {'qualification':'prerequisite_verified','functional_passes':0,'prerequisite_diagnostics':len(rows)}
    if exit_code!=0 or report.get('status')!='passed':raise ValueError('Example did not report successful functional execution')
    if not set(expected)<=set(by_id):raise ValueError('Missing required action result')
    for action_id in expected:
        row=by_id[action_id];checks=row.get('checks',{})
        if row.get('status')!='passed' or row.get('evidence_kind')!='functional' or not checks or not all(value is True for value in checks.values()):raise ValueError('Action has no true semantic checks: '+action_id)
        if not row.get('runtime',{}).get('version'):raise ValueError('Actual runtime was not recorded')
    return {'qualification':'functional_passed','functional_passes':len(expected),'prerequisite_diagnostics':0}


def normalized_architecture(value):
    return {'amd64':'x64','x86_64':'x64','aarch64':'arm64'}.get(value.lower(),value.lower())


def validate_runtime(report,major,architecture):
    for row in report.get('actions',[]):
        runtime=row.get('runtime',{})
        if major and int(runtime.get('version','0').split('.')[0])!=major:raise ValueError('Unexpected actual runtime version')
        if normalized_architecture(runtime.get('architecture',''))!=normalized_architecture(architecture):raise ValueError('Unexpected actual runtime architecture')


def validate_source(folder,data,manifest):
    errors=[]
    with zipfile.ZipFile(io.BytesIO(data)) as archive:
        for source in folder.rglob('*.cs'):
            relative=source.relative_to(folder)
            if not any(part in GENERATED for part in relative.parts) and relative.as_posix() not in archive.namelist():errors.append('Compiled source omitted from archive: '+relative.as_posix())
        for row in manifest['files']:
            path=folder/str(safe_member(row['path']))
            if not path.is_file() or path.read_bytes()!=archive.read(row['path']):errors.append('Source/archive bytes differ: '+row['path'])
        project=ET.fromstring(archive.read('Example.csproj'))
        props={node.tag:node.text for group in project.findall('PropertyGroup') for node in group}
        for key,value in {'TargetFramework':'net8.0','LangVersion':'12.0','RollForward':'Major'}.items():
            if props.get(key)!=value:errors.append('Unsupported consumer setting: '+key)
        if props.get('RestoreLockedMode','false').lower()=='true':errors.append('Consumer restore is locked')
        if project.findall('.//Import'):errors.append('Consumer project imports external build files')
        packages=project.findall('.//PackageReference')
        slides=[p for p in packages if p.get('Include') in ('Aspose.Slides.NET','Aspose.Slides.NET6.CrossPlatform')]
        if len(slides)!=1 or slides[0].get('Version')!='[26.10.0]':errors.append('Unexpected Slides package profile')
        sdk=json.loads(archive.read('global.json'))['sdk']
        if sdk.get('version')!='8.0.100' or sdk.get('rollForward')!='latestMajor' or sdk.get('allowPrerelease') is not False:errors.append('Restrictive or preview SDK selection')
        nuget=ET.fromstring(archive.read('NuGet.Config'));sources=nuget.find('packageSources')
        if sources is None or sources.find('clear') is None or [(n.get('value')) for n in sources.findall('add')]!=['https://api.nuget.org/v3/index.json']:errors.append('Package sources depend on machine settings')
        text=(folder/'_index.md').read_text(encoding='utf-8-sig')
        blocks=re.findall(r'```(?:csharp|cs|c#)\s*\n(.*?)```',text,re.S)
        canonical=lambda code:code.replace('\r\n','\n').strip()
        code_files={canonical(archive.read(n).decode('utf-8-sig')) for n in archive.namelist() if n.endswith('.cs')}
        if not blocks or any(canonical(block) not in code_files for block in blocks):errors.append('Printed C# differs from a compiled source file')
        known=CATALOG['articles'].get(manifest['article_id'])
        if known and (len(blocks)!=len(known['actions']) or any(canonical(block)!=canonical(archive.read(name).decode('utf-8-sig')) for block,name in zip(blocks,known['sources']))):errors.append('Printed C# recipe count or order differs from the collection mapping')
        for name in known.get('legacy_downloads',[]) if known else []:
            alias=folder/str(safe_member(name))
            if not alias.is_file() or alias.read_bytes()!=data:errors.append('Legacy download alias differs from the current archive: '+name)
        for n in archive.namelist():
            if n.endswith('.cs') and re.search(r'new\s+Bitmap\s*\(|Graphics\.FromImage',archive.read(n).decode('utf-8-sig')):errors.append('Windows-only bitmap implementation: '+n)
    if errors:raise ValueError('; '.join(errors))


def discover(content_root,only=None):
    base=Path(content_root)/'en/net/examples';result=[]
    for path in sorted(base.rglob('example-manifest.json')):
        if any(part in GENERATED for part in path.relative_to(base).parts):continue
        folder=path.parent;data=(folder/'example.zip').read_bytes();manifest=inspect_archive(data)
        if only and manifest['article_id'] not in only:continue
        validate_source(folder,data,manifest)
        article=manifest['article_id'];known=CATALOG['articles'].get(article)
        if known is None:raise ValueError('Unknown collection article: '+article)
        match=re.search(r'^url:\s*[\'"]?([^\'"\s]+)',(folder/'_index.md').read_text(encoding='utf-8-sig'),re.M)
        if match is None or match[1]!=known['url']:raise ValueError('Front matter URL differs from collection identity: '+article)
        blocks={action for action in manifest['actions'] if '/block-' in action}
        if blocks!=set(known['actions']):raise ValueError('Missing or foreign original collection block: '+article)
        result.append({'folder':folder,'data':data,'manifest':manifest})
    expected={p.parent for p in base.rglob('_index.md') if not any(part in GENERATED for part in p.relative_to(base).parts) and re.search(r'```(?:csharp|cs|c#)\s*\n',p.read_text(encoding='utf-8-sig'))}
    found={row['folder'] for row in result}
    if not only and expected!=found:raise ValueError('Every C# article needs exactly one verified download')
    if not result:raise ValueError('No .NET example downloads found')
    identities=[row['manifest']['article_id'] for row in result]
    if len(identities)!=len(set(identities)):raise ValueError('Duplicate collection article')
    if not only and set(identities)!=set(CATALOG['articles']):raise ValueError('Incomplete collection: missing '+str(sorted(set(CATALOG['articles'])-set(identities))))
    if only and set(only)!={row['manifest']['article_id'] for row in result}:raise ValueError('Unknown selected article')
    return result


def clean_build_outputs(folder):
    folder=Path(folder).resolve()
    for name in ('bin','obj'):
        target=(folder/name).resolve()
        if not target.is_relative_to(folder) or target==folder:raise ValueError('Build cache leaves its extraction directory')
        if target.exists():shutil.rmtree(target)


def execute(row,args,work,env):
    folder=Path(tempfile.mkdtemp(prefix=row['manifest']['article_id'].replace('/','-')+' example (1) ',dir=work))
    try:return execute_download(row,args,folder,env)
    finally:clean_build_outputs(folder)


def execute_download(row,args,folder,env):
    manifest=row['manifest'];article=manifest['article_id']
    extract_archive(row['data'],folder);output=folder/'output';steps=[]
    extra={'application-integration/web-api':['--self-test'],'application-integration/background-worker':['--self-test'],'application-integration/docker':['--verify-container']}.get(article,[])
    commands=[['restore','Example.sln'],['build','Example.sln','-c','Release','--no-restore'],['run','--project','Example.csproj','-c','Release','--no-build','--','--mode',args.mode,'--output',str(output),*extra]]
    for command in commands:
        started=time.monotonic()
        run=subprocess.run([args.dotnet,*command],cwd=folder,env=env,text=True,capture_output=True,encoding='utf-8',errors='replace',timeout=args.timeout)
        log=folder/(command[0]+'.log');log.write_text(run.stdout+run.stderr,encoding='utf-8',newline='\n')
        steps.append({'argv':[args.dotnet,*command],'exit_code':run.returncode,'seconds':round(time.monotonic()-started,3),'log':str(log)})
        if run.returncode and command[0]!='run':raise RuntimeError(article+' '+command[0]+' failed: '+(run.stdout+run.stderr)[-2000:])
    path=output/'execution.json'
    if not path.exists():raise ValueError(article+': execution.json missing')
    report=json.loads(path.read_text(encoding='utf-8-sig'))
    expected=[a for a in manifest['actions'] if '/block-' in a]
    if not expected:raise ValueError('Original recipe action mapping missing: '+article)
    conditional=article.startswith('ai/') or article=='application-integration/docker'
    qualification=summarize_execution(report,expected,steps[-1]['exit_code'],args.mode=='evaluation' and conditional)
    validate_runtime(report,args.require_runtime_major,args.require_architecture or platform.machine())
    print(qualification['qualification']+': '+article,flush=True)
    return {'article_id':article,'archive_sha256':sha(row['data']),'mode':args.mode,'steps':steps,'execution':report,**qualification}


def main():
    parser=argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--content-root',type=Path,default=Path('.'));parser.add_argument('--mode',choices=('evaluation','licensed'),default='evaluation')
    parser.add_argument('--dotnet',default='dotnet');parser.add_argument('--article',action='append');parser.add_argument('--workers',type=int,default=2)
    parser.add_argument('--out',type=Path,required=True);parser.add_argument('--work-root',type=Path);parser.add_argument('--timeout',type=int,default=420)
    parser.add_argument('--static-only',action='store_true');parser.add_argument('--fresh-extract',action='store_true');parser.add_argument('--require-runtime-major',type=int)
    parser.add_argument('--require-architecture',help='Native host architecture, e.g. X64 or ARM64; emulator output cannot qualify another architecture')
    args=parser.parse_args();args.out.parent.mkdir(parents=True,exist_ok=True);args.out.unlink(missing_ok=True)
    rows=discover(args.content_root,args.article);work=(args.work_root or args.out.parent/'fresh downloads').resolve();work.mkdir(parents=True,exist_ok=True)
    env={**os.environ,'DOTNET_CLI_TELEMETRY_OPTOUT':'1','DOTNET_NOLOGO':'1','NUGET_PACKAGES':str(work/'packages')}
    if args.mode=='evaluation':env.pop('ASPOSE_LICENSE_PATH',None)
    results=[];errors=[]
    if not args.static_only:
        with ThreadPoolExecutor(max_workers=args.workers) as pool:
            jobs={pool.submit(execute,row,args,work,env):row for row in rows}
            for job in as_completed(jobs):
                try:results.append(job.result())
                except Exception as error:
                    article=jobs[job]['manifest']['article_id'];errors.append({'article_id':article,'error':str(error)});print('FAILED: '+article+': '+str(error),flush=True)
    record={'schema_version':1,'utc':datetime.now(timezone.utc).isoformat(),'result':'fail' if errors else 'pass','os':platform.system(),'architecture':platform.machine(),'host':{'system':platform.system(),'release':platform.release(),'version':platform.version(),'machine':platform.machine(),'macos':platform.mac_ver()[0],'libc':platform.libc_ver()},'source_commit':os.environ.get('GITHUB_SHA'),'static_only':args.static_only,'article_count':len(rows),'functional_passes':sum(r['functional_passes'] for r in results),'prerequisite_diagnostics':sum(r['prerequisite_diagnostics'] for r in results),'results':results,'errors':errors}
    args.out.write_text(json.dumps(record,indent=2)+'\n',encoding='utf-8',newline='\n')
    print(json.dumps({k:v for k,v in record.items() if k not in ('results','errors')}));return int(bool(errors))


if __name__=='__main__':raise SystemExit(main())
