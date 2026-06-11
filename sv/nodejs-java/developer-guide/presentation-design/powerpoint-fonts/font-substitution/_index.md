---
title: Konfigurera teckensnittssubstitution i presentationer med JavaScript
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/nodejs-java/font-substitution/
keywords:
- teckensnitt
- ersätta teckensnitt
- teckensnittssubstitution
- byta teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Aktivera optimal teckensnittssubstitution i Aspose.Slides för Node.js när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat i JavaScript."
---
## **Översikt**

Teckensnittssubstitution gör att Aspose.Slides kan använda ett annat teckensnitt när det ursprungliga teckensnittet i presentationen inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda `getSubstitutions`‑metoden från `FontsManager`‑klassen.

Aspose.Slides låter dig även definiera regler för teckensnittssubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ställ in regler för teckensnittssubstitution**

Aspose.Slides tillåter dig att ange regler för teckensnitt som bestämmer vad som ska göras i vissa situationer (till exempel när ett teckensnitt inte kan nås) på detta sätt:

1. Läs in den relevanta presentationen.
2. Läs in teckensnittet som ska ersättas.
3. Läs in det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i samlingen av teckensnittsersättningsregler för presentationen.
6. Generera bild för bilden för att observera resultatet.

Denna JavaScript‑kod demonstrerar processen för teckensnittssubstitution:

```javascript
// Laddar en presentation
var pres = new aspose.slides.Presentation("Fonts.pptx");
try {
    // Laddar källteckensnittet som ska ersättas
    var sourceFont = new aspose.slides.FontData("SomeRareFont");
    // Laddar det nya teckensnittet
    var destFont = new aspose.slides.FontData("Arial");
    // Lägger till en teckensnittregel för teckensnittsersättning
    var fontSubstRule = new aspose.slides.FontSubstRule(sourceFont, destFont, aspose.slides.FontSubstCondition.WhenInaccessible);
    // Lägger till regeln i samlingen av teckensnittsersättningsregler
    var fontSubstRuleCollection = new aspose.slides.FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    // Lägger till en teckensnittregelsamling i regellistan
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    // Arial-teckensnittet kommer att användas i stället för SomeRareFont när det sistnämnda är otillgängligt
    var slideImage = pres.getSlides().get_Item(0).getImage(1.0, 1.0);
    // Sparar bilden till disk i JPEG-format
    try {
        slideImage.save("Thumbnail_out.jpg", aspose.slides.ImageFormat.Jpeg);
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

{{%  alert title="NOTE"  color="warning"   %}} 

Du kanske vill se [**Font Replacement**](/slides/sv/nodejs-java/font-replacement/).

{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Regler för teckensnittssubstitution deltar i den standardiserade processen för teckensnittsurval som används under rendering och konvertering. De är lämpliga för vanliga textsituationer där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Dock har Office‑matteekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**‑teckensnittet för att beräkna och rendera ekvationens layout korrekt. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matte‑teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och kan fortfarande resultera i ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [external font](/slides/sv/nodejs-java/custom-font/) så att det kan delta i den normala teckensnittsurvalsprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardregler för teckensnittssubstitution som beskrivits ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Replacement](/slides/sv/nodejs-java/font-replacement/) är en tvingad överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som triggas under ett specifikt villkor, till exempel när det ursprungliga teckensnittet är otillgängligt, och då används ett bestämt reservteckensnitt.

**När tillämpas subdivisionsregler exakt?**

Reglerna deltar i den standardiserade [font selection](/slides/sv/nodejs-java/font-selection-sequence/) sekvensen som utvärderas under inläsning, rendering och konvertering; om det valda teckensnittet är otillgängligt tillämpas ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och teckensnittet saknas på systemet?**

Biblioteket kommer att försöka välja det närmaste tillgängliga systemteckensnittet, likt hur PowerPoint skulle agera.

**Kan jag bifoga anpassade externa teckensnitt vid körning för att undvika substitution?**

Ja. Du kan [add external fonts](/slides/sv/nodejs-java/custom-font/) vid körning så att biblioteket tar dem i beaktande vid urval och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Aspose distribuerar inga betalda eller gratis teckensnitt; du lägger till och använder teckensnitt efter eget gottfinnande och ansvar.

**Finns det skillnader i substitutionsbeteende på Windows, Linux och macOS?**

Ja. Teckensnittsidentifiering startar i operativsystemets teckensnittskataloger. Mängden standardtillgängliga teckensnitt och sökvägarna varierar mellan plattformarna, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**

Synkronisera teckensnittssamlingen över maskiner eller containrar, [add the external fonts](/slides/sv/nodejs-java/custom-font/) som krävs för utsaktdokumenten, och [embed fonts](/slides/sv/nodejs-java/embedded-font/) i presentationer när det är möjligt så de valda teckensnitten är tillgängliga under rendering.