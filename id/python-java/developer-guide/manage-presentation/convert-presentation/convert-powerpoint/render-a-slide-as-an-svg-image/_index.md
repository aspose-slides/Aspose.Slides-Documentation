---
title: Render Slide Presentasi sebagai Gambar SVG di Python melalui Java
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
description: "Ekspor slide PowerPoint sebagai gambar SVG di Python melalui Java dan kontrol font, teks, gambar, ID, serta peristiwa dengan Aspose.Slides."
---
## **Gambaran Umum**

SVG adalah format gambar berbasis XML yang dapat diskalakan dan bekerja baik untuk penerbitan web, penampil slide, alur kerja aksesibilitas, serta pemrosesan otomatis. Aspose.Slides mengekspor setiap slide ke file SVG terpisah dan memungkinkan Anda mengontrol bagaimana teks, font, gambar, dan elemen SVG ditulis.

Gunakan [SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) ketika SVG yang diekspor harus kompak, dapat diprediksi di semua peramban, atau siap untuk penggunaan interaktif.

## **Ekspor Slide sebagai SVG**

Buat sebuah [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/), pilih slide, dan tulis ke aliran dengan [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Contoh-contoh memerlukan file `presentation.pptx` yang sudah ada. Setiap contoh memulai JVM bila diperlukan dan menutup aliran keluaran. Contoh berikut mengekspor setiap slide dalam presentasi sebagai file SVG terpisah.

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

Nama file menggunakan [Slide.getSlideNumber](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getSlideNumber) bukan indeks perulangan. Anda juga dapat mengekspor bentuk individu dengan [Shape.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/shape/) ketika penampil slide atau halaman web hanya memerlukan bentuk tersebut.

## **Konfigurasi Output SVG**

[SVGOptions](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/) mengendalikan rendering SVG. Untuk bingkai teks, [SVGOptions.setUseFrameSize](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameSize) menyertakan bingkai teks dalam area rendering, dan [SVGOptions.setUseFrameRotation](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setUseFrameRotation) menentukan apakah rotasi bingkai diterapkan. Atur [SVGOptions.setDisableFontLigatures](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableFontLigatures) ke `True` ketika teks harus dirender tanpa ligatur.

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

## **Kontrol Pemotongan Akhir Garis pada Kepala Panah**

SVG 1.1 tidak memiliki pengaturan inset marker untuk menentukan di mana garis harus berhenti di bawah kepala panah. Secara bawaan, Aspose.Slides memendekkan garis yang diekspor sehingga goresannya tidak menonjol melalui marker. Panggil [SVGOptions.setDisableLineEndCropping](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDisableLineEndCropping) dengan `True` untuk menggambar goresan sampai ke titik akhir asli garis. Pengaturan ini hanya memengaruhi output SVG. Garis tetap pada posisi dan panjangnya di slide.

Contoh menggambar kepala panah segitiga dan intan pada garis dengan lebar 2 dan 10 poin. Ia mengekspor slide yang sama dua kali, hanya mengubah opsi pemotongan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadStyle, Presentation, ShapeType, SVGOptions
from java.awt import Color
from java.io import FileOutputStream

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    y = 40

    for style in [LineArrowheadStyle.Triangle, LineArrowheadStyle.Diamond]:
        for width in [2, 10]:
            line = slide.getShapes().addAutoShape(ShapeType.Line, 40, y, 200, 0)
            line_format = line.getLineFormat()
            line_format.getFillFormat().setFillType(FillType.Solid)
            line_format.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
            line_format.setWidth(width)
            line_format.setEndArrowheadStyle(style)
            y += 50

    svg_options = SVGOptions()
    for disable_cropping, output_file_name in [(False, "cropped.svg"), (True, "uncropped.svg")]:
        svg_options.setDisableLineEndCropping(disable_cropping)
        svg_stream = FileOutputStream(output_file_name)
        try:
            slide.writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Perbandingan menunjukkan kepala panah segitiga pada garis 10 poin. Dengan pemotongan diaktifkan, ujungnya tajam. Dengan pemotongan dinonaktifkan, goresan menonjol melalui sisi miring marker dan menghasilkan ujung datar.

![Enlarged 10-point triangle with a sharp tip when cropping is enabled and a flat end when cropping is disabled](line-end-cropping.png)

Pada garis lain di contoh, goresan yang menonjol kurang terlihat pada segitiga 2 poin. Intan berisi menutupi ujung goresan pada kedua lebar.

## **Kontrol Teks dan Font**

Saat mengekspor slide ke SVG, Anda dapat mengontrol apakah teks tetap sebagai teks atau diubah menjadi grafik vektor, serta bagaimana font eksternal disertakan atau dirujuk. Opsi-opsi berikut membantu Anda menyeimbangkan konsistensi visual, kemampuan pemilihan teks, dan ketergantungan font dalam SVG yang diekspor.

### **Vektorkan Semua Teks**

Atur [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) ke `True` untuk menulis semua teks slide sebagai grafik vektor. Ini menghilangkan ketergantungan font dan membuat hasil visual lebih konsisten di semua peramban, namun teks tidak lagi dapat dipilih atau dicari sebagai teks SVG.

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

[SVGOptions.setExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setExternalFontsHandling) menggunakan nilai [SvgExternalFontsHandling](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/) untuk font yang dimuat secara eksternal. Pilih `AddLinksToFontFiles` untuk merujuk file font terpisah, `Embed` untuk menyertakan data font dalam SVG, atau `Vectorize` untuk merender hanya teks yang menggunakan font eksternal sebagai grafik. Verifikasi lisensi font sebelum menyematkan font.

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

Gunakan [SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) untuk mengurangi resolusi gambar tersemat, [SVGOptions.setDeletePicturesCroppedAreas](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setDeletePicturesCroppedAreas) untuk menghilangkan area sumber yang dipotong, dan [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) untuk mengontrol kualitas enkoding JPEG. Pengaturan ini mengurangi ukuran file dengan mengorbankan kesetiaan gambar atau data gambar yang dipertahankan.

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

## **Kontrol Resolusi Rasterisasi Metafile**

[SVGOptions.setMetafileRasterizationDpi](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setMetafileRasterizationDpi) menetapkan batas resolusi terendah untuk merasterkan metafile selama ekspor SVG. Gunakan ini untuk menyeimbangkan detail dan ukuran file ketika gambar EMF atau WMF dirasterkan. Ini tidak menentukan DPI global untuk SVG atau memaksa setiap objek pada slide menjadi gambar raster.

Unduh [metafile-rasterization.pptx](metafile-rasterization.pptx), yang berisi gambar EMF dengan garis diagonal berjarak rapat. Contoh berikut mengekspor slide pertama pada tiga resolusi rasterisasi melalui [Slide.writeAsSvg](https://reference.aspose.com/slides/python-java/aspose.slides/slide/). Semua pengaturan ekspor lainnya tetap sama sehingga hasil dapat dibandingkan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PicturesCompression, Presentation, SVGOptions
from java.io import FileOutputStream

presentation = Presentation("metafile-rasterization.pptx")
try:
    for dpi in [72, 150, 300]:
        svg_options = SVGOptions()
        svg_options.setMetafileRasterizationDpi(dpi)
        svg_options.setPicturesCompression(PicturesCompression.Dpi330)
        svg_options.setJpegQuality(90)

        output_file_name = f"slide-{dpi}.svg"
        svg_stream = FileOutputStream(output_file_name)
        try:
            presentation.getSlides().get_Item(0).writeAsSvg(svg_stream, svg_options)
        finally:
            svg_stream.close()
finally:
    presentation.dispose()
```

Pada output, EMF menjadi satu PNG tersemat di setiap SVG. Pengukuran berikut untuk presentasi yang disediakan; bukan formula umum untuk mengonversi DPI ke dimensi piksel.

| Metafile rasterization DPI | Embedded PNG dimensions | SVG file size (bytes) |
| --- | --- | --- |
| 72 | 1196 × 596 | 170,221 |
| 150 | 2492 × 1242 | 423,149 |
| 300 | 4983 × 2483 | 1,027,169 |

Perbandingan di bawah memperlihatkan area yang sama dari raster tersemat pada ukuran tampilan yang diperbesar. Garis diagonal menunjukkan pikselasi yang terlihat pada 72 DPI dan tepi yang lebih halus pada resolusi lebih tinggi, sementara ukuran file SVG bertambah. Meningkatkan nilai tidak selalu memperbaiki setiap detail atau mengubah setiap gambar yang diekspor.

![Enlarged diagonal-line detail at 72, 150, and 300 DPI](metafile-rasterization-comparison.png)

[SVGOptions.setPicturesCompression](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setPicturesCompression) mengendalikan pengurangan resolusi gambar dan dapat menutupi efek perubahan resolusi rasterisasi metafile. [SVGOptions.setJpegQuality](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setJpegQuality) mengendalikan kualitas enkoding JPEG, bukan resolusi rasterisasi metafile.

## **Tetapkan ID Stabil untuk Bentuk dan Teks**

Gunakan pengendali pemformatan Python yang terdaftar melalui `jpype.JProxy` untuk menetapkan nilai [SvgShape.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setId) pada bentuk dan nilai [SvgTSpan.setId](https://reference.aspose.com/slides/python-java/aspose.slides/svgtspan/#setId) pada elemen `tspan` teks. Tetapkan proxy dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController).

Pengendali berikut menggunakan [Shape.getOfficeInteropShapeId](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getOfficeInteropShapeId), yang stabil selama masa hidup bentuk, dan penghitung berulang untuk span teksnya. Ini membuat ID yang dihasilkan cocok untuk pemrosesan lanjutan pada presentasi yang tidak diubah.

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

## **Tambahkan Penanganan Peristiwa SVG**

Dalam pengendali pemformatan Python, panggil [SvgShape.setEventHandler](https://reference.aspose.com/slides/python-java/aspose.slides/svgshape/#setEventHandler) dengan nilai [SvgEvent](https://reference.aspose.com/slides/python-java/aspose.slides/svgevent/) untuk menambahkan penangan peristiwa JavaScript pada bentuk yang diekspor. Daftarkan pengendali melalui `jpype.JProxy` dan tetapkan dengan [SVGOptions.setShapeFormattingController](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setShapeFormattingController). Definisikan fungsi JavaScript di halaman atau dokumen SVG yang menampung hasil.

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

Halaman host dapat mendefinisikan fungsi JavaScript yang dirujuk oleh penangan. Menetapkan ID dan penangan peristiwa memungkinkan penampil slide, peningkatan aksesibilitas, dan alur kerja SVG interaktif lainnya.

## **FAQ**

**Kapan saya harus menggunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) alih-alih [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize)?**

Gunakan [SVGOptions.setVectorizeText](https://reference.aspose.com/slides/python-java/aspose.slides/svgoptions/#setVectorizeText) ketika semua teks harus independen dari font. Gunakan [SvgExternalFontsHandling.Vectorize](https://reference.aspose.com/slides/python-java/aspose.slides/svgexternalfontshandling/#Vectorize) ketika hanya teks yang menggunakan font eksternal yang harus diubah menjadi grafik.

**Apa cara terbaik untuk membuat SVG lebih kecil?**

Mulailah dengan mengompresi gambar tersemat, menghapus area gambar yang terpotong, dan memilih file font yang ditautkan ketika lingkungan target dapat menyediakannya. Uji hasilnya karena resolusi gambar yang lebih rendah, kualitas JPEG yang lebih rendah, dan teks yang tervektorkan masing-masing memiliki trade‑off kualitas dan ukuran yang berbeda.

**Bisakah saya memodifikasi elemen SVG yang diekspor setelah ekspor?**

Ya. Tetapkan ID melalui pengendali pemformatan, lalu pilih elemen SVG yang cocok di alat pemrosesan lanjutan atau skrip peramban Anda.