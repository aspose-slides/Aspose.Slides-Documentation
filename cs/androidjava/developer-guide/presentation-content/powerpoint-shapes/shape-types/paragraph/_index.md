---
title: Získání ohraničení odstavců z prezentací na Androidu
linktitle: Odstavec
type: docs
weight: 60
url: /cs/androidjava/paragraph/
keywords:
- ohraničení odstavce
- ohraničení textové části
- souřadnice odstavce
- souřadnice části
- velikost odstavce
- velikost textové části
- textový rámec
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak v Aspose.Slides pro Android pomocí Javy získat ohraničení odstavců a textových částí za účelem optimalizace umístění textu v prezentacích PowerPoint."
---
## **Přehled**

Tento článek vysvětluje, jak získat ohraničení, velikost a souřadnice odstavců a textových částí v Aspose.Slides. Ukazuje, jak pomocí `getRect()` získat obdélník odstavce v `TextFrame`, jak získat souřadnice odstavce a části uvnitř textového rámce buňky tabulky a upozorňuje na důležité detaily, jako jsou jednotky měření, vliv zalamování textu na ohraničení, převod na pixely a hodnoty efektivního formátování odstavce.

## **Získání souřadnic odstavců a částí v TextFrame**
Pomocí Aspose.Slides pro Android přes Java mohou vývojáři nyní získat obdélníkové souřadnice odstavce ve sbírce odstavců TextFrame. Umožňuje také získat [souřadnice části](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getCoordinates--) ve sbírce částí odstavce. V tomto tématu ukážeme na příkladu, jak získat obdélníkové souřadnice odstavce spolu s pozicí části uvnitř odstavce.

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
Pomocí metody [**getRect()**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraph#getRect--) mohou vývojáři získat obdélník ohraničující odstavec.

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

## **Získání velikosti odstavce a části uvnitř TextFrame buňky tabulky**

Pro získání velikosti a souřadnic [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Portion) nebo [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Paragraph) v textovém rámci buňky tabulky můžete použít metody [IPortion.getRect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getRect--) a [IParagraph.getRect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraph#getRect--).

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

## **FAQ**

**V jakých jednotkách jsou vráceny souřadnice odstavce a textových částí?**

V bodech, kde 1 palec = 72 bodů. Toto platí pro všechny souřadnice a rozměry na snímku.

**Ovlivňuje zalamování textu ohraničení odstavce?**

Ano. Pokud je v [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) povoleno [wrapping](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-), text se zalamuje tak, aby se vešel do šířky oblasti, což mění skutečné ohraničení odstavce.

**Lze souřadnice odstavce spolehlivě převést na pixely v exportovaném obrázku?**

Ano. Převod bodů na pixely pomocí: pixels = points × (DPI / 72). Výsledek závisí na DPI zvoleném pro vykreslování/export.

**Jak získám „efektivní“ parametry formátování odstavce s ohledem na dědičnost stylů?**

Použijte [efektivní datovou strukturu formátování odstavce](/slides/cs/androidjava/shape-effective-properties/); vrací konečné sloučené hodnoty odsazení, rozestupů, zalamování, RTL a dalších.