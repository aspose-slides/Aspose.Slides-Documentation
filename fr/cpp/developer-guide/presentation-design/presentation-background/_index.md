---
title: Gérer les arrière-plans de présentation en C++
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/cpp/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- couleur dégradée
- image d'arrière-plan
- transparence d'arrière-plan
- propriétés d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour C++, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d'ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés pour les arrière-plans de diapositives. Vous pouvez définir l'arrière-plan d'une **diapositive normale** (une seule diapositive) ou d'une **diapositive maître** (s'applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière-plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan d'une diapositive spécifique dans une présentation, même si la présentation utilise une diapositive maître. La modification ne s'applique qu'à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de l'arrière-plan de la diapositive sur `Solid`.
4. Utilisez la méthode [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) sur [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) pour spécifier la couleur d'arrière-plan unie.
5. Enregistrez la présentation modifiée.

L'exemple C++ suivant montre comment définir une couleur bleue unie comme arrière-plan d'une diapositive normale :
```cpp
// Créer une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Définir la couleur d'arrière-plan de la diapositive à bleu.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
slide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Enregistrer la présentation sur le disque.
presentation->Save(u"SolidColorBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Définir un arrière-plan de couleur unie pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan de la diapositive maître d'une présentation. La diapositive maître sert de modèle qui contrôle le formatage de toutes les diapositives, de sorte que lorsque vous choisissez une couleur unie pour l'arrière-plan de la diapositive maître, celle-ci s'applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositive maître (via `get_Masters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de l'arrière-plan de la diapositive maître sur `Solid`.
4. Utilisez la méthode [get_SolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_solidfillcolor/) pour spécifier la couleur d'arrière-plan unie.
5. Enregistrez la présentation modifiée.

L'exemple C++ suivant montre comment définir une couleur verte forêt comme arrière-plan d'une diapositive maître :
```cpp
// Créer une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto masterSlide = presentation->get_Master(0);

// Définir la couleur d'arrière-plan pour la diapositive Master à Vert forêt.
masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

// Enregistrer la présentation sur le disque.
presentation->Save(u"MasterSlideBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Définir un arrière-plan en dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une variation progressive de couleur. Lorsqu'il est utilisé comme arrière-plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur en dégradé comme arrière-plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de l'arrière-plan de la diapositive sur `Gradient`.
4. Utilisez la méthode [get_GradientFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_gradientformat/) sur [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) pour configurer les paramètres de dégradé souhaités.
5. Enregistrez la présentation modifiée.

L'exemple C++ suivant montre comment définir une couleur en dégradé comme arrière-plan d'une diapositive :
```cpp
// Créer une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Appliquer un effet de dégradé à l'arrière-plan.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Gradient);
slide->get_Background()->get_FillFormat()->get_GradientFormat()->set_TileFlip(TileFlip::FlipBoth);

// Enregistrer la présentation sur le disque.
presentation->Save(u"GradientBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


## **Définir une image comme arrière-plan de diapositive**

En plus des remplissages unis et en dégradé, Aspose.Slides vous permet d'utiliser des images comme arrière-plans de diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/cpp/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) de l'arrière-plan de la diapositive sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la méthode [get_PictureFillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/get_picturefillformat/) sur [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/fillformat/) pour affecter l'image comme arrière-plan.
7. Enregistrez la présentation modifiée.

L'exemple C++ suivant montre comment définir une image comme arrière-plan d'une diapositive :
```cpp
// Créer une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);

// Définir les propriétés de l'image d'arrière-plan.
slide->get_Background()->set_Type(BackgroundType::OwnBackground);
slide->get_Background()->get_FillFormat()->set_FillType(FillType::Picture);
slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);

// Charger l'image.
auto image = Images::FromFile(u"Tulips.jpg");
// Ajouter l'image à la collection d'images de la présentation.
auto ppImage = presentation->get_Images()->AddImage(image);
image->Dispose();

slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(ppImage);

// Enregistrer la présentation sur le disque.
presentation->Save(u"ImageAsBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


L'exemple de code suivant montre comment définir le type de remplissage d'arrière-plan sur une image en mosaïque et modifier les propriétés de mise en mosaïque :
```cpp
auto presentation = MakeObject<Presentation>();

auto firstSlide = presentation->get_Slide(0);

auto background = firstSlide->get_Background();

background->set_Type(BackgroundType::OwnBackground);
background->get_FillFormat()->set_FillType(FillType::Picture);

auto newImage = Images::FromFile(u"image.png");
auto ppImage = presentation->get_Images()->AddImage(newImage);
newImage->Dispose();

// Set the image used for the background fill.
auto backPictureFillFormat = background->get_FillFormat()->get_PictureFillFormat();
backPictureFillFormat->get_Picture()->set_Image(ppImage);

// Set the picture fill mode to Tile and adjust the tile properties.
backPictureFillFormat->set_PictureFillMode(PictureFillMode::Tile);
backPictureFillFormat->set_TileOffsetX(15.0);
backPictureFillFormat->set_TileOffsetY(15.0);
backPictureFillFormat->set_TileScaleX(46.0);
backPictureFillFormat->set_TileScaleY(87.0);
backPictureFillFormat->set_TileAlignment(RectangleAlignment::Center);
backPictureFillFormat->set_TileFlip(TileFlip::FlipY);

presentation->Save(u"TileBackground.pptx", SaveFormat::Pptx);
presentation->Dispose();
```


{{% alert color="primary" %}}

En savoir plus : [**Image mosaïquée comme texture**](/slides/fr/cpp/shape-formatting/#tile-picture-as-texture).

{{% /alert %}}

### **Modifier la transparence de l'image d'arrière-plan**

Vous pouvez souhaiter ajuster la transparence de l'image d'arrière-plan d'une diapositive afin que le contenu de la diapositive ressorte davantage. Le code C++ suivant vous montre comment modifier la transparence d'une image d'arrière-plan de diapositive :
```cpp
auto transparencyValue = 30; // Par exemple.

// Obtenir la collection des opérations de transformation d'image.
auto imageTransform = slide->get_Background()->get_FillFormat()->get_PictureFillFormat()->get_Picture()->get_ImageTransform();

// Trouver un effet de transparence à pourcentage fixe existant.
SharedPtr<IAlphaModulateFixed> transparencyOperation;
for (auto&& operation : imageTransform)
{
    if (ObjectExt::Is<IAlphaModulateFixed>(operation))
    {
        transparencyOperation = ExplicitCast<IAlphaModulateFixed>(operation);
        break;
    }
}

// Définir la nouvelle valeur de transparence.
if (transparencyOperation == nullptr)
{
    imageTransform->AddAlphaModulateFixedEffect(100.0f - transparencyValue);
}
else
{
    transparencyOperation->set_Amount(100.0f - transparencyValue);
}
```


## **Obtenir la valeur d'arrière-plan de la diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs d'arrière-plan effectives d'une diapositive. Cette interface expose le [FillFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibackgroundeffectivedata/get_effectformat/) effectifs.

En utilisant la méthode `get_Background` de la classe [BaseSlide](https://reference.aspose.com/slides/cpp/aspose.slides/baseslide/), vous pouvez obtenir l'arrière-plan effectif d'une diapositive.

L'exemple C++ suivant montre comment obtenir la valeur d'arrière-plan effective d'une diapositive :
```cpp
// Créer une instance de la classe Presentation.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

auto slide = presentation->get_Slide(0);

// Retrieve the effective background, taking into account master, layout, and theme.
auto effBackground = slide->get_Background()->GetEffective();

if (effBackground->get_FillFormat()->get_FillType() == FillType::Solid)
{
    Console::WriteLine(u"Fill color: {0}", effBackground->get_FillFormat()->get_SolidFillColor());
}
else
{
    Console::WriteLine(u"Fill type: {0}", ObjectExt::ToString(effBackground->get_FillFormat()->get_FillType()));
}
```


## **FAQ**

**Puis-je réinitialiser un arrière-plan personnalisé et restaurer l'arrière-plan du thème/de la disposition ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l'arrière-plan sera à nouveau hérité de la diapositive [layout](/slides/fr/cpp/slide-layout/)/[master](/slides/fr/cpp/slide-master/) correspondante (c’est-à-dire le [theme background](/slides/fr/cpp/presentation-theme/)).

**Que se passe-t-il pour l'arrière-plan si je change le thème de la présentation plus tard ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l'arrière-plan est hérité de la [layout](/slides/fr/cpp/slide-layout/)/[master](/slides/fr/cpp/slide-master/), il sera mis à jour pour correspondre au [new theme](/slides/fr/cpp/presentation-theme/).