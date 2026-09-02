---
title: PowerPoint alakzatok formázása .NET-ben
linktitle: Alakzat Formázása
type: docs
weight: 20
url: /hu/net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat vonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat renderelés
- szürkeárnyalatos alakzat renderelés
- alakzat forgatása
- 3D lekerekítési hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat C#-ban az Aspose.Slides segítségével – állítsa be a kitöltés, vonal és effektus stílusokat PPT és PPTX fájlokhoz precízen és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Továbbá beállíthatja az alakzatok belső kitöltését szabályozó beállításokat.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for .NET interfészeket és tulajdonságokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal az opciókkal formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat [vonalstílusát](https://reference.aspose.com/slides/hu/net/aspose.slides/linestyle/).  
1. Állítsa be a vonalvastagságot.  
1. Állítsa be a vonal [szaggatott stílusát](https://reference.aspose.com/slides/hu/net/aspose.slides/linedashstyle/).  
1. Állítsa be az alakzat vonalszínét.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan formázhat egy téglalap `AutoShape`‑t:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a téglalap alakzat kitöltőszínét.
    shape.FillFormat.FillType = FillType.NoFill;

    // Alkalmazza a formázást a téglalap vonalaira.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Állítsa be a téglalap vonalának színét.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlatos hatások alkalmazása az alakzat vonalaira**

A vázlatos hatás úgy teszi a vonalat, mintha kézzel rajzolták volna. Használja az [IShape.LineFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/lineformat/) interfészt a vonal beállításainak eléréséhez, az [ILineFormat.SketchFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformat/sketchformat/) interfészt a vázlat beállításaihoz, és az [ISketchFormat.SketchType](https://reference.aspose.com/slides/hu/net/aspose.slides/isketchformat/sketchtype/) interfészt a [LineSketchType](https://reference.aspose.com/slides/hu/net/aspose.slides/linesketchtype/) felsorolás értékének kiválasztásához.

Az alábbi C# kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/net/aspose.slides/linesketchtype/) hatást, olvassa ki a kifejezetten hozzárendelt értéket, és távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/net/aspose.slides/linesketchtype/) segítségével:

```csharp
using Aspose.Slides;

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

// Access the shape's line format and its sketch format.
var sketchFormat = shape.LineFormat.SketchFormat;

// Apply a sketch effect.
sketchFormat.SketchType = LineSketchType.Curved;

// Read the sketch effect assigned directly to the shape.
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");

// Remove the sketch effect.
sketchFormat.SketchType = LineSketchType.None;
```

Az `ISketchFormat.SketchType` által visszaadott érték a közvetlenül az alakzatra beállított formátumot jelenti. Ha a vonal formázását egy téma, mesterdia vagy elrendezési dia örökölheti, használja az [ILineFormat.GetEffective](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformat/geteffective/) metódust, érje el az [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ilineformateffectivedata/sketchformat/) elemet, és olvassa ki az [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/hu/net/aspose.slides/isketchformateffectivedata/sketchtype/) értékét. A hatékony érték a ténylegesen alkalmazott formázást tükrözi az öröklődés feloldása után:

```csharp
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

## **Csatlakozási stílusok formázása**

Itt a három csatlakozási típus lehetősége:

* Round  
* Miter  
* Bevel  

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögnél (például egy alakzat sarkán) kapcsol össze, a **Round** beállítást használja. Ha éles szögekkel rendelkező alakzatot rajzol, a **Miter** opció lehet előnyösebb.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi C# kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható) a Miter, Bevel és Round csatlakozási beállításokkal:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá három Rectangle típusú automatikus alakzatot.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Állítsa be a kitöltőszínt minden téglalap alakzatra.
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

    // Állítsa be a vonal színét minden téglalaphoz.
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

A PowerPointban a Színátmenetes kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy egy alakzatra folyamatos színátmenetet alkalmazzon. Például több színt is alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az alábbiak szerint alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Gradient`‑ra.  
1. Az [IGradientFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/igradientformat/) interfész által biztosított színátmenet‑állomásgyűjtemény `Add` metódusaival adja meg a kívánt színeket és pozíciókat.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazza a színátmenetes formázást az ellipszisre.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Állítsa be a színátmenet irányát.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Adjon hozzá két színátmenet‑állomást.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy olyan formázási lehetőség, amely lehetővé teszi egy két színű minta – például pontok, csíkok, keresztvonalak vagy négyzethálók – alkalmazását egy alakzatra. A minta előtér- és háttérszínét is testre szabhatja.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazva növelheti a prezentációk vizuális hatását. Még előre definiált minta választása után is megadhatja a pontos színeket, amelyeket a minta használjon.

Az alábbiak szerint alkalmazhat mintát egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Pattern`‑ra.  
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.  
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformat/backcolor/) értékét.  
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformat/forecolor/) értékét.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan alkalmazzon mintát egy téglalapra:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltést Pattern típusra.
    shape.FillFormat.FillType = FillType.Pattern;

    // Állítsa be a mintastílust.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Állítsa be a minta háttér- és előtérszíneit.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A téglalap mintás kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy olyan formázási lehetőség, amely lehetővé teszi egy kép beszúrását egy alakzatba – lényegében a képet az alakzat háttérként használja.

Az alábbiak szerint használhatja az Aspose.Slides‑t egy alakzat kép‑kitöltéséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Picture`‑ra.  
1. Állítsa be a kép kitöltési módot `Tile`‑ra (vagy egy másik kívánt módra).  
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot a kívánt képből.  
1. Rendelje hozzá ezt a képet az alakzat `PictureFillFormat`‑jának `Picture.Image` tulajdonságához.  
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy rendelkezünk egy „lotus.png” fájllal a következő képpel:

![A lotus kép](lotus.png)

Az alábbi C# kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Állítsa be a kitöltést Picture típusra.
    shape.FillFormat.FillType = FillType.Picture;

    // Állítsa be a kép kitöltési módot.
    shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

    // Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
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

![Az alakzat kép‑kitöltéssel](picture-fill.png)

### **Kép mozaikként textúra**

Ha mozaikként szeretne beállítani egy képet textúraként, és testre szabni a mozaik viselkedését, a következő [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/) osztály tulajdonságait használhatja:

- [PictureFillMode](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/picturefillmode/): A kép kitöltési módját állítja be – `Tile` vagy `Stretch`.  
- [TileAlignment](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilealignment/): A mozaikok alakzaton belüli elrendezését határozza meg.  
- [TileFlip](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileflip/): Igazítja, hogy a mozaik vízszintesen, függőlegesen vagy mindkettőnél tükröződjön.  
- [TileOffsetX](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileoffsetx/): A mozaik vízszintes eltolását (pontban) az alakzat kiindulópontjától.  
- [TileOffsetY](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileoffsety/): A mozaik függőleges eltolását (pontban) az alakzat kiindulópontjától.  
- [TileScaleX](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilescalex/): A mozaik vízszintes méretezését százalékban.  
- [TileScaleY](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilescaley/): A mozaik függőleges méretezését százalékban.

Az alábbi kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot mozaik‑képpel, és hogyan konfigurálja a mozaik beállításait:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.Slides[0];

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Állítsa be az alakzat kitöltést Picture típusra.
    shape.FillFormat.FillType = FillType.Picture;

    // Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Rendelje hozzá a képet az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Állítsa be a kép kitöltési módot és a mozaik tulajdonságait.
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

![A mozaik beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy olyan formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a tiszta háttérszín nem tartalmaz színátmeneteket, textúrákat vagy mintákat.

Az egyszínű kitöltés alkalmazásához az Aspose.Slides segítségével kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`‑ra.  
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltést Solid típusra.
    shape.FillFormat.FillType = FillType.Solid;

    // Állítsa be a kitöltőszínt.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, kép‑ vagy textúra‑kitöltést alkalmaz alakzatokra, beállíthat átlátszósági szintet is, hogy szabályozza a kitöltés átlátszóságát. Magasabb átlátszósági érték esetén az alakzat átlátszóbb lesz, és a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa‑értékének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`‑ra.  
1. Használja a `Color.FromArgb(alpha, baseColor)` metódust egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).  
1. Mentse a prezentációt.

Az alábbi C# kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy szilárd téglalap automatikus alakzatot.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet vizuális elemek pontos elhelyezésekor vagy tervezési igények esetén.

Alakzat forgatásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat `Rotation` tulajdonságát a kívánt szöggel.  
1. Mentse a prezentációt.

Az alábbi C# kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa a alakzatot 5 fokkal.
    shape.Rotation = 5;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D lekerekítési hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D lekerekítési hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D lekerekítési hatások hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) beállításait a lekerekítési paraméterek meghatározásához.  
1. Mentse a prezentációt.

Az alábbi C# kód megmutatja, hogyan alkalmazzon 3D lekerekítési hatásokat egy alakzatra:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Adj hozzá egy alakzatot a diához.
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

![A 3D lekerekítési hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.  
1. Állítsa be az alakzat [CameraType](https://reference.aspose.com/slides/hu/net/aspose.slides/icamera/cameratype/) és [LightType](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrig/lighttype/) tulajdonságait a 3D forgatás meghatározásához.  
1. Mentse a prezentációt.

Az alábbi C# kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzatra:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Hozzon létre egy példányt a Presentation osztályból.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.TextFrame.Text = "Hello, Aspose!";

    autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
    autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
    autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

    // Mentse a prezentációt PPTX fájlként.
    presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés szabályozása alakzatoknál**

Az [IShape.BlackWhiteMode](https://reference.aspose.com/slides/hu/net/aspose.slides/ishape/blackwhitemode/) tulajdonság határozza meg, hogyan jelenik meg egy egyedi alakzat, amikor a prezentációt fekete-fehér módban tekintik vagy dolgozzák fel. Nem engedélyezi a fekete-fehér megjelenítést önmagában, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használja a [BlackWhiteMode](https://reference.aspose.com/slides/hu/net/aspose.slides/blackwhitemode/) felsorolás egyik értékét a kívánt viselkedés meghatározásához. Például az `Automatic` lehetővé teszi a megjelenítő alkalmazásnak, hogy a konverziót a saját módján végezze, a `Gray` és `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehért használ, a `Black` és `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete‑fehér módban, a `NotDefined` pedig azt jelenti, hogy nincs alakzatszintű mód hozzárendelve.

Az alábbi C# kód egy színes alakzatot hoz létre, amely a fekete‑fehér megjelenítési mód alatt szürke lesz:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Tartsa a narancssárga kitöltést színes módban, de jelenítse meg a alakzatot szürke színnel fekete-fehér módban.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Normál színmódban a téglalap narancssárga kitöltése marad. Fekete‑fehér megjelenítés esetén a `Gray` mód miatt szürke színt kap, ami lehetővé teszi, hogy a teljes színű dia megmaradjon, miközben a nyomtatás, előnézet vagy egyéb munkafolyamatok során külön megjeleníthető legyen a fekete‑fehér beállítás.

## **Formázás visszaállítása**

Az alábbi C# kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa alaphelyzetbe az összes alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslide/) helyőrzőivel:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésen.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **GYIK**

**A befolyásolja a formaformázás a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a legtöbb helyet, míg a formázási paraméterek – színek, hatások, színátmenetek – metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni a dián olyan alakzatokat, amelyek azonos formázást használnak, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállításait. Ha az összes megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ez megkönnyíti a későbbi stíluskezelést.

**Menthetek-e egy egyedi forma stíluskészletet külön fájlba, hogy más prezentációkban is felhasználjam?**

Igen. Tároljon minta‑alakzatokat a kívánt stílusokkal egy sablon‑diakészletben vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázást a kívánt helyeken.