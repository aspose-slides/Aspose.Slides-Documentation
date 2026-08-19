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

Aspose.Slides for Android via Java sloučí prezentace klonováním snímků z jedné [Prezentace](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) do druhé. Hlavní operací je [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), která může zachovat formátování původního snímku nebo připojit klonovaný snímek k masteru či rozvržení v cílové prezentaci.

Tento článek pokrývá nejčastější postupy slučování:

- sloučit všechny snímky při zachování jejich původního formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom end‑to‑end postupu;
- řešit mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a problémy s vícevláknovostí.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snimek dědí velkou část vzhledu ze svého rozvržení a masteru. Z tohoto důvodu výběr přetížení klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [ISlideCollection.addClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachovat rozvržení a formátování původního snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery, takže opakované snímky používající stejný zdrojový master způsobí, že master nebude klonován opakovaně.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek ke konkrétnímu cílovému [IMasterSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `addClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo k specifickému cílovému [ILayoutSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslide/).

Master nebo rozvržení předané přetížení `addClone` musí patřit **cílové** prezentaci, ne zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat původní formátování**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když importované snímky mají zachovat svůj původní motiv, master a vztahy rozvržení.

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

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné návrhy. To je očekávané, když je původní formátování úmyslně zachováno.

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

Ověřte indexy snímků před klonováním, pokud pocházejí z uživatelského vstupu nebo externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , když importované snímky mají následovat master, který již patří cílové prezentaci.

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

Aspose.Slides vybere vhodné rozvržení pod zadaným masterem na základě typu nebo názvu zdrojového rozvržení. Pokud žádné vhodné rozvržení neexistuje a `allowCloneMissingLayout` je `true`, zdrojové rozvržení je klonováno, aby mohl být snímek přidán. Pokud je `false`, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pptxeditexception/).

Použijte `false`, pokud chcete, aby sloučení selhalo místo zavedení dalšího rozvržení do cílového masteru.

## **Sloučit snímky pomocí konkrétního cílového rozvržení**

Použijte přetížení [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) , když přesně víte, které cílové rozvržení mají importované snímky použít.

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

Aplikace cílového rozvržení mění děděný vztah rozvržení; nepřetváří obsah původního snímku. Pokud mají zdrojové a cílové rozvržení odlišné struktury zástupných objektů, prověřte výsledek, abyste potvrdili, že děděné formátování a chování zástupných objektů jsou vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí snímku automaticky nepřetvoří jeho obsah pro nové plátno. Tvary se tak mohou jevit posunuté, nečekaně změněné měřítko, nebo mimo viditelnou oblast snímku.

Praktickým přístupem je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize.setSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) může změnit měřítko existujícího obsahu při změně rozměrů snímku. [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesizescaletype/) měřítko přizpůsobí obsah tak, aby se vešel do požadované velikosti.

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

Změna velikosti upraví objekt zdrojové prezentace v paměti. Pokud potřebujete původní zdrojovou prezentaci neporušenou pro jiné operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnoví hierarchii sekcí zdrojové prezentace. Pokud jsou sekce v výstupu důležité, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [addClone(ISlide, ISection)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-).

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

Klonované snímky jsou připojeny k určené cílové sekci. Pro zachování několika zdrojových sekcí vytvořte tyto sekce v cíli a přiřaďte každý zdrojový snímek k odpovídající cílové sekci.

## **Bezpečně sloučit více prezentací**

Následující end‑to‑end příklad používá první prezentaci jako cílovou, normalizuje velikost snímku každého dalšího zdroje, udržuje každý zdroj otevřený jen během kopírování a ukládá konečný soubor jednou.

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

Toto je užitečný výchozí bod pro zachování původního formátování importovaných snímků. Pokud výstup musí používat jediný cílový motiv, nahraďte jednoduché volání `addClone(slide)` vhodným přetížením pro cílový master nebo cílové rozvržení uvedeným dříve.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr automaticky klonovaných masterů, aby se předešlo opakovanému klonování stejného masteru. Ručně klonované mastery nejsou tímto registrem sledovány, proto se vyhněte předklonování masterů, pokud nepotřebujete explicitní kontrolu nad strukturou masteru.

Nepředpokládejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud korporátní šablona musí řídit konečný vzhled, vyberte cílový master nebo rozvržení explicitně a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky přednášejícího a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou kopírovány při klonování snímku. Aspose.Slides také poskytuje dedikovaná API pro [poznámky prezentace](https://docs.aspose.com/slides/cs/androidjava/presentation-notes/) a [komentáře prezentace](https://docs.aspose.com/slides/cs/androidjava/presentation-comments/).

Pokud je formátování stránky poznámek důležité, ověřte sloučenou prezentaci, protože notmastery jsou objekty na úrovni prezentace a mohou se lišit mezi zdrojovými soubory. Pro workflow recenzí také ověřte autory komentářů a vlákna komentářů po sloučení souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování pouze viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k jeho zdrojům.

Vložené a odkazované zdroje by měly být zpracovány odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepřemění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplicitovány. Pokud je důležitá velikost výstupního souboru, prohlédněte sloučený balíček a změřte výsledek místo spoléhání se na implicitní deduplikaci.

### **Vložené fonty a jejich dostupnost**

Fonty jsou spravovány na úrovni prezentace. Pokud má typografie zůstat konzistentní napříč počítači, nepředpokládejte, že samotné klonování snímků zaručuje, že každý požadovaný font bude dostupný v cílovém prostředí. Můžete prohlédnout vložené fonty pomocí [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) a spravovat vkládání explicitně, jak je popsáno v [Vkládání fontů do prezentací](https://docs.aspose.com/slides/cs/androidjava/embedded-font/).

Také ověřte, že máte oprávnění vložit fonty použité ve zdrojových souborech. Licence fontů mohou omezovat vkládání.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo poskytněte pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-).

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

Otevření zašifrovaného zdroje automaticky nepřenáší stejnou ochranu na cílovou prezentaci. Ochranu výstupu nakonfigurujte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značnou paměť. [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) poskytuje ovládání pro správu BLOB a používání dočasných souborů. Viz [Správa BLOB v prezentacích](https://docs.aspose.com/slides/cs/androidjava/manage-blob/) pro strategie práce s velkými soubory.

U velkých souborů upřednostňujte načítání z cest souborů, pokud je to možné, uvolněte každou zdrojovou prezentaci, jakmile je sloučena, a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost při vícevláknovém provozu**

Nenačítejte, neupravujte, neukládejte ani neklonujte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/) současně z více vláken. Udržujte každou instanci prezentace omezenu na jednu operaci sloučení. Pokud paralelizujete nezávislé úlohy, používejte nezávislé instance prezentací a řiďte se pokyny pro vícevláknovost Aspose.Slides.

## **FAQ**

**Jak udržet původní návrh každé zdrojové prezentace?**

Použijte `addClone(sourceSlide)` bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud jej importovaný snímek potřebuje.

**Jak zajistit, aby importované snímky používaly cílový motiv?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k odpovídajícímu rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, pokud má každý importovaný snímek používat jedno známé rozvržení. Použijte master, pokud chcete, aby Aspose.Slides vybral mezi rozvrženími toho masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku není automaticky přepracován pro cílové rozměry. Změňte velikost zdrojové prezentace nejprve, pokud potřebujete předvídatelné umístění, například pomocí [SlideSize.setSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) a [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slidesizescaletype/).

**Lze sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují exakt stejné funkce, po cross‑formátovém sloučení ověřte složitý obsah. Viz [Podporované formáty souborů](https://docs.aspose.com/slides/cs/androidjava/supported-file-formats/).

**Zůstávají zdrojové sekce automaticky zachovány?**

Ne, základní smyčka, která pouze klonuje snímky, automaticky neuchovává sekce. Vytvořte požadované sekce v cíli a použijte přetížení sekce `addClone` když struktura sekcí musí být zachována.

**Zůstávají poznámky přednášejícího a komentáře zachovány?**

Ano, jsou kopírovány s klonovaným snímkem. Pro workflow závislé na stylování masteru poznámek, autorech komentářů nebo vláknech recenzí ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni prezentace i snímku.

**Co se stane s audio, video, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenášen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být po sloučení stále dostupné.

**Nespoléhejte se pouze na klonování snímků pro nasazení fontů?**  
Ne, nepředpokládejte, že samotné klonování snímků zaručuje dostupnost všech vložených fontů. Prohlédněte vložené fonty v cíli a explicitně spravujte vkládání fontů nebo jejich externí dostupnost, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s správným [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-), poté klonujte jeho snímky normálně. Ochrana výstupu se konfiguruje samostatně.

**Jak mám zacházet s velmi velkými prezentacemi?**

Použijte správu BLOB, pokud velké binární objekty dominují využití paměti, upřednostňujte načítání z cest souborů, rychle uvolňujte zdrojové prezentace a ukládejte konečný výsledek jen tehdy, když je potřeba.

**Mohou být snímky sloučeny z více vláken?**

Nepoužívejte jednu instanci Presentation současně z více vláken. Udržujte každou operaci sloučení oddělenou svými vlastními instancemi prezentací.