---
title: "Fonturval sekvens i Aspose.Slides för C++"
linktitle: "Fonturval"
type: docs
weight: 80
url: /sv/cpp/font-selection-sequence/
keywords:
  - "fonturval"
  - "fontbyte"
  - "fontersättning"
  - "bytesregel"
  - "tillgängligt teckensnitt"
  - "saknat teckensnitt"
  - "PowerPoint"
  - "OpenDocument"
  - "presentation"
  - "C++"
  - "Aspose.Slides"
description: "Upptäck hur Aspose.Slides för C++ väljer teckensnitt, vilket säkerställer skarpa och konsekventa presentationer av PPT-, PPTX- och ODP-filer—förbättra dina bilder nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen finns tillgängliga i operativsystemet. Om ett nödvändigt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet finns används det. Om det inte finns tillämpas ett lämpligt ersättningsteckensnitt. När teckensnittsbytningsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid körning av applikationen, använda inbäddade teckensnitt från en presentation eller ladda externa teckensnitt för utdatafiler såsom PDF-filer.

## **Teckensnittsurval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de — se [**Teckensnittsersättning**](https://docs.aspose.com/slides/sv/cpp/font-replacement/) och [**Teckensnittsbyte**](https://docs.aspose.com/slides/sv/cpp/font-substitution/).

Detta är den process som Aspose.Slides följer när den hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.
3. Om teckensnittsbytesregler har satts genom [FontSubstRule](https://reference.aspose.com/slides/sv/cpp/aspose.slides/fontsubstrule/), tillämpas de. 

Aspose.Slides låter dig lägga till teckensnitt vid körning av applikationen och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/cpp/custom-font/). 

När ytterligare teckensnitt placeras i en presentation kallas de för [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/cpp/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på utdatafiler. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller ladda de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga teckensnitt, vare sig betalda eller gratis. Vårt API låter dig ladda externa teckensnitt och bädda in dem i dokument, men du gör det med teckensnitt på ditt eget ansvar och eget gottfinnande.
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig granska de använda teckensnitten via [font manager](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_fontsmanager/), så att du kan besluta om du vill [bädda in](/slides/sv/cpp/embedded-font/), [ersätta](/slides/sv/cpp/font-replacement/), eller lägga till [externa källor](/slides/sv/cpp/custom-font/). Detta hjälper dig att förhindra oönskade ersättningar under rendering och export.

**Kan jag lägga till extra teckensnittsmappar utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/cpp/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets teckensnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst återgång till ett olämpligt teckensnitt när en glyf saknas?**

Definiera explicit [teckensnittsbyte](/slides/sv/cpp/font-replacement/) och teckensnittets [fallback-regler](/slides/sv/cpp/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du en konsekvent typografi och undviker oväntade resultat.