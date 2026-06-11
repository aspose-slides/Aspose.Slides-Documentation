---
title: Konfigurera fontsubstitution i presentationer med Python
linktitle: Fontsubstitution
type: docs
weight: 70
url: /sv/python-net/font-substitution/
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
- Python
- Aspose.Slides
description: "Aktivera optimal teckensnittssubstitution i Aspose.Slides för Python via .NET när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat."
---
## **Översikt**

Fontsubstitution gör att Aspose.Slides kan använda ett annat teckensnitt när det ursprungliga teckensnittet i presentationen inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda metoden `get_substitutions` från klassen `FontsManager`.

Aspose.Slides låter dig även definiera regler för fontsubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ställ in substitutionsregler**

Aspose.Slides allows you to set rules for fonts that determines what must be done in certain conditions (for example, when a font cannot be accessed) this way:

1. Läs in den relevanta presentationen.
2. Läs in teckensnittet som ska ersättas.
3. Läs in det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i samlingen av teckensnittsersättningsregler för presentationen.
6. Generera bild av bilden för att observera effekten.

Denna Python‑kod demonstrerar fontsubstitutionsprocessen:

```python
import aspose.slides as slides

# Läser in en presentation
with slides.Presentation(path + "Fonts.pptx") as presentation:
    # Läser in källteckensnittet som ska ersättas
    sourceFont = slides.FontData("SomeRareFont")

    # Läser in det nya teckensnittet
    destFont = slides.FontData("Arial")

    # Lägger till en teckensnittregel för teckensnittsbyte
    fontSubstRule = slides.FontSubstRule(sourceFont, destFont, slides.FontSubstCondition.WHEN_INACCESSIBLE)

    # Lägger till regeln i samlingen av teckensnittsersättningsregler
    fontSubstRuleCollection = slides.FontSubstRuleCollection()
    fontSubstRuleCollection.add(fontSubstRule)

    # Lägger till teckensnittregelssamlingen i regellistan
    presentation.fonts_manager.font_subst_rule_list = fontSubstRuleCollection

    #Arial teckensnittet kommer att användas i stället för SomeRareFont när det sistnämnda är otillgängligt
    with presentation.slides[0].get_image(1, 1) as bmp:
        # Sparar bilden till disk i JPEG-format
        bmp.save("Thumbnail_out.jpg", slides.ImageFormat.JPEG)
```

{{%  alert title="NOTE"  color="warning"   %}} 

Du kanske vill se [**Fontbyte**](/slides/sv/python-net/font-replacement/). 

{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Fontsubstitutionsregler deltar i den standardiserade teckensnittsväljarprocessen som används vid rendering och konvertering. De är lämpliga för vanliga textscenario där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Dock har Office‑matematiska ekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**‑teckensnittet för att korrekt beräkna och rendera ekvationens layout. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och kan fortfarande leda till ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [externt teckensnitt](/slides/sv/python-net/custom-font/) så att det kan delta i den normala teckensnittsväljarprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardfontsubstitutionsregler som beskrivits ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan fontbyte och fontsubstitution?**

[Byte](/slides/sv/python-net/font-replacement/) är en tvångsmässig överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som aktiveras under ett specifikt villkor, till exempel när det ursprungliga teckensnittet är otillgängligt, och då används ett angivet reservteckensnitt.

**När exakt tillämpas substitutionsregler?**

Reglerna deltar i den standard [teckensnittsväljar](/slides/sv/python-net/font-selection-sequence/) sekvensen som utvärderas under inläsning, rendering och konvertering; om det valda teckensnittet är otillgängligt tillämpas byte eller substitution.

**Vad är standardbeteendet om varken byte eller substitution är konfigurerade och teckensnittet saknas i systemet?**

Biblioteket försöker då välja det närmaste tillgängliga systemteckensnittet, liknande hur PowerPoint skulle fungera.

**Kan jag bifoga anpassade externa teckensnitt vid körning för att undvika substitution?**

Ja. Du kan [lägga till externa teckensnitt](/slides/sv/python-net/custom-font/) vid körning så att biblioteket tar dem i beaktande för val och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Aspose distribuerar varken betalda eller gratis teckensnitt; du lägger till och använder teckensnitt efter eget gottfinnande och ansvar.

**Finns det skillnader i substitutionsbeteende på Windows, Linux och macOS?**

Ja. Teckensnittsidentifiering startar från operativsystemets teckensnittskataloger. Mängden standardtillgängliga teckensnitt och sökvägarna varierar mellan plattformar, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**

Synkronisera teckensnittssatsen över maskiner eller containrar, [lägg till de externa teckensnitten](/slides/sv/python-net/custom-font/) som krävs för utgångsdokumenten, och [bädda in teckensnitt](/slides/sv/python-net/embedded-font/) i presentationer när det är möjligt så att de valda teckensnitten är tillgängliga under rendering.