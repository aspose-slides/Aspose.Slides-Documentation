---
title: Créer des présentations en PHP
linktitle: Créer une présentation
type: docs
weight: 10
url: /fr/php-java/create-presentation/
keywords:
- créer une présentation
- nouvelle présentation
- créer PPT
- nouveau PPT
- créer PPTX
- nouveau PPTX
- créer ODP
- nouveau ODP
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Créez des présentations avec Aspose.Slides pour PHP via Java — produisez des fichiers PPT, PPTX et ODP et enregistrez-les programmatiquement pour des résultats fiables."
---

## **Créer une présentation**

Pour ajouter une simple ligne droite à une diapositive sélectionnée de la présentation, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe Presentation.
1. Obtenez la référence d’une diapositive en utilisant son index.
1. Ajoutez une AutoShape de type Ligne en utilisant la méthode addAutoShape fournie par l’objet Shapes.
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

Dans l’exemple ci‑dessous, nous avons ajouté une ligne à la première diapositive de la présentation.
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


## **FAQ**

**Quels formats puis‑je enregistrer pour une nouvelle présentation ?**

Vous pouvez enregistrer au format [PPTX, PPT et ODP](/slides/fr/php-java/save-presentation/), et exporter vers [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/php-java/convert-powerpoint-to-xps/), [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), [SVG](/slides/fr/php-java/convert-powerpoint-to-png/), et [images](/slides/fr/php-java/convert-powerpoint-to-png/), entre autres.

**Puis‑je partir d’un modèle (POTX/POTM) et l’enregistrer comme un PPTX ordinaire ?**

Oui. Chargez le modèle et enregistrez‑le dans le format souhaité ; les formats POTX/POTM/PPTM et similaires [sont pris en charge](/slides/fr/php-java/supported-file-formats/).

**Comment contrôler la taille/le ratio d’aspect des diapositives lors de la création d’une présentation ?**

Définissez la [taille des diapositives](/slides/fr/php-java/slide-size/) (y compris les préréglages comme 4:3 et 16:9 ou des dimensions personnalisées) et choisissez comment le contenu doit être mis à l’échelle.

**Dans quelles unités les tailles et les coordonnées sont‑elles mesurées ?**

En points : 1 pouce équivaut à 72 unités.

**Comment gérer des présentations très volumineuses (avec de nombreux fichiers multimédias) pour réduire l’utilisation de la mémoire ?**

Utilisez les [stratégies de gestion des BLOB](/slides/fr/php-java/manage-blob/), limitez le stockage en mémoire en exploitant des fichiers temporaires, et privilégiez les flux de travail basés sur des fichiers plutôt que les flux uniquement en mémoire.

**Puis‑je créer/enregistrer des présentations en parallèle ?**

Vous ne pouvez pas manipuler la même [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) depuis [multiple threads](/slides/fr/php-java/multithreading/). Exécutez des instances séparées et isolées par thread ou par processus.

**Comment supprimer le filigrane d’évaluation et les limitations ?**

[Appliquez une licence](/slides/fr/php-java/licensing/) une fois par processus. Le XML de licence doit rester inchangé, et la configuration de licence doit être synchronisée si plusieurs threads sont impliqués.

**Puis‑je signer numériquement le PPTX que je crée ?**

Oui. Les [signatures numériques](/slides/fr/php-java/digital-signature-in-powerpoint/) (ajout et vérification) sont prises en charge pour les présentations.

**Les macros (VBA) sont‑elles prises en charge dans les présentations créées ?**

Oui. Vous pouvez [créer/modifier des projets VBA](/slides/fr/php-java/presentation-via-vba/) et enregistrer des fichiers activés macro tels que PPTM/PPSM.