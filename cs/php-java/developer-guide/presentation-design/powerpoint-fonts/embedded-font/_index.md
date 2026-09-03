---
title: Vkládání písem do prezentací pomocí PHP
linktitle: Vložená písma
type: docs
weight: 40
url: /cs/php-java/embedded-font/
keywords:
- přidat písmo
- vložit písmo
- vkládání písma
- získat vložené písmo
- přidat vložené písmo
- odebrat vložené písmo
- komprimovat vložené písmo
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Spravujte vložená písma v PowerPointu pomocí Aspose.Slides pro PHP přes Java. Přidávejte, načítejte, odstraňujte a komprimujte písma, abyste zachovali vzhled textu a snížili velikost souboru."
---
## **Úvod**

Vkládání písem ukládá data písma uvnitř prezentace PowerPoint. Když prohlížeč podporuje vložená písma, může zobrazovat text s těmito písmy i v případě, že nejsou nainstalována v cílovém systému. To pomáhá zachovat zalomení řádků, mezery mezi texty a rozvržení snímků.

Aspose.Slides for PHP via Java vám umožňuje načíst, přidat a odebrat vložená písma pomocí třídy [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/), kterou vrací [Presentation::getFontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getFontsManager). Můžete také zmenšit velikost vložených dat písma odebráním znaků, které prezentace nepoužívá.

Níže uvedené příklady pracují se soubory PPTX. Před vložením písma se ujistěte, že jsou jeho data dostupná pro Aspose.Slides a že licence povoluje vkládání.

## **Získání a odebrání vložených písem**

Použijte [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) k výpisu písem uložených v prezentaci. Chcete‑li některé odebrat, předáte písmo z tohoto seznamu metodě [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont) a poté prezentaci uložíte.

Následující příklad vypisuje vložená písma v souboru `EmbeddedFonts.pptx` a odebere Calibri, pokud je přítomno:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Odebrání vloženého písma odstraní jeho uložená data; nezmění to písmo přiřazené textu. Pokud je písmo nainstalováno v cílovém systému, text jej může nadále používat. V opačném případě může renderování vyžadovat [font substitution](/slides/cs/php-java/font-substitution/), což může ovlivnit rozvržení.

## **Prohlédnutí dat písma a oprávnění k vkládání**

Pomocí třídy [FontsManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/) můžete před vložením písma provést jeho kontrolu. Zavolejte [FontsManager::getFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getFonts) a získáte písma použité v prezentaci. Pro každé písmo předáte objekt [FontData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontdata/) a požadovanou hodnotu [FontStyleType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontstyletype/) metodě [FontsManager::getFontBytes](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getFontBytes). Metoda vrací binární data pro daný styl písma nebo `null`, pokud požadované písmo nebo styl nejsou k dispozici. Nepředávejte výsledek `null` metodě [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), protože tato metoda vyžaduje pole bajtů.

[EmbeddingLevel](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embeddinglevel/) je výčtová struktura příznaků, která uvádí omezení vložení uložená v písmu:

- `Installable` povoluje vložení a trvalou instalaci v jiném systému, pokud to licence písma umožňuje.
- `Restricted` zakazuje vložení, pokud není získáno povolení od právního vlastníka písma, a to jako jediný příznak oprávnění k použití.
- `PreviewPrint` povoluje dočasné použití pro prohlížení a tisk; dokument obsahující písmo musí být jen pro čtení.
- `Editable` povoluje dočasné použití a umožňuje dokument upravovat a ukládat.
- `NoSubsetting` je další omezení, které zakazuje vložení pouze části znaků. V takovém případě se vloží všechny znaky.
- `BitmapOnly` je další omezení, které povoluje vložit jen bitmapové varianty, ne vektorová data. Pokud písmo nemá bitmapové varianty, nelze jej vložit.

První čtyři hodnoty popisují oprávnění k použití, zatímco `NoSubsetting` a `BitmapOnly` lze kombinovat s nimi. Modifikátory kontrolujte pomocí bitových operací. Protože `Installable` má hodnotu nula, maskujte bity oprávnění k použití a porovnávejte výsledek s `Installable` místo kontroly jako příznaku. Současná písma by měla nastavit nejvýše jeden bit oprávnění k použití. Pro kompatibilitu se staršími písmy, která mohou mít nastavených více, pomocná metoda níže vybírá nejméně restriktivní oprávnění: `Editable`, poté `PreviewPrint` a nakonec `Restricted`.

Následující příklad audituje data normálního, tučného, kurzívního a tučně‑kurzívního stylu dostupná pro každé písmo vrácené metodou `FontsManager::getFonts`. Přeskakuje nedostupné styly, omezená písma, písma jen s bitmapami, písma omezená na náhled a tisk (protože výstup zůstává editovatelný) a písma, která jsou již vložena. Pokud kterýkoli dostupný styl má `NoSubsetting`, vloží všechny znaky pro danou rodinu písem.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tato kontrola hlásí omezení zakódovaná v každém souboru písma. Neposkytuje licenci, neprokazuje, že jste písmo získali legálně, ani nenahrazuje kontrolu licenční smlouvy písma před distribucí vložené kopie.

## **Přidání vložených písem**

Použijte [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) k vložení písma. Jeho přetížení přijímají buď objekt [FontData](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontdata/), nebo pole bajtů obsahující data písma. Výčtová struktura [EmbedFontCharacters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embedfontcharacters/) určuje, které znaky se zahrnou:

- [All](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embedfontcharacters/) vloží všechny znaky písma. Použijte tuto možnost, když příjemci potřebují upravovat prezentaci a zadávat nový text.
- [OnlyUsed](https://reference.aspose.com/slides/cs/php-java/aspose.slides/embedfontcharacters/) vloží jen znaky použité v prezentaci, což snižuje velikost souboru. Vyberte tuto možnost pro dokončenou prezentaci určenou primárně k prohlížení.

Následující příklad používá [FontsManager::getFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getFonts) k získání písem použité v souboru `Fonts.pptx` a vloží ta, která ještě nejsou vložena. Písma k přidání musí být dostupná na počítači, na kterém kód běží. Existující vložená písma si zachovají své aktuální sady znaků.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Komprese vložených písem**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/cs/php-java/aspose.slides/compress/#compressEmbeddedFonts) zmenšuje data vložených písem odstraněním nepoužívaných znaků. Funguje na písmech, která jsou již vložena, takže míra zmenšení závisí na množství nepoužitého fontu v prezentaci.

Následující příklad komprimuje písma v souboru `EmbeddedFonts.pptx` a výsledek uloží jako samostatný soubor:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Uchovejte původní soubor, pokud příjemci mohou později potřebovat přidávat text. Znaky odstraněné během komprese již nejsou dostupné z vloženého písma, i když jste původně vložili všechny znaky.

## **Často kladené otázky**

**Jak zjistit, zda bude během vykreslování vložené písmo stále nahrazeno?**

V prostředí, kde prezentaci vykreslujete, zavolejte [FontsManager::getSubstitutions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontsmanager/#getSubstitutions) a zjistěte, která písma Aspose.Slides nahradí. Také zkontrolujte nastavení [font substitution](/slides/cs/php-java/font-substitution/) a pravidla [font fallback](/slides/cs/php-java/fallback-font/). Náhradní mechanismus řeší chybějící znaky, takže vložení písma nevyřeší znaky, které samotné písmo neobsahuje.

**Mám vkládat běžná písma jako Arial a Calibri?**

Rozhodnutí založte na cílovém prostředí. Pokud jsou požadovaná písma dostupná na každém počítači, který prezentaci otevírá nebo vykresluje, může jejich vkládání jen zbytečně zvětšit velikost souboru. Pokud by příjemci nebo servery tato písma mohly postrádat, může jejich vložení pomoci zachovat zamýšlený vzhled, pokud to licence povoluje.