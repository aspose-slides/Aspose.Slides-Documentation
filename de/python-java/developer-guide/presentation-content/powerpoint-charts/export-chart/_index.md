---
title: Exportieren von Präsentationsdiagrammen in Python via Java
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/python-java/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für Python via Java exportieren, PPT- und PPTX-Formate unterstützen und das Reporting in jeden Workflow optimieren."
---
## **Übersicht**

Aspose.Slides ermöglicht den Export eines Diagramms aus einer Präsentation als Bild. Dieser Artikel zeigt, wie man ein Bild aus einem Diagramm erhält und speichert, was nützlich ist, wenn man Diagrammvisualisierungen außerhalb einer PowerPoint‑Präsentation wiederverwenden muss.

Zusätzlich zum grundlegenden Bildexport‑Workflow behandelt der Artikel häufige exportbezogene Fragen, einschließlich des Speicherns von Diagramminhalten als SVG, der Steuerung der Ausgabengröße über Renderoptionen, dem Laden von Schriften zur Wahrung von Beschriftungs‑ und Legenden‑Darstellung sowie dem Beibehalten der ursprünglichen Präsentationsformatierung wie Themen, Stile, Füllungen und Effekte beim Rendern.

## **Diagrammbild erhalten**
Aspose.Slides für Python via Java unterstützt das Extrahieren eines Bildes eines bestimmten Diagramms. Das folgende Beispiel zeigt, wie das funktioniert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, ImageFormat, Presentation

presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart_image = chart.getImage()
    try:
        chart_image.save("image.jpg", ImageFormat.Jpeg)
    finally:
        chart_image.dispose()
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) anstelle eines Rasterbildes exportieren?**

Ja. Ein Diagramm ist eine Form, und sein Inhalt kann mit der [Shape‑to‑SVG‑Speichermethode](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#writeAsSvgToBytes) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bildrender‑Überladungen, mit denen Sie Größe oder Maßstab angeben können – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Maßstab.

**Was soll ich tun, wenn Schriften in Beschriftungen und der Legende nach dem Export falsch aussehen?**

[Laden Sie die erforderlichen Schriften](/slides/de/python-java/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/de/python-java/aspose.slides/fontsloader/) damit die Diagrammrendition Metriken und das Textaussehen beibehält.

**Berücksichtigt der Export das PowerPoint‑Thema, die Stile und Effekte?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Themen, Stile, Füllungen, Effekte), sodass das Erscheinungsbild des Diagramms erhalten bleibt.

**Wo finde ich verfügbare Rendering‑/Export‑Funktionen über Diagrammbilder hinaus?**

Siehe die [API](https://reference.aspose.com/slides/de/python-java/aspose.slides/)/[Dokumentation](/slides/de/python-java/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/python-java/convert-powerpoint-to-pdf/), [SVG](/slides/de/python-java/render-a-slide-as-an-svg-image/), [XPS](/slides/de/python-java/convert-powerpoint-to-xps/), [HTML](/slides/de/python-java/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.