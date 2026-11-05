---
title: Formátování tvarů PowerPointu na Androidu
linktitle: Formátování tvaru
type: docs
weight: 20
url: /cs/androidjava/shape-formatting/
keywords:
- formátování tvaru
- formátování čáry
- skicovací efekt
- skicovat čáru tvaru
- formátování stylu spojení
- gradientová výplň
- vyplnění vzorem
- obrázková výplň
- texturová výplň
- plná barva výplně
- průhlednost tvaru
- černobílé vykreslení tvaru
- stupně šedi vykreslení tvaru
- otočení tvaru
- 3D zkosený efekt
- 3D otáčecí efekt
- obnovení formátování
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak na Androidu formátovat tvary PowerPointu pomocí Aspose.Slides — nastavit výplň, čáru a styly efektů pro soubory PPT a PPTX s přesností a úplnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro Android pomocí Javy vám umožňuje řídit tato nastavení programově, včetně průhlednosti, otočení a 3D formátování.

![Možnosti formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro Android pomocí Javy poskytuje rozhraní a metody, které vám umožňují formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) k řízení obrysu tvaru. Tento příklad vytvoří nevyplněný obdélník s modrým, přerušovaným obrysem. [ILineFormat.setStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setStyle-byte-) vybere složenou čáru tlustá‑tenká, zatímco [ILineFormat.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setWidth-double-) nastaví její šířku na 7 bodů a [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-) vybere vzor přerušení.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavení vlastních vzorů přerušení čáry**

Použijte [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCustomDashPattern-float---) když předdefinované styly čar neposkytují požadované délky čar a mezer, například pro značkové obrysy nebo technické diagramy. Přiřazením vzoru se automaticky změní styl přerušení čáry na [LineDashStyle.Custom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/).

Položky pole střídavě představují délky čáry a mezery, počínaje čárou. Každá hodnota je násobkem šířky čáry: `{ 4, 2 }` při šířce 3 body vytváří čáru o délce 12 bodů následovanou mezerou o délce 6 bodů. Používejte dvojice konečných, nezáporných hodnot k definování kompletních úseků čáry a mezery. Příklad používá kladné hodnoty, aby byla každá čára i mezera viditelná.

Tento příklad vytvoří pět modrých čar se stejnou délkou a plochými konci. První tři porovnávají vzory při šířce 3 body. Čtvrtá opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí jak délky čar, tak mezer. Pátá přepíná z vlastního vzoru na plnou čáru.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(600, 300, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[][] patterns = {
        { 4, 2 },
        { 1, 2 },
        { 6, 2, 1, 2 },
        { 4, 2 },
        { 4, 2 }
    };

    for (int i = 0; i < patterns.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
        line.getLineFormat().setWidth(i == 3 ? 6 : 3);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setCapStyle(LineCapStyle.Flat);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setCustomDashPattern(patterns[i]);
    }

    // Vrátit poslední čáru na plný styl.
    slide.getShapes().get_Item(4).getLineFormat().setDashStyle(LineDashStyle.Solid);

    presentation.save("custom_dash_patterns.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro návrat k předdefinovanému přerušovanému stylu předejte [LineDashStyle.Dash](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) metodě [ILineFormat.setDashStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setDashStyle-byte-). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory přerušení, širší čára používající první vzor a plná čára v PowerPointu](custom-dash-patterns.png)

### **Nastavení koncových tvarů čáry**

Použijte [ILineFormat.setCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setCapStyle-byte-) k nastavení konců otevřené čáry. Třída [LineCapStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linecapstyle/) poskytuje tři explicitní styly konců:

- `Flat`: Čára končí na koncovém bodě.
- `Round`: Polokruhový konec přesahuje za koncový bod o polovinu šířky čáry.
- `Square`: Čtvercový konec přesahuje za koncový bod o polovinu šířky čáry.

Třída také obsahuje `NotDefined`, což znamená, že žádný styl konce není explicitně přiřazen.

Konce se liší od šipek, které přidávají symboly na konce čáry, a od spojů, které řídí rohy mezi segmenty čáry. Tento příklad zakazuje šipky pomocí [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) a [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-), aby byly porovnány pouze tvary konců.

Následující příklad vytvoří tři jinak identické vodorovné čáry, široké 20 bodů. Shora dolů používají ploché, kulaté a čtvercové konce. Jejich koncové body mají stejné horizontální souřadnice; kulaté a čtvercové konce přesahují o 10 bodů za každý koncový bod.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        line.getLineFormat().setDashStyle(LineDashStyle.Solid);
        line.getLineFormat().setCapStyle(capStyles[i]);
        line.getLineFormat().setBeginArrowheadStyle(LineArrowheadStyle.None);
        line.getLineFormat().setEndArrowheadStyle(LineArrowheadStyle.None);
    }

    presentation.save("line_caps.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round** a **Square**.

![Ploché, kulaté a čtvercové konce na identických silných čárach v PowerPointu](line-caps.png)

## **Použití skicovacích efektů na čáry tvarů**

Skicovací efekt způsobí, že čára tvaru vypadá ručně kreslená. Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) k získání nastavení čáry, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getSketchFormat--) k získání nastavení skicu, a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#setSketchType-int-) k výběru hodnoty ze třídy [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/).

Následující kód v jazyce Java ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();
    sketchFormat.setSketchType(LineSketchType.Curved);
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Hodnota vrácená metodou [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/#getSketchType--) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavní snímku nebo rozložení snímku, použijte [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#getEffective--), přistupte k [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--), a přečtěte [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na prvním snímku a vypíše obě hodnoty:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    ILineFormat lineFormat = shape.getLineFormat();
    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Styl spojení určuje, jak se dva úseky obrysu setkají v rohu. Použijte **Round** pro zaoblené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Tento příklad vytvoří tři černé obdélníky s modrými obrysy o šířce 15 bodů. Používá [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) aby aplikoval hodnoty miter, bevel a round ze [LineJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/), a porovnal, jak jsou rohy vykresleny.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape miterShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape bevelShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape roundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    miterShape.getFillFormat().setFillType(FillType.Solid);
    miterShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    bevelShape.getFillFormat().setFillType(FillType.Solid);
    bevelShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    roundShape.getFillFormat().setFillType(FillType.Solid);
    roundShape.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    miterShape.getLineFormat().setWidth(15);
    bevelShape.getLineFormat().setWidth(15);
    roundShape.getLineFormat().setWidth(15);

    miterShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    miterShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    bevelShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    bevelShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    roundShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    roundShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    miterShape.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    bevelShape.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    roundShape.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    miterShape.getTextFrame().setText("Miter Join Style");
    bevelShape.getTextFrame().setText("Bevel Join Style");
    roundShape.getTextFrame().setText("Round Join Style");

    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Omezení Miter spojení u ostrých rohů**

Použijte [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setMiterLimit-float-) spolu s [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/#setJoinStyle-byte-) nastaveným na [LineJoinStyle.Miter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linejoinstyle/) k omezení, jak daleko může ostrý roh vystupovat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spojení k šířce čáry. Například hodnota `8` umožňuje délku miter až osm násobků šířky čáry; nejde o měření v bodech. Pokud by roh překročil limit, PowerPoint použije zkosený spoj v tomto rohu. Větší limit umožňuje ostřejší body. Nastavení ovlivňuje pouze miter spojení a jeho změna nemá viditelný efekt, pokud roh zůstává v rámci limitu.

Tento příklad vytvoří dva identické, nevyplněné trojúhelníky s obrysy o šířce 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník je široký 80 bodů a vysoký 160 bodů, což dává jeho hornímu rohu poměr délka miter / šířka čáry přibližně `4.12`. V důsledku toho PowerPoint zakosí levý vrchol a zachová pravý vrchol.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 320, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] miterLimits = new float[] { 2f, 8f };

    for (int i = 0; i < miterLimits.length; i++) {
        IAutoShape triangle = slide.getShapes().addAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
        triangle.getFillFormat().setFillType(FillType.NoFill);
        triangle.getLineFormat().setWidth(20);
        triangle.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zkosený vrchol s limitem miter 2 a špičatý vrchol s limitem miter 8 v PowerPointu](miter-limits.png)

## **Gradientové výplně**

Gradientová výplň míchá barvy přes tvar. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů od červené po fialovou pomocí [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getGradientFormat--). Metoda [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) umístí barvy zastávek na 0 a 1, na začátek a konec gradientu. Vymazání existujících zastávek zajišťuje, že budou použity jen tyto dvě barvy.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
    shape.getFillFormat().getGradientFormat().setLinearGradientAngle(45);
    shape.getFillFormat().getGradientFormat().getGradientStops().clear();
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0f, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0.0f, PresetColor.Red);

    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Elipsa s gradientovou výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste změnili gradientovou výplň uloženou v prezentaci.

### **Nastavení úhlu lineárního gradientu**

Použijte [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) k řízení orientace výplně [GradientShape.Linear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/). Úhel se měří ve stupních a roste ve směru hodinových ručiček: `0` jde zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Podporují se zlomkové úhly. Konečné úhly mimo `[0, 360)` jsou normalizovány na jednu otáčku; například `-45` se stane `315` a `360` se stane `0`.

Tento příklad vytvoří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0.5` a `1`. Škálování je zakázáno, aby bylo možné úhel porovnat nezávisle na proporcích obdélníků. Úhly zleva doprava jsou `0`, `45` a `90` v prvním řádku a `135`, `180` a `270` ve druhém řádku.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    float[] angles = new float[] { 0, 45, 90, 135, 180, 270 };

    for (int i = 0; i < angles.length; i++) {
        int x = 30 + (i % 3) * 230;
        int y = 30 + (i / 3) * 190;

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 200, 150);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.False);
        gradient.setLinearGradientAngle(angles[i]);
    }

    presentation.save("linear_gradient_angles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu:

![Lineární gradienty při 0°, 45° a 90° v horním řádku a 135°, 180° a 270° ve spodním řádku](linear-gradient-angles.png)

### **Škálování lineárního gradientu s tvarem**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/). Nastavte ji explicitně na `False`, aby se úhel geometrického gradientu zachoval při změně proporcí tvaru, nebo na `True`, aby se gradient škáloval podle šířky a výšky tvaru. Při povoleném škálování se viditelný úhel může lišit od přiřazeného úhlu u nečtvercového tvaru.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako při porovnání úhlů. Levý sloupec používá `False`; pravý sloupec používá `True`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak výplň reaguje na změnu velikosti bez změny nastavení gradientu.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 460, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] scalingOptions = new byte[] { NullableBool.False, NullableBool.True };

    for (int column = 0; column < scalingOptions.length; column++) {
        for (int row = 0; row < 2; row++) {
            int x = 30 + column * 360;
            int y = row == 0 ? 30 : 150;

            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, y, 300, 90);
            shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
            shape.getFillFormat().setFillType(FillType.Gradient);

            IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
            gradient.setGradientShape(GradientShape.Linear);
            gradient.getGradientStops().clear();
            gradient.getGradientStops().add(0f, Color.RED);
            gradient.getGradientStops().add(0.5f, Color.GREEN);
            gradient.getGradientStops().add(1f, Color.BLUE);
            gradient.setLinearGradientAngle(45);
            gradient.setLinearGradientScaled(scalingOptions[column]);

            if (row == 1) {
                shape.setWidth(90);
                shape.setHeight(280);
            }
        }
    }

    presentation.save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu, se škálováním vypnutým vlevo a zapnutým vpravo:

![Široké a vysoké obdélníky s 45° gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

S vypnutým škálováním si úhlopříčné barevné pásy zachovávají stejnou orientaci v obou obdélnících. Při zapnutém škálování se pásy natahují podle proporcí tvaru. To pomáhá reprodukovat gradient šablony při úpravě tvaru na jinou velikost. U čtverce zapnutí škálování nemění vzhled tohoto `45`‑stupňového gradientu.

Jak úhel, tak nastavení škálování se vztahují na lineární gradienty. Neovlivňují výplně [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientshape/).

### **Kombinace úhlu se směrem gradientu**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setGradientDirection-int-) vybírá styl gradientu ze třídy [GradientDirection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/gradientdirection/). Není to náhrada za číselný úhel. U lineárního gradientu mohou styly rohů změnit oblast, na kterou jsou barvy rozloženy, aniž by se změnil úhel přiřazený pomocí [setLinearGradientAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Při porovnávání úhlů nebo škálování ponechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: přiřazení směru před nebo po úhlu nezmění výsledek.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (int i = 0; i < 2; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        shape.getFillFormat().setFillType(FillType.Gradient);

        IGradientFormat gradient = shape.getFillFormat().getGradientFormat();
        gradient.setGradientShape(GradientShape.Linear);
        gradient.getGradientStops().clear();
        gradient.getGradientStops().add(0f, Color.RED);
        gradient.getGradientStops().add(0.5f, Color.GREEN);
        gradient.getGradientStops().add(1f, Color.BLUE);
        gradient.setLinearGradientScaled(NullableBool.True);

        if (i == 0) {
            gradient.setGradientDirection(GradientDirection.FromCorner1);
            gradient.setLinearGradientAngle(30);
        } else {
            gradient.setLinearGradientAngle(30);
            gradient.setGradientDirection(GradientDirection.FromCorner1);
        }
    }

    presentation.save("linear_gradient_direction.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Vyplnění vzorem**

Vyplnění vzorem použije dvoubarevný návrh, jako jsou tečky, pruhy nebo šachovnice. Tento příklad používá [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) k výběru vzoru mřížky. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getBackColor--) dodává světle šedé pozadí a [IPatternFormat.getForeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipatternformat/#getForeColor--) dodává žlutou barvu vzoru.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.rgb(192, 192, 192));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Obdélník s výplní vzorem](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje lokální obrázek a používá [Images.fromFile](https://reference.aspose.com/slides/androidjava/com.aspose.slides/images/#fromFile-java.lang.String-) k načtení do kolekce obrázků prezentace. Nastavení [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) na dlaždicový režim opakuje obrázek uvnitř obdélníku. Zdrojový obrázek použitý zde je zobrazen níže:

![Obrázek lotosu](lotus.png)

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    shape.getFillFormat().setFillType(FillType.Picture);
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    IImage image = Images.fromFile("lotus.png");
    IPPImage picture;
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        image.dispose();
    }
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit dlaždicový obrázek jako texturu a přizpůsobit chování dlaždic, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastavuje režim obrázkové výplně — buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Řídí, zda je dlaždice převrácena horizontálně, vertikálně, nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastavuje horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastavuje vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje horizontální měřítko dlaždice jako procento.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje vertikální měřítko dlaždice jako procento.

Tento příklad vyžaduje lokální obrázek a konfiguruje [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) tak, aby jej opakoval ve 50 % původní velikosti. Posuny o −32 bodů posunou dlaždice horizontálně i vertikálně; zarovnání dolní pravé a převrácení v obou směrech určují, jak je opakovaná textura uspořádána.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
    shape.getFillFormat().setFillType(FillType.Picture);

    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage;
    try {
        presentationImage = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Možnosti dlaždic](tile-options.png)

## **Plná barva výplně**

Plná výplň dává tvaru jednu jednotnou barvu. Tento příklad používá [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) k výběru režimu plné výplně a přiřadí žlutou barvu pomocí [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--), pak uloží obdélník do prezentace.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Tvar s plnou barvou výplně](solid-color-fill.png)

### **Kopírování barev při zachování odkazů na motiv**

Použijte [IColorFormat.copyFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#copyFrom-com.aspose.slides.IColorFormat-) k tomu, abyste zkopírovali definici barvy, včetně jejího typu, odkazu na motiv a transformací. To je užitečné při přenosu barvy výplně mezi tvary, které by měly nadále sledovat motiv prezentace. Metoda kopíruje jen barvu: nekopíruje typ výplně, obrys ani jiné formátování tvaru. Nastavte explicitně typ výplně cíle pomocí [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-).

Tento příklad vytvoří tři obdélníky, zleva doprava: zdroj, kopii respektující motiv a pevnou RGB kopii. Zdroj používá [IColorFormat.setSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setSchemeColor-int-) k odkazování na první akcentní barvu a přidává odstín pomocí [IColorOperationCollection.add](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icoloroperationcollection/#add-int-float-). RGB kopie používá efektivní barvu výplně ze zdroje, takže všechny tři vypadají na začátku identicky. Volání [IColorFormat.setColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#setColor-java.lang.Integer-) nastaví pevnou RGB hodnotu a vymaže existující transformace barvy.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(660, 220, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(65, 105, 225));

    IAutoShape source = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
    IAutoShape themeCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
    IAutoShape rgbCopy = slide.getShapes().addAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

    for (IAutoShape shape : new IAutoShape[] { source, themeCopy, rgbCopy }) {
        shape.getFillFormat().setFillType(FillType.Solid);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    }

    IColorFormat sourceColor = source.getFillFormat().getSolidFillColor();
    sourceColor.setSchemeColor(SchemeColor.Accent1);
    sourceColor.getColorTransform().add(ColorTransformOperation.Tint, 0.75f);

    themeCopy.getFillFormat().getSolidFillColor().copyFrom(sourceColor);
    rgbCopy.getFillFormat().getSolidFillColor().setColor(source.getFillFormat().getEffective().getSolidFillColor());

    IImage before = slide.getImage(1f, 1f);
    try {
        before.save("color-copy-before.png", ImageFormat.Png);
    } finally {
        before.dispose();
    }

    // Odkazy na motiv sledují novou akcentní barvu; pevná hodnota RGB ne.
    presentation.getMasterTheme().getColorScheme().getAccent1().setColor(Color.rgb(255, 69, 0));

    IImage after = slide.getImage(1f, 1f);
    try {
        after.save("color-copy-after.png", ImageFormat.Png);
    } finally {
        after.dispose();
    }
    presentation.save("copied_colors.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Před změnou motivu se všechny tři výplně shodují:

![Zdroj, cíl copyFrom a pevný RGB cíl s identickými modrými výplněmi](color-copy-before.png)

Po změně motivu zdroj a kopie respektující motiv následují novou akcentní barvu a zachovávají svůj odstín. Pevná RGB kopie zůstává modrá:

![Zdroj a cíl copyFrom s oranžovými výplněmi, zatímco pevný RGB cíl zůstává modrý](color-copy-after.png)

Zkopírovaná definice je nezávislá na zdroji. Následná změna odkazu na motiv ve zdroji, přiřazení jiné barvy nebo přidání či odebrání jeho transformací nemění cíl. Změna motivu stále ovlivňuje oba tvary, protože každý nezávisle odkazuje na stejnou barvu motivu.

Uložení a opětovné otevření PPTX zachovává typ zkopírované barvy vrácený metodou [IColorFormat.getColorType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorType--), odkaz na motiv a kolekci transformací vrácenou metodou [IColorFormat.getColorTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/#getColorTransform--); nedefinuje ji do RGB.

Při kopírování mezi různými kontexty motivu, například mezi prezentacemi s různými akcentními paletami, se zkopírovaný odkaz vyhodnocuje vůči motivu cíle. Stejný odkaz a transformace tak mohou vytvořit odlišnou viditelnou barvu. Viz [Presentation Theme](/slides/cs/androidjava/presentation-theme/) pro více informací o konfiguraci barev motivu.

## **Použití pozadí snímku jako výplně tvaru**

Použijte [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-) když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nastavte typ výplně pomocí [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) na [FillType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) aby se odstranila jakákoli explicitní výplň. S touto kombinací tvar používá pozadí snímku místo své výplně stylu. Pouhé zapnutí příznaku neodstraňuje existující explicitní výplň.

Toto se liší od [FillType.NoFill](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/): výplň pozadí pokrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň nechává tyto objekty viditelné. Gradient zůstává zarovnán se snímkem místo toho, aby se restartoval uvnitř každého tvaru.

Následující příklad vytvoří hlavní pozadí zděděné snímkem a umístí purpurový pruh za tři obdélníky. Levý obdélník používá pozadí, střední obdélník nemá výplň a pravý obdélník přepíná z výplně pozadí na explicitní oranžovou výplň.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 400, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    // Zdědit gradient z masteru.
    slide.getBackground().setType(BackgroundType.NotDefined);
    slide.getLayoutSlide().getBackground().setType(BackgroundType.NotDefined);
    IBackground background = slide.getLayoutSlide().getMasterSlide().getBackground();
    background.setType(BackgroundType.OwnBackground);
    background.getFillFormat().setFillType(FillType.Gradient);
    IGradientFormat gradient = background.getFillFormat().getGradientFormat();
    gradient.setGradientShape(GradientShape.Linear);
    gradient.setLinearGradientAngle(0);
    gradient.getGradientStops().clear();
    gradient.getGradientStops().add(0, Color.rgb(0, 0, 139));
    gradient.getGradientStops().add(1, Color.rgb(135, 206, 250));

    // Přidejte tento objekt jako první, aby byl za obdélníky.
    IAutoShape band = slide.getShapes().addAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(Color.MAGENTA);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    IAutoShape backgroundShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
    backgroundShape.getFillFormat().setFillType(FillType.NotDefined);
    backgroundShape.setUseBackgroundFill(true);

    IAutoShape noFillShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
    noFillShape.getFillFormat().setFillType(FillType.NoFill);

    IAutoShape explicitShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
    explicitShape.getFillFormat().setFillType(FillType.NotDefined);
    explicitShape.setUseBackgroundFill(true);

    // Zakázat výplň pozadí před použitím explicitní výplně.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek, zleva doprava: **výplň pozadím**, **žádná výplň** a **explicitní výplň**. Purpurový pruh je zakryt levým a pravým obdélníkem, ale zůstává viditelný skrz střední obdélník.

![Výplň pozadím, žádná výplň a explicitní oranžová výplň přes purpurový pruh](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozložení. Tvar používá rozpoznané pozadí snímku; příklad ponechává pozadí snímku i rozložení nedefinované, takže jej poskytuje master.

## **Nastavení průhlednosti**

U plné výplně komponenta alfa barvy řídí neprůhlednost: 0 je zcela průhledná a 255 zcela neprůhledná. Tento příklad používá alfa hodnotu 128 pro žlutý obdélník, což jej činí přibližně 50 % průhledným, takže obdélník pod ním zůstává viditelný. Barva je přiřazena pomocí [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(Color.argb(128, 255, 255, 0));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otočení tvarů**

Použijte [IShape.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setRotation-float-) k otočení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otáčí obdélník o 5 stupňů po směru hodinových ručiček a uloží prezentaci.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.setRotation(5);

    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Otočení tvaru](shape-rotation.png)

## **Přidání 3D Zkosených efektů**

Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getThreeDFormat--) k tomu, abyste tvaru dodali hloubku a zkosené hrany. Tento příklad vytvoří zelenou elipsu s oranžovým obrysem, použije [IThreeDFormat.setDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#setDepth-double-) aby nastavil hloubku na 4 body, a aplikuje kruhové horní zkosení s šířkou a výškou 6 bodů přes [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithreedformat/#getBevelTop--). Frontální ortografická kamera a tříbodové osvětlení umožňují viditelnost zkosení.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().setWidth(2.0);
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

3D pohled tvaru je řízen nastavením kamery. Tento příklad používá [ICamera.setRotation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setRotation-float-float-float-) s úhly šířky (latitude), délky (longitude) a revoluce 40, 35 a 20 stupňů. Vybere izometrickou kameru pomocí [ICamera.setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) a vyvážené osvětlení pomocí [ILightRig.setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-), poté uloží formátovaný obdélník.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![3D efekt otáčení](3D-rotation-effect.png)

## **Ovládání černobílého vykreslení pro tvary**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Sama o sobě neaktivuje černobílé zobrazení a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` nechává rozhodnout konverzi aplikaci pro vykreslování, `Gray` a `LightGray` používají šedé zabarvení, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachovává normální barevnost a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen režim na úrovni tvaru.

Tento příklad vytvoří oranžový obdélník a použije [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) aby vybral šedé zabarvení. Uložený tvar si zachová oranžovou výplň pro normální barevné zobrazení a požádá o šedé zabarvení aplikace, které respektují nastavení černobílého zobrazení:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V normálním barevném režimu si obdélník zachová oranžovou výplň. V černobílém pracovním postupu používá šedé zabarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat barevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné pracovní postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Použijte [ISlide.reset](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#reset--) k obnovení pozice, velikosti a formátování zástupných objektů snímku z jejich odpovídajících zástupných objektů rozvržení. Tento příklad vyžaduje existující prezentaci s placeholdery propojenými s rozvržením a před uložením resetuje každý snímek. Tvary bez odpovídajících placeholderů rozvržení nejsou resetovány.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        slide.reset();
    }

    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají jen málo dat ve srovnání s vloženými obrázky a médii. Obrázkové výplně mohou zvětšit velikost souboru, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru — výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což zjednoduší pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru šablony .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu použijte jejich formátování tam, kde je potřeba.