---
title: Impor Presentasi dari PDF atau HTML dalam PHP
linktitle: Impor Presentasi
type: docs
weight: 60
url: /id/php-java/import-presentation/
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
- PHP
- Aspose.Slides
description: "Impor dokumen PDF dan HTML ke dalam presentasi PowerPoint dan OpenDocument di PHP dengan Aspose.Slides untuk pemrosesan slide yang mulus dan berkinerja tinggi."
---
## **Pendahuluan**

Dengan menggunakan [**Aspose.Slides for PHP via Java**](https://products.aspose.com/slides/id/php-java/), Anda dapat mengimpor presentasi dari file dalam format lain. Aspose.Slides menyediakan kelas [SlideCollection](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/) untuk memungkinkan Anda mengimpor presentasi dari PDF, dokumen HTML, dll.

## **Impor PowerPoint dari PDF**

Dalam kasus ini, Anda dapat mengonversi PDF menjadi presentasi PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom:50%;" />

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/) .
2. Panggil metode [addFromPdf()](https://reference.aspose.com/slides/id/php-java/aspose.slides/SlideCollection#addFromPdf-java.lang.String-) dan berikan file PDF.
3. Gunakan metode [save()](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#save-java.lang.String-int-) untuk menyimpan file dalam format PowerPoint.

Kode PHP ini menunjukkan operasi PDF ke PowerPoint:

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

{{% alert title="Tips" color="primary" %}} 
Anda mungkin ingin mencoba aplikasi web Aspose gratis [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) karena ini merupakan implementasi langsung dari proses yang dijelaskan di sini. 
{{% /alert %}} 

## **Impor PowerPoint dari HTML**

Dalam kasus ini, Anda dapat mengonversi dokumen HTML menjadi presentasi PowerPoint.

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/php-java/aspose.slides/) .
2. Panggil metode [addFromHtml()](https://reference.aspose.com/slides/id/php-java/aspose.slides/slidecollection/#addFromHtml-java.io.InputStream-) dan berikan file HTML.
3. Gunakan metode [save()](https://reference.aspose.com/slides/id/php-java/aspose.slides/Presentation#save-java.lang.String-int-) untuk menyimpan file dalam format PowerPoint.

Kode PHP ini menunjukkan operasi HTML ke PowerPoint:

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

**Apakah tabel tetap terjaga saat mengimpor PDF, dan apakah deteksi mereka dapat ditingkatkan?**

Tabel dapat dideteksi selama proses impor; [PdfImportOptions](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfimportoptions/) menyertakan metode [setDetectTables](https://reference.aspose.com/slides/id/php-java/aspose.slides/pdfimportoptions/#setDetectTables) yang memungkinkan pengenalan tabel. Efektivitasnya bergantung pada struktur PDF.

{{% alert title="Catatan" color="warning" %}} 
Anda juga dapat menggunakan Aspose.Slides untuk mengonversi HTML ke format file populer lainnya: 

* [HTML to image](https://products.aspose.com/slides/id/php-java/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/id/php-java/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/id/php-java/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/id/php-java/conversion/html-to-tiff/)

{{% /alert %}}