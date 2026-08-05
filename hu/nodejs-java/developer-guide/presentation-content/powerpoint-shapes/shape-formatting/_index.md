---
title: PowerPoint alakzatok formázása JavaScriptben
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/nodejs-java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat alakzatvonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- képes kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: Formázza a PowerPoint alakzatokat JavaScriptben az Aspose.Slides segítségével—állítsa be a kitöltés, vonal és effektus stílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes kontrollal.
---
## **Bevezetés**

A PowerPointban alakzatokat adhatunk a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatjuk őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett megadhatjuk a kitöltés beállításait is, amelyek szabályozzák, hogyan töltődik ki a belsejük.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Node.js via Java osztályokat és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a lehetőségekkel formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzatra egyéni vonalstílust adhat meg. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [vonalstílusát](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linestyle/).
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [szaggatási stílusát](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linedashstyle/).
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-t:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 150, 75);

    // Állítsa be a téglalap alakzat kitöltő színét.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    // Alkalmazzon formázást a téglalap vonalaira.
    shape.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.ThickThin));
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(java.newByte(aspose.slides.LineDashStyle.Dash));

    // Állítsa be a téglalap vonalának színét.
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlatos hatás alkalmazása az alakzat vonalaira**

A vázlatos hatás kézzel rajzolt hatást kölcsönöz a vonalnak. Használja a [Shape.getLineFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/shape/) metódust a vonalbeállítások eléréséhez, a [LineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lineformat/) metódust a vázlat beállításokhoz, és a [SketchFormat.setSketchType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linesketchtype/) felsorolásból egy érték kiválasztásához.

Az alábbi JavaScript kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/linesketchtype/) használatával:

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 100);

    // A forma vonalformátumához és vázlatformátumához fér hozzá.
    let sketchFormat = shape.getLineFormat().getSketchFormat();

    // Alkalmazzon egy vázlat hatást.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.Curved);

    // Olvassa el a forma közvetlenül hozzárendelt vázlat hatását.
    let explicitSketchType = sketchFormat.getSketchType();
    console.log("Explicit sketch type: " + explicitSketchType);

    // Távolítsa el a vázlat hatást.
    sketchFormat.setSketchType(aspose.slides.LineSketchType.None);
} finally {
    presentation.dispose();
}
```

A [SketchFormat.getSketchType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/sketchformat/) által visszaadott érték közvetlenül az alakzatra beállított értéket jelenti. Ha a vonalformázás egy témából, mesterdiából vagy elrendezési diából öröklődik, használja a [LineFormat.getEffective](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lineformat/) metódust, hívja meg a visszakapott objektum `getSketchFormat` metódusát, majd a `getSketchType` metódust. A hatékony érték tükrözi a ténylegesen alkalmazott formázást az öröklődés feloldása után:

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

## **Csatlakozási stílusok formázása**

A három csatlakozási típus lehetősége:

* Kör
* Vég
* Lecsengés

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögnél (például egy alakzat sarkán) kapcsol össze, a **Kör** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyösebb lehet a **Vég** opció.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi JavaScript kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható) a Vég, Lecsengés és Kör csatlakozási beállításokkal:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá három téglalap típusú automatikus alakzatot.
    let shape1 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 75);
    let shape2 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 210, 20, 150, 75);
    let shape3 = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 135, 150, 75);

    // Állítsa be minden téglalap alakzat kitöltő színét.
    shape1.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape2.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    shape3.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

    // Állítsa be a vonalvastagságot.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Állítsa be minden téglalap vonalának színét.
    shape1.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    shape3.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));

    // Állítsa be a csatlakozási stílust.
    shape1.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Miter));
    shape2.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Bevel));
    shape3.getLineFormat().setJoinStyle(java.newByte(aspose.slides.LineJoinStyle.Round));

    // Adjon szöveget minden téglalaphoz.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("join_styles.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradiens kitöltés**

A PowerPointban a Gradiens kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt használhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Így alkalmazhat gradiens kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) tulajdonságát `Gradient` értékre.
1. Adja hozzá a két kívánt színt a meghatározott pozíciókkal a [GradientFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/gradientformat/) osztály által kiadott gradiens‑állomás gyűjtemény `add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazzon gradiens kitöltést egy ellipszisen:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon gradiens formázást az ellipszisre.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Gradient));
    shape.getFillFormat().getGradientFormat().setGradientShape(java.newByte(aspose.slides.GradientShape.Linear));

    // Állítsa be a gradiens irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(aspose.slides.GradientDirection.FromCorner2);

    // Adjon hozzá két gradiens állomást.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(1.0, aspose.slides.PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor(0, aspose.slides.PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az ellipszis gradiens kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés lehetővé teszi, hogy két színű mintát – például pontokat, csíkokat, keresztöltéseket vagy négyzeteket – alkalmazzon egy alakzatra. A minta előtér és háttér színeit egyénileg megadhatja.

Az Aspose.Slides több mint 45 előre definiált minta stílust kínál, amelyeket alakzatokra alkalmazhat a prezentáció vizuális vonzerejének növelésére. Még egy előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket a minta használjon.

Így alkalmazhat minta kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) tulajdonságát `Pattern` értékre.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Háttérszínét](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternformat/#getBackColor--).
1. Állítsa be a minta [Előtérszínét](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/patternformat/#getForeColor--).
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Pattern-re.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Pattern));

    // Állítsa be a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(java.newByte(aspose.slides.PatternStyle.Trellis));

    // Állítsa be a minta háttér- és előtérszíneit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – lényegében a képet az alakzat háttérként használja.

Így használhatja az Aspose.Slides-t kép kitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) tulajdonságát `Picture` értékre.
1. Állítsa be a kép kitöltés módját `Tile`-re (vagy egy másik preferált módra).
1. Hozzon létre egy [PPImage](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ppimage/) objektumot a felhasználandó képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájlunk a következő képpel:

![A lotus kép](lotus.png)

Az alábbi JavaScript kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Állítsa be a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Állítsa be a kép kitöltés módját.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Tile);

    // Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
    let image = aspose.slides.Images.fromFile("lotus.png");
    let picture = presentation.getImages().addImage(image);
    image.dispose();

    // Állítsa be a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Csempeképfeltöltés textúraként**

Ha csempeképet szeretne textúraként beállítani, és testreszabni a csempe viselkedését, a következő [PictureFillFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/) osztálymetódusokat használhatja:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setPictureFillMode): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileAlignment): Meghatározza a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileFlip): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettővel legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetX): A csempe vízszintes eltolását (pontban) az alakzat kiindulópontjától állítja.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileOffsetY): A csempe függőleges eltolását (pontban) az alakzat kiindulópontjától állítja.
- [setTileScaleX](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileScaleX): A csempe vízszintes méretarányát százalékban adja meg.
- [setTileScaleY](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/picturefillformat/#setTileScaleY): A csempe függőleges méretarányát százalékban adja meg.

Az alábbi kódrészlet megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempeképes kitöltéssel, és hogyan konfigurálja a csempe beállításait:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let firstSlide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy téglalap automatikus alakzatot.
    let shape = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 190, 95);

    // Állítsa be az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));

    // Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
    let sourceImage = aspose.slides.Images.fromFile("lotus.png");
    let presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Rendelje hozzá a képet az alakzathoz.
    let pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Állítsa be a kép kitöltés módját és a csempe tulajdonságait.
    pictureFillFormat.setPictureFillMode(aspose.slides.PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(java.newByte(aspose.slides.RectangleAlignment.BottomRight));
    pictureFillFormat.setTileFlip(aspose.slides.TileFlip.FlipBoth);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A csempe beállítások](tile-options.png)

## **Egyetlen színű kitöltés**

A PowerPointban az Egyetlen színű kitöltés egy olyan formázási lehetőség, amely egy alakzatot egyetlen, egységes színnel tölti ki. Ez a tiszta háttérszín nem tartalmaz semmilyen színátmenetet, textúrát vagy mintát.

Egyetlen színű kitöltés alkalmazásához az Aspose.Slides segítségével kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) tulajdonságát `Solid` értékre.
1. Rendeljen a forma számára egy kedvenc kitöltőszínt.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazzon egyetlen színű kitöltést egy téglalapra egy PowerPoint dián:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-re.
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));

    // Állítsa be a kitöltő színt.
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat egyetlen színű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egy alakzatra egyetlen színt, gradiens, kép vagy textúra kitöltést alkalmaz, beállíthatja az átlátszóság szintjét a kitöltés opacitásának szabályozásához. A magasabb átlátszóság érték átlátszóbbá teszi az alakzatot, és lehetővé teszi, hogy a háttér vagy az alatta lévő objektumok részben láthatóak legyenek.

Az Aspose.Slides lehetővé teszi az átlátszóság szintjének beállítását a kitöltés színének alfa értékének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/filltype/) tulajdonságot `Solid` értékre.
1. Használja a `Color` osztályt egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy szilárd téglalap automatikus alakzatot.
    let solidShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
    let transparentShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    transparentShape.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 255, 0, 204));

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_transparency.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet, ha a vizuális elemeket bizonyos elrendezési vagy tervezési igények szerint kell elhelyezni.

Alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi JavaScript kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```js
// Hozzon létre egy Presentation osztályt, amely egy prezentáció fájlt képvisel.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezze meg az első diát.
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa el az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D rézsút hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságait a rézsút beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi JavaScript kód megmutatja, hogyan alkalmazzon 3D rézsút hatásokat egy alakzatra:

```js
// Hozzon létre egy Presentation osztály példányt.
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy alakzatot a diához.
    let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "ORANGE"));
    shape.getLineFormat().setWidth(2.0);

    // Állítsa be az alakzat ThreeDFormat tulajdonságait.
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

![A 3D rézsút hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Prezentáció](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe szerint.
1. Adjon egy [AutoShape](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/autoshape/) elemet a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/camera/#setCameraType) és a [setLightType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/lightrig/#setLightType) metódusokat a 3D forgatás definiálásához.
1. Mentse a prezentációt.

Az alábbi JavaScript kód bemutatja, hogyan alkalmazzon 3D forgatási hatást egy alakzatra:

```js
// Hozzon létre egy Presentation osztály példányt.
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

## **Formázás visszaállítása**

Az alábbi Java kód bemutatja, hogyan állíthatja vissza egy dia formázását, és hogyan állíthatja vissza a helyzetet, méretet és formázást az összes helyőrzős alakzatra a [LayoutSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/layoutslide/) alapértelmezett beállításaira:

```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        let slide = presentation.getSlides().get_Item(i);
        // Állítsa vissza a dián minden alakzatot, amelynek helyőrzője van az elrendezésen.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Aktualizálja-e az alakzat formázása a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legnagyobb részét, míg az alakzati paraméterek, például színek, effektusok és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a fájlméretet.

**Hogyan tudom felismerni azokat az alakzatokat egy dián, amelyek azonos formázással rendelkeznek, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effekt beállítások. Ha minden megfelelő érték megegyezik, tekintse a stílusukat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Elmenthetek-e egy egyedi alakzatstílus készletet egy külön fájlba, hogy más prezentációkban újra felhasználhassam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat ahol csak szükséges.