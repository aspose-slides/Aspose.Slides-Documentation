---
title: Správa textových úseků v prezentacích pomocí Javy
linktitle: Textový úsek
type: docs
weight: 70
url: /cs/java/portion/
keywords:
  - textový úsek
  - část textu
  - souřadnice textu
  - pozice textu
  - PowerPoint
  - prezentace
  - Java
  - Aspose.Slides
description: "Naučte se spravovat textové úseky v prezentacích PowerPoint pomocí Aspose.Slides pro Javu, zvyšující výkon a možnosti přizpůsobení."
---
## **Přehled**

Textový úsek představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat pozici textového fragmentu, aplikovat formátování jen na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak pomocí metody `getCoordinates()` získat souřadnice začátku úseku. Také zdůrazňuje běžné scénáře související s úseky, jako je aplikace hypertextového odkazu na jediný textový fragment, pochopení, jak se formátování řeší prostřednictvím dědičnosti úsek → odstavec → textový rámec → téma, a řešení situací, kdy je požadované písmo nedostupné. Navíc upozorňuje, že výplň textu, barva a průhlednost mohou být nastaveny odlišně pro jednotlivé úseky ve stejném odstavci.

## **Získání souřadnic textového úseku**
[**getCoordinates()**](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPortion#getCoordinates--) metoda byla přidána do třídy [IPortion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportion/) a [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/), která umožňuje získat souřadnice začátku úseku.

```java
// Vytvořte třídu Presentation, která představuje soubor PPTX
Presentation pres = new Presentation();
try {
    // Úprava kontextu prezentace
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Mohu aplikovat hypertextový odkaz pouze na část textu v jediném odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/java/manage-hyperlinks/) k jednotlivému úseku; pouze tento fragment bude klikací, ne celý odstavec.

**Jak funguje dědičnost stylů: co přepisuje Portion a co se převzátí z Paragraph/TextFrame?**

Vlastnosti na úrovni úseku mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/), engine ji vezme z [Paragraph](https://reference.aspose.com/slides/cs/java/com.aspose.slides/paragraph/); pokud není nastavena ani tam, vezme ji z [TextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textframe/) nebo ze stylu [theme](https://reference.aspose.com/slides/cs/java/com.aspose.slides/theme/).

**Co se stane, pokud je písmo určené pro Portion na cílovém počítači/serveru nedostupné?**

[Pravidla náhrady písma](/slides/cs/java/font-selection-sequence/) se použijí. Text se může přetvořit: mohou se změnit metriky, dělení slov a šířka, což má vliv na přesné umístění.

**Mohu nastavit průhlednost nebo gradient výplně textu specifické pro Portion nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/java/com.aspose.slides/portion/) se mohou lišit od sousedních fragmentů.