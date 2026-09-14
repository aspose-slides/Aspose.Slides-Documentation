---
title: Zarządzanie nagłówkami i stopkami prezentacji w Pythonie poprzez Java
linktitle: Nagłówek i stopka
type: docs
weight: 140
url: /pl/python-java/presentation-header-and-footer/
keywords:
- nagłówek
- tekst nagłówka
- stopka
- tekst stopki
- ustaw nagłówek
- ustaw stopkę
- materiał rozdawniczy
- notatki
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak zarządzać polami zastępczymi stopki, daty i godziny, numeru slajdu oraz nagłówka na slajdach, stronach notatek i materiałach rozdawniczych przy użyciu Aspose.Slides dla Pythona poprzez Java."
---
## **Przegląd**

PowerPoint używa różnych pól zastępczych nagłówka i stopki w zależności od typu strony. Aspose.Slides dla Pythona poprzez Java pozwala kontrolować tekst i widoczność tych pól zastępczych za pomocą klas menedżera nagłówka/stopki.

Dostępne pola zastępcze zależą od zakresu:

| Zakres | Nagłówek | Stopka | Data/godzina | Numer slajdu/strony |
|---|---|---|---|---|
| Zwykły slajd | Nie | Tak | Tak | Tak |
| Mistrz notatek | Tak | Tak | Tak | Tak |
| Slajd notatek | Tak | Tak | Tak | Tak |
| Mistrz wersji wydruku | Tak | Tak | Tak | Tak |

Zwykły slajd prezentacji nie posiada pola zastępczego nagłówka. Nagłówki są dostępne na stronach notatek i w wersjach wydruków. Dla zwykłych slajdów należy używać pól zastępczych stopki, daty/godziny oraz numeru slajdu.

Zakres zmiany zależy od używanego menedżera. Klasa [SlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideheaderfootermanager/) kontroluje jeden zwykły slajd. Klasa [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notesslideheaderfootermanager/) kontroluje jeden slajd notatek. Menedżery mistrza i układu mogą również propagować ustawienia do zależnych slajdów, natomiast klasa [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) kontroluje mistrza wersji wydruku.

## **Ustaw stopkę, datę/godzinę i numery slajdów na zwykłych slajdach**

Dla zwykłych slajdów podstawowy przepływ pracy polega na uzyskaniu menedżera nagłówka/stopki każdego slajdu, ustawieniu tekstu stopki i daty/godziny, włączeniu wymaganych pól zastępczych oraz zapisaniu prezentacji. Numery slajdów są generowane przez prezentację, więc trzeba kontrolować jedynie ich widoczność.

Użyj [setFooterText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterText) i [setDateTimeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeText), aby ustawić tekst, oraz użyj [setFooterVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility), [setDateTimeVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility) i [setSlideNumberVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility), aby wyświetlić odpowiednie pola zastępcze.

Poniższy przykład end‑to‑end stosuje tę samą stopkę, tekst daty/godziny oraz widoczność numeru slajdu we wszystkich zwykłych slajdach:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    for slide in presentation.getSlides():
        header_footer_manager = slide.getHeaderFooterManager()

        header_footer_manager.setFooterText("Company Confidential")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jeśli musisz zaktualizować tylko jeden slajd, uzyskaj dostęp do tego slajdu bezpośrednio poprzez metodę [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) zamiast iterować po całej kolekcji.

## **Ustaw nagłówki i stopki w Mistrzu Notatek**

Mistrz notatek definiuje wspólne formatowanie i zachowanie pól zastępczych dla stron notatek. Użyj klasy [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/), gdy chcesz zmienić tylko sam mistrz notatek.

Poniższy przykład ustawia tekst nagłówka, stopki i daty/godziny w mistrzu notatek oraz sprawia, że wszystkie obsługiwane pola zastępcze są widoczne w tym mistrzu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Notes header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Notes footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metoda `getMasterNotesSlide` zwraca `None`, gdy prezentacja nie zawiera mistrza notatek.

## **Zastosuj ustawienia Mistrza Notatek do podrzędnych slajdów notatek**

Mistrz notatek może zastosować ustawienia nagłówka i stopki do siebie oraz do wszystkich zależnych slajdów notatek. Użyj dedykowanych metod propagacji w klasie [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/), gdy te same ustawienia mają być zastosowane w całej hierarchii notatek.

Na przykład, [setHeaderAndChildHeadersText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersText) i [setHeaderAndChildHeadersVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility) aktualizują nagłówek mistrza notatek oraz wszystkie nagłówki potomne. Odpowiednie metody są dostępne dla stopek, daty/godziny oraz numerów slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_notes_slide = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if master_notes_slide is not None:
        header_footer_manager = master_notes_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderAndChildHeadersText("Notes header")
        header_footer_manager.setHeaderAndChildHeadersVisibility(True)

        header_footer_manager.setFooterAndChildFootersText("Notes footer")
        header_footer_manager.setFooterAndChildFootersVisibility(True)

        header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")
        header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)

        header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Metody propagacji użyte powyżej to [setFooterAndChildFootersText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersText), [setFooterAndChildFootersVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility), [setDateTimeAndChildDateTimesText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText), [setDateTimeAndChildDateTimesVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility) oraz [setSlideNumberAndChildSlideNumbersVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility).

## **Ustaw nagłówki i stopki na pojedynczym slajdzie notatek**

Slajd notatek należy do konkretnego zwykłego slajdu. Użyj jego klasy [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notesslideheaderfootermanager/), gdy chcesz dostosować tylko tę stronę notatek.

Metoda [addNotesSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notesslidemanager/#addNotesSlide) zwraca slajd notatek dla bieżącego slajdu i tworzy go, jeśli jeszcze nie istnieje. Poniższy przykład konfiguruje stronę notatek powiązaną z pierwszym slajdem prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    notes_slide = slide.getNotesSlideManager().addNotesSlide()
    header_footer_manager = notes_slide.getHeaderFooterManager()

    header_footer_manager.setHeaderText("Header for the first notes page")
    header_footer_manager.setHeaderVisibility(True)

    header_footer_manager.setFooterText("Footer for the first notes page")
    header_footer_manager.setFooterVisibility(True)

    header_footer_manager.setDateTimeText("Date and time text")
    header_footer_manager.setDateTimeVisibility(True)

    header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Jeśli najpierw propagujesz ustawienia z mistrza notatek, a potem zmieniasz pojedynczy slajd notatek, późniejsze ustawienia per‑slajd pozwalają dostosować tę stronę notatek niezależnie.

## **Ustaw nagłówki i stopki w Mistrzu materiału rozdawniczego**

Strony wersji wydruków używają mistrza wersji wydruków dla pól zastępczych nagłówka, stopki, daty/godziny oraz numeru strony. W przeciwieństwie do stron notatek, ustawienia wersji wydruków są zarządzane przez mistrza wersji wydruków, a nie przez poszczególne slajdy wersji wydruków.

Użyj metody `getMasterHandoutSlide`, aby uzyskać dostęp do mistrza wersji wydruków. Jeśli nie jest obecny, wywołaj `setDefaultMasterHandoutSlide`, aby utworzyć domyślnego mistrza wersji wydruków.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    master_handout_slide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()

    if master_handout_slide is None:
        master_handout_slide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    if master_handout_slide is not None:
        header_footer_manager = master_handout_slide.getHeaderFooterManager()

        header_footer_manager.setHeaderText("Handout header")
        header_footer_manager.setHeaderVisibility(True)

        header_footer_manager.setFooterText("Handout footer")
        header_footer_manager.setFooterVisibility(True)

        header_footer_manager.setDateTimeText("Date and time text")
        header_footer_manager.setDateTimeVisibility(True)

        header_footer_manager.setSlideNumberVisibility(True)

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zrozum zakres i dziedziczenie**

Wybierz menedżera nagłówka/stopki, który odpowiada zakresowi, który chcesz zmienić:

- [SlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slideheaderfootermanager/) zmienia ustawienia stopy, daty/godziny i numeru slajdu dla jednego zwykłego slajdu.
- [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslideheaderfootermanager/) kontroluje slajd układu i może propagować obsługiwane ustawienia do zależnych slajdów.
- [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslideheaderfootermanager/) kontroluje mistrza zwykłych slajdów i może propagować obsługiwane ustawienia do zależnych slajdów.
- [MasterNotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masternotesslideheaderfootermanager/) kontroluje mistrza notatek i może propagować ustawienia do wszystkich zależnych slajdów notatek.
- [NotesSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notesslideheaderfootermanager/) zmienia jeden slajd notatek i obsługuje pole zastępcze nagłówka oprócz stopy, daty/godziny i numeru slajdu.
- [MasterHandoutSlideHeaderFooterManager](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterhandoutslideheaderfootermanager/) zmienia mistrza wersji wydruków i obsługuje wszystkie cztery typy pól zastępczych.

Używaj propagacji z mistrza lub układu, gdy to samo ustawienie ma obowiązywać w całej jego hierarchii. Używaj menedżera pojedynczego slajdu lub slajdu notatek, gdy potrzebne jest lokalne ustawienie dla jednej strony.

## **FAQ**

**Czy mogę dodać nagłówek do zwykłego slajdu?**

Nie. PowerPoint nie definiuje pola zastępczego nagłówka dla zwykłych slajdów. Na zwykłych slajdach użyj pól zastępczych stopki, daty/godziny i numeru slajdu. Pola zastępcze nagłówka są dostępne na stronach notatek i wersjach wydruków.

**Co zrobić, gdy pole zastępcze stopki, daty/godziny lub numeru slajdu nie jest widoczne?**

Użyj odpowiedniego menedżera nagłówka/stopki, aby sprawdzić jego widoczność i w razie potrzeby włączyć go. Na przykład, [isFooterVisible](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#isFooterVisible) informuje, czy pole zastępcze stopki jest obecne, a [setFooterVisibility](https://reference.aspose.com/slides/pl/python-java/aspose.slides/baseslideheaderfootermanager/#setFooterVisibility) zmienia jego widoczność.

**Jak rozpocząć numerację slajdów od wartości innej niż 1?**

Wywołaj metodę [setFirstSlideNumber](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#setFirstSlideNumber) prezentacji. Pola zastępcze numeru slajdu będą wtedy używać zaktualizowanej sekwencji numeracji.

**Co się dzieje z nagłówkami i stopkami podczas eksportu do PDF, obrazów lub HTML?**

Widoczne elementy nagłówka i stopki są renderowane wraz z resztą treści prezentacji w formacie wyjściowym. Ich wygląd zależy od typu eksportowanej strony oraz odpowiednich ustawień widoczności pól zastępczych.