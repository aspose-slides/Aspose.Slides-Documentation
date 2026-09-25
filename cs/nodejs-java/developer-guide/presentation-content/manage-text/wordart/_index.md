---
title: Vytvořit a použít WordArt efekty v Node.js
linktitle: WordArt
type: docs
weight: 110
url: /cs/nodejs-java/wordart/
keywords:
- WordArt
- vytvořit WordArt
- šablona WordArt
- efekt WordArt
- efekt stínu
- efekt odrazu
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro Node.js přes Java. Tento podrobný průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v Node.js."
---
## **Přehled**

Efekty WordArt vám umožňují stylizovat text pomocí výplní, obrysů, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvářet a přizpůsobovat tyto efekty v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js přes Java, bez nainstalovaného Microsoft Office.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, písma, výplně vzorem a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na její první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na „Aspose.Slides“. Pozice a rozměry tvaru jsou měřeny v bodech:

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

Nastavte písmo na Arial Black o velikosti 36 bodů, aby bylo formátování výraznější:

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

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/patternstyle/#SmallGrid) s tmavě oranžovou popředím a bílým pozadím, poté přidejte černý obrys textu o šířce 1 bod:

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

Výsledný text:

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použijte další efekty WordArt**

Následující příklady ukazují, jak aplikovat stíny, odrazy, záři, transformace a 3D efekty na text.

### **Použijte efekty vnějšího stínu**

Vnější stín přidává hloubku umístěním stínu za text. Můžete upravit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [enableOuterShadowEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effectformat/#enableOuterShadowEffect) a nastaví černý stín s poloměrem rozostření 4 body, směrem 230 stupňů a vzdáleností 30 bodů. Hodnoty měřítka 100 zachovávají velikost stínu, zatímco horizontální zkosení ho naklání o 20 stupňů. Alfa transformace nastavuje jeho neprůhlednost na 32 %:

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

Výsledný text:

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" title="Poznámka" %}}
- Když jsou použity zároveň vnější a přednastavené stíny, aplikuje se pouze vnější stín.
- Pokud jsou použity současně vnější a vnitřní stíny, výsledný efekt závisí na verzi PowerPointu. Například ve PowerPointu 2013 je efekt zdvojený, zatímco ve PowerPointu 2007 se použije pouze vnější stín.
{{% /alert %}}

### **Použijte efekty odrazu**

Odraz vytvoří zrcadlovou kopii textu. Nastavte jeho pozici, měřítko, rozostření a neprůhlednost pro řízení vzhledu.

Tento příklad volá [enableReflectionEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effectformat/#enableReflectionEffect) a převrátí odraz vertikálně se měřítkem –100 %. Používá poloměr rozostření 0,5 bodů a vzdálenost 4,72 bodů. Neprůhlednost klesá z 60 % na 0,9 % mezi pozicemi 0 % a 60 % podél odrazu:

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

Výsledný text:

![Efekt odrazu](reflection_effect.png)

### **Použijte efekty záře**

Záře přidává měkký barevný obrys kolem textu. Nastavte její barvu, neprůhlednost a poloměr pro řízení efektu.

Tento příklad volá [enableGlowEffect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/effectformat/#enableGlowEffect) a použije červenou záři s 54 % neprůhledností a poloměrem 7 bodů:

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

Výsledný text:

![Efekt záře](glow_effect.png)

### **Použijte transformace WordArt**

Transformace WordArt ohýbají, natahují nebo deformují blok textu.

Nastavte [setTransform](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#setTransform) na [ArchUpPour](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textshapetype/#ArchUpPour), aby se celý textový rámec zakřivil směrem vzhůru:

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

Výsledný text:

![Transformace WordArt](transform_effect.png)

{{% alert color="info" title="Poznámka" %}}
Aspose.Slides pro Node.js přes Java poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textshapetype/).
{{% /alert %}}

### **Použijte 3D efekty na tvary a text**

Můžete aplikovat 3D efekty na tvar nebo na jeho text. Šikmosti, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/) k přidání kruhových šikmostí, oranžové extruze a tmavě červeného konturu k obdélníku. Rozměry šikmostí, výška extruze, šířka kontury a hloubka jsou měřeny v bodech. Plastický materiál, vyvážené osvětlení otočené o 40 stupňů kolem osy Z a perspektivní kamera definují vzhled:

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

Výsledný tvar:

![3D efekt tvaru](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/#getThreeDFormat). Menší šikmosti tvarují hrany písmen, zatímco extruze a osvětlení poskytují textu hloubku:

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

Výsledný text:

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" title="Poznámka" %}}
Aplikace 3D efektů na text nebo jejich tvary — a interakce mezi těmito efekty — je řízena specifickými pravidly. Uvažujte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, prioritu má scéna tvaru a scéna textu se ignoruje.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se aplikuje pouze na text.

Tyto chování se vztahují k metodám [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getLightRig) a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/threedformat/#getCamera).
{{% /alert %}}

Pro zachování plochého a čitelného textu při zachování 3D formátování tvaru viz [Keep Text Flat on a 3D Shape](/slides/cs/nodejs-java/3d-presentation/) pro porovnání obou nastavení a kompletní JavaScriptový příklad.

## **Časté otázky**

**Mohu používat efekty WordArt s různými fonty nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides pro Node.js přes Java podporuje Unicode a funguje se všemi hlavními fonty a skripty. Efekty WordArt, jako jsou stíny, výplně a obrysy, lze aplikovat nezávisle na jazyce, i když dostupnost fontů a renderování mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky master slide?**

Ano, můžete aplikovat efekty WordArt na tvary na master slide, včetně zástupných symbolů pro nadpis, zápatí nebo text na pozadí. Změny provedené v master rozvržení se projeví na všech přidružených slidech.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientní výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek efektů WordArt bez ukládání prezentace?**

Ano, můžete vykreslovat slidy obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/#getImage) nebo vykreslovat jednotlivé tvary pomocí [Shape.getImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/#getImage). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.