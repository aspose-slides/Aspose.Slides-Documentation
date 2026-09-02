---
title: Konfigurace substituce písem v prezentacích pomocí PHP
linktitle: Substituce písem
type: docs
weight: 70
url: /cs/php-java/font-substitution/
keywords:
- písmo
- nahrazení písma
- substituce písma
- nahrazení písma
- náhrada písma
- pravidlo substituce
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Konfigurujte pravidla substituce písem a prohlédněte substituovaná písma v Aspose.Slides pro PHP prostřednictvím Javy při vykreslování nebo konverzi prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Substituce písem umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze získat přístup při vykreslování nebo konverzi prezentace. Substituce se týká vykresleného výstupu; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se má použít, když je konkrétní písmo nedostupné, a můžete si prohlédnout substituce, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různě nainstalovanými písmy.

## **Získání substitucí písem**

Pomocí metody [FontsManager::getSubstitutions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getsubstitutions/) určete, která písma budou substituována při vykreslování prezentace. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstitutioninfo/), které identifikují původní a substituované názvy písem.

Následující PHP příklad vypíše všechny substituce písem pro prezentaci:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $enumerator = $presentation->getFontsManager()->getSubstitutions()->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitution = $enumerator->next();
            $originalFontName = java_values($substitution->getOriginalFontName());
            $substitutedFontName = java_values($substitution->getSubstitutedFontName());
            echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
        }
    } finally {
        $enumerator->dispose();
    }
} finally {
    $presentation->dispose();
}
```

## **Získání substitucí písem pro vybrané snímky**

Pomocí přetížení [FontsManager::getSubstitutions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getsubstitutions/) s argumentem `int[] slides` můžete prozkoumat pouze substituce potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, kontrolujete velkou prezentaci inkrementálně, hledáte snímky závislé na nedostupných písmách, připravujete minimální balík písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování bez zpracování nesouvisejících snímků.

Pole `slides` obsahuje jednorozměrné indexy snímků začínající od jedné: `1` označuje první snímek. Naopak přístupník kolekce [Presentation::getSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getSlides) používá nulové indexování, takže stejný snímek je přístupný jako `$presentation->getSlides()->get_Item(0)`. Mějte tento rozdíl na paměti při tvorbě pole, aby nedošlo k chybě o jeden.

Volání přetížení provádějte přes metodu [Presentation::getFontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getFontsManager). Vrací pouze substituce určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstitutioninfo/), který obsahuje původní a substituované názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla záložních písem, pravidla substituce uložená v [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstrulecollection/) a [externě načtená písma](/slides/cs/php-java/custom-font/).

Stejná substituce může být vyžadována více než jedním vybraným snímkem. Při tvorbě inventáře písem nebo preflight zprávy deduplikujte výsledky. Následující příklad vypíše každou vrácenou substituci a poté vytvoří seřazený seznam unikátních mapování písem:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("Presentation.pptx");
try {
    $selectedSlides = [1, 3, 5];
    $substitutions = [];
    $enumerator = $presentation->getFontsManager()->getSubstitutions($selectedSlides)->iterator();
    try {
        while (java_values($enumerator->hasNext())) {
            $substitutions[] = $enumerator->next();
        }
    } finally {
        $enumerator->dispose();
    }

    echo "Substitutions for the selected slides:" . PHP_EOL;
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        echo $originalFontName . " -> " . $substitutedFontName . PHP_EOL;
    }

    $sortedPreflightEntries = [];
    foreach ($substitutions as $substitution) {
        $originalFontName = java_values($substitution->getOriginalFontName());
        $substitutedFontName = java_values($substitution->getSubstitutedFontName());
        $entry = $originalFontName . " -> " . $substitutedFontName;
        $sortedPreflightEntries[strtolower($entry)] = $entry;
    }
    ksort($sortedPreflightEntries, SORT_NATURAL | SORT_FLAG_CASE);

    echo "Deduplicated font preflight report:" . PHP_EOL;
    foreach ($sortedPreflightEntries as $entry) {
        echo $entry . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Třída [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/) poskytuje obě přetížení. Vyberte si to podle rozsahu operace vykreslování:

| Přetížení | Použít, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getsubstitutions/) bez argumentů | Potřebujete substituce pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getsubstitutions/) s `int[] slides` | Potřebujete substituce pro vybraný rozsah, inkrementální kontrolu nebo částečný export. |

## **Nastavení pravidel substituce písem**

Pro specifikaci písma, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.  
2. Vytvořte definice písem pro zdrojové a substituční písmo.  
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstcondition/).  
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsubstrulecollection/).  
5. Přiřaďte kolekci pomocí metody [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).  
6. Vykreslete nebo konvertujte prezentaci.

Následující PHP příklad substituuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykreslí první snímek k ověření výsledku. Substituční písmo musí být dostupné pro Aspose.Slides.

```php
use aspose\slides\FontData;
use aspose\slides\FontSubstCondition;
use aspose\slides\FontSubstRule;
use aspose\slides\FontSubstRuleCollection;
use aspose\slides\ImageFormat;
use aspose\slides\Presentation;

$presentation = new Presentation("Fonts.pptx");
try {
    $sourceFont = new FontData("SomeRareFont");
    $substituteFont = new FontData("Arial");
    $substitutionRule = new FontSubstRule($sourceFont, $substituteFont, FontSubstCondition::WhenInaccessible);

    $substitutionRules = new FontSubstRuleCollection();
    $substitutionRules->add($substitutionRule);
    $presentation->getFontsManager()->setFontSubstRuleList($substitutionRules);

    $image = $presentation->getSlides()->get_Item(0)->getImage(1.0, 1.0);
    try {
        $image->save("slide.jpg", ImageFormat::Jpeg);
    } finally {
        $image->dispose();
    }
} finally {
    $presentation->dispose();
}
```

{{% alert color="info" title="Note" %}}
Pro neomezenou změnu písem použité po celé prezentaci viz [Font Replacement](/slides/cs/php-java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla substituce písem jsou součástí standardního výběrového procesu písem používaného během vykreslování a konverze. Fungují pro běžný text, když Aspose.Slides dokáže nahradit nedostupné písmo dostupným písmem definovaným pravidlem.

Matematické rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozvržení rovnice. Pravidlo, které substituuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel a vykreslování může nadále hlásit, že **Cambria Math** je vyžadováno.

Pro vykreslení nebo konverzi takové prezentace zajistěte, aby byl **Cambria Math** dostupný pro Aspose.Slides. Nainstalujte jej v operačním systému nebo načtěte jako [externí písmo](/slides/cs/php-java/custom-font/).

Toto omezení se vztahuje na rozvržení rovnic. Pravidla substituce popsaná výše stále platí pro běžný text prezentace.

## **Často kladené otázky**

**Jaký je rozdíl mezi náhradou písma a substitucí písma?**

[Font replacement](/slides/cs/php-java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Substituce písma vybere písmo pro vykreslený výstup, když je splněna konfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla substituce aplikují?**

Pravidla se podílejí na [font selection sequence](/slides/cs/php-java/font-selection-sequence/) během vykreslování a konverze. S `WhenInaccessible` se pravidlo použije jen tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo substituce?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na pímech dostupných v runtime prostředí.

**Mohu načíst externí písma, aby se zabránilo substituci?**

Ano. Můžete [load external fonts](/slides/cs/php-java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a konverze.

**Distribuuje Aspose písma s knihovnou?**

Ne. Za poskytování písem a dodržování jejich licencí jste odpovědní vy.

**Mohou se výsledky substituce lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a umístění prohledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat substituci na jiném.

**Jak zajistit konzistentní výběr písma při dávkových konverzích?**

Používejte stejné soubory písem a verze na každém stroji nebo kontejneru, [load required external fonts](/slides/cs/php-java/custom-font/), a [embed fonts](/slides/cs/php-java/embedded-font/), pokud licence dovolí. Můžete také před exportem zavolat [FontsManager::getSubstitutions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/getsubstitutions/) k identifikaci neočekávaných substitucí.