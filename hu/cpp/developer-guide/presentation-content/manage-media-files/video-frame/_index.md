---
title: "Videókeretek kezelése prezentációkban C++ használatával"
linktitle: "Videókeret"
type: docs
weight: 10
url: /hu/cpp/video-frame/
keywords:
  - "videó hozzáadása"
  - "videó létrehozása"
  - "videó beágyazása"
  - "videó kinyerése"
  - "videó lekérése"
  - "videókeret"
  - "webes forrás"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentáció"
  - "C++"
  - "Aspose.Slides"
description: "Tanulja meg programozott módon videókeretek hozzáadását és kinyerését PowerPoint és OpenDocument diákban az Aspose.Slides for C++ segítségével. Gyors útmutató."
---
## **Bevezetés**

Egy jól elhelyezett videó a prezentációban meggyőzőbbé teheti az üzenetedet, és növelheti a közönséged elkötelezettségét.  

A PowerPoint lehetővé teszi, hogy videókat adj hozzá egy diára a prezentációban két módon:

* Helyi videó hozzáadása vagy beágyazása (a gépeden tárolt)
* Online videó hozzáadása (webes forrásból, például a YouTube-ról).

Az Aspose.Slides lehetővé teszi, hogy videókat (videoobjektumokat) adj hozzá egy prezentációhoz, a [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) interfész, a [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) interfész, és egyéb releváns típusok biztosítva.  

## **Beágyazott videókeret létrehozása**

Ha a diádhoz hozzáadni kívánt videófájl helyileg tárolódik, létrehozhatsz egy videókeretet a videó beágyazásához a prezentációban.  

1. Hozz létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)osztályból.  
1. Szerezz hivatkozást egy diára az indexe alapján.  
1. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) objektumot, és add meg a videófájl útvonalát a videó beágyazásához a prezentációba.  
1. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot a videó keret létrehozásához.  
1. Mentsd el a módosított prezentációt.  

Ez a C++ kód megmutatja, hogyan lehet helyileg tárolt videót hozzáadni a prezentációhoz:

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

Alternatív megoldásként videót adhatsz hozzá a fájl útvonalát közvetlenül az [AddVideoFrame()](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addvideoframe/) metódusnak átadva:

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Videókeret létrehozása webes forrásból származó videóval**

A Microsoft [PowerPoint 2013 és újabb](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) támogatja a YouTube videókat a prezentációkban. Ha a használni kívánt videó online érhető el (pl. a YouTube-on), hozzáadhatod a prezentációhoz a webes hivatkozásán keresztül.  

1. Hozz létre egy példányt a [Presentation ](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)osztályból.  
1. Szerezz hivatkozást egy diára az indexe alapján.  
1. Adj hozzá egy [IVideo](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideo/) objektumot, és add meg a videó linkjét.  
1. Állíts be egy bélyegképet a videókerethez.  
1. Mentsd el a prezentációt.  

Ez a C++ kód megmutatja, hogyan lehet webes videót hozzáadni egy diához egy PowerPoint prezentációban:

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Létrehoz egy Presentation objektumot, amely egy prezentációs fájlt reprezentál
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Videókeretet ad hozzá 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Beállítja a videó lejátszási módját és hangerőjét
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Mentés a prezentációt a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Videófeliratok kezelése**

Az Aspose.Slides lehetővé teszi, hogy a PowerPoint prezentációk videókereteihez lezárt feliratokat kezeld. A feliratok WebVTT formátumban tárolódnak, és a [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) metóduson keresztül érhetők el.  

**Feliratok hozzáadása egy videókerethez**

Feliratok hozzáadásához egy videókerethez:

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)osztályból.  
1. Adj hozzá egy videót a prezentációhoz.  
1. Adj hozzá egy [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot egy diához.  
1. Használd a [ICaptionsCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/) objektumot, amelyet a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) visszaad, WebVTT feliratcímke hozzáadásához.  
1. Mentsd el a módosított prezentációt.  

A következő kód megmutatja, hogyan adhatók feliratok egy videókerethez:

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

Az [ICaptionsCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/) interfész további túlterhelést is biztosít, amely lehetővé teszi a feliratok áramlásból történő hozzáadását.  

**Feliratok kinyerése egy videókeretből**

Feliratok kinyeréséhez egy videókeretből:

1. Töltsd be a videót tartalmazó prezentációt.  
1. Találd meg a célzott [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot.  
1. Iterálj végig a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) által visszaadott feliratcímkéken.  
1. Mentsd el minden feliratcímkét egy `.vtt` fájlba.  

A következő kód megmutatja, hogyan nyerhetők ki feliratok egy videókeretből:

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
            // A feliratcímkét WebVTT fájlba menti.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Minden [ICaptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptions/) objektum tartalmazza a felirat azonosítóját, címkéjét, bináris adatait, valamint a felirat adatot UTF‑8 karakterláncként.  

**Feliratok eltávolítása egy videókeretből**

Feliratok eltávolításához egy videókeretből:

1. Töltsd be a videót tartalmazó prezentációt.  
1. Szerezd meg a célzott [IVideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/) objektumot.  
1. Távolítsd el a feliratcímkéket a [get_CaptionTracks](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ivideoframe/get_captiontracks/) által visszaadott gyűjteményből.  
1. Mentsd el a módosított prezentációt.  

A következő kód megmutatja, hogyan távolíthatók el minden felirat egy videókeretből:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Eltávolítja az összes feliratot a videókeretből.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ha csak egy feliratcímkét szeretnél eltávolítani, használd a [Remove](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/remove/) vagy a [RemoveAt](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/removeat/) metódusokat a [Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icaptionscollection/clear/) helyett.  

## **Videó kinyerése egy diáról**

A videók diákhoz való hozzáadása mellett az Aspose.Slides lehetővé teszi a prezentációkban beágyazott videók kinyerését is.  

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)osztályból a videót tartalmazó prezentáció betöltéséhez.  
2. Iterálj végig az összes [ISlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/) objektumon.  
3. Iterálj végig az összes [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumon, hogy megtaláld a [VideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/) objektumot.  
4. Mentsd el a videót a lemezre.  

Ez a C++ kód megmutatja, hogyan nyerhető ki a videó egy prezentációs diáról:

```c++
// A dokumentumok könyvtárának elérési útja.
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

## **GYIK**

**Mely videolejátszási paraméterek módosíthatók egy VideoFrame esetén?**  
A [playback mode](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/set_playmode/) (automatikus vagy kattintásra) és a [looping](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/set_playloopmode/) mód beállítható. Ezek a beállítások a [VideoFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/) objektum tulajdonságain keresztül érhetők el.  

**A videó hozzáadása befolyásolja a PPTX fájl méretét?**  
Igen. Ha helyi videót ágyazol be, a bináris adat a dokumentumba kerül, így a prezentáció mérete a fájlmérettel arányosan nő. Online videó esetén csak egy hivatkozás és egy bélyegkép kerül beágyazásra, így a méretnövekedés kisebb.  

**Lecserélhetem a videót egy meglévő VideoFrame-ben anélkül, hogy megváltoztatnám a pozícióját és méretét?**  
Igen. A [video content](https://reference.aspose.com/slides/hu/cpp/aspose.slides/videoframe/set_embeddedvideo/) cseréjével a keretben megőrizheted a forma geometriáját; ez gyakori módja a médiák frissítésének egy már létező elrendezésben.  

**Megállapítható-e a beágyazott videó tartalomtípusa (MIME)?**  
Igen. A beágyazott videó rendelkezik egy [content type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/video/get_contenttype/) attribútummal, amely leolvasható és felhasználható, például a lemezre való mentéskor.