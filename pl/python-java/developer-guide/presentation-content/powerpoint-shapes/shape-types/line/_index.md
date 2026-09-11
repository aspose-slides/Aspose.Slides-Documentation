---
title: Dodawanie kształtów linii do prezentacji w Pythonie przy użyciu Java
linktitle: Linia
type: docs
weight: 50
url: /pl/python-java/line/
keywords:
- linia
- tworzenie linii
- dodawanie linii
- zwykła linia
- konfigurowanie linii
- dostosowywanie linii
- styl przerywania
- główka strzałki
- PowerPoint
- prezentacja
- Python
- Aspose.Slides
description: "Poznaj manipulację formatowaniem linii w prezentacjach PowerPoint przy użyciu Aspose.Slides dla Pythona przez Java. Odkryj właściwości, metody i przykłady."
---
## **Przegląd**

Aspose.Slides umożliwia programowe dodawanie kształtów linii do slajdów PowerPoint. Ten artykuł pokazuje, jak utworzyć prostą linię oraz jak dostosować linię, aby wyglądała jak strzałka.

Nauczysz się, jak dodać kształt linii do slajdu, dostosować jego wygląd oraz zapisać zaktualizowaną prezentację. Przykłady koncentrują się na praktycznych ustawieniach formatowania linii, takich jak styl, szerokość, wzór przerywania, opcje zakończeń strzałki oraz kolor wypełnienia.

## **Utworzenie prostej linii**

Aby dodać prostą linię do wybranego slajdu prezentacji, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
- Dodaj kształt linii, używając metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) obiektu [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje linię do pierwszego slajdu prezentacji:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ShapeType

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt linii.
    slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Zapisz plik PPTX na dysku.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Utworzenie linii w kształcie strzałki**

Aspose.Slides for Python via Java umożliwia programistom konfigurowanie właściwości linii, aby wyglądała ona atrakcyjniej. Aby skonfigurować linię tak, aby przypominała strzałkę, wykonaj poniższe kroki:

- Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/python-java/aspose.slides/presentation/).
- Uzyskaj odwołanie do slajdu na podstawie jego indeksu.
- Dodaj kształt linii, używając metody [addAutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/#addAutoShape) obiektu [ShapeCollection](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapecollection/).
- Ustaw [line style](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linestyle/) na jeden ze stylów oferowanych przez Aspose.Slides for Python via Java.
- Ustaw szerokość linii.
- Ustaw [dash style](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linedashstyle/) na jeden ze stylów oferowanych przez Aspose.Slides for Python via Java.
- Ustaw [arrowhead style](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linearrowheadstyle/) i [length](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linearrowheadlength/) na początku linii.
- Ustaw [arrowhead style](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linearrowheadstyle/) i [length](https://reference.aspose.com/slides/pl/python-java/aspose.slides/linearrowheadlength/) na końcu linii.
- Zapisz zmodyfikowaną prezentację jako plik PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, LineArrowheadLength, LineArrowheadStyle, LineDashStyle, LineStyle, Presentation, PresetColor, SaveFormat, ShapeType

# Utwórz instancję klasy Presentation, która reprezentuje plik PPTX.
presentation = Presentation()
try:
    # Pobierz pierwszy slajd.
    slide = presentation.getSlides().get_Item(0)

    # Dodaj kształt linii.
    line = slide.getShapes().addAutoShape(ShapeType.Line, 50, 150, 300, 0)

    # Zastosuj formatowanie do linii.
    line_format = line.getLineFormat()
    line_format.setStyle(LineStyle.ThickBetweenThin)
    line_format.setWidth(10)

    line_format.setDashStyle(LineDashStyle.DashDot)

    line_format.setBeginArrowheadLength(LineArrowheadLength.Short)
    line_format.setBeginArrowheadStyle(LineArrowheadStyle.Oval)

    line_format.setEndArrowheadLength(LineArrowheadLength.Long)
    line_format.setEndArrowheadStyle(LineArrowheadStyle.Triangle)

    line_format.getFillFormat().setFillType(FillType.Solid)
    line_format.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.Maroon)

    # Zapisz plik PPTX na dysku.
    presentation.save("LineShape.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Czy mogę przekształcić zwykłą linię w łącznik, aby "przyciągała" się do kształtów?**

Nie. Zwykła linia ( [AutoShape](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/) typu [Line](https://reference.aspose.com/slides/pl/python-java/aspose.slides/shapetype/)) nie zamienia się automatycznie w łącznik. Aby przyciągała się do kształtów, użyj dedykowanego typu [Connector](https://reference.aspose.com/slides/pl/python-java/aspose.slides/connector/) oraz [corresponding APIs](/slides/pl/python-java/connector/) do połączeń.

**Co zrobić, gdy właściwości linii są dziedziczone z motywu i trudno określić ostateczne wartości?**

[Read the effective properties](/slides/pl/python-java/shape-effective-properties/) linii i jej wypełnienia — już uwzględniają dziedziczenie oraz style motywu.

**Czy mogę zablokować linię przed edycją (przemieszczaniem, zmianą rozmiaru)?**

Tak. Kształty udostępniają [lock objects](https://reference.aspose.com/slides/pl/python-java/aspose.slides/autoshape/#getAutoShapeLock), które pozwalają [uniemożliwić operacje edycji](/slides/pl/python-java/applying-protection-to-presentation/).