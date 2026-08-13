---
title: Typsnittsurval sekvens i Aspose.Slides för Android via Java
linktitle: Typsnittsurval
type: docs
weight: 80
url: /sv/androidjava/font-selection-sequence/
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
- Android
- Java
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Android via Java väljer teckensnitt, vilket säkerställer skarp och konsekvent presentation av PPT-, PPTX- och ODP-filer – förbättra dina bildspel nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de teckensnitt som används i presentationen finns tillgängliga i operativsystemet. Om ett nödvändigt teckensnitt saknas väljer Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda teckensnittet i operativsystemet. Om teckensnittet finns används det. Om det inte hittas tillämpas ett lämpligt ersättningsteckensnitt. När teckensnittssubstitutionsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till teckensnitt vid applikationens körning, använda inbäddade teckensnitt från en presentation eller ladda externa teckensnitt för utdatafiler såsom PDF-filer.

## **Typsnittval**

Vissa regler gäller för teckensnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens teckensnitt för att verifiera att de valda teckensnitten finns i operativsystemet. Om teckensnitten bekräftas saknas, ersätts de — se [**Teckensnittsersättning**](https://docs.aspose.com/slides/sv/androidjava/font-replacement/) och [**Teckensnittssubstitution**](https://docs.aspose.com/slides/sv/androidjava/font-substitution/).

Detta är den process som Aspose.Slides följer när den hanterar teckensnitt:

1. Aspose.Slides söker efter teckensnitt i operativsystemet för att hitta det teckensnitt som matchar presentationens valda teckensnitt. 
2. Om det valda teckensnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningsteckensnitt som är så nära som möjligt det som PowerPoint skulle använda.
3. Om teckensnittsersättningsregler har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsubstrule/), tillämpas de.

Aspose.Slides låter dig lägga till teckensnitt i applikationens körning och sedan använda dessa teckensnitt. Se [**Anpassade teckensnitt**](https://docs.aspose.com/slides/sv/androidjava/custom-font/).

När ytterligare teckensnitt placeras i en presentation kallas de [**Inbäddade teckensnitt**](https://docs.aspose.com/slides/sv/androidjava/embedded-font/).

Aspose.Slides tillåter dig att lägga till teckensnitt som endast tillämpas på utdatafiler. Till exempel, om en presentation du vill konvertera till PDF innehåller teckensnitt som saknas i ditt system och inbäddade teckensnitt, kan du lägga till eller ladda de behövda teckensnitten som **externa teckensnitt**. 

{{% alert title="Note" color="info" %}} 
Vi distribuerar inga teckensnitt, vare sig betalda eller gratis. Vårt API låter dig ladda externa teckensnitt och bädda in dem i dokument, men du gör det på eget ansvar.
{{% /alert %}}

## **Vanliga frågor**

### Hur kan jag avgöra vilka teckensnitt som faktiskt används i en presentation innan konvertering?

Aspose.Slides låter dig inspektera de använda teckensnitten via [font manager](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/fontsmanager/), så att du kan bestämma om du ska [bädda in](/slides/sv/androidjava/embedded-font/), [ersätta](/slides/sv/androidjava/font-replacement/) eller lägga till [externa källor](/slides/sv/androidjava/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

### Kan jag lägga till extra teckensnittsmappar utan att installera dem i operativsystemet?

Ja. Du kan registrera [externa teckensnittskällor](/slides/sv/androidjava/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdens systemteckensnitt och håller layouten förutsägbar.

### Hur förhindrar jag en tyst återgång till ett olämpligt teckensnitt när en glyf saknas?

Definiera uttryckliga [teckensnittsersättning](/slides/sv/androidjava/font-replacement/) och [fallback-regler](/slides/sv/androidjava/fallback-font/) i förväg. Genom att analysera använda teckensnitt och ställa in en kontrollerad prioritet för ersättningar säkerställer du konsekvent typografi och undviker oväntade resultat.