---
title: Změna velikosti tvarů na snímcích prezentace
type: docs
weight: 100
url: /cs/cpp/re-sizing-shapes-on-slide/
keywords:
- úprava velikosti tvaru
- změna velikosti tvaru
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Snadno změňte velikost tvarů na snímcích PowerPoint a OpenDocument pomocí Aspose.Slides pro C++—automatizujte úpravy rozložení snímků a zvýšte produktivitu."
---
## **Přehled**

Jedna z nejčastějších otázek zákazníků Aspose.Slides pro C++ je, jak změnit velikost tvarů tak, aby se data neodříznula při změně velikosti snímku. Tento krátký technický článek ukazuje, jak to provést.

## **Změna velikosti tvarů**

Aby se zabránilo nesouladu tvarů při změně velikosti snímku, aktualizujte pozici a rozměry každého tvaru tak, aby odpovídaly novému rozložení snímku.

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

// Načtěte soubor prezentace.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Získejte původní velikost snímku.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Změňte velikost snímku bez škálování existujících tvarů.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Získejte novou velikost snímku.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Změňte velikost a přesuňte tvary na každém snímku.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Změňte velikost tvaru.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Změňte pozici tvaru.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="info" %}} 
Pokud snímek obsahuje tabulku, výše uvedený kód nebude fungovat správně. V takovém případě je nutné změnit velikost každé buňky v tabulce. 
{{% /alert %}} 

Použijte následující kód na svém konci pro změnu velikosti snímků, které obsahují tabulky. U tabulek je nastavení šířky nebo výšky speciální případ: musíte upravit výšky jednotlivých řádků a šířky sloupců, aby se změnila celková velikost tabulky.

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

// Získejte původní velikost snímku.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Změňte velikost snímku bez škálování existujících tvarů.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Získejte novou velikost snímku.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Změňte velikost tvaru.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Změňte pozici tvaru.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Změňte velikost tvaru.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Změňte pozici tvaru.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Změňte velikost tvaru.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Změňte pozici tvaru.
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

## **Často kladené otázky**

### Proč jsou tvary po změně velikosti snímku deformované nebo oříznuté?

Při změně velikosti snímku tvary zachovají svou původní polohu a rozměry, pokud se měřítko explicitně nezmění. To může způsobit oříznutí obsahu nebo nesoulad tvarů.

### Funguje poskytnutý kód pro všechny typy tvarů?

Základní příklad funguje pro většinu typů tvarů (textová pole, obrázky, grafy atd.). U tabulek však musíte zpracovat řádky a sloupce zvlášť, protože výška a šířka tabulky jsou určeny rozměry jednotlivých buněk.

### Jak změnit velikost tabulek při změně velikosti snímku?

Je nutné projít všechny řádky a sloupce tabulky a změnit jejich výšku a šířku proporcionálně, jak je ukázáno ve druhém příkladu kódu.

### Bude tato změna velikosti fungovat pro hlavní snímky a snímky rozložení?

Ano, ale měli byste také projít [Masters](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_masters/) a [Layout slides](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_layoutslides/) a použít stejnou logiku škálování na jejich tvary, aby byla zajištěna konzistence v celé prezentaci.

### Mohu změnit orientaci snímku (na výšku/na šířku) spolu se změnou velikosti?

Ano. Můžete použít [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/set_orientation/) pro změnu orientace. Ujistěte se, že podle toho nastavíte logiku škálování, aby zachovala rozložení.

### Existuje limit na velikost snímku, kterou mohu nastavit?

Aspose.Slides podporuje vlastní velikosti, ale velmi velké rozměry mohou ovlivnit výkon nebo kompatibilitu s některými verzemi PowerPointu.

### Jak mohu zabránit, aby tvary se zamknutým poměrem stran byly deformovány?

Můžete před škálováním zkontrolovat metodu `get_AspectRatioLocked` tvaru. Pokud je zamčena, upravte šířku nebo výšku proporcionálně místo samostatného škálování.