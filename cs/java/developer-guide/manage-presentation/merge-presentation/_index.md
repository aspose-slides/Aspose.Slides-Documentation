---
title: Efektivně sloučit prezentace v Javě
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/java/merge-presentation/
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
- Java
- Aspose.Slides
description: "Zjistěte, jak v Javě sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides for Java sloučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozvržení v cílové prezentaci.

Tento článek popisuje nejčastější postupy slučování:

- sloučit všechny snímky při zachování jejich zdrojového formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end-to-end pracovním postupu;
- řešit mastery, zdroje, poznámky, komentáře, média, písma, hesla, velké soubory a problémy s vícevláknovým zpracováním.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snímek dědí velkou část svého vzhledu z rozvržení a masteru. Z tohoto důvodu zvolený přetížený `addClone` určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachovat rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides automaticky sleduje klonované mastery, takže opakované snímky používající stejný zdrojový master nevedou k opakovanému klonování tohoto masteru.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétnímu cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/). Aspose.Slides vyhledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `addClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo k určitému cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/).

Master nebo rozvržení předané přetíženému `addClone` musí patřit **cílové** prezentaci, ne zdrojové.

## **Sloučit celé prezentace a zachovat zdrojové formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové. Toto je vhodná volba, když importované snímky mají zachovat původní motiv, master a vztahy rozvržení.

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

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) když mají importované snímky následovat master, který již patří cílové prezentaci.

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

Aspose.Slides vybere odpovídající rozvržení pod zadaným masterem porovnáním typu nebo názvu rozvržení zdrojového snímku. Pokud vhodné rozvržení neexistuje a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/).

Použijte `false`, pokud chcete, aby sloučení selhalo místo toho, aby se do cílového masteru přidalo další rozvržení.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) když přesně víte, které cílové rozvržení mají importované snímky použít.

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

Použití cílového rozvržení mění děděný vztah rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišné struktury zástupných objektů, zkontrolujte výsledek, abyste potvrdili, že děděné formátování a chování zástupných objektů jsou vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí automaticky nepřetvoří jeho obsah pro novou plochu. Tvary se tak mohou jevit posunuté, neočekávaně měřené nebo mimo viditelnou oblast snímku.

Praktický přístup je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesize/#setSize-float-float-int-) může škálovat existující obsah při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
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

Změna velikosti mění objekt zdrojové prezentace v paměti. Pokud potřebujete zachovat původní zdrojovou prezentaci nezměněnou pro další operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [addClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Klonované snímky jsou připojeny k určené cílové sekci. Pro zachování několika zdrojových sekcí znovu vytvořte tyto sekce v cíli a mapujte každý zdrojový snímek na odpovídající cílovou sekci.

## **Bezpečně sloučit více prezentací**

Následující end-to-end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, udržuje každý zdroj otevřený jen po dobu kopírování a uloží finální soubor jednorázově.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
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

Jedná se o užitečný výchozí scénář pro zachování zdrojového formátování importovaných snímků. Pokud váš výstup musí používat jediný cílový motiv, nahraďte jednoduché volání `addClone(slide)` přetížením s cílovým masterem nebo cílovým rozvržením, jak bylo ukázáno dříve.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides vede interní rejstřík automaticky klonovaných masterů, aby nedocházelo k opakovanému klonování stejného masteru. Manuálně klonované mastery nejsou v tomto rejstříku sledovány, proto se vyhněte předklonování masterů, pokud není vyžadována explicitní kontrola struktury masteru.

Neočekávejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud firemní šablona musí řídit finální vzhled, vyberte explicitně cílový master nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky přednášejícího a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou kopírovány při jeho klonování. Aspose.Slides také poskytuje dedikované API pro [presentation notes](https://docs.aspose.com/slides/cs/java/presentation-notes/) a [presentation comments](https://docs.aspose.com/slides/cs/java/presentation-comments/).

Pokud je formátování stránky s poznámkami důležité, ověřte sloučenou prezentaci, protože mastery poznámek jsou objekty na úrovni prezentace a mohou se mezi zdrojovými soubory lišit. Pro recenzní pracovní toky také ověřte autory komentářů a vlákna komentářů po sloučení souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte celý snímek místo kopírování pouze viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje by měly být zpracovány odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepromění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru důležitá, prozkoumejte sloučený balíček a změřte výsledek místo spoléhaní se na implicitní deduplikaci.

### **Vložená písma a dostupnost písem**

Písma jsou spravována na úrovni prezentace. Pokud musí typografie zůstat konzistentní napříč stroji, nepředpokládejte, že samotné klonování snímků zaručuje, že každé požadované písmo je dostupné v cílovém prostředí. Vložená písma můžete prozkoumat pomocí [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a spravovat vkládání explicitně, jak je popsáno v článku [Embed Fonts in Presentations](https://docs.aspose.com/slides/cs/java/embedded-font/).

Také ověřte, že máte oprávnění vkládat písma použitá ve zdrojových souborech. Licenční podmínky mohou vkládání omezovat.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo zadejte pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Otevření šifrovaného zdroje automaticky neaplikuje stejnou ochranu na cílovou prezentaci. Ochranu výstupu nakonfigurujte samostatně, pokud je potřeba.

### **Velké prezentace a spotřeba paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značnou paměť. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) poskytuje ovládací prvky pro správu BLOB a dočasných souborů. Viz [Manage Presentation BLOBs](https://docs.aspose.com/slides/cs/java/manage-blob/) pro strategie při práci s velkými soubory.

U velkých souborů upřednostněte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci, jakmile je sloučena, a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítejte, neupravujte, neukládejte ani neklonujte stejnou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) instanci současně z více vláken. Každou prezentaci omezte na jeden sloučovací operaci. Pokud paralelizujete nezávislé úlohy, používejte nezávislé instance prezentací a řiďte se [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/cs/java/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní návrh každé zdrojové prezentace?**

Použijte [`addClone(sourceSlide)`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud jej importovaný snímek vyžaduje.

**Jak zajistit, aby importované snímky použily motiv cíle?**

Použijte přetížení, které přijímá cílový master. Předejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí mapovat každý zdrojový snímek na vhodné rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, když má každý importovaný snímek používat jedno známé rozvržení. Použijte master, když chcete, aby Aspose.Slides vybralo rozvržení z tohoto masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku se automaticky nepřetváří pro cílové rozměry. Nejprve změňte velikost zdrojové prezentace, pokud potřebujete předvídatelné umístění, například pomocí [SlideSize.setSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesize/#setSize-float-float-int-) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejnou sadu funkcí, po meziformátovém sloučení ověřte složitý obsah. Viz [Supported File Formats](https://docs.aspose.com/slides/cs/java/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne, ne při základní smyčce, která pouze klonuje snímky. Vytvořte požadované sekce v cíli a použijte sekční přetížení [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), když musí být struktura sekcí zachována.

**Zachovají se poznámky a komentáře přednášejícího?**

Ano, jsou kopírovány s klonovaným snímkem. Pro workflow, které závisí na stylování masteru poznámek, autorech komentářů nebo vláknech recenzí, ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni prezentace i snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je součástí vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být i po sloučení dostupné.

**Jsou vložená písma ze všech zdrojů garantována v sloučené prezentaci?**

Nespoléhejte se pouze na klonování snímků pro nasazení písem. Prozkoumejte vložená písma v cíli a explicitně spravujte vkládání písem nebo dostupnost externích písem, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej pomocí správného [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), poté klonujte jeho snímky jako obvykle. Ochrana výstupu se konfiguruje odděleně.

**Jak zacházet s velmi velkými prezentacemi?**

Používejte správu BLOB při dominanci velkých binárních objektů, upřednostněte načítání z cest k souborům pro opravdu velké soubory, rychle uvolňujte zdrojové prezentace a finální výsledek ukládejte pouze tehdy, když je to nutné.

**Mohu sloučit snímky z více vláken?**

Nepožadujte souběžné používání jedné [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) instance z více vláken. Každou operaci sloučení izolujte do vlastních instancí prezentací.