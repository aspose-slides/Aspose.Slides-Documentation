---
title: Správa tvarů prezentace v .NET
linktitle: Manipulace s tvary
type: docs
weight: 40
url: /cs/net/shape-manipulations/
keywords:
- Tvar PowerPoint
- Tvar prezentace
- Tvar na snímku
- Vyhledat tvar
- Klonovat tvar
- Odstranit tvar
- Skrýt tvar
- Změnit pořadí tvaru
- Získat ID interop tvaru
- Alternativní text tvaru
- Formáty rozvržení tvaru
- Tvar jako SVG
- Tvar do SVG
- Zarovnat tvar
- Převrátit tvar
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Naučte se, jak identifikovat, klonovat, odstranit, skrýt, změnit pořadí, exportovat, zarovnat a převrátit tvary v prezentaci pomocí Aspose.Slides pro .NET."
---
## **Přehled**

Aspose.Slides for .NET představuje tvary na snímku jako uspořádanou [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/). Kolekce je zároveň místem, kde najdete a upravujete tvary, a zdrojem jejich pořadí vrstev: index `0` je nejzadnější tvar, zatímco poslední index je nejpřednější tvar.

Tento článek následuje tento model. Nejprve vysvětluje, jak spolehlivě identifikovat tvar, poté ukazuje, jak klonovat, odstraňovat, skrývat a měnit pořadí tvarů. Poslední sekce pokrývají formátování na úrovni rozvržení, export do SVG, zarovnání a nastavení převrácení. Každý příklad je nezávislý, takže můžete použít pouze operace, které váš workflow vyžaduje.

## **Identifikace a vyhledávání tvarů**

Indexy v kolekci jsou praktické při zpracování známého souboru, ale nejsou stabilními identifikátory. Přidání, odebrání nebo změna pořadí tvaru může změnit jeho index. Zvolte identifikátor podle toho, jak je prezentace vytvářena a udržována:

- [Name](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/name/) je užitečný pro šablony řízené vývojáři a snadno se kontroluje v panelu výběru PowerPointu. Jména lze upravovat a nejsou garantována jako jedinečná, proto si stanovte pojmenovací konvenci, pokud na nich kód závisí.
- [AlternativeText](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/alternativetext/) je užitečný, když popis přístupnosti nebo autorovo označení již tvar identifikuje. Je viditelný uživatelům, může být lokalizován nebo přepsán pro přístupnost a není garantován jako jedinečný. Nepřevádějte tiše smysluplný text přístupnosti na klíč databáze.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/officeinteropshapeid/) je jen pro čtení identifikátor, který je jedinečný v rámci snímku a odpovídá ID tvaru používanému interopem PowerPointu. Použijte jej při integraci s PowerPointem nebo když potřebujete jednoznačný odkaz během životnosti tvaru. Klonovaný nebo znovu vytvořený tvar je jiný tvar a získá vlastní ID.

Související vlastnost [UniqueId](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/uniqueid/) má rozsah prezentace, ale je určena pro doplňky a může být přeřazena. Neměla by být považována za trvalý externí klíč. Pokud je dlouhodobá identita zásadní, udržujte mapování v aplikačních datech a ověřujte, že očekávaný tvar stále existuje.

Následující příklad vyhledává podle `Name` s ordinální comparací a vrací interop ID v rozsahu snímku. Když šablona neobsahuje očekávaný tvar, kód nahlásí tento výsledek místo pokračování se špatným objektem.

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

## **Úprava kolekce tvarů**

Metody pro přidání, klonování, odebrání a změnu pořadí fungují na kolekci okamžitě. Pokud operace změní počet nebo pořadí tvarů, nepokračujte v používání indexů zachycených před touto operací.

### **Klonování tvaru**

[AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/addclone/) vytvoří nezávislou kopii a připojí ji do cílové kolekce. [InsertClone](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/insertclone/) také vytvoří kopii, ale umístí ji na určený index z‑řazení. Přetížení, která přijímají souřadnice, přesunou klon bez změny velikosti; přetížení s šířkou a výškou jej mohou také změnit.

Příklad vytvoří cílový snímek, klonuje popsaný obdélník dopředu a vloží druhý klon dozadu. Změny v kterémkoli klonu nemění původní tvar.

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

Klonování kopíruje obsah a formátování tvaru, včetně jeho jména a alternativního textu. Při nutnosti jedinečných hodnot přiřaďte novým logickým identifikátorům klonu. Zdroje použité složitými tvary jsou spravovány prezentací, ale klon zůstává novou položkou kolekce s novou identitou tvaru.

### **Odstranění tvarů**

[Remove](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/remove/) odstraní konkrétní objekt tvaru z jeho kolekce. Při odstraňování více shod během indexované iterace procházejte kolekci od konce, aby každý zbývající index zůstal platný.

Příklad odstraňuje každý tvar s určeným jménem. Čte `slide.Shapes[i]`, nikoli pevnou položku kolekce, a nepotřebně nekastuje tvar.

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

Po odebrání se počet tvarů a indexy následujících tvarů změní. Odkazy na neovlivněné tvary zůstávají spolehlivější než uložené indexy. Zvažte také konektory, animace a další funkce prezentace, které mohou odkazovat na odebraný objekt; odebrání viditelného tvaru může změnit více než jen vzhled snímku.

### **Skrytí tvaru**

Nastavením [Hidden](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/hidden/) na `true` zůstane tvar v kolekci, ale nebude se zobrazovat v normálním režimu prezentace. Jeho index, formátování i obsah zůstávají k dispozici kódu, takže skrytí je vhodné pro volitelné prvky, které mohou být později obnoveny.

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

Skrytí není smazání ani zabezpečení. Objekt může být stále nalezen a odkryt uživatelem nebo kódem a nadále patří do souboru prezentace.

### **Změna pořadí Z**

Překrývající se tvary se vykreslují podle pořadí v kolekci. [Reorder](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection/reorder/) přesune existující tvar na cílový index bez jeho klonování. Index `0` je zadní, `Count-1` je přední.

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

Obdélník je vytvořen jako první a zpočátku leží za elipsou. Přesunutí na poslední index jej umístí dopředu. Dokončete z‑řazení po přidání nebo klonování všech souvisejících tvarů, protože tyto operace přidávají nebo vkládají nové položky do kolekce a mohou změnit zamýšlený stack.

## **Inspekce tvarů na rozvrhových snímcích**

Normální snímky, rozvrhové snímky a hlavní snímky mají oddělené kolekce tvarů. Tvar v kolekci rozvržení není stejný objekt jako podobně umístěný tvar na normálním snímku. Prozkoumejte tvary rozvržení, když potřebujete pochopit nebo změnit formátování poskytované rozvržením.

Následující příklad čte [FillFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/fillformat/) a [LineFormat](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/lineformat/) každého tvaru rozvržení, aniž by předpokládal, že každý tvar je `AutoShape`.

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

Úprava rozvržení může ovlivnit více snímků, které ho používají. Před změnou tvaru rozvržení zjistěte, zda normální snímek dědí objekt nebo obsahuje lokální přepsání, a otestujte každý snímek využívající toto rozvržení.

## **Export tvaru do SVG**

[WriteAsSvg](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/writeassvg/) zapíše vykreslený obsah jednoho tvaru do proudu. Výsledek obsahuje samotný tvar, ne celou pozadí snímku ani sousední tvary.

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

Udržujte prezentaci otevřenou během renderování. Výstup závisí na formátování tvaru a na zdrojích, jako jsou fonty a obrázky. Pokud potřebujete celou kompozici, exportujte snímek místo jednotlivého tvaru. Volající vlastní proud a musí jej uvolnit.

## **Zarovnání tvarů**

[SlideUtil.AlignShapes](https://reference.aspose.com/slides/cs/net/aspose.slides.util/slideutil/alignshapes/) má přetížení, která zarovnávají buď všechny tvary, nebo vybrané indexy kolekce. [ShapesAlignmentType](https://reference.aspose.com/slides/cs/net/aspose.slides/shapesalignmenttype/) určuje okraj, středovou čáru nebo režim rozdělení. Nastavte `alignToSlide` na `true`, chcete-li použít okraje snímku; nastavením na `false` zarovnáte vybrané tvary relativně k sobě.

Příklad zarovná tři tvary k hornímu okraji snímku. Návratové odkazy na tvary jsou před zarovnáním převedeny na jejich aktuální indexy.

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

Zarovnání mění pozice, ne Z‑řazení. Relativní zarovnání obvykle vyžaduje alespoň dva tvary, zatímco horizontální nebo vertikální rozdělení potřebuje dostatek tvarů k definování rozestupů. Přepočítejte indexy, pokud před voláním metody měníte kolekci.

## **Převrácení tvaru**

Třída [ShapeFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/shapeframe/) ukládá pozici, velikost, horizontální a vertikální nastavení převrácení a rotaci. Její hodnoty `FlipH` a `FlipV` používají [NullableBool](https://reference.aspose.com/slides/cs/net/aspose.slides/nullablebool/): `True` zapíná převrácení, `False` jej vypíná a `NotDefined` zachovává neurčený/defaultní stav.

Vstupní prezentace níže obsahuje jeden netransformovaný tvar.

![Tvar před převrácením](shape_to_be_flipped.png)

Příklad zachová všechny ostatní hodnoty rámce a nahradí pouze dvě nastavení převrácení. To je důležité, protože přiřazení nového [Frame](https://reference.aspose.com/slides/cs/net/aspose.slides/ishape/frame/) nahrazuje celý rámec.

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

Uložený tvar je zrcadlen horizontálně i vertikálně při zachování pozice, velikosti a rotace.

![Tvar po převrácení](flipped_shape.png)

## **Často kladené otázky**

**Mám používat index kolekce jako identifikátor tvaru?**

Pouze pro krátkodobé zpracování, kdy se kolekce před použitím indexu nezmění. Upřednostněte ověřenou konvenci `Name` nebo `AlternativeText` pro vytvořené šablony, nebo `OfficeInteropShapeId` pro práci s interopem na úrovni snímku.

**Odstraňuje skrytí tvaru jej ze Z‑řazení?**

Ne. Skrytý tvar zůstává v kolekci na stejném indexu. Může být nalezen, přeuspořádán, upraven nebo znovu zviditelněn.

**Proč se klonovaný tvar objevil před jiným tvarem?**

`AddClone` přidá klon na konec kolekce, což je přední část Z‑řazení. Použijte `InsertClone` pro volbu počátečního indexu nebo `Reorder` po přidání všech tvarů.