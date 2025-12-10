---
title: Améliorez vos présentations avec AutoFit en .NET
linktitle: Paramètres Autofit
type: docs
weight: 30
url: /fr/net/manage-autofit-settings/
keywords:
- zone de texte
- autofit
- ne pas autofit
- adapter le texte
- réduire le texte
- envelopper le texte
- redimensionner la forme
- PowerPoint
- présentation
- C#
- .NET
- Aspose.Slides
description: "Apprenez à gérer les paramètres AutoFit dans Aspose.Slides pour .NET afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

## **Vue d'ensemble**

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Resize shape to fit text** pour la zone de texte — il redimensionne automatiquement la zone de texte afin de garantir que son texte y tienne toujours.

![Une zone de texte dans PowerPoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte—augmentant sa hauteur—pour lui permettre de contenir plus de texte.
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—diminuant sa hauteur—pour éliminer l'espace superflu.

Dans PowerPoint, voici les quatre paramètres ou options importants qui contrôlent le comportement d’autofit d’une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de dépassement**
* **Redimensionner la forme pour adapter le texte**
* **Envelopper le texte dans la forme**

![Options d’autofit dans PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET propose des options similaires—des propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—qui vous permettent de contrôler le comportement d’autofit des zones de texte dans les présentations.

## **Redimensionner une forme pour adapter le texte**

Si vous souhaitez que le texte d’une zone tienne toujours dans cette zone après des modifications, vous devez utiliser l’option **Resize shape to fit text**. Pour spécifier ce réglage, définissez la propriété `AutofitType` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) sur `Shape`.

![Redimensionner la forme pour adapter le texte](alwaysfit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (hauteur augmentée) afin de garantir que tout le texte y tienne. Si le texte devient plus court, le processus inverse se produit.

## **Ne pas autofit**

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quelles que soient les modifications du texte qu’elle contient, vous devez utiliser l’option **Do not Autofit**. Pour spécifier ce réglage, définissez la propriété `AutofitType` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) sur `None`.

![Paramètre "Do not Autofit" dans PowerPoint](donotautofit-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


Lorsque le texte devient trop long pour la zone, il déborde.

## **Réduire le texte en cas de dépassement**

Si le texte devient trop long pour la zone, grâce à l’option **Shrink text on overflow**, vous pouvez spécifier que la taille et l’espacement du texte doivent être réduits afin qu’il tienne dans la zone. Pour spécifier ce réglage, définissez la propriété `AutofitType` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) sur `Normal`.

![Paramètre "Shrink text on overflow" dans PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Info" color="info" %}}
Lorsque l’option **Shrink text on overflow** est utilisée, le réglage n’est appliqué que lorsque le texte devient trop long pour la zone.
{{% /alert %}}

## **Envelopper le texte**

Si vous voulez que le texte d’une forme soit enveloppé à l’intérieur de celle‑ci lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Wrap text in shape**. Pour spécifier ce réglage, vous devez définir la propriété `WrapText` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) sur `NullableBool.True`.

```c#
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    presentation.Save("output_presentation.pptx", SaveFormat.Pptx);
}
```


{{% alert title="Note" color="warning" %}}
Si vous définissez la propriété `WrapText` sur `NullableBool.False` pour une forme, lorsque le texte à l’intérieur de la forme devient plus long que la largeur de la forme, le texte dépasse les bordures de la forme sur une seule ligne.
{{% /alert %}}

## **FAQ**

**Les marges internes du cadre de texte affectent-elles AutoFit ?**

Oui. Le remplissage (marges internes) réduit la zone usable pour le texte, de sorte qu’AutoFit intervient plus tôt—en réduisant la police ou en redimensionnant la forme plus rapidement. Vérifiez et ajustez les marges avant d’ajuster AutoFit.

**Comment AutoFit interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts forcés restent en place, et AutoFit adapte la taille de la police et l’espacement autour d’eux. Supprimer les sauts inutiles réduit souvent l’agressivité avec laquelle AutoFit doit réduire le texte.

**Le changement de police du thème ou le déclenchement d’une substitution de police affecte‑t‑il les résultats d’AutoFit ?**

Oui. La substitution par une police aux métriques de glyphes différentes modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après tout changement ou substitution de police, revérifiez les diapositives.