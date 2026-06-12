---
title: Konversi Presentasi PowerPoint ke SWF Flash di .NET
linktitle: PowerPoint ke SWF
type: docs
weight: 80
url: /id/net/convert-powerpoint-to-swf-flash/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke SWF
- presentasi ke SWF
- slide ke SWF
- PPT ke SWF
- PPTX ke SWF
- PowerPoint ke Flash
- presentasi ke Flash
- slide ke Flash
- PPT ke Flash
- PPTX ke Flash
- simpan PPT sebagai SWF
- simpan PPTX sebagai SWF
- ekspor PPT ke SWF
- ekspor PPTX ke SWF
- PowerPoint
- presentasi
- .NET
- C#
- Aspose.Slides
description: "Konversi PowerPoint (PPT/PPTX) ke SWF Flash di .NET dengan Aspose.Slides. Contoh kode C# langkah demi langkah, output cepat berkualitas, tanpa automasi PowerPoint."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi presentasi PowerPoint ke SWF dengan menggunakan Aspose.Slides. Artikel ini menunjukkan cara menyimpan presentasi sebagai file SWF dengan metode [Presentation.Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/save/) dan cara mengonfigurasi ekspor dengan [SwfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions/), termasuk pengaturan penampil serta tata letak catatan atau komentar.

## **Konversi Presentasi ke Flash**

Metode [Save](https://reference.aspose.com/slides/id/net/aspose.slides/presentation/methods/save/index) yang disediakan oleh kelas [Presentation](https://reference.aspose.com/slides/id/net/aspose.slides/presentation) dapat digunakan untuk mengonversi seluruh presentasi menjadi dokumen SWF. Anda juga dapat menyertakan komentar dalam SWF yang dihasilkan dengan menggunakan kelas [SWFOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions) dan antarmuka [INotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/inotescommentslayoutingoptions). Contoh berikut menunjukkan cara mengonversi presentasi menjadi dokumen SWF dengan menggunakan opsi yang disediakan oleh kelas SWFOptions.

```c#
// Instansiasi objek Presentation yang mewakili file presentasi
using (Presentation presentation = new Presentation("HelloWorld.pptx"))
{
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.ViewerIncluded = false;


    INotesCommentsLayoutingOptions notesOptions = swfOptions.NotesCommentsLayouting;
    notesOptions.NotesPosition = NotesPositions.BottomFull;

    // Menyimpan presentasi dan halaman catatan
    presentation.Save("SaveAsSwf_out.swf", SaveFormat.Swf, swfOptions);
    swfOptions.ViewerIncluded = true;
    presentation.Save("SaveNotes_out.swf", SaveFormat.Swf, swfOptions);
}
```

## **FAQ**

**Apakah saya dapat menyertakan slide tersembunyi dalam SWF?**

Ya. Aktifkan opsi [ShowHiddenSlides](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions/showhiddenslides/) pada [SwfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions/). Secara default, slide tersembunyi tidak diekspor.

**Bagaimana saya dapat mengontrol kompresi dan ukuran akhir SWF?**

Gunakan flag [Compressed](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions/compressed/) (diaktifkan secara default) dan sesuaikan [JpegQuality](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions/jpegquality/) untuk menyeimbangkan ukuran file dan kualitas gambar.

**Untuk apa 'ViewerIncluded' dan kapan saya harus menonaktifkannya?**

[ViewerIncluded](https://reference.aspose.com/slides/id/net/aspose.slides.export/swfoptions/viewerincluded/) menambahkan UI pemutar tersemat (kontrol navigasi, panel, pencarian). Nonaktifkan jika Anda berencana menggunakan pemutar sendiri atau memerlukan kerangka SWF bersih tanpa UI.

**Apa yang terjadi jika font sumber tidak ada pada mesin ekspor?**

Aspose.Slides akan menggantikan font yang Anda tentukan melalui [DefaultRegularFont](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/defaultregularfont/) di [SwfOptions](https://reference.aspose.com/slides/id/net/aspose.slides.export/saveoptions/) untuk menghindari fallback yang tidak diinginkan.