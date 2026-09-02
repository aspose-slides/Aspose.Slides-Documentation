---
title: Render Slide Presentasi sebagai Gambar SVG di Python
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/python-net/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ke SVG
- presentasi ke SVG
- slide ke SVG
- PPT ke SVG
- PPTX ke SVG
- opsi ekspor SVG
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di Python dan kontrol font, teks, serta gambar dengan Aspose.Slides."
---
## **Overview**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja dengan baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, serta pemrosesan otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol cara teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/) ketika SVG yang diekspor harus ringkas, konsisten di semua peramban, atau siap untuk penggunaan interaktif.

## **Export a Slide as SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/), pilih satu slide, dan tulis ke aliran. Contoh berikut mengekspor setiap slide dalam sebuah presentasi menjadi file SVG terpisah.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        with open("slide-{}.svg".format(slide.slide_number), "wb") as svg_stream:
            slide.write_as_svg(svg_stream)
```

Nama file menggunakan [Slide.slide_number](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/slide_number/) bukan indeks perulangan. Anda juga dapat mengekspor bentuk individu dengan [Shape.write_as_svg](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/write_as_svg/) ketika penampil slide atau halaman web hanya membutuhkan bentuk tersebut.

## **Configure SVG Output**

[SVGOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/) mengontrol proses rendering SVG. Untuk bingkai teks, [SVGOptions.use_frame_size](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/use_frame_size/) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.use_frame_rotation](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/use_frame_rotation/) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.disable_font_ligatures](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/disable_font_ligatures/) ke `True` ketika teks harus dirender tanpa ligatur.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.disable_font_ligatures = True
    svg_options.use_frame_size = True
    svg_options.use_frame_rotation = False

    with open("slide-with-custom-options.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **Control Text and Fonts**

### **Vectorize All Text**

Setel [SVGOptions.vectorize_text](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/vectorize_text/) ke `True` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di berbagai peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.vectorize_text = True

    with open("slide-with-vectorized-text.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

### **Choose How External Fonts Are Handled**

[SVGOptions.external_fonts_handling](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/external_fonts_handling/) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `ADD_LINKS_TO_FONT_FILES` untuk merujuk pada file font terpisah, `EMBED` untuk menyertakan data font dalam SVG, atau `VECTORIZE` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    linked_fonts_options = slides.export.SVGOptions()
    linked_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.ADD_LINKS_TO_FONT_FILES

    with open("slide-with-font-links.svg", "wb") as linked_fonts_stream:
        presentation.slides[0].write_as_svg(linked_fonts_stream, linked_fonts_options)

    embedded_fonts_options = slides.export.SVGOptions()
    embedded_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.EMBED

    with open("slide-with-embedded-fonts.svg", "wb") as embedded_fonts_stream:
        presentation.slides[0].write_as_svg(embedded_fonts_stream, embedded_fonts_options)

    vectorized_external_fonts_options = slides.export.SVGOptions()
    vectorized_external_fonts_options.external_fonts_handling = slides.export.SvgExternalFontsHandling.VECTORIZE

    with open("slide-with-vectorized-external-fonts.svg", "wb") as vectorized_external_fonts_stream:
        presentation.slides[0].write_as_svg(vectorized_external_fonts_stream, vectorized_external_fonts_options)
```

## **Reduce Embedded Image Size**

Gunakan [SVGOptions.pictures_compression](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/pictures_compression/) untuk mengurangi resolusi gambar yang disematkan, [SVGOptions.delete_pictures_cropped_areas](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/delete_pictures_cropped_areas/) untuk menghilangkan area sumber yang terpotong, dan [SVGOptions.jpeg_quality](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/jpeg_quality/) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.pictures_compression = slides.export.PicturesCompression.DPI150
    svg_options.delete_pictures_cropped_areas = True
    svg_options.jpeg_quality = 80

    with open("compressed-slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

## **FAQ**

**When should I use [SVGOptions.vectorize_text](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/vectorize_text/) instead of [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgexternalfontshandling/)?**

Gunakan [SVGOptions.vectorize_text](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/vectorize_text/) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.VECTORIZE](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgexternalfontshandling/) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**What is the best way to make an SVG smaller?**

Mulailah dengan mengompresi gambar yang disematkan, menghapus area gambar yang terpotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena penurunan resolusi gambar, penurunan kualitas JPEG, dan teks yang di‑vector‑kan masing‑masing memiliki kompromi kualitas dan ukuran yang berbeda.