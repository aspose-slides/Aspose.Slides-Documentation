---
title: Spravujte video rámce v prezentacích pomocí C++
linktitle: Video rámec
type: docs
weight: 10
url: /cs/cpp/video-frame/
keywords:
- přidat video
- vytvořit video
- vložit video
- extrahovat video
- získat video
- video rámec
- webový zdroj
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Naučte se programově přidávat a extrahovat video rámce v PowerPoint a OpenDocument snímcích pomocí Aspose.Slides pro C++. Rychlý návod."
---
## **Úvod**

Dobře umístěné video v prezentaci může učinit vaše sdělení přesvědčivějším a zvýšit úroveň zapojení publika. 

PowerPoint vám umožňuje přidávat videa do snímku v prezentaci dvěma způsoby:

* Přidat nebo vložit lokální video (uložené ve vašem počítači)
* Přidat online video (z webového zdroje, například YouTube).

Aby vám Aspose.Slides umožnil přidávat videa (video objekty) do prezentace, poskytuje rozhraní [IVideo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideo/), rozhraní [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) a další související typy. 

## **Vytvoření vloženého video rámce**

Pokud je video soubor, který chcete přidat do svého snímku, uložen lokálně, můžete vytvořit video rámec pro vložení videa do vaší prezentace. 

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
1. Získejte odkaz na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideo/) a předávejte cestu k video souboru pro vložení videa do prezentace. 
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) pro vytvoření rámce pro video.  
1. Uložte upravenou prezentaci. 

Tento C++ kód vám ukazuje, jak přidat lokálně uložené video do prezentace:

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

Alternativně můžete přidat video tím, že jeho cestu k souboru předáte přímo metodě [AddVideoFrame()](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Vytvoření video rámce s videem z webového zdroje**

Microsoft [PowerPoint 2013 a novější](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) podporuje videa z YouTube v prezentacích. Pokud je video, které chcete použít, dostupné online (např. na YouTube), můžete jej přidat do prezentace pomocí jeho webového odkazu. 

1. Vytvořte instanci třídy [Presentation ](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) 
1. Získejte odkaz na snímek pomocí jeho indexu. 
1. Přidejte objekt [IVideo](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideo/) a předávejte odkaz na video.
1. Nastavte náhled pro video rámec. 
1. Uložte prezentaci. 

Tento C++ kód vám ukazuje, jak přidat video z webu do snímku v PowerPoint prezentaci:

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Vytvoří objekt Presentation, který představuje soubor prezentace
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Přidá video rámec 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Nastaví režim přehrávání a hlasitost videa
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Uloží prezentaci na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Správa titulků videa**

Aspose.Slides vám umožňuje spravovat uzavřené titulky pro video rámce v PowerPoint prezentacích. Titulky jsou uloženy ve formátu WebVTT a jsou zpřístupněny prostřednictvím metody [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Přidat titulky do video rámce**

Pro přidání titulků do video rámce:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Přidejte video do prezentace.
1. Přidejte objekt [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/) na snímek.
1. Použijte [ICaptionsCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/) vrácenou metodou [get_CaptionTracks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/get_captiontracks/) k přidání WebVTT stopy titulků.
1. Uložte upravenou prezentaci.

Následující kód vám ukazuje, jak přidat titulky do video rámce:

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

Rozhraní [ICaptionsCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/) také poskytuje přetížení, které vám umožní přidat titulky ze streamu.

**Extrahovat titulky z video rámce**

Pro extrahování titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Najděte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/).
1. Procházejte stopy titulků vrácené metodou [get_CaptionTracks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Uložte každou stopu titulků do souboru `.vtt`.

Následující kód vám ukazuje, jak extrahovat titulky z video rámce:

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
                    // Uloží stopu titulků do souboru WebVTT.
                    auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
                    File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Každý objekt [ICaptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptions/) poskytuje identifikátor titulků, popisek, binární data a data titulků jako řetězec UTF-8.

**Odstranit titulky z video rámce**

Pro odstranění titulků z video rámce:

1. Načtěte prezentaci, která obsahuje video.
1. Získejte cílový objekt [IVideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/).
1. Odstraňte stopy titulků ze sbírky vrácené metodou [get_CaptionTracks](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ivideoframe/get_captiontracks/).
1. Uložte upravenou prezentaci.

Následující kód vám ukazuje, jak odstranit všechny titulky z video rámce:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Odstraní všechny titulky z video rámce.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Pokud potřebujete odstranit pouze jednu stopu titulků, použijte metody [Remove](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/remove/) nebo [RemoveAt](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/removeat/) místo [Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides/icaptionscollection/clear/).

## **Extrahování videa ze snímku**

Kromě přidávání videí do snímků vám Aspose.Slides umožňuje extrahovat videa vložená v prezentacích.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) pro načtení prezentace obsahující video. 
2. Procházejte všechny objekty [ISlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islide/).
3. Procházejte všechny objekty [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) a najděte [VideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/videoframe/). 
4. Uložte video na disk.

Tento C++ kód vám ukazuje, jak extrahovat video ze snímku prezentace:

```c++
// Cesta k adresáři dokumentů.
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

## **Často kladené otázky**

**Které parametry přehrávání videa lze změnit pro VideoFrame?**

Můžete ovládat [režim přehrávání](https://reference.aspose.com/slides/cs/cpp/aspose.slides/videoframe/set_playmode/) (automaticky nebo při kliknutí) a [opakování](https://reference.aspose.com/slides/cs/cpp/aspose.slides/videoframe/set_playloopmode/). Tyto možnosti jsou dostupné prostřednictvím vlastností objektu [VideoFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/videoframe/).

**Ovlivňuje přidání videa velikost souboru PPTX?**

Ano. Když vložíte lokální video, binární data jsou zahrnuta do dokumentu, takže velikost prezentace roste úměrně velikosti souboru. Když přidáte online video, vloží se odkaz a náhled, takže nárůst velikosti je menší.

**Mohu nahradit video v existujícím VideoFrame, aniž bych změnil jeho pozici a velikost?**

Ano. Můžete vyměnit [obsah videa](https://reference.aspose.com/slides/cs/cpp/aspose.slides/videoframe/set_embeddedvideo/) uvnitř rámce při zachování geometrie tvaru; to je běžný scénář pro aktualizaci médií v existujícím rozložení.

**Lze určit typ obsahu (MIME) vloženého videa?**

Ano. Vložené video má [typ obsahu](https://reference.aspose.com/slides/cs/cpp/aspose.slides/video/get_contenttype/), který můžete přečíst a použít, například při ukládání na disk.