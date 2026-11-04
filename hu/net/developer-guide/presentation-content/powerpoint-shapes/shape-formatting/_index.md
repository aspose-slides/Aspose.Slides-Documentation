---
title: PowerPoint alakzatok formázása .NET-ben
linktitle: Alakzat formázás
type: docs
weight: 20
url: /hu/net/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat effektus
- vázlat alakzatvonal
- összekapcsolási stílus formázása
- gradient kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- szilárd szín kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat renderelés
- szürkeárnyalatos alakzat renderelés
- alakzat forgatása
- 3D élesítés effektus
- 3D forgatási effektus
- formázás visszaállítása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat C#-ban az Aspose.Slides használatával—állítson be kitöltési, vonal- és effektusstílusokat PPT és PPTX fájlokhoz precízen és teljes körű irányítással."
---
## **Bevezetés**

Formázza a alakzatokat a PowerPointban a körvonalak, kitöltések és effektusok beállításával. Az Aspose.Slides for .NET lehetővé teszi ezen beállítások programozott vezérlését, beleértve az átlátszóságot, forgatást és a 3D formázást.

![Alakzat formázási lehetőségek a PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for .NET felületeket és tulajdonságokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a beállításokkal formázhatja az alakzatokat.

## **Formázza a vonalakat**

Használja a [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) elemet az alakzat körvonalának vezérléséhez. Ez a példa egy kitöltés nélküli téglalapot hoz létre kék, szaggatott körvonallal. Az [ILineFormat.Style](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/style/) vastag‑vékony kombinált vonalat választ, míg az [ILineFormat.Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) a szélességet 7 pontra állítja és az [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) a szaggatott mintát választja.

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

![A formázott vonalak a bemutatóban](formatted-lines.png)

### **Egyéni vonal szaggatott minták beállítása**

Használja az [ILineFormat.CustomDashPattern](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/customdashpattern/) akkor, amikor az előre definiált vonalstílusok nem biztosítják a szükséges szaggatás hosszát és hézagokat, például márkázott körvonalaknál vagy műszaki diagramoknál. Minta hozzárendelése automatikusan a [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/) értékét a [LineDashStyle.Custom](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) értékre állítja.

A tömb elemei a szaggatás és a hézag hosszát váltakozva tartalmazzák, a szaggatással kezdve. Minden érték a vonalszélesség többszöröse: `{ 4, 2 }` 3 pont szélesség esetén 12 pontos szaggatást és ezt követően 6 pontos hézagot eredményez. Használjon véges, nem negatív értékpárokat a teljes szaggatás‑hézag szegmensek definiálásához. A példa pozitív értékeket használ, hogy minden szaggatás és hézag látható legyen.

Ez a példa öt kék vonalat hoz létre azonos hosszúsággal és lapos végződésekkel. Az első három a mintákat 3 pont szélességnél hasonlítja. A negyedik megismétli az első mintát a kétszeres szélességgel, megduplázva mind a szaggatás, mind a hézag hosszát. Az ötödik a saját mintáról szilárd vonalra vált.

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

// Az utolsó vonalat szilárd stílusra állítja vissza.
slide.Shapes[4].LineFormat.DashStyle = LineDashStyle.Solid;

presentation.Save("custom_dash_patterns.pptx", SaveFormat.Pptx);
```

Ahelyett, hogy előre definiált szaggatott stílusra térne vissza, állítsa a [LineDashStyle.Dash](https://reference.aspose.com/slides/net/aspose.slides/linedashstyle/) értékét a [ILineFormat.DashStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/dashstyle/)-ra. A kiválasztott stílus szabályozza a vonal megjelenését.

Az eredmény a PowerPointban, felülről lefelé: **{4, 2}, 3 pt**; **{1, 2}, 3 pt**; **{6, 2, 1, 2}, 3 pt**; **{4, 2}, 6 pt**; és **Solid, 3 pt**.

![Három egyéni szaggatott minta, egy szélesebb vonal az első mintával, és egy szilárd vonal a PowerPointban](custom-dash-patterns.png)

### **Vonal végek beállítása**

Használja a [ILineFormat.CapStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/capstyle/) elemet egy nyitott vonal végeinek beállításához. A [LineCapStyle](https://reference.aspose.com/slides/net/aspose.slides/linecapstyle/) felsoroló típus három egyértelmű végtípust biztosít:

- `Flat`: A vonal a végpontnál megáll.
- `Round`: Egy félkör alakú végződés a vonal szélességének felével túlnyúlik a végponton.
- `Square`: Egy négyzet alakú végződés a vonal szélességének felével túlnyúlik a végponton.

A felsoroló típus tartalmazza a `NotDefined` értéket is, ami azt jelenti, hogy nincs kifejezetten hozzárendelt végződés.

A végek eltérnek a nyilaktól, amelyek szimbólumokat adnak a vonal végéhez, valamint az illesztésektől, amelyek a vonalszakaszok sarkait szabályozzák. Ez a példa letiltja a nyilakat a [ILineFormat.BeginArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/beginarrowheadstyle/) és a [ILineFormat.EndArrowheadStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/endarrowheadstyle/) használatával, hogy csak a végződés formák legyenek összehasonlítva.

A következő példa három egyébként azonos, vízszintes vonalat hoz létre, 20 pont széles. Felülről lefelé lapos, kerek és négyzet végződéseket használnak. Végpontjaik ugyanazokkal a vízszintes koordinátákkal rendelkeznek; a kerek és a négyzet végződések 10 ponttal túlnyúlnak minden végponton.

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

Az eredmény a PowerPointban, felülről lefelé: **Flat**, **Round**, és **Square**.

![Lapos, kerek és négyzet alakú végződések az azonos vastag vonalakon a PowerPointban](line-caps.png)

## **Vázlat effektusok alkalmazása alakzatvonalakra**

A vázlat effektus kézzel rajzolt vonallá teszi az alakzatot. Használja a [IShape.LineFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/lineformat/) elemet a vonal beállításainak eléréséhez, az [ILineFormat.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/sketchformat/) elemet a vázlat beállításainak eléréséhez, és az [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) elemet a [LineSketchType](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) felsoroló típusból való érték kiválasztásához.

A következő C# kód bemutatja, hogyan kell alkalmazni a [LineSketchType.Curved](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) effektust, kiolvasni a kifejezetten hozzárendelt értéket, és eltávolítani az effektust a [LineSketchType.None](https://reference.aspose.com/slides/net/aspose.slides/linesketchtype/) használatával:

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

Az [ISketchFormat.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformat/sketchtype/) által visszaadott érték azt a beállítást jelenti, amely közvetlenül az alakzatra van alkalmazva. Ha a vonal formázását egy téma, mesterdia vagy elrendezési dia örökölheti, használja az [ILineFormat.GetEffective](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/geteffective/)-t, érje el az [ILineFormatEffectiveData.SketchFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformateffectivedata/sketchformat/)-t, és olvassa ki az [ISketchFormatEffectiveData.SketchType](https://reference.aspose.com/slides/net/aspose.slides/isketchformateffectivedata/sketchtype/)-t. A tényleges érték tükrözi a formázást, amely az öröklődés feloldása után valóban alkalmazva van. Ez a példa egy meglévő prezentációt igényel, amelyen legalább egy alakzat szerepel az első dián, és mindkét értéket kiírja:

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

## **Összekapcsolási stílusok formázása**

Itt vannak a három csatlakozási típus lehetősége:

* Round
* Miter
* Bevel

Az összekapcsolási stílus szabályozza, hogy két körvonal-szakasz hogyan találkozik egy sarkon. Használja a **Round**-ot lekerekített sarkokhoz, a **Miter**-t éles sarkokhoz, vagy a **Bevel**-t lelapított sarkokhoz.

![Az összekapcsolási stílus a bemutatóban](join-style-powerpoint.png)

Ez a példa három fekete téglalapot hoz létre kék, 15 pont széles körvonallal. A [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) értékét a [LineJoinStyle](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) miter, bevel és round értékeire állítja, hogy összehasonlítsa a sarkok megjelenését.

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

### **Miter csatlakozások korlátozása éles sarkoknál**

Használja az [ILineFormat.MiterLimit](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/miterlimit/) elemet a [ILineFormat.JoinStyle](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/joinstyle/) [LineJoinStyle.Miter](https://reference.aspose.com/slides/net/aspose.slides/linejoinstyle/) értékével együtt, hogy korlátozza, milyen messzire nyúlhat egy éles sarok.

A limit a belső és a külső sarok közötti távolság és a vonalvastagság aránya. Például a `8` érték lehetővé teszi, hogy a miter hossza legfeljebb nyolcszorosa legyen a vonalvastagságnak; ez nem pontban mért érték. Ha a sarok meghaladná a limitet, a PowerPoint a saroknál egy belevágott csatlakozást használ. Nagyobb limit élesebb pontokat enged. A beállítás csak a miter csatlakozásokra vonatkozik, és nincs látható hatása, ha a sarok mindkét limit között marad.

Ez a példa két azonos, kitöltés nélküli háromszöget hoz létre, 20 pont széles körvonallal. A bal háromszög a `2` limitet használja, a jobb a `8`-at. Mindkét háromszög 80 pont széles és 160 pont magas, így a felső csúcs miter‑hossz‑vonalszélesség aránya körülbelül `4.12`. Ennek következtében a PowerPoint a bal csúcsot belevágja, a jobb csúcsot megtartja.

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

Az eredmény a PowerPointban: **Miter limit 2** a bal oldalon és **miter limit 8** a jobb oldalon.

![Leeltávolított csúcs miter limit 2-vel és hegyes csúcs miter limit 8-cal a PowerPointban](miter-limits.png)

## **Gradient kitöltés**

A gradient kitöltés színeket kever egy alakzaton belül. Ez a példa egy ellipszist tölt ki lineáris gradienttel 45 fokos szögben a pirosból a lila felé az [IFillFormat.GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/gradientformat/) használatával. Az [IGradientStopCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/igradientstopcollection/add/) metódus a színállomásokat a 0 és 1 pozícióra helyezi, a gradient elejére és végére. A meglévő állomások törlése biztosítja, hogy csak ez a két szín legyen használva.

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

Ha egy gradient a exportált képen másként jelenik meg, mint a PowerPointban, lásd a [Choose a Gradient Rendering Style](/slides/hu/net/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy renderelési stílust anélkül, hogy megváltoztatná a prezentációban tárolt gradient kitöltést.

### **Lineáris gradient szög beállítása**

Használja az [IGradientFormat.LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) elemet a [GradientShape.Linear](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) kitöltés tájolásának szabályozásához. A szöget fokban mérik, és az óramutató járásával megegyezően növekszik: `0` balról jobbra fut, `90` felülről lefelé, `180` jobbról balra, és `270` alulról felülre. Tört szögek is támogatottak. A `[0, 360)` tartományon kívüli véges szögeket egy teljes fordulatra normalizálják; például a `-45` `315`-t, a `360` pedig `0`-t lesz.

Ez a példa hat téglalapot hoz létre azonos piros, zöld és kék színállomásokkal a `0`, `0.5` és `1` pozíciókban. A méretezés ki van kapcsolva, hogy a szög összehasonlítható legyen a téglalapok arányától függetlenül. A szögek balról jobbra: `0`, `45` és `90` az első sorban, a második sorban pedig `135`, `180` és `270`.

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

### **Lineáris gradient méretezése az alakzattal**

Az [IGradientFormat.LinearGradientScaled](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientscaled/) egy [NullableBool](https://reference.aspose.com/slides/net/aspose.slides/nullablebool/) értéket fogad el. Állítsa kifejezetten `False`‑ra, hogy a geometriai gradient szög megmaradjon, amikor az alakzat arányai változnak, vagy `True`‑ra, hogy a gradient az alakzat szélességével és magasságával együtt méreteződjön. A méretezés engedélyezése esetén a látható szög eltérhet a nem négyzet alakzatnál a hozzárendelt szögtől.

A következő példa `45` fokos szöget és ugyanazt a színállomást használja, mint a szöghasonlításnál. A bal oszlop `False`‑t használ; a jobb oszlop `True`‑t. Minden oszlop egy széles téglalapot tartalmaz egy magas téglalap fölött. Mindkettő ugyanazzal a széles mérettel kezdődik; a második téglalap szélességének és magasságának módosítása bemutatja, hogyan reagál a kitöltés átméretezésre azért, hogy ne változtassa meg a gradient beállításait.

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

Az eredmény a PowerPointban, bal oldalon a méretezés letiltva és jobb oldalon engedélyezve:

![Széles és magas téglalapok 45 fokos gradienttel, összehasonlítva a bal oldalon a LinearGradientScaled False értéket a jobb oldalon a True értékkel](linear-gradient-scaling.png)

A méretezés letiltásakor a diagonális színcsíkok ugyanazt a tájolást megtartják mindkét téglalapon. Méretezés engedélyezésekor a csíkok a alakzat arányával nyúlnak. Ez segít egy sablon gradientjének reprodukálásában, amikor egy alakzatot más méretre alakítunk. Négyzet esetén a méretezés engedélyezése nem változtatja meg a `45` fokos gradient megjelenését.

Mind a szög, mind a méretezés beállítása lineáris gradientekre vonatkozik. Nem befolyásolják a [GradientShape.Radial or GradientShape.Rectangle](https://reference.aspose.com/slides/net/aspose.slides/gradientshape/) kitöltéseket.

### **A szög kombinálása a gradient irányával**

Az [IGradientFormat.GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/gradientdirection/) egy gradient stílust választ a [GradientDirection](https://reference.aspose.com/slides/net/aspose.slides/gradientdirection/) felsoroló típusból; nem helyettesíti a numerikus szöget. Lineáris gradient esetén a sarok stílusok megváltoztathatják a színek elosztását anélkül, hogy a [LinearGradientAngle](https://reference.aspose.com/slides/net/aspose.slides/igradientformat/lineargradientangle/) változna. Tartsa a irányt változatlanul, amikor szögeket vagy méretezést hasonlít.

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

A minta kitöltés két színű mintát alkalmaz, például pontokat, csíkokat vagy négyzethálót. Ez a példa az [IPatternFormat.PatternStyle](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/patternstyle/) segítségével egy keresztnet mintát választ. Az [IPatternFormat.BackColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/backcolor/) a világosszürke háttér biztosítja, az [IPatternFormat.ForeColor](https://reference.aspose.com/slides/net/aspose.slides/ipatternformat/forecolor/) a sárga minta színt.

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

A kép kitöltés egy képet helyez el egy alakzaton belül. Ez a példa egy helyi képet igényel, és a [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) használatával tölti be a prezentáció képgyűjteményébe. Az [IPictureFillFormat.PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/) beállítása a mozaikos módra megismétli a képet a téglalapon belül. Az itt használt forráskép alább látható:

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

### **Kép mozaikként textúra**

Ha egy mozaikos képet textúraként szeretne beállítani, és testre szabni a mozaik viselkedését, a következő [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) felület és [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) osztály tulajdonságait használhatja:

- [PictureFillMode](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/picturefillmode/): Beállítja a kép kitöltési módot – `Tile` vagy `Stretch`.
- [TileAlignment](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilealignment/): Megadja a csempék igazítását az alakzaton belül.
- [TileFlip](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileflip/): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [TileOffsetX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsetx/): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [TileOffsetY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tileoffsety/): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [TileScaleX](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescalex/): Meghatározza a csempe vízszintes méretezését százalékban.
- [TileScaleY](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/tilescaley/): Meghatározza a csempe függőleges méretezését százalékban.

Ez a példa egy helyi képet igényel, és a [IPictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/ipicturefillformat/) beállítja, hogy a képet az eredeti méretének 50%-án ismételje. A `−32` pont eltolások a csempéket vízszintesen és függőlegesen eltolják; a jobb‑alsó illesztés és a mindkét irányban történő tükrözés határozza meg, hogyan rendeződik az ismételt textúra.

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

![A csempe beállítások](tile-options.png)

## **Szilárd szín kitöltés**

A szilárd kitöltés egyetlen, egységes színt ad az alakzatnak. Ez a példa a [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értékét a szilárd kitöltési módra állítja, és a [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) segítségével sárgát rendel, majd a téglalapot egy prezentációba menti.

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

![Az alakzat szilárd szín kitöltéssel](solid-color-fill.png)

## **A dia háttér használata alakzat kitöltésként**

Használja a [IAutoShape.UseBackgroundFill](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/usebackgroundfill/) elemet, ha egy alakzatnak illeszkednie kell a dia háttéréhez, például egy prezentációs sablonban. Állítsa a [IFillFormat.FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) értékét először a [FillType.NotDefined](https://reference.aspose.com/slides/net/aspose.slides/filltype/) értékre, hogy eltávolítsa az esetleges kifejezett kitöltést. Ezzel a kombinációval az alakzat a dia háttérét használja a saját stílus kitöltése helyett. A jelző engedélyezése önmagában nem távolítja el a meglévő kifejezett kitöltést.

Ez eltér a [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/)-től: a háttér kitöltés a forma mögött lévő objektumokat a megfelelő diaháttér területével fedi le, míg a NoFill azok az objektumok láthatóak maradnak. A gradient a diához igazítódik, ahelyett, hogy minden egyes alakzat belsejében újra indulna.

A következő példa egy mesterháttért hoz létre, amelyet a dia örököl, és egy bíbor szalagot helyez három téglalap mögé. A bal téglalap a háttérkitöltést használja, a középsőnek nincs kitöltése, a jobb téglalap a háttérkitöltésről egy kifejezett narancssárga kitöltésre vált.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
presentation.SlideSize.SetSize(720, 400, SlideSizeScaleType.DoNotScale);
var slide = presentation.Slides[0];

// A gradient örökölése a mastertől.
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

// A háttér kitöltés letiltása, mielőtt kifejezett kitöltést alkalmazna.
explicitShape.UseBackgroundFill = false;
explicitShape.FillFormat.FillType = FillType.Solid;
explicitShape.FillFormat.SolidFillColor.Color = Color.Orange;

presentation.Save("background_fill.pptx", SaveFormat.Pptx);
```

Az eredmény balról jobbra: **háttér kitöltés**, **nincs kitöltés**, és **kifejezett kitöltés**. A bíbor szalagot a bal és jobb téglalap elrejti, de a középsőn keresztül látható marad.

![Háttér kitöltés, nincs kitöltés és kifejezett narancssárga kitöltés egy bíbor szalag felett](background-fill.png)

Ugyanez a viselkedés a diára közvetlenül meghatározott vagy egy elrendezésből örökölt háttér esetén is érvényes. Az alakzat a dia feloldott hátterét használja; a példa a dia és elrendezés hátterét is undefined állapotra hagyja, hogy a mester biztosítsa azt.

## **Átlátszóság beállítása**

Szilárd kitöltés esetén a szín alfa komponense szabályozza az átlátszatlanságot: a `0` teljesen átlátszó, a `255` teljesen átlátszatlan. Ez a példa egy `128` alfa értéket használ egy sárga téglalaphoz, így körülbelül 50 % átlátszó, hogy az alatta lévő téglalap látható maradjon. A színt a [IFillFormat.SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) segítségével rendeli hozzá.

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

Használja az [IShape.Rotation](https://reference.aspose.com/slides/net/aspose.slides/ishape/rotation/) elemet egy alakzat forgatásához a dia síkján. A szöget fokban mérik; ez a példa egy téglalapot 5 fokkal forgat az óramutató járásával megegyező irányba, majd menti a prezentációt.

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

## **3D élesítés effektusok hozzáadása**

Használja az [IShape.ThreeDFormat](https://reference.aspose.com/slides/net/aspose.slides/ishape/threedformat/) elemet, hogy egy alakzatnak mélységet és élesített éleket adjon. Ez a példa egy zöld ellipszist hoz létre narancssárga körvonallal, a [IThreeDFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/depth/) értéket 4 pontra állítja, és egy körkörös felső élesítést alkalmaz 6 pont szélesség‑magasság paraméterekkel a [IThreeDFormat.BevelTop](https://reference.aspose.com/slides/net/aspose.slides/ithreedformat/beveltop/) használatával. Egy frontális ortografikus kamera és hárompontos megvilágítás teszi láthatóvá az élesítést.

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

![A 3D élesítés effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Egy alakzat 3D nézete a kamera beállításai által szabályozott. Ez a példa az [ICamera.SetRotation](https://reference.aspose.com/slides/net/aspose.slides/icamera/setrotation/) elemet használja 40, 35 és 20 fokos földrajzi, hosszúsági és fordulási szögekkel. Az [ICamera.CameraType](https://reference.aspose.com/slides/net/aspose.slides/icamera/cameratype/) segítségével egy izometrikus kamerát, az [ILightRig.LightType](https://reference.aspose.com/slides/net/aspose.slides/ilightrig/lighttype/) segítségével pedig kiegyensúlyozott megvilágítást választ, majd menti a formázott téglalapot.

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

Az [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) tulajdonság meghatározza, hogyan jelenik meg egy adott alakzat, amikor egy prezentációt fekete-fehér módban tekintenek vagy dolgoznak fel. Önmagában nem engedélyez fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/blackwhitemode/) felsoroló típusból a kívánt viselkedés kiválasztásához. Például az `Automatic` megengedi, hogy a renderelő alkalmazás válassza ki a konverziót, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehér megjelenítést, a `Black` és a `White` egyetlen színt kényszerítenek, a `Color` megőrzi a normál színezést, a `Hidden` elhagyja az alakzatot a fekete‑fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzatszintű mód hozzárendelve.

Ez a példa egy narancssárga téglalapot hoz létre és a [IShape.BlackWhiteMode](https://reference.aspose.com/slides/net/aspose.slides/ishape/blackwhitemode/) értékét `Gray`‑ra állítja. A mentett alakzat normál színmódban megtartja a narancssárga kitöltést, és a fekete‑fehér megjelenítési beállításokat tiszteletben tartó alkalmazásoktól szürke színezést kér.

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

Normál színmódban a téglalap megtartja a narancssárga kitöltést. Fekete‑fehér megjelenítési munkafolyamatban szürke színezést használ, mert módja `Gray`‑ra van állítva. Ez lehetővé teszi, hogy egy teljes színű diát megőrizzen, miközben egy különálló megjelenést definiál nyomtatáshoz, előnézethez vagy egyéb munkafolyamatokhoz, amelyek tiszteletben tartják a prezentáció fekete‑fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Használja az [ISlide.Reset](https://reference.aspose.com/slides/net/aspose.slides/islide/reset/) elemet a diahelyőrzők pozíciójának, méretének és formázásának visszaállításához a megfelelő elrendezéshelyőrzőkből. Ez a példa egy meglévő prezentációt igényel, amely elrendezéshez kapcsolt helyőrzőkkel rendelkezik, és a mentés előtt minden diát visszaállít. Az olyan alakzatok, amelyeknek nincs megfelelő elrendezéshelyőrzője, nem lesznek visszaállítva.

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

**Az alakzat formázása befolyásolja a végső prezentáció fájlméretét?**

A színek, vonalstílusok és effektus beállítások általában kevés adatot adnak hozzá a beágyazott képekhez és médiához képest. A képet kitöltő elemek növelhetik a fájlméretet, mivel a képeik a prezentációban vannak tárolva.

**Hogyan észlelhetem a diákon azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállítások. Ha minden megfelelő érték egyezik, tekintse őket azonos stílusúaknak, és logikusan csoportosítsa ezeket az alakzatokat, ezáltal egyszerűsítve a későbbi stíluskezelést.

**Menthetek-e egyedi alakzatstílusok gyűjteményét egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon diákkészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra formázásukat ahol szükséges.