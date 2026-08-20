---
title: Prezentációs alakzatok kezelése .NET-ben
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szöveg
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- alakzat tükrözése
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet azonosítani, klónozni, eltávolítani, elrejteni, újrarendezni, exportálni, igazítani és tükrözni a prezentációs alakzatokat az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/)ként képviseli. A gyűjtemény egyben az a hely, ahol alakzatokat kereshet és módosíthat, valamint a rétegezési sorrend forrása: a `0` indexű alakzat a leghátrul, a legnagyobb indexű pedig a legelöl helyezkedik el.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosítsunk egy alakzatot megbízhatóan, majd megmutatja, hogyan klónozzunk, távolítsunk el, rejtsünk el és rendezzünk át alakzatokat. Az utolsó szakaszok a felületi formázást, az SVG exportot, a igazítást és a tükrözési beállításokat fedik le. Minden példa független, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató szerkesztési és karbantartási módja alapján:

- A [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/name/) hasznos fejlesztői vezérlésű sablonokhoz, és könnyen megtekinthető a PowerPoint Kiválasztási ablaktáblájában. A neveket szerkeszthető, de nem garantált a egyediségük, ezért alakítson ki egy elnevezési konvenciót, ha a kód rájuk támaszkodik.
- Az [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetext/) akkor hasznos, ha egy akadálymentesítési leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy újraírták az akadálymentesítés céljából, és nem garantált az egyedisége. Ne használja csendben adatbáziskulcsként a jelentős akadálymentesítési szöveget.
- Az [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/officeinteropshapeid/) egy csak‑olvasásra szolgáló azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítónak felel meg. Használja, ha PowerPoint‑tal integrál, vagy ha egyértelmű hivatkozásra van szükség az alakzat élettartama alatt. Egy klónozott vagy újra létrehozott alakzat más alakzat, és a saját azonosítóját kapja.

A kapcsolódó [UniqueId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/uniqueid/) tulajdonság prezentáció‑szintű, de kiegészítőkhöz készült, és újra hozzárendelhető. Nem tekinthető állandó külső kulcsnak. Ha hosszú távú azonosításra van szükség, tartsa a leképezést az alkalmazás adatában, és ellenőrizze, hogy a várt alakzat továbbra is létezik‑e.

Az alábbi példa a `Name` alapján, ordinális összehasonlítással keres, és a dián belüli interop‑azonosítót adja vissza. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelzi a helytelen objektummal való folytatás helyett.

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

Amikor egy művelet alakzat‑típusra specifikus, ellenőrizze a felületet a típus‑specifikus tagok használata előtt. Ez a példa csak akkor frissíti a szöveget és az alternatív szöveget, ha a megnevezett objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) típusú.

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

## **Az alakzategyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusai azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

Az [AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addclone/) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. Az [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/insertclone/) szintén másolatot készít, de a megadott z‑rendeleti indexen helyezi el. A koordinátákat elfogadó túlterhelések a méretet változtatás nélkül mozdítják a másolatot; a szélességet és magasságot is megadó változatok átméretezhetik is.

A példa létrehoz egy cél‑diát, a címkézett téglalapot előre klónozza, majd egy második klónt a háttérbe szúr be. Bármelyik klón módosítása nem befolyásolja a forrás‑alakzatot.

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

A klónozás átmásolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Adj új logikai azonosítókat a klónnak, ha ezeknek az értékeknek egyedinek kell lenniük. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón új gyűjteményelemként, új alakzat‑identitással jelenik meg.

### **Alakzatok eltávolítása**

A [Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/remove/) egy adott alakzat objektumot töröl a gyűjteményéből. Több egyező alakzat indexelt iteráció közbeni eltávolításakor haladjon a vég felől, hogy a maradék indexek érvényben maradjanak.

Ez a példa minden megadott névvel rendelkező alakzatot eltávolít. `slide.Shapes[i]` értéket használ, nem rögzített gyűjteményelemet, és nem kényszeríti fölöslegesen az alakzat típusát.

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

Eltávolítás után a alakzatszám és a későbbi alakzatok indexei változnak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak a mentett indexeknél. Vegye figyelembe a csatlakozókat, animációkat és egyéb prezentációs elemeket, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több, mint a dia megjelenését módosíthatja.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/hidden/) `true`‑ra állítása az alakzatot a gyűjteményben hagyja, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kódból, így az elrejtés alkalmas opcionális elemeknél, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonság. Az objektum továbbra is felfedezhető és visszakapcsolható felhasználó vagy kód által, és része marad a prezentációfájlnak.

### **Z‑rendezés módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek megrajzolásra. A [Reorder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/reorder/) egy meglévő alakzatot a kívánt indexre mozgat klónozás nélkül. A `0` index a háttér, a `Count - 1` a előtér.

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

A téglalap először jön létre, és kezdetben az ellipsz mögött helyezkedik el. A végső indexre való áthelyezése előre hozza. A z‑rendezést az összes kapcsolódó alakzat hozzáadása vagy klónozása után véglegesítse, mivel ezek a műveletek új gyűjmentemeleket fűznek vagy szúrnak be, és megváltoztathatják a kívánt réteget.

## **Alakzatok ellenőrzése elrendezési diákon**

A normál diák, elrendezési diák és mesterdiák külön alakzategyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan helyezkedő alakzat egy normál dián. Ellenőrizze az elrendezési alakzatokat, ha a formázást kell megérteni vagy módosítani, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/fillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/lineformat/) tulajdonságát olvassa, anélkül, hogy azt feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több, azt használó diára is hatással lehet. Mielőtt elrendezési alakzatot módosítana, állapítsa meg, hogy egy normál dia örökölte‑e az objektumot vagy helyi felülbírálással rendelkezik, és tesztelje az összes, az elrendezést használó diát.

## **Alakzat exportálása SVG‑be**

A [WriteAsSvg](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/writeassvg/) egy alakzat renderelt tartalmát írja egy adatfolyamba. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

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

A prezentációt a renderelés közben tartsa nyitva. A kimenet az alakzat formázásától, valamint a betűkészletek és képek erőforrásaitól függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, ne egyetlen alakzatot. A hívó birtokolja az adatfolyamot, és el kell azt választania.

## **Alakzatok igazítása**

A [SlideUtil.AlignShapes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/alignshapes/) túltöltései vagy az összes alakzatot, vagy a kiválasztott gyűjteményindexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapesalignmenttype/) megadja a szélt, középvonalat vagy elosztási módot. A `alignToSlide` értékét `true`‑ra állítva a dia széleit használja; `false` esetén a kijelölt alakzatok egymáshoz viszonyított igazítását végzi.

Ez a példa három alakzatot igazít a dia felső széléhez. A visszaadott alakzatreferenciákat a tényleges indexeikre konvertálja közvetlenül az igazítás előtt.

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

Az igazítás a pozíciókat, nem a z‑rendet változtatja. A relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő számú alakzatra van szükség a távolság meghatározásához. Ha a gyűjteményt a metódus hívása előtt módosítja, számolja újra az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, a vízszintes és függőleges tükrözés beállításait, valamint a forgatást. A `FlipH` és `FlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) típust használják: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/frame/) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja a pozícióját, méretét és forgását.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat‑azonosítóként?**

Csak rövid életű feldolgozásnál, amikor a gyűjtemény nem változik az index használata előtt. Sablonokhoz előnyben részesítsen ellenőrzött `Name` vagy `AlternativeText` konvenciót, illetve `OfficeInteropShapeId`‑t a dián belüli interop munka esetén.

**Eltávolítja-e egy rejtett alakzat a z‑rendet?**

Nem. Egy rejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat elé?**

Az `AddClone` a klónt a gyűjtemény végére fűzi, ami a z‑rendezés elöl lévő pozíciója. Használja az `InsertClone`‑t a kezdeti index kiválasztásához, vagy az `Reorder`‑t minden alakzat hozzáadása után.