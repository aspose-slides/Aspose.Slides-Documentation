---
title: Gérer les effets de transformation d'image dans les présentations sur Android
linktitle: Effets de transformation d'image
type: docs
weight: 11
url: /fr/androidjava/image-transform-effects/
keywords:
- transformation d'image
- effet d'image
- luminosité
- contraste
- niveau de gris
- duo-ton
- teinte
- HSL
- remplacement de couleur
- flou
- transparence
- effet alpha
- chaîne d'effets
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Appliquer, chaîner, inspecter, supprimer et vérifier les effets de transformation d'image pour les cadres d'image avec Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d'image comme une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, commencez avec le [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) du cadre et accédez à [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/#getImageTransform--). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/) renvoyée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et de nettoyer les effets sans réécrire les octets d'origine de l'image.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification de la ronde‑trip PPTX.

## **Comprendre la propriété des effets et la réutilisation d'image**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) stocke ou référence les données d'image source détenues par la présentation.
- [ISlidesPicture](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidespicture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformations d'image.
- [IPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipictureframe/) est la forme de diapositive qui possède le remplissage d'image correspondant, la géométrie, les paramètres de recadrage et les autres formats au niveau du cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets de [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/). Lorsque le même `IPPImage` est transmis à [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) plusieurs fois, chaque nouveau cadre d'image reçoit son propre `ISlidesPicture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveau de gris, même si tous réutilisent la même ressource d'image incorporée.

Le même modèle `ISlidesPicture.getImageTransform` est également utilisé par d'autres remplissages d'image, comme une forme ou l'arrière‑plan d'une diapositive. Les exemples ci‑dessous portent sur les cadres d'image.

## **Utiliser des plages de paramètres et des unités valides**

Les méthodes présentées utilisent les plages sémantiques et les unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors plage ; le format de destination peut normaliser, omettre ou rejeter les données invalides lors de l'enregistrement ou à l'ouverture du fichier par PowerPoint.

| Opération | Paramètres | Plage valide et unité |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | de `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Aucun | Aucun paramètre numérique. L'alpha reste inchangé. |
| [addDuotoneEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les valeurs RVB et du canal alpha utilisées par `android.graphics.Color` vont de `0` à `255`. |
| [addTintEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | La teinte est comprise entre `0` (inclus) et `360` (exclu), en degrés ; le montant est de `-100` à `100`, pourcentage. |
| [addHSLEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | La teinte est comprise entre `0` (inclus) et `360` (exclu), en degrés ; la saturation et la luminance sont de `-100` à `100`, pourcentage. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Le rayon est non négatif et est exprimé en points ; `grow` est un booléen qui indique si le contenu flouté peut dépasser les limites d'origine. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un réglage d'opacité standard : `0` est totalement transparent et `100` conserve l'alpha existant. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | De `0` à `100`, pourcentage d'opacité. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | De `0` à `100`, pourcentage de seuil alpha. Les valeurs inférieures deviennent transparentes ; les valeurs égales ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, la transparence et l'opacité sont complémentaires. Par exemple, 35 % de transparence correspond à un montant de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) renvoie une opération [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l'opération. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/#getEffective--) renvoie des valeurs calculées en lecture seule qui peuvent être inspectées ou journalisées.

L'exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis rend un aperçu sans modifier l'image incorporée :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    IBrightnessContrast brightnessContrast = imageTransform.addBrightnessContrastEffect(15f, 20f);

    IBrightnessContrastEffectiveData effectiveValues = brightnessContrast.getEffective();
    System.out.println("Brightness: " + effectiveValues.getBrightness() + "%");
    System.out.println("Contrast: " + effectiveValues.getContrast() + "%");

    IImage preview = slide.getImage();
    try {
        preview.save("brightness-contrast-preview.png", ImageFormat.Png);
    } finally {
        preview.dispose();
    }
} finally {
    presentation.dispose();
}
```

[BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) est une extension d'effet d'image Office 2010 et est moins portable que l'effet de luminance standard DrawingML. Lorsque la luminosité et le contraste doivent rester éditables après un aller‑retour PPTX, utilisez [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) et vérifiez le résultat après réouverture du fichier. La section des limitations de format explique cette distinction plus en détail.

## **Appliquer les transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d'image qui réutilisent la même ressource. L'exemple suivant crée cinq cadres et applique respectivement le niveau de gris, le duo‑ton, la teinte, le réglage HSL et le remplacement de couleur.

[IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) contient deux paramètres de couleur éditables de façon indépendante : `color1` correspond aux pixels sombres, tandis que `color2` correspond aux pixels clairs. Cela en fait un exemple utile d'effet dont les paramètres sont plus complexes qu'une simple valeur scalaire.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(Color.rgb(0, 0, 128));
    duotone.getColor2().setColor(Color.rgb(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(Color.rgb(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) remplace la couleur de chaque pixel par une couleur fixe tout en conservant l'alpha. Il diffère de [addColorChangeEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), qui mappe une couleur source vers une couleur cible et expose les deux formats de couleur source et cible.

### **Appliquer un seuil de luminance**

Un seuil de luminance peut rendre les marques faibles sur une page numérisée plus faciles à distinguer du fond. [addGrayScaleEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) conserve les nuances intermédiaires de gris. [addBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBiLevelEffect-float-) mappe la luminance en noir ou blanc, tandis que [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) applique un seuil à l'opacité.

Le seuil de luminance varie de 0 % à 100 %, inclus. Les pixels en dessous du seuil deviennent noirs. Les pixels égaux ou supérieurs deviennent blancs. Augmenter le seuil rend plus de nuances noires parce que davantage d'entre elles tombent sous la coupure.

Téléchargez [grayscale‑swatches.png](grayscale-swatches.png) dans le répertoire de travail. Chaque libellé indique le niveau de gris original sur une échelle de 0 à 255. L'exemple place l'original à côté de deux copies et enregistre le seuil de chaque copie dans la présentation.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 150, SlideSizeScaleType.DoNotScale);
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    IPPImage image;
    IImage sourceImage = Images.fromFile("grayscale-swatches.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    String[] captions = { "Original", "Threshold 20%", "Threshold 60%" };
    IPictureFrame[] frames = new IPictureFrame[captions.length];
    for (int i = 0; i < captions.length; i++) {
        float x = 12 + 240 * i;
        IAutoShape label = shapes.addAutoShape(ShapeType.Rectangle, x, 12, 216, 36);
        label.getTextFrame().setText(captions[i]);
        frames[i] = shapes.addPictureFrame(ShapeType.Rectangle, x, 60, 216, 72, image);
    }

    frames[1].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(20f);
    frames[2].getPictureFormat().getPicture().getImageTransform().addBiLevelEffect(60f);

    presentation.save("luminance-threshold.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ouvrez la présentation de sortie dans PowerPoint pour comparer les trois cadres. L'échantillon libellé 96 a environ 38 % de luminance (96 sur 255). Il devient blanc au seuil de 20 % et noir au seuil de 60 %.

![Original grayscale swatches beside the black-and-white results at luminance thresholds of 20% and 60%](luminance-threshold.png)

## **Ajouter du flou, de la transparence et des effets alpha**

[addBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) agit sur tous les canaux de couleur, y compris l'alpha. Réglez `grow` sur `true` lorsque le bord flouté peut dépasser les limites de l'image d'origine.

Pour une transparence uniforme, utilisez [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents restent proportionnellement différents. [addAlphaReplaceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) attribue à la place une seule valeur alpha à tous les pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) convertit l'alpha en deux niveaux basés sur un seuil.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }

    IPictureFrame blurredFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
    IBlur blur = blurredFrame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, true);
    blur.setRadius(5);

    IPictureFrame transparentFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
    IAlphaModulateFixed alphaModulate = transparentFrame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65f);
    alphaModulate.setAmount(60f);

    IPictureFrame uniformAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
    uniformAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55f);

    IPictureFrame binaryAlphaFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
    IAlphaBiLevel alphaBiLevel = binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50f);
    alphaBiLevel.setThreshold(45f);
    binaryAlphaFrame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect();

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

D'autres opérations alpha sans paramètre incluent [addAlphaCeilingEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--) qui rend tout alpha non nul complètement opaque ; [addAlphaFloorEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--) qui rend tout alpha inférieur à 100 % totalement transparent ; et [addAlphaInverseEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--) qui transforme l'alpha en `100% - alpha`.

## **Construire une chaîne d'effets ordonnée**

Chaque méthode `add...Effect` ajoute une nouvelle opération à la fin de la collection. Le rendu utilise la collection comme un pipeline ordonné : la sortie de l'opération 0 devient l'entrée de l'opération 1, etc. Par conséquent, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d'une teinte supprime d'abord les informations chromatiques puis recolore le résultat de luminance. Une teinte suivie de niveau de gris supprime de nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations antérieures, tandis que la modulation alpha conserve leurs différences relatives.

L'exemple suivant construit une chaîne de quatre opérations, l'enregistre au format PPTX, rouvre la présentation, vérifie à la fois les types d'opérations et leur ordre, puis rend le résultat rouvert :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IPPImage image;
    IImage sourceImage = Images.fromFile("photo.png");
    try {
        image = presentation.getImages().addImage(sourceImage);
    } finally {
        sourceImage.dispose();
    }
    IPictureFrame pictureFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

    IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
    imageTransform.addGrayScaleEffect();
    imageTransform.addTintEffect(220f, 25f);
    imageTransform.addBlurEffect(2.5, false);
    imageTransform.addAlphaModulateFixedEffect(80f);

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation("image-transform-chain.pptx");
try {
    IShape reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);

    if (reopenedShape instanceof IPictureFrame) {
        IPictureFrame reopenedFrame = (IPictureFrame) reopenedShape;
        IImageTransformOperationCollection reopenedTransform = reopenedFrame.getPictureFormat().getPicture().getImageTransform();
        boolean orderIsPreserved = reopenedTransform.size() == 4 && 
                reopenedTransform.get_Item(0) instanceof IGrayScale && 
                reopenedTransform.get_Item(1) instanceof ITint && 
                reopenedTransform.get_Item(2) instanceof IBlur && 
                reopenedTransform.get_Item(3) instanceof IAlphaModulateFixed;
        System.out.println(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

        IImage renderedSlide = reopenedPresentation.getSlides().get_Item(0).getImage();
        try {
            renderedSlide.save("reopened-effect-chain.png", ImageFormat.Png);
        } finally {
            renderedSlide.dispose();
        }
    } else {
        System.out.println("The reopened shape is not a picture frame.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

La collection n'impose pas de matrice de compatibilité qui restreint les opérations de couleur, d'alpha et de flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement de couleur fixe supprime la variation RVB produite par les effets de couleur antérieurs ; le niveau de gris après duo‑ton supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent éliminer les détails alpha créés précédemment. Construisez la chaîne selon la séquence de traitement pixel souhaitée plutôt que de traiter ses éléments comme des indicateurs de formatage non ordonnés.


<!-- visual-explanation:image-transform-effects:start -->
[![The same image passes through grayscale then tint, and tint then grayscale. The two final grayscale images have different tones.](visual-image-transform-effects-49aa72211f3a.svg)](visual-image-transform-effects-49aa72211f3a.svg)

*In this illustrative Aspose.Slides for .NET 26.11 render, a 220° tint at 25% leaves the grayscale image unchanged. Applying the same tint before grayscale produces different tones.*
<!-- visual-explanation:image-transform-effects:end -->

## **Inspecter les valeurs éditables et effectives**

Une opération éditable est l'objet stocké dans `ISlidesPicture.getImageTransform`. Selon l'effet, il peut exposer des membres modifiables directement. Par exemple, [IBlur](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/) expose les valeurs modifiables `radius` et `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphamodulatefixed/) expose un `amount` modifiable, et [IAlphaBiLevel](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphabilevel/) expose un `threshold` modifiable. Les effets de couleur tels que [IDuotone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iduotone/) exposent des objets [IColorFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) mutables.

Certaines interfaces d'opération, y compris [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itint/), et [IAlphaReplace](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ialphareplace/), n'exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces paramètres, supprimez l'opération et ajoutez une substitution à la position requise.

Les données effectives renvoyées par `getEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le rendu, mais ne constituent pas une autre surface d'édition. L'exemple suivant parcourt la chaîne et inspecte les valeurs effectives là où l'API correspondante les fournit :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();

        for (int index = 0; index < imageTransform.size(); index++) {
            IImageTransformOperation operation = imageTransform.get_Item(index);
            System.out.println(index + ": " + operation.getClass().getSimpleName());

            if (operation instanceof IBrightnessContrast) {
                IBrightnessContrastEffectiveData data = ((IBrightnessContrast) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof ILuminance) {
                ILuminanceEffectiveData data = ((ILuminance) operation).getEffective();
                System.out.println("  Brightness: " + data.getBrightness());
                System.out.println("  Contrast: " + data.getContrast());
            } else if (operation instanceof IDuotone) {
                IDuotoneEffectiveData data = ((IDuotone) operation).getEffective();
                System.out.println("  Dark color: " + data.getColor1());
                System.out.println("  Light color: " + data.getColor2());
            } else if (operation instanceof IColorReplace) {
                IColorReplaceEffectiveData data = ((IColorReplace) operation).getEffective();
                System.out.println("  Replacement color: " + data.getColor());
            } else if (operation instanceof IHSL) {
                IHSLEffectiveData data = ((IHSL) operation).getEffective();
                System.out.println("  HSL: " + data.getHue() + ", " + data.getSaturation() + ", " + data.getLuminance());
            } else if (operation instanceof ITint) {
                ITintEffectiveData data = ((ITint) operation).getEffective();
                System.out.println("  Tint: " + data.getHue() + ", " + data.getAmount());
            } else if (operation instanceof IBlur) {
                IBlurEffectiveData data = ((IBlur) operation).getEffective();
                System.out.println("  Blur radius: " + data.getRadius() + " pt");
            } else if (operation instanceof IAlphaModulateFixed) {
                IAlphaModulateFixedEffectiveData data = ((IAlphaModulateFixed) operation).getEffective();
                System.out.println("  Alpha amount: " + data.getAmount() + "%");
            } else if (operation instanceof IAlphaReplace) {
                IAlphaReplaceEffectiveData data = ((IAlphaReplace) operation).getEffective();
                System.out.println("  Replacement alpha: " + data.getAlpha() + "%");
            } else if (operation instanceof IAlphaBiLevel) {
                IAlphaBiLevelEffectiveData data = ((IAlphaBiLevel) operation).getEffective();
                System.out.println("  Alpha threshold: " + data.getThreshold() + "%");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Les effets sans paramètre tels que le niveau de gris, le plafond alpha et l'inverse alpha possèdent néanmoins un objet de données effectives, mais il n'y a aucun paramètre scalaire à imprimer. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou nettoyer les transformations d'image**

Utilisez [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) pour supprimer une opération par son index. Comme les index changent après une suppression, recherchez d'abord la cible puis supprimez‑la après l'énumération. Utilisez [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imagetransformoperationcollection/#clear--) pour supprimer toute la chaîne.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("image-transform-chain.pptx");
try {
    IPictureFrame pictureFrame = null;

    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IPictureFrame) {
            pictureFrame = (IPictureFrame) shape;
            break;
        }
    }

    if (pictureFrame != null) {
        IImageTransformOperationCollection imageTransform = pictureFrame.getPictureFormat().getPicture().getImageTransform();
        int blurIndex = -1;

        for (int index = 0; index < imageTransform.size(); index++) {
            if (imageTransform.get_Item(index) instanceof IBlur) {
                blurIndex = index;
                break;
            }
        }

        if (blurIndex >= 0) {
            imageTransform.removeAt(blurIndex);
            System.out.println("The blur operation was removed.");
        }

        imageTransform.clear();
        System.out.println("Remaining operations: " + imageTransform.size());
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Supprimer ou nettoyer les transformations ne modifie que le formatage de l'image. Cela ne supprime pas, ne recompresse pas et ne modifie pas la ressource [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d'exportation**

Les transformations d'image proviennent de DrawingML, le format PPTX est donc le format éditable privilégié pour les chaînes d'effets. Même avec PPTX, toutes les opérations ne bénéficient pas d'une portabilité identique :

- Les opérations DrawingML standard telles que la luminance, le niveau de gris, le duo‑ton, la teinte, le HSL, le flou et les opérations alpha courantes ont la meilleure chance de survivre à un aller‑retour PPTX. Réouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/brightnesscontrast/) est une extension Office 2010 plutôt que l'opération de luminance DrawingML standard. Elle peut être utilisée pour le rendu en mémoire, mais il n'est pas garanti qu'elle reste en tant que [IBrightnessContrast](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibrightnesscontrast/) éditable après sauvegarde et réouverture du PPTX. Privilégiez [addLuminanceEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) pour des réglages de luminosité et contraste persistants.
- Le format binaire PPT précède le modèle complet d'effets DrawingML. L'enregistrement en PPT peut omettre les opérations non supportées, réduire une chaîne à un sous‑ensemble supporté ou approximativer l'apparence. N'utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou d'autres sorties visuelles applique la chaîne supportée à l'apparence rendue. Ces sorties ne contiennent pas de `IImageTransformOperationCollection` éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document/vecteur stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Rendre une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification de couleur sont combinées. Pour une sortie critique, testez à la fois le aller‑retour éditable et le format d'export final avec la même version d'Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d'image modifient-ils les données d'image incorporées ?**

Non. Les opérations appartiennent au `ISlidesPicture` utilisé par le remplissage d'image. Les octets sous‑jacents de `IPPImage` restent inchangés.

**Deux cadres d'image qui réutilisent la même image partageront‑ils leurs effets ?**

Non. Réutiliser un `IPPImage` évite la duplication des données d'image, mais chaque cadre d'image possède normalement un `ISlidesPicture` distinct et une collection de transformations d'image séparée.

**Les effets de couleur, de flou et alpha peuvent‑ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent éliminer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l'opération stockée dans la collection de transformations lorsque des membres modifiables existent ; sinon supprimez‑la et ajoutez une substitution avec de nouveaux paramètres de création.

**Quel format dois‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez le PPTX et vérifiez le fichier en le réouvrant. Le PPT hérité ne peut pas représenter le modèle complet d'effets DrawingML, et les formats d'exportation rendus conservent l'apparence plutôt que les opérations de transformation éditables.