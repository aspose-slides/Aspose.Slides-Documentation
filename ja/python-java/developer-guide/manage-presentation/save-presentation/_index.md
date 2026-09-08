---
title: Python via Java でプレゼンテーションを保存
linktitle: プレゼンテーションの保存
type: docs
weight: 80
url: /ja/python-java/save-presentation/
keywords:
- PowerPoint を保存
- OpenDocument を保存
- プレゼンテーションを保存
- スライドを保存
- PPT を保存
- PPTX を保存
- ODP を保存
- ファイルへのプレゼンテーション
- ストリームへのプレゼンテーション
- 事前定義されたビュータイプ
- Strict Office Open XML 形式
- Zip64 モード
- サムネイルの更新
- 保存進捗
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python via Java で PowerPoint および OpenDocument プレゼンテーションをファイルまたはストリームに保存し、PPTX の出力や進捗報告を設定します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/python-java/open-presentation/)後、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドを使用して結果を書き込みます。Aspose.Slides for Python via Java は、プレゼンテーションを PowerPoint、OpenDocument、PDF、その他の形式でファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **ファイルへのプレゼンテーションの保存**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。format の値は Aspose.Slides が作成するファイルの種類を決定します。

以下の例は、プレゼンテーションを作成し、PPTX ファイルとして保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ここでプレゼンテーションの内容を追加または変更します。

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **元の形式でプレゼンテーションを保存**

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSourceFormat) メソッドで元の形式を取得します。得られた [SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/) の値を [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#toSaveFormat) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を取得し、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) で変更されたプレゼンテーションを書き込みます。

以下の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新し、読み込んだ形式のまま出力ディレクトリに保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#toSaveFormat) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれ対応するプレゼンテーション保存形式にマップします。これはプレゼンテーションのソース形式のみをマップし、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていないまたは無効な [SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/) の値を渡すと、[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) がスローされます。

レガシーな PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。そのようなプレゼンテーションを拡張子なしのストリームから読み込むと、PPS や POT ファイルが PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名またはフォーマットメタデータを別途保持し、出力ファイル名と形式を選択する際に使用してください。

## **ストリームへのプレゼンテーションの保存**

保存時に最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能なストリームと [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合や、データベースに保存する場合、またはメモリ内で処理する場合に便利です。

以下の例は、新しいプレゼンテーションをファイルストリームに保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **事前定義されたビュータイプでプレゼンテーションを保存**

保存時に PowerPoint が最初に開くビューを指定できます。保存前に [ViewProperties.setLastView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setLastView) メソッドに [ViewType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewtype/) の値を使用します。

以下の例は、スライドマスタビューを初期ビューとして設定します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Strict Office Open XML 形式でプレゼンテーションを保存**

Office Open XML の Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/) のインスタンスを作成し、その [setConformance](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setConformance) メソッドに [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) を指定します。その後、オプションを [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Zip64 モードで Office Open XML 形式にプレゼンテーションを保存**

標準的な ZIP アーカイブは、各エントリの圧縮・非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超える可能性があります。ZIP64 拡張機能は適用されるサイズとエントリ数の制限を引き上げます。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setZip64Mode) メソッドを使用して、Aspose.Slides が ZIP64 拡張機能を書き込むかどうかを制御します：

- [IfNecessary](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#IfNecessary) は、プレゼンテーションが標準 ZIP の制限を超えた場合にのみ ZIP64 を使用します。これは既定のモードです。
- [Never](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#Never) は ZIP64 拡張機能を無効にします。
- [Always](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#Always) は常に ZIP64 拡張機能を書き込みます。

以下の例は、出力プレゼンテーションに対して常に ZIP64 拡張機能を有効にします：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="警告" %}}
もし [Zip64Mode.Never](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#Never) が使用され、プレゼンテーションが標準 ZIP の制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルを指定して Office Open XML 形式でプレゼンテーションを保存**

PPTX 出力では、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setCompressionLevel) メソッドを使用して保存速度とファイルサイズのバランスを調整できます。[CompressionLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/) クラスは以下の値を提供します：

- [None](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#None) は圧縮なしでデータを保存します。
- [Level1](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level1) は最速の圧縮を提供し、圧縮後のファイルが最も大きくなります。
- [Level2](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level2) から [Level5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level5) まで、保存速度よりも小さい出力を徐々に優先します。
- [Level6](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level6) は保存速度とファイルサイズのバランスを取ります。これが既定のレベルです。
- [Level7](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level7) と [Level8](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level8) は、保存速度よりもさらに小さい出力を優先します。
- [Level9](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level9) は最強の圧縮を提供し、最も多くの処理時間が必要です。

以下の例は、圧縮せずにプレゼンテーションを保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

以下の例は、最大の圧縮レベルを使用してプレゼンテーションを保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **サムネイルを更新せずにプレゼンテーションを保存**

プレゼンテーションを PPTX として保存する際、[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドはドキュメントのサムネイルを制御します：

- `True` は保存時にサムネイルを再生成します。これが既定値です。
- `False` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は生成しません。

以下の例は、サムネイルを更新せずにプレゼンテーションを保存します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注" %}}
サムネイルの更新を無効にすると、PPTX ファイルの保存にかかる時間を短縮できます。
{{% /alert %}}

## **保存進捗をパーセンテージで取得**

保存操作を監視するには、`jpype.JProxy` を使用して Python の進捗ハンドラを登録し、[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setProgressCallback) メソッドに渡します。Aspose.Slides はエクスポート中にハンドラの `reporting` メソッドを呼び出し、進捗値を渡します。

以下の例は、PDF エクスポートの進捗をコンソールに報告します：

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注" %}}
Aspose は、Aspose.Slides API で構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これにより、プレゼンテーションから選択したスライドを別々の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタル保存または“高速保存”をサポートしていますか？**

いいえ。各保存操作は、変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドが同じ Presentation インスタンスを保存できますか？**

いいえ。 [Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスは [スレッドセーフではありません](/slides/ja/python-java/multithreading/)。各インスタンスへのアクセスおよび保存は、同時に 1 つのスレッドからのみ行ってください。

**プレゼンテーションを保存すると、ハイパーリンクや外部リンクされたファイルはどうなりますか？**

[Hyperlinks](/slides/ja/python-java/manage-hyperlinks/) はプレゼンテーション内に残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションはそれらの場所に引き続きアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメントメタデータを保存できますか？**

はい。保存前に適切な [document properties](/slides/ja/python-java/presentation-properties/) を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。