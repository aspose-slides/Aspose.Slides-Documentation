---
title: Vytvořit a aplikovat WordArt efekty na Android
linktitle: WordArt
type: docs
weight: 110
url: /cs/androidjava/wordart/
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
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro Android pomocí Javy. Tento krok-za-krokem průvodce pomáhá vývojářům vylepšit prezentace profesionálním textem na Androidu."
---
## **Přehled**

Efekty WordArt vám umožňují stylovat text výplněmi, obrysy, stíny, odrazy, záři, transformacemi a 3D formátováním. Tento článek vysvětluje, jak vytvářet a přizpůsobovat tyto efekty v PowerPoint prezentacích pomocí Aspose.Slides pro Android přes Java, aniž by byl nainstalován Microsoft Office.

## **Vytvořit jednoduchou šablonu WordArt a použít ji na text**

Následující příklady vytvářejí jednoduchý styl WordArt nastavením textu, písma, výplně vzorem a obrysu.

Každý příklad vytvoří novou prezentaci a přidá obdélník na první snímek; vstupní soubor není potřeba. První příklad nastaví text na „Aspose.Slides“. Pozice a rozměry tvaru jsou měřeny v bodech:

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

Nastavte písmo na Arial Black s velikostí 36 bodů, aby bylo formátování výraznější:

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

Použijte vzor [SmallGrid](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/patternstyle/#SmallGrid) s tmavě oranžovou barvou popředí a bílým pozadím, poté přidejte černý obrys textu šířky 1 bod:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int darkOrange = Color.rgb(255, 140, 0);
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

![Jednoduchá šablona WordArt](WordArt_template.png)

## **Použít další efekty WordArt**

Následující příklady ukazují, jak na text aplikovat stíny, odrazy, záři, transformace a 3D efekty.

### **Použít vnější stínové efekty**

Vnější stín přidává hloubku umístěním stínu za text. Můžete upravit jeho barvu, směr, vzdálenost, poloměr rozostření, měřítko a zkosení.

Tento příklad volá [enableOuterShadowEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effectformat/#enableOuterShadowEffect--) a nastaví černý stín s poloměrem rozostření 4 body, směrem 230 °, a vzdáleností 30 bodů. Hodnoty měřítka 100 zachovávají velikost stínu, zatímco horizontální zkosení ho nakloní o 20 °. Alfa transformace nastaví jeho neprůhlednost na 32 %:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Efekt vnějšího stínu](outer_shadow_effect.png)

{{% alert color="info" title="Note" %}}
- Při současném použití vnějšího a předdefinovaného stínu se použije jen vnější stín.
- Pokud jsou použity vnější a vnitřní stíny zároveň, výsledek závisí na verzi PowerPointu. Například v PowerPoint 2013 se efekt zdvojnásobí, zatímco v PowerPoint 2007 se použije pouze vnější stín.
{{% /alert %}}

### **Použít odrazové efekty**

Odraz vytvoří zrcadlovou kopii textu. Upravením jeho polohy, měřítka, rozostření a neprůhlednosti můžete řídit vzhled.

Tento příklad volá [enableReflectionEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effectformat/#enableReflectionEffect--) a převrátí odraz vertikálně se záporným měřítkem –100 %. Používá poloměr rozostření 0,5 bodů a vzdálenost 4,72 bodů. Neprůhlednost klesá z 60 % na 0,9 % mezi pozicemi 0 % a 60 % podél odrazu:

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

![Efekt odrazu](reflection_effect.png)

### **Použít zářivé efekty**

Zář přidává kolem textu měkký barevný obrys. Upravením barvy, neprůhlednosti a poloměru můžete efekt řídit.

Tento příklad volá [enableGlowEffect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/effectformat/#enableGlowEffect--) a použije červenou záři s neprůhledností 54 % a poloměrem 7 bodů:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

![Efekt záře](glow_effect.png)

### **Použít transformace WordArt**

Transformace WordArt ohýbají, roztačují nebo deformují blok textu.

Nastavte [setTransform](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframeformat/#setTransform-int-) na [ArchUpPour](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textshapetype/#ArchUpPour) pro zakřivení celého textového rámce směrem vzhůru:

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

![Transformace WordArt](transform_effect.png)

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Android přes Java poskytuje sadu předdefinovaných [typů transformací](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textshapetype/).
{{% /alert %}}

### **Použít 3D efekty na tvary a text**

Na tvar nebo jeho text můžete aplikovat 3D efekty. Šikmost, extruze, osvětlení a nastavení kamery řídí výsledný vzhled.

Následující příklad používá [ThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/) k přidání kruhových šikmostí, oranžové extruze a tmavě červeného konturu na obdélník. Rozměry šikmostí, výška extruze, šířka konturu a hloubka jsou měřeny v bodech. Plastický materiál, vyvážené osvětlení otočené o 40 ° kolem osy Z a perspektivní kamera definují jeho vzhled:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    autoShape.getThreeDFormat().getExtrusionColor().setColor(orange);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

![3D efekt tvaru](shape_3D_effect.png)

Tento příklad aplikuje podobné 3D formátování na text pomocí [TextFrameFormat.getThreeDFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframeformat/#getThreeDFormat--). Menší šikmosti tvarují hrany písmen, zatímco extruze a osvětlení dodávají textu hloubku:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    int orange = Color.rgb(255, 165, 0);
    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(orange);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    int darkRed = Color.rgb(139, 0, 0);
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

![3D efekt textu](text_3D_effect.png)

{{% alert color="info" title="Note" %}}
Aplikace 3D efektů na text nebo jeho tvary – a interakce mezi těmito efekty – je řízena specifickými pravidly. Uvažujte scénu zahrnující jak text, tak tvar, který jej obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, ve které je umístěn.

- Pokud je scéna nastavena jak pro tvar, tak pro text, má přednost scéna tvaru a scéna textu se ignoruje.
- Pokud tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Pokud tvar nemá žádný 3D efekt, je považován za plochý a 3D efekt se aplikuje pouze na text.

Tyto chování se vztahují k metodám [ThreeDFormat.getLightRig](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/#getLightRig--) a [ThreeDFormat.getCamera](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/threedformat/#getCamera--).
{{% /alert %}}

Chcete‑li zachovat text plochý a čitelný při zachování 3D formátování tvaru, podívejte se na [Keep Text Flat on a 3D Shape](/slides/cs/androidjava/3d-presentation/) pro porovnání obou nastavení a kompletní Java příklad.

## **Často kladené otázky**

**Mohu použít efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides pro Android přes Java podporuje Unicode a funguje se všemi hlavními písmy a skripty. Efekty WordArt, jako stíny, výplně a obrysy, lze aplikovat bez ohledu na jazyk, ačkoli dostupnost písma a vykreslování může záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky hlavního rozvržení snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v hlavních rozvrženích, včetně zástupných symbolů titulku, zápatí nebo textu na pozadí. Změny provedené v hlavním rozvržení se projeví ve všech přidružených snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako stíny, záře a gradientní výplně, mohou mírně zvýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek efektů WordArt bez ukládání prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí [ISlide.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/#getImage--), nebo vykreslit jednotlivé tvary pomocí [IShape.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/#getImage--). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením či exportem celé prezentace.