---
title: Alakzatok átméretezése a prezentációs diákon
type: docs
weight: 100
url: /hu/cpp/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for C++ segítségével – automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Az Aspose.Slides for C++ ügyfelei leggyakrabban felmerülő kérdése, hogyan lehet átméretezni az alakzatokat úgy, hogy a diaméret változásakor az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan kell ezt megtenni.

## **Alakzatok átméretezése**

Az alakzatok eltorzulásának megakadályozása érdekében a diaméret változásakor frissítse minden alakzat pozícióját és méreteit, hogy megfeleljenek az új diárelrendezésnek.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Töltsük be a prezentáció fájlt.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Szerezze meg az eredeti dia méretét.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Módosítsa a dia méretét a meglévő alakzatok átméretezése nélkül.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Szerezze meg az új dia méretét.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Skálázza az alakzat méretét.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skálázza az alakzat méretét.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skálázza az alakzat pozícióját.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Ha egy dián táblázat szerepel, a fenti kód nem működik helyesen. Ebben az esetben a táblázat minden celláját át kell méretezni. 
{{% /alert %}} 

Használja az alábbi kódot a táblázatot tartalmazó diák átméretezéséhez. Táblázatok esetén a szélesség vagy magasság beállítása speciális eset: egyéni sormagasságokat és oszlopszélességeket kell módosítani a táblázat teljes méretének megváltoztatásához.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ILayoutSlideCollection.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <DOM/SlideSizeType.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnCollection.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowCollection.h>
#include <DOM/Table/ITable.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Szerezze meg az eredeti dia méretét.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Módosítsa a dia méretét a meglévő alakzatok átméretezése nélkül.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Szerezze meg az új dia méretét.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Skálázza az alakzat méretét.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skálázza az alakzat pozícióját.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Skálázza az alakzat méretét.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Skálázza az alakzat pozícióját.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Skálázza az alakzat méretét.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Skálázza az alakzat pozícióját.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

### Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?

Dia átméretezésekor az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a skálát nem változtatják meg kifejezetten. Ez a tartalom levágásához vagy az alakzatok eltolódásához vezethet.

### Működik a megadott kód minden alakzattípusra?

Az alap példa a legtöbb alakzattípusra (szövegdobozok, képek, diagramok stb.) működik. Azonban táblázatok esetén a sorokkal és oszlopokkal külön kell foglalkozni, mivel egy táblázat magasságát és szélességét az egyes cellák méretei határozzák meg.

### Hogyan lehet átméretezni a táblázatokat a dia átméretezésekor?

A táblázat összes sorát és oszlopát végig kell iterálni, és azok magasságát és szélességét arányosan át kell méretezni, ahogyan a második kódrészlet is mutatja.

### Működik ez az átméretezés mester- és elrendezési diákon is?

Igen, de érdemes végigmenni a [Mestereken](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) és a [Elrendezési diákon](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_layoutslides/), és ugyanazt a skálázási logikát alkalmazni az alakzataikra is, hogy a prezentáció egységes legyen.

### Megváltoztathatom a dia orientációját (álló/fekvő) az átméretezés mellett?

Igen. A [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/set_orientation/) segítségével módosíthatja az orientációt. Győződjön meg róla, hogy a skálázási logikát ennek megfelelően állítja be a elrendezés megtartásához.

### Van korlátja a beállítható diaméretnek?

Az Aspose.Slides egyéni méreteket támogat, de a nagyon nagy méretek befolyásolhatják a teljesítményt vagy a kompatibilitást bizonyos PowerPoint verziókkal.

### Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?

A skálázás előtt ellenőrizheti az alakzat `get_AspectRatioLocked` metódusát. Ha zárolt, a szélességet vagy magasságot arányosan módosítsa, ahelyett hogy őket egyenként skálázná.