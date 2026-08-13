---
title: Alakzat hatékony tulajdonságainak lekérése bemutatókból .NET-ben
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/net/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- világítási rig
- ferde alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan számítja és alkalmazza az Aspose.Slides for .NET a hatékony alakzat tulajdonságokat a pontos PowerPoint rendereléshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és a **hatékony** (effective) tulajdonságok közötti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Rész tulajdonságai egy dián.
2. Prototípus alakzat szövegstílusai egy elrendezésen vagy mesterdián, ha a rész szövegkeret alakzatának van ilyen.
3. Globális szövegbeállítások egy bemutatóban.

A helyi értékek meghatározhatók vagy elhagyhatók bármely szinten. Amikor az Aspose.Slides-nek szüksége van a végső „renderelt” formázásra, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a `GetEffective` metódus helyi formátumobjektumra hívásával kérheted le.

Az alábbi példa bemutatja, hogyan lehet hatékony értékeket lekérni. Feltételezi, hogy az első dián lévő első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) szövegkerettel és legalább egy részzel rendelkezik.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="info" %}}
A hatékony formázási adatok az öröklődés alkalmazása után a jelenlegi számított formázást képviselik. A jelenlegi megvalósításban egyes hatékony adatobjektumok, például az [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformateffectivedata/), belsőleg gyorsítótárban is tárolhatók. A szülő- vagy örökölt formázás módosítása után a `GetEffective` újrahívása frissítheti a gyorsítótárat, és egy korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha a hatékony értékeket későbbi újrahasználatra kell megőrizned, másold át a szükséges tulajdonságokat, például a betűmagasságot, kitöltőszínt, betűstílust vagy igazítást a saját adatobjektumodba.
{{% /alert %}}

## **A kamera hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. Az [ICameraEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/icameraeffectivedata/) interfész egy immutable objektumot képvisel, amely a hatékony kamera tulajdonságokat tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely a [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/) számára biztosítja a hatékony értékeket.

Az alábbi kódrészlet bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián lévő első alakzat 3D formázással rendelkezik.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **A világítási rig hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a világítási rig hatékony tulajdonságainak lekérését. Az [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrigeffectivedata/) interfész egy immutable objektumot képvisel, amely a hatékony világítási rig tulajdonságokat tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely a [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/) számára biztosítja a hatékony értékeket.

Az alábbi kódrészlet bemutatja, hogyan lehet a világítási rig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián lévő első alakzat 3D formázással rendelkezik.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **A bevel alakzat hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a bevel (ferde) alakzat hatékony tulajdonságainak lekérését. Az [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapebeveleffectivedata/) interfész egy immutable objektumot képvisel, amely a alakzat hatékony felület-relief tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely a [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/) számára biztosítja a hatékony értékeket.

Az alábbi kódrészlet bemutatja, hogyan lehet egy alakzat felső bevelének hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián lévő első alakzat 3D formázással rendelkezik.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Szövegkeret hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheted egy szövegkeret hatékony tulajdonságait. Az [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformateffectivedata/) interfész a hatékony szövegkeret formázási tulajdonságokat tartalmazza.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegkeret hatékony formázási tulajdonságait lekérni. Feltételezi, hogy az első dián lévő első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) szövegkerettel rendelkezik.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var textFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = textFrameFormat.GetEffective();

Console.WriteLine("Anchoring type: " + effectiveTextFrameFormat.AnchoringType);
Console.WriteLine("Autofit type: " + effectiveTextFrameFormat.AutofitType);
Console.WriteLine("Text vertical type: " + effectiveTextFrameFormat.TextVerticalType);
Console.WriteLine("Margins");
Console.WriteLine("   Left: " + effectiveTextFrameFormat.MarginLeft);
Console.WriteLine("   Top: " + effectiveTextFrameFormat.MarginTop);
Console.WriteLine("   Right: " + effectiveTextFrameFormat.MarginRight);
Console.WriteLine("   Bottom: " + effectiveTextFrameFormat.MarginBottom);
```

## **Szövegstílus hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheted egy szövegstílus hatékony tulajdonságait. Az [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/itextstyleeffectivedata/) interfész a hatékony szövegstílus tulajdonságokat tartalmazza.

Az alábbi kódrészlet bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián lévő első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) szövegkerettel rendelkezik.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var effectiveTextStyle = shape.TextFrame.TextFrameFormat.TextStyle.GetEffective();
var levelCount = 9;

for (var levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    var effectiveStyleLevel = effectiveTextStyle.GetLevel(levelIndex);
    Console.WriteLine("= Effective paragraph formatting for style level #" + levelIndex + " =");

    Console.WriteLine("Depth: " + effectiveStyleLevel.Depth);
    Console.WriteLine("Indent: " + effectiveStyleLevel.Indent);
    Console.WriteLine("Alignment: " + effectiveStyleLevel.Alignment);
    Console.WriteLine("Font alignment: " + effectiveStyleLevel.FontAlignment);
}
```

## **A hatékony betűmagasság értékének lekérése**

Az Aspose.Slides segítségével lekérheted a hatékony betűmagasságot. Az alábbi kód bemutatja, hogyan változik egy rész hatékony betűmagassága, amikor a helyi betűmagasság-értékeket különböző bemutató-szerkezet szinteken állítják be.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
autoShape.AddTextFrame("");

var paragraph = autoShape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var firstPortion = new Portion("Sample text with first portion");
var secondPortion = new Portion(" and second portion.");

paragraph.Portions.Add(firstPortion);
paragraph.Portions.Add(secondPortion);

var firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
var secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height just after creation:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.DefaultTextStyle.GetLevel(0).DefaultPortionFormat.FontHeight = 24;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting the presentation default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 40;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting paragraph default font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

firstPortion.PortionFormat.FontHeight = 55;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #0 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

secondPortion.PortionFormat.FontHeight = 18;
firstPortionFormatEffectiveData = firstPortion.PortionFormat.GetEffective();
secondPortionFormatEffectiveData = secondPortion.PortionFormat.GetEffective();

Console.WriteLine("Effective font height after setting portion #1 font height:");
Console.WriteLine("Portion #0: " + firstPortionFormatEffectiveData.FontHeight);
Console.WriteLine("Portion #1: " + secondPortionFormatEffectiveData.FontHeight);

presentation.Save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
```

## **A táblázat hatékony kitöltési formátumának lekérése**

Az Aspose.Slides segítségével lekérheted a különböző táblázatrészek hatékony kitöltési formátumát. Az [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/) interfész a hatékony kitöltési formázási tulajdonságokat tartalmazza. A cella formázás magasabb prioritással bír, mint a sor formázás, a sor formázás magasabb prioritással bír, mint az oszlop formázás, és az oszlop formázás magasabb prioritással bír, mint a teljes táblázat formázása.

Ennek eredményeként az [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/icellformateffectivedata/) tulajdonságai kerülnek felhasználásra a táblázatcellák megrajzolásához. Az alábbi kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltési formátumát lekérni. Feltételezi, hogy az első dián lévő első alakzat egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/) objektum.

```csharp
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var table = (ITable)presentation.Slides[0].Shapes[0];

var tableFormatEffective = table.TableFormat.GetEffective();
var rowFormatEffective = table.Rows[0].RowFormat.GetEffective();
var columnFormatEffective = table.Columns[0].ColumnFormat.GetEffective();
var cellFormatEffective = table[0, 0].CellFormat.GetEffective();

var tableFillFormatEffective = tableFormatEffective.FillFormat;
var rowFillFormatEffective = rowFormatEffective.FillFormat;
var columnFillFormatEffective = columnFormatEffective.FillFormat;
var cellFillFormatEffective = cellFormatEffective.FillFormat;
```

## **GYIK**

### A `GetEffective` egy pillanatképet ad vissza?

Nem mindig. A hatékony adatok az öröklődés alkalmazása után számított formázást képviselik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazottak lehetnek. Egy későbbi `GetEffective` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, ezért egy korábban lekért objektust nem szabad állandó pillanatképként kezelni.

### Mikor kell újra beolvasni a hatékony tulajdonságokat?

Hívd meg újra a `GetEffective` metódust, miután helyi formázást, szülőstílusokat, elrendezésformázást, mesterformázást vagy a bemutató szintű alapértelmezéseket módosítottad. A következő hívás újra értékeli a formázási hierarchiát, és a jelenlegi hatékony eredményt adja vissza.

### A layout/mester dia módosítása vagy eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?

Igen, de a változás csak a következő `GetEffective` híváskor jelenik meg. Ha egy szülő formázási forrás módosul vagy eltávolításra kerül, a korábban lekért hatékony adatok elavulhatnak. Amint a `GetEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

### Módosíthatók a hatékony adatobjektumok értékei?

Nem. A hatékony adatobjektumok csak a kiszámított értékeket exponálják. A módosításokat a helyi formázási objektumokban kell elvégezni, majd újra le kell kérni a hatékony értékeket.

### Mi történik, ha egy tulajdonság nincs beállítva az alakzat szintjén, a layout/master szintjén, sem a globális beállításokban?

A hatékony értéket a alapértelmezett mechanizmus határozza meg, amely a PowerPoint és az Aspose.Slides alapértelmezéseit tartalmazza. Ez a feloldott érték a jelenlegi hatékony adat részévé válik.

### Egy hatékony betűértékből meg tudom-e határozni, melyik szint adta meg a méretet vagy a betűtípust?

Nem közvetlenül. A hatékony adat a végső értéket adja vissza. A forrás megtalálásához ellenőrizd a helyi értékeket a rész, bekezdés, szövegkeret és a szövegstílusok (layout, master, presentation) szintjein, hogy lásd, hol jelent meg először az explicit definíció.

### Miért néznek néha az effektív értékek azonosnak a helyi értékekkel?

Mert a helyi érték végleges lett (nem volt szükség magasabb szintű öröklődésre). Ilyen esetekben az effektív érték megegyezik a helyi értékkel.

### Mikor használjam a hatékony tulajdonságokat, és mikor csak a helyi tulajdonságokkal dolgozzak?

Használd a hatékony adatot, amikor a „renderelt” eredményre van szükséged az összes öröklődés alkalmazása után, például színek, behúzások vagy méretek összehangolásához. Ha meg szeretnéd őrizni ezeket az értékeket a későbbi formázási változások ellenére, másold át a szükséges tulajdonságokat a saját objektumodba. Ha egy adott szinten szeretnél formázást módosítani, változtasd meg a helyi tulajdonságokat, majd ha szükséges, olvasd be újra a hatékony adatot a végeredmény ellenőrzéséhez.