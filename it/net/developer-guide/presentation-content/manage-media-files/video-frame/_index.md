---
title: Gestire i frame video nelle presentazioni in .NET
linktitle: Frame video
type: docs
weight: 10
url: /it/net/video-frame/
keywords:
- aggiungi video
- crea video
- incorpora video
- estrai video
- recupera video
- frame video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per .NET. Guida rapida passo-passo."
---
## **Introduzione**

Un video posizionato in modo appropriato in una presentazione può rendere il tuo messaggio più convincente e aumentare il livello di coinvolgimento del pubblico. 

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungi o incorpora un video locale (memorizzato sul tuo computer)
* Aggiungi un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) , l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) e altri tipi pertinenti. 

## **Crea un frame video incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un frame video per incorporare il video nella presentazione. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il riferimento a una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) e passa il percorso del file video per incorporare il video nella presentazione. 
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) per creare un frame per il video.  
1. Salva la presentazione modificata. 

```c#
// Istanzia la classe Presentation
using (Presentation pres = new Presentation("pres.pptx"))
{
    // Carica il video
    using (FileStream fileStream = new FileStream("Wildlife.mp4", FileMode.Open, FileAccess.Read))
    {
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        
        // Ottiene la prima diapositiva e aggiunge un frame video
        pres.Slides[0].Shapes.AddVideoFrame(10, 10, 150, 250, video);
        
        // Salva la presentazione su disco
        pres.Save("pres-with-video.pptx", SaveFormat.Pptx);
    }
}
```
In alternativa, è possibile aggiungere un video passando direttamente il suo percorso file al metodo [AddVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ishapecollection/addvideoframe/):

``` csharp
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    IVideoFrame vf = sld.Shapes.AddVideoFrame(50, 150, 300, 150, "video1.avi");
}
```


## **Crea un frame video con video da una fonte web**
Le versioni più recenti di Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supportano i video online nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad es. su YouTube), puoi aggiungerlo alla presentazione tramite il suo collegamento web.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
1. Ottieni il riferimento a una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) e passa il collegamento al video.
1. Imposta una miniatura per il frame video. 
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

## **Ritaglia un frame video**

Aspose.Slides consente di controllare quale parte di un video viene riprodotta impostando i valori trim-from-start e trim-from-end tramite [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/trimfromend/). Entrambi i valori sono specificati in millisecondi e definiscono quanto tempo viene saltato dall'inizio e dalla fine del video, rispettivamente. Queste impostazioni modificano le impostazioni di riproduzione del video nella presentazione; non tagliano né modificano i dati binari del video incorporato.

**Imposta le impostazioni di ritaglio**

Per creare un frame video e impostare le sue impostazioni di ritaglio:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/net/aspose.slides/ivideo/) alla presentazione.
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) a una diapositiva.
1. Imposta i valori trim-from-start e trim-from-end tramite [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/trimfromend/).
1. Salva la presentazione modificata.

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

**Leggi le impostazioni di ritaglio**

Per ispezionare le impostazioni di ritaglio esistenti, carica una presentazione, trova un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) tra le forme nella prima diapositiva e leggi i valori tramite [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/trimfromend/).

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

## **Gestisci i sottotitoli video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono esposti tramite la proprietà [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/).

**Aggiungi i sottotitoli a un frame video**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/).
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) a una diapositiva.
1. Utilizza la collezione [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] videoData = File.ReadAllBytes("video.mp4");
    IVideo video = presentation.Videos.AddVideo(videoData);

    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes.AddVideoFrame(0, 0, 100, 100, video);

    // Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
    videoFrame.CaptionTracks.Add("English", "track.vtt");

    presentation.Save("video_with_captions.pptx", SaveFormat.Pptx);
}
```

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrai i sottotitoli da un frame video**

1. Carica la presentazione che contiene il video.
1. Trova l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) di destinazione.
1. Itera attraverso la collezione [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/).
1. Salva ogni traccia di sottotitolo in un file `.vtt`.

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

**Rimuovi i sottotitoli da un frame video**

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/) di destinazione.
1. Rimuovi le tracce di sottotitoli dalla collezione [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/ivideoframe/captiontracks/).
1. Salva la presentazione modificata.

```cs
using (Presentation presentation = new Presentation("video_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IVideoFrame videoFrame = slide.Shapes[0] as IVideoFrame;

    // Rimuove tutti i sottotitoli dal frame video.
    videoFrame.CaptionTracks.Clear();

    presentation.Save("video_without_captions.pptx", SaveFormat.Pptx);
}
```

Se devi rimuovere solo una traccia di sottotitoli, utilizza i metodi [Remove](https://reference.aspose.com/slides/it/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides/captionscollection/removeat/) invece di [Clear](https://reference.aspose.com/slides/it/net/aspose.slides/captionscollection/clear/).

## **Estrai video da una diapositiva**
Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) per caricare la presentazione contenente il video. 
2. Itera attraverso tutti gli oggetti [ISlide](https://reference.aspose.com/slides/it/net/aspose.slides/islide).
3. Itera attraverso tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/net/aspose.slides/ishape) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe). 
4. Salva il video su disco.

```c#
// Istanzia un oggetto Presentation che rappresenta un file di presentazione 
Presentation presentation = new Presentation("Video.pptx");

// Itera attraverso le diapositive
foreach (ISlide slide in presentation.Slides)
{
    // Itera attraverso le forme
    foreach (IShape shape in presentation.Slides[0].Shapes)
    {
        // Salva il video su disco una volta trovato il VideoFrame contenente il video
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

Puoi controllare la [playback mode](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/playmode/) (auto o on click) e il [looping](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/playloopmode/). Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione cresce proporzionalmente alla dimensione del file. Quando aggiungi un video online, vengono incorporati un collegamento e una miniatura, perciò l'aumento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza cambiare la sua posizione e dimensione?**

Sì. È possibile scambiare il [video content](https://reference.aspose.com/slides/it/net/aspose.slides/videoframe/embeddedvideo/) all'interno del frame mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [content type](https://reference.aspose.com/slides/it/net/aspose.slides/video/contenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.