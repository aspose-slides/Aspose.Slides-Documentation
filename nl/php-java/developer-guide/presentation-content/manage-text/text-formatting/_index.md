---
title: Tekst opmaken in presentaties met PHP
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/php-java/text-formatting/
keywords:
- alinea uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype-eigenschappen
- lettertype-familie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-anker
- tekst-tabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Opmaak en stijl van tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor PHP via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettereigenschappen, rotatie, alinea‑spatiëring, autofit‑gedrag, tekstverankering, tab‑stops en taalinstellingen.

Tenzij anders vermeld, gebruiken de voorbeelden [sample.pptx](sample.pptx). De eerste vorm op de eerste dia is een tekstvak, en de eerste alinea bevat de hieronder getoonde tekst. Zowel dia‑ als vorm‑indices zijn nul‑gebaseerd. Voorbeelden die vette delen selecteren gebruiken effectieve opmaak, inclusief geërfde vetopmaak:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑overeenkomsten te vinden en te markeren, zie [Zoeken en vervangen van tekst](/slides/nl/php-java/search-and-replace-text/).

## **Tekstachtergrondkleur instellen**

Gebruik [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getHighlightColor) voor individuele tekstgedeelten.

Het volgende voorbeeld stelt een lichtgrijze markering in als de standaard voor de eerste alinea. Expliciete markeerkleuren op individuele gedeelten hebben voorrang op deze standaard:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Stel de markeerkleur in voor de volledige alinea.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De grijze alinea](gray_paragraph.png)

De onderstaande code‑voorbeeld toont hoe u de achtergrondkleur voor **tekstgedeelten met een vet lettertype** instelt:

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
            // Stel de markeerkleur in voor het tekstgedeelte.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De grijze tekstgedeelten](gray_text_portions.png)

## **Tekst‑alinea’s uitlijnen**

Gebruik [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment) om de alinea‑uitlijning binnen een tekstvak in te stellen. De waarde kan gecentreerd, links‑gealigneerd, rechts‑gealigneerd, uitgevuld, enzovoort zijn.

Het volgende code‑voorbeeld toont hoe u de alinea naar het **midden** centreert:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Stel de uitlijning van de alinea in op midden.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Lettertypen binnen een regel uitlijnen**

Gebruik [ParagraphFormat::setFontAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setFontAlignment) om tekstgedeelten met verschillende lettergroottes binnen een regel verticaal uit te lijnen. Deze instelling geldt voor de volledige alinea en regelt de uitlijning binnen elke regel daarvan.

Het volgende zelfstandige voorbeeld maakt vier gelabelde tekstvakken op één dia. Elke alinea bevat dezelfde tekst in 18, 36 en 54 punten, met een andere lettertype‑uitlijning. Het gebruikt Arial, schakelt autofit en omslag uit, en houdt de tekstvakken groot genoeg voor één regel.

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

Het resultaat:

![Vergelijking van baseline, top, midden en bodem lettertype‑uitlijning met gemengde lettergroottes](font_alignment.png)

Lettertype‑uitlijning gebruikt lettertype‑metingen, waardoor de zichtbare randen van individuele letters niet noodzakelijk exact op één lijn liggen. Het voorbeeld bevat zowel een hoofdletter als een “descender” om het verschil tussen baseline‑ en bodem‑uitlijning te laten zien. Beschikbaarheid en substitutie van lettertypen, de gebruikte tekens en het verschil in lettergroottes beïnvloeden het resultaat. Frame‑afmetingen, marges, regel‑spatiëring, omslag en autofit beïnvloeden eveneens de lay‑out; gebruik dezelfde lettertypen en lay‑outinstellingen bij het vergelijken van modi.

Deze instelling verschilt van [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setAlignment), die horizontale alinea‑uitlijning regelt, en van [TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType), die het tekstblok verticaal binnen de vorm positioneert. Superscript‑ en subscript‑opmaak via [BasePortionFormat::setEscapement](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setEscapement) verschuift individuele gedeelten ten opzichte van de baseline in plaats van lettertype‑uitlijning voor de regels van de alinea in te stellen.

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die is toegewezen aan [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). In de onderstaande voorbeelden is `alpha = 50` een ARGB‑alfakanaalwaarde op de 0‑255‑schaal, geen transparantie‑percentage.

Het volgende code‑voorbeeld laat zien hoe u transparantie toepast op de **volledige alinea**:

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

    // Stel de vulkleur van de tekst in op een transparante kleur.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De transparante alinea](transparent_paragraph.png)

Het volgende code‑voorbeeld laat zien hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

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
            // Stel de transparantie van het tekstgedeelte in.
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

Het resultaat:

![De transparante tekstgedeelten](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setSpacing) om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen. De voorbeelden voegen 3 punten spacing toe; negatieve waarden verkleinen de tekst.

Het volgende PHP‑code‑voorbeeld laat zien hoe u de tekenafstand in de **volledige alinea** vergroot:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Vergroot de tekenafstand.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De tekenafstand in de alinea](character_spacing_in_paragraph.png)

Het onderstaande code‑voorbeeld laat zien hoe u de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

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
            // Opmerking: Gebruik negatieve waarden om de tekenafstand te verkleinen.
            $portion->getPortionFormat()->setSpacing(3); // Vergroot de tekenafstand.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De tekenafstand in de tekstgedeelten](character_spacing_in_text_portions.png)

### **Kerning voor specifieke lettertypen uitschakelen**

In sommige gevallen kan de door Aspose.Slides gerenderde tekst er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑data voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om het gerenderde resultaat dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) in op een waarde groter dan de werkelijke lettergrootte. Dit voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia. Het controleert effectieve lettertypenamen, inclusief geërfde lettertypen, en stelt een drempel van 100 punten in voor gedeelten die Roboto gebruiken. Hiermee wordt kerning uitgeschakeld voor overeenkomende gedeelten met een lettergrootte onder 100 punten:

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

Voor tekst onder de drempel voorkomt deze instelling kerning en kan het helpen om de weergave van Aspose.Slides beter te laten overeenstemmen met die van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekst‑lettertype‑eigenschappen beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/).

Het volgende voorbeeld stelt het standaardlettertype van de eerste alinea in op Times New Roman 12 pt met vet, cursief en een gestippelde onderstreping. Expliciete opmaak op individuele gedeelten heeft voorrang op deze standaarden.

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

    // Stel de lettertype‑eigenschappen voor de alinea in.
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

Het resultaat:

![De lettertype‑eigenschappen voor de alinea](font_properties_for_paragraph.png)

Het volgende voorbeeld past Times New Roman 13 pt, cursieve opmaak en een gestippelde onderstreping toe op gedeelten waarvan de effectieve opmaak vet is:

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
            // Stel de lettertype‑eigenschappen voor het tekstgedeelte in.
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

Het resultaat:

![De lettertype‑eigenschappen voor tekstgedeelten](font_properties_for_text_portions.png)

## **Normalisatie van tekst‑hoogte regelen**

Gebruik [BasePortionFormat::setNormaliseHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setNormaliseHeight) bij het reproduceren van sjabloon‑typografie of bij het onderzoeken van verschillen in tekenhoogte. In PowerPoint strekt of comprimeert het inschakelen van normalisatie individuele tekens verticaal zodat ze een uniforme zichtbare hoogte hebben binnen het tekstgedeelte. Het garandeert niet gelijke tekst‑hoogten tussen verschillende lettertypen.

Stel de eigenschap in op [NullableBool::True of False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) om normalisatie expliciet in‑ of uit te schakelen. `NullableBool::NotDefined` laat de lokale instelling onveranderd, zodat het gedeelte de waarde erft, bijvoorbeeld van het alinea‑[getDefaultPortionFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat). Het betekent niet `False`. Gebruik [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) en lees `getNormaliseHeight` op de geretourneerde effectieve opmaakgegevens om de geëvalueerde Boole‑waarde te verkrijgen.

Het volgende zelfstandige voorbeeld vereist **Arial** geïnstalleerd. Het maakt twee tekstblokken met dezelfde hoofdletters, kleine letters, “descenders” en geaccentueerde tekens op 54 pt. Beide alinea’s schakelen normalisatie standaard in. Het bovenste gedeelte schakelt het expliciet uit; het onderste gedeelte erft het. De frame‑groottes, marges en alinea‑spatiëring zijn identiek, met omslag en autofit uitgeschakeld om de vergelijking consistent te houden. Het voorbeeld drukt `False: false` en `NotDefined: true` af en slaat “text_height_normalization.pptx” op.

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

De vergelijking hieronder werd geëxporteerd uit de opgeslagen presentatie. De bovenste rij heeft normalisatie uitgeschakeld (`False`); de onderste rij erft de ingeschakelde instelling (`NotDefined` → `True`). Houd Arial geïnstalleerd om dit uiterlijk te reproduceren.

![Arial‑tekst 54 pt met normalisatie uitgeschakeld boven en geërfde normalisatie ingeschakeld onder](text_height_normalization.png)

Normalisatie wijzigt de tekenhoogte zonder de toegewezen [getFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFontHeight)‑waarde te veranderen, die de lettergrootte in punten aangeeft. Alinea‑[setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) regelt regel‑spatiëring, terwijl tekst‑frame‑[setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst of de container zich aanpast. Deze instellingen dienen verschillende doelen en kunnen de totale lay‑out onafhankelijk van elkaar beïnvloeden. Zie voor meer over alinea‑opmaak en overerving [Beheer alinea](/slides/nl/php-java/manage-paragraph/).

## **Doorhalen toepassen en verwijderen**

Gebruik [BasePortionFormat::setStrikethroughType](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setStrikethroughType) op een tekstgedeelte om correcties, geannuleerde termen of vorige prijzen weer te geven zonder de originele tekst te verwijderen. Stel in op [TextStrikethroughType::Single of Double](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/) voor één of twee strepen door de tekst.

Om doorhalen te verwijderen, geef [TextStrikethroughType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#None) door. Hiermee wordt het effect expliciet uitgeschakeld, zelfs als de omringende opmaak doorhalen specificeert. Daarentegen laat [TextStrikethroughType::NotDefined](https://reference.aspose.com/slides/php-java/aspose.slides/textstrikethroughtype/#NotDefined) de lokale instelling ongedefinieerd, waardoor het gedeelte de opmaak kan erven, bijvoorbeeld van de alinea. Het garandeert niet dat doorhalen wordt verwijderd. Gebruik [PortionFormat::getEffective](https://reference.aspose.com/slides/php-java/aspose.slides/portionformat/#getEffective) om de resulterende opmaak, inclusief geërfde waarden, te lezen.

Het volgende zelfstandige voorbeeld maakt drie prijs‑vergelijkingen. Elke alinea heeft afzonderlijke gedeelten voor het label, de oude prijs en de huidige prijs, zodat alleen de oude prijs wordt beïnvloed. De eerste rij past doorhalen toe en verwijdert het vervolgens; de andere rijen behouden respectievelijk enkelvoudig en dubbel doorhalen. Het wijzigen van deze instelling behoudt de tekst en andere opmaak, inclusief de vetgedrukte oude prijs.

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

    // Pas doorhalen toe, en verwijder het vervolgens expliciet van de eerste vorige prijs.
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(0)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::None);

    $paragraphs->get_Item(1)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Single);
    $paragraphs->get_Item(2)->getPortions()->get_Item(1)->getPortionFormat()->setStrikethroughType(TextStrikethroughType::Double);

    $presentation->save("strikethrough.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat, van boven naar beneden: geen doorhalen, enkelvoudig doorhalen en dubbel doorhalen.

![Oude prijzen zonder doorhalen, met enkelvoudig doorhalen en met dubbel doorhalen](strikethrough.png)

## **Tekstrotatie instellen**

Gebruik [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setTextVerticalType) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

Het volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op [TextVerticalType::Vertical270](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/), wat de tekst **90 graden tegen de klok in** roteert:

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

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Cijfers naast elkaar weergeven in verticale tekst**

Om een tweecijferig getal samen te houden in een verticale Japanse label, plaats beide cijfers in één tekstgedeelte en roep [BasePortionFormat::setKumimoji](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setKumimoji) aan op dat gedeelte. Het voorbeeld gebruikt [TextVerticalType::EastAsianVertical](https://reference.aspose.com/slides/php-java/aspose.slides/textverticaltype/#EastAsianVertical) en 40‑punt MS Gothic voor beide labels. Alleen de [NullableBool](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/)‑waarde die aan het numerieke gedeelte wordt doorgegeven, verschilt.

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

In PowerPoint toont het linker label (`True`) de cijfers rechtop en naast elkaar tussen 和 en 年. In het rechter label (`False`) wordt het paar 90 graden met de klok mee geroteerd. De omringende Japanse tekens blijven rechtop in beide labels.

![PowerPoint‑vergelijking van verticale datum‑labels met rechtopstaande cijfers links en geroteerde cijfers rechts.](vertical_date.png)

## **Aangepaste rotatie voor tekst‑frames instellen**

Gebruik [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setRotationAngle) om een aangepaste rotatie‑hoek voor een [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) in te stellen.

Het onderstaande code‑voorbeeld roteert het tekstframe met 3 graden met de klok mee binnen de vorm:

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

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regel‑spatiëring van alinea’s instellen**

Aspose.Slides biedt [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) en [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceWithin) om alinea‑spatiëring te beheren. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om de regel‑spatiëring als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regel‑spatiëring in punten op te geven.

Het volgende voorbeeld stelt de spatiëring binnen de eerste alinea in op 200 % van de regelhoogte (dubbele spatiëring):

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

Het resultaat:

![De regel‑spatiëring binnen de alinea](line_spacing.png)

## **Regelafbreking beheersen**

Alinea‑regelafbrekingsregels zijn handig in smalle tekstblokken en presentaties die Latijnse en Oost‑Aziatische tekst combineren. De volgende methoden behoren tot [ParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/), dus ze gelden voor een volledige alinea:

- [setLatinLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) regelt regels voor Latijnse regelafbreking. In gecombineerde tekst kan het wijzigen hiervan ook de plaats beïnvloeden waar aangrenzende Oost‑Aziatische tekst en interpunctie omslaan.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) regelt regels voor Oost‑Aziatische regelafbreking, inclusief beperkingen voor tekens aan het begin en einde van een regel.

Deze regels vervangen niet [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setWrapText), die automatisch omslag binnen een tekstframe inschakelt. Ze beïnvloeden de lay‑out wanneer omslag plaatsvindt; ze voegen geen regel‑break‑tekens toe. Een expliciete regel‑break dwingt een nieuwe regel binnen de alinea, onafhankelijk van de beschikbare breedte.

Het volgende zelfstandige voorbeeld maakt een smal tekstblok met Chinees en Latijns. Het stelt beide regel‑afbrekingsopties expliciet in en slaat “line_breaking.pptx” op. Om met een van de regels te experimenteren, wijzig de betreffende waarde terwijl u de andere instellingen ongewijzigd laat. Het voorbeeld gebruikt Arial 24 pt en SimSun met een frame‑breedte van 160 pt en horizontale tekst‑frame‑marges op 0. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) wordt aangeroepen met [TextAutofitType::None](https://reference.aspose.com/slides/php-java/aspose.slides/textautofittype/) zodat tekstgrootte en frame‑afmetingen vast blijven.

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

## **Hangende interpunctie beheren**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) laat toegestane interpunctie buiten de rechterrand van de tekstlijn uitsteken in plaats van op de volgende regel te plaatsen. Het geldt voor de volledige alinea en verschilt van een hangende insprong.

Het volgende zelfstandige voorbeeld schakelt hangende interpunctie in een 100‑punt breed tekstframe in en slaat “hanging_punctuation.pptx” op. Met Arial 24 pt en horizontale tekst‑frame‑marges op 0, blijft de eindpunt na “sentence” na het woord staan en steekt buiten de rechterrand uit. Stel de eigenschap in op [NullableBool::False](https://reference.aspose.com/slides/php-java/aspose.slides/nullablebool/) om te vergelijken: met deze instellingen bevindt de punt zich op een aparte regel. Omslag is ingeschakeld en autofit is uitgeschakeld om de beschikbare breedte vast te houden.

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

Niet elk leesteken kan hangen. De [lettertype‑ en lay‑outvoorwaarden beschreven hierboven](#control-line-breaking) gelden ook voor deze vergelijking: wijzig het lettertype, de beschikbare breedte, marges of autofit‑instellingen kan het zichtbare verschil wegnemen.

## **Autofit‑type voor tekst‑frames instellen**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of tekst krimpt, overloopt of de vorm automatisch van grootte wijzigt. Het volgende voorbeeld configureert de vorm om te schalen zodat deze bij de tekst past en slaat het resultaat op als “autofit_type.pptx”.

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

Om het aantal regels na automatisch omslaan te tellen en te zien hoe tekst‑ of vormbreedte het resultaat beïnvloedt, zie [Count Rendered Lines](/slides/nl/php-java/manage-paragraph/). Alleen het aantal regels geeft niet aan of tekst buiten de container overloopt.

## **Anker van tekst‑frames instellen**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/php-java/aspose.slides/textframeformat/#setAnchoringType) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan. Het volgende voorbeeld verankert de tekst aan de onderkant van de eerste vorm en slaat het resultaat op als “text_anchor.pptx”.

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

## **Tab‑instelling voor tekst instellen**

Gebruik [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) en [ParagraphFormat::getTabs](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#getTabs) om tab‑stops in een alinea te configureren. Het volgende voorbeeld stelt de standaard tab‑intervallen in op 100 pt en voegt een links‑gealigneerde tab‑stop toe op 30 pt. Deze instellingen beïnvloeden tekst die tab‑tekens bevat.

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

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Bewijstaal instellen**

Aspose.Slides biedt [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setLanguageId), waarmee u de bewijstaal voor een tekstgedeelte kunt instellen. De bewijstaal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

Het volgende voorbeeld vereist “presentation.pptx” met een tekstvak als eerste vorm op de eerste dia en ten minste één alinea. Het vervangt de inhoud van de eerste alinea door “1。”, stelt SimSun in als lettertype en wijst de vereenvoudigd Chinees‑bewijstaal (`zh-CN`) toe. Het slaat het resultaat op als “proofing_language.pptx”:

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

    // Stel de Id van een bewijstaal in.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Taalkundige metadata kopiëren**

Wanneer u meertalige tekst uit een sjabloon kopieert, behoudt u zowel [BasePortionFormat::getLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getLanguageId) als [BasePortionFormat::getAlternativeLanguageId](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Het volgende zelfstandige voorbeeld maakt een bron‑gedeelte met Amerikaans‑Engels als taal en Frans als alternatieve taal, en kopieert de tekst en identifiers naar een gedeelte in een nieuwe presentatie.

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
    // Als de bron geen alternatieve taal heeft, maakt null de bestemmingswaarde leeg.
    $destination->getPortionFormat()->setAlternativeLanguageId($source->getPortionFormat()->getAlternativeLanguageId());
    $paragraph->getPortions()->add($destination);

    $presentation->save("copied_language_metadata.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Om een bron zonder alternatieve taal te testen, laat de toewijzing van `"fr-FR"` weg. De alternatieve identifier is dan `null`, en dezelfde kopiëringsinstructie behoudt de afwezigheid zonder een standaardwaarde toe te voegen, zelfs als de bestemming eerder een alternatieve taal had.

Deze identifiers bevatten taalkundige metadata. Het behouden ervan bepaalt niet welke woordenlijst PowerPoint kiest voor spelling‑ of grammaticacontrole.

## **Standaardtaal instellen**

Gebruik [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de standaardtaal voor tekst te definiëren die wordt aangemaakt tijdens het laden of maken van een presentatie. Het volgende voorbeeld maakt een presentatie met Amerikaans‑Engels als standaard‑teksttaal, voegt een tekstvak toe en drukt `en-US` af voor het eerste tekstgedeelte.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een nieuw rechthoekig vorm toe met tekst.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Controleer de taal van het eerste gedeelte.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Standaard‑tekststijl instellen**

Om standaard‑tekstopmaak op presentatieniveau toe te passen, gebruik [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Het volgende voorbeeld stelt een 14‑punt vet lettertype in als standaard voor alinea’s op het hoogste niveau in een nieuwe presentatie en slaat deze op als “default_text_style.pptx”. Tekst kan deze standaarden erven tenzij een specifiekere opmaak ze overschrijft.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Haal het alinea‑formaat van het hoogste niveau op.
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

## **Tekst extraheren met het All‑Caps‑effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑fonteffect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo’n tekstgedeelte met Aspose.Slides ophaalt, retourneert de bibliotheek de tekst exact zoals ingevoerd. Om de weergegeven tekst te laten overeenkomen, controleer [TextCapType](https://reference.aspose.com/slides/php-java/aspose.slides/textcaptype/) en zet de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde `All` is.

Dit voorbeeld vereist “sample2.pptx” met een tekstvak als eerste vorm op de eerste dia. Het eerste alinea‑gedeelte bevat “Hello, Aspose!” met het All‑Caps‑effect toegepast, zoals hieronder weergegeven.

![Het All‑Caps‑effect](all_caps_effect.png)

Het onderstaande code‑voorbeeld toont hoe u de tekst met het **All Caps**‑effect kunt extraheren:

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

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe wijzig ik tekst in een tabel op een dia?**

Om tekst in een tabel op een dia te wijzigen, gebruik [Table](https://reference.aspose.com/slides/php-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/cell/#getTextFrame) en alinea‑opmaak via [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Hoe pas ik een kleurverloop toe op tekst in een PowerPoint‑dia?**

Om een kleurverloop op tekst toe te passen, gebruik [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#getFillFormat). Stel [FillFormat::setFillType](https://reference.aspose.com/slides/php-java/aspose.slides/fillformat/#setFillType) in op [FillType::Gradient](https://reference.aspose.com/slides/php-java/aspose.slides/filltype/) en configureer de kleurverloop‑stops, richting en transparantie.