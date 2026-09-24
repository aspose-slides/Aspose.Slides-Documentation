---
title: Formátování textu prezentace v PHP
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/php-java/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
- textový rámeček
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámečku
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otáčení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V příkladech níže použijeme soubor pojmenovaný "sample.pptx", který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárních výrazů, viz [Vyhledat a nahradit text](/slides/cs/php-java/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) k nastavení výchozí barvy zvýraznění pro odstavec, nebo použijte [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#getHighlightColor) pro jednotlivé textové části.

V následujícím příkladu kódu je ukázáno, jak nastavit barvu pozadí pro **celý odstavec**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Nastavte barvu zvýraznění pro celý odstavec.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Kód níže ukazuje, jak nastavit barvu pozadí pro **textové části s tučným písmem**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nastavte barvu zvýraznění pro textovou část.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Šedé textové části](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setAlignment) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a tak dále.

Následující příklad kódu ukazuje, jak zarovnat odstavec do **středu**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Nastavte zarovnání odstavce na střed.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavit průhlednost textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené pomocí [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#getFillFormat). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB na stupnici 0–255, ne procento průhlednosti.

Kód níže ukazuje, jak použít průhlednost na **celý odstavec**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Nastavte barvu výplně textu na průhlednou barvu.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující příklad kódu ukazuje, jak použít průhlednost na **textové části s tučným písmem**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nastavte průhlednost textové části.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Průhledné textové části](transparent_text_portions.png)

## **Nastavit mezery mezi znaky textu**

Použijte [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setSpacing) k rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Následující PHP kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Poznámka: Pro zmenšení mezery mezi znaky použijte záporné hodnoty.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Zvětšit mezeru mezi znaky.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Kód níže ukazuje, jak rozšířit mezeru mezi znaky v **textových částech s tučným písmem**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Poznámka: Pro zmenšení mezery mezi znaky použijte záporné hodnoty.
            $portion->getPortionFormat()->setSpacing(3); // Zvětšit mezeru mezi znaky.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Mezera mezi znaky v textových částech](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl v takových případech blíže PowerPointu, můžete zakázat kerning pro textové části používající dané písmo. Nastavte [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na hodnotu podstatně větší než skutečná velikost písma:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající textové části a může pomoci slaďovat vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma ovlivněná tímto specifickým chováním PowerPointu.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/portionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučnost, kurzívu, tečkované podtržení a písmo Times New Roman na všechny části odstavce.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Nastavte vlastnosti písma pro odstavec.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Kód níže aplikuje podobné vlastnosti na **textové části s tučným písmem**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Nastavte vlastnosti písma pro textovou část.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Vlastnosti písma pro textové části](font_properties_for_text_portions.png)

## **Nastavit rotaci textu**

Použijte [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setTextVerticalType) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující příklad kódu nastavuje orientaci textu v tvaru na `Vertical270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Rotace textu](text_rotation.png)

## **Nastavit vlastní rotaci pro textové rámečky**

Použijte [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setRotationAngle) k nastavení vlastního úhlu rotace pro [TextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframe/).

Kód níže otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setSpaceBefore) a [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setSpaceWithin) pro řízení mezer odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující příklad kódu ukazuje, jak nastavit řádkování uvnitř odstavce:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text chová, když přesáhne hranice kontejneru. Použijte jej ke kontrole, zda se text zmenšuje, přeteče nebo automaticky mění velikost tvaru.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro spočítání řádků po automatickém zalomení a zjištění, jak se mění šířka textu nebo tvaru, viz [Count Rendered Lines](/slides/cs/php-java/manage-paragraph/). Pouhý počet řádků neukazuje, zda text přesahuje svůj kontejner.

## **Nastavit ukotvení textových rámečků**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textframeformat/#setAnchoringType) definuje, jak je text vertikálně umístěn uvnitř tvaru, např. nahoře, uprostřed nebo dole.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavit tabulaci textu**

Použijte [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) a [ParagraphFormat::getTabs](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraphformat/#getTabs) k nastavení tabulátorů v odstavci.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
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

Aspose.Slides poskytuje [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#setLanguageId), který umožňuje nastavit jazyk kontroly pravopisu pro textovou část. Jazyk kontroly pravopisu určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad kódu ukazuje, jak nastavit jazyk kontroly pravopisu pro textovou část:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Nastavte Id jazyka pro kontrolu pravopisu.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nastavit výchozí jazyk**

Použijte [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/cs/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidejte nový obdélníkový tvar s textem.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Zkontrolujte jazyk první části.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Nastavit výchozí styl textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/cs/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Následující příklad kódu ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro celý text napříč snímky v nové prezentaci.

```php
$presentation = new Presentation();
try {
    // Získat formát odstavce nejvyšší úrovně.
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

## **Extrahovat text s efektem VŠECH SLOV V KAPITÁLECH**

V PowerPointu aplikace fontového efektu **All Caps** (všechna písmena velká) způsobí, že text na snímku bude zobrazen velkými písmeny, i když byl původně zadán malými. Když takovou textovou část získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu s zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/textcaptype/) a převádějte vrácený řetězec na velká písmena, když je hodnota `All`.

Předpokládejme, že na první snímku souboru sample2.pptx máme následující textový rámeček.

![Efekt všech velkých písmen](all_caps_effect.png)

Kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

Aby bylo možné upravit text v tabulce na snímku, použijte [Table](https://reference.aspose.com/slides/cs/php-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell::getTextFrame](https://reference.aspose.com/slides/cs/php-java/aspose.slides/cell/#getTextFrame) a formátování odstavců pomocí [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/cs/php-java/aspose.slides/baseportionformat/#getFillFormat). Nastavte [FillFormat::setFillType](https://reference.aspose.com/slides/cs/php-java/aspose.slides/fillformat/#setFillType) na [FillType::Gradient](https://reference.aspose.com/slides/cs/php-java/aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.