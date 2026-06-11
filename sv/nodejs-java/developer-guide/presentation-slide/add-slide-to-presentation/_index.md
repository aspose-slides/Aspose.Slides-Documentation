---
title: Lägg till bilder i presentationer i JavaScript
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/nodejs-java/add-slide-to-presentation/
keywords:
- lägg till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java — sömlös, effektiv bildinfogning på några sekunder."
---
## **Översikt**

Aspose.Slides låter dig lägga till bilder i PowerPoint-presentationer programmässigt. En presentation innehåller master-/layout‑bilder och vanliga bilder, och vanliga bilder ordnas med ett nollbaserat index. Varje bild har ett unikt ID, och presentationsfiler utan bilder stöds inte.

Denna artikel förklarar hur du skapar ett `Presentation`‑objekt, får åtkomst till dess bildsamling, lägger till en tom bild, arbetar med den nyligen tillagda bilden och sparar den uppdaterade presentationen. Den behandlar också relaterade frågor såsom att infoga bilder på en specifik position, använda layouter och förstå den tomma bilden som finns i en ny skapad presentation.

## **Lägg till bild i presentation**

Innan vi pratar om att lägga till bilder i presentationsfilerna, låt oss diskutera några fakta om bilderna. Varje PowerPoint‑presentationfil innehåller en **Master / Layout**‑bild och andra **Normal**‑bilder. Det betyder att en presentationsfil innehåller minst en eller flera bilder. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides for Node.js via Java. Varje bild har ett unikt ID och alla normalbilder ordnas i en ordning som anges av det nollbaserade indexet.

Aspose.Slides for Node.js via Java låter utvecklare lägga till tomma bilder i sin presentation. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).
- Instansiera klassen [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection) genom att sätta en referens till egenskapen [Slides](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/Presentation#getSlides--) (samling av innehålls‑Slide‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation)-objektet.
- Lägg till en tom bild i presentationen i slutet av samlingen av innehållsbilder genom att anropa metoden [**addEmptySlide**](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection#addEmptySlide-aspose.slides.ILayoutSlide-) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/SlideCollection).
- Utför någon behandling med den nyligen tillagda tomma bilden.
- Spara slutligen presentationsfilen med hjälp av objektet [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation).

```javascript
// Instansiera Presentation‑klassen som representerar presentationsfilen
var pres = new aspose.slides.Presentation();
try {
    // Instansiera SlideCollection‑klassen
    var slds = pres.getSlides();
    for (var i = 0; i < pres.getLayoutSlides().size(); i++) {
        // Lägg till en tom bild i Slides‑samlingen
        slds.addEmptySlide(pres.getLayoutSlides().get_Item(i));
    }
    // Gör någon bearbetning på den nyligen tillagda bilden
    // Spara PPTX‑filen till disken
    pres.save("EmptySlide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **FAQ**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**

Ja. Biblioteket stöder bildsamlingar och [insert](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidecollection/insertclone/)-operationer, så du kan lägga till en bild på det önskade indexet istället för bara i slutet.

**Bevaras tema/stilar när man lägger till en bild baserad på en layout?**

Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny "tom" presentation innan bilder läggs till?**

En ny skapad presentation innehåller redan en tom bild med index noll. Detta är viktigt att beakta när man beräknar infogningsindex.

**Hur väljer jag rätt layout för en ny bild om mastern har många alternativ?**

Välj vanligtvis den [LayoutSlide](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/layoutslide/) som matchar den önskade strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [lägga till den i master](/slides/sv/nodejs-java/slide-layout/) och sedan använda den.