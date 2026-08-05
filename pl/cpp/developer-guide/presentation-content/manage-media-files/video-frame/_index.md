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

PowerPoint pozwala dodać wideo do slajdu w prezentacji na dwa sposoby:

* Dodaj lub osadź lokalne wideo (przechowywane na Twoim komputerze)
* Dodaj wideo online (z źródła internetowego, takiego jak YouTube).

Aby umożliwić dodawanie wideo (obiektów wideo) do prezentacji, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) oraz interfejs [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) i inne istotne typy. 

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w prezentacji. 

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu przy użyciu jego indeksu. 
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) i podaj ścieżkę do pliku wideo, aby osadzić wideo w prezentacji. 
4. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) i utwórz ramkę dla wideo.  
5. Zapisz zmodyfikowaną prezentację. 

Ten kod C++ pokazuje, jak dodać wideo przechowywane lokalnie do prezentacji:

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

Alternatywnie możesz dodać wideo, przekazując jego ścieżkę do metody [AddVideoFrame()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapecollection/addvideoframe/):

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **Utworzenie ramki wideo z wideo z źródła internetowego**

Nowsze wersje Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługują wideo online w prezentacjach. Jeśli wideo, którego chcesz użyć, jest dostępne w Internecie (np. na YouTube), możesz dodać je do prezentacji za pomocą jego linku.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu przy użyciu jego indeksu. 
3. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) i podaj link do wideo.
4. Ustaw miniaturę dla ramki wideo. 
5. Zapisz prezentację. 

Ten kod C++ pokazuje, jak dodać wideo z sieci do slajdu w prezentacji PowerPoint:

```c++
 // Ścieżka do katalogu dokumentów.
 const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
 const String filePath = u"../templates/video1.avi";

 // Tworzy obiekt Presentation, który reprezentuje plik prezentacji
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

## **Przycięcie ramki wideo**

Aspose.Slides umożliwia kontrolowanie, która część wideo jest odtwarzana, ustawiając wartości trim-from-start i trim-from-end za pomocą [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/set_trimfromstart/) oraz [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/set_trimfromend/). Obie wartości podawane są w milisekundach i określają, ile czasu jest pomijane od początku i końca wideo. Ustawienia te zmieniają sposób odtwarzania wideo w prezentacji; nie tną ani nie modyfikują binarnych danych osadzonego wideo.

**Ustawienia przycięcia**

Aby utworzyć ramkę wideo i ustawić jej parametry przycięcia:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Dodaj obiekt [IVideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideo/) do prezentacji.
3. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) do slajdu.
4. Ustaw wartości trim-from-start i trim-from-end za pomocą [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/set_trimfromstart/) oraz [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/set_trimfromend/).
5. Zapisz zmodyfikowaną prezentację.

Poniższy przykład kodu pomija pierwsze 2,5 sekundy i ostatnią sekundę osadzonego wideo podczas odtwarzania:

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

**Odczyt ustawień przycięcia**

Aby sprawdzić istniejące ustawienia przycięcia, wczytaj prezentację, znajdź obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) wśród kształtów na pierwszym slajdzie i odczytaj wartości za pomocą [IVideoFrame::get_TrimFromStart](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_trimfromstart/) oraz [IVideoFrame::get_TrimFromEnd](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_trimfromend/).

Poniższy przykład kodu znajduje pierwszą ramkę wideo na pierwszym slajdzie i raportuje jej ustawienia przycięcia w milisekundach:

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

## **Zarządzanie napisami wideo**

Aspose.Slides pozwala zarządzać napisami zamkniętymi dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i dostępne są poprzez metodę [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/). 

**Dodawanie napisów do ramki wideo**

Aby dodać napisy do ramki wideo:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Dodaj wideo do prezentacji.
3. Dodaj obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/) do slajdu.
4. Użyj [ICaptionsCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/) zwróconego przez [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/) aby dodać ścieżkę napisów WebVTT.
5. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak dodać napisy do ramki wideo:

```cpp
auto presentation = MakeObject<Presentation>();

auto videoData = File::ReadAllBytes(u"video.mp4");
auto video = presentation->get_Videos()->AddVideo(videoData);

auto slide = presentation->get_Slide(0);
auto videoFrame = slide->get_Shapes()->AddVideoFrame(0, 0, 100, 100, video);

// Dodaje nową ścieżkę napisów z pliku WebVTT.
videoFrame->get_CaptionTracks()->Add(u"English", u"track.vtt");

presentation->Save(u"video_with_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/) oferuje również przeciążenie, które umożliwia dodanie napisów ze strumienia.

**Wyodrębnianie napisów z ramki wideo**

Aby wyodrębnić napisy z ramki wideo:

1. Wczytaj prezentację zawierającą wideo.
2. Znajdź docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/).
3. Przejdź przez wszystkie ścieżki napisów zwrócone przez [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Zapisz każdą ścieżkę napisów do pliku `.vtt`.

Poniższy kod pokazuje, jak wyodrębnić napisy z ramki wideo:

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

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz treść napisu jako ciąg UTF‑8.

**Usuwanie napisów z ramki wideo**

Aby usunąć napisy z ramki wideo:

1. Wczytaj prezentację zawierającą wideo.
2. Pobierz docelowy obiekt [IVideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/).
3. Usuń ścieżki napisów z kolekcji zwróconej przez [get_CaptionTracks](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ivideoframe/get_captiontracks/).
4. Zapisz zmodyfikowaną prezentację.

Poniższy kod pokazuje, jak usunąć wszystkie napisy z ramki wideo:

```cpp
auto presentation = MakeObject<Presentation>(u"video_with_captions.pptx");
auto slide = presentation->get_Slide(0);
auto videoFrame = ExplicitCast<IVideoFrame>(slide->get_Shape(0));

// Usuwa wszystkie napisy z ramki wideo.
videoFrame->get_CaptionTracks()->Clear();

presentation->Save(u"video_without_captions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Jeśli trzeba usunąć tylko jedną ścieżkę napisów, użyj metod [Remove](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/removeat/) zamiast [Clear](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icaptionscollection/clear/).

## **Wyodrębnianie wideo ze slajdu**

Oprócz dodawania wideo do slajdów, Aspose.Slides pozwala wyodrębnić wideo osadzone w prezentacjach.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) aby wczytać prezentację zawierającą wideo. 
2. Przejdź przez wszystkie obiekty [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/).
3. Przejdź przez wszystkie obiekty [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) aby znaleźć [VideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/). 
4. Zapisz wideo na dysku.

Ten kod C++ pokazuje, jak wyodrębnić wideo ze slajdu prezentacji:

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

**Jakie parametry odtwarzania wideo można zmienić w VideoFrame?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/set_playmode/) (automatycznie lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/set_playloopmode/). Opcje te są dostępne poprzez właściwości obiektu [VideoFrame](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzisz lokalne wideo, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy dodasz wideo online, osadzany jest jedynie link i miniatura, więc przyrost rozmiaru jest mniejszy.

**Czy mogę zamienić wideo w istniejącym VideoFrame bez zmiany jego pozycji i rozmiaru?**

Tak. Możesz podmienić [zawartość wideo](https://reference.aspose.com/slides/pl/cpp/aspose.slides/videoframe/set_embeddedvideo/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ treści (MIME) osadzonego wideo?**

Tak. Osadzone wideo ma [typ treści](https://reference.aspose.com/slides/pl/cpp/aspose.slides/video/get_contenttype/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.