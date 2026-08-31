---
title: Conversion to Tiff with Notes
type: docs
weight: 10
url: /net/conversion-to-tiff-with-notes/
---

TIFF is one of several widely used image formats that Aspose.Slides for .NET supports for converting a presentation with notes to images. You can also generate slide thumbnails in the Notes Slide view. Below are two code snippets that shows how to generate TIFF images of a presentation in Notes Slide view.

The **Save** method exposed by the **Presentation** Class can be used to convert the whole presentation in Notes Slide view to TIFF. You can also generate a slide thumbnail in Notes Slide view for individual slides.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantiate a Presentation object that represents a presentation file
using (Presentation pres = new Presentation(srcFileName))
{
    //Place the speaker notes under each rendered slide
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Saving the presentation to TIFF with notes
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)
