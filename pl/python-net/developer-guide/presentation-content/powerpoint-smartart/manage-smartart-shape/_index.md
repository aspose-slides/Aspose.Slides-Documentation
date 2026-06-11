---
title: Zarządzaj grafikami SmartArt w prezentacjach przy użyciu Pythona
linktitle: Grafiki SmartArt
type: docs
weight: 20
url: /pl/python-net/manage-smartart-shape/
keywords:
- obiekt SmartArt
- grafika SmartArt
- styl SmartArt
- kolor SmartArt
- tworzenie SmartArt
- dodawanie SmartArt
- edycja SmartArt
- modyfikacja SmartArt
- dostęp do SmartArt
- typ układu SmartArt
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Automatyzuj tworzenie, edytowanie i stylizowanie grafiki SmartArt w PowerPoint przy użyciu Pythona via .NET z Aspose.Slides, oferując zwięzłe przykłady kodu i wskazówki skoncentrowane na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt do slajdu, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt za pośrednictwem kolekcji kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub sprawdzać jego właściwości.

## **Utworzenie kształtów SmartArt**

Aspose.Slides for Python via .NET umożliwia dodawanie własnych kształtów SmartArt do slajdów od podstaw. API ułatwia to. Aby dodać kształt SmartArt do slajdu:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/).
2. Uzyskaj docelowy slajd według jego indeksu.
3. Dodaj kształt SmartArt, określając jego typ układu.
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Utwórz instancję klasy Presentation.
with slides.Presentation() as presentation:
    # Uzyskaj dostęp do slajdu prezentacji.
    slide = presentation.slides[0]
    # Dodaj kształt SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Zapisz prezentację na dysku.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Dostęp do kształtów SmartArt na slajdach**

Poniższy kod demonstruje, jak uzyskać dostęp do kształtów SmartArt na slajdzie. Przykład iteruje po każdym kształcie na slajdzie i sprawdza, czy jest on obiektem [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/).

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Załaduj plik prezentacji.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in presentation.slides[0].shapes:
        # Sprawdź, czy kształt jest kształtem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Wypisz nazwę kształtu.
            print("Shape name:", shape.name)
```

## **Dostęp do kształtów SmartArt z określonym typem układu**

Poniższy przykład pokazuje, jak uzyskać dostęp do kształtu SmartArt o określonym typie układu. Należy pamiętać, że nie można zmienić typu układu SmartArt — jest on tylko do odczytu i jest ustalany w momencie tworzenia kształtu.

1. Utwórz instancję [Presentation](https://reference.aspose.com/slides/pl/python-net/aspose.slides/presentation/) i załaduj prezentację zawierającą kształt SmartArt.
2. Uzyskaj odwołanie do pierwszego slajdu według indeksu.
3. Iteruj po każdym kształcie na pierwszym slajdzie.
4. Sprawdź, czy kształt jest obiektem [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/).
5. Jeśli typ układu kształtu SmartArt odpowiada potrzebnemu, wykonaj wymagane działania.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in presentation.slides[0].shapes:
        # Sprawdź, czy kształt jest kształtem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Sprawdź typ układu SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```

## **Zmienianie stylu kształtu SmartArt**

Poniższy przykład pokazuje, jak znaleźć kształty SmartArt i zmienić ich styl:

1. Utwórz [Presentation] i załaduj plik zawierający kształt(y) SmartArt.
2. Uzyskaj odwołanie do pierwszego slajdu według indeksu.
3. Iteruj po każdym kształcie na pierwszym slajdzie.
4. Znajdź kształt SmartArt o określonym stylu.
5. Przypisz nowy styl do kształtu SmartArt.
6. Zapisz prezentację.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in presentation.slides[0].shapes:
        # Sprawdź, czy kształt jest kształtem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Sprawdź styl SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Zmień styl SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Zapisz prezentację.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Zmienianie stylu kolorów kształtów SmartArt**

Ten przykład pokazuje, jak zmienić styl kolorów kształtu SmartArt. Przykładowy kod znajduje kształt SmartArt o określonym stylu kolorów i aktualizuje go.

1. Utwórz instancję [Presentation] i załaduj prezentację zawierającą kształt(y) SmartArt.
2. Uzyskaj odwołanie do pierwszego slajdu według indeksu.
3. Iteruj po każdym kształcie na pierwszym slajdzie.
4. Sprawdź, czy kształt jest obiektem [SmartArt](https://reference.aspose.com/slides/pl/python-net/aspose.slides.smartart/smartart/).
5. Zlokalizuj kształt SmartArt o określonym stylu kolorów.
6. Ustaw nowy styl kolorów dla tego kształtu SmartArt.
7. Zapisz prezentację.

```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in presentation.slides[0].shapes:
        # Sprawdź, czy kształt jest kształtem SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Sprawdź typ koloru.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Zmień typ koloru.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Zapisz prezentację.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/python-net/powerpoint-animation/) za pomocą API animacji (wejścia, wyjścia, podkreślenia, ścieżki ruchu) tak samo jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego ID?**

Ustaw i użyj tekstu alternatywnego (AltText) oraz wyszukaj kształt po tej wartości — jest to zalecany sposób lokalizowania docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. Możesz grupować SmartArt z innymi kształtami (obrazami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/python-net/group/).

**Jak mogę uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturę/obraz kształtu; biblioteka może [renderować poszczególne kształty](/slides/pl/python-net/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwertowaniu całej prezentacji do PDF?**

Tak. Silnik renderujący dąży do wysokiej wierności przy [eksport PDF](/slides/pl/python-net/convert-powerpoint-to-pdf/), oferując szereg opcji jakości i zgodności.