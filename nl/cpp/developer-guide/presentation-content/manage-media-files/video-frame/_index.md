---
title: Beheer video‑frames in presentaties met C++
linktitle: Video‑frame
type: docs
weight: 10
url: /nl/cpp/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- video‑frame
- webbron
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u programmatically video‑frames kunt toevoegen en extraheren in PowerPoint‑ en OpenDocument‑slides met Aspose.Slides voor C++. Snelle hoe‑to‑handleiding."
---
## **Inleiding**

Een goed geplaatste video in een presentatie kan uw boodschap overtuigender maken en het betrokkenheidsniveau van uw publiek verhogen. 

PowerPoint biedt u twee manieren om video's aan een dia in een presentatie toe te voegen:

* Voeg een lokale video toe of embed deze (opgeslagen op uw computer)
* Voeg een online video toe (van een webbron zoals YouTube).

Om u in staat te stellen video's (video‑objecten) aan een presentatie toe te voegen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/)‑interface, de [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/)‑interface en andere relevante types. 

## **Maak een ingesloten video‑frame**

Als het videobestand dat u aan uw dia wilt toevoegen lokaal is opgeslagen, kunt u een video‑frame maken om de video in uw presentatie te embedden. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)klasse.
1. Verkrijg een referentie naar een dia via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/)‑object toe en geef het pad naar het videobestand door om de video in de presentatie te embedden. 
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/)‑object toe om een frame voor de video te maken.  
1. Sla de aangepaste presentatie op. 

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

U kunt ook een video toevoegen door het bestandspad rechtstreeks door te geven aan de [AddVideoFrame()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishapecollection/addvideoframe/)‑methode:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Maak een video‑frame met video van een webbron**

Microsoft [PowerPoint 2013 en nieuwer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) ondersteunt YouTube‑video's in presentaties. Als de video die u wilt gebruiken online beschikbaar is (bijv. op YouTube), kunt u deze via de weblink aan uw presentatie toevoegen. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)klasse
1. Verkrijg een referentie naar een dia via de index. 
1. Voeg een [IVideo](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideo/)‑object toe en geef de link naar de video door.
1. Stel een thumbnail in voor het video‑frame. 
1. Sla de presentatie op. 

Deze C++‑code laat zien hoe u een video van het web aan een dia in een PowerPoint‑presentatie toevoegt:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Initialiseert een Presentation‑object dat een presentatiebestand vertegenwoordigt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Voegt een video‑frame toe 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Stelt de afspeelmodus en het volume van de video in
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Slaat de presentatie op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Beheer video‑ondertitels**

Aspose.Slides stelt u in staat om gesloten ondertitels voor video‑frames in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/)‑methode.

**Ondertitels aan een video‑frame toevoegen**

Om ondertitels aan een video‑frame toe te voegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)klasse.
1. Voeg een video toe aan de presentatie.
1. Voeg een [IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/)‑object toe aan een dia.
1. Gebruik de [ICaptionsCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/) die wordt geretourneerd door [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/) om een WebVTT‑ondertiteltrack toe te voegen.
1. Sla de gewijzigde presentatie op.

De volgende code laat zien hoe u ondertitels aan een video‑frame toevoegt:

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

De [ICaptionsCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/)‑interface biedt ook een overload waarmee u ondertitels vanuit een stream kunt toevoegen.

**Ondertitels uit een video‑frame extraheren**

Om ondertitels uit een video‑frame te extraheren:

1. Laad de presentatie die de video bevat.
1. Zoek het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/)‑object.
1. Doorloop de ondertitel‑tracks die worden geretourneerd door [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Sla elke ondertiteltrack op in een `.vtt`‑bestand.

De volgende code laat zien hoe u ondertitels uit een video‑frame extrahereert:

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
            // Slaat het ondertiteltrack op naar een WebVTT-bestand.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Elk [ICaptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptions/)‑object exposeert de ondertitel‑identifier, het label, binaire data en de ondertitelgegevens als een UTF‑8‑string.

**Ondertitels uit een video‑frame verwijderen**

Om ondertitels uit een video‑frame te verwijderen:

1. Laad de presentatie die de video bevat.
1. Verkrijg het doel‑[IVideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/)‑object.
1. Verwijder ondertitel‑tracks uit de collectie die wordt geretourneerd door [get_CaptionTracks](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ivideoframe/get_captiontracks/).
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

Als u slechts één ondertiteltrack wilt verwijderen, gebruik dan de [Remove](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/remove/)‑ of [RemoveAt](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/removeat/)‑methoden in plaats van [Clear](https://reference.aspose.com/slides/nl/cpp/aspose.slides/icaptionscollection/clear/).

## **Video van een dia extraheren**

Naast het toevoegen van video's aan dia’s, maakt Aspose.Slides het mogelijk om video's die in presentaties zijn ingesloten te extraheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)klasse om de presentatie te laden die de video bevat. 
2. Doorloop alle [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/)‑objecten.
3. Doorloop alle [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)‑objecten om een [VideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/) te vinden. 
4. Sla de video op naar schijf.

Deze C++‑code laat zien hoe u de video van een presentatiedia extrahert:

```c++
// Het pad naar de documentenmap.
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

**Welke afspeelparameters van een VideoFrame kunnen worden aangepast?**

U kunt de [afspeelmodus](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/set_playmode/) (automatisch of bij klikken) en het [herhalen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/set_playloopmode/) controleren. Deze opties zijn beschikbaar via de eigenschappen van het [VideoFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de bestandsgrootte van de PPTX?**

Ja. Wanneer u een lokale video embedt, wordt de binaire data in het document opgenomen, waardoor de presentatiegroottes evenredig met de bestandsgrootte groeit. Wanneer u een online video toevoegt, worden alleen een link en een thumbnail ingebed, waardoor de grootte‑toename kleiner is.

**Kan ik de video in een bestaand VideoFrame vervangen zonder de positie en grootte aan te passen?**

Ja. U kunt de [video‑inhoud](https://reference.aspose.com/slides/nl/cpp/aspose.slides/videoframe/set_embeddedvideo/) binnen het frame verwisselen terwijl u de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario voor het bijwerken van media in een bestaande lay‑out.

**Kan het content‑type (MIME) van een ingebedde video worden bepaald?**

Ja. Een ingebedde video heeft een [content‑type](https://reference.aspose.com/slides/nl/cpp/aspose.slides/video/get_contenttype/) dat u kunt lezen en gebruiken, bijvoorbeeld bij het opslaan op schijf.