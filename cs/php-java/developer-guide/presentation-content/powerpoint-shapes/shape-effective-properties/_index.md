---
title: Získání efektivních vlastností tvaru z prezentací v PHP
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/php-java/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelná výbava
- zkosený tvar
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Naučte se používat Aspose.Slides pro PHP přes Java k rozlišení lokálního, zděděného a efektivního formátování tvarů v prezentacích PowerPoint."
---
## **Pochopte lokální, zděděné a efektivní vlastnosti**

Formátování PowerPointu může pocházet z několika míst. Hodnota uložená přímo na objektu je jeho **lokální hodnota**. Pokud tato hodnota není nastavena, PowerPoint se podívá na zdroje formátování nadřazené, jako je výchozí nastavení odstavce, textový styl, rozvržení nebo hlavní snímek, motiv nebo výchozí nastavení na úrovni prezentace. Tyto hodnoty jsou **zděděné hodnoty**. Hodnota, která zůstane po vyřešení celé hierarchie, je **efektivní hodnota** — hodnota použitá k vykreslení objektu.

Například část textu nemusí definovat vlastní výšku písma. Její lokální hodnota [getFontHeight](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/) je pak `NAN`, což znamená „není zde nastavena.“ Část může zdědit výšku ze svého odstavce, výchozího textového stylu prezentace nebo jiného relevantního zdroje. Voláním [getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/geteffective/) na formát části se vrátí finální vypočtená výška.

Používejte dva typy formátovacích dat pro různé účely:

- Číst nebo měnit lokální formátovací objekt, například [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/), když potřebujete kontrolovat, kde je hodnota definována.
- Číst objekt efektivních dat, například [data vrácená metodou PortionFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/geteffective/), když potřebujete finální, vykreslený výsledek. Efektivní data jsou jen pro čtení.

Před spuštěním příkladů [nainstalujte Aspose.Slides pro PHP přes Java](/slides/cs/php-java/installation/).

## **Porovnejte lokální, zděděné a efektivní hodnoty**

Následující kompletní příklad vytvoří tvar a aplikuje výšky písma na úrovních prezentace, odstavce a části. Každý krok vypíše hodnoty definované na těchto úrovních a výslednou efektivní hodnotu pro stejnou část textu. Také ukazuje, proč je potřeba po změnách formátování znovu načíst efektivní data.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

function formatLocalValue($value)
{
    return $value === null || is_nan($value) ? "<not set>" : (string)$value;
}

function printFontHeights($caption, $presentation, $paragraph, $portion)
{
    $presentationValue = java_values($presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->getFontHeight());
    $paragraphValue = java_values($paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFontHeight());
    $localValue = java_values($portion->getPortionFormat()->getFontHeight());

    // Přečtěte efektivní data po předchozích změnách.
    $effectiveValue = java_values($portion->getPortionFormat()->getEffective()->getFontHeight());

    echo $caption . PHP_EOL;
    echo "  Presentation default: " . formatLocalValue($presentationValue) . PHP_EOL;
    echo "  Paragraph default:    " . formatLocalValue($paragraphValue) . PHP_EOL;
    echo "  Portion local:        " . formatLocalValue($localValue) . PHP_EOL;
    echo "  Portion effective:    " . $effectiveValue . PHP_EOL;
}

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 500, 80, false);
    $textFrame = $shape->addTextFrame("Effective formatting");
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    // Definujte zděděné hodnoty na dvou různých úrovních.
    $presentation->getDefaultTextStyle()->getLevel(0)->getDefaultPortionFormat()->setFontHeight(20);
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(28);

    printFontHeights("The portion inherits from the paragraph", $presentation, $paragraph, $portion);

    // Lokální hodnota v části přepíše obě zděděné hodnoty.
    $portion->getPortionFormat()->setFontHeight(36);
    printFontHeights("A local value overrides inherited values", $presentation, $paragraph, $portion);

    // Změna zděděné hodnoty nepřepíše existující lokální hodnotu.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(30);
    printFontHeights("The local value still has priority", $presentation, $paragraph, $portion);

    // Vymažte lokální hodnotu. Část nyní opět zdědí hodnotu z odstavce.
    $portion->getPortionFormat()->setFontHeight(NAN);
    printFontHeights("The local value is cleared", $presentation, $paragraph, $portion);

    // Vymažte hodnotu odstavce. Výchozí hodnota prezentace nyní poskytuje výsledek.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(NAN);
    printFontHeights("The paragraph value is cleared", $presentation, $paragraph, $portion);

    $presentation->save("effective-properties.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Priorita v tomto příkladu je lokální formátování části, pak formátování odstavce a nakonec výchozí nastavení prezentace. Ostatní objekty mohou mít jiné řetězce dědičnosti, ale princip je stejný: konkrétnější explicitní hodnota vítězí a [getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/geteffective/) vrací finální výsledek.

## **Získání efektivních textových vlastností**

Formátování textu je rozděleno mezi několik objektů:

- [TextFrameFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/geteffective/) určuje vlastnosti textového rámce, jako jsou okraje, ukotvení, automatické přizpůsobení a svislý směr textu.
- [TextStyle.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textstyle/geteffective/) určuje formátování odstavce pro každou úroveň textového stylu.
- [ParagraphFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/geteffective/) určuje vlastnosti odstavce, jako jsou zarovnání, odsazení a odrážky.
- [PortionFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/geteffective/) určuje vlastnosti znaků, jako jsou výška písma, typ písma, barva, tučné a kurzíva.

Pro následující příklad musí soubor `text-formatting.pptx` obsahovat alespoň jeden snímek a jeden [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) s nepřázdným textovým rámcem. AutoShape může být kdekoliv v kolekci tvarů; kód vyhledá vhodný objekt a před použitím jej ověří.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    if ($value === null) {
        return "<not set>";
    }
    if (is_bool($value)) {
        return $value ? "true" : "false";
    }
    return (string)$value;
}

function hasNonEmptyText($shape)
{
    $textFrame = $shape->getTextFrame();
    if (java_is_null($textFrame)) {
        return false;
    }
    if (java_values($textFrame->getParagraphs()->getCount()) === 0) {
        return false;
    }
    return java_values($textFrame->getParagraphs()->get_Item(0)->getPortions()->getCount()) > 0;
}

function findAutoShapeWithText($slide)
{
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $candidate = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($candidate, $autoShapeClass) && hasNonEmptyText($candidate)) {
            return $candidate;
        }
    }
    return null;
}

$presentation = new Presentation("text-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $shape = findAutoShapeWithText($presentation->getSlides()->get_Item(0));
    if ($shape === null) {
        throw new RuntimeException("The first slide must contain an AutoShape with non-empty text.");
    }

    $textFrame = $shape->getTextFrame();
    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $textFrameEffective = $textFrame->getTextFrameFormat()->getEffective();
    $paragraphEffective = $paragraph->getParagraphFormat()->getEffective();
    $portionEffective = $portion->getPortionFormat()->getEffective();

    echo "Text frame margins:" . PHP_EOL;
    echo "  Left: " . formatEffectiveValue($textFrameEffective->getMarginLeft()) . PHP_EOL;
    echo "  Top: " . formatEffectiveValue($textFrameEffective->getMarginTop()) . PHP_EOL;
    echo "  Right: " . formatEffectiveValue($textFrameEffective->getMarginRight()) . PHP_EOL;
    echo "  Bottom: " . formatEffectiveValue($textFrameEffective->getMarginBottom()) . PHP_EOL;
    echo "Paragraph alignment: " . formatEffectiveValue($paragraphEffective->getAlignment()) . PHP_EOL;
    echo "Font height: " . formatEffectiveValue($portionEffective->getFontHeight()) . PHP_EOL;
    echo "Bold: " . formatEffectiveValue($portionEffective->getFontBold()) . PHP_EOL;

    $effectiveTextStyle = $textFrame->getTextFrameFormat()->getTextStyle()->getEffective();
    for ($level = 0; $level < 9; $level++) {
        $levelEffective = $effectiveTextStyle->getLevel($level);
        echo "Level " . $level . " indent: " . formatEffectiveValue($levelEffective->getIndent()) . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Získání efektivních 3D vlastností**

[ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/) vrací jeden objekt efektivních dat, který seskupuje všechna vyřešená 3D nastavení. Jeho metody [getCamera](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/), [getLightRig](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/), [getBevelTop](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/) a [getBevelBottom](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/) vystavují odpovídající efektivní data. Čtení těchto souvisejících nastavení dohromady usnadňuje pochopení finálního 3D vzhledu tvaru.

Pro tento příklad musí soubor `shape-3d.pptx` obsahovat alespoň jeden tvar na první snímku. Pokud chcete, aby výstup obsahoval hodnoty jiných než výchozí, aplikujte na tento tvar 3D kameru, osvětlení nebo nastavení zkosení.

```php
use aspose\slides\Presentation;

function formatEffectiveValue($javaValue)
{
    $value = java_values($javaValue);
    return $value === null ? "<not set>" : (string)$value;
}

$presentation = new Presentation("shape-3d.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0 || java_values($presentation->getSlides()->get_Item(0)->getShapes()->size()) === 0) {
        throw new RuntimeException("The first slide must contain a shape.");
    }

    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $threeDEffective = $shape->getThreeDFormat()->getEffective();

    echo "Camera:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getCamera()->getCameraType()) . PHP_EOL;
    echo "  Field of view: " . formatEffectiveValue($threeDEffective->getCamera()->getFieldOfViewAngle()) . PHP_EOL;
    echo "  Zoom: " . formatEffectiveValue($threeDEffective->getCamera()->getZoom()) . PHP_EOL;

    echo "Light rig:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getLightRig()->getLightType()) . PHP_EOL;
    echo "  Direction: " . formatEffectiveValue($threeDEffective->getLightRig()->getDirection()) . PHP_EOL;

    echo "Top bevel:" . PHP_EOL;
    echo "  Type: " . formatEffectiveValue($threeDEffective->getBevelTop()->getBevelType()) . PHP_EOL;
    echo "  Width: " . formatEffectiveValue($threeDEffective->getBevelTop()->getWidth()) . PHP_EOL;
    echo "  Height: " . formatEffectiveValue($threeDEffective->getBevelTop()->getHeight()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Získání efektivního formátování tabulky**

Formátování tabulky může pocházet ze stylu tabulky a z formátů aplikovaných na celou tabulku, sloupec, řádek nebo jednotlivou buňku. V případě konfliktů mezi explicitně definovanými výplněmi je prioritou buňka, řádek, sloupec a pak celá tabulka. Efektivní formát buňky je finální formát použité k vykreslení této buňky.

Pro tento příklad musí soubor `table-formatting.pptx` obsahovat alespoň jednu tabulku na první snímku. Tabulka musí mít alespoň jeden řádek a jeden sloupec. Kód hledá [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/) místo předpokladu, že `getShapes()->get_Item(0)` je tabulka.

```php
use aspose\slides\Presentation;

function findTable($slide)
{
    $tableClass = new JavaClass("com.aspose.slides.Table");
    $shapeCount = java_values($slide->getShapes()->size());
    for ($shapeIndex = 0; $shapeIndex < $shapeCount; $shapeIndex++) {
        $shape = $slide->getShapes()->get_Item($shapeIndex);
        if (java_instanceof($shape, $tableClass)) {
            return $shape;
        }
    }
    return null;
}

$presentation = new Presentation("table-formatting.pptx");
try {
    if (java_values($presentation->getSlides()->size()) === 0) {
        throw new RuntimeException("The presentation contains no slides.");
    }

    $table = findTable($presentation->getSlides()->get_Item(0));
    if ($table === null) {
        throw new RuntimeException("The first slide must contain a table.");
    }
    if (java_values($table->getRows()->size()) === 0 || java_values($table->getColumns()->size()) === 0) {
        throw new RuntimeException("The table must contain at least one cell.");
    }

    $tableEffective = $table->getTableFormat()->getEffective();
    $rowEffective = $table->getRows()->get_Item(0)->getRowFormat()->getEffective();
    $columnEffective = $table->getColumns()->get_Item(0)->getColumnFormat()->getEffective();
    $cellEffective = $table->get_Item(0, 0)->getCellFormat()->getEffective();

    echo "Table fill: " . java_values($tableEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Row fill: " . java_values($rowEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Column fill: " . java_values($columnEffective->getFillFormat()->getFillType()) . PHP_EOL;
    echo "Final cell fill: " . java_values($cellEffective->getFillFormat()->getFillType()) . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

Pokud potřebujete barvu místo jen typu výplně, nejprve zkontrolujte efektivní hodnotu [getFillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/geteffective/), a potom použijte metodu odpovídající tomuto typu — například [getSolidFillColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/geteffective/) pro plnou výplň.

## **Znovu načtěte efektivní data po změnách**

Efektivní data popisují hierarchii formátování v okamžiku, kdy jsou vyřešena. Zavolejte `getEffective` znovu po změně čehokoliv, co může být součástí této hierarchie, včetně:

- lokálního formátování objektu;
- výchozích nastavení odstavce nebo textového rámce;
- stylu tabulky, tabulky, sloupce, řádku nebo formátu buňky;
- formátování rozvržení nebo hlavního snímku;
- dat motivu nebo výchozích nastavení na úrovni prezentace;
- rozvržení nebo hlavního snímku přiřazeného ke snímku.

Neponechávejte objekt efektivních dat jako trvalý snímek. Aspose.Slides může vnitřně kešovat některá efektivní data a pozdější volání `getEffective` může tato data aktualizovat. Pokud potřebujete porovnat hodnoty před a po změně, zkopírujte požadované skalární hodnoty — například výšku písma, barvu, zarovnání nebo šířku zkosení — do vlastních proměnných před provedením změny.

Pro změnu hodnoty aktualizujte příslušný lokální formátovací objekt a poté zavolejte `getEffective` k ověření výsledku. Objektů efektivních dat jsou samy o sobě jen pro čtení.

## **FAQ**

**Jak mohu zjistit, která úroveň poskytla efektivní hodnotu?**

Efektivní data obsahují finální hodnotu, nikoli její zdroj. Prozkoumejte příslušné lokální objekty od nejspecifičtější úrovně směrem ven. Pro text to může zahrnovat část, odstavec, textový rámec, rozvržení, hlavní snímek, motiv a výchozí nastavení prezentace. Nedefinované hodnoty jako `NAN` nebo `null` signalizují, že hledání pokračuje na další úrovni.

**Co se stane, když žádná úroveň nenastaví vlastnost?**

Aspose.Slides určuje odpovídající výchozí hodnotu PowerPointu nebo knihovny. Tato vyřešená hodnota se objeví v efektivních datech, i když ji žádný lokální objekt explicitně nedefinuje.

**Proč se někdy efektivní hodnota rovná lokální hodnotě?**

Lokální hodnota vyhrála výpočet dědičnosti. To je očekávané, když je vlastnost explicitně nastavena na objektu a žádné specifičtější pravidlo ji nepřepíše.

**Kdy bych měl použít lokální data místo efektivních dat?**

Používejte lokální data k prohlížení nebo úpravě konkrétní úrovně formátování. Používejte efektivní data, když potřebujete finální vzhled po aplikaci dědičnosti, pravidel motivu a příslušných stylů. [Kompletní příklad porovnání](#compare-local-inherited-and-effective-values) ukazuje oba přístupy ve stejném postupu.