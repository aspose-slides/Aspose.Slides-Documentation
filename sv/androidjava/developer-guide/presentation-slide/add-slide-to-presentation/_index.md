---
title: Lägg till bilder i presentationer på Android
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/androidjava/add-slide-to-presentation/
keywords:
- lägg till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Android via Java—smidig, effektiv bildinfogning på sekunder."
---
## **Översikt**

Aspose.Slides låter dig lägga till bilder i PowerPoint‑presentationer programmässigt. En presentation innehåller master‑/layoutbilder och vanliga bilder, och de vanliga bilderna ordnas efter ett nollbaserat index. Varje bild har ett unikt ID, och presentationsfiler utan bilder stöds inte.

Den här artikeln förklarar hur man skapar ett `Presentation`‑objekt, får åtkomst till dess bildsamling, lägger till en tom bild, arbetar med den nylagda bilden och sparar den uppdaterade presentationen. Den täcker också relaterade punkter såsom att infoga bilder på en specifik position, använda layouter och förstå den tomma bilden som finns i en ny skapad presentation.

## **Lägg till en bild i en presentation**

Innan vi pratar om att lägga till bilder i presentationsfilerna, låt oss diskutera några fakta om bilderna. Varje PowerPoint‑presentationfil innehåller **Master / Layout**‑bild och andra **Normala** bilder. Det betyder att en presentationsfil innehåller minst en eller flera bilder. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides for Android via Java. Varje bild har ett unikt Id och alla Normala bilder ordnas i en ordning som anges av det nollbaserade indexet.

Aspose.Slides for Android via Java låter utvecklare lägga till tomma bilder i sina presentationer. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)-klassen.  
- Instansiera [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection)-klassen genom att sätta en referens till egenskapen [Slides](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation#getSlides--) (samling av innehålls‑Slide‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)-objektet.  
- Lägg till en tom bild i presentationen i slutet på samlingen av innehållsbilder genom att anropa [**addEmptySlide**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection#addEmptySlide-com.aspose.slides.ILayoutSlide-)-metoderna som exponeras av [ISlideCollection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ISlideCollection)-objektet.  
- Utför lite arbete med den nylagda tomma bilden.  
- Slutligen, skriv presentationsfilen med hjälp av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation)-objektet.

```java
// Instansiera Presentation class som representerar presentationsfilen
Presentation pres = new Presentation();
try {
    // Instansiera SlideCollection-klassen
    ISlideCollection slds = pres.getSlides();

    for (int i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Lägg till en tom bild i Slides-samlingen
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Utför lite arbete på den nyss tillagda bilden

    // Spara PPTX-filen till disken
    pres.save("EmptySlide.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Vanliga frågor**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**  
Ja. Biblioteket stöder bildsamlingar och [insert](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidecollection/#insertEmptySlide-int-com.aspose.slides.ILayoutSlide-)/[clone](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidecollection/#insertClone-int-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-)-operationer, så du kan lägga till en bild på det önskade indexet istället för bara i slutet.

**Bevaras teman/stilar när man lägger till en bild baserad på en layout?**  
Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny "tom" presentation innan man lägger till bilder?**  
En ny skapad presentation innehåller redan en tom bild med index noll. Detta är viktigt att beakta när man beräknar infogningsindex.

**Hur väljer jag den "rätta" layouten för en ny bild om mastern har många alternativ?**  
Välj generellt den [LayoutSlide](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/layoutslide/)-layout som matchar den erforderliga strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [lägga till den i master](/slides/sv/androidjava/slide-layout/) och sedan använda den.