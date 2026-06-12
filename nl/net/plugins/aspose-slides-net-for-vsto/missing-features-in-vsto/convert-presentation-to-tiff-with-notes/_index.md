---
title: Presentatie converteren naar Tiff met notities
type: docs
weight: 50
url: /nl/net/convert-presentation-to-tiff-with-notes/
---
TIFF is een van de vele veelgebruikte afbeeldingsformaten die Aspose.Slides voor .NET ondersteunt voor het converteren van een presentatie met notities naar afbeeldingen. U kunt ook miniatuurafbeeldingen van dia's genereren in de Notities‑diaweergave. Hieronder staan twee codefragmenten die laten zien hoe u TIFF‑afbeeldingen van een presentatie in de Notities‑diaweergave kunt genereren.

De [Save](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/methods/save)‑methode die door de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)‑klasse wordt aangeboden, kan worden gebruikt om de volledige presentatie in de Notities‑diaweergave naar TIFF te converteren. U kunt ook een miniatuurafbeelding van een dia genereren in de Notities‑diaweergave voor individuele dia's.
## **Voorbeeld**

``` 

  //Instantieer een Presentation‑object dat een presentatie‑bestand vertegenwoordigt

 Presentation pres = new Presentation("Conversion.pptx");

 //De presentatie opslaan als TIFF‑notities

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Download werkend voorbeeld**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Download voorbeeldcode**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

Voor meer details, bezoek [Converteer PowerPoint‑presentaties naar TIFF met notities in .NET](/slides/nl/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}