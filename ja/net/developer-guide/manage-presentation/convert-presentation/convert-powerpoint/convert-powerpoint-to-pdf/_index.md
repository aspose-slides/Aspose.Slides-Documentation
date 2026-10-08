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
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides を使用して .NET で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換し、迅速な C# コード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション (PPT、PPTX、ODP など) を C# で PDF 形式に変換すると、デバイス間の互換性が向上し、プレゼンテーションのレイアウトや書式が保持されます。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御する各種オプションの使用方法、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、変換対象スライドの選択、出力ドキュメントへのコンプライアンス規格の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは、プレゼンテーションを PDF に変換する際に一般的に使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに「*Aspose.Slides*」が、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値が設定されます。**Note**: 出力ドキュメントからこの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションとほぼ同一になるようにします。変換時に正確にレンダリングされる要素と属性は以下の通りです。

* 画像
* テキストボックスとシェイプ
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換する**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルの最適設定で提供されたプレゼンテーションを PDF に変換しようとします。

次のサンプルはプレゼンテーションを読み込み、デフォルトのエクスポート設定で表示されているすべてのスライドを PDF に保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose は無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスをデモします。このコンバーターで本記事で説明した手順を実際に試すことができます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラス配下のカスタムオプション（プロパティ）を提供し、生成される PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを自由に指定できます。

次の例は、PDF 1.5 形式で JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG で保存し、Flate テキスト圧縮を行う方法を示しています。

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

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持する**

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受取人がスライドと同時にワークブックのデータにアクセスできるようにしたいことがあります。[PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) を `true` に設定すると、埋め込み OLE ファイルが PDF の添付ファイルとして保持されます。

既定値は `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付されません。`true` に設定すると、ファイルデータも添付されます。プレビューは視覚的表現のままで、添付ファイルは受取人が別途開いたり保存したりできるようになります。OLE オブジェクト自体が PDF ページ上でインタラクティブな Excel ワークシートになることはありません。

次の例は、既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

結果を確認する手順:

1. 添付ファイルをサポートするビューア（例: Adobe Acrobat Reader）でエクスポートした PDF を開く。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探す。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開く。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。本例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートはデモしていません。

{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを PDF のページとして含めることができます。

次の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **パスワード保護された PDF に変換する**

次の例は、パスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷を許可し、高品質印刷も含まれます。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **フォント置換を検出する**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

次の例は、プレゼンテーションを PDF にエクスポートし、コンソールにフォント置換の警告を出力します。利用できないフォントが置換されたときのみ警告が出力されます。

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

フォント置換の詳細については、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

### **太字フォントが存在しないフォントの扱い**

フォントに専用の太字タイプフェイスが無い場合でも、プレゼンテーションは太字書式を適用できます。合成太字により、通常のグリフが人工的に太く表示されます。この太字テキストが PDF で重すぎる、または期待と異なる外観になる場合は、[PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) を `true` に設定してみてください。このオプションは、PDF エクスポート時に該当テキストをビットマップとして描画し、特定のフォントでの外観を改善できる場合があります。既定値は `false` です。

サンプルのプレゼンテーションには、通常テキストと同じフォントで太字書式が適用されたテキストボックスが二つ含まれています。このフォントは専用の太字タイプフェイスを持ちません。次の例はプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にして PDF にエクスポートします。

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

以下は、無効状態と有効状態のプレビューです。この例では、オプションが無効の場合、太字テキストの線が太く表示されます。オプションを有効にすると線が細くなり、通常テキストは変わりません。設定を選択する前に結果を比較してください。

| オプション無効 (`false`、既定) | オプション有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストのみがビットマップ化されます。ビットマップ化されたテキストは OCR なしでは選択、コピー、検索できず、800% ズーム時にエッジがやわらかく見えます。通常テキストは検索可能なままです。オプションを無効にした場合、両方の文字列がテキストとして残ります。

このオプションは、フォントに専用の太字タイプフェイスが無い場合に太字テキストをラスタライズします。[Font substitution](/slides/ja/net/font-substitution/) は、元フォントが利用できないときに別のフォントを選択します。

## **選択したスライドだけを PowerPoint から PDF に変換する**

次の例は、プレゼンテーションからスライド 1 と 3 を抽出して PDF にエクスポートします。配列内のスライド番号は 1 から始まり、入力プレゼンテーションには少なくとも 3 枚のスライドが含まれている必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタムスライドサイズで PowerPoint を PDF に変換する**

次の例は、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライドコンテンツを拡大縮小してフィットさせ、単一スライドを PDF にエクスポートします。

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

## **ノートスライド表示で PowerPoint を PDF に変換する**

次の例は、各スライドのスピーカーノートをスライド下部に配置してプレゼンテーションを PDF にエクスポートします。結果を確認するには、スピーカーノートが含まれたプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。以下のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます: **PDF/A1a**、**PDF/A1b**、**PDF/UA**。

次の C# コードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

Aspose.Slides は PDF 変換操作をサポートし、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) などの変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) といった専門的な形式への変換もサポートされています。

{{% /alert %}}

> **Note:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換できます。ファイルを列挙し、プログラムで変換処理を適用してください。

**変換後の PDF にパスワード保護を付加できますか？**

はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードとアクセス許可を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを `true` に設定すると、生成される PDF に非表示スライドがページとして含まれます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) や [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) などのプロパティを設定することで、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA など、さまざまな標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for .NET Documentation](/slides/ja/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)