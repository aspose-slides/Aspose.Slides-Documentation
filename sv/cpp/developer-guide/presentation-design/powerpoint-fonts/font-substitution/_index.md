---
title: Konfigurera fontsubstitution i presentationer med C++
linktitle: Fontsubstitution
type: docs
weight: 70
url: /sv/cpp/font-substitution/
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
- C++
- Aspose.Slides
description: "Aktivera optimal fontsubstitution i Aspose.Slides för C++ när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat."
---
## **Översikt**

Fontsubstitution tillåter Aspose.Slides att använda ett annat teckensnitt när det ursprungliga presentationsteckensnittet inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda metoden `GetSubstitutions` från gränssnittet `IFontsManager`.

Aspose.Slides tillåter också att du definierar regler för fontsubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ställ in fontsubstitutionsregler**

Aspose.Slides låter dig ange regler för teckensnitt som bestämmer vad som ska göras i vissa situationer (till exempel när ett teckensnitt inte kan nås) på följande sätt:

1. Läs in den relevanta presentationen.
2. Läs in teckensnittet som ska ersättas.
3. Läs in det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i presentationens samling av teckensnittsersättningsregler.
6. Generera bild för bilden för att observera effekten.

Denna C++-kod demonstrerar processen för fontsubstitution:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Laddar en presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definierar teckensnittet som ska ersättas och det nya teckensnittet
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Lägger till en teckensnittregel för teckensnittsersättning
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Lägger till regeln i samlingen av teckensnittsersättningsregler
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Lägger till teckensnittregelsamlingen i regellistan
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Sparar PPTX till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 
Du kanske vill se [**Fontersättning**](/slides/sv/cpp/font-replacement/). 
{{% /alert %}}

## **Begränsningar för matematiska ekvationsteckensnitt**

Fontsubstitutionsregler deltar i den vanliga teckensnittsväljsprocessen som används under rendering och konvertering. De är lämpliga för vanliga textsituationer där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Men Office-matematikekvationer har en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**-teckensnittet för att beräkna och rendera ekvationslayouten korrekt. På grund av detta stöds det inte att ersätta **Cambria Math** med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och det kan fortfarande leda till ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [externt teckensnitt](/slides/sv/cpp/custom-font/) så att det kan delta i den normala teckensnittsväljsprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardfontsubstitutionsregler som beskrivs ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan fontersättning och fontsubstitution?**  
[Replacement](/slides/sv/cpp/font-replacement/) är en tvingad överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som triggas under ett specifikt villkor, till exempel när det ursprungliga teckensnittet är otillgängligt, och då används ett angivet reservteckensnitt.

**När exakt tillämpas substitutionsregler?**  
Reglerna deltar i den vanliga [font selection](/slides/sv/cpp/font-selection-sequence/) sekvensen som utvärderas under laddning, rendering och konvertering; om det valda teckensnittet är otillgängligt tillämpas ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och teckensnittet saknas på systemet?**  
Biblioteket kommer att försöka välja det närmaste tillgängliga systemteckensnittet, liknande hur PowerPoint skulle bete sig.

**Kan jag bifoga egna externa teckensnitt vid körning för att undvika substitution?**  
Ja. Du kan [lägga till externa teckensnitt](/slides/sv/cpp/custom-font/) vid körning så att biblioteket tar dem i beaktning för val och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**  
Nej. Aspose distribuerar inte betalda eller gratis teckensnitt; du lägger till och använder teckensnitt på eget ansvar och egen fri vilja.

**Finns det skillnader i substitutionsbeteende på Windows, Linux och macOS?**  
Ja. Teckensnittsupptäckt startar från operativsystemets teckensnittskataloger. Mängden av standardtillgängliga teckensnitt och sökvägarna skiljer sig åt mellan plattformar, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**  
Synkronisera teckensnittssamlingen över maskiner eller containrar, [lägg till de externa teckensnitten](/slides/sv/cpp/custom-font/) som krävs för utgångsdokumenten, och [bädda in teckensnitt](/slides/sv/cpp/embedded-font/) i presentationer när det är möjligt så att de valda teckensnitten är tillgängliga under rendering.