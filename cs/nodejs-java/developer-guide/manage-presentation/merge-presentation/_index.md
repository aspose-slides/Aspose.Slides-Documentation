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
description: "Naučte se, jak sloučit PowerPoint a OpenDocument prezentace v JavaScriptu klonováním snímků, řízením masterů a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides pro Node.js přes Java sloučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) do druhé. Hlavní operací je [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru nebo rozvržení v cílové prezentaci.

Tento článek pokrývá nejčastější pracovní postupy sloučení:

- sloučit všechny snímky při zachování jejich původního formátování;
- sloučit vybrané snímky;
- použít master ze cílové prezentace;
- použít konkrétní rozvržení ze cílové prezentace;
- normalizovat odlišné velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end-to-end pracovním postupu;
- zpracovat mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a problémy s více vlákny.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snímek dědí velkou část svého vzhledu z rozvržení a masteru. Z tohoto důvodu zvolený přetížený způsob klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [SlideCollection.addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachovat rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery, takže opakované snímky používající stejný zdrojový master nevedou k opakovanému klonování tohoto masteru.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétnímu cílovému [MasterSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/masterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `addClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo k určitému cílovému [LayoutSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/layoutslide/).

Master nebo rozvržení předané do přetížené metody `addClone` musí patřit **cílové** prezentaci, nikoli zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat formátování zdroje**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když importované snímky mají zachovat svůj původní motiv, master a vztahy rozvržení.

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

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné návrhy. To je očekávané, když je úmyslně zachováno formátování zdroje.

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

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatele nebo z externí konfigurace.

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

Aspose.Slides vybere vhodné rozvržení pod uvedeným masterem podle typu nebo názvu rozvržení zdroje. Pokud neexistuje vhodné rozvržení a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/pptxeditexception/).

Použijte `false`, když chcete, aby sloučení selhalo místo toho, aby se do cílového masteru přidal další layout.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) když přesně víte, které cílové rozvržení mají importované snímky používat.

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

Aplikace cílového rozvržení mění pouze zděděný vztah rozvržení; nemění se obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišnou strukturu placeholderů, zkontrolujte výsledek, aby byly zděděné formátování a chování placeholderů vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s odlišnými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí automaticky nepřizpůsobí jeho obsah novému plátnu. Tvary se tak mohou jevit jako posunuté, nesprávně měřené nebo mimo viditelnou oblast snímku.

Praktický přístup je před klonováním změnit velikost zdrojové prezentace. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) může škálovat existující obsah při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

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

Změna velikosti mění objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci nezměněnou pro další operace, otevřete pro sloučení samostatnou instanci.

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

Klonované snímky jsou přidány na konec určené cílové sekce. Pro zachování několika zdrojových sekcí projděte [Presentation.getSections](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getSections), získejte aktuální snímky každé zdrojové sekce pomocí [Section.getSlidesListOfSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/section/#getSlidesListOfSection), znovu vytvořte sekce v cíli a klonujte každý vrácený snímek do odpovídající cílové sekce. Viz [Manage Slide Sections](/slides/cs/nodejs-java/slide-section/) pro kompletní příklad enumerace sekcí, včetně prázdných sekcí a strukturálních změn.

## **Bezpečné sloučení více prezentací**

Následující end-to-end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, ponechává každý zdroj otevřený jen během kopírování a uloží finální soubor jednou.

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

Jedná se o užitečný výchozí bod pro zachování formátování importovaných snímků. Pokud výstup musí používat jednotné téma cíle, nahraďte jednoduché volání `addClone(sourceSlide)` vhodným přetížením pro cílový master nebo cílové rozvržení uvedeným dříve.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr pro automaticky klonované mastery, aby nedocházelo k opakovanému klonování stejného masteru. Ručně klonované mastery nejsou v tomto registru sledovány, proto se vyhněte předklonování masterů, pokud necítíte potřebu explicitně řídit strukturu masteru.

Nevyjádřujte předpoklad, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud firemní šablona musí kontrolovat konečný vzhled, vyberte explicitně cílový master nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky řečníka a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou zkopírovány při klonování snímku. Aspose.Slides také poskytuje dedikovaná API pro [presentation notes](/slides/cs/nodejs-java/presentation-notes/) a [presentation comments](/slides/cs/nodejs-java/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, ověřte sloučenou prezentaci, protože mastery pro poznámky jsou objekty na úrovni celé prezentace a mohou se mezi zdrojovými soubory lišit. Pro recenzní pracovní postupy také ověřte autory komentářů a vlákna komentářů po kombinaci souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování jen viditelných tvarů, aby Aspose.Slides udržel vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje je třeba zpracovávat odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nevyrobí externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, ve kterém bude sloučená prezentace otevřena.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je důležitá velikost výstupního souboru, prohlédněte sloučený balíček a změřte výsledek místo spoléhání se na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud musí typografie zůstat konzistentní napříč stroji, nepředpokládejte, že klonování snímků samo zajistí dostupnost každého požadovaného fontu v cílovém prostředí. Vložené fonty můžete zkontrolovat pomocí [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) a spravovat vkládání explicitně podle návodu v [Embed Fonts in Presentations](/slides/cs/nodejs-java/embedded-font/).

Také ověřte, že máte oprávnění vložit fonty použité ve zdrojových souborech. Licenční podmínky fontů mohou vkládání omezovat.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo předávejte pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword-String-).

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

Otevření šifrovaného zdroje automaticky neaplikuje stejnou ochranu na cílovou prezentaci. Ochranu výstupu nakonfigurujte samostatně, pokud je požadována.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovávat značnou paměť. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) poskytuje ovládací prvky pro správu BLOB a dočasných souborů. Viz [Manage Presentation BLOBs](/slides/cs/nodejs-java/manage-blob/) pro strategie práce s velkými soubory.

U velkých souborů upřednostňujte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci ihned po jejím sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítěte, neukládejte ani neklonujte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) v několika vláknech najednou. Tyto operace nejsou podporovány pro vícevláknové použití. Pokud potřebujete paralelizovat nezávislé úlohy sloučení, použijte několik jednovláknových procesů, každý s vlastními instancemi prezentací, a řiďte se [Aspose.Slides multithreading guidance](/slides/cs/nodejs-java/multithreading/).

## **FAQ**

**Jak zachovat původní design každé zdrojové prezentace?**

Použijte [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud je importovaným snímkem potřeba.

**Jak zajistit, aby importované snímky použily téma cílové prezentace?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí mapovat každý zdrojový snímek na vhodné rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, když mají všechny importované snímky používat jedno známé rozvržení. Použijte master, když chcete, aby Aspose.Slides vybralo rozvržení z tohoto masteru na základě typu nebo názvu rozvržení zdroje.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku se automaticky nepřizpůsobí novým rozměrům. Pro předvídatelné umístění nejprve změňte velikost zdrojové prezentace, například pomocí [SlideSize.setSize](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože různé formáty nepodporují přesně stejnou sadu funkcí, po sloučení napříč formáty ověřte složitý obsah. Viz [Supported File Formats](/slides/cs/nodejs-java/supported-file-formats/).

**Zachovávají se sekce ze zdroje automaticky?**

Ne při základní smyčce, která jen klonuje snímky. Vytvořte požadované sekce v cílové prezentaci a použijte sekční přetížení [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-), pokud musí být struktura sekcí zachována.

**Zachovávají se poznámky řečnitelského a komentáře?**

Ano, jsou kopírovány s klonovaným snímkem. Pro workflow závislé na stylování masteru pro poznámky, autorech komentářů nebo vláknové recenze ověřte sloučený výsledek, protože tyto scénáře zahrnují objekty na úrovni celé prezentace i obsah snímků.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenesen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externími, takže jejich cílové soubory nebo URL musí být i po sloučení dostupné.

**Jsou vložené fonty ze všech zdrojů zaručeně dostupné v sloučené prezentaci?**

Nespoléhejte se jen na klonování snímků pro nasazení fontů. Prohlédněte vložené fonty v cíli a explicitně spravujte vkládání fontů nebo dostupnost externích fontů, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s správným [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword-String-), poté klonujte jeho snímky normálně. Ochrana výstupu se konfiguruje samostatně.

**Jak zacházet s velmi velkými prezentacemi?**

Používejte správu BLOB, pokud velké binární objekty dominují využití paměti, upřednostňujte načítání z cest k souborům, rychle uvolňujte zdrojové prezentace po sloučení a finální výsledek ukládejte jen tehdy, když je to nutné.

**Mohu sloučit snímky z více vláken?**

Nenačítejte, neukládejte ani neklonujte instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) ve více vláknech najednou. Pro paralelní úlohy sloučení použijte samostatné jednovláknové procesy s vlastními instancemi prezentací.