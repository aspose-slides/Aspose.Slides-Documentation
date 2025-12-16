---
title: Diagramme aus Präsentationen auf Android exportieren
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/androidjava/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Diagramme aus Präsentationen mit Aspose.Slides für Android via Java exportieren, PPT- und PPTX-Formate unterstützen und das Reporting in jeden Arbeitsablauf optimieren."
---

## **Ein Diagrammbild abrufen**
Aspose.Slides für Android über Java bietet Unterstützung zum Extrahieren des Bildes eines bestimmten Diagramms. Unten ist ein Beispiel angegeben.
```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    IImage slideImage = chart.getImage();

    try {
          slideImage.save("image.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) statt als Rasterbild exportieren?**

Ja. Ein Diagramm ist eine Form, und dessen Inhalt kann mit der [shape-to-SVG saving method](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) nach SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bildrender‑Überladungen, die es ermöglichen, Größe oder Skalierung anzugeben – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriften in Beschriftungen und der Legende nach dem Export falsch aussehen?**

[Laden Sie die erforderlichen Schriften](/slides/de/androidjava/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fontsloader/), damit das Rendern des Diagramms Metriken und Textdarstellung beibehält.

**Berücksichtigt der Export das PowerPoint‑Design, die Formatvorlagen und Effekte?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Designs, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering‑/Exportmöglichkeiten über Diagrammbilder hinaus?**

Siehe die [API](https://reference.aspose.com/slides/androidjava/com.aspose.slides/)/[Dokumentation](/slides/de/androidjava/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/androidjava/convert-powerpoint-to-pdf/), [SVG](/slides/de/androidjava/render-a-slide-as-an-svg-image/), [XPS](/slides/de/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/de/androidjava/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.