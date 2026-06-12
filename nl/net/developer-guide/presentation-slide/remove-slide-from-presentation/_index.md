---
title: Dia's verwijderen uit presentaties in .NET
linktitle: Dia verwijderen
type: docs
weight: 30
url: /nl/net/remove-slide-from-presentation/
keywords:
- dia verwijderen
- dia wissen
- ongebruikte dia verwijderen
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Verwijder moeiteloos dia's uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor .NET. Ontvang duidelijke C# codevoorbeelden en verbeter uw workflow."
---
## **Introductie**

Als een dia (of de inhoud ervan) overbodig wordt, kun je deze verwijderen. Aspose.Slides biedt de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse die [ISlideCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/islidecollection) omvat, een opslagplaats voor alle dia's in een presentatie. Met pointers (referentie of index) naar een bekende [ISlide](https://reference.aspose.com/slides/nl/net/aspose.slides/islide/) object kun je de dia aangeven die je wilt verwijderen. 

## **Dia verwijderen met referentie**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
1. Verkrijg een referentie naar de dia die je wilt verwijderen via de ID of index.  
1. Verwijder de refererende dia uit de presentatie.  
1. Sla de gewijzigde presentatie op.  

Deze C# code toont hoe je een dia via de referentie kunt verwijderen:

```c#
// Maakt een Presentation-object aan dat een presentatiebestand representeert
using (Presentation pres = new Presentation("RemoveSlideUsingReference.pptx"))
{

    // Benadert een dia via de index in de dia-collectie
    ISlide slide = pres.Slides[0];

    // Verwijdert een dia via de referentie
    pres.Slides.Remove(slide);

    // Slaat de gewijzigde presentatie op
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Dia verwijderen met index**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.  
1. Verwijder de dia uit de presentatie via de indexpositie.  
1. Sla de gewijzigde presentatie op.  

Deze C# code toont hoe je een dia via de index kunt verwijderen:

```c#
// Maakt een Presentation-object aan dat een presentatiebestand representeert
using (Presentation pres = new Presentation("RemoveSlideUsingIndex.pptx"))
{

    // Verwijdert een dia via de dia-index
    pres.Slides.RemoveAt(0);

    // Slaat de gewijzigde presentatie op
    pres.Save("modified_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Ongebruikte lay-outdia's verwijderen**

Aspose.Slides biedt de [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) methode (van de [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) klasse) waarmee je ongewenste en ongebruikte lay-outdia's kunt verwijderen. Deze C# code toont hoe je een lay-outdia uit een PowerPoint-presentatie kunt verwijderen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedLayoutSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **Ongebruikte masterdia's verwijderen**

Aspose.Slides biedt de [RemoveUnusedMasterSlides](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) methode (van de [Compress](https://reference.aspose.com/slides/nl/net/aspose.slides.lowcode/compress/) klasse) waarmee je ongewenste en ongebruikte masterdia's kunt verwijderen. Deze C# code toont hoe je een masterdia uit een PowerPoint-presentatie kunt verwijderen:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(pres);
    
    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Wat gebeurt er met dia-indexen nadat ik een dia verwijder?**

Na het verwijderen wordt de [collection](https://reference.aspose.com/slides/nl/net/aspose.slides/slidecollection/) opnieuw geïndexeerd: elke volgende dia verschuift één positie naar links, waardoor eerdere indexnummers verouderd raken. Als je een stabiele referentie nodig hebt, gebruik dan de persistente ID van elke dia in plaats van de index.

**Is de ID van een dia anders dan de index, en verandert deze wanneer aangrenzende dia's worden verwijderd?**

Ja. De index is de positie van de dia en verandert wanneer dia's worden toegevoegd of verwijderd. De dia-ID is een persistente identifier en verandert niet wanneer andere dia's worden verwijderd.

**Hoe beïnvloedt het verwijderen van een dia de secties?**

Als de dia deel uitmaakte van een sectie, zal die sectie simpelweg één dia minder bevatten. De sectiestructuur blijft bestaan; wordt een sectie leeg, kun je [secties verwijderen of reorganiseren](/slides/nl/net/slide-section/) naar behoefte.

**Wat gebeurt er met notities en opmerkingen die aan een dia zijn gekoppeld wanneer deze wordt verwijderd?**

[Notes](/slides/nl/net/presentation-notes/) en [comments](/slides/nl/net/presentation-comments/) zijn gekoppeld aan die specifieke dia en worden samen met de dia verwijderd. De inhoud van andere dia's blijft onaangetast.

**Hoe verschilt het verwijderen van dia's van het opschonen van ongebruikte lay-outs/masterdia's?**

Verwijderen verwijdert specifieke normale dia's uit de presentatie. Het opschonen van ongebruikte lay-outs/masterdia's verwijdert lay-out- of masterdia's waarnaar niets verwijst, waardoor de bestandsgrootte afneemt zonder de resterende inhoud te wijzigen. Deze handelingen vullen elkaar aan: meestal eerst verwijderen, daarna opschonen.