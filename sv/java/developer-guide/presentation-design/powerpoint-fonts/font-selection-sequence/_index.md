---
title: Sekvens för typsnittsurval i Aspose.Slides för Java
linktitle: Typsnittsval
type: docs
weight: 80
url: /sv/java/font-selection-sequence/
keywords:
- typsnittsurval
- typsnittssubstitution
- typsnittsersättning
- substitutionsregel
- tillgängligt typsnitt
- saknat typsnitt
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Java väljer typsnitt, vilket säkerställer skarp och enhetlig presentation av PPT-, PPTX- och ODP-filer – förbättra dina bilder nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen finns tillgängliga i operativsystemet. Om ett nödvändigt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas appliceras ett lämpligt ersättningsteckensnitt. När teckensnittssubstitutionsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid körning av applikationen, använda inbäddade teckensnitt från en presentation eller läsa in externa teckensnitt för utdokument som PDF-filer.

## **Teckensnittsval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de — se [**Teckensnittsersättning**](https://docs.aspose.com/slides/sv/java/font-replacement/) och [**Teckensnittssubstitution**](https://docs.aspose.com/slides/sv/java/font-substitution/).

Detta är den process som Aspose.Slides följer när den hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsubstrule/), tillämpas de. 

Aspose.Slides låter dig lägga till teckensnitt vid körning av applikationen och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/java/custom-font/). 

När extra teckensnitt placeras i en presentation kallas de för [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/java/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på utskriftsdokument. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller läsa in de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga teckensnitt, varken betalda eller gratis. Vårt API låter dig läsa in externa teckensnitt och bädda in dem i dokument, men du gör det på eget ansvar och enligt ditt eget gottfinnande.
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig granska de teckensnitt som används via [teckensnittshanteraren](https://reference.aspose.com/slides/sv/java/com.aspose.slides/fontsmanager/), så att du kan besluta om du vill [inbädda](/slides/sv/java/embedded-font/), [ersätta](/slides/sv/java/font-replacement/) eller lägga till [externa källor](/slides/sv/java/custom-font/). Detta hjälper dig att förhindra oönskade ersättningar under rendering och export.

**Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/java/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av systemets teckensnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst återgång till ett olämpligt teckensnitt när en glyph saknas?**

Definiera explicit [teckensnittsersättning](/slides/sv/java/font-replacement/) och teckensnittets [fallback-regler](/slides/sv/java/fallback-font/) i förväg. Genom att analysera använda teckensnitt och ställa in en kontrollerad prioritet för ersättningar säkerställer du enhetlig typografi och undviker oväntade resultat.