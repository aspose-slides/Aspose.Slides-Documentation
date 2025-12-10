---
title: Vidéo
type: docs
weight: 80
url: /fr/net/examples/elements/video/
keywords:
- exemple de vidéo
- cadre vidéo
- ajouter une vidéo
- accéder à la vidéo
- supprimer la vidéo
- lecture vidéo
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Travaillez avec la vidéo en C# utilisant Aspose.Slides : insérez, remplacez, coupez, définissez les images d’affiche et les options de lecture, et exportez les présentations aux formats PPT, PPTX et ODP."
---

Présente comment incorporer des cadres vidéo et définir les options de lecture en utilisant **Aspose.Slides for .NET**.

## **Ajouter un cadre vidéo**

Insérez un cadre vidéo vide sur une diapositive.
```csharp
static void Add_Video()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];

    // Ajouter un cadre vidéo intégré vide
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");
}
```


## **Accéder à un cadre vidéo**

Récupérez le premier cadre vidéo ajouté à une diapositive.
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


## **Supprimer un cadre vidéo**

Supprimez un cadre vidéo de la diapositive.
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


## **Définir la lecture vidéo**

Configurez la vidéo pour qu'elle se lise automatiquement lorsque la diapositive est affichée.
```csharp
static void Set_Video_Playback()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 320, 240, "video.mp4");

    // Configurer la vidéo pour qu'elle se lise automatiquement
    videoFrame.PlayMode = VideoPlayModePreset.Auto;
}
```
