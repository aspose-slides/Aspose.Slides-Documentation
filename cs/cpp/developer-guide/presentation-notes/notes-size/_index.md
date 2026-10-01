---
title: Změna velikosti a orientace stránky s poznámkami v C++
linktitle: Velikost stránky s poznámkami
type: docs
weight: 10
url: /cs/cpp/notes-size/
keywords:
- velikost stránky s poznámkami
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladu
- PowerPoint
- prezentace
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Načtěte a změňte rozměry stránky s poznámkami v Aspose.Slides pro C++, přepněte orientaci, ověřte uložené velikosti a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation::get_NotesSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_notessize/) k přístupu k nastavením stránky s poznámkami prezentace. Vrací objekt [INotesSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotessize/), jehož metoda [set_Size](https://reference.aspose.com/slides/cs/cpp/aspose.slides/inotessize/set_size/) nastavuje rozměry. Přestože objekt nastavení poznámek nelze nahradit, můžete změnit jeho velikost.

Šířka a výška jsou zadány v ** bodech**, přičemž 1 palec = 72 bodů. Například 900 × 600 bodů odpovídá 12,5 × 8 ⅓ palce. Tato nastavení se vztahují k celé prezentaci, nikoli k poznámkám konkrétního snímku.

| Nastavení | Účel |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_notessize/) | Řídí rozměry stránky s poznámkami a rozměry stránky použité při exportu podkladů. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_slidesize/) | Řídí běžné rozměry snímků prezentace přes [ISlideSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidesize/). |

Změna jednoho nastavení automaticky nemění druhé. Změna orientace stránky s poznámkami také neotáčí běžné snímky. Viz [Slide Size](/slides/cs/cpp/slide-size/) pro změnu velikosti běžných snímků.

Níže uvedené příklady používají existující `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky řečitele. Každý příklad lze spustit samostatně.

## **Načtení velikosti a orientace stránky s poznámkami**

Načtěte šířku a výšku a porovnejte je, abyste určili orientaci: širší stránka je na šířku, vyšší stránka je na výšku a stejné rozměry popisují čtvercovou stránku. Tento příklad vytiskne skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Přepnutí na šířkový formát bez změny velikosti papíru**

Pro změnu pouze orientace prohoďte stávající šířku a výšku. Tím zachováte délky obou stran, včetně těch u vlastní velikosti papíru. Podmínka níže zabraňuje převrácení již šířkové stránky zpět na výšku a nechává čtvercovou stránku beze změny.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Pro výšku použijte stejné přiřazení, když `size.get_Width() > size.get_Height()`. Nezáměňujte rozměry A4 nebo Letter, pokud také nechcete měnit velikost papíru.

## **Nastavení a ověření vlastního rozměru stránky s poznámkami**

Přiřaďte oba rozměry najednou a poté použijte [Presentation::Save](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/save/) k uložení prezentace. Tento příklad nastaví šířkovou stránku 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor k ověření uložených hodnot. Porovnání umožňuje toleranci 0,01 bodu pro hodnoty s plovoucí desetinnou čárkou; není to záruka přesnosti pro každý formát souboru.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

Očekávaný výsledek je `900 x 600 points` a `Size preserved: True`. Kontrola nově otevřené prezentace ověřuje uložený soubor, nikoli pouze nastavení v paměti.

## **Export poznámek a podkladů**

Rozměry stránky určují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě neumožňují tyto rozvržení; je třeba také nakonfigurovat možnosti exportu. Export běžných snímků nadále používá rozměry snímku.

### **Export poznámek do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notescommentslayoutingoptions/) k [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) pro zahrnutí poznámek do PDF. Tento příklad také vykreslí první snímek s poznámkami do PNG pomocí [Slide::GetImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slide/getimage/) a [RenderingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notespositions/) ponechává poznámky na jedné stránce; poznámky, které se nevejdou, mohou být oříznuty. PDF používá stránky 900 × 600 bodů. Při použité měřítku obrázku 1 × 1 je PNG 900 × 600 pixelů. Body popisují geometrii stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku vykreslování.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Pro export PDF s dlouhými poznámkami umožňuje [BottomFull](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/notespositions/) další stránky podle potřeby. Tento režim nepoužívejte s voláním obrázku jednosnímkového výše, které ho nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění objektů existujících v notes-master; změna rozměrů stránky samotná není zárukou, že veškerý obsah bude pasovat. Viz [Convert PowerPoint to PDF with Notes](/slides/cs/cpp/convert-powerpoint-to-pdf-with-notes/) pro více informací o exportu poznámek.

### **Export podkladů do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku 900 × 600 bodů a použije [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/cs/cpp/aspose.slides.export/handouttype/) k uspořádání až čtyř snímků na stránku. Horizontální předvolba řídí pořadí snímků; orientace stránky vychází ze šířky a výšky.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by měnila rozměry zdrojových snímků. Pro obrázky podkladů použijte [Presentation::GetImages](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/getimages/) s rozvržením podkladů, místo metody pro obrázek jednotlivého snímku. V Aspose.Slides vykreslování podkladů na úrovni prezentace používá rozměry stránky s poznámkami, zatímco volání obrázku jednotlivého snímku nevytváří stránku podkladu. Viz [Handout Mode](/slides/cs/cpp/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky ve prohlížečích, exportu a tisku**

Uchovávejte odděleně uloženou velikost prezentace, exportovanou velikost stránky a fyzickou velikost papíru při tisku:

- **Prohlížeče prezentací:** Prohlížeč může zobrazovat nebo tisknout poznámky pomocí vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, znovu jej otevřete a zkontrolujte rozměry; konverze formátu v té aplikaci je může normalizovat.
- **Exportní formáty:** Příklady PDF pro poznámky a podklady výše používají nakonfigurované rozměry stránky. Rastrové obrázky používají celočíselné rozměry pixelů a měřítko vykreslování, takže desetinné hodnoty bodů mohou být zaokrouhleny ve výstupu obrázku. Export běžných snímků neaplikuje velikost stránky s poznámkami.
- **Ovladače tiskáren:** Výběr papíru, automatická otočení a nastavení "fit-to-page" mohou změnit fyzický výstup, aniž by změnily rozměry uložené v prezentaci nebo PDF. Pro konkrétní velikost papíru přizpůsobte nastavení tiskárny a zkontrolujte náhled tisku.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek jen pro jeden snímek?**

Velikost stránky s poznámkami je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít různý obsah poznámek, ale tato vlastnost neposkytuje samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek nezměnila mé snímky?**

Stránky s poznámkami a běžné snímky mají nezávislé rozměry. Použijte nastavení velikosti běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek po uložení nebo tisku jinou velikost?**

Nejprve znovu otevřete uloženou prezentaci a porovnejte její rozměry poznámek. Pokud se změnily, zkontrolujte, zda uložení nebo konverze souboru v jiné aplikaci nezměnila nastavení stránky. Pokud ne, prověřte rozvržení exportu, měřítko obrázku, nastavení prohlížeče a výběr papíru tiskárny.