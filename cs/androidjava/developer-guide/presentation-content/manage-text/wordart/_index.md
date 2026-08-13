---
title: "Vytvořte a použijte efekty WordArt na Androidu"
linktitle: "WordArt"
type: docs
weight: 110
url: /cs/androidjava/wordart/
keywords:
- WordArt
- "vytvořit WordArt"
- "šablona WordArt"
- "efekt WordArt"
- "efekt stínu"
- "efekt zobrazení"
- "efekt záře"
- "transformace WordArt"
- "3D efekt"
- "efekt vnějšího stínu"
- "efekt vnitřního stínu"
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte efekty WordArt v Aspose.Slides pro Android. Tento návod krok za krokem pomáhá vývojářům vylepšit prezentace profesionálním textem v jazyce Java."
---
## **Přehled**

Efekty WordArt vám umožňují přidávat vizuálně atraktivní, stylizovaný text do vašich prezentací PowerPoint. S Aspose.Slides mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint — bez nutnosti mít nainstalovaný Office. Tento článek poskytuje přehled o práci s WordArt, včetně toho, jak aplikovat transformace textu, výplňové styly, obrysy, stíny a další možnosti formátování, aby byl obsah vaší prezentace výraznější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo výraznější.

## **Vytvořte jednoduchou šablonu WordArt a použijte ji na text**

**Using Aspose.Slides** 

Nejprve vytvoříme jednoduchý text pomocí tohoto Java kódu: 

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();

    Portion portion = (Portion)textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");
} finally {
    if (pres != null) pres.dispose();
}
```
Nyní nastavíme výšku písma textu na větší hodnotu, aby byl efekt výraznější, pomocí tohoto kódu:

``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    FontData fontData = new FontData("Arial Black");
    portion.getPortionFormat().setLatinFont(fontData);
    portion.getPortionFormat().setFontHeight(36);
} finally {
    if (pres != null) pres.dispose();
}

```

**Using Microsoft PowerPoint**

Přejděte do nabídky efektů WordArt v Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

V nabídce vpravo můžete vybrat předdefinovaný efekt WordArt. V nabídce vlevo můžete zadat nastavení pro nový WordArt. 

Toto jsou některé z dostupných parametrů nebo možností:

![todo:image_alt_text](image-20200930114015-3.png)

**Using Aspose.Slides**

Zde použijeme barvu vzoru [SmallGrid](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PatternStyle#SmallGrid) na text a přidáme černý okraj textu o šířce 1 pomocí tohoto kódu:

``` java 
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
    portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

    portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
    portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
} finally {
    if (pres != null) pres.dispose();
}
```

Výsledný text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Použijte další efekty WordArt**

**Using Microsoft PowerPoint**

V rozhraní programu můžete tyto efekty použít na text, blok textu, tvar nebo podobný prvek:

![todo:image_alt_text](image-20200930114129-5.png)

Například efekty Stín, Odraz a Záře lze použít na text; efekty 3D Formát a 3D Rotace lze použít na blok textu; vlastnost Měkké hrany lze použít na objekt tvaru (stále má efekt, i když není nastavena vlastnost 3D Formát).

### **Použijte stínové efekty**

Zde chceme nastavit vlastnosti vztahující se pouze k textu. Stínový efekt na text aplikujeme pomocí tohoto Java kódu:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableOuterShadowEffect();
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.BLACK);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleHorizontal(100);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setScaleVertical(65);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setBlurRadius(4.73);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDirection(230);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setDistance(2);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewHorizontal(30);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().setSkewVertical(0);
    portion.getPortionFormat().getEffectFormat().getOuterShadowEffect().getShadowColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.32f);
} finally {
    if (pres != null) pres.dispose();
}
```

API Aspose.Slides podporuje tři typy stínů: OuterShadow, InnerShadow a PresetShadow. 

S PresetShadow můžete aplikovat stín na text (použitím předdefinovaných hodnot). 

**Using Microsoft PowerPoint**

V PowerPointu můžete použít jeden typ stínu. Zde je příklad:

![todo:image_alt_text](image-20200930114225-6.png)

**Using Aspose.Slides**

Aspose.Slides ve skutečnosti umožňuje aplikovat dva typy stínů najednou: InnerShadow a PresetShadow.

**Notes:**

- When OuterShadow and PresetShadow are used together, only the OuterShadow effect gets applied. 
- If OuterShadow and InnerShadow get used simultaneously, the resulting or applied effect depends on the PowerPoint version. For instance, in PowerPoint 2013, the effect gets doubled. But in PowerPoint 2007, the OuterShadow effect gets applied. 

### **Použijte odrazové efekty na text**

Přidáme odraz k textu pomocí tohoto ukázkového kódu v Java:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

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
    if (pres != null) pres.dispose();
}
```

### **Použijte efekty záře na text**

Pomocí tohoto kódu aplikujeme efekt záře na text, aby zazářil nebo vynikl.

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    IPortion portion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.setText("Aspose.Slides");

    portion.getPortionFormat().getEffectFormat().enableGlowEffect();
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
    portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
} finally {
    if (pres != null) pres.dispose();
}
```

Výsledek operace:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="info" %}} 
Můžete změnit parametry pro stín, odraz a záři. Vlastnosti efektů se nastavují na každou část textu samostatně. 
{{% /alert %}} 

### **Použijte transformace ve WordArt**

Použijeme vlastnost Transform (obsaženou v celém bloku textu) pomocí tohoto kódu:
``` java 
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
} finally {
    if (pres != null) pres.dispose();
}
```

Výsledek:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="info" %}} 
Jak Microsoft PowerPoint, tak Aspose.Slides pro Android pomocí Javy poskytují určitý počet předdefinovaných typů transformací. 
{{% /alert %}} 

**Using PowerPoint**

Chcete-li získat přístup k předdefinovaným typům transformací, přejděte přes: **Formát** -> **TextEffect** -> **Transform**

**Using Aspose.Slides**

Pro výběr typu transformace použijte enum TextShapeType. 

### **Použijte 3D efekty na text a tvary**

Nastavíme 3D efekt na tvar textu pomocí tohoto ukázkového kódu:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    autoShape.getTextFrame().setText("Aspose.Slides");

    autoShape.getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelBottom().setHeight(10.5);
    autoShape.getThreeDFormat().getBevelBottom().setWidth(10.5);

    autoShape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    autoShape.getThreeDFormat().getBevelTop().setHeight(12.5);
    autoShape.getThreeDFormat().getBevelTop().setWidth(11);

    autoShape.getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    autoShape.getThreeDFormat().setExtrusionHeight(6);

    autoShape.getThreeDFormat().getContourColor().setColor(Color.RED);
    autoShape.getThreeDFormat().setContourWidth(1.5);

    autoShape.getThreeDFormat().setDepth(3);

    autoShape.getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    autoShape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    autoShape.getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Výsledný text a jeho tvar:

![todo:image_alt_text](image-20200930114816-9.png)

Aplikujeme 3D efekt na text pomocí tohoto Java kódu:

``` java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("Aspose.Slides");

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setHeight(3.5);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelBottom().setWidth(3.5);

    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setHeight(4);
    textFrame.getTextFrameFormat().getThreeDFormat().getBevelTop().setWidth(4);

    textFrame.getTextFrameFormat().getThreeDFormat().getExtrusionColor().setColor(Color.ORANGE);
    textFrame.getTextFrameFormat().getThreeDFormat().setExtrusionHeight(6);

    textFrame.getTextFrameFormat().getThreeDFormat().getContourColor().setColor(Color.RED);
    textFrame.getTextFrameFormat().getThreeDFormat().setContourWidth(1.5);

    textFrame.getTextFrameFormat().getThreeDFormat().setDepth(3);

    textFrame.getTextFrameFormat().getThreeDFormat().setMaterial(MaterialPresetType.Plastic);

    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);
    textFrame.getTextFrameFormat().getThreeDFormat().getLightRig().setRotation(0, 0, 40);

    textFrame.getTextFrameFormat().getThreeDFormat().getCamera().setCameraType(CameraPresetType.PerspectiveContrastingRightFacing);
} finally {
    if (pres != null) pres.dispose();
}
```

Výsledek operace:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="info" %}} 
Aplikace 3D efektů na texty nebo jejich tvary a interakce mezi efekty jsou založeny na určitých pravidlech. 

Uvažujte scénu pro text a tvar, který text obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, na kterou je objekt umístěn. 

- When the scene is set for both the figure and the text, the figure scene gets the higher priority—the text scene is ignored. 
- When the figure lacks its own scene but has 3D representation, the text scene is used. 
- Otherwise—when the shape originally has no 3D effect—the shape is flat and the 3D effect only gets applied to the text. 

These descriptions are connected to the ThreeDFormat.getLightRig() and ThreeDFormat.getCamera() methods. 
{{% /alert %}} 

## **Použijte vnější stínové efekty na text**
Aspose.Slides pro Android pomocí Javy poskytuje třídy [**IOuterShadow**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioutershadow/) a [**IInnerShadow**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iinnershadow/) , které vám umožňují aplikovat stínové efekty na text obsažený v [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/). Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
2. Získejte referenci snímku pomocí jeho indexu.
3. Přidejte AutoShape typu Rectangle (obdélník) na snímek.
4. Získejte přístup k TextFrame spojenému s AutoShape.
5. Nastavte FillType AutoShape na NoFill.
6. Vytvořte instanci třídy OuterShadow
7. Nastavte BlurRadius stínu.
8. Nastavte Direction stínu
9. Nastavte Distance stínu.
10. Nastavte RectangleAlign na TopLeft.
11. Nastavte PresetColor stínu na Black.
12. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Získat referenci na snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu Obdélník
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidat TextFrame k obdélníku
    ashp.addTextFrame("Aspose TextBox");

    // Zakázat výplň tvaru v případě, že chceme získat stín textu
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Přidat vnější stín a nastavit všechny potřebné parametry
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Zapsat prezentaci na disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použijte vnitřní stínové efekty na tvary**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
2. Získejte referenci snímku.
3. Přidejte AutoShape typu Rectangle.
4. Povolit InnerShadowEffect.
5. Nastavte všechny potřebné parametry.
6. Nastavte ColorType na Scheme.
7. Nastavte Scheme Color.
8. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) .

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // Získat referenci na snímek
    ISlide slide = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu Obdélník
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 400, 300);
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Přidat TextFrame k obdélníku
    ashp.addTextFrame("Aspose TextBox");
    IPortion port = ashp.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormat pf = port.getPortionFormat();
    pf.setFontHeight(50);

    // Povolit efekt vnitřního stínu
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Nastavit všechny potřebné parametry
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Nastavit ColorType jako Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Nastavit barvu schématu
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Uložit prezentaci
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

### Můžu použít efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?
Ano, Aspose.Slides podporuje Unicode a funguje se všemi hlavními písmy a skripty. Efekty WordArt, jako stín, výplň a obrys, lze aplikovat nezávisle na jazyce, i když dostupnost písma a vykreslování může záviset na systémových fontech.

### Mohu aplikovat efekty WordArt na prvky master snímku?
Ano, můžete aplikovat efekty WordArt na tvary na hlavních snímcích, včetně zástupců titulku, zápatí nebo textu pozadí. Změny provedené v rozložení masteru se projeví ve všech přidružených snímcích.

### Ovlivňují efekty WordArt velikost souboru prezentace?
Mírně. Efekty WordArt, jako stíny, záře a gradientové výplně, mohou mírně navýšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

### Mohu zobrazit náhled výsledku efektů WordArt bez uložení prezentace?
Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí metody `getImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) nebo [ISlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islide/). To vám umožní zobrazit výsledek v paměti nebo na obrazovce před uložením či exportem celé prezentace.