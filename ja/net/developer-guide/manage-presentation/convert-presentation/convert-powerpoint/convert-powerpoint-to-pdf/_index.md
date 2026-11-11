---
title: ".NET で PPT と PPTX を PDF に変換 [高度な機能を含む]"
linktitle: "PowerPoint を PDF に変換"
type: docs
weight: 40
url: /ja/net/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint を変換"
- "プレゼンテーションを変換"
- "PowerPoint を PDF に変換"
- "プレゼンテーションを PDF に変換"
- "PPT を PDF に変換"
- "PPT を PDF に変換"
- "PPTX を PDF に変換"
- "PPTX を PDF に変換"
- "PowerPoint を PDF として保存"
- "PPT を PDF として保存"
- "PPTX を PDF として保存"
- "PPT を PDF にエクスポート"
- "PPTX を PDF にエクスポート"
- "添付ファイル"
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速な C# コード例と高度な変換オプションを提供します。"
---
## **概要**

C# で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウトと書式設定を保持できるなど、いくつかの利点があります。このガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、そして出力ドキュメントにコンプライアンス標準を適用する方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注** Aspose.Slides に対して、この情報を出力ドキュメントから変更または削除するよう指示することはできません。
{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに非常に近いことを保証します。変換では次の要素と属性が正確にレンダリングされます。

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最高品質レベルの最適な設定で PDF に変換しようとします。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドを PDF に保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、ここで説明した手順の実装をライブで確認できます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスのプロパティであるカスタムオプションを提供し、生成される PDF をカスタマイズしたり、パスワードで PDF をロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の好みの品質設定を定義したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像の DPI を構成したり、その他多数の設定ができます。

以下の例は、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を使用して PDF 1.5 にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

> **注:** PDF に変換する際に `PdfOptions.SufficientResolution` を高い値（例: `300`）に設定すると、テキストの影や反射効果のレンダリング品質を向上させることができます。これにより、Microsoft PowerPoint の外観により近い PDF 出力が得られます。

### **画像圧縮の自動選択**

プレゼンテーションに多数の写真やスクリーンショットが含まれている場合、エクスポートされた PDF のサイズを縮小すると、メールやダウンロードが容易になります。PDF エクスポート時に各画像に最適な圧縮アルゴリズムを自動的に選択するには、[PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) を `true` に設定します。

以下の例は既存のプレゼンテーションを読み込み、自動画像圧縮選択を有効にして PDF ドキュメントとして保存します。他の PDF エクスポート設定はすべてデフォルト値のままです。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

このオプションは各画像に対して圧縮アルゴリズムを選択します。[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) を下げると JPEG 画像の品質が低下し、[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) を下げると画像が低解像度にダウンサンプルされ、ディテールが減少する可能性があります。自動圧縮選択を有効にしても、これらの設定が自動的に下がることはありません。

画像圧縮アルゴリズムの選択には追加の処理時間とメモリが必要です。サイズ削減はプレゼンテーションの画像とエクスポート設定に依存し、すべてのプレゼンテーションで一定の削減が保証されるわけではありません。

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込み Excel ワークブックが含まれている場合、PDF の受信者がスライドを表示できるだけでなく、ワークブックのデータにもアクセスできるようにしたいことがあります。結果の PDF に埋め込み OLE ファイルを添付として保持するには、[PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) を `true` に設定します。

デフォルト値は `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付として含まれません。オプションを `true` に設定すると、ファイルデータも追加で含まれます。プレビューは視覚的表現のままであり、添付は受信者が埋め込みファイルを別途開くまたは保存できるようにします。OLE オブジェクト自体が PDF ページ上で対話的な Excel ワークシートになることはありません。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

結果を確認するには:

1. Adobe Acrobat Reader などの添付ファイルに対応したビューアでエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを見つけます。
3. 添付ファイルを保存して Excel でデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課しています。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを結果の PDF のページとして含めることができます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **パスワード保護された PDF に PowerPoint を変換**

以下の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷を許可しており、高品質印刷も含まれます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
フォント置換についての詳細は、[フォント置換](/slides/ja/net/font-substitution/) 記事をご覧ください。
{{% /alert %}} 

### **専用の太字フォントがないフォントの処理**

プレゼンテーションは、フォントに専用の太字体がない場合でも太字書式を適用できます。テキストは合成太字により人工的に太く見えることがありますが、PDF で重すぎたり期待した外観と異なる場合は、[PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) を `true` に設定してみてください。このオプションは、対象フォントに専用の太字体がない場合に太字テキストをビットマップとしてレンダリングし、特定のフォントで外観を改善できることがあります。デフォルト値は `false` です。

サンプルのプレゼンテーションには、同じフォントで通常テキストと太字書式が適用されたテキストボックスがそれぞれ 1 つずつ含まれています。以下の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にして PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

以下のプレビューは、オプションが無効な場合と有効な場合を示しています。この例では、オプションが無効な場合、太字テキストのストロークが太くなります。オプションを有効にすると、ストロークが細くなり、通常テキストは変わりません。結果を比較して、プレゼンテーションに適した設定を選択してください。

| オプション無効 (`false`, デフォルト) | オプション有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストのみがビットマップ化されます。OCR なしではテキストとして選択、コピー、検索できず、800% ズーム時にエッジがやわらかく表示されます。通常テキストは検索可能なままです。オプションが無効な場合、両方の文字列がテキストとして残ります。

このオプションは、フォントに専用の太字体がない場合に太字としてフォーマットされたテキストをラスタライズします。[フォント置換](/slides/ja/net/font-substitution/) は、元のフォントが利用できない場合に別のフォントを選択します。

## **PowerPoint から選択したスライドを PDF に変換**

以下の例はプレゼンテーションからスライド 1 と 3 をエクスポートして PDF に保存します。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションの最初のスライドを 612 × 792 ポイント（8.5 × 11 インチ）のスライドサイズを持つ新しいプレゼンテーションにコピーします。スライドコンテンツはフィットするように拡大縮小され、単一スライドが PDF にエクスポートされます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下の例はプレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下部に配置します。結果を確認するには、スピーカーノートを含むプレゼンテーションを使用してください。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

この C# コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、および [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 変換を実行できます。その他の専門フォーマットへの PDF 変換操作—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、および [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—もサポートされています。
{{% /alert %}}

> **注:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあり、代替テキストは全体の図形に対してのみ提供されます。

## **よくある質問**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換することをサポートしています。ファイルを順に処理し、プログラムで変換プロセスを適用できます。

**変換された PDF にパスワードを設定できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードを設定し、アクセス権限を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

結果の PDF に非表示スライドを含めるには、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを `true` に設定します。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) や [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) などのプロパティを [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF 内の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF をエクスポートでき、文書がアクセシビリティおよび保存要件を満たすようにします。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](/slides/ja/net/)
- [Aspose.Slides for .NET API リファレンス](https://reference.aspose.com/slides/net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)

関連機能: [PDF へのプレゼンテーション エクスポート](/slides/ja/features/pdf-export/).