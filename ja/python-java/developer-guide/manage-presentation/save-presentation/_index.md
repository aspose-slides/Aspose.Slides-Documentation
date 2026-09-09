---
title: Python via Java でプレゼンテーションを保存する
linktitle: プレゼンテーションを保存
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
- 保存進行状況
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python via Java で PowerPoint および OpenDocument のプレゼンテーションをファイルまたはストリームに保存し、PPTX の出力と進行状況の報告を構成します。"
---
## **概要**

プレゼンテーションを作成するか、[既存のプレゼンテーションを開く](/slides/ja/python-java/open-presentation/)した後、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドを使用して結果を書き込みます。Aspose.Slides for Python via Java は、PowerPoint、OpenDocument、PDF などの形式でプレゼンテーションをファイルまたはストリームに保存できます。以下のセクションでは、標準的な保存操作と PPTX 出力に利用できるオプションについて説明します。

## **プレゼンテーションをファイルに保存する**

プレゼンテーションをファイルに保存するには、出力パスと [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。フォーマットの値は、Aspose.Slides が作成するファイルの種類を決定します。

次の例はプレゼンテーションを作成し、PPTX ファイルとして保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # ここにプレゼンテーションのコンテンツを追加または変更します。

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **プレゼンテーションを元の形式で保存する**

バッチ処理アプリケーションでは、入力形式が事前に分からないことがあります。ファイルを読み込んだ後、[Presentation.getSourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#getSourceFormat) メソッドから元の形式を取得します。得られた [SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/) の値を [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#toSaveFormat) に渡して対応する [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を取得し、[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) で修正されたプレゼンテーションを書き込みます。

次の完全な例は、入力ディレクトリ内のすべてのファイルを処理し、タイトルを更新した後、読み込んだ形式のまま出力ディレクトリに保存します。

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

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/slideutil/#toSaveFormat) は PPT、PPTX、ODP、PPTM、PPSX、PPSM、POTX、POTM、PPS、POT、OTP、FODP、PowerPoint XML をそれぞれのプレゼンテーション保存形式にマップします。これはプレゼンテーションのソース形式のみを対象としており、PDF、HTML、TIFF、画像などのエクスポート形式を選択するためのものではありません。サポートされていない、または無効な [SourceFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/sourceformat/) の値を渡すと、[IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html) が発生します。

レガシーな PPT、PPS、POT ファイルは同じバイナリコンテナを使用します。拡張子なしのストリームからこのようなプレゼンテーションを読み込むと、PPS や POT が PPT として識別されることがあります。これらのレガシーサブタイプを保持する必要がある場合は、元のファイル名または形式メタデータを別途保持し、出力ファイル名と形式を選択するときに使用してください。

## **プレゼンテーションをストリームに保存する**

最終的なファイルパスに依存せずにプレゼンテーションを書き込むには、書き込み可能なストリームと [SaveFormat](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveformat/) の値を [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。この方法は、出力を Web サービスから返す必要がある場合、データベースに保存する場合、またはメモリ内で処理する場合に便利です。

次の例は新しいプレゼンテーションをファイルストリームに保存します。

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

## **事前定義されたビュータイプで保存する**

保存されたプレゼンテーションを PowerPoint が最初に開くときのビューを指定できます。[ViewProperties.setLastView](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewproperties/#setLastView) メソッドに [ViewType](https://reference.aspose.com/slides/ja/python-java/aspose.slides/viewtype/) の値を渡してから保存してください。

次の例はスライドマスタービューを初期ビューとして設定します。

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

## **Strict Office Open XML 形式で保存する**

Office Open XML の Strict プロファイルに準拠した PPTX ファイルを作成するには、[PptxOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/) インスタンスを作成し、[setConformance](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setConformance) メソッドに [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/ja/python-java/aspose.slides/conformance/#Iso29500_2008_Strict) を渡します。その後、オプションを [Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドに渡します。

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

## **ZIP64 モードで Office Open XML 形式で保存する**

標準の ZIP アーカイブは、各エントリの圧縮サイズ・非圧縮サイズ、アーカイブ全体のサイズ、エントリ数に制限があります。PPTX ファイルは ZIP アーカイブであるため、非常に大きなプレゼンテーションはこれらの制限を超えることがあります。ZIP64 拡張はサイズとエントリ数の制限を引き上げます。

[PptxOptions.setZip64Mode](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setZip64Mode) メソッドを使用して、Aspose.Slides が ZIP64 拡張を書き込むかどうかを制御します。

- [IfNecessary](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#IfNecessary) はプレゼンテーションが標準 ZIP 制限を超えた場合にのみ ZIP64 を使用します。これがデフォルトモードです。
- [Never](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#Never) は ZIP64 拡張を無効にします。
- [Always](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#Always) は常に ZIP64 拡張を書き込みます。

次の例は出力プレゼンテーションに対して常に ZIP64 拡張を有効にします。

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
[Zip64Mode.Never](https://reference.aspose.com/slides/ja/python-java/aspose.slides/zip64mode/#Never) を使用し、プレゼンテーションが標準 ZIP 制限内に収まらない場合、保存操作は [PptxException](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxexception/) をスローします。
{{% /alert %}}

## **圧縮レベルを指定して Office Open XML 形式で保存する**

PPTX 出力では、[PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setCompressionLevel) メソッドを使用して、保存速度とファイルサイズのバランスを調整できます。[CompressionLevel](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/) クラスは次の値を提供します。

- [None](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#None) は圧縮せずにデータを保存します。
- [Level1](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level1) は最速の圧縮で、最も大きな圧縮後サイズになります。
- [Level2](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level2) から [Level5](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level5) は、保存速度よりも小さな出力を優先します。
- [Level6](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level6) は保存速度とファイルサイズのバランスを取ります。これがデフォルトです。
- [Level7](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level7) および [Level8](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level8) は、さらに小さな出力を優先します。
- [Level9](https://reference.aspose.com/slides/ja/python-java/aspose.slides/compressionlevel/#Level9) は最強の圧縮を行い、最も多くの処理時間が必要です。

次の例は圧縮なしでプレゼンテーションを保存します。

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

次の例は最大圧縮レベルで保存します。

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

## **サムネイルを更新せずに保存する**

プレゼンテーションを PPTX として保存する場合、[PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) メソッドでドキュメントサムネイルの更新を制御できます。

- `True` は保存時にサムネイルを再生成します。これがデフォルトです。
- `False` は既存のサムネイルを保持します。プレゼンテーションにサムネイルがない場合、Aspose.Slides は生成しません。

次の例はサムネイルを更新せずにプレゼンテーションを保存します。

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

## **保存進行状況をパーセンテージで報告する**

保存操作の進行状況を監視するには、`jpype.JProxy` を使用して Python のプログレスハンドラを登録し、[SaveOptions.setProgressCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setProgressCallback) メソッドに渡します。Aspose.Slides はエクスポート中にハンドラの `reporting` メソッドを呼び出し、進行状況の値を渡します。

次の例は PDF エクスポートの進行状況をコンソールに出力します。

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
Aspose は Aspose.Slides API で構築された無料の [PowerPoint Splitter](https://products.aspose.app/slides/ja/splitter) を提供しています。これにより、プレゼンテーションから選択したスライドを個別の PPT または PPTX ファイルとして保存できます。
{{% /alert %}}

## **FAQ**

**Aspose.Slides はインクリメンタル保存または「高速保存」をサポートしていますか？**

いいえ。各保存操作は変更された部分だけを更新するのではなく、完全な出力ファイルを書き込みます。

**複数のスレッドから同じ Presentation インスタンスを保存できますか？**

いいえ。[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) インスタンスは[スレッドセーフではありません](/slides/ja/python-java/multithreading/)。各インスタンスへのアクセスと保存は同時に 1 つのスレッドからのみ行ってください。

**プレゼンテーションを保存すると、ハイパーリンクや外部リンクされたファイルはどうなりますか？**

[ハイパーリンク](/slides/ja/python-java/manage-hyperlinks/)はプレゼンテーション内に残ります。Aspose.Slides は外部リンクされたファイルをコピーしないため、保存されたプレゼンテーションは引き続きそれらの場所にアクセスできる必要があります。

**作者、タイトル、会社、作成日などのドキュメントメタデータを保存できますか？**

はい。保存前に適切な[ドキュメントプロパティ](/slides/ja/python-java/presentation-properties/)を設定すれば、Aspose.Slides がそれらを出力ファイルに書き込みます。