---
title: Kelola Objek Tinta Presentasi di Python
linktitle: Kelola Tinta
type: docs
weight: 95
url: /id/python-net/manage-ink/
keywords:
- tinta
- objek tinta
- jejak tinta
- kelola tinta
- gambar tinta
- menggambar
- ekspor tinta
- rendering tinta
- sembunyikan tinta
- InkOptions
- PowerPoint
- presentasi
- Python
- Aspose.Slides
description: "Kelola objek tinta PowerPoint, edit jejak dan properti kuas, serta kontrol tampilan tinta saat mengekspor PDF, HTML, SVG, TIFF, dan gambar dengan Aspose.Slides untuk Python via .NET."
---
## **Pengantar**

PowerPoint menyediakan fitur tinta yang memungkinkan Anda menggambar goresan bebas. Tinta dapat digunakan untuk menyorot objek lain, menunjukkan hubungan dan proses, serta menarik perhatian ke item tertentu pada slide.

Namespace [aspose.slides.ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/) berisi kelas-kelas yang diperlukan untuk bekerja dengan objek tinta. Misalnya, kelas [Ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/ink/) mewakili sebuah objek tinta pada slide.

## **Perbedaan antara Objek Biasa dan Objek Tinta**

Objek pada slide PowerPoint biasanya direpresentasikan oleh objek bentuk. Dalam bentuk paling sederhana, sebuah bentuk adalah wadah yang menentukan area objek itu sendiri (frame-nya) beserta properti seperti ukuran wadah, bentuk, dan latar belakang. Untuk informasi lebih lanjut, lihat [Shape Layout Format](https://docs.aspose.com/slides/id/python-net/shape-manipulations/#access-layout-formats-for-shape).

Namun, ketika PowerPoint menangani objek tinta, ia mengabaikan semua properti dari frame objek (wadah) kecuali ukurannya. Ukuran area wadah ditentukan oleh properti standar [Ink.width](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/ink/width/) dan [Ink.height](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/ink/height/) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Jejak Tinta**

Jejak tinta adalah elemen dasar yang digunakan untuk merekam lintasan pena saat pengguna menulis tinta digital. Sebuah jejak menyimpan urutan titik yang terhubung.

Bentuk enkoding paling sederhana menentukan koordinat X dan Y dari setiap titik sampel. Ketika semua titik yang terhubung dirender, mereka menghasilkan gambar seperti ini:

![ink_powerpoint2](ink_powerpoint2.png)

## **Properti Kuas untuk Menggambar**

Kuas digunakan untuk menggambar garis yang menghubungkan titik-titik pada jejak tinta. Properti [InkBrush.color](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/inkbrush/color/) dan [InkBrush.size](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/inkbrush/size/) mengontrol warna dan ukuran kuas.

### **Atur Warna Kuas Tinta**

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.color = draw.Color.red
```

### **Atur Ukuran Kuas Tinta**

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("pres.pptx") as presentation:
    ink = presentation.slides[0].shapes[0]
    brush = ink.traces[0].brush
    brush.size = draw.SizeF(5.0, 10.0)
```

Umumnya, lebar dan tinggi kuas tidak sama, sehingga PowerPoint tidak menampilkan ukuran kuas (bagian data yang bersangkutan berwarna abu-abu). Ketika lebar dan tinggi kuas cocok, PowerPoint menampilkan ukurannya seperti ini:

![ink_powerpoint3](ink_powerpoint3.png)

Untuk kejelasan, mari tingkatkan tinggi objek tinta dan tinjau dimensi penting:

![ink_powerpoint4](ink_powerpoint4.png)

Wadah (frame) tidak memperhitungkan ukuran kuas—ia selalu mengasumsikan ketebalan garis nol (lihat gambar sebelumnya).

Oleh karena itu, untuk menentukan area yang terlihat dari seluruh objek tinta, ukuran kuas pada jejaknya harus dipertimbangkan. Di sini, objek target (jejak teks tulisan tangan) telah diskalakan ke ukuran wadah (frame). Ketika ukuran wadah berubah, ukuran kuas tetap konstan, dan sebaliknya.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint menggunakan perilaku serupa untuk objek teks:

![ink_powerpoint6](ink_powerpoint6.png)

## **Kendalikan Tampilan Tinta Selama Ekspor dan Rendering**

Aspose.Slides menyediakan kelas [InkOptions](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/) untuk mengontrol bagaimana objek tinta muncul dalam output yang diekspor atau dirender. Anda dapat menggunakan propertinya untuk menyembunyikan tinta sepenuhnya atau mengubah cara operasi masker kuas tinta diinterpretasikan.

Opsi tinta tersedia melalui opsi ekspor atau rendering untuk beberapa tipe output:

| Output | Properti opsi tinta |
| --- | --- |
| PDF | [`PdfOptions.ink_options`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/pdfoptions/ink_options/) |
| HTML | [`HtmlOptions.ink_options`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/htmloptions/ink_options/) |
| SVG | [`SVGOptions.ink_options`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/svgoptions/ink_options/) |
| TIFF | [`TiffOptions.ink_options`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/ink_options/) |
| Slide image | [`RenderingOptions.ink_options`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/ink_options/) |

Dua pengaturan yang sama tersedia melalui properti ini:

- [`InkOptions.hide_ink`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/hide_ink/) menentukan apakah objek tinta disertakan dalam output. Nilai defaultnya adalah `False`.
- [`InkOptions.interpret_mask_op_as_opacity`](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) menentukan apakah operasi masker diinterpretasikan sebagai opacity saat merender kuas tinta. Nilai defaultnya adalah `True`; setel ke `False` untuk menggunakan operasi ROP sebagai gantinya.

### **Sembunyikan Objek Tinta dalam Output PDF**

Secara default, objek tinta tetap terlihat selama ekspor. Atur [InkOptions.hide_ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/hide_ink/) ke `True` ketika Anda membutuhkan output bersih tanpa anotasi tulisan tangan atau konten tinta lainnya.

Contoh Python berikut mengekspor presentasi ke PDF sambil menyembunyikan semua objek tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    pdf_options = slides.export.PdfOptions()
    pdf_options.ink_options.hide_ink = True

    presentation.save("presentation_without_ink.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

### **Sembunyikan Objek Tinta Saat Merender Slide sebagai Gambar**

Untuk menyembunyikan objek tinta saat merender slide sebagai gambar bitmap, konfigurasikan [RenderingOptions.ink_options](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/renderingoptions/ink_options/) dan berikan opsi rendering ke metode [Slide.get_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/) .

Contoh Python berikut merender slide pertama sebagai gambar PNG tanpa objek tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    rendering_options = slides.export.RenderingOptions()
    rendering_options.ink_options.hide_ink = True

    with presentation.slides[0].get_image(rendering_options) as image:
        image.save("slide_without_ink.png", slides.ImageFormat.PNG)
```

### **Kendalikan Rendering Mask Tinta**

Properti [InkOptions.interpret_mask_op_as_opacity](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/interpret_mask_op_as_opacity/) mengontrol bagaimana operasi masker diinterpretasikan saat merender kuas tinta. Nilai defaultnya adalah `True`, yang menggunakan opacity. Setel properti ke `False` untuk menggunakan operasi ROP sebagai gantinya.

Contoh Python berikut mengekspor slide ke SVG dan menggunakan rendering berbasis ROP untuk operasi mask tinta:

```py
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    svg_options = slides.export.SVGOptions()
    svg_options.ink_options.interpret_mask_op_as_opacity = False

    with open("slide.svg", "wb") as svg_stream:
        presentation.slides[0].write_as_svg(svg_stream, svg_options)
```

Pengaturan yang sama dapat diterapkan melalui [TiffOptions.ink_options](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/tiffoptions/ink_options/) saat mengekspor presentasi atau merender slide ke TIFF.

### **Pilih Apakah Menyembunyikan atau Mempertahankan Tinta**

Atur [InkOptions.hide_ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/hide_ink/) ke `True` ketika file yang diekspor harus menjadi versi bersih dari presentasi yang dianotasi, misalnya salinan final yang ditujukan untuk distribusi tanpa tanda ulasan.

Biarkan [InkOptions.hide_ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/hide_ink/) pada nilai defaultnya `False` ketika anotasi tinta merupakan bagian dari konten yang dimaksud, seperti komentar ulasan, catatan tulisan tangan, sorotan, atau gambar yang harus tetap terlihat dalam hasil ekspor. Ini memungkinkan aplikasi menghasilkan output ulasan dan final yang terpisah dari presentasi yang sama tanpa mengubah objek tinta sumber.

## **FAQ**

**Apakah saya dapat mengubah warna atau ukuran goresan tinta yang ada?**

Ya. Dapatkan jejak dari [Ink.traces](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/ink/traces/), kemudian ubah [InkTrace.brush](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/inktrace/brush/). Anda dapat mengatur properti [InkBrush.color](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/inkbrush/color/) dan [InkBrush.size](https://reference.aspose.com/slides/id/python-net/aspose.slides.ink/inkbrush/size/) pada kuas.

**Apakah menyembunyikan tinta mengubah presentasi sumber?**

Tidak. [InkOptions.hide_ink](https://reference.aspose.com/slides/id/python-net/aspose.slides.export/inkoptions/hide_ink/) hanya memengaruhi hasil yang dirender atau diekspor; tidak menghapus atau memodifikasi objek tinta dalam presentasi sumber.

**Format ekspor mana yang mendukung opsi tinta?**

Anda dapat mengonfigurasi opsi tinta untuk PDF, HTML, SVG, TIFF, dan gambar slide bitmap melalui opsi ekspor atau rendering yang bersangkutan seperti yang ditunjukkan di atas.

**Bacaan Lanjutan**

* Untuk membaca tentang bentuk secara umum, lihat bagian [PowerPoint Shapes](https://docs.aspose.com/slides/id/python-net/powerpoint-shapes/).
* Untuk informasi lebih lanjut tentang nilai efektif, lihat [Shape Effective Properties](https://docs.aspose.com/slides/id/python-net/shape-effective-properties/#get-effective-font-height-value).
* Untuk detail tentang ekspor PDF, lihat [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-pdf/).
* Untuk detail tentang ekspor HTML, lihat [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-html/).
* Untuk detail tentang ekspor SVG, lihat [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/id/python-net/render-a-slide-as-an-svg-image/).
* Untuk detail tentang ekspor TIFF, lihat [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/id/python-net/convert-powerpoint-to-tiff/).
* Untuk detail tentang rendering slide-to-image, lihat [Convert Presentation Slides to Images](https://docs.aspose.com/slides/id/python-net/convert-slide/).