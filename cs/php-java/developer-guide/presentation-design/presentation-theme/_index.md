---
title: Správa motivů prezentací v PHP
linktitle: Motiv prezentace
type: docs
weight: 10
url: /cs/php-java/presentation-theme/
keywords:
- Motiv PowerPoint
- Motiv prezentace
- Motiv snímku
- Nastavit motiv
- Změnit motiv
- Spravovat motiv
- Externí motiv
- THMX
- Barva motivu
- Další paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro PHP přes Java pro vytváření, přizpůsobení a konverzi souborů PowerPoint s konzistentní identitou značky."
---
## **Úvod**

Motiv prezentace určuje koordinovanou sadu barev, písem, stylů pozadí, výplní, čar a efektů. Objektům, které jsou motivově‑svědomé, odkazují na tyto sdílené definice místo uložení každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace k dispozici prostřednictvím [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Hlavní snímek může přepsat motiv prezentace pomocí [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterthememanager/), zatímco rozložení nebo jednotlivý snímek může přepsat svůj zděděný motiv pomocí [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseoverridethememanager/). V praxi se efektivní motiv pro snímek řeší tímto řetězcem dědičnosti: motiv prezentace, přepsání hlavního snímku, přepsání rozložení a přepsání snímku.

![Komponenty motivu: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s motivy: prozkoumat motiv, změnit barvy a písma, kopírovat nebo použít motiv, aktualizovat styly pozadí a efektů a přečíst efektivní hodnoty po vyřešení dědičnosti a přepsání.

## **Prozkoumat motiv**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/) umožňuje přístup k barevnému schématu motivu, schématu písem a schématu formátu přes [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/). Prohlížení těchto kolekcí před jejich změnou je zvláště užitečné, když prezentace pochází z externího zdroje, protože počet a obsah položek stylu se mohou lišit.

Následující příklad načte hlavní vlastnosti motivu a nahlásí, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

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

Pokud soubor používá více hlavních snímků, nepředpokládejte, že každý snímek má stejný efektivní motiv. Prohlédněte hlavní snímek přidružený ke snímku a použijte pracovní postup s efektivním motivem uvedený později v tomto článku, když mohou existovat přepsání na úrovni rozložení nebo snímku.

## **Změna barev motivu**

Motivy‑svědomé výplně, čáry a text mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou vyhodnoceny vůči nové hodnotě. Objektům, které používají přímou RGB barvu, přepis motivu neovlivní.

Následující end‑to‑end příklad vytvoří tvar, který používá `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstane propojený s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud na tvaru nahradíte barvu schématu přímou barvou, pozdější změny `Accent4` již tuto výplň neovlivní.

### **Použití barev z doplňkové palety**

PowerPoint odvozuje světlejší a tmavší varianty z barvy motivu aplikací transformací barev. Aspose.Slides tyto transformace zpřístupňuje pomocí výčtu [ColorTransformOperation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy vygenerované z doplňkové palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.

**2** – Světlejší a tmavší varianty vytvořené ze hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich použije luminanční transformace a výsledek uloží:

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

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorscheme/) vystavuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty, které by se dynamicky převáděly z jedné podoby do druhé.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a vedlejší sadu písem pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/) tyto sady zpřístupňují.

Kompatibilní identifikátory písem motivu lze použít při formátování textu:

* `+mn‑lt` – tělo font Latin (Minor Latin Font)
* `+mj‑lt` – nadpis font Latin (Major Latin Font)
* `+mn‑ea` – tělo font East Asian (Minor East Asian Font)
* `+mj‑ea` – nadpis font East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis, který používá hlavní latinské písmo motivu, a jednu řádek těla, která používá vedlejší latinské písmo motivu. Poté změní písma motivu a výsledek uloží:

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

Nadpis následuje hlavní písmo a tělo textu následuje vedlejší písmo. Text, který má explicitní název písma místo identifikátoru motivu, se automaticky nepřepne, když se změní schéma písem motivu.

Hlavní a vedlejší kolekce písem mohou také obsahovat mapování písem pro jednotlivé psací systémy, jako jsou cyrilice, arabština, japonština, gruzínština a thaana. Pro prohlížení, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}
Pro více informací o písem v prezentacích viz [PowerPoint Fonts](/slides/cs/php-java/powerpoint-fonts/).
{{% /alert %}}

## **Kopírování nebo použití motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivy.

### **Použít externí motiv na snímky závislé na hlavním snímku**

Použijte [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) když máte soubor motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním hlavním snímku. Vyberte hlavní snímek ze sbírky [Presentation::getMasters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), která je reprezentována třídou [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/), a předávejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový hlavní snímek na základě vybraného hlavního snímku.
1. Aplikuje externí motiv na nový hlavní snímek.
1. Přidělí nový hlavní snímek všem snímkům, které předtím závisely na vybraném hlavním snímku.
1. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/).

Následující příklad použije externí motiv na snímky, které závisí na prvním hlavním snímku, a uloží prezentaci:

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

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxreadexception/). Ověřujte cesty zadávané uživateli, ošetřete selhání přístupu k souborovému systému a prezentaci uložte až po úspěšném použití motivu.

Přesunou se jen snímky, které závisely na vybraném hlavním snímku. Snímky přiřazené k jiným hlavním snímkům si zachovají své stávající hlavní snímky a motivy. Barvy, písma, výplně, čáry, pozadí a efekty, které jsou motiv‑svědomé, jsou řešeny vůči externímu motivu. Barvy, písma, výplně a další explicitní formátování přiřazené přímo mohou zůstat nezměněny. Přepsání na úrovni rozložení a snímku může také mít přednost před hodnotami zděděnými z nového hlavního snímku.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí k dispozici. Pro konzistentní vykreslování a export nainstalujte požadovaná písma, poskytujte je prostřednictvím [custom font sources](/slides/cs/php-java/custom-font/), nebo nastavte [font substitution](/slides/cs/php-java/font-substitution/).

Jedná se o přímý pracovní postup na úrovni hlavního snímku: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepisů motivu na úrovni snímku či rozložení.

### **Použít různé externí motivy ve vícehlavém (multi‑master) souboru**

Když není předem znám konkrétní hlavní snímek, získejte jej z reprezentativního snímku pomocí [Slide::getLayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/). Před použitím motivů uložte původní odkazy na hlavní snímky, protože každé volání vytvoří další hlavní snímek v prezentaci.

Následující příklad používá snímky ze dvou sekcí k nalezení jejich hlavních snímků a aplikuje odlišný externí motiv na každou skupinu:

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

První volání ovlivní jen snímky, které závisí na `$firstGroupMaster`, a druhé volání ovlivní jen snímky, které závisí na `$secondGroupMaster`. Snímky patřící k jakémukoli jinému hlavnímu snímku nebudou přeformátovány.

### **Zachovat zdrojový motiv při přesouvání snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový hlavní snímek do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/), poté naklonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) a naklonovaného hlavního snímku. Tím se přenesou hlavní snímek, jeho rozložení i související motiv.

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

Toto je preferovaný pracovní postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nesouvisející cílový hlavní snímek může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Použít hodnoty motivu na existující snímek**

Pokud cílový snímek musí zůstat na svém aktuálním hlavním snímku a rozložení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv použitý tímto snímkem, aniž by se změnil motiv zděděný ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/).

### **Použít přepsání motivu na rozložení**

Přepsání na úrovni rozložení se vztahuje na snímky, které používají dané rozložení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít prostřednictvím [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslidethememanager/):

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

Použijte motiv na úrovni hlavního snímku nebo prezentace, když mají mnoho rozložení a snímků sdílet stejný základní design; přepsání rozložení, když jedna rodina rozložení vyžaduje odlišné stylování; a přepsání snímku jen pro skutečné výjimky. Nadměrné přepsání na úrovni snímku ztěžuje předvídání pozdějších globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Výplně pozadí motivu jsou uloženy v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplňových definic je fyzicky uloženo v této sbírce, protože UI může kombinovat výplně motivu s barvami motivu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí prohlédněte uloženou sbírku a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/). Index stylu `0` znamená žádnou motivovou výplň; kladné hodnoty jsou odkazy na motivové styly pozadí. To se liší od indexování PHP sbírky přímo, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplní pozadí.

Následující příklad nahlásí dostupný počet výplní pozadí, přiřadí motivové pozadí prvnímu hlavnímu snímku a uloží prezentaci:

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

Viditelný výsledek závisí na motivové položce, na kterou odkazuje hlavní snímek, a na případných přepsáních pozadí na úrovni rozložení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze hlavního pozadí nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Varování" %}}
Nevnímejte index stylu jako nulově‑založený index kolekce. Také se vyhněte hardcodování čísla stylu z jednoho souboru a předpokladu, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/php-java/presentation-background/).
{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátu motivu obsahuje samostatné kolekce výplní, čar a efektových stylů, které jsou zpřístupněny přes [FormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají jemnému, střednímu a intenzivnímu formátování, ale kód by měl prohlížet každou sbírku místo předpokladu pevného počtu.

![Jemné, střední a intenzivní efekty motivu aplikované na stejný tvar](presentation-design_10.png)

Když přistupujete k těmto sbírkám v PHP, index kolekce je nulově‑založený: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazů stylu tvaru jsou samostatný koncept, který je zpřístupněn přes [ShapeStyle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapestyle/). Úprava motivového stylu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat beze změny.

Následující příklad zkontroluje, že požadované položky stylu existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím efektovém stylu a výsledek uloží:

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

U tvarů, které odkazují na tyto sloty, se první styl čáry motivu změní na červený, třetí styl výplně motivu se stane plnou lesní zelenou a třetí efektový styl získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, který slot každého tvaru používá a zda přímé formátování nepřepíše motiv.

![Styly efektů motivu po změně nastavení čáry, výplně a stínu](presentation-design_11.png)

## **Čtení efektivních hodnot motivu**

Syrové objekty motivu vám řeknou, co je definováno na konkrétní úrovni. Efektivní hodnoty vám řeknou, co snímek nebo tvar skutečně používá po vyřešení dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/), a pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/).

Následující příklad načte efektivní motiv, pozadí a první výplň tvaru ze snímku:

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud prohlížíte jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), můžete přehlédnout přepsání na úrovni hlavního snímku, rozložení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivní použití externího motivu všechny snímky v prezentaci?**

Ne. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) přidělí pouze snímky, které závisí na vybraném hlavním snímku. Snímky používající jiné hlavní snímky si zachovají své stávající motivy.

**Mohu použít motiv na jediný snímek bez změny hlavního snímku?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky budou nadále dědit své stávající motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho původního vzhledu naklonujte zdrojový hlavní snímek do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/) a naklonujte snímek s tímto hlavním snímkem pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/). Tím se zachová hlavní snímek, rozložení i motiv společně.

**Jak mohu vidět efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseoverridethememanager/) pro motiv snímku nebo rozložení a odpovídající metody pro efektivní data formátovacích objektů, jako jsou [Background.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/). Tyto API vrací vyřešené hodnoty po aplikaci dědičnosti a přepsání.