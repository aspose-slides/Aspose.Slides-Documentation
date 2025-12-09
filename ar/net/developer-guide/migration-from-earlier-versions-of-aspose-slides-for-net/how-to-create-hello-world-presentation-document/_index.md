---
title: كيفية إنشاء عروض تقديمية Hello World في .NET
linktitle: عرض تقديمي Hello World
type: docs
weight: 10
url: /ar/net/how-to-create-hello-world-presentation-document/
keywords:
- ترحيل
- مرحبا بالعالم
- كود قديم
- كود حديث
- نهج قديم
- نهج حديث
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "إنشاء عرض تقديمي Hello World بتنسيقات PowerPoint PPT و PPTX و ODP في .NET باستخدام Aspose.Slides عبر كل من واجهات API القديمة والحديثة في دليل بسيط واحد."
---

{{% alert color="primary" %}} 
تم إصدار واجهة برمجة تطبيقات Aspose.Slides for .NET الجديدة الآن، والآن يدعم هذا المنتج القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **دعم الكود القديم**
لاستخدام الكود legacy الذي تم تطويره باستخدام إصدارات Aspose.Slides for .NET التي تسبق 13.x، تحتاج إلى إجراء بعض الت تغييرات البسيطة في الكود الخاص بك حتى يعمل كما كان سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت مساحات الأسماء Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة اسم واحدة هي Aspose.Slides. يرجى إلقاء نظرة على مقطع الكود البسيط التالي لإنشاء مستند عرض تقديمي Hello World باستخدام API القديم لـ Aspose.Slides واتبع الخطوات التي توضح كيفية الترقي إلى API المدمج الجديد.
## **نهج Aspose.Slides for .NET القديم**
```c#
//إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();

//إنشاء كائن License
License license = new License();

//تعيين رخصة Aspose.Slides for .NET لتجنب قيود التقييم
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

//إزالة الشريحة الأولى من العرض والتي يتم دائمًا إضافتها بواسطة
//Aspose.Slides for .NET بشكل افتراضي أثناء إنشاء العرض
pres.Slides.RemoveAt(0);

//كتابة العرض كملف PPT
pres.Write("C:\\hello.ppt");
```




## **نهج Aspose.Slides for .NET 13.x الجديد**
```c#
// إنشاء عرض تقديمي
Presentation pres = new Presentation();

// Get the first slide
ISlide sld = (ISlide)pres.Slides[0];

// Add an AutoShape of Rectangle type
IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

// Add ITextFrame to the Rectangle
ashp.AddTextFrame("Hello World");

// Change the text color to Black (which is White by default)
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.FillType = FillType.Solid;
ashp.TextFrame.Paragraphs[0].Portions[0].PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Change the line color of the rectangle to White
ashp.ShapeStyle.LineColor.Color = Color.White;

// Remove any fill formatting in the shape
ashp.FillFormat.FillType = FillType.NoFill;

// Save the presentation to disk
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```
