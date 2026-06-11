---
title: Slajd master
type: docs
weight: 30
url: /pl/python-net/examples/elements/master-slide/
keywords:
- slajd master
- dodaj slajd master
- dostęp do slajdu master
- usuń slajd master
- nieużywany slajd master
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Aspose.Slides
description: "Zarządzaj slajdami master w Pythonie przy użyciu Aspose.Slides: twórz, edytuj, klonuj i formatuj motywy, tła oraz znaczniki, aby ujednolicić slajdy w PowerPoint i OpenDocument."
---
Slajdy master tworzą najwyższy poziom hierarchii dziedziczenia slajdów w programie PowerPoint. **Slajd master** definiuje wspólne elementy projektu, takie jak tła, logotypy i formatowanie tekstu. **Slajdy układu** dziedziczą po slajdach master, a **zwykłe slajdy** dziedziczą po slajdach układu.

Ten artykuł pokazuje, jak tworzyć, modyfikować i zarządzać slajdami master przy użyciu Aspose.Slides for Python via .NET.

## **Dodaj slajd master**

Ten przykład pokazuje, jak utworzyć nowy slajd master poprzez sklonowanie domyślnego.

```py
def add_master_slide():
    with slides.Presentation() as presentation:

        # Sklonuj domyślny slajd master.
        default_master_slide = presentation.masters[0]
        new_master = presentation.masters.add_clone(default_master_slide)

        presentation.save("master_slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Wskazówka 1:** Slajdy master umożliwiają zastosowanie spójnej identyfikacji wizualnej lub wspólnych elementów projektu we wszystkich slajdach. Wszelkie zmiany wprowadzone w masterze będą automatycznie odzwierciedlane w zależnych slajdach układu i zwykłych slajdach.  
> 💡 **Wskazówka 2:** Wszystkie kształty lub formatowanie dodane do slajdu master są dziedziczone przez slajdy układu, a te z kolei przez wszystkie zwykłe slajdy korzystające z tych układów.  
> Obraz poniżej ilustruje, jak pole tekstowe dodane na slajdzie master jest automatycznie renderowane na ostatecznym slajdzie.

![Przykład dziedziczenia master](master-slide-banner.png)

## **Dostęp do slajdu master**

Możesz uzyskać dostęp do slajdów master przy użyciu kolekcji `Presentation.masters`. Oto jak je pobrać i pracować z nimi:

```py
def access_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:
        # Uzyskaj dostęp do pierwszego slajdu master.
        first_master_slide = presentation.masters[0]
```

## **Usuń slajd master**

Slajdy master można usunąć zarówno po indeksie, jak i po odwołaniu.

```py
def remove_master_slide():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Usuń według indeksu.
        presentation.masters.remove_at(0)

        # Lub usuń według referencji.
        first_master_slide = presentation.masters[0]
        presentation.masters.remove(first_master_slide)

        presentation.save("master_slide_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Usuń nieużywane slajdy master**

Niektóre prezentacje zawierają slajdy master, które nie są używane. Usunięcie tych slajdów może pomóc zmniejszyć rozmiar pliku.

```py
def remove_unused_master_slides():
    with slides.Presentation("master_slide.pptx") as presentation:

        # Usuń wszystkie nieużywane slajdy master (nawet te oznaczone jako Preserve).
        presentation.masters.remove_unused(True)

        presentation.save("master_slides_removed.pptx", slides.export.SaveFormat.PPTX)
```

> ⚙️ **Wskazówka:** Użyj `remove_unused(True)`, aby wyczyścić nieużywane slajdy master i zminimalizować rozmiar prezentacji.