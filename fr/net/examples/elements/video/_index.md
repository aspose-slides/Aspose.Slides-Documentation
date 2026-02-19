---
title: Vidéo
type: docs
weight: 80
url: /fr/net/examples/elements/video/
keywords:
- vidéo
- cadre vidéo
- ajouter vidéo
- accès vidéo
- supprimer vidéo
- lecture vidéo
- exemple de code
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Ajouter et contrôler des vidéos avec Aspose.Slides for .NET : insérer, lire, couper, définir des images d'affichage, et exporter avec des exemples C# pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment intégrer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for .NET**.

## **Ajouter un cadre vidéo**

Insérez un cadre vidéo vide sur une diapositive.

```csharp
static void AddVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    // Ajouter une vidéo.
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```

## **Accéder à un cadre vidéo**

Récupérez le premier cadre vidéo ajouté à une diapositive.

```csharp
static void AccessVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Accéder au premier cadre vidéo sur la diapositive.
    var firstVideo = slide.Shapes.OfType<IVideoFrame>().First();
}
```

## **Supprimer un cadre vidéo**

Supprimez un cadre vidéo de la diapositive.

```csharp
static void RemoveVideo()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Supprimer le cadre vidéo.
    slide.Shapes.Remove(videoFrame);
}
```

## **Définir la lecture vidéo**

Configurez la vidéo pour qu'elle se lance automatiquement lorsque la diapositive est affichée.

```csharp
static void SetVideoPlayback()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configurer la vidéo pour qu'elle se lance automatiquement.
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```