---
title: Dodawanie slajdów do prezentacji w Pythonie
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/python-net/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument za pomocą Aspose.Slides dla Pythona w środowisku .NET — płynne, efektywne wstawianie slajdów w ciągu kilku sekund."
---
## **Przegląd**

Przed dodaniem slajdów do prezentacji warto zrozumieć, jak PowerPoint je organizuje. Każda prezentacja zawiera slajd master, opcjonalne slajdy układu oraz jeden lub więcej zwykłych slajdów. Każdy slajd ma unikalny identyfikator, a zwykłe slajdy są uporządkowane według indeksu zaczynającego się od zera. Ten artykuł pokazuje, jak używać Aspose.Slides dla Pythona do tworzenia slajdów i wyboru odpowiednich układów.

## **Dodawanie slajdów do prezentacji**

Aspose.Slides umożliwia dołączanie nowych slajdów na podstawie istniejących slajdów układu. Poniższy przykład przechodzi przez każdy układ w prezentacji, dodaje slajd używający tego układu, a następnie zapisuje plik.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
1. Uzyskaj dostęp do [SlideCollection](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/).
1. Dla każdego elementu w `presentation.layout_slides` wywołaj `add_empty_slide`, aby dołączyć slajd używający tego układu.
1. Opcjonalnie zmodyfikuj nowo dodane slajdy.
1. Zapisz prezentację jako plik PPTX.

```py
import aspose.slides as slides

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do kolekcji slajdów.
    slides = presentation.slides

    for layout_slide in presentation.layout_slides:
        # Dodaj pusty slajd do kolekcji slajdów.
        slides.add_empty_slide(layout_slide)

    # Wykonaj pewne operacje na nowo dodanych slajdach.

    # Zapisz prezentację na dysku.
    presentation.save("empty_slides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę wstawić nowy slajd w określonej pozycji, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/insert_empty_slide/)/[clone](https://reference.aspose.com/slides/pl/python-net/aspose.slides/slidecollection/insert_clone/), więc możesz dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motyw/style są zachowywane przy dodawaniu slajdu na podstawie układu?**

Tak. Układ dziedziczy formatowanie po swoim masterze, a nowy slajd dziedziczy po wybranym układzie oraz powiązanym masterze.

**Który slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. Jest to istotne przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybiera się [LayoutSlide](https://reference.aspose.com/slides/pl/python-net/aspose.slides/layoutslide/), który odpowiada wymaganemu układowi (Title and Content, Two Content itp.). Jeśli taki układ nie istnieje, możesz [add it to the master](/slides/pl/python-net/slide-layout/) i następnie go użyć.