---
title: Maak en pas WordArt-effecten toe in Node.js
linktitle: WordArt
type: docs
weight: 110
url: /nl/nodejs-java/wordart/
keywords:
- WordArt
- WordArt maken
- WordArt-sjabloon
- WordArt-effect
- schaduw-effect
- reflectie-effect
- gloed-effect
- WordArt-transformatie
- 3D-effect
- buitenste schaduw-effect
- binnenste schaduw-effect
- Node.js
- JavaScript
- Aspose.Slides
description: "Maak en pas WordArt-effecten aan in Aspose.Slides voor Node.js via Java. Deze stap-voor-stap gids helpt ontwikkelaars om presentaties te verbeteren met professionele tekst in Node.js."
---
## **Overzicht**

WordArt‑effecten stellen u in staat om tekst te stijlen met vullingen, contouren, schaduwen, reflecties, gloed, transformaties en 3D‑opmaak. Dit artikel legt uit hoe u deze effecten kunt maken en aanpassen in PowerPoint‑presentaties met Aspose.Slides voor Node.js via Java, zonder dat Microsoft Office geïnstalleerd is.

## **Maak een eenvoudige WordArt‑sjabloon en pas het toe op tekst**

De volgende voorbeelden bouwen een eenvoudige WordArt‑stijl door de tekst, het lettertype, de patroonvulling en de contour in te stellen.

Elk voorbeeld maakt een nieuwe presentatie aan en voegt een rechthoek toe aan de eerste dia; een invoerbestand is niet vereist. Het eerste voorbeeld stelt de tekst in op "Aspose.Slides". De positie en afmetingen van de vorm worden gemeten in punten:

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

Stel het lettertype in op Arial Black met 36 punten om de opmaak beter zichtbaar te maken:

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

Pas een [SmallGrid](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/patternstyle/#SmallGrid)-patroon toe met een donkeroranje voorgrond en een witte achtergrond, en voeg vervolgens een zwarte tekstcontour toe met een breedte van 1 punt:

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

De resulterende tekst:

![The simple WordArt template](WordArt_template.png)

## **Pas andere WordArt‑effecten toe**

De volgende voorbeelden laten zien hoe u schaduwen, reflecties, gloed, transformaties en 3D‑effecten op tekst kunt toepassen.

### **Pas buitenste schaduweffecten toe**

Een buitenste schaduw voegt diepte toe door een schaduw achter de tekst te plaatsen. U kunt de kleur, richting, afstand, vervagingsradius, schaal en scheefstand aanpassen.

Dit voorbeeld roept [enableOuterShadowEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) aan en stelt een zwarte schaduw in met een vervagingsradius van 4 punten, een richting van 230 graden en een afstand van 30 punten. Schaalwaarden van 100 behouden de schaduwgrootte, terwijl horizontale scheefstand deze 20 graden kantelt. De alfa‑transformatie stelt de opacity in op 32%:

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

De resulterende tekst:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Wanneer buitenste en vooraf ingestelde schaduwen samen worden gebruikt, wordt alleen de buitenste schaduw toegepast.
- Als buitenste en binnenste schaduwen gelijktijdig worden gebruikt, hangt het resulterende effect af van de PowerPoint‑versie. Bijvoorbeeld, in PowerPoint 2013 wordt het effect verdubbeld, terwijl in PowerPoint 2007 alleen de buitenste schaduw wordt toegepast.
{{% /alert %}}

### **Pas reflectie‑effecten toe**

Een reflectie maakt een gespiegeld duplicaat van de tekst. Pas de positie, schaal, vervaging en opacity aan om het uiterlijk te regelen.

Dit voorbeeld roept [enableReflectionEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) aan en draait de reflectie verticaal met een schaal van -100%. Het gebruikt een vervagingsradius van 0.5 punt en een afstand van 4.72 punt. De opacity daalt van 60% naar 0.9% tussen posities 0% en 60% langs de reflectie:

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

De resulterende tekst:

![The Reflection effect](reflection_effect.png)

### **Pas gloed‑effecten toe**

Een gloed voegt een zachte gekleurde omtrek rond de tekst toe. Pas de kleur, opacity en radius aan om het effect te regelen.

Dit voorbeeld roept [enableGlowEffect](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) aan en past een rode gloed toe met 54% opacity en een radius van 7 punten:

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

De resulterende tekst:

![The Glow effect](glow_effect.png)

### **Pas WordArt‑transformaties toe**

WordArt‑transformaties buigen, rekken of vervormen een blok tekst.

Stel [setTransform](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#setTransform) in op [ArchUpPour](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textshapetype/#ArchUpPour) om het volledige tekstkader omhoog te buigen:

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

De resulterende tekst:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides voor Node.js via Java biedt een set vooraf gedefinieerde [transformatietypen](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Pas 3D‑effecten toe op vormen en tekst**

U kunt 3D‑effecten toepassen op een vorm of op de bijbehorende tekst. Verbogen randen, extrusie, verlichting en camera‑instellingen bepalen het uiteindelijke uiterlijk.

Het volgende voorbeeld gebruikt [ThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/) om cirkelvormige verbogen randen, oranje extrusie en een donkerrode contour toe te voegen aan de rechthoek. Afmetingen van de verbogen randen, extrusie‑hoogte, contourbreedte en diepte worden gemeten in punten. Een plastic materiaal, evenwichtige verlichting gedraaid met 40 graden rond de Z-as, en een perspectiefcamera bepalen het uiterlijk:

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

De resulterende vorm:

![The shape 3D effect](shape_3D_effect.png)

Dit voorbeeld past een soortgelijke 3D‑opmaak toe op de tekst via [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Kleinere verbogen randen vormen de letterranden, terwijl extrusie en verlichting de tekst diepte geven:

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

De resulterende tekst:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
De toepassing van 3D‑effecten op tekst of hun vormen — en de interactie tussen deze effecten — wordt beheerst door specifieke regels. Beschouw een scène waarin zowel tekst als de vorm die het bevat aanwezig zijn. Een 3D‑effect omvat de 3D‑representatie van het object en de scène waarin het zich bevindt.

- Als er een scène is ingesteld voor zowel de vorm als de tekst, heeft de scène van de vorm voorrang en wordt de scène van de tekst genegeerd.
- Als de vorm geen eigen scène heeft maar wel een 3D‑representatie, wordt de scène van de tekst gebruikt.
- Als de vorm helemaal geen 3D‑effect heeft, wordt deze als plat beschouwd en wordt het 3D‑effect alleen op de tekst toegepast.

Dit gedrag heeft betrekking op de methoden [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getLightRig) en [ThreeDFormat.getCamera](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Om tekst plat en leesbaar te houden terwijl u de 3D‑opmaak van de vorm behoudt, zie [Keep Text Flat on a 3D Shape](/slides/nl/nodejs-java/3d-presentation/) voor een vergelijking van beide instellingen en een volledig JavaScript‑voorbeeld.

## **Veelgestelde vragen**

**Kan ik WordArt‑effecten gebruiken met verschillende lettertypen of scripts (bijv. Arabisch, Chinees)?**

Ja, Aspose.Slides voor Node.js via Java ondersteunt Unicode en werkt met alle belangrijke lettertypen en scripts. WordArt‑effecten zoals schaduw, vulling en contour kunnen worden toegepast ongeacht de taal, hoewel de beschikbaarheid van lettertypen en weergave kunnen afhangen van de systeemlettertypen.

**Kan ik WordArt‑effecten toepassen op elementen van de dia‑master?**

Ja, u kunt WordArt‑effecten toepassen op vormen in masterdia’s, inclusief titel‑plaatsaanduidingen, voetteksten of achtergrondtekst. Wijzigingen in de masterindeling worden doorgevoerd in alle bijbehorende dia’s.

**Beïnvloeden WordArt‑effecten de bestandsgrootte van de presentatie?**

Iets. WordArt‑effecten zoals schaduwen, gloeien en gradientvullingen kunnen de bestandsgrootte iets verhogen door extra opmaak‑metadata, maar het verschil is meestal verwaarloosbaar.

**Kan ik het resultaat van WordArt‑effecten bekijken zonder de presentatie op te slaan?**

Ja, u kunt dia’s met WordArt renderen naar afbeeldingen (bijv. PNG, JPEG) met behulp van [Slide.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/slide/#getImage), of individuele vormen renderen met [Shape.getImage](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/shape/#getImage). Hiermee kunt u het resultaat in het geheugen of op het scherm bekijken voordat u de volledige presentatie opslaat of exporteert.