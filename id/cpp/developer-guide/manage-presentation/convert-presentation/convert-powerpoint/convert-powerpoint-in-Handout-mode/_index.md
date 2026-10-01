---
title: Konversi Presentasi PowerPoint dalam Mode Handout Menggunakan C++
linktitle: Mode Handout
type: docs
weight: 150
url: /id/cpp/convert-powerpoint-in-handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- presentasi
- C++
- Aspose.Slides
description: "Konversi presentasi menjadi handout dalam C++. Atur jumlah slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides, dengan contoh kode. Coba gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk pencetakan dalam mode Handout. Mode ini memungkinkan Anda mengonfigurasi bagaimana beberapa slide muncul pada satu halaman, sehingga berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan memanggil metode `set_SlidesLayoutOptions` pada antarmuka [IPdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ihtmloptions/), dan [ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) .

Untuk mengatur dimensi dan orientasi halaman handout sebelum ekspor, lihat [Ukuran Halaman Catatan](/slides/id/cpp/notes-size/).

## **Ekspor Mode Handout**

Untuk mengonfigurasi mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handoutlayoutingoptions/), yang menentukan berapa banyak slide yang ditempatkan pada satu halaman dan parameter tampilan lainnya.

Di bawah ini contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```cpp
#include <DOM/Presentation.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Muat presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Atur opsi ekspor.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // cetak nomor slide
slidesLayoutOptions->set_PrintFrameSlide(true);                      // cetak bingkai di sekitar slide
slidesLayoutOptions->set_PrintComments(false);                       // tanpa komentar

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Ekspor presentasi ke PDF dengan tata letak yang dipilih.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Perlu diingat bahwa metode `set_SlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar.
{{% /alert %}} 

## **FAQ**

### Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?

Aspose.Slides mendukung [preset](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

### Bisakah saya menentukan kisi khusus, seperti 5 atau 8 slide per halaman?

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh enumerasi [HandoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handouttype/) ; tata letak arbitrer tidak didukung.

### Bisakah saya menyertakan slide tersembunyi dalam output Handout?

Ya. Gunakan metode `set_ShowHiddenSlides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/).