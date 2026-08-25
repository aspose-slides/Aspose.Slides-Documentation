---
title: Zarządzanie sekcjami slajdów w prezentacjach przy użyciu Pythona
linktitle: Sekcja slajdu
type: docs
weight: 100
url: /pl/python-net/slide-section/
keywords:
- tworzenie sekcji
- dodawanie sekcji
- edycja sekcji
- zmiana sekcji
- nazwa sekcji
- pobieranie slajdów sekcji
- przetwarzanie slajdów sekcji
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów przy użyciu Aspose.Slides for Python via .NET: twórz, zmieniaj nazwę, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wprowadzenie**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmiany zawartości slajdów. Za pomocą Aspose.Slides for Python via .NET możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje poprzez właściwość [Presentation.sections](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sections/) .

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja wymaga podzielenia na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj zwięzłe nazwy sekcji opisujące cel grupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj API sekcji do określania przynależności zamiast wyprowadzania jej z pozycji slajdów.

## **Tworzenie i zarządzanie sekcjami**

Użyj [SectionCollection.add_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/add_section/) aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [SectionCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/) również umożliwia:

- przenieść sekcję wraz ze jej slajdami, używając [SectionCollection.reorder_section_with_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/reorder_section_with_slides/);
- usunąć jedynie definicję sekcji za pomocą [SectionCollection.remove_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/remove_section/), zachowując jej slajdy;
- usunąć sekcję wraz z jej slajdami za pomocą [SectionCollection.remove_section_with_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/remove_section_with_slides/);
- dodać pustą sekcję na końcu za pomocą [SectionCollection.append_empty_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/append_empty_section/).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz ze slajdami i dołącza pustą sekcję:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    title_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    results_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", title_slide)
    results_section = presentation.sections.add_section("Results", results_slide)

    presentation.sections.reorder_section_with_slides(results_section, 0)
    presentation.sections.remove_section_with_slides(results_section)
    presentation.sections.append_empty_section("Appendix")
```

Po tych operacjach prezentacja zawiera sekcję `Introduction` z jej slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` oraz jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, ustaw jej właściwość [Section.name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/name/). Slajdy sekcji i jej pozycja pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    section = presentation.sections.add_section("Overview", slide)
    section.name = "Introduction"
```

## **Pobieranie slajdów z sekcji**

Właściwość [Presentation.sections](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sections/) zwraca [SectionCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectioncollection/), nad którym możesz iterować. Dla każdej [Section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/), wywołaj [Section.get_slides_list_of_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/get_slides_list_of_section/), aby uzyskać slajdy aktualnie do niej należące. Metoda zwraca [SectionSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/sectionslidecollection/), który zapewnia liczbę, dostęp indeksowy i iterację.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wypisuje każdy [name](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/name/), [identifier](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/section_id/), [starting slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/started_from_slide/), liczbę slajdów i numery slajdów sekcji. Używa dostępu indeksowego do odczytania pierwszego slajdu oraz pętli `for` do przetworzenia wszystkich slajdów. Dla pustej sekcji zwrócona kolekcja ma licznik równy zero, indeks nie jest używany, a iteracja nie wykonuje żadnych kroków.

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])

    presentation.sections.add_section("Introduction", first_slide)
    presentation.sections.add_section("Details", third_slide)
    presentation.sections.append_empty_section("Appendix")

    for section in presentation.sections:
        section_slides = section.get_slides_list_of_section()
        starting_slide = "none" if section.started_from_slide is None else str(section.started_from_slide.slide_number)

        print(f"Section: {section.name}")
        print(f"ID: {section.section_id}")
        print(f"Starting slide: {starting_slide}")
        print(f"Slide count: {section_slides.count}")

        if section_slides.count > 0:
            print(f"First slide via index: {section_slides[0].slide_number}")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(f" {slide.slide_number}", end="")
        print()
```

Członkostwo w sekcji jest określane przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [Section.started_from_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/started_from_slide/), indeksów slajdów i początkowego slajdu kolejnej sekcji.

Edycje strukturalne mogą zmienić zarówno slajdy zwracane dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz ze slajdami, usuwanie slajdów i usuwanie sekcji. Następny przykład wywołuje [Section.get_slides_list_of_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/get_slides_list_of_section/) po każdej takiej zmianie zamiast utrzymywać założenia o wcześniejszych granicach sekcji.

```py
import aspose.slides as slides


def print_section_slides(label, section):
    section_slides = section.get_slides_list_of_section()
    print(f"{label} ({section_slides.count} slides):", end="")
    for slide in section_slides:
        print(f" {slide.slide_number}", end="")
    print()


with slides.Presentation() as presentation:
    first_slide = presentation.slides[0]
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    third_slide = presentation.slides.add_empty_slide(presentation.layout_slides[0])
    presentation.slides.add_empty_slide(presentation.layout_slides[0])
    first_section = presentation.sections.add_section("First", first_slide)
    second_section = presentation.sections.add_section("Second", third_slide)

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.get_slides_list_of_section()
    presentation.slides.add_clone(slides_before_clone[0], first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.get_slides_list_of_section()
    first_section_position = slides_before_reorder[0].slide_number - 1
    presentation.slides.reorder(first_section_position, slides_before_reorder[slides_before_reorder.count - 1])
    print_section_slides("After reordering slides", first_section)

    presentation.sections.reorder_section_with_slides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.get_slides_list_of_section()
    presentation.slides.remove(slides_before_removal[0])
    print_section_slides("After removing a slide", first_section)

    presentation.sections.remove_section_with_slides(second_section)
    for section in presentation.sections:
        print_section_slides("Remaining section", section)
```

Wywołuj ponownie [Section.get_slides_list_of_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/get_slides_list_of_section/) gdy tylko slajdy lub sekcje są przemieszczane, klonowane, przenoszone lub usuwane. Dzięki temu kolejne przetwarzanie jest zgodne z bieżącą strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Używaj tego przepływu pracy z formatem obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszej iteracji.

## **FAQ**

**Czy sekcje są zachowywane przy zapisywaniu w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji jest tracone przy zapisywaniu do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Sekcja nie posiada stanu widoczności. Aby ukryć jej zawartość, ustaw właściwość [Slide.hidden](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/hidden/) dla każdego slajdu w sekcji.

**Jak mogę znaleźć sekcję zawierającą dany slajd?**

Iteruj po [Presentation.sections](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/sections/), wywołaj [Section.get_slides_list_of_section](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/get_slides_list_of_section/) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [Section.started_from_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/section/started_from_slide/) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `None`.