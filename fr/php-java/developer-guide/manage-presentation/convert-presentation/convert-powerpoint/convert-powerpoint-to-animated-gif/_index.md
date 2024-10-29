---
title: Convertir PowerPoint en GIF animé
type: docs
weight: 65
url: /fr/php-java/convert-powerpoint-to-animated-gif/
keywords: "Convertir PowerPoint en GIF animé, PPT en GIF, PPTX en GIF"
description: "Convertir PowerPoint en GIF animé : PPT en GIF, PPTX en GIF, avec l'API Aspose.Slides."
---

## Conversion des présentations en GIF animé avec les paramètres par défaut ##

Ce code d'exemple vous montre comment convertir une présentation en GIF animé en utilisant les paramètres standards :

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

Le GIF animé sera créé avec des paramètres par défaut.

{{%  alert  title="CONSEIL"  color="primary"  %}} 

Si vous souhaitez personnaliser les paramètres pour le GIF, vous pouvez utiliser la classe [GifOptions](https://reference.aspose.com/slides/php-java/aspose.slides/GifOptions). Consultez le code d'exemple ci-dessous.

{{% /alert %}} 

## Conversion des présentations en GIF animé avec des paramètres personnalisés ##
Ce code d'exemple montre comment convertir une présentation en GIF animé en utilisant des paramètres personnalisés :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// la taille du GIF résultant

    $gifOptions->setDefaultDelay(2000);// combien de temps chaque diapositive sera affichée avant de passer à la suivante

    $gifOptions->setTransitionFps(35);// augmenter le FPS pour une meilleure qualité d'animation de transition

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}

Vous voudrez peut-être consulter un convertisseur GRATUIT [Texte en GIF](https://products.aspose.app/slides/text-to-gif) développé par Aspose.

{{% /alert %}}