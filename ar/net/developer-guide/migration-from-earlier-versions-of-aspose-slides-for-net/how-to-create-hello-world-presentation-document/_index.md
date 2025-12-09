---
title: كيف تنشئ عروض تقديمية Hello World في .NET
linktitle: عرض تقديمي Hello World
type: docs
weight: 10
url: /ar/net/how-to-create-hello-world-presentation-document/
keywords:
- الترحيل
- مرحبا بالعالم
- الكود القديم
- الكود الحديث
- النهج القديم
- النهج الحديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
- description: "إنشاء عرض تقديمي Hello World PowerPoint بصيغ PPT و PPTX و ODP في .NET باستخدام Aspose.Slides عبر كل من الواجهات القديمة والحديثة في دليل بسيط واحد."
---

{{% alert color="primary" %}} 
تم إصدار واجهة برمجة تطبيقات [Aspose.Slides for .NET API](/slides/ar/net/) جديدة الآن وتدعم الآن هذا المنتج الواحد القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **دعم الكود القديم**
للاستخدام الكود القديم الذي تم تطويره باستخدام Aspose.Slides for .NET الإصدارات السابقة لـ 13.x، تحتاج إلى إجراء بعض التغييرات الصغيرة في كودك وسيتعمل الكود كما كان سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديم تحت مساحات الأسماء Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة اسم واحدة Aspose.Slides. يرجى إلقاء نظرة على المقتطف البرمجي البسيط التالي لإنشاء مستند عرض تقديمي Hello World باستخدام API القديم لـ Aspose.Slides واتبع الخطوات التي تصف كيفية الانتقال إلى API المدمج الجديد.
## **المنهج القديم لـ Aspose.Slides for .NET**
```c#
//إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();

//إنشاء كائن License
License license = new License();

//ضبط رخصة Aspose.Slides for .NET لتجنب قيود التقييم
license.SetLicense("Aspose.Slides.lic");

//إضافة شريحة فارغة إلى العرض والحصول على مرجع
//تلك الشريحة الفارغة
Slide slide = pres.AddEmptySlide();

//إضافة مستطيل (X=2400, Y=1800, العرض=1000 والارتفاع=500) إلى الشريحة
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//إخفاء خطوط المستطيل
rect.LineFormat.ShowLines = false;

//إضافة إطار نص إلى المستطيل بنص "Hello World" كالنص الافتراضي
rect.AddTextFrame("Hello World");

//إزالة الشريحة الأولى من العرض التي يتم إضافتها دائمًا بواسطة
//Aspose.Slides for .NET بشكل افتراضي أثناء إنشاء العرض
pres.Slides.RemoveAt(0);

//كتابة العرض كملف PPT
pres.Write("C:\\hello.ppt");
```

## **المنهج الجديد لـ Aspose.Slides for .NET 13.x**
```c#
// إنشاء كائن Presentation
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = (ISlide)pres.Slides[0];

// إضافة AutoShape من نوع Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// إضافة ITextFrame إلى المستطيل
ashp.AddTextFrame("Hello World");

// تغيير لون النص إلى الأسود (الذي يكون أبيض بشكل افتراضي)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// تغيير لون حد المستطيل إلى الأبيض
ashp.ShapeStyle.LineColor.Color = Color.White;

// إزالة أي تنسيق تعبئة في الشكل
ashp.FillFormat.FillType = FillType.NoFill;

// حفظ العرض التقديمي على القرص
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
