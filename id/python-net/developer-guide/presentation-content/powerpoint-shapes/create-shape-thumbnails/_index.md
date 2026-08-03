---
title: Membuat Gambar Miniatur Bentuk Presentasi di Python
linktitle: Gambar Miniatur Bentuk
type: docs
weight: 70
url: /id/python-net/create-shape-thumbnails/
keywords:
- gambar miniatur bentuk
- gambar bentuk
- render bentuk
- rendering bentuk
- batas visual
- batas bentuk
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Hasilkan gambar miniatur bentuk berkualitas tinggi dari slide PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET – dengan mudah membuat dan mengekspor gambar miniatur presentasi."
---
## **Pendahuluan**

Aspose.Slides for Python via .NET digunakan untuk membuat file presentasi di mana setiap halaman adalah sebuah slide. Anda dapat melihat slide ini di Microsoft PowerPoint dengan membuka file presentasi. Namun, pengembang kadang perlu melihat gambar bentuk secara terpisah dalam penampil gambar. Dalam kasus seperti itu, Aspose.Slides dapat menghasilkan gambar miniatur untuk bentuk slide. Artikel ini menjelaskan cara menggunakan fitur ini.

## **Hasilkan Gambar Miniatur Bentuk dari Slide**

Ketika Anda membutuhkan pratinjau objek tertentu daripada seluruh slide, Anda dapat merender gambar miniatur untuk sebuah bentuk individual. Aspose.Slides memungkinkan Anda mengekspor bentuk apa pun ke gambar, memudahkan pembuatan pratinjau ringan, ikon, atau aset untuk pemrosesan selanjutnya.

Untuk menghasilkan gambar miniatur dari bentuk apa pun:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan ID atau indeksnya.
1. Dapatkan referensi ke bentuk pada slide tersebut.
1. Render gambar miniatur bentuk.
1. Simpan gambar miniatur dalam format yang diinginkan.

Contoh di bawah menghasilkan gambar miniatur bentuk.

```py
import aspose.slides as slides

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Membuat gambar dengan skala default.
    with shape.get_image() as thumbnail:
        # Menyimpan gambar ke disk dalam format PNG.
        thumbnail.save("shape_thumbnail.png", slides.ImageFormat.PNG)
```

## **Hasilkan Gambar Miniatur dengan Faktor Skala Kustom**

Bagian ini menunjukkan cara menghasilkan gambar miniatur bentuk dengan faktor skala yang ditentukan pengguna di Aspose.Slides. Dengan mengontrol skala, Anda dapat menyesuaikan ukuran miniatur agar sesuai dengan pratinjau, ekspor, atau tampilan DPI tinggi.

Untuk menghasilkan gambar miniatur dari bentuk apa pun pada slide:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan slide berdasarkan ID atau indeksnya.
1. Dapatkan bentuk target pada slide tersebut.
1. Render gambar miniatur bentuk dengan skala yang ditentukan.
1. Simpan gambar miniatur dalam format yang diinginkan.

Contoh di bawah menghasilkan gambar miniatur dengan faktor skala yang ditentukan pengguna.

```py
import aspose.slides as slides

scale_x = 2.0
scale_y = scale_x

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    
    # Membuat gambar dengan skala yang ditentukan.
    with shape.get_image(slides.ShapeThumbnailBounds.SHAPE, scale_x, scale_y) as thumbnail:
        # Menyimpan gambar ke disk dalam format PNG.
        thumbnail.save("scaling_factor.png", slides.ImageFormat.PNG)
```

## **Hasilkan Gambar Miniatur Menggunakan Batas Penampilan Bentuk**

Bagian ini menunjukkan cara menghasilkan gambar miniatur dalam batas penampilan sebuah bentuk. Ini memperhitungkan semua efek bentuk. Gambar miniatur yang dihasilkan dibatasi oleh batas slide.

Untuk menghasilkan gambar miniatur dari bentuk slide apa pun dalam batas penampilannya:

1. Buat instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan slide berdasarkan ID atau indeksnya.
1. Dapatkan bentuk target pada slide tersebut.
1. Render gambar miniatur bentuk dengan batas yang ditentukan.
1. Simpan gambar miniatur dalam format gambar yang diinginkan.

Contoh di bawah membuat gambar miniatur dengan batas yang ditentukan pengguna.

```py
import aspose.slides as slides

image_bounds = slides.ShapeThumbnailBounds.APPEARANCE

# Membuat instance kelas Presentation untuk membuka file presentasi.
with slides.Presentation("hello_world.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    # Membuat gambar bentuk dengan batas penampilan.
    with shape.get_image(image_bounds, 1.0, 1.0) as thumbnail:
        # Menyimpan gambar ke disk dalam format PNG.
        thumbnail.save("apperance_bounds.png", slides.ImageFormat.PNG)
```

## **Dapatkan Batas Visual Aktual Sebuah Bentuk**

Properti kerangka dari sebuah [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/)—`Shape.x`, `Shape.y`, `Shape.width`, dan `Shape.height`—menjelaskan persegi panjang yang disimpan dalam model presentasi. Konten yang sebenarnya dirender dapat melampaui kerangka tersebut atau menempati persegi panjang beraksis sejajar yang berbeda. Rotasi, garis tepi, ujung panah, tata letak teks dan overflow, geometri SmartArt yang dihasilkan, serta efek rendering lainnya dapat mengubah area yang ditempati.

Gunakan [Shape.get_visual_bounds](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_visual_bounds/) untuk menghitung area yang ditempati tanpa membuat gambar. Metode ini mengembalikan persegi panjang floating-point dalam koordinat slide. Persegi panjang yang dikembalikan tidak dipotong ke slide, sehingga koordinatnya dapat menjadi negatif ketika konten melampaui asal slide.

Contoh berikut mendapatkan dan membandingkan kerangka dan batas visual:

```py
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("example.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]

    visual_bounds = shape.get_visual_bounds()

    frame_values = (shape.x, shape.y, shape.width, shape.height)
    visual_values = (visual_bounds.x, visual_bounds.y, visual_bounds.width, visual_bounds.height)

    print(f"Frame bounds (x, y, width, height): {frame_values}")
    print(f"Visual bounds (x, y, width, height): {visual_values}")
```

Persegi panjang yang sama dapat digunakan untuk menyelaraskan bentuk di sekitarnya ke tepi `left`, `right`, `top`, atau `bottom`; menyediakan ruang cukup dalam tata letak yang dihasilkan; atau mendeteksi konten di luar wilayah yang diizinkan. Batas visual sangat berguna untuk SmartArt, kotak teks, panah, gambar, bentuk yang diputar, dan bentuk grup, di mana kerangka yang disimpan mungkin tidak mewakili hasil render lengkap.

Gunakan [Shape.get_visual_bounds](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_visual_bounds/) ketika Anda memerlukan koordinat untuk tata letak atau validasi dan tidak memerlukan bitmap. Gunakan [Shape.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/) ketika Anda perlu merender bentuk. Dengan [ShapeThumbnailBounds](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds.SHAPE` mengukur gambar dari batas bentuk, termasuk pengaturan outline, sementara `ShapeThumbnailBounds.APPEARANCE` mengukurnya dari penampilan bentuk dan membatasi hasil ke batas slide. Sebaliknya, `Shape.get_visual_bounds` hanya mengembalikan persegi panjang yang dihitung dan tidak memotongnya ke slide.

## **FAQ**

**Format gambar apa yang dapat digunakan saat menyimpan gambar miniatur bentuk?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/id/python-net/aspose.slides/imageformat/), dan lainnya. Bentuk juga dapat [diekspor sebagai SVG vektor](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/) dengan menyimpan konten bentuk sebagai SVG.

**Apa perbedaan antara batas SHAPE dan APPEARANCE saat merender gambar miniatur?**

`SHAPE` menggunakan geometri bentuk; `APPEARANCE` memperhitungkan [efek visual](/slides/id/python-net/shape-effect/) (bayangan, cahaya, dll).

**Apa yang terjadi jika sebuah bentuk ditandai sebagai tersembunyi? Apakah masih akan dirender sebagai gambar miniatur?**

Bentuk tersembunyi tetap menjadi bagian dari model dan dapat dirender; flag tersembunyi memengaruhi tampilan slideshow tetapi tidak menghalangi pembuatan gambar bentuk.

**Apakah bentuk grup, diagram, SmartArt, dan objek kompleks lainnya didukung?**

Ya. Objek apa pun yang direpresentasikan sebagai [Shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/) (termasuk [GroupShape](https://reference.aspose.com/slides/id/python-net/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/id/python-net/aspose.slides.charts/chart/), dan [SmartArt](https://reference.aspose.com/slides/id/python-net/aspose.slides.smartart/smartart/)) dapat disimpan sebagai gambar miniatur atau sebagai SVG.

**Apakah font yang diinstal pada sistem memengaruhi kualitas gambar miniatur untuk bentuk teks?**

Ya. Anda harus [menyediakan font yang diperlukan](/slides/id/python-net/custom-font/) (atau [mengonfigurasi substitusi font](/slides/id/python-net/font-substitution/)) untuk menghindari fallback yang tidak diinginkan dan perubahan tata letak teks.