---
title: Správa skriptově specifických písem motivu v PHP
linktitle: Skriptově specifická písma motivu
type: docs
weight: 15
url: /cs/php-java/script-specific-font-mappings/
keywords:
- skriptově specifické písmo
- mapování písma motivu
- vícejazyčná prezentace
- psací systém
- cyrilické písmo
- arabské písmo
- japonské písmo
- gruzínské písmo
- thaana písmo
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Prozkoumejte, přidejte, nahraďte a odstraňte skriptově specifická mapování písem v motivu PowerPointu pomocí Aspose.Slides pro PHP přes Java."
---
## **Přehled**

Prezentace může vybrat různé rodiny písem pro různé psací systémy. To umožňuje multimultikulturní text, který i nadále používá písma motivu, aby sledoval jednotné schéma písem a zároveň využíval vhodná písma pro cyrilici, arabštinu, japonštinu, gruzínštinu, thaana a další skripty.

Motivová [FontScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/) obsahuje hlavní sbírku písem, typicky používanou pro nadpisy, a vedlejší sbírku písem, typicky používanou pro tělo textu. Kromě jejich latinských a východoasijských nastavení písem obě sbírky [Fonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/) vystavují mapování z tagů psacích systémů na názvy rodin písem.

Tento článek ukazuje, jak prozkoumat a upravit tato mapování v hlavním motivu prezentace a ověřit, že změny přežijí cyklus uložení‑a‑znovunačtení.

## **Pochopení tagů skriptů**

Metody pro skriptové písmo používají čtyřpísmenné podtagy BCP 47 k identifikaci psacích systémů. Běžné hodnoty zahrnují:

| Tag skriptu | Psací systém |
|---|---|
| `Cyrl` | Cyrilština |
| `Arab` | Arabština |
| `Hans` | Zjednodušená čínština |
| `Jpan` | Japonština |
| `Geor` | Gruzínština |
| `Thaa` | Thaana |

Tato mapování patří k motivu schématu písem, nikoli k jednotlivým částem textu. Prezentace může definovat různá mapování pro hlavní a vedlejší sbírky a může u některých skriptů mapování vynechat.

## **Přístup a inspekce mapování skriptových písem**

Použijte [Presentation::getMasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasterTheme) k získání motivu na úrovni prezentace. Metody [MasterTheme::getFontScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/#getFontScheme), [FontScheme::getMajor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/#getMajor) a [FontScheme::getMinor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/#getMinor) poskytují přístup k dvěma sbírkám [Fonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/).

Zavolejte [Fonts::getScriptFontMap](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/#getScriptFontMap) k načtení všech mapování ze sbírky. K vyhledání jednoho psacího systému zavolejte [Fonts::getScriptFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/#getScriptFont) s jeho tagem skriptu. `Fonts::getScriptFont` vrací `null`, pokud daná sbírka nepoužívá požadované mapování.

## **Úprava mapování a ověření perzistence**

Použijte [Fonts::setScriptFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/#setScriptFont) k vytvoření mapování nebo nahrazení aktuální rodiny písma. Použijte [Fonts::removeScriptFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/#removeScriptFont) k odstranění mapování.

Následující end‑to‑end příklad načte všechna existující hlavní a vedlejší mapování, vyhledá hlavní japonské písmo, změní hlavní cyrilické písmo, odstraní vedlejší mapování thaana, uloží prezentaci a znovu ji otevře k ověření obou změn. Aby byl krok odstraňování nezávislý na počátečním motivu, příklad nejprve vytvoří mapování thaana jen pokud ještě není definováno.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $fontScheme = $presentation->getMasterTheme()->getFontScheme();
    $majorFonts = $fontScheme->getMajor();
    $minorFonts = $fontScheme->getMinor();

    echo "Existing major mappings:" . PHP_EOL;
    $majorMappings = $majorFonts->getScriptFontMap()->iterator();
    while (java_values($majorMappings->hasNext())) {
        $mapping = $majorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    echo "Existing minor mappings:" . PHP_EOL;
    $minorMappings = $minorFonts->getScriptFontMap()->iterator();
    while (java_values($minorMappings->hasNext())) {
        $mapping = $minorMappings->next();
        echo "  " . java_values($mapping->getKey()) . ": " . java_values($mapping->getValue()) . PHP_EOL;
    }

    $japaneseFont = $majorFonts->getScriptFont("Jpan");
    if (java_is_null($japaneseFont)) {
        echo "No major Japanese font is defined." . PHP_EOL;
    } else {
        echo "Major Japanese font: " . java_values($japaneseFont) . PHP_EOL;
    }

    $majorFonts->setScriptFont("Cyrl", "Arial");

    if (java_is_null($minorFonts->getScriptFont("Thaa"))) {
        $minorFonts->setScriptFont("Thaa", "Arial");
    }

    $minorFonts->removeScriptFont("Thaa");
    $presentation->save("script-font-mappings.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("script-font-mappings.pptx");
try {
    $savedMajorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMajor();
    $savedMinorFonts = $savedPresentation->getMasterTheme()->getFontScheme()->getMinor();
    $savedCyrillicFont = $savedMajorFonts->getScriptFont("Cyrl");
    $savedThaanaFont = $savedMinorFonts->getScriptFont("Thaa");

    if (!java_is_null($savedCyrillicFont) && java_values($savedCyrillicFont) === "Arial") {
        echo "The Cyrillic mapping was preserved." . PHP_EOL;
    } else {
        echo "The Cyrillic mapping was not preserved." . PHP_EOL;
    }

    if (java_is_null($savedThaanaFont)) {
        echo "The Thaana mapping removal was preserved." . PHP_EOL;
    } else {
        echo "The Thaana mapping still exists." . PHP_EOL;
    }
} finally {
    $savedPresentation->dispose();
}
```

Ověření používá stejné chování `null` jako běžné vyhledávání: po uložení odstranění `Fonts::getScriptFont("Thaa")` vrací `null` pro vedlejší sbírku.

## **Rozlišení mapování motivu od ostatních nastavení písem**

Mapování motivu specifické pro skript se podílí na výběru písma, ale řeší jiný problém než přímé formátování textu, substituce a náhradní písmo:

| Mechanismus | Účel | Efekt změny mapování motivu |
|---|---|---|
| Mapování motivu specifické pro skript | Vybere hlavní nebo vedlejší motivové písmo pro psací systém. | Text, který stále používá odpovídající motivové písmo, se může přepnout na nově mapovanou rodinu. |
| Písmo přiřazené explicitně k části textu | Fixuje požadovanou rodinu písma na této části místo spolehnutí se na motiv. | Část může zůstat beze změny, protože její přímé formátování přebije volbu motivu. |
| Substituce písma | Nahrazuje požadované písmo, když není dostupné nebo když platí pravidlo substituce. | Probíhá po požadavku na písmo; nepředefinuje mapování skriptu v motivu. |
| Náhradní písmo | Poskytuje glyphy, které vybrané písmo neobsahuje, často pro konkrétní rozsahy Unicode. | Doplňuje chybějící glyphy; nemění uložené mapování motivu. |

Více informací o posledních dvou mechanismech najdete v [Font Substitution](/slides/cs/php-java/font-substitution/) a [Fallback Fonts](/slides/cs/php-java/fallback-font/).

Změna mapování v [Presentation::getMasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getMasterTheme) ovlivní pouze obsah, jehož efektivní formátování stále závisí na tomto motivu. Text může místo toho dědit přepsání motivu z masteru, rozložení nebo snímku, nebo použít explicitně přiřazené písmo. Prohlédněte si tyto úrovně, pokud viditelný výsledek neodpovídá mapování na úrovni prezentace.

## **Zajištění dostupnosti mapovaných písem a ověření výsledku**

Mapování skriptu ukládá název rodiny písma; neinstaluje ani nenačítá odpovídající soubor písma. Pro konzistentní vykreslení a export musí být každé mapované písmo nainstalováno v prostředí nebo poskytnuto Aspose.Slides pomocí vlastního zdroje, například [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsloader/#loadExternalFonts) nebo [LoadOptions::getDocumentLevelFontSources](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#getDocumentLevelFontSources). Viz [Custom Fonts](/slides/cs/php-java/custom-font/) pro dostupné možnosti načítání.

Ověření uloženého mapování potvrzuje jen, že definice motivu byla zachována. Neposkytuje důkaz, že je písmo dostupné, obsahuje všechny požadované glyphy nebo vytváří zamýšlené rozvržení. Vykreslete reprezentativní text pro každý požadovaný psací systém do obrázku nebo PDF a prohlédněte výstup. Tím odhalíte chybějící písma, neúplné pokrytí glyphů, chování náhrad a změny rozvržení před distribucí prezentace. Viz [Convert PowerPoint Presentations](/slides/cs/php-java/convert-powerpoint/) pro příklady vykreslení a exportu.

## **Často kladené otázky**

**Co vrací `Fonts::getScriptFont`, když skript není mapován?**

[Fonts::getScriptFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/#getScriptFont) vrací `null`, když požadované mapování skriptu není definováno v hlavní nebo vedlejší sbírce písem.

**Přidá `Fonts::setScriptFont` druhé mapování, pokud skript již existuje?**

Ne. [Fonts::setScriptFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fonts/#setScriptFont) vytvoří mapování, pokud chybí, a nahradí mapovanou rodinu písma, když je tag skriptu již přítomen.

**Proč změna mapování motivu neovlivnila některý text?**

Text může mít explicitně přiřazené písmo, dědit jiný motiv skrze přepsání, nebo být ovlivněn substitucí či náhradou během vykreslování. Mapování skriptu na úrovni prezentace řídí jen text, jehož efektivní formátování stále odkazuje na tuto sbírku motivových písem.

**Je uložení a opětovné otevření dostatečné pro validaci vícejazyčného výstupu?**

Ne. Opětovné otevření ověřuje perzistenci dat motivu. Také je potřeba vykreslit reprezentativní text z každého požadovaného psacího systému, aby bylo potvrzeno, že mapovaná písma jsou dostupná a obsahují potřebné glyphy.