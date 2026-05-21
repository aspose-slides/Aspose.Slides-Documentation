---
title: PHP で PPT と PPTX を PDF に変換 [高度な機能を含む]
linktitle: PowerPoint から PDF へ
type: docs
weight: 40
url: /ja/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPoint を変換
- プレゼンテーションを変換
- PowerPoint から PDF へ
- プレゼンテーションから PDF へ
- PPT から PDF へ
- PPT を PDF に変換
- PPTX から PDF へ
- PPTX を PDF に変換
- PowerPoint を PDF として保存
- PPT を PDF として保存
- PPTX を PDF として保存
- PPT を PDF にエクスポート
- PPTX を PDF にエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して PHP で PowerPoint PPT/PPTX を高品質で検索可能な PDF に変換し、迅速なコード例と高度な変換オプションを提供します。"
---
## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PHP で PDF 形式に変換すると、さまざまなデバイスでの互換性やプレゼンテーションのレイアウト・書式を保持できるという利点があります。本ガイドでは、プレゼンテーションを PDF に変換する方法、画像品質を制御するオプションの使用、非表示スライドの含め方、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数にして [Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスを作成し、`save` メソッドで PDF として保存します。[Presentation](https://reference.aspose.com/slides/ja/php-java/aspose.slides/Presentation) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを提供します。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java は、出力ドキュメントに API 情報とバージョン番号を挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」形式の値を設定します。**Note** この情報を出力ドキュメントから変更または除去することはできません。

{{% /alert %}}

Aspose.Slides では次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い形になるようにします。変換時に正確にレンダリングされる要素と属性は以下のとおりです。

* 画像
* テキスト ボックスと図形
* テキストの書式設定
* 段落の書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* テーブル

## **PowerPoint を PDF に変換する**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質の設定で提供されたプレゼンテーションを PDF に変換しようとします。

以下のコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。

```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # プレゼンテーションを PDF として保存します。
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスをデモできる無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/ja/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行し、ここで説明した手順を実際に試すことができます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換する**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PdfOptions) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの進行方法を指定したりできます。

### **カスタムオプション付きで PowerPoint を PDF に変換する**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```php
# PdfOptions クラスのインスタンスを作成します。
$pdfOptions = new PdfOptions();

# JPG 画像の品質を設定します。
$pdfOptions->setJpegQuality(90);

# 画像の DPI を設定します。
$pdfOptions->setSufficientResolution(300);

# メタファイルの動作を設定します。
$pdfOptions->setSaveMetafilesAsPng(true);

# テキストコンテンツの圧縮レベルを設定します。
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# PDF のコンプライアンスモードを定義します。
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # プレゼンテーションを PDF ドキュメントとして保存します。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **非表示スライドを含めて PowerPoint を PDF に変換する**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/PdfOptions) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

以下のコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions クラスのインスタンスを作成します。
    $pdfOptions = new PdfOptions();

    # 非表示スライドを追加します。
    $pdfOptions->setShowHiddenSlides(true);

    # プレゼンテーションを PDF として保存します。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **パスワード保護された PDF に PowerPoint を変換する**

以下のコードは、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。

```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions クラスのインスタンスを作成します。
    $pdfOptions = new PdfOptions();

    # PDF のパスワードとアクセス許可を設定します。
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # プレゼンテーションを PDF として保存します。
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **フォント置換の検出**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/ja/php-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

以下のコードは、フォント置換を検出する方法を示しています。

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// PDF オプションで警告コールバックを設定します。
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("sample.pptx");
try {
    // プレゼンテーションを PDF として保存します。
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

フォント置換の詳細については、[Font Substitution](/slides/ja/php-java/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

## **PowerPoint の選択スライドのみを PDF に変換する**

以下のコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。

```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # スライド番号の配列を設定します。
    $slides = array(1, 3);

    # プレゼンテーションを PDF として保存します。
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **カスタムスライドサイズで PowerPoint を PDF に変換する**

以下のコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("SelectedSlides.pptx");

# 調整されたスライドサイズで新しいプレゼンテーションを作成します。
$resizedPresentation = new Presentation();

try {
    # カスタムスライドサイズを設定します。
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # 元のプレゼンテーションから最初のスライドをクローンします。
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # ノート付きでリサイズしたプレゼンテーションを PDF に保存します。
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **ノートスライドビューで PowerPoint を PDF に変換する**

以下のコードは、ノートを含む PDF として PowerPoint プレゼンテーションを変換する方法を示しています。

```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスのインスタンスを作成します。
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Notes Layout を使用して PDF オプションを設定します。
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # ノート付きでプレゼンテーションを PDF に保存します。
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかを使用して PowerPoint 文書を PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

以下のコードは、異なるコンプライアンス標準に基づいて複数の PDF を生成する PowerPoint から PDF への変換プロセスを示しています。

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

{{% alert title="Note" color="warning" %}} 

Aspose.Slides は PDF 変換機能をサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-png/) 変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/ja/php-java/conversion/pdf-to-xml/) などの特殊形式への変換もサポートされています。

{{% /alert %}}

> **Note:** PDF/UA にエクスポートする場合、Aspose.Slides は SmartArt、チャート、数式などの複雑なグラフィックを単一の図として扱います。個々のパス要素は別個のコンテンツとして保持されず、アーティファクトとしてマークされることがあり、代替テキストは全体の図に対してのみ提供されます。

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルを PDF にバッチ変換することをサポートします。ファイルをループ処理し、プログラムで変換プロセスを適用できます。

**変換後の PDF にパスワードを設定できますか？**

もちろんです。変換プロセス中にパスワードとアクセス権限を設定するために、[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/) クラスを使用してください。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/ja/php-java/aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用して、結果の PDF に非表示スライドを含めます。

**Aspose.Slides は PDF 内の画像品質を高く保つことができますか？**

はい、`setJpegQuality` や `setSufficientResolution` などのメソッドを使用して画像品質を制御し、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF をエクスポートでき、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for PHP via Java Documentation](/slides/ja/php-java/)
- [Aspose.Slides for PHP via Java API Reference](https://reference.aspose.com/slides/ja/php-java/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/ja/conversion)