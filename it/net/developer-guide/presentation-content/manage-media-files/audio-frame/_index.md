---
title: Gestisci i frame audio nelle presentazioni in .NET
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
description: "Crea e controlla i frame audio in Aspose.Slides per .NET — esempi C# per incorporare, ritagliare, ripetere e configurare la riproduzione su presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i frame audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare la miniatura del frame audio, configurare le opzioni di riproduzione come volume, ripetizione, nascondere, ritaglio e durate di dissolvenza, ed estrarre l'audio utilizzato nelle transizioni della presentazione.

## **Crea frame audio**

Aspose.Slides per .NET consente di aggiungere file audio alle diapositive. I file audio vengono incorporati nelle diapositive come frame audio. 

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation).
2. Ottieni il riferimento di una diapositiva tramite il suo indice.
3. Carica lo stream del file audio che desideri incorporare nella diapositiva.
4. Aggiungi il frame audio incorporato (contenente il file audio) alla diapositiva.
5. Imposta [PlayMode](https://reference.aspose.com/slides/it/net/aspose.slides/audioplaymodepreset) e `Volume` esposti dall'oggetto [IAudioFrame](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe).
6. Salva la presentazione modificata.

Questo codice C# mostra come aggiungere un frame audio incorporato a una diapositiva:

```c#
// Crea un'istanza della classe Presentation che rappresenta un file di presentazione
using (Presentation pres = new Presentation())
{
    // Ottiene la prima diapositiva
    ISlide sld = pres.Slides[0];
    
    // Carica il file audio wav nello stream
    FileStream fstr = new FileStream("sampleaudio.wav", FileMode.Open, FileAccess.Read);

    // Aggiunge il frame audio
    IAudioFrame audioFrame = sld.Shapes.AddAudioFrameEmbedded(50, 150, 100, 100, fstr);

    // Imposta la modalità di riproduzione e il volume dell'audio
    audioFrame.PlayMode = AudioPlayModePreset.Auto;
    audioFrame.Volume = AudioVolumeMode.Loud;

    // Scrive il file PowerPoint su disco
    pres.Save("AudioFrameEmbed_out.pptx", SaveFormat.Pptx);
}
```

## **Modifica la miniatura del frame audio**

Quando aggiungi un file audio a una presentazione, l'audio appare come un frame con un'immagine predefinita standard (vedi l'immagine nella sezione seguente). Puoi modificare la miniatura del frame audio (impostare l'immagine preferita).

Questo codice C# mostra come modificare la miniatura o l'immagine di anteprima di un frame audio:

```c#
using (var presentation = new Presentation())
{
    var slide = presentation.Slides[0];

    // Aggiunge un frame audio alla diapositiva con una posizione e dimensione specificate.
    var audioStream = new FileStream("sample2.mp3", FileMode.Open, FileAccess.Read);
    var audioFrame = slide.Shapes.AddAudioFrameEmbedded(150, 100, 50, 50, audioStream);
    audioStream.Dispose();

    // Aggiunge un'immagine alle risorse della presentazione.
    var imageStream = File.OpenRead("eagle.jpeg");
    var audioImage = presentation.Images.AddImage(imageStream);
    imageStream.Dispose();

    // Imposta l'immagine per il frame audio.
    audioFrame.PictureFormat.Picture.Image = audioImage; // <-----
    
	// Salva la presentazione modificata su disco
    presentation.Save("example_out.pptx", SaveFormat.Pptx);
}
```

## **Modifica le opzioni di riproduzione audio**

Aspose.Slides per .NET consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume dell'audio, impostare l'audio per la riproduzione in loop o anche nascondere l'icona dell'audio.

Il riquadro **Audio Options** in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Audio Options** di PowerPoint corrispondono alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe):

- **Start** il menu a discesa corrisponde alla proprietà [AudioFrame.PlayMode](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/properties/playmode)
- **Volume** corrisponde alla proprietà [AudioFrame.Volume](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/properties/volume)
- **Play Across Slides** corrisponde alla proprietà [AudioFrame.PlayAcrossSlides](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/properties/playacrossslides)
- **Loop until Stopped** corrisponde alla proprietà [AudioFrame.PlayLoopMode](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/properties/playloopmode)
- **Hide During Show** corrisponde alla proprietà [AudioFrame.HideAtShowing](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/properties/hideatshowing)
- **Rewind after Playing** corrisponde alla proprietà [AudioFrame.RewindAudio ](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/properties/rewindaudio)

Le opzioni **Editing** di PowerPoint corrispondono alle proprietà di Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe):

- **Fade In** corrisponde alla proprietà [AudioFrame.FadeInDuration](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/fadeinduration/)
- **Fade Out** corrisponde alla proprietà [AudioFrame.FadeOutDuration](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/fadeoutduration/)
- **Trim Audio Start Time** corrisponde alla proprietà [AudioFrame.TrimFromStart](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/trimfromstart/)
- **Trim Audio End Time** il valore è uguale alla durata dell'audio meno il valore della proprietà [AudioFrame.TrimFromEnd](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/trimfromend/)

Il controllo **Volume** sul pannello di controllo audio di PowerPoint corrisponde alla proprietà [AudioFrame.VolumeValue](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/volumevalue/). Permette di modificare il volume dell'audio in percentuale.

Ecco come modificare le opzioni di riproduzione audio:

1. [Crea](#create-audio-frame) o ottieni il frame audio.
2. Imposta nuovi valori per le proprietà del frame audio che desideri modificare.
3. Salva il file PowerPoint modificato.

Questo codice C# dimostra un'operazione in cui le opzioni di un audio vengono regolate:

``` csharp 
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Ottiene la forma AudioFrame
    AudioFrame audioFrame = (AudioFrame)pres.Slides[0].Shapes[0];

    // Imposta la modalità di riproduzione su click
    audioFrame.PlayMode = AudioPlayModePreset.OnClick;

    // Imposta il volume su Basso
    audioFrame.Volume = AudioVolumeMode.Low;

    // Imposta l'audio per la riproduzione su tutte le diapositive
    audioFrame.PlayAcrossSlides = true;

    // Disabilita il loop per l'audio
    audioFrame.PlayLoopMode = false;

    // Nasconde il AudioFrame durante la presentazione
    audioFrame.HideAtShowing = true;

    // Riavvolge l'audio all'inizio dopo la riproduzione
    audioFrame.RewindAudio = true;

    // Salva il file PowerPoint su disco
    pres.Save("AudioFrameEmbed_changed.pptx", SaveFormat.Pptx);
}
```

Questo esempio C# mostra come aggiungere un nuovo frame audio con audio incorporato, ritagliarlo e impostare le durate di dissolvenza:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] audioData = File.ReadAllBytes("sampleaudio.mp3");
    IAudio audio = pres.Audios.AddAudio(audioData);
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(50, 50, 100, 100, audio);

    // Imposta l'offset di inizio del ritaglio a 1,5 secondi
    audioFrame.TrimFromStart = 1500f;
    // Imposta l'offset di fine del ritaglio a 2 secondi
    audioFrame.TrimFromEnd = 2000f;

    // Imposta la durata della dissolvenza in ingresso a 200 ms
    audioFrame.FadeInDuration = 200f;
    // Imposta la durata della dissolvenza in uscita a 500 ms
    audioFrame.FadeOutDuration = 500f;

    pres.Save("AudioFrameTrimFade_out.pptx", SaveFormat.Pptx);
}
```

Il seguente esempio di codice mostra come recuperare un frame audio con audio incorporato e impostare il suo volume al 85%:

```c#
using (Presentation pres = new Presentation("AudioFrameEmbed_out.pptx"))
{
    // Ottiene una forma di frame audio
    IAudioFrame audioFrame = (IAudioFrame)pres.Slides[0].Shapes[0];

    // Imposta il volume dell'audio all'85%
    audioFrame.VolumeValue = 85f;
    
    pres.Save("AudioFrameValue_out.pptx", SaveFormat.Pptx);
}
```

## **Gestisci i sottotitoli audio**

Aspose.Slides consente di aggiungere didascalie chiuse a un frame audio tramite la proprietà [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/iaudioframe/captiontracks/). Questa proprietà restituisce un [ICaptionsCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/), che consente di aggiungere tracce di sottotitoli WebVTT, iterare le tracce esistenti e rimuoverle quando necessario.

**Aggiungi sottotitoli audio**

Utilizza la proprietà [CaptionTracks](https://reference.aspose.com/slides/it/net/aspose.slides/iaudioframe/captiontracks/) per allegare una o più tracce di sottotitoli a un frame audio. Nell'esempio seguente, un file audio viene aggiunto a una diapositiva, quindi viene caricata una nuova traccia di sottotitoli da un file `.vtt`.

```cs
using (Presentation presentation = new Presentation())
{
    byte[] audioData = File.ReadAllBytes("audio.mp3");
    IAudio audio = presentation.Audios.AddAudio(audioData);

    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes.AddAudioFrameEmbedded(10, 10, 50, 50, audio);

    // Aggiunge una nuova traccia di didascalie da un file WebVTT.
    audioFrame.CaptionTracks.Add("New track", "track.vtt");

    presentation.Save("audio_with_captions.pptx", SaveFormat.Pptx);
}
```

**Estrai i sottotitoli audio**

Puoi iterare le tracce di sottotitoli associate a un frame audio e salvarle come file `.vtt`. Ogni traccia di sottotitoli espone i suoi dati binari e l'identificatore univoco, che può essere utilizzato durante l'esportazione dei sottotitoli.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    foreach (IShape shape in slide.Shapes)
    {
        if (shape is IAudioFrame audioFrame)
        {
            foreach (ICaptions captionTrack in audioFrame.CaptionTracks)
            {
                // Salva la traccia di sottotitoli come file .vtt.
                File.WriteAllBytes($"{captionTrack.CaptionId}.vtt", captionTrack.BinaryData);
            }
        }
    }
}
```

**Rimuovi i sottotitoli audio**

Per rimuovere i sottotitoli da un frame audio, utilizza i metodi forniti da [ICaptionsCollection](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/), come [Clear](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/remove/), o [RemoveAt](https://reference.aspose.com/slides/it/net/aspose.slides/icaptionscollection/removeat/). L'esempio seguente rimuove tutte le tracce di sottotitoli da un frame audio.

```cs
using (Presentation presentation = new Presentation("audio_with_captions.pptx"))
{
    ISlide slide = presentation.Slides[0];
    IAudioFrame audioFrame = slide.Shapes[0] as IAudioFrame;

    // Rimuove tutte le tracce di sottotitoli dal frame audio.
    audioFrame.CaptionTracks.Clear();

    presentation.Save("audio_without_captions.pptx", SaveFormat.Pptx);
}
```

## **Estrai audio**

Aspose.Slides per .NET consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono usato in una diapositiva specifica.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/net/aspose.slides/presentation) e carica la presentazione contenente l'audio.
2. Ottieni il riferimento della diapositiva pertinente tramite il suo indice.
3. Accedi alle transizioni della presentazione per la diapositiva.
4. Estrai il suono in dati byte.

Questo codice C# mostra come estrarre l'audio utilizzato in una diapositiva:

```c#
string presName = "AudioSlide.pptx";

// Crea un'istanza della classe Presentation che rappresenta un file di presentazione
Presentation pres = new Presentation(presName);

// Accesses the slide
ISlide slide = pres.Slides[0];

// Gets the slideshow transition effects for the slide
ISlideShowTransition transition = slide.SlideShowTransition;

//Extracts the sound in byte array
byte[] audio = transition.Sound.BinaryData;

System.Console.WriteLine("Length: " + audio.Length);
```

## **FAQ**

**Posso riutilizzare lo stesso asset audio su più diapositive senza aumentare le dimensioni del file?**

Sì. Aggiungi l'audio una sola volta alla [audio collection](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/audios/) condivisa della presentazione e crea ulteriori frame audio che fanno riferimento a quell'asset esistente. Questo evita la duplicazione dei dati multimediali e mantiene le dimensioni della presentazione sotto controllo.

**Posso sostituire il suono in un frame audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiorna il [link path](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/linkpathlong/) per puntare al nuovo file. Per un suono incorporato, sostituisci l'oggetto [embedded audio](https://reference.aspose.com/slides/it/net/aspose.slides/audioframe/embeddedaudio/) con un altro della [audio collection](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/audios/) della presentazione. La formattazione del frame e la maggior parte delle impostazioni di riproduzione rimangono inalterate.

**Il ritaglio modifica i dati audio sottostanti archiviati nella presentazione?**

No. Il ritaglio regola solo i limiti di riproduzione. I byte originali dell'audio rimangono intatti e accessibili tramite l'audio incorporato o la [audio collection](https://reference.aspose.com/slides/it/net/aspose.slides/presentation/audios/) della presentazione.