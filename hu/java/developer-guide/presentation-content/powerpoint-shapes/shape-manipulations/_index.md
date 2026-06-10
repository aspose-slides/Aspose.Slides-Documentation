---
title: Java-ban a prezentációs alakzatok kezelése
linktitle: Alakzat manipuláció
type: docs
weight: 40
url: /hu/java/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat azonosító lekérdezése
- alakzat alternatív szövege
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-re
- alakzat igazítása
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, szerkeszthet és optimalizálhat alakzatokat az Aspose.Slides for Java-ban, és szállíthat ki nagy teljesítményű PowerPoint prezentációkat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet alakzatokkal dolgozni prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan találhatunk meg egy alakzatot egy dián, klónozhatjuk, eltávolíthatjuk, elrejthetjük, módosíthatjuk a sorrendjét, lekérhetjük az Interop alakzat‑azonosítót, valamint beállíthatunk alternatív szöveget az azonosításhoz és a további feldolgozáshoz.

Továbbá érinti az alakzatok elrendezési formátumainak elérését, egy alakzat SVG‑ként való renderelését, az alakzatok diához való igazítását, valamint a vízszintes és függőleges tükrözéshez használt flip tulajdonságokat. Emellett a cikk egy rövid GYIK‑ot is tartalmaz az alakzat kombinálásáról, a rétegezési sorrendről és az alakzat zárolásáról.

## **Alakzat keresése egy dián**
Ez a téma egy egyszerű technikát mutat be, amely megkönnyíti a fejlesztők számára egy adott alakzat megtalálását egy dián anélkül, hogy annak belső azonosítóját használnák. Fontos tudni, hogy a PowerPoint prezentációs fájloknak nincs módja az alakzatok azonosítására a dián, csak egy belső egyedi azonosítóval. A fejlesztők számára nehéz lehet egy alakzatot a belső azonosítóval megtalálni. Minden diára hozzáadott alakzat rendelkezik valamilyen alternatív szöveggel. Javasoljuk, hogy a fejlesztők alternatív szöveget használjanak egy adott alakzat megtalálásához. Használhatja a Microsoft PowerPoint‑ot az objektumok alternatív szövegének meghatározásához, amelyeket a jövőben módosítani kíván.

Miután beállította egy kívánt alakzat alternatív szövegét, megnyithatja a prezentációt az Aspose.Slides for Java‑val, és végigiterálhat az összes diára hozzáadott alakzaton. Minden iteráció során ellenőrizheti az alakzat alternatív szövegét, és a megfelelő alternatív szöveggel rendelkező alakzat lesz az Ön által keresett. Ennek a technikának a jobb bemutatására létrehoztunk egy metódust, [findShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) amely elvégzi a keresést egy dián, és egyszerűen visszaadja a megtalált alakzatot.

```java
// Példányosítsa a Presentation osztályt, amely a prezentáció fájlt képviseli
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // A megtalálni kívánt alakzat alternatív szövege
    IShape shape = findShape(slide, "Shape1");
    if (shape != null)
    {
        System.out.println("Shape Name: " + shape.getName());
    }
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metódus implementációja egy alakzat megtalálására a dián az alternatív szöveg alapján
public static IShape findShape(ISlide slide, String alttext)
{
    // Az összes alakzat bejárása a dián belül
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Ha a dián lévő alternatív szöveg megegyezik a keresettel, akkor
        // Visszaadja az alakzatot
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Alakzat klónozása**
Alakzat klónozása egy diára az Aspose.Slides for Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Szerezze be egy dia referenciáját az indexének megadásával.
1. Nyissa meg a forrásdián lévő alakzatgyűjteményt.
1. Adjon hozzá egy újdia‑t a prezentációhoz.
1. Klónozza az alakzatokat a forrásdián lévő alakzatgyűjteményből az újdia‑ba.
1. Mentse el a módosított prezentációt PPTX fájlként.

Az alábbi példa egy csoportos alakzatot ad egy diához.

```java
// Presentation osztály példányosítása
Presentation pres = new Presentation("Source Frame.pptx");
try {
    IShapeCollection sourceShapes = pres.getSlides().get_Item(0).getShapes();
    ILayoutSlide blankLayout = pres.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destSlide = pres.getSlides().addEmptySlide(blankLayout);
    IShapeCollection destShapes = destSlide.getShapes();
    destShapes.addClone(sourceShapes.get_Item(1), 50, 150 + sourceShapes.get_Item(0).getHeight());
    destShapes.addClone(sourceShapes.get_Item(2));
    destShapes.insertClone(0, sourceShapes.get_Item(0), 50, 150);

    // PPTX fájl írása a lemezre
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat eltávolítása**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy bármely alakzatot eltávolítsanak. Egy alakzat eltávolításához egy diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Nyissa meg az első diát.
1. Keresse meg a konkrét AlternativeText‑el rendelkező alakzatot.
1. Távolítsa el az alakzatot.
1. Mentse a fájlt a lemezen.

```java
// Presentation objektum létrehozása
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Téglalap típusú autóalakzat hozzáadása
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String altText = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(0);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            sld.getShapes().remove(ashp);
        }
    }

    // Prezentáció mentése a lemezre
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat elrejtése**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy bármely alakzatot elrejtsenek. Egy alakzat elrejtéséhez egy diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Nyissa meg az első diát.
1. Keresse meg a konkrét AlternativeText‑el rendelkező alakzatot.
1. Rejtse el az alakzatot.
1. Mentse a fájlt a lemezen.

```java
// A PPTX-et képviselő Presentation osztály példányosítása
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Téglalap típusú autóalakzat hozzáadása
    sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);

    String alttext = "User Defined";
    int iCount = sld.getShapes().size();
    for (int i = 0; i < iCount; i++)
    {
        AutoShape ashp = (AutoShape)sld.getShapes().get_Item(i);
        if (alttext.equals(ashp.getAlternativeText()))
        {
            ashp.setHidden(true);
        }
    }

    // Prezentáció mentése a lemezre
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat sorrendjének módosítása**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára az alakzatok újrarendezését. Az újrarendezés határozza meg, hogy melyik alakzat van elöl és melyik hátul. Egy alakzat újrarendezéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá egy alakzatot.
1. Adjon szöveget az alakzat szövegkeretéhez.
1. Adjon hozzá egy másik alakzatot azonos koordinátákkal.
1. Rendezzük át az alakzatokat.
1. Mentse a fájlt a lemezen.

```java
Presentation pres = new Presentation("ChangeShapeOrder.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape shp3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
    shp3.getFillFormat().setFillType(FillType.NoFill);
    shp3.addTextFrame(" ");

    IParagraph para = shp3.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = para.getPortions().get_Item(0);
    portion.setText("Watermark Text Watermark Text Watermark Text");

    shp3 = slide.getShapes().addAutoShape(ShapeType.Triangle, 200, 365, 400, 150);

    slide.getShapes().reorder(2, shp3);

    pres.save("Reshape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Interop alakzat‑azonosító lekérdezése**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy egyedi alakzatazonosítót kapjanak a dia‑környezetben, szemben a [getUniqueId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getUniqueId--) módszerrel, amely egyedi azonosítót ad a teljes prezentációra vonatkozóan. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) metódust hozzáadták az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape) interfészhez és a [Shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Shape) osztályhoz. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getOfficeInteropShapeId--) metódus által visszaadott érték megfelel a Microsoft.Office.Interop.PowerPoint.Shape objektum Id értékének. Az alábbiakban egy példakód látható.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Egyedi alakzat azonosító lekérése a dia környezetben
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Alternatív szöveg beállítása egy alakzathoz**
Az Aspose.Slides for Java lehetővé teszi a fejlesztők számára, hogy bármely alakzat AlternateText‑ét beállítsák.
A prezentációban lévő alakzatok megkülönböztethetők a [AlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) vagy a [Shape Name](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setName-java.lang.String-) metódussal.
A [setAlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) és a [getAlternativeText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#getAlternativeText--) metódusok olvashatók és beállíthatók az Aspose.Slides, illetve a Microsoft PowerPoint segítségével.
Ezzel a módszerrel címkézhet alakzatot, és különféle műveleteket végezhet, például alakzat eltávolítása,
alakzat elrejtése vagy alakzatok újrarendezése egy dián.
Az AlternateText beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Presentation) osztályból.
1. Nyissa meg az első diát.
1. Adjon hozzá bármilyen alakzatot a diához.
1. Végezzen el némi munkát az újonnan hozzáadott alakzattal.
1. Járja be az alakzatokat a kereséshez.
1. Állítsa be az AlternativeText‑et.
1. Mentse a fájlt a lemezen.

```java
// Presentation osztály példányosítása, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Téglalap típusú autóalakzat hozzáadása
    IShape shp1 = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
    IShape shp2 = sld.getShapes().addAutoShape(ShapeType.Moon, 160, 40, 150, 50);
    shp2.getFillFormat().setFillType(FillType.Solid);
    shp2.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    for (int i = 0; i < sld.getShapes().size(); i++)
    {
        AutoShape shape = (AutoShape) sld.getShapes().get_Item(i);
        if (shape != null)
        {
            shape.setAlternativeText("User Defined");
        }
    }

    // Prezentáció mentése a lemezre
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Elrendezési formátumok elérése egy alakzathoz**
Az Aspose.Slides for Java egyszerű API‑t biztosít az alakzatok elrendezési formátumainak eléréséhez. Ez a cikk bemutatja, hogyan érhetők el ezek a formátumok.

Az alábbi mintakód látható.

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (ILayoutSlide layoutSlide : pres.getLayoutSlides())
    {
        for (IShape shape : layoutSlide.getShapes())
        {
            IFillFormat fillFormats = shape.getFillFormat();
            ILineFormat lineFormats = shape.getLineFormat();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat renderelése SVG‑ként**
Az Aspose.Slides for Java most már támogatja egy alakzat SVG‑ként való renderelését. A [writeAsSvg](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) metódus (és annak túlterhelése) hozzá lett adva a [Shape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/Shape) osztályhoz és az [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape) interfészhez. Ez a metódus lehetővé teszi, hogy az alakzat tartalmát SVG fájlként mentse. Az alábbi kódrészlet bemutatja, hogyan exportálható egy dia alakzata SVG fájlként.

```java
Presentation pres = new Presentation("TestExportShapeToSvg.pptx");
try {
    FileOutputStream stream = new FileOutputStream("SingleShape.svg");
    try {
        pres.getSlides().get_Item(0).getShapes().get_Item(0).writeAsSvg(stream);
    } finally {
        if (stream != null) stream.close();
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat igazítása**
Az Aspose.Slides lehetővé teszi az alakzatok igazítását a dia margója vagy egymáshoz viszonyítva. Ehhez hozzá lett adva a túlterhelt [SlidesUtil.alignShape()](https://reference.aspose.com/slides/hu/java/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) metódus. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ShapesAlignmentType) felsorolás határozza meg a lehetséges igazítási lehetőségeket.

**Példa 1**

Az alábbi forráskód a 1, 2 és 4 indexű alakzatokat igazítja a dia felső szélén.

```java
Presentation pres = new Presentation("example.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IShape shape1 = slide.getShapes().get_Item(1);
    IShape shape2 = slide.getShapes().get_Item(2);
    IShape shape3 = slide.getShapes().get_Item(4);
    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, pres.getSlides().get_Item(0), new int[]
    {
        slide.getShapes().indexOf(shape1),
        slide.getShapes().indexOf(shape2),
        slide.getShapes().indexOf(shape3)
    });
} finally {
    if (pres != null) pres.dispose();
}
}
```

**Példa 2**

Az alábbi példa megmutatja, hogyan igazítható a teljes alakzatgyűjtemény a gyűjtemény legalsó alakzatához viszonyítva.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Flip tulajdonságok**

Az Aspose.Slides‑ben a [ShapeFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/) osztály biztosítja a vízszintes és függőleges tükrözés vezérlését az `flipH` és `flipV` tulajdonságokkal. Mindkét tulajdonság `byte` típusú, ahol az `1` jelzi a tükrözést, a `0` a tükrözés hiányát, a `-1` pedig az alapértelmezett viselkedést. Ezek az értékek a shape‑[Frame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getFrame--)‑jéből érhetők el.

A flip beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapeframe/) példányt hozunk létre a shape aktuális pozíciójával és méretével, a kívánt `flipH` és `flipV` értékekkel, valamint a forgási szöggel. Ennek a példánynak a shape‑[Frame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ishape/#getFrame--)‑hez való hozzárendelése és a prezentáció mentése alkalmazza a tükörtranszformációkat és elmenti azokat a kimeneti fájlba.

Tegyük fel, hogy van egy sample.pptx fájl, amelynek az első diáján egyetlen shape van az alapértelmezett flip beállításokkal, az alábbiak szerint.

![The shape to be flipped](shape_to_be_flipped.png)

Az alábbi kódrészlet lekéri a shape aktuális flip tulajdonságait, és mindkét irányban tükrözi azt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // A shape vízszintes tükrözési tulajdonságának lekérdezése.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // A shape függőleges tükrözési tulajdonságának lekérdezése.
    byte verticalFlip = shape.getFrame().getFlipV();
    System.out.println("Vertical flip: " + verticalFlip);

    float x = shape.getFrame().getX();
    float y = shape.getFrame().getY();
    float width = shape.getFrame().getWidth();
    float height = shape.getFrame().getHeight();
    byte flipH = NullableBool.True; // Vízszintesen tükröz.
    byte flipV = NullableBool.True; // Vízszintesen tükröz.
    float rotation = shape.getFrame().getRotation();

    shape.setFrame(new ShapeFrame(x, y, width, height, flipH, flipV, rotation));

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The flipped shape](flipped_shape.png)

## **GYIK**

**Kombinálhatok-e alakzatokat (unió/kereszteződés/kivonás) egy dián, mint egy asztali szerkesztőben?**

Nincs beépített Boolean művelet API. Megközelíthető úgy, hogy saját maga állítja össze a kívánt körvonalat – például kiszámítja a keletkező geometriát (a [GeometryPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/geometrypath/) segítségével) és létrehoz egy új shape‑ot ezzel a kontúrral, opcionálisan eltávolítva az eredetieket.

**Hogyan szabályozhatom a rétegezési sorrendet (z‑order), hogy egy shape mindig „felül” legyen?**

Módosítsa a beszúrási/mozgatási sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/baseslide/#getShapes--) gyűjteményében. A kiszámítható eredmény érdekében véglegesítse a z‑order‑t minden egyéb dia‑módosítás után.

**Le tudom‑zárni egy shape‑ot, hogy a felhasználók ne szerkeszthessék PowerPoint‑ban?**

Igen. Állítson be [shape‑szintű védelmi zászlókat](/slides/hu/java/applying-protection-to-presentation/) (például kiválasztás, mozgás, átméretezés, szöveg szerkesztésének zárolása). Szükség esetén tükrözze a korlátozásokat a masteren vagy elrendezésen. Ez UI‑szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, például [csak‑olvasás ajánlás vagy jelszavak](/slides/hu/java/password-protected-presentation/).