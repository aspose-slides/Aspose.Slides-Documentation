---
title: Diagramm exportieren
type: docs
weight: 90
url: /de/nodejs-java/export-chart/
---

## **Diagrammbild abrufen**
Aspose.Slides for Node.js via Java bietet Unterstützung zum Extrahieren des Bildes eines bestimmten Diagramms. Unten ist ein Beispiel angegeben. 
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var slideImage = chart.getImage();
    try {
        slideImage.save("image.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) statt als Rasterbild exportieren?**

Ja. Ein Diagramm ist eine Form, und dessen Inhalte können mit der [shape-to-SVG saving method](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/writeassvg/) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bildrender‑Überladungen, die die Angabe von Größe oder Skalierung ermöglichen – die Bibliothek unterstützt das Rendern von Objekten mit bestimmten Abmessungen/Skala.

**Was soll ich tun, wenn Schriftarten in Beschriftungen und der Legende nach dem Export falsch dargestellt werden?**

[Laden Sie die erforderlichen Schriftarten](/slides/de/nodejs-java/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontsloader/), damit das Diagramm‑Rendering Metriken und das Textaussehen beibehält.

**Berücksichtigt der Export das PowerPoint‑Design, die Formatvorlagen und Effekte?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Designs, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering‑/Exportmöglichkeiten neben Diagrammbildern?**

Siehe die [API](https://reference.aspose.com/slides/nodejs-java/aspose.slides/)/[Dokumentation](/slides/de/nodejs-java/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/nodejs-java/convert-powerpoint-to-pdf/), [SVG](/slides/de/nodejs-java/render-a-slide-as-an-svg-image/), [XPS](/slides/de/nodejs-java/convert-powerpoint-to-xps/), [HTML](/slides/de/nodejs-java/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.