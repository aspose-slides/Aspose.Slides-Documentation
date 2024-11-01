---
title: Rendered As Tiff
type: docs
weight: 30
url: /net/rendered-as-tiff/
---

TIFF format is known by its flexibility to accommodate multipage images and data. Keeping in view the importance and popularity of TIFF format, Aspose.Slides for .NET provides the support for converting presentations into TIFF document.
This article explains how different tiff export options:

- Converting Presentation to TIFF with default size.
- Converting Presentation to TIFF with custom size.

The **Save** method exposed by **Presentation** class can be called by developers to convert the whole presentation into **TIFF** document. Further, TiffOptions class exposes ImageSize property enabling the developer to define the size of the image if required.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the presentation to TIFF document

    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);

}

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)
