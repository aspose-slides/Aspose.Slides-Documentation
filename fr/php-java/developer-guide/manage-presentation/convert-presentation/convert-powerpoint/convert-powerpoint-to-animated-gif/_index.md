---
title: Convertir des présentations PowerPoint en GIF animés en PHP
linktitle: PowerPoint en GIF
type: docs
weight: 65
url: /fr/php-java/convert-powerpoint-to-animated-gif/
keywords:
- GIF animé
- convertir PowerPoint
- convertir la présentation
- convertir la diapositive
- convertir PPT
- convertir PPTX
- PowerPoint en GIF
- présentation en GIF
- diapositive en GIF
- PPT en GIF
- PPTX en GIF
- enregistrer PPT en GIF
- enregistrer PPTX en GIF
- exporter PPT en GIF
- exporter PPTX en GIF
- paramètres par défaut
- paramètres personnalisés
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Convertissez facilement des présentations PowerPoint (PPT, PPTX) en GIF animés avec Aspose.Slides pour PHP via Java. Résultats rapides et de haute qualité."
---

## **Convertir des présentations en GIF animé avec les paramètres par défaut**

Ce code d'exemple vous montre comment convertir une présentation en GIF animé en utilisant les paramètres standard :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


Le GIF animé sera créé avec les paramètres par défaut. 

{{% alert title="ASTUCE" color="primary" %}} 
Si vous préférez personnaliser les paramètres du GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). Voir le code d'exemple ci-dessous.
{{% /alert %}} 

## **Convertir des présentations en GIF animé avec des paramètres personnalisés**
Ce code d'exemple vous montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// la taille du GIF résultant

    $gifOptions->setDefaultDelay(2000);// durée d'affichage de chaque diapositive avant de passer à la suivante

    $gifOptions->setTransitionFps(35);// augmenter le FPS pour améliorer la qualité de l'animation de transition

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


{{% alert title="Info" color="info" %}}
Vous pourriez vouloir essayer un convertisseur GRATUIT [Text to GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose. 
{{% /alert %}}

## **FAQ**

**Et si les polices utilisées dans la présentation ne sont pas installées sur le système ?**

Installez les polices manquantes ou [configurez les polices de secours](/slides/fr/php-java/powerpoint-fonts/). Aspose.Slides les remplacera, mais l'apparence peut différer. Pour l'image de marque, assurez-vous toujours que les polices requises sont explicitement disponibles.

**Puis-je superposer un filigrane sur les images du GIF ?**

Oui. [Ajoutez un objet/logo semi-transparent](/slides/fr/php-java/watermark/) à la diapositive maîtresse ou aux diapositives individuelles avant l'exportation — le filigrane apparaîtra sur chaque image.