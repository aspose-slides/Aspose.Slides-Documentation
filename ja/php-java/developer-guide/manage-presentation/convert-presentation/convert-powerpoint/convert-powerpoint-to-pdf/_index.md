---
title: PowerPointをPDFに変換
linktitle: PowerPointをPDFに変換
type: docs
weight: 40
url: /php-java/convert-powerpoint-to-pdf/
keywords: "PowerPointを変換, プレゼンテーション, PowerPointをPDFに, PPTをPDFに, PPTXをPDFに, PowerPointをPDFとして保存, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "PowerPointプレゼンテーションをPDFに変換します。準拠性やアクセシビリティ基準を満たしながらPowerPointをPDFとして保存"

---
## **概要**

この記事では、PHPを使用してPowerPointファイル形式をPDFに変換する方法を説明します。次のような幅広いトピックをカバーします。

- PPTをPDFに変換
- PPTXをPDFに変換
- ODPをPDFに変換
- PowerPointをPDFに変換

## **Java PowerPointからPDFへの変換**

Aspose.Slidesを使用すると、これらのフォーマットのプレゼンテーションをPDFに変換できます：

* PPT
* PPTX
* ODP

プレゼンテーションをPDFに変換するには、[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスにファイル名を引数として渡し、次に[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用してプレゼンテーションをPDFとして保存します。[Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)クラスは、プレゼンテーションをPDFに変換するために通常使用される[Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを公開しています。

{{%  alert title="注意"  color="warning"   %}} 

Aspose.Slides for PHP via Javaは、出力ドキュメントにAPI情報およびバージョン番号を直接書き込みます。たとえば、プレゼンテーションをPDFに変換すると、Aspose.Slides for PHP via Javaはアプリケーションフィールドに'*Aspose.Slides*'という値を、PDFプロデューサーフィールドには'*Aspose.Slides v XX.XX*'という形式の値を設定します。**注意**として、出力ドキュメントからこの情報を変更または削除するようにAspose.Slides for PHP via Javaに指示することはできません。

{{% /alert %}}

Aspose.Slidesを使用すると、以下のことができます：

* プレゼンテーション全体をPDFに
* プレゼンテーション内の特定のスライドをPDFに
* プレゼンテーションを 

Aspose.Slidesは、プレゼンテーションをPDFにエクスポートする際に、結果のPDFの内容が元のプレゼンテーションと非常に似ている方法で処理を行います。これらの既知の要素と属性は、プレゼンテーションからPDFへの変換中に正しくレンダリングされることがよくあります：

* 画像
* テキストボックスおよびその他の形状
* テキストおよびその書式
* 段落およびその書式
* ハイパーリンク
* ヘッダーおよびフッター
* 箇条書き
* テーブル

## **PowerPointをPDFに変換**

標準のPowerPoint PDF変換操作は、デフォルトのオプションを使用して実行されます。この場合、Aspose.Slidesは、最適な設定を使って提供されたプレゼンテーションをPDFに変換しようとします。

このPHPコードは、PowerPointをPDFに変換する方法を示しています：

```php
  # PowerPointファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # プレゼンテーションをPDFとして保存
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

Asposeは、プレゼンテーションからPDFへの変換プロセスを示す無料のオンライン[**PowerPoint to PDFコンバータ**](https://products.aspose.app/slides/conversion/ppt-to-pdf)を提供しています。ここで説明されている手順のライブ実装をテストするには、コンバータを使用できます。

{{% /alert %}}

## **オプションを使用して PowerPoint を PDF に変換**

Aspose.Slidesは、PDF（変換プロセスの結果）をカスタマイズし、PDFをパスワードでロックし、変換プロセスの進行方法を指定できるカスタムオプションを提供します。

### **カスタムオプションを使用して PowerPoint を PDF に変換**

カスタム変換オプションを使用すると、JPG画像の好みの品質設定を設定したり、メタファイルの取り扱い方法を指定したり、テキストの圧縮レベルを設定したりできます。

このPHPコードは、PowerPointをPDFに変換するための複数のカスタムオプションを使った操作を示しています：

```php
// PowerPointファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # PdfOptionsクラスをインスタンス化
    $pdfOptions = new PdfOptions();
    # Jpeg品質を設定
    $pdfOptions->setJpegQuality(90);
    # メタファイルの取り扱い動作を設定
    $pdfOptions->setSaveMetafilesAsPng(true);
    # テキストの圧縮レベルを設定
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # PDF標準を定義
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # プレゼンテーションをPDFとして保存
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **隠れスライドを含めて PowerPoint を PDF に変換**

プレゼンテーションに隠れスライドが含まれている場合、カスタムオプションである[ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--)プロパティを使用して、Aspose.Slidesに隠れスライドを結果のPDFのページとして含めるよう指示できます。

このPHPコードは、隠れスライドを含めてPowerPointプレゼンテーションをPDFに変換する方法を示します：

```php
// PowerPointファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # PdfOptionsクラスをインスタンス化
    $pdfOptions = new PdfOptions();
    # 隠れスライドを追加
    $pdfOptions->setShowHiddenSlides(true);
    # プレゼンテーションをPDFとして保存
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **パスワード保護されたPDFに PowerPoint を変換**

このPHPコードは、PowerPointをパスワード保護されたPDFに変換する方法を示しています（[PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)クラスからの保護パラメータを使用）：

```php
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # PdfOptionsクラスをインスタンス化
    $pdfOptions = new PdfOptions();
    # PDFパスワードとアクセス権限を設定
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # プレゼンテーションをPDFとして保存
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **フォント置き換えの検出**

Aspose.Slidesは、[SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/)クラスの[getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--)メソッドを提供しており、プレゼンテーションをPDFに変換するときのフォント置き換えを検出できるようにしています。

このPHPコードは、フォント置き換えを検出する方法を示しています：

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted"))) {
            echo ("フォント置き換え警告: " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

フォント置き換えのコールバックを取得する方法についての詳細は、[フォント置き換えの警告コールバックを取得する](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/)をご覧ください。

フォント置き換えに関する詳細は、[フォントの置き換え](https://docs.aspose.com/slides/php-java/font-substitution/)の記事をご覧ください。

{{% /alert %}} 

## **特定のスライドをPowerPointからPDFに変換**

このPHPコードは、PowerPointプレゼンテーションの特定のスライドをPDFに変換する方法を示しています：

```php
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # スライドの位置の配列を設定
    $slides = array(1, 3 );
    # プレゼンテーションをPDFとして保存
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **カスタムスライドサイズで PowerPoint を PDF に変換**

このPHPコードは、スライドサイズが指定されたPowerPointをPDFに変換する方法を示しています：

```php
// PowerPointファイルを表すPresentationオブジェクトをインスタンス化 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # スライドのタイプとサイズを設定
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **ノートスライド表示で PowerPoint を PDF に変換**

このPHPコードは、PowerPointをノート付きのPDFに変換する方法を示しています：

```php
// PowerPointファイルを表すPresentationクラスをインスタンス化
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **PDFのアクセシビリティおよび準拠性基準**

Aspose.Slidesは、[ウェブコンテンツアクセシビリティガイドライン（**WCAG**）](https://www.w3.org/TR/WCAG-TECHS/pdf.html)を満たす変換手順を使用できます。これらの準拠基準に基づいてPowerPointドキュメントをPDFにエクスポートできます：**PDF/A1a**、**PDF/A1b**、**PDF/UA**。

このPHPコードは、異なる準拠基準に基づいて複数のPDFを取得するPowerPointからPDFへの変換操作を示しています：

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slidesは、PDFを最も一般的なファイル形式に変換する操作をサポートしています。[PDFからHTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/)、[PDFから画像](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/)、[PDFからJPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/)、[PDFからPNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/)への変換が可能です。その他の特殊形式へのPDF変換操作もサポートされています—[PDFからSVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/)、[PDFからTIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/)、および[PDFからXML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)。

{{% /alert %}}