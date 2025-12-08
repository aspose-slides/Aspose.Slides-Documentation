---
title: Exportieren von Präsentationsdiagrammen mit Python
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/python-net/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für Python via .NET exportieren, PPT-, PPTX- und ODP-Formate unterstützen und das Reporting in jeden Workflow optimieren."
---

## **Diagrammbild abrufen**
Aspose.Slides für Python via .NET bietet Unterstützung zum Extrahieren des Bildes eines bestimmten Diagramms. Nachfolgend ein Beispiel wird gezeigt.  
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

Ja. Ein Diagramm ist ein Shape, und dessen Inhalte können mithilfe der [shape-to-SVG saving method](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/write_as_svg/) nach SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bilddarstellungs‑Overloads, die die Angabe von Größe oder Skalierung ermöglichen – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriften in Beschriftungen und der Legende nach dem Export falsch aussehen?**

[Laden Sie die erforderlichen Schriften](/slides/de/python-net/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/), damit die Diagrammdarstellung Metriken und Textdarstellung beibehält.

**Wird beim Export das PowerPoint‑Design, die Formatvorlagen und Effekte berücksichtigt?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Designs, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering‑/Exportmöglichkeiten neben Diagrammbildern?**

Siehe den Export‑Abschnitt der [API](https://reference.aspose.com/slides/python-net/aspose.slides.export/)/[Dokumentation](/slides/de/python-net/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/python-net/convert-powerpoint-to-pdf/), [SVG](/slides/de/python-net/render-a-slide-as-an-svg-image/), [XPS](/slides/de/python-net/convert-powerpoint-to-xps/), [HTML](/slides/de/python-net/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.