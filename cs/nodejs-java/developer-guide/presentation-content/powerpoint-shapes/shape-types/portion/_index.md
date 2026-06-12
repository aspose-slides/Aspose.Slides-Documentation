---
title: Spravovat textové úseky v prezentacích pomocí JavaScriptu
linktitle: Textový úsek
type: docs
weight: 70
url: /cs/nodejs-java/portion/
keywords:
- textový úsek
- textová část
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak spravovat textové úseky v prezentacích PowerPoint pomocí JavaScriptu a Aspose.Slides pro Node.js přes Java, což zvyšuje výkon a možnosti přizpůsobení."
---
## **Přehled**

Úsek textu představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze úseky použít, když potřebujete získat pozici textového fragmentu, použít formátování pouze na část odstavce nebo řídit chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat souřadnice začátku úseku pomocí metody `getCoordinates()`. Také poukazuje na běžné scénáře související s úseky, jako je přiřazení hypertextového odkazu k jedinému fragmentu textu, pochopení, jak se formátování řeší skrze úsek, odstavec, textový rámec a dědičnost motivu, a jak řešit situace, kdy požadované písmo není k dispozici. Navíc uvádí, že výplň textu, barva a průhlednost mohou být nastaveny odlišně pro jednotlivé úseky ve stejném odstavci.

## **Získání souřadnic pozice úseku**
[**getCoordinates()**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Portion#getCoordinates--) metoda byla přidána do třídy [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/), která umožňuje získat souřadnice začátku úseku.

```javascript
// Vytvořit instanci třídy Presentation, která představuje soubor PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Přetvoření kontextu prezentace
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Často kladené otázky**

**Mohu přiřadit hypertextový odkaz jen k části textu v jednom odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/nodejs-java/manage-hyperlinks/) k jednotlivému úseku; pouze tento fragment bude klikací, nikoli celý odstavec.

**Jak funguje dědičnost stylů: co přepisuje úsek a co je převzato z odstavce/textového rámce?**

Vlastnosti na úrovni úseku mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/), engine ji vezme z [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/); pokud není nastavena ani tam, vezme ji z [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) nebo ze stylu [theme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/theme/).

**Co se stane, pokud je písmo určené pro úsek na cílovém počítači/serveru nedostupné?**

[Pravidla pro substituci písem](/slides/cs/nodejs-java/font-selection-sequence/) se použijí. Text se může přetvořit: metriky, dělení slov a šířka se mohou změnit, což má vliv na přesné umístění.

**Mohu nastavit průhlednost výplně textu nebo gradient specifický pro úsek, nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a průhlednost na úrovni [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.