---
title: Správa datových značek grafu v prezentacích pomocí Pythonu
linktitle: Datová značka
type: docs
url: /cs/python-java/chart-data-marker/
keywords:
- graf
- datový bod
- značka
- možnosti značky
- velikost značky
- typ výplně
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Naučte se, jak přizpůsobit datové značky grafu v Aspose.Slides pro Python pomocí Javy, a zvýšit dopad prezentací v formátech PPT a PPTX pomocí přehledných příkladů kódu v Pythonu."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s datovými značkami grafu v Aspose.Slides. Ukazuje, jak vytvořit graf, získat přístup k sérii a jejím datovým bodům, aplikovat výplně obrázků na značky na úrovni datových bodů, upravit velikost značky a uložit aktualizovanou prezentaci. Také uvádí, že standardní tvary značek jsou k dispozici prostřednictvím výčtu [MarkerStyleType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markerstyletype/) a že vzhled značky je zachován při exportu grafů do rastrových formátů nebo SVG.

## **Nastavení možností značek grafu**
Značky lze nastavit na datových bodech grafu v konkrétní sérii. Pro nastavení možností značek grafu postupujte podle těchto kroků:

- Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
- Vytvořte výchozí graf.
- Nastavte obrázky.
- Získejte první sérii grafu.
- Přidejte nové datové body.
- Zapište prezentaci na disk.

Následující příklad nastavuje možnosti značek grafu na úrovni datových bodů.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, Presentation, SaveFormat

# Vytvořte prázdnou prezentaci.
presentation = Presentation()
try:
    # Získejte první snímek
    slide = presentation.getSlides().get_Item(0)

    # Vytváří se výchozí graf
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 0, 0, 400, 400)

    # Získejte výchozí index listu dat grafu.
    default_worksheet_index = 0

    # Získejte sešit s daty grafu.
    workbook = chart.getChartData().getChartDataWorkbook()

    # Odstraňte demonstrační sérii
    chart.getChartData().getSeries().clear()

    # Přidejte novou sérii
    series_name_cell = workbook.getCell(default_worksheet_index, 1, 1, "Series 1")
    chart.getChartData().getSeries().add(series_name_cell, chart.getType())

    # Načtěte první obrázek.
    desert_bytes = Path("Desert.jpg").read_bytes()
    desert_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(desert_bytes))

    # Načtěte druhý obrázek.
    tulips_bytes = Path("Tulips.jpg").read_bytes()
    tulips_image = presentation.getImages().addImage(jpype.JArray(jpype.JByte)(tulips_bytes))

    # Získejte první sérii grafu.
    series = chart.getChartData().getSeries().get_Item(0)

    # Přidejte datové body.
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

    # Změňte velikost značky série grafu.
    series.getMarker().setSize(15)

    # Uložte prezentaci s grafem
    presentation.save("MarkOptions_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Často kladené dotazy**

**Jaké tvary značek jsou k dispozici přímo?**

Standardní tvary jsou k dispozici (kruh, čtverec, diamant, trojúhelník atd.); seznam je definován třídou [MarkerStyleType](https://reference.aspose.com/slides/cs/python-java/aspose.slides/markerstyletype/). Pokud potřebujete nestandardní tvar, použijte značku s výplní obrázkem k napodobení vlastních vizuálů.

**Zůstávají značky zachovány při exportu grafu do obrázku nebo SVG?**

Ano. Při vykreslování grafů do [rasterové formáty](/slides/cs/python-java/convert-powerpoint-to-png/) nebo ukládání [tvary jako SVG](/slides/cs/python-java/render-a-slide-as-an-svg-image/) si značky zachovávají svůj vzhled a nastavení, včetně velikosti, výplně a obrysu.