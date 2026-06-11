---
title: Konfigurera teckensnittssubstitution i presentationer på Android
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/androidjava/font-substitution/
keywords:
- teckensnitt
- ersätta teckensnitt
- teckensnittssubstitution
- ersätta teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Aktivera optimal teckensnittssubstitution i Aspose.Slides för Android via Java när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat."
---
## **Översikt**

Teckensnittssubstitution gör att Aspose.Slides kan använda ett annat teckensnitt när det ursprungliga teckensnittet i presentationen inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda metoden `getSubstitutions` från gränssnittet `IFontsManager`.

Aspose.Slides låter dig också definiera regler för teckensnittssubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ange regler för teckensnittssubstitution**

Aspose.Slides låter dig ange regler för teckensnitt som bestämmer vad som ska göras under vissa förhållanden (till exempel när ett teckensnitt inte kan nås) på följande sätt:

1. Läs in den relevanta presentationen.
2. Läs in teckensnittet som ska ersättas.
3. Läs in det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i presentationens samling av teckensnittsersättningsregler.
6. Generera bild för sliden för att observera effekten.

Denna Java‑kod demonstrerar teckensnittssubstitutionsprocessen:

```java
// Laddar en presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laddar källteckensnittet som kommer att ersättas
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Laddar det nya teckensnittet
    IFontData destFont = new FontData("Arial");
    
    // Lägger till en teckensnittsregel för teckensnittsersättning
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Lägger till regeln i samlingen av teckensnittsersättningsregler
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Lägger till en teckensnittsregelssamling till regellistan
    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);
    
    // Arial-teckensnittet kommer att användas i stället för SomeRareFont när det sistnämnda är otillgängligt
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1f, 1f);
    
    // Sparar bilden till disk i JPEG-format
    try {
          slideImage.save("Thumbnail_out.jpg", ImageFormat.Jpeg);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert title="NOTE"  color="warning"   %}} 

Du kanske vill se [**Teckensnittsersättning**](/slides/sv/androidjava/font-replacement/).

{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Regler för teckensnittssubstitution deltar i den vanliga teckensnittsvalprocessen som används under rendering och konvertering. De är lämpliga för vanliga textscenarier där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Dock har Office-matematikekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**‑teckensnittet för att beräkna och rendera ekvationslayouten korrekt. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och kan fortfarande leda till ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [externt teckensnitt](/slides/sv/androidjava/custom-font/) så att det kan delta i den normala teckensnittsvalprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardregler för teckensnittssubstitution som beskrivs ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Replacement](/slides/sv/androidjava/font-replacement/) är en tvingad överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som aktiveras under ett specifikt villkor, till exempel när det ursprungliga teckensnittet är otillgängligt, och då används ett angivet reservteckensnitt.

**När exakt tillämpas substitueringsreglerna?**

Reglerna deltar i den standard [font selection](/slides/sv/androidjava/font-selection-sequence/) sekvensen som utvärderas under inläsning, rendering och konvertering; om det valda teckensnittet är otillgängligt tillämpas ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och teckensnittet saknas på systemet?**

Biblioteket kommer att försöka välja det närmaste tillgängliga systemteckensnittet, på liknande sätt som PowerPoint skulle göra.

**Kan jag bifoga anpassade externa teckensnitt vid körning för att undvika substitution?**

Ja. Du kan [add external fonts](/slides/sv/androidjava/custom-font/) vid körning så att biblioteket beaktar dem för val och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Aspose distribuerar inga betalda eller gratis teckensnitt; du lägger till och använder teckensnitt efter eget gottfinnande och ansvar.

**Finns det skillnader i substitueringsbeteende på Windows, Linux och macOS?**

Ja. Teckensnittsidentifiering startar i operativsystemets teckensnittskataloger. Uppsättningen av standardtillgängliga teckensnitt och sökvägarna skiljer sig åt mellan plattformarna, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batch‑konverteringar?**

Synkronisera teckensnittssamlingen över maskiner eller containrar, [add the external fonts](/slides/sv/androidjava/custom-font/) som krävs för utdatafilerna, och [embed fonts](/slides/sv/androidjava/embedded-font/) i presentationer när det är möjligt så att de valda teckensnitten är tillgängliga under rendering.