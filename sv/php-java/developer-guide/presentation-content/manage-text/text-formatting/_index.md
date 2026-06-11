---
title: Formatera presentationstext i PHP
linktitle: Textformatering
type: docs
weight: 50
url: /sv/php-java/text-formatting/
keywords:
- markera text
- reguljärt uttryck
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstånd
- typsnittsegenskaper
- typsnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstånd
- autofit egenskap
- textramförankring
- texttabulering
- standardspråk
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Formatera och stilisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för PHP via Java. Anpassa typsnitt, färger, justering med mera."
---
## **Översikt**

Den här artikeln visar hur man formaterar text i PowerPoint‑ och OpenDocument‑presentationer med Aspose.Slides för PHP via Java. Den täcker markering, bakgrundsfärger, transparens, teckenavstånd, typsnittsegenskaper, rotation, styckeavstånd, autofit‑beteende, textförankring, tabbstopp och språkinställningar.

I exemplen nedan använder vi en fil med namnet "sample.pptx" som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Markera text**

Använd [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/)`::highlightText`‑metoden när du behöver markera text som matchar ett specifikt urval inom en textram. Metoden applicerar en markeringsfärg på matchande textfragment och kan användas med [TextHighlightingOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/texthighlightingoptions/) för att styra hur sökningen utförs, t.ex. för att bara matcha hela ord.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan bara hela ordet **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Hämta den första formen från den första bilden.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Markera ordet "try" i formen.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Markera ordet "to" i formen.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

[TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/)`::highlightRegex`‑metoden markerar texthittningar som hittas med ett reguljärt uttryck.

Kodexemplet nedan markerar alla ord som innehåller **sju eller fler tecken**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Markera alla ord med sju eller fler tecken.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Ange bakgrundsfärg för text**

Använd [ParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/)'s standarddelformat för att ange standardmarkeringsfärg för ett stycke, eller använd [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/) för enskilda textdelar.

Följande kodexempel visar hur du anger bakgrundsfärg för **hela stycket**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Ange markeringsfärgen för hela stycket.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan demonstrerar hur du anger bakgrundsfärg för **textdelar med fet stil**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Ange markeringsfärgen för textdelen.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![De gråa textdelarna](gray_text_portions.png)

## **Justera textparagrafer**

Använd [ParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/)`::setAlignment`‑metoden för att ange styckejustering inom en textram. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat osv.

Följande kodexempel visar hur du justerar stycket till **centrum**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Sätt styckets justering till centrerad.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ange transparens för text**

Transparens för text styrs via alfakomponenten i färgen som tilldelas [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/)'s fyllningsformat. I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på skalan 0‑255, inte en transparensprocent.

Kodexemplet nedan visar hur du applicerar transparens på **hela stycket**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Ställ in fyllningsfärgen för texten till en transparent färg.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Följande kodexempel visar hur du applicerar transparens på **textdelar med fet stil**:

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
            // Ställ in transparensen för textdelen.
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

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ange teckenavstånd för text**

Använd [BasePortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/)`::setSpacing`‑metoden för att öka eller minska avståndet mellan tecken i en textruta.

Följande PHP‑kod visar hur du ökar teckenavståndet i **hela stycket**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Obs: Använd negativa värden för att komprimera teckenavståndet.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Utöka teckenavståndet.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur du ökar teckenavståndet i **textdelar med fet stil**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Obs: Använd negativa värden för att komprimera teckenavståndet.
            $portion->getPortionFormat()->setSpacing(3); // Utöka teckenavståndet.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Resultatet:

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text i PowerPoint. Detta kan ske eftersom PowerPoint ibland ignorerar kerningdata för vissa typsnitt, även när typsnittet innehåller giltig kerninginformation och kerning är aktiverat i PowerPoint‑inställningarna.

För att få den renderade utdata närmare PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det drabbade typsnittet. Ställ in [BasePortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize`‑metoden på ett värde som är betydligt större än den faktiska typsnittsstorleken:

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

Denna inställning förhindrar att kerning appliceras på matchande textdelar och kan hjälpa till att alignera Aspose.Slides‑renderingen med PowerPoints visuella utdata för de typsnitt som påverkas av detta PowerPoint‑specifika beteende.

## **Hantera typsnittsegenskaper för text**

Typsnittsegenskaper kan sättas på styckennivå via [ParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/)'s standarddelformat eller på enskilda delar via [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/).

Följande kod sätter teckensnitt och textstil för hela stycket: den applicerar teckenstorlek, fet, kursiv, punktad understrykning och teckensnittet Times New Roman på alla delar i stycket.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Använd teckensnittsegenskaper för stycket.
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

Resultatet:

![Typsnittsegenskaper för stycket](font_properties_for_paragraph.png)

Kodexemplet nedan applicerar liknande egenskaper på **textdelar med fet stil**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Ange teckensnittsegenskaper för textdelen.
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

Resultatet:

![Typsnittsegenskaper för textdelar](font_properties_for_text_portions.png)

## **Ange textrotation**

Använd [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/)`::setTextVerticalType`‑metoden för att ange en fördefinierad textriktning inom en form.

Följande kodexempel sätter textriktningen i formen till `Vertical270`, vilket roterar texten **90 grader moturs**:

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

Resultatet:

![Textrotation](text_rotation.png)

## **Ange anpassad rotation för textramar**

Använd [TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/)`::setRotationAngle`‑metoden för att ange en anpassad rotationsvinkel för en [TextFrame](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframe/).

Kodexemplet nedan roterar textrammet 3 grader medurs inom formen:

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

Resultatet:

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ange radavstånd för stycken**

Aspose.Slides tillhandahåller [ParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` och `ParagraphFormat::setSpaceWithin`‑metoder för att styra styckeavstånd. Dessa metoder används så här:

* Använd ett positivt värde för att ange radavstånd som en procentandel av radens höjd.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande kodexempel visar hur du anger radavståndet inom stycket:

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

Resultatet:

![Radavståndet i stycket](line_spacing.png)

## **Ange autofit‑typ för textramar**

[TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/)`::setAutofitType`‑metoden bestämmer hur text beter sig när den överskrider behållarens gränser. Använd den för att kontrollera om texten ska krympas, flyta över eller automatiskt ändra storlek på formen.

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

## **Ange förankring för textramar**

[TextFrameFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textframeformat/)`::setAnchoringType`‑metoden definierar hur text placeras vertikalt inne i en form, t.ex. högst upp, i mitten eller längst ner.

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

## **Ange tabulering för text**

Använd [ParagraphFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize`‑metoden och dess tab‑samling för att konfigurera tabbstopp i ett stycke.

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

Resultatet:

![Styckets tabbar](paragraph_tabs.png)

## **Ange språk för korrekturläsning**

Aspose.Slides tillhandahåller [BasePortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/baseportionformat/)`::setLanguageId`‑metoden, som låter dig ange språk för korrekturläsning för en textdel. Språket bestämmer vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande kodexempel visar hur du sätter språk för korrekturläsning för en textdel:

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

    // Ange ID för ett korrekturläsningsspråk.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Ange standardspråk**

Använd [LoadOptions](https://reference.aspose.com/slides/sv/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage`‑metoden för att definiera standardspråk för text som skapas vid inläsning eller skapande av en presentation.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Lägg till en ny rektangelform med text.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Kontrollera språk för den första textdelen.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Ange standardtextstil**

För att applicera standardtextformatering på presentationsnivå, använd [Presentation](https://reference.aspose.com/slides/sv/php-java/aspose.slides/presentation/)'s standardtextstil.

Följande kodexempel visar hur du sätter ett standardfett teckensnitt med storlek 14 pt för all text på alla bilder i en ny presentation.

```php
$presentation = new Presentation();
try {
    // Hämta paragrafformatet på högsta nivån.
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

## **Extrahera text med versaler‑effekt**

I PowerPoint gör **All Caps**‑teckensnittseffekten att text visas med versaler på bilden även om den ursprungligen skrevs med gemener. När du hämtar en sådan textdel med Aspose.Slides returnerar biblioteket texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Låt oss säga att vi har följande textruta på den första bilden i filen sample2.pptx.

![Versaler‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur du extraherar texten med **All Caps**‑effekten applicerad:

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

Utdata:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar man text i en tabell på en bild?**

För att ändra text i en tabell på en bild, använd [Table](https://reference.aspose.com/slides/sv/php-java/aspose.slides/table/). Iterera genom cellerna och uppdatera varje cell via [Cell](https://reference.aspose.com/slides/sv/php-java/aspose.slides/cell/)'s textram och styckeformatering via [Paragraph](https://reference.aspose.com/slides/sv/php-java/aspose.slides/paragraph/)'s styckeformat.

**Hur applicerar man en gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text, använd [PortionFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/portionformat/)'s fyllningsformat. Ställ in [FillFormat](https://reference.aspose.com/slides/sv/php-java/aspose.slides/fillformat/)'s fyllningstyp till [FillType](https://reference.aspose.com/slides/sv/php-java/aspose.slides/filltype/) `Gradient` och konfigurera gradientstopp, riktning och transparens.