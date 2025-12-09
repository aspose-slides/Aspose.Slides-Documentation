---
title: Gestion des arrière-plans de présentation dans .NET
linktitle: Arrière‑plan de diapositive
type: docs
weight: 20
url: /fr/net/presentation-background/
keywords:
- arrière‑plan de présentation
- arrière‑plan de diapositive
- couleur unie
- couleur dégradée
- arrière‑plan d'image
- transparence d'arrière‑plan
- propriétés d'arrière‑plan
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à définir des arrière‑plans dynamiques dans les fichiers PowerPoint et OpenDocument en utilisant Aspose.Slides pour .NET, avec des astuces de code pour améliorer vos présentations."
---

## **Vue d'ensemble**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière-plans de diapositives. Vous pouvez définir l'arrière-plan pour une **diapositive normale** (une seule diapositive) ou une **diapositive maître** (s'applique à plusieurs diapositives à la fois).

![Arrière-plan PowerPoint](powerpoint-background.png)

## **Définir un arrière-plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour une diapositive spécifique dans une présentation — même si la présentation utilise une diapositive maître. La modification ne s'applique qu'à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) d'arrière-plan de la diapositive sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) sur [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour spécifier la couleur d'arrière-plan unie.
5. Enregistrez la présentation modifiée.

L'exemple C# suivant montre comment définir une couleur bleue unie comme arrière-plan d'une diapositive normale :
```cs
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Définir la couleur d'arrière-plan de la diapositive à bleu.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Enregistrer la présentation sur le disque.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```


## **Définir un arrière-plan de couleur unie pour la diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière-plan pour la diapositive maître d'une présentation. La diapositive maître agit comme un modèle qui contrôle le formatage de toutes les diapositives ; ainsi, lorsque vous choisissez une couleur unie pour l'arrière-plan de la diapositive maître, elle s'applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive maître (via `masters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) d'arrière-plan de la diapositive maître sur `Solid`.
4. Utilisez le [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) pour spécifier la couleur d'arrière-plan unie.
5. Enregistrez la présentation modifiée.

L'exemple C# suivant montre comment définir une couleur unie (vert forêt) comme arrière-plan d'une diapositive maître :
```cs
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Définir la couleur d'arrière-plan de la diapositive maître à Vert forêt.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Enregistrer la présentation sur le disque.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```


## **Définir un arrière-plan en dégradé pour une diapositive**

Un dégradé est un effet graphique créé par un changement progressif de couleur. Lorsqu'il est utilisé comme arrière-plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur de dégradé comme arrière-plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) d'arrière-plan de la diapositive sur `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) sur [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour configurer les paramètres de votre dégradé préféré.
5. Enregistrez la présentation modifiée.

L'exemple C# suivant montre comment définir une couleur de dégradé comme arrière-plan d'une diapositive :
```cs
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Appliquer un effet de dégradé à l'arrière-plan.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Gradient;
    slide.Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Enregistrer la présentation sur le disque.
    presentation.Save("GradientBackground.pptx", SaveFormat.Pptx);
}
```


## **Définir une image comme arrière-plan de diapositive**

En plus des remplissages unis et en dégradé, Aspose.Slides vous permet d'utiliser des images comme arrière-plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) d'arrière-plan de la diapositive sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme arrière-plan de la diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) sur [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour affecter l'image comme arrière-plan.
7. Enregistrez la présentation modifiée.

L'exemple C# suivant montre comment définir une image comme arrière-plan d'une diapositive :
```c#
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Définir les propriétés de l'image d'arrière-plan.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Picture;
    slide.Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Charger l'image.
    IImage image = Images.FromFile("Tulips.jpg");
    // Ajouter l'image à la collection d'images de la présentation.
    IPPImage ppImage = presentation.Images.AddImage(image);
    image.Dispose();

    slide.Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Enregistrer la présentation sur le disque.
    presentation.Save("ImageAsBackground.pptx", SaveFormat.Pptx);
}
```


L'exemple de code suivant montre comment définir le type de remplissage d'arrière-plan sur une image en mosaïque et modifier les propriétés de mosaïquage :
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

    // Définir l'image utilisée pour le remplissage d'arrière-plan.
    IPictureFillFormat backPictureFillFormat = background.FillFormat.PictureFillFormat;
    backPictureFillFormat.Picture.Image = ppImage;

    // Définir le mode de remplissage de l'image sur Carreau et ajuster les propriétés du carrelage.
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
En savoir plus : [**Image en mosaïque comme texture**](/slides/fr/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l'image d'arrière-plan**

Vous pouvez souhaiter ajuster la transparence de l'image d'arrière-plan d'une diapositive afin de faire ressortir le contenu de la diapositive. Le code C# suivant montre comment modifier la transparence d'une image d'arrière-plan de diapositive :
```cs
var transparencyValue = 30; // Par exemple.

// Get the collection of picture transform operations.
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Find an existing fixed-percentage transparency effect.
var transparencyOperation = null as IAlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is IAlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Set the new transparency value.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```


## **Obtenir la valeur de l'arrière-plan de la diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs effectives d'arrière-plan d'une diapositive. Cette interface expose le [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/) effectifs.

En utilisant la propriété `background` de la classe [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), vous pouvez obtenir l'arrière-plan effectif d'une diapositive.

L'exemple C# suivant montre comment obtenir la valeur d'arrière-plan effectif d'une diapositive :
```cs
// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Récupérer l'arrière-plan effectif, en tenant compte du maître, de la disposition et du thème.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```


## **FAQ**

**Puis-je réinitialiser un arrière-plan personnalisé et restaurer l'arrière-plan du thème/mise en page ?**

Oui. Supprimez le remplissage personnalisé de la diapositive, et l'arrière‑plan sera de nouveau hérité de la diapositive correspondante [layout](/slides/fr/net/slide-layout/)/[master](/slides/fr/net/slide-master/) (c’est‑à‑dire le [theme background](/slides/fr/net/presentation-theme/)).

**Que se passe-t-il à l'arrière‑plan si je change le thème de la présentation plus tard ?**

Si une diapositive possède son propre remplissage, il restera inchangé. Si l'arrière‑plan est hérité du [layout](/slides/fr/net/slide-layout/)/[master](/slides/fr/net/slide-master/), il sera mis à jour pour correspondre au [new theme](/slides/fr/net/presentation-theme/).