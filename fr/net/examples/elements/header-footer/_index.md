---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/net/examples/elements/elements/header-footer/
keywords:
- exemple d'en-tête et pied de page
- ajouter en-tête et pied de page
- mettre à jour en-tête et pied de page
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page en C# avec Aspose.Slides : ajoutez ou modifiez la date/heure, les numéros de diapositive et le texte du pied de page, affichez ou masquez les espaces réservés dans PPT, PPTX et ODP."
---

Montre comment ajouter des pieds de page et mettre à jour les espaces réservés de date et d'heure en utilisant **Aspose.Slides for .NET**.

## Ajouter un pied de page

Ajoutez du texte à la zone de pied de page d’une diapositive et rendez-le visible.
```csharp
static void Add_Header_Footer()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.HeaderFooterManager.SetFooterText("My footer");
    slide.HeaderFooterManager.SetFooterVisibility(isVisible: true);
}
```


## Mettre à jour la date et l'heure

Modifiez l’espace réservé de date et d'heure sur une diapositive.
```csharp
static void Update_Date_Time()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.HeaderFooterManager.SetDateTimeText("01/01/2024");
    slide.HeaderFooterManager.SetDateTimeVisibility(isVisible: true);
}
```
