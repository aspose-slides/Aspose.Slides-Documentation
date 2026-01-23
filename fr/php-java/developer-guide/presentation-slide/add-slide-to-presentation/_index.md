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
description: "Ajoutez facilement des diapositives à vos présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides for PHP via Java — insertion fluide et efficace de diapositives en quelques secondes."
---

## **Ajouter une diapositive à une présentation**
{{% alert color="primary" %}} 

Avant de parler de l'ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Master / Layout** et d'autres diapositives **Normal**. Cela signifie qu'un fichier de présentation contient au moins une diapositive ou plus. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides for PHP via Java. Chaque diapositive possède un Id unique et toutes les diapositives Normales sont organisées dans un ordre spécifié par l'index basé sur zéro.

{{% /alert %}} 

Aspose.Slides for PHP via Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide dans la présentation, veuillez suivre les étapes ci‑dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Obtenez l'objet [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) en utilisant la méthode [getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (collection d'objets Slide) exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Ajoutez une diapositive vide à la présentation à la fin de la collection des diapositives de contenu en appelant la méthode **addEmptySlide** exposée par l'objet [SlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/).
- Effectuez des opérations avec la diapositive vide nouvellement ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
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

Oui. La bibliothèque prend en charge les collections de diapositives et les opérations [insert](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/insertclone/) , vous permettant d'ajouter une diapositive à l'index requis plutôt qu'à la fin uniquement.

**Les thèmes/styles sont-ils conservés lors de l'ajout d'une diapositive basée sur une disposition ?**

Oui. Une disposition hérite du formatage de son maître, et la nouvelle diapositive hérite de la disposition sélectionnée et de son maître associé.

**Quelle diapositive est présente dans une nouvelle « vide » présentation avant d'ajouter des diapositives ?**

Une présentation nouvellement créée contient déjà une diapositive vierge avec l'index zéro. Ceci est important à prendre en compte lors du calcul des indices d'insertion.

**Comment choisir la disposition « appropriée » pour une nouvelle diapositive si le maître propose de nombreuses options ?**

En général, choisissez le [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) qui correspond à la structure requise ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/php-java/aspose.slides/slidelayouttype/)). Si une telle disposition est absente, vous pouvez [add it to the master](/slides/fr/php-java/slide-layout/) et ensuite l’utiliser.