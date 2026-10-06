---
title: SmartArt kezelése PowerPoint prezentációkban .NET-ben
linktitle: SmartArt kezelése
type: docs
weight: 10
url: /hu/net/manage-smartart/
keywords:
- SmartArt
- SmartArt szöveg
- elrendezéstípus
- rejtett tulajdonság
- szervezeti ábra
- képes szervezeti ábra
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Tanulja meg a PowerPoint SmartArt létrehozását és szerkesztését az Aspose.Slides for .NET segítségével, érthető C# kópmintákkal, amelyek felgyorsítják a diatervezést és az automatizálást."
---
## **Áttekintés**

A SmartArt egy PowerPoint diagram, amely csomópontokból, csomópont alakzatokból és elrendezésből áll. Az Aspose.Slides for .NET segítségével létrehozhat SmartArt-ot, kiolvashatja a szöveget a csomópontokból, megváltoztathatja az elrendezését, ellenőrizheti a rejtett csomópontokat, konfigurálhatja a szervezeti ábra elrendezéseket, és létrehozhat képes szervezeti ábrákat.

## **Szöveg lekérése SmartArt objektumból**

Egy SmartArt csomópont egy vagy több alakzatot tartalmazhat. A csomópont alakzatok szövegének kiolvasásához iteráljon a [ISmartArt.AllNodes](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/allnodes/), majd olvassa el a [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), amelyet az [ISmartArtShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartshape/textframe/) visszaad.

A példa egy olyan bemutatót igényel, amelyben legalább egy dia és egy SmartArt objektum van az első alakzatként azon a dián. Kiírja az összes elérhető szövegkeretet a konzolra.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt) slide.Shapes[0];
foreach (var node in smartArt.AllNodes)
{
    foreach (var nodeShape in node.Shapes)
    {
        if (nodeShape.TextFrame != null)
        {
            Console.WriteLine(nodeShape.TextFrame.Text);
        }
    }
}
```

## **A SmartArt objektum elrendezéstípusának módosítása**

A SmartArt elrendezés szabályozza, hogy a csomópontok hogyan vannak elrendezve és összekapcsolva. A következő példa egy SmartArt objektumot hoz létre a [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `BasicBlockList` értékével, átváltja a `BasicProcess` értékre, és elmenti a bemutatót. A [IShapeCollection.AddSmartArt](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addsmartart/) hívásban megadott pozíció és méret pontban van mérve. Az elrendezés módosításához állítsa be az [ISmartArt.Layout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/layout/) értékét.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
smartArt.Layout = SmartArtLayoutType.BasicProcess;

presentation.Save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
```

## **Ellenőrizze, hogy egy SmartArt csomópont rejtett-e**

Az [ISmartArtNode.IsHidden](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/ishidden/) jelzi, hogy a csomópont rejtett-e a SmartArt adatmodellben. A rejtett csomópontok létezhetnek a struktúrában, még akkor is, ha a kiválasztott elrendezés nem jeleníti meg őket látható diagramelemként.

A következő példa egy csomópontot ad egy SmartArt objektumhoz, amely a [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` értéket használja, és ellenőrzi a hozzáadott csomópont rejtett állapotát. Üzenetet ír ki, ha a csomópont rejtett, és elmenti a diagramot.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
var node = smartArt.AllNodes.AddNode();
var isHidden = node.IsHidden;

if (isHidden)
{
    Console.WriteLine("The node is hidden in the SmartArt data model.");
}

presentation.Save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
```

## **A szervezeti ábra elrendezésének lekérése vagy beállítása**

Azoknál a SmartArt diagramoknál, amelyek szervezeti ábra elrendezést használnak, az [ISmartArtNode.OrganizationChartLayout](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/organizationchartlayout/) meghatározza, hogy a gyermek csomópontok hogyan helyezkednek el egy szülő csomópont alatt. Például a kiválasztott [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) függvényében beállíthatja, hogy a gyermek csomópontok balról, jobbról vagy mindkét oldalról lógjanak.

A következő példa létrehoz egy szervezeti ábrát, és beállítja az első csomópont elrendezését a [OrganizationChartLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/organizationchartlayouttype/) `LeftHanging` értékre. A nulla-alapú index `0` kiválasztja az első felső szintű csomópontot; annak gyermek csomópontjai a kiválasztott elrendezést használják. Ezután a módosított bemutatót elmenti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
var rootNode = smartArt.Nodes[0];
rootNode.OrganizationChartLayout = OrganizationChartLayoutType.LeftHanging;

presentation.Save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
```

## **Kép szervezeti ábra létrehozása**

A kép szervezeti ábra egy SmartArt elrendezés, amely hierarchiai diagramokhoz készült, és képhelyeket tartalmaz. Használja a [SmartArtLayoutType](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartartlayouttype/) `PictureOrganizationChart` értéket a SmartArt objektum diára való hozzáadásakor. Ez a példa egy diagramot ment képhelyekkel; a helyképek nem kerülnek kitöltésre.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var smartArt = slide.Shapes.AddSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

presentation.Save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
```

## **Régi diagramok csoport alakzatokká konvertálása**

Egy meglévő bemutató modernizálásakor előfordulhat, hogy frissítenie kell egy eredetileg PowerPoint 97–2003-ban létrehozott szervezeti ábrát. Az Aspose.Slides ezeket a régi diagramokat [ILegacyDiagram](https://reference.aspose.com/slides/net/aspose.slides/ilegacydiagram/) objektumokként jeleníti meg. Használja a [LegacyDiagram.ConvertToGroupShape](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/converttogroupshape/) metódust, hogy egy diagramot alakzatcsoporttá konvertáljon, így egyedi vizuális elemeket szerkeszthet. Részletekért tekintse meg a [LegacyDiagram API Reference](https://reference.aspose.com/slides/net/aspose.slides/legacydiagram/) oldalt.

A konvertálás új csoportot ad az alakzatgyűjteményhez anélkül, hogy eltávolítaná az eredeti diagramot. Sikeres konvertálás után távolítsa el az eredetit a [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) segítségével, hogy elkerülje a duplikált tartalmat. A konvertálás előtt gyűjtse össze a régi diagramokat egy tömbbe, hogy az alakzatok hozzáadása és eltávolítása ne zavarja az iterációt.

A következő példa megnyit egy bemutatót, minden diát keres, a diagramokat alakzatcsoportokká konvertálja, és elmenti a frissített bemutatót PPTX formátumban.

```csharp
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("legacy-diagrams.ppt");

foreach (var slide in presentation.Slides)
{
    var legacyDiagrams = slide.Shapes.OfType<ILegacyDiagram>().ToArray();
    foreach (var legacyDiagram in legacyDiagrams)
    {
        var groupShape = legacyDiagram.ConvertToGroupShape();

        if (groupShape != null)
        {
            slide.Shapes.Remove(legacyDiagram);
        }
    }
}

presentation.Save("modernized.pptx", SaveFormat.Pptx);
```

Az elmentett bemutató szerkeszthető alakzatcsoportokat tartalmaz a konvertált régi diagramok helyett, az eredeti diagramok már nincsenek jelen. Nyissa meg a PPTX-et a PowerPointban, hogy az egyes csoportokon belül szerkessze az elemeket, például a szöveget, a kitöltést vagy a pozíciót.

## **GYIK**

**Támogatja a SmartArt a tükrözést vagy megfordítást RTL nyelvek esetén?**

Igen. Az [IsReversed](https://reference.aspose.com/slides/net/aspose.slides.smartart/smartart/isreversed/) tulajdonság megfordítja a diagram irányát balról jobbra és jobbról balra, vagy vissza, ha a kiválasztott SmartArt elrendezés támogatja a megfordítást.

**Hogyan másolhatom a SmartArt-ot ugyanarra a diára vagy egy másik bemutatóba, miközben megőrzöm a formázást?**

A [SmartArt alakzat klónozásával](/slides/hu/net/shape-manipulations/) a [ShapeCollection.AddClone](https://reference.aspose.com/slides/net/aspose.slides/shapecollection/addclone/) vagy a SmartArt-ot tartalmazó diát [klónozva](/slides/hu/net/clone-slides/) megteheti. Mindkét módszer megőrzi a méretet, a pozíciót és a formázást.

**Hogyan renderelhetem a SmartArt-ot raszteres képpé előnézethez vagy webes exportáláshoz?**

[Renderelje a diát](/slides/hu/net/convert-powerpoint-to-png/) vagy a teljes bemutatót PNG vagy JPEG formátumba. A SmartArt a dia részeként kerül renderelésre.

**Hogyan találhatok egy konkrét SmartArt objektumot egy dián, ha több is van?**

Adjon egy egyedi [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/shape/alternativetext/) vagy [Name](https://reference.aspose.com/slides/net/aspose.slides/shape/name/) értéket a SmartArt alakzatra, keresse meg ezt az értéket a [Slide.Shapes](https://reference.aspose.com/slides/net/aspose.slides/baseslide/shapes/) között, majd ellenőrizze, hogy a megtalált alakzat egy [ISmartArt](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartart/).