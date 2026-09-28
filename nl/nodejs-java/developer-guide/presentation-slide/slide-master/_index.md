---
title: Beheer dia‑masters in presentaties met JavaScript
linktitle: Dia‑master
type: docs
weight: 70
url: /nl/nodejs-java/slide-master/
keywords:
- dia‑master
- masterdia
- PPT‑masterdia
- meerdere masterdia's
- masterdia's vergelijken
- achtergrond
- tijdelijke aanduiding
- masterdia klonen
- masterdia kopiëren
- masterdia dupliceren
- ongebruikte masterdia
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer dia‑masters in Aspose.Slides voor Node.js via Java: benader, bewerk, kloon, vergelijk en verwijder masterdia's in PowerPoint‑ en OpenDocument‑presentaties."
---
## **Overzicht**

Een **dia‑master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Hij kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een dia‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor Node.js via Java ondersteunt hetzelfde model. Een presentatie kan één of meer dia‑masters bevatten, en elke dia‑master kan verschillende lay-outdia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een dia‑master. In plaats daarvan gebruikt een normale dia een lay-outdia, en die lay-outdia behoort tot een dia‑master.

De hiërarchie is:

1. **Dia‑master** – definieert het gedeelde ontwerp en thema.  
1. **Lay-outdia** – definieert een specifieke rangschikking van tijdelijke aanduidingen en lay-out‑niveau opmaak.  
1. **Normale dia** – bevat de feitelijke presentatiewaarde en gebruikt één lay-outdia.

![De hiërarchie van dia‑masters, lay-outdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een dia‑master weergegeven door de [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/)‑klasse. Alle dia‑masters in een presentatie zijn beschikbaar via de `Presentation.getMasters()`‑collectie.

{{% alert color="info" title="Inheritance" %}}

Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een dia‑master en een lay-outdia beide een achtergrond definiëren, gebruiken dia's die op die lay-out zijn gebaseerd de lay‑outachtergrond. Voor meer informatie over lay-outdia's, zie [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Dia‑masters benaderen**

In PowerPoint kun je de weergave Dia‑master openen via **Beeld** > **Dia‑master**.

![De Dia‑master‑opdracht op het PowerPoint‑tabblad Beeld](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters()`‑collectie om dia‑masters te benaderen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Je kunt ook de dia‑master krijgen die door een normale dia wordt gebruikt via zijn lay‑out:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Wat een dia‑master bevat**

Een dia‑master is een object dat op een dia lijkt. Hij erft algemeen dia‑gedrag van [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/), zodat hij veel van dezelfde dia‑eigenschappen beschikbaar stelt die door normale en lay‑outdia's worden gebruikt. Master‑specifieke leden staan opgesomd op de [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/)‑API‑pagina.

Veelgebruikte leden van een dia‑master zijn:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond op master‑niveau in. |
| `getShapes()` | Slaat vormen op die op de master zijn geplaatst, zoals logo's, foto‑frames en gedeelde tekst. |
| `getLayoutSlides()` | Slaat de lay‑outdia's op die tot de master behoren. |
| `getThemeManager()` | Biedt toegang tot de master‑thema‑API's. |
| `getHeaderFooterManager()` | Beheert kop‑ en voetteksten, datums en diapagina‑nummers voor de master en zijn onderliggende lay‑outs. |
| `getDependingSlides()` | Retourneert normale dia's die via hun lay‑out van de master afhangen. |

## **Een afbeelding toevoegen aan een dia‑master**

Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt deze op dia's die lay‑outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve band‑en andere herhalende visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste dia‑master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer informatie over foto‑frames, zie [Picture Frame](/nodejs-java/picture-frame/).

## **De zichtbaarheid van master‑grafieken regelen**

Gebruik [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) om overerfde master‑grafieken, zoals logo's of decoratieve vormen, te verbergen zonder ze van de master te verwijderen. Geef `false` door aan [Slide.setShowMasterShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#setShowMasterShapes) op de dia die die grafieken moet weglaten en behoud `true` op dia's die ze moeten weergeven.

Het volgende zelfstandige voorbeeld maakt een blauwe decoratieve band op een master en twee dia's die dezelfde lege lay‑out gebruiken. De band is zichtbaar op de eerste dia en verborgen op de tweede. Er is geen invoerpresentatie of afbeelding nodig.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Het voorbeeld gebruikt de **Blank**‑lay‑out die wordt meegeleverd met een nieuwe presentatie en verwijdert de oorspronkelijke tijdelijke aanduidingen van de eerste dia.

### **Het toepassingsgebied van de instelling kiezen**

Een normale dia gebruikt zijn master via [Slide.getLayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getLayoutSlide) en [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Het instellen van de eigenschap op een individuele dia beïnvloedt alleen die dia. Het doorgeven van `false` aan [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) verbergt master‑grafieken voor dia's die die gedeelde lay‑out gebruiken, zelfs als hun eigen instelling `true` is. Om grafieken alleen op één dia te verbergen, wijzig je de dia‑eigenschap en laat je de gedeelde lay‑out ongewijzigd.

De instelling wordt niet ondersteund als een zichtbaarheid‑controle op de master‑dia zelf. Op een master geeft [getShowMasterShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) altijd `false` terug, en het doorgeven van `true` aan [setShowMasterShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) veroorzaakt een uitzondering. Pas het toe op een normale dia of een lay‑out.

### **Grafieken onderscheiden van de achtergrond**

| Bewerking | Effect |
| --- | --- |
| Master‑grafieken verbergen | Regelt de zichtbaarheid van overerfde master‑vormen zonder ze te verwijderen of de eigen vormen van de dia te wijzigen. |
| Dia‑achtergrond vullen wijzigen | Wijzigt de achtergrondkleur, -gradient of -afbeelding. Master‑grafieken zijn aparte vormen en kunnen zichtbaar blijven boven die achtergrond. Zie [Presentation Background](/slides/nl/nodejs-java/presentation-background/). |
| Een vorm van de master verwijderen | Verwijdert de gedeelde bronvorm, waardoor deze niet langer beschikbaar is voor enige dia die die master gebruikt. |

## **Werken met tijdelijke aanduidingen**

Tijdelijke aanduidingen worden normaal gesproken gedefinieerd op lay‑outdia's. De dia‑master levert de gedeelde stijl en thema die die lay‑outs erven, terwijl elke lay‑out beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn de tijdelijke aanduidings‑opdrachten beschikbaar in de weergave Dia‑master.

![De opdracht Tijdelijke aanduiding invoegen in de PowerPoint‑weergave Dia‑master](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de lay‑outdia die bij de master hoort:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook de vorm van een bestaande tijdelijke aanduiding op een dia‑master opmaken. Het volgende voorbeeld zoekt de titel‑tijdelijke aanduiding en past een lineaire gradient‑vulling toe:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Opgepaste titel‑tijdelijke aanduiding geërfd door normale dia's](slide-master_8.png)

Voor meer opties voor tijdelijke aanduidingen en tekstopmaak, zie [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) en [Text Formatting](/nodejs-java/text-formatting/).

## **Een dia‑master‑achtergrond wijzigen**

Een master‑achtergrond wordt geërfd door lay‑outs en dia's die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste dia‑master:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor gerelateerde onderwerpen, zie [Presentation Background](/nodejs-java/presentation-background/) en [Presentation Theme](/nodejs-java/presentation-theme/).

## **Een dia‑master klonen naar een andere presentatie**

Gebruik `MasterSlideCollection.addClone` om een dia‑master te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens worden gebruikt door lay‑outs en dia's in de bestemmingspresentatie.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Als je normale dia's samen met hun master moet klonen, zie [Clone Slides](/nodejs-java/clone-slides/).

## **Meerdere dia‑masters toevoegen**

Een presentatie kan meerdere dia‑masters bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginabereik of themainstellingen vereisen.

![PowerPoint‑opdrachten voor het invoegen en beheren van dia‑masters](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard master, geeft de kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master en voegt een nieuwe dia toe gebaseerd op die lay‑out:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Dia‑masters vergelijken**

Dia‑masters kunnen worden vergeleken met de `equals`‑methode die ze erven van [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID's, of dynamische tijdelijke aanduidingswaarden, zoals de huidige datum.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Voor meer informatie, zie [Compare Presentation Slides](/slides/nl/nodejs-java/compare-slides/).

## **Dia‑master‑weergave als standaardweergave instellen**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in de Dia‑master‑weergave:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer weergave‑instellingen, zie [Save Presentation](/slides/nl/nodejs-java/save-presentation/).

## **Ongebruikte dia‑masters verwijderen**

Presentaties bevatten soms dia‑masters die door geen enkele normale dia meer worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de `getMasters()`‑collectie te verwijderen:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Je kunt ook de low‑code‑methode `Compress.removeUnusedMasterSlides` gebruiken:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een dia‑master en een lay‑outdia?**

Een dia‑master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een lay‑outdia behoort tot een dia‑master en definieert een specifieke rangschikking van tijdelijke aanduidingen. Een normale dia gebruikt een lay‑outdia, waardoor hij van zowel de lay‑out als de master erft.

**Kan één presentatie meerdere dia‑masters bevatten?**

Ja. Een presentatie kan meerdere dia‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik tijdelijke aanduidingen toevoegen aan een dia‑master of een lay‑outdia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan lay‑outdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de dia‑master en zet de inhoudstemporelelijken op de lay‑outs die normale dia's zullen gebruiken.

**Kan ik een dia‑master verwijderen die nog wordt gebruikt?**

Nee. Een dia‑master met afhankelijke dia's kan niet veilig direct worden verwijderd. Verplaats eerst die dia's naar lay‑outs onder een andere master, of gebruik een opruim‑methode voor ongebruikte masters die alleen masters verwijdert die niet in gebruik zijn.