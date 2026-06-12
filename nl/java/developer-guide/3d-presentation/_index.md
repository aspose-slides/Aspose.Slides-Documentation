---
title: Maak 3D‑effecten in presentaties met Java
linktitle: 3D‑presentatie
type: docs
weight: 232
url: /nl/java/3d-presentation/
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
  - Java
  - Aspose.Slides
description: "Pas 3D‑effecten toe en render ze voor PowerPoint‑vormen en -tekst in Java met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides for Java kan vormen en tekst maken, bewerken, behouden en weergeven met PowerPoint‑achtige 3D‑opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop of afbeeldingvullingen, en 3D‑tekst.

{{% alert color="primary" %}}
Dit artikel gaat over 3D‑opmaak­effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modelfiles. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/).`getThreeDFormat()` om 3D‑opmaak toe te passen op een vorm. Het geretourneerde opmaakobject regelt de 3D‑scene voor die vorm.

Voor tekst gebruikt u [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Hiermee wordt 3D‑opmaak toegepast op het tekstframe in plaats van op de vorminhoud.

De belangrijkste API‑leden zijn:

| API‑lid | Waar het controleert | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getCamera--) | Bekijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in de 3D‑ruimte of stem overeen met een PowerPoint‑3D‑rotatie‑preset. |
| [getLightRig](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getLightRig--) | Verlichtingspreset, richting en lichtrotatie. | Wijzig hoe highlights en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlaktemateriaal, zoals vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metalen uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm naar achteren uitsteekt vanaf de voorzijde. | Zet een vlakke vorm om in een duidelijk dikke 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijkanten. | Maak diepte zichtbaar of stem de zijkleur af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Extra 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Fijnstem de diepte voor vormen of tekst, vooral in combinatie met bevel‑ en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte rand. |
| [getContourColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getContourWidth--), en [setContourWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omtrek rond het 3D‑object. | Benadruk de objectgrens in de gerenderde uitvoer. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Verlichtingsinstellingen, omdat verlichting de gezichten en zijden leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);
    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.BLUE);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Draai een vorm met de camera**

In PowerPoint wordt 3D‑rotatie ingesteld via het 3-D‑Rotatie‑venster. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑3‑D‑rotatie‑venster met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stelt u het kamertype en de rotatie in via de 3D‑opmaak die wordt geretourneerd door `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Gebruik de camera wanneer u wilt wijzigen hoe de kijker het object ziet. Het wijzigt niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel de extrusiehoogte in voor de dikte en de extrusiekleur voor de zijkleur:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Gebruik de diepte‑instelling wanneer u direct met de dieptewaarde van PowerPoint wilt werken of diepte wilt combineren met bevel, materiaal en texteffecten. In veel vormscenario’s is extrusiehoogte de duidelijkere instelling omdat het de zichtbare extrusie rechtstreeks uitdrukt.

## **Gebruik verloop‑ of afbeeldingvullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.ORANGE);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    Color extrusionColor = new Color(255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie afzonderlijk:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling:

```java
java.nio.file.Path imagePath = java.nio.file.Paths.get("image.jpg");
byte[] imageData = java.nio.file.Files.readAllBytes(imagePath);
IPPImage image = presentation.getImages().addImage(imageData);

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

Color extrusionColor = new Color(255, 140, 0);
shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

De foto wordt gerenderd op de voorzijde, terwijl de extrusie wordt gerenderd als het 3D‑zijoppervlak:

![Gerenderde 3D‑rechthoek met een foto­vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het lichaam van de vorm. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/):

```java
final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().setText("3D Text");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color patternColor = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5f);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);

    IImage thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/java/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/java/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, verlichting, materiaal, extrusie, vulling en schaal van de dia.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/java/shape-effective-properties/).
- Sommige uitvoerformaten kunnen de bewerkbare PowerPoint 3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑s of HTML‑pagina’s tot interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dat ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een camerarotatie en ofwel extrusie of diepte instellen. In de praktijk stelt u bovendien een verlichting en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/).`getThreeDFormat()` voor het vormlichaam en [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/java/shape-effective-properties/) om de uiteindelijke camera‑, verlichting‑, bevel‑ en gerelateerde 3D‑waarden te lezen.