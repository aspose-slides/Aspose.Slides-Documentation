---
title: Conversion to Tiff with Notes
type: docs
weight: 10
url: /net/conversion-to-tiff-with-notes/
---

TIFF is one of several widely used image formats that Aspose.Slides for .NET supports for converting a presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. Below are two code snippets that shows how to generate TIFF images of a presentation in Notes Slide view.

The **Save** method exposed by the **Presentation** Class can be used to convert the whole presentation in Notes Slide view to TIFF. You can also generate a slide thumbnail in Notes Slide view for individual slides.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF notes

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)
