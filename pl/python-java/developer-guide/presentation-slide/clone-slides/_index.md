---
title: Klonowanie slajdów prezentacji w Pythonie
linktitle: Klonuj slajdy
type: docs
weight: 35
url: /pl/python-java/clone-slides/
keywords:
- klonowanie slajdu
- kopiowanie slajdu
- zapis slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Szybko duplikuj slajdy PowerPoint za pomocą Aspose.Slides for Python via Java. Skorzystaj z naszych przejrzystych przykładów kodu, aby zautomatyzować tworzenie plików PPT w kilka sekund i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for Python via Java umożliwia również wykonanie kopii lub klona dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej prezentacji lub dowolnej innej otwartej prezentacji. Proces klonowania slajdów tworzy nowy slajd, który może być modyfikowany przez programistów bez zmiany oryginalnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innym miejscu w obrębie prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie razem z jego master slajdem w innej prezentacji.

W Aspose.Slides for Python via Java, kolekcja slajdów (kolekcja obiektów [Slide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slide/) ) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) i [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone), które umożliwiają wykonanie powyższych typów klonowania slajdów.

## **Klonowanie slajdu na końcu prezentacji**

Jeśli chcesz sklonować slajd i użyć go w tej samej prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Pobierz obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) i przekaż slajd do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone).
1. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – w prezentacji) na koniec prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt klasy Presentation reprezentujący plik prezentacji
presentation = Presentation("CloneWithinSamePresentationToEnd.pptx")
try:
    # Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    slides = presentation.getSlides()

    slides.addClone(presentation.getSlides().get_Item(0))

    # Zapisz zmodyfikowaną prezentację na dysku
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonowanie slajdu na inną pozycję w obrębie prezentacji**

Jeśli chcesz sklonować slajd i użyć go w tej samej prezentacji, ale w innym miejscu, użyj metody [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj referencję do kolekcji slajdów zwróconej przez [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) na obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się pod indeksem 1 – pozycja 2 – w prezentacji) do indeksu 2 – pozycja 3 – w prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt klasy Presentation reprezentujący plik prezentacji
presentation = Presentation("CloneWithInSamePresentation.pptx")
try:
    # Pobierz kolekcję slajdów w prezentacji
    slides = presentation.getSlides()

    # Sklonuj wybrany slajd do określonego indeksu w tej samej prezentacji
    slides.insertClone(2, presentation.getSlides().get_Item(1))

    # Zapisz zmodyfikowaną prezentację na dysku
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Klonowanie slajdu na końcu innej prezentacji**

Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej prezentację, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej docelową prezentację, do której slajd zostanie dodany.
1. Pobierz obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) odwołując się do kolekcji slajdów zwróconej przez [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) na obiekcie [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) i przekaż slajd z prezentacji źródłowej jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu 0 prezentacji źródłowej) na koniec docelowej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt klasy Presentation w celu wczytania pliku źródłowej prezentacji
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Utwórz obiekt klasy Presentation dla docelowego pliku PPTX (gdzie slajd ma zostać sklonowany)
    destination_presentation = Presentation()
    try:
        # Sklonuj wybrany slajd ze źródłowej prezentacji na koniec kolekcji slajdów w prezentacji docelowej
        slides = destination_presentation.getSlides()

        slides.addClone(source_presentation.getSlides().get_Item(0))

        # Zapisz docelową prezentację na dysku
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klonowanie slajdu na inną pozycję w innej prezentacji**

Jeśli potrzebujesz sklonować slajd z jednej prezentacji i użyć go w innej, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej źródłową prezentację, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej prezentację, do której slajd zostanie dodany.
1. Pobierz obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) docelowej prezentacji.
1. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) do indeksu 1 (pozycja 2) docelowej prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt klasy Presentation w celu wczytania pliku źródłowej prezentacji
source_presentation = Presentation("CloneAtEndOfAnother.pptx")
try:
    # Utwórz obiekt klasy Presentation dla docelowego pliku PPTX (gdzie slajd ma być sklonowany)
    destination_presentation = Presentation()
    try:
        # Sklonuj wybrany slajd ze źródłowej prezentacji do określonego indeksu w prezentacji docelowej
        slides = destination_presentation.getSlides()

        slides.insertClone(1, source_presentation.getSlides().get_Item(0))

        # Zapisz docelową prezentację na dysku
        destination_presentation.save("Aspose2_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klonowanie slajdu wraz z jego master slajdem do innej prezentacji**

Jeśli potrzebujesz sklonować slajd wraz z master slajdem z jednej prezentacji i użyć go w innej, najpierw musisz sklonować żądany master slajd ze źródłowej prezentacji do docelowej prezentacji. Następnie użyj sklonowanego master slajdu przy klonowaniu slajdu. Metoda [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) oczekuje master slajdu z docelowej prezentacji, a nie ze źródłowej. Aby sklonować slajd z masterem, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej źródłową prezentację, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) zawierającej docelową prezentację, do której slajd zostanie sklonowany.
1. Uzyskaj dostęp do slajdu, który ma zostać sklonowany, wraz z master slajdem.
1. Pobierz obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/#addClone) udostępnioną przez obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/) i przekaż master z pliku PPTX źródłowego jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/masterslidecollection/#addClone).
1. Pobierz obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) odwołując się do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) i przekaż slajd z prezentacji źródłowej do sklonowania oraz master slajd jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zero w prezentacji źródłowej) na koniec docelowej prezentacji, używając mastera ze slajdu źródłowego.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz obiekt klasy Presentation w celu wczytania pliku źródłowej prezentacji
source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    # Utwórz obiekt klasy Presentation dla docelowej prezentacji (gdzie slajd ma być sklonowany)
    destination_presentation = Presentation()
    try:
        # Utwórz obiekt Slide z kolekcji slajdów w prezentacji źródłowej wraz z
        # master slajdem
        source_slide = source_presentation.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()

        # Sklonuj żądany master slajd z prezentacji źródłowej do kolekcji masterów w
        # prezentacji docelowej
        masters = destination_presentation.getMasters()
        destination_master = masters.addClone(source_master)

        # Sklonuj żądany slajd z prezentacji źródłowej z wybranym masterem na koniec
        # kolekcji slajdów w prezentacji docelowej
        slides = destination_presentation.getSlides()
        slides.addClone(source_slide, destination_master, True)

        # Zapisz docelową prezentację na dysku
        destination_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx)
    finally:
        destination_presentation.dispose()
finally:
    source_presentation.dispose()
```

## **Klonowanie slajdu na końcu określonej sekcji**

Jeśli chcesz sklonować slajd i użyć go w tej samej prezentacji, ale w innej sekcji, użyj metody [**addClone**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addClone) udostępnionej przez klasę [**SlideCollection**](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/). Aspose.Slides for Python via Java umożliwia klonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100)
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0))

    destination_section = presentation.getSections().appendEmptySection("Section 2")
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), destination_section)

    # Zapisz docelową prezentację na dysku
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zapewnienie zgodnego rozmiaru slajdu**

Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów różnią się, Aspose.Slides nie przeskalowuje automatycznie sklonowanych kształtów – ich pierwotne współrzędne i wymiary pozostają zachowane, co może spowodować nieprawidłowe wyrównanie treści lub wyjście poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby odpowiadał rozmiarowi źródłowemu przed klonowaniem mastera i slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideSizeScaleType

source_presentation = Presentation("CloneToAnotherPresentationWithMaster.pptx")
try:
    target_presentation = Presentation()
    try:
        source_size = source_presentation.getSlideSize().getSize()
        target_presentation.getSlideSize().setSize(jpype.JFloat(source_size.getWidth()), jpype.JFloat(source_size.getHeight()), SlideSizeScaleType.DoNotScale)
    finally:
        target_presentation.dispose()
finally:
    source_presentation.dispose()
```

Zrób to przed klonowaniem mastera i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzenta są klonowane?**

Tak. Strona notatek i komentarze recenzenta są zawarte w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/python-java/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i osadzone dane są kopiowane. Jeśli wykres był powiązany z zewnętrznym źródłem (np. skoroszytem osadzonym jako OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/python-java/manage-ole/). Po przeniesieniu między plikami należy sprawdzić dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określonym indeksie slajdu i umieścić go w wybranej [sekcji](/slides/pl/python-java/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś slajd do niej.