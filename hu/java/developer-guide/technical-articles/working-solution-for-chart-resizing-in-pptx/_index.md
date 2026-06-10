---
title: Működő megoldás a diagram átméretezéshez PPTX-ben
type: docs
weight: 40
url: /hu/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Javítsa a váratlan diagram átméretezést PPTX-ben beágyazott Excel OLE objektumok használatakor az Aspose.Slides for Java-val. Tanulja meg a két módszert kóddal a méretek konzisztens megtartásához."
---
## **Háttér**

Megfigyeltük, hogy az Aspose komponenseken keresztül egy PowerPoint‑prezentációba beágyazott OLE‑objektumként megjelenő Excel‑diagramok az első aktiválásuk után meghatározatlan méretarányra változnak. Ez a viselkedés észrevehető vizuális különbséget okoz a prezentációban a diagram aktiválás előtti és utáni állapota között. Az Aspose csapata részletesen kivizsgálta a problémát, és megoldást talált. Ez a cikk leírja a probléma okait és a megfelelő javítást.

A [előző cikk](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)-ben elmagyaráztuk, hogyan hozhatunk létre Excel‑diagramot az Aspose.Cells for Java segítségével, és hogyan ágyazhatjuk be azt egy PowerPoint‑prezentációba az Aspose.Slides for Java használatával. Az [objektum előnézet probléma](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) kezelésére a diagram képét rendeltük a diagram OLE‑objektumkeretéhez. A kimeneti prezentációban, ha duplán rákattintunk a diagram képet megjelenítő OLE‑objektumkeretre, az Excel‑diagram aktiválódik. A végfelhasználók tetszőleges módosításokat végezhetnek a háttér‑Excel‑munkafüzetben, majd a aktivált munkafüzeten kívülre kattintva visszatérhetnek a megfelelő diára. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési arány a keret és a beágyazott Excel‑munkafüzet eredeti méretei alapján változik.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani eredeti méretét. Az OLE‑objektumkeretnek azonban saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, és a beágyazási folyamat részeként megőrzik a helyes arányokat. Az Excel‑ablakméret és az OLE‑objektumkeret mérete vagy pozíciója közötti különbségek függvényében történik az átméretezés.

## **Működő megoldás**

Két lehetséges forgatókönyv van a PowerPoint‑prezentációk létrehozására az Aspose.Slides for Java használatával.

**1. forgatókönyv:** Létrehozni egy prezentációt meglévő sablon alapján.  
**2. forgatókönyv:** Létrehozni egy prezentációt a semmiből.

A itt bemutatott megoldás mindkét forgatókönyvre alkalmazható. Minden megoldási megközelítés alapja ugyanaz: **a beágyazott OLE‑objektum ablakméretének meg kell egyeznie a PowerPoint‑dia OLE‑objektumkeretével**. Most bemutatjuk a két megközelítést.

## **Első megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a beágyazott Excel‑munkafüzet ablakmérete úgy, hogy az megegyezzen a PowerPoint‑dia OLE‑objektumkeretének méretével.

**1. forgatókönyv**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezzük, hogy a sablonban a 2. indexű alakzatnál szeretnénk egy OLE‑keretet elhelyezni, amely beágyazott Excel‑munkafüzettel tartalmaz. Ebben a forgatókönyvben az OLE‑objektumkeret mérete előre meghatározott – egyezik a sablon 2. indexű alakzatának méretével. Csak annyit kell tennünk, hogy a munkafüzet ablakméretét ennek az alakzatnak a méretével állítjuk egyenlővé. A következő kódrészlet ezt a célt szolgálja:

```java
// Állítsa be a munkafüzet ablakának szélességét hüvelykben (osztva 576-tal, mivel a PowerPoint 576 képpontot használ hüvelykenként).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Állítsa be a munkafüzet ablakának magasságát hüvelykben.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Mentse a munkafüzetet egy memóriafolyamra.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**2. forgatókönyv**

Tegyük fel, hogy a semmiből szeretnénk prezentációt létrehozni, és tetszőleges méretű OLE‑objektumkeretet szeretnénk beágyazott Excel‑munkafüzettel ellátni. Az alábbi kódrészletben egy OLE‑objektumkeretet hozunk létre, amely 4 hüvelyk magas és 9,5 hüvelyk széles, x = 0,5 hüvelyk, y = 1 hüvelyk helyen a dián. Ezután a Excel‑munkafüzet ablakát ugyanarra a méretre állítjuk – 4 hüvelyk magas és 9,5 hüvelyk széles.

```java
// A kívánt magasságunk.
int desiredHeight = 288; // 4 hüvelyk (4 * 72)
 
// A kívánt szélességünk.
int desiredWidth = 684; // 9,5 hüvelyk (9,5 * 72)
 
// Definiálja a diagram méretét egy ablakban.
chart.setSizeWithWindow(true);
 
// Állítsa be a munkafüzet ablakának szélességét hüvelykben (osztva 576-tal, mivel a PowerPoint 576 képpontot használ hüvelykenként).
workbook.getSettings().setWindowWidthInch(desiredHeight / 72f);
 
// Állítsa be a munkafüzet ablakának magasságát hüvelykben.
workbook.getSettings().setWindowHeightInch(desiredWidth / 72f);
 
// Mentse a munkafüzetet egy memóriafolyamra.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Második megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítható be a beágyazott Excel‑munkafüzetben lévő diagram mérete úgy, hogy az megegyezzen a PowerPoint‑dia OLE‑objektumkeretének méretével. Ez a megközelítés akkor hasznos, ha a diagram mérete előre ismert, és nem fog változni.

**1. forgatókönyv**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezzük, hogy a sablonban a 2. indexű alakzatnál egy OLE‑keretet akarunk elhelyezni, amely beágyazott Excel‑munkafüzettel rendelkezik. Ebben a forgatókönyvben az OLE‑keret mérete előre meghatározott – egyezik a sablon 2. indexű alakzatának méretével. Csak annyit kell tennünk, hogy a diagram méretét a munkafüzetben az alakzat méretével egyenlővé állítjuk. A következő kódrészlet ezt a célt szolgálja:

```java
// Határozza meg a diagram méretét ablak nélkül.
chart.setSizeWithWindow(false);
 
// Állítsa be a diagram szélességét pixelben (szorozza 96-tal, mivel az Excel hüvelykenként 96 pixelt használ).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Állítsa be a diagram magasságát pixelben.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Határozza meg a diagram nyomtatási méretét.
chart.setPrintSize(PrintSizeType.CUSTOM);
 
// Mentse a munkafüzetet egy memóriafolyamra.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

**2. forgatókönyv**

Tegyük fel, hogy a semmiből szeretnénk prezentációt létrehozni, és tetszőleges méretű OLE‑objektumkeretet szeretnénk beágyazott Excel‑munkafüzettel ellátni. Az alábbi kódrészletben egy OLE‑objektumkeretet hozunk létre, amelynek magassága 4 hüvelyk, szélessége 9,5 hüvelyk, x = 0,5 hüvelyk, y = 1 hüvelyk helyen a dián. A megfelelő diagram méretét is ugyanarra a méretre állítjuk: magasság 4 hüvelyk, szélesség 9,5 hüvelyk.

```java
// A kívánt magasságunk.
int desiredHeight = 288; // 4 hüvelyk (4 * 72)
 
// A kívánt szélességünk.
int desiredWidth = 684; // 9,5 hüvelyk (9,5 * 72)
 
// Határozza meg a diagram méretét ablak nélkül.
chart.setSizeWithWindow(false);
 
// Állítsa be a diagram szélességét pixelben (szorozza 96-tal, mivel az Excel hüvelykenként 96 pixelt használ).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 576f) * 96f));
 
// Állítsa be a diagram magasságát pixelben.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 576f) * 96f));
 
// Mentse a munkafüzetet egy memóriafolyamra.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    288,
    576,
    desiredWidth,
    desiredHeight,
    "Excel.Sheet.8",
    workbookStream.toByteArray());
```

## **Következtetés**

Két megközelítés létezik a diagram-átméretezési probléma megoldására. A megközelítés választása a követelményektől és a felhasználási esettől függ. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentációk sablon alapján vagy a semmiből készülnek. Emellett nincs korlátozás az OLE‑objektumkeret méretére ebben a megoldásban.

## **GYIK**

**Miért változik méretben a beágyazott Excel-diagram a PowerPointban történő aktiválás után?**  
Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretet, míg a PowerPoint OLE‑objektumkerete saját dimenziókkal rendelkezik. A PowerPoint és az Excel egyeztetik a méretet a képarány megőrzése érdekében, ami az átméretezést okozhat.

**Lehetséges-e teljesen megakadályozni ezt az átméretezési problémát?**  
Igen. Ha a beágyazás előtt az Excel‑munkafüzet ablakméretét vagy a diagram méretét az OLE‑objektumkeret méretéhez igazítjuk, a diagramméretek konzisztens maradnak.

**Melyik megközelítést válasszam: a munkafüzet ablakméretének beállítását vagy a diagram méretének beállítását?**  
Használja a **1. megközelítést (ablakméret)**, ha meg szeretné tartani a munkafüzet képarányát, és később lehetővé szeretné tenni az átméretezést.  
Használja a **2. megközelítést (diagramméret)**, ha a diagram méretei rögzítettek, és a beágyazás után nem fognak változni.

**Működnek-e ezek a módszerek mind sablon‑alapú, mind új prezentációk esetén?**  
Igen. Mindkét megközelítés ugyanúgy működik a sablonból létrehozott és a semmiből készült prezentációk esetén.

**Van korlátozás az OLE‑objektumkeret méretére?**  
Nem. Az OLE‑keretet tetszőleges méretre beállíthatja, amennyiben megfelelően skálázódik a munkafüzet vagy a diagram méretéhez.

**Használhatom-e ezeket a módszereket más táblázatkezelő programokkal készített diagramokkal?**  
A példák Excel-diagramokra vonatkoznak, amelyeket az Aspose.Cells segítségével hoztak létre, de az elvek más OLE‑kompatibilis táblázatkezelő programokra is alkalmazhatók, amennyiben hasonló méretezési lehetőségeket támogatnak.

## **Kapcsolódó szakaszok**

- [Excel-diagramok létrehozása és OLE‑objektumként beágyazása a prezentációkba](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE‑objektumok automatikus frissítése PowerPoint‑kiegészítő segítségével](/slides/hu/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)