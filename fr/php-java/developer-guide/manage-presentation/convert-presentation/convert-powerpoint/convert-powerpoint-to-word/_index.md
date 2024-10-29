---
title: Convertir PowerPoint en Word
type: docs
weight: 110
url: /fr/php-java/convert-powerpoint-to-word/
keywords: "Convertir PowerPoint, PPT, PPTX, Présentation, Word, DOCX, DOC, PPTX en DOCX, PPT en DOC, PPTX en DOC, PPT en DOCX, Java, java, Aspose.Slides"
description: "Convertir une présentation PowerPoint en Word"
---

Si vous prévoyez d'utiliser du contenu textuel ou des informations d'une présentation (PPT ou PPTX) de nouvelles manières, vous pourriez bénéficier de la conversion de la présentation en Word (DOC ou DOCX).

* Comparé à Microsoft PowerPoint, l'application Microsoft Word est équipée de davantage d'outils ou de fonctionnalités pour le contenu.
* En plus des fonctions d'édition dans Word, vous pourriez également bénéficier de fonctionnalités améliorées de collaboration, d'impression et de partage.

{{% alert color="primary" %}} 

Vous pourriez vouloir essayer notre [**Convertisseur en ligne de Présentation en Word**](https://products.aspose.app/slides/conversion/ppt-to-word) pour voir ce que vous pourriez tirer de l'utilisation de contenu textuel à partir de diapositives.

{{% /alert %}} 

## **Aspose.Slides et Aspose.Words**

Pour convertir un fichier PowerPoint (PPTX ou PPT) en Word (DOCX ou DOCX), vous avez besoin de [Aspose.Slides pour PHP via Java](https://products.aspose.com/slides/php-java/) et [Aspose.Words pour Java](https://products.aspose.com/words/php-java/).

En tant qu'API autonome, [Aspose.Slides](https://products.aspose.app/slides) pour Java fournit des fonctions qui vous permettent d'extraire des textes de présentations.

[Aspose.Words](https://docs.aspose.com/words/php-java/) est une API avancée de traitement de documents qui permet aux applications de générer, modifier, convertir, rendre, imprimer des fichiers et effectuer d'autres tâches avec des documents sans utiliser Microsoft Word.

## **Convertir PowerPoint en Word**

1. Téléchargez les bibliothèques [Aspose.Slides pour PHP via Java](https://downloads.aspose.com/slides/java) et [Aspose.Words pour Java](https://downloads.aspose.com/words/java).
2. Ajoutez *aspose-slides-x.x-jdk16.jar* et *aspose-words-x.x-jdk16.jar* à votre CLASSPATH.
3. Utilisez cet extrait de code pour convertir PowerPoint en Word :

```php
  $pres = new Presentation($inputPres);
  try {
    $doc = new Document();
    $builder = new DocumentBuilder($doc);
    foreach($pres->getSlides() as $slide) {
      # génère et insère l'image de la diapositive
      $bitmap = $slide->getThumbnail(1, 1);
      $builder->insertImage($bitmap);
      # insère les textes de la diapositive
      foreach($slide->getShapes() as $shape) {
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
          $builder->writeln($shape->getTextFrame()->getText());
        }
      }
      $builder->insertBreak(BreakType::PAGE_BREAK);
    }
    $doc->save($outputDoc);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```