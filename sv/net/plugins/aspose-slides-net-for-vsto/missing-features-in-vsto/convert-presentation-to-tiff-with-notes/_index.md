---
title: Konvertera presentation till Tiff med anteckningar
type: docs
weight: 50
url: /sv/net/convert-presentation-to-tiff-with-notes/
---
TIFF är ett av flera allmänt använda bildformat som Aspose.Slides för .NET stödjer för att konvertera en presentation med anteckningar till bilder. Du kan också generera bildminiatyrer i anteckningsbildsvyn. Nedan visas två kodsnuttar som visar hur man genererar TIFF‑bilder av en presentation i anteckningsbildsvyn.

Metoden [Save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/methods/save) som exponeras av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) kan användas för att konvertera hela presentationen i anteckningsbildsvyn till TIFF. Du kan också generera en bildminiatyr i anteckningsbildsvyn för enskilda bilder.
## **Exempel**

``` 

  //Skapa ett Presentation‑objekt som representerar en presentationsfil

 Presentation pres = new Presentation("Conversion.pptx");

 //Sparar presentationen till TIFF‑anteckningar

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **Ladda ner körbart exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **Ladda ner exempel på kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

För mer information, besök [Konvertera PowerPoint-presentationer till TIFF med anteckningar i .NET](/slides/sv/net/convert-powerpoint-to-tiff-with-notes/).

{{% /alert %}}