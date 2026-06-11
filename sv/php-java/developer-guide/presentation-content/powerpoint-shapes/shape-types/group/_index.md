---
title: Gruppformar i presentationer i PHP
linktitle: Formgrupp
type: docs
weight: 40
url: /sv/php-java/group/
keywords:
- gruppform
- formgrupp
- lägg till grupp
- alternativ text
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig att gruppera och avgruppera former i PowerPoint-presentationer med Aspose.Slides för PHP via Java — snabb, steg-för-steg-guide med fri kod."
---
## **Översikt**

Den här artikeln förklarar hur du arbetar med gruppformer i Aspose.Slides. Den visar hur du lägger till en gruppform på en bild, placerar former i den och sparar den uppdaterade presentationen. Den demonstrerar också hur du får åtkomst till former som lagras i en grupp och läser deras `AlternativeText`‑värden. Dessutom behandlar artikeln kort relaterade funktioner för gruppformer, såsom nästlade grupper, z‑ordning och låsalternativ.

## **Lägg till en gruppform**
Aspose.Slides stödjer arbete med gruppformer på bilder. Denna funktion hjälper utvecklare att skapa rikare presentationer. Aspose.Slides för PHP via Java stödjer att lägga till eller komma åt gruppformer. Det är möjligt att lägga till former i en lagd gruppform för att fylla den eller komma åt någon egenskap för gruppformen. För att lägga till en gruppform på en bild med Aspose.Slides för PHP via Java:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation).
1. Hämta referensen till en bild genom att använda dess Index.
1. Lägg till en gruppform på bilden.
1. Lägg till formerna i den lagda gruppformen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Exemplet nedan lägger till en gruppform på en bild.

```php
  # Instansiera Presentation-klassen
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Kom åt samlingen av former på bilderna
    $slideShapes = $sld->getShapes();
    # Lägger till en gruppform på bilden
    $groupShape = $slideShapes->addGroupShape();
    # Lägger till former i den lagda gruppformen
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Lägger till gruppformens ram
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # Skriv PPTX-filen till disk
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Åtkomst till AltText‑egenskapen**
Detta avsnitt visar enkla steg, komplett med kodexempel, för att lägga till en gruppform och komma åt AltText‑egenskapen för gruppformer på bilder. För att komma åt AltText för en gruppform i en bild med Aspose.Slides för PHP via Java:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/Presentation) som representerar en PPTX‑fil.
1. Hämta referensen till en bild genom att använda dess Index.
1. Kom åt bildens formsamling.
1. Kom åt gruppformen.
1. Kom åt egenskapen [Alternative Text](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getAlternativeText).

Exemplet nedan kommer åt alternativtexten för gruppformen.

```php
  # Instansiera Presentation-klassen som representerar PPTX fil
  $pres = new Presentation("AltText.pptx");
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Kom åt samlingen av former på bilderna
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Kom åt gruppformen.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Kom åt AltText-egenskapen
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Stöds nästlig gruppering (en grupp i en grupp)?**

Ja. [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/) har en [getParentGroup](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getparentgroup/)‑metod, som direkt indikerar stöd för hierarki (en grupp kan vara ett barn till en annan grupp).

**Hur kontrollerar jag gruppens z-ordning i förhållande till andra objekt på bilden?**

Använd [GroupShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/)‑metoden [getZOrderPosition](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/getzorderposition/) för att inspektera dess position i visningsstacken.

**Kan jag förhindra flyttning/redigering/avgruppering?**

Ja. Gruppens låssektion exponeras via [GroupShapeLock](https://reference.aspose.com/slides/sv/php-java/aspose.slides/groupshape/getgroupshapelock/), vilket låter dig begränsa operationer på objektet.