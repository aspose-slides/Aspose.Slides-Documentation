---
title: Buat Penampil Presentasi di Python
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/python-net/presentation-viewer/
keywords:
- lihat presentasi
- penampil presentasi
- buat penampil presentasi
- lihat PPT
- lihat PPTX
- lihat ODP
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Pelajari cara membuat penampil presentasi khusus di Python menggunakan Aspose.Slides. Mudah menampilkan file PowerPoint (PPTX, PPT) dan OpenDocument (ODP) tanpa Microsoft PowerPoint atau perangkat lunak kantor lainnya."
---
## **Pendahuluan**

Aspose.Slides untuk Python digunakan untuk membuat file presentasi dengan slide. Slide-slide ini dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, pengembang terkadang perlu melihat slide sebagai gambar di penampil gambar pilihan mereka atau menggunakannya dalam penampil presentasi khusus. Dalam kasus tersebut, Aspose.Slides memungkinkan Anda mengekspor slide individu sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Hasilkan Gambar SVG dari Slide**

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Buka aliran file.
1. Simpan slide sebagai gambar SVG ke aliran file.

```py
import aspose.slides as slides

slide_index = 0

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with open("output.svg", "wb") as svg_stream:
        slide.write_as_svg(svg_stream)
```

## **Buat Gambar Miniatur Slide**

Aspose.Slides membantu Anda menghasilkan gambar miniatur slide. Untuk menghasilkan miniatur slide menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Buat gambar miniatur dari slide yang direferensikan dengan skala yang diinginkan.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

```py
import aspose.slides as slides

slide_index = 0
scale_x = 1
scale_y = scale_x

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(scale_x, scale_y) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Buat Miniatur Slide dengan Dimensi yang Ditentukan Pengguna**

Untuk membuat gambar miniatur slide dengan dimensi yang ditentukan pengguna, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Hasilkan gambar miniatur dari slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

```py
import aspose.slides as slides
import aspose.pydrawing as pydrawing

slide_index = 0
slide_size = pydrawing.Size(1200, 800)

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(slide_size) as image:
        image.save("output.jpg", slides.ImageFormat.JPEG)
```

## **Buat Miniatur Slide dengan Catatan Pembicara**

Untuk menghasilkan miniatur slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [RenderingOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/).
1. Gunakan properti `RenderingOptions.slides_layout_options` untuk mengatur posisi catatan pembicara.
1. Buat sebuah instance dari kelas [Presentasi](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/).
1. Dapatkan referensi ke slide berdasarkan indeksnya.
1. Hasilkan gambar miniatur dari slide yang direferensikan menggunakan opsi rendering.
1. Simpan gambar miniatur dalam format gambar pilihan Anda.

```py
slide_index = 0

layout_options = slides.export.NotesCommentsLayoutingOptions()
layout_options.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

rendering_options = slides.export.RenderingOptions()
rendering_options.slides_layout_options = layout_options

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[slide_index]

    with slide.get_image(rendering_options) as image:
        image.save("output.png", slides.ImageFormat.PNG)
```

## **Contoh Langsung**

Coba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

[![Penampil PowerPoint Online](online-PowerPoint-viewer.png)](https://products.aspose.app/slides/id/viewer/)

## **FAQ**

**Apakah saya dapat menyematkan penampil presentasi dalam aplikasi web ASP.NET?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai [gambar](/slides/id/python-net/convert-powerpoint-to-png/) atau [HTML](/slides/id/python-net/convert-powerpoint-to-html/) dan menampilkannya di browser. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil .NET khusus?**

Pendekatan yang disarankan adalah merender setiap slide sebagai [gambar](/slides/id/python-net/convert-powerpoint-to-png/) (misalnya PNG atau SVG) atau mengkonversinya ke [HTML](/slides/id/python-net/convert-powerpoint-to-html/) menggunakan Aspose.Slides, kemudian menampilkan output di dalam picture box (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk deck yang besar, pertimbangkan lazy-loading atau rendering slide sesuai permintaan. Ini berarti menghasilkan konten slide hanya ketika pengguna menavigasinya, sehingga mengurangi penggunaan memori dan waktu pemuatan.