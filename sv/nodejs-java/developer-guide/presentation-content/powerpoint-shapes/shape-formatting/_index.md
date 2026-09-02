---
title: Formatera PowerPoint-former i JavaScript
linktitle: Formatering av former
type: docs
weight: 20
url: /sv/nodejs-java/shape-formatting/
keywords:
- formatera form
- formatera linje
- skisseffekt
- skisslinje för form
- formatera anslutningsstil
- gradientfyllning
- mönsterfyllning
- bildfyllning
- texturfyllning
- enfärgsfyllning
- formtransparens
- rotera form
- 3D-fasthöjningseffekt
- 3D-rotationseffekt
- återställ formatering
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatera PowerPoint‑former i JavaScript med Aspose.Slides—ange fyllnings‑, linje‑ och effektstilar för PPT-, PPTX‑ och ODP‑filer med precision och full kontroll."
---
## **Introduktion**

I PowerPoint kan du lägga till former på bilder. Eftersom former består av linjer kan du formatera dem genom att ändra eller tillämpa effekter på deras konturer. Dessutom kan du formatera former genom att ange inställningar som styr hur deras innandömen fylls.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides för Node.js via Java tillhandahåller klasser och metoder som låter dig formatera former med samma alternativ som finns i PowerPoint.

## **Formatera linjer**

Med Aspose.Slides kan du ange en anpassad linjestil för en form. Följande steg beskriver proceduren:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in [linjestil](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/linestyle/) för formen.
1. Ställ in linjebredden.
1. Ställ in [dash style](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/linedashstyle/) för linjen.
1. Ställ in linjens färg för formen.
1. Spara den modifierade presentationen som en PPTX-fil.

Följande kod visar hur du formaterar en rektangel `AutoShape`:

```js
// Skapa en instans av Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoform av typen Rektangel.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Ange fyllningsfärgen för rektangelformen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Tillämpa formatering på rektangelns linjer.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Ange färgen för rektangelns linje.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Spara PPTX-filen till disk.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De formaterade linjerna i presentationen](formatted-lines.png)

## **Applicera skiss‑effekter på formlinjer**

En skisseffekt får en formlinje att se handritad ut. Använd [Shape.getLineFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/shape/) för att komma åt linjeinställningarna, [LineFormat.getSketchFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/lineformat/) för att komma åt skissinställningarna och [SketchFormat.setSketchType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sketchformat/) för att välja ett värde från uppräkningen [LineSketchType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/linesketchtype/).

Följande JavaScript‑kod visar hur du applicerar en [LineSketchType.Curved](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/linesketchtype/) effekt, läser det uttryckligen tilldelade värdet och tar bort effekten med [LineSketchType.None](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/linesketchtype/):

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // Åtkomst till formens linjeformat och dess skissformat.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Tillämpa en skiss-effekt.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Läs av skiss-effekten som tilldelats formen direkt.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Ta bort skiss-effekten.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Värdet som returneras av [SketchFormat.getSketchType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/sketchformat/) representerar den inställning som tilldelats formen direkt. Om linjeformateringen kan ärvas från ett tema, en master‑bild eller en layout‑bild, använd [LineFormat.getEffective](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/lineformat/), anropa `getSketchFormat` på det returnerade objektet och sedan anropa dess `getSketchType`‑metod. Det effektiva värdet visar den formatering som faktiskt tillämpas efter att arv har lösts:

```js
let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    let lineFormat = shape.getLineFormat();

    let explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    let effectiveLineFormat = lineFormat.getEffective();
    let effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    console.log("Explicit sketch type: " + explicitSketchType);
    console.log("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Formatera anslutningsstilar**

Här är de tre alternativen för anslutningstyp:

* Round
* Miter
* Bevel

Som standard, när PowerPoint förenar två linjer i en vinkel (t.ex. vid en formes hörn), använder den inställningen **Round**. Om du däremot ritar en form med skarpa vinklar kan du föredra alternativet **Miter**.

![Anslutningsstilen i presentationen](join-style-powerpoint.png)

Följande JavaScript‑kod visar hur tre rektanglar (som visas i bilden ovan) skapades med Miter‑, Bevel‑ och Round‑inställningarna för anslutningstyp:

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till tre autoformer av typen Rektangel.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Ange fyllningsfärgen för varje rektangelform.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Ange linjebredden.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Ange färgen för varje rektangels linje.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Ange anslutningsstilen.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Lägg till text i varje rektangel.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Spara PPTX-filen till disk.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradientfyllning**

I PowerPoint är Gradientfyllning ett formateringsalternativ som låter dig applicera en kontinuerlig färgblandning på en form. Till exempel kan du använda två eller fler färger så att den ena gradvis tonas in i den andra.

Så här applicerar du en gradientfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Gradient`.
1. Lägg till dina två önskade färger med definierade positioner med hjälp av `add`‑metoderna i gradientstopp‑samlingen som exponeras av klassen [GradientFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/gradientformat/).
1. Spara den modifierade presentationen som en PPTX-fil.

Följande JavaScript‑kod visar hur du applicerar en gradientfyllningseffekt på en ellips:

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoform av typen Ellipse.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Tillämpa gradientformatering på ellipsen.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Ställ in gradientens riktning.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Lägg till två gradientstopp.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Spara PPTX-filen till disk.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Ellipsen med gradientfyllning](gradient-fill.png)

## **Mönsterfyllning**

I PowerPoint är Mönsterfyllning ett formateringsalternativ som låter dig applicera en tvåfärgsdesign – såsom prickar, ränder, korshatch eller schackrutor – på en form. Du kan välja egna färger för mönstrets förgrund och bakgrund.

Aspose.Slides erbjuder mer än 45 fördefinierade mönsterstilar som du kan använda på former för att förbättra dina presentationers visuella intryck. Även efter att ha valt ett fördefinierat mönster kan du specificera exakt vilka färger som ska användas.

Så här applicerar du en mönsterfyllning på en form med Aspose.Slides:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Pattern`.
1. Välj en mönsterstil från de fördefinierade alternativen.
1. Ställ in [Background Color](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/patternformat/#getBackColor--) för mönstret.
1. Ställ in [Foreground Color](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/patternformat/#getForeColor--) för mönstret.
1. Spara den modifierade presentationen som en PPTX-fil.

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoform av typen Rektangel.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstyp till Mönster.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Ställ in mönsterstil.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Ställ in mönstrets bakgrunds- och förgrundsfärger.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Spara PPTX-filen till disk.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Rektangeln med mönsterfyllning](pattern-fill.png)

## **Bildfyllning**

I PowerPoint är Bildfyllning ett formateringsalternativ som låter dig infoga en bild i en form – vilket effektivt använder bilden som formens bakgrund.

Så här använder du Aspose.Slides för att applicera en bildfyllning på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Picture`.
1. Ställ in bildfyllningsläget till `Tile` (eller ett annat föredraget läge).
1. Skapa ett [PPImage]-objekt från den bild du vill använda.
1. Skicka bilden till metoden `ISlidesPicture.setImage`.
1. Spara den modifierade presentationen som en PPTX-fil.

Anta att vi har en fil "lotus.png" med följande bild:

![Lotus‑bilden](lotus.png)

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoform av typen Rektangel.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Ställ in fyllningstyp till Bild.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Ställ in bildfyllningsläget.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Läs in en bild och lägg till den i presentationens resurser.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Ställ in bilden.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Spara PPTX-filen till disk.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formen med bildfyllning](picture-fill.png)

### **Använd tile-bild som textur**

Om du vill ställa in en tile‑bild som textur och anpassa tile‑beteendet kan du använda följande metoder i klassen [PictureFillFormat]:

- [setPictureFillMode]: Ställer in bildfyllningsläget – antingen `Tile` eller `Stretch`.
- [setTileAlignment]: Anger justeringen av tile‑arna inom formen.
- [setTileFlip]: Styr om tile‑en vänds horisontellt, vertikalt eller båda.
- [setTileOffsetX]: Ställer in den horisontella offseten för tile (i punkter) från formens ursprung.
- [setTileOffsetY]: Ställer in den vertikala offseten för tile (i punkter) från formens ursprung.
- [setTileScaleX]: Definierar den horisontella skalan för tile som en procentsats.
- [setTileScaleY]: Definierar den vertikala skalan för tile som en procentsats.

Följande kodexempel visar hur du lägger till en rektangelform med en tile‑bildfyllning och konfigurerar tile‑alternativen:

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Lägg till en rektangel autoform.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Ställ in fyllningstypen för formen till Bild.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Läs in bilden och lägg till den i presentationens resurser.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Tilldela bilden till formen.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurera bildfyllningsläget och tile-egenskaperna.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Spara PPTX-filen till disk.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Tile‑alternativen](tile-options.png)

## **Enfärgsfyllning**

I PowerPoint är Enfärgsfyllning ett formateringsalternativ som fyller en form med en enda, enhetlig färg. Denna enkla bakgrundsfärg appliceras utan några gradienter, texturer eller mönster.

För att applicera en enfärgsfyllning på en form med Aspose.Slides, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Solid`.
1. Tilldela din önskade fyllnadsfärg till formen.
1. Spara den modifierade presentationen som en PPTX-fil.

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoform av typen Rektangel.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Ställ in fyllningstypen till Solid.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Ställ in fyllningsfärgen.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Spara PPTX-filen till disk.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formen med enfärgsfyllning](solid-color-fill.png)

## **Ställ in transparens**

I PowerPoint, när du applicerar en enfärgs-, gradient-, bild‑ eller texturfyllning på former kan du också ange en transparensnivå för att kontrollera fyllningens opacitet. Ett högre transparensvärde gör formen mer genomskinlig, så att bakgrunden eller underliggande objekt blir delvis synliga.

Aspose.Slides låter dig ange transparensnivån genom att justera alfa‑värdet i färgen som används för fyllningen. Så här gör du:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens [FillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) till `Solid`.
1. Använd `Color` för att definiera en färg med transparens (komponenten `alpha` styr transparensen).
1. Spara presentationen.

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en solid rektangel autoform.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Lägg till en transparent rektangel autoform ovanpå den solida formen.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Spara PPTX-filen till disk.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den genomskinliga formen](shape-transparency.png)

## **Rotera former**

Aspose.Slides låter dig rotera former i PowerPoint‑presentationer. Detta kan vara användbart när du placerar visuella element med specifika justerings‑ eller designbehov.

För att rotera en form på en bild, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Ställ in formens rotations­egenskap till önskad vinkel.
1. Spara presentationen.

```js
// Instansiera Presentation-klassen som representerar en presentationsfil.
let presentation = new aspose.slides.Presentation();
try {
    // Hämta den första bilden.
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en autoform av typen Rektangel.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Rotera formen med 5 grader.
    shape.setRotation(5);

    // Spara PPTX-filen till disk.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Formens rotation](shape-rotation.png)

## **Lägg till 3D-fasthöjningseffekter**

Aspose.Slides låter dig applicera 3D-fasthöjningseffekter på former genom att konfigurera deras [ThreeDFormat]-egenskaper.

För att lägga till 3D-fasthöjningseffekter på en form, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Konfigurera formens [ThreeDFormat] för att definiera fasthöjningsinställningarna.
1. Spara presentationen.

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Lägg till en form på bilden.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Ställ in formens ThreeDFormat-egenskaper.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Spara presentationen som en PPTX-fil.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![3D-fasthöjningseffekten](3D-bevel-effect.png)

## **Lägg till 3D-rotations‑effekter**

Aspose.Slides låter dig applicera 3D-rotationseffekter på former genom att konfigurera deras [ThreeDFormat]-egenskaper.

För att applicera 3D-rotation på en form:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/).
1. Hämta en referens till en bild baserat på dess index.
1. Lägg till en [AutoShape](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/autoshape/) på bilden.
1. Använd [setCameraType] och [setLightType] för att definiera 3D-rotationen.
1. Spara presentationen.

```js
// Skapa en instans av Presentation-klassen.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Spara presentationen som en PPTX-fil.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![3D-rotationseffekten](3D-rotation-effect.png)

## **Återställ formatering**

Följande Java‑kod visar hur du återställer formateringen på en bild och återställer position, storlek och formatering för alla former med platshållare på [LayoutSlide] till deras standardinställningar:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Återställ varje form på bilden som har en platshållare på layouten.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Påverkar formatering av former den slutliga presentationsfilens storlek?**

Endast marginellt. Inbäddade bilder och media tar upp största delen av filutrymmet, medan formparametrar som färger, effekter och gradienter lagras som metadata och nästan inte ökar filstorleken.

**Hur kan jag upptäcka former på en bild som har identisk formatering så att jag kan gruppera dem?**

Jämför varjeformes nyckelformaterings‑egenskaper – fyllning, linje och effektinställningar. Om alla motsvarande värden matchar, behandla deras stilar som identiska och gruppera logiskt dessa former, vilket förenklar senare stilhantering.

**Kan jag spara en uppsättning anpassade formstilar i en separat fil för återanvändning i andra presentationer?**

Ja. Spara exempelformer med önskade stilar i en mall‑slide‑uppsättning eller en .POTX‑mallfil. När du skapar en ny presentation, öppna mallen, klona de former du behöver och återapplicera deras formatering där det behövs.