---
title: Trendlinie
type: docs
url: /de/nodejs-java/trend-line/
---

## **Trendlinie hinzufügen**

Aspose.Slides für Node.js über Java bietet eine einfache API zum Verwalten verschiedener Diagramm‑Trendlinien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse.
1. Holen Sie sich die Referenz einer Folie anhand ihres Index.
1. Fügen Sie ein Diagramm mit Standarddaten und einem gewünschten Typ hinzu (in diesem Beispiel wird ChartType.ClusteredColumn verwendet).
1. Exponential‑Trendlinie für Diagramm‑Reihe 1 hinzufügen.
1. Lineare Trendlinie für Diagramm‑Reihe 1 hinzufügen.
1. Logarithmische Trendlinie für Diagramm‑Reihe 2 hinzufügen.
1. Gleitender‑Durchschnitt‑Trendlinie für Diagramm‑Reihe 2 hinzufügen.
1. Polynomial‑Trendlinie für Diagramm‑Reihe 3 hinzufügen.
1. Power‑Trendlinie für Diagramm‑Reihe 3 hinzufügen.
1. Schreiben Sie die geänderte Präsentation in eine PPTX‑Datei.

Der folgende Code wird verwendet, um ein Diagramm mit Trendlinien zu erstellen.
```javascript
// Eine Instanz der Presentation-Klasse erstellen
var pres = new aspose.slides.Presentation();
try {
    // Erstelle ein gruppiertes Säulendiagramm
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 400);
    // Exponentielle Trendlinie für Diagrammreihe 1 hinzufügen
    var tredLinep = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Exponential);
    tredLinep.setDisplayEquation(false);
    tredLinep.setDisplayRSquaredValue(false);
    // Lineare Trendlinie für Diagrammreihe 1 hinzufügen
    var tredLineLin = chart.getChartData().getSeries().get_Item(0).getTrendLines().add(aspose.slides.TrendlineType.Linear);
    tredLineLin.setTrendlineType(aspose.slides.TrendlineType.Linear);
    tredLineLin.getFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    tredLineLin.getFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Logarithmische Trendlinie für Diagrammreihe 2 hinzufügen
    var tredLineLog = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.setTrendlineType(aspose.slides.TrendlineType.Logarithmic);
    tredLineLog.addTextFrameForOverriding("New log trend line");
    // Gleitender Durchschnitt Trendlinie für Diagrammreihe 2 hinzufügen
    var tredLineMovAvg = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setTrendlineType(aspose.slides.TrendlineType.MovingAverage);
    tredLineMovAvg.setPeriod(3);
    tredLineMovAvg.setTrendlineName("New TrendLine Name");
    // Polynomialtrendlinie für Diagrammreihe 3 hinzufügen
    var tredLinePol = chart.getChartData().getSeries().get_Item(2).getTrendLines().add(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setTrendlineType(aspose.slides.TrendlineType.Polynomial);
    tredLinePol.setForward(1);
    tredLinePol.setOrder(3);
    // Potenztrendlinie für Diagrammreihe 3 hinzufügen
    var tredLinePower = chart.getChartData().getSeries().get_Item(1).getTrendLines().add(aspose.slides.TrendlineType.Power);
    tredLinePower.setTrendlineType(aspose.slides.TrendlineType.Power);
    tredLinePower.setBackward(1);
    // Präsentation speichern
    pres.save("ChartTrendLines_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Benutzerdefinierte Linie hinzufügen**

Aspose.Slides für Node.js über Java bietet eine einfache API zum Hinzufügen benutzerdefinierter Linien in ein Diagramm. Um eine einfache gerade Linie zu einer ausgewählten Folie der Präsentation hinzuzufügen, führen Sie die folgenden Schritte aus:

- Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)-Klasse
- Holen Sie sich die Referenz einer Folie über ihren Index
- Erstellen Sie ein neues Diagramm mit der AddChart‑Methode des Shapes‑Objekts
- Fügen Sie mit der AddAutoShape‑Methode des Shapes‑Objekts eine AutoShape vom Typ Linie hinzu
- Setzen Sie die Farbe der Formlinien.
- Schreiben Sie die geänderte Präsentation als PPTX‑Datei

Der folgende Code wird verwendet, um ein Diagramm mit benutzerdefinierten Linien zu erstellen.
```javascript
// Eine Instanz der Presentation-Klasse erstellen
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    var shape = chart.getUserShapes().getShapes().addAutoShape(aspose.slides.ShapeType.Line, 0, chart.getHeight() / 2, chart.getWidth(), 0);
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    pres.save("Presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Was bedeuten „forward“ und „backward“ bei einer Trendlinie?**

Sie sind die Längen der Trendlinie, die nach vorne bzw. nach hinten projiziert werden: Bei Streu‑ (XY‑)Diagrammen in Achseneinheiten; bei Nicht‑Streu‑Diagrammen in Anzahl der Kategorien. Nur nicht‑negative Werte sind zulässig.

**Wird die Trendlinie beim Exportieren der Präsentation nach PDF oder SVG bzw. beim Rendern einer Folie zu einem Bild beibehalten?**

Ja. Aspose.Slides konvertiert Präsentationen in [PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/)/[SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/) und rendert Diagramme zu Bildern; Trendlinien bleiben dabei als Teil des Diagramms erhalten. Es gibt zudem eine Methode, um ein Bild des Diagramms selbst zu [exportieren](/slides/de/nodejs-java/create-shape-thumbnails/).