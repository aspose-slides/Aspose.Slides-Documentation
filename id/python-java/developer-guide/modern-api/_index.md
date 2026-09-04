---
title: Tingkatkan Pemrosesan Gambar dengan API Modern di Python
linktitle: API Modern
type: docs
weight: 237
url: /id/python-java/modern-api/
keywords:
- API modern
- menggambar
- thumbnail slide
- slide ke gambar
- thumbnail bentuk
- bentuk ke gambar
- thumbnail presentasi
- presentasi ke gambar
- tambahkan gambar
- tambahkan foto
- Python
- Java
- Aspose.Slides
description: "Modernisasi pemrosesan gambar di Python melalui Java: render slide dan shape, tambahkan gambar, serta migrasikan panggilan imaging yang sudah usang ke API Modern Aspose.Slides."
---
## **Pendahuluan**

Aspose.Slides untuk Python via Java mengakses pustaka Java melalui JPype. API pemrosesan gambar warisan menggunakan [BufferedImage](https://docs.oracle.com/javase/8/docs/api/java/awt/image/BufferedImage.html) dan [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) dari `java.awt`.

Pustaka Java menurunkan (deprecate) API imaging ini mulai versi 24.4. API Modern menggunakan [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/) untuk memuat, merender, dan menyimpan gambar. Gunakan API ini untuk kode Python baru dan saat memigrasikan alur kerja pemrosesan gambar yang ada.

{{% alert color="info" title="Note" %}}
Nama metode lama di bawah ini hanya sebagai referensi migrasi. Metode tersebut tidak lagi tersedia pada rilis terkini. Contoh yang dapat dijalankan menggunakan API Modern.
{{% /alert %}}

## **API Modern**

Tipe utama pemrosesan gambar adalah:

- [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/) — mewakili gambar raster atau vektor.  
- [ImageFormat](https://reference.aspose.com/slides/id/python-java/aspose.slides/imageformat/) — menyediakan konstanta format file gambar.  
- [Images](https://reference.aspose.com/slides/id/python-java/aspose.slides/images/) — membuat gambar, misalnya dengan [Images.fromFile](https://reference.aspose.com/slides/id/python-java/aspose.slides/images/#fromFile).

Gunakan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) atau [Shape.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) untuk merender satu slide atau shape. Gunakan [Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan opsi rendering untuk merender beberapa slide. Overload tanpa argumen mengembalikan koleksi gambar presentasi.

Muat gambar dengan [Images.fromFile](https://reference.aspose.com/slides/id/python-java/aspose.slides/images/#fromFile), tambahkan dengan [ImageCollection.addImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/#addImage), atau perbarui gambar presentasi yang ada dengan [PPImage.replaceImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#replaceImage). Kedua operasi koleksi gambar menerima [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/).

Lepaskan setiap gambar yang Anda muat atau render dengan memanggil metode `dispose`‑nya di dalam blok `finally`. Lepaskan presentasi dengan [Presentation.dispose](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#dispose).

### **Menyiapkan Lingkungan Python**

Pasang paket-paket sebagaimana dijelaskan pada [Installation](/slides/id/python-java/installation/). Setiap contoh mengimpor `asposeslides` sebelum memulai JVM, kemudian mengimpor API setelah JVM berjalan. Contoh‑contoh membiarkan JVM tetap berjalan agar dapat digunakan kembali. Lihat [Limitations and API Differences](/slides/id/python-java/limitations-and-api-differences/#import-the-library) untuk panduan siklus hidup notebook dan JVM.

Contoh yang membuka `pres.pptx` memerlukan presentasi di direktori kerja. Contoh yang memuat `image.png` memerlukan berkas gambar yang sudah ada.

### **Muat Gambar dan Render Slide**

Contoh ini menambahkan gambar ke slide pertama dan menyimpan slide sebagai gambar JPEG. [IImage.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/#save) menuliskan gambar yang dirender dalam format yang ditentukan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Images, Presentation, ShapeType
from java.awt import Dimension

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)

    image_size = Dimension(1920, 1080)
    slide_image = slide.getImage(image_size)
    try:
        slide_image.save("slide1.jpeg", ImageFormat.Jpeg)
    finally:
        slide_image.dispose()
finally:
    presentation.dispose()
```

## **Mengganti Kode Lama dengan API Modern**

Gantikan panggilan thumbnail warisan dengan metode yang mengembalikan [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/), lalu simpan hasilnya dengan [IImage.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/#save). Ini menghilangkan kebutuhan untuk meneruskan gambar yang dirender ke [ImageIO.write](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#write-java.awt.image.RenderedImage-java.lang.String-java.io.File-).

### **Render Slide pada Ukuran Tertentu**

Gantikan panggilan warisan `slide.getThumbnail(image_size)` dengan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) menggunakan ukuran gambar yang sama.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        image_size = Dimension(1920, 1080)
        slide_image = presentation.getSlides().get_Item(0).getImage(image_size)
        try:
            slide_image.save("image.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Mendapatkan Thumbnail Slide**

Gantikan panggilan warisan `slide.getThumbnail()` dengan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) tanpa argumen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide_image = presentation.getSlides().get_Item(0).getImage()
        try:
            slide_image.save("slide1.png", ImageFormat.Png)
        finally:
            slide_image.dispose()
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Mendapatkan Thumbnail Shape**

Gantikan panggilan warisan `shape.getThumbnail()` dengan [Shape.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage). Pastikan slide berisi shape sebelum mengaksesnya.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation

presentation = Presentation("pres.pptx")
try:
    if presentation.getSlides().size() > 0:
        slide = presentation.getSlides().get_Item(0)
        if slide.getShapes().size() > 0:
            shape_image = slide.getShapes().get_Item(0).getImage()
            try:
                shape_image.save("shape.png", ImageFormat.Png)
            finally:
                shape_image.dispose()
        else:
            print("The first slide contains no shapes.")
    else:
        print("The presentation contains no slides.")
finally:
    presentation.dispose()
```

### **Mendapatkan Thumbnail Presentasi**

Gantikan panggilan warisan `presentation.getThumbnails(options, image_size)` dengan [Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages). Gunakan [RenderingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/) untuk mengonfigurasi rendering.

Iterasi langsung atas array yang dikembalikan dengan `enumerate` Python. Lepaskan setiap gambar yang dikembalikan dalam blok `finally` agar kegagalan penyimpanan tidak meninggalkan gambar yang belum dilepaskan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, RenderingOptions
from java.awt import Dimension

presentation = Presentation("pres.pptx")
try:
    rendering_options = RenderingOptions()
    image_size = Dimension(1920, 1080)
    images = presentation.getImages(rendering_options, image_size)
    try:
        for index, image in enumerate(images, start=1):
            image.save(f"slide{index}.png", ImageFormat.Png)
    finally:
        for image in images:
            image.dispose()
finally:
    presentation.dispose()
```

### **Menambahkan Gambar ke Presentasi**

Gantikan pemuatan melalui [ImageIO.read](https://docs.oracle.com/javase/8/docs/api/javax/imageio/ImageIO.html#read-java.io.File-) dengan [Images.fromFile](https://reference.aspose.com/slides/id/python-java/aspose.slides/images/#fromFile), lalu berikan gambar yang dihasilkan ke [ImageCollection.addImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/#addImage). Tambahkan gambar ke slide dan simpan presentasi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Images, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    image = Images.fromFile("image.png")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    slide = presentation.getSlides().get_Item(0)
    slide.getShapes().addPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, picture)
    presentation.save("picture.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Metode yang Tidak Lagi Dipakai dan Penggantinya dalam API Modern**

Tabel-tabel menggunakan notasi pemanggilan Python. Nama pada kolom warisan mengidentifikasi API yang dihapus; gunakan metode pengganti yang ditautkan. Metode modern untuk merender gambar mengembalikan objek [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/) alih-alih gambar buffered Java.

### **Presentation**

[Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) mengembalikan array gambar yang dirender ketika dipanggil dengan opsi rendering.

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `presentation.getThumbnails(options)` | [getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan `options` |
| `presentation.getThumbnails(options, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan `options, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides)` | [getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan `options, slides` |
| `presentation.getThumbnails(options, slides, scale_x, scale_y)` | [getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan `options, slides, scale_x, scale_y` |
| `presentation.getThumbnails(options, slides, image_size)` | [getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan `options, slides, image_size` |
| `presentation.getThumbnails(options, image_size)` | [getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) dengan `options, image_size` |

Di sini, `slides` adalah `int[]` Java berisi nomor slide berbasis satu; buat dengan `jpype.JArray(jpype.JInt)([1, 3])` untuk memilih slide 1 dan 3. `image_size` adalah [Dimension](https://docs.oracle.com/javase/8/docs/api/java/awt/Dimension.html).

### **Shape**

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `shape.getThumbnail()` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) tanpa argumen |
| `shape.getThumbnail(bounds, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/shape/#getImage) dengan `bounds, scale_x, scale_y` |

### **Slide**

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `slide.getThumbnail()` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) tanpa argumen |
| `slide.getThumbnail(scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan `scale_x, scale_y` |
| `slide.getThumbnail(options)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan `options` |
| `slide.getThumbnail(options, scale_x, scale_y)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan `options, scale_x, scale_y` |
| `slide.getThumbnail(options, image_size)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan `options, image_size` |
| `slide.getThumbnail(tiff_options)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan `tiff_options` |
| `slide.getThumbnail(image_size)` | [getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) dengan `image_size` |
| `slide.renderToGraphics(options, graphics)` | Tidak ada pengganti langsung; render ke gambar sebagai gantinya |
| `slide.renderToGraphics(options, graphics, scale_x, scale_y)` | Tidak ada pengganti langsung; render ke gambar sebagai gantinya |
| `slide.renderToGraphics(options, graphics, image_size)` | Tidak ada pengganti langsung; render ke gambar sebagai gantinya |

Di sini, `options` adalah [RenderingOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/renderingoptions/), dan `tiff_options` adalah [TiffOptions](https://reference.aspose.com/slides/id/python-java/aspose.slides/tiffoptions/).

### **Output**

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `output.add(path, buffered_image)` | [Output.add](https://reference.aspose.com/slides/id/python-java/aspose.slides/output/#add) dengan `path, image`, di mana `image` adalah [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/) |

### **ImageCollection**

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `collection.addImage(buffered_image)` | [ImageCollection.addImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/imagecollection/#addImage) dengan [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/) |

### **PPImage**

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `picture.getSystemImage()` | [PPImage.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#getImage) |

Untuk mengganti isi gambar presentasi yang ada, gunakan [PPImage.replaceImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/ppimage/#replaceImage) dengan sebuah [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/).

### **PatternFormat**

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `pattern.getTileImage(style_color)` | [PatternFormat.getTile](https://reference.aspose.com/slides/id/python-java/aspose.slides/patternformat/#getTile) dengan `style_color` |
| `pattern.getTileImage(background, foreground)` | [PatternFormat.getTile](https://reference.aspose.com/slides/id/python-java/aspose.slides/patternformat/#getTile) dengan `background, foreground` |

Argumen warna tetap berupa objek Java [Color](https://docs.oracle.com/javase/8/docs/api/java/awt/Color.html).

### **PatternFormatEffectiveData**

Untuk data pola efektif yang dikembalikan oleh API Java melalui JPype, metode pengganti mempertahankan nama `getTileIImage`.

| Panggilan Legacy | Pengganti Modern |
| --- | --- |
| `effective_pattern.getTileImage(background, foreground)` | `effective_pattern.getTileIImage(background, foreground)`, mengembalikan [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/) |

## **Dukungan API untuk Graphics2D**

Overload legacy `renderToGraphics` menggambar ke konteks [Graphics2D](https://docs.oracle.com/javase/8/docs/api/java/awt/Graphics2D.html) yang disediakan pemanggil. API Modern tidak memiliki pengganti langsung yang menggambar ke konteks tersebut.

Gunakan [Slide.getImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/slide/#getImage) untuk merender slide atau [Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) untuk merender beberapa slide, kemudian simpan gambar yang dikembalikan dengan [IImage.save](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/#save). Aplikasi yang menggabungkan rendering slide dengan gambar Java kustom harus menyesuaikan langkah komposit mereka.

## **FAQ**

**Mengapa API imaging Java lama digantikan?**

API Modern memindahkan pemuatan, rendering, dan penyimpanan gambar ke [IImage](https://reference.aspose.com/slides/id/python-java/aspose.slides/iimage/). Ini memberikan alur kerja abstraksi gambar yang umum alih-alih mengekspos gambar buffered Java atau konteks grafis Java.

**Apakah saya masih membutuhkan Java dan JPype?**

Ya. Aspose.Slides untuk Python via Java tetap dijalankan di atas JVM. API Modern mengubah panggilan pemrosesan gambar, bukan persyaratan runtime. Lihat [System Requirements](/slides/id/python-java/system-requirements/).

**Bagaimana cara melepaskan gambar di Python?**

Panggil `dispose` pada setiap gambar yang Anda muat atau render di dalam blok `finally`. Jika Anda merender beberapa slide, lepaskan setiap gambar dalam array yang dikembalikan. Lepaskan presentasi secara terpisah dengan [Presentation.dispose](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#dispose).

**Apakah beralih ke API Modern menjamin pembuatan thumbnail lebih cepat?**

Tidak ada jaminan peningkatan performa. Pengganti mendukung opsi rendering, skala, dan ukuran gambar; ukur performa dengan presentasi dan pengaturan output Anda.

**Mengapa pengambil gambar kadang‑kadang mengembalikan koleksi?**

[Presentation.getImages](https://reference.aspose.com/slides/id/python-java/aspose.slides/presentation/#getImages) tanpa argumen mengembalikan gambar‑gambar yang tertanam dalam presentasi. Overload‑nya dengan opsi rendering mengembalikan gambar slide yang dirender.