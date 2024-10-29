---
title: Comparer des diapositives
type: docs
weight: 50
url: /fr/php-java/compare-slides/
---

## **Comparer Deux Diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) et à la classe [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Elle renvoie vrai pour les diapositives/layouts et les diapositives/master qui sont identiques par leur structure et leur contenu statique.

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc. sont égaux. La comparaison ne prend pas en compte les valeurs d'identifiant unique, par exemple, SlideId et le contenu dynamique, par exemple, la valeur actuelle de la date dans le champ Date.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d est égal à SomePresentation2 MasterSlide#%d", $i, $j));
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