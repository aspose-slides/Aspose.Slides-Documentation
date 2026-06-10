---
title: Prezentációs alakzatok kezelése Androidon
linktitle: Alakzat manipuláció
type: docs
weight: 40
url: /hu/androidjava/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- Interop alakzat azonosito lekerese
- alakzat alternativ szovege
- alakzat elrendesitesi formatumai
- alakzat SVG-kent
- alakzat SVG-be
- alakzat igazitasa
- PowerPoint
- prezentacio
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat letre, szerkeszthet es optimalizalhat alakzatokat az Aspose.Slides for Android via Java segitsegevel, es szallithat nagy teljesitmenyu PowerPoint prezentaciokat."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan lehet alakzatokkal dolgozni prezentációkban az Aspose.Slides használatával. Bemutatja, hogyan találhatunk meg egy alakzatot egy dián, klónozhatjuk, eltávolíthatjuk, elrejthetjük, módosíthatjuk a sorrendjét, lekérhetjük az Interop alakzat‑azonosítót, és hogyan állíthatunk be alternatív szöveget az azonosításhoz és a további feldolgozáshoz.

Továbbá lefedi, hogyan érhetjük el az alakzatok elrendezési formátumait, hogyan renderelhetünk egy alakzatot SVG‑ként, hogyan igazíthatunk alakzatokat egy dián, és hogyan használhatók a vízszintes és függőleges tükrözéshez tartozó flip tulajdonságok. Emellett a cikk egy rövid GYIK‑ot is tartalmaz az alakzatok egyesítésével, rétegezési sorrendjével és zárolásával kapcsolatban.

## **Alakzat keresése egy dián**
Ez a téma egy egyszerű technikát mutat be, amely megkönnyíti a fejlesztők számára, hogy egy adott alakzatot megtaláljanak a dián anélkül, hogy a belső azonosítóját kellene használniuk. Fontos tudni, hogy a PowerPoint prezentációfájlok egyetlen módon sem tudják azonosítani az alakzatokat a dián kívül egy belső egyedi azonosítón kívül. A fejlesztők számára nehéz lehet egy alakzatot megtalálni a belső egyedi azonosítója alapján. Minden diára felvett alakzathoz van valamilyen Alternatív Szöveg. Javasoljuk, hogy a fejlesztők az Alternatív Szöveget használják egy adott alakzat megtalálásához. A Microsoft PowerPoint segítségével definiálhatja az objektumok alternatív szövegét, amelyeket később módosítani szeretne.

Miután beállította a kívánt alakzat alternatív szövegét, megnyithatja a prezentációt az Aspose.Slides for Android via Java segítségével, és végigiterálhat a diára felvett összes alakzaton. Minden iteráció során ellenőrizheti az alakzat alternatív szövegét, és a megfelelő alternatív szöveggel rendelkező alakzat lesz a keresett alakzat. Ennek a technikának a jobb bemutatásához létrehoztunk egy [findShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) nevű metódust, amely megoldja egy adott alakzat megtalálását a dián, és egyszerűen visszaadja azt.

```java
// Példányosít egy Presentation osztályt, amely a prezentáció fájlt képviseli
Presentation pres = new Presentation("FindingShapeInSlide.pptx");
try {

    ISlide slide = pres.getSlides().get_Item(0);
    // A megtalálandó alakzat alternatív szövege
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
// Metódus implementációja egy alakzat megtalálásához egy dián az alternatív szöveg alapján
public static IShape findShape(ISlide slide, String alttext)
{
    // A dián belüli összes alakzat iterálása
    for (int i = 0; i < slide.getShapes().size(); i++)
    {
        // Ha a dián található alternatív szöveg megegyezik a keresettel
        // Visszaadja az alakzatot
        if (slide.getShapes().get_Item(i).getAlternativeText().compareTo(alttext) == 0)
            return slide.getShapes().get_Item(i);
    }
    return null;
}
```

## **Alakzat klónozása**
Alakzat klónozásához egy dián az Aspose.Slides for Android via Java használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Szerezze be a dia hivatkozását az indexe alapján.
1. Érje el a forrásdia alakzatgyűjteményét.
1. Adjon hozzá egy új diát a prezentációhoz.
1. Klónozza az alakzatokat a forrásdia alakzatgyűjteményéből az új diára.
1. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példa egy csoport alakzatot ad egy diához.

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

    // PPTX fájl mentése a lemezen
    pres.save("CloneShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat eltávolítása**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy a fejlesztők eltávolítsanak bármelyik alakzatot. Egy alakzat eltávolításához egy diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Keresse meg az alakzatot a megadott AlternativeText érték alapján.
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

    // Prezentáció mentése a lemezen
    pres.save("RemoveShape_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat elrejtése**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy a fejlesztők elrejtsenek bármelyik alakzatot. Egy alakzat elrejtéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Keresse meg az alakzatot a megadott AlternativeText érték alapján.
1. Rejtse el az alakzatot.
1. Mentse a fájlt a lemezen.

```java
// Presentation osztály példányosítása, amely a PPTX-et képviseli
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

    // Prezentáció mentése a lemezen
    pres.save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat sorrendjének módosítása**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy a fejlesztők átrendezzék az alakzatokat. Az átrendezés meghatározza, melyik alakzat van elöl és melyik hátul. Egy alakzat átrendezéséhez egy dián kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Adjon hozzá egy alakzatot.
1. Adjon szöveget az alakzat szövegkeretébe.
1. Adjon hozzá egy másik alakzatot ugyanazzal a koordinátával.
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

## **Interop alakzat‑azonosító lekérése**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy a fejlesztők egyedi alakzat‑azonosítót kapjanak egy dián belül, szemben a [getUniqueId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getUniqueId--) metódussal, amely a prezentáció szintjén ad egyedi azonosítót. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) metódus került fel a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape) interfészhez és a [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Shape) osztályhoz. A [getOfficeInteropShapeId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getOfficeInteropShapeId--) metódus által visszaadott érték megfelel a Microsoft.Office.Interop.PowerPoint.Shape objektum Id‑jének. Az alábbiakban egy mintakód látható.

```java
Presentation pres = new Presentation("Presentation.pptx");
try {
    // Egyedi alakzat azonosító lekérése dián belül
    long officeInteropShapeId = pres.getSlides().get_Item(0).getShapes().get_Item(0).getOfficeInteropShapeId();

} finally {
    if (pres != null) pres.dispose();
}
```

## **Alternatív szöveg beállítása egy alakzathoz**
Az Aspose.Slides for Android via Java lehetővé teszi, hogy a fejlesztők beállítsák bármelyik alakzat AlternateText értékét. A prezentáció alakzatait megkülönböztethetjük a [AlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) vagy a [Shape Name](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setName-java.lang.String-) metódussal.
A [setAlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#setAlternativeText-java.lang.String-) és a [getAlternativeText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#getAlternativeText--) metódusok olvashatók és írhatók az Aspose.Slides és a Microsoft PowerPoint segítségével egyaránt.
Ezzel a módszerrel címkézhet alakzatot, és különböző műveleteket végezhet, például egy alakzat eltávolítása, elrejtése vagy átrendezése a dián.
Az AlternateText beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Presentation) osztályból.
1. Érje el az első diát.
1. Adjon hozzá bármilyen alakzatot a diához.
1. Végezzen el némi munkát az újaként felvett alakzattal.
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

    // Prezentáció mentése a lemezen
    pres.save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alakzat elrendezési formátumainak elérése**
Az Aspose.Slides for Android via Java egyszerű API‑t biztosít az alakzatok elrendezési formátumainak eléréséhez. Ez a cikk bemutatja, hogyan érheti el ezeket a formátumokat.

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
Az Aspose.Slides for Android via Java most már támogatja az alakzatok SVG‑ként történő renderelését. A [writeAsSvg](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape#writeAsSvg-java.io.OutputStream-) metódus (és annak túlterhelése) felkerült a [Shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/Shape) osztályba és az [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape) interfészbe. Ez a metódus lehetővé teszi, hogy az alakzat tartalmát SVG fájlként mentse. Az alábbi kódrészlet megmutatja, hogyan exportálhatja egy dia alakzatát SVG fájlba.

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
Az Aspose.Slides lehetővé teszi az alakzatok igazítását akár a dia margóihoz, akár egymáshoz képest. Erre a célra hozzá lett adva az [SlidesUtil.alignShape()](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/SlideUtil#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) túlterhelt metódus. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ShapesAlignmentType) felsorolás definiálja a lehetséges igazítási lehetőségeket.

**Példa 1**

Az alábbi forráskód a 1., 2. és 4. indexű alakzatokat igazítja a dia felső szélén.

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

A következő példa azt mutatja, hogyan igazítható a teljes alakzatgyűjtemény a gyűjtemény legalsó alakzata szerint.

```java
Presentation pres = new Presentation("example.pptx");
try {
    SlideUtil.alignShapes(ShapesAlignmentType.AlignBottom, false, pres.getSlides().get_Item(0));
} finally {
    if (pres != null) pres.dispose();
}
```

## **Flip tulajdonságok**

Az Aspose.Slides‑ben a [ShapeFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/) osztály biztosítja a horizontális és vertikális tükrözés vezérlését a `flipH` és `flipV` tulajdonságokon keresztül. Mindkét tulajdonság `byte` típusú, ahol az `1` érték tükrözést jelent, a `0` nincs tükrözés, a `-1` pedig az alapértelmezett viselkedést alkalmazza. Ezek az értékek egy alakzat [Frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getFrame--)‑jéből érhetők el.

A flip beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapeframe/) példányt hozunk létre az alakzat jelenlegi pozíciójával és méretével, a kívánt `flipH` és `flipV` értékekkel, valamint a forgatási szöggel. Ennek a példánynak a [Frame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/#getFrame--)‑hez való hozzárendelése és a prezentáció mentése alkalmazza a tükörtranszformációkat, és elmenti azokat a kimeneti fájlba.

Tegyük fel, hogy van egy sample.pptx fájlunk, amelynek az első diája egyetlen alakzatot tartalmaz alapértelmezett flip beállításokkal, ahogy az alább látható.

![The shape to be flipped](shape_to_be_flipped.png)

Az alábbi kódrészlet lekéri az alakzat aktuális flip tulajdonságait, és mind vízszintesen, mind függőlegesen tükrözi azt.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    // Az alakzat vízszintes tükrözési tulajdonságának lekérése.
    byte horizontalFlip = shape.getFrame().getFlipH();
    System.out.println("Horizontal flip: " + horizontalFlip);

    // Az alakzat függőleges tükrözési tulajdonságának lekérése.
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

**Kombinálhatok-e alakzatokat (unió/keresztezés/kivonás) egy dián, ahogy egy asztali szerkesztőben?**

Nincs beépített Boolean művelet API. Megközelíthető saját kontúr megalkotásával – például kiszámítva a végeredmény geometriáját a [GeometryPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/geometrypath/) segítségével, majd létrehozva egy új alakzatot ezzel a kontúrral, opcionálisan a régi alakzatok eltávolításával.

**Hogyan szabályozhatom a rétegezési sorrendet (z‑order), hogy egy alakzat mindig "felül" maradjon?**

Módosítsa a beszúrási/áthelyezési sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/baseslide/#getShapes--) gyűjteményében. A kiszámítható eredményekért véglegesítse a z‑order‑t minden egyéb dia módosítás után.

**Le tudom-e "zárolni" egy alakzatot, hogy a felhasználók ne szerkeszthessék PowerPointban?**

Igen. Állítson be alakzatszintű védelmi jelzőket (például kijelölés, mozgás, átméretezés, szövegszerkesztés zárolása). Szükség esetén alkalmazzon korlátozásokat a mester vagy a layout szintjén is. Vegye figyelembe, hogy ez UI‑szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, például [read‑only ajánlásokkal vagy jelszavakkal](/slides/hu/androidjava/password-protected-presentation/).