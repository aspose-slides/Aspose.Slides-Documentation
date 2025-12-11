---
title: AndroidでPPTおよびPPTXをPDFに変換 [高度な機能を含む]
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /ja/androidjava/convert-powerpoint-to-pdf/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android を使用して、Java で PowerPoint の PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---

## **概要**

AndroidでPowerPointプレゼンテーション（PPT、PPTX、ODPなど）をPDF形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウト・書式を保持できるなど、多くの利点があります。このガイドでは、プレゼンテーションをPDF文書に変換する方法、画像品質を制御するさまざまなオプションの使用、非表示スライドの含め方、PDFファイルのパスワード保護、フォント置換の検出、特定のスライドだけを変換する方法、そして出力文書にコンプライアンス標準を適用する方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスに渡し、`save` メソッドを使用して PDF として保存します。[Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for Android via Java は、API情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」の形式の値を設定します。**注意**：Aspose.Slides にこの情報を出力ドキュメントから変更または削除させることはできません。
{{% /alert %}}

Aspose.Slides を使用すると、次の変換が可能です：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になるよう保証します。変換時には要素や属性が正確にレンダリングされ、以下が含まれます：

* 画像
* テキストボックスと図形
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準的な PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最高品質設定で最適に PDF に変換しようとします。

このコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示します：

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // プレゼンテーションを PDF として保存します。
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行すれば、ここで説明した手順を実際に体験できます。
{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワードでのロック、変換プロセスの進行方法を指定できます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```java
// PdfOptions クラスのインスタンスを作成します。
PdfOptions pdfOptions = new PdfOptions();

// Set the quality for JPG images.
pdfOptions.setJpegQuality((byte)90);

// Set DPI for images.
pdfOptions.setSufficientResolution(300);

/// メタファイルの動作を設定します。
pdfOptions.setSaveMetafilesAsPng(true);

// Set the text compression level for textual content.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Define the PDF compliance mode.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // プレゼンテーションを PDF ドキュメントとして保存します。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **非表示スライドを含めてPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) メソッドを使用して、非表示スライドを結果の PDF にページとして含めることができます。

このコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています：

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    PdfOptions pdfOptions = new PdfOptions();

    // 非表示スライドを追加します。
    pdfOptions.setShowHiddenSlides(true);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **パスワード保護されたPDFにPowerPointを変換**

このコードは、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています：

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // PdfOptions クラスのインスタンスを作成します。
    PdfOptions pdfOptions = new PdfOptions();

    // PDF のパスワードとアクセス権限を設定します。
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

このコードは、フォント置換を検出する方法を示しています：

```java
public static void main(String[] args) {
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
    Presentation presentation = new Presentation("sample.pptx");

    // PDF オプションに警告コールバックを設定します。
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // プレゼンテーションを PDF として保存します。
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// 警告コールバックの実装。
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 
レンダリングプロセス中のフォント置換に関するコールバック取得の詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換の詳細については、[Font Substitution](/slides/ja/androidjava/font-substitution/) 記事をご覧ください。
{{% /alert %}}

## **PowerPointから選択したスライドをPDFに変換**

このコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています：

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // スライド番号の配列を設定します。
    int[] slides = { 1, 3 };

    // プレゼンテーションを PDF として保存します。
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **カスタムスライドサイズでPowerPointをPDFに変換**

このコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています：

```java
float slideWidth = 612;
float slideHeight = 792;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");

// 調整されたスライドサイズで新しいプレゼンテーションを作成します。
Presentation resizedPresentation = new Presentation();

try {
    // カスタムスライドサイズを設定します。
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // 元のプレゼンテーションから最初のスライドをクローンします。
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // ノート付きの PDF にリサイズされたプレゼンテーションを保存します。
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **ノートスライドビューでPowerPointをPDFに変換**

このコードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています：

```java
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Notes Layout を使用して PDF オプションを設定します。
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // ノート付きでプレゼンテーションを PDF に保存します。
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **PDFのアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できるようにします。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

このコードは、さまざまなコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています：

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 
Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/)、および [PDF to PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/) の変換を実行できます。また、[PDF to SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) といった特殊形式への PDF 変換もサポートされています。
{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF に一括変換することをサポートしています。ファイルを順に処理し、プログラム上で変換プロセスを適用できます。

**変換された PDF にパスワード保護を設定できますか？**

もちろんです。変換プロセス中にパスワードを設定し、アクセス権限を定義するには、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスを使用します。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

結果の PDF に非表示スライドを含めるには、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用します。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) クラスの `setJpegQuality` や `setSufficientResolution` といったメソッドを使用して、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF をエクスポートでき、文書がアクセシビリティとアーカイブ要件を満たすことを保証します。

## **追加リソース**

- [Aspose.Slides for Android via Java ドキュメント](/slides/ja/androidjava/)
- [Aspose.Slides for Android via Java API リファレンス](https://reference.aspose.com/slides/androidjava/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)