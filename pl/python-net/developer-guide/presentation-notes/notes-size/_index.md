---
title: Zmiana rozmiaru i orientacji strony notatek w Pythonie
linktitle: Rozmiar strony notatek
type: docs
weight: 10
url: /pl/python-net/notes-size/
keywords:
- rozmiar strony notatek
- orientacja notatek
- notatki poziome
- notatki pionowe
- rozmiar handoutu
- PowerPoint
- prezentacja
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Odczytaj i zmień wymiary strony notatek w Aspose.Slides dla Pythona via .NET, zmień orientację, zweryfikuj zapisane rozmiary oraz eksportuj notatki lub handouty do PDF i obrazów."
---
## **Przegląd**

Użyj [Presentation.notes_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/notes_size/) aby uzyskać dostęp do ustawień strony notatek prezentacji. Zwraca on obiekt [NotesSize](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notessize/), którego właściwość [size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/notessize/size/) jest zapisywalna. Chociaż sam obiekt ustawień jest tylko do odczytu, możesz przypisać nowe wymiary do jego właściwości size.

Szerokość i wysokość podawane są w **punktach**, przy 72 punktach na cal. Na przykład 900 × 600 punktów to 12,5 × 8⅓ cala. Ustawienia te odnoszą się do całej prezentacji, a nie do notatek pojedynczego slajdu.

| Ustawienie | Cel |
| --- | --- |
| [Presentation.notes_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/notes_size/) | Kontroluje wymiary strony notatek oraz wymiary strony używane przy eksportowaniu handoutów. |
| [Presentation.slide_size](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/slide_size/) | Kontroluje standardowe wymiary slajdów prezentacji za pomocą [SlideSize](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidesize/). |

Zmiana jednego z ustawień nie powoduje automatycznej zmiany drugiego. Zmiana orientacji strony notatek nie obraca również standardowych slajdów. Zobacz [Slide Size](/slides/pl/python-net/slide-size/), aby zmienić rozmiar standardowych slajdów.

Poniższe przykłady używają istniejącego pliku `sample.pptx`. Dla przykładów eksportu użyj prezentacji zawierającej co najmniej jeden slajd z notatkami prelegenta. Każdy przykład może być uruchomiony niezależnie.

## **Odczyt rozmiaru i orientacji strony notatek**

Odczytaj szerokość i wysokość oraz porównaj je, aby określić orientację: szersza strona to tryb poziomy, wyższa strona to tryb pionowy, a równe wymiary opisują stronę kwadratową. Ten przykład wypisuje rzeczywiste wymiary w punktach, bez zakładania standardowego rozmiaru papieru.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size
    orientation = "Square"

    if size.width > size.height:
        orientation = "Landscape"
    elif size.width < size.height:
        orientation = "Portrait"

    print(f"Notes page: {size.width:g} x {size.height:g} points")
    print(f"Orientation: {orientation}")
```

## **Przełącz na tryb poziomy bez zmiany rozmiaru papieru**

Aby zmienić tylko orientację, zamień istniejącą szerokość i wysokość. Dzięki temu zachowane zostaną długości obu boków, włącznie z tymi w niestandardowym rozmiarze papieru. Poniższy warunek zapobiega przekształceniu już poziomej strony z powrotem na pionową i pozostawia stronę kwadratową niezmienioną.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    size = presentation.notes_size.size

    if size.width < size.height:
        presentation.notes_size.size = drawing.SizeF(size.height, size.width)

    presentation.save("landscape-notes.pptx", slides.export.SaveFormat.PPTX)
```

Dla orientacji pionowej użyj tego samego przypisania, gdy `size.width > size.height`. Nie zamieniaj wymiarów A4 ani Letter, chyba że chcesz również zmienić rozmiar papieru.

## **Ustaw i zweryfikuj niestandardowy rozmiar strony notatek**

Przypisz oba wymiary jednocześnie, a następnie użyj [Presentation.save](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/save/), aby zapisać prezentację. Ten przykład ustawia stronę poziomą o wymiarach 900 × 600 punktów, zapisuje ją jako PPTX i ponownie otwiera zapisaną plik, aby sprawdzić zachowane wartości. Porównanie dopuszcza tolerancję 0,01 punktu dla wartości zmiennoprzecinkowych; nie jest to gwarancja precyzji dla każdego formatu pliku.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

expected_size = drawing.SizeF(900, 600)

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = expected_size
    presentation.save("custom-notes.pptx", slides.export.SaveFormat.PPTX)

with slides.Presentation("custom-notes.pptx") as reopened:
    actual_size = reopened.notes_size.size
    width_matches = abs(actual_size.width - expected_size.width) < 0.01
    height_matches = abs(actual_size.height - expected_size.height) < 0.01
    preserved = width_matches and height_matches

    print(f"Stored notes page: {actual_size.width:g} x {actual_size.height:g} points")
    print(f"Size preserved: {preserved}")
```

Oczekiwany wynik to `900 x 600 points` oraz `Size preserved: True`. Sprawdzenie nowo otwartej prezentacji weryfikuje zapisany plik, a nie jedynie ustawienia w pamięci.

## **Eksport notatek i handoutów**

Wymiary strony określają dostępny obszar dla układów notatek lub handoutów. Same w sobie nie włączają tych układów: należy także skonfigurować opcje eksportu. Eksport standardowych slajdów nadal używa wymiarów slajdu.

### **Eksport notatek do PDF i PNG**

Przypisz [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notescommentslayoutingoptions/) do [PdfOptions.slides_layout_options](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/pdfoptions/slides_layout_options/), aby uwzględnić notatki w pliku PDF. Ten przykład renderuje również pierwszy slajd z notatkami do PNG przy użyciu [Slide.get_image](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slide/get_image/) oraz [RenderingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/renderingoptions/).

Tryb [BOTTOM_TRUNCATED](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notespositions/) utrzymuje notatki na jednej stronie; notatki, które nie mieszczą się, mogą zostać obcięte. PDF używa stron o wymiarach 900 × 600 punktów. Przy skali obrazu 1 × 1 użytej poniżej PNG ma 900 × 600 pikseli. Punkty opisują geometrię strony; piksele opisują wyjście rastrowe, którego wymiary zależą również od skali renderowania.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.NotesCommentsLayoutingOptions()
    layout.notes_position = slides.export.NotesPositions.BOTTOM_TRUNCATED

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("notes.pdf", slides.export.SaveFormat.PDF, pdf_options)

    rendering_options = slides.export.RenderingOptions()
    rendering_options.slides_layout_options = layout

    with presentation.slides[0].get_image(rendering_options, 1, 1) as image:
        image.save("first-slide-notes.png", slides.ImageFormat.PNG)
```

Dla eksportu PDF z długimi notatkami, [BOTTOM_FULL](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/notespositions/) pozwala na dodatkowe strony w razie potrzeby. Nie używaj tego trybu z wywołaniem obrazu pojedynczego slajdu powyżej, które go nie obsługuje. Po zmianie rozmiaru sprawdź wyjście pod kątem przyciętych notatek i rozmieszczenia istniejących obiektów notes‑master; zmiana samych wymiarów strony nie powinna być traktowana jako gwarancja, że cała zawartość zmieści się. Zobacz [Convert PowerPoint to PDF with Notes](/slides/pl/python-net/convert-powerpoint-to-pdf-with-notes/) po więcej informacji o eksporcie notatek.

### **Eksport handoutów do PDF**

Użyj [HandoutLayoutingOptions](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handoutlayoutingoptions/) do wyświetlenia wielu miniatur slajdów na jednej stronie. Poniższy przykład ustawia stronę o wymiarach 900 × 600 punktów i używa [HandoutType.HANDOUTS_4_HORIZONTAL](https://reference.aspose.com/slides/pl/python-net/aspose.slides.export/handouttype/), aby ułożyć do czterech slajdów na stronę. Ustawienie poziome kontroluje kolejność slajdów; orientacja strony wynika z jej szerokości i wysokości.

```python
import aspose.pydrawing as drawing
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    presentation.notes_size.size = drawing.SizeF(900, 600)

    layout = slides.export.HandoutLayoutingOptions()
    layout.handout = slides.export.HandoutType.HANDOUTS_4_HORIZONTAL

    pdf_options = slides.export.PdfOptions()
    pdf_options.slides_layout_options = layout

    presentation.save("handouts.pdf", slides.export.SaveFormat.PDF, pdf_options)
```

Zmiana rozmiaru strony zmienia dostępny obszar siatki handoutów bez zmiany wymiarów slajdów źródłowych. Dla obrazów handoutów użyj [Presentation.get_images](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/get_images/) z układem handout, zamiast metody obrazu pojedynczego slajdu. W Aspose.Slides renderowanie handoutów na poziomie prezentacji korzysta z wymiarów strony notatek, podczas gdy wywołanie obrazu pojedynczego slajdu nie tworzy strony handoutu. Zobacz [Handout Mode](/slides/pl/python-net/convert-powerpoint-in-handout-mode/) po opcje układu.

## **Rozmiar strony w przeglądarkach, eksporcie i drukowaniu**

Utrzymuj odrębne rozmiary zapisanej prezentacji, wyeksportowanej strony i drukowanego papieru:

- **Presentation viewers:** Przeglądarka może wyświetlać lub drukować notatki stosując własne zasady układu. Jeśli inna aplikacja zapisze plik, otwórz go ponownie i sprawdź wymiary; konwersja formatu tej aplikacji może je znormalizować.
- **Export formats:** Powyższe przykłady PDF notatek i handoutów używają skonfigurowanych wymiarów strony. Obrazy rastrowe używają całkowitych wymiarów w pikselach i skali renderowania, więc ułamkowe wartości punktów mogą być zaokrąglane w wyjściu obrazu. Eksport standardowych slajdów nie stosuje rozmiaru strony notatek.
- **Printer drivers:** Wybór papieru, automatyczna rotacja i ustawienia dopasowania do strony mogą zmienić rzeczywisty wydruk bez zmiany wymiarów zapisanych w prezentacji lub PDF. Dla określonego rozmiaru papieru dopasuj ustawienia drukarki i sprawdź podgląd wydruku.

## **FAQ**

**Czy mogę ustawić rozmiar notatek tylko dla jednego slajdu?**

Rozmiar strony notatek jest ustawieniem na poziomie całej prezentacji. Pojedyncze slajdy mogą mieć różną treść notatek, ale ta właściwość nie zapewnia oddzielnego rozmiaru strony dla każdego slajdu.

**Dlaczego zmiana orientacji notatek nie zmieniła moich slajdów?**

Strony notatek i standardowe slajdy mają niezależne wymiary. Użyj ustawień rozmiaru zwykłych slajdów, gdy chcesz zmienić rozmiar samych slajdów.

**Dlaczego mój zapisany lub wydrukowany wynik ma inny rozmiar?**

Najpierw otwórz ponownie zapisaną prezentację i porównaj jej wymiary notatek. Jeśli się zmieniły, sprawdź, czy zapisanie lub konwersja pliku w innej aplikacji zmieniła ustawienia strony. Jeśli nie, sprawdź układ eksportu, skalę obrazu, ustawienia przeglądarki i wybór papieru w drukarce.