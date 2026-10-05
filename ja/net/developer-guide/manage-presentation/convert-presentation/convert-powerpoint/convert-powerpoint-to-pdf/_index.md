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
- "添付"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- ".NET"
- "C#"
- "Aspose.Slides"
description: ".NET で Aspose.Slides を使用して PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換します。高速な C# コード例と高度な変換オプションを提供します。"
---
## **概要**

C# で PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PDF 形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウトと書式設定を保持するなど、多くの利点があります。本ガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、および出力ドキュメントにコンプライアンス基準を適用する方法を示します。

## **PowerPoint から PDF への変換**

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスに渡し、[Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) クラスは通常、プレゼンテーションを PDF に変換するために使用される [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for .NET は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する場合、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注** Aspose.Slides に対してこの情報を変更または削除するよう指示することはできません。
{{% /alert %}}

Aspose.Slides を使用すると、次の変換が可能です：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションと非常に近い形になるようにします。変換では、以下を含む要素と属性が正確にレンダリングされます：

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準的な PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最大品質レベルの最適な設定で PDF に変換しようとします。

次の例は、プレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドを PDF に保存します。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint から PDF コンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、本稿で説明した手順をライブで実装できます。
{{% /alert %}}

## **オプションを使用した PowerPoint から PDF への変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの下にあるカスタムオプション（プロパティ）を提供し、生成された PDF をカスタマイズしたり、パスワードで保護したり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションを使用した PowerPoint から PDF への変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定を指定したり、メタファイルの処理方法を定義したり、テキストの圧縮レベルを設定したり、画像の DPI を構成したり、その他多数の設定が可能です。

次の例は、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を使用して PDF 1.5 にエクスポートします。

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

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受信者がスライドを閲覧できるだけでなく、ワークブックのデータにもアクセスできるようにしたいことがあります。埋め込み OLE ファイルを結果の PDF の添付ファイルとして保持するには、[PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) を `true` に設定します。

既定値は `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `true` に設定すると、ファイルデータも追加で含まれます。プレビューは視覚的表現のままで、添付ファイルにより受信者は埋め込みファイルを別々に開くか保存できます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

次の例は、すでに埋め込みの Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

結果を確認するには：

1. Adobe Acrobat Reader など、ファイル添付をサポートするビューアでエクスポートされた PDF を開きます。
2. ビューアの **添付ファイル** パネルを開き、埋め込みワークブックを見つけます。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課しています。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例は既定の PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含む PowerPoint から PDF への変換**

プレゼンテーションに非表示スライドがある場合、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを使用して、非表示スライドを結果の PDF のページとして含めることができます。

次の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **パスワード保護された PDF への PowerPoint 変換**

次の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限では印刷が許可されており、高品質印刷も含まれます。

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

次の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。警告は、利用できないフォントがエクスポート中に置換された場合にのみ出力されます。

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
フォント置換の詳細については、[Font Substitution](/slides/ja/net/font-substitution/) 記事をご覧ください。
{{% /alert %}}

## **PowerPoint から選択スライドを PDF に変換**

次の例は、プレゼンテーションからスライド 1 と 3 を PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

次の例は、プレゼンテーションの最初のスライドを 612 × 792 ポイント（8.5 × 11 インチ）のスライドサイズを持つ新しいプレゼンテーションにコピーします。スライド内容をフィットするようにスケーリングし、単一スライドを PDF にエクスポートします。

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

次の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下部に配置します。結果を確認するには、スピーカーノートを含むプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。これらのコンプライアンス標準のいずれか (**PDF/A1a**, **PDF/A1b**, **PDF/UA**) を使用して PowerPoint ドキュメントを PDF にエクスポートできます。

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
Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/) の変換を実行できます。さらに、[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/) などの専門フォーマットへの変換もサポートされています。
{{% /alert %}}

> **注:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる場合があります。代替テキストは全体の図に対してのみ提供されます。

## **よくある質問**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを反復処理し、プログラムで変換プロセスを適用できます。

**変換された PDF にパスワード保護を設定できますか？**

はい。変換プロセス中にパスワードを設定し、アクセス許可を定義するには、[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスを使用します。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスの [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) プロパティを `true` に設定すると、結果の PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい、[JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) や [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) などのプロパティを [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) クラスで設定することで、PDF の画像品質を高く保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA など、さまざまな標準に準拠した PDF のエクスポートを可能にし、文書がアクセシビリティとアーカイブ要件を満たすようにします。

## **追加リソース**

- [Aspose.Slides for .NET ドキュメント](/slides/ja/net/)
- [Aspose.Slides for .NET API リファレンス](https://reference.aspose.com/slides/net/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)