---
title: Gérer les arrière-plans de présentation en C#
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/net/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- dégradé de couleur
- arrière-plan d'image
- transparence d'arrière-plan
- propriétés d'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d'ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés pour les arrière-plans de diapositive. Vous pouvez definir l'arriere-plan d'une **diapositive normale** (une seule diapositive) ou d'une **diapositive modele** (s'applique a plusieurs diapositives a la fois).

![PowerPoint background](powerpoint-background.png)

## **Definir un arriere-plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de definir une couleur unie comme arriere-plan pour une diapositive specifique d'une presentation - meme si la presentation utilise une diapositive modele. La modification s'applique uniquement a la diapositive selectionnee.

1. Creez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Definissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Definissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de l'arriere-plan de la diapositive sur `Solid`.
4. Utilisez la propriete [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) de [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour specifier la couleur unie de l'arriere-plan.
5. Enregistrez la presentation modifiee.

L'exemple C# suivant montre comment definir une couleur bleue unite comme arriere-plan d'une diapositive normale:
```cs
// Créez une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Définissez la couleur d'arrière-plan de la diapositive en bleu.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Enregistrez la présentation sur le disque.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **Definir un arriere-plan de couleur unie pour la diapositive modele**

Aspose.Slides vous permet de definir une couleur unie comme arriere-plan de la diapositive modele d'une presentation. La diapositive modele sert de modele qui controle le formatage de toutes les diapositives, ainsi lorsque vous choisissez une couleur unie pour l'arriere-plan de la diapositive modele, elle s'applique a chaque diapositive.

1. Creez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Definissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive modele (via `masters`) sur `OwnBackground`.
3. Definissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de l'arriere-plan de la diapositive modele sur `Solid`.
4. Utilisez la [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) pour specifier la couleur unie de l'arriere-plan.
5. Enregistrez la presentation modifiee.

L'exemple C# suivant montre comment definir une couleur vert forêt comme arriere-plan de la diapositive modele:
```cs
// Créez une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Définissez la couleur d'arrière-plan de la diapositive maître sur vert forêt.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Enregistrez la présentation sur le disque.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Definir un arriere-plan degrade pour une diapositive**

Un degrade est un effet graphique cree par une variation progressive de couleur. Lorsqu'il est utilise comme arriere-plan de diapositive, le degrade peut rendre les presentations plus artistiques et professionelles. Aspose.Slides vous permet de definir une couleur de degrade comme arriere-plan des diapositives.

1. Creez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Definissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Definissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de l'arriere-plan de la diapositive sur `Gradient`.
4. Utilisez la propriete [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) de [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour configurer les parametres de degrade souhaites.
5. Enregistrez la presentation modifiee.

L'exemple C# suivant montre comment definir une couleur de degrade comme arriere-plan d'une diapositive:
```cs
// Créez une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Appliquez un effet de dégradé à l'arrière-plan.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Enregistrez la présentation sur le disque.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Definir une image comme arriere-plan de diapositive**

En plus des remplissages unis et degres, Aspose.Slides vous permet d'utiliser des images comme arriere-plan de diapositive.

1. Creez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Definissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Definissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) de l'arriere-plan de la diapositive sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arriere-plan de la diapositive.
5. Ajoutez l'image a la collection d'images de la presentation.
6. Utilisez la propriete [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) de [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour affecter l'image comme arriere-plan.
7. Enregistrez la presentation modifiee.

Le code suivant montre comment definir le type de remplissage d'arriere-plan sur une image en mosaïque et modifier les proprietes de mosaïquage:
```cs
using (Presentation presentation = new Presentation())
{
    ISlide firstSlide = presentation.Slides[0];

    IBackground background = firstSlide.Background;

    background.Type = BackgroundType.OwnBackground;
    background.FillFormat.FillType = FillType.Picture;

    IPPImage ppImage;
    using (IImage newImage = Aspose.Slides.Images.FromFile("image.png"))
        ppImage = presentation.Images.AddImage(newImage);

    // Définir l'image utilisée pour le remplissage de l'arrière-plan.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Définir le mode de remplissage de l'image sur Tuile et ajuster les propriétés de la tuile.
    backPictureFillFormat.PictureFillMode = PictureFillMode.Tile;
    backPictureFillFormat.TileOffsetX = 15f;
    backPictureFillFormat.TileOffsetY = 15f;
    backPictureFillFormat.TileScaleX = 46f;
    backPictureFillFormat.TileScaleY = 87f;
    backPictureFillFormat.TileAlignment = RectangleAlignment.Center;
    backPictureFillFormat.TileFlip = TileFlip.FlipY;

    presentation.Save("TileBackground.pptx", SaveFormat.Pptx);
}
```


{{% alert color="primary" %}}
En savoir plus: [**Tile Picture As Texture**](/slides/fr/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l'image d'arriere-plan**

Vous pouvez vouloir ajuster la transparence de l'image d'arriere-plan d'une diapositive afin de faire ressortir le contenu de la diapositive. Le code C# suivant vous montre comment modifier la transparence d'une image d'arriere-plan de diapositive:
```cs
var transparencyValue = 30; // Par exemple.

// Obtenir la collection des opérations de transformation d'image.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Trouver un effet de transparence à pourcentage fixe existant.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Définir la nouvelle valeur de transparence.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **Obtenir la valeur d'arriere-plan de la diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) pour recuperer les valeurs effectives d'arriere-plan d'une diapositive. Cette interface expose le [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) effectifs.

En utilisant la propriete `background` de la classe [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), vous pouvez obtenir l'arriere-plan effectif d'une diapositive.

```cs
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Récupérer l'arrière-plan effectif, en tenant compte du master, de la mise en page et du thème.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **FAQ**

**Puis-je reinitialiser un arriere-plan personnalise et restaurer l'arriere-plan du theme/de la mise en page?**

Oui. Supprimez le remplissage personnalise de la diapositive, et l'arriere-plan sera a nouveau herite de la diapositive [layout](/slides/fr/net/slide-layout/)/[master](/slides/fr/net/slide-master/) correspondante (c'est-a-dire le [theme background](/slides/fr/net/presentation-theme/)).

**Que se passe-t-il avec l'arriere-plan si je change le theme de la presentation plus tard?**

Si une diapositive possede son propre remplissage, il restera inchange. Si l'arriere-plan est herite de la diapositive [layout](/slides/fr/net/slide-layout/)/[master](/slides/fr/net/slide-master/), il sera mis a jour pour correspondre au [new theme](/slides/fr/net/presentation-theme/).