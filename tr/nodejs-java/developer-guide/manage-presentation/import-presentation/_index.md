---
title: PDF veya HTML'den JavaScript ile Sunumları İçe Aktarma
linktitle: Sunumu İçe Aktar
type: docs
weight: 60
url: /tr/nodejs-java/import-presentation/
keywords:
- sunum içe aktar
- slayt içe aktar
- PDF içe aktar
- HTML içe aktar
- PDF'den sunuma
- PDF'den PPT'ye
- PDF'den PPTX'e
- PDF'den ODP'ye
- HTML'den sunuma
- HTML'den PPT'ye
- HTML'den PPTX'e
- HTML'den ODP'ye
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile PDF ve HTML belgelerini PowerPoint ve OpenDocument sunumlarına sorunsuz ve yüksek performanslı slayt işleme için içe aktarın."
---
## **Giriş**

Using [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/tr/nodejs-java/), you can import presentations from files in other formats. Aspose.Slides provides the [SlideCollection](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/) class to allow you to import presentations from PDFs, HTML documents, etc.

## **PDF'ten PowerPoint'e Aktarım**

Bu durumda, bir PDF'yi PowerPoint sunumuna dönüştürebilirsiniz.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/) sınıfının örneğini oluşturun.  
2. PDF dosyasını geçerek [addFromPdf()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) metodunu çağırın.  
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu JavaScript kodu PDF'ten PowerPoint'e dönüşüm işlemini gösterir:

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

Burada açıklanan sürecin canlı bir uygulaması olduğu için **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/tr/import/pdf-to-powerpoint) web uygulamasına göz atmak isteyebilirsiniz. 

{{% /alert %}} 

## **HTML'den PowerPoint'e Aktarım**

Bu durumda, bir HTML belgesini PowerPoint sunumuna dönüştürebilirsiniz.

1. Bir [Presentation](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/) sınıfının örneğini oluşturun.  
2. HTML dosyasını geçerek [addFromHtml()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) metodunu çağırın.  
3. Dosyayı PowerPoint formatında kaydetmek için [save()](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) metodunu kullanın.

Bu JavaScript kodu HTML'den PowerPoint'e dönüşüm işlemini gösterir:

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

## **SSS**

**PDF içe aktarılırken tablolar korunur mu ve algılamaları iyileştirilebilir mi?**

Tablolar içe aktarma sırasında algılanabilir; [PdfImportOptions](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfimportoptions/) içinde tablo tanımasını etkinleştiren bir [setDetectTables](https://reference.aspose.com/slides/tr/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) metodu bulunur. Etkinlik, PDF'nin yapısına bağlıdır.