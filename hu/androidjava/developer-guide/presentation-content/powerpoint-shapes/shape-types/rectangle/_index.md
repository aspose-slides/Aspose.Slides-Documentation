---
title: Téglalapok hozzáadása prezentációkhoz Androidon
linktitle: Téglalap
type: docs
weight: 80
url: /hu/androidjava/rectangle/
keywords:
- téglalap hozzáadása
- téglalap létrehozása
- téglalap alakzat
- egyszerű téglalap
- formázott téglalap
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Emelje a PowerPoint prezentációit téglalapok hozzáadásával az Aspose.Slides for Android segítségével Java-ban - egyszerűen tervezzen és módosítson alakzatokat programozottan."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan adhatunk hozzá téglalap alakzatokat a PowerPoint diához az Aspose.Slides segítségével. Bemutatja egy egyszerű téglalap létrehozását, egy formázott téglalap létrehozását, és a frissített bemutató PPTX fájlként való mentését.

Megtekintheti, hogyan alkalmazhat alapvető téglalap formázást, mint például a kitöltés szilárd színe, a vonal színe és a vonalvastagság. Emellett a cikk GYIK-ja a kapcsolódó téglalap feladatokra mutat, beleértve a lekerekített sarkokat, képkitöltéseket, vizuális effektusokat, hiperhivatkozásokat, alakzólakat, exportálási lehetőségeket és a hatékony tulajdonságokat.

## **Téglalap hozzáadása egy diára**
Egyszerű téglalap hozzáadásához a bemutató kiválasztott diájához kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
- Szerezze meg egy dia referenciáját az Index használatával.
- Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) téglalap típusút a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amelyet az [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektum biztosít.
- Írja ki a módosított bemutatót PPTX fájlként.

Az alább megadott példában egyszerű téglalapot adtunk hozzá a bemutató első diájához.

```java
// Példányosítsa a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape hozzáadása ellipszis típusú
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Írja a PPTX fájlt a lemezesre
    pres.save("RecShp1.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Formázott téglalap hozzáadása egy diára**
Formázott téglalap hozzáadásához egy diára kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
- Szerezze meg egy dia referenciáját az Index használatával.
- Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IAutoShape) téglalap típusút a [addAutoShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection#addAutoShape-int-float-float-float-float-) metódus használatával, amelyet az [IShapeCollection](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShapeCollection) objektum biztosít.
- Állítsa a téglalap [Fill Type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FillType) értékét Solid-ra.
- Állítsa be a téglalap színét a [SolidFillColor.setColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IColorFormat#setColor-java.awt.Color-) metódus használatával, amelyet az [IFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFillFormat) objektum biztosít, amely a [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IShape) objektummal van kapcsolatban.
- Állítsa be a téglalap vonalainak színét.
- Állítsa be a téglalap vonalainak szélességét.
- Írja ki a módosított bemutatót PPTX fájlként.

A fenti lépéseket a lenti példában valósítottuk meg.

```java
// Példányosítja a Presentation osztályt, amely a PPTX-et képviseli
Presentation pres = new Presentation();
try {
    // Szerezze meg az első diát
    ISlide sld = pres.getSlides().get_Item(0);

    // AutoShape hozzáadása ellipszis típusú
    IShape shp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 150, 50);

    // Alkalmazzon némi formázást az ellipszis alakzatra
    shp.getFillFormat().setFillType(FillType.Solid);
    shp.getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    // Alkalmazzon némi formázást az ellipszis vonalára
    shp.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shp.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    shp.getLineFormat().setWidth(5);

    // Írja a PPTX fájlt a lemezre
    pres.save("RecShp2.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **GYIK**

**Hogyan adhatok hozzá lekerekített sarkú téglalapot?**

Használja a lekerekített sarkú [shape type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shapetype/) típust, és állítsa be a sarokradiuszt az alakzat tulajdonságaiban; a lekerekítés egyes sarkokra is alkalmazható geometriai módosításokkal.

**Hogyan tölthetek ki egy téglalapot képpel (textúrával)?**

Válassza ki a kép [fill type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) típusát, adja meg a kép forrását, és állítsa be a [stretching/tiling modes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/picturefillmode/) módokat.

**Lehet egy téglalapnak árnyéka és ragyogása?**

Igen. Az [Outer/inner shadow, glow, and soft edges](/slides/hu/androidjava/shape-effect/) elérhető állítható paraméterekkel.

**Átalakíthatom a téglalapot gombbal és hiperhivatkozással?**

Igen. [Assign a hyperlink](/slides/hu/androidjava/manage-hyperlinks/) a forma kattintásához (ugrás diára, fájlra, webcímre vagy e‑mailre).

**Hogyan védhetem meg a téglalapot a mozgatástól és a módosításoktól?**

Használjon alakzólakat: megtilthatja a mozgatást, átméretezést, kiválasztást vagy a szövegszerkesztést a kiosztás megőrzése érdekében.

**Átalakíthatom a téglalapot raszteres képpé vagy SVG‑vé?**

Igen. [Render the shape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) képpé a megadott mérettel/méretezéssel, vagy [export it as SVG](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) vektorként használható formátumba.

**Hogyan tudom gyorsan lekérni egy téglalap tényleges (effective) tulajdonságait a téma és az öröklődés figyelembevételével?**

[Use the shape’s effective properties](/slides/hu/androidjava/shape-effective-properties/): az API kiszámított értékeket ad vissza, amelyek figyelembe veszik a téma stílusait, az elrendezést és a helyi beállításokat, megkönnyítve a formázás elemzését.