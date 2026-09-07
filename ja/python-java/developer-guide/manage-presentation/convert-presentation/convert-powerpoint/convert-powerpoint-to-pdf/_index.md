---
title: Python via Java で PPT と PPTX を PDF に変換（高度な機能を含む）
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
- PDF/A1a
- PDF/A1b
- PDF/UA
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides を使用して、Python（via Java）で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

Python（via Java）で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換することには、デバイス間の互換性やプレゼンテーションのレイアウト・書式を保持できるなど、さまざまな利点があります。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択変換、そして出力ドキュメントにコンプライアンス基準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスにファイル名を引数として渡し、[save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) メソッドを公開しています。

{{% alert color="info" title="注" %}}
Aspose.Slides for Python via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注**：この情報を出力ドキュメントから変更または削除するよう Aspose.Slides に指示することはできません。
{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になるよう保証します。変換時には以下の要素と属性が正確にレンダリングされます。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準変換はデフォルトの PDF エクスポート設定を使用します。画像品質、ページ内容、または PDF コンプライアンスを制御する必要がある場合はカスタムオプションを使用してください。

例を実行する前に、[Aspose.Slides for Python via Java](/slides/ja/python-java/installation/) と互換性のある Java ランタイムをインストールします。各例はカレントディレクトリの `presentation.pptx` を読み込みます。対象の PPT、PPTX、または ODP ファイルに置き換えてください。JVM は Python プロセスごとに一度だけ開始します。

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

{{% alert color="info" title="注" %}}
Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料のオンライン **PowerPoint to PDF コンバータ** を提供しています。このコンバータでテストを実行すると、ここで説明する手順の実際の実装を確認できます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) クラスのプロパティとして提供されるカスタムオプションを通じて、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの進め方を指定できます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを自由に指定できます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfCompliance, PdfOptions, PdfTextCompression, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setJpegQuality(jpype.JByte(90))
    pdf_options.setSufficientResolution(300)
    pdf_options.setSaveMetafilesAsPng(True)
    pdf_options.setTextCompression(PdfTextCompression.Flate)
    pdf_options.setCompliance(PdfCompliance.Pdf15)
    presentation.save("presentation-custom.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **非表示スライド付きで PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、非表示スライドを結果 PDF のページとして含めることができます。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setShowHiddenSlides(True)
    presentation.save("presentation-hidden-slides.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **パスワード保護付き PDF に PowerPoint を変換**

以下のコードは、[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護付き PDF に変換する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfAccessPermissions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.setPassword("password")
    permissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint
    pdf_options.setAccessPermissions(permissions)
    presentation.save("presentation-protected.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) クラス配下の [setWarningCallback](https://reference.aspose.com/slides/ja/python-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションから PDF への変換中にフォント置換を検出できるようにします。

Java API からの警告コールバックを受け取るには JPype プロキシを使用します。Java の説明文字列を Python の文字列に変換してからプレフィックスを確認してください。

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


presentation = Presentation("presentation.pptx")
try:
    handler = FontSubstitutionHandler()
    callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
    pdf_options = PdfOptions()
    pdf_options.setWarningCallback(callback)
    presentation.save("presentation-font-warnings.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="注" %}}
レンダリング処理中のフォント置換に関するコールバック受信の詳細は、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細情報は、[Font Substitution](/slides/ja/python-java/font-substitution/) 記事をご覧ください。
{{% /alert %}}

## **PowerPoint の選択スライドを PDF に変換**

[Presentation.save](https://reference.aspose.com/slides/ja/python-java/aspose.slides/presentation/#save) に渡すスライド番号は 1 から始まります。この例では、スライド 1 と 3 が存在する場合にそれらをエクスポートします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    if presentation.getSlides().size() >= 3:
        slide_numbers = jpype.JArray(jpype.JInt)([1, 3])
        presentation.save("presentation-selected-slides.pdf", slide_numbers, SaveFormat.Pdf)
    else:
        print("The presentation must contain at least three slides.")
finally:
    presentation.dispose()
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

この例は、ページサイズ 612 × 792 ポイント（US Letter）に最初のスライドをエクスポートします。スライドを指定サイズの新しいプレゼンテーションにクローンします。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation("presentation.pptx")
try:
    resized_presentation = Presentation()
    try:
        resized_presentation.getSlideSize().setSize(612.0, 792.0, SlideSizeScaleType.EnsureFit)
        if presentation.getSlides().size() > 0:
            slide = presentation.getSlides().get_Item(0)
            resized_presentation.getSlides().insertClone(0, slide)
            resized_presentation.getSlides().removeAt(1)
            resized_presentation.save("presentation-custom-size.pdf", SaveFormat.Pdf)
        else:
            print("The presentation contains no slides.")
    finally:
        resized_presentation.dispose()
finally:
    presentation.dispose()
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下のコードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています。

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(notes_options)
    presentation.save("presentation-with-notes.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

## **PDF のアクセシビリティとコンプライアンス基準**

アクセシブルな PDF を作成する際は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) を参照してください。[PdfOptions.setCompliance](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setCompliance) を使用して出力標準を選択できます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

> **注**：PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個別のパス要素は別々のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**  
はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチで PDF に変換する機能をサポートしています。ファイルを列挙し、プログラム的に変換処理を適用できます。

**変換された PDF にパスワード保護を設定できますか？**  
はい。[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) クラスでパスワードとアクセス権限を設定して、変換時に PDF を保護できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**  
[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、結果 PDF に非表示スライドをページとして含めます。

**Aspose.Slides は PDF の高画質画像を維持できますか？**  
はい。[PdfOptions](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/) の [setJpegQuality](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setJpegQuality) や [setSufficientResolution](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfoptions/#setSufficientResolution) などのメソッドを使用して、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**  
はい、Aspose.Slides は [さまざまな標準](https://reference.aspose.com/slides/ja/python-java/aspose.slides/pdfcompliance/)（PDF/A1a、PDF/A1b、PDF/UA など）に準拠した PDF のエクスポートをサポートしています。目的に合わせた標準を選択し、要件に合致しているか出力を確認してください。

## **追加リソース**

- [Aspose.Slides for Python via Java ドキュメント](/slides/ja/python-java/)
- [Aspose.Slides for Python via Java API リファレンス](https://reference.aspose.com/slides/ja/python-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)