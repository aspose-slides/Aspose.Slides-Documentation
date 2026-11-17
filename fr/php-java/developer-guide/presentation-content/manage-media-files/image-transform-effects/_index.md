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

Aspose.Slides représente les ajustements d'image comme une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, commencez avec le [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) du cadre et accédez à [Picture::getImageTransform](https://reference.aspose.com/slides/php-java/aspose.slides/picture/getimagetransform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/) renvoyée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et d'effacer les effets sans réécrire les octets d'image d'origine.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification de la conservation en aller‑retour PPTX.

## **Comprendre la propriété des effets et la réutilisation des images**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) stocke ou référence les données d'image source appartenant à la présentation.
- [Picture](https://reference.aspose.com/slides/php-java/aspose.slides/picture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformations d'image.
- [PictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframe/) est la forme de diapositive qui possède le remplissage d'image pertinent, la géométrie, les paramètres de rognage et d'autres formats au niveau du cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets dans [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/). Lorsque le même `PPImage` est passé à [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addpictureframe/) plus d'une fois, chaque nouveau cadre d'image reçoit son propre `Picture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d'image intégrée.

Le même modèle `Picture::getImageTransform` est également utilisé par d'autres remplissages d'image, comme une forme ou l'arrière‑plan d'une diapositive. Les exemples ci‑dessous portent sur les cadres d'image.

## **Utiliser des intervalles et des unités de paramètres valides**

Les méthodes présentées utilisent les intervalles sémantiques et les unités suivants. Conservez les valeurs dans ces intervalles même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors limites ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l'enregistrement ou lorsque PowerPoint ouvre le fichier.

| Opération | Paramètres | Intervalle valide et unité |
|---|---|---|
| [addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) | `brightness`, `contrast` | `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) | Aucun | Aucun paramètre numérique. L'alpha reste inchangé. |
| [addDuotoneEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addduotoneeffect/) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `java.awt.Color` utilisent `0` à `255`. |
| [addTintEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Teinte est `0` inclus à `360` exclu, en degrés ; le montant est de `-100` à `100`, pourcentage. |
| [addHSLEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Teinte est `0` inclus à `360` exclu, en degrés ; saturation et luminance sont de `-100` à `100`, pourcentage. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Le rayon est non négatif et mesuré en points ; `grow` est un booléen qui contrôle si le contenu flou peut s'étendre au-delà des limites d'origine. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un redimensionnement ordinaire de l'opacité : `0` est entièrement transparent et `100` conserve l'alpha existant. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` à `100`, pourcentage d'opacité. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` à `100`, pourcentage de seuil alpha. Les valeurs en dessous deviennent transparentes ; les valeurs au-dessus ou égales deviennent opaques. |

Pour la modulation alpha fixe, transparence et opacité sont complémentaires. Par exemple, 35 % de transparence correspond à un montant de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[ImageTransformOperationCollection::addLuminanceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addluminanceeffect/) renvoie une opération [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/). Ses réglages scalaires sont fournis lors de la création de l'opération. [Luminance::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/geteffective/) renvoie des valeurs calculées en lecture seule qui peuvent être inspectées ou consignées.

L'exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis génère un aperçu sans modifier l'image intégrée :

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

`Luminance` est l'effet standard de luminosité et de contraste de DrawingML. Lorsque ces réglages doivent rester modifiables après un aller‑retour PPTX, rouvrez la présentation enregistrée et vérifiez à la fois le type d'opération et ses valeurs effectives.

## **Appliquer des transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d'image qui réutilisent la même ressource d'image. L'exemple suivant crée cinq cadres et applique le niveau de gris, duotone, teinte, ajustement HSL et remplacement de couleur.

[Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) contient deux paramètres de couleur modifiables indépendamment : `color1` mappe les pixels sombres, tandis que `color2` mappe les pixels clairs. Cela en fait un exemple utile d'effet dont les réglages sont plus complexes qu'une seule valeur scalaire.

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

[addColorReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorreplaceeffect/) remplace la couleur de chaque pixel par une couleur fixe tout en préservant l'alpha. C'est différent de [addColorChangeEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addcolorchangeeffect/), qui mappe une couleur source vers une autre et expose les deux formats de couleur source et cible.

### **Appliquer un seuil de luminance**

Un seuil de luminance peut rendre plus faciles à distinguer les marques faibles sur une page numérisée. [addGrayScaleEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addgrayscaleeffect/) conserve les nuances intermédiaires de gris. [addBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addbileveleffect/) mappe la luminance en noir ou blanc, tandis que [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) applique un seuil à l'opacité.

Le seuil de luminance varie de 0 % à 100 %, inclus. Les pixels en dessous du seuil deviennent noirs. Les pixels au-dessus ou égaux deviennent blancs. Augmenter le seuil rend plus de nuances noires car davantage d'entre elles tombent sous la coupure.

Téléchargez [grayscale-swatches.png](grayscale-swatches.png) dans le répertoire contenant le script PHP. Chaque étiquette indique le niveau de gris original sur une échelle de 0 à 255. L'exemple place l'original à côté de deux copies et enregistre le seuil de chaque copie dans la présentation.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(720, 150, SlideSizeScaleType::DoNotScale);
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $sourceImage = Images::fromFile(__DIR__ . "/grayscale-swatches.png");
    try {
        $image = $presentation->getImages()->addImage($sourceImage);
    } finally {
        $sourceImage->dispose();
    }

    $captions = ["Original", "Threshold 20%", "Threshold 60%"];
    $frames = [];
    foreach ($captions as $index => $caption) {
        $x = 12 + 240 * $index;
        $label = $shapes->addAutoShape(ShapeType::Rectangle, $x, 12, 216, 36);
        $label->getTextFrame()->setText($caption);
        $frames[] = $shapes->addPictureFrame(ShapeType::Rectangle, $x, 60, 216, 72, $image);
    }

    $frames[1]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(20);
    $frames[2]->getPictureFormat()->getPicture()->getImageTransform()->addBiLevelEffect(60);

    $presentation->save(__DIR__ . "/luminance-threshold.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ouvrez la présentation de sortie dans PowerPoint pour comparer les trois cadres. Le nuancier étiqueté 96 a environ 38 % de luminance (96 sur 255). Il devient blanc au seuil de 20 % et noir au seuil de 60 %.

![Nuanciers gris originaux à côté des résultats noir-et-blanc aux seuils de luminance de 20 % et 60 %](luminance-threshold.png)

## **Ajouter des effets de flou, de transparence et alpha**

[addBlurEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addblureffect/) affecte tous les canaux de couleur, y compris l'alpha. Réglez `grow` sur `true` lorsque le bord flou peut s'étendre au-delà des limites de l'image d'origine.

Pour une transparence uniforme, utilisez [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphamodulatefixedeffect/). Elle multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents restent proportionnellement différents. [addAlphaReplaceEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphareplaceeffect/) attribue au contraire une seule valeur alpha à tous les pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphabileveleffect/) convertit l'alpha en deux niveaux basés sur un seuil.

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

D'autres opérations alpha sans paramètre incluent [addAlphaCeilingEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaceilingeffect/), qui rend chaque alpha non nul entièrement opaque ; [addAlphaFloorEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphaflooreffect/), qui rend chaque alpha inférieur à 100 % entièrement transparent ; et [addAlphaInverseEffect](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/addalphainverseeffect/), qui change l'alpha en `100% - alpha`.

## **Construire une chaîne d'effets ordonnée**

Chaque méthode `add...Effect` ajoute une nouvelle opération à la fin de la collection. Le rendu utilise la collection comme un pipeline ordonné : la sortie de l'opération 0 devient l'entrée de l'opération 1, etc. Ainsi, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d'une teinte supprime d'abord l'information chromatique puis recolore le résultat de luminance. Une teinte suivie de niveau de gris supprime à nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par des opérations antérieures, tandis que la modulation alpha conserve leurs différences relatives.

L'exemple suivant construit une chaîne de quatre opérations, l'enregistre au format PPTX, rouvre la présentation, vérifie à la fois les types d'opérations et leur ordre, et rend le résultat rouvert :

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

La collection n'impose pas de matrice de compatibilité qui restreint les opérations couleur, alpha et flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement de couleur fixe supprime la variation RVB produite par les effets couleur antérieurs ; le niveau de gris après duotone supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent éliminer les détails alpha créés précédemment. Construisez la chaîne selon la séquence de traitement des pixels souhaitée plutôt que de traiter ses éléments comme des indicateurs de formatage non ordonnés.

<!-- visual-explanation:image-transform-effects:start -->
[![La même image passe d'abord par le niveau de gris puis la teinte, et de la teinte puis le niveau de gris. Les deux images finales en niveaux de gris ont des tons différents.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)
<!-- visual-explanation:image-transform-effects:end -->

*Dans ce rendu illustratif d'Aspose.Slides pour .NET 26.11, une teinte de 220° à 25 % laisse l'image en niveaux de gris intacte. Appliquer la même teinte avant le niveau de gris produit des tons différents.*

## **Inspecter les valeurs modifiables et effectives**

Une opération modifiable est l'objet stocké dans `Picture::getImageTransform`. Selon l'effet, il peut exposer directement des membres modifiables. Par exemple, [Blur](https://reference.aspose.com/slides/php-java/aspose.slides/blur/) expose les valeurs modifiables `radius` et `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/php-java/aspose.slides/alphamodulatefixed/) expose un `amount` modifiable, et [AlphaBiLevel](https://reference.aspose.com/slides/php-java/aspose.slides/alphabilevel/) expose un `threshold` modifiable. Les effets de couleur tels que [Duotone](https://reference.aspose.com/slides/php-java/aspose.slides/duotone/) exposent des objets [ColorFormat](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) mutables.

Certaines opérations, y compris [Luminance](https://reference.aspose.com/slides/php-java/aspose.slides/luminance/), [HSL](https://reference.aspose.com/slides/php-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/php-java/aspose.slides/tint/), et [AlphaReplace](https://reference.aspose.com/slides/php-java/aspose.slides/alphareplace/), n'exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces réglages, supprimez l'opération et ajoutez un remplacement à la position requise.

Les données effectives renvoyées par `getEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées que le rendu utilise, mais ce n'est pas une autre surface d'édition. L'exemple suivant énumère la chaîne et inspecte les valeurs effectives là où l'API correspondante les fournit :

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

Les effets sans paramètre comme le niveau de gris, le plafond alpha et l'inverse alpha possèdent toujours un objet de données effectives, mais il n'y a aucune configuration scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou effacer les transformations d'image**

Utilisez [ImageTransformOperationCollection::removeAt](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/removeat/) pour supprimer une opération par indice. Parce que les indices changent après une suppression, recherchez d'abord la cible puis supprimez‑la après l'énumération. Utilisez [ImageTransformOperationCollection::clear](https://reference.aspose.com/slides/php-java/aspose.slides/imagetransformoperationcollection/clear/) pour supprimer toute la chaîne.

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

Supprimer ou effacer les transformations ne modifie que le formatage de l'image. Cela ne supprime pas, ne recompresse pas ou ne modifie pas autrement la ressource [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d'exportation**

Les transformations d'image proviennent de DrawingML, ainsi PPTX est le format modifiable privilégié pour les chaînes d'effets. Même avec PPTX, toutes les opérations n'ont pas une portabilité identique :

- Les opérations standard de DrawingML comme la luminance, le niveau de gris, le duotone, la teinte, HSL, le flou et les opérations alpha courantes ont les meilleures chances de survivre à un aller‑retour PPTX. Rouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- Le format binaire PPT précède le modèle complet d'effets DrawingML. Enregistrer en PPT peut omettre les opérations non prises en charge, réduire une chaîne à un sous‑ensemble supporté ou approximer l'apparence. N'utilisez pas le PPT comme format de vérification pour une chaîne modifiable complexe.
- Le rendu en PNG, JPEG, TIFF, PDF, SVG, HTML ou autre sortie visuelle applique la chaîne prise en charge à l'apparence rendue. Ces sorties ne contiennent pas une `ImageTransformOperationCollection` modifiable ; les formats raster aplatissent le résultat en pixels, et les exportations de documents ou vecteurs stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Rendre une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification de couleur sont combinées. Pour une sortie critique, testez à la fois l'aller‑retour éditable et le format d'export final avec la même version d'Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d'image modifient-ils les données de l'image intégrée ?**

Non. Les opérations appartiennent au `Picture` utilisé par le remplissage d'image. Les octets sous‑jacent de `PPImage` restent inchangés.

**Deux cadres d'image qui réutilisent la même image partageront-ils leurs effets ?**

Non. Réutiliser un `PPImage` évite les doublons de données d'image, mais chaque cadre d'image possède normalement un `Picture` distinct et une collection de transformations d'image.

**Les effets de couleur, de flou et alpha peuvent-ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent supprimer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l'opération stockée dans la collection de transformations là où des membres modifiables existent ; sinon supprimez‑la et ajoutez un remplacement avec de nouveaux paramètres de création.

**Quel format devrais‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez PPTX et vérifiez le fichier en le rouvrant. Le PPT hérité ne peut pas représenter le modèle complet d'effets DrawingML, et les formats d'export rendus conservent l'apparence plutôt que les opérations de transformation modifiables.