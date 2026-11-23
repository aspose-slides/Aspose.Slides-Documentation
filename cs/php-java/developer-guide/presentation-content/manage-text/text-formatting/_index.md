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
- rozestup znaků
- vlastnosti písma
- rodina písma
- otáčení textu
- úhel otáčení
- textový rám
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámu
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro PHP přes Java. Pokrývá barvy pozadí, průhlednost, rozestupy znaků, vlastnosti písma, rotaci, odstupy odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Vyhledat a nahradit text](/slides/cs/php-java/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) pro jednotlivé části textu.

Následující příklad nastavuje světle šedé zvýraznění jako výchozí pro první odstavec. Výslovné barvy zvýraznění u jednotlivých částí mají přednost před tímto výchozím nastavením:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Nastavit barvu zvýraznění pro celý odstavec.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedený ukázkový kód demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
        // Nastavit barvu zvýraznění pro část textu.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) k nastavení zarovnání odstavce v textovém rámci. Hodnota může být centrovaná, zarovnaná vlevo, zarovnaná vpravo, do bloku atd.

Následující ukázkový kód ukazuje, jak zarovnat odstavec na **střed**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
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

## **Zarovnat písma v řádku**

Použijte [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) k vertikálnímu zarovnání částí textu s různými velikostmi písma v řádku. Toto nastavení platí pro celý odstavec a řídí zarovnání v každém jeho řádku.

Následující samostatný příklad vytváří čtyři popsaná textová pole na jednom snímku. Každý odstavec obsahuje stejný text ve velikostech 18, 36 a 54 bodů s odlišným zarovnáním písma. Používá Arial, zakazuje automatické přizpůsobení a zalamování a udržuje textové rámy dostatečně velké pro jeden řádek.

```php
use aspose\slides\FillType;
use aspose\slides\FontAlignment;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $alignments = [FontAlignment::Baseline, FontAlignment::Top, FontAlignment::Center, FontAlignment::Bottom];
    $alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    $fontSizes = [18, 36, 54];
    $font = new FontData("Arial");
    $gray = java("java.awt.Color")->GRAY;
    $black = java("java.awt.Color")->BLACK;

    for ($i = 0; $i < count($alignments); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 20 + $i * 130, 660, 120);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);

        $label = $textFrame->getParagraphs()->get_Item(0);
        $label->setText($alignmentNames[$i]);
        $label->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setFontHeight(14);
        $label->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $label->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($gray);

        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setFontAlignment($alignments[$i]);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setLatinFont($font);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);

        foreach ($fontSizes as $fontSize) {
            $portion = new Portion("Ag ");
            $portion->getPortionFormat()->setFontHeight($fontSize);
            $paragraph->getPortions()->add($portion);
        }

        $textFrame->getParagraphs()->add($paragraph);
    }

    $presentation->save("font_alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Porovnání zarovnání písma na základní linii, nahoře, uprostřed a dole při smíšených velikostech písma](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné hrany jednotlivých znaků se nemusí přesně shodovat. Příklad zahrnuje jak velké písmeno, tak spádový znak, aby ukázal rozdíl mezi zarovnáním na základní linii a dole. Dostupnost a náhrada písma, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámu, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů použijte stejná písma a nastavení rozvržení.

Toto nastavení se liší od [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), které řídí horizontální zarovnání odstavce, a od [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), které vertikálně umisťuje textový blok uvnitř tvaru. Formátování horního a dolního indexu pomocí [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) posouvá jednotlivé části relativně k základní linii místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu je řízena alfa komponentou barvy přiřazené [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB v rozsahu 0–255, nikoli procento průhlednosti.

Níže uvedený ukázkový kód ukazuje, jak použít průhlednost na **celý odstavec**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Nastavit barvu výplně textu na průhlednou barvu.
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

Následující ukázkový kód ukazuje, jak použít průhlednost na **části textu s tučným písmem**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Nastavit průhlednost části textu.
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

![Průhledné části textu](transparent_text_portions.png)

## **Nastavit rozestup znaků v textu**

Použijte [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) k rozšíření nebo zmenšení rozestupu mezi znaky v textovém poli. Příklady přidávají 3 body rozestupu; záporné hodnoty text zmenšují.

Následující PHP kód ukazuje, jak rozšířit rozestup znaků v **celém odstavci**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Poznámka: Použijte záporné hodnoty ke zmenšení rozestupu znaků.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Rozšířit rozestup znaků.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Rozestup znaků v odstavci](character_spacing_in_paragraph.png)

Níže uvedený ukázkový kód ukazuje, jak rozšířit rozestup znaků v **částech textu s tučným písmem**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Poznámka: Použijte záporné hodnoty ke zmenšení rozestupu znaků.
            $portion->getPortionFormat()->setSpacing(3); // Rozšířit rozestup znaků.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek:

![Rozestup znaků v částech textu](character_spacing_in_text_portions.png)

### **Zakázat kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. To může nastat, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby bylo vykreslené výstupní zobrazení podobnější PowerPointu, můžete zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na hodnotu větší než skutečná velikost písma. Tento příklad vyžaduje soubor „presentation.pptx“ s textovým polem jako prvním tvarem na první snímku. Kontroluje efektivní názvy písem, včetně zděděných, a nastavuje práh 100 bodů pro části používající Roboto. To zakáže kerning pro odpovídající části s velikostí písma pod 100 bodů:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro písma ovlivněná tímto specifickým chováním PowerPointu.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) nebo na jednotlivých částech pomocí [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

Následující příklad nastavuje výchozí písmo prvního odstavce na Times New Roman 12 bodů s tučným, kurzívovým a tečkovaným podtržením. Výslovné formátování jednotlivých částí má přednost před těmito výchozími hodnotami.

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Nastavit vlastnosti písma pro odstavec.
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

Následující příklad aplikuje Times New Roman 13 bodů, kurzívové formátování a tečkované podtržení na části, jejichž efektivní formátování je tučné:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Nastavit vlastnosti písma pro část textu.
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

![Vlastnosti písma pro části textu](font_properties_for_text_portions.png)

## **Ovládání normalizace výšky textu**

Použijte [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) při reprodukci typografie šablony nebo zkoumání rozdílů ve výšce znaků. V PowerPointu povolení normalizace protahuje nebo stlačuje jednotlivé znaky vertikálně, aby měly jednotnou viditelnou výšku v rámci textové části. Není zaručena stejná výška textu napříč různými písmy.

Nastavte vlastnost na [NullableBool::True nebo False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) pro explicitní povolení nebo zakázání normalizace. `NullableBool::NotDefined` ponechává místní nastavení nevyplněné, takže část dědí hodnotu, například z [getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) odstavce. To neznamená `False`. Použijte [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) a přečtěte `getNormaliseHeight` v vrácených efektivních formátovacích datech, abyste získali vyřešenou Boolovskou hodnotu.

Následující samostatný příklad vyžaduje nainstalované **Arial**. Vytvoří dva textové bloky obsahující stejná velká písmena, malá písmena, spádové znaky a diakritiku ve velikosti 54 bodů. Oba odstavce mají ve výchozím nastavení povolenou normalizaci. Horní část ji explicitně zakazuje; spodní část ji dědí. Velikosti rámců, okraje a odstavy odstavců jsou identické, s vypnutým zalamováním a automatickým přizpůsobením, aby zůstala srovnání konzistentní. Příklad vypíše `False: false` a `NotDefined: true` a poté uloží „text_height_normalization.pptx“.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAnchorType;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $settings = [NullableBool::False, NullableBool::NotDefined];
    $settingNames = ["False", "NotDefined"];

    for ($i = 0; $i < count($settings); $i++) {
        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 60 + $i * 200, 660, 150);
        $shape->getFillFormat()->setFillType(FillType::NoFill);
        $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $textFrame = $shape->getTextFrame();
        $textFrame->setText("Hxgjpq ÅÉ 0123");
        $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
        $textFrame->getTextFrameFormat()->setWrapText(NullableBool::False);
        $textFrame->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $textFrame->getTextFrameFormat()->setMarginTop(0);
        $textFrame->getTextFrameFormat()->setMarginLeft(0);

        $paragraph = $textFrame->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $paragraph->getParagraphFormat()->setSpaceWithin(100);
        $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setNormaliseHeight(NullableBool::True);

        $portion = $paragraph->getPortions()->get_Item(0);
        $font = new FontData("Arial");
        $portion->getPortionFormat()->setLatinFont($font);
        $portion->getPortionFormat()->setFontHeight(54);
        $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($black);
        $portion->getPortionFormat()->setNormaliseHeight($settings[$i]);

        $normaliseHeight = java_values($portion->getPortionFormat()->getEffective()->getNormaliseHeight());
        echo $settingNames[$i], ": ", $normaliseHeight ? "true" : "false", PHP_EOL;
    }

    $presentation->save("text_height_normalization.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Porovnání níže bylo exportováno ze uložené prezentace. Horní řada má normalizaci vypnutou (`False`); spodní řada dědí zapnuté nastavení (`NotDefined` → `True`). Pro reprodukci vzhledu ponechte nainstalované Arial.

![Text Arial 54 bodů s vypnutou normalizací nahoře a zděděnou zapnutou normalizací dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by měnila přiřazenou hodnotu [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight), která udává velikost písma v bodech. Odstavec [setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) řídí řádkování, zatímco [setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) řídí, jak se text nebo jeho kontejner přizpůsobuje tak, aby se vešel. Tato nastavení slouží různým účelům a mohou nezávisle ovlivnit celkové rozvržení. Více o formátování odstavců a dědičnosti naleznete v [Spravovat odstavec](/slides/cs/php-java/manage-paragraph/).

## **Použít a odstranit přeškrtnutí**

Použijte [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) na část textu k zobrazení oprav, zrušených výrazů nebo původních cen bez smazání původního textu. Nastavte ji na [TextStrikethroughType::Single nebo Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí předávejte [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None). Tím se efekt explicitně zakáže, i když okolní formátování určuje přeškrtnutí. Naopak [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) nechává místní nastavení nedefinované, což umožňuje části zdědit formátování, například z odstavce. To nezaručuje, že přeškrtnutí bude odstraněno. Použijte [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) k přečtení výsledného formátování, včetně zděděných hodnot.

Následující samostatný příklad vytváří tři srovnání cen. Každý odstavec má samostatné části pro popisek, původní cenu a aktuální cenu, takže je ovlivněna pouze původní cena. V první řadě se přeškrtnutí použije a pak odstraní; ostatní řady zachovávají jednoduché a dvojité přeškrtnutí. Změna tohoto nastavení zachovává text a jeho další formátování, včetně tučné původní ceny.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Paragraph;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextStrikethroughType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 620, 220);
    $shape->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
    $shape->getTextFrame()->getParagraphs()->clear();

    $labels = [ "None: ", "Single: ", "Double: " ];

    foreach ($labels as $label) {
        $paragraph = new Paragraph();
        $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Left);
        $paragraph->getParagraphFormat()->setSpaceAfter(20);

        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $format->setFontHeight(28);
        $font = new FontData("Arial");
        $format->setLatinFont($font);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $blackColor = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($blackColor);

        $labelPortion = new Portion($label);
        $paragraph->getPortions()->add($labelPortion);

        $previousPrice = new Portion("$100");
        $previousPrice->getPortionFormat()->setFontBold(NullableBool::True);
        $paragraph->getPortions()->add($previousPrice);
        $currentPrice = new Portion(" → $80");
        $paragraph->getPortions()->add($currentPrice);

        $shape->getTextFrame()->getParagraphs()->add($paragraph);
    }

    $paragraphs = $shape->getTextFrame()->getParagraphs();

    // Použít přeškrtnutí, pak jej explicitně odstranit z první předchozí ceny.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Výsledek, shora dolů: bez přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Předchozí ceny bez přeškrtnutí, s jedním přeškrtnutím a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavit rotaci textu**

Použijte [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

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

## **Zobrazit číslice vedle sebe ve vertikálním textu**

Aby byl dvouciferný údaj v japonském vertikálním popisku udržet pohromadě, vložte obě číslice do jedné textové části a zavolejte [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) na tuto část. Příklad používá [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) a 40‑bodové MS Gothic pro oba popisky. Pouze hodnota [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) předaná číselné části se liší.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextVerticalType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 120;

    foreach ([NullableBool::True, NullableBool::False] as $kumimoji) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 48, 120, 420);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        $frame = $label->addTextFrame("");
        $frame->getTextFrameFormat()->setTextVerticalType(TextVerticalType::EastAsianVertical);

        $paragraph = $frame->getParagraphs()->get_Item(0);
        $format = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $font = new FontData("MS Gothic");
        $format->setLatinFont($font);
        $format->setEastAsianFont($font);
        $format->setFontHeight(40);
        $format->getFillFormat()->setFillType(FillType::Solid);
        $black = java("java.awt.Color")->BLACK;
        $format->getFillFormat()->getSolidFillColor()->setColor($black);

        $digits = new Portion("12");
        $digits->getPortionFormat()->setKumimoji($kumimoji);

        $portions = $paragraph->getPortions();
        $portions->clear();
        $portions->add(new Portion("令和"));
        $portions->add($digits);
        $portions->add(new Portion("年"));

        $x += 240;
    }
    $presentation->save("vertical_date.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

V PowerPointu levý popisek (`True`) zobrazuje číslice svisle a vedle sebe mezi 和 a 年. Pravý popisek (`False`) otáčí dvojici o 90 stupňů po směru hodinových ručiček. Obklopující japonské znaky zůstávají svislé v obou popiscích.

![Porovnání vertikálních datumových štítků v PowerPointu s svislými číslicemi vlevo a otočenými číslicemi vpravo](vertical_date.png)

## **Nastavit vlastní rotaci pro textové rámce**

Použijte [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) k nastavení vlastní úhlu rotace pro [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/).

Níže uvedený ukázkový kód otáčí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

Aspose.Slides poskytuje [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) a [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) k řízení odstupů odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procento výšky řádku.  
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad nastavuje rozestup uvnitř prvního odstavce na 200 % výšky řádku (dvojité řádkování):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Ovládání zalamování řádků**

Pravidla zalamování řádku odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinské a východoasijské texty. Následující metody patří do [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), takže se aplikují na celý odstavec:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) řídí pravidla zalamování latinského textu. Ve smíšeném textu změna může také změnit, kde se zalamují sousední východoasijské znaky a interpunkce.  
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) řídí pravidla zalamování východoasijského textu, včetně omezení pro znaky na začátku a konci řádku.

Tato pravidla nenahrazují [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), které umožňuje automatické zalamování v textovém rámci. Ovlivňují rozvržení, když k zalamování dochází; nevkládají znaky konce řádku. Explicitní konec řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytváří úzký textový blok obsahující čínštinu a latinku. Explicitně nastaví obě možnosti zalamování a uloží „line_breaking.pptx“. Pro experimentování s libovolným pravidlem změňte odpovídající hodnotu při zachování ostatních nastavení. Příklad používá 24‑bodové Arial a SimSun s šířkou rámu 160 bodů a nulovými horizontálními okraji textového rámu. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) je voláno s [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/), aby velikost textu a rozměry rámu zůstaly pevné.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ovládání zavěšené interpunkce**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) umožňuje oprávněné interpunkci vystoupit za pravý okraj textového řádku místo aby zabírala následující řádek. Používá se pro celý odstavec a liší se od zavěšeného odsazení.

Následující samostatný příklad povoluje zavěšenou interpunkci v 100‑bodovém širokém textovém rámci a uloží „hanging_punctuation.pptx“. S 24‑bodovým Arial a nulovými horizontálními okraji textového rámu zůstává poslední tečka po slově „sentence“ a přesahuje pravý okraj textu. Nastavte vlastnost na [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) pro porovnání: s tímto nastavením tečka zabírá samostatný řádek. Zalamování je povoleno a automatické přizpůsobení je zakázáno, aby byla šířka pevná.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Ne každá interpunkční značka může zavěsit. [Podmínky písma a rozvržení popsané výše](#control-line-breaking) se také vztahují na toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může odstranit viditelný rozdíl.

## **Nastavit typ automatického přizpůsobení pro textové rámce**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přetéká nebo automaticky mění velikost tvaru. Následující příklad konfiguruje tvar tak, aby se změnil tak, aby text pasoval, a uloží výsledek do „autofit_type.pptx“.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak změna šířky textu nebo tvaru výsledek ovlivní, viz [Počítání vykreslených řádků](/slides/cs/php-java/manage-paragraph/). Pouze počet řádků neurčuje, zda text přesahuje svůj kontejner.

## **Nastavit kotev textových rámců**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke dnu prvního tvaru a uloží výsledek do „text_anchor.pptx“.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

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

Použijte [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) a [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) k nastavení tabulátorů v odstavci. Následující příklad nastavuje výchozí interval tabulátoru na 100 bodů a přidává levý zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

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

Aspose.Slides poskytuje [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), který umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje soubor „presentation.pptx“ s textovým polem jako prvním tvarem na první snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce textem „1。」“, nastaví písmo SimSun a přiřadí jazyk kontroly zjednodušené čínštiny (`zh-CN`). Uloží výsledek do „proofing_language.pptx“:

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

    // Nastavit Id jazykové kontroly.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Kopírovat jazyková metadata**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId), tak [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Následující samostatný příklad vytváří zdrojovou část s US English jako jejím jazykem a French jako alternativním jazykem a kopíruje text a identifikátory do části v nové prezentaci.

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$source = new Portion("Hello! Bonjour!");
$source->getPortionFormat()->setLanguageId("en-US");
$source->getPortionFormat()->setAlternativeLanguageId("fr-FR");

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 400, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $destination = new Portion();
    $destination->setText($source->getText());
    $destination->getPortionFormat()->setLanguageId($source->getPortionFormat()->getLanguageId());
    // Pokud zdroj nemá alternativní jazyk, null vymaže hodnotu v cíli.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení „fr-FR“. Alternativní identifikátor bude pak `null` a stejný příkaz kopírování zachová jeho nepřítomnost bez zavedení výchozí hodnoty, i když cílový objekt dříve měl alternativní jazyk nastaven.

Tyto identifikátory jsou uloženy jako jazyková metadata. Jejich zachování neurčuje, který slovník PowerPoint vybere pro kontrolu pravopisu nebo gramatiky.

## **Nastavit výchozí jazyk**

Použijte [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) k definování výchozího jazyka pro text vytvářený při načítání nebo tvorbě prezentace. Následující příklad vytváří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vypíše `en-US` pro jeho první část textu.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Přidat nový obdélníkový tvar s textem.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Zkontrolovat jazyk první části.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Nastavit výchozí styl textu**

Pro aplikaci výchozího formátování textu na úrovni prezentace použijte [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Následující příklad nastavuje 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a ukládá ji jako „default_text_style.pptx“. Text může tato výchozí nastavení dědit, pokud není přepsáno konkrétnějším formátováním.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

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

## **Extrahovat text s efektem VŠECH KAPITÁLEK**

V PowerPointu aplikace efekt **All Caps** (všechny kapitálky) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takovou část textu získáte pomocí Aspose.Slides, knihovna vrací text přesně tak, jak byl zadán. Pro získání zobrazeného textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) a převádějte vrácený řetězec na velká písmena, pokud je hodnota `All`.

Tento příklad vyžaduje soubor „sample2.pptx“ s textovým polem jako prvním tvarem na první snímku. První část prvního odstavce obsahuje „Hello, Aspose!“ s aplikovaným efektem VŠECH KAPITÁLEK, jak je znázorněno níže.

![Efekt VŠECH KAPITÁLEK](all_caps_effect.png)

Níže uvedený ukázkový kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

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

## **FAQ**

**Jak mohu upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Procházejte buňky a aktualizujte každou buňku pomocí [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) a formátování odstavců pomocí [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak mohu použít gradientovou barvu na text na snímku PowerPoint?**

Pro aplikaci gradientové barvy na text použijte [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Nastavte [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) na [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) a nakonfigurujte gradientové zastávky, směr a průhlednost.