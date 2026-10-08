---
title: Java経由のPythonでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/python-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint を PDF に変換
- プレゼンテーションを PDF に変換
- PPT を PDF に変換
- PPT を PDF に変換
- PPTX を PDF に変換
- PPTX を PDF に変換
- PowerPoint を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- 添付
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Java 経由の Python で PowerPoint の PPT/PPTX を高品質かつ検索可能な PDF に変換し、迅速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPointプレゼンテーション（PPT、PPTX、ODPなど）をJava経由のPythonでPDF形式に変換すると、さまざまな利点があります。デバイス間の互換性やプレゼンテーションのレイアウトと書式設定を保持できます。 本ガイドでは、プレゼンテーションをPDFドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDFファイルのパスワード保護、フォント置換の検出、変換対象の特定スライドの選択、出力ドキュメントへの準拠基準の適用方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションをPDFに変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションをPDFに変換するには、ファイル名を引数として[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)クラスに渡し、[save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)メソッドを使用してプレゼンテーションをPDFとして保存します。[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/)クラスは、通常プレゼンテーションをPDFに変換するために使用される[save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save)メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションをPDFに変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値を設定します。**注** Aspose.Slides に対して、出力ドキュメントからこの情報を変更または削除するよう指示することはできません。
{{% /alert %}}

Aspose.Slides は以下の変換をサポートします：

* プレゼンテーション全体をPDFに変換
* プレゼンテーションから特定のスライドをPDFに変換

Aspose.Slides はプレゼンテーションをPDFにエクスポートし、生成されたPDFが元のプレゼンテーションとほぼ同一になるようにします。変換時に要素や属性が正確にレンダリングされます。具体的には：

* 画像
* テキストボックスと図形
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準の変換はデフォルトのPDFエクスポート設定を使用します。画像品質、ページ内容、またはPDFの準拠性を制御する必要がある場合は、カスタムオプションを使用してください。

例を実行する前に、[Aspose.Slides for Python via Java](/slides/ja/python-java/installation/) と互換性のある Java ランタイムをインストールしてください。各例は現在の作業ディレクトリから `presentation.pptx` を読み取ります。ご自身の PPT、PPTX、または ODP ファイルに置き換えてください。JVM は Python プロセスごとに一度だけ起動します。

次の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドをPDFに保存します。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose は、プレゼンテーションからPDFへの変換プロセスを示す無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、ここで説明した手順の実装を確認できます。
{{% /alert %}}

## **PowerPointをPDFに変換（オプションあり）**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成されたPDFをカスタマイズしたり、パスワードでロックしたり、変換プロセスの進行方法を指定したりできます。

### **PowerPointをPDFに変換（カスタムオプション）**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを定義できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setJpegQuality(jpype.JByte(90))
pdf_options.setSufficientResolution(300)
pdf_options.setSaveMetafilesAsPng(True)
pdf_options.setTextCompression(PdfTextCompression.Flate)
pdf_options.setCompliance(PdfCompliance.Pdf15)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **埋め込みOLEファイルをPDF添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受信者がスライドを閲覧できるだけでなく、ワークブックのデータにもアクセスできるようにしたいことがあります。`True` を指定して [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) を呼び出すと、埋め込み OLE ファイルが結果の PDF に添付ファイルとして保持されます。

デフォルト値は `False` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページにレンダリングされますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `True` に設定すると、ファイルデータも添付されます。プレビューは視覚的な表現のままで、添付により受信者は埋め込みファイルを個別に開くまたは保存できます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

次の例は、すでに埋め込みの Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setIncludeOleData(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

結果を確認するには：

1. Adobe Acrobat Reader など、ファイル添付をサポートするビューアでエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探します。
3. 添付ファイルを保存して Excel でデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付とは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課しています：PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含む他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF 準拠設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **PowerPointをPDFに変換（非表示スライド込み）**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

次の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setShowHiddenSlides(True)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **PowerPointをパスワード保護されたPDFに変換**

次の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス許可では印刷が可能で、高品質印刷も含まれます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setPassword("password")
pdf_options.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスの下で [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションからPDFへの変換プロセス中にフォント置換を検出できるようにします。

次の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。警告は、利用できないフォントが置換されたときにのみ出力されます。Java API から警告コールバックを受け取るために JPype プロキシを使用します。プレフィックスを確認する前に、Java の説明文字列を Python の文字列に変換してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, ReturnAction, SaveFormat, WarningType

class FontSubstitutionHandler:
    def warning(self, warning):
        description = str(warning.getDescription())
        if warning.getWarningType() == WarningType.DataLoss and description.startswith("Font will be substituted"):
            print(f"Font substitution warning: {description}")
        return ReturnAction.Continue


handler = FontSubstitutionHandler()
callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)

pdf_options = PdfOptions()
pdf_options.setWarningCallback(callback)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
フォント置換に関する詳細は、[Font Substitution](/slides/ja/python-java/font-substitution/) 記事をご覧ください。
{{% /alert %}}

### **専用の太字フォントがないフォントの処理**

プレゼンテーションでは、フォントに専用の太字タイプフェイスがなくても、テキストに太字書式を適用できます。このテキストは、通常のグリフを人工的に太くする合成太字により太字として表示されます。そのテキストが PDF で意図した外観と比較して重く見える場合や異なる場合は、`True` を指定して [PdfOptions.setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setRasterizeUnsupportedFontStyles) を呼び出してみてください。このオプションは、PDF エクスポート時に影響を受けたテキストをビットマップとしてレンダリングし、特定のフォントでの外観を改善できることがあります。デフォルト値は `False` です。

サンプルのプレゼンテーションには、通常テキストが入ったテキストボックスと、同じフォント（専用の太字タイプフェイスなし）に太字書式が適用されたテキストボックスの 2 つがあります。次の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にし、PDF にエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

pdf_options = PdfOptions()
pdf_options.setRasterizeUnsupportedFontStyles(True)

presentation = Presentation("unsupported-bold.pptx")
try:
    presentation.save("rasterized.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

以下のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプションが無効の場合、太字テキストのストロークが太くなります。オプションを有効にすると、ストロークが細くなり、通常テキストは変更されません。設定を選択する前に結果を比較してください。

| オプション無効 (`False`、デフォルト) | オプション有効 (`True`) |
|---|---|
| ![サポートされていないフォントスタイルのラスタライズが無効なPDF](unsupported-bold-disabled.png) | ![サポートされていないフォントスタイルのラスタライズが有効なPDF](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると、太字テキストだけがビットマップに変換されます。OCR なしでは選択、コピー、検索ができず、800% のズームではエッジが柔らかく表示されます。通常テキストは検索可能なままです。オプションが無効の場合、両方の文字列はテキストとして残ります。

このオプションは、フォントに専用の太字タイプフェイスがない場合に、太字として書式設定されたテキストをラスタライズします。元のフォントが利用できない場合は、[Font substitution](/slides/ja/python-java/font-substitution/) が別のフォントを選択します。

## **PowerPointから選択したスライドをPDFに変換**

[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) に渡すスライド番号は 1 から始まります。この例は、スライド 1 と 3 が存在する場合にそれらをエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
    presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **PowerPointをカスタムスライドサイズでPDFに変換**

この例は、サイズ 612 × 792 ポイント（US Letter）のページに最初のスライドをエクスポートします。指定サイズの新しいプレゼンテーションにスライドをクローンし、スライドコンテンツを拡大縮小して収めます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
resized_presentation = Presentation()
try:
    resized_presentation.getSlideSize().setSize(612, 792, SlideSizeScaleType.EnsureFit)
    slide = presentation.getSlides().get_Item(0)
    resized_presentation.getSlides().insertClone(0, slide)

    # 新しく作成されたプレゼンテーションに含まれる空白スライドを削除します。
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **PowerPointをノートスライドビューでPDFに変換**

次の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下に配置します。結果を見るには、スピーカーノートを含むプレゼンテーションを使用してください。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

notes_options = NotesCommentsLayoutingOptions()
notes_options.setNotesPosition(NotesPositions.BottomFull)

pdf_options = PdfOptions()
pdf_options.setSlidesLayoutOptions(notes_options)

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF のアクセシビリティと準拠基準**

アクセシブルな PDF を作成する際は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) を参照してください。[PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) を使用して出力標準を選択できます：**PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

このコードは、異なる準拠基準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()

    pdf_options.setCompliance(PdfCompliance.PdfA1a)
    presentation.save("presentation-a1a.pdf", SaveFormat.Pdf, pdf_options)

    pdf_options.setCompliance(PdfCompliance.PdfA1b)
    presentation.save("presentation-a1b.pdf", SaveFormat.Pdf, pdf_options)
    
    pdf_options.setCompliance(PdfCompliance.PdfUa)
    presentation.save("presentation-ua.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

> **注:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別々のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF に一括変換することをサポートしています。ファイルを順に処理し、プログラムで変換プロセスを実行できます。

**変換された PDF にパスワード保護を設定できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスを使用してパスワードを設定し、アクセス許可を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスで `True` を指定して [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) を呼び出すと、結果の PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) や [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) といったメソッドを使用して画像品質を制御し、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A 準拠基準をサポートしていますか？**

はい、Aspose.Slides はアクセシビリティやアーカイブ用に、PDF/A1a、PDF/A1b、PDF/UA を含む [various standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) に準拠した PDF のエクスポートを可能にします。適切な標準を選択し、出力が要件を満たしているか確認してください。

## **追加リソース**

- [Aspose.Slides for Python via Java ドキュメント](/slides/ja/python-java/)
- [Aspose.Slides for Python via Java API リファレンス](https://reference.aspose.com/slides/python-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)