---
title: Vytvořte a aplikujte WordArt efekty v Javě
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
- efekt zobrazení
- efekt záře
- transformace WordArt
- 3D efekt
- efekt vnějšího stínu
- efekt vnitřního stínu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte WordArt efekty v Aspose.Slides pro Javu. Tento podrobný návod pomáhá vývojářům vylepšit prezentace profesionálním textem v Javě."
---
## **Přehled**

Efekty WordArt vám umožňují přidávat vizuálně atraktivní, stylizovaný text do vašich prezentací PowerPoint. S Aspose.Slides mohou vývojáři programově vytvářet, přizpůsobovat a spravovat WordArt stejně jako v Microsoft PowerPoint – aniž by bylo potřeba mít nainstalovaný Office. Tento článek poskytuje přehled práce s WordArt, včetně toho, jak aplikovat textové transformace, výplně, obrysy, stíny a další možnosti formátování, aby byl obsah vaší prezentace výražnější a poutavější. WordArt vám umožňuje zacházet s textem jako s grafickým objektem. Skládá se z efektů nebo speciálních úprav aplikovaných na text, aby byl atraktivnější nebo výraznější.

## **Vytvoření jednoduché šablony WordArt a její použití na text**

**Použití Aspose.Slides** 

Nejprve vytvoříme jednoduchý text pomocí tohoto Java kódu: 

``` java
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
Nyní nastavíme výšku fontu textu na větší hodnotu, aby byl efekt viditelnější, pomocí tohoto kódu:

``` java 
FontData fontData = new FontData("Arial Black");
portion.getPortionFormat().setLatinFont(fontData);
portion.getPortionFormat().setFontHeight(36);
```

**Použití Microsoft PowerPoint**

Přejděte do nabídky efektů WordArt v Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

V pravém menu můžete vybrat předdefinovaný efekt WordArt. V levém menu můžete specifikovat nastavení nového WordArt. 

Toto jsou některé z dostupných parametrů nebo možností:

![todo:image_alt_text](image-20200930114015-3.png)

**Použití Aspose.Slides**

Zde použijeme barvu vzoru [SmallGrid](https://reference.aspose.com/slides/cs/java/com.aspose.slides/PatternStyle#SmallGrid) na text a přidáme černý ohraničení textu o šířce 1 pomocí tohoto kódu:

``` java 
portion.getPortionFormat().getFillFormat().setFillType(FillType.Pattern);
portion.getPortionFormat().getFillFormat().getPatternFormat().getForeColor().setColor(Color.ORANGE);
portion.getPortionFormat().getFillFormat().getPatternFormat().getBackColor().setColor(Color.WHITE);
portion.getPortionFormat().getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.SmallGrid);

portion.getPortionFormat().getLineFormat().getFillFormat().setFillType(FillType.Solid);
portion.getPortionFormat().getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
```

Výsledný text:

![todo:image_alt_text](image-20200930114108-4.png)

## **Použití dalších efektů WordArt**

**Použití Microsoft PowerPoint**

V rozhraní programu můžete tyto efekty aplikovat na text, textový blok, tvar nebo podobný prvek:

![todo:image_alt_text](image-20200930114129-5.png)

Například efekty Stín, Odraz a Záření lze aplikovat na text; efekty 3D Formát a 3D Rotace lze aplikovat na textový blok; vlastnost Měkké hrany lze aplikovat na objekt tvaru (stále má efekt, když není nastavena vlastnost 3D Formát).

### **Aplikace stínových efektů**

Zde zamýšlíme nastavit vlastnosti vztahující se pouze na text. Stínový efekt na text aplikujeme pomocí tohoto Java kódu:

``` java
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
```

API Aspose.Slides podporuje tři typy stínů: OuterShadow, InnerShadow a PresetShadow. 

S PresetShadow můžete na text aplikovat stín (použitím předdefinovaných hodnot). 

**Použití Microsoft PowerPoint**

V PowerPointu můžete použít jeden typ stínu. Zde je příklad:

![todo:image_alt_text](image-20200930114225-6.png)

**Použití Aspose.Slides**

Aspose.Slides ve skutečnosti umožňuje aplikovat dva typy stínů najednou: InnerShadow a PresetShadow.

**Poznámky:**

- Když jsou použity OuterShadow a PresetShadow společně, aplikuje se pouze efekt OuterShadow. 
- Pokud jsou OuterShadow a InnerShadow použity současně, výsledný nebo aplikovaný efekt závisí na verzi PowerPointu. Například v PowerPointu 2013 se efekt zdvojnásobí. V PowerPointu 2007 se aplikuje efekt OuterShadow. 

### **Aplikace zobrazení na texty**

Přidáme zobrazení k textu pomocí tohoto ukázkového kódu v Javě:

``` java
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
```

### **Aplikace efektu záře na texty**

Použijeme efekt záře na text, aby vynikl nebo se leskl, pomocí tohoto kódu:

``` java
portion.getPortionFormat().getEffectFormat().enableGlowEffect();
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().setR((byte)255);
portion.getPortionFormat().getEffectFormat().getGlowEffect().getColor().getColorTransform().add(ColorTransformOperation.SetAlpha, 0.54f);
portion.getPortionFormat().getEffectFormat().getGlowEffect().setRadius(7);
```

Výsledek operace:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 

Můžete změnit parametry pro stín, zobrazení a záři. Vlastnosti efektů se nastavují na každou část textu zvlášť. 

{{% /alert %}} 

### **Použití transformací ve WordArt**

Použijeme vlastnost Transform (obsaženou v celém bloku textu) pomocí tohoto kódu:
``` java 
textFrame.getTextFrameFormat().setTransform(TextShapeType.ArchUpPour);
```

Výsledek:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 

Jak Microsoft PowerPoint, tak Aspose.Slides pro Java poskytují určitý počet předdefinovaných typů transformací. 

{{% /alert %}} 

**Použití PowerPoint**

Pro přístup k předdefinovaným typům transformací přejděte: **Formát** -> **TextEffect** -> **Transform**

**Použití Aspose.Slides**

Pro výběr typu transformace použijte výčet TextShapeType. 

### **Aplikace 3D efektů na texty a tvary**

Nastavíme 3D efekt na textový tvar pomocí tohoto ukázkového kódu:

``` java
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
```

Výsledný text a jeho tvar:

![todo:image_alt_text](image-20200930114816-9.png)

Aplikujeme 3D efekt na text pomocí tohoto Java kódu:

``` java
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
```

Výsledek operace:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 

Použití 3D efektů na texty nebo jejich tvary a interakce mezi efekty jsou založeny na určitých pravidlech.

Zvažte scénu pro text a tvar, který text obsahuje. 3D efekt zahrnuje 3D reprezentaci objektu a scénu, na kterou je objekt umístěn.

- Když je scéna nastavena jak pro tvar, tak pro text, má scéna tvaru vyšší prioritu – scéna textu je ignorována.
- Když tvar nemá vlastní scénu, ale má 3D reprezentaci, použije se scéna textu.
- Jinak – pokud tvar původně nemá 3D efekt – je tvar plochý a 3D efekt se aplikuje jen na text.

Tyto popisy souvisejí s metodami ThreeDFormat.getLightRig() a ThreeDFormat.getCamera().

{{% /alert %}} 

## **Použití vnějšího stínu na texty**
Aspose.Slides pro Java poskytuje třídy [**IOuterShadow**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioutershadow/) a [**IInnerShadow**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iinnershadow/), které umožňují aplikovat stínové efekty na text obsažený v [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/). Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte referenci na snímek pomocí jeho indexu.
3. Přidejte k snímku AutoShape typu Obdélník.
4. Získejte přístup k TextFrame spojenému s AutoShape.
5. Nastavte vlastnost FillType AutoShape na NoFill.
6. Vytvořte instanci třídy OuterShadow.
7. Nastavte BlurRadius stínu.
8. Nastavte Direction (směr) stínu.
9. Nastavte Distance (vzdálenost) stínu.
10. Nastavte RectanglelAlign na TopLeft.
11. Nastavte PresetColor stínu na Black.
12. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

Tento ukázkový kód v Javě — implementace výše uvedených kroků — ukazuje, jak aplikovat vnější stínový efekt na text:

```java
Presentation pres = new Presentation();
try {
    // Získat referenci na snímek
    ISlide sld = pres.getSlides().get_Item(0);

    // Přidat AutoShape typu Obdélník
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // Přidat TextFrame k obdélníku
    ashp.addTextFrame("Aspose TextBox");

    // Zakázat výplň tvaru pro případ, že chceme získat stín textu
    ashp.getFillFormat().setFillType(FillType.NoFill);

    // Přidat vnější stín a nastavit všechny potřebné parametry
    ashp.getEffectFormat().enableOuterShadowEffect();
    IOuterShadow shadow = ashp.getEffectFormat().getOuterShadowEffect();
    shadow.setBlurRadius(4.0);
    shadow.setDirection(45);
    shadow.setDistance(3);
    shadow.setRectangleAlign(RectangleAlignment.TopLeft);
    shadow.getShadowColor().setPresetColor(PresetColor.Black);

    //Uložit prezentaci na disk
    pres.save("pres_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Použití vnitřního stínu na tvary**
Proveďte následující kroky:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation).
2. Získejte referenci na snímek.
3. Přidejte AutoShape typu Obdélník.
4. Povolte InnerShadowEffect.
5. Nastavte všechny potřebné parametry.
6. Nastavte ColorType na Scheme.
7. Nastavte Scheme Color.
8. Uložte prezentaci jako soubor [PPTX](https://docs.fileformat.com/presentation/pptx/) file.

Tento ukázkový kód (na základě výše uvedených kroků) ukazuje, jak v Javě přidat spojku mezi dva tvary:

```java
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

    // Povolit InnerShadowEffect
    IEffectFormat ef = pf.getEffectFormat();
    ef.enableInnerShadowEffect();

    // Nastavit všechny potřebné parametry
    ef.getInnerShadowEffect().setBlurRadius(8.0);
    ef.getInnerShadowEffect().setDirection(90.0F);
    ef.getInnerShadowEffect().setDistance(6.0);
    ef.getInnerShadowEffect().getShadowColor().setB((byte)189);

    // Nastavit ColorType jako Scheme
    ef.getInnerShadowEffect().getShadowColor().setColorType(ColorType.Scheme);

    // Nastavit Scheme Color
    ef.getInnerShadowEffect().getShadowColor().setSchemeColor(SchemeColor.Accent1);

    // Uložit prezentaci
    pres.save("WordArt_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené dotazy**

**Mohu použít efekty WordArt s různými písmy nebo skripty (např. arabština, čínština)?**

Ano, Aspose.Slides podporuje Unicode a funguje se všemi hlavními písmy a skripty. Efekty WordArt, jako jsou stín, výplň a obrys, lze aplikovat bez ohledu na jazyk, i když dostupnost fontů a jejich vykreslování může záviset na systémových fontech.

**Mohu aplikovat efekty WordArt na prvky master snímku?**

Ano, můžete aplikovat efekty WordArt na tvary v master snímcích, včetně zástupců titulů, zápatí nebo textu na pozadí. Změny provedené v rozložení masteru se projeví ve všech přidružených snímcích.

**Ovlivňují efekty WordArt velikost souboru prezentace?**

Mírně. Efekty WordArt, jako jsou stíny, záře a gradientové výplně, mohou mírně zvětšit velikost souboru kvůli přidaným metadatům formátování, ale rozdíl je obvykle zanedbatelný.

**Mohu si prohlédnout výsledek efektů WordArt bez uložení prezentace?**

Ano, můžete vykreslit snímky obsahující WordArt do obrázků (např. PNG, JPEG) pomocí metody `getImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ishape/) nebo [ISlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islide/). To vám umožní náhled výsledku v paměti nebo na obrazovce před uložením či exportem celé prezentace.