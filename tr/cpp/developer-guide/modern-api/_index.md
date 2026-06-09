---
title: Modern API ile Görüntü İşlemeyi Geliştirin
linktitle: Modern API
type: docs
weight: 280
url: /tr/cpp/modern-api/
keywords:
- System.Drawing
- modern API
- çizim
- slayt küçük resmi
- slayttan görüntüye
- şekil küçük resmi
- şekilden görüntüye
- sunum küçük resmi
- sunumu görüntülere
- görüntü ekle
- resim ekle
- C++
- Aspose.Slides
description: "Eskiden kullanımdan kaldırılmış görüntüleme API'lerini C++ Modern API ile değiştirerek slayt görüntü işlemesini modernleştirin ve PowerPoint ile OpenDocument otomasyonunu sorunsuz hale getirin."
---
## **Giriş**

Şu anda, Aspose.Slides for C++ kitaplığı, genel API'sinde System::Drawing sınıflarına bağımlılıklara sahiptir:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/tr/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/tr/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/tr/cpp/system.drawing/bitmap/)

24.4 sürümünden itibaren, bu genel API kullanım dışı olarak ilan edilmiştir.

Genel API'deki System::Drawing bağımlılıklarından kurtulmak için, sözde "Modern API"yi ekledik. [System::Drawing::Image] ve [System::Drawing::Bitmap] içeren yöntemler kullanım dışı olarak işaretlenmiştir ve Modern API'deki karşılık gelen yöntemlerle değiştirilmeleri gerekir. [System::Drawing::Graphics] içeren yöntemler kullanım dışı olarak işaretlenmiş ve doğrudan Modern API karşılığı yoktur.

Geçerli sürümlerde, System::Drawing türlerine bağlı genel API'yi eski/kullanım dışı olarak değerlendirin. Yeni kod için ve mevcut görüntü işleme iş akışlarını taşırken Modern API'yi kullanın.

## **Modern API**

Genel API'ye aşağıdaki sınıflar ve enum'lar eklendi:

- [Aspose::Slides::IImage](https://reference.aspose.com/slides/tr/cpp/aspose.slides/iimage/) - raster veya vektör görüntüyü temsil eder.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/tr/cpp/aspose.slides/imageformat/) - görüntünün dosya formatını temsil eder.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/tr/cpp/aspose.slides/images/) - IImage arayüzünü başlatmak ve onunla çalışmak için yöntemler.

Tek bir slayt veya şekil oluşturmak için `GetImage` kullanın. Birden fazla sunum slaytı oluşturmak için `GetImages` kullanın. Görüntüleri yüklemek için [Images] yöntemlerini, sunuma eklemek için `AddImage` ile [IImage] kullanın ve mevcut bir sunum görüntüsünü güncellemek için `ReplaceImage` ile [IImage] kullanın.

Yeni API'yi kullanmanın tipik bir senaryosu aşağıdaki gibi görünebilir:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// diskteki dosyadan kullanımı sona erdirilebilir bir IImage örneği oluştur.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// sunumun görüntülerine bir IImage örneği ekleyerek PowerPoint görüntüsü oluştur.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// slayt #1 üzerine bir resim şekli ekle
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// slayt #1'i temsil eden IImage örneğini al.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// görüntüyü diske kaydet.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **Eski Kodu Modern API ile Değiştirme**

Geçişi kolaylaştırmak için, yeni [IImage] arayüzü [System::Drawing::Image] ve [System::Drawing::Bitmap] sınıflarının ayrı imzalarını tekrar eder. Genel olarak, System::Drawing kullanan eski yöntemi yeniyle değiştirmek yeterlidir.

### **Slayt Küçük Resmi Almak**

Eski/kullanım dışı API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **Şekil Küçük Resmi Almak**

Eski/kullanım dışı API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

Modern API:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **Sunum Küçük Resmi Almak**

Eski/kullanım dışı API:

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

### **Sunuma Resim Eklemek**

Eski/kullanım dışı API:

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

## **Kullanım Dışı Yöntemler/Özellikler ve Modern API'deki Yerine Geçmeleri**

### **Presentation Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **Slide Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
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

### **Shape Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **ImageCollection Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **PPImage Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **PatternFormat Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **IPatternFormatEffectiveData Sınıfı**
|Yöntem İmzası|Yerine Geçen Yöntem İmzası|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **System::Drawing::Graphics için API Desteği**

[System::Drawing::Graphics] içeren yöntemler kullanım dışı olarak ilan edilmiştir ve doğrudan Modern API karşılığı yoktur.

Sunumu [System::Drawing::Graphics] üzerine çizen API yerine Modern API görüntü oluşturma yöntemlerini kullanın:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/tr/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **SSS**

**Neden [System::Drawing::Graphics] kaldırıldı?**

Genel API'de [System::Drawing::Graphics] desteği, oluşturma ve görüntülerle çalışma birleştirilerek, platforma özgü bağımlılıklar ortadan kaldırılarak ve [IImage] ile çapraz platform yaklaşımına geçilerek kullanım dışı bırakıldı. [System::Drawing::Graphics] yerine `GetImage` veya `GetImages` kullanın.

**[IImage]'in [System::Drawing::Image]/[System::Drawing::Bitmap] ile karşılaştırmalı pratik faydası nedir?**

[IImage] raster ve vektör görüntülerle çalışmayı birleştirir, [ImageFormat] aracılığıyla çeşitli formatlarda kaydetmeyi basitleştirir, `System::Drawing` bağımlılığını azaltır ve kodun ortamlar arasında daha taşınabilir olmasını sağlar.

**Modern API, küçük resim oluşturma performansını etkiler mi?**

`GetThumbnail`'tan `GetImage`'a geçiş senaryoları kötüleştirmez: yeni yöntemler aynı seçenekler ve boyutlarla görüntü üretme yeteneğini sağlar ve oluşturma seçeneklerini korur. Kazanç veya kayıp senaryoya bağlıdır, ancak fonksiyonel olarak değiştirmeler eşdeğerdir.