---
title: Diagramme aus Präsentationen in Java exportieren
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
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für Java exportieren, PPT- und PPTX-Formate unterstützen und das Reporting in jeden Workflow optimieren."
---

## **Diagrammbild abrufen**
Aspose.Slides for Java bietet Unterstützung zum Extrahieren eines Bildes eines bestimmten Diagramms. Unten ist ein Beispiel angegeben.
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

**Kann ich ein Diagramm als Vektor (SVG) statt eines Rasterbilds exportieren?**

Ja. Ein Diagramm ist eine Form, und dessen Inhalte können mit der [shape-to-SVG saving method](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die image-rendering Überladungen, die Ihnen erlauben, Größe oder Skalierung anzugeben – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriften in Beschriftungen und Legende nach dem Export falsch aussehen?**

[Laden Sie die erforderlichen Schriften](/slides/de/java/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/java/com.aspose.slides/fontsloader/), damit das Diagrammrendering Metriken und Textdarstellung beibehält.

**Berücksichtigt der Export das PowerPoint-Thema, Formatvorlagen und Effekte?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Themen, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich verfügbare Rendering/Export‑Fähigkeiten über Diagrammbilder hinaus?**

Siehe die [API](https://reference.aspose.com/slides/java/com.aspose.slides/)/[documentation](/slides/de/java/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/java/convert-powerpoint-to-pdf/), [SVG](/slides/de/java/render-a-slide-as-an-svg-image/), [XPS](/slides/de/java/convert-powerpoint-to-xps/), [HTML](/slides/de/java/convert-powerpoint-to-html/), etc.) und zugehörige Rendering‑Optionen.