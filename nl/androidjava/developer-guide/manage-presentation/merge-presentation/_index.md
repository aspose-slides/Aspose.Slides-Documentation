---
title: Presentaties efficiënt samenvoegen op Android
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/androidjava/merge-presentation/
keywords:
- PowerPoint samenvoegen
- presentaties samenvoegen
- dia's samenvoegen
- PPT samenvoegen
- PPTX samenvoegen
- ODP samenvoegen
- PowerPoint combineren
- presentaties combineren
- dia's combineren
- PPT combineren
- PPTX combineren
- ODP combineren
- Android
- Java
- Aspose.Slides
description: "Voeg moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samen met Aspose.Slides voor Android via Java, en stroomlijn uw workflow."
---
## **Overzicht**

Het samenvoegen van PowerPoint- en OpenDocument-presentaties is een veelvoorkomende taak in veel Android-applicaties, vooral bij het genereren van rapporten, het samenstellen van dia's uit verschillende bronnen, of het automatiseren van presentatieworkflows. Aspose.Slides biedt een krachtige en gebruiksvriendelijke API om meerdere PPT-, PPTX- of ODP-bestanden te combineren tot één presentatie zonder Microsoft PowerPoint, LibreOffice of OpenOffice te installeren.

In deze gids leer je hoe je PowerPoint- en OpenDocument-presentaties kunt samenvoegen met slechts een paar regels code. We leveren kant-en-klare voorbeelden en laten zien hoe je dia-opmaak, layout en andere presentatie-elementen behoudt tijdens het samenvoegproces.

Of je nu een enterprise-applicatie bouwt of een eenvoudige automatisatietool, Aspose.Slides maakt het samenvoegen van presentaties snel, betrouwbaar en schaalbaar. Aspose.Slides stelt je in staat presentaties op verschillende manieren samen te voegen. Je kunt presentaties combineren met al hun vormen, stijlen, tekst, opmaak, opmerkingen, animaties en meer—zonder je zorgen te maken over kwaliteits- of gegevensverlies.

{{% alert color="primary" %}}
Zie ook: [Clone Slides](https://docs.aspose.com/slides/nl/androidjava/clone-slides/)
{{% /alert %}}

### **Wat kan worden samengevoegd**

Met Aspose.Slides kun je samengevoegen

* volledige presentaties. Alle dia's uit de presentaties komen in één presentatie terecht
* specifieke dia's. Geselecteerde dia's komen in één presentatie terecht
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar.

### **Samenvoegopties**

Je kunt opties toepassen die bepalen of

* elke dia in de uitvoerpresentatie een unieke stijl behoudt
* een specifieke stijl wordt gebruikt voor alle dia's in de uitvoerpresentatie.

Om presentaties samen te voegen, biedt Aspose.Slides [AddClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methoden (van de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) interface). Er zijn verschillende implementaties van de `AddClone`‑methoden die de parameters van het samenvoegproces definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--) collectie, zodat je een `AddClone`‑methode kunt aanroepen op de presentatie waarin je dia's wilt samenvoegen.

De `AddClone`‑methode retourneert een `ISlide`‑object, dat een kloon is van de bron‑dia. De dia's in een uitvoerpresentatie zijn simpelweg een kopie van de dia's uit de bron. Daarom kun je wijzigingen aanbrengen in de resulterende dia's (bijvoorbeeld stijlen, opmaakopties of layout toepassen) zonder je zorgen te maken dat de bronpresentaties worden beïnvloed.

## **Presentaties samenvoegen**

Aspose.Slides biedt de [**AddClone(ISlide)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) methode die je in staat stelt dia's te combineren terwijl de dia's hun layout en stijlen behouden (standaardparameters).

Deze Java-code laat zien hoe je presentaties kunt samenvoegen:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Presentaties samenvoegen met een slide-master**

Aspose.Slides biedt de [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) methode die je in staat stelt dia's te combineren met het toepassen van een slide-master presentatiesjabloon. Op deze manier kun je, indien nodig, de stijl voor de dia's in de uitvoerpresentatie aanpassen.

Deze Java-code demonstreert de beschreven bewerking:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Opmerking" color="warning" %}} 
De dia-layout voor de slide-master wordt automatisch bepaald. Wanneer geen geschikte layout kan worden bepaald, en de `allowCloneMissingLayout`-boolean-parameter van de `AddClone`-methode is ingesteld op true, wordt de layout van de bron-dia gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PptxEditException) gegooid.
{{% /alert %}}

Als je wilt dat de dia's in de uitvoerpresentatie een andere dia-layout hebben, gebruik dan de [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) methode in plaats daarvan bij het samenvoegen.

## **Specifieke dia's uit presentaties samenvoegen**

Het samenvoegen van specifieke dia's uit meerdere presentaties is handig voor het maken van aangepaste diavoorstellingen. Aspose.Slides voor Android via Java stelt je in staat alleen de dia's te selecteren en te importeren die je nodig hebt. De API behoudt de opmaak, layout en vormgeving van de originele dia's.

De volgende Java-code maakt een nieuwe presentatie, voegt titel-dia's uit twee andere presentaties toe, en slaat het resultaat op in een bestand:
```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Presentaties samenvoegen met een dia-layout**

Deze Java-code laat zien hoe je dia's uit presentaties combineert terwijl je je gewenste dia-layout toepast om één uitvoerpresentatie te verkrijgen:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Presentaties samenvoegen met verschillende dia-groottes**

{{% alert title="Opmerking" color="warning" %}} 
Je kunt geen presentaties met verschillende dia-groottes samenvoegen. 
{{% /alert %}}

Om 2 presentaties met verschillende dia-groottes samen te voegen, moet je één van de presentaties aanpassen zodat de grootte overeenkomt met die van de andere presentatie.

Deze voorbeeldcode demonstreert de beschreven bewerking:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Dia's samenvoegen naar een sectie in een presentatie**

Deze Java-code laat zien hoe je een specifieke dia naar een sectie in een presentatie kunt samenvoegen:
```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

De dia wordt toegevoegd aan het einde van de sectie.

{{% alert title="Tip" color="primary" %}}
Aspose biedt een [GRATIS Collage-webapp](https://products.aspose.app/slides/nl/collage). Met deze online dienst kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG-afbeeldingen samenvoegen, [fotogrijen](https://products.aspose.app/slides/nl/collage/photo-grid) maken, enzovoort.
{{% /alert %}}

## **Veelgestelde vragen**

**Zijn er beperkingen op het aantal dia's bij het samenvoegen van presentaties?**

Geen strikte beperkingen. Aspose.Slides kan grote bestanden aan, maar de prestaties hangen af van de grootte en de systeembronnen. Voor zeer grote presentaties wordt aanbevolen om een 64-bit JVM te gebruiken en voldoende heap-geheugen toe te wijzen.

**Kan ik presentaties samenvoegen met ingesloten video of audio?**

Ja, Aspose.Slides behoudt multimediacontent die in dia's is ingesloten, maar de uiteindelijke presentatie kan aanzienlijk groter worden.

**Worden lettertypen behouden bij het samenvoegen van presentaties?**

Ja. Lettertypen die in de bronpresentaties worden gebruikt, worden bewaard in het uitvoerbestand, ervan uitgaande dat ze op het systeem zijn geïnstalleerd of [ingesloten](/slides/nl/androidjava/embedded-font/).