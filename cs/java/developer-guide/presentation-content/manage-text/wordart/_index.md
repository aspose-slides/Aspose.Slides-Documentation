---
title: Vytvoření a aplikace WordArt efektů v Javě
linktitle: WordArt
type: docs
weight: 110
url: /cs/java/wordart/
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
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro Java. Tento krok za krokem průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem v Javě."
---
## **Přehled**

Efekty WordArt vám umožňují stylizovat text pomocí výplní, obrysů, stínů, odrazů, záře, transformací a 3D formátování. Tento článek vysvětluje, jak vytvářet a přizpůsobovat tyto efekty v prezentacích PowerPoint pomocí Aspose.Slides pro Java, bez nainstalovaného Microsoft Office.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

Následující příklady vytvoří jednoduchý styl WordArt nastavením textu, písma, výplně vzorem a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na její první snímek; není vyžadován žádný vstupní soubor. První příklad nastaví text na "Aspose.Slides". Pozice a rozměry tvaru jsou měřeny v bodech:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    presentation.dispose();
}
```

Nastavte písmo na Arial Black o velikosti 36 bodů, aby bylo formátování výraznější:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    presentation.dispose();
}
```

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/java/com.aspose.slides/patternstyle/#SmallGrid) s tmavě oranžovou popředím a bílým pozadím a poté přidejte černý obrys textu šířky 1 bod:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    Color darkOrange = new Color(255, 140, 0);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(darkOrange);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().setWidth(1);
    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    presentation.dispose();
}
```

Výsledný text:

![The simple WordArt template](WordArt_template.png)

## **Použijte další efekty WordArt**

Následující příklady ukazují, jak použít stíny, odrazy, záři, transformace a 3D efekty na text.

### **Použijte efekty vnějšího stínu**

Vnější stín přidává hloubku umístěním stínu za text. Můžete přizpůsobit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [enableOuterShadowEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effectformat/#enableOuterShadowEffect--) a nastaví černý stín s poloměrem rozostření 4 body, směrem 230 stupňů a vzdáleností 30 bodů. Hodnoty měřítka 100 zachovávají velikost stínu, zatímco horizontální zkosení jej naklání o 20 stupňů. Alfa transformace nastaví průhlednost na 32 %:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(20);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    presentation.dispose();
}
```

Výsledný text:

![The Outer Shadow effect](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Když jsou použity současně vnější a předdefinované stíny, použije se pouze vnější stín.
- Pokud jsou současně použity vnější a vnitřní stíny, výsledek závisí na verzi PowerPointu. Například ve PowerPoint 2013 se efekt zdvojnásobí, zatímco ve PowerPoint 2007 se použije jen vnější stín.
{{% /alert %}}

### **Použijte efekty odrazu**

Odraz vytvoří zrcadlovou kopii textu. Upravením jeho polohy, měřítka, rozostření a průhlednosti můžete ovládat jeho vzhled.

Tento příklad volá [enableReflectionEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effectformat/#enableReflectionEffect--) a převrátí odraz vertikálně se škálou -100 %. Používá poloměr rozostření 0,5 bodu a vzdálenost 4,72 bodu. Průhlednost klesá z 60 % na 0,9 % mezi pozicemi 0 % a 60 % podél odrazu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableReflectionEffect();
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setBlurRadius(0.5);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDistance(4.72);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartPosAlpha(0f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndPosAlpha(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setDirection(90);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setScaleVertical(-100);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setStartReflectionOpacity(60f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setEndReflectionOpacity(0.9f);
    portion.getPortionFormat().getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.BottomLeft);
} finally {
    presentation.dispose();
}
```

Výsledný text:

![The Reflection effect](reflection_effect.png)

### **Použijte efekty záře**

Záře přidává kolem textu měkký barevný obrys. Přizpůsobením barvy, průhlednosti a poloměru můžete efekt řídit.

Tento příklad volá [enableGlowEffect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/effectformat/#enableGlowEffect--) a použije červenou záři s průhledností 54 % a poloměrem 7 bodů:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
    FontData font = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(font);
    portion.getPortionFormat().setFontHeight(36);

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setColor(Color.RED);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    presentation.dispose();
}
```

Výsledný text:

![The Glow effect](glow_effect.png)

### **Použijte transformace WordArt**

Transformace WordArt ohýbají, natahují nebo deformují blok textu.

Nastavte [setTransform](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setTransform-int-) na [ArchUpPour](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textshapetype/#ArchUpPour) pro zakřivení celého textového rámce směrem nahoru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");
    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    presentation.dispose();
}
```

Výsledný text:

![The WordArt transformation](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Java poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Použijte 3D efekty na tvary a text**

Můžete použít 3D efekty na tvar nebo na jeho text. Šikmé řezy, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/threedformat/) k přidání kulatých šikmých řezů, oranžové extruze a tmavě červeného obrysu k obdélníku. Rozměry šikmých řezů, výška extruze, šířka kontury a hloubka jsou měřeny v bodech. Plastický materiál, vyvážené osvětlení otočené o 40 ° kolem osy Z a perspektivní kamera definují jeho vzhled:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    Color orange = new Color(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    autoShape.getThreeDFormat().getContourColor().setColor(darkRed);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Výsledný tvar:

![The shape 3D effect](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#getThreeDFormat--). Menší šikmé řezy tvarují okraje písmen, zatímco extruze a osvětlení dodávají textu hloubku:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    Color orange = new Color(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    Color darkRed = new Color(139, 0, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(darkRed);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    presentation.dispose();
}
```

Výsledný text:

![The text 3D effect](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Aplikace 3D efektů na text nebo jejich tvary — a interakce mezi těmito efekty — je řízena specifickými pravidly. Uvažujte scénu, která zahrnuje jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, má prioritu scéna tvaru a scéna textu je ignorována.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar vůbec nemá 3D efekt, je považován za plochý a 3D efekt se použije pouze na text.

Tyto chování souvisejí s metodami [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/cs/java/com.aspose.slides/threedformat/#getLightRig--) a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/java/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Chcete-li zachovat text plochý a čitelný při zachování 3D formátování svého tvaru, podívejte se na [Keep Text Flat on a 3D Shape](/slides/cs/java/3d-presentation/) pro srovnání obou nastavení a kompletní Java příklad.

## **Často kladené otázky**

**Mohu používat efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides pro Java podporuje Unicode a funguje se všemi hlavními písmy a skripty. Efekty WordArt, jako jsou stín, výplň a obrys, lze použít bez ohledu na jazyk, i když dostupnost písma a vykreslování mohou záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky master snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v master snímcích, včetně zástupců titulků, zápatí nebo textu na pozadí. Změny provedené v rozložení masteru se projeví ve všech souvisejících snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientové výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu zobrazit náhled výsledku efektů WordArt bez uložení prezentace?**

Ano, můžete vykreslovat snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [ISlide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/#getImage--), nebo vykreslovat jednotlivé tvary pomocí [IShape.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/#getImage--). To vám umožní zobrazit náhled výsledku v paměti nebo na obrazovce před uložením nebo exportem celé prezentace.