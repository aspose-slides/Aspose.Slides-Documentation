---
title: Formátování textu v prezentaci v PHP
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/php-java/text-formatting/
keywords:
- zvýraznit text
- regulární výraz
- zarovnat odstavec
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otočení
- textový rámec
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámce
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Popisuje zvýrazňování, barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otáčení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V následujících příkladech použijeme soubor pojmenovaný „sample.pptx“, který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvýraznit text**

Použijte metodu [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/)`::highlightText`, když potřebujete zvýraznit text, který odpovídá konkrétnímu vzorku v textovém rámci. Metoda aplikuje barvu zvýraznění na odpovídající úseky textu a lze ji použít spolu s [TextHighlightingOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/texthighlightingoptions/) k řízení způsobu provádění vyhledávání, například pro shodu jen celých slov.

Níže uvedený příklad kódu zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Získat první tvar z první snímky.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Zvýraznit slovo "try" ve tvaru.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Zvýraznit slovo "to" ve tvaru.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/)`::highlightRegex` zvýrazní shody textu nalezené regulárním výrazem.

Níže uvedený příklad kódu zvýrazní všechna slova, která obsahují **sedm nebo více znaků**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Zvýraznit všechna slova se sedmi a více znaky.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Nastavit barvu pozadí textu**

Použijte výchozí formát úseku třídy [ParagraphFormat] k nastavení výchozí barvy zvýraznění odstavce, nebo použijte [PortionFormat] pro jednotlivé úseky textu.

Následující příklad kódu ukazuje, jak nastavit barvu pozadí **celého odstavce**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Nastavit barvu zvýraznění pro celý odstavec.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Následující příklad kódu ukazuje, jak nastavit barvu pozadí **úseků textu s tučným písmem**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nastavit barvu zvýraznění pro úsek textu.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Šedé úseky textu](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte metodu [ParagraphFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/)`::setAlignment` k nastavení zarovnání odstavce v textovém rámu. Hodnota může být centrovaná, zarovnaná doleva, doprava, zarovnaná do bloku a tak dále.

Následující příklad kódu ukazuje, jak zarovnat odstavec na **střed**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Nastavit zarovnání odstavce na střed.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavit průhlednost textu**

Průhlednost textu se řídí pomocí alfa komponentu barvy přiřazené výplňovému formátu [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB v rozsahu 0‑255, nikoli procento průhlednosti.

Níže uvedený příklad kódu ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Nastavit barvu výplně textu na průhlednou barvu.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující příklad kódu ukazuje, jak aplikovat průhlednost na **úseky textu s tučným písmem**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nastavit průhlednost úseku textu.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Průhledné úseky textu](transparent_text_portions.png)

## **Nastavit mezery mezi znaky textu**

Použijte metodu [BasePortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/)`::setSpacing` k rozšíření nebo zúžení mezer mezi znaky v textovém rámečku.

Následující PHP kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Rozšířit mezeru mezi znaky.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Mezery mezi znaky v odstavci](character_spacing_in_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak rozšířit mezery mezi znaky v **úsecích textu s tučným písmem**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
            $portion->getPortionFormat()->setSpacing(3); // Rozšířit mezeru mezi znaky.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Mezery mezi znaky v úsecích textu](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl v takových případech blíže PowerPointu, můžete zakázat kerning pro úseky textu, které používají dotčené písmo. Nastavte metodu [BasePortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` na hodnotu výrazně vyšší než skutečná velikost písma:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Toto nastavení zabraňuje aplikaci kerningu na odpovídající úseky textu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma, na která se tento specifický chování PowerPointu vztahuje.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce prostřednictvím výchozího formátu úseku třídy [ParagraphFormat] nebo na jednotlivých úsecích pomocí [PortionFormat].

Následující kód nastaví písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučné, kurzívu, tečkované podtržení a písmo Times New Roman na všechny úseky v odstavci.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Nastavit vlastnosti písma pro odstavec.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Níže uvedený příklad kódu aplikuje podobné vlastnosti na **úseky textu s tučným písmem**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nastavit vlastnosti písma pro úsek textu.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Vlastnosti písma pro úseky textu](font_properties_for_text_portions.png)

## **Nastavit otáčení textu**

Použijte metodu [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` k nastavení předdefinované orientace textu uvnitř tvaru.

Následující příklad kódu nastaví orientaci textu ve tvaru na `Vertical270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Otáčení textu](text_rotation.png)

## **Nastavit vlastní otáčení pro textové rámečky**

Použijte metodu [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/)`::setRotationAngle` k nastavení vlastního úhlu otáčení pro [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).

Níže uvedený příklad kódu otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Vlastní otáčení textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje metody [ParagraphFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` a `ParagraphFormat::setSpaceWithin` k řízení mezer odstavců. Tyto metody se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad kódu ukazuje, jak specifikovat řádkování v odstavci:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavit typ automatického přizpůsobení pro textové rámečky**

Metoda [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/)`::setAutofitType` určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte ji k řízení, zda se text zmenší, přeteče nebo automaticky změnit velikost tvaru.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavit ukotvení textových rámečků**

Metoda [TextFrameFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/)`::setAnchoringType` určuje, jak je text umístěn vertikálně uvnitř tvaru, například nahoře, uprostřed nebo dole.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavit tabulaci textu**

Použijte metodu [ParagraphFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` a jeho kolekci tabulátorů k nastavení tabulátorů v odstavci.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje metodu [BasePortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/)`::setLanguageId`, která umožňuje nastavit jazyk kontroly pravopisu pro úsek textu. Jazyk kontroly pravopisu určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad kódu ukazuje, jak nastavit jazyk kontroly pravopisu pro úsek textu:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Nastavit ID jazyka pro kontrolu pravopisu.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavit výchozí jazyk**

Použijte metodu [LoadOptions](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` k definování výchozího jazyka pro text vytvořený během načítání nebo vytváření prezentace.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidat nový obdélníkový tvar s textem.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Zkontrolovat jazyk prvního úseku.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Nastavit výchozí styl textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte výchozí styl textu třídy [Presentation](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/).

Následující příklad kódu ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro veškerý text na všech snímcích v nové prezentaci.

```php
$presentation = new Presentation();
try {
    // Získat formát odstavce na nejvyšší úrovni.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Extrahovat text s efektem VELKÝCH PÍSMEN**

V PowerPointu aplikace efekt **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takový úsek textu načtete pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro získání zobrazeného textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textcaptype/) a převádějte vrácený řetězec na velká písmena, když je hodnota `All`.

Předpokládejme, že na první snímku souboru sample2.pptx máme následující textový rámeček.

![Efekt VELKÝCH PÍSMEN](all_caps_effect.png)

Níže uvedený příklad kódu ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/). Projděte buňky a aktualizujte každou buňku prostřednictvím textového rámce [Cell](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/) a formátování odstavců pomocí formátu odstavce [Paragraph](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/)'s paragraph format.

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte výplňový formát [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/). Nastavte typ výplně [FillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/)'s fill type na [FillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) `Gradient` a nakonfigurujte gradientové zastávky, směr a průhlednost.