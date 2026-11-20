---
title: Gestire i fotogrammi video nelle presentazioni usando C++
linktitle: Fotogramma video
type: docs
weight: 10
url: /it/cpp/video-frame/
keywords:
- aggiungi video
- crea video
- incorpora video
- estrai video
- recupera video
- fotogramma video
- fonte web
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i fotogrammi video in presentazioni PowerPoint e OpenDocument usando Aspose.Slides per C++. Guida rapida pratica."
---
## **Introduzione**

I video possono aiutare a spiegare idee e coinvolgere il pubblico. Aspose.Slides for C++ consente di aggiungere fotogrammi video alle diapositive, regolare le impostazioni di riproduzione, gestire i sottotitoli e estrarre i dati video incorporati.

PowerPoint supporta video locali e collegamenti a video online, come i video di YouTube.

Per rappresentare i dati video e i fotogrammi video, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) e altri tipi pertinenti.

## **Crea un Fotogramma Video Incorporato**

Se il file video che desideri aggiungere alla diapositiva è memorizzato localmente, è possibile creare un fotogramma video per incorporare il video nella presentazione.

Questo esempio incorpora un video locale nella prima diapositiva di una presentazione esistente e salva il risultato. Le coordinate e le dimensioni del fotogramma sono in punti. Lo stream rimane aperto fino al completamento del salvataggio perché [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) lo mantiene bloccato mentre la presentazione lo utilizza.

```cpp
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <Export/SaveFormat.h>
#include <LoadingStreamBehavior.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto videoStream = File::OpenRead(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::KeepLocked);
slide->get_Shapes()->AddVideoFrame(10, 10, 150, 250, video);

presentation->Save(u"embedded_video.pptx", SaveFormat::Pptx);

presentation->Dispose();
videoStream->Dispose();
```

È inoltre possibile passare direttamente un percorso video locale a [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Questo esempio incorpora il video nella prima diapositiva di una nuova presentazione. Il video deve rimanere accessibile fino al salvataggio della presentazione.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

slide->get_Shapes()->AddVideoFrame(50, 150, 300, 150, u"video.avi");

presentation->Save(u"video_from_path.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Crea un Fotogramma Video con Video da una Fonte Web**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) supporta video online nelle presentazioni. È possibile creare un fotogramma video che collega a un video online, come un video di YouTube.

Questo esempio aggiunge un collegamento a un video di YouTube e la sua miniatura nella prima diapositiva. Sostituisci l'identificatore del video per usare un altro video. Il metodo [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) richiede la riproduzione automatica. Il download della miniatura e la riproduzione del video richiedono l'accesso a Internet. Il visualizzatore della presentazione deve inoltre supportare la riproduzione di video online.

```cpp
#include <net/web_client.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/VideoPlayModePreset.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPictureFillFormat.h>
#include <DOM/ISlidesPicture.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);


auto webClient = MakeObject<System::Net::WebClient>();

String videoId = u"aqz-KE-bpKQ";
auto videoUrl = String::Format(u"https://www.youtube.com/embed/{0}", videoId);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240, videoUrl);
videoFrame->set_PlayMode(VideoPlayModePreset::Auto);

auto thumbnailUrl = String::Format(u"https://img.youtube.com/vi/{0}/hqdefault.jpg", videoId);
auto thumbnailData = webClient->DownloadData(thumbnailUrl);
auto thumbnail = presentation->get_Images()->AddImage(thumbnailData);
videoFrame->get_PictureFormat()->get_Picture()->set_Image(thumbnail);

presentation->Save(u"online_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Riproduci un Video in Modalità Schermo Intero**

Nella presentazione formativa, è possibile riprodurre una dimostrazione software in modalità schermo intero in modo che il pubblico possa vedere i dettagli. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) accetta `true` per abilitare questo comportamento durante la riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) nella prima diapositiva e abilita la riproduzione a schermo intero. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_FullScreenMode(true);
        break;
    }
}

presentation->Save(u"full_screen_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

La riproduzione a schermo intero controlla come viene visualizzato il video. In modo indipendente, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) controlla se inizia automaticamente o al clic, e [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) controlla se si ripete. Per scegliere il comportamento d'avvio, impostare la modalità di riproduzione su [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). L'esempio conserva le impostazioni di avvio e di ciclo esistenti.

## **Riavvolgi un Video dopo la Riproduzione**

Nella presentazione formativa, riportare un video dimostrativo all'inizio lo rende pronto per il presentatore a riprodurlo nuovamente. Chiamare [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) con `true` per riportare il video all'inizio dopo la fine della riproduzione.

Questo esempio apre una presentazione, trova il primo [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) nella prima diapositiva e abilita il riavvolgimento. Disabilita il ciclo in modo che la riproduzione possa terminare e imposta la riproduzione per avviarsi al clic. La presentazione di input deve contenere almeno una diapositiva con un fotogramma video esistente nella prima diapositiva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <DOM/VideoPlayModePreset.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"training.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        videoFrame->set_RewindVideo(true);
        videoFrame->set_PlayLoopMode(false);
        videoFrame->set_PlayMode(VideoPlayModePreset::OnClick);
        break;
    }
}

presentation->Save(u"rewind_video.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Il riavvolgimento riporta il video all'inizio senza avviarlo nuovamente. Al contrario, abilitare [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) ripete la riproduzione automaticamente. Mantenere il ciclo disabilitato quando si desidera che il video termini e rimanga pronto per una nuova riproduzione. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) controlla in modo indipendente l'avvio automatico o al clic; questo esempio utilizza [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) così il presentatore controlla quando inizia la riproduzione. Impostare la modalità di riproduzione dopo l'impostazione del ciclo, come mostrato nell'esempio. Il riavvolgimento funziona indipendentemente da [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Ritaglia un Fotogramma Video**

Utilizzare [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) e [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) per saltare una parte dell'inizio o della fine di un video durante la riproduzione. Entrambi i valori sono in millisecondi. Il ritaglio modifica le impostazioni di riproduzione senza modificare i dati video incorporati.

**Imposta Impostazioni di Ritaglio**

Questo esempio incorpora un video locale e salta i primi 2,5 secondi e l'ultimo secondo durante la riproduzione. Utilizzare un video più lungo di 3,5 secondi in modo che rimanga un segmento riproducibile.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);
videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Leggi Impostazioni di Ritaglio**

Questo esempio stampa i valori di ritaglio del primo fotogramma video nella prima diapositiva in millisecondi. La presentazione deve contenere almeno una diapositiva. Se quella diapositiva non ha un fotogramma video, non viene stampato nulla. L'esempio precedente produce valori di 2500 e 1000.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        Console::WriteLine(String::Format(u"Trim from start: {0} ms", videoFrame->get_TrimFromStart()));
        Console::WriteLine(String::Format(u"Trim from end: {0} ms", videoFrame->get_TrimFromEnd()));
        break;
    }
}

presentation->Dispose();
```

## **Gestisci i Sottotitoli Video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i fotogrammi video nelle presentazioni PowerPoint. I sottotitoli sono archiviati in formato WebVTT e sono accessibili tramite il metodo [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

### **Aggiungi Sottotitoli a un Fotogramma Video**

Questo esempio incorpora un video locale e aggiunge una traccia di sottotitoli WebVTT etichettata English. I timestamp dei sottotitoli dovrebbero corrispondere al video. La presentazione salvata include sia il video sia i suoi sottotitoli.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) fornisce anche un overload che consente di aggiungere i sottotitoli da uno stream.

### **Estrai i Sottotitoli da un Fotogramma Video**

Questo esempio salva tutte le tracce di sottotitoli dai fotogrammi video nella prima diapositiva come file WebVTT separati. I numeri sequenziali mantengono i file di output distinti. La console riporta il numero di tracce estratte. La presentazione deve contenere almeno una diapositiva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto trackCount = 0;
for (auto&& shape : IterateOver(slide->get_Shapes()))
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : IterateOver(videoFrame->get_CaptionTracks()))
        {
            trackCount++;
            auto outputPath = String::Format(u"captions_{0}.vtt", trackCount);
            File::WriteAllBytes(outputPath, captionTrack->get_BinaryData());
        }
    }
}

Console::WriteLine(String::Format(u"Caption tracks extracted: {0}", trackCount));

presentation->Dispose();
```

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e il testo del sottotitolo come stringa UTF-8.

### **Rimuovi i Sottotitoli da un Fotogramma Video**

Questo esempio rimuove tutti i sottotitoli dal fotogramma video nella prima posizione della forma sulla prima diapositiva e salva il risultato. Si assume che la diapositiva e la forma esistano e che la forma sia un fotogramma video.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <Export/SaveFormat.h>
#include <DOM/ICaptionsCollection.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se è necessario rimuovere solo una traccia di sottotitoli, utilizzare i metodi [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) invece di [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

### **Cerca Sottotitoli Video**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) restituisce l'intera traccia WebVTT, inclusi l'intestazione, le linee di temporizzazione e il testo dei sottotitoli. Per trovare una frase pronunciata e il suo timestamp, leggere i cue in memoria. Ad esempio, una traccia English nella diapositiva 2 potrebbe contenere il seguente testo:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

L'esempio apre `captioned_media.pptx` e legge le tracce di sottotitoli di ogni fotogramma video di livello superiore in ogni diapositiva utilizzando [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/). In un cue di testo semplice, la linea di temporizzazione contiene `-->` e una riga vuota termina il cue. Quando il sottotitolo contiene “café”, l'esempio stampa il numero della diapositiva, l'etichetta della traccia, la linea di temporizzazione originale e il sottotitolo completo. La ricerca ignora maiuscole/minuscole.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ICaptionsCollection.h>
#include <DOM/ICaptions.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/string_reader.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"captioned_media.pptx");
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        auto videoFrame = AsCast<IVideoFrame>(shape);
        if (!videoFrame)
            continue;

        for (auto&& track : IterateOver(videoFrame->get_CaptionTracks()))
        {
            auto reader = MakeObject<StringReader>(track->get_DataAsString());
            for (auto timing = reader->ReadLine(); !timing.IsNull(); timing = reader->ReadLine())
            {
                if (!timing.Contains(u"-->"))
                    continue;

                String caption;
                for (auto line = reader->ReadLine(); !String::IsNullOrEmpty(line); line = reader->ReadLine())
                {
                    if (!String::IsNullOrEmpty(caption))
                        caption += u"\n";
                    caption += line;
                }

                if (caption.IndexOf(u"caf\u00E9", StringComparison::OrdinalIgnoreCase) >= 0)
                {
                    Console::WriteLine(String::Format(u"Slide {0} | {1} | {2}", slide->get_SlideNumber(), track->get_Label(), timing));
                    Console::WriteLine(caption);
                }
            }
        }
    }
}
presentation->Dispose();
```

La ricerca di “café” produce una corrispondenza per la traccia di esempio. La ricerca salta l'intestazione e preserva l'impostazione di temporizzazione nell'output.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Estrai Video da una Diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

Questo esempio estrae i video incorporati da ogni diapositiva in file binari separati e numerati. I video collegati vengono ignorati perché non hanno dati incorporati. La console stampa il tipo MIME di ogni video e il conteggio totale. L'output utilizza l'estensione generica `.bin`; cambiarla per corrispondere al tipo di media segnalato quando necessario.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IVideoFrame.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IVideo.h>
#include <system/io/file.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"presentation_with_videos.pptx");

auto videoCount = 0;
for (auto&& slide : IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IVideoFrame>(shape))
        {
            auto videoFrame = ExplicitCast<IVideoFrame>(shape);
            auto video = videoFrame->get_EmbeddedVideo();
            if (video == nullptr)
            {
                Console::WriteLine(u"Skipped a linked video: no embedded data is available.");
                continue;
            }

            videoCount++;
            auto outputPath = String::Format(u"extracted_video_{0}.bin", videoCount);
            File::WriteAllBytes(outputPath, video->get_BinaryData());
            Console::WriteLine(String::Format(u"Video {0}: {1}", videoCount, video->get_ContentType()));
        }
    }
}

Console::WriteLine(String::Format(u"Embedded videos extracted: {0}", videoCount));

presentation->Dispose();
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un fotogramma video?**

È possibile controllare la [modalità di riproduzione](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automatica o al clic) e il [ciclo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Queste opzioni sono disponibili tramite i metodi dell'oggetto [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando si incorpora un video locale, i dati binari vengono inclusi nel documento, quindi le dimensioni della presentazione aumentano proporzionalmente alla dimensione del file. Quando si collega a un video online e si aggiunge una miniatura, la presentazione memorizza il collegamento e l'immagine di anteprima invece dei dati video, quindi l'aumento di dimensione è solitamente minore.

**Posso sostituire il video in un fotogramma video esistente senza modificare la sua posizione e dimensione?**

Sì. È possibile scambiare il [contenuto video](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) all'interno del fotogramma mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [tipo di contenuto](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) che è possibile leggere e utilizzare, ad esempio quando lo si salva su disco.