---
title: PHP で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint から PDF へ
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
- 添付
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint PPT/PPTX を高品質かつ検索可能な PDF に変換します。高速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション (PPT、PPTX、ODP など) を PHP で PDF 形式に変換すると、さまざまな利点があります。デバイス間の互換性やプレゼンテーションのレイアウトと書式設定の保持が含まれます。本ガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するさまざまなオプションの使用、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、そして出力ドキュメントへのコンプライアンス標準の適用について示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスに渡し、次に [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) メソッドを使用してプレゼンテーションを PDF として保存します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) クラスは、通常プレゼンテーションを PDF に変換するために使用される [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/save/) メソッドを公開しています。

{{% alert color="info" title="Note" %}}
Aspose.Slides for PHP via Java は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**Note** この情報を出力ドキュメントから変更または削除するよう指示することはできません。
{{% /alert %}}

Aspose.Slides では、次の変換が可能です：

* プレゼンテーション全体を PDF に変換
* プレゼンテーションの特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションと非常に近いことを保証します。変換時に要素と属性が正確にレンダリングされ、以下を含みます：

* **画像**
* **テキスト ボックスと図形**
* **テキストの書式設定**
* **段落の書式設定**
* **ハイパーリンク**
* **ヘッダーとフッター**
* **箇条書き**
* **表**

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は提供されたプレゼンテーションを最高品質の設定で最適に PDF に変換しようとします。

以下の例は、プレゼンテーションを読み込み、デフォルトのエクスポート設定を使用してすべての表示スライドを PDF に保存します。

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
Aspose は、プレゼンテーションから PDF への変換プロセスを示す無料のオンライン [**PowerPoint から PDF へのコンバーター**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバーターでテストを実行し、ここで説明した手順を実際に体験できます。
{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスのプロパティとして提供されるカスタム オプションを提供し、生成された PDF をカスタマイズしたり、パスワードで PDF をロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタム オプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定を定義したり、メタファイルの処理方法を指定したり、テキストの圧縮レベルを設定したり、画像の DPI を構成したり、その他多数の設定が可能です。

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

### **画像圧縮の自動選択**

プレゼンテーションに多数の写真やスクリーンショットが含まれる場合、エクスポートされた PDF のサイズを縮小すると、メール送信やダウンロードが容易になります。[PdfOptions::setBestImagesCompressionRatio](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setbestimagescompressionratio/) を `true` で呼び出すと、PDF エクスポート時に各画像に最適な圧縮アルゴリズムが自動的に選択されます。

以下の例は、既存のプレゼンテーションを読み込み、自動画像圧縮選択を有効にし、PDF ドキュメントとして保存します。他のすべての PDF エクスポート設定はデフォルト値のままです。

```php
use aspose\slides\PdfOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$pdfOptions = new PdfOptions();
$pdfOptions->setBestImagesCompressionRatio(true);

$presentation = new Presentation("image-heavy.pptx");
try {
    $presentation->save("image-heavy.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

このオプションは、各画像に対して圧縮アルゴリズムを選択します。[setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) に渡す値を下げると JPEG 画像の品質が低下し、[setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) に渡す値を下げると画像が低解像度にダウンサンプリングされ、ディテールが減少する可能性があります。自動圧縮選択を有効にしても、これらの設定が低下することはありません。

画像圧縮アルゴリズムの選択には、追加の処理時間とメモリが必要です。サイズ削減はプレゼンテーションの画像やエクスポート設定に依存し、すべてのプレゼンテーションで一定の削減が保証されるわけではありません。

### **埋め込み OLE ファイルを PDF 添付ファイルとして保持**

プレゼンテーションに埋め込みの Excel ワークブックが含まれる場合、PDF の受取人がスライドを見るだけでなく、ワークブックのデータにもアクセスできるようにしたいことがあります。[setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) を `true` で呼び出すと、埋め込み OLE ファイルを結果の PDF の添付ファイルとして保持します。

既定値は `false` です。OLE オブジェクトのプレビュー画像またはアイコンは PDF ページに表示されますが、埋め込みファイルは添付ファイルとして含まれません。オプションを `true` に設定すると、ファイルデータも追加で含まれます。プレビューは視覚的な表現のままで、添付ファイルにより受取人は埋め込みファイルを個別に開いたり保存したりできます。OLE オブジェクトは PDF ページ上でインタラクティブな Excel ワークシートにはなりません。

以下の例は、すでに埋め込みの Excel ワークブックを含むプレゼンテーションを読み込み、ワークブックを添付した状態で PDF にエクスポートします。

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
2. ビューアの **Attachments** パネルを開き、埋め込みワークブックを見つけます。
3. 添付ファイルを保存し、Excel で開いてデータを確認するか、ビューアが許可すれば直接開きます。PDF ページ上のプレビューは添付ファイルとは別です。

{{% alert color="info" title="Note" %}}
PDF/A 標準は添付ファイルに制限を課しています。PDF/A-1 は埋め込みファイルを禁止し、PDF/A-2 は PDF/A 添付ファイルのみを許可し、PDF/A-3 は Excel ワークブックを含むその他のファイルタイプを許可します。これらは標準の要件であり、Aspose.Slides 固有の制限ではありません。この例はデフォルトの PDF コンプライアンス設定を使用しており、PDF/A エクスポートは示していません。
{{% /alert %}}

### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれる場合、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

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

以下の例は、開く際にパスワード `password` が必要な PDF にプレゼンテーションをエクスポートします。アクセス権限では印刷が許可されており、ハイ品質印刷も含まれます。

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

以下の例は、プレゼンテーションを PDF にエクスポートし、コンソールにフォント置換警告を出力します。利用できないフォントが置換されたときにのみ警告が出力されます。

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
フォント置換の詳細については、[Font Substitution](/slides/ja/php-java/font-substitution/) 記事をご覧ください。
{{% /alert %}}

### **専用の太字フォントがないフォントの処理**

プレゼンテーションは、フォントに専用の太字タイプフェイスがなくても、テキストに太字書式を適用できます。テキストは合成太字により、通常のグリフを人工的に太くして太字に見えることがあります。そのテキストが PDF で見た目が重すぎる、または意図した外観と異なる場合は、[PdfOptions::setRasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) を `true` で呼び出してみてください。このオプションは、PDF エクスポート時に該当テキストをビットマップとしてレンダリングし、特定のフォントの外観を改善できます。既定値は `false` です。

サンプルのプレゼンテーションには、通常のテキストが入ったテキストボックスと、同じフォントで太字書式が適用されたテキストボックスの 2 つが含まれています。このフォントは専用の太字タイプフェイスを持ちません。以下の例は、プレゼンテーションを読み込み、サポートされていないフォントスタイルのラスタライズを有効にし、PDF にエクスポートします。

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

以下のプレビューは、オプション無効時と有効時の出力を示しています。この例では、オプションが無効の場合、太字テキストの線が太くなります。オプションを有効にすると、線が細くなり、通常のテキストは変わりません。設定を選ぶ前に結果を比較してください。

| オプション無効 (`false`、デフォルト) | オプション有効 (`true`) |
|---|---|
| ![サポートされていないフォントスタイルのラスタライズが無効な PDF](unsupported-bold-disabled.png) | ![サポートされていないフォントスタイルのラスタライズが有効な PDF](unsupported-bold-enabled.png) |

この例では、オプションを有効にすると太字テキストのみがビットマップに変換されます。その結果、OCR なしでは選択、コピー、テキスト検索ができず、800% ズーム時にエッジが柔らかく表示されます。通常のテキストは検索可能なままです。オプションが無効の場合、両方の文字列はテキストとして残ります。

このオプションは、フォントに専用の太字タイプフェイスがない場合、太字で書式設定されたテキストをラスタライズします。代わりに [Font substitution](/slides/ja/php-java/font-substitution/) は、元のフォントが利用できないときに別のフォントを選択します。

## **PowerPoint から選択したスライドを PDF に変換**

以下の例は、プレゼンテーションからスライド 1 と 3 を抽出して PDF にエクスポートします。この配列のスライド番号は 1 から始まり、入力プレゼンテーションは少なくとも 3 枚のスライドを含んでいる必要があります。

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

## **カスタム スライドサイズで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションの最初のスライドを 612 × 792 ポイント (8.5 × 11 インチ) のスライドサイズを持つ新しいプレゼンテーションにコピーします。スライド内容をフィットさせるようにスケーリングし、単一スライドを PDF にエクスポートします。

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

    // 新しいプレゼンテーションで作成された空のスライドを削除します。
    $resizedPresentation->getSlides()->removeAt(1);

    $resizedPresentation->save("PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **ノート スライド ビューで PowerPoint を PDF に変換**

以下の例は、プレゼンテーションを PDF にエクスポートし、各スライドのスピーカーノートをスライドの下に配置します。結果を確認するには、スピーカーノートを含むプレゼンテーションを使用してください。

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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。PowerPoint ドキュメントを PDF にエクスポートする際に、これらのコンプライアンス標準のいずれかを使用できます：**PDF/A1a**、**PDF/A1b**、および **PDF/UA**。

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
Aspose.Slides は PDF 変換操作をサポートしており、PDF ファイルを一般的なファイル形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) の変換を実行できます。さらに、[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) など、専門的な形式への PDF 変換操作もサポートされています。
{{% /alert %}}

> **Note:** PDF/UA にエクスポートする際、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個別のパス要素は別々のコンテンツとして保持されず、アーティファクトとしてマークされることがあり、代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートしています。ファイルを反復処理し、プログラムで変換プロセスを適用できます。

**変換された PDF をパスワードで保護できますか？**

はい。[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスを使用して、変換プロセス中にパスワードを設定し、アクセス権限を定義できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスで `true` を指定して [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setshowhiddenslides/) を呼び出すと、結果の PDF に非表示スライドが含まれます。

**Aspose.Slides は PDF の画像品質を高く保つことができますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの [setJpegQuality](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setjpegquality/) や [setSufficientResolution](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/setsufficientresolution/) などのメソッドを使用して画像品質を制御し、PDF の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は [various standards](https://reference.aspose.com/slides/php-java/aspose.slides/pdfcompliance/)（PDF/A1a、PDF/A1b、PDF/UA を含む）に準拠した PDF のエクスポートを可能にし、ドキュメントがアクセシビリティとアーカイブ要件を満たすようにします。

## **追加リソース**

- [Aspose.Slides for PHP via Java ドキュメント](/slides/ja/php-java/)
- [Aspose.Slides for PHP via Java API リファレンス](https://reference.aspose.com/slides/php-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)