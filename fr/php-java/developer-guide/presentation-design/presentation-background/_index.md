---
title: "Gestion des arrière-plans de présentation en PHP"
linktitle: "Arrière-plan de diapositive"
type: docs
weight: 20
url: /fr/php-java/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- couleur dégradée
- arrière-plan image
- transparence d'arrière-plan
- propriétés d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour PHP via Java, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d'ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés pour les arrière-plans de diapositives. Vous pouvez définir l'arrière-plan d'une **diapositive normale** (une seule diapositive) ou d'une **diapositive maîtresse** (s'applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière-plan de couleur unie pour une diapositive normale**

Aspose.Slides permet de définir une couleur unie comme arrière-plan d'une diapositive spécifique d'une présentation — même si la présentation utilise une diapositive maîtresse. La modification s'applique uniquement à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de l'arrière-plan de la diapositive sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) sur [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour spécifier la couleur d'arrière-plan unie.
5. Enregistrez la présentation modifiée.

L'exemple PHP suivant montre comment définir une couleur bleue unie comme arrière-plan d'une diapositive normale :
```php
// Créez une instance de la classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Définissez la couleur d'arrière-plan de la diapositive en bleu.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $slide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    
    // Enregistrez la présentation sur le disque.
    $presentation->save("SolidColorBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Définir un arrière-plan de couleur unie pour une diapositive maîtresse**

Aspose.Slides permet de définir une couleur unie comme arrière-plan de la diapositive maîtresse d'une présentation. La diapositive maîtresse agit comme un modèle qui contrôle le formatage de toutes les diapositives ; ainsi, lorsque vous choisissez une couleur unie pour l'arrière-plan de la diapositive maîtresse, elle s'applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositive maîtresse (via `getMasters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de l'arrière-plan de la diapositive maîtresse sur `Solid`.
4. Utilisez la méthode [getSolidFillColor](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getSolidFillColor) pour spécifier la couleur d'arrière-plan unie.
5. Enregistrez la présentation modifiée.

L'exemple PHP suivant montre comment définir une couleur verte unie comme arrière-plan d'une diapositive maîtresse :
```php
// Créez une instance de la classe Presentation.
$presentation = new Presentation();
try {
    $masterSlide = $presentation->getMasters()->get_Item(0);

    // Définissez la couleur d'arrière-plan de la diapositive maître en vert forêt.
    $masterSlide->getBackground()->setType(BackgroundType::OwnBackground);
    $masterSlide->getBackground()->getFillFormat()->setFillType(FillType::Solid);
    $masterSlide->getBackground()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);

    // Enregistrez la présentation sur le disque.
    $presentation->save("MasterSlideBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Définir un arrière-plan dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une transition progressive de couleur. Lorsqu'il est utilisé comme arrière-plan de diapositive, les dégradés peuvent rendre les présentations plus artistiques et professionnelles. Aspose.Slides permet de définir une couleur de dégradé comme arrière-plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de l'arrière-plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [getGradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getGradientFormat) sur [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L'exemple PHP suivant montre comment définir une couleur de dégradé comme arrière-plan d'une diapositive :
```php
// Créez une instance de la classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Appliquez un effet de dégradé à l'arrière-plan.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Gradient);
    $slide->getBackground()->getFillFormat()->getGradientFormat()->setTileFlip(TileFlip::FlipBoth);

    // Enregistrez la présentation sur le disque.
    $presentation->save("GradientBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


## **Définir une image comme arrière-plan de diapositive**

En plus des remplissages unis et dégradés, Aspose.Slides permet d'utiliser des images comme arrière-plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/php-java/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) de l'arrière-plan de la diapositive sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la méthode [getPictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#getPictureFillFormat) sur [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pour attribuer l'image comme arrière-plan.
7. Enregistrez la présentation modifiée.

L'exemple PHP suivant montre comment définir une image comme arrière-plan d'une diapositive :
```php
// Créez une instance de la classe Presentation.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Définissez les propriétés de l'image d'arrière-plan.
    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    // Chargez l'image.
    $image = Images::fromFile("Tulips.jpg");
    // Ajoutez l'image à la collection d'images de la présentation.
    $ppImage = $presentation->getImages()->addImage($image);
    $image->dispose();

    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    // Enregistrez la présentation sur le disque.
    $presentation->save("ImageAsBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


L'exemple de code suivant montre comment définir le type de remplissage d'arrière-plan sur une image en mosaïque et modifier les propriétés de mosaïquage :
```php
$presentation = new Presentation();
try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    $background = $firstSlide->getBackground();

    $background->setType(BackgroundType::OwnBackground);
    $background->getFillFormat()->setFillType(FillType::Picture);

    $newImage = Images::fromFile("image.png");
    $ppImage = $presentation->getImages()->addImage($newImage);
    $newImage->dispose();

    // Définir l'image utilisée pour le remplissage d'arrière-plan.
    $backPictureFillFormat = $background->getFillFormat()->getPictureFillFormat();
    $backPictureFillFormat->getPicture()->setImage($ppImage);

    // Définir le mode de remplissage d'image sur Carreau et ajuster les propriétés du carrelage.
    $backPictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $backPictureFillFormat->setTileOffsetX(15);
    $backPictureFillFormat->setTileOffsetY(15);
    $backPictureFillFormat->setTileScaleX(46);
    $backPictureFillFormat->setTileScaleY(87);
    $backPictureFillFormat->setTileAlignment(RectangleAlignment::Center);
    $backPictureFillFormat->setTileFlip(TileFlip::FlipY);

    $presentation->save("TileBackground.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```


{{% alert color="primary" %}}

En savoir plus : [**Tile Picture As Texture**](/slides/fr/php-java/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Modifier la transparence de l'image d'arrière-plan**

Vous pouvez souhaiter ajuster la transparence de l'image d'arrière-plan d'une diapositive afin de faire ressortir le contenu de la diapositive. Le code PHP suivant montre comment modifier la transparence d'une image d'arrière-plan de diapositive :
```php
$transparencyValue = 30; // Par exemple.

// Get the collection of picture transform operations.
$imageTransform = $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();

// Find an existing fixed-percentage transparency effect.
$transparencyOperation = null;
foreach($imageTransform as $operation) {
    if (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
        $transparencyOperation = $operation;
        break;
    }
}

// Set the new transparency value.
if (java_is_null($transparencyOperation)) {
    $imageTransform->addAlphaModulateFixedEffect(100 - $transparencyValue);
} else {
    $transparencyOperation->setAmount(100 - $transparencyValue);
}
```


## **Obtenir la valeur d'arrière-plan de la diapositive**

Aspose.Slides fournit la classe `BackgroundEffectiveData` pour récupérer les valeurs d'arrière-plan effectives d'une diapositive. Cette classe expose le [FillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/php-java/aspose.slides/effectformat/) effectifs.

En utilisant la méthode `getBackground` de la classe [BaseSlide](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/), vous pouvez obtenir l'arrière-plan effectif d'une diapositive.

L'exemple PHP suivant montre comment obtenir la valeur d'arrière-plan effectif d'une diapositive :
```php
// Créez une instance de la classe Presentation.
$presentation = new Presentation("Sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Récupérez l'arrière-plan effectif, en tenant compte du maître, de la disposition et du thème.
    $effBackground = $slide->getBackground()->getEffective();

    if ($effBackground->getFillFormat()->getFillType() == FillType::Solid)
        echo "Fill color: " . $effBackground->getFillFormat()->getSolidFillColor() . "\n";
    else
        echo "Fill type: " . $effBackground->getFillFormat()->getFillType() . "\n";
} finally {
    $presentation->dispose();
}
```


## **FAQ**

**Puis-je réinitialiser un arrière-plan personnalisé et restaurer l'arrière-plan du thème/de la mise en page ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l'arrière-plan sera à nouveau hérité de la diapositive [mise en page](/slides/fr/php-java/slide-layout/)/[maîtresse](/slides/fr/php-java/slide-master/) correspondante (c’est‑à‑dire du [arrière-plan du thème](/slides/fr/php-java/presentation-theme/)).

**Que se passe-t-il avec l'arrière-plan si je change le thème de la présentation plus tard ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l'arrière-plan est hérité de la [mise en page](/slides/fr/php-java/slide-layout/)/[maîtresse](/slides/fr/php-java/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/php-java/presentation-theme/).