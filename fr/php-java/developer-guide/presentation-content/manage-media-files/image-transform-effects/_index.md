---
title: Gérer les effets de transformation d'image dans les présentations avec PHP
linktitle: Effets de transformation d'image
type: docs
weight: 11
url: /fr/php-java/image-transform-effects/
keywords:
- transformation d'image
- effet d'image
- luminosité
- contraste
- niveaux de gris
- duotone
- teinte
- HSL
- remplacement de couleur
- flou
- transparence
- effet alpha
- chaîne d'effets
- PowerPoint
- présentation
- PHP
- Aspose.Slides
description: "Appliquer, chaîner, inspecter, supprimer et vérifier les effets de transformation d'image pour les cadres d'image avec Aspose.Slides pour PHP via Java."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d'image comme une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, commencez par le [Picture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picture/) du cadre et accédez à [Picture::getImageTransform](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picture/getimagetransform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/) retournée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et de nettoyer les effets sans réécrire les octets d'image d'origine.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification de la boucle de sauvegarde PPTX.

## **Comprendre la propriété des effets et la réutilisation d'image**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) stocke ou référence les données d'image source détenues par la présentation.
- [Picture](https://reference.aspose.com/slides/fr/php-java/aspose.slides/picture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformations d'image.
- [PictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pictureframe/) est la forme de diapositive qui possède le remplissage d'image, la géométrie, les paramètres de recadrage et les autres options de formatage au niveau du cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets de [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/). Lorsque le même `PPImage` est transmis à plusieurs reprises à [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/fr/php-java/aspose.slides/shapecollection/addpictureframe/), chaque nouveau cadre d'image reçoit son propre `Picture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d'image incorporée.

Le même modèle `Picture::getImageTransform` est également utilisé par d'autres remplissages d'image, tels qu'une forme ou l'arrière-plan de diapositive. Les exemples ci‑dessous se concentrent sur les cadres d'image.

## **Utiliser des plages de paramètres et des unités valides**

Les méthodes présentées utilisent les plages sémantiques et les unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors plage ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l'enregistrement ou à l'ouverture du fichier par PowerPoint.

| Opération | Paramètres | Plage et unité valides |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Aucun | Aucun paramètre numérique. Alpha est inchangé. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `java.awt.Color` utilisent `0` à `255`. |
| [addTintEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Teinte de `0` inclus à `360` exclu, en degrés ; quantité de `-100` à `100`, pourcentage. |
| [addHSLEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Teinte de `0` inclus à `360` exclu, en degrés ; saturation et luminance de `-100` à `100`, pourcentage. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [addBlurEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Le rayon est non négatif et exprimé en points ; `grow` est un booléen qui indique si le contenu flou peut dépasser les limites d'origine. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un redimensionnement d'opacité ordinaire : `0` est complètement transparent et `100` préserve l'alpha existant. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` à `100`, pourcentage d'opacité. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` à `100`, pourcentage de seuil alpha. Les valeurs en dessous deviennent transparentes ; les valeurs égales ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, la transparence et l'opacité sont complémentaires. Par exemple, 35 % de transparence correspond à un facteur de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) renvoie une opération [Luminance](https://reference.aspose.com/slides/fr/php-java/aspose.slides/luminance/). Ses paramètres scalaires sont fournis lors de la création de l'opération. [Luminance::getEffective](https://reference.aspose.com/slides/fr/php-java/aspose.slides/luminance/geteffective/) renvoie des valeurs en lecture seule calculées qui peuvent être inspectées ou journalisées.

L'exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis rend un aperçu sans modifier l'image incorporée :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $luminance = $imageTransform->addLuminanceEffect(15, 20);

    $effectiveValues = $luminance->getEffective();
    echo "Brightness: " . java_values($effectiveValues->getBrightness()) . "%" . PHP_EOL;
    echo "Contrast: " . java_values($effectiveValues->getContrast()) . "%" . PHP_EOL;

    $preview = $slide->getImage();
    try {
        $preview->save("brightness-contrast-preview.png", ImageFormat::Png);
    } finally {
        if (!java_is_null($preview)) {
            $preview->dispose();
        }
    }
} finally {
    $presentation->dispose();
}
```

`Luminance` est l'effet standard DrawingML de luminosité et de contraste. Lorsque ces paramètres doivent rester modifiables après un aller‑retour PPTX, rouvrez la présentation enregistrée et vérifiez à la fois le type d'opération et ses valeurs effectives.

## **Appliquer des transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d'image qui réutilisent une même ressource d'image. L'exemple suivant crée cinq cadres et applique le niveau de gris, le duotone, la teinte, le réglage HSL et le remplacement de couleur.

[Duotone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/duotone/) possède deux paramètres de couleur éditables indépendamment : `color1` correspond aux pixels sombres, tandis que `color2` correspond aux pixels clairs. Cela en fait un exemple utile d'effet dont les réglages sont plus complexes qu'une simple valeur scalaire.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $grayFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 180, 120, $image);
    $grayFrame->getPictureFormat()->getPicture()->getImageTransform()->addGrayScaleEffect();

    $duotoneFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 220, 20, 180, 120, $image);
    $duotone = $duotoneFrame->getPictureFormat()->getPicture()->getImageTransform()->addDuotoneEffect();
    $duotone->getColor1()->setColor(new Java("java.awt.Color", 0, 0, 128));
    $duotone->getColor2()->setColor(new Java("java.awt.Color", 255, 215, 0));

    $tintFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 420, 20, 180, 120, $image);
    $tintFrame->getPictureFormat()->getPicture()->getImageTransform()->addTintEffect(210, 35);

    $hslFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 120, 170, 180, 120, $image);
    $hslFrame->getPictureFormat()->getPicture()->getImageTransform()->addHSLEffect(30, 20, -10);

    $replacementFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 320, 170, 180, 120, $image);
    $colorReplacement = $replacementFrame->getPictureFormat()->getPicture()->getImageTransform()->addColorReplaceEffect();
    $colorReplacement->getColor()->setColor(new Java("java.awt.Color", 100, 149, 237));

    $presentation->save("color-transformations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) remplace la couleur de chaque pixel par une couleur fixe tout en préservant l'alpha. Il diffère de [addColorChangeEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), qui mappe une couleur source vers une autre et expose les formats couleur source et cible.

## **Ajouter des effets de flou, de transparence et d'alpha**

[addBlurEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) agit sur tous les canaux de couleur, y compris l'alpha. Définissez `grow` sur `true` lorsque le bord flou peut dépasser les limites de l'image d'origine.

Pour une transparence uniforme, utilisez [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents conservent leurs différences proportionnelles. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) attribue à la place une même valeur alpha à tous les pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) convertit l'alpha en deux niveaux selon un seuil.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $blurredFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 140, $image);
    $blur = $blurredFrame->getPictureFormat()->getPicture()->getImageTransform()->addBlurEffect(4.5, true);
    $blur->setRadius(5);

    $transparentFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 20, 200, 140, $image);
    $alphaModulate = $transparentFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaModulateFixedEffect(65);
    $alphaModulate->setAmount(60);

    $uniformAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 180, 200, 140, $image);
    $uniformAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaReplaceEffect(55);

    $binaryAlphaFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 240, 180, 200, 140, $image);
    $alphaBiLevel = $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaBiLevelEffect(50);
    $alphaBiLevel->setThreshold(45);
    $binaryAlphaFrame->getPictureFormat()->getPicture()->getImageTransform()->addAlphaInverseEffect();

    $presentation->save("blur-and-alpha-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

D'autres opérations alpha sans paramètres incluent [addAlphaCeilingEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), qui rend chaque alpha non nul complètement opaque ; [addAlphaFloorEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), qui rend chaque alpha inférieur à 100 % totalement transparent ; et [addAlphaInverseEffect](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), qui transforme l'alpha en `100% - alpha`.

## **Construire une chaîne d'effets ordonnée**

Chaque méthode `add...Effect` ajoute une nouvelle opération à la fin de la collection. Le moteur de rendu utilise la collection comme un pipeline ordonné : la sortie de l'opération 0 devient l'entrée de l'opération 1, etc. Ainsi, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d'une teinte retire d'abord l'information chromatique, puis recolore le résultat de luminance. Une teinte suivie d'un niveau de gris supprime à nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations précédentes, tandis que la modulation alpha préserve leurs différences relatives.

L'exemple suivant construit une chaîne de quatre opérations, l'enregistre en PPTX, rouvre la présentation, vérifie à la fois les types d'opération et leur ordre, puis rend le résultat rouver :

```php
use aspose\slides\ImageFormat;
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $sourceImage = Images::fromFile("photo.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        if (!java_is_null($sourceImage)) {
            $sourceImage->dispose();
        }
    }

    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 400, 260, $image);
    $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
    $imageTransform->addGrayScaleEffect();
    $imageTransform->addTintEffect(220, 25);
    $imageTransform->addBlurEffect(2.5, false);
    $imageTransform->addAlphaModulateFixedEffect(80);

    $presentation->save("image-transform-chain.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    if (java_instanceof($reopenedShape, new JavaClass("com.aspose.slides.PictureFrame"))) {
        $reopenedTransform = $reopenedShape->getPictureFormat()->getPicture()->getImageTransform();
        $orderIsPreserved = java_values($reopenedTransform->size()) === 4 && 
            java_instanceof($reopenedTransform->get_Item(0), new JavaClass("com.aspose.slides.GrayScale")) && 
            java_instanceof($reopenedTransform->get_Item(1), new JavaClass("com.aspose.slides.Tint")) && 
            java_instanceof($reopenedTransform->get_Item(2), new JavaClass("com.aspose.slides.Blur")) && 
            java_instanceof($reopenedTransform->get_Item(3), new JavaClass("com.aspose.slides.AlphaModulateFixed"));
        echo $orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.";

        $renderedSlide = $reopenedPresentation->getSlides()->get_Item(0)->getImage();
        try {
            $renderedSlide->save("reopened-effect-chain.png", ImageFormat::Png);
        } finally {
            if (!java_is_null($renderedSlide)) {
                $renderedSlide->dispose();
            }
        }
    } else {
        echo "The reopened shape is not a picture frame.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

La collection n'impose pas de matrice de compatibilité qui séparerait les opérations couleur, alpha et flou en chaînes distinctes. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement de couleur fixe supprime la variation RVB générée par les effets couleur antérieurs ; le niveau de gris après duotone supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent éliminer les détails alpha créés auparavant. Construisez la chaîne selon la séquence de traitement des pixels souhaitée plutôt que de traiter ses éléments comme des indicateurs de formatage non ordonnés.

## **Inspecter les valeurs modifiables et effectives**

Une opération modifiable est l'objet stocké dans `Picture::getImageTransform`. Selon l'effet, elle peut exposer directement des membres modifiables. Par exemple, [Blur](https://reference.aspose.com/slides/fr/php-java/aspose.slides/blur/) expose les valeurs modifiables `radius` et `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/fr/php-java/aspose.slides/alphamodulatefixed/) expose un `amount` modifiable, et [AlphaBiLevel](https://reference.aspose.com/slides/fr/php-java/aspose.slides/alphabilevel/) expose un `threshold` modifiable. Les effets couleur tels que [Duotone](https://reference.aspose.com/slides/fr/php-java/aspose.slides/duotone/) exposent des objets [ColorFormat](https://reference.aspose.com/slides/fr/php-java/aspose.slides/colorformat/) mutables.

Certaines opérations, dont [Luminance](https://reference.aspose.com/slides/fr/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/fr/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/fr/php-java/aspose.slides/tint/) et [AlphaReplace](https://reference.aspose.com/slides/fr/php-java/aspose.slides/alphareplace/), n'exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces paramètres, supprimez l'opération et ajoutez une nouvelle à la position requise.

Les données effectives retournées par `getEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées que le moteur de rendu utilise, mais ce n’est pas une surface d’édition supplémentaire. L'exemple suivant parcourt la chaîne et inspecte les valeurs effectives lorsque l’API correspondante les fournit :

```php
use aspose\slides\Presentation;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());

        for ($index = 0; $index < $effectCount; $index++) {
            $operation = $imageTransform->get_Item($index);
            echo $index . ": " . java_values($operation->getClass()->getSimpleName()) . PHP_EOL;

            if (java_instanceof($operation, new JavaClass("com.aspose.slides.Luminance"))) {
                $data = $operation->getEffective();
                echo "  Brightness: " . java_values($data->getBrightness()) . PHP_EOL;
                echo "  Contrast: " . java_values($data->getContrast()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Duotone"))) {
                $data = $operation->getEffective();
                echo "  Dark color: " . java_values($data->getColor1()->toString()) . PHP_EOL;
                echo "  Light color: " . java_values($data->getColor2()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.ColorReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement color: " . java_values($data->getColor()->toString()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.HSL"))) {
                $data = $operation->getEffective();
                echo "  HSL: " . java_values($data->getHue()) . ", " . java_values($data->getSaturation()) . ", " . java_values($data->getLuminance()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Tint"))) {
                $data = $operation->getEffective();
                echo "  Tint: " . java_values($data->getHue()) . ", " . java_values($data->getAmount()) . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.Blur"))) {
                $data = $operation->getEffective();
                echo "  Blur radius: " . java_values($data->getRadius()) . " pt" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaModulateFixed"))) {
                $data = $operation->getEffective();
                echo "  Alpha amount: " . java_values($data->getAmount()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaReplace"))) {
                $data = $operation->getEffective();
                echo "  Replacement alpha: " . java_values($data->getAlpha()) . "%" . PHP_EOL;
            } elseif (java_instanceof($operation, new JavaClass("com.aspose.slides.AlphaBiLevel"))) {
                $data = $operation->getEffective();
                echo "  Alpha threshold: " . java_values($data->getThreshold()) . "%" . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Les effets sans paramètres tels que le niveau de gris, le plafond alpha et l'inverse alpha possèdent toujours un objet de données effectives, mais il n’existe aucune valeur scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou effacer les transformations d'image**

Utilisez [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/removeat/) pour supprimer une opération par son indice. Parce que les indices changent après une suppression, recherchez d'abord la cible puis supprimez‑la après l'énumération. Utilisez [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/fr/php-java/aspose.slides/imagetransformoperationcollection/clear/) pour enlever toute la chaîne.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("image-transform-chain.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = null;
    $shapeCount = java_values($slide->getShapes()->size());

    for ($index = 0; $index < $shapeCount; $index++) {
        $shape = $slide->getShapes()->get_Item($index);
        if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
            $pictureFrame = $shape;
            break;
        }
    }

    if ($pictureFrame !== null) {
        $imageTransform = $pictureFrame->getPictureFormat()->getPicture()->getImageTransform();
        $effectCount = java_values($imageTransform->size());
        $blurIndex = -1;

        for ($index = 0; $index < $effectCount; $index++) {
            if (java_instanceof($imageTransform->get_Item($index), new JavaClass("com.aspose.slides.Blur"))) {
                $blurIndex = $index;
                break;
            }
        }

        if ($blurIndex >= 0) {
            $imageTransform->removeAt($blurIndex);
            echo "The blur operation was removed." . PHP_EOL;
        }

        $imageTransform->clear();
        echo "Remaining operations: " . java_values($imageTransform->size()) . PHP_EOL;
        $presentation->save("image-transforms-cleared.pptx", SaveFormat::Pptx);
    }
} finally {
    $presentation->dispose();
}
```

Supprimer ou effacer les transformations ne modifie que le formatage de l'image. Cela ne supprime pas, ne recompresse pas et n'altère pas la ressource [PPImage](https://reference.aspose.com/slides/fr/php-java/aspose.slides/ppimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d'exportation**

Les transformations d'image proviennent de DrawingML, donc le PPTX est le format éditable privilégié pour les chaînes d'effets. Même avec le PPTX, toutes les opérations n'ont pas exactement la même portabilité :

- Les opérations DrawingML standard telles que luminance, niveau de gris, duotone, teinte, HSL, flou et les opérations alpha courantes ont le plus de chances de survivre à un aller‑retour PPTX. Rouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- Le format binaire PPT précède le modèle complet des effets DrawingML. Enregistrement au format PPT peut omettre les opérations non prises en charge, réduire une chaîne à un sous‑ensemble supporté ou approximativement reproduire l'apparence. N'utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou d’autres sorties visuelles applique la chaîne supportée à l’apparence rendue. Ces sorties ne contiennent pas de `ImageTransformOperationCollection` éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document ou vecteur stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Le rendu d’une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsqu’on combine plusieurs opérations alpha ou de quantification de couleur. Pour une sortie critique, testez à la fois la boucle éditable et le format d'export final avec la même version d'Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d'image modifient‑ils les données d'image incorporées ?**

Non. Les opérations appartiennent au `Picture` utilisé par le remplissage d'image. Les octets sous‑jacents de `PPImage` restent inchangés.

**Deux cadres d'image qui réutilisent la même image partageront‑ils leurs effets ?**

Non. Réutiliser un `PPImage` évite la duplication des données d'image, mais chaque cadre d'image possède normalement un `Picture` distinct et une collection de transformations d'image distincte.

**Les effets couleur, flou et alpha peuvent‑ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent éliminer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l'opération stockée dans la collection de transformations là où des membres modifiables existent ; sinon, supprimez‑la et ajoutez une opération de remplacement avec de nouveaux paramètres de création.

**Quel format dois‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez le PPTX et vérifiez le fichier en le rouvrant. Le format PPT hérité ne peut pas représenter le modèle complet des effets DrawingML, et les formats d'exportation rendus conservent l'apparence plutôt que les opérations de transformation éditables.