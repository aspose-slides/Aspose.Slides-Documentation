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
description: "Ismerje meg, hogyan adhat hozzá és nyerhet ki programozottan videókereteket PowerPoint és OpenDocument diákat az Aspose.Slides for C++ segítségével. Gyors gyakorlati útmutató."
---
## **Bevezetés**

Egy megfelelően elhelyezett videó egy prezentációban meggyőzőbbé teheti az üzenetedet, és növelheti a közönség elkötelezettségét.

A PowerPoint két módon teszi lehetővé a videók hozzáadását egy diára a prezentációban:

* Helyi videó hozzáadása vagy beágyazása (a gépeden tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Az Aspose.Slides biztosítja az [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) interfészt, az [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) interfészt, és egyéb releváns típusokat.

## **Beágyazott videókeret létrehozása**

Ha a diához hozzáadni kívánt videófájl helyi tárolású, létrehozhatsz egy videókeretet a videó prezentációba ágyazásához.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezd meg egy dia hivatkozását az indexe alapján.
3. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) objektumot, és add meg a videófájl útvonalát a videó prezentációba ágyazásához.
4. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot a videó keret létrehozásához.  
5. Mentsd el a módosított prezentációt.

Ez a C++ kód bemutatja, hogyan adhatunk hozzá helyileg tárolt videót egy prezentációhoz:

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

Alternatív megoldásként hozzáadhatsz egy videót a fájl útvonalát közvetlenül az [AddVideoFrame()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addvideoframe/) metódusnak átadva:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) újabb verziói támogatják az online videókat a prezentációkban. Ha a használni kívánt videó online elérhető (például a YouTube-on), hozzáadhatod a prezentációhoz a webes hivatkozásán keresztül.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezd meg egy dia hivatkozását az indexe alapján.
3. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) objektumot, és add meg a videó hivatkozását.
4. Állíts be egy miniaturát a videókerethez.
5. Mentsd el a prezentációt.

Ez a C++ kód bemutatja, hogyan adhatunk hozzá egy webes videót a PowerPoint prezentáció egy diájához:

```c++
// A dokumentumok könyvtárának útvonala.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt képvisel
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Videókeretet ad hozzá 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Beállítja a videó lejátszási módját és hangerőjét
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Mentse a prezentációt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Videókeret vágása**

Az Aspose.Slides lehetővé teszi a video lejátszott részének szabályozását a trim-from-start és trim-from-end értékek beállításával az [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/set_trimfromstart/) és [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/set_trimfromend/) segítségével. Mindkét érték ezredmásodpercben van megadva, és meghatározza, hogy a videó elejéről és végéről mennyi időt hagyunk ki. Ezek a beállítások a prezentációban a videó lejátszási módját módosítják; nem vágják vagy módosítják a beágyazott videó bináris adatát.

**Trim beállítások beállítása**

Videókeret létrehozásához és trim beállításainak megadásához:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) objektumot a prezentációhoz.
3. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot egy diához.
4. Állítsd be a trim-from-start és trim-from-end értékeket az [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/set_trimfromstart/) és [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/set_trimfromend/) segítségével.
5. Mentsd el a módosított prezentációt.

A következő kódrészlet kihagyja az beágyazott videó első 2,5 másodpercét és az utolsó másodpercét a lejátszás során:

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

**Trim beállítások olvasása**

A meglévő trim beállítások megtekintéséhez tölts be egy prezentációt, keresd meg az első dián lévő alakzatok közül az [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot, és olvasd ki az értékeket a [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_trimfromstart/) és [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_trimfromend/) segítségével.

A következő kódrészlet megtalálja az első videókeretet az első dián, és jelenti annak trim beállításait ezredmásodpercben:

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

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi a videókeretekhez tartozó zárt feliratok kezelését a PowerPoint prezentációkban. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) metóduson keresztül érhetők el.

**Feliratok hozzáadása videókerethez**

Feliratok hozzáadásához egy videókerethez:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Adj hozzá egy videót a prezentációhoz.
3. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot egy diához.
4. Használd a [ICaptionsCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/) objektumot, amelyet a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) ad vissza, egy WebVTT feliratsáv hozzáadásához.
5. Mentsd el a módosított prezentációt.

A következő kód bemutatja, hogyan adhatók feliratok egy videókerethez:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Új feliratsávot ad hozzá egy WebVTT fájlból.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/) felület további overloadot is biztosít, amely lehetővé teszi feliratok hozzáadását egy streamből.

**Feliratok kinyerése egy videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltsd be azt a prezentációt, amelyik tartalmazza a videót.
2. Találd meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot.
3. Iterálj végig a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) által visszaadott feliratsávokon.
4. Mentsd el minden feliratsávot egy `.vtt` fájlba.

A következő kód bemutatja, hogyan nyerhetők ki a feliratok egy videókeretből:

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
            // A feliratsávot WebVTT fájlba menti.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait, valamint a felirat adatot UTF-8 karakterláncként.

**Feliratok eltávolítása egy videókeretből**

Feliratok eltávolításához egy videókeretből:

1. Töltsd be azt a prezentációt, amelyik tartalmazza a videót.
2. Szerezd meg a cél [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot.
3. Távolítsd el a feliratsávokat a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) által visszaadott gyűjteményből.
4. Mentsd el a módosított prezentációt.

A következő kód bemutatja, hogyan távolíthatók el az összes felirat egy videókeretből:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Eltávolítja az összes feliratot a videókeretről.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ha csak egy feliratsávot kell eltávolítani, használd a [Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/remove/) vagy [RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/removeat/) metódusokat a [Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/clear/) helyett.

## **Videó kinyerése egy diáról**

A videók diákra való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkba beágyazott videók kinyerését.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból a videót tartalmazó prezentáció betöltéséhez.
2. Iterálj végig az összes [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumon.
3. Iterálj végig az összes [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumon, hogy megtaláld a [VideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/) objektumot.
4. Mentsd el a videót a lemezre.

Ez a C++ kód bemutatja, hogyan nyerhető ki egy prezentációs diáról a videó:

```c++
// A dokumentumok könyvtárának útvonala.
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

## **Gyakran Ismételt Kérdések**

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**

A [playback mode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/set_playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/set_playloopmode/) beállítható. Ezek az opciók a [VideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.

**A videó hozzáadása befolyásolja a PPTX fájlméretet?**

Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a prezentáció mérete arányosan nő a fájlmérettel. Ha online videót adsz hozzá, egy hivatkozás és egy miniatűr kerül beágyazásra, így a méretnövekedés kisebb.

**Lecserélhető a videó egy meglévő VideoFrame-ben anélkül, hogy módosítanám a pozícióját és méretét?**

Igen. A kereten belül kicserélheted a [video content](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/set_embeddedvideo/) anélkül, hogy a forma geometria megváltozna; ez gyakori eset a média frissítésére egy meglévő elrendezésben.

**Meghatározható-e egy beágyazott videó tartalomtípusa (MIME)?**

Igen. Egy beágyazott videó rendelkezik [content type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/video/get_contenttype/) (MIME-típus) információval, amelyet kiolvashatsz és felhasználhatsz, például a lemezre mentéskor.