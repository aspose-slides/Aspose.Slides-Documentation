---
title: Formatage des Formes
type: docs
weight: 20
url: /php-java/shape-formatting/
keywords: "Format de forme, format de lignes, styles de jonction de format, remplissage dégradé, remplissage de motifs, remplissage d'image, remplissage de couleur unie, rotation des formes, effets de biseautage 3D, effet de rotation 3D, présentation PowerPoint, Java, Aspose.Slides pour PHP via Java"
description: "Formatage des formes dans une présentation PowerPoint"
---

Dans PowerPoint, vous pouvez ajouter des formes aux diapositives. Étant donné que les formes sont constituées de lignes, vous pouvez les formater en modifiant ou en appliquant certains effets à leurs lignes constitutives. De plus, vous pouvez formater les formes en spécifiant des paramètres qui déterminent comment elles (la zone en elles) sont remplies.

![format-shape-powerpoint](format-shape-powerpoint.png)

**Aspose.Slides pour PHP via Java** fournit des interfaces et des propriétés qui vous permettent de formater des formes en fonction des options connues dans PowerPoint.

## **Format de Lignes**

En utilisant Aspose.Slides, vous pouvez spécifier votre style de ligne préféré pour une forme. Ces étapes décrivent un tel procédé :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Définissez une couleur pour les lignes de la forme.
5. Définissez la largeur pour les lignes de la forme.
6. Définissez le [style de ligne](https://reference.aspose.com/slides/php-java/aspose.slides/LineStyle) pour la ligne de la forme.
7. Définissez le [style de tiret](https://reference.aspose.com/slides/php-java/aspose.slides/LineDashStyle) pour la ligne de la forme.
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP démontre une opération où nous avons formaté un rectangle `AutoShape` :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une autoforme de type rectangle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);
    # Définit la couleur de remplissage pour la forme rectangle
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->WHITE);
    # Applique un certain formatage sur les lignes du rectangle
    $shp->getLineFormat()->setStyle(LineStyle->ThickThin);
    $shp->getLineFormat()->setWidth(7);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->Dash);
    # Définit la couleur de la ligne du rectangle
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectShpLn_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Styles de Jonction de Format**
Voici les 3 options de type de jonction :

* Rond
* Miter
* Bevel

Par défaut, lorsque PowerPoint joint deux lignes à un angle (ou un coin de forme), il utilise le paramètre **Rond**. Cependant, si vous souhaitez dessiner une forme avec des angles très aigus, vous voudrez peut-être sélectionner **Miter**.

![join-style-powerpoint](join-style-powerpoint.png)

Ce Java démontre une opération où 3 rectangles (l'image ci-dessus) ont été créés avec les paramètres de types de jonction Miter, Bevel et Round :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute 3 formes rectangles
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 100, 150, 75);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 150, 75);
    $shp3 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 250, 150, 75);
    # Définit la couleur de remplissage pour la forme rectangle
    $shp1->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp3->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    # Définit la largeur de la ligne
    $shp1->getLineFormat()->setWidth(15);
    $shp2->getLineFormat()->setWidth(15);
    $shp3->getLineFormat()->setWidth(15);
    # Définit la couleur de la ligne du rectangle
    $shp1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shp3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    # Définit le Style de Jonction
    $shp1->getLineFormat()->setJoinStyle(LineJoinStyle->Miter);
    $shp2->getLineFormat()->setJoinStyle(LineJoinStyle->Bevel);
    $shp3->getLineFormat()->setJoinStyle(LineJoinStyle->Round);
    # Ajoute du texte à chaque rectangle
    $shp1->getTextFrame()->setText("Style de Jonction Miter");
    $shp2->getTextFrame()->setText("Style de Jonction Bevel");
    $shp3->getTextFrame()->setText("Style de Jonction Rond");
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectShpLnJoin_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remplissage Dégradé**
Dans PowerPoint, le Remplissage Dégradé est une option de formatage qui vous permet d'appliquer un mélange continu de couleurs à une forme. Par exemple, vous pouvez appliquer deux couleurs ou plus dans une configuration où une couleur s'estompe progressivement et se transforme en une autre couleur.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage dégradé à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forme sur `Gradient`.
5. Ajoutez vos 2 couleurs préférées avec des positions définies à l'aide des méthodes `Add` exposées par la collection `GradientStops` associée à la classe `GradientFormat`.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP démontre une opération où l'effet de remplissage dégradé a été utilisé sur une ellipse :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une autoforme ellipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 75, 150);
    # Applique le formatage dégradé à l'ellipse
    $shp->getFillFormat()->setFillType(FillType::Gradient);
    $shp->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape->Linear);
    # Définit la direction du dégradé
    $shp->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);
    # Ajoute 2 arrêts de dégradé
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor->Purple);
    $shp->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor->Red);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("EllipseShpGrad_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remplissage de Motifs**
Dans PowerPoint, le Remplissage de Motifs est une option de formatage qui vous permet d'appliquer un motif à deux couleurs composé de points, de rayures, de croisements ou de carreaux à une forme. De plus, vous pouvez sélectionner vos couleurs préférées pour le premier plan et l'arrière-plan de votre motif.

Aspose.Slides propose plus de 45 styles prédéfinis qui peuvent être utilisés pour formater des formes et enrichir des présentations. Même après avoir choisi un motif prédéfini, vous pouvez toujours spécifier les couleurs que le motif doit contenir.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de motif à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forme sur `Pattern`.
5. Définissez votre style de motif préféré pour la forme.
6. Définissez la [Couleur d'Arrière-Plan](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getBackColor--) pour le [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
7. Définissez la [Couleur de Premier Plan](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat#getForeColor--) pour le [PatternFormat](https://reference.aspose.com/slides/php-java/aspose.slides/PatternFormat).
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP démontre une opération où un remplissage de motif a été utilisé pour embellir un rectangle :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une autoforme rectangle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Définit le type de remplissage sur Motif
    $shp->getFillFormat()->setFillType(FillType::Pattern);
    # Définit le style de motif
    $shp->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle->Trellis);
    # Définit les couleurs de motif arrière et avant
    $shp->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shp->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectShpPatt_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remplissage d'Image**
Dans PowerPoint, le Remplissage d'Image est une option de formatage qui vous permet de placer une image à l'intérieur d'une forme. Essentiellement, vous utilisez une image comme arrière-plan de la forme.

Voici comment utiliser Aspose.Slides pour remplir une forme avec une image :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forme sur `Picture`.
5. Définissez le mode de remplissage d'image sur Tile.
6. Créez un objet `IPPImage` en utilisant l'image qui sera utilisée pour remplir la forme.
7. Définissez la propriété `Picture.Image` de l'objet `PictureFillFormat` sur le `IPPImage` récemment créé.
8. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment remplir une forme avec une image :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une autoforme rectangle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Définit le type de remplissage sur Image
    $shp->getFillFormat()->setFillType(FillType::Picture);
    # Définit le mode de remplissage d'image
    $shp->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Tile);
    # Définit l'image
    $picture;
    $image = Images->fromFile("Tulips.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    $shp->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectShpPic_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Remplissage de Couleur Unie**
Dans PowerPoint, le Remplissage de Couleur Unie est une option de formatage qui permet de remplir une forme avec une couleur unique. La couleur choisie est typiquement une couleur unie. La couleur est appliquée à l'arrière-plan de la forme avec aucun effet spécial ou modifications.

Voici comment utiliser Aspose.Slides pour appliquer un remplissage de couleur unie à une forme :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Définissez le [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/FillType) de la forme sur `Solid`.
5. Définissez votre couleur préférée pour la forme.
6. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment appliquer un remplissage de couleur unie à une boîte dans PowerPoint :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute une autoforme rectangle
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Définit le type de remplissage sur Solide
    $shape->getFillFormat()->setFillType(FillType::Solid);
    # Définit la couleur pour le rectangle
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectShpSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Définir la Transparence**

Dans PowerPoint, lorsque vous remplissez des formes avec des couleurs unies, des dégradés, des images ou des textures, vous pouvez spécifier le niveau de transparence qui détermine l'opacité d'un remplissage. De cette manière, par exemple, si vous définissez un faible niveau de transparence, l'objet de diapositive ou l'arrière-plan derrière (la forme) apparaît à travers.

Aspose.Slides vous permet de définir le niveau de transparence pour une forme de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Utilisez `new Color` avec le composant alpha défini.
5. Enregistrez l'objet en tant que fichier PowerPoint.

Ce code PHP démontre le processus :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute une forme solide
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 75, 175, 75, 150);
    # Ajoute une forme transparente par-dessus la forme solide
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 204, 102, 0, 128));
    # Enregistre le fichier PPTX sur le disque
    $pres->save("ShapeTransparentOverSolid_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Rotation des Formes**
Aspose.Slides vous permet de faire pivoter une forme ajoutée à une diapositive de la manière suivante :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Faites pivoter la forme par le nombre de degrés nécessaires.
5. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code PHP vous montre comment faire pivoter une forme de 90 degrés :

```php
  # Instancie une classe de présentation qui représente un fichier de présentation
  $pres = new Presentation();
  try {
    # Obtient la première diapositive
    $sld = $pres->getSlides()->get_Item(0);
    # Ajoute une autoforme rectangle
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 75, 150);
    # Fait pivoter la forme de 90 degrés
    $shp->setRotation(90);
    # Enregistre le fichier PPTX sur le disque
    $pres->save("RectShpRot_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter des Effets de Biseautage 3D**
Aspose.Slides vous permet d'ajouter des effets de biseautage 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Définissez vos paramètres préférés pour les propriétés de [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) de la forme.
5. Enregistrez la présentation sur le disque.

Ce code PHP vous montre comment ajouter des effets de biseautage 3D à une forme :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Ajoute une forme à la diapositive
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 30, 30, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $format = $shape->getLineFormat()->getFillFormat();
    $format->setFillType(FillType::Solid);
    $format->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);
    # Définit les propriétés ThreeDFormat de la forme
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    # Enregistre la présentation en tant que fichier PPTX
    $pres->save("Bavel_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ajouter un Effet de Rotation 3D**
Aspose.Slides vous permet d'appliquer des effets de rotation 3D à une forme en modifiant ses propriétés [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat) de cette manière :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation).
2. Obtenez une référence de la diapositive par son index.
3. Ajoutez une [IShape](https://reference.aspose.com/slides/php-java/aspose.slides/IShape) à la diapositive.
4. Spécifiez vos chiffres préférés pour les [CameraType](https://reference.aspose.com/slides/php-java/aspose.slides/ICamera#getCameraType--) et [LightType](https://reference.aspose.com/slides/php-java/aspose.slides/ILightRig#getLightType--).
5. Enregistrez la présentation sur le disque.

Ce code PHP vous montre comment appliquer des effets de rotation 3D à une forme :

```php
  # Crée une instance de la classe Presentation
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Line, 30, 300, 200, 200);
    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(0, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    # Enregistre la présentation en tant que fichier PPTX
    $pres->save("Rotation_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Réinitialiser la Mise en Forme**

Ce code PHP vous montre comment réinitialiser la mise en forme dans une diapositive et rétablir la position, la taille et le formatage de chaque forme qui a un espace réservé sur [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/LayoutSlide) à leurs valeurs par défaut :

```php
  $pres = new Presentation();
  try {
    foreach($pres->getSlides() as $slide) {
      # chaque forme sur la diapositive qui a un espace réservé sur la mise en page sera rétablie
      $slide->reset();
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```