---
title: Konversi Presentasi PowerPoint dalam Mode Handout Menggunakan Python
linktitle: Mode Handout
type: docs
weight: 150
url: /id/python-java/convert-powerpoint-in-handout-mode/
keywords:
- konversi PowerPoint
- konversi presentasi
- mode handout
- handout
- PPT
- PPTX
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Konversi presentasi PowerPoint menjadi handout dalam Python via Java. Atur beberapa slide per halaman dan ekspor ke PDF dengan Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides for Python via Java memungkinkan Anda mengekspor presentasi dalam mode handout, mengatur beberapa slide pada satu halaman. Hal ini berguna untuk mencetak materi presentasi untuk konferensi, seminar, dan acara serupa.

Konfigurasikan tata letak melalui metode [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions). Tata letak handout didukung oleh [PdfOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/), [RenderingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/), [HtmlOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/htmloptions/), dan [TiffOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffoptions/). Gunakan objek [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/handoutlayoutingoptions/) untuk menentukan pengaturan tata letak dan tampilan.

## **Ekspor Mode Handout**

Untuk mengekspor presentasi dalam mode handout, buat sebuah instance [HandoutLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/handoutlayoutingoptions/) dan tetapkan ke opsi ekspor target menggunakan [setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions).

Contoh berikut memuat `sample.pptx` dan mengekspornya ke PDF dengan empat slide per halaman dalam urutan horizontal. Contoh ini menyertakan nomor slide dan bingkai di sekitar slide, serta mengecualikan komentar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

# Muat sebuah presentasi.
presentation = Presentation("sample.pptx")
try:
    # Konfigurasikan tata letak handout.
    slides_layout_options = HandoutLayoutingOptions()
    slides_layout_options.setHandout(HandoutType.Handouts4Horizontal)
    slides_layout_options.setPrintSlideNumbers(True)
    slides_layout_options.setPrintFrameSlide(True)
    slides_layout_options.setPrintComments(False)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(slides_layout_options)

    # Ekspor presentasi ke PDF dengan tata letak yang dipilih.
    presentation.save("output.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Peringatan" %}}
Pengaturan tata letak handout berlaku untuk format output yang didukung, seperti PDF, HTML, TIFF, dan gambar yang dirender. Mereka tidak mengubah urutan slide dalam presentasi sumber.
{{% /alert %}}

## **FAQ**

**Berapa jumlah maksimum thumbnail slide per halaman dalam mode handout?**

Aspose.Slides mendukung hingga sembilan thumbnail per halaman. Preset [HandoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/handouttype/) menyediakan satu, dua, tiga, empat, enam, atau sembilan slide per halaman. Preset empat, enam, dan sembilan slide menawarkan urutan horizontal dan vertikal.

**Apakah saya dapat menentukan kisi khusus, seperti lima atau delapan slide per halaman?**

Tidak. Jumlah dan urutan thumbnail dikendalikan oleh nilai [HandoutType](https://reference.aspose.com/slides/id/python-java/aspose.slides/handouttype/) yang telah ditentukan sebelumnya. Kisi sembarangan tidak didukung oleh pengaturan tata letak handout ini.

**Apakah saya dapat menyertakan slide tersembunyi dalam output handout?**

Ya. Aktifkan slide tersembunyi dalam pengaturan ekspor untuk format target. Untuk PDF, panggil [PdfOptions.setShowHiddenSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/#setShowHiddenSlides) dengan `True` sebelum menyimpan presentasi.