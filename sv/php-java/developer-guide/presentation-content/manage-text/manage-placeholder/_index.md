---
title: Hantera presentationsplatshållare i PHP
linktitle: Hantera platshållare
type: docs
weight: 10
url: /sv/php-java/manage-placeholder/
keywords:
- platshållare
- textplatshållare
- bildplatshållare
- diagramplatshållare
- uppmaningstext
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera enkelt platshållare i Aspose.Slides för PHP via Java: ersätt text, anpassa uppmaningar och ställ in bildtransparens i PowerPoint och OpenDocument."
---
## **Översikt**

Aspose.Slides låter dig hantera platshållare i presentationer programmatiskt. Den här artikeln förklarar hur du hittar platshållare på bilder och ändrar deras text, anger anpassade prompttexter för platshållarlayouter och justerar transparensen för en bild som används som bakgrund för en platshållare. Den innehåller också en kort FAQ som klargör skillnaden mellan basplatshållare och lokala former, förklarar hur ändringar av platshållare kan tillämpas via layouter eller master‑bilder och pekar på hantering av sidhuvud‑ och sidfot‑platshållare.

## **Ändra text i en platshållare**
Genom att använda [Aspose.Slides for PHP via Java](/slides/sv/php-java/) kan du hitta och modifiera platshållare på bilder i presentationer. Aspose.Slides låter dig göra ändringar i texten i en platshållare.

**Förutsättning**: Du behöver en presentation som innehåller en platshållare. Sådan presentation kan du skapa i det vanliga Microsoft PowerPoint‑programmet.

Så här använder du Aspose.Slides för att ersätta texten i platshållaren i den presentationen:

1. Skapa en instans av [`Presentation`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation)-klassen och ange presentationen som argument.
2. Hämta en bildreferens via dess index.
3. Iterera genom formerna för att hitta platshållaren.
4. Typkonvertera platshållarformen till en [`AutoShape`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/AutoShape) och ändra texten med hjälp av [`TextFrame`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/TextFrame) som är associerad med [`AutoShape`](https://reference.aspose.com/slides/sv/php-java/aspose.slides/AutoShape).
5. Spara den modifierade presentationen.

Den här PHP‑koden visar hur du ändrar texten i en platshållare:

```php
  # Instansierar en Presentation-klass
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Åtkomst till den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Itererar genom former för att hitta platshållaren
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Ändrar texten i varje platshållare
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Sparar presentationen till disk
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ange prompttext i en platshållare**
Standard‑ och förbyggda layouter innehåller prompttexter för platshållare såsom ***Klicka för att lägga till en rubrik*** eller ***Klicka för att lägga till en underrubrik***. Med Aspose.Slides kan du infoga dina egna prompttexter i platshållarlayouter.

Den här PHP‑koden visar hur du anger prompttexten i en platshållare:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Itererar genom bilden
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint visar "Klicka för att lägga till titel"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Lägger till underrubrik
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Ställ in transparens för bild i platshållare**

Aspose.Slides låter dig ange transparensen för bakgrundsbilden i en text‑platshållare. Genom att justera transparensen för bilden i ett sådant ramverk kan du låta texten eller bilden framträda tydligare (beroende på färgerna i texten och bilden).

Den här PHP‑koden visar hur du ställer in transparensen för en bildbakgrund (i en form):

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Vad är en grundplatshållare och hur skiljer den sig från en lokal form på en bild?**

En grundplatshållare är den ursprungliga formen i en layout eller master som bildens form ärver från – typ, position och viss formatering kommer från den. En lokal form är oberoende; om det inte finns någon grundplatshållare gäller ingen arv.

**Hur kan jag uppdatera alla rubriker eller bildtexter i en presentation utan att iterera över varje bild?**

Redigera den motsvarande platshållaren i layouten eller i master‑bilden. Bilder som baseras på de layouter/master‑bilderna kommer automatiskt att ärva ändringen.

**Hur styr jag de standardiserade sidhuvuds-/sidfotsplatshållarna—datum & tid, bildnummer och sidfotstext?**

Använd HeaderFooter‑hanterarna på lämplig nivå (vanliga bilder, layouter, master, anteckningar/handouts) för att slå på eller av dessa platshållare och för att ange deras innehåll.