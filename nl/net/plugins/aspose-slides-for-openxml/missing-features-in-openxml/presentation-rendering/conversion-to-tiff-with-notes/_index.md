---
title: Conversie naar Tiff met notities
type: docs
weight: 10
url: /nl/net/conversion-to-tiff-with-notes/
---
TIFF is een van de verschillende veelgebruikte beeldformaten die Aspose.Slides voor .NET ondersteunt voor het converteren van een presentatie met aantekeningen naar afbeeldingen. Je kunt ook miniatuurafbeeldingen van dia's genereren in de Notitiesdia‑weergave. Hieronder staan twee codefragmenten die laten zien hoe je TIFF‑afbeeldingen van een presentatie in de Notitiesdia‑weergave kunt genereren.

De **Save**‑methode die wordt aangeboden door de **Presentation**‑klasse kan worden gebruikt om de volledige presentatie in de Notitiesdia‑weergave naar TIFF te converteren. Je kunt ook een miniatuurafbeelding van een dia in de Notitiesdia‑weergave genereren voor individuele dia’s.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

    //Maak een Presentation-object aan dat een presentatiebestand vertegenwoordigt
using (Presentation pres = new Presentation(srcFileName))
{
    //Plaats de sprekernotities onder elke gerenderde dia
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //Sla de presentatie op naar TIFF met notities
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)