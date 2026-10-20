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
- 添付ファイル
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides を使用して .NET で PowerPoint の PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速な C# コード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を C# で PDF 形式に変換すると、さまざまなデバイスでの互換性が向上し、プレゼンテーションのレイアウトや書式設定が保持されます。本ガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルへのパスワード保護、フォント置換の検出、特定スライドの選択変換、および出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスに渡し、次に [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}

Aspose.Slides for .NET は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」の形式の値を設定します。**注意**：この情報を出力ドキュメントから変更または削除するように Aspose.Slides に指示することはできません。

{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になることを保証します。変換時に正確にレンダリングされる要素と属性は以下の通りです。

* 画像
* テキスト ボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルト オプションを使用します。この場合、Aspose.Slides は最大品質レベルで最適な設定を用いて提供されたプレゼンテーションを PDF に変換しようとします。

次のサンプルは、プレゼンテーションを読み込み、デフォルトのエクスポート設定で表示スライドすべてを PDF に保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}

Aspose は無料のオンライン [**PowerPoint から PDF へのコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しており、プレゼンテーションから PDF への変換プロセスをデモしています。このコンバータでテストを実行し、ここで説明した手順を実際に体験できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスのプロパティとして提供されるカスタム オプションにより、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの動作指定などを行えます。

### **カスタム オプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

次のサンプルは、PDF 1.5 にエクスポートし、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を適用します。

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

### **画像圧縮の自動選択**

プレゼンテーションに多数の写真やスクリーンショットが含まれる場合、エクスポートされた PDF のサイズを縮小するとメール送信やダウンロードが容易になります。[PdfOptions.BestImagesCompressionRatio](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/bestimagescompressionratio/) を `true` に設定すると、PDF エクスポート時に各画像に最適な圧縮アルゴリズムが自動的に選択されます。

次のサンプルは既存のプレゼンテーションを読み込み、自動画像圧縮選択を有効にして PDF 文書として保存します。他の PDF エクスポート設定はデフォルトのままです。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { BestImagesCompressionRatio = true };

using var presentation = new Presentation("image-heavy.pptx");
presentation.Save("image-heavy.pdf", SaveFormat.Pdf, pdfOptions);
```

このオプションは画像ごとに圧縮アルゴリズムを選択します。[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) を下げると JPEG 画像の品質が低下し、[SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) を下げると画像が低解像度にダウンサンプルされ、ディテールが削減されます。自動圧縮選択を有効にしても、これらの設定自体が下がるわけではありません。

画像圧縮アルゴリズムの選択には追加の処理時間とメモリが必要です。サイズ削減はプレゼンテーションの画像とエクスポート設定に依存し、すべてのプレゼンテーションで一定の削減が保証されるわけではありません。

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込み Excel ワークブックが含まれている場合、PDF の受信者がスライドと同時にワークブックのデータにアクセスできるようにしたいことがあります。[PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) を `true` に設定すると、埋め込み OLE ファイルが結果の PDF に添付ファイルとして保持されます。

既定値は `false` で、OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付されません。`true` に設定するとファイルデータも添付されます。プレビューは視覚的表現のままで、添付により受信者は埋め込みファイルを別途開くか保存できます。OLE オブジェクト自体が PDF ページ上で対話的な Excel ワークシートになるわけではありません。

次のサンプルは、既に埋め込み Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

結果を確認する手順:

1. 添付ファイルに対応したビューア（例: Adobe Acrobat Reader）でエクスポートされた PDF を開く。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探す。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開く。PDF ページ上のプレビューは添付とは別です。

{{% alert color="info" title="Note" %}}

PDF/A 標準は添付ファイルに制限を課します。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付のみを許可し、PDF/A-3 は Excel ワークブックを含む他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。本例は既定の PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。

{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドがある場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを PDF のページとして含めることができます。

次のサンプルは、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **パスワード保護された PDF に変換**

次のサンプルは、開く際にパスワード `password` が必要な PDF をエクスポートします。アクセス許可は印刷（高品質印刷を含む）を許可します。

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にある [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) プロパティを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

次のサンプルは、プレゼンテーションを PDF にエクスポートし、コンソールにフォント置換警告を出力します。利用できないフォントが置換されたときのみ警告が出力されます。

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

### **専用の Bold 書体がないフォントの扱い**

フォントに専用の Bold 書体がない場合でも、プレゼンテーションはテキストに太字書式を適用できます。これは合成太字として、通常のグリフを人工的に太くすることで実現されます。合成太字が PDF で重く見える、または期待した外観と異なる場合は、[PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) を `true` に設定してみてください。このオプションは PDF エクスポート時に該当テキストをビットマップとしてレンダリングし、特定フォントでの外観を改善できる場合があります。既定値は `false` です。

サンプルのプレゼンテーションには、通常のテキストと同じフォントで太字書式が適用されたテキスト ボックスの 2 つが含まれています（このフォントには専用の Bold 書体がありません）。次のサンプルはプレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にして PDF にエクスポートします。

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

以下のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプションが無効の場合、太字テキストのストロークが太くなります。オプション有効時はストロークが細くなり、通常テキストは変わりません。プレゼンテーションに合わせて設定を選択してください。

| オプション無効 (`false`、既定) | オプション有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストのみがビットマップ化されます。ビットマップ化されたテキストは OCR なしでは選択、コピー、検索できず、800% ズーム時にエッジが柔らかく表示されます。通常テキストは検索可能なままです。オプションが無効の場合、両方の文字列がテキストとして残ります。

このオプションは、フォントに専用の Bold 書体がない場合に太字として書式設定されたテキストをラスタライズします。[Font substitution](/slides/ja/net/font-substitution/) は、元フォントが利用できないときに別のフォントを選択します。

## **選択したスライドのみを PowerPoint から PDF に変換**

次のサンプルは、プレゼンテーションからスライド 1 と 3 を抽出して PDF にエクスポートします。配列内のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタム スライド サイズで PowerPoint を PDF に変換**

次のサンプルは、プレゼンテーションの最初のスライドを新しいプレゼンテーションにコピーし、スライドサイズを 612 × 792 ポイント（8.5 × 11 インチ）に設定します。スライド コンテンツはフィットするようにスケールされ、単一スライドが PDF にエクスポートされます。

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

## **ノート スライド ビューで PowerPoint を PDF に変換**

次のサンプルは、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライド下部に配置します。結果を見るにはスピーカーノートを含むプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下の C# コードは、異なるコンプライアンス標準に基づく複数の PDF を生成する PowerPoint から PDF への変換プロセスを示します。

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

Aspose.Slides は PDF 変換機能もサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) 変換が利用可能です。また、[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) などの特殊形式への変換もサポートされています。

{{% /alert %}}

> **注意:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図形として扱います。個別のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図形に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF に変換できます。ファイルを列挙し、プログラム的に変換プロセスを適用してください。

**変換後の PDF にパスワードを設定できますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用してパスワードとアクセス許可を設定し、変換時に PDF を保護できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを `true` に設定すると、結果の PDF に非表示スライドがページとして含まれます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) や [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) などのプロパティを設定することで、PDF の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートをサポートしており、アクセシビリティとアーカイブ要件を満たすドキュメントを作成できます。

## **追加リソース**

- [Aspose.Slides for .NET Documentation](/slides/ja/net/)
- [Aspose.Slides for .NET API Reference](https://reference.aspose.com/slides/net/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/conversion)