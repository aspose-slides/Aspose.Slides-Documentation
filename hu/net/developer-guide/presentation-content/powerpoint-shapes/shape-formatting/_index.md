---
title: PowerPoint alakzatok formázása .NET-ben
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3D él hatás
- 3D forgatás hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat C#-ban az Aspose.Slides segítségével—állítson be kitöltési, vonal- és effektusstílusokat PPT és PPTX fájlokhoz precízen és teljes kontrollal."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diahoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett beállítások megadásával formázhatja az alakzatok belsejét, amelyek szabályozzák a kitöltést.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for .NET interfészeket és tulajdonságokat biztosít, amelyek lehetővé teszik alakzatok formázását a PowerPointban elérhető ugyanazokkal a beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések foglalják össze az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/net/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal szélességét.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/net/aspose.slides/linedashstyle/) értékét.
1. Állítsa be a vonal színét az alakzatra.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi C# kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-ot:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Kapja meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a téglalap alakzat kitöltő színét.
    shape.FillFormat.FillType = FillType.NoFill;

    // Alkalmazzon formázást a téglalap vonalaira.
    shape.LineFormat.Style = LineStyle.ThickThin;
    shape.LineFormat.Width = 7;
    shape.LineFormat.DashStyle = LineDashStyle.Dash;

    // Állítsa be a téglalap vonalának színét.
    shape.LineFormat.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
}
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Csatlakozási stílusok formázása**

A három csatlakozási típus opciója a következő:

* Kerek
* Sarok
* Ferde

Alapértelmezés szerint, amikor a PowerPoint két vonalat szögben (például egy alakzat sarkán) egyesít, a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Szarok** opciót.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi C# kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Miter, Bevel és Round csatlakozási típus beállításokkal:

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá három automatikus alakzatot Rectangle típusban.
    IAutoShape shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Állítsa be a kitöltő színt minden téglalap alakzatra.
    shape1.FillFormat.FillType = FillType.Solid;
    shape1.FillFormat.SolidFillColor.Color = Color.Black;
    shape2.FillFormat.FillType = FillType.Solid;
    shape2.FillFormat.SolidFillColor.Color = Color.Black;
    shape3.FillFormat.FillType = FillType.Solid;
    shape3.FillFormat.SolidFillColor.Color = Color.Black;

    // Állítsa be a vonal vastagságát.
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

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("join_styles.pptx", SaveFormat.Pptx);
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt is alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az alábbiakban bemutatjuk, hogyan alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Gradient`-ra.
1. Adja hozzá a két kívánt színt meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `Add` metódusával.
1. Mentse a módosított prezentációt PPTX fájlként.

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Ellipse típusban.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon színátmenetes formázást az ellipszisre.
    shape.FillFormat.FillType = FillType.Gradient;
    shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;

    // Állítsa be a színátmenet irányát.
    shape.FillFormat.GradientFormat.GradientDirection = GradientDirection.FromCorner2;

    // Adjon hozzá két színátmeneti állomást.
    shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
    shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
}
```

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi két színű minták (például pontok, csíkok, keresztminták vagy négyzethálók) alkalmazását egy alakzatra. Egyéni színeket választhat a minta előtér és háttér színéhez.

Az Aspose.Slides több mint 45 előre definiált minta stílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelésére. Még az előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kíván.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy minta stílust a előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformat/backcolor/) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/net/aspose.slides/ipatternformat/forecolor/) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Pattern-re.
    shape.FillFormat.FillType = FillType.Pattern;

    // Állítsa be a minta stílust.
    shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;

    // Állítsa be a minta háttér- és előtérszíneket.
    shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
    shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
}
```

![A téglalap mintás kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi egy képernyő beillesztését egy alakzatba – ezáltal a képet az alakzat háttérként használja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Picture`-ra.
1. Állítsa be a kép kitöltés módját `Tile`-re (vagy egy másik kívánt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/net/aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Rendelje hozzá ezt a képet a forma `Picture.Image` tulajdonságához a `PictureFillFormat`-ban.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájl a következő képpel:

![A lotus kép](lotus.png)

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusban.
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

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
}
```

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Mozaik kép textúraként**

Ha mozaik képet szeretne beállítani textúraként, és testreszabni a mozaik viselkedését, az alábbi [IPictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/) interfész és [PictureFillFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/picturefillformat/) osztály tulajdonságait használhatja:

- [PictureFillMode](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/picturefillmode/): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilealignment/): Meghatározza a csempék igazítását az alakzaton belül.
- [TileFlip](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileflip/): Ellenőrzi, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen-e tükrözve.
- [TileOffsetX](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [TileOffsetY](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [TileScaleX](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.
- [TileScaleY](https://reference.aspose.com/slides/hu/net/aspose.slides/ipicturefillformat/tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.Slides[0];

    // Adjon hozzá egy téglalap auto shape-et.
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

    // Állítsa be a képkitöltés módját és a csempézés tulajdonságait.
    pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    pictureFillFormat.TileOffsetX = -32;
    pictureFillFormat.TileOffsetY = -32;
    pictureFillFormat.TileScaleX = 50;
    pictureFillFormat.TileScaleY = 50;
    pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
    pictureFillFormat.TileFlip = TileFlip.FlipBoth;

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("tile.pptx", SaveFormat.Pptx);
}
```

![A csempe beállítások](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín alkalmazásra kerül gradiensek, textúrák vagy minták nélkül.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`-ra.
1. Rendelje a kívánt kitöltő színt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-re.
    shape.FillFormat.FillType = FillType.Solid;

    // Állítsa be a kitöltő színt.
    shape.FillFormat.SolidFillColor.Color = Color.Yellow;

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
}
```

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, kép vagy textúra kitöltést alkalmaz a alakzatokra, beállíthat egy átlátszósági szintet is a kitöltés átlátszatlanságának szabályozásához. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, így a háttér vagy az alatta lévő objektumok részben láthatóak lesznek.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa értékének módosításával. Íme, hogyan teheti ezt:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/net/aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color.FromArgb(alpha, baseColor)` metódust egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```c#
const int alpha = 128;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy szilárd téglalap auto shape-et.
    IAutoShape solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap auto shape-et a szilárd alakzat fölé.
    IAutoShape transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.FillFormat.FillType = FillType.Solid;
    transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
}
```

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok elforgatása**

Az Aspose.Slides lehetővé teszi alakzatok elforgatását PowerPoint prezentációkban. Ez hasznos lehet vizuális elemek elhelyezésekor, amelyeknek meghatározott igazításra vagy tervezési igényekre van szükségük.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat `Rotation` tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```c#
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
using (Presentation presentation = new Presentation())
{
    // Szerezze meg az első diát.
    ISlide slide = presentation.Slides[0];

    // Adjon hozzá egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa el az alakzatot 5 fokkal.
    shape.Rotation = 5;

    // Mentse a PPTX fájlt a lemezen.
    presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
}
```

![Az alakzat elforgatása](shape-rotation.png)

## **3D él effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D él effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) tulajdonságok beállításával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) beállításait az él definíciójához.
1. Mentse a prezentációt.

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

![A 3D él effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/net/aspose.slides/threedformat/) tulajdonságok beállításával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/net/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/net/aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [CameraType](https://reference.aspose.com/slides/hu/net/aspose.slides/icamera/cameratype/) és [LightType](https://reference.aspose.com/slides/hu/net/aspose.slides/ilightrig/lighttype/) értékét a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

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

![A 3D forgatási effektus](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi C# kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan állíthatók vissza a helyzet, méret és minden alakzat formázása a [LayoutSlide](https://reference.aspose.com/slides/hu/net/aspose.slides/layoutslide/) helyőrzőivel az alapértelmezett beállításokra:

```c#
using (Presentation presentation = new Presentation("sample.pptx"))
{
    foreach (ISlide slide in presentation.Slides)
    {
        // Állítsa vissza minden alakzatot a dián, amely helyőrzővel rendelkezik az elrendezésen.
        slide.Reset();
    }

    presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**A formátum módosítása befolyásolja a kész prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiák foglalják a fájl legnagyobb részét, míg a alakzatok paraméterei, mint a színek, effektusok és színátmenetek metaadatként tárolódnak, és szinte nem növelik a fájl méretét.

**Hogyan tudom felderíteni a dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Használja az egyes alakzatok kulcsfontosságú formázási tulajdonságainak – kitöltés, vonal és effektus beállítások – összehasonlítását. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek-e egy egyéni alakzatstílusok halmazt egy külön fájlba a későbbi használatra más prezentációkban?**

Igen. Tárolja a kívánt stílusokkal ellátott mintalakzatokat egy sablon diakészletben vagy egy .POTX sablon fájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat ahol szükséges.