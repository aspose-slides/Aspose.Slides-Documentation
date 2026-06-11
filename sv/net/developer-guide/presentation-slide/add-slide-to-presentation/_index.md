---
title: Lägg till slides i presentationer i .NET
linktitle: Lägg till slide
type: docs
weight: 10
url: /sv/net/add-slide-to-presentation/
keywords:
- lägg till slide
- skapa slide
- tom slide
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Lägg enkelt till slides i dina PowerPoint- och OpenDocument-presentationer med Aspose.Slides för .NET — sömlös, effektiv slide‑infogning på några sekunder."
---
## **Översikt**

Aspose.Slides låter dig lägga till slides i PowerPoint-presentationer programatiskt. En presentation innehåller master/layout‑slides och normala slides, och normala slides ordnas enligt ett nollbaserat index. Varje slide har ett unikt ID, och presentationsfiler utan slides stöds inte.

Denna artikel förklarar hur du skapar ett `Presentation`‑objekt, får åtkomst till dess slide‑samling, lägger till en tom slide, arbetar med den nyligen tillagda sliden och sparar den uppdaterade presentationen. Den behandlar också relaterade frågor såsom att infoga slides på en specifik position, använda layouter och förstå den tomma sliden som finns i en nyskapad presentation.

## **Lägg till en slide i en presentation**
Innan vi pratar om att lägga till slides i presentationsfilerna, låt oss diskutera några fakta om slides. Varje PowerPoint‑presentationsfil innehåller en Master‑/Layout‑slide och andra Normala slides. Det innebär att en presentationsfil innehåller minst en slide. Det är viktigt att veta att presentationsfiler utan slides inte stöds av Aspose.Slides för .NET. Varje slide har ett unikt Id och alla Normala slides ordnas i den ordning som anges av det nollbaserade indexet. Aspose.Slides för .NET låter utvecklare lägga till tomma slides i sin presentation. För att lägga till en tom slide i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
- Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/islidecollection) genom att sätta en referens till egenskapen Slides (samling av innehålls‑Slide‑objekt) som exponeras av Presentation‑objektet.
- Lägg till en tom slide i presentationen i slutet av samlingen av innehållsslides genom att anropa AddEmptySlide‑metoderna som exponeras av ISlideCollection‑objektet.
- Utför några åtgärder med den nyligen tillagda tomma sliden.
- Skriv slutligen presentationsfilen med hjälp av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)‑objektet.

{{< gist "aspose-slides" "53249e5573d2cd6e66f91f708e8fe008" "Examples-CSharp-Slides-AddSlides-AddSlides.cs" >}}

## **Vanliga frågor**

**Kan jag infoga en ny slide på en specifik position, inte bara i slutet?**

Ja. Biblioteket stödjer slide‑samlingar och [insert](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/insertclone/)‑operationer, så du kan lägga till en slide på det önskade indexet istället för enbart i slutet.

**Behålls teman/stilar när en slide läggs till baserat på en layout?**

Ja. En layout ärver formatering från sin master, och den nya sliden ärver från den valda layouten och dess tillhörande master.

**Vilken slide finns i en ny "tom" presentation innan slides läggs till?**

En nyskapad presentation innehåller redan en tom slide med index noll. Detta är viktigt att beakta när du beräknar infogningsindex.

**Hur väljer jag den "rätta" layouten för en ny slide om mastern har många alternativ?**

Välj vanligtvis den [LayoutSlide](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslide/) som matchar den önskade strukturen ([Titel och innehåll, Två innehåll, etc.](https://reference.aspose.com/slides/sv/net/aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [lägga till den i mastern](/slides/sv/net/slide-layout/) och sedan använda den.