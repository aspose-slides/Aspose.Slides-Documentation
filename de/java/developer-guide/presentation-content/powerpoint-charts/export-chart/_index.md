---
title: Export von Präsentationsdiagrammen in Java
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/java/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für Java exportieren, unterstützt PPT- und PPTX-Formate, und vereinfachen Sie das Reporting in jeden Workflow."
---

## **Diagrammbild abrufen**
Aspose.Slides für Java unterstützt das Extrahieren eines Bildes eines bestimmten Diagramms. Nachfolgend ein Beispiel.
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

Ja. Ein Diagramm ist ein Shape, und dessen Inhalt kann mithilfe der [shape-to-SVG saving method](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixel festlegen?**

Verwenden Sie die Bildrender‑Überladungen, die es ermöglichen, Größe oder Maßstab anzugeben – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Maßstab.

**Was soll ich tun, wenn Schriftarten in Beschriftungen und der Legende nach dem Export falsch dargestellt werden?**

[Load the required fonts](/slides/de/java/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/) damit die Diagrammrenderung Metriken und Textdarstellung beibehält.

**Wird beim Export das PowerPoint‑Design, die Formatvorlagen und Effekte berücksichtigt?**

Ja. Aspose.Slides’ Renderer folgt der Formatierung der Präsentation (Designs, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering‑/Exportmöglichkeiten neben Diagrammbildern?**

Siehe die [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[Dokumentation](/slides/de/java/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/java/convert-powerpoint-to-pdf/), [SVG](/slides/de/java/render-a-slide-as-an-svg-image/), [XPS](/slides/de/java/convert-powerpoint-to-xps/), [HTML](/slides/de/java/convert-powerpoint-to-html/), etc.) und zugehörige Rendering‑Optionen.