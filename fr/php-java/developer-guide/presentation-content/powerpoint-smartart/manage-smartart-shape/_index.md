---
title: Gérer les graphiques SmartArt dans les présentations avec PHP
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/php-java/manage-smartart-shape/
keywords:
- Objet SmartArt
- Graphique SmartArt
- Style SmartArt
- Couleur SmartArt
- créer SmartArt
- ajouter SmartArt
- modifier SmartArt
- changer SmartArt
- accéder SmartArt
- type de mise en page SmartArt
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Automatiser la création, la modification et le style des SmartArt PowerPoint en PHP avec Aspose.Slides, avec des exemples de code concis et des conseils axés sur la performance."
---

## **Créer une forme SmartArt**
Aspose.Slides for PHP via Java propose une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d’une diapositive en utilisant son Index.
1. [Ajoutez une forme SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en définissant son [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Enregistrez la présentation modifiée au format PPTX.
```php
  # Instancier la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une forme Smart Art
    $smart = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::BasicBlockList);
    # Enregistrement de la présentation
    $pres->save("SimpleSmartArt.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : forme SmartArt ajoutée à la diapositive**|

## **Accéder à une forme SmartArt sur une diapositive**
Le code suivant permet d’accéder aux formes SmartArt ajoutées dans une diapositive de présentation. Dans l’exemple, nous parcourrons chaque forme de la diapositive et vérifierons si elle est une forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Si la forme est de type SmartArt, nous la convertirons en instance de **SmartArt**.
```php
  # Charger la présentation souhaitée
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Parcourir chaque forme dans la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        echo("Shape Name:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Accéder à une forme SmartArt avec un type de mise en page particulier**
Le code d’exemple suivant aide à accéder à la forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) avec un LayoutType spécifique : veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et ne peut être défini que lors de l’ajout de la forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation contenant une forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l’intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) et convertissez la forme sélectionnée en SmartArt si c’est le cas.
1. Vérifiez la forme SmartArt avec le LayoutType particulier et effectuez les actions requises par la suite.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Parcourir chaque forme dans la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        # Vérifier le Layout SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Do some thing here....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Modifier le style d’une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style rapide pour toute forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation contenant une forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l’intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) et convertissez la forme sélectionnée en SmartArt si c’est le cas.
1. Trouvez la forme SmartArt avec le Style particulier.
1. Appliquez le nouveau style à la forme SmartArt.
1. Enregistrez la présentation.
```php
  # Instancier la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourir chaque forme de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        # Vérifier le style SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Modifier le style SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Enregistrement de la présentation
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : forme SmartArt avec le style modifié**|

## **Modifier le style de couleur d’une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style de couleur pour toute forme SmartArt. Le code d’exemple suivant accède à la forme SmartArt avec un style de couleur particulier et le modifie.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation contenant une forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l’intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) et convertissez la forme sélectionnée en SmartArt si c’est le cas.
1. Trouvez la forme SmartArt avec le style de couleur particulier.
1. Appliquez le nouveau style de couleur à la forme SmartArt.
1. Enregistrez la présentation.
```php
  # Instancier la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourir chaque forme de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        # Vérifier le type de couleur SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Modifier le type de couleur SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Enregistrement de la présentation
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure : forme SmartArt avec le style de couleur modifié**|

## **FAQ**

**Puis‑je animer SmartArt comme un seul objet ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/php-java/powerpoint-animation/) via l’API d’animations (entrée, sortie, mise en valeur, chemins de mouvement) comme pour les autres formes.

**Comment puis‑je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme par cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis‑je regrouper SmartArt avec d’autres formes ?**

Oui. Vous pouvez regrouper SmartArt avec d’autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/php-java/group/).

**Comment obtenir une image d’un SmartArt spécifique (par ex., pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre les formes individuelles](/slides/fr/php-java/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L’apparence du SmartArt sera‑t‑elle conservée lors de la conversion de la présentation entière en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l’[export PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), avec diverses options de qualité et de compatibilité.