---
title: Sekvens för teckensnittsval i Aspose.Slides för PHP
linktitle: Teckensnittsval
type: docs
weight: 80
url: /sv/php-java/font-selection-sequence/
keywords:
- teckensnittsval
- teckensnittsbyte
- teckensnittsersättning
- bytesregel
- tillgängligt teckensnitt
- saknat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för PHP via Java väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer — förbättra dina bilder nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om teckensnitten som används i presentationen finns tillgängliga i operativsystemet. Om ett obligatoriskt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas tillämpas ett lämpligt ersättningsteckensnitt. När teckensnittsbytesregler definieras via `FontSubstRule` beaktas även dessa regler.

Du kan också lägga till teckensnitt vid programkörning, använda inbäddade teckensnitt från en presentation eller ladda externa teckensnitt för utmatningsdokument, såsom PDF-filer.

## **Teckensnittsurval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bildspel) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns tillgängliga i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de – se [**Font Replacement**](https://docs.aspose.com/slides/sv/php-java/font-replacement/) och [**Font Substitution**](https://docs.aspose.com/slides/sv/php-java/font-substitution/).

Detta är den process som Aspose.Slides följer när det gäller teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda. 
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsubstrule/), tillämpas de.

Aspose.Slides låter dig lägga till teckensnitt till Aspose‑runtime och sedan använda dessa teckensnitt. Se [**Custom fonts**](https://docs.aspose.com/slides/sv/php-java/custom-font/).

När ytterligare teckensnitt placeras i en presentation kallas de [**Embedded fonts**](https://docs.aspose.com/slides/sv/php-java/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på utmatningsdokument. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller ladda de nödvändiga teckensnitten som **External fonts**. 

## **FAQ**

**Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig granska de använda teckensnitten via [font manager](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fontsmanager/), så att du kan avgöra om du vill [embed](/slides/sv/php-java/embedded-font/), [replace](/slides/sv/php-java/font-replacement/) eller lägga till [external sources](/slides/sv/php-java/custom-font/). Detta hjälper dig att förhindra oönskade ersättningar under rendering och export.

**Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [external font sources](/slides/sv/php-java/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets teckensnitt och behåller layouten förutsägbar.

**Hur förhindrar jag en tyst fallback till ett olämpligt teckensnitt när en glyf saknas?**

Definiera explicita [font replacement](/slides/sv/php-java/font-replacement/) och teckensnitt [fallback rules](/slides/sv/php-java/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en styrd prioritet för ersättningar säkerställer du en konsekvent typografi och undviker oväntade resultat.