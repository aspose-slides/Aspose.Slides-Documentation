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

Aspose.Slides voor Android via Java kan 3D‑formattering in PowerPoint‑stijl voor vormen en tekst maken, bewerken, behouden en renderen. Dit artikel behandelt 3D‑effecten zoals rotatie, extrusie, bevels, verlichting, materiaal, verloop‑ of afbeeldingsvullingen en 3D‑tekst.

{{% alert color="primary" %}}
Dit artikel gaat over 3D‑formatteringseffecten op PowerPoint‑vormen en -tekst. Het gaat niet over het invoegen of bewerken van op zichzelf staande 3D‑modelfiles. Wanneer u een dia exporteert naar een afbeelding, PDF of HTML, rendert Aspose.Slides die 3D‑effecten in de geëxporteerde 2D‑output.
{{% /alert %}}

## **3D-formatteringconcepten**

Gebruik de [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) methode om 3D‑formattering op een vorm toe te passen. De methode retourneert [IThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/), die de 3D‑scene voor die vorm beheert.

Voor tekst gebruikt u de [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) methode. Hiermee wordt 3D‑formattering toegepast op het tekstkader i.p.v. op het vormlichaam.

De belangrijkste API‑leden zijn:

| API‑lid | Wat het regelt | Wanneer te gebruiken |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Zichtpunt, voorgedefinieerd cameratype, rotatie, zoom en perspectief. | Roteer het object in 3D‑ruimte of pas een PowerPoint‑3D‑rotatie‑preset toe. |
| [getLightRig](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Lichtpreset, richting en lichtrotatie. | Wijzig hoe hooglichten en schaduwen op het 3D‑oppervlak verschijnen. |
| [getMaterial](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) and [setMaterial](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Oppervlakte‑materiaal, zoals plat, mat, plastic of metaal. | Laat dezelfde geometrie er platter, zachter, glanzender of metallischer uitzien. |
| [getExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) and [setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hoe ver de vorm vanaf de voorzijde naar achteren uitstrekt. | Maak van een platte vorm een duidelijk dikke 3D‑object. |
| [getExtrusionColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Kleur van de geëxtrudeerde zijvlakken. | Maak de diepte zichtbaar of stem de zijkleur af op de voorvulling. |
| [getDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getDepth--) and [setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Extra 3D‑diepte die PowerPoint‑3D‑formattering gebruikt. | Fijnstem de diepte voor vormen of tekst, vooral in combinatie met bevel‑ en materiaalingstellingen. |
| [getBevelTop](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) and [getBevelBottom](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Verhoogde of afgeronde randen op de voor- en achterkant. | Voeg een verzachte of gevormde rand toe in plaats van een scherpe platte zijde. |
| [getContourColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), and [setContourWidth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Omtrek rond het 3D‑object. | Benadruk de objectgrens in de gerenderde output. |

## **Een 3D‑vorm maken**

Een vorm heeft meestal vier soorten instellingen nodig voordat hij overtuigend 3D uitziet:

- Camera‑instellingen, omdat de standaard vooraanzicht de extrusie kan verbergen.
- Lichtinstellingen, omdat verlichting de gezichten en zijvlakken leesbaar maakt.
- Materiaalinstellingen, omdat het oppervlak beïnvloedt hoe licht wordt weergegeven.
- Extrusie‑ of diepte‑instellingen, omdat een platte vorm dikte nodig heeft.

Het volgende voorbeeld maakt een rechthoek, voegt tekst toe aan de voorzijde, past 3D‑formattering toe, slaat de presentatie op als PPTX op, en rendert de dia naar een PNG‑afbeelding.

```java
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

De gerenderde dia‑afbeelding toont de rechthoek als een dikke 3D‑blokken:

![Gerenderde blauwe 3D‑rechthoek met witte 3D‑tekst op de voorzijde](img_01_01.png)

## **Een vorm draaien met de camera**

In PowerPoint wordt 3D‑rotatie geconfigureerd via het venster 3‑D‑rotatie. De X-, Y- en Z‑rotatiewaarden komen overeen met de rotatie die u instelt via de camera‑API.

![PowerPoint‑venster 3‑D‑rotatie met gemarkeerde X‑, Y‑ en Z‑rotatiewaarden](img_02_01.png)

In Aspose.Slides stelt u het cameratype en de rotatie in via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Gebruik de camera wanneer u moet wijzigen hoe de kijker het object ziet. Het verandert de 2D‑vormgeometrie op de dia niet. Het verandert het 3D‑blikpunt dat PowerPoint en Aspose.Slides gebruiken bij het renderen.

## **Extrusie en diepte toevoegen**

Extrusie maakt een vorm dikker door deze achter de voorzijde uit te strekken. In PowerPoint bepaalt de diepte‑instelling deze zichtbare dikte, en de kleur‑instelling bepaalt de kleur van de zijvlakken.

![PowerPoint‑diepte‑instellingen gekoppeld aan extrusiekleur‑ en extrusiehoogte‑eigenschappen](img_02_02.png)

Stel [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) in voor de dikte en [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) voor de kleur van de zijkanten:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Gebruik [IThreeDFormat.setDepth](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) wanneer u direct met de diepte‑waarde van PowerPoint wilt werken of diepte wilt combineren met bevel‑, materiaal‑ en texteffecten. In veel situaties is `setExtrusionHeight` de duidelijkere instelling omdat deze de zichtbare extrusie rechtstreeks uitdrukt.

## **Verloop‑ of afbeelding‑vullingen gebruiken met 3D‑effecten**

3D‑formattering staat los van de vormvulling. U kunt een effen kleur, verloop, patroon of afbeelding‑vulling op de voorzijde toepassen en toch dezelfde camera‑, licht‑, materiaal‑ en extrusie‑instellingen gebruiken.

Dit voorbeeld past een verloop‑vulling toe op de vorm en een donkerdere extrusiekleur op de zijkanten:

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
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, Color.rgb(255, 165, 0));

    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));

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

Om in plaats daarvan een afbeelding‑vulling te gebruiken, voegt u de afbeelding toe aan de presentatie en kent u deze toe aan de vormvulling:

```java
IPPImage image;
try (FileInputStream imageStream = new FileInputStream("image.png")) {
    image = presentation.getImages().addImage(imageStream);
}

shape.getFillFormat().setFillType(FillType.Picture);
shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
shape.getThreeDFormat().setExtrusionHeight(150);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(255, 140, 0));
```

![Gerenderde 3D‑rechthoek met een foto‑vulling op de voorzijde en oranje extrusie](img_02_04.png)

## **3D‑formattering toepassen op tekst**

3D‑formattering van een vorm heeft invloed op het vormlichaam. 3D‑formattering van tekst heeft invloed op het tekstkader. Dit is handig voor WordArt‑achtige effecten waarbij de letters zelf extrusie, materiaal, verlichting en camera‑instellingen nodig hebben.

Het volgende voorbeeld maakt tekst met een patroon‑vulling, past een WordArt‑transformatie toe en configureert 3D‑instellingen op [ITextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/):

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
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.rgb(255, 140, 0));
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

![Gerenderde 3D‑tekst met een gebogen WordArt‑transformatie, oranje patroon‑vulling en donkere extrusie](img_02_05.png)

## **Export‑ en rendergedrag**

Aspose.Slides behoudt 3D‑formattering bij het opslaan naar PowerPoint‑formaten zoals PPTX. Bij het renderen of exporteren naar vaste‑layoutformaten wordt de 3D‑scene gerasterd of in de output getekend als een 2D‑resultaat. Dit geldt wanneer u dia’s rendert naar [PNG](/slides/nl/androidjava/convert-powerpoint-to-png/), exporteert naar [PDF](/slides/nl/androidjava/convert-powerpoint-to-pdf/), exporteert naar [HTML](/slides/nl/androidjava/convert-powerpoint-to-html/), of frames genereert voor [video‑conversie](/slides/nl/androidjava/convert-powerpoint-to-video/).

Houd de volgende punten in gedachten:

- Geëxporteerde afbeeldingen en PDF’s zijn niet interactief. Het object kan na export niet door de kijker worden gedraaid.
- Het uiteindelijke uiterlijk hangt af van de combinatie van camera, lichtinstallatie, materiaal, extrusie, vulling en dia‑schaling.
- Als u overgeërfde of themagebaseerde formatteringswaarden wilt inspecteren, lees dan de [effectieve vormeigenschappen](/slides/nl/androidjava/shape-effective-properties/).
- Sommige outputformaten kunnen bewerkbare PowerPoint‑3D‑formattering niet opslaan. In die formaten wordt het visuele resultaat gerenderd in plaats van bewaard als bewerkbare 3D‑instellingen.

## **Veelgestelde vragen**

**Kan Aspose.Slides interactieve 3D‑presentaties maken?**

Aspose.Slides maakt en rendert PowerPoint‑3D‑effecten voor vormen en tekst. Het maakt van geëxporteerde afbeeldingen, PDF’s of HTML‑pagina’s geen interactieve 3D‑scènes die een kijker kan draaien. In PPTX blijft de 3D‑formattering bewerkbaar in PowerPoint wanneer het formaat dit ondersteunt.

**Wat is het verschil tussen een 3D‑model en een 3D‑effect?**

Een 3D‑model is een afzonderlijk 3D‑object dat in een presentatie wordt ingevoegd. Een 3D‑effect is formattering die wordt toegepast op een gewone PowerPoint‑vorm of -tekst, zoals rotatie, extrusie, bevel, verlichting en materiaal. Dit artikel behandelt 3D‑effecten.

**Welke instellingen zijn vereist voor een zichtbare 3D‑vorm?**

Minimaal moet u een camera‑rotatie en ofwel extrusie of diepte instellen. In de praktijk stelt u ook een lichtinstallatie en materiaal in zodat de gerenderde vlakken duidelijke hooglichten en schaduwen hebben.

**Kan ik 3D‑effecten toepassen op zowel vormen als tekst?**

Ja. Gebruik [IShape.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) voor het vormlichaam en [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) voor tekst.

**Zullen 3D‑effecten verschijnen bij het exporteren naar afbeeldingen, PDF, HTML of videoframes?**

Ja. Aspose.Slides rendert 3D‑effecten bij het genereren van dia‑afbeeldingen, PDF‑output, HTML‑output en frames die worden gebruikt voor video‑conversie. De geëxporteerde output bevat het gerenderde uiterlijk, niet een bewerkbaar 3D‑object.

**Kan ik de uiteindelijke 3D‑waarden lezen nadat overerving en themainstellingen zijn toegepast?**

Ja. Gebruik de effectieve formatterings‑API’s beschreven in [Shape Effective Properties](/slides/nl/androidjava/shape-effective-properties/) om de uiteindelijke camera‑, lichtinstallatie‑, bevel‑ en gerelateerde 3D‑waarden te lezen.