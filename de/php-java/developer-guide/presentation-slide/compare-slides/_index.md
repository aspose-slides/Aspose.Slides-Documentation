---
title: Vergleiche Folien
type: docs
weight: 50
url: /de/php-java/compare-slides/
---

## **Vergleiche Zwei Folien**
Die Equals-Methode wurde dem [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide)-Interface und der [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide)-Klasse hinzugefügt. Sie gibt true für die Folien/Layout und Folien/Masterfolien zurück, die in ihrer Struktur und statischen Inhalte identisch sind.

Zwei Folien sind gleich, wenn alle Formen, Stile, Texte, Animationen und andere Einstellungen usw. gleich sind. Der Vergleich berücksichtigt keine einzigartigen Identifikatorwerte, z.B. SlideId und dynamische Inhalte, z.B. den aktuellen Datumswert im Datumsplatzhalter.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d ist gleich zu SomePresentation2 MasterSlide#%d", $i, $j));
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