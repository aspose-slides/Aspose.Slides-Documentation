---
title: Konversi Slide PowerPoint ke PNG dengan Python
linktitle: Slide ke PNG
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

Aspose.Slides for Python via .NET mempermudah konversi presentasi PowerPoint ke PNG. Anda memuat sebuah presentasi, mengiterasi slide‑slide‑nya, merender masing‑masing menjadi gambar raster, dan menyimpan hasilnya sebagai file PNG. Ini ideal untuk membuat pratinjau slide, menyematkan slide dalam halaman web, atau menghasilkan aset statis untuk proses selanjutnya.

## **Konversi Slide ke PNG**

Bagian ini menunjukkan contoh paling sederhana untuk mengonversi presentasi PowerPoint menjadi gambar PNG menggunakan Aspose.Slides for Python via .NET.

Ikuti langkah‑langkah berikut:

1. Instansiasi kelas [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan sebuah slide dari koleksi `Presentation.slides` (lihat kelas [Slide](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/)).
1. Gunakan metode `Slide.get_image` untuk menghasilkan thumbnail slide.
1. Gunakan metode `Presentation.save` untuk menyimpan thumbnail slide dalam format PNG.

Kode Python berikut menunjukkan cara mengonversi presentasi PowerPoint ke PNG:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image() as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konversi Slide ke PNG dengan Dimensi Kustom**

Untuk mengekspor slide ke PNG dengan skala kustom, panggil `Slide.get_image` dengan faktor skala horisontal dan vertikal. Pengganda ini mengubah ukuran output relatif terhadap dimensi asli slide—misalnya, `2.0` menggandakan lebar dan tinggi. Gunakan nilai yang sama untuk `scale_x` dan `scale_y` untuk memelihara rasio aspek.

Kode Python berikut mendemonstrasikan operasi yang dijelaskan:

```py
import aspose.slides as slides

scale_x = 2
scale_y = scale_x

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(scale_x, scale_y) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

## **Konversi Slide ke PNG dengan Ukuran Kustom**

Jika Anda ingin menghasilkan file PNG dengan ukuran tertentu, berikan nilai `width` dan `height` yang diinginkan. Kode di bawah ini menunjukkan cara mengonversi PowerPoint ke PNG sambil menentukan ukuran gambar:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

size = drawing.Size(960, 720)

with slides.Presentation("presentation.pptx") as presentation:
    for index, slide in enumerate(presentation.slides):
        with slide.get_image(size) as image:
            image.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

{{% alert title="Tip" color="primary" %}}
Anda mungkin ingin mencoba **konverter PowerPoint-ke-PNG** gratis dari Aspose—[PPTX ke PNG](https://products.aspose.app/slides/id/conversion/pptx-to-png) dan [PPT ke PNG](https://products.aspose.app/slides/id/conversion/ppt-to-png). Mereka menyediakan implementasi langsung dari proses yang dijelaskan di halaman ini.
{{% /alert %}}

## **FAQ**

**Bagaimana saya dapat mengekspor hanya bentuk tertentu (misalnya, grafik atau gambar) bukan seluruh slide?**

Aspose.Slides mendukung [pembuatan thumbnail untuk bentuk individual](/slides/id/python-net/create-shape-thumbnails/); Anda dapat merender sebuah bentuk menjadi gambar PNG.

**Apakah konversi paralel didukung di server?**

Ya, tetapi [jangan bagikan](/slides/id/python-net/multithreading/) satu instance presentasi di antara thread. Gunakan instance terpisah per thread atau proses.

**Apa saja batasan versi percobaan ketika mengekspor ke PNG?**

Mode evaluasi menambahkan watermark pada gambar output dan memberlakukan [pembatasan lain](/slides/id/python-net/licensing/) hingga lisensi diterapkan.