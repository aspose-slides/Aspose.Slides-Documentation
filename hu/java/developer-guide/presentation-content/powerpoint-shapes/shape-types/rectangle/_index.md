---
title: Téglalapok hozzáadása a prezentációkhoz Java-ban
linktitle: Téglalap
type: docs
weight: 80
url: /hu/java/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alakzat
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Növelje PowerPoint prezentációi hatékonyságát téglalapok hozzáadásával az Aspose.Slides for Java segítségével – egyszerűen tervezzen és módosítson alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet téglalap alakzatokat hozzáadni a PowerPoint diákhoz az Aspose.Slides használatával. Szól egy egyszerű téglalap létrehozásáról, egy formázott téglalapról, valamint a módosított prezentáció PPTX fájlként való mentéséről.

Megtekintheti, hogyan alkalmazható az alapvető téglalap-formázás, például az egyszínű kitöltés, a vonalszín és a vonalvastagság. Emellett a cikk GYIK része kapcsolódó téglalap feladatokra mutat rá, többek között lekerekített sarkokra, képi kitöltésekre, vizuális hatásokra, hiperhivatkozásokra, alakzatzárolásra, exportálási lehetőségekre és hatékony tulajdonságokra.

## **Téglalap hozzáadása a diára**
A prezentáció egy kiválasztott diájához egyszerű téglalap hozzáadásához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) téglalap típusú alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amelyet az [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Írja ki a módosított prezentációt PPTX fájlként.

Az alább bemutatott példában egy egyszerű téglalapot adtunk hozzá a prezentáció első diájához.

```java
// Presentation osztály példányosítása, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Ellipszis típusú AutoShape hozzáadása
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // A PPTX fájl mentése a lemezre
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formázott téglalap hozzáadása a diára**
Formázott téglalap hozzáadásához a diára kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.
- Szerezze be a dia hivatkozását az Index használatával.
- Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IAutoShape) téglalap típusú alakzatot a [addAutoShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus segítségével, amelyet az [IShapeCollection](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShapeCollection) objektum biztosít.
- Állítsa be a téglalap [Fill Type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/FillType) értékét Solid‑ra.
- Állítsa be a téglalap színét a [SolidFillColor.setColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) metódussal, amelyet az [IFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IFillFormat) objektum kínál a [IShape](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IShape) objektumhoz kapcsolódóan.
- Állítsa be a téglalap vonalainak színét.
- Állítsa be a téglalap vonalainak szélességét.
- Írja ki a módosított prezentációt PPTX fájlként.

A fenti lépéseket a lenti példában valósítottuk meg.

```java
// Presentation osztály példányosítása, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Az első dia lekérése
    ISlide sld = pres.getSlides().get_Item(0);

    // Ellipszis típusú AutoShape hozzáadása
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Formázás alkalmazása az ellipszis alakzatra
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Formázás alkalmazása az ellipszis vonalára
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // A PPTX fájl mentése a lemezre
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan adhatok hozzá egy lekerekített sarkú téglalapot?**

Használja a lekerekített sarkú [shape type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shapetype/)‑t, és állítsa be a sarokrúdiamétert az alakzat tulajdonságaiban; a lekerekítést egyes sarkokra is alkalmazhatja geometriai módosításokkal.

**Hogyan tölthetek ki egy téglalapot képpel (textúrával)?**

Válassza a kép [fill type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/)-ot, adja meg a kéforrást, és állítsa be a [stretching/tiling modes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/picturefillmode/)-t.

**Lehet-e a téglalapra árnyékot vagy ragyogást alkalmazni?**

Igen. A [külső/belső árnyék, ragyogás és lágy szél]( /slides/hu/java/shape-effect/) elérhető, és paraméterekkel szabályozható.

**Átalakíthatom-e a téglalapot gombbal és hiperhivatkozással?**

Igen. [Rendeljen hiperhivatkozást](/slides/hu/java/manage-hyperlinks/) az alakzat kattintásához (diára, fájlra, webcímre vagy e‑mailre ugrás).

**Hogyan védhetem meg a téglalapot a mozgatástól és a módosítástól?**

[Használja a shape locks](/slides/hu/java/applying-protection-to-presentation/) funkciót: megtilthatja a mozgatást, átméretezést, kiválasztást vagy a szövegszerkesztést a elrendezés megőrzése érdekében.

**Konvertálhatom‑e a téglalapot raszteres képpé vagy SVG‑vé?**

Igen. [Renderelheti az alakzatot](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#getImage-int-float-float-) egy megadott méretű/skálájú képpé, vagy [exportálhatja SVG‑ként](https://reference.aspose.com/slides/hu/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) vektoros felhasználásra.

**Hogyan szerezhetem meg gyorsan egy téglalap tényleges (effective) tulajdonságait a téma és az öröklődés figyelembevételével?**

[Használja az alakzat hatékony tulajdonságait](/slides/hu/java/shape-effective-properties/): az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, elrendezését és a helyi beállításokat, ezzel leegyszerűsítve a formázási elemzést.