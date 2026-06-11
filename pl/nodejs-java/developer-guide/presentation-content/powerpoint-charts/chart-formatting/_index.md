---
title: Formatowanie wykresów prezentacji w JavaScript
linktitle: Formatowanie wykresu
type: docs
weight: 60
url: /pl/nodejs-java/chart-formatting/
keywords:
- formatowanie wykresu
- formatowanie wykresu
- element wykresu
- właściwości wykresu
- ustawienia wykresu
- opcje wykresu
- właściwości czcionki
- zaokrąglone obramowanie
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Poznaj formatowanie wykresów w Aspose.Slides dla Node.js w JavaScript i podnieś swoją prezentację PowerPoint dzięki profesjonalnemu, przyciągającemu uwagę stylowi."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak formatować wykresy w prezentacjach PowerPoint przy użyciu Aspose.Slides. Pokazuje, jak dostosować kluczowe elementy wykresu, takie jak osie, linie siatki, tytuły, legendy, obszar wykresu i wypełnienia ścian, aby poprawić wygląd i czytelność danych wykresu.

Demonstruje również, jak ustawić właściwości czcionki dla tekstu wykresu, zastosować wstępnie zdefiniowane i niestandardowe formaty numeryczne do danych wykresu oraz włączyć zaokrąglone rogi dla obszaru wykresu. Razem te przykłady pokazują, jak kontrolować zarówno styl wizualny, jak i prezentację danych wykresu w prezentacji.

## **Formatowanie elementów wykresu**

Aspose.Slides for Node.js via Java umożliwia programistom dodawanie własnych wykresów do slajdów od podstaw. Ten artykuł wyjaśnia, jak formatować różne elementy wykresu, w tym oś kategorii i oś wartości.

Aspose.Slides for Node.js via Java zapewnia prosty interfejs API do zarządzania różnymi elementami wykresu i formatowania ich przy użyciu własnych wartości:

1. Utwórz instancję klasy [**Presentation**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do slajdu po jego indeksie.
1. Dodaj wykres z danymi domyślnymi oraz wybranym typem (w tym przykładzie użyjemy ChartType.LineWithMarkers).
1. Uzyskaj dostęp do osi wartości wykresu i ustaw następujące właściwości:
   1. Ustawienie **Formatu linii** dla głównych linii siatki osi wartości
   1. Ustawienie **Formatu linii** dla pobocznych linii siatki osi wartości
   1. Ustawienie **Formatu liczby** dla osi wartości
   1. Ustawienie **Jednostek Min, Max, Główne i Poboczne** dla osi wartości
   1. Ustawienie **Właściwości tekstu** dla danych osi wartości
   1. Ustawienie **Tytułu** dla osi wartości
   1. Ustawienie **Formatu linii** dla osi wartości
1. Uzyskaj dostęp do osi kategorii wykresu i ustaw następujące właściwości:
   1. Ustawienie **Formatu linii** dla głównych linii siatki osi kategorii
   1. Ustawienie **Formatu linii** dla pobocznych linii siatki osi kategorii
   1. Ustawienie **Właściwości tekstu** dla danych osi kategorii
   1. Ustawienie **Tytułu** dla osi kategorii
   1. Ustawienie **Pozycjonowania etykiet** dla osi kategorii
   1. Ustawienie **Kąta obrotu** dla etykiet osi kategorii
1. Uzyskaj dostęp do legendy wykresu i ustaw **Właściwości tekstu** dla niej
1. Ustaw wyświetlanie legend wykresu bez nakładania się na wykres
1. Uzyskaj dostęp do **Drugiej osi wartości** wykresu i ustaw następujące właściwości:
   1. Włącz **Drugą oś wartości**
   1. Ustawienie **Formatu linii** dla drugiej osi wartości
   1. Ustawienie **Formatu liczby** dla drugiej osi wartości
   1. Ustawienie **Jednostek Min, Max, Główne i Poboczne** dla drugiej osi wartości
1. Dodaj pierwszą serię wykresu na drugiej osi wartości
1. Ustaw kolor wypełnienia tylnej ściany wykresu
1. Ustaw kolor wypełnienia obszaru rysunku wykresu
1. Zapisz zmodyfikowaną prezentację do pliku PPTX

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Uzyskiwanie pierwszego slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodawanie przykładowego wykresu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);
    // Ustawianie tytułu wykresu
    chart.hasTitle();
    chart.getChartTitle().addTextFrameForOverriding("");
    var chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ustawianie formatu głównych linii siatki dla osi wartości
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Ustawianie formatu pobocznych linii siatki dla osi wartości
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Ustawianie formatu liczbowego osi wartości
    chart.getAxes().getVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");
    // Ustawianie maksymalnych i minimalnych wartości wykresu
    chart.getAxes().getVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getVerticalAxis().setMaxValue(15.0);
    chart.getAxes().getVerticalAxis().setMinValue(-2.0);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);
    // Ustawianie właściwości tekstu osi wartości
    var txtVal = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    txtVal.setFontBold(aspose.slides.NullableBool.True);
    txtVal.setFontHeight(16);
    txtVal.setFontItalic(aspose.slides.NullableBool.True);
    txtVal.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtVal.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkGreen));
    txtVal.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Ustawianie tytułu osi wartości
    chart.getAxes().getVerticalAxis().hasTitle();
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    var valtitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valtitle.setText("Primary Axis");
    valtitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valtitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valtitle.getPortionFormat().setFontHeight(20);
    valtitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    valtitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ustawianie formatu głównych linii siatki dla osi kategorii
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    // Ustawianie formatu pobocznych linii siatki dla osi kategorii
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);
    // Ustawianie właściwości tekstu osi kategorii
    var txtCat = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    txtCat.setFontBold(aspose.slides.NullableBool.True);
    txtCat.setFontHeight(16);
    txtCat.setFontItalic(aspose.slides.NullableBool.True);
    txtCat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtCat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    txtCat.setLatinFont(new aspose.slides.FontData("Arial"));
    // Ustawianie tytułu osi kategorii
    chart.getAxes().getHorizontalAxis().hasTitle();
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");
    var catTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    catTitle.setText("Sample Category");
    catTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    catTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    catTitle.getPortionFormat().setFontHeight(20);
    catTitle.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    catTitle.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Ustawianie pozycji etykiet osi kategorii
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    // Ustawianie kąta obrotu etykiet osi kategorii
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);
    // Ustawianie właściwości tekstu legendy
    var txtleg = chart.getLegend().getTextFormat().getPortionFormat();
    txtleg.setFontBold(aspose.slides.NullableBool.True);
    txtleg.setFontHeight(16);
    txtleg.setFontItalic(aspose.slides.NullableBool.True);
    txtleg.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    txtleg.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.DarkRed));
    // Ustaw wyświetlanie legend wykresu bez nakładania się na wykres
    chart.getLegend().setOverlay(true);
    // chart.ChartData.Series[0].PlotOnSecondAxis=true;
    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(true);
    // Ustawianie drugiej osi wartości
    chart.getAxes().getSecondaryVerticalAxis().isVisible();
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(aspose.slides.LineStyle.ThickBetweenThin);
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20);
    // Ustawianie formatu liczbowego drugiej osi wartości
    chart.getAxes().getSecondaryVerticalAxis().isNumberFormatLinkedToSource();
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Hundreds);
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%");
    // Ustawianie maksymalnych i minimalnych wartości wykresu
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMajorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMaxValue();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinorUnit();
    chart.getAxes().getSecondaryVerticalAxis().isAutomaticMinValue();
    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5.0);
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0);
    // Ustawianie koloru tylnej ściany wykresu
    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Ustawianie koloru obszaru rysunku
    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", aspose.slides.PresetColor.LightCyan));
    // Zapisz prezentację
    pres.save("FormattedChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustawienia właściwości czcionki dla wykresu**

Aspose.Slides for Node.js via Java zapewnia obsługę ustawiania właściwości czcionki dla wykresu. Postępuj zgodnie z poniższymi krokami, aby ustawić właściwości czcionki dla wykresu.

- Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/) .
- Dodaj wykres na slajdzie.
- Ustaw wysokość czcionki.
- Zapisz zmodyfikowaną prezentację.

Poniżej znajduje się przykładowy kod.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    pres.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw format liczbowy**

Aspose.Slides for Node.js via Java zapewnia prosty interfejs API do zarządzania formatem danych wykresu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
1. Uzyskaj odniesienie do slajdu po jego indeksie.
1. Dodaj wykres z danymi domyślnymi oraz wybranym typem (w tym przykładzie użyto **ChartType.ClusteredColumn**).
1. Ustaw wstępnie zdefiniowany format liczby z dostępnych wartości.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw format liczby danych wykresu.
1. Zapisz prezentację.
1. Ustaw niestandardowy format liczby.
1. Przejdź przez komórki danych wykresu w każdej serii i ustaw inny format liczby danych wykresu.
1. Zapisz prezentację.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Uzyskaj dostęp do pierwszego slajdu prezentacji
    var slide = pres.getSlides().get_Item(0);
    // Dodawanie domyślnego wykresu słupkowego grupowanego
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    // Uzyskiwanie kolekcji serii wykresu
    var series = chart.getChartData().getSeries();
    // Przeglądanie każdej serii wykresu
    for (var i = 0; i < series.size(); i++) {
        var ser = series.get_Item(i);
        // Przeglądanie każdej komórki danych w serii
        for (var j = 0; j < ser.getDataPoints().size(); j++) {
            var cell = ser.getDataPoints().get_Item(j);
            // Ustawianie formatu liczbowego
            cell.getValue().getAsCell().setPresetNumberFormat(java.newByte(10));// 0.00%
        }
    }
    // Zapisywanie prezentacji
    pres.save("PresetNumberFormat.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Poniżej podano możliwe wstępnie zdefiniowane wartości formatu liczby wraz z ich indeksami:

|**0**|General|
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
|**47**mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Ustaw zaokrąglone krawędzie obszaru wykresu**

Aspose.Slides for Node.js via Java zapewnia obsługę ustawiania obszaru wykresu. Metody [**hasRoundedCorners**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#hasRoundedCorners--) i [**setRoundedCorners**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart#setRoundedCorners-boolean-) zostały dodane do klasy [Chart](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Chart).

1. Utwórz obiekt klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation) .
1. Dodaj wykres na slajdzie.
1. Ustaw typ wypełnienia i kolor wypełnienia wykresu
1. Ustaw właściwość zaokrąglonych rogów na **True**.
1. Zapisz zmodyfikowaną prezentację.

Poniżej znajduje się przykładowy kod. 

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().setStyle(aspose.slides.LineStyle.Single);
    chart.setRoundedCorners(true);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę ustawić półprzezroczyste wypełnienia dla kolumn/obszarów, zachowując nieprzezroczyste obramowanie?**

Tak. Przezroczystość wypełnienia i obramowanie są konfigurowane oddzielnie. Jest to przydatne przy poprawianiu czytelności siatki i danych w gęstych wizualizacjach.

**Jak radzić sobie z etykietami danych, gdy nachodzą na siebie?**

Zmniejsz rozmiar czcionki, wyłącz nieistotne elementy etykiet (na przykład kategorie), ustaw przesunięcie/pozycję etykiety, wyświetlaj etykiety tylko dla wybranych punktów w razie potrzeby lub przełącz format na „wartość + legenda”.

**Czy mogę zastosować wypełnienia gradientowe lub wzorcowe dla serii?**

Tak. Zarówno wypełnienia jednorodne, jak i gradientowe/wzorcowe są zazwyczaj dostępne. W praktyce używaj gradientów oszczędnie i unikaj kombinacji, które zmniejszają kontrast względem siatki i tekstu.