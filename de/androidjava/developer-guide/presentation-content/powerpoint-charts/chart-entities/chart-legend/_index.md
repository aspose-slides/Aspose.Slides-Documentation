---
title: Diagrammlegenden in Präsentationen auf Android anpassen
linktitle: Diagrammlegende
type: docs
url: /de/androidjava/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Android via Java an, um PowerPoint-Präsentationen mit individuell gestalteter Legendenformatierung zu optimieren."
---

## **Legendenpositionierung**
Um die Legenden‑Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Holen Sie die Referenz der Folie.
- Fügen Sie der Folie ein Diagramm hinzu.
- Setzen Sie die Eigenschaften der Legende.
- Schreiben Sie die Präsentation als PPTX‑Datei.

Im nachstehenden Beispiel haben wir die Position und Größe der Diagramm‑Legende festgelegt.
```java
// Erstelle eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
try {
    // Hole die Referenz der Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Füge ein gruppiertes Säulendiagramm zur Folie hinzu
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Legenden-Eigenschaften festlegen
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    
    // Schreibe die Präsentation auf die Festplatte
    pres.save("Legend_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Schriftgröße einer Legende festlegen**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Festlegen der Schriftgröße der Legende. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Erstellen Sie das Standard‑Diagramm.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den Minimalwert der Achse.
- Setzen Sie den Maximalwert der Achse.
- Schreiben Sie die Präsentation auf die Festplatte.
```java
// Erstelle eine Instanz der Presentation-Klasse
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


## **Schriftgröße einer einzelnen Legende festlegen**
Aspose.Slides für Android via Java ermöglicht Entwicklern das Festlegen der Schriftgröße einzelner Legendeinträge. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation).
- Erstellen Sie das Standard‑Diagramm.
- Zugriff auf den Legendeintrag.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den Minimalwert der Achse.
- Setzen Sie den Maximalwert der Achse.
- Schreiben Sie die Präsentation auf die Festplatte.
```java
// Erstelle eine Instanz der Presentation-Klasse
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

**Kann ich die Legende aktivieren, damit das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([setOverlay(false)](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legend/#setOverlay-boolean-)); in diesem Fall verkleinert sich der Zeichenbereich, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbezeichnungen erstellen?**

Ja. Lange Bezeichnungen werden automatisch umgebrochen, wenn nicht genug Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruch‑Zeichen im Seriennamen unterstützt.

**Wie kann ich die Legende an das Farbschema des Präsentationsthemas anpassen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie erben dann vom Theme und werden bei einer Design‑Änderung korrekt aktualisiert.