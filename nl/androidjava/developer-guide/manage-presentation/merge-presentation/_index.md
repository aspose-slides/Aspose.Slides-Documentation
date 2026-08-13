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
description: "Voeg moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samen met Aspose.Slides voor Android via Java, waardoor je workflow wordt vereenvoudigd."
---
## **Overzicht**

Het samenvoegen van PowerPoint‑ en OpenDocument‑presentaties is een veelvoorkomende taak in tal van Android‑applicaties, vooral bij het genereren van rapporten, het samenstellen van dia’s uit verschillende bronnen of het automatiseren van presentatiewerkstromen. Aspose.Slides biedt een krachtige en gebruiksvriendelijke API om meerdere PPT‑, PPTX‑ of ODP‑bestanden te combineren tot één presentatie, zonder Microsoft PowerPoint, LibreOffice of OpenOffice te hoeven installeren.

In deze gids leer je hoe je PowerPoint‑ en OpenDocument‑presentaties kunt samenvoegen met slechts een paar regels code. We leveren kant‑klaar voorbeeldmateriaal en laten zien hoe je de opmaak, indelingen en andere presentatie‑elementen behoudt tijdens het samenvoegproces.

Of je nu een enterprise‑applicatie bouwt of een eenvoudige automatiseringstool, Aspose.Slides maakt het samenvoegen van presentaties snel, betrouwbaar en schaalbaar. Aspose.Slides biedt verschillende manieren om presentaties te combineren. Je kunt presentaties samenvoegen met al hun vormen, stijlen, tekst, opmaak, opmerkingen, animaties en meer — zonder je zorgen te maken over kwaliteitsverlies of gegevensverlies.

{{% alert color="info" %}}
Zie ook: [Clone Slides](https://docs.aspose.com/slides/nl/androidjava/clone-slides/)
{{% /alert %}}

### **Wat kan er worden samengevoegd**

Met Aspose.Slides kun je

* volledige presentaties samenvoegen. Alle dia’s uit de presentaties eindigen in één presentatie
* specifieke dia’s samenvoegen. Geselecteerde dia’s komen in één presentatie terecht
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar toe.

### **Samenvoegopties**

Je kunt opties toepassen die bepalen of

* elke dia in de uitvoerpresentatie een unieke stijl behoudt
* één specifieke stijl wordt gebruikt voor alle dia’s in de uitvoerpresentatie.

Om presentaties samen te voegen, biedt Aspose.Slides de [AddClone](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methoden (van de [ISlideCollection](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection) interface). Er bestaan verschillende implementaties van de `AddClone`‑methoden die de parameters van het samenvoegproces definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#getSlides--)‑collectie, zodat je een `AddClone`‑methode kunt aanroepen vanaf de presentatie waaraan je dia’s wilt toevoegen.

De `AddClone`‑methode retourneert een `ISlide`‑object, een kloon van de bron‑dia. De dia’s in een uitvoerpresentatie zijn simpelweg een kopie van de dia’s uit de bron. Daarom kun je de resulterende dia’s aanpassen (bijvoorbeeld stijlen, opmaakopties of indelingen toepassen) zonder je zorgen te maken dat de bronpresentaties worden beïnvloed.

## **Presentaties samenvoegen**

Aspose.Slides biedt de [**AddClone(ISlide)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-)‑methode die het mogelijk maakt dia’s te combineren terwijl de dia’s hun indelingen en stijlen behouden (standaardparameters).

Deze Java‑code toont hoe je presentaties samenvoegt:

```java
import com.aspose.slides.*;

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

## **Presentaties samenvoegen met een Slide Master**

Aspose.Slides biedt de [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-)‑methode die het mogelijk maakt dia’s te combineren met een slide‑master‑presentatiesjabloon. Zo kun je, indien nodig, de stijl van de dia’s in de uitvoerpresentatie wijzigen.

Deze Java‑code demonstreert de beschreven bewerking:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
De dia‑indeling voor de slide master wordt automatisch bepaald. Wanneer er geen geschikte indeling kan worden vastgesteld, wordt – als de `allowCloneMissingLayout`‑bool‑parameter van de `AddClone`‑methode op true staat – de indeling van de bron‑dia gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/PptxEditException) gegooid.
{{% /alert %}}

Wil je dat de dia’s in de uitvoerpresentatie een andere dia‑indeling krijgen, gebruik dan de [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑methode in plaats daarvan tijdens het samenvoegen.

## **Specifieke dia’s uit presentaties samenvoegen**

Het samenvoegen van specifieke dia’s uit meerdere presentaties is handig voor het maken van aangepaste dia‑sets. Aspose.Slides for Android via Java stelt je in staat alleen de dia’s te selecteren en importeren die je nodig hebt. De API behoudt opmaak, indeling en ontwerp van de oorspronkelijke dia’s.

De volgende Java‑code maakt een nieuwe presentatie, voegt titel‑dia’s van twee andere presentaties toe en slaat het resultaat op in een bestand:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Presentaties samenvoegen met een dia‑indeling**

Deze Java‑code toont hoe je dia’s uit presentaties combineert terwijl je een voorkeurs‑dia‑indeling toepast, om één uitvoerpresentatie te verkrijgen:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Presentaties samenvoegen met verschillende dia‑groottes**

{{% alert title="Note" color="warning" %}} 
Je kunt geen presentaties met verschillende dia‑groottes samenvoegen. 
{{% /alert %}}

Om twee presentaties met verschillende dia‑groottes samen te voegen, moet je één van de presentaties herdimensioneren zodat de grootte overeenkomt met die van de andere presentatie.

Deze voorbeeldcode demonstreert de beschreven bewerking:

```java
import com.aspose.slides.*;

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

## **Dia’s samenvoegen naar een presentatiesectie**

Deze Java‑code laat zien hoe je een specifieke dia toevoegt aan een sectie in een presentatie:

```java
import com.aspose.slides.*;

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

De dia wordt aan het einde van de sectie toegevoegd.

{{% alert title="Tip" color="info" %}}
Aspose biedt een [FREE Collage web app](https://products.aspose.app/slides/nl/collage). Met deze online dienst kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG afbeeldingen samenvoegen, foto‑roosters maken, enzovoort. 
{{% /alert %}}

## **FAQ**

### Zijn er beperkingen in het aantal dia’s bij het samenvoegen van presentaties?

Geen strikte limieten. Aspose.Slides kan grote bestanden aan, maar de prestaties hangen af van de bestandsgrootte en de systeembronnen. Voor zeer grote presentaties wordt aangeraden een 64‑bit JVM te gebruiken en voldoende heap‑geheugen toe te wijzen.

### Kan ik presentaties met ingebedde video of audio samenvoegen?

Ja, Aspose.Slides behoudt multimedia‑inhoud die in de dia’s is ingebed, maar de uiteindelijke presentatie kan aanzienlijk groter worden.

### Worden lettertypen behouden bij het samenvoegen van presentaties?

Ja. Lettertypen die in de bron‑presentaties worden gebruikt, blijven behouden in het uitvoer‑bestand, op voorwaarde dat ze op het systeem zijn geïnstalleerd of [embedded](/slides/nl/androidjava/embedded-font/).