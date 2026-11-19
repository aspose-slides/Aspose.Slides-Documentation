---
title: 3D-effecten maken in presentaties met Java
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

Aspose.Slides for Java kan vormen en tekst maken, bewerken, behouden en weergeven in PowerPoint-achtige 3D-opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop‑ of afbeeldingvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaak‑effecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van zelfstandige 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D‑opmaakconcepten**

Gebruik de [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--)‑methode om 3D‑opmaak toe te passen op een vorm. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm bestuurt.

Voor tekst gebruikt u de [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--)‑methode. Hiermee wordt 3D‑opmaak toegepast op het tekstkader i.p.v. op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Kijkpunt, vooraf ingestelde cameratype, rotatie, zoom en perspectief. | Draai het object in 3D‑ruimte of pas een PowerPoint‑3D‑rotatie‑preset toe. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Licht‑preset, richting en lichtrotatie. | Verander hoe highlights en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlakte‑materiaal, zoals vlak, mat, kunststof of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metaalachtig uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm zich terugstrekt van het voorvlak. | Zet een vlakke vorm om in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijkanten. | Maak diepte zichtbaar of stem de kleur van de zijkant af op de vulling van de voorkant. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Extra 3D‑diepte die door PowerPoint‑3D‑opmaak wordt gebruikt. | Fijn‑afstellen van diepte voor vormen of tekst, vooral in combinatie met schuine en materiaal‑instellingen. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op het voor‑ en achtervlak. | Voeg een verzachte of gevormde rand toe i.p.v. een scherpe vlakke rand. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) en [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) en [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omtrek rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Maak een 3D‑vorm**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camerainstellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak bepaalt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan het voorvlak en past 3D‑opmaak toe. De camera‑rotatiewaarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding met dubbele standaardafmetingen en slaat de presentatie op als PPTX.

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
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

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

De gerenderde dia‑afbeelding toont het rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op het voorvlak](img_01_01.png)

## **Draai een vorm met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D Rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

![PowerPoint‑paneel 3‑D Rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides gebruikt u de camera via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch vooraanzicht en stelt de X‑, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u moet wijzigen hoe de kijker het object ziet. Het verandert de 2D‑vormgeometrie op de dia niet. Het verandert het 3D‑kijkpunt dat PowerPoint en Aspose.Slides bij het renderen gebruiken.

### **Kopieer camerarichting van een sjabloon‑vorm**

Om de oriëntatie van een sjabloon‑vorm overeen te laten komen, lees u het camera‑preset met [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) en de rotatiehoeken met [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Het voorbeeld opent `template.pptx` en kopieert de camerarichting van de eerste vorm op de eerste dia naar de tweede vorm. Beide vormen hebben al 3D‑verlichting en de tweede vorm heeft geen expliciete camera‑rotatie.

De hoeken staan in graden. Index `0` is breedtegraad, index `1` is lengtegraad, en index `2` is omwenteling. Geef ze in die volgorde door aan [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-).... Als de bron `null` retourneert, heeft deze geen expliciete rotatie, laat dan de hoeken van de tweede vorm ongewijzigd. Een expliciete rotatie van `(0, 0, 0)` geeft drie nullen en moet gekopieerd worden.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("template.pptx");
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    ICamera sourceCamera = shapes.get_Item(0).getThreeDFormat().getCamera();
    ICamera destinationCamera = shapes.get_Item(1).getThreeDFormat().getCamera();

    destinationCamera.setCameraType(sourceCamera.getCameraType());
    float[] angles = sourceCamera.getRotation();
    if (angles != null) {
        destinationCamera.setRotation(angles[0], angles[1], angles[2]);
    }

    presentation.save("camera-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wanneer u `camera-copy.pptx` opnieuw opent in PowerPoint, heeft de pijl rechts hetzelfde camera‑preset en dezelfde rotatie als de rechthoek links. Beide vormen gebruiken dezelfde verlichting en extrusiediepte.

![Een blauwe 3D‑rechthoek en een rechtswijzende pijl met overeenkomende camerarichting, bekeken van boven en rechts](camera-orientation.png)

## **Voeg extrusie en diepte toe**

Extrusie maakt een vorm dikker door deze achter het voorvlak uit te breiden. In PowerPoint stelt de diepte‑regeling deze zichtbare dikte in en de kleur‑regeling bepaalt de kleur van de zijkanten.

![PowerPoint-diepteregelingen gekoppeld aan eigenschappen van extrusiekleur en -hoogte](img_02_02.png)

Gebruik [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) om de dikte in te stellen en [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) om de kleur van de zijkanten op te vragen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en draait de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    Color extrusionColor = new Color(128, 0, 128);

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

De methode [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) stelt de diepte van een 3D‑vorm in. De methode [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) bepaalt de hoogte van het extrusie‑effect, zoals in dit voorbeeld.

## **Gebruik verloop‑ of afbeeldingvullingen met 3D‑effecten**

3D‑opmaak is onafhankelijk van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling op het voorvlak toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op het voorvlak en een donkeroranje kleur op de extrusie van 150 punten. De verloopstops op 0 en 100 markeren het begin en einde van het verloop. De camera‑rotatiewaarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding met dubbele standaardafmetingen:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

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

De gerenderde output behoudt het verloop op het voorvlak en rendert de extrusie afzonderlijk:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en koppelt u deze aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het strekt de afbeelding uit om de rechthoek te vullen, past een extrusie van 150 punten toe en stelt de camera‑rotatie in graden in. Het configureert de vorm in het geheugen zonder een bestand op te slaan of te renderen:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    Path imagePath = Paths.get("image.jpg");
    byte[] imageData = Files.readAllBytes(imagePath);
    IPPImage image = presentation.getImages().addImage(imageData);

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    Color extrusionColor = new Color(255, 140, 0);
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

De afbeelding wordt gerenderd op het voorvlak, terwijl de extrusie wordt gerenderd als het 3D‑zijoppervlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op het voorvlak en oranje extrusie](img_02_04.png)

## **Pas 3D‑opmaak toe op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een bovenwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). De extrusiehoogte en diepte staan in punten en de lichtrotatie in graden. De vormvulling en -omtrek zijn verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding met dubbele standaarddia‑afmetingen en slaat de presentatie op als PPTX:

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

De tekst wordt gerenderd als gebogen, geëxtrudeerde 3D‑letters:

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Houd tekst vlak op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑vorm behouden blijft, roep u [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) aan via [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer deze `false` is, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert de 3D‑opmaak van de vorm niet: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Het verschilt ook van gewone rotatie. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) roteert de vorm in het dia‑vlak, terwijl [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) de aangepaste rotatie van de tekst binnen zijn begrenzingsvak regelt. Tekst buiten de 3D‑scene houden zet geen van die hoeken terug.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `false` links en `true` rechts. De camera‑hoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG met dubbele standaardafmetingen.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(TextAlignment.Center);
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Center);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(100, 149, 237));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(65, 105, 225));
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

Aan de linkerkant volgt de tekst de 3D‑oriëntatie. Aan de rechterkant blijft hij vlak en beter leesbaar. Beide rechthoeken behouden dezelfde zichtbare extrusie en 3D‑oriëntatie.

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft vlak rechts](keep_text_flat.png)

## **Export‑ en render‑gedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑lay‑out‑formaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/java/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/java/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Export‑afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en dia‑schaling.
- Als u geërfde of themagebaseerde opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/java/shape-effective-properties/).
- Sommige outputformaten kunnen geen bewerkbare PowerPoint‑3D‑opmaak opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑s of HTML‑pagina’s tot interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint zolang het formaat dat ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een losstaand 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, schuine rand, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

U moet minimaal een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stelt u ook een lichtinstallatie en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) voor het vormlichaam en [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) voor tekst.

**Zullen 3D‑effecten verschijnen bij exporteren naar afbeeldingen, PDF, HTML of video‑frames?**

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor videoconversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de definitieve 3D‑waarden uitlezen nadat erfelijkheid en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/java/shape-effective-properties/) om de uiteindelijke camera, lichtinstallatie, schuine rand en gerelateerde 3D‑waarden uit te lezen.