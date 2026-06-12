---
title: Vykreslení prezentací se záložními fonty v JavaScriptu
linktitle: Vykreslit prezentace
type: docs
weight: 30
url: /cs/nodejs-java/render-presentation-with-fallback-font/
keywords:
- záložní font
- vykreslit PowerPoint
- vykreslit prezentaci
- vykreslit snímek
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vykreslete prezentace se záložními fonty v Aspose.Slides pro Node.js – zachovejte konzistentní text v PPT, PPTX a ODP pomocí podrobných ukázek kódu v JavaScriptu."
---
## **Přehled**

Aspose.Slides umožňuje vykreslovat prezentace pomocí pravidel záložních fontů. Tento článek ukazuje, jak vytvořit kolekci pravidel pro záložní fonty, upravit její pravidla odebráním nebo přidáním záložních fontů a přiřadit kolekci pomocí metody `FontsManager.setFontFallBackRulesCollection`.

Jakmile je kolekce pravidel záložních fontů přiřazena k `FontsManager` prezentace, pravidla se aplikují během operací, jako je ukládání, vykreslování a převod prezentace. Příklad ukazuje, jak použít nakonfigurovaná pravidla při vykreslování náhledu snímku a jeho uložení jako PNG obrázku.

## **Vykreslení snímku pomocí pravidel záložních fontů**

Následující příklad obsahuje následující kroky:

1. Vytvoříme [kolekci pravidel záložních fontů](/slides/cs/nodejs-java/create-fallback-fonts-collection/).
1. [Odstranit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule#remove-java.lang.String-) pravidlo záložního fontu a [addFallBackFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule#addFallBackFonts-java.lang.String-) k jinému pravidlu.
1. Nastavte kolekci pravidel metodou [getFontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getFontsManager--).[getFontFallBackRulesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontsManager#getFontFallBackRulesCollection--) .
1. Pomocí metody [Presentation.save](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-) můžeme uložit prezentaci ve stejném formátu nebo ji uložit v jiném. Po nastavení kolekce pravidel záložních fontů do [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontsManager) se tato pravidla použijí během všech operací s prezentací: ukládání, vykreslování, převod atd.

```javascript
// Vytvoření nové instance kolekce pravidel
var rulesList = new aspose.slides.FontFallBackRulesCollection();
// vytvořit několik pravidel
rulesList.add(new aspose.slides.FontFallBackRule(0x400, 0x4ff, "Times New Roman"));
for (let i = 0; i < rulesList.size(); i++) {
    let fallBackRule = rulesList.get_Item(0);
    // Pokouším se odebrat záložní font "Tahoma" ze načtených pravidel
    fallBackRule.remove("Tahoma");
    // A aktualizovat pravidla pro specifikovaný rozsah
    if ((fallBackRule.getRangeEndIndex() >= 0x4000) && (fallBackRule.getRangeStartIndex() < 0x5000)) {
        fallBackRule.addFallBackFonts("Verdana");
    }
}
// Také můžeme odebrat jakákoliv existující pravidla ze seznamu
if (rulesList.size() > 0) {
    rulesList.remove(rulesList.get_Item(0));
}
var pres = new aspose.slides.Presentation("input.pptx");
try {
    // Přiřazení připraveného seznamu pravidel k použití
    pres.getFontsManager().setFontFallBackRulesCollection(rulesList);
    // Vykreslení miniatury s použitím inicializované kolekce pravidel a uložení jako JPEG
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Uložení obrázku na disk ve formátu JPEG
    try {
        slideImage.save("Slide_0.jpg", aspose.slides.ImageFormat.Jpeg);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Convert PPT and PPTX to JPG in JavaScript](/slides/cs/nodejs-java/convert-powerpoint-to-jpg/).
{{% /alert %}}