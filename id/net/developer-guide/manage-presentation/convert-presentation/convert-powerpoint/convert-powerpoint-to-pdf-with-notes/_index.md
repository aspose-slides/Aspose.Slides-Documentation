---
title: Konversi Presentasi PowerPoint ke PDF dengan Catatan di .NET
linktitle: PowerPoint ke PDF dengan Catatan
type: docs
weight: 50
url: /id/net/convert-powerpoint-to-pdf-with-notes/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PDF
- presentasi ke PDF
- slide ke PDF
- PPT ke PDF
- PPTX ke PDF
- simpan presentasi sebagai PDF
- simpan PPT sebagai PDF
- simpan PPTX sebagai PDF
- ekspor PPT ke PDF
- ekspor PPTX ke PDF
- catatan pembicara
- PDF dengan catatan
- .NET
- C#
- Aspose.Slides
description: "Konversi format PPT dan PPTX ke PDF dengan catatan menggunakan Aspose.Slides untuk .NET. Pertahankan tata letak dan catatan pembicara untuk presentasi profesional."
---
## **Gambaran Umum**

Dalam artikel ini, Anda akan mempelajari cara mengonversi presentasi PowerPoint ke format PDF dengan catatan pembicara menggunakan Aspose.Slides. Panduan ini akan mencakup langkah-langkah yang diperlukan dan menyediakan contoh kode untuk membantu Anda menyelesaikan tugas ini dengan efisien. Pada akhir artikel ini, Anda akan dapat:

- Menerapkan proses konversi untuk mengubah slide PowerPoint menjadi dokumen PDF sambil mempertahankan catatan pembicara.
- Menyesuaikan PDF hasil agar catatan pembicara termasuk dan diformat sesuai kebutuhan Anda.

## **Konversi PowerPoint ke PDF dengan Catatan**

Metode `Save` dalam kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/) dapat digunakan untuk mengonversi presentasi PPT atau PPTX ke PDF dengan catatan pembicara. Dengan Aspose.Slides, Anda cukup memuat presentasi, mengonfigurasi opsi tata letak menggunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/notescommentslayoutingoptions/) untuk menyertakan catatan pembicara, lalu menyimpan file sebagai PDF. Cuplikan kode berikut menunjukkan cara mengonversi presentasi contoh ke PDF dalam tampilan Slide Catatan.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    // Konfigurasikan opsi PDF untuk merender catatan pembicara.
    PdfOptions pdfOptions = new PdfOptions
    {
        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // Render catatan pembicara di bawah slide.
        }
    };

    // Simpan presentasi ke PDF dengan catatan pembicara.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}
```

{{% alert color="info" %}} 
Anda mungkin ingin melihat Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/id/conversion). 
{{% /alert %}}