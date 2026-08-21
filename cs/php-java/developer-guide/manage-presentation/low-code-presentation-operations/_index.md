---
title: Nízkokódové operace prezentací v PHP
linktitle: Low-Code API
type: docs
weight: 50
url: /cs/php-java/low-code-presentation-operations/
keywords:
- low-code API prezentací
- převod prezentace
- sloučení prezentací
- iterace snímků
- iterace tvarů
- iterace textu
- shromažďování tvarů
- komprese prezentace
- odstranění nepoužitých master snímků
- odstranění nepoužitých rozvržení snímků
- komprese vložených fontů
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Použijte low-code API Aspose.Slides v PHP k převodu a sloučení prezentací, iteraci obsahu, shromažďování tvarů a snížení velikosti prezentace."
---
## **Přehled**

Namespace [aspose.slides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/) poskytuje statické pomocné třídy pro běžné operace s prezentacemi. Tyto pomocníky zabalí často používané workflow objektového modelu do zaměřených metod, takže můžete převádět nebo slučovat soubory, zpracovávat prvky prezentace, shromažďovat tvary a odstraňovat nepoužitý obsah s menším množstvím kódu.

Low-code pomocníci jsou nejvíce užiteční, když se operace vztahuje na celý soubor nebo prezentaci a výchozí workflow odpovídá vašim požadavkům. Použijte plný [Aspose.Slides object model](https://reference.aspose.com/slides/cs/php-java/aspose.slides/), když potřebujete jemnou kontrolu nad jednotlivými snímky, mistry, rozvrženími, tvary, nastavením exportu nebo vztahy mezi prvky prezentace.

The following table summarizes the available helpers:

| Pomocník | Použít pro |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/cs/php-java/aspose.slides/convert/) | Převod prezentace do jiného formátu pomocí přímého volání soubor na soubor. |
| [Merger](https://reference.aspose.com/slides/cs/php-java/aspose.slides/merger/) | Kombinování kompletních souborů prezentací ve stejném formátu. |
| [ForEach_](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/) | Spuštění zpětného volání pro každý snímek, tvar, odstavec nebo část textu. |
| [Collect](https://reference.aspose.com/slides/cs/php-java/aspose.slides/collect/) | Získání tvarů z celé prezentace pro opakované zpracování nebo analýzu. |
| [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/) | Odstranění nepoužitých masterů a rozvržení a snížení vložených dat fontů. |

## **Převod prezentace**

Použijte [Convert::autoByExtension](https://reference.aspose.com/slides/cs/php-java/aspose.slides/convert/#autoByExtension) když je přípona výstupního souboru dostačující k výběru formátu exportu. Metoda otevře zdrojovou prezentaci, určí požadovaný formát z cesty výstupu a zapíše výsledek.

```php
use aspose\slides\Convert;

Convert::autoByExtension("input.pptx", "output.pdf");
```

Třída [Convert](https://reference.aspose.com/slides/cs/php-java/aspose.slides/convert/) také poskytuje vyhrazené metody pro výstup PDF, SVG, JPEG, PNG a TIFF. Použijte plný objektový model, když potřebujete před exportem prezentaci prozkoumat nebo upravit nebo nakonfigurovat volbu exportu, která není nabízená vybraným pomocníkem. Viz [Převod prezentace](/php-java/convert-presentation/) pro workflow a možnosti specifické pro formát.

## **Sloučení prezentací**

Použijte [Merger::process](https://reference.aspose.com/slides/cs/php-java/aspose.slides/merger/#process) k sloučení kompletních souborů prezentací jedním voláním. Vstupní prezentace musí mít stejný formát souboru.

```php
use aspose\slides\Merger;

$inputFiles = ["part-1.pptx", "part-2.pptx"];
Merger::process($inputFiles, "merged.pptx");
```

Tento pomocník je vhodný, když mají být všechny snímky připojeny k jednomu výsledku bez individuálního výběru nebo přemapování. Použijte plný objektový model, když potřebujete sloučit vybrané snímky, použít cílový master nebo rozvržení, výslovně zachovat sekce nebo sladit různé velikosti snímků. Viz [Sloučení prezentací](/php-java/merge-presentation/) pro tyto scénáře.

## **Iterace přes prvky prezentace**

Třída [ForEach_](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/) volá zpětné volání pro každý požadovaný typ prvku prezentace. Vyhýbá se vnořeným smyčkám sběru a je praktická pro inspekci nebo změny formátování po celé prezentaci.

Následující příklad používá [ForEach_::slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#slide), [ForEach_::shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#paragraph) a [ForEach_::portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#portion) k inspekci odpovídajících prvků:

```php
use aspose\slides\ForEach_;
use aspose\slides\Presentation;

class SlideCallback {
    public function invoke($slide, $index): void {
        $slideIndex = java_values($index);
        $shapeCount = java_values($slide->getShapes()->size());
        echo sprintf("Slide %d: %d shapes", $slideIndex, $shapeCount) . PHP_EOL;
    }
}

class ShapeCallback {
    public function invoke($shape, $slide, $index): void {
        $shapeIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $shapeName = java_values($shape->getName());
        echo sprintf("Shape %d on %s: %s", $shapeIndex, $slideType, $shapeName) . PHP_EOL;
    }
}

class ParagraphCallback {
    public function invoke($paragraph, $slide, $index): void {
        $paragraphIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($paragraph->getText());
        echo sprintf("Paragraph %d on %s: %s", $paragraphIndex, $slideType, $text) . PHP_EOL;
    }
}

class PortionCallback {
    public function invoke($portion, $paragraph, $slide, $index): void {
        $portionIndex = java_values($index);
        $slideType = java_values($slide->getClass()->getSimpleName());
        $text = java_values($portion->getText());
        echo sprintf("Portion %d on %s: %s", $portionIndex, $slideType, $text) . PHP_EOL;
    }
}

$presentation = new Presentation("input.pptx");
try {
    $slideCallback = java_closure(new SlideCallback(), null, java('com.aspose.slides.ForEach_$ForEachSlideCallback'));
    $shapeCallback = java_closure(new ShapeCallback(), null, java('com.aspose.slides.ForEach_$ForEachShapeCallback'));
    $paragraphCallback = java_closure(new ParagraphCallback(), null, java('com.aspose.slides.ForEach_$ForEachParagraphCallback'));
    $portionCallback = java_closure(new PortionCallback(), null, java('com.aspose.slides.ForEach_$ForEachPortionCallback'));

    ForEach_::slide($presentation, $slideCallback);
    ForEach_::shape($presentation, $shapeCallback);
    ForEach_::paragraph($presentation, $paragraphCallback);
    ForEach_::portion($presentation, $portionCallback);
} finally {
    $presentation->dispose();
}
```

Ve výchozím nastavení zahrnuje procházení tvarů a textu po celé prezentaci normální, master a layout snímky. Přetížení s parametrem `includeNotes` mohou také zpracovávat snímky poznámek. Použijte přímé smyčky sběru, když je důležitý pořadí procházení, předčasný ukončení, filtrování před voláním zpětného volání nebo podrobná kontrola nad rodičovskými a podřízenými vztahy.

## **Sběr tvarů**

Použijte [Collect::shapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/collect/#shapes) když potřebujete kolekci všech tvarů v prezentaci místo zpětného volání pro každý tvar. To je užitečné, pokud bude stejná sada filtrována, počítána nebo zpracovávána vícekrát.

```php
use aspose\slides\Collect;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $shapes = Collect::shapes($presentation);

    foreach ($shapes as $shape) {
        $shapeName = java_values($shape->getName());
        $shapeType = java_values($shape->getClass()->getSimpleName());
        echo sprintf("%s: %s", $shapeName, $shapeType) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Použijte [ForEach_::shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#shape) místo toho, když může být každý tvar zpracován okamžitě a nepotřebujete uchovat shromážděný výsledek.

## **Komprese obsahu prezentace**

Třída [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/) může odstranit nepoužité strukturační prvky a snížit vložená data fontů:

- [Compress::removeUnusedLayoutSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedLayoutSlides) odstraňuje rozvržení snímků, na které neodkazuje žádný normální snímek.
- [Compress::removeUnusedMasterSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#removeUnusedMasterSlides) odstraňuje master snímky, které už nejsou používány.
- [Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#compressEmbeddedFonts) odstraňuje nepoužité znaky z vložených fontů.

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    Compress::removeUnusedLayoutSlides($presentation);
    Compress::removeUnusedMasterSlides($presentation);
    Compress::compressEmbeddedFonts($presentation);

    $presentation->save("compressed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Odstraňte nepoužitá rozvržení před nepoužitými mastery, aby master, který se po vyčištění rozvržení stane neodkazovaným, mohl být také odstraněn. Uložte optimalizovanou prezentaci do nového souboru, pokud později budete potřebovat původní mastery, rozvržení nebo kompletní vložená data fontů. Pro více podrobností viz [Slide Master](/php-java/slide-master/) a [Embedded Font](/php-java/embedded-font/).

## **Často kladené otázky**

**Kdy mám použít low-code API místo plného objektového modelu?**

Používejte low-code pomocníky, když se standardní operace vztahuje na celý soubor nebo prezentaci a nevyžaduje detailní kontrolu nad jednotlivými prvky. Použijte plný objektový model, když potřebujete vybrat konkrétní snímky, řídit vztahy mezi master a layout, prozkoumat mezistav, nebo nakonfigurovat chování, které pomocník neexponuje.

**Může Merger kombinovat prezentace v různých formátech souborů?**

Ne. [Merger::process](https://reference.aspose.com/slides/cs/php-java/aspose.slides/merger/#process) vyžaduje vstupní prezentace ve stejném formátu. Převeďte vstupní soubory nejprve na společný formát, například pomocí [Convert::autoByExtension](https://reference.aspose.com/slides/cs/php-java/aspose.slides/convert/#autoByExtension), a poté sloučte převedené soubory.

**Zpracovává ForEach_ master, layout a poznámkové snímky?**

[ForEach_::slide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#slide) iteruje přes běžné snímky prezentace. Operace [ForEach_::shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#shape), [ForEach_::paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#paragraph) a [ForEach_::portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#portion) zahrnují ve výchozím nastavení normální, master a layout snímky. Použijte jejich přetížení s parametrem `includeNotes` nastaveným na `true`, aby byly zahrnuty i snímky poznámek.

**Jaký je rozdíl mezi ForEach_::shape a Collect::shapes?**

Použijte [ForEach_::shape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/#shape), pokud chcete každý tvar zpracovat okamžitě pomocí zpětného volání. Použijte [Collect::shapes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/collect/#shapes), když potřebujete iterovatelný výsledek, který můžete uchovat, filtrovat, počítat nebo procházet vícekrát.

**Zmenšuje Compress vždy velikost souboru prezentace?**

Ne nutně. Výsledek závisí na tom, zda prezentace obsahuje nepoužitá rozvržení, nepoužité mastery nebo vložené fonty s nepoužitými znaky. Pokud žádné z těchto položek nejsou, odpovídající operace [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/) nemusí snížit velikost souboru.

**Ukládají se změny provedené pomocí ForEach_ nebo Compress automaticky?**

Ne. Tito pomocníci pracují s načteným objektem [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/) v paměti. Po změně prvků v callbacku [ForEach_](https://reference.aspose.com/slides/cs/php-java/aspose.slides/foreach_/), nebo po spuštění [Compress](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/), zavolejte [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save), abyste výsledek zapsali.

## **Související články**

- [Převod prezentace](/php-java/convert-presentation/)
- [Sloučení prezentací](/php-java/merge-presentation/)
- [Slide Master](/php-java/slide-master/)
- [Správa textového pole](/php-java/manage-textbox/)
- [Vložený font](/php-java/embedded-font/)