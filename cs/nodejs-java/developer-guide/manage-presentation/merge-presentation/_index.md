---
title: Efektivně sloučit prezentace v JavaScriptu
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak v JavaScriptu sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozložení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides for Node.js via Java sloučí prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) do druhé. Hlavní operací je [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozložení v cílové prezentaci.

Tento článek popisuje nejčastější postupy slučování:

- sloučit všechny snímky a zachovat jejich formátování ze zdroje;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozložení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end-to-end postupu;
- řešit mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a problémy s vícevláknovým zpracováním.

## **Jak klonování snímků ovlivňuje mastery a rozložení**

Snímek zdědí velkou část svého vzhledu z rozložení a masteru. Z tohoto důvodu zvolený přetížený metod klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachovat rozložení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides automaticky sleduje klonované mastery, takže opakované snímky používající stejný zdrojový master nevedou k opakovanému klonování tohoto masteru.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétnímu cílovému [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/). Aspose.Slides hledá odpovídající rozložení pod tímto masterem podle typu nebo názvu rozložení.
- `addClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo k specifickému cílovému [LayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/).

Master nebo rozložení předané do přetížené metody `addClone` musí patřit **cílové** prezentaci, nikoli zdrojové.

## **Sloučit celé prezentace a zachovat formátování zdroje**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové. Toto je vhodná volba, když importované snímky mají zachovat své původní téma, master a vztahy rozložení.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné motivy. To je očekávané, když je záměrně zachováno formátování zdroje.

## **Sloučit vybrané snímky**

Nemusíte klonovat každý snímek. Následující příklad importuje jen vybrané indexy snímků ze zdrojové prezentace.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Před klonováním ověřte indexy snímků, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) když importované snímky mají následovat master, který již patří cílové prezentaci.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides vybere vhodné rozložení pod zadaným masterem porovnáním typu nebo názvu zdrojového rozložení. Pokud žádné vhodné rozložení neexistuje a `allowCloneMissingLayout` je `true`, zdrojové rozložení se klonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/).

Použijte `false`, pokud chcete, aby sloučení selhalo místo zavedení dalšího rozložení do cílového masteru.

## **Sloučit snímky pomocí konkrétního cílového rozložení**

Použijte přetížení [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) když přesně víte, které cílové rozložení mají importované snímky použít.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Použití cílového rozložení mění zděděný vztah rozložení; nepřetváří obsah zdrojového snímku. Pokud se struktura placeholderů zdrojového a cílového rozložení liší, zkontrolujte výsledek, aby zděděné formátování a chování placeholderů bylo vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s odlišnými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí nezmění automaticky jeho obsah pro nové plátno. Tvary se tak mohou jevit posunuté, škálované neočekávaně nebo mimo viditelnou oblast snímku.

Praktický postup je před klonováním změnit velikost zdrojové prezentace. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) může škálovat existující obsah při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Změna velikosti mění objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci nezměněnou pro další operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a explicitně klonujte snímky do nich pomocí [addClone(Slide, Section)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-).

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Klonované snímky jsou připojeny k určené cílové sekci. Pro zachování několika zdrojových sekcí znovu vytvořte tyto sekce v cíli a mapujte každý zdrojový snímek na odpovídající cílovou sekci.

## **Bezpečné sloučení více prezentací**

Následující end-to-end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, drží každou zdrojovou prezentaci otevřenou jen po dobu kopírování a uloží finální soubor jednou.

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Jedná se o užitečný výchozí scénář pro zachování formátování importovaných snímků. Pokud výstup musí používat jediný cílový motiv, nahraďte jednoduché volání `addClone(sourceSlide)` příslušným přetížením masteru nebo rozložení uvedeným dříve.

## **Praktická úvaha**

### **Mastery, rozložení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést potřebný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr pro automaticky klonované mastery, aby nedocházelo k opakovanému klonování stejného masteru. Manuálně klonované mastery nejsou tímto registrem sledovány, proto se vyhněte předklonování masterů, pokud není zapotřebí explicitní kontrola struktury masteru.

Nepočitujte se, že dva mastery nebo rozložení se stejným názvem jsou vizuálně ekvivalentní. Pokud korporátní šablona musí řídit finální vzhled, zvolte explicitně cílový master nebo rozložení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky řečníka a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou při klonování zkopírovány. Aspose.Slides také poskytuje dedikovaná API pro [presentation notes](https://docs.aspose.com/slides/cs/nodejs-java/presentation-notes/) a [presentation comments](https://docs.aspose.com/slides/cs/nodejs-java/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, ověřte sloučenou prezentaci, protože mastery poznámek jsou objekty na úrovni celé prezentace a mohou se mezi zdrojovými soubory lišit. Pro revizní pracovní postupy také ověřte autory komentářů a vlákna komentářů po kombinaci souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, video a OLE data. Klonujte samotný snímek místo kopiování jen viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje je třeba zacházet odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nezmění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides výslovně sleduje automaticky klonované mastery, ale to by nemělo být vnímáno jako obecná záruka, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru důležitá, prohlédněte sloučený balíček a změřte výsledek místo spoléhání se na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud musí typografie zůstat konzistentní napříč stroji, nepředpokládejte, že samotné klonování snímků zaručuje, že každý potřebný font bude dostupný v cílovém prostředí. Vložené fonty můžete zkontrolovat pomocí [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) a spravovat vložení explicitně, jak je popsáno v [Embed Fonts in Presentations](https://docs.aspose.com/slides/cs/nodejs-java/embedded-font/).

Také ověřte, že máte povolení vložit fonty použité ve zdrojových souborech. Licenční podmínky fontů mohou omezení vložení stanovovat.

### **Prezentace chráněné heslem**

Zdrojová prezentace chráněná heslem musí být otevřena úspěšně, než lze její snímky klonovat. Heslo zadejte pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // Pracujte s dešifrovanou prezentací.
} finally {
    source.dispose();
}
```

Otevření šifrovaného zdroje automaticky nepřenáší stejnou ochranu na cílovou prezentaci. Výstupní ochranu nakonfigurujte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značnou paměť. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) poskytuje ovládací prvky pro správu BLOB a dočasných souborů. Viz [Manage Presentation BLOBs](https://docs.aspose.com/slides/cs/nodejs-java/manage-blob/) pro strategie při práci s velkými soubory.

U velkých souborů upřednostňujte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci, jakmile je sloučena, a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítejte, neukládejte ani neklonujte instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) ve více vláknech. Tyto operace nejsou podporovány v multithreadovém prostředí. Pokud potřebujete paralelizovat nezávislé úlohy sloučení, použijte několik jednovláknových procesů, z nichž každý má své vlastní instance prezentací, a řiďte se [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/cs/nodejs-java/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní design každé zdrojové prezentace?**

Použijte [`addClone(sourceSlide)`](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) bez zadání cílového masteru nebo rozložení. Aspose.Slides může automaticky klonovat zdrojový master, pokud jej importovaný snímek potřebuje.

**Jak přimět importované snímky použít téma cílové prezentace?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí mapovat každý zdrojový snímek na vhodné rozložení pod tímto masterem.

**Kdy použít konkrétní cílové rozložení místo cílového masteru?**

Použijte konkrétní rozložení, když má každý importovaný snímek používat jedno známé rozložení. Použijte master, když chcete, aby Aspose.Slides vybral mezi rozloženími tohoto masteru na základě typu nebo názvu zdrojového rozložení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku není automaticky přepracován pro rozměry cíle. Převyššíte zdrojovou prezentaci předem, například pomocí [SlideSize.setSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují naprosto stejný soubor funkcí, ověřte složitý obsah po cross-formátovém sloučení. Viz [Supported File Formats](https://docs.aspose.com/slides/cs/nodejs-java/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne, ne základní smyčka, která pouze klonuje snímky. Vytvořte požadované sekce v cíli a použijte sekční přetížení [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-), pokud musí být struktura sekcí zachována.

**Zachovají se poznámky řečníka a komentáře?**

Jsou zkopírovány s klonovaným snímkem. Pro workflow, které závisí na stylování masteru poznámek, autorech komentářů nebo vláknových revizích, ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury jak na úrovni prezentace, tak snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenesen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být po sloučení stále dostupné.

**Jsou vložené fonty ze všech zdrojů zaručeně dostupné v sloučené prezentaci?**

Nespoléhejte se jen na klonování snímků pro nasazení fontů. Zkontrolujte vložené fonty v cíli a explicitně spravujte vložení fontů nebo externí dostupnost fontů, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej pomocí správného [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), poté klonujte jeho snímky normálně. Výstupní ochrana se nastavuje odděleně.

**Jak zacházet s velmi velkými prezentacemi?**

Používejte správu BLOB, pokud velké binární objekty dominují využití paměti, upřednostňujte načítání z cest k souborům pro opravdu velké soubory, promptně uvolňujte zdrojové prezentace a finální výsledek ukládejte jen tehdy, když je to potřeba.

**Mohu klonovat snímky z více vláken?**

Nenačítejte, neukládejte ani neklonujte instance prezentací ve více vláknech. Pro paralelní úlohy sloučení použijte oddělené jednovláknové procesy a nezávislé instance prezentací.