---
title: Diagrammdaten Tabelle
type: docs
url: /php-java/chart-data-table/
---

## **Schriftart-Eigenschaften für Diagrammdaten Tabelle festlegen**
Aspose.Slides für PHP via Java bietet Unterstützung für die Änderung der Farbzusammenstellung in einer Farbreihe.

1. Erstellen Sie ein [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) Klassenobjekt.
1. Fügen Sie das Diagramm auf der Folie hinzu.
1. Legen Sie die Diagrammtabelle fest.
1. Legen Sie die Schriftgröße fest.
1. Speichern Sie die geänderte Präsentation.

Unten ist ein Beispiel gegeben.

```php
  # Erstellen einer leeren Präsentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->setDataTable(true);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontBold(NullableBool::True);
    $chart->getChartDataTable()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```