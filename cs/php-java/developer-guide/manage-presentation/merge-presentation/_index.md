---
title: Efektivní sloučení prezentací v PHP
linktitle: Sloučení prezentací
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
description: "Zjistěte, jak v PHP sloučit PowerPoint a OpenDocument prezentace pomocí klonování snímků, řízení masterů a rozložení, změny velikosti obsahu snímků, zachování sekcí a zpracování chráněných nebo velkých souborů."
---
## **Přehled**

Aspose.Slides pro PHP přes Java sloučuje prezentace klonováním snímků z jedné [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) do druhé. Hlavní operací je [SlideCollection::addClone()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), která může zachovat formátování zdrojového snímku nebo připojit klonovaný snímek k masteru či rozložení v cílové prezentaci.

Tento článek pokrývá nejčastější pracovní postupy sloučení:

- sloučit všechny snímky a zachovat jejich zdrojové formátování;
- sloučit vybrané snímky;
- použít master z cílové prezentace;
- použít konkrétní rozložení z cílové prezentace;
- normalizovat různé velikosti snímků před sloučením;
- přidat klonované snímky do sekce;
- sloučit několik prezentací v jednom kompletním pracovním postupu;
- zpracovat mastery, zdroje, poznámky, komentáře, média, fonty, hesla, velké soubory a problémy s vícevláknovým zpracováním.

## **Jak klonování snímků ovlivňuje mastery a rozložení**

Snímek dědí velkou část svého vzhledu od svého rozložení a masteru. Z tohoto důvodu vybraná přetížení klonování určuje, jak bude sloučený snímek integrován do cílové prezentace.

Použijte [SlideCollection::addClone()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) jedním z následujících způsobů:

- `addClone(sourceSlide)` — zachovat rozložení a formátování zdrojového snímku. V případě potřeby může být zdrojový master automaticky naklonován do cílové prezentace. Aspose.Slides automaticky sledovaně klonované mastery tak, aby se opakovaně neklonovaly stejné mastery.
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — připojit klonovaný snímek k určitému cílovému [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/). Aspose.Slides vyhledá odpovídající rozložení pod tímto masterem podle typu nebo názvu rozložení.
- `addClone(sourceSlide, destinationLayout)` — připojit klonovaný snímek přímo k určitému cílovému [LayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/).

Master nebo rozložení předané přetížení `addClone` musí patřit **cílové** prezentaci, nikoli zdrojové prezentaci.

## **Sloučit celé prezentace a zachovat formátování zdroje**

Nejjednodušší sloučení zkopíruje každý snímek ze zdrojové prezentace do cílové prezentace. Toto je vhodná volba, když mají importované snímky zachovat své původní téma, master a vztahy rozložení.

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

Výsledná prezentace může obsahovat více masterů, pokud zdroj a cíl používají odlišné designy. To je očekávané, když je záměrně zachováno formátování zdroje.

## **Sloučit vybrané snímky**

Nemusíte klonovat každý snímek. Následující příklad importuje jen vybrané indexy snímků ze zdrojové prezentace.

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

Ověřte indexy snímků před klonováním, pokud pocházejí od uživatele nebo z externí konfigurace.

## **Sloučit snímky pomocí cílového masteru**

Použijte přetížení [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), když mají importované snímky následovat master, který již patří do cílové prezentace.

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

Aspose.Slides vybere vhodné rozložení pod zadaným masterem porovnáním typu nebo názvu rozložení ze zdrojového snímku. Pokud neexistuje vhodné rozložení a `allowCloneMissingLayout` je `true`, zdrojové rozložení se naklonuje, aby mohl být snímek přidán. Pokud je `false`, je vyvolána [PptxEditException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxeditexception/).

Použijte `false`, když chcete, aby sloučení selhalo místo toho, aby se do cílového masteru zavádělo další rozložení.

## **Sloučit snímky pomocí konkrétního cílového rozložení**

Použijte přetížení [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), když přesně víte, které cílové rozložení mají importované snímky použít.

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

Použití cílového rozložení mění zděděný vztah rozložení; ne redesignuje obsah zdrojového snímku. Pokud mají zdrojové a cílové rozložení odlišné struktury placeholderů, zkontrolujte výsledek, aby bylo jisté, že zděděné formátování a chování placeholderů jsou vhodné.

## **Sloučit prezentace s různými velikostmi snímků**

Prezentace s různými rozměry snímků mohou být sloučeny, ale klonování snímku do prezentace s jinou velikostí automaticky neredesinuje jeho obsah na novém plátně. Tvary se tak mohou jevit jako posunuté, nečekaně škálované nebo mimo viditelnou oblast snímku.

Praktický postup je změnit velikost zdrojové prezentace před klonováním. Metoda [SlideSize::setSize()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/setsize/) může měřítkově upravit existující obsah při změně rozměrů snímku. [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesizescaletype/) škáluje obsah tak, aby se vešel do požadované velikosti.

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

Změna velikosti mění objekt zdrojové prezentace v paměti. Pokud potřebujete původní zdrojovou prezentaci neporušenou pro další operace, otevřete pro sloučení samostatnou instanci.

## **Sloučit snímky do sekce prezentace**

Základní smyčka klonování snímků neobnovuje hierarchii sekcí zdrojové prezentace. Pokud jsou sekce důležité ve výstupu, vytvořte nebo vyberte sekce v cílové prezentaci a explicitně do nich klonujte snímky pomocí [addClone(Slide, Section)](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/).

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

Klonované snímky jsou připojeny k určené cílové sekci. Pro zachování několika zdrojových sekcí projděte [Presentation::getSections](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Presentation/#getSections), získejte aktuální snímky každé zdrojové sekce pomocí [Section::getSlidesListOfSection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/Section/#getSlidesListOfSection), znovu vytvořte sekce v cíli a klonujte každý vrácený snímek do odpovídající cílové sekce. Viz [Manage Slide Sections](/slides/cs/php-java/slide-section/) pro kompletní příklad enumerace sekcí, včetně prázdných sekcí a strukturálních změn.

## **Bezpečné sloučení více prezentací**

Následující end‑to‑end příklad používá první prezentaci jako cíl, normalizuje velikost snímku každého dalšího zdroje, udržuje každý zdroj otevřený jen po dobu kopírování a ukládá finální soubor jednou.

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

Toto je užitečná výchozí hodnota pro zachování formátování importovaných snímků. Pokud výstup musí používat jednotné téma cíle, nahraďte jednoduché volání `addClone($slide)` příslušným přetížením masteru nebo rozložení, jak bylo ukázáno dříve.

## **Praktické úvahy**

### **Mastery, rozložení a věrnost formátování**

Výchozí klonování snímků může automaticky přenést potřebný zdrojový master do cílové prezentace. Aspose.Slides udržuje interní registr pro automaticky klonované mastery, aby nedošlo k opakovanému klonování stejného masteru. Manuálně klonované mastery nejsou tímto registretem sledovány, takže se vyhněte předběžnému klonování masterů, pokud nepřejete explicitní kontrolu nad strukturou masteru.

Nepředpokládejte, že dva mastery nebo rozložení se stejným názvem jsou vizuálně ekvivalentní. Pokud firemní šablona musí řídit finální vzhled, vyberte explicitně cílový master nebo rozložení a po sloučení výsledek ověřte.

### **Poznámky a komentáře**

Poznámky přednášejícího a komentáře ke snímkům jsou spojeny s obsahem snímku a jsou při klonování zkopírovány. Aspose.Slides také poskytuje dedikované API pro [presentation notes](/slides/cs/php-java/presentation-notes/) a [presentation comments](/slides/cs/php-java/presentation-comments/).

Pokud je důležité formátování stránky s poznámkami, ověřte sloučenou prezentaci, protože mastery pro poznámky jsou objekty na úrovni celé prezentace a mohou se mezi zdrojovými soubory lišit. Pro recenzní workflow ověřte také autory komentářů a vlákna komentářů po kombinaci souborů od různých autorů nebo šablon.

### **Obrázky, audio, video, OLE objekty a externí odkazy**

Snímky mohou odkazovat na zdroje na úrovni prezentace, jako jsou obrázky, vložené audio, vložené video a OLE data. Klonujte samotný snímek místo kopírování jen jeho viditelných tvarů, aby Aspose.Slides mohlo udržet vztahy snímku k těmto zdrojům.

Vložené a odkazované zdroje je třeba zacházet odlišně. Odkazovaný audio, video, OLE objekt nebo hypertextový odkaz zůstává závislý na externím cíli; klonování snímku nepromění externí odkaz na vložený obsah. Otestujte cesty a URL odkazovaných zdrojů v prostředí, kde bude sloučená prezentace otevírána.

Aspose.Slides výslovně sleduje automaticky klonované mastery, ale to neznamená, že identické binární zdroje z nesouvisejících zdrojových prezentací budou vždy deduplikovány. Pokud je důležitá velikost výstupního souboru, prohlédněte sloučený balíček a změřte výsledek místo spoléhání se na implicitní deduplikaci.

### **Vložené fonty a dostupnost fontů**

Fonty jsou spravovány na úrovni prezentace. Pokud musí typografie zůstat konzistentní mezi stroji, nepředpokládejte, že klonování snímků samotných zaručí, že každý požadovaný font bude dostupný v cílovém prostředí. Vložené fonty můžete zkontrolovat pomocí [FontsManager::getEmbeddedFonts()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getembeddedfonts/) a spravovat jejich vložení explicitně, jak je popsáno v [Embed Fonts in Presentations](/slides/cs/php-java/embedded-font/).

Také ověřte, že máte oprávnění vložit fonty použité ve zdrojových souborech. Licenční podmínky fontů mohou omezovat vkládání.

### **Prezentace chráněné heslem**

Zdroj chráněný heslem musí být úspěšně otevřen, než mohou být jeho snímky klonovány. Heslo se předává pomocí [LoadOptions::setPassword()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/setpassword/).

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

Otevření šifrovaného zdroje automaticky nepřenáší stejnou ochranu na cílovou prezentaci. Ochranu výstupu nastavte samostatně, pokud je potřeba.

### **Velké prezentace a využití paměti**

Velké prezentace obsahující vysoce rozlišené obrázky, audio, video nebo jiné velké binární objekty mohou spotřebovat značnou paměť. [LoadOptions::getBlobManagementOptions()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/getblobmanagementoptions/) poskytuje ovládání BLOBů a dočasných souborů. Viz [Open Presentations](/slides/cs/php-java/open-presentation/#open-large-presentations) pro příklad velkých souborů v PHP přes Java.

U velkých souborů raději načítejte z cest k souborům, co nejdříve uvolněte každou zdrojovou prezentaci po jejím sloučení a vyhněte se opakovanému ukládání mezivýsledků, pokud workflow nevyžaduje kontrolní body.

### **Bezpečnost vláken**

Nenačítejte, neupravujte, neukládejte ani neklonujte instance [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) ve více vláknech. Tyto operace nejsou podporovány pro vícevláknové použití v PHP přes Java. Pokud potřebujete paralelní úlohy sloučení, spusťte je v oddělených jednovláknových procesech, přičemž každý proces používá vlastní instance prezentací, a řiďte se [Aspose.Slides multithreading guidance](/slides/cs/php-java/multithreading/).

## **Často kladené otázky**

**Jak zachovat původní design každé zdrojové prezentace?**

Použijte [SlideCollection::addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/) bez zadání cílového masteru či rozložení. Aspose.Slides může automaticky klonovat zdrojový master, pokud jej importovaný snímek potřebuje.

**Jak zajistit, aby importované snímky používaly téma cíle?**

Použijte přetížení, které přijímá cílový master. Předávejte master z cílové prezentace, ne ze zdrojové. Aspose.Slides se pokusí přiřadit každý zdrojový snímek k vhodnému rozložení pod tímto masterem.

**Kdy použít konkrétní cílové rozložení místo cílového masteru?**

Použijte konkrétní rozložení, když mají všechny importované snímky využívat jedno známo rozložení. Použijte master, když chcete, aby Aspose.Slides vybralo mezi rozloženími toho masteru na základě typu nebo názvu zdrojového rozložení.

**Lze sloučit prezentace s různými velikostmi snímků?**

Ano, ale obsah snímku se automaticky neredesinuje na nové rozměry. Nejprve změňte velikost zdrojové prezentace, pokud potřebujete předvídatelné umístění, například pomocí [SlideSize::setSize()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesize/setsize/) a [SlideSizeScaleType::EnsureFit](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidesizescaletype/).

**Mohu sloučit PPT, PPTX a ODP prezentace do jednoho souboru?**

Ano. Načtěte každou zdrojovou prezentaci, klonujte požadované snímky do jedné cílové a uložte cíl v podporovaném výstupním formátu. Protože formáty prezentací nepodporují přesně stejnou sadu funkcí, po cross‑format sloučení ověřte složitý obsah. Viz [Supported File Formats](/slides/cs/php-java/supported-file-formats/).

**Jsou zdrojové sekce automaticky zachovány?**

Ne, při základní smyčce, která jen klonuje snímky. Vytvořte požadované sekce v cíli a použijte sekční přetížení [addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/addclone/), pokud musí být struktura sekcí zachována.

**Jsou poznámky přednášejícího a komentáře zachovány?**

Ano, jsou zkopírovány s klonovaným snímkem. Pro workflow závislé na stylování masteru pro poznámky, autorech komentářů nebo vláknových recenzích ověřte sloučený výsledek, protože tyto scénáře zahrnují struktury na úrovni prezentace i snímku.

**Co se stane s audiem, videem, OLE objekty a hypertextovými odkazy?**

Vložený obsah je přenesen jako součást vztahů zdrojů klonovaného snímku. Externí odkazy zůstávají externí, takže jejich cílové soubory nebo URL musí být po sloučení stále dostupné.

**Jsou vložené fonty ze všech zdrojů garantovány v sloučené prezentaci?**

Nespoléhejte se pouze na klonování snímků pro nasazení fontů. Prohlédněte vložené fonty v cíli a explicitně spravujte jejich vložení nebo externí dostupnost, pokud je typografie důležitá.

**Jak sloučit soubor chráněný heslem?**

Otevřete jej s použitím správného [LoadOptions::setPassword()](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/setpassword/), pak normálně klonujte jeho snímky. Ochrana výstupu se nastavuje samostatně.

**Jak postupovat u velmi velkých prezentací?**

Použijte správu BLOB, pokud velké binární objekty dominují paměťovému využití, upřednostněte načítání z cest k souborům, rychle uvolněte zdrojové prezentace po jejich sloučení a finální výsledek uložte jen jednou, když je potřeba.

**Mohu sloučit snímky z více vláken?**

Načítání, ukládání nebo klonování prezentací ve více vláknech není podporováno v PHP přes Java. Pro paralelní práci použijte samostatné jednovláknové procesy a v každém procesu izolujte instance prezentací.