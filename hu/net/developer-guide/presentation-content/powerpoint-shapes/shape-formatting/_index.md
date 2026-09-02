---
title: PowerPoint alakzatok formázása .NET-ben
linktitle: Alakzatformázás
type: docs
weight: 20
url: /hu/net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat alakvonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- alakzat forgatása
- 3D lekerekített hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat C#-ban az Aspose.Slides segítségével — állítson be kitöltési, vonal- és effektus stílusokat PPT és PPTX fájlokhoz precízen és teljes körű irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhatunk a diákhoz. Mivel az alakzatok vonalakból állnak, a kontúrok módosításával vagy hatások alkalmazásával formázhatók. Emellett az alakzatok kitöltésének beállításával szabályozhatjuk a belső terület megjelenését.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for .NET felületeket és tulajdonságokat biztosít, amelyekkel az alakzatokat a PowerPointban elérhető ugyanazokkal a beállításokkal formázhatja.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzat egyéni vonalstílusát adhatja meg. A következő lépések ismertetik az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/net/aspose.slides/linestyle/)‑ját.
1. Állítsa be a vonalszélességet.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/net/aspose.slides/linedashstyle/)‑ját.
1. Állítsa be a vonal színét az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan formázzon egy téglalap `AutoShape`‑t:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusúként.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a téglalap alakzat kitöltő színét.
    shape.FillFormat.FillType = FillType.NoFill;

    // Alkalmazzon formázást a téglalap vonalaira.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Állítsa be a téglalap vonal színét.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The formatted lines in the presentation](formatted-lines.png)

## **Vázlat hatások alkalmazása alakvonalakra**

A vázlat hatás kézzel rajzolt vonalat eredményez. Használja az [IShape.LineFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/lineformat/)‑t a vonalbeállítások eléréséhez, az [ILineFormat.SketchFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformat/sketchformat/)‑t a vázlat beállításokhoz, valamint az [ISketchFormat.SketchType](https://reference.aspose.com/slides/hu/net/aspose.slides/isketchformat/sketchtype/)‑t a [LineSketchType](https://reference.aspose.com/slides/hu/net/aspose.slides/linesketchtype/) felsorolásból történő érték kiválasztásához.

Az alábbi C# kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/net/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/net/aspose.slides/linesketchtype/) használatával:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Hozzáférés az alakzat vonalformátumához és a vázlatformátumához.
var sketchFormat = shape.LineFormat.SketchFormat;

// Vázlat hatás alkalmazása.
sketchFormat.SketchType = LineSketchType.Curved;

// A formára közvetlenül hozzárendelt vázlat hatás olvasása.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// A vázlat hatás eltávolítása.
sketchFormat.SketchType = LineSketchType.None;
```

Az `ISketchFormat.SketchType` által visszaadott érték azt a beállítást jelenti, amely közvetlenül az alakzatra lett hozzárendelve. Ha a vonalformázás egy témából, mesterdiából vagy elrendezési diából öröklődik, használja az [ILineFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformat/geteffective/)‑t, férjen hozzá az [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformateffectivedata/sketchformat/)‑hez, és olvassa ki az [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/hu/net/aspose.slides/isketchformateffectivedata/sketchtype/) értékét. A hatékony érték tükrözi a ténylegesen alkalmazott formázást az öröklődés feloldása után:

```csharp
using var presentation = new Presentation("presentation.pptx");

var shape = presentation.Slides[0].Shapes[0];
var lineFormat = shape.LineFormat;

var explicitSketchType = lineFormat.SketchFormat.SketchType;
var effectiveLineFormat = lineFormat.GetEffective();
var effectiveSketchType = effectiveLineFormat.SketchFormat.SketchType;

Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
Console.WriteLine($"Effective sketch type: {effectiveSketchType}");
```

## **Csatlakozási stílusok formázása**

Az alábbi három csatlakozási típus közül választhat:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat szöggel (például egy alakzat sarkán) egyesít, a **Round** beállítást használja. Ha azonban olyan alakzatot rajzol, amelynek éles szögei vannak, előfordulhat, hogy a **Miter** opciót részesíti előnyben.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi C# kód bemutatja, hogyan hoztak létre három téglalapot (a fenti képen látható) a Miter, Bevel és Round csatlakozási beállításokkal:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá három automatikus alakzatot Rectangle típusúként.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Állítsa be minden téglalap alakzat kitöltő színét.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Állítsa be a vonalvastagságot.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Állítsa be minden téglalap vonalának színét.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Állítsa be a csatlakozási stílust.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Adjon szöveget minden téglalaphoz.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványuljon a másikba.

Íme, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)‑ját `Gradient`‑ra.
1. Adja hozzá a két kedvenc színét a definiált pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `Add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan alkalmazzon színátmenetes kitöltési hatást egy ellipszisre:

```c#
 // Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Ellipse típusúként.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon színátmenetes formázást az ellipszisre.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Állítsa be a színátmenet irányát.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Adjon hozzá két színátmenet állomást.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy két színű mintát – például pontokat, csíkokat, keresztvonalakat vagy négyzeteket – alkalmazzon egy alakzatra. A minta előtér- és háttérszíneit egyedi színekkel állíthatja be.

Az Aspose.Slides több mint 45 előre definiált mintastílust biztosít, amelyeket alakzatokra alkalmazhat a bemutatók vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használjon.

Íme, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)‑ját `Pattern`‑ra.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformat/backcolor/)‑ját.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformat/forecolor/)‑ját.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusúként.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Pattern-re.
    shape.FillFormat.FillType = FillType.Pattern;

    // Állítsa be a minta stílusát.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Állítsa be a minta háttér- és előtérszíneit.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Képek kitöltése**

A PowerPointban a Képek kitöltése egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – a képet ezzel az alakzat háttérként használva.

Íme, hogyan használja az Aspose.Slides‑t egy kép kitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)‑ját `Picture`‑ra.
1. Állítsa be a kép kitöltés módját `Tile`‑re (vagy egy másik kedvenc módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Rendelje hozzá ezt a képet a `Picture.Image` tulajdonsághoz a shape `PictureFillFormat`‑jában.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájlunk a következő képpel:

![The lotus picture](lotus.png)

Az alábbi C# kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusúként.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Állítsa be a kitöltés típusát Picture-re.
    shape.FillFormat.FillType = FillType.Picture;

    // Állítsa be a kép kitöltés módját.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
    IImage image = Images.FromFile("lotus.png");
    IPPImage presentationImage = presentation.Images.AddImage(image);
    image.Dispose();

    // Állítsa be a képet.
    shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Kép mozaikként textúrával**

Ha egy mozaik képet szeretne textúraként beállítani, és testreszabni a mozaik viselkedését, akkor a következő [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) interfész és [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/) osztály tulajdonságait használhatja:

- [PictureFillMode](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/picturefillmode/): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilealignment/): Megadja a mozaikok igazítását az alakzaton belül.
- [TileFlip](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileflip/): Szabályozza, hogy a mozaik vízszintesen, függőlegesen vagy mindkét irányban legyen-e tükrözve.
- [TileOffsetX](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileoffsetx/): Beállítja a mozaik vízszintes eltolását (pontokban) az alakzat kiindulási pontjától.
- [TileOffsetY](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileoffsety/): Beállítja a mozaik függőleges eltolását (pontokban) az alakzat kiindulási pontjától.
- [TileScaleX](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilescalex/): Meghatározza a mozaik vízszintes méretezését százalékban.
- [TileScaleY](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilescaley/): Meghatározza a mozaik függőleges méretezését százalékban.

Az alábbi kódrészlet megmutatja, hogyan adjon hozzá egy téglalap alakzatot mozaik képpel és hogyan konfigurálja a mozaik opciókat:

```c#
 // Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.Slides[0];

    // Adjon hozzá egy téglalap auto alakzatot.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Állítsa be az alakzat kitöltés típusát Picture-re.
    shape.FillFormat.FillType = FillType.Picture;

    // Töltse be a képet és adja hozzá a prezentáció erőforrásaihoz.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Rendelje hozzá a képet az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Állítsa be a kép kitöltés módját és a csempézési tulajdonságokat.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The tile options](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a tiszta háttérszín nem tartalmaz színátmenetet, textúrát vagy mintát.

Az egyszínű kitöltés alkalmazásához az Aspose.Slides segítségével kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)‑ját `Solid`‑ra.
1. Rendelje hozzá a kívánt kitöltő színt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusúként.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-ra.
    shape.FillFormat.FillType = FillType.Solid;

    // Állítsa be a kitöltés színét.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egyszínű, színátmenetes, képes vagy textúrás kitöltést alkalmaz a alakzatokra, beállíthat átlátszósági szintet a kitöltés átlátszóságának szabályozásához. A magasabb átlátszóság érték átlátszóbban jeleníti meg az alakzatot, lehetővé téve a háttér vagy az alatta lévő elemek részleges láthatóságát.

Az Aspose.Slides a szín alfa értékének módosításával teszi lehetővé az átlátszóság beállítását. Így csinálja:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/)‑t `Solid`‑ra.
1. Használja a `Color.FromArgb(alpha, baseColor)` metódust egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi C# kód bemutatja, hogyan alkalmazzon átlátszó kitöltő színt egy téglalapra:

```c#
const int alpha = 128;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy szilárd téglalap auto alakzatot.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap auto alakzatot a szilárd alakzat fölé.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi, hogy forgassa az alakzatokat a PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek elhelyezésekor, ha speciális igazításra vagy tervezési igényekre van szükség.

Alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat `Rotation` tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi C# kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusúként.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa el az alakzatot 5 fokkal.
    shape.Rotation = 5;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D lekerekített hatások hozzáadása**

Az Aspose.Slides lehetővé teszi, hogy 3D lekerekített hatásokat alkalmazzon alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D lekerekített hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/)‑ját a lekerekítési beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi C# kód megmutatja, hogyan alkalmazzon 3D lekerekített hatásokat egy alakzatra:

```c#
 // Hozzon létre egy példányt a Presentation osztályból.
 using (Presentation presentation = new Presentation())
 {
     ISlide slide = presentation.Slides[0];

     // Adjon hozzá egy alakzatot a diához.
     IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
     shape.FillFormat.FillType = FillType.Solid;
     shape.FillFormat.SolidFillColor.Color = Color.Green;
     shape.LineFormat.FillFormat.FillType = FillType.Solid;
     shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
     shape.LineFormat.Width = 2.0;

     // Állítsa be az alakzat ThreeDFormat tulajdonságait.
     shape.ThreeDFormat.Depth = 4;
     shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
     shape.ThreeDFormat.BevelTop.Height = 6;
     shape.ThreeDFormat.BevelTop.Width = 6;
     shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
     shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
     shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

     // Mentse a prezentációt PPTX fájlként.
     presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
 }
```

Az eredmény:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi, hogy 3D forgatási hatásokat alkalmazzon alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [CameraType](https://reference.aspose.com/slides/hu/net/aspose.slides/icamera/cameratype/) és [LightType](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrig/lighttype/) tulajdonságait a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

Az alábbi C# kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzatra:

```c#
// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Depth = 6;
    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Mentse a prezentációt PPTX fájlként.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![The 3D rotation effect](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi C# kód megmutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza az összes helykitöltővel ellátott alakzat helyzetét, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslide/) alapértelmezett beállításaiba:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Állítsa vissza a dián lévő minden alakzatot, amelynek helykitöltője van az elrendezésen.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**A formaformázás befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legnagyobb részét, míg a formázási paraméterek – színek, hatások, színátmenetek – metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan lehet felismerni azonos formázású alakzatokat egy dián, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatásbeállítások. Ha minden érték megegyezik, tekintse stílusaikat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egyedi alakzatifogásokat egy külön fájlba, hogy más prezentációkban is felhasználjam őket?**

Igen. Tárolja a kívánt stílusú mintaalakzatokat egy sablon‑diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges alakzatokat, és alkalmazza formázásukat a megfelelő helyeken.