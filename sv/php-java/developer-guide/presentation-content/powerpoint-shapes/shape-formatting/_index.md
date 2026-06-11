---
title: Formatera PowerPoint-former i PHP
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/php-java/shape-formatting/
keywords:
- formatera form
- formatera linje
- formatera fogstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- rotera form
- 3D‑kantningseffekt
- 3D‑roteringseffekt
- återställ formatering
- PowerPoint
- presentation
- PHP
- Aspose.Slides
description: "Lär dig hur du formaterar PowerPoint‑former i PHP med Aspose.Slides—ange fyllnings‑, linje‑ och effektstilar för PPT, PPTX och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller applicera effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras inre fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för PHP via Java tillhandahåller klasser och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ange [line style](https://reference.aspose.com/slides/sv/php-java/aspose.slides/linestyle/) för formen.
1. Ange linjebredden.
1. Ange [dash style](https://reference.aspose.com/slides/sv/php-java/aspose.slides/linedashstyle/) för linjen.
1. Ange linjens färg för formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

Följande PHP‑kod demonstrerar hur man formaterar en rektangel `AutoShape`:

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Formatera fogstilar**

Här är de tre alternativ för fogtyp:

* Rund
* Snedkant
* Avfasning

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formens hörn), använder den inställningen **Rund**. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Snedkant**.

![The join style in the presentation](join-style-powerpoint.png)

Följande PHP‑kod demonstrerar hur tre rektanglar (som visas i bilden ovan) skapades med fogtypinställningarna Snedkant, Avfasning och Rund:

```php
// Skapa en instans av Presentation‑klassen som representerar en presentationsfil.
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

    // Ställ in fogstilen.
    $shape1->getLineFormat()->setJoinStyle(LineJoinStyle::Miter);
    $shape2->getLineFormat()->setJoinStyle(LineJoinStyle::Bevel);
    $shape3->getLineFormat()->setJoinStyle(LineJoinStyle::Round);

    // Lägg till text i varje rektangel.
    $shape1->getTextFrame()->setText("Miter Join Style");
    $shape2->getTextFrame()->setText("Bevel Join Style");
    $shape3->getTextFrame()->setText("Round Join Style");

    // Spara PPTX‑filen till disk.
    $presentation->save("join_styles.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig blandning av färger på en form. Till exempel kan du använda två eller fler färger så att den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/gradientformat/).
1. Spara den modifierade presentationen som en PPTX‑fil.

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

Resultatet:

![The ellipse with gradient fill](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign — såsom prickar, ränder, korshatch eller rutmönster — på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides tillhandahåller över 45 fördefinierade mönsterstilar som du kan applicera på former för att förbättra den visuella attraktionskraften i dina presentationer. Även efter att du har valt ett fördefinierat mönster kan du fortfarande ange exakt vilka färger det ska använda.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/php-java/aspose.slides/patternformat/#getBackColor) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/php-java/aspose.slides/patternformat/#getForeColor) för mönstret.
1. Spara den modifierade presentationen som en PPTX‑fil.

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

Resultatet:

![The rectangle with pattern fill](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form — på så sätt använder du bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [PPImage](https://reference.aspose.com/slides/sv/php-java/aspose.slides/ppimage/)‑objekt från bilden du vill använda.
1. Skicka bilden till metoden `SlidesPicture.setImage`.
1. Spara den modifierade presentationen som en PPTX‑fil.

Låt oss säga att vi har en fil ”lotus.png” med följande bild:

![The lotus picture](lotus.png)

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

Resultatet:

![The shape with picture fill](picture-fill.png)

### **Tila bild som textur**

Om du vill ange en tilad bild som textur och anpassa tilningsbeteendet kan du använda följande metoder i klassen [PictureFillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/):

- [setPictureFillMode](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setPictureFillMode): Anger bildfyllningsläget — antingen `Tile` eller `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setTileAlignment): Specificerar justeringen av plattorna inom formen.
- [setTileFlip](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setTileFlip): Kontrollerar om plattan flippar horisontellt, vertikalt eller båda.
- [setTileOffsetX](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setTileOffsetX): Anger den horisontella offseten för plattan (i punkter) från formens ursprung.
- [setTileOffsetY](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setTileOffsetY): Anger den vertikala offseten för plattan (i punkter) från formens ursprung.
- [setTileScaleX](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setTileScaleX): Definierar den horisontella skalan för plattan som en procentandel.
- [setTileScaleY](https://reference.aspose.com/slides/sv/php-java/aspose.slides/picturefillformat/#setTileScaleY): Definierar den vertikala skalan för plattan som en procentandel.

Följande kodexempel visar hur du lägger till en rektangelform med tilad bildfyllning och konfigurerar til‑alternativen:

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $firstSlide = $presentation->getSlides()->get_Item(0);

    // Lägg till en rektangulär autoform.
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

    // Konfigurera bildfyllningsläget och tilningsegenskaperna.
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

Resultatet:

![The tile options](tile-options.png)

## **Enfärgsfyllning**

I PowerPoint är Enfärgsfyllning ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en enfärgsfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Solid`.
1. Tilldela din föredragna fyllningsfärg till formen.
1. Spara den modifierade presentationen som en PPTX‑fil.

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

Resultatet:

![The shape with solid color fill](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en enfärgs-, gradient‑, bild‑ eller texturfyllning på former kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt delvis syns.

Aspose.Slides låter dig ange transparensnivån genom att justera alfa‑värdet i den färg som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ställ in [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (alfa‑komponenten styr transparensen).
1. Spara presentationen.

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
$presentation = new Presentation();
try {
    // Hämta den första bilden.
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en solid rektangulär autoform.
    $solidShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangulär autoform över den solida formen.
    $transparentShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 80, 80, 150, 75);
    $transparentShape->getFillFormat()->setFillType(FillType::Solid);
    $transparentShape->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", 255, 255, 0, 204));

    // Spara PPTX-filen till disk.
    $presentation->save("shape_transparency.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![The transparent shape](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifik justering eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens rotations‑egenskap till önskad vinkel.
1. Spara presentationen.

```php
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
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

Resultatet:

![The shape rotation](shape-rotation.png)

## **Lägg till 3D‑kantningseffekter**

Aspose.Slides gör det möjligt att applicera 3D‑kantningseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/)-egenskaper.

För att lägga till 3D‑kantningseffekter på en form, följ dessa steg:

1. Instansiera klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/) för att definiera kantningsinställningarna.
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

Resultatet:

![The 3D bevel effect](3D-bevel-effect.png)

## **Lägg till 3D‑rotationsseffekter**

Aspose.Slides gör det möjligt att applicera 3D‑rotationsseffekter på former genom att konfigurera deras [ThreeDFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/threedformat/)-egenskaper.

För att applicera 3D‑rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/).
1. Hämta en referens till en bild genom dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/php-java/aspose.slides/autoshape/) på bilden.
1. Använd [setCameraType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/camera/#setCameraType) och [setLightType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/lightrig/#setLightType) för att definiera 3D‑rotationen.
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

Resultatet:

![The 3D rotation effect](3D-rotation-effect.png)

## **Återställ formatering**

Följande Java‑kod visar hur du återställer formateringen av en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide](https://reference.aspose.com/slides/sv/php-java/aspose.slides/layoutslide/) till deras standardinställningar:

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

## **FAQ**

**Påverkar formatering av former den slutgiltiga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media tar största delen av filstorleken, medan formparametrar som färger, effekter och gradienter lagras som metadata och tillför i princip ingen extra storlek.

**Hur kan jag upptäcka former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varje forms viktigaste formaterings‑egenskaper — fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑bildserie eller en .POTX‑mallfil. När du skapar en ny presentation öppnar du mallen, klonar de stylade former du behöver och återapplicerar deras formatering där det krävs.