---
title: Grafiekgegevens tabellen aanpassen in Python
linktitle: Gegevenstabel
type: docs
url: /nl/python-net/chart-data-table/
keywords:
- grafiekgegevens
- gegevenstabel
- lettertype‑eigenschappen
- PowerPoint
- OpenDocument
- presentatie
- Python
- Aspose.Slides
description: "Pas grafiekgegevens tabellen aan in Python voor PPT, PPTX en ODP met Aspose.Slides om de efficiëntie en aantrekkelijkheid van presentaties te verbeteren."
---
## **Overzicht**

Dit artikel legt uit hoe u werkt met gegevens tabellen van grafieken in Aspose.Slides. Het toont hoe u een gegevens tabel voor een grafiek weergeeft en de tekstopmaak personaliseert door lettertype‑eigenschappen in te stellen, zoals vet stijl en lettergrootte. Het voorbeeld laat zien hoe u een presentatie laadt, een grafiek toevoegt, de gegevens tabel van de grafiek inschakelt, lettertype‑instellingen toepast en de bijgewerkte presentatie opslaat.

Het bevat ook beknopte antwoorden op veelgestelde vragen over het weergeven van legende‑symbolen in een grafiek‑gegevens tabel, het behouden van de gegevens tabel bij export, werken met grafieken die geladen zijn uit bestaande presentaties of sjablonen, en het identificeren van grafieken waarbij de gegevens tabel is ingeschakeld.

## **Lettertype‑eigenschappen instellen voor gegevens tabel van grafiek**
Aspose.Slides for Python via .NET biedt ondersteuning voor het wijzigen van de kleur van categorieën in een serie‑kleur.  

1. Instantieer [Presentation](https://reference.aspose.com/slides/nl/python-net/aspose.slides/presentation/) class‑object.  
1. Voeg een grafiek toe aan de dia.  
1. Stel grafiektabel in.  
1. Stel letterhoogte in.  
1. Sla de gewijzigde presentatie op.  

Hieronder staat een voorbeeld.  

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

	chart.has_data_table = True

	chart.chart_data_table.text_format.portion_format.font_bold = 1
	chart.chart_data_table.text_format.portion_format.font_height = 20

	pres.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kan ik kleine legende‑symbolen naast de waarden in de gegevens tabel van de grafiek weergeven?**

Ja. De gegevens tabel ondersteunt [legend keys](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/datatable/show_legend_key/), en u kunt ze in- of uitschakelen.

**Wordt de gegevens tabel behouden bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert de grafiek als onderdeel van de dia, zodat de geëxporteerde [PDF](/slides/nl/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/nl/python-net/convert-powerpoint-to-html/)/[image](/slides/nl/python-net/convert-powerpoint-to-png/) de grafiek met de gegevens tabel bevat.

**Worden gegevens tabellen ondersteund voor grafieken die uit een sjabloonbestand komen?**

Ja. Voor elke grafiek die geladen is uit een bestaande presentatie of sjabloon kunt u controleren en wijzigen of een gegevens tabel [is shown](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_data_table/) via de eigenschapen van de grafiek.

**Hoe kan ik snel vinden welke grafieken in een bestand de gegevens tabel hebben ingeschakeld?**

Inspecteer de eigenschap van elke grafiek die aangeeft of de gegevens tabel [is shown](https://reference.aspose.com/slides/nl/python-net/aspose.slides.charts/chart/has_data_table/) en doorloop de dia's om de grafieken te identificeren waarbij deze is ingeschakeld.