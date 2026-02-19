---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/net/examples/elements/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- accéder à une transition de diapositive
- supprimer une transition de diapositive
- durée de la transition
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez les transitions de diapositive dans Aspose.Slides for .NET : ajoutez, personnalisez et séquencez les effets et les durées avec des exemples C# pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment appliquer des effets de transition de diapositive et des temporisations avec **Aspose.Slides for .NET**.

## **Ajouter une transition de diapositive**

Appliquez un effet de transition en fondu à la première diapositive.

```csharp
static void AddSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Appliquer une transition en fondu.
    slide.SlideShowTransition.Type = TransitionType.Fade;
}
```

## **Accéder à une transition de diapositive**

Lisez le type de transition actuellement attribué à une diapositive.

```csharp
static void AccessSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Push;

    // Accéder au type de transition.
    var type = slide.SlideShowTransition.Type;
}
```

## **Supprimer une transition de diapositive**

Effacez tout effet de transition en définissant le type sur `None`.

```csharp
static void RemoveSlideTransition()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.Type = TransitionType.Fade;

    // Supprimer la transition en définissant None.
    slide.SlideShowTransition.Type = TransitionType.None;
}
```

## **Définir la durée de la transition**

Spécifiez la durée pendant laquelle la diapositive est affichée avant de passer automatiquement à la suivante.

```csharp
static void SetTransitionDuration()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.SlideShowTransition.AdvanceOnClick = true;
    slide.SlideShowTransition.AdvanceAfterTime = 2000; // en millisecondes
}
```