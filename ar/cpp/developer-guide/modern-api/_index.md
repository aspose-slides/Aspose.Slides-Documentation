---
title: واجهة برمجة التطبيقات الحديثة
type: docs
weight: 280
url: /cpp/modern-api/
keywords: "واجهة برمجة التطبيقات الحديثة، الرسم"
description: "واجهة برمجة التطبيقات الحديثة"
---

## المقدمة

حالياً، لدى مكتبة Aspose.Slides لـ C++ تبعيات في واجهتها العامة على الفئات التالية من System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

اعتبارًا من الإصدار 24.4، تم إعلان هذه الواجهة العامة كمتهالكة.

للتخلص من التبعيات على System::Drawing في الواجهة العامة، أضفنا ما يُسمى "واجهة برمجة التطبيقات الحديثة". تم إعلان الطرق التي تستخدم System::Drawing::Image و System::Drawing::Bitmap كمتهالكة وسيتم استبدالها بالطرق المقابلة من واجهة برمجة التطبيقات الحديثة. تم إعلان دعم System::Graphics كمتهالك وسيتم إزالته من الواجهة العامة.

سيكون إزالة الواجهة العامة المتهالكة مع التبعيات على System::Drawing في الإصدار 24.8.

## واجهة برمجة التطبيقات الحديثة

تم إضافة الفئات والتعدادات التالية إلى الواجهة العامة:

- Aspose::Slides::IImage - تمثل الصورة النقطية أو المتجهة.
- Aspose::Slides::ImageFormat - تمثل تنسيق الملف للصورة.
- Aspose::Slides::Images - طرق لإنشاء والعمل مع واجهة IImage.

قد يبدو سيناريو نموذجي لاستخدام الواجهة الجديدة كما يلي:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// إنشاء مثيل يمكن التخلص منه من IImage من الملف على القرص.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// إنشاء صورة PowerPoint عن طريق إضافة مثيل من IImage إلى صور العرض التقديمي.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// إضافة شكل صورة على الشريحة #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// الحصول على مثيل من IImage يمثل الشريحة #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// حفظ الصورة على القرص.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## استبدال الشيفرة القديمة بواجهة برمجة التطبيقات الحديثة

لتسهيل الانتقال، تكرر واجهة IImage الجديدة التوقيعات المنفصلة لفئات Image و Bitmap. بشكل عام، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة التي تستخدم System::Drawing بالطريقة الجديدة.

### الحصول على صورة مصغرة للشريحة

كود باستخدام واجهة برمجة التطبيقات المتهالكة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

واجهة برمجة التطبيقات الحديثة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### الحصول على صورة مصغرة لشكل

كود باستخدام واجهة برمجة التطبيقات المتهالكة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

واجهة برمجة التطبيقات الحديثة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### الحصول على صورة مصغرة للعرض التقديمي

كود باستخدام واجهة برمجة التطبيقات المتهالكة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

واجهة برمجة التطبيقات الحديثة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### إضافة صورة إلى عرض تقديمي

كود باستخدام واجهة برمجة التطبيقات المتهالكة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

واجهة برمجة التطبيقات الحديثة:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## الطرق/الخصائص التي سيتم إزالتها واستبدالها في واجهة برمجة التطبيقات الحديثة

### فئة العرض التقديمي
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|ستتم إزالته تمامًا|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|ستتم إزالته تمامًا|

### فئة الشريحة
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|ستتم إزالته تمامًا|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|ستتم إزالته تمامًا|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|ستتم إزالته تمامًا|

### فئة الشكل
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### فئة مجموعة الصور
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### فئة PPImage
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### فئة PatternFormat
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### فئة IPatternFormatEffectiveData
|توقيع الطريقة|توقيع الوقت البديل|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## دعم واجهة برمجة التطبيقات لـ System::Drawing::Graphics سيتوقف

تم إعلان الطرق التي تستخدم [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) كمتهالكة وسيتم إزالة دعمها من الواجهة العامة.

سيتم إزالة الجزء من واجهة برمجة التطبيقات الذي يستخدمها:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)