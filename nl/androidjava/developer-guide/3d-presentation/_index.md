---
title: 3D-effecten maken in presentaties op Android
linktitle: 3D-presentatie
type: docs
weight: 232
url: /nl/androidjava/3d-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Pas 3D-effecten toe en render ze voor PowerPoint-vormen en -tekst op Android met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D-tekst."
---
## **Overzicht**

Aspose.Slides for Android via Java kan vormen en tekst maken, bewerken, behouden en weergeven met PowerPoint‑achtige 3D‑opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, inkepingen, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="info" title="Opmerking" %}}
Dit artikel gaat over 3D‑opmaak­effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van losse 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten van 3D‑opmaak**

Gebruik de [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) methode om 3D‑opmaak toe te passen op een vorm. De methode geeft een [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/) terug, die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) methode. Deze past 3D‑opmaak toe op het tekstkader in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Roteer het object in de 3D‑ruimte of stem overeen met een PowerPoint‑3D‑rotatie‑preset. |
| [getLightRig](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtpreset, richting en lichtrotatie. | Wijzig hoe hooglichten en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlaktmateriaal, zoals plat, mat, kunststof of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metaalachtig uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm zich achterwaarts uitstrekt vanaf de voorzijde. | Maak van een platte vorm een zichtbaar dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijkanten. | Maak diepte zichtbaar of stem de kleur van de zijkanten af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Fijn afstemmen van diepte voor vormen of tekst, vooral in combinatie met inkeping‑ en materiaalin­stellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte kant. |
| [getContourColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getContourColor--) en [getContourWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--) en [setContourWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omranding rondom het 3D‑object. | Benadruk de objectgrens in de gerenderde uitvoer. |

## **Maak een 3D‑vorm**

Een vorm heeft doorgaans vier soorten instellingen nodig voordat hij overtuigend 3D uitziet:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaalin­stellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De camerarotatiewaarden zijn in graden en de extrusie‑hoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

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

De gerenderde dia-afbeelding toont de rechthoek als een dikke 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Roteer een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑rotatie. De X-, Y- en Z‑rotatiewaarden komen overeen met de rotatie die u instelt via de camera‑API.

![PowerPoint‑paneel 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides krijgt u toegang tot de camera via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getCamera--). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch frontaanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u de weergave van het object voor de kijker wilt wijzigen. Het verandert de 2D‑vormgeometrie op de dia niet. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Voeg extrusie en diepte toe**

Extrusie maakt een vorm dikker doordat deze zich achter de voorzijde uitstrekt. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijkanten.

![PowerPoint‑diepte‑instellingen in kaart gebracht op extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Gebruik [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) om de dikte in te stellen en [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) om de zijkleur te benaderen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijden en roteert de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    int extrusionColor = Color.rgb(128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

De [IThreeDFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) methode stelt de diepte van een 3D‑vorm in. De [setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) methode bestuurt de hoogte van het extrusie‑effect, zoals weergegeven in dit voorbeeld.

## **Gebruik verloop‑ of afbeelding‑vullingen met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeelding‑vulling op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de extrusie van 150 punten. De verloopstops op 0 en 100 markeren het begin en einde van het verloop. De camerarotatiewaarden zijn in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final float imageScale = 2;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, Color.BLUE);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    int extrusionColor = Color.rgb(255, 140, 0);
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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeelding‑vulling te gebruiken, voegt u de afbeelding toe aan de presentatie en wijst u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand genaamd "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camerarotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.jpg")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    int extrusionColor = Color.rgb(255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het lichaam van de vorm. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑wit rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--). De extrusie‑hoogte en diepte zijn in punten en de lichtrotatie is in graden. De vormvulling en omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddia‑afmetingen en slaat de presentatie op als PPTX:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int patternColor = Color.rgb(255, 140, 0);
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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Houd tekst plat op een 3D‑vorm**

Om de tekst leesbaar te houden terwijl de 3D‑uitstraling van een vorm behouden blijft, roept u [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) aan via [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframe/#getTextFrameFormat--). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--). Het is bovendien anders dan gewone rotatie. [IShape.setRotation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#setRotation-float-) roteert de vorm in het dia‑vlak, terwijl [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) de aangepaste rotatie van de tekst binnen zijn omhullende regelt. Tekst buiten de 3D‑scene houden reset geen van beide hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `false` links en `true` rechts. De camerahoeeken zijn in graden en de extrusie‑hoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(65, 105, 225));
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    IAutoShape flatTextShape = (IAutoShape) slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", SaveFormat.Pptx);
    IImage image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft plat rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de uitvoer getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/androidjava/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/androidjava/convert-powerpoint-to-video/).

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en dia‑schaling.
- Als u geërfde of themagerelateerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vorm‑eigenschappen](/slides/nl/androidjava/shape-effective-properties/).
- Sommige uitvoerformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s tot interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is een opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, inkeping, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbaar 3D‑object?**

Minimaal moet een camera‑rotatie en ofwel extrusie of diepte worden ingesteld. In de praktijk stelt u ook een lichtinstallatie en materiaal in zodat de gerenderde gezichten duidelijk highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) voor het vormlichaam en [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) voor tekst.

**Zullen 3D‑effecten verschijnen bij exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het genereren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen na toepassing van overerving en themainstellingen?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/androidjava/shape-effective-properties/) om de uiteindelijke camera‑, lichtinstallatie‑, inkepings‑ en gerelateerde 3D‑waarden te lezen.