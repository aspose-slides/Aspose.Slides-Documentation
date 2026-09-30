---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu JavaScript
linktitle: Legenda wykresu
type: docs
url: /pl/nodejs-java/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Dostosuj legendy wykresów przy użyciu Aspose.Slides dla Node.js via Java, aby zoptymalizować prezentacje PowerPoint za pomocą spersonalizowanego formatowania legendy."
---
## **Przegląd**

Aspose.Slides for Node.js via Java zapewnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak pozycjonować i zmieniać rozmiar legendy, ustawiać rozmiar czcionki dla całej legendy, formatować pojedynczy element legendy oraz ukrywać lub przywracać wybrane elementy.

FAQ obejmuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie etykiet wieloliniowych oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj metod legendy [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) i [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/), aby określić jej pozycję i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje wykres słupkowy grupowany z domyślnymi danymi na pierwszym slajdzie. Podzielenie żądanych przesunięć i wymiarów legendy przez szerokość i wysokość wykresu konwertuje je na wartości względne: legenda jest przesunięta o 50 punktów od lewego górnego rogu wykresu i ma rozmiar 100 × 100 punktów.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Wyraź pozycję i rozmiar legendy względem wykresu.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw rozmiar czcionki legendy**

Użyj metody legendy [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/), aby uzyskać dostęp do formatowania tekstu, oraz [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight), aby ustawić rozmiar czcionki w punktach.

Ten przykład tworzy wykres z domyślnymi danymi i ustawia tekst legendy na 20 punktów. Wyłącza także automatyczne granice dla osi pionowej i ustawia jej zakres od -5 do 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw rozmiar czcionki pojedynczego elementu legendy**

Użyj kolekcji zwracanej przez metodę legendy [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/), aby uzyskać formatowanie konkretnego elementu. Indeksy elementów zaczynają się od zera, więc indeks `1` odnosi się do drugiego elementu.

Ten przykład tworzy wykres słupkowy grupowany, którego domyślne dane zawierają co najmniej dwie serie. Formatuje drugi element legendy jako pogrubiony, kursywa i niebieski tekst o rozmiarze 20 punktów.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukryj pojedyncze elementy legendy**

Aby wykluczyć pomocniczą serię z legendy, zachowując jej dane widoczne, wywołaj [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) z wartością `true` za pośrednictwem [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). To ukrywa tylko wybrany element legendy; nie usuwa serii ani jej punktów danych. Natomiast wywołanie [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) z wartością `false` ukrywa całą legendę.

Przykład poniżej tworzy wykres słupkowy grupowany z wieloma seriami przy użyciu domyślnych danych. Ukrywa element legendy drugiej serii (indeks `1`) i zapisuje prezentację. Następnie przywraca element, wywołując [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) z `false`, i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Przywróć ten sam wpis bez zmiany danych wykresu.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Porównanie poniżej pokazuje ten sam wykres ze wszystkimi elementami legendy widocznymi oraz z ukrytym drugim elementem. Kolumny drugiej serii pozostają niezmienione.

![Porównanie wykresu ze wszystkimi elementami legendy widocznymi i z ukrytym drugim elementem legendy; wszystkie kolumny pozostają widoczne.](hide-legend-entry.png)

W wykresach kolumnowych, słupkowych i liniowych elementy legendy identyfikują serie. W wykresach kołowych identyfikują poszczególne punkty danych (wycinki), więc zamiast tego użyj [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) na wybranej wycince. Dokumentacja API opisuje tę metodę punktu danych dla typów wykresów `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` i `BarOfPie`. Nie zakładaj, że działa ona w wykresach pierścieniowych, które nie są wymienione na tej liście.

## **FAQ**

**Czy mogę sprawić, aby wykres rezerwował miejsce dla legendy zamiast nakładać ją na wykres?**

Tak. Wywołaj [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) z wartością `false`, aby zarezerwować miejsce dla legendy zamiast pozwolić jej nakładać się na obszar wykresu.

**Czy mogę tworzyć wieloliniowe etykiety legendy?**

Tak. Długie etykiety mogą się zawijać, gdy dostępna szerokość jest niewystarczająca. Możesz także używać znaków nowej linii w nazwach serii, aby wymusić podziały linii.

**Jak sprawić, aby legenda stosowała się do schematu kolorów motywu prezentacji?**

Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie z motywu. Jawne formatowanie zastępuje odpowiednie ustawienia motywu.