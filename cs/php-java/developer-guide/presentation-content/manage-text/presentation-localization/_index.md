---
title: Automatizace lokalizace prezentace v PHP
linktitle: Lokalizace prezentace
type: docs
weight: 100
url: /cs/php-java/presentation-localization/
keywords:
- změna jazyka
- kontrola pravopisu
- potlačení kontroly pravopisu
- jazyk korektury
- identifikátor jazyka
- vícejazyčný text
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Nastavte jazyky korektury pro text v prezentacích PowerPoint a OpenDocument v PHP pomocí Aspose.Slides, včetně výchozích nastavení a vícejazyčných odstavců."
---
## **Přehled**

Aspose.Slides pro PHP prostřednictvím Java vám umožňuje konfigurovat metadata korektury pro jednotlivé textové části. Použijte [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) k určení jazyka korektury, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setSpellCheck) k povolení nebo potlačení kontrol pravopisu a [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setProofDisabled) k řízení širšího stavu „neprovádět korekturu“. Protože jsou tato nastavení použita na úrovni části, jeden odstavec může obsahovat více jazyků a různá pravidla korektury.

Tento článek vysvětluje, jak přiřadit jazyk konkrétnímu textu, nastavit výchozí jazyk pro nový text pomocí [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), vytvořit vícejazyčné odstavce, zvolit mezi `SpellCheck` a `ProofDisabled` a zachovat zamýšlená nastavení při použití [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Tyto vlastnosti ukládají metadata pro prezentační aplikace; nepřekládají text, neprovádějí kontrolu pravopisu na základě slovníku ani nevrací slova s pravopisnými chybami.

## **Nastavení jazyka korektury pro text**

Vytvořte nebo načtěte [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), získejte požadovanou textovou část pomocí [Portion::getPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getPortionFormat) a přiřaďte jí identifikátor jazyka. Následující příklad vytvoří tvar, nastaví britskou angličtinu jako jazyk korektury a výsledek uloží pomocí [Presentation::save](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavení výchozího jazyka pro nový text**

Pomocí [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) určete jazyk korektury, který Aspose.Slides přiřadí nově vytvořenému textu. Toto nastavení je užitečné, pokud většina nebo veškerý nový text v prezentaci používá stejný jazyk. Nemění metadata jazyka textu, který již má explicitně nastavený jazyk.

Následující příklad vytvoří prezentaci, jejíž nový text používá pravidla korektury pro němčinu:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Použití více jazyků v jednom odstavci**

[Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/) obsahuje kolekci textových částí. Pro každý jazyk vytvořte samostatný [Portion](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/) a nastavit jeho `LanguageId` nezávisle.

Tento příklad vytvoří jeden odstavec s částmi v angličtině a francouzštině:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Povolení nebo potlačení kontroly pravopisu pro jednotlivé části**

[PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/) dědí společné textové vlastnosti definované v [BasePortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/). Přistupujte k formátu části pomocí [Portion::getPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portion/#getPortionFormat) a použijte [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setSpellCheck) k řízení, zda prezentační aplikace může pro danou část kontrolovat pravopis. Výchozí hodnota je `false`: `true` povolí kontrolu pravopisu, `false` ji potlačí.

Nastavení se vztahuje na jednotlivé textové části. Různé části ve stejném odstavci tak mohou mít různé hodnoty. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) a `setSpellCheck` slouží doplňujícím účelům: `setLanguageId` určuje jazyk korektury, zatímco `setSpellCheck` rozhoduje, zda je pro část povolena kontrola pravopisu.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setProofDisabled) také řídí korekturu, ale představuje širší stav „neprovádět korekturu“ jako [NullableBool](https://reference.aspose.com/slides/cs/php-java/aspose.slides/nullablebool/). Použijte `setSpellCheck`, pokud potřebujete přímý Boolean přepínač specificky pro kontrolu pravopisu. Použijte `setProofDisabled`, pokud potřebujete zachovat nebo výslovně řídit metadata o neprovádění korektury, včetně stavu `NotDefined`. Pokud nastavíte obě vlastnosti, udržujte jejich hodnoty konzistentní; nekombinujte `setSpellCheck(true)` s `setProofDisabled(NullableBool::True)`.

Tyto vlastnosti konfigurovat metadata korektury používaná PowerPointem a dalšími prezentačními aplikacemi. Aspose.Slides je nepoužívá k provádění slovníkových kontrol pravopisu ani k vracení seznamu slov s pravopisnými chybami.

Následující kompletní příklad vytvoří vstupní prezentaci, načte ji, přiřadí různé nastavení kontroly pravopisu a jazyky korektury dvěma částem ve stejném odstavci, uloží výsledek, znovu jej otevře a ověří uložené hodnoty:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) spojuje sousední části, které mají stejné formátování. Rozdíl pouze v `SpellCheck` neudrží takové části oddělené; po jejich spojení si výsledná část zachová hodnotu `SpellCheck` první části. Pokud části potřebují různé nastavení kontroly pravopisu, zavolejte `joinPortionsWithSameFormatting` před přiřazením těchto nastavení, nebo po spojení zkontrolujte hranice výsledných částí a nastavení znovu aplikujte. Části s různými hodnotami `LanguageId` zůstávají oddělené, protože se liší formátování jazyka korektury.

## **Často kladené otázky**

**Překládá jazykové ID text?**

Ne. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId) ukládá metadata korektury pro pravopis a gramatiku; nemění obsah textu. Přeložte text samostatně a poté nastavte odpovídající identifikátor jazyka pro každou přeloženou část.

**Řídí jazyk korektury fonty, dělení slov nebo zalamování řádků?**

Ne. Identifikátor jazyka slouží pouze pro korekturu. Renderování a rozvržení textu především závisí na dostupných [fonts](/slides/cs/php-java/powerpoint-fonts/), systému zápisu a nastavení textového rámce. Pro spolehlivé vykreslení poskytněte požadované fonty, nakonfigurujte [font substitution](/slides/cs/php-java/font-substitution/) nebo [embed fonts](/slides/cs/php-java/embedded-font/) v prezentaci.

**Může jeden odstavec používat několik jazyků korektury?**

Ano. Přiřaďte každý jazyk k samostatné části, jak je ukázáno v příkladu vícejazyčného odstavce.

**Mám použít `setDefaultTextLanguage` nebo `setLanguageId`?**

Použijte [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), pokud chcete výchozí nastavení pro nově vytvořený text. Použijte [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId), když konkrétní část potřebuje explicitní jazyk korektury nebo když odstavec obsahuje více jazyků.