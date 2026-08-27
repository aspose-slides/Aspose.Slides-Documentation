---
title: Prezentációs alakzatok kezelése .NET-ben
linktitle: Alakzatmanipuláció
type: docs
weight: 40
url: /hu/net/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat azonosító lekérése
- alakzat alternatív szövege
- alakzat emelési pont
- előre meghatározott alakzat emelés
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
description: "Ismerje meg, hogyan azonosíthatja, módosíthatja, klónozhatja, eltávolíthatja, elrejtheti, átrendezheti, exportálhatja, igazíthatja és tükrözheti a prezentációs alakzatokat az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

Aspose.Slides for .NET a dián lévő alakzatokat egy rendezett [IShapeCollection](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/)ként ábrázolja. A gyűjtemény egyaránt hely, ahol az alakzatokat megtalálja és módosítja, valamint a rétegezési sorrend forrása: a `0` indexű alakzat a leghátrul, míg az utolsó indexű a legelül lévő alakzat.

Ez a cikk ezt a modellt követi. Először bemutatja, hogyan azonosítsunk egy alakzatot megbízhatóan és módosítsuk az előre meghatározott alakzatemelés‑pontokat, majd megmutatja, hogyan klónozzuk, távolítsuk el, rejtsük el és rendezzük át az alakzatokat. Az utolsó szakaszok a diasablon‑szintű formázást, az SVG‑exportot, a igazítást és a tükrözési beállításokat fedik le. Minden példa önálló, így csak a munkafolyamatához szükséges műveleteket használhatja.

## **Alakzatok azonosítása és keresése**

A gyűjtemény indexei kényelmesek egy ismert fájl feldolgozásakor, de nem stabil azonosítók. Egy alakzat hozzáadása, eltávolítása vagy átrendezése megváltoztathatja az indexét. Válasszon azonosítót a bemutató előállítási és karbantartási módja szerint:

- [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/name/) hasznos fejlesztő‑vezérelt sablonoknál, és könnyen megtekinthető a PowerPoint Kiválasztási paneljén. A neveket szerkeszthető, és nem garantált a egyediségük, ezért alakítson ki egy elnevezési konvenciót, ha a kód ezekre támaszkodik.
- [AlternativeText](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/alternativetext/) akkor hasznos, ha egy akadálymentesítési leírás vagy a szerző által megadott címke már azonosítja az alakzatot. Látható a felhasználók számára, lokalizálható vagy átírható akadálymentesítés céljából, és nem garantált az egyedisége. Ne a jelentős akadálymentesítési szöveget használja néma módon adatbáziskulcsként.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/officeinteropshapeid/) egy csak‑olvasású azonosító, amely egy dián belül egyedi, és a PowerPoint interop által használt alakzat‑azonosítónak felel meg. Használja, ha PowerPoint‑integrációt valósít meg, vagy ha egyértelmű hivatkozásra van szükség az alakzat élettartama alatt. Egy klónozott vagy újra‑létrehozott alakzat más alakzat, és saját azonosítót kap.

A kapcsolódó [UniqueId](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/uniqueid/) tulajdonság prezentáció‑szintű, de kiegészítők számára készült, és újra‑rendelhető. Nem tekinthető állandó külső kulcsnak. Ha hosszú távú azonosítás szükséges, tárolja a leképezést az alkalmazás adatbázisában, és ellenőrizze, hogy a várt alakzat még létezik‑e.

Az alábbi példa a `Name` alapján keres ordális összehasonlítással, és a diához tartozó interop‑azonosítót jelzi. Ha a sablon nem tartalmazza a várt alakzatot, a kód ezt az eredményt jelenti, ahelyett, hogy a hibás objektummal folytatná a műveletet.

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

Amikor egy művelet alakzat‑típusra specifikus, ellenőrizze az interfészt, mielőtt típus‑specifikus tagokat használna. Ez a példa a szöveget és az alternatív szöveget csak akkor frissíti, ha a megnevezett objektum egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/).

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

## **Előre meghatározott alakzatemelés módosítása**

Az előre meghatározott geometriai alakzatok olyan emelési pontokat tartalmazhatnak, amelyek például a sarkok méretét, a nyíl arányait vagy az ív szögeit vezérlik. Ezekhez a csak‑olvasású [IGeometryShape.Adjustments](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/adjustments/) gyűjteményen keresztül férhet hozzá. Maga a gyűjtemény az alakzattól származik, de minden [IAdjustValue](https://reference.aspose.com/slides/hu/net/aspose.slides/iadjustvalue/) tartalmaz egy módosítható értéket.

Ne csak egy fix gyűjtemény‑indexre támaszkodjon. Iteráljon a módosításokon, és vizsgálja a csak‑olvasású [Type](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/type/) tulajdonságot, amelynek [ShapeAdjustmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeadjustmenttype/) értéke leírja, mit szabályoz az emelés. A csak‑olvasású [Name](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/name/) további azonosítási információt nyújt, és különösen hasznos, ha egy előre meghatározott alakzat több azonos szemantikai típusú emelést tartalmaz.

Használja a jelentésnek megfelelő érték‑tulajdonságot:

| Emelés típusa | Cél | Módosítandó érték |
|---|---|---|
| `CornerSize` | Lekerekített sarkok mérete | [RawValue](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/rawvalue/) |
| `ArrowTailThickness` | Nyílfarok vastagsága | `RawValue` |
| `ArrowheadLength` | Nyílfej hossza | `RawValue` |
| `ArrowheadWidth` | Nyílfej szélessége | `RawValue` |
| `StartAngle` | Körszelet vagy ív kezdőszöge | [AngleValue](https://reference.aspose.com/slides/hu/net/aspose.slides/adjustvalue/anglevalue/) |
| `EndAngle` | Körszelet vagy ív befejezőszöge | `AngleValue` |

A `Type` és a `Name` nem módosítható. A `RawValue` egész szám, olvasási‑írási tulajdonság a preset natív geometriai egységeiben, míg az `AngleValue` fokban kifejezett szög, szintén olvasási‑írási. Az emelések száma, sorrendje, jelentése és érvényes tartománya a preset [ShapeType](https://reference.aspose.com/slides/hu/net/aspose.slides/igeometryshape/shapetype/)‑tól függ. Egy presethez érvényes érték egy másiknál érvénytelen vagy más hatást eredményezhet.

Ha a `Type` értéke `ShapeAdjustmentType.Custom`, az API nem ismeri fel a szabványos szemantikai jelentést. Vizsgálja meg a `Name`‑et, a preset típusát és a jelenlegi értéket, és hagyja változatlanul az emelést, hacsak a várt jelentés és tartomány nem ismert. Még a felismert típusok esetén is ellenőrizze, hogy ugyanaz a típus többször fordul‑e elő, mielőtt értéket választana. A [Connector](/slides/hu/net/connector/) cikk bemutatja ezt a helyzetet a csatlakozó‑görbületek esetén.

Az alábbi teljes példa három preset alakzat alap‑ és módosított változatát hozza létre. Végigiterál minden emelésen, kiírja a `Name`‑et és a `Type`‑ot, a mérettel kapcsolatos értékeket a `RawValue`‑val, a szögeket az `AngleValue`‑val módosítja, és elmenti az eredményt. A bal oszlop az alap geometriát, a jobb oszlop a módosított lekerekített téglalapot, a négyirányú nyilat és a szelet mutatja.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

// Hozzáadja a fejlécet az alap és a módosított alakzat oszlopokhoz.
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

A szemantikai típus ellenőrzése a változtatás előtt egyértelművé teszi a kód szándékát, és megakadályozza, hogy egy adott gyűjtemény‑index ugyanazt a jelentést hordozza különböző preset alakzatoknál.

## **Az alakzatgyűjtemény módosítása**

A hozzáadás, klónozás, eltávolítás és átrendezés metódusok azonnal a gyűjteményen dolgoznak. Ha egy művelet megváltoztatja az alakzatok számát vagy sorrendjét, ne támaszkodjon a művelet előtt rögzített indexekre.

### **Alakzat klónozása**

[AddClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/addclone/) független másolatot hoz létre, és a célgyűjtemény végére illeszti. [InsertClone](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/insertclone/) szintén másolatot készít, de a megadott z‑rendi indexbe helyezi. A koordinátákat elfogadó túlterhelések a klónt méretváltoztatás nélkül mozgatják; a szélesség‑magasságot tartalmazó túlterhelések átméretezhetik is.

A példa egy cél‑diát hoz létre, egy feliratos téglalapot klónoz az élre, és egy második klónt illeszt be a hátulra. Bármelyik klón módosítása nem érinti a forrásalkalmazzatot.

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

A klónozás másolja az alakzat tartalmát és formázását, beleértve a nevét és az alternatív szöveget is. Adjunk új logikai azonosítókat a klónnak, ha ezeknek az értékeknek egyedinek kell lenniük. A komplex alakzatok által használt erőforrásokat a prezentáció kezeli, de a klón egy új gyűjteményelem, új alakzat‑azonossággal.

### **Alakzatok eltávolítása**

[Remove](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/remove/) egy adott alakzat objektumot töröl a gyűjteményéből. Több egyezés eltávolításakor indexelt iteráció közben a végéről haladjon, hogy a maradék indexek érvényben maradjanak.

Ez a példa minden kijelölt névvel rendelkező alakzatot eltávolít. `slide.Shapes[i]`‑t olvas, nem egy fix gyűjteményelemet, és nem kényszeríti feleslegesen az alakzatot.

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

Eltávolítás után a alakzatszám és a későbbi alakzatok indexei megváltoznak. A nem érintett alakzatokra mutató hivatkozások megbízhatóbbak, mint a mentett indexek. Figyelembe kell venni a csatlakozókat, animációkat és egyéb prezentációs elemeket, amelyek az eltávolított objektumra hivatkozhatnak; egy látható alakzat eltávolítása több mint a dia megjelenését változtathatja meg.

### **Alakzat elrejtése**

A [Hidden](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/hidden/) `true`‑ra állítása megtartja az alakzatot a gyűjteményben, de megakadályozza, hogy a normál diavetítésben megjelenjen. Az indexe, formázása és tartalma továbbra is elérhető a kód számára, ezért az elrejtés alkalmas opcionális elemekre, amelyeket később vissza lehet állítani.

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

Az elrejtés nem törlés vagy biztonsági funkció. Az objektum továbbra is felfedezhető és visszakapcsolható felhasználó vagy kód által, és része marad a prezentációs fájlnak.

### **Z‑rendi módosítása**

Az átfedő alakzatok a gyűjtemény sorrendjében kerülnek megrajzolásra. [Reorder](https://reference.aspose.com/slides/hu/net/aspose.slides/ishapecollection/reorder/) egy meglévő alakzatot a célindexre mozgat klónozás nélkül. A `0` index a hátul, a `Count - 1` a front.

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

A téglalap először jön létre, és kezdetben az ellipsz mögött helyezkedik el. A végső indexre mozgatásával előre kerül. A z‑rendet a kapcsolódó alakzatok hozzáadása vagy klónozása után állítsa be, mert ezek a műveletek új gyűjteményelemeket illesztenek be vagy fűznek hozzá, és módosíthatják a kívánt rétegsorrendet.

## **Alakzatok vizsgálata elrendezési diákon**

Normál diák, elrendezési diák és mesterdiák külön gyűjteményekkel rendelkeznek. Egy elrendezési gyűjteményben lévő alakzat nem ugyanaz az objektum, mint egy hasonló helyen lévő alakzat egy normál dián. Vizsgálja meg az elrendezési alakzatokat, ha a formázást kell megértenie vagy módosítania, amelyet egy elrendezés biztosít.

Az alábbi példa minden elrendezési alakzat [FillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/fillformat/)‑ját és [LineFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/lineformat/)‑ját olvassa ki, anélkül, hogy feltételezné, hogy minden alakzat egy `AutoShape`.

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

Egy elrendezés szerkesztése több diára is kihatással lehet, amelyik használja azt. Mielőtt elrendezési alakzatot módosítana, határozza meg, hogy egy normál dia örökölte‑e az objektumot vagy helyi felülírást tartalmaz‑e, és tesztelje az összes olyan diát, amely az elrendezést használja.

## **Alakzat exportálása SVG‑ként**

[WriteAsSvg](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/writeassvg/) egy alakzat renderelt tartalmát írja egy adatfolyamba. Az eredmény csak az alakzatot tartalmazza, nem a teljes dia hátterét vagy a környező alakzatokat.

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

Tartsa nyitva a prezentációt a renderelés során. A kimenet az alakzat formázásától és a betűkészletek, képek stb. erőforrásoktól függ. Ha a teljes kompozícióra van szüksége, exportálja a diát, ne egyetlen alakzatot. A hívó tulajdonos a streamet, és felelős annak felhasználásról.

## **Alakzatok igazítása**

A [SlideUtil.AlignShapes](https://reference.aspose.com/slides/hu/net/aspose.slides.util/slideutil/alignshapes/) túlterhelései vagy az összes alakzatot, vagy a kiválasztott gyűjtemény‑indexeket igazítják. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/net/aspose.slides/shapesalignmenttype/) megadja a szél, a középvonal vagy az elosztási módot. Az `alignToSlide` `true` értéke a dia széleit használja; `false` esetén a kiválasztott alakzatok egymáshoz viszonyított igazítása történik.

Ez a példa három alakzatot igazít a dia felső széléhez. A visszakapott alakzat‑referenciákat az igazítás előtt az aktuális indexeikre konvertálja.

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

Az igazítás pozíciókat változtat, nem a z‑rendet. Relatív igazításhoz általában legalább két alakzat szükséges, míg a vízszintes vagy függőleges elosztáshoz elég sok alakzat kell a távolság meghatározásához. Számolja újra az indexeket, ha a gyűjteményt a metódus hívása előtt módosította.

## **Alakzat tükrözése**

A [ShapeFrame](https://reference.aspose.com/slides/hu/net/aspose.slides/shapeframe/) osztály tárolja a pozíciót, méretet, vízszintes és függőleges tükrözési beállításokat, valamint a forgást. A `FlipH` és `FlipV` értékek a [NullableBool](https://reference.aspose.com/slides/hu/net/aspose.slides/nullablebool/) típusúak: `True` engedélyezi a tükrözést, `False` letiltja, a `NotDefined` pedig megtartja a nem meghatározott/alapértelmezett állapotot.

Az alábbi bemeneti prezentáció egy nem tükrözött alakzatot tartalmaz.

![The shape before flipping](shape_to_be_flipped.png)

A példa minden más keretértéket megtart, és csak a két tükrözési beállítást cseréli le. Ez fontos, mert egy új [Frame](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/frame/) hozzárendelése a teljes keretet felülírja.

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

A mentett alakzat vízszintesen és függőlegesen tükröződik, miközben megőrzi a pozícióját, méretét és forgását.

![The shape after flipping](flipped_shape.png)

## **GYIK**

**Használjak gyűjtemény‑indexet alakzat‑azonosítóként?**

Csak rövid életű feldolgozásnál, amikor a gyűjtemény nem változik az index használata előtt. Az előre elkészített sablonoknál inkább ellenőrzött `Name` vagy `AlternativeText` konvenciót, a dia‑szintű interop munkához `OfficeInteropShapeId`‑t részesítsen előnyben.

**Az elrejtett alakzat eltűnik‑e a z‑rendből?**

Nem. Egy elrejtett alakzat a gyűjteményben marad ugyanazon az indexen. Megtalálható, átrendezhető, szerkeszthető vagy újra láthatóvá tehető.

**Miért jelent meg egy klónozott alakzat egy másik alakzat előtt?**

Az `AddClone` a klónt a gyűjtemény végére illeszti, ami a z‑rend frontja. Használja az `InsertClone`‑t a kezdeti index megadásához, vagy az `Reorder`‑t az összes alakzat hozzáadása után.

**Használhatok fix indexet egy előre meghatározott alakzatemelés azonosításához?**

Csak akkor, ha a pontos presetet és a gyűjtemény‑elrendezést előre ellenőrizte. Inkább iteráljon a `IGeometryShape.Adjustments`‑en, és ellenőrizze az `IAdjustValue.Type`‑ot; ha ugyanaz a szemantikai típus többször fordul elő, használja az `IAdjustValue.Name`‑et további információként.