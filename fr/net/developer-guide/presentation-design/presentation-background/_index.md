---
title: Gérer les arrière-plans de présentation dans .NET
linktitle: Arrière-plan de diapositive
type: docs
weight: 20
url: /fr/net/presentation-background/
keywords:
- arrière-plan de présentation
- arrière-plan de diapositive
- couleur unie
- couleur dégradée
- arrière-plan d'image
- transparence de l'arrière-plan
- propriétés de l'arrière-plan
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à définir des arrière-plans dynamiques dans les fichiers PowerPoint et OpenDocument avec Aspose.Slides pour .NET, grâce à des astuces de code pour améliorer vos présentations."
---
## **Introduction**

Les couleurs unies, les dégradés et les images sont couramment utilisés comme arrière‑plan de diapositives. Vous pouvez définir l’arrière‑plan d’une **diapositive normale** (une seule diapositive) ou d’une **diapositive maître** (qui s’applique à plusieurs diapositives à la fois).

![PowerPoint background](powerpoint-background.png)

## **Définir un arrière‑plan de couleur unie pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan d’une diapositive spécifique dans une présentation — même si la présentation utilise une diapositive maître. La modification s’applique uniquement à la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/solidfillcolor/) de [FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/) pour spécifier la couleur unie de l’arrière‑plan.
5. Enregistrez la présentation modifiée.

L’exemple C# suivant montre comment définir une couleur unie bleue comme arrière‑plan d’une diapositive normale :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    // Définir la couleur d'arrière-plan de la diapositive en bleu.
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Blue;

    // Enregistrer la présentation sur le disque.
    presentation.Save("SolidColorBackground.pptx", SaveFormat.Pptx);
}
```

## **Définir un arrière‑plan de couleur unie pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme arrière‑plan de la diapositive maître d’une présentation. La diapositive maître agit comme un modèle qui contrôle la mise en forme de toutes les diapositives, ainsi, lorsque vous choisissez une couleur unie pour l’arrière‑plan de la diapositive maître, elle s’applique à chaque diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/net/aspose.slides/backgroundtype/) de la diapositive maître (via `masters`) sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive maître sur `Solid`.
4. Utilisez le [SolidFillColor](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/solidfillcolor/) pour spécifier la couleur unie de l’arrière‑plan.
5. Enregistrez la présentation modifiée.

L’exemple C# suivant montre comment définir une couleur unie (vert forêt) comme arrière‑plan d’une diapositive maître :

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation())
{
    IMasterSlide masterSlide = presentation.Masters[0];

    // Définir la couleur d'arrière-plan de la diapositive Maître en Vert forêt.
    masterSlide.Background.Type = BackgroundType.OwnBackground;
    masterSlide.Background.FillFormat.FillType = FillType.Solid;
    masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Enregistrer la présentation sur le disque.
    presentation.Save("MasterSlideBackground.pptx", SaveFormat.Pptx);
}
```

## **Définir un arrière‑plan en dégradé pour une diapositive**

Un dégradé est un effet graphique créé par une transition progressive de couleur. Lorsqu’il est utilisé comme arrière‑plan de diapositive, le dégradé peut rendre les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur en dégradé comme arrière‑plan des diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/gradientformat/) de [FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/) pour configurer vos paramètres de dégradé préférés.
5. Enregistrez la présentation modifiée.

L’exemple C# suivant montre comment définir une couleur en dégradé comme arrière‑plan d’une diapositive :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Définir une image comme arrière‑plan de diapositive**

En plus des remplissages unis et en dégradé, Aspose.Slides vous permet d’utiliser des images comme arrière‑plan de diapositive.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Définissez le [BackgroundType](https://reference.aspose.com/slides/fr/net/aspose.slides/backgroundtype/) de la diapositive sur `OwnBackground`.
3. Définissez le [FillType](https://reference.aspose.com/slides/fr/net/aspose.slides/filltype/) de l’arrière‑plan de la diapositive sur `Picture`.
4. Chargez l’image que vous souhaitez utiliser comme arrière‑plan de la diapositive.
5. Ajoutez l’image à la collection d’images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/picturefillformat/) de [FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/fillformat/) pour assigner l’image comme arrière‑plan.
7. Enregistrez la présentation modifiée.

L’exemple C# suivant montre comment définir une image comme arrière‑plan d’une diapositive :

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Le fragment de code suivant montre comment définir le type de remplissage d’arrière‑plan sur une image en mosaïque et modifier les propriétés de tuilage :

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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

{{% alert color="info" %}}
Lisez‑plus : [**Tile Picture As Texture**](/slides/fr/net/shape-formatting/#tile-picture-as-texture).
{{% /alert %}}

### **Modifier la transparence de l’image d’arrière‑plan**

Vous pouvez souhaiter ajuster la transparence de l’image d’arrière‑plan d’une diapositive afin que le contenu de la diapositive ressorte davantage. Le code C# suivant vous montre comment modifier la transparence d’une image d’arrière‑plan de diapositive :

```cs
using Aspose.Slides;
using Aspose.Slides.Effects;
using Aspose.Slides.Export;

var transparencyValue = 30; // Par exemple.

using (Presentation presentation = new Presentation("ImageAsBackground.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Obtenir la collection d'opérations de transformation d'image.
    var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

    // Rechercher un effet de transparence fixe existant.
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

    presentation.Save("ImageBackgroundTransparency.pptx", SaveFormat.Pptx);
}
```

## **Obtenir la valeur de l’arrière‑plan de la diapositive**

Aspose.Slides fournit l’interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/fr/net/aspose.slides/ibackgroundeffectivedata/) pour récupérer les valeurs effectives de l’arrière‑plan d’une diapositive. Cette interface expose le [FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibackgroundeffectivedata/fillformat/) et le [EffectFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibackgroundeffectivedata/effectformat/) effectifs.

En utilisant la propriété `background` de la classe [BaseSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/baseslide/), vous pouvez obtenir l’arrière‑plan effectif d’une diapositive.

L’exemple C# suivant montre comment obtenir la valeur d’arrière‑plan effectif d’une diapositive :

```cs
using Aspose.Slides;

// Créer une instance de la classe Presentation.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    ISlide slide = presentation.Slides[0];  

    // Récupérer l'arrière-plan effectif, en tenant compte du maître, de la mise en page et du thème.
    IBackgroundEffectiveData effBackground = slide.Background.GetEffective();

    if (effBackground.FillFormat.FillType == FillType.Solid)
        Console.WriteLine("Fill color: " + effBackground.FillFormat.SolidFillColor);
    else
        Console.WriteLine("Fill type: " + effBackground.FillFormat.FillType);
}
```

## **FAQ**

### Puis‑je réinitialiser un arrière‑plan personnalisé et restaurer l’arrière‑plan du thème/mise en page ?

Oui. Supprimez le remplissage personnalisé de la diapositive, et l’arrière‑plan sera de nouveau hérité de la diapositive [mise en page](/slides/fr/net/slide-layout/)/[maître](/slides/fr/net/slide-master/) correspondante (c’est‑à‑dire de l’[arrière‑plan du thème](/slides/fr/net/presentation-theme/)).

### Que se passe‑t‑il pour l’arrière‑plan si je change le thème de la présentation ultérieurement ?

Si une diapositive possède son propre remplissage, celui‑ci restera inchangé. Si l’arrière‑plan est hérité de la [mise en page](/slides/fr/net/slide-layout/)/[maître](/slides/fr/net/slide-master/), il sera mis à jour pour correspondre au [nouveau thème](/slides/fr/net/presentation-theme/).