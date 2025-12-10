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
- source Web
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à ajouter et extraire programmatiquement des cadres vidéo dans les diapositives PowerPoint et OpenDocument en utilisant Aspose.Slides pour .NET. Guide pratique rapide."
---

Une vidéo bien placée dans une présentation peut rendre votre message plus percutant et augmenter le niveau d'engagement de votre audience. 

PowerPoint vous permet d'ajouter des vidéos à une diapositive d'une présentation de deux manières :

* Ajouter ou incorporer une vidéo locale (stockée sur votre ordinateur)
* Ajouter une vidéo en ligne (provenant d'une source web telle que YouTube).

Pour vous permettre d'ajouter des vidéos (objets vidéo) à une présentation, Aspose.Slides fournit l'interface [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), l'interface [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) et d'autres types pertinents. 

## **Créer un cadre vidéo intégré**

Si le fichier vidéo que vous souhaitez ajouter à votre diapositive est stocké localement, vous pouvez créer un cadre vidéo pour intégrer la vidéo dans votre présentation. 

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Obtenir la référence d'une diapositive via son indice. 
3. Ajouter un objet [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) et transmettre le chemin du fichier vidéo pour intégrer la vidéo à la présentation. 
4. Ajouter un objet [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) pour créer un cadre pour la vidéo.  
5. Enregistrer la présentation modifiée. 

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

Alternativement, vous pouvez ajouter une vidéo en transmettant directement son chemin de fichier à la méthode [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/):
``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Créer un cadre vidéo avec une vidéo provenant d'une source Web**
Microsoft [PowerPoint 2013 et versions ultérieures](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) prend en charge les vidéos YouTube dans les présentations. Si la vidéo que vous souhaitez utiliser est disponible en ligne (par exemple sur YouTube), vous pouvez l'ajouter à votre présentation via son lien web. 

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)
2. Obtenir la référence d'une diapositive via son indice. 
3. Ajouter un objet [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) et transmettre le lien vers la vidéo.
4. Définir une miniature pour le cadre vidéo. 
5. Enregistrer la présentation. 

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

    // Charge la miniature
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```


## **Extraire la vidéo d'une diapositive**
En plus d'ajouter des vidéos aux diapositives, Aspose.Slides vous permet d'extraire les vidéos intégrées dans les présentations.

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) pour charger la présentation contenant la vidéo. 
2. Parcourir tous les objets [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide). 
3. Parcourir tous les objets [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape) afin de trouver un [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe). 
4. Enregistrer la vidéo sur le disque.

```c#
 // Instancie un objet Presentation qui représente un fichier de présentation 
Presentation presentation = new Presentation("Video.pptx");

// Parcourt les diapositives
foreach (ISlide slide in presentation.Slides)
{
    // Parcourt les formes
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Enregistre la vidéo sur le disque dès qu'un VideoFrame contenant la vidéo est trouvé
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

Vous pouvez contrôler le [mode de lecture](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatique ou au clic) et la [boucle](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Ces options sont disponibles via les propriétés de l'objet [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**L'ajout d'une vidéo affecte-t-il la taille du fichier PPTX ?**

Oui. Lorsque vous intégrez une vidéo locale, les données binaires sont incluses dans le document, de sorte que la taille de la présentation augmente proportionnellement à la taille du fichier. Lorsque vous ajoutez une vidéo en ligne, un lien et une miniature sont incorporés, ce qui entraîne une augmentation de taille moindre.

**Puis-je remplacer la vidéo d'un VideoFrame existant sans changer sa position et sa taille ?**

Oui. Vous pouvez échanger le [contenu vidéo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) à l'intérieur du cadre tout en conservant la géométrie de la forme ; c'est un scénario fréquent pour mettre à jour les médias dans une mise en page existante.

**Peut-on déterminer le type de contenu (MIME) d'une vidéo incorporée ?**

Oui. Une vidéo incorporée possède un [type de contenu](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) que vous pouvez lire et utiliser, par exemple lors de son enregistrement sur le disque.