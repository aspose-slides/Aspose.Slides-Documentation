---
title: Anpassa bubbeldiagram i presentationer med Python
linktitle: Bubbeldiagram
type: docs
url: /sv/python-java/bubble-chart/
keywords:
- bubbeldiagram
- bubbelform
- storleksskalning
- storleksrepresentation
- PowerPoint
- presentation
- Python
- Java
- Aspose.Slides
description: "Skapa och anpassa kraftfulla bubbeldiagram i PowerPoint med Aspose.Slides för Python via Java för att enkelt förbättra din datavisualisering."
---
## **Översikt**

Den här artikeln visar hur man arbetar med bubbeldiagram i Aspose.Slides. Den täcker två specifika anpassningsalternativ: skalning av bubbelformer via metoden [setBubbleSizeScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale) och styrning av hur bubbelformvärden representeras via metoden [setBubbleSizeRepresentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation).

Exemplen demonstrerar hur man skapar ett bubbeldiagram, justerar skalningen av storlekar och byter bubbelformrepresentation till att använda bredd. Artikeln innehåller också en kort FAQ‑sektion som förklarar stöd för diagramtypen “Bubble with 3-D”, påpekar att praktiska diagramgränser beror på prestanda och mål‑PowerPoint‑version, samt beskriver hur export bevarar diagrammets utseende via Aspose.Slides‑renderingsmotorn.

## **Skalning av bubbeldiagramstorlek**
Aspose.Slides for Python via Java stödjer skalning av bubbeldiagramstorlek genom metoderna [ChartSeries.getBubbleSizeScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseries/#getBubbleSizeScale), [ChartSeriesGroup.getBubbleSizeScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeScale) och [ChartSeriesGroup.setBubbleSizeScale](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeScale). Följande exempel visar hur man skalar bubbelformer.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 100, 100, 400, 300)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeScale(150)

    presentation.save("Result.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Representera data som bubbeldiagramstorlekar**
Metoderna [**setBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#setBubbleSizeRepresentation) och [**getBubbleSizeRepresentation**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/#getBubbleSizeRepresentation) finns i klassen [ChartSeriesGroup](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chartseriesgroup/). Bubbelformrepresentationen anger hur bubbelformvärdena representeras i bubbeldiagrammet. Möjliga värden är [**BubbleSizeRepresentationType.Area**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bubblesizerepresentationtype/#Area) och [**BubbleSizeRepresentationType.Width**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bubblesizerepresentationtype/#Width). Uppräkningen [**BubbleSizeRepresentationType**](https://reference.aspose.com/slides/sv/python-java/aspose.slides/bubblesizerepresentationtype/) specificerar de möjliga sätten att representera data som bubbeldiagramstorlekar. Följande exempel visar hur man representerar bubbelformer med bredd.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BubbleSizeRepresentationType, ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, True)

    chart.getChartData().getSeriesGroups().get_Item(0).setBubbleSizeRepresentation(BubbleSizeRepresentationType.Width)

    presentation.save("Presentation_BubbleSizeRepresentation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Stöds ett "bubbeldiagram med 3-D‑effekt", och hur skiljer det sig från ett vanligt?**

Ja. Det finns en separat diagramtyp, “Bubble with 3-D”. Den applicerar 3‑D‑stil på bubblorna men lägger inte till någon extra axel; datan förblir X‑Y‑S (storlek). Typen finns i klassen för [diagramtyp](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/).

**Finns det en gräns för antalet serier och datapunkter i ett bubbeldiagram?**

Det finns ingen hård gräns på API‑nivå; begränsningarna bestäms av prestanda och mål‑PowerPoint‑version. Det rekommenderas att hålla antalet punkter rimligt för läsbarhet och renderingshastighet.

**Hur påverkar export utseendet på ett bubbeldiagram (PDF, bilder)?**

Export till stödda format bevarar diagrammets utseende; renderingen sker av Aspose.Slides‑motorn. För raster‑/vektormat­format gäller allmänna regler för diagramgrafikrendering (upplösning, kantutjämning), så välj tillräcklig DPI för utskrift.