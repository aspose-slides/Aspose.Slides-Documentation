---
title: PowerPoint alakzatok formázása Java-ban
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat effektus
- vázlat alakzatvonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- alakzat forgatása
- 3D bevel effektus
- 3D forgatás effektus
- formázás visszaállítása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Java-ban az Aspose.Slides használatával—állítson be kitöltés, vonal és effektus stílusokat PPT, PPTX és ODP fájlokhoz pontosan és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a vonalvonalak módosításával vagy effektusok alkalmazásával. Emellett az alakzatok kitöltését is beállíthatja, megadva a belső terület kitöltésének módját.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Java interfészeket és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokkal a lehetőségekkel formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzat egyedi vonalstílusát adhatja meg. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal szélességét.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linedashstyle/) értékét.
1. Állítsa be a vonal színét az alakzatra.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy `AutoShape` téglalapot:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Beállítja a téglalap alakzat kitöltő színét.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Formázást alkalmaz a téglalap vonalaira.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Beállítja a téglalap vonalának színét.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The formatted lines in the presentation](formatted-lines.png)

## **Vázlat hatások alkalmazása alakzatvonalakra**

A vázlat effektus kézzel rajzolt vonalat eredményez az alakzaton. Használja a [IShape.getLineFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) metódust a vonalbeállítások eléréséhez, az [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformat/) metódust a vázlat beállításokhoz, és az [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linesketchtype/) felsorolt értékek egyikének kiválasztásához.

Az alábbi Java kód azt mutatja, hogyan alkalmazzon [LineSketchType.Curved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linesketchtype/) hatást, olvassa ki a kifejezetten beállított értéket, és távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linesketchtype/) használatával:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Hozzáfér az alakzat vonalformátumához és annak vázlatformátumához.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Vázlat effektust alkalmaz.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Kiolvassa a alakzatra közvetlenül hozzárendelt vázlat effektust.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Eltávolítja a vázlat effektust.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Az [ISketchFormat.getSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isketchformat/) által visszaadott érték a közvetlenül az alakzatra beállított konfigurációt jelenti. Ha a vonalformázás öröklődik egy témából, mesterdiáról vagy elrendezésdióból, használja az [ILineFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformat/) metódust, érje el az [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformateffectivedata/) értéket, és olvassa ki az [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isketchformateffectivedata/) értékét. A hatékony érték a ténylegesen alkalmazott formázást tükrözi az öröklődés feloldása után:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    ILineFormat lineFormat = shape.getLineFormat();

    int explicitSketchType = lineFormat.getSketchFormat().getSketchType();
    ILineFormatEffectiveData effectiveLineFormat = lineFormat.getEffective();
    int effectiveSketchType = effectiveLineFormat.getSketchFormat().getSketchType();

    System.out.println("Explicit sketch type: " + explicitSketchType);
    System.out.println("Effective sketch type: " + effectiveSketchType);
} finally {
    presentation.dispose();
}
```

## **Csatlakozási stílusok formázása**

Az alábbi három csatlakozási típus érhető el:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat egy szögben (például egy alakzat sarkában) illeszt össze, a **Round** beállítást használja. Ha azonban hegyes szögekkel rendelkező alakzatot rajzol, előnyösebb lehet a **Miter** opció.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi Java kód bemutatja, hogyan hoztak létre három téglalapot (a fenti képen látható) a Miter, Bevel és Round csatlakozási típusok beállításaival:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad három automatikus alakzatot Rectangle típusban.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Beállítja minden téglalap alakzat kitöltő színét.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Beállítja a vonal vastagságát.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Beállítja minden téglalap vonalának színét.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Beállítja a csatlakozási stílust.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Szöveget ad minden téglalaphoz.
    shape1.getTextFrame().setText("Miter Join Style");
    shape2.getTextFrame().setText("Bevel Join Style");
    shape3.getTextFrame().setText("Round Join Style");

    // Mentés PPTX fájlként a lemezre.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt használhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az Aspose.Slides segítségével a színátmenetes kitöltés alkalmazásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be a shape [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Gradient`-ra.
1. Adja hozzá a két preferált színt meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `add` metódusaival.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisen:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Ellipse típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazza a színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Beállítja a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Két színátmeneti pontot ad hozzá.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy olyan formázási lehetőség, amely két színű mintát (például pontok, csíkok, keresztvonalak vagy négyzethálók) alkalmaz egy alakzatra. A minta előtér és háttér színét egyéni színekre állíthatja.

Az Aspose.Slides több mint 45 előre definiált minta stílust kínál, amelyeket alakzatokra alkalmazhat a bemutatók vizuális vonzerejének növelése érdekében. Miután kiválasztott egy előre definiált mintát, továbbra is megadhatja a pontos színeket, amelyeket a minta használjon.

A minta kitöltés alkalmazásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be a shape [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapon:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Pattern-re.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Beállítja a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Beállítja a minta háttér- és előtérszíneit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen be egy alakzatba – lényegében a képet az alakzat háttérként használja.

Az alábbiakban bemutatjuk, hogyan használhatja az Aspose.Slides-t kép kitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be a shape [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Picture`-ra.
1. Állítsa be a kép kitöltés módját `Tile`-re (vagy más preferált módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) objektumot a használni kívánt képről.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájlunk a következő képpel:

![The lotus picture](lotus.png)

Az alábbi Java kód bemutatja, hogyan tölthet ki egy alakzatot a képpel:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Beállítja a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja a kép kitöltési módot.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Beállítja a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Csempe képet textúraként**

Ha szeretne egy csempézett képet textúraként beállítani és testre szabni a csempézés viselkedését, használja az alábbi [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillformat/) osztály metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Meghatározza a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pointban) az alakzat origójától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pointban) az alakzat origójától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálja a csempe beállításait:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Hozzáad egy téglalap automatikus alakzatot.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Az alakzathoz rendeli a képet.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Beállítja a kép kitöltési módot és a csempézés tulajdonságait.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The tile options](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy olyan formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín nincs gradiensek, textúrák vagy minták befolyásolásában.

Az Aspose.Slides segítségével egy egyszínű kitöltés alkalmazásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be a shape [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Állítsa be a kívánt kitöltő színt az alakzaton.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapon egy PowerPoint dián:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Solid-re.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Beállítja a kitöltő színt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, képes vagy textúrás kitöltést alkalmaz egy alakzatra, beállíthatja az átlátszósági szintet a kitöltés átlátszóságának szabályozásához. A magasabb átlátszósági érték áttetszőbbé teszi az alakzatot, lehetővé téve a háttér vagy a mögötte lévő objektumok részleges láthatóságát.

Az Aspose.Slides lehetővé teszi az átlátszóság szintjének beállítását a kitöltés színének alfa komponensének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` osztályt egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon átlátszó kitöltő színt egy téglalapon:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy szilárd téglalap automatikus alakzatot.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Hozzáad egy áttetsző téglalap automatikus alakzatot a szilárd alakzat fölé.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Mentés PPTX fájlként a lemezre.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi az alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet vizuális elemek konkrét igazítási vagy tervezési igények szerinti elhelyezésénél.

Egy alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Rectangle típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgatja az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Mentés PPTX fájlként a lemezre.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D bevel hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D bevel hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D bevel hatások hozzáadásához egy alakzatra kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságait a bevel beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon 3D bevel hatásokat egy alakzatra:

```java
// Létrehoz egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Alakzatot ad hozzá a diához.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Beállítja az alakzat ThreeDFormat tulajdonságait.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // Mentés PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The 3D bevel effect](3D-bevel-effect.png)

## **3D forgatás hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatás hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára a indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) alakzatot a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icamera/#setCameraType-int-) és a [setLightType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon 3D forgatás hatásokat egy alakzatra:

```java
// Létrehoz egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Mentés PPTX fájlként.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The 3D rotation effect](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi Java kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza az összes alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslide/) helyőrzőinek alapértelmezett beállításaival:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Visszaállítja a dián lévő minden alakzatot, amelynek van helyőrzője az elrendezésben.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Hatással van-e az alakzatformázás a végső prezentáció fájlméretére?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legnagyobb részét, míg az alakzatparaméterek, például színek, effektusok és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan lehet azonos formázású alakzatokat egy dián felismerni, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat fő formázási tulajdonságait – kitöltés, vonal és effekt beállításait. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami egyszerűbbé teszi a későbbi stíluskezelést.

**Menthetek-e egy egyedi alakzatstílus készletet külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon diakészletben vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a kívánt helyeken.