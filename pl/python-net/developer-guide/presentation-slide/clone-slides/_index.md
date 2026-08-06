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
description: "Szybko klonuj lub duplikuj slajdy PowerPoint za pomocą Aspose.Slides for Python via .NET. Skorzystaj z naszych przejrzystych przykładów kodu i wskazówek, aby automatyzować tworzenie prezentacji PPT w kilka sekund, zwiększyć wydajność i wyeliminować ręczną pracę."
---
## **Wprowadzenie**

Klonowanie jest procesem tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides również umożliwia kopiowanie (klonowanie) dowolnego slajdu, a następnie wstawienie sklonowanego slajdu do bieżącej prezentacji lub dowolnej innej otwartej prezentacji. Klonowanie slajdu tworzy nowy slajd, który deweloperzy mogą modyfikować bez wpływu na oryginalny slajd. Istnieje kilka sposobów klonowania slajdu:

- Klonowanie na końcu prezentacji.
- Klonowanie w innym miejscu w obrębie prezentacji.
- Klonowanie na końcu innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie w określonym miejscu w innej prezentacji.

W Aspose.Slides for Python via .NET, [kolekcja slajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) udostępniona przez obiekt [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) zapewnia metody `add_clone` i `insert_clone`, które umożliwiają wykonywanie tego rodzaju klonowania slajdów.

## **Instalacja**

```bash
pip install aspose.slides
```

## **Klonowanie na końcu w obrębie tej samej prezentacji**

Jeśli chcesz sklonować slajd w tej samej prezentacji i dodać go na koniec istniejących slajdów, użyj metody `add_clone`. Postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj kolekcję slajdów z obiektu [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Wywołaj metodę `add_clone` na [KolekcjaSlajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd do sklonowania.
1. Zapisz zmodyfikowaną prezentację.

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

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj kolekcję slajdów z obiektu [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Wywołaj metodę `insert_clone` na [KolekcjaSlajdów](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd do sklonowania oraz docelowy indeks nowej pozycji.
1. Zapisz zmodyfikowaną prezentację.

W poniższym przykładzie slajd o indeksie 1 (pozycja 2) jest klonowany do indeksu 2 (pozycja 3) w obrębie tej samej prezentacji.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik prezentacji.
with slides.Presentation("CloneWithInSamePresentation.pptx") as presentation:
    # Sklonuj wybrany slajd do określonej pozycji (indeks) w tej samej prezentacji.
    presentation.slides.insert_clone(2, presentation.slides[1])
    # Zapisz zmodyfikowaną prezentację na dysku.
    presentation.save("Aspose_CloneWithInSamePresentation_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie na końcu innej prezentacji**

Jeśli potrzebujesz sklonować slajd z jednej prezentacji i dodać go na koniec innej prezentacji:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji źródłowej (zawierającej slajd do klonowania).
1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji docelowej (gdzie slajd zostanie dodany).
1. Uzyskaj kolekcję slajdów z prezentacji docelowej.
1. Wywołaj `add_clone` na kolekcji slajdów prezentacji docelowej, przekazując slajd z prezentacji źródłowej.
1. Zapisz zmodyfikowaną prezentację docelową.

W poniższym przykładzie slajd o indeksie 0 w prezentacji źródłowej jest klonowany do końca prezentacji docelowej.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik źródłowej prezentacji.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd zostanie sklonowany).
    with slides.Presentation() as target_presentation:
        # Sklonuj wybrany slajd ze źródłowej prezentacji na koniec kolekcji slajdów w docelowej prezentacji.
        target_presentation.slides.add_clone(source_presentation.slides[0])
        # Zapisz docelową prezentację na dysku.
        target_presentation.save("Aspose2_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie do określonej pozycji w innej prezentacji**

Jeśli potrzebujesz sklonować slajd z jednej prezentacji i wstawić go do innej prezentacji w określonej pozycji:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji źródłowej (zawierającej slajd do klonowania).
1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji docelowej (gdzie slajd zostanie dodany).
1. Uzyskaj kolekcję slajdów z prezentacji docelowej.
1. Wywołaj metodę `insert_clone` na kolekcji slajdów prezentacji docelowej, przekazując slajd z prezentacji źródłowej oraz żądany docelowy indeks.
1. Zapisz zmodyfikowaną prezentację docelową.

W poniższym przykładzie slajd o indeksie 0 w prezentacji źródłowej jest klonowany do indeksu 2 (pozycja 3) w prezentacji docelowej.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik źródłowej prezentacji.
with slides.Presentation("CloneAtEndOfAnother.pptx") as source_presentation:
    # Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany).
    with slides.Presentation("Aspose2_out.pptx") as target_presentation:
        # Wstaw klon pierwszego slajdu ze źródła na indeks 2 w docelowej prezentacji.
        target_presentation.slides.insert_clone(2, source_presentation.slides[0])
        # Zapisz docelową prezentację na dysku.
        target_presentation.save("Aspose3_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie slajdu razem z jego masterem do innej prezentacji**

Jeśli musisz sklonować slajd **z jego masterem** z jednej prezentacji i użyć go w innej, najpierw sklonuj wymagany master slajd z prezentacji źródłowej do prezentacji docelowej. Następnie użyj tego mastera docelowego przy klonowaniu slajdu. Metoda `add_clone(Slide, MasterSlide)` oczekuje **mastera slajdu z prezentacji docelowej**, a nie ze źródłowej.

Aby sklonować slajd razem z jego masterem, wykonaj następujące kroki:

1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji źródłowej (zawierającej slajd do klonowania).
1. Utwórz instancję klasy [Prezentacja](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) dla prezentacji docelowej.
1. Uzyskaj dostęp do slajdu źródłowego, który ma zostać sklonowany, oraz jego mastera.
1. Uzyskaj [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/) z kolekcji masterów prezentacji docelowej.
1. Wywołaj `add_clone` na [MasterSlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/masterslidecollection/), przekazując master ze źródła, aby sklonować go do docelowej.
1. Uzyskaj [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/) z kolekcji slajdów prezentacji docelowej.
1. Wywołaj `add_clone` na [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/), przekazując slajd źródłowy oraz sklonowany master docelowy.
1. Zapisz zmodyfikowaną prezentację docelową.

W poniższym przykładzie slajd o indeksie 0 w prezentacji źródłowej jest klonowany do końca prezentacji docelowej przy użyciu mastera sklonowanego ze źródła.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation, aby reprezentować plik źródłowej prezentacji.
with slides.Presentation("CloneToAnotherPresentationWithMaster.pptx") as source_presentation:
    # Utwórz instancję klasy Presentation dla docelowej prezentacji, w której slajd zostanie sklonowany.
    with slides.Presentation() as target_presentation:
        # Pobierz pierwszy slajd ze źródłowej prezentacji.
        source_slide = source_presentation.slides[0]
        # Pobierz master slajd używany przez pierwszy slajd.
        source_master = source_slide.layout_slide.master_slide
        # Sklonuj master slajd do kolekcji masterów docelowej prezentacji.
        cloned_master = target_presentation.masters.add_clone(source_master)
        # Sklonuj slajd ze źródłowej prezentacji na koniec docelowej prezentacji, używając sklonowanego mastera.
        target_presentation.slides.add_clone(source_slide, cloned_master, True)
        # Zapisz docelową prezentację na dysku.
        target_presentation.save("CloneToAnotherPresentationWithMaster_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Klonowanie na końcu w określonej sekcji**

Za pomocą Aspose.Slides for Python via .NET możesz sklonować slajd z jednej sekcji prezentacji i wstawić go do innej sekcji w tej samej prezentacji. Aby to zrobić, użyj metody `add_clone(Slide, Section)` klasy [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/).

Poniższy przykład w Pythonie pokazuje, jak sklonować slajd i wstawić klon do określonej sekcji:

```py
import aspose.slides as slides

# Utwórz nową pustą prezentację.
with slides.Presentation() as presentation:
    # Dodaj pusty slajd oparty na układzie pierwszego slajdu.
    slide = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Dodaj kształt elipsy do nowego slajdu; ten slajd zostanie później sklonowany.
    slide.shapes.add_auto_shape(slides.ShapeType.ELLIPSE, 150, 150, 100, 100)
    # Dodaj kolejny pusty slajd oparty na układzie pierwszego slajdu.
    slide2 = presentation.slides.add_empty_slide(presentation.slides[0].layout_slide)
    # Utwórz sekcję o nazwie "Section2", która zaczyna się od slide2.
    section = presentation.sections.add_section("Section2", slide2)
    # Sklonuj wcześniej utworzony slajd do sekcji "Section2".
    presentation.slides.add_clone(slide, section)
    # Zapisz prezentację jako plik PPTX.
    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Czy notatki prelegenta i komentarze recenzenta są klonowane?

Tak. Strona z notatkami i komentarze recenzenta są zawarte w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/python-net/presentation-notes/) po wstawieniu.

### Jak obsługiwane są wykresy i ich źródła danych?

Obiekt wykresu, formatowanie oraz osadzone dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. arkuszem wbudowanym jako OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/python-net/manage-ole/). Po przeniesieniu między plikami zweryfikuj dostępność danych oraz zachowanie odświeżania.

### Czy mogę kontrolować pozycję wstawiania i sekcje klonu?

Tak. Możesz wstawić klon na określonym indeksie slajdu i umieścić go w wybranej [sekcji](/slides/pl/python-net/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś do niej slajd.