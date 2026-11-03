---
title: Beheer presentatieplaceholders in JavaScript
linktitle: Beheer Placeholders
type: docs
weight: 10
url: /nl/nodejs-java/manage-placeholder/
keywords:
- plaatsaanduiding
- tekstplaatsaanduiding
- afbeeldingsplaatsaanduiding
- diagramplaatsaanduiding
- inhoudsplaatsaanduiding
- prompttekst
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Leer hoe u tekst-, afbeelding-, diagram- en inhoudsplaceholders kunt inspecteren en bewerken en hoe u placeholder‑erfenis begrijpt met Aspose.Slides voor Node.js via Java."
---
## **Overzicht**

Een placeholder is een vorm die een positie reserveert voor een bepaald type inhoud in een presentatiesjabloon. Veelvoorkomende voorbeelden zijn titel, inhoud, afbeelding, diagram en algemene inhouds‑placeholders. In tegenstelling tot een gewone vorm kan een placeholder zijn positie, grootte, opmaak en andere instellingen erven van een lay‑out‑dia of master‑dia.

Aspose.Slides maakt placeholder‑informatie beschikbaar via de [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) methode. De methode retourneert een [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) object of `null` voor een normale vorm. Gebruik [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) om te bepalen wat de placeholder bedoeld is te bevatten.

De vormklasse blijft relevant nadat u het placeholder‑type kent:

- Een lege tekst‑, afbeelding‑, diagram‑ of inhouds‑placeholder wordt meestal weergegeven door een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
- Een ingevulde afbeelding‑placeholder kan worden weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/).
- Een ingevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/).
- Een inhouds‑placeholder kan verschillende soorten inhoud bevatten. Controleer zowel [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) als de runtime‑vormklasse in plaats van aan te nemen dat elke placeholder een [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) is.

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) beschrijft de rol van een placeholder; het garandeert niet het runtime‑type van de vorm. Gebruik altijd een type‑check voordat u tekst, afbeelding, diagram, tabel of media‑specifieke leden benadert.
{{% /alert %}}

## **Begrijp Placeholder‑erfenis**

Placeholders vormen een hiërarchie:

1. Een master‑dia definieert herbruikbare stijlen en, in sommige gevallen, master‑niveau placeholders.
2. Een lay‑out‑dia definieert de indeling die wordt gebruikt door een of meer normale dia's en kan erven van de master.
3. Een normale dia bevat de placeholders voor die dia en kan erven van de lay‑out.

Roep [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) aan om één niveau hoger in deze hiërarchie te gaan. Een dia‑placeholder retourneert normaal zijn lay‑out‑placeholder; een lay‑out‑placeholder kan zijn master‑placeholder retourneren. De methode retourneert `null` wanneer de vorm geen basis‑placeholder heeft.

Het volgende voorbeeld geeft de placeholders op de eerste dia weer en rapporteert hun basis‑placeholders:

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

Een placeholder bewerken op een normale dia maakt een lokale overschrijving voor die dia aan of wijzigt deze. Het bewerken van de bijbehorende lay‑out of master kan alle dia's beïnvloeden die die instelling nog steeds erven. Een lokale gewone vorm heeft geen basis‑placeholder en begint niet met erven alleen omdat hij dezelfde coördinaten beslaat.

## **Placeholder‑status Verwijderen**

Wanneer u een sjabloon aanpast, gebruikt u [Shape.removePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#removePlaceholder) om een bestaand object als gewone vorm te behouden. De [getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) methode retourneert `null`, maar de vorm blijft in de collectie van de dia. In tegenstelling tot [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#remove) wordt de vorm uit die collectie verwijderd.

Het volgende voorbeeld vereist `template.pptx` met minstens één dia en een niet‑lege tekst‑placeholder op de eerste dia. Gebruik een placeholder met opmaak die is geërfd van de lay‑out of master om het effect van het verwijderen van die relatie te zien. Het voorbeeld controleert dat dezelfde vorm blijft bestaan, roept de methode opnieuw aan op de nu gewone vorm, en slaat het resultaat op:

{{% alert color="warning" title="Warning" %}}
Het verwijderen van placeholder‑status behoudt niet automatisch de geërfde weergave‑instellingen. Het onderstaande voorbeeld laat die instellingen bewust onaangepast, waardoor de uitvoer er anders kan uitzien. Een vorm waarvan positie en grootte volledig geërfd zijn, kan na de aanroep nul‑coördinaten en afmetingen hebben en onzichtbaar worden, ook al blijft hij in de collectie.
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

        // Het aanroepen van de methode op een gewone vorm heeft geen effect.
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

Voor een overeenkomende placeholder geven alle drie de controles `true` terug. De tekst blijft behouden, maar geërfde positie, grootte, rotatie, lettertype, alinea‑uitlijning, marges van het tekstkader, verticale verankering, opvulling en lijnafspraken kunnen veranderen wanneer de placeholder‑relatie wordt verwijderd. Bijvoorbeeld, geërfde titelopmaak kan terugvallen op gewone tekstopmaak. Zie [Slide Layout](/slides/nl/nodejs-java/slide-layout/) voor meer over lay‑outs.

Om de beoogde weergave te behouden, legt u de berekende positie, grootte en rotatie vast vóór de aanroep, en kopieert u de benodigde effectieve opmaak‑waarden naar afzonderlijke variabelen. Haal die waarden op via [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getEffective), en [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective). Vertrouw niet alleen op de effectieve‑opmaakobjecten, want hun tekst‑opmaakwaarden kunnen wijzigen nadat de relatie is verwijderd. Pas de vastgelegde waarden expliciet toe op de gewone vorm achteraf, inclusief lettertypefamilie, grootte, stijl, kleur, alinea‑instellingen, tekstkader‑instellingen, opvulling en lijn die door uw sjabloon worden gebruikt.

Geërfde vormgeometrie moet mogelijk ook expliciet worden toegewezen via [GeometryShape.setShapeType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/geometryshape/#setShapeType). Voor een rechthoekige tekst‑placeholder betekent dit het toewijzen van [ShapeType.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapetype/#Rectangle); alleen de opvulling en lijn herstellen, herstelt mogelijk niet de zichtbare rechthoek. Sjablonen met extra effecten of meer complexe opmaak vereisen dat die instellingen ook worden afgehandeld.

## **Tekst Wijzigen in een Placeholder**

Titel-, gecentreerde‑titel-, ondertitel-, body‑ en tekst‑placeholders ondersteunen normaal gesproken tekst. Controleer op [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) voordat u de [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) methode gebruikt.

Dit voorbeeld werkt de eerste titel‑placeholder op de eerste dia bij en slaat het resultaat op:

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

Dit patroon voorkomt dat afbeelding‑, diagram‑, tabel‑ of media‑placeholders als [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) objecten worden behandeld. Het identificeert de placeholder ook op basis van doel in plaats van te vertrouwen op een kwetsbare vorm‑index.

## **Prompt‑tekst Instellen op een Lay‑out**

Prompt‑tekst is de ontwerpinstructie die wordt weergegeven in een lege placeholder, zoals *Click to add title*. Stel aangepaste prompt‑tekst in op de lay‑out‑placeholder in plaats van te proberen deze te bereiken via de vormcollectie van een normale dia. Benader de lay‑out via [Slide.getLayoutSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#getLayoutSlide) en itereren over de collectie die wordt geretourneerd door [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes).

Het volgende voorbeeld wijzigt de titel‑ en ondertitel‑prompts op de lay‑out die door de eerste dia wordt gebruikt:

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

Prompt‑tekst is geen normale dia‑inhoud. Het is bedoeld voor lege placeholders in bewerkingsapplicaties zoals PowerPoint. Zodra een gebruiker of programma echte inhoud toevoegt, wordt de prompt niet meer weergegeven. Het wijzigen van een prompt vervangt ook niet de bestaande tekst op dia’s die de lay‑out gebruiken.

## **Afbeeldings‑placeholder Bijwerken**

Er zijn twee gevallen om af te handelen:

- Als de afbeelding‑placeholder al is gevuld en wordt weergegeven door een [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/), vervang dan de afbeelding via [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#getPicture), en [Picture.setImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/#setImage).
- Als het nog een lege placeholder is, voeg dan een afbeelding‑frame toe op de coördinaten van de placeholder met [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) en verwijder de lege placeholder.

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

De vervanging die voor een lege placeholder wordt gemaakt, is een lokaal picture‑frame, geen nieuwe placeholder, omdat [Shape.getPlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getPlaceholder) geen setter biedt. Het behoudt de gereserveerde positie maar erft niet langer placeholder‑specifiek gedrag. Als het behouden van de placeholder‑relatie essentieel is, bereid en vul dan eerst de placeholder in PowerPoint voor, en werk daarna het resulterende [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) bij met Aspose.Slides.

Voor beeld‑transparantie, bijsnijden en andere afbeelding‑specifieke effecten, zie [Manage Picture Frames](/slides/nl/nodejs-java/picture-frame/). Die bewerkingen behoren tot het picture‑frame of picture‑fill, niet tot placeholder‑metadata.

## **Werken met Diagram‑ en Inhouds‑placeholders**

Een ingevulde diagram‑placeholder kan worden weergegeven door een [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/). Dit voorbeeld vindt zo’n diagram op basis van zowel placeholder‑type als runtime‑klasse, wijzigt de titel, en slaat het bestand op:

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

Een algemene inhouds‑placeholder heeft meestal [PlaceholderType.Object](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Object). In PowerPoint fungeert deze als startpunt voor verschillende inhoudstypen, waaronder diagrammen, tabellen, diagrammen, afbeeldingen en media. Nadat hij is gevuld, inspecteer je de werkelijke vorm‑klasse om te ontdekken wat hij bevat. Gespecialiseerde lay‑outs kunnen ook [PlaceholderType.Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Media), of [PlaceholderType.Diagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholdertype/#Diagram) blootleggen.

Aspose.Slides zet een lege [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) placeholder niet om in een [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) enkel door [Placeholder.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/#getType) te wijzigen; het type kan niet via het object worden aangepast. Om een lege diagram‑ of inhouds‑ruimte programmatisch te vullen, voeg het vereiste object toe op de coördinaten van de placeholder en verwijder daarna de lege placeholder. Het volgende voorbeeld doet dat voor een diagram:

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

Het toegevoegde diagram is een gewone lokale diagram. Het beslaat het gebied van de placeholder maar erft niet van de lay‑out‑placeholder. Gebruik de speciale [chart management articles](/slides/nl/nodejs-java/powerpoint-charts/) wanneer u de categorieën, series of werkboekgegevens moet vervangen.

## **Compleet Voorbeeld: Tekst‑ of Afbeeldings‑inhoud Bijwerken**

Het volgende end‑to‑end voorbeeld opent een sjabloon, zoekt in de eerste dia naar een titel‑ of afbeelding‑placeholder, controleert de placeholder‑ en vorm‑typen, werkt de juiste inhoud bij, en slaat de uitvoer op. Het voorbeeld vermijdt opzettelijk de veronderstelling van een vorm‑index of het behandelen van elke placeholder als dezelfde klasse.

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

Een basis‑placeholder is de overeenkomstige vorm op de lay‑out of master waarvan een andere placeholder erft. Gebruik [Shape.getBasePlaceholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getBasePlaceholder) om deze op te halen. Een gewone lokale vorm retourneert `null` omdat hij geen deel uitmaakt van de placeholder‑hiërarchie.

**Kan ik alle dia‑titels wijzigen door een lay‑out‑placeholder te bewerken?**

U kunt geërfde opmaak of prompt‑tekst wijzigen via een lay‑out, maar bestaande titelinhoud wordt opgeslagen op de normale dia's. Om de werkelijke titeltekst in een hele presentatie te vervangen, iterateer over de dia's en werk elke titel‑placeholder bij.

**Hoe beheer ik datum-, dia‑nummer-, header‑ en footer‑placeholders?**

Gebruik de header‑ en footer‑managers op de juiste dia-, lay‑out-, master‑, notitie‑ of handout‑scope. Zie [Manage Presentation Header and Footer](/slides/nl/nodejs-java/presentation-header-and-footer/) voor volledige voorbeelden.