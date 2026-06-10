---
title: Működő megoldás a diagram átméretezésére PPTX-ben
type: docs
weight: 60
url: /hu/cpp/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Javítsa a PPTX-ben a beágyazott Excel OLE objektumok használatakor előforduló váratlan diagram átméretezést az Aspose.Slides for C++ segítségével. Ismerjen meg két módszert kóddal a méretek egységességének megtartásához."
---
## **Háttér**

Megfigyelés szerint az Aspose komponenseken keresztül PowerPoint‑prezentációba OLE objektumként beágyazott Excel‑diagramok az első aktiválásuk után nem meghatározott méretarámba kerülnek. Ez a viselkedés észrevehető vizuális eltérést okoz a diagram aktiválás előtti és utáni állapota között. Az Aspose csapata részletesen vizsgálta a problémát, és megoldást talált. Ez a cikk leírja a probléma okait és a megfelelő javítást.

Az [előző cikkben](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) elmagyaráztuk, hogyan hozhatunk létre Excel‑diagramot az Aspose.Cells for C++ segítségével, és hogyan ágyazhatjuk be azt PowerPoint‑prezentációba az Aspose.Slides for C++ használatával. Az [objektum előnézeti problémájának](/slides/hu/cpp/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a diagram képét az OLE objektumkerethez rendeltük. A kimeneti prezentációban, ha duplán kattintunk a diagram képet megjelenítő OLE objektumkeretre, az Excel‑diagram aktiválódik. A végfelhasználók a háttérben lévő Excel‑munkafüzetben tetszőleges módosításokat végezhetnek, majd az aktivált munkafüzeten kívül kattintva visszatérhetnek a megfelelő diára. Az OLE objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési arány a OLE objektumkeret és a beágyazott Excel‑munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

Mivel az Excel‑munkafüzetnek saját ablakmérete van, az első aktiváláskor megpróbálja megtartani az eredeti méretét. Az OLE objektumkeretnek azonban saját mérete van. A Microsoft szerint, amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik a méretet, és az ágyazási folyamat részeként megőrzik a helyes arányokat. Az Excel‑ablakméret és az OLE objektumkeret mérete vagy pozíciója közötti eltérések hatására történik az átméretezés.

## **Működő megoldás**

Az Aspose.Slides for C++ használatával PowerPoint‑prezentációk létrehozására két lehetséges forgatókönyv létezik.

**Scenario 1:** Létrehozni egy prezentációt meglévő sablon alapján.  
**Scenario 2:** Újról, semmiből létrehozni egy prezentációt.

Az itt bemutatott megoldás mindkét forgatókönyvre alkalmazható. Minden megoldási megközelítés alappillére ugyanaz: **a beágyazott OLE objektum ablakméretének meg kell egyeznie a PowerPoint‑dia OLE objektumkeretével**. Most a megoldás két megközelítését fogjuk bemutatni.

## **Első megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel‑munkafüzet ablakméretét úgy, hogy az megegyezzen a PowerPoint‑dia OLE objektumkeretének méretével.

**Scenario 1**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján kívánunk prezentációkat létrehozni. Feltételezzük, hogy a sablonban a 2. indexű alakzatnál OLE‑keretet szeretnénk elhelyezni, amely beágyazott Excel‑munkafüzetet tartalmaz. Ebben a forgatókönyvben az OLE objektumkeret mérete előre meghatározott – megegyezik a sablonban a 2. indexű alakzat méretével. Csak annyi a teendő, hogy a munkafüzet ablakméretét egyenlővé tegyük ezzel az alakzattal. A következő kódrészlet erre szolgál:

```cpp
System::SharedPtr<System::IO::MemoryStream> ToSlidesMemoryStream(intrusive_ptr<Aspose::Cells::Systems::IO::MemoryStream> inputStream)
{
    auto outputBuffer = System::MakeArray<uint8_t>(inputStream->GetLength(), inputStream->GetBuffer()->ArrayPoint());
    auto outputStream = System::MakeObject<System::IO::MemoryStream>(outputBuffer);

    return outputStream;
}
```

```cpp
// Definiálja a diagram méretét egy ablakban. 
chart->SetSizeWithWindow(true);

auto shape = slide->get_Shape(2);

// Állítsa be a munkafüzet ablakszélességét hüvelykben (72-tel osztva, mivel a PowerPoint hüvelykenként 72 képpontot használ).
workbook->GetISettings()->SetWindowWidthInch(shape->get_Width() / 72.f);

// Állítsa be a munkafüzet ablakmagasságát hüvelykben.
workbook->GetISettings()->SetWindowHeightInch(shape->get_Height() / 72.f);

// Mentse a munkafüzetet egy memóriaáramra.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream3(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(), 
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**

Tegyük fel, hogy semmiből szeretnénk prezentációt készíteni, és tetszőleges méretű OLE objektumkeretet szeretnénk hozzáadni beágyazott Excel‑munkafüzettel. A következő kódrészletben létrehozunk egy 4 hüvelyk magas és 9,5 hüvelyk széles OLE objektumkeretet az x = 0,5 hüvelyk, y = 1 hüvelyk pozícióban a dián. Ezután az Excel‑munkafüzet ablakát ugyanarra a méretre állítjuk – 4 hüvelyk magasra és 9,5 hüvelyk szélesre.

```cpp
// A kívánt magasság.
int32_t desiredHeight = 288; // 4 hüvelyk (4 * 72)

// A kívánt szélesség.
int32_t desiredWidth = 684; // 9,5 hüvelyk (9.5 * 72)

// Definiálja a diagram méretét egy ablakban. 
chart->SetSizeWithWindow(true);

// Állítsa be a munkafüzet ablakszélességét hüvelykben.
workbook->GetISettings()->SetWindowWidthInch(desiredWidth / 72.f);

// Állítsa be a munkafüzet ablakmagasságát hüvelykben.
workbook->GetISettings()->SetWindowHeightInch(desiredHeight / 72.f);

// Mentse a munkafüzetet egy memóriaáramra.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f,
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Második megközelítés**

Ebben a megközelítésben megtanuljuk, hogyan állítsuk be a beágyazott Excel‑munkafüzetben lévő diagram méretét úgy, hogy az megegyezzen a PowerPoint‑dia OLE objektumkeretének méretével. Ez a megközelítés akkor hasznos, ha a diagram mérete előre ismert, és soha nem változik.

**Scenario 1**

Tegyük fel, hogy definiáltunk egy sablont, és annak alapján szeretnénk prezentációkat létrehozni. Feltételezzük, hogy a sablonban a 2. indexű alakzatnál OLE‑keretet kívánunk elhelyezni, amely beágyazott Excel‑munkafüzetet tartalmaz. Ebben a forgatókönyvben az OLE keret mérete előre meghatározott – megegyezik a 2. indexű alakzat méretével a sablonban. Csak annyi a feladat, hogy a munkafüzetben a diagram méretét ugyanolyanra állítsuk, mint az alakzat mérete. A következő kódrészlet erre szolgál:

```cpp
// Határozza meg a diagram méretét ablak nélkül. 
chart->SetSizeWithWindow(false);

auto shape = slide->get_Shape(2);

// Állítsa be a diagram szélességét pixelben (szorozza 96-tal, mivel az Excel hüvelykenként 96 pixelt használ).    
chart->GetIChartObject()->SetWidth((int32_t)(shape->get_Width() / 72.f * 96.f));

// Állítsa be a diagram magasságát pixelben.
chart->GetIChartObject()->SetHeight((int32_t)(shape->get_Height() / 72.f) * 96.f);

// Határozza meg a diagram nyomtatási méretét.
chart->SetPrintSize(Aspose::Cells::PrintSizeType::PrintSizeType_Custom);

// Mentse a munkafüzetet memóriaáramra.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    shape->get_X(), 
    shape->get_Y(), 
    shape->get_Width(),
    shape->get_Height(),
    dataInfo);
```

**Scenario 2**

Tegyük fel, hogy semmiből szeretnénk prezentációt létrehozni, és tetszőleges méretű OLE objektumkeretet adunk hozzá beágyazott Excel‑munkafüzettel. A következő kódrészletben létrehozunk egy 4 hüvelyk magas és 9,5 hüvelyk széles OLE objektumkeretet a dián, ahol x = 0,5 hüvelyk, y = 1 hüvelyk. A megfelelő diagram méretét is ugyanarra a méretre állítjuk: 4 hüvelyk magasra és 9,5 hüvelyk szélesre.

```cpp
// A kívánt magasság.
int32_t desiredHeight = 288; // 4 hüvelyk (4 * 576)

// A kívánt szélesség.
int32_t desiredWidth = 684; // 9,5 hüvelyk(9.5 * 576)

// Határozza meg a diagram méretét ablak nélkül. 
chart->SetSizeWithWindow(false);

// Állítsa be a diagram szélességét pixelben.    
chart->GetIChartObject()->SetWidth((int32_t)((desiredWidth / 72.f) * 96.f));

// Állítsa be a diagram magasságát pixelben.
chart->GetIChartObject()->SetHeight((int32_t)((desiredHeight / 72.f) * 96.f));

// Mentse a munkafüzetet memóriaáramra.
System::SharedPtr<System::IO::MemoryStream> workbookStream = ToSlidesMemoryStream(workbook->SaveToStream());

System::SharedPtr<IOleEmbeddedDataInfo> dataInfo = System::MakeObject<OleEmbeddedDataInfo>(workbookStream->ToArray(), u"xls");

// Hozzon létre egy OLE objektumkeretet a beágyazott Excel adatokkal.
System::SharedPtr<IOleObjectFrame> oleFrame = slide->get_Shapes()->AddOleObjectFrame(
    36.0f, 
    72.0f, 
    desiredWidth, 
    desiredHeight,
    dataInfo);
```

## **Következtetés**

Két megközelítés létezik a diagram-átméretezési probléma megoldására. A választott megközelítés a követelményektől és az esettől függ. Mindkét módszer ugyanúgy működik, függetlenül attól, hogy a prezentációt sablonból vagy semmiből hozták létre. Emellett nincs korlátozás az OLE objektumkeret méretére ebben a megoldásban.

## **GYIK**

**Miért változik méretben a beágyazott Excel‑diagram a PowerPoint‑ban történő aktiválás után?**  
Ez azért történik, mert az Excel az első aktiváláskor megpróbálja visszaállítani az eredeti ablakméretét, míg a PowerPoint‑ban az OLE objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel egyeztetik a méretet, hogy megőrizzék az arányt, ami az átméretezést okozhat.

**Lehetséges-e teljesen megakadályozni ezt az átméretezési problémát?**  
Igen. Az Excel‑munkafüzet ablakméretének vagy a diagram méretének a OLE objektumkeret méretéhez igazításával a beágyazás előtt a diagram méretei konzisztensen maradhatnak.

**Melyik megközelítést válasszam, a munkafüzet ablakméretének beállítását vagy a diagram méretének beállítását?**  
Használja a **1. megközelítést (ablakméret)**, ha meg szeretné őrizni a munkafüzet arányait, és esetleg később engedélyezni a méretezést.  
Használja a **2. megközelítést (diagramméret)**, ha a diagram méretei rögzítettek, és a beágyazás után nem változnak.

**Működnek-e ezek a módszerek sablon‑alapú és új prezentációkkal egyaránt?**  
Igen. Mindkét megközelítés ugyanúgy működik a sablonból és a semmiből létrehozott prezentációk esetében.

**Van korlátozás az OLE objektumkeret méretére?**  
Nincs. Az OLE keretet bármilyen méretre beállíthatja, ameddig megfelelően skálázódik a munkafüzet vagy a diagram méretéhez.

**Használhatom ezeket a módszereket más táblázatkezelő programokkal létrehozott diagramokkal is?**  
A példák Excel‑diagramokra vonatkoznak, amelyeket az Aspose.Cells készít, de az elvek más OLE‑kompatibilis táblázatprogramokra is alkalmazhatók, ha támogatják a hasonló méretezési beállításokat.

## **Kapcsolódó szakaszok**

- [Excel diagramok létrehozása és OLE objektumként való beágyazása prezentációkba](/slides/hu/cpp/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)