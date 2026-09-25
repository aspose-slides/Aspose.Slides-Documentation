---
title: Creëer 3D‑effecten in presentaties met Node.js
linktitle: 3D‑presentatie
type: docs
weight: 232
url: /nl/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentatie
- 3D‑rotatie
- 3D‑diepte
- 3D‑extrusie
- 3D‑verloop
- 3D‑tekst
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en –tekst in Node.js met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides for Node.js via Java kan vormen en tekst creëren, bewerken, behouden en weergeven met PowerPoint‑achtige 3D‑opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, afgeschuinde randen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modelfiles. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten voor 3D‑opmaak**

Gebruik de [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getThreeDFormat) methode om 3D‑opmaak op een vorm toe te passen. De methode retourneert [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/), die de 3D‑scene voor die vorm regelt.

Voor tekst gebruikt u de [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) methode. Deze past 3D‑opmaak toe op het tekstframe in plaats van op het vormlichaam.

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getCamera) | Gezichtsstandpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in de 3D‑ruimte of pas een PowerPoint‑rotatie‑preset toe. |
| [getLightRig](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getLightRig) | Vooraf ingestelde verlichting, richting en lichtrotatie. | Verander hoe highlights en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getMaterial) en [setMaterial](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setMaterial) | Oppervlaktmateriaal, zoals plat, mat, plastic of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metallischer uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Hoe ver de vorm zich naar achteren uitstrekt vanaf de voorzijde. | Verander een vlakke vorm in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Kleur van de uitgeprinte zijkanten. | Maak diepte zichtbaar of stem de zijkleur af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getDepth) en [setDepth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setDepth) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Fijnafstelling van diepte voor vormen of tekst, vooral in combinatie met afgeschuinde randen en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getBevelTop) en [getBevelBottom](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe vlakke rand. |
| [getContourColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getContourWidth) en [setContourWidth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Contour rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat deze overtuigend 3D oogt:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Verlichtingsinstellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak bepaalt hoe het licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camerarotatiewaarden zijn in graden, en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op tweemaal de standaardafmetingen en slaat de presentatie op als PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blokken:

![Gerenderde blauwe 3D-rechthoek met witte 3D-tekst op de voorzijde](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u toegang tot de camera via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getCamera). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch vooraanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Gebruik de camera wanneer u wilt wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑zichtpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑regelaar deze zichtbare dikte, en de kleur‑regelaar bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑regelaars gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Gebruik [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) om de dikte in te stellen en [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) om de kleur van de zijkanten op te halen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en roteert de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

De methode [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setDepth) stelt de diepte van een 3D‑vorm in. De methode [setExtrusionHeight](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) regelt de hoogte van het extrusie‑effect, zoals getoond in dit voorbeeld.

## **Verloop‑ of afbeeldingvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorzijde toepassen en toch dezelfde camera-, licht-, materiaal- en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de extrusie van 150 punten. De verloopstops bij 0 en 100 markeren het begin en einde van het verloop. De camerarotatiewaarden zijn in graden. De dia wordt gerenderd naar een PNG‑afbeelding op tweemaal de standaardafmetingen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe, en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑wit rasterpatroon, past een omhoog gerichte boog toe en configureert 3D‑instellingen via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). De extrusiehoogte en diepte zijn in punten, en de lichtrotatie is in graden. De vormvulling en omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op tweemaal de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gerenderde 3D‑tekst met een gebogen WordArt-transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Tekst plat houden op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑vorm behouden blijft, roept u [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) aan via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer de waarde `false` is, neemt de tekst deel aan de scene en volgt deze de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getThreeDFormat). Het is ook anders dan gewone rotatie. [Shape.setRotation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#setRotation) roteert de vorm in het dia‑vlak, terwijl [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) de aangepaste rotatie van de tekst binnen de omhullende regelt. Tekst buiten de 3D‑scene houden, reset geen van deze hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstopzetting verschilt: `false` links en `true` rechts. De camera‑hoeken zijn in graden, en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op tweemaal de standaardafmetingen.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Aan de linkerkant volgt de tekst de 3D‑oriëntatie. Aan de rechterkant blijft deze plat en makkelijker leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft plat rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/nodejs-java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/nodejs-java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/nodejs-java/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/nodejs-java/convert-powerpoint-to-video/).

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtopstelling, materiaal, extrusie, vulling en dia‑schaling.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vorm‑eigenschappen](/slides/nl/nodejs-java/shape-effective-properties/).
- Sommige uitvoerformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **Veelgestelde vragen**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en renderen PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s niet tot interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of tekst, zoals rotatie, extrusie, afgeschuinde randen, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een camerarotatie instellen en ofwel extrusie of diepte. In de praktijk stelt u ook een lichtopstelling en materiaal in zodat de gerenderde gezichten duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [Shape.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getThreeDFormat) voor het vormlichaam en [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) voor tekst.

**Zien 3D‑effecten er uit bij export naar afbeeldingen, PDF, HTML of video‑frames?**

Ja. Aspose.Slides renderen 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. Het geëxporteerde resultaat bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de definitieve 3D‑waarden lezen nadat er erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/nodejs-java/shape-effective-properties/) om de uiteindelijke camera‑, lichtopstelling‑, afgeschuinde‑rand‑ en gerelateerde 3D‑waarden te lezen.