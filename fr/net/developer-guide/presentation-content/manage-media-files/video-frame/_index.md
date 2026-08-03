---
title: Gérer les cadres vidéo dans les présentations en .NET
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/net/video-frame/
keywords:
- ajouter vidéo
- créer vidéo
- intégrer vidéo
- extraire vidéo
- récupérer vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmaticalement des cadres vidéo dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET. Guide pratique rapide."
---
## **Introduction**

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (à partir d'une source Web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) , l'interface [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) et d'autres types pertinents. 

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour incorporer la vidéo dans votre présentation. 

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Obtenir la référence d'une diapositive via son indice. 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) et fournir le chemin du fichier vidéo pour incorporer la vidéo à la présentation. 
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrer la présentation modifiée. 

Ce code C# montre comment ajouter une vidéo stockée localement à une présentation :

```c#
// Instancie la classe Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Charge la vidéo
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Obtient la première diapositive et ajoute un cadre vidéo
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Enregistre la présentation sur le disque
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
Alternativement, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [AddVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Créer un cadre vidéo à partir d'une source Web**

Les versions récentes de Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) prennent en charge les vidéos en ligne dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien Web.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
1. Obtenir la référence d'une diapositive via son indice. 
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) et fournir le lien vers la vidéo.
1. Définir une vignette pour le cadre vidéo. 
1. Enregistrer la présentation. 

Ce code C# montre comment ajouter une vidéo depuis le Web à une diapositive d'une présentation PowerPoint :

```c#
public static void Run()
{
    // Instancie un objet Presentation qui représente un fichier de présentation
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Ajoute un VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Charge la vignette
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Rogner un cadre vidéo**

Aspose.Slides vous permet de contrôler quelle partie d'une vidéo est lue en définissant les valeurs trim-from-start et trim-from-end via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/trimfromstart/) et [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/trimfromend/). Les deux valeurs sont exprimées en millisecondes et définissent le temps à ignorer respectivement au début et à la fin de la vidéo. Ces paramètres modifient les paramètres de lecture de la vidéo dans la présentation ; ils ne coupent pas et ne modifient pas les données binaires de la vidéo incorporée.

**Définir les paramètres de rognage**

Pour créer un cadre vidéo et définir ses paramètres de rognage :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Ajouter un objet [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) à la présentation.
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) à une diapositive.
1. Définir les valeurs trim-from-start et trim-from-end via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/trimfromstart/) et [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/trimfromend/).
1. Enregistrer la présentation modifiée.

Le code suivant ignore les 2,5 secondes initiales et la dernière seconde d'une vidéo incorporée lors de la lecture :

```cs
using var presentation = new Presentation();

var videoData = File.ReadAllBytes("video.mp4");
var video = presentation.Videos.AddVideo(videoData);

var slide = presentation.Slides[0];
var videoFrame = slide.Shapes.AddVideoFrame(50, 50, 640, 360, video);

videoFrame.TrimFromStart = 2500f;
videoFrame.TrimFromEnd = 1000f;

presentation.Save("video_with_trim.pptx", SaveFormat.Pptx);
```

**Lire les paramètres de rognage**

Pour examiner les paramètres de rognage existants, chargez une présentation, trouvez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) parmi les formes de la première diapositive et lisez les valeurs via [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/trimfromstart/) et [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/trimfromend/).

Le code suivant trouve le premier cadre vidéo de la première diapositive et indique ses paramètres de rognage en millisecondes :

```cs
using var presentation = new Presentation("video_with_trim.pptx");

var slide = presentation.Slides[0];
foreach (var shape in slide.Shapes)
{
    if (shape is IVideoFrame videoFrame)
    {
        var trimFromStart = videoFrame.TrimFromStart;
        var trimFromEnd = videoFrame.TrimFromEnd;

        Console.WriteLine($"Trim from start: {trimFromStart} ms");
        Console.WriteLine($"Trim from end: {trimFromEnd} ms");

        break;
    }
}
```

## **Gérer les légendes vidéo**

Aspose.Slides vous permet de gérer les sous-titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous-titres sont stockés au format WebVTT et sont accessibles via la propriété [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/).

**Ajouter des légendes à un cadre vidéo**

Pour ajouter des légendes à un cadre vidéo :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
1. Ajouter une vidéo à la présentation.
1. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) à une diapositive.
1. Utiliser la collection [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/) pour ajouter une piste de sous-titres WebVTT.
1. Enregistrer la présentation modifiée.

Le code suivant montre comment ajouter des légendes à un cadre vidéo :

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

L'interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d'ajouter des sous-titres à partir d'un flux.

**Extraire les légendes d'un cadre vidéo**

Pour extraire les légendes d'un cadre vidéo :

1. Charger la présentation contenant la vidéo.
1. Trouver l'objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) cible.
1. Itérer sur la collection [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/).
1. Enregistrer chaque piste de sous-titres dans un fichier `.vtt`.

Le code suivant montre comment extraire les légendes d'un cadre vidéo :

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IVideoFrame videoFrame)
        {
            foreach (ICaptions captionTrack in videoFrame.CaptionTracks)
            {
                // Enregistre la piste de sous-titres dans un fichier WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Chaque objet [ICaptions](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptions/) expose l'identifiant du sous-titre, le libellé, les données binaires et le texte du sous-titre sous forme de chaîne UTF-8.

**Supprimer les légendes d'un cadre vidéo**

Pour supprimer les légendes d'un cadre vidéo :

1. Charger la présentation contenant la vidéo.
1. Obtenir l'objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) cible.
1. Supprimer les pistes de sous-titres de la collection [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/).
1. Enregistrer la présentation modifiée.

Le code suivant montre comment supprimer toutes les légendes d'un cadre vidéo :

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Supprime toutes les sous-titres du cadre vidéo.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Si vous devez supprimer uniquement une piste de sous-titres, utilisez les méthodes [Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides/captionscollection/removeat/) plutôt que [Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/captionscollection/clear/).

## **Extraire une vidéo d'une diapositive**

Outre l'ajout de vidéos aux diapositives, Aspose.Slides vous permet d'extraire les vidéos incorporées dans les présentations.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) pour charger la présentation contenant la vidéo. 
2. Parcourir tous les objets [ISlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide).
3. Parcourir tous les objets [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape) afin de trouver un [VideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe). 
4. Enregistrer la vidéo sur le disque.

Ce code C# montre comment extraire la vidéo d'une diapositive d'une présentation :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation("Video.pptx");

// Parcourt les diapositives
foreach (ISlide slide in presentation.Slides)
{
    // Parcourt les formes
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Enregistre la vidéo sur le disque une fois le VideoFrame contenant la vidéo trouvé
        if (shape is VideoFrame)
        {
            IVideoFrame vf = shape as IVideoFrame;
            String type = vf.EmbeddedVideo.ContentType;
            int ss = type.LastIndexOf('/');
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            Byte[] buffer = vf.EmbeddedVideo.BinaryData;
            using (FileStream stream = new FileStream("NewVideo_out." + type, FileMode.Create, FileAccess.Write, FileShare.Read))
            {                                                     
                stream.Write(buffer, 0, buffer.Length);
            }
        }
    }
}
```

## **FAQ**

**Quels paramètres de lecture vidéo peuvent être modifiés pour un VideoFrame ?**

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/playmode/) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/playloopmode/). Ces options sont disponibles via les propriétés de l'objet [VideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/).

**L'ajout d'une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous incorporez une vidéo locale, les données binaires sont incluses dans le document, ce qui entraîne une augmentation de la taille de la présentation proportionnelle à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont incorporés, de sorte que l'augmentation de taille est moindre.

**Puis-je remplacer la vidéo d'un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez remplacer le [contenu vidéo](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/embeddedvideo/) à l'intérieur du cadre tout en conservant la géométrie de la forme ; c'est un scénario fréquent pour mettre à jour les médias dans une disposition existante.

**Peut-on déterminer le type de contenu (MIME) d'une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/fr/net/aspose.slides/video/contenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.