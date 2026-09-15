---
title: A diagram átméretezésének munkaközeli megoldása PPTX-ben
type: docs
weight: 40
url: /hu/java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazás
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Javítsa a váratlan diagram átméretezést PPTX-ben, amikor beágyazott Excel OLE objektumokat használ az Aspose.Slides for Java. Ismerje meg a két módszert kóddal a méretek konzisztens megtartásához."
---
## **Háttér**

Megfigyeltük, hogy az Aspose komponenseken keresztül PowerPoint‑prezentációba beágyazott OLE objektumként szereplő Excel‑diagramok az első aktiválás után egy nem meghatározott skálára vannak átméretezve. Ez a viselkedés észrevehető vizuális különbséget okoz a prezentációban a diagram aktiválás előtti és utáni állapota között. Az Aspose csapata részletesen kivizsgálta a problémát, és megoldást talált. Ez a cikk leírja a probléma okait és a megfelelő javítást.

Az [előző cikkben](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) elmagyaráztuk, hogyan hozhatunk létre egy Excel‑diagramot az Aspose.Cells for Java segítségével, és ágyazhatjuk be egy PowerPoint‑prezentációba az Aspose.Slides for Java segítségével. A [objektum előnézeti problémájának](/slides/hu/java/object-preview-issue-when-adding-oleobjectframe/) megoldásához a diagram képét hozzárendeltük a diagram OLE objektumkeretéhez. A kimeneti prezentációban, ha duplán kattintunk az OLE objektumkeretre, amely a diagramképet mutatja, az Excel‑diagram aktiválódik. A végfelhasználók a mögöttes Excel‑munkafüzetben tetszőleges módosításokat végezhetnek, majd a aktivált munkafüzeten kívülre kattintva visszatérhetnek a megfelelő diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési tényező a OLE objektumkeret és a beágyazott Excel‑munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Az OLE objektumkeretnek azonban saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, és a beágyazási folyamat részeként a helyes arányokat fenntartják. Az Excel‑ablakméret és az OLE objektumkeret mérete vagy pozíciója közti különbségek alapján történik az átméretezés.

## **Működő megoldás**

Két lehetséges forgatókönyv létezik a PowerPoint‑prezentációk létrehozásához az Aspose.Slides for Java használatával.

**Scenario 1:** Létrehozni egy prezentációt egy meglévő sablon alapján.

**Scenario 2:** Létrehozni egy prezentációt a semmiből.

Az itt bemutatott megoldás mindkét forgatókönyvre alkalmazható. Minden megoldási megközelítés alapja ugyanaz: **a beágyazott OLE objektum ablakméretének meg kell egyeznie a PowerPoint‑dia OLE objektumkeretével**. Most a megoldás két megközelítését vesszük sorra.

## **Első megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel‑munkafüzet ablakméretét, hogy az egyezzen a PowerPoint‑dia OLE objektumkeretének méretével.

**Scenario 1**

Tegyük fel, hogy definiáltunk egy sablont, és szeretnénk belőle prezentációkat készíteni. Tegyük fel, hogy a sablonban a 2. indexű alakzat helyén OLE‑keretet szeretnénk elhelyezni, amely egy beágyazott Excel‑munkafüzetet tartalmaz. Ebben a forgatókönyvben az OLE objektumkeret mérete előre meghatározott – egyezik a sablon 2. indexű alakzatának méretével. Ahhoz, hogy a munkafüzet ablakméretét az alakzat méretével egyeztesse, csak be kell állítanunk azt. A következő kódrészlet ezt a célt szolgálja:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Állítsa be a munkafüzet ablak szélességét hüvelykben (osztva 72-vel, mivel a PowerPoint hüvelykenként 72 pontot használ).
workbook.getSettings().setWindowWidthInch(slide.getShapes().get_Item(2).getWidth() / 72f);
 
// Állítsa be a munkafüzet ablak magasságát hüvelykben.
workbook.getSettings().setWindowHeightInch(slide.getShapes().get_Item(2).getHeight() / 72f);
 
// Mentse a munkafüzetet memóriafolyamba.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

Tegyük fel, hogy a semmiből szeretnénk prezentációt létrehozni, és bármilyen méretű OLE objektumkeretet szeretnénk a beágyazott Excel‑munkafüzettel. A következő kódrészletben egy 4 hüvelyk magas és 9,5 hüvelyk széles OLE objektumkeretet hozunk létre a diáron x = 0,5 hüvelyk és y = 1 hüvelyk helyen. Ezután az Excel‑munkafüzet ablakát ugyanolyan méretűre állítjuk – 4 hüvelyk magas és 9,5 hüvelyk széles.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// A kívánt magasságunk.
int desiredHeight = 288; // 4 hüvelyk (4 * 72)
 
// A kívánt szélességünk.
int desiredWidth = 684; // 9,5 hüvelyk (9.5 * 72)
 
// Állítsa be a diagram méretét egy ablakban.
chart.setSizeWithWindow(true);
 
// Állítsa be a munkafüzet ablak szélességét hüvelykben (osztva 72-vel, mivel a PowerPoint hüvelykenként 72 pontot használ).
workbook.getSettings().setWindowWidthInch(desiredWidth / 72f);
 
// Állítsa be a munkafüzet ablak magasságát hüvelykben.
workbook.getSettings().setWindowHeightInch(desiredHeight / 72f);
 
// Mentse a munkafüzetet memóriafolyamba.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 hüvelyk (0.5 * 72)
    72,  // y = 1 hüvelyk (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Második megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a diagram méretét a beágyazott Excel‑munkafüzetben, hogy az egyezzen a PowerPoint‑dia OLE objektumkeretének méretével. Ez a megközelítés akkor hasznos, amikor a diagram mérete előre ismert, és soha nem változik.

**Scenario 1**

Tegyük fel, hogy definiáltunk egy sablont, és szeretnénk belőle prezentációkat készíteni. Tegyük fel, hogy a sablonban a 2. indexű alakzat helyén OLE‑keretet akarunk elhelyezni, amely egy beágyazott Excel‑munkafüzetet tartalmaz. Ebben a forgatókönyvben az OLE keret mérete előre meghatározott – egyezik a sablon 2. indexű alakzatának méretével. Ahhoz, hogy a diagram méretét a munkafüzetben az alakzat méretével egyeztesse, csak be kell állítanunk azt. A következő kódrészlet ezt a célt szolgálja:

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// Határozza meg a diagram méretét ablak nélkül.
chart.setSizeWithWindow(false);
 
// Állítsa be a diagram szélességét pixelben (szorozza 96-tal, mivel az Excel hüvelykenként 96 pixelt használ).
chart.getChartObject().setWidth((int)((slide.getShapes().get_Item(2).getWidth() / 72f) * 96f));
 
// Állítsa be a diagram magasságát pixelben.
chart.getChartObject().setHeight((int)((slide.getShapes().get_Item(2).getHeight() / 72f) * 96f));
 
// Határozza meg a diagram nyomtatási méretét.
chart.setPrintSize(com.aspose.cells.PrintSizeType.CUSTOM);
 
// Mentse a munkafüzetet memóriafolyamba.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    slide.getShapes().get_Item(2).getX(),
    slide.getShapes().get_Item (2).getY(),
    slide.getShapes().get_Item (2).getWidth(),
    slide.getShapes().get_Item (2).getHeight(),
    dataInfo);
```

**Scenario 2**

Tegyük fel, hogy a semmiből szeretnénk prezentációt készíteni, és bármilyen méretű OLE objektumkeretet szeretnénk a beágyazott Excel‑munkafüzettel. A következő kódrészletben egy 4 hüvelyk magas és 9,5 hüvelyk széles OLE objektumkeretet hozunk létre a diáron x = 0,5 hüvelyk és y = 1 hüvelyk helyen. A diagram méretét is ugyanarra a méretre állítjuk: 4 hüvelyk magasság és 9,5 hüvelyk szélesség.

```java
import com.aspose.slides.*;
import java.io.ByteArrayOutputStream;

// A kívánt magasságunk.
int desiredHeight = 288; // 4 hüvelyk (4 * 72)
 
// A kívánt szélességünk.
int desiredWidth = 684; // 9,5 hüvelyk (9.5 * 72)
 
// Határozza meg a diagram méretét ablak nélkül.
chart.setSizeWithWindow(false);
 
// Állítsa be a diagram szélességét pixelben (osztva 72-vel a hüvelykekhez, szorozva 96-tal, mivel az Excel hüvelykenként 96 pixelt használ).
chart.getChartObject().setWidth((int)((desiredWidth / 72f) * 96f));
 
// Állítsa be a diagram magasságát pixelben.
chart.getChartObject().setHeight((int)((desiredHeight / 72f) * 96f));
 
// Mentse a munkafüzetet memóriafolyamba.
ByteArrayOutputStream workbookStream = new ByteArrayOutputStream();
workbook.save(workbookStream, com.aspose.cells.SaveFormat.EXCEL_97_TO_2003);
 
// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(workbookStream.toByteArray(), "xls");
IOleObjectFrame oleFrame = slide.getShapes().addOleObjectFrame(
    36,  // x = 0,5 hüvelyk (0.5 * 72)
    72,  // y = 1 hüvelyk (1 * 72)
    desiredWidth,
    desiredHeight,
    dataInfo);
```

## **Következtetés**

Két megközelítés létezik a diagram‑átméretezési probléma megoldására. A választás a követelményektől és a felhasználási esettől függ. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentációk sablonból vagy a semmiből készülnek. Emellett ebben a megoldásban nincs korlátozás az OLE objektumkeret méretére.

## **GYIK**

### Miért változik a beágyazott Excel‑diagram mérete a PowerPoint‑ban történő aktiválás után?

Ez azért fordul elő, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretét, míg a PowerPoint‑ban az OLE objektumkeretnek saját méretei vannak. A PowerPoint és az Excel egyeztetik a méretet az arányok megtartása érdekében, ami átméretezést okozhat.

### Lehetséges-e teljesen elkerülni ezt az átméretezési problémát?

Igen. Ha az Excel‑munkafüzet ablakméretét vagy a diagram méretét a beágyazás előtt az OLE objektumkeret méretéhez igazítjuk, a diagram mérete konzisztens marad.

### Melyik megközelítést válasszam, az ablakméret beállítását vagy a diagramméretet?

Használja a **1. megközelítést (ablakméret)**, ha a munkafüzet arányait szeretné megtartani, és esetleg később szeretne átméretezni.  
Használja a **2. megközelítést (diagramméret)**, ha a diagram méretei előre rögzítettek és nem fognak változni a beágyazás után.

### Működnek-e ezek a módszerek sablon‑alapú és új prezentációk esetén egyaránt?

Igen. Mindkét megközelítés egyformán működik sablonból és a semmiből készült prezentációk esetén.

### Van-e korlátozás az OLE objektumkeret méretére?

Nincs. Az OLE keretet bármilyen méretre beállíthatja, amíg megfelelően méretezhető a munkafüzet vagy a diagram.

### Használhatók-e ezek a módszerek más táblázatkezelő programokban létrehozott diagramokkal?

A példák az Aspose.Cells‑szel készült Excel‑diagramokra vonatkoznak, de az elv ugyanúgy alkalmazható más OLE‑kompatibilis táblázatkezelő programokra, amennyiben azok támogatják a hasonló méretezési beállításokat.

## **Kapcsolódó szakaszok**

- [Excel-diagramok létrehozása és OLE objektumként történő beágyazása a prezentációkba](/slides/hu/java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)