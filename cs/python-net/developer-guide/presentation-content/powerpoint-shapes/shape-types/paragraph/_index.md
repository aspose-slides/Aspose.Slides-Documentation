---
title: Získání ohraničení odstavců z prezentací v Pythonu
linktitle: Odstavec
type: docs
weight: 60
url: /cs/python-net/paragraph/
keywords:
- ohraničení odstavce
- ohraničení části textu
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost části textu
- textový rámec
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Naučte se, jak v Aspose.Slides pro Python přes .NET získat ohraničení odstavců a částí textu a optimalizovat umístění textu v prezentacích PowerPoint a OpenDocument."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a částí textu v Aspose.Slides. Ukazuje, jak pomocí `get_rect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavce a části uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavce.

## **Získání souřadnic odstavce a části v TextFrame**
Pomocí Aspose.Slides pro Python přes .NET mohou vývojáři nyní získat obdélníkové souřadnice odstavce v kolekci odstavců TextFrame. Také umožňuje získat souřadnice části v kolekci částí odstavce. V tomto tématu ukážeme na příkladu, jak získat obdélníkové souřadnice odstavce spolu s pozicí části uvnitř odstavce.

## **Získání obdélníkových souřadnic odstavce**
Byla přidána nová metoda **GetRect()**. Umožňuje získat obdélník ohraničení odstavce.

```py
import aspose.slides as slides

# Vytvořte objekt Presentation, který představuje soubor prezentace
with slides.Presentation(path + "Shapes.pptx") as presentation:
    shape = presentation.slides[0].shapes[0]
    textFrame = shape.text_frame
    rect = textFrame.paragraphs[0].get_rect()
```

## **Získání velikosti odstavce a části v textovém rámci buňky tabulky** ##

Pro získání velikosti a souřadnic [Portion](https://reference.aspose.com/slides/cs/python-net/aspose.slides/portion/) nebo [Paragraph](https://reference.aspose.com/slides/cs/python-net/aspose.slides/paragraph/) v textovém rámci buňky tabulky můžete použít metody [IPortion.GetRect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iportion/) a [IParagraph.GetRect](https://reference.aspose.com/slides/cs/python-net/aspose.slides/iparagraph/).

Tento ukázkový kód demonstruje popsanou operaci:

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation(path + "source.pptx") as pres:
    tbl = pres.slides[0].shapes[0]

    cell = tbl.rows[1][1]


    x = tbl.X + tbl.rows[1][1].offset_x
    y = tbl.Y + tbl.rows[1][1].offset_y

    for para in cell.text_frame.paragraphs:
        if para.text == "":
            continue

        rect = para.get_rect()
        shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                rect.x + x, rect.y + y, rect.width, rect.height)

        shape.fill_format.fill_type = slides.FillType.NO_FILL
        shape.line_format.fill_format.solid_fill_color.color = draw.Color.yellow
        shape.line_format.fill_format.fill_type = slides.FillType.SOLID

        for portion in para.portions:
            if "0" in portion.text:
                rect = portion.get_rect()
                shape = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.RECTANGLE,
                        rect.x + x, rect.y + y, rect.width, rect.height)

                shape.fill_format.fill_type = slides.FillType.NO_FILL
```

## **Často kladené otázky**

**V jakých jednotkách jsou vráceny souřadnice odstavce a částí textu?**

V bodech, kde 1 palec = 72 bodů. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je [wrapping](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframeformat/wrap_text/) povolen v [TextFrame](https://reference.aspose.com/slides/cs/python-net/aspose.slides/textframe/), text se zalomí tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely provede: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování/export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/python-net/shape-effective-properties/); vrací konečné konsolidované hodnoty pro odsazení, rozestupy, zalamování, RTL a další.