---
title: Gestire i Fotogrammi Video nelle Presentazioni in .NET
linktitle: Fotogramma Video
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
- sorgente web
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara a aggiungere ed estrarre programmaticamente i fotogrammi video in slide PowerPoint e OpenDocument usando Aspose.Slides per .NET. Guida rapida passo passo."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides for .NET consente di aggiungere fotogrammi video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come video di YouTube.

Per rappresentare i dati video e i fotogrammi video, Aspose.Slides fornisce l’interfaccia [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , l’interfaccia [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) e altri tipi pertinenti.

## **Crea un Fotogramma Video Incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare un fotogramma video per incorporare il video nella presentazione.

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

Puoi anche passare direttamente un percorso video locale a [AddVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addvideoframe/). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve restare accessibile fino al salvataggio della presentazione.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

slide.Shapes.AddVideoFrame(50, 150, 300, 150, "video.avi");

presentation.Save("video_from_path.pptx", SaveFormat.Pptx);
```

## **Imposta il Volume del Video con Precisione**

In Aspose.Slides for .NET 26.11 o versioni successive, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) imposta una percentuale a virgola mobile da 0 a 100. Usalo quando le impostazioni predefinite di [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) sono troppo grossolane. Per esempio, `75.5f` richiede un volume del 75,5 %.

Questo esempio richiede [Aspose.Slides for .NET](/slides/it/net/installation/) 26.11 o versioni successive e un file locale `video.mp4`. Incorpora il video, inizializza esplicitamente la riproduzione, salva la presentazione e legge nuovamente la percentuale memorizzata.

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

Convalida gli input manualmente; non fare affidamento sul setter per rifiutare valori al di fuori dell’intervallo documentato. I preset Low, Medium e Loud corrispondono a 20, 50 e 80 in 26.11. Impostare un preset può sostituire una percentuale precedente, quindi assegna la percentuale per ultima quando ti serve un valore esatto. Usa [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) per l’impostazione esplicita di mute; uno zero numerico e l’enumerazione preset non sono stati stati progettati per essere intercambiabili.

Imposta esplicitamente [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) anche quando configuri un video collegato e mantieni il file multimediale disponibile per lo spettatore. Il salvataggio e la riapertura verificano l’impostazione memorizzata; la riproduzione effettiva e il livello sonoro dipendono dal lettore della presentazione e dalle sue impostazioni audio.

## **Crea un Fotogramma Video con Video da una Fonte Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare un fotogramma video che collega a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento a un video YouTube e una miniatura alla prima diapositiva. Sostituisci l’identificatore del video per usarne un altro. L’impostazione [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono l’accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

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

## **Riproduci un Video in Modalità a Schermo Intero**

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità a schermo intero così il pubblico può vedere i dettagli. Imposta [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) su `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di ingresso deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

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

La riproduzione a schermo intero controlla come il video viene visualizzato. Separatamente, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controlla se il video inizia automaticamente o al clic, e [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). L’esempio preserva le impostazioni di avvio e di loop esistenti.

## **Riavvolgi un Video Dopo la Riproduzione**

In una presentazione formativa, riportare un video dimostrativo all’inizio lo rende pronto per essere riprodotto nuovamente dal presentatore. Imposta [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) su `true` per riportare il video all’inizio dopo il completamento della riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) nella prima diapositiva e abilita il riavvolgimento. Disattiva il looping affinché la riproduzione possa terminare e imposta la riproduzione in avvio al clic. La presentazione di ingresso deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

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

Il riavvolgimento riporta il video all’inizio senza avviarlo nuovamente. Al contrario, abilitare [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) fa ripetere la riproduzione automaticamente. Mantieni il loop disattivato quando vuoi che il video termini e rimanga pronto per una riproduzione successiva. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controlla in maniera indipendente l’avvio automatico o al clic; questo esempio usa [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) così il presentatore decide quando avviare la riproduzione. Imposta la modalità di riproduzione dopo l’impostazione del loop, come mostrato nell’esempio. Il riavvolgimento funziona indipendentemente da [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Ritaglia un Fotogramma Video**

Usa [IVideoFrame.TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromstart/) e [IVideoFrame.TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/trimfromend/) per saltare una parte dell’inizio o della fine di un video durante la riproduzione. Entrambi i valori sono in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta le Impostazioni di Ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l’ultimo secondo durante la riproduzione. Usa un video più lungo di 3,5 secondi così rimane un segmento riproducibile.

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

Questo esempio stampa i valori di ritaglio del primo fotogramma video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un fotogramma video, non viene stampato nulla. L’esempio precedente produce valori di 2500 e 1000.

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

Aspose.Slides permette di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati in formato WebVTT e sono accessibili tramite la proprietà [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

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

L’interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) fornisce anche un overload che consente di aggiungere sottotitoli da uno stream.

**Estrai i Sottotitoli da un Fotogramma Video**

Questo esempio salva tutte le tracce di sottotitoli dai fotogrammi video nella prima diapositiva come file WebVTT separati. I numeri sequenziali mantengono i file di output distinti. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

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

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/net/aspose.slides/icaptions/) espone l’identificatore del sottotitolo, l’etichetta, i dati binari e il testo del sottotitolo come stringa UTF‑8.

**Rimuovi i Sottotitoli da un Fotogramma Video**

Questo esempio rimuove tutti i sottotitoli dal fotogramma video nella prima posizione della forma nella prima diapositiva e salva il risultato. Presume che la diapositiva e la forma esistano e che la forma sia un fotogramma video.

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

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [Remove](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/removeat/) invece di [Clear](https://reference.aspose.com/slides/net/aspose.slides/captionscollection/clear/).

## **Estrai il Video da una Diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari numerati separati. I video collegati vengono saltati perché non hanno dati incorporati. La console stampa il tipo MIME di ogni video e il conteggio totale. L’output utilizza l’estensione generica `.bin`; cambiala per corrispondere al tipo multimediale riportato quando necessario.

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

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (auto o al clic) e il [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). queste opzioni sono disponibili tramite le proprietà dell’oggetto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**L’aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione cresce proporzionalmente alle dimensioni del file. Quando colleghi a un video online e aggiungi una miniatura, la presentazione memorizza solo il collegamento e l’immagine di anteprima anziché i dati video, quindi l’aumento di dimensione è solitamente minore.

**Posso sostituire il video in un fotogramma video esistente senza cambiare la sua posizione e le sue dimensioni?**

Sì. Puoi sostituire il [contenuto video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) all’interno del fotogramma mantenendo inalterata la geometria della forma; è uno scenario comune per l’aggiornamento dei media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato possiede un [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.