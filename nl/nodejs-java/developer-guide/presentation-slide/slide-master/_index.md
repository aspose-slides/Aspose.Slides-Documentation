---
title: Beheer dia-masters in presentaties met JavaScript
linktitle: Dia-master
type: docs
weight: 70
url: /nl/nodejs-java/slide-master/
keywords:
- dia-master
- master-dia
- PPT-master-dia
- meerdere master-dia's
- master-dia's vergelijken
- achtergrond
- plaatsaanduiding
- master-dia klonen
- master-dia kopiëren
- master-dia dupliceren
- ongebruikte master-dia
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer dia-masters in Aspose.Slides voor Node.js via Java: toegang, bewerken, klonen, vergelijken en verwijderen van master-dia's in PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Een **dia‑master** definieert gedeelde ontwerpinstellingen voor een groep dia’s. Het kan gezamenlijke vormen, logo’s, achtergronden, tekststijlen, thema‑instellingen en voettekst‑instellingen bevatten. In PowerPoint is het bewerken van een dia‑master de gebruikelijke manier om een presentatie consistent te houden zonder dezelfde opmaak op elke dia te herhalen.

Aspose.Slides voor Node.js via Java ondersteunt hetzelfde model. Een presentatie kan één of meer master‑dia’s bevatten, en elke master‑dia kan meerdere lay‑out dia’s bevatten. Normale dia’s verwijzen meestal niet direct naar een master‑dia. In plaats daarvan gebruikt een normale dia een lay‑out dia, en die lay‑out dia behoort tot een master‑dia.

De hiërarchie is:

1. **Dia‑master** – definieert het gedeelde ontwerp en thema.  
1. **Lay‑out dia** – definieert een specifieke rangschikking van tijdelijke aanduidingen en lay‑out‑niveau opmaak.  
1. **Normale dia** – bevat de feitelijke presentatiedata en gebruikt één lay‑out dia.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

In Aspose.Slides wordt een dia‑master gerepresenteerd door de [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/)‑klasse. Alle master‑dia’s in een presentatie zijn beschikbaar via de `Presentation.getMasters()`‑collectie.

{{% alert color="info" title="Inheritance" %}}

Wanneer dezelfde eigenschap op meer dan één niveau is gedefinieerd, heeft het specifiekste niveau voorrang. Bijvoorbeeld, als een master‑dia en een lay‑out dia beide een achtergrond definiëren, gebruiken dia’s die op die lay‑out zijn gebaseerd de achtergrond van de lay‑out. Voor meer informatie over lay‑out dia’s, zie [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Toegang tot Dia‑masters**

In PowerPoint kun je de Dia‑master‑weergave openen via **Beeld** > **Dia‑master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

In Aspose.Slides gebruik je de `getMasters()`‑collectie om master‑dia’s te benaderen:

```javascript
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

Je kunt ook de master‑dia ophalen die door een normale dia wordt gebruikt via de bijbehorende lay‑out:

```javascript
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

## **Wat een Dia‑master Bevat**

Een master‑dia is een dia‑achtig object. Het erft gemeenschappelijk dia‑gedrag van [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/), waardoor het veel van dezelfde dia‑eigenschappen beschikbaar stelt die door normale en lay‑out dia’s worden gebruikt. Master‑specifieke leden staan vermeld op de [MasterSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/masterslide/)‑API‑pagina.

Veelgebruikte master‑dia‑leden omvatten:

| Lid | Doel |
| --- | --- |
| `getBackground()` | Stelt de achtergrond op master‑niveau in. |
| `getShapes()` | Bewaart vormen die op de master zijn geplaatst, zoals logo’s, fotolijsten en gedeelde tekst. |
| `getLayoutSlides()` | Bewaart de lay‑out dia’s die tot de master behoren. |
| `getThemeManager()` | Biedt toegang tot de master‑thema‑API’s. |
| `getHeaderFooterManager()` | Beheert kop‑ en voetteksten, datums en dia‑nummers voor de master en de onderliggende lay‑outs. |
| `getDependingSlides()` | Geeft normale dia’s terug die via hun lay‑outs afhankelijk zijn van de master. |

## **Afbeelding Toevoegen aan een Dia‑master**

Wanneer je een afbeelding toevoegt aan een master‑dia, verschijnt deze op alle dia’s die lay‑outs van die master gebruiken. Dit is nuttig voor logo’s, watermerken, decoratieve banden en andere terugkerende visuele elementen.

Het volgende voorbeeld voegt een logo toe aan de eerste master‑dia:

```javascript
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

Voor meer informatie over fotolijsten, zie [Picture Frame](/nodejs-java/picture-frame/).

## **Werken met Tijdelijke Aanduidingen**

Tijdelijke aanduidingen worden normaal gedefinieerd op lay‑out dia’s. De master‑dia levert de gedeelde stijl en het thema waar die lay‑outs van erven, terwijl elke lay‑out beslist welke tijdelijke aanduidingen beschikbaar zijn en waar ze worden geplaatst.

In PowerPoint zijn de tijdelijke‑aanduiding‑opdrachten beschikbaar in de Dia‑master‑weergave.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Om nieuwe tijdelijke aanduidingen toe te voegen met Aspose.Slides, werk je met de lay‑out dia die bij de master hoort:

```javascript
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

Je kunt ook de vorm van een bestaande tijdelijke aanduiding op een master‑dia opmaken. Het volgende voorbeeld zoekt de titel‑placeholder en past een lineaire verloopvulling toe:

```javascript
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
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(255.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Voor meer opties voor placeholders en tekstopmaak, zie [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) en [Text Formatting](/nodejs-java/text-formatting/).

## **Achtergrond van een Dia‑master Wijzigen**

Een master‑achtergrond wordt geërfd door lay‑outs en dia’s die deze niet overschrijven. Het volgende voorbeeld stelt een effen achtergrondkleur in voor de eerste master‑dia:

```javascript
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

## **Dia‑master Kopiëren naar een Andere Presentatie**

Gebruik `MasterSlideCollection.addClone` om een master‑dia naar een andere presentatie te kopiëren. De gekopieerde master kan vervolgens worden gebruikt door lay‑outs en dia’s in de doelpresentatie.

```javascript
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

Als je normale dia’s samen met hun master wilt klonen, zie [Clone Slides](/nodejs-java/clone-slides/).

## **Meerdere Dia‑masters Toevoegen**

Een presentatie kan meerdere master‑dia’s bevatten. Dit is handig wanneer verschillende secties verschillende branding, paginavormgeving of thema‑instellingen vereisen.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

Het volgende voorbeeld kloont de standaard master, geeft de kloon een andere achtergrond, maakt een lay‑out onder die gekloonde master en voegt een nieuwe dia toe die op die lay‑out is gebaseerd:

```javascript
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

## **Dia‑masters Vergelijken**

Master‑dia’s kunnen worden vergeleken met de `equals`‑methode die ze erven van [BaseSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/). De vergelijking controleert structuur en statische inhoud, zoals vormen, tekst, opmaak, animaties en andere dia‑instellingen. Unieke identifiers, zoals dia‑ID’s, of dynamische placeholder‑waarden, zoals de huidige datum, worden niet vergeleken.

```javascript
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

Voor meer informatie, zie [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Dia‑master‑weergave Instellen als Standaardweergave**

Gebruik de `setLastView`‑methode op [ViewProperties](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/viewproperties/) om de weergave te bepalen die PowerPoint eerst opent. Het volgende voorbeeld opent de presentatie in Dia‑master‑weergave:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Voor meer weergave‑instellingen, zie [Save Presentation](/nodejs-java/save-presentation/).

## **Ongebruikte Master‑dia’s Verwijderen**

Presentaties bevatten soms master‑dia’s die niet meer door normale dia’s worden gebruikt. Het verwijderen van ongebruikte masters kan de bestandsgrootte verkleinen en onderhoud van sjablonen vereenvoudigen.

Gebruik `removeUnused` om ongebruikte masters uit de `getMasters()`‑collectie te verwijderen:

```javascript
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
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Wat is het verschil tussen een dia‑master en een lay‑out dia?**

Een dia‑master definieert gedeelde ontwerpinstellingen zoals thema, achtergrond, gemeenschappelijke vormen en tekststijlen. Een lay‑out dia behoort tot een master‑dia en definieert een specifieke rangschikking van tijdelijke aanduidingen. Een normale dia gebruikt een lay‑out dia, zodat deze zowel van de lay‑out als van de master erft.

**Kan één presentatie meerdere dia‑masters bevatten?**

Ja. Een presentatie kan meerdere dia‑masters bevatten. Gebruik meerdere masters wanneer verschillende secties verschillende visuele systemen of branding nodig hebben.

**Moet ik tijdelijke aanduidingen toevoegen aan een master‑dia of een lay‑out dia?**

In de meeste gevallen voeg je tijdelijke aanduidingen toe aan lay‑out dia’s. Plaats gedeelde visuele elementen en gedeelde opmaak op de master‑dia en zet de inhouds‑placeholders op de lay‑outs die normale dia’s zullen gebruiken.

**Kan ik een master‑dia verwijderen die nog in gebruik is?**

Nee. Een master‑dia met afhankelijke dia’s kan niet veilig rechtstreeks worden verwijderd. Verplaats eerst die dia’s naar lay‑outs onder een andere master, of gebruik een opruim‑methode die alleen ongebruikte masters verwijdert.