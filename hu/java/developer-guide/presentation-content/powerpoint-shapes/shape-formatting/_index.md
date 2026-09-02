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
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D fazek effektus
- 3D forgatási effektus
- formázás visszaállítása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan formázhatja a PowerPoint alakzatokat Java-ban az Aspose.Slides segítségével - állítsa be a kitöltés, vonal és effektus stílusait PPT, PPTX és ODP fájlokhoz precízen és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhatsz a diákhoz. Mivel az alakzatok vonalakból állnak, őket a körvonalak módosításával vagy effektusok alkalmazásával formázhatod. Emellett beállítások megadásával formázhatod az alakzatok belső kitöltését is.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Java interfészeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzatra egyedi vonalstílust adhat meg. A következő lépések mutatják be az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linestyle/) értékét.
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linedashstyle/) értékét.
1. Állítsa be az alakzat vonalszínét.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy `AutoShape` téglalapot:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot, amely téglalap típusú.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Állítsa be a téglalap alakzat kitöltőszínét.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Alkalmazza a formázást a téglalap vonalaira.
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

![The formatted lines in the presentation](formatted-lines.png)

## **Vázlatos effektusok alkalmazása a alakzatvonalakra**

A vázlatos effektus kézzel rajzolt megjelenést kölcsönöz a vonalnak. Használja az [IShape.getLineFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/) metódust a vonalbeállítások eléréséhez, az [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformat/) metódust a vázlat beállításainak eléréséhez, és az [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isketchformat/) metódust, hogy a [LineSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linesketchtype/) felsorolásból válasszon értéket.

Az alábbi Java kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linesketchtype/) effektust, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el az effektust a [LineSketchType.None](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linesketchtype/) segítségével:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Hozzáfér az alakzat vonalformátumához és annak vázlatformátumához.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Alkalmaz egy vázlat effektust.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Olvassa be a közvetlenül az alakzatra rendelt vázlat effektust.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Távolítsa el a vázlat effektust.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Az [ISketchFormat.getSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isketchformat/) által visszaadott érték közvetlenül a alakzatra beállított formázást jelenti. Ha a vonalformázás öröklődik egy témából, mester diából vagy elrendezési diából, használja az [ILineFormat.getEffective](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformat/) metódust, lépjen hozzá az [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilineformateffectivedata/) metódushoz, és olvassa ki az [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/isketchformateffectivedata/) értéket. A hatékony érték az öröklődés feloldása után ténylegesen alkalmazott formázást tükrözi:

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

A három csatlakozási típus lehetősége:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat köt össze szögnél (például egy alakzat sarkánál), a **Round** beállítást használja. Ha azonban hegyes szögekkel rendelkező alakzatot rajzol, a **Miter** opció előnyösebb lehet.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi Java kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Miter, Bevel és Round csatlakozási beállításokkal:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá három automatikus alakzatot, amelyek téglalap típusúak.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Állítsa be a kitöltőszínt minden téglalap alakzatra.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Állítsa be a vonalvastagságot.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Állítsa be a vonal színét minden téglalaphoz.
    shape1.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape1.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    shape3.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape3.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // Állítsa be a csatlakozási stílust.
    shape1.getLineFormat().setJoinStyle(LineJoinStyle.Miter);
    shape2.getLineFormat().setJoinStyle(LineJoinStyle.Bevel);
    shape3.getLineFormat().setJoinStyle(LineJoinStyle.Round);

    // Adjon szöveget minden téglalaphoz.
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

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzunk egy alakzatra. Például két vagy több színt alkalmazhatunk úgy, hogy az egyik fokozatosan elhalványul a másikba.

Az Aspose.Slides használatával a színátmenetes kitöltés alkalmazása a következő:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Gradient`‑re.
1. Adja hozzá a két kívánt színt a megfelelő pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `add` metódusaival.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot, amely ellipszis típusú.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Állítsa be a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Adjon hozzá két színátmeneti stopot.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy két színű mintát – például pöttyöket, csíkokat, keresztmintát vagy négyzetrácsot – alkalmazzunk egy alakzatra. A minta első és háttérszínét egyedi színekkel állíthatja be.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket a minta használjon.

A minta kitöltés alkalmazása a következő:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Pattern`‑re.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot, amely téglalap típusú.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Pattern-re.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Állítsa be a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Állítsa be a minta háttér- és előtérszíneit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen be egy alakzatba – ezáltal a kép az alakzat háttérként szolgál.

Az Aspose.Slides használatával a kép kitöltés alkalmazása a következő:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Picture`‑re.
1. Állítsa be a kép kitöltés módját `Tile`‑re (vagy más preferált módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse el a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájlunk a következőképp:

![The lotus picture](lotus.png)

Az alábbi Java kód bemutatja, hogyan tölt fel egy alakzatot a képpel:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot, amely téglalap típusú.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Állítsa be a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Állítsa be a kép kitöltés módját.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Állítsa be a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Kép csempeként a textúrához**

Ha csempeként szeretne egy képet textúraként beállítani, és testreszabni a csempézés viselkedését, használja az [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Megadja a csempék igazítását az alakzatban.
- [setTileFlip](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Irányítja, hogy a csempe vízszintesen, függőlegesen vagy mindkettőben legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és hogyan konfigurálja a csempe beállításait:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy téglalap auto alakzatot.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Állítsa be az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Rendelje hozzá a képet az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Állítsa be a kép kitöltési módot és a csempézési tulajdonságokat.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The tile options](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez a háttérszín nem tartalmaz semmilyen színátmenetet, textúrát vagy mintát.

Az Aspose.Slides segítségével egyszínű kitöltést alkalmazhat egy alakzatra a következő lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`‑ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi Java kód megmutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra a PowerPoint dián:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot, amely téglalap típusú.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-re.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Állítsa be a kitöltés színét.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, amikor egyszínű, színátmenetes, kép‑ vagy textúrakitöltést alkalmazunk alakzatokra, megadhatjuk az átlátszósági szintet is, amely szabályozza a kitöltés átlátszatlanságát. A magasabb átlátszósági érték áttetszőbbé teszi az alakzatot, így a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszóság beállítását a kitöltéshez használt szín alfa komponensének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`‑ra.
1. Használja a `Color` osztályt egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse el a prezentációt.

Az alábbi Java kód megmutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy tömör téglalap auto alakzatot.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap auto alakzatot a tömör alakzat fölé.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek pontos elhelyezéséhez vagy tervezési igényekhez.

Alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse el a prezentációt.

Az alábbi Java kód bemutatja, hogyan forgassunk egy alakzatot 5 fokkal:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy automatikus alakzatot, amely téglalap típusú.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa el az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D Fazek Effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D fazek effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D fazek effektusok hozzáadásához egy alakzathoz kövesse a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) beállításait a fazek paraméterek definiálásához.
1. Mentse el a prezentációt.

Az alábbi Java kód megmutatja, hogyan alkalmazzon 3D fazek effektusokat egy alakzatra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy alakzatot a diához.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Állítsa be az alakzat ThreeDFormat tulajdonságait.
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

![The 3D bevel effect](3D-bevel-effect.png)

## **3D Forgatási Effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatási effektus alkalmazásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) objektumot a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icamera/#setCameraType-int-) és a [setLightType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
1. Mentse el a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon 3D forgatási effektusokat egy alakzatra:

```java
import com.aspose.slides.*;

// Hozzon létre egy példányt a Presentation osztályból.
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

![The 3D rotation effect](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatokra**

Az [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metódus határozza meg, hogyan jelenjen meg egy adott alakzat, amikor a prezentációt fekete-fehér módban tekintik vagy dolgozzák fel. Ez önmagában nem aktiválja a fekete-fehér megjelenítést, és nem módosítja az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/blackwhitemode/) osztályból a kívánt viselkedés kiválasztásához. Például az `Automatic` lehetővé teszi a megjelenítő alkalmazásnak, hogy válasszon konverziót, a `Gray` és a `LightGray` szürke árnyalatot alkalmaz, a `BlackWhite` csak feketét és fehéret használ, a `Black` és a `White` egyetlen színt erőltet, a `Color` megtartja a normál színezést, a `Hidden` elrejti az alakzatot fekete-fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzatszintű mód hozzárendelve.

Az alábbi Java kód létrehoz egy színes alakzatot, és fekete-fehér megjelenítésben szürkére állítja:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Tartsa meg a narancssárga kitöltést színmódban, de renderelje az alakzatot szürke színnel fekete-fehér módban.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete-fehér megjelenítési munkafolyamatban szürke színt használ, mert a módja `Gray`‑re van állítva. Ez lehetővé teszi, hogy a teljes színű diát megőrizze, miközben meghatározza a nyomtatásra, előnézetre vagy egyéb, a prezentáció fekete-fehér beállításait tiszteletben tartó munkafolyamatoknál a kívánt megjelenést.

## **Formázás visszaállítása**

Az alábbi Java kód megmutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza a pozíciót, méretet és a helyőrzőkkel rendelkező alakzatok formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslide/) alapértelmezett beállításaira:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Állítsa vissza az egyes alakzatokat a dián, amelyeknek helyőrzője van az elrendezésen.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**Befolyásolja az alakzat formázása a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják el a legtöbb helyet, míg a színek, effektek és színátmenetek paraméterei metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan lehet azonos formázású alakzatokat felismerni egy dián, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállításait. Ha minden megfelelő érték megegyezik, tekintse őket azonos stílusúnak, és logikusan csoportosítsa az alakzatokat, ami később egyszerűsíti a stíluskezelést.

**Menthetek-e egyedi alakzatstílusok halmazát egy külön fájlba későbbi felhasználásra más prezentációkban?**

Igen. Tárolja a kívánt stílusokkal ellátott mintaalakzatokat egy sablon diakészletben vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázást ahol szükséges.