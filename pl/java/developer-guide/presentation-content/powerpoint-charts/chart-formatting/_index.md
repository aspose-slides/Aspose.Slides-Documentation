---
title: Formatowanie wykresów w prezentacji w Javie
linktitle: Formatowanie wykresu
type: docs
weight: 60
url: /pl/java/chart-formatting/
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
- Java
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Javy i podnieś swoją prezentację PowerPoint dzięki niestandardowym osiom, czcionkom, formatom liczb oraz zaokrąglonym krawędziom wykresu."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wbudowane formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatuj elementy wykresu**

Użyj [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) do formatowania tytułów wykresu, osi, linii siatki, legend i obszaru wykresu. Ten przykład tworzy wykres liniowy ze znacznikami i domyślnymi danymi, a następnie stosuje oddzielne style tekstu i linii do osi wartości i osi kategorii. Rozmiary czcionek i grubości linii podane są w punktach; etykiety kategorii są obrócone o 45 stopni.

Oś wartości używa [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) niezależnie od komórek źródłowych. Jej skala rozciąga się od -2 do 15, z głównymi przedziałami co 2 i mniejszymi przedziałami co 0,5. Przykład łączy także formatowanie procentowe z [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) ustawionym na tysiące, więc dostosuj te ustawienia do znaczenia i wielkości swoich danych. Legenda pozostaje poza obszarem wykresu, ponieważ [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) jest wywoływana z wartością `false`. Wypełnienia tylnej ściany i podłogi konfigurowane są za pomocą [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) i [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--), ale te powierzchnie są widoczne tylko w wykresach 3D.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw właściwości czcionki dla wykresu**

Ustaw domyślny rozmiar czcionki dla tekstu wykresu za pomocą [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--). Przykład tworzy wykres kolumnowy grupowany z czcionką 20 punktów i włącza etykiety wartości dla pierwszej serii przy użyciu [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). Elementy tekstowe z własnymi explicit ustawieniami czcionki mogą zastąpić domyślne ustawienia wykresu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw format liczbowy**

Użyj [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) aby zastosować wbudowany format liczbowy do komórek skoroszytu wykresu. Ten przykład tworzy wykres kolumnowy grupowany z domyślnymi, opartymi na komórkach danymi i stosuje indeks formatu 10 (`0.00%`) do każdej komórki wartości serii. Zmienia to sposób wyświetlania wartości w skoroszycie bez zmiany leżących pod spodem liczb; na przykład 0,25 jest wyświetlane jako 25,00%. Format osi i etykiet danych może być konfigurowany oddzielnie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższa tabela zawiera indeksy wbudowanych formatów liczbowych wraz z reprezentatywnymi formatami Excel dla ustawień regionalnych English (United States). Dokładne ciągi formatów i ich wyświetlanie mogą się różnić w zależności od aplikacji i ustawień regionalnych, szczególnie dla walut i dat. Niektóre formaty Excel różnią się także od domyślnych w standardzie OOXML, jak opisano w [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Indeks | Format |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Ustaw zaokrąglone krawędzie obszaru wykresu**

Wywołaj [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) z wartością `true`, aby zaokrąglić rogi obszaru wykresu. Przykład tworzy wykres kolumnowy grupowany i używa [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) aby nadać jego obramowaniu jednolity szary kolor i jednoliniowy styl przed zapisaniem prezentacji.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Edytuj istniejące adnotacje wykresu**

Wykres może zawierać niestandardowe kształty, takie jak adnotacja tekstowa wyjaśniająca status raportu. Dostęp do tych kształtów uzyskuje się poprzez [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--), również wymieniony w [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) w odniesieniu do API wykresu. Kolekcja zwrócona przez [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) zawiera kształty należące do wykresu.

Zwykły pole tekstowe umieszczone nad wykresem należy do slajdu, nawet jeśli wygląda jak część wykresu. Iterowanie przez [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) znajduje wykres i zwykłe kształty slajdu, ale nie wylicza poszczególnych kształtów wewnątrz wykresu. Tytuły wykresów i etykiety danych są oddzielnymi elementami wykresu, a nie niestandardowymi adnotacjami w tej kolekcji.

Pobierz [chart-annotations.pptx](chart-annotations.pptx) i umieść go w katalogu roboczym aplikacji. Jego pierwszy slajd zawiera wykres z niezagregowaną adnotacją o treści „Preliminary results”, linią należącą do wykresu oraz zwykłym polem tekstowym slajdu o treści „Slide overlay”. Przykład znajduje pierwszy wykres na tym slajdzie i zmienia adnotację na „Final results”, gdy raport jest gotowy do publikacji. Sprawdza, czy kolekcja nie jest pusta i edytuje jedynie [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) z niepustą ramką tekstową zwróconą przez [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) oraz z oczekiwanym tekstem.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

Linia i pole tekstowe slajdu pozostają niezmienione. Poniższe obrazy prezentują wejściowy oraz zapisany, ponownie otwarty wynik:

| Before editing | After editing |
| --- | --- |
| ![Adnotacja wykresu – Preliminary results](chart-annotations-before.png) | ![Adnotacja wykresu – Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Przykład sprawdza tylko kształty będące własnością wykresu na najwyższym poziomie. Jeśli adnotacja znajduje się wewnątrz [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/), sprawdź także zbiór [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) tej grupy. Powtarzaj to rekurencyjnie dla zagnieżdżonych grup, stosując te same kontrole tekstu do ich podrzędnych kształtów. Grupa sama w sobie jest kontenerem; nie traktuj jej jako pola tekstowego.
{{% /alert %}}

## **Najczęściej zadawane pytania**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i obramowanie są konfigurowane osobno. Jest to przydatne do poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak mogę radzić sobie z etykietami danych, gdy zachodzą na siebie?**

Zredukuj rozmiar czcionki, wyłącz nieistotne elementy etykiet (na przykład kategorie), dostosuj położenie etykiet, w razie potrzeby wyświetlaj etykiety tylko dla wybranych punktów lub zmień format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorzec do serii?**

Tak. Serii można stosować wypełnienia jednolite, gradientowe i wzorzec. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które zmniejszają kontrast z siatką i tekstem.