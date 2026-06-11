---
title: Dodawanie slajdów do prezentacji w Javie
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/java/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Java—bezproblemowe, efektywne wstawianie slajdów w kilka sekund."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie slajdów do prezentacji PowerPoint. Prezentacja zawiera slajdy master/układ oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu zerowego. Każdy slajd ma unikalny identyfikator, a pliki prezentacji bez slajdów nie są obsługiwane.

Ten artykuł wyjaśnia, jak utworzyć obiekt `Presentation`, uzyskać dostęp do jego kolekcji slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem oraz zapisać zaktualizowaną prezentację. Omówione są także powiązane zagadnienia, takie jak wstawianie slajdów w określonej pozycji, używanie układów oraz zrozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Dodaj slajd do prezentacji**

Zanim przejdziemy do dodawania slajdów do plików prezentacji, omówmy kilka faktów dotyczących slajdów. Każdy plik prezentacji PowerPoint zawiera slajd **Master / Layout** oraz inne **Normal** slajdy. Oznacza to, że plik prezentacji zawiera co najmniej jeden slajd. Ważne jest, aby wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for Java. Każdy slajd ma unikalny Id, a wszystkie Normal Slides są uporządkowane według indeksu zerowego.

Aspose.Slides for Java umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd w prezentacji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
- Utwórz instancję klasy [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection), ustawiając odniesienie do właściwości [Slides](https://reference.aspose.com/slides/pl/java/com.aspose.slides/Presentation#getSlides--) (kolekcja obiektów Slide zawierających treść), udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).
- Dodaj pusty slajd do prezentacji na końcu kolekcji slajdów zawartości, wywołując metodę [**addEmptySlide**](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ISlideCollection).
- Wykonaj operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji, używając obiektu [Presentation](https://reference.aspose.com/slides/pl/java/com.aspose.slides/presentation).

```java
// Utwórz klasę Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation();
try {
    // Utwórz klasę SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Dodaj pusty slajd do kolekcji Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Wykonaj operacje na nowo dodanym slajdzie

    // Zapisz plik PPTX na dysku
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Czy mogę wstawić nowy slajd w określonej pozycji, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), dzięki czemu można dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motywy/style są zachowywane przy dodawaniu slajdu opartego na układzie?**

Tak. Układ dziedziczy formatowanie po swoim masterze, a nowy slajd dziedziczy po wybranym układzie i powiązanym masterze.

**Jaki slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. Jest to istotne przy obliczaniu indeksów wstawiania.

**Jak wybrać właściwy układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybiera się [LayoutSlide](https://reference.aspose.com/slides/pl/java/com.aspose.slides/layoutslide/), który odpowiada wymaganemu układowi ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pl/java/com.aspose.slides/slidelayouttype/)). Jeśli taki układ nie istnieje, można go [dodaj go do mastera](/slides/pl/java/slide-layout/) i następnie użyć.