---
title: Jämför presentationsbilder i PHP
linktitle: Jämför bilder
type: docs
weight: 50
url: /sv/php-java/compare-slides/
keywords:
- jämför bilder
- bildjämförelse
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Jämför PowerPoint- och OpenDocument-presentationer programatiskt med Aspose.Slides för PHP via Java. Identifiera snabbt bildskillnader i koden."
---
## **Introduktion**

Aspose.Slides låter dig jämföra bilder, layoutbilder och masterbilder med hjälp av `equals`‑metoden som tillhandahålls av `BaseSlide`‑klassen. Metoden returnerar `true` när de jämförda bilderna är identiska i sin struktur och statiskt innehåll.

## **Jämför två bilder**

Equals‑metoden har lagts till i klassen [BaseSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/BaseSlide) . Den returnerar true för bilder/layout och bilder/master som är identiska i sin struktur och statiskt innehåll.

Två bilder är lika om alla former, stilar, texter, animationer och andra inställningar osv. är lika. Jämförelsen tar inte hänsyn till unika identifieringsvärden, t.ex. SlideId och dynamiskt innehåll, t.ex. aktuellt datumvärde i datumplatshållare.

```php
  $presentation1 = new Presentation("AccessSlides.pptx");
  try {
    $presentation2 = new Presentation("HelloWorld.pptx");
    try {
      for($i = 0; $i < java_values($presentation1->getMasters()->size()) ; $i++) {
        for($j = 0; $j < java_values($presentation2->getMasters()->size()) ; $j++) {
          if ($presentation1->getMasters()->get_Item($i)->equals($presentation2->getMasters()->get_Item($j))) {
            echo(sprintf("SomePresentation1 MasterSlide#%d is equal to SomePresentation2 MasterSlide#%d", $i, $j));
          }
        }
      }
    } finally {
      $presentation2->dispose();
    }
  } finally {
    $presentation1->dispose();
  }
```

## **FAQ**

**Påverkar det att en bild är dold jämförelsen av bilderna själva?**

[Hidden status](https://reference.aspose.com/slides/sv/php-java/aspose.slides/slide/gethidden/) är en egenskap på presentations-/uppspelningsnivå, inte visuellt innehåll. Likheten mellan två specifika bilder bestäms av deras struktur och statiskt innehåll; det faktum att en bild är dold gör inte bilderna olika.

**Tas hyperlänkar och deras parametrar med i beräkningen?**

Ja. Länkar är en del av en bilds statiska innehåll. Om URL:en eller hyperlänkåtgärden skiljer sig, behandlas detta vanligtvis som en skillnad i statiskt innehåll.

**Om ett diagram refererar till en extern Excel‑fil, tas innehållet i den filen med i beräkningen?**

Nej. Jämförelsen utförs baserat på bilderna själva. Externa datakällor läses vanligtvis inte vid jämförelsetillfället; endast det som finns i bildens struktur och statiska tillstånd tas med.