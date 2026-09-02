---
title: Alakzat hatékony tulajdonságainak lekérése .NET-ben PowerPoint bemutatókhoz
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/net/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- fényszerkezet
- rekesz alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltés formátum
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan használja az Aspose.Slides for .NET-et a helyi, örökölt és hatékony alakzatformázás megkülönböztetésére PowerPoint bemutatókban."
---
## **A helyi, örökölt és hatékony tulajdonságok megértése**

A PowerPoint formázás több helyről is származhat. Az objektumra közvetlenül tárolt érték az **helyi érték**. Ha ez az érték nincs beállítva, a PowerPoint a szülő formázási forrásokat vizsgálja, például egy bekezdés alapértelmezését, egy szövegstílust, egy elrendezést vagy mesterdiát, egy témát vagy a bemutató szintű alapértelmezéseket. Ezek az értékek **örökölt értékek**. Az az érték, amely a teljes hierarchia feloldása után megmarad, a **hatékony érték** – az objektum megjelenítéséhez használt érték.

Például egy szövegrészlet nem definiálhatja saját betűmagasságát. Ennek helyi [FontHeight](https://reference.aspose.com/slides/hu/net/aspose.slides/ibaseportionformat/fontheight/) értéke ekkor `float.NaN`, ami azt jelenti, hogy "nincs beállítva itt." A részlet örökölhet magasságot a bekezdéséből, a bemutató alapértelmezett szövegstílusából vagy egy másik alkalmazható forrásból. A [GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/geteffective/) metódus meghívása a részlet formátumán a végleges feloldott magasságot adja vissza.

Használja a kétféle formázási adatot különböző célokra:

- Olvassa vagy módosítsa a helyi formátumobjektumot, például a [IPortionFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/) esetén, amikor szabályozni kell, hogy hol van definiálva az érték.
- Olvasson egy hatékony adatobjektumot, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformateffectivedata/) esetén, amikor a végső, megjelenített eredményre van szükség. A hatékony adatok csak olvashatók.

## **Helyi, örökölt és hatékony értékek összehasonlítása**

Az alábbi teljes példa létrehoz egy alakzatot, és a betűmagasságot a bemutató, bekezdés és részlet szintjein alkalmazza. Minden lépés kiírja az adott szinteken definiált értékeket és a ugyanazon szövegrészlethez tartozó hatékony értéket. Emellett bemutatja, miért kell a hatékony adatot a formázási módosítások után újra beolvasni.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
var textFrame = shape.AddTextFrame("Effective formatting");
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

// Define inherited values at two different levels.
// → Határozza meg az örökölt értékeket két különböző szinten.
presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 20;
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 28;

PrintFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

// A local value on the portion overrides both inherited values.
// → A részlet helyi értéke felülírja mindkét örökölt értéket.
portion.PortionFormat.FontHeight = 36;
PrintFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

// Changing an inherited value does not override an existing local value.
// → Egy örökölt érték módosítása nem felülírja a meglévő helyi értéket.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 30;
PrintFontHeights("The local value still has priority", presentation, paragraph, portion);

// Clear the local value. The portion now inherits from the paragraph again.
// → Törölje a helyi értéket. A részlet most újra a bekezdéstől örököl.
portion.PortionFormat.FontHeight = float.NaN;
PrintFontHeights("The local value is cleared", presentation, paragraph, portion);

// Clear the paragraph value. The presentation default now supplies the result.
// → Törölje a bekezdés értékét. A bemutató alapértelmezése most adja az eredményt.
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = float.NaN;
PrintFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

presentation.Save("effective-properties.pptx", SaveFormat.Pptx);

static void PrintFontHeights(string caption, Presentation presentation, IParagraph paragraph, IPortion portion)
{
    var presentationValue = presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight;
    var paragraphValue = paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight;
    var localValue = portion.PortionFormat.FontHeight;

    // Read effective data after the preceding changes.
    // → Olvassa be a hatékony adatot az előző módosítások után.
    var effectiveValue = portion.PortionFormat.GetEffective().FontHeight;

    Console.WriteLine(caption);
    Console.WriteLine($"  Presentation default: {FormatLocalValue(presentationValue)}");
    Console.WriteLine($"  Paragraph default:    {FormatLocalValue(paragraphValue)}");
    Console.WriteLine($"  Portion local:        {FormatLocalValue(localValue)}");
    Console.WriteLine($"  Portion effective:    {effectiveValue}");
}

static string FormatLocalValue(float value) => float.IsNaN(value) ? "<not set>" : value.ToString();
```

Ebben a példában a prioritás a részlet helyi formázása, majd a bekezdés formázása, végül a bemutató alapértelmezése. Más objektumoknak eltérő öröklődési láncaik lehetnek, de a szabály ugyanaz: egy konkrétabb, kifejezett érték nyer, és a [GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/geteffective/) a végső eredményt adja vissza.

## **Hatékony szövegtulajdonságok lekérése**

A szövegformázás több objektumra van szétosztva:

- [ITextFrameFormat.GetEffective()](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformat/geteffective/) megoldja a szövegkeret tulajdonságait, mint a margók, rögzítés, automatikus méretezés és a függőleges szövegirány.
- [ITextStyle.GetEffective()](https://reference.aspose.com/slides/hu/net/aspose.slides/itextstyle/geteffective/) megoldja a bekezdésformázást minden szövegstílus szintjén.
- [IParagraphFormat.GetEffective()](https://reference.aspose.com/slides/hu/net/aspose.slides/iparagraphformat/geteffective/) megoldja a bekezdés tulajdonságait, mint a Igazítás, behúzás és felsorolásjelek.
- [IPortionFormat.GetEffective()](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformat/geteffective/) megoldja a karakter tulajdonságait, mint a betűmagasság, betűtípus, szín, félkövér és dőlt.

A következő példához a `text-formatting.pptx` fájlnak legalább egy diát és egy [AutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/autoshape/) elemet kell tartalmaznia nem üres szövegkerettel. Az AutoShape megjelenhet a alakzatgyűjtemény bármely pozíciójában; a kód keres egy megfelelő objektumot, és használat előtt ellenőri.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("text-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var autoShapes = presentation.Slides[0].Shapes.OfType<IAutoShape>();
var shape = autoShapes.FirstOrDefault(candidate => HasNonEmptyText(candidate));

if (shape == null)
{
    throw new InvalidOperationException("The first slide must contain an AutoShape with non-empty text.");
}

var textFrame = shape.TextFrame;
var paragraph = textFrame.Paragraphs[0];
var portion = paragraph.Portions[0];

var textFrameEffective = textFrame.TextFrameFormat.GetEffective();
var paragraphEffective = paragraph.ParagraphFormat.GetEffective();
var portionEffective = portion.PortionFormat.GetEffective();

Console.WriteLine("Text frame margins:");
Console.WriteLine($"  Left: {textFrameEffective.MarginLeft}");
Console.WriteLine($"  Top: {textFrameEffective.MarginTop}");
Console.WriteLine($"  Right: {textFrameEffective.MarginRight}");
Console.WriteLine($"  Bottom: {textFrameEffective.MarginBottom}");
Console.WriteLine($"Paragraph alignment: {paragraphEffective.Alignment}");
Console.WriteLine($"Font height: {portionEffective.FontHeight}");
Console.WriteLine($"Bold: {portionEffective.FontBold}");

var effectiveTextStyle = textFrame.TextFrameFormat.TextStyle.GetEffective();
for (var level = 0; level < 9; level++)
{
    var levelEffective = effectiveTextStyle.GetLevel(level);
    Console.WriteLine($"Level {level} indent: {levelEffective.Indent}");
}

static bool HasNonEmptyText(IAutoShape shape)
{
    if (shape.TextFrame == null)
        return false;

    if (shape.TextFrame.Paragraphs.Count == 0)
        return false;

    return shape.TextFrame.Paragraphs[0].Portions.Count > 0;
}
```

## **Hatékony 3D tulajdonságok lekérése**

[IThreeDFormat.GetEffective()](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/geteffective/) egy [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) objektumot ad vissza, amely az összes feloldott 3D beállítást csoportosítja. Ennek [Camera](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/camera/), [LightRig](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/lightrig/), [BevelTop](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/beveltop/) és [BevelBottom](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/bevelbottom/) tulajdonságai a megfelelő hatékony adatot teszik közzé. Ezeknek a kapcsolódó beállításoknak a közös olvasása megkönnyíti egy alakzat végső 3D megjelenésének megértését.

Ehhez a példához a `shape-3d.pptx` fájlnak az első diáján legalább egy alakzatot kell tartalmaznia. Alkalmazzon 3D kamerát, megvilágítást vagy rézsút beállításokat az alakzatra, ha szeretné, hogy a kimenet az alapértelmezésektől eltérő értékeket tartalmazzon.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("shape-3d.pptx");

if (presentation.Slides.Count == 0 || presentation.Slides[0].Shapes.Count == 0)
{
    throw new InvalidOperationException("The first slide must contain a shape.");
}

var shape = presentation.Slides[0].Shapes[0];
var threeDEffective = shape.ThreeDFormat.GetEffective();

Console.WriteLine("Camera:");
Console.WriteLine($"  Type: {threeDEffective.Camera.CameraType}");
Console.WriteLine($"  Field of view: {threeDEffective.Camera.FieldOfViewAngle}");
Console.WriteLine($"  Zoom: {threeDEffective.Camera.Zoom}");

Console.WriteLine("Light rig:");
Console.WriteLine($"  Type: {threeDEffective.LightRig.LightType}");
Console.WriteLine($"  Direction: {threeDEffective.LightRig.Direction}");

Console.WriteLine("Top bevel:");
Console.WriteLine($"  Type: {threeDEffective.BevelTop.BevelType}");
Console.WriteLine($"  Width: {threeDEffective.BevelTop.Width}");
Console.WriteLine($"  Height: {threeDEffective.BevelTop.Height}");
```

## **Hatékony táblázatformázás lekérése**

A táblázat formázása származhat a táblázat stílusából, valamint a teljes táblázatra, oszlopra, sorra vagy egyéni cellára alkalmazott formátumokból. Az explicit módon meghatározott kitöltések közötti ütközések esetén a prioritás: cella, sor, oszlop, majd a teljes táblázat. Egy cella hatékony formátuma a végső formátum, amely a cella megrajzolásához használatos.

Ehhez a példához a `table-formatting.pptx` fájlnak az első diáján legalább egy táblázatot kell tartalmaznia. A táblázatnak legalább egy sorból és egy oszlopból kell állnia. A kód egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) elemet keres, ahelyett, hogy azt feltételezné, hogy a `Shapes[0]` egy táblázat.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("table-formatting.pptx");

if (presentation.Slides.Count == 0)
    throw new InvalidOperationException("The presentation contains no slides.");

var table = presentation.Slides[0].Shapes.OfType<ITable>().FirstOrDefault();

if (table == null)
    throw new InvalidOperationException("The first slide must contain a table.");

if (table.Rows.Count == 0 || table.Columns.Count == 0)
    throw new InvalidOperationException("The table must contain at least one cell.");

var tableEffective = table.TableFormat.GetEffective();
var rowEffective = table.Rows[0].RowFormat.GetEffective();
var columnEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellEffective = table[0, 0].CellFormat.GetEffective();

Console.WriteLine($"Table fill: {tableEffective.FillFormat.FillType}");
Console.WriteLine($"Row fill: {rowEffective.FillFormat.FillType}");
Console.WriteLine($"Column fill: {columnEffective.FillFormat.FillType}");
Console.WriteLine($"Final cell fill: {cellEffective.FillFormat.FillType}");
```

Ha a színre van szüksége, nem csak a kitöltés típusára, először ellenőrizze a hatékony [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/filltype/) értéket, majd olvassa el ahhoz a típushoz tartozó tulajdonságot – például a [SolidFillColor](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/solidfillcolor/) egy egyenletes kitöltéshez.

## **A hatékony adatok újraolvasása módosítások után**

A hatékony adatok leírják a formázási hierarchiát azon a ponton, amikor feloldásra kerülnek. Hívja meg újra a `GetEffective` metódust, miután megváltoztatott bármely, a hierarchiában részt vevő elemet, beleértve:

- az objektum helyi formázását;
- bekezdés vagy szövegkeret alapértelmezéseit;
- egy táblázatstílust, táblázatot, oszlopot, sort vagy cella formátumot;
- elrendezés vagy mesterdia formázását;
- téma adatokat vagy a bemutató szintű alapértelmezéseket;
- a diára hozzárendelt elrendezést vagy mestert.

Ne tartson egy hatékony adatobjektumot állandó pillanatképként. Az Aspose.Slides belsőleg gyorsítótárazhat néhány hatékony adatot, és egy későbbi `GetEffective` hívás frissítheti azt. Ha értékeket kell összehasonlítania változtatás előtt és után, másolja a szükséges skalár értékeket – például a betűmagasságot, színt, igazítást vagy a rézsú szélességet – saját változóiba a módosítás előtt.

Egy érték megváltoztatásához frissítse a megfelelő helyi formátumobjektumot, majd hívja meg a `GetEffective` metódust az eredmény ellenőrzéséhez. Maga a hatékony adatobjektum csak olvasható.

## **GYIK**

**Hogyan tudom megállapítani, melyik szint szolgáltatta a hatékony értéket?**

A hatékony adatok a végső értéket tartalmazzák, nem annak forrását. Vizsgálja meg az alkalmazandó helyi objektumokat a legspecifikusabb szintről kifelé. Szöveg esetén ez magában foglalhatja a részletet, bekezdést, szövegkeretet, elrendezést, mestert, témát és a bemutató alapértelmezéseit. A `float.NaN` vagy `null` értékek jelzik, hogy a keresés egy másik szintre folytatódik.

**Mi történik, ha egy szinten sem definiálják a tulajdonságot?**

Az Aspose.Slides a megfelelő PowerPoint vagy könyvtári alapértelmezést oldja fel. Ez a feloldott érték megjelenik a hatékony adatokban, még akkor is, ha egy helyi objektum sem definiálja explicit módon.

**Miért egyes esetekben a hatékony érték megegyezik a helyi értékkel?**

A helyi érték nyerte meg az öröklődési számítást. Ez akkor várható, amikor a tulajdonság explicit módon van beállítva az objektumon, és nincs specifikusabb szabály, amely felülírná.

**Mikor használjak helyi adatot a hatékony adat helyett?**

Használjon helyi adatot egy adott formázási szint vizsgálatához vagy szerkesztéséhez. Használjon hatékony adatot, ha az öröklődés, a téma szabályai és az alkalmazandó stílusok feloldása után a végső megjelenésre van szüksége. A [complete comparison example](#compare-local-inherited-and-effective-values) mindkettőt bemutatja egyetlen munkafolyamatban.