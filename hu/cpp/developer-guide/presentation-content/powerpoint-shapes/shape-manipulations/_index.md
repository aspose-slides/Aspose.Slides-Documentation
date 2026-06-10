---
title: Prezentációk alakzatainak kezelése C++-ban
linktitle: Alakzatkezelés
type: docs
weight: 40
url: /hu/cpp/shape-manipulations/
keywords:
- PowerPoint alakzat
- prezentációs alakzat
- alakzat a dián
- alakzat keresése
- alakzat klónozása
- alakzat eltávolítása
- alakzat elrejtése
- alakzat sorrendjének módosítása
- interop alakzat-azonosító lekérése
- alakzat alternatív szöveg
- alakzat elrendezési formátumok
- alakzat SVG-ként
- alakzat SVG-be
- alakzat igazítása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre, szerkeszthet és optimalizálhat alakzatokat az Aspose.Slides for C++ használatával, és szállíthat nagy teljesítményű PowerPoint prezentációkat."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk alakzatokkal a prezentációkban az Aspose.Slides használatával. Bemutatja, hogyan találhatunk egy alakzatot egy dián, hogyan klónozhatjuk, hogyan távolíthatjuk el, hogyan rejthetjük el, hogyan változtathatjuk meg a sorrendjét, hogyan kérhetjük le az Interop alakzat-azonosítót, és hogyan állíthatunk be alternatív szöveget az azonosításhoz és további feldolgozáshoz.

Emellett bemutatja, hogyan érhetjük el az alakzatok elrendezési formátumait, hogyan renderelhetünk egy alakzatot SVG‑ként, hogyan igazíthatjuk az alakzatokat egy dián, és hogyan használhatjuk a flip tulajdonságokat a vízszintes és függőleges tükrözéshez. Továbbá a cikk tartalmaz egy rövid GYIK‑ot az alakzatok kombinálásáról, a rétegezési sorrendről és az alakzatok zárolásáról.

## **Alakzat megtalálása egy dián**
Ez a téma egy egyszerű technikát mutat be, amely megkönnyíti a fejlesztők számára egy adott alakzat megtalálását a dián anélkül, hogy a belső azonosítót használnák. Fontos tudni, hogy a PowerPoint prezentációfájlok nem rendelkeznek olyan módszerrel, amely a belső egyedi azonosító mellett más módon azonosítaná az alakzatokat a dián. Úgy tűnik, a fejlesztők számára nehéz egy alakzatot megtalálni a belső egyedi azonosító használatával. Minden diára hozzáadott alakzathoz tartozik valamilyen alternatív szöveg. Javasoljuk a fejlesztőknek, hogy alternatív szöveget használjanak egy adott alakzat megtalálásához. Az MS PowerPoint segítségével megadhatja azoknak az objektumoknak az alternatív szövegét, amelyeket a jövőben módosítani kíván.

Miután beállította egy kívánt alakzat alternatív szövegét, megnyithatja a prezentációt az Aspose.Slides for C++ segítségével, és végigiterálhat a diára hozzáadott összes alakzaton. Minden iteráció során ellenőrizheti az alakzat alternatív szövegét, és a megfelelő alternatív szöveggel rendelkező alakzat lesz a keresett. A technika jobb bemutatásához létrehoztunk egy [FindShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) metódust, amely megoldja egy adott alakzat megtalálását egy dián, és egyszerűen visszaadja azt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **Alakzat klónozása**
Alakzat klónozásához egy diára az Aspose.Slides for C++ használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Szerezze be egy dia referenciaját az indexének használatával.
3. Hozzáférés a forrásdia alakzategyűjteményéhez.
4. Adjon hozzá egy új diát a prezentációhoz.
5. Klónozza az alakzatokat a forrásdia alakzategyűjteményéből az új diára.
6. Mentse a módosított prezentációt PPTX fájlként.

Az alábbi példa egy csoportos alakzatot ad hozzá egy diához.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **Alakzat eltávolítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy bármely alakzatot eltávolítsanak. Egy alakzat eltávolításához bármely diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Hozzáférés az első diához.
3. Keresse meg a megadott AlternativeText tulajdonságú alakzatot.
4. Távolítsa el az alakzatot.
5. Mentse el a fájlt a lemezen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **Alakzat elrejtése**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy bármely alakzatot elrejtsenek. Egy alakzat elrejtéséhez bármely diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Hozzáférés az első diához.
3. Keresse meg a megadott AlternativeText tulajdonságú alakzatot.
4. Rejtse el az alakzatot.
5. Mentse el a fájlt a lemezen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **Alakzat sorrendjének módosítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy átrendezzék az alakzatokat. Az alakzat átrendezése meghatározza, melyik alakzat van elöl vagy hátul. Az alakzat átrendezéséhez bármely diáról kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Hozzáférés az első diához.
3. Adj hozzá egy alakzatot.
4. Adj hozzá szöveget az alakzat szövegkeretébe.
5. Adj hozzá egy másik alakzatot ugyanazzal a koordinátával.
6. Rendezd át az alakzatokat.
7. Mentse el a fájlt a lemezen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **Interop alakzat-azonosító lekérése**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy egyedi alakzat-azonosítót szerezzék meg a diára vonatkozóan, szemben a UniqueId tulajdonsággal, amely a prezentáció szintjén biztosít egyedi azonosítót. Az OfficeInteropShapeId tulajdonság hozzá lett adva az IShape interfészekhez és a Shape osztályhoz. Az OfficeInteropShapeId tulajdonság által visszaadott érték megfelel a Microsoft.Office.Interop.PowerPoint.Shape objektum Id értékének. Az alábbiakban a mintakód látható.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **AlternativeText tulajdonság beállítása**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy bármely alakzat AlternateText értékét beállítsák. Az AlternateText beállításához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból.
2. Hozzáférés az első diához.
3. Adj hozzá egy tetszőleges alakzatot a diához.
4. Végezzen némi műveletet az újonnan hozzáadott alakzattal.
5. Járja be az alakzatokat, hogy megtaláljon egy adottat.
6. Állítsa be az AlternativeText-et.
7. Mentse el a fájlt a lemezen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **Elrendezési formátumok elérése egy alakzathoz**
Az Aspose.Slides for C++ lehetővé teszi a fejlesztők számára, hogy elérjék egy alakzat elrendezési formátumait. Ez a cikk bemutatja, hogyan érheti el egy alakzat **FillFormat** és **LineFormat** tulajdonságait.

Az alábbiakban a mintakód látható.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **Alakzat renderelése SVG‑ként**
Az Aspose.Slides for C++ most támogatja egy alakzat SVG‑ként való renderelését. A WriteAsSvg metódus (és annak túlterhelése) hozzá lett adva a Shape osztályhoz és az IShape interfészhez. Ez a metódus lehetővé teszi az alakzat tartalmának SVG fájlként való mentését. Az alábbi kódrészlet bemutatja, hogyan exportálhatjuk egy dia alakzatát SVG fájlba.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **Alakzatok igazítása**
Az Aspose.Slides lehetővé teszi az alakzatok igazítását a dia margóival vagy egymáshoz viszonyítva. Ehhez egy túlterhelt [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) metódust adtunk hozzá. A [ShapesAlignmentType](https://reference.aspose.com/slides/hu/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) felsorolás definiálja a lehetséges igazítási opciókat.

**Példa 1**

Az alábbi forráskód a 1, 2 és 4 indexű alakzatokat a dia felső szélén igazítja.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**Példa 2**

Az alábbi példa azt mutatja, hogyan igazítható a teljes alakzategyűjtemény a gyűjtemény legalsó alakzatához viszonyítva.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **Flip tulajdonságok**

Az Aspose.Slides-ben a [ShapeFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeframe/) osztály biztosítja a vízszintes és függőleges tükrözés szabályozását az alakzat `flipH` és `flipV` tulajdonságain keresztül. Mindkét tulajdonság a [NullableBool](https://reference.aspose.com/slides/hu/cpp/aspose.slides/nullablebool/) típusa, amely `True` értékkel jelzi a tükrözést, `False` a nem tükrözést, vagy `NotDefined` a alapértelmezett viselkedés használatát. Ezek az értékek az alakzat [Frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_frame/) tulajdonságán keresztül érhetők el.

A flip beállítások módosításához egy új [ShapeFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapeframe/) példányt hozunk létre az alakzat jelenlegi pozíciójával és méretével, a kívánt `flipH` és `flipV` értékekkel, valamint a forgatási szöggel. Ennek a példánynak a shape [Frame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/get_frame/) tulajdonságához való hozzárendelése és a prezentáció mentése alkalmazza a tükrözési transzformációkat és a kimeneti fájlba írja őket.

Tegyük fel, hogy van egy sample.pptx fájlunk, amelynek első dia egyetlen alakzatot tartalmaz alapértelmezett flip beállításokkal, az alábbiakban látható.

![A tükrözendő alakzat](shape_to_be_flipped.png)

A következő kódrészlet lekéri az alakzat jelenlegi flip tulajdonságait és vízszintesen és függőlegesen is tükrözi azt.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// Az alakzat vízszintes tükrözés tulajdonságának lekérése.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// Az alakzat függőleges tükrözés tulajdonságának lekérése.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // Vízszintesen tükröz.
auto flipV = NullableBool::True; // Vízszintesen tükröz.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![A tükrözött alakzat](flipped_shape.png)

## **GYIK**

**Kombinálhatok‑e alakzatokat (unió/keresztezés/kivonás) egy dián, mint egy asztali szerkesztőben?**  
Nincs beépített Boolean művelet API. Megközelíthető azzal, hogy saját maga építi meg a kívánt körvonalat – például kiszámítja az eredményes geometriát (a [GeometryPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides/geometrypath/) használatával), és létrehoz egy új alakzatot ezzel a körvonallal, opcionálisan eltávolítva az eredetieket.

**Hogyan szabályozhatom a rétegsorrendet (z‑order), hogy egy alakzat mindig a "tetején" maradjon?**  
Módosítsa a beszúrási/mozgatási sorrendet a dia [shapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseslide/get_shapes/) gyűjteményén belül. A kiszámítható eredményekért a z‑sorrendet a többi dia módosítás után finalizálja.

**Le tudom‑e "zárolni" egy alakzatot, hogy a felhasználók ne szerkeszthessék PowerPointban?**  
Igen. Állítsa be a [shape-level protection flags](/slides/hu/cpp/applying-protection-to-presentation/) (pl. a kijelölés, mozgatás, átméretezés, szövegszerkesztés zárolását). Szükség esetén tükrözze a korlátozásokat a master vagy layout szinten. Vegye figyelembe, hogy ez UI‑szintű védelem, nem biztonsági funkció; erősebb védelemhez kombinálja fájlszintű korlátozásokkal, mint a [csak‑olvasás ajánlás vagy jelszó](/slides/hu/cpp/password-protected-presentation/).