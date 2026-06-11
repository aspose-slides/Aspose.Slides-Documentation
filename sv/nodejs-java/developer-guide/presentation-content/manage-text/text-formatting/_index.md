---
title: Formatera presentationstext i JavaScript
linktitle: Textformatering
type: docs
weight: 50
url: /sv/nodejs-java/text-formatting/
keywords:
- markera text
- reguljart uttryck
- justera stycke
- textstil
- textbakgrund
- texttransparens
- teckenavstand
- typsnittegenskaper
- typsnittsfamilj
- textrotation
- rotationsvinkel
- textram
- radavstand
- autofit-egenskap
- ankare for textram
- texttabulering
- standardsprak
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatera och stylisera text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java. Anpassa typsnitt, färger, justering med mera."
---
## **Översikt**

Denna artikel visar hur du formaterar text i PowerPoint- och OpenDocument-presentationer med Aspose.Slides för Node.js via Java. Den täcker markering, bakgrundsfärger, transparens, teckenavstånd, teckensnittsegenskaper, rotation, styckeavstånd, autosträckningsbeteende, textankring, tabbstopp och språkinställningar.

I exemplen nedan kommer vi att använda en fil med namnet "sample.pptx", som innehåller en enda textruta på den första bilden med följande text:

![Exempeltext](sample_text.png)

## **Markera text**

Använd metoden [TextFrame.highlightText](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-) när du behöver markera text som matchar ett specifikt exempel inom en textruta. Metoden applicerar en markeringsfärg på matchande textfragment och kan användas tillsammans med [TextSearchOptions](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textsearchoptions/) för att styra hur sökningen utförs, till exempel för att endast matcha hela ord.

Kodexemplet nedan markerar alla förekomster av tecknen **"try"** och markerar sedan endast hela ordet **"to"**.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textFrame = shape.getTextFrame();

    // Markera ordet "try" i formen.
    textFrame.highlightText("try", java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Markera ordet "to" i formen.
    textFrame.highlightText("to", java.getStaticFieldValue("java.awt.Color", "MAGENTA"), searchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den markerade texten](highlighted_text.png)

## **Markera text med reguljära uttryck**

Metoden [TextFrame.highlightRegex](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-aspose.slides.IFindResultCallback-) markerar textmatchningar som hittas med ett reguljärt uttryck. I Node.js via Java exponeras detta API på [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).

Kodexemplet nedan markerar alla ord som innehåller **sju eller fler tecken**:

```javascript
const Pattern = java.import("java.util.regex.Pattern");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    // Markera alla ord med sju eller fler tecken.
    shape.getTextFrame().highlightRegex(regex, java.getStaticFieldValue("java.awt.Color", "YELLOW"), null);

    presentation.save("highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den markerade texten med reguljärt uttryck](highlighted_text_using_regex.png)

## **Ställ in textbakgrundsfärg**

Använd [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) för att ange standardmarkeringsfärgen för ett stycke, eller använd [PortionFormat.getHighlightColor](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getHighlightColor--) för enskilda textdelar.

Följande kodexempel visar hur du ställer in bakgrundsfärgen för **hela stycket**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in markeringsfärgen för hela stycket.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det gråa stycket](gray_paragraph.png)

Kodexemplet nedan visar hur du ställer in bakgrundsfärgen för **textdelar med fet stil**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ställ in markeringsfärgen för textdelen.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De grå textdelarna](gray_text_portions.png)

## **Justera textstycken**

Använd [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setAlignment-byte-) för att ange styckejustering inom en textruta. Värdet kan vara centrerat, vänsterjusterat, högerjusterat, justerat osv.

Följande kodexempel visar hur du justerar stycket till **centrerat**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ställ in justeringen av stycket till centrerat.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det justerade stycket](aligned_paragraph.png)

## **Ställ in transparens för text**

Transparens för text styrs genom alfa‑komponenten i färgen som tilldelas [PortionFormat.getFillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getFillFormat--). I exemplen nedan är `alpha = 50` ett ARGB‑alfavärde på skalan 0‑255, inte en transparensprocent.

Kodexemplet nedan visar hur du applicerar transparens på **hela stycket**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Ställ in fyllningsfärgen för texten till transparent färg.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Det transparenta stycket](transparent_paragraph.png)

Kodexemplet nedan visar hur du applicerar transparens på **textdelar med fet stil**:

```javascript
const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Ställ in transparensen för textdelen.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![De transparenta textdelarna](transparent_text_portions.png)

## **Ställ in teckenavstånd för text**

Använd [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) för att öka eller minska avståndet mellan tecken i en textruta.

Följande JavaScript-kod visar hur du ökar teckenavståndet i **hela stycket**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Obs: Använd negativa värden för att komprimera teckenavståndet.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Utöka teckenavståndet.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Teckenavståndet i stycket](character_spacing_in_paragraph.png)

Kodexemplet nedan visar hur du ökar teckenavståndet i **textdelar med fet stil**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Obs: Använd negativa värden för att komprimera teckenavståndet.
            portion.getPortionFormat().setSpacing(3); // Utöka teckenavståndet.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Teckenavståndet i textdelarna](character_spacing_in_text_portions.png)

### **Inaktivera kerning för specifika typsnitt**

I vissa fall kan text som renderas av Aspose.Slides se något tajtare ut än samma text i PowerPoint. Detta kan hända eftersom PowerPoint ibland ignorerar kerning‑data för vissa typsnitt, även när typsnittet innehåller korrekt kerninginformation och kerning är aktiverat i PowerPoints inställningar.

För att få den renderade utdata att bättre motsvara PowerPoint i sådana fall kan du inaktivera kerning för textdelar som använder det berörda typsnittet. Ställ in [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) på ett värde som är avsevärt större än den faktiska teckenstorleken:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Hantera texttypsnitts‑egenskaper**

Typsnittegenskaper kan sättas på styckennivå via [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) eller på enskilda delar via [PortionFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/).

Följande kod sätter typsnitt och textstil för hela stycket: den applicerar teckenstorlek, fet stil, kursiv, prickad understrykning samt typsnittet Times New Roman på alla delar i stycket.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Ställ in typsnittsegenskaperna för stycket.
    defaultPortionFormat.setFontHeight(12);
    defaultPortionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    defaultPortionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
    defaultPortionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Typsnittegenskaperna för stycket](font_properties_for_paragraph.png)

Kodexemplet nedan tillämpar liknande egenskaper på **textdelar med fet stil**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Ställ in typsnittsegenskaperna för textdelen.
            portionFormat.setFontHeight(13);
            portionFormat.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
            portionFormat.setFontUnderline(java.newByte(aspose.slides.TextUnderlineType.Dotted));
            portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Typsnittegenskaperna för textdelarna](font_properties_for_text_portions.png)

## **Ställ in textrotation**

Använd [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) för att ange en fördefinierad textorientering inom en form.

Följande kodexempel sätter textorienteringen i formen till `Vertical270`, vilket roterar texten **90 grader moturs**:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Textrotationen](text_rotation.png)

## **Ställ in anpassad rotation för textramar**

Använd [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) för att ange en anpassad rotationsvinkel för en [TextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframe/).

Kodexemplet nedan roterar textramen med 3 grader medurs inom formen:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Den anpassade textrotationen](custom_text_rotation.png)

## **Ställ in radavstånd för stycken**

Aspose.Slides tillhandahåller [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) och [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) för att kontrollera styckeavstånd. Dessa egenskaper används på följande sätt:

* Använd ett positivt värde för att ange radavstånd som en procentsats av radens höjd.
* Använd ett negativt värde för att ange radavstånd i punkter.

Följande kodexempel visar hur du specificerar radavståndet inom stycket:

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Radavståndet i stycket](line_spacing.png)

## **Ställ in autofit‑typ för textramar**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) bestämmer hur text beter sig när den överskrider ramarna för sin behållare. Använd den för att styra om texten ska krympas, överflöda eller automatiskt ändra formens storlek.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in ankare för textramar**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) definierar hur text placeras vertikalt inuti en form, till exempel högst upp, i mitten eller längst ner.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in texttabulering**

Använd [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) och [ParagraphFormat.getTabs](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraphformat/#getTabs--) för att konfigurera tabbstopp i ett stycke.

```javascript
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Resultatet:

![Styckets tabulatorer](paragraph_tabs.png)

## **Ställ in språk för korrektur**

Aspose.Slides tillhandahåller [PortionFormat.setLanguageId](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), vilket gör att du kan ange korrekturspråket för en textdel. Korrekturspråket avgör vilket språk som används för stavnings‑ och grammatikkontroller i PowerPoint.

Följande kodexempel visar hur du anger korrekturspråket för en textdel:

```javascript
const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ange Id för ett korrekturspråk.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ställ in standardspråk**

Använd [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) för att definiera standardspråket för text som skapas vid inläsning eller skapande av en presentation.

```javascript
const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Lägg till en ny rektangulär form med text.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Kontrollera det första textdelens språk.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ställ in standardtextstil**

För att applicera standardformatering av text på presentationsnivå, använd [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Följande kodexempel visar hur du ställer in ett standardtypsnitt i fet stil med storlek 14 pt för all text i alla bilder i en ny presentation.

```javascript
const presentation = new aspose.slides.Presentation();
try {
    // Hämta topnivåns styckeformat.
    const paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat !== null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    }

    presentation.save("default_text_style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Extrahera text med All‑Caps‑effekt**

I PowerPoint får du text att visas med versaler när du använder teckenformatet **All Caps**, men själva texten lagras i dess ursprungliga form. När du hämtar en sådan textdel med Aspose.Slides returneras texten exakt som den angavs. För att matcha den visade texten, kontrollera [TextCapType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/textcaptype/) och konvertera den returnerade strängen till versaler när värdet är `All`.

Låt oss säga att vi har följande textruta på den första bilden i filen sample2.pptx.

![All Caps‑effekten](all_caps_effect.png)

Kodexemplet nedan visar hur du extraherar texten med **All Caps**‑effekten tillämpad:

```javascript
const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const autoShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    console.log("Original text: " + textPortion.getText());

    const textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() === aspose.slides.TextCapType.All) {
        const text = textPortion.getText().toUpperCase();
        console.log("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

Utdata:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Hur ändrar man text i en tabell på en bild?**

För att ändra text i en tabell på en bild använder du [Table](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/table/). Iterera genom cellerna och uppdatera varje cell via [Cell.getTextFrame](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/cell/#getTextFrame--) samt styckeformatering via [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Hur applicerar man gradientfärg på text i en PowerPoint‑bild?**

För att applicera en gradientfärg på text använder du [PortionFormat.getFillFormat](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/portionformat/#getFillFormat--). Ställ in [FillFormat.setFillType](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) till [FillType.Gradient](https://reference.aspose.com/slides/sv/nodejs-java/aspose.slides/filltype/) och konfigurera gradientstopp, riktning och transparens.