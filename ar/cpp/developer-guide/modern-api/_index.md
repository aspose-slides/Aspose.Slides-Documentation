---
title: تحسين معالجة الصور باستخدام الواجهة الحديثة للبرمجة
linktitle: API الحديثة
type: docs
weight: 280
url: /ar/cpp/modern-api/
keywords:
- System.Drawing
- API حديثة
- رسم
- صورة مصغرة للشريحة
- تحويل الشريحة إلى صورة
- صورة مصغرة للشكل
- تحويل الشكل إلى صورة
- صورة مصغرة للعرض
- تحويل العرض إلى صور
- إضافة صورة
- إضافة صورة
- C++
- Aspose.Slides
description: "تحديث معالجة صور الشرائح باستبدال واجهات برمجة التطبيقات القديمة للتصوير بواجهة برمجة التطبيقات الحديثة لـ C++ لتوفير أتمتة سلسة لعروض PowerPoint ووثائق OpenDocument."
---

## **المقدمة**

حاليًا، مكتبة Aspose.Slides لـ C++ لديها اعتماديات في واجهة برمجة التطبيقات العامة على الفئات التالية من System::Drawing:
- [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/)
- [System::Drawing::Image](https://reference.aspose.com/slides/cpp/system.drawing/image/)
- [System::Drawing::Bitmap](https://reference.aspose.com/slides/cpp/system.drawing/bitmap/)

اعتبارًا من الإصدار 24.4، تم الإعلان عن إهمال هذه الواجهة العامة.

من أجل التخلص من الاعتماديات على System::Drawing في الواجهة العامة، أضفنا ما يُسمى بـ "واجهة برمجة التطبيقات الحديثة". تم إهمال الأساليب التي تستخدم System::Drawing::Image و System::Drawing::Bitmap وسيتتم استبدالها بالأساليب المقابلة من الواجهة الحديثة. تم إهمال الأساليب التي تستخدم System::Graphics وسيتم حذف دعمها من الواجهة العامة.

سيتم إزالة الواجهة العامة المهملة التي تعتمد على System::Drawing في الإصدار 24.8.

## **واجهة برمجة التطبيقات الحديثة**

تم إضافة الفئات والإنومات التالية إلى الواجهة العامة:

- Aspose::Slides::IImage - تمثل الصورة النقطية أو المتجهة.
- Aspose::Slides::ImageFormat - تمثل تنسيق ملف الصورة.
- Aspose::Slides::Images - أساليب لإنشاء والعمل مع واجهة IImage.

سيناريو نموذجي لاستخدام الواجهة الجديدة قد يبدو كما يلي:
```cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();
        
// إنشاء مثيل يمكن التخلص منه من IImage من الملف على القرص.
System::SharedPtr<IImage> image = Images::FromFile(u"image.png");
            
// إنشاء صورة PowerPoint بإضافة مثيل من IImage إلى صور العرض التقديمي.
System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);
        
// إضافة شكل صورة إلى الشريحة #1
pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
        
// الحصول على مثيل IImage يمثل الشريحة #1.
auto slideImage = pres->get_Slide(0)->GetImage(System::Drawing::Size(1920, 1080));

// حفظ الصورة على القرص.
slideImage->Save(u"slide1.jpeg", Aspose::Slides::ImageFormat::Jpeg);
```


## **استبدال الكود القديم بواجهة API الحديثة**

لتسهيل الانتقال، تكرر واجهة IImage الجديدة التواقيع المنفصلة لفئات Image و Bitmap. بشكل عام، ستحتاج فقط إلى استبدال استدعاء الطريقة القديمة باستخدام System::Drawing بالطريقة الجديدة.

### **الحصول على صورة مصغرة للشريحة**

الكود باستخدام واجهة مهملة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetThumbnail()->Save(u"slide1.png");
```


واجهة API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->GetImage()->Save(u"slide1.png");
```


### **الحصول على صورة مصغرة للشكل**

الكود باستخدام واجهة مهملة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetThumbnail()->Save(u"shape.png");
```


واجهة API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

pres->get_Slide(0)->get_Shape(0)->GetImage()->Save(u"shape.png");
```


### **الحصول على صورة مصغرة للعرض التقديمي**

الكود باستخدام واجهة مهملة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

auto bitmaps = pres->GetThumbnails(System::MakeObject<RenderingOptions>(), System::Drawing::Size(1980, 1028));

for (int32_t index = 0; index < bitmaps->get_Length(); index++)
{
    System::SharedPtr<System::Drawing::Bitmap> thumbnail = bitmaps[index];
    thumbnail->Save(System::String::Format(u"slide_{0}.png", index), System::Drawing::Imaging::ImageFormat::get_Png());
}
```


واجهة API الحديثة:
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

الكود باستخدام واجهة مهملة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<System::Drawing::Image> image = System::Drawing::Image::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


واجهة API الحديثة:
``` cpp
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<Aspose::Slides::IImage> image = Aspose::Slides::Images::FromFile(u"image.png");

System::SharedPtr<IPPImage> ppImage = pres->get_Images()->AddImage(image);

pres->get_Slide(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, ppImage);
```


## **الأساليب/الخصائص التي ستُحذف واستبدالها في الواجهة الحديثة**

### **فئة Presentation**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, float scaleX, float scaleY)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|GetThumbnails(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|GetImages(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::ArrayPtr&lt;int32_t&gt; slides, System::Drawing::Size imageSize)|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format)|Will be deleted completely|
|Save(System::String fname, System::ArrayPtr&lt;int32_t&gt; slides, Export::SaveFormat format, System::SharedPtr&lt;Export::ISaveOptions&gt; options)|Will be deleted completely|

### **فئة Slide**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(float scaleX, float scaleY)|GetImage(float scaleX, float scaleY)|
|GetThumbnail(System::Drawing::Size imageSize)|GetImage(System::Drawing::Size imageSize)|
|GetThumbnail(System::SharedPtr&lt;Export::ITiffOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, float scaleX, float scaleY)|
|GetThumbnail(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|GetImage(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::Drawing::Size imageSize)|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics)|Will be deleted completely|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, float scaleX, float scaleY)|Will be deleted completely|
|RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt; options, System::SharedPtr&lt;System::Drawing::Graphics&gt; graphics, System::Drawing::Size renderingSize)|Will be deleted completely|

### **فئة Shape**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|GetThumbnail()|GetImage()|
|GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|GetImage(ShapeThumbnailBounds bounds, float scaleX, float scaleY)|

### **فئة ImageCollection**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|AddImage(System::SharedPtr&lt;System::Drawing::Image&gt; image)|AddImage(System::SharedPtr&lt;IImage&gt; image)|

### **فئة PPImage**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|ReplaceImage(System::SharedPtr&lt;System::Drawing::Image&gt; newImage)|ReplaceImage(System::SharedPtr&lt;Aspose::Slides::IImage&gt; newImage)|
|get_SystemImage()|get_Image()|

### **فئة PatternFormat**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTile(System::Drawing::Color background, System::Drawing::Color foreground)|
|GetTileImage(System::Drawing::Color styleColor)|GetTile(System::Drawing::Color styleColor)|

### **فئة IPatternFormatEffectiveData**
|توقيع الطريقة|توقيع الطريقة البديلة|
| :- | :- |
|GetTileImage(System::Drawing::Color background, System::Drawing::Color foreground)|GetTileIImage(System::Drawing::Color background, System::Drawing::Color foreground)|

## **ستتوقف الدعم عن System::Drawing::Graphics**

تم إعلان إهمال الأساليب التي تستخدم [System::Drawing::Graphics](https://reference.aspose.com/slides/cpp/system.drawing/graphics/) وسيتم حذف دعمها من الواجهة العامة.

الجزء المتعلق بهذه الواجهة سيُحذف:
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, float, float)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-float-float-method)
- [Slide::RenderToGraphics(System::SharedPtr&lt;Export::IRenderingOptions&gt;, System::SharedPtr&lt;System::Drawing::Graphics&gt;, System::Drawing::Size)](https://reference.aspose.com/slides/cpp/aspose.slides/slide/rendertographics/#sliderendertographicssystemsharedptrexportirenderingoptions-systemsharedptrsystemdrawinggraphics-systemdrawingsize-method)

## **الأسئلة الشائعة**

**لماذا تم إلغاء System::Drawing::Graphics؟**

يتم إزالة الدعم عن `Graphics` من الواجهة العامة لتوحيد العمل مع التصيير والصور، وإلغاء الارتباط بالاعتماديات الخاصة بالمنصات، والانتقال إلى مقاربة متعددة المنصات باستخدام [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/). سيتم حذف جميع الأساليب التي تصدر إلى `Graphics`.

**ما هي الفائدة العملية من IImage مقارنةً بـ Image/Bitmap؟**

[IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) يدمج العمل مع الصور النقطية والمتجهة، يبسط عملية الحفظ إلى صيغ متعددة عبر [ImageFormat](https://reference.aspose.com/slides/cpp/aspose.slides/imageformat/)، يقلل الاعتماد على `System::Drawing`، ويجعل الشيفرة أكثر قابلية للنقل بين البيئات.

**هل ستؤثر الواجهة الحديثة على أداء إنشاء الصور المصغرة؟**

التحويل من `GetThumbnail` إلى `GetImage` لا يضعف الأداء في السيناريوهات؛ الأساليب الجديدة توفر نفس القدرات لإنتاج الصور مع الخيارات والأحجام، مع الحفاظ على دعم خيارات التصيير. الفائدة أو الفقدان المحدد يعتمد على السيناريو، لكن من الناحية الوظيفية البدائل متكافئة.