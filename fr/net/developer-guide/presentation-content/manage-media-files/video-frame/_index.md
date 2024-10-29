---
title: Cadre Vidéo
type: docs
weight: 10
url: /fr/net/video-frame/
keywords: "Ajouter vidéo, créer cadre vidéo, extraire vidéo, présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Ajouter un cadre vidéo à une présentation PowerPoint en C# ou .NET"
---

Une vidéo bien placée dans une présentation peut rendre votre message plus convaincant et augmenter le niveau d'engagement avec votre public.

PowerPoint vous permet d'ajouter des vidéos à une diapositive dans une présentation de deux manières :

* Ajouter ou intégrer une vidéo locale (stockée sur votre machine)
* Ajouter une vidéo en ligne (d'une source web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), l'interface [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) et d'autres types pertinents.

## **Créer un Cadre Vidéo Intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) et passez le chemin du fichier vidéo pour intégrer la vidéo avec la présentation.
1. Ajoutez un objet [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.
1. Enregistrez la présentation modifiée.

Ce code C# vous montre comment ajouter une vidéo stockée localement à une présentation :

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
Alternativement, vous pouvez ajouter une vidéo en passant directement son chemin de fichier à la méthode [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/) :

```c#
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Créer un Cadre Vidéo avec une Vidéo d'une Source Web**
Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez une référence à une diapositive par son index.
1. Ajoutez un objet [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) et passez le lien vers la vidéo.
1. Définissez une miniature pour le cadre vidéo.
1. Enregistrez la présentation.

Ce code C# vous montre comment ajouter une vidéo du web à une diapositive dans une présentation PowerPoint :

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
    // Ajoute un cadre vidéo
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Charge la miniature
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Extraire une Vidéo d'une Diapositive**
En plus d'ajouter des vidéos aux diapositives, Aspose.Slides vous permet d'extraire des vidéos intégrées dans des présentations.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour charger la présentation contenant la vidéo.
2. Itérez à travers tous les objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide).
3. Itérez à travers tous les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) pour trouver un [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe).
4. Enregistrez la vidéo sur le disque.

Ce code C# vous montre comment extraire la vidéo d'une diapositive de présentation :

```c#
// Instancie un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation("Video.pptx");

// Itère à travers les diapositives
foreach (ISlide slide in presentation.Slides)
{
    // Itère à travers les formes
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