---
title: تعزيز معالجة الصور باستخدام API الحديثة
linktitle: API الحديثة
type: docs
weight: 280
url: /ar/cpp/modern-api/
keywords:
- System.Drawing
- API الحديثة
- الرسم
- صورة مصغرة للشريحة
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض التقديمي
- تحويل العرض التقديمي إلى صور
- إضافة صورة
- إضافة صورة
- C++
- Aspose.Slides
description: "قم بتحديث معالجة صور الشرائح عن طريق استبدال واجهات برمجة التطبيقات التصويرية المهجورة بـ API الحديثة للغة C++ لتسهيل أتمتة PowerPoint و OpenDocument."
---
## **مقدمة**

حالياً، مكتبة Aspose.Slides للغة C++ تحتوي على تبعيات في واجهة برمجة التطبيقات العامة على الفئات التالية من System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/ar/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/ar/cpp/system.drawing/bitmap/)

اعتبارًا من الإصدار 24.4، تم إعلان أن واجهة برمجة التطبيقات العامة هذه مهجورة.

من أجل التخلص من التبعيات على System::Drawing في واجهة برمجة التطبيقات العامة، أضفنا ما يُسمى بـ "Modern API". تُعلن الطرق التي تستخدم [System::Drawing::Image](https://reference.aspose.com/slides/ar/cpp/system.drawing/image/) و [System::Drawing::Bitmap](https://reference.aspose.com/slides/ar/cpp/system.drawing/bitmap/) كمهجورة ويجب استبدالها بالطرق المقابلة من Modern API. تُعلن الطرق التي تستخدم [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/) كمهجورة ولا يوجد بديل مباشر في Modern API.

في الإصدارات الحالية، اعتبر واجهة برمجة التطبيقات العامة التي تعتمد على أنواع System::Drawing كقديمة/مهجورة. استخدم Modern API للشفرة الجديدة وعند ترحيل تدفقات عمل معالجة الصور الحالية.

## **API الحديثة**

تمت إضافة الفئات والعدادات التالية إلى واجهة برمجة التطبيقات العامة:
- [Aspose::Slides::IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) - تمثّل الصورة النقطية أو المتجهة.
- [Aspose::Slides::ImageFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/) - يمثل تنسيق ملف الصورة.
- [Aspose::Slides::Images](https://reference.aspose.com/slides/ar/cpp/aspose.slides/images/) - طرق لإنشاء والعمل مع واجهة [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) .

استخدم `GetImage` لتصوير شريحة واحدة أو شكل. استخدم `GetImages` لتصوير عدة شرائح عرض. استخدم طرق [Images](https://reference.aspose.com/slides/ar/cpp/aspose.slides/images/) لتحميل الصور، `AddImage` مع [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) لإضافتها إلى عرض تقديمي، و `ReplaceImage` مع [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) لتحديث صورة عرض تقديمي موجودة.

قد يبدو سيناريو الاستخدام النموذجي للـ API الجديد على النحو التالي:

``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// إنشاء نسخة قابلة للتصرف من IImage من الملف على القرص.  
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// إنشاء صورة PowerPoint بإضافة نسخة من IImage إلى صور العرض التقديمي.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// إضافة شكل صورة على الشريحة #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// الحصول على نسخة من IImage تمثل الشريحة #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// حفظ الصورة على القرص.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```

## **استبدال الشيفرة القديمة بـ API الحديثة**

لتسهيل الانتقال، يكرر واجهة [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) التواقيع المنفصلة لفئات [System::Drawing::Image](https://reference.aspose.com/slides/ar/cpp/system.drawing/image/) و [System::Drawing::Bitmap](https://reference.aspose.com/slides/ar/cpp/system.drawing/bitmap/). بشكل عام، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة التي تستخدم System::Drawing بالواحدة الجديدة.

### **الحصول على صورة مصغرة للشريحة**

واجهة برمجة التطبيقات القديمة/المهجورة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```

API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```

### **الحصول على صورة مصغرة للشكل**

واجهة برمجة التطبيقات القديمة/المهجورة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```

API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```

### **الحصول على صورة مصغرة للعرض التقديمي**

واجهة برمجة التطبيقات القديمة/المهجورة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```

API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto images = pres->GetImages(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < images->get_Length(); index++)
{
    System::SharedPtr<IImage> thumbnail = images[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), Aspose::Slides::ImageFormat::Png);
}
```

### **إضافة صورة إلى عرض تقديمي**

واجهة برمجة التطبيقات القديمة/المهجورة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```

## **الطرق/الخصائص المهجورة واستبدالاتها في API الحديثة**

### **فئة Presentation**
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|No Modern API replacement|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|No Modern API replacement|

### **فئة Slide**
|توقيع الطريقة|توقيع طريقة الاستبدال|
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

### **فئة Shape**
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **فئة ImageCollection**
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **فئة PPImage**
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **فئة PatternFormat**
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **فئة IPatternFormatEffectiveData**
|توقيع الطريقة|توقيع طريقة الاستبدال|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **دعم API لـ System::Drawing::Graphics**

تُعلن الطرق التي تستخدم [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/) كمهجورة ولا يوجد لها بديل مباشر في Modern API.

استخدم طرق عرض الصور في Modern API بدلًا من API التي تُظهر إلى [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/):
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/ar/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **الأسئلة الشائعة**

**لماذا تم حذف [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/)?**

تم إهمال دعم [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/) في واجهة برمجة التطبيقات العامة لتوحيد العمل مع العرض والصور، وإزالة الارتباط بالاعتماديات الخاصة بالمنصة، والانتقال إلى نهج متعدد المنصات باستخدام [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/). استخدم `GetImage` أو `GetImages` بدلاً من العرض إلى [System::Drawing::Graphics](https://reference.aspose.com/slides/ar/cpp/system.drawing/graphics/).

**ما الفائدة العملية من [IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) مقارنةً بـ [System::Drawing::Image](https://reference.aspose.com/slides/ar/cpp/system.drawing/image/)/[System::Drawing::Bitmap](https://reference.aspose.com/slides/ar/cpp/system.drawing/bitmap/)?**

[IImage](https://reference.aspose.com/slides/ar/cpp/aspose.slides/iimage/) يوحد التعامل مع الصور النقطية والمتجهة، يبسط حفظها بتنسيقات مختلفة عبر [ImageFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides/imageformat/)، يقلل الاعتماد على `System::Drawing`، ويجعل الشيفرة أكثر قابلية للنقل عبر البيئات.

**هل سيؤثر Modern API على أداء إنشاء الصور المصغرة؟**

الانتقال من `GetThumbnail` إلى `GetImage` لا يؤدي إلى تدهور الأداء: الطرق الجديدة توفر نفس الإمكانيات لإنشاء الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات العرض. الكسب أو الفقد المحدد يعتمد على السيناريو، لكن من الناحية الوظيفية البدائل متكافئة.