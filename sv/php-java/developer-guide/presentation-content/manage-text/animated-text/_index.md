---
title: Animera PowerPoint-text i PHP
linktitle: Animerad text
type: docs
weight: 60
url: /sv/php-java/animated-text/
keywords:
- animerad text
- textanimation
- animerat stycke
- styckeanimation
- animationseffekt
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Skapa dynamisk animerad text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java, med enkla, optimerade kodexempel."
---
## **Översikt**

Denna artikel förklarar hur du arbetar med animerad text i Aspose.Slides genom att tillämpa animationseffekter på enskilda stycken och hämta de effekter som redan har tilldelats stycken i en textram. Den fokuserar på API‑metoderna som används för att lägga till stycknivåanimation och för att inspektera befintliga styckeanimationseffekter i en presentation.

## **Lägg till animationseffekter på stycken**

Vi har lagt till metoden [**addEffect()**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) i klassen [**Sequence**](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Sequence). Denna metod låter dig lägga till animationseffekter på ett enskilt stycke. Följande exempel visar hur du lägger till en animationseffekt på ett enskilt stycke:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # välj stycke för att lägga till effekt
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # lägg till Fly-animationseffekt på valt stycke
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Hämta animationseffekter för stycken**

Du kanske vill ta reda på vilka animationseffekter som har lagts till i ett stycke – till exempel kan du i ett scenario vilja hämta animationseffekterna i ett stycke eftersom du planerar att applicera dessa effekter på ett annat stycke eller en annan form. Aspose.Slides för PHP via Java låter dig hämta alla animationseffekter som har applicerats på stycken i en textram (form). Följande exempel visar hur du hämtar animationseffekterna i ett stycke:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Hur skiljer sig textanimationer från bildövergångar, och kan de kombineras?**

Textanimationer styr objektets beteende över tid på en bild, medan [transitions](/slides/sv/php-java/slide-transition/) styr hur bilderna förändras. De är oberoende och kan användas tillsammans; uppspelningsordningen styrs av animationstidslinjen och övergångsinställningarna.

**Behålls textanimationer vid export till PDF eller bilder?**

Nej. PDF och rasterbilder är statiska, så du ser ett enda tillstånd av bilden utan rörelse. För att behålla rörelsen, använd export till [video](/slides/sv/php-java/convert-powerpoint-to-video/) eller [HTML](/slides/sv/php-java/export-to-html5/).

**Fungerar textanimationer i layouter och bildmastern?**

Effekter som appliceras på layout-/mastern objekt ärvs av bilderna, men deras tidsinställning och interaktion med bildnivåanimationer beror på den slutgiltiga sekvensen på bilden.