---
title: Präsentationsdiagramme exportieren in PHP
linktitle: Diagramm exportieren
type: docs
weight: 90
url: /de/php-java/export-chart/
keywords:
- Diagramm
- Diagramm zu Bild
- Diagramm als Bild
- Diagrammbild extrahieren
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie Präsentationsdiagramme mit Aspose.Slides für PHP via Java exportieren, PPT- und PPTX-Formate unterstützen und das Reporting in jeden Workflow integrieren."
---

## **Diagrammbild abrufen**
Aspose.Slides für PHP via Java bietet Unterstützung zum Extrahieren eines Bildes eines bestimmten Diagramms. Nachfolgend ein Beispiel.
```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $slideImage = $chart->getImage();
    try {
      $slideImage->save("image.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich ein Diagramm als Vektor (SVG) statt als Rasterbild exportieren?**

Ja. Ein Diagramm ist eine Form, und dessen Inhalte können mit der [shape-to-SVG saving method](https://reference.aspose.com/slides/php-java/aspose.slides/shape/writeassvg/) als SVG gespeichert werden.

**Wie kann ich die genaue Größe des exportierten Diagramms in Pixeln festlegen?**

Verwenden Sie die Bildrender‑Overloads, die das Festlegen von Größe oder Maßstab ermöglichen – die Bibliothek unterstützt das Rendern von Objekten mit angegebenen Abmessungen/Maßstab.

**Was soll ich tun, wenn Schriften in Beschriftungen und der Legende nach dem Export falsch aussehen?**

[Laden Sie die erforderlichen Schriften](/slides/de/php-java/custom-font/) über [FontsLoader](https://reference.aspose.com/slides/php-java/aspose.slides/fontsloader/), damit das Rendern des Diagramms Metriken und Textdarstellung beibehält.

**Berücksichtigt der Export das PowerPoint‑Design, die Formatvorlagen und Effekte?**

Ja. Der Renderer von Aspose.Slides folgt der Formatierung der Präsentation (Designs, Formatvorlagen, Füllungen, Effekte), sodass das Erscheinungsbild des Diagramms erhalten bleibt.

**Wo finde ich weitere Rendering‑/Export‑Funktionen neben Diagrammbildern?**

Siehe die [API](https://reference.aspose.com/slides/php-java/aspose.slides/)/[Dokumentation](/slides/de/php-java/convert-powerpoint/) für Ausgabeziele ([PDF](/slides/de/php-java/convert-powerpoint-to-pdf/), [SVG](/slides/de/php-java/render-a-slide-as-an-svg-image/), [XPS](/slides/de/php-java/convert-powerpoint-to-xps/), [HTML](/slides/de/php-java/convert-powerpoint-to-html/), usw.) und zugehörige Rendering‑Optionen.