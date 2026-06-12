---
title: Menyematkan Font dalam Presentasi dengan Python
linktitle: Menyematkan Font
type: docs
weight: 40
url: /id/python-net/embedded-font/
keywords:
- menambahkan font
- menyematkan font
- penyematan font
- mengambil font yang disematkan
- menambahkan font yang disematkan
- menghapus font yang disematkan
- mengompres font yang disematkan
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Menyematkan font TrueType dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET, memastikan rendering yang akurat di semua platform."
---
## **Pendahuluan**

**Menyematkan font dalam PowerPoint** memastikan presentasi Anda mempertahankan tampilan yang dimaksud di berbagai sistem. Baik menggunakan font unik untuk kreativitas maupun yang standar, menyematkan font mencegah gangguan pada teks dan tata letak.

Jika Anda menggunakan font pihak ketiga atau non-standar karena berkreasi dengan pekerjaan Anda, maka Anda memiliki alasan lebih untuk menyematkan font tersebut. Sebaliknya (tanpa font yang disematkan), teks atau angka pada slide, tata letak, gaya, dll. dapat berubah atau menjadi kotak‑kotak yang membingungkan.

Gunakan kelas [FontsManager](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/), [FontData](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontdata/), dan [Compress](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/) untuk mengelola font yang disematkan.

## **Dapatkan dan Hapus Font yang Disematkan**

Ambil atau hapus font yang disematkan dari sebuah presentasi dengan mudah menggunakan metode [get_embedded_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) dan [remove_embedded_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/remove_embedded_font/).

Kode Python berikut menunjukkan cara mengambil dan menghapus font yang disematkan dari sebuah presentasi:

```python
import aspose.slides as slides
import aspose.pydrawing as draw

# Instansiasi kelas Presentation yang mewakili file presentasi.
with slides.Presentation("EmbeddedFonts.pptx") as presentation:
    slide = presentation.slides[0]

    # Render slide yang berisi bingkai teks yang menggunakan font 'FunSized' yang disematkan.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture1_out.png", slides.ImageFormat.PNG)

    fonts_manager = presentation.fonts_manager

    # Ambil semua font yang disematkan.
    embedded_fonts = fonts_manager.get_embedded_fonts()

    # Temukan font 'Calibri'.
    font_data = list(filter(lambda data : data.font_name == "Calibri", embedded_fonts))[0]

    # Hapus font 'Calibri'.
    fonts_manager.remove_embedded_font(font_data)

    # Render slide; font 'Calibri' akan diganti dengan yang sudah ada.
    with slide.get_image(draw.Size(960, 720)) as image:
        image.save("picture2_out.png", slides.ImageFormat.PNG)

    # Simpan presentasi tanpa font 'Calibri' yang disematkan ke disk.
    presentation.save("WithoutEmbeddedFonts.ppt", slides.export.SaveFormat.PPT)
```

## **Tambahkan Font yang Disematkan**

Dengan menggunakan enum [EmbedFontCharacters](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/embedfontcharacters/) dan dua overload dari metode [add_embedded_font](https://reference.aspose.com/slides/id/python-net/aspose.slides/fontsmanager/add_embedded_font/), Anda dapat memilih aturan (penyematan) yang diinginkan untuk menyematkan font dalam sebuah presentasi. Kode Python berikut menunjukkan cara menyematkan dan menambahkan font ke sebuah presentasi:

```python
import aspose.slides as slides

# Muat sebuah presentasi.
with slides.Presentation("Fonts.pptx") as presentation:
    all_fonts = presentation.fonts_manager.get_fonts()
    embedded_fonts = presentation.fonts_manager.get_embedded_fonts()

    for font in all_fonts:
        if font not in embedded_fonts:
            presentation.fonts_manager.add_embedded_font(font, slides.export.EmbedFontCharacters.ALL)

    # Simpan presentasi ke disk.
    presentation.save("AddEmbeddedFont.pptx", slides.export.SaveFormat.PPTX)
```

## **Kompres Font yang Disematkan**

Optimalkan ukuran file dengan mengompres font yang disematkan menggunakan [compress_embedded_fonts](https://reference.aspose.com/slides/id/python-net/aspose.slides.lowcode/compress/compress_embedded_fonts/).

Contoh kode untuk kompresi:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.compress_embedded_fonts(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Bagaimana saya dapat mengetahui bahwa font tertentu dalam presentasi masih akan digantikan selama rendering meskipun sudah disematkan?**

Periksa [informasi substitusi](/slides/id/python-net/font-substitution/) di manajer font dan [aturan fallback/substitusi](/slides/id/python-net/fallback-font/): jika font tidak tersedia atau dibatasi, fallback akan digunakan.

**Apakah layak menyematkan font "sistem" seperti Arial/Calibri?**

Biasanya tidak—font tersebut hampir selalu tersedia. Namun untuk portabilitas penuh di lingkungan "tipis" (Docker, server Linux tanpa font yang terpasang sebelumnya), menyematkan font sistem dapat menghilangkan risiko substitusi yang tidak terduga.