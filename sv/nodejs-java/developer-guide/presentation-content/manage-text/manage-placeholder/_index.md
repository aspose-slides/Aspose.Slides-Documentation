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
description: "Lär dig hur du granskar och redigerar text-, bild-, diagram- och innehållsplatshållare samt förstår platshållarärvning med Aspose.Slides för Node.js via Java."
---
## **Översikt**

En platshållare är en form som reserverar en position för en viss typ av innehåll i en presentationsmall. Vanliga exempel är titel, brödtext, bild, diagram och generella innehållsplatshållare. Till skillnad från en vanlig form kan en platshållare ärva sin position, storlek, formatering och andra inställningar från en layoutbild eller huvudbild.

Aspose.Slides exponerar platshållarinformation via metoden [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder). Metoden returnerar ett [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/)‑objekt eller `null` för en normal form. Använd [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) för att bestämma vad platshållaren är avsedd att innehålla.

Formklassen är fortfarande viktig efter att du känner till platshållartypen:

- En tom text‑, bild‑, diagram‑ eller innehållsplatshållare representeras vanligtvis av en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- En ifylld bildplatshållare kan representeras av en [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- En innehållsplatshållare kan innehålla flera typer av innehåll. Kontrollera både [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) och den faktiska formklassen istället för att anta att varje platshållare är en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) beskriver en platshållares roll; den garanterar inte formens faktiska typ. Använd alltid en typkontroll innan du får tillgång till text-, bild-, diagram-, tabell- eller mediespecifika medlemmar.
{{% /alert %}}

## **Förstå ärvning av platshållare**

Platshållare bildar en hierarki:

1. En huvudbild definierar återanvändbara stilar och, i vissa fall, platshållare på huvudnivå.
2. En layoutbild definierar arrangemanget som används av en eller flera vanliga bilder och kan ärva från huvudbilden.
3. En normal bild innehåller platshållarna för den bilden och kan ärva från dess layout.

Anropa [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) för att gå upp en nivå i denna hierarki. En bildplatshållare returnerar normalt sin layoutplatshållare; en layoutplatshållare kan returnera sin huvudplatshållare. Metoden returnerar `null` när formen inte har någon basplatshållare.

Följande exempel listar platshållare på den första bilden och rapporterar deras basplatshållare:

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

Att redigera en platshållare på en normal bild skapar eller ändrar en lokal överskrivning för den bilden. Att redigera den relaterade layouten eller huvudbilden kan påverka alla bilder som fortfarande ärver den inställningen. En lokal vanlig form har ingen basplatshållare och börjar inte ärva bara för att den har samma koordinater.

## **Ta bort platshållarstatus**

När du anpassar en mall, använd [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) för att behålla ett befintligt objekt som en vanlig form. Dess [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder)‑metod returnerar `null`, men formen förblir i bildens samling. I motsats till detta tar [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) bort formen från den samlingen.

Följande exempel kräver `template.pptx` med minst en bild och en icke‑tom textplatshållare på den första bilden. Använd en platshållare med formatering ärvd från dess layout eller huvud för att se effekten av att ta bort den relationen. Exemplet kontrollerar att samma form förblir, anropar metoden igen på den nu vanliga formen och sparar resultatet.

{{% alert color="warning" title="Warning" %}}
Att ta bort platshållarstatus bevarar inte automatiskt ärvda utseendeinställningar. Exemplet nedan lämnar avsiktligt dessa inställningar oförändrade, så utdata kan se annorlunda ut. En form vars position och storlek är helt ärvda kan ha nollkoordinater och dimensioner efter anropet och bli osynlig även om den fortfarande finns i samlingen.
{{% /alert %}}

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shapes = slide.getShapes();
    let found = false;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const textFrame = shape.getTextFrame();
        if (shape.getPlaceholder() == null || textFrame == null) {
            continue;
        }

        const text = textFrame.getText();
        if (text == null || text.length === 0) {
            continue;
        }

        const shapeCount = shapes.size();
        shape.removePlaceholder();

        console.log("Placeholder removed: " + (shape.getPlaceholder() == null));
        const retainedShape = shapes.get_Item(index);
        console.log("Same shape retained: " + shape.equals(retainedShape));
        console.log("Shape count unchanged: " + (shapes.size() === shapeCount));

        // Att anropa metoden på en vanlig form har ingen effekt.
        shape.removePlaceholder();
        found = true;
        break;
    }

    if (found) {
        presentation.save("placeholder-status-removed.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("No nonempty text placeholder was found on the first slide.");
    }
} finally {
    presentation.dispose();
}
```

För en matchande platshållare skriver alla tre kontrollerna ut `true`. Texten förblir, men ärvd position, storlek, rotation, teckensnitt, styckejustering, marginaler för textram, vertikal förankring, fyllning och linjeinställningar kan förändras när platshållarrelationen tas bort. Till exempel kan ärvd titelformatering falla tillbaka till vanlig textformatering. Se [Slide Layout](/slides/sv/nodejs-java/slide-layout/) för mer om layouter.

För att bevara det avsedda utseendet, fånga den lösta positionen, storleken och rotationen före anropet, och kopiera de erforderliga effektiva formateringsvärdena till separata variabler. Hämta dessa värden via [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective) och [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Lita inte enbart på att behålla effektiva formatobjekt, eftersom deras textformateringsvärden kan förändras efter att relationen har tagits bort. Applicera explicit de fångade värdena på den vanliga formen därefter, inklusive teckensnittsfamilj, storlek, stil, färg, styckeinställningar, textraminställningar, fyllning och linje som används i din mall.

Ärvd formgeometri kan också behöva tilldelas explicit via [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). För en rektangulär textplatshållare betyder detta att tilldela [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); att bara återställa fyllning och linje kanske inte återställer den synliga rektangeln. Mallar med ytterligare effekter eller mer komplex formatering kräver också att dessa inställningar hanteras.

## **Ändra text i en platshållare**

Titel-, centrerad titel-, underrubrik-, brödtext- och textplatshållare stöder normalt text. Kontrollera att det är en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) innan du använder dess [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame)‑metod.

Detta exempel uppdaterar den första titelplatshållaren på den första bilden och sparar resultatet:

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

Detta mönster undviker att behandla bild-, diagram-, tabell- eller mediaplatshållare som [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)‑objekt. Det identifierar också platshållaren efter syfte istället för att förlita sig på ett ömtåligt formindex.

## **Ange uppmaningstext på en layout**

Uppmaningstext är designtidens instruktion som visas i en tom platshållare, t.ex. *Klicka för att lägga till titel*. Ställ in anpassad uppmaningstext på layoutens platshållare istället för att försöka nå den via en normal bilds formsamling. Åtkomst till layouten sker via [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) och iterera över samlingen som returneras av [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

Följande exempel ändrar titel- och underrubrikuppmaningarna i den layout som används på den första bilden:

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

Uppmaningstext är inte normalt bildinnehåll. Den är avsedd för tomma platshållare i redigeringsprogram som PowerPoint. När en användare eller ett program tillhandahåller verkligt innehåll visas uppmaningen inte längre. Att ändra en uppmaning ersätter inte heller befintlig text på bilder som använder layouten.

## **Uppdatera en bildplatshållare**

Det finns två fall att hantera:

- Om bildplatshållaren redan är ifylld och representeras av en [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), ersätt bilden via [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture) och [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Om den fortfarande är en tom platshållare, lägg till en bildram på platshållarens koordinater med [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) och ta bort den tomma platshållaren.

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

Ersättningen som skapats för en tom platshållare är en lokal bildram, inte en ny platshållare, eftersom [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) inte har en setter. Den behåller den reserverade positionen men ärver inte längre platshållarspecifikt beteende. Om det är viktigt att behålla platshållarrelationen, förbered och fyll platshållaren i PowerPoint först, och uppdatera sedan den resulterande [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) med Aspose.Slides.

För bildtransparens, beskärning och andra bildspecifika effekter, se [Manage Picture Frames](/slides/sv/nodejs-java/picture-frame/). Dessa operationer hör till bildramen eller bildfyllningen, inte till platshållarmetadata.

## **Arbeta med diagram- och innehållsplatshållare**

En ifylld diagramplatshållare kan representeras av ett [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Detta exempel hittar ett sådant diagram både via platshållartyp och körklass, ändrar dess titel och sparar filen:

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

En generell innehållsplatshållare har vanligtvis [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). I PowerPoint fungerar den som en startpunkt för flera innehållstyper, inklusive diagram, tabeller, diagram, bilder och media. Efter att den har fyllts, inspektera den faktiska formklassen för att ta reda på vad den innehåller. Specialiserade layouter kan också exponera [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media) eller [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides konverterar inte en tom [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/)‑platshållare till ett [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) enbart genom att ändra [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType); typen kan inte ändras via objektet. För att programatiskt fylla ett tomt diagram eller innehållsområde, lägg till det nödvändiga objektet på platshållarens koordinater och ta sedan bort den tomma platshållaren. Följande exempel gör detta för ett diagram:

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

Det tillagda diagrammet är ett vanligt lokalt diagram. Det upptar platshållarens område men ärver inte från layoutplatshållaren. Använd de dedikerade [chart management articles](/slides/sv/nodejs-java/powerpoint-charts/) när du behöver ersätta dess kategorier, serier eller arbetsboksdata.

## **Fullständigt exempel: Uppdatera text- eller bildinnehåll**

Följande helhetsexempel öppnar en mall, söker den första bilden efter antingen en titel‑ eller bildplatshållare, kontrollerar platshållar‑ och formtyper, uppdaterar lämpligt innehåll och sparar utdata. Exemplet undviker avsiktligt att anta ett formindex eller behandla varje platshållare som samma klass.

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

**Vad är en basplatshållare?**

En basplatshållare är den motsvarande formen på layouten eller huvudbilden som en annan platshållare ärver från. Använd [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) för att hämta den. En vanlig lokal form returnerar `null` eftersom den inte är en del av platshållarhierarkin.

**Kan jag ändra alla bildtitlar genom att redigera en layoutplatshållare?**

Du kan ändra ärvd formatering eller uppmaningstext via en layout, men befintligt titelinnehåll lagras på de normala bilderna. För att ersätta faktisk titeltext i hela en presentation, iterera över bilderna och uppdatera varje titelplatshållare.

**Hur hanterar jag datum-, bildnummer-, sidhuvud- och sidfotplatshållare?**

Använd header- och footermgrarna på lämplig bild, layout, huvud, anteckningar eller utdelningsnivå. Se [Manage Presentation Header and Footer](/slides/sv/nodejs-java/presentation-header-and-footer/) för fullständiga exempel.