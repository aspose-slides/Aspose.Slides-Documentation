---
title: Access OpenDocument Presentation
type: docs
weight: 10
url: /net/access-opendocument-presentation/
---

Aspose.Slides for .NET offers **Presentation** class that represents a presentation file.**Presentation** class can now also access **ODP** through **Presentation** constructor when the object is instantiated.
## **Example**
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
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Download Running Example**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)


