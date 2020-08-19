---
title: Convert Presentation to Tiff with Notes
type: docs
weight: 50
url: /net/convert-presentation-to-tiff-with-notes/
---

TIFF is one of several widely used image formats that Aspose.Slides for .NET supports for converting a presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. Below are two code snippets that shows how to generate TIFF images of a presentation in Notes Slide view.

The [Save](https://apireference.aspose.com/slides/net/aspose.slides/presentation/methods/save) method exposed by [Presentation](https://apireference.aspose.com/slides/net/aspose.slides/presentation) class can be used to convert the whole presentation in Notes Slide view to TIFF. You can also generate a slide thumbnail in Notes Slide view for individual slides.
#### **Example**

``` 

  //Instantiate a Presentation object that represents a presentation file

 Presentation pres = new Presentation("Conversion.pptx");

 //Saving the presentation to TIFF notes

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
#### **Download Running Example**
- [CodePlex](https://asposeslidesvsto.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in VSTO/Tiff conversion with note/)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d/view/SourceCode)
#### **Download Sample Code**
- [CodePlex](https://asposeslidesvsto.codeplex.com/releases/view/620001)
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-78d1d03d#content)

{{% alert color="primary" %}} 

For more details, visit [Converting Presentation with Notes](/slides/net/convert-powerpoint-ppt-and-pptx-to-tiff-with-notes/).

{{% /alert %}}
