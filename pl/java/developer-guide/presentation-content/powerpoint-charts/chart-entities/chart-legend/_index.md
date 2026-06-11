---
title: Dostosuj legendy wykresów w prezentacjach przy użyciu Java
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
description: "Dostosuj legendy wykresów przy użyciu Aspose.Slides dla Java, aby zoptymalizować prezentacje PowerPoint dzięki dopasowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides udostępnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić pozycję i rozmiar legendy, określić rozmiar czcionki dla całej legendy oraz zastosować formatowanie do pojedynczego wpisu legendy.

Opisuje również kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu zostawił miejsce na legendę, umożliwienie długim etykietom legendy zawijania lub używania znaków nowej linii oraz pozwolenie formatowaniu legendy na dziedziczenie z motywu prezentacji, gdy nie są ustawione explicite ustawienia tekstu i wypełnienia.

## **Pozycjonowanie legendy**
Aby ustawić właściwości legendy, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
- Uzyskaj referencję do slajdu.
- Dodaj wykres na slajdzie.
- Ustaw właściwości legendy.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy pozycję i rozmiar legendy wykresu.

```java
// Utwórz instancję klasy Presentation
Presentation pres = new Presentation();
try {
    // Pobierz referencję do slajdu
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Dodaj wykres słupkowy grupowany na slajdzie
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
Aspose.Slides for Java umożliwia programistom ustawienie rozmiaru czcionki legendy. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
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

## **Ustaw rozmiar czcionki pojedynczego wpisu legendy**
Aspose.Slides for Java umożliwia programistom ustawienie rozmiaru czcionki poszczególnych wpisów legendy. Postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation).
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

**Czy mogę włączyć legendę tak, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać ją?**

Tak. Użyj trybu bez nakładania ([setOverlay(false)](https://reference.aspose.com/slides/pl/java/com.aspose.slides/legend/#setOverlay-boolean-)); w takim przypadku obszar wykresu zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć etykiety legendy wielowierszowe?**

Tak. Długie etykiety są automatycznie zawijane, gdy brak wystarczającej przestrzeni; wymuszone łamanie wierszy jest obsługiwane za pomocą znaków nowej linii w nazwie serii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Nie ustawiaj explicite kolorów, wypełnień ani czcionek dla legendy ani jej tekstu. Wówczas będą one dziedziczyć z motywu i zostaną prawidłowo zaktualizowane po zmianie projektu.