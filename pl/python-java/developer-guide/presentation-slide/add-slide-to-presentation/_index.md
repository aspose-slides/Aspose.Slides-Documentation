---
title: Dodawanie slajdów do prezentacji w Pythonie
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/python-java/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Python via Java — płynne, wydajne wstawianie slajdów w kilka sekund."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie slajdów do prezentacji PowerPoint. Prezentacja zawiera slajdy master/układu oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu rozpoczynającego się od zera. Każdy slajd ma unikalny identyfikator, a pliki prezentacji bez slajdów nie są obsługiwane.

Ten artykuł wyjaśnia, jak utworzyć obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) , uzyskać dostęp do jego kolekcji slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem oraz zapisać zaktualizowaną prezentację. Omówione są również powiązane kwestie, takie jak wstawianie slajdów w określonym miejscu, używanie układów oraz zrozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Dodaj slajd do prezentacji**

Zanim omówimy, jak dodawać slajdy do plików prezentacji, przyjrzyjmy się kilku faktom na temat slajdów. Każdy plik prezentacji PowerPoint zawiera slajdy **master/układ** oraz **zwykłe** slajdy. Plik prezentacji zawiera przynajmniej jeden slajd. Pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for Python via Java. Każdy slajd ma unikalny identyfikator, a wszystkie zwykłe slajdy są uporządkowane w kolejności określonej indeksem rozpoczynającym się od zera.

Aspose.Slides for Python via Java umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd do prezentacji, wykonaj następujące kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odwołanie do obiektu [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/) za pomocą metody [getSlides](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/#getSlides) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Dodaj pusty slajd na koniec kolekcji slajdów prezentacji, wywołując metodę [addEmptySlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#addEmptySlide) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/).
- Wykonaj pewne operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji przy użyciu obiektu [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
presentation = Presentation()
try:
    # Pobierz kolekcję slajdów.
    slides = presentation.getSlides()

    for i in range(presentation.getLayoutSlides().size()):
        # Dodaj pusty slajd do kolekcji slajdów.
        slides.addEmptySlide(presentation.getLayoutSlides().get_Item(i))

    # Wykonaj pewne operacje na nowo dodanym slajdzie.

    # Zapisz plik PPTX na dysku.
    presentation.save("EmptySlide.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę wstawić nowy slajd w określonym miejscu, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertEmptySlide)/[clone](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidecollection/#insertClone), dzięki czemu możesz dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motyw/style są zachowywane podczas dodawania slajdu na podstawie układu?**

Tak. Układ dziedziczy formatowanie po swoim masterze, a nowy slajd dziedziczy po wybranym układzie i powiązanym z nim masterze.

**Jaki slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. Jest to ważne przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybierz [LayoutSlide](https://reference.aspose.com/slides/pl/python-java/aspose.slides/layoutslide/), który odpowiada wymaganemu układowi ([Tytuł i zawartość, Dwie zawartości, itp.](https://reference.aspose.com/slides/pl/python-java/aspose.slides/slidelayouttype/)). Jeśli taki układ nie istnieje, możesz [dodaj go do mastera](/slides/pl/python-java/slide-layout/) i potem go użyć.