---
title: Formatowanie tekstu prezentacji w JavaScript
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/nodejs-java/text-formatting/
keywords:
- wyrównaj akapit
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstępy między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstu
- odstęp między wierszami
- właściwość autofit
- kotwica ramki tekstu
- tabulacja tekstu
- język domyślny
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js via Java. Dostosuj czcionki, kolory, wyrównanie i inne."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js via Java. Obejmuje kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie autofit, kotwiczenie tekstu, tabulatory i ustawienia języka.

O ile nie zaznaczono inaczej, przykłady używają [sample.pptx](sample.pptx). Pierwszy kształt na pierwszym slajdzie jest polem tekstowym, a jego pierwszy akapit zawiera tekst pokazany poniżej. Indeksy slajdów i kształtów są zerowe. Przykłady wybierające pogrubione fragmenty używają efektywnego formatowania, w tym dziedziczonego pogrubienia:

![Przykładowy tekst](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Search and Replace Text](/slides/pl/nodejs-java/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat), aby ustawić domyślny kolor podświetlenia dla akapitu, lub użyj [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor) dla poszczególnych fragmentów tekstu.

Poniższy przykład ustawia jasnoszare podświetlenie jako domyślne dla pierwszego akapitu. Jawne kolory podświetlenia na poszczególnych fragmentach mają pierwszeństwo przed tym domyślnym:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw kolor podświetlenia dla całego akapitu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("gray_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ustaw kolor podświetlenia dla fragmentu tekstu.
            portion.getPortionFormat().getHighlightColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));
        }
    }

    presentation.save("gray_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit **do środka**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw wyrównanie akapitu do środka.
    paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Wyrównany akapit](aligned_paragraph.png)

## **Wyrównaj czcionki w linii**

Użyj [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setFontAlignment), aby pionowo wyrównać fragmenty tekstu o różnych rozmiarach czcionki w jednej linii. To ustawienie dotyczy całego akapitu i kontroluje wyrównanie w każdej z jego linii.

Poniższy, samodzielny przykład tworzy cztery oznaczone pola tekstowe na jednym slajdzie. Każdy akapit zawiera ten sam tekst w rozmiarach 18, 36 i 54 punktów, z różnym wyrównaniem czcionki. Używa Arial, wyłącza autofit i zawijanie oraz utrzymuje ramki tekstowe wystarczająco duże dla jednej linii.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const alignments = [aspose.slides.FontAlignment.Baseline, aspose.slides.FontAlignment.Top, aspose.slides.FontAlignment.Center, aspose.slides.FontAlignment.Bottom];
    const alignmentNames = ["Baseline", "Top", "Center", "Bottom"];
    const fontSizes = [18, 36, 54];

    for (let i = 0; i < alignments.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));

        const label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new aspose.slides.FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));

        for (const fontSize of fontSizes) {
            const portion = new aspose.slides.Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Porównanie wyrównania bazowego, górnego, środkowego i dolnego przy mieszanych rozmiarach czcionki](font_alignment.png)

Wyrównanie czcionki używa metryk czcionki, więc widoczne krawędzie poszczególnych liter nie muszą dokładnie pokrywać się. Przykład zawiera zarówno wielką literę, jak i znak z obniżeniem, aby pokazać różnicę między wyrównaniem do linii bazowej a dolnym. Dostępność czcionki i jej zamienniki, użyte znaki oraz różnica w rozmiarach czcionek wpływają na wynik. Wymiary ramki, marginesy, odstępy między wierszami, zawijanie i autofit także wpływają na układ; używaj tych samych czcionek i ustawień układu przy porównywaniu trybów.

To ustawienie różni się od [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setAlignment), które kontroluje poziome wyrównanie akapitu, oraz od [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType), które pozycjonuje blok tekstu pionowo w ramach kształtu. Formatowanie indeksu górnego i dolnego przy użyciu [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setEscapement) przesuwa poszczególne fragmenty względem linii bazowej zamiast ustawiać wyrównanie czcionki dla linii akapitu.

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). W poniższych przykładach `alpha = 50` to wartość kanału alfa ARGB w skali 0–255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const fillFormat = paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat();

    // Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
    fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
    fillFormat.getSolidFillColor().setColor(transparentBlack);

    presentation.save("transparent_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const alpha = 50;
const transparentBlack = java.newInstanceSync("java.awt.Color", 0, 0, 0, alpha);
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const fillFormat = portion.getPortionFormat().getFillFormat();

            // Ustaw przezroczystość fragmentu tekstu.
            fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
            fillFormat.getSolidFillColor().setColor(transparentBlack);
        }
    }

    presentation.save("transparent_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustaw odstępy znaków w tekście**

Użyj [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setSpacing), aby zwiększyć lub zmniejszyć odstępy między znakami w polu tekstowym. Przykłady dodają 3 punkty odstępu; wartości ujemne zmniejszają tekst.

Poniższy kod JavaScript pokazuje, jak rozszerzyć odstęp znaków w **całym akapicie**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozszerz odstęp znaków.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Odstępy znaków w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak rozszerzyć odstęp znaków w **fragmentach tekstu z pogrubioną czcionką**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
            portion.getPortionFormat().setSpacing(3); // Rozszerz odstęp znaków.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Odstępy znaków w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla określonych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściślej niż ten sam tekst wyświetlany w PowerPoint. Może się tak stać, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby uzyskać wynik bliższy PowerPoint w takich przypadkach, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize) na wartość większą niż rzeczywisty rozmiar czcionki. Ten przykład wymaga pliku "presentation.pptx" z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie. Sprawdza efektywne nazwy czcionek, w tym dziedziczone, i ustawia próg 100 punktów dla fragmentów używających Roboto. To wyłącza kerning dla pasujących fragmentów o rozmiarze czcionki poniżej 100 punktów:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraphs = autoShape.getTextFrame().getParagraphs();
    const paragraphCount = paragraphs.getCount();
    const targetFont = "Roboto";

    for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
        const portions = paragraphs.get_Item(paragraphIndex).getPortions();
        const portionCount = portions.getCount();

        for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const portionFormat = portion.getPortionFormat().getEffective();
            const latinFont = portionFormat.getLatinFont();
            const eastAsianFont = portionFormat.getEastAsianFont();
            const complexScriptFont = portionFormat.getComplexScriptFont();

            if ((latinFont !== null && latinFont.getFontName() === targetFont) ||
                (eastAsianFont !== null && eastAsianFont.getFontName() === targetFont) ||
                (complexScriptFont !== null && complexScriptFont.getFontName() === targetFont)) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Dla dopasowanego tekstu poniżej progu to ustawienie zapobiega kerningowi i może pomóc wyrównać renderowanie Aspose.Slides z wizualnym efektem PowerPoint dla czcionek dotkniętych tym specyficznym dla PowerPoint zachowaniem.

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu poprzez [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) lub na poszczególnych fragmentach poprzez [PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/).

Poniższy przykład ustawia domyślną czcionkę pierwszego akapitu na 12‑punktowy Times New Roman z pogrubieniem, kursywą i kropkowanym podkreśleniem. Jawne formatowanie poszczególnych fragmentów ma pierwszeństwo przed tymi wartościami domyślnymi.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const defaultPortionFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();

    // Ustaw właściwości czcionki dla akapitu.
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

Wynik:

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład stosuje 13‑punktowy Times New Roman, formatowanie kursywy i kropkowane podkreślenie do fragmentów, których efektywne formatowanie jest pogrubione:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    const portions = paragraph.getPortions();
    const portionCount = portions.getCount();

    for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
        const portion = portions.get_Item(portionIndex);
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            const portionFormat = portion.getPortionFormat();

            // Ustaw właściwości czcionki dla fragmentu tekstu.
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

Wynik:

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Kontroluj normalizację wysokości tekstu**

Użyj [BasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setNormaliseHeight), gdy odtwarzasz typografię szablonu lub badzesz różnice w wysokości znaków. W PowerPoint włączenie normalizacji rozciąga lub kompresuje poszczególne znaki pionowo, aby uzyskać jednolitą widoczną wysokość w ramach fragmentu tekstu. Nie gwarantuje to równej wysokości tekstu między różnymi czcionkami.

Ustaw właściwość na [NullableBool.True lub False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/), aby jawnie włączyć lub wyłączyć normalizację. `NullableBool.NotDefined` pozostawia ustawienie lokalne nieustawione, tak że fragment dziedziczy wartość, np. z [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) akapitu. Nie oznacza to `False`. Użyj [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective) i odczytaj [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) aby uzyskać rozstrzygniętą wartość boolowską.

Poniższy, samodzielny przykład wymaga zainstalowanego **Arial**. Tworzy dwa bloki tekstu zawierające te same wielkie litery, małe litery, dolne części i znaki diakrytyczne w rozmiarze 54 punktów. Oba akapity włączają normalizację domyślnie. Górny fragment wyłącza ją jawnie; dolny dziedziczy. Rozmiary ramki, marginesy i odstępy akapitów są identyczne, a zawijanie i autofit są wyłączone, aby zachować spójność porównania. Przykład wypisuje `False: false` i `NotDefined: true`, po czym zapisuje "text_height_normalization.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const settings = [aspose.slides.NullableBool.False, aspose.slides.NullableBool.NotDefined];
    const settingNames = ["False", "NotDefined"];

    for (let i = 0; i < settings.length; i++) {
        const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

        const textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
        textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.False));
        textFrame.getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Top));
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        const paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(java.newByte(aspose.slides.NullableBool.True));

        const portion = paragraph.getPortions().get_Item(0);
        const font = new aspose.slides.FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
        portion.getPortionFormat().setNormaliseHeight(java.newByte(settings[i]));

        console.log(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Porównanie poniżej zostało wyeksportowane z zapisanej prezentacji. Górny wiersz ma wyłączoną normalizację (`False`); dolny wiersz dziedziczy włączone ustawienie (`NotDefined` → `True`). Upewnij się, że Arial jest zainstalowany, aby odtworzyć ten wygląd.

![Tekst Arial 54‑punktowy z wyłączoną normalizacją powyżej i dziedziczoną normalizacją poniżej](text_height_normalization.png)

Normalizacja zmienia wysokość znaku bez zmiany przypisanej wartości [getFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFontHeight), która określa rozmiar czcionki w punktach. [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin) kontroluje odstęp między wierszami, natomiast [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) steruje tym, jak tekst lub jego kontener dopasowuje się do rozmiaru. Te ustawienia służą różnym celom i mogą wpływać na ostateczny układ niezależnie. Aby uzyskać więcej informacji o formatowaniu akapitu i dziedziczeniu, zobacz [Manage Paragraph](/slides/pl/nodejs-java/manage-paragraph/).

## **Zastosuj i usuń przekreślenie**

Użyj [BasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setStrikethroughType) na fragmencie tekstu, aby wyświetlić poprawki, odrzucone terminy lub poprzednie ceny bez usuwania oryginalnego tekstu. Ustaw na [TextStrikethroughType.Single lub Double](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/) dla jednej lub dwóch linii przekreślonych przez tekst.

Aby usunąć przekreślenie, użyj [TextStrikethroughType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#None). To wyraźnie wyłącza efekt, nawet jeśli otaczające formatowanie określa przekreślenie. Natomiast [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textstrikethroughtype/#NotDefined) pozostawia lokalne ustawienie niezdefiniowane, pozwalając fragmentowi dziedziczyć formatowanie, np. z akapitu. Nie gwarantuje to usunięcia przekreślenia. Użyj [PortionFormat.getEffective](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portionformat/#getEffective), aby odczytać wynikowe formatowanie, w tym dziedziczone wartości.

Poniższy, samodzielny przykład tworzy trzy porównania cen. Każdy akapit ma osobne fragmenty dla etykiety, poprzedniej ceny i bieżącej ceny, więc jedynie poprzednia cena jest dotknięta. W pierwszym wierszu najpierw stosuje, a następnie usuwa przekreślenie; pozostałe wiersze zachowują pojedyncze i podwójne przekreślenie. Zmiana tego ustawienia zachowuje tekst i jego pozostałe formatowanie, w tym pogrubioną poprzednią cenę.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    shape.getTextFrame().getParagraphs().clear();

    const labels = ["None: ", "Single: ", "Double: "];

    for (const label of labels) {
        const paragraph = new aspose.slides.Paragraph();
        paragraph.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        const format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        const font = new aspose.slides.FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        format.getFillFormat().getSolidFillColor().setColor(textColor);

        const labelPortion = new aspose.slides.Portion(label);
        paragraph.getPortions().add(labelPortion);

        const previousPrice = new aspose.slides.Portion("$100");
        previousPrice.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
        paragraph.getPortions().add(previousPrice);
        const currentPrice = new aspose.slides.Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    const paragraphs = shape.getTextFrame().getParagraphs();

    // Zastosuj przekreślenie, a potem wyraźnie je usuń z pierwszej poprzedniej ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.None));

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Single));
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(java.newByte(aspose.slides.TextStrikethroughType.Double));

    presentation.save("strikethrough.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik, od góry do dołu: brak przekreślenia, pojedyncze przekreślenie i podwójne przekreślenie.

![Poprzednie ceny bez przekreślenia, z pojedynczym przekreśleniem i z podwójnym przekreśleniem](strikethrough.png)

## **Ustaw obrót tekstu**

Użyj [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType), aby ustawić predefiniowaną orientację tekstu w kształcie.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textverticaltype/), co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(java.newByte(aspose.slides.TextVerticalType.Vertical270));

    presentation.save("text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Obrót tekstu](text_rotation.png)

## **Ustaw niestandardowy obrót dla ramek tekstowych**

Użyj [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setRotationAngle), aby ustawić własny kąt obrotu dla [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w kształcie:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Niestandardowy obrót tekstu](custom_text_rotation.png)

## **Ustaw odstępy między wierszami akapitów**

Aspose.Slides udostępnia [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore) i [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin), aby kontrolować odstępy akapitu. Właściwości te są używane w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić odstęp w punktach.

Poniższy przykład ustawia odstęp wewnątrz pierwszego akapitu na 200 % wysokości wiersza (podwójny odstęp):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Odstęp wierszy w akapicie](line_spacing.png)

## **Kontroluj łamanie linii**

Reguły łamania linii akapitu są przydatne w wąskich blokach tekstowych i prezentacjach, które mieszają tekst łaciński i wschodnioazjatycki. Poniższe metody należą do [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/), więc dotyczą całego akapitu:

- [setLatinLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setLatinLineBreak) kontroluje reguły łamania linii łacińskich. W mieszanym tekście zmiana tej opcji może również zmienić miejsce, w którym są łamane sąsiadujące znaki wschodnioazjatyckie i interpunkcja.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) kontroluje reguły łamania linii wschodnioazjatyckich, w tym ograniczenia dotyczące znaków na początku i końcu linii.

Te reguły nie zastępują [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setWrapText), które włącza automatyczne zawijanie w ramce tekstowej. Wpływają na układ, gdy zachodzi zawijanie; nie wstawiają znaków nowej linii. Jawne wymuszenie nowej linii powoduje nowy wiersz w akapicie niezależnie od dostępnej szerokości.

Poniższy, samodzielny przykład tworzy wąski blok tekstowy zawierający chiński i łaciński tekst. Ustawia oba opcje łamania linii explicite i zapisuje "line_breaking.pptx". Aby eksperymentować z każdą regułą, zmień odpowiednią wartość, pozostawiając drugie ustawienie niezmienione. Przykład używa 24‑punktowego Arial i SimSun przy szerokości ramki 160 punktów i zerowych poziomych marginesów ramki tekstowej. [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) jest wywoływane z [TextAutofitType.None](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textautofittype/), aby rozmiar tekstu i wymiary ramki pozostały stałe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    const eastAsianFont = new aspose.slides.FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setLatinLineBreak(java.newByte(aspose.slides.NullableBool.False));
    format.setEastAsianLineBreak(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("line_breaking.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontroluj zawieszoną interpunkcję**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setHangingPunctuation) pozwala dopuszczalnej interpunkcji wybiegać poza prawą krawędź linii tekstu zamiast zajmować następną linię. Dotyczy całego akapitu i różni się od wcięcia wiszącego.

Poniższy, samodzielny przykład włącza zawieszoną interpunkcję w ramce tekstowej o szerokości 100 punktów i zapisuje "hanging_punctuation.pptx". Przy 24‑punktowym Arial i zerowych poziomych marginesach ramki, ostatni kropka pozostaje po słowie "sentence" i wystaje poza prawą krawędź tekstu. Ustaw właściwość na [NullableBool.False](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nullablebool/), aby porównać: przy tych ustawieniach kropka zajmuje oddzielną linię. Zawijanie jest włączone, a autofit wyłączony, aby zachować stałą dostępną szerokość.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));

    const textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(java.newByte(aspose.slides.NullableBool.True));
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.None));
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    const paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    const format = paragraph.getParagraphFormat();
    format.setAlignment(aspose.slides.TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    const latinFont = new aspose.slides.FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    const textColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(textColor);
    format.setHangingPunctuation(java.newByte(aspose.slides.NullableBool.True));

    presentation.save("hanging_punctuation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Nie każda interpunkcja może wisieć. [Warunki czcionki i układu opisane powyżej](#control-line-breaking) również mają zastosowanie do tego porównania: zmiana czcionki, dostępnej szerokości, marginesów lub ustawień autofitu może usunąć widoczną różnicę.

## **Ustaw typ autofitu dla ramek tekstowych**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAutofitType) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst zmniejsza się, wypływa poza ramkę, czy kształt automatycznie się zmienia. Poniższy przykład konfiguruje kształt tak, aby zmieniał rozmiar, aby pomieścić tekst i zapisuje wynik jako "autofit_type.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));

    presentation.save("autofit_type.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby policzyć wiersze po automatycznym zawijaniu i zobaczyć, jak zmiany szerokości tekstu lub kształtu wpływają na wynik, zobacz [Count Rendered Lines](/slides/pl/nodejs-java/manage-paragraph/). Samo liczenie wierszy nie wskazuje, czy tekst wypływa poza kontener.

## **Ustaw kotwicę ramek tekstowych**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/#setAnchoringType) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. u góry, w środku lub na dole. Poniższy przykład kotwiczy tekst u dołu pierwszego kształtu i zapisuje wynik jako "text_anchor.pptx".

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);
    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(java.newByte(aspose.slides.TextAnchorType.Bottom));

    presentation.save("text_anchor.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw tabulację tekstu**

Użyj [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize) i [ParagraphFormat.getTabs](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getTabs), aby skonfigurować tabulatory w akapicie. Poniższy przykład ustawia domyślny odstęp tabulacji na 100 punktów i dodaje lewostronny tabulator w 30 punktach. Ustawienia te wpływają na tekst zawierający znaki tabulacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, java.newByte(aspose.slides.TabAlignment.Left));

    presentation.save("paragraph_tabs.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId), który pozwala ustawić język korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład wymaga "presentation.pptx" z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie i przynajmniej jednym akapitem. Zastępuje zawartość pierwszego akapitu na "1。", ustawia SimSun jako czcionkę i przypisuje język korekty chiński uproszczony (`zh-CN`). Zapisuje wynik jako "proofing_language.pptx":

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const autoShape = slide.getShapes().get_Item(0);

    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const font = new aspose.slides.FontData("SimSun");
    const textPortion = new aspose.slides.Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ustaw Id języka korekty.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kopiowanie metadanych językowych**

Podczas kopiowania tekstu wielojęzycznego z szablonu, zachowaj zarówno [BasePortionFormat.getLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getLanguageId), jak i [BasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getAlternativeLanguageId). Poniższy, samodzielny przykład tworzy fragment źródłowy z językiem US English i francuskim językiem alternatywnym, a następnie kopiuje tekst i identyfikatory do fragmentu w nowej prezentacji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const source = new aspose.slides.Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const destination = new aspose.slides.Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Jeśli źródło nie ma alternatywnego języka, null usuwa wartość docelową.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby wypróbować źródło bez języka alternatywnego, pomiń przypisanie `"fr-FR"`. Alternatywny identyfikator będzie wtedy `null`, a to samo polecenie kopiowania zachowa jego brak bez wprowadzania wartości domyślnej, nawet jeśli docelowy wcześniej miał przypisany język alternatywny.

Te identyfikatory przechowują metadane językowe. Zachowanie ich nie ustala, który słownik PowerPoint wybierze do sprawdzania pisowni lub gramatyki.

## **Ustaw język domyślny**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage), aby zdefiniować domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji. Poniższy przykład tworzy prezentację z domyślnym językiem tekstu US English, dodaje pole tekstowe i wypisuje `en-US` dla jego pierwszego fragmentu tekstowego.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);

    // Dodaj nowy prostokątny kształt z tekstem.
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Sprawdź język pierwszego fragmentu.
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    console.log(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle).

Poniższy przykład ustawia 14‑punktową pogrubioną czcionkę jako domyślną dla akapitów najwyższego poziomu w nowej prezentacji i zapisuje ją jako "default_text_style.pptx". Tekst może dziedziczyć te domyślne ustawienia, chyba że bardziej szczegółowe formatowanie je nadpisze.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    // Pobierz format akapitu najwyższego poziomu.
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

## **Wyodrębnij tekst z efektem wielkich liter (All‑Caps)**

W PowerPoint zastosowanie efektu **All Caps** powoduje, że tekst wyświetlany jest wielkimi literami na slajdzie, nawet gdy został wpisany małymi literami. Gdy pobierasz taki fragment tekstu przy pomocy Aspose.Slides, biblioteka zwraca dokładnie tak wprowadzony tekst. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textcaptype/) i przekształć zwrócony łańcuch na wielkie litery, gdy wartość jest `All`.

Przykład wymaga "sample2.pptx" z polem tekstowym jako pierwszym kształtem na pierwszym slajdzie. Jego pierwszy akapit‑pierwszy fragment zawiera "Hello, Aspose!" z zastosowanym efektem All Caps, jak pokazano poniżej.

![Efekt All Caps](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample2.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const autoShape = slide.getShapes().get_Item(0);
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

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/). Przeglądaj komórki i aktualizuj każdą komórkę za pomocą [Cell.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/cell/#getTextFrame) oraz formatowanie akapitu przez [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/#getParagraphFormat).

**Jak zastosować gradientowy kolor do tekstu na slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#getFillFormat). Ustaw [FillFormat.setFillType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/#setFillType) na [FillType.Gradient](https://reference.aspose.com/slides/nodejs-java/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek i przezroczystość.