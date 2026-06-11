---
title: Lägg till rektanglar i presentationer i PHP
linktitle: Rektangel
type: docs
weight: 80
url: /sv/php-java/rectangle/
keywords:
- lägga till rektangel
- skapa rektangel
- rektangelform
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Förbättra dina PowerPoint-presentationer genom att lägga till rektanglar med Aspose.Slides för PHP via Java — designa och ändra former programatiskt på ett enkelt sätt."
---
## **Översikt**

Den här artikeln visar hur man lägger till rektangelformer i PowerPoint‑bilder med Aspose.Slides. Den täcker att skapa en enkel rektangel, att skapa en formaterad rektangel och att spara den uppdaterade presentationen som en PPTX‑fil.

Du får också se hur du tillämpar grundläggande formatering av rektangeln, såsom en solid fyllnadsfärg, linjefärg och linjebredd. Dessutom pekar artikelns FAQ på relaterade rektangeltasks, inklusive rundade hörn, bildfyllningar, visuella effekter, hyperlänkar, formlås, exportalternativ och effektiva egenskaper.

## **Lägg till en rektangel på en bild**
För att lägga till en enkel rektangel på den valda bilden i presentationen, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) av typ Rectangle med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).
- Skriv den modifierade presentationen som en PPTX‑fil.

I exemplet nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

```php
  # Instansiera Presentation‑klassen som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till AutoShape av ellipse‑typ
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Skriv PPTX‑filen till disk
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lägg till en formaterad rektangel på en bild**
För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation).
- Hämta referensen till en bild genom att använda dess Index.
- Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) av typ Rectangle med hjälp av metoden [addAutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/#addAutoShape) som exponeras av objektet [ShapeCollection](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapecollection/).
- Ställ in [Fill Type] för rektangeln till Solid.
- Ställ in färgen på rektangeln med metoden [ColorFormat::setColor](https://reference.aspose.com/slides/sv/php-java/aspose.slides/colorformat/#setColor) som exponeras av objektet [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/) som är associerat med objektet [Shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/).
- Ställ in färgen på rektangelns linjer.
- Ställ in bredden på rektangelns linjer.
- Skriv den modifierade presentationen som en PPTX‑fil.

Ovanstående steg är implementerade i exemplet nedan.

```php
  # Instansiera Presentation‑klassen som representerar PPTX
  $pres = new Presentation();
  try {
    # Hämta den första bilden
    $sld = $pres->getSlides()->get_Item(0);
    # Lägg till AutoShape av ellips‑typ
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Tillämpa viss formatering på ellipsformen
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Tillämpa viss formatering på ellipsens linje
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Skriv PPTX‑filen till disk
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hur lägger jag till en rektangel med rundade hörn?**

Använd den rundade hörn‑[shape type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; rundning kan också appliceras per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fill type](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/), ange bildkällan och konfigurera [stretching/tiling modes](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/sv/php-java/shape-effect/) finns tillgängliga med justerbara parametrar.

**Kan jag göra en rektangel till en knapp med en hyperlänk?**

Ja. [Assign a hyperlink](/slides/sv/php-java/manage-hyperlinks/) till formens klick (hoppa till en bild, fil, webbadress eller e‑mail).

**Hur kan jag skydda en rektangel mot att flyttas och förändras?**

Använd formlås: du kan förbjuda flyttning, storleksändring, markering eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [render the shape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/#getImage) till en bild med en angiven storlek/skala eller [export it as SVG](https://reference.aspose.com/slides/sv/php-java/aspose.slides/shape/writeassvg/) för vektoranvändning.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Use the shape’s effective properties](/slides/sv/php-java/shape-effective-properties/): API‑t returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar analys av formatering.