---
title: Přizpůsobení tvarů prezentací v .NET
linktitle: Vlastní tvar
type: docs
weight: 20
url: /cs/net/custom-shape/
keywords:
- vlastní tvar
- přidat tvar
- vytvořit tvar
- změnit tvar
- geometrie tvaru
- geometrická cesta
- body cesty
- upravit body
- přidat bod
- odebrat bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v prezentacích PowerPoint pomocí Aspose.Slides pro .NET: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary v prezentaci v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) aby bylo možné upravit existující tvary, provádět základní operace úpravy cesty, přidávat nebo odstraňovat body a aplikovat aktualizovanou geometrii zpět na tvar.

Také demonstruje, jak vytvořit vlastní a složené tvary, vytvořit tvary zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, a použít starší konverzi mezi [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí editačních bodů**

V PowerPointu můžete použít **Edit Points** k úpravě čtverce:

* Přesunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní měnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![přehled_obrázek](custom_shape_0.png)

Při úpravě tvarů v PowerPointu mějte na paměti následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřená, nebo otevřená.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotevní body a ovládací úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou dva ovládací úchyty zarovnány a jsou stejně vzdálené od kotevního bodu.
  * U přímého bodu jsou dva ovládací úchyty zarovnány, ale mohou mít různou vzdálenost od kotevního bodu.
* Přesunutím kotevních bodů nebo úpravou jejich úchytů se mění obrys tvaru.

Pro úpravu tvarů v PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a rozhraní [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Instance [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Chcete-li získat [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) z instance [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/), můžete použít metodu [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) pro tvary s jednou cestou a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody v rozhraní [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Pomocí vlastností [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) a [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) můžete nastavit vzhled geometrické cesty.
* Pomocí vlastnosti [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) jako pole segmentů cesty.
* Ve starších verzích, které podporují níže uvedené konverzní metody, můžete převést [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) na [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Použijte metody [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (třídy [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) pro konverzi mezi [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Jednoduché operace úprav**

Použijte následující metody k úpravě geometrické cesty. Přetížení, která přijímají index, vloží segment na tuto nulovou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidání nebo vložení přímé čáry. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Přidání nebo vložení kubické Bézierovy křivky se dvěma řídicími body a koncovým bodem. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Přidání nebo vložení kvadratické Bézierovy křivky s jedním řídicím bodem a koncovým bodem. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Přidat eliptický úsek se zadanými rozměry a úhly ve stupních. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Uzavřít aktuální útvar spojení koncového bodu s počátečním bodem. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Nastavit počáteční bod útvaru. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Odstranit segment na nulovém indexu. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do obdélníkového tvaru pomocí [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) a aplikuje upravenou cestu pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Souřadnice jsou lokální vzhledem k tvaru: oba nové body jsou uprostřed, 100 bodů od levého okraje a 50 bodů od horního. Indexy segmentů 1 a 4 je umístí na horní a dolní hranu, čímž tyto hrany stáhnou dovnitř.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var geometryPath = shape.GetGeometryPaths()[0];
geometryPath.LineTo(100, 50, 1);
geometryPath.LineTo(100, 50, 4);

shape.SetGeometryPath(geometryPath);
```

![příklad1_obrázek](custom_shape_1.png)

## **Odstranění bodů z tvaru**

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nulovém indexu 2 pomocí [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Aplikace upravené cesty pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje konturu tvaru.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```

![příklad2_obrázek](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů určují špičky a zapouzdření; krok 72 stupňů rovnoměrně rozprostře pět špiček. Cesta je uzavřena pomocí [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) a aplikována na obdélníkový tvar pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), čímž nahradí jeho obrys.

```csharp
using System;
using System.Collections.Generic;
using System.Drawing;
using Aspose.Slides;

var points = new List<PointF>();

var outerRadius = 100f;
var innerRadius = 50f;
var angleStep = 72;

for (var angle = -90; angle < 270; angle += angleStep)
{
    var radians = angle * (Math.PI / 180f);
    var x = outerRadius * Math.Cos(radians);
    var y = outerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));

    radians = Math.PI * (angle + angleStep / 2) / 180.0;
    x = innerRadius * Math.Cos(radians);
    y = innerRadius * Math.Sin(radians);
    points.Add(new PointF((float)x + outerRadius, (float)y + outerRadius));
}

var starPath = new GeometryPath();
starPath.MoveTo(points[0]);

for (var i = 1; i < points.Count; i++)
{
    starPath.LineTo(points[i]);
}

starPath.CloseFigure();

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, outerRadius * 2, outerRadius * 2);
shape.SetGeometryPath(starPath);
```

![příklad3_obrázek](custom_shape_3.png)

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) pro horní a dolní třetinu tvaru. Aplikací obou cest pomocí [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) vznikne jediný složený tvar s mezerou přes jeho střední třetinu.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

var topPath = new GeometryPath();
topPath.MoveTo(0, 0);
topPath.LineTo(shape.Width, 0);
topPath.LineTo(shape.Width, shape.Height / 3);
topPath.LineTo(0, shape.Height / 3);
topPath.CloseFigure();

var bottomPath = new GeometryPath();
bottomPath.MoveTo(0, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```

![příklad4_obrázek](custom_shape_4.png)

## **Vytvoření vlastního tvaru s zakřivenými rohy**

Tento příklad kombinuje přímé segmenty s [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) aby vytvořil tvar se zakřivenými rohy dovnitř. Velikost každého rohu určuje šířku a výšku oblouku v bodech a otočení -90 stupňů vykreslí proti směru hodinových ručiček čtvrtkruhový elipsový úsek. Hotová cesta je použita pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) a prezentace je uložena ve formátu PPTX.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var shapeX = 20f;
var shapeY = 20f;
var shapeWidth = 300f;
var shapeHeight = 200f;

var leftTopSize = 50f;
var rightTopSize = 20f;
var rightBottomSize = 40f;
var leftBottomSize = 10f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var topLeft = new PointF(leftTopSize, 0);
var topRight = new PointF(shapeWidth - rightTopSize, 0);
var rightBottom = new PointF(shapeWidth, shapeHeight - rightBottomSize);
var bottomLeft = new PointF(leftBottomSize, shapeHeight);
var leftTop = new PointF(0, leftTopSize);

var geometryPath = new GeometryPath();
geometryPath.MoveTo(topLeft);
geometryPath.LineTo(topRight);
geometryPath.ArcTo(rightTopSize, rightTopSize, 180, -90);
geometryPath.LineTo(rightBottom);
geometryPath.ArcTo(rightBottomSize, rightBottomSize, -90, -90);
geometryPath.LineTo(bottomLeft);
geometryPath.ArcTo(leftBottomSize, leftBottomSize, 0, -90);
geometryPath.LineTo(leftTop);
geometryPath.ArcTo(leftTopSize, leftTopSize, 90, -90);
geometryPath.CloseFigure();

var shape = slide.Shapes.AddAutoShape(ShapeType.Custom, shapeX, shapeY, shapeWidth, shapeHeight);
shape.SetGeometryPath(geometryPath);

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Zjištění, zda je geometrie tvaru uzavřená**

Následující pomocná metoda kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Čte [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) a porovnává poslední segmentův [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) s [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Vrátí false, když neexistují neprázdné cesty. Toto kontroluje poslední příkaz každé cesty; neprozkoumává každou podčást v rámci cesty. Příklad vytiskne `True` pro obdélník.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);
Console.WriteLine(IsGeometryClosed(shape));

bool IsGeometryClosed(IGeometryShape geometryShape)
{
    var hasNonemptyPath = false;

    foreach (var geometryPath in geometryShape.GetGeometryPaths())
    {
        var segments = geometryPath.PathData;
        if (segments.Length == 0)
        {
            continue;
        }

        hasNonemptyPath = true;
        var lastSegment = segments[segments.Length - 1];
        if (lastSegment.PathCommand != PathCommandType.Close)
        {
            return false;
        }
    }

    return hasNonemptyPath;
}
```

## **Prohlédnutí příkazů geometrické cesty**

Stáhněte [contour.pptx](contour.pptx) a umístěte jej do pracovního adresáře aplikace. První snímek obsahuje tvar se svislým horním okrajem, kubickou Bézierovou křivkou a přímým uzavíracím okrajem. Použijte [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/) k načtení jeho cest. Každá cesta uvádí své segmenty v pořadí kreslení v [PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/). Každý segmentův [PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) určuje, jak číst jeho [SegmentData](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/segmentdata/).

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("contour.pptx");

var shape = (IGeometryShape)presentation.Slides[0].Shapes[0];
var paths = shape.GetGeometryPaths();

for (int i = 0; i < paths.Length; i++)
{
    var segments = paths[i].PathData;
    for (int j = 0; j < segments.Length; j++)
    {
        var command = segments[j].PathCommand;
        var data = segments[j].SegmentData;
        var detail = command switch
        {
            PathCommandType.MoveTo or PathCommandType.LineTo => $"destination=({data[0]}, {data[1]})",
            PathCommandType.CubicBezierTo => $"control1=({data[0]}, {data[1]}) control2=({data[2]}, {data[3]}) end=({data[4]}, {data[5]})",
            PathCommandType.Close => "no coordinates",
            _ => $"raw=[{string.Join(", ", data)}]"
        };
        Console.WriteLine($"Path {i}, segment {j}: {command} {detail}");
    }
}
```

Tvar je umístěn na (200, 100) bodech na snímku. Uvedené body jsou lokální vzhledem k tvaru, s (0, 0) v jeho levém horním rohu, x roste doprava a y dolů. Uzavírací segment se vrací do počátečního bodu bez dalších souřadnic.

```text
Path 0, segment 0: MoveTo destination=(0, 0)
Path 0, segment 1: LineTo destination=(80, 0)
Path 0, segment 2: CubicBezierTo control1=(70, 15) control2=(30, 45) end=(0, 60)
Path 0, segment 3: Close no coordinates
```

![Tvar PowerPoint s rovným horním okrajem, zakřiveným okrajem od pravého horního k levému dolnímu a rovným levým okrajem](contour.png)

## **Extrahování a prohlédnutí prvků tvaru**

Použijte [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) abyste prozkoumali existující tvar jako prvky obsahující body cesty a typy bodů. Pro každou vrácenou [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) přetypujte na [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) abyste přečetli její pole [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) a [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Toto zastoupení je užitečné pro analýzu kontur nebo předávání geometrie nástrojům pro vlastní kreslení.

Příklad otevře prezentaci, najde první geometrický tvar přímo na prvním snímku a vytiskne jeho segmenty cesty. Použijte prezentaci, která obsahuje tvar s přímými i zakřivenými segmenty, abyste viděli oba typy výstupu. Nepřehledává skupiny.

```csharp
using System;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("input.pptx");
var slide = presentation.Slides[0];

var shape = slide.Shapes.OfType<IGeometryShape>().FirstOrDefault();
if (shape == null)
{
    Console.WriteLine("No geometry shape found on the first slide.");
    return;
}

foreach (IShapeElement element in shape.CreateShapeElements())
{
    var shapeElement = (ShapeElement)element;
    var points = shapeElement.PathPoints;
    var types = shapeElement.PathTypes;
    Console.WriteLine("Shape element:");

    for (var i = 0; i < points.Length; i++)
    {
        var pointType = types[i] & 0x07; // Udržet typ segmentu, vyjma příznaků.
        switch (pointType)
        {
            case 0:
                Console.WriteLine($"Start figure at {points[i]}");
                break;
            case 1:
                Console.WriteLine($"Line to {points[i]}");
                break;
            case 3:
                Console.WriteLine($"Cubic Bezier: controls {points[i]}, {points[i + 1]}; end {points[i + 2]}");
                i += 2; // Consume both control points and the endpoint.
                break;
        }

        if ((types[i] & 0x80) != 0)
        {
            Console.WriteLine("Close subpath back to its starting point.");
        }
    }
}
```

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje útvar a typ `1` kreslí čáru od předchozího bodu k aktuálnímu. Kubický Bézier segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí položky typu `3`: dva řídicí body a poté nový koncový bod. Smyčka spotřebuje tyto tři položky najednou a kontroluje koncový bod pro uzavření.

Typy bodů také obsahují příznaky. Pomocí masky `0x07` identifikujte typ segmentu a testujte `0x80` zvlášť pro detekci uzavřené podcesty. Například `129` (`0x81`) znamená koncový bod čáry, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá podcestu. Porovnání surové hodnoty jen s `1` nebo `3` by tyto případy přehlédlo. Ostatní příznaky, jako čárka (`0x10`) a značka (`0x20`), nemění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), přičemž X roste doprava a Y dolů. Pro neseskupený tvar extrahované souřadnice již zahrnují jeho pozici [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) a odrážejí jeho aktuální šířku a výšku. Například neotočený obdélník v `(100, 200)` s rozměry `120 × 80` má kontury `(100, 200)`–`(220, 280)`. Nepřidávejte pozici tvaru znovu. Odečtěte jeho X a Y, aby byly souřadnice relativní k jeho neotočenému rámci.

Extrahované body neaplikují [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) tvaru ani vodorovné a svislé převrácení. Pro reprodukci zobrazené kontury aplikujte tyto transformace kolem středu tvaru. Pro seskupené tvary také zohledněte mapování souřadnic skupiny a transformace; nepředpokládejte, že extrahované body jsou konečné vykreslené souřadnice snímku, ani neaplikujte posun nebo škálu dvakrát, pokud už jsou zahrnuty v rámci potomka.

**Inspekce vs. úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Zvolte tento přístup, když vaše analytické nebo kreslící kódy potřebují pole bodů/typů. Použijte [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/), pokud potřebujete příkazy geometrie v lokálním souřadnicovém systému tvaru nebo chcete upravit jeho geometrii. Použijte upravené cesty pomocí [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) nebo [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Převod GeometryPath na GraphicsPath (System.Drawing.Drawing2D)**

Následující příklad vyžaduje starší sestavení Aspose.Slides pro .NET, které podporuje [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), například verzi 25.10, a Windows prostředí s `System.Drawing.Common`. Konverzní metody byly odstraněny ve [verzi 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Tento příklad kombinuje obdélníkový obrys s textem převedeným na geometrii. Obrysova [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) je nastavena tak, aby zakázala výplň. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) ukládá obrys textu, který [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) převádí na vyplněnou geometrickou cestu. Aplikací obou cest pomocí [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) vznikne jediný tvar obsahující obdélník a text. Pro převod v opačném směru použijte [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

```csharp
using System.Drawing;
using System.Drawing.Drawing2D;
using Aspose.Slides;
using Aspose.Slides.Util;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 100);

var originalPath = shape.GetGeometryPaths()[0];
originalPath.FillMode = PathFillModeType.None;

using var graphicsPath = new GraphicsPath();
using var fontFamily = new FontFamily("Arial");
using var stringFormat = StringFormat.GenericDefault;

graphicsPath.AddString("Text in shape", fontFamily, (int)FontStyle.Bold, 40, new PointF(10, 10), stringFormat);

var textPath = ShapeUtil.GraphicsPathToGeometryPath(graphicsPath);
textPath.FillMode = PathFillModeType.Normal;

shape.SetGeometryPaths(new[] { originalPath, textPath });
```

![příklad5_obrázek](custom_shape_5.png)

## **Často kladené otázky**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstává u tvaru; mění se pouze kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte vlastnost [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána se souřadnicovým systémem tvaru.

**Mohu převést vlastní tvar na obrázek, aby byl výsledek „uzamčen“?**

Ano. Exportujte požadovanou oblast [slide](/slides/cs/net/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/net/create-shape-thumbnails/) do rastrového formátu; to usnadňuje další práci se složitými geometrickými tvary.