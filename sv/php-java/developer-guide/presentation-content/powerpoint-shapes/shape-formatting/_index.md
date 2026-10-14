---
title: Formatera PowerPoint-former i PHP
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/php-java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skiss-effekt
- skissformlinje
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- solid färgfyllning
- formtransparens
- svart-vit återgivning av form
- gråskala återgivning av form
- rotera form
- 3D-fasett-effekt
- 3D-rotations-effekt
- återställ formatering
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i PHP med Aspose.Slides—sätt fyllnings‑, linje‑ och effektstilar för PPT-, PPTX‑ och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![formatering av form i PowerPoint](format-shape-powerpoint.png)

Aspose.Slides för PHP via Java tillhandahåller klasser och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange [linjestil](https://reference.aspose.com/slides/php-java/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [streckstil](https://reference.aspose.com/slides/php-java/aspose.slides/linedashstyle/) för linjen.
1. Ange linjens färg för formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

Följande PHP‑kod demonstrerar hur man formaterar en rektangel `AutoShape`:

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en autoform av typen Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 75);

    // Ställ in fyllningsfärgen för rektangelformen.
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    // Applicera formatering på rektangelns linjer.
    $shape->getLineFormat()->setStyle(LineStyle::ThickThin);
    $shape->getLineFormat()->setWidth(7);
    $shape->getLineFormat()->setDashStyle(LineDashStyle::Dash);

    // Ställ in färgen för rektangelns linje.
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Spara PPTX-filen till disk.
    $presentation->save("formatted_lines.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på formens linjer**

En skiss‑effekt får en formlinje att se handritad ut. Använd [Shape.getLineFormat](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) för att komma åt linjeinställningarna, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/) för att komma åt skissinställningarna och [SketchFormat.setSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) för att välja ett värde från enumen [LineSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/).

Följande PHP‑kod visar hur man applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/)‑effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/php-java/aspose.slides/linesketchtype/):

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);

    // Åtkomst till formens linjeformat och dess skissformat.
    $sketchFormat = $shape->getLineFormat()->getSketchFormat();

    // Applicera en skisseffekt.
    $sketchFormat->setSketchType(LineSketchType::Curved);

    // Läs den skisseffekt som tilldelats direkt till formen.
    $explicitSketchType = $sketchFormat->getSketchType();
    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;

    // Ta bort skisseffekten.
    $sketchFormat->setSketchType(LineSketchType::None);
} finally {
    $presentation->dispose();
}
```

Värdet som returneras av [SketchFormat.getSketchType](https://reference.aspose.com/slides/php-java/aspose.slides/sketchformat/) representerar den inställning som tilldelats formen direkt. Om linjeformateringen kan ärvas från ett tema, en huvudbild eller en layout‑bild, använd [LineFormat.getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/lineformat/), få åtkomst till det returnerade objektets `getSketchFormat`‑metod och läs dess `getSketchType`‑värde. Det effektiva värdet speglar den formatering som faktiskt tillämpas efter att arv har lösts:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lineFormat = $shape->getLineFormat();

    $explicitSketchType = $lineFormat->getSketchFormat()->getSketchType();
    $effectiveLineFormat = $lineFormat->getEffective();
    $effectiveSketchType = $effectiveLineFormat->getSketchFormat()->getSketchType();

    echo "Explicit sketch type: " . $explicitSketchType . PHP_EOL;
    echo "Effective sketch type: " . $effectiveSketchType . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Formatera anslutningsstilar**

Här är de tre alternativ för anslutningstyp:

* Rund
* Fasett
* Avfasad

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den **Rund**‑inställningen. Men om du ritar en form med skarpa vinklar kan du föredra **Fasett**‑alternativet.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande PHP‑kod demonstrerar hur tre rektanglar (som visas i bilden ovan) skapades med Miter, Bevel och Round‑inställningarna för anslutningstyp:

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till tre autoformer av typen Rectangle.
    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 75);
    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 210, 20, 150, 75);
    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 135, 150, 75);

    // Ställ in fyllningsfärgen för varje rektangelform.
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

    // Ställ in linjebredden.
    $shape1->getLineFormat()->setWidth(15);
    $shape2->getLineFormat()->setWidth(15);
    $shape3->getLineFormat()->setWidth(15);

    // Ställ in färgen för varje rektangels linje.
    $shape1->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape2->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $shape3->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);

    // Ställ in anslutningsstilen.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Lägg till text i varje rektangel.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Spara PPTX-filen till disk.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du använda två eller fler färger så att den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två föredragna färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/php-java/aspose.slides/gradientformat/).
1. Spara den ändrade presentationen som en PPTX‑fil.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en autoform av typen Ellipse.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 150, 75);

    // Applicera gradientformatering på ellipsen.
    $shape->getFillFormat()->setFillType(FillType::Gradient);
    $shape->getFillFormat()->getGradientFormat()->setGradientShape(GradientShape::Linear);

    // Ställ in gradientens riktning.
    $shape->getFillFormat()->getGradientFormat()->setGradientDirection(GradientDirection::FromCorner2);

    // Lägg till två gradientstopp.
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(1.0, PresetColor::Purple);
    $shape->getFillFormat()->getGradientFormat()->getGradientStops()->addPresetColor(0, PresetColor::Red);

    // Spara PPTX-filen till disk.
    $presentation->save("gradient_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Ellipsen med gradientfyllning](gradient-fill.png)

Om en gradient ser annorlunda ut i en exporterad bild jämfört med i PowerPoint, se [Choose a Gradient Rendering Style](/slides/sv/php-java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style). Du kan välja en renderingsstil utan att ändra gradientfyllningen som lagras i presentationen.

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign — såsom prickar, ränder, korsstreck eller rutor — på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra det visuella uttrycket i dina presentationer. Även efter att du valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger det ska använda.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ange [Background Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getBackColor) för mönstret.
1. Ange [Foreground Color](https://reference.aspose.com/slides/php-java/aspose.slides/patternformat/#getForeColor) för mönstret.
1. Spara den ändrade presentationen som en PPTX‑fil.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en autoform av typen Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Pattern.
    $shape->getFillFormat()->setFillType(FillType::Pattern);

    // Ställ in mönsterstilen.
    $shape->getFillFormat()->getPatternFormat()->setPatternStyle(PatternStyle::Trellis);

    // Ställ in mönstrets bakgrunds- och förgrundsfärger.
    $shape->getFillFormat()->getPatternFormat()->getBackColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
    $shape->getFillFormat()->getPatternFormat()->getForeColor()->setColor(java("java.awt.Color")->YELLOW);

    // Spara PPTX-filen till disk.
    $presentation->save("pattern_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form — i praktiken använder du bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) till `Picture`.
1. Ange bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [PPImage](https://reference.aspose.com/slides/php-java/aspose.slides/ppimage/)‑objekt från bilden du vill använda.
1. Skicka bilden till metoden `SlidesPicture.setImage`.
1. Spara den ändrade presentationen som en PPTX‑fil.

Anta att vi har en fil "lotus.png" med följande bild:

![Lotus‑bilden](lotus.png)

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en autoform av typen Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 255, 130);

    // Ställ in fyllningstypen till Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Ställ in bildfyllningsläget.
    $shape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Tile);

    // Läs in en bild och lägg till den i presentationens resurser.
    $image = Images::fromFile("lotus.png");
    $picture = $presentation->getImages()->addImage($image);
    $image->dispose();

    // Ställ in bilden.
    $shape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);

    // Spara PPTX-filen till disk.
    $presentation->save("picture_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Formen med bildfyllning](picture-fill.png)

### **Tile‑bild som textur**

Om du vill ställa in en kaklad bild som textur och anpassa kaklingsbeteendet kan du använda följande metoder i klassen [PictureFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Ställer in bildfyllningsläget — antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileAlignment): Anger justeringen av kaklorna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileFlip): Kontrollerar om kaklan vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Ställer in den horisontella förskjutningen av kaklan (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Ställer in den vertikala förskjutningen av kaklan (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definierar den horisontella skalningen av kaklan i procent.
- [setTileScaleY](https://reference.aspose.com/slides/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definierar den vertikala skalningen av kaklan i procent.

Följande kodexempel visar hur man lägger till en rektangel med en kaklad bildfyllning och konfigurerar kaklagealternativ:

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Lägg till en rektangel autoform.
    $shape = $firstSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 190, 95);

    // Ställ in fyllningstypen för formen till Picture.
    $shape->getFillFormat()->setFillType(FillType::Picture);

    // Läs in bilden och lägg till den i presentationens resurser.
    $sourceImage = Images::fromFile("lotus.png");
    $presentationImage = $presentation->getImages()->addImage($sourceImage);
    $sourceImage->dispose();

    // Tilldela bilden till formen.
    $pictureFillFormat = $shape->getFillFormat()->getPictureFillFormat();
    $pictureFillFormat->getPicture()->setImage($presentationImage);

    // Konfigurera bildfyllningsläget och kakelinställningarna.
    $pictureFillFormat->setPictureFillMode(PictureFillMode::Tile);
    $pictureFillFormat->setTileOffsetX(-32);
    $pictureFillFormat->setTileOffsetY(-32);
    $pictureFillFormat->setTileScaleX(50);
    $pictureFillFormat->setTileScaleY(50);
    $pictureFillFormat->setTileAlignment(RectangleAlignment::BottomRight);
    $pictureFillFormat->setTileFlip(TileFlip::FlipBoth);

    // Spara PPTX-filen till disk.
    $presentation->save("tile.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Kaklagealternativen](tile-options.png)

## **Enkel färgfyllning**

I PowerPoint är Solid Color Fill ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en solid färgfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange formens [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllnadsfärg till formen.
1. Spara den ändrade presentationen som en PPTX‑fil.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en autoform av typen Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Solid.
    $shape->getFillFormat()->setFillType(FillType::Solid);

    // Ställ in fyllningsfärgen.
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);

    // Spara PPTX-filen till disk.
    $presentation->save("solid_color_fill.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Formen med solid färgfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en solid färg, gradient, bild eller texturfyllning på former kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt blir delvis synliga.

Aspose.Slides låter dig ange transparensnivån genom att justera alfavärdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange [FillType](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alfakomponenten styr transparensen).
1. Spara presentationen.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en solid rektangel autoform.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel autoform ovanpå den solida formen.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Spara PPTX-filen till disk.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Den transparenta formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justerings‑ eller designbehov.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Ange formens rotations‑egenskap till önskad vinkel.
1. Spara presentationen.

```php
// Instansiera Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en autoform av typen Rectangle.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    $shape->setRotation(5);

    // Spara PPTX-filen till disk.
    $presentation->save("shape_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Formens rotation](shape-rotation.png)

## **Lägg till 3D‑fasett‑effekter**

Aspose.Slides låter dig applicera 3D‑fasett‑effekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)‑egenskaper.

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/) för att definiera fasettinställningar.
1. Spara presentationen.

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en form på bilden.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 50, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GREEN);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->ORANGE);
    $shape->getLineFormat()->setWidth(2.0);

    // Ställ in formens ThreeDFormat-egenskaper.
    $shape->getThreeDFormat()->setDepth(4);
    $shape->getThreeDFormat()->getBevelTop()->setBevelType(BevelPresetType::Circle);
    $shape->getThreeDFormat()->getBevelTop()->setHeight(6);
    $shape->getThreeDFormat()->getBevelTop()->setWidth(6);
    $shape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::OrthographicFront);
    $shape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::ThreePt);
    $shape->getThreeDFormat()->getLightRig()->setDirection(LightingDirection::Top);

    // Spara presentationen som en PPTX-fil.
    $presentation->save("3D_bevel_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![3D‑fasett‑effekten](3D-bevel-effect.png)

## **Lägg till 3D‑rotations‑effekter**

Aspose.Slides låter dig applicera 3D‑rotationseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/php-java/aspose.slides/threedformat/)‑egenskaper.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild efter dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/php-java/aspose.slides/autoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/php-java/aspose.slides/camera/#setCameraType) och [setLightType](https://reference.aspose.com/slides/php-java/aspose.slides/lightrig/#setLightType) för att definiera 3D‑rotationen.
1. Spara presentationen.

```php
// Skapa en instans av Presentation-klassen.
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);
    $autoShape->getTextFrame()->setText("Hello, Aspose!");

    $autoShape->getThreeDFormat()->setDepth(6);
    $autoShape->getThreeDFormat()->getCamera()->setRotation(40, 35, 20);
    $autoShape->getThreeDFormat()->getCamera()->setCameraType(CameraPresetType::IsometricLeftUp);
    $autoShape->getThreeDFormat()->getLightRig()->setLightType(LightRigPresetType::Balanced);

    // Spara presentationen som en PPTX-fil.
    $presentation->save("3D_rotation_effect.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![3D‑rotations‑effekten](3D-rotation-effect.png)

## **Styr svart‑vit rendering för former**

[Shape::setBlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/shape/#setBlackWhiteMode)-metoden specificerar hur en enskild form renderas när en presentation visas eller bearbetas i svart‑vit läge. Den aktiverar inte svart‑vit visning i sig själv och ändrar inte formens fyllning, linje eller annan formatering i normalt färgläge.

Använd ett värde från klassen [BlackWhiteMode](https://reference.aspose.com/slides/php-java/aspose.slides/blackwhitemode/) för att välja önskat beteende. Till exempel låter `Automatic` renderingsprogrammet välja konverteringen, `Gray` och `LightGray` använder grå färgning, `BlackWhite` använder endast svart och vitt, `Black` och `White` tvingar en enda färg, `Color` bevarar normal färgning, och `Hidden` utesluter formen i svart‑vit läge. `NotDefined` betyder att inget läge på formnivå har tilldelats.

Följande PHP‑kod skapar en färgad form och får den att visas grå i svart‑vit visningsläge:

```php
use aspose\slides\BlackWhiteMode;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 200, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $orange = new Java("java.awt.Color", 255, 165, 0);
    $shape->getFillFormat()->getSolidFillColor()->setColor($orange);

    // Behåll den orange fyllningen i färgläge, men rendera formen med grå färgning i svart-vitt läge.
    $shape->setBlackWhiteMode(BlackWhiteMode::Gray);

    $presentation->save("shape_black_white_mode.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

I normalt färgläge behåller rektangeln sin orange fyllning. I ett arbetsflöde för svart‑vit visning använder den grå färgning eftersom dess läge är satt till `Gray`. Detta låter dig behålla en färgrik bild när du definierar ett eget utseende för utskrift, förhandsgranskning eller andra arbetsflöden som respekterar presentationens svart‑vita visningsinställningar.

## **Återställ formatering**

Följande Java‑kod visar hur man återställer formatering av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/) till deras standardinställningar:

```php
$presentation = new Presentation("sample.pptx");
try {
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        // Återställ varje form på bilden som har en platshållare på layouten.
        $slide->reset();
    }
    $presentation->save("reset_formatting.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Vanliga frågor**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media tar upp mest av filens utrymme, medan formparametrar såsom färger, effekter och gradienter lagras som metadata och tillför praktiskt taget ingen extra storlek.

**Hur kan jag identifiera former på en bild som delar identisk formatering så att jag kan gruppera dem?**

Jämför varjeformes viktigaste formateringsegenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, betraktas deras stilar som identiska och du kan logiskt gruppera dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildserie eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de former du behöver och återapplicera deras formatering där det behövs.