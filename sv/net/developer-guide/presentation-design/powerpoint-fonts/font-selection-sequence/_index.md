---
title: Typsnittsalternativsekvens i Aspose.Slides för .NET
linktitle: Typsnittsalternativ
type: docs
weight: 80
url: /sv/net/font-selection-sequence/
keywords:
- typsnittsalternativ
- typsnittssubstitution
- typsnittsersättning
- substitutionsregel
- tillgängligt typsnitt
- saknat typsnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för .NET väljer typsnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer—förbättra dina bildspel nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format, tar Aspose.Slides hänsyn till dess inbäddade typsnitt och de typsnitt som finns tillgängliga för applikationen. Om ett behövt typsnitt saknas väljer Aspose.Slides ett ersättningstypsnitt som är så nära som möjligt det som PowerPoint skulle använda.

Tillgängliga typsnitt kan omfatta systemtypsnitt, typsnitt som laddas av applikationen och typsnitt som är inbäddade i presentationen. För ett matchande inbäddat och registrerat typsnitt styr .NET 26.11‑inställningen som beskrivs nedan vilken som har prioritet. Typsnittssubstitueringsregler som definieras via [FontSubstRule](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) är en separat mekanism.

Du kan också lägga till typsnitt vid applikationens körning, använda inbäddade typsnitt från en presentation eller ladda externa typsnitt för utdatafiler såsom PDF-filer.

## **Typsnittsval**

Text kan referera till ett tematypsnitt, till exempel `+mn-lt`, istället för ett explicit familjenamn. Se [Resolve Theme Font References](/slides/sv/net/presentation-theme/#resolve-theme-font-references) för att få familjen som anges av det aktuella temat. Att lösa upp den referensen är separerat från att kontrollera typsnittstillgänglighet och tillämpa renderings‑tidens ersättning eller glyph‑fallback; den identifierar inte den typsnittsfil som slutligen används för att rendera texten.

När du renderar bilder eller konverterar en presentation, kontrollera att de begärda typsnitten är inbäddade eller tillgängliga från registrerade källor. Saknade typsnitt kan kräva ersättning eller substitution; se [**Font Replacement**](/slides/sv/net/font-replacement/) och [**Font Substitution**](/slides/sv/net/font-substitution/).

När du undersöker typsnittsval:

1. Lös upp den begärda familjen och stilen, inklusive eventuell temareferens.
2. Kontrollera inbäddade typsnitt och registrerade källor, inklusive systemtypsnitt och typsnitt som laddas av applikationen. Använd inställningen nedan när matchande inbäddade och registrerade versioner konkurrerar.
3. Granska [typsnitts substitueringsregler](https://reference.aspose.com/slides/net/aspose.slides/fontsubstrule/) och glyph‑fallback om det begärda typsnittet eller tecknen inte är tillgängliga.

Aspose.Slides låter dig lägga till typsnitt vid applikationens körning och sedan använda dessa typsnitt. Se [**Custom fonts**](/slides/sv/net/custom-font/).

När ytterligare typsnitt placeras i en presentation kallas de [**Embedded fonts**](/slides/sv/net/embedded-font/).

Aspose.Slides låter dig lägga till typsnitt som endast tillämpas på *utdokument*. Till exempel, om en presentation du vill konvertera till PDF innehåller typsnitt som saknas i ditt system och inbäddade typsnitt, kan du lägga till eller ladda de nödvändiga typsnitten som **external fonts**.

{{% alert title="Note" color="info" %}} 
Vi distribuerar inga typsnitt, varken betalda eller gratis. Vårt API låter dig läsa in externa typsnitt och bädda in dem i dokument, men du gör det med typsnitt på ditt eget gottfinnande och ansvar.
{{% /alert %}}

## **Föredra registrerade typsnitt framför inbäddade typsnitt**

Från och med .NET 26.11 låter [IFontsManager.PreferRegisteredFontsOverEmbedded](https://reference.aspose.com/slides/net/aspose.slides/ifontsmanager/preferregisteredfontsoverembedded/) ett matchande registrerat typsnitt ha prioritet framför ett inbäddat typsnitt vid export. Standardvärdet är `false`. Matchning använder typsnittsnamnet och stilen; ett annat familjenamn är inte en ersättningsmatch. Registrerade typsnitt kan komma från systemet eller [explicit inlästa typsnittskällor](/slides/sv/net/custom-font/).

Följande exempel använder paketet **Aspose.Slides.NET6.CrossPlatform 26.11** på .NET 8. Följ [installationsguide](/slides/sv/net/installation/) för din miljö. Tillhandahåll `embedded-fonts.pptx` med ett inbäddat typsnitt och `preferred.ttf` med samma familjenamn och stil. De två typsnittsfilena bör skilja sig synligt om du vill jämföra resultatet.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var fontBytes = File.ReadAllBytes("preferred.ttf");
FontsLoader.LoadExternalFont(fontBytes);
using var presentation = new Presentation("embedded-fonts.pptx");

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("embedded-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = true;
presentation.Save("registered-preference.pdf", SaveFormat.Pdf);

presentation.FontsManager.PreferRegisteredFontsOverEmbedded = false;
presentation.Save("restored-preference.pdf", SaveFormat.Pdf);
```

Denna inställning ändrar typsnittsprioriteten under export; den byter inte namn på textens typsnitt, tar inte bort inbäddade typsnittsdata eller återbäddar den registrerade filen. Det är en runtime‑inställning: ställ in den igen efter att ha öppnat en presentation på nytt. Om inget matchande registrerat typsnitt är tillgängligt ger inte aktiveringen av preferensen ett sådant; verifiera det resulterande typsnittet och layouten i din målmiljö.

PNG‑ och PDF‑utdata med explicit inlästa vanliga typsnitt kontrollerades för konfigurationen ovan. Kontrollera dina egna typsnitts‑filer, stilar, SDK‑byggnad och utdataformat innan du förlitar dig på identiska resultat. Typsnittsmått kan förändra radbrytningar och positionering. Använd [typsnittsersättning](/slides/sv/net/font-replacement/) eller [substitution](/slides/sv/net/font-substitution/) när du behöver en annan familj, och [operationer för inbäddade typsnitt](/slides/sv/net/embedded-font/) när du behöver ändra de typsnitt som lagras i presentationen.

## **FAQ**

**Hur kan jag avgöra vilka typsnitt som faktiskt används i en presentation före konvertering?**

Aspose.Slides låter dig inspektera de använda typsnitten via [typsnittshanteraren](https://reference.aspose.com/slides/net/aspose.slides/presentation/fontsmanager/), så att du kan besluta om du ska [bädda in](/slides/sv/net/embedded-font/), [ersätta](/slides/sv/net/font-replacement/), eller lägga till [externa källor](/slides/sv/net/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

**Kan jag lägga till extra typsnittskataloger utan att installera dem på operativsystemet?**

Ja. Du kan registrera [externa typsnittskällor](/slides/sv/net/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets typsnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst fallback till ett olämpligt typsnitt när en glyph saknas?**

Definiera explicit [typsnittsersättning](/slides/sv/net/font-replacement/) och typsnitt [fallback‑regler](/slides/sv/net/fallback-font/) i förväg. Genom att analysera använda typsnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du konsekvent typografi och undviker oväntade resultat.