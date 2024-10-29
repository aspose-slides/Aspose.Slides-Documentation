---
title: Gérer les paramètres d'Autoajustement
type: docs
weight: 30
url: /fr/net/manage-autofit-settings/
keywords: "Zone de texte, Autoajustement, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Définir les paramètres d'autoajustement pour la zone de texte dans PowerPoint en C# ou .NET"
---

Par défaut, lorsque vous ajoutez une zone de texte, Microsoft PowerPoint utilise le réglage **Redimensionner la forme pour ajuster le texte** pour la zone de texte : elle redimensionne automatiquement la zone de texte pour s'assurer que son texte y tient toujours.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Lorsque le texte dans la zone de texte devient plus long ou plus grand, PowerPoint agrandit automatiquement la zone de texte - augmente sa hauteur - pour lui permettre de contenir plus de texte.
* Lorsque le texte dans la zone de texte devient plus court ou plus petit, PowerPoint réduit automatiquement la zone de texte - diminue sa hauteur - pour supprimer l'espace inutile.

Dans PowerPoint, il y a 4 paramètres ou options importants qui contrôlent le comportement d'autoajustement pour une zone de texte :

* **Ne pas autoajuster**
* **Réduire le texte en cas de débordement**
* **Redimensionner la forme pour ajuster le texte**
* **Envelopper le texte dans la forme.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides pour .NET offre des options similaires - certaines propriétés sous la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat) - qui vous permettent de contrôler le comportement d'autoajustement pour les zones de texte dans les présentations.

## **Redimensionner la Forme pour Ajuster le Texte**

Si vous souhaitez que le texte dans une boîte s'ajuste toujours dans cette boîte après des modifications apportées au texte, vous devez utiliser l'option **Redimensionner la forme pour ajuster le texte**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) sur `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Ce code C# vous montre comment spécifier qu'un texte doit toujours s'ajuster dans sa boîte dans une présentation PowerPoint :

```c#
 using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Shape;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Si le texte devient plus long ou plus grand, la zone de texte sera automatiquement redimensionnée (augmentation de la hauteur) pour garantir que tout le texte y tienne. Si le texte devient plus court, l'inverse se produit.

## **Ne Pas Autoajuster**

Si vous souhaitez qu'une zone de texte ou une forme conserve ses dimensions, peu importe les modifications apportées au texte qu'elle contient, vous devez utiliser l'option **Ne pas autoajuster**. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) sur `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Ce code C# vous montre comment spécifier qu'une zone de texte doit toujours conserver ses dimensions dans une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.None;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

Lorsque le texte devient trop long pour sa boîte, il déborde.

## **Réduire le Texte en Cas de Débordement**

Si un texte devient trop long pour sa boîte, grâce à l'option **Réduire le texte en cas de débordement**, vous pouvez spécifier que la taille et l'espacement du texte doivent être réduits pour s'adapter dans sa boîte. Pour spécifier ce réglage, définissez la propriété [AutofitType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/autofittype) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) sur `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Ce code C# vous montre comment spécifier qu'un texte doit être réduit en cas de débordement dans une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.AutofitType = TextAutofitType.Normal;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Info" color="info" %}}

Lorsque l'option **Réduire le texte en cas de débordement** est utilisée, le réglage ne s'applique que lorsque le texte devient trop long pour sa boîte.

{{% /alert %}}

## **Envelopper le Texte**

Si vous souhaitez que le texte dans une forme soit enveloppé à l'intérieur de cette forme lorsque le texte dépasse la bordure de la forme (uniquement en largeur), vous devez utiliser le paramètre **Envelopper le texte dans la forme**. Pour spécifier ce réglage, vous devez définir la propriété [WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/properties/wraptext) (de la classe [TextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/textframeformat)) sur `true`.

Ce code C# vous montre comment utiliser le réglage d'enveloppement de texte dans une présentation PowerPoint :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    portion.PortionFormat.FillFormat.FillType = FillType.Solid;
    autoShape.TextFrame.Paragraphs[0].Portions.Add(portion);

    ITextFrameFormat textFrameFormat = autoShape.TextFrame.TextFrameFormat;
    textFrameFormat.WrapText = NullableBool.True;

    pres.Save("Output-presentation.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}

Si vous définissez la propriété `WrapText` sur `False` pour une forme, lorsque le texte à l'intérieur de la forme devient plus long que la largeur de la forme, le texte s'étend au-delà des bordures de la forme sur une seule ligne.

{{% /alert %}}