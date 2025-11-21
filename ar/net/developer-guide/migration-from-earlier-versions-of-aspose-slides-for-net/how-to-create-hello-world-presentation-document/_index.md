---
title: كيف تنشئ عروض تقديمية Hello World في .NET
linktitle: عرض Hello World
type: docs
weight: 10
url: /ar/net/how-to-create-hello-world-presentation-document/
keywords:
- ترحيل
- مرحبا بالعالم
- شفرة قديمة
- شفرة حديثة
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء عرض تقديمي PowerPoint PPT, PPTX و ODP Hello World في .NET باستخدام Aspose.Slides عبر كل من الواجهات القديمة والحديثة في دليل بسيط."
---

{{% alert color="primary" %}} 
تم إصدار واجهة برمجة تطبيقات [Aspose.Slides for .NET API](/slides/ar/net/) جديدة الآن ويدعم هذا المنتج الموحد القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل الموجود منها.
{{% /alert %}} 
## **دعم الشيفرة القديمة**
للتعامل مع الشيفرة القديمة التي تم تطويرها باستخدام إصدارات Aspose.Slides for .NET السابقة للنسخة 13.x، تحتاج إلى إجراء بعض التعديلات البسيطة في الكود الخاص بك سيعمل الكود كما كان من قبل. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديم تحت مساحات الأسماء Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة الاسم الوحيدة Aspose.Slides. يرجى إلقاء نظرة على المقتطف البرمجي البسيط التالي لإنشاء مستند عرض تقديمي «Hello World» باستخدام واجهة Aspose.Slides القديمة واتبع الخطوات التي تصف كيفية الانتقال إلى واجهة البرمجة المدمجة الجديدة.
## **نهج Aspose.Slides for .NET القديم**
```c#
//إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();

//إنشاء كائن License
License license = new License();

//تعيين ترخيص Aspose.Slides for .NET لتجنب قيود التقييم
license.SetLicense("Aspose.Slides.lic");

//إضافة شريحة فارغة إلى العرض والحصول على مرجع
//تلك الشريحة الفارغة
Slide slide = pres.AddEmptySlide();

//إضافة مستطيل (X=2400, Y=1800, العرض=1000 والارتفاع=500) إلى الشريحة
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//إخفاء خطوط المستطيل
rect.LineFormat.ShowLines = false;

//إضافة إطار نص إلى المستطيل بالنص الافتراضي "Hello World"
rect.AddTextFrame("Hello World");

//إزالة الشريحة الأولى من العرض التي يتم إضافتها دائمًا بواسطة
//Aspose.Slides for .NET بشكل افتراضي عند إنشاء العرض
pres.Slides.RemoveAt(0);

//كتابة العرض كملف PPT
pres.Write("C:\\hello.ppt");
```


## **نهج Aspose.Slides for .NET 13.x الجديد**
```c#
// إنشاء كائن Presentation
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = (ISlide)pres.Slides[0];

// إضافة AutoShape من النوع Rectangle
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// إضافة ITextFrame إلى المستطيل
ashp.AddTextFrame("Hello World");

// تغيير لون النص إلى أسود (وهو أبيض بشكل افتراضي)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// تغيير لون خط المستطيل إلى أبيض
ashp.ShapeStyle.LineColor.Color = Color.White;

// إزالة أي تنسيق تعبئة في الشكل
ashp.FillFormat.FillType = FillType.NoFill;

// حفظ العرض التقديمي على القرص
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
