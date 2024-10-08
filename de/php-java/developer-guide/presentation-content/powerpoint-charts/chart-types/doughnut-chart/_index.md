---
title: Doughnut-Diagramm
type: docs
weight: 30
url: /de/php-java/doughnut-chart/
---

## **Ändern des Mittelbereichs im Doughnut-Diagramm**
{{% alert color="primary" %}} 

Aspose.Slides für PHP über Java unterstützt jetzt die Angabe der Größe des Lochs in einem Doughnut-Diagramm. In diesem Thema werden wir mit einem Beispiel sehen, wie die Größe des Lochs in einem Doughnut-Diagramm angegeben wird.

{{% /alert %}} 

Um die Größe des Lochs in einem Doughnut-Diagramm anzugeben, befolgen Sie bitte die folgenden Schritte:

1. Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation) Objekt.
1. Fügen Sie auf der Folie ein Doughnut-Diagramm hinzu.
1. Geben Sie die Größe des Lochs in einem Doughnut-Diagramm an.
1. Schreiben Sie die Präsentation auf die Festplatte.

Im folgenden Beispiel haben wir die Größe des Lochs in einem Doughnut-Diagramm festgelegt.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Doughnut, 50, 50, 400, 400);
    $chart->getChartData()->getSeriesGroups()->get_Item(0)->setDoughnutHoleSize(90);
    # Schreiben Sie die Präsentation auf die Festplatte
    $pres->save("DoughnutHoleSize_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```