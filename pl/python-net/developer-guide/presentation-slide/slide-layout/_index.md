---
title: Zastosuj lub zmień układy slajdów w Pythonie
linktitle: Układ slajdu
type: docs
weight: 60
url: /pl/python-net/slide-layout/
keywords:
- układ slajdu
- układ treści
- element zastępczy
- projektowanie prezentacji
- projektowanie slajdów
- nieużywany układ
- widoczność stopki
- slajd tytułowy
- tytuł i treść
- nagłówek sekcji
- dwie treści
- porównanie
- tylko tytuł
- pusty układ
- treść z podpisem
- obraz z podpisem
- tytuł i pionowy tekst
- pionowy tytuł i tekst
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla Pythona za pomocą .NET, dodawaj elementy zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie elementów zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie pozwalając każdemu slajdowi zawierać własną treść.

Najbardziej typowe układy to:

- **Title Slide**: Zawiera elementy zastępcze tytułu i podtytułu.
- **Title and Content**: Zawiera element zastępczy tytułu oraz ogólnego przeznaczenia element zastępczy treści.
- **Blank**: Nie zawiera elementów zastępczych treści i jest przydatny, gdy każdy kształt zostanie rozmieszczony ręcznie.

## **Zrozum dziedziczenie układów**

Prezentacja ma trzy powiązane poziomy:

1. A [slajd główny](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/) definiuje motyw, współdzielone formatowanie, tła i wspólne obiekty.
2. A [układ slajdu](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/) należy do slajdu głównego i określa konkretny układ elementów zastępczych.
3. A [zwykły slajd](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną treść dla tego slajdu.

Zwykły slajd dziedziczy motyw i formatowanie z jego układu, a układ dziedziczy z slajdu głównego. Wartość ustawiona bezpośrednio na zwykłym slajdzie zastępuje dziedziczoną wartość na tym poziomie. Podczas tworzenia zwykłego slajdu, jego kształty elementów zastępczych są generowane na podstawie wybranego układu, podczas gdy wprowadzona treść w tych elementach należy do zwykłego slajdu.

Dodaj wymagane elementy zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego elementu zastępczego do układu później nie spowoduje automatycznego dodania odpowiadającego kształtu elementu do istniejących zwykłych slajdów.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu, który jest już używany, sprawdź jego zależne slajdy i przejrzyj powstałą prezentację.
- Układ, który jest nadal używany przez slajd, nie może zostać usunięty. Przypisz najpierw zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Po więcej informacji o najwyższym poziomie tej hierarchii zobacz [Slajd główny](/slides/pl/python-net/slide-master/).

## **Wybierz i zastosuj układ slajdu**

Używaj typu układu, gdy prezentacja podąża za standardowymi definicjami układów PowerPoint. Nazwy układów można edytować i są lokalizowalne, więc wybór oparty na nazwie jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład wyszukuje **Title and Content** w pierwszym slajdzie głównym. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi test na null jest potrzebny, ponieważ prezentacja może zawierać wyłącznie niestandardowe układy. Wybrany układ jest następnie zastosowany do pierwszego zwykłego slajdu za pośrednictwem właściwości [Slide.layout_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje elementów zastępczych, dziedziczone formatowanie oraz powiązania między istniejącymi elementami a nowym układem mogą ulec zmianie, dlatego należy sprawdzić wynik przy przełączaniu między znacznie różnymi układami.

## **Dodaj układ slajdu**

Wybór i tworzenie to oddzielne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy nowego. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterlayoutslidecollection/add/) na kolekcji układów docelowego slajdu głównego.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje zwykły slajd oparty na tym układzie. Nazwy układów muszą być unikalne w kolekcji.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Dodawaj układ tylko wtedy, gdy szablon rzeczywiście potrzebuje kolejnej wielokrotnego użytku struktury. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodaj elementy zastępcze do układu slajdu**

Właściwość [LayoutSlide.placeholder_manager] zapewnia [LayoutPlaceholderManager] do dodawania kształtów elementów zastępczych do układu.

| Element zastępczy PowerPoint       | Metoda LayoutPlaceholderManager |
| ---------------------------------- | -------------------------------- |
| ![Treść](content.png)              | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Treść (pionowa)](contentV.png)   | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Tekst](text.png)                 | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Tekst (pionowa)](textV.png)      | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Obraz](picture.png)              | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Wykres](chart.png)               | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabela](table.png)               | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)          | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Media](media.png)                | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Obraz online](onlineImage.png)   | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Poniższy przykład weryfikuje, czy układ **Blank** istnieje, dodaje do niego cztery elementy zastępcze, a następnie tworzy zwykły slajd używający zmodyfikowanego układu. Kolejność jest zamierzona: elementy są dodawane przed utworzeniem zwykłego slajdu, dzięki czemu Aspose.Slides może wygenerować odpowiadające kształty elementów na tym slajdzie.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Wynik:

![Elementy zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Ostrzeżenie" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących elementów zastępczych układu może wpływać na zależne slajdy. Nowo dodany element nie jest automatycznie wstawiany do istniejących zwykłych slajdów. Testuj zmiany układu na kopii prezentacji i sprawdzaj każdy zależny slajd.
{{% /alert %}}

## **Usuń nieużywane układy slajdów**

Użyj metody [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) aby usunąć układy, do których nie odwołuje żaden zwykły slajd. Metoda pozostawia nienaruszone układy wciąż używane.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Aby usunąć konkretny układ, najpierw skorzystaj z jego właściwości [has_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/has_depending_slides/) lub metody [get_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/get_depending_slides/). Przypisz zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/remove/). Próba usunięcia używanego układu wywołuje [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/).

## **Sterowanie widocznością stopki w układzie slajdu**

Układ ma własne elementy zastępcze stopki, numeru slajdu i daty/godziny. Użyj właściwości [LayoutSlide.header_footer_manager] aby kontrolować te elementy dla jednego układu. Jest to przydatne, gdy na przykład układy treści powinny wyświetlać stopki, a układy tytułów nie powinny.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Sterowanie widocznością stopki w slajdzie głównym i jego układach potomnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii slajdu głównego, użyj właściwości [MasterSlide.header_footer_manager]. Metody propagacji [MasterSlideHeaderFooterManager] działają na slajdzie głównym oraz jego zależnych układach i zwykłych slajdach; nie dotyczą pojedynczego zwykłego slajdu.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Jaka jest różnica między slajdem głównym a układem slajdu?**

Slajd główny definiuje motyw prezentacji i współdzielone formatowanie. Układ slajdu należy do slajdu głównego i określa jedną wielokrotnego użytku kombinację elementów zastępczych. Zwykłe slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji za pomocą metody [add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Przy kopiowaniu między prezentacjami zweryfikuj także czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Zależne slajdy dziedziczą zmiany układu, chyba że nadpisują dotknięte formatowanie lub obiekty lokalnie. Geometria elementów zastępczych i dziedziczony styl mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [get_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/get_depending_slides/) aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides podnosi [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) aby usunąć tylko nieodwołane układy.