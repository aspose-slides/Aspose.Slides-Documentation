"""Archive checks must reject broken consumer downloads before running them."""
import hashlib
from copy import deepcopy
import io
import json
from pathlib import Path
import tempfile
import unittest
import zipfile

from verify import inspect_archive, extract_archive, summarize_execution, discover, validate_runtime, clean_build_outputs, validate_catalog, CATALOG


def archive(files,actions=None):
    manifest={'article_id':'demo/sample','actions':actions or ['demo/sample/block-001'],'files':[{'path':name,'sha256':hashlib.sha256(data).hexdigest()} for name,data in files.items()]}
    result=io.BytesIO()
    with zipfile.ZipFile(result,'w') as z:
        for name,data in files.items():z.writestr(name,data)
        z.writestr('example-manifest.json',json.dumps(manifest))
    return result.getvalue()


class ArchiveTests(unittest.TestCase):
    def setUp(self):
        self.files={'Program.cs':b'// known source','Example.csproj':b'<Project/>','Example.sln':b'solution','ExampleBootstrap.cs':b'bootstrap','global.json':b'{}','NuGet.Config':b'config','README.txt':b'readme','.vscode/launch.json':b'{}','.vscode/tasks.json':b'{}','Fonts/NotoSans-Regular.ttf':b'font','Fonts/OFL.txt':b'font license'}

    def test_current_bytes_are_safe_to_extract(self):
        data=archive(self.files);meta=inspect_archive(data)
        self.assertEqual('demo/sample',meta['article_id'])
        with tempfile.TemporaryDirectory() as directory:
            extract_archive(data,Path(directory));self.assertEqual(self.files['Program.cs'],(Path(directory)/'Program.cs').read_bytes())

    def test_catalog_cannot_silently_shrink_the_collection(self):
        catalog=deepcopy(CATALOG);catalog['articles'].pop('elements/slide')
        with self.assertRaisesRegex(ValueError,'denominator'):validate_catalog(catalog)

    def test_catalog_cannot_silently_remove_a_legacy_download(self):
        catalog=deepcopy(CATALOG);catalog['articles']['content-extraction/chart-data']['legacy_downloads']=[]
        with self.assertRaisesRegex(ValueError,'Legacy'):validate_catalog(catalog)

    def test_traversal_and_secret_are_rejected(self):
        for name in ('../escape.txt','C:/escape.txt','license.lic','key.pfx','obj/project.assets.json'):
            with self.subTest(name=name),self.assertRaises(ValueError):inspect_archive(archive({**self.files,name:b'x'}))

    def test_changed_member_is_rejected(self):
        data=archive(self.files);out=io.BytesIO()
        with zipfile.ZipFile(io.BytesIO(data)) as old,zipfile.ZipFile(out,'w') as new:
            for n in old.namelist():new.writestr(n,b'changed' if n=='Program.cs' else old.read(n))
        with self.assertRaisesRegex(ValueError,'hash'):inspect_archive(out.getvalue())

    def test_missing_bootstrap_is_rejected(self):
        files=dict(self.files);files.pop('ExampleBootstrap.cs')
        with self.assertRaisesRegex(ValueError,'missing'):inspect_archive(archive(files))

    def test_font_and_font_license_are_required(self):
        for name in ('Fonts/NotoSans-Regular.ttf','Fonts/OFL.txt'):
            files=dict(self.files);files.pop(name)
            with self.subTest(name=name),self.assertRaisesRegex(ValueError,'missing'):
                inspect_archive(archive(files))

    def test_duplicate_or_foreign_archive_action_is_rejected(self):
        for actions in (['demo/sample/block-001']*2,['other/article/block-001']):
            with self.subTest(actions=actions),self.assertRaises(ValueError):inspect_archive(archive(self.files,actions))

    def test_duplicate_expected_action_cannot_inflate_pass_count(self):
        with self.assertRaises(ValueError):summarize_execution({},['demo/sample/block-001']*2,0,False)

    def test_emulated_architecture_cannot_qualify_native_arm(self):
        report={'actions':[{'runtime':{'version':'10.0.14','architecture':'X64'}}]}
        with self.assertRaisesRegex(ValueError,'architecture'):validate_runtime(report,10,'ARM64')
        validate_runtime(report,10,'AMD64')

    def test_completed_build_cache_is_removed_but_evidence_is_kept(self):
        with tempfile.TemporaryDirectory() as directory:
            root=Path(directory)
            for name in ('bin/Release/Example.dll','obj/project.assets.json','output/execution.json','run.log'):
                p=root/name;p.parent.mkdir(parents=True,exist_ok=True);p.write_text('proof')
            clean_build_outputs(root)
            self.assertFalse((root/'bin').exists());self.assertFalse((root/'obj').exists())
            self.assertTrue((root/'output/execution.json').exists());self.assertTrue((root/'run.log').exists())

    def test_generated_copy_is_not_a_second_article(self):
        with tempfile.TemporaryDirectory() as directory:
            copied=Path(directory)/'en/net/examples/demo/sample/bin/Release/net8.0'
            copied.mkdir(parents=True)
            (copied/'example-manifest.json').write_text('{}')
            with self.assertRaisesRegex(ValueError,'No .NET example downloads'):
                discover(Path(directory))

    def test_prerequisite_is_never_counted_as_functional_success(self):
        action={'action_id':'demo/sample/block-001','status':'prerequisite_required','evidence_kind':'prerequisite_diagnostic','unmet_prerequisites':['license']}
        report={'status':'prerequisite_required','actions':[action]}
        with self.assertRaises(ValueError):summarize_execution(report,['demo/sample/block-001'],2,False)
        result=summarize_execution(report,['demo/sample/block-001'],2,True)
        self.assertEqual(0,result['functional_passes']);self.assertEqual('prerequisite_verified',result['qualification'])

    def test_every_declared_action_must_have_true_semantic_checks(self):
        row={'action_id':'demo/sample/block-001','status':'passed','evidence_kind':'functional','checks':{'round trip':True},'runtime':{'version':'10.0.14'}}
        result=summarize_execution({'status':'passed','actions':[row]},['demo/sample/block-001'],0,False)
        self.assertEqual(1,result['functional_passes'])
        with self.assertRaises(ValueError):summarize_execution({'status':'passed','actions':[row]},['demo/sample/block-001','demo/sample/block-002'],0,False)
        row['checks']['round trip']=False
        with self.assertRaises(ValueError):summarize_execution({'status':'passed','actions':[row]},['demo/sample/block-001'],0,False)


if __name__=='__main__':unittest.main()
