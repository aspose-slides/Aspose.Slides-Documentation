---
title: PDFまたはHTMLからPHPでプレゼンテーションをインポート
linktitle: プレゼンテーションをインポート
type: docs
weight: 60
url: /ja/php-java/import-presentation/
keywords:
- プレゼンテーションをインポート
- スライドをインポート
- PDFをインポート
- HTMLをインポート
- PDFからプレゼンテーションへ
- PDFからPPTへ
- PDFからPPTXへ
- PDFからODPへ
- HTMLからプレゼンテーションへ
- HTMLからPPTへ
- HTMLからPPTXへ
- HTMLからODPへ
- PowerPoint
- OpenDocument
- PHP
- Aspose.Slides
description: "Aspose.Slides を使用して、PHP で PDF および HTML ドキュメントを PowerPoint および OpenDocument のプレゼンテーションにシームレスかつ高速にインポートします。"
---

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/) を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slides は、[SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) クラスを提供し、PDF、HTML ドキュメントなどからプレゼンテーションをインポートできます。

## **PDF から PowerPoint にインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) メソッドを呼び出し、PDF ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、PowerPoint 形式でファイルを保存します。

この PHP コードは PDF から PowerPoint への変換を実演します:
```php
  $pres = new Presentation();
  try {
    $pres->getSlides()->addFromPdf("InputPDF.pdf");
    $pres->save("OutputPresentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert  title="Tip" color="primary" %}} 
このプロセスの実装例として、**Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリをご確認ください。 
{{% /alert %}} 

## **HTML から PowerPoint にインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) メソッドを呼び出し、HTML ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、PowerPoint 形式でファイルを保存します。

この PHP コードは HTML から PowerPoint への変換を実演します:
```php
  $presentation = new Presentation();
  try {
    $htmlStream = new Java("java.io.FileInputStream", "page.html");
    try {
      $presentation->getSlides()->addFromHtml($htmlStream);
    } finally {
      if (!java_is_null($htmlStream)) {
        $htmlStream->close();
      }
    }
    $presentation->save("MyPresentation.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```


## **FAQ**

**PDF をインポートする際にテーブルは保持されますか？また、検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/) にはテーブル認識を有効にする [setDetectTables](https://reference.aspose.com/slides/php-java/aspose.slides/pdfimportoptions/#setDetectTables) メソッドが含まれています。効果は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides を使用して HTML を他の一般的なファイル形式に変換することもできます: 

* [HTML を画像に変換](https://products.aspose.com/slides/php-java/conversion/html-to-image/)  
* [HTML を JPG に変換](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)  
* [HTML を XML に変換](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)  
* [HTML を TIFF に変換](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)  

{{% /alert %}}