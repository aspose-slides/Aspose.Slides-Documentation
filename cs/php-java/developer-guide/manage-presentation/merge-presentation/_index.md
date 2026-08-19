---
title: Efektivně sloučit prezentace v PHP
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/php-java/merge-presentation/
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
- PHP
- Aspose.Slides
description: "Naučte se, jak v PHP sloučit prezentace PowerPoint a OpenDocument klonováním snímků, řízením masterů a rozvržení, změnou velikosti obsahu snímků, zachováním sekcí a zpracováním chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides pro PHP přes Java sloučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) do druhé. Hlavní operací je [SlideCollection::addClone()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozvržení v cílové prezentaci.

Tento článek popisuje nejčastější scénáře slučování:

- sloučit všechny snímky při zachování jejich původního formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozvržení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom kompletním pracovním postupu;
- zpracovat mastery, zdroje, poznámky, komentáře, média, písma, hesla, velké soubory a problémy s vícevláknovým zpracováním.

## **Jak klonování snímků ovlivňuje mastery a rozvržení**

Snímek dědí velkou část svého vzhledu ze svého rozvržení a masteru. Z tohoto důvodu zvolený přetížený (overload) klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [SlideCollection::addClone()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachová rozvržení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky klonován do cílové prezentace. Aspose.Slides sleduje automaticky klonované mastery, aby se opakovaně nesklonovaly stejné mastery.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojí klonovaný snímek ke konkrétnímu cílovému [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/). Aspose.Slides hledá odpovídající rozvržení pod tímto masterem podle typu nebo názvu rozvržení.
- `addClone(sourceSlide, destinationLayout)` — připojí klonovaný snímek přímo k určitému cílovému [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/).

Master nebo rozvržení předané přetížené metodě `addClone` musí patřit **cílové** prezentaci, nikoli zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat formátování zdroje**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když importované snímky mají zachovat své původní téma, master a vztahy rozvržení.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají různé návrhy. To je očekávané, když je úmyslně zachováno zdrojové formátování.

## **Sloučit vybrané snímky**

Není nutné klonovat každý snímek. Následující příklad importuje pouze vybrané indexy snímků ze zdrojové prezentace.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $slideIndexes = [0, 2, 4];

        foreach ($slideIndexes as $index) {
            $destination->getSlides()->addClone($source->getSlides()->get_Item($index));
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-selected-slides.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatelského vstupu nebo externí konfigurace.

## **Sloučit snímky s použitím cílového masteru**

Použijte přetížení [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), pokud importované snímky mají následovat master, který již patří cílové prezentaci.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationMaster = $destination->getMasters()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationMaster, true);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-master.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Aspose.Slides vybere vhodné rozvržení pod zadaným masterem podle typu nebo názvu zdrojového rozvržení. Pokud neexistuje vhodné rozvržení a `allowCloneMissingLayout` je `true`, zdrojové rozvržení se klonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/).

Použijte `false`, pokud chcete, aby sloučení selhalo místo zavedení dalšího rozvržení do cílového masteru.

## **Sloučit snímky s použitím konkrétního cílového rozvržení**

Použijte přetížení [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), když přesně víte, které cílové rozvržení mají importované snímky použít.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $destinationLayout = $destination->getLayoutSlides()->get_Item(0);

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $destinationLayout);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-destination-layout.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Použití cílového rozvržení mění děděný vztah rozvržení; nepřetváří obsah zdrojového snímku. Pokud mají zdrojové a cílové rozvržení odlišné struktury zástupných prvků, zkontrolujte výsledek a potvrďte, že děděné formátování a chování zástupných prvků jsou vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků lze sloučit, ale klonování snímku do prezentace s jinou velikostí snímku automaticky nepřetvoří jeho obsah pro nové plátno. Tvary se tak mohou jevit posunuté, neočekávaně zmenšené nebo mimo viditelnou oblast snímku.

Praktickým přístupem je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize::setSize()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/setsize/) může škálovat existující obsah při změně rozměrů snímku. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
        $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());
        $destinationWidth = java_values($destination->getSlideSize()->getSize()->getWidth());
        $destinationHeight = java_values($destination->getSlideSize()->getSize()->getHeight());

        if ($sourceWidth != $destinationWidth || $sourceHeight != $destinationHeight) {
            $source->getSlideSize()->setSize($destinationWidth, $destinationHeight, SlideSizeScaleType::EnsureFit);
        }

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-same-slide-size.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Změna velikosti upraví objekt zdrojové prezentace v paměti. Pokud potřebujete původní zdrojovou prezentaci neporušenou pro další operace, otevřete samostatnou instanci pro sloučení.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce v výstupu důležité, vytvořte nebo vyberte sekce v cílové prezentaci a klonujte snímky do nich explicitně pomocí [addClone(Slide, Section)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$destination = new Presentation("destination.pptx");
try {
    $source = new Presentation("source.pptx");
    try {
        $importedSection = $destination->getSections()->appendEmptySection("Imported slides");

        foreach ($source->getSlides() as $slide) {
            $destination->getSlides()->addClone($slide, $importedSection);
        }
    } finally {
        $source->dispose();
    }

    $destination->save("merged-with-section.pptx", SaveFormat::Pptx);
} finally {
    $destination->dispose();
}
```

Klonované snímky jsou připojeny k určené cílové sekci. Pro zachování několika zdrojových sekcí je znovu vytvořte v cíli a mapujte každý zdrojový snímek na odpovídající cílovou sekci.

## **Bezpečně sloučit více prezentací**

Následující příklad od začátku do konce používá první prezentaci jako cílovou, normalizuje velikost snímku každého dalšího zdroje, udržuje každý zdroj otevřený jen během kopírování a uloží konečný soubor jednou.

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

$merged = new Presentation($inputFiles[0]);
try {
    $mergedWidth = java_values($merged->getSlideSize()->getSize()->getWidth());
    $mergedHeight = java_values($merged->getSlideSize()->getSize()->getHeight());

    for ($fileIndex = 1; $fileIndex < count($inputFiles); $fileIndex++) {
        $source = new Presentation($inputFiles[$fileIndex]);
        try {
            $sourceWidth = java_values($source->getSlideSize()->getSize()->getWidth());
            $sourceHeight = java_values($source->getSlideSize()->getSize()->getHeight());

            if ($sourceWidth != $mergedWidth || $sourceHeight != $mergedHeight) {
                $source->getSlideSize()->setSize($mergedWidth, $mergedHeight, SlideSizeScaleType::EnsureFit);
            }

            foreach ($source->getSlides() as $slide) {
                $merged->getSlides()->addClone($slide);
            }
        } finally {
            $source->dispose();
        }
    }

    $merged->save("merged.pptx", SaveFormat::Pptx);
} finally {
    $merged->dispose();
}
```

Jedná se o užitečný výchozí bod pro zachování formátování importovaných snímků. Pokud výstup musí používat jediné cílové téma, nahraďte jednoduché volání `addClone($slide)` vhodným přetížením pro cílový master nebo cílové rozvržení uvedeným výše.

## **Praktické úvahy**

### **Mastery, rozvržení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést požadovaný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr automaticky klonovaných masterů, aby nedocházelo k opakovanému klonování stejného masteru. Manuálně klonované mastery nejsou tímto registrem sledovány, proto se vyhněte předklonování masterů, pokud nepotřebujete explicitní kontrolu nad strukturou masteru.

Nepředpokládejte, že dva mastery nebo rozvržení se stejným názvem jsou vizuálně ekvivalentní. Pokud firemní šablona musí řídit konečný vzhled, vyberte explicitně cílový master nebo rozvržení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky řečníka a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou kopírovány při klonování snímku. Aspose.Slides také poskytuje vyhrazené API pro [presentation notes](https://docs.aspose.com/slides/cs/php-java/presentation-notes/) a [presentation comments](https://docs.aspose.com/slides/cs/php-java/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, ověřte sloučenou prezentaci, protože note master jsou objekty na úrovni prezentace a mohou se lišit mezi zdrojovými soubory. Pro revizní pracovní postupy také ověřte autory komentářů a vlákna komentářů po sloučení souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování jen jeho viditelných tvarů, aby Aspose.Slides mohl udržet vztahy snímku k těmto zdrojům.

Vložené a odkazované zdroje by měly být zpracovány odlišně. Odkazované audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepromění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevřena.

Aspose.Slides explicitně sleduje automaticky klonované mastery, ale to by nemělo být považováno za obecnou záruku, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je důležitá velikost výstupního souboru, zkontrolujte sloučený balíček a změřte výsledek místo spoléhaní se na implicitní deduplikaci.

### **Vložená písma a dostupnost písem**

Písma jsou spravována na úrovni prezentace. Pokud má typografie zůstat konzistentní napříč počítači, nepředpokládejte, že samotné klonování snímků zaručuje, že všechna potřebná písma jsou dostupná v cílovém prostředí. Vložená písma můžete zkontrolovat pomocí [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getembeddedfonts/) a spravovat vkládání explicitně, jak je popsáno v [Embed Fonts in Presentations](https://docs.aspose.com/slides/cs/php-java/embedded-font/).

Také ověřte, že máte povoleno vkládat písma použité ve zdrojových souborech. Licence písem mohou omezovat vkládání.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než lze jeho snímky klonovat. Heslo zadejte pomocí [LoadOptions::setPassword()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/setpassword/).

```php
require_once("Java.inc");
require_once("lib/aspose.slides.php");

use aspose\slides\LoadOptions;
use aspose\slides\Presentation;

$loadOptions = new LoadOptions();
$loadOptions->setPassword("YOUR_PASSWORD");

$source = new Presentation("protected.pptx", $loadOptions);
try {
    // Pracujte s dešifrovanou prezentací.
} finally {
    $source->dispose();
}
```

Otevření šifrovaného zdroje automaticky nepřenáší stejnou ochranu do cílové prezentace. Ochranu výstupu nastavte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značnou paměť. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) poskytuje ovládání pro správu BLOB a použití dočasných souborů. Viz [Open Presentations](https://docs.aspose.com/slides/cs/php-java/open-presentation/#open-large-presentations) pro příklad práce s velkými soubory v PHP přes Java.

U velkých souborů upřednostněte načítání z cest k souborům, pokud je to možné, uvolněte každou zdrojovou prezentaci hned po jejím sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud pracovní postup nevyžaduje kontrolní body.

### **Bezpečnost při vícevláknovém zpracování**

Nenačítěte, neupravujte, neukládejte ani nekloonujte instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) ve více vláknech. Tyto operace nejsou v PHP přes Java podporovány pro vícevláknové použití. Pokud potřebujete paralelní úlohy sloučení, spusťte je v samostatných jednovláknech procesech, přičemž každý proces používá vlastní instance prezentací, a řiďte se [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/cs/php-java/multithreading/).

## **FAQ**

**Jak mohu zachovat původní design každé zdrojové prezentace?**

Použijte [`addClone(sourceSlide)`](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) bez zadání cílového masteru nebo rozvržení. Aspose.Slides může automaticky klonovat zdrojový master, pokud jej importovaný snímek potřebuje.

**Jak zajistit, aby importované snímky používaly cílové téma?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k vhodnému rozvržení pod tímto masterem.

**Kdy použít konkrétní cílové rozvržení místo cílového masteru?**

Použijte konkrétní rozvržení, pokud má každý importovaný snímek používat jediné známé rozvržení. Použijte master, pokud chcete, aby Aspose.Slides vybíral mezi rozvrženími tohoto masteru na základě typu nebo názvu zdrojového rozvržení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku není automaticky přetvořen pro cílové rozměry. Před sloučením změňte velikost zdrojové prezentace, pokud potřebujete předvídatelné umístění, například pomocí [SlideSize::setSize()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/setsize/) a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejnou sadu funkcí, ověřte složitý obsah po sloučeních napříč formáty. Viz [Supported File Formats](https://docs.aspose.com/slides/cs/php-java/supported-file-formats/).

**Zachovají se zdrojové sekce automaticky?**

Ne, ne základní smyčkou, která klonuje jen snímky. Znovu vytvořte požadované sekce v cíli a použijte přetížení sekce metody [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), pokud je nutné zachovat strukturu sekcí.

**Zachovají se poznámky řečníka a komentáře?**

Jsou zkopírovány spolu s klonovaným snímkem. Pro pracovní postupy závislé na stylování note-masteru, autorech komentářů nebo vláknech recenzí ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni prezentace i obsahu snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenášen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být i po sloučení nadále dostupné.

**Jsou vložená písma ze všech zdrojů zaručena v sloučené prezentaci?**

Nespoléhejte se jen na klonování snímků pro nasazení písem. Zkontrolujte vložená písma v cíli a explicitně spravujte vkládání písem nebo dostupnost externích písem, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s správným [LoadOptions::setPassword()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/setpassword/), poté normálně klonujte jeho snímky. Ochrana výstupu je nastavena odděleně.

**Jak mám zacházet s velmi velkými prezentacemi?**

Používejte správu BLOB, když velké binární objekty dominují využití paměti, upřednostňujte načítání z cest k souborům u velmi velkých souborů, rychle uvolňujte zdrojové prezentace a finální výsledek ukládejte jen pokud je to potřeba.

**Mohu sloučit snímky z více vláken?**

Načítání, ukládání nebo klonování prezentací ve více vláknech není v PHP přes Java podporováno. Pro paralelní práci použijte samostatné jednovlákné procesy a udržujte instance prezentací izolované v každém procesu.