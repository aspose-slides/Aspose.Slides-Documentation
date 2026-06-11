---
title: Dodawanie slajdów do prezentacji w .NET
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/net/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for .NET — płynne, efektywne wstawianie slajdów w kilka sekund."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie slajdów do prezentacji PowerPoint. Prezentacja zawiera slajdy master/layout oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu zerowego. Każdy slajd ma unikalny identyfikator, a pliki prezentacji bez slajdów nie są obsługiwane.

Ten artykuł wyjaśnia, jak utworzyć obiekt `Presentation`, uzyskać dostęp do jego kolekcji slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem i zapisać zaktualizowaną prezentację. Porusza również powiązane kwestie, takie jak wstawianie slajdów w określonej pozycji, używanie układów oraz zrozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Dodaj slajd do prezentacji**
Zanim przejdziemy do dodawania slajdów do plików prezentacji, omówmy kilka faktów dotyczących slajdów. Każdy plik prezentacji PowerPoint zawiera slajd Master / Layout oraz inne zwykłe slajdy. Oznacza to, że plik prezentacji zawiera co najmniej jeden slajd. Ważne jest, aby wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for .NET. Każdy slajd ma unikalny Id, a wszystkie zwykłe slajdy są uporządkowane w kolejności określonej przez indeks zerowy. Aspose.Slides for .NET umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd do prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
- Zainicjuj klasę [ISlideCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/islidecollection), ustawiając referencję do właściwości Slides (kolekcja obiektów Slide) udostępnionej przez obiekt Presentation.
- Dodaj pusty slajd do prezentacji na końcu kolekcji slajdów zawartości, wywołując metodę AddEmptySlide udostępnioną przez obiekt ISlideCollection.
- Wykonaj operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji za pomocą obiektu [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **FAQ**

**Czy mogę wstawić nowy slajd w określonej pozycji, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pl/net/aspose.slides/slidecollection/insertclone/), dzięki czemu możesz dodać slajd pod wymaganym indeksem, a nie tylko na końcu.

**Czy motyw/style są zachowywane przy dodawaniu slajdu na podstawie układu?**

Tak. Układ dziedziczy formatowanie z swojego mastera, a nowy slajd dziedziczy po wybranym układzie oraz powiązanym z nim masterze.

**Jaki slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. To ważne przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybierz [LayoutSlide](https://reference.aspose.com/slides/pl/net/aspose.slides/layoutslide/), który pasuje do wymaganego układu ([Title and Content, Two Content, itp.](https://reference.aspose.com/slides/pl/net/aspose.slides/slidelayouttype/)). Jeśli taki układ jest nieobecny, możesz [dodaj go do mastera](/slides/pl/net/slide-layout/) i następnie go użyć.