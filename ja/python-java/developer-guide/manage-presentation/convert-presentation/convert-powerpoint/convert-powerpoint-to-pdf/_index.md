---
title: Python（via Java）で PPT と PPTX を PDF に変換 [高度な機能を含む]
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
- 添付ファイル
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python（via Java）で PowerPoint の PPT/PPTX を高品質で検索可能な PDF に変換し、迅速なコード例と高度な変換オプションを提供します。"
---
## **概要**

Python（via Java）で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウトと書式設定の保持など、いくつかの利点があります。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定のスライドの選択変換、そして出力ドキュメントに準拠基準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスに渡し、[save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」の形式の値を設定します。**注意**：Aspose.Slides にこの情報を変更または削除させることはできません。
{{% /alert %}}

Aspose.Slides は次の変換を行うことができます：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションにできるだけ近くなるよう保証します。変換時に要素と属性は正確にレンダリングされ、以下が含まれます：

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の変換はデフォルトの PDF エクスポート設定を使用します。画像品質、ページ内容、または PDF の準拠性を制御する必要がある場合は、カスタム オプションを使用します。

[Aspose.Slides for Python via Java](/slides/ja/python-java/installation/) をインストールし、例を実行する前に互換性のある Java ランタイムをインストールしてください。各例はカレントディレクトリから `presentation.pptx` を読み取ります。ご使用の PPT、PPTX、または ODP ファイルに置き換えてください。Python プロセスごとに JVM を一度起動します。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドを PDF に保存します。

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
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint から PDF への変換ツール**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータを使用して、ここで説明した手順のライブ実装をテストできます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスのプロパティとして提供されるカスタム オプションを提供し、生成される PDF のカスタマイズ、パスワードでのロック、または変換プロセスの進行方法を指定できます。

### **カスタム オプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを指定できます。

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

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込み Excel ブックが含まれている場合、PDF の受信者がスライドの表示に加えてブックのデータにアクセスできるようにしたいことがあります。`True` を指定して [setIncludeOleData](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setIncludeOleData) を呼び出すと、埋め込み OLE ファイルを結果の PDF に添付ファイルとして保持できます。

デフォルト値は `False` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `True` に設定すると、ファイルデータが追加で添付されます。プレビューは視覚的表現のままで、添付ファイルにより受信者は埋め込みファイルを個別に開くか保存できます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

以下の例は、すでに埋め込み Excel ブックを含むプレゼンテーションを読み込み、ブックを添付した状態で PDF にエクスポートします。

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
2. ビューアの **Attachments** パネルを開き、埋め込みブックを探します。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF 準拠設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

以下の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

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

### **パスワードで保護された PDF に PowerPoint を変換**

以下の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷を許可し、高品質印刷も可能です。

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。警告は、使用できないフォントがエクスポート時に置換されたときのみ出力されます。JPype プロキシを使用して Java API から警告コールバックを受け取ります。チェックする前に Java の説明文字列を Python の文字列に変換してプレフィックスを確認してください：

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
フォント置換の詳細については、[フォント置換](/slides/ja/python-java/font-substitution/) 記事をご覧ください。
{{% /alert %}}

## **PowerPoint から選択したスライドを PDF に変換**

[Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) に渡すスライド番号は 1 から始まります。この例は、スライド 1 と 3 が存在する場合にそれらをエクスポートします：

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

## **カスタム スライドサイズで PowerPoint を PDF に変換**

この例は、ページサイズ 612 x 792 ポイント（US Letter）の用紙に最初のスライドをエクスポートします。指定したサイズの新しいプレゼンテーションにスライドをクローンし、スライド内容をフィットするようにスケーリングします。

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

    # 新しいプレゼンテーションで作成された空白スライドを削除します。
    resized_presentation.getSlides().removeAt(1)

    resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
    resized_presentation.dispose()
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下に配置します。スピーカーノートを含むプレゼンテーションを使用して結果をご確認ください。

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

アクセシブルな PDF を作成する際は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) を参照してください。出力標準を選択するには、[PdfOptions.setCompliance](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setCompliance) を使用し、**PDF/A1a**、**PDF/A1b**、**PDF/UA** のいずれかを指定します。

このコードは、異なる準拠基準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています：

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

> **Note:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF に一括変換することをサポートしています。ファイルを順に処理し、プログラムで変換プロセスを適用できます。

**変換された PDF をパスワードで保護することは可能ですか？**

はい。変換プロセス中にパスワードとアクセス権限を設定するには、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスを使用します。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

結果の PDF に非表示スライドを含めるには、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスで `True` を指定して [setShowHiddenSlides](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) を呼び出します。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setJpegQuality) や [setSufficientResolution](https://reference.aspose.com/slides/python-java/aspose.slides/pdfoptions/#setSufficientResolution) などのメソッドを使用して画像品質を制御し、PDF の高品質画像を確保できます。

**Aspose.Slides は PDF/A 準拠基準をサポートしていますか？**

はい、Aspose.Slides は、アクセシビリティやアーカイブのために PDF/A1a、PDF/A1b、PDF/UA などの [various standards](https://reference.aspose.com/slides/python-java/aspose.slides/pdfcompliance/) に準拠した PDF のエクスポートを可能にします。適切な標準を選択し、要件に合わせて出力を確認してください。

## **追加リソース**

- [Aspose.Slides for Python via Java ドキュメント](/slides/ja/python-java/)
- [Aspose.Slides for Python via Java API リファレンス](https://reference.aspose.com/slides/python-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)