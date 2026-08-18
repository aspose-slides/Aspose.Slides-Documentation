---
title: Zarządzanie nagłówkami i stopkami prezentacji w Pythonie
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/python-net/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiał
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak zarządzać polami zastępczymi stopki, daty‑czasu, numeru slajdu i nagłówka na slajdach, stronach notatek i materiałach przy użyciu Aspose.Slides dla Pythona via .NET."
---
## **Przegląd**

PowerPoint używa różnych pól zastępczych nagłówka i stopki w zależności od typu strony. Aspose.Slides for Python via .NET umożliwia kontrolowanie tekstu i widoczności tych pól zastępczych za pomocą klas menedżerów nagłówka/stopki.

Dostępne pola zastępcze zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz materiałów | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie ma pola zastępczego nagłówka. Nagłówki są dostępne na stronach notatek i materiałach. Dla zwykłych slajdów użyj pól zastępczych stopki, daty/godziny oraz numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Klasa [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slideheaderfootermanager/) kontroluje jeden zwykły slajd. Klasa [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslideheaderfootermanager/) kontroluje jeden slajd notatek. Menedżerowie master i układu mogą również propagować ustawienia do zależnych slajdów, natomiast klasa [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) kontroluje mistrza materiałów.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych pól zastępczych oraz zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc trzeba kontrolować jedynie ich widoczność.

Użyj [`set_footer_text`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_text/) i [`set_date_time_text`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_text/), aby ustawić tekst, oraz użyj [`set_footer_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/), [`set_date_time_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/set_date_time_visibility/), i [`set_slide_number_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/set_slide_number_visibility/), aby wyświetlić odpowiednie pola zastępcze.

Poniższy przykład end-to-end stosuje tę samą stopkę, tekst daty/godziny i widoczność numeru slajdu we wszystkich zwykłych slajdach:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    for slide in presentation.slides:
        header_footer_manager = slide.header_footer_manager

        header_footer_manager.set_footer_text("Company Confidential")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_slide_footers.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli potrzebujesz zaktualizować tylko jeden slajd, uzyskaj dostęp do tego slajdu bezpośrednio poprzez kolekcję [`slides`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slides/pl/), zamiast iterować po całej kolekcji.

## **Ustaw nagłówki i stopki w Mistrzu Notatek**

Mistrz notatek definiuje wspólne formatowanie i zachowanie pól zastępczych dla stron notatek. Użyj klasy [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/), gdy chcesz zmienić wyłącznie sam mistrz notatek.

Poniższy przykład ustawia tekst nagłówka, stopki i daty/godziny w mistrzu notatek oraz sprawia, że wszystkie obsługiwane pola zastępcze są widoczne w tym mistrzu:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_text("Notes header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Notes footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", slides.export.SaveFormat.PPTX)
```

Prezentacja może nie zawierać mistrza notatek, więc przed zmianą należy sprawdzić, czy zwrócona wartość nie jest `None`.

## **Zastosuj ustawienia Mistrza Notatek do podrzędnych slajdów notatek**

Mistrz notatek może zastosować ustawienia nagłówka i stopki do siebie oraz do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji w klasie [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/), gdy te same ustawienia mają być stosowane w całej hierarchii notatek.

Na przykład, [`set_header_and_child_headers_text`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_text/) i [`set_header_and_child_headers_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_header_and_child_headers_visibility/) aktualizują nagłówek mistrza notatek i wszystkie nagłówki podrzędne. Odpowiednie metody są dostępne dla stopek, daty/godziny oraz numerów slajdów.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_notes_slide = presentation.master_notes_slide_manager.master_notes_slide

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.header_footer_manager

        header_footer_manager.set_header_and_child_headers_text("Notes header")
        header_footer_manager.set_header_and_child_headers_visibility(True)

        header_footer_manager.set_footer_and_child_footers_text("Notes footer")
        header_footer_manager.set_footer_and_child_footers_visibility(True)

        header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")
        header_footer_manager.set_date_time_and_child_date_times_visibility(True)

        header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Metody propagacji użyte powyżej to [`set_footer_and_child_footers_text`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_text/), [`set_footer_and_child_footers_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_footer_and_child_footers_visibility/), [`set_date_time_and_child_date_times_text`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_text/), [`set_date_time_and_child_date_times_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_date_time_and_child_date_times_visibility/), i [`set_slide_number_and_child_slide_numbers_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/set_slide_number_and_child_slide_numbers_visibility/).

## **Ustaw nagłówki i stopki na pojedynczym slajdzie notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego klasy [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslideheaderfootermanager/), gdy chcesz dostosować jedynie tę stronę notatek.

Metoda [`add_notes_slide`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslidemanager/add_notes_slide/) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    notes_slide = presentation.slides[0].notes_slide_manager.add_notes_slide()
    header_footer_manager = notes_slide.header_footer_manager

    header_footer_manager.set_header_text("Header for the first notes page")
    header_footer_manager.set_header_visibility(True)

    header_footer_manager.set_footer_text("Footer for the first notes page")
    header_footer_manager.set_footer_visibility(True)

    header_footer_manager.set_date_time_text("Date and time text")
    header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", slides.export.SaveFormat.PPTX)
```

Jeśli najpierw propagujesz ustawienia z mistrza notatek, a następnie zmieniasz pojedynczy slajd notatek, późniejsze ustawienia per‑slajd pozwalają niezależnie dostosować tę stronę notatek.

## **Ustaw nagłówki i stopki w Mistrzu Materiałów**

Strony materiałów używają mistrza materiałów dla swoich pól zastępczych nagłówka, stopki, daty/godziny i numeru strony. W przeciwieństwie do stron notatek, ustawienia materiałów są zarządzane poprzez mistrza materiałów, a nie poszczególne slajdy materiałów.

Użyj właściwości [`master_handout_slide`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterhandoutslidemanager/master_handout_slide/), aby uzyskać dostęp do mistrza materiałów. Jeśli nie istnieje, wywołaj [`set_default_master_handout_slide`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/), aby utworzyć domyślny mistrz materiałów.

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is None:
        presentation.master_handout_slide_manager.set_default_master_handout_slide()
        master_handout_slide = presentation.master_handout_slide_manager.master_handout_slide

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.header_footer_manager

        header_footer_manager.set_header_text("Handout header")
        header_footer_manager.set_header_visibility(True)

        header_footer_manager.set_footer_text("Handout footer")
        header_footer_manager.set_footer_visibility(True)

        header_footer_manager.set_date_time_text("Date and time text")
        header_footer_manager.set_date_time_visibility(True)

        header_footer_manager.set_slide_number_visibility(True)

    presentation.save("presentation_with_handout_footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki, który odpowiada zakresowi, który chcesz zmienić:

- [`SlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slideheaderfootermanager/) zmienia ustawienia stopki, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [`LayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslideheaderfootermanager/) kontroluje slajd układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`MasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslideheaderfootermanager/) kontroluje zwykły master slajdów i może propagować obsługiwane ustawienia do zależnych slajdów.
- [`MasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masternotesslideheaderfootermanager/) kontroluje mistrza notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [`NotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notesslideheaderfootermanager/) zmienia jeden slajd notatek i obsługuje pole zastępcze nagłówka oprócz stopki, daty/godziny i numeru slajdu.
- [`MasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterhandoutslideheaderfootermanager/) zmienia mistrza materiałów i obsługuje wszystkie cztery typy pól zastępczych.

Używaj propagacji z mastera lub układu, gdy to samo ustawienie ma obowiązywać w całej jego hierarchii. Używaj menedżera pojedynczego slajdu lub slajdu notatek, gdy potrzebujesz lokalnego ustawienia dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje pola zastępczego nagłówka dla zwykłych slajdów. Na zwykłych slajdach użyj pól zastępczych stopki, daty/godziny i numeru slajdu. Pola zastępcze nagłówka są dostępne na stronach notatek i materiałach.

**Co zrobić, jeśli pole zastępcze stopki, daty/godziny lub numeru slajdu nie jest widoczne?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jej widoczność i w razie potrzeby ją włączyć. Na przykład, [`is_footer_visible`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/is_footer_visible/) informuje, czy pole zastępcze stopki jest obecne, a [`set_footer_visibility`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/baseslideheaderfootermanager/set_footer_visibility/) zmienia jej widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Ustaw właściwość [`first_slide_number`](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/first_slide_number/) prezentacji. Następnie pola zastępcze numeru slajdu będą używać zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane wraz z resztą treści prezentacji w formacie wyjściowym. Ich wygląd zależy od typu eksportowanej strony oraz odpowiednich ustawień widoczności pól zastępczych.