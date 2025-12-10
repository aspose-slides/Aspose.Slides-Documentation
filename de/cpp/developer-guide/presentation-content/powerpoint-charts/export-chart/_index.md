---
title: Export von Präsentationsdiagrammen in С++
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
- С++
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für С++ exportieren, PPT- und PPTX-Formate unterstützen und das Reporting in jeden Workflow integrieren."
---

## **Diagrammbild abrufen**
Aspose.Slides for C++ bietet Unterstützung zum Extrahieren eines Bildes eines bestimmten Diagramms. Nachfolgend ein Beispiel.  
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

Ja. Ein Diagramm ist ein Shape, und sein Inhalt kann mittels der [shape-to-SVG saving method](https://reference.aspose.com/slides/cpp/aspose.slides/shape/writeassvg/) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bildrender‑Überladungen, die es ermöglichen, Größe oder Skalierung anzugeben – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Skalierung.

**Was soll ich tun, wenn Schriften in Beschriftungen und Legende nach dem Export falsch angezeigt werden?**

[Laden Sie die erforderlichen Schriften](/slides/de/cpp/custom-font/) via [FontsLoader](https://reference.aspose.com/slides/cpp/aspose.slides/fontsloader/) so that the chart rendering preserves metrics and text appearance.

**Wird beim Export das PowerPoint‑Design, die Formatvorlagen und Effekte berücksichtigt?**

Ja. Der Renderer von Aspose.Slides befolgt die Formatierung der Präsentation (Designs, Stile, Füllungen, Effekte), sodass das Aussehen des Diagramms erhalten bleibt.

**Wo finde ich verfügbare Rendering‑/Export‑Funktionen über Diagrammbilder hinaus?**

Siehe den Export‑Abschnitt der [API](https://reference.aspose.com/slides/cpp/aspose.slides.export/)/[Dokumentation](/slides/de/cpp/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/cpp/convert-powerpoint-to-pdf/), [SVG](/slides/de/cpp/render-a-slide-as-an-svg-image/), [XPS](/slides/de/cpp/convert-powerpoint-to-xps/), [HTML](/slides/de/cpp/convert-powerpoint-to-html/), etc.) und zugehörige Rendering‑Optionen.