---
title: Beheer videoframes in presentaties met C++
linktitle: Videoframe
type: docs
weight: 10
url: /nl/cpp/video-frame/
keywords:
- video toevoegen
- video maken
- video insluiten
- video extraheren
- video ophalen
- videoframe
- webbron
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je programmatisch videoframes kunt toevoegen en extraheren in PowerPoint- en OpenDocument-dia's met Aspose.Slides voor C++. Snelle handleiding."
---
## **Inleiding**

Video's kunnen helpen ideeën uit te leggen en een publiek te boeien. Aspose.Slides voor C++ stelt je in staat videoframes aan dia's toe te voegen, afspeelinstellingen aan te passen, bijschriften te beheren en ingebedde video‑gegevens te extraheren.

PowerPoint ondersteunt lokale video’s en koppelingen naar online video’s, zoals YouTube‑video’s.

Om video‑gegevens en videoframes te vertegenwoordigen, biedt Aspose.Slides de [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/)-interface, de [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/)-interface en andere relevante types.

## **Maak een ingebedde videoframe**

Als het videobestand dat je aan je dia wilt toevoegen lokaal is opgeslagen, kun je een videoframe maken om de video in je presentatie in te sluiten.

Dit voorbeeld insluit een lokale video op de eerste dia van een bestaande presentatie en slaat het resultaat op. Frame‑coördinaten en afmetingen zijn in punten. De stream blijft open tot het opslaan voltooid is omdat [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) deze vergrendelt terwijl de presentatie hem gebruikt.

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

Je kunt ook een lokaal videopath rechtstreeks doorgeven aan [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Dit voorbeeld insluit de video op de eerste dia van een nieuwe presentatie. De video moet toegankelijk blijven totdat de presentatie wordt opgeslagen.

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

## **Maak een videoframe met video van een webbron**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) ondersteunt online video’s in presentaties. Je kunt een videoframe maken dat koppelt naar een online video, zoals een YouTube‑video.

Dit voorbeeld voegt een YouTube‑videokoppeling en miniatuur toe aan de eerste dia. Vervang de video‑identifier om een andere video te gebruiken. De methode [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) vraagt om automatische weergave. Het downloaden van de miniatuur en het afspelen van de video vereisen internettoegang. De presentatieweergave moet ook online video‑afspelen ondersteunen.

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

## **Speel een video af in volledig scherm-modus**

In een trainingspresentatie kun je een software‑demo in volledig scherm afspelen zodat het publiek de details kan zien. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) accepteert `true` om dit gedrag tijdens het afspelen in te schakelen.

Dit voorbeeld opent een presentatie, zoekt de eerste [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) op de eerste dia en schakelt volledig scherm‑afspelen in. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Volledig scherm‑afspelen bepaalt hoe de video wordt weergegeven. Onafhankelijk daarvan regelt [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) of deze automatisch of bij klik start, en [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) of deze herhaalt. Om het startgedrag te kiezen, stel je de afspeelmodus in op [VideoPlayModePreset::Auto of VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Het voorbeeld behoudt de bestaande start‑ en lusinstellingen.

## **Hervind een video na afspelen**

In een trainingspresentatie, het terugbrengen van een demonstratievideo naar het begin maakt deze klaar voor de presentator om opnieuw af te spelen. Roep [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) aan met `true` om de video na voltooid afspelen naar het begin te brengen.

Dit voorbeeld opent een presentatie, zoekt de eerste [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) op de eerste dia en schakelt het terugspoelen in. Het schakelt looping uit zodat het afspelen kan eindigen en stelt het afspelen in om bij klik te starten. De invoerpresentatie moet minstens één dia bevatten met een bestaand videoframe op de eerste dia.

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

Het terugspoelen brengt de video terug naar het begin zonder deze opnieuw te starten. Daarentegen zorgt het inschakelen van [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) voor automatisch herhalen van het afspelen. Houd looping uitgeschakeld wanneer je wilt dat de video eindigt en klaar blijft om opnieuw af te spelen. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) regelt onafhankelijk automatisch of bij‑klik starten; dit voorbeeld gebruikt [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) zodat de presentator bepaalt wanneer het afspelen start. Stel de afspeelmodus in na de lusinstelling, zoals getoond in het voorbeeld. Het terugspoelen werkt onafhankelijk van [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Trim een videoframe**

Gebruik [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) en [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) om een deel van het begin of einde van een video over te slaan tijdens het afspelen. Beide waarden zijn in milliseconden. Trimmen wijzigt de afspeelinstellingen zonder de ingebedde video‑gegevens te wijzigen.

**Triminstellingen instellen**

Dit voorbeeld insluit een lokale video en slaat de eerste 2,5 seconde en de laatste seconde over tijdens het afspelen. Gebruik een video langer dan 3,5 seconde zodat er een afspeelbaar segment overblijft.

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

**Triminstellingen lezen**

Dit voorbeeld drukt de trimwaarden van het eerste videoframe op de eerste dia af in milliseconden. De presentatie moet minstens één dia bevatten. Als die dia geen videoframe heeft, wordt er niets afgedrukt. Het vorige voorbeeld levert waarden van 2500 en 1000 op.

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

## **Beheer video‑bijschriften**

Aspose.Slides stelt je in staat gesloten ondertitels voor videoframes in PowerPoint‑presentaties te beheren. Ondertitels worden opgeslagen in WebVTT‑formaat en zijn toegankelijk via de methode [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Ondertitels toevoegen aan een videoframe**

Dit voorbeeld insluit een lokale video en voegt een WebVTT‑ondertiteltrack toe met het label English. De tijdstempels van de ondertitels moeten overeenkomen met de video. De opgeslagen presentatie bevat zowel de video als de ondertitels.

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

De interface [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) biedt ook een overload die je in staat stelt ondertitels vanaf een stream toe te voegen.

**Ondertitels extraheren uit een videoframe**

Dit voorbeeld slaat alle ondertiteltracks van videoframes op de eerste dia op als afzonderlijke WebVTT‑bestanden. Opeenvolgende nummers houden de uitvoerbestanden onderscheiden. De console rapporteert het aantal geëxtraheerde tracks. De presentatie moet minstens één dia bevatten.

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

Elk [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/)‑object exposeert de ondertitel‑identifier, het label, binaire gegevens en de ondertiteltekst als een UTF‑8‑string.

**Ondertitels verwijderen uit een videoframe**

Dit voorbeeld verwijdert alle ondertitels uit het videoframe op de eerste vormpositie op de eerste dia en slaat het resultaat op. Het gaat ervan uit dat de dia en vorm bestaan en dat de vorm een videoframe is.

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

Als je slechts één ondertiteltrack wilt verwijderen, gebruik dan de methoden [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) of [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) in plaats van [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Video extraheren van een dia**

Naast het toevoegen van video’s aan dia's, maakt Aspose.Slides het mogelijk om ingesloten video’s uit presentaties te extraheren.

Dit voorbeeld extrahert ingesloten video’s van elke dia naar afzonderlijke, genummerde binaire bestanden. Gelinkte video’s worden overgeslagen omdat ze geen ingesloten gegevens hebben. De console toont het MIME‑type van elke video en het totale aantal. De output gebruikt de generieke extensie `.bin`; wijzig deze om overeen te komen met het gerapporteerde mediatype indien nodig.

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

**Welke video‑afspeelparameters kunnen voor een videoframe worden gewijzigd?**

Je kunt de [afspeelmodus](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto of bij klik) en de [lusinstelling](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) controleren. Deze opties zijn beschikbaar via de methoden van het [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)‑object.

**Heeft het toevoegen van een video invloed op de PPTX‑bestandsgrootte?**

Ja. Wanneer je een lokale video insluit, worden de binaire gegevens opgenomen in het document, waardoor de presentatiegrootte evenredig met de bestandsgrootte toeneemt. Wanneer je naar een online video linkt en een miniatuur toevoegt, slaat de presentatie de koppeling en voorbeeldafbeelding op in plaats van de video‑gegevens, waardoor de grootte‑toename doorgaans kleiner is.

**Kan ik de video in een bestaand videoframe vervangen zonder de positie en grootte te wijzigen?**

Ja. Je kunt de [video‑inhoud](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) binnen het frame verwisselen terwijl je de geometrie van de vorm behoudt; dit is een veelvoorkomend scenario om media in een bestaande lay-out bij te werken.

**Kan het contenttype (MIME) van een ingesloten video worden bepaald?**

Ja. Een ingesloten video heeft een [contenttype](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) dat je kunt lezen en gebruiken, bijvoorbeeld bij het opslaan naar schijf.