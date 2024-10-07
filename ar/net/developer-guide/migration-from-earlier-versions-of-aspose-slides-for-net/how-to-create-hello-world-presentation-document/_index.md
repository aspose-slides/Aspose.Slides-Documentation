---
title: كيفية إنشاء وثيقة عرض "Hello World"
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
---

{{% alert color="primary" %}} 

تم إصدار [Aspose.Slides for .NET API](/slides/net/) جديدة والآن يدعم هذا المنتج المفرد القدرة على إنشاء مستندات PowerPoint من الصفر وتحرير المستندات الموجودة.

{{% /alert %}} 
## **دعم الشيفرة القديمة**
لاستخدام الشيفرة القديمة التي تم تطويرها باستخدام إصدارات Aspose.Slides for .NET السابقة لـ 13.x، تحتاج إلى إجراء بعض التغييرات الطفيفة في الشيفرة الخاصة بك وستعمل الشيفرة كما كانت سابقًا. جميع الفئات التي كانت موجودة في Aspose.Slides for .NET القديمة تحت أسماء مساحات Aspose.Slide و Aspose.Slides.Pptx قد تم دمجها الآن في مساحة أسماء Aspose.Slides واحدة. يرجى النظر إلى مقتطف الشيفرة البسيط التالي لإنشاء وثيقة عرض "Hello World" باستخدام واجهة برمجة التطبيقات القديمة لـ Aspose.Slides واتباع الخطوات التي تشرح كيفية الترحيل إلى واجهة برمجة التطبيقات المدمجة الجديدة.
## **نهج Aspose.Slides for .NET القديم**
```c#
//Instantiate a Presentation object that represents a PPT file
Presentation pres = new Presentation();

//Create a License object
License license = new License();

//Set the license of Aspose.Slides for .NET to avoid the evaluation limitations
license.SetLicense("Aspose.Slides.lic");

//Adding an empty slide to the presentation and getting the reference of
//that empty slide
Slide slide = pres.AddEmptySlide();

//Adding a rectangle (X=2400, Y=1800, Width=1000 & Height=500) to the slide
Aspose.Slides.Rectangle rect = slide.Shapes.AddRectangle(2400, 1800, 1000, 500);

//Hiding the lines of rectangle
rect.LineFormat.ShowLines = false;

//Adding a text frame to the rectangle with "Hello World" as a default text
rect.AddTextFrame("Hello World");

//Removing the first slide of the presentation which is always added by
//Aspose.Slides for .NET by default while creating the presentation
pres.Slides.RemoveAt(0);

//Writing the presentation as a PPT file
pres.Write("C:\\hello.ppt");
```



## **نهج Aspose.Slides for .NET 13.x الجديد**
```c#
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
pres.Save("D:\\data\\HelloWorld.pptx", SaveFormat.Pptx);
```