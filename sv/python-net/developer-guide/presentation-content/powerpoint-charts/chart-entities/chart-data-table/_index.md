---
title: Anpassa diagramdatatabeller i Python
linktitle: Datatabell
type: docs
url: /sv/python-net/chart-data-table/
keywords:
- diagramdata
- datatabell
- typsnittegenskaper
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Anpassa diagramdatatabeller i Python för PPT, PPTX och ODP med Aspose.Slides för att öka effektiviteten och attraktiviteten i presentationer."
---
## **Översikt**

Denna artikel förklarar hur man arbetar med diagramdatatabeller i Aspose.Slides. Den visar hur man visar en datatabell för ett diagram och anpassar dess textformatering genom att ställa in typsnittsegenskaper såsom fet stil och typsnittshöjd. Exemplet demonstrerar hur man laddar en presentation, lägger till ett diagram, aktiverar diagrammets datatabell, tillämpar typsnittsinställningar och sparar den uppdaterade presentationen.

Den innehåller också korta svar på vanliga frågor om att visa förklaringsnycklar i en diagramdatatabell, bevara datatabellen vid export, arbeta med diagram som laddats från befintliga presentationer eller mallar, samt identifiera diagram där datatabellen är aktiverad.

## **Ange typsnitts‑egenskaper för diagramdatatabell**

Aspose.Slides for Python via .NET erbjuder stöd för att ändra färg på kategorier i en seriefärg.  

1. Instansiera [Presentation](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/) klassobjekt.  
1. Lägg till diagram på bilden.  
1. Ställ in diagramtabell.  
1. Ställ in typsnittshöjd.  
1. Spara den modifierade presentationen.  

Nedan ges ett exempel.  

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

**Kan jag visa små förklaringsnycklar bredvid värdena i diagrammets datatabell?**

Ja. Datatabellen stöder [legend keys](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/datatable/show_legend_key/), och du kan slå på eller av dem.

**Kommer datatabellen att bevaras vid export av presentationen till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet som en del av bilden, så den exporterade [PDF](/slides/sv/python-net/convert-powerpoint-to-pdf/)/[HTML](/slides/sv/python-net/convert-powerpoint-to-html/)/[image](/slides/sv/python-net/convert-powerpoint-to-png/) innehåller diagrammet med dess datatabell.

**Stöds datatabeller för diagram som kommer från en mallfil?**

Ja. För alla diagram som laddats från en befintlig presentation eller mall kan du kontrollera och ändra om en datatabell [visas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_data_table/) via diagrammets egenskaper.

**Hur kan jag snabbt hitta vilka diagram i en fil som har datatabellen aktiverad?**

Inspektera varje diagram‑egenskap som visar om datatabellen [visas](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/chart/has_data_table/) och gå igenom bilderna för att identifiera diagrammen där den är aktiverad.