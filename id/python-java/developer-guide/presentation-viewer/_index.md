---
title: Buat Penampil Presentasi di Python via Java
linktitle: Penampil Presentasi
type: docs
weight: 50
url: /id/python-java/presentation-viewer/
keywords:
- lihat presentasi
- penampil presentasi
- buat penampil presentasi
- lihat PPT
- lihat PPTX
- lihat ODP
- PowerPoint
- OpenDocument
- presentasi
- Python
- Java
- Aspose.Slides
description: "Buat penampil presentasi kustom di Python via Java menggunakan Aspose.Slides. Tampilkan file PowerPoint dan OpenDocument dengan mudah tanpa Microsoft PowerPoint."
---
## **Pendahuluan**

Aspose.Slides for Python via Java digunakan untuk membuat file presentasi dengan slide. Slide ini dapat dilihat dengan membuka presentasi di Microsoft PowerPoint, misalnya. Namun, terkadang pengembang perlu melihat slide sebagai gambar di penampil gambar pilihan mereka atau membuat penampil presentasi mereka sendiri. Dalam kasus seperti itu, Aspose.Slides memungkinkan Anda mengekspor slide tunggal sebagai gambar. Artikel ini menjelaskan cara melakukannya.

## **Menghasilkan Gambar SVG dari Slide**

Untuk menghasilkan gambar SVG dari slide presentasi dengan Aspose.Slides, ikuti langkah-langkah berikut:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Buka aliran byte.
1. Simpan slide sebagai gambar SVG ke aliran dan tulis ke file.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import ByteArrayOutputStream

slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Menghasilkan SVG dengan ID Bentuk Kustom**

Aspose.Slides dapat digunakan untuk menghasilkan sebuah [SVG](https://docs.fileformat.com/page-description-language/svg/) dari slide dengan ID bentuk kustom. Untuk melakukan ini, gunakan metode [SvgShape.setId](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgshape/#setId) dari [SvgShape](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgshape/). `CustomSvgShapeFormattingController` dapat digunakan untuk mengatur ID bentuk.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import ByteArrayOutputStream

class CustomSvgShapeFormattingController:
    def __init__(self, shape_start_index=0):
        self.shape_index = shape_start_index

    def formatShape(self, svg_shape, shape):
        svg_shape.setId(f"shape-{self.shape_index}")
        self.shape_index += 1


slide_index = 0

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    controller = CustomSvgShapeFormattingController()
    controller_proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(controller_proxy)

    svg_stream = ByteArrayOutputStream()
    try:
        slide.writeAsSvg(svg_stream, svg_options)
        svg_data = bytes(svg_stream.toByteArray())
        with open("output.svg", "wb") as output_file:
            output_file.write(svg_data)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Membuat Gambar Miniatur Slide**

Aspose.Slides membantu Anda menghasilkan gambar miniatur slide. Untuk menghasilkan miniatur slide menggunakan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur slide yang direferensikan dengan skala yang ditentukan.
1. Simpan gambar miniatur dalam format gambar yang diinginkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat

slide_index = 0
scale_x = 1.0
scale_y = scale_x

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(scale_x, scale_y)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Membuat Miniatur Slide dengan Dimensi yang Ditentukan Pengguna**

Untuk membuat gambar miniatur slide dengan dimensi yang ditentukan pengguna, ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur slide yang direferensikan dengan dimensi yang ditentukan.
1. Simpan gambar miniatur dalam format gambar yang diinginkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat
from java.awt import Dimension

slide_index = 0
slide_size = Dimension(1200, 800)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(slide_size)
    try:
        image.save("output.jpg", ImageFormat.Jpeg)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Membuat Miniatur Slide dengan Catatan Pembicara**

Untuk menghasilkan miniatur slide dengan catatan pembicara menggunakan Aspose.Slides, ikuti langkah-langkah di bawah ini:

1. Buat sebuah instance dari kelas [RenderingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/) .
1. Gunakan metode [RenderingOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/#setSlidesLayoutOptions) untuk mengatur posisi catatan pembicara.
1. Buat sebuah instance dari kelas [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/) .
1. Dapatkan referensi slide berdasarkan indeksnya.
1. Dapatkan gambar miniatur slide yang direferensikan dengan opsi rendering.
1. Simpan gambar miniatur dalam format gambar yang diinginkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, RenderingOptions

slide_index = 0
layouting_options = NotesCommentsLayoutingOptions()
layouting_options.setNotesPosition(NotesPositions.BottomTruncated)

rendering_options = RenderingOptions()
rendering_options.setSlidesLayoutOptions(layouting_options)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(slide_index)
    image = slide.getImage(rendering_options)
    try:
        image.save("output.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

## **Contoh Langsung**

Anda dapat mencoba aplikasi gratis [**Aspose.Slides Viewer**](https://products.aspose.app/slides/id/viewer/) untuk melihat apa yang dapat Anda implementasikan dengan API Aspose.Slides:

![Penampil PowerPoint Online](online-PowerPoint-viewer.png)

## **FAQ**

**Apakah saya dapat menyematkan penampil presentasi dalam aplikasi web?**

Ya. Anda dapat menggunakan Aspose.Slides di sisi server untuk merender slide sebagai gambar atau HTML dan menampilkannya di peramban. Fitur navigasi dan zoom dapat diimplementasikan dengan JavaScript untuk pengalaman interaktif.

**Apa cara terbaik menampilkan slide di dalam penampil kustom?**

Pendekatan yang disarankan adalah merender setiap slide sebagai gambar (mis., PNG atau SVG) atau mengonversinya ke HTML menggunakan Aspose.Slides, kemudian menampilkan hasilnya di dalam kotak gambar (untuk desktop) atau kontainer HTML (untuk web).

**Bagaimana cara menangani presentasi besar dengan banyak slide?**

Untuk dek besar, pertimbangkan lazy-loading atau rendering slide sesuai permintaan. Ini berarti menghasilkan konten slide hanya ketika pengguna menavigasinya, sehingga mengurangi penggunaan memori dan waktu pemuatan.