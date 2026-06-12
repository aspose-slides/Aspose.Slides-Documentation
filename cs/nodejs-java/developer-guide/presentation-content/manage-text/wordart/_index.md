---
title: Vytvoření a použití efektů WordArt v JavaScriptu
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
- efekt zobrazení
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte a přizpůsobte efekty WordArt v Aspose.Slides pro Node.js. Tento návod krok za krokem pomáhá vývojářům vylepšit prezentace profesionálním textem."
---
## **Přehled**

Efekty WordArt vám umožňují přidávat vizuálně atraktivní, stylizovaný text do vašich prezentací PowerPoint. S Aspose.Slides mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint—bez nutnosti instalace Office. Tento článek poskytuje přehled práce s WordArt, včetně aplikace textových transformací, výplní, obrysů, stínů a dalších možností formátování, aby byl obsah prezentace výraznější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo výraznější.

## **Vytvoření jednoduché šablony WordArt a její použití na text**

**Použití Aspose.Slides** 

Nejprve vytvoříme jednoduchý text pomocí tohoto JavaScript kódu:

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
Nyní nastavíme výšku písma textu na větší hodnotu, aby byl efekt patrnější, pomocí tohoto kódu:

```javascript
var fontData = new aspose.slides.FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Použití Microsoft PowerPoint**

Přejděte do nabídky efektů WordArt v Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

V nabídce vpravo můžete vybrat předdefinovaný efekt WordArt. V nabídce vlevo můžete zadat nastavení pro nový WordArt. 

Toto jsou některé dostupné parametry nebo možnosti:

![todo:image_alt_text](image-20200930114015-3.png)

**Použití Aspose.Slides**

Zde použijeme barvu vzoru [SmallGrid](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PatternStyle#SmallGrid) na text a přidáme černý okraj textu o šířce 1 pomocí tohoto kódu:

```javascript
portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.SmallGrid));
portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
```

Výsledný text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Použití dalších efektů WordArt**

**Použití Microsoft PowerPoint**

V rozhraní programu můžete tyto efekty aplikovat na text, blok textu, tvar nebo podobný prvek:

![todo:image_alt_text](image-20200930114129-5.png)

Například efekty Stín, Odraz a Záře lze aplikovat na text; efekty 3D Formát a 3D Rotace lze aplikovat na blok textu; vlastnost Měkké hrany lze aplikovat na objekt tvaru (má efekt i když není nastaven žádný 3D Formát). 

### **Aplikace stínových efektů**

Zde zamýšlíme nastavit vlastnosti vztahující se pouze na text. Stínový efekt na text aplikujeme pomocí tohoto JavaScript kódu:

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

Aspose.Slides API podporuje tři typy stínů: OuterShadow, InnerShadow a PresetShadow. 

S PresetShadow můžete aplikovat stín na text (použitím předdefinovaných hodnot). 

**Použití Microsoft PowerPoint**

V PowerPointu můžete použít jeden typ stínu. Zde je příklad:

![todo:image_alt_text](image-20200930114225-6.png)

**Použití Aspose.Slides**

Aspose.Slides ve skutečnosti umožňuje aplikovat dva typy stínů najednou: InnerShadow a PresetShadow.

**Poznámky:**

- Když jsou použity OuterShadow a PresetShadow společně, aplikuje se pouze efekt OuterShadow. 
- Pokud jsou použity OuterShadow a InnerShadow současně, výsledný nebo aplikovaný efekt závisí na verzi PowerPointu. Například v PowerPoint 2013 se efekt zdvojnásobí. V PowerPoint 2007 se aplikuje efekt OuterShadow. 

### **Aplikace zobrazení na texty**

Přidáme zobrazení k textu pomocí tohoto příkladu kódu v JavaScriptu:

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

### **Aplikace efektu Záře na texty**

Pomocí tohoto kódu aplikujeme na text efekt Záře, aby zářil nebo vynikl:

```javascript
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR(255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(aspose.slides.ColorTransformOperation.SetAlpha, 0.54);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Výsledek operace:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Můžete změnit parametry pro stín, zobrazení a záři. Vlastnosti efektů se nastavují na každou část textu zvlášť. 
{{% /alert %}} 

### **Použití transformací ve WordArt**

Použijeme vlastnost Transform (inherentní v celém bloku textu) pomocí tohoto kódu:
```javascript
textFrame.getTextFrameFormat().setTransform(java.newByte(aspose.slides.TextShapeType.ArchUpPour));
```

Výsledek:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Microsoft PowerPoint i Aspose.Slides pro Node.js přes Java poskytují určitý počet předdefinovaných typů transformací. 
{{% /alert %}} 

**Použití PowerPoint**

Pro přístup k předdefinovaným typům transformací přejděte: **Formát** -> **TextEffect** -> **Transform**

**Použití Aspose.Slides**

Pro výběr typu transformace použijte výčet TextShapeType. 

### **Aplikace 3D efektů na texty a tvary**

Nastavíme 3D efekt na tvar textu pomocí tohoto ukázkového kódu:

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

Výsledný text a jeho tvar:

![todo:image_alt_text](image-20200930114816-9.png)

Aplikujeme 3D efekt na text pomocí tohoto JavaScript kódu:

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

Výsledek operace:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Aplikace 3D efektů na texty nebo jejich tvary a interakce mezi efekty jsou založeny na určitých pravidlech. 

Uvažujme scénu pro text a tvar, který text obsahuje. 3D efekt obsahuje reprezentaci 3D objektu a scénu, na které je objekt umístěn. 

- Když je scéna nastavena jak pro tvar, tak pro text, má scéna tvaru vyšší prioritu—scéna textu je ignorována. 
- Když tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu. 
- Jinak—když tvar původně nemá 3D efekt—tvar zůstane plochý a 3D efekt se aplikuje pouze na text. 

Tyto popisy jsou spojeny s metodami ThreeDFormat.getLightRig() a ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Aplikace efektů vnějšího stínu na texty**

Aspose.Slides pro Node.js přes Java poskytuje třídy [**OuterShadow**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/outershadow/) a [**InnerShadow**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/innershadow/), které umožňují aplikovat efekty stínu na text obsažený v [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/). Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation). 
2. Získejte referenci na snímek pomocí jeho indexu. 
3. Přidejte na snímek AutoShape typu Rectangle. 
4. Získejte přístup k TextFrame spojenému s AutoShape. 
5. Nastavte FillType AutoShape na NoFill. 
6. Vytvořte instanci třídy OuterShadow 
7. Nastavte BlurRadius stínu. 
8. Nastavte Direction stínu. 
9. Nastavte Distance stínu. 
10. Nastavte RectanglelAlign na TopLeft. 
11. Nastavte PresetColor stínu na Black. 
12. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) . 

Tento ukázkový kód v Javě – implementace výše uvedených kroků – ukazuje, jak aplikovat efekt vnějšího stínu na text:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Získat referenci na snímek
    var sld = pres.getSlides().get_Item(0);
    // Přidat AutoShape typu Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 150, 50);
    // Přidat TextFrame k obdélníku
    ashp.addTextFrame("Aspose TextBox");
    // Zakázat výplň tvaru, pokud chceme získat stín textu
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Přidat vnější stín a nastavit všechny potřebné parametry
    ashp.getEffectFormat().enableOuterShadowEffect();
    var shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(aspose.slides.RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(aspose.slides.PresetColor.Black);
    // Uložit prezentaci na disk
    pres.save("pres_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Aplikace efektu vnitřního stínu na tvary**

Postupujte podle těchto kroků:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation). 
2. Získejte referenci na snímek. 
3. Přidejte AutoShape typu Rectangle. 
4. Povolte InnerShadowEffect. 
5. Nastavte všechny potřebné parametry. 
6. Nastavte ColorType na Scheme. 
7. Nastavte Scheme Color. 
8. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) . 

Tento ukázkový kód (na základě výše uvedených kroků) ukazuje, jak přidat spojku mezi dvěma tvary v JavaScriptu:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Získat referenci na snímek
    var slide = pres.getSlides().get_Item(0);
    // Přidat AutoShape typu Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Přidat TextFrame k obdélníku
    ashp.addTextFrame("Aspose TextBox");
    var port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    var pf = port.getPortionFormat();
    pf.setFontHeight(50);
    // Povolit efekt vnitřního stínu
    var ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();
    // Nastavit všechny potřebné parametry
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB(189);
    // Nastavit ColorType jako Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(aspose.slides.ColorType.Scheme);
    // Nastavit Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(aspose.slides.SchemeColor.Accent1);
    // Uložit prezentaci
    pres.save("WordArt_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu používat efekty WordArt s různými fonty nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides podporuje Unicode a pracuje se všemi hlavními fonty a skripty. Efekty WordArt jako stín, výplň a obrys lze použít nezávisle na jazyku, i když dostupnost fontů a vykreslování může záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky hlavního snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v hlavních snímcích, včetně zástupců titulku, zápatí nebo textu na pozadí. Změny provedené v hlavním rozvržení se projeví ve všech souvisejících snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt jako stíny, záře a gradientové výplně mohou mírně navýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu náhlednout výsledek efektů WordArt bez uložení prezentace?**

Ano, můžete renderovat snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí metody `getImage` z tříd [Shape](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/shape/) nebo [Slide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slide/), což vám umožní náhled v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.