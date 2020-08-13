---
title: Access OpenDocument Presentation
type: docs
weight: 10
url: /net/access-opendocument-presentation/
---

Aspose.Slides for .NET offers **Presentation** class that represents a presentation file.**Presentation** class can now also access **ODP** through **Presentation** constructor when the object is instantiated.
##### **Example**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instantiate a Presentation object that represents a presentation file

using (Presentation pres = new Presentation(srcFileName))

{

    //Saving the PPTX presentation to PPTX format

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Download Sample Code**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/releases/view/619597)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c)
## **Download Running Example**
- [Codeplex](https://asposeslidesopenxml.codeplex.com/SourceControl/latest#Aspose.Slides Features missing in OpenXML/OpenDocument Presentation/)
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)
- [Code.MSDN](https://code.msdn.microsoft.com/AsposeSlides-Features-9866600c/view/SourceCode)

{{% alert color="primary" %}} 

For more details, visit [Accessing OpenDocument Presentation](http://www.aspose.com/docs/display/slidesnet/Accessing+OpenDocument+Presentation).

{{% /alert %}}
