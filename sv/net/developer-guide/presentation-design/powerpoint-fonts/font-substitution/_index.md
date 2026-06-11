---
title: Konfigurera fontsubstitution i presentationer i .NET
linktitle: Fontsubstitution
type: docs
weight: 70
url: /sv/net/font-substitution/
keywords:
- font
- ersätt font
- fontsubstitution
- byt font
- fontbyte
- substitionsregel
- ersättningsregel
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Aktivera optimal fontsubstitution i Aspose.Slides för .NET när du konverterar PowerPoint- och OpenDocument-presentationer till andra filformat."
---
## **Översikt**

Fontsubstitution gör det möjligt för Aspose.Slides att använda ett annat typsnitt när det ursprungliga presentations‑typsnittet inte är tillgängligt under rendering eller konvertering. Du kan kontrollera vilka typsnitt som ersattes genom att använda `GetSubstitutions`‑metoden från `IFontsManager`‑gränssnittet.

Aspose.Slides låter dig också definiera regler för fontsubstitution. Till exempel kan du ange att ett otillgängligt typsnitt ska ersättas med ett annat tillgängligt typsnitt och sedan tillämpa dessa regler via presentationens typsnittshanterare.

## **Hämta fontsubstitutioner**

För att du ska kunna ta reda på vilka presentations‑typsnitt som ersätts under en renderingsprocess, erbjuder Aspose.Slides [GetSubstitution](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsmanager/getsubstitutions/)‑metoden från [IFontsManager](https://reference.aspose.com/slides/sv/net/aspose.slides/ifontsmanager/)‑gränssnittet.

C#‑koden visar hur du får alla fontsubstitutioner som utförs när en presentation renderas:
```c#
using (Presentation pres = new Presentation(@"Presentation.pptx"))
{
    foreach (var fontSubstitution in pres.FontsManager.GetSubstitutions())
    {
        Console.WriteLine("{0} -> {1}", fontSubstitution.OriginalFontName, fontSubstitution.SubstitutedFontName);
    }
}
```

## **Ställ in regler för fontsubstitution**

Aspose.Slides låter dig ange regler för typsnitt som bestämmer vad som ska göras under vissa förhållanden (till exempel när ett typsnitt inte kan nås) på följande sätt:

1. Läs in den relevanta presentationen.
2. Läs in typsnittet som ska ersättas.
3. Läs in det nya typsnittet.
4. Lägg till en regel för ersättningen.
5. Lägg till regeln i presentationens samling av font‑ersättningsregler.
6. Generera bild på bilden för att observera effekten.

Denna C#‑kod demonstrerar fontsubstitutionsprocessen:
```c#
// Laddar en presentation
Presentation presentation = new Presentation("Fonts.pptx");

// Laddar källtypsnittet som ska ersättas
IFontData sourceFont = new FontData("SomeRareFont");

// Laddar det nya typsnittet
IFontData destFont = new FontData("Arial");

// Lägger till en typsnittregel för typsnittsbyte
IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

// Lägger till regeln i samlingen av typsnittssubstitutionsregler
IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
fontSubstRuleCollection.Add(fontSubstRule);

// Lägger till typsnittregelssamlingen till regellistan
presentation.FontsManager.FontSubstRuleList = fontSubstRuleCollection;

using (IImage image = presentation.Slides[0].GetImage(1f, 1f))
{
    // Sparar bilden till disk i JPEG-format
    image.Save("Thumbnail_out.jpg", ImageFormat.Jpeg);
}
```

{{%  alert title="NOTE"  color="warning"   %}} 
Du kanske vill se [**Typsnittsbyte**](/slides/sv/net/font-replacement/). 
{{% /alert %}}

## **Begränsningar för matematiska ekvationstypsnitt**

Fontsubstitutionsregler deltar i den standardprocess för typsnittsval som används under rendering och konvertering. De är lämpliga för vanliga textscenarier där Aspose.Slides kan ersätta ett otillgängligt typsnitt med ett annat tillgängligt typsnitt enligt den konfigurerade regeln.

Dock har Office-mathematikekvationer en viktig begränsning. Om en ekvation skapades med **Cambria Math** kan Aspose.Slides fortfarande kräva det ursprungliga **Cambria Math**‑typsnittet för att beräkna och rendera ekvationslayouten korrekt. På grund av detta stöds inte ersättning av **Cambria Math** med ett annat matematiktypsnitt, såsom **STIX Two Math**, för ekvationsrendering och kan fortfarande resultera i ett undantag som indikerar att **Cambria Math** krävs.

För att konvertera sådana presentationer framgångsrikt, se till att **Cambria Math** är tillgängligt för Aspose.Slides vid körning. Du kan installera typsnittet i operativsystemet eller tillhandahålla det som ett [externa typsnitt](/slides/sv/net/custom-font/) så att det kan delta i den normala typsnittsväljarprocessen under rendering och konvertering.

Denna begränsning är specifik för ekvationsrendering. De standardfontsubstitutionsregler som beskrivits ovan gäller fortfarande för vanlig presentationstext när det ursprungliga typsnittet är otillgängligt.

## **FAQ**

**Vad är skillnaden mellan typsnittsersättning och typsnittsubstitution?**

[Replacement](/slides/sv/net/font-replacement/) är en tvångsöverskrivning av ett typsnitt med ett annat i hela presentationen. Substitution är en regel som aktiveras under ett specifikt villkor, till exempel när det ursprungliga typsnittet är otillgängligt, och då används ett angivet reservtypsnitt.

**När tillämpas substitutionsregler exakt?**

Reglerna deltar i den standard [font selection](/slides/sv/net/font-selection-sequence/) sekvens som utvärderas under laddning, rendering och konvertering; om det valda typsnittet är otillgängligt tillämpas ersättning eller substitution.

**Vad är standardbeteendet om varken ersättning eller substitution är konfigurerad och typsnittet saknas på systemet?**

Biblioteket kommer att försöka välja det närmaste tillgängliga systemtypsnittet, liknande hur PowerPoint skulle bete sig.

**Kan jag bifoga anpassade externa typsnitt vid körning för att undvika substitution?**

Ja. Du kan [lägga till externa typsnitt](/slides/sv/net/custom-font/) vid körning så att biblioteket beaktar dem för val och rendering, även för efterföljande konverteringar.

**Distribuerar Aspose några typsnitt med biblioteket?**

Nej. Aspose distribuerar inga betalda eller fria typsnitt; du lägger till och använder typsnitt på eget ansvar och eget gottfinnande.

**Finns det skillnader i substitionsbeteende på Windows, Linux och macOS?**

Ja. Typsnittsupptäckt startar från operativsystemets typsnittskataloger. Mängden standardtillgängliga typsnitt och sökvägarna skiljer sig åt mellan plattformar, vilket påverkar tillgänglighet och behovet av substitution.

**Hur bör jag förbereda miljön för att minimera oväntad substitution under batchkonverteringar?**

Synkronisera typsnittssamlingen över maskiner eller containrar, [lägg till de externa typsnitten](/slides/sv/net/custom-font/) som krävs för utdata‑dokumenten, och [bädda in typsnitt](/slides/sv/net/embedded-font/) i presentationer när det är möjligt så att de valda typsnitten är tillgängliga under rendering.