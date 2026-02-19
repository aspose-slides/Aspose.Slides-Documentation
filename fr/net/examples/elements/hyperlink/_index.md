---
title: Hyperlien
type: docs
weight: 130
url: /fr/net/examples/elements/hyperlink/
keywords:
- hyperlien
- ajouter un hyperlien
- accéder à un hyperlien
- supprimer un hyperlien
- mettre à jour un hyperlien
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajouter et gérer des hyperliens dans Aspose.Slides for .NET: texte de lien, formes et images, définir les cibles et les actions pour PPT, PPTX et ODP avec des exemples C#."
---
Cet article montre comment ajouter, accéder, supprimer et mettre à jour des hyperliens sur des formes en utilisant **Aspose.Slides for .NET**.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site Web externe.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Accéder à un hyperlien**

Lisez les informations d'hyperlien à partir de la partie texte d'une forme.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Supprimer un hyperlien**

Supprimez l'hyperlien du texte d'une forme.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte qui contient déjà un hyperlien, ce qui reproduit la façon dont PowerPoint met à jour les hyperliens de manière sûre.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Modifier un hyperlien dans du texte existant doit être effectué via
    // HyperlinkManager plutôt que de définir la propriété directement.
    // Cela reproduit la façon dont PowerPoint met à jour les hyperliens de manière sécurisée.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```