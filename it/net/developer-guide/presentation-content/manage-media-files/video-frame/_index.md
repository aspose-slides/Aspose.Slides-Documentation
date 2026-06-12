---
title: Gestire i fotogrammi video nelle presentazioni in .NET
linktitle: Fotogramma video
type: docs
weight: 10
url: /it/net/video-frame/
keywords:
- aggiungere video
- creare video
- incorporare video
- estrarre video
- recuperare video
- fotogramma video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente fotogrammi video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per .NET. Guida rapida pratico."
---
## **Introduzione**

Un video ben posizionato in una presentazione può rendere il tuo messaggio più coinvolgente e aumentare i livelli di partecipazione del pubblico. 

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungere o incorporare un video locale (memorizzato sul tuo computer)
* Aggiungere un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) , l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) e altri tipi pertinenti. 

## **Crea un fotogramma video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella tua presentazione. 

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Ottieni il riferimento di una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) e passa il percorso del file video per incorporare il video nella presentazione. 
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) per creare un fotogramma per il video.  
1. Salva la presentazione modificata. 

```c#
 // Istanzia la classe Presentation
 using (Presentation pres = new Presentation("pres.pptx"))
 {
     // Carica il video
     using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
     {
         IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
         
         // Ottiene la prima diapositiva e aggiunge un videoframe
         pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
         
         // Salva la presentazione su disco
         pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
     }
 }
```
In alternativa, puoi aggiungere un video passando direttamente il percorso del file al metodo [AddVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addvideoframe/) :

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```

## **Crea un fotogramma video con video da una fonte web**

Microsoft [PowerPoint 2013 e versioni successive](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla tua presentazione tramite il suo collegamento web. 

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) .
1. Ottieni il riferimento di una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) e passa il collegamento al video.
1. Imposta una miniatura per il fotogramma video. 
1. Salva la presentazione. 

```c#
public static void Run()
{
    // Istanzia un oggetto Presentation che rappresenta un file di presentazione 
    using (Presentation pres = new Presentation())
    {
        AddVideoFromYouTube(pres, "Tj75Arhq5ho");
        pres.Save("AddVideoFrameFromWebSource_out.pptx", SaveFormat.Pptx);
    }
}

private static void AddVideoFromYouTube(Presentation pres, string videoId)
{
    // Aggiunge un VideoFrame
    IVideoFrame videoFrame = pres.Slides[0].Shapes.AddVideoFrame(10, 10, 427, 240, "https://www.youtube.com/embed/" + videoId);
    videoFrame.PlayMode = VideoPlayModePreset.Auto;

    // Carica la miniatura
    using (WebClient client = new WebClient())
    {
        string thumbnailUri = "http://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
        videoFrame.PictureFormat.Picture.Image = pres.Images.AddImage(client.DownloadData(thumbnailUri));
    }
}
```

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite la proprietà [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/) .

**Aggiungi sottotitoli a un fotogramma video**

Per aggiungere sottotitoli a un fotogramma video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/) .
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) a una diapositiva.
1. Usa la raccolta [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/) fornisce anche una sovraccarico che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un fotogramma video**

Per estrarre i sottotitoli da un fotogramma video:

1. Carica la presentazione che contiene il video.
1. Trova l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) di destinazione.
1. Itera attraverso la raccolta [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/) .
1. Salva ogni traccia di sottotitoli in un file `.vtt` .

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
                // Salva la traccia di sottotitoli in un file WebVTT.
                string filePath = $"{captionTrack.CaptionId}.vtt";
                File.WriteAllBytes(filePath, captionTrack.BinaryData);
            }
        }
    }
}
```

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/it/net/aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i sottotitoli da un fotogramma video**

Per rimuovere i sottotitoli da un fotogramma video:

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) di destinazione.
1. Rimuovi le tracce di sottotitoli dalla raccolta [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/) .
1. Salva la presentazione modificata.

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Rimuove tutti i sottotitoli dal fotogramma video.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [Remove](https://reference.aspose.com/slides/it/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides/captionscollection/removeat/) invece di [Clear](https://reference.aspose.com/slides/it/net/aspose.slides/captionscollection/clear/) .

## **Estrai video da una diapositiva**
Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) per caricare la presentazione contenente il video. 
2. Itera attraverso tutti gli oggetti [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide) .
3. Itera attraverso tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe) . 
4. Salva il video su disco.

```c#
// Instanzia un oggetto Presentation che rappresenta un file di presentazione 
Presentation presentation = new Presentation("Video.pptx");

// Itera attraverso le diapositive
foreach (ISlide slide in presentation.Slides)
{
    // Itera attraverso le forme
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Salva il video su disco una volta trovato VideoFrame contenente il video
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

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/playmode/) (auto o al clic) e il [looping](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/playloopmode/) . Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/) .

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari sono inclusi nel documento, quindi la dimensione della presentazione aumenta proporzionalmente alla dimensione del file. Quando aggiungi un video online, vengono incorporati un collegamento e una miniatura, quindi l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza modificare posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/embeddedvideo/) all'interno del fotogramma mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/it/net/aspose.slides/video/contenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.