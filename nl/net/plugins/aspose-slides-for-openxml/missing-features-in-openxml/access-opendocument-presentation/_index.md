---  
title: Toegang tot OpenDocument-presentatie  
type: docs  
weight: 10  
url: /nl/net/access-opendocument-presentation/  
---
Aspose.Slides voor .NET biedt de **Presentation**-klasse die een presentatiebestand vertegenwoordigt. De **Presentation**-klasse kan nu ook **ODP** benaderen via de **Presentation**-constructor wanneer het object wordt aangemaakt.
## **Voorbeeld**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

using (Presentation pres = new Presentation(srcFileName))

{

    //Opslaan van de PPTX-presentatie in PPTX-formaat

    pres.Save(destFileName, SaveFormat.Pptx);

}

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Werkend voorbeeld downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)