---
title: PowerPoint-Diagramme in PHP animieren
linktitle: Animierte Diagramme
type: docs
weight: 80
url: /de/php-java/animated-charts/
keywords:
- Diagramm
- animiertes Diagramm
- Diagramm-Animation
- Diagrammreihe
- Diagrammkategorie
- Reihen-Element
- Kategorie-Element
- Effekt hinzufügen
- Effekttyp
- PowerPoint
- Präsentation
- PHP
- Aspose.Slides
description: "Erstellen Sie beeindruckende animierte Diagramme mit Aspose.Slides für PHP über Java. Verbessern Sie Präsentationen mit dynamischen Visualisierungen in PPT- und PPTX-Dateien - starten Sie jetzt."
---

{{% alert color="primary" %}} 
Aspose.Slides für PHP über Java unterstützt die Animation von Diagrammelementen. **Series**, **Categories**, **Series Elements**, **Categories Elements** können mit der Methode [**ISequence**.**addEffect**](https://reference.aspose.com/slides/php-java/aspose.slides/ISequence#addEffect-com.aspose.slides.IChart-int-int-int-int-int-) und den beiden Enums [**EffectChartMajorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMajorGroupingType) sowie [**EffectChartMinorGroupingType**](https://reference.aspose.com/slides/php-java/aspose.slides/EffectChartMinorGroupingType) animiert werden.
{{% /alert %}} 

## **Diagrammreihen-Animation**
Wenn Sie eine Diagrammreihe animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagramm‑Objekts.
1. Animieren Sie die Reihe.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Diagrammreihen animiert.
```php
  # Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Referenz des Diagrammobjekts erhalten
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Die Reihe animieren
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


## **Diagramm‑Kategorien‑Animation**
Wenn Sie Diagrammkategorien animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagramm‑Objekts.
1. Animieren Sie die Kategorie.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Diagrammkategorien animiert.
```php
  # Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
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


## **Animation eines Reihe‑Elements**
Wenn Sie Reihen‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagramm‑Objekts.
1. Animieren Sie Reihen‑Elemente.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Elemente einer Reihe animiert.
```php
  # Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
  $pres = new Presentation("ExistingChart.pptx");
  try {
    # Referenz des Diagrammobjekts erhalten
    $slide = $pres->getSlides()->get_Item(0);
    $shapes = $slide->getShapes();
    $chart = $shapes->get_Item(0);
    # Elemente der Serie animieren
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


## **Animation eines Kategorie‑Elements**
Wenn Sie Kategorie‑Elemente animieren möchten, schreiben Sie den Code gemäß den unten aufgeführten Schritten:

1. Laden Sie eine Präsentation.
1. Holen Sie die Referenz des Diagramm‑Objekts.
1. Animieren Sie Kategorie‑Elemente.
1. Schreiben Sie die Präsentationsdatei auf die Festplatte.

Im nachstehenden Beispiel haben wir Kategorie‑Elemente animiert.
```php
  # Instanziieren Sie die Presentation-Klasse, die eine Präsentationsdatei darstellt
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

**Werden verschiedene Effektarten (z. B. Einstieg, Betonung, Ausgang) für Diagramme wie für reguläre Formen unterstützt?**

Ja. Ein Diagramm wird als Form behandelt und unterstützt daher die üblichen Animationseffekttypen, einschließlich Einstieg, Betonung und Ausgang, mit voller Kontrolle über die Zeitleiste der Folie und die Animationssequenzen.

**Kann ich Diagramm‑Animationen mit Folienübergängen kombinieren?**

Ja. [Übergänge](/slides/de/php-java/slide-transition/) gelten für die Folie, während Animationseffekte für Objekte auf der Folie gelten. Sie können beides in derselben Präsentation verwenden und sie unabhängig voneinander steuern.

**Werden Diagramm‑Animationen beim Speichern als PPTX beibehalten?**

Ja. Beim [speichern als PPTX](/slides/de/php-java/save-presentation/) bleiben alle Animationseffekte und deren Reihenfolge erhalten, da sie Teil des nativen Animationsmodells der Präsentation sind.

**Kann ich vorhandene Diagramm‑Animationen aus einer Präsentation auslesen und ändern?**

Ja. Die API bietet Zugriff auf die Zeitleiste der Folie, Sequenzen und Effekte, sodass Sie vorhandene Diagramm‑Animationen inspizieren und anpassen können, ohne alles neu erstellen zu müssen.

**Kann ich ein Video erzeugen, das Diagramm‑Animationen enthält, mit Aspose.Slides?**

Ja. Sie können eine Präsentation [Exportieren einer Präsentation als Video](/slides/de/php-java/convert-powerpoint-to-video/) und dabei die Animationen, Zeitsteuerungen und weitere Exporteinstellungen beibehalten, sodass das resultierende Video die animierte Wiedergabe widerspiegelt.