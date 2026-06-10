---
title: OpenDocument prezentáció elérése
type: docs
weight: 10
url: /hu/net/access-opendocument-presentation/
---
Az Aspose.Slides for .NET **Presentation** osztályt biztosít, amely egy prezentációfájlt képvisel. A **Presentation** osztály mostantól a **Presentation** konstruktoron keresztül is elérheti az **ODP**-t, amikor az objektum példányosításra kerül.
## **Példa**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Példányosít egy Presentation objektumot, amely egy prezentációfájlt reprezentál

using (Presentation pres = new Presentation(srcFileName))

{

    //A PPTX prezentáció mentése PPTX formátumba

    pres.Save(destFileName, SaveFormat.Pptx);

}

```
## **Minta kód letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Futtatható példa letöltése**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)