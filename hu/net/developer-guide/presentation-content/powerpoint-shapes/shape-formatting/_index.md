---
title: PowerPoint alakzatok formázása .NET-ben
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- alakzat vonal vázlat hatása
- csatlakozási stílus formázása
- átmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D ferdehatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat C#-ban az Aspose.Slides használatával—állítsa be a kitöltés, vonal és hatás stílusait PPT és PPTX fájlokhoz precízen és teljes irányítás mellett."
---
## **Bevezetés**

PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Továbbá beállíthatja az alakzatok kitöltésének beállításait, amelyek szabályozzák a belső terület kitöltését.

![Alakzat formázása PowerPointban](format-shape-powerpoint.png)

Aspose.Slides for .NET interfészeket és tulajdonságokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a lehetőségekkel.

## **Vonalak formázása**

Az Aspose.Slides segítségével egyéni vonalstílust adhat meg egy alakzathoz. Az alábbi lépések ismertetik a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat [vonalstílus](https://reference.aspose.com/slides/net/aspose.slides/linestyle/) tulajdonságát.  
5. Állítsa be a vonal vastagságát.  
6. Állítsa be a vonal [vonal szaggatottsága](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) tulajdonságát.  
7. Állítsa be a vonal színét az alakzathoz.  
8. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-ot:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a rectangle alakzat kitöltő színét.
    shape.FillFormat.FillType = FillType.NoFill;

    // Alkalmazzon formázást a rectangle vonalaira.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Állítsa be a rectangle vonalának színét.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A prezentációban formázott vonalak](formatted-lines.png)

## **Vázlatos hatások alkalmazása az alakzat vonalaihoz**

Egy vázlat hatás a vonalat kézzel rajzoltként jeleníti meg. A [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) segítségével érheti el a vonal beállításait, a [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) a vázlat beállításait, és a [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) segítségével választhat egy értéket a [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) felsorolásból.

Az alábbi C# kód bemutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten megadott értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) használatával:

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

Az `ISketchFormat.SketchType` által visszaadott érték a közvetlenül az alakzatra beállított beállítást jelenti. Ha a vonal formázás örökölhető egy témából, mester diából vagy elrendezés diából, használja a [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/), érje el a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/), és olvassa ki a [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/). A hatékony érték tükrözi a ténylegesen alkalmazott formázást az öröklődés feloldása után:

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

## **Illesztési stílusok formázása**

Itt vannak a három illesztési típus lehetősége:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögben (például egy alakzat sarkán) illeszt össze, a **Round** beállítást használja. Azonban ha éles szögekkel rendelkező alakzatot rajzol, előnyösebb lehet a **Miter** opció.

![Az illesztési stílus a prezentációban](join-style-powerpoint.png)

Az alábbi C# kód bemutatja, hogyan hozhattók létre három téglalap (a fenti képen látható) a Miter, Bevel és Round illesztési beállításokkal:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

//    // Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt jelöl.
//    // Szerezze meg az első diát.
//    // Három automatikus alakzatot adjon hozzá Rectangle típusú.
//    // Állítsa be az egyes téglalap alakzatok kitöltő színét.
//    // Állítsa be a vonal vastagságát.
//    // Állítsa be az egyes téglalapok vonalának színét.
//    // Állítsa be az illesztési stílust.
//    // Szöveget adjon az egyes téglalapokhoz.
//    // Mentse a PPTX fájlt a lemezre.
using (Presentation presentation = new Presentation())
{
    // Get the first slide.
    ISlide slide = presentation.Slides[0];

    // Add three auto shapes of the Rectangle type.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Set the fill color for each rectangle shape.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Set the line width.
    shape1.LineFormat.Width = 15;
    shape2.LineFormat.Width = 15;
    shape3.LineFormat.Width = 15;

    // Set the color for each rectangle's line.
    shape1.LineFormat.FillFormat.FillType = FillType.Solid;
    shape1.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape2.LineFormat.FillFormat.FillType = FillType.Solid;
    shape2.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
    shape3.LineFormat.FillFormat.FillType = FillType.Solid;
    shape3.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Set the join style.
    shape1.LineFormat.JoinStyle = LineJoinStyle.Miter;
    shape2.LineFormat.JoinStyle = LineJoinStyle.Bevel;
    shape3.LineFormat.JoinStyle = LineJoinStyle.Round;

    // Add text to each rectangle.
    shape1.TextFrame.Text = "Miter Join Style";
    shape2.TextFrame.Text = "Bevel Join Style";
    shape3.TextFrame.Text = "Round Join Style";

    // Save the PPTX file to disk.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Átmenetes kitöltés**

PowerPointban az Átmenetes Kitöltés egy formázási lehetőség, amely lehetővé teszi folyamatos színátmenet alkalmazását egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Itt található, hogyan alkalmazzon átmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékét `Gradient`.  
5. Adja hozzá a két kedvenc színét a meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `Add` metódusaival.  
6. Mentse a módosított prezentációt PPTX fájlként.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Ellipse típusú.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon átmenetes formázást az ellipszisre.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Állítsa be az átmenet irányát.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Adjon hozzá két gradient stopot.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![Az ellipszis átmenetes kitöltéssel](gradient-fill.png)

Ha egy átmenet másként jelenik meg egy exportált képen, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) részt. Választhat renderelési stílust anélkül, hogy megváltoztatná a prezentációban tárolt átmenetes kitöltést.

## **Minta kitöltés**

PowerPointban a Minta Kitöltés egy formázási lehetőség, amely lehetővé teszi két színű minta—például pontok, csíkok, keresztező vonalak vagy négyzetek—alkalmazását egy alakzatra. A minta első és háttérszínére is megadhat saját színeket.

Az Aspose.Slides több mint 45 előre definiált mintastílust biztosít, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelésére. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket.

Itt látható, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékét `Pattern`.  
5. Válasszon egy mintastílust az előre definiált lehetőségek közül.  
6. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) értékét.  
7. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) értékét.  
8. Mentse a módosított prezentációt PPTX fájlként.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Pattern-re.
    shape.FillFormat.FillType = FillType.Pattern;

    // Állítsa be a minta stílusát.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Állítsa be a minta háttér- és előtérszínét.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

PowerPointban a Kép Kitöltés egy formázási lehetőség, amely lehetővé teszi egy kép beillesztését egy alakzatba – hatékonyan a képet a forma háttérként használva.

Itt látható, hogyan használja az Aspose.Slides-et kép kitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékét `Picture`.  
5. Állítsa be a kép kitöltés módját `Tile` (vagy egy másik preferált módra).  
6. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) objektumot a felhasználandó képből.  
7. Rendelje hozzá ezt a képet a `Picture.Image` tulajdonsághoz az alakzat `PictureFillFormat`-jában.  
8. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájlunk a következő képpel:

![A lotus kép](lotus.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);

    // Állítsa be a kitöltés típusát Picture-re.
    shape.FillFormat.FillType = FillType.Picture;

    // Állítsa be a kép kitöltés módját.
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

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Csempézett kép textúraként**

Ha csempézett képet szeretne textúraként beállítani, és testreszabni a csempézés viselkedését, használhatja a [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) osztály következő tulajdonságait:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Beállítja a kép kitöltés módját – akár `Tile`, akár `Stretch`.  
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Meghatározza a csempék igazítását az alakzaton belül.  
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőnél tükröződjön.  
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat eredetétől.  
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat eredetétől.  
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.  
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és konfigurálja a csempe beállításait:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Megkapja az első diát.
    ISlide firstSlide = presentation.Slides[0];

    // Hozzáad egy téglalap automatikus alakzatot.
    IAutoShape shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltés típusát Picture-re.
    shape.FillFormat.FillType = FillType.Picture;

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    IPPImage presentationImage;
    using (IImage sourceImage = Images.FromFile("lotus.png"))
        presentationImage = presentation.Images.AddImage(sourceImage);

    // Hozzárendeli a képet az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.FillFormat.PictureFillFormat;
    pictureFillFormat.Picture.Image = presentationImage;

    // Beállítja a kép kitöltés módot és a csempézés tulajdonságait.
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

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

PowerPointban az Egyszínű Kitöltés egy formázási lehetőség, amely egyetlen, homogén színnel tölti ki az alakzatot. Ez a tiszta háttérszín nem tartalmaz átmeneteket, textúrákat vagy mintákat.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékét `Solid`.  
5. Rendelje hozzá a kívánt kitöltő színt az alakzathoz.  
6. Mentse a módosított prezentációt PPTX fájlként.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-re.
    shape.FillFormat.FillType = FillType.Solid;

    // Állítsa be a kitöltés színét.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

PowerPointban, amikor egy egyszínű, átmenetes, kép- vagy textúra kitöltést alkalmaz a alakzatokra, beállíthat átlátszósági szintet a kitöltés átláthatóságának szabályozásához. A magasabb átlátszósági érték átláthatóbbá teszi az alakzatot, lehetővé téve, hogy a háttér vagy az alatta lévő objektumok részben láthatóak legyenek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be a [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékét `Solid`.  
5. Használja a `Color.FromArgb(alpha, baseColor)`-t átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).  
6. Mentse a prezentációt.

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

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Aspose.Slides lehetővé teszi az alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek elhelyezésekor, ha specifikus igazításra vagy tervezési igényekre van szükség.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat `Rotation` tulajdonságát a kívánt szögre.  
5. Mentse a prezentációt.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusú.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa el az alakzatot 5 fokkal.
    shape.Rotation = 5;

    // Mentse a PPTX fájlt a lemezre.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![Az alakzat forgatása](shape-rotation.png)

## **3D Ferdehatás (Bevel) hozzáadása**

Aspose.Slides lehetővé teszi 3D ferde (bevel) hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) beállításait a bevel beállítások meghatározásához.  
5. Mentse a prezentációt.

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![A 3D ferdehatás](3D-bevel-effect.png)

## **3D Forgatási hatások hozzáadása**

Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/threedformat/) tulajdonságok konfigurálásával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) osztályból.  
2. Szerezzen hivatkozást egy diára az indexe alapján.  
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) elemet a diához.  
4. Állítsa be az alakzat [CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) és [LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) tulajdonságait a 3D forgatás meghatározásához.  
5. Mentse a prezentációt.

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

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatokhoz**

Az [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) tulajdonság meghatározza, hogyan jelenik meg egy egyedi alakzat, amikor a prezentáció fekete-fehér módban van megtekintve vagy feldolgozva. Nem engedélyez fekete-fehér megjelenítést önmagában, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedés kiválasztásához. Például az `Automatic` lehetővé teszi a renderelő alkalmazásnak a konverzió kiválasztását, a `Gray` és `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete-fehér színt használ, a `Black` és `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot a fekete-fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzatszintű mód hozzárendelve.

Az alábbi C# kód létrehoz egy színes alakzatot, és fekete-fehér megjelenítési módban szürke színűvé teszi:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;

// Keep the orange fill in color mode, but render the shape with gray coloring in black-and-white mode.
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete-fehér megjelenítési munkafolyamatban szürke színt használ, mert a módja `Gray`-re van állítva. Ez lehetővé teszi a teljes színű dia megőrzését, miközben a nyomtatás, előnézet vagy egyéb munkafolyamatok esetén, amelyek tiszteletben tartják a prezentáció fekete-fehér megjelenítési beállításait, megkülönböztethető megjelenést definiál.

## **Formázás visszaállítása**

Az alábbi C# kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan állítható vissza az összes helykitöltővel rendelkező alakzat pozíciója, mérete és formázása a [LayoutSlide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) alapértelmezett beállításaira:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Visszaállítja a dián lévő minden alakzatot, amelynek helykitöltője van az elrendezésben.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Menyire befolyásolja az alakzat formázása a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legtöbb helyét, míg az alakzatparaméterek, mint a színek, hatások és átmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik jelentősen a méretet.

**Hogyan tudom felismerni a dián azonos formázással rendelkező alakzatokat, hogy csoportosíthassam őket?**

Használja minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállításait. Ha minden megfelelő érték megegyezik, tekintse őket azonos stílusúaknak, és logikailag csoportosítsa ezeket az alakzatokat, ami egyszerűsíti a későbbi stíluskezelést.

**Menthetek egy saját alakzatstílus-készletet egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tárolja a kívánt stílusokkal rendelkező mintaalakzatokat egy sablon diakészletben vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat ahol szükséges.