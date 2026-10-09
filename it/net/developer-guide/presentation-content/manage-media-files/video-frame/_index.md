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
description: "Impara ad aggiungere ed estrarre programmaticamente i fotogrammi video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per .NET. Guida rapida passo-passo."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides per .NET consente di aggiungere fotogrammi video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i fotogrammi video, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/), l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) e altri tipi pertinenti.

## **Crea un Fotogramma Video Incorporato**

Se il file video che desideri aggiungere alla tua diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del fotogramma sono in punti. Lo stream rimane aperto fino al termine del salvataggio perché [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) lo mantiene bloccato mentre la presentazione lo utilizza.

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

Puoi anche passare un percorso video locale direttamente a [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Crea un Fotogramma Video con Video da una Fonte Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare un fotogramma video che collega a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento a un video YouTube e una miniatura alla prima diapositiva. Sostituisci l'identificatore del video per utilizzare un altro video. L'impostazione [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono l'accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

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

## **Riproduci un Video in Modalità Schermo Intero**

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità schermo intero così il pubblico può vedere i dettagli. Imposta [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) su `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

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

La riproduzione a schermo intero controlla come il video viene visualizzato. In modo indipendente, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controlla se inizia automaticamente o al click, e [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). L'esempio preserva le impostazioni di avvio e di ciclo esistenti.

## **Riavvolgi un Video Dopo la Riproduzione**

In una presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per essere riprodotto di nuovo dall'presentatore. Imposta [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) su `true` per riportare il video all'inizio dopo il termine della riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) nella prima diapositiva e abilita il riavvolgimento. Disabilita il ciclo in modo che la riproduzione possa terminare e imposta l'avvio su click. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

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

Il riavvolgimento riporta il video all'inizio senza avviarlo di nuovo. Al contrario, abilitare [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ripete automaticamente la riproduzione. Mantieni il ciclo disabilitato quando vuoi che il video termini e rimanga pronto per una nuova riproduzione. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controlla indipendentemente l'avvio automatico o al click; questo esempio utilizza [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) così l'presentatore decide quando avviare la riproduzione. Imposta la modalità di riproduzione dopo l'impostazione del ciclo, come mostrato nell'esempio. Il riavvolgimento funziona indipendentemente da [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Ritaglia un Fotogramma Video**

Usa [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) per saltare una parte dell'inizio o della fine di un video durante la riproduzione. Entrambi i valori sono in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le Impostazioni di Ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l'ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi in modo che rimanga un segmento riproducibile.

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

**Leggi le Impostazioni di Ritaglio**

Questo esempio stampa i valori di ritaglio del primo fotogramma video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un fotogramma video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

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

## **Gestisci i Sottotitoli Video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono accessibili tramite la proprietà [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

**Aggiungi Sottotitoli a un Fotogramma Video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli devono corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

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

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrai i Sottotitoli da un Fotogramma Video**

Questo esempio salva tutte le tracce di sottotitoli dai fotogrammi video nella prima diapositiva come file WebVTT separati. Numeri sequenziali mantengono i file di output distinti. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

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

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

**Rimuovi i Sottotitoli da un Fotogramma Video**

Questo esempio rimuove tutti i sottotitoli dal fotogramma video nella prima posizione della forma nella prima diapositiva e salva il risultato. Si presuppone che la diapositiva e la forma esistano e che la forma sia un fotogramma video.

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

Se devi rimuovere solo una traccia di sottotitoli, utilizza i metodi [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) invece di [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Estrai Video da una Diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari numerati separati. I video collegati sono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ciascun video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; cambiala per farla corrispondere al tipo multimediale segnalato, se necessario.

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

**Quali parametri di riproduzione video possono essere modificati per un fotogramma video?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto o al click) e il [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari sono inclusi nel documento, quindi le dimensioni della presentazione crescono in proporzione alla dimensione del file. Quando colleghi a un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima anziché i dati video, quindi l'aumento di dimensione è solitamente minore.

**Posso sostituire il video in un fotogramma video esistente senza modificare posizione e dimensioni?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) all'interno del fotogramma mantenendo la geometria della forma; è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) che può essere letto e utilizzato, ad esempio quando lo si salva su disco.