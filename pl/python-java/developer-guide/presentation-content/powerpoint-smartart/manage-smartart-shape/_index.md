---
title: Zarządzanie grafikami SmartArt w prezentacjach przy użyciu Pythona
linktitle: Grafika SmartArt
type: docs
weight: 20
url: /pl/python-java/manage-smartart-shape/
keywords:
- Obiekt SmartArt
- Grafika SmartArt
- Styl SmartArt
- Kolor SmartArt
- Tworzenie SmartArt
- Dodawanie SmartArt
- Edycja SmartArt
- Zmiana SmartArt
- Dostęp do SmartArt
- Typ układu SmartArt
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Automatyzuj tworzenie, edycję i stylizację SmartArt w PowerPoint przy użyciu Pythona i Aspose.Slides, oferując krótkie przykłady kodu i wskazówki skoncentrowane na wydajności."
---
## **Przegląd**

Aspose.Slides umożliwia programowe tworzenie i zarządzanie grafikami SmartArt w prezentacjach PowerPoint. Ten artykuł wyjaśnia, jak dodać kształt SmartArt na slajdzie, uzyskać dostęp do istniejących kształtów SmartArt, znaleźć SmartArt o określonym typie układu oraz zaktualizować jego wygląd, zmieniając styl SmartArt lub styl kolorów.

Przykłady pokazują, jak pracować z kształtami SmartArt za pośrednictwem kolekcji kształtów slajdu prezentacji, sprawdzić, czy kształt jest SmartArt, a następnie modyfikować lub przeglądać jego właściwości.

## **Utworzenie kształtu SmartArt**
Aspose.Slides for Python via Java udostępnia API do tworzenia kształtów SmartArt. Aby utworzyć kształt SmartArt na slajdzie, wykonaj poniższe kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
2. Pobierz slajd według jego indeksu.
3. [Dodaj kształt SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addSmartArt) określając [SmartArtLayoutType](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartartlayouttype/).
4. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Zapisz prezentację.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt dodany do slajdu**|

## **Dostęp do kształtu SmartArt na slajdzie**
Poniższy przykład uzyskuje dostęp do kształtów SmartArt na slajdzie prezentacji. Iteruje przez każdy kształt na slajdzie i sprawdza, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Dostęp do kształtu SmartArt o określonym typie układu**
Poniższy przykład uzyskuje dostęp do kształtu [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/) o określonym typie układu, zwróconego przez [SmartArt.getLayout](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/#getLayout).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.
2. Pobierz pierwszy slajd według jego indeksu.
3. Iteruj przez każdy kształt na pierwszym slajdzie.
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).
5. Sprawdź, czy kształt SmartArt ma określony typ układu i wykonaj wymaganą operację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Sprawdź układ SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Zmiana stylu kształtu SmartArt**
Ten przykład pokazuje, jak zmienić szybki styl kształtu SmartArt.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.
2. Pobierz pierwszy slajd według jego indeksu.
3. Iteruj przez każdy kształt na pierwszym slajdzie.
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).
5. Znajdź kształt SmartArt o określonym stylu.
6. Ustaw nowy styl dla kształtu SmartArt.
7. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Przeglądaj każdy kształt na pierwszym slajdzie.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Sprawdź i zmień styl SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Rysunek: Kształt SmartArt ze zmienionym stylem**|

## **Zmiana stylu kolorów kształtu SmartArt**
Ten przykład uzyskuje dostęp do kształtu SmartArt o określonym stylu kolorów i zmienia ten styl.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) i wczytaj prezentację zawierającą kształt SmartArt.
2. Pobierz pierwszy slajd według jego indeksu.
3. Iteruj przez każdy kształt na pierwszym slajdzie.
4. Sprawdź, czy kształt jest instancją [SmartArt](https://reference.aspose.com/slides/pl/python-java/aspose.slides/smartart/).
5. Znajdź kształt SmartArt o określonym stylu kolorów.
6. Ustaw nowy styl kolorów dla kształtu SmartArt.
7. Zapisz prezentację.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpase.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Iteruj przez każdy kształt na pierwszym slajdzie.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Sprawdź i zmień styl SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Rysunek: Kształt SmartArt ze zmienionym stylem kolorów**|

## **FAQ**

**Czy mogę animować SmartArt jako pojedynczy obiekt?**

Tak. SmartArt jest kształtem, więc możesz zastosować [standardowe animacje](/slides/pl/python-java/powerpoint-animation/) za pośrednictwem API animacji (animacje wejścia, wyjścia, podkreślenia, ścieżki ruchu) tak jak w przypadku innych kształtów.

**Jak mogę znaleźć konkretny SmartArt na slajdzie, jeśli nie znam jego wewnętrznego ID?**

Ustaw i użyj [alternatywnego tekstu](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#setAlternativeText) oraz wyszukaj kształt według tej wartości — jest to zalecany sposób odnalezienia docelowego kształtu.

**Czy mogę grupować SmartArt z innymi kształtami?**

Tak. możesz grupować SmartArt z innymi kształtami (obrazkami, tabelami itp.), a następnie [manipulować grupą](/slides/pl/python-java/group/).

**Jak uzyskać obraz konkretnego SmartArt (np. do podglądu lub raportu)?**

Wyeksportuj miniaturę/obraz kształtu; biblioteka może [renderować pojedyncze kształty](/slides/pl/python-java/create-shape-thumbnails/) do plików rastrowych (PNG/JPG/TIFF).

**Czy wygląd SmartArt zostanie zachowany przy konwertowaniu całej prezentacji na PDF?**

Tak. Silnik renderujący dąży do wysokiej wierności przy [eksportowaniu do PDF](/slides/pl/python-java/convert-powerpoint-to-pdf/), oferując różnorodne opcje jakości i kompatybilności.