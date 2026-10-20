---
title: Alakzatok átméretezése a bemutató diákon C++-ban
type: docs
weight: 130
url: /hu/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/alakzatok-átméretezése-dián/
  - /hu/cpp/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Könnyedén átméretezhet alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for C++ segítségével—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Áttekintés**

Amikor megváltoztatja egy bemutató diaméretét, lehet, hogy át kell méretezni és át kell helyezni a benne lévő alakzatokat az új méretekhez igazítva. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, és hogyan kell kezelni a táblázatokat diákon, mester-diákon és elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új diaszélesség és az eredeti szélesség arányával. Alkalmazza a megfelelő magassárrátát a függőleges koordinátákra és a magasságra.

Az első példa betölt egy olyan bemutatót, amelynek diái nem tartalmaznak táblázatokat, megváltoztatja a diaméretet A4-re, és elmenti az eredményt. A [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) módszert a [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) értékkel használja, hogy a későbbi ciklus irányítsa a méretezést. Az arányok dimenzió nélküli értékek; az alakzatok pozíciói és méretei pontban vannak megadva. A különböző szélesség- és magassárráták torzíthatják az alakzatokat, és egy alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

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

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Calculate independent horizontal and vertical scale factors.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        shape->set_Width(shape->get_Width() * widthRatio);
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" title="Note" %}}
A táblázatokat külön kell kezelni: a táblázat teljes szélességét és magasságát nem kell beállítani, hanem az oszlopszélességeket és sormagasságokat kell méretezni. A sormagasságok nagyobbak maradhatnak a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblázatokat, és a mester-diák és elrendezések, valamint az egyes diák alakzatainak feldolgozása után menti az átméretezett bemutatót. Segédfüggvénye minden egyes [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/)-t úgy kezel, hogy méretezi a [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) és [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) értékeket. Ezután méretezi a táblázat pozícióját anélkül, hogy külön méretezné a táblázat teljes méreteit.

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
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Számítsa ki a független vízszintes és függőleges méretezési tényezőket.
auto originalSize = presentation->get_SlideSize()->get_Size();
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
auto targetSize = presentation->get_SlideSize()->get_Size();
auto widthRatio = targetSize.get_Width() / originalSize.get_Width();
auto heightRatio = targetSize.get_Height() / originalSize.get_Height();

auto resizeShapes = [](SharedPtr<IShapeCollection> shapes, float widthRatio, float heightRatio)
{
    for (auto&& shape : shapes)
    {
        if (ObjectExt::Is<ITable>(shape))
        {
            auto table = ExplicitCast<ITable>(shape);
            // A táblázat méreteit az oszlopszélességek és a sormagasságok szabályozzák.
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }

            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
        }
        else
        {
            shape->set_Width(shape->get_Width() * widthRatio);
            shape->set_Height(shape->get_Height() * heightRatio);
        }

        shape->set_X(shape->get_X() * widthRatio);
        shape->set_Y(shape->get_Y() * heightRatio);
    }
};

// Alakzatok átméretezése a master-diákon, elrendezéseken és az egyes diákon.
for (auto&& master : presentation->get_Masters())
{
    resizeShapes(master->get_Shapes(), widthRatio, heightRatio);

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        resizeShapes(layoutSlide->get_Shapes(), widthRatio, heightRatio);
    }
}

for (auto&& slide : presentation->get_Slides())
{
    resizeShapes(slide->get_Shapes(), widthRatio, heightRatio);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

Ha a diaméretet átméretezés nélkül változtatja meg, az alakzatok megtartják eredeti pozíciójukat és méretüket, és a dia szélén túl is kinyúlhatnak. A szélesség és magasság különböző arányokkal való méretezése szintén torzíthatja az alakzatokat.

**Működik a megadott kód minden alakzattípusra?**

Az első példa közvetlenül módosítja az alakzat határait, és táblázat nélküli diákra szánt. A második példa a táblázatokat külön kezeli. Ellenőrizze a kapott elrendezést, különösen a szöveget és a táblázatokat, mivel ezek a példák nem méretezik a betűméreteket, és a táblázattartalom korlátozhatja a sormagasságokat.

**Hogyan méretezhetem át a táblázatokat a dia átméretezésekor?**

Méretezze az oszlopszélességeket a szélességarány szerint, a minimális sormagasságokat a magasságarány szerint, majd méretezze a táblázat pozícióját, ahogyan a második példában látható.

**Működik ez az átméretezés mester-diákon és elrendezés-diákon is?**

Igen. A második példa végigiterál a [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) és minden mester [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) elemein, és ugyanazt az átméretezési logikát alkalmazza az alakzataikra.

**Megváltoztathatom a dia tájolását (álló/fekvő) az átméretezés közben?**

Igen. A [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) beállítása a diaméret módosítása után, a célméretek lekérése előtt biztosítja, hogy a méretezési tényezők a végső tájolást tükrözzék.

**Van korlát a beállítható diaméretre?**

A [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) segítségével megadhat egyedi diaméreteket. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függnek.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**

Használja ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új diaméretekbe való illesztéséhez vegye a szélesség- és magassárráták közül a kisebbet mind a méretekhez, mind a pozíciókhoz. Ez megőrzi az arányokat, de egy él mentén üres hely maradhat.