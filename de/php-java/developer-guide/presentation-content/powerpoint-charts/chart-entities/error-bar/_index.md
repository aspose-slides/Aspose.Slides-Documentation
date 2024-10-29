---
title: Fehlerbalken
type: docs
url: /de/php-java/error-bar/
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für PHP über Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt für die Verwendung eines benutzerdefinierten Wertetyps. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection)-Sammlung von Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-X-Format fest.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-Y-Format fest.
1. Legen Sie die Werte und das Format der Balken fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Erstellen eines Blasendiagramms
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Hinzufügen von Fehlerbalken und Festlegen des Formats
    $errBarX = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsXFormat();
    $errBarY = $chart->getChartData()->getSeries()->get_Item(0)->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Fixed);
    $errBarX->setValue(0.1);
    $errBarY->setValueType(ErrorBarValueType::Percentage);
    $errBarY->setValue(5);
    $errBarX->setType(ErrorBarType::Plus);
    $errBarY->getFormat()->getLine()->setWidth(2.0);
    $errBarX->hasEndCap();
    # Präsentation speichern
    $pres->save("ErrorBars.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Benutzerdefinierten Fehlerbalkenwert hinzufügen**
Aspose.Slides für PHP über Java bietet eine einfache API zur Verwaltung von benutzerdefinierten Fehlerbalkenwerten. Der Beispielcode gilt, wenn die [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--) -Eigenschaft gleich **Custom** ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection)-Sammlung von Serien:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-X-Format fest.
1. Greifen Sie auf die erste Diagrammserie zu und legen Sie das Fehlerbalken-Y-Format fest.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und legen Sie die Werte für die Fehlerbalken für einzelne Serien-Datenpunkte fest.
1. Legen Sie die Werte und das Format der Balken fest.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX-Datei.

```php
  # Erstellen Sie eine Instanz der Presentation-Klasse
  $pres = new Presentation();
  try {
    # Erstellen eines Blasendiagramms
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Hinzufügen benutzerdefinierter Fehlerbalken und Festlegen des Formats
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Zugriff auf den Datenpunkt der Diagrammserie und Festlegung der Werte für die Fehlerbalken für
    # einzelnen Punkt
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Fehlerbalken für die Punkte der Diagrammserie festlegen
    for($i = 0; $i < java_values($points->size()) ; $i++) {
      $points->get_Item($i)->getErrorBarsCustomValues()->getXMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getXPlus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYMinus()->setAsLiteralDouble($i + 1);
      $points->get_Item($i)->getErrorBarsCustomValues()->getYPlus()->setAsLiteralDouble($i + 1);
    }
    # Präsentation speichern
    $pres->save("ErrorBarsCustomValues.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```