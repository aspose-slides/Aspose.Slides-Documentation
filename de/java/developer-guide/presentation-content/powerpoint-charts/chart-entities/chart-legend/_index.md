---
title: Diagrammlegende
type: docs
url: /de/java/chart-legend/
---

## **Positionierung der Legende**
Um die Eigenschaften der Legende festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Holen Sie sich eine Referenz zur Folie.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im folgenden Beispiel haben wir die Position und Größe für die Diagrammlegende festgelegt.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Holen Sie sich eine Referenz zur Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Fügen Sie ein gruppiertes Säulendiagramm zur Folie hinzu
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Legen Sie die Eigenschaften der Legende fest
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Schreiben Sie die Präsentation auf die Festplatte
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Schriftgröße der Legende festlegen**
Aspose.Slides für Java ermöglicht Entwicklern, die Schriftgröße der Legende festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Schriftgröße fest.
- Legen Sie den minimalen Achsenwert fest.
- Legen Sie den maximalen Achsenwert fest.
- Schreiben Sie die Präsentation auf die Festplatte.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
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

## **Schriftgröße der einzelnen Legende festlegen**
Aspose.Slides für Java ermöglicht Entwicklern, die Schriftgröße einzelner Legendeinträge festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) Klasse.
- Erstellen Sie das Standarddiagramm.
- Greifen Sie auf den Legendeintrag zu.
- Legen Sie die Schriftgröße fest.
- Legen Sie den minimalen Achsenwert fest.
- Legen Sie den maximalen Achsenwert fest.
- Schreiben Sie die Präsentation auf die Festplatte.

```java
// Erstellen Sie eine Instanz der Presentation-Klasse
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