---
title: Skapa 3D‑effekter i presentationer med Node.js
linktitle: 3D‑presentation
type: docs
weight: 232
url: /sv/nodejs-java/3d-presentation/
keywords:
- 3D PowerPoint
- 3D‑presentation
- 3D‑rotation
- 3D‑djup
- 3D‑extrusion
- 3D‑gradient
- 3D‑text
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Tillämpa och rendera 3D‑effekter för PowerPoint‑former och -text i Node.js med Aspose.Slides. Konfigurera kamera, belysning, material, extrusion, fyllningar och 3D‑text."
---
## **Översikt**

Aspose.Slides för Node.js via Java kan skapa, redigera, bevara och rendera PowerPoint‑liknande 3D‑formatering för former och text. Denna artikel täcker 3D‑effekter såsom rotation, extrusion, fasader, belysning, material, gradient‑ eller bildfyllningar och 3D‑text.

{{% alert color="info" title="Note" %}}
Denna artikel handlar om 3D‑formateringseffekter på PowerPoint‑former och text. Den handlar inte om att infoga eller redigera fristående 3D‑modellfiler. När du exporterar en bild till en bild, PDF eller HTML renderar Aspose.Slides dessa 3D‑effekter i den exporterade 2D‑utdata.
{{% /alert %}}

## **3D‑formateringskoncept**

Använd metoden [Shape.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getThreeDFormat) för att tillämpa 3D‑formatering på en form. Metoden returnerar [ThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/), som styr 3D‑scenen för den formen.

För text, använd metoden [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Detta tillämpar 3D‑formatering på textramen istället för formens kropp.

De viktigaste API‑medlemmarna är:

| API‑medlem | Vad den styr | När den ska användas |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getCamera) | Vypunkt, förinställd kameratyp, rotation, zoom och perspektiv. | Rotera objektet i 3D‑rymd eller matcha en förinställd PowerPoint‑3D‑rotation. |
| [getLightRig](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getLightRig) | Ljusförinställning, riktning och ljusrotation. | Ändra hur högdagrar och skuggor visas på 3D‑ytan. |
| [getMaterial](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getMaterial) and [setMaterial](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setMaterial) | Ytmaterial, såsom platt, matt, plast eller metall. | Gör samma geometri plattare, mjukare, glansigare eller metallisk. |
| [getExtrusionHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getExtrusionHeight) and [setExtrusionHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) | Hur långt formen sträcker sig bakåt från dess framsida. | Gör en platt form till ett synligt tjockt 3D‑objekt. |
| [getExtrusionColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) | Färg på de extruderade sidorna. | Gör djupet synligt eller samordna sidfärgen med framsidesfyllning. |
| [getDepth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getDepth) and [setDepth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setDepth) | Ytterligare 3D‑djup som används av PowerPoint 3D‑formatering. | Finjustera djup för former eller text, särskilt tillsammans med fasad‑ och materialinställningar. |
| [getBevelTop](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getBevelTop) and [getBevelBottom](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getBevelBottom) | Upphöjda eller avrundade kanter på framsidan och baksidan. | Lägg till en mjukad eller formad kant istället för en skarp platt yta. |
| [getContourColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getContourColor), [getContourWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getContourWidth), and [setContourWidth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setContourWidth) | Kontur runt 3D‑objektet. | Betona objektets gräns i renderad utdata. |

## **Skapa en 3D‑form**

En form brukar behöva fyra typer av inställningar innan den ser övertygande 3D ut:

- Kamerainställningar, eftersom standardframsidan kan dölja extrusionen.  
- Ljuseinställningar, eftersom belysning gör ytorna och sidorna läsbara.  
- Materialinställningar, eftersom ytan påverkar hur ljus renderas.  
- Extruderings‑ eller djupinställningar, eftersom en platt form behöver tjocklek.

Följande exempel skapar en rektangel, lägger till text på dess framsida och tillämpar 3D‑formatering. Kamerarotationsvärdena är i grader och extruderingshöjden är 100 punkter. Exemplet renderar bilden till en PNG‑fil med dubbla standarddimensioner och sparar presentationen som PPTX.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getTextFrame().setText("3D");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("shape_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("shape_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Den renderade bildspelsbilden visar rektangeln som ett tjockt 3D‑block:

![Renderad blå 3D‑rektangel med vit 3D‑text på framsidan](img_01_01.png)

## **Rotera en form med kameran**

I PowerPoint konfigureras 3D‑rotation från panelen 3‑D‑rotation. X-, Y‑ och Z‑rotationsvärdena motsvarar rotationen du anger via kamera‑API‑t.

![PowerPoint‑panel för 3‑D‑rotation med X‑, Y‑ och Z‑rotationsvärden markerade](img_02_01.png)

I Aspose.Slides nås kameran via [ThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getCamera). Detta exempel skapar en rektangel, väljer en ortografisk framsida och sätter dess X‑, Y‑ och Z‑rotationer till 20, 30 respektive 40 grader. Det konfigurerar formen i minnet utan att spara en fil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
} finally {
    presentation.dispose();
}
```

Använd kameran när du behöver ändra hur betraktaren ser objektet. Det förändrar inte 2D‑geometrin för formen på bilden. Det ändrar 3D‑vy‑punkten som PowerPoint och Aspose.Slides använder vid rendering.

## **Lägg till extrusion och djup**

Extrusion får en form att se tjock ut genom att förlänga den bakom framsidan. I PowerPoint styr djupkontrollen denna synliga tjocklek och färgkontrollen anger färgen på sidoytorna.

![PowerPoint‑djupkontroller mappade till extrusionens färg‑ och höjd‑egenskaper](img_02_02.png)

Använd [ThreeDFormat.setExtrusionHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) för att sätta tjockleken och [ThreeDFormat.getExtrusionColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getExtrusionColor) för att komma åt sidfärgen. Detta exempel ger en rektangel en 100‑punkts extrusion med lila sidor och roterar kameran för att visa dess tjocklek. Det konfigurerar formen i minnet utan att spara en fil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 200, 200);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(20, 30, 40);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(100);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Metoden [ThreeDFormat.setDepth](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setDepth) sätter djupet för en 3D‑form. Metoden [setExtrusionHeight](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#setExtrusionHeight) styr höjden på extrusionseffekten, som visas i detta exempel.

## **Använd gradient‑ eller bildfyllning med 3D‑effekter**

3D‑formatering är oberoende av formens fyllning. Du kan tillämpa en solid färg, gradient, mönster eller bildfyllning på framsidan och fortfarande använda samma kamera, ljus, material och extruderingsinställningar.

Detta exempel tillämpar en blå‑till‑orange gradient på framsidan och en mörkorange färg på den 150‑punkts extrusionen. Gradientstopparna vid 0 och 100 markerar början och slutet på gradienten. Kamerarotationsvärdena är i grader. Bilden renderas till en PNG‑fil med dubbla standarddimensioner:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getTextFrame().setText("3D Gradient");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(64);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "BLUE"));
    const orangeColor = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    shape.getFillFormat().getGradientFormat().getGradientStops().add(100, orangeColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("gradient_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }
} finally {
    presentation.dispose();
}
```

Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion:

![Renderad 3D‑rektangel med en blå‑till‑orange gradientfyllning och orange extrusion](img_02_03.png)

För att i stället använda en bildfyllning, lägg till bilden i presentationen och tilldela den som formens fyllning. Detta exempel förutsätter att en fil med namnet "image.jpg" finns i arbetskatalogen. Bilden sträcks för att fylla rektangeln, en 150‑punkts extrusion appliceras och kamerarotation anges i grader. Det konfigurerar formen i minnet utan att spara eller rendera en fil:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    const sourceImage = aspose.slides.Images.fromFile("image.jpg");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);

    const extrusionColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(10, 20, 30);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(150);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
} finally {
    presentation.dispose();
}
```

Renderad 3D‑rektangel med foto‑fyllning på framsidan och orange extrusion:

![Renderad 3D‑rektangel med foto‑fyllning på framsidan och orange extrusion](img_02_04.png)

## **Tillämpa 3D‑formatering på text**

Formens 3D‑formatering påverkar formkroppen. Textens 3D‑formatering påverkar textramen. Detta är användbart för WordArt‑liknande effekter där bokstäverna själva behöver extrusion, material, belysning och kamerainställningar.

Följande exempel skapar text med ett orange‑och‑vitt rutnätmönster, tillämpar en uppåtböjd båge och konfigurerar 3D‑inställningarna via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Extruderingshöjden och djupet anges i punkter, och ljusrotationen i grader. Formens fyllning och kontur döljs så att endast texten syns. Exemplet renderar en PNG‑fil med dubbla bildens standarddimensioner och sparar presentationen som PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const imageScale = 2;

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 150, 250, 250);

    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().setText("3D Text");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const patternColor = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(patternColor);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.LargeGrid));

    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(128);

    const textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setTransform(java.newByte(aspose.slides.TextShapeType.ArchUp));
    textFrameFormat.getThreeDFormat().setExtrusionHeight(3.5);
    textFrameFormat.getThreeDFormat().setDepth(3);
    textFrameFormat.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
    textFrameFormat.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrameFormat.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrameFormat.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
    textFrameFormat.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);

    const thumbnail = slide.getImage(imageScale, imageScale);
    try {
        thumbnail.save("text_3d.png", aspose.slides.ImageFormat.Png);
    } finally {
        thumbnail.dispose();
    }

    presentation.save("text_3d.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Renderad 3D‑text med en böjd WordArt‑transformering, orange mönsterfyllning och mörk extrusion:

![Renderad 3D‑text med en böjd WordArt‑transformering, orange mönsterfyllning och mörk extrusion](img_02_05.png)

## **Behåll text platt på en 3D‑form**

För att hålla texten läsbar samtidigt som formens 3D‑utseende bevaras, anropa [TextFrameFormat.setKeepTextFlat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setKeepTextFlat) via [TextFrame.getTextFrameFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#getTextFrameFormat). När värdet är `true` förblir texten utanför 3D‑scenen. När det är `false` deltar texten i scenen och följer dess 3D‑orientering.

Denna inställning tar inte bort formens 3D‑formatering: dess kamera, belysning, material och extrusion förblir konfigurerade via [Shape.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getThreeDFormat). Den skiljer sig också från vanlig rotation. [Shape.setRotation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#setRotation) roterar formen i bildens plan, medan [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setRotationAngle) styr textens egna rotation inom dess omgivande ruta. Att hålla texten utanför 3D‑scenen återställer inte något av dessa vinklar.

Följande självständiga exempel skapar en blå rektangel med text och klonar den bredvid originalet. Båda formerna har samma 3D‑formatering; endast textinställningen skiljer sig: `false` till vänster och `true` till höger. Kameravinklarna är i grader och extruderingshöjden är 40 punkter. Exemplet sparar presentationen som PPTX och renderar jämförelsesliden till PNG med dubbla standarddimensioner.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 70, 160, 240, 140);

    shape.getTextFrame().setText("Readable text");
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);
    shape.getTextFrame().getParagraphs().get_Item(0).getParagraphFormat().setAlignment(java.newByte(aspose.slides.TextAlignment.Center));
    shape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Center));
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const fillColor = java.newInstanceSync("java.awt.Color", 100, 149, 237);
    shape.getFillFormat().getSolidFillColor().setColor(fillColor);

    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getCamera().setRotation(30, 30, 0);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Flat);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    shape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Flat);
    shape.getThreeDFormat().setExtrusionHeight(40);
    const extrusionColor = java.newInstanceSync("java.awt.Color", 65, 105, 225);
    shape.getThreeDFormat().getExtrusionColor().setColor(extrusionColor);
    shape.getTextFrame().getTextFrameFormat().setKeepTextFlat(false);

    const flatTextShape = slide.getShapes().addClone(shape, 400, 160);
    flatTextShape.getTextFrame().getTextFrameFormat().setKeepTextFlat(true);

    presentation.save("keep_text_flat.pptx", aspose.slides.SaveFormat.Pptx);
    const image = slide.getImage(2, 2);
    try {
        image.save("keep_text_flat.png", aspose.slides.ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Till vänster följer texten 3D‑orienteringen. Till höger förblir den platt och enklare att läsa. Båda rektanglarna behåller samma synliga extrusion och 3D‑orientering.

![Sida‑vid‑sida 3D‑rektanglar: text följer 3D‑orienteringen till vänster och förblir platt till höger](keep_text_flat.png)

## **Export‑ och renderingsbeteende**

Aspose.Slides bevarar 3D‑formatering när du sparar i PowerPoint‑format som PPTX. När du renderar eller exporterar till layout‑fixerade format rasteriseras 3D‑scenen eller ritas in i utdata som ett 2D‑resultat. Detta gäller när du renderar bilder till [PNG](/slides/sv/nodejs-java/convert-powerpoint-to-png/), exporterar till [PDF](/slides/sv/nodejs-java/convert-powerpoint-to-pdf/), exporterar till [HTML](/slides/sv/nodejs-java/convert-powerpoint-to-html/), eller genererar ramar för [videokonvertering](/slides/sv/nodejs-java/convert-powerpoint-to-video/).

Tänk på följande:

- Exporterade bilder och PDF‑filer är inte interaktiva. Objektet kan inte roteras av betraktaren efter export.
- Det slutgiltiga utseendet beror på kombinationen av kamera, ljusrigg, material, extrusion, fyllning och bildskalning.
- Om du behöver undersöka ärvda eller temabaserade formateringsvärden, läs de [effective shape properties](/slides/sv/nodejs-java/shape-effective-properties/).
- Vissa utdataformat kan inte lagra redigerbar PowerPoint 3D‑formatering. I dessa format renderas den visuella resultatet istället för att bevaras som redigerbara 3D‑inställningar.

## **FAQ**

**Kan Aspose.Slides skapa interaktiva 3D‑presentationer?**

Aspose.Slides skapar och renderar PowerPoint 3D‑effekter för former och text. Det gör inte exporterade bilder, PDF‑filer eller HTML‑sidor till interaktiva 3D‑scener som en betraktare kan rotera. I PPTX förblir 3D‑formateringen redigerbar i PowerPoint där formatet stödjer det.

**Vad är skillnaden mellan en 3D‑modell och en 3D‑effekt?**

En 3D‑modell är ett separat 3D‑objekt som infogas i en presentation. En 3D‑effekt är formatering som appliceras på en vanlig PowerPoint‑form eller text, såsom rotation, extrusion, fasad, belysning och material. Denna artikel täcker 3D‑effekter.

**Vilka inställningar krävs för en synlig 3D‑form?**

Som minimum måste du ange en kamerarotation och antingen extrusion eller djup. I praktiken brukar du också ange en ljusrigg och material så att de renderade ytorna får tydliga högdagrar och skuggor.

**Kan jag tillämpa 3D‑effekter på både former och text?**

Ja. Använd [Shape.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getThreeDFormat) för formkroppen och [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat) för text.

**Kommer 3D‑effekter att visas vid export till bilder, PDF, HTML eller videobilder?**

Ja. Aspose.Slides renderar 3D‑effekter när du producerar bildslidor, PDF‑utdata, HTML‑utdata och ramar som används för videokonvertering. Den exporterade utdata innehåller den renderade utseendet, inte ett redigerbart 3D‑objekt.

**Kan jag läsa de slutgiltiga 3D‑värdena efter arv och temainställningar har tillämpats?**

Ja. Använd de effektiva formaterings‑API‑erna som beskrivs i [Shape Effective Properties](/slides/sv/nodejs-java/shape-effective-properties/) för att läsa den slutgiltiga kameran, ljusriggen, fasaden och relaterade 3D‑värden.