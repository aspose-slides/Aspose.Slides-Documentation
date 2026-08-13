---
title: Impor Presentasi dari PDF atau HTML di .NET
linktitle: Impor Presentasi
type: docs
weight: 60
url: /id/net/import-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Impor PDF dan dokumen HTML dengan mudah ke dalam presentasi PowerPoint dan OpenDocument di .NET menggunakan Aspose.Slides untuk pemrosesan slide yang mulus dan berkinerja tinggi."
---
## **Pendahuluan**

Dengan menggunakan Aspose.Slides, Anda dapat mengimpor presentasi dari file dalam format lain. Aspose.Slides menyediakan kelas [SlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/) yang memungkinkan Anda mengimpor presentasi dari dokumen PDF dan HTML.

## **Impor PowerPoint dari PDF**

Dalam kasus ini, Anda dapat mengonversi PDF menjadi presentasi PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). 
2. Panggil metode [AddFromPdf](https://reference.aspose.com/slides/id/net/aspose.slides.slidecollection/addfrompdf/methods/1) dan berikan file PDF. 
3. Gunakan metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides.presentation/save/methods/5) untuk menyimpan file dalam format PowerPoint.

Kode C# ini menunjukkan operasi PDF ke PowerPoint:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="info" %}} 
Anda mungkin ingin melihat aplikasi web **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) karena itu merupakan implementasi langsung dari proses yang dijelaskan di sini. 
{{% /alert %}} 

## **Impor PowerPoint dari HTML**

Dalam kasus ini, Anda dapat mengonversi dokumen HTML menjadi presentasi PowerPoint.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). 
2. Panggil metode [AddFromHtml](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) dan berikan file HTML. 
3. Gunakan metode [Save](https://apireference.aspose.com/slides/id/net/aspose.slides.presentation/save/methods/5) untuk menyimpan file sebagai dokumen PowerPoint.

Kode C# ini menunjukkan operasi HTML ke PowerPoint: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (var presentation = new Presentation())
{
    using (var htmlStream = File.OpenRead("page.html"))
    {
        presentation.Slides.AddFromHtml(htmlStream);
    }

    presentation.Save("MyPresentation.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Apakah tabel tetap terjaga saat mengimpor PDF, dan apakah deteksi tabel dapat ditingkatkan?

Tabel dapat dideteksi selama proses impor; [PdfImportOptions](https://reference.aspose.com/slides/id/net/aspose.slides.import/pdfimportoptions/) mencakup parameter [DetectTables](https://reference.aspose.com/slides/id/net/aspose.slides.import/pdfimportoptions/detecttables/) yang mengaktifkan pengenalan tabel. Efektivitasnya bergantung pada struktur PDF.

{{% alert title="Note" color="warning" %}} 
Anda juga dapat menggunakan Aspose.Slides untuk mengonversi HTML ke format file populer lainnya: 

* [HTML to image](https://products.aspose.com/slides/id/net/conversion/html-to-image/)
* [HTML to JPG](https://products.aspose.com/slides/id/net/conversion/html-to-jpg/)
* [HTML to XML](https://products.aspose.com/slides/id/net/conversion/html-to-xml/)
* [HTML to TIFF](https://products.aspose.com/slides/id/net/conversion/html-to-tiff/)

{{% /alert %}}