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
description: "Tillämpa och rendera 3D-effekter för PowerPoint-former och text i Java med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D-text."
---
## **Översikt**

Aspose.Slides for Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrusion, avfasningar, belysning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="info" title="Obs" %}}

Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modelfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.

{{% /alert %}}

## **3D‑formateringskoncept**

Använd [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--)‑metoden för att tillämpa 3D‑formatering på en form. Metoden returnerar [IThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/), som styr 3D‑scenen för den formen.

För text, använd [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--)‑metoden. Detta tillämpar 3D‑formatering på textramen istället för på formens kropp.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den styr | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--) | Vy, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymden eller matcha en PowerPoint‑rotationsförinställning. |
| [getLightRig](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getLightRig--) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getMaterial--) och [setMaterial](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setMaterial-int-) | Ytmaterial, såsom platt, matt, plast eller metall. | Få samma geometri att se plattare, mjukare, glansigare eller metallisk ut. |
| [getExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionHeight--) och [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) | Hur långt formen sträcker sig bakåt från dess framsida. | Omvandla en platt form till ett tydligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) | Färg på extruderade sidor. | Gör djupet synligt eller anpassa sidfärgen till frambeläggningens färg. |
| [getDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getDepth--) och [setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) | Ytterligare 3D‑djup som används av PowerPoint‑3D‑formatering. | Finjustera djupet för former eller text, särskilt tillsammans med avfasnings‑ och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--) och [getBevelBottom](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelBottom--) | Upphöjda eller avrundade kanter på framsida och baksida. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourColor--) och [getContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getContourWidth--) och [setContourWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setContourWidth-double-) | Kontur runt 3D‑objektet. | Betona objektets gräns i den renderade utdata. |

## **Skapa en 3D‑form**

En form behöver vanligtvis fyra typer av inställningar innan den ser trovärdig 3D‑ut:

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.
- Ljuseinställningar, eftersom belysning gör ytor och sidor tydliga.
- Materialinställningar, eftersom ytan påverkar hur ljuset renderas.
- Extrusion‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess framsida och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extrusionens höjd är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standardmått och sparar presentationen som PPTX.

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

Den renderade bildfilen visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation i panelen 3‑D‑Rotation. X‑, Y‑ och Z‑rotationsvärdena motsvarar rotationen du anger via kamera‑API‑et.

![PowerPoint‑panelen 3‑D‑rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides får du åtkomst till kameran via [IThreeDFormat.getCamera](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getCamera--). Detta exempel skapar en rektangel, väljer en ortografisk frontvy och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

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

Använd kameran när du behöver ändra hur betraktaren ser objektet. Det ändrar inte 2D‑formgeometrin på bilden. Det ändrar den 3D‑vy som PowerPoint och Aspose.Slides använder vid rendering.

### **Kopiera kamerariktning från en mallform**

För att matcha riktningen på en mallform, läs dess kameraförinställning med [getCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getCameraType--) och dess rotationsvinklar med [getRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#getRotation--). Exemplet öppnar `template.pptx` och kopierar kamerariktningen från den första formen på den första bilden till den andra formen. Båda formerna har redan 3D‑belysning, och den andra formen har ingen explicit kamerarotation.

Vinklarna är i grader. Index `0` är latitud, index `1` är longitud och index `2` är revolution. Skicka dem till [setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) i den ordningen. Returnerar källan `null` har den ingen explicit rotation, så låt den andra formens vinklar vara odefinierade. En explicit rotation av `(0, 0, 0)` returnerar tre nollor och ska kopieras.

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

När du öppnar `camera-copy.pptx` i PowerPoint har pilen till höger samma kameraförinställning och rotation som rektangeln till vänster. Båda formerna använder samma belysning och extrusionsdjup.

![En blå 3D‑rektangel och en högerpil med matchande kamerariktning, sedd ovanifrån och åt höger](camera-orientation.png)

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att den sträcker sig bakom framsidan. I PowerPoint styr djupkontrollen detta synliga tjocklek och färgkontrollen färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extrusionsfärg och extrusionshöjd‑egenskaper](img_02_02.png)

Använd [IThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-) för att ange tjockleken och [IThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getExtrusionColor--) för att komma åt sidfärgen. Detta exempel ger en rektangel en extrusion på 100 punkter med lila sidor och roterar kameran för att visa tjockleken. Det konfigurerar formen i minnet utan att spara en fil:

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

[IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-)‑metoden sätter djupet för en 3D‑form. [setExtrusionHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setExtrusionHeight-double-)‑metoden styr extrusionens höjd, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllningar med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan applicera en enfärgad färg, gradient, mönster eller bildfyllning på framsidan och fortfarande använda samma kamera, ljus, material och extrusionsinställningar.

Detta exempel applicerar en blå‑till‑orange gradient på framsidan och en mörkorange färg på den 150‑punkts extrusionen. Gradientstopp vid 0 och 100 markerar början och slutet på gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standardmått:

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

Den renderade utdata behåller gradienten på framsidan och renderar extrusionen separat:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att använda en bildfyllning istället, lägg till bilden i presentationen och tilldela den till formens fyllning. Detta exempel förutsätter en befintlig fil med namn **image.jpg** i arbetskatalogen. Det sträcker bilden för att fylla rektangeln, applicerar en extrusion på 150 punkter och sätter kamerarotation i grader. Det konfigurerar formen i minnet utan att spara eller rendera en fil:

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

Bilden renderas på framsidan, medan extrusionen renderas som 3D‑sidoytan:

![Renderad 3D‑rektangel med ett fotofyll på framsidan och orange extrusion](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formens kropp. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där själva bokstäverna behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutnätmönster, applicerar en uppåtböjd båg och konfigurerar 3D‑inställningar via [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--). Extrusionshöjden och djupet är i punkter och ljusrotationen i grader. Formens fyllning och kontur är dolda så att endast texten är synlig. Exemplet renderar en PNG‑fil med dubbla bildmått och sparar presentationen som PPTX:

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

Texten renderas som böjd, extruderad 3D‑bokstavsgrafik:

![Renderad 3D‑text med en bågformad WordArt‑transform, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla text läsbar samtidigt som du bevarar formens 3D‑utseende, anropa [ITextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setKeepTextFlat-boolean-) via [ITextFrame.getTextFrameFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/#getTextFrameFormat--). När värdet är `true` förblir texten utanför 3D‑scenen. När det är `false` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrusion förblir konfigurerade via [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--). Det skiljer sig också från vanlig rotation. [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) roterar formen i bildplanet, medan [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) styr textens anpassade rotation inom sin omgivningsruta. Att hålla texten utanför 3D‑scenen återställer inte någon av dessa vinklar.

Följande självständiga exempel skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `false` till vänster och `true` till höger. Kameravinklarna är i grader och extrusionshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standardmått.

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

Till vänster följer texten 3D‑orienteringen. Till höger förblir den platt och lättare att läsa. Båda rektanglarna behåller samma synliga extrusion och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: text följer 3D‑orienteringen till vänster och förblir platt till höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när den sparas till PowerPoint‑format såsom PPTX. När du renderar eller exporterar till fasta layoutformat rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/java/convert-powerpoint-to-html/), eller genererar ramar för [video conversion](/slides/sv/java/convert-powerpoint-to-video/).

Tänk på följande:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.
- Om du behöver inspektera ärvda eller temabaserade formateringsvärden, läs de [effektiva formategenskaperna för formen](/slides/sv/java/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint‑3D‑formatering. I dessa format renderas den visuella resultatet i stället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint‑3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stöder det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, avfasning, belysning och material. Denna artikel behandlar 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Minst en kamerarotation och antingen extrusion eller djup. I praktiken bör du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag tillämpa 3D‑effekter på både former och text?**

Ja. Använd [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) för formens kropp och [ITextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#getThreeDFormat--) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videoram?**

Ja. Aspose.Slides renderar 3D‑effekter när bildfiler, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering produceras. Den exporterade utdata innehåller den renderade bilden, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter att arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API:erna som beskrivs i [Formens effektiva egenskaper](/slides/sv/java/shape-effective-properties/) för att läsa den slutgiltiga kameran, ljusriggen, avfasningen och relaterade 3D‑värden.