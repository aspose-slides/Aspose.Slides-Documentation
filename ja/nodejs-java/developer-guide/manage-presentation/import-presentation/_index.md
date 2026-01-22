---
title: JavaScriptでPDFまたはHTMLからプレゼンテーションをインポート
linktitle: プレゼンテーションのインポート
type: docs
weight: 60
url: /ja/nodejs-java/import-presentation/
keywords:
- プレゼンテーションのインポート
- スライドのインポート
- PDFのインポート
- HTMLのインポート
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js を使用して、PDF および HTML ドキュメントを PowerPoint および OpenDocument プレゼンテーションにインポートし、シームレスで高性能なスライド処理を実現します。"
---

Using [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nodejs-java/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

## **PDF から PowerPoint をインポート**

In this case, you get to convert a PDF to a PowerPoint presentation.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) class.  
2. Call the [addFromPdf()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) method and pass the PDF file.  
3. Use the [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This JavaScript code demonstrates the PDF to PowerPoint operation:
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
You may want to check out **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/import/pdf-to-powerpoint) web app because it is a live implementation of the process described here. 
{{% /alert %}} 

## **HTML から PowerPoint をインポート**

In this case, you get to convert a HTML document to a PowerPoint presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/) class.  
2. Call the [addFromHtml()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) method and pass the HTML file.  
3. Use the [save()](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) method to save the file in the PowerPoint format.

This JavaScript code demonstrates the HTML to PowerPoint operation:
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

**Are tables preserved when importing a PDF, and can their detection be improved?**

Tables can be detected during import; [PdfImportOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/) includes a [setDetectTables](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) method that enables table recognition. The effectiveness depends on the PDF’s structure.