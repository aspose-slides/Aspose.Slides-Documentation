---
title: SmartArt alakzat csomópontok kezelése prezentációkban C++ használatával
linktitle: SmartArt alakzat csomópont
type: docs
weight: 30
url: /hu/cpp/manage-smartart-shape-node/
keywords:
- SmartArt csomópont
- gyermekcsomópont
- csomópont hozzáadása
- csomópont pozíció
- csomópont elérése
- csomópont eltávolítása
- egyéni pozíció
- asszisztens csomópont
- kitöltési formátum
- csomópont renderelése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "SmartArt alakzat csomópontok kezelése PPT és PPTX fájlokban az Aspose.Slides for C++ segítségével. Kapjon világos kódmintákat és tippeket a prezentációk egyszerűsítéséhez."
---
## **Áttekintés**

A PowerPoint‑prezentációkban a SmartArt grafikákat olyan csomópontok szervezik, amelyek szöveget tartalmaznak és meghatározzák a diagram felépítését. Az Aspose.Slides lehetővé teszi ezen SmartArt csomópontok programozott kezelését: új csomópontok és gyermekcsomópontok hozzáadása, gyermekcsomópontok beszúrása egy adott pozícióba, meglévő csomópontok elérése, valamint szövegük, szintjük és pozíciójuk kiolvasása.

Ez a cikk bemutatja, hogyan kezelhetők a SmartArt alakzat csomópontok. Megmutatja, hogyan távolíthatók el csomópontok, hogyan dolgozhatunk gyermekcsomópontokkal index vagy pozíció alapján, hogyan változtatható meg egy asszisztens csomópont normál csomópontra, hogyan állítható be a SmartArt csomópont alakzatok pozíciója, mérete és forgatása, hogyan állítható be a csomópont kitöltési formátuma, valamint hogyan generálhatunk bélyegképet egy SmartArt gyermekcsomóponthoz.

## **SmartArt csomópont hozzáadása**
Az Aspose.Slides for C++ a legegyszerűbb API‑t biztosítja a SmartArt alakzatok kezeléséhez a legegyszerűbb módon. Az alábbi példakód segít csomópontot és gyermekcsomópontot hozzáadni egy SmartArt alakzathoz.

- Hozzon létre egy példányt a[Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia referenciáját az Index használatával.
- Iteráljon végig minden alakzaton az első dián.
- Ellenőrizze, hogy az alakzat SmartArt típusú‑e, és ha igen, típuscastolja a kiválasztott alakzatot SmartArt‑ra.
- Adjon hozzá egy új csomópontot a SmartArt alakzat NodeCollection‑jéhez, és állítsa be a szöveget a TextFrame‑ben.
- Ezután adjon hozzá egy gyermekcsomópontot az újonnan hozzáadott SmartArt csomóponthoz, és állítsa be a szöveget a TextFrame‑ben.
- Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodes-AddNodes.cpp" >}}

## **SmartArt csomópont hozzáadása egy adott pozícióban**
Az alábbi példakódban bemutatjuk, hogyan adhatók hozzá a gyermekcsomópontok a SmartArt alakzat megfelelő csomópontjaihoz egy meghatározott pozícióban.

- Hozzon létre egy példányt a`Presentation` osztályból.
- Szerezze meg az első dia referenciáját az Index használatával.
- Adjon hozzá egy StackedList típusú SmartArt alakzatot a megnyitott diára.
- Hozzáférés az hozzáadott SmartArt alakzat első csomópontjához.
- Ezután adja hozzá a gyermekcsomópontot a kiválasztott csomóponthoz a 2. pozícióban, és állítsa be a szövegét.
- Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNodesSpecificPosition-AddNodesSpecificPosition.cpp" >}}

## **SmartArt csomópont elérése**
Az alábbi példakód segít elérni a SmartArt alakzaton belüli csomópontokat. Kérjük, vegye figyelembe, hogy a SmartArt LayoutType‑ját nem módosíthatja, mivel csak olvasható, és csak a SmartArt alakzat hozzáadásakor állítható be.

- Hozzon létre egy példányt a`Presentation` osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia referenciáját az Index használatával.
- Iteráljon végig minden alakzaton az első dián.
- Ellenőrizze, hogy az alakzat SmartArt típusú‑e, és ha igen, típuscastolja a kiválasztott alakzatot SmartArt‑ra.
- Iteráljon végig az összes csomóponton a SmartArt alakzaton belül.
- Hozzáférés és megjelenítés olyan információkhoz, mint a SmartArt csomópont pozíciója, szintje és szövege.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessSmartArt-AccessSmartArt.cpp" >}}

## **SmartArt gyermekcsomópont elérése**
Az alábbi példakód segít elérni a SmartArt alakzaton belüli csomópontokhoz tartozó gyermekcsomópontokat.

- Hozzon létre egy példányt a PresentationEx osztályból, és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia referenciáját az Index használatával.
- Iteráljon végig minden alakzaton az első dián.
- Ellenőrizze, hogy az alakzat SmartArt típusú‑e, és ha igen, típuscastolja a kiválasztott alakzatot SmartArtEx‑re.
- Iteráljon végig az összes csomóponton a SmartArt alakzaton belül.
- Minden kiválasztott SmartArt alakzat csomópont esetén iteráljon végig az adott csomópont összes gyermekcsomópontján.
- Hozzáférés és megjelenítés olyan információkhoz, mint a gyermekcsomópont pozíciója, szintje és szövege.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodes-AccessChildNodes.cpp" >}}

## **SmartArt gyermekcsomópont elérése egy adott pozícióban**
Ebben a példában megtanuljuk, hogyan érhetők el a gyermekcsomópontok egy adott pozícióban, amelyek a SmartArt alakzat megfelelő csomópontjaihoz tartoznak.

- Hozzon létre egy példányt a`Presentation` osztályból.
- Szerezze meg az első dia referenciáját az Index használatával.
- Adjon hozzá egy StackedList típusú SmartArt alakzatot.
- Hozzáférés a hozzáadott SmartArt alakzathoz.
- Hozzáférés a 0 indexű csomóponthoz a hozzáfért SmartArt alakzatban.
- Ezután a GetNodeByPosition() metódus használatával érje el a 1. pozícióban lévő gyermekcsomópontot a hozzáfért SmartArt csomópontnál.
- Hozzáférés és megjelenítés olyan információkhoz, mint a gyermekcsomópont pozíciója, szintje és szövege.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessChildNodeSpecificPosition-AccessChildNodeSpecificPosition.cpp" >}}

## **SmartArt csomópont eltávolítása**
Ebben a példában megtanuljuk, hogyan távolíthatók el a csomópontok a SmartArt alakzaton belül.

- Hozzon létre egy példányt a`Presentation` osztályból és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia referenciáját az Index használatával.
- Iteráljon végig minden alakzaton az első dián.
- Ellenőrizze, hogy az alakzat SmartArt típusú‑e, és ha igen, típuscastolja a kiválasztott alakzatot SmartArt‑ra.
- Ellenőrizze, hogy a SmartArt csomópontjainak száma nagyobb‑e, mint 0.
- Válassza ki a törlendő SmartArt csomópontot.
- Ezután a kiválasztott csomópontot a RemoveNode() metódussal távolítsa el* Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNode-RemoveNode.cpp" >}}

## **SmartArt csomópont eltávolítása egy adott pozícióban**
Ebben a példában megtanuljuk, hogyan távolíthatók el a csomópontok a SmartArt alakzaton belül egy adott pozícióban.

- Hozzon létre egy példányt a`Presentation` osztályból és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg az első dia referenciáját az Index használatával.
- Iteráljon végig minden alakzaton az első dián.
- Ellenőrizze, hogy az alakzat SmartArt típusú‑e, és ha igen, típuscastolja a kiválasztott alakzatot SmartArt‑ra.
- Válassza ki a SmartArt alakzat 0 indexű csomópontját.
- Ezután ellenőrizze, hogy a kiválasztott SmartArt csomópontnak több mint 2 gyermekcsomópontja van‑e.
- Ezután a RemoveNodeByPosition() metódussal távolítsa el az 1. pozícióban lévő csomópontot.
- Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNodeSpecificPosition-RemoveNodeSpecificPosition.cpp" >}}

## **Egyéni pozíció beállítása egy SmartArt gyermekcsomópont számára**
Az Aspose.Slides most támogatja a SmartArtShape X és Y tulajdonságok beállítását. Az alábbi kódrészlet megmutatja, hogyan állítható be egyedi SmartArtShape pozíció, méret és forgatás, és kérjük, vegye figyelembe, hogy új csomópontok hozzáadása az összes csomópont pozíciójának és méretének újraszámítását eredményezi.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CustomChildNodesInSmartArt-CustomChildNodesInSmartArt.cpp" >}}

## **Asszisztens csomópont ellenőrzése**
Az alábbi példakódban megvizsgáljuk, hogyan azonosíthatók az Assistant (asszisztens) csomópontok a SmartArt csomópontgyűjteményben, és hogyan módosíthatók.

- Hozzon létre egy példányt a PresentationEx osztályból és töltse be a prezentációt SmartArt alakzattal.
- Szerezze meg a második dia referenciáját az Index használatával.
- Iteráljon végig minden alakzaton az első dián.
- Ellenőrizze, hogy az alakzat SmartArt típusú‑e, és ha igen, típuscastolja a kiválasztott alakzatot SmartArtEx‑re.
- Iteráljon végig az összes csomóponton a SmartArt alakzaton belül, és ellenőrizze, hogy ezek Assistant csomópontok‑e.
- Módosítsa az Assistant csomópont állapotát normál csomópontra.
- Mentse a prezentációt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AssistantNode-AssistantNode.cpp" >}}

## **Csomópont kitöltési formátumának beállítása**
Az Aspose.Slides for C++ lehetővé teszi egyedi SmartArt alakzatok hozzáadását és azok kitöltési formátumának beállítását. Ez a cikk bemutatja, hogyan hozhatók létre és érhetők el a SmartArt alakzatok, valamint hogyan állítható be a kitöltési formátum az Aspose.Slides for C++ használatával.

Kérjük, kövesse az alábbi lépéseket:

- Hozzon létre egy példányt a`Presentation` osztályból.
- Szerezze meg egy dia referenciáját az index használatával.
- Adjon hozzá egy SmartArt alakzatot a LayoutType beállításával.
- Állítsa be a FillFormat‑ot a SmartArt alakzat csomópontjaihoz.
- Írja ki a módosított prezentációt PPTX fájlként.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FillFormatSmartArtShapeNode-FillFormatSmartArtShapeNode.cpp" >}}

## **SmartArt gyermekcsomópont előnézeti képe generálása**
A fejlesztők a következő lépések követésével generálhatnak előnézeti képet egy SmartArt gyermekcsomópontról:

1. Példányosítson egy`Presentation` osztályt, amely a PPTX fájlt képviseli.
2. Adjon hozzá SmartArt‑ot.
3. Szerezze meg egy csomópont referenciáját az Index használatával
4. Szerezze meg a bélyegkép képet.
5. Mentse a bélyegképet tetszőleges képf formátumban.

Az alábbi példa egy SmartArt gyermekcsomópont bélyegképének generálását mutatja

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto smartArt = slide->get_Shapes()->AddSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicCycle);
auto node = smartArt->get_Node(1);

auto image = node->get_Shape(0)->GetImage();
image->Save(u"SmartArt_ChildNote_Thumbnail_out.jpeg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **FAQ**

**Támogatott a SmartArt animáció?**

Igen. A SmartArt‑ot normál alakzatként kezelik, így [alkalmazhat szabványos animációkat](/slides/hu/cpp/shape-animation/) (belépés, kilépés, hangsúlyozás, mozgási útvonalak) és beállíthatja az időzítést. Szükség esetén animálhatja a SmartArt csomópontok belül lévő alakzatokat is.

**Hogyan találhatok megbízhatóan egy adott SmartArt‑ot a dián, ha a belső azonosítója ismeretlen?**

Rendeljen és keressen [alternatív szöveg](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/set_alternativetext/) alapján. Egy egyedi AltText beállítása a SmartArt‑hoz lehetővé teszi, hogy programozottan megtalálja anélkül, hogy a belső azonosítókra támaszkodna.

**Megmarad a SmartArt megjelenése, ha a prezentációt PDF‑re konvertálják?**

Igen. Az Aspose.Slides magas vizuális pontossággal rendereli a SmartArt‑ot a[PDF export](/slides/hu/cpp/convert-powerpoint-to-pdf/) során, megtartva a elrendezést, színeket és effektusokat.

**Kivonhatok képet az egész SmartArt‑ról (előnézethez vagy jelentésekhez)?**

Igen. A SmartArt alakzatot renderelheti [raszteres formátumokba](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getimage/) vagy [SVG‑be](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) skálázható vektor kimenetként, ami alkalmas bélyegképek, jelentések vagy webes felhasználásra.