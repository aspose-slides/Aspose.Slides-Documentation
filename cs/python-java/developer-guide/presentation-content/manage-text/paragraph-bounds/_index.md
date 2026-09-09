---
title: Získání ohraničení odstavců z prezentací v Pythonu přes Java
linktitle: Ohraničení odstavce
type: docs
weight: 43
url: /cs/python-java/paragraph-bounds/
keywords:
- ohraničení odstavce
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- Python
- Java
- Aspose.Slides
description: "Zjistěte, jak v Aspose.Slides pro Python přes Java získat ohraničení odstavců pro optimalizaci umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak získat obdélník odstavce z [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) pomocí [Paragraph.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getRect), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod do pixelů a hodnoty efektivního formátování odstavce.

## **Získání obdélníkových souřadnic odstavce**

Použijte [Paragraph.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getRect) k získání ohraničujícího obdélníku odstavce.

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

## **Získání velikosti odstavce uvnitř textového rámce buňky tabulky**

Chcete-li získat velikost a souřadnice [Paragraph](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/) v textovém rámci buňky tabulky, použijte [Paragraph.getRect](https://reference.aspose.com/slides/cs/python-java/aspose.slides/paragraph/#getRect). Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže pokud potřebujete souřadnice na úrovni snímku, přidejte pozici tabulky a posun buňky.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a nakreslí obdélníky na snímku pro vizualizaci těchto ohraničení:

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

## **Často kladené otázky**

**V jakých jednotkách jsou měřeny souřadnice odstavce?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. Týká se to všech souřadnic a rozměrů na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [TextFrame](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframe/) povoleno [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/python-java/aspose.slides/textframeformat/#setWrapText), text se láme tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převádějte body na pixely pomocí vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/python-java/shape-effective-properties/); vrací konečné konsolidované hodnoty pro odsazení, mezery, zalamování, RTL a další.