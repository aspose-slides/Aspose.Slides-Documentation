---
title: Konfigurera teckensnittssubstitution i presentationer med PHP
linktitle: Teckensnittssubstitution
type: docs
weight: 70
url: /sv/php-java/font-substitution/
keywords:
- teckensnitt
- ersätt teckensnitt
- teckensnittssubstitution
- ersätta teckensnitt
- teckensnittsersättning
- substitionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Aktivera optimal teckensnittssubstitution i Aspose.Slides för PHP via Java när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat."
---
## **Introduktion**

Teckensnittssubstitution tillåter Aspose.Slides att använda ett annat teckensnitt när det ursprungliga presentationsteckensnittet inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda metoden `getSubstitutions` från klassen `FontsManager`.

Aspose.Slides låter dig också definiera regler för teckensnittssubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ange regler för teckensnittssubstitution**

Aspose.Slides låter dig ange regler för teckensnitt som bestämmer vad som ska göras i vissa situationer (till exempel när ett teckensnitt inte kan nås) på följande sätt:

1. Läs in den relevanta presentationen.
2. Läs in teckensnittet som ska ersättas.
3. Läs in det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i presentationens samling av teckensnittsersättningsregler.
6. Generera bild av sliden för att observera effekten.

Den här PHP-koden demonstrerar teckensnittssubstitutionsprocessen:

```php
  # Laddar en presentation
  $pres = new Presentation("Fonts.pptx");
  try {
    # Laddar källteckensnittet som kommer att ersättas
    $sourceFont = new FontData("SomeRareFont");
    # Laddar det nya teckensnittet
    $destFont = new FontData("Arial");
    # Lägger till en teckensnittregel för teckensnittsersättning
    $fontSubstRule = new FontSubstRule($sourceFont, $destFont, FontSubstCondition->WhenInaccessible);
    # Lägger till regeln i samlingen av teckensnittsersättningsregler
    $fontSubstRuleCollection = new FontSubstRuleCollection();
    $fontSubstRuleCollection->add($fontSubstRule);
    # Lägger till en teckensnittregelsamling till regellistan
    $pres->getFontsManager()->setFontSubstRuleList($fontSubstRuleCollection);
    # Arial-teckensnittet kommer att användas istället för SomeRareFont när det senare är otillgängligt
    $slideImage = $pres->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    # Sparar bilden till disk i JPEG-format
    try {
      $slideImage->save("Thumbnail_out.jpg", ImageFormat::Jpeg);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert title="NOTE"  color="warning"   %}} 

Du kanske vill se [**Font Replacement**](/slides/sv/php-java/font-replacement/).

{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Regler för teckensnittssubstitution deltar i den standardteckensnittsväljningsprocess som används under rendering och konvertering. De är lämpliga för vanliga textscenarier där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Dock har Office-matematikekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**-teckensnittet för att korrekt beräkna och rendera ekvationslayouten. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och kan fortfarande leda till ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [external font](/slides/sv/php-java/custom-font/) så att det kan delta i den normala teckensnittsväljningsprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardregler för teckensnittssubstitution som beskrivits ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan teckensnittsersättning och teckensnittssubstitution?**

[Replacement](/slides/sv/php-java/font-replacement/) är en tvingad överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som triggas under ett specifikt villkor, till exempel när det ursprungliga teckensnittet inte är tillgängligt, och då används ett utsedd reservteckensnitt.

**När tillämpas substitutionsregler exakt?**

Reglerna deltar i den standard [font selection](/slides/sv/php-java/font-selection-sequence/) sekvens som utvärderas under inläsning, rendering och konvertering; om det valda teckensnittet är otillgängligt tillämpas ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och teckensnittet saknas i systemet?**

Biblioteket kommer att försöka välja det närmaste tillgängliga systemteckensnittet, liknande hur PowerPoint skulle bete sig.

**Kan jag bifoga anpassade externa teckensnitt vid körning för att undvika substitution?**

Ja. Du kan [add external fonts](/slides/sv/php-java/custom-font/) vid körning så att biblioteket tar dem i beaktande för val och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Aspose distribuerar inga betalda eller gratis teckensnitt; du lägger till och använder teckensnitt på eget ansvar och eget gottfinnande.

**Finns det skillnader i substitutionsbeteende på Windows, Linux och macOS?**

Ja. Upptäckt av teckensnitt börjar i operativsystemets teckensnittskataloger. Mängden standardtillgängliga teckensnitt och sökvägarna varierar mellan plattformar, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**

Synkronisera teckensnittssatsen över maskiner eller containrar, [add the external fonts](/slides/sv/php-java/custom-font/) som krävs för utgångsdokumenten, och [embed fonts](/slides/sv/php-java/embedded-font/) i presentationer när det är möjligt så att de valda teckensnitten är tillgängliga under rendering.