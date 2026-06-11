---
title: Lägg till bilder i presentationer i C++
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/cpp/add-slide-to-presentation/
keywords:
- lägg till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint- och OpenDocument-presentationer med Aspose.Slides för C++ — sömlös, effektiv bildinfogning på några sekunder."
---
## **Översikt**

Aspose.Slides låter dig lägga till bilder i PowerPoint‑presentationer programatiskt. En presentation innehåller master/layoute‑bilder och vanliga bilder, och de vanliga bilderna ordnas enligt ett nollbaserat index. Varje bild har ett unikt ID, och presentationsfiler utan bilder stöds inte.

Denna artikel förklarar hur du skapar ett `Presentation`‑objekt, får åtkomst till dess bildsamling, lägger till en tom bild, arbetar med den nyligen tillagda bilden och sparar den uppdaterade presentationen. Den behandlar också relaterade ämnen såsom att infoga bilder på en specifik position, använda layouter och förstå den tomma bilden som finns i en ny skapad presentation.

## **Lägg till en bild i en presentation**
Innan vi pratar om att lägga till bilder i presentationsfilerna, låt oss diskutera några fakta om bilderna. Varje PowerPoint‑presentationsfil innehåller Master‑/Layout‑bilder och andra normala bilder. Det betyder att en presentationsfil innehåller minst en eller flera bilder. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides för C++. Varje bild har ett unikt Id och alla normala bilder ordnas i en följd som specificeras av det nollbaserade indexet. Aspose.Slides för C++ låter utvecklare lägga till tomma bilder i sina presentationer. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)klassen.
- Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/islidecollection/)klassen genom att sätta en referens till Slides‑egenskapen (samling av innehållsSlide‑objekt) som exponeras av Presentation‑objektet.
- Lägg till en tom bild i presentationen i slutet av samlingen av innehållsbilder genom att anropa AddEmptySlide‑metoderna som exponeras av ISlideCollection‑objektet.
- Utför någon behandling med den nyss tillagda tomma bilden.
- Skriv slutligen presentationsfilen med hjälp av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)objektet.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddSlides-AddSlides.cpp" >}}

## **FAQ**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**

Ja. Biblioteket stödjer bildsamlingar och [insert](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidecollection/insertclone/)‑operationer, så du kan lägga till en bild på det önskade indexet istället för enbart i slutet.

**Bevaras tema/stilar när jag lägger till en bild baserad på en layout?**

Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny ”tom” presentation innan bilder läggs till?**

En nyss skapad presentation innehåller redan en tom bild med index noll. Detta är viktigt att beakta när du beräknar infogningsindex.

**Hur väljer jag rätt layout för en ny bild om master har många alternativ?**

Välj i allmänhet den [LayoutSlide](https://reference.aspose.com/slides/sv/cpp/aspose.slides/layoutslide/) som matchar den erforderliga strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/cpp/aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [add it to the master](/slides/sv/cpp/slide-layout/) och sedan använda den.