---
title: Mengonversi Presentasi PowerPoint ke PDF dengan Catatan dalam C++
linktitle: PowerPoint ke PDF dengan Catatan
type: docs
weight: 50
url: /id/cpp/convert-powerpoint-to-pdf-with-notes/
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
- C++
- Aspose.Slides
description: "Mengonversi format PPT dan PPTX ke PDF dengan catatan menggunakan Aspose.Slides untuk C++. Mempertahankan tata letak dan catatan pembicara untuk presentasi profesional."
---
## **Overview**

Di artikel ini, Anda akan mempelajari cara mengonversi presentasi PowerPoint ke format PDF dengan catatan pembicara menggunakan Aspose.Slides. Panduan ini akan mencakup langkah-langkah yang diperlukan dan menyediakan contoh kode untuk membantu Anda menyelesaikan tugas ini dengan efisien. Pada akhir artikel ini, Anda akan dapat:

- Menerapkan proses konversi untuk mengubah slide PowerPoint menjadi dokumen PDF sambil mempertahankan catatan pembicara.
- Menyesuaikan PDF output agar catatan pembicara termasuk dan diformat sesuai kebutuhan Anda.

## **Convert PowerPoint to PDF with Notes**

Metode `Save` dalam kelas [Presentation](https://reference.aspose.com/slides/id/cpp/aspose.slides/presentation/) dapat digunakan untuk mengonversi presentasi PPT atau PPTX ke PDF dengan catatan pembicara. Dengan Aspose.Slides, Anda cukup memuat presentasi, mengonfigurasi opsi tata letak menggunakan kelas [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/notescommentslayoutingoptions/) untuk menyertakan catatan pembicara, lalu menyimpan file sebagai PDF. Potongan kode berikut menunjukkan cara mengonversi contoh presentasi ke PDF dalam tampilan Slide Catatan.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Mengonfigurasi opsi PDF untuk merender catatan pembicara.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // Merender catatan pembicara di bawah slide.
    
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Menyimpan presentasi ke PDF dengan catatan pembicara.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
```

{{% alert color="info" %}} 
Anda mungkin ingin melihat Aspose [Online PowerPoint to PDF Converter](https://products.aspose.app/slides/id/conversion). 
{{% /alert %}}