---
title: Teckensnittsurvalsekvens i Aspose.Slides för .NET
linktitle: Teckensnittsurval
type: docs
weight: 80
url: /sv/net/font-selection-sequence/
keywords:
- teckensnittsurval
- teckensnittssubstitution
- teckensnittsersättning
- substitutionsregel
- tillgängligt teckensnitt
- saknat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för .NET väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer — förbättra dina bildspel nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen finns tillgängliga i operativsystemet. Om ett nödvändigt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som ligger så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas tillämpas ett lämpligt ersättningsteckensnitt. När teckensnittssubstitutionsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid körning av programmet, använda inbäddade teckensnitt från en presentation eller läsa in externa teckensnitt för utdokument, såsom PDF-filer.

## **Fontval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bildspel) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de — se [**Fontbyte**](https://docs.aspose.com/slides/sv/net/font-replacement/) och [**Fontsubstitution**](https://docs.aspose.com/slides/sv/net/font-substitution/).

Detta är den process som Aspose.Slides följer när det hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som ligger så nära som möjligt det som PowerPoint skulle använda.
3. Om regler för fontbyte har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/net/aspose.slides/fontsubstrule/), tillämpas de. 

Aspose.Slides låter dig lägga till teckensnitt i programmet vid körning och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/net/custom-font/). 

När extra teckensnitt placeras i en presentation kallas de [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/net/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på utskriftsdokument. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller läsa in de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga teckensnitt, varken betalda eller gratis. Vårt API låter dig läsa in externa teckensnitt och bädda in dem i dokument, men du gör detta med teckensnitt på eget ansvar. 
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig inspektera de använda teckensnitten via [font manager](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/fontsmanager/), så att du kan besluta om du vill [bädda in](/slides/sv/net/embedded-font/), [ersätta](/slides/sv/net/font-replacement/), eller lägga till [externa källor](/slides/sv/net/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

**Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/net/custom-font/) såsom mappar eller strömmar i minnet för rendering och export. Detta tar bort beroendet av värdsystemets teckensnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst återgång till ett olämpligt teckensnitt när en glyf saknas?**

Definiera explicit [teckensnittsersättning](/slides/sv/net/font-replacement/) och font [fallback-regler](/slides/sv/net/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du enhetlig typografi och undviker oväntade resultat.