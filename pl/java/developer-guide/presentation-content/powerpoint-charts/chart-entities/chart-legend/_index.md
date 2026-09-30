---
title: Dostosowanie legend wykresów w prezentacjach przy użyciu Java
linktitle: Legenda wykresu
type: docs
url: /pl/java/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- Java
- Aspose.Slides
description: "Dostosuj legendy wykresów za pomocą Aspose.Slides dla Java, aby zoptymalizować prezentacje PowerPoint dzięki spersonalizowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides for Java oferuje opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić położenie i rozmiar legendy, ustawić rozmiar czcionki dla całej legendy, sformatować pojedynczy wpis legendy oraz ukryć lub przywrócić wybrane wpisy.

Sekcja FAQ opisuje powiązane zachowania, w tym rezerwowanie miejsca dla legendy, wyświetlanie etykiet wieloliniowych oraz dziedziczenie formatowania z motywu prezentacji.

## **Pozycjonowanie legendy**

Użyj metod legendy [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-) i [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) , aby określić jej położenie i rozmiar jako ułamki wymiarów wykresu.

Ten przykład tworzy prezentację i dodaje wykres kolumnowy grupowany z danymi domyślnymi do pierwszego slajdu. Podzielenie żądanych przesunięć i wymiarów legendy przez szerokość i wysokość wykresu przekształca je na wartości względne: legenda jest przesunięta o 50 punktów od lewego górnego rogu wykresu i ma rozmiar 100 × 100 punktów.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Wyraż pozycję i rozmiar legendy względem wykresu.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustawienie rozmiaru czcionki legendy**

Użyj legendy [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) , aby uzyskać dostęp do formatowania tekstu, i użyj [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) , aby ustawić rozmiar czcionki w punktach.

Ten przykład tworzy wykres z danymi domyślnymi i ustawia tekst legendy na 20 punktów. Wyłącza także automatyczne granice dla osi pionowej i ustawia jej zakres od -5 do 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustawienie rozmiaru czcionki pojedynczego wpisu legendy**

Użyj kolekcji zwróconej przez metodę legendy [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) , aby uzyskać dostęp do formatowania konkretnego wpisu. Indeksy wpisów są zerowe, więc indeks `1` odnosi się do drugiego wpisu.

Ten przykład tworzy wykres kolumnowy grupowany, którego domyślne dane zawierają co najmniej dwie serie. Formatuje drugi wpis legendy, używając pogrubionej, kursywnej i niebieskiej czcionki o rozmiarze 20 punktów.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ukrywanie pojedynczych wpisów legendy**

Aby wykluczyć pomocniczą serię z legendy, zachowując jednocześnie widoczność jej danych, wywołaj [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) z wartością `true` za pośrednictwem [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). To ukrywa tylko wybrany wpis legendy; nie usuwa serii ani jej punktów danych. Wywołanie [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) z wartością `false` ukrywa natomiast całą legendę.

Poniższy przykład tworzy wykres kolumnowy grupowany z wieloma seriami przy użyciu danych domyślnych. Ukrywa wpis legendy drugiej serii (indeks `1`) i zapisuje prezentację. Następnie przywraca wpis, wywołując [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) z wartością `false`, i zapisuje drugą kopię. Kolumny pozostają widoczne w obu plikach.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Przywróć ten sam wpis bez zmiany danych wykresu.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Poniższe porównanie pokazuje ten sam wykres ze wszystkimi wpisami legendy widocznymi oraz z ukrytym drugim wpisem w legendzie. Kolumny drugiej serii pozostają niezmienione.

![Porównanie wykresu ze wszystkimi wpisami legendy widocznymi oraz z ukrytym drugim wpisem w legendzie; wszystkie kolumny pozostają widoczne.](hide-legend-entry.png)

W wykresach słupkowych, kolumnowych i liniowych wpisy legendy identyfikują serie. W wykresach kołowych identyfikują pojedyncze punkty danych (kawałki), więc użyj [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) na wybranym kawałku. Dokumentacja API opisuje tę metodę punktu danych dla typów wykresów `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` oraz `BarOfPie`. Nie zakładaj, że dotyczy ona wykresów pierścieniowych, które nie są wymienione na tej liście.

## **FAQ**

**Czy mogę sprawić, aby wykres rezerwował miejsce na legendę zamiast ją nakładać?**

Tak. Wywołaj [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) z wartością `false`, aby zarezerwować miejsce na legendę zamiast pozwalać jej nachodzić na obszar wykresu.

**Czy mogę tworzyć wieloliniowe etykiety legendy?**

Tak. Długie etykiety mogą się zawijać, gdy dostępna szerokość jest niewystarczająca. Można także używać znaków nowej linii w nazwach serii, aby wymusić podziały linii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Pozostaw kolory, wypełnienia i czcionki legendy nieustawione, aby mogła dziedziczyć formatowanie z motywu. Jawne formatowanie nadpisuje odpowiadające ustawienia motywu.