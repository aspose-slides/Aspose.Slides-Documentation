---
title: Operace low-code prezentací v C++
linktitle: Low-Code API
type: docs
weight: 50
url: /cs/cpp/low-code-presentation-operations/
keywords:
- low-code API pro prezentace
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- sběr tvarů
- komprimace prezentace
- odstranění nepoužívaných master snímků
- odstranění nepoužívaných layout snímků
- komprimace vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v C++ k převodu a sloučení prezentací, iteraci obsahu, sběru tvarů a zmenšení velikosti prezentace."
---
## **Přehled**

Namespace [Aspose::Slides::LowCode](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zapouzdřují často používané workflow objektového modelu do cílených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, sbírat tvary a odstraňovat nepoužívaný obsah s menším množstvím kódu.

Low-code pomocníky jsou nejvíce užitečné, když se operace vztahuje na celý soubor nebo prezentaci a výchozí workflow odpovídá vašim požadavkům. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/cpp/aspose.slides/) když potřebujete jemnější kontrolu nad jednotlivými snímky, mistry, rozvrženími, tvary, nastaveními exportu nebo vztahy mezi prvky prezentace.

Následující tabulka shrnuje dostupné pomocníky:

| Helper | Use it for |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor‑na‑soubor. |
| [Merger](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/merger/) | Kombinování kompletních souborů prezentací ve stejném formátu. |
| [ForEach](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/) | Spuštění akce pro každou snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/) | Odstranění nepoužívaných mistrů a rozvržení a zmenšení vložených fontových dat. |

## **Převeďte prezentaci**

Použijte [Convert::AutoByExtension](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/autobyextension/) když je přípona výstupního souboru dostačující pro výběr formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z výstupní cesty a zapíše výsledek.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/convert/) také poskytuje vyhrazené metody pro výstup do PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem prezentaci zkontrolovat nebo upravit, nebo nakonfigurovat možnost exportu, která není v pomocníkovi k dispozici. Viz [Convert Presentation](/cpp/convert-presentation/) pro workflow a možnosti specifické pro formáty.

## **Sloučte prezentace**

Použijte [Merger::Process](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/merger/process/) k sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo pře mapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, použít cílový master nebo rozvržení, explicitně zachovat sekce nebo sladit různé velikosti snímků. Viz [Merge Presentations](/cpp/merge-presentation/) pro tyto scénáře.

## **Procházejte prvky prezentace**

Třída [ForEach](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/) volá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám kolekcí a je vhodná pro kontrolu nebo změny formátování v celé prezentaci.

Následující příklad používá [ForEach::Slide](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/paragraph/), a [ForEach::Portion](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/portion/) k prozkoumání odpovídajících prvků:

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

Ve výchozím nastavení zahrnuje procházení tvarů a textu v celé prezentaci normální, master a layout snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky poznámek. Použijte přímé smyčky kolekcí, když je důležitý pořadí procházení, předčasný odchod, filtrování před voláním zpětného volání nebo podrobná kontrola nad rodičovským‑potomkovým vztahem.

## **Sbírejte tvary**

Použijte [Collect::Shapes](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/collect/shapes/) když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, pokud bude stejná sada filtrována, počítána nebo zpracovávána vícekrát.

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

Použijte místo toho [ForEach::Shape](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/foreach/shape/), když může být každý tvar zpracován okamžitě a není potřeba uchovávat shromážděný výsledek.

## **Komprimujte obsah prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/) může odstranit nepoužívané strukturované prvky a zmenšit vložená data fontů:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) odstraňuje rozvržovací snímky, na které neodkazuje žádný normální snímek.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) odstraňuje master snímky, které již nejsou použity.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) odstraňuje nepoužívané znaky ze zabudovaných fontů.

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

Odstraňte nejprve nepoužívaná rozvržení před nepoužívanými mistry, aby mohl být master, který se po vyčištění rozvržení stane neodkazovaným, také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud můžete později potřebovat původní mistry, rozvržení nebo kompletní vložená data fontů. Pro více podrobností viz [Slide Master](/cpp/slide-master/) a [Embedded Font](/cpp/embedded-font/).

## **FAQ**

**Kdy mám použít low-code API místo plného objektového modelu?**

Používejte low-code pomocníky, když standardní operace platí pro celý soubor nebo prezentaci a nevyžaduje podrobnou kontrolu nad jednotlivými prvky. Použijte plný objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy mezi mistry a rozvrženími, zkontrolovat mezistav nebo nakonfigurovat chování, které pomocník neodhaluje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. Merger::Process vyžaduje vstupní prezentace ve stejném formátu. Nejprve převeďte vstupní soubory do společného formátu, například pomocí Convert::AutoByExtension, a pak sloučte převedené soubory.

**Zpracovává ForEach master, layout a poznámkové snímky?**

[ForEach::Slide] iteruje normální snímky prezentace. Operace [ForEach::Shape], [ForEach::Paragraph] a [ForEach::Portion] v celé prezentaci zahrnují ve výchozím nastavení normální, master a layout snímky. Použijte jejich přetížení s `includeNotes` nastaveným na `true`, aby byly zahrnuty i poznámkové snímky.

**Jaký je rozdíl mezi ForEach::Shape a Collect::Shapes?**

Použijte ForEach::Shape, když chcete každý tvar zpracovat okamžitě pomocí zpětného volání. Použijte Collect::Shapes, pokud potřebujete výčtový výsledek, který lze uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužívaná rozvržení, nepoužívané mistry nebo vložené fonty s nepoužívanými znaky. Pokud žádné z toho není, odpovídající operace Compress nemusí zmenšit velikost souboru.

**Ukládají se změny provedené pomocí ForEach nebo Compress automaticky?**

Ne. Tyto pomocníky pracují s načteným objektem Presentation v paměti. Po změně prvků v zpětném volání ForEach nebo po spuštění Compress zavolejte Presentation::Save, abyste výsledek zapsali.

## **Související články**

- [Convert Presentation](/cpp/convert-presentation/)
- [Merge Presentations](/cpp/merge-presentation/)
- [Slide Master](/cpp/slide-master/)
- [Manage Text Box](/cpp/manage-textbox/)
- [Embedded Font](/cpp/embedded-font/)