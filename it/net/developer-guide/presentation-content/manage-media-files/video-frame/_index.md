---
title: Gestire le cornici video nelle presentazioni in .NET
linktitle: Cornice video
type: docs
weight: 10
url: /it/net/video-frame/
keywords:
- aggiungi video
- crea video
- incorpora video
- estrai video
- recupera video
- cornice video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- .NET
- C#
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente cornici video in diapositive PowerPoint e OpenDocument usando Aspose.Slides per .NET. Guida pratica rapida."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides per .NET consente di aggiungere cornici video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e le cornici video, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/net/aspose.slides/ivideo/) , l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) e altri tipi pertinenti.

## **Crea una Cornice Video Incorporata**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, puoi creare una cornice video per incorporare il video nella tua presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni della cornice sono in punti. Lo stream rimane aperto fino al completamento del salvataggio perché [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/net/aspose.slides/loadingstreambehavior/) lo mantiene bloccato mentre la presentazione lo utilizza.

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

## **Imposta il Volume del Video con Precisione**

In Aspose.Slides per .NET 26.11 o versioni successive, [IVideoFrame.VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volumevalue/) imposta una percentuale in virgola mobile da 0 a 100. Usala quando le impostazioni predefinite di [Volume](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/volume/) sono troppo grossolane. Ad esempio, `75.5f` richiede un volume del 75.5%.

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

Convalida l'input autonomamente; non fare affidamento sul setter per rifiutare valori al di fuori dell'intervallo documentato. Le preimpostazioni Low, Medium e Loud corrispondono a 20, 50 e 80 in 26.11. Impostare una preimpostazione può sovrascrivere una percentuale precedente, quindi assegna la percentuale per ultima quando hai bisogno di un valore esatto. Usa [AudioVolumeMode.Mute](https://reference.aspose.com/slides/net/aspose.slides/audiovolumemode/) per l'impostazione esplicita di silenzio; lo zero numerico e l'enumerazione di preset non sono stati intercambiabili.

Imposta esplicitamente [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/playmode/) quando configuri anche un video collegato e mantieni disponibile il suo file multimediale per lo spettatore. Il salvataggio e la riapertura verificano l'impostazione memorizzata; la riproduzione reale e il volume dipendono dal lettore della presentazione e dalle sue impostazioni audio.

## **Crea una Cornice Video con Video da una Fonte Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. Puoi creare una cornice video che collega a un video online, come un video di YouTube.

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

In una presentazione formativa, puoi riprodurre una dimostrazione software in modalità schermo intero affinché il pubblico possa vedere i dettagli. Imposta [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/) su `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con una cornice video esistente nella prima diapositiva.

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

La riproduzione a schermo intero controlla come il video viene visualizzato. In modo indipendente, [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controlla se inizia automaticamente o al clic, e [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) controlla se si ripete. Per scegliere il comportamento di avvio, imposta la modalità di riproduzione su [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/). L'esempio conserva le impostazioni di avvio e ripetizione esistenti.

## **Riavvolgi un Video Dopo la Riproduzione**

In una presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per il presentatore per riprodurlo nuovamente. Imposta [RewindVideo](https://reference.aspose.com/slides/net/aspose.slides/videoframe/rewindvideo/) su `true` per riportare il video all'inizio dopo il completamento della riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/) nella prima diapositiva e abilita il riavvolgimento. Disabilita il loop in modo che la riproduzione possa terminare e imposta l'avvio della riproduzione al clic. La presentazione di input deve contenere almeno una diapositiva con una cornice video esistente nella prima diapositiva.

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

Il riavvolgimento riporta il video all'inizio senza avviarlo nuovamente. Al contrario, abilitare [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/) ripete la riproduzione automaticamente. Mantieni il loop disabilitato quando vuoi che il video termini e rimanga pronto per una nuova riproduzione. [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) controlla indipendentemente l'avvio automatico o al clic; questo esempio utilizza [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/net/aspose.slides/videoplaymodepreset/) così il presentatore controlla quando inizia la riproduzione. Imposta la modalità di riproduzione dopo l'impostazione del loop, come mostrato nell'esempio. Il riavvolgimento funziona indipendentemente da [FullScreenMode](https://reference.aspose.com/slides/net/aspose.slides/videoframe/fullscreenmode/).

## **Ritaglia una Cornice Video**

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

Questo esempio stampa i valori di ritaglio della prima cornice video sulla prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha una cornice video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

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

Aspose.Slides consente di gestire i sottotitoli chiusi per le cornici video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati nel formato WebVTT e sono disponibili tramite la proprietà [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/).

### **Aggiungi Sottotitoli a una Cornice Video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli dovrebbero corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

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

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/) fornisce anche una sovraccarico che consente di aggiungere sottotitoli da uno stream.

### **Estrai i Sottotitoli da una Cornice Video**

Questo esempio salva tutte le tracce di sottotitoli dalle cornici video sulla prima diapositiva come file WebVTT separati. Numeri sequenziali mantengono distinti i file di output. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

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

### **Rimuovi i Sottotitoli da una Cornice Video**

Questo esempio rimuove tutti i sottotitoli dalla cornice video nella prima posizione della forma sulla prima diapositiva e salva il risultato. Assume che la diapositiva e la forma esistano e che la forma sia una cornice video.

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

### **Cerca i Sottotitoli Video**

[ICaptions.DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) restituisce l'intera traccia WebVTT, inclusa l'intestazione, le linee temporali e il testo dei sottotitoli. Per trovare una frase pronunciata e il relativo timestamp, leggi i cue in memoria. Per esempio, una traccia English nella diapositiva 2 potrebbe contenere il seguente testo:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

L'esempio visita ogni diapositiva e legge le tracce delle sue cornici video di livello superiore attraverso [IVideoFrame.CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/ivideoframe/captiontracks/). In un cue di testo semplice, la linea temporale contiene `-->` e una riga vuota termina il cue. Quando il testo del sottotitolo contiene “café”, l'esempio stampa il numero della diapositiva, l'etichetta della traccia, la linea temporale originale e il sottotitolo completo.

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

La ricerca di “café” produce una corrispondenza per la traccia di esempio. L'intestazione e l'impostazione temporale sono al di fuori del testo del cue.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Estrai il Video da una Diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari separati e numerati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ciascun video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; cambiala per corrispondere al tipo multimediale segnalato quando necessario.

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

**Quali parametri di riproduzione video possono essere modificati per una cornice video?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playmode/) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/net/aspose.slides/videoframe/playloopmode/). Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/net/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inseriti nel documento, quindi la dimensione della presentazione aumenta proporzionalmente alla dimensione del file. Quando colleghi a un video online e aggiungi una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima invece dei dati video, quindi l'aumento di dimensione è solitamente minore.

**Posso sostituire il video in una cornice video esistente senza modificare la sua posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/net/aspose.slides/videoframe/embeddedvideo/) all'interno della cornice mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [content type](https://reference.aspose.com/slides/net/aspose.slides/video/contenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.