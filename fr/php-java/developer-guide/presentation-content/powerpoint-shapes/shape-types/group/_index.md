---
title: Formes de groupe de présentation en PHP
linktitle: Groupe de formes
type: docs
weight: 40
url: /fr/php-java/group/
keywords:
- forme de groupe
- groupe de formes
- ajouter un groupe
- texte alternatif
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à regrouper et dégrouper des formes dans les présentations PowerPoint en utilisant Aspose.Slides pour PHP via Java — guide rapide, étape par étape, avec du code gratuit."
---

## **Ajouter une forme groupée**
Aspose.Slides prend en charge le travail avec des formes groupées sur les diapositives. Cette fonctionnalité aide les développeurs à créer des présentations plus riches. Aspose.Slides for PHP via Java prend en charge l'ajout ou l'accès aux formes groupées. Il est possible d'ajouter des formes à une forme groupée ajoutée pour la remplir ou d'accéder à toute propriété de la forme groupée. Pour ajouter une forme groupée à une diapositive à l'aide d'Aspose.Slides for PHP via Java :

1. Créez une instance de la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe.  
1. Obtenez la référence d'une diapositive en utilisant son Index  
1. Ajoutez une forme groupée à la diapositive.  
1. Ajoutez les formes à la forme groupée ajoutée.  
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

L'exemple ci‑dessous ajoute une forme groupée à une diapositive.
```php
  # Instancier la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Accéder à la collection de formes des diapositives
    $slideShapes = $sld->getShapes();
    # Ajouter une forme groupée à la diapositive
    $groupShape = $slideShapes->addGroupShape();
    # Ajouter des formes à l'intérieur de la forme groupée ajoutée
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Ajouter le cadre de la forme groupée
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Écrire le fichier PPTX sur le disque
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Accéder à la propriété AltText**
Ce sujet présente des étapes simples, accompagnées d'exemples de code, pour ajouter une forme groupée et accéder à la propriété AltText des formes groupées sur les diapositives. Pour accéder à l'AltText d'une forme groupée dans une diapositive à l'aide d'Aspose.Slides for PHP via Java :

1. Instanciez la [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) classe qui représente le fichier PPTX.  
1. Obtenez la référence d'une diapositive en utilisant son Index.  
1. Accédez à la collection de formes des diapositives.  
1. Accédez à la forme groupée.  
1. Accédez à la propriété [Texte alternatif](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#getAlternativeText).

L'exemple ci‑dessous accède au texte alternatif de la forme groupée.
```php
  # Instancier la classe Presentation qui représente le fichier PPTX
  $pres = new Presentation("AltText.pptx");
  try {
    # Obtenir la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Accéder à la collection de formes des diapositives
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Accéder à la forme groupée.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Accéder à la propriété AltText
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Le groupement imbriqué (un groupe à l'intérieur d'un autre groupe) est‑il pris en charge ?**

Oui. [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) possède une méthode [getParentGroup](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getparentgroup/) qui indique directement la prise en charge de la hiérarchie (un groupe peut être l'enfant d'un autre groupe).

**Comment contrôler l'ordre Z du groupe par rapport aux autres objets de la diapositive ?**

Utilisez la méthode [getZOrderPosition](https://reference.aspose.com/slides/php-java/aspose.slides/shape/getzorderposition/) du [GroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/) pour inspecter sa position dans la pile d'affichage.

**Puis‑je empêcher le déplacement/la modification/le dégroupage ?**

Oui. La section de verrouillage du groupe est exposée via [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/getgroupshapelock/), qui vous permet de restreindre les opérations sur l'objet.