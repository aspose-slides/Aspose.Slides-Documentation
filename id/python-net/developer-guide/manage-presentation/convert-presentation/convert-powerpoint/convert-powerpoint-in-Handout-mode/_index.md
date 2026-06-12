---
title: Konversi Presentasi dalam Mode Handout dengan Python
linktitle: Mode Handout
type: docs
weight: 150
url: /id/python-net/convert-powerpoint-in-Handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PowerPoint
- presentasi
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Konversi presentasi menjadi handout dengan Python. Atur slide per halaman, pertahankan catatan, ekspor ke PDF atau gambar dengan Aspose.Slides, lengkap dengan kode contoh. Coba secara gratis."
---
## **Pendahuluan**

Aspose.Slides menyediakan kemampuan untuk mengonversi presentasi ke berbagai format, termasuk membuat handout untuk pencetakan dalam mode Handout. Mode ini memungkinkan Anda mengonfigurasi bagaimana beberapa slide muncul pada satu halaman, sehingga berguna untuk konferensi, seminar, dan acara lainnya. Anda dapat mengaktifkan mode ini dengan mengatur properti `slides_layout_options` pada kelas [PdfOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/), dan [TiffOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/) .

## **Ekspor Mode Handout**

Untuk mengonfigurasi mode Handout, gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/handoutlayoutingoptions/), yang menentukan berapa banyak slide yang ditempatkan pada satu halaman serta parameter tampilan lainnya.

Di bawah ini contoh kode yang menunjukkan cara mengonversi presentasi ke PDF dalam mode Handout.

```py
# Muat presentasi.
with slides.Presentation("sample.pptx") as presentation:

    # Atur opsi ekspor.
    slides_layout_options = slides.export.HandoutLayoutingOptions()
    slides_layout_options.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL  # 4 slide pada satu halaman secara horizontal
    slides_layout_options.print_slide_numbers = True                                 # cetak nomor slide
    slides_layout_options.print_frame_slide = True                                   # cetak bingkai di sekitar slide
    slides_layout_options.print_comments = False                                     # tidak ada komentar

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = slides_layout_options

    # Ekspor presentasi ke PDF dengan tata letak yang dipilih.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

{{% alert color="warning" %}} 
Perhatikan bahwa properti `slides_layout_options` hanya tersedia untuk format output tertentu, seperti PDF, HTML, TIFF, dan saat merender sebagai gambar. 
{{% /alert %}} 

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode Handout?**

Aspose.Slides mendukung [preset](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/handouttype/) hingga 9 thumbnail per halaman dengan urutan horizontal atau vertikal: 1, 2, 3, 4 (horizontal/vertikal), 6 (horizontal/vertikal), dan 9 (horizontal/vertikal).

**Apakah saya dapat menentukan grid khusus, seperti 5 atau 8 slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikendalikan secara ketat oleh enumerasi [HandoutType](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/handouttype/); tata letak arbitrer tidak didukung.

**Apakah saya dapat menyertakan slide tersembunyi dalam output Handout?**

Ya. Aktifkan opsi `show_hidden_slides` dalam pengaturan ekspor untuk format target, seperti [PdfOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/), atau [TiffOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/).