---
title: Získání ohraničení odstavců z prezentací v JavaScriptu
linktitle: Ohraničení odstavců
type: docs
weight: 43
url: /cs/nodejs-java/paragraph-bounds/
keywords:
- ohraničení odstavce
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak v Aspose.Slides pro Node.js získat ohraničení odstavců pomocí Java a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak načíst obdélník odstavce z [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) pomocí [Paragraph.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/getrect/), jak získat souřadnice odstavce uvnitř textového rámečku buňky tabulky, a zdůrazňuje důležité detaily, jako jsou měrné jednotky, vliv zalamování textu na ohraničení, převod pixelů a hodnoty efektivního formátování odstavce.

## **Získání obdélníkových souřadnic odstavce**

Použijte [Paragraph.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/getrect/) k získání ohraničujícího obdélníku odstavce.

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Získání velikosti odstavce uvnitř textového rámečku buňky tabulky**

Chcete-li získat velikost a souřadnice [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/) v textovém rámečku buňky tabulky, použijte [Paragraph.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/getrect/). Vrácený obdélník je relativní k textovému rámečku buňky tabulky, takže přidejte pozici tabulky a odsazení buňky, pokud potřebujete souřadnice na úrovni snímku.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a nakreslí obdélníky na snímku pro vizualizaci těchto ohraničení:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**V jakých jednotkách se měří souřadnice odstavce?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. To platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) povoleno [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframeformat/setwraptext/), text se zalamuje tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Body převádějte na pixely pomocí vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dedičnost stylu?**

Použijte [efektivní strukturu formátování odstavce](/slides/cs/nodejs-java/shape-effective-properties/); vrátí konečné konsolidované hodnoty pro odsazení, řádkování, zalamování, RTL a další.