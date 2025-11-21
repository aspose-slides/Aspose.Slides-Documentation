---
title: Audio
type: docs
weight: 70
url: /fr/net/examples/elements/audio/
keywords:
- exemple audio
- cadre audio
- ajouter audio
- accéder à l'audio
- supprimer audio
- lecture audio
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec l'audio en C# avec Aspose.Slides : ajoutez, remplacez, extrayez et coupez les sons, définissez le volume et la lecture pour les diapositives et les formes dans PowerPoint et OpenDocument."
---

Illustre comment intégrer des cadres audio et contrôler la lecture avec **Aspose.Slides for .NET**. Les exemples suivants montrent des opérations audio de base.

## Ajouter un cadre audio

Insérez un cadre audio vide qui pourra plus tard contenir des données sonores incorporées.
```csharp
static void Add_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Créer un cadre audio vide (l'audio sera intégré plus tard)
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());
}
```


## Accéder à un cadre audio

Ce code récupère le premier cadre audio d’une diapositive.
```csharp
static void Access_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Accéder au premier cadre audio de la diapositive
    var firstAudio = slide.Shapes.OfType<IAudioFrame>().First();
}
```


## Supprimer un cadre audio

Supprimez un cadre audio ajouté précédemment.
```csharp
static void Remove_Audio()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Supprimer le cadre audio
    slide.Shapes.Remove(audioFrame);
}
```


## Définir la lecture audio

Configurez le cadre audio pour qu’il se lance automatiquement lorsque la diapositive apparaît.
```csharp
static void Set_Audio_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, new MemoryStream());

    // Lire automatiquement lorsque la diapositive apparaît
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
}
```
