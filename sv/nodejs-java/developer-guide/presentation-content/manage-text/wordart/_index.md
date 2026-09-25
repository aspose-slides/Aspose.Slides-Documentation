---
title: Skapa och tillämpa WordArt-effekter i Node.js
linktitle: WordArt
type: docs
weight: 110
url: /sv/nodejs-java/wordart/
keywords:
- WordArt
- skapa WordArt
- WordArt-mall
- WordArt-effekt
- skuggeffekt
- reflektionseffekt
- glödeffekt
- WordArt-transformation
- 3D-effekt
- yttre skuggeffekt
- inre skuggeffekt
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa WordArt-effekter i Aspose.Slides för Node.js via Java. Denna steg-för-steg-guide hjälper utvecklare att förbättra presentationer med professionell text i Node.js."
---
## **Översikt**

WordArt‑effekter låter dig formatera text med fyllningar, konturer, skuggor, reflektioner, glöd, transformationer och 3D‑formatering. Denna artikel förklarar hur du skapar och anpassar dessa effekter i PowerPoint‑presentationer med Aspose.Slides för Node.js via Java, utan att Microsoft Office är installerat.

## **Skapa en enkel WordArt‑mall och tillämpa den på text**

Följande exempel bygger en enkel WordArt‑stil genom att ange text, teckensnitt, mönsterfyllning och kontur.

Varje exempel skapar en ny presentation och lägger till en rektangel på den första bilden; ingen indatafil krävs. Det första exemplet anger texten till "Aspose.Slides". Formens position och dimensioner mäts i punkter:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();

    const portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Ställ in teckensnittet till Arial Black på 36 punkter för att göra formateringen mer märkbar:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Tillämpa ett [SmallGrid](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/patternstyle/#SmallGrid)-mönster med en mörkorange förgrund och en vit bakgrund, lägg sedan till en svart textkontur med en bredd på 1 punkt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    const darkOrange = java.newInstanceSync("java.awt.Color", 255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![The simple WordArt template](WordArt_template.png)

## **Tillämpa andra WordArt‑effekter**

Följande exempel visar hur man tillämpar skuggor, reflektioner, glöd, transformationer och 3D‑effekter på text.

### **Tillämpa yttre skuggeffekter**

En yttre skugga ger djup genom att placera en skugga bakom texten. Du kan anpassa dess färg, riktning, avstånd, oskärpegrad, skala och skevning.

Detta exempel anropar [enableOuterShadowEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) och anger en svart skugga med en oskärpegrad på 4 punkter, en riktning på 230 grader och ett avstånd på 30 punkter. Skalavärden på 100 bevarar skuggans storlek, medan horisontell skevning vinklar den 20 grader. Alfa‑transformen sätter dess opacitet till 32%:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.32));
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- När yttre och förinställda skuggor används tillsammans, tillämpas endast den yttre skuggan.
- Om yttre och inre skuggor används samtidigt beror den resulterande effekten på PowerPoint‑versionen. Till exempel, i PowerPoint 2013 dubblas effekten, medan i PowerPoint 2007 appliceras endast den yttre skuggan.
{{% /alert %}}

### **Tillämpa reflektionseffekter**

En reflektion skapar en spegelvänd kopia av texten. Justera dess position, skala, oskärpa och opacitet för att kontrollera dess utseende.

Detta exempel anropar [enableReflectionEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) och vänder reflektionen vertikalt med en skala på -100%. Det använder en oskärpegrad på 0,5 punkt och ett avstånd på 4,72 punkt. Opaciteten minskar från 60% till 0,9% mellan positionerna 0% och 60% längs reflektionen:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(java.newFloat(0));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(java.newFloat(60));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(java.newFloat(0.9));
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(java.newByte(aspose.slides.RectangleAlignment.BottomLeft));
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![The Reflection effect](reflection_effect.png)

### **Tillämpa glödeffekter**

Ett glöd ger en mjuk färgad kontur runt texten. Justera dess färg, opacitet och radie för att kontrollera effekten.

Detta exempel anropar [enableGlowEffect](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) och tillämpar ett rött glöd med 54% opacitet och en radie på 7 punkter:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    const font = new aspose.slides.FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, java.newFloat(0.54));
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![The Glow effect](glow_effect.png)

### **Tillämpa WordArt‑transformationer**

WordArt‑transformationer böjer, sträcker eller deformerar ett textblock.

Sätt [setTransform](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setTransform) till [ArchUpPour](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) för att kurva hela textramen uppåt:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);

    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides för Node.js via Java tillhandahåller en uppsättning fördefinierade [transformationstyper](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Tillämpa 3D‑effekter på former och text**

Du kan tillämpa 3D‑effekter på en form eller på dess text. Fasar, extrudering, belysning och kamerainställningar styr det resulterande utseendet.

Följande exempel använder [ThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/) för att lägga till cirkulära fasar, orange extrudering och en mörkröd kontur till rektangeln. Fasernas dimensioner, extruderingshöjd, konturbredd och djup mäts i punkter. Ett plastmaterial, balanserad belysning roterad 40 grader runt Z‑axeln och en perspektivkamera definierar dess utseende:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Den resulterande formen:

![The shape 3D effect](shape_3D_effect.png)

Detta exempel tillämpar liknande 3D‑formatering på texten via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Mindre fasar formar bokstavskanterna, medan extrudering och belysning ger texten djup:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 200);
    const textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    const orange = java.newInstanceSync("java.awt.Color", 255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    const darkRed = java.newInstanceSync("java.awt.Color", 139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Den resulterande texten:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Tillämpning av 3D‑effekter på text eller deras former — och interaktionen mellan dessa effekter — styrs av specifika regler. Tänk på en scen som involverar både text och den form som innehåller den. En 3D‑effekt inkluderar objektets 3D‑representation och den scen där den placeras.

- Om en scen är inställd för både formen och texten, har formens scen företräde och textens scen ignoreras.
- Om formen saknar sin egen scen men har en 3D‑representation, används textens scen.
- Om formen inte har någon 3D‑effekt alls behandlas den som platt, och 3D‑effekten tillämpas endast på texten.

Detta beteende relaterar till metoderna [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getLightRig) och [ThreeDFormat.getCamera](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

För att hålla texten platt och läsbar samtidigt som du behåller formens 3D‑formatering, se [Keep Text Flat on a 3D Shape](/slides/sv/nodejs-java/3d-presentation/) för en jämförelse av båda inställningarna och ett komplett JavaScript‑exempel.

## **FAQ**

**Kan jag använda WordArt‑effekter med olika teckensnitt eller skript (t.ex. arabiska, kinesiska)?**

Ja, Aspose.Slides för Node.js via Java stödjer Unicode och fungerar med alla större teckensnitt och skript. WordArt‑effekter såsom skugga, fyllning och kontur kan tillämpas oavsett språk, även om tillgänglighet och rendering av teckensnitt kan bero på systemets teckensnitt.

**Kan jag tillämpa WordArt‑effekter på element i slide‑mastern?**

Ja, du kan tillämpa WordArt‑effekter på former i master‑slides, inklusive titelplatshållare, sidfötter eller bakgrundstext. Ändringar som görs i master‑layouten kommer att återspeglas på alla associerade slides.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera slides som innehåller WordArt till bilder (t.ex. PNG, JPEG) med [Slide.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/#getImage), eller rendera enskilda former med [Shape.getImage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/#getImage). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.