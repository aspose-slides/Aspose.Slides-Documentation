---
title: Gestisci i Frame Video nelle Presentazioni con C++
linktitle: Frame Video
type: docs
weight: 10
url: /it/cpp/video-frame/
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
- C++
- Aspose.Slides
description: "Impara ad aggiungere ed estrarre programmaticamente i frame video in diapositive PowerPoint e OpenDocument utilizzando Aspose.Slides per C++. Guida rapida passo-passo."
---
## **Introduzione**

Un video posizionato correttamente in una presentazione può rendere il tuo messaggio più coinvolgente e aumentare il livello di coinvolgimento del pubblico. 

PowerPoint consente di aggiungere video a una diapositiva in una presentazione in due modi:

* Aggiungere o incorporare un video locale (archiviato sul tuo computer)
* Aggiungere un video online (da una fonte web come YouTube).

Per consentirti di aggiungere video (oggetti video) a una presentazione, Aspose.Slides fornisce l'interfaccia [IVideo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideo/) , l'interfaccia [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) e altri tipi pertinenti. 

## **Crea un Frame Video incorporato**

Se il file video che desideri aggiungere alla tua diapositiva è archiviato localmente, puoi creare un frame video per incorporare il video nella tua presentazione. 

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento a una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideo/) e passa il percorso del file video per incorporarlo nella presentazione. 
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) per creare un frame per il video.  
1. Salva la presentazione modificata. 

Questo codice C++ mostra come aggiungere un video archiviato localmente a una presentazione:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Carica il video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Ottiene la prima diapositiva e aggiunge un frame video
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Salva la presentazione su disco
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

In alternativa, puoi aggiungere un video passando direttamente il percorso del file al metodo [AddVideoFrame()](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Crea un Frame Video con Video da una Fonte Web**

Microsoft [PowerPoint 2013 e versioni successive](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) supporta i video di YouTube nelle presentazioni. Se il video che desideri utilizzare è disponibile online (ad esempio su YouTube), puoi aggiungerlo alla tua presentazione tramite il suo link web. 

1. Crea un'istanza della classe [Presentation ](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottieni il riferimento a una diapositiva tramite il suo indice. 
1. Aggiungi un oggetto [IVideo](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideo/) e passa il link al video.
1. Imposta una miniatura per il frame video. 
1. Salva la presentazione. 

Questo codice C++ mostra come aggiungere un video dal web a una diapositiva in una presentazione PowerPoint:

```c++
// Il percorso della directory dei documenti.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Istanzia un oggetto Presentation che rappresenta un file di presentazione
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Accede alla prima diapositiva
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Aggiunge un Frame Video 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Imposta la Modalità di Riproduzione e il Volume del Video
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Salva la presentazione su disco
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Gestisci i Sottotitoli dei Video**

Aspose.Slides consente di gestire i sottotitoli chiusi per i frame video nelle presentazioni PowerPoint. I sottotitoli sono memorizzati in formato WebVTT e sono accessibili tramite il metodo [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**Aggiungi Sottotitoli a un Frame Video**

Per aggiungere i sottotitoli a un frame video:

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Aggiungi un video alla presentazione.
1. Aggiungi un oggetto [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) a una diapositiva.
1. Utilizza la [ICaptionsCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/) restituita da [get_CaptionTracks](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/get_captiontracks/) per aggiungere una traccia di sottotitoli WebVTT.
1. Salva la presentazione modificata.

Il codice seguente mostra come aggiungere i sottotitoli a un frame video:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Aggiunge una nuova traccia di sottotitoli da un file WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

L'interfaccia [ICaptionsCollection](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/) fornisce anche una sovraccarico che consente di aggiungere i sottotitoli da uno stream.

**Estrai i Sottotitoli da un Frame Video**

Per estrarre i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Trova l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) target.
1. Itera attraverso le tracce di sottotitoli restituite da [get_CaptionTracks](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Salva ogni traccia di sottotitoli in un file `.vtt`.

Il codice seguente mostra come estrarre i sottotitoli da un frame video:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        for (auto&& captionTrack : videoFrame->get_CaptionTracks())
        {
            // Salva la traccia dei sottotitoli in un file WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Ogni oggetto [ICaptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptions/) espone l'identificatore del sottotitolo, l'etichetta, i dati binari e i dati del sottotitolo come stringa UTF-8.

**Rimuovi i Sottotitoli da un Frame Video**

Per rimuovere i sottotitoli da un frame video:

1. Carica la presentazione che contiene il video.
1. Ottieni l'oggetto [IVideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/) target.
1. Rimuovi le tracce di sottotitoli dalla collezione restituita da [get_CaptionTracks](https://reference.aspose.com/slides/it/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Salva la presentazione modificata.

Il codice seguente mostra come rimuovere tutti i sottotitoli da un frame video:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Rimuove tutti i sottotitoli dal frame video.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Se devi rimuovere solo una traccia di sottotitoli, usa i metodi [Remove](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/remove/) o [RemoveAt](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/removeat/) invece di [Clear](https://reference.aspose.com/slides/it/cpp/aspose.slides/icaptionscollection/clear/).

## **Estrai Video da una Diapositiva**

Oltre ad aggiungere video alle diapositive, Aspose.Slides consente di estrarre i video incorporati nelle presentazioni.

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/) per caricare la presentazione contenente il video. 
2. Itera attraverso tutti gli oggetti [ISlide](https://reference.aspose.com/slides/it/cpp/aspose.slides/islide/). 
3. Itera attraverso tutti gli oggetti [IShape](https://reference.aspose.com/slides/it/cpp/aspose.slides/ishape/) per trovare un [VideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/videoframe/). 
4. Salva il video su disco.

Questo codice C++ mostra come estrarre il video da una diapositiva della presentazione:

```c++
// Il percorso della directory dei documenti.
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```

## **FAQ**

**Quali parametri di riproduzione video possono essere modificati per un VideoFrame?**

Puoi controllare la [modalità di riproduzione](https://reference.aspose.com/slides/it/cpp/aspose.slides/videoframe/set_playmode/) (automatica o al clic) e il [looping](https://reference.aspose.com/slides/it/cpp/aspose.slides/videoframe/set_playloopmode/). Queste opzioni sono disponibili tramite le proprietà dell'oggetto [VideoFrame](https://reference.aspose.com/slides/it/cpp/aspose.slides/videoframe/) .

**L'aggiunta di un video influisce sulla dimensione del file PPTX?**

Sì. Quando incorpori un video locale, i dati binari vengono inclusi nel documento, quindi la dimensione della presentazione aumenta proporzionalmente alla dimensione del file. Quando aggiungi un video online, viene incorporato un link e una miniatura, quindi l'incremento di dimensione è minore.

**Posso sostituire il video in un VideoFrame esistente senza cambiarne posizione e dimensione?**

Sì. Puoi scambiare il [contenuto video](https://reference.aspose.com/slides/it/cpp/aspose.slides/videoframe/set_embeddedvideo/) all'interno del frame mantenendo la geometria della forma; questo è uno scenario comune per aggiornare i media in un layout esistente.

**È possibile determinare il tipo di contenuto (MIME) di un video incorporato?**

Sì. Un video incorporato ha un [content type](https://reference.aspose.com/slides/it/cpp/aspose.slides/video/get_contenttype/) che puoi leggere e utilizzare, ad esempio quando lo salvi su disco.