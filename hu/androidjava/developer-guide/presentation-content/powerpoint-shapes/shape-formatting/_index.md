---
title: PowerPoint alakzatok formázása Androidon
linktitle: Alakzat formázása
type: docs
weight: 20
url: /hu/androidjava/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszósága
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázzák a PowerPoint alakzatokat Androidon az Aspose.Slides használatával – állítsa be a kitöltés, vonal és effektus stílusait PPT, PPTX és ODP fájlokhoz precízen és teljes ellenőrzéssel."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a körvonalak módosításával vagy effektusok alkalmazásával. Ezenkívül alakzatokat is formázhat olyan beállítások megadásával, amelyek szabályozzák, hogyan töltik ki a belsejüket.

![format-shape-powerpoint](format-shape-powerpoint.png)

Az Aspose.Slides for Android via Java interfészeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a beállításokkal.

## **Vonalak formázása**

Az Aspose.Slides használatával egyedi vonalstílust adhat meg egy alakzathoz. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [line style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linestyle/) attribútumát.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a vonal [dash style](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/linedashstyle/) attribútumát.
1. Állítsa be a vonal színét az alakzathoz.
1. Mentse a módosított prezentációt PPTX fájlként.

A következő kód bemutatja, hogyan formázzunk egy téglalap `AutoShape`-t:

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
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

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The formatted lines in the presentation](formatted-lines.png)

## **Csatlakozási stílusok formázása**

A három csatlakozási típus lehetőség a következő:

* Round
* Miter
* Bevel

Alapértelmezés szerint, amikor a PowerPoint két vonalat kapcsol össze egy szögben (például egy alakzat sarkán), a **Round** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, a **Miter** opciót részesítheti előnyben.

![The join style in the presentation](join-style-powerpoint.png)

Az alábbi Java kód bemutatja, hogyan hoztak létre három téglalapot (az előző képen látható módon) a Miter, Bevel és Round csatlakozási típus-beállítások használatával:

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá három Rectangle típusú automatikus alakzatot.
    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 75);
    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 20, 150, 75);
    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 135, 150, 75);

    // Állítsa be minden téglalap alakzat kitöltőszínét.
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

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Gradient kitöltés**

A PowerPointban a Gradient Fill egy formázási lehetőség, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt adhat meg úgy, hogy az egyik fokozatosan átmenjen a másikba.

Íme, hogyan alkalmazzon gradient kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Gradient`-ra.
1. Adja hozzá a kívánt két színt a meghatározott pozíciókkal a gradient stop gyűjtemény `add` metódusainak segítségével, amelyet az [IGradientFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/igradientformat/) interfész biztosít.
1. Mentse a módosított prezentációt PPTX fájlként.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Ellipse típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Alkalmazza a gradient formázást az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Állítsa be a gradient irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Adjon hozzá két gradient stopot.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The ellipse with gradient fill](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Pattern Fill egy formázási lehetőség, amely lehetővé teszi, hogy kétszínű mintát (például pontot, csíkot, keresztmintát vagy csekköt) alkalmazzon egy alakzatra. Testreszabhatja a minta elő- és háttérszínét.

Az Aspose.Slides több mint 45 előre definiált minta stílust biztosít, amelyet az alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növelése érdekében. Még előre definiált minta kiválasztása után is megadhatja a pontos színeket.

Íme, hogyan alkalmazzon minta kitöltést egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Pattern`-re.
1. Válasszon egy minta stílust az előre definiált opciók közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternformat/#getBackColor--) színét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/patternformat/#getForeColor--) színét.
1. Mentse a módosított prezentációt PPTX fájlként.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
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

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The rectangle with pattern fill](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill egy formázási lehetőség, amely lehetővé teszi egy kép beillesztését egy alakzatba – a képet a forma háttérként használva.

Íme, hogyan használja az Aspose.Slides-t kép kitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Picture`-ra.
1. Állítsa be a kép kitöltés módját `Tile`-re (vagy egy másik preferált módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ippimage/) objektumot a használni kívánt képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájl a következő képpel:

![The lotus picture](lotus.png)

Az alábbi Java kód bemutatja, hogyan töltsön ki egy alakzatot a képpel:

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
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

    // Töltsön be egy képet, és adja hozzá a prezentáció erőforrásaihoz.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Állítsa be a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape with picture fill](picture-fill.png)

### **Kép csempézés textúraként**

Ha egy csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, az alábbi [IPictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/) interfész és [PictureFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillformat/) osztály metódusait használhatja:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): A kép kitöltés módját állítja be – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Meghatározza a csempék elrendezését az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkét irányban legyen-e tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulópontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulópontjától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Meghatározza a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Meghatározza a csempe függőleges méretezését százalékban.

Az alábbi kódrészlet mutatja, hogyan adjon hozzá egy téglalap alakzatot csempézett kép kitöltéssel, és állítsa be a csempe opciókat:

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy téglalap automatikus alakzatot.
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

    // Állítsa be a kép kitöltés módját és a csempézés tulajdonságait.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The tile options](tile-options.png)

## **Egyetlen színű kitöltés**

A PowerPointban a Solid Color Fill egy formázási lehetőség, amely egyetlen, egységes színnel tölti ki az alakzatot. Ez az egyszerű háttérszín alkalmazásra kerül anélkül, hogy gradienteket, textúrákat vagy mintákat tartalmazna.

Az alábbi lépések segítenek egyetlen színű kitöltés alkalmazásában egy alakzatra az Aspose.Slides használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Adja meg a kívánt kitöltő színt az alakzatnak.
1. Mentse a módosított prezentációt PPTX fájlként.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Állítsa be a kitöltés típusát Solid-re.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Állítsa be a kitöltőszínt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape with solid color fill](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egy alakzatra egyszínű, gradient, kép vagy textúra kitöltést alkalmaz, beállíthat egy átlátszósági szintet a kitöltés átlátszatlanságának szabályozására. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve a háttér vagy az alatta lévő objektumok részleges megjelenését.

Az Aspose.Slides lehetővé teszi az átlátszósági szint beállítását a kitöltés színének alfa komponensének módosításával. Íme, hogyan teheti ezt:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Használja a `Color` osztályt egy átlátszó szín definiálásához (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy szilárd téglalap automatikus alakzatot.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Adjon hozzá egy átlátszó téglalap automatikus alakzatot a szilárd alakzat felett.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent shape](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi alakzatok forgatását PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek pontos elhelyezéséhez vagy tervezési igényekhez.

Az alakzat forgatásához a dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat forgatási tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```java
// Példányosítsa a Presentation osztályt, amely egy prezentációfájlt reprezentál.
Presentation presentation = new Presentation();
try {
    // Szerezze meg az első diát.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy Rectangle típusú automatikus alakzatot.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Forgassa el az alakzatot 5 fokkal.
    shape.setRotation(5);

    // Mentse a PPTX fájlt a lemezen.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The shape rotation](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D rézsút hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságait a kívánt rézsút beállításokhoz.
1. Mentse a prezentációt.

```java
// Hozzon létre egy példányt a Presentation osztályból.
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjon hozzá egy alakzatot a diára.
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

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/threedformat/) tulajdonságainak konfigurálásával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.
1. Szerezze be egy dia hivatkozását az indexe alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iautoshape/) elemet a diára.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icamera/#setCameraType-int-) és [setLightType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
1. Mentse a prezentációt.

```java
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

## **Formázás visszaállítása**

Az alábbi Java kód bemutatja, hogyan állítsa vissza egy dia formázását, és hogyan állítsa alapértelmezett értékekre a [LayoutSlide](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/layoutslide/) helyőrzőkkel rendelkező összes alakzat helyzetét, méretét és formázását:

```java
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

**Bev Impactálja az alakzatok formázása a végleges prezentáció fájlméretét?**

Csak minimálisan. A beágyazott képek és médiafájlok foglalják a fájl legnagyobb részét, míg az alakzati paraméterek (színek, effektusok, gradientek) metaadatként tárolódnak, és szinte nem növelik a méretet.

**Hogyan tudom felismerni az azonos formázású alakzatokat egy dián, hogy csoportosíthassam őket?**

Hasonlítsa össze minden alakzat kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effekt beállítások. Ha minden érték megegyezik, tekintse a stílusokat azonosnak, és logikailag csoportosítsa az alakzatokat, ami megkönnyíti a későbbi stíluskezelést.

**Menthetek egy egyedi alakzatstílus-készletet külön fájlba, hogy más prezentációkban újra felhasználjam?**

Igen. Tárolja a kívánt stílusokkal rendelkező mintaalakzatokat egy sablon diákkészletben vagy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, és alkalmazza a formázásukat a kívánt helyeken.