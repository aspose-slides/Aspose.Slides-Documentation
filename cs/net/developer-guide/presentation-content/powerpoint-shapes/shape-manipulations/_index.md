---
title: Správa tvarů prezentace v .NET
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/net/shape-manipulations/
keywords:
- tvar PowerPoint
- tvar prezentace
- tvar na snímku
- najít tvar
- klonovat tvar
- odstranit tvar
- skrýt tvar
- změnit pořadí tvaru
- získat interop ID tvaru
- alternativní text tvaru
- bod úpravy tvaru
- přednastavená úprava tvaru
- geometrie tvaru
- formáty rozložení tvaru
- tvar jako SVG
- tvar do SVG
- zarovnat tvar
- převrátit tvar
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak identifikovat, upravovat, klonovat, odstraňovat, skrývat, měnit pořadí, exportovat, zarovnávat a převracet tvary prezentace pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides for .NET představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/). Tato kolekce slouží jak k vyhledávání a úpravám tvarů, tak i jako zdroj jejich pořadí vrstvení: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar a upravit přednastavené body úprav, pak ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Závěrečné části pokrývají formátování na úrovni rozložení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít jen operace, které váš pracovní postup vyžaduje.

## **Identifikace a vyhledání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo přeuspořádání tvaru může změnit jeho index. Vyberte identifikátor podle toho, jak je prezentace tvořena a udržována:

- [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/name/) je užitečný pro šablony řízené vývojářem a snadno jej lze zkontrolovat v panelu výběru PowerPointu. Jména lze upravovat a nejsou garantována jako jedinečná, takže pokud kód na nich závisí, zavést konvenci pojmenování.
- [AlternativeText](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/alternativetext/) je užitečný, když popis přístupnosti nebo autorův štítek již tvar identifikuje. Je viditelný uživatelům, může být lokalizován nebo přepsán pro přístupnost a není garantován jako jedinečný. Nepřeměňujte tiše smysluplný text přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/officeinteropshapeid/) je jen pro čtení identifikátor, který je jedinečný v rámci snímku a odpovídá ID tvaru používanému PowerPoint interop. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá své vlastní ID.

Související vlastnost [UniqueId](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/uniqueid/) má rozsah prezentace, ale je určena pro doplňky a může být přeřazena. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita zásadní, uložte mapování v datech aplikace a ověřte, že očekávaný tvar stále existuje.

Pro praktický příklad čtení a aktualizace jak alternativního textu, tak názvu, viz [Manage Alternative Text Titles and Descriptions](/slides/cs/net/presentation-accessibility/). Používejte alternativní text k vysvětlení významu vizuálu čtenářům a oddělte jej od názvů tvarů používaných kódem pro vyhledávání tvarů.

Následující příklad vyhledává podle `Name` s ordinálním porovnáním a uvádí ID interopu v rámci snímku. Když šablona neobsahuje očekávaný tvar, kód vrátí tento výsledek místo pokračování se špatným objektem.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? targetShape = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "RevenueChart", StringComparison.Ordinal))
    {
        targetShape = shape;
        break;
    }
}

if (targetShape is null)
{
    Console.WriteLine("The shape 'RevenueChart' was not found on slide 1.");
}
else
{
    Console.WriteLine($"Found {targetShape.Name}; interop ID: {targetShape.OfficeInteropShapeId}");
}
```

Když je operace specifická pro typ tvaru, zkontrolujte rozhraní před použitím členů specifických pro typ. Tento příklad aktualizuje text a alternativní text pouze pokud je pojmenovaný objekt typu [IAutoShape](https://reference.aspose.com/slides/cs/net/aspose.slides/iautoshape/).

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

IShape? candidate = null;
foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "StatusLabel", StringComparison.Ordinal))
    {
        candidate = shape;
        break;
    }
}

if (candidate is IAutoShape autoShape)
{
    autoShape.TextFrame.Text = "Approved";
    autoShape.AlternativeText = "Approval status: approved";
    presentation.Save("identified-shape.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("'StatusLabel' is missing or is not an AutoShape.");
}
```

## **Identifikace a úprava přednastavených úprav tvarů**

Tvary s přednastavenou geometrií mohou mít body úprav, které řídí například velikost rohu, proporce šipek nebo úhly oblouků. Přistupujte k nim přes jen pro čtení kolekci [IGeometryShape.Adjustments](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/adjustments/). Kolekci samotnou poskytuje tvar, ale každý [IAdjustValue](https://reference.aspose.com/slides/cs/net/aspose.slides/iadjustvalue/) obsahuje hodnotu, kterou lze změnit.

Nespoléhejte pouze na pevný index kolekce. Procházejte úpravy a kontrolujte jen pro čtení vlastnost [Type](https://reference.aspose.com/slides/cs/net/aspose.slides/adjustvalue/type/), jejíž hodnota [ShapeAdjustmentType](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeadjustmenttype/) popisuje, co úprava ovládá. Jen pro čtení vlastnost [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/adjustvalue/name/) poskytuje další identifikační informace a je zvláště užitečná, když přednastavení obsahuje více úprav se stejným sémantickým typem.

Použijte hodnotovou vlastnost, která odpovídá významu úpravy:

| Typ úpravy | Účel | Hodnota ke změně |
|---|---|---|
| `CornerSize` | Velikost zaoblených rohů | [RawValue](https://reference.aspose.com/slides/cs/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Tloušťka ocasu šipky | `RawValue` |
| `ArrowheadLength` | Délka špičky šipky | `RawValue` |
| `ArrowheadWidth` | Šířka špičky šipky | `RawValue` |
| `StartAngle` | Počáteční úhel výseče nebo oblouku | [AngleValue](https://reference.aspose.com/slides/cs/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Koncový úhel výseče nebo oblouku | `AngleValue` |

`Type` a `Name` nelze přiřazovat. `RawValue` je čtení/zápis celé číslo v nativních jednotkách geometrie přednastavení, zatímco `AngleValue` je čtení/zápis úhel ve stupních. Počet, pořadí, význam a platný rozsah úprav závisí na přednastaveném [ShapeType](https://reference.aspose.com/slides/cs/net/aspose.slides/igeometryshape/shapetype/). Hodnota platná pro jedno přednastavení může být neplatná nebo mít jiný efekt pro jiné.

Když je `Type` rovno `ShapeAdjustmentType.Custom`, API nepozná standardní sémantický význam. Prozkoumejte `Name`, typ přednastavení a existující hodnotu a ponechte úpravu nezměněnou, pokud nejsou známé očekávaný význam a rozsah. I pro rozpoznané typy zkontrolujte, zda se stejný typ vyskytuje vícekrát, než vyberete hodnotu. Článek [Connector](/slides/cs/net/connector/) ukazuje tuto situaci s úpravami zakřivení spojnic.

Následující kompletní příklad vytváří výchozí a upravené verze tří přednastavených tvarů. Prochází každou úpravu, uvádí její `Name` a `Type`, mění hodnoty související s velikostí pomocí `RawValue`, mění úhly pomocí `AngleValue` a ukládá výsledek. Levý sloupec zachovává výchozí geometrii; pravý sloupec zobrazuje upravený zaoblený obdélník, čtyřsměrovou šipku a výseč.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Přidá záhlaví pro výchozí a upravené sloupce tvarů.
var defaultColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 20, 250, 30);
defaultColumnLabel.TextFrame.Text = "Default preset geometry";
var adjustedColumnLabel = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 390, 20, 250, 30);
adjustedColumnLabel.TextFrame.Text = "Modified adjustment values";

slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 80, 70, 160, 70);
var modifiedRoundedRectangle = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 430, 70, 160, 70);
modifiedRoundedRectangle.Name = "ModifiedRoundedRectangle";

slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 80, 180, 160, 110);
var modifiedArrow = slide.Shapes.AddAutoShape(ShapeType.QuadArrow, 430, 180, 160, 110);
modifiedArrow.Name = "ModifiedQuadArrow";

slide.Shapes.AddAutoShape(ShapeType.Pie, 95, 330, 130, 130);
var modifiedPie = slide.Shapes.AddAutoShape(ShapeType.Pie, 445, 330, 130, 130);
modifiedPie.Name = "ModifiedPie";

var shapesToAdjust = new IGeometryShape[]
{
    modifiedRoundedRectangle,
    modifiedArrow,
    modifiedPie
};

foreach (var shape in shapesToAdjust)
{
    for (var adjustmentIndex = 0; adjustmentIndex < shape.Adjustments.Count; adjustmentIndex++)
    {
        var adjustment = shape.Adjustments[adjustmentIndex];
        Console.WriteLine($"{shape.Name} / {adjustment.Name}: {adjustment.Type}");

        switch (adjustment.Type)
        {
            case ShapeAdjustmentType.CornerSize:
                adjustment.RawValue = 5000;
                break;
            case ShapeAdjustmentType.ArrowTailThickness:
                adjustment.RawValue = 25000;
                break;
            case ShapeAdjustmentType.ArrowheadLength:
                adjustment.RawValue = 30000;
                break;
            case ShapeAdjustmentType.ArrowheadWidth:
                adjustment.RawValue = 40000;
                break;
            case ShapeAdjustmentType.StartAngle:
                adjustment.AngleValue = 30;
                break;
            case ShapeAdjustmentType.EndAngle:
                adjustment.AngleValue = 300;
                break;
            case ShapeAdjustmentType.Custom:
                Console.WriteLine($"Custom adjustment '{adjustment.Name}' was not changed.");
                break;
        }
    }
}

presentation.Save("preset-shape-adjustments.pptx", SaveFormat.Pptx);
```

Kontrola sémantického typu před změnou hodnoty činí kód explicitním ohledně jeho záměru a zabraňuje předpokladu, že určitý index kolekce má stejný význam u různých přednastavených tvarů.

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odebrání a přeřazení operují na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nespoléhejte nadále na indexy zachycené před touto operací.

### **Klonování tvaru**

[AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addclone/) vytvoří nezávislou kopii a připojí ji k cílové kolekci. [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/insertclone/) také vytvoří kopii, ale umístí ji na určený index z‑řazení. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit velikost.

Příklad vytváří cílový snímek, klonuje označený obdélník dopředu a vloží druhý klon dozadu. Změny v libovolném klonu neovlivní zdrojový tvar.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var sourceSlide = presentation.Slides[0];
var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
sourceShape.Name = "SourceLabel";
sourceShape.TextFrame.Text = "Source";

var blankLayout = presentation.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
var destinationSlide = presentation.Slides.AddEmptySlide(blankLayout);

var frontCloneShape = destinationSlide.Shapes.AddClone(sourceShape, 80, 80);
frontCloneShape.Name = "FrontClone";
if (frontCloneShape is IAutoShape frontClone)
{
    frontClone.TextFrame.Text = "Front clone";
}
else
{
    Console.WriteLine("The front clone is not an AutoShape; its text was not changed.");
}

var backCloneShape = destinationSlide.Shapes.InsertClone(0, sourceShape, 80, 180);
backCloneShape.Name = "BackClone";
if (backCloneShape is IAutoShape backClone)
{
    backClone.TextFrame.Text = "Back clone";
}
else
{
    Console.WriteLine("The back clone is not an AutoShape; its text was not changed.");
}

presentation.Save("cloned-shapes.pptx", SaveFormat.Pptx);
```

Klonování kopíruje obsah a formátování tvaru, včetně jeho názvu a alternativního textu. Přidělte novým klonům logické identifikátory, pokud musí být tyto hodnoty jedinečné. Zdroje používané složitými tvary spravuje prezentace, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranění tvarů**

[Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/remove/) smaže konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během iterace s indexy procházejte od konce, aby každý zbývající index zůstal platný.

Tento příklad odstraňuje každý tvar s určeným názvem. Čte `slide.Shapes[i]`, ne pevnou položku kolekce, a nepřetypovává tvar zbytečně.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var keepShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
keepShape.Name = "Keep";

var firstTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
firstTemporaryShape.Name = "Temporary";

var secondTemporaryShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
secondTemporaryShape.Name = "Temporary";

for (var i = slide.Shapes.Count - 1; i >= 0; i--)
{
    var shape = slide.Shapes[i];
    if (string.Equals(shape.Name, "Temporary", StringComparison.Ordinal))
    {
        slide.Shapes.Remove(shape);
    }
}

presentation.Save("removed-shapes.pptx", SaveFormat.Pptx);
```

Po odebrání se mění počet tvarů a indexy následujících tvarů. Odkazy na nedotčené tvary zůstávají spolehlivější než uložené indexy. Zvažte také spojnice, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavením [Hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/hidden/) na `true` ponecháte tvar v kolekci, ale zabráníte jeho zobrazení v běžné promítací sekvenci. Jeho index, formátování a obsah zůstávají dostupné kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var visibleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
visibleShape.Name = "VisibleLabel";

var optionalShape = slide.Shapes.AddAutoShape(ShapeType.Moon, 240, 40, 100, 100);
optionalShape.Name = "OptionalDecoration";

foreach (var shape in slide.Shapes)
{
    if (string.Equals(shape.Name, "OptionalDecoration", StringComparison.Ordinal))
    {
        shape.Hidden = true;
    }
}

presentation.Save("hidden-shape.pptx", SaveFormat.Pptx);
```

Skrytí není smazání ani zabezpečení. Objekt může být nadále objeven a odskryt uživatelem nebo kódem a zůstává součástí souboru prezentace.

### **Změna Z‑řazení**

Překrývající se tvary se vykreslují v pořadí kolekce. [Reorder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní; `Count - 1` je přední.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var blueRectangle = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
blueRectangle.Name = "BlueRectangle";
blueRectangle.FillFormat.FillType = FillType.Solid;
blueRectangle.FillFormat.SolidFillColor.Color = Color.SteelBlue;

var orangeEllipse = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
orangeEllipse.Name = "OrangeEllipse";
orangeEllipse.FillFormat.FillType = FillType.Solid;
orangeEllipse.FillFormat.SolidFillColor.Color = Color.Orange;

slide.Shapes.Reorder(slide.Shapes.Count - 1, blueRectangle);
presentation.Save("reordered-shapes.pptx", SaveFormat.Pptx);
```

Obdélník je vytvořen jako první a nejprve leží za elipsou. Přesunutí na poslední index ho umístí dopředu. Dokončete z‑řazení po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky kolekce a mohou změnit zamýšlený zásobník.

## **Prohlížení tvarů na rozložení snímků**

Normální snímky, rozložení a hlavní snímky mají samostatné kolekce tvarů. Tvar v kolekci rozložení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prohlédněte si tvary rozložení, když potřebujete pochopit nebo změnit formátování poskytované rozložením.

Následující příklad čte pro každý tvar rozložení [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/fillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/lineformat/) bez předpokladu, že každý tvar je `AutoShape`.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");

foreach (var layoutSlide in presentation.LayoutSlides)
{
    foreach (var shape in layoutSlide.Shapes)
    {
        var fillType = shape.FillFormat.FillType;
        var lineWidth = shape.LineFormat.Width;
        Console.WriteLine($"{layoutSlide.Name} / {shape.Name}: fill={fillType}, line width={lineWidth}");
    }
}
```

Úprava rozložení může ovlivnit více snímků, které jej používají. Před změnou tvaru rozložení zjistěte, zda normální snímek objekt dědí nebo obsahuje místní přepsání, a otestujte každý snímek, který dané rozložení používá.

## **Export tvaru do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje tvar, nikoli celé pozadí snímku nebo sousední tvary.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

if (slide.Shapes.Count == 0)
{
    Console.WriteLine("Slide 1 does not contain a shape to export.");
}
else
{
    var shape = slide.Shapes[0];
    using var svgStream = File.Create("shape.svg");
    shape.WriteAsSvg(svgStream);
}
```

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou písma a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uvolnit.

## **Zarovnání tvarů**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/alignshapes/) mají přetížení, která zarovnávají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/net/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true`, chcete-li použít okraje snímku; nastavte na `false` pro zarovnání vybraných tvarů vůči sobě navzájem.

Tento příklad zarovnává tři tvary k hornímu okraji snímku. Vrácené odkazy na tvary jsou okamžitě převedeny na jejich aktuální indexy před zarovnáním.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
var thirdShape = slide.Shapes.AddAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
firstShape.Name = "FirstAlignedShape";
secondShape.Name = "SecondAlignedShape";
thirdShape.Name = "ThirdAlignedShape";

var shapeIndexes = new[]
{
    slide.Shapes.IndexOf(firstShape),
    slide.Shapes.IndexOf(secondShape),
    slide.Shapes.IndexOf(thirdShape)
};

SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
presentation.Save("aligned-shapes.pptx", SaveFormat.Pptx);
```

Zarovnání mění pozice, nikoli Z‑řazení. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů k definování mezery. Přepočítejte indexy, pokud upravujete kolekci před voláním metody.

## **Překlopení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeframe/) ukládá pozici, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `FlipH` a `FlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/net/aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává nedefinovaný/výchozí stav.

Vstupní prezentace níže obsahuje jeden neobrácený tvar.

![The shape before flipping](shape_to_be_flipped.png)

Příklad zachovává všechny ostatní hodnoty rámce a nahrazuje pouze dvě nastavení převrácení. To je důležité, protože při přiřazení nového [Frame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/frame/) se nahradí celý rámec.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var shape = presentation.Slides[0].Shapes[0];
var frame = shape.Frame;

Console.WriteLine($"Horizontal flip before change: {frame.FlipH}");
Console.WriteLine($"Vertical flip before change: {frame.FlipV}");

shape.Frame = new ShapeFrame(
    frame.X, frame.Y, frame.Width, frame.Height,
    NullableBool.True, NullableBool.True, frame.Rotation);

presentation.Save("flipped-shape.pptx", SaveFormat.Pptx);
```

Uložený tvar je zrcadlen horizontálně i vertikálně, přičemž si zachovává pozici, velikost a rotaci.

![The shape after flipping](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřený konvent `Name` nebo `AlternativeText` pro šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraní skrytí tvaru jeho z‑řazení?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Lze jej najít, přeřadit, upravit nebo znovu zobrazit.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`AddClone` připojí klon na konec kolekce, což je přední část Z‑řazení. Použijte `InsertClone` pro výběr počátečního indexu nebo `Reorder` po přidání všech tvarů.

**Mohu použít pevný index k identifikaci úpravy přednastaveného tvaru?**

Pouze po ověření přesného přednastavení a rozložení kolekce. Upřednostněte iteraci přes `IGeometryShape.Adjustments` a kontrolu `IAdjustValue.Type`; použijte `IAdjustValue.Name` jako doplňující informaci, když se stejný sémantický typ objeví vícekrát.