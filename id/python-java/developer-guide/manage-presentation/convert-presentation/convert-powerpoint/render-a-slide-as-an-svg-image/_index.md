---
title: Render Slide Presentasi sebagai Gambar SVG dalam Python via Java
linktitle: Slide ke SVG
type: docs
weight: 50
url: /id/python-java/render-a-slide-as-an-svg-image/
keywords:
- PowerPoint ke SVG
- presentasi ke SVG
- slide ke SVG
- PPT ke SVG
- PPTX ke SVG
- opsi ekspor SVG
- SVG interaktif
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Ekspor slide PowerPoint sebagai gambar SVG di Python via Java dan kontrol font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang skalabel dan bekerja baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, serta pemrosesan pasca otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/), pilih sebuah slide, dan tulis ke aliran dengan [Slide.writeAsSvg](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/). Contoh-contoh memerlukan file `presentation.pptx` yang sudah ada. Setiap contoh memulai JVM bila diperlukan dan menutup aliran outputnya. Contoh berikut mengekspor setiap slide dalam presentasi ke file SVG terpisah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        output_file_name = f"slide-{slide.getSlideNumber()}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Nama file menggunakan [Slide.getSlideNumber](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getSlideNumber) bukan indeks perulangan. Anda juga dapat mengekspor sebuah shape individual dengan [Shape.writeAsSvg](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/) ketika penampil slide atau halaman web hanya membutuhkan shape tersebut.

## **Konfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/) mengontrol render SVG. Untuk frame teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setUseFrameSize) menyertakan frame teks dalam area render, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setUseFrameRotation) menentukan apakah rotasi frame diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) ke `True` ketika teks harus dirender tanpa ligatur.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setDisableFontLigatures(True)
    svg_options.setUseFrameSize(True)
    svg_options.setUseFrameRotation(False)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-custom-options.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Kontrol Teks dan Font**

### **Vektorisasi Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setVectorizeText) ke `True` untuk menuliskan semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan pada font dan membuat hasil visual lebih konsisten di semua peramban, tetapi teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setVectorizeText(True)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-vectorized-text.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

### **Pilih Cara Penanganan Font Eksternal**

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgExternalFontsHandling
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    font_modes = [
        ("slide-with-font-links.svg", SvgExternalFontsHandling.AddLinksToFontFiles),
        ("slide-with-embedded-fonts.svg", SvgExternalFontsHandling.Embed),
        ("slide-with-vectorized-external-fonts.svg", SvgExternalFontsHandling.Vectorize),
    ]
    for output_file_name, font_mode in font_modes:
        svg_options = SVGOptions()
        svg_options.setExternalFontsHandling(font_mode)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

## **Kurangi Ukuran Gambar Tersemat**

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setPicturesCompression) untuk mengurangi resolusi gambar tersemat, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setJpegQuality) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan ketepatan gambar atau data gambar yang dipertahankan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.setPicturesCompression(PicturesCompression.Dpi150)
    svg_options.setDeletePicturesCroppedAreas(True)
    svg_options.setJpegQuality(80)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("compressed-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Tetapkan ID Stabil untuk Shape dan Teks**

Gunakan kontroler format Python yang didaftarkan melalui `jpype.JProxy` untuk menetapkan nilai [SvgShape.setId](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgshape/#setId) pada shape dan nilai [SvgTSpan.setId](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgtspan/#setId) pada elemen `tspan` teks. Tetapkan proxy dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Kontroler berikut menggunakan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getOfficeInteropShapeId), yang stabil selama masa hidup shape, serta penghitung berulang untuk `tspan` teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak diubah.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions
from java.io import FileOutputStream

class StableSvgIdController:
    def __init__(self):
        self.current_shape_id = ""
        self.text_span_index = 0

    def formatShape(self, svg_shape, shape):
        self.current_shape_id = f"shape-{shape.getOfficeInteropShapeId()}"
        self.text_span_index = 0
        svg_shape.setId(self.current_shape_id)

    def formatText(self, svg_tspan, portion, text_frame):
        svg_tspan.setId(f"{self.current_shape_id}-text-{self.text_span_index}")
        self.text_span_index += 1


presentation = Presentation("presentation.pptx")
try:
    controller = StableSvgIdController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeAndTextFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("slide-with-stable-ids.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

## **Tambahkan Penangan Peristiwa SVG**

Dalam kontroler format Python, panggil [SvgShape.setEventHandler](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgshape/#setEventHandler) dengan nilai [SvgEvent](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgevent/) untuk menambahkan penangan peristiwa JavaScript ke shape yang diekspor. Daftarkan kontroler melalui `jpype.JProxy` dan tetapkan dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions, SvgEvent
from java.io import FileOutputStream

class SvgEventController:
    def formatShape(self, svg_shape, shape):
        if shape.getName() == "ActionButton":
            svg_shape.setId("action-button")
            svg_shape.setEventHandler(SvgEvent.OnClick, "handleShapeClick(event)")


presentation = Presentation("presentation.pptx")
try:
    controller = SvgEventController()
    proxy = jpype.JProxy("com.aspose.slides.ISvgShapeFormattingController", inst=controller)
    svg_options = SVGOptions()
    svg_options.setShapeFormattingController(proxy)

    slide = presentation.getSlides().get_Item(0)
    svg_stream = FileOutputStream("interactive-slide.svg")
    try:
        slide.writeAsSvg(svg_stream, svg_options)
    finally:
        svg_stream.close()
finally:
    presentation.dispose()
```

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Penetapan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setVectorizeText) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#setVectorizeText) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) ketika hanya teks yang menggunakan font eksternal yang harus dikonversi menjadi grafik.

**Apa cara terbaik untuk memperkecil ukuran SVG?**

Mulailah dengan mengompresi gambar tersemat, menghapus area gambar yang dipotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang dipivektorisasi masing-masing memiliki kompromi kualitas dan ukuran yang berbeda.

**Apakah saya dapat memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui kontroler format, lalu pilih elemen SVG yang cocok dalam alat pemrosesan lanjutan atau skrip peramban Anda.