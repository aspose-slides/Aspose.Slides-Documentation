---
title: Přizpůsobení tvarů prezentace v .NET
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
- editační body
- přidat bod
- odstranit bod
- operace úpravy
- zakřivený roh
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvářejte a přizpůsobujte tvary v PowerPoint prezentacích pomocí Aspose.Slides pro .NET: geometrické cesty, zakřivené rohy, složené tvary."
---
## **Přehled**

Tento článek vysvětluje, jak přizpůsobit tvary prezentace v Aspose.Slides úpravou geometrie tvaru pomocí editačních bodů a geometrických cest. Ukazuje, jak pracovat s [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/) pro úpravu existujících tvarů, provádění základních operací úprav cest, přidávání nebo odstraňování bodů a aplikaci aktualizované geometrie zpět na tvar.

Také ukazuje, jak vytvořit vlastní a složené tvary, sestavit tvary se zakřivenými rohy, zjistit, zda je geometrie tvaru uzavřená, a použít starší konverzi mezi [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) pro další scénáře přizpůsobení geometrie.

## **Změna tvaru pomocí editačních bodů**

V PowerPoint můžete použít **Edit Points** k úpravě čtverce:

* Posunout roh dovnitř nebo ven.
* Upravit zakřivení v bodě.
* Přidat nové body.

Úprava bodů vám umožní změnit obrys tvaru nebo použít existující tvar jako základ pro nový.

## **Tipy pro úpravu tvarů**

![overview_image](custom_shape_0.png)

Při úpravě tvarů PowerPointu mějte na paměti následující pojmy:

* Tvar (nebo jeho cesta) může být buď uzavřená, nebo otevřená.
* Cesta tvaru se skládá z kotevních bodů spojených segmenty.
* Segment může být přímý nebo zakřivený. Kotevní body a řídící úchyty určují jeho tvar.
* Kotevní body existují jako rohové body, přímé body nebo hladké body:
  * U rohového bodu se sousední segmenty mohou setkat pod úhlem.
  * U hladkého bodu jsou dva řídící úchyty zarovnány a stejně vzdáleny od kotevního bodu.
  * U přímého bodu jsou dva řídící úchyty zarovnány, ale mohou mít různou vzdálenost od kotevního bodu.
* Posun kotevních bodů nebo úprava jejich úchytů mění obrys tvaru.

Pro úpravu tvarů PowerPointu pomocí editačních bodů poskytuje **Aspose.Slides** třídu [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a rozhraní [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).

* Instanci [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) představuje geometrickou cestu objektu [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/).
* Pro získání [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) z instance [IGeometryShape](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/) můžete použít metodu [IGeometryShape.GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/).
* Pro nastavení [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) pro tvar můžete použít tyto metody: [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) pro tvary s jednou cestou a [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) pro tvary s více cestami.
* Pro přidání segmentů můžete použít metody pod rozhraním [IGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/).
* Pomocí vlastností [IGeometryPath.Stroke](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/stroke/) a [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) můžete nastavit vzhled geometrické cesty.
* Pomocí vlastnosti [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) můžete získat geometrickou cestu [GeometryShape](https://reference.aspose.com/slides/net/aspose.slides/geometryshape/) jako pole segmentů cesty.
* Ve starších verzích, které podporují níže uvedené konverzní metody, můžete převést [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) na [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).
* Použijte metody [GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/) a [GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) (z třídy [ShapeUtil](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/)) pro konverzi mezi [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) a [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath).

## **Jednoduché operace úprav**

Použijte následující metody k úpravě geometrické cesty. Přetížené verze, které přijímají index, vloží segment na tuto nulově založenou pozici v poli segmentů cesty.

| Operace | Metoda |
| --- | --- |
| Přidat nebo vložit přímou čáru. | [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) |
| Přidat nebo vložit kubickou Bézierovu křivku se dvěma řídícími body a koncovým bodem. | [GeometryPath.CubicBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/cubicbezierto/) |
| Přidat nebo vložit kvadratickou Bézierovu křivku s jedním řídícím bodem a koncovým bodem. | [GeometryPath.QuadraticBezierTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/quadraticbezierto/) |
| Přidat eliptický oblouk se zadanými rozměry a úhly ve stupních. | [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) |
| Uzavřít aktuální obrazec propojením koncového bodu se startovním bodem. | [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) |
| Nastavit výchozí bod obrazce. | [GeometryPath.MoveTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/moveto/) |
| Odstranit segment na nulově založeném indexu. | [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/) |

## **Přidání vlastních bodů do tvaru**

Tento příklad vloží dva body do pravoúhlého tvaru pomocí [GeometryPath.LineTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/lineto/) a aplikuje upravenou cestu pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/). Souřadnice jsou lokální k tvaru: oba nové body jsou ve středu, 100 bodů od levého okraje a 50 bodů od horního. Indexy segmentů 1 a 4 je umístí na horní a dolní hranu, čímž tyto hrany stáhnou dovnitř.

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

![example1_image](custom_shape_1.png)

## **Odstranění bodů z tvaru**

Tento příklad mění obrys ve tvaru srdce odstraněním segmentu na nulově založeném indexu 2 pomocí [GeometryPath.RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/removeat/). Aplikace upravené cesty pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) aktualizuje konturu tvaru.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Heart, 100, 100, 300, 300);

var path = shape.GetGeometryPaths()[0];
path.RemoveAt(2);

shape.SetGeometryPath(path);
```
![example2_image](custom_shape_2.png)

## **Vytvoření vlastního tvaru**

Tento příklad vytvoří pěticípou hvězdu pomocí [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/). Střídavé vnější a vnitřní poloměry 100 a 50 bodů definují špičky a rezy; krok 72 stupňů rovnoměrně rozmístí pět špiček. Cesta je uzavřena pomocí [GeometryPath.CloseFigure](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/closefigure/) a aplikována na pravoúhlý tvar pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), čímž nahradí jeho obrys.

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
![example3_image](custom_shape_3.png)

## **Vytvoření složeného vlastního tvaru**

Tento příklad definuje dva uzavřené objekty [GeometryPath](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/) pro horní a dolní třetinu tvaru. Aplikace obou cest pomocí [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) vytvoří jeden složený tvar s mezerou ve střední třetině.

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
bottomPath.MoveTo(shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height / 3 * 2);
bottomPath.LineTo(shape.Width, shape.Height);
bottomPath.LineTo(0, shape.Height);
bottomPath.CloseFigure();

shape.SetGeometryPaths(new GeometryPath[] { topPath, bottomPath });
```
![example4_image](custom_shape_4.png)

## **Vytvoření vlastního tvaru se zakřivenými rohy**

Tento příklad kombinuje přímé segmenty s [GeometryPath.ArcTo](https://reference.aspose.com/slides/net/aspose.slides/geometrypath/arcto/) k vytvoření tvaru se zakřivenými rohy dovnitř. Každá velikost rohu určuje šířku a výšku oblouku v bodech a úhel –90 stupňů vykreslí proti směru hodinových ručiček čtvrtkruh. Dokončená cesta je aplikována pomocí [IGeometryShape.SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/), a prezentace je uložena ve formátu PPTX.

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

## **Zjistit, zda je geometrie tvaru uzavřená**

Následující pomocná metoda kontroluje, zda každá neprázdná geometrická cesta končí uzavíracím segmentem. Čte [IGeometryPath.PathData](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/pathdata/) a porovnává poslední segmentů [IPathSegment.PathCommand](https://reference.aspose.com/slides/net/aspose.slides/ipathsegment/pathcommand/) s [PathCommandType.Close](https://reference.aspose.com/slides/net/aspose.slides/pathcommandtype/). Vrátí false, když neexistují neprázdné cesty. Tato kontrola zkoumá poslední příkaz každé cesty; neinspekcovaně zkoumá všechny podobrazce uvnitř cesty. Příklad vypíše `True` pro pravoúhlý tvar.

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

## **Extrahování a inspekce prvků tvaru**

Použijte [IGeometryShape.CreateShapeElements](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/createshapeelements/) k prozkoumání existujícího tvaru jako prvků obsahujících body cesty a typy bodů. Přetypujte každý vrácený [IShapeElement](https://reference.aspose.com/slides/net/aspose.slides/ishapeelement/) na [ShapeElement](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/) a přečtěte jeho pole [PathPoints](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathpoints/) a [PathTypes](https://reference.aspose.com/slides/net/aspose.slides/shapeelement/pathtypes/). Toto znázornění je užitečné pro analýzu kontur nebo předání geometrie vlastním kreslicím nástrojům.

Příklad otevře prezentaci, najde první geometrický tvar přímo na první snímku a vypíše jeho segmenty cesty. Použijte prezentaci obsahující tvar s přímými i zakřivenými segmenty, abyste viděli oba typy výstupu. Neprohledává skupiny.

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
        var pointType = types[i] & 0x07; // Zachovat typ segmentu, vynechat příznaky.
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

Pole odpovídají podle indexu: `points[i]` je bod a `types[i]` popisuje jeho roli. Typ `0` zahajuje obrazec a typ `1` kreslí čáru z předchozího bodu do aktuálního. Kubický Bézier segment začíná na předchozím koncovém bodu a používá tři po sobě jdoucí položky typu `3`: dva řídící body a následně nový koncový bod. Smyčka spotřebuje tyto tři položky najednou a kontroluje koncový bod pro uzavření.

Typy bodů také obsahují příznaky. Pomocí masky `0x07` zjistíte typ segmentu a samostatně testujte `0x80` pro detekci uzavřeného podcesty. Například `129` (`0x81`) znamená koncový bod line, který uzavírá podcestu, a `131` (`0x83`) znamená koncový bod Bézieru, který uzavírá podcestu. Porovnání surové hodnoty jen s `1` nebo `3` by tyto případy přehlédlo. Ostatní příznaky, jako pomlčka (`0x10`) a značka (`0x20`), nezmění základní typ segmentu.

**Souřadnice a transformace.** Body jsou měřeny v bodech (1/72 palce), přičemž X roste doprava a Y dolů. U negruoupovaného tvaru již extrahované souřadnice zahrnují jeho [X](https://reference.aspose.com/slides/net/aspose.slides/shape/x/) a [Y](https://reference.aspose.com/slides/net/aspose.slides/shape/y/) pozici a odrážejí jeho aktuální šířku a výšku. Například neotočený pravoúhlý tvar na `(100, 200)` s velikostí `120 × 80` má obrysové hranice `(100, 200)`–`(220, 280)`. Nepřičítávejte pozici tvaru znovu. Odečtěte jeho X a Y, abyste získali souřadnice relativní k neotočenému rámu.

Extrahované body neaplikují rotaci tvaru ([Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/)) ani horizontální a vertikální převrácení. Pro reprodukci zobrazeného obrysu aplikujte tyto transformace kolem středu tvaru. U seskupených tvarů také zohledněte mapování a transformace souřadnic skupiny; nepředpokládejte, že extrahované body jsou finální souřadnice na snímku, ani je nepřidávejte ani neskalujte dvakrát, pokud jsou již zahrnuty v rámci dítěte.

**Inspekce versus úprava.** Extrahovaná pole popisují konturu; jejich změna neaktualizuje původní tvar. Použijte tento přístup, když vaše analýza nebo kreslicí kód potřebuje pole bodů/typů. Když potřebujete geometrické příkazy v lokálním souřadnicovém systému tvaru nebo chcete editovat jeho geometrii, použijte [GetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/getgeometrypaths/). Upravené cesty aplikujte pomocí [SetGeometryPath](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypath/) nebo [SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/).

## **Převod GeometryPath na GraphicsPath (System.Drawing.Drawing2D)**

Následující příklad vyžaduje starší sestavení Aspose.Slides for .NET, které podporuje [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/), například verzi 25.10, a Windows prostředí s `System.Drawing.Common`. Konverzní metody byly odebrány ve [verzi 25.11](https://releases.aspose.com/slides/net/release-notes/2025/aspose-slides-for-net-25-11-release-notes/).

Tento příklad kombinuje pravoúhlý obrys s textem převedeným na geometrii. Obrysovi [IGeometryPath.FillMode](https://reference.aspose.com/slides/net/aspose.slides/igeometrypath/fillmode/) je nastaveno, aby zakázalo vyplnění. [GraphicsPath](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.graphicspath) ukládá obrys textu, který [ShapeUtil.GraphicsPathToGeometryPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/graphicspathtogeometrypath/) převádí na vyplněnou geometrickou cestu. Aplikace obou cest pomocí [IGeometryShape.SetGeometryPaths](https://reference.aspose.com/slides/net/aspose.slides/igeometryshape/setgeometrypaths/) vytvoří jeden tvar obsahující obdélník i text. Pro převod opačným směrem použijte [ShapeUtil.GeometryPathToGraphicsPath](https://reference.aspose.com/slides/net/aspose.slides.util/shapeutil/geometrypathtographicspath/).

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
![example5_image](custom_shape_5.png)

## **FAQ**

**Co se stane s výplní a obrysem po nahrazení geometrie?**

Styl zůstane u tvaru; mění se jen kontura. Výplň a obrys jsou automaticky aplikovány na novou geometrii.

**Jak správně otočit vlastní tvar spolu s jeho geometrií?**

Použijte vlastnost [Rotation](https://reference.aspose.com/slides/net/aspose.slides/shape/rotation/) tvaru; geometrie se otáčí spolu s tvarem, protože je svázána s jeho vlastním souřadnicovým systémem.

**Mohu převést vlastní tvar na obrázek, aby byl „uzamčen“ výsledek?**

Ano. Exportujte požadovanou [slide](/slides/cs/net/convert-powerpoint-to-png/) nebo samotný [shape](/slides/cs/net/create-shape-thumbnails/) do rastrového formátu; to usnadní další práci s komplexními geometriemi.