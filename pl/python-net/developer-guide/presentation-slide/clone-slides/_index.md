---
title: Klonowanie slajdów PowerPoint w Pythonie
linktitle: Klonuj slajdy
type: docs
weight: 40
url: /pl/python-net/clone-slides/
keywords:
- klonowanie slajdu
- kopiowanie slajdu
- zapis slajdu
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Szybko klonuj lub duplikuj slajdy PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez .NET. Korzystaj z naszych przejrzystych przykładów kodu i wskazówek, aby automatyzować tworzenie prezentacji PPT w kilka sekund, zwiększyć wydajność i wyeliminować ręczną pracę."
---
## **Wstęp**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides umożliwia również kopiowanie (klonowanie) dowolnego slajdu, a następnie wstawienie sklonowanego slajdu do bieżącej prezentacji lub dowolnej innej otwartej prezentacji. Klonowanie slajdu tworzy nowy slajd, który programiści mogą modyfikować bez wpływu na oryginalny slajd. Istnieje kilka sposobów klonowania slajdu:

- Klonowanie na końcu prezentacji.
- Klonowanie w innej pozycji w obrębie prezentacji.
- Klonowanie na końcu innej prezentacji.
- Klonowanie w innej pozycji w innej prezentacji.
- Klonowanie w określonej pozycji w innej prezentacji.

W Aspose.Slides dla Pythona poprzez .NET, [slide collection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) zapewnia metody `add_clone` i `insert_clone` służące do wykonywania tego typu klonowania slajdów.

## **Instalacja**

```bash
pip install aspose.slides
```

## **Instalacja**

```bash
pip install aspose.slides
```

## **Instalacja**

```bash
pip install aspose.slides
```

## **Klonowanie na końcu w obrębie tej samej prezentacji**

Jeśli chcesz sklonować slajd w tej samej prezentacji i dodać go na koniec istniejących slajdów, użyj metody `add_clone`. Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Pobierz kolekcję slajdów z obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
3. Wywołaj metodę `add_clone` na [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd do sklonowania.
4. Zapisz zmodyfikowaną prezentację.

W poniższym przykładzie pierwszy slajd (indeks 0) jest klonowany i dodawany na koniec prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik prezentacji.
with slides.Presentation("CloneWithinSamePresentationToEnd.pptx") as presentation:
    # Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji.
    presentation.slides.add_clone(presentation.slides[0])
    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie do określonej pozycji w tej samej prezentacji**

Jeśli chcesz sklonować slajd w tej samej prezentacji i umieścić go w innej pozycji, użyj metody `insert_clone`:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Pobierz kolekcję slajdów z obiektu [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Wywołaj metodę `insert_clone` na [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd do sklonowania oraz docelowy indeks dla jego nowej pozycji.
1. Zapisz zmodyfikowaną prezentację.

W poniższym przykładzie slajd o indeksie 1 (pozycja 2) jest klonowany do indeksu 2 (pozycja 3) w tej samej prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik prezentacji.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Sklonuj żądany slajd do określonej pozycji (indeks) w tej samej prezentacji.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie na końcu innej prezentacji**

Jeśli potrzebujesz sklonować slajd z jednej prezentacji i dodać go na koniec innej prezentacji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji źródłowej (tej, która zawiera slajd do sklonowania).
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji docelowej (w której slajd zostanie dodany).
1. Pobierz kolekcję slajdów z prezentacji docelowej.
1. Wywołaj `add_clone` na docelowym [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd z prezentacji źródłowej.
1. Zapisz zmodyfikowaną prezentację docelową.

W poniższym przykładzie slajd o indeksie 0 w prezentacji źródłowej jest klonowany do końca prezentacji docelowej.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik źródłowej prezentacji.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd zostanie sklonowany).
    with slides.Presentation() as target_presentation:
        # Sklonuj wybrany slajd ze źródłowej prezentacji na koniec kolekcji slajdów w prezentacji docelowej.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Zapisz docelową prezentację na dysku.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie do określonej pozycji w innej prezentacji**

Jeśli musisz sklonować slajd z jednej prezentacji i wstawić go do innej prezentacji w określonym miejscu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji źródłowej (tej, która zawiera slajd do sklonowania).
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji docelowej (w której slajd zostanie dodany).
1. Pobierz kolekcję slajdów z prezentacji docelowej.
1. Wywołaj metodę `insert_clone` na docelowym [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd z prezentacji źródłowej oraz żądany docelowy indeks.
1. Zapisz zmodyfikowaną prezentację docelową.

W poniższym przykładzie slajd o indeksie 0 w prezentacji źródłowej jest klonowany do indeksu 2 (pozycja 3) w prezentacji docelowej.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik źródłowej prezentacji.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Wstaw klon pierwszego slajdu ze źródła pod indeksem 2 w docelowej prezentacji.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Zapisz docelową prezentację na dysku.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie slajdu wraz z jego slajdem głównym do innej prezentacji**

Jeśli musisz sklonować slajd **z jego masterem** z jednej prezentacji i użyć go w innej, najpierw sklonuj wymagany slajd główny z prezentacji źródłowej do prezentacji docelowej. Następnie użyj tego mastera docelowego przy klonowaniu slajdu. Metoda `add_clone(Slide, MasterSlide)` oczekuje **slajdu głównego z prezentacji docelowej**, a nie ze źródłowej.

Aby sklonować slajd wraz z jego masterem, wykonaj następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji źródłowej (tej, która zawiera slajd do sklonowania).
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji docelowej.
1. Uzyskaj dostęp do slajdu źródłowego, który ma być sklonowany, oraz jego slajdu głównego.
1. Pobierz [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/) z kolekcji masterów prezentacji docelowej.
1. Wywołaj `add_clone` na docelowym [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/), przekazując master źródłowy, aby sklonować go do docelowego.
1. Pobierz [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) z kolekcji slajdów prezentacji docelowej.
1. Wywołaj `add_clone` na docelowym [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd źródłowy oraz sklonowany master docelowy.
1. Zapisz zmodyfikowaną prezentację docelową.

W poniższym przykładzie slajd o indeksie 0 w prezentacji źródłowej jest klonowany na koniec prezentacji docelowej z użyciem mastera sklonowanego ze źródła.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik źródłowej prezentacji.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Utwórz instancję klasy Presentation dla docelowej prezentacji, w której slajd zostanie sklonowany.
    with slides.Presentation() as target_presentation:
        # Pobierz pierwszy slajd ze źródłowej prezentacji.
        source_slide = source_presentation.slides[0]
        # Pobierz slajd główny używany przez pierwszy slajd.
        source_master = source_slide.layout_slide.master_slide
        # Sklonuj slajd główny do kolekcji masterów docelowej prezentacji.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Sklonuj slajd ze źródłowej prezentacji na koniec docelowej prezentacji używając sklonowanego mastera.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Zapisz docelową prezentację na dysku.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie na końcu w wybranej sekcji**

Przy użyciu Aspose.Slides dla Pythona poprzez .NET możesz sklonować slajd z jednej sekcji prezentacji i wstawić go do innej sekcji w tej samej prezentacji. Aby to zrobić, użyj metody `add_clone(Slide, Section)` klasy [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/).

Przykład w Pythonie poniżej pokazuje, jak sklonować slajd i wstawić klon do określonej sekcji:

```py
import aspose.slides as slides

# Utwórz nową pustą prezentację.
with slides.Presentation() as presentation:
    # Dodaj pusty slajd na podstawie układu pierwszego slajdu.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Dodaj kształt elipsy do nowego slajdu; ten slajd będzie później klonowany.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Dodaj kolejny pusty slajd na podstawie układu pierwszego slajdu.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Utwórz sekcję o nazwie "Section2", która zaczyna się od slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Sklonuj wcześniej utworzony slajd do sekcji "Section2".
    presentation.slides.add_clone(slide, section)
    # Zapisz prezentację jako plik PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **Upewnij się, że rozmiar slajdu jest zgodny**

Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów różnią się, Aspose.Slides nie przeskalowuje automatycznie sklonowanych kształtów — ich pierwotne współrzędne i wymiary są zachowane, co może spowodować, że zawartość będzie wyświetlana nieprawidłowo lub wyjdzie poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby odpowiadał źródłowemu przed klonowaniem mastera i slajdu:

```py
source_size = source_presentation.slide_size.size

target_presentation.slide_size.set_size(
    source_size.width, source_size.height, slides.SlideSizeScaleType.DO_NOT_SCALE)
```

Zrób to przed klonowaniem mastera i slajdu.

## **FAQ**

### Czy notatki prelegenta i komentarze recenzentów są klonowane?

Tak. Strona z notatkami oraz komentarze recenzentów są dołączane do klonu. Jeśli ich nie chcesz, [usuń je](/slides/pl/python-net/presentation-notes/) po wstawieniu.

### Jak obsługiwane są wykresy i ich źródła danych?

Obiekt wykresu, formatowanie oraz wbudowane dane są kopiowane. Jeśli wykres był powiązany z zewnętrznym źródłem (np. zeszytem OLE osadzonym), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/python-net/manage-ole/). Po przeniesieniu pomiędzy plikami należy sprawdzić dostępność danych i zachowanie odświeżania.

### Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/python-net/slide-section/). Jeśli docelowa sekcja nie istnieje, utwórz ją najpierw, a następnie przenieś slajd do niej.
