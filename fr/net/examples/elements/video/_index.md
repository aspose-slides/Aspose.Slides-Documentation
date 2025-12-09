---
title: Vidéo
type: docs
weight: 80
url: /fr/net/examples/elements/video/
keywords:
- exemple de vidéo
- cadre vidéo
- ajouter vidéo
- accéder à la vidéo
- supprimer vidéo
- lecture vidéo
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travailler avec la vidéo en C# avec Aspose.Slides: insérer, remplacer, couper, définir les images d'affiche et les options de lecture, et exporter les présentations aux formats PPT, PPTX et ODP."
---

Montre comment intégrer des cadres vidéo et définir les options de lecture à l’aide de **Aspose.Slides for .NET**.

## Ajouter un cadre vidéo

Insérer un cadre vidéo vide sur une diapositive.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Ajouter un cadre vidéo intégré vide
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## Accéder à un cadre vidéo

Récupérer le premier cadre vidéo ajouté à une diapositive.
```csharp
static void Access_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Accéder au premier cadre vidéo sur la diapositive
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```


## Supprimer un cadre vidéo

Supprimer un cadre vidéo de la diapositive.
```csharp
static void Remove_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Supprimer le cadre vidéo
    slide.Shapes.Remove(videoFrame);
}
```


## Définir la lecture vidéo

Configurer la vidéo pour qu’elle se lance automatiquement lorsque la diapositive est affichée.
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configurer la vidéo pour qu'elle se lance automatiquement
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
