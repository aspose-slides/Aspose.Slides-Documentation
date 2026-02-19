---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/net/examples/elements/header-footer/
keywords:
- en-tête et pied de page
- ajouter en-tête et pied de page
- mettre à jour en-tête et pied de page
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page des diapositives avec Aspose.Slides pour .NET: ajoutez des dates, des numéros de diapositive et du texte personnalisé dans PPT, PPTX et ODP avec des exemples C#."
---
Cet article montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d'heure en utilisant **Aspose.Slides for .NET**.

## **Ajouter un pied de page**
Ajoutez du texte dans la zone de pied de page d'une diapositive et rendez-le visible.

```csharp
static void AddHeaderFooter()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```

## **Mettre à jour la date et l'heure**
Modifiez l'espace réservé de date et d'heure sur une diapositive.

```csharp
static void UpdateDateTime()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```