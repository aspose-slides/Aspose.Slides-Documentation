---
title: Získání ohraničení textové části z prezentací v JavaScriptu
linktitle: Ohraničení části
type: docs
weight: 47
url: /cs/nodejs-java/portion-bounds/
keywords:
- ohraničení textové části
- textová část
- textová část
- souřadnice textu
- pozice textu
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak získat ohraničení textové části v prezentacích PowerPoint pomocí Aspose.Slides pro Node.js přes Javu."
---
## **Přehled**

Textová část představuje konkrétní fragment textu uvnitř odstavce a umožňuje s tímto fragmentem pracovat nezávisle na okolním obsahu. V Aspose.Slides lze části použít, když potřebujete získat ohraničení textového fragmentu, aplikovat formátování jen na část odstavce nebo ovládat chování textu na podrobnější úrovni.

Tento článek ukazuje, jak získat ohraničující obdélník části pomocí [Portion.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/getrect/). Také ukazuje, jak získat souřadnice začátku části pomocí [Portion.getCoordinates](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/getcoordinates/). Navíc zdůrazňuje běžné scénáře související s částmi, například aplikaci hypertextového odkazu na jediný textový fragment, pochopení, jak je formátování řešeno skrze část, odstavec, textový rámec a dědičnost motivu, a jak zacházet s případy, kdy je požadované písmo nedostupné.

## **Získání ohraničení textové části**

Použijte [Portion.getRect](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/getrect/) k získání ohraničujícího obdélníku textové části:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Získání souřadnic textové části**

Použijte [Portion.getCoordinates](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/getcoordinates/) k získání souřadnic začátku textové části:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Mohu aplikovat hypertextový odkaz pouze na část textu v jednom odstavci?**

Ano, můžete [přiřadit hypertextový odkaz](/slides/cs/nodejs-java/manage-hyperlinks/) k jednotlivé části; pouze tento fragment bude kliknutelný, ne celý odstavec.

**Jak funguje dědičnost stylů: co část přepisuje a co se převzímá z odstavce nebo textového rámce?**

Vlastnosti na úrovni části mají nejvyšší prioritu. Pokud není vlastnost nastavena na [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/), Aspose.Slides ji převzme z [Paragraph](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/paragraph/). Pokud není nastavena ani tam, Aspose.Slides použije styl [TextFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/textframe/) nebo [theme](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/theme/).

**Co se stane, pokud je písmo určené pro část chybějící na cílovém počítači nebo serveru?**

[Pravidla pro náhradu písem](/slides/cs/nodejs-java/font-selection-sequence/) se použijí. Text se může překreslit: metriky, dělení slov a šířka se mohou změnit, což je důležité pro přesné umístění.

**Mohu nastavit transparentnost výplně textu nebo gradient specifické pro část nezávisle na zbytku odstavce?**

Ano, barva textu, výplň a transparentnost na úrovni [Portion](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/portion/) se mohou lišit od sousedních fragmentů.