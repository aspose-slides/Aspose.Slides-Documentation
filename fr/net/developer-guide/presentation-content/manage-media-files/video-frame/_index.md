---
title: Gérer les images vidéo dans les présentations en .NET
linktitle: Image vidéo
type: docs
weight: 10
url: /fr/net/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
- extraire une vidéo
- récupérer une vidéo
- image vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et extraire programatiquement des images vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour .NET. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et captiver un public. Aspose.Slides for .NET vous permet d’ajouter des images vidéo aux diapositives, d’ajuster les paramètres de lecture, de gérer les sous‑titres et d’extraire les données vidéo embarquées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, comme les vidéos YouTube.

Pour représenter les données vidéo et les images vidéo, Aspose.Slides propose les interfaces [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) et d’autres types pertinents.

## **Create an Embedded Video Frame**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer une image vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d’une présentation existante et enregistre le résultat. Les coordonnées et les dimensions de l’image sont exprimées en points. Le flux reste ouvert jusqu’à la fin de l’enregistrement car [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) le maintient verrouillé pendant que la présentation l’utilise.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");
var slide = presentation.Slides[0];

using var videoStream = File.OpenRead("video.mp4");
var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.KeepLocked);
slide.Shapes.AddVideoFrame(10, 10, 150, 250, video);

presentation.Save("embedded_video.pptx", SaveFormat.Pptx);
```

Vous pouvez également passer le chemin d’une vidéo locale directement à [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Cet exemple intègre la vidéo sur la première diapositive d’une nouvelle présentation. La vidéo doit rester accessible jusqu’à ce que la présentation soit enregistrée.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Create a Video Frame with Video from a Web Source**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer une image vidéo qui lie à une vidéo en ligne, comme une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et une miniature à la première diapositive. Remplacez l’identifiant de la vidéo pour en utiliser une autre. Le paramètre [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

```csharp
using System.Net.Http;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var httpClient = new HttpClient();

var videoId = "aqz-KE-bpKQ";
var videoUrl = $"https://www.youtube.com/embed/{videoId}";
var videoFrame = slide.Shapes.AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame.PlayMode = VideoPlayModePreset.Auto;

var thumbnailUrl = $"https://img.youtube.com/vi/{videoId}/hqdefault.jpg";
var thumbnailData = httpClient.GetByteArrayAsync(thumbnailUrl).GetAwaiter().GetResult();
var thumbnail = presentation.Images.AddImage(thumbnailData);
videoFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("online_video.pptx", SaveFormat.Pptx);
```

## **Play a Video in Full-Screen Mode**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public puisse voir les détails. Définissez [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) à `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sur la première diapositive et active la lecture en plein écran. La présentation d’entrée doit contenir au moins une diapositive avec une image vidéo existante sur la première diapositive.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.FullScreenMode = true;
        break;
    }
}

presentation.Save("full_screen_video.pptx", SaveFormat.Pptx);
```

La lecture en plein écran contrôle la façon dont la vidéo est affichée. Indépendamment, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) détermine si elle démarre automatiquement ou au clic, et [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) indique si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). L’exemple préserve les paramètres de démarrage et de boucle existants.

## **Rewind a Video After Playback**

Dans une présentation de formation, ramener une vidéo de démonstration à son début la rend prête à être rejouée par le présentateur. Définissez [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) à `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sur la première diapositive et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et définit le démarrage de la lecture au clic. La présentation d’entrée doit contenir au moins une diapositive avec une image vidéo existante sur la première diapositive.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("training.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        videoFrame.RewindVideo = true;
        videoFrame.PlayLoopMode = false;
        videoFrame.PlayMode = VideoPlayModePreset.OnClick;
        break;
    }
}

presentation.Save("rewind_video.pptx", SaveFormat.Pptx);
```

Le rembobinage ramène la vidéo à son début sans la relancer. En revanche, activer [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous souhaitez que la vidéo se termine et reste prête à être rejouée. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) contrôle indépendamment le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) afin que le présentateur décide du moment où la lecture commence. Définissez le mode de lecture après le paramètre de boucle, comme le montre l’exemple. Le rembobinage fonctionne indépendamment de [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Trim a Video Frame**

Utilisez [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) et [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) pour ignorer une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans modifier les données vidéo embarquées.

**Set Trim Settings**

Cet exemple intègre une vidéo locale et saute les 2,5 secondes initiales ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu’un segment lisible reste.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);
videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Read Trim Settings**

Cet exemple affiche les valeurs de rognage de la première image vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive n’a aucune image vidéo, rien n’est affiché. L’exemple précédent génère les valeurs 2500 et 1000.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("video_with_trim.pptx");
var slide = presentation.Slides[0];

foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        Console.WriteLine($"Trim from start: {videoFrame.TrimFromStart} ms");
        Console.WriteLine($"Trim from end: {videoFrame.TrimFromEnd} ms");
        break;
    }
}
```

## **Manage Video Captions**

Aspose.Slides vous permet de gérer les sous‑titres masqués pour les images vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont exposés via la propriété [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Add Captions to a Video Frame**

Cet exemple intègre une vidéo locale et ajoute une piste de sous‑titres WebVTT intitulée English. Les horodatages des sous‑titres doivent correspondre à la vidéo. La présentation enregistrée comprend à la fois la vidéo et ses sous‑titres.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);
videoFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
```

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres à partir d’un flux.

**Extract Captions from a Video Frame**

Cet exemple enregistre toutes les pistes de sous‑titres des images vidéo de la première diapositive en fichiers WebVTT séparés. Des numéros séquentiels permettent de distinguer les fichiers de sortie. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var trackCount = 0;
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        foreach (var captionTrack in videoFrame.CaptionTracks)
        {
            trackCount++;
            var outputPath = $"captions_{trackCount}.vtt";
            File.WriteAllBytes(outputPath, captionTrack.BinaryData);
        }
    }
}

Console.WriteLine($"Caption tracks extracted: {trackCount}");
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Remove Captions from a Video Frame**

Cet exemple supprime tous les sous‑titres de l’image vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est une image vidéo.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("video_with_captions.pptx");
var slide = presentation.Slides[0];

var videoFrame = (IVideoFrame) slide.Shapes[0];
videoFrame.CaptionTracks.Clear();

presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
```

Si vous devez supprimer uniquement une piste de sous‑titres, utilisez les méthodes [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) au lieu de [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Extract Video from a Slide**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos incorporées dans les présentations.

Cet exemple extrait les vidéos incorporées de chaque diapositive dans des fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne contiennent pas de données incorporées. La console affiche le type MIME de chaque vidéo ainsi que le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média rapporté si nécessaire.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_videos.pptx");

var videoCount = 0;
foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            var video = videoFrame.EmbeddedVideo;
            if (video == null)
            {
                Console.WriteLine("Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            var outputPath = $"extracted_video_{videoCount}.bin";
            File.WriteAllBytes(outputPath, video.BinaryData);
            Console.WriteLine($"Video {videoCount}: {video.ContentType}");
        }
    }
}

Console.WriteLine($"Embedded videos extracted: {videoCount}");
```

## **FAQ**

**Which video playback parameters can be changed for a video frame?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto ou au clic) et le [bouclage](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**Does adding a video affect the PPTX file size?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait croître la taille de la présentation proportionnellement à la taille du fichier. Lorsque vous liez à une vidéo en ligne et ajoutez une miniature, la présentation stocke le lien et l’image d’aperçu plutôt que les données vidéo, ainsi l’augmentation de taille est généralement moindre.

**Can I replace the video in an existing video frame without changing its position and size?**

Oui. Vous pouvez échanger le [video content](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) à l’intérieur de l’image tout en conservant la géométrie de la forme ; c’est un cas d’usage courant pour mettre à jour les médias dans une mise en page existante.

**Can the content type (MIME) of an embedded video be determined?**

Oui. Une vidéo incorporée possède un [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que vous pouvez lire et utiliser, par exemple lors de l’enregistrement sur disque.