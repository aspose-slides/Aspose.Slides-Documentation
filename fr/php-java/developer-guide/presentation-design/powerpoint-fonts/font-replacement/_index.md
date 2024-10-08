---
title: Remplacement de police - API Java PowerPoint
linktitle: Remplacement de police
type: docs
weight: 60
url: /fr/php-java/font-replacement/
description: Apprenez comment remplacer des polices en utilisant la méthode de remplacement explicite dans PowerPoint avec l'API Java.
---

Si vous changez d'avis concernant l'utilisation d'une police, vous pouvez remplacer cette police par une autre. Toutes les instances de l'ancienne police seront remplacées par la nouvelle police.

Aspose.Slides vous permet de remplacer une police de cette manière :

1. Chargez la présentation concernée.
2. Chargez la police qui sera remplacée.
3. Chargez la nouvelle police.
4. Remplacez la police.
5. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code PHP démontre le remplacement de police :

```php
  # Charge une présentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Charge la police source qui sera remplacée
    $sourceFont = new FontData("Arial");
    # Charge la nouvelle police
    $destFont = new FontData("Times New Roman");
    # Remplace les polices
    $pres->getFontsManager()->replaceFont($sourceFont, $destFont);
    # Sauvegarde la présentation
    $pres->save("UpdatedFont_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Pour définir des règles qui déterminent ce qui se passe dans certaines conditions (si une police ne peut pas être accédée, par exemple), voir [**Substitution de police**](/slides/fr/php-java/font-substitution/).

{{% /alert %}}