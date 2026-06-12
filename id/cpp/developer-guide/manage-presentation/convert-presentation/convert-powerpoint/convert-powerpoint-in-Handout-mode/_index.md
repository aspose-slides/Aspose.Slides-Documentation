---
title: Konversi Presentasi PowerPoint ke Mode Handout Menggunakan C++
linktitle: Mode Handout
type: docs
weight: 150
url: /id/cpp/convert-powerpoint-in-Handout-mode/
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
description: "Konversi presentasi menjadi handout dengan C++. Atur jumlah slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar menggunakan Aspose.Slides, lengkap dengan contoh kode. Coba secara gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk pencetakan dalam mode Handout. Mode ini memungkinkan Anda mengatur bagaimana beberapa slide ditampilkan pada satu halaman, sehingga berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan menetapkan metode `set_SlidesLayoutOptions` pada antarmuka [IPdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ipdfoptions/), [IRenderingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/irenderingoptions/), [IHtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/ihtmloptions/), dan [ITiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/itiffoptions/) .

## **Ekspor Mode Handout**

Untuk mengatur mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handoutlayoutingoptions/) , yang menentukan berapa banyak slide yang ditempatkan pada satu halaman serta parameter tampilan lainnya.

```cpp
// Muat presentasi.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Set the export options.
auto slidesLayoutOptions = MakeObject<HandoutLayoutingOptions>();
slidesLayoutOptions->set_Handout(HandoutType::Handouts4Horizontal);  // 4 slide pada satu halaman secara horizontal
slidesLayoutOptions->set_PrintSlideNumbers(true);                    // cetak nomor slide
slidesLayoutOptions->set_PrintFrameSlide(true);                      // cetak bingkai di sekitar slide
slidesLayoutOptions->set_PrintComments(false);                       // tanpa komentar

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(slidesLayoutOptions);

// Export the presentation to PDF with the chosen layout.
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="warning" %}} 
Perlu diingat bahwa metode `set_SlidesLayoutOptions` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar. 
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [presets](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat menentukan grid khusus, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikontrol secara ketat oleh enumerasi [HandoutType](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/handouttype/) ; tata letak arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Gunakan metode `set_ShowHiddenSlides` pada pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/cpp/aspose.slides.export/tiffoptions/).