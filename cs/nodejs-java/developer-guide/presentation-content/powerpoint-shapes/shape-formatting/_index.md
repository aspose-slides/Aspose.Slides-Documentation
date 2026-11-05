---
title: Formátování tvarů PowerPointu v JavaScriptu
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/nodejs-java/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- skicový efekt
- skicová čára tvaru
- formátovat styl spoje
- gradientní výplň
- výplň vzorem
- výplň obrázkem
- výplň texturou
- výplň plnou barvou
- průhlednost tvaru
- černobílé vykreslování tvaru
- stupňování šedi tvaru
- otáčet tvar
- 3d kvádrový efekt
- 3d otočný efekt
- resetovat formátování
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v JavaScriptu pomocí Aspose.Slides — nastavte výplň, čáru a styly efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro Node.js pomocí Javy vám umožňuje tato nastavení řídit programově, včetně průhlednosti, otáčení a 3D formátování.

![Možnosti formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro Node.js pomocí Javy poskytuje třídy a metody, které umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátovat čáry**

Použijte [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) k ovládání obrysu tvaru. Tento příklad vytváří nevyplněný obdélník s modrým, čárkovaným obrysem. [LineFormat.setStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setStyle) vybírá složenou čáru s tlustým a tenkým segmentem, zatímco [LineFormat.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setWidth) nastavuje šířku na 7 bodů a [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle) vybírá vzor čárkování.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavit vlastní vzory čar**

Použijte [LineFormat.setCustomDashPattern](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCustomDashPattern), když předdefinované styly čar neposkytují požadované délky čar a mezer, například pro značkové obrysy nebo technické diagramy. Při přiřazení vzoru se automaticky změní styl čáry na [LineDashStyle.Custom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/).

Položky pole se střídají mezi délkou čáry a mezerou, počínaje čárou. Každá hodnota je násobkem šířky čáry: `[4, 2]` při šířce 3 body vytváří čáru o délce 12 bodů a mezeru o délce 6 bodů. Používejte páry konečných, nezáporných hodnot k definování kompletních segmentů čáry a mezery. Příklad používá kladné hodnoty, aby byly všechny čáry i mezery viditelné.

Tento příklad vytváří pět modrých čar se stejnou délkou a plochými konci. První tři porovnávají vzory při šířce 3 body. Čtvrtá opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí délky čáry i mezery. Pátá přepíná z vlastního vzoru na plnou čáru.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];

    for (let i = 0; i < patterns.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setCapStyle(java.newByte(aspose.slides.LineCapStyle.Flat));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        let pattern = java.newArray("float", patterns[i]);
        line.getLineFormat().setCustomDashPattern(pattern);
    }

    // Vrátit poslední čáru na plný styl.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));

    presentation.save("custom_dash_patterns.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro návrat k předdefinovanému čárkovanému stylu místo toho předejte [LineDashStyle.Dash](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linedashstyle/) metodě [LineFormat.setDashStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setDashStyle). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čáry, širší čára s prvním vzorem a plná čára v PowerPointu](custom-dash-patterns.png)

### **Nastavit konce čáry**

Použijte [LineFormat.setCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setCapStyle) k nastavení konců otevřené čáry. Třída [LineCapStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linecapstyle/) poskytuje tři explicitní styly konců:

- `Flat`: Tah končí v koncovém bodě.
- `Round`: Polokruhový konec přesahuje koncový bod o polovinu šířky čáry.
- `Square`: Čtvercový konec přesahuje koncový bod o polovinu šířky čáry.

Třída také zahrnuje `NotDefined`, což znamená, že žádný styl konce není explicitně přiřazen.

Konce se liší od šipek, které přidávají symboly na konce čáry, a od spojů, které řídí rohy mezi segmenty čáry. Tento příklad vypíná šipky pomocí [LineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setBeginArrowheadStyle) a [LineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setEndArrowheadStyle), aby byly srovnávány pouze tvary konců.

Následující příklad vytváří tři jinak identické horizontální čáry, široké 20 bodů. Shora dolů používají ploché, kulaté a čtvercové konce. Jejich koncové body mají stejné vodorovné souřadnice; kulaté a čtvercové konce přesahují 10 bodů za každý koncový bod.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let capStyles = [aspose.slides.LineCapStyle.Flat, aspose.slides.LineCapStyle.Round, aspose.slides.LineCapStyle.Square];

    for (let i = 0; i < capStyles.length; i++) {
        let line = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        line.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Solid));
        line.getLineFormat().setCapStyle(java.newByte(capStyles[i]));
        line.getLineFormat().setBeginArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
        line.getLineFormat().setEndArrowheadStyle(java.newByte(aspose.slides.LineArrowheadStyle.None));
    }

    presentation.save("line_caps.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round** a **Square**.

![Ploché, kulaté a čtvercové konce na identických tlustých čarách v PowerPointu](line-caps.png)

## **Použít skicové efekty na čáry tvaru**

Skicový efekt způsobí, že čára tvaru vypadá ručně kreslená. Použijte [Shape.getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) pro přístup k nastavením čáry, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getSketchFormat) pro přístup k nastavením skicu a [SketchFormat.setSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#setSketchType) pro výběr hodnoty ze třídy [LineSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/).

Následující JavaScriptový kód ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linesketchtype/):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    let sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Hodnota vrácená metodou [SketchFormat.getSketchType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/sketchformat/#getSketchType) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozložení snímku, použijte [LineFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#getEffective), zavolejte `getSketchFormat` na vráceném objektu a poté zavolejte jeho metodu `getSketchType`. Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na prvním snímku a vypíše obě hodnoty:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    let lineFormat = shape.getLineFormat();
    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formátovat styly spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Styl spoje určuje, jak se dva úseky obrysu setkávají v rohu. Použijte **Round** pro zakulacené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spoje v prezentaci](join-style-powerpoint.png)

Tento příklad vytváří tři černé obdélníky s modrými obrysy širokými 15 bodů. Používá [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) k aplikaci hodnot miter, bevel a round ze třídy [LineJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/), aby porovnal, jak jsou rohy vykresleny.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let miterShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let bevelShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let roundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    bevelShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    roundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    bevelShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    roundShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    miterShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    bevelShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    roundShape.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Omezit miterové spoje u ostrých rohů**

Použijte [LineFormat.setMiterLimit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setMiterLimit) spolu s [LineFormat.setJoinStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lineformat/#setJoinStyle) nastaveným na [LineJoinStyle.Miter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/linejoinstyle/) k omezení, jak daleko může ostrý roh vyčnívat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spoje k šířce čáry. Například hodnota `8` povoluje délku miteru až osmkrát větší než šířka čáry; není to měření v bodech. Pokud by roh překročil limit, PowerPoint použije na tomto rohu zploštělý spoj. Větší limit umožňuje ostřejší body. Nastavení ovlivňuje pouze miterové spoje a jeho změna nemá viditelný efekt, když roh zůstává v rámci obou limitů.

Tento příklad vytváří dva identické, nevyplněné trojúhelníky s obrysy širokými 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník má šířku 80 bodů a výšku 160 bodů, což dává jeho hornímu rohu poměr délka miteru k šířce čáry přibližně `4,12`. V důsledku toho PowerPoint zploští levý vrchol a zachová pravý vrchol.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let miterLimits = [2, 8];

    for (let i = 0; i < miterLimits.length; i++) {
        let triangle = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 139));
        triangle.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
        triangle.getLineFormat().setMiterLimit(java.newFloat(miterLimits[i]));
    }

    presentation.save("miter_limits.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zploštělý vrchol s limitem miter 2 a špičatý vrchol s limitem miter 8 v PowerPointu](miter-limits.png)

## **Gradientní výplň**

Gradientní výplň míchá barvy přes tvar. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů od červené k fialové pomocí [FillFormat.getGradientFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getGradientFormat). Metoda [GradientStopCollection.addPresetColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientstopcollection/#addPresetColor) umístí barevné zastávky na 0 a 1, na začátek a konec gradientu. Vymazání existujících zastávek zajistí, že budou použity jen tyto dvě barvy.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0, aspose.slides.PresetColor.Red);

    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/nodejs-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl renderování, aniž byste měnili gradientní výplň uloženou v prezentaci.

### **Nastavit úhel lineárního gradientu**

Použijte [GradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle) k ovládání orientace výplně [GradientShape.Linear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/). Úhel se měří ve stupních a zvyšuje se po směru hodinových ručiček: `0` běží zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Podporovány jsou i zlomkové úhly. Konečné úhly mimo interval `[0, 360)` jsou normalizovány na jedno otočení; například `-45` se stane `315` a `360` se stane `0`.

Tento příklad vytváří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0,5` a `1`. Škálování je vypnuto, aby mohl být úhel porovnán nezávisle na proporcích obdélníků. Úhly, zleva doprava, jsou `0`, `45` a `90` v prvním řádku a `135`, `180` a `270` ve druhém řádku.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let angles = [0, 45, 90, 135, 180, 270];

    for (let i = 0; i < angles.length; i++) {
        let x = 30 + (i % 3) * 230;
        let y = 30 + Math.floor(i / 3) * 190;

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.False));
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu:

![Lineární gradienty při 0, 45 a 90 stupních v horním řádku a 135, 180 a 270 stupních ve spodním řádku](linear-gradient-angles.png)

### **Škálovat lineární gradient podle tvaru**

[GradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientScaled) přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/). Nastavte ji explicitně na `False`, aby úhel geometrického gradientu zůstal stejný při změně proporcí tvaru, nebo na `True`, aby se gradient škáloval se šířkou a výškou tvaru. Při zapnutém škálování se viditelný úhel může lišit od přiřazeného úhlu u nečtvercového tvaru.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako v porovnání úhlů. Levý sloupec používá `False`; pravý sloupec používá `True`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak výplň reaguje na změnu velikosti bez změny nastavení gradientu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    let scalingOptions = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.True];

    for (let column = 0; column < scalingOptions.length; column++) {
        for (let row = 0; row < 2; row++) {
            let x = 30 + column * 360;
            let y = row == 0 ? 30 : 150;

            let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

            let gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
            gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
            gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(java.newByte(scalingOptions[column]));

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu, s vypnutým škálováním vlevo a zapnutým vpravo:

![Široké a vysoké obdélníky s 45‑stupňovým gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

Při vypnutém škálování si šikmé barevné pásy zachovávají stejnou orientaci v obou obdélnících. Při zapnutém škálování se pásy roztahují s proporcemi tvaru. To pomáhá reprodukovat gradient šablony při úpravě tvaru na jinou velikost. Na čtverci zapnutí škálování nemění vzhled tohoto 45‑stupňového gradientu.

Oba nastavení – úhel i škálování – se vztahují na lineární gradienty. Neovlivňují výplně [GradientShape.Radial nebo GradientShape.Rectangle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientshape/).

### **Kombinovat úhel se směrem gradientu**

[GradientFormat.setGradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setGradientDirection) vybírá styl gradientu ze třídy [GradientDirection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientdirection/); není to náhrada za číselný úhel. Pro lineární gradient mohou styly rohu změnit oblast, na které jsou barvy rozloženy, aniž by se změnil úhel nastavený pomocí [setLinearGradientAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/gradientformat/#setLinearGradientAngle). Při porovnávání úhlů nebo škálování ponechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: přiřazení směru před nebo po úhlu nemění výsledek.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    for (let i = 0; i < 2; i++) {
        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));

        let gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0, java.getStaticFieldValue("java.awt.Color", "RED"));
        gradient.getGradientStops().add(java.newFloat(0.5), java.getStaticFieldValue("java.awt.Color", "GREEN"));
        gradient.getGradientStops().add(1, java.getStaticFieldValue("java.awt.Color", "BLUE"));
        gradient.setLinearGradientScaled(java.newByte(aspose.slides.NullableBool.True));

        if (i == 0) {
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(aspose.slides.GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Výplň vzorem**

Výplň vzorem aplikuje dvoubarevný design, například tečky, pruhy nebo šachovnici. Tento příklad používá [PatternFormat.setPatternStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#setPatternStyle) k výběru vzoru mřížky. [PatternFormat.getBackColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getBackColor) poskytuje světle šedé pozadí a [PatternFormat.getForeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/patternformat/#getForeColor) dodává žlutou barvu vzoru.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Obdélník s výplní vzorem](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje lokální obrázek a používá [Images.fromFile](https://reference.aspose.com/slides/nodejs-java/aspose.slides/images/#fromFile) k načtení do kolekce obrázků prezentace. Nastavení [PictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode) na režim dlaždicování opakuje obrázek v rámci obdélníku. Zdrojový obrázek použitý zde je zobrazen níže:

![Obrázek lotosu](lotus.png)

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit dlaždicovaný obrázek jako texturu a přizpůsobit chování dlaždicování, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastavuje režim obrázkové výplně – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Ovládá, zda je dlaždice převrácena vodorovně, svisle nebo v obou směrech.
- [setTileOffsetX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje svislé měřítko dlaždice v procentech.

Tento příklad vyžaduje lokální obrázek a konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/) tak, aby jej opakoval na 50 % původní velikosti. Posuny –32 bodů posunou dlaždice vodorovně i svisle; zarovnání vpravo dole a převracení v obou směrech určuje, jak je opakovaná textura uspořádána.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let firstSlide = presentation.getSlides().get_Item(0);

    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Možnosti dlaždicování](tile-options.png)

## **Plná barva výplně**

Plná výplň dává tvaru jednolitou barvu. Tento příklad používá [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) k výběru režimu plné výplně a přiřazuje žlutou barvu pomocí [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor), poté ukládá obdélník v prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tvar s plnou barvou výplně](solid-color-fill.png)

### **Kopírovat barvy se zachováním odkazů na motiv**

Použijte [ColorFormat.copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#copyFrom) k zkopírování definice barvy, včetně jejího typu barvy, odkazu na motiv a transformací. To je užitečné při přenosu výplňové barvy mezi tvary, které by měly i nadále sledovat motiv prezentace. Metoda kopíruje pouze barvu: nekopíruje typ výplně, obrys ani jiné formátování tvaru. Nastavte typ výplně cíle explicitně pomocí [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType).

Tento příklad vytváří tři obdélníky, zleva doprava: zdroj, kopii respektující motiv a pevnou RGB kopii. Zdroj používá [ColorFormat.setSchemeColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setSchemeColor) k odkazu na první akcentní barvu a přidává tón pomocí [ColorOperationCollection.add](https://reference.aspose.com/slides/nodejs-java/aspose.slides/coloroperationcollection/#add). RGB kopie používá efektivní výplňovou barvu zdroje, takže všechny tři vypadají zpočátku identicky. Volání [ColorFormat.setColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#setColor) nastaví pevnou RGB hodnotu a vymaže jakékoli existující transformace barvy.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 65, 105, 225));

    let source = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 40, 180, 140);
    let themeCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 240, 40, 180, 140);
    let rgbCopy = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 450, 40, 180, 140);

    for (let shape of [source, themeCopy, rgbCopy]) {
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    }

    let sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(aspose.slides.SchemeColor.Accent1);
    sourceColor.getColorTransform().add(aspose.slides.ColorTransformOperation.Tint, java.newFloat(0.75));

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    let before = slide.getImage(1, 1);
    try {
        before.save("color-copy-before.png", aspose.slides.ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Odkazy na motiv používají novou akcentní barvu; pevná hodnota RGB ne.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(java.newInstanceSync("java.awt.Color", 255, 69, 0));

    let after = slide.getImage(1, 1);
    try {
        after.save("color-copy-after.png", aspose.slides.ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Před změnou motivu všechny tři výplně odpovídají:

![Zdroj, copyFrom cíl a pevná RGB výplň se stejnou modrou barvou](color-copy-before.png)

Po změně motivu zdroj a kopie respektující motiv následují novou akcentní barvu a zachovají svůj tón. Pevná RGB kopie zůstává modrá:

![Zdroj a copyFrom cíl s oranžovými výplněmi, zatímco pevná RGB výplň zůstává modrá](color-copy-after.png)

Zkopírovaná definice je nezávislá na zdroji. Následná změna odkazu na motiv zdroje, přiřazení jiné barvy nebo přidání/odebrání jejích transformací nemění cíl. Změna motivu stále ovlivní oba tvary, protože každý nezávisle odkazuje na stejnou barvu motivu.

Uložení a opětovné otevření PPTX zachovává typ zkopírované barvy vrácený metodou [ColorFormat.getColorType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorType), odkaz na motiv a kolekci transformací vrácenou metodou [ColorFormat.getColorTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/#getColorTransform); neprovádí plochou konverzi na RGB.

Při kopírování mezi různými kontexty motivů, například mezi prezentacemi s různými akcentními paletami, se zkopírovaný odkaz rozpozná vůči motivu cíle. Stejný odkaz a transformace tak mohou vést k odlišnému viditelnému odstínu. Viz [Presentation Theme](/slides/cs/nodejs-java/presentation-theme/) pro více informací o konfiguraci barev motivu.

## **Použít pozadí snímku jako výplň tvaru**

Použijte [AutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#setUseBackgroundFill), když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nastavte typ výplně pomocí [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) na [FillType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) nejprve, abyste odstranili jakoukoli explicitní výplň. S tímto kombinací tvar používá pozadí snímku místo své vlastní výplně. Pouze nastavení příznaku neodstraní existující explicitní výplň.

To se liší od [FillType.NoFill](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/): výplň pozadím zakrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň ponechává tyto objekty viditelné. Gradient zůstává zarovnán k snímku místo toho, aby se restartoval uvnitř každého tvaru.

Následující příklad vytváří hlavní pozadí zděděné snímkem a umisťuje purpurovou pásku za tři obdélníky. Levý obdélník používá pozadí, prostřední nemá výplň a pravý přepíná z výplně pozadí na explicitní oranžovou výplň.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, aspose.slides.SlideSizeScaleType.DoNotScale);
    let slide = presentation.getSlides().get_Item(0);

    // Zdědit gradient z hlavního motivu.
    slide.getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    slide.getLayoutSlide().getBackground().setType(java.newByte(aspose.slides.BackgroundType.NotDefined));
    let background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(java.newByte(aspose.slides.BackgroundType.OwnBackground));
    background.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    let gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, java.newInstanceSync("java.awt.Color", 0, 0, 139));
    gradient.getGradientStops().add(1, java.newInstanceSync("java.awt.Color", 135, 206, 250));

    // Nejprve přidejte tento objekt, aby se zobrazil za obdélníky.
    let band = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    band.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "MAGENTA"));
    band.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let backgroundShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    backgroundShape.setUseBackgroundFill(true);

    let noFillShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    let explicitShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NotDefined));
    explicitShape.setUseBackgroundFill(true);

    // Zakázat výplň pozadí před aplikací explicitní výplně.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    explicitShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    presentation.save("background_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek, zleva doprava: **výplň pozadí**, **žádná výplň** a **explicitní výplň**. Purpurová páska je skryta levým a pravým obdélníkem, ale zůstává viditelná skrze prostřední obdélník.

![Výplň pozadí, žádná výplň a explicitní oranžová výplň přes purpurovou pásku](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozložení. Tvar používá rozlišené pozadí snímku; příklad ponechává jak snímek, tak rozložení bez definovaného pozadí, takže jej poskytuje hlavní motiv.

## **Nastavit průhlednost**

Pro plnou výplň řídí alfa komponenta barvy neprůhlednost: 0 je zcela průhledná a 255 zcela neprůhledná. Tento příklad používá alfa hodnotu 128 pro žlutý obdélník, čímž je přibližně 50 % průhledný, takže pod ním ležící obdélník zůstává viditelný. Barva je přiřazena pomocí [FillFormat.getSolidFillColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#getSolidFillColor).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otočit tvary**

Použijte [Shape.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setRotation) k otočení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otáčí obdélník o 5 stupňů po směru hodinových ručiček a ukládá prezentaci.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidat 3D kvádrové efekty**

Použijte [Shape.getThreeDFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getThreeDFormat) k tomu, aby tvar získal hloubku a kvádrové hrany. Tento příklad vytváří zelenou elipsu s oranžovým obrysem, používá [ThreeDFormat.setDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#setDepth) k nastavení hloubky na 4 body a aplikuje kruhový horní kvádr s šířkou a výškou 6 bodů pomocí [ThreeDFormat.getBevelTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/threedformat/#getBevelTop). Přední ortografická kamera a trojibodové osvětlení zpřehledňují kvádr.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![3D kvádrový efekt](3D-bevel-effect.png)

## **Přidat 3D otočné efekty**

3D pohled tvaru je řízen nastavením kamery. Tento příklad používá [Camera.setRotation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setRotation) s úhly latitude, longitude a revoluce 40, 35 a 20 stupňů. Vybere izometrickou kameru pomocí [Camera.setCameraType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/camera/#setCameraType) a vyvážené osvětlení pomocí [LightRig.setLightType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/lightrig/#setLightType), poté uloží formátovaný obdélník.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![3D otočný efekt](3D-rotation-effect.png)

## **Řídit černobílé vykreslování tvarů**

Metoda [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Nezpřístupňuje černobílý režim sama o sobě a nemění výplň, obrys ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` nechá aplikaci pro vykreslování zvolit konverzi, `Gray` a `LightGray` používají šedé zbarvení, `BlackWhite` používá pouze černou a bílou, `Black` a `White` vynutí jednosloučnou barvu, `Color` zachovává normální zbarvení a `Hidden` vynechává tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Tento příklad vytváří oranžový obdélník a používá [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) k výběru šedého zbarvení. Uložený tvar si zachová oranžovou výplň pro normální barevné zobrazení a požaduje šedé zbarvení od aplikací, které respektují nastavení černobílého zobrazení:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V normálním barevném režimu obdélník zachovává oranžovou výplň. V černobílém pracovním postupu používá šedé zbarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat barevný snímek a současně definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovit formátování**

Použijte [Slide.reset](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/#reset) k obnovení pozice, velikosti a formátování zástupných objektů snímku z odpovídajících zástupných objektů rozložení. Tento příklad vyžaduje existující prezentaci s propojenými zástupnými objekty rozložení a resetuje každý snímek před uložením. Tvary bez odpovídajících zástupných objektů rozložení nejsou resetovány.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Zda formátování tvaru ovlivňuje konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají jen málo data ve srovnání s vloženými obrázky a médii. Výplně obrázků mohou zvýšit velikost souboru, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte každé klíčové vlastnosti formátování tvaru – výplně, čáry a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což zjednodušuje správu stylů později.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte stylované tvary, které potřebujete, a znovu použijte jejich formátování kdekoliv je to nutné.