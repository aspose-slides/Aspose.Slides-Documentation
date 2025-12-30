---
title: Fehlerbalken in Präsentationsdiagrammen mit PHP anpassen
linktitle: Fehlerbalken
type: docs
url: /de/php-java/error-bar/
keywords:
- Fehlerbalken
- benutzerdefinierter Wert
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für PHP via Java Fehlerbalken in Diagrammen hinzufügen und anpassen — optimieren Sie Datenvisualisierungen in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Wertetyp verwendet wird. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**-Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.  
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalkenformat.  
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalkenformat.  
1. Festlegen von Balkenwerten und -format.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.  
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Erstellen eines Blasendiagramms
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Fehlerbalken hinzufügen und das Format festlegen
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


## **Benutzerdefinierte Fehlerbalkenwerte hinzufügen**
Aspose.Slides for PHP via Java bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die [**IErrorBarsFormat.ValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/IErrorBarsFormat#getValue--)‑Eigenschaft auf **Custom** gesetzt ist. Um einen Wert anzugeben, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**DataPoints**](https://reference.aspose.com/slides/php-java/aspose.slides/IChartSeriesCollection)-Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.  
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.  
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Fehlerbalkenformat.  
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Fehlerbalkenformat.  
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für den jeweiligen Datenpunkt.  
1. Festlegen von Balkenwerten und -format.  
1. Schreiben Sie die geänderte Präsentation in eine PPTX-Datei.  
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Blasendiagramm erstellen
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Benutzerdefinierte Fehlerbalken hinzufügen und das Format festlegen
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $errBarX = $series->getErrorBarsXFormat();
    $errBarY = $series->getErrorBarsYFormat();
    $errBarX->isVisible();
    $errBarY->isVisible();
    $errBarX->setValueType(ErrorBarValueType::Custom);
    $errBarY->setValueType(ErrorBarValueType::Custom);
    # Zugriff auf Datenpunkt der Diagrammserie und Festlegen der Fehlerbalkenwerte für
    # einzelnen Punkt
    $points = $series->getDataPoints();
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForXMinusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYPlusValues(DataSourceType::DoubleLiterals);
    $points->getDataSourceTypeForErrorBarsCustomValues()->setDataSourceTypeForYMinusValues(DataSourceType::DoubleLiterals);
    # Fehlerbalken für Diagrammserienpunkte festlegen
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


## **FAQ**

**Was passiert mit Fehlerbalken beim Exportieren einer Präsentation in PDF oder Bilder?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markern und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und kompatibel mit Markern und Datenbeschriftungen; überschneiden sich die Elemente, müssen Sie möglicherweise die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Klassen für die Arbeit mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) und die zugehörigen Klassen [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).