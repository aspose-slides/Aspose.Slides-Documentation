---
title: Működő megoldás a PPTX diagram átméretezésére
type: docs
weight: 60
url: /hu/net/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel-diagram
- OLE-objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Javítsa a nem várt diagram átméretezést PPTX-ben, amikor beágyazott Excel OLE objektumokat használ az Aspose.Slides for .NET segítségével. Ismerjen meg két kóddal ellátott módszert az egységes méretek megtartásához."
---
## **Háttér**

Megfigyelték, hogy az Aspose komponenseken keresztül PowerPoint-prezentációba OLE objektumként beágyazott Excel-diagramok az első aktiválásuk után ismeretlen méretarányra változnak. Ez a viselkedés észrevehető vizuális különbséget okoz a prezentációban a diagram aktiválás előtti és utáni állapotok között. Az Aspose csapata részletesen kivizsgálta a problémát, és megoldást talált. Ez a cikk leírja a probléma okait és a megfelelő javítást.

Az [előző cikk](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) bemutatta, hogyan hozhatunk létre Excel-diagramot az Aspose.Cells for .NET segítségével, és ágyazhatjuk be egy PowerPoint-prezentációba az Aspose.Slides for .NET használatával. Az [objektum előnézeti probléma](/slides/hu/net/object-preview-issue-when-adding-oleobjectframe/) megoldására a diagram képét a diagram OLE objektumkerethez rendeltük. A kimeneti prezentációban, ha duplán rákkattintunk a diagram képet megjelenítő OLE objektumkeretre, az Excel-diagram aktiválódik. A végfelhasználók a mögöttes Excel-munkafüzetben elvégezhetik a kívánt módosításokat, majd a aktivált munkafüzeten kívülre kattintva visszatérhetnek a megfelelő diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési arány az OLE objektumkeret és a beágyazott Excel-munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

Mivel az Excel-munkafüzetnek saját ablakmérete van, az első aktiváláskor megtartja az eredeti méretét. Az OLE objektumkeretnek azonban saját mérete van. A Microsoft szerint, amikor az Excel-munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, és a beágyazási folyamat részeként megtartják a megfelelő arányokat. Az Excel-ablak mérete és az OLE objektumkeret mérete vagy pozíciójának különbségei alapján történik az átméretezés.

## **Működő megoldás**

Hozzáférhető két lehetséges forgatókönyv a PowerPoint-prezentációk létrehozásához az Aspose.Slides for .NET használatával.

**Scenario 1:** Létrehozni egy prezentációt egy meglévő sablon alapján.

**Scenario 2:** Létrehozni egy prezentációt a semmibe.

Az itt bemutatott megoldás mindkét forgatókönyvre alkalmazható. Minden megoldási megközelítés alapja ugyanaz: **a beágyazott OLE objektum ablakméretének meg kell egyeznie a PowerPoint-dián lévő OLE objektumkerettel**. Most megvitatjuk a megoldás két megközelítését.

## **Első megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel-munkafüzet ablakméretét úgy, hogy az megegyezzen a PowerPoint-dián lévő OLE objektumkeret méretével.

**Scenario 1**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezhetjük, hogy a sablon 2‑es indexű alakzatában egy OLE keretet kívánunk elhelyezni, amely beágyazott Excel-munkafüzettel rendelkezik. Ebben a forgatókönyvben az OLE objektumkeret mérete előre definiált – megegyezik a sablon 2‑es indexű alakzatának méretével. Csak annyit kell tennünk, hogy a munkafüzet ablakméretét a forma méretével egyenlővé állítjuk. Az alábbi kódrészlet ezt a célt szolgálja:

```cs
// Definiálja a diagram méretét egy ablakkal. 
chart.SizeWithWindow = true;

// Állítsa be a munkafüzet ablakának szélességét hüvelykben (72-vel osztva, mivel a PowerPoint 72 pixelt használ hüvelykenként).
workbook.Worksheets.WindowWidthInch = slide.Shapes[2].Width / 72f;

// Állítsa be a munkafüzet ablakának magasságát hüvelykben.
workbook.Worksheets.WindowHeightInch = slide.Shapes[2].Height / 72f;

// Mentse a munkafüzetet egy memóriafolyamba.
MemoryStream workbookStream = workbook.SaveToStream();

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatával.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Tegyük fel, hogy a semmiből szeretnénk prezentációt létrehozni, és bármilyen méretű OLE objektumkeretet szeretnénk hozzáadni beágyazott Excel-munkafüzettel. Az alábbi kódrészletben egy 4 hüvelykes magasságú és 9.5 hüvelykes széles OLE objektumkeretet hozunk létre a dián, x = 0.5 hüvelyk és y = 1 hüvelyk helyen. Ezután az Excel-munkafüzet ablakát ugyanarra a méretre állítjuk – 4 hüvelyk magasra és 9.5 hüvelyk szélesre.

```cs
// A kívánt magasságunk.
int desiredHeight = 288; // 4 hüvelyk (4 * 72)

// A kívánt szélességünk.
int desiredWidth = 684; //9.5 hüvelyk (9.5 * 72)

// Definiálja a diagram méretét egy ablakkal.
chart.SizeWithWindow = true;

// Állítsa be a munkafüzet ablakának szélességét hüvelykben.
workbook.Worksheets.WindowWidthInch = desiredWidth / 72f;

// Állítsa be a munkafüzet ablakának magasságát hüvelykben.
workbook.Worksheets.WindowHeightInch = desiredHeight / 72f;

// Mentse a munkafüzetet egy memóriafolyamba.
MemoryStream workbookStream = workbook.SaveToStream();

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Második megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel-munkafüzetben lévő diagram méretét úgy, hogy az megegyezzen a PowerPoint-dián lévő OLE objektumkeret méretével. Ez a megközelítés akkor hasznos, ha a diagram mérete előre ismert, és soha nem változik.

**Scenario 1**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezhetjük, hogy a sablon 2‑es indexű alakzatában egy OLE keretet szeretnénk elhelyezni, amely beágyazott Excel-munkafüzettel rendelkezik. Ebben a forgatókönyvben az OLE keret mérete előre definiált – megegyezik a sablon 2‑es indexű alakzatának méretével. Csak annyit kell tennünk, hogy a munkafüzetben lévő diagram méretét a forma méretével egyenlővé állítjuk. Az alábbi kódrészlet ezt a célt szolgálja:

```cs
// Definiálja a diagram méretét ablak nélkül. 
chart.SizeWithWindow = false;

// Állítsa be a diagram szélességét pixelekben (szorozza 96-tal, mivel az Excel 96 pixelt használ hüvelykenként).    
chart.ChartObject.Width = (int)((slide.Shapes[2].Width / 72f) * 96f);

// Állítsa be a diagram magasságát pixelekben.
chart.ChartObject.Height = (int)((slide.Shapes[2].Height / 72f) * 96f);

// Definiálja a diagram nyomtatási méretét.
chart.PrintSize = PrintSizeType.Custom;

// Mentse a munkafüzetet egy memóriafolyamba.
MemoryStream workbookStream = workbook.SaveToStream();

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    slide.Shapes[2].X,
    slide.Shapes[2].Y,
    slide.Shapes[2].Width,
    slide.Shapes[2].Height,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

**Scenario 2**

Tegyük fel, hogy a semmiből szeretnénk prezentációt létrehozni, és bármilyen méretű OLE objektumkeretet szeretnénk hozzáadni beágyazott Excel-munkafüzettel. Az alábbi kódrészletben egy 4 hüvelykes magasságú és 9.5 hüvelykes széles OLE objektumkeretet hozunk létre a dián, x = 0.5 hüvelyk és y = 1 hüvelyk helyen. A megfelelő diagram méretét is ugyanarra a méretre állítjuk: 4 hüvelykes magasság és 9.5 hüvelykes szélesség.

```cs
 // A kívánt magasságunk.
int desiredHeight = 288; // 4 hüvelyk (4 * 576)

// A kívánt szélességünk.
int desiredWidth = 684; // 9.5 hüvelyk (9.5 * 576)

// Definiálja a diagram méretét ablak nélkül. 
chart.SizeWithWindow = false;

// Állítsa be a diagram szélességét pixelekben.   
chart.ChartObject.Width = (int)((desiredWidth / 72f) * 96f);

// Állítsa be a diagram magasságát pixelekben.    
chart.ChartObject.Height = (int)((desiredHeight / 72f) * 96f);

// Mentse a munkafüzetet egy memóriafolyamba.
MemoryStream workbookStream = workbook.SaveToStream();

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
Aspose.Slides.OleObjectFrame oleFrame = slide.Shapes.AddOleObjectFrame(
    36,
    72,
    desiredWidth,
    desiredHeight,
	"Excel.Sheet.8",
	workbookStream.ToArray());
```

## **Következtetés**

Két megközelítés létezik a diagram-átméretezési probléma megoldására. A megközelítés választása a követelményektől és az eset használatától függ. Mindkét megközelítés ugyanúgy működik, függetlenül attól, hogy a prezentációk sablonból vagy a semmiből vannak-e létrehozva. Emellett ebben a megoldásban nincs korlátozás az OLE objektumkeret méretére.

## **GYIK**

**Miért változik méretben a beágyazott Excel-diagram, miután aktiváltam a PowerPointban?**
Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretet, míg a PowerPoint OLE objektumkerete saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányokat, ami az átméretezést okozhat.

**Lehet teljesen megelőzni ezt az átméretezési problémát?**
Igen. Ha az Excel-munkafüzet ablakméretét vagy a diagram méretét a beágyazás előtt az OLE objektumkeret méretével egyeztetjük, akkor a diagram méretei állandóak maradnak.

**Melyik megközelítést válasszam, a munkafüzet ablakméretének beállítását vagy a diagram méretének beállítását?**
Használja az **Approach 1 (window size)** megközelítést, ha meg szeretné tartani a munkafüzet arányait, és később esetleg engedélyezni a méretezést.  
Használja az **Approach 2 (chart size)** megközelítést, ha a diagram méretei rögzítettek, és a beágyazás után nem fognak változni.

**Működnek ezek a módszerek mind a sablon-alapú, mind az új prezentációkkal?**
Igen. Mindkét megközelítés ugyanúgy működik a sablonokból és a semmiből létrehozott prezentációk esetén.

**Van korlátozás az OLE objektumkeret méretére?**
Nincs. Az OLE keretet bármilyen méretre beállíthatja, amíg megfelelően skálázódik a munkafüzet vagy a diagram méretéhez.

**Használhatom ezeket a módszereket más táblázatkezelő programokban készült diagramok esetén?**
A példák Excel-diagramokra lettek tervezve, amelyeket az Aspose.Cells készít, de az elvek más OLE-kompatibilis táblázatkezelő programokra is alkalmazhatók, amennyiben azok hasonló méretezési lehetőségeket támogatnak.

## **Kapcsolódó szakaszok**

- [Excel-diagramok létrehozása és OLE objektumként való beágyazása a prezentációkba](/slides/hu/net/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)
- [OLE objektumok automatikus frissítése PowerPoint kiegészítő segítségével](/slides/hu/net/updating-ole-objects-automatically-using-ms-powerpoint-add-in/)