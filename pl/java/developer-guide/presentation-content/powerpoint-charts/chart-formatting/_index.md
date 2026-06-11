---
title: Formatowanie wykresów prezentacji w Javie
linktitle: Formatowanie wykresów
type: docs
weight: 60
url: /pl/java/chart-formatting/
keywords:
- format wykresu
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
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Javy i podnieś swoją prezentację PowerPoint dzięki profesjonalnemu, przyciągającemu uwagę stylowi."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Pokazuje także, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępne i niestandardowe formaty liczbowe do danych wykresu oraz włączyć zaokrąglone rogi dla obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatowanie elementów wykresu**
Aspose.Slides for Java pozwala programistom dodawać własne wykresy do slajdów od podstaw. Ten artykuł wyjaśnia, jak formatować różne elementy wykresu, w tym oś kategorii i oś wartości.

Aspose.Slides for Java udostępnia prosty interfejs API do zarządzania różnymi elementami wykresu i formatowania ich przy użyciu własnych wartości:

1. Utwórz instancję klasy [**Presentation**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z domyślnymi danymi oraz dowolnym wybranym typem (w tym przykładzie użyjemy ChartType.LineWithMarkers).
1. Uzyskaj dostęp do osi wartości wykresu i ustaw następujące właściwości:
   1. Ustawienie **Line format** dla głównych linii siatki osi wartości
   1. Ustawienie **Line format** dla pomniejszych linii siatki osi wartości
   1. Ustawienie **Number Format** dla osi wartości
   1. Ustawienie **Min, Max, Major and Minor units** dla osi wartości
   1. Ustawienie **Text Properties** dla danych osi wartości
   1. Ustawienie **Title** dla osi wartości
   1. Ustawienie **Line Format** dla osi wartości
1. Uzyskaj dostęp do osi kategorii wykresu i ustaw następujące właściwości:
   1. Ustawienie **Line format** dla głównych linii siatki osi kategorii
   1. Ustawienie **Line format** dla pomniejszych linii siatki osi kategorii
   1. Ustawienie **Text Properties** dla danych osi kategorii
   1. Ustawienie **Title** dla osi kategorii
   1. Ustawienie **Label Positioning** dla osi kategorii
   1. Ustawienie **Rotation Angle** dla etykiet osi kategorii
1. Uzyskaj dostęp do legendy wykresu i ustaw **Text Properties** dla niej
1. Ustaw wyświetlanie legend wykresu bez nakładania się na wykres
1. Uzyskaj dostęp do **Secondary Value Axis** wykresu i ustaw następujące właściwości:
   1. Włącz sekundarną **Value Axis**
   1. Ustawienie **Line Format** dla drugorzędnej osi wartości
   1. Ustawienie **Number Format** dla drugorzędnej osi wartości
   1. Ustawienie **Min, Max, Major and Minor units** dla drugorzędnej osi wartości
1. Teraz narysuj pierwszą serię wykresu na drugorzędnej osi wartości
1. Ustaw kolor wypełnienia tylnej ściany wykresu
1. Ustaw kolor wypełnienia obszaru wykresu
1. Zapisz zmodyfikowaną prezentację do pliku PPTX

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Uzyskiwanie pierwszego slajdu
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodawanie przykładowego wykresu
    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    // Ustawianie tytułu wykresu
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ustawianie formatu głównych linii siatki dla osi wartości
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    // Ustawianie formatu pomocniczych linii siatki dla osi wartości
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Ustawianie formatu liczbowego osi wartości
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    // Ustawianie maksymalnych i minimalnych wartości wykresu
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    // Ustawianie właściwości tekstu osi wartości
    IChartPortionFormat txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(NullableBool.True);
    txtVal.getFillFormat().setFillType(FillType.Solid);
    txtVal.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkGreen));
    txtVal.setLatinFont(new FontData("Times New Roman"));

    // Ustawianie tytułu osi wartości
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ustawianie formatu głównych linii siatki dla osi kategorii
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    // Ustawianie formatu pomocniczych linii siatki dla osi kategorii
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    // Ustawianie właściwości tekstu osi kategorii
    IChartPortionFormat txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(NullableBool.True);
    txtCat.getFillFormat().setFillType(FillType.Solid);
    txtCat.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    txtCat.setLatinFont(new FontData("Arial"));

    // Ustawianie tytułu osi kategorii
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(NullableBool.True);

    // Ustawianie pozycji etykiet osi kategorii
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);

    // Ustawianie kąta obrotu etykiet osi kategorii
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    // Ustawianie właściwości tekstu legendy
    IChartPortionFormat txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(NullableBool.True);
    txtleg.getFillFormat().setFillType(FillType.Solid);
    txtleg.getFillFormat().getSolidFillColor().setColor(new Color(PresetColor.DarkRed));

    // Ustaw wyświetlanie legend wykresu bez nakładania się na wykres

    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Ustawianie drugorzędnej osi wartości
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);

    // Ustawianie formatu liczbowego drugorzędnej osi wartości
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");

    // Ustawianie maksymalnych i minimalnych wartości wykresu
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20f);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5f);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0f);

    // Ustawianie koloru tylnej ściany wykresu
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE);

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);
    // Ustawianie koloru obszaru wykresu
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(new Color(PresetColor.LightCyan));

    // Zapisz prezentację
    pres.save("FormattedChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw właściwości czcionki dla wykresu**
Aspose.Slides for Java zapewnia obsługę ustawiania właściwości czcionki związanych z wykresem. Proszę postępować zgodnie z poniższymi krokami, aby ustawić właściwości czcionki dla wykresu.

- Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation/).
- Dodaj wykres na slajdzie.
- Ustaw wysokość czcionki.
- Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    
    pres.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw format liczbowy**
Aspose.Slides for Java udostępnia prosty interfejs API do zarządzania formatem danych wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu.
1. Dodaj wykres z domyślnymi danymi oraz dowolnym wybranym typem (ten przykład używa **ChartType.ClusteredColumn**).
1. Ustaw wstępny format liczbowy spośród dostępnych wartości wstępnych.
1. Przejdź przez komórkę danych wykresu w każdej serii wykresu i ustaw format liczbowy danych wykresu.
1. Zapisz prezentację.
1. Ustaw niestandardowy format liczbowy.
1. Przejdź przez komórkę danych wykresu w każdej serii wykresu i ustaw inny format liczbowy danych wykresu.
1. Zapisz prezentację.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Uzyskaj dostęp do pierwszego slajdu prezentacji
    ISlide slide = pres.getSlides().get_Item(0);

    // Dodaj domyślny wykres słupkowy skupiony
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);

    // Uzyskanie kolekcji serii wykresu
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    // Przejście przez każdą serię wykresu
    for (IChartSeries ser : series) 
    {
        // Przejście przez każdą komórkę danych w serii
        for (IChartDataPoint cell : ser.getDataPoints()) 
        {
            // Ustawienie formatu liczbowego
            cell.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0,00%
        }
    }

    // Zapisanie prezentacji
    pres.save("PresetNumberFormat.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Poniżej podano możliwe wartości wstępnych formatów liczbowych wraz z ich indeksami, które można używać:

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
Aspose.Slides for Java zapewnia obsługę ustawiania obszaru wykresu. Metody [**hasRoundedCorners**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChart#hasRoundedCorners--) i [**setRoundedCorners**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChart#setRoundedCorners-boolean-) zostały dodane do interfejsu [IChart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/IChart) oraz klasy [Chart](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Chart).

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
1. Dodaj wykres na slajdzie.
1. Ustaw typ wypełnienia i kolor wypełnienia wykresu
1. Ustaw właściwość zaokrąglonych rogów na True.
1. Zapisz zmodyfikowaną prezentację.

Poniżej podano przykładowy kod.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów przy zachowaniu nieprzezroczystej krawędzi?**

Tak. Przezroczystość wypełnienia i obramowanie są konfigurowane oddzielnie. Jest to przydatne do poprawy czytelności siatki i danych w gęstych wizualizacjach.

**Jak radzić sobie z etykietami danych, gdy się nakładają?**

Zredukuj rozmiar czcionki, wyłącz nieistotne elementy etykiet (np. kategorie), ustaw przesunięcie/pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub zmień format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe do serii?**

Tak. Zazwyczaj dostępne są zarówno wypełnienia jednolite, jak i gradientowe/wzorcowe. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które zmniejszają kontrast względem siatki i tekstu.