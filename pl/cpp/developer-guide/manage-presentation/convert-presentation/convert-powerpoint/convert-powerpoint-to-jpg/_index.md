---
title: Konwertuj PPT i PPTX na JPG w C++
linktitle: PowerPoint do JPG
type: docs
weight: 60
url: /pl/cpp/convert-powerpoint-to-jpg/
keywords:
- konwertuj PowerPoint
- konwertuj prezentację
- konwertuj slajd
- konwertuj PPT
- konwertuj PPTX
- PowerPoint do JPG
- prezentacja do JPG
- slajd do JPG
- PPT do JPG
- PPTX do JPG
- zapisz PowerPoint jako JPG
- zapisz prezentację jako JPG
- zapisz slajd jako JPG
- zapisz PPT jako JPG
- zapisz PPTX jako JPG
- eksportuj PPT do JPG
- eksportuj PPTX do JPG
- C++
- Aspose.Slides
description: "Konwertuj slajdy PowerPoint (PPT, PPTX) na wysokiej jakości obrazy JPG w C++ przy użyciu Aspose.Slides, korzystając z szybkich i niezawodnych przykładów kodu."
---
## **Wstęp**

Konwertowanie prezentacji PowerPoint i OpenDocument do obrazów JPG ułatwia udostępnianie slajdów, optymalizację wydajności oraz osadzanie treści w witrynach internetowych lub aplikacjach. Aspose.Slides for C++ pozwala przekształcić pliki PPTX, PPT i ODP w obrazy JPEG wysokiej jakości. Ten przewodnik wyjaśnia różne metody konwersji.

Dzięki tym funkcjom łatwo zaimplementować własną przeglądarkę prezentacji i utworzyć miniaturę dla każdego slajdu. Może to być przydatne, jeśli chcesz chronić slajdy przed kopiowaniem lub pokazać prezentację w trybie tylko do odczytu. Aspose.Slides umożliwia konwersję całej prezentacji lub wybranego slajdu do formatów obrazów.

## **Konwertuj slajdy prezentacji na obrazy JPG**

Oto kroki, aby przekonwertować plik PPT, PPTX lub ODP na JPG:

1. Stwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).
2. Pobierz obiekt slajdu typu [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/) z kolekcji slajdów prezentacji.
3. Utwórz obraz slajdu przy użyciu metody [ISlide.GetImage](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/).
4. Wywołaj metodę [IImage.Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/save/) na obiekcie obrazu. Przekaż nazwę pliku wyjściowego i format obrazu jako argumenty.

{{% alert color="info" %}} 

**Uwaga:** Konwersja PPT, PPTX lub ODP do JPG różni się od konwersji do innych formatów w API Aspose.Slides for C++. Dla innych formatów zazwyczaj używa się metody [IPresentation.Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ipresentation/save/). Jednak dla konwersji JPG musisz użyć metody [IImage.Save](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iimage/save/).

{{% /alert %}} 

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/enumerator_adapter.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace System;

float scaleX = 1.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.ppt");

for (auto&& slide : presentation->get_Slides())
{
    // Utwórz obraz slajdu w określonej skali.
    auto image = slide->GetImage(scaleX, scaleY);

    // Zapisz obraz na dysku w formacie JPEG.
    auto fileName = String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Konwertuj slajdy na JPG z niestandardowymi wymiarami**

Aby zmienić wymiary wynikowych obrazów JPG, możesz ustawić rozmiar obrazu, przekazując go do metody [ISlide.GetImage(Size)](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/getimage/#islidegetimagesystemdrawingsize-method). Dzięki temu możesz generować obrazy o określonej szerokości i wysokości, zapewniając, że wynik spełnia Twoje wymagania dotyczące rozdzielczości i proporcji. Ta elastyczność jest szczególnie przydatna przy tworzeniu obrazów dla aplikacji internetowych, raportów lub dokumentacji, gdzie wymagane są precyzyjne wymiary obrazu.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size.h>
#include <system/enumerator_adapter.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

System::Drawing::Size imageSize(1200, 800);

auto presentation = MakeObject<Presentation>(u"PowerPoint-Presentation.pptx");

for (auto&& slide : presentation->get_Slides())
{
    // Utwórz obraz slajdu o określonym rozmiarze.
    auto image = slide->GetImage(imageSize);

    // Zapisz obraz na dysku w formacie JPEG.
    auto fileName = System::String::Format(u"Slide_{0}.jpg", slide->get_SlideNumber());
    image->Save(fileName, ImageFormat::Jpeg);

    image->Dispose();
}

presentation->Dispose();
```

## **Renderuj komentarze przy zapisywaniu slajdów jako obrazy**

Aspose.Slides for C++ zapewnia funkcję, która pozwala renderować komentarze na slajdach prezentacji podczas ich konwersji do obrazów JPG. Funkcjonalność ta jest szczególnie przydatna do zachowania adnotacji, uwag lub dyskusji dodanych przez współpracowników w prezentacjach PowerPoint. Włączając tę opcję, zapewniasz, że komentarze będą widoczne w wygenerowanych obrazach, co ułatwia przeglądanie i udostępnianie opinii bez konieczności otwierania oryginalnego pliku prezentacji.

Załóżmy, że mamy plik prezentacji „sample.pptx”, zawierający slajd z komentarzami:

![The slide with comments](slide_with_comments.png)

Poniższy kod C++ konwertuje slajd na obraz JPG, zachowując komentarze:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/CommentsPositions.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

float scaleX = 2.0f;
float scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
{
    auto commentOptions = MakeObject<NotesCommentsLayoutingOptions>();
    commentOptions->set_CommentsPosition(CommentsPositions::Right);
    commentOptions->set_CommentsAreaWidth(200);
    commentOptions->set_CommentsAreaColor(Color::get_DarkOrange());

    // Ustaw opcje komentarzy slajdu.
    auto options = MakeObject<RenderingOptions>();
    options->set_SlidesLayoutOptions(commentOptions);

    // Konwertuj pierwszy slajd na obraz.
    auto image = presentation->get_Slide(0)->GetImage(options, scaleX, scaleY);

    image->Save(u"Slide_1.jpg", ImageFormat::Jpeg);
    image->Dispose();
}

presentation->Dispose();
```

Wynik:

![The JPG image with comments](image_with_comments.png)

## **Zobacz także**

Zobacz inne opcje konwertowania PPT, PPTX lub ODP na obrazy, takie jak:

- [Konwertuj PowerPoint na GIF](/slides/pl/cpp/convert-powerpoint-to-animated-gif/)
- [Konwertuj PowerPoint na PNG](/slides/pl/cpp/convert-powerpoint-to-png/)
- [Konwertuj PowerPoint na TIFF](/slides/pl/cpp/convert-powerpoint-to-tiff/)
- [Konwertuj PowerPoint na SVG](/slides/pl/cpp/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Aby zobaczyć, jak Aspose.Slides konwertuje PowerPoint na obrazy JPG, wypróbuj te darmowe konwertery online: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/pl/conversion/pptx-to-jpg) oraz [PPT to JPG](https://products.aspose.app/slides/pl/conversion/ppt-to-jpg). 

{{% /alert %}}

![Free Online PPTX to JPG Converter](ppt-to-jpg.png)

{{% alert title="Wskazówka" color="info" %}}

Aspose udostępnia [DARMOWĄ aplikację internetową Collage](https://products.aspose.app/slides/pl/collage). Korzystając z tej usługi online, możesz łączyć obrazy [JPG do JPG](https://products.aspose.app/slides/pl/collage/jpg) lub PNG do PNG, tworzyć [siatki zdjęć](https://products.aspose.app/slides/pl/collage/photo-grid) i tak dalej. 

Stosując te same zasady opisane w tym artykule, możesz konwertować obrazy z jednego formatu na inny. Po więcej informacji zobacz następujące strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/cpp/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/cpp/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/cpp/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/cpp/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### Czy ta metoda obsługuje konwersję wsadową?

Tak, Aspose.Slides pozwala na konwersję wsadową wielu slajdów do JPG w jednej operacji.

### Czy konwersja obsługuje SmartArt, wykresy i inne złożone obiekty?

Tak, Aspose.Slides renderuje całą zawartość, w tym SmartArt, wykresy, tabele, kształty i inne. Dokładność renderowania może się nieco różnić w porównaniu z PowerPoint, zwłaszcza przy użyciu niestandardowych lub brakujących czcionek.

### Czy istnieją ograniczenia co do liczby slajdów, które można przetworzyć?

Sam Aspose.Slides nie nakłada ścisłych limitów na liczbę slajdów, które możesz przetworzyć. Jednak przy dużych prezentacjach lub obrazach wysokiej rozdzielczości możesz napotkać błąd braku pamięci.