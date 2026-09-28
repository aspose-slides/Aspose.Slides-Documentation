---
title: "Zastosuj lub zmień układy slajdów w Pythonie"
linktitle: "Układ slajdu"
type: docs
weight: 60
url: /pl/python-net/slide-layout/
keywords:
- "układ slajdu"
- "układ treści"
- "pole zastępcze"
- "projekt prezentacji"
- "projekt slajdu"
- "nieużywany układ"
- "widoczność stopki"
- "slajd tytułowy"
- "tytuł i treść"
- "nagłówek sekcji"
- "dwie treści"
- "porównanie"
- "tylko tytuł"
- "pusty układ"
- "treść z podpisem"
- "obraz z podpisem"
- "tytuł i pionowy tekst"
- "pionowy tytuł i tekst"
- "PowerPoint"
- "OpenDocument"
- "prezentacja"
- "Python"
- "Aspose.Slides"
description: "Zastosuj, twórz i modyfikuj układy slajdów w Aspose.Slides dla Pythona poprzez .NET, dodawaj pola zastępcze, usuwaj nieużywane układy i kontroluj widoczność stopki."
---
## **Przegląd**

Układ slajdu określa pozycje i formatowanie pól zastępczych, takich jak tytuły, tekst, obrazy, wykresy i tabele. Zastosowanie układu zapewnia slajdom spójną strukturę, jednocześnie umożliwiając każdemu slajdowi zawartość indywidualną.

Najczęstsze układy to:

- **Title Slide**: Zawiera pola zastępcze tytułu i podtytułu.
- **Title and Content**: Zawiera pole zastępcze tytułu oraz uniwersalne pole zastępcze zawartości.
- **Blank**: Nie zawiera pól zastępczych treści i jest przydatny, gdy każdy kształt będzie rozmieszczany ręcznie.

## **Zrozumienie dziedziczenia układów**

Prezentacja ma trzy powiązane poziomy:

1. A [master slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/) definiuje motyw, wspólne formatowanie, tła i wspólne obiekty.
2. A [layout slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/) należy do mastera i określa konkretny układ pól zastępczych.
3. A [normal slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/) używa jednego układu i przechowuje wprowadzoną treść tego slajdu.

Normalny slajd dziedziczy motyw i formatowanie z swojego układu, a układ dziedziczy z mastera. Wartość ustawiona bezpośrednio na normalnym slajdzie zastępuje wartość odziedziczoną na tym poziomie. Gdy tworzony jest normalny slajd, jego kształty pól zastępczych są generowane na podstawie wybranego układu, podczas gdy treść wprowadzona w tych polach należy do normalnego slajdu.

Dodaj wymagane pola zastępcze do układu przed tworzeniem z niego slajdów. Dodanie kolejnego pola zastępczego do układu później nie dodaje automatycznie odpowiadającego kształtu pola do istniejących normalnych slajdów.

Ta zależność ma dwa ważne konsekwencje:

- Zmiana dziedziczonego formatowania lub istniejącej geometrii pól zastępczych w układzie może zaktualizować każdy slajd, który od niego zależy. Przed edycją układu już używanego, sprawdź jego zależne slajdy i przejrzyj powstałą prezentację.
- Układ, który jest nadal używany przez którykolwiek slajd, nie może zostać usunięty. Najpierw przypisz zależne slajdy do innego układu lub usuń tylko nieużywane układy.

Aby uzyskać więcej informacji o najwyższym poziomie tej hierarchii, zobacz [Slide Master](/slides/pl/python-net/slide-master/).

Aby ukryć dziedziczone loga lub dekoracyjne kształty mastera na jednym slajdzie lub poprzez współdzielony układ, zobacz [Control the Visibility of Master Graphics](/slides/pl/python-net/slide-master/). Przykład porównuje dwa slajdy używające tego samego mastera.

## **Wybór i zastosowanie układu slajdu**

Używaj typu układu, gdy prezentacja podąża za standardowymi definicjami układów PowerPointa. Nazwy układów można edytować i mogą być lokalizowane, dlatego wybór na podstawie nazwy jest mniej niezawodny, chyba że kontrolujesz szablon źródłowy.

Poniższy przykład szuka **Title and Content** w pierwszym masterze. Jeśli ten układ jest niedostępny, celowo przechodzi do **Blank**. Drugi warunek null jest konieczny, ponieważ prezentacja może zawierać tylko układy niestandardowe. Wybrany układ jest następnie stosowany do pierwszego normalnego slajdu za pośrednictwem właściwości [Slide.layout_slide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/layout_slide/).

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

Zmiana układu slajdu nie usuwa zwykłych kształtów dodanych bezpośrednio do slajdu. Jednak pozycje pól zastępczych, dziedziczone formatowanie i zgodność istniejących pól z nowym układem mogą się zmienić, dlatego należy sprawdzić wynik przy przełączaniu między znacznie różnymi układami.

## **Dodawanie układu slajdu**

Wybór i tworzenie to oddzielne operacje. Poprzedni przykład wybiera istniejący układ; nie tworzy go. Aby utworzyć układ, wywołaj metodę [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterlayoutslidecollection/add/) na kolekcji układów docelowego mastera.

Poniższy przykład zawsze dodaje nowy układ **Title and Content** o nazwie `Report Title and Content`, a następnie dodaje normalny slajd oparty na tym układzie. Nazwy układów muszą być unikalne w kolekcji.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Dodawaj układ tylko wtedy, gdy szablon naprawdę potrzebuje kolejnej struktury wielokrotnego użytku. Jeśli odpowiedni układ już istnieje, wybierz i użyj go ponownie zamiast tworzyć duplikat.

## **Dodawanie pól zastępczych do układu slajdu**

Właściwość [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/placeholder_manager/) udostępnia [LayoutPlaceholderManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/) do dodawania kształtów pól zastępczych do układu.

| Placeholder programu PowerPoint | Metoda `LayoutPlaceholderManager` |
| ----------------------------------- | --------------------------------- |
| ![Zawartość](content.png)             | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Zawartość (pionowa)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Tekst](text.png)                   | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Tekst (pionowy)](textV.png)       | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Obraz](picture.png)             | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Wykres](chart.png)                 | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tabela](table.png)                 | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png)           | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Multimedia](media.png)                 | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Obraz online](onlineImage.png)    | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

Poniższy przykład weryfikuje, czy układ **Blank** istnieje, dodaje do niego cztery pola zastępcze, a następnie tworzy normalny slajd wykorzystujący zmodyfikowany układ. Kolejność jest zamierzona: pola są dodawane przed utworzeniem slajdu, co pozwala Aspose.Slides wygenerować odpowiadające im kształty na tym slajdzie.

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

![Pola zastępcze na slajdzie układu](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Zmiana dziedziczonego formatowania lub geometrii istniejących pól zastępczych w układzie może wpłynąć na slajdy zależne. Nowo dodane pole zastępcze nie jest automatycznie wstawiane do istniejących normalnych slajdów. Testuj zmiany układów na kopii prezentacji i sprawdź każdy slajd zależny.
{{% /alert %}}

## **Usuwanie nieużywanych układów slajdów**

Użyj metody [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) aby usunąć układy, do których nie odwołuje żaden normalny slajd. Metoda pozostawia nienaruszone układy nadal używane.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Aby usunąć konkretny układ, najpierw użyj jego właściwości [has_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/has_depending_slides/) lub metody [get_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/get_depending_slides/). Przypisz zależne slajdy przed wywołaniem [LayoutSlide.remove](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/remove/). Próba usunięcia używanego układu generuje [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/).

## **Kontrola widoczności stopki na układzie slajdu**

Układ ma własne pola zastępcze stopki, numeru slajdu i daty/godziny. Użyj właściwości [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/header_footer_manager/) aby kontrolować te pola dla jednego układu. Jest to przydatne, gdy na przykład układy zawartości mają wyświetlać stopki, a układy tytułowe nie powinny.

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

## **Kontrola widoczności stopki w masterze i jego układach podrzędnych**

Aby zastosować spójne ustawienia stopki w całej hierarchii mastera, użyj właściwości [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslide/header_footer_manager/). Metody propagacji [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslideheaderfootermanager/) działają na masterze oraz jego zależnych układach i normalnych slajdach; nie dotyczą jednego pojedynczego normalnego slajdu.

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

**Jaka jest różnica między master slajdem a układem slajdu?**

Master slajd definiuje motyw prezentacji i wspólne formatowanie. Układ slajdu należy do mastera i definiuje jedną wielokrotnego użytku konfigurację pól zastępczych. Normalne slajdy używają tych układów i przechowują treść specyficzną dla slajdu.

**Czy mogę skopiować układ slajdu z jednej prezentacji do drugiej?**

Tak. Dodaj kopię do docelowej kolekcji metodą [add_clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Przy kopiowaniu między prezentacjami sprawdź także czcionki, motywy, obrazy i inne zasoby używane przez źródłowy układ.

**Co się stanie, gdy zmodyfikuję układ, który jest już używany?**

Slajdy zależne dziedziczą zmiany układu, chyba że nadpisują zmienione formatowanie lub obiekty lokalnie. Geometria pól zastępczych i dziedziczone style mogą więc zmienić się jednocześnie na wielu slajdach. Użyj [get_depending_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/get_depending_slides/) aby zidentyfikować dotknięte slajdy przed edycją układu.

**Co się stanie, jeśli usunę układ, który jest nadal używany?**

Aspose.Slides generuje [PptxEditException](https://reference.aspose.com/slides/pl/python-net/aspose.slides/pptxeditexception/). Najpierw przypisz zależne slajdy do innego układu lub użyj [remove_unused_layout_slides](https://reference.aspose.com/slides/pl/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) aby usunąć wyłącznie nieodwoływane układy.