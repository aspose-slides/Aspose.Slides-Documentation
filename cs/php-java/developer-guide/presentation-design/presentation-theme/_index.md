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
- Dodatečná paleta
- Písmo motivu
- Styl motivu
- Efekt motivu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Hlavní motivy prezentací v Aspose.Slides pro PHP přes Javu pro vytváření, přizpůsobení a převod souborů PowerPoint se sjednoceným brandováním."
---
## **Úvod**

Motiv prezentace definuje koordinovaný soubor barev, písem, stylů pozadí, výplní, čar a efektů. Objekty, které jsou motivem‑vědomé, odkazují na tyto sdílené definice místo ukládání každé vizuální vlastnosti jako pevné hodnoty, takže změna motivu může najednou aktualizovat mnoho objektů.

V Aspose.Slides je motiv na úrovni prezentace dostupný přes [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/). Prezentace může také obsahovat přepsání motivu na nižších úrovních. Master může přepsat motiv prezentace přes [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterthememanager/), zatímco rozvržení nebo jednotlivý snímek může přepsat zděděný motiv přes [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseoverridethememanager/). V práci je efektivní motiv pro snímek vyřešen pomocí tohoto řetězce dědičnosti: motiv prezentace → přepsání masterem → přepsání rozvržením → přepsání snímkem.

![Motivní komponenty: barvy, písma, styly pozadí a efekty](theme-constituents.png)

Níže uvedené sekce ukazují nejčastější pracovní postupy s motivem: kontrola motivu, změna barev a písem, kopírování nebo použití motivu, aktualizace stylů pozadí a efektů a čtení efektivních hodnot po vyřešení dědičnosti a přepsání.

## **Kontrola motivu**

Objekt [MasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/) zpřístupňuje schéma barev motivu, schéma písem a schéma formátů přes [MasterTheme.getColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/) a [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/mastertheme/). Kontrola těchto kolekcí před jejich změnou je obzvláště užitečná, když prezentace pochází z externího zdroje, protože počet a obsah položek stylů se může lišit.

Následující příklad načte hlavní vlastnosti motivu a vypíše, kolik stylů pozadí, výplní, čar a efektů je v motivu uloženo:

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

Pokud soubor používá více masterů, nepředpokládejte, že každý snímek má stejný efektivní motiv. Zkontrolujte master přiřazený ke snímku a použijte pracovní postup „efektivní motiv“, který je ukázán později v tomto článku, pokud mohou být přítomna přepsání rozvržení nebo snímku.

## **Změna barev motivu**

Motivně‑vědomé výplně, čáry a text mohou odkazovat na logickou barvu ze seznamu [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/schemecolor/). Když změníte odpovídající položku v [ColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorscheme/), všechny objekty, které stále odkazují na tuto barvu motivu, jsou aktualizovány na novou hodnotu. Objektům, které používají přímou RGB barvu, se změna motivové barvy neprojeví.

Následující end‑to‑end příklad vytvoří tvar používající `Accent4`, změní barvu motivu `Accent4` na červenou, uloží prezentaci, znovu ji otevře a vytiskne efektivní barvu výplně:

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

Protože obdélník zůstává propojen s `Accent4`, jeho viditelná barva se po změně motivu stane červenou. Pokud nahradíte barvu motivu přímou barvou na tvaru, pozdější změny `Accent4` již tento výplň neovlivní.

### **Použití barev z dodatečné palety**

PowerPoint vytváří světlejší a tmavší varianty z barvy motivu aplikací barevných transformací. Aspose.Slides zpřístupňuje tyto transformace přes výčet [ColorTransformOperation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colortransformoperation/).

![Hlavní barvy motivu a světlejší a tmavší barvy vytvořené z dodatečné palety](additional-palette-colors.png)

**1** – Hlavní barvy motivu.  
**2** – Světlejší a tmavší varianty vytvořené z hlavních barev motivu.

Následující příklad vytvoří šest obdélníků založených na `Accent4`, na pět z nich aplikuje luminanční transformace a výsledek uloží:

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

Výčet [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/schemecolor/) používá `Text1`, `Background1`, `Text2` a `Background2`, zatímco [ColorScheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorscheme/) zpřístupňuje stejné sloty motivu jako `Dark1`, `Light1`, `Dark2` a `Light2`. Mapování je pevné:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Jedná se o alternativní názvy pro stejné sloty motivu; nejsou to hodnoty dynamicky konvertované z jedné podoby do druhé.

## **Změna písem motivu**

Schéma písem motivu obsahuje hlavní sadu písem pro nadpisy a méně důležitou sadu pro tělo textu. Metody [FontScheme.getMajor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/) a [FontScheme.getMinor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fontscheme/) tato písma zpřístupňují.

Identifikátory písem kompatibilních s PowerPointem lze použít ve formátování textu:

* `+mn‑lt` – tělo písmo Latin (Minor Latin Font)
* `+mj‑lt` – nadpis písmo Latin (Major Latin Font)
* `+mn‑ea` – tělo písmo East Asian (Minor East Asian Font)
* `+mj‑ea` – nadpis písmo East Asian (Major East Asian Font)

Následující příklad vytvoří jeden nadpis používající hlavní latinské písmo motivu a jeden řádek těla používající méně důležité latinské písmo motivu. Pak změní písma motivu a výsledek uloží:

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

Nadpis používá hlavní písmo a tělo textu používá menší písmo. Text, který má explicitně nastavený název písma místo motivového identifikátoru, se při změně schématu písem automaticky nepřepne.

Hlavní a méně důležité kolekce písem mohou také obsahovat mapování písem pro jednotlivé psané systémy, např. cyriliku, arabštinu, japonštinu, gruzínštinu a thaana. Pro kontrolu, přidání, nahrazení nebo odebrání těchto mapování viz [Script‑Specific Theme Fonts](/slides/cs/php-java/script-specific-font-mappings/).

{{% alert color="info" title="Tip" %}}

Pro více informací o písmenech v prezentacích viz [PowerPoint Fonts](/slides/cs/php-java/powerpoint-fonts/).

{{% /alert %}}

## **Kopírování nebo použití motivu**

Níže uvedené pracovní postupy řeší různé problémy související s motivem.

### **Použití externího motivu na snímky závislé na masteru**

Použijte [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) při práci se souborem motivu PowerPoint (`.thmx`) a chcete přeformátovat každý snímek, který závisí na konkrétním masteru. Vyberte master z kolekce [Presentation::getMasters](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), která je představována třídou [MasterSlideCollection](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/), a předávejte cestu k souboru motivu metodě.

Metoda provádí následující operace:

1. Vytvoří nový master‑snímek založený na vybraném masteru.  
2. Aplikuje externí motiv na nový master.  
3. Přiřadí nový master všem snímkům, které dříve závisely na vybraném masteru.  
4. Vrátí nově vytvořený [MasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/).

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

Neplatný, poškozený nebo nepodporovaný motiv může vyvolat [PptxReadException](https://reference.aspose.com/slides/cs/php-java/aspose.slides/pptxreadexception/). Validujte cesty zadané uživateli, ošetřete selhání přístupu k filesystému a uložte prezentaci až po úspěšném použití motivu.

Přesunou se jen snímky, které závisely na vybraném masteru. Snímky spojené s jinými mastery si ponechají své stávající mastery a motivy. Barvy, písma, výplně, čáry, pozadí a efekty motiv‑vědomé se vyřeší vůči externímu motivu. Přímě přiřazené barvy, písma, výplně a další explicitní formátování mohou zůstat nezměněny. Přepsání na úrovni rozvržení a snímku může také mít přednost před hodnotami zděděnými z nového masteru.

Motiv může odkazovat na písma, která nejsou v běhovém prostředí k dispozici. Pro konzistentní vykreslování a export nainstalujte potřebná písma, poskytněte je přes [custom font sources](/slides/cs/php-java/custom-font/), nebo nakonfigurujte [font substitution](/slides/cs/php-java/font-substitution/).

Jedná se o přímý pracovní postup na úrovni masteru: metoda přijímá cestu k souboru `.thmx` a nevyžaduje ruční vytváření přepsání motivu na úrovni snímku nebo rozvržení.

### **Použití různých externích motivů v prezentaci s více mastery**

Když není předem známo, který master je relevantní, získejte jej z reprezentativního snímku přes [Slide::getLayoutSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slide/) a [LayoutSlide::getMasterSlide](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslide/). Uložte původní odkazy na mastery před aplikací jakýchkoli motivů, protože každý volání vytvoří další master v prezentaci.

Následující příklad použije snímky ze dvou sekcí k nalezení jejich masterů a aplikuje odlišný externí motiv na každou skupinu:

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

První volání ovlivní jen snímky, které závisí na `$firstGroupMaster`, a druhé volání jen snímky, které závisí na `$secondGroupMaster`. Snímky patřící k jinému masteru nebudou přeformátovány.

### **Zachování zdrojového motivu při přesunu snímků**

Pokud chcete přesunout snímek do jiné prezentace a zachovat jeho původní design, naklonujte zdrojový master do cílové prezentace pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/), poté naklonujte snímek pomocí [SlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/) a naklonovaného masteru. Tím se přenese master, jeho rozvržení a přidružený motiv.

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

Jedná se o preferovaný postup, když musí zdrojový snímek v cíli vypadat stejně. Pouhé klonování obsahu na nezávislý cílový master může změnit barvy, písma, pozadí a efekty řízené motivem.

### **Aplikace hodnot motivu na existující snímek**

Pokud musí cílový snímek zůstat na svém aktuálním masteru a rozvržení, inicializujte přepsání na úrovni snímku ze zdrojového motivu. Metody [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/) a [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/) zkopírují tři hlavní komponenty motivu do přepsání.

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

Tím se změní motiv použitého snímku bez ovlivnění motivu zděděného ostatními snímky. Pro odebrání lokálního přepsání a návrat k zděděným hodnotám zavolejte [OverrideTheme.clear](https://reference.aspose.com/slides/cs/php-java/aspose.slides/overridetheme/).

### **Aplikace přepsání motivu na rozvržení**

Přepsání na úrovni rozvržení se vztahuje na snímky, které používají toto rozvržení, pokud konkrétní snímek nemá vlastní přepsání. Stejné inicializační metody lze použít přes [LayoutSlideThemeManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/layoutslidethememanager/):

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

Použijte motiv na úrovni masteru nebo prezentace, když má mnoho rozvržení a snímků sdílet stejný základní design, přepsání rozvržení, když jedna rodina rozvržení potřebuje odlišné stylování, a přepsání snímku jen pro skutečné výjimky. Nadměrná přepsání na úrovni snímku ztěžují předvídání následných globálních změn motivu.

## **Aktualizace stylů pozadí motivu**

Styl výplní pozadí motivu je uložen v [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/). PowerPoint může v uživatelském rozhraní nabídnout více možností pozadí, než kolik výplní je fyzicky uloženo v této kolekci, protože UI může kombinovat výplně motivu s barvami motivu a dalšími odkazy na styly.

![Galerie stylů pozadí PowerPointu pro motiv prezentace](presentation-design_8.png)

Před použitím stylu pozadí zkontrolujte uloženou kolekci a aktuální [Background.getStyleIndex](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/). Index stylu `0` znamená žádnou motivovou výplň; kladné hodnoty jsou odkazy na motivové styly pozadí. To se liší od indexování PHP kolekce přímo, kde `get_Item(0)` označuje první uloženou položku. Nepředpokládejte, že každá prezentace obsahuje stejný počet stylů výplně pozadí.

Následující příklad vypíše počet dostupných výplní pozadí, přiřadí motivový odkaz na pozadí prvému masteru a uloží prezentaci:

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

Viditelný výsledek závisí na motivové položce, na kterou odkazuje master, a na případných přepsáních pozadí na úrovni rozvržení nebo snímku. Pokud snímek používá vlastní pozadí, změna pouze pozadí masteru nemusí tento snímek změnit. Použijte [Background.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/) když potřebujete znát finální pozadí po aplikaci dědičnosti.

{{% alert color="warning" title="Warning" %}}

Nevnímejte index stylu jako nulově‑založený index kolekce. Také se vyhněte hard‑codování čísla stylu z jednoho souboru a předpokládání, že bude mít stejný vzhled v jiném souboru; definice stylů motivu jsou specifické pro prezentaci.

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

Pro přímé formátování pozadí a dědičnost pozadí viz [Presentation Background](/slides/cs/php-java/presentation-background/).

{{% /alert %}}

## **Aktualizace efektů motivu**

Schéma formátů motivu obsahuje samostatné kolekce výplní, čar a efektů, které jsou zpřístupněny přes [FormatScheme.getFillStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/) a [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/cs/php-java/aspose.slides/formatscheme/). Typické kancelářské motivy často obsahují tři hlavní položky stylu, které vizuálně odpovídají subtilnímu, střednímu a intenzivnímu formátování, ale kód by měl kontrolovat každou kolekci místo předpokládání pevného počtu položek.

![Subtilní, střední a intenzivní motivové efekty použité na stejném tvaru](presentation-design_10.png)

Při přístupu k těmto kolekcím v PHP je index kolekce nulově‑založený: `get_Item(0)` je první uložený styl a `get_Item(2)` je třetí. Indexy odkazující na styl tvaru jsou samostatný koncept, zpřístupněný přes [ShapeStyle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/shapestyle/). Úprava motivového stylu ovlivní tvary, které na tento styl odkazují; tvary s přímým formátováním mohou zůstat nezměněny.

Následující příklad ověří, že požadované položky stylů existují, změní první styl čáry, změní třetí styl výplně, povolí vnější stín ve třetím stylu efektu a výsledek uloží:

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

Pro tvary, které tyto sloty používají, se první motivová čára stane červenou, třetí motivová výplň se změní na plně zelenou (forest green) a třetí efekt získá vnější stín s vzdáleností 10 bodů. Přesný vizuální výsledek stále závisí na tom, který slot stylu každá figura odkazuje a zda přímé formátování nepřepisuje motiv.

![Styly motivových efektů po změně čáry, výplně a nastavení stínu](presentation-design_11.png)

## **Zjištění, zda efektivní plná výplň používá barvu motivu**

Výplň může být uložena přímo na objektu nebo zděděna z odstavce, rozvržení, masteru, motivového stylu nebo jiné úrovně formátování. Zavolejte [FillFormat::getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/) pro rozpuštění této hierarchie do neměnných efektivních dat výplně. Nejprve zkontrolujte výsledek `getFillType`. Pouze když je `FillType::Solid`, čtěte vlastnosti plné výplně.

Pro plnou výplň `getSolidFillColor` vrací finální vykreslenou RGB hodnotu po dědičnosti, vyhledání v motivě a aplikaci barevných transformací. Metoda `getSolidFillSchemeColor` vrací odpovídající logický slot [SchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/schemecolor/), např. `Text1` nebo `Accent6`. Hodnota `SchemeColor::NotDefined` znamená, že efektivní plná výplň není založena na schematické barvě. Ve workflow, kde jsou výplně buď motivové barvy nebo přímé RGB barvy, tato hodnota identifikuje přímou RGB výplň.

Neproměňujte místní hodnotu [ColorFormat::getSchemeColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/colorformat/) pro klasifikaci výplně. Např. část textu může mít lokálně nedefinovanou schematickou barvu (`NotDefined`), zatímco její efektivní výplň zdědí motivovou barvu a rozepne se na `Text1` nebo `Accent6`. Naopak `getSolidFillSchemeColor` říká, která logická motivová položka vytvořila efektivní barvu, ale neříká, z které úrovně (objekt, odstavec, rozvržení, master nebo jiná) pochází.

Následující příklad načte prezentaci, provede audit výplní tvarů i výplní částí textu, vytiskne každou finální RGB hodnotu a přidruženou schematickou barvu a označí plné výplně, které nebudou sledovat změny motivových barev:

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

Větev `NotDefined` poskytuje seznam plných výplní, které nebudou reagovat na změny slotů motivových barev. Přezkoumejte tyto objekty, když prezentace musí odpovídat novému brandovému paletě. Hlášená RGB hodnota stále ukazuje aktuální vzhled, zatímco hodnota schematu vysvětluje, zda je tento vzhled spojen s motivem.

Objekty s efektivním formátem jsou snímky okamžiku. Po změně motivu prezentace, přepsání motivu nebo jakéhokoli zděděného formátování znovu zavolejte `getEffective` a načtěte nová data výplně před porovnáním nebo hlášením barev.

## **Čtení efektivních hodnot motivu**

Surové objekty motivu říkají, co je definováno na konkrétní úrovni. Efektivní hodnoty říkají, co snímek nebo tvar skutečně používá po rozpuštění dědičnosti a lokálních přepsání. Pro snímek zavolejte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseoverridethememanager/). Pro pozadí použijte [Background.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/), pro výplň [FillFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/).

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

Používejte efektivní data pro diagnostiku vykreslování, validaci a porovnání. Pokud kontrolujete jen [Presentation.getMasterTheme](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/), můžete přehlédnout přepsání na úrovni masteru, rozvržení, snímku nebo tvaru, které mění finální vzhled.

## **Často kladené otázky**

**Ovlivňuje použití externího motivu všechny snímky v prezentaci?**

Ne. [MasterSlide::applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslide/) přidělí změnu jen snímkům, které závisí na vybraném masteru. Snímky používající jiné mastery si ponechají své stávající motivy.

**Mohu aplikovat motiv na jediný snímek bez změny masteru?**

Ano. Použijte [SlideThemeManager](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidethememanager/) snímku a inicializujte jeho přepsání motivu. Změna zůstane lokální pro tento snímek; ostatní snímky nadále dědí své existující motivy.

**Jaký je nejbezpečnější způsob, jak přenést motiv z jedné prezentace do druhé?**

Při přesunu snímku a zachování jeho zdrojového vzhledu naklonujte zdrojový master do cíle a naklonujte snímek s tímto masterem pomocí [MasterSlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/masterslidecollection/) a [SlideCollection.addClone](https://reference.aspose.com/slides/cs/php-java/aspose.slides/slidecollection/). Tím se zachová master, rozvržení i motiv společně.

**Jak mohu zobrazit efektivní hodnoty po dědičnosti a přepsání?**

Použijte [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseoverridethememanager/) pro motiv snímku nebo rozvržení a odpovídající efektivní‑data metody pro formátové objekty, např. [Background.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/background/) a [FillFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/). Tyto API vracejí rozpuštěné hodnoty po aplikaci dědičnosti a přepsání.