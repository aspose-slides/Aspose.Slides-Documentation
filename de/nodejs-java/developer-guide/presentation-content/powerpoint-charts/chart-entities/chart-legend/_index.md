---
title: Diagrammlegende
type: docs
url: /de/nodejs-java/chart-legend/
---

## **Legendenpositionierung**

Um die Legenden‑Eigenschaften festzulegen, folgen Sie bitte den untenstehenden Schritten:

- Erzeugen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Holen Sie eine Referenz zur Folie.
- Fügen Sie ein Diagramm zur Folie hinzu.
- Setzen Sie die Eigenschaften der Legende.
- Schreiben Sie die Präsentation als PPTX-Datei.

Im nachfolgenden Beispiel haben wir die Position und Größe der Diagrammlegende festgelegt.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
var pres = new aspose.slides.Presentation();
try {
    // Hole Referenz der Folie
    var slide = pres.getSlides().get_Item(0);
    // Füge ein gruppiertes Säulendiagramm auf der Folie hinzu
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);
    // Setze Legenden-Eigenschaften
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());
    // Schreibe die Präsentation auf die Festplatte
    pres.save("Legend_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Schriftgröße der Legende festlegen**

Aspose.Slides für Node.js über Java ermöglicht es Entwicklern, die Schriftgröße der Legende festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Setzen Sie die Schriftgröße.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
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


## **Schriftgröße einzelner Legendeinträge festlegen**

Aspose.Slides für Node.js über Java ermöglicht es Entwicklern, die Schriftgröße einzelner Legendeinträge festzulegen. Bitte folgen Sie den untenstehenden Schritten:

- Instanziieren Sie die Klasse [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation).
- Erstellen Sie das Standarddiagramm.
- Zugriff auf den Legendeintrag.
- Setzen Sie die Schriftgröße.
- Setzen Sie den minimalen Achsenwert.
- Setzen Sie den maximalen Achsenwert.
- Schreiben Sie die Präsentation auf die Festplatte.
```javascript
// Erstelle eine Instanz der Presentation-Klasse
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

**Kann ich die Legende aktivieren, sodass das Diagramm automatisch Platz dafür reserviert, anstatt sie zu überlagern?**

Ja. Verwenden Sie den Nicht‑Overlay‑Modus ([setOverlay(false)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/)); in diesem Fall verkleinert sich der Plot‑Bereich, um die Legende aufzunehmen.

**Kann ich mehrzeilige Legendenbeschriftungen erstellen?**

Ja. Lange Beschriftungen werden automatisch umgebrochen, wenn nicht genug Platz vorhanden ist; erzwungene Zeilenumbrüche werden über Zeilenumbruch‑Zeichen im Seriennamen unterstützt.

**Wie kann ich die Legende an das Farbschema des Präsentationsthemas anpassen?**

Setzen Sie keine expliziten Farben/Füllungen/Schriften für die Legende oder deren Text. Sie erben dann vom Thema und werden bei einer Design‑Änderung korrekt aktualisiert.