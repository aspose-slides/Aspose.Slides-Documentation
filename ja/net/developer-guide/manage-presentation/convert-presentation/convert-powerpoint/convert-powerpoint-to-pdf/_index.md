---
title: .NET で PPT と PPTX を PDF に変換 [高度機能を含む]
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
description: "Aspose.Slides を使用して .NET で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速な C# コード例と高度な変換オプションを提供します。"
---
## **概要**

C# で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、デバイス間の互換性やプレゼンテーションのレイアウト・書式を保持できるなどの利点があります。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、変換対象スライドの選択、出力ドキュメントへのコンプライアンス基準の適用方法を説明します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスにファイル名を渡し、[Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/) クラスは、通常 PDF への変換に使用される [Save](https://reference.aspose.com/slides/ja/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する際、Application フィールドには "*Aspose.Slides*"、PDF Producer フィールドには "*Aspose.Slides v XX.XX*" の形式の値が設定されます。**注意**：この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションとほぼ同一の PDF を生成します。変換時に正確にレンダリングされる要素と属性は以下のとおりです。

* 画像
* テキストボックスおよび図形
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換する**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を用いてプレゼンテーションを PDF に変換しようとします。

以下の C# コードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.ppt");

// プレゼンテーションを PDF として保存します。
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモンストレーションする無料のオンライン **PowerPoint to PDF コンバータ**（https://products.aspose.app/slides/ja/conversion/ppt-to-pdf）を提供しています。このコンバータでテストを実行すると、本ガイドで説明した手順を実際に体験できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラス配下のカスタムオプション（プロパティ）を提供し、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの動作指定が可能です。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの取り扱い、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions
{
    // JPG 画像の品質を設定します。
    JpegQuality = 90,

    // 画像の DPI を設定します。
    SufficientResolution = 300,

    // メタファイルの扱いを設定します。
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

### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを PDF のページとして含めることができます。

以下の C# コードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// PdfOptions クラスのインスタンスを作成します。
var pdfOptions = new PdfOptions();

// 非表示スライドを追加します。
pdfOptions.ShowHiddenSlides = true;

// プレゼンテーションを PDF として保存します。
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **パスワード保護された PDF に PowerPoint を変換する**

以下の C# コードは、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラス配下の [WarningCallback](https://reference.aspose.com/slides/ja/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換中にフォント置換を検出できます。

以下の C# コードは、フォント置換を検出する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

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

{{%  alert color="info"  %}} 

レンダリング中のフォント置換コールバックの取得方法については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換の詳細については、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **PowerPoint の特定スライドだけを PDF に変換する**

以下の C# コードは、PowerPoint プレゼンテーションから特定のスライドだけを抽出して PDF に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
using var presentation = new Presentation("PowerPoint.pptx");

// スライド番号の配列を設定します。
int[] slides = { 1, 3 };

// プレゼンテーションを PDF として保存します。
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタムスライドサイズで PowerPoint を PDF に変換する**

以下の C# コードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// PowerPoint プレゼンテーションを読み込みます。
using var presentation = new Presentation("SelectedSlides.pptx");

// 調整されたスライドサイズで新しいプレゼンテーションを作成します。
using var resizedPresentation = new Presentation();

// カスタムスライドサイズを設定します。
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// 元のプレゼンテーションから最初のスライドをクローンします。
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// 新しいプレゼンテーションに作成された空白スライドを削除します。
resizedPresentation.Slides.RemoveAt(1);

// リサイズされたプレゼンテーションを PDF として保存します。
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **ノートスライドビューで PowerPoint を PDF に変換する**

以下の C# コードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// PowerPoint プレゼンテーションを読み込みます。
using var presentation = new Presentation("NotesFile.pptx");

// ノートレイアウトで PDF オプションを設定します。
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// ノート付きでプレゼンテーションを PDF に保存します。
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF のアクセシビリティとコンプライアンス基準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の C# コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Aspose.Slides は PDF 変換操作もサポートしており、PDF ファイルを一般的な形式に変換できます。たとえば、[PDF to HTML](https://products.aspose.com/slides/ja/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/net/conversion/pdf-to-png/) への変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/ja/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/net/conversion/pdf-to-xml/) といった特殊形式への変換もサポートされています。

{{% /alert %}}

> **注**：PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個別のパス要素は別々のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

### 複数の PowerPoint ファイルを一括で PDF に変換できますか？

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチで PDF に変換することをサポートしています。ファイルを列挙してプログラムから変換プロセスを実行できます。

### 変換後の PDF にパスワードを設定できますか？

もちろんです。[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードとアクセス許可を設定し、変換時に保護できます。

### PDF に非表示スライドを含めるにはどうすればよいですか？

[PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスの `ShowHiddenSlides` プロパティを `true` に設定すると、生成される PDF に非表示スライドが含まれます。

### Aspose.Slides は PDF の画像品質を高く保てますか？

はい、`JpegQuality` や `SufficientResolution` などのプロパティを [PdfOptions](https://reference.aspose.com/slides/ja/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF 内の画像品質を高く保つことができます。

### PDF/A コンプライアンス標準はサポートされていますか？

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などの各種標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](/slides/ja/net/)
- [Aspose.Slides for .NET API リファレンス](https://reference.aspose.com/slides/ja/net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/ja/conversion)