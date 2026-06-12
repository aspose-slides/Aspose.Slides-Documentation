---
title: Správa zástupných objektů prezentace v JavaScriptu
linktitle: Spravovat zástupné objekty
type: docs
weight: 10
url: /cs/nodejs-java/manage-placeholder/
keywords:
- zástupný objekt
- textový zástupný objekt
- obrázkový zástupný objekt
- grafický zástupný objekt
- výzva textu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše spravujte zástupné objekty v Aspose.Slides pro Node.js pomocí Java: nahraďte text, přizpůsobte výzvy a nastavte průhlednost obrázku v PowerPointu i OpenDocumentu."
---
## **Přehled**

Aspose.Slides umožňuje programově spravovat zástupné objekty prezentace. Tento článek vysvětluje, jak najít zástupné objekty na snímcích a změnit jejich text, nastavit vlastní výzvu textu pro rozvržení zástupných objektů a upravit průhlednost obrázku použitého jako pozadí zástupného objektu. Obsahuje také stručné FAQ, které objasňuje rozdíl mezi základními zástupnými objekty a lokálními tvary, vysvětluje, jak lze změny zástupných objektů aplikovat prostřednictvím rozvržení nebo hlavních šablon, a odkazuje na správu zástupných objektů záhlaví a zápatí.

## **Změna textu v zástupném objektu**

Pomocí [Aspose.Slides for Node.js via Java](/slides/cs/nodejs-java/) můžete najít a upravit zástupné objekty na snímcích v prezentacích. Aspose.Slides vám umožňuje měnit text v zástupném objektu.

**Požadavek**: Potřebujete prezentaci, která obsahuje zástupný objekt. Takovou prezentaci můžete vytvořit v běžné aplikaci Microsoft PowerPoint.

Takto používáte Aspose.Slides k nahrazení textu v zástupném objektu v dané prezentaci:

1. Vytvořte instanci třídy [`Presentation`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) a jako argument předejte prezentaci.
2. Získejte odkaz na snímek podle jeho indexu.
3. Projděte tvary a najděte zástupný objekt.
4. Přetypujte tvar zástupného objektu na [`AutoShape`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape) a změňte text pomocí [`TextFrame`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/TextFrame) přidruženého k [`AutoShape`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/AutoShape).
5. Uložte upravenou prezentaci.

Tento JavaScriptový kód ukazuje, jak změnit text v zástupném objektu:

```javascript
// Vytvoří instanci třídy Presentation
var pres = new aspose.slides.Presentation("ReplacingText.pptx");
try {
    // Přistupuje k prvnímu snímku
    var sld = pres.getSlides().get_Item(0);
    // Prochází tvary, aby našel zástupný objekt
    for (let i = 0; i < sld.getShapes().size(); i++) {
        let shp = sld.getShapes().get_Item(i);
        if (shp.getPlaceholder() != null) {
            // Mění text v každém zástupném objektu
            shp.getTextFrame().setText("This is Placeholder");
        }
    }
    // Uloží prezentaci na disk
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení výzvy textu v zástupném objektu**

Standardní a předpřipravená rozvržení obsahují výzvy textu pro zástupné objekty, jako je ***Klikněte pro přidání nadpisu*** nebo ***Klikněte pro přidání podnadpisu***. Pomocí Aspose.Slides můžete do rozvržení zástupných objektů vložit vlastní výzvy textu.

Tento JavaScriptový kód ukazuje, jak nastavit výzvu textu v zástupném objektu:

```javascript
var pres = new aspose.slides.Presentation("Presentation.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    // Iteruje přes snímek
    for (let i = 0; i < slide.getSlide().getShapes().size(); i++) {
        let shape = slide.getSlide().getShapes().get_Item(i);
        if ((shape.getPlaceholder() != null) && (java.instanceOf(shape, "com.aspose.slides.AutoShape"))) {
            var text = "";
            // PowerPoint zobrazuje "Klikněte pro přidání nadpisu"
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.CenteredTitle) {
                text = "Add Title";
            } else // Přidává podnadpis
            if (shape.getPlaceholder().getType() == aspose.slides.PlaceholderType.Subtitle) {
                text = "Add Subtitle";
            }
            shape.getTextFrame().setText(text);
            console.log("Placeholder with text: " + text);
        }
    }
    pres.save("Placeholders_PromptText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nastavení průhlednosti obrázku zástupného objektu**

Aspose.Slides umožňuje nastavit průhlednost obrázku pozadí v textovém zástupném objektu. Úpravou průhlednosti obrázku v takovém rámci můžete zvýraznit buď text, nebo obrázek (v závislosti na barvách textu a obrázku).

Tento JavaScriptový kód ukazuje, jak nastavit průhlednost obrázku pozadí (uvnitř tvaru):

```javascript
var presentation = new aspose.slides.Presentation("example.pptx");
var shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
var operationCollection = shape.getFillFormat().getPictureFillFormat().getPicture().getImageTransform();
for (var i = 0; i < operationCollection.size(); i++) {
    if (java.instanceOf(operationCollection.get_Item(i), "com.aspose.slides.AlphaModulateFixed")) {
        var alphaModulate = operationCollection.get_Item(i);
        var currentValue = 100 - alphaModulate.getAmount();
        console.log("Current transparency value: " + currentValue);
        var alphaValue = 40;
        alphaModulate.setAmount(100 - alphaValue);
    }
}
presentation.save("example_out.pptx", aspose.slides.SaveFormat.Pptx);
```

## **FAQ**

**Co je základní zástupný objekt a jak se liší od lokálního tvaru na snímku?**

Základní zástupný objekt je původní tvar v rozvržení nebo hlavní šabloně, ze kterého dědí tvar snímku – typ, umístění a část formátování pochází z něj. Lokální tvar je nezávislý; pokud neexistuje základní zástupný objekt, dědictví se neuplatní.

**Jak mohu aktualizovat všechny nadpisy nebo popisky v celé prezentaci, aniž bych procházel každý snímek?**

Upravte odpovídající zástupný objekt v rozvržení nebo v hlavní šabloně. Snímky založené na těchto rozvrženích/hlavní šabloně automaticky zdědí změnu.

**Jak mohu ovládat standardní zástupné objekty záhlaví/zápatí – datum a čas, číslo snímku a text zápatí?**

Použijte správce HeaderFooter v odpovídajícím rozsahu (běžné snímky, rozvržení, hlavní šablona, poznámky/letáky) k zapnutí nebo vypnutí těchto zástupných objektů a k nastavení jejich obsahu.