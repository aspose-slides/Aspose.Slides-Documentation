---
title: Impor Presentasi dari PDF atau HTML dalam JavaScript
linktitle: Impor Presentasi
type: docs
weight: 60
url: /id/nodejs-java/import-presentation/
keywords:
- impor presentasi
- impor slide
- impor PDF
- impor HTML
- PDF ke presentasi
- PDF ke PPT
- PDF ke PPTX
- PDF ke ODP
- HTML ke presentasi
- HTML ke PPT
- HTML ke PPTX
- HTML ke ODP
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Impor dokumen PDF dan HTML ke dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Node.js untuk pemrosesan slide yang mulus dan berkinerja tinggi."
---
## **Pendahuluan**

Dengan menggunakan [**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/id/nodejs-java/), Anda dapat mengimpor presentasi dari file dalam format lain. Aspose.Slides menyediakan kelas [SlideCollection](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/) untuk memungkinkan Anda mengimpor presentasi dari PDF, dokumen HTML, dll.

## **Impor PowerPoint dari PDF**

Dalam kasus ini, Anda dapat mengonversi PDF menjadi presentasi PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/).
2. Panggil metode [addFromPdf()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) dan berikan file PDF.
3. Gunakan metode [save()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) untuk menyimpan file dalam format PowerPoint.

Kode JavaScript ini menunjukkan operasi konversi PDF ke PowerPoint:

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
Anda mungkin ingin mencoba aplikasi web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) karena itu merupakan implementasi langsung dari proses yang dijelaskan di sini. 
{{% /alert %}} 

## **Impor PowerPoint dari HTML**

Dalam kasus ini, Anda dapat mengonversi dokumen HTML menjadi presentasi PowerPoint.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/).
2. Panggil metode [addFromHtml()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) dan berikan file PDF.
3. Gunakan metode [save()](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) untuk menyimpan file dalam format PowerPoint.

Kode JavaScript ini menunjukkan operasi konversi HTML ke PowerPoint:

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

**Apakah tabel tetap terjaga saat mengimpor PDF, dan dapatkah deteksi mereka ditingkatkan?**

Tabel dapat dideteksi selama proses impor; [PdfImportOptions](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfimportoptions/) mencakup metode [setDetectTables](https://reference.aspose.com/slides/id/nodejs-java/aspose.slides/pdfimportoptions/#setDetectTables) yang mengaktifkan pengenalan tabel. Keefektifannya tergantung pada struktur PDF.