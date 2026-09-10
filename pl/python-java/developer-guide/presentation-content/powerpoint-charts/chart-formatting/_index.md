---
title: Formatowanie wykresów prezentacji w Pythonie
linktitle: Formatowanie wykresów
type: docs
weight: 60
url: /pl/python-java/chart-formatting/
keywords:
- formatowanie wykresu
- formatowanie wykresu
- element wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglona krawędź
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Pythona poprzez Java i podnieś swoją prezentację PowerPoint dzięki profesjonalnemu, przyciągającemu uwagę stylowi."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane i własne formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi dla obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatuj elementy wykresu**
Aspose.Slides for Python via Java umożliwia programistom dodawanie własnych wykresów do slajdów od podstaw. Ten artykuł wyjaśnia, jak formatować różne elementy wykresu, w tym osie kategorii i wartości.

Aspose.Slides for Python via Java provides a simple API for managing different chart entities and formatting them using custom values:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj dostęp do slajdu przy użyciu jego indeksu.
1. Dodaj wykres wybranego typu z danymi domyślnymi (w tym przykładzie użyto [ChartType.LineWithMarkers](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Uzyskaj dostęp do osi wartości wykresu i ustaw następujące właściwości:
   1. Ustaw **format linii** dla głównych linii siatki osi wartości.
   1. Ustaw **format linii** dla pomniejszych linii siatki osi wartości.
   1. Ustaw **format liczbowy** dla osi wartości.
   1. Ustaw **minimum, maksimum, jednostki główne i pomniejsze** dla osi wartości.
   1. Ustaw **właściwości tekstu** dla danych osi wartości.
   1. Ustaw **tytuł** dla osi wartości.
1. Uzyskaj dostęp do osi kategorii wykresu i ustaw następujące właściwości:
   1. Ustaw **format linii** dla głównych linii siatki osi kategorii.
   1. Ustaw **format linii** dla pomniejszych linii siatki osi kategorii.
   1. Ustaw **właściwości tekstu** dla danych osi kategorii.
   1. Ustaw **tytuł** dla osi kategorii.
   1. Ustaw **pozycjonowanie etykiet** dla osi kategorii.
   1. Ustaw **kąt obrotu** dla etykiet osi kategorii.
1. Uzyskaj dostęp do legendy wykresu i ustaw jej **właściwości tekstu**.
1. Wyświetl legendę wykresu bez nakładania się na wykres.
1. Uzyskaj dostęp do **drugorzędnej osi wartości** wykresu i ustaw następujące właściwości:
   1. Włącz drugorzędną **osię wartości**.
   1. Ustaw **format linii** dla drugorzędnej osi wartości.
   1. Ustaw **format liczbowy** dla drugorzędnej osi wartości.
   1. Ustaw **minimum, maksimum, jednostki główne i pomniejsze** dla drugorzędnej osi wartości.
1. Umieść pierwszą serię wykresu na drugorzędnej osi wartości.
1. Ustaw kolor wypełnienia tylnej ściany wykresu.
1. Ustaw kolor wypełnienia obszaru wykresu.
1. Zapisz zmodyfikowaną prezentację do pliku PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Utwórz instancję klasy Presentation
presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu
    slide = presentation.getSlides().get_Item(0)

    # Dodaj przykładowy wykres
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Ustaw tytuł wykresu
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Ustaw format głównych linii siatki dla osi wartości
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Ustaw format pomniejszych linii siatki dla osi wartości
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Ustaw format liczbowy osi wartości
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Ustaw maksymalne i minimalne wartości wykresu
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Ustaw właściwości tekstu osi wartości
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Ustaw tytuł osi wartości
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Ustaw format głównych linii siatki dla osi kategorii
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Ustaw format pomniejszych linii siatki dla osi kategorii
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Ustaw właściwości tekstu osi kategorii
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Ustaw tytuł osi kategorii
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Ustaw pozycję etykiet osi kategorii
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Ustaw kąt obrotu etykiet osi kategorii
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Ustaw właściwości tekstu legendy
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Pokaż legendę wykresu bez nakładania się na wykres

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Ustaw drugorzędną oś wartości
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Ustaw format liczbowy drugorzędnej osi wartości
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Ustaw maksymalne i minimalne wartości wykresu
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Ustaw kolor tylnej ściany wykresu
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Ustaw kolor obszaru wykresu
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Save the presentation
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw właściwości czcionki dla wykresu**
Aspose.Slides for Python via Java obsługuje ustawianie właściwości czcionki dla wykresów. Postępuj zgodnie z poniższymi krokami, aby ustawić właściwości czcionki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Dodaj wykres do slajdu.
- Ustaw wysokość czcionki.
- Zapisz zmodyfikowaną prezentację.

Poniższy przykład demonstruje te kroki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw format numeryczny**
Aspose.Slides for Python via Java udostępnia prosty interfejs API do zarządzania formatami danych wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj dostęp do slajdu przy użyciu jego indeksu.
1. Dodaj wykres wybranego typu z danymi domyślnymi (w tym przykładzie użyto [ChartType.ClusteredColumn](https://reference.aspose.com/slides/pl/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Ustaw wstępnie zdefiniowany format liczbowy spośród dostępnych wartości wstępnych.
1. Iteruj przez komórki danych w każdej serii wykresu i ustaw ich format liczbowy.
1. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Utwórz instancję klasy Presentation
presentation = Presentation()
try:
    # Uzyskaj dostęp do pierwszego slajdu prezentacji
    slide = presentation.getSlides().get_Item(0)

    # Dodaj domyślny wykres kolumnowy grupowany
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Uzyskaj dostęp do zbioru serii wykresu
    chart_series_collection = chart.getChartData().getSeries()

    # Przejdź przez wszystkie serie wykresu
    for chart_series in chart_series_collection:
        # Przejdź przez wszystkie punkty danych w serii
        for data_point in chart_series.getDataPoints():
            # Ustaw format liczbowy
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Zapisz prezentację
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dostępne wstępnie zdefiniowane formaty liczbowe i ich indeksy są wymienione poniżej:

|**0**|Ogólny|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ustaw zaokrąglone krawędzie obszaru wykresu**
Aspose.Slides for Python via Java obsługuje zaokrąglone rogi obszaru wykresu poprzez metody [hasRoundedCorners](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#hasRoundedCorners) i [setRoundedCorners](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/#setRoundedCorners) klasy [Chart](https://reference.aspose.com/slides/pl/python-java/aspose.slides/chart/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Dodaj wykres do slajdu.
1. Ustaw typ i styl wypełnienia linii obramowania wykresu.
1. Włącz zaokrąglone rogi.
1. Zapisz zmodyfikowaną prezentację.

Poniższy przykład demonstruje te kroki.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Utwórz instancję klasy Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczystą ramkę?**

Tak. Przezroczystość wypełnienia i obramowanie są konfigurowane osobno. Jest to przydatne do poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę sobie poradzić z etykietami danych, gdy zachodzą na siebie?**

Zredukuj rozmiar czcionki, wyłącz nieistotne elementy etykiet (np. kategorie), ustaw offset/pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Zazwyczaj dostępne są zarówno wypełnienia jednorodne, jak i gradientowe/wzorcowe. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które obniżają kontrast względem siatki i tekstu.