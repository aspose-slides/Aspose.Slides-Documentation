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

Aspose.Slides for Java kan vormen en tekst maken, bewerken, behouden en weergeven met PowerPoint-achtige 3D-opmaak. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="info" title="Note" %}}
Dit artikel gaat over 3D‑opmaakeffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van afzonderlijke 3D‑modelbestanden. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **Concepten van 3D‑opmaak**

Gebruik de [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getThreeDFormat--) methode om 3D‑opmaak toe te passen op een vorm. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) methode. Deze past 3D‑opmaak toe op het tekstframe in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getCamera--) | Gezichtsstandpunt, vooraf ingestelde cameratypen, rotatie, zoom en perspectief. | Roteer het object in 3D‑ruimte of pas een vooraf ingestelde PowerPoint‑rotatie toe. |
| [getLightRig](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtvoorinstelling, richting en lichtrotatie. | Wijzig hoe hoogtepunten en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlaktemateriaal, zoals vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metallischer uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm zich naar achteren uitstrekt vanaf de voorzijde. | Verander een vlakke vorm in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijkanten. | Maak diepte zichtbaar of stem de kleur van de zijkant af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Extra 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Fijn afstellen van diepte voor vormen of tekst, vooral in combinatie met schuine randen en materiaalinstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherp vlakke zijde. |
| [getContourColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getContourColor--) en [getContourWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getContourWidth--) en [setContourWidth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omtreklijn rond het 3D‑object. | Benadruk de objectgrens in de gerenderde uitvoer. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D oogt:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Verlichtingsinstellingen, omdat verlichting de gezichten en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak invloed heeft op hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een vlakke vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde en past 3D‑opmaak toe. De cameraro­tatie‑waarden staan in graden en de extrusiehoogte is 100 punten. Het voorbeeld rendert de dia naar een PNG‑afbeelding op het dubbele van de standaardafmetingen en slaat de presentatie op als PPTX.

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

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het venster 3‑D Rotatie. De X-, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die u via de camera‑API instelt.

In Aspose.Slides krijgt u toegang tot de camera via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getCamera--). Dit voorbeeld maakt een rechthoek, selecteert een orthografisch frontaanzicht en stelt de X-, Y‑ en Z‑rotaties in op respectievelijk 20, 30 en 40 graden. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

Gebruik de camera wanneer u de manier wilt wijzigen waarop de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑viewpoint dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dikker door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleuroptie bepaalt de kleur van de zijvlakken.

![PowerPoint-diepteregelingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Gebruik [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) om de dikte in te stellen en [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) om de kleur van de zijkant te benaderen. Dit voorbeeld geeft een rechthoek een extrusie van 100 punten met paarse zijkanten en roteert de camera om de dikte te onthullen. Het configureert de vorm in het geheugen zonder een bestand op te slaan:

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

De [IThreeDFormat.setDepth](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setDepth-double-) methode stelt de diepte van een 3D‑vorm in. De [setExtrusionHeight](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) methode bepaalt de hoogte van het extrusie‑effect, zoals getoond in dit voorbeeld.

## **Verloop‑ of afbeeldingvullingen gebruiken met 3D‑effecten**

3D‑opmaak is onafhankelijk van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeeldingvulling toepassen op de voorzijde en toch dezelfde camera, verlichting, materiaal en extrusie‑instellingen gebruiken.

Dit voorbeeld past een blauw‑naar‑oranje verloop toe op de voorzijde en een donkeroranje kleur op de extrusie van 150 punten. De verloopstops bij 0 en 100 markeren het begin en einde van het verloop. De cameraro­tatie‑waarden staan in graden. De dia wordt gerenderd naar een PNG‑afbeelding op het dubbele van de standaardafmetingen:

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

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voegt u de afbeelding toe aan de presentatie en kent u deze toe aan de vormvulling. Dit voorbeeld vereist een bestaand bestand met de naam "image.jpg" in de werkmap. Het strekt de afbeelding uit tot de rechthoek, past een extrusie van 150 punten toe en stelt de cameraro­tatie in graden in. Het configureert de vorm in het geheugen zonder op te slaan of te renderen:

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

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm beïnvloedt het vormlichaam. 3D‑opmaak van tekst beïnvloedt het tekstframe. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een oranje‑en‑witte rasterpatroon, past een opwaartse boog toe en configureert 3D‑instellingen via [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). De extrusiehoogte en diepte zijn in punten, en de lichtrotatie is in graden. De vormvulling en omtreklijn worden verborgen zodat alleen de tekst zichtbaar is. Het voorbeeld rendert een PNG‑afbeelding op het dubbele van de standaarddiadimensies en slaat de presentatie op als PPTX:

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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroonvulling en donkere extrusie](img_02_05.png)

## **Tekst plat houden op een 3D‑vorm**

Om tekst leesbaar te houden terwijl de 3D‑uitstraling van een vorm behouden blijft, roept u [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) aan via [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframe/#getTextFrameFormat--). Wanneer de waarde `true` is, blijft de tekst buiten de 3D‑scene. Wanneer `false`, neemt de tekst deel aan de scene en volgt hij de 3D‑oriëntatie.

Deze instelling verwijdert niet de 3D‑opmaak van de vorm: de camera, verlichting, materiaal en extrusie blijven geconfigureerd via [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getThreeDFormat--). Het verschilt ook van gewone rotatie. [IShape.setRotation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#setRotation-float-) roteert de vorm in het diavlak, terwijl [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) de aangepaste rotatie van de tekst binnen de omhullende bepaalt. Het buiten de 3D‑scene houden van tekst reset geen van deze hoeken.

Het volgende zelfstandige voorbeeld maakt een blauwe rechthoek met tekst en kloont deze naast het origineel. Beide vormen hebben dezelfde 3D‑opmaak; alleen de tekstinstelling verschilt: `false` links en `true` rechts. De camerahoeken staan in graden en de extrusiehoogte is 40 punten. Het voorbeeld slaat de presentatie op als PPTX en rendert de vergelijkingsdia naar PNG op het dubbele van de standaardafmetingen.

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

![Zij‑aan‑zij 3D‑rechthoeken: tekst volgt de 3D‑oriëntatie links en blijft vlak rechts](keep_text_flat.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑opmaak bij het opslaan in PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer u dia's rendert naar [PNG](/slides/nl/java/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/java/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/java/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/java/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtrig, materiaal, extrusie, vulling en diavergroting.
- Als u geërfde of themagerichte opmaakwaarden wilt inspecteren, lees dan de [effective shape properties](/slides/nl/java/shape-effective-properties/).
- Sommige outputformaten kunnen de bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina's niet tot interactieve 3D‑scènes die een kijker kan roteren. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een reguliere PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, schuine rand, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minstens moet een cameraro­tatie en ofwel extrusie of diepte worden ingesteld. In de praktijk stelt men ook een lichtrig en materiaal in zodat de gerenderde gezichten duidelijke hoogtepunten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ishape/#getThreeDFormat--) voor het vormlichaam en [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of video‑frames?**

Ja. Aspose.Slides rendert 3D‑effecten wanneer dia‑afbeeldingen, PDF‑output, HTML‑output en frames voor video‑conversie worden geproduceerd. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Shape Effective Properties](/slides/nl/java/shape-effective-properties/) om de definitieve camera‑, lichtrig‑, schuine‑rand‑ en gerelateerde 3D‑waarden te lezen.