---
title: Układ slajdu
type: docs
weight: 20
url: /pl/python-java/examples/elements/layout-slide/
keywords:
- przykład kodu
- układ slajdu
- dodaj układ slajdu
- uzyskaj dostęp do układu slajdu
- usuń układ slajdu
- nieużywany układ slajdu
- klonuj układ slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj układami slajdów przy użyciu Aspose.Slides dla Pythona poprzez Java: dodawaj, uzyskuj dostęp, usuwaj, sprzątaj i klonuj układy w prezentacjach PowerPoint i OpenDocument."
---
Ten artykuł pokazuje, jak pracować z **układami slajdów** przy użyciu Aspose.Slides dla Pythona poprzez Java. Układ slajdu definiuje projekt i formatowanie dziedziczone przez zwykłe slajdy. Możesz dodawać, uzyskiwać dostęp, klonować i usuwać układy slajdów, a także usuwać nieużywane, aby zmniejszyć rozmiar prezentacji.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj układ slajdu**

Utwórz własny układ slajdu, aby zdefiniować formatowanie wielokrotnego użytku. Poniższy przykład dodaje pole tekstowe do nowego układu, a następnie tworzy dwa slajdy, które go używają.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)

    # Utwórz układ slajdu z pustym typem układu i niestandardową nazwą.
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Main layout")

    # Dodaj pole tekstowe do układu slajdu.
    layout_text_box = layout_slide.getShapes().addAutoShape(ShapeType.Rectangle, 75, 75, 150, 150)
    layout_text_box.getTextFrame().setText("Layout Slide Text")

    # Dodaj dwa slajdy, które dziedziczą tekst z układu.
    presentation.getSlides().addEmptySlide(layout_slide)
    presentation.getSlides().addEmptySlide(layout_slide)
finally:
    presentation.dispose()
```

> 💡 **Note 1:** Układy slajdów działają jako szablony dla poszczególnych slajdów. Możesz zdefiniować wspólne elementy raz i ponownie używać ich w wielu slajdach.

> 💡 **Note 2:** Gdy dodasz kształty lub tekst do układu slajdu, wszystkie slajdy oparte na tym układzie wyświetlają współdzieloną treść automatycznie.  
> Zrzut ekranu poniżej pokazuje dwa slajdy, które dziedziczą pole tekstowe z tego samego układu slajdu.

![Slajdy dziedziczące zawartość układu](layout-slide-result.png)

## **Uzyskaj dostęp do układu slajdu**

Uzyskaj dostęp do układów slajdów według indeksu lub typu układu, takiego jak pusty, tytułowy lub nagłówek sekcji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Uzyskaj dostęp do układu slajdu po indeksie.
    first_layout_slide = presentation.getLayoutSlides().get_Item(0)

    # Uzyskaj dostęp do układu slajdu po typie.
    blank_layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
finally:
    presentation.dispose()
```

## **Usuń układ slajdu**

Usuń konkretny układ slajdu, gdy nie jest już potrzebny.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Temporary layout")

    presentation.getLayoutSlides().remove(layout_slide)
finally:
    presentation.dispose()
```

## **Usuń nieużywane układy slajdów**

Usuń układy slajdów, które nie są używane przez żaden zwykły slajd, aby zmniejszyć rozmiar prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    presentation.getLayoutSlides().removeUnused()
finally:
    presentation.dispose()
```

## **Klonuj układ slajdu**

Zduplikuj układ slajdu i dodaj kopię na koniec kolekcji układów slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    master_slide = presentation.getMasters().get_Item(0)
    source_layout_slide = presentation.getLayoutSlides().add(master_slide, SlideLayoutType.Blank, "Source layout")

    cloned_layout_slide = presentation.getLayoutSlides().addClone(source_layout_slide)
finally:
    presentation.dispose()
```

> ✅ **Summary:** Układy slajdów pomagają utrzymać spójne formatowanie w całej prezentacji. Aspose.Slides umożliwia tworzenie, zarządzanie, ponowne użycie i czyszczenie układów w razie potrzeby.