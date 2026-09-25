---
title: Prezentáció alakzatok kezelése .NET-ben
linktitle: Alakzat manipuláció
type: docs
weight: 40
url: /hu/net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentáció alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat ID lekérése
- alakzat alternatív szövege
- alakzat beállítási pont
- előre definiált alakzat beállítása
- alakzat geometria
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
description: "Tanulja meg, hogyan azonosítsa, állítsa be, klónozza, távolítsa el, rejtse el, rendezze újra, exportálja, igazítsa és tükrözze a prezentáció alakzatokat az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Az Aspose.Slides for .NET a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/) képviseli. A gyűjtemény egyben az a hely, ahol az alakzatokat megtalálja és módosítja, valamint a rétegzési sorrendjének forrása: a `0` index a leghátrább alakzat, míg az utolsó index a legelső alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan lehet egy alakzatot megbízhatóan azonosítani és módosítani az előre definiált alakzatbeállítási pontokat, majd megmutatja, hogyan lehet klónozni, eltávolítani, elrejteni és újrarendezni az alakzatokat. Az utolsó szakaszok a elrendezési szintű formázást, az SVG exportot, az igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak azokat a műveleteket használhatja, amelyekre a munkafolyamatnak szüksége van.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozása során, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató szerkesztése és karbantartása módja szerint:

- [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/name/) hasznos fejlesztő által vezérelt sablonoknál, és könnyen megtekinthető a PowerPoint Kijelölési ablaktáblájában. A neveket szerkeszthető, de nem garantált, hogy egyediek, ezért alakítson ki egy elnevezési konvenciót, ha a kód rájuk támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetext/) akkor hasznos, ha egy hozzáférhetőségi leírás vagy a szerző által megadott címke már azonosítja az alakzatot. A felhasználók számára látható, lokalizálható vagy újraírásra alkalmas a hozzáférhetőség érdekében, és nem garantált, hogy egyedi. Ne használja csendben a jelentős hozzáférhetőségi szöveget adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/officeinteropshapeid/) egy csak olvasható azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzatazonosítónak felel meg. Használja, ha PowerPointtel integrál, vagy ha egyértelmű hivatkozásra van szüksége egy alakzat életciklusa alatt. Egy klónozott vagy újra létrehozott alakzat másik alakzat, és saját azonosítót kap.

A kapcsolódó [UniqueId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/uniqueid/) tulajdonságnak prezentációhatára van, de kiegészítők számára szánták, és újra hozzárendelhető. Nem szabad állandó külső kulcsként kezelni. Ha hosszú távú azonosításra van szükség, tartsa a leképezést az alkalmazás adatában, és ellenőrizze, hogy a várt alakzat még létezik-e.

A [Manage Alternative Text Titles and Descriptions](/slides/hu/net/presentation-accessibility/) cikkben gyakorlati példát láthat a cím és leírás alternatív szövegének olvasására és frissítésére. Használja az alternatív szöveget a vizuális jelentés magyarázatára az olvasók számára, és tartsa külön a kóddal keresett alakzatnevektől.

Az alábbi példa a `Name` alapján keres ordinalszerű összehasonlítással, és a diára vonatkozó interop azonosítót jelentik. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt adja vissza, ahelyett, hogy a rossz objektummal folytatná.

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

Amikor egy művelet alakzat típusra specifikus, ellenőrizze az interfészt a típus-specifikus tagok használata előtt. Ez a példa a szöveget és az alternatív szöveget csak akkor frissíti, ha a megnevezett objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/).

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

## **Előre definiált alakzatbeállítások azonosítása és módosítása**

Az előre definiált geometriai alakzatok képesek exponálni olyan beállítási pontokat, amelyek a sarkok méretét, a nyíl arányait vagy a körív szögeit szabályozzák. Ezeket a csak olvasható [IGeometryShape.Adjustments](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/adjustments/) gyűjteményen keresztül érheti el. Maga a gyűjtemény az alakzatból származik, de minden [IAdjustValue](https://reference.aspose.com/slides/hu/net/aspose.slides/iadjustvalue/) egy módosítható értéket tartalmaz.

Ne csak egy rögzített gyűjteményindexre támaszkodjon. Járja be a beállításokat, és vizsgálja meg a csak olvasható [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/type/) tulajdonságot, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz a beállítás. A csak olvasható [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/name/) további azonosítási információt ad, és különösen hasznos, ha egy előre definiált alakzat több azonos szemantikai típusú beállítást tartalmaz.

Használja a beállítás jelentésének megfelelő értéktulajdonságot:

| Adjustment type | Purpose | Value to change |
|---|---|---|
| `CornerSize` | Lekerekített sarkok mérete | [RawValue](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Nyílfarok vastagsága | `RawValue` |
| `ArrowheadLength` | Nyílhegy hossza | `RawValue` |
| `ArrowheadWidth` | Nyílhegy szélessége | `RawValue` |
| `StartAngle` | Körív vagy szelet kezdőszöge | [AngleValue](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Körív vagy szelet befejezőszöge | `AngleValue` |

A `Type` és a `Name` nem módosítható. A `RawValue` egy olvasható/írható egész szám a beállított geometria natív egységeiben, míg az `AngleValue` egy olvasható/írható fokban megadott szög. A beállítások száma, sorrendje, jelentése és érvényes tartománya a beállított [ShapeType](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/shapetype/) függvénye. Egy beállítás, amely az egyik előre definiáltnál érvényes, egy másiknál érvénytelen vagy más hatást eredményezhet.

Amikor a `Type` értéke `ShapeAdjustmentType.Custom`, az API nem ismeri fel a standard szemantikai jelentést. Vizsgálja meg a `Name`-et, a beállított típust és a meglévő értéket, és hagyja változatlanul a beállítást, hacsak nem ismeri a várt jelentést és tartományt. Még a felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször is előfordul-e, mielőtt értéket választana. A [Connector](/slides/hu/net/connector/) cikk bemutatja ezt a helyzetet a kapcsolatív hajlítási beállításokkal.

Az alábbi teljes példa három előre definiált alakzat alapértelmezett és módosított változatát hozza létre. Minden beállításon végigiterál, jelentésként megjeleníti a `Name` és `Type` értékeket, a mérettel kapcsolatos értékeket a `RawValue`, a szögeket az `AngleValue` módosítja, majd elmenti az eredményt. A bal oszlop az alapértelmezett geometriát tartja; a jobb oszlop a módosított lekerekített téglalapot, a négyszögű nyilat és a szeletet mutatja.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Hozzáadja a fejlécet az alapértelmezett és a módosított alakzat oszlopokhoz.
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

A szemantikai típus ellenőrzése érték módosítása előtt egyértelművé teszi a kód szándékát, és elkerüli, hogy egy adott gyűjteményindex különböző jelentéssel bírjon különböző előre definiált alakzatoknál.

## **Az alakzategyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és újrarendezés metódusai azonnal a gyűjteményt érintik. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

[AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addclone/) egy független másolatot hoz létre, és a célgyűjtemény végére fűzi. [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/insertclone/) szintén másolatot készít, de a megadott z-sorrend indexnél helyezi el. A koordinátákat elfogadó túlterhelések a másolat méretét változtatás nélkül mozgatják; a szélességet és magasságot megadó túlterhelések átméretezhetik is.

A példa egy cél diát hoz létre, egy címkézett téglalapot klónoz a frontra, és egy második klónt szúr be a háttérbe. Bármelyik klón módosítása nem érinti a forrás alakzatot.

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

A klónozás az alakzat tartalmát és formázását, köztük a nevét és az alternatív szövegét is másolja. Ha ezeknek az értékeknek egyedinek kell lenniük, adjon új logikai azonosítókat a klónnak. A komplex alakzatok által használt erőforrások a prezentáció által kezeltek, de a klón egy új gyűjteményelem, új alakzatidentitással.

### **Alakzatok eltávolítása**

[Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/remove/) egy adott alakzatobjektumot töröl a gyűjteményéből. Több egyezés eltávolításakor indexelt iteráció során haladjon a vég felől, hogy a maradt indexek továbbra is érvényesek maradjanak.

Ez a példa minden a kijelölt névvel rendelkező alakzatot eltávolít. `slide.Shapes[i]`-t olvas, nem egy rögzített gyűjteményelemet, és nem kényszeríti feleslegesen a típust.

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

Eltávolítás után az alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Vegye figyelembe a kapcsolatokat, animációkat és más prezentációs elemeket is, amelyek a eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása a dián megjelenő tartalmon túlmutat.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/hidden/) `true` értékre állítása megőrzi az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Indexe, formázása és tartalma továbbra is elérhető a kód számára, ezért az elrejtés alkalmas opcionális elemeknél, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonsági intézkedés. Az objektum továbbra is felfedezhető és újra láthatóvá tehető felhasználó vagy kód által, és része marad a prezentáció fájlnak.

### **Z-sorrend módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek festésre. [Reorder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/reorder/) egy létező alakzatot egy cél indexre mozgat klónozás nélkül. A `0` index a hátul, a `Count - 1` az elöl.

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

A téglalap először jön létre, és kezdetben az ellipszis mögött helyezkedik el. A végső indexre mozgatása előre helyezi. A z-sorrendet akkor állítsa be, amikor minden kapcsolódó alakzatot hozzáadta vagy klónozta, mivel ezek a műveletek új gyűjteményelemeket fűznek vagy szúrnak be, és megváltoztathatják a kívánt rétegezést.

## **Alakzatok ellenőrzése elrendezési diákon**

A normál diák, elrendezési diák és alap sablon diák külön alakzategyűjteménnyel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonlóan elhelyezett alakzat egy normál dián. Ellenőrizze az elrendezési alakzatokat, amikor a formázást szeretné megérteni vagy módosítani, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/fillformat/) és [LineFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/lineformat/) tulajdonságát olvassa, anélkül, hogy feltételezné, hogy minden alakzat egy `AutoShape`.

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

Az elrendezés szerkesztése több olyan diát is érinthet, amely a változtatást használja. Mielőtt elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökli-e az objektumot vagy helyi felülírást tartalmaz, és tesztelje az összes olyan diát, amely azt az elrendezést használja.

## **Alakzat exportálása SVG-re**

[WriteAsSvg](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/writeassvg/) egy alakzat renderelt tartalmát írja egy adatfolyamba. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia háttérjét vagy a szomszédos alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés közben. A kimenet az alakzat formázásától és olyan erőforrásoktól, mint betűkészletek és képek, függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, ne pedig egyetlen alakzatot. A hívó birtokolja az adatfolyamot, és le kell zárnia azt.

## **Alakzatok igazítása**

A [SlideUtil.AlignShapes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjteményindexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapesalignmenttype/) megadja a szélt, középső vonalat vagy elosztási módot. A `alignToSlide` `true` értéke a dia széleit használja; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítását végzi.

Ez a példa három alakzatot a dia felső széléhez igazít. A visszaadott alakzat hivatkozásokat az igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás pozíciót változtat, nem a z-sorrendet. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elegendő számú alakzat kell, hogy meghatározza a távolságot. Ha a metódus hívása előtt módosítja a gyűjteményt, újra kell számolnia az indexeket.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgatást. A `FlipH` és `FlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) típust használják: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megőrzi a nem meghatározott/ alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden egyéb keretértéket megőriz, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/frame/) hozzárendelése a teljes keret cseréjét jelenti.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megtartja pozícióját, méretét és forgatását.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjteményindexet alakzatazonosítóként?**

Csak rövid életű feldolgozás esetén, amikor a gyűjtemény nem változik az index használata előtt. Az előre szerkesztett sablonoknál részesítsen előnyben egy ellenőrzött `Name` vagy `AlternativeText` konvenciót, vagy a diára vonatkozó interop munkához használja az `OfficeInteropShapeId`-t.

**Eltávolítja-e egy elrejtett alakzat a z-sorrendet?**

Nem. Egy elrejtett alakzat a gyűjteményben ugyanazon az indexen marad. Megtalálható, újrarendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `AddClone` a klónt a gyűjtemény végére fűzi, ami a z-sorrend eleje. Az `InsertClone` segítségével választhatja ki a kezdeti indexet, vagy használja a `Reorder`-t, miután az összes alakzatot hozzáadta.

**Használhatok rögzített indexet egy előre definiált alakzatbeállítás azonosításához?**

Csak a pontos előre definiált típus és a gyűjtemény elrendezés validálása után. Inkább iteráljon a `IGeometryShape.Adjustments` gyűjteményen, és ellenőrizze az `IAdjustValue.Type` értékét; ha ugyanaz a szemantikai típus többször is előfordul, használja az `IAdjustValue.Name`-t további információként.