---
title: Slajd główny
type: docs
weight: 30
url: /pl/php-java/examples/elements/master-slide/
keywords:
- slajd główny
- dodaj slajd główny
- dostęp do slajdu głównego
- usuń slajd główny
- nieużywany slajd główny
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Zarządzaj slajdami głównymi w PHP przy użyciu Aspose.Slides: twórz, edytuj, klonuj i formatuj motywy, tła, elementy zastępcze, aby ujednolicić slajdy w PowerPoint i OpenDocument."
---
Slajdy główne tworzą najwyższy poziom hierarchii dziedziczenia slajdów w PowerPoint. **Slajd główny** definiuje wspólne elementy projektu, takie jak tła, loga i formatowanie tekstu. **Slajdy układu** dziedziczą po slajdach głównych, a **zwykłe slajdy** dziedziczą po slajdach układu.

Ten artykuł demonstruje, jak tworzyć, modyfikować i zarządzać slajdami głównymi przy użyciu Aspose.Slides dla PHP via Java.

## **Add a Master Slide**

Ten przykład pokazuje, jak utworzyć nowy slajd główny, klonując domyślny.

```php
function addMasterSlide() {
    $presentation = new Presentation();
    try {
        // Sklonuj domyślny slajd główny.
        $defaultMasterSlide = $presentation->getMasters()->get_Item(0);
        $newMasterSlide = $presentation->getMasters()->addClone($defaultMasterSlide);

        $presentation->save("master_slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tip 1:** Slajdy główne umożliwiają zastosowanie spójnej identyfikacji wizualnej lub wspólnych elementów projektu na wszystkich slajdach. Wszelkie zmiany wprowadzone w slajdzie głównym będą automatycznie odzwierciedlane w zależnych slajdach układu i zwykłych slajdach.
> 
> 💡 **Tip 2:** Wszystkie kształty lub formatowanie dodane do slajdu głównego są dziedziczone przez slajdy układu, a następnie przez wszystkie zwykłe slajdy korzystające z tych układów.  
> Poniższy obraz ilustruje, jak pole tekstowe dodane na slajdzie głównym jest automatycznie renderowane na końcowym slajdzie.

![Przykład dziedziczenia slajdu](master-slide-banner.png)

## **Access a Master Slide**

Możesz uzyskać dostęp do slajdów głównych, używając metody `Presentation::getMasters`. Oto jak je pobrać i pracować z nimi:

```php
function accessMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Uzyskaj dostęp do pierwszego slajdu głównego.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove a Master Slide**

Slajdy główne można usunąć zarówno według indeksu, jak i odwołania.

```php
function removeMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Usuń według indeksu.
        $presentation->getMasters()->removeAt(0);

        // Lub usuń według odwołania.
        $firstMasterSlide = $presentation->getMasters()->get_Item(0);
        $presentation->getMasters()->remove($firstMasterSlide);

        $presentation->save("master_slide_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove Unused Master Slides**

Niektóre prezentacje zawierają slajdy główne, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```php
function removeUnusedMasterSlide() {
    $presentation = new Presentation("master_slide.pptx");
    try {
        // Usuń wszystkie nieużywane slajdy główne (nawet te oznaczone jako Preserve).
        $presentation->getMasters()->removeUnused(true);

        $presentation->save("master_slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> ⚙️ **Tip:** Użyj `removeUnused(true)`, aby usunąć nieużywane slajdy główne i zminimalizować rozmiar prezentacji.