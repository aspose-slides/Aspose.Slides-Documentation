---
title: Konfigurera reservteckensnittssamlingar på Android
linktitle: Reservteckensnittssamling
type: docs
weight: 20
url: /sv/androidjava/create-fallback-fonts-collection/
keywords:
- reservteckensnitt
- reservregel
- teckensnittssamling
- konfigurera teckensnitt
- installera teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa en reservteckensnittssamling i Aspose.Slides för Android via Java för att hålla texten konsekvent och skarp i PowerPoint- och OpenDocument-presentationer."
---
## **Översikt**

Aspose.Slides låter dig konfigurera en samling av reservteckensnittregler för en presentation. Varje reservregel representeras av klassen `FontFallBackRule` och kan läggas till i en `FontFallBackRulesCollection`, som implementerar gränssnittet `IFontFallBackRulesCollection`.

Efter att du har skapat samlingen kan du tilldela den till `FontFallBackRulesCollection`‑egenskapen i presentationens `FontsManager`. `FontsManager` styr teckensnitt över hela presentationen, och varje `Presentation`‑instans har sin egen `FontsManager`.

När `FontsManager` har initierats med reservteckensnittssamlingen tillämpas de angivna reservteckensnitten under rendering av presentationen.

## **Tillämna reservregler**

Instanser av [FontFallBackRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRule) klassen kan organiseras i [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRulesCollection), som implementerar [IFontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IFontFallBackRulesCollection)‑gränssnittet. Det är möjligt att lägga till eller ta bort regler från samlingen.

Sedan kan denna samling tilldelas [FontFallBackRulesCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontFallBackRulesCollection)‑metoden i [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager)‑klassen. FontsManager styr teckensnitt över hela presentationen.

Varje [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) har en [getFontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getFontsManager--)‑metod med sin egen instans av klassen [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/FontsManager).

Här är ett exempel på hur du skapar en samling av reservteckensnittsregler och tilldelar den till [FontsManager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getFontsManager--) för en viss presentation:  

```java
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

När FontsManager har initierats med reservteckensnittssamlingen tillämpas reservteckensnitten under rendering av presentationen.

{{% alert color="primary" %}} 
Läs mer om hur du [Render Presentation with Fallback Font](/slides/sv/androidjava/render-presentation-with-fallback-font/).
{{% /alert %}}

## **Vanliga frågor**

**Kommer mina reservregler att bäddas in i PPTX-filen och vara synliga i PowerPoint efter sparning?**

Nej. Reservreglerna är inställningar för rendering vid körning; de serialiseras inte till PPTX och visas inte i PowerPoints användargränssnitt.

**Gäller reservteckensnitt för text i SmartArt, WordArt, diagram och tabeller?**

Ja. Samma glyf‑substitutionsmekanism används för all text i dessa objekt.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Du lägger till och använder teckensnitt på din sida och på eget ansvar.

**Kan ersättning/substitution för saknade teckensnitt och reserv för saknade glyfer användas tillsammans?**

Ja. De är oberoende steg i samma teckensnittslösningspipeline: först löser motorn teckensnittstillgänglighet ([replacement](/slides/sv/androidjava/font-replacement/)/[substitution](/slides/sv/androidjava/font-substitution/)), sedan fyller reservteckensnittet luckor för saknade glyfer i tillgängliga teckensnitt.