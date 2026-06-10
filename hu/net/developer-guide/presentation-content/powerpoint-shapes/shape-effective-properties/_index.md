---
title: Alakzat effektív tulajdonságainak lekérése bemutatókból .NET-ben
linktitle: Effektív tulajdonságok
type: docs
weight: 50
url: /hu/net/shape-effective-properties/
keywords:
- alakzat tulajdonságai
- kamera tulajdonságai
- fény rig
- perem alakzat
- szövegdoboz
- szövegstílus
- betűmagasság
- kitöltési formátum
- PowerPoint
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, hogyan számítja és alkalmazza az Aspose.Slides for .NET az effektív alakzattulajdonságokat a pontos PowerPoint rendereléshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **effektív** tulajdonságok közötti különbséget. A helyi értékek azok, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Rész tulajdonságai egy dián.  
1. Prototípus alakzat szövegstílusai egy elrendezésen vagy mester dián, ha a rész szövegdoboz alakzata rendelkezik ilyennel.  
1. Globális szövegbeállítások egy bemutatóban.

A helyi értékek meghatározhatók vagy elhagyhatók bármely szinten. Amikor az Aspose.Slides a végső „renderelt” formázásra van szüksége, feloldja az öröklődési láncot és visszaadja a **effektív** értékeket. Azokat a helyi formátumobjektum `GetEffective` metódusának meghívásával kaphatja meg.

Az alábbi példa bemutatja, hogyan lehet hatékony értékeket lekérni. Feltételezzük, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) szövegdobozszal és legalább egy résszel rendelkezik.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

var localTextFrameFormat = shape.TextFrame.TextFrameFormat;
var effectiveTextFrameFormat = localTextFrameFormat.GetEffective();

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
var localPortionFormat = portion.PortionFormat;
var effectivePortionFormat = localPortionFormat.GetEffective();
```

{{% alert color="primary" %}}
Az effektív formázási adatok a jelenlegi, öröklődés után kiszámított formázást képviselik. A jelenlegi megvalósításban egyes effektív adatobjektumok, például az [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/iportionformateffectivedata/), lehetnek belsőleg gyorsítótárazva. A `GetEffective` újbóli meghívása a szülő‑ vagy örökölt formázás módosítása után frissítheti a gyorsítótárazott adatokat, és a korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha az effektív értékeket későbbi felhasználásra meg kell őrizni, másolja a szükséges tulajdonságokat, például betűmagasságot, kitöltőszínt, betűstílust vagy igazítást a saját adatobjektumába.
{{% /alert %}}

## **Kamera effektív tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy kamera effektív tulajdonságait. Az [ICameraEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/icameraeffectivedata/) interfész egy immutable (változtathatatlan) objektumot képvisel, amely a kamera effektív tulajdonságait tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely effektív értékeket ad a [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/) számára.

Az alábbi kódminta bemutatja, hogyan lehet lekérni a kamera effektív tulajdonságait. Feltételezzük, hogy az első dián az első alakzat 3D formázással rendelkezik.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective camera properties =");
Console.WriteLine("Type: " + threeDEffectiveData.Camera.CameraType);
Console.WriteLine("Field of view: " + threeDEffectiveData.Camera.FieldOfViewAngle);
Console.WriteLine("Zoom: " + threeDEffectiveData.Camera.Zoom);
```

## **Világítási rig effektív tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy világítási rig (light rig) effektív tulajdonságait. Az [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrigeffectivedata/) interfész egy immutable objektumot képvisel, amely a rig effektív tulajdonságait tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely effektív értékeket ad a [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/) számára.

Az alábbi kódminta bemutatja, hogyan lehet lekérni a világítási rig effektív tulajdonságait. Feltételezzük, hogy az első dián az első alakzat 3D formázással rendelkezik.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective light rig properties =");
Console.WriteLine("Type: " + threeDEffectiveData.LightRig.LightType);
Console.WriteLine("Direction: " + threeDEffectiveData.LightRig.Direction);
```

## **Alakzat perem (bevel) effektív tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi, hogy lekérje egy alakzat peremének (bevel) effektív tulajdonságait. Az [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapebeveleffectivedata/) interfész egy immutable objektumot képvisel, amely a forma effektív felszínbeli (face‑relief) tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformateffectivedata/) révén érhető el, amely effektív értékeket ad a [IThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ithreedformat/) számára.

Az alábbi kódminta bemutatja, hogyan lehet lekérni egy forma felső peremének (top bevel) effektív tulajdonságait. Feltételezzük, hogy az első dián az első alakzat 3D formázással rendelkezik.

```csharp
using var presentation = new Presentation("sample.pptx");

var slide = presentation.Slides[0];
var shape = slide.Shapes[0];

var threeDEffectiveData = shape.ThreeDFormat.GetEffective();

Console.WriteLine("= Effective shape's top face relief properties =");
Console.WriteLine("Type: " + threeDEffectiveData.BevelTop.BevelType);
Console.WriteLine("Width: " + threeDEffectiveData.BevelTop.Width);
Console.WriteLine("Height: " + threeDEffectiveData.BevelTop.Height);
```

## **Szövegdoboz effektív tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegdoboz effektív tulajdonságait. Az [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/itextframeformateffectivedata/) interfész tartalmazza a szövegdoboz effektív formázási tulajdonságait.

Az alábbi kódminta bemutatja, hogyan lehet lekérni a szövegdoboz effektív formázási tulajdonságait. Feltételezzük, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) szövegdobozszal.

```csharp
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

## **Szövegstílus effektív tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheti egy szövegstílus effektív tulajdonságait. Az [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/itextstyleeffectivedata/) interfész tartalmazza a szövegstílus effektív tulajdonságait.

Az alábbi kódminta bemutatja, hogyan lehet lekérni a szövegstílus effektív tulajdonságait. Feltételezzük, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) szövegdobozszal.

```csharp
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

## **Az effektív betűmagasság értékének lekérése**

Az Aspose.Slides segítségével lekérheti az effektív betűmagasságot. Az alábbi kód bemutatja, hogyan változik egy rész effektív betűmagassága, miután helyi betűmagasság‑értékeket állítanak be a bemutató különböző szerkezeti szintjein.

```csharp
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

## **A táblázat effektív kitöltési formátumának lekérése**

Az Aspose.Slides segítségével lekérheti a táblázat különböző részeinek effektív kitöltési formázását. Az [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/ifillformateffectivedata/) interfész tartalmazza a kitöltés effektív formázási tulajdonságait. A cella formázásának magasabb prioritása van, mint a sor formázásának, a sor formázásnak magasabb prioritása van, mint az oszlop formázásának, és az oszlop formázásnak magasabb prioritása van, mint a teljes táblázat formázásának.

Ennek eredményeként az [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/net/aspose.slides/icellformateffectivedata/) tulajdonságait használják a táblázatcella megjelenítéséhez. Az alábbi kódminta bemutatja, hogyan lehet lekérni a táblázat különböző részeinek effektív kitöltési formázását. Feltételezzük, hogy az első dián az első alakzat egy [ITable](https://reference.aspose.com/slides/hu/net/aspose.slides/itable/).

```csharp
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

**A `GetEffective` egy pillanatképet ad vissza?**  
Nem mindig. Az effektív adatok az öröklődés után kiszámított formázást képviselik, de egyes effektív adatobjektumok lehetnek belsőleg gyorsítótárazva. Egy későbbi `GetEffective` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, így a korábban lekért objektum nem tekinthető tartós pillanatképként.

**Mikor kell újra beolvasni az effektív tulajdonságokat?**  
Hívja újra a `GetEffective`‑t a helyi formázás, a szülő‑stílusok, az elrendezés, a mester vagy a bemutató szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát és a jelenlegi effektív eredményt adja vissza.

**A layout/mester dia módosítása befolyásolja a már lekért effektív tulajdonságokat?**  
Igen, de a változás a következő `GetEffective` híváskor jelenik meg. Ha egy szülő formázási forrás módosul vagy eltávolításra kerül, a korábban lekért effektív adatok elavultak lehetnek. Amint a `GetEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

**Módosíthatók az értékek az effektív adatobjektumokon keresztül?**  
Nem. Az effektív adatobjektumok csak kiszámolt értékeket tartalmaznak. A módosításokat a helyi formázási objektumokban kell elvégezni, majd újra be kell kérni az effektív értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem az elrendezésen/mesteren, sem a globális beállításokban?**  
Az effektív értéket a alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. A feloldott érték a jelenlegi effektív adatok részévé válik.

**Az effektív betűértékből meg lehet tudni, melyik szint biztosította a méretet vagy betűtípust?**  
Nem közvetlenül. Az effektív adat csak a végső értéket adja vissza. A forrást a rész, bekezdés, szövegdoboz és a szövegstílusok helyi értékeinek ellenőrzésével, valamint az elrendezés, mester és bemutató szintű értékekkel kell meghatározni.

**Miért néznek úgy ki az effektív értékek néha azonosnak a helyi értékekkel?**  
Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyen esetben az effektív érték megegyezik a helyi értékkel.

**Mikor kell effektív tulajdonságokat használni, és mikor csak a helyi tulajdonságokkal dolgozni?**  
Használja az effektív adatokat, ha az „renderelt” eredményre van szüksége az összes öröklődés alkalmazása után, például színek, behúzások vagy méretek igazításához. Ha meg akarja őrizni ezeket az értékeket a későbbi formázási változásoktól függetlenül, másolja a szükséges tulajdonságokat a saját objektumába. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, majd ha szükséges, olvassa be újra az effektív adatokat a végeredmény ellenőrzéséhez.