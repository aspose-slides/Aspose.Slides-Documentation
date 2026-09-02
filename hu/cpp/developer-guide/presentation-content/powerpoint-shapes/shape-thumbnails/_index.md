---
title: Diaformák bélyegképeinek létrehozása C++-ban
linktitle: Forma bélyegképek
type: docs
weight: 70
url: /hu/cpp/shape-thumbnails/
keywords:
- forma bélyegkép
- forma kép
- forma renderelése
- forma renderelés
- vizuális határok
- forma határok
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Készítsen magas minőségű forma bélyegképeket a PowerPoint-diákról az Aspose.Slides for C++ használatával – egyszerűen hozhat létre és exportálhat bemutató bélyegképeket."
---
## **Bevezetés**

Az Aspose.Slides arra szolgál, hogy bemutatófájlokat hozzon létre, ahol minden oldal egy dia. Ezeket a diákot a Microsoft PowerPoint segítségével nyithatják meg a bemutatófájlok. De néha a fejlesztőknek külön képolvasóban kell megtekinteniük a formák képeit. Ilyen esetben az Aspose.Slides segít előállítani a diaformák bélyegképét. Ennek a funkciónak a használatát ebben a cikkben írjuk le.  
Ez a cikk bemutatja, hogyan lehet különböző módokon előállítani a diák bélyegképeit:

- Bélyegkép generálása egy formáról a diákon belül.  
- Bélyegkép generálása egy diaformáról felhasználó által meghatározott méretekkel.  
- Bélyegkép generálása a forma megjelenésének határain belül.

## **Bélyegkép generálása egy forma alapján a diához**
A forma bélyegképének előállításához bármely diáról, az Aspose.Slides for C++ használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Szerezze be bármely dia hivatkozását az azonosítója vagy indexe alapján.  
1. Szerezze meg a hivatkozott dia forma bélyegképét alapértelmezett méretezésben.  
1. Mentse el a bélyegkép képet a kívánt képformátumba.  

Az alábbi példa egy forma bélyegképének generálását mutatja.

```cpp
auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage();
image->Save(u"Shape_thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Felhasználó által meghatározott méretezési tényezővel ellátott bélyegkép generálása**
A forma bélyegképének generálásához bármely diaformára az Aspose.Slides for C++ használatával:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Szerezze be bármely dia hivatkozását az azonosítója vagy indexe alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét a forma határának figyelembevételével.  
1. Mentse el a bélyegkép képet a kívánt képformátumba.  

Az alábbi példa felhasználó által meghatározott méretezési tényezővel ellátott bélyegkép generálását mutatja.

```cpp
auto bounds = ShapeThumbnailBounds::Shape;
auto scale = 1; // X és Y tengelyek mentén történő méretezés.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Scaling Factor Thumbnail_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Határoláson alapuló forma megjelenés bélyegkép létrehozása**
Ez a módszer a formák bélyegképeinek létrehozásához lehetővé teszi a fejlesztők számára, hogy a forma megjelenésének határain belül készítsenek bélyegképet. Figyelembe veszi a forma összes effektusát. A generált forma bélyegképét a dia határai korlátozzák. Bármely diaforma megjelenésének határain belüli bélyegkép generálásához használja az alábbi példakódot:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.  
1. Szerezze be bármely dia hivatkozását az azonosítója vagy indexe alapján.  
1. Szerezze meg a hivatkozott dia bélyegképét a forma határainak megjelenésként való használatával.  
1. Mentse el a bélyegkép képet a kívánt képformátumba.  

Az alábbi példa a határoláson alapuló megjelenésű bélyegkép létrehozását mutatja.

```cpp
auto bounds = ShapeThumbnailBounds::Appearance;
auto scale = 1; // X és Y tengelyek mentén történő méretezés.

auto presentation = MakeObject<Presentation>(u"HelloWorld.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto image = shape->GetImage(bounds, scale, scale);
image->Save(u"Shape_thumbnail_Bound_Shape_out.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **A forma tényleges vizuális határainak lekérdezése**

Az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) keret tulajdonságai — `IShape::get_X()`, `IShape::get_Y()`, `IShape::get_Width()`, és `IShape::get_Height()` — leírják a prezentációmodellben tárolt téglalapot. A ténylegesen renderelt tartalom túlnyúlhat ezen a kereten vagy más, tengelyekhez igazított téglalapot foglalhat el. A forgatás, keretek, nyilak, szövegelrendezés és túlcsordulás, a generált SmartArt geometria és egyéb renderelési hatások mind módosíthatják a lefoglalt területet.

Használja a [Shape::GetVisualBounds](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getvisualbounds/) metódust a foglalt terület kiszámításához kép létrehozása nélkül. A metódus egy [RectangleF](https://reference.aspose.com/slides/hu/cpp/system.drawing/rectanglef/) objektumot ad vissza diakoordinátákban. A visszaadott téglalap nincs levágva a diára, ezért koordinátái negatívak lehetnek, ha a tartalom meghaladja a dia kiindulópontját.

A [Shape::GetVisualBounds](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getvisualbounds/) jelenleg nincs deklarálva az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) felületen. Ezért a dián lévő forma gyűjteményéből származó alakzatot tartsa interfész értékként, és csak a metódus hívásakor cast-olja.

Az alábbi példa lekéri és összehasonlítja a keretet és a vizuális határokat:

```cpp
auto presentation = MakeObject<Presentation>(u"example.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto visualBounds = System::AsCast<Shape>(shape)->GetVisualBounds();

System::Drawing::RectangleF frameBounds(
    shape->get_X(), shape->get_Y(), shape->get_Width(), shape->get_Height());

Console::WriteLine(u"Frame bounds: {0}", frameBounds);
Console::WriteLine(u"Visual bounds: {0}", visualBounds);

presentation->Dispose();
```

Ugyanez a [RectangleF](https://reference.aspose.com/slides/hu/cpp/system.drawing/rectanglef/) használható a közeli formák igazításához a `RectangleF::get_Left()`, `RectangleF::get_Right()`, `RectangleF::get_Top()` vagy `RectangleF::get_Bottom()` éléhez; elegendő hely lefoglalásához egy generált elrendezésben; vagy a megengedett régión kívüli tartalom észleléséhez. A vizuális határok különösen hasznosak SmartArt, szövegdobozok, nyilak, képek, forgatott formák és csoportos alakzatok esetén, ahol a tárolt keret nem tükrözi a teljes renderelt eredményt.

Használja a [Shape::GetVisualBounds](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getvisualbounds/) metódust, ha elrendezési vagy validációs koordinátákra van szüksége, és nem igényel bitmapet. Használja az [IShape::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getimage/) metódust, ha a formát renderelni kell. A [ShapeThumbnailBounds](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shapethumbnailbounds/) esetén a `ShapeThumbnailBounds::Shape` a forma határából méretezi a képet, beleértve a keretbeállításokat, míg a `ShapeThumbnailBounds::Appearance` a forma megjelenéséből méretezi, és a diátárolókra korlátozza az eredményt. Ezzel szemben a [Shape::GetVisualBounds](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/getvisualbounds/) csak a számított téglalapot adja vissza, és nem vágja le a diára.

## **GYIK**

**Milyen képfájl-formátumok használhatók a forma bélyegképek mentéséhez?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imageformat/), és egyebek. A formák [exportálhatók vektoriális SVG formátumba](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/writeassvg/) a forma tartalmának SVG-ként való mentésével.

**Mi a különbség a Shape és az Appearance határok között bélyegkép renderelésekor?**  
`Shape` a forma geometriáját használja; `Appearance` a [vizuális effektusokat](/slides/hu/cpp/shape-effect/) (árnyékok, ragyogások stb.) is figyelembe veszi.

**Mi történik, ha egy forma rejtettnek van jelölve? Továbbra is generálható a bélyegképe?**  
A rejtett forma továbbra is része a modellnek, és renderelhető; a rejtett jelző a diavetítés megjelenítését befolyásolja, de nem akadályozza meg a forma képének generálását.

**Támogatottak a csoportos formák, diagramok, SmartArt és egyéb összetett objektumok?**  
Igen. Bármely, [Shape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/shape/)‑ként reprezentált objektum (beleértve a [GroupShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chart/), és [SmartArt](https://reference.aspose.com/slides/hu/cpp/aspose.slides.smartart/smartart/)) menthető bélyegkép vagy SVG formátumban.

**A rendszerben telepített betűtípusok befolyásolják a szöveges formák bélyegképeinek minőségét?**  
Igen. Ajánlott a [szükséges betűtípusok biztosítása](/slides/hu/cpp/custom-font/) (vagy a [betűtípus-helyettesítések beállítása](/slides/hu/cpp/font-substitution/)), hogy elkerülje a nem kívánt fallback‑eket és a szöveg újbóli elrendezését.