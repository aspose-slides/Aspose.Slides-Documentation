---
title: C#でPPTおよびPPTXをPDFに変換 [高度な機能を含む]
linktitle: PPTおよびPPTXをPDFに変換
type: docs
weight: 40
url: /ja/net/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointをPDFに変換
- プレゼンテーションをPDFに変換
- PPTをPDFに変換
- PPTをPDFに変換
- PPTXをPDFに変換
- PPTXをPDFに変換
- ODPをPDFに変換
- ODPをPDFに変換
- PowerPointをPDFとして保存
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides for .NET
description: "C# または .NET で Aspose.Slides を使用して PPT、PPTX、ODP プレゼンテーションを PDF に変換する方法を学びます。パスワード保護、コンプライアンス標準、カスタムオプションなどの高度な機能を実装し、高品質でアクセシブルな PDF 文書を作成します。"
---

## **概要**

C# で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式設定を保持できるなど、いくつかの利点があります。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択的変換、および出力ドキュメントにコンプライアンス標準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスにファイル名を引数として渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides for .NET は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換すると、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**Note** この情報を出力ドキュメントから変更または削除するように指示することはできません。
{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い結果になるようにします。変換時に正確にレンダリングされる要素と属性には、以下が含まれます。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルト オプションを使用します。この場合、Aspose.Slides は最高品質レベルの最適設定で提供されたプレゼンテーションを PDF に変換しようとします。

この C# コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 
Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料のオンライン **PowerPoint to PDF converter**(https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行すると、ここで説明する手順のライブ実装を確認できます。
{{% /alert %}}

## **PowerPoint を PDF に変換（オプション付き）**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタム オプションを提供し、結果の PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタム オプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の好みの品質設定を定義したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像の DPI を構成したりできます。

以下のコード例は、いくつかのカスタム オプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示します。
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

    // PDF のコンプライアンス モードを定義します。
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// プレゼンテーションを PDF ドキュメントとして保存します。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを結果の PDF のページとして含めることができます。

この C# コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
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


### **パスワード保護された PDF に PowerPoint を変換**

この C# コードは、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions();

// PDF のパスワードとアクセス権限を設定します。
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

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

// 警告コールバックの実装。
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
レンダリング プロセス中のフォント置換に関するコールバックの取得については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細は、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。
{{% /alert %}} 

## **PowerPoint から選択したスライドだけを PDF に変換**

この C# コードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています:
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// スライド番号の配列を設定します。
int[] slides = { 1, 3 };

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **カスタム スライド サイズで PowerPoint を PDF に変換**

この C# コードは、指定したスライド サイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています:
```c#
var slideWidth = 612;
var slideHeight = 792;

// PowerPoint プレゼンテーションをロードします。
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


## **ノート スライド ビューで PowerPoint を PDF に変換**

この C# コードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています:
```c#
// PowerPointプレゼンテーションをロードします。
using var presentation = new Presentation("NotesFile.pptx");

// NotesレイアウトでPDFオプションを設定します。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// ノート付きPDFとしてプレゼンテーションを保存します。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できるようにします。次のコンプライアンス標準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます: **PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

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
Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、および [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) の変換が可能です。その他の専門フォーマットへの変換 — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、および [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) — もサポートされています。
{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを列挙してプログラムで変換処理を適用できます。

**変換後の PDF にパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードを設定し、変換時にアクセス権限を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの `ShowHiddenSlides` プロパティを `true` に設定すると、結果の PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、`JpegQuality` や `SufficientResolution` などのプロパティを [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートし、アクセシビリティとアーカイブ要件を満たすことができます。

## **Additional Resources**

- [Aspose.Slides for .NET Documentation](/slides/ja/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)