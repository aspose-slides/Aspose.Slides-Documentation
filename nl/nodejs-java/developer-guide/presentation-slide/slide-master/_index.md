---
title: Beheer presentatie‑dia‑masters in JavaScript
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
- plaatsbepaling
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
description: "Beheer dia‑masters in Aspose.Slides voor Node.js via Java: toegang, bewerken, klonen, vergelijken en verwijderen van masterdia's in PowerPoint- en OpenDocument‑presentaties."
---
## **Overzicht**

Een **dia‑master** definieert gedeelde ontwerpinstellingen voor een groep dia's. Hij kan gemeenschappelijke vormen, logo's, achtergronden, tekststijlen, themainstellingen en voettekstinstellingen bevatten. In PowerPoint is het bewerken van een dia‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor Node.js via Java ondersteunt hetzelfde model. Een presentatie kan één of meerdere dia‑masters bevatten, en elke dia‑master kan verschillende lay‑outdia's bevatten. Normale dia's verwijzen meestal niet rechtstreeks naar een dia‑master. In plaats daarvan gebruikt een normale dia een lay‑outdia, en die lay‑outdia behoort tot een dia‑master.

De hiërarchie is:

1. **Dia‑master** – definieert het gedeelde ontwerp en thema.  
1. **Lay‑outdia** – definieert een specifieke rangschikking van tijdelijke aanwijzingen en lay‑out‑niveau opmaak.  
1. **Normale dia** – bevat de daadwerkelijke presentatie‑inhoud en gebruikt één lay‑outdia.

![De hiërarchie van dia‑masters, lay‑outdia's en normale dia's](slide-master_2.jpg)

In Aspose.Slides wordt een dia‑master weergegeven door de klasse [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) . Alle dia‑masters in een presentatie zijn beschikbaar via de collectie `Presentation.getMasters()`.

{{% alert color="info" title="Erfenis" %}}

Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, wint het specifiekere niveau. Bijvoorbeeld, als een dia‑master en een lay‑outdia beide een achtergrond definiëren, gebruiken dia's die op die lay‑out zijn gebaseerd de achtergrond van de lay‑out. Voor meer informatie over lay‑outdia's, zie [Dia‑indelingen toepassen of wijzigen](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Dia‑masters benaderen**

In PowerPoint kun je de dia‑masterweergave openen via **Beeld** > **Dia‑master**.

![De Dia‑master‑opdracht op het tabblad Beeld in PowerPoint](slide-master_3.jpg)

In Aspose.Slides gebruik je de collectie `getMasters()` om dia‑masters te benaderen:

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

Je kunt ook de dia‑master die door een normale dia wordt gebruikt verkrijgen via zijn lay‑out:

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

Een dia‑master is een object dat op een dia lijkt. Hij erft het algemene gedrag van een dia van [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/), waardoor hij veel van dezelfde dia‑eigenschappen biedt die door normale en lay‑outdia's worden gebruikt. Dia‑specifieke leden staan vermeld op de API‑pagina van [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/) .

Veelgebruikte leden van een dia‑master zijn onder andere:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond van de dia‑master in. |
| `getShapes()` | Bevat vormen die op de master zijn geplaatst, zoals logo's, afbeeldingen en gedeelde tekst. |
| `getLayoutSlides()` | Bevat de lay‑outdia's die bij de master horen. |
| `getThemeManager()` | Biedt toegang tot de themabeheer‑API's van de master. |
| `getHeaderFooterManager()` | Beheert kopteksten, voetteksten, datums en paginanummers voor de master en de onderliggende lay‑outs. |
| `getDependingSlides()` | Geeft de normale dia's terug die via hun lay‑outs van de master afhankelijk zijn. |

## **Afbeelding toevoegen aan een dia‑master**

Wanneer je een afbeelding toevoegt aan een dia‑master, verschijnt deze op dia's die lay‑outs van die master gebruiken. Dit is handig voor logo's, watermerken, decoratieve banden en andere herhalende visuele elementen.

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

Voor meer informatie over afbeeldingsframes, zie [Picture Frame](/nodejs-java/picture-frame/).

## **Werken met tijdelijke aanwijzingen**

Tijdelijke aanwijzingen (placeholders) worden normaal gesproken gedefinieerd op lay‑outdia's. De dia‑master levert de gedeelde stijl en het thema waar die lay‑outs van erven, terwijl elke lay‑out beslist welke placeholders beschikbaar zijn en waar ze geplaatst worden.

In PowerPoint zijn placeholder‑opdrachten beschikbaar in de dia‑masterweergave.

![De invoegen‑placeholder‑opdracht in de PowerPoint‑dia‑masterweergave](slide-master_5.png)

Om nieuwe placeholders toe te voegen met Aspose.Slides, werk je met de lay‑outdia die bij de master hoort:

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

Je kunt ook placeholder‑vormen opmaken die al op een dia‑master bestaan. Het volgende voorbeeld zoekt de titel‑placeholder en past een lineaire gradiëntenvulling toe:

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

![Opgecode title‑placeholder geërfd door normale dia's](slide-master_8.png)

Voor meer opties voor placeholders en tekstopmaak, zie [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) en [Text Formatting](/nodejs-java/text-formatting/).

## **Achtergrond van een dia‑master wijzigen**

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

Gebruik `MasterSlideCollection.addClone` om een dia‑master te kopiëren naar een andere presentatie. De gekopieerde master kan vervolgens door lay‑outs en dia's in de bestemmingspresentatie worden gebruikt.

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

Een presentatie kan meerdere dia‑masters bevatten. Dit is handig wanneer verschillende secties een andere branding, paginavormgeving of themainstellingen nodig hebben.

![PowerPoint‑opdrachten voor het invoegen en beheren van dia‑masters](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard‑master, geeft de kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master aan, en voegt een nieuwe dia toe gebaseerd op die lay‑out:

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

Dia‑masters kunnen worden vergeleken met de `equals`‑methode die is geërfd van [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Het vergelijkt geen unieke identifiers, zoals dia‑ID's, of dynamische placeholder‑waarden, zoals de huidige datum.

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

Voor meer informatie zie [Compare Presentation Slides](/slides/nl/nodejs-java/compare-slides/).

## **Dia‑masterweergave instellen als standaardweergave**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in de dia‑masterweergave:

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

Presentaties bevatten soms dia‑masters die niet meer door enige normale dia worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en het onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de collectie `getMasters()` te verwijderen:

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

### Wat is het verschil tussen een dia‑master en een lay‑outdia?

Een dia‑master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een lay‑outdia behoort tot een dia‑master en bepaalt een specifieke rangschikking van placeholders. Een normale dia gebruikt een lay‑outdia, waardoor hij zowel van de lay‑out als van de master erft.

### Kan één presentatie meerdere dia‑masters bevatten?

Ja. Een presentatie kan meerdere dia‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

### Moet ik placeholders toevoegen aan een dia‑master of een lay‑outdia?

In de meeste gevallen voeg je placeholders toe aan lay‑outdia's. Plaats gedeelde visuele elementen en gedeelde opmaak op de dia‑master, en zet de content‑placeholders op de lay‑outs die de normale dia's gebruiken.

### Kan ik een dia‑master verwijderen die nog in gebruik is?

Nee. Een dia‑master die afhankelijke dia's heeft, kan niet veilig rechtstreeks worden verwijderd. Verplaats eerst die dia's naar lay‑outs onder een andere master, of gebruik een opschoonmethode die alleen ongebruikte masters verwijdert.