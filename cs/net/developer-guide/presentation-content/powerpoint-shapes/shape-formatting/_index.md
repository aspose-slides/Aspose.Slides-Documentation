---
title: Formátování tvarů PowerPointu v .NET
linktitle: Formátování tvarů
type: docs
weight: 20
url: /cs/net/shape-formatting/
keywords:
- formátovat tvar
- formátovat čáru
- skicový efekt
- skicová čára tvaru
- formátovat styl spoje
- gradientová výplň
- vzorková výplň
- obrázková výplň
- texturová výplň
- jednobarevná výplň
- průhlednost tvaru
- černobílé vykreslování tvaru
- stupně šedi vykreslování tvaru
- otočit tvar
- 3D efekt zkosení
- 3D rotační efekt
- obnovit formátování
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak formátovat tvary PowerPointu v C# pomocí Aspose.Slides — nastavte výplň, čáru a styly efektů pro soubory PPT a PPTX s přesností a plnou kontrolou."
---
## **Úvod**

Formátujte tvary v PowerPointu úpravou jejich obrysů, výplní a efektů. Aspose.Slides pro .NET vám umožňuje ovládat tato nastavení programově, včetně průhlednosti, otáčení a 3D formátování.

![Možnosti formátování tvaru v PowerPointu](format-shape-powerpoint.png)

Aspose.Slides pro .NET poskytuje rozhraní a vlastnosti, které vám umožní formátovat tvary pomocí stejných možností, jaké jsou k dispozici v PowerPointu.

## **Formátování čar**

Použijte [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) k ovládání obrysu tvaru. Tento příklad vytvoří nevyplněný obdélník s modrým, čárkovaným obrysem. [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) vybírá složenou čáru typu silná‑tenká, zatímco [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) nastaví její šířku na 7 bodů a [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) vybírá vzor čáry.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Výsledek:

![Formátované čáry v prezentaci](formatted-lines.png)

### **Nastavení vlastních vzorů čárek**

Použijte [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/), když předdefinované styly čar neposkytují potřebnou délku čárek a mezer, například pro značkové obrysy nebo technické diagramy. Při přiřazení vzoru se automaticky nastaví [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) na [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/).

Položky pole se střídají mezi délkou čárky a mezery, začínají čárkou. Každá hodnota je násobkem šířky čáry: `{ 4, 2 }` při šířce 3 body vytvoří čáru o délce 12 bodů následovanou mezerou 6 bodů. Používejte páry konečných, nezáporných hodnot k definování kompletních segmentů čára‑mezera. Příklad používá kladné hodnoty, aby byly všechny čárky a mezery viditelné.

Tento příklad vytvoří pět modrých čar se stejnou délkou a plochými konci. První tři porovnávají vzory při šířce 3 body. Čtvrtá opakuje první vzor při dvojnásobné šířce, čímž zdvojnásobí jak délku čáry, tak mezery. Pátá přepíná z vlastního vzoru na plnou čáru.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Vrátit poslední čáru na plný styl.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Chcete‑li se vrátit k předdefinovanému čárkovanému stylu, přiřaďte [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) k [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/). Vybraný styl řídí vzhled čáry.

Výsledek v PowerPointu, shora dolů: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; a **Solid, 3 pt**.

![Tři vlastní vzory čárek, širší čára používající první vzor a plná čára v PowerPointu](custom-dash-patterns.png)


### **Nastavení koncových tvarů čáry**

Použijte [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) k nastavení konců otevřené čáry. Výčtové typy [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) poskytují tři explicitní styly konců:

- `Flat`: Tah končí na koncovém bodě.
- `Round`: Polokruhový konec přesahuje koncový bod o polovinu šířky čáry.
- `Square`: Čtvercový konec přesahuje koncový bod o polovinu šířky čáry.

Výčet také obsahuje `NotDefined`, což znamená, že není přiřazen žádný explicitní styl konce.

Konce se liší od šipek, které přidávají symboly na konce čáry, a od spojů, které řídí rohy mezi segmenty čáry. Tento příklad zakáže šipky pomocí [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) a [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/), aby byly porovnávány pouze tvary konců.

Následující příklad vytvoří tři jinak identické vodorovné čáry, široké 20 bodů. Shora dolů používají ploché, kulaté a čtvercové konce. Jejich koncové body mají stejné vodorovné souřadnice; kulaté a čtvercové konce přesahují o 10 bodů za každý konec.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Výsledek v PowerPointu, shora dolů: **Flat**, **Round** a **Square**.

![Plochý, kulatý a čtvercový konec na identických silných čarách v PowerPointu](line-caps.png)

## **Použití skicových efektů na čáry tvarů**

Skicový efekt způsobí, že čára tvaru vypadá ručně kresleně. Použijte [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) k přístupu k nastavením čáry, [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) k přístupu k nastavením skicu a [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) k výběru hodnoty z výčtu [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/).

Následující kód C# ukazuje, jak použít efekt [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) , přečíst explicitně přiřazenou hodnotu a odstranit efekt pomocí [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/):

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Hodnota vrácená z [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) představuje nastavení přiřazené přímo tvaru. Pokud může být formátování čáry zděděno z motivu, hlavního snímku nebo rozvržení, použijte [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), přistupte k [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) a přečtěte [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). Efektivní hodnota odráží formátování, které je skutečně aplikováno po vyřešení dědičnosti. Tento příklad vyžaduje existující prezentaci s alespoň jedním tvarem na prvním snímku a vypíše obě hodnoty:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");
var shape = presentation.Slides[0].Shapes[0];

var lineFormat = shape.LineFormat;
var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Formátování stylů spojení**

Zde jsou tři možnosti typů spojení:

* Round
* Miter
* Bevel

Styl spoje řídí, jak se dva úseky obrysu setkají v rohu. Použijte **Round** pro zaoblené rohy, **Miter** pro ostré rohy nebo **Bevel** pro zploštělé rohy.

![Styl spojení v prezentaci](join-style-powerpoint.png)

Tento příklad vytvoří tři černé obdélníky s modrými obrysy širokými 15 bodů. Nastaví [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) na miter, bevel a round hodnoty z [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/), aby porovnal, jak jsou rohy vykresleny.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Omezení miterových spojů u ostrých rohů**

Použijte [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) spolu s [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) nastaveným na [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) k omezení, jak daleko může ostrý roh vystupovat.

Limit je poměr vzdálenosti mezi vnitřním a vnějším rohem spoje k šířce čáry. Například hodnota `8` povoluje délku miteru až osmnásobek šířky čáry; nejde o měření v bodech. Pokud by roh překročil limit, PowerPoint použije na tomto rohu zkosený spoj. Větší limit umožňuje ostřejší špičky. Nastavení ovlivňuje pouze miterové spoje a změna nemá viditelný dopad, pokud roh zůstane v obou limitech.

Tento příklad vytvoří dva identické nevyplněné trojúhelníky s obrysy širokými 20 bodů. Levý trojúhelník používá limit `2` a pravý `8`. Každý trojúhelník je široký 80 bodů a vysoký 160 bodů, což dává jeho hornímu rohu poměr délky miteru k šířce čáry přibližně `4.12`. V důsledku toho PowerPoint zkosení levého vrcholu zruší a pravý zachová.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Výsledek v PowerPointu: **Miter limit 2** vlevo a **miter limit 8** vpravo.

![Zkosený vrchol s limitem miteru 2 a špičatý vrchol s limitem miteru 8 v PowerPointu](miter-limits.png)

## **Gradientová výplň**

Gradientová výplň míchá barvy napříč tvarem. Tento příklad vyplní elipsu lineárním gradientem pod úhlem 45 stupňů z červené do fialové pomocí [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/). Metoda [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) umisťuje barevné zastávky na 0 a 1, na začátek a konec gradientu. Vymazání existujících zastávek zajišťuje, že jsou použity jen tyto dvě barvy.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Výsledek:

![Elipsa s gradientovou výplní](gradient-fill.png)

Pokud gradient v exportovaném obrázku vypadá jinak než v PowerPointu, podívejte se na [Choose a Gradient Rendering Style](/slides/cs/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Můžete vybrat styl vykreslování bez změny gradientové výplně uložené v prezentaci.

### **Nastavení úhlu lineárního gradientu**

Použijte [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) k ovládání orientace lineární výplně [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/). Úhel se měří ve stupních a roste po směru hodinových ručiček: `0` běží zleva doprava, `90` shora dolů, `180` zprava doleva a `270` zdola nahoru. Podporovány jsou i zlomkové úhly. Konečné úhly mimo interval `[0, 360)` se normalizují na jednu otáčku; například `-45` se stane `315` a `360` se stane `0`.

Tento příklad vytvoří šest obdélníků se stejnými červenými, zelenými a modrými zastávkami na pozicích `0`, `0.5` a `1`. Škálování je vypnuto, aby bylo možné porovnat úhel nezávisle na proporcích obdélníků. Úhly, zleva doprava, jsou `0`, `45` a `90` v první řadě a `135`, `180` a `270` ve druhé řadě.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Výsledek v PowerPointu:

![Lineární gradienty při 0, 45 a 90 stupních v horním řádku, a 135, 180 a 270 stupních ve spodním řádku](linear-gradient-angles.png)

### **Škálování lineárního gradientu podle tvaru**

[IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) přijímá hodnotu [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/). Nastavte ji explicitně na `False`, aby úhel gradientu zůstal geometricky stejný při změně proporcí tvaru, nebo na `True`, aby se gradient škáloval s šířkou a výškou tvaru. Při povoleném škálování se viditelný úhel může lišit od přiřazeného úhlu u netrvalých tvarů.

Následující příklad používá úhel `45` stupňů a stejné barevné zastávky jako při porovnání úhlů. Levý sloupec používá `False`; pravý sloupec používá `True`. Každý sloupec obsahuje široký obdélník nad vysokým obdélníkem. Oba začínají se stejnými širokými rozměry; změna šířky a výšky druhého obdélníku ukazuje, jak se výplň chová při změně velikosti bez změny nastavení gradientu.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Výsledek v PowerPointu, s vypnutým škálováním vlevo a zapnutým vpravo:

![Široké a vysoké obdélníky s 45‑stupňovým gradientem, porovnání LinearGradientScaled False vlevo a True vpravo](linear-gradient-scaling.png)

S vypnutým škálováním si šikmé barevné pásy zachovávají stejnou orientaci v obou obdélnících. S povoleným škálováním se pásy roztahují s proporcemi tvaru. To pomáhá reprodukovat gradient šablony při úpravě tvaru na jinou velikost. Na čtverci povolení škálování nemění vzhled tohoto 45‑stupňového gradientu.

Obě nastavení úhlu i škálování se vztahují na lineární gradienty. Nepředstavují náhradu za [GradientShape.Radial nebo GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/).

### **Kombinování úhlu se směrem gradientu**

[IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) vybírá styl gradientu z výčtu [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/); není to náhrada za číselný úhel. Pro lineární gradient mohou styly rohu změnit oblast, na které jsou barvy rozloženy, aniž by se měnil [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/). Při porovnávání úhlů nebo škálování nechte směr beze změny.

Následující příklad aplikuje stejná nastavení v opačném pořadí. Oba obdélníky mají stejný vzhled: přiřazení směru před nebo po úhlu nemění výsledek.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Vzorová výplň**

Vzorová výplň aplikuje dvoubarevný návrh, například tečky, pruhy nebo šachovnici. Tento příklad používá [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) k výběru vzoru “trellis”. [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) poskytuje světle šedé pozadí a [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) dodává žlutou barvu vzoru.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Výsledek:

![Obdélník s vzorovou výplní](pattern-fill.png)

## **Obrázková výplň**

Obrázková výplň používá obrázek uvnitř tvaru. Tento příklad vyžaduje místní obrázek a používá [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) k jeho načtení do kolekce obrázků prezentace. Nastavením [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) na režim dlaždic opakujete obrázek uvnitř obdélníku. Zdrojový obrázek použitý zde je zobrazen níže:

![Obrázek lotosu](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Výsledek:

![Tvar s obrázkovou výplní](picture-fill.png)

### **Dlaždicovat obrázek jako texturu**

Pokud chcete nastavit dlaždicovaný obrázek jako texturu a přizpůsobit chování dlaždicování, můžete použít následující vlastnosti rozhraní [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) a třídy [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/):

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Nastavuje režim obrázkové výplně — buď `Tile`, nebo `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Určuje zarovnání dlaždic uvnitř tvaru.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Ovládá, zda je dlaždice převrácena vodorovně, svisle nebo obojí.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Nastavuje vodorovný posun dlaždice (v bodech) od počátku tvaru.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Nastavuje svislý posun dlaždice (v bodech) od počátku tvaru.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Definuje vodorovné měřítko dlaždice v procentech.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Definuje svislé měřítko dlaždice v procentech.

Tento příklad vyžaduje místní obrázek a konfiguruje [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) k jeho opakování na 50 % původní velikosti. Posuny −32 bodů posunou dlaždice vodorovně i svisle; zarovnání vpravo dole a převrácení v obou směrech určuje, jak je opakovaná textura uspořádána.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Výsledek:

![Možnosti dlaždicování](tile-options.png)

## **Jednobarevná výplň**

Jednobarevná výplň dává tvaru jednotnou barvu. Tento příklad nastaví [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na režim jednobarevné výplně a přiřadí žlutou barvu pomocí [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/), poté uloží obdélník do prezentace.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Výsledek:

![Tvar s jednobarevnou výplní](solid-color-fill.png)

### **Kopírování barev při zachování odkazů na motiv**

Použijte [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) ke kopírování definice barvy, včetně typu barvy, odkazu na motiv a transformací. To je užitečné při přenosu barvy výplně mezi tvary, které by měly i nadále sledovat motiv prezentace. Metoda kopíruje pouze barvu: nekopíruje typ výplně, obrys ani jiné formátování tvaru. Nastavte cílové [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) explicitně.

Tento příklad vytvoří tři obdélníky, zleva doprava: zdroj, kopii citlivou na motiv a pevnou RGB kopii. Zdroj používá [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) k odkazu na první akcentní barvu a přidává odstín pomocí [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/). RGB kopie používá efektivní barvu výplně ze zdroje, takže všechny tři vypadají identicky. Přiřazením [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) nastavíte pevnou RGB hodnotu a vymažete všechny existující transformace barvy.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

Před změnou motivu všechny tři výplně odpovídají:

![Zdroj, cíl CopyFrom a pevný RGB cíl s identickými modrými výplněmi](color-copy-before.png)

Po změně motivu zdroj a kopie citlivá na motiv následují novou akcentní barvu a zachovají svůj odstín. Pevná RGB kopie zůstane modrá:

![Zdroj a cíl CopyFrom s oranžovými výplněmi, zatímco pevný RGB cíl zůstává modrý](color-copy-after.png)

Zkopírovaná definice je nezávislá na zdroji. Následná změna odkazu na motiv ve zdroji, přiřazení jiné barvy nebo úprava transformací neovlivní cíl. Změna motivu stále ovlivní oba tvary, protože každý samostatně odkazuje na stejnou barvu motivu.

Uložení a opětovné otevření PPTX zachová [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), odkaz na motiv a kolekci [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) v kopírované barvě; neprovádí se převod na RGB.

Při kopírování mezi různými kontexty motivů, např. prezentacemi s různými akcentními paletami, se odkaz rozřeší vůči motivu cíle. Stejný odkaz a transformace tak mohou vést k jinému viditelnému výsledku. Viz [Presentation Theme](/slides/cs/net/presentation-theme/) pro více informací o konfiguraci barev motivu.

## **Použití pozadí snímku jako výplně tvaru**

Použijte [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) když má tvar odpovídat pozadí snímku, například v šabloně prezentace. Nejprve nastavte [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) na [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/), aby se odstranila jakákoli explicitní výplň. S touto kombinací tvar použije místo své výplně pozadí snímku. Pouze nastavení příznaku neodstraní existující explicitní výplň.

To se liší od [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): výplň pozadím zakrývá objekty za tvarem odpovídající oblastí pozadí snímku, zatímco žádná výplň ponechává tyto objekty viditelné. Gradient zůstává zarovnán k snímku, nikoli k jednotlivým tvarům.

Následující příklad vytvoří hlavní pozadí, které dědí snímek, a umístí magentový pruh za tři obdélníky. Levý obdélník používá pozadí, prostřední nemá výplň a pravý přepíná z výplně pozadím na explicitní oranžovou výplň.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Zdědit gradient z hlavního motivu.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Přidejte tento objekt jako první, aby byl za obdélníky.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// Zakázat výplň pozadí před aplikací explicitní výplně.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Výsledek, zleva doprava: **výplň pozadím**, **žádná výplň** a **explicitní výplň**. Magentový pruh je skryt levým a pravým obdélníkem, ale zůstává viditelný skrze prostřední obdélník.

![Výplň pozadím, žádná výplň a explicitní oranžová výplň přes magentový pruh](background-fill.png)

Stejné chování platí pro pozadí definované přímo na snímku nebo zděděné z rozvržení. Tvar používá rozlišené pozadí snímku; v příkladu jsou pozadí snímku i rozvržení nedefinována, takže je poskytuje hlavní motiv.

## **Nastavení průhlednosti**

U jednobarevné výplně řídí alfa komponenta barvy neprůhlednost: 0 je úplně průhledná a 255 úplně neprůhledná. Tento příklad používá alfa hodnotu 128 pro žlutý obdélník, což ho činí přibližně 50 % průhledným, takže pod ním ležící obdélník zůstává viditelný. Barva je přiřazena pomocí [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/).

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Výsledek:

![Průhledný tvar](shape-transparency.png)

## **Otáčení tvarů**

Použijte [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) k otáčení tvaru v rovině snímku. Úhel se měří ve stupních; tento příklad otočí obdélník o 5 stupňů po směru hodinových ručiček a uloží prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Výsledek:

![Otáčení tvaru](shape-rotation.png)

## **Přidání 3D efektů zkosení**

Použijte [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) k přidání hloubky a zkosených okrajů tvaru. Tento příklad vytvoří zelenou elipsu s oranžovým obrysem, nastaví [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) na 4 body a aplikuje kruhový horní zkosení s šířkou a výškou 6 bodů pomocí [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/). Přední ortografická kamera a trojibodové osvětlení zpřehlední zkosení.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Výsledek:

![3D efekt zkosení](3D-bevel-effect.png)

## **Přidání 3D rotačních efektů**

3D pohled tvaru je řízen nastavením kamery. Tento příklad používá [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) s úhly šířky, délky a rotace 40, 35 a 20 stupňů. Vybere izometrickou kameru pomocí [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) a vyvážené osvětlení pomocí [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/), poté uloží formátovaný obdélník.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Výsledek:

![3D rotační efekt](3D-rotation-effect.png)

## **Řízení černobílého vykreslování tvarů**

Vlastnost [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) určuje, jak se jednotlivý tvar vykresluje, když je prezentace zobrazována nebo zpracovávána v černobílém režimu. Nepovoluje samotné zobrazení v černobílé, ani nemění výplň, obrys nebo jiné formátování tvaru v normálním barevném režimu.

Použijte hodnotu z výčtu [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) k výběru požadovaného chování. Například `Automatic` nechá konverzi na rozhodnutí aplikace, `Gray` a `LightGray` používají šedé zabarvení, `BlackWhite` používá jen černou a bílou, `Black` a `White` vynutí jedinou barvu, `Color` zachová normální barvy a `Hidden` vynechá tvar v černobílém režimu. `NotDefined` znamená, že není přiřazen žádný režim na úrovni tvaru.

Tento příklad vytvoří oranžový obdélník a nastaví [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) na šedou. Uložený tvar si v normálním barevném režimu zachová oranžovou výplň a požádá aplikace, které respektují černobílé nastavení, o šedé zbarvení:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

V normálním barevném režimu obdélník zachovává oranžovou výplň. V pracovním postupu černobílého zobrazení používá šedé zbarvení, protože je nastaven na `Gray`. To vám umožní zachovat plnobarevný snímek a definovat odlišný vzhled pro tisk, náhled nebo jiné postupy, které respektují nastavení černobílého zobrazení prezentace.

## **Obnovení formátování**

Použijte [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) k obnovení pozice, velikosti a formátování zástupných objektů snímku z jejich odpovídajících zástupných objektů rozvržení. Tento příklad vyžaduje existující prezentaci s rozvržením‑spojenými zástupnými objekty a resetuje každý snímek před uložením. Tvary bez odpovídajících zástupných objektů rozvržení nejsou resetovány.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **Často kladené otázky**

**Ovlivňuje formátování tvaru konečnou velikost souboru prezentace?**

Barvy, styly čar a nastavení efektů obecně přidávají málo dat ve srovnání s vloženými obrázky a médii. Obrázkové výplně mohou zvýšit velikost souboru, protože jejich obrázky jsou uloženy v prezentaci.

**Jak mohu detekovat tvary na snímku, které mají identické formátování, abych je mohl seskupit?**

Porovnejte klíčové vlastnosti formátování každého tvaru — výplň, čára a nastavení efektů. Pokud se všechny odpovídající hodnoty shodují, považujte jejich styly za identické a logicky je seskupte, což usnadní následnou správu stylů.

**Mohu uložit sadu vlastních stylů tvarů do samostatného souboru pro opětovné použití v jiných prezentacích?**

Ano. Uložte ukázkové tvary s požadovanými styly do šablony snímků nebo souboru .POTX. Při vytváření nové prezentace otevřete šablonu, klonujte potřebné stylované tvary a znovu aplikujte jejich formátování tam, kde je to potřeba.