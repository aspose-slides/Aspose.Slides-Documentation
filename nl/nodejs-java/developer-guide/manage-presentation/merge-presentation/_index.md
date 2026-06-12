---
title: Efficiënt presentaties samenvoegen in JavaScript
linktitle: Presentaties samenvoegen
type: docs
weight: 40
url: /nl/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Moeiteloos PowerPoint (PPT, PPTX) en OpenDocument (ODP) presentaties samenvoegen in JavaScript met Aspose.Slides for Node.js, waardoor uw workflow wordt gestroomlijnd."
---
## **Overzicht**

Aspose.Slides stelt je in staat om presentaties te combineren door dia’s van de ene presentatie te klonen naar een andere. Dit artikel legt uit hoe je volledige presentaties of geselecteerde dia’s kunt samenvoegen, een slide‑master of een specifiek layout tijdens het samenvoegen kunt gebruiken, presentaties met verschillende dia‑groottes kunt afhandelen en samengevoegde dia’s aan een presentatiesectie kunt toevoegen. Het behandelt ook praktische notities over samengevoegde inhoud, waaronder notities van de spreker, opmerkingen, met een wachtwoord beveiligde bronbestanden en thread‑gebruik.

## **Presentatie samenvoegen**

Wanneer je de ene presentatie met de andere samenvoegt, combineer je in feite hun dia’s in één presentatie om één bestand te verkrijgen. 

{{% alert title="Info" color="info" %}}
De meeste presentatiesoftware (PowerPoint of OpenOffice) mist functies waarmee gebruikers presentaties op deze manier kunnen combineren. 
{{% /alert %}}

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/nl/nodejs-java/), maakt echter op verschillende manieren het samenvoegen van presentaties mogelijk. Je kunt presentaties samenvoegen met al hun vormen, stijlen, teksten, opmaak, opmerkingen, animaties, enz., zonder je zorgen te maken over kwaliteits- of gegevensverlies.

**Zie ook**

[Dia’s klonen](https://docs.aspose.com/slides/nl/nodejs-java/clone-slides/).

### **Wat kan worden samengevoegd**

Met Aspose.Slides kun je

* volledige presentaties. Alle dia’s uit de presentaties eindigen in één presentatie
* specifieke dia’s. Geselecteerde dia’s eindigen in één presentatie
* presentaties in één formaat (PPT naar PPT, PPTX naar PPTX, enz.) en in verschillende formaten (PPT naar PPTX, PPTX naar ODP, enz.) naar elkaar.

### **Samenvoeg‑opties**

Je kunt opties toepassen die bepalen of

* elke dia in de doelpresentatie een unieke stijl behoudt
* een specifieke stijl wordt gebruikt voor alle dia’s in de doelpresentatie.

Om presentaties samen te voegen, biedt Aspose.Slides de [addClone](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methoden (van de [SlideCollection](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection)‑klasse). Er zijn verschillende implementaties van de `addClone`‑methoden die de parameters van het samenvoeg‑proces definiëren. Elk Presentation‑object heeft een [Slides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#getSlides--) collectie, zodat je een `addClone`‑methode kunt aanroepen vanaf de presentatie waarin je dia’s wilt samenvoegen.

De `addClone`‑methode retourneert een `Slide`‑object, dat een kloon is van de bron‑slide. De dia’s in de doelpresentatie zijn eenvoudigweg een kopie van de dia’s uit de bron. Daarom kun je de resulterende dia’s aanpassen (bijvoorbeeld stijlen of opmaak‑opties of layouts toepassen) zonder dat de bron‑presentaties worden beïnvloed. 

## **Presentaties samenvoegen**

Aspose.Slides biedt de [**AddClone(ISlide)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) methode die je in staat stelt dia’s te combineren terwijl de dia’s hun layouts en stijlen behouden (standaard‑parameters).

Deze JavaScript‑code laat zien hoe je presentaties samenvoegt:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Presentaties samenvoegen met Slide Master**

Aspose.Slides biedt de [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) methode die je in staat stelt dia’s te combineren terwijl een slide‑master‑presentatiesjabloon wordt toegepast. Op deze manier kun je, indien nodig, de stijl van de dia’s in de doelpresentatie wijzigen.

Deze JavaScript‑code demonstreert de beschreven bewerking:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
De slide‑layout voor de slide‑master wordt automatisch bepaald. Wanneer een geschikte layout niet kan worden bepaald, wordt – als de `allowCloneMissingLayout`‑boolean‑parameter van de `addClone`‑methode op true staat – de layout van de bron‑slide gebruikt. Anders wordt een [PptxEditException](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/PptxEditException) gegooid. 
{{% /alert %}}

Wil je dat de dia’s in de doelpresentatie een andere slide‑layout hebben, gebruik dan de [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) methode in plaats van bij het samenvoegen.

## **Specifieke dia’s uit presentaties samenvoegen**

Het samenvoegen van specifieke dia’s uit meerdere presentaties is handig voor het maken van aangepaste diavoorstellingen. Aspose.Slides for Node.js via Java laat je alleen de dia’s selecteren en importeren die je nodig hebt. De API behoudt opmaak, layout en ontwerp van de oorspronkelijke dia’s.

De volgende JavaScript‑code maakt een nieuwe presentatie, voegt titel‑dia’s toe uit twee andere presentaties en slaat het resultaat op in een bestand:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Presentaties samenvoegen met dia‑layout**

Deze JavaScript‑code laat zien hoe je dia’s uit presentaties combineert terwijl je de gewenste dia‑layout toepast om één uitvoer­presentatie te krijgen:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Presentaties samenvoegen met verschillende dia‑groottes**

{{% alert title="Note" color="warning" %}} 
Je kunt geen presentaties met verschillende dia‑groottes samenvoegen. 
{{% /alert %}}

Om 2 presentaties met verschillende dia‑groottes te combineren, moet je één van de presentaties aanpassen zodat de grootte overeenkomt met die van de andere presentatie. 

Deze voorbeeldcode demonstreert de beschreven bewerking:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Dia’s samenvoegen met presentatiesectie**

Deze JavaScript‑code laat zien hoe je een specifieke dia naar een sectie in een presentatie kunt samenvoegen:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

De dia wordt aan het einde van de sectie toegevoegd. 

## **FAQ**

**Worden spreker‑notities behouden tijdens het samenvoegen?**

Ja. Bij het klonen van dia’s neemt Aspose.Slides alle dia‑elementen over, inclusief notities, opmaak en animaties.

**Worden opmerkingen en hun auteurs overgebracht?**

Opmerkingen, als onderdeel van de dia‑inhoud, worden met de dia gekopieerd. Auteur‑labels van opmerkingen blijven behouden als opmerkingobjecten in de resulterende presentatie.

**Wat als de bronpresentatie met een wachtwoord is beveiligd?**

Deze moet worden [geopend met het wachtwoord](/slides/nl/nodejs-java/password-protected-presentation/) via [LoadOptions.setPassword](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/loadoptions/setpassword/); na het laden kunnen die dia’s veilig worden gekloond naar een onbeveiligd doelbestand (of ook een beveiligd bestand).

**Hoe thread‑veilig is de samenvoeg‑operatie?**

Gebruik niet dezelfde [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/)‑instantie vanuit [meerdere threads](/slides/nl/nodejs-java/multithreading/). De aanbevolen regel is “één document — één thread”; verschillende bestanden kunnen parallel in afzonderlijke threads worden verwerkt.

## **Zie ook**

Aspose biedt een [GRATIS Online Collage Maker](https://products.aspose.app/slides/nl/collage). Met deze online dienst kun je [JPG naar JPG](https://products.aspose.app/slides/nl/collage/jpg) of PNG naar PNG afbeeldingen samenvoegen, [fotogriezen](https://products.aspose.app/slides/nl/collage/photo-grid) maken en meer.

Bekijk de [Aspose GRATIS Online Merger](https://products.aspose.app/slides/nl/merger). Hiermee kun je PowerPoint‑presentaties in hetzelfde formaat (bijv. PPT naar PPT, PPTX naar PPTX) of tussen verschillende formaten (bijv. PPT naar PPTX, PPTX naar ODP) samenvoegen.

[![Aspose GRATIS Online Merger](slides-merger.png)](https://products.aspose.app/slides/nl/merger)