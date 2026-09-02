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
description: "Naučte se, jak v Javě sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením hlavních a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides for Java spojuje prezentace klonováním snímků z jedné [Prezentace](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k hlavě nebo rozvržení v cílové prezentaci.

Tento článek popisuje nejčastější postupy sloučení:

- sloučit všechny snímky při zachování jejich zdrojového formátování;
- sloučit vybrané snímky;
- použít hlavičku (master) z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end-to-end pracovním postupu;
- zpracovat hlavní (masters), zdroje, poznámky, komentáře, média, písma, hesla, velké soubory a problémy s vícenásobným vláknením.

## **Jak klonování snímků ovlivňuje hlavní (masters) a rozvržení**

Snímek dědí velkou část svého vzhledu z rozvržení a hlavní (master). Z tohoto důvodu volba přetížení klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachová rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery, takže opakované snímky používající stejný zdrojový master nevedou k opakovanému klonování tohoto masteru.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojí klonovaný snímek k určitému cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu rozvržení nebo názvu.
- `addClone(sourceSlide, destinationLayout)` — připojí klonovaný snímek přímo k určitému cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslide/).

Master nebo rozvržení předané přetížení `addClone` musí patřit **cílové** prezentaci, nikoli zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat zdrojové formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když importované snímky mají zachovat své původní téma, master a vztahy rozvržení.

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

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají různé návrhy. To je očekávané, když je zdrojové formátování úmyslně zachováno.

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

Použijte [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) přetížení, když mají importované snímky následovat master, který již patří do cílové prezentace.

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

Aspose.Slides vybírá vhodné rozvržení pod zadaným masterem porovnáním typu nebo názvu rozvržení zdrojového snímku. Pokud neexistuje vhodné rozvržení a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pptxeditexception/).

Použijte `false`, když chcete, aby sloučení selhalo místo toho, aby se do cílového masteru přidalo další rozvržení.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) přetížení, když přesně víte, které cílové rozvržení mají importované snímky použít.

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

Použití cílového rozvržení mění děděnou vazbu rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišné struktury zástupných objektů, prohlédněte výsledek a ověřte, že děděné formátování a chování zástupných objektů jsou vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí neprovedete automaticky redesign obsahu pro novou plochu. Tvary se tak mohou jevit posunuté, neočekávaně měřené nebo mimo viditelnou oblast snímku.

Praktickým přístupem je před klonováním změnit velikost zdrojové prezentace. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesize/#setSize-float-float-int-) může škálovat existující obsah při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

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

Změna velikosti mění objekt zdrojové prezentace v paměti. Pokud potřebujete původní zdrojovou prezentaci zachovat nezměněnou pro další operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnoví hierarchii sekcí ve zdrojové prezentaci. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [addClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Klonované snímky jsou připojeny ke specifikované cílové sekci. Pro zachování několika zdrojových sekcí enumerujte [Presentation.getSections](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSections--), získejte aktuální snímky každé zdrojové sekce pomocí [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/isection/#getSlidesListOfSection--), znovu vytvořte sekce v cíli a klonujte každý vrácený snímek do odpovídající cílové sekce. Viz [Manage Slide Sections](/slides/cs/java/slide-section/) pro kompletní příklad enumerace sekcí, včetně prázdných sekcí a strukturálních změn.

## **Bezpečné sloučení více prezentací**

Následující end-to-end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, drží každý zdroj otevřený pouze během kopírování a uloží finální soubor jednou.

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

Jedná se o užitečný výchozí základ pro zachování formátování importovaných snímků. Pokud váš výstup musí používat jediné cílové téma, nahraďte jednoduché volání `addClone(slide)` odpovídajícím přetížením pro cílový master nebo cílové rozvržení, jak bylo uvedeno dříve.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr automaticky klonovaných masterů, aby se zabránilo opakovanému klonování stejného masteru. Ručně klonované mastery nejsou tímto registrem sledovány, proto se vyhněte předklonování masterů, pokud nepotřebujete explicitní kontrolu nad strukturou masterů.

Neočekávejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud firemní šablona musí řídit finální vzhled, zvolte explicitně cílový master nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky přednášejícího a komentáře k snímkům jsou svázány s obsahem snímku a jsou kopírovány při klonování snímku. Aspose.Slides také poskytuje dedikované API pro [presentation notes](/slides/cs/java/presentation-notes/) a [presentation comments](/slides/cs/java/presentation-comments/).

Pokud je formátování stránky poznámek důležité, ověřte sloučenou prezentaci, protože mastery poznámek jsou objekty úrovně prezentace a mohou se mezi zdrojovými soubory lišit. Pro recenzní workflow také ověřte autory komentářů a vlákna komentářů po spojení souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování jen jeho viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje by měly být zpracovány odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepromění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je velikost výstupního souboru důležitá, prohlédněte sloučený balíček a změřte výsledek místo spolehnutí se na implicitní deduplikaci.

### **Vložená písma a jejich dostupnost**

Písma jsou spravována na úrovni prezentace. Pokud má typografie zůstat konzistentní napříč stroji, nepředpokládejte, že klonování snímků samo o sobě zaručuje, že všechna požadovaná písma budou dostupná v cílovém prostředí. Vložená písma můžete prozkoumat pomocí [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a spravovat jejich vložení explicitně, jak je popsáno v [Embed Fonts in Presentations](/slides/cs/java/embedded-font/).

Také ověřte, že máte oprávnění vložit písma použité ve zdrojových souborech. Licenční podmínky fontů mohou omezení vložení ukládat.

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

Otevření šifrovaného zdroje automaticky nepřenáší stejnou ochranu do cílové prezentace. Ochranu výstupu nastavte samostatně podle potřeby.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značnou paměť. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) poskytuje ovládání pro správu BLOBů a dočasných souborů. Viz [Manage Presentation BLOBs](/slides/cs/java/manage-blob/) pro strategie práce s velkými soubory.

U velkých souborů upřednostňujte načítání z cest souborů, pokud je to možné, uvolněte každou zdrojovou prezentaci, jakmile byla sloučena, a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítejte, neupravujte, neukládejte ani neklonujte stejnou [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) instanci souběžně z více vláken. Každou instanci prezentace omezte na jednu operaci sloučení. Pokud paralelizujete nezávislé úlohy, používejte nezávislé instance prezentací a řiďte se [Aspose.Slides multithreading guidance](/slides/cs/java/multithreading/).

## **FAQ**

**Jak mohu zachovat původní návrh každé zdrojové prezentace?**  
Použijte [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud ho importovaný snímek potřebuje.

**Jak mohu přimět importované snímky používat téma cíle?**  
Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí mapovat každý zdrojový snímek na vhodné rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**  
Použijte konkrétní rozvržení, když mají všechny importované snímky používat jedno známé rozvržení. Použijte master, když chcete, aby Aspose.Slides vybral mezi rozvrženími toho masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**  
Ano, ale obsah snímků není automaticky přepracován pro rozměry cíle. Před sloučením změňte velikost zdrojové prezentace, například pomocí [SlideSize.setSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesize/#setSize-float-float-int-) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**  
Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejnou sadu funkcí, po cross‑format sloučení ověřte složitý obsah. Viz [Supported File Formats](/slides/cs/java/supported-file-formats/).

**Jsou zdrojové sekce automaticky zachovány?**  
Ne při základní smyčce, která pouze klonuje snímky. Vytvořte požadované sekce v cíli a použijte sekční přetížení [addClone](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-), pokud musí být struktura sekcí zachována.

**Jsou poznámky a komentáře zachovány?**  
Ano, jsou zkopírovány s klonovaným snímkem. Pro workflow závislé na stylování masteru poznámek, autorech komentářů nebo vláknech recenzí ověřte sloučený výsledek, protože tyto scénáře zahrnují i struktury na úrovni prezentace.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**  
Vložený obsah je přenášen jako součást vztahů klonovaného snímku k jeho zdrojům. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být i po sloučení dostupné.

**Jsou vložená písma ze všech zdrojů garantována v sloučené prezentaci?**  
Nespoléhejte se pouze na klonování snímků pro nasazení písem. Prohlédněte vložená písma v cíli a explicitně spravujte jejich vložení nebo dostupnost externích písem, pokud je typografie důležitá.

**Jak sloučím soubor chráněný heslem?**  
Otevřete jej pomocí správného [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), pak klonujte jeho snímky běžně. Ochrana výstupu se nastavuje samostatně.

**Jak mám nakládat s velmi velkými prezentacemi?**  
Používejte správu BLOBů, pokud velké binární objekty dominují využití paměti, upřednostňujte načítání z cest souborů pro velmi velké soubory, promptně uvolňujte zdrojové prezentace a finální výsledek ukládejte jen když je to nutné.

**Mohu sloučit snímky z více vláken?**  
Není vhodné používat stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) souběžně z více vláken. Každou operaci sloučení izolujte do vlastních instancí prezentací.