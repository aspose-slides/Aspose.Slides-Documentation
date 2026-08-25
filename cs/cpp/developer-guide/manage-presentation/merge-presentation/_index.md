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
description: "Zjistěte, jak v C++ sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných či velkých souborů."
---
## **Přehled**

Aspose.Slides pro C++ slučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozvržení v cílové prezentaci.

Tento článek pokrývá nejčastější postupy slučování:

- sloučit všechny snímky při zachování jejich zdrojového formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end‑to‑end postupu;
- řešit mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory i problémy s vícevláknovým provozem.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snímek dědí velkou část vzhledu ze svého rozvržení a masteru. Z tohoto důvodu zvolená přetížení klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection::AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) jedním z následujících způsobů:

- `AddClone(sourceSlide)` — zachovat rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky naklonován do cílové prezentace. Aspose.Slides automaticky sledované naklonované mastery tak zabrání opakovanému klonování stejného masteru.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétnímu cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/imasterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `AddClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo ke konkrétnímu cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ilayoutslide/).

Master nebo rozvržení předané přetížení `AddClone` musí patřit **cílové** prezentaci, ne zdrojové.

## **Sloučit celé prezentace a zachovat zdrojové formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové. Toto je vhodná volba, když importované snímky mají zachovat svůj původní motiv, master a vztahy rozvržení.

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

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné návrhy. To je očekávané, když je zdrojové formátování úmyslně zachováno.

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

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatele či z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [AddClone(ISlide, IMasterSlide, bool)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) když importované snímky mají následovat master, který již patří cílové prezentaci.

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

Aspose.Slides vybere vhodné rozvržení pod zadaným masterem podle typu nebo názvu zdrojového rozvržení. Pokud neexistuje vhodné rozvržení a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se naklonuje, aby mohl být snímek přidán. Pokud je `false`, vyvolá se [PptxEditException](https://reference.aspose.com/slides/cs/cpp/aspose.slides/details_pptxeditexception/).

Použijte `false`, když chcete, aby sloučení selhalo místo toho, aby se do cílového masteru přidalo další rozvržení.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) když přesně víte, které cílové rozvržení mají importované snímky použít.

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

Použití cílového rozvržení změní zděděný vztah rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišnou strukturu placeholderů, zkontrolujte výsledek, aby byla zděděná formátování a chování placeholderů vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s odlišnými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí automaticky nepřetvoří jeho obsah na novou plochu. Tvary se tak mohou jevit posunuté, neočekávaně škálované nebo mimo viditelnou oblast snímku.

Praktickým přístupem je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize::SetSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesize/setsize/) může měřítkem upravit existující obsah při změně rozměrů snímku. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

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

Změna velikosti upravuje objekt zdrojové prezentace v paměti. Pokud potřebujete původní zdrojovou prezentaci neporušenou pro další operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnoví hierarchii sekcí ze zdrojové prezentace. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/).

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

Klonované snímky jsou připojeny k určené cílové sekci. Chcete‑li zachovat několik zdrojových sekcí, projděte [Presentation::get_Sections](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/get_sections/), získejte aktuální snímky každé zdrojové sekce pomocí [ISection::GetSlidesListOfSection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/isection/getslideslistofsection/), vytvořte sekce v cíli a klonujte každý vrácený snímek do odpovídající cílové sekce. Viz [Manage Slide Sections](/slides/cs/cpp/slide-section/) pro kompletní ukázku enumerace sekcí, včetně prázdných sekcí a strukturálních změn.

## **Bezpečně sloučit více prezentací**

Následující end‑to‑end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, drží každý zdroj otevřený jen po dobu kopírování a soubor uloží až na konci.

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

Toto je užitečný výchozí bod pro zachování zdrojového formátování importovaných snímků. Pokud výstup musí používat jednotný motiv cíle, nahraďte jednoduché volání `AddClone(slide)` přetížením pro cílový master nebo cílové rozvržení, jak bylo ukázáno dříve.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides udržuje vnitřní registr pro automaticky naklonované mastery, aby se předešlo opakovanému klonování stejného masteru. Manuálně naklonované mastery nejsou v tomto registru sledovány, proto se vyhněte předklonování masterů, pokud nepotřebujete explicitní kontrolu nad strukturou masteru.

Neočekávejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud korporátní šablona musí řídit finální vzhled, zvolte explicitně cílový master nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky přednášejícího a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou při klonování zkopírovány. Aspose.Slides také poskytuje dedikované API pro [presentation notes](/slides/cs/cpp/presentation-notes/) a [presentation comments](/slides/cs/cpp/presentation-comments/).

Pokud je formátování stránky s poznámkami důležité, ověřte sloučenou prezentaci, protože mastery poznámek jsou objekty na úrovni prezentace a mohou se mezi zdrojovými soubory lišit. Pro recenzní workflow také ověřte autory komentářů a vlákna komentářů po kombinaci souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování jen viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje by měly být zpracovány odlišně. Odkazovaný audio, video, OLE objekt či hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nezmění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides explicitně sleduje automaticky naklonované mastery, ale to by nemělo být vnímáno jako obecná záruka, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru důležitá, prohlédněte sloučený balíček a změřte výsledek místo spoléhání se na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud má typografie zůstat konzistentní napříč stroji, neočekávejte, že pouhé klonování snímků zaručí, že každý požadovaný font bude k dispozici v cílovém prostředí. Vložené fonty můžete zkontrolovat pomocí [FontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/cs/cpp/aspose.slides/fontsmanager/getembeddedfonts/) a spravovat vkládání explicitně, jak je popsáno v [Embed Fonts in Presentations](/slides/cs/cpp/embedded-font/).

Také ověřte, že máte právo vkládat fonty použité ve zdrojových souborech. Licence fontů mohou omezovat vkládání.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo předávejte pomocí [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/).

```cpp
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto source = System::MakeObject<Presentation>(u"protected.pptx", loadOptions);
```

Otevření šifrovaného zdroje automaticky nepřenáší stejné zabezpečení na cílovou prezentaci. Ochranu výstupu nastavte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovávat značnou paměť. [LoadOptions::set_BlobManagementOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_blobmanagementoptions/) poskytuje řízení pro manipulaci s BLOBy a používání dočasných souborů. Viz [Manage Presentation BLOBs](/slides/cs/cpp/manage-blob/) pro strategie s velkými soubory.

U velkých souborů upřednostňujte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci ihned po sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítejte, nemodifikujte, neukládejte ani neklonujte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) současně z více vláken. Každou prezentaci omezte na jeden sloučovací úkon. Pokud paralelizujete nezávislé úlohy, používejte nezávislé instance prezentací a řiďte se [Aspose.Slides multithreading guidance](/slides/cs/cpp/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní návrh každé zdrojové prezentace?**

Použijte [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky naklonovat zdrojový master, pokud je importovaným snímkem požadován.

**Jak přimět importované snímky použít motiv cíle?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdroje. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k vhodnému rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, když má každý importovaný snímek použít jedno známé rozvržení. Použijte master, když chcete, aby Aspose.Slides vybralo mezi rozvrženími tohoto masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku není automaticky přepracován pro rozměry cíle. Pro předvídatelné umístění nejprve změňte velikost zdrojové prezentace, například pomocí [SlideSize::SetSize](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesize/setsize/) a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/cpp/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují úplně stejný soubor funkcí, po cross‑formátovém sloučení ověřte složitý obsah. Viz [Supported File Formats](/slides/cs/cpp/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne při základní smyčce, která pouze klonuje snímky. Znovu vytvořte požadované sekce v cíli a použijte sekční přetížení [AddClone](https://reference.aspose.com/slides/cs/cpp/aspose.slides/islidecollection/addclone/), pokud má být struktura sekcí zachována.

**Zachovají se poznámky přednášejícího a komentáře?**

Ano, jsou zkopírovány s klonovaným snímkem. Pro workflow, které závisí na stylování masteru poznámek, autorech komentářů nebo vláknové recenzi, výsledek po sloučení ověřte, protože tyto scénáře zahrnují struktury na úrovni prezentace i obsahu snímku.

**Co se stane s audio, video, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenesen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory či URL musí být i po sloučení dostupné.

**Jsou vložené fonty ze všech zdrojů garantováno dostupné ve sloučené prezentaci?**

Nespoléhejte se pouze na klonování snímků pro nasazení fontů. Prohlédněte vložené fonty v cíli a explicitně spravujte vkládání nebo externí dostupnost fontů, když je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s korektním [LoadOptions::set_Password](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_password/), poté klonujte jeho snímky normálně. Ochrana výstupu se nastavuje odděleně.

**Jak zacházet s velmi velkými prezentacemi?**

Používejte správu BLOBů, když velké binární objekty domínují využití paměti, upřednostňujte načítání z cest k souborům, rychle uvolňujte zdrojové prezentace po sloučení a finální výsledek ukládejte jen tehdy, když je to nutné.

**Mohu klonovat snímky z více vláken?**

Nenapojte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) souběžně z více vláken. Každý sloučovací úkon izolujte do vlastní instance prezentace.