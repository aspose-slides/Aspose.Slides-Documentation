---
title: Gérer les cadres vidéo dans les présentations en .NET
linktitle: Cadre vidéo
type: docs
weight: 10
url: /fr/net/video-frame/
keywords:
- ajouter une vidéo
- créer une vidéo
- intégrer une vidéo
- extraire une vidéo
- récupérer une vidéo
- cadre vidéo
- source web
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et extraire de façon programmatique des cadres vidéo dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour .NET. Guide rapide."
---
Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre public. 

PowerPoint vous permet d’ajouter des vidéos à une diapositive d’une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d’une source web telle que YouTube).

Pour vous permettre d’ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit les interfaces [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) et [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/), ainsi que d’autres types pertinents. 

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation)class.
1. Obtenez la référence d’une diapositive via son index. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) et transmettez le chemin du fichier vidéo pour intégrer la vidéo à la présentation. 
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
1. Enregistrez la présentation modifiée. 

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
Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode [AddVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Créer un cadre vidéo avec une vidéo provenant d’une source Web**
Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l’ajouter à votre présentation via son lien web. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation)
1. Obtenez la référence d’une diapositive via son index. 
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideo/) et transmettez le lien de la vidéo.
1. Définissez une vignette pour le cadre vidéo. 
1. Enregistrez la présentation. 

Ce code C# montre comment ajouter une vidéo depuis le Web à une diapositive d’une présentation PowerPoint :

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

## **Gérer les sous‑titres vidéo**

Aspose.Slides vous permet de gérer les sous‑titres fermés pour les cadres vidéo dans les présentations PowerPoint. Les sous‑titres sont stockés au format WebVTT et sont accessibles via la propriété [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/).

**Ajouter des sous‑titres à un cadre vidéo**

Pour ajouter des sous‑titres à un cadre vidéo :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/)
1. Ajoutez une vidéo à la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) à une diapositive.
1. Utilisez la collection [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/) pour ajouter une piste de sous‑titres WebVTT.
1. Enregistrez la présentation modifiée.

Le code suivant montre comment ajouter des sous‑titres à un cadre vidéo :

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Ajoute une nouvelle piste de sous-titres à partir d'un fichier WebVTT.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

L’interface [ICaptionsCollection](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptionscollection/) propose également une surcharge qui vous permet d’ajouter des sous‑titres à partir d’un flux.

**Extraire les sous‑titres d’un cadre vidéo**

Pour extraire les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
1. Trouvez l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) cible.
1. Parcourez la collection [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/).
1. Enregistrez chaque piste de sous‑titres dans un fichier `.vtt`.

Le code suivant montre comment extraire les sous‑titres d’un cadre vidéo :

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

Chaque objet [ICaptions](https://reference.aspose.com/slides/fr/net/aspose.slides/icaptions/) expose l’identifiant du sous‑titre, le libellé, les données binaires et le texte du sous‑titre sous forme de chaîne UTF‑8.

**Supprimer les sous‑titres d’un cadre vidéo**

Pour supprimer les sous‑titres d’un cadre vidéo :

1. Chargez la présentation contenant la vidéo.
1. Obtenez l’objet [IVideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/) cible.
1. Supprimez les pistes de sous‑titres de la collection [CaptionTracks](https://reference.aspose.com/slides/fr/net/aspose.slides/ivideoframe/captiontracks/).
1. Enregistrez la présentation modifiée.

Le code suivant montre comment supprimer tous les sous‑titres d’un cadre vidéo :

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Supprime tous les sous‑titres du cadre vidéo.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Si vous devez supprimer uniquement une piste de sous‑titres, utilisez les méthodes [Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/captionscollection/remove/) ou [RemoveAt](https://reference.aspose.com/slides/fr/net/aspose.slides/captionscollection/removeat/) au lieu de [Clear](https://reference.aspose.com/slides/fr/net/aspose.slides/captionscollection/clear/).

## **Extraire la vidéo d’une diapositive**
Outre l’ajout de vidéos aux diapositives, Aspose.Slides vous permet d’extraire les vidéos intégrées aux présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) pour charger la présentation contenant la vidéo. 
2. Parcourez tous les objets [ISlide](https://reference.aspose.com/slides/fr/net/aspose.slides/islide).
3. Parcourez tous les objets [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape) pour trouver un [VideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe). 
4. Enregistrez la vidéo sur le disque.

Ce code C# montre comment extraire la vidéo d’une diapositive de présentation :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation("Video.pptx");

// Itère à travers les diapositives
foreach (ISlide slide in presentation.Slides)
{
    // Itère à travers les formes
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Enregistre la vidéo sur le disque dès qu’un VideoFrame contenant la vidéo est trouvé
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

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/playmode/) (automatique ou au clic) et la [boucle de lecture](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/playloopmode/). Ces options sont disponibles via les propriétés de l’objet [VideoFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/).

**L’ajout d’une vidéo affecte-t‑il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, ainsi la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une vignette sont intégrés, ce qui entraîne une augmentation de taille moindre.

**Puis‑je remplacer la vidéo d’un VideoFrame existant sans modifier sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/fr/net/aspose.slides/videoframe/embeddedvideo/) à l’intérieur du cadre tout en conservant la géométrie de la forme ; c’est un scénario courant pour mettre à jour les médias dans une mise en page existante.

**Peut‑on déterminer le type de contenu (MIME) d’une vidéo intégrée ?**

Oui. Une vidéo intégrée possède un [type de contenu](https://reference.aspose.com/slides/fr/net/aspose.slides/video/contenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.