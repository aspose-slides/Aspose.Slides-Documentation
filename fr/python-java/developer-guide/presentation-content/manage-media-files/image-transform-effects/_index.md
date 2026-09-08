---
title: Gestion des effets de transformation d’image dans les présentations avec Python
linktitle: Effets de transformation d’image
type: docs
weight: 11
url: /fr/python-java/image-transform-effects/
keywords:
  - transformation d’image
  - effet d’image
  - luminosité
  - contraste
  - niveaux de gris
  - bicolore
  - teinte
  - HSL
  - remplacement de couleur
  - flou
  - transparence
  - effet alpha
  - chaîne d’effets
  - PowerPoint
  - présentation
  - Python
  - Java
  - Aspose.Slides
description: "Appliquez, chaînez, inspectez, supprimez et vérifiez les effets de transformation d’image pour les cadres d’image avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d’image sous forme d’une collection ordonnée d’opérations de transformation d’image. Pour un cadre d’image, commencez par le [Picture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/) du cadre et accédez à [Picture.getImageTransform](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/#getImageTransform). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/) renvoyée vous permet d’ajouter, d’énumérer, d’inspecter, de supprimer et de réinitialiser les effets sans réécrire les octets d’image originaux.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d’effets ordonnées, les valeurs effectives, la suppression et la vérification d’un aller‑retour PPTX.

## **Comprendre la propriété des effets et la réutilisation d’images**

Une ressource d’image et l’image qui l’affiche sont deux objets différents :

- [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) stocke ou référence les données d’image source appartenant à la présentation.
- [Picture](https://reference.aspose.com/slides/fr/python-java/aspose.slides/picture/) appartient à un remplissage d’image et fait référence à une ressource d’image tout en stockant la collection de transformations d’image.
- [PictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pictureframe/) est la forme de diapositive qui possède le remplissage d’image concerné, la géométrie, les paramètres de recadrage et les autres formatages au niveau du cadre.

Ainsi, les opérations de transformation d’image ne modifient pas les octets de [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/). Lorsque le même `PPImage` est passé à [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addPictureFrame) plusieurs fois, chaque nouveau cadre d’image reçoit son propre `Picture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d’image intégrée.

Le même modèle `Picture.getImageTransform` est également utilisé par d’autres remplissages d’image, comme une forme ou l’arrière‑plan d’une diapositive. Les exemples ci‑dessous se concentrent sur les cadres d’image.

## **Utiliser des plages de paramètres et des unités valides**

Les méthodes présentées utilisent les plages sémantiques et les unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque n’interdit pas immédiatement chaque valeur hors plage ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l’enregistrement ou à l’ouverture du fichier par PowerPoint.

| Opération | Paramètres | Plage valide et unité |
|---|---|---|
| [addBrightnessContrastEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) | `brightness`, `contrast` | `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [addGrayScaleEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addGrayScaleEffect) | Aucun | Aucun paramètre numérique. L’alpha reste inchangé. |
| [addDuotoneEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addDuotoneEffect) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `java.awt.Color` utilisent `0` à `255`. |
| [addTintEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addTintEffect) | `hue`, `amount` | La teinte va de `0` inclus à `360` exclu, en degrés ; le montant va de `-100` à `100`, pourcentage. |
| [addHSLEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addHSLEffect) | `hue`, `saturation`, `luminance` | La teinte va de `0` inclus à `360` exclu, en degrés ; la saturation et la luminance vont de `-100` à `100`, pourcentage. |
| [addColorReplaceEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [addBlurEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) | `radius`, `grow` | Le rayon est non négatif et mesuré en points ; `grow` est un booléen qui contrôle si le contenu flou peut s’étendre au‑delà des limites d’origine. |
| [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect) | `amount` | `amount` pourcentage non négatif. Utilisez `0` à `100` pour un redimensionnement d’opacité ordinaire : `0` est complètement transparent et `100` préserve l’alpha existant. |
| [addAlphaReplaceEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) | `alpha` | `alpha` de `0` à `100`, pourcentage d’opacité. |
| [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) | `threshold` | `threshold` de `0` à `100`, seuil alpha en pourcentage. Les valeurs en dessous deviennent transparentes ; les valeurs égales ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, transparence et opacité sont complémentaires. Par exemple, 35 % de transparence correspond à un montant de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[ImageTransformOperationCollection.addBrightnessContrastEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addBrightnessContrastEffect) renvoie une opération [BrightnessContrast](https://reference.aspose.com/slides/fr/python-java/aspose.slides/brightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l’opération. [BrightnessContrast.getEffective](https://reference.aspose.com/slides/fr/python-java/aspose.slides/brightnesscontrast/#getEffective) renvoie des valeurs calculées en lecture seule qui peuvent être inspectées ou consignées.

L’exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis rend un aperçu sans modifier l’image intégrée :

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    brightness_contrast = image_transform.addBrightnessContrastEffect(15.0, 20.0)

    effective_values = brightness_contrast.getEffective()
    print("Brightness: ", effective_values.getBrightness(), "%", sep="")
    print("Contrast: ", effective_values.getContrast(), "%", sep="")

    preview = slide.getImage()
    try:
        preview.save("brightness-contrast-preview.png", ImageFormat.Png)
    finally:
        preview.dispose()
finally:
    presentation.dispose()
```

[BrightnessContrast](https://reference.aspose.com/slides/fr/python-java/aspose.slides/brightnesscontrast/) est une extension d’effet d’image Office 2010 et est moins portable que l’effet de luminance DrawingML standard. Lorsque la luminosité et le contraste doivent rester éditables après un aller‑retour PPTX, utilisez [ImageTransformOperationCollection.addLuminanceEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) et vérifiez le résultat après réouverture du fichier. La section sur les limitations de format explique cette distinction plus en détail.

## **Appliquer des transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d’image qui réutilisent une même ressource d’image. L’exemple suivant crée cinq cadres et applique respectivement le niveau de gris, le duo‑ton, la teinte, l’ajustement HSL et le remplacement de couleur.

[Duotone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/duotone/) contient deux paramètres de couleur éditables indépendamment : `color1` mappe les pixels sombres, tandis que `color2` mappe les pixels clairs. Cela en fait un exemple utile d’effet dont les paramètres sont plus complexes qu’une simple valeur scalaire.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    gray_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image)
    gray_frame.getPictureFormat().getPicture().getImageTransform().addGrayScaleEffect()

    duotone_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image)
    duotone = duotone_frame.getPictureFormat().getPicture().getImageTransform().addDuotoneEffect()
    duotone.getColor1().setColor(Color(0, 0, 128))
    duotone.getColor2().setColor(Color(255, 215, 0))

    tint_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image)
    tint_frame.getPictureFormat().getPicture().getImageTransform().addTintEffect(210.0, 35.0)

    hsl_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image)
    hsl_frame.getPictureFormat().getPicture().getImageTransform().addHSLEffect(30.0, 20.0, -10.0)

    replacement_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.getPictureFormat().getPicture().getImageTransform().addColorReplaceEffect()
    color_replacement.getColor().setColor(Color(100, 149, 237))

    presentation.save("color-transformations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

[addColorReplaceEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addColorReplaceEffect) remplace la couleur de chaque pixel par une couleur fixe tout en conservant l’alpha. Il diffère de [addColorChangeEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addColorChangeEffect), qui mappe une couleur source vers une autre et expose les deux formats de couleur source et cible.

## **Ajouter le flou, la transparence et les effets alpha**

[addBlurEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addBlurEffect) affecte tous les canaux de couleur, y compris l’alpha. Réglez `grow` sur `True` lorsque le bord flou peut dépasser les limites de l’image d’origine.

Pour une transparence uniforme, utilisez [addAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaModulateFixedEffect). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents conservent leurs différences proportionnelles. [addAlphaReplaceEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaReplaceEffect) attribue à la place une seule valeur alpha à tous les pixels. [addAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaBiLevelEffect) convertit l’alpha en deux niveaux basés sur un seuil.

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)

    blurred_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image)
    blur = blurred_frame.getPictureFormat().getPicture().getImageTransform().addBlurEffect(4.5, True)
    blur.setRadius(5)

    transparent_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.getPictureFormat().getPicture().getImageTransform().addAlphaModulateFixedEffect(65.0)
    alpha_modulate.setAmount(60.0)

    uniform_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image)
    uniform_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaReplaceEffect(55.0)

    binary_alpha_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaBiLevelEffect(50.0)
    alpha_bi_level.setThreshold(45.0)
    binary_alpha_frame.getPictureFormat().getPicture().getImageTransform().addAlphaInverseEffect()

    presentation.save("blur-and-alpha-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

D’autres opérations alpha sans paramètres incluent [addAlphaCeilingEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaCeilingEffect), qui rend chaque alpha non nul totalement opaque ; [addAlphaFloorEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaFloorEffect), qui rend chaque alpha inférieur à 100 % totalement transparent ; et [addAlphaInverseEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addAlphaInverseEffect), qui change l’alpha en `100% - alpha`.

## **Construire une chaîne d’effets ordonnée**

Chaque méthode `add...Effect` ajoute une nouvelle opération à la fin de la collection. Le moteur de rendu utilise la collection comme pipeline ordonné : la sortie de l’opération 0 devient l’entrée de l’opération 1, et ainsi de suite. Par conséquent, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d’une teinte supprime d’abord les informations chromatiques puis recolore le résultat de luminance. Une teinte suivie de niveau de gris supprime à nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations précédentes, tandis que la modulation alpha préserve leurs différences relatives.

L’exemple suivant construit une chaîne de quatre opérations, l’enregistre au format PPTX, rouvre la présentation, vérifie à la fois les types d’opération et leur ordre, puis rend le résultat rouvert :

```python
import jpype
import asposeslides
from pathlib import Path

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaModulateFixed, Blur, GrayScale, ImageFormat, PictureFrame, Presentation, SaveFormat, ShapeType, Tint

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    image_data = Path("photo.png").read_bytes()
    image_bytes = jpype.JArray(jpype.JByte)(image_data)
    image = presentation.getImages().addImage(image_bytes)
    picture_frame = slide.getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image)

    image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
    image_transform.addGrayScaleEffect()
    image_transform.addTintEffect(220.0, 25.0)
    image_transform.addBlurEffect(2.5, False)
    image_transform.addAlphaModulateFixedEffect(80.0)

    presentation.save("image-transform-chain.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

reopened_presentation = Presentation("image-transform-chain.pptx")
try:
    reopened_shape = reopened_presentation.getSlides().get_Item(0).getShapes().get_Item(0)

    if isinstance(reopened_shape, PictureFrame):
        reopened_transform = reopened_shape.getPictureFormat().getPicture().getImageTransform()
        expected_types = (GrayScale, Tint, Blur, AlphaModulateFixed)
        order_is_preserved = reopened_transform.size() == len(expected_types)
        for index, expected_type in enumerate(expected_types):
            order_is_preserved = order_is_preserved and isinstance(reopened_transform.get_Item(index), expected_type)
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        rendered_slide = reopened_presentation.getSlides().get_Item(0).getImage()
        try:
            rendered_slide.save("reopened-effect-chain.png", ImageFormat.Png)
        finally:
            rendered_slide.dispose()
    else:
        print("The reopened shape is not a picture frame.")
finally:
    reopened_presentation.dispose()
```

La collection n’impose pas de matrice de compatibilité qui restreint les opérations de couleur, alpha et flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement de couleur fixe supprime la variation RVB produite par les effets de couleur antérieurs ; le niveau de gris après duo‑ton supprime les deux couleurs sélectionnées ; et les opérations de plafond, plancher, remplacement ou bi‑niveau alpha peuvent éliminer les détails alpha créés précédemment. Construisez la chaîne selon la séquence de traitement pixel souhaitée plutôt que de traiter ses éléments comme des indicateurs de formatage non ordonnés.

## **Inspecter les valeurs modifiables et effectives**

Une opération modifiable est l’objet stocké dans `Picture.getImageTransform`. Selon l’effet, elle peut exposer directement des membres modifiables. Par exemple, [Blur](https://reference.aspose.com/slides/fr/python-java/aspose.slides/blur/) expose les valeurs modifiables `radius` et `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/fr/python-java/aspose.slides/alphamodulatefixed/) expose un `amount` modifiable, et [AlphaBiLevel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/alphabilevel/) expose un `threshold` modifiable. Les effets de couleur tels que [Duotone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/duotone/) exposent des objets [ColorFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/colorformat/) mutables.

Certaines classes d’opération, y compris [BrightnessContrast](https://reference.aspose.com/slides/fr/python-java/aspose.slides/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/fr/python-java/aspose.slides/hsl/), [Tint](https://reference.aspose.com/slides/fr/python-java/aspose.slides/tint/), et [AlphaReplace](https://reference.aspose.com/slides/fr/python-java/aspose.slides/alphareplace/), n’exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces paramètres, supprimez l’opération et ajoutez un remplacement à la position requise.

Les données effectives renvoyées par `getEffective` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le moteur de rendu, mais ce n’est pas une autre surface d’édition. L’exemple suivant énumère la chaîne et inspecte les valeurs effectives où l’API correspondante les fournit :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AlphaBiLevel, AlphaModulateFixed, AlphaReplace, Blur, BrightnessContrast, ColorReplace, Duotone, HSL, Luminance, PictureFrame, Presentation, Tint

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()

        for index in range(image_transform.size()):
            operation = image_transform.get_Item(index)
            print(index, ": ", operation.getClass().getSimpleName(), sep="")

            if isinstance(operation, BrightnessContrast):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Luminance):
                data = operation.getEffective()
                print("  Brightness: ", data.getBrightness(), sep="")
                print("  Contrast: ", data.getContrast(), sep="")
            elif isinstance(operation, Duotone):
                data = operation.getEffective()
                print("  Dark color: ", data.getColor1(), sep="")
                print("  Light color: ", data.getColor2(), sep="")
            elif isinstance(operation, ColorReplace):
                data = operation.getEffective()
                print("  Replacement color: ", data.getColor(), sep="")
            elif isinstance(operation, HSL):
                data = operation.getEffective()
                print("  HSL: ", data.getHue(), ", ", data.getSaturation(), ", ", data.getLuminance(), sep="")
            elif isinstance(operation, Tint):
                data = operation.getEffective()
                print("  Tint: ", data.getHue(), ", ", data.getAmount(), sep="")
            elif isinstance(operation, Blur):
                data = operation.getEffective()
                print("  Blur radius: ", data.getRadius(), " pt", sep="")
            elif isinstance(operation, AlphaModulateFixed):
                data = operation.getEffective()
                print("  Alpha amount: ", data.getAmount(), "%", sep="")
            elif isinstance(operation, AlphaReplace):
                data = operation.getEffective()
                print("  Replacement alpha: ", data.getAlpha(), "%", sep="")
            elif isinstance(operation, AlphaBiLevel):
                data = operation.getEffective()
                print("  Alpha threshold: ", data.getThreshold(), "%", sep="")
finally:
    presentation.dispose()
```

Les effets sans paramètre tels que le niveau de gris, le plafond alpha et l’inverse alpha possèdent toujours un objet de données effectives, mais il n’y a aucune valeur scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou réinitialiser les transformations d’image**

Utilisez [ImageTransformOperationCollection.removeAt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#removeAt) pour supprimer une opération par indice. Comme les indices se décalent après une suppression, recherchez d’abord la cible puis supprimez‑la après l’énumération. Utilisez [ImageTransformOperationCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#clear) pour supprimer l’ensemble de la chaîne.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Blur, PictureFrame, Presentation, SaveFormat

presentation = Presentation("image-transform-chain.pptx")
try:
    picture_frame = None

    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.getPictureFormat().getPicture().getImageTransform()
        blur_index = -1

        for index in range(image_transform.size()):
            if isinstance(image_transform.get_Item(index), Blur):
                blur_index = index
                break

        if blur_index >= 0:
            image_transform.removeAt(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: ", image_transform.size(), sep="")
        presentation.save("image-transforms-cleared.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Supprimer ou réinitialiser les transformations ne modifie que le formatage de l’image. Cela ne supprime pas, ne recomprime pas et ne modifie pas la ressource [PPImage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/ppimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d’exportation**

Les transformations d’image proviennent de DrawingML, le PPTX est donc le format éditable préféré pour les chaînes d’effets. Même avec le PPTX, toutes les opérations n’ont pas une portabilité identique :

- Les opérations DrawingML standard telles que la luminance, le niveau de gris, le duo‑ton, la teinte, le HSL, le flou et les opérations alpha courantes ont les meilleures chances de survivre à un aller‑retour PPTX. Rouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/fr/python-java/aspose.slides/brightnesscontrast/) est une extension Office 2010 plutôt qu’une opération de luminance DrawingML standard. Elle peut être utilisée pour le rendu en mémoire, mais il n’est pas garanti qu’elle reste un [BrightnessContrast](https://reference.aspose.com/slides/fr/python-java/aspose.slides/brightnesscontrast/) éditable après l’enregistrement et la réouverture du PPTX. Privilégiez [addLuminanceEffect](https://reference.aspose.com/slides/fr/python-java/aspose.slides/imagetransformoperationcollection/#addLuminanceEffect) pour des ajustements de luminosité et de contraste persistants.
- Le format binaire PPT précède le modèle complet d’effets DrawingML. Enregistrer en PPT peut omettre les opérations non prises en charge, réduire une chaîne à un sous‑ensemble supporté ou approximer l’apparence. N’utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou tout autre format visuel applique la chaîne supportée à l’apparence rendue. Ces sorties ne contiennent pas de `ImageTransformOperationCollection` éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document/vector stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Le rendu d’une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents lecteurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification de couleur sont combinées. Pour des résultats critiques, testez à la fois l’aller‑retour éditable et le format d’exportation final avec la même version d’Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d’image modifient-ils les données de l’image intégrée ?**

Non. Les opérations appartiennent au `Picture` utilisé par le remplissage d’image. Les octets sous‑jacent de `PPImage` restent inchangés.

**Deux cadres d’image qui réutilisent la même image partageront‑ils leurs effets ?**

Non. Réutiliser un `PPImage` évite la duplication des données d’image, mais chaque cadre d’image possède normalement un `Picture` séparé et une collection de transformations d’image distincte.

**Les effets de couleur, de flou et alpha peuvent‑ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent éliminer les détails couleur ou alpha créés auparavant.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l’opération stockée dans la collection de transformations lorsque des membres modifiables existent ; sinon, supprimez‑la et ajoutez un remplacement avec de nouveaux paramètres de création.

**Quel format dois‑je utiliser pour conserver une chaîne de transformations ?**

Utilisez le PPTX et vérifiez le fichier en le rouvrant. Le PPT legacy ne peut pas représenter le modèle complet d’effets DrawingML, et les formats d’exportation rendus conservent l’apparence plutôt que les opérations de transformation éditables.