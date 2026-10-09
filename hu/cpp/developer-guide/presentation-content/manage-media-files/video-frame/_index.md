---
title: Videókeretek kezelése prezentációkban C++ használatával
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
- webes forrás
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket PowerPoint és OpenDocument diákba az Aspose.Slides for C++ segítségével. Gyors útmutató."
---
## **Bevezetés**

A videók segíthetnek az ötletek megmagyarázásában és a közönség bevonásában. Az Aspose.Slides for C++ lehetővé teszi, hogy videókereteket adjon a diákhoz, módosítsa a lejátszási beállításokat, kezelje a feliratokat, és kinyerje a beágyazott videó adatokat.

A PowerPoint támogatja a helyi videókat és az online videókra mutató hivatkozásokat, például a YouTube‑videókat.

A videóadatok és videókeretek ábrázolásához az Aspose.Slides biztosítja az [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) interfészt és egyéb releváns típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diára hozzáadni kívánt videofájl helyi tárolású, létrehozhat egy videókeretet a videó prezentációba való beágyazásához.

Ez a példa egy helyi videót ágyaz be egy meglévő prezentáció első diájára, majd elmenti az eredményt. A keret koordinátái és méretei pontban vannak megadva. A stream nyitva marad a mentés befejezéséig, mivel a [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) zárolva tartja, amíg a prezentáció használja.

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

A helyi videó elérési útját közvetlenül is átadhatja a [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) metódusnak. Ez a példa a videót egy új prezentáció első diájára ágyazza be. A videónak a prezentáció mentéséig elérhetőnek kell maradnia.

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

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) támogatja az online videókat a prezentációkban. Létrehozhat egy videókeretet, amely online videóra, például egy YouTube‑videóra mutat.

Ez a példa egy YouTube‑videó hivatkozást és miniatűr képet ad hozzá az első diához. Cserélje le a videóazonosítót egy másik videó használatához. A [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) metódus automatikus lejátszást kér. A miniatűr letöltése és a videó lejátszása internetkapcsolatot igényel. A prezentáció megjelenítőnek szintén támogatnia kell az online videó lejátszását.

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

Egy képzési prezentációban a szoftverbemutatót teljes képernyős módban játszhatja, így a közönség láthatja a részleteket. A [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) `true` értéket fogad, hogy ezt a viselkedést a lejátszás során engedélyezze.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a teljes képernyős lejátszást. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik egy videókeret.

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

A teljes képernyős lejátszás szabályozza, hogyan jelenik meg a videó. Függetlenül ettől a [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) határozza meg, automatikusan vagy kattintásra indul-e, és a [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) szabályozza, ismétlődik‑e. A kezdési viselkedés kiválasztásához állítsa be a lejátszási módot a [VideoPlayModePreset::Auto vagy VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) értékre. A példa megőrzi a meglévő indítási és ismétlési beállításokat.

## **Videó visszatekerése a lejátszás után**

Egy képzési prezentációban a bemutató videó elejére való visszatekerése azt teszi lehetővé, hogy a bemondó újra le tudja játszani. Hívja a [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) metódust `true` értékkel, hogy a lejátszás befejezése után a videó a kezdetére kerüljön.

Ez a példa megnyit egy prezentációt, megtalálja az első [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) elemet az első dián, és engedélyezi a visszatekerést. Letiltja az ismétlést, hogy a lejátszás befejeződhessen, és a lejátszást kattintásra állítja. A bemeneti prezentációnak legalább egy diát kell tartalmaznia, amelyen az első dián már létezik egy videókeret.

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

A visszatekerés a videót a kezdetére helyezi újraindítás nélkül. Ezzel szemben a [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) engedélyezése automatikusan ismétli a lejátszást. Tartsa letiltva az ismétlést, ha azt szeretné, hogy a videó befejeződjön, és készen álljon az újbóli lejátszásra. A [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) függetlenül szabályozza az automatikus vagy kattintásra történő indítást; ez a példa a [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/) értéket használja, így a bemondó szabályozza, mikor indul a lejátszás. Állítsa be a lejátszási módot az ismétlési beállítás után, ahogyan a példában látható. A visszatekerés független a [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) beállítástól.

## **Videókeret vágása**

Használja az [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) és az [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/) metódusokat a videó elejének vagy végének egy részének kihagyásához lejátszás közben. Mindkét érték ezredmásodpercben van megadva. A vágás megváltoztatja a lejátszási beállításokat anélkül, hogy módosítaná a beágyazott videó adatokat.

**Vágási beállítások beállítása**

Ez a példa egy helyi videót ágyaz be, és a lejátszás során kihagyja az első 2,5 másodpercet és az utolsó másodpercet. Használjon 3,5 másodpercnél hosszabb videót, hogy lejátszható szegmens maradjon.

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

**Vágási beállítások olvasása**

Ez a példa kiírja az első videókeret vágási értékeit az első dián ezredmásodpercben. A prezentációnak legalább egy diasornak kell lennie. Ha az a dia nem tartalmaz videókeretet, nem kerül kiírásra semmi. Az előző példa 2500 és 1000 értékeket ad.

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

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint prezentációkban lévő videókeretekhez zárt feliratokat kezeljen. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Ez a példa egy helyi videót ágyaz be, és hozzáad egy „English” címkéjű WebVTT feliratspTracket. A feliratok időbélyegzőinek meg kell egyezniük a videóval. A mentett prezentáció tartalmazza a videót és a feliratokat is.

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) interfész szintén biztosít egy túlterhelést, amely lehetővé teszi a feliratok streamből való hozzáadását.

**Feliratok kinyerése videókeretből**

Ez a példa az első dián lévő videókeretek összes feliratsávját különálló WebVTT fájlokként menti. A sorszámok megkülönböztetik a kimeneti fájlokat. A konzol jelzi a kinyert sávok számát. A prezentációnak legalább egy diát kell tartalmaznia.

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

Minden [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) objektum elérhetővé teszi a felirat azonosítóját, címkéjét, bináris adatát és a felirat szövegét UTF‑8 karakterláncként.

**Feliratok eltávolítása videókeretből**

Ez a példa az első dia első alakzat pozíciójában lévő videókeretből eltávolítja az összes feliratot, és elmenti az eredményt. Feltételezi, hogy a dia és az alakzat létezik, és hogy az alakzat videókeret.

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

Ha csak egy feliratsávot szeretne eltávolítani, használja a [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) metódust a [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/) helyett.

## **Videó kinyerése diáról**

A videók diákra való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

Ez a példa minden diáról kinyeri a beágyazott videókat, és különálló, számozott bináris fájlokba menti őket. A hivatkozott videókat kihagyja, mert nem tartalmaznak beágyazott adatot. A konzol kiírja minden videó MIME‑típusát és a teljes számot. A kimenet általános `.bin` kiterjesztést használ; szükség esetén módosítsa a jelentett médiatípusnak megfelelően.

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

A [playback mode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) vezérelhető. Ezek az opciók a [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) objektum metódusain keresztül érhetők el.

**Az videó hozzáadása befolyásolja a PPTX fájl méretét?**

Igen. Ha egy helyi videót ágyaz be, a bináris adat bekerül a dokumentumba, így a prezentáció mérete arányosan nő a fájl méretével. Ha online videóra hivatkozik és miniatűr képet ad hozzá, a prezentáció a hivatkozást és a előnézeti képet tárolja a videó adat helyett, így a méretnövekedés általában kisebb.

**Lecserélhetem a videót egy meglévő videókeretben anélkül, hogy megváltoztatnám annak helyzetét és méretét?**

Igen. A [video content](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) cserélhető a kereten belül a forma geometriai adatait megőrizve; ez gyakori eset a meglévő elrendezésben lévő média frissítésére.

**Meghatározható-e egy beágyazott videó tartalom típusa (MIME)?**

Igen. Egy beágyazott videónak van [content type](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/) attribútuma, amelyet kiolvashat és felhasználhat, például a lemezre mentéskor.