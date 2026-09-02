---
title: Gérer les effets de transformation d'image dans les présentations avec Java
linktitle: Effets de transformation d'image
type: docs
weight: 11
url: /fr/java/image-transform-effects/
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
- Java
- Aspose.Slides
description: "Appliquer, chaîner, inspecter, supprimer et vérifier les effets de transformation d'image pour les cadres d'image avec Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d'image comme une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, commencez par le [ISlidesPicture](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidespicture/) du cadre et accédez à [ISlidesPicture.getImageTransform](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidespicture/#getImageTransform--). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/) retournée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et de vider les effets sans réécrire les octets d'image originaux.

Cet article démontre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification de la ronde‑trip PPTX.

## **Comprendre la propriété des effets et la réutilisation d'image**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) stocke ou référence les données d'image source appartenant à la présentation.
- [ISlidesPicture](https://reference.aspose.com/slides/fr/java/com.aspose.slides/islidespicture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformations d'image.
- [IPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ipictureframe/) est la forme de diapositive qui possède le remplissage d'image pertinent, la géométrie, les paramètres de rognage et les autres mises en forme au niveau du cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets de [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/). Lorsque le même `IPPImage` est transmis à [IShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishapecollection/#addPictureFrame-int-float-float-float-float-com.aspose.slides.IPPImage-) plus d'une fois, chaque nouveau cadre d'image reçoit son propre `ISlidesPicture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d'image incorporée.

Le même modèle `ISlidesPicture.getImageTransform` est également utilisé par d'autres remplissages d'image, tels qu'une forme ou un arrière‑plan de diapositive. Les exemples ci‑dessous se concentrent sur les cadres d'image.

## **Utiliser des plages de paramètres valides et des unités**

Les méthodes présentées utilisent les plages sémantiques et les unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors plage ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l'enregistrement ou lorsque PowerPoint ouvre le fichier.

| Opération | Paramètres | Plage valide et unité |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) | `brightness`, `contrast` | `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addGrayScaleEffect--) | Aucun | Aucun paramètre numérique. Alpha inchangé. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addDuotoneEffect--) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `java.awt.Color` utilisent `0` à `255`. |
| [addTintEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addTintEffect-float-float-) | `hue`, `amount` | Teinte de `0` inclus à `360` exclus, en degrés ; quantité de `-100` à `100`, pourcentage. |
| [addHSLEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addHSLEffect-float-float-float-) | `hue`, `saturation`, `luminance` | Teinte de `0` inclus à `360` exclus, en degrés ; saturation et luminance de `-100` à `100`, pourcentage. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [addBlurEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) | `radius`, `grow` | Rayon non négatif mesuré en points ; `grow` est un booléen qui contrôle si le contenu flou peut dépasser les limites d'origine. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un redimensionnement d'opacité ordinaire : `0` est totalement transparent et `100` préserve l'alpha existant. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) | `alpha` | `0` à `100`, pourcentage d'opacité. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) | `threshold` | `0` à `100`, pourcentage de seuil alpha. Les valeurs en dessous deviennent transparentes ; les valeurs au‑dessus ou égales deviennent opaques. |

Pour la modulation alpha fixe, transparence et opacité sont complémentaires. Par exemple, 35 % de transparence correspond à une valeur de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[IImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addBrightnessContrastEffect-float-float-) renvoie une opération [IBrightnessContrast](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibrightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l'opération. [IBrightnessContrast.getEffective](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibrightnesscontrast/#getEffective--) renvoie les valeurs en lecture seule calculées qui peuvent être inspectées ou journalisées.

L'exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis rend un aperçu sans modifier l'image incorporée :

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

[BrightnessContrast](https://reference.aspose.com/slides/fr/java/com.aspose.slides/brightnesscontrast/) est une extension d'effet d'image Office 2010 et est moins portable que l'effet de luminance standard de DrawingML. Lorsque la luminosité et le contraste doivent rester modifiables après un aller‑retour PPTX, utilisez [IImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) et vérifiez le résultat après réouverture du fichier. La section des limitations de format explique cette distinction plus en détail.

## **Appliquer des transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d'image qui réutilisent une même ressource d'image. L'exemple suivant crée cinq cadres et applique le niveau de gris, le duotone, la teinte, le réglage HSL et le remplacement de couleur.

[IDuotone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iduotone/) comprend deux paramètres de couleur modifiables indépendamment : `color1` représente les pixels sombres, tandis que `color2` représente les pixels clairs. C'est donc un exemple utile d'effet dont les réglages sont plus complexes qu'une simple valeur scalaire.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

    IPictureFrame grayFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
    grayFrame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect();

    IPictureFrame duotoneFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
    IDuotone duotone = duotoneFrame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect();
    duotone.getColor1().setColor(new Color(0, 0, 128));
    duotone.getColor2().setColor(new Color(255, 215, 0));

    IPictureFrame tintFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
    tintFrame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210f, 35f);

    IPictureFrame hslFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
    hslFrame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30f, 20f, -10f);

    IPictureFrame replacementFrame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
    IColorReplace colorReplacement = replacementFrame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect();
    colorReplacement.getColor().setColor(new Color(100, 149, 237));

    presentation.save("color-transformations.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addColorReplaceEffect--) remplace la couleur de chaque pixel par une couleur fixe tout en préservant l'alpha. Il diffère de [addColorChangeEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addColorChangeEffect--), qui mappe une couleur source vers une autre et expose les formats couleur source et cible.

## **Ajouter le flou, la transparence et les effets alpha**

[addBlurEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addBlurEffect-double-boolean-) agit sur tous les canaux de couleur, y compris l'alpha. Réglez `grow` sur `true` lorsque le bord flou peut dépasser les limites de l'image d'origine.

Pour une transparence uniforme, utilisez [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaModulateFixedEffect-float-). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents conservent leurs différences proportionnelles. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaReplaceEffect-float-) affecte plutôt une même valeur alpha à tous les pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaBiLevelEffect-float-) convertit l'alpha en deux niveaux selon un seuil.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);

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

D'autres opérations alpha sans paramètre incluent [addAlphaCeilingEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaCeilingEffect--), qui rend chaque alpha non nul complètement opaque ; [addAlphaFloorEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaFloorEffect--), qui rend chaque alpha inférieur à 100 % totalement transparent ; et [addAlphaInverseEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addAlphaInverseEffect--), qui change l'alpha en `100% - alpha`.

## **Construire une chaîne d'effets ordonnée**

Chaque méthode `add...Effect` ajoute une nouvelle opération à la fin de la collection. Le rendu utilise la collection comme pipeline ordonné : la sortie de l'opération 0 devient l'entrée de l'opération 1, et ainsi de suite. Par conséquent, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d'une teinte supprime d'abord les informations chromatiques puis recolorie le résultat de luminance. Une teinte suivie de niveau de gris supprime à nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations antérieures, tandis que la modulation alpha préserve leurs différences relatives.

L'exemple suivant construit une chaîne de quatre opérations, l'enregistre au format PPTX, rouvre la présentation, vérifie à la fois les types d'opérations et leur ordre, puis rend le résultat rouvert :

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    byte[] imageData = Files.readAllBytes(Paths.get("photo.png"));
    IPPImage image = presentation.getImages().addImage(imageData);
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

La collection n'impose pas une matrice de compatibilité qui restreint les opérations couleur, alpha et flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement de couleur fixe supprime la variation RVB produite par les effets couleur précédents ; le niveau de gris après duotone supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou binaire peuvent éliminer les détails alpha créés précédemment. Construisez la chaîne en fonction de la séquence de traitement pixel souhaitée plutôt qu'en la traitant comme un ensemble d'indicateurs de mise en forme non ordonnés.

## **Inspecter les valeurs modifiables et effectives**

Une opération modifiable est l'objet stocké dans `ISlidesPicture.getImageTransform`. Selon l'effet, elle peut exposer directement des membres modifiables. Par exemple, [IBlur](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iblur/) expose les valeurs modifiables `radius` et `grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ialphamodulatefixed/) expose un `amount` modifiable, et [IAlphaBiLevel](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ialphabilevel/) expose un `threshold` modifiable. Les effets couleur tels que [IDuotone](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iduotone/) exposent des objets [IColorFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/icolorformat/) mutables.

Certaines interfaces d'opération, dont [IBrightnessContrast](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ihsl/), [ITint](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itint/), et [IAlphaReplace](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ialphareplace/), n'exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces réglages, supprimez l'opération et ajoutez un remplacement à la position requise.

Les données effectives renvoyées par `getEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le moteur de rendu, mais ce n'est pas une autre surface d'édition. L'exemple suivant parcourt la chaîne et inspecte les valeurs effectives lorsque l'API correspondante les fournit :

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

Les effets sans paramètre tels que le niveau de gris, le plafond alpha et l'inverse alpha disposent toujours d'un objet de données effectives, mais il n'y a aucune valeur scalaire à imprimer. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou effacer les transformations d'image**

Utilisez [IImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#removeAt-int-) pour supprimer une opération par son indice. Comme les indices se décalent après une suppression, recherchez d'abord la cible puis supprimez‑la après l'énumération. Utilisez [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/fr/java/com.aspose.slides/imagetransformoperationcollection/#clear--) pour supprimer toute la chaîne.

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

Supprimer ou effacer les transformations ne modifie que la mise en forme de l'image. Cela ne supprime pas, ne recompresse pas et ne modifie pas la ressource [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d'export**

Les transformations d'image proviennent de DrawingML, le PPTX est donc le format modifiable préféré pour les chaînes d'effets. Même avec le PPTX, toutes les opérations n'ont pas la même portabilité :

- Les opérations DrawingML standard telles que luminance, niveau de gris, duotone, teinte, HSL, flou et les opérations alpha courantes ont la meilleure chance de survivre à une ronde‑trip PPTX. Réouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/fr/java/com.aspose.slides/brightnesscontrast/) est une extension Office 2010 plutôt que l'opération de luminance standard de DrawingML. Elle peut être utilisée pour le rendu en mémoire, mais il n'est pas garanti qu'elle reste en tant que [IBrightnessContrast](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibrightnesscontrast/) modifiable après enregistrement et réouverture du PPTX. Privilégiez [addLuminanceEffect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iimagetransformoperationcollection/#addLuminanceEffect-float-float-) pour des réglages de luminosité et de contraste persistants.
- Le format binaire PPT précède le modèle complet d'effets DrawingML. Enregistré au format PPT, il peut omettre les opérations non prises en charge, réduire une chaîne à un sous‑ensemble supporté ou approximer l'apparence. N'utilisez pas le PPT comme format de vérification pour une chaîne modifiable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou d'autres sorties visuelles applique la chaîne prise en charge à l'apparence rendue. Ces sorties ne contiennent pas de `IImageTransformOperationCollection` modifiable ; les formats raster aplatissent le résultat en pixels, et les exportations document/vecteur stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Rendre une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, notamment lorsqu'on combine plusieurs opérations alpha ou de quantification de couleur. Pour une sortie critique, testez à la fois la ronde‑trip modifiable et le format d'export final avec la même version d'Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d'image modifient-ils les données d'image incorporées ?**

Non. Les opérations appartiennent au `ISlidesPicture` utilisé par le remplissage d'image. Les octets sous‑jacents de `IPPImage` restent inchangés.

**Deux cadres d'image qui réutilisent la même image partageront-ils leurs effets ?**

Non. La réutilisation d'un `IPPImage` évite la duplication des données d'image, mais chaque cadre d'image possède généralement son propre `ISlidesPicture` et sa collection de transformations d'image.

**Les effets couleur, flou et alpha peuvent-ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent éliminer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l'opération stockée dans la collection de transformations là où des membres modifiables existent ; sinon, supprimez‑la et ajoutez‑la de nouveau avec de nouveaux paramètres de création.

**Quel format dois‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez le PPTX et vérifiez le fichier en le rouvrant. Le PPT hérité ne peut pas représenter le modèle complet d'effets DrawingML, et les formats d'export rendus préservent l'apparence plutôt que les opérations de transformation modifiables.