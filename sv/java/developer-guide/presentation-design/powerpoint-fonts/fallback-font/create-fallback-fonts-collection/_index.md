---
title: Konfigurera reservteckensnittssamlingar i Java
linktitle: Reservteckensnittssamling
type: docs
weight: 20
url: /sv/java/create-fallback-fonts-collection/
keywords:
- reservteckensnitt
- reservregel
- teckensnittssamling
- konfigurera teckensnitt
- ställa in teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Skapa en reservteckensnittssamling i Aspose.Slides för Java för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av reservteckensnittregler för en presentation. Varje reservregel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar gränssnittet `IFontFallBackRulesCollection`.

Efter att du har skapat samlingen kan du tilldela den till egenskapen `FontFallBackRulesCollection` i presentationens `FontsManager`. `FontsManager` styr teckensnitt i hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med reservteckensnittssamlingen tillämpas de angivna reservteckensnitten under rendering av presentationen.

## **Tillämpa reservregler**

Instanser av klassen [FontFallBackRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRule) kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRulesCollection), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IFontFallBackRulesCollection) gränssnittet. Det går att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling tilldelas [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontFallBackRulesCollection)‑metoden i klassen [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager). FontsManager styr teckensnitt i hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) har en [getFontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getFontsManager--)‑metod med sin egen instans av klassen [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/FontsManager).

Här är ett exempel på hur man skapar en samling av reservteckensnittregler och tilldelar den till [FontsManager](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getFontsManager--) i en viss presentation:  

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IFontFallBackRulesCollection userRulesList = new FontFallBackRulesCollection();

    userRulesList.add(new FontFallBackRule(0x0B80, 0x0BFF, "Vijaya"));
    userRulesList.add(new FontFallBackRule(0x3040, 0x309F, "MS Mincho, MS Gothic"));

    pres.getFontsManager().setFontFallBackRulesCollection(userRulesList);
} finally {
    if (pres != null) pres.dispose();
}
```

Efter att FontsManager har initierats med reservteckensnittssamlingen tillämpas reservteckensnitten under rendering av presentationen.

{{% alert color="info" %}} 
Läs mer om hur man [Rendera presentation med reservteckensnitt](/slides/sv/java/render-presentation-with-fallback-font/).
{{% /alert %}}

## **FAQ**

### Kommer mina reservregler att bäddas in i PPTX-filen och vara synliga i PowerPoint efter sparning?

Nej. Reservregler är inställningar för rendering vid körning; de serialiseras inte till PPTX och kommer inte att visas i PowerPoints användargränssnitt.

### Gäller reservteckensnitt för text i SmartArt, WordArt, diagram och tabeller?

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

### Distribuerar Aspose några teckensnitt med biblioteket?

Nej. Du lägger till och använder teckensnitt på din sida och på eget ansvar.

### Kan ersättning/substitution för saknade teckensnitt och reserv för saknade glyfer användas tillsammans?

Ja. De är oberoende steg i samma teckensnittslösningspipeline: först löser motorn tillgänglighet för teckensnitt ([replacement](/slides/sv/java/font-replacement/)/[substitution](/slides/sv/java/font-substitution/)), sedan fyller reservteckensnitt luckorna för saknade glyfer i tillgängliga teckensnitt.