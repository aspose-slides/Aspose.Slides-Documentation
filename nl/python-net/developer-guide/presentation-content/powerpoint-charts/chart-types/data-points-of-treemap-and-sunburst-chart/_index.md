---
title: Aangepaste gegevenspunten in Treemap- en Sunburst-grafieken in Python
linktitle: Gegevenspunten in Treemap- en Sunburst-grafieken
type: docs
url: /nl/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-grafiek
- sunburst-grafiek
- hiërarchische grafiek
- gegevenspunt
- gegevenslabel
- takkleur
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe je hiërarchische gegevens maakt en niveaus, labels en kleuren aanpast in Treemap- en Sunburst-grafieken met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Treemap‑ en Sunburst‑grafieken geven hetzelfde type hiërarchische gegevens weer, maar ze gebruiken verschillende lay‑outs. Een Treemap tekent de hiërarchie als geneste rechthoeken waarvan de oppervlakten de bladwaarden vertegenwoordigen. Een Sunburst tekent die hiërarchie als concentrische ringen: bovenliggende groepen staan dicht bij het midden en bladcategorieën bevinden zich op de buitenste ring.

In Aspose.Slides for Python via .NET is elke numerieke waarde een [ChartDataPoint](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/). De [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/)‑collectie biedt toegang tot het blad en de bijbehorende bovenliggende groepen. Dit artikel legt die koppeling uit en laat zien hoe beide grafiektype­s gemaakt en opgemaakt kunnen worden met dezelfde voorbeeldgegevens.

![A Treemap chart with Consumer and Business branches](treemap-hierarchy.png)

![A Sunburst chart with the same Consumer and Business hierarchy](sunburst-hierarchy.png)

## **Begrijp categorieën, gegevenspunten en niveaus**

Het onderstaande voorbeeld bevat drie categoriëniveaus en één numerieke reeks:

| Tak | Stengel | Blad | Omzet |
| --- | --- | --- | ---: |
| Consumer | Computers | Laptops | 12 |
| Consumer | Computers | Desktops | 8 |
| Consumer | Mobile | Phones | 15 |
| Consumer | Mobile | Tablets | 6 |
| Business | Services | Consulting | 10 |
| Business | Services | Support | 7 |
| Business | Software | Licenses | 11 |
| Business | Software | Subscriptions | 14 |

Elke rij creëert één bladcategorie en één gegevenspunt. De categoriën‑groeperingsniveaus beschrijven het pad van dat blad naar zijn bovenliggende elementen. Voor de eerste rij is het pad `Consumer > Computers > Laptops`.

De indexen in [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) lopen van het blad omhoog:

| `data_point_levels`‑index | Logisch niveau | Treemap‑weergave | Sunburst‑weergave |
| ---: | --- | --- | --- |
| `0` | Blad | Waarde‑rechthoek | Segment van buitenste ring |
| `1` | Stengel | Bovenliggende rechthoek of koptekst | Segment van middelste ring |
| `2` | Tak | Bovenliggende rechthoek of koptekst | Segment van binnenste ring |

Deze volgorde is voor beide grafiektype­s gelijk, hoewel hun visuele lay‑out verschilt. Een bovenliggend segment wordt gedeeld door meerdere bladeren. Om het op te maken, gebruik je het overeenkomstige niveau van het eerste gegevenspunt in die groep. Bijvoorbeeld, de `Consumer`‑tak start met het `Laptops`‑punt, terwijl de `Software`‑stengel start met het `Licenses`‑punt. Verwijzingen naar die punten bewaren is duidelijker en veiliger dan onverklaarde uitdrukkingen zoals `data_points[0]` of `data_points[6]`.

## **Maak en pas beide grafiektype­s aan**

Het onderstaande volledige voorbeeld maakt een Treemap op de eerste dia en een Sunburst op de tweede dia. Het bouwt de hiërarchie, toont de waarde voor `Tablets`, past vaste kleuren toe op geselecteerde niveaus, formatteert een tak‑label en slaat de presentatie op.

```py
import aspose.pydrawing as drawing
import aspose.slides as slides
import aspose.slides.charts as charts


def set_solid_fill(fill_format, color):
    fill_format.fill_type = slides.FillType.SOLID
    fill_format.solid_fill_color.color = color


def add_hierarchy_chart(slide, chart_type):
    worksheet_index = 0
    leaf_level_index = 0
    stem_level_index = 1
    branch_level_index = 2

    chart = slide.shapes.add_chart(chart_type, 40, 40, 640, 440)
    chart.has_title = False
    chart.has_legend = False
    chart.chart_data.categories.clear()
    chart.chart_data.series.clear()

    workbook = chart.chart_data.chart_data_workbook
    workbook.clear(worksheet_index)

    def add_category(row_index, leaf_name):
        category_cell = workbook.get_cell(worksheet_index, row_index, 2, leaf_name)
        return chart.chart_data.categories.add(category_cell)

    # Voeg de bladcategorieën toe. Een groepeerelement wordt alleen ingesteld wanneer een nieuwe groep begint;
    # de volgende categorieën blijven in die groep tot een ander element wordt ingesteld.
    laptops_category = add_category(1, "Laptops")
    laptops_category.grouping_levels.set_grouping_item(stem_level_index, "Computers")
    laptops_category.grouping_levels.set_grouping_item(branch_level_index, "Consumer")

    add_category(2, "Desktops")

    phones_category = add_category(3, "Phones")
    phones_category.grouping_levels.set_grouping_item(stem_level_index, "Mobile")

    add_category(4, "Tablets")

    consulting_category = add_category(5, "Consulting")
    consulting_category.grouping_levels.set_grouping_item(stem_level_index, "Services")
    consulting_category.grouping_levels.set_grouping_item(branch_level_index, "Business")

    add_category(6, "Support")

    licenses_category = add_category(7, "Licenses")
    licenses_category.grouping_levels.set_grouping_item(stem_level_index, "Software")

    add_category(8, "Subscriptions")

    series_name_cell = workbook.get_cell(worksheet_index, 0, 3, "Revenue")
    series = chart.chart_data.series.add(series_name_cell, chart_type)
    series.labels.default_data_label_format.show_category_name = True

    def add_data_point(row_index, value):
        value_cell = workbook.get_cell(worksheet_index, row_index, 3, value)

        if chart_type == charts.ChartType.TREEMAP:
            return series.data_points.add_data_point_for_treemap_series(value_cell)

        return series.data_points.add_data_point_for_sunburst_series(value_cell)

    laptops_data_point = add_data_point(1, 12)
    add_data_point(2, 8)
    add_data_point(3, 15)
    tablets_data_point = add_data_point(4, 6)
    add_data_point(5, 10)
    add_data_point(6, 7)
    licenses_data_point = add_data_point(7, 11)
    add_data_point(8, 14)

    # Toon de categorie en de waarde op het blad Tablets.
    tablets_label_format = tablets_data_point.data_point_levels[leaf_level_index].label.data_label_format
    tablets_label_format.show_category_name = True
    tablets_label_format.show_value = True
    tablets_label_format.separator = "\n"
    tablets_label_format.number_format = "$0"

    # Formatteer de Consumer‑tak via het eerste blad in die tak.
    consumer_branch_level = laptops_data_point.data_point_levels[branch_level_index]
    consumer_branch_fill = consumer_branch_level.format.fill
    consumer_branch_color = drawing.Color.from_argb(31, 78, 121)
    set_solid_fill(consumer_branch_fill, consumer_branch_color)

    consumer_label_format = consumer_branch_level.label.data_label_format
    consumer_label_format.show_category_name = True
    consumer_label_format.show_series_name = False
    consumer_label_text_fill = consumer_label_format.text_format.portion_format.fill_format
    set_solid_fill(consumer_label_text_fill, drawing.Color.white)

    # Formatteer de Software‑stengel via het eerste blad in die stengel.
    software_stem_level = licenses_data_point.data_point_levels[stem_level_index]
    software_stem_fill = software_stem_level.format.fill
    software_stem_color = drawing.Color.from_argb(112, 173, 71)
    set_solid_fill(software_stem_fill, software_stem_color)

    # parent_label_layout beïnvloedt de bovenliggende labels van Treemap; Sunburst gebruikt ringsegmenten.
    if chart_type == charts.ChartType.TREEMAP:
        series.parent_label_layout = charts.ParentLabelLayoutType.OVERLAPPING


with slides.Presentation() as presentation:
    treemap_slide = presentation.slides[0]
    add_hierarchy_chart(treemap_slide, charts.ChartType.TREEMAP)

    layout_slide = presentation.layout_slides[0]
    sunburst_slide = presentation.slides.add_empty_slide(layout_slide)
    add_hierarchy_chart(sunburst_slide, charts.ChartType.SUNBURST)

    presentation.save("hierarchical-charts.pptx", slides.export.SaveFormat.PPTX)
```

De categorie‑cellen en waarde‑cellen gebruiken dezelfde werkblad‑rij, zodat hun collectie‑posities op één lijn blijven. Als je met een bestaande grafiek werkt in plaats van er een te maken, inspecteer dan eerst de categorie‑rijen en bewaar benoemde verwijzingen naar de gegevenspunten en niveaus die je wilt opmaken.

## **Gedrag en praktische overwegingen**

### **Verschillen tussen Treemap en Sunburst**

- Een Treemap gebruikt oppervlakte om waarde te communiceren en geneste rechthoeken om hiërarchie te communiceren. De [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/parent_label_layout/)‑eigenschap bepaalt hoe bovenliggende labels verschijnen in dit grafiektype.
- Een Sunburst gebruikt hoek om waarde te communiceren en ringdiepte om hiërarchie te communiceren. [ChartSeries.parent_label_layout](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartseries/parent_label_layout/) regelt de ring‑labels niet.
- Beide grafiektype­s gebruiken dezelfde categoriën‑groeperingsniveaus en dezelfde blad‑naar‑bovenliggend‑volgorde in `data_point_levels`, zodat de data‑opbouw‑ en niveau‑opmaakcode gedeeld kan worden.
- Bovenliggende waarden worden berekend uit hun onderliggende bladeren. Voeg geen afzonderlijke numerieke punten toe voor takken of stengels.

### **Sortering en segmentvolgorde**

De grafiek‑lay‑out‑engine bepaalt de uiteindelijke plaatsing van rechthoeken en ringsegmenten. Groepeer gerelateerde categoriënrijen vóór het toevoegen, maar vertrouw niet op een specifieke rechthoek‑positie of starthoek. Als de volgorde betekenis heeft, neem die dan op in de labels of gebruik een grafiektype met een expliciete categoriënas.

### **Thema en vaste kleuren**

Niet‑opgemaakte grafiekniveaus erven kleuren van het presentatiethema. Het voorbeeld gebruikt expliciete RGB‑vullingen voor voorspelbare output. Als de grafiek thema‑wijzigingen moet volgen, gebruik dan scheme‑kleuren in plaats van vaste RGB‑waarden en vermijd het overschrijven van elk niveau. Controleer ook het label‑contrast na het wijzigen van een tak‑ of stengel‑vulling.

### **Labels en beschikbare ruimte**

PowerPoint kan labels verbergen of afkappen wanneer een segment te klein is. Het vergroten van de grafiek, verkorten van categorienamen of minder labelvelden tonen, levert meestal een duidelijker resultaat op. Een label kan de categorienaam, reeksennaam en waarde combineren via [DataLabelFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/), maar het inschakelen van elk veld maakt hiërarchische grafieken vaak moeilijk leesbaar.

### **Export en rendering**

Opslaan als PPTX behoudt de bewerkbaarheid van de grafiek. Wanneer Aspose.Slides de presentatie rendert naar PDF of een afbeelding, worden de ondersteunde vullingen en labelinstellingen gerenderd met de grafiek. Lettertype‑substitutie en kleine verschillen in beschikbare lay‑out‑ruimte kunnen de regel‑afbraak of zichtbaarheid van labels beïnvloeden, dus installeer de vereiste lettertypen en controleer belangrijke exportdoelen.

## **FAQ**

**Waarom beïnvloedt het wijzigen van een bovenliggend niveau meerdere bladeren?**

Een tak of stengel is een gedeeld visueel segment. Het [ChartDataPointLevel](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointlevel/) kan bereikt worden via een onderliggend blad, maar de opmaak behoort tot het gedeelde bovenliggende segment, niet alleen tot dat blad.

**Waarom ontbreekt een datalabel?**

Schakel eerst de vereiste velden in op het label‑object [DataLabelFormat](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datalabelformat/). Controleer daarna of het segment voldoende ruimte heeft. De lay‑out van Treemap‑ouder‑labels, grafiekafmetingen, label‑lengte, lettergrootte en het aantal ingeschakelde velden bepalen allemaal of een label getoond kan worden.

**Kan ik de exacte volgorde of coördinaten van segmenten instellen?**

Je kunt de bron‑rij‑volgorde bepalen en elke groep aaneengesloten houden, maar je kunt geen exacte Treemap‑rechthoeken of Sunburst‑hoeken toewijzen. De grafiek‑lay‑out‑engine berekent deze uit de hiërarchie, waarden en beschikbare ruimte.

**Waarom veranderen kleuren na een thema‑wijziging van de presentatie?**

Thema‑gebaseerde vullingen zijn bedoeld om het presentatiethema te volgen. Gebruik expliciete RGB‑kleuren voor de niveaus die vast moeten blijven, of behoud scheme‑kleuren wanneer aanpassing aan een nieuw thema gewenst is.

**Wordt aangepaste opmaak behouden bij PDF‑ en afbeeldingsexport?**

Ja, ondersteunde grafiekvullingen en labelinstellingen worden meegenomen tijdens het renderen. Zorg voor de benodigde lettertypen en test de uiteindelijke exportgrootte, want label‑passing is lay‑out‑afhankelijk.

## **Zie ook**

- [Create Treemap charts](/slides/nl/python-net/create-chart/#create-tree-map-charts)
- [Create Sunburst charts](/slides/nl/python-net/create-chart/#create-sunburst-charts)
- [Export presentation charts](/slides/nl/python-net/export-chart/)
- [Manage presentation themes](/slides/nl/python-net/presentation-theme/)