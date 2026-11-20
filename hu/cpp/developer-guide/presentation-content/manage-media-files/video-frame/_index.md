---
title: Videókeretek kezelése bemutatókban C++ használatával
linktitle: Videókeret
type: docs
weight: 10
url: /hu/cpp/video-frame/
keywords:
- videó hozzáadása
- videó létrehozása
- videó beágyazása
- videó kinyerése
- videó lekérése
- videókeret
- webforrás
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Tanulja meg programozottan hozzáadni és kinyerni a videókereteket PowerPoint és OpenDocument diákba az Aspose.Slides for C++ segítségével. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek magyarázatában és a közönség bevonásában. Az Aspose.Slides for C++ lehetővé teszi, hogy videókereteket adjunk a diákkhoz, beállítsuk a lejátszási beállításokat, kezeljük a feliratokat, és kinyerjük a beágyazott videó adatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube videókat.

A videoadatok és videókeretek ábrázolásához az Aspose.Slides a [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) interfészt, a [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) interfészt és egyéb releváns típusokat biztosít.

## **Beágyazott videókeret létrehozása**

Ha a diára feltenni kívánt videofájl helyileg van tárolva, létrehozhat egy videókeretet a videó beágyazásához a bemutatóba.

Ez a példa egy helyi videót ágyaz be a meglévő bemutató első diájára, és elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A folyam nyitva marad a mentés befejezéséig, mivel a [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a bemutató használja.

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

A helyi videó útvonalát közvetlenül is átadhatja a [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) metódusnak. Ez a példa egy új bemutató első diájára ágyaz be videót. A videónak a mentés befejezéséig elérhetőnek kell maradnia.

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

## **Webforrásból származó videóval ellátott videókeret létrehozása**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a bemutatókban. Létrehozhat egy videókeretet, amely egy online videóra mutató hivatkozást tartalmaz, például egy YouTube videóra.

Ez a példa egy YouTube videó hivatkozást és bélyegképet ad az első diához. Cserélje le a videó azonosítóját, ha másik videót szeretne használni. A [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) metódus automatikus lejátszást kér. A bélyegkép letöltése és a videó lejátszása internetkapcsolatot igényel. A bemutató megjelenítőnek szintén támogatnia kell az online videó lejátszást.

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

## **Videó lejátszása teljes képernyős módban**

Képzési bemutatóban szoftverbemutatót játszhat le teljes képernyőn, hogy a közönség lássa a részleteket. A [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) `true` értékkel engedélyezi ezt a viselkedést lejátszás közben.

Ez a példa megnyit egy bemutatót, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Különállóan a [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) vezérli, hogy automatikusan vagy kattintásra indítson, és a [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) szabályozza, hogy ismétlődjön-e. A kezdési viselkedés kiválasztásához állítsa a lejátszási módot a [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) értékre. A példa megtartja a meglévő kezdő- és ismétlődési beállításokat.

## **Videó visszatekerése lejátszás után**

Képzési bemutatóban egy demonstrációs videó elejére visszatekerése után újra lejátszhatóvá teszi azt a prezentátornak. Hívja a [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) metódust `true` értékkel, hogy a lejátszás befejezésekor a videó visszatérjen a kezdetéhez.

Ez a példa megnyit egy bemutatót, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a visszatekerést. Kikapcsolja a hurkot, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja. A bemeneti bemutatónak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik videókeret.

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

A visszatekerés a videót a kezdetére hozza anélkül, hogy újra elindulna. Ezzel szemben a [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) engedélyezése automatikusan ismétli a lejátszást. Tartsa a hurkot letiltva, amikor azt akarja, hogy a videó befejeződjön, és készen álljon az újbóli lejátszásra. A [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) önállóan szabályozza az automatikus vagy kattintásra történő indítást; ez a példa a [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) értéket használja, így a prezentátor dönt a lejátszás kezdeteiről. Állítsa be a lejátszási módot a hurok beállítása után, ahogyan a példában is látható. A visszatekerés független a [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) működésétől.

## **Videókeret vágása**

Használja a [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) és a [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) metódusokat a videó elejének vagy végének kihagyásához lejátszás közben. Mindkét érték ezredmásodpercben van megadva. A vágás megváltoztatja a lejátszási beállításokat anélkül, hogy a beágyazott videó adatát módosítaná.

**Trim beállítások beállítása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon legalább 3,5 másodperc hosszú videót, hogy egy lejátszható szegmens megmaradjon.

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

**Trim beállítások olvasása**

Ez a példa kiírja az első videókeret trim értékeit az első dián ezredmásodpercben. A bemutatónak legalább egy diát kell tartalmaznia. Ha az adott dián nincs videókeret, semmi sem kerül kiírásra. Az előző példa 2500 és 1000 értékeket ad.

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

## **Videó feliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint bemutatókban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) metóduson keresztül érhetők el.

### **Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és egy „English” feliratnyomot (WebVTT) ad hozzá. A felirat időbélyegeinek egyezniük kell a videóval. A mentett bemutató tartalmazza mind a videót, mind a feliratokat.

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) interfész egy túlterhelést is biztosít, amely lehetővé teszi feliratok hozzáadását egy folyamról.

### **Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratnyomát különálló WebVTT fájlokba menti. A sorrendben növekvő számok biztosítják, hogy a kimeneti fájlok megkülönböztethetők legyenek. A konzol jelzi a kinyert nyomok számát. A bemutatónak legalább egy diát kell tartalmaznia.

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

Minden [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) objektum kiírja a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 karakterláncként.

### **Feliratok eltávolítása videókeretből**

Ez a példa az első dián az első alakzat pozíciójában lévő videókeret összes feliratát eltávolítja, majd elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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

Ha csak egy feliratnyomot szeretne eltávolítani, használja a [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) metódust a [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) helyett.

### **Videó feliratok keresése**

Az [ICaptions::get_DataAsString](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/get_dataasstring/) visszaadja a teljes WebVTT nyomot, beleértve a fejlécet, az idővonalakat és a felirat szövegét. Egy kimondott kifejezés és annak időbélyegének megtalálásához olvassa be a jelzéseket a memóriában. Például egy angol nyom a 2. dián a következő szöveget tartalmazhatja:

```text
WEBVTT Café tour

00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

A példa megnyitja a `captioned_media.pptx` fájlt, és minden felső‑szintű videókeret feliratnyomait minden dián a [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) használatával olvassa. Egy egyszerű szöveges jelzésnél az idővonal `-->` karaktert tartalmaz, és egy üres sor zárja a jelzést. Amikor a felirat tartalmazza a „café” szót, a példa kiírja a diaszámot, a nyom címkéjét, az eredeti idővonalat és a teljes feliratot. A keresés nem érzékeny a kis-/nagybetűkre.

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

A „café” keresése egy egyezést ad a mintanyomra. A keresés kihagyja a fejlécet, és megőrzi az időbeállítást a kimenetben.

```text
Slide 2 | English | 00:00:01.000 --> 00:00:03.000 align:start
Meet me at the café
near the station.
```

## **Videó kinyerése diából**

A videók diákhoz adása mellett az Aspose.Slides lehetővé teszi a bemutatókba beágyazott videók kinyerését is.

Ez a példa minden diáról kinyeri a beágyazott videókat, és külön‑számozott bináris fájlokba menti őket. A hivatkozott (linked) videókat kihagyja, mivel azok nem tartalmaznak beágyazott adatot. A konzol kiírja minden videó MIME‑típusát és az összes darabszámot. A kimenet a generikus `.bin` kiterjesztést használja; szükség esetén cserélje le a jelentett média típusnak megfelelő kiterjesztésre.

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

## **GYIK**

**Mely videó lejátszási paraméterek módosíthatók egy videókeretnél?**

A [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) vezérelhető. Ezek a lehetőségek a [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) objektum metódusaiban érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyaz be, a bináris adat a dokumentumba kerül, így a bemutató mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik, és bélyegképet ad hozzá, a bemutató csak a hivatkozást és az előnézeti képet tárolja, nem a videó adatot, ezért a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám a pozícióját és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) cseréjével a keret geometriáját változatlanul hagyhatja; ez gyakori szituáció a médiatartalom frissítésére egy meglévő elrendezésben.

**Megállapítható-e a beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) információval, amelyet leolvashat és felhasználhat, például mentéskor lemezre.