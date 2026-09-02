---
title: "Hantera presentationens slide-mästare i JavaScript"
linktitle: "Slide-mästare"
type: docs
weight: 70
url: /sv/nodejs-java/slide-master/
keywords:
- "bildmaster"
- "masterbild"
- "PPT masterbild"
- "flera masterbilder"
- "jämför masterbilder"
- "bakgrund"
- "platshållare"
- "klona masterbild"
- "kopiera masterbild"
- "duplicera masterbild"
- "oanvänd masterbild"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Hantera slide masters i Aspose.Slides för Node.js via Java: åtkomst, redigering, kloning, jämförelse och borttagning av masterbilder i PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

En **slide master** definierar gemensamma designinställningar för en grupp bilder. Den kan innehålla gemensamma former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för Node.js via Java stöder samma modell. En presentation kan innehålla en eller flera masterbilder, och varje masterbild kan innehålla flera layoutbilder. Vanliga bilder refererar normalt inte direkt till en masterbild. Istället använder en vanlig bild en layoutbild, och den layoutbilden tillhör en masterbild.

Hierarkin är:

1. **Slide master** – definierar den gemensamma designen och temat.  
1. **Layout slide** – definierar en specifik placering av platshållare och layout‑nivåformatering.  
1. **Normal slide** – innehåller själva presentationsinnehållet och använder en layoutbild.

![Hierarkin av masterbilder, layoutbilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/). Alla masterbilder i en presentation är tillgängliga via samlingen `Presentation.getMasters()`.

{{% alert color="info" title="Arv" %}}
När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en masterbild och en layoutbild båda definierar en bakgrund, använder bilder baserade på den layouten layoutens bakgrund. För mer information om layoutbilder, se [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Åtkomst till slide master**

I PowerPoint kan du öppna vy för Slide Master via **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoint‑fliken View](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `getMasters()` för att komma åt masterbilder:

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

Du kan också hämta masterbilden som används av en normal bild via dess layout:

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

## **Vad en slide master innehåller**

En masterbild är ett bild‑likt objekt. Den ärver vanligt bildbeteende från [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/), så den exponerar många av samma bildegenskaper som används av normala och layoutbilder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/).

Vanligt använda master‑medlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `getBackground()` | Ställer in master‑nivåns bildbakgrund. |
| `getShapes()` | Lagrar former som placerats på masteren, såsom logotyper, bildramar och gemensam text. |
| `getLayoutSlides()` | Lagrar layoutbilderna som tillhör masteren. |
| `getThemeManager()` | Ger åtkomst till master‑tema‑API:er. |
| `getHeaderFooterManager()` | Kontrollerar sidhuvuden, sidfot, datum och bildnummer för masteren och dess underliggande layouter. |
| `getDependingSlides()` | Returnerar normala bilder som beror på masteren via sina layouter. |

## **Lägg till en bild i en slide master**

När du lägger till en bild i en masterbild visas den på bilder som använder layouter från den masteren. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första masterbilden:

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

För mer information om bildramar, se [Picture Frame](/nodejs-java/picture-frame/).

## **Arbeta med platshållare**

Platshållare definieras normalt på layoutbilder. Masterbilden tillhandahåller den gemensamma stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon i Slide Master‑vyn.

![Infoga platshållare‑kommandot i PowerPoint Slide Master‑vyn](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides arbetar du med layoutbilden som tillhör masteren:

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

Du kan också formatera platshållarformer som redan finns på en masterbild. Följande exempel hittar titel‑platshållaren och applicerar en linjär gradientfyllning:

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

![Formaterad titel‑platshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) och [Text Formatting](/nodejs-java/text-formatting/).

## **Ändra bakgrund för en slide master**

En masterbakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första masterbilden:

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

För relaterade ämnen, se [Presentation Background](/nodejs-java/presentation-background/) och [Presentation Theme](/nodejs-java/presentation-theme/).

## **Klona en slide master till en annan presentation**

Använd `MasterSlideCollection.addClone` för att kopiera en masterbild till en annan presentation. Den kopierade masteren kan sedan användas av layouter och bilder i destinationspresentationen.

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

Om du behöver klona normala bilder tillsammans med deras master, se [Clone Slides](/nodejs-java/clone-slides/).

## **Lägg till flera slide masters**

En presentation kan innehålla flera masterbilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera masterbilder](slide-master_9.jpg)

Följande exempel klonar standard‑masteren, ger klonen en annan bakgrund, skapar en layout under den klonade masteren och lägger till en ny bild baserad på den layouten:

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

## **Jämför slide masters**

Masterbilder kan jämföras med metoden `equals` som ärvd från [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Compare Presentation Slides](/slides/sv/nodejs-java/compare-slides/).

## **Ange Slide Master‑vyn som standardvy**

Använd metoden `setLastView` på [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

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

För fler vy‑inställningar, se [Save Presentation](/slides/sv/nodejs-java/save-presentation/).

## **Ta bort oanvända masterbilder**

Presentationer kan ibland innehålla masterbilder som inte längre används av några normala bilder. Att ta bort oanvända masterbilder kan minska filstorleken och förenkla underhållet av mallar.

Använd `removeUnused` för att ta bort oanvända masterbilder från samlingen `getMasters()`:

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

Du kan också använda den låga‑kod‑metoden `Compress.removeUnusedMasterSlides`:

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

### Vad är skillnaden mellan en slide master och en layoutbild?

En slide master definierar gemensamma designinställningar såsom tema, bakgrund, gemensamma former och textstilar. En layoutbild tillhör en masterbild och definierar en specifik placering av platshållare. En normal bild använder en layoutbild, så den ärver både från layouten och masteren.

### Kan en presentation innehålla flera slide masters?

Ja. En presentation kan innehålla flera slide masters. Använd flera masterbilder när olika avsnitt behöver olika visuella system eller varumärkesprofiler.

### Ska jag lägga till platshållare i en masterbild eller en layoutbild?

I de flesta fall lägger du till platshållare i layoutbilder. Placera delade visuella element och gemensam formatering på masterbilden, och lägg sedan innehålls‑platshållare på de layouter som de normala bilderna kommer att använda.

### Kan jag ta bort en masterbild som fortfarande används?

Nej. En masterbild som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en städmetod för oanvända masterbilder som bara tar bort masterbilder som inte är i bruk.