---
title: Comparer les diapositives de présentation en PHP
linktitle: Comparer les diapositives
type: docs
weight: 50
url: /fr/php-java/compare-slides/
keywords:
- comparer les diapositives
- comparaison de diapositives
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Comparez les présentations PowerPoint et OpenDocument programmatiquement avec Aspose.Slides pour PHP via Java. Identifiez rapidement les différences de diapositives dans le code."
---

## **Comparer deux diapositives**
La méthode Equals a été ajoutée à l'interface [IBaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/IBaseSlide) et à la classe [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/BaseSlide). Elle renvoie true pour les diapositives/disposition et diapositives maître qui sont identiques par leur structure et leur contenu statique.  

Deux diapositives sont égales si toutes les formes, styles, textes, animations et autres paramètres, etc., sont égaux. La comparaison ne tient pas compte des valeurs d'identifiants uniques, par exemple SlideId, ni du contenu dynamique, par exemple la valeur de date actuelle dans le texte de substitution Date.
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

**Le fait qu'une diapositive soit masquée affecte-t-il la comparaison des diapositives elles‑mêmes ?**

[Hidden status](https://reference.aspose.com/slides/php-java/aspose.slides/slide/gethidden/) est une propriété au niveau de la présentation/lecture, pas du contenu visuel. L'égalité de deux diapositives spécifiques est déterminée par leur structure et leur contenu statique ; le simple fait qu'une diapositive soit masquée ne rend pas les diapositives différentes.

**Les hyperliens et leurs paramètres sont-ils pris en compte ?**

Oui. Les liens font partie du contenu statique d’une diapositive. Si l’URL ou l’action du lien hypertexte diffère, cela est généralement considéré comme une différence de contenu statique.

**Si un graphique fait référence à un fichier Excel externe, le contenu de ce fichier sera-t-il pris en compte ?**

Non. La comparaison s'effectue en se basant uniquement sur les diapositives elles‑mêmes. Les sources de données externes ne sont généralement pas lues lors de la comparaison ; seuls les éléments présents dans la structure et l’état statique de la diapositive sont pris en compte.