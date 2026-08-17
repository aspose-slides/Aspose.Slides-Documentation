---
title: Hantera presentationsplatshållare i JavaScript
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/nodejs-java/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- innehållsplatshållare
- uppmaningstext
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lär dig hur du granskar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärv med Aspose.Slides för Node.js via Java."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och allmänna innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller masternivå.

Aspose.Slides exponerar platshållarinformation via metoden [Shape.getPlaceholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getPlaceholder). Metoden returnerar ett [Placeholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholder/)‑objekt eller `null` för en normal form. Använd [Placeholder.getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholder/#getType) för att avgöra vad platshållaren är avsedd att innehålla.

Formklassen är fortfarande viktig efter att du känner till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras vanligtvis av en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).
- En ifylld bildplatshållare kan representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/).
- En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/).
- En innehållsplatshållare kan innehålla flera olika typer av innehåll. Kontrollera både [Placeholder.getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholder/#getType) och den körningsspecifika formklassen istället för att anta att varje platshållare är en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholder/#getType) beskriver en platshållares roll; den garanterar inte formens körningstidstyp. Använd alltid en typkontroll innan du får åtkomst till text-, bild-, diagram-, tabell‑ eller mediespecifika medlemmar.
{{% /alert %}}

## **Förstå platshållarärv**

Platshållare bildar en hierarki:

1. En masternivåbild definierar återanvändbara stilar och, i vissa fall, masternivå‑platshållare.
2. En layoutbild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från mastern.
3. En vanlig bild innehåller platshållarna för den bilden och kan ärva från sin layout.

Anropa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getBasePlaceholder) för att gå ett steg upp i denna hierarki. En bildplatshållare returnerar normalt sin layout‑platshållare; en layout‑platshållare kan returnera sin masternivå‑platshållare. Metoden returnerar `null` när formen inte har någon bas‑platshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras bas‑platshållare:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Att redigera en platshållare på en vanlig bild skapar eller förändrar en lokal överskrivning för den bilden. Att redigera den relaterade layouten eller mastern kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen bas‑platshållare och börjar inte ärva bara för att den upptar samma koordinater.

## **Ändra text i en platshållare**

Titel‑, centrerad‑titel‑, undertitel‑, brödtext‑ och text‑platshållare stödjer normalt text. Kontrollera att det är en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) innan du använder dess [getTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/#getTextFrame)‑metod.

Detta exempel uppdaterar den första titel‑platshållaren på den första bilden och sparar resultatet:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mönstret undviker att behandla bild‑, diagram‑, tabell‑ eller mediaplatshållare som [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/)‑objekt. Det identifierar också platshållaren efter syfte istället för att förlita sig på ett skört formindex.

## **Ange uppmaningstext på en layout**

Uppmaningstext är design‑tidsinstruktionen som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ange anpassad uppmaningstext på layout‑platshållaren snarare än att försöka nå den via en vanlig bilds formsamling. Kom åt layouten via [Slide.getLayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getLayoutSlide) och iterera över samlingen som returneras av [BaseSlide.getShapes](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseslide/#getShapes).

Följande exempel ändrar titel‑ och undertitel‑uppmaningar på layouten som används av den första bilden:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Uppmaningstext är inte vanligt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller riktigt innehåll visas uppmaningen inte längre. Att ändra en uppmaning ersätter inte befintlig text på bilder som använder layouten.

## **Uppdatera en bild‑platshållare**

Det finns två situationer att hantera:

- Om bild‑platshållaren redan är ifylld och representeras av en [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/), ersätt bilden via [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picturefillformat/#getPicture) och [Picture.setImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/picture/#setImage).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) och ta bort den tomma platshållaren.

Nästa exempel stödjer båda fallen och sparar presentationen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ersättningen som skapades för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [Shape.getPlaceholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getPlaceholder) inte har någon setter. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är viktigt att bevara platshållarförhållandet, förbered och fyll i platshållaren i PowerPoint först, och uppdatera sedan den resulterande [PictureFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/pictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/nodejs-java/picture-frame/). Dessa operationer hör till bildramen eller bildfyllningen, inte till platshållarmetadata.

## **Arbeta med diagram‑ och innehållsplatshållare**

En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/). Detta exempel hittar ett sådant diagram genom både platshållartyp och körningsklass, ändrar dess titel och sparar filen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

En allmän innehållsplatshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholdertype/#Object). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. När den har fyllts i, inspektera den faktiska formklassen för att lära dig vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholdertype/#Media) eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides konverterar inte en tom [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/)‑platshållare till ett [Chart](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/chart/) enbart genom att ändra [Placeholder.getType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/placeholder/#getType); typen kan inte ändras via objektet. För att fylla ett tomt diagram‑ eller innehållsområde programmässigt, lägg till det nödvändiga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layout‑platshållaren. Använd de dedikerade [chart management articles](/slides/sv/nodejs-java/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsbokdata.

## **Fullständigt exempel: Uppdatera text‑ eller bildinnehåll**

Följande end‑to‑end‑exempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bild‑platshållare, kontrollerar platshållar‑ och formtyper, uppdaterar lämpligt innehåll och sparar resultatet. Exemplet undviker medvetet att anta ett formindex eller att behandla varje platshållare som samma klass.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Vad är en bas‑platshållare?**

En bas‑platshållare är den motsvarande formen på layouten eller mastern som en annan platshållare ärver från. Använd [Shape.getBasePlaceholder](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getBasePlaceholder) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte är en del av platshållar‑hierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layout‑platshållare?**

Du kan ändra ärvd formatering eller uppmaningstext via en layout, men befintligt titel‑innehåll lagras på de vanliga bilderna. För att ersätta faktiska titeltexter i en hel presentation, iterera över bilderna och uppdatera varje titel‑platshållare.

**Hur hanterar jag datum‑, bildnummer‑, sidhuvud‑ och sidfot‑platshållare?**

Använd sidhuvuds‑ och sidfotshanterarna på lämplig bild, layout, master, antecknings‑ eller utdelningssida. Se [Manage Presentation Header and Footer](/slides/sv/nodejs-java/presentation-header-and-footer/) för kompletta exempel.