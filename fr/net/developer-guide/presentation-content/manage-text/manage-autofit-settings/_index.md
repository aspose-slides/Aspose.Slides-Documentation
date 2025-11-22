---
title: "Améliorez vos présentations avec AutoFit en C#"
linktitle: "Gérer les paramètres AutoFit"
type: docs
weight: 30
url: /fr/net/manage-autofit-settings/
keywords:
- "zone de texte"
- "ajustement automatique"
- "ne pas ajuster automatiquement"
- "adapter le texte"
- "réduire le texte"
- "enrouler le texte"
- "redimensionner la forme"
- "PowerPoint"
- "présentation"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "Apprenez à gérer les paramètres AutoFit dans Aspose.Slides pour .NET afin d'optimiser l'affichage du texte dans vos présentations PowerPoint et OpenDocument et d'améliorer la lisibilité du contenu."
---

## **Vue d'ensemble**

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le paramètre **Redimensionner la forme pour faire tenir le texte** — il redimensionne automatiquement la zone de texte afin que son texte y tienne toujours.

![Une zone de texte dans PowerPoint](textbox-in-powerpoint.png)

* Lorsque le texte de la zone de texte devient plus long ou plus gros, PowerPoint agrandit automatiquement la zone de texte—en augmentant sa hauteur—pour lui permettre de contenir plus de texte.  
* Lorsque le texte de la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte—en diminuant sa hauteur—pour éliminer l’espace redondant.

Dans PowerPoint, voici les quatre paramètres ou options importants qui contrôlent le comportement d’ajustement automatique d’une zone de texte :

* **Ne pas ajuster automatiquement**
* **Réduire le texte en cas de dépassement**
* **Redimensionner la forme pour faire tenir le texte**
* **Enrouler le texte dans la forme**

![Options d’ajustement automatique dans PowerPoint](autofit-options-powerpoint.png)

Aspose.Slides for .NET propose des options similaires—des propriétés de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)—qui vous permettent de contrôler le comportement d’ajustement automatique des zones de texte dans les présentations.

## **Redimensionner la forme pour faire tenir le texte**

Si vous souhaitez que le texte d’une zone tienne toujours dans celle‑ci après des modifications du texte, vous devez utiliser l’option **Redimensionner la forme pour faire tenir le texte**. Pour définir ce paramètre, affectez la propriété `AutofitType` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) à `Shape`.

![Redimensionner la forme pour faire tenir le texte](alwaysfit-setting-powerpoint.png)

Ce code C# montre comment spécifier que le texte doit toujours tenir dans sa zone dans une présentation PowerPoint :
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


Si le texte devient plus long ou plus gros, la zone de texte sera automatiquement redimensionnée (hauteur augmentée) afin que tout le texte y tienne. Si le texte devient plus court, l’inverse se produit.

## **Ne pas ajuster automatiquement**

Si vous souhaitez qu’une zone de texte ou une forme conserve ses dimensions quel que soit le texte qu’elle contient, vous devez utiliser l’option **Ne pas ajuster automatiquement**. Pour définir ce paramètre, affectez la propriété `AutofitType` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) à `None`.

!["Ne pas ajuster automatiquement" paramètre dans PowerPoint](donotautofit-setting-powerpoint.png)

Ce code C# montre comment spécifier qu’une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :
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


Lorsque le texte devient trop long pour sa zone, il déborde.

## **Réduire le texte en cas de dépassement**

Si le texte devient trop long pour sa zone, l’option **Réduire le texte en cas de dépassement** vous permet de spécifier que la taille et l’interligne du texte doivent être diminués afin qu’il tienne dans sa zone. Pour définir ce paramètre, affectez la propriété `AutofitType` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) à `Normal`.

!["Réduire le texte en cas de dépassement" paramètre dans PowerPoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code C# montre comment spécifier que le texte doit être réduit en cas de dépassement dans une présentation PowerPoint :
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
Lorsque l’option **Réduire le texte en cas de dépassement** est utilisée, le réglage n’est appliqué que lorsque le texte devient trop long pour sa zone.
{{% /alert %}}

## **Enrouler le texte**

Si vous voulez que le texte dans une forme soit renvoyé à l’intérieur de cette forme lorsque le texte dépasse la bordure de la forme (largeur uniquement), vous devez utiliser le paramètre **Enrouler le texte dans la forme**. Pour définir ce paramètre, affectez la propriété `WrapText` de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) à `NullableBool.True`.

Ce code C# montre comment utiliser le réglage Enrouler le texte dans une présentation PowerPoint :
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

**Les marges internes du cadre de texte affectent-elles l’ajustement automatique ?**

Oui. Le remplissage (marges internes) réduit la zone utilisable pour le texte, de sorte que l’ajustement automatique se déclenche plus tôt — il réduit la police ou redimensionne la forme plus rapidement. Vérifiez et ajustez les marges avant de peaufiner l’ajustement automatique.

**Comment l’ajustement automatique interagit‑il avec les sauts de ligne manuels et souples ?**

Les sauts imposés restent en place, et l’ajustement automatique adapte la taille de la police et l’interligne autour d’eux. Supprimer les sauts inutiles réduit souvent l’intensité avec laquelle l’ajustement automatique doit réduire le texte.

**Le changement de police du thème ou le déclenchement d’une substitution de police affecte‑t‑il les résultats de l’ajustement automatique ?**

Oui. La substitution par une police dont les métriques diffèrent modifie la largeur/hauteur du texte, ce qui peut changer la taille finale de la police et le retour à la ligne. Après toute modification ou substitution de police, revérifiez les diapositives.