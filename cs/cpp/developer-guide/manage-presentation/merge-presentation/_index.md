---
title: Efektivně sloučit prezentace v C++
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/cpp/merge-presentation/
keywords:
- sloučit PowerPoint
- sloučit prezentace
- sloučit snímky
- sloučit PPT
- sloučit PPTX
- sloučit ODP
- kombinovat PowerPoint
- kombinovat prezentace
- kombinovat snímky
- kombinovat PPT
- kombinovat PPTX
- kombinovat ODP
- C++
- Aspose.Slides
description: "Naučte se, jak v C++ sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných či velkých souborů."
---
## **Přehled**

Aspose.Slides pro C++ sloučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozvržení v cílové prezentaci.

Tento článek popisuje nejčastější postupy sloučení:

- sloučit všechny snímky při zachování formátování zdroje;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end-to-end postupu;
- zpracovat mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a problémy s multithreadingem.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snímek dědí velkou část svého vzhledu od svého rozvržení a masteru. Z tohoto důvodu výběr přetížení klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) jedním z následujících způsobů:

- `AddClone(sourceSlide)` — zachovat rozvržení a formátování zdrojového snímku. V případě potřeby lze automaticky klonovat zdrojový master do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery, takže opakované snímky používající stejný zdrojový master nevedou k opakovanému klonování tohoto masteru.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojí klonovaný snímek ke konkrétnímu cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `AddClone(sourceSlide, destinationLayout)` — připojí klonovaný snímek přímo k určitému cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/).

Master nebo rozvržení předané přetížení `AddClone` musí patřit **cílové** prezentaci, nikoli zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat formátování zdroje**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když importované snímky mají zachovat své původní téma, master a vztahy rozvržení.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged.pptx", SaveFormat::Pptx);
```

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné návrhy. To je očekávané, když je formátování zdroje úmyslně zachováno.

## **Sloučit vybrané snímky**

Nemusíte klonovat každý snímek. Následující příklad importuje pouze vybrané indexy snímků ze zdrojové prezentace.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

int32_t slideIndexes[] = {0, 2, 4};

for (auto index : slideIndexes)
{
    destination->get_Slides()->AddClone(source->get_Slide(index));
}

destination->Save(u"merged-selected-slides.pptx", SaveFormat::Pptx);
```

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/), když importované snímky mají následovat master, který již patří cílové prezentaci.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationMaster = destination->get_Master(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationMaster, true);
}

destination->Save(u"merged-with-destination-master.pptx", SaveFormat::Pptx);
```

Aspose.Slides vybere vhodné rozvržení pod uvedeným masterem porovnáním typu nebo názvu zdrojového rozvržení. Pokud neexistuje vhodné rozvržení a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/details_pptxeditexception/).

Použijte `false`, pokud chcete, aby sloučení selhalo místo zavedení dalšího rozvržení do cílového masteru.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/), pokud přesně víte, které cílové rozvržení mají importované snímky použít.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationLayout = destination->get_LayoutSlide(0);

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, destinationLayout);
}

destination->Save(u"merged-with-destination-layout.pptx", SaveFormat::Pptx);
```

Přidání cílového rozvržení mění zděděný vztah rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišnou strukturu zástupných objektů, prohlédněte výsledek a ověřte, že zděděné formátování a chování zástupných objektů jsou vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí snímku automaticky nepřetváří jeho obsah pro nové plátno. Tvary se tak mohou jevit posunuté, nečekaně změněné velikosti nebo mimo viditelnou oblast snímku.

Praktickým přístupem je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize::SetSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesize/setsize/) může měřítko stávajícího obsahu při změně rozměrů snímku. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/) měřítkem přizpůsobí obsah požadované velikosti.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto destinationSize = destination->get_SlideSize()->get_Size();
auto sourceSize = source->get_SlideSize()->get_Size();

if (sourceSize.get_Width() != destinationSize.get_Width() || 
    sourceSize.get_Height() != destinationSize.get_Height())
{
    source->get_SlideSize()->SetSize(
        destinationSize.get_Width(), 
        destinationSize.get_Height(), 
        SlideSizeScaleType::EnsureFit);
}

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide);
}

destination->Save(u"merged-same-slide-size.pptx", SaveFormat::Pptx);
```

Změna velikosti mění objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci nezměněnou pro jiné operace, otevřete pro sloučení samostatnou instanci.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce ve výstupu důležité, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/).

```cpp
#include <DOM/ISectionCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto destination = System::MakeObject<Presentation>(u"destination.pptx");
auto source = System::MakeObject<Presentation>(u"source.pptx");

auto importedSection = destination->get_Sections()->AppendEmptySection(u"Imported slides");

for (const auto& slide : source->get_Slides())
{
    destination->get_Slides()->AddClone(slide, importedSection);
}

destination->Save(u"merged-with-section.pptx", SaveFormat::Pptx);
```

Klonované snímky jsou připojeny ke specifikované cílové sekci. Pro zachování několika zdrojových sekcí znovu vytvořte tyto sekce v cíli a přiřaďte každý zdrojový snímek k odpovídající cílové sekci.

## **Bezpečné sloučení více prezentací**

Následující end-to-end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, udržuje každý zdroj otevřený pouze po dobu kopírování a nakonec uloží výsledný soubor.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

System::String inputFiles[] = {u"part1.pptx", u"part2.pptx", u"part3.pptx"};
const int32_t inputFileCount = 3;

auto merged = System::MakeObject<Presentation>(inputFiles[0]);
auto mergedSize = merged->get_SlideSize()->get_Size();

for (int32_t fileIndex = 1; fileIndex < inputFileCount; fileIndex++)
{
    auto source = System::MakeObject<Presentation>(inputFiles[fileIndex]);
    auto sourceSize = source->get_SlideSize()->get_Size();

    if (sourceSize.get_Width() != mergedSize.get_Width() || 
        sourceSize.get_Height() != mergedSize.get_Height())
    {
        source->get_SlideSize()->SetSize(
            mergedSize.get_Width(), 
            mergedSize.get_Height(), 
            SlideSizeScaleType::EnsureFit);
    }

    for (const auto& slide : source->get_Slides())
    {
        merged->get_Slides()->AddClone(slide);
    }
}

merged->Save(u"merged.pptx", SaveFormat::Pptx);
```

Toto je užitečný výchozí stav pro zachování formátování importovaných snímků. Pokud výstup musí používat jediný cílový motiv, nahraďte jednoduché volání `AddClone(slide)` příslušným přetížením pro cílový master nebo cílové rozvržení, jak bylo uvedeno dříve.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides udržuje vnitřní registr automaticky klonovaných masterů, aby nedocházelo k opakovanému klonování stejného masteru. Manuálně klonované mastery nejsou tímto registrem sledovány, proto se vyhněte předklonování masterů, pokud nevyžadujete explicitní kontrolu nad strukturou masteru.

Nepředpokládejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud korporátní šablona má kontrolovat finální vzhled, zvolte explicitně cílový master nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky prezentátora a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou kopírovány při klonování snímku. Aspose.Slides také poskytuje vyhrazené API pro [presentation notes](https://docs.aspose.com/slides/cs/cpp/presentation-notes/) a [presentation comments](https://docs.aspose.com/slides/cs/cpp/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, ověřte sloučenou prezentaci, protože mastery poznámek jsou objekty na úrovni prezentace a mohou se lišit mezi zdrojovými soubory. Pro revizní procesy také ověřte autory komentářů a vlákna komentářů po sloučení souborů od různých autorů či šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování jen viditelných tvarů, aby Aspose.Slides mohlo udržovat vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje by měly být zpracovány odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepřemění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevřena.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je důležitá velikost výstupního souboru, prohlédněte sloučený balíček a změřte výsledek místo spoléhaní na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud má typografie zůstávat konzistentní napříč počítači, nepředpokládejte, že pouhé klonování snímků zaručuje, že každý požadovaný font bude dostupný v cílovém prostředí. Můžete prohlédnout vložené fonty pomocí [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a spravovat vkládání explicitně, jak je popsáno v [Embed Fonts in Presentations](https://docs.aspose.com/slides/cs/cpp/embedded-font/).

Také ověřte, že máte povoleno vkládat fonty použité ve zdrojových souborech. Licenční podmínky fontů mohou vkládání omezovat.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než mohou být jeho snímky klonovány. Heslo zadejte pomocí [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Otevření šifrovaného zdroje automaticky nepřenáší stejné zabezpečení do cílové prezentace. Pokud je potřeba, nakonfigurujte ochranu výstupu samostatně.

### **Velké prezentace a spotřeba paměti**

Velké prezentace obsahující vysokorozlišovací obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značné množství paměti. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) poskytuje ovládací prvky pro správu BLOB a dočasných souborů. Viz [Manage Presentation BLOBs](https://docs.aspose.com/slides/cs/cpp/manage-blob/) pro strategie velkých souborů.

U velkých souborů upřednostněte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci ihned po jejím sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost při více vláknech**

Nenačítejte, neměňte, neukládejte ani neklonujte stejnou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) instanci souběžně z více vláken. Udržujte každou instanci prezentace omezenou na jeden sloučovací úkon. Pokud paralelizujete nezávislé úlohy, použijte nezávislé instance prezentací a řiďte se [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/cs/cpp/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní návrh každé zdrojové prezentace?**

Použijte [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud ho importovaný snímek potřebuje.

**Jak přimět importované snímky používat cílový motiv?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k vhodnému rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, když má každý importovaný snímek používat známé rozvržení. Použijte master, pokud chcete, aby Aspose.Slides vybral rozvržení mezi rozvrženími tohoto masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku není automaticky přetvořen pro rozměry cíle. Pokud potřebujete předvídatelné umístění, nejprve změňte velikost zdrojové prezentace, například pomocí [SlideSize::SetSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesize/setsize/) a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejnou sadu funkcí, ověřte složitý obsah po meziformátových sloučeních. Viz [Supported File Formats](https://docs.aspose.com/slides/cs/cpp/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Není to pravda u základní smyčky, která pouze klonuje snímky. Znovu vytvořte požadované sekce v cíli a použijte sekční přetížení [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) pokud je nutné zachovat strukturu sekcí.

**Zachovají se poznámky prezentátora a komentáře?**

Kopírují se s klonovaným snímkem. Pro procesy závislé na stylování masteru poznámek, autorech komentářů nebo vláknových recenzních datech ověřte výsledek sloučení, protože tyto scénáře zahrnují struktury na úrovni prezentace i obsahu snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenášen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být po sloučení stále dostupné.

**Jsou vložené fonty ze všech zdrojů garantovaně dostupné v sloučené prezentaci?**

Nespoléhejte se pouze na klonování snímků pro nasazení fontů. Prohlédněte vložené fonty v cíli a explicitně spravujte vkládání fontů nebo dostupnost externích fontů, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej se správným [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/), poté klonujte jeho snímky normálně. Ochrana výstupu se nastavuje samostatně.

**Jak mám zacházet s velmi velkými prezentacemi?**

Používejte správu BLOB, pokud velké binární objekty dominují spotřebě paměti, upřednostněte načítání z cest k souborům u velmi velkých souborů, rychle uvolňujte zdrojové prezentace a finální výsledek ukládejte jen v případě potřeby.

**Mohu sloučit snímky z více vláken?**

Nepoužívejte stejnou [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) instanci souběžně z více vláken. Udržujte každou operaci sloučení izolovanou ve vlastní instanci prezentace.