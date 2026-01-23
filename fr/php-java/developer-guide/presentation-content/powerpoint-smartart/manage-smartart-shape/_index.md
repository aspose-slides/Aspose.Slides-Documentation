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
- Créer SmartArt
- Ajouter SmartArt
- Modifier SmartArt
- Changer SmartArt
- Accéder à SmartArt
- Type de disposition SmartArt
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Automatisez la création, la modification et le stylisme des SmartArt PowerPoint en PHP avec Aspose.Slides, en proposant des exemples de code concis et des conseils axés sur la performance."
---

## **Créer une forme SmartArt**
Aspose.Slides for PHP via Java a fourni une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, veuillez suivre les étapes ci-dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenir la référence d'une diapositive en utilisant son Index.
3. [Ajouter une forme SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addSmartArt) en définissant son [LayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArtLayoutType).
4. Enregistrer la présentation modifiée au format PPTX.
```php
  # Instancier la classe Presentation
  $pres = new Presentation();
  try {
    # Obtenir la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajouter une forme SmartArt
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
Le code suivant sera utilisé pour accéder aux formes SmartArt ajoutées dans la diapositive de la présentation. Dans le code d'exemple, nous parcourrons chaque forme de la diapositive et vérifierons s'il s'agit d'une forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt). Si la forme est du type SmartArt, nous la convertirons en instance [**SmartArt**](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).
```php
  # Charger la présentation souhaitée
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Parcourir chaque forme à l'intérieur de la première diapositive
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


## **Accéder à une forme SmartArt avec un type de disposition particulier**
Le code d'exemple suivant aidera à accéder à la forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt) avec un LayoutType particulier. Veuillez noter que vous ne pouvez pas modifier le LayoutType du SmartArt car il est en lecture seule et ne est défini que lors de l'ajout de la forme [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/SmartArt).

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son Index.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt] et convertir la forme sélectionnée en SmartArt si c'est le cas.
5. Vérifier la forme SmartArt avec le LayoutType particulier et effectuer les actions requises par la suite.
```php
  $pres = new Presentation("AccessSmartArtShape.pptx");
  try {
    # Parcourir chaque forme à l'intérieur de la première diapositive
    foreach($pres->getSlides()->get_Item(0)->getShapes() as $shape) {
      # Vérifier si la forme est de type SmartArt
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        # Vérifier la disposition SmartArt
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


## **Modifier le style d'une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style rapide d'une forme SmartArt.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son Index.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt] et convertir la forme sélectionnée en SmartArt si c'est le cas.
5. Trouver la forme SmartArt avec un style particulier.
6. Définir le nouveau style pour la forme SmartArt.
7. Enregistrer la présentation.
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
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        # Vérifier le style SmartArt
        if ($smart->getQuickStyle() == SmartArtQuickStyleType::SimpleFill) {
          # Modifier le style SmartArt
          $smart->setQuickStyle(SmartArtQuickStyleType::Cartoon);
        }
      }
    }
    # Enregistrer la présentation
    $pres->save("ChangeSmartArtStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure : forme SmartArt avec style modifié**|

## **Modifier le style de couleur d'une forme SmartArt**
Dans cet exemple, nous apprendrons à modifier le style de couleur d'une forme SmartArt. Le code d'exemple suivant accédera à la forme SmartArt avec un style de couleur particulier et en modifiera le style.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et charger la présentation contenant une forme SmartArt.
2. Obtenir la référence de la première diapositive en utilisant son Index.
3. Parcourir chaque forme de la première diapositive.
4. Vérifier si la forme est du type [SmartArt] et convertir la forme sélectionnée en SmartArt si c'est le cas.
5. Trouver la forme SmartArt avec un style de couleur particulier.
6. Définir le nouveau style de couleur pour la forme SmartArt.
7. Enregistrer la présentation.
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
        # Convertir la forme en SmartArtEx
        $smart = $shape;
        # Vérifier le type de couleur SmartArt
        if ($smart->getColorStyle() == SmartArtColorType::ColoredFillAccent1) {
          # Modifier le type de couleur SmartArt
          $smart->setColorStyle(SmartArtColorType::ColorfulAccentColors);
        }
      }
    }
    # Enregistrer la présentation
    $pres->save("ChangeSmartArtColorStyle.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```


|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure : forme SmartArt avec style de couleur modifié**|

## **FAQ**

**Puis-je animer le SmartArt comme un seul objet ?**

Oui. Le SmartArt est une forme, vous pouvez donc appliquer les [standard animations](/slides/fr/php-java/powerpoint-animation/) via l'API d'animations (entrée, sortie, mise en emphase, trajectoires de mouvement) comme pour les autres formes.

**Comment puis-je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme à l'aide de cette valeur - c'est une méthode recommandée pour localiser la forme cible.

**Puis-je grouper le SmartArt avec d'autres formes ?**

Oui. Vous pouvez grouper le SmartArt avec d'autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/php-java/group/).

**Comment obtenir une image d'un SmartArt spécifique (par ex., pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme; la bibliothèque peut [render individual shapes](/slides/fr/php-java/create-shape-thumbnails/) en fichiers raster (PNG/JPG/TIFF).

**L'apparence du SmartArt sera-t-elle conservée lors de la conversion de la présentation entière en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l'[PDF export](/slides/fr/php-java/convert-powerpoint-to-pdf/), avec un éventail d'options de qualité et de compatibilité.