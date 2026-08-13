---
title: كيفية إنشاء عروض تقديمية Hello World في .NET
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
description: "إنشاء عرض تقديمي PowerPoint PPT، PPTX و ODP Hello World في .NET باستخدام Aspose.Slides عبر كل من واجهات البرمجة القديمة والحديثة في دليل بسيط واحد."
---
{{% alert color="info" %}} 
تم إصدار نسخة جديدة من [Aspose.Slides for .NET API](/slides/ar/net/) والآن يدعم هذا المنتج إمكانية إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **دعم الكود القديم**
لكي تتمكن من استخدام الكود القديم المطور مع إصدارات Aspose.Slides for .NET السابقة للنسخة 13.x، تحتاج إلى إجراء بعض التغييرات البسيطة في شفرتك وسيعمل الكود كما كان مسبقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديم تحت مساحات الأسماء Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة الاسم الوحيدة Aspose.Slides. يرجى إلقاء نظرة على مقتطف الشفرة البسيط التالي لإنشاء مستند عرض تقديمي Hello World في واجهة برمجة تطبيقات Aspose.Slides القديمة واتبع الخطوات التي تصف كيفية الانتقال إلى الواجهة المدمجة الجديدة.
## **النهج القديم لـ Aspose.Slides for .NET**
```c#
using System.Drawing;
using Aspose.Slides;

//إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();

//إنشاء كائن License
License license = new License();

//ضبط ترخيص Aspose.Slides for .NET لتجنب قيود التقييم
license.SetLicense("Aspose.Slides.lic");

//إضافة شريحة فارغة إلى العرض التقديمي والحصول على مرجع
//لتلك الشريحة الفارغة
Slide slide = pres.AddEmptySlide();

//إضافة مستطيل (X=2400, Y=1800, Width=1000 & Height=500) إلى الشريحة
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//إخفاء خطوط المستطيل
rect.LineFormat.ShowLines = false;

//إضافة إطار نص إلى المستطيل بالنص الافتراضي "Hello World"
rect.AddTextFrame("Hello World");

//إزالة الشريحة الأولى من العرض التقديمي التي يتم إضافتها دائمًا بواسطة
//Aspose.Slides for .NET بشكل افتراضي أثناء إنشاء العرض التقديمي
pres.Slides.RemoveAt(0);

//كتابة العرض التقديمي كملف PPT
pres.Write("C:\\hello.ppt");
```

## **النهج الجديد لـ Aspose.Slides for .NET 13.x**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن Presentation
Presentation pres = new Presentation();

// الحصول على الشريحة الأولى
ISlide sld = (ISlide)pres.Slides[0];

// إضافة AutoShape من نوع مستطيل
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// إضافة ITextFrame إلى المستطيل
ashp.AddTextFrame("Hello World");

// تغيير لون النص إلى الأسود (وهو أبيض بشكل افتراضي)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// تغيير لون خط المستطيل إلى أبيض
ashp.ShapeStyle.LineColor.Color = Color.White;

// إزالة أي تنسيق تعبئة في الشكل
ashp.FillFormat.FillType = FillType.NoFill;

// حفظ العرض التقديمي إلى القرص
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```