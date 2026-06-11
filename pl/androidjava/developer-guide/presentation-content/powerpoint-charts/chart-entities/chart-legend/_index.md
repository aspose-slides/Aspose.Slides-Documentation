---
title: Dostosuj legendy wykresów w prezentacjach na Androidzie
linktitle: Legenda wykresu
type: docs
url: /pl/androidjava/chart-legend/
keywords:
- legenda wykresu
- pozycja legendy
- rozmiar czcionki
- PowerPoint
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Dostosuj legendy wykresów przy użyciu Aspose.Slides dla Androida w Javie, aby zoptymalizować prezentacje PowerPoint dzięki dopasowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides oferuje opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić pozycję i rozmiar legendy, ustawić rozmiar czcionki dla całej legendy oraz zastosować formatowanie do pojedynczego elementu legendy.

Opisuje również kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu zostawił miejsce dla legendy, umożliwienie zawijania długich etykiet legendy lub użycie podziałów wierszy oraz pozwolenie legendzie na dziedziczenie formatowania z motywu prezentacji, gdy nie zostaną określone explicit ustawienia tekstu i wypełnienia.

## **Pozycjonowanie legendy**
Aby ustawić właściwości legendy, wykonaj następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu.
- Dodaj wykres na slajdzie.
- Ustaw właściwości legendy.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy pozycję i rozmiar legendy wykresu.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Otrzymaj referencję do slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaj wykres kolumnowy grupowany na slajdzie
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Ustaw właściwości legendy
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Zapisz prezentację na dysku
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw rozmiar czcionki legendy**
Aspose.Slides for Android via Java umożliwia programistom ustawienie rozmiaru czcionki legendy. Proszę postępować zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);

    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ustaw rozmiar czcionki pojedynczego elementu legendy**
Aspose.Slides for Android via Java umożliwia programistom ustawienie rozmiaru czcionki pojedynczych wpisów legendy. Proszę postępować zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Uzyskaj dostęp do wpisu legendy.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IChartTextFormat tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    tf.getPortionFormat().setFontBold(NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    
    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Czy mogę włączyć legendę, aby wykres automatycznie przydzielał miejsce dla niej zamiast nakładać ją?**

Tak. Użyj trybu bez nakładania ([setOverlay(false)](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); w tym przypadku obszar rysunku zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć etykiety legendy wielowierszowe?**

Tak. Długie etykiety są automatycznie zawijane, gdy brak miejsca; wymuszone podziały wierszy są obsługiwane przy użyciu znaków nowej linii w nazwie serii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Nie ustawiaj jawnych kolorów, wypełnień ani czcionek dla legendy ani jej tekstu. Wtedy będą one dziedziczone z motywu i prawidłowo zaktualizują się po zmianie projektu.