---
title: Získání ohraničení textové části v prezentacích pro Android
linktitle: Ohraničení části
type: docs
weight: 47
url: /cs/androidjava/portion-bounds/
keywords:
- ohraničení textové části
- textová část
- část textu
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak získat ohraničení textové části v prezentacích PowerPoint pomocí Aspose.Slides pro Android v Javě."
---
## **Přehled**

Část textu představuje konkrétní fragment textu uvnitř odstavce a umožňuje pracovat s tímto fragmentem nezávisle na okolním obsahu. V Aspose.Slides lze části použít, když potřebujete získat ohraničení textového fragmentu, použít formátování pouze na část odstavce nebo řídit chování textu na podrobnější úroveň.

Tento článek ukazuje, jak získat ohraničující obdélník části pomocí [IPortion.getRect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getRect--). Také ukazuje, jak získat souřadnice začátku části pomocí [IPortion.getCoordinates](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getCoordinates--). Navíc zdůrazňuje běžné scénáře související s částmi, jako je aplikace hypertextového odkazu na jediný textový fragment, pochopení, jak je formátování řešeno prostřednictvím částí, odstavců, textových rámců a dědičnosti motivu, a řešení případů, kdy je požadované písmo nedostupné.

## **Získání ohraničení textové části**

Použijte [IPortion.getRect](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getRect--) k získání ohraničujícího obdélníku textové části:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Získání souřadnic textové části**

Použijte [IPortion.getCoordinates](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getCoordinates--) k získání souřadnic začátku textové části:

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené dotazy**

**Mohu aplikovat hypertextový odkaz pouze na část textu v jediném odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/androidjava/manage-hyperlinks/) jednotlivé části; pouze tento fragment bude klikací, nikoli celý odstavec.

**Jak funguje dědičnost stylu: co část přepíše a co se převzátí z odstavce nebo textového rámce?**

Vlastnosti úrovně části mají nejvyšší prioritu. Pokud není vlastnost nastavena na [IPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/), Aspose.Slides ji vezme z [IParagraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/). Pokud není nastavena ani tam, Aspose.Slides použije styl z [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) nebo [theme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/theme/).

**Co se stane, pokud je písmo určené pro část chybějící na cílovém počítači nebo serveru?**

[Pravidla nahrazování písma](/slides/cs/androidjava/font-selection-sequence/) se použijí. Text se může přetéct: mohou se změnit metriky, dělení slov a šířka, což má význam pro přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifické pro část nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [IPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/) se mohou lišit od sousedních fragmentů.