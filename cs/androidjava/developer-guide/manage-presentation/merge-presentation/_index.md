---
title: Efektivní sloučení prezentací na Androidu
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Zjistěte, jak na Androidu sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides for Android via Java slučuje prezentace klonováním snímků z jedné [Prezentace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozvržení v cílové prezentaci.

Tento článek pokrývá nejčastější scénáře slučování:

- sloučit všechny snímky při zachování jejich zdrojového formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end‑to‑end scénáři;
- řešit mastery, zdroje, poznámky, komentáře, média, písma, hesla, velké soubory a problémy s multithreadingem.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snímek dědí velkou část vzhledu ze svého rozvržení a masteru. Z tohoto důvodu zvolený přetížený způsob klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachovat rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery tak, aby opakované snímky používající stejný zdrojový master nevedly k opakovanému klonování tohoto masteru.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétnímu cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `addClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo ke konkrétnímu cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/).

Master nebo rozvržení předané přetíženému `addClone` musí patřit **cílové** prezentaci, nikoli zdrojové.

## **Sloučit celé prezentace a zachovat zdrojové formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové. Toto je vhodná volba, když mají importované snímky zachovat své původní téma, master a vztahy rozvržení.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné návrhy. To je očekávané, když je zdrojové formátování úmyslně zachováno.

## **Sloučit vybrané snímky**

Nemusíte klonovat každý snímek. Následující příklad importuje pouze vybrané indexy snímků ze zdrojové prezentace.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Před klonováním ověřte indexy snímků, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-), když by importované snímky měly následovat master, který již náleží cílové prezentaci.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides vybere vhodné rozvržení pod zadaným masterem porovnáním typu nebo názvu zdrojového rozvržení. Pokud žádné vhodné rozvržení neexistuje a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, vyvolá se [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/).

Použijte `false`, když chcete, aby sloučení selhalo místo přidání dalšího rozvržení do cílového masteru.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-), když přesně víte, které cílové rozvržení mají importované snímky použít.

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aplikace cílového rozvržení mění zděděný vztah rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišnou strukturu zástupných objektů, zkontrolujte výsledek, aby byly zděděné formátování a chování zástupných objektů vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí automaticky nepřetvoří jeho obsah pro novou plochu. Tvary se tak mohou zdát posunuté, špatně měřené nebo mimo viditelnou oblast snímku.

Praktický přístup je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) může měřit existující obsah při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Změna velikosti upravuje objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci nezměněnou pro další operace, otevřete pro sloučení samostatnou instanci.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud sekce hrají roli ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a explicitně klonujte snímky do nich pomocí [addClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Klonované snímky se připojí k určené cílové sekci. Pro zachování několika zdrojových sekcí projděte [Presentation.getSections](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSections--), získejte aktuální snímky každé zdrojové sekce pomocí [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--), znovu vytvořte sekce v cíli a klonujte každý vrácený snímek do odpovídající cílové sekce. Viz [Manage Slide Sections](/slides/cs/androidjava/slide-section/) pro kompletní příklad enumerace sekcí, včetně prázdných sekcí a strukturálních změn.

## **Bezpečně sloučit více prezentací**

Následující end‑to‑end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, drží každý zdroj otevřený pouze během kopírování a nakonec uloží finální soubor.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

Jedná se o užitečný výchozí scénář pro zachování zdrojového formátování importovaných snímků. Pokud výstup musí používat jediný cílový motiv, nahraďte jednoduché volání `addClone(slide)` příslušným přetížením pro cílový master nebo cílové rozvržení uvedeným výše.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést potřebný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr automaticky klonovaných masterů, aby se stejný master neklonoval opakovaně. Ručně klonované mastery nejsou v tomto registru sledovány, proto se vyhněte předklonování masterů, pokud nepotřebujete explicitní kontrolu nad strukturou masteru.

Neočekávejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud korporátní šablona musí řídit finální vzhled, vyberte explicitně cílový master nebo rozvržení a výsledek po sloučení ověřte.

### **Poznámky a komentáře**

Poznámky k řečníkovi a komentáře ke snímkům jsou svázány s obsahem snímku a jsou zkopírovány při jeho klonování. Aspose.Slides také poskytuje specializovaná API pro [presentation notes](/slides/cs/androidjava/presentation-notes/) a [presentation comments](/slides/cs/androidjava/presentation-comments/).

Pokud je formátování stránky poznámek důležité, ověřte sloučenou prezentaci, protože poznámkové mastery jsou objekty na úrovni celé prezentace a mohou se mezi zdrojovými soubory lišit. Pro revizní workflow také ověřte autory komentářů a strukturu vlákna po sloučení souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte celý snímek místo kopírování jen viditelných tvarů, aby Aspose.Slides zachoval vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje je třeba ošetřit rozdílně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepromění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru důležitá, prohlédněte sloučený balíček a změřte výsledek místo spoléhání se na implicitní deduplikaci.

### **Vložená písma a dostupnost písem**

Písma jsou spravována na úrovni prezentace. Pokud má typografie zůstat konzistentní napříč zařízeními, nevyvozujte, že klonování snímků samo zajistí, že všechna potřebná písma jsou dostupná v cílovém prostředí. Vložená písma můžete prozkoumat pomocí [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a spravovat jejich vložení explicitně, jak je popsáno v [Embed Fonts in Presentations](/slides/cs/androidjava/embedded-font/).

Také ověřte, že máte oprávnění vložit písma použité ve zdrojových souborech. Licenční podmínky mohou vkládání omezovat.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem je nutné nejprve úspěšně otevřít, než lze jeho snímky klonovat. Heslo předávejte pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // Pracujte s dešifrovanou prezentací.
} finally {
    source.dispose();
}
```

Otevření šifrovaného zdroje automaticky nepřenáší stejnou ochranu na cílovou prezentaci. Ochranu výstupu nastavte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné objemné binární objekty mohou spotřebovat značné množství paměti. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) poskytuje nastavení pro správu BLOB a dočasných souborů. Viz [Manage Presentation BLOBs](/slides/cs/androidjava/manage-blob/) pro strategie práce s velkými soubory.

U velkých souborů upřednostňujte načítání z cest souborů, pokud je to možné, uvolněte každou zdrojovou prezentaci ihned po jejím sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje checkpointy.

### **Bezpečnost při práci s vlákny**

Nenačítejte, neupravujte, neukládejte ani nekloonujte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) současně z více vláken. Každou prezentaci omezte na jednu operaci sloučení. Pokud paralelizujete nezávislé úlohy, používejte nezávislé instance prezentací a řiďte se [Aspose.Slides multithreading guidance](/slides/cs/androidjava/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní design každé zdrojové prezentace?**

Použijte [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud ho importovaný snímek potřebuje.

**Jak přimět importované snímky používat cílové téma?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k odpovídajícímu rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, když má každý importovaný snímek používat jedno známé rozvržení. Použijte master, když chcete, aby Aspose.Slides vybral mezi rozvrženími tohoto masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku se automaticky nepřetvoří pro cílové rozměry. Před sloučením změňte velikost zdrojové prezentace, například pomocí [SlideSize.setSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesizescaletype/).

**Mohu sloučit soubory PPT, PPTX a ODP do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože různé formáty nepodporují přesně stejnou sadu funkcí, po sloučení napříč formáty ověřte složitý obsah. Viz [Supported File Formats](/slides/cs/androidjava/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne při základní smyčce, která pouze klonuje snímky. Vytvořte požadované sekce v cíli a použijte sekční přetížení [addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), pokud je struktura sekcí nutná.

**Zachovají se poznámky řečníka a komentáře?**

Ano, kopírují se s klonovaným snímkem. Pro workflow závislé na stylování poznámkového masteru, autorech komentářů nebo vláknové revizi ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni celé prezentace i snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah zůstává součástí vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být i po sloučení dostupné.

**Jsou vložená písma ze všech zdrojů garantována v sloučené prezentaci?**

Nespoléhejte se pouze na klonování snímků pro nasazení písem. Prohlédněte vložená písma v cíli a explicitně spravujte jejich vložení nebo dostupnost externích písem, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s pomocí správného [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), poté běžně klonujte jeho snímky. Ochrana výstupu se nastavuje odděleně.

**Jak mám zacházet s velmi velkými prezentacemi?**

Používejte správu BLOB, pokud velké binární objekty dominují využití paměti, upřednostňujte načítání z cest souborů, rychle uvolňujte zdrojové prezentace po jejich sloučení a finální výsledek ukládejte jen jednou, když je to potřeba.

**Mohu sloučit snímky z více vláken?**

Nekombinujte jednu instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) současně v několika vláknech. Každou operaci sloučení izolujte do vlastní instance prezentace.