---
title: .NET で PPT と PPTX を PDF に変換（高度な機能を含む）
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
description: "Aspose.Slides を使用して .NET で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換し、迅速な C# コード例と高度な変換オプションを提供します。"
---

## **概要**

C# で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式設定を保持できるなどの利点があります。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択変換、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスにファイル名を引数として渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換すると、Aspose.Slides は Application フィールドに "*Aspose.Slides*"、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" 形式の値を設定します。**注意**：この情報を出力ドキュメントから変更または削除するように指示することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドだけを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションに極めて近い PDF を生成します。変換時には以下の要素と属性が正確にレンダリングされます。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準の PowerPoint→PDF 変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最適な設定で最高品質レベルの PDF に変換しようとします。

この C# コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています：
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーション→PDF 変換プロセスを実演する無料のオンライン **PowerPoint to PDF converter** を提供しています。このコンバーターでテストを実行すれば、ここで説明した手順をライブで体験できます。

{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスのプロパティとして提供されるカスタムオプションを使用して、生成される PDF のカスタマイズ、パスワードでのロック、変換プロセスの進行方法を指定できます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを自由に定義できます。

以下のコード例は、さまざまなカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
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

     // テキストコンテンツの圧縮レベルを設定します。
     TextCompression = PdfTextCompression.Flate,

     // PDF コンプライアンスモードを定義します。
     Compliance = PdfCompliance.Pdf15
 };

 // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
 using var presentation = new Presentation("PowerPoint.pptx");

 // プレゼンテーションを PDF ドキュメントとして保存します。
 presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **非表示スライドを含めてPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを結果の PDF のページとして含めることができます。

この C# コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています：
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions();

// 非表示スライドを追加します。
pdfOptions.ShowHiddenSlides = true;

// プレゼンテーションを PDF として保存します。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **パスワード保護されたPDFにPowerPointを変換**

この C# コードは、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています：
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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供しており、プレゼンテーション→PDF 変換プロセス中のフォント置換を検出できます。

この C# コードは、フォント置換を検出する方法を示しています：
```c#
public static void Main()
{
    // PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
    using var presentation = new Presentation("sample.pptx");

    // PDF オプションで警告コールバックを設定します。
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

レンダリング中にフォント置換のコールバックを取得する詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細情報は、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPointの選択したスライドをPDFに変換**

この C# コードは、PowerPoint プレゼンテーションから特定のスライドだけを選択して PDF に変換する方法を示しています：
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// スライド番号の配列を設定します。
int[] slides = { 1, 3 };

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **カスタムスライドサイズでPowerPointをPDFに変換**

この C# コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています：
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

この C# コードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています：
```c#
// PowerPoint プレゼンテーションをロードします。
using var presentation = new Presentation("NotesFile.pptx");

// Notes レイアウトで PDF オプションを設定します。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// プレゼンテーションをノート付き PDF として保存します。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **PDFのアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用することをサポートしています。次のコンプライアンス標準のいずれかを使用して、PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の C# コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint→PDF 変換プロセスを示しています：
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

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルをさまざまな一般的な形式に変換できます。[PDF to HTML]、[PDF to image]、[PDF to JPG]、[PDF to PNG] の変換が可能です。また、[PDF to SVG]、[PDF to TIFF]、[PDF to XML] といった専門フォーマットへの変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換することをサポートしています。ファイルをループ処理し、プログラムから変換プロセスを適用できます。

**変換後の PDF にパスワード保護を設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用して、変換中にパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの `ShowHiddenSlides` プロパティを `true` に設定すると、結果の PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、`JpegQuality` や `SufficientResolution` などのプロパティを [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A のコンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートを可能にし、アクセシビリティとアーカイブ要件を満たします。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](/slides/ja/net/)
- [Aspose.Slides for .NET API リファレンス](https://reference.aspose.com/slides/net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)