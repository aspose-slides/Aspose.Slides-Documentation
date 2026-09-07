---
title: Mengonversi PPT dan PPTX ke JPG di Python
linktitle: PowerPoint ke JPG
type: docs
weight: 60
url: /id/python-java/convert-powerpoint-to-jpg/
keywords:
- konversi PowerPoint
- konversi presentasi
- konversi slide
- PowerPoint ke JPG
- PPT ke JPG
- PPTX ke JPG
- simpan slide sebagai JPG
- ekspor PPT ke JPG
- ekspor PPTX ke JPG
- Python
- Java
- Aspose.Slides
description: "Mengonversi slide PowerPoint (PPT, PPTX) menjadi gambar JPG di Python melalui Java. Atur dimensi gambar kustom dan render catatan serta komentar dengan Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides for Python via Java memungkinkan Anda mengonversi presentasi PowerPoint dan OpenDocument (PPT, PPTX, dan ODP) menjadi gambar JPEG. Anda dapat mengekspor setiap slide atau slide yang dipilih untuk membuat thumbnail, membangun penampil presentasi, atau menyematkan pratinjau slide di situs web atau aplikasi.

## **Mengonversi PowerPoint PPT/PPTX ke JPG**

1. Muat presentasi dengan [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/).
2. Dapatkan slide menggunakan [getSlides](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getSlides).
3. Panggil [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan faktor skala horizontal dan vertikal untuk merender setiap slide.
4. Simpan setiap gambar yang dirender sebagai JPEG menggunakan [ImageFormat.Jpeg](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/#Jpeg), kemudian lepaskan sumber daya gambar.

{{% alert color="info" title="Catatan" %}}
Mengekspor ke JPG membuat gambar terpisah untuk setiap slide. Simpan gambar yang dirender alih-alih menyimpan presentasi langsung ke format gambar.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        slide_image = slide.getImage(1.0, 1.0)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Mengonversi PowerPoint PPT/PPTX ke JPG dengan Dimensi yang Disesuaikan**

Hitung faktor skala horizontal dan vertikal dari dimensi piksel yang diinginkan serta ukuran slide asli, lalu berikan ke [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage). Contoh berikut menargetkan gambar 1200 × 800 untuk setiap slide.

Menggunakan faktor skala yang berbeda dapat meregangkan slide. Untuk mempertahankan rasio aspeknya, gunakan faktor skala yang sama untuk kedua sumbu; lebar dan tinggi yang dihasilkan akan mengikuti proporsi slide asli.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("presentation.pptx")
try:
    desired_width = 1200
    desired_height = 800
    slide_size = presentation.getSlideSize().getSize()
    scale_x = desired_width / slide_size.getWidth()
    scale_y = desired_height / slide_size.getHeight()

    for slide in presentation.getSlides():
        slide_image = slide.getImage(scale_x, scale_y)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **Merender Komentar Saat Menyimpan Slide sebagai Gambar**

Gunakan [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/notescommentslayoutingoptions/) untuk mengonfigurasi catatan dan komentar, dan terapkan tata letaknya melalui [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions). Contoh ini menempatkan catatan di bagian bawah, memotong catatan yang tidak muat, dan menampilkan komentar di kanan dalam area selebar 200 piksel. Ia menyimpan setiap slide yang dirender sebagai gambar JPG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CommentsPositions, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    layout_options = NotesCommentsLayoutingOptions()
    layout_options.setNotesPosition(NotesPositions.BottomTruncated)
    layout_options.setCommentsPosition(CommentsPositions.Right)
    layout_options.setCommentsAreaWidth(200)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout_options)
    image_size = Dimension(740, 960)

    for slide in presentation.getSlides():
        slide_image = slide.getImage(rendering_options, image_size)
        try:
            slide_image.save(f"Slide_{slide.getSlideNumber()}.jpg", ImageFormat.Jpeg)
        finally:
            slide_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Apakah saya dapat mengonversi beberapa slide atau presentasi ke JPG?**

Ya. Contoh-contoh tersebut melakukan iterasi melalui semua slide dan menyimpan satu JPG per slide. Untuk memproses beberapa presentasi, ulangi konversi untuk setiap file masukan dan gunakan folder output terpisah atau nama file unik agar tidak menimpa gambar.

**Apakah grafik, SmartArt, tabel, dan bentuk termasuk dalam gambar?**

Objek-objek tersebut dirender sebagai bagian dari slide. Pastikan font yang digunakan oleh presentasi tersedia di lingkungan konversi untuk mengurangi perbedaan yang disebabkan oleh substitusi font.

**Bagaimana saya dapat mengurangi penggunaan memori saat mengekspor presentasi besar?**

Proses gambar satu per satu, lepaskan masing‑masing setelah disimpan, dan hindari dimensi output yang terlalu besar. Kebutuhan memori bergantung pada konten slide dan ukuran gambar.

## **Lihat Juga**

- [Konversi PowerPoint ke PNG](/slides/id/python-java/convert-powerpoint-to-png/).
- [Merender slide sebagai gambar SVG](/slides/id/python-java/render-a-slide-as-an-svg-image/).