---
title: كيفية إنشاء عروض تقديمية Hello World في .NET
linktitle: عرض Hello World
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
description: "إنشاء عرض تقديمي Hello World بتنسيقات PowerPoint PPT، PPTX و ODP في .NET باستخدام Aspose.Slides باستخدام كل من واجهات برمجة التطبيقات القديمة والحديثة في دليل بسيط واحد."
---
{{% alert color="info" %}} 
تم إصدار [Aspose.Slides for .NET API](/slides/ar/net/) جديد الآن ويدعم هذا المنتج الواحد القدرة على إنشاء مستندات PowerPoint من الصفر وتعديل المستندات الموجودة.
{{% /alert %}} 
## **دعم الشيفرة القديمة**
من أجل استخدام الشيفرة القديمة المطورة باستخدام إصدارات Aspose.Slides for .NET السابقة لـ 13.x، تحتاج إلى إجراء بعض التعديلات الطفيفة في الشيفرة الخاصة بك وستعمل الشيفرة كما كانت سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت مساحات الاسم Aspose.Slide و Aspose.Slides.Pptx تم دمجها الآن في مساحة اسم واحدة هي Aspose.Slides. يرجى إلقاء نظرة على المقتطف البرمجي البسيط التالي لإنشاء مستند عرض تقديمي Hello World باستخدام API القديم لـ Aspose.Slides واتبع الخطوات التي تصف كيفية الانتقال إلى API المدمج الجديد.
## **نهج Aspose.Slides for .NET القديم**
```c#
using System.Drawing;
using Aspose.Slides;

//إنشاء كائن Presentation يمثل ملف PPT
Presentation pres = new Presentation();

//إنشاء كائن License
License license = new License();

//ضبط رخصة Aspose.Slides for .NET لتجنب قيود التقييم
license.SetLicense("Aspose.Slides.lic");

//إضافة شريحة فارغة إلى العرض التقديمي والحصول على المرجع الخاص بـ
//تلك الشريحة الفارغة
Slide slide = pres.AddEmptySlide();

//إضافة مستطيل (X=2400, Y=1800, العرض=1000 والارتفاع=500) إلى الشريحة
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//إخفاء خطوط المستطيل
rect.LineFormat.ShowLines = false;

//إضافة إطار نص إلى المستطيل مع "Hello World" كنص افتراضي
rect.AddTextFrame("Hello World");

//إزالة الشريحة الأولى من العرض التقديمي التي تتم إضافتها دائمًا بواسطة
//Aspose.Slides for .NET افتراضيًا أثناء إنشاء العرض التقديمي
pres.Slides.RemoveAt(0);

//كتابة العرض التقديمي كملف PPT
pres.Write("C:\\hello.ppt");
```



## **نهج Aspose.Slides for .NET 13.x الجديد**
```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instantiate Presentation
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
pres.Save("HelloWorld.pptx", SaveFormat.Pptx);
```