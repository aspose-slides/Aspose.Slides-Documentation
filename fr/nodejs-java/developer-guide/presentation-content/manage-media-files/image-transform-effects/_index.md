---
title: Gérer les effets de transformation d'image dans les présentations avec JavaScript
linktitle: Effets de transformation d'image
type: docs
weight: 11
url: /fr/nodejs-java/image-transform-effects/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer, chaîner, inspecter, supprimer et vérifier les effets de transformation d'image pour les cadres d'image avec Aspose.Slides pour Node.js via Java."
---
## **Vue d’ensemble**

Aspose.Slides représente les ajustements d'image comme une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, commencez avec le [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) du cadre et accédez à [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) renvoyée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et de réinitialiser les effets sans réécrire les octets d'image originaux.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification du voyage aller‑retour PPTX.

## **Comprendre la propriété des effets et la réutilisation d’image**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) stocke ou référence les données d'image source possédées par la présentation.
- [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformation d'image.
- [PictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pictureframe/) est la forme de diapositive qui possède le remplissage d'image pertinent, la géométrie, les paramètres de recadrage et d'autres mises en forme au niveau du cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets du [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/). Lorsque le même [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) est passé à [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/) plusieurs fois, chaque nouveau cadre d'image reçoit son propre [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d'image incorporée.

Le même modèle [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) est également utilisé par d'autres remplissages d'image, tels qu'une forme ou l'arrière‑plan d'une diapositive. Les exemples ci‑dessous portent sur les cadres d'image.

## **Utiliser des plages de paramètres et des unités valides**

Les méthodes présentées utilisent les plages sémantiques et les unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors plage ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l’enregistrement ou lorsque PowerPoint ouvre le fichier.

| Opération | Paramètres | Plage valide et unité |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `brightness`, `contrast` | `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | Aucun | Aucun paramètre numérique. L'alpha reste inchangé. |
| [addDuotoneEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `java.awt.Color` utilisent `0` à `255`. |
| [addTintEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `amount` | La teinte est comprise entre `0` (inclus) et `360` (exclus), en degrés ; la quantité est de `-100` à `100`, pourcentage. |
| [addHSLEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `hue`, `saturation`, `luminance` | La teinte est comprise entre `0` (inclus) et `360` (exclus), en degrés ; saturation et luminance sont de `-100` à `100`, pourcentage. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `radius`, `grow` | Le rayon est non négatif et mesuré en points ; `grow` est un booléen qui contrôle si le contenu flou peut dépasser les limites originales. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un réglage d’opacité ordinaire : `0` est totalement transparent et `100` conserve l'alpha existant. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `alpha` | `0` à `100`, pourcentage d’opacité. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) | `threshold` | `0` à `100`, pourcentage de seuil alpha. Les valeurs en dessous deviennent transparentes ; les valeurs au‑déjà‑le‑niveau ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, transparence et opacité sont complémentaires. Par exemple, 35 % de transparence correspond à un montant de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) renvoie une opération [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l'opération. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) renvoie des valeurs calculées en lecture seule qui peuvent être inspectées ou consignées.

L’exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis rend un aperçu sans modifier l’image incorporée :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    const brightnessContrast = imageTransform.addBrightnessContrastEffect(15, 20);

    const effectiveValues = brightnessContrast.getEffective();
    console.log("Brightness: " + effectiveValues.getBrightness() + "%");
    console.log("Contrast: " + effectiveValues.getContrast() + "%");

    const preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", aspose.slides.ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) est une extension d’effet d’image Office 2010 et est moins portable que l’effet de luminance standard DrawingML. Lorsque la luminosité et le contraste doivent rester modifiables après un aller‑retour PPTX, utilisez [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) et vérifiez le résultat après réouverture du fichier. La section des limitations de format explique cette distinction plus en détail.

## **Appliquer les transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d’image qui réutilisent une même ressource d’image. L’exemple suivant crée cinq cadres et applique le niveau de gris, le duotone, la teinte, le réglage HSL et le remplacement de couleur.

[Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) contient deux paramètres de couleur éditables indépendamment : `color1` mappe les pixels sombres, tandis que `color2` mappe les pixels clairs. Cela en fait un exemple utile d’un effet dont les paramètres sont plus complexes qu’une simple valeur scalaire.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const grayFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    const duotoneFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 220, 20, 180, 120, image);
    const duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(java.newInstanceSync("java.awt.Color", 0, 0, 128));
    duotone.getColor2().setColor(java.newInstanceSync("java.awt.Color", 255, 215, 0));

    const tintFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210, 35);

    const hslFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30, 20, -10);

    const replacementFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 320, 170, 180, 120, image);
    const colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(java.newInstanceSync("java.awt.Color", 100, 149, 237));

    presentation.save("color-transformations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) remplace la couleur de chaque pixel par une couleur fixe tout en préservant l’alpha. C’est différent de [addColorChangeEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), qui mappe une couleur source vers une autre et expose les formats de couleur source et cible.

### **Appliquer un seuil de luminance**

Un seuil de luminance peut rendre les marques faibles d’une page numérisée plus faciles à distinguer de l’arrière‑plan. [addGrayScaleEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) conserve les nuances intermédiaires de gris. [addBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) mappe la luminance vers le noir ou le blanc, tandis que [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) applique un seuil à l’opacité.

Le seuil de luminance varie de 0 % à 100 %, inclus. Les pixels en dessous du seuil deviennent noirs. Les pixels au‑déjà‑le‑niveau ou supérieurs deviennent blancs. Augmenter le seuil rend davantage de nuances noires parce que plus d’entre elles tombent sous la coupure.

Téléchargez [grayscale-swatches.png](grayscale-swatches.png) dans le répertoire de travail. Chaque libellé indique le niveau de gris original sur une échelle de 0 à 255. L’exemple place l’original à côté de deux copies et enregistre le seuil de chaque copie dans la présentation.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, slides.SlideSizeScaleType.DoNotScale);
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const sourceImage = slides.Images.fromFile("grayscale-swatches.png");
    let image;
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const captions = ["Original", "Threshold 20%", "Threshold 60%"];
    const frames = [];
    for (let i = 0; i < captions.length; i++) {
        const x = 12 + 240 * i;
        const label = shapes.addAutoShape(slides.ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        const frame = shapes.addPictureFrame(slides.ShapeType.Rectangle, x, 60, 216, 72, image);
        frames.push(frame);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60);
    
    presentation.save("luminance-threshold.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ouvrez la présentation de sortie dans PowerPoint pour comparer les trois cadres. L’échantillon libellé 96 a environ 38 % de luminance (96 sur 255). Il devient blanc au seuil de 20 % et noir au seuil de 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Ajouter du flou, de la transparence et des effets alpha**

[addBlurEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) affecte tous les canaux de couleur, y compris l’alpha. Réglez `grow` sur `true` lorsque le bord flou peut dépasser les limites originales de l’image.

Pour une transparence uniforme, utilisez [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents restent proportionnellement différents. [addAlphaReplaceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) attribue à la place une même valeur alpha à tous les pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) convertit l’alpha en deux niveaux selon un seuil.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const blurredFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 20, 200, 140, image);
    const blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    const transparentFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 20, 200, 140, image);
    const alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65);
    alphaModulate.setAmount(60);

    const uniformAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55);

    const binaryAlphaFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 240, 180, 200, 140, image);
    const alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50);
    alphaBiLevel.setThreshold(45);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

D’autres opérations alpha sans paramètres comprennent [addAlphaCeilingEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), qui rend chaque alpha non nul totalement opaque ; [addAlphaFloorEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), qui rend chaque alpha inférieur à 100 % totalement transparent ; et [addAlphaInverseEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/), qui change l’alpha en `100% - alpha`.

## **Construire une chaîne d’effets ordonnée**

Chaque méthode `add...Effect` ajoute une nouvelle opération à la fin de la collection. Le moteur de rendu utilise la collection comme un pipeline ordonné : la sortie de l’opération 0 devient l’entrée de l’opération 1, etc. Par conséquent, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi de la teinte supprime d’abord l’information chromatique puis recolore le résultat de luminance. La teinte suivie du niveau de gris supprime de nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations antérieures, tandis que la modulation alpha conserve leurs différences relatives.

L’exemple suivant crée une chaîne de quatre opérations, l’enregistre au format PPTX, rouvre la présentation, vérifie à la fois les types d’opérations et leur ordre, puis rend le résultat rouvé :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    let image;
    const sourceImage = aspose.slides.Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    const pictureFrame = slide.getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 400, 260, image);
    const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220, 25);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80);

    presentation.save("image-transform-chain.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (java.instanceOf(reopenedShape, "com.aspose.slides.IPictureFrame")) {
        const reopenedTransform = reopenedShape.getPictureFormat().getPicture().getImageTransform();
        const orderIsPreserved = reopenedTransform.size() === 4 &&
            java.instanceOf(reopenedTransform.get_Item(0), "com.aspose.slides.IGrayScale") &&
            java.instanceOf(reopenedTransform.get_Item(1), "com.aspose.slides.ITint") &&
            java.instanceOf(reopenedTransform.get_Item(2), "com.aspose.slides.IBlur") &&
            java.instanceOf(reopenedTransform.get_Item(3), "com.aspose.slides.IAlphaModulateFixed");
        console.log(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        const renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", aspose.slides.ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        console.log("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

La collection n’impose pas de matrice de compatibilité qui limite les opérations couleur, alpha et flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement couleur fixe supprime la variation RVB produite par les effets couleur antérieurs ; le niveau de gris après duotone supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent éliminer les détails alpha créés précédemment. Construisez la chaîne selon la séquence de traitement des pixels souhaitée plutôt que de considérer ses éléments comme des drapeaux de formatage non ordonnés.

<!-- visual-explanation:image-transform-effects:start -->
[![La même image passe d'abord par le niveau de gris puis la teinte, et la teinte puis le niveau de gris. Les deux images finales en niveaux de gris ont des tons différents.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*Dans ce rendu illustratif Aspose.Slides pour .NET 26.11, une teinte de 220° à 25 % laisse l’image en niveaux de gris inchangée. Appliquer la même teinte avant le niveau de gris produit des tons différents.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspecter les valeurs éditables et effectives**

Une opération éditable est l’objet stocké dans [Picture.getImageTransform](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/). Selon l’effet, il peut exposer des membres modifiables directement. Par exemple, [Blur](https://reference.aspose.com/slides/nodejs-java/aspose.slides/blur/) expose les valeurs modifiables `radius` et `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphamodulatefixed/) expose un `amount` modifiable, et [AlphaBiLevel](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphabilevel/) expose un `threshold` modifiable. Les effets couleur tels que [Duotone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/duotone/) exposent des objets [ColorFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/colorformat/) mutables.

Certaines opérations, y compris [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/nodejs-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tint/), et [AlphaReplace](https://reference.aspose.com/slides/nodejs-java/aspose.slides/alphareplace/), n’exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces paramètres, supprimez l’opération et ajoutez un remplacement à la position requise.

Les données effectives renvoyées par `getEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le moteur de rendu, mais il ne s’agit pas d’une autre surface d’édition. L’exemple suivant énumère la chaîne et inspecte les valeurs effectives là où l’API correspondante les fournit :

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (let index = 0; index < imageTransform.size(); index++) {
            const operation = imageTransform.get_Item(index);
            console.log(index + ": " + operation.getClass().getSimpleName());

            if (java.instanceOf(operation, "com.aspose.slides.IBrightnessContrast")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.ILuminance")) {
                const data = operation.getEffective();
                console.log("  Brightness: " + data.getBrightness());
                console.log("  Contrast: " + data.getContrast());
            } else if (java.instanceOf(operation, "com.aspose.slides.IDuotone")) {
                const data = operation.getEffective();
                console.log("  Dark color: " + data.getColor1());
                console.log("  Light color: " + data.getColor2());
            } else if (java.instanceOf(operation, "com.aspose.slides.IColorReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement color: " + data.getColor());
            } else if (java.instanceOf(operation, "com.aspose.slides.IHSL")) {
                const data = operation.getEffective();
                console.log("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (java.instanceOf(operation, "com.aspose.slides.ITint")) {
                const data = operation.getEffective();
                console.log("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (java.instanceOf(operation, "com.aspose.slides.IBlur")) {
                const data = operation.getEffective();
                console.log("  Blur radius: " + data.getRadius() + " pt");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaModulateFixed")) {
                const data = operation.getEffective();
                console.log("  Alpha amount: " + data.getAmount() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaReplace")) {
                const data = operation.getEffective();
                console.log("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (java.instanceOf(operation, "com.aspose.slides.IAlphaBiLevel")) {
                const data = operation.getEffective();
                console.log("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Les effets sans paramètres tels que le niveau de gris, le plafond alpha et l’inverse alpha possèdent toujours un objet de données effectives, mais il n’y a aucune valeur scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou réinitialiser les transformations d’image**

Utilisez [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) pour supprimer une opération par indice. Comme les indices changent après une suppression, recherchez d’abord la cible puis supprimez‑la après l’énumération. Utilisez [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) pour supprimer l’ensemble de la chaîne.

```javascript
const aspose = {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("image-transform-chain.pptx");
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();
    let pictureFrame = null;

    for (let index = 0; index < shapes.size(); index++) {
        const shape = shapes.get_Item(index);
        if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
            pictureFrame = shape;
            break;
        }
    }

    if (pictureFrame != null) {
        const imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        let blurIndex = -1;

        for (let index = 0; index < imageTransform.size(); index++) {
            if (java.instanceOf(imageTransform.get_Item(index), "com.aspose.slides.IBlur")) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            console.log("The blur operation was removed.");
        }

        imageTransform.clear();
        console.log("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", aspose.slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Supprimer ou réinitialiser les transformations ne modifie que le formatage de l’image. Cela ne supprime pas, ne recomprime pas et ne modifie pas la ressource [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d’exportation**

Les transformations d’image proviennent de DrawingML, ainsi le PPTX est le format éditable privilégié pour les chaînes d’effets. Même avec le PPTX, toutes les opérations ne sont pas également portables :

- Les opérations DrawingML standards telles que la luminance, le niveau de gris, le duotone, la teinte, le HSL, le flou et les opérations alpha communes ont les meilleures chances de survivre à un aller‑retour PPTX. Rouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) est une extension Office 2010 plutôt que l’opération de luminance DrawingML standard. Elle peut être utilisée pour le rendu en mémoire, mais aucune garantie n’est donnée qu’elle restera une opération [BrightnessContrast](https://reference.aspose.com/slides/nodejs-java/aspose.slides/brightnesscontrast/) éditable après enregistrement et réouverture du PPTX. Privilégiez [addLuminanceEffect](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) pour des réglages de luminosité et contraste persistants.
- Le format binaire PPT précède le modèle complet d’effets DrawingML. En enregistrant au format PPT, les opérations non prises en charge peuvent être omises, la chaîne peut être réduite à un sous‑ensemble pris en charge, ou l’apparence peut être approximée. N’utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou tout autre sortie visuelle applique la chaîne prise en charge à l’apparence rendue. Ces sorties ne contiennent pas de [ImageTransformOperationCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/imagetransformoperationcollection/) éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document/vector stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Le rendu d’une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification de couleur sont combinées. Pour des sorties critiques, testez à la fois le voyage aller‑retour éditable et le format d’exportation final avec la même version d’Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d'image modifient-ils les données de l'image incorporée ?**

Non. Les opérations appartiennent au [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) utilisé par le remplissage d'image. Les octets du [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) sous‑jacent restent inchangés.

**Deux cadres d'image qui réutilisent la même image partagent‑ils leurs effets ?**

Non. Réutiliser un [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) évite les doublons de données d’image, mais chaque cadre d'image possède normalement un [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picture/) et une collection de transformation d'image distincts.

**Les effets couleur, flou et alpha peuvent‑ils être combinés ?**

Oui. La collection accepte une chaîne ordonnée les incluant tous. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent éliminer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l’opération stockée dans la collection de transformations là où des membres modifiables existent ; sinon supprimez‑la et ajoutez un remplacement avec de nouveaux paramètres de création.

**Quel format devrais‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez le PPTX et vérifiez le fichier en le rouvrant. Le PPT hérité ne peut pas représenter le modèle complet d’effets DrawingML, et les formats d’exportation rendus conservent l’apparence plutôt que les opérations de transformation éditables.