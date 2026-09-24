---
title: Tekst in presentaties formatteren in PHP
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
- lettertype‑eigenschappen
- lettertypefamilie
- tekstrotatie
- rotatie‑hoek
- tekstkader
- regelafstand
- autofit‑eigenschap
- tekstkader‑anker
- tekst‑tabulatie
- standaardtaal
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Formatteer en style tekst in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor PHP via Java. Pas lettertypen, kleuren, uitlijning en meer aan."
---
## **Overzicht**

Dit artikel toont hoe u tekst kunt opmaken in PowerPoint‑ en OpenDocument‑presentaties met Aspose.Slides voor PHP via Java. Het behandelt achtergrondkleuren, transparantie, tekenafstand, lettertype‑eigenschappen, rotatie, alinea‑afstand, autofit‑gedrag, tekst‑ankering, tab‑stops en taalinstellingen.

In de voorbeelden hieronder gebruiken we een bestand genaamd "sample.pptx", dat een enkel tekstvak op de eerste dia bevat met de volgende tekst:

![Voorbeeldtekst](sample_text.png)

Om letterlijke tekst of reguliere‑expressie‑matches te vinden en te markeren, zie [Search and Replace Text](/slides/nl/php-java/search-and-replace-text/).

## **Achtergrondkleur van Tekst Instellen**

Gebruik [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) om de standaard markeerkleur voor een alinea in te stellen, of gebruik [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#getHighlightColor) voor individuele tekstgedeelten.

De volgende code‑voorbeeld laat zien hoe u de achtergrondkleur voor de **hele alinea** instelt:

```php
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

De code‑voorbeeld hieronder demonstreert hoe u de achtergrondkleur voor **tekstgedeelten met een vet lettertype** instelt:

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

## **Tekst‑alinea’s Uitlijnen**

Gebruik [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setAlignment) om de uitlijning van alinea’s binnen een tekstframe in te stellen. De waarde kan gecentreerd, links‑uitgelijnd, rechts‑uitgelijnd, uitgevuld, enzovoort zijn.

De volgende code‑voorbeeld laat zien hoe u de alinea naar het **midden** uitlijnt:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Stel de uitlijning van de alinea in op gecentreerd.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![De uitgelijnde alinea](aligned_paragraph.png)

## **Transparantie van Tekst Instellen**

Transparantie van tekst wordt geregeld via het alfacomponent van de kleur die is toegewezen aan [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#getFillFormat). In de voorbeelden hieronder is `alpha = 50` een ARGB‑alphakanaalwaarde op de schaal 0–255, geen transparantiepercentage.

De code‑voorbeeld hieronder toont hoe u transparantie toepast op de **hele alinea**:

```php
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

De volgende code‑voorbeeld toont hoe u transparantie toepast op **tekstgedeelten met een vet lettertype**:

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
            // Stelt de transparantie van het tekstgedeelte in.
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

## **Tekenafstand voor Tekst Instellen**

Gebruik [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setSpacing) om de afstand tussen tekens in een tekstvak te vergroten of te verkleinen.

De volgende PHP‑code laat zien hoe u de tekenafstand in de **hele alinea** vergroot:

```php
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

De code‑voorbeeld hieronder toont hoe u de tekenafstand vergroot in **tekstgedeelten met een vet lettertype**:

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

### **Kerning Uitschakelen voor Specifieke Lettertypen**

In sommige gevallen kan tekst die door Aspose.Slides wordt gerenderd er iets strakker uitzien dan dezelfde tekst in PowerPoint. Dit kan gebeuren omdat PowerPoint kerning‑gegevens voor bepaalde lettertypen negeert, zelfs wanneer het lettertype geldige kerning‑informatie bevat en kerning is ingeschakeld in de PowerPoint‑instellingen.

Om de gerenderde uitvoer in dergelijke gevallen dichter bij PowerPoint te brengen, kunt u kerning uitschakelen voor tekstgedeelten die het betreffende lettertype gebruiken. Stel [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) in op een waarde die aanzienlijk groter is dan de feitelijke lettergrootte:

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

Deze instelling voorkomt dat kerning wordt toegepast op overeenkomende tekstgedeelten en kan helpen om de weergave van Aspose.Slides beter te laten overeenstemmen met de visuele uitvoer van PowerPoint voor lettertypen die door dit PowerPoint‑specifieke gedrag worden beïnvloed.

## **Tekst‑lettertype‑eigenschappen Beheren**

Lettertype‑eigenschappen kunnen op alinea‑niveau worden ingesteld via [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) of op individuele gedeelten via [PortionFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/portionformat/).

De volgende code stelt het lettertype en de tekststijl in voor de hele alinea: het past lettergrootte, vet, cursief, gestippelde onderstreping en het lettertype Times New Roman toe op alle gedeelten in de alinea.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Stel de lettertype-eigenschappen voor de alinea in.
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

De code‑voorbeeld hieronder past soortgelijke eigenschappen toe op **tekstgedeelten met een vet lettertype**:

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

## **Tekstrotatie Instellen**

Gebruik [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setTextVerticalType) om een vooraf gedefinieerde tekstoriëntatie binnen een vorm in te stellen.

De volgende code‑voorbeeld stelt de tekstoriëntatie in de vorm in op `Vertical270`, wat de tekst **90 graden tegen de klok in** roteert:

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

Het resultaat:

![De tekstrotatie](text_rotation.png)

## **Aangepaste Rotatie voor Tekstkaders Instellen**

Gebruik [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setRotationAngle) om een aangepaste rotatie‑hoek in te stellen voor een [TextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframe/).

De code‑voorbeeld hieronder roteert het tekstkader met 3 graden met de klok mee binnen de vorm:

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

Het resultaat:

![De aangepaste tekstrotatie](custom_text_rotation.png)

## **Regelafstand van Alinea’s Instellen**

Aspose.Slides biedt [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setSpaceBefore) en [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setSpaceWithin) om de alinea‑afstand te regelen. Deze eigenschappen worden als volgt gebruikt:

* Gebruik een positieve waarde om regelafstand op te geven als een percentage van de regelhoogte.
* Gebruik een negatieve waarde om regelafstand in punten op te geven.

De volgende code‑voorbeeld laat zien hoe u de regelafstand binnen de alinea specificeert:

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

Het resultaat:

![De regelafstand binnen de alinea](line_spacing.png)

## **Autofit‑type voor Tekstkaders Instellen**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setAutofitType) bepaalt hoe tekst zich gedraagt wanneer deze de grenzen van de container overschrijdt. Gebruik het om te regelen of de tekst krimpt, overlapt of de vorm automatisch vergroot.

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

Om het aantal regels na automatisch afbreken te tellen en te zien hoe tekst‑ of vormbreedte het resultaat wijzigt, zie [Count Rendered Lines](/slides/nl/php-java/manage-paragraph/). Alleen het aantal regels geeft niet aan of de tekst buiten de container uitsteekt.

## **Anker van Tekstkaders Instellen**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textframeformat/#setAnchoringType) definieert hoe tekst verticaal binnen een vorm wordt gepositioneerd, bijvoorbeeld bovenaan, in het midden of onderaan.

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

## **Tekst‑tabulatie Instellen**

Gebruik [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) en [ParagraphFormat::getTabs](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraphformat/#getTabs) om tab‑stops in een alinea te configureren.

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

Het resultaat:

![De alinea‑tabs](paragraph_tabs.png)

## **Proof‑taal Instellen**

Aspose.Slides biedt [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#setLanguageId), waarmee u de controle‑taal voor een tekstgedeelte kunt instellen. De controle‑taal bepaalt de taal die wordt gebruikt voor spelling‑ en grammaticacontrole in PowerPoint.

De volgende code‑voorbeeld toont hoe u de controle‑taal voor een tekstgedeelte instelt:

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

    // Stel de Id van een controletaal in.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Standaardtaal Instellen**

Gebruik [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) om de standaardtaal te definiëren voor tekst die wordt aangemaakt tijdens het laden of creëren van een presentatie.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Voeg een nieuw rechthoekvorm toe met tekst.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Controleer de taal van het eerste gedeelte.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Standaard‑tekststijl Instellen**

Om standaardtekstopmaak op presentatieniveau toe te passen, gebruik [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation/#getDefaultTextStyle).

De volgende code‑voorbeeld laat zien hoe u een standaard vet lettertype met een grootte van 14 pt instelt voor alle tekst op alle dia's in een nieuwe presentatie.

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

## **Tekst Extraheren met het Alles‑Hoofdletters‑Effect**

In PowerPoint zorgt het toepassen van het **All Caps**‑lettertype‑effect ervoor dat tekst in hoofdletters wordt weergegeven op de dia, zelfs wanneer deze oorspronkelijk in kleine letters is getypt. Wanneer u zo'n tekstgedeelte ophaalt met Aspose.Slides, geeft de bibliotheek de tekst exact terug zoals ingevoerd. Om de weergegeven tekst te laten overeenkomen, controleer [TextCapType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/textcaptype/) en zet de geretourneerde tekenreeks om naar hoofdletters wanneer de waarde `All` is.

Stel dat we het volgende tekstvak op de eerste dia van het bestand sample2.pptx hebben.

![Het Alles‑Hoofdletters‑effect](all_caps_effect.png)

De code‑voorbeeld hieronder toont hoe u de tekst met het **All Caps**‑effect kunt extraheren:

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hoe tekst in een tabel op een dia aanpassen?**

Om tekst in een tabel op een dia te wijzigen, gebruik [Table](https://reference.aspose.com/slides/nl/php-java/aspose.slides/table/). Loop door de cellen en werk elke cel bij via [Cell::getTextFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/cell/#getTextFrame) en alinea‑opmaak via [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Hoe een gradient‑kleur op tekst in een PowerPoint‑dia toepassen?**

Gebruik [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseportionformat/#getFillFormat) om een gradient‑kleur op tekst toe te passen. Stel [FillFormat::setFillType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/#setFillType) in op [FillType::Gradient](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/) en configureer de gradient‑stops, richting en transparantie.