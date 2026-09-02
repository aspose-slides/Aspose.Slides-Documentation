---
title: Efektivně slučovat prezentace v .NET
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
description: "Zjistěte, jak v .NET sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozložení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides pro .NET slučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru nebo rozložení v cílové prezentaci.

Tento článek popisuje nejčastější scénáře slučování:

- sloučit všechny snímky při zachování jejich zdrojového formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozložení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom kompletním workflow;
- zpracovat mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a otázky související s multithreadingem.

## **Jak klonování snímků ovlivňuje mastery a rozložení**

Snímek dědí většinu svého vzhledu ze svého rozložení a masteru. Z tohoto důvodu výběr přetížení (overload) klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection.AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) jedním z následujících způsobů:

- `AddClone(sourceSlide)` — zachovat rozložení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery, takže opakované snímky používající stejný zdrojový master nevedou k opakovanému klonování tohoto masteru.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek k určitému cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterslide/). Aspose.Slides hledá odpovídající rozložení pod tímto masterem podle typu nebo názvu rozložení.
- `AddClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo k určitému cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/net/aspose.slides/ilayoutslide/).

Master nebo rozložení předané přetížení `AddClone` musí patřit **cílové** prezentaci, nikoli zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat zdrojové formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když importované snímky mají zachovat svůj původní motiv, master a vztahy rozložení.

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

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné designy. To je očekávané, když je zdrojové formátování úmyslně zachováno.

## **Sloučit vybrané snímky**

Nemusíte klonovat každý snímek. Následující příklad importuje jen vybrané indexy snímků ze zdrojové prezentace.

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

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) když mají importované snímky následovat master, který již patří cílové prezentaci.

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

Aspose.Slides vybere vhodné rozložení pod zadaným masterem porovnáním typu nebo názvu zdrojového rozložení. Pokud neexistuje vhodné rozložení a `allowCloneMissingLayout` je `true`, zdrojové rozložení se klonuje, aby mohl být snímek přidán. Pokud je `false`, vyvolá se [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception/).

Použijte `false`, když chcete, aby sloučení selhalo místo zavedení dalšího rozložení do cílového masteru.

## **Sloučit snímky pomocí konkrétního cílového rozložení**

Použijte přetížení [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) když přesně víte, které cílové rozložení mají importované snímky použít.

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

Použití cílového rozložení mění děděný vztah rozložení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozložení odlišné struktury placeholderů, prověřte výsledek, aby děděné formátování a chování placeholderů bylo vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí automaticky nepřetváří jeho obsah pro nové plátno. Tvary se tak mohou jevit posunuté, neočekávaně měřené nebo mimo viditelnou oblast snímku.

Praktickým přístupem je před klonováním změnit velikost zdrojové prezentace. Metoda [SlideSize.SetSize](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesize/setsize/) může škálovat existující obsah při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

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

Změna velikosti upravuje objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci beze změny pro další operace, otevřete pro sloučení samostatnou instanci.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/).

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

Klonované snímky se připojí ke specifikované cílové sekci. Pro zachování několika zdrojových sekcí je replikujte v cíli a přiřaďte každý zdrojový snímek odpovídající cílové sekci.

## **Bezpečné sloučení více prezentací**

Následující end-to-end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, udržuje každý zdroj otevřený jen během kopírování a ukládá finální soubor jednorázově.

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

Toto je užitečná výchozí metoda pro zachování zdrojového formátování importovaných snímků. Pokud výstup musí použít jednotný motiv cíle, nahraďte jednoduché volání `AddClone(slide)` vhodným přetížením pro cílový master nebo cílové rozložení uvedeným dříve.

## **Praktické úvahy**

### **Mastery, rozložení a přesnost formátování**

Výchozí klonování snímků může automaticky přenést potřebný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr automaticky klonovaných masterů, aby se stejný master neklonoval opakovaně. Manuálně klonované mastery nejsou v tomto registru sledovány, proto se vyhněte předklonování masterů, pokud nepotřebujete explicitní kontrolu nad strukturou masteru.

Neočekávejte, že dva mastery nebo rozložení se stejným názvem jsou vizuálně ekvivalentní. Pokud firemní šablona musí řídit finální vzhled, vyberte explicitně cílový master nebo rozložení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky k prezentéru a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou kopírovány při klonování snímku. Aspose.Slides také poskytuje dedikovaná API pro [presentation notes](https://docs.aspose.com/slides/cs/net/presentation-notes/) a [presentation comments](https://docs.aspose.com/slides/cs/net/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, ověřte sloučenou prezentaci, protože mastery poznámek jsou objekty na úrovni prezentace a mohou se mezi zdrojovými soubory lišit. Pro revizní workflow ověřte také autory komentářů a strukturu vláken po kombinaci souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložený audio, vložené video a OLE data. Klonujte celý snímek místo pouhého kopírování viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje je třeba zacházet odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku neupřednostňuje externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevřena.

Aspose.Slides sleduje automaticky klonované mastery, ale to by nemělo být chápáno jako obecná záruka, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru podstatná, prozkoumejte sloučený balíček a změřte výsledek namísto spoléhání se na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud typografie musí zůstat konzistentní mezi stroji, nepředpokládejte, že klonování snímků samotných zaručuje dostupnost každého požadovaného fontu v cílovém prostředí. Vložené fonty můžete zkontrolovat pomocí [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/cs/net/aspose.slides/fontsmanager/getembeddedfonts/) a spravovat jejich vložení explicitně, jak je popsáno v [Embed Fonts in Presentations](https://docs.aspose.com/slides/cs/net/embedded-font/).

Také ověřte, že máte oprávnění vkládat fonty použité ve zdrojových souborech. Licenční podmínky fontů mohou vkládání omezovat.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo předávejte pomocí [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Otevření šifrovaného zdroje automaticky nepřenáší stejnou ochranu do cílové prezentace. Ochranu výstupu nakonfigurujte zvlášť podle potřeby.

### **Velké prezentace a spotřeba paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné rozsáhlé binární objekty mohou spotřebovávat značné množství paměti. [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/blobmanagementoptions/) poskytuje řízení pro práci s BLOBy a dočasnými soubory. Viz [Manage Presentation BLOBs](https://docs.aspose.com/slides/cs/net/manage-blob/) pro strategie s velkými soubory.

U velkých souborů upřednostňujte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci ihned po sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítejte, neupravujte, neukládejte ani nekloňte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) současně z více vláken. Každou instanci prezentace omezte na jednu operaci sloučení. Pokud paralelizujete nezávislé úlohy, použijte nezávislé instance prezentací a řiďte se [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/cs/net/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní design každé zdrojové prezentace?**

Použijte [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/) bez zadání cílového masteru nebo rozložení. Aspose.Slides může automaticky klonovat zdrojový master, když jej importovaný snímek potřebuje.

**Jak přimět importované snímky použít motiv cíle?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k vhodnému rozložení pod tímto masterem.

**Kdy použít konkrétní cílové rozložení místo cílového masteru?**

Použijte konkrétní rozložení, když má každý importovaný snímek použít jedno známé rozložení. Použijte master, když chcete, aby Aspose.Slides vybral rozložení z masteru na základě typu nebo názvu zdrojového rozložení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku se automaticky nepřetváří na nové rozměry. Pro předvídatelné umístění nejprve změňte velikost zdrojové prezentace, například pomocí [SlideSize.SetSize](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesize/setsize/) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/net/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejný soubor funkcí, po cross-format sloučení ověřte složitý obsah. Viz [Supported File Formats](https://docs.aspose.com/slides/cs/net/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne, základní smyčka, která klonuje jen snímky, sekce neobnoví. Vytvořte požadované sekce v cíli a použijte sekční přetížení [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/addclone/), pokud má být struktura sekcí zachována.

**Zachovají se poznámky a komentáře?**

Ano, jsou zkopírovány s klonovaným snímkem. Pro workflow, které závisí na stylování masteru poznámek, autorech komentářů nebo vláknové revizi, ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni prezentace i obsahu snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je součástí vztahů zdrojových zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být po sloučení stále dostupné.

**Jsou vložené fonty ze všech zdrojů garantovány v sloučené prezentaci?**

Nespoléhejte se jen na klonování snímků pro nasazení fontů. Prozkoumejte vložené fonty v cíli a explicitně spravujte vložení nebo dostupnost externích fontů, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s použitím správného [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/) a poté klonujte jeho snímky běžně. Ochrana výstupu se konfiguruje odděleně.

**Jak mám nakládat s velmi velkými prezentacemi?**

Používejte správu BLOBů, pokud velké binární objekty dominují paměti, upřednostňujte načítání z cest k souborům, okamžitě uvolněte zdrojové prezentace po jejich sloučení a finální výsledek ukládejte jen jednorázově.

**Mohu klonovat snímky z více vláken?**

Nenechávejte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) používat současně z více vláken. Každou operaci sloučení izolujte do vlastních instancí prezentace.