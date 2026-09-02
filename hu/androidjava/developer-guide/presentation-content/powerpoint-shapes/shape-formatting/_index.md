---
title: PowerPoint alakzatok formázása Androidon
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/androidjava/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat alakzat vonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- képi kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3d döntött hatás
- 3d forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Androidon az Aspose.Slides használatával—állítsa be a kitöltés, vonal és effektus stílusait PPT, PPTX és ODP fájlokhoz precíz módon és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett beállíthatja az alakzatok kitöltését szabályozó beállítások megadásával.

![alakzat formázása PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for Android via Java interfészeket és metódusokat biztosít, amelyek segítségével a PowerPointban elérhető ugyanazokkal a beállításokkal formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzat egyéni vonalstílusát adhatja meg. Az alábbi lépések mutatják be az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be a forma [line style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linestyle/) attribútumát.  
1. Állítsa be a vonal vastagságát.  
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linedashstyle/) beállítását.  
1. Állítsa be a forma vonalszínét.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy `AutoShape` téglalapot:

```java
// Hozza létre a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot Téglalap típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Állítsa be a téglalap alakzat kitöltőszínét.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Alkalmazzon formázást a téglalap vonalaira.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Állítsa be a téglalap vonalának színét.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Vázlat hatások alkalmazása az alakzat vonalaira**

A vázlat hatás úgy teszi, hogy az alakzat vonala kézzel rajzoltnak tűnik. Használja a [IShape.getLineFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) metódust a vonalbeállítások eléréséhez, a [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformat/) metódust a vázlat beállításainak eléréséhez, és a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linesketchtype/) felsorolásból érték kiválasztásához.

Az alábbi Java kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linesketchtype/) hatást, olvassa el a kifejezetten megadott értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linesketchtype/) használatával:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Az alakzat vonalformátumához és vázlatformátumához való hozzáférés.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Vázlat hatás alkalmazása.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Olvassa be a alakzatra közvetlenül hozzárendelt vázlat hatást.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // A vázlat hatás eltávolítása.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

A [ISketchFormat.getSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isketchformat/) által visszaadott érték a forma közvetlenül hozzárendelt beállítását jelenti. Ha a vonalfogalmazás öröklődik egy témából, mester‑diából vagy elrendezési diából, használja a [ILineFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformat/) metódust, férjen hozzá a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformateffectivedata/) metódushoz, és olvassa el a [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isketchformateffectivedata/) értékét. A hatékony érték tükrözi a formázást, amely az öröklődés feloldása után ténylegesen alkalmazásra kerül:

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

## **Összekapcsolási stílusok formázása**

A három összekapcsolási típus opciója:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat köt össze szögben (például egy alakzat sarkán), a **Round** beállítást használja. Azonban ha éles szögekkel rajzol alakzatot, a **Miter** opció lehet megfelelőbb.

![Az összekapcsolási stílus a prezentációban](join-style-powerpoint.png)

Az alábbi Java kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Miter, Bevel és Round összekapcsolási típus beállításokkal:

```java
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Három téglalap típusú automatikus alakzatot ad hozzá.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Beállítja minden téglalap alakzat kitöltőszínét.
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

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Színátmenetes kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az alábbiak szerint alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be a forma [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Gradient`‑re.  
1. Az [IGradientFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igradientformat/) interfész által biztosított gradient‑stop gyűjtemény `add` metódusaival adja hozzá a kívánt két színt meghatározott pozícióval.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```java
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Ellipszis típusú automatikus alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Színátmenetes formázást alkalmaz az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Beállítja a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Két színátmenet‑stopot ad hozzá.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy olyan formázási lehetőség, amely két színű mintát – például pontokat, csíkokat, keresztvonalakat vagy négyzeteket – alkalmaz egy alakzatra. A minta előtér és háttér színeit egyéni színekkel állíthatja be.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket a minta használjon.

Az alábbiak szerint alkalmazhat mintás kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be a forma [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Pattern`‑re.  
1. Válasszon egy mintastílust a rendelkezésre álló opciók közül.  
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternformat/#getBackColor--) értékét.  
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternformat/#getForeColor--) értékét.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon mintás kitöltést egy téglalapra:

```java
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Téglalap típusú automatikus alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // A kitöltés típusát Pattern-re állítja.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // A mintastílust állítja be.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // A minta háttér- és előtérszínét állítja be.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A téglalap mintás kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy olyan formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – lényegében a képet háttérként használva.

Az alábbiak szerint használhatja az Aspose.Slides‑t képkitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be a forma [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Picture`‑re.  
1. Állítsa be a kép kitöltés módját `Tile`‑ra (vagy egy másik kívánt módra).  
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot a használni kívánt képből.  
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.  
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” nevű fájlunk a következő képpel:

![A lótusz kép](lotus.png)

Az alábbi Java kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```java
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Téglalap típusú automatikus alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // A kitöltés típusát Picture-re állítja.
    shape.getFillFormat().setFillType(FillType.Picture);

    // A kép kitöltési módot állítja be.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Kép betöltése és hozzáadása a prezentáció erőforrásaihoz.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // A képet állítja be.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat képpel kitöltve](picture-fill.png)

### **Kép csempeként textúrához**

Ha csempézett képet szeretne beállítani textúraként, és testre szabni a csempézési viselkedést, használhatja a [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a kép kitöltési módot – `Tile` vagy `Stretch`.  
- [setTileAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Megadja a csempék igazítását az alakzaton belül.  
- [setTileFlip](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Meghatározza, hogy a csempe vízszintesen, függőlegesen vagy mindkettő szerint legyen tükrözve.  
- [setTileOffsetX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontokban) az alakzat eredeti pontjától.  
- [setTileOffsetY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontokban) az alakzat eredeti pontjától.  
- [setTileScaleX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Meghatározza a csempe vízszintes méretezését százalékban.  
- [setTileScaleY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és konfigurálja a csempe beállításait:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Téglalap auto alakzatot ad hozzá.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // A forma kitöltés típusát Picture-re állítja.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Betölti a képet és hozzáadja a prezentáció erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // A képet a formához rendeli.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // A kép kitöltési módját és a csempe tulajdonságait állítja be.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // A PPTX fájlt a lemezre menti.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A csempe beállításai](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egyenletes színnel tölti ki az alakzatot. Ez a egyszerű háttérszín nem tartalmaz semmilyen színátmenetet, textúrát vagy mintát.

Az Egyszínű kitöltés alkalmazásához az Aspose.Slides‑ben kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be a forma [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`‑ra.  
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.  
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Téglalap típusú automatikus alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // A kitöltés típusát Solid-ra állítja.
    shape.getFillFormat().setFillType(FillType.Solid);

    // A kitöltőszínt állítja be.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // A PPTX fájlt a lemezre menti.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, kép‑ vagy textúra‑kitöltést alkalmaz alakzatokra, beállíthatja az átlátszósági szintet is, hogy szabályozza a kitöltés átlátszóságát. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, így a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa komponensének módosításával. Így járhat el:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`‑ra.  
1. Használja a `Color`‑t egy átlátszósággal rendelkező szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).  
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```java
// A Presentation osztály példányosítása, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Szilárd téglalap auto alakzatot ad hozzá.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Átlátszó téglalap auto alakzatot ad hozzá a szilárd alakzat fölött.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // A PPTX fájlt a lemezre menti.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint‑prezentációkban. Ez hasznos lehet a vizuális elemek meghatározott igazítási vagy tervezési igényeinek kielégítésére.

Az alakzat egy dián történő forgatásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.  
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```java
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Téglalap típusú automatikus alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Az alakzatot 5 fokkal elforgatja.
    shape.setRotation(5);

    // A PPTX fájlt a lemezre menti.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat forgatása](shape-rotation.png)

## **3D döntött hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D döntött hatások hozzáadását alakzatokhoz a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

A 3D döntött hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Konfigurálja a forma [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságait a döntött beállítások meghatározásához.  
1. Mentse a prezentációt.

Az alábbi Java kód megmutatja, hogyan alkalmazzon 3D döntött hatásokat egy alakzatra:

```java
// A Presentation osztály példányát hozza létre.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Alakzatot ad a diára.
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

    // Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D döntött hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások hozzáadását alakzatokhoz a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

A 3D forgatási hatások alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
1. Szerezzen referenciát egy diára az indexe alapján.  
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) alakzatot a diára.  
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icamera/#setCameraType-int-) és a [setLightType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás definiálásához.  
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzatra:

```java
// A Presentation osztály példányát hozza létre.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);
    autoShape.getTextFrame().setText("Hello, Aspose!");

    autoShape.getThreeDFormat().setDepth(6);
    autoShape.getThreeDFormat().getCamera().setRotation(40, 35, 20);
    autoShape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.IsometricLeftUp);
    autoShape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.Balanced);

    // Mentse a prezentációt PPTX fájlként.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi Java kód megmutatja, hogyan állíthatja vissza egy dia formázását, és hogyan állíthatja vissza a pozíciót, méretet és a helyőrzőkkel rendelkező összes alakzat formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/) alapértelmezett beállításaira:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Visszaállítja a dián lévő összes alakzatot, amelynek az elrendezésen helyőrzője van.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A forma formázása befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok teszik ki a fájl méretének a legtöbb részét, míg a forma paraméterei, például színek, effektusok és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik jelentősen a méretet.

**Hogyan tudok azonos formázású alakzatokat egy dián azonosítani, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállításait. Ha az összes megfelelő érték megegyezik, tekintse őket azonos stílusúaknak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyéni alakzatstílus-csomagot egy külön fájlba, hogy más prezentációkban is újra felhasználhassam?**

Igen. Tárolja a kívánt stílusú mintaalakzatokat egy sablon‑diakönyvben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és a kívánt helyeken alkalmazza a formázásukat.