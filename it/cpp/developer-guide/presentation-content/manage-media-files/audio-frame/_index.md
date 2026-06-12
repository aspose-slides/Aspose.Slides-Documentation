---
title: Gestire l'audio nelle presentazioni usando C++
linktitle: Fotogramma audio
type: docs
weight: 10
url: /it/cpp/audio-frame/
keywords:
- audio
- fotogramma audio
- miniatura
- aggiungi audio
- proprietà audio
- opzioni audio
- estrai audio
- C++
- Aspose.Slides
description: "Crea e controlla i fotogrammi audio in Aspose.Slides per C++ — esempi di codice per incorporare, ritagliare, eseguire in loop e configurare la riproduzione in presentazioni PPT, PPTX e ODP."
---
## **Panoramica**

Questo articolo spiega come lavorare con i fotogrammi audio in Aspose.Slides. Mostra come aggiungere audio incorporato alle diapositive, personalizzare l'anteprima del fotogramma audio, configurare le opzioni di riproduzione come volume, ciclo, nascondere, ritaglio e durate di dissolvenza, ed estrarre l'audio utilizzato nelle transizioni della presentazione.

## **Creare fotogrammi audio**

Aspose.Slides per C++ consente di aggiungere file audio alle diapositive. I file audio sono incorporati nelle diapositive come fotogrammi audio.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation).
2. Ottenere il riferimento a una diapositiva tramite il suo indice.
3. Caricare lo stream del file audio da incorporare nella diapositiva.
4. Aggiungere il fotogramma audio incorporato (contenente il file audio) alla diapositiva.
5. Impostare [PlayMode](https://reference.aspose.com/slides/it/cpp/namespace/aspose.slides#a1e0dfa632c5498e693145d42f3cf8e4c) e `Volume` esposti dall'oggetto [IAudioFrame](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.i_audio_frame).
6. Salvare la presentazione modificata.

Questo codice C++ mostra come aggiungere un fotogramma audio incorporato a una diapositiva:

``` cpp
// Istanzia una classe Presentation che rappresenta un file di presentazione
auto pres = System::MakeObject<Presentation>();

// Ottiene la prima diapositiva
auto sld = pres->get_Slides()->idx_get(0);

// Carica il file audio wav nello stream
auto fstr = System::MakeObject<FileStream>(u"sampleaudio.wav", FileMode::Open, FileAccess::Read);

// Aggiunge il fotogramma audio
auto audioFrame = sld->get_Shapes()->AddAudioFrameEmbedded(50.0f, 150.0f, 100.0f, 100.0f, fstr);

// Imposta la modalità di riproduzione e il volume dell'audio
audioFrame->set_PlayMode(AudioPlayModePreset::Auto);
audioFrame->set_Volume(AudioVolumeMode::Loud);

// Scrive il file PowerPoint su disco
pres->Save(u"AudioFrameEmbed_out.pptx", SaveFormat::Pptx);
```

## **Modificare l'anteprima del fotogramma audio**

Quando si aggiunge un file audio a una presentazione, l'audio appare come un fotogramma con un'immagine predefinita standard (vedi l'immagine nella sezione sottostante). È possibile cambiare l'anteprima del fotogramma audio (impostare l'immagine preferita).

Questo codice C++ mostra come modificare l'anteprima o l'immagine di anteprima di un fotogramma audio:

```cpp
auto presentation = System::MakeObject<Presentation>();
        
auto slide = presentation->get_Slides()->idx_get(0);
        
// Aggiunge un fotogramma audio alla diapositiva con una posizione e dimensione specificate.
auto audioStream = System::MakeObject<System::IO::FileStream>(u"sample2.mp3", 
    System::IO::FileMode::Open, System::IO::FileAccess::Read);
    
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(150.0f, 100.0f, 50.0f, 50.0f, audioStream);
            
// Aggiunge un'immagine alle risorse della presentazione.
auto imageStream = System::IO::File::OpenRead(u"eagle.jpeg");
auto audioImage = presentation->get_Images()->AddImage(imageStream);
            
// Imposta l'immagine per il fotogramma audio.
audioFrame->get_PictureFormat()->get_Picture()->set_Image(audioImage); // <-----
        
//Salva la presentazione modificata su disco
presentation->Save(u"example_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Modificare le opzioni di riproduzione audio**

Aspose.Slides per C++ consente di modificare le opzioni che controllano la riproduzione o le proprietà di un audio. Ad esempio, è possibile regolare il volume, impostare la riproduzione in ciclo o nascondere l'icona audio.

Il riquadro **Audio Options** in Microsoft PowerPoint:

![example1_image](audio_frame_0.png)

Le **Audio Options** di PowerPoint corrispondono ai metodi Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/):

- **Start** corrisponde al metodo [AudioFrame::set_PlayMode](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_playmode/)
- **Volume** corrisponde al metodo [AudioFrame::set_Volume](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_volume/)
- **Play Across Slides** corrisponde al metodo [AudioFrame::set_PlayAcrossSlides](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_playacrossslides/)
- **Loop until Stopped** corrisponde al metodo [AudioFrame::set_PlayLoopMode](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_playloopmode/)
- **Hide During Show** corrisponde al metodo [AudioFrame::set_HideAtShowing](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_hideatshowing/)
- **Rewind after Playing** corrisponde al metodo [AudioFrame::set_RewindAudio](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_rewindaudio/)

Le opzioni di **Editing** di PowerPoint corrispondono alle proprietà Aspose.Slides [AudioFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/):

- **Fade In** corrisponde al metodo [AudioFrame.set_FadeInDuration](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_fadeinduration/)
- **Fade Out** corrisponde al metodo [AudioFrame.set_FadeOutDuration](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_fadeoutduration/)
- **Trim Audio Start Time** corrisponde al metodo [AudioFrame.set_TrimFromStart](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_trimfromstart/)
- **Trim Audio End Time** corrisponde al metodo [AudioFrame.set_TrimFromEnd](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_trimfromend/)

Il controllo **Volume** del pannello audio di PowerPoint corrisponde al metodo [AudioFrame.set_VolumeValue](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_volumevalue/). Consente di modificare il volume audio in percentuale.

Ecco come modificare le opzioni di riproduzione audio:

1. [Create](#creating-audio-frame) o recuperare il fotogramma audio.
2. Impostare nuovi valori per le proprietà del fotogramma audio da modificare.
3. Salvare il file PowerPoint modificato.

Questo codice C++ dimostra un'operazione in cui le opzioni di un audio vengono regolate:

``` cpp
auto pres = System::MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");

// Ottiene una forma
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0);

// Effettua il cast della forma a AudioFrame
auto audioFrame = System::ExplicitCast<AudioFrame>(shape);

// Imposta la modalità di riproduzione per avviare al clic
audioFrame->set_PlayMode(AudioPlayModePreset::OnClick);

// Imposta il volume su Basso
audioFrame->set_Volume(AudioVolumeMode::Low);

// Imposta l'audio per riprodursi su più diapositive
audioFrame->set_PlayAcrossSlides(true);

// Disabilita il ciclo per l'audio
audioFrame->set_PlayLoopMode(false);

// Nasconde il fotogramma audio durante la presentazione
audioFrame->set_HideAtShowing(true);

// Riavvolge l'audio all'inizio dopo la riproduzione
audioFrame->set_RewindAudio(true);

// Salva il file PowerPoint su disco
pres->Save(u"AudioFrameEmbed_changed.pptx", SaveFormat::Pptx);
```

Questo esempio C++ mostra come aggiungere un nuovo fotogramma audio con audio incorporato, ritagliarlo e impostare le durate di dissolvenza:

```cpp
auto pres = MakeObject<Presentation>();
auto slide = pres->get_Slide(0);

auto audioData = File::ReadAllBytes(u"sampleaudio.mp3");
auto audio = pres->get_Audios()->AddAudio(audioData);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(50, 50, 100, 100, audio);

// Sets the trimming start offset to 1.5 seconds
audioFrame->set_TrimFromStart(1500);
// Sets the trimming end offset to 2 seconds
audioFrame->set_TrimFromEnd(2000);

// Sets the fade-in duration to 200 ms
audioFrame->set_FadeInDuration(200);
// Sets the fade-out duration to 500 ms
audioFrame->set_FadeOutDuration(500);

pres->Save(u"AudioFrameTrimFade_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

Il seguente esempio di codice mostra come recuperare un fotogramma audio con audio incorporato e impostarne il volume all'85%:

```cpp
auto pres = MakeObject<Presentation>(u"AudioFrameEmbed_out.pptx");
    
// Ottiene una forma di fotogramma audio
auto audioFrame = ExplicitCast<IAudioFrame>(pres->get_Slide(0)->get_Shape(0));

// Imposta il volume audio al 85%
audioFrame->set_VolumeValue(85);

pres->Save(u"AudioFrameValue_out.pptx", SaveFormat::Pptx);
pres->Dispose();
```

## **Gestire i sottotitoli audio**

Aspose.Slides consente di aggiungere sottotitoli chiusi a un fotogramma audio tramite il metodo [get_CaptionTracks](https://reference.aspose.com/slides/it/cpp/aspose.slides/iaudioframe/get_captiontracks/). Questo metodo restituisce un [ICaptionsCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/), che permette di aggiungere tracce di sottotitoli WebVTT, iterare le tracce esistenti e rimuoverle quando necessario.

**Aggiungere sottotitoli audio**

Utilizzare il metodo [get_CaptionTracks](https://reference.aspose.com/slides/it/cpp/aspose.slides/iaudioframe/get_captiontracks/) per collegare una o più tracce di sottotitoli a un fotogramma audio. Nell'esempio seguente, un file audio viene aggiunto a una diapositiva, quindi viene caricata una nuova traccia di sottotitoli da un file `.vtt`.

```cpp
auto presentation = MakeObject<Presentation>();

auto audioData = File::ReadAllBytes(u"audio.mp3");
auto audio = presentation->get_Audios()->AddAudio(audioData);

auto slide = presentation->get_Slide(0);
auto audioFrame = slide->get_Shapes()->AddAudioFrameEmbedded(10, 10, 50, 50, audio);

// Add a new caption track from a WebVTT file.
audioFrame->get_CaptionTracks()->Add(u"New track", u"track.vtt");

presentation->Save(u"audio_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Estrarre i sottotitoli audio**

È possibile iterare le tracce di sottotitoli associate a un fotogramma audio e salvarle come file `.vtt`. Ogni traccia espone i propri dati binari e un identificatore univoco, utilizzabile durante l'esportazione dei sottotitoli.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IAudioFrame>(shape))
    {
        auto audioFrame = ExplicitCast<IAudioFrame>(shape);
        for (auto&& captionTrack : audioFrame->get_CaptionTracks())
        {
            // Salva ogni traccia di sottotitolo come file .vtt.
            auto fileName = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(fileName, captionTrack->get_BinaryData());
        }
    }
}
presentation->Dispose();
```

**Rimuovere i sottotitoli audio**

Per rimuovere i sottotitoli da un fotogramma audio, utilizzare i metodi forniti da [ICaptionsCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/), come [Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/clear/), [Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/remove/), o [RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/removeat/). L'esempio seguente rimuove tutte le tracce di sottotitoli da un fotogramma audio.

```cpp
auto presentation = MakeObject<Presentation>(u"audio_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto audioFrame = ExplicitCast<IAudioFrame>(slide->get_Shape(0));

// Rimuove tutte le tracce di sottotitoli dal fotogramma audio.
audioFrame->get_CaptionTracks()->Clear();

presentation->Save(u"audio_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Estrarre l'audio**
Aspose.Slides consente di estrarre il suono utilizzato nelle transizioni della presentazione. Ad esempio, è possibile estrarre il suono usato in una diapositiva specifica.

1. Creare un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/class/aspose.slides.presentation) e caricare la presentazione contenente l'audio.
2. Ottenere il riferimento alla diapositiva pertinente tramite il suo indice.
3. Accedere alle transizioni della presentazione per la diapositiva.
4. Estrarre il suono in dati binari.

Questo codice C++ mostra come estrarre l'audio usato in una diapositiva:

``` cpp
String presName = u"AudioSlide.pptx";

// Istanzia una classe Presentation che rappresenta un file di presentazione
auto pres = System::MakeObject<Presentation>(presName);

// Accede alla diapositiva desiderata
auto slide = pres->get_Slides()->idx_get(0);

// Ottiene gli effetti di transizione della presentazione per la diapositiva
auto transition = slide->get_SlideShowTransition();

// Estrae il suono in un array di byte
auto audio = transition->get_Sound()->get_BinaryData();

Console::WriteLine(String(u"Length: ") + audio->get_Length());
```

## **FAQ**

**Posso riutilizzare lo stesso asset audio su più diapositive senza aumentare le dimensioni del file?**

Sì. Aggiungere l'audio una sola volta alla [collezione audio condivisa](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_audios/) della presentazione e creare fotogrammi audio aggiuntivi che facciano riferimento a quell'asset esistente. Questo evita la duplicazione dei dati multimediali e mantiene la dimensione della presentazione sotto controllo.

**Posso sostituire il suono in un fotogramma audio esistente senza ricreare la forma?**

Sì. Per un suono collegato, aggiornare il [link path](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_linkpathlong/) per puntare al nuovo file. Per un suono incorporato, scambiare l'oggetto [embedded audio](https://reference.aspose.com/slides/it/cpp/aspose.slides/audioframe/set_embeddedaudio/) con un altro presente nella [collezione audio](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/get_audios/) della presentazione. La formattazione del fotogramma e la maggior parte delle impostazioni di riproduzione rimangono intatte.

**Il ritaglio modifica i dati audio sottostanti memorizzati nella presentazione?**

No. Il ritaglio regola solo i limiti di riproduzione. I byte audio originali rimangono inalterati e accessibili tramite l'audio incorporato o la collezione audio della presentazione.