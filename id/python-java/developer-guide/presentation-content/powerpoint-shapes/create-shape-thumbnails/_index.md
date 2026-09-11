---
title: Membuat Thumbnail Bentuk Presentasi di Python via Java
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/python-java/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dengan Aspose.Slides untuk Python via Java – dengan mudah buat dan ekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for Python via Java dapat digunakan untuk membuat file presentasi di mana setiap halaman sesuai dengan sebuah slide. Slide dapat dilihat dengan membuka file presentasi menggunakan Microsoft PowerPoint. Namun, pengembang kadang perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus tersebut, Aspose.Slides for Python via Java membantu mereka menghasilkan gambar miniatur bentuk slide.

Artikel ini menjelaskan cara menghasilkan thumbnail bentuk dengan berbagai cara:

- Membuat thumbnail bentuk di dalam slide.
- Membuat thumbnail bentuk untuk bentuk slide dengan dimensi yang ditentukan pengguna.
- Membuat thumbnail bentuk dalam batas tampilan bentuk.

## **Hasilkan Thumbnail Bentuk dari Slide**
Untuk menghasilkan thumbnail bentuk dari slide mana pun menggunakan Aspose.Slides for Python via Java, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi ke sebuah slide menggunakan ID atau indeksnya.
1. Ambil [gambar thumbnail bentuk](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) dari sebuah bentuk pada slide yang direferensikan dengan skala default.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Kode contoh ini menunjukkan cara menghasilkan thumbnail bentuk dari slide:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

# Membuat instance kelas Presentation yang mewakili file presentasi.
presentation = Presentation("Thumbnail.pptx")
try:
    # Membuat gambar skala penuh.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage()
    try:
        # Simpan gambar ke disk dalam format PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Hasilkan Thumbnail dengan Faktor Skala yang Ditentukan Pengguna**
Untuk menghasilkan thumbnail bentuk dari slide menggunakan Aspose.Slides for Python via Java, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi ke sebuah slide menggunakan ID atau indeksnya.
1. Ambil [gambar thumbnail bentuk](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) dari sebuah bentuk pada slide yang direferensikan dengan dimensi yang ditentukan pengguna.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Kode contoh ini menunjukkan cara menghasilkan thumbnail bentuk berdasarkan faktor skala yang ditentukan:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Membuat instance kelas Presentation yang mewakili file presentasi.
presentation = Presentation("Thumbnail.pptx")
try:
    # Membuat gambar dengan skala faktor 2 di kedua arah.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 2, 2)
    try:
        # Simpan gambar ke disk dalam format PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Buat Thumbnail Tampilan Bentuk Berbasis Batas**
Metode ini untuk membuat thumbnail bentuk memungkinkan pengembang menghasilkan thumbnail dalam batas tampilan bentuk. Ini mempertimbangkan semua efek bentuk. Thumbnail bentuk yang dihasilkan dibatasi oleh batas slide. Untuk menghasilkan thumbnail bentuk slide dalam batas tampilannya, lakukan hal berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
1. Dapatkan referensi ke sebuah slide menggunakan ID atau indeksnya.
1. Ambil gambar thumbnail dari sebuah bentuk pada slide yang direferensikan menggunakan batas tampilannya.
1. Simpan gambar thumbnail dalam format gambar pilihan Anda.

Kode contoh ini berdasarkan langkah‑langkah di atas:

```python
import jpile
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeThumbnailBounds

# Membuat instance kelas Presentation yang mewakili file presentasi.
presentation = Presentation("Thumbnail.pptx")
try:
    # Membuat gambar skala penuh.
    shape_image = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1)
    try:
        # Simpan gambar ke disk dalam format PNG.
        shape_image.save("output.png", ImageFormat.Png)
    finally:
        shape_image.dispose()
finally:
    presentation.dispose()
```

## **Dapatkan Batas Visual Aktual dari Sebuah Bentuk**

Properti frame dari [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/)—metode [getX](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getX), [getY](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getY), [getWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getWidth), dan [getHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getHeight)—menjelaskan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui frame tersebut atau menempati persegi panjang yang sejajar sumbu yang berbeda. Rotasi, outline, kepala panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, dan efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getVisualBounds) untuk menghitung area yang ditempati tanpa membuat gambar. Metode ini mengembalikan sebuah [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong ke slide, sehingga koordinatnya dapat menjadi negatif ketika konten melampaui asal slide.

Contoh berikut memperoleh dan membandingkan frame serta batas visual:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.awt.geom import Rectangle2D

presentation = Presentation("example.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)

    visual_bounds = shape.getVisualBounds()
    frame_bounds = Rectangle2D.Float(shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight())

    print("Frame bounds:", frame_bounds)
    print("Visual bounds:", visual_bounds)
finally:
    presentation.dispose()
```

[Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) yang sama dapat digunakan untuk menyelaraskan bentuk‑bentuk di sekitarnya ke tepi kiri, kanan, atas, atau bawah; menyediakan cukup ruang dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan grup bentuk, di mana frame yang disimpan mungkin tidak merepresentasikan hasil render penuh.

Gunakan [Shape.getVisualBounds](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getVisualBounds) ketika Anda membutuhkan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [Shape.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapethumbnailbounds/), [ShapeThumbnailBounds.Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapethumbnailbounds/#Shape) mengatur ukuran gambar dari batas bentuk, termasuk pengaturan outline, sementara [ShapeThumbnailBounds.Appearance](https://reference.aspose.com/slides/id/python-java/aspose.slides/shapethumbnailbounds/#Appearance) mengatur ukuran dari tampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, [Shape.getVisualBounds](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getVisualBounds) hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [dieksport sebagai SVG vektor](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#writeAsSvgToBytes) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas Shape dan Appearance saat merender thumbnail?**

`Shape` menggunakan geometri bentuk; `Appearance` memperhitungkan [efek visual](/slides/id/python-java/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah tetap akan dirender sebagai thumbnail?**

Bentuk yang tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan presentasi tetapi tidak mencegah pembuatan gambar bentuk.

**Apakah grup bentuk, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/python-java/aspose.slides/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/python-java/aspose.slides/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/python-java/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/python-java/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan penataan ulang teks.