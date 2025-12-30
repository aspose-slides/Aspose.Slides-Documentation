---
title: Anpassen von Ringdiagrammen in Präsentationen mit PHP
linktitle: Ringdiagramm
type: docs
weight: 30
url: /de/php-java/doughnut-chart/
keywords:
- Ringdiagramm
- Zentraler Abstand
- Lochgröße
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Entdecken Sie, wie Sie Ringdiagramme in Aspose.Slides für PHP via Java erstellen und anpassen, wobei PowerPoint-Formate für dynamische Präsentationen unterstützt werden."
---

## **Zentralen Abstand bei einem Ringdiagramm angeben**
{{% alert color="primary" %}} 

Aspose.Slides für PHP via Java unterstützt jetzt die Angabe der Größe des Lochs in einem Ringdiagramm. In diesem Thema sehen wir anhand eines Beispiels, wie die Größe des Lochs in einem Ringdiagramm angegeben wird.

{{% /alert %}} 

Um die Größe des Lochs in einem Ringdiagramm anzugeben, führen Sie bitte die folgenden Schritte aus:

1. Instanziieren Sie das [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation)-Objekt.
1. Fügen Sie dem Folienobjekt ein Ringdiagramm hinzu.
1. Geben Sie die Größe des Lochs im Ringdiagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im nachstehenden Beispiel haben wir die Größe des Lochs im Ringdiagramm festgelegt.
```php
  # Erstelle eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Schreibe die Präsentation auf die Festplatte
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Kann ich ein mehrstufiges Ringdiagramm mit mehreren Ringen erstellen?**

Ja. Fügen Sie einer einzigen Ringdiagramm mehrere Datenreihen hinzu – jede Datenreihe wird zu einem separaten Ring. Die Reihenfolge der Ringe wird durch die Reihenfolge der Datenreihen in der Sammlung bestimmt.

**Wird ein „explodiertes“ Ringdiagramm (getrennte Segmente) unterstützt?**

Ja. Es gibt einen Exploded Doughnut [chart type](https://reference.aspose.com/slides/php-java/aspose.slides/charttype/) und eine Explosions‑Eigenschaft für Datenpunkte; Sie können einzelne Segmente trennen.

**Wie kann ich ein Bild eines Ringdiagramms (PNG/SVG) für einen Bericht erhalten?**

Ein Diagramm ist ein Shape; Sie können es als [raster image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getImage) rendern oder das Diagramm in ein [SVG image](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#writeAsSvg) exportieren.