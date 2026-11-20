---
title: "Hantera video‑ramar i presentationer med C++"
linktitle: "Video‑ram"
type: docs
weight: 10
url: /sv/cpp/video-frame/
keywords:
- "lägga till video"
- "skapa video"
- "bädda in video"
- "extrahera video"
- "hämta video"
- "video‑ram"
- "webbkälla"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "C++"
- "Aspose.Slides"
description: "Lär dig att programatiskt lägga till och extrahera video‑ramar i PowerPoint‑ och OpenDocument‑bilder med Aspose.Slides för C++. Snabb steg‑för‑steg‑guide."
---
## **Introduktion**

Videor kan hjälpa till att förklara idéer och engagera en publik. Aspose.Slides för C++ låter dig lägga till video­ramar på bilder, justera uppspelningsinställningar, hantera bildtexter och extrahera inbäddade videodata.

PowerPoint stödjer lokala videor och länkar till online‑videor, såsom YouTube‑videor.

För att representera videodata och video­ramar tillhandahåller Aspose.Slides gränssnitten [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) , [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) , samt andra relevanta typer.

## **Skapa en inbäddad video­ram**

Om videofilen du vill lägga till på din bild är lagrad lokalt kan du skapa en video­ram för att bädda in videon i din presentation.

Detta exempel bäddar in en lokal video på den första bilden i en befintlig presentation och sparar resultatet. Ramens koordinater och dimensioner är i punkter. Strömmen förblir öppen tills sparandet är klart eftersom [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) låser den medan presentationen använder den.

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

Du kan också skicka en lokal videostig direkt till [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Detta exempel bäddar in videon på den första bilden i en ny presentation. Videon måste förbli åtkomlig tills presentationen sparas.

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

## **Skapa en video­ram med video från en webbkälla**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) stödjer online‑videor i presentationer. Du kan skapa en video­ram som länkar till en online‑video, till exempel en YouTube‑video.

Detta exempel lägger till en YouTube‑videolänk och miniatyr på den första bilden. Byt ut videoin identifieraren för att använda en annan video. Metoden [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) begär automatisk uppspelning. Nedladdning av miniatyren och uppspelning av videon kräver internetåtkomst. Visningsprogrammet för presentationen måste även stödja online‑videouppspelning.

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

## **Spela en video i helskärmsläge**

I en träningspresentation kan du spela en mjukvarudemonstration i helskärmsläge så publiken kan se detaljerna. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) accepterar `true` för att aktivera detta beteende under uppspelning.

Detta exempel öppnar en presentation, hittar den första [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) på den första bilden och aktiverar helskärmsuppspelning. Indatapresentationen måste innehålla minst en bild med en befintlig video­ram på den första bilden.

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

Helskärmsuppspelning styr hur videon visas. Oberoende kontrollerar [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) om den startar automatiskt eller på klick, och [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) styr om den upprepas. För att välja startbeteendet, sätt uppspelningsläget till [VideoPlayModePreset::Auto eller VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Exemplet bevarar de befintliga start- och loopinställningarna.

## **Spola tillbaka en video efter uppspelning**

I en träningspresentation gör att återföra en demonstrationsvideo till början den redo för presentatören att spela igen. Anropa [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) med `true` för att återföra videon till början efter att uppspelningen är klar.

Detta exempel öppnar en presentation, hittar den första [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) på den första bilden och aktiverar spolning tillbaka. Det inaktiverar looping så att uppspelningen kan avslutas och sätter uppspelning att starta på klick. Indatapresentationen måste innehålla minst en bild med en befintlig video­ram på den första bilden.

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

Spolning tillbaka återför videon till början utan att starta den igen. Däremot gör att aktivera [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) att uppspelning upprepas automatiskt. Håll looping inaktiverad när du vill att videon ska avslutas och vara redo för återuppspelning. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) kontrollerar oberoende automatisk eller klickstart; detta exempel använder [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) så presentatören styr när uppspelning startar. Ställ in uppspelningsläget efter loopinställningen, som visas i exemplet. Spolning tillbaka fungerar oberoende av [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Trimma en video­ram**

Använd [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) och [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) för att hoppa över en del av början eller slutet av en video under uppspelning. Båda värdena är i millisekunder. Trimning ändrar uppspelningsinställningarna utan att ändra den inbäddade videon.

**Ställ in triminställningar**

Detta exempel bäddar in en lokal video och hoppar över de första 2,5 sekunderna och den sista sekunden under uppspelning. Använd en video längre än 3,5 sekunder så att ett spelbart segment kvarstår.

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

**Läs triminställningar**

Detta exempel skriver ut trimvärdena för den första video­ramen på den första bilden i millisekunder. Presentationen måste innehålla minst en bild. Om den bilden saknar video­ram skrivs inget ut. Föregående exempel ger värdena 2500 och 1000.

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

## **Hantera video‑undertexter**

Aspose.Slides låter dig hantera stängda undertexter för video­ramar i PowerPoint‑presentationer. Undertexterna lagras i WebVTT‑format och exponeras via metoden [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

### **Lägg till undertexter på en video­ram**

Detta exempel bäddar in en lokal video och lägger till ett WebVTT‑undertextspår märkt English. Undertextens tidsstämplar bör matcha videon. Den sparade presentationen innehåller både video och dess undertexter.

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

Gränssnittet [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) erbjuder också en överlagring som låter dig lägga till undertexter från en ström.

### **Extrahera undertexter från en video­ram**

Detta exempel sparar alla undertextspår från video­ramar på den första bilden som separata WebVTT‑filer. Sekventiella nummer håller utdatafilerna unika. Konsolen rapporterar antalet extraherade spår. Presentationen måste innehålla minst en bild.

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

Varje [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/)‑objekt exponerar undertextens identifierare, etikett, binära data och undertextens text som en UTF‑8‑sträng.

### **Ta bort undertexter från en video­ram**

Detta exempel tar bort alla undertexter från video­ramen i den första formens position på den första bilden och sparar resultatet. Det förutsätter att bilden och formen finns och att formen är en video­ram.

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

Om du bara behöver ta bort ett undertextspår, använd metoderna [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) eller [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) istället för [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

### **Sök i video‑undertexter**

[ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) returnerar hela WebVTT‑spåret, inklusive header, tidslinjer och undertexten. För att hitta en talad fras och dess tidsstämpel, läs cue‑erna i minnet. Till exempel kan ett engelsk spår på bild 2 innehålla följande text:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

Exemplet öppnar `captioned_media.pptx` och läser undertextspåren för varje top‑nivå video­ram på varje bild med [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/). I en plain‑text cue innehåller tidslinjen `-->` och en tom rad avslutar cue‑en. När undertexten innehåller “café” skriver exemplet ut bildnummer, spårets etikett, originaltidslinjen och fullständig undertext. Sökningen ignorerar skiftläge.

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

Sökning efter “café” ger en matchning för det exempelspåret. Sökningen hoppar över headern och bevarar tidsinställningen i utdata.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Extrahera video från en bild**

Förutom att lägga till videor på bilder låter Aspose.Slides dig extrahera videor som är inbäddade i presentationer.

Detta exempel extraherar inbäddade videor från varje bild till separata, numrerade binära filer. Länkade videor hoppas över eftersom de saknar inbäddad data. Konsolen skriver ut varje videos MIME‑typ och det totala antalet. Utdata använder den generiska filändelsen `.bin`; ändra den för att matcha den rapporterade mediatypen vid behov.

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

**Vilka video‑uppspelningsparametrar kan ändras för en video­ram?**

Du kan styra [uppspelningsläget](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (auto eller på klick) och [loopning](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Dessa alternativ är tillgängliga via [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)-objektets metoder.

**Påverkar tillägg av en video PPTX‑filens storlek?**

Ja. När du bäddar in en lokal video inkluderas den binära datan i dokumentet, så presentationens storlek ökar i proportion till videofilen. När du länkar till en online‑video och lägger till en miniatyr sparar presentationen länken och förhandsbilden istället för videodatan, så storleksökningen är vanligtvis mindre.

**Kan jag ersätta videon i en befintlig video­ram utan att ändra dess position och storlek?**

Ja. Du kan byta ut [videoinnehållet](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) i ramen samtidigt som du bevarar formens geometri; detta är ett vanligt scenario för att uppdatera media i en befintlig layout.

**Kan innehållstypen (MIME) för en inbäddad video bestämmas?**

Ja. En inbäddad video har en [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) som du kan läsa och använda, till exempel när du sparar den till disk.