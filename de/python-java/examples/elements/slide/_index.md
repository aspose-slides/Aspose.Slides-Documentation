---
title: Folie
type: docs
weight: 10
url: /de/python-java/examples/elements/slide/
keywords:
- Codebeispiel
- Folie
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Java
- Aspose.Slides
description: "Verwalten Sie Folien in Aspose.Slides für Python via Java: Hinzufügen, Zugreifen, Duplizieren, Neuordnen und Entfernen von Folien mit Python-Codebeispielen für PowerPoint- und OpenDocument-Präsentationen."
---
Dieser Artikel liefert Beispiele, die zeigen, wie man Folien mit **Aspose.Slides for Python via Java** hinzufügt, darauf zugreift, dupliziert, neu anordnet und entfernt.

Installieren Sie das Paket wie in [Installation](/slides/de/python-java/installation/) beschrieben. Jeder Beispielcode importiert `asposeslides`, bevor die JVM gestartet wird, und importiert anschließend die API, nachdem die JVM läuft.

## **Folie hinzufügen**

Um eine neue Folie hinzuzufügen, wählen Sie zunächst ein Layout aus. Dieses Beispiel verwendet ein leeres Layout, um der Präsentation eine leere Folie hinzuzufügen.

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
Jedes Folienlayout leitet sich von einer Masterfolie ab, die das Gesamtdesign und die Platzhalterstruktur definiert. Das Bild unten zeigt, wie Masterfolien und ihre zugehörigen Layouts in PowerPoint organisiert sind.
{{% /alert %}}

![Beziehung zwischen Master und Layout](master-layout-slide.png)

## **Zugriff auf Folien nach Index**

Greifen Sie auf Folien über deren nullbasierte Indexnummer zu oder ermitteln Sie den Index einer Folie anhand einer Referenz. Das ist nützlich, um durch Folien zu iterieren oder bestimmte Folien zu ändern.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideLayoutType

presentation = Presentation()
try:
    # Füge eine weitere leere Folie hinzu.
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)
    presentation.getSlides().addEmptySlide(blank_layout)

    # Greife auf Folien nach Index zu.
    first_slide = presentation.getSlides().get_Item(0)
    second_slide = presentation.getSlides().get_Item(1)

    # Erhalte den Index einer Folie aus einer Referenz und greife dann per Index darauf zu.
    second_slide_index = presentation.getSlides().indexOf(second_slide)
    second_slide_by_index = presentation.getSlides().get_Item(second_slide_index)
finally:
    presentation.dispose()
```

## **Folie duplizieren**

Duplizieren Sie eine vorhandene Folie. Die duplizierte Folie wird automatisch am Ende der Folienkollektion eingefügt.

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

## **Folien neu anordnen**

Ändern Sie die Reihenfolge der Folien, indem Sie eine Folie auf einen neuen Index verschieben. Dieses Beispiel verschiebt eine duplizierte Folie an die erste Position.

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

## **Folie entfernen**

Entfernen Sie eine Folie, indem Sie ihre Referenz an die Folienkollektion übergeben. Dieses Beispiel fügt eine zweite Folie hinzu und entfernt anschließend die ursprüngliche, sodass nur noch die neue übrig bleibt.

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