---
title: Uzyskaj granice akapitu z prezentacji w Pythonie za pośrednictwem Javy
linktitle: Granice akapitu
type: docs
weight: 43
url: /pl/python-java/paragraph-bounds/
keywords:
- granice akapitu
- współrzędne akapitu
- rozmiar akapitu
- ramka tekstowa
- PowerPoint
- prezentacja
- Python
- Java
- Aspose.Slides
description: "Dowiedz się, jak pobrać granice akapitu w Aspose.Slides dla Pythona za pośrednictwem Javy, aby zoptymalizować pozycjonowanie tekstu w prezentacjach PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak uzyskać granice, rozmiar i współrzędne akapitów w Aspose.Slides. Pokazuje, jak pobrać prostokąt akapitu z [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/) używając [Paragraph.getRect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/#getRect), jak uzyskać współrzędne akapitu wewnątrz ramki tekstowej komórki tabeli oraz podkreśla ważne szczegóły, takie jak jednostki miary, wpływ zawijania tekstu na granice, konwersja na piksele i wartości efektywnego formatowania akapitu.

## **Pobierz prostokątne współrzędne akapitu**

Użyj [Paragraph.getRect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/#getRect) aby uzyskać prostokąt ograniczający akapit.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("Shapes.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().get_Item(0)
    paragraph = shape.getTextFrame().getParagraphs().get_Item(0)
    rectangle = paragraph.getRect()
finally:
    presentation.dispose()
```

## **Pobierz rozmiar akapitu wewnątrz ramki tekstowej komórki tabeli**

Aby uzyskać rozmiar i współrzędne [Paragraph](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/) w ramce tekstowej komórki tabeli, użyj [Paragraph.getRect](https://reference.aspose.com/slides/pl/python-java/aspose.slides/paragraph/#getRect). Zwrócony prostokąt jest względem ramki tekstowej komórki tabeli, więc dodaj pozycję tabeli i offset komórki, gdy potrzebujesz współrzędnych na poziomie slajdu.

Poniższy przykład pobiera granice akapitu wewnątrz komórki tabeli i rysuje prostokąty na slajdzie, aby zwizualizować te granice:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation("source.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)
    cell = table.getRows().get_Item(1).get_Item(1)

    cell_x = table.getX() + cell.getOffsetX()
    cell_y = table.getY() + cell.getOffsetY()

    for paragraph in cell.getTextFrame().getParagraphs():
        if not paragraph.getText():
            continue

        paragraph_rectangle = paragraph.getRect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, paragraph_rectangle_x, paragraph_rectangle_y, paragraph_rectangle.width, paragraph_rectangle.height)

        paragraph_bounds_shape.getFillFormat().setFillType(FillType.NoFill)
        paragraph_bounds_shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        paragraph_bounds_shape.getLineFormat().getFillFormat().setFillType(FillType.Solid)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**W jakich jednostkach mierzone są współrzędne akapitu?**

Są mierzone w punktach, gdzie 1 cal równa się 72 punktom. Dotyczy to wszystkich współrzędnych i wymiarów na slajdzie.

**Czy zawijanie tekstu wpływa na granice akapitu?**

Tak. Jeśli [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframeformat/#setWrapText) jest włączone dla [TextFrame](https://reference.aspose.com/slides/pl/python-java/aspose.slides/textframe/), tekst dzieli się, aby dopasować się do szerokości obszaru, co zmienia rzeczywiste granice akapitu.

**Czy współrzędne akapitu można wiarygodnie przeliczyć na piksele w wyeksportowanym obrazie?**

Tak. Przelicz punkty na piksele używając wzoru: piksele = punkty × (DPI / 72). Wynik zależy od DPI wybranego do renderowania lub eksportu.

**Jak uzyskać „efektywne” parametry formatowania akapitu, uwzględniając dziedziczenie stylu?**

Użyj [effective paragraph formatting data structure](/slides/pl/python-java/shape-effective-properties/); zwraca ona ostateczne skonsolidowane wartości wcięć, odstępów, zawijania, RTL i innych.