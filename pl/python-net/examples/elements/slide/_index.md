---
title: Slajd
type: docs
weight: 10
url: /pl/python-net/examples/elements/slide/
keywords:
- slajd
- dodaj slajd
- dostęp do slajdu
- indeks slajdu
- klonuj slajd
- zmień kolejność slajdów
- usuń slajd
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj slajdami w Pythonie przy użyciu Aspose.Slides: twórz, klonuj, zmieniaj kolejność, ukrywaj, ustawiaj tła i rozmiar, stosuj przejścia oraz eksportuj do formatu PowerPoint i OpenDocument."
---
Ten artykuł zawiera szereg przykładów demonstrujących, jak pracować ze slajdami przy użyciu **Aspose.Slides for Python via .NET**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, przestawiać i usuwać slajdy za pomocą klasy `Presentation`.

Każdy przykład poniżej zawiera krótkie wyjaśnienie, a następnie fragment kodu w języku Python.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw musisz wybrać układ. W tym przykładzie używamy układu `Blank` i dodajemy pusty slajd do prezentacji.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Każdy slajd opiera się na układzie, który sam jest oparty na slajdzie głównym.
        # Użyj układu Blank, aby utworzyć nowy slajd.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Dodaj nowy pusty slajd przy użyciu wybranego układu.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Wskazówka:** Każdy układ slajdu pochodzi z głównego slajdu, który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obraz ilustruje, jak główne slajdy i ich powiązane układy są zorganizowane w programie PowerPoint.

![Relacja między szablonem głównym a układem](master-layout-slide.png)

## **Uzyskaj dostęp do slajdów według indeksu**

Możesz uzyskać dostęp do slajdów przy użyciu ich indeksu. Jest to przydatne przy iteracji po slajdach lub modyfikowaniu konkretnych slajdów.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Uzyskaj dostęp do slajdu według indeksu.
        first_slide = presentation.slides[0]
```

## **Klonuj slajd**

Ten przykład pokazuje, jak sklonować istniejący slajd. Sklonowany slajd jest automatycznie dodawany na końcu kolekcji slajdów.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Sklonuj slajd; zostanie on dodany na końcu prezentacji.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Przestaw kolejność slajdów**

Możesz zmienić kolejność slajdów, przenosząc je na nowy indeks. W tym przypadku przenosimy slajd na pierwszą pozycję.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Przenieś slajd na pierwszą pozycję (pozostałe przesuwają się w dół).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuń slajd**

Aby usunąć slajd, po prostu odwołaj się do niego i wywołaj `remove`. Ten przykład usuwa pierwszy slajd.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Usuń slajd.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```