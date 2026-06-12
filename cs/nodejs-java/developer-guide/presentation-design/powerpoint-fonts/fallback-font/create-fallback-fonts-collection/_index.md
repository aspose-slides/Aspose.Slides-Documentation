---
title: Konfigurace kolekcí záložních fontů v JavaScriptu
linktitle: Kolekce záložních fontů
type: docs
weight: 20
url: /cs/nodejs-java/create-fallback-fonts-collection/
keywords:
- záložní font
- záložní pravidlo
- kolekce fontů
- konfigurace fontu
- nastavení fontu
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Nastavte kolekci záložních fontů v JavaScriptu pomocí Aspose.Slides pro Node.js, aby byl text v prezentacích PowerPoint a OpenDocument konzistentní a ostrý."
---
## **Overview**

Aspose.Slides vám umožňuje nakonfigurovat kolekci pravidel záložních fontů pro prezentaci. Každé záložní pravidlo je reprezentováno třídou `FontFallBackRule` a může být přidáno do `FontFallBackRulesCollection`.

Po vytvoření kolekce ji můžete přiřadit pomocí metody `setFontFallBackRulesCollection` správce písem (`FontsManager`) prezentace. `FontsManager` řídí písma v celé prezentaci a každá instance `Presentation` má svůj vlastní `FontsManager`.

Jakmile je `FontsManager` inicializován s kolekcí záložních fontů, specifikované záložní fonty jsou použity při vykreslování prezentace.

## **Apply Fallback Rules**

Instance třídy [FontFallBackRule](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRule) mohou být uspořádány do [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRulesCollection), která implementuje třídu [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRulesCollection). Je možné přidávat nebo odebírat pravidla z kolekce.

Pak může být tato kolekce přiřazena metodě [FontFallBackRulesCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontFallBackRulesCollection) třídy [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontsManager). FontsManager řídí písma v celé prezentaci.

Každá [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) má metodu [getFontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getFontsManager--) se svou vlastní instancí třídy [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/FontsManager).

Zde je příklad, jak vytvořit kolekci pravidel záložních fontů a přiřadit ji do [FontsManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getFontsManager--) konkrétní prezentace:  

```javascript
var pres = new aspose.slides.Presentation();
try {
    var userRulesList = new aspose.slides.FontFallBackRulesCollection();
    userRulesList.add(new aspose.slides.FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    userRulesList.add(new aspose.slides.FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Po inicializaci FontsManageru s kolekcí záložních fontů jsou záložní fonty použity během vykreslování prezentace.

{{% alert color="primary" %}} 
Přečtěte si více o tom, jak [Vykreslit prezentaci se záložním fontem](/slides/cs/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Will my fallback rules be embedded into the PPTX file and visible in PowerPoint after saving?**

No. Fallback rules are runtime rendering settings; they are not serialized into PPTX and will not appear in PowerPoint's UI.

**Does fallback apply to text inside SmartArt, WordArt, charts, and tables?**

Yes. The same glyph-substitution mechanism is used for any text in these objects.

**Does Aspose distribute any fonts with the library?**

No. You add and use fonts on your side and under your own responsibility.

**Can replacement/substitution for missing fonts and fallback for missing glyphs be used together?**

Yes. They are independent stages of the same font-resolution pipeline: first the engine resolves font availability ([replacement](/slides/cs/nodejs-java/font-replacement/)/[substitution](/slides/cs/nodejs-java/font-substitution/)), then fallback fills gaps for missing glyphs in available fonts.