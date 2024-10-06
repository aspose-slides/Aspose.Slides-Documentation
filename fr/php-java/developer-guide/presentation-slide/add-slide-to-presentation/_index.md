---
title: Ajouter une diapositive à la présentation
type: docs
weight: 10
url: /php-java/add-slide-to-presentation/
---

## **Ajouter une diapositive à la présentation**
{{% alert color="primary" %}} 

Avant de parler de l’ajout de diapositives aux fichiers de présentation, discutons de quelques faits concernant les diapositives. Chaque fichier de présentation PowerPoint contient une diapositive **Maître / Mise en Page** et d'autres diapositives **Normales**. Cela signifie qu'un fichier de présentation contient au moins une ou plusieurs diapositives. Il est important de savoir que les fichiers de présentation sans diapositives ne sont pas pris en charge par Aspose.Slides pour PHP via Java. Chaque diapositive possède un identifiant unique et toutes les diapositives normales sont arrangées dans un ordre spécifié par l’index basé sur zéro.

{{% /alert %}} 

Aspose.Slides pour PHP via Java permet aux développeurs d'ajouter des diapositives vides à leur présentation. Pour ajouter une diapositive vide à la présentation, veuillez suivre les étapes ci-dessous :

- Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Instanciez la classe [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection) en faisant référence à la propriété [Slides](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#getSlides--) (collection d'objets Slide de contenu) exposée par l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).
- Ajoutez une diapositive vide à la présentation à la fin de la collection de diapositives de contenu en appelant les méthodes [**addEmptySlide**](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) exposées par l'objet [ISlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/ISlideCollection).
- Effectuez des opérations sur la nouvelle diapositive vide ajoutée.
- Enfin, écrivez le fichier de présentation en utilisant l'objet [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation).

```php
  # Instancier la classe Presentation qui représente le fichier de présentation
  $pres = new Presentation();
  try {
    # Instancier la classe SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Ajouter une diapositive vide à la collection de diapositives
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Effectuer des opérations sur la diapositive nouvellement ajoutée
    # Enregistrer le fichier PPTX sur le disque
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```