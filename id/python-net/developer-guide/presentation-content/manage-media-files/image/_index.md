---
title: Optimalkan Manajemen Gambar dalam Presentasi dengan Python
linktitle: Kelola Gambar
type: docs
weight: 10
url: /id/python-net/image/
keywords:
- tambahkan gambar
- tambahkan gambar
- ganti gambar
- koleksi gambar
- bingkai gambar
- gambar tertaut
- latar belakang
- tambahkan PNG
- tambahkan JPG
- tambahkan SVG
- SVG ke bentuk
- sumber daya SVG eksternal
- PowerPoint
- OpenDocument
- presentasi
- Python
- Aspose.Slides
description: "Pelajari cara menambahkan, menggunakan kembali, menautkan, mengganti, dan mengelola gambar raster serta SVG dalam presentasi PowerPoint dan OpenDocument dengan Aspose.Slides untuk Python via .NET."
---
## **Pendahuluan**

Aspose.Slides untuk Python via .NET menyediakan beberapa cara untuk bekerja dengan gambar, dan setiap cara memiliki tujuan yang berbeda. Anda dapat menyimpan gambar dalam presentasi, menampilkannya dalam bingkai gambar, menggunakannya sebagai latar belakang slide, menautkan ke gambar eksternal, mengganti sumber daya gambar yang dibagikan, atau mengonversi konten SVG menjadi bentuk yang dapat diedit.

Artikel ini fokus pada sumber daya gambar dan cara penggunaannya di seluruh presentasi. Untuk pemotongan, transparansi, efek, peregangan, dan format lain yang diterapkan pada satu bingkai gambar, lihat [Bingkai Gambar](/slides/id/python-net/picture-frame/).

## **Memahami Model Gambar**

Konsep API berikut saling terkait tetapi tidak dapat dipertukarkan:

- The [presentation image collection](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/) stores image resources used by the presentation. Use [ImageCollection.add_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/add_image/) to add image data and obtain an [IPPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/) resource.
- A [picture frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipictureframe/) is a shape that displays an image on a slide, layout, or master. Use [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_picture_frame/) to place an image resource on a slide.
- A slide background uses an image as part of the slide fill rather than as a shape. It therefore does not behave like a picture frame.
- [IPPImage.replace_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/replace_image/) replaces an image resource. If several presentation elements use that resource, they all use the replacement.
- Converting an SVG to shapes creates editable slide shapes. After conversion, the content is no longer managed as one picture resource.

Alur kerja tipikal adalah: tambahkan data gambar ke koleksi gambar, terima sebuah [IPPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/), dan kemudian gunakan sumber daya tersebut di satu atau lebih bingkai gambar atau isian.

## **Menambahkan Gambar Tersemat**

Untuk menyisipkan gambar lokal, baca berkas, tambahkan datanya ke koleksi gambar, dan buat bingkai gambar yang menggunakan `IPPImage` yang dikembalikan.

```python
import aspose.slides as slides

with open("photo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

Gambar yang ditambahkan dengan cara ini tersemat dalam presentasi, sehingga berkas hasil tidak bergantung pada keberadaan berkas gambar asli.

### **Menambahkan Gambar dari Web**

Ketika gambar tersedia melalui HTTP atau HTTPS, unduh byte-nya, tambahkan ke koleksi gambar presentasi, dan gunakan sumber daya gambar yang dikembalikan dengan cara yang sama seperti gambar lokal.

```python
from urllib.request import urlopen

import aspose.slides as slides

image_url = "https://example.com/image.png"
with urlopen(image_url) as response:
    image_data = response.read()

with slides.Presentation() as presentation:
    image = presentation.images.add_image(image_data)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, image)

    presentation.save("presentation-from-web.pptx", slides.export.SaveFormat.PPTX)
```

Dalam aplikasi yang berjalan lama, gunakan kembali klien HTTP atau pool koneksi bila sesuai alih-alih membuat koneksi baru untuk setiap permintaan. Juga validasi URL remote, ukuran respons, dan tipe konten ketika sumber tidak dapat dipercaya.

## **Gunakan Ulang Gambar di Seluruh Slide**

Jika gambar yang sama diperlukan lebih dari satu kali, tambahkan sekali ke presentasi dan gunakan kembali [IPPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/) yang dikembalikan ketika membuat bingkai gambar tambahan. Ini menghindari memuat data sumber yang sama berulang kali dan membuat hubungan antara sumber daya gambar yang dibagikan dan penggunaannya menjadi eksplisit.

Untuk grafik yang harus muncul secara otomatis pada banyak slide, seperti logo perusahaan, pertimbangkan menempatkan bingkai gambar pada [slide master](/slides/id/python-net/slide-master/) atau tata letak alih-alih menambahkan bentuk setara ke setiap slide.

## **Menggunakan Gambar sebagai Latar Belakang Slide**

Gambar latar belakang ditetapkan ke isian slide; ia tidak ditambahkan sebagai bentuk bingkai gambar. Ini berguna ketika gambar harus menutupi latar belakang slide dan tidak boleh dimanipulasi sebagai objek slide biasa.

```python
import aspose.slides as slides

with open("background.jpg", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    image = presentation.images.add_image(image_data)
    slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    slide.background.fill_format.fill_type = slides.FillType.PICTURE
    slide.background.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    slide.background.fill_format.picture_fill_format.picture.image = image

    presentation.save("background-image.pptx", slides.export.SaveFormat.PPTX)
```

Untuk opsi latar belakang tambahan, termasuk latar belakang master dan tata letak, lihat [Presentation Background](/slides/id/python-net/presentation-background/).

## **Gambar Tersemat dan Gambar Tertaut**

Gambar tersemat dan gambar tertaut memiliki pertukaran portabilitas dan ukuran berkas yang berbeda:

- **Gambar tersemat:** data gambar disimpan di dalam presentasi. Presentasi menjadi mandiri, tetapi ukuran berkas mencakup data gambar.
- **Gambar tertaut:** presentasi menyimpan jalur atau URL ke gambar eksternal. Ini dapat mengurangi ukuran presentasi, tetapi sumber eksternal harus tetap dapat diakses saat presentasi dibuka atau dirender.

Gambar tertaut dapat dibuat dengan menetapkan jalur atau URL eksternal melalui [ISlidesPicture.link_path_long](https://reference.aspose.com/slides/id/python-net/aspose.slides/islidespicture/link_path_long/) alih-alih menanamkan data gambar.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 320, 180, None)
    picture_frame.picture_format.picture.link_path_long = "https://example.com/image.png"

    presentation.save("linked-image.pptx", slides.export.SaveFormat.PPTX)
```

Gunakan gambar tertaut hanya ketika lingkungan penyebaran dapat mengakses sumber eksternal secara andal. Untuk presentasi yang harus berfungsi secara offline atau dipindahkan antar sistem, gambar tersemat biasanya lebih aman.

## **Bekerja dengan Gambar SVG**

SVG adalah format vektor, sehingga berguna untuk ikon, diagram, dan grafik lain yang harus skalabel tanpa kehilangan detail seperti pada gambar raster. Aspose.Slides mendukung SVG baik sebagai sumber daya gambar maupun sebagai sumber untuk bentuk slide yang dapat diedit.

### **Menambahkan SVG sebagai Gambar**

Buat sebuah [SvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/svgimage/), tambahkan ke koleksi gambar, dan tempatkan sumber daya gambar yang dihasilkan dalam bingkai gambar.

```python
import aspose.slides as slides

with open("icon.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    image = presentation.images.add_image(svg_image)
    slide = presentation.slides[0]
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 200, image)

    presentation.save("svg-image.pptx", slides.export.SaveFormat.PPTX)
```

### **Mengonversi SVG ke Bentuk yang Dapat Diedit**

Aspose.Slides dapat mengonversi SVG menjadi grup bentuk slide yang dapat diedit, mirip dengan perintah PowerPoint yang bersangkutan.

![PowerPoint Popup Menu](img_01_01.png)

Gunakan overload [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_group_shape/) yang menerima sebuah [ISvgImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/isvgimage/) untuk melakukan konversi.

```python
import aspose.slides as slides

with open("diagram.svg", "r", encoding="utf-8") as svg_stream:
    svg_content = svg_stream.read()

svg_image = slides.SvgImage(svg_content)

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    slide = presentation.slides[0]
    slide.shapes.add_group_shape(svg_image, 0, 0, slide_size.width, slide_size.height)

    presentation.save("editable-svg-shapes.pptx", slides.export.SaveFormat.PPTX)
```

Gunakan konversi SVG‑ke‑bentuk ketika elemen vektor individu perlu diedit sebagai bentuk PowerPoint. Jika SVG hanya perlu ditampilkan, mempertahankannya sebagai gambar lebih sederhana dan menghindari pembuatan banyak bentuk terpisah.

## **Mengganti Sumber Daya Gambar yang Ada**

Gunakan [IPPImage.replace_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/replace_image/) ketika Anda ingin mengganti sumber daya gambar yang ada. Ini sangat berguna untuk grafik yang dibagikan seperti logo.

```python
import aspose.slides as slides

with open("new-logo.png", "rb") as image_stream:
    image_data = image_stream.read()

with slides.Presentation("input.pptx") as presentation:
    image_to_replace = presentation.images[0]
    image_to_replace.replace_image(image_data)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

Jika beberapa bingkai gambar, latar belakang, master, atau tata letak menggunakan sumber daya gambar yang sama, mengganti sumber daya tersebut memperbarui semua penggunaan tersebut. Jika hanya satu bingkai gambar yang harus berubah, tetapkan gambar yang berbeda ke bingkai itu alih-alih mengganti sumber daya yang dibagikan.

`replace_image` juga menyediakan overload yang menerima sebuah [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) atau [IPPImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/) lain.

## **Panduan Praktis Manajemen Gambar**

### **Mengendalikan Ukuran Presentasi**

Gambar raster besar dapat membuat presentasi menjadi terlalu besar. Gunakan gambar sumber dengan dimensi yang sesuai untuk ukuran tampilan yang dimaksudkan, gunakan kembali sumber daya gambar yang dibagikan bila memungkinkan, dan hindari menanamkan salinan berulang dari grafik resolusi penuh yang sama.

Untuk gambar raster yang sudah ditempatkan dalam bingkai gambar, [PictureFillFormat.compress_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/picturefillformat/compress_image/) dapat mengurangi data gambar sesuai resolusi dan pengaturan pemotongan yang dipilih. Ini adalah pemrosesan bingkai gambar bukan manajemen koleksi gambar, jadi lihat [Bingkai Gambar](/slides/id/python-net/picture-frame/) untuk operasi format terkait.

### **Pilih Antara Konten Tersemat dan Tertaut**

Menanamkan membuat presentasi portabel karena semua data gambar yang diperlukan berpindah bersama berkas. Menautkan dapat mengurangi ukuran berkas, tetapi menambah ketergantungan eksternal. Gunakan tautan hanya ketika ketergantungan tersebut dapat diterima dan stabil.

### **Gunakan Ulang Branding yang Dibagikan**

Untuk logo, watermark, atau grafik dekoratif yang berulang, gunakan satu sumber daya gambar dan gunakan kembali. Jika grafik tersebut merupakan bagian dari desain presentasi bukan konten slide, letakkan pada master atau tata letak sehingga diwariskan ke slide yang sesuai.

### **Jaga Portabilitas Sumber Daya SVG**

SVG yang berdiri sendiri lebih mudah dipindahkan dan dirender secara konsisten dibandingkan SVG yang bergantung pada berkas atau sumber jaringan eksternal. Bila memungkinkan, sematkan sumber daya yang diperlukan sebelum mengimpor SVG. Konversi SVG ke bentuk hanya ketika elemen vektor individual perlu diedit.

### **Gunakan API Gambar Lintas Platform Modern**

Untuk kode Python via .NET baru, gunakan API Aspose.Slides [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) dan [Images](https://reference.aspose.com/slides/id/python-net/aspose.slides/images/) alih-alih API gambar `aspose.pydrawing.Image` atau `aspose.pydrawing.Bitmap` yang sudah usang. Lihat [Modern API](/slides/id/python-net/modern-api/) untuk panduan migrasi.

WMF dan EMF memerlukan pertimbangan khusus. Ketika format ini dilewatkan melalui sebuah [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/), [ImageCollection.add_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/add_image/) mengonversi metafile menjadi representasi PNG raster sebelum disisipkan. Jika mempertahankan data metafile penting, gunakan overload berbasis stream dari [ImageCollection.add_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/add_image/). Menghasilkan konten EMF dari spreadsheet atau produk lain adalah alur integrasi terpisah dan berada di luar cakupan artikel ini.

## **FAQ**

**Apa perbedaan antara koleksi gambar dan bingkai gambar?**

Koleksi gambar menyimpan sumber daya gambar yang dapat digunakan kembali. Bingkai gambar adalah bentuk slide yang menampilkan salah satu sumber daya tersebut dan menyediakan format khusus gambar seperti pemotongan dan efek.

**Cara terbaik mengganti logo yang sama di semua tempat adalah apa?**

Jika logo sudah dibagikan sebagai satu sumber daya gambar, ganti sumber daya tersebut dengan [IPPImage.replace_image](https://reference.aspose.com/slides/id/python-net/aspose.slides/ippimage/replace_image/). Untuk branding di seluruh presentasi, menempatkan logo pada master atau tata letak juga dapat mengurangi duplikasi konten slide.

**Mengapa gambar tertaut menghilang di komputer lain?**

Gambar tertaut bergantung pada berkas atau URL eksternal. Jika sumber tersebut tidak dapat dijangkau dari komputer lain, gambar tertaut tidak akan tersedia. Tanamkan gambar ketika presentasi harus mandiri.

**Apakah SVG yang disisipkan dapat diedit sebagai bentuk PowerPoint?**

Ya. Konversikan SVG dengan [ShapeCollection.add_group_shape](https://reference.aspose.com/slides/id/python-net/aspose.slides/shapecollection/add_group_shape/); grup yang dihasilkan berisi bentuk slide yang dapat diedit, bukan satu gambar SVG.

**Bagaimana cara menjaga presentasi dengan banyak gambar tetap kecil?**

Gunakan kembali sumber daya gambar yang dibagikan, hindari sumber raster yang terlalu besar, kompres gambar raster yang sesuai bila perlu, letakkan branding berulang pada master atau tata letak, dan gunakan gambar tertaut hanya ketika ketergantungan eksternal dapat diterima.