---
title: PowerPoint alakzatok formázása .NET-ben
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat effektus
- vázlat alakzat vonal
- illesztési stílus formázása
- gradient kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3d lekerekített effektus
- 3d forgatási effektus
- formázás visszaállítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan lehet C#‑ban formázni a PowerPoint alakzatokat az Aspose.Slides segítségével—precíz és teljes irányítás a kitöltés, vonal és effektus stílusainak PPT és PPTX fájlokban."
---
## **Bevezetés**

Formázza a PowerPoint alakzatokat azok körvonalainak, kitöltéseinek és effektjeinek módosításával. Az Aspose.Slides for .NET lehetővé teszi ezen beállítások programozott vezérlését, beleértve az átlátszóságot, forgatást és a 3D formázást.

![Alakzatformázási lehetőségek a PowerPointban](format-shape-powerpoint.png)

Aspose.Slides for .NET interfészeket és tulajdonságokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a lehetőségekkel.

## **Vonalak formázása**

Használja a [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) elemet a forma körvonalának vezérléséhez. Ez a példa egy kitöltetlen négyzetet hoz létre kék, szaggatott körvonallal. Az [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) egy vastag‑vékony összetett vonalat választ, míg az [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) 7 pontra állítja a szélességét, és az [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) a szaggatottsági mintát választja.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.Style = LineStyle.ThickThin;
shape.LineFormat.Width = 7;
shape.LineFormat.DashStyle = LineDashStyle.Dash;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("formatted_lines.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

### **Egyéni vonal szaggatottsági minták beállítása**

Használja a [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) elemet, ha az előre definiált vonalstílusok nem biztosítanak megfelelő szaggatási hosszakat és hézagokat, például márkázott körvonalak vagy műszaki diagramok esetén. Egy minta hozzárendelése automatikusan beállítja az [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) értékét a [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) értékre.

A tömb bejegyzései felváltva tartalmaznak vonal‑ és hézaghosszakat, a vonallal kezdve. Minden érték a vonal szélességének többszöröse: `{ 4, 2 }` 3 pont szélességnél 12 pontos vonalat és 6 pontos hézagot eredményez. Párokat használjon véges, nemnegatív értékekből a teljes vonal‑hézag szegmensek meghatározásához. A példa pozitív értékeket használ, hogy minden vonal és hézag látható legyen.

Ez a példa öt kék vonalat hoz létre azonos hosszal és lapos csúcsokkal. Az első három 3 pont szélességű mintákat hasonlít össze. A negyedik kétszeres szélességgel ismétli az első mintát, megduplázva a vonal‑ és hézaghosszakat. Az ötödik egy egyéni mintáról szilárd vonalra vált.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(600, 300, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var patterns = new[]
{
    new float[] { 4, 2 },
    new float[] { 1, 2 },
    new float[] { 6, 2, 1, 2 },
    new float[] { 4, 2 },
    new float[] { 4, 2 }
};

for (var i = 0; i < patterns.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 50, 50 + i * 50, 500, 0);
    line.LineFormat.Width = i == 3 ? 6 : 3;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.CapStyle = LineCapStyle.Flat;
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.CustomDashPattern = patterns[i];
}

// Visszaállítja az utolsó vonalat szilárd stílusra.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Ahelyett, hogy egy előre definiált szaggatott stílusra térne vissza, rendelje a [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) értéket az [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) elemhez. A kiválasztott stílus szabályozza a vonal megjelenését.

Az eredmény a PowerPointban, fentről lefelé: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; és **Solid, 3 pt**.

![Három egyéni szaggatottsági minta, egy szélesebb vonal az első mintával, és egy szilárd vonal a PowerPointban](custom-dash-patterns.png)

### **Vonalvégek beállítása**

Használja a [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) elemet a nyílt vonal végeinek beállításához. A [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) felsorolás három egyértelmű csúcsstílust biztosít:

- `Flat`: A vonal a végpontnál megáll.
- `Round`: Egy félkör alakú csúcs a végponton túlnyúlik a vonal szélességének felével.
- `Square`: Egy négyzet alakú csúcs a végpontnál túlnyúlik a vonal szélességének felével.

A felsorolás tartalmazza a `NotDefined` értéket is, amely azt jelenti, hogy nincs explicit módon hozzárendelt csúcsstílus.

A csúcsok különböznek a nyilak csúcsfejeitől, amelyek szimbólumokat adnak a vonal végeihez, valamint az illesztésektől, amelyek a vonalszakaszok közti sarkokat szabályozzák. Ez a példa letiltja a nyílfejeket a [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) és [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) segítségével, hogy csak a csúcsformákat hasonlítsa össze.

A következő példa három egyébként azonos, vízszintes vonalat hoz létre, 20 pont széles. Fentről lefelé lapos, kör és négyzet csúcsokat használ. Végpontjaik ugyanazokkal a vízszintes koordinátákkal rendelkeznek; a kör és négyzet csúcsok 10 ponttal túlnyúlnak minden végponton.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 240, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var capStyles = new[] { LineCapStyle.Flat, LineCapStyle.Round, LineCapStyle.Square };

for (var i = 0; i < capStyles.Length; i++)
{
    var line = slide.Shapes.AddAutoShape(ShapeType.Line, 100, 50 + i * 70, 300, 0);
    line.LineFormat.Width = 20;
    line.LineFormat.FillFormat.FillType = FillType.Solid;
    line.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    line.LineFormat.DashStyle = LineDashStyle.Solid;
    line.LineFormat.CapStyle = capStyles[i];
    line.LineFormat.BeginArrowheadStyle = LineArrowheadStyle.None;
    line.LineFormat.EndArrowheadStyle = LineArrowheadStyle.None;
}

presentation.Save("line_caps.pptx", SaveFormat.Pptx);
```

Az eredmény a PowerPointban, fentről lefelé: **Flat**, **Round**, és **Square**.

![Lapos, kör és négyzet csúcsok azonos vastag vonalakon a PowerPointban](line-caps.png)

## **Vázlat effektusok alkalmazása alakzat vonalakra**

A vázlat effektus azt a benyomást kelti, mintha a vonal kézzel rajzolt lenne. Használja a [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) elemet a vonal beállításainak eléréséhez, az [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) a vázlat beállításainak eléréséhez, és az [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) a [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) felsorolás értékének kiválasztásához.

A következő C# kód bemutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) effektet, hogyan olvassa ki a explicit módon hozzárendelt értéket, és hogyan távolítsa el az effektet a [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) használatával:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

var sketchFormat = shape.LineFormat.SketchFormat;
sketchFormat.SketchType = LineSketchType.Curved;
var explicitSketchType = sketchFormat.SketchType;
Console.WriteLine($"Explicit sketch type: {explicitSketchType}");
sketchFormat.SketchType = LineSketchType.None;
```

Az [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) által visszaadott érték a forma közvetlenül kapott beállítását jelenti. Ha a vonalformázás egy témából, mester diából vagy elrendezési diából örökölhető, használja a [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/) elemet, érje el a [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/) elemet, és olvassa ki az [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/) értékét. A tényleges érték tükrözi a formázást, amely az öröklődés feloldása után alkalmazásra kerül. Ez a példa egy meglévő prezentációt igényel, amely legalább egy alakzatot tartalmaz az első dián, és kiírja mindkét értéket:

```csharp
using System;
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

Íme a három illesztési típus lehetősége:

* Round
* Miter
* Bevel

Az illesztési stílus szabályozza, hogy két körvonal szegmens hogyan találkozik egy sarkon. Használja a **Round** értéket a lekerekített sarkokhoz, a **Miter** értéket a hegyes sarkokhoz, vagy a **Bevel** értéket a lelapított sarkokhoz.

![Az illesztési stílus a prezentációban](join-style-powerpoint.png)

Ez a példa három fekete téglalapot hoz létre kék, 15 pont széles körvonallal. A [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) elemet a [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) miter, bevel és round értékeire állítja be, hogy összehasonlítsa a sarkok megjelenését.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var miterShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
var bevelShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
var roundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

miterShape.FillFormat.FillType = FillType.Solid;
miterShape.FillFormat.SolidFillColor.Color = Color.Black;
bevelShape.FillFormat.FillType = FillType.Solid;
bevelShape.FillFormat.SolidFillColor.Color = Color.Black;
roundShape.FillFormat.FillType = FillType.Solid;
roundShape.FillFormat.SolidFillColor.Color = Color.Black;

miterShape.LineFormat.Width = 15;
bevelShape.LineFormat.Width = 15;
roundShape.LineFormat.Width = 15;

miterShape.LineFormat.FillFormat.FillType = FillType.Solid;
miterShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
bevelShape.LineFormat.FillFormat.FillType = FillType.Solid;
bevelShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;
roundShape.LineFormat.FillFormat.FillType = FillType.Solid;
roundShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Blue;

miterShape.LineFormat.JoinStyle = LineJoinStyle.Miter;
bevelShape.LineFormat.JoinStyle = LineJoinStyle.Bevel;
roundShape.LineFormat.JoinStyle = LineJoinStyle.Round;

miterShape.TextFrame.Text = "Miter Join Style";
bevelShape.TextFrame.Text = "Bevel Join Style";
roundShape.TextFrame.Text = "Round Join Style";

presentation.Save("join_styles.pptx", SaveFormat.Pptx);
```

### **Miter illesztések korlátozása hegyes sarkoknál**

Használja a [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) elemet, a [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) értékre állítva, hogy korlátozza, milyen messzire nyúlhat egy hegyes sarok.

A limit a csatlakozás belső és külső sarkai közti távolság és a vonal szélessége közti arány. Például a `8` érték legfeljebb nyolcszorosa a vonal szélességének engedélyezi a miter hosszát; nem pontmérték. Ha a sarok meghaladná a limitet, a PowerPoint egy lelapított illesztést használ azon a sarkon. Nagyobb limit élesebb pontokat enged meg. A beállítás csak a miter illesztéseket érinti, és a módosítása nem látható, ha a sarok mindkét limit között marad.

Ez a példa két azonos, kiürült háromszöget hoz létre 20 pont széles körvonallal. A bal háromszög `2` limitet használ, a jobb pedig `8`-at. Minden háromszög 80 pont széles és 160 pont magas, a felső sarkához körülbelül `4,12`-es miter‑hossz‑vonalszélesség arányt adva. Ennek következtében a PowerPoint a bal csúcsot lelapítja, míg a jobb csúcsot megőrzi.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(500, 320, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var miterLimits = new[] { 2f, 8f };

for (var i = 0; i < miterLimits.Length; i++)
{
    var triangle = slide.Shapes.AddAutoShape(ShapeType.Triangle, 90 + i * 240, 110, 80, 160);
    triangle.FillFormat.FillType = FillType.NoFill;
    triangle.LineFormat.Width = 20;
    triangle.LineFormat.FillFormat.FillType = FillType.Solid;
    triangle.LineFormat.FillFormat.SolidFillColor.Color = Color.DarkBlue;
    triangle.LineFormat.JoinStyle = LineJoinStyle.Miter;
    triangle.LineFormat.MiterLimit = miterLimits[i];
}

presentation.Save("miter_limits.pptx", SaveFormat.Pptx);
```

Az eredmény a PowerPointban: **Miter limit 2** bal oldalon és **miter limit 8** jobb oldalon.

![Laplított csúcs miter limit 2-vel és hegyes csúcs miter limit 8-cal a PowerPointban](miter-limits.png)

## **Gradient kitöltés**

A gradient kitöltés színeket kever át egy alakzaton. Ez a példa egy ellipszist tölt ki lineáris gradienttel 45 fokos szöggel pirosból lila színig a [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/) használatával. Az [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) metódus a színállomásokat 0 és 1 pozícióra helyezi, a gradient elejére és végére. A meglévő állomások törlése biztosítja, hogy csak ez a két szín legyen használva.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Gradient;
shape.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
shape.FillFormat.GradientFormat.LinearGradientAngle = 45;
shape.FillFormat.GradientFormat.GradientStops.Clear();
shape.FillFormat.GradientFormat.GradientStops.Add(1.0f, PresetColor.Purple);
shape.FillFormat.GradientFormat.GradientStops.Add(0.0f, PresetColor.Red);

presentation.Save("gradient_fill.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az ellipszis gradient kitöltéssel](gradient-fill.png)

Ha egy gradient másként jelenik meg egy exportált képen, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy renderelési stílust anélkül, hogy megváltoztatná a prezentációban tárolt gradient kitöltést.

### **Lineáris gradient szög beállítása**

Használja a [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) elemet a [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) kitöltés tájolásának vezérléséhez. A szög fokban van mérve, és az óramű irányába növekszik: `0` balról jobbra, `90` felülről alulra, `180` jobbról balra, `270` alulról felülre. Tört szögek is támogatottak. A `[0, 360)`-on kívüli véges szögeket egy körön belül normalizálja; például a `-45` `315`-t, a `360` pedig `0`-t lesz.

Ez a példa hat téglalapot hoz létre azonos vörös, zöld és kék színállomásokkal a `0`, `0.5` és `1` pozíciókban. A skálázás le van tiltva, hogy a szög összehasonlítható legyen a téglalapok méretaránya nélkül. A szögek balról jobbra: az első sorban `0`, `45`, és `90`, a második sorban `135`, `180`, és `270`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var angles = new float[] { 0, 45, 90, 135, 180, 270 };

for (var i = 0; i < angles.Length; i++)
{
    var x = 30 + (i % 3) * 230;
    var y = 30 + (i / 3) * 190;

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 200, 150);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.False;
    gradient.LinearGradientAngle = angles[i];
}

presentation.Save("linear_gradient_angles.pptx", SaveFormat.Pptx);
```

Az eredmény a PowerPointban:

![Lineáris gradientek 0, 45 és 90 fokban a felső sorban, valamint 135, 180 és 270 fokban az alsó sorban](linear-gradient-angles.png)

### **Lineáris gradient skálázása az alakzattal**

A [IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) egy [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értéket fogad. Állítsa explicit módon `False`-ra, hogy a geometriai gradient szög a forma arányainak változásakor is megmaradjon, vagy `True`-ra, hogy a gradient a forma szélességével és magasságával együtt skálázódjon. A skálázás engedélyezése esetén a látható szög eltérhet az nem négyzet alakú formán a hozzárendelt szögtől.

A következő példa `45` fokos szöget és ugyanazokat a színállomásokat használja, mint a szög összehasonlításnál. A bal oszlop `False`-t használ; a jobb oszlop `True`-t. Minden oszlop egy széles téglalapot tartalmaz egy magas téglalap felett. Mindkettő ugyanazzal a széles mérettel indul; a második téglalap szélességének és magasságának módosítása bemutatja, hogyan reagál a kitöltés a méretváltoztatásra anélkül, hogy a gradient beállításait változtatná.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 460, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

var scalingOptions = new[] { NullableBool.False, NullableBool.True };

for (var column = 0; column < scalingOptions.Length; column++)
{
    for (var row = 0; row < 2; row++)
    {
        var x = 30 + column * 360;
        var y = row == 0 ? 30 : 150;
        
        var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, x, y, 300, 90);
        shape.LineFormat.FillFormat.FillType = FillType.NoFill;
        shape.FillFormat.FillType = FillType.Gradient;

        var gradient = shape.FillFormat.GradientFormat;
        gradient.GradientShape = GradientShape.Linear;
        gradient.GradientStops.Clear();
        gradient.GradientStops.Add(0f, Color.Red);
        gradient.GradientStops.Add(0.5f, Color.Lime);
        gradient.GradientStops.Add(1f, Color.Blue);
        gradient.LinearGradientAngle = 45;
        gradient.LinearGradientScaled = scalingOptions[column];

        if (row == 1)
        {
            shape.Width = 90;
            shape.Height = 280;
        }
    }
}

presentation.Save("linear_gradient_scaling.pptx", SaveFormat.Pptx);
```

Az eredmény a PowerPointban, a bal oldalon a skálázás letiltva, a jobb oldalon engedélyezve:

![Széles és magas téglalapok 45 fokos gradienttel, a bal oldalon LinearGradientScaled False, a jobb oldalon True](linear-gradient-scaling.png)

Skálázás letiltásakor a diagonális színcsíkok ugyanazt az orientációt tartják mindkét téglalapban. Skálázás engedélyezésekor a csíkok a forma arányával nyúlnak. Ez segít egy sablon gradientjének reprodukálásában, amikor egy alakzatot más méretre adaptálunk. Egy négyzet esetén a skálázás engedélyezése nem változtatja meg ezt a `45` fokos gradientet.

A szög és a skálázási beállítások egyaránt lineáris gradientekre vonatkoznak. Nem irányítják a [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) kitöltéseket.

### **Szög kombinálása a gradient irányával**

Az [IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) a [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) felsorolásból választ egy gradient stílust; ez nem helyettesíti a numerikus szöget. Lineáris gradient esetén a sarokstílusok megváltoztathatják a színek eloszlási területét anélkül, hogy a [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) változna. Tartsa a irányt változatlanul, amikor szögeket vagy skálázást hasonlít.

A következő példa ugyanazokat a beállításokat fordított sorrendben alkalmazza. A két téglalap ugyanúgy néz ki: a direction beállítása a szög előtt vagy után nem változtatja meg az eredményt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

for (var i = 0; i < 2; i++)
{
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30 + i * 140, 320, 100);
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
    shape.FillFormat.FillType = FillType.Gradient;

    var gradient = shape.FillFormat.GradientFormat;
    gradient.GradientShape = GradientShape.Linear;
    gradient.GradientStops.Clear();
    gradient.GradientStops.Add(0f, Color.Red);
    gradient.GradientStops.Add(0.5f, Color.Lime);
    gradient.GradientStops.Add(1f, Color.Blue);
    gradient.LinearGradientScaled = NullableBool.True;

    if (i == 0)
    {
        gradient.GradientDirection = GradientDirection.FromCorner1;
        gradient.LinearGradientAngle = 30;
    }
    else
    {
        gradient.LinearGradientAngle = 30;
        gradient.GradientDirection = GradientDirection.FromCorner1;
    }
}

presentation.Save("linear_gradient_direction.pptx", SaveFormat.Pptx);
```

## **Minta kitöltés**

A minta kitöltés két színű mintát alkalmaz, például pontokat, csíkokat vagy négyzethálót. Ez a példa a [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) segítségével választ egy kereszttáblás mintát. Az [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) a világosszürke hátteret biztosítja, az [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) pedig a sárga mintaszínt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Pattern;
shape.FillFormat.PatternFormat.PatternStyle = PatternStyle.Trellis;
shape.FillFormat.PatternFormat.BackColor.Color = Color.LightGray;
shape.FillFormat.PatternFormat.ForeColor.Color = Color.Yellow;

presentation.Save("pattern_fill.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A kép kitöltés egy képet használ egy alakzaton belül. Ez a példa helyi képet igényel, és a [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) segítségével tölti be a prezentáció képgyűjteményébe. Az [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) mozaik módra állítása megismétli a képet a téglalapon belül. Az itt használt forráskép alább látható:

![A lótusz kép](lotus.png)

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
shape.FillFormat.FillType = FillType.Picture;
shape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Tile;

using var image = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(image);
shape.FillFormat.PictureFillFormat.Picture.Image = presentationImage;

presentation.Save("picture_fill.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép mozaik mintaként**

Ha mozaikképet szeretne textúraként beállítani és testre szabni a mozaik viselkedését, a következő tulajdonságokat használhatja az [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) osztály esetén:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Beállítja a kép kitöltési módot – `Tile` vagy `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Megadja a csempék igazítását az alakzaton belül.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

Ez a példa helyi képet igényel, és a [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) beállítja, hogy az eredeti méretének 50%-án ismétlődjön. A −32 pontos eltolások a csempéket vízszintesen és függőlegesen mozgatják; a jobb alsó igazítás és mindkét irányban történő tükrözés határozza meg, hogyan rendeződik a megismételt textúra.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var firstSlide = presentation.Slides[0];

var shape = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);
shape.FillFormat.FillType = FillType.Picture;

using var sourceImage = Images.FromFile("lotus.png");
var presentationImage = presentation.Images.AddImage(sourceImage);

var pictureFillFormat = shape.FillFormat.PictureFillFormat;
pictureFillFormat.Picture.Image = presentationImage;
pictureFillFormat.PictureFillMode = PictureFillMode.Tile;
pictureFillFormat.TileOffsetX = -32;
pictureFillFormat.TileOffsetY = -32;
pictureFillFormat.TileScaleX = 50;
pictureFillFormat.TileScaleY = 50;
pictureFillFormat.TileAlignment = RectangleAlignment.BottomRight;
pictureFillFormat.TileFlip = TileFlip.FlipBoth;

presentation.Save("tile.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A csempe beállításai](tile-options.png)

## **Egyszínű kitöltés**

Az egyszínű kitöltés egyetlen, egységes színt ad az alakzatra. Ez a példa a [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) elemet egységkitöltés módra állítja, és sárgát rendel a [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) segítségével, majd elmenti a téglalapot egy prezentációban.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Yellow;

presentation.Save("solid_color_fill.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

### **Színek másolása a téma hivatkozások megtartásával**

Használja az [IColorFormat.CopyFrom](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/copyfrom/) elemet egy szín definíció másolásához, beleértve a szín típusát, a téma hivatkozását és a transzformációkat. Ez akkor hasznos, ha egy kitöltő színt alakzatok között kíván áthelyezni, amelyeknek továbbra is a prezentáció témát kell követniük. A metódus csak a színt másolja; a kitöltés típusát, a körvonalat vagy más alakzatformázást nem másolja. Állítsa be a cél [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) elemét explicit módon.

Ez a példa három téglalapot hoz létre, balról jobbra: a forrást, egy témát figyelembe vevő másolatot és egy rögzített RGB másolatot. A forrás az [IColorFormat.SchemeColor](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/schemecolor/) segítségével hivatkozik az első hangsúly színre, és egy árnyalatot ad hozzá az [IColorOperationCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icoloroperationcollection/add/) használatával. Az RGB másolat a forrás tényleges kitöltő színét használja, így kezdetben az összes három azonosnak tűnik. Az [IColorFormat.Color](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/color/) hozzárendelése egy rögzített RGB értéket állít be, és törli a meglévő színtranszformációkat.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(660, 220, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

presentation.MasterTheme.ColorScheme.Accent1.Color = Color.RoyalBlue;

var source = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 40, 180, 140);
var themeCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 240, 40, 180, 140);
var rgbCopy = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 450, 40, 180, 140);

foreach (var shape in new[] { source, themeCopy, rgbCopy })
{
    shape.FillFormat.FillType = FillType.Solid;
    shape.LineFormat.FillFormat.FillType = FillType.NoFill;
}

var sourceColor = source.FillFormat.SolidFillColor;
sourceColor.SchemeColor = SchemeColor.Accent1;
sourceColor.ColorTransform.Add(ColorTransformOperation.Tint, 0.75f);

themeCopy.FillFormat.SolidFillColor.CopyFrom(sourceColor);
rgbCopy.FillFormat.SolidFillColor.Color = source.FillFormat.GetEffective().SolidFillColor;

using var before = slide.GetImage(1f, 1f);
before.Save("color-copy-before.png", ImageFormat.Png);

// Theme references follow the new accent color; the fixed RGB value does not.
presentation.MasterTheme.ColorScheme.Accent1.Color = Color.OrangeRed;

using var after = slide.GetImage(1f, 1f);
after.Save("color-copy-after.png", ImageFormat.Png);
presentation.Save("copied_colors.pptx", SaveFormat.Pptx);
```

A téma változtatása előtt mindhárom kitöltés egyezik:

![Forrás, CopyFrom cél és rögzített RGB cél azonos kék kitöltésekkel](color-copy-before.png)

A téma változtatása után a forrás és a témát figyelembe vevő másolat az új hangsúly színt követi és megtartja az árnyalatát. A rögzített RGB másolat kék marad:

![Forrás és CopyFrom cél narancssárga kitöltéssel, míg a rögzített RGB cél kék marad](color-copy-after.png)

A másolt definíció független a forrástól. A forrás téma hivatkozásának, egy másik szín hozzárendelésének vagy a transzformációk hozzáadásának vagy eltávolításának megváltoztatása nem befolyásolja a célt. A téma változtatása még mindig mindkét alakzatot érinti, mivel mindegyik önállóan a ugyanarra a téma színre hivatkozik.

A PPTX mentése és újranyitása megőrzi a másolt szín [IColorFormat.ColorType](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortype/), téma hivatkozását és [IColorFormat.ColorTransform](https://reference.aspose.com/slides/net/aspose.slides/icolorformat/colortransform/) gyűjteményét; nem lapítja le a definíciót RGB-re.

Különböző téma környezetek között másoláskor, például eltérő hangsúly palettákkal rendelkező prezentációk esetén, a másolt hivatkozás a cél téma szerint kerül feloldásra. Ugyanaz a hivatkozás és transzformációk ezért más látható színt eredményezhetnek. Tekintse meg a [Presentation Theme](/slides/hu/net/presentation-theme/) oldalt a téma színek konfigurálásáról.

## **Dia háttér használata alakzat kitöltésként**

Használja az [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) elemet, ha egy alakzatnak meg kell egyeznie a dia háttérrel, például egy prezentációs sablonban. Állítsa először a [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) elemet a [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékre, hogy eltávolítsa az esetleges explicit kitöltést. Ezzel a kombinációval az alakzat a dia hátterét használja a saját stílus kitöltése helyett. A jelző egyedüli engedélyezése nem távolítja el a meglévő explicit kitöltést.

Ez különbözik a [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/): a háttér kitöltés a forma mögötti objektumokat takarja a dia megfelelő területével, míg a NoFill megjeleníti őket. A gradient a diához igazodik, nem indul újból minden egyes alakzatban.

A következő példa egy mester háttért hoz létre, amelyet a dia örököl, és egy magenta sávot helyez három téglalap mögé. A bal téglalap a háttér kitöltést használja, a középső téglalap nincs kitöltve, a jobb téglalap a háttér kitöltésről egy explicit narancssárga kitöltésre vált.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// Örökölje a gradientet a masterből.
slide.Background.Type = BackgroundType.NotDefined;
slide.LayoutSlide.Background.Type = BackgroundType.NotDefined;
var background = slide.LayoutSlide.MasterSlide.Background;
background.Type = BackgroundType.OwnBackground;
background.FillFormat.FillType = FillType.Gradient;
var gradient = background.FillFormat.GradientFormat;
gradient.GradientShape = GradientShape.Linear;
gradient.LinearGradientAngle = 0;
gradient.GradientStops.Clear();
gradient.GradientStops.Add(0, Color.DarkBlue);
gradient.GradientStops.Add(1, Color.LightSkyBlue);

// Adja hozzá ezt az objektumot először, hogy a téglalapok mögött jelenjen meg.
var band = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 25, 150, 670, 100);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.Magenta;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var backgroundShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 100, 160, 200);
backgroundShape.FillFormat.FillType = FillType.NotDefined;
backgroundShape.UseBackgroundFill = true;

var noFillShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 280, 100, 160, 200);
noFillShape.FillFormat.FillType = FillType.NoFill;

var explicitShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 510, 100, 160, 200);
explicitShape.FillFormat.FillType = FillType.NotDefined;
explicitShape.UseBackgroundFill = true;

// A háttér kitöltést tiltsa le, mielőtt explicit kitöltést alkalmazna.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Az eredmény, balról jobbra: **background fill**, **no fill**, és **explicit fill**. A magenta sávot a bal és jobb téglalap takarja, de a középső téglalapon keresztül látható marad.

![Háttér kitöltés, nincs kitöltés és explicit narancssárga kitöltés egy magenta sáv felett](background-fill.png)

Ez a viselkedés ugyanúgy érvényes a diára közvetlenül definiált vagy egy elrendezésből örökölt háttérre is. Az alakzat a dia feloldott háttérét használja; a példa a dia és az elrendezés hátterét is undefined állapotra hagyja, így a mester biztosítja.

## **Átlátszóság beállítása**

Egységkitöltés esetén a szín alfa komponense szabályozza az átlátszatlanságot: 0 teljesen átlátszó, 255 teljesen átlátszatlan. Ez a példa 128 alfa értéket használ egy sárga téglalaphoz, ami körülbelül 50%-os átlátszóságot eredményez, így az alatta lévő téglalap látható marad. A színt az [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) segítségével rendeli hozzá.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

const int alpha = 128;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var solidShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

var transparentShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
transparentShape.FillFormat.FillType = FillType.Solid;
transparentShape.FillFormat.SolidFillColor.Color = Color.FromArgb(alpha, Color.Yellow);

presentation.Save("shape_transparency.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Használja a [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) elemet egy alakzat a dia síkjában történő forgatásához. A szög fokban van mérve; ez a példa egy téglalapot 5 fokkal az óramű irányába fordít és elmenti a prezentációt.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
shape.Rotation = 5;

presentation.Save("shape_rotation.pptx", SaveFormat.Pptx);
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D lekerekített effektusok hozzáadása**

Használja a [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) elemet, hogy egy alakzatnak mélységet és lekerekített éleket adjon. Ez a példa egy zöld ellipszist hoz létre narancs körvonaljal, a [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) értéket 4 pontra állítja, és egy kör alakú felső lekerekítést alkalmaz 6 pont szélességgel és magassággal a [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) segítségével. Egy előre mutató ortografikus kamera és hárompontos megvilágítás teszi láthatóvá a lekerekítést.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Green;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Orange;
shape.LineFormat.Width = 2.0;
shape.ThreeDFormat.Depth = 4;
shape.ThreeDFormat.BevelTop.BevelType = BevelPresetType.Circle;
shape.ThreeDFormat.BevelTop.Height = 6;
shape.ThreeDFormat.BevelTop.Width = 6;
shape.ThreeDFormat.Camera.CameraType = CameraPresetType.OrthographicFront;
shape.ThreeDFormat.LightRig.LightType = LightRigPresetType.ThreePt;
shape.ThreeDFormat.LightRig.Direction = LightingDirection.Top;

presentation.Save("3D_bevel_effect.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A 3D lekerekített effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Az alakzat 3D nézete a kamera beállításaival van szabályozva. Ez a példa a [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) használatával 40, 35 és 20 fokos szélességi, hosszúsági és fordulatszög értékeket állít be. Egy izometrikus kamerát választ a [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) segítségével, és kiegyensúlyozott megvilágítást a [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) segítségével, majd elmenti a formázott téglalapot.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
autoShape.TextFrame.Text = "Hello, Aspose!";
autoShape.ThreeDFormat.Camera.CameraType = CameraPresetType.IsometricLeftUp;
autoShape.ThreeDFormat.Camera.SetRotation(40, 35, 20);
autoShape.ThreeDFormat.LightRig.LightType = LightRigPresetType.Balanced;

presentation.Save("3D_rotation_effect.pptx", SaveFormat.Pptx);
```

Az eredmény:

![A 3D forgatási effektus](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés szabályozása alakzatoknál**

Az [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) tulajdonság meghatározza, hogyan jelenik meg egy egyedi alakzat, amikor a prezentáció fekete-fehér módban kerül megtekintésre vagy feldolgozásra. Nem kapcsol be önmagában fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedés kiválasztásához. Például az `Automatic` a renderelő alkalmazást hagyja kiválasztani a konverziót, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehér megjelenítést használ, a `Black` és a `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` kihagyja az alakzatot fekete‑fehér módban. A `NotDefined` azt jelenti, hogy nincs hozzárendelt alakzatszintű mód.

Ez a példa egy narancssárga téglalapot hoz létre, és az [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) értékét grisre állítja. A mentett alakzat megtartja a narancssárga kitöltést normál színmegjelenítéskor, és szürke színezést kér a fekete‑fehér megjelenítést tiszteletben tartó alkalmazásoktól:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
shape.FillFormat.FillType = FillType.Solid;
shape.FillFormat.SolidFillColor.Color = Color.Orange;
shape.BlackWhiteMode = BlackWhiteMode.Gray;

presentation.Save("shape_black_white_mode.pptx", SaveFormat.Pptx);
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete‑fehér megjelenítési munkafolyamatban szürke színezést használ, mert a módja `Gray`‑re van állítva. Ez lehetővé teszi, hogy megőrizze a teljes színű diát, miközben külön megjelenést definiál nyomtatáshoz, előnézethez vagy egyéb munkafolyamatokhoz, amelyek tiszteletben tartják a prezentáció fekete‑fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Használja a [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) elemet a dián lévő helykitöltők pozíciójának, méretének és formázásának visszaállításához a megfelelő elrendezéshelykitöltőkből. Ez a példa meglévő prezentációt igényel, amely elrendezéshez kapcsolt helykitöltőkkel rendelkezik, és mentés előtt minden diát visszaállít. Azok az alakzatok, amelyeknek nincs megfelelő elrendezéshelykitöltője, nem lesznek visszaállítva.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
foreach (var slide in presentation.Slides)
{
    slide.Reset();
}

presentation.Save("reset_formatting.pptx", SaveFormat.Pptx);
```

## **GYIK**

**A formaformázás befolyásolja a végleges prezentáció fájlméretét?**

A színek, vonalstílusok és effektus beállítások általában kevés adatot adnak hozzá a beágyazott képekhez és médiához képest. A kép kitöltések növelhetik a fájlméretet, mivel a képeiket a prezentációban tárolják.

**Hogyan ismerhetek fel egy dián olyan alakzatokat, amelyek azonos formázást osztanak meg, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságát – kitöltés, vonal és effekt beállítások. Ha minden megfelelő érték egyezik, tekintse a stílusukat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ami egyszerűsíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzatstílusok halmazt külön fájlba, hogy más prezentációkban újra felhasználhassam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon diakészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat ahol szükséges.