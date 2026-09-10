---
title: Zarządzanie znacznikami danych wykresu w prezentacjach przy użyciu Pythona
linktitle: Znacznik danych
type: docs
url: /pl/python-java/chart-data-marker/
keywords:
- wykres
- punkt danych
- znacznik
- opcje znacznika
- rozmiar znacznika
- typ wypełnienia
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak dostosować znaczniki danych wykresu w Aspose.Slides dla Pythona przy użyciu Javy, zwiększając wpływ prezentacji w formatach PPT i PPTX dzięki przejrzystym przykładom kodu w Pythonie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować ze znacznikami danych wykresu w Aspose.Slides. Pokazuje, jak utworzyć wykres, uzyskać dostęp do serii i jej punktów danych, zastosować wypełnienia obrazkiem do znaczników na poziomie punktu danych, dostosować rozmiar znacznika oraz zapisać zaktualizowaną prezentację. Zaznacza również, że standardowe kształty znaczników są dostępne w wyliczeniu [MarkerStyleType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markerstyletype/) i że wygląd znacznika jest zachowywany przy eksportowaniu wykresów do formatów rastrowych lub SVG.

## **Ustaw opcje znacznika wykresu**
Markery można ustawić dla punktów danych wykresu w konkretnej serii. Aby ustawić opcje znacznika wykresu, wykonaj następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Utwórz wykres domyślny.
- Ustaw obrazy.
- Uzyskaj dostęp do pierwszej serii wykresu.
- Dodaj nowe punkty danych.
- Zapisz prezentację na dysk.

Poniższy przykład ustawia opcje znacznika wykresu na poziomie punktu danych.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Utwórz pustą prezentację.
presentation = Presentation()
try:
    # Access first slide
    slide = presentation.getSlides().get_Item(0)

    # Creating the default chart
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Get the default chart data worksheet index.
    default_worksheet_index = 0

    # Get the chart data workbook.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Delete demo series
    chart.getChartData().getSeries().clear()

    # Add new series
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Load the first picture.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Load the second picture.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Access the first chart series.
    series = chart.getChartData().getSeries().get_Item(0)

    # Add data points.
    value_cell = workbook.getCell(default_worksheet_index, 1, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 2, 1, 2.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    value_cell = workbook.getCell(default_worksheet_index, 3, 1, 3.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(desert_image)

    value_cell = workbook.getCell(default_worksheet_index, 4, 1, 4.5)
    point = series.getDataPoints().addDataPointForLineSeries(value_cell)
    point.getMarker().getFormat().getFill().setFillType(FillType.Picture)
    point.getMarker().getFormat().getFill().getPictureFillFormat().getPicture().setImage(tulips_image)

    # Change the chart series marker size.
    series.getMarker().setSize(15)

    # Save presentation with chart
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```


## **FAQ**

**Jakie kształty znaczników są dostępne od razu?**

Standardowe kształty są dostępne (koło, kwadrat, romb, trójkąt itp.); lista jest zdefiniowana w klasie [MarkerStyleType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/markerstyletype/). Jeśli potrzebujesz niestandardowego kształtu, użyj znacznika z wypełnieniem obrazem, aby emulować własne elementy wizualne.

**Czy znaczniki są zachowywane przy eksportowaniu wykresu do obrazu lub SVG?**

Tak. Podczas renderowania wykresów do [formatów rastrowych](/slides/pl/python-java/convert-powerpoint-to-png/) lub zapisywania [kształtów jako SVG](/slides/pl/python-java/render-a-slide-as-an-svg-image/), znaczniki zachowują swój wygląd i ustawienia, w tym rozmiar, wypełnienie i obrys.