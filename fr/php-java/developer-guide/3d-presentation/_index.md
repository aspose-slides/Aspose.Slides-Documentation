---
title: Créer des effets 3D dans les présentations avec PHP
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
- présentation
- PHP
- Aspose.Slides
description: "Appliquer et rendre des effets 3D pour les formes et le texte PowerPoint en PHP avec Aspose.Slides. Configurer la caméra, l'éclairage, le matériau, l'extrusion, les remplissages et le texte 3D."
---
## **Vue d'ensemble**

Aspose.Slides for PHP via Java peut créer, modifier, conserver et rendre le formatage 3D de type PowerPoint pour les formes et le texte. Cet article couvre les effets 3D tels que la rotation, l'extrusion, les biseaux, l'éclairage, le matériau, les remplissages en dégradé ou image, et le texte 3D.

{{% alert color="info" title="Note" %}}
Cet article porte sur les effets de formatage 3D appliqués aux formes et au texte de PowerPoint. Il ne s'agit pas d'insérer ou de modifier des fichiers de modèle 3D autonomes. Lorsque vous exportez une diapositive vers une image, un PDF ou du HTML, Aspose.Slides rend ces effets 3D dans la sortie 2D exportée.
{{% /alert %}}

## **Concepts de formatage 3D**

Utilisez la méthode [Shape::getThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getThreeDFormat--) pour appliquer le formatage 3D à une forme. La méthode renvoie [ThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/), qui contrôle la scène 3D de cette forme.

Pour le texte, utilisez la méthode [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) . Cette méthode applique le formatage 3D au cadre de texte plutôt qu'au corps de la forme.

Les membres d’API les plus importants sont :

| Membre de l'API | Ce qu'il contrôle | Quand l'utiliser |
|---|---|---|
| [getCamera](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getCamera--) | Point de vue, type de caméra prédéfini, rotation, zoom et perspective. | Faire pivoter l'objet dans l'espace 3D ou correspondre à un préréglage de rotation 3D de PowerPoint. |
| [getLightRig](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getLightRig--) | Préréglage d'éclairage, direction et rotation de la lumière. | Modifier la façon dont les reflets et les ombres apparaissent sur la surface 3D. |
| [getMaterial](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getMaterial--) et [setMaterial](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setMaterial-byte-) | Matériau de surface, tel que plat, mat, plastique ou métal. | Faire paraître la même géométrie plus plate, plus douce, brillante ou métallique. |
| [getExtrusionHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getExtrusionHeight--) et [setExtrusionHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) | À quel point la forme s'étend vers l'arrière depuis sa face avant. | Transformer une forme plate en un objet 3D visiblement épais. |
| [getExtrusionColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getExtrusionColor--) | Couleur des faces extrudées. | Rendre la profondeur visible ou coordonner la couleur des côtés avec le remplissage de face. |
| [getDepth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getDepth--) et [setDepth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setDepth-double-) | Profondeur 3D supplémentaire utilisée par le formatage 3D de PowerPoint. | Ajuster finement la profondeur pour les formes ou le texte, notamment avec les paramètres de biseau et de matériau. |
| [getBevelTop](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getBevelTop--) et [getBevelBottom](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getBevelBottom--) | Arêtes relevées ou arrondies sur les faces avant et arrière. | Ajouter un bord adouci ou moulé au lieu d'une face plate et nette. |
| [getContourColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getContourColor--) et [getContourWidth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getContourWidth--) et [setContourWidth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setContourWidth-double-) | Contour autour de l’objet 3D. | Mettre en évidence les limites de l’objet dans le rendu. |

## **Créer une forme 3D**

Une forme nécessite généralement quatre types de paramètres avant d’apparaître de façon convaincante en 3D :

- Paramètres de caméra, car la vue frontale par défaut peut masquer l'extrusion.  
- Paramètres d'éclairage, car l'éclairage rend les faces et les côtés lisibles.  
- Paramètres de matériau, car la surface influence la façon dont la lumière est rendue.  
- Paramètres d'extrusion ou de profondeur, car une forme plate a besoin d'épaisseur.

L’exemple suivant crée un rectangle, ajoute du texte à sa face avant et applique le formatage 3D. Les valeurs de rotation de la caméra sont exprimées en degrés, et la hauteur d’extrusion est de 100 points. L’exemple rend la diapositive en image PNG à deux fois ses dimensions par défaut et enregistre la présentation au format PPTX.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getTextFrame()->setText("3D");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(java("java.awt.Color")->BLUE);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("shape_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("shape_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

L’image de la diapositive rendue montre le rectangle comme un bloc 3D épais :

![Rectangle 3D bleu rendu avec texte 3D blanc sur la face avant](img_01_01.png)

## **Faire pivoter une forme avec la caméra**

Dans PowerPoint, la rotation 3D est configurée depuis le panneau Rotation 3‑D. Les valeurs de rotation X, Y et Z correspondent à la rotation que vous définissez via l’API caméra.

![Volet Rotation 3D de PowerPoint avec les valeurs de rotation X, Y et Z mises en évidence](img_02_01.png)

Dans Aspose.Slides, accédez à la caméra via [ThreeDFormat::getCamera](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getCamera--). Cet exemple crée un rectangle, sélectionne une vue frontale orthographique et définit ses rotations X, Y et Z à 20, 30 et 40 degrés respectivement. Il configure la forme en mémoire sans enregistrer de fichier :

```php
use aspose\slides\CameraPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
} finally {
    $presentation->dispose();
}
```

Utilisez la caméra lorsque vous devez modifier la façon dont le spectateur voit l’objet. Cela ne modifie pas la géométrie 2D de la forme sur la diapositive. Cela modifie le point de vue 3D utilisé par PowerPoint et par Aspose.Slides lors du rendu.

## **Ajouter une extrusion et une profondeur**

L’extrusion donne l’impression d’épaisseur en prolongeant la forme derrière la face avant. Dans PowerPoint, le contrôle de profondeur définit cette épaisseur visible, et le contrôle de couleur définit la couleur des faces latérales.

![Contrôles de profondeur de PowerPoint associés aux propriétés de couleur d'extrusion et de hauteur d'extrusion](img_02_02.png)

Utilisez [ThreeDFormat::setExtrusionHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) pour définir l’épaisseur et [ThreeDFormat::getExtrusionColor](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#getExtrusionColor--) pour accéder à la couleur des côtés. Cet exemple donne à un rectangle une extrusion de 100 points avec des côtés violets et fait pivoter la caméra pour révéler son épaisseur. Il configure la forme en mémoire sans enregistrer de fichier :

```php
use aspose\slides\CameraPresetType;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 200, 200);

    $extrusionColor = new Java("java.awt.Color", 128, 0, 128);

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(20, 30, 40);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(100);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

La méthode [ThreeDFormat::setDepth](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setDepth-double-) définit la profondeur d’une forme 3D. La méthode [setExtrusionHeight](https://reference.aspose.com/slides/fr/php-java/aspose.slides/threedformat/#setExtrusionHeight-double-) contrôle la hauteur de l’effet d’extrusion, comme le montre cet exemple.

## **Utiliser des remplissages en dégradé ou image avec des effets 3D**

Le formatage 3D est indépendant du remplissage de la forme. Vous pouvez appliquer une couleur unie, un dégradé, un motif ou un remplissage image à la face avant et conserver les mêmes paramètres de caméra, lumière, matériau et extrusion.

Cet exemple applique un dégradé du bleu à l’orange à la face avant et une couleur orange sombre à l’extrusion de 150 points. Les arrêts du dégradé à 0 % et 100 % marquent le début et la fin du dégradé. Les valeurs de rotation de la caméra sont en degrés. La diapositive est rendue en image PNG à deux fois ses dimensions par défaut :

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getTextFrame()->setText("3D Gradient");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(64);

    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(0, java("java.awt.Color")->BLUE);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->add(100, new Java("java.awt.Color", 255, 165, 0));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("gradient_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Le rendu conserve le dégradé sur la face avant et rend séparément l’extrusion :

![Rectangle 3D rendu avec un remplissage en dégradé du bleu à l’orange et une extrusion orange](img_02_03.png)

Pour utiliser un remplissage image à la place, ajoutez l’image à la présentation et affectez‑la au remplissage de la forme. Cet exemple suppose l’existence d’un fichier nommé "image.jpg" dans le répertoire de travail. Il étire l’image pour remplir le rectangle, applique une extrusion de 150 points et définit la rotation de la caméra en degrés. Il configure la forme en mémoire sans enregistrer ni rendre de fichier :

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $sourceImage = Images::fromFile("image.jpg");

    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $shape->getFillFormat()->setFillType(FillType::Picture);
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($image);
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);

    $extrusionColor = new Java("java.awt.Color", 255, 140, 0);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(10, 20, 30);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(150);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor($extrusionColor);
} finally {
    $presentation->dispose();
}
```

L’image est rendue sur la face avant, tandis que l’extrusion apparaît comme la surface latérale 3D :

![Rectangle 3D rendu avec un remplissage photo sur la face avant et une extrusion orange](img_02_04.png)

## **Appliquer le formatage 3D au texte**

Le formatage 3D d’une forme affecte le corps de la forme. Le formatage 3D du texte affecte le cadre de texte. Ceci est utile pour obtenir des effets de type WordArt où les lettres elles‑mêmes nécessitent extrusion, matériau, éclairage et paramètres de caméra.

L’exemple suivant crée du texte avec un motif de grille orange‑et‑blanc, applique une arche ascendante et configure les paramètres 3D via [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#getThreeDFormat--). La hauteur d’extrusion et la profondeur sont exprimées en points, et la rotation de la lumière en degrés. Le remplissage et le contour de la forme sont masqués pour que seul le texte soit visible. L’exemple rend une image PNG à deux fois les dimensions par défaut de la diapositive et enregistre la présentation au format PPTX :

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\PatternStyle;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextShapeType;

$imageScale = 2;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 150, 250, 250);

    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->setText("3D Text");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Pattern);
    $patternColor = new Java("java.awt.Color", 255, 140, 0);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getForeColor()->setColor($patternColor);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->WHITE);
    $portion->getPortionFormat()->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::LargeGrid);

    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(128);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat->setTransform(TextShapeType::ArchUp);
    $textFrameFormat->getThreeDFormat()->setExtrusionHeight(3.5);
    $textFrameFormat->getThreeDFormat()->setDepth(3);
    $textFrameFormat->getThreeDFormat()->setMaterial(MaterialPresetType::Plastic);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);
    $textFrameFormat->getThreeDFormat()->getLightRig()->setRotation(0, 0, 40);
    $textFrameFormat->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::PerspectiveContrastingRightFacing);

    $thumbnail = $slide->getImage($imageScale, $imageScale);
    try {
        $thumbnail->save("text_3d.png", ImageFormat::Png);
    } finally {
        $thumbnail->dispose();
    }

    $presentation->save("text_3d.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Le texte est rendu comme des lettres 3D courbées et extrudées :

![Texte 3D rendu avec une transformation WordArt en arche, un remplissage à motif orange et une extrusion sombre](img_02_05.png)

## **Maintenir le texte plat sur une forme 3D**

Pour que le texte reste lisible tout en conservant l’aspect 3D de la forme, appelez [TextFrameFormat::setKeepTextFlat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setKeepTextFlat-boolean-) via [TextFrame::getTextFrameFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframe/#getTextFrameFormat--). Lorsque la valeur est `true`, le texte reste hors de la scène 3D. Lorsqu’elle est `false`, le texte participe à la scène et suit son orientation 3D.

Ce paramètre ne supprime pas le formatage 3D de la forme : sa caméra, son éclairage, son matériau et son extrusion restent configurés via [Shape::getThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getThreeDFormat--). Il diffère également de la rotation ordinaire. [Shape::setRotation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#setRotation-float-) fait pivoter la forme dans le plan de la diapositive, tandis que [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#setRotationAngle-float-) contrôle la rotation personnalisée du texte dans son cadre. Garder le texte hors de la scène 3D ne réinitialise aucun de ces angles.

L’exemple autonome suivant crée un rectangle bleu avec texte et le clone à côté de l’original. Les deux formes partagent le même formatage 3D ; seul le paramètre texte diffère : `false` à gauche et `true` à droite. Les angles de la caméra sont en degrés et la hauteur d’extrusion est de 40 points. L’exemple enregistre la présentation au format PPTX et rend la diapositive de comparaison en PNG à deux fois ses dimensions par défaut.

```php
use aspose\slides\CameraPresetType;
use aspose\slides\FillType;
use aspose\slides\ImageFormat;
use aspose\slides\LightingDirection;
use aspose\slides\LightRigPresetType;
use aspose\slides\MaterialPresetType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 70, 160, 240, 140);

    $shape->getTextFrame()->setText("Readable text");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getParagraphFormat()->setAlignment(TextAlignment::Center);
    $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Center);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getCamera()->setRotation(30, 30, 0);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Flat);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);
    $shape->getThreeDFormat()->setMaterial(MaterialPresetType::Flat);
    $shape->getThreeDFormat()->setExtrusionHeight(40);
    $shape->getThreeDFormat()->getExtrusionColor()->setColor(new Java("java.awt.Color", 65, 105, 225));
    $shape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(false);

    $flatTextShape = $slide->getShapes()->addClone($shape, 400, 160);
    $flatTextShape->getTextFrame()->getTextFrameFormat()->setKeepTextFlat(true);

    $presentation->save("keep_text_flat.pptx", SaveFormat::Pptx);
    $image = $slide->getImage(2, 2);
    try {
        $image->save("keep_text_flat.png", ImageFormat::Png);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

À gauche, le texte suit l’orientation 3D. À droite, il reste plat et plus facile à lire. Les deux rectangles conservent la même extrusion visible et la même orientation 3D.

![Rectangles 3D côte à côte : le texte suit l’orientation 3D à gauche et reste plat à droite](keep_text_flat.png)

## **Comportement d'exportation et de rendu**

Aspose.Slides conserve le formatage 3D lors de l’enregistrement aux formats PowerPoint tels que PPTX. Lors du rendu ou de l’exportation vers des formats à mise en page fixe, la scène 3D est rasterisée ou dessinée dans la sortie comme un résultat 2D. Cela s’applique lorsque vous rendez les diapositives en [PNG](/slides/fr/php-java/convert-powerpoint-to-png/), exportez en [PDF](/slides/fr/php-java/convert-powerpoint-to-pdf/), exportez en [HTML](/slides/fr/php-java/convert-powerpoint-to-html/), ou générez des images‑cadres pour la [conversion vidéo](/slides/fr/php-java/convert-powerpoint-to-video/).

Gardez ces points à l’esprit :

- Les images et PDF exportés ne sont pas interactifs. L’objet ne peut pas être pivoté par le spectateur après l’exportation.
- L’apparence finale dépend de la combinaison de la caméra, du dispositif d’éclairage, du matériau, de l’extrusion, du remplissage et du redimensionnement de la diapositive.
- Si vous devez inspecter les valeurs de formatage héritées ou basées sur le thème, lisez les [propriétés effectives de la forme](/slides/fr/php-java/shape-effective-properties/).
- Certains formats de sortie ne peuvent pas stocker le formatage 3D PowerPoint éditable. Dans ces formats, le résultat visuel est rendu plutôt que conservé comme paramètres 3D éditables.

## **FAQ**

**Aspose.Slides peut-il créer des présentations 3D interactives ?**

Aspose.Slides crée et rend les effets 3D de PowerPoint pour les formes et le texte. Il ne rend pas les images, PDF ou pages HTML exportés interactifs ; le spectateur ne peut pas faire pivoter la scène 3D. En PPTX, le formatage 3D reste éditable dans PowerPoint lorsque le format le supporte.

**Quelle est la différence entre un modèle 3D et un effet 3D ?**

Un modèle 3D est un objet 3D séparé inséré dans une présentation. Un effet 3D est un formatage appliqué à une forme ou à du texte PowerPoint ordinaire, tel que la rotation, l’extrusion, le biseau, l’éclairage et le matériau. Cet article traite des effets 3D.

**Quels paramètres sont requis pour obtenir une forme 3D visible ?**

Au minimum, définissez une rotation de caméra et soit une extrusion, soit une profondeur. En pratique, ajoutez aussi un dispositif d’éclairage et un matériau afin que les faces rendues présentent des reflets et des ombres clairs.

**Puis‑je appliquer des effets 3D aux formes et au texte ?**

Oui. Utilisez [Shape::getThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shape/#getThreeDFormat--) pour le corps de la forme et [TextFrameFormat::getThreeDFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/textframeformat/#getThreeDFormat--) pour le texte.

**Les effets 3D apparaissent‑ils lors de l’exportation vers des images, PDF, HTML ou des images‑cadres vidéo ?**

Oui. Aspose.Slides rend les effets 3D lors de la génération d’images de diapositives, de sorties PDF, HTML et d’images‑cadres utilisées pour la conversion vidéo. Le résultat exporté contient l’apparence rendue, pas un objet 3D éditable.

**Puis‑je lire les valeurs 3D finales après l’application de l’héritage et des paramètres de thème ?**

Oui. Utilisez les API de formatage effectif décrites dans [Propriétés effectives de la forme](/slides/fr/php-java/shape-effective-properties/) pour lire les caméras, dispositifs d’éclairage, biseaux et autres valeurs 3D finales.