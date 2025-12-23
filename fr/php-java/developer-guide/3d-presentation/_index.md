---
title: Créer des présentations 3D en PHP
linktitle: Présentation 3D
type: docs
weight: 232
url: /fr/php-java/3d-presentation/
keywords:
- PowerPoint 3D
- présentation 3D
- rotation 3D
- profondeur 3D
- extrusion 3D
- dégradé 3D
- texte 3D
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Générez des présentations interactives 3D en PHP avec Aspose.Slides sans effort. Exportez rapidement aux formats PowerPoint et OpenDocument pour une utilisation polyvalente."
---

## **Aperçu**
Depuis Aspose.Slides Java 20.9, il est possible de créer des objets 3D dans les présentations. PowerPoint 3D est un moyen de donner vie aux présentations. Montrez des objets du monde réel avec une présentation 3D, démontrez le modèle 3D de votre futur projet commercial, le modèle 3D d’un bâtiment ou de son intérieur, le modèle 3D d’un personnage de jeu, ou simplement une représentation 3D de vos données.  

Les modèles 3D PowerPoint peuvent être créés à partir de formes 2D, en appliquant des effets tels que : rotation 3D, profondeur et extrusion 3D, dégradé 3D, texte 3D, etc.  
La liste des fonctionnalités 3D appliquées aux formes se trouve dans la classe **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**.  
Une instance de la classe peut être obtenue par :  

- la méthode **[Shape.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/Shape#getThreeDFormat--)** pour créer un modèle 3D PowerPoint.  
- la méthode **[TextFrameFormat.getThreeDFormat()](https://reference.aspose.com/slides/php-java/aspose.slides/TextFrameFormat#getThreeDFormat--)** pour créer du texte 3D (WordArt).  

Tous les effets implémentés dans **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)** peuvent être utilisés tant pour les formes que pour le texte.  
Jetons un coup d’œil rapide aux principales méthodes de la classe **[ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat)**. Dans l’exemple suivant, nous créons une forme rectangle 2D avec du texte. En obtenant la vue caméra sur la forme, nous modifions sa rotation pour la faire apparaître comme un modèle 3D. En définissant une lumière plate et sa direction vers le haut du modèle 3D, nous apportons plus de volume au modèle. Les matériaux modifiés, la hauteur d’extrusion et la couleur donnent au modèle 3D un aspect plus vivant.  
``` php 
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("sandbox_3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Voici le modèle 3D résultant :

![todo:image_alt_text](img_01_01.png)

## **Rotation 3D**
La rotation d’un modèle 3D dans PowerPoint peut être effectuée via le menu :

![todo:image_alt_text](img_02_01.png)

Pour faire pivoter un modèle 3D avec l’API Aspose.Slides, utilisez la méthode **[IThreeDFormat.getCamera()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getCamera--)**, puis définissez la rotation de la caméra par rapport à la forme 3D :
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
// ... définir les autres paramètres de la scène 3D

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


## **Profondeur et extrusion 3D**
Les méthodes **[IThreeDFormat.getExtrusionHeight()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionHeight--)** et **[IThreeDFormat.getExtrusionColor()](https://reference.aspose.com/slides/php-java/aspose.slides/ThreeDFormat#getExtrusionColor--)** sont utilisées pour créer une extrusion sur la forme :
``` php
$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
$shape->getThreeDFormat()->setExtrusionHeight(100);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 128, 0, 128));
# ... définir les autres paramètres de la scène 3D

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


Dans PowerPoint, la profondeur de la forme se définit via :

![todo:image_alt_text](img_02_02.png)

## **Dégradé 3D**
Le dégradé 3D peut apporter davantage de volume à une forme 3D PowerPoint :
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);
$shape->getTextFrame()->setText("3D");
$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

$shape->getFillFormat()->setFillType(FillType::Gradient);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
$shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, java("java.awt.Color")->ORANGE);

$shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
$shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
$shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
$shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$shape->getThreeDFormat()->setExtrusionHeight(150);
$shape->getThreeDFormat()->getExtrusionColor()->setColor(new java("java.awt.Color", 255, 140, 0));

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->dispose();
```


Voici à quoi cela ressemble :

![todo:image_alt_text](img_02_03.png)
  
Vous pouvez également créer un dégradé d’image :
``` php
$shape->getFillFormat()->setFillType(FillType::Picture);

$image = Images->fromFile("image.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode->Stretch);
# ... configuration 3D: shape.ThreeDFormat.Camera, shape.ThreeDFormat.LightRig, shape.ThreeDFormat.Extrusion* propriétés

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("sample_3d.png", ImageFormat::Png);
$thumbnail->dispose();
```


Voici le résultat :

![todo:image_alt_text](img_02_04.png)

## **Texte 3D (WordArt)**
Pour créer un texte 3D (WordArt), procédez comme suit :
``` php
$imageScale = 2;

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);
$shape->getFillFormat()->setFillType(FillType::NoFill);
$shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
$shape->getTextFrame()->setText("3D Text");

$portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
$portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor(new java("java.awt.Color", 255, 140, 0));
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
$portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

$shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);
$textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
# configurer l'effet de transformation WordArt "Arch Up"
$textFrameFormat->setTransform(TextShapeType::ArchUp);

$textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
$textFrameFormat->getThreeDFormat()->setDepth(3);
$textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
$textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
$textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
$textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
$textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

$thumbnail = $slide->getImage($imageScale, $imageScale);
$thumbnail->save("text3d.png", ImageFormat::Png);
$thumbnail->dispose();

$presentation->save("text3d.pptx", SaveFormat::Pptx);
$presentation->dispose();
```


Voici le résultat :

![todo:image_alt_text](img_02_05.png)

## **FAQ**

**Les effets 3D seront-ils conservés lors de l’exportation d’une présentation vers des images/PDF/HTML ?**

Oui. Le moteur 3D de Slides rend les effets 3D lors de l’exportation vers les formats pris en charge ([images](/slides/fr/php-java/convert-powerpoint-to-png/), [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), etc.).

**Puis‑je récupérer les valeurs « effectives » (finales) des paramètres 3D qui tiennent compte des thèmes, de l’héritage, etc. ?**

Oui. Slides propose des API pour [lire les valeurs effectives](/slides/fr/php-java/shape-effective-properties/) (y compris pour la 3D : éclairage, chanfreins, etc.) afin que vous puissiez voir les paramètres appliqués en fin de compte.

**Les effets 3D fonctionnent‑ils lors de la conversion d’une présentation en vidéo ?**

Oui. Lors de la [génération des images pour la vidéo](/slides/fr/php-java/convert-powerpoint-to-video/), les effets 3D sont rendus de la même manière que pour les [images exportées](/slides/fr/php-java/convert-powerpoint-to-png/).