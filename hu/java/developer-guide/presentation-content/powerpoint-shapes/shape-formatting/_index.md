---
title: "Formázza a PowerPoint alakzatokat Java-ban"
linktitle: "Alakzatformázás"
type: docs
weight: 20
url: /hu/java/shape-formatting/
keywords:
- "alakzat formázása"
- "vonal formázása"
- "vázlat hatás"
- "alakzatvonal vázlat"
- "csatlakozási stílus formázása"
- "gradiens kitöltés"
- "minta kitöltés"
- "kép kitöltés"
- "textúra kitöltés"
- "egyszínű kitöltés"
- "alakzat átlátszóság"
- "fekete-fehér alakzat renderelés"
- "szürkeárnyalatos alakzat renderelés"
- "alakzat forgatása"
- "3D feréles hatás"
- "3D forgatási hatás"
- "formázás visszaállítása"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Java-ban az Aspose.Slides segítségével – állítson be kitöltés, vonal és hatás stílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes irányítással."
---
## **Bevezetés**

PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Emellett beállíthatja az alakzatok kitöltését irányító beállítások megadásával.

![format-shape-powerpoint](format-shape-powerpoint.png)

Aspose.Slides for Java felületeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazon beállításokkal.

## **Vonalak formázása**

Aspose.Slides segítségével megadhat egy egyéni vonalstílust egy alakzathoz. Az alábbi lépések mutatják a eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [vonalstílusát](https://reference.aspose.com/slides/java/com.aspose.slides/linestyle/).
1. Állítsa be a vonal vastagságát.
1. Állítsa be a vonal [szaggatott stílusát](https://reference.aspose.com/slides/java/com.aspose.slides/linedashstyle/).
1. Állítsa be a vonal színét az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő kód bemutatja, hogyan formázhat egy `AutoShape` téglalapot:

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

    // Állítsa be a téglalap alakzat kitöltő színét.
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

## **Vázlatos hatások alkalmazása az alakzat vonalaira**

Az vázlatos hatás úgy jeleníti meg a vonalat, mintha kézzel rajzolt lenne. Használja a [IShape.getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/) metódust a vonalbeállítások eléréséhez, a [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/) metódust a vázlat beállításokhoz, és a [ISketchFormat.setSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) felsorolásból egy érték kiválasztásához.

A következő Java kód bemutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/java/com.aspose.slides/linesketchtype/) használatával:

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Hozzáfér az alakzat vonalformátumához és annak vázlatformátumához.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Alkalmaz egy vázlat hatást.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Olvassa ki a közvetlenül az alakzatra hozzárendelt vázlat hatást.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Távolítsa el a vázlat hatást.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

A [ISketchFormat.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformat/) által visszaadott érték a közvetlenül az alakzatra beállított beállítást jelenti. Ha a vonalformázás öröklődésen keresztül jön egy témából, mesterdiából vagy elrendezési diából, használja az [ILineFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformat/), érje el a [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ilineformateffectivedata/), és olvassa ki az [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/java/com.aspose.slides/isketchformateffectivedata/). A hatékony érték azt a formázást tükrözi, amely az öröklődés feloldása után ténylegesen alkalmazásra kerül:

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

Itt vannak a három csatlakozási típus lehetőségei:

* Kerek
* Derékszögű
* Feréles

Alapértelmezés szerint, amikor a PowerPoint két vonalat szöggel (például egy alakzat sarkán) kapcsol össze, a **Kerek** beállítást használja. Azonban, ha éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Derékszögű** lehetőséget.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

A következő Java kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Derékszögű, Feréles és Kerek csatlakozási típus beállításokkal:

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

    // Állítsa be a kitöltő színt minden téglalap alakzathoz.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Állítsa be a vonal vastagságát.
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

## **Gradiens kitöltés**

PowerPointban a Gradiens kitöltés egy olyan formázási beállítás, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan átmenjen a másikba.

Itt látható, hogyan alkalmazzon gradiens kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékét `Gradient`-re.
1. Adja hozzá a két kívánt színt a megadott pozíciókkal az [IGradientFormat](https://reference.aspose.com/slides/java/com.aspose.slides/igradientformat/) felület által biztosított `add` metódusokkal a gradiens‑stop gyűjteményben.
1. Mentse a módosított prezentációt PPTX fájlként.

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazzon gradiens formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Állítsa be a gradiens irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Adjon hozzá két gradiens stopot.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Az ellipszis gradiens kitöltéssel](gradient-fill.png)

Ha egy gradiens másként néz ki egy exportált képen, mint a PowerPointban, tekintse meg a [Choose a Gradient Rendering Style](/slides/hu/java/convert-powerpoint-to-png/#choose-a-gradient-rendering-style) oldalt. Kiválaszthat egy renderelési stílust anélkül, hogy megváltoztatná a prezentációban tárolt gradiens kitöltést.

## **Minta kitöltés**

PowerPointban a Minta kitöltés egy formázási beállítás, amely lehetővé teszi, hogy kétszínű mintát (például pontokat, csíkokat, keresztvonalakat vagy négyzethálót) alkalmazzon egy alakzatra. Egyedi színeket választhat a minta előtérhez és háttérhez.

Az Aspose.Slides több mint 45 előre definiált minta stílust biztosít, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelésére. Még egy előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használjon.

Itt látható, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/java/com.aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse a módosított prezentációt PPTX fájlként.

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

    // Állítsa be a minta háttér- és előtér színeit.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

PowerPointban a Kép kitöltés egy formázási beállítás, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – hatékonyan használva a képet az alakzat háttérként.

Itt látható, hogyan alkalmazzon kép kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékét `Picture`-re.
1. Állítsa be a kép kitöltési módot `Tile`-re (vagy egy másik kívánt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) objektumot a használandó képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

![A lotus kép](lotus.png)

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

    // Állítsa be a kép kitöltési módot.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
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

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempézése textúraként**

Ha csempézett képet szeretne textúraként beállítani és testreszabni a csempézés viselkedését, használhatja a [IPictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/) felület és a [PictureFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/picturefillformat/) osztály alábbi metódusait:

- [setPictureFillMode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a kép kitöltési módot – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulópontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulópontjától.
- [setTileScaleX](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Meghatározza a csempe függőleges méretezését százalékban.

A következő kódrészlet bemutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és állítsa be a csempe opciókat:

```java
import com.aspose.slides.*;

// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Állítsa be az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Rendelje hozzá a képet az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Állítsa be a kép kitöltési módot és a csempézés tulajdonságait.
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

![A csempe opciók](tile-options.png)

## **Egyszínű kitöltés**

PowerPointban az Egyszínű kitöltés egy olyan formázási beállítás, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín grádiensek, textúrák vagy minták nélkül kerül alkalmazásra.

Az egyszínű kitöltés alakzatra való alkalmazásához az Aspose.Slides segítségével kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Rendelje hozzá a kívánt kitöltő színt az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

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

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

PowerPointban, amikor egyszínű, gradiens, kép vagy textúra kitöltést alkalmaz alakzatokra, beállíthat átlátszósági szintet is, amely szabályozza a kitöltés átlátszóságát. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve a háttér vagy a mögöttes objektumok részleges láthatóságát.

Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltéshez használt szín alfa komponensének módosításával. Íme, hogyan történik:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` osztályt egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

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

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek meghatározott elrendezése vagy tervezése során.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

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

![Az alakzat forgatása](shape-rotation.png)

## **3D Feréles hatások hozzáadása**

Aspose.Slides lehetővé teszi 3D feréles hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) tulajdonságainak beállításával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) tulajdonságait a feréles beállítások meghatározásához.
1. Mentse a prezentációt.

```java
import com.aspose.slides.*;
import java.awt.Color;

// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Alakzat hozzáadása a diához.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.GREEN);
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.ORANGE);
    shape.getLineFormat().setWidth(2.0);

    // Az alakzat ThreeDFormat tulajdonságainak beállítása.
    shape.getThreeDFormat().setDepth(4);
    shape.getThreeDFormat().getBevelTop().setBevelType(BevelPresetType.Circle);
    shape.getThreeDFormat().getBevelTop().setHeight(6);
    shape.getThreeDFormat().getBevelTop().setWidth(6);
    shape.getThreeDFormat().getCamera().setCameraType(CameraPresetType.OrthographicFront);
    shape.getThreeDFormat().getLightRig().setLightType(LightRigPresetType.ThreePt);
    shape.getThreeDFormat().getLightRig().setDirection(LightingDirection.Top);

    // A prezentáció mentése PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![A 3D feréles hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/java/com.aspose.slides/threedformat/) tulajdonságainak beállításával.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet a diára.
1. Használja a [setCameraType](https://reference.aspose.com/slides/java/com.aspose.slides/icamera/#setCameraType-int-) és a [setLightType](https://reference.aspose.com/slides/java/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

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

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatoknál**

Az [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metódus meghatározza, hogy egy egyedi alakzat hogyan jelenik meg, amikor a prezentációt fekete-fehér módban tekintik vagy dolgozzák fel. Nem kapcsol be önmagában a fekete-fehér megjelenítést, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását a normál színmódban.

Használja a [BlackWhiteMode](https://reference.aspose.com/slides/java/com.aspose.slides/blackwhitemode/) osztály értékét a kívánt viselkedés kiválasztásához. Például az `Automatic` hagyja, hogy a renderelő alkalmazás válassza a konverziót, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak fekete-fehér színeket használ, a `Black` és `White` egyetlen színt kényszerít, a `Color` megőrzi a normál színezést, a `Hidden` elrejti az alakzatot fekete-fehér módban, a `NotDefined` azt jelenti, hogy nincs alakzatszintű mód beállítva.

A következő Java kód létrehoz egy színes alakzatot, és fekete-fehér megjelenítési módban szürkének mutatja:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    // Tartsa a narancssárga kitöltést színmódban, de a alakzatot szürke színnel jelenítse meg fekete-fehér módban.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete-fehér megjelenítési munkafolyamatban szürke színezést használ, mivel a módja `Gray`-re van állítva. Ez lehetővé teszi, hogy megtartsa a teljes színű diát, miközben meghatározza a nyomtatás, előnézet vagy egyéb munkafolyamatok számára a külön megjelenést, amelyek tiszteletben tartják a prezentáció fekete-fehér megjelenítési beállításait.

## **Formázás visszaállítása**

A következő Java kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza a [LayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslide/) helyőrzőkkel rendelkező összes alakzat pozícióját, méretét és formázását az alapértelmezett beállításokra:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Állítsa vissza a dián lévő minden alakzatot, amelynek helyőrzője van az elrendezésen.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A befolyásolja az alakzat formázása a végső prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl méretének nagy részét, míg az alakzat paraméterei, mint a színek, hatások és grádiensek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan lehet felismerni a dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Használja az egyes alakzatok kulcsfontosságú formázási tulajdonságainak – kitöltés, vonal és hatás beállításainak – összehasonlítását. Ha minden megfelelő érték egyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ez megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyedi alakzati stílusok halmazt külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tárolja a kívánt stílusokkal ellátott minta alakzatokat egy sablon diákkészletben vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza újra a formázásukat a szükséges helyeken.