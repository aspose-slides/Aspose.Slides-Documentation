---
title: Gérer les effets de transformation d'image dans les présentations avec .NET
linktitle: Effets de transformation d'image
type: docs
weight: 11
url: /fr/net/image-transform-effects/
keywords:
- transformation d'image
- effet d'image
- luminosité
- contraste
- niveaux de gris
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
- .NET
- C#
- Aspose.Slides
description: "Appliquer, enchaîner, inspecter, supprimer et vérifier les effets de transformation d'image pour les cadres d'image avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d’image comme une collection ordonnée d’opérations de transformation d’image. Pour un cadre d’image, commencez avec le [ISlidesPicture](https://reference.aspose.com/slides/fr/net/aspose.slides/islidespicture/) du cadre et accédez à [ISlidesPicture.ImageTransform](https://reference.aspose.com/slides/fr/net/aspose.slides/islidespicture/imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/) retournée vous permet d’ajouter, d’énumérer, d’inspecter, de supprimer et de nettoyer les effets sans réécrire les octets de l’image d’origine.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d’effets ordonnées, les valeurs effectives, la suppression et la vérification de la ronde‑trip PPTX.

## **Comprendre la propriété des effets et la réutilisation d’image**

Une ressource d’image et l’image qui l’affiche sont des objets différents :

- [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) stocke ou référence les données d’image source appartenant à la présentation.
- [ISlidesPicture](https://reference.aspose.com/slides/fr/net/aspose.slides/islidespicture/) appartient à un remplissage d’image et se réfère à une ressource d’image tout en stockant la collection de transformations d’image.
- [IPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ipictureframe/) est la forme de diapositive qui possède le remplissage d’image concerné, la géométrie, les paramètres de recadrage et d’autres formatages au niveau du cadre.

Par conséquent, les opérations de transformation d’image ne modifient pas les octets du [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/). Lorsque le même `IPPImage` est passé à [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addpictureframe/) plusieurs fois, chaque nouveau cadre d’image reçoit son propre `ISlidesPicture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d’image incorporée.

Le même modèle `ISlidesPicture.ImageTransform` est également utilisé par d’autres remplissages d’image, tels qu’une forme ou un arrière‑plan de diapositive. Les exemples ci‑dessous se concentrent sur les cadres d’image.

## **Utiliser des plages de paramètres valides et les unités**

Les méthodes présentées utilisent les plages sémantiques et unités suivantes. Conservez les valeurs dans ces plages même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors plage ; le format de présentation cible peut normaliser, ignorer ou rejeter les données non valides lors de l’enregistrement ou à l’ouverture du fichier par PowerPoint.

| Opération | Paramètres | Plage valide et unité |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` à `100`, pourcent ; `0` laisse le composant inchangé. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Aucun | Aucun paramètre numérique. L’alpha reste inchangé. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `System.Drawing.Color` utilisent `0` à `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | La teinte est comprise entre `0` inclus et `360` exclus, en degrés ; `amount` est de `-100` à `100`, pourcent. |
| [AddHSLEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | La teinte est comprise entre `0` inclus et `360` exclus, en degrés ; saturation et luminance sont de `-100` à `100`, pourcent. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [AddBlurEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Le rayon est non négatif et mesuré en points ; `grow` est un booléen qui indique si le contenu flou peut dépasser les limites d’origine. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Pourcent non négatif. Utilisez `0` à `100` pour un réglage d’opacité ordinaire : `0` est complètement transparent et `100` conserve l’alpha existant. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` à `100`, pourcent d’opacité. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` à `100`, pourcent de seuil alpha. Les valeurs en dessous deviennent transparentes ; les valeurs égales ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, transparence et opacité sont complémentaires. Par exemple, 35 % de transparence correspond à une modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[IImageTransformOperationCollection.AddBrightnessContrastEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) renvoie une opération [IBrightnessContrast](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ibrightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l’opération. [IBrightnessContrast.GetEffective](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/brightnesscontrast/geteffective/) renvoie des valeurs en lecture seule calculées qui peuvent être inspectées ou consignées.

L’exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis génère un aperçu sans modifier l’image incorporée :

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
IBrightnessContrast brightnessContrast = imageTransform.AddBrightnessContrastEffect(15f, 20f);

var effectiveValues = brightnessContrast.GetEffective();
Console.WriteLine("Brightness: " + effectiveValues.Brightness + "%");
Console.WriteLine("Contrast: " + effectiveValues.Contrast + "%");

using var preview = slide.GetImage();
preview.Save("brightness-contrast-preview.png", ImageFormat.Png);
```

[BrightnessContrast](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/brightnesscontrast/) est une extension d’effet d’image Office 2010 et est moins portable que l’effet de luminance standard DrawingML. Lorsque la luminosité et le contraste doivent rester éditables après un aller‑retour PPTX, utilisez [IImageTransformOperationCollection.AddLuminanceEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) et vérifiez le résultat après réouverture du fichier. La section des limites de format explique cette distinction plus en détail.

## **Appliquer des transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d’image qui réutilisent une même ressource d’image. L’exemple suivant crée cinq cadres et applique le niveau de gris, le duo‑tone, la teinte, le réglage HSL et le remplacement de couleur.

[IDuotone](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iduotone/) contient deux paramètres de couleur éditables indépendamment : `Color1` mappe les pixels sombres, tandis que `Color2` mappe les pixels clairs. Cela en fait un exemple utile d’effet dont les réglages sont plus complexes qu’une simple valeur scalaire.

```csharp
using System.Drawing;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var grayFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 180, 120, image);
grayFrame.PictureFormat.Picture.ImageTransform.AddGrayScaleEffect();

var duotoneFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 220, 20, 180, 120, image);
var duotone = duotoneFrame.PictureFormat.Picture.ImageTransform.AddDuotoneEffect();
duotone.Color1.Color = Color.Navy;
duotone.Color2.Color = Color.Gold;

var tintFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 420, 20, 180, 120, image);
tintFrame.PictureFormat.Picture.ImageTransform.AddTintEffect(210f, 35f);

var hslFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 120, 170, 180, 120, image);
hslFrame.PictureFormat.Picture.ImageTransform.AddHSLEffect(30f, 20f, -10f);

var replacementFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 320, 170, 180, 120, image);
var colorReplacement = replacementFrame.PictureFormat.Picture.ImageTransform.AddColorReplaceEffect();
colorReplacement.Color.Color = Color.CornflowerBlue;

presentation.Save("color-transformations.pptx", SaveFormat.Pptx);
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) remplace la couleur de chaque pixel par une couleur fixe tout en conservant l’alpha. C’est différent de [AddColorChangeEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), qui mappe une couleur source vers une autre et expose les formats couleur source et cible.

## **Ajouter le flou, la transparence et les effets alpha**

[AddBlurEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) affecte tous les canaux de couleur, y compris l’alpha. Définissez `grow` sur `true` lorsque le bord flou peut dépasser les limites de l’image d’origine.

Pour une transparence uniforme, utilisez [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents restent proportionnellement différents. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) attribue plutôt une même valeur alpha à tous les pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) convertit l’alpha en deux niveaux selon un seuil.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);

var blurredFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 140, image);
var blur = blurredFrame.PictureFormat.Picture.ImageTransform.AddBlurEffect(4.5, true);
blur.Radius = 5;

var transparentFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 20, 200, 140, image);
var alphaModulate = transparentFrame.PictureFormat.Picture.ImageTransform.AddAlphaModulateFixedEffect(65f);
alphaModulate.Amount = 60f;

var uniformAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 180, 200, 140, image);
uniformAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaReplaceEffect(55f);

var binaryAlphaFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 240, 180, 200, 140, image);
var alphaBiLevel = binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaBiLevelEffect(50f);
alphaBiLevel.Threshold = 45f;
binaryAlphaFrame.PictureFormat.Picture.ImageTransform.AddAlphaInverseEffect();

presentation.Save("blur-and-alpha-effects.pptx", SaveFormat.Pptx);
```

D’autres opérations alpha sans paramètre incluent [AddAlphaCeilingEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), qui rend tout alpha non nul complètement opaque ; [AddAlphaFloorEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), qui rend tout alpha inférieur à 100 % complètement transparent ; et [AddAlphaInverseEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), qui change l’alpha en `100% - alpha`.

## **Construire une chaîne d’effets ordonnée**

Chaque méthode `Add...Effect` ajoute une nouvelle opération à la fin de la collection. Le rendu utilise la collection comme pipeline ordonné : la sortie de l’opération 0 devient l’entrée de l’opération 1, etc. Par conséquent, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi d’une teinte supprime d’abord les informations chromatiques puis recolore le résultat de luminance. Une teinte suivie de niveau de gris supprime de nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations précédentes, tandis que la modulation alpha préserve leurs différences relatives.

L’exemple suivant construit une chaîne de quatre opérations, l’enregistre au format PPTX, rouvre la présentation, vérifie à la fois les types d’opérations et leur ordre, puis rend le résultat rouvert :

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var imageData = File.ReadAllBytes("photo.png");
var image = presentation.Images.AddImage(imageData);
var pictureFrame = slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 400, 260, image);

var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
imageTransform.AddGrayScaleEffect();
imageTransform.AddTintEffect(220f, 25f);
imageTransform.AddBlurEffect(2.5, false);
imageTransform.AddAlphaModulateFixedEffect(80f);

presentation.Save("image-transform-chain.pptx", SaveFormat.Pptx);

using var reopenedPresentation = new Presentation("image-transform-chain.pptx");
var reopenedShape = reopenedPresentation.Slides[0].Shapes[0];

if (reopenedShape is IPictureFrame reopenedFrame)
{
    var reopenedTransform = reopenedFrame.PictureFormat.Picture.ImageTransform;
    var orderIsPreserved = reopenedTransform.Count == 4 && 
            reopenedTransform[0] is IGrayScale && 
            reopenedTransform[1] is ITint && 
            reopenedTransform[2] is IBlur && 
            reopenedTransform[3] is IAlphaModulateFixed;
    Console.WriteLine(orderIsPreserved ? "The effect chain was preserved." : "The effect chain changed during the round trip.");

    using var renderedSlide = reopenedPresentation.Slides[0].GetImage();
    renderedSlide.Save("reopened-effect-chain.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The reopened shape is not a picture frame.");
}
```

La collection n’impose pas de matrice de compatibilité qui restreindrait les opérations couleur, alpha et flou à des chaînes distinctes. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement couleur fixe élimine la variation RVB produite par les effets couleur antérieurs ; le niveau de gris après duo‑tone élimine les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent supprimer les détails alpha créés auparavant. Construisez la chaîne selon la séquence de traitement pixel souhaitée plutôt que de traiter ses éléments comme des drapeaux de formatage non ordonnés.

## **Inspecter les valeurs éditables et effectives**

Une opération éditable est l’objet stocké dans `ISlidesPicture.ImageTransform`. Selon l’effet, elle peut exposer des membres modifiables directement. Par exemple, [IBlur](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iblur/) expose `Radius` et `Grow` modifiables, [IAlphaModulateFixed](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ialphamodulatefixed/) expose `Amount` modifiable, et [IAlphaBiLevel](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ialphabilevel/) expose `Threshold` modifiable. Les effets couleur tels que [IDuotone](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iduotone/) exposent des objets [IColorFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/icolorformat/) mutables.

Certaines interfaces d’opération, dont [IBrightnessContrast](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/itint/) et [IAlphaReplace](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ialphareplace/), n’exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces réglages, supprimez l’opération et ajoutez un remplacement à la position requise.

Les données effectives renvoyées par `GetEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le rendu, mais ce n’est pas une autre surface d’édition. L’exemple suivant énumère la chaîne et inspecte les valeurs effectives lorsque l’API correspondante les fournit :

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        var operation = imageTransform[index];
        Console.WriteLine(index + ": " + operation.GetType().Name);

        switch (operation)
        {
            case IBrightnessContrast brightnessContrast:
                var brightnessContrastData = brightnessContrast.GetEffective();
                Console.WriteLine("  Brightness: " + brightnessContrastData.Brightness);
                Console.WriteLine("  Contrast: " + brightnessContrastData.Contrast);
                break;
            case ILuminance luminance:
                var luminanceData = luminance.GetEffective();
                Console.WriteLine("  Brightness: " + luminanceData.Brightness);
                Console.WriteLine("  Contrast: " + luminanceData.Contrast);
                break;
            case IDuotone duotone:
                var duotoneData = duotone.GetEffective();
                Console.WriteLine("  Dark color: " + duotoneData.Color1);
                Console.WriteLine("  Light color: " + duotoneData.Color2);
                break;
            case IColorReplace colorReplace:
                var colorReplaceData = colorReplace.GetEffective();
                Console.WriteLine("  Replacement color: " + colorReplaceData.Color);
                break;
            case IHSL hsl:
                var hslData = hsl.GetEffective();
                Console.WriteLine("  HSL: " + hslData.Hue + ", " + hslData.Saturation + ", " + hslData.Luminance);
                break;
            case ITint tint:
                var tintData = tint.GetEffective();
                Console.WriteLine("  Tint: " + tintData.Hue + ", " + tintData.Amount);
                break;
            case IBlur blur:
                var blurData = blur.GetEffective();
                Console.WriteLine("  Blur radius: " + blurData.Radius + " pt");
                break;
            case IAlphaModulateFixed alphaModulate:
                var alphaData = alphaModulate.GetEffective();
                Console.WriteLine("  Alpha amount: " + alphaData.Amount + "%");
                break;
            case IAlphaReplace alphaReplace:
                var alphaReplaceData = alphaReplace.GetEffective();
                Console.WriteLine("  Replacement alpha: " + alphaReplaceData.Alpha + "%");
                break;
            case IAlphaBiLevel alphaBiLevel:
                var alphaBiLevelData = alphaBiLevel.GetEffective();
                Console.WriteLine("  Alpha threshold: " + alphaBiLevelData.Threshold + "%");
                break;
        }
    }
}
```

Les effets sans paramètre comme le niveau de gris, le plafond alpha et l’inverse alpha possèdent également un objet de données effectives, mais il n’y a aucune configuration scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou vider les transformations d’image**

Utilisez [IImageTransformOperationCollection.RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/removeat/) pour supprimer une opération par son indice. Comme les indices changent après une suppression, recherchez d’abord la cible puis supprimez‑la après l’énumération. Utilisez `Clear()` pour supprimer toute la chaîne.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

using var presentation = new Presentation("image-transform-chain.pptx");
var pictureFrame = presentation.Slides[0].Shapes.OfType<IPictureFrame>().FirstOrDefault();

if (pictureFrame != null)
{
    var imageTransform = pictureFrame.PictureFormat.Picture.ImageTransform;
    var blurIndex = -1;

    for (var index = 0; index < imageTransform.Count; index++)
    {
        if (imageTransform[index] is IBlur)
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform.RemoveAt(blurIndex);
        Console.WriteLine("The blur operation was removed.");
    }

    imageTransform.Clear();
    Console.WriteLine("Remaining operations: " + imageTransform.Count);
    presentation.Save("image-transforms-cleared.pptx", SaveFormat.Pptx);
}
```

Supprimer ou vider les transformations ne modifie que le formatage de l’image. Cela ne supprime pas, ne recompresse pas et ne modifie pas la ressource [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d’exportation**

Les transformations d’image proviennent de DrawingML, donc le PPTX est le format éditable préféré pour les chaînes d’effets. Même avec le PPTX, toutes les opérations ne disposent pas d’une portabilité identique :

- Les opérations DrawingML standard telles que luminance, niveau de gris, duo‑tone, teinte, HSL, flou et les opérations alpha courantes ont la meilleure chance de survivre à un aller‑retour PPTX. Rouvrez toujours le fichier généré et inspectez la collection lorsque la conservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/brightnesscontrast/) est une extension Office 2010 plutôt que l’opération standard de luminance DrawingML. Elle peut être utilisée pour le rendu en mémoire, mais il n’est pas garanti qu’elle reste un [IBrightnessContrast](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/ibrightnesscontrast/) éditable après sauvegarde et réouverture du PPTX. Privilégiez [AddLuminanceEffect](https://reference.aspose.com/slides/fr/net/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) pour des ajustements de luminosité et contraste persistants.
- Le format binaire PPT précède le modèle complet d’effets DrawingML. Enregistrer au format PPT peut omettre les opérations non prises en charge, réduire une chaîne à un sous‑ensemble supporté ou approximativer l’apparence. N’utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou d’autres sorties visuelles applique la chaîne supportée à l’apparence rendue. Ces sorties ne contiennent pas de `IImageTransformOperationCollection` éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document/vector stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Le rendu d’une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification de couleur sont combinées. Pour une sortie critique, testez à la fois le aller‑retour éditable et le format d’export final avec la même version d’Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d’image modifient‑ils les données d’image incorporées ?**

Non. Les opérations appartiennent au `ISlidesPicture` utilisé par le remplissage d’image. Les octets sous‑jacents du `IPPImage` restent inchangés.

**Deux cadres d’image qui réutilisent la même image partageront‑ils leurs effets ?**

Non. Réutiliser un `IPPImage` évite les doublons de données d’image, mais chaque cadre d’image possède normalement un `ISlidesPicture` séparé et une collection de transformations d’image distincte.

**Les effets couleur, flou et alpha peuvent‑ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent supprimer les détails couleur ou alpha précédents.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l’opération stockée dans la collection de transformations lorsque des membres modifiables existent ; sinon, supprimez‑la et ajoutez un remplacement avec de nouveaux paramètres de création.

**Quel format devrais‑je utiliser pour préserver une chaîne de transformations ?**

Utilisez le PPTX et vérifiez le fichier en le rouvrant. Le PPT hérité ne peut pas représenter le modèle complet d’effets DrawingML, et les formats d’exportation rendus préservent l’apparence plutôt que les opérations de transformation éditables.