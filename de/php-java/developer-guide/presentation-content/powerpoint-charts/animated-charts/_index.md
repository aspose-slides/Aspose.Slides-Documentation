---
title: PowerPoint-Diagramme in PHP animieren
linktitle: Animierte Diagramme
type: docs
weight: 80
url: /de/php-java/animated-charts/
keywords:
- Diagramm
- animiertes Diagramm
- Diagrammanimation
- Diagrammserie
- Diagrammkategorie
- Serienelement
- Kategorienelement
- Effekt hinzufügen
- Effektart
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie beeindruckende animierte Diagramme mit Aspose.Slides für PHP via Java. Steigern Sie Präsentationen mit dynamischen Visuals in PPT- und PPTX-Dateien - starten Sie jetzt."
---

{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java unterstützt die Animation von Diagrammelementen. **Series**, **Categories**, **Series Elements**, **Categories Elements** können mit der Methode [**Sequence::addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/sequence/#addEffect) und den beiden Aufzählungen [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) sowie [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType) animiert werden.

{{% /alert %}} 

## **Diagrammserienanimation**
Wenn Sie eine Diagrammserie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie die Serie.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Diagrammserien animiert.
```php
  # Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Referenz des Diagrammobjekts erhalten
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Die Serie animieren
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::BySeries, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Die modifizierte Präsentation auf die Festplatte schreiben
    $pres->save("AnimatingSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Diagrammkategorieanimation**
Wenn Sie eine Diagrammkategorie animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie die Kategorie.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Diagrammkategorien animiert.
```php
  # Instanziieren der Presentation-Klasse, die eine Präsentationsdatei repräsentiert
  $pres = new Presentation("ExistingChart.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMajorGroupingType::ByCategory, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $pres->save("Sample_Animation_C.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation in einem Serienlement**
Wenn Sie Serienlemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie Serienlemente.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Serienlemente animiert.
```php
  # Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Referenz des Diagrammobjekts erhalten
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Serienelemente animieren
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInSeries, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Die Präsentationsdatei auf die Festplatte schreiben
    $pres->save("AnimatingSeriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Animation in einem Kategorieelement**
Wenn Sie Kategorieelemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagrammobjekts.
1. Animieren Sie Kategorieelemente.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Kategorieelemente animiert.
```php
  # Instanziieren der Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Referenz des Diagrammobjekts erhalten
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Kategorien-Elemente animieren
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectType::Fade, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 0, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 1, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 0, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 1, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 2, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    $slide->getTimeline()->getMainSequence()->addEffect($chart, EffectChartMinorGroupingType::ByElementInCategory, 2, 3, EffectType::Appear, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Die Präsentationsdatei auf die Festplatte schreiben
    $pres->save("AnimatingCategoriesElements_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Werden verschiedene Effektarten (z. B. Eintritt, Betonung, Austritt) für Diagramme wie für reguläre Formen unterstützt?**

Ja. Ein Diagramm wird als Form behandelt und unterstützt daher die Standard‑Animationseffektarten, einschließlich Eintritt, Betonung und Austritt, mit voller Kontrolle über die Zeitleiste der Folie und die Animationssequenzen.

**Kann ich Diagrammanimationen mit Folienübergängen kombinieren?**

Ja. [Transitions](/slides/de/php-java/slide-transition/) gelten für die Folie, während Animationseffekte für Objekte auf der Folie gelten. Sie können be beides in derselben Präsentation verwenden und unabhängig steuern.

**Werden Diagramm‑Animationen beim Speichern als PPTX erhalten?**

Ja. Beim [save to PPTX](/slides/de/php-java/save-presentation/) bleiben alle Animationseffekte und ihre Reihenfolge erhalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagramm‑Animationen aus einer Präsentation auslesen und ändern?**

Ja. Die API bietet Zugriff auf die Folien‑Zeitachse, Sequenzen und Effekte, sodass Sie vorhandene Diagramm‑Animationen inspizieren und anpassen können, ohne alles von Grund auf neu zu erstellen.

**Kann ich ein Video erzeugen, das Diagramm‑Animationen mit Aspose.Slides enthält?**

Ja. Sie können eine Präsentation [export a presentation to video](/slides/de/php-java/convert-powerpoint-to-video/) und dabei Animationen beibehalten, Timings und weitere Export‑Einstellungen konfigurieren, sodass das resultierende Video die animierte Wiedergabe widerspiegelt.