---
title: Gérer les formes SmartArt
type: docs
weight: 20
url: /fr/php-java/manage-smartart-shape/
---


## **Créer une forme SmartArt**
Aspose.Slides pour PHP via Java a fourni une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
1. Obtenez la référence d'une diapositive en utilisant son Index.
1. [Ajoutez une forme SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) en définissant son [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
1. Enregistrez la présentation modifiée en tant que fichier PPTX.

```php
  # Instancier la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter la forme Smart Art
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
|**Figure : Forme SmartArt ajoutée à la diapositive**|

## **Accéder à la forme SmartArt dans la diapositive**
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans le code d'exemple, nous parcourrons chaque forme dans la diapositive et vérifierons si c'est une forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Si la forme est de type SmartArt, nous la typons en instance de [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

```php
  # Charger la présentation désirée
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Parcourir chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typage de la forme à SmartArtEx
        $smart = $shape;
        echo("Nom de la forme:" . $smart->getName());
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Accéder à la forme SmartArt avec un type de mise en page particulier**
Le code d'exemple suivant vous aidera à accéder à la forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) avec un LayoutType particulier : veuillez noter que vous ne pouvez pas changer le LayoutType du SmartArt car il est en lecture seule et est défini uniquement lorsque la forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) est ajoutée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) et typifiez la forme sélectionnée en SmartArt si c'est un SmartArt.
1. Vérifiez la forme SmartArt avec un LayoutType particulier et effectuez ce qui est requis par la suite.

```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Parcourir chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typage de la forme à SmartArtEx
        $smart = $shape;
        # Vérification de la mise en page du SmartArt
        if ($smart->getLayout() == SmartArtLayoutType::BasicBlockList) {
          echo("Faites quelque chose ici....");
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Changer le style de forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style rapide pour toute forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) et typifiez la forme sélectionnée en SmartArt si c'est un SmartArt.
1. Trouvez la forme SmartArt avec un style particulier.
1. Définissez le nouveau style pour la forme SmartArt.
1. Enregistrez la présentation.

```php
  # Instancier la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourir chaque forme à l'intérieur de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typage de la forme à SmartArtEx
        $smart = $shape;
        # Vérification du style SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Changer le style SmartArt
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
|**Figure : Forme SmartArt avec style modifié**|

## **Changer le style de couleur de la forme SmartArt**
Dans cet exemple, nous allons apprendre à changer le style de couleur pour toute forme SmartArt. Dans le code d'exemple suivant, nous accéderons à la forme SmartArt avec un style de couleur particulier et modifierons son style.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et chargez la présentation avec la forme SmartArt.
1. Obtenez la référence de la première diapositive en utilisant son Index.
1. Parcourez chaque forme à l'intérieur de la première diapositive.
1. Vérifiez si la forme est de type [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) et typifiez la forme sélectionnée en SmartArt si c'est un SmartArt.
1. Trouvez la forme SmartArt avec un style de couleur particulier.
1. Définissez le nouveau style de couleur pour la forme SmartArt.
1. Enregistrez la présentation.

```php
  # Instancier la classe Presentation
  $pres = new Presentation("SimpleSmartArt.pptx");
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Parcourir chaque forme à l'intérieur de la première diapositive
    foreach($slide->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Typage de la forme à SmartArtEx
        $smart = $shape;
        # Vérification du type de couleur SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Changer le type de couleur SmartArt
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
|**Figure : Forme SmartArt avec style de couleur modifié**|