---
title: Dostosowanie legend wykresów w prezentacjach przy użyciu JavaScript
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
description: "Dostosuj legendy wykresów przy użyciu JavaScript i Aspose.Slides dla Node.js, aby zoptymalizować prezentacje PowerPoint dzięki dopasowanemu formatowaniu legend."
---
## **Przegląd**

Aspose.Slides udostępnia opcje dostosowywania legend wykresów w prezentacjach PowerPoint. Ten artykuł pokazuje, jak ustawić pozycję i rozmiar legendy, określić rozmiar czcionki całej legendy oraz zastosować formatowanie dla pojedynczego elementu legendy.

Omawia także kilka powiązanych zachowań w sekcji FAQ, w tym użycie trybu bez nakładania, aby obszar wykresu zostawił miejsce na legendę, umożliwienie długim etykietom legendy zawijania lub używania znaków nowej linii oraz pozwolenie legendzie na dziedziczenie formatowania z motywu prezentacji, gdy nie zostaną zastosowane jawne ustawienia tekstu i wypełnienia.

## **Pozycjonowanie legendy**

Aby ustawić właściwości legendy, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Uzyskaj odniesienie do slajdu.
- Dodaj wykres do slajdu.
- Ustaw właściwości legendy.
- Zapisz prezentację jako plik PPTX.

W poniższym przykładzie ustawiliśmy pozycję i rozmiar legendy wykresu.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    // Uzyskaj odniesienie do slajdu
    var slide = pres.getSlides().get_Item(0);
    // Dodaj wykres słupkowy grupowany na slajdzie
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Ustaw właściwości legendy
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Zapisz prezentację na dysku
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw rozmiar czcionki legendy**

Aspose.Slides for Node.js via Java umożliwia deweloperom ustawienie rozmiaru czcionki legendy. Wykonaj poniższe kroki:

- Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ustaw rozmiar czcionki pojedynczego wpisu legendy**

Aspose.Slides for Node.js via Java umożliwia deweloperom ustawienie rozmiaru czcionki pojedynczych wpisów legendy. Wykonaj poniższe kroki:

- Zainicjuj klasę [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation).
- Utwórz domyślny wykres.
- Uzyskaj dostęp do wpisu legendy.
- Ustaw rozmiar czcionki.
- Ustaw minimalną wartość osi.
- Ustaw maksymalną wartość osi.
- Zapisz prezentację na dysku.

```javascript
// Utwórz instancję klasy Presentation
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var tf = chart.getLegend().getEntries().get_Item(1).getTextFormat();
    tf.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    tf.getPortionFormat().setFontHeight(20);
    tf.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    tf.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tf.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Czy mogę włączyć legendę, aby wykres automatycznie przydzielał dla niej miejsce zamiast nakładać ją?**

Tak. Użyj trybu bez nakładania ([setOverlay(false)](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/legend/setoverlay/)); w takim przypadku obszar wykresu zostanie zmniejszony, aby pomieścić legendę.

**Czy mogę tworzyć wielolinijkowe etykiety legendy?**

Tak. Długie etykiety są automatycznie zawijane, gdy brakuje miejsca; wymuszone podziały wierszy są obsługiwane za pomocą znaków nowej linii w nazwie serii.

**Jak sprawić, aby legenda korzystała ze schematu kolorów motywu prezentacji?**

Nie ustawiaj jawnych kolorów, wypełnień ani czcionek dla legendy ani jej tekstu. Wtedy będą one dziedziczone z motywu i zostaną prawidłowo zaktualizowane po zmianie schematu.