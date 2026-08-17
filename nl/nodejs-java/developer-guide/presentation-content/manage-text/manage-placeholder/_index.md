---
title: Beheer presentatie‑placeholders in JavaScript
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/nodejs-java/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeelding‑placeholder
- diagram‑placeholder
- inhouds‑placeholder
- prompttekst
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u tekst‑, afbeelding‑, diagram‑ en inhouds‑placeholders kunt inspecteren en bewerken en de placeholder‑erfenis begrijpt met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald soort inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, lichaam, afbeelding, diagram en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑outrij of masterslide.

Aspose.Slides geeft placeholder‑informatie weer via de [Shape.getPlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getPlaceholder)‑methode. De methode retourneert een [Placeholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholder/)‑object of `null` voor een normale vorm. Gebruik [Placeholder.getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholder/#getType) om te bepalen wat de placeholder moet bevatten.

De vormklasse blijft van belang nadat je het placeholder‑type kent:

- Een lege tekst-, afbeelding‑, diagram‑ of inhouds‑placeholder wordt meestal weergegeven door een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/).
- Een gevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/).
- Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/).
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder.getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholder/#getType) als de runtime‑vormklasse in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholder/#getType) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat je tekst, afbeelding, diagram, tabel of media‑specifieke leden benadert.
{{% /alert %}}

## **Placeholder‑erfenis begrijpen**

Placeholders vormen een hiërarchie:

1. Een masterslide definieert herbruikbare stijlen en, in sommige gevallen, placeholders op masterniveau.
2. Een lay‑outrij definieert de indeling die door één of meer normale slides wordt gebruikt en kan erven van de master.
3. Een normale slide bevat de placeholders voor die slide en kan erven van zijn lay‑outrij.

Roep [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) aan om een niveau hoger in deze hiërarchie te gaan. Een slide‑placeholder retourneert normaal zijn lay‑outrij‑placeholder; een lay‑outrij‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft een lijst van placeholders op de eerste slide en meldt hun basis‑placeholders:

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

Een placeholder op een normale slide bewerken creëert of wijzigt een lokale override voor die slide. Het bewerken van de gerelateerde lay‑outrij of master kan alle slides beïnvloeden die nog steeds die instelling erven. Een gewone lokale vorm heeft geen basis‑placeholder en begint niet met erven alleen omdat hij dezelfde coördinaten inneemt.

## **Tekst in een placeholder wijzigen**

Titel‑, gecentreerde‑titel‑, ondertitel‑, lichaam‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) voordat je de [getTextFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/#getTextFrame)‑methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste slide bij en slaat het resultaat op:

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

Dit patroon voorkomt dat afbeelding‑, diagram‑, tabel‑ of media‑placeholders worden behandeld als [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/)‑objecten. Het identificeert de placeholder bovendien op basis van doel in plaats van te vertrouwen op een fragiele vorm‑index.

## **Prompt‑tekst instellen op een lay‑outrij**

Prompt‑tekst is de ontwerp‑tijd instructie die wordt weergegeven in een lege placeholder, zoals *Klik om een titel toe te voegen*. Stel aangepaste prompt‑tekst in op de lay‑outrij‑placeholder in plaats van te proberen deze via de vorm‑collectie van een normale slide te bereiken. Benader de lay‑outrij via [Slide.getLayoutSlide](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getLayoutSlide) en iterate over de collectie die wordt geretourneerd door [BaseSlide.getShapes](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/baseslide/#getShapes).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de lay‑outrij die door de eerste slide wordt gebruikt:

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

Prompt‑tekst is geen normale slide‑inhoud. Het is bedoeld voor lege placeholders in bewerkings‑applicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op slides die de lay‑outrij gebruiken.

## **Een afbeelding‑placeholder bijwerken**

Er zijn twee gevallen te behandelen:

- Als de afbeelding‑placeholder al gevuld is en wordt weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/), vervang de afbeelding via [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picturefillformat/#getPicture) en [Picture.setImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/picture/#setImage).
- Als het nog een lege placeholder is, voeg een picture frame toe op de coördinaten van de placeholder met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) en verwijder de lege placeholder.

Het volgende voorbeeld ondersteunt beide gevallen en slaat de presentatie op:

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

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal picture frame, geen nieuwe placeholder, omdat [Shape.getPlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getPlaceholder) geen setter biedt. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul de placeholder eerst in PowerPoint, en werk vervolgens het resulterende [PictureFrame](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor beeld‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/nodejs-java/picture-frame/). Die bewerkingen behoren tot het picture frame of picture fill, niet tot placeholder‑metadata.

## **Werken met diagram‑ en inhouds‑placeholders**

Een gevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/). Dit voorbeeld zoekt zo’n diagram op basis van zowel placeholder‑type als runtime‑klasse, wijzigt de titel en slaat het bestand op:

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

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholdertype/#Object). In PowerPoint fungeert hij als een lanceerder voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteer je de daadwerkelijke vormklasse om te weten wat erin zit. Gespecialiseerde lay‑outrijen kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholdertype/#Media) of [PlaceholderType.Diagram](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholdertype/#Diagram) blootleggen.

Aspose.Slides converteert geen lege [AutoShape](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/autoshape/) placeholder naar een [Chart](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/chart/) alleen door [Placeholder.getType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/placeholder/#getType) te wijzigen; het type kan niet via het object worden aangepast. Om een leeg diagram of een inhoudsgebied programmatisch te vullen, voeg je het benodigde object toe op de coördinaten van de placeholder en verwijder je vervolgens de lege placeholder. Het volgende voorbeeld doet dit voor een diagram:

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

Het toegevoegde diagram is een gewone lokaal diagram. Het neemt het gebied van de placeholder in, maar erft niet van de lay‑outrij‑placeholder. Gebruik de toegewijde [chart management articles](/slides/nl/nodejs-java/powerpoint-charts/) wanneer je de categorieën, series of workbook‑data moet vervangen.

## **Volledig voorbeeld: Tekst of afbeeldingsinhoud bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt in de eerste slide naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vormtypes, werkt de juiste inhoud bij en slaat de output op. Het voorbeeld vermijdt bewust aannames over een vorm‑index of het behandelen van elke placeholder als dezelfde klasse.

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

**Wat is een basis‑placeholder?**

Een basis‑placeholder is de overeenkomstige vorm op de lay‑outrij of master waarvan een andere placeholder erft. Gebruik [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle slide‑titels wijzigen door een lay‑outrij‑placeholder aan te passen?**

Je kunt geërfde opmaak of prompt‑tekst wijzigen via een lay‑outrij, maar bestaande titelinhoud staat opgeslagen op de normale slides. Om de werkelijke titeltekst in een hele presentatie te vervangen, iterate je over de slides en werk je elke titel‑placeholder bij.

**Hoe beheer ik datum‑, slide‑nummer‑, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op het juiste niveau: slide, lay‑outrij, master, notities of hand-out. Zie [Manage Presentation Header and Footer](/slides/nl/nodejs-java/presentation-header-and-footer/) voor volledige voorbeelden.