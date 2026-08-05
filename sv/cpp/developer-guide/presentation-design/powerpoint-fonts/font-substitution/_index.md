---
title: Konfigurera teckensnittsbyte i presentationer med C++
linktitle: Teckensnittsbyte
type: docs
weight: 70
url: /sv/cpp/font-substitution/
keywords:
- teckensnitt
- substituera teckensnitt
- teckensnittsbyte
- ersätta teckensnitt
- teckensnittsersättning
- substitutionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Aktivera optimal teckensnittsbyte i Aspose.Slides för C++ när du konverterar PowerPoint och OpenDocument-presentationer till andra filformat."
---
## **Översikt**

Fontsubstitution gör det möjligt för Aspose.Slides att använda ett annat teckensnitt när det ursprungliga teckensnittet i presentationen inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka teckensnitt som ersattes genom att använda metoden `GetSubstitutions` från gränssnittet `IFontsManager`.

Aspose.Slides låter dig också definiera regler för fontsubstitution. Till exempel kan du ange att ett otillgängligt teckensnitt ska ersättas med ett annat tillgängligt teckensnitt och sedan tillämpa dessa regler via presentationens teckensnittshanterare.

## **Ange fontsubstitutionsregler**

Aspose.Slides låter dig ange regler för teckensnitt som bestämmer vad som ska göras under vissa förhållanden (t.ex. när ett teckensnitt inte kan nås) på följande sätt:

1. Ladda den relevanta presentationen.
2. Ladda teckensnittet som ska ersättas.
3. Ladda det nya teckensnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i samlingen av fontersättningsregler för presentationen.
6. Generera en bild av bilden för att observera effekten.

Denna C++-kod demonstrerar fontsubstitutionsprocessen:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/RuleBasedFontsReplacement_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Laddar en presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Definierar teckensnittet som ska ersättas och det nya teckensnittet
SharedPtr<IFontData> sourceFont = MakeObject<FontData>(u"SomeRareFont");
SharedPtr<IFontData> destFont = MakeObject<FontData>(u"Arial");
	
// Lägger till en teckensnittsregel för teckensnittsersättning
SharedPtr<FontSubstRule> fontSubstRule = MakeObject<FontSubstRule>(sourceFont, destFont, FontSubstCondition::WhenInaccessible);

// Lägger till regeln i samlingen av teckensnittsbytesregler
SharedPtr<FontSubstRuleCollection> fontSubstRuleCollection = MakeObject<FontSubstRuleCollection>();
fontSubstRuleCollection->Add(fontSubstRule);

// Lägger till teckensnittsregelssamlingen i regellistan
pres->get_FontsManager()->set_FontSubstRuleList ( fontSubstRuleCollection);


// Sparar PPTX till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert title="NOTE"  color="warning"   %}} 

Du kanske vill se [**Font Replacement**](/slides/sv/cpp/font-replacement/). 

{{% /alert %}}

## **Begränsningar för matematiska ekvations­teckensnitt**

Fontsubstitutionsregler deltar i den standardprocess för teckensnittsurval som används vid rendering och konvertering. De är lämpliga för vanliga textscenarier där Aspose.Slides kan ersätta ett otillgängligt teckensnitt med ett annat tillgängligt teckensnitt enligt den konfigurerade regeln.

Dock har Office‑matteekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**‑teckensnittet för att beräkna och rendera ekvationslayouten korrekt. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matematiskt teckensnitt, såsom **STIX Two Math**, för ekvationsrendering och kan fortfarande leda till ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera teckensnittet i operativsystemet eller tillhandahålla det som ett [external font](/slides/sv/cpp/custom-font/) så att det kan delta i den normala teckensnittsurvalsprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardfontsubstitutionsregler som beskrivits ovan gäller fortfarande för vanlig presentationstext när det ursprungliga teckensnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan fontersättning och fontsubstitution?**

[Replacement](/slides/sv/cpp/font-replacement/) är en tvingad överskrivning av ett teckensnitt med ett annat i hela presentationen. Substitution är en regel som triggas under ett specifikt villkor, till exempel när det ursprungliga teckensnittet är otillgängligt, och då används ett bestämt reservteckensnitt.

**När exakt tillämpas substitueringsregler?**

Reglerna deltar i den standard [font selection](/slides/sv/cpp/font-selection-sequence/) sekvens som utvärderas under laddning, rendering och konvertering; om det valda teckensnittet är otillgängligt tillämpas ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och teckensnittet saknas i systemet?**

Biblioteket kommer att försöka välja det närmaste tillgängliga systemteckensnittet, liknande hur PowerPoint skulle bete sig.

**Kan jag bifoga anpassade externa teckensnitt vid körning för att undvika substitution?**

Ja. Du kan [add external fonts](/slides/sv/cpp/custom-font/) vid körning så att biblioteket tar dem i beaktning för urval och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några teckensnitt med biblioteket?**

Nej. Aspose distribuerar inga betalda eller fria teckensnitt; du lägger till och använder teckensnitt på egen ansvar och efter eget gottfinnande.

**Finns det skillnader i substitueringsbeteende på Windows, Linux och macOS?**

Ja. Teckensnittsupptäckt startar från operativsystemets teckensnittskataloger. Mängden standardtillgängliga teckensnitt och sökvägarna skiljer sig åt mellan plattformar, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**

Synkronisera teckensnittssatsen över maskiner eller containrar, [add the external fonts](/slides/sv/cpp/custom-font/) som krävs för utdata‑dokumenten, och [embed fonts](/slides/sv/cpp/embedded-font/) i presentationer när det är möjligt så att de valda teckensnitten är tillgängliga under rendering.