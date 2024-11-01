---
title: Adding Shapes to Presentation
type: docs
weight: 30
url: /net/adding-shapes-to-presentation/
---

## **VSTO**
Below is the code snippet for adding line shape:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
To add a simple plain line to a selected slide of the presentation, please follow the steps below:

- Create an instance of Presentation class
- Obtain the reference of a slide by using its Index
- Add an AutoShape of Line type using AddAutoShape method exposed by Shapes object
- Write the modified presentation as a PPTX file

In the example given below, we have added a line to the first slide of the presentation.

``` csharp

   //Instantiate Prseetation class that represents the PPTX

  Presentation pres = new Presentation();

  //Get the first slide

  ISlide slide = pres.Slides[0];

  //Add an autoshape of type line

  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);

``` 
## **Download Running Code**
- [Codeplex](https://asposevsto.codeplex.com/releases/view/616670)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/SourceControl/latest#Aspose.Slides Vs VSTO Slides/Adding Shape to Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)
