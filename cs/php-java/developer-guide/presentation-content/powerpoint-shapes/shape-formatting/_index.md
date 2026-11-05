---
title: Formátování tvarů PowerPoint v PHP
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/php-java/shape-formatting/
keywords:
- formát tvaru
- formát čáry
- skicový efekt
- skicová čára tvaru
- formátování stylu spoje
- gradientová výplň
- výplň vzorem
- výplň obrázkem
- výplň texturou
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- šedotónové vykreslování tvaru
- otočení tvaru
- 3D efekt zkosení
- 3D otáčecí efekt
- obnovení formátování
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPoint v PHP pomocí Aspose.Slides — nastavte výplň, čáru a styl efektů pro soubory PPT a PPTX s precizností a plnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro PHP prostřednictvím Java vám umožní tato nastavení programově řídit, včetně průhlednosti, otočení a 3D formátování.

![Možnosti formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro PHP prostřednictvím Java poskytuje třídy a metody, které vám umožní formátovat tvary pomocí stejných možností, které jsou k dispozici v PowerPointu.

## **Formátování čar**

Použijte [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) k řízení obrysu tvaru. Tento příklad vytvoří nevyplněný obdélník s modrým, čárkovaným obrysem. [LineFormat::setStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setStyle) vybere tlustou‑tenkou složenou čáru, zatímco [LineFormat::setWidth](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setWidth) nastaví její šířku na 7 bodů a [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle) vybere vzor čárkování.

```php
use aspose\slides\FillType;
use aspose\slides\LineDashStyle;
use aspose\slides\LineStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavení vlastních vzorů čárových čárek**

Použijte [LineFormat::setCustomDashPattern](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCustomDashPattern), když předdefinované styly čar neposkytují požadované délky čárek a mezer, například pro značkové obrysy nebo technické diagramy. Přiřazením vzoru se automaticky změní styl čáry na [LineDashStyle::Custom](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/).

Položky pole se střídají mezi délkou čárky a mezery, začínají čárkou. Každá hodnota je násobkem šířky čáry: `[4, 2]` při šířce 3 body dává čáru o délce 12 bodů následovanou mezerou 6 bodů. Používejte dvojice konečných, nezáporných hodnot k definování kompletních segmentů čáry a mezery. Příklad používá kladné hodnoty, aby byla každá čárka a mezera viditelná.

Tento příklad vytvoří pět modrých čar se stejnou délkou a plochými zakončeními. První tři porovnávají vzory při šířce 3 body. Čtvrtá opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí jak délky čárek, tak mezer. Pátá přepíná z vlastního vzoru na plnou čáru.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(600, 300, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $patterns = [
        [4, 2],
        [1, 2],
        [6, 2, 1, 2],
        [4, 2],
        [4, 2]
    ];
    $lineColor = new Java("java.awt.Color", 0, 0, 139);

    for ($i = 0; $i < count($patterns); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 50 + $i * 50, 500, 0);
        $line->getLineFormat()->setWidth($i == 3 ? 6 : 3);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setCapStyle(LineCapStyle::Flat);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setCustomDashPattern($patterns[$i]);
    }

    // Nastavit poslední čáru na plný styl.
    $slide->getShapes()->get_Item(4)->getLineFormat()->setDashStyle(LineDashStyle::Solid);

    $presentation->save("custom_dash_patterns.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Chcete-li se vrátit k předdefinovanému stylu čárkované čáry, předávejte [LineDashStyle::Dash](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) metodě [LineFormat::setDashStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setDashStyle). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čárování, silnější čára používající první vzor a plná čára v PowerPointu](custom-dash-patterns.png)

### **Nastavení zakončení čar**

Použijte [LineFormat::setCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setCapStyle) k nastavení konců otevřené čáry. Třída [LineCapStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linecapstyle/) poskytuje tři explicitní styly zakončení:

- `Flat`: Tah končí na koncovém bodě.
- `Round`: Polokulaté zakončení přesahuje za koncový bod o polovinu šířky čáry.
- `Square`: Čtvercové zakončení přesahuje za koncový bod o polovinu šířky čáry.

Třída také zahrnuje `NotDefined`, což znamená, že žádný styl zakončení není explicitně přiřazen.

Zakončení se liší od šipek, které přidávají symboly na konce čar, a spojů, které řídí rohy mezi segmenty čar. Tento příklad zakazuje šipky pomocí [LineFormat::setBeginArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setBeginArrowheadStyle) a [LineFormat::setEndArrowheadStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setEndArrowheadStyle), aby byly porovnávány pouze tvary zakončení.

Následující příklad vytvoří tři jinak identické vodorovné čáry, široké 20 bodů. Shora dolů používají ploché, kulaté a čtvercové zakončení. Jejich koncové body mají stejné vodorovné souřadnice; kulaté a čtvercové zakončení přesahují 10 bodů za každý koncový bod.

```php
use aspose\slides\FillType;
use aspose\slides\LineArrowheadStyle;
use aspose\slides\LineCapStyle;
use aspose\slides\LineDashStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 240, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $capStyles = [LineCapStyle::Flat, LineCapStyle::Round, LineCapStyle::Square];

    for ($i = 0; $i < count($capStyles); $i++) {
        $line = $slide->getShapes()->addAutoShape(ShapeType::Line, 100, 50 + $i * 70, 300, 0);
        $line->getLineFormat()->setWidth(20);
        $line->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $line->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $line->getLineFormat()->setDashStyle(LineDashStyle::Solid);
        $line->getLineFormat()->setCapStyle($capStyles[$i]);
        $line->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle::None);
        $line->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle::None);
    }

    $presentation->save("line_caps.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round** a **Square**.

![Ploché, kulaté a čtvercové zakončení na identických silných čarách v PowerPointu](line-caps.png)

## **Použití skicových efektů na linky tvarů**

Skicový efekt způsobí, že linka tvaru vypadá ručně kreslená. Použijte [Shape::getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getLineFormat) pro přístup k nastavením čáry, [LineFormat::getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getSketchFormat) pro přístup k nastavením skici a [SketchFormat::setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#setSketchType) pro výběr hodnoty z třídy [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Následující PHP kód ukazuje, jak použít efekt [LineSketchType::Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType::None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/) :

```php
use aspose\slides\LineSketchType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    $sketchFormat = $shape->getLineFormat()->getSketchFormat();
    $sketchFormat->setSketchType(LineSketchType::Curved);
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Hodnota vrácená metodou [SketchFormat::getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/#getSketchType) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavní snímku nebo rozložení snímku, použijte [LineFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#getEffective), přistupte k metodě `getSketchFormat` vráceného objektu a přečtěte jeho hodnotu `getSketchType`. Efektivní hodnota odráží formátování, které je skutečně použito po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na prvním snímku a vypíše obě hodnoty:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $lineFormat = $shape->getLineFormat();
    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typu spojení:

* Round
* Miter
* Bevel

Styl spojení řídí, jak se dva úseky obrysu setkají v rohu. Použijte **Round** pro zaoblené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Tento příklad vytvoří tři černé obdélníky s modrými obrysy širokými 15 bodů. Nastaví [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) na hodnoty miter, bevel a round třídy [LineJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) a porovná, jak jsou rohy vykresleny.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $miterShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $bevelShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $roundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    $miterShape->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $bevelShape->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $roundShape->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    $miterShape->getLineFormat()->setWidth(15);
    $bevelShape->getLineFormat()->setWidth(15);
    $roundShape->getLineFormat()->setWidth(15);

    $miterShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $miterShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $bevelShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $bevelShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $roundShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $roundShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    $miterShape->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $bevelShape->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $roundShape->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    $miterShape->getTextFrame()->setText("Miter Join Style");
    $bevelShape->getTextFrame()->setText("Bevel Join Style");
    $roundShape->getTextFrame()->setText("Round Join Style");

    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Omezení Miter spojení na ostrých rozích**

Použijte [LineFormat::setMiterLimit](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setMiterLimit) s [LineFormat::setJoinStyle](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/#setJoinStyle) nastaveným na [LineJoinStyle::Miter](https://reference.aspose.com/slides/php-java/aspose.slides/linejoinstyle/) k omezení, jak daleko může ostrý roh vyčnívat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spoje k šířce čáry. Například hodnota `8` povoluje délku miteru až osminásobek šířky čáry; nejde o měření v bodech. Pokud by roh překročil limit, PowerPoint použije na tomto rohu zkosení. Větší limit umožňuje ostřejší špičky. Nastavení se týká jen miterových spojení a jeho změna nemá viditelný efekt, když roh zůstává v obou limitech.

Tento příklad vytvoří dva identické nevyplněné trojúhelníky s obrysy širokými 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník má šířku 80 bodů a výšku 160 bodů, což dává jeho hornímu rohu poměr délky miteru k šířce čáry přibližně `4.12`. Výsledkem je, že PowerPoint zbeveluje levý vrchol a zachová pravý vrchol.

```php
use aspose\slides\FillType;
use aspose\slides\LineJoinStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(500, 320, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $miterLimits = [2, 8];

    for ($i = 0; $i < count($miterLimits); $i++) {
        $triangle = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 90 + $i * 240, 110, 80, 160);
        $triangle->getFillFormat()->setFillType(FillType::NoFill);
        $triangle->getLineFormat()->setWidth(20);
        $triangle->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
        $lineColor = new Java("java.awt.Color", 0, 0, 139);
        $triangle->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
        $triangle->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
        $triangle->getLineFormat()->setMiterLimit($miterLimits[$i]);
    }

    $presentation->save("miter_limits.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zbevelovaný vrchol s limitem 2 a špičatý vrchol s limitem 8 v PowerPointu](miter-limits.png)

## **Gradientové výplně**

Gradientová výplň míchá barvy napříč tvarem. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45° od červené k fialové pomocí [FillFormat::getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat). Metoda [GradientStopCollection::addPresetColor](https://reference.aspose.com/slides/php-java/aspose.slides/gradientstopcollection/#addPresetColor) umístí barevné zastávky na 0 a 1, na začátek a konec gradientu. Vymazání existujících zastávek zajistí, že budou použity jen tyto dvě barvy.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\PresetColor;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);
    $shape->getFillFormat()->getGradientFormat()->setLinearGradientAngle(45);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->clear();
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0.0, PresetColor::Red);

    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Elipsa s gradientovou výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá odlišně než v PowerPointu, viz [Choose a Gradient Rendering Style](/slides/cs/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování, aniž byste měnili gradientovou výplň uloženou v prezentaci.

### **Nastavení úhlu lineárního gradientu**

Použijte [GradientFormat::setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle) k řízení orientace výplně [GradientShape::Linear](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/). Úhel se měří ve stupních a roste po směru hodinových ručiček: `0` běží zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Zlomkové úhly jsou podporovány. Finální úhly mimo rozsah `[0, 360)` jsou normalizovány na jednu otáčku; například `-45` se stane `315` a `360` se stane `0`.

Tento příklad vytvoří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0.5` a `1`. Škálování je vypnuto, aby mohl být úhel porovnán nezávisle na proporcích obdélníků. Úhly zleva doprava jsou `0`, `45` a `90` v první řadě a `135`, `180` a `270` ve druhé řadě.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $angles = [0, 45, 90, 135, 180, 270];

    for ($i = 0; $i < count($angles); $i++) {
        $x = 30 + ($i % 3) * 230;
        $y = 30 + intdiv($i, 3) * 190;

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 200, 150);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::False);
        $gradient->setLinearGradientAngle($angles[$i]);
    }

    $presentation->save("linear_gradient_angles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek v PowerPointu:

![Lineární gradienty při 0°, 45° a 90° v horním řádku a 135°, 180° a 270° ve spodním řádku](linear-gradient-angles.png)

### **Škálování lineárního gradientu s tvarem**

[GradientFormat::setLinearGradientScaled](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientScaled) přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/). Nastavte ji explicitně na `False`, aby úhel geometrického gradientu zůstával stejný při změně proporcí tvaru, nebo na `True`, aby se gradient škáloval s šířkou a výškou tvaru. Při povoleném škálování se viditelný úhel může lišit od přiřazeného úhlu u nesčtvercového tvaru.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako při porovnání úhlů. Levý sloupec používá `False`; pravý používá `True`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak výplň reaguje na změnu velikosti, aniž by se měnilo nastavení gradientu.

```php
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 460, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $scalingOptions = [NullableBool::False, NullableBool::True];

    for ($column = 0; $column < count($scalingOptions); $column++) {
        for ($row = 0; $row < 2; $row++) {
            $x = 30 + $column * 360;
            $y = $row == 0 ? 30 : 150;

            $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, $y, 300, 90);
            $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
            $shape->getFillFormat()->setFillType(FillType::Gradient);

            $gradient = $shape->getFillFormat()->getGradientFormat();
            $gradient->setGradientShape(GradientShape::Linear);
            $gradient->getGradientStops()->clear();
            $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
            $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
            $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
            $gradient->setLinearGradientAngle(45);
            $gradient->setLinearGradientScaled($scalingOptions[$column]);

            if ($row == 1) {
                $shape->setWidth(90);
                $shape->setHeight(280);
            }
        }
    }

    $presentation->save("linear_gradient_scaling.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek v PowerPointu, se škálováním vypnutým vlevo a zapnutým vpravo:

![Široké a vysoké obdélníky s 45° gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

Při vypnutém škálování si úhlopříčné barevné pásy zachovávají stejnou orientaci v obou obdélnících. Při zapnutém škálování se pásy roztahují s proporcemi tvaru. To pomáhá reprodukovat gradient šablony při úpravě tvaru na jinou velikost. Na čtverci povolení škálování nemění vzhled tohoto `45`‑stupňového gradientu.

Oba nastavení – úhel i škálování – platí pro lineární gradienty. Nekontrolují výplně [GradientShape::Radial or GradientShape::Rectangle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientshape/).

### **Kombinace úhlu se směrem gradientu**

[GradientFormat::setGradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setGradientDirection) vybírá styl gradientu z třídy [GradientDirection](https://reference.aspose.com/slides/php-java/aspose.slides/gradientdirection/); není to náhrada číselného úhlu. Pro lineární gradient mohou styly rohů změnit oblast, na kterou jsou barvy rozloženy, aniž by se měnil úhel nastavený přes [setLinearGradientAngle](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/#setLinearGradientAngle). Při porovnávání úhlů nebo škálování ponechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: přiřazení směru před nebo po úhlu nemění výsledek.

```php
use aspose\slides\FillType;
use aspose\slides\GradientDirection;
use aspose\slides\GradientShape;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    for ($i = 0; $i < 2; $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30 + $i * 140, 320, 100);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getFillFormat()->setFillType(FillType::Gradient);

        $gradient = $shape->getFillFormat()->getGradientFormat();
        $gradient->setGradientShape(GradientShape::Linear);
        $gradient->getGradientStops()->clear();
        $gradient->getGradientStops()->add(0, java("java.awt.Color")->RED);
        $gradient->getGradientStops()->add(0.5, java("java.awt.Color")->GREEN);
        $gradient->getGradientStops()->add(1, java("java.awt.Color")->BLUE);
        $gradient->setLinearGradientScaled(NullableBool::True);

        if ($i == 0) {
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
            $gradient->setLinearGradientAngle(30);
        } else {
            $gradient->setLinearGradientAngle(30);
            $gradient->setGradientDirection(GradientDirection::FromCorner1);
        }
    }

    $presentation->save("linear_gradient_direction.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vyplnění vzorem**

Vyplnění vzorem aplikuje dvojbarevný design, například tečky, proužky nebo šachovnici. Tento příklad používá [PatternFormat::setPatternStyle](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#setPatternStyle) k výběru vzoru trellis. [PatternFormat::getBackColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) poskytuje světle šedé pozadí a [PatternFormat::getForeColor](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) žlutou barvu vzoru.

```php
use aspose\slides\FillType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Pattern);
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Obdélník s výplní vzorem](pattern-fill.png)

## **Vyplnění obrázkem**

Vyplnění obrázkem používá obrázek uvnitř tvaru. Tento příklad vyžaduje lokální obrázek a používá [Images::fromFile](https://reference.aspose.com/slides/php-java/aspose.slides/images/#fromFile) k načtení do kolekce obrázků prezentace. Nastavení [PictureFillFormat::setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode) na režim dlaždic opakuje obrázek v obdélníku. Zdrojový obrázek použitý zde je zobrazen níže:

![Obrázek lotosu](lotus.png)

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);
    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    $image = Images::fromFile("lotus.png");
    try {
        $picture = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Tvar s vyplněním obrázkem](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit dlaždicovaný obrázek jako texturu a přizpůsobit chování dlaždicování, můžete použít následující metody třídy [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) :

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Nastavuje režim vyplnění obrázkem – buď `Tile`, nebo `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Určuje zarovnání dlaždic uvnitř tvaru.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Řídí, zda je dlaždice překlopená vodorovně, svisle nebo obojí.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definuje vodorovné měřítko dlaždice v procentech.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definuje svislé měřítko dlaždice v procentech.

Tento příklad vyžaduje lokální obrázek a konfiguruje [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/) tak, aby ho opakoval ve 50 % původní velikosti. Posuny `-32` bodů posunou dlaždice vodorovně i svisle; zarovnání doleva dole a překlopení v obou směrech určuje, jak je opakovaná textura uspořádána.

```php
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\RectangleAlignment;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TileFlip;

$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);
    $shape->getFillFormat()->setFillType(FillType::Picture);

    $sourceImage = Images::fromFile("lotus.png");
    try {
        $presentationImage = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Možnosti dlaždicování](tile-options.png)

## **Jednobarevná výplň**

Jednobarevná výplň dává tvaru jedinou, jednotnou barvu. Tento příklad nastaví [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) na režim jednobarevné výplně a přiřadí žlutou barvu pomocí [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor), poté uloží obdélník v prezentaci.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Tvar s jednobarevnou výplní](solid-color-fill.png)

### **Kopírování barev při zachování odkazů na motiv**

Použijte [ColorFormat::copyFrom](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#copyFrom) k kopírování definice barvy, včetně typu barvy, odkazu na motiv a transformací. To je užitečné při převodu barvy výplně mezi tvary, které by měly i nadále sledovat motiv prezentace. Metoda kopíruje jen barvu: nekopíruje typ výplně, obrys ani jiné formátování tvaru. Cílový typ výplně nastavte explicitně pomocí [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType).

Tento příklad vytvoří tři obdélníky, zleva doprava: zdroj, kopii citlivou na motiv a pevnou RGB kopii. Zdroj používá [ColorFormat::setSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setSchemeColor) k odkazování na první akcentní barvu a přidává odstín pomocí [ColorOperationCollection::add](https://reference.aspose.com/slides/php-java/aspose.slides/coloroperationcollection/#add). RGB kopie používá efektivní barvu výplně ze zdroje, takže všechny tři vypadají zpočátku identicky. Volání [ColorFormat::setColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#setColor) nastaví pevnou RGB hodnotu a vymaže všechny existující transformace barvy.

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(660, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $initialAccent = new Java("java.awt.Color", 65, 105, 225);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($initialAccent);

    $source = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 40, 180, 140);
    $themeCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 240, 40, 180, 140);
    $rgbCopy = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 450, 40, 180, 140);

    foreach ([$source, $themeCopy, $rgbCopy] as $shape) {
        $shape->getFillFormat()->setFillType(FillType::Solid);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    }

    $sourceColor = $source->getFillFormat()->getSolidFillColor();
    $sourceColor->setSchemeColor(SchemeColor::Accent1);
    $sourceColor->getColorTransform()->add(ColorTransformOperation::Tint, 0.75);

    $themeCopy->getFillFormat()->getSolidFillColor()->copyFrom($sourceColor);
    $rgbCopy->getFillFormat()->getSolidFillColor()->setColor($source->getFillFormat()->getEffective()->getSolidFillColor());

    $before = $slide->getImage(1.0, 1.0);
    try {
        $before->save("color-copy-before.png", ImageFormat::Png);
    } finally {
        $before->dispose();
    }

    // Odkazy na motiv následují novou akcentní barvu; pevná hodnota RGB ne.
    $updatedAccent = new Java("java.awt.Color", 255, 69, 0);
    $presentation->getMasterTheme()->getColorScheme()->getAccent1()->setColor($updatedAccent);

    $after = $slide->getImage(1.0, 1.0);
    try {
        $after->save("color-copy-after.png", ImageFormat::Png);
    } finally {
        $after->dispose();
    }
    $presentation->save("copied_colors.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Před změnou motivu všechny tři výplně odpovídají:

![Zdroj, cíl copyFrom a pevná RGB cílová barva se stejnými modrými výplněmi](color-copy-before.png)

Po změně motivu zdroj a kopie citlivá na motiv následují novou barvu akcentu a zachovávají svůj odstín. Pevná RGB kopie zůstává modrá:

![Zdroj a cíl copyFrom s oranžovými výplněmi, zatímco pevná RGB cílová barva zůstává modrá](color-copy-after.png)

Kopírovaná definice je nezávislá na zdroji. Následná změna odkazu na motiv zdroje, přiřazení jiné barvy nebo přidání/odebrání jejích transformací nemění cíl. Změna motivu stále ovlivní oba tvary, protože každý samostatně odkazuje na stejnou barvu motivu.

Uložení a opětovné otevření souboru PPTX zachovává typ zkopírované barvy vrácený metodou [ColorFormat::getColorType](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorType), odkaz na motiv a kolekci transformací vrácenou metodou [ColorFormat::getColorTransform](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/#getColorTransform); nedochází k převodu definice na RGB.

Při kopírování mezi různými kontexty motivu, například mezi prezentacemi s odlišnými akcentními paletami, se zkopírovaný odkaz vyhodnocuje vůči motivu cíle. Stejný odkaz a transformace tak mohou vytvořit jinou viditelnou barvu. Viz [Presentation Theme](/slides/cs/php-java/presentation-theme/) pro více informací o konfiguraci barev motivu.

## **Použít pozadí snímku jako výplň tvaru**

Použijte [AutoShape::setUseBackgroundFill](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/#setUseBackgroundFill), když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nejprve nastavte typ výplně pomocí [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) na [FillType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) a odstraňte jakoukoli explicitní výplň. V této kombinaci tvar používá pozadí snímku místo své vlastní výplně. Pouze nastavení příznaku neodstraní existující explicitní výplň.

To se liší od [FillType::NoFill](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/): výplň pozadím zakryje objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň ponechá tyto objekty viditelné. Gradient zůstane zarovnán s snímkem namísto restartu uvnitř každého tvaru.

Následující příklad vytvoří hlavní pozadí zděděné snímkem a umístí magentový pruh za tři obdélníky. Levý obdélník používá pozadí, prostřední nemá výplň a pravý přepíná z výplně pozadím na explicitní oranžovou výplň.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\GradientShape;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 400, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    // Zdědit gradient z hlavního motivu.
    $slide->getBackground()->setType(BackgroundType::NotDefined);
    $slide->getLayoutSlide()->getBackground()->setType(BackgroundType::NotDefined);
    $background = $slide->getLayoutSlide()->getMasterSlide()->getBackground();
    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Gradient);
    $gradient = $background->getFillFormat()->getGradientFormat();
    $gradient->setGradientShape(GradientShape::Linear);
    $gradient->setLinearGradientAngle(0);
    $gradient->getGradientStops()->clear();
    $startColor = new Java("java.awt.Color", 0, 0, 139);
    $gradient->getGradientStops()->add(0, $startColor);
    $endColor = new Java("java.awt.Color", 135, 206, 250);
    $gradient->getGradientStops()->add(1, $endColor);

    // Přidejte tento objekt jako první, aby se zobrazoval za obdélníky.
    $band = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 25, 150, 670, 100);
    $band->getFillFormat()->setFillType(FillType::Solid);
    $band->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->MAGENTA);
    $band->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

    $backgroundShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 160, 200);
    $backgroundShape->getFillFormat()->setFillType(FillType::NotDefined);
    $backgroundShape->setUseBackgroundFill(true);

    $noFillShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 280, 100, 160, 200);
    $noFillShape->getFillFormat()->setFillType(FillType::NoFill);

    $explicitShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 510, 100, 160, 200);
    $explicitShape->getFillFormat()->setFillType(FillType::NotDefined);
    $explicitShape->setUseBackgroundFill(true);

    // Zakázat výplň pozadí před aplikací explicitní výplně.
    $explicitShape->setUseBackgroundFill(false);
    $explicitShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $explicitShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("background_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek, zleva doprava: **background fill**, **no fill**, a **explicit fill**. Magentový pruh je skryt levým a pravým obdélníkem, ale zůstává viditelný skrz prostřední obdélník.

![Pozadí výplní, žádná výplň a explicitní oranžová výplň nad fialovým pruhem](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozložení. Tvar používá rozlišené pozadí snímku; v příkladu jsou pozadí snímku i rozložení nedefinována, takže jej poskytuje hlavní motiv.

## **Nastavení průhlednosti**

U jednobarevné výplně řídí alfa komponenta barvy neprůhlednost: 0 je zcela průhledná a 255 zcela neprůhledná. Tento příklad používá alfa hodnotu 128 pro žlutý obdélník, čímž je přibližně 50 % průhledný, takže pod ním ležící obdélník zůstane vidět. Barva je přiřazena přes [FillFormat::getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor).

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 255, 0, 128);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor($fillColor);

    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otočení tvarů**

Použijte [Shape::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setRotation) k otočení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otočí obdélník o 5 deg po směru hodinových ručiček a uloží prezentaci.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $shape->setRotation(5);

    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Otočení tvaru](shape-rotation.png)

## **Přidání 3D efektu zkosení**

Použijte [Shape::getThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getThreeDFormat) k dodání hloubky a zkosených hran tvaru. Tento příklad vytvoří zelenou elipsu s oranžovým obrysem, nastaví [ThreeDFormat::setDepth](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#setDepth) na 4 body a aplikuje kruhové horní zkosení se šířkou a výškou 6 bodů přes [ThreeDFormat::getBevelTop](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/#getBevelTop). Frontální ortografická kamera a trojbodové osvětlení zpřehlední zkosení.

```php
use aspose\slides\BevelPresetType;
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\LightRigPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 0, 128, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $lineColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor($lineColor);
    $shape->getLineFormat()->setWidth(2.0);
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D otáčecích efektů**

3D zobrazení tvaru řídí nastavení kamery. Tento příklad používá [Camera::setRotation](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setRotation) s úhly latitude = 40°, longitude = 35° a revoluce = 20°. Vybere izometrickou kameru přes [Camera::setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) a vyvážené osvětlení přes [LightRig::setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType), poté uloží naformátovaný obdélník.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightRigPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![3D otáčecí efekt](3D-rotation-effect.png)

## **Ovládání černobílého vykreslování pro tvary**

Metoda [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) určuje, jak je jednotlivý tvar vykreslen, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Samotná metoda neaktivuje černobílé zobrazení a nemění výplň, obrys ani jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z třídy [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) pro výběr požadovaného chování. Například `Automatic` nechá aplikaci zvolit konverzi, `Gray` a `LightGray` použijí šedé zabarvení, `BlackWhite` jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvy a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Tento příklad vytvoří oranžový obdélník a nastaví [Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode) na šedou. Uložený tvar si zachová oranžovou výplň pro normální barevné zobrazení a požaduje šedé zabarvení od aplikací, které respektují nastavení černobílého zobrazení:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $fillColor = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($fillColor);
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

V normálním barevném režimu si obdélník zachová oranžovou výplň. V černobílém pracovním postupu používá šedé zabarvení, protože jeho režim je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a zároveň definovat odlišný vzhled pro tisk, náhled nebo jiné workflowy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Použijte [Slide::reset](https://reference.aspose.com/slides/php-java/aspose.slides/slide/#reset) k obnovení polohy, velikosti a formátování zástupců snímku z jejich odpovídajících zástupců rozložení. Tento příklad vyžaduje existující prezentaci se zástupci propojenými s rozložením a resetuje každý snímek před uložením. Tvary bez odpovídajících zástupců rozložení nejsou resetovány.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $slide->reset();
    }

    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Ovlivňuje formátování tvarů konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obvykle přidávají málo dat ve srovnání s vloženými obrázky a médii. Vyplnění obrázkem může zvýšit velikost souboru, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru – výplň, čáru a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky seskupte tyto tvary, což usnadní pozdější správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly v šabloně snímků nebo v souboru šablony .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylizované tvary a znovu aplikujte jejich formátování tam, kde je potřeba.