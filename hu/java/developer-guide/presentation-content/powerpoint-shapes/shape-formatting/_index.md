---
title: PowerPoint alakzatok formázása Java-ban
linktitle: Alakzatformázás
type: docs
weight: 20
url: /hu/java/shape-formatting/
keywords:
- alakzat formázása
- vonal formázása
- csatlakozási stílus formázása
- színátmenetes kitöltés
- minta kitöltés
- kép kitöltés
- textúra kitöltés
- egyszínű kitöltés
- alakzat átlátszóság
- alakzat forgatása
- 3D rézsút hatás
- 3D forgatási hatás
- formázás visszaállítása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan formázhatja a PowerPoint alakzatokat Java-ban az Aspose.Slides használatával – állítsa be a kitöltés, vonal és effektus stílusait PPT, PPTX és ODP fájlokhoz precízen és teljes kontrollal."
---
## **Bevezetés**

A PowerPointban alakzatokat adhat hozzá a diákhoz. Mivel az alakzatok vonalakból állnak, formázhatja őket a vonalvonalak módosításával vagy effektusok alkalmazásával. Emellett az alakzatok formázása során megadhatja a belső kitöltés vezérlő beállításait.

![alakzat formázása PowerPointban](format-shape-powerpoint.png)

Az Aspose.Slides for Java interfészeket és metódusokat biztosít, amelyek lehetővé teszik az alakzatok formázását a PowerPointban elérhető ugyanazokkal a lehetőségekkel.

## **Vonalak formázása**

Az Aspose.Slides segítségével egy alakzathoz egyedi vonalstílust adhat meg. Az alábbi lépések mutatják a folyamatot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [vonalstílus](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linestyle/) tulajdonságát.
1. Állítsa be a vonalvastagságot.
1. Állítsa be a vonal [vonalvonalminta](https://reference.aspose.com/slides/hu/java/com.aspose.slides/linedashstyle/) tulajdonságát.
1. Állítsa be az alakzat vonalszínét.
1. Mentse el a módosított prezentációt PPTX fájlként.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy Rectangle típusú auto alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 75);

    // Beállítja a téglalap alakzat kitöltőszínét.
    shape.getFillFormat().setFillType(FillType.NoFill);

    // Formázást alkalmaz a téglalap vonalaira.
    shape.getLineFormat().setStyle(LineStyle.ThickThin);
    shape.getLineFormat().setWidth(7);
    shape.getLineFormat().setDashStyle(LineDashStyle.Dash);

    // Beállítja a téglalap vonalának színét.
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    // A PPTX fájl mentése lemezre.
    presentation.save("formatted_lines.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![A formázott vonalak a prezentációban](formatted-lines.png)

## **Csatlakozási stílusok formázása**

Az alábbiak a három csatlakozási típuslehetőség:

* Kerek
* Fazett
* Levágott

Alapértelmezés szerint, amikor a PowerPoint két vonalat szögnél (például egy alakzat sarkán) fűz össze, a **Kerek** beállítást használja. Ha azonban éles szögekkel rendelkező alakzatot rajzol, előnyben részesítheti a **Fazett** opciót.

![A csatlakozási stílus a prezentációban](join-style-powerpoint.png)

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Három Rectangle típusú auto alakzatot ad hozzá.
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

    // Beállítja a vonalvastagságot.
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

    // A PPTX fájl mentése lemezre.
    presentation.save("join_styles.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Színátmenetes kitöltés**

A PowerPointban a Gradient Fill egy formázási beállítás, amely lehetővé teszi, hogy folyamatos színátmenetet alkalmazzon egy alakzatra. Például két vagy több színt adhat hozzá úgy, hogy az egyik fokozatosan elhalványul a másikba.

Íme, hogyan alkalmazhat színátmenetes kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Gradient`-ra.
1. Adja hozzá a kívánt két színt a meghatározott pozíciókkal a [IGradientFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/igradientformat/) interfész által biztosított gradient stop gyűjtemény `add` metódusaival.
1. Mentse el a módosított prezentációt PPTX fájlként.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy Ellipse típusú auto alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 50, 50, 150, 75);

    // Színátmenetes formázást alkalmaz az ellipszisre.
    shape.getFillFormat().setFillType(FillType.Gradient);
    shape.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);

    // Beállítja a színátmenet irányát.
    shape.getFillFormat().getGradientFormat().setGradientDirection(GradientDirection.FromCorner2);

    // Két színátmeneti pontot ad hozzá.
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)1.0, PresetColor.Purple);
    shape.getFillFormat().getGradientFormat().getGradientStops().addPresetColor((float)0, PresetColor.Red);

    // A PPTX fájl mentése lemezre.
    presentation.save("gradient_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Az ellipszis színátmenetes kitöltéssel](gradient-fill.png)

## **Minta kitöltés**

A PowerPointban a Pattern Fill egy formázási beállítás, amely lehetővé teszi, hogy két színű mintát (például pontokat, csíkokat, keresztmintákat vagy kockákat) alkalmazzon egy alakzatra. Egyéni színeket választhat a minta előtér és háttér színéhez.

Az Aspose.Slides több mint 45 előre definiált minta stílust biztosít, amelyeket alakzatokra alkalmazhat a prezentációk vizuális vonzerejének növeléséhez. Az előre definiált minta kiválasztása után is megadhatja a pontos színeket, amelyeket használjon.

Íme, hogyan alkalmazhat minta kitöltést egy alakzatra az Aspose.Slides segítségével:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Pattern`-ra.
1. Válasszon egy minta stílust az előre definiált lehetőségek közül.
1. Állítsa be a minta [Background Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/patternformat/#getBackColor--) színét.
1. Állítsa be a minta [Foreground Color](https://reference.aspose.com/slides/hu/java/com.aspose.slides/patternformat/#getForeColor--) színét.
1. Mentse el a módosított prezentációt PPTX fájlként.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy Rectangle típusú auto alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Pattern-re.
    shape.getFillFormat().setFillType(FillType.Pattern);

    // Beállítja a minta stílusát.
    shape.getFillFormat().getPatternFormat().setPatternStyle(PatternStyle.Trellis);

    // Beállítja a minta háttér- és előtérszínét.
    shape.getFillFormat().getPatternFormat().getBackColor().setColor(Color.LIGHT_GRAY);
    shape.getFillFormat().getPatternFormat().getForeColor().setColor(Color.YELLOW);

    // A PPTX fájl mentése lemezre.
    presentation.save("pattern_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![A téglalap minta kitöltéssel](pattern-fill.png)

## **Kép kitöltés**

A PowerPointban a Picture Fill egy formázási beállítás, amely lehetővé teszi, hogy egy képet helyezzen el egy alakzatban – ezzel a képet alakzat háttérként használja.

Íme, hogyan használhatja az Aspose.Slides-et kép kitöltés alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Picture`-ra.
1. Állítsa be a kép kitöltés módját `Tile`-ra (vagy egy másik kedvelt módra).
1. Hozzon létre egy [IPPImage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ippimage/) objektumot a kívánt képből.
1. Adja át a képet az `ISlidesPicture.setImage` metódusnak.
1. Mentse el a módosított prezentációt PPTX fájlként.

Tegyük fel, hogy van egy "lotus.png" fájlunk a következő képpel:

![A lotus kép](lotus.png)

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy Rectangle típusú auto alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 255, 130);
    
    // Beállítja a kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Beállítja a kép kitöltés módját.
    shape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Tile);

    // Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
    IImage image = Images.fromFile("lotus.png");
    IPPImage picture = presentation.getImages().addImage(image);
    image.dispose();

    // Beállítja a képet.
    shape.getFillFormat().getPictureFillFormat().getPicture().setImage(picture);

    // A PPTX fájl mentése lemezre.
    presentation.save("picture_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Az alakzat kép kitöltéssel](picture-fill.png)

### **Kép csempézése textúraként**

Ha csempézett képet szeretne textúraként beállítani, és testre szabni a csempézés viselkedését, a következő [IPictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/) interfész és [PictureFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillformat/) osztály metódusait használhatja:

- [setPictureFillMode](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-): Beállítja a kép kitöltés módját – `Tile` vagy `Stretch`.
- [setTileAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileAlignment-byte-): Meghatározza a csempék igazítását az alakzaton belül.
- [setTileFlip](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileFlip-int-): Szabályozza, hogy a csempe vízszintesen, függőlegesen vagy mindkettőre legyen tükrözve.
- [setTileOffsetX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileOffsetX-float-): Beállítja a csempe vízszintes eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileOffsetY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileOffsetY-float-): Beállítja a csempe függőleges eltolását (pontban) az alakzat kiindulási pontjától.
- [setTileScaleX](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileScaleX-float-): Megadja a csempe vízszintes méretezését százalékban.
- [setTileScaleY](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipicturefillformat/#setTileScaleY-float-): Megadja a csempe függőleges méretezését százalékban.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Egy Rectangle típusú auto alakzatot ad hozzá.
    IAutoShape shape = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 190, 95);

    // Beállítja az alakzat kitöltés típusát Picture-re.
    shape.getFillFormat().setFillType(FillType.Picture);

    // Betölt egy képet és hozzáadja a prezentáció erőforrásaihoz.
    IImage sourceImage = Images.fromFile("lotus.png");
    IPPImage presentationImage = presentation.getImages().addImage(sourceImage);
    sourceImage.dispose();

    // A képet hozzárendeli az alakzathoz.
    IPictureFillFormat pictureFillFormat = shape.getFillFormat().getPictureFillFormat();
    pictureFillFormat.getPicture().setImage(presentationImage);

    // Beállítja a kép kitöltés módját és a csempézés tulajdonságait.
    pictureFillFormat.setPictureFillMode(PictureFillMode.Tile);
    pictureFillFormat.setTileOffsetX(-32);
    pictureFillFormat.setTileOffsetY(-32);
    pictureFillFormat.setTileScaleX(50);
    pictureFillFormat.setTileScaleY(50);
    pictureFillFormat.setTileAlignment(RectangleAlignment.BottomRight);
    pictureFillFormat.setTileFlip(TileFlip.FlipBoth);

    // A PPTX fájl mentése lemezre.
    presentation.save("tile.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![A csempe beállításai](tile-options.png)

## **Egyszínű kitöltés**

A PowerPointban az Egyszínű kitöltés egy formázási beállítás, amely egy alakzatot egyetlen, egységes színnel tölti ki. Ez az egyszerű háttérszín alkalmazásra kerül anélkül, hogy gradientek, textúrák vagy minták lennének.

Az egyszínű kitöltés alkalmazásához egy alakzatra az Aspose.Slides használatával kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. Rendeljen egy kedvelt kitöltési színt az alakzathoz.
1. Mentse el a módosított prezentációt PPTX fájlként.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy Rectangle típusú auto alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Beállítja a kitöltés típusát Solid-ra.
    shape.getFillFormat().setFillType(FillType.Solid);

    // Beállítja a kitöltőszínt.
    shape.getFillFormat().getSolidFillColor().setColor(Color.YELLOW);

    // A PPTX fájl mentése lemezre.
    presentation.save("solid_color_fill.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Az alakzat egyszínű kitöltéssel](solid-color-fill.png)

## **Átlátszóság beállítása**

A PowerPointban, ha egyszínű, színátmenetes, kép vagy textúra kitöltést alkalmaz alakzatokra, beállíthat egy átlátszósági szintet is a kitöltés átlátszatlanságának szabályozásához. A magasabb átlátszósági érték átlátszóbbá teszi az alakzatot, lehetővé téve a háttér vagy az alatta lévő objektumok részleges megjelenését.

Az Aspose.Slides lehetővé teszi, hogy az átlátszósági szintet a kitöltés színének alfa értékének módosításával állítsa be. Íme, hogyan lehet ezt megtenni:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be a [FillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) értékét `Solid`-ra.
1. `Color` használatával definiáljon egy átlátszó színt (az `alpha` komponens szabályozza az átlátszóságot).
1. Mentse a prezentációt.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy szilárd téglalap auto alakzatot ad hozzá.
    IAutoShape solidShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Egy átlátszó téglalap auto alakzatot ad hozzá a szilárd alakzat fölé.
    IAutoShape transparentShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 150, 75);
    transparentShape.getFillFormat().setFillType(FillType.Solid);
    transparentShape.getFillFormat().getSolidFillColor().setColor(new Color(255, 255, 0, 204));

    // A PPTX fájl mentése lemezre.
    presentation.save("shape_transparency.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Az átlátszó alakzat](shape-transparency.png)

## **Alakzatok forgatása**

Az Aspose.Slides lehetővé teszi az alakzatok forgatását a PowerPoint prezentációkban. Ez hasznos lehet a vizuális elemek elhelyezésekor, ha speciális igazításra vagy tervezési igényekre van szükség.

Az alakzat egy dián való forgatásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat rotációs tulajdonságát a kívánt szögre.
1. Mentse a prezentációt.

```java
// A Presentation osztály példányosítása, amely egy prezentációs fájlt képvisel.
Presentation presentation = new Presentation();
try {
    // Az első diát lekéri.
    ISlide slide = presentation.getSlides().get_Item(0);

    // Egy Rectangle típusú auto alakzatot ad hozzá.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 75);

    // Az alakzatot 5 fokkal forgatja.
    shape.setRotation(5);

    // A PPTX fájl mentése lemezre.
    presentation.save("shape_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Az alakzat forgatása](shape-rotation.png)

## **3D rézsút hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D rézsút hatások alkalmazását az alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságok beállításával.

3D rézsút hatások hozzáadásához egy alakzathoz kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Állítsa be az alakzat [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságait a rézsút beállításainak meghatározásához.
1. Mentse a prezentációt.

```java
// Hozzon létre egy példányt a Presentation osztályból.
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

![A 3D rézsút hatás](3D-bevel-effect.png)

## **3D forgatási hatások hozzáadása**

Az Aspose.Slides lehetővé teszi 3D forgatási hatások alkalmazását az alakzatokra a [ThreeDFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/threedformat/) tulajdonságok beállításával.

3D forgatás alkalmazásához egy alakzatra:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
1. Szerezzen referenciát egy diára index alapján.
1. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iautoshape/) elemet a diához.
1. Használja a [setCameraType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icamera/#setCameraType-int-) és [setLightType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ilightrig/#setLightType-int-) metódusokat a 3D forgatás meghatározásához.
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

![A 3D forgatási hatás](3D-rotation-effect.png)

## **Formázás visszaállítása**

Az alábbi Java kód bemutatja, hogyan állítható vissza egy dia formázása, és hogyan állítható vissza az összes helyőrzővel rendelkező alakzat pozíciója, mérete és formázása a [LayoutSlide](https://reference.aspose.com/slides/hu/java/com.aspose.slides/layoutslide/) alapértelmezett beállításaival:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // Visszaállítja a dián lévő minden alakzatot, amelynek a layouton helyőrzője van.
        slide.reset();
    }
    presentation.save("reset_formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **GYIK**

**A formázott alakzatok befolyásolják a végső prezentáció fájlméretét?**

Csak nagyon kevés mértékben. A beágyazott képek és média foglalja a fájl legnagyobb részét, míg az alakzatparaméterek, például színek, effektek és színátmenetek metaadatként kerülnek tárolásra, és gyakorlatilag nem növelik jelentősen a méretet.

**Hogyan tudom felismerni egy dián azonos formázású alakzatokat, hogy csoportosíthassam őket?**

Hasonlítsa össze az egyes alakzatok kulcsfontosságú formázási tulajdonságait – kitöltés, vonal és effektus beállításait. Ha minden megfelelő érték megegyezik, tekintse a stílusokat azonosnak és logikailag csoportosítsa ezeket az alakzatokat, ami egyszerűsíti a későbbi stíluskezelést.

**Menthetek-e egy egyéni alakzatstílusokból álló halmazt egy külön fájlba, hogy más prezentációkban is újra felhasználjam?**

Igen. Tároljon mintaalakzatokat a kívánt stílusokkal egy sablon diáikat vagy egy .POTX sablonfájlban. Új prezentáció létrehozásakor nyissa meg a sablont, klónozza a szükséges stílusú alakzatokat, majd alkalmazza a formázásukat a kívánt helyeken.