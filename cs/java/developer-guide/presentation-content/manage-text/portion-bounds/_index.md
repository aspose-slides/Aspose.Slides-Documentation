---
title: Získání ohraničení úseku textu z prezentací v Java
linktitle: Ohraničení úseku
type: docs
weight: 47
url: /cs/java/portion-bounds/
keywords:
- ohraničení úseku textu
- úsek textu
- část textu
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Naučte se, jak získat ohraničení úseku textu v prezentacích PowerPoint pomocí Aspose.Slides pro Java."
---
## **Přehled**

Úsek textu představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat ohraničení textového fragmentu, aplikovat formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník úseku pomocí [IPortion.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getRect--). Také ukazuje, jak získat souřadnice začátku úseku pomocí [IPortion.getCoordinates](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getCoordinates--). Navíc zvýrazňuje běžné scénáře související s úseky, jako je aplikace hypertextového odkazu na jediný textový fragment, pochopení toho, jak se formátování řeší přes úsek, odstavec, textový rámeček a dědictví motivu, a jak zacházet s případy, kdy zadané písmo není k dispozici.

## **Získání ohraničení úseku textu**

Použijte [IPortion.getRect](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getRect--) k získání ohraničujícího obdélníku úseku textu:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Získání souřadnic úseku textu**

Použijte [IPortion.getCoordinates](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getCoordinates--) k získání souřadnic začátku úseku textu:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu aplikovat hypertextový odkaz pouze na část textu v jediném odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/java/manage-hyperlinks/) k jednotlivému úseku; kliknutelný bude pouze tento fragment, ne celý odstavec.

**Jak funguje dědičnost stylů: co úsek přepíše a co se převzít z odstavce nebo textového rámce?**

Vlastnosti na úrovni úseku mají nejvyšší prioritu. Pokud není vlastnost nastavena na [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/), Aspose.Slides ji převzala z [IParagraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/). Pokud není nastavena ani tam, Aspose.Slides použije styl z [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) nebo [theme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/theme/).

**Co se stane, pokud je písmo specifikované pro úsek na cílovém počítači nebo serveru nedostupné?**

[Pravidla substituce písma](/slides/cs/java/font-selection-sequence/) se použijí. Text se může přeskupit: mohou se změnit metriky, dělení slov a šířka, což má význam pro přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifický pro úsek nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) se mohou lišit od sousedních fragmentů.