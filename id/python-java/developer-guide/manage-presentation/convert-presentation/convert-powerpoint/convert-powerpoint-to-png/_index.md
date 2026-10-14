---
title: Mengonversi Slide PowerPoint ke PNG dalam Python
linktitle: PowerPoint ke PNG
type: docs
weight: 30
url: /id/python-java/convert-powerpoint-to-png/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- konversi PPT
- konversi PPTX
- PowerPoint ke PNG
- presentasi ke PNG
- slide ke PNG
- PPT ke PNG
- PPTX ke PNG
- simpan PPT sebagai PNG
- simpan PPTX sebagai PNG
- ekspor PPT ke PNG
- ekspor PPTX ke PNG
- Python
- Java
- Aspose.Slides
description: "Mengonversi slide PowerPoint menjadi gambar PNG dalam Python melalui Java. Mengekspor presentasi PPT, PPTX, dan ODP dengan skala khusus atau dimensi gambar yang tepat."
---
## **Gambaran Umum**

Artikel ini menjelaskan cara mengonversi slide presentasi menjadi gambar PNG menggunakan Aspose.Slides untuk Python melalui Java. Anda dapat memuat presentasi dalam format seperti PPT, PPTX, dan ODP, merender setiap slide, dan menyimpannya sebagai gambar PNG terpisah.

Contoh di bawah ini menunjukkan proses rendering dengan skala default, meningkatkan skala, menentukan dimensi output dalam piksel, dan memilih gaya rendering gradien.

## **Konversi PowerPoint ke PNG**

Muat presentasi dengan kelas [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) dan akses slide-nya melalui koleksi [Presentation.getSlides](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getSlides). Contoh tersebut merender setiap slide dengan [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) tanpa parameter untuk membuat thumbnail. Kemudian dipanggil [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) dengan [ImageFormat.Png](https://reference.aspose.com/slides/python-java/aspose.slides/imageformat/#Png) untuk menyimpan setiap slide yang dirender sebagai gambar PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage()
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Overload [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) tanpa parameter merender dengan skala 0.2. Misalnya, slide berukuran 720 × 540 poin menghasilkan thumbnail berukuran 144 × 108 piksel. Untuk mengontrol dimensi output, gunakan overload dengan faktor skala atau ukuran gambar eksplisit yang ditunjukkan di bawah.
{{% /alert %}}

## **Konversi PowerPoint ke PNG dengan Dimensi Kustom**

Berikan faktor skala horizontal dan vertikal ke [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) untuk mengontrol dimensi yang dirender. Pada contoh ini, kedua faktor tersebut adalah 2, sehingga slide berukuran 720 × 540 poin menghasilkan gambar berukuran 1440 × 1080 piksel. Faktor skala yang sama mempertahankan rasio aspek slide. Setiap gambar yang dirender disimpan dalam format PNG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    scale_x = 2.0
    scale_y = scale_x

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(scale_x, scale_y)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Konversi PowerPoint ke PNG dengan Ukuran Kustom**

Untuk menentukan dimensi output dalam piksel, berikan ukuran ke [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage) alih-alih faktor skala. Contoh ini merender setiap slide pada 960 × 720 piksel dan menyimpan hasilnya dalam format PNG. Pilih dimensi yang sesuai dengan rasio aspek slide untuk menghindari pemanjangan gambar.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    image_size = Dimension(960, 720)

    for index, slide in enumerate(presentation.getSlides()):
        image = slide.getImage(image_size)
        try:
            image.save(f"slide_{index}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

## **Pilih Gaya Rendering Gradien**

Misalkan sebuah slide berisi isian gradien, tetapi transisi pada PNG yang diekspor terlihat lebih terang atau berbeda dari yang Anda lihat di PowerPoint. Anda dapat menggunakan metode [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/python-java/aspose.slides/saveoptions/#setGradientStyle) yang diwarisi oleh [RenderingOptions](https://reference.aspose.com/slides/python-java/aspose.slides/renderingoptions/) untuk memilih cara gradien dirender.

Unduh [gradient-styles.pptx](gradient-styles.pptx) dan letakkan di direktori kerja aplikasi. Slide pertama berisi dua gradien linear: sian ke oranye di bagian atas dan biru ke kuning di bagian bawah. Setiap gradien memiliki dua titik henti, pada 0% dan 100%.

Contoh berikut memuat presentasi ini dan merender slide pertama yang sama dalam kedua mode dengan [Slide.getImage](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getImage).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GradientStyle, ImageFormat, Presentation, RenderingOptions

presentation = Presentation("gradient-styles.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    gradient_styles = (GradientStyle.Default, GradientStyle.PowerPointUI)
    for style in gradient_styles:
        options = RenderingOptions()
        options.setGradientStyle(style)

        style_name = "Default" if style == GradientStyle.Default else "PowerPointUI"
        image = slide.getImage(options, 1.0, 1.0)
        try:
            image.save(f"gradient-{style_name}.png", ImageFormat.Png)
        finally:
            image.dispose()
finally:
    presentation.dispose()
```

Gambar di bawah menunjukkan output dari slide yang sama, dengan kedua gradien di setiap gambar:

| Default | PowerPointUI |
| --- | --- |
| ![Gradien cyan-ke-oranye dan biru-ke-kuning yang dirender dengan Default](gradient-Default.png) | ![Gradien yang sama dirender dengan PowerPointUI](gradient-PowerPointUI.png) |

Pada contoh ini, `Default` menghasilkan warna antara yang lebih terang, sedangkan `PowerPointUI` menghasilkan warna antara yang lebih gelap. Perbedaannya bergantung pada warna dan titik henti dalam gradien.

Pilih `Default` ketika output standar Aspose.Slides sesuai dengan kebutuhan Anda. Coba `PowerPointUI` ketika prioritas Anda adalah mencocokkan tampilan di PowerPoint. Bandingkan kedua output dengan hasil yang diinginkan; tidak ada mode yang secara universal lebih disukai.

## **FAQ**

**Bagaimana cara mengekspor bentuk tertentu, seperti diagram atau gambar, alih-alih seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individual](/slides/id/python-java/create-shape-thumbnails/), memungkinkan Anda merender sebuah bentuk sebagai gambar PNG.

**Apakah konversi paralel didukung pada server?**

Ya. Gunakan instansi presentasi terpisah untuk setiap thread atau proses; [jangan berbagi satu instansi di antara thread](/slides/id/python-java/multithreading/).

**Apa keterbatasan evaluasi saat mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan menerapkan [pembatasan lainnya](/slides/id/python-java/licensing/) sampai lisensi diterapkan.