---
title: Skapa 3D-effekter i presentationer på Android
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/androidjava/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrudering
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Tillämpa och rendera 3D-effekter för PowerPoint-former och -text på Android med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides för Android via Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Den här artikeln täcker 3D‑effekter såsom rotation, extrudering, fasetter, belysning, material, gradient‑ eller bildfyllning och 3D‑text.

{{% alert color="primary" %}}
Den här artikeln handlar om 3D‑formateringseffekter på PowerPoint‑former och -text. Det gäller inte insättning eller redigering av fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd metoden [IShape.getThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) för att tillämpa 3D‑formatering på en form. Metoden returnerar [IThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/), som styr 3D‑scenen för den formen.

För text, använd metoden [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Detta tillämpar 3D‑formatering på textramen i stället för formens kropp.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den styr | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getCamera--) | Vy, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rum eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getLightRig--) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getMaterial--) och [setMaterial](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#setMaterial-int-) | Ytmaterial, exempelvis slätt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, blankare eller metallisk ut. |
| [getExtrusionHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getExtrusionHeight--) och [setExtrusionHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hur långt formen sträcker sig bakåt från sin framsida. | Gör en platt form till ett tydligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Färgen på de extruderade sidorna. | Gör djupet synligt eller samordna sidans färg med frambildens fyllning. |
| [getDepth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getDepth--) och [setDepth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) | Ytterligare 3D‑djup som används av PowerPoints 3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med fasett‑ och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--) och [getBevelBottom](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getBevelBottom--) | Upphöjda eller avrundade kanter på fram- och baksidorna. | Lägg till en mjukad eller formad kant i stället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getContourWidth--), och [setContourWidth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur runt 3D‑objektet. | Framhäv objektets kant i renderad output. |

## **Skapa en 3D‑form**

- Kamerainställningar, eftersom standardframsidan kan dölja extruderingen.
- Ljusinställningar, eftersom belysning gör ytorna och sidorna läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess framsida, tillämpar 3D‑formatering, sparar presentationen som PPTX och renderar bilden till en PNG‑fil.

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

Den renderade bildsbilden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du anger via kamera‑API‑et.

![PowerPoint‑panelen 3‑D‑Rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides ställs kameratyp och rotation in via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getCamera--):

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Den ändrar inte den 2D‑geometri som formen har på bilden. Den ändrar 3D‑vy‑punkten som PowerPoint och Aspose.Slides använder vid rendering.

## **Lägg till extrudering och djup**

Extrudering får en form att se tjock ut genom att den sträcker sig bakom framsidan. I PowerPoint ställer djupkontrollen in denna synliga tjocklek och färgkontrollen anger sidornas färg.

![PowerPoints djupkontroller mappade till extruderings‑färg‑ och extruderings‑höjd‑egenskaper](img_02_02.png)

Ställ in [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) för tjockleken och [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#getExtrusionColor--) för sidans färg:

```java
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(Color.rgb(128, 0, 128));
```

Använd [IThreeDFormat.setDepth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) när du behöver arbeta direkt med PowerPoints djupvärde eller kombinera djup med fasett, material och texteffekter. I många form‑scenarier är `setExtrusionHeight` den tydligare inställningen eftersom den uttrycker den synliga extruderingen direkt.

## **Använd gradient‑ eller bildfyllning med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en enhetlig färg, gradient, mönster eller bildfyllning på framsidan och fortfarande använda samma kamera‑, ljus‑, material‑ och extruderingsinställningar.

Detta exempel använder en gradientfyllning på formen och en mörkare extruderingsfärg på sidorna:

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

Den renderade utdata behåller gradienten på framsidan och renderar extruderingen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att istället använda en bildfyllning, lägg till bilden i presentationen och tilldela den som formens fyllning:

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

Bilden renderas på framsidan, medan extruderingen renderas som 3D‑sidoyta:

![Renderad 3D‑rektangel med ett fotofyllning på framsidan och orange extrudering](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formens kropp. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, belysning och kamerainställningar.

Följande exempel skapar text med en mönsterfyllning, tillämpar en WordArt‑transform och konfigurerar 3D‑inställningar på [ITextFrameFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/):

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

Texten renderas som böjd, extruderad 3D‑bokstavsgrafik:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när den sparas till PowerPoint‑format som PPTX. Vid rendering eller export till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/androidjava/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/), eller genererar bildrutor för [videokonvertering](/slides/sv/androidjava/convert-powerpoint-to-video/).

Tänk på följande punkter:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskala.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/androidjava/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett fristående 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller -text, såsom rotation, extrudering, fasett, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum bör du ange en kamerarotation och antingen extrudering eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag tillämpa 3D‑effekter på både former och text?**

Ja. Använd [IShape.getThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) för formens kropp och [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframeformat/#getThreeDFormat--) för text.

**Kommer 3D‑effekter att visas när man exporterar till bilder, PDF, HTML eller videorutor?**

Ja. Aspose.Slides renderar 3D‑effekter när slide‑bilder, PDF‑utdata, HTML‑utdata och bildrutor för videokonvertering skapas. Den exporterade utdata innehåller det renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Shape Effective Properties](/slides/sv/androidjava/shape-effective-properties/) för att läsa den slutgiltiga kameran, ljusriggen, fasetten och relaterade 3D‑värden.