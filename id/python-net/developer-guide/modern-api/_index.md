---
title: Tingkatkan Pemrosesan Gambar dengan API Modern
linktitle: API Modern
type: docs
weight: 280
url: /id/python-net/modern-api/
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
- Aspose.Slides
description: "Modernisasi pemrosesan gambar slide dengan mengganti API imaging yang tidak lagi direkomendasikan menggunakan API Modern Python untuk otomatisasi PowerPoint dan OpenDocument yang mulus."
---
## **Pendahuluan**

API publik Aspose.Slides for Python saat ini bergantung pada tipe `aspose.pydrawing` berikut:
- `aspose.pydrawing.Graphics`
- `aspose.pydrawing.Image`
- `aspose.pydrawing.Bitmap`
- `aspose.pydrawing.printing.PrinterSettings`

Mulai versi 24.4, API publik ini **tidak lagi direkomendasikan** karena [perubahan](https://releases.aspose.com/slides/id/python-net/release-notes/2024/aspose-slides-for-python-net-24-4-release-notes/#introducing-a-new-modern-api) pada API publik Aspose.Slides for Python.

Untuk menghilangkan `aspose.pydrawing` dari API publik, kami memperkenalkan **API Modern**. Metode yang menggunakan `aspose.pydrawing.Image` dan `aspose.pydrawing.Bitmap` tidak lagi direkomendasikan dan harus diganti dengan padanan API Modern mereka. Metode yang menggunakan `aspose.pydrawing.Graphics` tidak lagi direkomendasikan dan tidak memiliki pengganti langsung di API Modern.

Pada versi saat ini, perlakukan API publik yang bergantung pada `aspose.pydrawing` sebagai warisan/tidak direkomendasikan. Gunakan API Modern untuk kode baru dan saat memigrasikan alur kerja pemrosesan gambar yang ada.

## **API Modern**

Kelas dan enum berikut telah ditambahkan ke API publik:

- [aspose.slides.IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) – merepresentasikan gambar raster atau vektor.
- [aspose.slides.ImageFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/imageformat/) – merepresentasikan format berkas gambar.
- [aspose.slides.Images](https://reference.aspose.com/slides/id/python-net/aspose.slides/images/) – menyediakan metode untuk membuat dan bekerja dengan [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/).

Gunakan `get_image` untuk merender satu slide atau bentuk. Gunakan `get_images` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/id/python-net/aspose.slides/images/) untuk memuat gambar, `add_image` dengan [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) untuk menambahkannya ke presentasi, dan `replace_image` dengan [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) untuk memperbarui gambar presentasi yang sudah ada.

Skenario penggunaan tipikal untuk API baru terlihat seperti ini:

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)

    with slide.get_image(drawing.Size(1920, 1080)) as slide_image:
        slide_image.save("slide1.jpeg", slides.ImageFormat.JPEG)
```

## **Ganti Kode Lama dengan API Modern**

Untuk transisi yang lebih mudah, kelas baru [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) mencerminkan API terpisah dari kelas `aspose.pydrawing.Image` dan `aspose.pydrawing.Bitmap`. Dalam kebanyakan kasus, Anda hanya perlu mengganti pemanggilan metode yang menggunakan `aspose.pydrawing` dengan padanan API Modern mereka.

### **Dapatkan Thumbnail Slide**

**Deprecated API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    slide.get_thumbnail().save("slide1.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    with slide.get_image() as image:
        image.save("slide1.png")
```

### **Dapatkan Thumbnail Bentuk**

**Deprecated API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    
    shape.get_thumbnail().save("shape.png")
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]

    with shape.get_image() as image:
        image.save("shape.png")
```

### **Dapatkan Thumbnail Presentasi**

**Deprecated API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_thumbnails(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", drawing.imaging.ImageFormat.png)
```

**Modern API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation("sample.pptx") as presentation:
    thumbnails = presentation.get_images(slides.export.RenderingOptions(), drawing.Size(1980, 1028))

    for index, thumbnail in enumerate(thumbnails):
        thumbnail.save(f"slide_{index}.png", slides.ImageFormat.PNG)
```

### **Tambah Gambar ke Presentasi**

**Deprecated API:**

```python
import aspose.slides as slides
import aspose.pydrawing as drawing

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    image = drawing.Image.from_file("image.png")
    pp_image = presentation.images.add_image(image)
    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

**Modern API:**

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("image.png") as image:
        pp_image = presentation.images.add_image(image)

    slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 10, 10, 100, 100, pp_image)
```

## **Metode dan Properti yang Akan Dihapus serta Pengganti Modernnya**

### **Presentation Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|get_thumbnails(options)|[get_images(options)](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions)|
|get_thumbnails(options, slides)|[get_images(options, slides)](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint)|
|get_thumbnails(options, scale_x, scale_y)|[get_images(options, scale_x, scale_y)](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnails(options, slides, scale_x, scale_y)|[get_images(options, slides, scale_x, scale_y)](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-float-float)|
|get_thumbnails(options, image_size)|[get_images(options, image_size)](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|get_thumbnails(options, slides, image_size)|[get_images(options, slides, image_size)](https://reference.aspose.com/slides/id/python-net/aspose.slides/presentation/get_images/#asposeslidesexportirenderingoptions-listint-asposepydrawingssize)|
|save(fname, format, response, show_inline)|Tidak ada pengganti API Modern|
|save(fname, format, options, response, show_inline)|Tidak ada pengganti API Modern|
|print()|Tidak ada pengganti API Modern|
|print(printer_settings)|Tidak ada pengganti API Modern|
|print(printer_name)|Tidak ada pengganti API Modern|
|print(printer_settings, pres_name)|Tidak ada pengganti API Modern|

### **Slide Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#)|
|get_thumbnail(scale_x, scale_y)|[get_image(scale_x, scale_y)](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#float-float)|
|get_thumbnail(image_size)|[get_image(image_size)](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#asposepydrawingsize)|
|get_thumbnail(options)|[get_image(options: ITiffOptions)](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#asposeslidesexportitiffoptions)|
|get_thumbnail(options)|[get_image(options: IRenderingOptions)](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions)|
|get_thumbnail(options, scale_x, scale_y)|[get_image(options, scale_x, scale_y)](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-float-float)|
|get_thumbnail(options, image_size)|[get_image(options, image_size)](https://reference.aspose.com/slides/id/python-net/aspose.slides/slide/get_image/#asposeslidesexportirenderingoptions-asposepydrawingsize)|
|render_to_graphics(options, graphics)|Tidak ada pengganti API Modern|
|render_to_graphics(options, graphics, scale_x, scale_y)|Tidak ada pengganti API Modern|
|render_to_graphics(options, graphics, rendering_size)|Tidak ada pengganti API Modern|

### **Shape Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|get_thumbnail()|[get_image()](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/#)|
|get_thumbnail(bounds, scale_x, scale_y)|[get_image(bounds, scale_x, scale_y)](https://reference.aspose.com/slides/id/python-net/aspose.slides/shape/get_image/#shapethumbnailbounds-float-float)|

### **ImageCollection Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|add_image(image: aspose.pydrawing.Image)|[add_image(image)](https://reference.aspose.com/slides/id/python-net/aspose.slides/imagecollection/add_image/#iimage)|

### **PPImage Class**

|Tanda Tangan Metode/Properti|Tanda Tangan Metode/Properti Pengganti|
| :- | :- |
|replace_image(new_image: aspose.pydrawing.Image)|[replace_image(new_image)](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/replace_image/#iimage)|
|system_image|[image](https://reference.aspose.com/slides/id/python-net/aspose.slides/ppimage/image/)|

### **ImageWrapperFactory Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|create_image_wrapper(image: aspose.pydrawing.Image)|[create_image_wrapper(image)](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimagewrapperfactory/create_image_wrapper/#iimage)|

### **PatternFormat Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile(background, foreground)](https://reference.aspose.com/slides/id/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor-asposepydrawingcolor)|
|get_tile_image(style_color)|[get_tile(style_color)](https://reference.aspose.com/slides/id/python-net/aspose.slides/patternformat/get_tile/#asposepydrawingcolor)|

### **IPatternFormatEffectiveData Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|get_tile_image(background, foreground)|[get_tile_i_image(background, foreground)](https://reference.aspose.com/slides/id/python-net/aspose.slides/ipatternformateffectivedata/get_tile_i_image/#asposepydrawingcolor-asposepydrawingcolor)|

### **Output Class**

|Tanda Tangan Metode|Tanda Tangan Metode Pengganti|
| :- | :- |
|add(path, image: aspose.pydrawing.Image)|[add(path, image)](https://reference.aspose.com/slides/id/python-net/aspose.slides.export.web/output/add/#str-iimage)|

## **Dukungan API untuk aspose.pydrawing.Graphics**

Metode yang menggunakan `aspose.pydrawing.Graphics` tidak lagi direkomendasikan dan tidak memiliki pengganti langsung di API Modern.

Gunakan metode rendering gambar API Modern alih-alih API yang merender ke `aspose.pydrawing.Graphics`:
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, scale_x, scale_y)`
- `aspose.pydrawing.Slide.render_to_graphics(options, graphics, rendering_size)`

# **FAQ**

**Mengapa `aspose.pydrawing.Graphics` dihilangkan?**

Dukungan untuk `aspose.pydrawing.Graphics` tidak lagi direkomendasikan dalam API publik untuk menyatukan kerja dengan rendering dan gambar, menghilangkan ketergantungan pada platform tertentu, serta beralih ke pendekatan lintas platform dengan [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/). Gunakan `get_image` atau `get_images` alih-alih merender ke `aspose.pydrawing.Graphics`.

**Apa manfaat praktis dari [IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) dibandingkan `aspose.pydrawing.Image`/`aspose.pydrawing.Bitmap`?**

[IImage](https://reference.aspose.com/slides/id/python-net/aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor, menyederhanakan penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/id/python-net/aspose.slides/imageformat/), mengurangi ketergantungan pada pydrawing, dan membuat kode lebih portabel antar lingkungan.

**Apakah API Modern memengaruhi kinerja pembuatan thumbnail?**

Berpindah dari `get_thumbnail` ke `get_image` tidak memperburuk skenario: metode baru memberikan kemampuan yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil tetap mendukung opsi rendering. Keuntungan atau penurunan spesifik tergantung pada skenario, tetapi secara fungsional pengganti tersebut setara.