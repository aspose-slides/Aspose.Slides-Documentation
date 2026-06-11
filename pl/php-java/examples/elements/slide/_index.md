---
title: Slajd
type: docs
weight: 10
url: /pl/php-java/examples/elements/slide/
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
- PHP
- Aspose.Slides
description: "Zarządzaj slajdami w PHP przy użyciu Aspose.Slides: twórz, klonuj, zmieniaj kolejność, ukrywaj, ustawiaj tła i rozmiar, stosuj przejścia oraz eksportuj do PowerPoint i OpenDocument."
---
Ten artykuł zawiera szereg przykładów demonstrujących, jak pracować ze slajdami przy użyciu **Aspose.Slides for PHP via Java**. Dowiesz się, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy przy użyciu klasy `Presentation`.

Każdy przykład poniżej zawiera krótkie wyjaśnienie oraz fragment kodu w PHP.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw musisz wybrać układ. W tym przykładzie używamy układu `Blank` i dodajemy pusty slajd do prezentacji.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Każdy slajd opiera się na układzie, który sam jest oparty na master slajdzie.
        // Użyj układu Blank, aby utworzyć nowy slajd.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Dodaj nowy pusty slajd przy użyciu wybranego układu.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Wskazówka:** Każdy układ slajdu pochodzi z master slajdu, który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obrazek ilustruje, jak master slajdy i ich powiązane układy są zorganizowane w programie PowerPoint.

![Relacja master i układu](master-layout-slide.png)

## **Uzyskaj dostęp do slajdów według indeksu**

Możesz uzyskać dostęp do slajdów przy użyciu ich indeksu.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Uzyskaj dostęp do slajdu po indeksie.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Klonuj slajd**

Ten przykład pokazuje, jak sklonować istniejący slajd. Sklonowany slajd jest automatycznie dodawany na koniec kolekcji slajdów.

```php
function cloneSlide() {
    // Domyślnie prezentacja zawiera jeden pusty slajd.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Sklonuj pierwszy slajd; zostanie on dodany na koniec prezentacji.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Indeks sklonowanego slajdu to 1 (drugi slajd w prezentacji).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zmień kolejność slajdów**

Możesz zmienić kolejność slajdów, przenosząc jeden na nowy indeks. W tym przypadku przenosimy slajd na pierwszą pozycję.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Przesuń slajd na pierwszą pozycję (inne przesuwają się w dół).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń slajd**

Aby usunąć slajd, wystarczy odwołać się do niego i wywołać `remove`. Ten przykład usuwa slajdy według indeksu oraz według referencji.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Usuń slajd po indeksie.
        $presentation->getSlides()->removeAt(0);

        // Usuń slajd po referencji.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```