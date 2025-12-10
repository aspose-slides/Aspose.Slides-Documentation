---
title: Exportieren von Präsentationsdiagrammen in .NET
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/net/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für .NET exportieren, PPT- und PPTX-Formate unterstützen und das Reporting in jeden Workflow optimieren."
---

## **Diagrammbild abrufen**
Aspose.Slides for .NET bietet Unterstützung zum Extrahieren eines Bildes eines bestimmten Diagramms. Nachstehendes Beispiel wird gezeigt.
```c#
using (Presentation presentation = new Presentation("test.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IChart chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    using (IImage image = chart.GetImage())
    {
        image.Save("image.png", ImageFormat.Png);
    }
}
```


## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) statt als Rasterbild exportieren?**

Ja. Ein Diagramm ist eine Form, und sein Inhalt kann mit der [shape-to-SVG saving method](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) nach SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bild‑Rendering‑Überladungen, die die Angabe von Größe oder Skalierung ermöglichen – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriften in Beschriftungen und der Legende nach dem Export falsch dargestellt werden?**

[Laden Sie die erforderlichen Schriften](/slides/de/net/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/), damit das Rendering des Diagramms Metriken und Textdarstellung beibehält.

**Wird beim Export das PowerPoint‑Design, die Formatvorlagen und Effekte berücksichtigt?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Designs, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering‑/Export‑Möglichkeiten neben Diagrammbildern?**

Siehe den Export‑Abschnitt der [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[Dokumentation](/slides/de/net/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/net/convert-powerpoint-to-pdf/), [SVG](/slides/de/net/render-a-slide-as-an-svg-image/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [HTML](/slides/de/net/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.