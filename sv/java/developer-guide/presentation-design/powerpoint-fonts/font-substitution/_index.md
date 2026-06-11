---
title: Konfigurera fontsubstitution i presentationer med Java
linktitle: Fontsubstitution
type: docs
weight: 70
url: /sv/java/font-substitution/
keywords:
- teckensnitt
- ersätta teckensnitt
- teckensnittsubstitution
- ersätt teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Aktivera optimal fontsubstitution i Aspose.Slides för Java när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat."
---
## **Översikt**

Fontsubstitution gör det möjligt för Aspose.Slides att använda ett annat teckensnitt när det ursprungliga teckensnittet i presentationen inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda metoden `getSubstitutions` från gränssnittet `IFontsManager`.

Aspose.Slides låter dig också definiera regler för fontsubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ange regler för fontsubstitution**

Aspose.Slides låter dig ange regler för teckensnitt som bestämmer vad som ska göras under vissa förhållanden (t.ex. när ett teckensnitt inte kan nås) på följande sätt:

1. Ladda den relevanta presentationen.
2. Ladda teckensnittet som ska ersättas.
3. Ladda det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i samlingen av teckensnittsersättningsregler för presentationen.
6. Generera en bild av sliden för att se effekten.

Denna Java‑kod demonstrerar processen för fontsubstitution:

```java
// Laddar en presentation
Presentation pres = new Presentation("Fonts.pptx");
try {
    // Laddar källteckensnittet som ska ersättas
    IFontData sourceFont = new FontData("SomeRareFont");
    
    // Laddar det nya teckensnittet
    IFontData destFont = new FontData("Arial");
    
    // Lägger till en teckensnittsregel för teckensnittsbyte
    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);
    
    // Lägger till regeln i samlingen av teckensnittsbytesregler
    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);
    
    // Lägger till en teckensnittsregelssamling i regellistan
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
Du kanske vill se [**Teckensnittsbyte**](/slides/sv/java/font-replacement/). 
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Regler för fontsubstitution deltar i den standardmässiga teckensnittsurvalprocessen som används under rendering och konvertering. De är lämpliga för vanliga textscenario där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Dock har Office‑matteekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**‑teckensnittet för att korrekt beräkna och rendera ekvationslayouten. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och det kan fortfarande leda till ett undantag som visar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [externt teckensnitt](/slides/sv/java/custom-font/) så att det kan delta i den normala teckensnittsurvalprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardregler för fontsubstitution som beskrivits ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan teckensnittsbyte och fontsubstitution?**

[Byte](/slides/sv/java/font-replacement/) är en tvångsmässig överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som aktiveras under ett specifikt villkor, till exempel när det ursprungliga teckensnittet är otillgängligt, och då används ett angivet reservteckensnitt.

**När exakt tillämpas substitutionsregler?**

Reglerna deltar i den standardmässiga [teckensnittsurval](/slides/sv/java/font-selection-sequence/) sekvensen som utvärderas under inläsning, rendering och konvertering; om det valda teckensnittet är otillgängligt appliceras ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och teckensnittet saknas på systemet?**

Biblioteket försöker välja det närmaste tillgängliga systemteckensnittet, likt hur PowerPoint skulle agera.

**Kan jag bifoga anpassade externa teckensnitt vid körning för att undvika substitution?**

Ja. Du kan [lägga till externa teckensnitt](/slides/sv/java/custom-font/) vid körning så att biblioteket tar dem i beaktande för urval och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Aspose distribuerar inga betalda eller gratis teckensnitt; du lägger till och använder teckensnitt på egen beslutsfattning och ansvar.

**Finns det skillnader i substitutionsbeteende på Windows, Linux och macOS?**

Ja. Teckensnittsökning startar från operativsystemets teckensnittskataloger. Mängden standardtillgängliga teckensnitt och sökvägarna skiljer sig åt mellan plattformarna, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**

Synkronisera teckensnittssamlingen över maskiner eller containrar, [lägg till de externa teckensnitten](/slides/sv/java/custom-font/) som krävs för utmatningsdokumenten, och [bädda in teckensnitt](/slides/sv/java/embedded-font/) i presentationer när det är möjligt så att de valda teckensnitten är tillgängliga under rendering.