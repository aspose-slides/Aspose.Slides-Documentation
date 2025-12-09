---
title: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/nodejs-java/import-presentation/
keywords: "PowerPoint のインポート, PDF からプレゼンテーション, PDF から PPTX, PDF から PPT, Java, Aspose.Slides for Node.js via Java"
description: "PDF から PowerPoint プレゼンテーションをインポートします。PDF を PowerPoint に変換します"
---

Using [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

## **PDF から PowerPoint をインポート**

この場合、PDF を PowerPoint プレゼンテーションに変換できます。

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) メソッドを呼び出し、PDF ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この JavaScript コードは PDF から PowerPoint への変換操作を示しています:  
```javascript
var pres = new aspose.slides.Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


{{% alert  title="Tip" color="primary" %}} 
このプロセスの実装例として、**Aspose free** の [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) Web アプリをご確認いただくとよいでしょう。 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

この場合、HTML ドキュメントを PowerPoint プレゼンテーションに変換できます。

1. [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) クラスのインスタンスを作成します。  
2. [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) メソッドを呼び出し、HTML ファイルを渡します。  
3. [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) メソッドを使用して、ファイルを PowerPoint 形式で保存します。

この JavaScript コードは HTML から PowerPoint への変換操作を示しています:  
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var htmlStream = java.newInstanceSync("java.io.FileInputStream", "page.html");
    try {
        presentation.getSlides().addFromHtml(htmlStream);
    } finally {
        if (htmlStream != null) {
            htmlStream.close();
        }
    }
    presentation.save("MyPresentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {
    console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```


## **FAQ**

**PDF のインポート時にテーブルは保持されますか、また検出精度を向上させることはできますか？**

インポート時にテーブルを検出できます。[PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) には、テーブル認識を有効にする [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) メソッドが含まれています。効果は PDF の構造に依存します。

{{% alert title="Note" color="warning" %}} 
Aspose.Slides を使用して、HTML を他の一般的なファイル形式に変換することもできます: 

* [HTML to image](https://products.aspose.com/slides/nodejs-java/conversion/html-to-image/) - HTML から画像  
* [HTML to JPG](https://products.aspose.com/slides/nodejs-java/conversion/html-to-jpg/) - HTML から JPG  
* [HTML to XML](https://products.aspose.com/slides/nodejs-java/conversion/html-to-xml/) - HTML から XML  
* [HTML to TIFF](https://products.aspose.com/slides/nodejs-java/conversion/html-to-tiff/) - HTML から TIFF  

{{% /alert %}}