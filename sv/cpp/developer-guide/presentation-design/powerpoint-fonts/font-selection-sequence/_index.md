---
title: Fontvalsföljd i Aspose.Slides för C++
linktitle: Fontval
type: docs
weight: 80
url: /sv/cpp/font-selection-sequence/
keywords:
- fontval
- teckensnittssubstitution
- teckensnittsersättning
- substitutionsregel
- tillgängligt teckensnitt
- saknat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för C++ väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer — förbättra dina bilder nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om teckensnitten som används i presentationen finns tillgängliga i operativsystemet. Om ett erforderligt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas tillämpas ett lämpligt ersättningsteckensnitt. När teckensnittssubstitutionsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid programkörning, använda inbäddade teckensnitt från en presentation eller ladda externa teckensnitt för utdata‑dokument såsom PDF‑filer.

## **Teckensnittsurval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas vara saknade ersätts de – se [**Teckensnittsbyte**](https://docs.aspose.com/slides/sv/cpp/font-replacement/) och [**Teckensnittssubstitution**](https://docs.aspose.com/slides/sv/cpp/font-substitution/).

Detta är den process som Aspose.Slides följer när det hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta teckensnittet som matchar presentationens valda teckensnitt.  
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.  
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstrule/), tillämpas de.  

Aspose.Slides låter dig lägga till teckensnitt vid programkörning och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/cpp/custom-font/).

När ytterligare teckensnitt placeras i en presentation kallas de [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/cpp/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på utdata‑dokument. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller ladda de nödvändiga teckensnitten som **externa teckensnitt**.

{{% alert title="Note" color="info" %}} 
Vi distribuerar inga teckensnitt, varken betalda eller gratis. Vårt API låter dig ladda externa teckensnitt och bädda in dem i dokument, men du gör detta med teckensnitt på egen diskretion och ansvar.
{{% /alert %}}

## **FAQ**

### Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation före konvertering?

Aspose.Slides låter dig inspektera de teckensnitt som används via [teckensnittshanteraren](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/), så att du kan besluta om du ska [bädda in](/slides/sv/cpp/embedded-font/), [ersätta](/slides/sv/cpp/font-replacement/) eller lägga till [externa källor](/slides/sv/cpp/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

### Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/cpp/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets teckensnitt och håller layouten förutsägbar.

### Hur förhindrar jag ett tyst fallback‑beteende till ett olämpligt teckensnitt när en glyph saknas?

Definiera explicita [teckensnittsersättnings](/slides/sv/cpp/font-replacement/)‑ och teckensnittssfallback‑regler (/slides/sv/cpp/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du konsekvent typografi och undviker oväntade resultat.