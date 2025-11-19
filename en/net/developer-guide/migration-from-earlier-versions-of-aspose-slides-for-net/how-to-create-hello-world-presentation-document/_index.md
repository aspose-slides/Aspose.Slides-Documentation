---
title: How to Create Hello World Presentations in .NET
linktitle: Hello World Presentation
type: docs
weight: 10
url: /net/how-to-create-hello-world-presentation-document/
keywords:
- migration
- hello world
- legacy code
- modern code
- legacy approach
- modern approach
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
- description: "Create a Hello World PowerPoint PPT, PPTX and ODP presentation in .NET with Aspose.Slides using both legacy and modern APIs in one simple guide."
---

{{% alert color="primary" %}} 

A new [Aspose.Slides for .NET API](/slides/net/) has been released and now this single product supports the capability to generate PowerPoint documents from scratch and editing the existing ones.

{{% /alert %}} 
## **Support for Legacy code**
In order to use the legacy code developed with Aspose.Slides for .NET versions earlier to 13.x, you need to make some minor changes in your code and the code will work as earlier. All the classes that were present in old Aspose.Slides for .NET under Aspose.Slide and Aspose.Slides.Pptx namespaces are now merged in single Aspose.Slides namespace. Please take a look over the following simple code snippet for creating a Hello World Presentation document in legacy Aspose.Slides API and follow the steps describing how to migrate to new merged API.
## **Legacy Aspose.Slides for .NET approach**
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



## **New Aspose.Slides for .NET 13.x approach**
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

