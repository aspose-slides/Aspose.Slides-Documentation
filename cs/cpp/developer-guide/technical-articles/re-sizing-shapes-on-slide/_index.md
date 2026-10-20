---
title: Změna velikosti tvarů na snímcích prezentace v C++
type: docs
weight: 130
url: /cs/cpp/resizing-shapes-on-slide/
aliases:
  - /cs/cpp/re-sizing-shapes-on-slide/
  /cpp/re-sizing-shapes-on-slide/
keywords:
- změna velikosti tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++ — automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, může být také nutné změnit velikost a umístění jejích tvarů, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně měnit velikost tvarů a jak zacházet s tabulkami na snímcích, hlavních snímcích a rozvrženích.

## **Změna velikosti tvarů**

Aby se zachovala relativní poloha a velikost každého tvaru, vynásobte jeho vodorovné souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho svislé souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují tabulky, změní velikost snímku na formát A4 a výsledek uloží. Používá [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) s [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/), aby následná smyčka řídila škálování. Poměry jsou bez jednotek; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neskaluje velikost jeho písma.

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

// Vypočítejte nezávislé horizontální a vertikální měřítkové faktory.
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
Tabulky vyžadují zvláštní zacházení: škálujte jejich šířky sloupců a výšky řádků místo přiřazení celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší než požadované, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary v hlavních snímcích a rozvrženích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocná metoda zpracovává každou [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) škálováním [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) a [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Pak škáluje polohu tabulky, aniž by samostatně škáloval její celkové rozměry.

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

// Vypočítejte nezávislé horizontální a vertikální měřítkové faktory.
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
            // Rozměry tabulky jsou řízeny šířkami sloupců a výškami řádků.
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

// Změňte velikost tvarů definovaných na hlavních snímcích a rozvrženích i na jednotlivých snímcích.
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

## **Často kladené otázky**

**Proč jsou tvary po změně velikosti snímku deformovány nebo oříznuty?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat přes okraj snímku. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvaru přímo a je určen pro snímky bez tabulek. Druhý příklad zachází s tabulkami samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikosti písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Škálujte šířky sloupců poměrem šířky a minimální výšky řádků poměrem výšky, poté škálujte polohu tabulky, jak je ukázáno ve druhém příkladu.

**Bude toto škálování fungovat i pro hlavní snímky a rozvržení snímků?**

Ano. Druhý příklad prochází [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) a každým [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) a aplikuje stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/v šířku) spolu se změnou velikosti?**

Ano. Nastavte [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) po změně velikosti snímku a před načtením cílových rozměrů, aby škálovací faktory odrážely konečnou orientaci.

**Existuje limit pro velikost snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Podporované rozměry také závisí na formátu prezentace a aplikaci použité k otevření souboru.

**Jak mohu zabránit deformaci tvarů s pevným poměrem stran?**

Použijte stejný škálovací faktor pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro oba rozměry i pozice. To zachová proporce, ale může zanechat nevyužitý prostor podél jedné hrany.