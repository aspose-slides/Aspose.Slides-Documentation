---
title: Formátování tvarů PowerPointu v Javě
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/java/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- skicovací efekt
- skicovat čáru tvaru
- formát stylu spojení
- gradientní výplň
- vzorová výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- otočení tvaru
- 3D sražený efekt
- 3D rotační efekt
- obnovení formátování
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak v Javě pomocí Aspose.Slides formátovat tvary PowerPointu — nastavit výplně, čáry a efekty pro soubory PPT a PPTX s přesností a úplnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro Java vám umožňuje tyto nastavení ovládat programově, včetně průhlednosti, otáčení a 3D formátování.

![Možnosti formátování tvarů v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro Java poskytuje rozhraní a metody, které umožňují formátovat tvary pomocí stejných možností, které jsou k dispozici v PowerPointu.

## **Formátování čar**

Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) ke kontrole obrysu tvaru. Tento příklad vytváří nevyplněný obdélník s modrým, čárkovaným obrysem. [ILineFormat.setStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setStyle-byte-) vybírá složenou čáru tlustá‑tenká, zatímco [ILineFormat.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setWidth-double-) nastaví její šířku na 7 bodů a [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-) vybere vzor čáry.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **Nastavení vlastních vzorů čárových čar**

Použijte [ILineFormat.setCustomDashPattern](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCustomDashPattern-float:A-) když předdefinované styly čar neposkytují požadované délky čáry a mezer, například pro firemní obrysy nebo technické diagramy. Při přiřazení vzoru se automaticky změní styl čáry na [LineDashStyle.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).

Položky pole se střídají mezi délkou čáry a mezery, počínaje čárou. Každá hodnota je násobkem šířky čáry: `{ 4, 2 }` při šířce 3 bodů vytvoří čáru dlouhou 12 bodů a následnou mezeru dlouhou 6 bodů. Používejte dvojice konečných, nezáporných hodnot k definování kompletních segmentů čáry a mezery. Příklad používá kladné hodnoty, aby byly všechny čáry a mezery viditelné.

Tento příklad vytváří pět modrých čar se stejnou délkou a plochými konci. První tři porovnávají vzory při šířce 3 bodů. Čtvrtá zopakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí jak délku čáry, tak mezery. Pátá přepíná z vlastního vzoru na plnou čáru.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Chcete‑li se vrátit k předdefinovanému čárkovanému stylu, předejte [LineDashStyle.Dash](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/) metodě [ILineFormat.setDashStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setDashStyle-byte-). Vybraný styl určuje vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čárových čar, širší čára používající první vzor a plná čára v PowerPointu](custom-dash-patterns.png)

### **Nastavení koncových stylů čar**

Použijte [ILineFormat.setCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setCapStyle-byte-) k nastavení konců otevřené čáry. Třída [LineCapStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linecapstyle/) poskytuje tři explicitní styly konců:

- `Flat`: Tah končí na koncovém bodě.
- `Round`: Polokruhový konec přesahuje koncový bod o polovinu šířky čáry.
- `Square`: Čtvercový konec přesahuje koncový bod o polovinu šířky čáry.

Třída také zahrnuje `NotDefined`, což znamená, že žádný styl konce není explicitně přiřazen.

Konce se liší od šipek, které přidávají symboly na konce čáry, a od spojení, která řídí rohy mezi segmenty čáry. Tento příklad zakáže šipky pomocí [ILineFormat.setBeginArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setBeginArrowheadStyle-byte-) a [ILineFormat.setEndArrowheadStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setEndArrowheadStyle-byte-), takže jsou porovnávány pouze tvary konců.

Následující příklad vytvoří tři jinak identické vodorovné čáry, šířky 20 bodů. Shora dolů používají ploché, kulaté a čtvercové konce. Jejich koncové body mají stejné vodorovné souřadnice; kulaté a čtvercové konce přesahují 10 bodů za každý koncový bod.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(500, 240, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] capStyles = new byte[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

    for (int i = 0; i < capStyles.length; i++) {
        IAutoShape line = slide.getShapes().addAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
        line.getLineFormat().setWidth(20);
        line.getLineFormat().getFillFormat().setFillType(FillType.Solid);
        line.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
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

Výsledek v PowerPointu, shora dolů: **Flat**, **Round**, a **Square**.

![Plochý, kulatý a čtvercový konec na identických tlustých čarách v PowerPointu](line-caps.png)

## **Použití skicovacích efektů na čáry tvarů**

Skicovací efekt dává čáře tvaru vzhled ručně kreslené. Použijte [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) k přístupu k nastavením čáry, [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getSketchFormat--) k přístupu k nastavením skice a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#setSketchType-int-) k výběru hodnoty ze třídy [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/).

Následující kód v Javě ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/), přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/):

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

Hodnota vrácená metodou [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/#getSketchType--) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, základního snímku nebo rozvržení, použijte [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#getEffective--), přistupte k [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/#getSketchFormat--) a přečtěte [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/#getSketchType--). Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na první snímku a vypíše obě hodnoty:

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

- Zaoblený
- Ostrý
- Sražený

Styl spojení řídí, jak se dva obrysové segmenty setkávají v rohu. Použijte **Zaoblený** pro zaoblené rohy, **Ostrý** pro ostré rohy nebo **Sražený** pro zploštělé rohy.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Tento příklad vytváří tři černé obdélníky s modrými obrysy o šířce 15 bodů. Používá [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) k nastavení hodnot miter, bevel a round třídy [LineJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) a porovnává, jak jsou rohy vykresleny.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

### **Omezení ostrých spojení u ostrých rohů**

Použijte [ILineFormat.setMiterLimit](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setMiterLimit-float-) spolu s [ILineFormat.setJoinStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/#setJoinStyle-byte-) nastaveným na [LineJoinStyle.Miter](https://reference.aspose.com/slides/java/com.aspose.slides/linejoinstyle/) k omezení, jak daleko může ostrý roh vystupovat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spojení k šířce čáry. Například hodnota `8` umožňuje délku miteru až osminásobek šířky čáry; nejde o měřítko v bodech. Pokud by roh překročil limit, PowerPoint použije sražené spojení v tomto bodě. Větší limit umožňuje ostřejší špičky. Nastavení ovlivňuje pouze miterové spoje a nemá viditelný vliv, když roh zůstává v mezích limitu.

Tento příklad vytváří dva identické, nevyplněné trojúhelníky s obrysy o šířce 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník je široký 80 bodů a vysoký 160 bodů, což dává jeho hornímu rohu poměr délky miteru k šířce čáry přibližně `4.12`. PowerPoint proto sraženě zpracuje levý vrchol a zachová pravý vrchol.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
        triangle.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
        triangle.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
        triangle.getLineFormat().setMiterLimit(miterLimits[i]);
    }

    presentation.save("miter_limits.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Sražený vrchol s omezením ostrosti 2 a špičatý vrchol s omezením ostrosti 8 v PowerPointu](miter-limits.png)

## **Gradientní výplň**

Gradientní výplň míchá barvy přes tvar. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů od červené po fialovou pomocí [IFillFormat.getGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getGradientFormat--). Metoda [IGradientStopCollection.addPresetColor](https://reference.aspose.com/slides/java/com.aspose.slides/igradientstopcollection/#addPresetColor-float-int-) umístí barevné zastávky na 0 a 1, tedy na začátek a konec gradientu. Vymazání existujících zastávek zajistí, že budou použity pouze tyto dvě barvy.

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

![Elipsa s gradientní výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, podívejte se na [Zvolte styl vykreslování gradientu](/slides/cs/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste měnili gradient uložený v prezentaci.

### **Nastavení úhlu lineárního gradientu**

Použijte [IGradientFormat.setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-) k řízení orientace výplně [GradientShape.Linear](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/). Úhel se měří ve stupních a roste ve směru hodinových ručiček: `0` jde zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Podporovány jsou desetinné úhly. Úhly mimo interval `[0, 360)` jsou normalizovány na jednu otáčku; např. `-45` se změní na `315` a `360` na `0`.

Tento příklad vytváří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0.5` a `1`. Škálování je vypnuto, aby šlo úhly porovnat nezávisle na proporcích obdélníků. Úhly, zleva doprava, jsou v první řadě `0`, `45` a `90` a ve druhé řadě `135`, `180` a `270`.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Lineární gradienty při 0°, 45°, a 90° v horním řádku a 135°, 180°, a 270° v dolním řádku](linear-gradient-angles.png)

### **Škálování lineárního gradientu s tvarem**

[IGradientFormat.setLinearGradientScaled](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientScaled-byte-) přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/). Nastavte ji explicitně na `False`, aby geometrický úhel gradientu zůstal stejný při změně proporcí tvaru, nebo na `True`, aby se gradient škáloval spolu se šířkou a výškou tvaru. Se zapnutým škálováním se viditelný úhel může lišit od přiřazeného úhlu u netrvalých (nečtvercových) tvarů.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako v porovnání úhlů. Levý sloupec používá `False`; pravý sloupec používá `True`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak výplň reaguje na změnu velikosti bez změny nastavení gradientu.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

Výsledek v PowerPointu, s vypnutým škálováním vlevo a zapnutým vpravo:

![Široké a vysoké obdélníky s 45° gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

S vypnutým škálováním si diagonální barevné pásy zachovávají stejnou orientaci v obou obdélnících. Se zapnutým škálováním se pásy natahují spolu s proporcemi tvaru. To pomáhá reprodukovat gradient šablony při úpravě tvaru na jinou velikost. Na čtverci zapnutí škálování nemění vzhled tohoto `45`‑stupňového gradientu.

Obě nastavení – úhel i škálování – se vztahují pouze na lineární gradienty. Neovlivňují výplně [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/java/com.aspose.slides/gradientshape/).

### **Kombinace úhlu se směrem gradientu**

[IGradientFormat.setGradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setGradientDirection-int-) vybírá styl gradientu ze třídy [GradientDirection](https://reference.aspose.com/slides/java/com.aspose.slides/gradientdirection/); není to náhrada za číselný úhel. U lineárního gradientu mohou styly rohů změnit oblast, kde jsou barvy rozloženy, aniž by se změnil úhel nastavený metodou [setLinearGradientAngle](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/#setLinearGradientAngle-float-). Při porovnávání úhlů nebo škálování nechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: nastavení směru před nebo po úhlu výsledek nemění.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

## **Vzorová výplň**

Vzorová výplň aplikuje dvoubarevný motiv, například body, pruhy nebo šachovnici. Tento příklad používá [IPatternFormat.setPatternStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#setPatternStyle-byte-) k výběru motivu mřížky. [IPatternFormat.getBackColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getBackColor--) poskytuje světle šedé pozadí a [IPatternFormat.getForeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ipatternformat/#getForeColor--) poskytuje žlutou barvu motivu.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    shape.getFillFormat().setFillType(FillType.Pattern);
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje lokální obrázek a načte jej do kolekce obrázků prezentace pomocí [Images.fromFile](https://reference.aspose.com/slides/java/com.aspose.slides/images/#fromFile-java.lang.String-). Nastavení [IPictureFillFormat.setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) na režim dlaždicování opakuje obrázek uvnitř obdélníku. Použitý zdrojový obrázek je zobrazen níže:

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

Chcete‑li nastavit opakovaný obrázek jako texturu a přizpůsobit chování opakování, můžete použít následující metody rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Nastaví režim obrázkové výplně – `Tile` nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Řídí, zda je dlaždice otočena horizontálně, vertikálně nebo oběma směry.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Nastaví horizontální posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Nastaví vertikální posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Definuje horizontální měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Definuje vertikální měřítko dlaždice v procentech.

Tento příklad vyžaduje lokální obrázek a konfiguruje [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) tak, aby jej opakoval při 50 % původní velikosti. Posuny `-32` bodů posunou dlaždice horizontálně i vertikálně; zarovnání vpravo dole a otočení v obou směrech určují uspořádání opakované textury.

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

![Možnosti dlaždicování](tile-options.png)

## **Jednobarevná výplň**

Jednobarevná výplň dává tvaru jednu, jednotnou barvu. Tento příklad používá [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) k nastavení režimu jednobarevné výplně a přiřazuje žlutou barvu pomocí [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--), poté ukládá obdélník v prezentaci.

```java
import com.aspose.slides.*;
import java.awt.Color;

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

![Tvar s jednobarevnou výplní](solid-color-fill.png)

## **Použít pozadí snímku jako výplň tvaru**

Použijte [IAutoShape.setUseBackgroundFill](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#setUseBackgroundFill-boolean-), když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nejprve použijte [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) na **[FillType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/)**, aby se odstranila jakákoliv explicitní výplň. S touto kombinací tvar použije pozadí snímku místo své vlastní výplně. Pouze nastavení příznaku nedostane existující explicitní výplň.

Odlišuje se od [FillType.NoFill](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/): výplní pozadí zakrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň nechává tyto objekty viditelné. Gradient zůstává zarovnán k snímku místo toho, aby byl znovu zahájen uvnitř každého tvaru.

Následující příklad vytvoří hlavní pozadí zděděné snímkem a umístí magentový pás za tři obdélníky. Levý obdélník používá pozadí, střední obdélník nemá výplň a pravý obdélník přepíná z výplně pozadím na explicitní oranžovou výplň.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    gradient.getGradientStops().add(0, new Color(0, 0, 139));
    gradient.getGradientStops().add(1, new Color(135, 206, 250));

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

    // Disable background fill before applying an explicit fill.
    explicitShape.setUseBackgroundFill(false);
    explicitShape.getFillFormat().setFillType(FillType.Solid);
    explicitShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));

    presentation.save("background_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek, zleva doprava: **vyplnění pozadím**, **žádná výplň**, a **explicitní výplň**. Magentový pás je skrytý levým a pravým obdélníkem, ale zůstává viditelný skrze prostřední obdélník.

![Výplň pozadím, žádná výplň a explicitní oranžová výplň přes magenta pás](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozvržení. Tvar používá rozlišené pozadí snímku; příklad ponechává pozadí snímku i rozvržení nedefinováno, takže jej dodává hlavní návrh.

## **Nastavení průhlednosti**

U jednobarevné výplně komponenta alfa barvy řídí neprůhlednost: 0 je zcela průhledná a 255 zcela neprůhledná. Tento příklad používá alfa hodnotu 128 pro žlutý obdélník, čímž jej přibližně na 50 % učiní průhledným, aby podkladový obdélník zůstal vidět. Barva je přiřazena pomocí [IFillFormat.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#getSolidFillColor--).

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 128));

    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Použijte [IShape.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setRotation-float-) k otáčení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otáčí obdélník o 5 stupňů po směru hodinových ručiček a ukládá prezentaci.

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

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D sražených efektů**

Použijte [IShape.getThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getThreeDFormat--) k přidání hloubky a sražených okrajů tvaru. Tento příklad vytvoří zelenou elipsu s oranžovým obrysem, nastaví hloubku na 4 body pomocí [IThreeDFormat.setDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#setDepth-double-) a aplikuje kruhové horní sražení s šířkou a výškou 6 bodů přes [IThreeDFormat.getBevelTop](https://reference.aspose.com/slides/java/com.aspose.slides/ithreedformat/#getBevelTop--). Kamera zepředu a tříbodové osvětlení zpřehledňují sražení.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
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

![3D efekt sražení](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

3D pohled tvaru řídí nastavení kamery. Tento příklad používá [ICamera.setRotation](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setRotation-float-float-float-) s úhly šířky, délky a otáčení 40, 35 a 20 stupňů. Vybere isometrickou kameru pomocí [ICamera.setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) a vyvážené osvětlení pomocí [ILightRig.setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-), poté ukládá naformátovaný obdélník.

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

![3D rotační efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování tvarů**

Metoda [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) specifikuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazena nebo zpracována v černobílém režimu. Samotná metoda neaktivuje černobílý režim a nemění výplň, čáru ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu ze třídy [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `Automatic` nechá konverzi na rozhodnutí aplikace, `Gray` a `LightGray` používají šedý odstín, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvu a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že žádný režim na úrovni tvaru není přiřazen.

Tento příklad vytvoří oranžový obdélník a použije [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) k nastavení režimu na šedou. Uložený tvar si zachová oranžovou výplň pro normální barevné zobrazení a požaduje šedé zabarvení od aplikací, které respektují nastavení černobílého režimu:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(new Color(255, 165, 0));
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V normálním barevném režimu si obdélník ponechává oranžovou výplň. V černobílém workflow používá šedé zabarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné workflowy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Použijte [ISlide.reset](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#reset--) k obnovení pozice, velikosti a formátování zástupců snímku z odpovídajících zástupců rozvržení. Tento příklad vyžaduje existující prezentaci s rozvržením‑spojenými zástupci a před uložením resetuje každý snímek. Tvary bez odpovídajících zástupců rozvržení nejsou resetovány.

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

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají jen málo dat ve srovnání s vloženými obrázky a multimédii. Obrázkové výplně mohou zvětšit velikost souboru, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají stejný formát, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony prezentace nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, zkopírujte potřebné stylované tvary a znovu použijte jejich formátování podle potřeby.