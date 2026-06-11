---
title: Konfigurera fallback‑typsnittssamlingar i JavaScript
linktitle: Fallback‑typsnittssamling
type: docs
weight: 20
url: /sv/nodejs-java/create-fallback-fonts-collection/
keywords:
- fallback‑typsnitt
- fallback‑regel
- typsnittssamling
- konfigurera typsnitt
- installera typsnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa en fallback‑typsnittssamling i JavaScript med Aspose.Slides för Node.js för att hålla texten konsekvent och skarp i PowerPoint‑ och OpenDocument‑presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av fallback‑typsnittregler för en presentation. Varje fallback‑regel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`.

Efter att du skapat samlingen kan du tilldela den med metoden `setFontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr typsnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initialiserats med fallback‑typsnittssamlingen appliceras de angivna fallback‑typsnitten under rendering av presentationen.

## **Tillämpa fallback‑regler**

Instanser av [FontFallBackRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRule) klassen kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRulesCollection), som implementerar [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRulesCollection) klassen. Det är möjligt att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling tilldelas [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontFallBackRulesCollection)‑metoden i [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontsManager) klassen. FontsManager styr typsnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation) har en [getFontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getFontsManager--)‑metod med sin egen instans av [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/FontsManager)‑klassen.

Här är ett exempel på hur man skapar en samling av fallback‑typsnittsregler och tilldelar den till [FontsManager](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getFontsManager--) för en viss presentation:  

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

Efter att FontsManager har initierats med fallback‑typsnittssamlingen appliceras fallback‑typsnitten under rendering av presentationen.

{{% alert color="primary" %}} 
Läs mer om hur man [Renderar presentation med fallback‑typsnitt](/slides/sv/nodejs-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

**Kommer mina fallback‑regler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter att den sparats?**

Nej. Fallback‑regler är inställningar för rendering vid körning; de serialiseras inte till PPTX och visas inte i PowerPoints användargränssnitt.

**Gäller fallback för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några typsnitt med biblioteket?**

Nej. Du lägger till och använder typsnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade typsnitt och fallback för saknade glyfer användas samtidigt?**

Ja. De är oberoende steg i samma typsnittslösningspipeline: först löser motorn typsnittstillgänglighet ([replacement](/slides/sv/nodejs-java/font-replacement/)/[substitution](/slides/sv/nodejs-java/font-substitution/)), sedan fyller fallback luckor för saknade glyfer i tillgängliga typsnitt.