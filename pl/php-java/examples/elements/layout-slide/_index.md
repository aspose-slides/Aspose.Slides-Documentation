---
title: Układ slajdu
type: docs
weight: 20
url: /pl/php-java/examples/elements/layout-slide/
keywords:
- układ slajdu
- dodaj układ slajdu
- uzyskaj dostęp do układu slajdu
- usuń układ slajdu
- nieużywany układ slajdu
- klonuj układ slajdu
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Użyj PHP do zarządzania układami slajdów w Aspose.Slides: twórz, stosuj, klonuj, zmieniaj nazwy oraz dostosowuj elementy zastępcze i motywy w prezentacjach w formatach PPT, PPTX i ODP."
---
Ten artykuł pokazuje, jak pracować z **Układami slajdów** w Aspose.Slides for PHP via Java. Układ slajdu definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać układy slajdów, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

## **Dodaj układ slajdu**

Możesz utworzyć własny układ slajdu, aby zdefiniować wielokrotnego użytku formatowanie. Na przykład możesz dodać pole tekstowe, które pojawia się na wszystkich slajdach korzystających z tego układu.

```php
function addLayoutSlide() {
    $presentation = new Presentation();
    try {
        $masterSlide = $presentation->getMasters()->get_Item(0);

        // Utwórz układ slajdu z pustym typem układu i własną nazwą.
        $layoutSlide = $presentation->getLayoutSlides()->add($masterSlide, SlideLayoutType::Blank, "Main layout");

        $presentation->save("layout_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Wskazówka 1:** Układy slajdów działają jako szablony dla poszczególnych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.

> 💡 **Wskazówka 2:** Gdy dodasz kształty lub tekst do układu slajdu, wszystkie slajdy oparte na tym układzie automatycznie wyświetlą tę współdzieloną treść.
> Poniższy zrzut ekranu pokazuje dwa slajdy, z których każdy dziedziczy pole tekstowe z tego samego układu slajdu.

![Slajdy dziedziczące układ slajdu](layout-slide-result.png)


## **Uzyskaj dostęp do układu slajdu**

Układy slajdów można uzyskać przez indeks lub typ układu (np. `Blank`, `Title`, `SectionHeader` itp.).

```php
function accessLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Dostęp przez indeks.
        $firstLayoutSlide = $presentation->getLayoutSlides()->get_Item(0);

        // Dostęp przez typ układu.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń układ slajdu**

Możesz usunąć konkretny układ slajdu, jeśli nie jest już potrzebny.

```php
function removeLayoutSlide() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Pobierz układ slajdu według typu i usuń go.
        $layoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Custom);
        $presentation->getLayoutSlides()->remove($layoutSlide);

        $presentation->save("layout_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń nieużywane układy slajdów**

Aby zmniejszyć rozmiar prezentacji, możesz usunąć układy slajdów, które nie są używane przez żadne zwykłe slajdy.

```php
function removeUnusedLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Automatycznie usuwa wszystkie układy slajdów, które nie są używane przez żaden slajd.
        $presentation->getLayoutSlides()->removeUnused();

        $presentation->save("layout_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Klonuj układ slajdu**

Możesz powielić układ slajdu za pomocą metody `addClone`.

```php
function cloneLayoutSlides() {
    $presentation = new Presentation("layout_slide.pptx");
    try {
        // Pobierz istniejący układ slajdu według typu.
        $blankLayoutSlide = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Sklonuj układ slajdu na koniec kolekcji układów slajdów.
        $clonedLayoutSlide = $presentation->getLayoutSlides()->addClone($blankLayoutSlide);

        $presentation->save("layout_slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ✅ **Podsumowanie:** Układy slajdów to potężne narzędzia do zarządzania spójnym formatowaniem w całej prezentacji. Aspose.Slides umożliwia pełną kontrolę nad tworzeniem, zarządzaniem i optymalizacją układów slajdów.