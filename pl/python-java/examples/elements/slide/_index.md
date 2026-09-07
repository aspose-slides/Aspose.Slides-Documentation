---
title: Slajd
type: docs
weight: 10
url: /pl/python-java/examples/elements/slide/
keywords:
- przykład kodu
- slajd
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Zarządzaj slajdami w Aspose.Slides for Python via Java: dodawaj, uzyskuj dostęp, klonuj, zmieniaj kolejność i usuwaj slajdy przy użyciu przykładów kodu w Pythonie dla prezentacji PowerPoint i OpenDocument."
---
Ten artykuł zawiera przykłady demonstrujące, jak dodawać, uzyskiwać dostęp, klonować, zmieniać kolejność i usuwać slajdy przy użyciu **Aspose.Slides for Python via Java**.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj slajd**

Aby dodać nowy slajd, najpierw wybierz układ. Ten przykład używa pustego układu, aby dodać pusty slajd do prezentacji.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    presentation.getSlides().addEmptySlide(blank_layout)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Każdy układ slajdu jest pochodną slajdu-mistrza, który definiuje ogólny projekt i strukturę pól zastępczych. Poniższy obrazek ilustruje, jak slajdy-mistrze i ich powiązane układy są zorganizowane w programie PowerPoint.
{{% /alert %}}

![Relacja między slajdem-mistrzem a układem](master-layout-slide.png)

## **Dostęp do slajdów według indeksu**

Uzyskaj dostęp do slajdów używając ich indeksu zerowego lub znajdź indeks slajdu na podstawie odwołania. Jest to przydatne przy iteracji lub modyfikacji konkretnych slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpython.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Dodaj kolejny pusty slajd.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Uzyskaj dostęp do slajdów według indeksu.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Pobierz indeks slajdu z odwołania, a potem uzyskaj dostęp do niego według indeksu.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Klonowanie slajdu**

Sklonuj istniejący slajd. Sklonowany slajd jest automatycznie dodawany na koniec kolekcji slajdów.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    cloned_slide_index = presentation.getSlides().indexOf(cloned_slide)
finally:
    presentation.dispose()
```

## **Zmiana kolejności slajdów**

Zmień kolejność slajdów, przenosząc jeden na nowy indeks. Ten przykład przenosi sklonowany slajd na pierwszą pozycję.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)

    cloned_slide = presentation.getSlides().addClone(first_slide)

    presentation.getSlides().reorder(0, cloned_slide)
finally:
    presentation.dispose()
```

## **Usuwanie slajdu**

Usuń slajd, przekazując jego odwołanie do kolekcji slajdów. Ten przykład dodaje drugi slajd, a następnie usuwa pierwotny, pozostawiając tylko nowy.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    second_slide = presentation.getSlides().addEmptySlide(blank_layout)

    first_slide = presentation.getSlides().get_Item(0)
    presentation.getSlides().remove(first_slide)
finally:
    presentation.dispose()
```