---
title: Contexte de la Présentation
type: docs
weight: 20
url: /fr/php-java/presentation-background/
keywords: "contexte PowerPoint, définir le contexte "
description: "Définir le contexte dans une présentation PowerPoint "
---

Des couleurs unies, des dégradés et des images sont souvent utilisés comme images d'arrière-plan pour les diapositives. Vous pouvez définir l'arrière-plan soit pour une **diapositive normale** (diapositive unique) ou **diapositive maître** (plusieurs diapositives à la fois)

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Définir une Couleur Unie comme Arrière-plan pour une Diapositive Normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour une diapositive spécifique dans une présentation (même si cette présentation contient une diapositive maître). Le changement d'arrière-plan n'affecte que la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) pour l'arrière-plan de la diapositive sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) exposée par [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment définir une couleur unie (bleue) comme arrière-plan pour une diapositive normale :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Définit la couleur d'arrière-plan pour la première ISlide sur Bleu
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Écrit la présentation sur le disque
    $pres->save("ContentBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir une Couleur Unie comme Arrière-plan pour une Diapositive Maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour la diapositive maître d'une présentation. La diapositive maître agit comme un modèle qui contient et contrôle les paramètres de formatage pour toutes les diapositives. Par conséquent, lorsque vous sélectionnez une couleur unie comme arrière-plan pour la diapositive maître, ce nouvel arrière-plan sera utilisé pour toutes les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) pour la diapositive maître (`Masters`) sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) pour l'arrière-plan de la diapositive maître sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor--) exposée par [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour spécifier une couleur unie pour l'arrière-plan.
5. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment définir une couleur unie (vert forêt) comme arrière-plan pour une diapositive maître dans une présentation :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Définit la couleur d'arrière-plan pour la Master ISlide sur Vert Forêt
    $pres->getMasters()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $pres->getMasters()->get_Item(0)->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    # Écrit la présentation sur le disque
    $pres->save("MasterBG.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir une Couleur en Dégradé comme Arrière-plan pour une Diapositive**

Un dégradé est un effet graphique basé sur un changement progressif de couleur. Les couleurs en dégradé, lorsqu'elles sont utilisées comme arrière-plans pour des diapositives, donnent aux présentations un aspect artistique et professionnel. Aspose.Slides vous permet de définir une couleur en dégradé comme arrière-plan pour des diapositives dans des présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) pour l'arrière-plan de la diapositive maîtresse sur `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat--) exposée par [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour spécifier vos paramètres de dégradé préférés.
5. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment définir une couleur en dégradé comme arrière-plan pour une diapositive :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("MasterBG.pptx");
  try {
    # Applique l'effet de dégradé à l'arrière-plan
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip->FlipBoth);
    # Écrit la présentation sur le disque
    $pres->save("ContentBG_Grad.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir une Image comme Arrière-plan pour une Diapositive**

En plus des couleurs unies et des couleurs en dégradé, Aspose.Slides vous permet également de définir des images comme arrière-plan pour des diapositives dans des présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) pour l'arrière-plan de la diapositive maître sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat--) exposée par [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour définir l'image comme l'arrière-plan.
7. Enregistrez la présentation modifiée.

Ce code PHP vous montre comment définir une image comme arrière-plan pour une diapositive :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    # Définit les conditions pour l'image d'arrière-plan
    $pres->getSlides()->get_Item(0)->getBackground()->setType(BackgroundType::OwnBackground);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
    # Charge l'image
    $imgx;
    $image = Images->fromFile("Desert.jpg");
    try {
      $imgx = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Ajoute l'image à la collection d'images de la présentation
    $pres->getSlides()->get_Item(0)->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($imgx);
    # Écrit la présentation sur le disque
    $pres->save("ContentBG_Img.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Changer la Transparence de l'Image d'Arrière-plan**

Vous souhaiterez peut-être ajuster la transparence de l'image d'arrière-plan d'une diapositive pour mettre en avant le contenu de la diapositive. Ce code PHP vous montre comment changer la transparence pour une image d'arrière-plan de diapositive :

```php
  $transparencyValue = 30;// par exemple

  # Obtient une collection d'opérations de transformation d'image
  $imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  # Trouve un effet de transparence avec un pourcentage fixe.
  $transparencyOperation = null;
  foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
      $transparencyOperation = $operation;
      break;
    }
  }
  # Définit la nouvelle valeur de transparence.
  if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
  } else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
  }
```

## **Obtenir la Valeur de l'Arrière-plan de la Diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/) pour vous permettre d'obtenir les valeurs effectives des arrière-plans de diapositives. Cette interface contient des informations sur le [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getFillFormat--) effectif et l'[EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ibackgroundeffectivedata/#getEffectFormat--).

En utilisant la propriété [Background](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getBackground--) de la classe [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/), vous pouvez obtenir la valeur effective pour l'arrière-plan d'une diapositive.

Ce code PHP vous montre comment obtenir la valeur d'arrière-plan effective d'une diapositive :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation("SamplePresentation.pptx");
  try {
    $effBackground = $pres->getSlides()->get_Item(0)->getBackground()->getEffective();
    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid) {
      echo("Couleur de remplissage : " . $effBackground->getFillFormat()->getSolidFillColor());
    } else {
      echo("Type de remplissage : " . $effBackground->getFillFormat()->getFillType());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```