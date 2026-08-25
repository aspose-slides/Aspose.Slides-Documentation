---
title: Efektivně sloučit prezentace v .NET
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak sloučit prezentace PowerPoint a OpenDocument v .NET klonováním snímků, řízením předloh a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides for .NET spojuje prezentace klonováním snímků z jedné [Prezentace](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k předloze či rozvržení v cílové prezentaci.

Tento článek popisuje nejčastější scénáře slučování:

- sloučit všechny snímky při zachování jejich zdrojového formátování;
- sloučit vybrané snímky;
- použít předlohu z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end‑to‑end pracovním postupu;
- řešit předlohy, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a problémy s vícevláknovým zpracováním.

## **Jak klonování snímků ovlivňuje předlohy a rozvržení**

Snímek dědí velkou část vzhledu ze svého rozvržení a předlohy. Z tohoto důvodu zvolený přetížený metod `AddClone` určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) jedním z těchto způsobů:

- `AddClone(sourceSlide)` — zachovat rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojová předloha automaticky klonována do cílové prezentace. Aspose.Slides automaticky sleduje klonované předlohy, aby se opakované snímky používající stejnou zdrojovou předlohu neklonovaly opakovaně.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétní cílové [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/). Aspose.Slides vyhledá odpovídající rozvržení pod touto předlohou podle typu nebo názvu rozvržení.
- `AddClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo ke konkrétnímu cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/).

Předloha nebo rozvržení předávané do přetížení `AddClone` musí patřit **cílové** prezentaci, nikoli zdrojové.

## **Sloučit celé prezentace a zachovat zdrojové formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové. Toto je vhodná volba, když mají importované snímky zachovat původní motiv, předlohu a vztahy rozvržení.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Výsledná prezentace může obsahovat více předloh, pokud zdroj a cíl používají odlišné designy. To je očekávané, když je zdrojové formátování úmyslně zachováno.

## **Sloučit vybrané snímky**

Nemusíte klonovat každý snímek. Následující příklad importuje pouze vybrané indexy snímků ze zdrojové prezentace.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Před klonováním ověřte indexy snímků, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílové předlohy**

Použijte přetížení [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/), když mají importované snímky následovat předlohu, která již patří cílové prezentaci.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides vybere vhodné rozvržení pod zadanou předlohou podle typu nebo názvu rozvržení zdrojového snímku. Pokud neexistuje vhodné rozvržení a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, vyvolá se [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception/).

Použijte `false`, pokud chcete, aby sloučení selhalo místo toho, aby se do cílové předlohy přidalo další rozvržení.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/), když přesně víte, které cílové rozvržení mají importované snímky použít.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Použití cílového rozvržení mění zděděný vztah rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišné struktury zástupných objektů, zkontrolujte výsledek, aby zděděné formátování a chování zástupných objektů bylo vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s odlišnými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí automaticky nepřetvoří jeho obsah na novou plochu. Tvary se tak mohou objevit posunuté, nečekaně škálované nebo mimo viditelnou oblast snímku.

Praktickým přístupem je před klonováním změnit velikost zdrojové prezentace. Metoda [SlideSize.SetSize](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesize/setsize/) dokáže změnit rozměry snímku a současně přizpůsobit existující obsah. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby zapadl do požadované velikosti.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Změna velikosti upravuje objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci beze změny pro další operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a explicitně klonujte snímky do nich pomocí [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Klonované snímky jsou připojeny ke specifikované cílové sekci. Pro zachování několika zdrojových sekcí projděte [Presentation.Sections](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/sections/), získejte aktuální snímky každé zdrojové sekce pomocí [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isection/getslideslistofsection/), znovu vytvořte sekce v cíli a klonujte každý vrácený snímek do odpovídající cílové sekce. Viz [Manage Slide Sections](/slides/cs/net/slide-section/) pro kompletní příklad enumerace sekcí, včetně prázdných sekcí a strukturálních změn.

## **Bezpečné sloučení více prezentací**

Následující end‑to‑end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, drží každý zdroj otevřený jen po dobu kopírování a po dokončení uloží finální soubor.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Jedná se o užitečný výchozí scénář pro zachování zdrojového formátování importovaných snímků. Pokud výstup musí používat jednotný motiv cíle, nahraďte jednoduché volání `AddClone(slide)` příslušným přetížením s cílovou předlohou nebo cílovým rozvržením, jak bylo ukázáno dříve.

## **Praktické úvahy**

### **Předlohy, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést potřebnou zdrojovou předlohu do cílové prezentace. Aspose.Slides udržuje interní registr automaticky klonovaných předloh, aby nedocházelo k opakovanému klonování stejné předlohy. Ručně klonované předlohy nejsou tímto registrem sledovány, proto se vyhněte předklonování předloh, pokud nepotřebujete explicitní kontrolu nad strukturou předlohy.

Předpokládejte, že dvě předlohy nebo rozvržení se stejným názvem nejsou vizuálně ekvivalentní. Pokud korporátní šablona musí řídit finální vzhled, vyberte explicitně cílovou předlohu nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky přednášejícího a komentáře k snímkům jsou svázány s obsahem snímku a jsou kopírovány při jeho klonování. Aspose.Slides také poskytuje dedikované API pro [poznámky prezentace](/slides/cs/net/presentation-notes/) a [komentáře prezentace](/slides/cs/net/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, zkontrolujte sloučenou prezentaci, protože poznámkové předlohy jsou objekty na úrovni prezentace a mohou se mezi soubory lišit. Pro recenzní workflow ověřte také autory komentářů a vlákna komentářů po kombinaci souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte celý snímek místo pouhého kopírování viditelných tvarů, aby Aspose.Slides mohl zachovat vazby snímku na jeho zdroje.

Vložené a odkazované zdroje by se měly zpracovávat odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepromění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides explicitně sleduje automaticky klonované předlohy, ale nemělo by se to považovat za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru důležitá, prohlédněte sloučený balíček a změřte výsledek místo spoléhaní se na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud musí typografie zůstat konzistentní napříč stroji, nepředpokládejte, že klonování snímků samotných zaručuje, že každý požadovaný font bude dostupný v cílovém prostředí. Vložené fonty můžete zkontrolovat pomocí [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) a spravovat jejich vložení explicitně, jak je popsáno v [Embed Fonts in Presentations](/slides/cs/net/embedded-font/).

Také ověřte, že máte oprávnění vložit fonty použité ve zdrojových souborech. Licence fontů mohou vložení omezovat.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo zadejte pomocí [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Otevření šifrovaného zdroje automaticky neaplikuje stejnou ochranu na cílovou prezentaci. Ochranu výstupu nakonfigurujte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovávat značnou paměť. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/blobmanagementoptions/) poskytuje ovládací prvky pro správu BLOB a dočasných souborů. Viz [Manage Presentation BLOBs](/slides/cs/net/manage-blob/) pro strategie práce s velkými soubory.

U velkých souborů upřednostňujte načítání z cest souborů, pokud je to možné, uvolněte každou zdrojovou prezentaci, jakmile je sloučena, a vyhněte se opakovanému ukládání mezivýsledků, pokud to workflow nevyžaduje.

### **Vláknová bezpečnost**

Nenačítejte, nemodifikujte, neukládejte ani neklonujte stejnou [Prezentaci](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) souběžně z více vláken. Každou instanci prezentace omezte na jeden sloučovací úkol. Pokud paralelizujete nezávislé úlohy, použijte nezávislé instance prezentací a řiďte se [průvodcem pro vícevláknové zpracování Aspose.Slides](/slides/cs/net/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní design každé zdrojové prezentace?**

Použijte [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) bez zadání cílové předlohy nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojovou předlohu, pokud ji importovaný snímek potřebuje.

**Jak donutit importované snímky používat motiv cíle?**

Použijte přetížení, které přijímá cílovou předlohu. Předávejte předlohu z cílové prezentace, nikoli ze zdroje. Aspose.Slides se pokusí mapovat každý zdrojový snímek na vhodné rozvržení pod touto předlohou.

**Kdy použít konkrétní cílové rozvržení místo cílové předlohy?**

Použijte konkrétní rozvržení, když má každý importovaný snímek používat jedno známé rozvržení. Použijte předlohu, když chcete, aby Aspose.Slides vybralo mezi rozvrženími předlohy na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku není automaticky přepracován pro rozměry cíle. Pro předvídatelné umístění nejprve změňte velikost zdrojové prezentace, např. pomocí [SlideSize.SetSize](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesize/setsize/) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejný soubor funkcí, po sloučení napříč formáty ověřte složitý obsah. Viz [Supported File Formats](/slides/cs/net/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne, základní smyčka, která klonuje jen snímky, sekce neobnoví. Vytvořte požadované sekce v cíli a použijte sekční přetížení [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/), pokud musí být struktura sekcí zachována.

**Zachovají se poznámky přednášejícího a komentáře?**

Ano, jsou kopírovány s klonovaným snímkem. Pro workflow, které závisí na stylu poznámkové předlohy, autorech komentářů nebo vláknových recenzních datech, ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni prezentace i snímku.

**Co se stane s audio, video, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenesen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí i po sloučení být dostupné.

**Jsou vložené fonty ze všech zdrojů garantovány v sloučené prezentaci?**

Nespoléhejte se pouze na klonování snímků pro nasazení fontů. Zkontrolujte vložené fonty v cíli a explicitně spravujte jejich vložení nebo dostupnost externích fontů, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s platným [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/), poté klonujte jeho snímky běžně. Ochrana výstupu se konfiguruje samostatně.

**Jak zacházet s velmi velkými prezentacemi?**

Použijte správu BLOB, pokud dominují velké binární objekty, upřednostněte načítání z cest souborů pro opravdu velké soubory, rychle uvolňujte zdrojové prezentace a finální výsledek ukládejte jen jednou, když je to nutné.

**Mohu klonovat snímky z více vláken?**

Nekombinujte jednu [Prezentaci](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) souběžně napříč více vlákny. Každý sloučovací úkol izolujte do vlastní instance prezentace.