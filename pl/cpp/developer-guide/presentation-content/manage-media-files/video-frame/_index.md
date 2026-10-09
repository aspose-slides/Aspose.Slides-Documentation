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
- rama wideo
- źródło internetowe
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Naucz się programowo dodawać i wyodrębniać ramki wideo w slajdach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla C++. Szybki przewodnik krok po kroku."
---
## **Wprowadzenie**

Filmy mogą pomóc wyjaśnić pomysły i zaangażować odbiorców. Aspose.Slides for C++ umożliwia dodawanie ramek wideo do slajdów, dostosowywanie ustawień odtwarzania, zarządzanie napisami oraz wyodrębnianie osadzonych danych wideo.

PowerPoint obsługuje lokalne filmy oraz linki do filmów online, takich jak filmy z serwisu YouTube.

Aby przedstawić dane wideo i ramki wideo, Aspose.Slides udostępnia interfejs [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/), interfejs [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) oraz inne istotne typy.

## **Utworzenie osadzonej ramki wideo**

Jeśli plik wideo, który chcesz dodać do slajdu, jest przechowywany lokalnie, możesz utworzyć ramkę wideo, aby osadzić wideo w swojej prezentacji.

Ten przykład osadza lokalny film na pierwszym slajdzie istniejącej prezentacji i zapisuje wynik. Współrzędne i wymiary ramki podawane są w punktach. Strumień pozostaje otwarty do zakończenia zapisu, ponieważ [LoadingStreamBehavior::KeepLocked](https://reference.aspose.com/slides/cpp/aspose.slides/loadingstreambehavior/) utrzymuje go zablokowanym, gdy prezentacja go używa.

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

Możesz również przekazać ścieżkę do lokalnego wideo bezpośrednio do [AddVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/). Ten przykład osadza wideo na pierwszym slajdzie nowej prezentacji. Wideo musi pozostać dostępne do momentu zapisania prezentacji.

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

## **Utworzenie ramki wideo z wideo ze źródła internetowego**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) obsługuje filmy online w prezentacjach. Możesz utworzyć ramkę wideo, która odwołuje się do filmu online, takiego jak film z YouTube.

Ten przykład dodaje link do filmu YouTube oraz miniaturę na pierwszy slajd. Zastąp identyfikator filmu, aby użyć innego filmu. Metoda [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_playmode/) żąda automatycznego odtwarzania. Pobieranie miniatury i odtwarzanie filmu wymaga dostępu do Internetu. Przeglądarka prezentacji musi również obsługiwać odtwarzanie filmów online.

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

## **Odtwarzanie filmu w trybie pełnoekranowym**

W prezentacji szkoleniowej możesz odtworzyć demonstrację oprogramowania w trybie pełnoekranowym, aby publiczność mogła zobaczyć szczegóły. [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/) przyjmuje `true`, aby włączyć to zachowanie podczas odtwarzania.

Ten przykład otwiera prezentację, znajduje pierwszą [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) na pierwszym slajdzie i włącza odtwarzanie w trybie pełnoekranowym. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

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

Odtwarzanie w trybie pełnoekranowym kontroluje sposób wyświetlania filmu. Oddzielnie, [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) określa, czy odtwarzanie rozpoczyna się automatycznie czy po kliknięciu, a [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) kontroluje, czy się powtarza. Aby wybrać zachowanie uruchomienia, ustaw tryb odtwarzania na [VideoPlayModePreset::Auto or VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/). Przykład zachowuje istniejące ustawienia startu i pętli.

## **Przewijanie wideo po odtworzeniu**

W prezentacji szkoleniowej, przywrócenie filmu demonstracyjnego do początku sprawia, że jest gotowy do ponownego odtworzenia przez prowadzącego. Wywołaj [set_RewindVideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_rewindvideo/) z wartością `true`, aby po zakończeniu odtwarzania przywrócić film do początku.

Ten przykład otwiera prezentację, znajduje pierwszą [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) na pierwszym slajdzie i włącza przewijanie. Wyłącza pętlę, aby odtwarzanie mogło się zakończyć, oraz ustawia odtwarzanie na start po kliknięciu. Wejściowa prezentacja musi zawierać co najmniej jeden slajd z istniejącą ramką wideo na pierwszym slajdzie.

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

Przewijanie przywraca film do początku bez ponownego uruchamiania. Natomiast włączenie [set_PlayLoopMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/) powtarza odtwarzanie automatycznie. Pozostaw pętlę wyłączoną, gdy chcesz, aby film zakończył się i był gotowy do ponownego odtworzenia. [set_PlayMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) niezależnie kontroluje automatyczny lub po kliknięciu start; w tym przykładzie użyto [VideoPlayModePreset::OnClick](https://reference.aspose.com/slides/cpp/aspose.slides/videoplaymodepreset/), aby prowadzący decydował, kiedy rozpocząć odtwarzanie. Ustaw tryb odtwarzania po ustawieniu pętli, jak pokazano w przykładzie. Przewijanie działa niezależnie od [set_FullScreenMode](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_fullscreenmode/).

## **Przycinanie ramki wideo**

Użyj [IVideoFrame::set_TrimFromStart](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromstart/) i [IVideoFrame::set_TrimFromEnd](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/set_trimfromend/), aby pominąć część początku lub końca filmu podczas odtwarzania. Obie wartości podawane są w milisekundach. Przycinanie zmienia ustawienia odtwarzania bez modyfikowania osadzonych danych wideo.

**Ustawienia przycinania**

Ten przykład osadza lokalny film i pomija pierwsze 2,5 sekundy oraz ostatnią sekundę podczas odtwarzania. Użyj filmu dłuższego niż 3,5 sekundy, aby pozostał odtwarzalny segment.

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

**Odczyt ustawień przycinania**

Ten przykład wypisuje wartości przycięcia pierwszej ramki wideo na pierwszym slajdzie w milisekundach. Prezentacja musi zawierać co najmniej jeden slajd. Jeśli ten slajd nie ma ramki wideo, nic nie zostanie wypisane. Poprzedni przykład generuje wartości 2500 i 1000.

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

## **Zarządzanie napisami wideo**

Aspose.Slides umożliwia zarządzanie zamkniętymi napisami dla ramek wideo w prezentacjach PowerPoint. Napisy są przechowywane w formacie WebVTT i udostępniane za pośrednictwem metody [IVideoFrame::get_CaptionTracks](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/get_captiontracks/).

**Dodaj napisy do ramki wideo**

Ten przykład osadza lokalny film i dodaje ścieżkę napisów WebVTT oznaczoną jako English. Znaczniki czasu napisów powinny pasować do filmu. Zapisana prezentacja zawiera zarówno film, jak i jego napisy.

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

Interfejs [ICaptionsCollection](https://reference.aspose.com/slides/cpp/aspose.slides/icaptionscollection/) oferuje także przeciążenie umożliwiające dodanie napisów ze strumienia.

**Wyodrębnij napisy z ramki wideo**

Ten przykład zapisuje wszystkie ścieżki napisów z ramek wideo na pierwszym slajdzie jako oddzielne pliki WebVTT. Kolejne numery utrzymują pliki wyjściowe od siebie oddzielone. Konsola raportuje liczbę wyodrębnionych ścieżek. Prezentacja musi zawierać co najmniej jeden slajd.

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

Każdy obiekt [ICaptions](https://reference.aspose.com/slides/cpp/aspose.slides/icaptions/) udostępnia identyfikator napisu, etykietę, dane binarne oraz tekst napisu jako ciąg UTF‑8.

**Usuń napisy z ramki wideo**

Ten przykład usuwa wszystkie napisy z ramki wideo w pierwszej pozycji kształtu na pierwszym slajdzie i zapisuje wynik. Zakłada, że slajd i kształt istnieją oraz że kształt jest ramką wideo.

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

Jeśli potrzebujesz usunąć tylko jedną ścieżkę napisów, użyj metod [Remove](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/remove/) lub [RemoveAt](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/removeat/) zamiast [Clear](https://reference.aspose.com/slides/cpp/aspose.slides/captionscollection/clear/).

## **Wyodrębnianie wideo ze slajdu**

Oprócz dodawania filmów do slajdów, Aspose.Slides umożliwia wyodrębnianie wideo osadzonego w prezentacjach.

Ten przykład wyodrębnia osadzone filmy ze wszystkich slajdów do oddzielnych, numerowanych plików binarnych. Filmy powiązane są pomijane, ponieważ nie mają osadzonych danych. Konsola wypisuje typ MIME każdego filmu oraz łączną liczbę. Wyjście używa ogólnego rozszerzenia `.bin`; w razie potrzeby zmień je, aby pasowało do zgłaszanego typu mediów.

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

**Które parametry odtwarzania wideo można zmienić dla ramki wideo?**

Możesz kontrolować [tryb odtwarzania](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/) (automatycznie lub po kliknięciu) oraz [pętlę](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/). Opcje te są dostępne za pośrednictwem metod obiektu [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/).

**Czy dodanie wideo wpływa na rozmiar pliku PPTX?**

Tak. Gdy osadzasz lokalny film, dane binarne są dołączane do dokumentu, więc rozmiar prezentacji rośnie proporcjonalnie do rozmiaru pliku. Gdy linkujesz do filmu online i dodajesz miniaturę, prezentacja przechowuje link i obraz podglądu zamiast danych wideo, więc przyrost rozmiaru jest zazwyczaj mniejszy.

**Czy mogę zastąpić wideo w istniejącej ramce wideo bez zmiany jej położenia i rozmiaru?**

Tak. Możesz zamienić [zawartość wideo](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/) w ramce, zachowując geometrię kształtu; jest to typowy scenariusz aktualizacji mediów w istniejącym układzie.

**Czy można określić typ treści (MIME) osadzonego wideo?**

Tak. Osadzone wideo posiada [typ treści](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/), który możesz odczytać i wykorzystać, na przykład przy zapisywaniu go na dysk.