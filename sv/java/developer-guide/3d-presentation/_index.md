---
title: Skapa 3D‑effekter i presentationer med Java
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/java/3d-presentation/
keywords:
- 3D‑PowerPoint
- 3D‑presentation
- 3D‑rotation
- 3D‑djup
- 3D‑extrudering
- 3D‑gradient
- 3D‑text
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Tillämpar och renderar 3D‑effekter för PowerPoint‑former och -text i Java med Aspose.Slides. Konfigurera kamera, belysning, material, extrudering, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrudering, avfasningar, belysning, material, gradient‑ eller bildfyllning samt 3D‑text.

{{% alert color="info" title="Obs" %}}

Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild till bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utmatningen.

{{% /alert %}}

## **3D‑formateringskoncept**

Använd metoden [IShape.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getThreeDFormat--) för att tillämpa 3D‑formatering på en form. Metoden returnerar [IThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/), som styr 3D‑scenen för den formen.

För text, använd metoden [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) . Detta tillämpar 3D‑formatering på textramen istället för formkroppen.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den styr | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getCamera--) | Synpunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑utrymme eller matcha en PowerPoint‑3D‑roteringsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getLightRig--) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getMaterial--) och [setMaterial](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Ytmaterial, t.ex. platt, matt, plast eller metall. | Gör samma geometri plattare, mjukare, glansigare eller metallisk. |
| [getExtrusionHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) och [setExtrusionHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hur långt formen sträcker sig bakåt från dess främre yta. | Gör en platt form till ett tydligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidans färg med främre fyllning. |
| [getDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getDepth--) och [setDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djup för former eller text, särskilt tillsammans med avfasning och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getBevelTop--) och [getBevelBottom](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Upphöjda eller avrundade kanter på främre och bakre ytor. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getContourColor--) och [getContourWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getContourWidth--) och [setContourWidth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur runt 3D‑objektet. | Betona objektets gräns i renderad utmatning. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser trovärdigt 3D ut:

- Kamerainställningar, eftersom standard‑framsidan kan dölja extruderingen.
- Ljuseinställningar, eftersom belysning gör ytorna och sidorna läsbara.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess främre yta och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extruderingshöjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX.

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

Den renderade bildens bild visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D-rektangel med vit 3D-text på framytan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation i panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar rotationen du anger via kamera‑API‑et.

![PowerPoint‑panelen 3‑D‑Rotation med X, Y och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides får du åtkomst till kameran via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getCamera--). Detta exempel skapar en rektangel, väljer en ortografisk framsidesvy och sätter X‑, Y‑ och Z‑rotationerna till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

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

Använd kameran när du behöver ändra hur betraktaren ser objektet. Det ändrar inte 2D‑formens geometri på bilden. Det ändrar den 3D‑vy som PowerPoint och Aspose.Slides använder vid rendering.

## **Lägg till extrudering och djup**

Extrudering gör att en form ser tjock ut genom att den sträcks bakom den främre ytan. I PowerPoint styr djupkontrollen den synliga tjockleken och färgkontrollen bestämmer färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extruderingsfärg och extruderingshöjdsegenskaper](img_02_02.png)

Använd [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) för att ange tjockleken och [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) för att komma åt sidofärgen. Detta exempel ger en rektangel en 100‑punkts extrudering med lila sidor och roterar kameran för att visa dess tjocklek. Det konfigurerar formen i minnet utan att spara en fil:

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

Metoden [IThreeDFormat.setDepth](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setDepth-double-) sätter djupet för en 3D‑form. Metoden [setExtrusionHeight](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) styr höjden på extruderings‑effekten, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllning med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en solid färg, gradient, mönster eller bildfyllning på den främre ytan och fortfarande använda samma kamera, ljus, material och extrudering.

Detta exempel applicerar en blå‑till‑orange gradient på den främre ytan och en mörkorange färg på den 150‑punkts extruderingen. Gradientstopparna vid 0 och 100 markerar början och slutet av gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standardmått:

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

Den renderade utmatningen behåller gradienten på den främre ytan och renderar extruderingen separat:

![Renderad 3D‑rektangel med blå‑till‑orange gradientfyllning och orange extrudering](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel kräver en befintlig fil med namn **image.jpg** i arbetskatalogen. Det sträcker bilden så att den fyller rektangeln, applicerar en 150‑punkts extrudering och sätter kamerarotationen i grader. Det konfigurerar formen i minnet utan att spara eller rendera en fil:

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

Bilden renderas på den främre ytan, medan extruderingen renderas som 3D‑sidoytan:

![Renderad 3D‑rektangel med foto‑fyllning på framytan och orange extrudering](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

3D‑formatering av form påverkar formkroppen. 3D‑formatering av text påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrudering, material, belysning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutnätsmönster, applicerar en uppåtriktad båge och konfigurerar 3D‑inställningar via [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Extruderingshöjden och djupet är i punkter och ljusrotationen i grader. Formens fyllning och kontur är dolda så att bara texten syns. Exemplet renderar en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX:

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

Texten renderas som böjd, extruderad 3D‑bokstav:

![Renderad 3D‑text med en bågig WordArt‑transform, orange mönsterfyllning och mörk extrudering](img_02_05.png)

## **Behåll texten platt på en 3D‑form**

För att hålla texten läsbar samtidigt som formens 3D‑utseende bevaras, anropa [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) via [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframe/#getTextFrameFormat--). När värdet är `true` förblir texten utanför 3D‑scenen. När det är `false` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrudering förblir konfigurerade via [IShape.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getThreeDFormat--). Det skiljer sig också från vanlig rotation. [IShape.setRotation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#setRotation-float-) roterar formen i bildplanet, medan [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) styr textens egna rotation inom dess begränsningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa rotationer.

Följande självständiga exempel skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `false` till vänster och `true` till höger. Kameravinklarna är i grader och extruderingshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standardmått.

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

Till vänster följer texten 3D‑orienteringen. Till höger förblir den platt och lättare att läsa. Båda rektanglarna behåller samma synliga extrudering och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: text följer 3D‑orienteringen till vänster och förblir platt till höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar till PowerPoint‑format som PPTX. Vid rendering eller export till fasta layout‑format rasteriseras 3D‑scenen eller ritas in i resultatet som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/java/convert-powerpoint-to-html/), eller genererar ramar för [videokonvertering](/slides/sv/java/convert-powerpoint-to-video/).

Kom ihåg följande:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrudering, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs [effektiva formsegenskaper](/slides/sv/java/shape-effective-properties/).
- Vissa exportformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas det visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stöder det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrudering, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum måste du ange en kamerarotation och antingen extrudering eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag applicera 3D‑effekter på både former och text?**

Ja. Använd [IShape.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ishape/#getThreeDFormat--) för formkroppen och [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoramar?**

Ja. Aspose.Slides renderar 3D‑effekter när du producerar bildfiler, PDF‑utmatning, HTML‑utmatning och ramar som används för videokonvertering. Den exporterade utmatningen innehåller den renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutliga 3D‑värdena efter arv och temainställningar har tillämpats?**

Ja. Använd effektiva formaterings‑API:er som beskrivs i [Shape Effective Properties](/slides/sv/java/shape-effective-properties/) för att läsa slutgiltig kamera, ljusrigg, avfasning och relaterade 3D‑värden.