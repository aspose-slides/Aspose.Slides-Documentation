---
title: Operace prezentací s nízkým kódem v C++
linktitle: API s nízkým kódem
type: docs
weight: 50
url: /cs/cpp/low-code-presentation-operations/
keywords:
- API prezentace s nízkým kódem
- převod prezentace
- sloučení prezentací
- procházení snímků
- procházení tvarů
- procházení textu
- sběr tvarů
- komprese prezentace
- odstranění nepoužívaných hlavních snímků
- odstranění nepoužívaných rozvržovacích snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v C++ k převodu a sloučení prezentací, procházení obsahu, sběru tvarů a zmenšení velikosti prezentace."
---
## **Přehled**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/cs/cpp/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| Pomocník | K čemu použít |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/merger/) | Kombinování kompletních souborů prezentací se stejným formátem. |
| [ForEach](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/) | Spuštění akce pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných hlav a rozvržení a zmenšení vložených fontových dat. |

## **Převod prezentace**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

The [Convert](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/slides/cs/cpp/convert-presentation/) for format-specific workflows and options.

## **Sloučení prezentací**

Use [Merger::Process](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/slides/cs/cpp/merge-presentation/) for those scenarios.

## **Iterace přes prvky prezentace**

The [ForEach](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach::Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **Sběr tvarů**

Use [Collect::Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Use [ForEach::Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **Komprese obsahu prezentace**

The [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/slides/cs/cpp/slide-master/) and [Embedded Font](/slides/cs/cpp/embedded-font/).

## **Často kladené otázky**

**Kdy bych měl použít low-code API místo plného objektového modelu?**

Používejte low-code pomocníky, když se standardní operace vztahuje na celý soubor nebo celou prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte plný objektový model, pokud potřebujete vybrat konkrétní snímky, řídit vztahy hlav a rozvržení, inspektovat mezistav nebo nakonfigurovat chování, které pomocník neumožňuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger::Process](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/merger/process/) vyžaduje vstupní prezentace ve stejném formátu. Nejprve převěďte vstupní soubory do společného formátu, například pomocí [Convert::AutoByExtension](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/autobyextension/), a poté sloučte převedené soubory.

**Zpracovává ForEach hlavní, rozvržovací a poznámkové snímky?**

[ForEach::Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/slide/) prochází normální snímky prezentace. Operace [ForEach::Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/paragraph/) a [ForEach::Portion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/portion/) v celé prezentaci zahrnují normální, hlavní a rozvržovací snímky ve výchozím nastavení. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, aby byly zahrnuty poznámkové snímky.

**Jaký je rozdíl mezi ForEach::Shape a Collect::Shapes?**

Použijte [ForEach::Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/shape/), abyste zpracovali každý tvar okamžitě pomocí zpětného volání. Použijte [Collect::Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/collect/shapes/), když potřebujete výsledek jako kolekci, kterou lze zachovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané hlavy nebo vložené fonty s nepoužívanými znaky. Pokud žádná z těchto komponenty neexistují, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/) nemusí snížit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Títo pomocníci operují na načteném objektu [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) v paměti. Po změně prvků v callbacku [ForEach](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/) nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/), zavolejte [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/), abyste výsledek zapsali.

## **Související články**

- [Convert Presentation](/slides/cs/cpp/convert-presentation/)
- [Merge Presentations](/slides/cs/cpp/merge-presentation/)
- [Slide Master](/slides/cs/cpp/slide-master/)
- [Manage Text Box](/slides/cs/cpp/manage-textbox/)
- [Embedded Font](/slides/cs/cpp/embedded-font/)