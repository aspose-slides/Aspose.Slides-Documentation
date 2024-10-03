---
title: Conversion to XPS
type: docs
weight: 40
url: /net/conversion-to-xps/
---

**XPS** format is also widely used for exchange of data. Aspose.Slides for .NET takes care of its importance and provides the built-in support for converting a presentation into XPS document.

The **Save** method exposed by Presentation class can be used to convert the whole presentation into **XPS** document. Further, **XpsOptions** class exposes **SaveMetafileAsPng** property that can be set to true or false as per requirement.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//Instantiate a Presentation object that represents a presentation file

Presentation pres = new Presentation(srcFileName);

//Saving the presentation to TIFF document

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)
