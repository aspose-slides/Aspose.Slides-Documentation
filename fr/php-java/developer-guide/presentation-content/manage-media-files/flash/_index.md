---
title: Extraire des objets Flash des présentations en PHP
linktitle: Flash
type: docs
weight: 10
url: /fr/php-java/flash/
keywords:
- extraire flash
- objet flash
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez comment extraire des objets Flash des diapositives PowerPoint et OpenDocument avec Aspose.Slides pour PHP via Java, exemples de code complets et bonnes pratiques."
---

## **Extraire les objets Flash des présentations**

Aspose.Slides for PHP via Java fournit une fonctionnalité d'extraction des objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris stocker les données d'objet SWF.
```php
  # Instancier la classe Presentation qui représente le PPTX
  $pres = new Presentation();
  try {
    $controls = $pres->getSlides()->get_Item(0)->getControls();
    $flashControl = null;
    foreach($controls as $control) {
      if (java_values($control->getName()) == "ShockwaveFlash1") {
        $flashControl = $control;
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Quels formats de présentation sont pris en charge lors de l'extraction du contenu Flash ?**

[Aspose.Slides prend en charge](/slides/fr/php-java/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés au Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 tout en conservant l'interactivité du Flash ?**

Non. Aspose.Slides n'exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l'exportation vers [HTML](/slides/fr/php-java/convert-powerpoint-to-html/)/[HTML5](/slides/fr/php-java/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin de son support. Le chemin recommandé consiste à remplacer le Flash par des alternatives telles que la vidéo ou les animations HTML5 avant l'exportation.

**D'un point de vue sécurité, Aspose.Slides exécute-t-il des fichiers SWF lors de la lecture d'une présentation ?**

Non. Aspose.Slides traite le Flash comme des données binaires incorporées au fichier et n'exécute pas le contenu SWF pendant le traitement.

**Comment dois-je gérer les présentations qui incluent du Flash ainsi que d'autres fichiers incorporés via OLE ?**

Aspose.Slides prend en charge [l'extraction des objets OLE incorporés](/slides/fr/php-java/manage-ole/), vous pouvez donc traiter tout le contenu incorporé en une seule passe, en gérant les contrôles Flash et les autres documents OLE incorporés ensemble.