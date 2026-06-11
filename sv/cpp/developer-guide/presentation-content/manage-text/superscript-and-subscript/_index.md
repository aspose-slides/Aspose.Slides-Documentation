---
title: Hantera upphöjd och nedsänkt text i presentationer med C++
linktitle: Upphöjd och nedsänkt
type: docs
weight: 80
url: /sv/cpp/superscript-and-subscript/
keywords:
- upphöjd
- nedsänkt
- lägg till upphöjd
- lägg till nedsänkt
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska upphöjd och nedsänkt text i Aspose.Slides för C++ och lyft dina presentationer med professionell textformatering för maximal effekt."
---
## **Översikt**

Aspose.Slides tillhandahåller funktioner för att integrera upphöjd och nedsänkt text i dina PowerPoint‑presentationer (PPT, PPTX) och OpenDocument‑presentationer (ODP). Oavsett om du behöver markera kemiska formler, matematiska ekvationer eller kommentera innehåll med fotnoter, hjälper dessa specialiserade formateringsalternativ till att bevara tydlighet och precision. I den här artikeln lär du dig hur du sömlöst tillämpar upphöjda och nedsänkta stilar och säkerställer professionella resultat på varje bild.

## **Hantera upphöjd och nedsänkt text**

Du kan lägga till upphöjd och nedsänkt text i valfri stycke‑del. För att lägga till upphöjd eller nedsänkt text i Aspose.Slides‑textram måste du använda **Escapement**‑egenskaperna i PortionFormat‑klassen.

Denna egenskap returnerar eller anger den upphöjda eller nedsänkta texten (värde från -100 % (nedsänkt) till 100 % (upphöjd)). Till exempel:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen.  
- Hämta referensen till en bild genom att använda dess Index.  
- Lägg till en IAutoShape av typen Rectangle på bilden.  
- Få åtkomst till ITextFrame som är associerad med IAutoShape.  
- Rensa befintliga Paragraphs.  
- Skapa ett nytt styckeobjekt för att hålla upphöjd text och lägg till det i IParagraphs‑samlingen i ITextFrame.  
- Skapa ett nytt portion‑objekt.  
- Ange Escapement‑egenskapen för portionen mellan 0 och 100 för att lägga till upphöjd text. (0 betyder ingen upphöjd text)  
- Ställ in någon text för Portion och lägg sedan till den i portion‑samlingen i stycket.  
- Skapa ett nytt styckeobjekt för att hålla nedsänkt text och lägg till det i IParagraphs‑samlingen i ITextFrame.  
- Skapa ett nytt portion‑objekt.  
- Ange Escapement‑egenskapen för portionen mellan 0 och -100 för att lägga till nedsänkt text. (0 betyder ingen nedsänkt text)  
- Ställ in någon text för Portion och lägg sedan till den i portion‑samlingen i stycket.  
- Spara presentationen som en PPTX‑fil.

Implementeringen av stegen ovan visas nedan.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AddingSuperscriptAndSubscriptTextInTextFrame-AddingSuperscriptAndSubscriptTextInTextFrame.cpp" >}}

## **Vanliga frågor**

**Kommer upphöjd och nedsänkt text att bevaras vid export till PDF eller andra format?**

Ja, Aspose.Slides behåller korrekt upphöjd och nedsänkt formatering när presentationer exporteras till PDF, PPT/PPTX, bilder och andra stödda format. Den specialiserade formateringen förblir intakt i alla utdatafiler.

**Kan upphöjd och nedsänkt text kombineras med andra formateringsstilar som fetstil eller kursiv?**

Ja, Aspose.Slides låter dig blanda olika textstilar inom en enda portion av text. Du kan aktivera fetstil, kursiv, understrykning och samtidigt tillämpa upphöjd eller nedsänkt text genom att konfigurera motsvarande egenskaper i [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/).

**Fungerar upphöjd och nedsänkt formatering för text i tabeller, diagram eller SmartArt?**

Ja, Aspose.Slides stöder formatering inom de flesta objekt, inklusive tabeller och diagram­element. När du arbetar med SmartArt måste du komma åt de relevanta elementen (såsom [SmartArtNode](https://reference.aspose.com/slides/sv/cpp/aspose.slides.smartart/smartartnode/)) och deras textbehållare, och sedan konfigurera [PortionFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/portionformat/)-egenskaper på liknande sätt.