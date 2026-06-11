---
title: Konfigurera fallback-typsnittssamlingar i PHP
linktitle: Fallback-typsnittssamling
type: docs
weight: 20
url: /sv/php-java/create-fallback-fonts-collection/
keywords:
- fallback-typsnitt
- fallback-regel
- typsnittssamling
- konfigurera typsnitt
- installera typsnitt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Ställ in en fallback-typsnittssamling i Aspose.Slides för PHP via Java för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av fallback-typsnittregler för en presentation. Varje fallback-regel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`.

Efter att ha skapat samlingen kan du tilldela den med metoden `setFontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr typsnitt över hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med fallback-typsnittssamlingen tillämpas de angivna fallback-typsnitten under presentationens rendering.

## **Applicera fallback‑regler**

Instanser av [FontFallBackRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRule) klassen kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRulesCollection). Det är möjligt att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling tilldelas till [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontFallBackRulesCollection)-metoden i klassen [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontsManager). `FontsManager` styr typsnitt över presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) har en [getFontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#getFontsManager)-metod med sin egen instans av klassen [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/FontsManager).

Här är ett exempel på hur man skapar en samling av fallback-typsnittsregler och tilldelar den till [FontsManager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#getFontsManager) för en viss presentation:  

```php
  $pres = new Presentation();
  try {
    $userRulesList = new FontFallBackRulesCollection();
    $userRulesList->add(new FontFallBackRule(0xb80, 0xbff, "Vijaya"));
    $userRulesList->add(new FontFallBackRule(0x3040, 0x309f, "MS Mincho, MS Gothic"));
    $pres->getFontsManager()->setFontFallBackRulesCollection($userRulesList);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

När `FontsManager` har initierats med fallback-typsnittssamlingen tillämpas fallback-typsnitten under presentationens rendering.

{{% alert color="primary" %}} 
Läs mer om hur du [Rendera presentation med fallback‑typsnitt](/slides/sv/php-java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Vanliga frågor**

**Kommer mina fallback‑regler att bäddas in i PPTX‑filen och vara synliga i PowerPoint efter sparning?**

Nej. Fallback‑regler är inställningar för rendering i realtid; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints användargränssnitt.

**Gäller fallback för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några typsnitt med biblioteket?**

Nej. Du lägger till och använder typsnitt på din sida och under ditt eget ansvar.

**Kan ersättning/substitution för saknade typsnitt och fallback för saknade glyfer användas tillsammans?**

Ja. De är oberoende steg i samma font‑upplösningspipeline: först löser motorn typsnittstillgänglighet ([ersättning](/slides/sv/php-java/font-replacement/)/[substitution](/slides/sv/php-java/font-substitution/)), sedan fyller fallback i luckor för saknade glyfer i tillgängliga typsnitt.