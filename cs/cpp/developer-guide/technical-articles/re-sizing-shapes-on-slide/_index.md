---
title: Změna velikosti tvarů na snímcích prezentace v C++
type: docs
weight: 130
url: /cs/cpp/resizing-shapes-on-slide/
aliases:
  - /cpp/re-sizing-shapes-on-slide/
  - /cs/cpp/re-sizing-shapes-on-slide/
keywords:
  - změna velikosti tvaru
  - změna velikosti tvaru
  - PowerPoint
  - OpenDocument
  - prezentace
  - C++
  - Aspose.Slides
description: "Jednoduše změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++ - automatizujte úpravy rozvržení snímků a zvýšte produktivitu."
---
## **Přehled**

Když změníte velikost snímku prezentace, může být nutné také změnit velikost a pozici jeho tvarů, aby odpovídaly novým rozměrům. Tento článek ukazuje, jak ručně měnit měřítko tvarů a jak zacházet s tabulkami na snímcích, master slidech a rozvrzích.

## **Změna velikosti tvarů**

Pro zachování relativní polohy a velikosti každého tvaru vynásobte jeho horizontální souřadnice a šířku poměrem nové šířky snímku k původní šířce. Použijte odpovídající poměr výšky na jeho vertikální souřadnice a výšku.

První příklad načte prezentaci, jejíž snímky neobsahují tabulky, změní velikost snímku na formát A4 a výsledek uloží. Používá [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/) s [SlideSizeScaleType::DoNotScale](https://reference.aspose.com/slides/cpp/aspose.slides/slidesizescaletype/), aby následná smyčka řídila škálování. Poměry jsou bezrozměrné; pozice a rozměry tvarů jsou měřeny v bodech. Různé poměry šířky a výšky mohou tvary deformovat a změna rozměrů tvaru neskaluje velikost jeho písma.

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
Tabulky vyžadují zvláštní zacházení: jejich šířky sloupců a výšky řádků je třeba škálovat místo přiřazování celkové šířky a výšky tabulky. Výšky řádků mohou zůstat větší, než je požadováno, pokud obsah buňky vyžaduje více místa.
{{% /alert %}}

Druhý příklad podporuje tabulky a zpracovává tvary na master slidech a rozvrzích i na jednotlivých snímcích před uložením změněné velikosti prezentace. Jeho pomocná metoda zpracovává každé [ITable](https://reference.aspose.com/slides/cpp/aspose.slides/itable/) změnou měřítka [IColumn::set_Width](https://reference.aspose.com/slides/cpp/aspose.slides/icolumn/set_width/) a [IRow::set_MinimalHeight](https://reference.aspose.com/slides/cpp/aspose.slides/irow/set_minimalheight/). Poté změnší měřítko pozice tabulky, aniž by samostatně měřilo její celkové rozměry.

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

// Vypočítej nezávislé horizontální a vertikální faktory měřítka.
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

// Změňte velikost tvarů definovaných na masterech a rozvrzích i na jednotlivých snímcích.
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

**Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?**

Pokud změníte velikost snímku bez škálování tvarů, zachovají si své původní pozice a rozměry a mohou přesahovat okraj snímku. Škálování šířky a výšky různými poměry může také tvary deformovat.

**Funguje poskytnutý kód pro všechny typy tvarů?**

První příklad mění ohraničení tvarů přímo a je určen pro snímky bez tabulek. Druhý příklad zachází s tabulkami samostatně. Zkontrolujte výsledné rozvržení, zejména text a tabulky, protože tyto příklady neskalují velikost písma a obsah tabulky může omezovat výšky řádků.

**Jak změním velikost tabulek při změně velikosti snímku?**

Změňte šířky sloupců podle poměru šířky a minimální výšky řádků podle poměru výšky, poté změňte měřítko pozice tabulky, jak je ukázáno ve druhém příkladu.

**Bude tato změna velikosti fungovat pro master snímky a layout snímky?**

Ano. Druhý příklad prochází [Presentation::get_Masters](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_masters/) a každým [IMasterSlide::get_LayoutSlides](https://reference.aspose.com/slides/cpp/aspose.slides/imasterslide/get_layoutslides/) v rámci masteru a používá stejnou logiku změny velikosti na jejich tvary.

**Mohu změnit orientaci snímku (na výšku/do šířky) spolu se změnou velikosti?**

Ano. Nastavte [SlideSize::set_Orientation](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/set_orientation/) po změně velikosti snímku a před načtením cílových rozměrů, aby faktory měřítka odrážely konečnou orientaci.

**Existuje limit velikosti snímku, kterou mohu nastavit?**

Můžete zadat vlastní rozměry snímku pomocí [SlideSize::SetSize](https://reference.aspose.com/slides/cpp/aspose.slides/slidesize/setsize/). Podporované rozměry také závisí na formátu prezentace a na aplikaci, kterou soubor otevřete.

**Jak zabránit, aby tvary s pevným poměrem stran byly deformovány?**

Použijte stejný faktor měřítka pro šířku i výšku. Pro umístění původního rozvržení do nových rozměrů snímku použijte menší z poměrů šířky a výšky pro obě rozměry a pozice. To zachová proporce, ale může zanechat nevyužitý prostor podél jedné hrany.