---
title: .NET で PPT と PPTX を PDF に変換する [高度な機能を含む]
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
description: " .NET で Aspose.Slides を使用して、PowerPoint の PPT/PPTX を高品質で検索可能な PDF に変換します。高速な C# コード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション (PPT、PPTX、ODP など) を C# で PDF 形式に変換することには、さまざまな利点があります。デバイス間での互換性や、プレゼンテーションのレイアウトや書式設定を保持できる点などです。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、変換対象の特定スライドの選択、出力ドキュメントへの準拠基準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスは、プレゼンテーションを PDF に変換する際に通常使用される [Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに "*Aspose.Slides*"、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" という形式の値を設定します。**Note** この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションにできるだけ近い形になるよう保証します。変換時に正確にレンダリングされる要素と属性は以下のとおりです。

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を用いて提供されたプレゼンテーションを PDF に変換しようとします。

この C# コードは、プレゼンテーション (PPT、PPTX、ODP など) を PDF に変換する方法を示しています。

```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しています。このコンバーターを使用して、本ガイドで説明した手順を実際にテストできます。

{{% /alert %}}

## **PowerPoint をオプション付きで PDF に変換**

Aspose.Slides は、結果の PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進め方を指定したりできるカスタムオプション（[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスのプロパティ）を提供します。

### **PowerPoint をカスタムオプション付きで PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI 設定などを指定できます。

以下のコード例は、いくつかのカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

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

    // PDF 準拠モードを定義します。
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// プレゼンテーションを PDF ドキュメントとして保存します。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **PowerPoint を非表示スライド付きで PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを生成された PDF のページとして含めることができます。

この C# コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

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

### **PowerPoint をパスワード保護 PDF に変換**

この C# コードは、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

この C# コードは、フォント置換を検出する方法を示しています。

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

レンダリングプロセス中のフォント置換に関するコールバック取得の詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。フォント置換の詳細については、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPoint から選択したスライドを PDF に変換**

この C# コードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。

```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// スライド番号の配列を設定します。
int[] slides = { 1, 3 };

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

この C# コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```c#
var slideWidth = 612;
var slideHeight = 792;

// PowerPoint プレゼンテーションを読み込みます。
using var presentation = new Presentation("SelectedSlides.pptx");

// スライドサイズを調整した新しいプレゼンテーションを作成します。
using var resizedPresentation = new Presentation();

// カスタムスライドサイズを設定します。
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// 元のプレゼンテーションから最初のスライドをクローンします。
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// リサイズしたプレゼンテーションをノート付きの PDF として保存します。
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

## **ノートスライドビューで PowerPoint を PDF に変換**

この C# コードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています。

```c#
// PowerPoint プレゼンテーションを読み込みます。
using var presentation = new Presentation("NotesFile.pptx");

// Configure the PDF options with Notes Layout.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Save the presentation to a PDF with notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF のアクセシビリティと準拠基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できるようにします。次の準拠基準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

この C# コードは、異なる準拠基準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なフォーマットに変換できます。[PDF to HTML](https://products.aspose.com/slides/ja/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/net/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/ja/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/net/conversion/pdf-to-xml/) といった特殊フォーマットへの変換もサポートされています。

{{% /alert %}}

> **Note:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があり、代替テキストは全体の図に対してのみ提供されます。

## **よくある質問**

**複数の PowerPoint ファイルをまとめて PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを反復処理し、プログラムで変換プロセスを適用できます。

**変換された PDF にパスワード保護を設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスを使用して、変換プロセス中にパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの `ShowHiddenSlides` プロパティを `true` に設定すると、生成された PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの `JpegQuality` や `SufficientResolution` などのプロパティを設定することで、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A 準拠標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートを可能にし、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for .NET Documentation](/slides/ja/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/ja/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ja/conversion)