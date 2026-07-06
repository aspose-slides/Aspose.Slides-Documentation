---
title: Získání ohraničení odstavců z prezentací v Javě
linktitle: Ohraničení odstavců
type: docs
weight: 43
url: /cs/java/paragraph-bounds/
keywords:
- ohraničení odstavců
- souřadnice odstavců
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak v Aspose.Slides pro Javu získat ohraničení odstavců a optimalizovat umístění textu v prezentacích PowerPoint."
---
## **Overview**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak získat obdélník odstavce z [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) pomocí [IParagraph.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IParagraph#getRect--), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavců.

## **Get Rectangular Coordinates of a Paragraph**

Použijte [IParagraph.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IParagraph#getRect--) pro získání ohraničujícího obdélníku odstavce.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    java.awt.geom.Rectangle2D.Float rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Get the Size of a Paragraph Inside a Table Cell TextFrame**

Chcete-li získat velikost a souřadnice [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/) v textovém rámci buňky tabulky, použijte [IParagraph.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IParagraph#getRect--). Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže přidejte pozici tabulky a offset buňky, pokud potřebujete souřadnice na úrovni snímku.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a nakreslí obdélníky na snímku pro vizualizaci těchto ohraničení:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        java.awt.geom.Rectangle2D.Float paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.x + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.y + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width,
                paragraphRectangle.height);

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**V jakých jednotkách jsou měřeny souřadnice odstavců?**

Měří se v bodech, kde 1 palec odpovídá 72 bodům. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) povoleno [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), text se zalomí tak, aby se vešel do šířky oblasti, což změní skutečné ohraničení odstavce.

**Lze souřadnice odstavců spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely provádějte pomocí vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslení nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylů?**

Použijte [effective paragraph formatting data structure](/slides/cs/java/shape-effective-properties/); vrátí konečné konsolidované hodnoty odsazení, mezery, zalamování, RTL a další.