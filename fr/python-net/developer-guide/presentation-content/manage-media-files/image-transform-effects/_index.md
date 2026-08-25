---
title: Gérer les effets de transformation d'image dans les présentations avec Python
linktitle: Effets de transformation d'image
type: docs
weight: 11
url: /fr/python-net/image-transform-effects/
keywords:
- transformation d'image
- effet d'image
- luminosité
- contraste
- niveau de gris
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
- Python
- Aspose.Slides
description: "Appliquer, enchaîner, inspecter, supprimer et vérifier les effets de transformation d'image pour les cadres d'image avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d'image sous forme d'une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, commencez avec le [Picture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picture/) du cadre et accédez à sa propriété [image_transform](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picture/image_transform/). La [ImageTransformOperationCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/) renvoyée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et de vider les effets sans réécrire les octets originaux de l'image.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification de la boucle de conversion PPTX.

## **Comprendre la possession des effets et la réutilisation d'images**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) stocke ou référence les données source de l'image appartenant à la présentation.
- [Picture](https://reference.aspose.com/slides/fr/python-net/aspose.slides/picture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformations d'image.
- [PictureFrame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pictureframe/) est la forme de diapositive qui possède le remplissage d'image concerné, la géométrie, les paramètres de recadrage et d'autres paramètres de niveau de cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets du [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/). Lorsque le même `PPImage` est passé à [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/fr/python-net/aspose.slides/shapecollection/add_picture_frame/) plusieurs fois, chaque nouveau cadre d'image reçoit son propre `Picture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveau de gris, même si tous réutilisent la même ressource d'image incorporée.

Le même modèle `Picture.image_transform` est également utilisé par d'autres remplissages d'image, tels qu'une forme ou l'arrière-plan d'une diapositive. Les exemples ci‑dessous portent sur les cadres d'image.

## **Utiliser des plages de paramètres et des unités valides**

Les méthodes présentées utilisent les plages sémantiques et les unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors limites ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l'enregistrement ou lorsqu PowerPoint ouvre le fichier.

| Opération | Paramètres | Plage valide et unité |
|---|---|---|
| [add_brightness_contrast_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) | `brightness`, `contrast` | de `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [add_gray_scale_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_gray_scale_effect/) | Aucun | Aucun paramètre numérique. L'alpha reste inchangé. |
| [add_duotone_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_duotone_effect/) | `color1`, `color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha utilisent `0` à `255`. |
| [add_tint_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_tint_effect/) | `hue`, `amount` | `hue` de `0` inclus à `360` exclus, en degrés ; `amount` de `-100` à `100`, pourcentage. |
| [add_hsl_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_hsl_effect/) | `hue`, `saturation`, `luminance` | `hue` de `0` inclus à `360` exclus, en degrés ; `saturation` et `luminance` de `-100` à `100`, pourcentage. |
| [add_color_replace_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) | `color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [add_blur_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) | `radius`, `grow` | `radius` est non négatif et mesuré en points ; `grow` est un booléen qui contrôle si le contenu flou peut dépasser les limites d'origine. |
| [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un dimensionnement d'opacité ordinaire : `0` est complètement transparent et `100` préserve l'alpha existant. |
| [add_alpha_replace_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) | `alpha` | De `0` à `100`, pourcentage d'opacité. |
| [add_alpha_bi_level_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) | `threshold` | De `0` à `100`, pourcentage de seuil alpha. Les valeurs inférieures deviennent transparentes ; les valeurs égales ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, transparence et opacité sont complémentaires. Par exemple, 35 % de transparence correspond à un montant de modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[ImageTransformOperationCollection.add_brightness_contrast_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_brightness_contrast_effect/) renvoie une opération [BrightnessContrast](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/brightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l'opération. [BrightnessContrast.get_effective](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/brightnesscontrast/get_effective/) renvoie des valeurs en lecture seule calculées qui peuvent être inspectées ou journalisées.

L'exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis génère un aperçu sans modifier l'image incorporée :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    brightness_contrast = image_transform.add_brightness_contrast_effect(15, 20)

    effective_values = brightness_contrast.get_effective()
    print("Brightness: " + str(effective_values.brightness) + "%")
    print("Contrast: " + str(effective_values.contrast) + "%")

    with slide.get_image() as preview:
        preview.save("brightness-contrast-preview.png")
```

[BrightnessContrast](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/brightnesscontrast/) est une extension d'effet d'image Office 2010 et est moins portable que l'effet de luminance standard DrawingML. Lorsque la luminosité et le contraste doivent rester éditables après une boucle de conversion PPTX, utilisez [ImageTransformOperationCollection.add_luminance_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) et vérifiez le résultat après réouverture du fichier. La section des limitations de format explique cette distinction plus en détail.

## **Appliquer les transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d'image qui réutilisent une même ressource d'image. L'exemple suivant crée cinq cadres et applique respectivement le niveau de gris, le duo‑tone, la teinte, l'ajustement HSL et le remplacement de couleur.

[Duotone](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/duotone/) possède deux paramètres de couleur éditables indépendamment : `color1` mappe les pixels sombres, tandis que `color2` mappe les pixels clairs. Cela en fait un exemple utile d'effet dont les paramètres sont plus complexes qu'une simple valeur scalaire.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    gray_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 180, 120, image)
    gray_frame.picture_format.picture.image_transform.add_gray_scale_effect()

    duotone_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 220, 20, 180, 120, image)
    duotone = duotone_frame.picture_format.picture.image_transform.add_duotone_effect()
    duotone.color1.color = draw.Color.navy
    duotone.color2.color = draw.Color.gold

    tint_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 420, 20, 180, 120, image)
    tint_frame.picture_format.picture.image_transform.add_tint_effect(210, 35)

    hsl_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 120, 170, 180, 120, image)
    hsl_frame.picture_format.picture.image_transform.add_hsl_effect(30, 20, -10)

    replacement_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 320, 170, 180, 120, image)
    color_replacement = replacement_frame.picture_format.picture.image_transform.add_color_replace_effect()
    color_replacement.color.color = draw.Color.cornflower_blue

    presentation.save("color-transformations.pptx", slides.export.SaveFormat.PPTX)
```

[add_color_replace_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_replace_effect/) remplace la couleur de chaque pixel par une couleur fixe tout en préservant l'alpha. Il diffère de [add_color_change_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_color_change_effect/), qui mappe une couleur source vers une autre et expose les formats de couleur source et cible.

## **Ajouter le flou, la transparence et les effets alpha**

[add_blur_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_blur_effect/) affecte tous les canaux de couleur, y compris l'alpha. Définissez `grow` sur `True` lorsque le bord flou peut dépasser les limites d'origine de l'image.

Pour une transparence uniforme, utilisez [add_alpha_modulate_fixed_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_modulate_fixed_effect/). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents restent proportionnellement différents. [add_alpha_replace_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_replace_effect/) attribue plutôt une même valeur alpha à tous les pixels. [add_alpha_bi_level_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_bi_level_effect/) convertit l'alpha en deux niveaux selon un seuil.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    blurred_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 20, 200, 140, image)
    blur = blurred_frame.picture_format.picture.image_transform.add_blur_effect(4.5, True)
    blur.radius = 5

    transparent_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 20, 200, 140, image)
    alpha_modulate = transparent_frame.picture_format.picture.image_transform.add_alpha_modulate_fixed_effect(65)
    alpha_modulate.amount = 60

    uniform_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 20, 180, 200, 140, image)
    uniform_alpha_frame.picture_format.picture.image_transform.add_alpha_replace_effect(55)

    binary_alpha_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 240, 180, 200, 140, image)
    alpha_bi_level = binary_alpha_frame.picture_format.picture.image_transform.add_alpha_bi_level_effect(50)
    alpha_bi_level.threshold = 45
    binary_alpha_frame.picture_format.picture.image_transform.add_alpha_inverse_effect()

    presentation.save("blur-and-alpha-effects.pptx", slides.export.SaveFormat.PPTX)
```

D'autres opérations alpha sans paramètres incluent [add_alpha_ceiling_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_ceiling_effect/), qui rend tout alpha non nul entièrement opaque ; [add_alpha_floor_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_floor_effect/), qui rend tout alpha inférieur à 100 % complètement transparent ; et [add_alpha_inverse_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_alpha_inverse_effect/), qui transforme l'alpha en `100% - alpha`.

## **Construire une chaîne d'effets ordonnée**

Chaque méthode `add_..._effect` ajoute une nouvelle opération à la fin de la collection. Le moteur de rendu utilise la collection comme un pipeline ordonné : la sortie de l'opération 0 devient l'entrée de l'opération 1, etc. Par conséquent, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d'une teinte supprime d'abord l'information chromatique puis recolore le résultat de luminance. Une teinte suivie du niveau de gris supprime la teinte à nouveau. De même, le remplacement alpha peut écraser les valeurs alpha calculées par des opérations antérieures, tandis que la modulation alpha préserve leurs différences relatives.

L'exemple suivant construit une chaîne de quatre opérations, l'enregistre au format PPTX, rouvre la présentation, vérifie les types d'opérations ainsi que leur ordre, et rend le résultat rouvert :

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    with slides.Images.from_file("photo.png") as source_image:
        image = presentation.images.add_image(source_image)

    picture_frame = slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 400, 260, image)
    image_transform = picture_frame.picture_format.picture.image_transform
    image_transform.add_gray_scale_effect()
    image_transform.add_tint_effect(220, 25)
    image_transform.add_blur_effect(2.5, False)
    image_transform.add_alpha_modulate_fixed_effect(80)

    presentation.save("image-transform-chain.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("image-transform-chain.pptx") as reopened_presentation:
    reopened_shape = reopened_presentation.slides[0].shapes[0]

    if isinstance(reopened_shape, slides.PictureFrame):
        reopened_transform = reopened_shape.picture_format.picture.image_transform
        order_is_preserved = (
            len(reopened_transform) == 4 and
            isinstance(reopened_transform[0], slides.effects.GrayScale) and
            isinstance(reopened_transform[1], slides.effects.Tint) and
            isinstance(reopened_transform[2], slides.effects.Blur) and
            isinstance(reopened_transform[3], slides.effects.AlphaModulateFixed)
        )
        print("The effect chain was preserved." if order_is_preserved else "The effect chain changed during the round trip.")

        with reopened_presentation.slides[0].get_image() as rendered_slide:
            rendered_slide.save("reopened-effect-chain.png")
    else:
        print("The reopened shape is not a picture frame.")
```

La collection n'impose pas de matrice de compatibilité qui restreint les opérations de couleur, alpha et flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement de couleur fixe supprime la variation RVB produite par des effets de couleur antérieurs ; le niveau de gris après duo‑tone supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent éliminer les détails alpha créés précédemment. Construisez la chaîne selon la séquence de traitement des pixels souhaitée plutôt que de considérer ses éléments comme des drapeaux de formatage non ordonnés.

## **Inspecter les valeurs éditables et effectives**

Une opération éditable est l'objet stocké dans `Picture.image_transform`. Selon l'effet, il peut exposer des membres modifiables directement. Par exemple, [Blur](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/blur/) expose les propriétés modifiables `radius` et `grow`, [AlphaModulateFixed](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/alphamodulatefixed/) expose la propriété modifiable `amount`, et [AlphaBiLevel](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/alphabilevel/) expose la propriété modifiable `threshold`. Les effets de couleur tels que [Duotone](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/duotone/) exposent des objets [ColorFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/colorformat/) mutables.

Certaines opérations, dont [BrightnessContrast](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/brightnesscontrast/), [HSL](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/hsl/), [Tint](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/tint/) et [AlphaReplace](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/alphareplace/), n'exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces paramètres, supprimez l'opération et ajoutez un remplacement à la position requise.

Les données effectives retournées par `get_effective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le moteur de rendu, mais ne constituent pas une autre surface d'édition. L'exemple suivant énumère la chaîne et inspecte les valeurs effectives là où l'API correspondante les fournit :

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform

        for index, operation in enumerate(image_transform):
            print(str(index) + ": " + type(operation).__name__)

            if isinstance(operation, slides.effects.BrightnessContrast):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Luminance):
                effect_data = operation.get_effective()
                print("  Brightness: " + str(effect_data.brightness))
                print("  Contrast: " + str(effect_data.contrast))
            elif isinstance(operation, slides.effects.Duotone):
                effect_data = operation.get_effective()
                print("  Dark color: " + str(effect_data.color1))
                print("  Light color: " + str(effect_data.color2))
            elif isinstance(operation, slides.effects.ColorReplace):
                effect_data = operation.get_effective()
                print("  Replacement color: " + str(effect_data.color))
            elif isinstance(operation, slides.effects.HSL):
                effect_data = operation.get_effective()
                print("  HSL: " + str(effect_data.hue) + ", " + str(effect_data.saturation) + ", " + str(effect_data.luminance))
            elif isinstance(operation, slides.effects.Tint):
                effect_data = operation.get_effective()
                print("  Tint: " + str(effect_data.hue) + ", " + str(effect_data.amount))
            elif isinstance(operation, slides.effects.Blur):
                effect_data = operation.get_effective()
                print("  Blur radius: " + str(effect_data.radius) + " pt")
            elif isinstance(operation, slides.effects.AlphaModulateFixed):
                effect_data = operation.get_effective()
                print("  Alpha amount: " + str(effect_data.amount) + "%")
            elif isinstance(operation, slides.effects.AlphaReplace):
                effect_data = operation.get_effective()
                print("  Replacement alpha: " + str(effect_data.alpha) + "%")
            elif isinstance(operation, slides.effects.AlphaBiLevel):
                effect_data = operation.get_effective()
                print("  Alpha threshold: " + str(effect_data.threshold) + "%")
```

Les effets sans paramètres comme le niveau de gris, le plafond alpha et l'inverse alpha possèdent toujours un objet de données effectives, mais il n'existe aucune valeur scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou vider les transformations d'image**

Utilisez [ImageTransformOperationCollection.remove_at](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/remove_at/) pour supprimer une opération par son indice. Comme les indices se décalent après une suppression, recherchez d'abord la cible puis supprimez‑la après l'énumération. Utilisez `clear()` pour supprimer toute la chaîne.

```python
import aspose.slides as slides

with slides.Presentation("image-transform-chain.pptx") as presentation:
    picture_frame = None

    for shape in presentation.slides[0].shapes:
        if isinstance(shape, slides.PictureFrame):
            picture_frame = shape
            break

    if picture_frame is not None:
        image_transform = picture_frame.picture_format.picture.image_transform
        blur_index = None

        for index, operation in enumerate(image_transform):
            if isinstance(operation, slides.effects.Blur):
                blur_index = index
                break

        if blur_index is not None:
            image_transform.remove_at(blur_index)
            print("The blur operation was removed.")

        image_transform.clear()
        print("Remaining operations: " + str(len(image_transform)))
        presentation.save("image-transforms-cleared.pptx", slides.export.SaveFormat.PPTX)
```

Supprimer ou vider les transformations ne change que le formatage de l'image. Cela ne supprime pas, ne recompresse pas et ne modifie pas la ressource [PPImage](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ppimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d'exportation**

Les transformations d'image proviennent de DrawingML, de sorte que le PPTX est le format éditable privilégié pour les chaînes d'effets. Même avec le PPTX, toutes les opérations ne possèdent pas la même portabilité :

- Les opérations DrawingML standard telles que luminance, niveau de gris, duo‑tone, teinte, HSL, flou et les opérations alpha courantes ont la meilleure chance de survivre à une boucle de conversion PPTX. Réouvrez toujours le fichier généré et inspectez la collection lorsque la préservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/brightnesscontrast/) est une extension Office 2010 plutôt que l'opération de luminance standard DrawingML. Elle peut être utilisée pour le rendu en mémoire, mais il n'est pas garanti qu'elle reste une opération `BrightnessContrast` éditable après enregistrement et réouverture du PPTX. Privilégiez [add_luminance_effect](https://reference.aspose.com/slides/fr/python-net/aspose.slides.effects/imagetransformoperationcollection/add_luminance_effect/) pour des ajustements de luminosité et contraste persistants.
- Le format binaire PPT précède le modèle complet d'effets DrawingML. L'enregistrement au format PPT peut omettre les opérations non prises en charge, réduire une chaîne à un sous‑ensemble pris en charge ou approximer l'apparence. N'utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou d'autres sorties visuelles applique la chaîne prise en charge à l'apparence rendue. Ces sorties ne contiennent pas de `ImageTransformOperationCollection` éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document ou vecteur stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Le rendu d'une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification de couleur sont combinées. Pour une sortie critique, testez à la fois la boucle éditable et le format d'export final avec la même version d'Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d'image modifient-ils les données d'image incorporées ?**

Non. Les opérations appartiennent au `Picture` utilisé par le remplissage d'image. Les octets sous‑jacents du `PPImage` restent inchangés.

**Deux cadres d'image qui réutilisent la même image partagent‑ils leurs effets ?**

Non. La réutilisation d'un `PPImage` évite les données d'image dupliquées, mais chaque cadre d'image possède normalement un `Picture` distinct et une collection de transformations d'image distincte.

**Les effets de couleur, de flou et alpha peuvent‑ils être combinés ?**

Oui. La collection les accepte dans une seule chaîne ordonnée. Considérez l'impact de chaque opération sur la sortie de la précédente, car les opérations de remplacement et de seuil peuvent éliminer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l'opération stockée dans la collection de transformations là où des membres modifiables existent ; sinon, supprimez‑la et ajoutez un remplacement avec de nouveaux paramètres de création.

**Quel format dois‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez PPTX et vérifiez le fichier en le rouvrant. Le PPT hérité ne peut pas représenter le modèle complet d'effets DrawingML, et les formats d'exportation rendus conservent l'apparence plutôt que les opérations de transformation éditables.