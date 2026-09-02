---
title: PowerPoint alakzatok formázása Androidon
linktitle: Alakzat formázás
type: docs
weight: 20
url: /hu/androidjava/shape-formatting/
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
- egyszínű kitöltés
- alakzat átlátszóság
- fekete-fehér alakzat renderelés
- szürkeárnyalatos alakzat renderelés
- alakzat forgatása
- 3D domborítási hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- bemutató
- Android
- Java
- Aspose.Slides
description: "Tudja meg, hogyan formázhatja a PowerPoint alakzatokat Androidon az Aspose.Slides segítségével – állítson be kitöltés, vonal és hatás stílusokat PPT, PPTX és ODP fájlokhoz precízen és teljes irányítással."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy hatások alkalmazásával. Továbbá, alakzatokat formázhat olyan beállítások megadásával, amelyek meghatározzák, hogyan legyen kitöltve a belsejük.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Android via Java interfészeket és metódusokat biztosít, amelyek lehetővé teszik, hogy a PowerPointban elérhető ugyanazokkal a beállításokkal formázza az alakzatokat.

## **Vonalak formázása**

Az Aspose.Slides használatával egy alakzat számára megadhat egy egyedi vonalstílust. Az alábbi lépések ismertetik az eljárást:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linestyle/) értékét.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linedashstyle/) értékét.
1. Állítsa be a vonal színét az alakzatra.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi kód bemutatja, hogyan formázhat egy téglalap `AutoShape`-t:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot téglalap típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Eltávolítja a kitöltést a téglalap alakzatról, hogy csak a vonalai legyenek láthatóak.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Alkalmaz formázást a téglalap vonalaira.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Beállítja a téglalap vonalának színét.
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

## **Vázlat hatások alkalmazása a forma vonalaira**

A vázlat hatás egy forma vonalát kézzel rajzoltként jeleníti meg. Használja az [IShape.getLineFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) metódust a vonal beállítások eléréséhez, az [ILineFormat.getSketchFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformat/) metódust a vázlat beállításokhoz, valamint az [ISketchFormat.setSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isketchformat/) metódust a [LineSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linesketchtype/) felsoroló típus értékének kiválasztásához.

Az alábbi Java kód bemutatja, hogyan alkalmazzon egy [LineSketchType.Curved](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linesketchtype/) hatást, hogyan olvassa ki a kifejezetten hozzárendelt értéket, és hogyan távolítsa el a hatást a [LineSketchType.None](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linesketchtype/) használatával:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);

    // Hozzáfér az alakzat vonalformátumához és annak vázlatformátumához.
    ISketchFormat sketchFormat = shape.getLineFormat().getSketchFormat();

    // Alkalmaz egy vázlat hatást.
    sketchFormat.setSketchType(LineSketchType.Curved);

    // Kiolvassa a alakzatra közvetlenül hozzárendelt vázlat hatást.
    int explicitSketchType = sketchFormat.getSketchType();
    System.out.println("Explicit sketch type: " + explicitSketchType);

    // Eltávolítja a vázlat hatást.
    sketchFormat.setSketchType(LineSketchType.None);
} finally {
    presentation.dispose();
}
```

Az [ISketchFormat.getSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isketchformat/) által visszaadott érték az alakzatra közvetlenül beállított formázást jelenti. Ha a vonalformázás egy témából, fő diábol vagy elrendezési diából öröklődik, használja az [ILineFormat.getEffective](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformat/) metódust, érje el az [ILineFormatEffectiveData.getSketchFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilineformateffectivedata/) értéket, és olvassa ki az [ISketchFormatEffectiveData.getSketchType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/isketchformateffectivedata/) értéket. A hatékony érték tükrözi a ténylegesen alkalmazott formázást az öröklődés feloldása után:

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

A három csatlakozási típus lehetősége a következő:

* Kerek
* Metszett
* Lejtett

Alapértelmezés szerint, amikor a PowerPoint két vonalat szöggel (például egy alakzat sarkán) kapcsol össze, a **Round** beállítást használja. Azonban, ha olyan alakzatot rajzol, amelyik éles szögekkel rendelkezik, akkor a **Miter** opciót részesítheti előnyben.

![A csatlakozás stílusa a bemutatóban](join-style-powerpoint.png)

Az alábbi Java kód bemutatja, hogyan hoztak létre három téglalapot (ahogy a fenti képen látható) a Miter, Bevel és Round csatlakozási típus beállítások használatával:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad három automatikus alakzatot téglalap típusban.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Beállítja a kitöltő színt minden téglalap alakzatra.
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    // Beállítja a vonalvastagságot.
    shape1.getLineFormat().setWidth(15);
    shape2.getLineFormat().setWidth(15);
    shape3.getLineFormat().setWidth(15);

    // Beállítja a vonal színét minden téglalaphoz.
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

A PowerPointban a Színátmenetes kitöltés egy formázási beállítás, amely lehetővé teszi, hogy folyamatos színkeverést alkalmazzon egy alakzatra. Például két vagy több színt alkalmazhat úgy, hogy az egyik fokozatosan elhalványul a másikba.

Íme, hogyan alkalmazzon színátmenetes kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Gradient`-ra.
1. Adja hozzá a két kedvenc színét a meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igradientformat/) interfész által biztosított színátmenet‑stop gyűjtemény `add` metódusaival.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon színátmenetes kitöltést egy ellipszisre:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot Ellipszis típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmaz színátmenetes formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Beállítja a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Hozzáad két színátmenet‑állomást.
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

A PowerPointban a Minta kitöltés egy formázási beállítás, amely lehetővé teszi, hogy egy két színből álló mintát – például pontokat, csíkokat, keresztmintákat vagy négyzeteket – alkalmazzon egy alakzatra. Egyedi színeket választhat a minta előtérhez és háttérhez.

Az Aspose.Slides több mint 45 előre definiált mintastílust kínál, amelyeket az alakzatokra alkalmazhat a bemutatók vizuális vonzerejének növelésére. Még egy előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használni kell.

Íme, hogyan alkalmazzon mintás kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy mintastílust a előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternformat/#getBackColor--) értékét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternformat/#getForeColor--) értékét.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon mintás kitöltést egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot téglalap típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Mintára.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Beállítja a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Beállítja a minta háttér- és előtérszíneit.
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

## **Képkitöltés**

A PowerPointban a Képkitöltés egy formázási beállítás, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzat belsejében – hatékonyan a képet használva az alakzat háttérként.

Íme, hogyan használja az Aspose.Slides-et a képkitöltés alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Picture`-re.
1. Állítsa be a képkitöltés módot `Tile`-re (vagy egy másik kívánt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított bemutatót PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájl a következő képpel:

![A lótusz kép](lotus.png)

Az alábbi Java kód bemutatja, hogyan töltse ki egy alakzatot a képpel:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot téglalap típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Beállítja a kitöltés típusát Képre.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja a kép kitöltési módot.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Betölt egy képet és hozzáadja a bemutató erőforrásaihoz.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Beállítja a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A forma képkitöltéssel](picture-fill.png)

### **Kép csempeként textúra**

Ha egy csempézett képet szeretne textúraként beállítani és testreszabni a csempe viselkedését, a következő [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) interfész és a [PictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillformat/) osztály metódusait használhatja:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a képkitöltés módját – legyen az `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Megadja a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen, vagy mindkettőben legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontban) az alakzat eredetétől.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontban) az alakzat eredetétől.
- [setTileScaleX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódminta megmutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett képkitöltéssel és hogyan konfigurálja a csempe beállításait:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Hozzáad egy téglalap automatikus alakzatot.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltés típusát Képre.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Betölti a képet és hozzáadja a bemutató erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // Hozzáadja a képet az alakzathoz.
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

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A csempe opciók](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási beállítás, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín alkalmazásakor nincs színátmenet, textúra vagy minta.

Az Aspose.Slides segítségével egyszínű kitöltést alkalmazni egy alakzatra a következő lépések szerint:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Rendelje hozzá a kívánt kitöltőszínt az alakzathoz.
1. Mentse a módosított bemutatót PPTX fájlként.

Az alábbi Java kód bemutatja, hogyan alkalmazzon egyszínű kitöltést egy téglalapra egy PowerPoint dián:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot téglalap típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Szilárdra.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Beállítja a kitöltő színt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A forma egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egy alakzatra egyszínű, színátmenetes, képi vagy textúra kitöltést alkalmaz, beállíthat átlátszósági szintet is, hogy szabályozza a kitöltés átlátszóságát. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, így a háttér vagy a mögötte lévő objektumok részben láthatóak lesznek.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását az alpha érték módosításával a kitöltés színében. Íme, hogyan teheti meg:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color`-t egy átlátszóságot tartalmazó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a bemutatót.

Az alábbi Java kód bemutatja, hogyan alkalmazzon átlátszó kitöltőszínt egy téglalapra:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy szilárd téglalap automatikus alakzatot.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Hozzáad egy átlátszó téglalap automatikus alakzatot a szilárd alakzat fölött.
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

![Az átlátszó forma](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint bemutatókban. Ez hasznos lehet vizuális elemek meghatározott igazítású vagy tervezési igényű elhelyezésekor.

Az alakzat forgatásához egy dián kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a bemutatót.

Az alábbi Java kód bemutatja, hogyan forgasson egy alakzatot 5 fokkal:

```java
import com.aspose.slides.*;

// Példányosítja a Presentation osztályt, amely egy bemutató fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Lekéri az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Hozzáad egy automatikus alakzatot téglalap típusban.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgatja az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Mentse a PPTX fájlt a lemezre.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A forma forgatása](shape-rotation.png)

## **3D lekerekítési hatások hozzáadása**

Az Aspose.Slides lehetővé teszi, hogy 3D lekerekítési (vagy domborítási) hatásokat alkalmazzon alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D lekerekítési hatások hozzáadásához egy alakzaton kövesse ezeket a lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Konfigurálja az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) beállításait a lekerekítési paraméterek meghatározásához.
1. Mentse a bemutatót.

Az alábbi Java kód megmutatja, hogyan alkalmazzon 3D lekerekítési hatásokat egy alakzatra:

```java
import com.aspose.slides.*;
import java.awt.Color;

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

    // Mentse a bemutatót PPTX fájlként.
    presentation.save("3D_bevel_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D lekerekített hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi, hogy 3D forgatási hatásokat alkalmazzon alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságok konfigurálásával.

3D forgatási hatások alkalmazásához egy alakzaton:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezzen hivatkozást egy diára az indexe alapján.
1. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icamera/#setCameraType-int-) és a [setLightType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
1. Mentse a bemutatót.

Az alábbi Java kód bemutatja, hogyan alkalmazzon 3D forgatási hatásokat egy alakzatra:

```java
import com.aspose.slides.*;

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

    // Mentse a bemutatót PPTX fájlként.
    presentation.save("3D_rotation_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Fekete-fehér megjelenítés vezérlése alakzatoknál**

Az [IShape.setBlackWhiteMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#setBlackWhiteMode-byte-) metódus határozza meg, hogyan jelenik meg egy adott alakzat, amikor a bemutatót fekete-fehér módban tekintik vagy dolgozzák fel. Nem aktiválja a fekete-fehér megjelenítést önmagában, és nem változtatja meg az alakzat kitöltését, vonalát vagy egyéb formázását normál színmódban.

Használjon egy értéket a [BlackWhiteMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/blackwhitemode/) osztályból a kívánt viselkedés kiválasztásához. Például az `Automatic` a renderelő alkalmazást hagyja a konverzió kiválasztásában, a `Gray` és a `LightGray` szürke színezést alkalmaz, a `BlackWhite` csak feketét és fehér színt használ, a `Black` és a `White` egyetlen színt erőltet, a `Color` megőrzi a normál színezést, a `Hidden` kihagyja az alakzatot fekete-fehér módban. A `NotDefined` azt jelenti, hogy nincs alakzat szintű mód beállítva.

Az alábbi Java kód egy színes alakzatot hoz létre, amely fekete-fehér megjelenítési módban szürkének látszik:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    // Tartsa a narancssárga kitöltést színmódban, de a alakzatot szürke színnel jelenítse meg fekete-fehér módban.
    shape.setBlackWhiteMode(BlackWhiteMode.Gray);

    presentation.save("shape_black_white_mode.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Normál színmódban a téglalap megtartja narancssárga kitöltését. Fekete-fehér megjelenítési munkafolyamatban szürke színezést használ, mivel a módja `Gray`-re van állítva. Ez lehetővé teszi, hogy megtartsa a teljes színű diát, miközben egyedi megjelenést definiál a nyomtatáshoz, előnézethez vagy más munkafolyamatokhoz, amelyek tiszteletben tartják a bemutató fekete-fehér megjelenítési beállításait.

## **Formázás visszaállítása**

Az alábbi Java kód megmutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa vissza az összes helykitöltővel rendelkező alakzat pozícióját, méretét és formázását a [LayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/) alapértelmezett beállításaiba:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Visszaállítja a dián lévő minden alakzatot, amelynek helykitöltője az elrendezésen van.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A forma formázása befolyásolja a végső bemutató fájlméretét?**

Csak nagyon kevés mértékben. A beágyazott képek és média foglalják a fájl legtöbb helyét, míg a forma paraméterei, mint a színek, hatások és színátmenetek metaadatként tárolódnak, és gyakorlatilag nem növelik a méretet.

**Hogyan tudom felismerni a dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és hatás beállításokat. Ha minden megfelelő érték megegyezik, tekintse a stílusukat azonosnak, és logikailag csoportosítsa ezeket az alakzatokat, ami leegyszerűsíti a későbbi stíluskezelést.

**Menthetek-e egy egyedi forma stíluskészletet egy külön fájlba, hogy más bemutatókban is használhassam?**

Igen. Tároljon mintaalakzatokat a kívánt stílussal egy sablon diákként vagy .POTX sablonfájlként. Új bemutató létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és ahol szükséges, alkalmazza újra a formázásukat.