---
title: Zarządzanie ramkami wideo w prezentacjach przy użyciu C++
linktitle: Ramka wideo
type: docs
weight: 10
url: /pl/cpp/video-frame/
keywords:
- dodaj wideo
- utwórz wideo
- osadź wideo
- wyodrębnij wideo
- pobierz wideo
- ramka wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Dobrze umieszczone wideo w prezentacji może uczynić Twoją wiadomość bardziej przekonującą i zwiększyć poziom zaangażowania odbiorców. 

PowerPoint umożliwia dodawanie wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) , interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) , oraz inne odpowiednie typy. 

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do swojego slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) i przekaż ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) , aby utworzyć ramkę dla wideo.  
1. Zapisz zmodyfikowaną prezentację. 

Ten kod w C++ pokazuje, jak dodać lokalnie przechowywane wideo do prezentacji:

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

Ewentualnie możesz dodać wideo, przekazując jego ścieżkę bezpośrednio do metody [AddVideoFrame()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addvideoframe/) :

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **Utworzenie ramki wideo z wideo ze źródła internetowego**

Microsoft [PowerPoint 2013 i nowsze](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) obsługuje wideo z YouTube w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne online (np. na YouTube), możesz dodać je do swojej prezentacji za pomocą linku internetowego. 

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) 
1. Uzyskaj odniesienie do slajdu za pomocą jego indeksu. 
1. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) i przekaż link do wideo. 
1. Ustaw miniaturkę dla ramki wideo. 
1. Zapisz prezentację. 

Ten kod w C++ pokazuje, jak dodać wideo z sieci do slajdu w prezentacji PowerPoint:

```c++
// Ścieżka do katalogu dokumentów.
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// Tworzy obiekt Presentation reprezentujący plik prezentacji
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Uzyskuje dostęp do pierwszego slajdu
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Dodaje ramkę wideo 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// Ustawia tryb odtwarzania i głośność wideo
vf->set_PlayMode(VideoPlayModePreset::Auto);

//Zapisuje prezentację na dysku
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/) .

**Dodaj napisy do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
1. Dodaj wideo do prezentacji.
1. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) do slajdu.
1. Użyj [ICaptionsCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/) zwróconego przez [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/) , aby dodać ścieżkę napisów WebVTT.
1. Zapisz zmodyfikowaną prezentację.

Następujący kod pokazuje, jak dodać napisy do ramki wideo:

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

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/) zapewnia również przeciążenie umożliwiające dodawanie napisów ze strumienia.

**Wyodrębnij napisy z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Załaduj prezentację zawierającą wideo.
1. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) .
1. Iteruj po ścieżkach napisów zwróconych przez [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/) .
1. Zapisz każdą ścieżkę napisów do pliku `.vtt`.

Następujący kod pokazuje, jak wyodrębnić napisy z ramki wideo:

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
            // Zapisuje ścieżkę napisów do pliku WebVTT.
            auto filePath = captionTrack->get_CaptionId().ToString() + u".vtt";
            File::WriteAllBytes(filePath, captionTrack->get_BinaryData());
        }
    }
}

presentation->Dispose();
```

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz dane napisu jako ciąg znaków UTF-8.

**Usuń napisy z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Załaduj prezentację zawierającą wideo.
1. Pobierz docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) .
1. Usuń ścieżki napisów z kolekcji zwróconej przez [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/) .
1. Zapisz zmodyfikowaną prezentację.

Następujący kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Usuwa wszystkie napisy z ramki wideo.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jeśli musisz usunąć tylko jedną ścieżkę napisów, użyj metod [Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/removeat/) zamiast [Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/clear/) .

## **Wyodrębnij wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) , aby załadować prezentację zawierającą wideo. 
2. Iteruj po wszystkich obiektach [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) .
3. Iteruj po wszystkich obiektach [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) , aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/) . 
4. Zapisz wideo na dysku.

Ten kod w C++ pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

```c++
// Ścieżka do katalogu dokumentów.
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

**Jakie parametry odtwarzania wideo można zmienić dla VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/set_playmode/) (automatyczny lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/set_playloopmode/) . Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/) .

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalne wideo, dane binarne są włączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodajesz wideo online, osadzany jest link i miniaturka, więc przyrost rozmiaru jest mniejszy.

**Czy mogę wymienić wideo w istniejącej VideoFrame bez zmiany jej położenia i rozmiaru?**

Tak. Możesz zamienić [zawartość wideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/set_embeddedvideo/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ zawartości (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [typ zawartości](https://reference.aspose.com/slides/pl/cpp/aspose.slides/video/get_contenttype/) , który możesz odczytać i wykorzystać, na przykład podczas zapisywania go na dysku.