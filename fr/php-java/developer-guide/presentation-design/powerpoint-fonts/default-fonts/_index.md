---
title: Polices par Défaut - PowerPoint Java API
linktitle: Polices par Défaut
type: docs
weight: 30
url: /php-java/default-font/
description: PowerPoint Java API vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou en vignettes. Cet article montre comment définir la police DefaultRegular et la police DefaultAsian à utiliser comme polices par défaut.
---


## **Utiliser des Polices par Défaut pour le Rendu de la Présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou en vignettes. Cet article montre comment définir la police DefaultRegular et la police DefaultAsian à utiliser comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices depuis des répertoires externes en utilisant Aspose.Slides pour PHP via Java API :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions).
1. [Définissez la DefaultRegularFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultRegularFont-java.lang.String-) sur votre police souhaitée. Dans l'exemple suivant, j'ai utilisé Wingdings.
1. [Définissez la DefaultAsianFont](https://reference.aspose.com/slides/php-java/aspose.slides/LoadOptions#setDefaultAsianFont-java.lang.String-) sur votre police souhaitée. J'ai utilisé Wingdings dans l'échantillon suivant.
1. Chargez la présentation en utilisant Presentation et en définissant les options de chargement.
1. Maintenant, générez la vignette de la diapositive, le PDF et le XPS pour vérifier les résultats.

L'implémentation de ce qui précède est donnée ci-dessous.

```php
  # Utiliser des options de chargement pour définir les polices régulières et asiatiques par défaut
  $loadOptions = new LoadOptions(LoadFormat::Auto);
  $loadOptions->setDefaultRegularFont("Wingdings");
  $loadOptions->setDefaultAsianFont("Wingdings");
  # Charger la présentation
  $pres = new Presentation("DefaultFonts.pptx", $loadOptions);
  try {
    # Générer la vignette de la diapositive
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1, 1);
    try {
      # sauvegarder l'image sur le disque.
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
    # Générer le PDF
    $pres->save("output_out.pdf", SaveFormat::Pdf);
    # Générer le XPS
    $pres->save("output_out.xps", SaveFormat::Xps);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```