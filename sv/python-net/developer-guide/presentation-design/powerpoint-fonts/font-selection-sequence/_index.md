---
title: Typsnittsval i Aspose.Slides för Python
linktitle: Typsnittsval
type: docs
weight: 80
url: /sv/python-net/font-selection-sequence/
keywords:
- typsnittsval
- typsnittssubstitution
- typsnittsersättning
- substitutionsregel
- tillgängligt typsnitt
- saknat typsnitt
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Upptäck hur Aspose.Slides för Python via .NET väljer typsnitt, vilket säkerställer klar och konsekvent presentation av PPT-, PPTX- och ODP-filer — förbättra dina bildspel nu."
---
## **Översikt**

När en presentation laddas, renderas eller konverteras till ett annat format kontrollerar Aspose.Slides om de typsnitt som används i presentationen finns tillgängliga i operativsystemet. Om ett nödvändigt typsnitt saknas väljer Aspose.Slides ett ersättningstypsnitt som ligger så nära som möjligt det som PowerPoint skulle använda.

Aspose.Slides söker först efter det valda typsnittet i operativsystemet. Om typsnittet hittas används det. Om det inte hittas tillämpas ett lämpligt ersättningstypsnitt. När typsnittssubstitutionsregler definieras via `FontSubstRule` tas även dessa regler i beaktande.

Du kan också lägga till typsnitt vid programkörning, använda inbäddade typsnitt från en presentation eller läsa in externa typsnitt för utdokument som PDF-filer.

## **Typsnittsurval**

Vissa regler gäller för typsnitt i en presentation när presentationen laddas, renderas eller konverteras till ett annat format. Till exempel, när du försöker konvertera en presentation (dess bilder) till bilder, kontrolleras presentationens typsnitt för att verifiera att de valda typsnitten finns i operativsystemet. Om typsnitten bekräftas saknas ersätts de – se [**Typsnittsersättning**](https://docs.aspose.com/slides/sv/python-net/font-replacement/) och [**Typsnittssubstitution**](https://docs.aspose.com/slides/sv/python-net/font-substitution/).

Detta är den process som Aspose.Slides följer när den hanterar typsnitt:

1. Aspose.Slides söker efter typsnitt i operativsystemet för att hitta det typsnitt som matchar presentationens valda typsnitt. 
2. Om det valda typsnittet hittas använder Aspose.Slides det. Annars använder Aspose.Slides ett ersättningstypsnitt som ligger så nära som möjligt det som PowerPoint skulle använda.
3. Om regler för typsnittsersättning har ställts in via [FontSubstRule](https://reference.aspose.com/slides/sv/python-net/aspose.slides/fontsubstrule/), tillämpas de. 

Aspose.Slides låter dig lägga till typsnitt under programkörning och sedan använda dessa typsnitt. Se [**Anpassade typsnitt**](https://docs.aspose.com/slides/sv/python-net/custom-font/). 

När extra typsnitt placeras i en presentation kallas de [**Inbäddade typsnitt**](https://docs.aspose.com/slides/sv/python-net/embedded-font/).

Aspose.Slides låter dig lägga till typsnitt som endast tillämpas på utdokument. Till exempel, om en presentation du vill konvertera till PDF innehåller typsnitt som saknas på ditt system och inbäddade typsnitt, kan du lägga till eller läsa in de behövda typsnitten som **externa typsnitt**. 

{{% alert title="Note" color="primary" %}} 
Vi distribuerar inga typsnitt, varken betalda eller gratis. Vårt API låter dig läsa in externa typsnitt och bädda in dem i dokument, men du gör det med typsnitt på ditt eget ansvar och efter eget gottfinnande.
{{% /alert %}}

## **Vanliga frågor**

**Hur kan jag avgöra vilka typsnitt som faktiskt används i en presentation innan konvertering?**

Aspose.Slides låter dig inspektera de använda typsnitten via [font manager](https://reference.aspose.com/slides/sv/python-net/aspose.slides/presentation/fonts_manager/), så att du kan avgöra om du ska [bädda in](/slides/sv/python-net/embedded-font/), [ersätta](/slides/sv/python-net/font-replacement/) eller lägga till [externa källor](/slides/sv/python-net/custom-font/). Detta hjälper dig att förhindra oönskade substitutioner under rendering och export.

**Kan jag lägga till extra typsnittskataloger utan att installera dem i operativsystemet?**

Ja. Du kan registrera [externa typsnittskällor](/slides/sv/python-net/custom-font/) såsom mappar eller minnesströmmar för rendering och export. Detta tar bort beroendet av värdsystemets typsnitt och håller layouten förutsägbar.

**Hur förhindrar jag en tyst återgång till ett olämpligt typsnitt när en glyf saknas?**

Definiera explicita [font replacement](/slides/sv/python-net/font-replacement/) och typsnittets [fallBack rules](/slides/sv/python-net/fallback-font/) i förväg. Genom att analysera använda typsnitt och sätta en kontrollerad prioritet för ersättningar säkerställer du enhetlig typografi och undviker oväntade resultat.