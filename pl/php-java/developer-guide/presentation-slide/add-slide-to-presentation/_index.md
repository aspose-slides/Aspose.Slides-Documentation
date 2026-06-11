---
title: Dodawanie slajdów do prezentacji w PHP
linktitle: Dodaj slajd
type: docs
weight: 10
url: /pl/php-java/add-slide-to-presentation/
keywords:
- dodaj slajd
- utwórz slajd
- pusty slajd
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Łatwo dodawaj slajdy do swoich prezentacji PowerPoint i OpenDocument przy użyciu Aspose.Slides for PHP via Java — płynne, efektywne wstawianie slajdów w ciągu kilku sekund."
---
## **Przegląd**

Aspose.Slides pozwala programowo dodawać slajdy do prezentacji PowerPoint. Prezentacja zawiera slajdy master/układ oraz zwykłe slajdy, a zwykłe slajdy są uporządkowane według indeksu zerowego. Każdy slajd ma unikalny identyfikator, a pliki prezentacji bez slajdów nie są obsługiwane.

Ten artykuł wyjaśnia, jak stworzyć obiekt `Presentation`, uzyskać jego kolekcję slajdów, dodać pusty slajd, pracować z nowo dodanym slajdem oraz zapisać zaktualizowaną prezentację. Omówione są także powiązane kwestie, takie jak wstawianie slajdów w określone miejsce, korzystanie z układów oraz zrozumienie pustego slajdu, który istnieje w nowo utworzonej prezentacji.

## **Dodaj slajd do prezentacji**

Zanim omówimy dodawanie slajdów do plików prezentacji, przedstawmy kilka faktów o slajdach. Każdy plik prezentacji PowerPoint zawiera **slajd Master / Layout** oraz inne **slajdy Normalne**. Oznacza to, że plik prezentacji zawiera co najmniej jeden slajd. Należy wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for PHP via Java. Każdy slajd ma unikalny Id, a wszystkie Normal Slides są uporządkowane według indeksu zerowego.

Aspose.Slides for PHP via Java umożliwia programistom dodawanie pustych slajdów do ich prezentacji. Aby dodać pusty slajd w prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
- Pobierz obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/) używając metody [getSlides](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation#getSlides--) (kolekcja obiektów Slide) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).
- Dodaj pusty slajd do prezentacji na końcu kolekcji slajdów zawartości, wywołując metodę [**addEmptySlide**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/#addEmptySlide) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/).
- Wykonaj operacje na nowo dodanym pustym slajdzie.
- Na koniec zapisz plik prezentacji przy użyciu obiektu [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/presentation).

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation();
  try {
    # Utwórz instancję klasy SlideCollection
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Dodaj pusty slajd do kolekcji Slides
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Wykonaj pewne operacje na nowo dodanym slajdzie
    # Zapisz plik PPTX na dysku
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Czy mogę wstawić nowy slajd w określonej pozycji, a nie tylko na końcu?**

Tak. Biblioteka obsługuje kolekcje slajdów oraz operacje [insert](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/insertclone/) , dzięki czemu możesz dodać slajd pod wymaganą indeksacją, a nie wyłącznie na końcu.

**Czy motywy/style są zachowywane przy dodawaniu slajdu na podstawie układu?**

Tak. Układ dziedziczy formatowanie z jego mastera, a nowy slajd dziedziczy po wybranym układzie i powiązanym z nim masterze.

**Jaki slajd znajduje się w nowej „pustej” prezentacji przed dodaniem slajdów?**

Nowo utworzona prezentacja już zawiera jeden pusty slajd o indeksie zero. Należy to uwzględnić przy obliczaniu indeksów wstawiania.

**Jak wybrać „odpowiedni” układ dla nowego slajdu, jeśli master ma wiele opcji?**

Zazwyczaj wybiera się [LayoutSlide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/layoutslide/) pasujący do wymaganego strukturalnie układu ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidelayouttype/)). Jeśli taki układ nie istnieje, możesz [add it to the master](/slides/pl/php-java/slide-layout/) i następnie go użyć.