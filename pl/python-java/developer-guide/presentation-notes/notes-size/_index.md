---
title: Zmień rozmiar i orientację strony notatek w Pythonie za pomocą Java
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/python-java/notes-size/
keywords:
- rozmiar strony notatek
- orientacja notatek
- notatki poziome
- notatki pionowe
- rozmiar rozdawnika
- PowerPoint
- prezentacja
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla Pythona przy użyciu Java, przełącz orientację, zweryfikuj zapisane rozmiary i wyeksportuj notatki lub rozdawniki do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getNotesSize), aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca on obiekt [NotesSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notessize/) , którego metoda [setSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notessize/#setSize) ustawia wymiary strony. Chociaż obiekt ustawień nie może być wymieniony, możesz przypisać nowe wymiary za pomocą tej metody.

Szerokość i wysokość podawane są w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12,5 × 8⅓ cala. Ustawienia te dotyczą całej prezentacji, a nie notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getNotesSize) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksporcie wersji rozdawnika. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlideSize) | Kontroluje wymiary standardowych slajdów prezentacji za pomocą [SlideSize](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidesize/). |

Zmiana któregokolwiek z ustawień nie zmienia automatycznie drugiego. Zmiana orientacji strony notatek nie powoduje również obrotu standardowych slajdów. Zobacz [Rozmiar slajdu](/slides/pl/python-java/slide-size/), aby zmienić rozmiar standardowych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Dla przykładów eksportu użyj prezentacji zawierającej co najmniej jeden slajd z notatkami prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość i porównaj je, aby określić orientację: szersza strona to orientacja pozioma, wyższa strona to orientacja pionowa, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, bez przyjmowania standardowego rozmiaru papieru.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()
    orientation = "Square"

    if size.getWidth() > size.getHeight():
        orientation = "Landscape"
    elif size.getWidth() < size.getHeight():
        orientation = "Portrait"

    print(f"Notes page: {size.getWidth()} x {size.getHeight()} points")
    print(f"Orientation: {orientation}")
finally:
    presentation.dispose()
```

## **Przełącz na orientację poziomą bez zmiany rozmiaru papieru**

Aby zmienić tylko orientację, zamień istniejącą szerokość i wysokość. Zachowuje to długości obu boków, w tym niestandardowego rozmiaru papieru. Poniższy warunek zapobiega przekształceniu już poziomej strony z powrotem na pionową oraz pozostawia stronę kwadratową niezmienioną.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    size = presentation.getNotesSize().getSize()

    if size.getWidth() < size.getHeight():
        width = size.getWidth()
        size.setSize(size.getHeight(), width)
        presentation.getNotesSize().setSize(size)

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.getWidth() > size.getHeight()`. Nie zamieniaj wymiarów A4 ani Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustaw i zweryfikuj niestandardowy rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#save) aby zapisać prezentację. Ten przykład ustawia stronę poziomą o rozmiarze 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisany plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    expected_size = Dimension(900, 600)
    presentation.getNotesSize().setSize(expected_size)

    presentation.save("custom-notes.pptx", SaveFormat.Pptx)

    reopened = Presentation("custom-notes.pptx")
    try:
        actual_size = reopened.getNotesSize().getSize()
        width_matches = abs(actual_size.getWidth() - expected_size.getWidth()) < 0.01
        height_matches = abs(actual_size.getHeight() - expected_size.getHeight()) < 0.01
        preserved = width_matches and height_matches

        print(f"Stored notes page: {actual_size.getWidth()} x {actual_size.getHeight()} points")
        print(f"Size preserved: {preserved}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Oczekiwany wynik to `900.0 x 600.0 points` oraz `Size preserved: True`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie jedynie ustawienia w pamięci.

## **Eksport notatek i wersji rozdawnika**

Wymiary strony określają dostępny obszar dla układów notatek lub wersji rozdawnika. Same w sobie nie włączają tych układów: konieczna jest również konfiguracja opcji eksportu. Eksport standardowych slajdów nadal korzysta z wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notescommentslayoutingoptions/) do [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/pdfoptions/#setSlidesLayoutOptions), aby uwzględnić notatki w pliku PDF. Ten przykład renderuje również pierwszy slajd z notatkami do formatu PNG przy użyciu [Slide.getImage](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/#getImage) i [RenderingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/renderingoptions/).

Tryb [BottomTruncated](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą być obcięte. PDF używa stron o rozmiarze 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej, PNG ma 900 × 600 pikseli. Punkty opisują geometryczną budowę strony; piksele opisują wyjście rastrowe, którego wymiary zależą również od skali renderowania.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, NotesCommentsLayoutingOptions, NotesPositions, PdfOptions, Presentation, RenderingOptions, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = NotesCommentsLayoutingOptions()
    layout.setNotesPosition(NotesPositions.BottomTruncated)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("notes.pdf", SaveFormat.Pdf, pdf_options)

    rendering_options = RenderingOptions()
    rendering_options.setSlidesLayoutOptions(layout)

    image = presentation.getSlides().get_Item(0).getImage(rendering_options, 1.0, 1.0)
    try:
        image.save("first-slide-notes.png", ImageFormat.Png)
    finally:
        image.dispose()
finally:
    presentation.dispose()
```

Podczas eksportu PDF z długimi notatkami, [BottomFull](https://reference.aspose.com/slides/pl/python-java/aspose.slides/notespositions/) umożliwia dodanie dodatkowych stron w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu przedstawionym powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wyjście pod kątem obciętych notatek i rozmieszczenia istniejących obiektów master-notatek; zmiana samych wymiarów strony nie jest gwarancją, że cała zawartość się zmieści. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/python-java/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport wersji rozdawnika do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-java/aspose.slides/handoutlayoutingoptions/), aby umieścić miniatury wielu slajdów na jednej stronie. Poniższy przykład ustawia stronę o rozmiarze 900 × 600 punktów i używa [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/pl/python-java/aspose.slides/handouttype/), aby ułożyć do czterech slajdów na stronie. Ustawienie poziome kontroluje kolejność slajdów; orientacja strony wynika z jej szerokości i wysokości.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import HandoutLayoutingOptions, HandoutType, PdfOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("sample.pptx")
try:
    size = Dimension(900, 600)
    presentation.getNotesSize().setSize(size)

    layout = HandoutLayoutingOptions()
    layout.setHandout(HandoutType.Handouts4Horizontal)

    pdf_options = PdfOptions()
    pdf_options.setSlidesLayoutOptions(layout)

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdf_options)
finally:
    presentation.dispose()
```

Zmiana rozmiaru strony zmienia dostępny obszar dla siatki wersji rozdawnika, nie zmieniając wymiarów źródłowych slajdów. Dla obrazów wersji rozdawnika użyj [Presentation.getImages](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getImages) z układem wersji rozdawnika, zamiast metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie wersji rozdawnika na poziomie prezentacji korzysta z wymiarów strony notatek, podczas gdy wywołanie obrazu pojedynczego slajdu nie generuje strony rozdawnika. Zobacz [Handoff Mode](/slides/pl/python-java/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w podglądach, eksporcie i drukowaniu**

Zachowaj odrębne rozmiary: zapisany rozmiar prezentacji, rozmiar strony po eksporcie i rozmiar papieru po wydruku:

- **Presentation viewers:** Przeglądarka może wyświetlać lub drukować notatki według własnych reguł układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu w tej aplikacji może je znormalizować.
- **Export formats:** Przykłady PDF notatek i wersji rozdawnika powyżej używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach oraz skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport standardowych slajdów nie uwzględnia rozmiaru strony notatek.
- **Printer drivers:** Wybór papieru, automatyczny obrót i ustawienia dopasowania do strony mogą zmienić fizyczny wynik bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla konkretnego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie całej prezentacji. Poszczególne slajdy mogą mieć różną treść notatek, ale ta właściwość nie umożliwia ustawienia odrębnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i standardowe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru standardowych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj wymiary notatek. Jeśli uległy zmianie, sprawdź, czy zapis lub konwersja pliku w innej aplikacji zmieniła ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia przeglądarki i wybór papieru w drukarce.