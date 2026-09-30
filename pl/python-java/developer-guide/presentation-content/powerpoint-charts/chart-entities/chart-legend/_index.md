---
title: "Dostosuj legendy wykresów w prezentacjach przy użyciu Pythona"
linktitle: "Legenda wykresu"
type: docs
url: /pl/python-java/chart-legend/
keywords:
  - "legenda wykresu"
  - "pozycja legendy"
  - "rozmiar czcionki"
  - "PowerPoint"
  - "prezentacja"
  - "Python"
  - "Java"
  - "Aspose.Slides"
description: "Dostosuj legendy wykresów przy użyciu Aspose.Slides for Python via Java, aby zoptymalizować prezentacje PowerPoint poprzez spersonalizowane formatowanie legend."
---
## **Przegląd**

Aspose.Slides for Python via Java zapewnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak pozycjonować i zmieniać rozmiar legendy, ustawiać rozmiar czcionki dla całej legendy, formatować pojedynczy wpis legendy oraz ukrywać lub przywracać wybrane pozycje.

FAQ obejmuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie etykiet wielowierszowych oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj metod legendy [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) oraz [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight), aby określić jej pozycję i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje wykres kolumnowy grupowany z domyślnymi danymi do pierwszego slajdu. Podzielenie żądanych offsetów i wymiarów legendy przez szerokość i wysokość wykresu konwertuje je na wartości względne: legenda jest przesunięta o 50 punktów od lewego górnego rogu wykresu i ma rozmiar 100 na 100 punktów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Określ pozycję i rozmiar legendy względem wykresu.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw rozmiar czcionki legendy**

Użyj [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) legendy, aby uzyskać dostęp do formatowania tekstu, oraz [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight), aby ustawić rozmiar czcionki w punktach.

Ten przykład tworzy wykres z domyślnymi danymi i ustawia tekst legendy na 20 punktów. Wyłącza także automatyczne granice dla osi pionowej i ustawia jej zakres od -5 do 10.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ustaw rozmiar czcionki pojedynczego wpisu legendy**

Użyj kolekcji zwracanej przez metodę legendy [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries), aby uzyskać dostęp do formatowania konkretnego wpisu. Indeksy wpisów zaczynają się od zera, więc indeks `1` odnosi się do drugiego wpisu.

Ten przykład tworzy wykres kolumnowy grupowany, którego domyślne dane zawierają przynajmniej dwie serie. Formatuje drugi wpis legendy, używając pogrubionej, pochylonej i niebieskiej czcionki o rozmiarze 20 punktów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ukryj pojedyncze wpisy legendy**

Aby wykluczyć pomocniczą serię z legendy, zachowując jej dane widoczne, wywołaj [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) z wartością `True` za pośrednictwem [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). To ukrywa tylko wybrany wpis legendy; nie usuwa serii ani jej punktów danych. Natomiast wywołanie [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) z wartością `False` ukrywa całą legendę.

Poniższy przykład tworzy wykres kolumnowy grupowany z wieloma seriami przy użyciu domyślnych danych. Ukrywa wpis legendy drugiej serii (indeks `1`) i zapisuje prezentację. Następnie przywraca wpis, wywołując [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) z wartością `False` i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Przywróć ten sam wpis bez zmiany danych wykresu.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Poniższe porównanie pokazuje ten sam wykres ze wszystkimi widocznymi wpisami oraz z ukrytym drugim wpisem. Kolumny drugiej serii pozostają niezmienione.

![Porównanie wykresu ze wszystkimi widocznymi wpisami legendy oraz z ukrytym Serią 2 w legendzie; wszystkie kolumny pozostają widoczne.](hide-legend-entry.png)

W wykresach kolumnowych, słupkowych i liniowych wpisy legendy identyfikują serie. W wykresach kołowych identyfikują one pojedyncze punkty danych (wycinki), więc należy użyć [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) na wybranej wycince. Dokumentacja API opisuje tę metodę punktu danych dla typów wykresów `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` i `BarOfPie`. Nie zakładaj, że działa ona w wykresach pierścieniowych, które nie są wymienione na tej liście.

## **FAQ**

**Czy mogę sprawić, że wykres zarezerwuje miejsce dla legendy zamiast nakładać ją na obszar wykresu?**

Tak. Wywołaj [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) z wartością `False`, aby zarezerwować miejsce dla legendy zamiast pozwalać jej nakładać się na obszar wykresu.

**Czy mogę tworzyć wielowierszowe etykiety legendy?**

Tak. Długie etykiety mogą się zawijać, gdy dostępna szerokość jest niewystarczająca. Możesz również używać znaków nowej linii w nazwach serii, aby wymusić podziały linii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie z motywu. Jawne formatowanie nadpisuje odpowiadające ustawienia motywu.