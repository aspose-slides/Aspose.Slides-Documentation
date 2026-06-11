---
title: Ta bort bilder från presentationer i PHP
linktitle: Ta bort bild
type: docs
weight: 30
url: /sv/php-java/remove-slide-from-presentation/
keywords:
- ta bort bild
- radera bild
- ta bort oanvänd bild
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Ta enkelt bort bilder från PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Få tydliga kodexempel och förbättra ditt arbetsflöde."
---
## **Introduktion**

Om en bild (eller dess innehåll) blir överflödig kan du ta bort den. Aspose.Slides tillhandahåller klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/) som kapslar in [SlideCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/), vilket är ett arkiv för alla bilder i en presentation. Genom att använda pekare (referens eller index) för ett känt [Slide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/)-objekt kan du ange den bild du vill ta bort.

## **Ta bort en bild med referens**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till den bild du vill ta bort via dess ID eller index.
1. Ta bort den refererade bilden från presentationen.
1. Spara den ändrade presentationen. 

Denna PHP‑kod visar hur du tar bort en bild via dess referens:

```php
  # Skapa ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("demo.pptx");
  try {
    # Hämtar en bild via dess index i bildsamlingen
    $slide = $pres->getSlides()->get_Item(0);
    # Tar bort en bild via dess referens
    $pres->getSlides()->remove($slide);
    # Sparar den ändrade presentationen
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ta bort en bild med index**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Ta bort bilden från presentationen via dess indexposition.
1. Spara den ändrade presentationen. 

Denna PHP‑kod visar hur du tar bort en bild via dess index:

```php
  # Skapar ett Presentation-objekt som representerar en presentationsfil
  $pres = new Presentation("demo.pptx");
  try {
    # Tar bort en bild via dess bildindex
    $pres->getSlides()->removeAt(0);
    # Sparar den ändrade presentationen
    $pres->save("modified.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Ta bort oanvända layoutbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedLayoutSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) (från klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) ) så att du kan ta bort oönskade och oanvända layoutbilder. Denna PHP‑kod visar hur du tar bort en layoutbild från en PowerPoint‑presentation:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedLayoutSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ta bort oanvända masterbilder**

Aspose.Slides tillhandahåller metoden [removeUnusedMasterSlides](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) (från klassen [Compress](https://reference.aspose.com/slides/sv/php-java/aspose.slides/compress/) ) så att du kan ta bort oönskade och oanvända masterbilder. Denna PHP‑kod visar hur du tar bort en masterbild från en PowerPoint‑presentation:

```php
  $pres = new Presentation("pres.pptx");
  try {
    Compress->removeUnusedMasterSlides($pres);
    $pres->save("pres-out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vanliga frågor**

**Vad händer med bildindexen efter att jag har tagit bort en bild?**

Efter borttagning omindexeras [collection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slidecollection/): varje efterföljande bild förflyttas ett steg åt vänster, så tidigare indexnummer blir föråldrade. Om du behöver en stabil referens, använd varje bilds beständiga ID istället för dess index.

**Är en bilds ID annorlunda än dess index, och förändras det när intilliggande bilder raderas?**

Ja. Indexet är bildens position och förändras när bilder läggs till eller tas bort. Bildens ID är en beständig identifierare och ändras inte när andra bilder raderas.

**Hur påverkar borttagning av en bild bildsektioner?**

Om bilden tillhörde en sektion kommer den sektionen helt enkelt att innehålla en bild mindre. Sektionens struktur kvarstår; om en sektion blir tom kan du [ta bort eller omorganisera sektioner](/slides/sv/php-java/slide-section/) vid behov.

**Vad händer med anteckningar och kommentarer som är knutna till en bild när den tas bort?**

[Notes](/slides/sv/php-java/presentation-notes/) och [comments](/slides/sv/php-java/presentation-comments/) är knutna till den specifika bilden och tas bort tillsammans med den. Innehåll på andra bilder påverkas inte.

**Hur skiljer sig borttagning av bilder från att rensa oanvända layouter/mastere?**

Borttagning tar bort specifika vanliga bilder från presentationen. Rensning av oanvända layouter/mastere tar bort layout‑ eller masterbilder som inget refererar till, vilket minskar filstorleken utan att förändra återstående bildinnehåll. Dessa åtgärder är komplementära: vanligtvis tar du bort först, sedan rensar du.