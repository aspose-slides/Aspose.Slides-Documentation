---
title: استبدال الصور داخل مجموعة صور العرض
type: docs
weight: 90
url: /ar/cpp/replacing-images-inside-presentation-image-collection/
---

{{% alert color="primary" %}} 

Aspose.Slides لــ C++ يتيح لك استبدال الصور المضافة في أشكال الشريحة. في هذه المقالة، سوف تتعلم كيفية استبدال الصورة المضافة في مجموعة صور العرض من خلال طرق مختلفة.

{{% /alert %}} 
## **استبدال الصورة داخل مجموعة صور العرض**
Aspose.Slides لــ C++ يوفر طريقة API بسيطة تتيح لك استبدال الصورة داخل مجموعة صور العرض بهذه الطريقة:

1. قم بتحميل ملف العرض الذي يحتوي على صورة باستخدام فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation).
1. قم بتحميل صورة من ملف في مصفوفة بايت.
1. استخدم واحدة من هذه الطرق:
   - الطريقة الأولى: استبدل الصورة المستهدفة بالصورة الجديدة في مصفوفة البايت.
   - الطريقة الثانية: قم بتحميل الصورة في كائن [Image](https://reference.aspose.com/slides/cpp/class/system.drawing.image) واستبدل الصورة المستهدفة بالصورة المحملة.
   - الطريقة الثالثة: استبدل الصورة بالصورة المضافة بالفعل في مجموعة صور العرض.
1. قم بكتابة العرض المعدل كملف PPTX.

يعرض لك هذا الرمز المثال كيفية استبدال الصورة في مجموعة صور العرض:

``` cpp
// قم بإنشاء عرض تقديمي
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"presentation.pptx");

// الطريقة الأولى
ArrayPtr<uint8_t> data = ReadAllBytes(u"image0.jpeg");
SharedPtr<IPPImage> oldImage = presentation->get_Images()->idx_get(0);
oldImage->ReplaceImage(data);

// الطريقة الثانية
SharedPtr<IImage> newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Images()->idx_get(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// الطريقة الثالثة
oldImage = presentation->get_Images()->idx_get(2);
oldImage->ReplaceImage(presentation->get_Images()->idx_get(3));

// قم بحفظ العرض
presentation->Save(u"c:\\Presentations\\TestSmart.pptx", SaveFormat::Pptx);
```