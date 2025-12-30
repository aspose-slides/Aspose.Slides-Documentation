---
title: Präsentationsfolien vergleichen in PHP
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
description: "Vergleichen Sie PowerPoint- und OpenDocument-Präsentationen programmatisch mit Aspose.Slides für PHP über Java. Identifizieren Sie Folienunterschiede im Code schnell."
---

## **Zwei Folien vergleichen**
Die Equals‑Methode wurde dem Interface [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) und der Klasse [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide) hinzugefügt. Sie gibt true zurück für Folien/Layouts und Master‑Folien, die in ihrer Struktur und ihrem statischen Inhalt identisch sind.  

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine eindeutigen Bezeichnerwerte, z. B. SlideId, und keinen dynamischen Inhalt, z. B. den aktuellen Datumswert in einem Datums‑Platzhalter.
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

**Wirkt sich die Tatsache aus, dass eine Folie ausgeblendet ist, auf den Vergleich der Folien selbst aus?**

[Versteckter Status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) ist eine Präsentations‑/Wiedergabe‑Ebene‑Eigenschaft, kein visueller Inhalt. Die Gleichheit zweier konkreter Folien wird durch ihre Struktur und ihren statischen Inhalt bestimmt; die bloße Tatsache, dass eine Folie ausgeblendet ist, macht die Folien nicht unterschiedlich.

**Werden Hyperlinks und ihre Parameter berücksichtigt?**

Ja. Links sind Teil des statischen Inhalts einer Folie. Wenn die URL oder die Hyperlink‑Aktion abweicht, wird dies in der Regel als Unterschied im statischen Inhalt behandelt.

**Wenn ein Diagramm auf eine externe Excel‑Datei verweist, werden die Inhalte dieser Datei berücksichtigt?**

Nein. Der Vergleich wird anhand der Folien selbst durchgeführt. Externe Datenquellen werden in der Regel zum Vergleich nicht gelesen; es wird nur das berücksichtigt, was in der Struktur und dem statischen Zustand der Folie vorhanden ist.