---
title: Lägg till ellipser i presentationer i PHP
linktitle: Ellips
type: docs
weight: 30
url: /sv/php-java/ellipse/
keywords:
- ellips
- form
- lägg till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för PHP via Java i PPT- och PPTX-presentationer — kodexempel inkluderade."
---
## **Översikt**

Den här artikeln visar hur du lägger till ellipsformer i PowerPoint-bilder med Aspose.Slides. Den täcker att skapa en enkel ellips, att skapa en formaterad ellips och att spara den uppdaterade presentationen som en PPTX-fil. Den berör också relaterade frågor som att arbeta med ellipsens position och storlek, att kontrollera staplingsordning och att tillämpa animationseffekter.

## **Skapa en ellips**
För att lägga till en enkel ellips på ett valt bildspel i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Ellipse med metoden [addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).
- Skriv den modifierade presentationen som en PPTX-fil.

I exemplet nedan har vi lagt till en ellips på den första bilden

```php
  # Instansiera Presentation-klassen som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till AutoShape av ellipstyp
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Skriv PPTX-filen till disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Skapa en formaterad ellips**
För att lägga till en bättre formaterad ellips på en bild, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en AutoShape av typen Ellipse med metoden [addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).
- Ställ in fyllningstypen för ellipsen till Solid.
- Ställ in färgen för ellipsen med metoden `SolidFillColor::setColor` som exponeras av objektet [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) som är kopplat till objektet [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/).
- Ställ in färgen på ellipsens linjer.
- Ställ in bredden på ellipsens linjer.
- Skriv den modifierade presentationen som en PPTX-fil.

I exemplet nedan har vi lagt till en formaterad ellips på den första bilden i presentationen.

```php
  # Instansiera Presentation-klassen som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till AutoShape av ellipstyp
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Applicera viss formatering på ellipsformen
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Applicera viss formatering på Ellipsens linje
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Skriv PPTX-filen till disk
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hur anger jag den exakta positionen och storleken på en ellips i förhållande till bildens enheter?**

Koordinater och storlekar anges vanligtvis **i punkter**. För förutsägbara resultat bör du basera dina beräkningar på bildens storlek och konvertera behövda millimeter eller tum till punkter innan du tilldelar värden.

**Hur kan jag placera en ellips ovanför eller under andra objekt (kontrollera staplingsordning)?**

Justera ritordningen för objektet genom att föra det framåt eller skicka det bakåt. Detta låter ellipsen överlappa andra objekt eller avslöja de som ligger under den.

**Hur animerar jag en ellipss framträdande eller betoning?**

[Apply](/slides/sv/php-java/shape-animation/) ingångs-, betoning- eller avslutningseffekter på formen och konfigurera triggers och tidpunkter för att styra när och hur animationen spelas.