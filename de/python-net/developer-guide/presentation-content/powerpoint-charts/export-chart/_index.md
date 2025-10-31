---
title: Diagramme aus Präsentationen mit Python exportieren
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/python-net/export-chart/
keywords:
- diagramm
- diagramm zu bild
- diagramm als bild
- diagrammbild extrahieren
- PowerPoint
- OpenDocument
- präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für Python via .NET exportieren, unterstützt PPT, PPTX und ODP Formate, und Berichterstellung in jeden Arbeitsablauf integrieren."
---

## **Diagrammbild abrufen**
Aspose.Slides für Python via .NET bietet Unterstützung zum Extrahieren des Bildes eines bestimmten Diagramms. Das folgende Beispiel wird bereitgestellt.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation("test.pptx") as presentation:
	slide = presentation.slides[0]
	chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
	
	with chart.get_image() as image:
		image.save("image.png", slides.ImageFormat.PNG)
```

## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) statt als Rasterbild exportieren?**

Ja. Ein Diagramm ist ein Shape, und dessen Inhalt kann mithilfe der [Shape-zu-SVG-Speichermethode](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixel festlegen?**

Verwenden Sie die Überladungen zum Bildrendern, die die Angabe von Größe oder Skalierung ermöglichen – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriftarten in Beschriftungen und Legende nach dem Export falsch dargestellt werden?**

Die erforderlichen Schriftarten [laden](/slides/de/python-net/custom-font/) über den [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/), damit die Diagrammrenderung Metriken und Textdarstellung beibehält.

**Wird beim Export das PowerPoint-Design, die Stile und Effekte berücksichtigt?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Designs, Stile, Füllungen, Effekte), sodass das Erscheinungsbild des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering-/Exportfunktionen neben Diagrammbildern?**

Siehe den Exportbereich der [API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[Dokumentation](/slides/de/python-net/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), usw.) und zugehörige Rendering-Optionen.