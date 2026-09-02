---
title: Gérer les effets de transformation d’image dans les présentations avec C++
linktitle: Effets de transformation d’image
type: docs
weight: 11
url: /fr/cpp/image-transform-effects/
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
- C++
- Aspose.Slides
description: "Appliquer, enchaîner, inspecter, supprimer et vérifier les effets de transformation d’image pour les cadres d’image avec Aspose.Slides pour C++."
---
## **Vue d'ensemble**

Aspose.Slides représente les ajustements d'image comme une collection ordonnée d'opérations de transformation d'image. Pour un cadre d'image, partez de la [ISlidesPicture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/) du cadre et accédez à [ISlidesPicture::get_ImageTransform](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/get_imagetransform/). La [IImageTransformOperationCollection](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/) retournée vous permet d'ajouter, d'énumérer, d'inspecter, de supprimer et de vider les effets sans réécrire les octets d'image d'origine.

Cet article montre un flux de travail complet pour la luminosité et le contraste, les transformations de couleur, le flou, la transparence, les chaînes d'effets ordonnées, les valeurs effectives, la suppression et la vérification de la boucle de conversion PPTX.

## **Comprendre la possession des effets et la réutilisation d'image**

Une ressource d'image et l'image qui l'affiche sont des objets différents :

- [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) stocke ou référence les données source de l'image appartenant à la présentation.
- [ISlidesPicture](https://reference.aspose.com/slides/fr/cpp/aspose.slides/islidespicture/) appartient à un remplissage d'image et fait référence à une ressource d'image tout en stockant la collection de transformations d'image.
- [IPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ipictureframe/) est la forme de diapositive qui possède le remplissage d'image concerné, la géométrie, les paramètres de recadrage et les autres mises en forme au niveau du cadre.

Par conséquent, les opérations de transformation d'image ne modifient pas les octets de [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/). Lorsque le même `IPPImage` est transmis à [IShapeCollection::AddPictureFrame](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ishapecollection/addpictureframe/) plus d'une fois, chaque nouveau cadre d'image reçoit son propre `ISlidesPicture` et sa propre collection de transformations. Appliquer le niveau de gris à un cadre ne rend pas les autres cadres en niveaux de gris, même si tous réutilisent la même ressource d'image intégrée.

Le même modèle `ISlidesPicture::get_ImageTransform` est également utilisé par d'autres remplissages d'image, tels qu'une forme ou l'arrière‑plan d'une diapositive. Les exemples ci‑dessous portent sur les cadres d'image.

## **Utiliser des intervalles et des unités de paramètres valides**

Les méthodes démontrées utilisent les intervalles sémantiques et les unités suivants. Conservez les valeurs dans ces intervalles même si une version particulière de la bibliothèque ne rejette pas immédiatement chaque valeur hors‑intervalle ; le format de présentation cible peut normaliser, omettre ou rejeter les données invalides lors de l'enregistrement ou à l'ouverture du fichier par PowerPoint.

| Opération | Paramètres | Intervalle et unité valides |
|---|---|---|
| [AddBrightnessContrastEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) | `brightness`, `contrast` | `-100` à `100`, pourcentage ; `0` laisse le composant inchangé. |
| [AddGrayScaleEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addgrayscaleeffect/) | Aucun | Aucun paramètre numérique. Alpha reste inchangé. |
| [AddDuotoneEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addduotoneeffect/) | `Color1`, `Color2` | Deux couleurs pour les pixels sombres et clairs. Les canaux RVB et alpha dans `System::Drawing::Color` utilisent `0` à `255`. |
| [AddTintEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addtinteffect/) | `hue`, `amount` | Teinte de `0` (inclus) à `360` (exclu), en degrés ; quantité de `-100` à `100`, pourcentage. |
| [AddHSLEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addhsleffect/) | `hue`, `saturation`, `luminance` | Teinte de `0` (inclus) à `360` (exclu), en degrés ; saturation et luminance de `-100` à `100`, pourcentage. |
| [AddColorReplaceEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) | `Color` | La couleur de remplacement utilise des valeurs de canal de `0` à `255`. Les valeurs alpha existantes restent inchangées. |
| [AddBlurEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) | `radius`, `grow` | Le rayon est non négatif et mesuré en points ; `grow` contrôle si le contenu flou peut s'étendre hors des limites d'origine. |
| [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/) | `amount` | Pourcentage non négatif. Utilisez `0` à `100` pour un facteur d'opacité ordinaire : `0` est totalement transparent et `100` préserve l'alpha existant. |
| [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) | `alpha` | `0` à `100`, pourcentage d'opacité. |
| [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) | `threshold` | `0` à `100`, pourcentage de seuil alpha. Les valeurs en dessous deviennent transparentes ; les valeurs égales ou supérieures deviennent opaques. |

Pour la modulation alpha fixe, la transparence et l'opacité sont complémentaires. Par exemple, 35 % de transparence correspond à une modulation alpha de 65 %.

## **Appliquer la luminosité et le contraste**

[IImageTransformOperationCollection::AddBrightnessContrastEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addbrightnesscontrasteffect/) renvoie une opération [IBrightnessContrast](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ibrightnesscontrast/). Ses paramètres scalaires sont fournis lors de la création de l'opération. La méthode `IBrightnessContrast::GetEffective` renvoie des valeurs calculées en lecture seule qui peuvent être inspectées ou journalisées.

L'exemple suivant augmente la luminosité de 15 % et le contraste de 20 %, puis génère un aperçu sans modifier l'image intégrée :

```cpp
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto brightnessContrast = imageTransform->AddBrightnessContrastEffect(15.0f, 20.0f);

auto effectiveValues = brightnessContrast->GetEffective();
Console::WriteLine(u"Brightness: {0}%", effectiveValues->get_Brightness());
Console::WriteLine(u"Contrast: {0}%", effectiveValues->get_Contrast());

auto preview = slide->GetImage();
preview->Save(u"brightness-contrast-preview.png", ImageFormat::Png);

presentation->Dispose();
```

[BrightnessContrast](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/brightnesscontrast/) est une extension d'effet d'image Office 2010 et est moins portable que l'effet de luminance standard DrawingML. Lorsque la luminosité et le contraste doivent rester modifiables après un aller‑retour PPTX, utilisez [IImageTransformOperationCollection::AddLuminanceEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) et vérifiez le résultat après réouverture du fichier. La section sur les limitations de format explique cette distinction plus en détail.

## **Appliquer des transformations de couleur**

Les effets de couleur peuvent être appliqués indépendamment à différents cadres d'image qui réutilisent une même ressource. L'exemple suivant crée cinq cadres et applique le niveau de gris, le duotone, la teinte, le réglage HSL et le remplacement de couleur.

[IDuotone](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iduotone/) possède deux paramètres de couleur éditables indépendamment : `get_Color1` correspond aux pixels sombres, tandis que `get_Color2` correspond aux pixels clairs. Cela en fait un exemple utile d'effet dont les réglages sont plus complexes qu'une simple valeur scalaire.

```cpp
#include <DOM/Effects/IColorReplace.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IColorFormat.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto grayFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 180.0f, 120.0f, image);
grayFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddGrayScaleEffect();

auto duotoneFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 220.0f, 20.0f, 180.0f, 120.0f, image);
auto duotone = duotoneFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddDuotoneEffect();
duotone->get_Color1()->set_Color(Color::get_Navy());
duotone->get_Color2()->set_Color(Color::get_Gold());

auto tintFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 420.0f, 20.0f, 180.0f, 120.0f, image);
tintFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddTintEffect(210.0f, 35.0f);

auto hslFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 120.0f, 170.0f, 180.0f, 120.0f, image);
hslFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddHSLEffect(30.0f, 20.0f, -10.0f);

auto replacementFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 320.0f, 170.0f, 180.0f, 120.0f, image);
auto colorReplacement = replacementFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddColorReplaceEffect();
colorReplacement->get_Color()->set_Color(Color::get_CornflowerBlue());

presentation->Save(u"color-transformations.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

[AddColorReplaceEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorreplaceeffect/) remplace la couleur de chaque pixel par une couleur fixe tout en préservant l'alpha. C’est différent de [AddColorChangeEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addcolorchangeeffect/), qui mappe une couleur source vers une autre et expose les formats de couleur source et cible.

## **Ajouter le flou, la transparence et les effets alpha**

[AddBlurEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addblureffect/) affecte tous les canaux de couleur, y compris l'alpha. Fixez `grow` à `true` lorsque le bord flou peut dépasser les limites d'origine de l'image.

Pour une transparence uniforme, utilisez [AddAlphaModulateFixedEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphamodulatefixedeffect/). Il multiplie chaque valeur alpha existante, de sorte que les pixels partiellement transparents restent proportionnellement différents. [AddAlphaReplaceEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphareplaceeffect/) attribue à la place une seule valeur alpha à tous les pixels. [AddAlphaBiLevelEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphabileveleffect/) convertit l'alpha en deux niveaux selon un seuil.

```cpp
#include <DOM/Effects/IAlphaBiLevel.h>
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);

auto blurredFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 140.0f, image);
auto blur = blurredFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddBlurEffect(4.5, true);
blur->set_Radius(5.0);

auto transparentFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 20.0f, 200.0f, 140.0f, image);
auto alphaModulate = transparentFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(65.0f);
alphaModulate->set_Amount(60.0f);

auto uniformAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 20.0f, 180.0f, 200.0f, 140.0f, image);
uniformAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform()->AddAlphaReplaceEffect(55.0f);

auto binaryAlphaFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 240.0f, 180.0f, 200.0f, 140.0f, image);
auto binaryAlphaTransform = binaryAlphaFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
auto alphaBiLevel = binaryAlphaTransform->AddAlphaBiLevelEffect(50.0f);
alphaBiLevel->set_Threshold(45.0f);
binaryAlphaTransform->AddAlphaInverseEffect();

presentation->Save(u"blur-and-alpha-effects.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

D’autres opérations alpha sans paramètre incluent [AddAlphaCeilingEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaceilingeffect/), qui rend tout alpha non nul complètement opaque ; [AddAlphaFloorEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphaflooreffect/), qui rend tout alpha inférieur à 100 % totalement transparent ; et [AddAlphaInverseEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addalphainverseeffect/), qui change l'alpha en `100% - alpha`.

## **Construire une chaîne d'effets ordonnée**

Chaque méthode `Add...Effect` ajoute une nouvelle opération à la fin de la collection. Le rendu utilise la collection comme un pipeline ordonné : la sortie de l'opération 0 devient l'entrée de l'opération 1, etc. Ainsi, les mêmes opérations dans un ordre différent peuvent produire une image différente.

Par exemple, le niveau de gris suivi de la teinte enlève d'abord les informations chromatiques puis recolore le résultat de luminance. La teinte suivie du niveau de gris supprime à nouveau la teinte. De même, le remplacement alpha peut écraser les valeurs alpha calculées par les opérations précédentes, tandis que la modulation alpha préserve leurs différences relatives.

L'exemple suivant crée une chaîne de quatre opérations, l'enregistre en PPTX, rouvre la présentation, vérifie les types d'opérations et leur ordre, puis rend le résultat rouvert :

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IGrayScale.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ITint.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto imageData = File::ReadAllBytes(u"photo.png");
auto image = presentation->get_Images()->AddImage(imageData);
auto pictureFrame = slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 50.0f, 50.0f, 400.0f, 260.0f, image);

auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
imageTransform->AddGrayScaleEffect();
imageTransform->AddTintEffect(220.0f, 25.0f);
imageTransform->AddBlurEffect(2.5, false);
imageTransform->AddAlphaModulateFixedEffect(80.0f);

presentation->Save(u"image-transform-chain.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto reopenedShape = reopenedPresentation->get_Slide(0)->get_Shape(0);

if (ObjectExt::Is<IPictureFrame>(reopenedShape))
{
    auto reopenedFrame = ExplicitCast<IPictureFrame>(reopenedShape);
    auto reopenedTransform = reopenedFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto orderIsPreserved = reopenedTransform->get_Count() == 4 && 
            ObjectExt::Is<IGrayScale>(reopenedTransform->idx_get(0)) && 
            ObjectExt::Is<ITint>(reopenedTransform->idx_get(1)) && 
            ObjectExt::Is<IBlur>(reopenedTransform->idx_get(2)) && 
            ObjectExt::Is<IAlphaModulateFixed>(reopenedTransform->idx_get(3));
    Console::WriteLine(orderIsPreserved ? u"The effect chain was preserved." : u"The effect chain changed during the round trip.");

    auto renderedSlide = reopenedPresentation->get_Slide(0)->GetImage();
    renderedSlide->Save(u"reopened-effect-chain.png", ImageFormat::Png);
}
else
{
    Console::WriteLine(u"The reopened shape is not a picture frame.");
}

reopenedPresentation->Dispose();
```

La collection n'impose pas de matrice de compatibilité limitant les opérations couleur, alpha et flou à des chaînes séparées. Elles peuvent être combinées, mais les combinaisons ne sont pas toujours utiles. Un remplacement couleur fixe supprime les variations RVB produites par les effets couleur précédents ; le niveau de gris après duotone supprime les deux couleurs sélectionnées ; et les opérations alpha plafond, plancher, remplacement ou bi‑niveau peuvent éliminer les détails alpha créés plus tôt. Construisez la chaîne selon la séquence de traitement des pixels souhaitée plutôt que de traiter ses éléments comme des indicateurs de mise en forme non ordonnés.

## **Inspecter les valeurs éditables et effectives**

Une opération éditable est l'objet stocké dans `ISlidesPicture::get_ImageTransform`. Selon l'effet, il peut exposer directement des membres modulables. Par exemple, [IBlur](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iblur/) expose `set_Radius` et `set_Grow`, [IAlphaModulateFixed](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ialphamodulatefixed/) expose `set_Amount`, et [IAlphaBiLevel](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ialphabilevel/) expose `set_Threshold`. Les effets couleur tels que [IDuotone](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iduotone/) exposent des objets [IColorFormat](https://reference.aspose.com/slides/fr/cpp/aspose.slides/icolorformat/) mutables.

Certaines interfaces d'opération, dont [IBrightnessContrast](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ibrightnesscontrast/), [IHSL](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ihsl/), [ITint](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/itint/) et [IAlphaReplace](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ialphareplace/), n'exposent pas leurs scalaires de création comme propriétés modifiables. Pour changer ces réglages, supprimez l'opération et ajoutez un remplacement à la position requise.

Les données effectives renvoyées par `GetEffective()` sont calculées et en lecture seule. Elles sont utiles pour résoudre les couleurs dépendantes du thème et lire les valeurs normalisées utilisées par le moteur de rendu, mais ce n’est pas une autre surface d’édition. L’exemple suivant parcourt la chaîne et inspecte les valeurs effectives de plusieurs opérations courantes :

```cpp
#include <DOM/Effects/IAlphaModulateFixed.h>
#include <DOM/Effects/IAlphaModulateFixedEffectiveData.h>
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IBlurEffectiveData.h>
#include <DOM/Effects/IBrightnessContrast.h>
#include <DOM/Effects/IBrightnessContrastEffectiveData.h>
#include <DOM/Effects/IDuotone.h>
#include <DOM/Effects/IDuotoneEffectiveData.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/Effects/ILuminance.h>
#include <DOM/Effects/ILuminanceEffectiveData.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();

    for (auto&& operation : imageTransform)
    {
        if (ObjectExt::Is<IBrightnessContrast>(operation))
        {
            auto brightnessContrast = ExplicitCast<IBrightnessContrast>(operation);
            auto data = brightnessContrast->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<ILuminance>(operation))
        {
            auto luminance = ExplicitCast<ILuminance>(operation);
            auto data = luminance->GetEffective();
            Console::WriteLine(u"Brightness: {0}; contrast: {1}", data->get_Brightness(), data->get_Contrast());
        }
        else if (ObjectExt::Is<IDuotone>(operation))
        {
            auto duotone = ExplicitCast<IDuotone>(operation);
            auto data = duotone->GetEffective();
            Console::WriteLine(u"Dark color: {0}; light color: {1}", data->get_Color1(), data->get_Color2());
        }
        else if (ObjectExt::Is<IBlur>(operation))
        {
            auto blur = ExplicitCast<IBlur>(operation);
            auto data = blur->GetEffective();
            Console::WriteLine(u"Blur radius: {0} pt", data->get_Radius());
        }
        else if (ObjectExt::Is<IAlphaModulateFixed>(operation))
        {
            auto alphaModulate = ExplicitCast<IAlphaModulateFixed>(operation);
            auto data = alphaModulate->GetEffective();
            Console::WriteLine(u"Alpha amount: {0}%", data->get_Amount());
        }
    }
}

presentation->Dispose();
```

Les effets sans paramètre comme le niveau de gris, le plafond alpha et l’inverse alpha possèdent toujours un objet de données effectives, mais il n’y a aucune valeur scalaire à afficher. Leur présence et leur position dans la collection sont les informations importantes.

## **Supprimer ou vider les transformations d'image**

Utilisez [IImageTransformOperationCollection::RemoveAt](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/removeat/) pour supprimer une opération par index. Comme les index changent après une suppression, recherchez d’abord la cible puis supprimez‑la après l’énumération. Utilisez `Clear()` pour supprimer toute la chaîne.

```cpp
#include <DOM/Effects/IBlur.h>
#include <DOM/Effects/IImageTransformOperationCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlidesPicture.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Effects;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"image-transform-chain.pptx");
auto slide = presentation->get_Slide(0);
SharedPtr<IPictureFrame> pictureFrame;

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IPictureFrame>(shape))
    {
        pictureFrame = ExplicitCast<IPictureFrame>(shape);
        break;
    }
}

if (pictureFrame != nullptr)
{
    auto imageTransform = pictureFrame->get_PictureFormat()->get_Picture()->get_ImageTransform();
    auto blurIndex = -1;

    for (auto index = 0; index < imageTransform->get_Count(); ++index)
    {
        if (ObjectExt::Is<IBlur>(imageTransform->idx_get(index)))
        {
            blurIndex = index;
            break;
        }
    }

    if (blurIndex >= 0)
    {
        imageTransform->RemoveAt(blurIndex);
        Console::WriteLine(u"The blur operation was removed.");
    }

    imageTransform->Clear();
    Console::WriteLine(u"Remaining operations: {0}", imageTransform->get_Count());
    presentation->Save(u"image-transforms-cleared.pptx", SaveFormat::Pptx);
}

presentation->Dispose();
```

Supprimer ou vider les transformations ne modifie que la mise en forme de l'image. Cela ne supprime pas, ne recompresse pas et ne modifie pas la ressource [IPPImage](https://reference.aspose.com/slides/fr/cpp/aspose.slides/ippimage/) réutilisée.

## **Considérer les formats de présentation et les cibles d'exportation**

Les transformations d'image proviennent de DrawingML, ainsi le PPTX est le format éditable privilégié pour les chaînes d'effets. Même avec PPTX, toutes les opérations ne sont pas également portables :

- Les opérations DrawingML standard comme luminance, niveau de gris, duotone, teinte, HSL, flou et les opérations alpha courantes ont le meilleur chance de survivre à un aller‑retour PPTX. Réouvrez toujours le fichier généré et inspectez la collection lorsqu’une conservation est requise.
- [BrightnessContrast](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/brightnesscontrast/) est une extension Office 2010 plutôt que l’opération de luminance DrawingML standard. Elle peut être utilisée pour le rendu en mémoire, mais il n’est pas garanti qu’elle reste un [IBrightnessContrast](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/ibrightnesscontrast/) éditable après sauvegarde et réouverture du PPTX. Privilégiez [AddLuminanceEffect](https://reference.aspose.com/slides/fr/cpp/aspose.slides.effects/iimagetransformoperationcollection/addluminanceeffect/) pour des ajustements de luminosité et contraste persistants.
- Le format binaire PPT précède le modèle complet d'effets DrawingML. En enregistrant en PPT, les opérations non supportées peuvent être omises, la chaîne réduite à un sous‑ensemble supporté, ou l’apparence approximée. N’utilisez pas le PPT comme format de vérification pour une chaîne éditable complexe.
- Le rendu vers PNG, JPEG, TIFF, PDF, SVG, HTML ou d’autres sorties visuelles applique la chaîne supportée à l’aspect rendu. Ces sorties ne contiennent pas de `IImageTransformOperationCollection` éditable ; les formats raster aplatissent le résultat en pixels, et les exportations document ou vecteur stockent leur propre représentation de rendu.
- Les effets ne rendent pas une image liée autonome. Le rendu d’une image liée dépend toujours de la disponibilité de la ressource liée lors du chargement de la présentation.

Différents consommateurs de présentations peuvent rendre les cas limites différemment, surtout lorsque plusieurs opérations alpha ou de quantification couleur sont combinées. Pour une sortie critique, testez à la fois le aller‑retour éditable et le format d’export final avec la même version d’Aspose.Slides utilisée en production.

## **FAQ**

**Les effets de transformation d’image modifient‑ils les données d’image intégrées ?**

Non. Les opérations appartiennent au `ISlidesPicture` utilisé par le remplissage d’image. Les octets sous‑jacents de `IPPImage` restent inchangés.

**Deux cadres d’image réutilisant la même image partagent‑ils leurs effets ?**

Non. Réutiliser un `IPPImage` évite la duplication des données d’image, mais chaque cadre d’image possède normalement un `ISlidesPicture` distinct et sa propre collection de transformations.

**Les effets couleur, flou et alpha peuvent‑ils être combinés ?**

Oui. La collection les accepte dans une chaîne ordonnée. Considérez ce que chaque opération fait à la sortie de la précédente, car les opérations de remplacement et de seuil peuvent supprimer les détails couleur ou alpha antérieurs.

**Pourquoi les valeurs effectives sont‑elles en lecture seule ?**

Les données effectives représentent les valeurs calculées utilisées pour le rendu, y compris les couleurs résolues. Modifiez l’opération stockée dans la collection de transformations lorsqu’il existe des membres modulables ; sinon, supprimez‑la et ajoutez un remplacement avec de nouveaux paramètres de création.

**Quel format devrais‑je utiliser pour conserver une chaîne de transformations ?**

Utilisez PPTX et vérifiez le fichier en le réouvrant. Le PPT hérité ne peut pas représenter le modèle complet d’effets DrawingML, et les formats d’exportation rendus conservent l’apparence plutôt que les opérations de transformation éditables.