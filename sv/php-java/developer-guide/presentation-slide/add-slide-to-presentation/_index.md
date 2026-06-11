---
title: Lägg till bilder i presentationer i PHP
linktitle: Lägg till bild
type: docs
weight: 10
url: /sv/php-java/add-slide-to-presentation/
keywords:
- lägga till bild
- skapa bild
- tom bild
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Lägg enkelt till bilder i dina PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för PHP via Java — sömlös och effektiv bildinfogning på några sekunder."
---
## **Översikt**

Aspose.Slides låter dig lägga till bilder i PowerPoint‑presentationer programatiskt. En presentation innehåller master‑/layoutbilder och vanliga bilder, och de vanliga bilderna ordnas enligt ett nollbaserat index. Varje bild har ett unikt ID, och presentationsfiler utan bilder stöds inte.

Den här artikeln förklarar hur du skapar ett `Presentation`‑objekt, får åtkomst till dess bildsamling, lägger till en tom bild, arbetar med den nyligen tillagda bilden och sparar den uppdaterade presentationen. Den behandlar även relaterade punkter såsom att infoga bilder på en specifik position, använda layouter och förstå den tomma bilden som finns i en ny skapad presentation.

## **Lägg till en bild i en presentation**

Innan vi pratar om att lägga till bilder i presentationsfilerna, låt oss diskutera några fakta om bilderna. Varje PowerPoint‑presentationfil innehåller **Master / Layout**‑bild och andra **Normala** bilder. Det innebär att en presentationsfil innehåller minst en bild eller fler. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides for PHP via Java. Varje bild har ett unikt Id och alla normala bilder ordnas i en följd som anges av det nollbaserade indexet.

Aspose.Slides for PHP via Java låter utvecklare lägga till tomma bilder i sin presentation. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
- Hämta objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/) genom att använda metoden [getSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation#getSlides--) (samling av innehålls‑Slide‑objekt) som exponeras av [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation)-objektet.
- Lägg till en tom bild i presentationen i slutet av samlingen av innehållsbilder genom att anropa metoden [**addEmptySlide**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/#addEmptySlide) som exponeras av objektet [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/).
- Utför några operationer med den nyss tillagda tomma bilden.
- Slutligen, skriv presentationsfilen med hjälp av objektet [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).

```php
  # Instansiera Presentation-klass som representerar presentationsfilen
  $pres = new Presentation();
  try {
    # Instansiera SlideCollection-klass
    $slds = $pres->getSlides();
    for($i = 0; $i < java_values($pres->getLayoutSlides()->size()) ; $i++) {
      # Lägg till en tom bild i Slides-samlingen
      $slds->addEmptySlide($pres->getLayoutSlides()->get_Item($i));
    }
    # Utför något arbete på den nyligen tillagda bilden
    # Spara PPTX-filen till disken
    $pres->save("EmptySlide.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Vanliga frågor**

**Kan jag infoga en ny bild på en specifik position, inte bara i slutet?**

Ja. Biblioteket stöder bildsamlingar och [insert](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/insertemptyslide/)/[clone](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/insertclone/)‑operationer, så du kan lägga till en bild på det önskade indexet istället för endast i slutet.

**Behåller temat/stilarna sig när man lägger till en bild baserad på en layout?**

Ja. En layout ärver formatering från sin master, och den nya bilden ärver från den valda layouten och dess associerade master.

**Vilken bild finns i en ny "tom" presentation innan bilder läggs till?**

En ny skapad presentation innehåller redan en tom bild med index noll. Detta är viktigt att beakta när du beräknar infogningsindex.

**Hur väljer jag rätt layout för en ny bild om mastern har många alternativ?**

Välj vanligtvis den [LayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/) som matchar den behövda strukturen ([Title and Content, Two Content, etc.](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidelayouttype/)). Om en sådan layout saknas kan du [lägg till den i mastern](/slides/sv/php-java/slide-layout/) och sedan använda den.