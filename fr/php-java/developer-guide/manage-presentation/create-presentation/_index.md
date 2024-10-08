---
title: Créez une présentation PowerPoint en utilisant PHP
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/php-java/create-presentation/
keywords: créer ppt java, créer présentation ppt, créer pptx java
description: Découvrez comment créer des présentations PowerPoint, par exemple PPT, PPTX, en utilisant PHP à partir de zéro.
---

## **Créer une présentation PowerPoint**
Pour ajouter une simple ligne à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez une AutoShape de type ligne en utilisant la méthode addAutoShape exposée par l'objet Shapes.
1. Écrivez la présentation modifiée en tant que fichier PPTX.

Dans l'exemple ci-dessous, nous avons ajouté une ligne à la première diapositive de la présentation.

```php
  # Instancier un objet Presentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une autoshape de type ligne
    $slide->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    $pres->save("NewPresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```