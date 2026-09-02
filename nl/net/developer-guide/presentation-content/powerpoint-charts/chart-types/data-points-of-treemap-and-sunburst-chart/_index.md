---
title: Pas gegevenspunten aan in Treemap- en Sunburst-diagrammen in .NET
linktitle: Gegevenspunten in Treemap- en Sunburst-diagrammen
type: docs
url: /nl/net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- hiërarchisch diagram
- gegevenspunt
- databelabel
- takkleur
- PowerPoint
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Leer hoe u hiërarchische gegevens kunt maken en niveaus, labels en kleuren kunt aanpassen in Treemap- en Sunburst-diagrammen met Aspose.Slides voor .NET."
---
## **Overzicht**

Treemap- en Sunburst-diagrammen tonen dezelfde soort hiërarchische gegevens, maar ze gebruiken verschillende indelingen. Een Treemap tekent de hiërarchie als geneste rechthoeken waarbij de oppervlakte de bladwaarden weergeeft. Een Sunburst tekent dit als concentrische ringen: top‑niveau groepen staan dicht bij het midden en bladcategorieën bevinden zich op de buitenste ring.

In Aspose.Slides for .NET is elke numerieke waarde een [IChartDataPoint](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/). De collectie [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) biedt toegang tot het blad en de bijbehorende bovenliggende groepen. Dit artikel legt die koppeling uit en toont hoe beide diagramtypen te maken en op te maken met dezelfde voorbeeldgegevens.

![Een Treemap-diagram met Consumer en Business takken](treemap-hierarchy.png)

![Een Sunburst-diagram met dezelfde Consumer en Business hiërarchie](sunburst-hierarchy.png)

## **Begrijpen van categorieën, datapunten en niveaus**

De gebruikte voorbeelddata hieronder heeft drie categoriëniveaus en één numerieke reeks:

| Tak | Stam | Blad | Omzet |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Elke rij maakt één bladcategorie en één datapunt aan. De categoriëniveau‑groeperingen beschrijven het pad van dat blad naar de bovenliggende groepen. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen in [IChartDataPoint.DataPointLevels](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapoint/datapointlevels/) lopen vanaf het blad naar boven:

| `DataPointLevels` index | Logisch niveau | Treemap‑weergave | Sunburst‑weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Buitening‑segment |
| `1` | Stam | Bovenliggend rechthoek of kop | Midden‑segment |
| `2` | Tak | Top‑niveau rechthoek of kop | Binnen‑segment |

Deze volgorde is hetzelfde voor beide diagramtypen, hoewel hun visuele indelingen verschillen. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het corresponderende niveau van het eerste datapunt in die groep. Bijvoorbeeld, de `Consumer`‑tak begint met het `Laptops`‑punt, terwijl de `Software`‑stam begint met het `Licenses`‑punt. Referenties naar die punten behouden is duidelijker en veiliger dan onverklaarde uitdrukkingen te gebruiken zoals `dataPoints[0]` of `dataPoints[6]`.

## **Maak en pas beide diagramtypen aan**

Het volgende volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie op, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

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

    // Voeg de bladcategorieën toe. Een groepeerelement wordt alleen ingesteld wanneer een nieuwe groep begint;
    // de volgende categorieën blijven in die groep totdat een ander element wordt ingesteld.
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

    // Toon de categorie en de waarde op het blad Tablets.
    var tabletsLabelFormat = tabletsDataPoint.DataPointLevels[leafLevelIndex]
        .Label.DataLabelFormat;
    tabletsLabelFormat.ShowCategoryName = true;
    tabletsLabelFormat.ShowValue = true;
    tabletsLabelFormat.Separator = "\n";
    tabletsLabelFormat.NumberFormat = "$0";

    // Formatteer de Consumer‑tak via het eerste blad in die tak.
    var consumerBranchLevel = laptopsDataPoint.DataPointLevels[branchLevelIndex];
    var consumerBranchFill = consumerBranchLevel.Format.Fill;
    var consumerBranchColor = Color.FromArgb(31, 78, 121);
    SetSolidFill(consumerBranchFill, consumerBranchColor);

    var consumerLabelFormat = consumerBranchLevel.Label.DataLabelFormat;
    consumerLabelFormat.ShowCategoryName = true;
    consumerLabelFormat.ShowSeriesName = false;
    var consumerLabelTextFill = consumerLabelFormat.TextFormat.PortionFormat.FillFormat;
    SetSolidFill(consumerLabelTextFill, Color.White);

    // Formatteer de Software‑stam via het eerste blad in die stam.
    var softwareStemLevel = licensesDataPoint.DataPointLevels[stemLevelIndex];
    var softwareStemFill = softwareStemLevel.Format.Fill;
    var softwareStemColor = Color.FromArgb(112, 173, 71);
    SetSolidFill(softwareStemFill, softwareStemColor);

    // ParentLabelLayout beïnvloedt Treemap‑ouderlabels; Sunburst gebruikt ringsegmenten.
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

De categorie‑cellen en waardecellen gebruiken dezelfde werkblad‑rij, zodat hun collectie‑posities op één lijn blijven. Werk je met een bestaand diagram in plaats van er een nieuw te maken, controleer dan eerst de categorierijen en bewaar benoemde referenties naar de datapunten en niveaus die je wilt opmaken.

## **Gedrag en praktische overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om de waarde weer te geven en geneste rechthoeken om de hiërarchie weer te geven. De eigenschap [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/parentlabellayout/) bepaalt hoe bovenliggende labels verschijnen in dit diagramtype.
- Een Sunburst gebruikt hoek om de waarde weer te geven en ringdiepte om de hiërarchie weer te geven. [IChartSeries.ParentLabelLayout](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartseries/parentlabellayout/) beheerst de ringlabels niet.
- Beide diagramtypen gebruiken dezelfde categoriëniveau‑groeperingen en dezelfde blad‑naar‑ouder‑volgorde in `DataPointLevels`, zodat de data‑opbouw‑ en niveau‑opmaakcode gedeeld kan worden.
- Bovenliggende waarden worden berekend vanuit hun afstammende bladeren. Voeg geen afzonderlijke numerieke punten toe voor takken of stammen.

### **Sortering en segmentvolgorde**

De lay‑outengine van het diagram bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Rangschik gerelateerde categorierijen bij elkaar voordat je ze toevoegt, maar vertrouw niet op een specifieke rechthoekpositie of starthoek. Als de volgorde betekenis heeft, voeg die dan toe aan de labels of gebruik een diagramtype met een expliciete categorie‑as.

### **Thema en vaste kleuren**

Niet‑opgemaakte diagramniveaus erven kleuren van het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare output. Als het diagram thema‑wijzigingen moet volgen, gebruik dan schema‑kleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het labelcontrast na het wijzigen van een tak‑ of stam‑vulling.

### **Labels en beschikbare ruimte**

PowerPoint kan labels verbergen of afkappen wanneer een segment te klein is. Het vergroten van de diagramgrootte, het inkorten van categorienamen of het tonen van minder labelvelden levert meestal een duidelijker resultaat op. Een label kan de categorienaam, serienaam en waarde combineren via [IDataLabelFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/), maar het inschakelen van elk veld maakt hiërarchische diagrammen vaak moeilijk leesbaar.

### **Export en weergave**

Opslaan als PPTX houdt het diagram bewerkbaar. Wanneer Aspose.Slides de presentatie rendert naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen met het diagram weergegeven. Lettertype‑substitutie en kleine verschillen in beschikbare lay‑outruimte kunnen de tekstomslag of labelzichtbaarheid beïnvloeden, dus installeer de vereiste lettertypen en controleer belangrijke exportdoelen.

## **FAQ**

**Waarom beïnvloedt het wijzigen van een bovenliggend niveau meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. Het [IChartDataPointLevel](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/ichartdatapointlevel/) kan worden bereikt via een afstammend blad, maar de opmaak behoort toe aan het gedeelde bovenliggende segment en niet uitsluitend aan dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de vereiste velden in op het label‑object [IDataLabelFormat](https://reference.aspose.com/slides/nl/net/aspose.slides.charts/idatalabelformat/). Controleer vervolgens of het segment voldoende ruimte heeft. De Treemap‑bovenlabel‑lay‑out, diagramafmetingen, label­lengte, lettergrootte en het aantal ingeschakelde velden bepalen allemaal of een label kan worden weergegeven.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de volgorde van de bron‑rijen controleren en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De diagram‑lay‑outengine berekent ze op basis van de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren nadat het presentatiethema is aangepast?**

Op thema gebaseerd vullingen zijn bedoeld om de presentatie‑palet te volgen. Pas expliciete RGB‑kleuren toe op de niveaus die vast moeten blijven, of behoud schema‑kleuren wanneer het aanpassen aan een nieuw thema de voorkeur heeft.

**Wordt aangepaste opmaak behouden bij PDF‑ en afbeeldingsexport?**

Ja, ondersteunde diagramvullingen en labelinstellingen worden meegenomen bij het renderen. Zorg voor de vereiste lettertypen en test de uiteindelijke exportgrootte voor consistente resultaten op verschillende systemen, omdat labelpassing afhankelijk is van de lay‑out.

## **Zie ook**

- [Treemap‑diagrammen maken](/slides/nl/net/create-chart/#create-tree-map-charts)
- [Sunburst‑diagrammen maken](/slides/nl/net/create-chart/#create-sunburst-charts)
- [Presentatiediagrammen exporteren](/slides/nl/net/export-chart/)
- [Presentatiethema’s beheren](/slides/nl/net/presentation-theme/)