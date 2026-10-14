---
title: Konversi Slide PowerPoint ke PNG dalam Python
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/python-net/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint ke PNG
- konversi presentasi ke PNG
- konversi slide ke PNG
- konversi PPT ke PNG
- konversi PPTX ke PNG
- konversi ODP ke PNG
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- ODP ke PNG
- Python
- Aspose.Slides
description: "Konversi presentasi PowerPoint dan OpenDocument ke gambar PNG berkualitas tinggi dengan cepat menggunakan Aspose.Slides untuk Python via .NET, memastikan hasil yang tepat dan otomatis."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk Python via .NET. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender tiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah ini menunjukkan cara merender dengan skala default, meningkatkan skala, menentukan dimensi output dalam piksel, dan memilih gaya rendering gradien.

## **Konversi PowerPoint ke PNG**

Muat sebuah presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) dan akses slide‑nya melalui koleksi [slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slides/). Contoh ini merender setiap slide dengan [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) tanpa parameter untuk membuat thumbnail. Kemudian memanggil [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/) dengan [ImageFormat.PNG](https://reference.aspose.com/slides/python-net/aspose.slides/imageformat/) untuk menyimpan tiap slide yang telah dirender sebagai gambar PNG.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert color="info" title="Note" %}}
Overload [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) tanpa parameter merender pada skala 0.2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail berukuran 144 × 108 piksel. Untuk mengontrol dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit seperti yang ditunjukkan di bawah.
{{% /alert %}}

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) untuk mengontrol dimensi yang dirender. Pada contoh ini, kedua faktor adalah 2, sehingga slide berukuran 720 × 540 poin menghasilkan gambar 1440 × 1080 piksel. Faktor skala yang sama mempertahankan rasio aspek slide. Setiap gambar disimpan dalam format PNG dengan [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/).

```python
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/) alih‑alih faktor skala. Contoh ini merender setiap slide pada 960 × 720 piksel dan menyimpan hasilnya dengan [IImage.save](https://reference.aspose.com/slides/python-net/aspose.slides/iimage/save/). Pilih dimensi yang sesuai dengan rasio aspek slide untuk menghindari gambar menjadi terdistorsi.

```python
import aspose.slides as slides

image_size = slides.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(image_size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Pilih Gaya Rendering Gradien**

Misalkan sebuah slide berisi isian gradien, tetapi transisi pada PNG yang diekspor tampak lebih terang atau berbeda dari yang Anda lihat di PowerPoint. Anda dapat menggunakan properti [gradient_style](https://reference.aspose.com/slides/python-net/aspose.slides.export/saveoptions/gradient_style/) dari [RenderingOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertamanya berisi dua gradien linear: sian ke oranye di bagian atas dan biru ke kuning di bagian bawah. Setiap gradien memiliki dua titik berhenti, pada 0% dan 100%.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [Slide.get_image](https://reference.aspose.com/slides/python-net/aspose.slides/slide/get_image/).

```python
import aspose.slides as slides

with slides.Presentation("gradient-styles.pptx") as presentation:
    slide = presentation.slides[0]

    gradient_styles = [slides.GradientStyle.DEFAULT, slides.GradientStyle.POWER_POINT_UI]
    for style in gradient_styles:
        options = slides.export.RenderingOptions()
        options.gradient_style = style

        with slide.get_image(options, 1.0, 1.0) as image:
            image.save(f"gradient-{style.name}.png", slides.ImageFormat.PNG)
```

| Default | PowerPointUI |
| --- | --- |
| ![Gradien sian-ke-oranye dan biru-ke-kuning dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Dalam contoh ini, `DEFAULT` menghasilkan warna antara yang lebih terang, sedangkan `POWER_POINT_UI` menghasilkan warna antara yang lebih gelap. Perbedaannya tergantung pada warna dan titik berhenti dalam gradien.

Pilih `DEFAULT` ketika output standar Aspose.Slides sudah memenuhi kebutuhan Anda. Coba `POWER_POINT_UI` ketika prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang Anda inginkan; tidak ada mode yang secara universal lebih baik.

## **Tanya Jawab**

**Bagaimana saya dapat mengekspor bentuk tertentu, seperti diagram atau gambar, daripada seluruh slide?**

Aspose.Slides mendukung [membuat thumbnail untuk bentuk individual](/slides/id/python-net/create-shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya. Gunakan satu instance presentasi terpisah untuk setiap thread atau proses; [jangan bagikan satu instance di antara thread](/slides/id/python-net/multithreading/).

**Apa batasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lain](/slides/id/python-net/licensing/) sampai lisensi diterapkan.