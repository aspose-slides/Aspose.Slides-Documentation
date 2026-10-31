"""A native process failure must remain a failure after a passing JSON report."""
import importlib.util
from pathlib import Path
import unittest


class WorkerNativeTests(unittest.TestCase):
    def setUp(self):
        path=Path(__file__).with_name('stress_worker.py')
        self.assertTrue(path.is_file(), 'The source-bound worker comparison tool must exist')
        spec=importlib.util.spec_from_file_location('stress_worker_test',path)
        self.tool=importlib.util.module_from_spec(spec);spec.loader.exec_module(self.tool)
        self.execution={'status':'passed','actions':[{'action_id':'application-integration/background-worker/block-001','status':'passed','checks':{'original':True},'runtime':{'version':'10.0.14','architecture':'ARM64'}}]}

    def test_post_pass_abort_is_never_accepted(self):
        errors=self.tool.assess_process(-6,self.execution,self.tool.EXPECTED_RESULT,None,False,'ARM64')
        self.assertIn('process_exit_nonzero',errors)

    def test_missing_report_is_never_reconstructed_from_stdout(self):
        self.assertIn('execution_report_missing',self.tool.assess_process(0,None,self.tool.EXPECTED_RESULT,None,False,'ARM64'))

    def test_original_json_types_cannot_change(self):
        changed=dict(self.tool.EXPECTED_RESULT);changed['cancellation_recorded']=1
        self.assertIn('original_result_changed',self.tool.assess_process(0,self.execution,changed,None,False,'ARM64'))

    def test_trial_requires_measured_sdk_serialization(self):
        self.assertIn('sdk_observation_missing',self.tool.assess_process(0,self.execution,self.tool.EXPECTED_RESULT,None,True,'ARM64'))
        metrics={'sdk_concurrency_bound':1,'maximum_sdk_active':1,'sdk_active':0,'runs':[{'phase':name,'metrics':{'sdk_concurrency_bound':1,'maximum_sdk_active':1,'sdk_active':0}} for name in ('normal-output','shutdown-output','active-output')]}
        self.assertEqual([],self.tool.assess_process(0,self.execution,self.tool.EXPECTED_RESULT,metrics,True,'ARM64'))
        metrics['runs'][0]['metrics']['maximum_sdk_active']=2
        self.assertIn('sdk_phase_concurrency_invalid',self.tool.assess_process(0,self.execution,self.tool.EXPECTED_RESULT,metrics,True,'ARM64'))
        metrics['runs'][0]['metrics']['maximum_sdk_active']=True
        self.assertIn('sdk_phase_concurrency_invalid',self.tool.assess_process(0,self.execution,self.tool.EXPECTED_RESULT,metrics,True,'ARM64'))
        metrics['sdk_concurrency_bound']=True
        self.assertIn('sdk_concurrency_invalid',self.tool.assess_process(0,self.execution,self.tool.EXPECTED_RESULT,metrics,True,'ARM64'))


if __name__=='__main__':unittest.main()
