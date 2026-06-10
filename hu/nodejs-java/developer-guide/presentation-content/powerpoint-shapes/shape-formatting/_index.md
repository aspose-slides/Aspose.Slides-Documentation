---
title: PowerPoint alakzatok formázása JavaScriptben
linktitle: Alakzatformázás
type: docs
weight: 20
url: /hu/nodejs-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- szilárd szín kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3D szegély hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Formázza a PowerPoint alakzatokat JavaScriptben az Aspose.Slides használatával – állítsa be a kitöltés, vonal és effektus stílusokat PPT, PPTX és ODP fájlokhoz pontosan és teljes ellenőrzéssel."
---
## **Bevezetés**

A PowerPoint‑ban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Továbbá beállíthatja az alakzatok kitöltését szabályozó beállításokkal, amelyek meghatározzák, hogyan töltődik ki a belsejük.

![alakzat formázása PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for Node.js via Java osztályokat és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a lehetőségekkel formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides használatával egyedi vonalstílust adhat egy alakzathoz. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal szélességét.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linedashstyle/) értékét.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő kód bemutatja, hogyan formázhatja a `AutoShape` téglalapot:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusú.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Beállítja a téglalap alakzat kitöltőszínét.
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

## **Csatlakozási stílusok formázása**

Az alábbiak a három csatlakozási típus lehetősége:

* Kerek
* Miter
* Ferde

Alapértelmezés szerint, amikor a PowerPoint két vonalat szögnél (például egy alakzat sarkán) összekapcsol, a **Round** beállítást használja. Ha azonban éles szögekkel rajzol alakzatot, a **Miter** opciót részesítheti előnyben.

![Az összekapcsolási stílus a prezentációban](join-style-powerpoint.png)

A következő JavaScript‑kód bemutatja, hogyan hozták létre a fenti képen látható három téglalapot a Miter, Bevel és Round csatlakozási beállításokkal:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad három automatikus alakzatot Rectangle típusú.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Beállítja az egyes téglalap alakzatok kitöltőszínét.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Beállítja a vonal vastagságát.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Beállítja az egyes téglalapok vonalának színét.
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

    // Szöveget ad az egyes téglalapokhoz.
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

A PowerPoint‑ban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi színek folyamatos keverésének alkalmazását egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan átmenjen a másikba.

A színátmenetes kitöltés alkalmazásához egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Gradient`‑ra.
1. A [GradientFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/gradientformat/) osztály által kiírt gradient‑stop gyűjtemény `add` metódusaival adja hozzá a két kívánt színt a meghatározott pozíciókkal.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő JavaScript‑kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Ellipse típusú.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazza a színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Beállítja a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Két színátmenet‑állomást ad hozzá.
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

A PowerPoint‑ban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi két színnel készült mintázat – például pontok, csíkok, keresztminták vagy négyzethálók – alkalmazását egy alakzatra. A minta előtér‑ és háttérszíneit egyénileg is beállíthatja.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelése érdekében. Még egy előre definiált minta kiválasztása után is megadhatja a pontos színeket.

A minta kitöltés alkalmazásához egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Pattern`‑re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő JavaScript‑kód bemutatja, hogyan alkalmazzon mintás kitöltést egy téglalapra:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusú.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // A kitöltés típusát Pattern-re állítja.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Beállítja a mintastílust.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Beállítja a minta háttér- és előtérszínét.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A téglalap mintás kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPoint‑ban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi egy kép beillesztését egy alakzatba – lényegében a képet a forma háttérként használva.

A kép kitöltés alkalmazása egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Picture`‑ra.
1. Állítsa be a kép kitöltés módját `Tile`‑re (vagy egy másik kívánt módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájl a következő képpel:

![A lótusz kép](lotus.png)

A következő JavaScript‑kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusú.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // A kitöltés típusát Picture-re állítja.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Beállítja a kép kitöltés módját.
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

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempével textúraként**

Ha egy csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, használja a [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a kép kitöltés módját — `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Meghatározza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőben legyen-e tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): Beállítja a csempe vízszintes eltolását (pontokban) az alakzat eredetétől.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): Beállítja a csempe függőleges eltolását (pontokban) az alakzat eredetétől.
- [setTileScaleX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): Meghatározza a csempe függőleges méretezését százalékban.

A következő kódrészlet megmutatja, hogyan adjon egy téglalap alakzatot csempézett képkitöltéssel, és hogyan konfigurálja a csempe‑opciókat:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Az első diát kapja meg.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Hozzáad egy téglalap automatikus alakzatot.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltésének típusát Picture-re.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Hozzáadja a képet az alakzathoz.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Beállítja a kép kitöltés módját és a csempézés tulajdonságait.
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

![A csempe beállítások](tile-options.png)

## **Szilárd szín kitöltés**

A PowerPoint‑ban a Szilárd szín kitöltés egy formázási lehetőség, amely egyetlen, egyenletes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín gradiensek, textúrák vagy minták nélkül kerül alkalmazásra.

Szilárd színű kitöltés alkalmazásához egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. Adja meg a kívánt kitöltőszínt az alakzatnak.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő JavaScript‑kód bemutatja, hogyan alkalmazzon szilárd színű kitöltést egy téglalapra egy PowerPoint‑dián:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusú.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // A kitöltés típusát Solid-ra állítja.
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

![Az alakzat szilárd színű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

PowerPoint‑ban, ha szilárd színt, színátmenetet, képet vagy textúra‑kitöltést alkalmaz alakzatokra, beállíthat átlátszósági szintet is a kitöltés átlátszatlanságának szabályozásához. Magasabb átlátszóság esetén az alakzat átlátszóbb lesz, így a háttér vagy a mögöttes objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszóság szintjének beállítását a kitöltéshez használt szín alfa‑értékének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) értékét `Solid`‑ra.
1. A `Color` segítségével definiáljon egy átlátszó színt (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

A következő JavaScript‑kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
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

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint‑prezentációkban. Ez hasznos lehet vizuális elemek elhelyezésekor, ha speciális igazításra vagy tervezési igényekre van szükség.

Alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

A következő JavaScript‑kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```js
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // A legelső diát kapja meg.
    let slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusú.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Elforgatja az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Elmenti a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D szegélyeffektek hozzáadása**

Az Aspose.Slides lehetővé teszi 3D szegélyeffektek alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D szegélyeffektek hozzáadásához egy alakzatra kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) beállításait a szegélyparaméterek meghatározásához.
1. Mentse a prezentációt.

A következő JavaScript‑kód szemlélteti, hogyan alkalmazzon 3D szegélyeffekteket egy alakzatra:

```js
// Példányosítja a Presentation osztályt.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Alakzatot ad a diára.
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

![A 3D szegély effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) objektumot adjon a diára.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás definiálásához.
1. Mentse a prezentációt.

A következő JavaScript‑kód bemutatja, hogyan alkalmazzon 3D forgatási effektusokat egy alakzatra:

```js
// Példányosítja a Presentation osztályt.
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

![A 3D forgatási effektus](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi Java‑kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa alaphelyzetbe a [LayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) helyőrzőkkel rendelkező összes alakzat pozícióját, méretét és formázását:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Állítsa vissza az egyes alakzatokat a dián, amelyeknek helyőrzője van az elrendezésben.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Befolyásolja az alakzat formázása a végső prezentáció fájlméretét?**

Csak nagyon kevés mértékben. A beágyazott képek és médiafájlok foglalják a fájl legnagyobb részét, míg az alakzatparaméterek (színek, hatások, színátmenetek) metaadatként tárolódnak, és gyakorlatilag nem növelik jelentősen a fájlméretet.

**Hogyan tudom felismerni egy dián az azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effekt beállítások. Ha minden megfelelő érték egyezik, tekintse a stílusukat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzatstílus‑készletet egy külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon‑diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció készítésekor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a kívánt helyeken.