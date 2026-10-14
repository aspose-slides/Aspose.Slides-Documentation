---
title: PowerPoint alakzatok formázása Androidon
linktitle: Alakzatformázás
type: docs
weight: 20
url: /hu/androidjava/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- vázlat hatás
- vázlat alakzatvonal
- csatlakozási stílus formázása
- színátmenetes kitöltés
- mintás kitöltés
- kép kitöltés
- textúra kitöltés
- egységes színű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat megjelenítés
- szürkeárnyalatos alakzat megjelenítés
- alakzat forgatása
- 3D lekerekítés hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Androidon az Aspose.Slides segítségével—állítson be kitöltési, vonal- és effektusstílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes ellenőrzéssel."
---
## **Bevezetés**

A PowerPoint‑ban alakzatokat adhat hozzá a diához. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy effektusok alkalmazásával. Emellett beállíthatja a kitöltési beállításokat, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Android via Java olyan interfészeket és metódusokat biztosít, amelyekkel a PowerPointban elérhető ugyanazokat a lehetőségeket használva formázhatja az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides segítségével egyedi vonalstílust adhat egy alakzathoz. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linestyle/) értékét.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a [dash style](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linedashstyle/) értékét.
1. Állítsa be az alakzat vonalszínét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-et:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Távolítsa el a kitöltést a téglalap alakzatról, hogy csak a vonalai legyenek láthatók.
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

![A formázott vonalak a bemutatóban](formatted-lines.png)

## **Skicceffektusok alkalmazása az alakzat vonalaira**

A skicceffektus kézzel rajzolt megjelenést kölcsönöz a vonalnak. Használja a [IShape.getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/) metódust a vonalbeállítások eléréséhez, az [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) metódust a skicbeállításokhoz, és az [ISketchFormat.setSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) felsorolásból való érték kiválasztásához.

Az alábbi Java kód megmutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) effektust, hogyan olvassa ki a kifejezetten beállított értéket, valamint hogyan távolítsa el az effektust a [LineSketchType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/linesketchtype/) segítségével:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // A forma vonalformátumához és vázlatformátumához fér hozzá.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Vázlat hatást alkalmaz.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // A forma közvetlenül hozzárendelt vázlat hatását olvassa.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Vázlat hatást eltávolít.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Az [ISketchFormat.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformat/) által visszaadott érték közvetlenül az alakzatra beállított konfigurációt reprezentálja. Ha a vonalformázás öröklődik egy témából, mester diából vagy elrendezési diából, használja az [ILineFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformat/) metódust, majd az [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilineformateffectivedata/) és [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/isketchformateffectivedata/) segítségével olvassa ki a tényleges értéket. A hatékony érték az öröklődés feloldása után ténylegesen alkalmazott formázást tükrözi:

```java
import com.aspose.slides.*;

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

A három csatlakozási típus:

* Kerek
* Vágott
* Lóvas

Alapértelmezés szerint a PowerPoint a **Kerek** beállítást használja, amikor két vonalat egy szögnél (például egy alakzat sarkán) kapcsol össze. Ha azonban éles szögekkel rendelkező alakzatot rajzol, a **Vágott** opció lehet előnyösebb.

![A csatlakozási stílus a bemutatóban](join-style-powerpoint.png)

Az alábbi Java kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható) a Vágott, Lóvas és Kerek csatlakozási beállításokkal:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá három Rectangle típusú automatikus alakzatot.
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

    // Állítsa be minden téglalap vonalának színét.
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

A PowerPointban a Színátmenetes kitöltés egy formázási lehetőség, amely folyamatos színátmenetet alkalmaz egy alakzatra. Például több színt is alkalmazhat úgy, hogy az egyik fokozatosan beleolvad a másikba.

Így alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékét `Gradient`‑ra.
1. Adja hozzá a két kívánt színt a megadott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igradientformat/) interfész által biztosított színátmenet‑stopok gyűjteményének `add` metódusaival.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisen:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Állítsa be a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Adjon hozzá két színátmenet‑állomást.
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

Ha a színátmenet a kiexportált képen eltér a PowerPointban láthatótól, lásd a [Choose a Gradient Rendering Style](/slides/hu/androidjava/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) részt. A megjelenítési stílus kiválasztása nem módosítja a prezentációban tárolt színátmenetet.

## **Minta kitöltés**

A PowerPointban a Minta kitöltés egy formázási lehetőség, amellyel kéttónusú mintát (például pontok, csíkok, keresztvonalak vagy sakktáblaminta) alkalmazhat egy alakzatra. A mintához egyéni előtér- és háttérszíneket is megadhat.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket alakzatokra alkalmazhat annak érdekében, hogy látványosabbá tegye a prezentációkat. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket.

Az alábbiakban bemutatjuk, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékét `Pattern`‑ra.
1. Válasszon egy mintastílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/androidjava/com.aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon minta kitöltést egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
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

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Kép kitöltés egy formázási lehetőség, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – a képet gyakorlatilag az alakzat háttérként használja.

Az alábbi lépések mutatják, hogyan használja az Aspose.Slides‑t kép kitöltés alkalmazásához:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékét `Picture`‑ra.
1. Állítsa be a kép kitöltés módját `Tile`‑re (vagy egy másik kívánt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) objektumot a felhasználandó képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított bemutatót PPTX fájlként.

Tegyük fel, hogy van egy „lotus.png” fájl a következő képpel:

![A lotus kép](lotus.png)

Az alábbi Java kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
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

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Csempézett kép textúraként**

Ha egy csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, használhatja a [IPictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/picturefillformat/) osztály következő metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): A kép kitöltés módját állítja – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Meghatározza a csempék igazítását az alakzatban.
- [setTileFlip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőben legyen-e tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): A csempe vízszintes eltolását (pontban) állítja az alakzat kiindulópontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): A csempe függőleges eltolását (pontban) állítja az alakzat kiindulópontjától.
- [setTileScaleX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): A csempe vízszintes méretezését százalékban adja meg.
- [setTileScaleY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): A csempe függőleges méretezését százalékban adja meg.

Az alábbi kódminta megmutatja, hogyan adjon egy téglalap alakzatot csempézett kép kitöltéssel, és konfigurálja a csempe beállításait:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Állítsa be a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Töltsön be egy képet és adja hozzá a prezentáció erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Rendelje hozzá a képet az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Állítsa be a kép kitöltés módját és a csempézés tulajdonságait.
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

![A csempe beállításai](tile-options.png)

## **Egységes színű kitöltés**

A PowerPointban az Egységes színű kitöltés egy egyszerű formázási lehetőség, amely egyetlen, egyenletes színnel tölti ki az alakzatot. Ez a háttérszín nem tartalmaz semmilyen színátmenetet, textúrát vagy mintát.

Egységes színű kitöltés alkalmazásához Aspose.Slides‑sel:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékét `Solid`‑ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon egységes színű kitöltést egy téglalapra egy PowerPoint dián:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-re.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Állítsa be a kitöltő színt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az alakzat egységes színű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

PowerPointban, ha egységes színt, színátmenetet, képet vagy textúrát alkalmaz a kitöltéshez, megadhatja az átlátszósági szintet is, amely szabályozza a kitöltés átlátszóságát. A nagyobb átlátszóság érték átlátszóbbá teszi az alakzatot, így a háttér vagy az alatta lévő objektumok részben láthatóvá válnak.

Az Aspose.Slides lehetővé teszi az átlátszóság beállítását a kitöltés színének alfa komponensének módosításával. Így teheti:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) értékét `Solid`‑ra.
1. Használja a `Color`‑t egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy szilárd téglalap automatikus alakzatot.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölé.
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

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek meghatározott igazítás vagy tervezési igények szerinti elhelyezésénél.

Alakzat forgatásához egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
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

![Az alakzat forgatása](shape-rotation.png)

## **3D lekerekítés effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D lekerekítés effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D lekerekítés hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) tulajdonságait a lekerekítési beállítások meghatározásához.
1. Mentse a prezentációt.

Az alábbi Java kód bemutatja, hogyan alkalmazzon 3D lekerekítést egy alakzatra:

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

![A 3D lekerekítési effektus](3D-bevel-effect.png)

## **3D forgatási effektusok hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási effektusok alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Használja a [setCameraType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icamera/#setCameraType-int-) és a [setLightType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

Az alábbi Java kód demonstrálja a 3D forgatási effektus alkalmazását egy alakzatra:

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

![A 3D forgatási effektus](3D-rotation-effect.png)

## **Fekete‑fehér megjelenítés vezérlése alakzatoknál**

Az [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metódus határozza meg, hogyan jelenik meg egy adott alakzat fekete‑fehér módban, amikor a prezentációt így tekintik vagy dolgozzák fel. Nem kapcsol be a fekete‑fehér megjelenítést önmagában, és nem módosítja az alakzat kitöltését, vonalát vagy egyéb formázását normál színes módban.

A [BlackWhiteMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/blackwhitemode/) osztályból egy értéket válasszon a kívánt viselkedéshez. Például az `Automatic` lehetővé teszi a megjelenítő alkalmazásnak a konverziót, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete‑fehér színt használ, a `Black` és a `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete‑fehér módban, a `NotDefined` pedig azt jelenti, hogy nincs alakzatszintű mód beállítva.

Az alábbi Java kód egy színes alakzatot hoz létre, amely fekete‑fehér megjelenítéskor szürke lesz:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Tartsa a narancssárga kitöltést szín módban, de fekete-fehér módban szürke színnel jelenítse meg az alakzatot.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normál színes módban a téglalap narancssárga kitöltésű marad. Fekete‑fehér megjelenítési munkafolyamatban a `Gray` mód miatt szürke színt kap, ami lehetővé teszi, hogy a teljes színű dia megmaradjon, miközben a nyomtatás, előnézet vagy más, a fekete‑fehér beállítást tiszteletben tartó munkafolyamatokhoz külön megjelenést definiáljon.

## **Formázás visszaállítása**

Az alábbi Java kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza az összes helyőrzős alakzat helyzetét, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslide/) alapértelmezett beállításaira:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésben.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A formaformázás befolyásolja a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a legtöbb helyet, míg a színek, effektusok és színátmenetek metaadatai szinte nem növelik a méretet.

**Hogyan tudok olyan alakzatokat detektálni egy dián, amelyek azonos formázást használnak, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállítások. Ha minden megfelelő érték egyezik, tekintse a stílusukat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek-e egy egyéni alakzatstílus készletet külön fájlba, hogy más prezentációkban is felhasználhassam?**

Igen. Tárolja a kívánt stílusokkal ellátott mintalakzatokat egy sablon diakönyvtárban vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a kívánt helyeken.