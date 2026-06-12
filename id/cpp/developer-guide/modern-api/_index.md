---
title: Meningkatkan Pemrosesan Gambar dengan API Modern
linktitle: API Modern
type: docs
weight: 280
url: /id/cpp/modern-api/
keywords:
- System.Drawing
- API modern
- menggambar
- thumbnail slide
- slide ke gambar
- thumbnail bentuk
- bentuk ke gambar
- thumbnail presentasi
- presentasi ke gambar
- tambah gambar
- tambah foto
- C++
- Aspose.Slides
description: Modernisasi pemrosesan gambar slide dengan menggantikan API imaging yang usang dengan API Modern C++ untuk otomatisasi PowerPoint dan OpenDocument yang mulus.
---
## **Pendahuluan**

Saat ini, pustaka Aspose.Slides untuk C++ memiliki ketergantungan dalam API publiknya pada kelas-kelas berikut dari System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/id/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/id/cpp/system.drawing/bitmap/)

Mulai versi 24.4, API publik ini dinyatakan usang.

Untuk menghilangkan ketergantungan pada System::Drawing dalam API publik, kami menambahkan apa yang disebut “Modern API”. Metode dengan [System::Drawing::Image](https://reference.aspose.com/slides/id/cpp/system.drawing/image/) dan [System::Drawing::Bitmap](https://reference.aspose.com/slides/id/cpp/system.drawing/bitmap/) dinyatakan usang dan harus diganti dengan metode yang bersesuaian dari Modern API. Metode dengan [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/) dinyatakan usang dan tidak memiliki pengganti Modern API secara langsung.

Dalam versi saat ini, perlakukan API publik yang bergantung pada tipe System::Drawing sebagai warisan/usang. Gunakan Modern API untuk kode baru dan ketika memigrasikan alur kerja pemrosesan gambar yang ada.

## **Modern API**

Ditambahkan kelas dan enumerasi berikut ke API publik:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) - mewakili gambar raster atau vektor.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/) - mewakili format berkas gambar.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/id/cpp/aspose.slides/images/) - metode untuk membuat instance dan bekerja dengan antarmuka [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/).

Gunakan `GetImage` untuk merender satu slide atau bentuk. Gunakan `GetImages` untuk merender beberapa slide presentasi. Gunakan metode [Images](https://reference.aspose.com/slides/id/cpp/aspose.slides/images/) untuk memuat gambar, `AddImage` dengan [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) untuk menambahkannya ke presentasi, dan `ReplaceImage` dengan [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) untuk memperbarui gambar presentasi yang ada.

Skenario tipikal penggunaan API baru dapat terlihat seperti berikut:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// instansiasi objek IImage yang dapat dibuang dari berkas di disk.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// buat gambar PowerPoint dengan menambahkan instance IImage ke gambar presentasi.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// tambahkan bentuk gambar pada slide #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// dapatkan instance IImage yang mewakili slide #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// simpan gambar ke disk.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Mengganti Kode Lama dengan Modern API**

Untuk memudahkan transisi, antarmuka dari [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) yang baru mengulangi tanda tangan terpisah dari kelas [System::Drawing::Image](https://reference.aspose.com/slides/id/cpp/system.drawing/image/) dan [System::Drawing::Bitmap](https://reference.aspose.com/slides/id/cpp/system.drawing/bitmap/). Secara umum, Anda hanya perlu mengganti panggilan ke metode lama yang menggunakan System::Drawing dengan yang baru.

### **Mendapatkan Thumbnail Slide**

API warisan/usang:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Mendapatkan Thumbnail Bentuk**

API warisan/usang:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Mendapatkan Thumbnail Presentasi**

API warisan/usang:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **Menambahkan Gambar ke Presentasi**

API warisan/usang:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **Metode/Properti Usang dan Penggantinya di Modern API**

### **Kelas Presentation**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Kelas Slide**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|No Modern API replacement|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|No Modern API replacement|

### **Kelas Shape**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **Kelas ImageCollection**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **Kelas PPImage**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **Kelas PatternFormat**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **Kelas IPatternFormatEffectiveData**
|Signature Metode|Signature Metode Pengganti|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **Dukungan API untuk System::Drawing::Graphics**

Metode dengan [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/) dinyatakan usang dan tidak memiliki pengganti Modern API secara langsung.

Gunakan metode rendering gambar Modern API sebagai gantinya API yang merender ke [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/id/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **FAQ**

**Mengapa [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/) dihapus?**

Dukungan untuk [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/) dinyatakan usang dalam API publik untuk menyatukan pekerjaan rendering dan gambar, menghilangkan ketergantungan pada platform tertentu, dan beralih ke pendekatan lintas platform dengan [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/). Gunakan `GetImage` atau `GetImages` alih-alih merender ke [System::Drawing::Graphics](https://reference.aspose.com/slides/id/cpp/system.drawing/graphics/).

**Apa manfaat praktis [IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) dibandingkan [System::Drawing::Image](https://reference.aspose.com/slides/id/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/id/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/id/cpp/aspose.slides/iimage/) menyatukan kerja dengan gambar raster dan vektor, menyederhanakan penyimpanan ke berbagai format melalui [ImageFormat](https://reference.aspose.com/slides/id/cpp/aspose.slides/imageformat/), mengurangi ketergantungan pada `System::Drawing`, dan membuat kode lebih portabel di berbagai lingkungan.

**Apakah Modern API akan memengaruhi kinerja pembuatan thumbnail?**

Berpindah dari `GetThumbnail` ke `GetImage` tidak memperburuk skenario: metode baru memberikan kemampuan yang sama untuk menghasilkan gambar dengan opsi dan ukuran, sambil mempertahankan dukungan untuk opsi rendering. Keuntungan atau penurunan spesifik tergantung pada skenario, namun secara fungsional penggantinya setara.