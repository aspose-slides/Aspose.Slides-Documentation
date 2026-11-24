---
title: Správa motivů prezentací v PHP
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/php-java/presentation-theme/
keywords:
- PowerPoint motiv
- motiv prezentace
- motiv snímku
- nastavit motiv
- změnit motiv
- spravovat motiv
- externí motiv
- THMX
- barva motivu
- další paleta
- písmo motivu
- styl motivu
- efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro PHP přes Java pro tvorbu, přizpůsobení a konverzi souborů PowerPoint s konzistentní značkou."
---
## **Úvod**

Motiv prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objektům citlivým na motiv se odkazuje na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace přes [MasterThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/masterthememanager/), zatímco rozvržení nebo jednotlivý snímek může přepsat svůj zděděný motiv přes [BaseOverrideThemeManager::getOverrideTheme](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). V praxi se účinný motiv pro snímek určuje pomocí tohoto řetězce dědičnosti: motiv prezentace, přepsání masteru, přepsání rozvržení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s motivy: prohlédnutí motivu, změna barev a písem, kopírování nebo použití motivu, aktualizace stylů pozadí a efektů a čtení účinných hodnot po vyřešení dědičnosti a přepsání.

## **Prohlédnutí motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) poskytuje schéma barev motivu, schéma písem a schéma formátování přes [MasterTheme::getColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/), [MasterTheme::getFontScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/) a [MasterTheme::getFormatScheme](https://reference.aspose.com/slides/php-java/aspose.slides/mastertheme/). Prohlédnutí těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad čte hlavní vlastnosti motivu a uvádí, kolik stylů pozadí, výplně, čáry a efektu je v motivu uloženo:

```php
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $theme = $presentation->getMasterTheme();

    echo "Theme name: " . $theme->getName() . PHP_EOL;
    echo "Accent 1: " . $theme->getColorScheme()->getAccent1()->getColor() . PHP_EOL;
    echo "Major Latin font: " . $theme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Minor Latin font: " . $theme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Background fill styles: " . java_values($theme->getFormatScheme()->getBackgroundFillStyles()->size()) . PHP_EOL;
    echo "Fill styles: " . java_values($theme->getFormatScheme()->getFillStyles()->size()) . PHP_EOL;
    echo "Line styles: " . java_values($theme->getFormatScheme()->getLineStyles()->size()) . PHP_EOL;
    echo "Effect styles: " . java_values($theme->getFormatScheme()->getEffectStyles()->size()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný účinný motiv. Prohlédněte master přiřazený ke snímku a použijte pracovní postup s účinným motivem uvedený později v tomto článku, pokud mohou existovat přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Výplně, čáry a text citlivé na motiv mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, se změna motivu nijak neprojeví.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne účinnou barvu výplně:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 100, 100);
    $shape->getFillFormat()->setFillType(FillType::Solid);
    $shape->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $presentation->getMasterTheme()->getColorScheme()->getAccent4()->setColor(java("java.awt.Color")->RED);

    $presentation->save("theme-color.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$savedPresentation = new Presentation("theme-color.pptx");
try {
    $savedSlide = $savedPresentation->getSlides()->get_Item(0);

    $savedShape = $savedSlide->getShapes()->get_Item(0);
    $effectiveColor = $savedShape->getFillFormat()->getEffective()->getSolidFillColor();
    echo sprintf("Effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
} finally {
    $savedPresentation->dispose();
}
```

Protože obdélník zůstává propojen s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte schématickou barvu přímou barvou na tvaru, pozdější změny `Accent4` už tento výplň neovlivní.

### **Použití barev z rozšířené palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barev. Aspose.Slides tyto transformace vystavuje pomocí výčtu [ColorTransformOperation](https://reference.aspose.com/slides/php-java/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy generované z rozšířené palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich použije luminanční transformace a uloží výsledek:

```php
use aspose\slides\ColorTransformOperation;
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SchemeColor;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape1 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 10, 50, 50);
    $shape1->getFillFormat()->setFillType(FillType::Solid);
    $shape1->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);

    $shape2 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 70, 50, 50);
    $shape2->getFillFormat()->setFillType(FillType::Solid);
    $shape2->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.2);
    $shape2->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.8);

    $shape3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 130, 50, 50);
    $shape3->getFillFormat()->setFillType(FillType::Solid);
    $shape3->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.4);
    $shape3->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.6);

    $shape4 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 190, 50, 50);
    $shape4->getFillFormat()->setFillType(FillType::Solid);
    $shape4->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.6);
    $shape4->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::AddLuminance, 0.4);

    $shape5 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 250, 50, 50);
    $shape5->getFillFormat()->setFillType(FillType::Solid);
    $shape5->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape5->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.75);

    $shape6 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 10, 310, 50, 50);
    $shape6->getFillFormat()->setFillType(FillType::Solid);
    $shape6->getFillFormat()->getSolidFillColor()->setSchemeColor(SchemeColor::Accent4);
    $shape6->getFillFormat()->getSolidFillColor()->getColorTransform()->add(ColorTransformOperation::MultiplyLuminance, 0.5);

    $presentation->save("theme-color-palette.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Tyto varianty zůstávají založeny na barvě motivu. Pokud se `Accent4` později změní, transformované barvy se přepočítají z nové hodnoty `Accent4`.

### **Mapování hodnot `SchemeColor` na sloty `ColorScheme`**

Výčet [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/php-java/aspose.slides/colorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejde o hodnoty dynamicky převáděné z jednoho tvaru na druhý.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu pro tělo textu. Metody [FontScheme::getMajor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) a [FontScheme::getMinor](https://reference.aspose.com/slides/php-java/aspose.slides/fontscheme/) tyto sady zpřístupňují.

Identifikátory písem kompatibilních s PowerPointem lze použít při formátování textu:

* `+mn‑lt` – Tělo písma Latin (Minor Latin Font)
* `+mj‑lt` – Nadpis písma Latin (Major Latin Font)
* `+mn‑ea` – Tělo písma East Asian (Minor East Asian Font)
* `+mj‑ea` – Nadpis písma East Asian (Major East Asian Font)
* `+mn‑cs` – Tělo písma Complex Script (Minor Complex Script Font)
* `+mj‑cs` – Nadpis písma Complex Script (Major Complex Script Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo motivu, a jeden řádek těla, který používá vedlejší latinské písmo motivu. Pak změní písma motivu a uloží výsledek:

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $heading = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 500, 60);
    $heading->getTextFrame()->setText("Theme heading");
    $heading->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mj-lt"));

    $body = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 120, 500, 60);
    $body->getTextFrame()->setText("Theme body text");
    $body->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $presentation->getMasterTheme()->getFontScheme()->getMajor()->setLatinFont(new FontData("Aptos Display"));
    $presentation->getMasterTheme()->getFontScheme()->getMinor()->setLatinFont(new FontData("Arial"));

    $presentation->save("theme-fonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nadpis používá hlavní písmo a tělo používá vedlejší písmo. Text, který má explicitně nastavený název písma místo identifikátoru motivu, se automaticky nepřepne při změně schématu písem motivu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psané systémy, jako jsou Cyrilice, Arabština, Japonština, Gruzie a Thaana. Pro prohlédnutí, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písech v prezentaci viz [PowerPoint Fonts](/slides/cs/php-java/powerpoint-fonts/).
{{% /alert %}}

### **Řešení odkazů na písmo motivu**

Při prohlížení textu může [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) vrátit odkaz na motiv, např. `+mn‑lt`, místo názvu rodiny písem. Zavolejte [FontData::getFontName](https://reference.aspose.com/slides/php-java/aspose.slides/fontdata/) s odpovídajícími účinnými daty motivu, aby se odkaz vyřešil. Předpony `+mj` a `+mn` vybírají hlavní a vedlejší sadu písem; přípony `-lt`, `-ea` a `-cs` vybírají jejich latinské, východoasijské a komplexní skriptové písmo.

Získejte účinný motiv přes [Slide::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) na objekt, jehož motiv se vztahuje k prohlíženému textu. Pro běžný text na snímku tuto metodu zavolejte na snímek, aby kontext zahrnoval zděděný motiv snímku a lokální přepsání. Při prohlížení rozvržení nebo samotného masteru použijte jeho vlastní účinný motiv. Nepředpokládejte, že motiv prvního masteru platí pro každý snímek.

Následující příklad vytvoří textový úsek, který explicitně odkazuje na vedlejší latinské písmo. Inicializuje schéma písem snímku pomocí [OverrideTheme::initFontSchemeFromInherited](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) a nastaví hlavní a vedlejší latinské rodiny na `Arial` a `Calibri`, čímž je výsledek reprodukovatelný bez vstupního souboru.

```php
use aspose\slides\FontData;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $theme = $slide->getThemeManager()->getOverrideTheme();
    $theme->initFontSchemeFromInherited();
    $theme->getFontScheme()->getMajor()->setLatinFont(new FontData("Arial"));
    $theme->getFontScheme()->getMinor()->setLatinFont(new FontData("Calibri"));

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 60);
    $shape->getTextFrame()->setText("Text using the minor theme font");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLatinFont(new FontData("+mn-lt"));

    $font = $portion->getPortionFormat()->getLatinFont();
    $effectiveTheme = $slide->createThemeEffective();
    echo $font->getFontName() . " -> " . $font->getFontName($effectiveTheme) . PHP_EOL;

    $explicitFont = new FontData("Verdana");
    echo $explicitFont->getFontName() . " -> " . $explicitFont->getFontName($effectiveTheme) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Výstup je `+mn‑lt -> Calibri` následovaný `Verdana -> Verdana`. Uložený odkaz zůstává nezměněn, zatímco explicitní název rodiny je vrácen tak, jak je. Kdyby úsek použil `+mj‑lt`, vyřešilo by se na `Arial` v tomto motivu.

Vyřešení odkazu na motiv identifikuje rodinu písma specifikovanou motivem. Nekontroluje dostupnost písma ani nevypočítává, který soubor písma je nakonec použit po substituci nebo záložním výběru během vykreslování. Viz [Font Selection Sequence](/slides/cs/php-java/font-selection-sequence/) a [Font Substitution](/slides/cs/php-java/font-substitution/) pro tyto samostatné kroky.

## **Kopírování nebo použití motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivy.

### **Použití externího motivu na snímky závislé na masteru**

Použijte [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) když máte soubor motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master ze sbírky [Presentation::getMasters](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), která je reprezentována pomocí [MasterSlideCollection](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), a předejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master slide na základě vybraného masteru.  
1. Aplikuje externí motiv na nový master.  
1. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
1. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/).

Následující příklad aplikuje externí motiv na snímky, které závisí na prvním masteru, a uloží prezentaci:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $selectedMaster = $presentation->getMasters()->get_Item(0);
    $themedMaster = $selectedMaster->applyExternalThemeToDependingSlides("corporate-theme.thmx");

    echo "Created master: " . java_values($themedMaster->getName()) . PHP_EOL;

    $presentation->save("presentation-with-external-theme.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Neplatný, poškozený nebo nepodporovaný motiv může způsobit [PptxReadException](https://reference.aspose.com/slides/php-java/aspose.slides/pptxreadexception/). Ověřujte cesty zadané uživateli, ošetřete selhání přístupu k souborovému systému a prezentaci ukládejte až po úspěšném aplikování motivu.

Přesunou se jen snímky, které závisely na vybraném masteru. Snímky spojené s jinými mastery si zachovají své stávající mastery a motivy. Barvy, písma, výplně, čáry, pozadí a efekty citlivé na motiv jsou vyhodnoceny vůči externímu motivu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Motiv může odkazovat na písma, která nejsou v době běhu k dispozici. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, zpřístupněte je pomocí [custom font sources](/slides/cs/php-java/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/php-java/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje manuální vytváření přepsání na úrovni snímku nebo rozvržení.

### **Použití různých externích motivů v prezentaci s více mastery**

Když není předem známý relevantní master, získejte jej ze zástupního snímku pomocí [Slide::getLayoutSlide](https://reference.aspose.com/slides/php-java/aspose.slides/slide/) a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslide/). Před aplikací jakýchkoli motivů uložte původní odkazy na mastery, protože každý volání vytvoří další master v prezentaci.

Následující příklad použije snímky ze dvou sekcí ke zjištění jejich masterů a aplikuje odlišný externí motiv na každou skupinu:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (java_values($presentation->getSlides()->size()) < 5) {
        echo "The presentation does not contain the expected representative slides." . PHP_EOL;
    } else {
        $firstGroupMaster = $presentation->getSlides()->get_Item(0)->getLayoutSlide()->getMasterSlide();
        $secondGroupMaster = $presentation->getSlides()->get_Item(4)->getLayoutSlide()->getMasterSlide();

        if (java_values($firstGroupMaster->getSlideId()) === java_values($secondGroupMaster->getSlideId())) {
            echo "The representative slides use the same master." . PHP_EOL;
        } else {
            $firstThemedMaster = $firstGroupMaster->applyExternalThemeToDependingSlides("blue-theme.thmx");
            $secondThemedMaster = $secondGroupMaster->applyExternalThemeToDependingSlides("green-theme.thmx");

            echo "First themed master: " . java_values($firstThemedMaster->getName()) . PHP_EOL;
            echo "Second themed master: " . java_values($secondThemedMaster->getName()) . PHP_EOL;

            $presentation->save("multi-master-with-external-themes.pptx", SaveFormat::Pptx);
        }
    }
} finally {
    $presentation->dispose();
}
```

První volání ovlivní jen snímky, které závisí na `$firstGroupMaster`, a druhé volání ovlivní jen snímky, které závisí na `$secondGroupMaster`. Snímky patřící k jiným masterům nebudou přeformátovány.

### **Zachování původního motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, klonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/), poté klonujte snímek s [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/) a klonovaným masterem. Tím se přenese master, jeho rozvržení a související motiv společně.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $sourceSlide = $source->getSlides()->get_Item(0);

        $sourceMaster = $sourceSlide->getLayoutSlide()->getMasterSlide();
        $clonedMaster = $target->getMasters()->addClone($sourceMaster);

        $target->getSlides()->addClone($sourceSlide, $clonedMaster, true);

        $target->save("theme-preserved.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Toto je preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikace hodnot motivu na existující snímek**

Pokud má cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte lokální přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme::initColorSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/), [OverrideTheme::initFontSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) a [OverrideTheme::initFormatSchemeFrom](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/) zkopírují tři hlavní komponenty motivu do přepsání.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);

        $overrideTheme = $targetSlide->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-slide.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Tím se změní motiv použitého snímku, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme::clear](https://reference.aspose.com/slides/php-java/aspose.slides/overridetheme/).

### **Aplikace přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají dané rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/layoutslidethememanager/):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new Presentation("source-theme.pptx");
try {
    $target = new Presentation("target.pptx");
    try {
        $targetSlide = $target->getSlides()->get_Item(0);
        
        $overrideTheme = $targetSlide->getLayoutSlide()->getThemeManager()->getOverrideTheme();
        $overrideTheme->initColorSchemeFrom($source->getMasterTheme()->getColorScheme());
        $overrideTheme->initFontSchemeFrom($source->getMasterTheme()->getFontScheme());
        $overrideTheme->initFormatSchemeFrom($source->getMasterTheme()->getFormatScheme());

        $target->save("theme-applied-to-layout.pptx", SaveFormat::Pptx);
    } finally {
        $target->dispose();
    }
} finally {
    $source->dispose();
}
```

Použijte motiv na úrovni masteru nebo prezentace, když má mnoho rozvržení a snímků sdílet stejné základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné formátování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme::getBackgroundFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této sbírce, protože UI může kombinovat výplně motivu s barvami motivu a dalšími referencemi stylů.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou kolekci a aktuální [Background::getStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/background/). Index stylu `0` znamená žádnou motivovou výplň; kladné hodnoty jsou odkazy na motivové styly pozadí. To se liší od indexování PHP kolekce přímo, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad uvádí počet dostupných výplní pozadí, přiřadí motivový odkaz na pozadí prvnímu masteru a uloží prezentaci:

```php
use aspose\slides\BackgroundType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $backgroundStyleCount = java_values($presentation->getMasterTheme()->getFormatScheme()->getBackgroundFillStyles()->size());
    echo "Background fill styles: " . $backgroundStyleCount . PHP_EOL;
    if ($backgroundStyleCount === 0) {
        throw new RuntimeException("The presentation theme does not contain background fill styles.");
    }

    $masterSlide = $presentation->getMasters()->get_Item(0);
    $masterSlide->getBackground()->setType(BackgroundType::Themed);
    $masterSlide->getBackground()->setStyleIndex(1);

    $presentation->save("theme-background.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Viditelný výsledek závisí na záznamu motivu, na který master odkazuje, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze motivu masteru nemusí tento snímek změnit. Použijte [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) pokud potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}
Nezpracovávejte index stylu jako nulově‑ založený index kolekce. Také se vyhněte hardcodování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro konkrétní prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/php-java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátování motivu obsahuje samostatné kolekce výplní, čar a efektových stylů vystavené přes [FormatScheme::getFillStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/), [FormatScheme::getLineStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/) a [FormatScheme::getEffectStyles](https://reference.aspose.com/slides/php-java/aspose.slides/formatscheme/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl kontrolovat každou kolekci místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Při přístupu k těmto kolekcím v PHP je index kolekce nulově‑ založený: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazující na styl tvaru jsou samostatný pojem, vystavený přes [ShapeStyle](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/). Úprava stylu motivu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat beze změny.

Následující příklad ověří, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a uloží výsledek:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    $formatScheme = $presentation->getMasterTheme()->getFormatScheme();
    if (java_values($formatScheme->getLineStyles()->size()) < 1 || java_values($formatScheme->getFillStyles()->size()) < 3 || java_values($formatScheme->getEffectStyles()->size()) < 3) {
        throw new RuntimeException("The theme does not contain the style entries required by this example.");
    }

    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->setFillType(FillType::Solid);
    $formatScheme->getLineStyles()->get_Item(0)->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->RED);
    $formatScheme->getFillStyles()->get_Item(2)->setFillType(FillType::Solid);
    $formatScheme->getFillStyles()->get_Item(2)->getSolidFillColor()->setColor(new Java("java.awt.Color", 34, 139, 34));
    $effectFormat = $formatScheme->getEffectStyles()->get_Item(2)->getEffectFormat();
    $effectFormat->enableOuterShadowEffect();
    $effectFormat->getOuterShadowEffect()->setDistance(10.0);

    $presentation->save("theme-effects.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro tvary, které odkazují na tyto sloty, se první styl čáry motivu stane červeným, třetí styl výplně motivu se stane plnou lesní zelení a třetí styl efektu získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, které sloty stylu každý tvar odkazuje, a zda přímé formátování nepřepíše motiv.

![Styly efektů motivu po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Výběr výplní a čar motivu pro tvar**

Tvar může nezávisle vybrat svou výplň a obrys pomocí [ShapeStyle::setFillStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setFillStyleIndex) a [ShapeStyle::setLineStyleIndex](https://reference.aspose.com/slides/php-java/aspose.slides/shapestyle/#setLineStyleIndex). Pro obě metody index `1` vybírá první položku ve odpovídající kolekci motivu (`get_Item(0)`) a index `2` vybírá druhou (`get_Item(1)`).

Následující příklad nastaví dva styly výplně (zlatý a nebe-modrý) a dva styly čáry (tmavě modrý 6 pt a tmavě červený 12 pt) ve výchozím motivu nové prezentace. Uloží snímek ve třech fázích, abyste si mohli porovnat výsledky v PowerPointu.

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $styles = $presentation->getMasterTheme()->getFormatScheme();

    $goldFill = $styles->getFillStyles()->get_Item(0);
    $goldFill->setFillType(FillType::Solid);
    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 255, 215, 0));
    $blueFill = $styles->getFillStyles()->get_Item(1);
    $blueFill->setFillType(FillType::Solid);
    $blueFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 135, 206, 235));

    $thinLine = $styles->getLineStyles()->get_Item(0);
    $thinLine->getFillFormat()->setFillType(FillType::Solid);
    $thinLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 139));
    $thinLine->setWidth(6);
    $thickLine = $styles->getLineStyles()->get_Item(1);
    $thickLine->getFillFormat()->setFillType(FillType::Solid);
    $thickLine->getFillFormat()->getSolidFillColor()->setColor(new Java("java.awt.Color", 139, 0, 0));
    $thickLine->setWidth(12);

    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    $left = $shapes->addAutoShape(ShapeType::Rectangle, 100, 205, 200, 130);
    $right = $shapes->addAutoShape(ShapeType::Rectangle, 420, 205, 200, 130);
    $left->getShapeStyle()->setFillStyleIndex(1);
    $right->getShapeStyle()->setFillStyleIndex(2);
    $left->getShapeStyle()->setLineStyleIndex(1);
    $right->getShapeStyle()->setLineStyleIndex(1);
    $presentation->save("01-initial.pptx", SaveFormat::Pptx);

    $right->getShapeStyle()->setLineStyleIndex(2);
    $presentation->save("02-line-changed.pptx", SaveFormat::Pptx);

    $goldFill->getSolidFillColor()->setColor(new Java("java.awt.Color", 46, 139, 87));
    $presentation->save("03-theme-changed.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

| Počáteční styly | Změna pravého obrysu | Úprava první výplně motivu |
|:---:|:---:|:---:|
| ![Zlaté a nebe‑modré obdélníky s odpovídajícími tenkými tmavě modrými obrysy](theme-style-initial.png) | ![Nebe‑modrý obdélník má nyní tlustý tmavě červený obrys](theme-style-line-changed.png) | ![Levý obdélník je nyní zelený a oba obrysy zůstaly beze změny](theme-style-fill-changed.png) |

Výběr jiného stylu čáry mění pouze obrys pravého obdélníku. Úprava první výplně motivu aktualizuje každý tvar, který ji používá. Zde se zeleně zbarví jen levý obdélník.

U existujícího tvaru může lokální barva výplně, barva čáry nebo šířka čáry přepsat příslušnou část motivu. Pokud změna indexu stylu nemá viditelný efekt, zkontrolujte [direct formatting](/slides/cs/php-java/shape-formatting/) tvaru.

## **Zjištění, zda účinná plná výplň používá barvu motivu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, motivu nebo jiné úrovně formátování. Zavolejte [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/) pro vyřešení této hierarchie do neměnných účinných dat výplně. Nejprve zkontrolujte výsledek `getFillType`. Pouze když je to `FillType::Solid`, čtěte vlastnosti plné výplně.

Pro plnou výplň `getSolidFillColor` vrací konečnou vykreslenou RGB hodnotu po zděděnosti, vyhledání motivu a aplikaci transformací barev. Metoda `getSolidFillSchemeColor` vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor::NotDefined` znamená, že účinná plná výplň není založena na schématické barvě. V pracovním postupu, kde jsou výplně buď barvy motivu nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Nepoužívejte lokální hodnotu [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/php-java/aspose.slides/colorformat/) samotnou k zařazení výplně. Například část textu může mít žádnou lokálně definovanou schématickou barvu, takže její lokální hodnota je `NotDefined`, zatímco její účinná výplň zděděná z motivu se vyhodnotí na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` vám řekne, který logický slot motivu vytvořil účinnou barvu, ale neříká, zda tento slot pochází z objektu, odstavce, rozvržení, masteru nebo jiné úrovně hierarchie.

Následující příklad načte prezentaci, zkontroluje výplně tvarů i výplně textových úseků, vytiskne každou finální RGB hodnotu a související schématickou barvu a označí plné výplně, které nebudou sledovat změny barvy motivu:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SchemeColor;

$auditFill = function (string $objectName, $localFill): void {
    $effectiveFill = $localFill->getEffective();

    if (java_values($effectiveFill->getFillType()) != FillType::Solid) {
        echo $objectName . ": fill type = " . java_values($effectiveFill->getFillType()) . "; not a solid fill." . PHP_EOL;
        return;
    }

    $rgb = $effectiveFill->getSolidFillColor();
    $effectiveSchemeColor = java_values($effectiveFill->getSolidFillSchemeColor());
    $localSchemeColor = java_values($localFill->getSolidFillColor()->getSchemeColor());

    echo sprintf("%s: RGB = #%02X%02X%02X", $objectName, java_values($rgb->getRed()), java_values($rgb->getGreen()), java_values($rgb->getBlue())) . PHP_EOL;
    echo $objectName . ": local scheme = " . $localSchemeColor . ", effective scheme = " . $effectiveSchemeColor . PHP_EOL;

    if ($effectiveSchemeColor == SchemeColor::NotDefined) {
        echo $objectName . ": direct RGB or another non-scheme fill; audit as theme-independent." . PHP_EOL;
    } else {
        echo $objectName . ": theme-dependent through " . $effectiveSchemeColor . "." . PHP_EOL;
    }
};

$autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
$presentation = new Presentation("input.pptx");
try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);

        $shapeCount = java_values($slide->getShapes()->size());
        for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            $shapeName = "Slide " . ($slideIndex + 1) . ", shape " . ($shapeIndex + 1);
            $auditFill($shapeName, $shape->getFillFormat());

            if (java_instanceof($shape, $autoShapeClass)) {
                $paragraphCount = java_values($shape->getTextFrame()->getParagraphs()->getCount());
                for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);

                    $portionCount = java_values($paragraph->getPortions()->getCount());
                    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                        $portion = $paragraph->getPortions()->get_Item($portionIndex);
                        $portionName = $shapeName . ", paragraph " . ($paragraphIndex + 1) . ", portion " . ($portionIndex + 1);
                        $auditFill($portionName, $portion->getPortionFormat()->getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

Větev `NotDefined` poskytuje auditní seznam plných výplní, které nebudou reagovat na změny v slotách barvy motivu. Prohlédněte si tyto objekty, když musí prezentace následovat novou firemní paletu. Uvedená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schématu vysvětluje, zda je tento vzhled spojen s motivem.

Objekty s účinným formátem jsou snímky v čase. Po změně motivu prezentace, přepsání motivu nebo jakéhokoli zděděného formátování znovu zavolejte `getEffective` a přečtěte nová účinná data výplně před porovnáním nebo hlášením barev.

## **Čtení účinných hodnot motivu**

Surové objekty motivu říkají, co je definováno na konkrétní úrovni. Účinné hodnoty říkají, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/), a pro výplň [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/).

Následující příklad načte účinný motiv, pozadí a první výplň tvaru ze snímku:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;

$presentation = new Presentation("input.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $effectiveTheme = $slide->getThemeManager()->createThemeEffective();
    $effectiveBackground = $slide->getBackground()->getEffective();

    echo "Effective major Latin font: " . $effectiveTheme->getFontScheme()->getMajor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective minor Latin font: " . $effectiveTheme->getFontScheme()->getMinor()->getLatinFont()->getFontName() . PHP_EOL;
    echo "Effective background fill type: " . java_values($effectiveBackground->getFillFormat()->getFillType()) . PHP_EOL;

    if (java_values($slide->getShapes()->size()) > 0) {
        $effectiveFill = $slide->getShapes()->get_Item(0)->getFillFormat()->getEffective();
        echo "First shape effective fill type: " . java_values($effectiveFill->getFillType()) . PHP_EOL;
        if (java_values($effectiveFill->getFillType()) == FillType::Solid) {
            $effectiveColor = $effectiveFill->getSolidFillColor();
            echo sprintf("First shape effective fill color: A=%d, R=%d, G=%d, B=%d", java_values($effectiveColor->getAlpha()), java_values($effectiveColor->getRed()), java_values($effectiveColor->getGreen()), java_values($effectiveColor->getBlue())) . PHP_EOL;
        }
    }
} finally {
    $presentation->dispose();
}
```

Používejte účinná data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation::getMasterTheme](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), můžete přehlédnout přepsání masteru, rozvržení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivňuje aplikace externího motivu všechny snímky v prezentaci?**

Ne. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/php-java/aspose.slides/masterslide/) přeřazuje jen snímky, které závisí na vybraném masteru. Snímky používající jiné mastery si zachovají své existující motivy.

**Mohu aplikovat motiv na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/php-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále dědit své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu klonujte zdrojový master do cílové prezentace a klonujte snímek s tímto masterem pomocí [MasterSlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/masterslidecollection/) a [SlideCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/slidecollection/). Tím se master, rozvržení a motiv přenesou společně.

**Jak mohu vidět účinné hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager::createThemeEffective](https://reference.aspose.com/slides/php-java/aspose.slides/baseoverridethememanager/) pro snímek nebo rozvržení a odpovídající metody s účinnými daty pro formátové objekty, jako jsou [Background::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/background/) a [FillFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.