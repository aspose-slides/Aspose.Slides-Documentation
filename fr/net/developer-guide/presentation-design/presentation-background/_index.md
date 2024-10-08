---
title: Fond de présentation
type: docs
weight: 20
url: /fr/net/presentation-background/
keywords:
- Fond PowerPoint
- définir le fond
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Définir le fond dans une présentation PowerPoint en C# ou .NET"
---

Les couleurs unies, les dégradés de couleurs et les images sont souvent utilisées comme images de fond pour les diapositives. Vous pouvez définir le fond soit pour une **diapositive normale** (diapositive unique) soit pour une **diapositive maître** (plusieurs diapositives à la fois).

<img src="powerpoint-background.png" alt="powerpoint-background"  />

## **Définir une couleur unie comme fond pour une diapositive normale**

Aspose.Slides vous permet de définir une couleur unie comme fond pour une diapositive spécifique dans une présentation (même si cette présentation contient une diapositive maître). Le changement de fond n'affecte que la diapositive sélectionnée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) pour le fond de la diapositive sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) exposée par [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour spécifier une couleur unie pour le fond.
5. Enregistrez la présentation modifiée.

Ce code C# vous montre comment définir une couleur unie (bleu) comme fond pour une diapositive normale :

```c#
// Crée une instance de la classe Presentation
using (Presentation pres = new Presentation())
{

    // Définit la couleur de fond pour la première ISlide sur Bleu
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Slides[0].Background.FillFormat.SolidFillColor.Color = Color.Blue;
    
    // Écrit la présentation sur le disque
    pres.Save("ContentBG_out.pptx", SaveFormat.Pptx);
}
```

## **Définir une couleur unie comme fond pour une diapositive maître**

Aspose.Slides vous permet de définir une couleur unie comme fond pour la diapositive maître dans une présentation. La diapositive maître agit en tant que modèle qui contient et contrôle les paramètres de formatage pour toutes les diapositives. Par conséquent, lorsque vous sélectionnez une couleur unie comme fond pour la diapositive maître, ce nouveau fond sera utilisé pour toutes les diapositives.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) pour la diapositive maître (`Masters`) sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) pour le fond de la diapositive maître sur `Solid`.
4. Utilisez la propriété [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/fillformat/solidfillcolor/) exposée par [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour spécifier une couleur unie pour le fond.
5. Enregistrez la présentation modifiée.

Ce code C# vous montre comment définir une couleur unie (vert forêt) comme fond pour une diapositive maître dans une présentation :

```c#
// Crée une instance de la classe Presentation
using (Presentation pres = new Presentation())
{

    // Définit la couleur de fond pour la diapositive maître ISlide sur Vert forêt
    pres.Masters[0].Background.Type = BackgroundType.OwnBackground;
    pres.Masters[0].Background.FillFormat.FillType = FillType.Solid;
    pres.Masters[0].Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

    // Écrit la présentation sur le disque
    pres.Save("SetSlideBackgroundMaster_out.pptx", SaveFormat.Pptx);

}
```

## **Définir une couleur dégradée comme fond pour une diapositive**

Un dégradé est un effet graphique basé sur un changement progressif de couleur. Les couleurs dégradées, lorsqu'elles sont utilisées comme fonds pour les diapositives, rendent les présentations plus artistiques et professionnelles. Aspose.Slides vous permet de définir une couleur dégradée comme fond pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) pour le fond de la diapositive maître sur `Gradient`.
4. Utilisez la propriété [GradientFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/gradientformat/) exposée par [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour spécifier vos paramètres de dégradé préférés.
5. Enregistrez la présentation modifiée.

Ce code C# vous montre comment définir une couleur dégradée comme fond pour une diapositive :

```c#
// Crée une instance de la classe Presentation
using (Presentation pres = new Presentation("SetBackgroundToGradient.pptx"))
{

    // Applique un effet de dégradé au fond
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Gradient;
    pres.Slides[0].Background.FillFormat.GradientFormat.TileFlip = TileFlip.FlipBoth;

    // Écrit la présentation sur le disque
    pres.Save("ContentBG_Grad_out.pptx", SaveFormat.Pptx);
}
```

## **Définir une image comme fond pour une diapositive**

En plus des couleurs unies et des couleurs dégradées, Aspose.Slides vous permet également de définir des images comme fond pour les diapositives dans les présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Définissez l'énumération [BackgroundType](https://reference.aspose.com/slides/net/aspose.slides/backgroundtype/) pour la diapositive sur `OwnBackground`.
3. Définissez l'énumération [FillType](https://reference.aspose.com/slides/net/aspose.slides/filltype/) pour le fond de la diapositive maître sur `Picture`.
4. Chargez l'image que vous souhaitez utiliser comme fond de diapositive.
5. Ajoutez l'image à la collection d'images de la présentation.
6. Utilisez la propriété [PictureFillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/picturefillformat/) exposée par [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/fillformat/) pour définir l'image comme fond.
7. Enregistrez la présentation modifiée.

Ce code C# vous montre comment définir une image comme fond pour une diapositive :

```c#
// Crée une instance de la classe Presentation
using (Presentation pres = new Presentation("SetImageAsBackground.pptx"))
{
    // Définit les conditions pour l'image de fond
    pres.Slides[0].Background.Type = BackgroundType.OwnBackground;
    pres.Slides[0].Background.FillFormat.FillType = FillType.Picture;
    pres.Slides[0].Background.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;

    // Charge une image et l'ajoute à la collection d'images de la présentation
    IImage image = Images.FromFile("Tulips.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    pres.Slides[0].Background.FillFormat.PictureFillFormat.Picture.Image = ppImage;

    // Écrit la présentation sur le disque
    pres.Save("ContentBG_Img_out.pptx", SaveFormat.Pptx);
}
```

### **Changer la transparence de l'image de fond**

Vous pouvez souhaiter ajuster la transparence de l'image de fond d'une diapositive pour que le contenu de la diapositive se détache. Ce code C# vous montre comment changer la transparence pour une image de fond de diapositive :

```c#
var transparencyValue = 30; // par exemple

// Obtient une collection d'opérations de transformation d'image
var imageTransform = slide.Background.FillFormat.PictureFillFormat.Picture.ImageTransform;

// Trouve un effet de transparence avec un pourcentage fixe.
var transparencyOperation = null as AlphaModulateFixed;
foreach (var operation in imageTransform)
{
    if (operation is AlphaModulateFixed alphaModulateFixed)
    {
        transparencyOperation = alphaModulateFixed;
        break;
    }
}

// Définit la nouvelle valeur de transparence.
if (transparencyOperation == null)
{
    imageTransform.AddAlphaModulateFixedEffect(100 - transparencyValue);
}
else
{
    transparencyOperation.Amount = (100 - transparencyValue);
}
```

## **Obtenir la valeur de fond de la diapositive**

Aspose.Slides fournit l'interface [IBackgroundEffectiveData](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/) pour vous permettre d'obtenir les valeurs effectives des fonds de diapositives. Cette interface contient des informations sur le [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/fillformat) effectif et sur le [EffectFormat](https://reference.aspose.com/slides/net/aspose.slides/ibackgroundeffectivedata/effectformat/).

En utilisant la propriété [Background](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/background/) de la classe [BaseSlide](https://reference.aspose.com/slides/net/aspose.slides/baseslide/), vous pouvez obtenir la valeur effective pour un fond de diapositive.

Ce code C# vous montre comment obtenir la valeur effective du fond d'une diapositive :

```c#
// Crée une instance de la classe Presentation
Presentation pres = new Presentation("SamplePresentation.pptx");

IBackgroundEffectiveData effBackground = pres.Slides[0].Background.GetEffective();

if (effBackground.FillFormat.FillType == FillType.Solid)
    Console.WriteLine("Couleur de remplissage : " + effBackground.FillFormat.SolidFillColor);
else
    Console.WriteLine("Type de remplissage : " + effBackground.FillFormat.FillType);
```