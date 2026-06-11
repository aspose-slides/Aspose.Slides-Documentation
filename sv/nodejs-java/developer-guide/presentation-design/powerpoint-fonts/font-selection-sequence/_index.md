---
title: Fontvalsekvens i Aspose.Slides för Node.js via Java
linktitle: Fontval
type: docs
weight: 80
url: /sv/nodejs-java/font-selection-sequence/
keywords:
- fontval
- teckensnittssubstitution
- teckensnittsersättning
- substitionsregel
- tillgängligt teckensnitt
- saknat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Node.js via Java väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer — förbättra dina bilder nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen finns i operativsystemet. Om ett nödvändigt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas appliceras ett lämpligt ersättningsteckensnitt. När teckensnittssubstitutionsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid körning, använda inbäddade teckensnitt från en presentation eller läsa in externa teckensnitt för utdata‑dokument som PDF‑filer.

## **Teckensnittval**

Vissa regler gäller för teckensnitt i en presentation när den laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de – se [**Teckensnittsbyte**](https://docs.aspose.com/slides/sv/nodejs-java/font-replacement/) och [**Teckensnittssubstitution**](https://docs.aspose.com/slides/sv/nodejs-java/font-substitution/).

Detta är processen som Aspose.Slides följer när det hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta teckensnittet som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det PowerPoint skulle använda.
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fontsubstrule/), tillämpas de.

Aspose.Slides låter dig lägga till teckensnitt vid körning och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/nodejs-java/custom-font/).

När extra teckensnitt placeras i en presentation kallas de [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/nodejs-java/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på *utdata‑dokument*. Till exempel, om en presentation som du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller läsa in de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga teckensnitt, vare sig betalda eller gratis. Vårt API låter dig läsa in externa teckensnitt och bädda in dem i dokument, men du gör det med teckensnitt på ditt eget ansvar och enligt din egen discretion.
{{% /alert %}}

## **FAQ**

**Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig undersöka de använda teckensnitten via [teckensnittshanteraren](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/getfontsmanager/), så att du kan bestämma om du vill [bädda in](/slides/sv/nodejs-java/embedded-font/), [ersätta](/slides/sv/nodejs-java/font-replacement/) eller lägga till [externa källor](/slides/sv/nodejs-java/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

**Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/nodejs-java/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta eliminerar beroendet av värdsystemets teckensnitt och gör layouten förutsägbar.

**Hur förhindrar jag en tyst fallback till ett olämpligt teckensnitt när en glyf saknas?**

Definiera explicita [teckensnittsersättningar](/slides/sv/nodejs-java/font-replacement/) och font [fallback‑regler](/slides/sv/nodejs-java/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du konsekvent typografi och undviker oväntade resultat.