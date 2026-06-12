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
description: "Impor dokumen PDF dan HTML dengan mudah ke dalam presentasi PowerPoint dan OpenDocument di .NET menggunakan Aspose.Slides untuk pemrosesan slide yang mulus dan berkinerja tinggi."
---
## **Pendahuluan**

Dengan Aspose.Slides, Anda dapat mengimpor presentasi dari file dalam format lain. Aspose.Slides menyediakan kelas [SlideCollection](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/) yang memungkinkan Anda mengimpor presentasi dari dokumen PDF dan HTML.

## **Import PowerPoint dari PDF**

Dalam kasus ini, Anda dapat mengonversi PDF menjadi presentasi PowerPoint.

<img src="pdf-to-powerpoint.png" alt="pdf-to-powerpoint" style="zoom: 50%;" />

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/). 
2. Panggil metode [AddFromPdf](https://reference.aspose.com/slides/id/net/aspose.slides.slidecollection/addfrompdf/methods/1) dan berikan file PDF. 
3. Gunakan metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides.presentation/save/methods/5) untuk menyimpan file dalam format PowerPoint.

```c#
using (Presentation pres = new Presentation())
{
    pres.Slides.AddFromPdf("InputPDF.pdf");
    pres.Save("OutputPresentation.pptx", SaveFormat.Pptx);
}
```

{{% alert  title="TIP" color="primary" %}} 
Anda mungkin ingin melihat **Aspose free** [PDF to PowerPoint](https://products.aspose.app/slides/id/import/pdf-to-powerpoint) aplikasi web karena ini adalah implementasi langsung dari proses yang dijelaskan di sini. 
{{% /alert %}} 

## **Import PowerPoint dari HTML**

Dalam kasus ini, Anda dapat mengonversi dokumen HTML menjadi presentasi PowerPoint.

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) . 
2. Panggil metode [AddFromHtml](https://reference.aspose.com/slides/id/net/aspose.slides/slidecollection/addfromhtml/#addfromhtml) dan berikan file HTML. 
3. Gunakan metode [Save](https://apireference.aspose.com/slides/id/net/aspose.slides.presentation/save/methods/5) untuk menyimpan file sebagai dokumen PowerPoint.

```c#
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

**Apakah tabel dipertahankan saat mengimpor PDF, dan dapatkah deteksinya ditingkatkan?**

Tabel dapat terdeteksi selama proses impor; [PdfImportOptions](https://reference.aspose.com/slides/id/net/aspose.slides.import/pdfimportoptions/) menyertakan parameter [DetectTables](https://reference.aspose.com/slides/id/net/aspose.slides.import/pdfimportoptions/detecttables/) yang memungkinkan pengenalan tabel. Efektivitasnya tergantung pada struktur PDF.

{{% alert title="Note" color="warning" %}} 
Anda juga dapat menggunakan Aspose.Slides untuk mengonversi HTML ke format file populer lainnya: 

* [HTML ke gambar](https://products.aspose.com/slides/id/net/conversion/html-to-image/)
* [HTML ke JPG](https://products.aspose.com/slides/id/net/conversion/html-to-jpg/)
* [HTML ke XML](https://products.aspose.com/slides/id/net/conversion/html-to-xml/)
* [HTML ke TIFF](https://products.aspose.com/slides/id/net/conversion/html-to-tiff/)

{{% /alert %}}