---
title: .NET‑ben Treemap és Sunburst diagramok adatpontjainak testreszabása
linktitle: Adatpontok Treemap és Sunburst diagramokban
type: docs
url: /hu/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap diagram
- sunburst diagram
- hierarchikus diagram
- adatpont
- adatcímke
- ág színe
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre hierarchikus adatokat, és testreszabhatja a szinteket, címkéket és színeket a Treemap és Sunburst diagramokban az Aspose.Slides for .NET segítségével."
---
## **Áttekintés**

A Treemap és a Sunburst diagramok ugyanazt a hierarchikus adatfajtát jelenítik meg, de különböző elrendezéseket használnak. A Treemap a hierarchiát egymásba ágyazott téglalapokként ábrázolja, ahol a terület a levélértékeket jelenti. A Sunburst körkörös gyűrűket használ: a felső szintű csoportok a középpont közelében vannak, a levélkategóriák pedig a külső gyűrűn.

Az Aspose.Slides for .NET‑ben minden numerikus érték egy [IChartDataPoint](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/). Az [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) gyűjteménye hozzáférést biztosít a levélhez és a szülőcsoportokhoz. Ez a cikk elmagyarázza ezt a leképezést, és megmutatja, hogyan hozhatók létre és formázhatók mindkét diagramtípus ugyanabból a mintaadatból.

![Egy Treemap diagram a Consumer és Business ágazatokkal](treemap-hierarchy.png)

![Egy Sunburst diagram ugyanazzal a Consumer és Business hierarchiával](sunburst-hierarchy.png)

## **Kategóriák, adatpontok és szintek megértése**

Az alább bemutatott minta három kategóriaszintet és egy numerikus sorozatot tartalmaz:

| Ágazat | Ág | Levél | Bevétel |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Minden sor egy levélkategóriát és egy adatpontot hoz létre. A kategória‑csoportosítási szintek a levél és szülői között leírt utat jelölik. Az első sor esetén az út `Consumer > Computers > Laptops`.

Az [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) indexei a levél felől felfelé haladnak:

| `DataPointLevels` index | Logikai szint | Treemap ábrázolás | Sunburst ábrázolás |
| ---: | --- | --- | --- |
| `0` | Levél | Érték‑téglalap | Külső‑gyűrű szegmens |
| `1` | Ág | Szülő‑téglalap vagy fejléc | Középső‑gyűrű szegmens |
| `2` | Ágazat | Felső‑szintű téglalap vagy fejléc | Belső‑gyűrű szegmens |

Ez a sorrend mindkét diagramtípusnál ugyanaz, bár a vizuális elrendezés eltér. Egy szülő szegmens több levél által közösen használt. Formázásához használja az adott csoport első adatpontjának megfelelő szintjét. Például a `Consumer` ágazat a `Laptops` ponttal kezdődik, míg a `Software` ág a `Licenses` ponttal. Az ilyen hivatkozások tárolása egyértelműbb és biztonságosabb, mint a `dataPoints[0]` vagy `dataPoints[6]` típusú kifejezések használata.

## **Mindkét diagramtípus létrehozása és testreszabása**

Az alábbi teljes példakód létrehoz egy Treemap‑et az első dián, és egy Sunburst‑ot a másodikon. Felépíti a hierarchiát, megjeleníti a `Tablets` értékét, rögzített színeket alkalmaz a kiválasztott szintekre, formáz egy ágazatcímkét, majd elmenti a prezentációt.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var treemapSlide = presentation.Slides[0];
AddHierarchyChart(treemapSlide, ChartType.Treemap);

var layoutSlide = presentation.LayoutSlides[0];
var sunburstSlide = presentation.Slides.AddEmptySlide(layoutSlide);
AddHierarchyChart(sunburstSlide, ChartType.Sunburst);

presentation.Save("hierarchical-charts.pptx", SaveFormat.Pptx);

static void AddHierarchyChart(ISlide slide, ChartType chartType)
{
    const int worksheetIndex = 0;
    const int leafLevelIndex = 0;
    const int stemLevelIndex = 1;
    const int branchLevelIndex = 2;

    var chart = slide.Shapes.AddChart(chartType, 40, 40, 640, 440);
    chart.HasTitle = false;
    chart.HasLegend = false;
    chart.ChartData.Categories.Clear();
    chart.ChartData.Series.Clear();

    var workbook = chart.ChartData.ChartDataWorkbook;
    workbook.Clear(worksheetIndex);

    // Adja hozzá a levélkategóriákat. A csoportosító elemet csak akkor állítják be, amikor egy új csoport kezdődik;
    // a következő kategóriák ebben a csoportban maradnak, amíg egy másik elemet nem állítanak be.
    var laptopsCategory = AddCategory(1, "Laptops");
    laptopsCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Computers");
    laptopsCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Consumer");

    AddCategory(2, "Desktops");

    var phonesCategory = AddCategory(3, "Phones");
    phonesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Mobile");

    AddCategory(4, "Tablets");

    var consultingCategory = AddCategory(5, "Consulting");
    consultingCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Services");
    consultingCategory.GroupingLevels.SetGroupingItem(branchLevelIndex, "Business");

    AddCategory(6, "Support");

    var licensesCategory = AddCategory(7, "Licenses");
    licensesCategory.GroupingLevels.SetGroupingItem(stemLevelIndex, "Software");

    AddCategory(8, "Subscriptions");

    var seriesNameCell = workbook.GetCell(worksheetIndex, 0, 3, "Revenue");
    var series = chart.ChartData.Series.Add(seriesNameCell, chartType);
    series.Labels.DefaultDataLabelFormat.ShowCategoryName = true;

    var laptopsDataPoint = AddDataPoint(1, 12);
    AddDataPoint(2, 8);
    AddDataPoint(3, 15);
    var tabletsDataPoint = AddDataPoint(4, 6);
    AddDataPoint(5, 10);
    AddDataPoint(6, 7);
    var licensesDataPoint = AddDataPoint(7, 11);
    AddDataPoint(8, 14);

    // Mutassa a kategóriát és az értéket a Tablets levélnél.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Formázza a Consumer ágat az ágon belüli első levél alapján.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Formázza a Software ágat az ágon belüli első levél alapján.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // A ParentLabelLayout befolyásolja a Treemap szülőcímkéket; a Sunburst gyűrűszegmenseket használ.
    if (chartType == ChartType.Treemap)
    {
        series.ParentLabelLayout = ParentLabelLayoutType.Overlapping;
    }

    IChartCategory AddCategory(int rowIndex, string leafName)
    {
        var categoryCell = workbook.GetCell(worksheetIndex, rowIndex, 2, leafName);
        return chart.ChartData.Categories.Add(categoryCell);
    }

    IChartDataPoint AddDataPoint(int rowIndex, double value)
    {
        var valueCell = workbook.GetCell(worksheetIndex, rowIndex, 3, value);

        if (chartType == ChartType.Treemap)
        {
            return series.DataPoints.AddDataPointForTreemapSeries(valueCell);
        }

        return series.DataPoints.AddDataPointForSunburstSeries(valueCell);
    }

    static void SetSolidFill(IFillFormat fillFormat, Color color)
    {
        fillFormat.FillType = FillType.Solid;
        fillFormat.SolidFillColor.Color = color;
    }
}
```

A kategória‑cellák és az érték‑cellák ugyanazt a munkalap‑sort használják, így a gyűjtemény‑pozíciók összehangoltak maradnak. Amikor meglévő diagrammal dolgozik az újak létrehozása helyett, először ellenőrizze a kategória‑sorokat, és tárolja a formázandó adatpontokra és szintekre mutató neveket.

## **Viselkedés és gyakorlati szempontok**

### **Treemap és Sunburst különbségek**

- A Treemap a területet használja az érték közlésére, a beágyazott téglalapokat pedig a hierarchia jelzésére. Az [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/parentlabellayout/) tulajdonság szabályozza, hogyan jelennek meg a szülőcímkék ebben a diagramtípusban.
- A Sunburst a szöget használja az érték közlésére, a gyűrűmélységet pedig a hierarchia jelzésére. Az [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartseries/parentlabellayout/) nem befolyásolja a gyűrűcímkéket.
- Mindkét diagramtípus ugyanazokat a kategória‑csoportosítási szinteket és ugyanazt a levél‑szülő sorrendet használja a `DataPointLevels`‑ben, ezért a adat‑építő és szint‑formázó kód közösen használható.
- A szülőértékeket a leszármazott levelekből számítják ki. Ne adjon hozzá külön numerikus pontokat az ágazatokhoz vagy ágakhoz.

### **Rendezés és szegmens sorrend**

A diagram‑elrendező motor határozza meg a téglalapok és gyűrűszegmensek végső elhelyezését. Helyezze egymás mellé a kapcsolódó kategória‑sorokat, mielőtt hozzáadná őket, de ne támaszkodjon egy adott téglalap pozícióra vagy kiindulási szögre. Ha a sorrend jelentést hordoz, tüntesse fel a címkékben, vagy válasszon olyan diagramtípust, amely kifejezett kategória‑tengelyt biztosít.

### **Téma és rögzített színek**

A formázatlan diagram‑szintek a prezentáció témájától öröklik a színeket. A példa kifejezett RGB‑kitöltésekkel rendelkezik a kiszámítható eredmény érdekében. Ha a diagramnak a téma‑változásokra kell reagálnia, használjon séma‑színeket a rögzített RGB‑értékek helyett, és kerülje minden szint felülírását. Emellett ellenőrizze a címke‑kontrasztot egy ágazat‑ vagy ág‑kitöltés módosítása után.

### **Címkék és rendelkezésre álló hely**

A PowerPoint elrejtheti vagy csonkolhatja a címkéket, ha egy szegmens túl kicsi. A diagram méretének növelése, a kategórianév rövidítése vagy a megjelenítendő címkefieldek számának csökkentése általában tisztább eredményt ad. Egy címke kombinálhatja a kategórianév, sorozatnév és érték megjelenítését az [IDataLabelFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabelformat/)‑on keresztül, de minden mező engedélyezése gyakran nehezíti a hierarchikus diagramok olvashatóságát.

### **Exportálás és renderelés**

A PPTX‑be mentés megőrzi a diagram szerkeszthetőségét. Amikor az Aspose.Slides a prezentációt PDF‑re vagy képre rendereli, a támogatott kitöltések és címke‑beállítások a diagrammal együtt jelennek meg. A betűtípus‑helyettesítés és a rendelkezésre álló elrendezési tér apró eltérései megváltoztathatják a sortörést vagy a címke láthatóságát, ezért telepítse a szükséges betűtípusokat, és ellenőrizze a fontos exportcélokat.

## **GYIK**

**Miért befolyásolja egy szülő szint módosítása több levél megjelenését?**

Egy ágazat vagy ág közös vizuális szegmens. Az [IChartDataPointLevel](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/ichartdatapointlevel/) elérhető egy leszármazott levélön keresztül, de a formázás a megosztott szülőszegmenshez tartozik, nem csak az adott levélhez.

**Miért hiányzik egy adatcímke?**

Először engedélyezze a szükséges mezőket a címke [IDataLabelFormat](https://reference.aspose.com/slides/hu/net/aspose.slides.charts/idatalabelformat/) objektumán. Ezután ellenőrizze, hogy a szegmensnek van‑e elegendő helye. A Treemap szülő‑címke‑elrendezés, a diagramméretek, a címkehossz, a betűméret és a bekapcsolt mezők száma mind befolyásolják, hogy a címke megjeleníthető‑e.

**Beállíthatom a szegmensek pontos sorrendjét vagy koordinátáit?**

A forrás‑sor sorrendjét és a csoportok összefüggő elrendezését kontrolálhatja, de nem adhat meg pontos Treemap‑téglalapokat vagy Sunburst‑szögeket. Az elrendező motor a hierarchiából, az értékekből és a rendelkezésre álló térből számítja ki őket.

**Miért változnak a színek a prezentáció téma‑váltása után?**

A téma‑alapú kitöltések a prezentáció palettáját követik. Rögzített színekkel (RGB) jelölje meg azokat a szinteket, amelyeknek állandóaknak kell maradniuk, vagy használjon séma‑színeket, ha a téma‑változtatás előnyben részesül.

**Megmarad-e az egyéni formázás PDF‑ és kép‑exportoknál?**

Igen, a támogatott diagram‑kitöltések és címke‑beállítások szerepelnek a renderelés során. A köztisztán működő eredmény érdekében tegye elérhetővé a szükséges betűtípusokat, és tesztelje a végső exportméretet, mivel a címke‑illesztés az elrendezéstől függ.

## **Lásd még**

- [Create Treemap charts](/slides/hu/net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/hu/net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/hu/net/export-chart/)
- [Manage presentation themes](/slides/hu/net/presentation-theme/)