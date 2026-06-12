---
title: Získání ohraničení odstavců z prezentací v Javě
linktitle: Odstavec
type: docs
weight: 60
url: /cs/java/paragraph/
keywords:
- ohraničení odstavce
- ohraničení části textu
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost části textu
- textový rámec
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak získat ohraničení odstavců a částí textu v Aspose.Slides pro Javu za účelem optimalizace umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a částí textu v Aspose.Slides. Ukazuje, jak pomocí `getRect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavce a části uvnitř textového rámce buňky tabulky, a zdůrazňuje důležité podrobnosti, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod do pixelů a hodnoty efektivního formátování odstavce.

## **Získání souřadnic odstavce a části v TextFrame**
Pomocí Aspose.Slides for Java mohou vývojáři nyní získat obdélníkové souřadnice odstavce uvnitř kolekce odstavců v TextFrame. Také umožňuje získat [souřadnice části](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getCoordinates--) uvnitř kolekce částí odstavce. V tomto tématu ukážeme na příkladu, jak získat obdélníkové souřadnice odstavce spolu s umístěním části uvnitř odstavce.

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **Získání obdélníkových souřadnic odstavce**
Pomocí metody [**getRect()**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IParagraph#getRect--) mohou vývojáři získat obdélník ohraničení odstavce.

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Získání velikosti odstavce a části v textovém rámci buňky tabulky**
Pro získání velikosti a souřadnic [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Portion) nebo [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Paragraph) v textovém rámci buňky tabulky můžete použít metody [IPortion.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getRect--) a [IParagraph.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IParagraph#getRect--).

Tento ukázkový kód demonstruje popsanou operaci:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**V jakých jednotkách jsou vrácené souřadnice odstavce a částí textu měřeny?**

V bodech, kde 1 palec = 72 bodů. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování slov ohraničení odstavce?**

Ano. Pokud je [zalamování](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframeformat/#setWrapText-byte-) povoleno v [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/), text se rozbije tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převést body na pixely lze pomocí: pixely = body × (DPI / 72). Výsledek závisí na DPI zvoleném pro renderování/export.

**Jak získám „efektivní“ parametry formátování odstavce, s ohledem na dědičnost stylu?**

Použijte [effective paragraph formatting data structure](/slides/cs/java/shape-effective-properties/); vrací konečné konsolidované hodnoty pro odsazení, mezery, zalamování, RTL a další.