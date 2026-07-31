---
title: Export von Präsentationsdiagrammen in C++
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/cpp/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für C++ exportieren, PPT und PPTX Formate unterstützen und Berichterstellung in jeden Workflow optimieren."
---
## **Übersicht**

Aspose.Slides ermöglicht es Ihnen, ein Diagramm aus einer Präsentation als Bild zu exportieren. Dieser Artikel zeigt, wie Sie ein Bild aus einem Diagramm erhalten und speichern können, was nützlich ist, wenn Sie Diagrammvisualisierungen außerhalb einer PowerPoint‑Präsentation wiederverwenden müssen.

## **Diagrammbild erhalten**
Aspose.Slides für C++ bietet Unterstützung zum Extrahieren des Bildes eines bestimmten Diagramms. Nachfolgend ein Beispiel.

```cpp
auto presentation = MakeObject<Presentation>(u"test.pptx");

auto slide = presentation->get_Slide(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 0, 0, 500, 500);

auto image = chart->GetImage();
image->Save(u"image.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) anstelle eines Rasterbildes exportieren?**

Ja. Ein Diagramm ist eine Form, und dessen Inhalt kann mithilfe der [shape-to-SVG saving method](https://reference.aspose.com/slides/de/cpp/aspose.slides/shape/writeassvg/) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Überladungen für die Bilddarstellung, die es Ihnen ermöglichen, Größe oder Skalierung anzugeben – die Bibliothek unterstützt das Rendern von Objekten mit den angegebenen Abmessungen/der Skalierung.

**Was soll ich tun, wenn Schriftarten in Beschriftungen und Legende nach dem Export falsch dargestellt werden?**

[Laden Sie die erforderlichen Schriftarten](/slides/de/cpp/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/de/cpp/aspose.slides/fontsloader/), damit die Diagrammdarstellung Metriken und das Textaussehen beibehält.

**Berücksichtigt der Export das PowerPoint-Thema, die Formatvorlagen und Effekte?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Themen, Formatvorlagen, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering-/Exportmöglichkeiten neben Diagrammbildern?**

Siehe den Export‑Abschnitt der [API](https://reference.aspose.com/slides/de/cpp/aspose.slides.export/)/[Dokumentation](/slides/de/cpp/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/de/cpp/convert-powerpoint-to-xps/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.