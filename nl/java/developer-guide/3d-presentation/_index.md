---
title: Maak 3D-effecten in presentaties met Java
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentatie
- 3D-rotatie
- 3D-diepte
- 3D-extrusie
- 3D-verloop
- 3D-tekst
- PowerPoint
- presentatie
- Java
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst in Java met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for Java kan 3D-opmaak in PowerPoint-stijl voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D-effecten zoals rotatie, extrusie, afschuiningen, verlichting, materiaal, verloop- of afbeeldingvullingen en 3D-tekst.

{{% alert color="info" %}}
Dit artikel gaat over 3D-opmaak-effecten op PowerPoint-vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D-modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D-effecten in de geëxporteerde 2D-uitvoer.
{{% /alert %}}

## **Concepten voor 3D-opmaak**

Gebruik [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/).`getThreeDFormat()` om 3D-opmaak op een vorm toe te passen. Het geretourneerde opmaakobject bestuurt de 3D-scene voor die vorm.

Voor tekst gebruikt u [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Hiermee wordt 3D-opmaak op het tekstkader toegepast in plaats van op het vormlichaam.

De belangrijkste API-leden zijn:

| API-lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getCamera--) | Zichtpunt, preset camertype, rotatie, zoom en perspectief. | Rotatie van het object in 3D-ruimte of overeenkomen met een PowerPoint-rotatie-preset. |
| [getLightRig](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getLightRig--) | Light preset, richting en lichtrotatie. | Wijzigt hoe hooglichten en schaduwen verschijnen op het 3D-oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlaktemateriaal, zoals plat, mat, plastic of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metallisch uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm achterwaarts uitsteekt vanaf de voorzijde. | Maak van een platte vorm een duidelijk dik 3D-object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijkanten. | Maak diepte zichtbaar of stem de zijkleur af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Extra 3D-diepte die door PowerPoint 3D-opmaak wordt gebruikt. | Fijnregel de diepte voor vormen of tekst, vooral samen met afschuining en materiaalsinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe vlakke rand. |
| [getContourColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getContourWidth--), en [setContourWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omtrek rond het 3D-object. | Benadruk de objectgrens in de gerenderde uitvoer. |

## **Een 3D-vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camera-instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie- of dieptesinstellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D-opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG-afbeelding.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

De gerenderde dia-afbeelding toont de rechthoek als een dik 3D-blok:

![Gerenderde blauwe 3D-rechthoek met witte 3D-tekst op de voorzijde](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D-rotatie geconfigureerd via het venster 3-D-rotatie. De X-, Y- en Z-rotatiewaarden komen overeen met de rotatie die u instelt via de camera-API.

![PowerPoint-venster 3-D-rotatie met gemarkeerde X-, Y- en Z-rotatiewaarden](img_02_01.png)

In Aspose.Slides stelt u het camertype en de rotatie in via de 3D-opmaak die wordt geretourneerd door `shape.getThreeDFormat()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Gebruik de camera wanneer u de weergave van het object door de kijker wilt wijzigen. Het verandert niet de 2D-vormgeometrie op de dia. Het wijzigt het 3D-zichtpunt dat door PowerPoint en door Aspose.Slides wordt gebruikt bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dikker door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte-instelling deze zichtbare dikte, en de kleur-instelling bepaalt de kleur van de zijkanten.

![PowerPoint-diepte-instellingen gekoppeld aan extrusiekleur- en extrusiehoogte-eigenschappen](img_02_02.png)

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Gebruik de diepte-instelling wanneer u direct met de diepte-waarde van PowerPoint wilt werken of diepte wilt combineren met afschuining, materiaal en texteffecten. In veel vormscenario's is extrusiehoogte de duidelijkere instelling omdat deze de zichtbare extrusie direct weergeeft.

## **Verloop- of afbeeldingsvullingen gebruiken met 3D-effecten**

3D-opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op de voorzijde toepassen en toch dezelfde camera-, licht-, materiaal- en extrusie-instellingen gebruiken.

Dit voorbeeld past een verloopvulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Gerenderde 3D-rechthoek met een blauw-naar-oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

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
} finally {
    presentation.dispose();
}
```

![Gerenderde 3D-rechthoek met een foto-vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D-opmaak toepassen op tekst**

3D-opmaak van een vorm heeft invloed op het vormlichaam. 3D-opmaak van tekst heeft invloed op het tekstkader. Dit is nuttig voor WordArt-achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera-instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt-transformatie toe en configureert 3D-instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Gerenderde 3D-tekst met een gebogen WordArt-transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Export- en rendergedrag**

Aspose.Slides behoudt 3D-opmaak bij het opslaan naar PowerPoint-formaten zoals PPTX. Bij het renderen of exporteren naar vaste-indelingsformaten wordt de 3D-scene gerasterd of in de uitvoer getekend als een 2D-resultaat. Dit is van toepassing wanneer u dia's rendert naar [PNG](/slides/nl/java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/java/convert-powerpoint-to-html/), of frames genereert voor [video conversie](/slides/nl/java/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en dia-scaling.
- Als u geërfde of themagerichte opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/java/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint-3D-opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D-instellingen.

## **FAQ**

### Kan Aspose.Slides interactieve 3D-presentaties maken?

Aspose.Slides maakt en rendert PowerPoint-3D-effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑s of HTML‑pagina's tot interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D-opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

### Wat is het verschil tussen een 3D-model en een 3D-effect?

Een 3D-model is een los 3D-object dat in een presentatie wordt ingevoegd. Een 3D-effect is opmaak die wordt toegepast op een reguliere PowerPoint-vorm of -tekst, zoals rotatie, extrusie, afschuining, verlichting en materiaal. Dit artikel behandelt 3D-effecten.

### Welke instellingen zijn vereist voor een zichtbare 3D-vorm?

Op zijn minst stelt u een camera-rotatie en een extrusie- of diepte-waarde in. In de praktijk stelt u ook een lichtinstallatie en materiaal in zodat de gerenderde gezichten duidelijke hooglichten en schaduwen hebben.

### Kan ik 3D-effecten toepassen op zowel vormen als tekst?

Ja. Gebruik [IShape](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/).`getThreeDFormat()` voor het vormlichaam en [ITextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` voor tekst.

### Zullen 3D-effecten verschijnen bij export naar afbeeldingen, PDF, HTML of videoframes?

Ja. Aspose.Slides rendert 3D-effecten bij het genereren van dia-afbeeldingen, PDF-output, HTML-output en frames die worden gebruikt voor video-conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D-object.

### Kan ik de uiteindelijke 3D-waarden lezen nadat er erf- en themainstellingen zijn toegepast?

Ja. Gebruik de effectieve opmaak-API’s beschreven in [Shape Effective Properties](/slides/nl/java/shape-effective-properties/) om de uiteindelijke camera-, lichtinstallatie-, afschuining- en gerelateerde 3D-waarden te lezen.