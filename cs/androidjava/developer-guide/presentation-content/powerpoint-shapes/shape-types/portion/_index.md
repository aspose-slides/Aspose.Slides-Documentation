---
title: Správa textových úseků v prezentacích na Androidu
linktitle: Textový úsek
type: docs
weight: 70
url: /cs/androidjava/portion/
keywords:
- textový úsek
- část textu
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat textové úseky v prezentacích PowerPoint pomocí Aspose.Slides pro Android v Javě, zvyšující výkon a přizpůsobení."
---
## **Úvod**

Textový úsek představuje konkrétní fragment textu uvnitř odstavce a umožňuje pracovat s tímto fragmentem nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat pozici textového fragmentu, použít formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

## **Získat souřadnice textového úseku**
[**getCoordinates()**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortion#getCoordinates--) metoda byla přidána do tříd [IPortion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportion/) a [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/), která umožňuje získat souřadnice začátku úseku.

```java
// Instancujte třídu Presentation, která představuje PPTX
Presentation pres = new Presentation();
try {
    // Přetvoření kontextu prezentace
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

## **Časté dotazy**

**Mohu přiřadit hyperodkaz jen na část textu v rámci jediného odstavce?**

Ano, můžete [přiřadit hyperodkaz](/slides/cs/androidjava/manage-hyperlinks/) k jednotlivému úseku; klikací bude jen tento fragment, ne celý odstavec.

**Jak funguje dědičnost stylů: co přepisuje Portion a co se převzátí z Paragraph/TextFrame?**

Vlastnosti na úrovni Portion mají vyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/), engine ji převezme z [Paragraph](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/paragraph/); pokud není nastavena ani tam, použije se ze [TextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textframe/) nebo ze stylu [theme](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/theme/).

**Co se stane, když je pro Portion specifikováno písmo, které chybí na cílovém počítači/serveru?**

Použijí se [pravidla pro náhradu písem](/slides/cs/androidjava/font-selection-sequence/). Text se může přeuspořádat: mohou se změnit metriky, dělení slov a šířka, což má vliv na přesné umístění.

**Mohu nastavit transparentnost výplně textu nebo přechod specifický pro Portion nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/portion/) se mohou lišit od sousedních úseků.