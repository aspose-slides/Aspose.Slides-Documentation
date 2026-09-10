---
title: Gegevenspunten aanpassen in Treemap‑ en Sunburst‑grafieken in Python
linktitle: Gegevenspunten in Treemap‑ en Sunburst‑grafieken
type: docs
url: /nl/python-java/data-points-of-treemap-and-sunburst-chart/
weight: 40
keywords:
- Treemap‑grafiek
- Sunburst‑grafiek
- hiërarchische grafiek
- gegevenspunt
- gegevenslabel
- takkleur
- PowerPoint
- presentatie
- Python
- Java
- Aspose.Slides
description: "Leer hoe u hiërarchische gegevens kunt maken en niveaus, labels en kleuren kunt aanpassen in Treemap‑ en Sunburst‑grafieken met Aspose.Slides voor Python via Java."
---
## **Overzicht**

Treemap‑ en Sunburst‑grafieken tonen hetzelfde type hiërarchische gegevens, maar ze gebruiken verschillende lay‑outs. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de gebiedesgrootte de bladwaarden weergeeft. Een Sunburst tekent het als concentrische ringen: hoog niveau‑groepen staan dicht bij het midden, en bladcategorieën bevinden zich op de buitenste ring.

In Aspose.Slides for Python via Java is elke numerieke waarde een [ChartDataPoint](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/). De [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getDataPointLevels)‑methode biedt toegang tot het blad en de bovenliggende groepen. Dit artikel legt die mapping uit en laat zien hoe je beide grafiektype‑s maakt en opmaakt met dezelfde voorbeeldgegevens.

![Een Treemap‑grafiek met Consument‑ en Zakelijk‑takken](treemap-hierarchy.png)

![Een Sunburst‑grafiek met dezelfde Consument‑ en Zakelijk‑hiërarchie](sunburst-hierarchy.png)

## **Begrijp Categorieën, Gegevenspunten en Niveaus**

Het onderstaande voorbeeld bevat drie categorieniveaus en één numerieke reeks:

| Tak | Stam | Blad | Omzet |
| --- | --- | --- | ---: |
| Consument | Computers | Laptops | 12 |
| Consument | Computers | Desktops | 8 |
| Consument | Mobiel | Telefoons | 15 |
| Consument | Mobiel | Tablets | 6 |
| Zakelijk | Diensten | Consultancy | 10 |
| Zakelijk | Diensten | Ondersteuning | 7 |
| Zakelijk | Software | Licenties | 11 |
| Zakelijk | Software | Abonnementen | 14 |

Elke rij maakt één bladcategorie en één gegevenspunt. De categoriegroeperingsniveaus beschrijven het pad van dat blad naar zijn ouders. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen die worden geretourneerd door [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getDataPointLevels) lopen van het blad omhoog:

| `getDataPointLevels()` index | Logisch niveau | Treemap‑weergave | Sunburst‑weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Buitening‑segment |
| `1` | Stam | Bovenliggend‑rechthoek of kop | Midden‑ringsegment |
| `2` | Tak | Top‑niveau‑rechthoek of kop | Binnen‑ringsegment |

Deze volgorde is identiek voor beide grafiektype‑s, hoewel hun visuele lay‑outs verschillen. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het te formatteren, gebruik je het overeenkomstige niveau van het eerste gegevenspunt in die groep. Bijvoorbeeld, de `Consumer`‑tak start met het `Laptops`‑punt, terwijl de `Software`‑stam start met het `Licenses`‑punt. Het bewaren van referenties naar die punten is duidelijker en veiliger dan onverklaarde uitdrukkingen zoals `data_points.get_Item(0)` of `data_points.get_Item(6)`.

## **Maak en Pas Beide Grafiektype‑s Aan**

Het volgende volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, ParentLabelLayoutType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    branch_names = [
        "Consumer", "Consumer", "Consumer", "Consumer",
        "Business", "Business", "Business", "Business"
    ]
    stem_names = [
        "Computers", "Computers", "Mobile", "Mobile",
        "Services", "Services", "Software", "Software"
    ]
    leaf_names = [
        "Laptops", "Desktops", "Phones", "Tablets",
        "Consulting", "Support", "Licenses", "Subscriptions"
    ]
    revenues = [12, 8, 15, 6, 10, 7, 11, 14]
    data_point_count = len(leaf_names)

    chart_types = [ChartType.Treemap, ChartType.Sunburst]
    layout_slide = presentation.getLayoutSlides().get_Item(0)

    for chart_index, chart_type in enumerate(chart_types):
        if chart_index == 0:
            slide = presentation.getSlides().get_Item(0)
        else:
            slide = presentation.getSlides().addEmptySlide(layout_slide)

        chart = slide.getShapes().addChart(chart_type, 40, 40, 640, 440)
        chart.setTitle(False)
        chart.setLegend(False)

        chart_data = chart.getChartData()
        chart_data.getCategories().clear()
        chart_data.getSeries().clear()

        workbook = chart_data.getChartDataWorkbook()
        workbook.clear(worksheet_index)

        # Voeg de bladcategorieën toe. Een groepeerelement wordt alleen ingesteld wanneer een nieuwe groep begint;
        # de daaropvolgende categorieën blijven in die groep totdat een ander element wordt ingesteld.
        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            category_cell = workbook.getCell(worksheet_index, row_index, 2, leaf_name)
            category = chart_data.getCategories().add(category_cell)

            stem_name = stem_names[data_index]
            starts_new_stem = data_index == 0
            if data_index > 0:
                previous_stem_name = stem_names[data_index - 1]
                starts_new_stem = stem_name != previous_stem_name
            if starts_new_stem:
                category.getGroupingLevels().setGroupingItem(stem_level_index, stem_name)

            branch_name = branch_names[data_index]
            starts_new_branch = data_index == 0
            if data_index > 0:
                previous_branch_name = branch_names[data_index - 1]
                starts_new_branch = branch_name != previous_branch_name
            if starts_new_branch:
                category.getGroupingLevels().setGroupingItem(branch_level_index, branch_name)

        series_name_cell = workbook.getCell(worksheet_index, 0, 3, "Revenue")
        series = chart_data.getSeries().add(series_name_cell, chart_type)
        series.getLabels().getDefaultDataLabelFormat().setShowCategoryName(True)

        laptops_data_point = None
        tablets_data_point = None
        licenses_data_point = None

        for data_index in range(data_point_count):
            row_index = data_index + 1
            leaf_name = leaf_names[data_index]
            revenue = revenues[data_index]
            value_cell = workbook.getCell(worksheet_index, row_index, 3, jpype.JDouble(revenue))

            if chart_type == ChartType.Treemap:
                data_point = series.getDataPoints().addDataPointForTreemapSeries(value_cell)
            else:
                data_point = series.getDataPoints().addDataPointForSunburstSeries(value_cell)

            if leaf_name == "Laptops":
                laptops_data_point = data_point
            elif leaf_name == "Tablets":
                tablets_data_point = data_point
            elif leaf_name == "Licenses":
                licenses_data_point = data_point

        # Toon de categorie en waarde op het blad Tablets.
        tablets_leaf_level = tablets_data_point.getDataPointLevels().get_Item(leaf_level_index)
        tablets_label_format = tablets_leaf_level.getLabel().getDataLabelFormat()
        tablets_label_format.setShowCategoryName(True)
        tablets_label_format.setShowValue(True)
        tablets_label_format.setSeparator("\n")
        tablets_label_format.setNumberFormat("$0")

        # Formateer de tak Consumer via het eerste blad in die tak.
        consumer_branch_level = laptops_data_point.getDataPointLevels().get_Item(branch_level_index)
        consumer_branch_fill = consumer_branch_level.getFormat().getFill()
        consumer_branch_color = Color(31, 78, 121)
        consumer_branch_fill.setFillType(FillType.Solid)
        consumer_branch_fill.getSolidFillColor().setColor(consumer_branch_color)

        consumer_label_format = consumer_branch_level.getLabel().getDataLabelFormat()
        consumer_label_format.setShowCategoryName(True)
        consumer_label_format.setShowSeriesName(False)
        consumer_label_text_fill = consumer_label_format.getTextFormat().getPortionFormat().getFillFormat()
        consumer_label_text_fill.setFillType(FillType.Solid)
        consumer_label_text_fill.getSolidFillColor().setColor(Color.WHITE)

        # Formateer de stam Software via het eerste blad in die stam.
        software_stem_level = licenses_data_point.getDataPointLevels().get_Item(stem_level_index)
        software_stem_fill = software_stem_level.getFormat().getFill()
        software_stem_color = Color(112, 173, 71)
        software_stem_fill.setFillType(FillType.Solid)
        software_stem_fill.getSolidFillColor().setColor(software_stem_color)

        # ParentLabelLayout beïnvloedt de bovenliggende labels van Treemap; Sunburst gebruikt ringsegmenten.
        if chart_type == ChartType.Treemap:
            series.setParentLabelLayout(ParentLabelLayoutType.Overlapping)

    presentation.save("hierarchical-charts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De categoriecellen en waardecellen gebruiken dezelfde werkblad‑rij, zodat hun verzamelposities uitgelijnd blijven. Wanneer je met een bestaande grafiek werkt in plaats van er één te maken, inspecteer dan eerst de categorierijen en bewaar benoemde verwijzingen naar de gegevenspunten en niveaus die je wilt formatteren.

## **Gedrag en Praktische Overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om waarde te communiceren en geneste rechthoeken om hiërarchie te tonen. De [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setParentLabelLayout)‑methode bepaalt hoe bovenliggende labels verschijnen in dit grafiektype.
- Een Sunburst gebruikt hoek om waarde te communiceren en ringdiepte om hiërarchie te tonen. [ChartSeries.setParentLabelLayout](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartseries/#setParentLabelLayout) regelt **niet** de ringlabels.
- Beide grafiektype‑s gebruiken dezelfde categoriegroeperingsniveaus en dezelfde blad‑naar‑ouder‑volgorde die wordt geretourneerd door [ChartDataPoint.getDataPointLevels](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapoint/#getDataPointLevels), zodat de code voor gegevensopbouw en niveau‑formattering gedeeld kan worden.
- Bovenliggende waarden worden berekend uit hun afstammende bladeren. Voeg geen aparte numerieke punten toe voor takken of stammen.

### **Sorteren en Segmentvolgorde**

De lay‑out‑engine van de grafiek bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Orden gerelateerde categorie‑rijen bij elkaar voordat je ze toevoegt, maar vertrouw niet op een specifieke rechthoek‑positie of start‑hoek. Als de volgorde betekenis heeft, neem die dan op in de labels of gebruik een grafiektype met een expliciete categoriënas.

### **Thema en Vaste Kleuren**

Niet‑geformatteerde grafiekniveaus erven kleuren van het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare uitvoer. Als de grafiek thema‑wijzigingen moet volgen, gebruik dan schema‑kleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer bovendien het label‑contrast nadat je een tak‑ of stam‑vulling hebt aangepast.

### **Labels en Beschikbare Ruimte**

PowerPoint kan labels verbergen of afkappen wanneer een segment te klein is. Het vergroten van de grafiek, verkorten van categorienamen of minder labelvelden tonen, levert meestal een helderder resultaat op. Een label kan de categorienaam, serienaam en waarde combineren via [DataLabelFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/), maar het inschakelen van elk veld maakt hiërarchische grafieken vaak moeilijk leesbaar.

### **Exporteren en Renderen**

Opslaan als PPTX behoudt de bewerkbaarheid van de grafiek. Wanneer Aspose.Slides de presentatie rendert naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen meegeleverd. Lettertype‑substitutie en kleine verschillen in beschikbare lay‑out‑ruimte kunnen de regel‑afbreking of label‑zichtbaarheid veranderen, dus installeer de benodigde lettertypen en verifieer belangrijke export‑doelen.

## **Veelgestelde Vragen**

**Waarom beïnvloedt het wijzigen van een bovenliggend niveau meerdere bladeren?**

Een tak of stam is een gedeeld visueel segment. De bijbehorende [ChartDataPointLevel](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chartdatapointlevel/) is toegankelijk via een afstammend blad, maar de opmaak behoort tot het gedeelde bovenliggende segment, niet alleen tot dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de vereiste velden in op het [DataLabelFormat](https://reference.aspose.com/slides/nl/python-java/aspose.slides/datalabelformat/)-object van het label. Controleer daarna of het segment voldoende ruimte heeft. De lay‑out van Treemap‑bovenliggende labels, grafiekafmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden bepalen allemaal of een label kan worden weergegeven.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de bron‑rij‑volgorde regelen en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De lay‑out‑engine berekent ze op basis van de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren na een themawijziging van de presentatie?**

Thema‑gebaseerde vullingen volgen het presentatiethema. Gebruik expliciete RGB‑kleuren voor niveaus die vast moeten blijven, of behoud schema‑kleuren wanneer aanpassen aan een nieuw thema de voorkeur heeft.

**Wordt aangepaste opmaak behouden bij export naar PDF en afbeeldingen?**

Ja, ondersteunde grafiekvullingen en labelinstellingen worden meegenomen tijdens het renderen. Zorg voor de benodigde lettertypen en test de uiteindelijke exportgrootte, want label‑passing is lay‑out‑afhankelijk.

## **Zie Ook**

- [Maak Treemap‑grafieken](/slides/nl/python-java/create-chart/#create-tree-map-charts)
- [Maak Sunburst‑grafieken](/slides/nl/python-java/create-chart/#create-sunburst-charts)
- [Exporteer presentatiegrafieken](/slides/nl/python-java/export-chart/)
- [Beheer presentatiethema’s](/slides/nl/python-java/presentation-theme/)