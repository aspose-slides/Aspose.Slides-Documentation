---
title: Układ slajdu
type: docs
weight: 20
url: /pl/python-net/examples/elements/layout-slide/
keywords:
- układ slajdu
- dodaj układ slajdu
- dostęp do układu slajdu
- usuń układ slajdu
- nieużywany układ slajdu
- klonuj układ slajdu
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Użyj Pythona do zarządzania układami slajdów za pomocą Aspose.Slides: twórz, stosuj, klonuj, zmieniaj nazwy i dostosowuj elementy zastępcze oraz motywy w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak pracować z **Layout Slides** w Aspose.Slides dla Pythona w .NET. Układ slajdu definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać układy slajdów, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

## **Dodaj układ slajdu**

Możesz utworzyć niestandardowy układ slajdu, aby zdefiniować wielokrotnie używane formatowanie.

```py
def add_layout_slide():
    with slides.Presentation() as presentation:
        master_slide = presentation.masters[0]
        layout_type = slides.SlideLayoutType.CUSTOM
        layout_name = "Main layout"

        # Utwórz slajd układu z określonym typem i nazwą.
        layout_slide = presentation.layout_slides.add(master_slide, layout_type, layout_name)

        presentation.save("layout_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Tip 1:** Układy slajdów działają jako szablony dla poszczególnych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.

> 💡 **Tip 2:** Kiedy dodasz kształty lub tekst do układu slajdu, wszystkie slajdy oparte na tym układzie wyświetlą tę wspólną treść automatycznie.
> Poniższy zrzut ekranu pokazuje dwa slajdy, z których każdy dziedziczy pole tekstowe z tego samego układu slajdu.

![Slajdy dziedziczące zawartość układu](layout-slide-result.png)


## **Uzyskaj dostęp do układu slajdu**

Układy slajdów można uzyskać przez indeks lub typ układu (np. `Blank`, `Title`, `SectionHeader` itd.).

```py
def access_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Dostęp według indeksu.
        first_layout_slide = presentation.layout_slides[0]

        # Dostęp według typu układu.
        blank_layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
```

## **Usuń układ slajdu**

Możesz usunąć konkretny układ slajdu, jeśli nie jest już potrzebny.

```py
def remove_layout_slide():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Pobierz slajd układu według typu i usuń go.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.CUSTOM)
        presentation.layout_slides.remove(layout_slide)

        presentation.save("layout_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuń nieużywane układy slajdów**

Aby zmniejszyć rozmiar prezentacji, możesz chcieć usunąć układy slajdów, które nie są używane przez żadne zwykłe slajdy.

```py
def remove_unused_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Automatycznie usuwa wszystkie slajdy układu, które nie są odniesione przez żaden slajd.
        presentation.layout_slides.remove_unused()

        presentation.save("layout_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonuj układ slajdu**

Możesz zduplikować układ slajdu, używając metody `AddClone`.

```py
def clone_layout_slides():
    with slides.Presentation("layout_slide.pptx") as presentation:

        # Pobierz istniejący slajd układu według typu.
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Sklonuj slajd układu na koniec kolekcji slajdów układu.
        cloned_layout_slide = presentation.layout_slides.add_clone(layout_slide)

        presentation.save("layout_slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

> ✅ **Podsumowanie:** Układy slajdów są potężnym narzędziem do zarządzania spójnym formatowaniem w całej prezentacji. Aspose.Slides umożliwia pełną kontrolę nad tworzeniem, zarządzaniem i optymalizacją układów slajdów.