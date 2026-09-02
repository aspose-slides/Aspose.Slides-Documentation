---
title: Anpassa datapunkter i Treemap- och Sunburst-diagram i .NET
linktitle: Datapunkter i Treemap- och Sunburst-diagram
type: docs
url: /sv/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- hierarkiskt diagram
- datapunkt
- datalabel
- grenfärg
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lär dig hur du skapar hierarkisk data och anpassar nivåer, etiketter och färger i Treemap- och Sunburst-diagram med Aspose.Slides för .NET."
---
## **Översikt**

Treemap- och Sunburst-diagram visar samma typ av hierarkisk data, men de använder olika layouter. En Treemap ritar hierarkin som inbäddade rektanglar vars områden representerar lövvärden. En Sunburst ritar den som koncentriska ringar: toppnivågrupperna är nära centrum och lövkategorierna är på den yttre ringen.

I Aspose.Slides för .NET är varje numeriskt värde ett [IChartDataPoint](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/). Dess [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) samling ger åtkomst till lövet och dess föräldragrupper. Denna artikel förklarar den mappningen och visar hur du skapar och formaterar båda diagramtyperna från samma exempeldata.

![Ett Treemap-diagram med Consumer- och Business-grenar](treemap-hierarchy.png)

![Ett Sunburst-diagram med samma Consumer- och Business-hierarki](sunburst-hierarchy.png)

## **Förstå kategorier, datapunkter och nivåer**

Exemplet som används nedan har tre kategorinivåer och en numerisk serie:

| Gren | Stam | Löv | Intäkt |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Varje rad skapar en lövkategori och en datapunkt. Kategorigruppnivåerna beskriver vägen från det lövet till dess föräldrar. För den första raden är vägen `Consumer > Computers > Laptops`.

Indexen i [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) löper från lövet uppåt:

| `DataPointLevels` index | Logisk nivå | Treemap-representation | Sunburst-representation |
| ---: | --- | --- | --- |
| `0` | Löv | Värderektangel | Yttre ringsegment |
| `1` | Stam | Föräldrarektangel eller rubrik | Melleringssegment |
| `2` | Gren | Toppnivårektangel eller rubrik | Inre ringsegment |

Denna ordning är densamma för båda diagramtyperna även om deras visuella layouter skiljer sig. Ett föräldersegment delas av flera löv. För att formatera det, använd motsvarande nivå från den första datapunkten i den gruppen. Till exempel startar `Consumer`-grenen med `Laptops`-punkten, medan `Software`-stammen startar med `Licenses`-punkten. Att hålla referenser till dessa punkter är tydligare och säkrare än att använda odefinierade uttryck som `dataPoints[0]` eller `dataPoints[6]`.

## **Skapa och anpassa båda diagramtyperna**

Följande kompletta exempel skapar en Treemap på den första bilden och en Sunburst på den andra bilden. Det bygger hierarkin, visar värdet för `Tablets`, applicerar fasta färger på utvalda nivåer, formaterar en grenetikett och sparar presentationen.

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

    // Lägg till lövkategorierna. Ett grupperingselement sätts endast när en ny grupp börjar;
    // följande kategorier förblir i den gruppen tills ett annat element sätts.
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

    // Visa kategori och värde på Tablets-lövet.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Formatera Consumer-grenen via det första lövet i den grenen.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Formatera Software-stammen via det första lövet i den stammen.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout påverkar föräldralabelerna i Treemap; Sunburst använder ringsegment.
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

Kategoricellerna och värdecellerna använder samma arbetsbladsrad, så deras samlingspositioner förblir justerade. När du arbetar med ett befintligt diagram istället för att skapa ett, inspektera först kategoriraderna och lagra namngivna referenser till de datapunkter och nivåer du avser att formatera.

## **Beteende och praktiska överväganden**

### **Treemap- och Sunburst-skillnader**

- En Treemap använder area för att kommunicera värde och inbäddade rektanglar för att kommunicera hierarki. Egenskapen [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/parentlabellayout/) styr hur föräldraetiketter visas i den här diagramtypen.
- En Sunburst använder vinkel för att kommunicera värde och ringdjup för att kommunicera hierarki. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartseries/parentlabellayout/) styr inte dess ringetiketter.
- Båda diagramtyperna använder samma kategorigruppnivåer och samma löv‑till‑förälder‑ordning i `DataPointLevels`, så kod för databyggnad och nivå‑formatering kan delas.
- Föräldravärden beräknas från deras nedärvda löv. Lägg inte till separata numeriska punkter för grenar eller stammar.

### **Sortering och segmentordning**

Diagramlayoutmotorn bestämmer den slutgiltiga placeringen av rektanglar och ringsegment. Ordna relaterade kategorirader tillsammans innan du lägger till dem, men lita inte på en specifik rektangelposition eller startvinkel. Om sekvensen har betydelse, inkludera den i etiketterna eller använd en diagramtyp med en explicit kategori‑axel.

### **Tema och fasta färger**

Oformaterade diagramnivåer ärver färger från presentationens tema. Exemplet använder explicita RGB‑fyllningar för förutsägbar utskrift. Om diagrammet ska följa temaförändringar, använd schemafärger istället för fasta RGB‑värden och undvik att åsidosätta varje nivå. Kontrollera också etikettkontrast efter att du ändrat en gren‑ eller stamfyllning.

### **Etiketter och tillgängligt utrymme**

PowerPoint kan dölja eller trunkera etiketter när ett segment är för litet. Att öka diagrammets storlek, förkorta kategorinamn eller visa färre etikettfält ger oftast ett tydligare resultat. En etikett kan kombinera kategorinamn, serienamn och värde via [IDataLabelFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/idatalabelformat/), men att aktivera alla fält gör ofta hierarkiska diagram svåra att läsa.

### **Export och renderering**

Att spara som PPTX behåller diagrammet redigerbart. När Aspose.Slides renderar presentationen till PDF eller bild, renderas de stödjade fyllningarna och etikettinställningarna med diagrammet. Teckensnittssubstitution och små skillnader i tillgängligt layoututrymme kan förändra radbrytning eller etikettsynlighet, så installera de erforderliga teckensnitten och verifiera viktiga exportmål.

## **FAQ**

**Varför påverkar en ändring av en föräldranivå flera löv?**

En gren eller stam är ett delat visuellt segment. Dess [IChartDataPointLevel](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/ichartdatapointlevel/) kan nås via ett nedärvt löv, men formateringen tillhör det delade föräldrasegmentet snarare än bara det lövet.

**Varför saknas en datalabel?**

Aktivera först de erforderliga fälten på etikettens [IDataLabelFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.charts/idatalabelformat/)-objekt. Kontrollera sedan om segmentet har tillräckligt med utrymme. Treemap‑föräldralabel‑layout, diagramdimensioner, etikettlängd, teckensnittsstorlek och antalet aktiverade fält påverkar alla om en etikett kan visas.

**Kan jag ange exakt ordning eller koordinater för segment?**

Du kan styra källradens ordning och hålla varje grupp sammanhängande, men du kan inte tilldela exakta Treemap‑rektanglar eller Sunburst‑vinklar. Diagramlayoutmotorn beräknar dem från hierarkin, värdena och tillgängligt utrymme.

**Varför förändras färger när presentationstemat ändras?**

Temabaserade fyllningar är avsedda att följa presentationens palett. Applicera explicita RGB‑färger på de nivåer som måste förbli fasta, eller behåll schemafärger när anpassning till ett nytt tema föredras.

**Kommer anpassad formatering att bevaras i PDF‑ och bildexport?**

Ja, stödjade diagramfyllningar och etikettinställningar inkluderas vid rendering. För konsistenta resultat på olika system, gör de nödvändiga teckensnitten tillgängliga och testa den slutliga exportstorleken eftersom etikettanpassning är layout‑beroende.

## **Se även**

- [Skapa Treemap-diagram](/slides/sv/net/create-chart/#create-tree-map-charts)
- [Skapa Sunburst-diagram](/slides/sv/net/create-chart/#create-sunburst-charts)
- [Exportera presentationsdiagram](/slides/sv/net/export-chart/)
- [Hantera presentationsteman](/slides/sv/net/presentation-theme/)