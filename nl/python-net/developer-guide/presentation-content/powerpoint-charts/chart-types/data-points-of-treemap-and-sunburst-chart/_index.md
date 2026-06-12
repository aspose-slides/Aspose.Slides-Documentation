---
title: Aangepaste gegevenspunten in Treemap en Sunburst diagrammen in Python
linktitle: Gegevenspunten in Treemap en Sunburst diagrammen
type: docs
url: /nl/python-net/data-points-of-treemap-and-sunburst-chart/
keywords:
- treemap-diagram
- sunburst-diagram
- gegevenspunt
- labelkleur
- takkleur
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Leer hoe u gegevenspunten in treemap‑ en sunburst‑diagrammen kunt beheren met Aspose.Slides voor Python via .NET, compatibel met PowerPoint‑ en OpenDocument‑formaten."
---
## **Inleiding**

Naast andere PowerPoint-diagramtypen zijn er twee hiërarchische—**Treemap** en **Sunburst** (ook wel Sunburst‑grafiek, Sunburst‑diagram, Radiale diagram, Radiale grafiek of Meerlagige taartdiagram genoemd). Deze diagrammen tonen hiërarchische gegevens die zijn georganiseerd als een boom—van bladeren tot de top van een tak. Bladeren worden gedefinieerd door de gegevenspunten van de reeks, en elk daaropvolgend genest groepeerniveau wordt bepaald door de bijbehorende categorie. Aspose.Slides for Python via .NET stelt je in staat om gegevenspunten van Sunburst‑diagrammen en Treemaps in Python te formatteren.

Hier is een Sunburst‑diagram waarbij de gegevens in de kolom Series1 de bladknooppunten definiëren, terwijl de andere kolommen de hiërarchische gegevenspunten definiëren:

![Sunburst chart example](sunburst_example.png)

Laten we beginnen met het toevoegen van een nieuw Sunburst‑diagram aan de presentatie:

```py
with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
```

{{% alert color="primary" title="Zie ook" %}}
- [**Sunburst‑diagrammen maken**](/slides/nl/python-net/create-chart/#create-sunburst-charts)
{{% /alert %}}

Als je diagram‑gegevenspunten moet formatteren, gebruik dan de volgende API’s:

[ChartDataPointLevelsManager](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointlevelsmanager/), [ChartDataPointLevel](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapointlevel/), en de [ChartDataPoint.data_point_levels](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chartdatapoint/data_point_levels/) eigenschap. Ze bieden toegang tot het formatteren van gegevenspunten in Treemap‑ en Sunburst‑diagrammen. [ChartDataPointLevelsManager] wordt gebruikt om meer‑niveau‑categorieën te benaderen; het vertegenwoordigt een container van [ChartDataPointLevel]‑objecten. Het is in essentie een wrapper rond [ChartCategoryLevelsManager] met extra eigenschappen die specifiek zijn voor gegevenspunten. Het type [ChartDataPointLevel] stelt twee eigenschappen bloot—[format] en [label]—die toegang geven tot de bijbehorende instellingen.

## **Weergave van gegevenspuntwaarden**

Deze sectie toont hoe je de waarde van individuele gegevenspunten in Treemap‑ en Sunburst‑diagrammen kunt weergeven. Je ziet hoe je waardelabels voor geselecteerde punten inschakelt.

Geef de waarde van het gegevenspunt "Leaf 4" weer:

```py
data_points = chart.chart_data.series[0].data_points
data_points[3].data_point_levels[0].label.data_label_format.show_value = True
```

![Data point value](data_point_value.png)

## **Labels en kleuren instellen voor gegevenspunten**

Deze sectie laat zien hoe je aangepaste labels en kleuren kunt instellen voor individuele gegevenspunten in Treemap‑ en Sunburst‑diagrammen. Je leert hoe je een specifiek gegevenspunt benadert, een label toewijst en een effen vulling toepast om belangrijke knooppunten te markeren.

Stel het gegevenslabel van "Branch 1" in om de naam van de reeks ("Series1") weer te geven in plaats van de categorienaam, en stel vervolgens de tekstkleur in op geel:

```py
branch1_label = data_points[0].data_point_levels[2].label
branch1_label.data_label_format.show_category_name = False
branch1_label.data_label_format.show_series_name = True

branch1_label.data_label_format.text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
branch1_label.data_label_format.text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.yellow
```

![Data point's label and color](data_point_color.png)

## **Branchkleuren instellen voor gegevenspunten**

Gebruik branchkleuren om te bepalen hoe boven‑ en onderliggende knooppunten visueel gegroepeerd worden in Treemap‑ en Sunburst‑diagrammen. Deze sectie laat zien hoe je een aangepaste branchkleur voor een specifiek gegevenspunt instelt zodat je belangrijke subbomen kunt markeren en de leesbaarheid van het diagram verbetert.

Wijzig de kleur van de "Stem 4"‑branch:

```py
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.SUNBURST, 30, 30, 450, 400)
    data_points = chart.chart_data.series[0].data_points

    stem4_branch = data_points[9].data_point_levels[1]
    
    stem4_branch.format.fill.fill_type = slides.FillType.SOLID
    stem4_branch.format.fill.solid_fill_color.color = draw.Color.red
      
    presentation.save("branch_color.pptx", slides.export.SaveFormat.PPTX)
```

![Branch color](branch_color.png)

## **Veelgestelde vragen**

**Kan ik de volgorde (sortering) van segmenten in Sunburst/Treemap wijzigen?**

Nee. PowerPoint sorteert segmenten automatisch (meestal op aflopende waarden, met de klok mee). Aspose.Slides spiegelt dit gedrag: je kunt de volgorde niet rechtstreeks wijzigen; dit moet je doen door de gegevens vooraf te verwerken.

**Hoe beïnvloedt het presentatiethema de kleuren van segmenten en labels?**

Diagramkleuren erven het [theme/palette](/slides/nl/python-net/presentation-theme/) van de presentatie tenzij je expliciet vullingen/lettertypen instelt. Voor consistente resultaten kun je het beste vaste vullingen en tekstopmaak vastzetten op de benodigde niveaus.

**Zal exporteren naar PDF/PNG aangepaste branchkleuren en labelinstellingen behouden?**

Ja. Bij het exporteren van de presentatie blijven de diagraminstellingen (vullingen, labels) behouden in de uitvoerformaten, omdat Aspose.Slides rendert met de toegepaste diagramopmaak.

**Kan ik de werkelijke coördinaten van een label/element berekenen voor aangepaste overlay‑plaatsing bovenop het diagram?**

Ja. Nadat de diagramlay-out is gevalideerd, zijn `actual_x`/`actual_y` beschikbaar voor elementen (bijvoorbeeld een [DataLabel]), wat helpt bij het nauwkeurig positioneren van overlays.