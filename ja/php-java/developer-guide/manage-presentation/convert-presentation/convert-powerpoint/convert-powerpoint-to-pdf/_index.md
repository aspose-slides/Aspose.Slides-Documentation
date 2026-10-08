---
title: PHPでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPoint から PDF へ
type: docs
weight: 40
url: /ja/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint から PDF
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
- 添付
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して、PHP で PowerPoint の PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション (PPT、PPTX、ODP など) を PHP で PDF 形式に変換すると、さまざまな利点があります。デバイス間の互換性や、プレゼンテーションのレイアウトと書式が保持されます。このガイドでは、プレゼンテーションを PDF 文書に変換する方法、画像品質を制御するさまざまなオプションの使用方法、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、変換対象スライドの選択、出力文書へのコンプライアンス基準の適用方法を示します。

## **PowerPoint から PDF への変換**

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスに渡し、[save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスは通常、プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換すると、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**Note** では、この情報を変更または削除するよう Aspose.Slides に指示できないことを示します。
{{% /alert %}}

Aspose.Slides は、以下を変換できます：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションに極めて近い PDF を生成します。変換では次の要素と属性が正確にレンダリングされます：

* 画像
* テキストボックスと図形
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準的な PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最高品質の最適な設定で PDF に変換しようとします。

以下の例は、プレゼンテーションをロードし、デフォルトのエクスポート設定を使用してすべての表示スライドを PDF に保存します。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint から PDF へのコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、ここで説明した手順を実際に試すことができます。
{{% /alert %}}

## **PowerPoint を PDF に変換（オプションあり）**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスのプロパティであるカスタムオプションを提供し、結果の PDF をカスタマイズしたり、パスワードで PDF をロックしたり、変換プロセスの実行方法を指定したりできます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の好みの品質設定を定義したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像の DPI を構成したり、その他多数の設定が可能です。

以下の例は、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を使用して PDF 1.5 にエクスポートします。

```php
use aspose\slides\PdfCompliance;
use aspose\slides\PdfOptions;
use aspose\slides\PdfTextCompression;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setJpegQuality(90);
$pdfOptions->setSufficientResolution(300);
$pdfOptions->setSaveMetafilesAsPng(true);
$pdfOptions->setTextCompression(PdfTextCompression::Flate);
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれている場合、PDF の受信者がスライドを閲覧できるだけでなく、ワークブックのデータにもアクセスできるようにしたいことがあります。[setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) を `true` で呼び出すと、埋め込み OLE ファイルを結果の PDF の添付ファイルとして保持します。

デフォルト値は `false`：OLE オブジェクトのプレビュー画像またはアイコンは PDF ページにレンダリングされますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `true` に設定すると、ファイルデータも追加で含まれます。プレビューは視覚的な表現のままで、添付ファイルにより受信者は埋め込みファイルを個別に開いたり保存したりできます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

以下の例は、すでに埋め込み Excel ワークブックを含むプレゼンテーションをロードし、ワークブックを添付した状態で PDF にエクスポートします。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setIncludeOleData(true);

$presentation = new Presentation("presentation.pptx");
try {
    $presentation->save("presentation.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

結果を確認するには：

1. Adobe Acrobat Reader など、ファイル添付をサポートするビューアでエクスポートされた PDF を開きます。
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを探します。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課します：PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含む他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含む PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

以下の例は、非表示スライドを含めてプレゼンテーションを PDF にエクスポートします。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setShowHiddenSlides(true);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **パスワード保護された PDF に PowerPoint を変換**

以下の例は、`password` のパスワードで開く必要がある PDF にプレゼンテーションをエクスポートします。アクセス権限は印刷を許可し、高品質印刷も可能です。

```php
use aspose\slides\PdfAccessPermissions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setPassword("password");
$pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

$presentation = new Presentation("PowerPoint.pptx");
try {
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

以下の例は、プレゼンテーションを PDF にエクスポートし、フォント置換の警告をコンソールに出力します。警告は、使用できないフォントがエクスポート中に置換されたときにのみ出力されます。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));

$pdfOptions = new PdfOptions();
$pdfOptions->setWarningCallback($warningCallback);

$presentation = new Presentation("sample.pptx");
try {
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
フォント置換に関する詳細情報については、[フォント置換](/slides/ja/php-java/font-substitution/) 記事をご覧ください。
{{% /alert %}}

### **専用の太字フォントがないフォントの処理**

プレゼンテーションは、フォントに専用の太字タイプフェイスがなくても、テキストに太字書式を適用できます。その場合、合成太字により通常の字形を人工的に太くして太字に見せます。PDF でテキストが重く見える、または意図した外観と異なる場合は、`true` で [PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) を呼び出してみてください。このオプションは、PDF エクスポート時に対象テキストをビットマップとしてレンダリングし、特定のフォントで外観を改善できます。デフォルト値は `false` です。

サンプルのプレゼンテーションには、通常のテキストが含まれるテキストボックスと、同じフォントに太字書式が適用されたテキストボックスの 2 つがありますが、そのフォントには専用の太字タイプフェイスがありません。以下の例は、プレゼンテーションをロードし、サポートされていないフォントスタイルのラスター化を有効にして PDF にエクスポートします。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setRasterizeUnsupportedFontStyles(true);

$presentation = new Presentation("unsupported-bold.pptx");
try {
    $presentation->save("rasterized.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

以下のプレビューは、オプションが無効な出力と有効な出力を示しています。この例では、オプションが無効な場合、太字テキストの線が太くなります。オプションを有効にすると、その線は細くなり、通常のテキストは変わりません。設定を選択する前に結果を比較してください。

| オプションが無効 (`false`, デフォルト) | オプションが有効 (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると、太字テキストだけがビットマップに変換されます。OCR なしでは選択、コピー、テキスト検索ができず、800% ズーム時にはエッジが柔らかく表示されます。通常のテキストは検索可能なままです。オプションが無効の場合、両方の文字列はテキストのままです。

このオプションは、フォントに専用の太字タイプフェイスがない場合に太字として書式設定されたテキストをラスター化します。[フォント置換](/slides/ja/php-java/font-substitution/) は、元のフォントが利用できないときに別のフォントを選択します。

## **PowerPoint から選択したスライドを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("PowerPoint.pptx");
try {
    $slides = array(1, 3);
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションの最初のスライドを 612 × 792 ポイント (8.5 × 11 インチ) のスライドサイズを持つ新しいプレゼンテーションにコピーします。スライド内容をフィットするようにスケーリングし、単一スライドを PDF にエクスポートします。

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$slideWidth = 612.0;
$slideHeight = 792.0;

$presentation = new Presentation("SelectedSlides.pptx");
$resizedPresentation = new Presentation();

try {
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    // 新しいプレゼンテーションが作成されたときにできる空のスライドを削除します。
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **ノートスライドビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスライド下にスピーカーノートを配置します。結果を見るには、スピーカーノートを含むプレゼンテーションを使用してください。

```php
use aspose\slides\NotesCommentsLayoutingOptions;
use aspose\slides\NotesPositions;
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$notesOptions = new NotesCommentsLayoutingOptions();
$notesOptions->setNotesPosition(NotesPositions::BottomFull);

$pdfOptions = new PdfOptions();
$pdfOptions->setSlidesLayoutOptions($notesOptions);

$presentation = new Presentation("SelectedSlides.pptx");
try {
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。これらのコンプライアンス標準のいずれか (**PDF/A1a**, **PDF/A1b**, **PDF/UA**) を使用して PowerPoint 文書を PDF にエクスポートできます。

このコードは、異なるコンプライアンス標準に基づいて�数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose.Slides は PDF 変換操作をサポートし、PDF ファイルを一般的なファイル形式に変換できます。[PDF を HTML に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/) 、[PDF を image に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/) 、[PDF を JPG に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/) 、[PDF を PNG に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) の変換を実行できます。その他、[PDF を SVG に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/) 、[PDF を TIFF に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/) 、[PDF を XML に変換](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) などの特殊形式への PDF 変換もサポートされています。
{{% /alert %}}

> **Note:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあります。代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**  
はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを順に処理し、プログラムで変換プロセスを適用できます。

**変換された PDF にパスワード保護を設定できますか？**  
はい。変換プロセス中に [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスを使用してパスワードを設定し、アクセス権限を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**  
[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスで `true` を指定して [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) を呼び出すと、結果の PDF に非表示スライドを含めることができます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**  
はい、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) や [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) などのメソッドを使用して画像品質を制御し、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**  
はい、Aspose.Slides は [さまざまな標準](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/) を含む PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF をエクスポートでき、文書がアクセシビリティとアーカイブ要件を満たすようにします。

## **追加リソース**

- [Aspose.Slides for PHP via Java ドキュメント](/slides/ja/php-java/)
- [Aspose.Slides for PHP via Java API リファレンス](https://reference.aspose.com/slides/php-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)