---
title: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/androidjava/import-presentation/
keywords: "プレゼンテーションへのPowerPoint、PDFのインポート、PDFからPPTXへ、PDFからPPTへ、Java、Aspose.Slides for Android via Java"
description: "PDFからPowerPointプレゼンテーションをインポートします。PDFをPowerPointに変換します"
---

[**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/androidjava/)を使用すると、他の形式のファイルからプレゼンテーションをインポートできます。Aspose.Slidesは、PDF、HTMLドキュメントなどからプレゼンテーションをインポートするために[SlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/)クラスを提供します。

## **PDFからPowerPointをインポート**

この場合、PDFをPowerPointプレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)クラスのインスタンスを作成します。
2. [addFromPdf()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-)メソッドを呼び出し、PDFファイルを渡します。
3. [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、ファイルをPowerPoint形式で保存します。

このJavaコードはPDFからPowerPointへの操作を示しています：

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="ヒント" color="primary" %}} 

**Aspose無料** [PDFからPowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint)ウェブアプリをチェックしてみると良いでしょう。ここで説明されたプロセスのライブ実装です。

{{% /alert %}} 

## **HTMLからPowerPointをインポート**

この場合、HTMLドキュメントをPowerPointプレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)クラスのインスタンスを作成します。
2. [addFromHtml()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-)メソッドを呼び出し、HTMLファイルを渡します。
3. [save()](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-)メソッドを使用して、ファイルをPowerPoint形式で保存します。

このJavaコードはHTMLからPowerPointへの操作を示しています：

```java
Presentation presentation = new Presentation();
try {
    FileInputStream htmlStream = new FileInputStream("page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) htmlStream.close();
    }

    presentation.save("MyPresentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

{{% alert title="注意" color="warning" %}} 

Aspose.Slidesを使用して、HTMLを他の人気のファイル形式に変換することもできます：

* [HTMLから画像](https://products.aspose.com/slides/androidjava/conversion/html-to-image/)
* [HTMLからJPG](https://products.aspose.com/slides/androidjava/conversion/html-to-jpg/)
* [HTMLからXML](https://products.aspose.com/slides/androidjava/conversion/html-to-xml/)
* [HTMLからTIFF](https://products.aspose.com/slides/androidjava/conversion/html-to-tiff/)

{{% /alert %}}