---
title: PHP で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint を PDF に変換
type: docs
weight: 40
url: /ja/php-java/convert-powerpoint-to-pdf/
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
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して、PHP で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PHPでPowerPointプレゼンテーション（PPT、PPTX、ODPなど）をPDF形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウトと書式を保持できるなどの利点があります。本ガイドでは、プレゼンテーションをPDF文書に変換する方法、画像品質を制御する各種オプションの使用方法、非表示スライドの含め方、PDFファイルへのパスワード保護、フォント置換の検出、特定のスライドを選択して変換する方法、そして出力文書に準拠基準を適用する方法を示します。

## **PowerPointからPDFへの変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスに渡し、[save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスは通常、プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。例えば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**注** Aspose.Slides に対してこの情報を変更または削除するよう指示することはできません。
{{% /alert %}}

Aspose.Slides は次の変換を可能にします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションとほぼ同一になることを保証します。変換では、以下を含む要素と属性が正確に描画されます。

* 画像
* テキストボックスと図形
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPointをPDFに変換**

標準的な PowerPoint から PDF への変換プロセスはデフォルトのオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最高品質の最適設定で PDF に変換しようとします。

以下の例はプレゼンテーションを読み込み、デフォルトのエクスポート設定を使用して表示されているすべてのスライドを PDF に保存します。

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
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint to PDF コンバーター**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバーターでテストを実行すると、ここで説明した手順のライブ実装を確認できます。
{{% /alert %}}

## **オプション付きでPowerPointをPDFに変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスのプロパティであるカスタムオプションを提供し、生成される PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプションでPowerPointをPDFに変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定を指定したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像の DPI を構成したりすることができます。

以下の例は、JPEG 品質を 90、画像解像度を 300 DPI、メタファイルを PNG として保存し、Flate テキスト圧縮を使用してプレゼンテーションを PDF 1.5 にエクスポートします。

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

プレゼンテーションに埋め込みの Excel ブックが含まれている場合、PDF の受信者がスライドを見るだけでなくブックのデータにもアクセスできるようにしたいことがあります。`true` を指定して [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) を呼び出すと、埋め込み OLE ファイルが結果の PDF の添付ファイルとして保持されます。

既定値は `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに描画されますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `true` に設定すると、ファイルデータも添付されます。プレビューは視覚的な表現のままで、添付ファイルによって受信者は埋め込みファイルを個別に開くまたは保存できます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

以下の例は、すでに埋め込みの Excel ブックを含むプレゼンテーションを読み込み、ブックを添付した状態で PDF にエクスポートします。

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
2. ビューアの **Attachments** パネルを開き、埋め込みブックを見つけます。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課します：PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ブックを含む他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF 準拠設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めてPowerPointをPDFに変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

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

### **パスワード保護された PDF にPowerPointを変換**

以下の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス許可は印刷を許可し、高品質印刷も含まれます。

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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できるようにします。

以下の例は、プレゼンテーションを PDF にエクスポートし、コンソールにフォント置換の警告を出力します。利用できないフォントが置換された場合にのみ警告が表示されます。

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
フォント置換の詳細については、[フォント置換](/slides/ja/php-java/font-substitution/) 記事をご覧ください。
{{% /alert %}} 

## **PowerPointから選択したスライドをPDFに変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 スライドを含んでいる必要があります。

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

## **カスタムスライドサイズでPowerPointをPDFに変換**

以下の例は、プレゼンテーションの最初のスライドを 612 × 792 ポイント（8.5 × 11 インチ）のスライドサイズを持つ新しいプレゼンテーションにコピーします。スライドコンテンツを適合させるようにスケーリングし、単一スライドを PDF にエクスポートします。

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

    // 新しく作成されたプレゼンテーションに含まれる空のスライドを削除します。
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **ノートスライドビューでPowerPointをPDFに変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスライドノートをスライドの下に配置します。結果を見るには、スライドノートを含むプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。これらのコンプライアンス標準のいずれか（**PDF/A1a**、**PDF/A1b**、**PDF/UA**）を使用して PowerPoint 文書を PDF にエクスポートできます。

このコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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
Aspose.Slides は PDF 変換操作をサポートし、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) の変換を実行できます。その他の特殊形式への PDF 変換操作—[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—もサポートされています。
{{% /alert %}}

> **注:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされる可能性があります。代替テキストは全体の図に対してのみ提供されます。

## **よくある質問**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**  
はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを列挙し、プログラムで変換プロセスを適用できます。

**変換された PDF にパスワード保護を設定できますか？**  
はい。[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスを使用して、変換プロセス中にパスワードを設定し、アクセス許可を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**  
[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) を `true` に設定して、結果の PDF に非表示スライドを含めます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**  
はい、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setJpegQuality) や [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setSufficientResolution) などのメソッドを使用して画像品質を制御し、PDF の高品質画像を確保できます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**  
はい、Aspose.Slides は [さまざまな標準](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/)（PDF/A1a、PDF/A1b、PDF/UA）に準拠した PDF をエクスポートでき、文書がアクセシビリティと保存要件を満たすようにします。

## **追加リソース**

- [Aspose.Slides for PHP via Java ドキュメント](/slides/ja/php-java/)
- [Aspose.Slides for PHP via Java API リファレンス](https://reference.aspose.com/slides/php-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)