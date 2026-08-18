---
title: Klonowanie slajdów prezentacji w PHP
linktitle: Klonuj slajdy
type: docs
weight: 35
url: /pl/php-java/clone-slides/
keywords:
- klonuj slajd
- kopiuj slajd
- zapisz slajd
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Szybko duplikuj slajdy PowerPoint przy użyciu Aspose.Slides for PHP. Skorzystaj z naszych przejrzystych przykładów kodu, aby w kilka sekund zautomatyzować tworzenie PPT i wyeliminować ręczną pracę."
---
## **Wstęp**

Klonowanie to proces tworzenia dokładnej kopii lub repliki czegoś. Aspose.Slides for PHP via Java umożliwia także wykonanie kopii lub klonu dowolnego slajdu, a następnie wstawienie tego sklonowanego slajdu do bieżącej lub dowolnej innej otwartej prezentacji. Proces klonowania slajdu tworzy nowy slajd, który może być modyfikowany przez programistów bez zmieniania pierwotnego slajdu. Istnieje kilka możliwych sposobów klonowania slajdu:

- Klonowanie na końcu w obrębie prezentacji.
- Klonowanie w innym miejscu w obrębie prezentacji.
- Klonowanie na końcu w innej prezentacji.
- Klonowanie w innym miejscu w innej prezentacji.
- Klonowanie w określonej pozycji w innej prezentacji.

W Aspose.Slides for PHP via Java, (kolekcja obiektów [Slide](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Slide) ) udostępniona przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zapewnia metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) i [insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#insertClone), aby wykonać powyższe rodzaje klonowania slajdów

## **Klonowanie slajdu na końcu prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji na końcu istniejących slajdów, użyj metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) zgodnie z poniższymi krokami:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) odwołując się do kolekcji slajdów udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) i przekaż slajd do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone).
1. Zapisz zmodyfikowany plik prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na pierwszej pozycji – indeks zero – prezentacji) na koniec prezentacji.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Zapisz zmodyfikowaną prezentację na dysku
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klonowanie slajdu do innej pozycji w obrębie prezentacji**
Jeśli chcesz sklonować slajd i następnie użyć go w tym samym pliku prezentacji, lecz w innej pozycji, użyj metody [insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#insertClone):

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Uzyskaj obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection) odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation).
1. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#insertClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) i przekaż slajd do sklonowania wraz z indeksem nowej pozycji jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#insertClone).
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

W poniższym przykładzie sklonowaliśmy slajd (znajdujący się na indeksie zero – pozycja 1 – prezentacji) do indeksu 1 – pozycja 2 – prezentacji.

```php
  # Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Sklonuj wybrany slajd na koniec kolekcji slajdów w tej samej prezentacji
    $slds = $pres->getSlides();
    # Sklonuj wybrany slajd w określonym indeksie w tej samej prezentacji
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Zapisz zmodyfikowaną prezentację na dysku
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Klonowanie slajdu na końcu innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innym pliku prezentacji, na końcu istniejących slajdów:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierającą prezentację, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierającą docelową prezentację, do której slajd zostanie dodany.
1. Uzyskaj obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection) odwołując się do kolekcji [**Slides**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) udostępnionej przez obiekt Presentation docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) i przekaż slajd z prezentacji źródłowej jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z pierwszego indeksu prezentacji źródłowej) na koniec docelowej prezentacji.

```php
  # Utwórz instancję klasy Presentation w celu załadowania pliku prezentacji źródłowej
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany)
    $destPres = new Presentation();
    try {
      # Sklonuj wybrany slajd ze źródłowej prezentacji na koniec kolekcji slajdów w prezentacji docelowej
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Zapisz docelową prezentację na dysku
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klonowanie slajdu do innej pozycji w innej prezentacji**
Jeśli musisz sklonować slajd z jednej prezentacji i użyć go w innym pliku prezentacji, w określonej pozycji:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierającą prezentację źródłową, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierającą prezentację, do której slajd zostanie dodany.
1. Uzyskaj klasę [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) odwołując się do kolekcji Slides udostępnionej przez obiekt Presentation docelowej prezentacji.
1. Wywołaj metodę [insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#insertClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) i przekaż slajd z prezentacji źródłowej wraz z żądaną pozycją jako parametr do metody [insertClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#insertClone).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd (z indeksu zero prezentacji źródłowej) do indeksu 1 (pozycja 2) docelowej prezentacji.

```php
  # Utwórz instancję klasy Presentation w celu załadowania pliku prezentacji źródłowej
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Utwórz instancję klasy Presentation dla docelowego PPTX (gdzie slajd ma być sklonowany)
    $destPres = new Presentation();
    try {
      # Sklonuj wybrany slajd ze źródłowej prezentacji na koniec kolekcji slajdów w prezentacji docelowej
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Zapisz docelową prezentację na dysku
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klonowanie slajdu w określonej pozycji w innej prezentacji**
Jeśli musisz sklonować slajd wraz z master slajdem z jednej prezentacji i użyć go w innej prezentacji, najpierw musisz sklonować żądany master slajd z prezentacji źródłowej do docelowej. Następnie musisz użyć tego master slajdu do klonowania slajdu z masterem. Metoda [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/pl/php-java/aspose.slides/slidecollection/addclone/) oczekuje master slajdu z docelowej prezentacji, a nie ze źródłowej. Aby sklonować slajd z masterem, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierającą prezentację źródłową, z której slajd zostanie sklonowany.
1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) zawierającą docelową prezentację, do której slajd zostanie sklonowany.
1. Uzyskaj dostęp do slajdu, który ma być sklonowany, wraz z master slajdem.
1. Utwórz instancję klasy [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MasterSlideCollection) odwołując się do kolekcji Masters udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) udostępnioną przez obiekt [MasterSlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/MasterSlideCollection) i przekaż master z źródłowego PPTX do sklonowania jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone).
1. Utwórz instancję klasy [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) ustawiając odwołanie do kolekcji Slides udostępnionej przez obiekt [Presentation](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation) docelowej prezentacji.
1. Wywołaj metodę [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) udostępnioną przez obiekt [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/Presentation/#getSlides) i przekaż slajd z prezentacji źródłowej do sklonowania oraz master slajd jako parametr do metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone).
1. Zapisz zmodyfikowany plik docelowej prezentacji.

W poniższym przykładzie sklonowaliśmy slajd z masterem (znajdujący się na indeksie zero w prezentacji źródłowej) na koniec docelowej prezentacji, używając mastera ze slajdu źródłowego.

```php
  # Utwórz instancję klasy Presentation w celu załadowania pliku prezentacji źródłowej
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Utwórz instancję klasy Presentation dla dokumentu docelowego (gdzie slajd ma być sklonowany)
    $destPres = new Presentation();
    try {
      # Utwórz obiekt ISlide z kolekcji slajdów w prezentacji źródłowej wraz z
      # slajdem master
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Sklonuj wybrany slajd master z prezentacji źródłowej do kolekcji masterów w
      # prezentacji docelowej
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Sklonuj wybrany slajd master z prezentacji źródłowej do kolekcji masterów w
      # prezentacji docelowej
      $iSlide = $masters->addClone($SourceMaster);
      # Sklonuj wybrany slajd z prezentacji źródłowej z wybranym masterem na koniec
      # kolekcji slajdów w prezentacji docelowej
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Zapisz docelową prezentację na dysku
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Klonowanie slajdu na końcu określonej sekcji**
Jeśli chcesz sklonować slajd i następnie użyć go w tej samej prezentacji, ale w innej sekcji, użyj metody [addClone](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection/#addClone) udostępnionej przez klasę [SlideCollection](https://reference.aspose.com/slides/pl/php-java/aspose.slides/SlideCollection). Aspose.Slides for PHP via Java umożliwia sklonowanie slajdu z pierwszej sekcji i wstawienie tego sklonowanego slajdu do drugiej sekcji tej samej prezentacji.

Poniższy fragment kodu pokazuje, jak sklonować slajd i wstawić sklonowany slajd do określonej sekcji.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Zapisz docelową prezentację na dysku
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Zapewnienie dopasowanego rozmiaru slajdu**

Podczas klonowania slajdów do innej prezentacji upewnij się, że prezentacja docelowa ma taki sam rozmiar slajdu jak źródłowa. Jeśli rozmiary slajdów różnią się, Aspose.Slides nie przeskalowuje automatycznie sklonowanych kształtów — ich pierwotne współrzędne i wymiary są zachowane, co może spowodować, że zawartość będzie nieprawidłowo wyrównana lub wyjdzie poza granice slajdu.

Możesz ustawić rozmiar slajdu prezentacji docelowej tak, aby odpowiadał źródłowemu przed klonowaniem mastera i slajdu:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Zrób to przed klonowaniem mastera i slajdu.

## **FAQ**

**Czy notatki prelegenta i komentarze recenzentów są klonowane?**

Tak. Strona z notatkami i komentarze recenzji są uwzględnione w klonie. Jeśli ich nie chcesz, [usuń je](/slides/pl/php-java/presentation-notes/) po wstawieniu.

**Jak obsługiwane są wykresy i ich źródła danych?**

Obiekt wykresu, formatowanie i osadzone dane są kopiowane. Jeśli wykres był połączony z zewnętrznym źródłem (np. osadzonym skoroszytem OLE), to połączenie jest zachowane jako [obiekt OLE](/slides/pl/php-java/manage-ole/). Po przeniesieniu między plikami sprawdź dostępność danych i zachowanie odświeżania.

**Czy mogę kontrolować pozycję wstawiania i sekcje dla klonu?**

Tak. Możesz wstawić klon na określony indeks slajdu i umieścić go w wybranej [sekcji](/slides/pl/php-java/slide-section/). Jeśli docelowa sekcja nie istnieje, najpierw ją utwórz, a następnie przenieś slajd do niej.