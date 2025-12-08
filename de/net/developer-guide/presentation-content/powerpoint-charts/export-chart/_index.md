---
title: Diagramm exportieren
type: docs
weight: 90
url: /de/net/export-chart/
keywords:
- Diagramm
- Diagrammbild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Diagrammbilder aus PowerPoint-Präsentationen in C# oder .NET erhalten"
---

## **Diagrammbild abrufen**
Aspose.Slides für .NET bietet Unterstützung zum Extrahieren eines Bildes eines bestimmten Diagramms. Nachfolgend ein Beispiel.

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
Ja. Ein Diagramm ist eine Form, und dessen Inhalt kann mit der [shape-to-SVG saving method](https://reference.aspose.com/slides/net/aspose.slides/shape/writeassvg/) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**
Verwenden Sie die Bilddarstellungs-Überladungen, die es ermöglichen, Größe oder Skalierung anzugeben - die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriftarten in Beschriftungen und Legende nach dem Export falsch aussehen?**
[Laden Sie die erforderlichen Schriftarten](/slides/de/net/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/net/aspose.slides/fontsloader/), damit das Rendern des Diagramms Metriken und Textaussehen beibehält.

**Berücksichtigt der Export das PowerPoint-Theme, Formatvorlagen und Effekte?**
Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Themes, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering-/Export-Funktionen neben Diagrammbildern?**
Siehe den Exportbereich der [API](https://reference.aspose.com/slides/net/aspose.slides.export/)/[Dokumentation](/slides/de/net/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/net/convert-powerpoint-to-pdf/), [SVG](/slides/de/net/render-a-slide-as-an-svg-image/), [XPS](/slides/de/net/convert-powerpoint-to-xps/), [HTML](/slides/de/net/convert-powerpoint-to-html/), usw.) und zugehörige Rendering-Optionen.