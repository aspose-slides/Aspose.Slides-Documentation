---
title: Grupowe kształty prezentacji w Pythonie przy użyciu Java
linktitle: Grupa Kształtów
type: docs
weight: 40
url: /pl/python-java/group/
keywords:
- grupowy kształt
- grupa kształtów
- dodaj grupę
- tekst alternatywny
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Dowiedz się, jak grupować i rozgrupowywać kształty w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona poprzez Java — krok po kroku z darmowym kodem w Pythonie."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z grupowymi kształtami w Aspose.Slides. Pokazuje, jak dodać grupowy kształt do slajdu, umieścić w nim kształty i zapisać zaktualizowaną prezentację. Demonstratuje również, jak uzyskać dostęp do kształtów przechowywanych w grupie i odczytać ich alternatywny tekst przy użyciu [getAlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText). Dodatkowo artykuł krótko opisuje powiązane możliwości grupowych kształtów, takie jak grupy zagnieżdżone, kolejność Z i opcje blokowania.

## **Dodaj grupowy kształt**

Aspose.Slides obsługuje pracę z grupowymi kształtami na slajdach. Ta funkcja pomaga programistom tworzyć bogatsze prezentacje. Aspose.Slides for Python via Java wspiera dodawanie i dostęp do grupowych kształtów. Możesz wypełnić grupowy kształt innymi kształtami lub uzyskać dostęp do jego właściwości. Aby dodać grupowy kształt do slajdu przy użyciu Aspose.Slides for Python via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Dodaj grupowy kształt do slajdu.
1. Dodaj kształty do grupowego kształtu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ShapeFrame, ShapeType

# Utwórz instancję klasy Presentation.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Uzyskaj dostęp do kolekcji kształtów slajdu.
    slide_shapes = slide.getShapes()

    # Dodaj grupowy kształt do slajdu.
    group_shape = slide_shapes.addGroupShape()

    # Dodaj kształty wewnątrz grupowego kształtu.
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 100, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 300, 300, 100, 100)
    group_shape.getShapes().addAutoShape(ShapeType.Rectangle, 500, 300, 100, 100)

    # Ustaw ramkę grupowego kształtu.
    group_frame = ShapeFrame(100, 300, 500, 40, NullableBool.False_, NullableBool.False_, 0)
    group_shape.setFrame(group_frame)

    # Zapisz plik PPTX na dysku.
    presentation.save("GroupShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Dostęp do alternatywnego tekstu**

Ta sekcja pokazuje, jak uzyskać dostęp do alternatywnego tekstu kształtów wewnątrz grupy na slajdzie. Aby uzyskać dostęp do tego tekstu przy użyciu Aspose.Slides for Python via Java:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/) reprezentującej plik PPTX.
1. Uzyskaj odwołanie do slajdu według jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu.
1. Uzyskaj dostęp do grupowego kształtu.
1. Odczytaj alternatywny tekst jego kształtów przy użyciu [getAlternativeText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getAlternativeText).

Poniższy przykład uzyskuje dostęp do alternatywnego tekstu kształtów wewnątrz grupy:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GroupShape, Presentation

# Utwórz instancję klasy Presentation reprezentującej plik PPTX.
presentation = Presentation("AltText.pptx")
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    for i in range(slide.getShapes().size()):
        # Uzyskaj dostęp do kształtu w kolekcji kształtów slajdu.
        shape = slide.getShapes().get_Item(i)

        if isinstance(shape, GroupShape):
            # Uzyskaj dostęp do kształtów wewnątrz grupy.
            for j in range(shape.getShapes().size()):
                child_shape = shape.getShapes().get_Item(j)

                # Odczytaj tekst alternatywny.
                print(child_shape.getAlternativeText())
finally:
    presentation.dispose()
```

## **FAQ**

**Czy grupowanie zagnieżdżone (grupa wewnątrz grupy) jest obsługiwane?**

Tak. [GroupShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshape/) posiada metodę [getParentGroup](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getParentGroup), co wskazuje na obsługę hierarchii: grupa może być dzieckiem innej grupy.

**Jak kontrolować kolejność Z grupy względem innych obiektów na slajdzie?**

Użyj metody [getZOrderPosition](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shape/#getZOrderPosition) obiektu [GroupShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshape/), aby sprawdzić jego pozycję w stosie wyświetlania.

**Czy mogę zapobiec przenoszeniu, edycji lub rozgrupowywaniu?**

Tak. Blokady grupy są udostępniane poprzez [getGroupShapeLock](https://reference.aspose.com/slides/pl/python-java/aspose.slides/groupshape/#getGroupShapeLock), co pozwala ograniczyć operacje na obiekcie.