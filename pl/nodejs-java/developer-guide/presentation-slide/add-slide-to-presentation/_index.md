---
title: Dodawanie slajdów do prezentacji w JavaScript
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/nodejs-java/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for Node.js via Java — płynne, wydajne wstawianie slajdów w ciągu kilku sekund."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie slajdów do prezentacji PowerPoint. Prezentacja zawiera slajdy master/layout oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu zaczynającego się od zera. Każdy slajd ma unikalny identyfikator, a pliki prezentacji bez slajdów nie są obsługiwane.

W tym artykule wyjaśniono, jak utworzyć obiekt `Presentation`, uzyskać dostęp do jego kolekcji slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem oraz zapisać zaktualizowaną prezentację. Omówiono również kwestie takie jak wstawianie slajdów w określonym miejscu, używanie układów oraz rozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Dodaj slajd do prezentacji**

Zanim przejdziemy do dodawania slajdów do plików prezentacji, omówmy kilka faktów dotyczących slajdów. Każdy plik prezentacji PowerPoint zawiera slajd **Master / Layout** oraz inne **Normal** slajdy. Oznacza to, że plik prezentacji zawiera przynajmniej jeden slajd. Ważne jest, aby wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for Node.js via Java. Każdy slajd ma unikalny Id, a wszystkie Normal Slides są uporządkowane według indeksu zaczynającego się od zera.

Aspose.Slides for Node.js via Java umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd w prezentacji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
- Zainicjuj klasę [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection), ustawiając odniesienie do właściwości [Slides](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/Presentation#getSlides--) (kolekcja obiektów Slide zawierających treść) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).
- Dodaj pusty slajd do prezentacji na końcu kolekcji slajdów treści, wywołując metodę [**addEmptySlide**](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/SlideCollection).
- Wykonaj potrzebne operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji, używając obiektu [Presentation](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation).

```javascript
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
var pres = new aspose.slides.Presentation();
try {
    // Utwórz instancję klasy SlideCollection
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Dodaj pusty slajd do kolekcji Slides
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Wykonaj pewne operacje na nowo dodanym slajdzie
    // Zapisz plik PPTX na dysku
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Czy mogę wstawić nowy slajd w określonym miejscu, a nie tylko na końcu?**  
Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidecollection/insertclone/), dzięki czemu możesz dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motyw/style są zachowywane przy dodawaniu slajdu opartego na układzie?**  
Tak. Układ dziedziczy formatowanie z swojego mastera, a nowy slajd dziedziczy po wybranym układzie i powiązanym z nim masterze.

**Jaki slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**  
Nowo utworzona prezentacja zawiera już jeden pusty slajd o indeksie zero. Jest to ważne przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**  
Zazwyczaj wybierz [LayoutSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/layoutslide/), który odpowiada wymaganemu układowi ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/slidelayouttype/)). Jeśli taki układ nie istnieje, możesz [dodaj go do mastera](/slides/pl/nodejs-java/slide-layout/) i następnie go użyć.