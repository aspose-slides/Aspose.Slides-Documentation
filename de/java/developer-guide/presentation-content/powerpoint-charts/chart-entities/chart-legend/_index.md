---
title: Diagrammlegenden in Präsentationen mit Java anpassen
linktitle: Diagrammlegende
type: docs
url: /de/java/chart-legend/
keywords:
- Diagrammlegende
- Legendenposition
- Schriftgröße
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Passen Sie Diagrammlegenden mit Aspose.Slides für Java an, um PowerPoint-Präsentationen mit individuell formatierter Legende zu optimieren."
---

## **Legendenpositionierung**
Um die Eigenschaften der Legende festzulegen, folgen Sie bitte den unten genannten Schritten:

- Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Holen Sie die Referenz der Folie.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Legen Sie die Eigenschaften der Legende fest.
- Speichern Sie die Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir die Position und Größe der Diagrammlegende festgelegt.
```java
// Erstelle eine Instanz der Klasse Presentation
Presentation pres = new Presentation();
try {
    // Hole die Referenz der Folie
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Füge ein gruppiertes Säulendiagramm zur Folie hinzu
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);
    
    // Setze Legenden-Eigenschaften
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
Aspose.Slides für Java ermöglicht Entwicklern das Festlegen der Schriftgröße der Legende. Bitte folgen Sie den unten genannten Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Speichern Sie die Präsentation auf dem Datenträger.
```java
// Erstelle eine Instanz der Klasse Presentation
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
Aspose.Slides für Java ermöglicht Entwicklern das Festlegen der Schriftgröße einzelner Legendeneinträge. Bitte folgen Sie den unten genannten Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Greifen Sie auf den Legenden-Eintrag zu.
- Legen Sie die Schriftgröße fest.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Speichern Sie die Präsentation auf dem Datenträger.
```java
// Erstelle eine Instanz der Klasse Presentation
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

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**  
Ja. Verwenden Sie den Nicht-Overlay-Modus ([setOverlay(false)](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-)); in diesem Fall verkleinert sich der Zeichenbereich, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**  
Ja. Lange Beschriftungen werden automatisch umgebrochen, wenn nicht genügend Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruchzeichen im Seriennamen unterstützt.

**Wie kann ich die Legende an das Farbdesign der Präsentationsvorlage anpassen?**  
Vergeben Sie keine expliziten Farben/Füllungen/Schriftarten für die Legende oder deren Text. Sie erben dann vom Thema und werden bei Änderungen des Designs korrekt aktualisiert.