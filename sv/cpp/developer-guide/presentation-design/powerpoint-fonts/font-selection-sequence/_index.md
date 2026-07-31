---
title: Teckensnittsurvalsekvens i Aspose.Slides för C++
linktitle: Teckensnittsurval
type: docs
weight: 80
url: /sv/cpp/font-selection-sequence/
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
- C++
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för C++ väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer—förbättra dina bilder nu."
---
## **Översikt**

När en presentation läses in, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen är tillgängliga i operativsystemet. Om ett nödvändigt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så likt som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas appliceras ett lämpligt ersättningsteckensnitt. När teckensnittsbytesregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid programkörning, använda inbäddade teckensnitt från en presentation eller ladda externa teckensnitt för utmatningsdokument såsom PDF-filer.

## **Teckensnittsurval**

Vissa regler gäller för teckensnitt i en presentation när presentationen läses in, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de — se [**Teckensnittsersättning**](https://docs.aspose.com/slides/sv/cpp/font-replacement/) och [**Teckensnittssubstitution**](https://docs.aspose.com/slides/sv/cpp/font-substitution/).

Detta är processen som Aspose.Slides följer när den hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar det som presentationen har valt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstrule/), tillämpas de. 

Aspose.Slides låter dig lägga till teckensnitt vid programkörning och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/cpp/custom-font/). 

När extra teckensnitt placeras i en presentation kallas de [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/cpp/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast appliceras på *utmatningsdokument*. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas på ditt system och inbäddade teckensnitt, kan du lägga till eller ladda de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga teckensnitt, varken betalda eller gratis. Vårt API låter dig ladda externa teckensnitt och bädda in dem i dokument, men du gör det med teckensnitt på eget ansvar och enligt din egen bedömning.
{{% /alert %}}

## **FAQ**

**Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig inspektera de använda teckensnitten via [font manager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/), så att du kan avgöra om du ska [bädda in](/slides/sv/cpp/embedded-font/), [ersätta](/slides/sv/cpp/font-replacement/) eller lägga till [externa källor](/slides/sv/cpp/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

**Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/cpp/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets teckensnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst återgång till ett olämpligt teckensnitt när en glyf saknas?**

Definiera explicit [teckensnittsersättning](/slides/sv/cpp/font-replacement/) och teckensnitt[fallback-regler](/slides/sv/cpp/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du konsistent typografi och undviker oväntade resultat.