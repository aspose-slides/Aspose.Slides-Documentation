---
title: Dodawanie slajdów do prezentacji na Androidzie
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/androidjava/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Android via Java — płynne, efektywne wstawianie slajdów w kilka sekund."
---
## **Overview**

Aspose.Slides umożliwia programowe dodawanie slajdów do prezentacji PowerPoint. Prezentacja zawiera slajdy typu master/layout oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu zerowego. Każdy slajd ma unikalny ID, a pliki prezentacji bez slajdów nie są obsługiwane.

Ten artykuł wyjaśnia, jak utworzyć obiekt `Presentation`, uzyskać dostęp do jego kolekcji slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem oraz zapisać zaktualizowaną prezentację. Omówione są również powiązane zagadnienia, takie jak wstawianie slajdów w określone miejsce, używanie układów oraz zrozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Add a Slide to a Presentation**

Zanim przejdziemy do dodawania slajdów do plików prezentacji, omówmy kilka faktów dotyczących slajdów. Każdy plik prezentacji PowerPoint zawiera slajd **Master / Layout** oraz inne slajdy **Normal**. Oznacza to, że plik prezentacji zawiera co najmniej jeden slajd. Ważne jest, aby wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for Android via Java. Każdy slajd ma unikalny Id, a wszystkie slajdy Normal są uporządkowane według indeksu zerowego.

Aspose.Slides for Android via Java umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd w prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
- Zainicjalizuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection), ustawiając odwołanie do właściwości [Slides](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/Presentation#getSlides--) (kolekcja obiektów Slide) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).
- Dodaj pusty slajd do prezentacji na końcu kolekcji slajdów zawartości, wywołując metodę [**addEmptySlide**](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) udostępnioną przez obiekt [ISlideCollection](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ISlideCollection).
- Wykonaj pewne operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji przy użyciu obiektu [Presentation](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/presentation).

```java
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
Presentation pres = new Presentation();
try {
    // Utwórz instancję klasy SlideCollection
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Dodaj pusty slajd do kolekcji Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Wykonaj pewne operacje na nowo dodanym slajdzie

    // Zapisz plik PPTX na dysk
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Czy mogę wstawić nowy slajd w określonym miejscu, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), dzięki czemu można dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motyw/style są zachowywane przy dodawaniu slajdu na podstawie układu?**

Tak. Układ dziedziczy formatowanie z swojego mastera, a nowy slajd dziedziczy z wybranego układu oraz powiązanego z nim mastera.

**Który slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. Jest to ważne przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybierz [LayoutSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/layoutslide/), który odpowiada wymaganemu układowi ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/slidelayouttype/)). Jeśli taki układ nie istnieje, możesz [dodaj go do mastera](/slides/pl/androidjava/slide-layout/) i następnie go użyć.