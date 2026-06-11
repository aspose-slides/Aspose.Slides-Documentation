---
title: Hantera slide masters för presentationer i JavaScript
linktitle: Slide master
type: docs
weight: 70
url: /sv/nodejs-java/slide-master/
keywords:
- slide master
- masterbild
- PPT masterbild
- flera masterbilder
- jämför masterbilder
- bakgrund
- platshållare
- klona masterbild
- kopiera masterbild
- duplicera masterbild
- oanvänd masterbild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Hantera slide masters i Aspose.Slides för Node.js via Java: komma åt, redigera, klona, jämföra och ta bort masterbilder i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

En **slide master** definierar delade designinställningar för en grupp bildspel. Den kan innehålla gemensamma former, logotyper, bakgrunder, textstilar, temainställningar och sidfotinställningar. I PowerPoint är redigering av en slide master det vanliga sättet att hålla en presentation konsekvent utan att upprepa samma formatering på varje bild.

Aspose.Slides för Node.js via Java stöder samma modell. En presentation kan innehålla en eller flera master‑bilder, och varje master‑bild kan innehålla flera layout‑bilder. Vanliga bilder hänvisar normalt inte direkt till en master‑bild. Istället använder en vanlig bild en layout‑bild, och den layout‑bilden tillhör en master‑bild.

Hierarkin är:

1. **Slide master** – definierar den delade designen och temat.  
1. **Layout‑bild** – definierar en specifik placering av platshållare och layout‑nivåformatering.  
1. **Normal bild** – innehåller det faktiska presentationsinnehållet och använder en layout‑bild.

![Hierarkin av master‑bilder, layout‑bilder och normala bilder](slide-master_2.jpg)

I Aspose.Slides representeras en slide master av klassen [MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/). Alla master‑bilder i en presentation är tillgängliga via samlingen `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}

När samma egenskap definieras på mer än en nivå vinner den mer specifika nivån. Till exempel, om en master‑bild och en layout‑bild båda definierar en bakgrund, använder bilder baserade på den layouten layout‑bakgrunden. För mer information om layout‑bilder, se [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Åtkomst till Slide Masters**

I PowerPoint kan du öppna Slide Master‑vyn via **View** > **Slide Master**.

![Slide Master‑kommandot på PowerPoint‑fliken View](slide-master_3.jpg)

I Aspose.Slides använder du samlingen `getMasters()` för att komma åt master‑bilder:

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

Du kan också hämta master‑bilden som används av en normal bild via dess layout:

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

## **Vad en Slide Master Innehåller**

En master‑bild är ett bild‑liknande objekt. Den ärver gemensamt bildbeteende från [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/), så den exponerar många av samma bildegenskaper som används av normala och layout‑bilder. Master‑specifika medlemmar listas på API‑sidan för [MasterSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/masterslide/).

Vanligt använda master‑bildmedlemmar inkluderar:

| Medlem | Syfte |
| --- | --- |
| `getBackground()` | Ställer in master‑nivåns bildbakgrund. |
| `getShapes()` | Lagrar former placerade på mastern, såsom logotyper, bildramar och delad text. |
| `getLayoutSlides()` | Lagrar layout‑bilderna som tillhör mastern. |
| `getThemeManager()` | Ger åtkomst till master‑tema‑API:erna. |
| `getHeaderFooterManager()` | Kontrollerar sidhuvuden, sidfötter, datum och bildnummer för mastern och dess underliggande layouter. |
| `getDependingSlides()` | Returnerar normala bilder som beror på mastern genom sina layouter. |

## **Lägg till en Bild i en Slide Master**

När du lägger till en bild i en master‑bild visas den på bilder som använder layouter från den mastern. Detta är användbart för logotyper, vattenstämplar, dekorativa band och andra återkommande visuella element.

Följande exempel lägger till en logotyp på den första master‑bilden:

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

För mer information om bildramar, se [Picture Frame](/nodejs-java/picture-frame/).

## **Arbeta med Platshållare**

Platshållare definieras normalt på layout‑bilder. Master‑bilden tillhandahåller den gemensamma stilen och temat som dessa layouter ärver, medan varje layout bestämmer vilka platshållare som är tillgängliga och var de placeras.

I PowerPoint finns platshållarkommandon i Slide Master‑vyn.

![Infoga platshållarkommandot i PowerPoint Slide Master‑vy](slide-master_5.png)

För att lägga till nya platshållare med Aspose.Slides, arbeta med layout‑bilden som tillhör mastern:

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

Du kan också formatera platshållarformer som redan finns på en master‑bild. Följande exempel hittar titel‑platshållaren och tillämpar en linjär gradientfyllning:

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

![Formaterad titel‑platshållare ärvd av normala bilder](slide-master_8.png)

För fler alternativ för platshållare och textformatering, se [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) och [Text Formatting](/nodejs-java/text-formatting/).

## **Ändra Bakgrund för en Slide Master**

En master‑bakgrund ärvs av layouter och bilder som inte åsidosätter den. Följande exempel sätter en solid bakgrundsfärg för den första master‑bilden:

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

För relaterade ämnen, se [Presentation Background](/nodejs-java/presentation-background/) och [Presentation Theme](/nodejs-java/presentation-theme/).

## **Klona en Slide Master till En Annan Presentation**

Använd `MasterSlideCollection.addClone` för att kopiera en master‑bild till en annan presentation. Den kopierade mastern kan sedan användas av layouter och bilder i destinationspresentationen.

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

Om du behöver klona normala bilder tillsammans med deras master, se [Clone Slides](/nodejs-java/clone-slides/).

## **Lägg till Flera Slide Masters**

En presentation kan innehålla flera master‑bilder. Detta är användbart när olika avsnitt kräver olika varumärkesprofil, sidstruktur eller temainställningar.

![PowerPoint‑kommandon för att infoga och hantera master‑bilder](slide-master_9.jpg)

Följande exempel klonar standard‑mastern, ger kopian en annan bakgrund, skapar en layout under den klonade mastern och lägger till en ny bild baserad på den layouten:

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

## **Jämför Slide Masters**

Master‑bilder kan jämföras med `equals`‑metoden som ärvd från [BaseSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/). Jämförelsen kontrollerar struktur och statiskt innehåll, såsom former, text, formatering, animationer och andra bildinställningar. Den jämför inte unika identifierare, såsom bild‑ID:n, eller dynamiska platshållarvärden, såsom aktuellt datum.

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

För mer information, se [Compare Presentation Slides](/nodejs-java/compare-slides/).

## **Ställ in Slide Master‑vyn som Standardvy**

Använd `setLastView`‑metoden på [ViewProperties](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/viewproperties/) för att styra vilken vy PowerPoint öppnar först. Följande exempel öppnar presentationen i Slide Master‑vyn:

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

För fler vyinställningar, se [Save Presentation](/nodejs-java/save-presentation/).

## **Ta Bort Oanvända Master‑bilder**

Presentationer kan ibland innehålla master‑bilder som inte längre används av några normala bilder. Att ta bort oanvända master‑bilder kan minska filstorleken och förenkla underhållet av mallar.

Använd `removeUnused` för att ta bort oanvända master‑bilder från samlingen `getMasters()`:

```javascript
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Du kan också använda low‑code‑metoden `Compress.removeUnusedMasterSlides`:

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

**Vad är skillnaden mellan en slide master och en layout‑bild?**

En slide master definierar delade designinställningar som tema, bakgrund, gemensamma former och textstilar. En layout‑bild tillhör en master‑bild och definierar en specifik placering av platshållare. En normal bild använder en layout‑bild, så den ärver både från layouten och master‑bilden.

**Kan en presentation innehålla flera slide masters?**

Ja. En presentation kan innehålla flera slide masters. Använd flera master‑bilder när olika avsnitt behöver olika visuella system eller varumärkesprofiler.

**Ska jag lägga till platshållare på en master‑bild eller en layout‑bild?**

I de flesta fall lägger du till platshållare på layout‑bilder. Sätt delade visuella element och gemensam formatering på master‑bilden, och placera innehålls‑platshållare på de layouter som normala bilder kommer att använda.

**Kan jag ta bort en master‑bild som fortfarande används?**

Nej. En master‑bild som har beroende bilder kan inte tas bort säkert direkt. Flytta först dessa bilder till layouter under en annan master, eller använd en metod för att rensa oanvända master‑bilder som endast tar bort master‑bilder som inte används.