---
title: Diagramgegevens tabellen aanpassen in presentaties met Python
linktitle: Gegevenstabel
type: docs
url: /nl/python-net/chart-data-table/
keywords:
- diagramgegevens
- gegevenstabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Diagramgegevens tabellettertypen, randen en legenda-sleutels aanpassen in PowerPoint-presentaties met Aspose.Slides voor Python via .NET."
---
## **Overzicht**

Aspose.Slides for Python via .NET stelt u in staat om de gegevens tabel van een diagram weer te geven en de tekstopmaak, randen en legenda‑sleutels aan te passen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst opmaakt, elk type rand bestuurt en legenda‑sleutels weergeeft of verbergt. De voorbeelden slaan de geconfigureerde diagrammen op in PPTX‑bestanden.

## **Lettertype‑eigenschappen instellen**

Om de gegevens tabel van een diagram weer te geven, stelt u [has_data_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_data_table/) in op `True`. Gebruik [chart_data_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/chart_data_table/) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met behulp van de [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) klasse.  
1. Voeg een gegroepeerde kolomdiagram toe aan de eerste dia.  
1. Schakel de gegevens tabel van het diagram in.  
1. Schakel vette tekst in met [font_bold](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/font_bold/) en stel [font_height](https://reference.aspose.com/slides/nl/python-net/aspose.slides/baseportionformat/font_height/) in op `20` voor tekst van 20 punten.  
1. Sla de aangepaste presentatie op.

Het onderstaande voorbeeld vereist `test.pptx` in de werkmap met ten minste één dia. Het voegt een diagram met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat het diagram met de gegevens tabel ingeschakeld en de opgegeven lettertype‑instellingen toegepast.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Randen van de gegevens tabel aanpassen**

Schakel de tabel in met [Chart.has_data_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_data_table/) en krijg er toegang via [Chart.chart_data_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/chart_data_table/). U kunt drie soorten randen onafhankelijk regelen:

- [has_border_horizontal](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datatable/has_border_horizontal/) regelt de horizontale celranden.  
- [has_border_vertical](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datatable/has_border_vertical/) regelt de verticale celranden.  
- [has_border_outline](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datatable/has_border_outline/) regelt de buitenrand van de tabel.

Stel elke eigenschap in op `True` om de randen weer te geven of op `False` om ze te verbergen. Het onderstaande voorbeeld maakt een gegroepeerde kolomdiagram met standaardgegevens, toont horizontale randen en de buitenrand, en verbergt verticale randen. Het vereist geen invoerbestand. De positie en grootte van het diagram worden in punten gespecificeerd.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

De onderstaande vergelijking gebruikt in alle vier gevallen dezelfde diagramgegevens en legenda‑sleutelinstelling. Begonnen met alle randen ingeschakeld, schakelt elke overige variant precies één rand‑eigenschap uit. De variant linksonder komt overeen met de randinstellingen in het voorbeeld.

![Chart data tables with all borders enabled, no horizontal borders, no vertical borders, and no outer border](data-table-borders.png)

## **Legenda‑sleutels weergeven of verbergen**

Legenda‑sleutels zijn kleine gekleurde markeringen naast de serienaam in de gegevens tabel. Ze helpen lezers elke tabelrij te koppelen aan een diagramserie. Stel [show_legend_key](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datatable/show_legend_key/) in op `True` om deze markeringen weer te geven of op `False` om ze te verbergen.

De afzonderlijke legenda van het diagram wordt geregeld door [Chart.has_legend](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_legend/). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legenda verbergt de sleutels in de gegevens tabel niet, en het verbergen van de tabel‑sleutels verbergt de afzonderlijke legenda niet.

Het onderstaande voorbeeld maakt een diagram met standaardgegevens, schakelt de gegevens tabel in en toont legenda‑sleutels erin terwijl de afzonderlijke legenda wordt verborgen. Alle tabelranden zijn expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels van de tabel te verbergen, wijzig `data_table.show_legend_key` naar `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

De onderstaande vergelijking toont dezelfde tabel met legenda‑sleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld en de afzonderlijke diagramlegenda is in beide gevallen verborgen.

![Chart data tables with legend keys shown on the left and hidden on the right](data-table-legend-keys.png)

## **FAQ**

**Kan ik legenda‑sleutels weergeven in de gegevens tabel van een diagram?**  

Ja. Stel [show_legend_key](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datatable/show_legend_key/) in op `True` om legenda‑sleutels weer te geven of op `False` om ze te verbergen.

**Wordt de gegevens tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**  

Ja. Aspose.Slides rendert het diagram en de weergegeven gegevens tabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/nl/python-net/convert-powerpoint-to-html/) of [images](/slides/nl/python-net/convert-powerpoint-to-png/).

**Kan ik werken met gegevens tabellen in diagrammen die uit een sjabloon zijn geladen?**  

Ja. Voor een diagram dat is geladen uit een bestaande presentatie of sjabloon, gebruikt u [has_data_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_data_table/) om te controleren of de gegevens tabel wordt weergegeven of om dit te wijzigen.

**Hoe kan ik diagrammen vinden die een gegevens tabel hebben ingeschakeld?**  

Loop door de vormen op elke dia, identificeer de diagrammen en controleer hun [has_data_table](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_data_table/)‑eigenschap. Een waarde van `True` geeft aan dat de gegevens tabel is ingeschakeld.