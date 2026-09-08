---
title: Kelola Objek Tinta Presentasi di Python via Java
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/python-java/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- ekspor tinta
- render tinta
- sembunyikan tinta
- InkOptions
- PowerPoint
- presentasi
- Python
- Java
- Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kontrol tampilan tinta selama ekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk Python via Java."
---
## **Pendahuluan**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menampilkan koneksi dan proses, serta menarik perhatian ke item tertentu pada slide.

Aspose.Slides menyediakan tipe yang diperlukan untuk bekerja dengan objek tinta. Misalnya, kelas [Ink](https://reference.aspose.com/slides/id/python-java/aspose.slides/ink/) mewakili sebuah objek tinta pada slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek shape. Dalam bentuk paling sederhana, shape adalah sebuah wadah yang menentukan area objek itu sendiri (frame) bersama properti seperti ukuran wadah, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Format Tata Letak Shape](/slides/id/python-java/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti frame objek (wadah) kecuali ukurannya. Ukuran area wadah ditentukan oleh metode standar [Shape.getWidth](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getWidth) dan [Shape.getHeight](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getHeight) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Sebuah jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding paling sederhana menentukan koordinat X dan Y setiap titik contoh. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik-titik pada jejak tinta. Kuas memiliki warna dan ukuran sendiri, yang direpresentasikan oleh metode [InkBrush.getColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkbrush/#getColor) dan [InkBrush.getSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkbrush/#getSize).

### **Atur Warna Kuas Tinta**

Kode Python ini menunjukkan cara mengatur warna kuas tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Color = jpype.JClass("java.awt.Color")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush.setColor(Color.RED)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

### **Atur Ukuran Kuas Tinta**

Kode Python ini menunjukkan cara mengatur ukuran kuas tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Ink

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    ink = slide.getShapes().get_Item(0)
    if isinstance(ink, Ink):
        traces = ink.getTraces()
        if len(traces) > 0:
            brush = traces[0].getBrush()
            brush_size = Dimension(5, 10)
            brush.setSize(brush_size)
        else:
            print("The ink object has no traces.")
    else:
        print("The first shape is not an ink object.")
finally:
    presentation.dispose()
```

Secara umum, lebar dan tinggi kuas tidak cocok, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data terkait berwarna abu-abu). Ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya sebagai berikut:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Wadah (frame) tidak memperhitungkan ukuran kuas—selalu menganggap ketebalan garis nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas pada jejaknya harus dipertimbangkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran wadah (frame). Ketika ukuran wadah berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kontrol Penampilan Tinta Selama Ekspor dan Rendering**

Aspose.Slides menyediakan kelas [InkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/) untuk mengontrol bagaimana objek tinta muncul dalam output yang diekspor atau dirender. Anda dapat menggunakan propertinya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi masker kuas tinta diinterpretasikan.

Opsi tinta tersedia melalui opsi ekspor atau rendering untuk berbagai tipe output:

| Output | Properti opsi tinta |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/pdfoptions/#getInkOptions) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/htmloptions/#getInkOptions) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/svgoptions/#getInkOptions) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffoptions/#getInkOptions) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/#getInkOptions) |

Metode [InkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/) berikut mengungkapkan dua pengaturan yang sama:

- [getHideInk](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#getHideInk) menentukan apakah objek tinta termasuk dalam output. Nilai defaultnya `False`.
- [getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) menentukan apakah operasi masker diinterpretasikan sebagai opacity saat merender kuas tinta. Nilai defaultnya `True`; panggil [setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) dengan `False` untuk menggunakan operasi ROP sebagai gantinya.

### **Sembunyikan Objek Tinta dalam Output PDF**

Secara default, objek tinta tetap terlihat selama ekspor. Untuk membuat output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya, panggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#setHideInk) dengan `True`.

Contoh Python berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PdfOptions, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    pdf_options = PdfOptions()
    pdf_options.getInkOptions().setHideInk(True)

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

### **Sembunyikan Objek Tinta Saat Merender Slide sebagai Gambar**

Untuk menyembunyikan objek tinta saat merender slide sebagai gambar bitmap, konfigurasikan [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/#getInkOptions) dan kirimkan opsi rendering ke [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage).

Contoh Python berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, RenderingOptions, ImageFormat

presentation = Presentation("presentation.pptx")
try:
    rendering_options = RenderingOptions()
    rendering_options.getInkOptions().setHideInk(True)

    slide = presentation.getSlides().get_Item(0)
    image = slide.getImage(rendering_options)
    try:
        image.save("slide_without_ink.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

### **Kontrol Rendering Mask Tinta**

Pengaturan [InkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#getInterpretMaskOpAsOpacity) mengontrol bagaimana operasi masker diinterpretasikan saat merender kuas tinta. Nilai defaultnya `True`, yang menggunakan opacity. Untuk menggunakan operasi ROP sebagai gantinya, panggil [InkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#setInterpretMaskOpAsOpacity) dengan `False`.

Contoh Python berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi mask tinta:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SVGOptions

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation("presentation.pptx")
try:
    svg_options = SVGOptions()
    svg_options.getInkOptions().setInterpretMaskOpAsOpacity(False)

    stream = FileOutputStream("slide.svg")
    try:
        slide = presentation.getSlides().get_Item(0)
        slide.writeAsSvg(stream, svg_options)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions.getInkOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffoptions/#getInkOptions) saat mengekspor presentasi atau merender slide ke TIFF.

### **Pilih untuk Menyembunyikan atau Mempertahankan Tinta**

Ketika Anda membutuhkan versi bersih dari presentasi beranotasi untuk distribusi tanpa tanda ulasan, panggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#setHideInk) dengan `True` selama ekspor.

Biarkan [InkOptions.getHideInk](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#getHideInk) pada nilai default `False` ketika anotasi tinta merupakan bagian dari konten yang diinginkan, seperti komentar ulasan, catatan tulisan tangan, penyorotan, atau gambar yang harus tetap terlihat dalam hasil ekspor. Ini memungkinkan aplikasi menghasilkan output ulasan dan final terpisah dari presentasi yang sama tanpa memodifikasi objek tinta sumber.

## **FAQ**

**Apakah saya dapat mengubah warna atau ukuran goresan tinta yang ada?**

Ya. Dapatkan jejak dari [Ink.getTraces](https://reference.aspose.com/slides/id/python-java/aspose.slides/ink/#getTraces), kemudian ubah [InkTrace.getBrush](https://reference.aspose.com/slides/id/python-java/aspose.slides/inktrace/#getBrush)‑nya. Panggil [InkBrush.setColor](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkbrush/#setColor) atau [InkBrush.setSize](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkbrush/#setSize) untuk mengubah kuas.

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. Memanggil [InkOptions.setHideInk](https://reference.aspose.com/slides/id/python-java/aspose.slides/inkoptions/#setHideInk) hanya memengaruhi hasil yang dirender atau diekspor; tidak menghapus atau memodifikasi objek tinta dalam presentasi sumber.

**Format ekspor mana yang mendukung opsi tinta?**

Anda dapat mengkonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang sesuai seperti ditunjukkan di atas.

**Bacaan Lanjutan**

* Untuk membaca tentang shape secara umum, lihat bagian [PowerPoint Shapes](/slides/id/python-java/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](/slides/id/python-java/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail ekspor PDF, lihat [Convert PPT and PPTX to PDF](/slides/id/python-java/convert-powerpoint-to-pdf/).
* Untuk detail ekspor HTML, lihat [Convert PowerPoint Presentations to HTML](/slides/id/python-java/convert-powerpoint-to-html/).
* Untuk detail ekspor SVG, lihat [Render Presentation Slides as SVG Images](/slides/id/python-java/render-a-slide-as-an-svg-image/).
* Untuk detail ekspor TIFF, lihat [Convert PowerPoint Presentations to TIFF](/slides/id/python-java/convert-powerpoint-to-tiff/).
* Untuk detail rendering slide menjadi gambar, lihat [Convert Presentation Slides to Images](/slides/id/python-java/convert-slide/).