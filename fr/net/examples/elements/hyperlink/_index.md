---
title: Hyperlien
type: docs
weight: 130
url: /fr/net/examples/elements/hyperlink/
keywords:
- exemple d'hyperlien
- ajouter un hyperlien
- accéder à un hyperlien
- supprimer un hyperlien
- mettre à jour un hyperlien
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajouter, modifier et supprimer des hyperliens en C# avec Aspose.Slides: texte du lien, formes, diapositives, URL et e-mail; définir les cibles et les actions pour PPT, PPTX et ODP."
---

Démontre l'ajout, l'accès, la suppression et la mise à jour des hyperliens sur les formes à l'aide de **Aspose.Slides for .NET**.

## **Ajouter un hyperlien**

Créez une forme rectangulaire avec un hyperlien pointant vers un site Web externe.
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## **Accéder à un hyperlien**

Lisez les informations d'hyperlien à partir de la portion de texte d'une forme.
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## **Supprimer un hyperlien**

Effacez l'hyperlien du texte d'une forme.
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## **Mettre à jour un hyperlien**

Modifiez la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte contenant déjà un hyperlien, ce qui reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Modifier un hyperlien dans le texte existant doit être effectué via
    // HyperlinkManager plutôt que de définir la propriété directement.
    // Cela reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
