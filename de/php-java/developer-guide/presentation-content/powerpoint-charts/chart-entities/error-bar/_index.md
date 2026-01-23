---
title: Fehlerbalken in Präsentationsdiagrammen mit PHP anpassen
linktitle: Fehlerbalken
type: docs
url: /de/php-java/error-bar/
keywords:
- Fehlerbalken
- Benutzerdefinierter Wert
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erfahren Sie, wie Sie mit Aspose.Slides für PHP via Java Fehlerbalken in Diagrammen hinzufügen und anpassen — optimieren Sie die Datenvisualisierung in PowerPoint-Präsentationen."
---

## **Fehlerbalken hinzufügen**
Aspose.Slides für PHP via Java bietet eine einfache API zur Verwaltung von Fehlerbalkenwerten. Der Beispielcode gilt, wenn ein benutzerdefinierter Werttyp verwendet wird. Um einen Wert festzulegen, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**Datenpunkte**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/)‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Format des Fehlerbalkens.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
```php
  # Instanz der Presentation-Klasse erstellen
  $pres = new Presentation();
  try {
    # Erstelle ein Blasendiagramm
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Bubble, 50, 50, 400, 300, true);
    # Fehlerbalken hinzufügen und dessen Format festlegen
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
Aspose.Slides für PHP via Java bietet eine einfache API zur Verwaltung benutzerdefinierter Fehlerbalkenwerte. Der Beispielcode gilt, wenn die Methode [**ErrorBarsFormat::getValueType**](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/#getValueType) den Wert **Custom** zurückgibt. Um einen Wert festzulegen, verwenden Sie die **ErrorBarCustomValues**‑Eigenschaft eines bestimmten Datenpunkts in der [**Datenpunkte**](https://reference.aspose.com/slides/php-java/aspose.slides/chartseriescollection/)‑Sammlung der Serie:

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation)-Klasse.
1. Fügen Sie ein Blasendiagramm auf der gewünschten Folie hinzu.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das X‑Format des Fehlerbalkens.
1. Greifen Sie auf die erste Diagrammserie zu und setzen Sie das Y‑Format des Fehlerbalkens.
1. Greifen Sie auf die einzelnen Datenpunkte der Diagrammserie zu und setzen Sie die Fehlerbalkenwerte für den jeweiligen Datenpunkt der Serie.
1. Festlegen der Balkenwerte und des Formats.
1. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.
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
    # Zugriff auf Datenpunkt der Diagrammserie und Festlegen von Fehlerbalkenwerten für
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

**Was passiert mit Fehlerbalken, wenn eine Präsentation in PDF oder Bilder exportiert wird?**

Sie werden als Teil des Diagramms gerendert und bei der Konvertierung zusammen mit der restlichen Diagrammformatierung erhalten, vorausgesetzt, es wird eine kompatible Version oder ein Renderer verwendet.

**Können Fehlerbalken mit Markierungen und Datenbeschriftungen kombiniert werden?**

Ja. Fehlerbalken sind ein separates Element und sind mit Markierungen und Datenbeschriftungen kompatibel; überschneiden sich die Elemente, müssen Sie ggf. die Formatierung anpassen.

**Wo finde ich die Liste der Eigenschaften und Klassen zum Arbeiten mit Fehlerbalken in der API?**

In der API‑Referenz: die Klasse [ErrorBarsFormat](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarsformat/) und die zugehörigen Klassen [ErrorBarType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbartype/) und [ErrorBarValueType](https://reference.aspose.com/slides/php-java/aspose.slides/errorbarvaluetype/).