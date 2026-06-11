---
title: Skapa 3D-effekter i presentationer med Java
linktitle: 3D-presentation
type: docs
weight: 232
url: /sv/java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D-presentation
- 3D-rotation
- 3D-djup
- 3D-extrusion
- 3D-gradient
- 3D-text
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Applicera och rendera 3D-effekter för PowerPoint-former och -text i Java med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides för Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrusion, avfasningar, belysning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="primary" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/).`getThreeDFormat()` för att tillämpa 3D‑formatering på en form. Det returnerade formatobjektet styr 3D‑scenen för den formen.

För text, använd [ITextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()`. Detta tillämpar 3D‑formatering på textramen istället för formkroppen.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den styr | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getCamera--) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymd eller matcha en PowerPoint‑3D‑rotationsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getLightRig--) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getMaterial--) och [setMaterial](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Ytmaterial, såsom slätt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [getExtrusionHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) och [setExtrusionHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hur långt formen sträcker sig bakåt från sin främre yta. | Omvandla en platt form till ett synligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidfärgen med frontfyllningen. |
| [getDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getDepth--) och [setDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt i kombination med avfasning‑ och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getBevelTop--) och [getBevelBottom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Upphöjda eller rundade kanter på fram- och baksidorna. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getContourColor--), [getContourWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getContourWidth--), och [setContourWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur runt 3D‑objektet. | Betona objektets gräns i renderad utdata. |

## **Skapa en 3D‑form**

En form kräver vanligtvis fyra typer av inställningar innan den ser övertygande 3D ut:

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.
- Ljuseinställningar, eftersom belysning gör ytorna och sidorna tydliga.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta, tillämpar 3D‑formatering, sparar presentationen som PPTX och renderar bilden till en PNG‑fil.

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

Den renderade bildspelsbilden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på främre yta](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från rutan 3‑D‑rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar den rotation du ställer in via kamera‑API‑et.

![PowerPoint‑rutan 3‑D‑rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides ställs kameratyp och rotation in via 3D‑formatet som returneras av `shape.getThreeDFormat()`:

```java
shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
```

Använd kameran när du behöver förändra hur betraktaren ser objektet. Den ändrar inte 2D‑geometrin för formen på bilden. Den ändrar 3D‑vy‑punkten som används av PowerPoint och av Aspose.Slides vid rendering.

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att den sträcker sig bakom den främre ytan. I PowerPoint styr djupkontrollen den synliga tjockleken och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extrusion‑färg och extrusion‑höjd‑egenskaper](img_02_02.png)

Ställ in extrusion‑höjden för tjockleken och extrusion‑färgen för sidfärgen:

```java
Color extrusionColor = new Color(128, 0, 128);

shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
shape.getThreeDFormat().setExtrusionHeight(100);
shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
```

Använd djupinställningen när du behöver arbeta med PowerPoints djupvärde direkt eller kombinera djup med avfasning, material och texteffekter. I många form‑scenarier är extrusion‑höjden den tydligare inställningen eftersom den uttrycker den synliga extrusionen direkt.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på den främre ytan och ändå använda samma kamera-, ljus-, material- och extruderingsinställningar.

Detta exempel applicerar en gradientfyllning på formen och en mörkare extruderingsfärg på sidorna:

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

Den renderade utsagan behåller gradienten på den främre ytan och renderar extrusionen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning:

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

Bilden renderas på den främre ytan, medan extrusionen renderas som 3D‑sidoyta:

![Renderad 3D‑rektangel med en fotofyllning på den främre ytan och orange extrusion](img_02_04.png)

## **Applicera 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med en mönsterfyllning, applicerar en WordArt‑transform och konfigurerar 3D‑inställningar på [ITextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/):

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

Texten renderas som böjd, extruderad 3D‑bokstavstext:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid rendering eller export till layout‑fast format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/java/convert-powerpoint-to-html/), eller genererar ramar för [videokonvertering](/slides/sv/java/convert-powerpoint-to-video/).

Kom ihåg följande punkter:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.
- Om du behöver undersöka ärvda eller temabaserade formateringsvärden, läs [effektiva formegenskaper](/slides/sv/java/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum ställ in en kamerarotation och antingen extrusion eller djup. I praktiken bör du också ställa in en ljusrigg och material så att de renderade ytorna har tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [IShape](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/).`getThreeDFormat()` för formkroppen och [ITextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/).`getThreeDFormat()` för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoramar?**

Ja. Aspose.Slides renderar 3D‑effekter när man producerar bildspel‑bilder, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering. Den exporterade utdata innehåller det renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [effektiva formegenskaper](/slides/sv/java/shape-effective-properties/) för att läsa slutgiltig kamera, ljusrigg, avfasning och relaterade 3D‑värden.