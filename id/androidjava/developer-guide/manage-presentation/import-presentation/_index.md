---
title: "Impor Presentasi dari PDF atau HTML di Android"
linktitle: "Impor Presentasi"
type: docs
weight: 60
url: /id/androidjava/import-presentation/
keywords:
- "impor presentasi"
- "impor slide"
- "impor PDF"
- "impor HTML"
- "PDF ke presentasi"
- "PDF ke PPT"
- "PDF ke PPTX"
- "PDF ke ODP"
- "HTML ke presentasi"
- "HTML ke PPT"
- "HTML ke PPTX"
- "HTML ke ODP"
- "PowerPoint"
- "OpenDocument"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Impor dokumen PDF dan HTML ke dalam presentasi PowerPoint dan OpenDocument menggunakan Java dengan Aspose.Slides untuk Android untuk pemrosesan slide yang mulus dan berkinerja tinggi."
---
## **Pendahuluan**

Menggunakan [**Aspose.Slides for Android via Java**](https://products.aspose.com/slides/id/androidjava/), Anda dapat mengimpor presentasi dari file dalam format lain. Aspose.Slides menyediakan kelas [SlideCollection](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidecollection/) untuk memungkinkan Anda mengimpor presentasi dari PDF, dokumen HTML, dll.

## **Impor PowerPoint dari PDF**

Dalam kasus ini, Anda akan mengonversi PDF menjadi presentasi PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/).
2. Panggil metode [addFromPdf()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/SlideCollection#addFromPdf-java.lang.String-) dan berikan file PDF.
3. Gunakan metode [save()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) untuk menyimpan file dalam format PowerPoint.

Kode Java ini menunjukkan operasi PDF ke PowerPoint:

```java
Presentation pres = new Presentation();
try {
    pres.getSlides().addFromPdf("InputPDF.pdf");
    pres.save("OutputPresentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert  title="Tip" color="primary" %}} 
Anda mungkin ingin mencoba **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) web app karena itu merupakan implementasi langsung dari proses yang dijelaskan di sini. 
{{% /alert %}} 

## **Impor PowerPoint dari HTML**

Dalam kasus ini, Anda akan mengonversi dokumen HTML menjadi presentasi PowerPoint.

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/).
2. Panggil metode [addFromHtml()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) dan berikan file PDF.
3. Gunakan metode [save()](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-) untuk menyimpan file dalam format PowerPoint.

Kode Java ini menunjukkan operasi HTML ke PowerPoint: 

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

## **FAQ**

**Apakah tabel dipertahankan saat mengimpor PDF, dan apakah deteksi mereka dapat ditingkatkan?**

Tabel dapat dideteksi selama impor; [PdfImportOptions](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pdfimportoptions/) mencakup metode [setDetectTables](https://reference.aspose.com/slides/id/androidjava/com.aspose.slides/pdfimportoptions/#setDetectTables-boolean-) yang mengaktifkan pengenalan tabel. Efektivitasnya bergantung pada struktur PDF.