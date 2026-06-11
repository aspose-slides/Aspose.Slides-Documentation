---
title: Lägg till bilder i presentationer i Java
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/java/add-slide-to-presentation/
keywords:
- lägg till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint och OpenDocument presentationer med Aspose.Slides för Java - smidig, effektiv bildinfogning på några sekunder."
---
## **Översikt**

Aspose.Slides gör det möjligt att lägga till bilder i PowerPoint‑presentationer programatiskt. En presentation innehåller master-/layout‑bilder och vanliga bilder, och de vanliga bilderna ordnas efter ett nollbaserat index. Varje bild har ett unikt ID, och presentationsfiler utan bilder stöds inte.

Den här artikeln förklarar hur man skapar ett `Presentation`‑objekt, får åtkomst till dess bildsamling, lägger till en tom bild, arbetar med den nyligen lagda bilden och sparar den uppdaterade presentationen. Den täcker också relaterade punkter såsom att infoga bilder på en viss position, använda layouter och förstå den tomma bilden som finns i en ny skapad presentation.

## **Lägg till en bild i en presentation**

Innan vi diskuterar hur man lägger till bilder i presentationsfilerna, låt oss gå igenom några fakta om bilderna. Varje PowerPoint‑presentationsfil innehåller **Master / Layout**‑bild och andra **Vanliga** bilder. Det innebär att en presentationsfil innehåller minst en eller flera bilder. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides for Java. Varje bild har ett unikt Id och alla Vanliga bilder ordnas i en ordning som specificeras av det nollbaserade indexet.

Aspose.Slides for Java låter utvecklare lägga till tomma bilder i sin presentation. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).
- Instansiera klassen [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection) genom att sätta en referens till egenskapen [Slides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation#getSlides--) (samling av innehållsbilder) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation)-objektet.
- Lägg till en tom bild i presentationen i slutet av samlingen av innehållsbilder genom att anropa metoden [**addEmptySlide**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-) som exponeras av objektet [ISlideCollection](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ISlideCollection).
- Utför någon bearbetning på den nyligen lagda tomma bilden.
- Slutligen, skriv presentationsfilen med hjälp av objektet [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation).

```java
// Instansiera Presentation‑klassen som representerar presentationsfilen
Presentation pres = new Presentation();
try {
    // Instansiera SlideCollection‑klassen
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Lägg till en tom bild i Slides‑samlingen
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Utför någon bearbetning på den nyss lagda bilden

    // Spara PPTX‑filen till disken
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**

Ja. Biblioteket stödjer bildsamlingar och [insert](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)‑operationer, så du kan lägga till en bild på det önskade indexet istället för enbart i slutet.

**Behålls tema/stilar när en bild läggs till baserat på en layout?**

Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny "tom" presentation innan du lägger till bilder?**

En ny skapad presentation innehåller redan en tom bild med index noll. Detta är viktigt att beakta när man beräknar infogningsindex.

**Hur väljer jag den "rätta" layouten för en ny bild om mastern har många alternativ?**

Välj i allmänhet den [LayoutSlide](https://reference.aspose.com/slides/sv/java/com.aspose.slides/layoutslide/) som matchar den erforderliga strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/java/com.aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [lägg till den i mastern](/slides/sv/java/slide-layout/) och sedan använda den.