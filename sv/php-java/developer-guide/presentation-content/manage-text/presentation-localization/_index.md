---
title: Automatisera lokalisering av presentationer i PHP
linktitle: Presentation lokalisering
type: docs
weight: 100
url: /sv/php-java/presentation-localization/
keywords:
- ändra språk
- stavningskontroll
- språk-id
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Automatisera lokalisering av PowerPoint- och OpenDocument-bilder med Aspose.Slides för PHP via Java, med praktiska kodexempel och tips för snabbare global utrullning."
---
## **Översikt**

Denna artikel förklarar hur du ställer in `LanguageId` för text i en presentation med hjälp av Aspose.Slides. Den visar hur du öppnar en presentation, lägger till en form med text, tilldelar ett språkidentifierare till en textdel och sparar resultatet som en PPTX‑fil.

## **Ändra språk för en presentation och formtext**
- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
- Hämta referensen till en bild genom att använda dess index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) av typen [Rectangle](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ShapeType#Rectangle) på bilden.
- Lägg till lite text i TextFrame.
- [Set Language Id](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) till text.
- Skriv presentationen som en PPTX‑fil.

Implementeringen av ovanstående steg demonstreras nedan i ett exempel.

```php
  $pres = new Presentation("test.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 50);
    $shape->addTextFrame("Text to apply spellcheck language");
    $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLanguageId("en-EN");
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Utlöser språk-ID automatisk översättning av text?**

Nej. [Language ID](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) i Aspose.Slides lagrar språket för stavningskontroll och grammatikkontroll, men den översätter inte eller ändrar textinnehållet. Det är metadata som PowerPoint förstår för korrekturgranskning.

**Påverkar språk-ID avstavning och radbrytningar vid rendering?**

I Aspose.Slides används [language ID](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) för korrekturgranskning. Kvaliteten på avstavning och radbrytning beror främst på tillgängligheten av [proper fonts](/slides/sv/php-java/powerpoint-fonts/) samt layout‑/radbrytningsinställningar för skriftsystemet. För att säkerställa korrekt rendering, gör de nödvändiga typsnitten tillgängliga, konfigurera [font substitution rules](/slides/sv/php-java/font-substitution/) och/eller [embed fonts](/slides/sv/php-java/embedded-font/) i presentationen.

**Kan jag ange olika språk inom ett enda stycke?**

Ja. [Language ID](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/#setLanguageId) tillämpas på textdelsnivå, så ett enda stycke kan blanda flera språk med olika korrekturinställningar.