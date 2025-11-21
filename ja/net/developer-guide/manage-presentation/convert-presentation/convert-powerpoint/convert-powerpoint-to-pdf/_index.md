---
title: .NETでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/net/convert-powerpoint-to-pdf/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換し、迅速な C# コード例と高度な変換オプションを提供します。"
---

## **概要**

C#でPowerPointプレゼンテーション（PPT、PPTX、ODPなど）をPDF形式に変換すると、さまざまな利点があります。デバイス間の互換性が向上し、プレゼンテーションのレイアウトや書式設定が保持されます。このガイドでは、プレゼンテーションをPDFドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDFファイルへのパスワード保護、フォント置換の検出、特定のスライドの選択変換、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスに渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドを使用して PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)クラスは通常、プレゼンテーションを PDF に変換するために使用される[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/)メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET は API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する際、Application フィールドには「*Aspose.Slides*」が、PDF Producer フィールドには「*Aspose.Slides v XX.XX*」形式の値が設定されます。**注意** Aspose.Slides にこの情報を変更または削除させることはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になるようにします。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキストボックスと図形
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルの最適な設定で提供されたプレゼンテーションを PDF に変換しようとします。

この C# コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose は無料のオンライン[**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しており、プレゼンテーションから PDF への変換プロセスを実演しています。このコンバータを使用して、本記事で説明した手順をライブでテストできます。

{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、結果の PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進め方を指定したりできます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```c#
 // PdfOptions クラスのインスタンスを作成します。
 var pdfOptions = new PdfOptions
 {
     // JPG 画像の品質を設定します。
     JpegQuality = 90,

     // 画像の DPI を設定します。
     SufficientResolution = 300,

     // メタファイルの動作を設定します。
     SaveMetafilesAsPng = true,

     // テキスト コンテンツの圧縮レベルを設定します。
     TextCompression = PdfTextCompression.Flate,

     // PDF コンプライアンス モードを定義します。
     Compliance = PdfCompliance.Pdf15
 };

 // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
 using var presentation = new Presentation("PowerPoint.pptx");

 // プレゼンテーションを PDF ドキュメントとして保存します。
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **非表示スライド付きでPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを結果の PDF のページとして含めることができます。

この C# コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions();

// 非表示スライドを追加します。
pdfOptions.ShowHiddenSlides = true;

// プレゼンテーションを PDF に保存します。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **パスワード保護されたPDFにPowerPointを変換**

この C# コードは、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions();

// PDF のパスワードとアクセス許可を設定します。
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **フォント置換の検出**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

この C# コードは、フォント置換を検出する方法を示しています:
```c#
public static void Main()
{
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。 
    using var presentation = new Presentation("sample.pptx");

    // PDF オプションに警告コールバックを設定します。
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // プレゼンテーションを PDF として保存します。
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// 警告コールバックの実装です。
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

レンダリングプロセス中のフォント置換に関するコールバックの取得方法の詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細情報は、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPointから選択したスライドをPDFに変換**

この C# コードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// スライド番号の配列を設定します。
int[] slides = { 1, 3 };

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **カスタムスライドサイズでPowerPointをPDFに変換**

この C# コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **ノートスライドビューでPowerPointをPDFに変換**

この C# コードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています:
```c#
// PowerPoint プレゼンテーションを読み込む。
using var presentation = new Presentation("NotesFile.pptx");

// ノートレイアウトを使用して PDF オプションを設定する。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// プレゼンテーションをノート付き PDF として保存する。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **PDFのアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます: **PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この C# コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています:
```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) などの特殊形式への変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数のPowerPointファイルを一括でPDFに変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを列挙し、プログラムから変換プロセスを適用できます。

**変換した PDF にパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して、変換プロセス中にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの `ShowHiddenSlides` プロパティを `true` に設定すると、結果の PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、`JpegQuality` や `SufficientResolution` などのプロパティを [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **Additional Resources**

- [Aspose.Slides for .NET Documentation](/slides/ja/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)