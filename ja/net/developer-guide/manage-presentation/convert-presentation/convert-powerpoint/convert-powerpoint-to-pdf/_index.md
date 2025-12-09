---
title: .NETでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /ja/net/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointからPDFへ
- プレゼンテーションからPDFへ
- PPTからPDFへ
- PPTをPDFに変換
- PPTXからPDFへ
- PPTXをPDFに変換
- PowerPointをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: ".NETでAspose.Slidesを使用してPowerPoint PPT/PPTXを高品質かつ検索可能なPDFに変換し、迅速なC#コード例と高度な変換オプションを提供します。"
---

## **概要**

C# で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式を保持できるという利点があります。このガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、特定スライドの選択変換、出力文書へのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET は API 情報とバージョン番号を出力文書に挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値が入力されます。**注意**：この情報を出力文書から変更または除去するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では、次のように変換できます。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションにできるだけ近い状態になるようにします。変換時に正確にレンダリングされる要素と属性は以下のとおりです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint-to-PDF 変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を使用して提供されたプレゼンテーションを PDF に変換しようとします。

以下の C# コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose は無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスをデモンストレーションします。このコンバーターでテストを実行すれば、ここで説明した手順を実際に確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの取り扱い方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```c#
// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions
{
    // JPG 画像の品質を設定します。
    JpegQuality = 90,

    // 画像の DPI を設定します。
    SufficientResolution = 300,

    // メタファイルの処理方法を設定します。
    SaveMetafilesAsPng = true,

    // テキストコンテンツの圧縮レベルを設定します。
    TextCompression = PdfTextCompression.Flate,

    // PDF のコンプライアンスモードを定義します。
    Compliance = PdfCompliance.Pdf15
};

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// プレゼンテーションを PDF ドキュメントとして保存します。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを PDF のページとして出力に含めることができます。

以下の C# コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
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

以下の C# コードは、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。
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

Aspose.Slides は [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下の C# コードは、フォント置換を検出する方法を示しています。
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

レンダリング中のフォント置換に対するコールバック受信の詳細については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換に関する詳細は、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **選択したスライドだけを PowerPoint から PDF に変換**

以下の C# コードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。
```c#
// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// スライド番号の配列を設定します。
int[] slides = { 1, 3 };

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の C# コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```c#
var slideWidth = 612;
var slideHeight = 792;

// PowerPoint プレゼンテーションをロードします。
using var presentation = new Presentation("SelectedSlides.pptx");

// 調整されたスライドサイズで新しいプレゼンテーションを作成します。
using var resizedPresentation = new Presentation();

// カスタムスライドサイズを設定します。
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// 元のプレゼンテーションから最初のスライドをクローンします。
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// リサイズされたプレゼンテーションをノート付きの PDF として保存します。
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```


## **ノート スライド ビューで PowerPoint を PDF に変換**

以下の C# コードは、ノートを含む PDF として PowerPoint プレゼンテーションを変換する方法を示しています。
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

// ノート付きの PDF としてプレゼンテーションを保存します。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```


## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の C# コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint-to-PDF 変換プロセスを示しています。
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

Aspose.Slides は PDF 変換操作もサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) の変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) といった特殊形式への変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートしています。ファイルを列挙してプログラムから変換処理を実行できます。

**変換後の PDF にパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードとアクセス権限を設定し、変換時に適用できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの `ShowHiddenSlides` プロパティを `true` に設定すると、非表示スライドが生成される PDF に含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、`JpegQuality` や `SufficientResolution` などのプロパティを [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF 内の画像を高品質に保つことができます。

**PDF/A のコンプライアンス標準はサポートされていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などの各種標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティやアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for .NET Documentation](/slides/ja/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)