---
title: Získání ohraničení odstavců z prezentací v Pythonu
linktitle: Ohraničení odstavců
type: docs
weight: 43
url: /cs/python-net/paragraph-bounds/
keywords:
- ohraničení odstavců
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Zjistěte, jak získat ohraničení odstavců v Aspose.Slides pro Python pomocí .NET a optimalizovat umístění textu v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak pomocí [Paragraph.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/get_rect/) získat obdélník odstavce z [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavců.

## **Získání obdélníkových souřadnic odstavce**

Použijte [Paragraph.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/get_rect/) k získání ohraničujícího obdélníku odstavce.

```py
import aspose.slides as slides

with slides.Presentation("Shapes.pptx") as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes[0]
    paragraph = shape.text_frame.paragraphs[0]
    rectangle = paragraph.get_rect()
```

## **Získání velikosti odstavce uvnitř textového rámce buňky tabulky**

Chcete‑li získat velikost a souřadnice [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) v textovém rámci buňky tabulky, použijte [Paragraph.get_rect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/get_rect/). Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže pokud potřebujete souřadnice na úrovni snímku, přidejte pozici tabulky a offset buňky.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a vykreslí obdélníky na snímku pro vizualizaci těchto ohraničení:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation("source.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]
    cell = table.rows[1][1]

    cell_x = table.x + cell.offset_x
    cell_y = table.y + cell.offset_y

    for paragraph in cell.text_frame.paragraphs:
        if paragraph.text == "":
            continue

        paragraph_rectangle = paragraph.get_rect()
        paragraph_rectangle_x = paragraph_rectangle.x + cell_x
        paragraph_rectangle_y = paragraph_rectangle.y + cell_y

        paragraph_bounds_shape = slide.shapes.add_auto_shape(
            slides.ShapeType.RECTANGLE,
            paragraph_rectangle_x,
            paragraph_rectangle_y,
            paragraph_rectangle.width,
            paragraph_rectangle.height)

        paragraph_bounds_shape.fill_format.fill_type = slides.FillType.NO_FILL
        paragraph_bounds_shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        paragraph_bounds_shape.line_format.fill_format.fill_type = slides.FillType.SOLID

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Často kladené otázky**

**V jakých jednotkách jsou měřeny souřadnice odstavců?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/) povoleno [TextFrameFormat.wrap_text](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/wrap_text/), text se zalomí tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Mohou být souřadnice odstavce spolehlivě převedeny na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely provedete pomocí vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/python-net/shape-effective-properties/); vrací konečné sloučené hodnoty pro odsazení, mezery, zalamování, RTL a další.