---
title: Anpassa bubbeldiagram i presentationer med Python
linktitle: Bubbeldiagram
type: docs
url: /sv/python-net/bubble-chart/
keywords:
- bubbeldiagram
- bubbeltstorlek
- skalning av storlek
- storleksrepresentation
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint och OpenDocument med Aspose.Slides for Python via .NET för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Denna artikel visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbeltstorlekar via egenskapen `bubble_size_scale` och styrning av hur bubbeltstorleksvärden representeras via egenskapen `bubble_size_representation`.

Exemplen visar hur man skapar ett bubbeldiagram, justerar dess skalning av storlek och byter bubbeltstorleksrepresentation till att använda bredd. Artikeln innehåller också en kort FAQ‑sektion som klargör stöd för diagramtypen “Bubble with 3-D”, noterar att praktiska diagramgränser beror på prestanda och mål‑PowerPoint‑version, samt förklarar att export bevarar diagrammets utseende via Aspose.Slides renderingsmotor.

## **Skalning av bubbeldiagramstorlekar**
Aspose.Slides for Python via .NET ger stöd för skalning av bubbeldiagramstorlekar. I Aspose.Slides for Python via .NET har egenskaperna **ChartSeries.bubble_size_scale** och **ChartSeriesGroup.bubble_size_scale** lagts till. Nedan ges ett exempel. 

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
	chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 100, 100, 400, 300)
	chart.chart_data.series_groups[0].bubble_size_scale = 150
	pres.save("Result.pptx", slides.export.SaveFormat.PPTX)
```




## **Representera data som bubbeldiagramstorlekar**
Egenskapen **bubble_size_representation** har lagts till i klasserna ChartSeries, ChartSeriesGroup. **bubble_size_representation** specificerar hur bubbeltstorleksvärdena representeras i bubbeldiagrammet. Möjliga värden är: **BubbleSizeRepresentationType.AREA** och **BubbleSizeRepresentationType.WIDTH**. På motsvarande sätt har enumen **BubbleSizeRepresentationType** lagts till för att ange möjliga sätt att representera data som bubbeldiagramstorlekar. Nedan ges exempel på kod.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.BUBBLE, 50, 50, 600, 400, True)
    chart.chart_data.series_groups[0].bubble_size_representation = charts.BubbleSizeRepresentationType.WIDTH
    pres.save("Presentation_BubbleSizeRepresentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Stöds ett “bubble chart with 3-D effect”, och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, “Bubble with 3-D”. Den applicerar 3‑D‑stil på bubblorna men lägger inte till någon extra axel; data förblir X‑Y‑S (storlek). Typen finns i uppräkningen [chart type](https://reference.aspose.com/slides/sv/python-net/aspose.slides.charts/charttype/).

**Finns det någon begränsning för hur många serier och punkter som kan finnas i ett bubbeldiagram?**

Det finns ingen hård gräns på API‑nivå; begränsningarna bestäms av prestanda och mål‑PowerPoint‑versionen. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödjade format bevarar diagrammets utseende; renderingen utförs av Aspose.Slides‑motorn. För raster‑/vektormatier gäller generella regler för diagramgrafikrendering (upplösning, anti‑aliasing), så välj tillräckligt DPI för utskrift.