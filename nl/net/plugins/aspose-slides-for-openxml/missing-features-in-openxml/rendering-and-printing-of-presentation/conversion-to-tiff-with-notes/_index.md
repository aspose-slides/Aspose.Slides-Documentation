---
title: Conversie naar Tiff met notities
type: docs
weight: 10
url: /nl/net/conversion-to-tiff-with-notes/
---
TIFF is één van de verschillende veelgebruikte beeldformaten die Aspose.Slides voor .NET ondersteunt voor het converteren van een presentatie met aantekeningen naar afbeeldingen. Je kunt ook miniaturen van dia's genereren in de Notities-diaweergave. Hieronder staan twee codefragmenten die laten zien hoe je TIFF-afbeeldingen van een presentatie in de Notities-diaweergave genereert.

De **Save**-methode die wordt blootgesteld door de **Presentation**-klasse kan worden gebruikt om de volledige presentatie in Notities-diaweergave naar TIFF te converteren. Je kunt ook een miniatuur van een dia genereren in de Notities-diaweergave voor individuele dia's.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation(srcFileName);

//Opslaan van de presentatie naar TIFF-notities

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)