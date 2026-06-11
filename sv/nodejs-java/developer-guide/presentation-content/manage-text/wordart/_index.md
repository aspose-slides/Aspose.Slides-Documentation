---
title: Skapa och tillämpa WordArt-effekter i JavaScript
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
- visningseffekt
- glödeffekt
- WordArt-transformation
- 3D-effekt
- yttre skuggeffekt
- inre skuggeffekt
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa och anpassa WordArt-effekter i Aspose.Slides för Node.js. Denna steg-for-steg-guide hjälper utvecklare att förbättra presentationer med professionell text."
---
## **Översikt**

WordArt-effekter låter dig lägga till visuellt tilltalande, stiliserad text i dina PowerPoint-presentationer. Med Aspose.Slides kan utvecklare programatiskt skapa, anpassa och hantera WordArt precis som i Microsoft PowerPoint—utan att behöva ha Office installerat. Denna artikel ger en översikt över hur du arbetar med WordArt, inklusive hur du tillämpar texttransformeringar, fyllningsstilar, konturer, skuggor och andra formateringsalternativ för att göra ditt presentationsinnehåll mer uttrycksfullt och engagerande. WordArt låter dig behandla text som ett grafiskt objekt. Det består av effekter eller specialmodifieringar som tillämpas på text för att göra den mer attraktiv eller märkbar.

## **Skapa en enkel WordArt-mall och tillämpa den på text**

**Använda Aspose.Slides** 

Först skapar vi en enkel text med den här JavaScript-koden:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    var textFrame = autoShape.getTextFrame();
    var portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
Nu sätter vi textens teckenhöjd till ett större värde för att göra effekten mer märkbar med den här koden:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Använda Microsoft PowerPoint**

Gå till menyn för WordArt-effekter i Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Från menyn till höger kan du välja en fördefinierad WordArt-effekt. Från menyn till vänster kan du ange inställningarna för en ny WordArt. 

Här är några av de tillgängliga parametrarna eller alternativen:

![todo:image_alt_text](image-20200930114015-3.png)

**Använda Aspose.Slides**

Här tillämpar vi färgmönstret [SmallGrid](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/PatternStyle#SmallGrid) på texten och lägger till en svart textkant med bredd 1 med den här koden:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Den resulterande texten:

![todo:image_alt_text](image-20200930114108-4.png)

## **Tillämpa andra WordArt-effekter**

**Använda Microsoft PowerPoint**

Från programmets klass kan du tillämpa dessa effekter på en text, textblock, form eller liknande element:

![todo:image_alt_text](image-20200930114129-5.png)

Till exempel kan Skugga-, Reflexions- och Glöd-effekter tillämpas på en text; 3D‑format- och 3D‑rotations‑effekter kan tillämpas på ett textblock; egenskapen Mjuka kanter kan tillämpas på ett formobjekt (den har fortfarande en effekt när ingen 3D‑format‑egenskap är inställd). 

### **Tillämpa skuggeffekter**

Här avser vi att endast ställa in egenskaper som gäller för text. Vi tillämpar skuggeffekten på en text med den här koden i JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.32);
```

Aspose.Slides API stödjer tre typer av skuggor: OuterShadow, InnerShadow och PresetShadow. 

Med PresetShadow kan du applicera en skugga på en text (med förinställda värden). 

**Använda Microsoft PowerPoint**

I PowerPoint kan du använda en typ av skugga. Här är ett exempel:

![todo:image_alt_text](image-20200930114225-6.png)

**Använda Aspose.Slides**

Aspose.Slides låter dig faktiskt tillämpa två typer av skuggor samtidigt: InnerShadow och PresetShadow.

**Obs:** 

- När OuterShadow och PresetShadow används tillsammans, appliceras endast OuterShadow-effekten. 
- Om OuterShadow och InnerShadow används samtidigt beror den resulterande eller applicerade effekten på PowerPoint-versionen. Till exempel, i PowerPoint 2013 fördubblas effekten. Men i PowerPoint 2007 appliceras OuterShadow-effekten. 

### **Tillämpa visning på texter**

Vi lägger till visning på texten med detta kodexempel i JavaScript:

```javascript
portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60.0);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9);
portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(aspose.slides.RectangleAlignment.BottomLeft);
```

### **Tillämpa glödeffekt på texter**

Vi tillämpar glödeffekten på texten för att få den att glänsa eller sticka ut med den här koden:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Du kan ändra parametrarna för skugga, visning och glöd. Effekternas egenskaper ställs in för varje del av texten separat. 

{{% /alert %}} 

### **Använda transformationer i WordArt**

Vi använder Transform‑egenskapen (inbyggd i hela textblocket) med den här koden:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Resultatet:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Både Microsoft PowerPoint och Aspose.Slides för Node.js via Java erbjuder ett visst antal fördefinierade transformationstyper.

{{% /alert %}} 

**Använda PowerPoint**

För att komma åt fördefinierade transformationstyper, gå via: **Format** -> **TextEffect** -> **Transform**

**Använda Aspose.Slides**

För att välja en transformationstyp, använd enum‑typen TextShapeType. 

### **Tillämpa 3D-effekter på texter och former**

Vi sätter en 3D-effekt på en textform med detta exempel på kod:

```javascript
autoShape.getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);
autoShape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
autoShape.getThreeDFormat().getBevelTop().setWidth(11);
autoShape.getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
autoShape.getThreeDFormat().setExtrusionHeight(6);
autoShape.getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
autoShape.getThreeDFormat().setContourWidth(1.5);
autoShape.getThreeDFormat().setDepth(3);
autoShape.getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
autoShape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);
autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Den resulterande texten och dess form:

![todo:image_alt_text](image-20200930114816-9.png)

Vi tillämpar en 3D-effekt på texten med denna JavaScript-kod:

```javascript
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);
textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);
textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);
textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);
textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(aspose.slides.MaterialPresetType.Plastic);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);
textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);
textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.PerspectiveContrastingRightFacing);
```

Resultatet av operationen:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Tillämpningen av 3D-effekter på texter eller deras former och interaktionen mellan effekter baseras på vissa regler.

Tänk på en scen för en text och den form som innehåller den texten. 3D-effekten innehåller en 3D‑objektrepresentation och den scen där objektet placerades.

- När scenen är inställd för både figur och text får figurscenen högre prioritet – texts cenen ignoreras.
- När figuren saknar egen scen men har 3D‑representation används texts cenen.
- Annars – när formen ursprungligen inte har någon 3D‑effekt – är formen plan och 3D‑effekten appliceras endast på texten.

Dessa beskrivningar är kopplade till metoderna ThreeDFormat.getLightRig() och ThreeDFormat.getCamera(). 

{{% /alert %}} 

## **Tillämpa yttre skuggeffekter på texter**

Aspose.Slides för Node.js via Java tillhandahåller klasserna [**OuterShadow**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/outershadow/) och [**InnerShadow**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/innershadow/) som låter dig tillämpa skuggeffekter på en text som finns i [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/). Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta referensen till en bild genom att använda dess index.
3. Lägg till en AutoShape av typen Rectangle på bilden.
4. Få åtkomst till TextFrame som är associerad med AutoShape.
5. Ställ in FillType för AutoShape till NoFill.
6. Instansiera OuterShadow-klassen
7. Ställ in BlurRadius för skuggan.
8. Ställ in Direction för skuggan
9. Ställ in Distance för skuggan.
10. Ställ in RectanglelAlign till TopLeft.
11. Ställ in PresetColor för skuggan till Black.
12. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta exempel på Java‑kod—en implementering av stegen ovan—visar hur du tillämpar yttre skuggeffekt på en text:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Hämta referensen till bilden
    var sld = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av Rectangle-typ
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Lägg till TextFrame till rektangeln
    ashp.addTextFrame("Aspose TextBox");
    // Inaktivera formfyllning ifall vi vill ha skugga av texten
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Lägg till yttre skugga och sätt alla nödvändiga parametrar
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Spara presentationen till disk
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tillämpa inre skuggeffekt på former**

Följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
2. Hämta en referens till bilden.
3. Lägg till en AutoShape av typen Rectangle.
4. Aktivera InnerShadowEffect.
5. Ställ in alla nödvändiga parametrar.
6. Ställ in ColorType till Scheme.
7. Ställ in Scheme‑färgen.
8. Spara presentationen som en [PPTX](https://docs.fileformat.com/presentation/pptx/)‑fil.

Detta exempel på kod (baserat på stegen ovan) visar hur du lägger till en förbindelse mellan två former i JavaScript:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Hämta referensen till bilden
    var slide = pres.getSlides().get_Item(0);
    // Lägg till en AutoShape av typen Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Lägg till TextFrame till rektangeln
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Aktivera InnerShadowEffect
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Ange alla nödvändiga parametrar
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Ange ColorType som Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Ange Scheme-färg
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Spara presentationen
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kan jag använda WordArt‑effekter med olika typsnitt eller skript (t.ex. Arabiska, Kinesiska)?**

Ja, Aspose.Slides stödjer Unicode och fungerar med alla större typsnitt och skript. WordArt‑effekter som skugga, fyllning och kontur kan appliceras oavsett språk, även om tillgänglighet och rendering av typsnitt kan bero på systemets typsnitt.

**Kan jag tillämpa WordArt‑effekter på element i bildmasteren?**

Ja, du kan applicera WordArt‑effekter på former i masterbilder, inklusive titelplatshållare, sidfot eller bakgrundstext. Ändringar som görs i masterlayouten kommer att återspeglas på alla associerade bilder.

**Påverkar WordArt‑effekter presentationsfilens storlek?**

Lite grann. WordArt‑effekter som skuggor, glöd och gradientfyllningar kan något öka filstorleken på grund av extra formateringsmetadata, men skillnaden är vanligtvis försumbar.

**Kan jag förhandsgranska resultatet av WordArt‑effekter utan att spara presentationen?**

Ja, du kan rendera bilder som innehåller WordArt till bilder (t.ex. PNG, JPEG) med metoden `getImage` från klasserna [Shape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/) eller [Slide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slide/). Detta låter dig förhandsgranska resultatet i minnet eller på skärmen innan du sparar eller exporterar hela presentationen.