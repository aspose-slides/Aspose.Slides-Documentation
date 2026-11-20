---
title: Gestire i frame audio nelle presentazioni in .NET
linktitle: Frame audio
type: docs
weight: 10
url: /it/net/audio-frame/
keywords:
- audio
- frame audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- .NET
- C#
- Aspose.Slides
description: "Incorpora audio nelle diapositive, modifica l'icona audio, configura la riproduzione, gestisci i sottotitoli WebVTT e estrai i suoni delle transizioni delle diapositive con Aspose.Slides per .NET."
---
## **Panoramica**

Un frame audio consente di riprodurre un suono su una diapositiva. Con Aspose.Slides per .NET, è possibile incorporare una clip audio, scegliere l’immagine che la rappresenta, regolare la riproduzione e allegare i sottotitoli. È inoltre possibile recuperare un suono assegnato a una transizione di diapositiva.

## **Creare frame audio**

Usa [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) per incorporare una clip audio locale nella prima diapositiva. Le prime due coordinate posizionano il frame sulla diapositiva, e i due valori successivi impostano larghezza e altezza, tutti in punti. Questo esempio imposta [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) per avviare automaticamente la clip e [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) sul preset alto.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, audioStream);
audioFrame.PlayMode = AudioPlayModePreset.Auto;
audioFrame.Volume = AudioVolumeMode.Loud;

presentation.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
```

## **Modificare la miniatura del frame audio**

Per impostazione predefinita, un frame audio visualizza un’icona di altoparlante. Per visualizzare una miniatura personalizzata, aggiungi un’immagine alla presentazione con [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) e assegnala alla proprietà [Picture.Image](https://reference.aspose.com/slides/net/aspose.slides/islidespicture/image/) del frame. L’esempio utilizza un JPEG come miniatura per una clip audio incorporata.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var imageStream = File.OpenRead("eagle.jpeg");
var thumbnail = presentation.Images.AddImage(imageStream);

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
audioFrame.PictureFormat.Picture.Image = thumbnail;

presentation.Save("example_out.pptx", SaveFormat.Pptx);
```

## **Modificare le opzioni di riproduzione audio**

I controlli **Audio Options** di PowerPoint determinano quando inizia una clip, quanto è alta e come si comporta durante la presentazione.

![Controlli Audio Options di PowerPoint per un frame audio](audio_frame_0.png)

| Controllo PowerPoint | Aspose.Slides property |
| --- | --- |
| Avvio | [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) |
| Preset volume | [Volume](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volume/) |
| Riproduci su più diapositive | [PlayAcrossSlides](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playacrossslides/) |
| Ripeti fino a interruzione | [PlayLoopMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playloopmode/) |
| Nascondi durante la presentazione | [HideAtShowing](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/hideatshowing/) |
| Riavvolgi dopo la riproduzione | [RewindAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/rewindaudio/) |
| Dissolvenza in ingresso | [FadeInDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeinduration/) |
| Dissolvenza in uscita | [FadeOutDuration](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/fadeoutduration/) |
| Taglia l'inizio audio | [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) |
| Taglia la fine audio | [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) |
| Slider volume | [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/) |

L’esempio trova il primo frame audio nella prima diapositiva, imposta [PlayMode](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/playmode/) per avviare la riproduzione con un clic e seleziona il preset volume basso. La clip continua su più diapositive con il looping disabilitato. L’icona rimane nascosta durante la presentazione e la clip viene riavvolta dopo la riproduzione.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.PlayMode = AudioPlayModePreset.OnClick;
audioFrame.Volume = AudioVolumeMode.Low;
audioFrame.PlayAcrossSlides = true;
audioFrame.PlayLoopMode = false;
audioFrame.HideAtShowing = true;
audioFrame.RewindAudio = true;

presentation.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
```

Per una clip più lunga di 3,5 secondi, questo esempio salta i primi 1,5 secondi e gli ultimi 2 secondi. [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) misura la durata da omettere alla fine della clip. Per ottenere il tempo finale mostrato in PowerPoint, sottrai quell’intervallo dalla durata totale della clip. La clip ritagliata sfuma in ingresso in 200 ms e sfuma in uscita in 500 ms. Tutte e quattro le proprietà accettano valori in millisecondi.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audioStream);
audioFrame.TrimFromStart = 1500f;
audioFrame.TrimFromEnd = 2000f;
audioFrame.FadeInDuration = 200f;
audioFrame.FadeOutDuration = 500f;

presentation.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
```

Per impostare il volume di riproduzione a una percentuale specifica, usa [VolumeValue](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/volumevalue/). Questo esempio imposta il primo frame audio nella prima diapositiva all’85 %.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("AudioFrameEmbed_out.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.VolumeValue = 85f;

presentation.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
```

## **Gestire i sottotitoli audio**

Ogni frame audio dispone di una collezione [CaptionTracks](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/captiontracks/). Usala per allegare sottotitoli WebVTT alla clip, esportare le tracce esistenti o rimuoverle.

### **Aggiungere sottotitoli audio**

L’esempio incorpora una clip audio nella prima diapositiva e utilizza [ICaptionsCollection.Add](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/add/) per allegare una traccia WebVTT locale. Il primo argomento fornisce l’etichetta della traccia, e il secondo identifica il file contenente i sottotitoli temporizzati.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var audioStream = File.OpenRead("audio.wav");
var audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audioStream);
audioFrame.CaptionTracks.Add("English", "track.vtt");

presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
```

### **Estrarre i sottotitoli audio**

Questo esempio esporta ogni traccia di sottotitoli allegata a un frame audio nella prima diapositiva. Scrive i [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/icaptions/binarydata/) della traccia in un file WebVTT e utilizza il suo [CaptionId](https://reference.aspose.com/slides/net/aspose.slides/icaptions/captionid/) come nome del file, così ogni traccia ha un output separato.

```csharp
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var audioFrame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in audioFrame.CaptionTracks)
    {
        File.WriteAllBytes($"{track.CaptionId}.vtt", track.BinaryData);
    }
}
```

### **Rimuovere i sottotitoli audio**

Usa [Remove](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/removeat/) per eliminare una traccia singola. L’esempio utilizza [Clear](https://reference.aspose.com/slides/net/aspose.slides/icaptionscollection/clear/) per rimuovere tutti i sottotitoli dal primo frame audio nella prima diapositiva preservando la clip.

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

var audioFrame = slide.Shapes.OfType<IAudioFrame>().FirstOrDefault();
if (audioFrame == null)
{
    Console.WriteLine("The first slide has no audio frame.");
    return;
}

audioFrame.CaptionTracks.Clear();

presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
```

### **Trovare una riga nei sottotitoli audio**

Per trovare una riga nei sottotitoli audio nella prima diapositiva, leggi in memoria i [DataAsString](https://reference.aspose.com/slides/net/aspose.slides/icaptions/dataasstring/) di ogni traccia. In un cue WebVTT di testo puro, la riga di temporizzazione contiene `-->`, le righe dei sottotitoli la seguono e una riga vuota termina il cue. Questo esempio stampa l’etichetta della traccia e ogni riga di sottotitolo contenente “café”.

```csharp
using System;
using System.IO;
using System.Linq;
using Aspose.Slides;

using var presentation = new Presentation("audio_with_captions.pptx");
var slide = presentation.Slides[0];

foreach (var frame in slide.Shapes.OfType<IAudioFrame>())
{
    foreach (var track in frame.CaptionTracks)
    {
        using var reader = new StringReader(track.DataAsString);
        var inCue = false;
        while (reader.ReadLine() is string line)
        {
            if (line.Length == 0)
                inCue = false;
            else if (line.Contains("-->"))
                inCue = true;
            else if (inCue && line.Contains("café", StringComparison.OrdinalIgnoreCase))
                Console.WriteLine($"{track.Label}: {line}");
        }
    }
}
```

## **Estrarre audio**

Una transizione di diapositiva può avere un suono proprio. Per recuperarlo, leggi la proprietà [Sound](https://reference.aspose.com/slides/net/aspose.slides/islideshowtransition/sound/) della transizione. L’esempio accede ai [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) del suono e stampa la sua dimensione in byte. Se la prima diapositiva non ha un suono di transizione, stampa invece un messaggio.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("AudioSlide.pptx");
var slide = presentation.Slides[0];

var sound = slide.SlideShowTransition.Sound;
if (sound == null)
{
    Console.WriteLine("The first slide has no transition sound.");
    return;
}

var audioData = sound.BinaryData;
Console.WriteLine($"Transition sound: {audioData.Length} bytes.");
```

## **FAQ**

**Posso riutilizzare la stessa clip audio in più diapositive senza duplicarla?**

Sì. Aggiungi la clip una sola volta alla [audio collection](https://reference.aspose.com/slides/net/aspose.slides/presentation/audios/) della presentazione e passa lo stesso oggetto audio a [AddAudioFrameEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addaudioframeembedded/) per ogni diapositiva.

**Posso sostituire il suono in un frame audio esistente?**

Sì. Per un suono collegato, aggiorna [LinkPathLong](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/linkpathlong/) per puntare al file sostitutivo. Per un suono incorporato, assegna un’altra clip dalla collezione audio della presentazione a [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/). Entrambi gli approcci conservano il frame esistente.

**Il ritaglio modifica i dati audio memorizzati nella presentazione?**

No. [TrimFromStart](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromstart/) e [TrimFromEnd](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/trimfromend/) impostano i limiti di riproduzione. È ancora possibile recuperare la clip completa da [EmbeddedAudio](https://reference.aspose.com/slides/net/aspose.slides/iaudioframe/embeddedaudio/).