---
title: Získání ohraničení odstavců z prezentací na Androidu
linktitle: Ohraničení odstavce
type: docs
weight: 43
url: /cs/androidjava/paragraph-bounds/
keywords:
- hranice odstavce
- souřadnice odstavce
- velikost odstavce
- textový rámec
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak v Aspose.Slides pro Android pomocí Javy získat ohraničení odstavců pro optimalizaci umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců v Aspose.Slides. Ukazuje, jak získat obdélník odstavce z [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) pomocí [IParagraph.getRect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraph#getRect--), jak získat souřadnice odstavce uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavců.

## **Získání obdélníkových souřadnic odstavce**

Použijte IParagraph.getRect k získání ohraničujícího obdélníku odstavce.

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **Získání velikosti odstavce uvnitř textového rámce buňky tabulky**

Aby bylo možné získat velikost a souřadnice [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/) v textovém rámci buňky tabulky, použijte IParagraph.getRect. Vrácený obdélník je relativní k textovému rámci buňky tabulky, takže pokud potřebujete souřadnice na úrovni snímku, přidejte pozici tabulky a posun buňky.

Následující příklad získá ohraničení odstavce uvnitř buňky tabulky a vykreslí obdélníky na snímku, aby vizualizoval tato ohraničení:

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

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou měřeny souřadnice odstavce?**

Jsou měřeny v bodech, kde 1 palec odpovídá 72 bodům. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je pro [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) povoleno TextFrameFormat.setWrapText, text se zalamuje tak, aby odpovídal šířce oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely pomocí vzorce: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování nebo export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylů?**

Použijte [effective paragraph formatting data structure](/slides/cs/androidjava/shape-effective-properties/); vrací konečné konsolidované hodnoty pro odsazení, mezery, zalamování, RTL a další.