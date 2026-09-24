---
title: Formatowanie tekstu prezentacji w JavaScript
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/nodejs-java/text-formatting/
keywords:
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstęp między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- interlinia
- właściwość autofit
- kotwica ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js poprzez Javę. Dostosuj czcionki, kolory, wyrównanie i inne."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Node.js za pośrednictwem Javy. Obejmuje kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie autofit, kotwiczenie tekstu, tabulatory i ustawienia języka.

W poniższych przykładach użyjemy pliku o nazwie „sample.pptx”, który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Search and Replace Text](/slides/pl/nodejs-java/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) aby ustawić domyślny kolor podświetlenia dla akapitu lub użyj [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#getHighlightColor--) dla poszczególnych fragmentów tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

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

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

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

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setAlignment-int-) aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, justowana i tak dalej.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

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

![Wyrównany akapit](aligned_paragraph.png)

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez komponent alfa koloru przypisanego do [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). W poniższych przykładach `alpha = 50` to wartość kanału alfa ARGB w skali 0–255, a nie procent przezroczystości.

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

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustaw odstęp między znakami w tekście**

Użyj [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setSpacing-float-) aby zwiększyć lub zmniejszyć odstępy między znakami w polu tekstowym.

Poniższy kod JavaScript pokazuje, jak zwiększyć odstęp między znakami w **całym akapicie**:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const autoShape = slide.getShapes().get_Item(0);
    const paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zwiększ odstęp między znakami.

    presentation.save("character_spacing_in_paragraph.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Odstęp między znakami w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak zwiększyć odstęp między znakami w **fragmentach tekstu z pogrubioną czcionką**:

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
            portion.getPortionFormat().setSpacing(3); // Zwiększ odstęp między znakami.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Odstęp między znakami w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla określonych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco bardziej ściśle niż ten sam tekst wyświetlany w PowerPoint. Może się tak stać, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby w takich przypadkach wynik renderowania był bliższy PowerPoint, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setKerningMinimalSize-float-) na wartość znacząco większą niż rzeczywisty rozmiar czcionki:

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

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu za pomocą [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat--) lub na poszczególnych fragmentach za pomocą [PortionFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/portionformat/).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: stosuje rozmiar czcionki, pogrubienie, kursywę, kropkowane podkreślenie oraz czcionkę Times New Roman dla wszystkich fragmentów w akapicie.

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

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **fragmentów tekstu z pogrubioną czcionką**:

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

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Ustaw obrót tekstu**

Użyj [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setTextVerticalType-byte-) aby ustawić predefiniowaną orientację tekstu wewnątrz kształtu.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na `Vertical270`, co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

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

![Obrót tekstu](text_rotation.png)

## **Ustaw niestandardowy obrót dla ramek tekstowych**

Użyj [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setRotationAngle-float-) aby ustawić niestandardowy kąt obrotu dla [TextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w obrębie kształtu:

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

![Niestandardowy obrót tekstu](custom_text_rotation.png)

## **Ustaw interlinię akapitów**

Aspose.Slides udostępnia [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setSpaceAfter-float-), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setSpaceBefore-float-) i [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setSpaceWithin-float-) aby kontrolować odstępy akapitów. Te właściwości używa się w następujący sposób:

* Użyj wartości dodatniej, aby określić interlinię jako procent wysokości linii.
* Użyj wartości ujemnej, aby określić interlinię w punktach.

Poniższy przykład kodu pokazuje, jak określić interlinię w akapicie:

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

![Interlinia w akapicie](line_spacing.png)

## **Ustaw typ autofitu dla ramek tekstowych**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setAutofitType-byte-) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst ma się zmniejszać, przelewać czy automatycznie zmieniać rozmiar kształtu.

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

Aby policzyć wiersze po automatycznym łamaniu i zobaczyć, jak zmienia się szerokość tekstu lub kształtu, zobacz [Count Rendered Lines](/slides/pl/nodejs-java/manage-paragraph/). Liczba wierszy sama w sobie nie wskazuje, czy tekst przelewa się poza kontener.

## **Ustaw kotwicę ramek tekstowych**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textframeformat/#setAnchoringType-byte-) określa, jak tekst jest rozmieszczony pionowo wewnątrz kształtu, np. na górze, w środku lub na dole.

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

Użyj [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#setDefaultTabSize-float-) i [ParagraphFormat.getTabs](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraphformat/#getTabs--) aby skonfigurować tabulatory w akapicie.

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

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-), co pozwala ustawić język korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla fragmentu tekstu:

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

## **Ustaw domyślny język**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) aby określić domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji.

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

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/presentation/#getDefaultTextStyle--).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 punktów dla całego tekstu we wszystkich slajdach nowej prezentacji.

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

## **Wyodrębnij tekst z efektem wielkich liter**

W PowerPoint stosowanie efektu czcionki **All Caps** sprawia, że tekst wyświetlany jest wielkimi literami na slajdzie, nawet jeśli pierwotnie został wpisany małymi literami. Gdy pobierasz taki fragment tekstu za pomocą Aspose.Slides, biblioteka zwraca tekst dokładnie taki, jaki został wprowadzony. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textcaptype/) i zamień zwrócony ciąg na wielkie litery, gdy wartość to `All`.

Załóżmy, że mamy następujące pole tekstowe na pierwszym slajdzie pliku sample2.pptx.

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

Output:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak modyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [Table](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/table/). Przeglądaj komórki i aktualizuj każdą komórkę za pomocą [Cell.getTextFrame](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/cell/#getTextFrame--) oraz formatowanie akapitu za pomocą [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/#getParagraphFormat--).

**Jak zastosować gradientowy kolor do tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/baseportionformat/#getFillFormat--). Ustaw [FillFormat.setFillType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/fillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/filltype/) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.