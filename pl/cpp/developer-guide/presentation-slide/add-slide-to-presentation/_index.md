---
title: Dodawanie slajdów do prezentacji w C++
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/cpp/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument za pomocą Aspose.Slides for C++ — płynne, wydajne wstawianie slajdów w kilka sekund."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie slajdów do prezentacji PowerPoint. Prezentacja zawiera slajdy master/układu oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu zerowego. Każdy slajd ma unikalny identyfikator, a pliki prezentacji bez slajdów nie są obsługiwane.

Ten artykuł wyjaśnia, jak utworzyć obiekt `Presentation`, uzyskać dostęp do jego kolekcji slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem oraz zapisać zaktualizowaną prezentację. Omawia również powiązane kwestie, takie jak wstawianie slajdów w określonej pozycji, używanie układów oraz rozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Dodaj slajd do prezentacji**
Zanim przejdziemy do dodawania slajdów do plików prezentacji, omówmy kilka faktów dotyczących slajdów. Każdy plik prezentacji PowerPoint zawiera slajd Master / Layout oraz inne zwykłe slajdy. Oznacza to, że plik prezentacji zawiera co najmniej jeden slajd. Ważne jest, aby wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for C++. Każdy slajd ma unikalny identyfikator, a wszystkie zwykłe slajdy są uporządkowane zgodnie z indeksem zerowym. Aspose.Slides for C++ umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd w prezentacji, proszę postępować zgodnie z poniższymi krokami:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .
- Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/) , ustawiając odniesienie do właściwości Slides (kolekcja obiektów Slide zawierających treść) udostępnionej przez obiekt Presentation.
- Dodaj pusty slajd do prezentacji na koniec kolekcji slajdów zawartości, wywołując metodę AddEmptySlide udostępnioną przez obiekt ISlideCollection.
- Wykonaj pewne operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji przy użyciu obiektu [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/) .

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Czy mogę wstawić nowy slajd w określonej pozycji, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidecollection/insertclone/), dzięki czemu możesz dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motywy/style są zachowywane przy dodawaniu slajdu opartego na układzie?**

Tak. Układ dziedziczy formatowanie po swoim masterze, a nowy slajd dziedziczy po wybranym układzie oraz powiązanym z nim masterze.

**Jaki slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. Jest to ważne przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybierz [LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/layoutslide/), który odpowiada wymaganemu układowi ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pl/cpp/aspose.slides/slidelayouttype/)). Jeśli taki układ jest brakujący, możesz [dodać go do mastera](/slides/pl/cpp/slide-layout/) i następnie go użyć.