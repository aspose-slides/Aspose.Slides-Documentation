---
title: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/php-java/import-presentation/
keywords: "PowerPointのインポート、PDFからプレゼンテーションへ、PDFからPPTXへ、PDFからPPTへ、Java、Aspose.Slides for PHP via Java"
description: "PDFからPowerPointプレゼンテーションをインポートします。PDFをPowerPointに変換します"
---

[**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/php-java/)を使用すると、他のフォーマットのファイルからプレゼンテーションをインポートできます。Aspose.Slidesは、PDF、HTMLドキュメントなどからプレゼンテーションをインポートできる[SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/)クラスを提供しています。

## **PDFからPowerPointをインポートする**

この場合、PDFをPowerPointプレゼンテーションに変換します。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/)クラスのインスタンスを作成します。
2. [addFromPdf()](https://reference.aspose.com/slides/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-)メソッドを呼び出し、PDFファイルを渡します。
3. [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、PowerPoint形式でファイルを保存します。

このPHPコードは、PDFからPowerPointへの操作を示しています：

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

{{% alert  title="ヒント" color="primary" %}} 

ここで説明されているプロセスのライブ実装である**Aspose無料** [PDFからPowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)ウェブアプリをチェックすることをお勧めします。 

{{% /alert %}} 

## **HTMLからPowerPointをインポートする**

この場合、HTMLドキュメントをPowerPointプレゼンテーションに変換します。

1. [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/)クラスのインスタンスを作成します。
2. [addFromHtml()](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-)メソッドを呼び出し、PDFファイルを渡します。
3. [save()](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、PowerPoint形式でファイルを保存します。

このPHPコードは、HTMLからPowerPointへの操作を示しています：

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

{{% alert title="注意" color="warning" %}} 

Aspose.Slidesを使用して、HTMLを他の一般的なファイル形式に変換することもできます： 

* [HTMLから画像](https://products.aspose.com/slides/php-java/conversion/html-to-image/)
* [HTMLからJPG](https://products.aspose.com/slides/php-java/conversion/html-to-jpg/)
* [HTMLからXML](https://products.aspose.com/slides/php-java/conversion/html-to-xml/)
* [HTMLからTIFF](https://products.aspose.com/slides/php-java/conversion/html-to-tiff/)

{{% /alert %}}