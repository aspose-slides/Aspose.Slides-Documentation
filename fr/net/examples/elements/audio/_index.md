---
title: Audio
type: docs
weight: 70
url: /fr/net/examples/elements/audio/
keywords:
- audio
- cadre audio
- ajouter audio
- accéder à l'audio
- supprimer audio
- lecture audio
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez les exemples audio d'Aspose.Slides pour .NET : insertion, lecture, découpage et extraction du son dans les présentations PPT, PPTX et ODP avec du code C# clair."
---
Cet article montre comment intégrer des cadres audio et contrôler la lecture avec **Aspose.Slides for .NET**. Les exemples suivants illustrent les opérations audio de base.

## **Ajouter un cadre audio**

Insérez un cadre audio vide pouvant contenir ultérieurement des données sonores intégrées.

```csharp
static void AddAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Créer un cadre audio vide (le son sera intégré plus tard).
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```

## **Accéder à un cadre audio**

Ce code récupère le premier cadre audio d’une diapositive.

```csharp
static void AccessAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Accéder au premier cadre audio sur la diapositive.
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```

## **Supprimer un cadre audio**

Supprimez un cadre audio précédemment ajouté.

```csharp
static void RemoveAudio()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Supprimer le cadre audio.
    slide.Shapes.Remove(audioFrame);
}
```

## **Définir la lecture audio**

Configurez le cadre audio pour qu’il se lance automatiquement lorsque la diapositive apparaît.

```csharp
static void SetAudioPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Lire automatiquement lorsque la diapositive apparaît.
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```