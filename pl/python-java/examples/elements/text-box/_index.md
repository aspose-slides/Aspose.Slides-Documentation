---
title: Pole tekstowe
type: docs
weight: 40
url: /pl/python-java/examples/elements/text-box/
keywords:
- przykład kodu
- pole tekstowe
- PowerPoint
- OpenDocument
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Pracuj z polami tekstowymi w Aspose.Slides for Python via Java: dodawaj, formatuj, wyszukuj i usuwaj tekst w prezentacjach PowerPoint i OpenDocument."
---
W **Aspose.Slides for Python via Java**, pole tekstowe jest automatycznym kształtem zawierającym tekst. Prawie każdy kształt może zawierać tekst, ale typowe pole tekstowe nie ma wypełnienia ani obramowania i wyświetla tylko tekst.

Ten przewodnik wyjaśnia, jak programowo dodawać, uzyskiwać dostęp i usuwać pola tekstowe.

Zainstaluj pakiet zgodnie z opisem w [Installation](/slides/pl/python-java/installation/). Każdy przykład importuje `asposeslides` przed uruchomieniem JVM, a następnie importuje API po uruchomieniu JVM.

## **Dodaj pole tekstowe**

Utwórz prostokąt, usuń jego wypełnienie i obramowanie oraz przypisz sformatowany tekst.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    # Utwórz kształt prostokąta.
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)

    # Usuń wypełnienie i obramowanie, aby wyświetlać tylko tekst.
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

    # Ustaw domyślne formatowanie tekstu.
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    text_format = paragraph.getParagraphFormat().getDefaultPortionFormat()
    text_format.getFillFormat().setFillType(FillType.Solid)
    text_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

    text_box.getTextFrame().setText("Some text...")
finally:
    presentation.dispose()
```

## **Uzyskaj dostęp do pól tekstowych według zawartości**

Dodaj przykładowe pole tekstowe, a następnie znajdź kształty, których tekst zawiera słowo kluczowe "Slide".

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                # Użyj pasującego pola tekstowego.
                print(text_frame.getText())
finally:
    presentation.dispose()
```

## **Usuń pola tekstowe według zawartości**

Znajdź i usuń pola tekstowe na pierwszym slajdzie, które zawierają określone słowo kluczowe.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, ShapeType, FillType, AutoShape

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    text_box = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 75, 150, 100)
    text_box.getFillFormat().setFillType(FillType.NoFill)
    text_box.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
    text_box.getTextFrame().setText("Slide notes")

    shapes_to_remove = []
    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if isinstance(shape, AutoShape):
            text_frame = shape.getTextFrame()
            if text_frame is not None and "Slide" in str(text_frame.getText()):
                shapes_to_remove.append(shape)

    for shape in shapes_to_remove:
        slide.getShapes().remove(shape)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
Zbierz pasujące kształty w osobnej liście przed ich usunięciem, aby uniknąć modyfikacji kolekcji kształtów podczas iteracji.
{{% /alert %}}