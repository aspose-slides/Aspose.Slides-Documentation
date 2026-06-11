---
title: Teckensnittsvalningssekvens i Aspose.Slides för Android via Java
linktitle: Teckensnittval
type: docs
weight: 80
url: /sv/androidjava/font-selection-sequence/
keywords:
- teckensnittval
- teckensnittssubstitution
- teckensnittsersättning
- substitutionsregel
- tillgängligt teckensnitt
- saknat teckensnitt
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Android via Java väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer — förbättra dina bildspel nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen finns tillgängliga i operativsystemet. Om ett obligatoriskt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet hittas används det. Om det inte hittas tillämpas ett lämpligt ersättningsteckensnitt. När teckensnittsersättningsregler definieras via `FontSubstRule` tas även dessa i beaktande.

Du kan också lägga till teckensnitt vid applikationens körning, använda inbäddade teckensnitt från en presentation eller ladda externa teckensnitt för utdata‑dokument såsom PDF‑filer.

## **Teckensnittsurval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de — se [**Teckensnittsersättning**](https://docs.aspose.com/slides/sv/androidjava/font-replacement/) och [**Teckensnittssubstitution**](https://docs.aspose.com/slides/sv/androidjava/font-substitution/).

Detta är processen Aspose.Slides följer när det hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstrule/), tillämpas de.

Aspose.Slides låter dig lägga till teckensnitt vid applikationens körning och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/androidjava/custom-font/).

När ytterligare teckensnitt placeras i en presentation kallas de [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/androidjava/embedded-font/).

Aspose.Slides låter dig lägga till teckensnitt som endast tillämpas på *endast* utdata‑dokument. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller ladda de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga teckensnitt, varken betalda eller gratis. Vårt API låter dig ladda externa teckensnitt och bädda in dem i dokument, men du gör det med teckensnitt på din egen ansvar och eget gottfinnande.
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag ta reda på vilka teckensnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig inspektera de teckensnitt som används via [teckensnittshanteraren](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/), så att du kan besluta om du vill [bädda in](/slides/sv/androidjava/embedded-font/), [ersätta](/slides/sv/androidjava/font-replacement/) eller lägga till [externa källor](/slides/sv/androidjava/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

**Kan jag lägga till extra teckensnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/androidjava/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets teckensnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst återgång till ett olämpligt teckensnitt när en glyph saknas?**

Definiera explicit [teckensnittsersättning](/slides/sv/androidjava/font-replacement/) och teckensnitt [återfallsregler](/slides/sv/androidjava/fallback-font/) i förväg. Genom att analysera använda teckensnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du enhetlig typografi och undviker oväntade resultat.