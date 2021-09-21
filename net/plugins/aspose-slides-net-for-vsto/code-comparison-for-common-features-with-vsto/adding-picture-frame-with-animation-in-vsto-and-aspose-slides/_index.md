---
title: Adding Picture Frame with Animation in VSTO and Aspose.Slides
type: docs
weight: 20
url: /net/adding-picture-frame-with-animation-in-vsto-and-aspose-slides/
---

The code samples below create a presentation with a slide, add an image with a picture frame and applies animation to it.
## **VSTO**
Using VSTO, take the following steps:

1. Create a presentation.
1. Add an empty slide.
1. Add a picture shape to the slide.
1. Apply animation to the picture.
1. Write the presentation to disk.

``` csharp

 //Creating empty presentation

PowerPoint.Presentation pres = Globals.ThisAddIn.Application.Presentations.Add(Microsoft.Office.Core.MsoTriState.msoFalse);

//Add a blank slide

PowerPoint.Slide sld = pres.Slides.Add(1, PowerPoint.PpSlideLayout.ppLayoutBlank);

//Add Picture Frame

PowerPoint.Shape PicFrame = sld.Shapes.AddPicture("pic.jpeg",

Microsoft.Office.Core.MsoTriState.msoTriStateMixed,

Microsoft.Office.Core.MsoTriState.msoTriStateMixed, 150, 100, 400, 300);

//Applying animation on picture frame

PicFrame.AnimationSettings.EntryEffect = Microsoft.Office.Interop.PowerPoint.PpEntryEffect.ppEffectBoxIn;

//Saving Presentation

pres.SaveAs("VSTOAnim.ppt", PowerPoint.PpSaveAsFileType.ppSaveAsPresentation,

Microsoft.Office.Core.MsoTriState.msoFalse);

``` 
## **Aspose.Slides**
Using Aspose.Slides for .NET, perform the following steps:

1. Create a presentation.
1. Access the first slide.
1. Add an image to a picture collection.
1. Add a picture shape to the slide.
1. Apply animation to the picture.
1. Write the presentation to disk.

``` csharp

 //Creating empty presentation

Presentation pres = new Presentation();

//Accessing the First slide

Slide slide = pres.GetSlideByPosition(1);

//Adding the picture object to pictures collection of the presentation

Picture pic = new Picture(pres, "pic.jpeg");

//After the picture object is added, the picture is given a uniqe picture Id

int picId = pres.Pictures.Add(pic);

//Adding Picture Frame

Shape PicFrame = slide.Shapes.AddPictureFrame(picId, 1450, 1100, 2500, 2200);

//Applying animation on picture frame

PicFrame.AnimationSettings.EntryEffect = ShapeEntryEffect.BoxIn;

//Saving Presentation

pres.Write("AsposeAnim.ppt");

``` 
## **Download Sample Code**
- [Codeplex](https://asposevsto.codeplex.com/downloads/get/772946)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/download/AsposeSlidesVsVSTOv1.1/Adding.Picture.Frame.with.Animation.Aspose.Slides.zip)
- [Sourceforge](https://sourceforge.net/projects/asposevsto/files/Aspose.Slides%20Vs%20VSTO%20Slides/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Adding%20Picture%20Frame%20with%20Animation%20\(Aspose.Slides\).zip)
