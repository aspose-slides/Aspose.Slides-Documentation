---
title: Gérer les trames vidéo dans les présentations en .NET
linktitle: Trame vidéo
type: docs
weight: 10
url: /fr/net/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- trame vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des trames vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour .NET. Guide pratique rapide."
---
## **Introduction**

Les vidéos peuvent aider à expliquer des idées et à captiver un public. Aspose.Slides for .NET vous permet d’ajouter des trames vidéo aux diapositives, d’ajuster les paramètres de lecture, de gérer les sous-titres et d’extraire les données vidéo intégrées.

PowerPoint prend en charge les vidéos locales et les liens vers des vidéos en ligne, comme les vidéos YouTube.

Pour représenter les données vidéo et les trames vidéo, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) et [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/), ainsi que d’autres types pertinents.

## **Créer une trame vidéo intégrée**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer une trame vidéo pour intégrer la vidéo dans votre présentation.

Cet exemple intègre une vidéo locale sur la première diapositive d’une présentation existante et enregistre le résultat. Les coordonnées et les dimensions de la trame sont exprimées en points. Le flux reste ouvert jusqu’à la fin de l’enregistrement parce que [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) le maintient verrouillé pendant que la présentation l’utilise.

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

Vous pouvez également transmettre directement le chemin d’une vidéo locale à [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Cet exemple intègre la vidéo sur la première diapositive d’une nouvelle présentation. La vidéo doit rester accessible jusqu’à ce que la présentation soit enregistrée.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Définir le volume vidéo avec précision**

Dans Aspose.Slides for .NET 26.11 ou version ultérieure, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) définit un pourcentage à virgule flottante de 0 à 100. Utilisez‑le lorsque les préréglages [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) sont trop grossiers. Par exemple, `75.5f` demande un volume de 75,5 %.

Cet exemple nécessite [Aspose.Slides for .NET](/slides/fr/net/installation/) 26.11 ou version ultérieure et un fichier local `video.mp4`. Il intègre la vidéo, initialise explicitement la lecture, enregistre la présentation et lit le pourcentage stocké.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

var volume = 75.5f;
if (float.IsNaN(volume) || float.IsInfinity(volume) || volume < 0 || volume > 100)
{
    Console.WriteLine("Use a finite volume from 0 to 100.");
    return;
}

using (var presentation = new Presentation())
{
    var videoBytes = File.ReadAllBytes("video.mp4");
    var video = presentation.Videos.AddVideo(videoBytes);
    var frame = presentation.Slides[0].Shapes.AddVideoFrame(50, 50, 320, 180, video);
    frame.PlayMode = VideoPlayModePreset.Auto;
    frame.VolumeValue = volume;
    presentation.Save("video-volume.pptx", SaveFormat.Pptx);
}

using var saved = new Presentation("video-volume.pptx");
var savedFrame = saved.Slides[0].Shapes.OfType<IVideoFrame>().First();
Console.WriteLine(savedFrame.VolumeValue);
```

Validez vous‑même les entrées ; ne comptez pas sur le mutateur pour rejeter les valeurs hors de l’intervalle documenté. Les préréglages Low, Medium et Loud correspondent à 20, 50 et 80 dans la version 26.11. La définition d’un préréglage peut remplacer un pourcentage antérieur, il faut donc affecter le pourcentage en dernier lorsque vous avez besoin d’une valeur précise. Utilisez [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) pour le réglage de sourdine explicite ; zéro numérique et l’énumération de préréglage ne sont pas des états interchangeables.

Définissez explicitement [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) également lors de la configuration d’une vidéo liée, et maintenez son fichier média disponible pour le spectateur. Enregistrer puis rouvrir vérifie le paramètre stocké ; la lecture réelle et le niveau sonore dépendent du lecteur de présentation et de ses réglages audio.

## **Créer une trame vidéo à partir d’une source Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prend en charge les vidéos en ligne dans les présentations. Vous pouvez créer une trame vidéo qui lie une vidéo en ligne, par exemple une vidéo YouTube.

Cet exemple ajoute un lien vidéo YouTube et sa miniature à la première diapositive. Remplacez l’identifiant vidéo pour utiliser une autre vidéo. Le paramètre [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) demande une lecture automatique. Le téléchargement de la miniature et la lecture de la vidéo nécessitent un accès Internet. Le visualiseur de présentation doit également prendre en charge la lecture de vidéos en ligne.

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

## **Lire une vidéo en mode plein écran**

Dans une présentation de formation, vous pouvez lire une démonstration logicielle en mode plein écran afin que le public voie les détails. Réglez [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) sur `true` pour activer ce comportement pendant la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sur la première diapositive, et active la lecture en plein écran. La présentation d’entrée doit contenir au moins une diapositive avec une trame vidéo existante sur la première diapositive.

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

La lecture en plein écran contrôle la façon dont la vidéo est affichée. De façon indépendante, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) détermine si elle démarre automatiquement ou au clic, et [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) détermine si elle se répète. Pour choisir le comportement de démarrage, définissez le mode de lecture sur [VideoPlayModePreset.Auto ou VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). L’exemple préserve les paramètres de démarrage et de boucle existants.

## **Rembobiner une vidéo après la lecture**

Dans une présentation de formation, remettre une vidéo de démonstration au début la rend prête pour que le présentateur la relise. Réglez [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) sur `true` pour ramener la vidéo au début après la fin de la lecture.

Cet exemple ouvre une présentation, trouve le premier [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) sur la première diapositive, et active le rembobinage. Il désactive la boucle afin que la lecture puisse se terminer et règle la lecture pour démarrer au clic. La présentation d’entrée doit contenir au moins une diapositive avec une trame vidéo existante sur la première diapositive.

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

Le rembobinage ramène la vidéo au début sans la relancer. En revanche, activer [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) répète la lecture automatiquement. Gardez la boucle désactivée lorsque vous voulez que la vidéo se termine et reste prête à être relue. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) contrôle de façon indépendante le démarrage automatique ou au clic ; cet exemple utilise [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) afin que le présentateur contrôle le moment du démarrage. Définissez le mode de lecture après le paramètre de boucle, comme le montre l’exemple. Le rembobinage fonctionne indépendamment de [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Rogner une trame vidéo**

Utilisez [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) et [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) pour ignorer une partie du début ou de la fin d’une vidéo pendant la lecture. Les deux valeurs sont exprimées en millisecondes. Le rognage modifie les paramètres de lecture sans altérer les données vidéo intégrées.

**Définir les paramètres de rognage**

Cet exemple intègre une vidéo locale et ignore les 2,5 secondes initiales ainsi que la dernière seconde pendant la lecture. Utilisez une vidéo de plus de 3,5 secondes afin qu’un segment lisible subsiste.

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

**Lire les paramètres de rognage**

Cet exemple affiche les valeurs de rognage de la première trame vidéo sur la première diapositive en millisecondes. La présentation doit contenir au moins une diapositive. Si cette diapositive n’a pas de trame vidéo, rien n’est affiché. L’exemple précédent produit des valeurs de 2500 et 1000.

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

## **Gérer les sous-titres vidéo**

Aspose.Slides vous permet de gérer les sous-titres fermés pour les trames vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la propriété [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Ajouter des sous‑titres à une trame vidéo**

Cet exemple intègre une vidéo locale et ajoute une piste de sous‑titres WebVTT libellée English. Les horodatages des sous‑titres doivent correspondre à la vidéo. La présentation enregistrée inclut la vidéo et ses sous‑titres.

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

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) fournit également une surcharge permettant d’ajouter des sous‑titres depuis un flux.

### **Extraire les sous‑titres d’une trame vidéo**

Cet exemple enregistre toutes les pistes de sous‑titres des trames vidéo de la première diapositive sous forme de fichiers WebVTT séparés. Des numéros séquentiels différencient les fichiers de sortie. La console indique le nombre de pistes extraites. La présentation doit contenir au moins une diapositive.

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

### **Supprimer les sous‑titres d’une trame vidéo**

Cet exemple supprime tous les sous‑titres de la trame vidéo à la première position de forme sur la première diapositive et enregistre le résultat. Il suppose que la diapositive et la forme existent et que la forme est une trame vidéo.

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

### **Rechercher des sous‑titres vidéo**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) renvoie la piste WebVTT complète, incluant son en‑tête, les lignes de synchronisation et le texte du sous‑titre. Pour trouver une phrase prononcée et son horodatage, lisez les repères en mémoire. Par exemple, une piste English sur la diapositive 2 pourrait contenir le texte suivant :

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

L’exemple parcourt chaque diapositive et lit les pistes de ses trames vidéo de niveau supérieur via [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). Dans un repère en texte brut, la ligne de synchronisation contient `-->` et une ligne vide termine le repère. Lorsque le texte du sous‑titre contient « café », l’exemple affiche le numéro de diapositive, le libellé de la piste, la ligne de synchronisation originale et le sous‑titre complet.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("captioned_media.pptx");
foreach (var slide in presentation.Slides)
{
    var tracks = slide.Shapes.OfType<IVideoFrame>().SelectMany(frame => frame.CaptionTracks);
    foreach (var track in tracks)
    {
        using var reader = new StringReader(track.DataAsString);
        while (reader.ReadLine() is string timing)
        {
            if (!timing.Contains("-->")) continue;

            var lines = new List<string>();
            while (reader.ReadLine() is string line && line.Length > 0)
                lines.Add(line);

            var caption = string.Join(Environment.NewLine, lines);
            if (caption.Contains("café", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Slide {slide.SlideNumber} | {track.Label} | {timing}");
                Console.WriteLine(caption);
            }
        }
    }
}
```

La recherche de « café » produit une correspondance pour la piste d’exemple. L’en‑tête et le réglage de synchronisation sont en dehors du texte du repère.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extraire la vidéo d’une diapositive**

En plus d’ajouter des vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées dans les présentations.

Cet exemple extrait les vidéos intégrées de chaque diapositive dans des fichiers binaires séparés et numérotés. Les vidéos liées sont ignorées car elles ne possèdent pas de données intégrées. La console affiche le type MIME de chaque vidéo ainsi que le nombre total. La sortie utilise l’extension générique `.bin` ; modifiez‑la pour correspondre au type de média indiqué si nécessaire.

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

**Quels paramètres de lecture vidéo peuvent être modifiés pour une trame vidéo ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto ou au clic) et la [boucle](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte‑t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ce qui fait que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous liez une vidéo en ligne et ajoutez une miniature, la présentation stocke le lien et l’image d’aperçu au lieu des données vidéo, de sorte que l’augmentation de taille est généralement moindre.

**Puis‑je remplacer la vidéo d’une trame vidéo existante sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) au sein de la trame tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.