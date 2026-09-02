---
title: Beheer video-frames in presentaties met C++
linktitle: Video-frame
type: docs
weight: 10
url: /nl/cpp/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video-frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u programmatig video-frames kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor C++. Snelle stapsgewijze handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en de betrokkenheid van uw publiek verhogen. 

PowerPoint staat u toe om video's aan een dia in een presentatie toe te voegen op twee manieren:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u toe te staan video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/) interface, de [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) interface en andere relevante typen. 

## **Een ingesloten video‑frame maken**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie in te sluiten. 

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Haal de referentie van een dia op via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/) object toe en geef het pad naar het videobestand door om de video in de presentatie in te sluiten. 
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) object toe om een frame voor de video te maken.  
1. Sla de gewijzigde presentatie op. 

Deze C++‑code laat zien hoe u een lokaal opgeslagen video aan een presentatie toevoegt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de [AddVideoFrame()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addvideoframe/) methode:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Een video‑frame maken met video van een webbron**

Nieuwere versies van Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunen online‑video's in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de web‑link aan uw presentatie toevoegen.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Haal de referentie van een dia op via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/) object toe en geef de link naar de video door.
1. Stel een miniatuurafbeelding in voor het video‑frame. 
1. Sla de presentatie op. 

Deze C++‑code laat zien hoe u een video van het internet aan een dia in een PowerPoint‑presentatie toevoegt:

```c++
 // Het pad naar de documentenmap.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Instanties een Presentation-object dat een presentatiebestand vertegenwoordigt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Benadert de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Voegt een video-frame toe 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Stelt de afspeelmodus en het volume van de video in
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Slaat de presentatie op schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Een video‑frame inkorten**

Aspose.Slides stelt u in staat te bepalen welk deel van een video wordt afgespeeld door de waarden trim‑from‑start en trim‑from‑end in te stellen via [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/set_trimfromstart/) en [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/set_trimfromend/). Beide waarden worden opgegeven in milliseconden en bepalen hoeveel tijd er respectievelijk aan het begin en einde van de video wordt overgeslagen. Deze instellingen wijzigen de afspeelinstellingen van de video in de presentatie; ze knippen of wijzigen de ingebedde videobinaire gegevens niet.

**Trim‑instellingen instellen**

Om een video‑frame te maken en de trim‑instellingen in te stellen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/) object toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) object toe aan een dia.
1. Stel de waarden trim‑from‑start en trim‑from‑end in via [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/set_trimfromstart/) en [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/set_trimfromend/).
1. Sla de gewijzigde presentatie op.

De volgende code‑voorbeeld slaat de eerste 2,5 seconde en de laatste seconde van een ingesloten video over tijdens het afspelen:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(50, 50, 640, 360, video);

videoFrame->set_TrimFromStart(2500.0f);
videoFrame->set_TrimFromEnd(1000.0f);

presentation->Save(u"video_with_trim.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

**Trim‑instellingen lezen**

Om bestaande trim‑instellingen te inspecteren, laadt u een presentatie, zoekt u een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) object tussen de vormen op de eerste dia, en leest u de waarden via [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_trimfromstart/) en [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Het volgende code‑voorbeeld vindt het eerste video‑frame op de eerste dia en rapporteert de trim‑instellingen in milliseconden:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_trim.pptx");

auto slide = presentation->get_Slide(0);
for (auto&& shape : slide->get_Shapes())
{
    if (ObjectExt::Is<IVideoFrame>(shape))
    {
        auto videoFrame = ExplicitCast<IVideoFrame>(shape);
        auto trimFromStart = videoFrame->get_TrimFromStart();
        auto trimFromEnd = videoFrame->get_TrimFromEnd();

        Console::WriteLine(u"Trim from start: {0} ms", trimFromStart);
        Console::WriteLine(u"Trim from end: {0} ms", trimFromEnd);

        break;
    }
}

presentation->Dispose();
```

## **Video‑bijschriften beheren**

Aspose.Slides stelt u in staat om ondertitelingen voor video‑frames in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en kunnen worden opgevraagd via de methode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Ondertitels toevoegen aan een video‑frame**

Om ondertitels toe te voegen aan een video‑frame:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) object toe aan een dia.
1. Gebruik de [ICaptionsCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/) die wordt geretourneerd door [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/) om een WebVTT‑ondertiteltrack toe te voegen.
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u ondertitels toevoegt aan een video‑frame:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Adds a new captions track from a WebVTT file.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

De [ICaptionsCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/) interface biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels extraheren uit een video‑frame**

Om ondertitels te extraheren uit een video‑frame:

1. Laad de presentatie die de video bevat.
1. Zoek het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) object.
1. Itereer door de ondertiteltracks die worden geretourneerd door [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Sla elke ondertiteltrack op naar een `.vtt`‑bestand.

De volgende code laat zien hoe u ondertitels uit een video‑frame extrahert:

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
            // Slaat de ondertiteltrack op naar een WebVTT-bestand.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Elk [ICaptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptions/) object geeft de ondertitel‑identifier, label, binaire gegevens en ondertitelgegevens weer als een UTF‑8‑string.

**Ondertitels verwijderen uit een video‑frame**

Om ondertitels te verwijderen uit een video‑frame:

1. Laad de presentatie die de video bevat.
1. Haal het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/) object op.
1. Verwijder ondertiteltracks uit de collectie die wordt geretourneerd door [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u alle ondertitels uit een video‑frame verwijdert:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Verwijdert alle ondertitels van het video-frame.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de [Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/removeat/) methoden in plaats van [Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/clear/).

## **Video extraheren uit een dia**

Naast het toevoegen van video's aan dia's, stelt Aspose.Slides u in staat om video's die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) om de presentatie te laden die de video bevat. 
2. Itereer door alle [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/) objecten.
3. Itereer door alle [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/) te vinden. 
4. Sla de video op naar schijf.

Deze C++‑code laat zien hoe u de video op een presentatiedia extrahert:

```c++
// Het pad naar de documentmap.
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

**Welke afspeelparameters van een video‑frame kunnen worden aangepast?**

U kunt de [playback mode](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/set_playmode/) (automatisch of bij klikken) en [looping](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/set_playloopmode/) regelen. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/) object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video insluit, wordt de binaire data in het document opgenomen, waardoor de presentatiegrootte groeit in verhouding tot de bestandsgrootte. Wanneer u een online video toevoegt, worden een link en een miniatuurafbeelding ingesloten, waardoor de toename in grootte kleiner is.

**Kan ik de video in een bestaand video‑frame vervangen zonder de positie en grootte te wijzigen?**

Ja. U kunt de [video content](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/set_embeddedvideo/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay-out.

**Kan het content‑type (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [content type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/video/get_contenttype/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.