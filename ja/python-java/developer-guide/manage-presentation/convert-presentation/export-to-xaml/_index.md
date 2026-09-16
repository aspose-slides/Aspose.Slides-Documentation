---
title: Python via Java でプレゼンテーションを XAML にエクスポート
linktitle: プレゼンテーションを XAML に変換
type: docs
weight: 30
url: /ja/python-java/export-to-xaml/
keywords:
- PowerPoint をエクスポート
- OpenDocument をエクスポート
- プレゼンテーションをエクスポート
- PowerPoint を変換
- OpenDocument を変換
- プレゼンテーションを変換
- PowerPoint から XAML へ
- OpenDocument から XAML へ
- プレゼンテーションから XAML へ
- PPT から XAML へ
- PPTX から XAML へ
- ODP から XAML へ
- PPT を XAML として保存
- PPTX を XAML として保存
- ODP を XAML として保存
- PPT を XAML にエクスポート
- PPTX を XAML にエクスポート
- ODP を XAML にエクスポート
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java を使用して、PowerPoint および OpenDocument のプレゼンテーションを XAML にエクスポートします。デフォルト オプションを使用するか、非表示スライドを含めることができます。"
---
## **概要**

この記事では、Aspose.Slides for Python via Java を使用して PowerPoint プレゼンテーションを XAML にエクスポートする方法を説明します。XAML の簡単な概要を含み、デフォルト設定でプレゼンテーションを XAML に保存する方法を示し、[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) を使用してエクスポートをカスタマイズする方法（非表示スライドのエクスポートを含む）を実演します。また、フォールバックフォント、XAML スタックの互換性、非表示スライドのエクスポート動作に関する一般的な質問にも答えます。

例を実行するには、Aspose.Slides for Python via Java と互換性のある Java ランタイムが必要です。`pres.pptx` を現在の作業ディレクトリに配置してください。各例は、JVM がまだ起動していない場合にのみ起動します。

## **XAML について**

XAML は XML ベースのマークアップ言語で、WPF（Windows Presentation Foundation）や UWP（Universal Windows Platform）、Xamarin.Forms などのフレームワークでユーザーインターフェイスを記述するために使用されます。

XAML ファイルはビジュアルデザイナーで操作することも、マークアップを直接記述・編集することもできます。

## **デフォルト オプションでプレゼンテーションを XAML にエクスポート**

以下の Python の例は、デフォルト設定でプレゼンテーションを XAML にエクスポートする方法を示します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

デフォルトでは、エクスポートされたスライドはプロセスの現在の作業ディレクトリ内の `pres` サブフォルダーに保存されます。フォルダーは自動的に作成され、必要な画像も同様に保存されます。

出力フォルダー名は、拡張子なしのソース ファイル名から取得されます。`pres.pptx` の場合、出力ファイルは `pres/Slide_1.xaml`、`pres/Slide_2.xaml` などと名付けられます。入力プレゼンテーションに絶対パスを指定した場合でも、出力フォルダーは入力ファイルと同じ場所ではなく、現在の作業ディレクトリを基準に作成されます。

## **カスタム オプションでプレゼンテーションを XAML にエクスポート**

Aspose.Slides がプレゼンテーションを XAML にエクスポートする方法は、[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) クラスで制御できます。

出力をカスタム場所に保存するには、`IXamlOutputSaver` を実装し、その実装インスタンスを [XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) の [setOutputSaver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setOutputSaver) メソッドに渡します。

XAML 出力に非表示スライドを含めるには、以下の Python の例のように `True` を指定して [setExportHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) を呼び出します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **生成されたすべての XAML アーティファクトを取得**

XAML エクスポートでは、エクスポートされた各スライドに対して XAML ドキュメントと、個別の画像やサポートリソースが生成されることがあります。デフォルトのファイルシステム保存機能の代わりにこれらのアーティファクトを受け取るには、カスタム `IXamlOutputSaver` を [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setOutputSaver) に割り当てます。XAML オプションを受け取る [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) のオーバーロードを使用してエクスポートを開始します。

Python では、`jpype.JProxy` を使用して Java の `IXamlOutputSaver` インターフェイスを実装します。コールバック パスを `str` に変換し、Java のバイト配列を Python の `bytes` にコピーしてから返す方法を以下に示します。

### **コールバック ライフサイクルを理解**

- `path` はアーティファクトを識別し、相対ディレクトリを含む場合があります。XAML が相対パスでリソースを参照する可能性があるため、この情報を保持してください。
- `data` にはアーティファクトのバイトが含まれます。画像やその他のバイナリリソースはテキストとしてデコードしてはいけません。
- セーバーは返却前にデータを保持または永続化する責任があります。例では各バイト配列をアプリケーション所有のメモリにコピーしています。
- エクスポートは、プレゼンテーションの保存操作が完了し、すべてのコールバックが正常に終了した場合にのみ成功とみなします。ストレージエラーを無視したり、観測されないバックグラウンド書き込みを開始したりしないでください。永続化が後で行われる場合は、そのステップが成功した後に全体の成功を報告してください。

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) はカスタムセーバーにも適用されます。デフォルト設定 `False` は非表示スライドの XAML ドキュメントを除外します。`True` を渡すとそれらとエクスポートに必要なリソースが含まれます。リソース数はプレゼンテーションによって異なるため、スライドごとに 1 つのコールバックがあるとか、固定されたコールバック順序があると想定しないでください。

### **メモリへエクスポートしアーティファクトを検査**

この完全な例は `pres.pptx` を読み込み、すべてのアーティファクトを名前と不変の `bytes` 値の Python 辞書に収集し、名前、タイプ、バイト数を出力します。提供された名前はそのまま保持されます。重複する名前がある場合は、アーティファクトを静かに上書きするのではなくコレクションを無効とします。例では結果を使用する前にこのチェックを行います。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpial.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(True)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    inspect_xaml_text = False
    image_extensions = (".png", ".jpg", ".jpeg", ".gif", ".bmp", ".tif", ".tiff", ".svg")
    for name, data in saver.artifacts.items():
        lower_name = name.lower()
        is_xaml = lower_name.endswith(".xaml")
        is_image = lower_name.endswith(image_extensions)
        kind = "slide XAML" if is_xaml else "image" if is_image else "supporting resource"
        print(f"{name}: {len(data)} bytes ({kind})")

        # XAML のみデコードし、テキスト検査が必要なときだけデコードします。
        if is_xaml and inspect_xaml_text:
            markup = data.decode("utf-8")
            print(markup)


main()
```

拡張子のチェックは検査に有用です。未知のリソース型を含め、すべてのアーティファクトを保持してください。保存や転送時にはバイトを変更せずにそのまま保持します。テキスト処理が必要な XAML のみ、UTF-8 で `bytes.decode` を使用してください。

### **収集したアーティファクトを ZIP アーカイブにパッケージ**

この独立した例はエクスポートを収集し、名前を検証したうえで元のバイトを ZIP アーカイブに書き込みます。ユニークなアーカイブ名は同時実行エクスポート ジョブを分離します。ZIP エントリはスラッシュ (/) を使用し、相対ディレクトリを保持します。正規化後に衝突する危険な名前や安全でない名前は、書き込む前にパッケージ全体を破棄します。

```python
from uuid import uuid4
from zipfile import ZipFile

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

class MemoryXamlSaver:
    def __init__(self):
        self.artifacts = {}
        self.valid = True

    def save(self, path, data):
        name = str(path)
        if name in self.artifacts:
            self.valid = False
            print(f"Export rejected: duplicate artifact name: {name}")
            return
        self.artifacts[name] = bytes(data)

def main():

    saver = MemoryXamlSaver()
    output_saver = jpype.JProxy("com.aspose.slides.IXamlOutputSaver", inst=saver)
    presentation = Presentation("pres.pptx")
    try:
        options = XamlOptions()
        options.setOutputSaver(output_saver)
        options.setExportHiddenSlides(False)
        presentation.save(options)
    finally:
        presentation.dispose()

    if not saver.valid:
        print("Export rejected: the artifact collection is invalid.")
        return

    entries = {}
    entry_names = set()
    for name, data in saver.artifacts.items():
        entry_name = name.replace("\\", "/")
        segments = entry_name.split("/")
        unsafe_name = entry_name.startswith("/") or ":" in entry_name or "\x00" in entry_name
        unsafe_name |= any(not segment.strip() or segment in (".", "..") for segment in segments)
        normalized_name = entry_name.casefold()
        if unsafe_name or normalized_name in entry_names:
            print(f"Export rejected: unsafe or duplicate artifact name: {name}")
            return
        entry_names.add(normalized_name)
        entries[entry_name] = data

    job_id = uuid4()
    archive_path = f"xaml-{job_id}.zip"
    try:
        with ZipFile(archive_path, mode="x") as archive:
            for name, data in entries.items():
                archive.writestr(name, data)

        # クローズにより ZIP ディレクトリが確定し、成功が報告されます。
        print(f"Saved {len(entries)} artifacts to {archive_path}")
    except OSError as exception:
        print(f"Archive persistence failed: {exception}")


main()
```

例では Python の `zipfile.ZipFile` を使用してローカル アーカイブを作成しています。エクスポーター自体は個別の XAML や画像ファイルを書き込みません。リモート ストレージの場合は、アーカイブ書き込み段階を収集したバイト配列のアップロードに置き換えてください。エクスポート ジョブの識別子とフル相対アーティファクト名をブロブ キーとして使用するか、ジョブ識別子、相対名、バイナリ データをデータベース行に保存します。すべてのアップロードが完了するかデータベース トランザクションがコミットされた後にジョブを公開し、永続化に失敗した場合は部分的な出力をクリーンアップしてください。

大規模なプレゼンテーションの場合、カスタムセーバーで各アーティファクトを直接アプリケーション ストレージに永続化すれば、エクスポート全体の追加コピーをメモリに保持する必要がなくなります。エクスポーターの観点からは、各コールバックを同期的に保ち、宛先がバイトを受け取った後にのみ返却し、エラーは呼び出し元に伝搬させてください。

### **リソース名を保持し参照を検証**

- 宛先が要求する場合はパス区切り文字を正規化しますが、相対ディレクトリは保持してください。すべての生成名が一意でリソース参照が有効であることが確実でない限り、`pathlib.Path.name` のみを使用しないでください。
- 宛先固有の名前検証を適用します。個別ファイルを書き込む場合、ルートパスやディレクトリトラバーサルセグメントを拒否し、`pathlib.Path.resolve` で宛先を解決し、ディレクトリ区切り文字を含めたチェックで意図したエクスポート ディレクトリ以下に留まっていることを確認します。書き込み先をリダイレクトできるシンボリックリンクのない、アプリケーション管理のディレクトリを使用してください。
- エクスポート ジョブごとに別々のセーバーとストレージ 名前空間を使用します。区切り文字の正規化後および宛先の大小文字感度ルールに従って衝突を検出してください。
- 公開前に、各 XAML ドキュメントを XML として解析し、画像の `Source` や `ImageSource` 属性などのファイルベースのリソース参照を検査します。各相対 URI をそれを含む XAML アーティファクトのディレクトリに対して解決し、結果のストレージ名を正規化して、対応するマップ キー、ZIP エントリ、または保存オブジェクトが存在することを確認します。外部 URI と XAML マークアップ式は相対ファイル名とは別に扱ってください。

例として、`pres/Slide_1.xaml` が `images/image1.png` を参照している場合、保存されたリソースは `pres/images/image1.png` として利用可能である必要があります。`image1.png` だけを保持すると関係が壊れます。オブジェクト ストレージの場合、ジョブ プレフィックス以下に同じレイアウトを保持し、これらのリソース URL を XAML コンシューマがアクセスできるようにしてください。完了した ZIP を再度開き、エントリ名とリソースバイトを検証し、対象 XAML 環境で代表的なスライドを読み込んで画像が正しく解決されることを確認します。

## **FAQ**

**元のフォントがマシンに存在しない場合、予測可能なフォントを確保するにはどうすればよいですか？**

[XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) で [setDefaultRegularFont](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setDefaultRegularFont) を呼び出します。元のフォントが欠如している場合、エクスポート時のフォールバック フォントとして使用されます。ただし、生成された XAML がフォールバック フォントを参照することや、対象マシンにそのフォントが存在することが保証されるわけではありません。XAML が参照するフォントが表示環境に存在することを確認してください。

**エクスポートされた XAML は WPF のみを対象としていますか、それとも他の XAML スタックでも使用できますか？**

Aspose.Slides はパブリック API を通じて WPF 用 XAML をエクスポートします。UWP や Xamarin.Forms など他の XAML スタックとの互換性は保証されていません。生成されたマークアップは対象環境でテストしてください。

**非表示スライドはサポートされていますか？デフォルトでエクスポートされないようにする方法はありますか？**

デフォルトでは、非表示スライドは含まれません。これらの動作は [XamlOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/) の [setExportHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/xamloptions/#setExportHiddenSlides) で制御できます。エクスポートが不要な場合は無効のままにしてください。