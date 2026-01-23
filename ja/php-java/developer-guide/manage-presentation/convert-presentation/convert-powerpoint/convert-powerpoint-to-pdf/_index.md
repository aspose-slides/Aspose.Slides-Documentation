---
title: PHPでPPTおよびPPTXをPDFに変換（高度な機能を含む）
linktitle: PowerPointからPDFへ
type: docs
weight: 40
url: /ja/php-java/convert-powerpoint-to-pdf/
keywords:
- PowerPointを変換
- プレゼンテーションを変換
- PowerPointからPDFへ
- プレゼンテーションからPDFへ
- PPTをPDFへ
- PPTをPDFに変換
- PPTXをPDFへ
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
description: "Aspose.Slides を使用して、PHPでPowerPoint PPT/PPTXを高品質で検索可能なPDFに変換します。高速なコード例と高度な変換オプションをご提供します。"
---

## **概要**

PowerPoint プレゼンテーション（PPT、PPTX、ODP など）を PHP で PDF 形式に変換すると、さまざまなデバイス間での互換性や、プレゼンテーションのレイアウト・書式を保持できるといった利点があります。このガイドでは、プレゼンテーションを PDF に変換する方法、画像品質の制御オプション、非表示スライドの含め方、PDF のパスワード保護、フォント置換の検出、変換対象スライドの選択、コンプライアンス基準の適用方法を示します。

## **PowerPoint から PDF への変換**

Aspose.Slides を使用すると、次の形式のプレゼンテーションを PDF に変換できます。

* **PPT**
* **PPTX**
* **ODP**

プレゼンテーションを PDF に変換するには、ファイル名を `Presentation` クラスの引数として渡し、`save` メソッドで PDF として保存します。`Presentation` クラスは、通常 PDF への変換に使用される `save` メソッドを提供します。

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java は、API 情報とバージョン番号を出力ドキュメントに埋め込みます。たとえば、プレゼンテーションを PDF に変換すると、Application フィールドに "*Aspose.Slides*"、PDF Producer フィールドに "*Aspose.Slides v XX.XX*" という形式の値が設定されます。**注意**：出力ドキュメントからこの情報を変更または削除するよう指示することはできません。

{{% /alert %}}

Aspose.Slides は次の変換をサポートします。

* プレゼンテーション全体を PDF に変換
* プレゼンテーション内の特定スライドを PDF に変換

Aspose.Slides はプレゼンテーションを PDF にエクスポートし、元のプレゼンテーションに極めて近い PDF を生成します。変換時に正確にレンダリングされる要素と属性は次のとおりです。

* 画像
* テキストボックスとシェイプ
* テキスト書式
* 段落書式
* ハイパーリンク
* ヘッダーとフッター
* 箇条書き
* 表

## **PowerPoint を PDF に変換**

標準の PowerPoint から PDF への変換プロセスはデフォルトオプションを使用します。この場合、Aspose.Slides は最高品質レベルで最適な設定を使用してプレゼンテーションを PDF に変換しようとします。

以下のコードは、プレゼンテーション（PPT、PPTX、ODP など）を PDF に変換する方法を示しています。
```php
# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # プレゼンテーションをPDFとして保存します。
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose は、プレゼンテーションから PDF への変換プロセスを実演する無料オンライン **PowerPoint to PDF converter**（https://products.aspose.app/slides/conversion/ppt-to-pdf）を提供しています。このコンバータでテストを実行すると、ここで説明した手順のリアル実装を確認できます。

{{% /alert %}}

## **オプション付きで PowerPoint を PDF に変換**

Aspose.Slides は、`PdfOptions` クラス（https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions）配下のカスタムオプション（プロパティ）を提供し、結果の PDF をカスタマイズしたり、パスワードでロックしたり、変換プロセスの動作を指定したりできます。

### **カスタムオプション付きで PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、ラスタ画像の品質設定、メタファイルの処理方法、テキストの圧縮レベル、画像の DPI などを指定できます。

以下のコード例は、複数のカスタムオプションを使用して PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```php
# PdfOptionsクラスのインスタンスを作成します。
$pdfOptions = new PdfOptions();

# JPG画像の品質を設定します。
$pdfOptions->setJpegQuality(90);

# 画像のDPIを設定します。
$pdfOptions->setSufficientResolution(300);

# メタファイルの動作を設定します。
$pdfOptions->setSaveMetafilesAsPng(true);

# テキストコンテンツの圧縮レベルを設定します。
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# PDFコンプライアンスモードを定義します。
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # プレゼンテーションをPDFドキュメントとして保存します。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **非表示スライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに非表示スライドが含まれている場合、`PdfOptions` クラス（https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides） の `setShowHiddenSlides` メソッドを使用して、非表示スライドを結果の PDF のページとして含めることができます。

以下のコードは、非表示スライドを含めて PowerPoint プレゼンテーションを PDF に変換する方法を示しています。
```php
# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptionsクラスのインスタンスを作成します。
    $pdfOptions = new PdfOptions();

    # 非表示スライドを追加します。
    $pdfOptions->setShowHiddenSlides(true);

    # プレゼンテーションをPDFとして保存します。
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **パスワード保護された PDF に PowerPoint を変換**

以下のコードは、`PdfOptions` クラス（https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/） の保護パラメーターを使用して、PowerPoint プレゼンテーションをパスワード保護された PDF に変換する方法を示しています。
```php
# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # PdfOptionsクラスのインスタンスを作成します。
    $pdfOptions = new PdfOptions();

    # PDFのパスワードとアクセス許可を設定します。
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # プレゼンテーションをPDFとして保存します。
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


### **フォント置換の検出**

Aspose.Slides は、`PdfOptions` クラス（https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/） の `setWarningCallback` メソッド（https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setWarningCallback） を提供し、プレゼンテーションから PDF への変換プロセス中にフォント置換を検出できます。

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

// PDFオプションで警告コールバックを設定します。
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// プレゼンテーションをPDFとして保存します。
$presentation = new Presentation("sample.pptx");
try {
    // Save the presentation as a PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


{{%  alert color="primary"  %}} 

フォント置換の詳細については、[Font Substitution](/slides/ja/php-java/font-substitution/) 記事をご参照ください。

{{% /alert %}} 

## **選択したスライドだけを PDF に変換**

以下のコードは、PowerPoint プレゼンテーションの特定スライドだけを PDF に変換する方法を示しています。
```php
# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("PowerPoint.pptx");
try {
    # スライド番号の配列を設定します。
    $slides = array(1, 3);

    # プレゼンテーションをPDFとして保存します。
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

# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("SelectedSlides.pptx");

# スライドサイズを調整した新しいプレゼンテーションを作成します。
$resizedPresentation = new Presentation();

try {
    # カスタムスライドサイズを設定します。
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # 元のプレゼンテーションから最初のスライドをクローンします。
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # リサイズされたプレゼンテーションをノート付きPDFとして保存します。
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```


## **ノートスライドビューで PowerPoint を PDF に変換**

以下のコードは、ノートを含む PDF を生成するために PowerPoint プレゼンテーションを変換する方法を示しています。
```php
# PowerPointまたはOpenDocumentファイルを表すPresentationクラスのインスタンスを作成します。
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # ノートレイアウトでPDFオプションを設定します。
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # プレゼンテーションをノート付きPDFとして保存します。
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```


## **PDF のアクセシビリティとコンプライアンス標準**

Aspose.Slides は、[Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) に準拠した変換手順を使用できます。次のコンプライアンス標準のいずれかで PDF をエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

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

Aspose.Slides は PDF 変換機能もサポートしており、PDF ファイルをさまざまな一般的フォーマットに変換できます。たとえば、[PDF to HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDF to image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDF to JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、[PDF to PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/) への変換が可能です。また、[PDF to SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDF to TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、[PDF to XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/) などの専門フォーマットへの変換もサポートされています。

{{% /alert %}}

## **FAQ**

**複数の PowerPoint ファイルを一括で PDF に変換できますか？**

はい、Aspose.Slides は複数の PPT または PPTX ファイルをバッチ変換して PDF にすることをサポートします。ファイルをループ処理し、プログラムから変換プロセスを適用できます。

**変換後の PDF にパスワードを設定できますか？**

もちろんです。`PdfOptions` クラス（https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/） を使用して、変換中にパスワードとアクセス権限を設定できます。

**PDF に非表示スライドを含めるにはどうすればよいですか？**

`PdfOptions` クラス（https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/） の `setShowHiddenSlides` メソッドを使用して、結果の PDF に非表示スライドを含めます。

**Aspose.Slides は PDF の画像品質を高く保てますか？**

はい、`PdfOptions` クラスの `setJpegQuality` や `setSufficientResolution` などのメソッドを利用して、PDF 内の画像を高品質に保つことができます。

**Aspose.Slides は PDF/A コンプライアンス標準をサポートしていますか？**

はい、Aspose.Slides は PDF/A1a、PDF/A1b、PDF/UA などの各種標準に準拠した PDF のエクスポートをサポートし、アクセシビリティとアーカイブ要件を満たすことができます。

## **追加リソース**

- [Aspose.Slides for PHP via Java ドキュメント](/slides/ja/php-java/)
- [Aspose.Slides for PHP via Java API リファレンス](https://reference.aspose.com/slides/php-java/)
- [Aspose 無料オンラインコンバータ](https://products.aspose.app/slides/conversion)