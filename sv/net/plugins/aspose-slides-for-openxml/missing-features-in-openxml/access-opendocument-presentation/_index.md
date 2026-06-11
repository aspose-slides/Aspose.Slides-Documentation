---
title: Åtkomst till OpenDocument-presentation
type: docs
weight: 10
url: /sv/net/access-opendocument-presentation/
---
Aspose.Slides for .NET erbjuder **Presentation**‑klassen som representerar en presentationsfil. **Presentation**‑klassen kan nu också komma åt **ODP** via **Presentation**‑konstruktorn när objektet instansieras.
## **Exempel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "OpenDocument Presentation.odp";

string destFileName = FilePath + "OpenDocument Presentation.pptx";

//Instansiera ett Presentation-objekt som representerar en presentationsfil

using (Presentation pres = new Presentation(srcFileName))

{

    //Sparar PPTX-presentationen i PPTX-format

    pres.Save(destFileName, SaveFormat.Pptx);

}
``` 
## **Ladda ner exempel på kod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ladda ner körbart exempel**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/OpenDocument%20Presentation)