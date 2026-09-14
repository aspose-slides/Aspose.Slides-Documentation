---
title: "Zarządzanie sekcjami slajdów w prezentacjach przy użyciu Pythona via Java"
linktitle: "Sekcja slajdu"
type: docs
weight: 90
url: /pl/python-java/slide-section/
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
- Java
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów przy użyciu Aspose.Slides for Python via Java: twórz, zmieniaj nazwę, zmieniaj kolejność, pobieraj i przetwarzaj slajdy sekcji w prezentacjach PPTX."
---
## **Wprowadzenie**

Sekcje organizują kolejne slajdy w nazwane grupy bez zmiany zawartości slajdów. Za pomocą Aspose.Slides for Python via Java możesz tworzyć, zmieniać kolejność, zmieniać nazwę, przeglądać i usuwać sekcje za pomocą metody [Presentation.getSections](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSections) .

Sekcje są szczególnie przydatne, gdy:

- duża prezentacja musi zostać podzielona na logiczne tematy lub rozdziały;
- różne grupy slajdów są przydzielane różnym współpracownikom;
- slajdy muszą być przetwarzane, przenoszone lub łączone jako grupy.

Wybieraj zwięzłe nazwy sekcji, które opisują cel zgrupowanych slajdów. Ponieważ sekcje są częścią struktury prezentacji, używaj API sekcji do określania przynależności zamiast wyprowadzania jej z pozycji slajdów.

## **Utworzenie i zarządzanie sekcjami**

Użyj [SectionCollection.addSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/#addSection) aby utworzyć sekcję, podając jej nazwę i slajd początkowy. Aspose.Slides określa, które slajdy należą do sekcji, na podstawie bieżącej struktury sekcji w prezentacji.

Ta sama [SectionCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/) umożliwia również:

- przeniesienie sekcji wraz z jej slajdami za pomocą [reorderSectionWithSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/#reorderSectionWithSlides);
- usunięcie tylko definicji sekcji przy użyciu [removeSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/#removeSection), zachowując jej slajdy;
- usunięcie sekcji wraz z jej slajdami przy użyciu [removeSectionWithSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/#removeSectionwithslides);
- dodanie pustej sekcji na końcu przy użyciu [appendEmptySection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/#appendEmptySection).

Poniższy przykład tworzy dwie sekcje, przenosi jedną z nich, usuwa ją wraz z jej slajdami i dodaje pustą sekcję:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    title_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    results_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", title_slide)
    results_section = presentation.getSections().addSection("Results", results_slide)

    presentation.getSections().reorderSectionWithSlides(results_section, 0)
    presentation.getSections().removeSectionWithSlides(results_section)
    presentation.getSections().appendEmptySection("Appendix")
finally:
    presentation.dispose()
```

Po tych operacjach prezentacja zawiera sekcję `Introduction` wraz z jej slajdami oraz pustą sekcję `Appendix`. Sekcja `Results` i jej slajdy zostały usunięte.

## **Zmienianie nazw sekcji**

Aby zmienić nazwę sekcji, wywołaj jej metodę [Section.setName](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#setName). Slajdy sekcji i jej pozycja pozostają niezmienione.

Poniższy przykład tworzy sekcję i zmienia jej nazwę:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    section = presentation.getSections().addSection("Overview", slide)
    section.setName("Introduction")
finally:
    presentation.dispose()
```

## **Pobieranie slajdów z sekcji**

Metoda [Presentation.getSections](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSections) zwraca [SectionCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectioncollection/), po którym można iterować. Dla każdej [Section](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/) wywołaj [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getSlidesListOfSection), aby uzyskać slajdy aktualnie do niej należące. Metoda zwraca [SectionSlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectionslidecollection/), który zapewnia liczbę, dostęp indeksowy i iterację.

Poniższy przykład tworzy dwie wypełnione sekcje i jedną pustą sekcję, a następnie wyświetla nazwę każdej sekcji ([name]), identyfikator ([identifier]), slajd początkowy ([starting slide]), liczbę slajdów oraz numery slajdów. Używa [SectionSlideCollection.get_Item](https://reference.aspose.com/slides/pl/python-java/aspose.slides/sectionslidecollection/#get_Item) do odczytania pierwszego slajdu oraz instrukcji `for` do przetworzenia każdego slajdu. Dla pustej sekcji zwrócona kolekcja ma rozmiar zero, metoda nie jest wywoływana, a iteracja nie wykonuje żadnych operacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)

    presentation.getSections().addSection("Introduction", first_slide)
    presentation.getSections().addSection("Details", third_slide)
    presentation.getSections().appendEmptySection("Appendix")

    for section in presentation.getSections():
        section_slides = section.getSlidesListOfSection()
        starting_slide = "none" if section.getStartedFromSlide() is None else str(section.getStartedFromSlide().getSlideNumber())

        print("Section: ", section.getName(), sep="")
        print("ID: ", section.getSectionId(), sep="")
        print("Starting slide: ", starting_slide, sep="")
        print("Slide count: ", section_slides.size(), sep="")

        if section_slides.size() > 0:
            print("First slide via get_Item: ", section_slides.get_Item(0).getSlideNumber(), sep="")

        print("Slide numbers:", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()
finally:
    presentation.dispose()
```

Przynależność do sekcji jest określana przez strukturę sekcji w prezentacji. Nie obliczaj ręcznie zakresu sekcji na podstawie [Section.getStartedFromSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getStartedFromSlide), indeksów slajdów i slajdu początkowego następnej sekcji.

Edytowanie struktury może zmienić zarówno slajdy zwrócone dla sekcji, jak i ich numery. Obejmuje to zmianę kolejności slajdów, klonowanie slajdu do sekcji, przenoszenie sekcji wraz z jej slajdami, usuwanie slajdów i usuwanie sekcji. Następny przykład wywołuje [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getSlidesListOfSection) po każdej takiej zmianie zamiast zachowywać założenia co do wcześniejszych granic sekcji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    presentation.getSlides().addEmptySlide(layout_slide)
    third_slide = presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
    first_section = presentation.getSections().addSection("First", first_slide)
    second_section = presentation.getSections().addSection("Second", third_slide)

    def print_section_slides(label, section):
        section_slides = section.getSlidesListOfSection()
        print(f"{label} ({section_slides.size()} slides):", end="")
        for slide in section_slides:
            print(" ", slide.getSlideNumber(), sep="", end="")
        print()

    print_section_slides("Initially", first_section)

    slides_before_clone = first_section.getSlidesListOfSection()
    presentation.getSlides().addClone(slides_before_clone.get_Item(0), first_section)
    print_section_slides("After cloning into the section", first_section)

    slides_before_reorder = first_section.getSlidesListOfSection()
    first_section_position = slides_before_reorder.get_Item(0).getSlideNumber() - 1
    presentation.getSlides().reorder(first_section_position, slides_before_reorder.get_Item(slides_before_reorder.size() - 1))
    print_section_slides("After reordering slides", first_section)

    presentation.getSections().reorderSectionWithSlides(first_section, 1)
    print_section_slides("After moving the section", first_section)

    slides_before_removal = first_section.getSlidesListOfSection()
    presentation.getSlides().remove(slides_before_removal.get_Item(0))
    print_section_slides("After removing a slide", first_section)

    presentation.getSections().removeSectionWithSlides(second_section)
    for section in presentation.getSections():
        print_section_slides("Remaining section", section)
finally:
    presentation.dispose()
```

Wywołuj [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getSlidesListOfSection) ponownie za każdym razem, gdy slajdy lub sekcje są zmieniane kolejnością, klonowane, przenoszone lub usuwane. Dzięki temu dalsze przetwarzanie będzie zgodne z bieżącą strukturą prezentacji.

Format PPT (PowerPoint 97–2003) nie zachowuje metadanych sekcji. Używaj tego przepływu pracy z formatem obsługującym sekcje, takim jak PPTX; konwersja do PPT usuwa strukturę sekcji potrzebną do późniejszej iteracji.

## **FAQ**

**Czy sekcje są zachowywane przy zapisie w formacie PPT (PowerPoint 97–2003)?**

Nie. Format PPT nie obsługuje metadanych sekcji, więc grupowanie sekcji zostaje utracone przy zapisie do .ppt.

**Czy cała sekcja może być „ukryta”?**

Nie. Sekcja nie posiada stanu widoczności. Aby ukryć jej zawartość, wywołaj [Slide.setHidden](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#setHidden) dla każdego slajdu w sekcji.

**Jak znaleźć sekcję zawierającą dany slajd?**

Iteruj po kolekcji zwróconej przez [Presentation.getSections](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSections), wywołaj [Section.getSlidesListOfSection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getSlidesListOfSection) dla każdej sekcji i porównaj zwrócone slajdy z docelowym slajdem. Dla niepustej sekcji [Section.getStartedFromSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/section/#getStartedFromSlide) zwraca jej pierwszy slajd; dla pustej sekcji zwraca `None`.