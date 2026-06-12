---
title: Získání efektivních vlastností tvaru z prezentací v PHP
linktitle: Efektivní vlastnosti
type: docs
weight: 50
url: /cs/php-java/shape-effective-properties/
keywords:
- vlastnosti tvaru
- vlastnosti kamery
- světelné zařízení
- zkosený tvar
- textový rámec
- textový styl
- výška písma
- formát výplně
- PowerPoint
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, jak Aspose.Slides pro PHP prostřednictvím Java vypočítává a aplikuje efektivní vlastnosti tvarů pro přesné vykreslení PowerPointu."
---
## **Přehled**

Toto téma vysvětluje rozdíl mezi **lokálními** a **efektivními** vlastnostmi. Lokální hodnoty jsou hodnoty nastavené přímo na konkrétní úrovni formátování, například:

1. Vlastnosti úseku na snímku.
1. Textové styly prototypu tvaru na rozložení nebo hlavním snímku, pokud má úsek textového rámce tvar.
1. Globální nastavení textu v prezentaci.

Lokální hodnoty mohou být na libovolné úrovni definovány nebo vynechány. Když Aspose.Slides potřebuje finální „vypočtené“ formátování, rozpozná řetězec dědičnosti a vrátí **efektivní** hodnoty. Získáte je voláním metody `getEffective` na objektu lokálního formátu.

Následující příklad ukazuje, jak získat efektivní hodnoty. Předpokládá, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) s textovým rámcem a alespoň jedním úsekem.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Data efektivního formátování představují aktuální vypočítané formátování po aplikaci dědičnosti. V aktuální implementaci mohou být některé objekty efektivních dat vrácené metodami, jako je [PortionFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/geteffective/), interně uloženy v cache. Opětovné volání `getEffective` po změně rodičovského nebo zděděného formátování může obnovit data v cache a dříve získaný objekt již nemusí představovat předchozí stav. Pokud potřebujete zachovat efektivní hodnoty pro pozdější použití, zkopírujte požadované vlastnosti, například výšku písma, barvu výplně, styl písma nebo zarovnání, do svého vlastního datového objektu.
{{% /alert %}}

## **Získání efektivních vlastností kamery**

Aspose.Slides umožňuje získat efektivní vlastnosti kamery. Efektivní data vrácená metodou [ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/) obsahují konečné vlastnosti kamery pro [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti kamery. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Získání efektivních vlastností světelného zařízení**

Aspose.Slides umožňuje získat efektivní vlastnosti světelného zařízení. Efektivní data vrácená metodou [ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/) obsahují konečné vlastnosti světelného zařízení pro [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti světelného zařízení. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Získání efektivních vlastností zkoseného tvaru**

Aspose.Slides umožňuje získat efektivní vlastnosti zkosení tvaru. Efektivní data vrácená metodou [ThreeDFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/geteffective/) obsahují konečné vlastnosti reliéfu pro [ThreeDFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/threedformat/).

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti horního zkosení tvaru. Předpokládá, že první tvar na prvním snímku má 3D formátování.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Získání efektivních vlastností textového rámce**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového rámce. Efektivní data vrácená metodou [TextFrameFormat.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/geteffective/) obsahují vlastnosti formátování textového rámce.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti formátování textového rámce. Předpokládá, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) s textovým rámcem.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Získání efektivních vlastností textového stylu**

Pomocí Aspose.Slides můžete získat efektivní vlastnosti textového stylu. Efektivní data vrácená metodou [TextStyle.getEffective](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textstyle/geteffective/) obsahují vlastnosti textového stylu.

Následující ukázkový kód ukazuje, jak získat efektivní vlastnosti textového stylu. Předpokládá, že první tvar na prvním snímku je [AutoShape](https://reference.aspose.com/slides/cs/php-java/aspose.slides/autoshape/) s textovým rámcem.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Získání efektivní hodnoty výšky písma**

Pomocí Aspose.Slides můžete získat efektivní výšku písma. Následující kód demonstruje, jak se efektivní výška písma úseku mění po nastavení lokálních hodnot výšky písma na různých úrovních struktury prezentace.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Získání efektivního formátu výplně pro tabulku**

Pomocí Aspose.Slides můžete získat efektivní formátování výplně pro různé části tabulky. Efektivní data vrácená objekty formátování obsahují vlastnosti [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/). Formátování buňky má vyšší prioritu než formátování řádku, formátování řádku má vyšší prioritu než formátování sloupce a formátování sloupce má vyšší prioritu než formátování celé tabulky.

V důsledku toho jsou pro vykreslení buňky tabulky použity efektivní vlastnosti [CellFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cellformat/). Následující ukázkový kód ukazuje, jak získat efektivní formátování výplně pro různé části tabulky. Předpokládá, že první tvar na prvním snímku je [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **Často kladené otázky**

**Vrací `getEffective` snímek?**

Ne vždy. Data efektivního formátování představují vypočítané formátování po aplikaci dědičnosti, ale některé objekty mohou být interně uloženy v cache. Následující volání `getEffective` může formátování přepočítat a aktualizovat cache, takže dříve získaný objekt by neměl být považován za trvalý snímek.

**Kdy bych měl znovu načíst efektivní vlastnosti?**

Zavolejte `getEffective` znovu po změně lokálního formátování, rodičovských stylů, formátování rozložení, formátování hlavního snímku nebo výchozích nastavení na úrovni prezentace. Další volání znovu vyhodnotí hierarchii formátování a vrátí aktuální efektivní výsledek.

**Ovlivní změna nebo odebrání rozložení/hlavního snímku efektivní vlastnosti, které už byly získány?**

Ano, ale změna se projeví až při dalším volání `getEffective`. Pokud se změní nebo odstraní zdroj rodičovského formátování, dříve získaná efektivní data mohou být zastaralá. Po opětovném volání `getEffective` Aspose.Slides znovu vyhodnotí strom formátování a výsledná písma, barvy, velikosti nebo jiné hodnoty se mohou změnit.

**Mohu měnit hodnoty pomocí objektů efektivních dat?**

Ne. Objekty efektivních dat pouze poskytují vypočtené hodnoty. Proveďte změny v lokálních objektech formátování a poté znovu získáte efektivní hodnoty.

**Co se stane, když není vlastnost nastavena na úrovni tvaru, ani v rozložení/hlavním snímku, ani v globálním nastavení?**

Efektivní hodnota je určena výchozím mechanismem, který zahrnuje výchozí nastavení PowerPointu a Aspose.Slides. Tato vyřešená hodnota se stane součástí aktuálních efektivních dat.

**Z efektivní hodnoty písma mohu zjistit, na které úrovni byla velikost nebo typ písma zadán?**

Není to přímo možné. Efektivní data vracejí konečnou hodnotu. Pro zjištění zdroje prohlédněte lokální hodnoty v úseku, odstavci, textovém rámci a textových stylech na úrovni rozložení, hlavního snímku a prezentace, abyste zjistili, kde se objevila první explicitní definice.

**Proč se efektivní hodnoty někdy shodují s lokálními?**

Protože lokální hodnota se ukázala jako konečná (nebylo potřeba vyšší úrovně dědičnosti). V takových případech se efektivní hodnota shoduje s lokální.

**Kdy bych měl používat efektivní vlastnosti a kdy pracovat pouze s lokálními?**

Používejte efektivní data, když potřebujete výsledek „jak je vykresleno“ po aplikaci celé dědičnosti, například pro zarovnání barev, odsazení nebo velikostí. Pokud potřebujete tyto hodnoty zachovat bez ohledu na pozdější změny formátování, zkopírujte požadované vlastnosti do vlastního objektu. Pokud chcete změnit formátování na konkrétní úrovni, upravte lokální vlastnosti a následně, pokud je to nutné, znovu načtěte efektivní data k ověření výsledku.