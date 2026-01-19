---
title: العمل مع حجم وتخطيط العرض التقديمي
type: docs
weight: 90
url: /ar/net/working-with-size-and-layout-of-presentation/
---

**SlideSize.Type** و **SlideSize.Size** هما خاصيتان من فئة العرض التقديمي اللتين يمكن تعيينهما أو الحصول عليهما كما هو موضح أدناه في المثال.
## **مثال**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Working With Size and Layout.pptx";

//Instantiate a Presentation object that represents a presentation file 

Presentation presentation = new Presentation(FileName);

Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];

//Set the slide size of generated presentations to that of source

auxPresentation.SlideSize.Type = presentation.SlideSize.Type;

auxPresentation.SlideSize.Size = presentation.SlideSize.Size;

auxPresentation.Slides.InsertClone(0, slide);

auxPresentation.Slides.RemoveAt(0);

//Save Presentation to disk

auxPresentation.Save(FileName, Aspose.Slides.Export.SaveFormat.Pptx);

``` 
## **تحميل مثال الكود**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **تحميل مثال التشغيل**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Working%20With%20Size%20and%20Layout)

{{% alert color="primary" %}} 

للمزيد من التفاصيل، زر [تغيير حجم شريحة العرض التقديمي في .NET](/slides/ar/net/slide-size/).

{{% /alert %}}