---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu Pythona
linktitle: Legenda wykresu
type: docs
url: /pl/python-java/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides dla Pythona poprzez Java, aby zoptymalizować prezentacje PowerPoint z dopasowanym formatowaniem legendy."
---
## **Przegląd**

Aspose.Slides udostępnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić położenie i rozmiar legendy, określić rozmiar czcionki całej legendy oraz zastosować formatowanie do pojedynczego wpisu legendy.

Opisuje także kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu pozostawił miejsce dla legendy, umożliwienie długim etykietom legendy zawijanie lub używanie znaków nowej linii oraz dziedziczenie formatowania legendy z motywem prezentacji, gdy nie zostaną zastosowane explicite ustawienia tekstu i wypełnienia.

## **Pozycjonowanie legendy**

Aby ustawić właściwości legendy, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu.
1. Dodaj wykres do slajdu.
1. Ustaw właściwości legendy.
1. Zapisz prezentację jako plik PPTX.

Poniższy przykład ustawia położenie i rozmiar legendy wykresu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Utwórz pustą prezentację.
presentation = Presentation()
try:
    # Uzyskaj odniesienie do slajdu.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj wykres kolumnowy grupowany do slajdu.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Ustaw właściwości legendy.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Zapisz prezentację na dysku.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawienie rozmiaru czcionki legendy**

Aspose.Slides for Python via Java umożliwia ustawienie rozmiaru czcionki legendy. Wykonaj następujące kroki:

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Utwórz domyślny wykres.
1. Ustaw rozmiar czcionki.
1. Ustaw minimalną wartość osi.
1. Ustaw maksymalną wartość osi.
1. Zapisz prezentację na dysku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Utwórz pustą prezentację.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustawienie rozmiaru czcionki pojedynczego wpisu legendy**

Aspose.Slides for Python via Java umożliwia ustawienie rozmiaru czcionki poszczególnych wpisów legendy. Wykonaj następujące kroki:

1. Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Utwórz domyślny wykres.
1. Uzyskaj dostęp do wpisu legendy.
1. Ustaw rozmiar czcionki.
1. Zapisz prezentację na dysku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Utwórz pustą prezentację.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę włączyć legendę tak, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać się na nią?**

Tak. Użyj [setOverlay](https://reference.aspose.com/slides/pl/python-java/aspose.slides/legend/#setOverlay) z wartością `False`, aby włączyć tryb bez nakładania; w tym przypadku obszar wykresu zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć wieloliniowe etykiety legendy?**

Tak. Długie etykiety automatycznie się zawijają, gdy brakuje miejsca; wymuszone podziały linii są obsługiwane za pomocą znaków nowej linii w nazwie serii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Nie ustawiaj explicite kolorów, wypełnień ani czcionek dla legendy ani jej tekstu. Wtedy będą one dziedziczone z motywu i prawidłowo zaktualizują się przy zmianie projektu.