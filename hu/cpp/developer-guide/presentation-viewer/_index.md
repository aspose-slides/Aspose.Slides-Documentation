---
title: Prezentáció megjelenítő létrehozása C++-ban
linktitle: Prezentáció megjelenítő
type: docs
weight: 50
url: /hu/cpp/presentation-viewer/
keywords:
- prezentáció megtekintése
- prezentáció megjelenítő
- prezentáció megjelenítő létrehozása
- PPT megtekintése
- PPTX megtekintése
- ODP megtekintése
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Egy egyedi prezentáció megjelenítőt hoz létre C++-ban az Aspose.Slides használatával. Könnyedén jeleníthető meg a PowerPoint és az OpenDocument fájlok a Microsoft PowerPoint nélkül."
---
## **Bevezetés**

Az Aspose.Slides for C++ a prezentációs fájlok diák létrehozásához használható. Ezek a diák megtekinthetők például a Microsoft PowerPoint programban történő prezentációk megnyitásával. Néha azonban a fejlesztőknek szükségük lehet arra, hogy a diák képekként jelenjenek meg a kedvenc képnézőjükben, vagy saját prezentációmegjelenítőt készítsenek. Ilyen esetben az Aspose.Slides lehetővé teszi egyetlen dia kép formátumba exportálását. Ez a cikk leírja, hogyan kell ezt megtenni.

## **SVG kép generálása diából**

Az Aspose.Slides használatával egy prezentációs diából SVG képet generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Nyisson meg egy fájlfolyamot.
1. Mentse a diát SVG képként a fájlfolyamra.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream);
svgStream->Dispose();

presentation->Dispose();
```

## **SVG generálása egyedi alakzat-azonosítóval**

Az Aspose.Slides használható egy diáról egy egyedi alakzat-azonosítóval rendelkező [SVG](https://docs.fileformat.com/page-description-language/svg/) generálására. Ehhez használja a `set_Id` metódust a [ISvgShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/isvgshape/) interfésztől. A `CustomSvgShapeFormattingController` használható az alakzat azonosítójának beállításához.

```cpp
auto slideIndex = 0;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto svgOptions = MakeObject<SVGOptions>();
svgOptions->set_ShapeFormattingController(MakeObject<CustomSvgShapeFormattingController>());

auto svgStream = File::Create(u"output.svg");
slide->WriteAsSvg(svgStream, svgOptions);
svgStream->Dispose();

presentation->Dispose();
```
```cpp
class CustomSvgShapeFormattingController : public ISvgShapeFormattingController
{
private:
    int m_shapeIndex;

public:
    CustomSvgShapeFormattingController(int shapeStartIndex = 0)
    {
        m_shapeIndex = shapeStartIndex;
    }

    void FormatShape(SharedPtr<ISvgShape> svgShape, SharedPtr<IShape> shape)
    {
        svgShape->set_Id(String::Format(u"shape-{0}", m_shapeIndex++));
    }
};
```

## **Dia bélyegkép létrehozása**

Az Aspose.Slides segít a diák bélyegképeinek előállításában. Egy dia bélyegképének az Aspose.Slides segítségével történő generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét egy meghatározott méretarányban.
1. Mentse el a bélyegképet a kívánt képformátumban.

```cpp
auto slideIndex = 0;
auto scaleX = 1;
auto scaleY = scaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(scaleX, scaleY);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Dia bélyegkép létrehozása felhasználó által meghatározott méretekkel**

Felhasználó által meghatározott méretekkel rendelkező dia bélyegkép létrehozásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a meghatározott méretekkel.
1. Mentse el a bélyegképet a kívánt képformátumban.

```cpp
auto slideIndex = 0;
auto slideSize = Size(1200, 800);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(slideSize);
image->Save(u"output.jpg", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Dia bélyegkép létrehozása előadói jegyzetekkel**

Az Aspose.Slides használatával előadói jegyzetekkel ellátott dia bélyegképének generálásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [RenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/) osztályból.
1. Használja a `RenderingOptions.set_SlidesLayoutOptions` metódust az előadói jegyzetek pozíciójának beállításához.
1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a dia hivatkozását az indexe alapján.
1. Szerezze meg a hivatkozott dia bélyegképét a renderelési beállításokkal.
1. Mentse el a bélyegképet a kívánt képformátumban.

```cpp
auto slideIndex = 0;

auto layoutingOptions = MakeObject<NotesCommentsLayoutingOptions>();
layoutingOptions->set_NotesPosition(NotesPositions::BottomTruncated);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layoutingOptions);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(slideIndex);

auto image = slide->GetImage(renderingOptions);
image->Save(u"output.png", ImageFormat::Png);
image->Dispose();

presentation->Dispose();
```

## **Élő példa**

Próbálhatja ki a [**Aspose.Slides Viewer**](https://products.aspose.app/slides/hu/viewer/) ingyenes alkalmazást, hogy lássa, mit valósíthat meg az Aspose.Slides API-val:

![Online PowerPoint megjelenítő](online-PowerPoint-viewer.png)

## **GYIK**

**Beágyazhatok-e prezentációmegjelenítőt egy webalkalmazásba?**

Igen. Az Aspose.Slides szerveroldalon használható a diák képként vagy HTML-ként történő renderelésére, majd a böngészőben történő megjelenítésére. A navigációs és nagyítási funkciók JavaScript segítségével valósíthatók meg egy interaktív élményhez.

**Mi a legjobb módja a diák megjelenítésének egy saját megjelenítőben?**

A javasolt megközelítés minden diát képként (pl. PNG vagy SVG) renderelni, vagy az Aspose.Slides segítségével HTML-re konvertálni, majd a kimenetet egy képkeretben (asztali alkalmazás esetén) vagy HTML konténerben (web esetén) megjeleníteni.

**Hogyan kezeljem a sok diát tartalmazó nagy prezentációkat?**

Nagy prezentációk esetén érdemes a diák lusta betöltését vagy igény szerinti renderelését alkalmazni. Ez azt jelenti, hogy a dia tartalma csak akkor kerül előállításra, amikor a felhasználó a diahoz navigál, ezáltal csökkentve a memória- és betöltési időt.