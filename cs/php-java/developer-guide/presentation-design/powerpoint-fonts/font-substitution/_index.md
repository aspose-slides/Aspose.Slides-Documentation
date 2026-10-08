---
title: Konfigurace náhrady písma v prezentacích pomocí PHP
linktitle: Náhrada písma
type: docs
weight: 70
url: /cs/php-java/font-substitution/
keywords:
- písmo
- náhradní písmo
- náhrada písma
- nahrazení písma
- nahrazení písma
- pravidlo náhrady
- pravidlo nahrazení
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Konfigurujte pravidla náhrady písma a kontrolujte nahrazená písma v Aspose.Slides pro PHP prostřednictvím Java při vykreslování nebo převodu prezentací PowerPoint a OpenDocument."
---
## **Přehled**

Náhrada písma umožňuje Aspose.Slides použít dostupné písmo místo písma, ke kterému nelze přistupovat při vykreslování nebo převodu prezentace. Náhrada ovlivňuje vykreslený výstup; nemění písmo přiřazené k obsahu prezentace.

Můžete definovat písmo, které se použije, když je konkrétní písmo nedostupné, a můžete zkontrolovat náhrady, které Aspose.Slides během vykreslování provede. To pomáhá udržet výstup konzistentní napříč prostředími s různými nainstalovanými písmy.

If a font is available but has no dedicated bold typeface, see [Zpracování písem bez dedikovaného tučného řezu](/slides/cs/php-java/convert-powerpoint-to-pdf/#handle-fonts-without-a-dedicated-bold-typeface). Tato sekce vysvětluje, jak rastrování ovlivněného textu během exportu do PDF a důsledky pro výběr textu, vyhledávání a škálování.

## **Získání náhrad písem**

Použijte metodu [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) abyste určili, která písma budou při vykreslení prezentace nahrazena. Metoda vrací objekty [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/), které identifikují původní a nahrazené názvy písem.

Následující PHP příklad vypisuje všechny náhrady písem pro prezentaci:

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

## **Získání náhrad písem pro vybrané snímky**

Použijte přetížení [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) s argumentem `int[] slides`, abyste prozkoumali pouze náhrady potřebné k vykreslení konkrétních snímků. To je užitečné, když vykreslujete nebo exportujete část prezentace, provádíte postupnou kontrolu velké prezentace, vyhledáváte snímky závislé na nedostupných písmách, připravujete minimální balíček písem pro server nebo kontejner, nebo diagnostikujete rozdíly ve vykreslování, aniž byste zpracovávali nesouvisející snímky.

`slides` pole obsahuje jednorozměrné indexy snímků od jedné: `1` označuje první snímek. Na rozdíl od toho, přístup k sbírce pomocí [Presentation::getSlides](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getslides/) používá indexování od nuly, takže stejný snímek je přístupný jako `$presentation->getSlides()->get_Item(0)`. Pamatujte na tento rozdíl při tvorbě pole, aby nedocházelo k chybám o jeden.

Zavolejte přetížení přes metodu [Presentation::getFontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getfontsmanager/). Vrací pouze náhrady určené během vykreslování vybraných snímků. Každý výsledek je objekt [FontSubstitutionInfo](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstitutioninfo/), který obsahuje původní a nahrazené názvy písem. Výsledek odráží aktuální prostředí písem, nakonfigurovaná pravidla záložních písem, pravidla náhrady uložená v [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/), a [externě načtená písma](/slides/cs/php-java/custom-font/).

Stejná náhrada může být vyžadována více než jedním vybraným snímkem. Odstraňte duplicitní výsledky, když vytváříte inventuru písem nebo preflight report. Následující příklad vypisuje každou vrácenou náhradu a poté vytváří seřazený seznam unikátních mapování písem:

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

Třída [FontsManager](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/) poskytuje obě přetížení. Vyberte si podle rozsahu vykreslovací operace:

| Přetížení | Použijte, když |
|---|---|
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with no arguments | Potřebujete náhrady pro celou prezentaci. |
| [getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/) with `int[] slides` | Potřebujete náhrady pro vybraný rozsah, postupnou kontrolu nebo částečný export. |

## **Nastavení pravidel náhrady písem**

Chcete-li specifikovat písmo, které má Aspose.Slides použít, když je zdrojové písmo nedostupné:

1. Načtěte prezentaci.
2. Vytvořte definice písem pro zdrojové a náhradní písmo.
3. Vytvořte [FontSubstRule](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrule/) s podmínkou [WhenInaccessible](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstcondition/).
4. Přidejte pravidlo do [FontSubstRuleCollection](https://reference.aspose.com/slides/php-java/aspose.slides/fontsubstrulecollection/).
5. Přiřaďte kolekci pomocí metody [FontsManager::setFontSubstRuleList](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/setfontsubstrulelist/).
6. Vykreslete nebo převedete prezentaci.

Následující PHP příklad nahrazuje `Arial` za `SomeRareFont`, když je `SomeRareFont` nedostupné, a poté vykresluje první snímek k ověření výsledku. Náhradní písmo musí být dostupné pro Aspose.Slides.

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
Pro neomezenou změnu písem používaných v celé prezentaci, viz [Nahrazení písem](/slides/cs/php-java/font-replacement/).
{{% /alert %}}

## **Omezení pro písma matematických rovnic**

Pravidla náhrady písem jsou součástí standardního procesu výběru písem používaného během vykreslování a převodu. Fungují pro běžný text, když Aspose.Slides může nahradit nedostupné písmo dostupným písmem specifikovaným pravidlem.

Rovnice Office Math mají další požadavek. Pokud rovnice používá **Cambria Math**, Aspose.Slides může potřebovat právě toto písmo k výpočtu a vykreslení rozložení rovnice. Pravidlo, které nahrazuje jiné matematické písmo, například **STIX Two Math**, nemůže nahradit **Cambria Math** pro tento účel, a vykreslování může stále hlásit, že **Cambria Math** je požadováno.

Pro vykreslení nebo převod takové prezentace zajistěte, aby bylo **Cambria Math** dostupné pro Aspose.Slides. Nainstalujte jej v operačním systému nebo jej načtěte jako [externí písmo](/slides/cs/php-java/custom-font/).

Toto omezení se vztahuje na rozložení rovnic. Pravidla náhrady popsaná výše stále platí pro běžný text prezentace.

## **Často kladené dotazy**

**Jaký je rozdíl mezi nahrazením písem a náhradou písem?**

[Nahrazení písem](/slides/cs/php-java/font-replacement/) úmyslně mění jedno písmo na jiné v celé prezentaci. Náhrada písem vybírá písmo pro vykreslený výstup, když je splněna nakonfigurovaná podmínka, například když je původní písmo nedostupné.

**Kdy se pravidla náhrady používají?**

Pravidla se podílejí na [sekvenci výběru písma](/slides/cs/php-java/font-selection-sequence/) během vykreslování a převodu. S `WhenInaccessible` se pravidlo používá pouze tehdy, když Aspose.Slides nemůže získat přístup ke zdrojovému písmu.

**Co se stane, když písmo chybí a není nakonfigurováno žádné pravidlo náhrady?**

Aspose.Slides vybere nejbližší dostupné písmo podle svého procesu výběru písem. Výsledek závisí na písmenech dostupných v runtime prostředí.

**Mohu načíst externí písma, aby se předešlo náhradě?**

Ano. Můžete [načíst externí písma](/slides/cs/php-java/custom-font/), aby je Aspose.Slides mohl použít během vykreslování a převodu.

**Distribuuje Aspose písma s knihovnou?**

Ne. Vy jste zodpovědní za poskytování písem a za dodržování jejich licencí.

**Mohou se výsledky náhrady lišit mezi Windows, Linux a macOS?**

Ano. Instalovaná písma a místa vyhledávání písem se liší podle operačního systému, takže písmo dostupné na jednom počítači může vyžadovat náhradu na jiném.

**Jak mohu zajistit konzistentní výběr písem při dávkových konverzích?**

Používejte stejné soubory písem a verze na každém počítači nebo kontejneru, [načtěte požadovaná externí písma](/slides/cs/php-java/custom-font/) a [vložená písma](/slides/cs/php-java/embedded-font/) pokud licence umožňuje. Můžete také před exportem zavolat [FontsManager::getSubstitutions](https://reference.aspose.com/slides/php-java/aspose.slides/fontsmanager/getsubstitutions/), abyste identifikovali neočekávané náhrady.