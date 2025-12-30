---
title: Ajouter des diapositives aux présentations en PHP
linktitle: Ajouter une diapositive
type: docs
weight: 10
url: /fr/php-java/add-slide-to-presentation/
keywords:
- ajouter une diapositive
- créer une diapositive
- diapositive vide
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument avec Aspose.Slides for PHP via Java — insertion de diapositives fluide et efficace en quelques secondes."
---

## **Ajouter une diapositive à une présentation**
{{% alert color="primary" %}} 

Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Master / Layout** et d'autres diapositives **Normal**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for PHP via Java. Chaque diapositive possède un Id unique et toutes les Diapositives Normal sont organisées dans un ordre spécifié par l'index zéro‑base.

{{% /alert %}} 

Aspose.Slides for PHP via Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) en définissant une référence à la propriété [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (collection d'objets Slide de contenu) exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) exposées par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- Effectuez des opérations avec la diapositive vide nouvellement ajoutée.
- Enfin, écrivez le fichier de présentation à l'aide de l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
```php
  # Instancier la classe Presentation qui représente le fichier de présentation
  $pres = new Presentation();
  try {
    # Instancier la classe SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Ajouter une diapositive vide à la collection Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Effectuer des opérations sur la diapositive nouvellement ajoutée
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


## **FAQ**

**Puis-je insérer une nouvelle diapositive à une position spécifique, pas seulement à la fin ?**

Oui. La bibliothèque prend en charge les collections de diapositives et les opérations [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) , vous pouvez donc ajouter une diapositive à l'index requis plutôt qu'à la fin uniquement.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une mise en page ?**

Oui. Une mise en page hérite du formatage de son master, et la nouvelle diapositive hérite de la mise en page sélectionnée ainsi que de son master associé.

**Quelle diapositive est présente dans une nouvelle présentation « vide » avant d'ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l'indice zéro. Cela est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la mise en page « appropriée » pour une nouvelle diapositive si le master propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) qui correspond à la structure requise ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). Si une telle mise en page est absente, vous pouvez la [l’ajouter au master](/slides/fr/php-java/slide-layout/) et l'utiliser ensuite.