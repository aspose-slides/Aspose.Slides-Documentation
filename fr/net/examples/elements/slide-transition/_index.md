---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/net/examples/elements/slide-transition/
keywords:
- exemple de transition de diapositive
- ajouter une transition de diapositive
- accéder à une transition de diapositive
- supprimer une transition de diapositive
- durée de la transition
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Contrôlez les transitions de diapositive en C# avec Aspose.Slides : choisissez les types, la vitesse, le son et le minutage pour peaufiner les présentations dans PPT, PPTX et ODP."
---

Démontre l'application des effets de transition de diapositive et des minutages avec **Aspose.Slides for .NET**.

## Ajouter une transition de diapositive

Appliquez un effet de transition en fondu à la première diapositive.
```csharp
static void Add_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Appliquer une transition en fondu
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```


## Accéder à une transition de diapositive

Lisez le type de transition actuellement assigné à une diapositive.
```csharp
static void Access_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Push;

    // Accéder au type de transition
    var type = slide.SlideShowTransition.Type;
}
```


## Supprimer une transition de diapositive

Supprimez tout effet de transition en définissant le type sur `None`.
```csharp
static void Remove_Slide_Transition()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Supprimer la transition en définissant None
    slide.SlideShowTransition.Type = TransitionType.None;
}
```


## Définir la durée de la transition

Spécifiez la durée pendant laquelle la diapositive est affichée avant de passer automatiquement à la suivante.
```csharp
static void Set_Transition_Duration()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // en millisecondes
}
```
