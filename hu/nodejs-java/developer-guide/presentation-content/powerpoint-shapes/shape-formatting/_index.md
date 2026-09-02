---
title: PowerPoint alakzatok formázása JavaScript-ben
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/nodejs-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- alakzatvonal vázlat
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyetlen színű kitöltés
- alakzat átlátszósága
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D lekerekítési hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "PowerPoint alakzatok formázása JavaScript-ben az Aspose.Slides segítségével—precíz és teljes irányítással állítson be kitöltési, vonal- és hatásstílusokat PPT, PPTX és ODP fájlokhoz."
---
## **Bevezetés**

A PowerPointban alakzatokat adhatsz a diákhoz. Mivel az alakzatok vonalakból állnak, a körvonalukat formázhatod a vonalak módosításával vagy hatások alkalmazásával. Továbbá alakzatok formázhatók olyan beállítások megadásával, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Node.js via Java osztályokat és metódusokat biztosít, amelyek lehetővé teszik, hogy az alakzatokat a PowerPointban elérhető ugyanazokkal az opciókkal formázd.

## **Vonalak formázása**

Az Aspose.Slides használatával egyedi vonalstílust adhatunk meg egy alakzathoz. Az alábbi lépések vázolják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal szélességét.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linedashstyle/) értékét.
1. Állítsa be az alakzat vonalszínét.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázható egy téglalap `AutoShape`:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Téglalap típusban.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Eltávolítja a kitöltést a téglalap alakzatról.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Formázást alkalmaz a téglalap vonalaira.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Beállítja a téglalap vonalának színét.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlat-hatások alkalmazása az alakzat vonalaira**

A vázlat hatás úgy teszi, hogy az alakzat vonala kézzel rajzoltnek tűnik. Használja a [Shape.getLineFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) metódust a vonal beállítások eléréséhez, a [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lineformat/) metódust a vázlat beállításokhoz, és a [SketchFormat.setSketchType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linesketchtype/) felsorolásból egy érték kiválasztásához.

Az alábbi JavaScript kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linesketchtype/) használatával:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // A forma vonalformátumához és vázlatformátumához fér hozzá.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Vázlat hatást alkalmaz.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // A forma közvetlenül hozzárendelt vázlat hatását olvassa.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Eltávolítja a vázlat hatást.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

A [SketchFormat.getSketchType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sketchformat/) által visszaadott érték a közvetlenül az alakzatra beállított konfigurációt képviseli. Ha a vonal formázása örökölhető egy témából, mester- vagy elrendezési diáról, használja a [LineFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lineformat/) metódust, hívja meg a visszakapott objektumon a `getSketchFormat` metódust, majd a `getSketchType` metódust. A hatékony érték a ténylegesen alkalmazott formázást tükrözi az öröklődés feloldása után:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

## **Csatlakozási stílusok formázása**

A három csatlakozási típus opció:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat szögnél (például egy alakzat sarkán) összekapcsol, a **Round** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Miter** opciót.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi JavaScript kód megmutatja, hogyan lett három téglalap (az előző képen látható) létrehozva a Miter, Bevel és Round csatlakozási típus beállításokkal:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad három automatikus alakzatot Téglalap típusban.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Beállítja a kitöltőszínt minden téglalap alakzathoz.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Beállítja a vonalvastagságot.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Beállítja a vonal színét minden téglalaphoz.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Beállítja a csatlakozási stílust.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Szöveget ad minden téglalaphoz.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazz egy alakzatra. Például két vagy több színt használhatsz úgy, hogy az egyik fokozatosan elhalványul a másikba.

Így alkalmazhatod a színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Gradient`-re.
1. Adja meg a két kívánt színt a meghatározott pozíciókkal a [GradientFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/gradientformat/) által biztosított gradient stop gyűjtemény `add` metódusainak segítségével.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazz színátmenetes kitöltést egy ellipszisre:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Ellipszis típusban.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmaz színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Beállítja a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Hozzáad két színátmeneti állomást.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy két színű mintát – például pontokat, csíkokat, keresztmintát vagy négyzetrácsot – alkalmazz egy alakzatra. A minta előtér- és háttérszínét testre szabhatod.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhatsz a prezentációk vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatod a pontos színeket, amelyeket használni kell.

Így alkalmazhatod a minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazz minta kitöltést egy téglalapra:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Téglalap típusban.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Mintára.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Beállítja a mintastílust.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Beállítja a minta háttér- és előtérszíneit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Képpel kitöltés**

A PowerPointban a Képpel kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezz el egy alakzaton belül – gyakorlatilag a képet az alakzat háttérként használva.

Így használhatod az Aspose.Slides-t a képpel kitöltéshez egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Picture`-ra.
1. Állítsa be a kép kitöltési módját `Tile`-ra (vagy egy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse el a módosított prezentációt PPTX fájlként.

![A lótusz kép](lotus.png)

Az alábbi JavaScript kód bemutatja, hogyan töltsd ki egy alakzatot a képpel:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Téglalap típusban.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Beállítja a kitöltés típusát Képre.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Beállítja a kép kitöltési módot.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Beállítja a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat képpel kitöltve](picture-fill.png)

### **Kép csempézése textúraként**

Ha egy csempézett képet szeretnél textúraként beállítani, és testre szabni a csempézés viselkedését, a [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) osztály következő metódusait használhatod:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a kép kitöltési módját—`Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettő szerint legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontokban) az alakzat eredetétől.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontokban) az alakzat eredetétől.
- [setTileScaleX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Megadja a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Megadja a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet megmutatja, hogyan adj hozzá egy téglalap alakzatot csempézett képkitöltéssel és konfiguráld a csempe beállításait:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Hozzáad egy téglalap automatikus alakzatot.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltés típusát Képre.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Hozzáadja a képet az alakzathoz.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Konfigurálja a kép kitöltési módot és a csempézési tulajdonságokat.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A csempe beállításai](tile-options.png)

## **Egyetlen színű kitöltés**

A PowerPointban az Egyetlen színű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín gradiensek, textúrák vagy minták nélkül kerül alkalmazásra.

Az egyetlen színű kitöltés alkalmazásához az Aspose.Slides segítségével kövesd az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Solid`-ra.
1. Adja meg a kívánt kitöltőszínt az alakzatnak.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazz egyetlen színű kitöltést egy téglalapra egy PowerPoint dián:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Téglalap típusban.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Egyszínűre.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Beállítja a kitöltőszínt.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat egyetlen színű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egy alakzatra egyetlen színt, színátmenetet, képet vagy textúrát alkalmazunk, a kitöltés átlátszósági szintjét is beállíthatjuk, ezáltal szabályozva a kitöltés átlátszóságát. Magasabb átlátszósági érték esetén az alakzat áttetszőbb lesz, és a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszóság szintjének beállítását a kitöltéshez használt szín alfa komponensének módosításával. Így teheted:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` objektumot egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse el a prezentációt.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazz átlátszó kitöltőszínt egy téglalapra:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy szilárd téglalap automatikus alakzatot.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet, ha vizuális elemeket speciális elrendezéssel vagy dizájn követelményekkel kell elhelyezni.

Alakzat forgatásához egy dián kövesd az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse el a prezentációt.

Az alábbi JavaScript kód bemutatja, hogyan forgassunk egy alakzatot 5 fokkal:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Létrehozza a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Lekéri az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Téglalap típusban.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgatja az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D lekerekítési hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D lekerekítési hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D lekerekítési hatások hozzáadásához egy alakzathoz kövesd az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) beállításait a lekerekítési paraméterek meghatározásához.
1. Mentse el a prezentációt.

Az alábbi JavaScript kód megmutatja, hogyan alkalmazz 3D lekerekítési hatásokat egy alakzatra:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation osztály egy példányát.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy alakzatot a diára.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Beállítja az alakzat ThreeDFormat tulajdonságait.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(aspose.slides.BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(aspose.slides.LightingDirection.Top);

    // Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D lekerekítési hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás definiálásához.
1. Mentse el a prezentációt.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazz 3D forgatási hatásokat egy alakzatra:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Létrehozza a Presentation osztály egy példányát.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(aspose.slides.CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(aspose.slides.LightRigPresetType.Balanced);

    // Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_rotation_effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés szabályozása alakzatoknál**

A [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/#setBlackWhiteMode) metódus megadja, hogyan jelenik meg egy egyedi alakzat, amikor a prezentációt fekete-fehér módban tekintik vagy dolgozzák fel. Nem engedélyezi magát a fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál szín módban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/blackwhitemode/) felsorolásból a kívánt viselkedés kiválasztásához. Például az `Automatic` hagyja, hogy a renderelő alkalmazás válasszon konverziót, a `Gray` és `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehér színeket használ, a `Black` és `White` egyetlen színt kényszerítenek, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete‑fehér módban, a `NotDefined` pedig azt jelenti, hogy nincs alakzatszintű mód beállítva.

Az alábbi JavaScript kód egy színes alakzatot hoz létre, és fekete‑fehér megjelenítési módban szürkének jeleníti meg:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));

    // A narancssárga kitöltést szín módban tartja, de a alakzatot szürke színnel jeleníti meg fekete-fehér módban.
    shape.setBlackWhiteMode(java.newByte(aspose.slides.BlackWhiteMode.Gray));

    presentation.save("shape_black_white_mode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normál szín módban a téglalap megtartja narancssárga kitöltését. Fekete‑fehér megjelenítési munkafolyamat során szürke színezést használ, mert a mód `Gray`‑ra van állítva. Ez lehetővé teszi, hogy egy teljes színes diát őrizz, miközben egyedi megjelenést definiálsz nyomtatáshoz, előnézethez vagy egyéb munkafolyamatokhoz, amelyek figyelembe veszik a prezentáció fekete‑fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Az alábbi JavaScript kód megmutatja, hogyan állítsd vissza egy dia formázását, és hogyan állítsd vissza az összes alakzat, valamint a helyőrzőkkel rendelkező alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) alapértelmezett beállításaira:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Állítsa vissza a dián minden olyan alakzatot, amelynek helyőrzője van az elrendezésben.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A alakzat formázása befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legnagyobb részét, míg az alakzatok paraméterei (színek, hatások, színátmenetek) metaadatként vannak tárolva, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni a dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállításait. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami egyszerűsíti a későbbi stíluskezelést.

**Menthetek-e egyedi alakzatstílusok készletét egy külön fájlba, hogy más prezentációkban is felhasználjam?**

Igen. Tároljon minta alakzatokat a kívánt stílusokkal egy sablon diakészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat a kívánt helyeken.