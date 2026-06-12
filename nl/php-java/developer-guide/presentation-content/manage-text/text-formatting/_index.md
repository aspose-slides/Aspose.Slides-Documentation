---
title: Tekst opmaken in presentaties met PHP
linktitle: Tekstopmaak
type: docs
weight: 50
url: /nl/php-java/text-formatting/
keywords:
- tekst markeren
- reguliere expressie
- paragraaf uitlijnen
- tekststijl
- tekstachtergrond
- teksttransparantie
- tekenafstand
- lettertype-eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatiehoek
- tekstframe
- regelafstand
- autofit-eigenschap
- tekstframe-anker
- teksttabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Formateer en styleer tekst in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor PHP via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel laat zien hoe je tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor PHP via Java. Het behandelt markeringen, achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekstverankering, tabstops en taalinstellingen.

In de voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkel tekstvak op de eerste dia bevat met de volgende tekst:

![Sample text](sample_text.png)

## **Tekst markeren**

Gebruik de [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/)`::highlightText`‑methode wanneer je tekst wilt markeren die overeenkomt met een specifiek voorbeeld binnen een tekstvak. De methode past een markeerkleur toe op overeenkomende tekstfragmenten en kan worden gebruikt met [TextHighlightingOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/texthighlightingoptions/) om te bepalen hoe de zoekopdracht wordt uitgevoerd, bijvoorbeeld om alleen volledige woorden te matchen.

De code‑voorbeeld hieronder markeert alle voorkomens van de tekens **"try"** en markeert vervolgens alleen het volledige woord **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Haal de eerste vorm van de eerste dia op.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Markeer het woord "try" in de vorm.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Markeer het woord "to" in de vorm.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The highlighted text](highlighted_text.png)

## **Tekst markeren met reguliere expressies**

De [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/)`::highlightRegex`‑methode markeert tekstfragmenten die door een reguliere expressie worden gevonden.

De code‑voorbeeld hieronder markeert alle woorden die **zeven of meer tekens** bevatten:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Markeer alle woorden met zeven of meer tekens.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Achtergrondkleur voor tekst instellen**

Gebruik de standaard‑portion‑format van [ParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/) voor individuele tekstporties.

De volgende code‑voorbeeld laat zien hoe je de achtergrondkleur voor de **hele alinea** instelt:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Stel de markeerkleur in voor de hele alinea.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The gray paragraph](gray_paragraph.png)

De code‑voorbeeld hieronder laat zien hoe je de achtergrondkleur instelt voor **tekstporties met een vet lettertype**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Stel de markeerkleur in voor de tekstportie.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The gray text portions](gray_text_portions.png)

## **Tekst alinea's uitlijnen**

Gebruik de [ParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/)`::setAlignment`‑methode om de alinea‑uitlijning binnen een tekstvak in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

De volgende code‑voorbeeld laat zien hoe je de alinea naar het **midden** uitlijnt:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Stel de uitlijning van de alinea in op midden.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The aligned paragraph](aligned_paragraph.png)

## **Transparantie voor tekst instellen**

Transparantie van tekst wordt geregeld via het alfa‑component van de kleur die aan het invulformaat van [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/) is toegewezen. In de voorbeelden hieronder is `alpha = 50` een ARGB‑alfa‑kanaalwaarde op de 0‑255‑schaal, geen transparantie‑percentage.

De code‑voorbeeld hieronder toont hoe je transparantie toepast op de **hele alinea**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Stel de vulkleur van de tekst in op een transparante kleur.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The transparent paragraph](transparent_paragraph.png)

De volgende code‑voorbeeld toont hoe je transparantie toepast op **tekstporties met een vet lettertype**:

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
            // Stel de transparantie van de tekstportie in.
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

Het resultaat:

![The transparent text portions](transparent_text_portions.png)

## **Tekenafstand voor tekst instellen**

Gebruik de [BasePortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/)`::setSpacing`‑methode om de afstand tussen tekens in een tekstvak uit te breiden of te verkleinen.

De volgende PHP‑code toont hoe je de tekenafstand in de **hele alinea** vergroot:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Opmerking: Gebruik negatieve waarden om de tekenafstand te comprimeren.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Vergroot de tekenafstand.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

De code‑voorbeeld hieronder toont hoe je de tekenafstand vergroot in **tekstporties met een vet lettertype**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Opmerking: Gebruik negatieve waarden om de tekenafstand te comprimeren.
            $portion->getPortionFormat()->setSpacing(3); // Vergroot de tekenafstand.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning uitschakelen voor specifieke lettertypen**

In sommige gevallen kan de door Aspose.Slides gerenderde tekst er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te laten komen, kun je kerning uitschakelen voor tekstporties die het desbetreffende lettertype gebruiken. Stel de [BasePortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize`‑methode in op een waarde die aanzienlijk groter is dan de werkelijke lettergrootte:

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

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstporties en kan helpen om de weergave van Aspose.Slides af te stemmen op de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Lettertype‑eigenschappen van tekst beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via het standaard‑portion‑formaat van [ParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/) of op individuele porties via [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de volledige alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het Times New Roman‑lettertype toe op alle porties in de alinea.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Stel de lettertype‑eigenschappen in voor de alinea.
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

Het resultaat:

![The font properties for the paragraph](font_properties_for_paragraph.png)

De code‑voorbeeld hieronder past vergelijkbare eigenschappen toe op **tekstporties met een vet lettertype**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Stel de lettertype‑eigenschappen in voor de tekstportie.
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

Het resultaat:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Tekstrotatie instellen**

Gebruik de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)`::setTextVerticalType`‑methode om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

De volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op `Vertical270`, waardoor de tekst **90 graden tegen de klok in** wordt gedraaid:

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

Het resultaat:

![The text rotation](text_rotation.png)

## **Aangepaste rotatie voor tekstframes instellen**

Gebruik de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)`::setRotationAngle`‑methode om een aangepaste rotatiehoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).

De code‑voorbeeld hieronder draait het tekstframe 3 graden met de klok mee binnen de vorm:

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

Het resultaat:

![The custom text rotation](custom_text_rotation.png)

## **Regelafstand van alinea's instellen**

Aspose.Slides biedt de methoden [ParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` en `ParagraphFormat::setSpaceWithin` om de alinea‑afstand te regelen. Deze methoden worden als volgt gebruikt:

* Gebruik een positieve waarde om de regelafstand als percentage van de regelhoogte op te geven.
* Gebruik een negatieve waarde om de regelafstand in punten op te geven.

De volgende code‑voorbeeld toont hoe je de regelafstand binnen de alinea specificeert:

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

Het resultaat:

![The line spacing within the paragraph](line_spacing.png)

## **Autofit‑type voor tekstframes instellen**

De [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)`::setAutofitType`‑methode bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik deze om te bepalen of de tekst krimpt, overlapt of de vorm automatisch vergroot.

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

## **Anker van tekstframes instellen**

De [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/)`::setAnchoringType`‑methode bepaalt hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, midden of onderaan.

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

## **Tabulatie voor tekst instellen**

Gebruik de [ParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize`‑methode en de tab‑verzameling om tabstops in een alinea te configureren.

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

Het resultaat:

![The paragraph tabs](paragraph_tabs.png)

## **Controlerende taal instellen**

Aspose.Slides biedt de [BasePortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/)`::setLanguageId`‑methode, waarmee je de controlerende taal voor een tekstportie kunt instellen. De controlerende taal bepaalt welke taal wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende code‑voorbeeld toont hoe je de controlerende taal voor een tekstportie instelt:

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

    // Stel de ID van een controletaal in.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Standaardtaal instellen**

Gebruik de [LoadOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage`‑methode om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of maken van een presentatie.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een nieuwe rechthoekvorm met tekst toe.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Controleer de taal van de eerste tekstportie.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Standaard tekststijl instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik je de standaard‑tekststijl van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/).

De volgende code‑voorbeeld laat zien hoe je een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia's in een nieuwe presentatie.

```php
$presentation = new Presentation();
try {
    // Haal het alineaformaat van het hoogste niveau op.
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

## **Tekst met All‑Caps‑effect extraheren**

In PowerPoint zorgt het toepassen van het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters op de dia verschijnt, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer je een dergelijke tekstportie ophaalt met Aspose.Slides, retourneert de bibliotheek de tekst exact zoals deze is ingevoerd. Om de weergegeven tekst te matchen, controleer je [TextCapType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textcaptype/) en converteer je de geretourneerde tekenreeks naar hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak hebben op de eerste dia van het bestand sample2.pptx.

![The All Caps effect](all_caps_effect.png)

De code‑voorbeeld hieronder toont hoe je de tekst met het **All Caps**‑effect extraheert:

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

Uitvoer:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe tekst in een tabel op een dia aanpassen?**

Om tekst in een tabel op een dia aan te passen, gebruik je [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via het tekstframe van [Cell](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/) en de alinea‑opmaak via het alinea‑formaat van [Paragraph](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/).

**Hoe een kleurverloop op tekst in een PowerPoint‑dia toepassen?**

Om een kleurverloop op tekst toe te passen, gebruik je het invulformaat van [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/). Stel het invultype van [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) in op [FillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) `Gradient` en configureer de verloopstops, richting en transparantie.