---
title: Creëer 3D-effecten in presentaties op Android
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
description: "Pas 3D-effecten toe en render ze voor PowerPoint‑vormen en -tekst op Android met Aspose.Slides. Configureer camera, verlichting, materiaal, extrusie, vullingen en 3D‑tekst."
---
## **Overzicht**

Aspose.Slides for Android via Java kan vormen en tekst maken, bewerken, behouden en renderen met PowerPoint-achtige 3D-opmaak. Dit artikel behandelt 3D-effecten zoals rotatie, extrusie, schuine randen, verlichting, materiaal, verloop- of afbeeldingsvullingen en 3D-tekst.

{{% alert color="info" %}}
Dit artikel gaat over 3D-opmaakeffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van op zichzelf staande 3D‑modelbestanden. Wanneer je een dia exporteert naar een afbeelding, PDF of HTML, renderen Aspose.Slides die 3D-effecten in de geëxporteerde 2D-uitvoer.
{{% /alert %}}

## **Concepten voor 3D‑opmaak**

Gebruik de [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) methode om 3D‑opmaak op een vorm toe te passen. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm regelt.

Voor tekst gebruik je de [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) methode. Deze past 3D‑opmaak toe op het tekstframe in plaats van op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Kijkpunt, vooraf ingestelde camertype, rotatie, zoom en perspectief. | Het object roteren in 3D‑ruimte of een PowerPoint‑3D‑rotatie‑preset overeen laten komen. |
| [getLightRig](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Vooraf ingestelde verlichting, richting en lichtrotatie. | Verander hoe highlights en schaduwen verschijnen op het 3D‑oppervlak. |
| [getMaterial](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) en [setMaterial](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlaktmateriaal, zoals vlak, mat, plastic of metaal. | Laat dezelfde geometrie er vlakker, zachter, glanzender of metallischer uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) en [setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm zich naar achteren uitstrekt vanaf de voorkant. | Een platte vorm omzetten in een duidelijk dik 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijkanten. | Diepte zichtbaar maken of de kleur van de zijkanten afstemmen op de vulkleur van de voorkant. |
| [getDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getDepth--) en [setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Aanvullende 3D‑diepte gebruikt door PowerPoint‑3D‑opmaak. | Diepte bijstellen voor vormen of tekst, vooral in combinatie met bevel‑ en materiaalin­stellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) en [getBevelBottom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor‑ en achtervlakken. | Een verzachte of gevormde rand toevoegen in plaats van een scherpe platte kant. |
| [getContourColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), en [setContourWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omtrek rond het 3D‑object. | De rand van het object benadrukken in de gerenderde output. |

## **Een 3D‑vorm maken**

Een vorm heeft doorgaans vier soorten instellingen nodig voordat hij overtuigend 3D uitziet:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Verlichtingsinstellingen, omdat verlichting de vlakken en zijkanten leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑opmaak toe, slaat de presentatie op als PPTX en rendert de dia naar een PNG‑afbeelding.

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

De gerenderde dia‑afbeelding toont de rechthoek als een dik 3D‑blok:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm roteren met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het paneel 3‑D‑Rotatie. De X‑, Y‑ en Z‑rotatiewaarden komen overeen met de rotatie die je via de camera‑API instelt.

![PowerPoint‑venster 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stel je het camertype en de rotatie in via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

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

Gebruik de camera wanneer je moet wijzigen hoe de kijker het object ziet. Het verandert niet de 2D‑vormgeometrie op de dia. Het wijzigt het 3D‑kijkpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie laat een vorm dikker lijken door deze achter de voorzijde uit te breiden. In PowerPoint bepaalt de diepte‑regelaar deze zichtbare dikte, en de kleur‑regelaar bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑regelaars gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) in voor de dikte en [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) voor de zijkleur:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(128, 0, 128));
} finally {
    presentation.dispose();
}
```

Gebruik [IThreeDFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) wanneer je direct met de diepte‑waarde van PowerPoint wilt werken of diepte wilt combineren met bevel, materiaal en teksteffecten. In veel vormscenario’s is `setExtrusionHeight` de duidelijkere instelling omdat deze direct de zichtbare extrusie uitdrukt.

## **Verloop‑ of afbeeldingvullingen gebruiken met 3D‑effecten**

3D‑opmaak staat los van de vormvulling. Je kunt een effen kleur, verloop, patroon of afbeelding op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, new Color(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));

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

De gerenderde output behoudt het verloop op de voorzijde en rendert de extrusie apart:

![Gerenderde 3D‑rechthoek met een blauw‑naar‑oranje verloopvulling en oranje extrusie](img_02_03.png)

Om in plaats daarvan een afbeeldingvulling te gebruiken, voeg je de afbeelding toe aan de presentatie en wijs je deze toe aan de vormvulling:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 150, 250, 250);

    IPPImage image;
    try (FileInputStream imageStream = new FileInputStream("image.png")) {
        image = presentation.getImages().addImage(imageStream);
    }

    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(new Color(255, 140, 0));
} finally {
    presentation.dispose();
}
```

De afbeelding wordt gerenderd op de voorzijde, terwijl de extrusie wordt weergegeven als het 3D‑zijvlak:

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑opmaak toepassen op tekst**

3D‑opmaak van een vorm heeft invloed op het vormlichaam. 3D‑opmaak van tekst heeft invloed op het tekstframe. Dit is nuttig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroonvulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(new Color(255, 140, 0));
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.LargeGrid);

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(TextShapeType.ArchUp);

    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
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

Aspose.Slides behoudt 3D‑opmaak bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output ingevoegd als een 2D‑resultaat. Dit geldt wanneer je dia’s rendert naar [PNG](/slides/nl/androidjava/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), of frames genereert voor [video conversion](/slides/nl/androidjava/convert-powerpoint-to-video/).

Houd rekening met de volgende punten:

- Exporteerde afbeeldingen en PDF‑bestanden zijn niet interactief. Het object kan na export niet door de kijker worden geroteerd.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, verlichtingsrig, materiaal, extrusie, vulling en dia‑schaling.
- Als je geërfde of thema‑gebaseerde opmaakwaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/androidjava/shape-effective-properties/).
- Sommige outputformaten kunnen bewerkbare PowerPoint‑3D‑opmaak niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **FAQ**

### Kan Aspose.Slides interactieve 3D‑presentaties maken?

Aspose.Slides maakt en renderen PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt geen geëxporteerde afbeeldingen, PDF‑bestanden of HTML‑pagina’s interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑opmaak bewerkbaar in PowerPoint waar het formaat dat ondersteunt.

### Wat is het verschil tussen een 3D‑model en een 3D‑effect?

Een 3D‑model is een apart 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is opmaak die wordt toegepast op een gewone PowerPoint‑vorm of tekst, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

### Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?

Minimaal moet je een camera‑rotatie instellen en ofwel extrusie of diepte. In de praktijk stel je ook een verlichtingsrig en materiaal in zodat de gerenderde vlakken duidelijke highlights en schaduwen hebben.

### Kan ik 3D‑effecten toepassen op zowel vormen als tekst?

Ja. Gebruik [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) voor het vormlichaam en [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) voor tekst.

### Zullen 3D‑effecten verschijnen bij export naar afbeeldingen, PDF, HTML of video‑frames?

Ja. Aspose.Slides rendert 3D‑effecten bij het produceren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

### Kan ik de definitieve 3D‑waarden lezen nadat erfelijkheid en thema‑instellingen zijn toegepast?

Ja. Gebruik de effectieve opmaak‑API’s beschreven in [Effectieve vormeigenschappen](/slides/nl/androidjava/shape-effective-properties/) om de uiteindelijke camera‑, verlichtingsrig‑, bevel‑ en gerelateerde 3D‑waarden te lezen.