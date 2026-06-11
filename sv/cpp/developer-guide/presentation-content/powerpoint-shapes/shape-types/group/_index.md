---
title: Grupppresentationformer i C++
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/cpp/group/
keywords:
- gruppform
- formgrupp
- lägg till grupp
- alternativ text
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig att gruppera och avgruppera former i PowerPoint‑presentationer med Aspose.Slides för C++ — snabb, steg‑för‑steg‑guide med gratis C++‑kod."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med gruppformer i Aspose.Slides. Den visar hur man lägger till en gruppform på en bild, placerar former inuti den och sparar den uppdaterade presentationen. Den demonstrerar också hur man får åtkomst till former som lagras i en grupp och läser deras `AlternativeText`‑värden. Dessutom täcker artikeln kort relaterade funktioner för gruppformer såsom nästlade grupper, z‑ordning och låsalternativ.

## **Lägg till en gruppform**
Aspose.Slides stöder arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides för C++ stöder att lägga till eller komma åt gruppformer. Det är möjligt att lägga till former i en redan tillagd gruppform för att fylla den eller komma åt någon egenskap hos gruppformen. För att lägga till en gruppform på en bild med Aspose.Slides för C++:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en gruppform på bilden.
1. Lägg till formerna i den tillagda gruppformen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CreateGroupShape-CreateGroupShape.cpp" >}}

## **Åtkomst till AltText‑egenskapen**
Detta avsnitt visar enkla steg, komplett med kodexempel, för att lägga till en gruppform och komma åt AltText‑egenskapen för gruppformer på bilder. För att komma åt AltText för en gruppform i en bild med Aspose.Slides för C++:

1. Instansiera klassen `Presentation` som representerar en PPTX‑fil.
1. Hämta referensen till en bild genom att använda dess index.
1. Åtkomst till bildens formsamling.
1. Åtkomst till gruppformen.
1. Åtkomst till AltText‑egenskapen.

Exemplet nedan får åtkomst till den alternativa texten för gruppformen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessingAltTextinGroupshapes-AccessingAltTextinGroupshapes.cpp" >}}

## **FAQ**

**Stöds nästlad gruppering (en grupp inuti en grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/groupshape/) har en [get_ParentGroup](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_parentgroup/)‑metod, som tydligt visar stöd för hierarki (en grupp kan vara ett barn till en annan grupp).

**Hur styr jag gruppens z‑ordning i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/groupshape/)‑s [Z-Order position](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/get_zorderposition/) för att inspektera dess position i visningsstacken.

**Kan jag förhindra flyttning/redigering/avgruppering?**

Ja. Gruppens låssektion exponeras via [get_GroupShapeLock](https://reference.aspose.com/slides/sv/cpp/aspose.slides/groupshape/get_groupshapelock/), vilket låter dig begränsa operationer på objektet.