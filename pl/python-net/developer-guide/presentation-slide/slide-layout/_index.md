---
title: Zastosuj lub zmień układy slajdów w Pythonie
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/python-net/slide-layout/
keywords:
- układ slajdu
- układ treści
- pole zastępcze
- projektowanie prezentacji
- projektowanie slajdu
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwa elementy treści
- porównanie
- tylko tytuł
- układ pusty
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać i dostosowywać układy slajdów w Aspose.Slides dla Pythona przy użyciu .NET. Poznaj typy układów, kontrolę pól zastępczych, widoczność stopki oraz manipulację układami za pomocą przykładów kodu w Pythonie."
---
## **Wprowadzenie**

Układ slajdu określa rozmieszczenie pól zastępczych i formatowanie treści na slajdzie. Kontroluje, które pola zastępcze są dostępne i gdzie się pojawiają. Układy slajdów pomagają szybko i konsekwentnie projektować prezentacje — niezależnie od tego, czy tworzysz coś prostego, czy bardziej złożonego. Niektóre z najczęściej używanych układów slajdów w programie PowerPoint to:

**Układ tytułowy** – Zawiera dwa pola tekstowe: jedno dla tytułu i jedno dla podtytułu.

**Układ tytuł i treść** – Zawiera mniejsze pole tytułowe na górze oraz większe poniżej przeznaczone na główną treść (taką jak tekst, wypunktowania, wykresy, obrazy i inne).

**Układ pusty** – Nie zawiera żadnych pól zastępczych, dając pełną kontrolę nad projektowaniem slajdu od podstaw.

Układy slajdów są częścią mistrza slajdów, który jest slajdem najwyższego poziomu definiującym style układów w prezentacji. Możesz uzyskać dostęp i modyfikować układy slajdów za pośrednictwem mistrza slajdów — zarówno według ich typu, nazwy, jak i unikalnego identyfikatora. Alternatywnie możesz edytować konkretny układ slajdu bezpośrednio w prezentacji.

Aby pracować z układami slajdów w Aspose.Slides for Python, możesz używać:
- Właściwości takie jak [layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/layout_slides/) i [masters](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/masters/) w klasie [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/)
- Typy takie jak [LayoutSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/), i [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Aby dowiedzieć się więcej o pracy z mistrzami slajdów, zapoznaj się z artykułem [Zarządzanie mistrzami slajdów PowerPoint w Pythonie](/slides/pl/python-net/slide-master/).
{{% /alert %}}

## **Dodawanie układów slajdów do prezentacji**

Aby dostosować wygląd i strukturę swoich slajdów, może być konieczne dodanie nowych układów slajdów do prezentacji. Aspose.Slides for Python umożliwia sprawdzenie, czy dany układ już istnieje, dodanie nowego w razie potrzeby oraz użycie go do wstawiania slajdów opartych na tym układzie.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj dostęp do [MasterLayoutSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterlayoutslidecollection/).
1. Sprawdź, czy żądany układ slajdu już istnieje w kolekcji. Jeśli nie, dodaj potrzebny układ slajdu.
1. Dodaj pusty slajd oparty na nowym układzie slajdu.
1. Zapisz prezentację.

Poniższy kod w języku Python demonstruje, jak dodać układ slajdu do prezentacji PowerPoint:

```python
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby otworzyć plik prezentacji.
with slides.Presentation("sample.pptx") as presentation:
    # Przejdź przez typy układów slajdów, aby wybrać układ slajdu.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Sytuacja, w której prezentacja nie zawiera wszystkich typów układów.
        # Plik prezentacji zawiera tylko układy Blank i Custom.
        # Jednak układy slajdów o typach niestandardowych mogą mieć rozpoznawalne nazwy,
        # takie jak "Title", "Title and Content" itd., które mogą być użyte do wyboru układu slajdu.
        # Możesz również polegać na zestawie typów kształtów pól zastępczych.
        # Na przykład slajd tytułowy powinien mieć tylko typ pola zastępczego Title i tak dalej.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Dodaj pusty slajd przy użyciu dodanego układu slajdu.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Zapisz prezentację na dysku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuwanie nieużywanych układów slajdów**

Aspose.Slides udostępnia metodę [remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) klasy [Compress](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/), umożliwiającą usunięcie niechcianych i nieużywanych układów slajdów.

Poniższy kod w języku Python pokazuje, jak usunąć układ slajdu z prezentacji PowerPoint:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dodawanie pól zastępczych do układów slajdów**

Aspose.Slides udostępnia właściwość [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/placeholder_manager/), która pozwala dodawać nowe pola zastępcze do układu slajdu.

Ten menedżer zawiera metody dla następujących typów pól zastępczych:

| Pole zastępcze PowerPoint          | Metoda [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Treść](content.png)              | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Treść (pionowa)](contentV.png)   | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Tekst](text.png)                 | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Tekst (pionowy)](textV.png)      | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Obraz](picture.png)              | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Wykres](chart.png)               | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Tabela](table.png)               | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)          | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)                | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Obraz online](onlineimage.png)   | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Poniższy kod w języku Python demonstruje, jak dodać nowe kształty pól zastępczych do układu pustego:

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Pobierz układ slajdu Blank.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Pobierz menedżera pól zastępczych układu slajdu.
    placeholder_manager = layout.placeholder_manager

    # Dodaj różne pola zastępcze do układu slajdu Blank.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Dodaj nowy slajd z układem Blank.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Pola zastępcze na układzie slajdu](add_placeholders.png)

## **Ustawianie widoczności stopki dla układu slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być wyświetlane lub ukrywane w zależności od układu slajdu. Aspose.Slides for Python pozwala kontrolować widoczność tych pól zastępczych stopki. Jest to przydatne, gdy chcesz, aby niektóre układy wyświetlały informacje stopki, a inne pozostawały czyste i minimalistyczne.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do układu slajdu według jego indeksu.
1. Ustaw widoczność pola zastępczego stopki slajdu.
1. Ustaw widoczność pola zastępczego numeru slajdu.
1. Ustaw widoczność pola zastępczego daty i godziny.
1. Zapisz prezentację.

Poniższy kod w języku Python pokazuje, jak ustawić widoczność stopki slajdu i wykonać powiązane zadania:

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```

## **Ustawianie widoczności stopki potomnej dla slajdu**

W prezentacjach PowerPoint elementy stopki, takie jak data, numer slajdu i własny tekst, mogą być kontrolowane na poziomie mistrza slajdu, aby zapewnić spójność we wszystkich układach slajdów. Aspose.Slides for Python umożliwia ustawienie widoczności i treści tych pól zastępczych stopki na mistrzu slajdu oraz propagowanie tych ustawień do wszystkich potomnych układów slajdów. Dzięki temu uzyskujesz jednolite informacje stopki w całej prezentacji.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz odniesienie do mistrza slajdu według jego indeksu.
1. Ustaw widoczność wszystkich pól zastępczych stopki mistrza i jego potomków.
1. Ustaw widoczność wszystkich pól zastępczych numeru slajdu mistrza i jego potomków.
1. Ustaw widoczność wszystkich pól zastępczych daty i godziny mistrza i jego potomków.
1. Zapisz prezentację.

Poniższy kod w języku Python demonstruje tę operację:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaka jest różnica między mistrzem slajdu a układem slajdu?**

Mistrz slajdu definiuje ogólny motyw i domyślne formatowanie, natomiast układy slajdów określają konkretne rozmieszczenie pól zastępczych dla różnych typów treści.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak, możesz sklonować układ slajdu z kolekcji [layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/layout_slides/) jednej prezentacji i wstawić go do innej, używając metody `add_clone`.

**Co się stanie, jeśli usunę układ slajdu, który jest nadal używany przez slajd?**

Jeśli spróbujesz usunąć układ slajdu, który jest nadal odwoływany przynajmniej przez jeden slajd w prezentacji, Aspose.Slides zgłosi wyjątek [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/). Aby tego uniknąć, użyj [remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/), który bezpiecznie usuwa tylko nieużywane układy slajdów.