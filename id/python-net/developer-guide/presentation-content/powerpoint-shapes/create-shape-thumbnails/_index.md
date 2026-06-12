---
title: Buat Thumbnail Bentuk Presentasi di Python
linktitle: Thumbnail Bentuk
type: docs
weight: 70
url: /id/python-net/create-shape-thumbnails/
keywords:
- thumbnail bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Hasilkan thumbnail bentuk berkualitas tinggi dari slide PowerPoint dan OpenDocument dengan Aspose.Slides for Python via .NET - dengan mudah buat dan ekspor thumbnail presentasi."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET digunakan untuk membuat file presentasi di mana setiap halaman adalah sebuah slide. Anda dapat melihat slide‑slide ini di Microsoft PowerPoint dengan membuka file presentasi. Namun, terkadang pengembang perlu melihat gambar bentuk secara terpisah di penampil gambar. Dalam kasus tersebut, Aspose.Slides dapat menghasilkan gambar thumbnail untuk bentuk slide. Artikel ini menjelaskan cara menggunakan fitur tersebut.

## **Hasilkan Thumbnail Bentuk dari Slide**

Ketika Anda membutuhkan pratinjau suatu objek tertentu daripada seluruh slide, Anda dapat merender thumbnail untuk satu bentuk. Aspose.Slides memungkinkan Anda mengekspor bentuk apa pun ke gambar, memudahkan pembuatan pratinjau ringan, ikon, atau aset untuk pemrosesan lanjutan.

Untuk menghasilkan thumbnail dari bentuk apa pun:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan ID atau indeksnya.
1. Dapatkan referensi ke bentuk pada slide tersebut.
1. Render gambar thumbnail bentuk tersebut.
1. Simpan gambar thumbnail dalam format yang diinginkan.

Contoh di bawah menghasilkan thumbnail bentuk.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Buat gambar dengan skala default.
    with shape.get_image() as thumbnail:
        # Simpan gambar ke disk dalam format PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Hasilkan Thumbnail dengan Faktor Skala Kustom**

Bagian ini menunjukkan cara menghasilkan thumbnail bentuk dengan faktor skala yang ditentukan pengguna di Aspose.Slides. Dengan mengontrol skala, Anda dapat menyesuaikan ukuran thumbnail agar sesuai dengan pratinjau, ekspor, atau tampilan DPI tinggi.

Untuk menghasilkan thumbnail untuk bentuk apa pun pada slide:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan slide berdasarkan ID atau indeksnya.
1. Dapatkan bentuk target pada slide tersebut.
1. Render gambar thumbnail bentuk dengan skala yang ditentukan.
1. Simpan gambar thumbnail dalam format yang diinginkan.

Contoh di bawah menghasilkan thumbnail dengan faktor skala yang ditentukan pengguna.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Buat gambar dengan skala yang ditentukan.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Simpan gambar ke disk dalam format PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Hasilkan Thumbnail Menggunakan Batas Penampilan Bentuk**

Bagian ini menunjukkan cara menghasilkan thumbnail di dalam batas penampilan bentuk. Ini memperhitungkan semua efek bentuk. Thumbnail yang dihasilkan dibatasi oleh batas slide.

Untuk menghasilkan thumbnail dari bentuk slide apa pun dalam batas penampilannya:

1. Buat instance kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan slide berdasarkan ID atau indeksnya.
1. Dapatkan bentuk target pada slide tersebut.
1. Render gambar thumbnail bentuk dengan batas yang ditentukan.
1. Simpan gambar thumbnail dalam format gambar yang diinginkan.

Contoh di bawah membuat thumbnail dengan batas yang ditentukan pengguna.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Buat gambar bentuk dengan batas penampilan.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Simpan gambar ke disk dalam format PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan thumbnail bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/python-net/aspose.slides/imageformat/), dan lain‑lain. Bentuk juga dapat [dieksport sebagai SVG vektor](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas SHAPE dan APPEARANCE saat merender thumbnail?**

`SHAPE` menggunakan geometri bentuk; `APPEARANCE` memperhitungkan [efek visual](/slides/id/python-net/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai thumbnail?**

Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak menghalangi pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/)) dapat disimpan sebagai thumbnail atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas thumbnail untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/python-net/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/python-net/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perubahan tata letak teks.