---
title: Alakzatok átméretezése a bemutató diákon C++-ban
type: docs
weight: 130
url: /hu/cpp/resizing-shapes-on-slide/
aliases:
  - /hu/cpp/re-sizing-shapes-on-slide/
  /cpp/alakzatok-átméretezése-dián/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for C++ segítségével—automatizálja a diaelrendezés beállításait és növelje a termelékenységet."
---
## **Áttekintés**

Ha megváltoztatja egy bemutató dia méretét, előfordulhat, hogy át kell méreteznie és át kell helyeznie annak alakzatait, hogy illeszkedjenek az új méretekhez. Ez a cikk bemutatja, hogyan lehet kézzel méretezni az alakzatokat, és hogyan kezeljük a táblákat diákon, mesterdiákon és elrendezéseken.

## **Alakzatok átméretezése**

Az egyes alakzatok relatív pozíciójának és méretének megőrzéséhez szorozza meg a vízszintes koordinátákat és a szélességet az új dia szélességének és az eredeti szélességnek arányával. Alkalmazza a megfelelő magasságarányt a függőleges koordinátákra és a magasságra.

Az első példa betölt egy olyan bemutatót, amelynek diái nem tartalmaznak táblákat, A4-re változtatja a dia méretét, majd elmenti az eredményt. A [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) metódust a [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/) értékkel használja, hogy a későbbi ciklus szabályozza a méretezést. Az arányok dimenzió nélküli értékek; az alakzatok pozíciói és méretei pontban vannak megadva. A különböző szélesség- és magasságarányok torzíthatják az alakzatokat, és az alakzat méretének megváltoztatása nem méretezi át a betűméreteket.

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
A táblákat külön kell kezelni: a teljes táblaszélesség és magasság helyett az oszlopszélességeket és sormagasságokat kell méretezni. A sormagasságok nagyobbak lehetnek a kért értéknél, ha a cella tartalma több helyet igényel.
{{% /alert %}}

A második példa támogatja a táblákat, és a mesterdiákon, elrendezéseken, valamint az egyes diákon lévő alakzatokat dolgozza fel a méretezett bemutató mentése előtt. Segítője minden [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) elemet úgy kezel, hogy méretezi a [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) és [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/) metódusokat. Ezután a táblázat pozícióját méretezi anélkül, hogy külön méretezné a teljes méreteit.

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

// Számolja ki a független vízszintes és függőleges méretezési tényezőket.
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

// Átméretezi a mestereken, elrendezéseken és egyedi diákon definiált alakzatokat.
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

## **Gyakran Ismételt Kérdések**

**Miért torzulnak vagy vágódnak le az alakzatok a dia átméretezése után?**

Ha a dia méretét anélkül változtatja meg, hogy az alakzatokat méretezné, azok megőrzik eredeti pozíciójukat és méretüket, és kilóghatnak a diáról. A szélesség és magasság különböző arányú méretezése szintén torzíthatja az alakzatokat.

**A megadott kód minden alakzattípusra működik?**

Az első példa közvetlenül módosítja az alakzat határait, és olyan diákra vonatkozik, amelyek nem tartalmaznak táblákat. A második példa külön kezeli a táblákat. Ellenőrizze a végeredmény elrendezését, különösen a szöveget és a táblákat, mivel ezek a példák nem méreteznek betűméreteket, és a táblázat tartalma korlátozhatja a sormagasságokat.

**Hogyan méretezzem át a táblákat a dia átméretezésekor?**

Méretezze az oszlopszélességeket a szélességi arány szerint, a minimális sormagasságokat a magassági arány szerint, majd méretezze a táblázat pozícióját, ahogyan a második példában látható.

**Ez az átméretezés működik-e mesterdiákon és elrendezési diákon?**

Igen. A második példa végigiterál a [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) és minden mester [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) elemein, és ugyanazt az átméretezési logikát alkalmazza az azokban lévő alakzatokra.

**Megváltoztathatom egy dia orientációját (álló/ fekvő) az átméretezés mellett?**

Igen. Állítsa be a [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) értéket a dia méretének megváltoztatása után és a célméretek lekérdezése előtt, hogy a méretezési tényezők a végső orientációt tükrözzék.

**Van korlátozás a beállítható dia méretére?**

Egyéni dia méreteket adhat meg a [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) segítségével. A támogatott méretek a bemutató formátumától és a fájlt megnyitó alkalmazástól is függenek.

**Hogyan akadályozhatom meg, hogy a rögzített képarányú alakzatok torzuljanak?**

Használja ugyanazt a méretezési tényezőt a szélességhez és a magassághoz. Az eredeti elrendezés új dia méreteibe való illesztéséhez a szélességi és magassági arányok közül a kisebbet alkalmazza mindkét dimenzióra és pozícióra. Ez megőrzi az arányokat, de előfordulhat, hogy az egyik oldalnál üres tér marad.