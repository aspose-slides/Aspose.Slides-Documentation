---
title: Präsentationsfolien in PHP vergleichen
linktitle: Folien vergleichen
type: docs
weight: 50
url: /de/php-java/compare-slides/
keywords:
- Folien vergleichen
- Folienvergleich
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmgesteuert mit Aspose.Slides für PHP über Java. Identifizieren Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Die Equals‑Methode wurde zur Klasse [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) hinzugefügt. Sie gibt true zurück für Folien/Layout‑ und Master‑Folien, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.  

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Identifikatoren, z. B. SlideId, und keinen dynamischen Inhalt, z. B. das aktuelle Datum in einem Datums‑Platzhalter.  
```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```


## **FAQ**

**Wirkt sich die Tatsache, dass eine Folie ausgeblendet ist, auf den Vergleich der Folien selbst aus?**

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) ist eine Präsentations‑/Wiedergabe‑Ebene‑Eigenschaft, nicht visueller Inhalt. Die Gleichheit zweier bestimmter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die reine Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und ihre Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion unterschiedlich ist, wird dies in der Regel als Unterschied im statischen Inhalt betrachtet.

**Falls ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich erfolgt basierend auf den Folien selbst. Externe Datenquellen werden in der Regel zum Vergleich nicht ausgelesen; es wird nur das berücksichtigt, was in der Struktur und dem statischen Zustand der Folie vorhanden ist.