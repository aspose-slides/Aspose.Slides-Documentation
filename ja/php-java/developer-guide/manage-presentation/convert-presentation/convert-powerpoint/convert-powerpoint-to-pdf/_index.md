---
title: PHPでPPTとPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointからPDFへ
type: docs
weight: 40
url: /ja/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointをPDFに変換
- プレゼンテーションをPDFに変換
- PPTをPDFに変換
- PPTをPDFに変換
- PPTXをPDFに変換
- PPTXをPDFに変換
- PowerPointをPDFとして保存
- PPTをPDFとして保存
- PPTXをPDFとして保存
- PPTをPDFにエクスポート
- PPTXをPDFにエクスポート
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Aspose.Slidesを使用して、PHPでPowerPoint PPT/PPTXを高品質で検索可能なPDFに変換します。高速なコード例と高度な変換オプションを提供しています。"
---

## **概要**

PowerPoint プレゼンテーション (PPT、PPTX、ODP など) を PHP で PDF 形式に変換すると、さまざまなデバイス間での互換性やプレゼンテーションのレイアウトと書式を保持できるといった利点があります。本ガイドでは、プレゼンテーションを PDF ドキュメントに変換する方法、画像品質を制御するオプションの使用、非表示スライドの追加、PDF ファイルのパスワード保護、フォント置換の検出、特定スライドの選択変換、および出力ドキュメントへのコンプライアンス標準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を引数として [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスに渡し、`save` メソッドを使用して PDF として保存します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) クラスは、通常プレゼンテーションを PDF に変換するために使用される `save` メソッドを公開しています。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java は、API 情報とバージョン番号を出力ドキュメントに挿入します。たとえば、プレゼンテーションを PDF に変換する際、Aspose.Slides は Application フィールドに「*Aspose.Slides*」を、PDF Producer フィールドに「*Aspose.Slides v XX.XX*」という形式の値を設定します。**注意**：この情報を出力ドキュメントから変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides では、次の変換が可能です。

* プレゼンテーション全体を PDF に変換
* プレゼンテーションから特定のスライドのみを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、生成された PDF が元のプレゼンテーションに極めて近い状態になるよう保証します。変換時には次の要素と属性が正確にレンダリングされます。

* 画像
* テキスト ボックスとシェイプ
* テキスト書式設定
* 段落書式設定
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を用いて提供されたプレゼンテーションを PDF に変換しようとします。

以下のコードは、プレゼンテーション (PPT、PPTX、ODP など) を PDF に変換する方法を示しています。
```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # プレゼンテーションを PDF 形式で保存します。
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料のオンライン [**PowerPoint to PDF converter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) を提供しています。このコンバータでテストを実行すれば、本記事で説明した手順をライブで確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) クラスのプロパティとしてカスタムオプションを提供し、生成される PDF のカスタマイズ、パスワードによるロック、変換プロセスの進行方法を指定できます。

### **カスタムオプションで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスター画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを定義できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```php
# PdfOptions クラスをインスタンス化します。
$pdfOptions = new PdfOptions();

# JPG 画像の品質を設定します。
$pdfOptions->setJpegQuality(90);

# 画像の DPI を設定します。
$pdfOptions->setSufficientResolution(300);

# メタファイルの動作を設定します。
$pdfOptions->setSaveMetafilesAsPng(true);

# テキストコンテンツの圧縮レベルを設定します。
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# PDF のコンプライアンス モードを定義します。
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # プレゼンテーションを PDF ドキュメントとして保存します。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions) クラスの [setShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) メソッドを使用して、非表示スライドを生成される PDF のページとして含めることができます。

以下のコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions クラスをインスタンス化します。
    $pdfOptions = new PdfOptions();

    # 非表示スライドを追加します。
    $pdfOptions->setShowHiddenSlides(true);

    # プレゼンテーションを PDF として保存します。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **パスワード保護された PDF に PowerPoint を変換**

以下のコードは、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの保護パラメータを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。
```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptions クラスをインスタンス化します。
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

Aspose.Slides は、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの下にある [setWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback) メソッドを提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

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

// プレゼンテーションを PDF として保存します。
$presentation = new Presentation("sample.pptx");
try {
    // Save the presentation as a PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

レンダリングプロセス中のフォント置換に関するコールバックの取得方法については、[Getting Warning Callbacks for Fonts Substitution](/slides/ja/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) を参照してください。

フォント置換の詳細については、[Font Substitution](/slides/ja/php-java/font-substitution/) 記事をご覧ください。

{{% /alert %}} 

## **選択したスライドのみを PDF に変換**

以下のコードは、PowerPoint プレゼンテーションから特定のスライドだけを PDF に変換する方法を示しています。
```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
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


## **カスタムスライドサイズで PowerPoint を PDF に変換**

以下のコードは、指定したスライドサイズで PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation("SelectedSlides.pptx");

# 調整されたスライドサイズで新しいプレゼンテーションを作成します。
$resizedPresentation = new Presentation();

try {
    # カスタムスライドサイズを設定します。
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # 元のプレゼンテーションから最初のスライドをクローンします。
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # メモ付きでリサイズされたプレゼンテーションを PDF として保存します。
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **ノート スライド ビューで PowerPoint を PDF に変換**

以下のコードは、ノートを含む PDF に PowerPoint プレゼンテーションを変換する方法を示しています。
```php
# PowerPoint または OpenDocument ファイルを表す Presentation クラスをインスタンス化します。
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # ノートレイアウトで PDF オプションを構成します。
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

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PowerPoint ドキュメントを PDF にエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

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

Aspose.Slides は PDF 変換操作もサポートしており、PDF ファイルを一般的な形式に変換できます。[PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) 変換が可能です。さらに、[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) といった特殊フォーマットへの変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は PPT または PPTX ファイルを複数まとめて PDF に変換するバッチ機能をサポートしています。ファイルを列挙し、プログラムで変換処理を適用できます。

**変換後の PDF にパスワードを設定できますか？**

もちろんです。[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスを使用して、変換時にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの `setShowHiddenSlides` メソッドを使用して、生成される PDF に非表示スライドを含められます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/) クラスの `setJpegQuality` や `setSufficientResolution` などのメソッドを利用して、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A のコンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などのさまざまな標準に準拠した PDF のエクスポートを可能にし、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for PHP via Java ドキュメント](/slides/ja/php-java/)
- [Aspose.Slides for PHP via Java API リファレンス](https://reference.aspose.com/slides/php-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)