---
title: "Dia's verwijderen uit presentaties op Android"
linktitle: "Dia verwijderen"
type: docs
weight: 30
url: /nl/androidjava/remove-slide-from-presentation/
keywords:
- dia verwijderen
- dia wissen
- ongebruikte dia verwijderen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Verwijder moeiteloos dia's uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor Android. Bekijk duidelijke Java-codevoorbeelden en verbeter uw workflow."
---
## **Introductie**

Als een dia (of de inhoud ervan) overbodig wordt, kun je deze verwijderen. Aspose.Slides biedt de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse die [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islidecollection/) omvat, wat een opslagplaats is voor alle dia's in een presentatie. Door pointers (referentie of index) te gebruiken voor een bekende [ISlide](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/islide/) object, kun je de dia aangeven die je wilt verwijderen.

## **Dia verwijderen per referentie**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.  
2. Haal een referentie op van de dia die je wilt verwijderen via de ID of index.  
3. Verwijder de verwijzende dia uit de presentatie.  
4. Sla de aangepaste presentatie op.  

Deze Java‑code laat zien hoe je een dia via zijn referentie verwijdert:

```java
// Instantieer een Presentation-object dat een presentatiedocument vertegenwoordigt
Presentation pres = new Presentation("demo.pptx");
try {
    // Toegang tot een dia via zijn index in de diacollectie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Verwijdert een dia via zijn referentie
    pres.getSlides().remove(slide);
    
    // Slaat de aangepaste presentatie op
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Dia verwijderen per index**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/) klasse.  
2. Verwijder de dia uit de presentatie via zijn indexpositie.  
3. Sla de aangepaste presentatie op.  

Deze Java‑code laat zien hoe je een dia via zijn index verwijdert:

```java
// Instantieert een Presentation-object dat een presentatiedocument vertegenwoordigt
Presentation pres = new Presentation("demo.pptx");
try {
    // Verwijdert een dia via zijn dia-index
    pres.getSlides().removeAt(0);
    
    // Slaat de aangepaste presentatie op
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Ongebruikte lay-outdia's verwijderen**

Aspose.Slides biedt de [removeUnusedLayoutSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) methode (van de [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) klasse) om je in staat te stellen ongewenste en ongebruikte lay-outdia's te verwijderen. Deze Java‑code laat zien hoe je een lay-outdia uit een PowerPoint‑presentatie verwijdert:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ongebruikte masterslides verwijderen**

Aspose.Slides biedt de [removeUnusedMasterSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) methode (van de [Compress](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/compress/) klasse) om je in staat te stellen ongewenste en ongebruikte masterslides te verwijderen. Deze Java‑code laat zien hoe je een masterslide uit een PowerPoint‑presentatie verwijdert:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **FAQ**

**Wat gebeurt er met de dia‑indexen nadat ik een dia heb verwijderd?**

Na het verwijderen herziet de [collection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/slidecollection/) de indexen: elke volgende dia verschuift één positie naar links, waardoor eerdere indexnummers niet meer actueel zijn. Als je een stabiele referentie nodig hebt, gebruik dan de permanente ID van elke dia in plaats van de index.

**Is de ID van een dia anders dan de index, en verandert deze wanneer aangrenzende dia's worden verwijderd?**

Ja. De index is de positie van de dia en verandert wanneer dia's worden toegevoegd of verwijderd. De dia‑ID is een permanente identifier en verandert niet wanneer andere dia's worden verwijderd.

**Hoe beïnvloedt het verwijderen van een dia de secties van de presentatie?**

Als de dia tot een sectie behoorde, zal die sectie simpelweg één dia minder bevatten. De sectiestructuur blijft behouden; als een sectie leeg wordt, kun je [remove or reorganize sections](/slides/nl/androidjava/slide-section/) desgewenst verwijderen of reorganiseren.

**Wat gebeurt er met notities en opmerkingen die aan een dia zijn gekoppeld wanneer deze wordt verwijderd?**

[Notes](/slides/nl/androidjava/presentation-notes/) en [comments](/slides/nl/androidjava/presentation-comments/) zijn gekoppeld aan die specifieke dia en worden samen met deze verwijderd. De inhoud van andere dia's blijft onaangetast.

**Hoe verschilt het verwijderen van dia's van het opschonen van ongebruikte lay-outs/masters?**

Verwijderen haalt specifieke gewone dia's uit de presentatie. Het opschonen van ongebruikte lay-outs/masters verwijdert lay-out‑ of masterslides die nergens naar verwijzen, waardoor de bestandsgrootte afneemt zonder de resterende dia‑inhoud te wijzigen. Deze handelingen vullen elkaar aan: meestal eerst verwijderen, daarna opschonen.