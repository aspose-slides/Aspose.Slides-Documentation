---
title: Zarządzaj sekcjami slajdów w prezentacjach w C++
linktitle: Sekcja slajdu
type: docs
weight: 100
url: /pl/cpp/slide-section/
keywords:
- tworzenie sekcji
- dodawanie sekcji
- edytowanie sekcji
- zmiana sekcji
- nazwa sekcji
- pobieranie slajdów sekcji
- przetwarzanie slajdów sekcji
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów przy pomocy Aspose.Slides dla C++: twórz, zmieniaj nazwy, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wprowadzenie**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmiany zawartości slajdu. Dzięki Aspose.Slides for C++ możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje za pomocą metody [Presentation::get_Sections](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sections/) .

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja musi być podzielona na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj zwięzłe nazwy sekcji, które opisują cel pogrupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj API sekcji do określania przynależności zamiast wyprowadzania jej z pozycji slajdów.

## **Tworzenie i zarządzanie sekcjami**

Użyj [ISectionCollection::AddSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/addsection/) aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [ISectionCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/) umożliwia również:

- przenieść sekcję wraz z jej slajdami, używając [ISectionCollection::ReorderSectionWithSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/reordersectionwithslides/);
- usunąć tylko definicję sekcji za pomocą [ISectionCollection::RemoveSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/removesection/), zachowując jej slajdy;
- usunąć sekcję i jej slajdy za pomocą [ISectionCollection::RemoveSectionWithSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/removesectionwithslides/);
- dodać pustą sekcję na końcu za pomocą [ISectionCollection::AppendEmptySection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/appendemptysection/).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz z jej slajdami i dodaje pustą sekcję:

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto titleSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto resultsSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", titleSlide);
auto resultsSection = sections->AddSection(u"Results", resultsSlide);

sections->ReorderSectionWithSlides(resultsSection, 0);
sections->RemoveSectionWithSlides(resultsSection);
sections->AppendEmptySection(u"Appendix");
```

Po tych operacjach prezentacja zawiera sekcję `Introduction` wraz z jej slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, wywołaj [ISection::set_Name](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/set_name/). Slajdy sekcji oraz ich pozycja pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto section = presentation->get_Sections()->AddSection(u"Overview", slide);
section->set_Name(u"Introduction");
```

## **Pobieranie slajdów z sekcji**

Metoda [Presentation::get_Sections](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sections/) zwraca [ISectionCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectioncollection/), którą możesz wyliczyć. Dla każdej [ISection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/), wywołaj [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/getslideslistofsection/), aby uzyskać slajdy aktualnie do niej należące. Metoda zwraca [ISectionSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isectionslidecollection/), która zapewnia liczbę, indeksowany dostęp i enumerację.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wypisuje dla każdej sekcji jej [nazwa](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/get_name/), [identyfikator](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/get_sectionid/), [slajd początkowy](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/get_startedfromslide/), liczbę slajdów oraz numery slajdów. Używa indeksowanego dostępu, aby odczytać pierwszy slajd oraz pętli `for` opartej na zakresach, aby przetworzyć każdy slajd. Dla pustej sekcji zwrócona kolekcja ma liczbę równą zero, dostęp indeksowany nie jest używany, a enumeracja nie wykonuje żadnych iteracji.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
sections->AddSection(u"Introduction", firstSlide);
sections->AddSection(u"Details", thirdSlide);
sections->AppendEmptySection(u"Appendix");

for (const auto& section : sections)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    auto startingSlide = section->get_StartedFromSlide();

    System::Console::WriteLine(u"Section: {0}", section->get_Name());
    System::Console::WriteLine(u"ID: {0}", section->get_SectionId().ToString());
    if (startingSlide == nullptr)
    {
        System::Console::WriteLine(u"Starting slide: none");
    }
    else
    {
        System::Console::WriteLine(u"Starting slide: {0}", startingSlide->get_SlideNumber());
    }
    System::Console::WriteLine(u"Slide count: {0}", sectionSlides->get_Count());

    if (sectionSlides->get_Count() > 0)
    {
        System::Console::WriteLine(u"First slide via index: {0}", sectionSlides->idx_get(0)->get_SlideNumber());
    }

    System::Console::Write(u"Slide numbers:");
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
}
```

Członkostwo w sekcji jest określane przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/get_startedfromslide/), indeksów slajdów i slajdu początkowego następnej sekcji.

Edycje strukturalne mogą zmienić zarówno slajdy zwrócone dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz z jej slajdami, usuwanie slajdów i usuwanie sekcji. Następny przykład wywołuje [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/getslideslistofsection/) po każdej takiej zmianie zamiast zachowywać założenia o poprzednich granicach sekcji.

```cpp
#include <DOM/ISection.h>
#include <DOM/ISectionCollection.h>
#include <DOM/ISectionSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>();
auto layoutSlide = presentation->get_LayoutSlide(0);
auto firstSlide = presentation->get_Slide(0);
presentation->get_Slides()->AddEmptySlide(layoutSlide);
auto thirdSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);
presentation->get_Slides()->AddEmptySlide(layoutSlide);

auto sections = presentation->get_Sections();
auto firstSection = sections->AddSection(u"First", firstSlide);
auto secondSection = sections->AddSection(u"Second", thirdSlide);

auto printSectionSlides = [](const System::String& label, const System::SharedPtr<ISection>& section)
{
    auto sectionSlides = section->GetSlidesListOfSection();
    System::Console::Write(u"{0} ({1} slides):", label, sectionSlides->get_Count());
    for (const auto& slide : sectionSlides)
    {
        System::Console::Write(u" {0}", slide->get_SlideNumber());
    }
    System::Console::WriteLine();
};

printSectionSlides(u"Initially", firstSection);

auto slidesBeforeClone = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->AddClone(slidesBeforeClone->idx_get(0), firstSection);
printSectionSlides(u"After cloning into the section", firstSection);

auto slidesBeforeReorder = firstSection->GetSlidesListOfSection();
auto firstSlideInSection = slidesBeforeReorder->idx_get(0);
auto lastSlideInSection = slidesBeforeReorder->idx_get(slidesBeforeReorder->get_Count() - 1);
auto firstSectionPosition = firstSlideInSection->get_SlideNumber() - 1;
presentation->get_Slides()->Reorder(firstSectionPosition, lastSlideInSection);
printSectionSlides(u"After reordering slides", firstSection);

sections->ReorderSectionWithSlides(firstSection, 1);
printSectionSlides(u"After moving the section", firstSection);

auto slidesBeforeRemoval = firstSection->GetSlidesListOfSection();
presentation->get_Slides()->Remove(slidesBeforeRemoval->idx_get(0));
printSectionSlides(u"After removing a slide", firstSection);

sections->RemoveSectionWithSlides(secondSection);
for (const auto& section : sections)
{
    printSectionSlides(u"Remaining section", section);
}
```

Wywołuj [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/getslideslistofsection/) ponownie za każdym razem, gdy slajdy lub sekcje są przemieszczane, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie pozostaje zgodne z bieżącą strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Używaj tego przepływu pracy z formatem, który obsługuje sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszej enumeracji.

## **FAQ**

**Czy sekcje są zachowywane podczas zapisywania w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być "ukryta"?**

Nie. Sekcja nie ma stanu widoczności. Aby ukryć jej zawartość, wywołaj [ISlide::set_Hidden](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/set_hidden/) dla każdego slajdu w sekcji.

**Jak mogę znaleźć sekcję zawierającą dany slajd?**

Wylicz [Presentation::get_Sections](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_sections/), wywołaj [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/getslideslistofsection/) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla sekcji niepustej, [ISection::get_StartedFromSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/isection/get_startedfromslide/) zwraca jej pierwszy slajd; dla sekcji pustej zwraca `nullptr`.