---
title: Formatowanie tekstu prezentacji na Androidzie
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/androidjava/text-formatting/
keywords:
- podświetlanie tekstu
- wyrażenie regularne
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
- odstęp między wierszami
- właściwość autoskalowania
- kotwica ramki tekstowej
- tabulacja tekstu
- język domyślny
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Javie. Dostosuj czcionki, kolory, wyrównanie i inne."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Androida w Java. Obejmuje podświetlanie, kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie autoskalowania, kotwiczenie tekstu, tabulatory i ustawienia języka.

W poniższych przykładach użyjemy pliku o nazwie „sample.pptx”, który zawiera pojedyncze pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Przykładowy tekst](sample_text.png)

## **Podświetlanie tekstu**

Użyj metody [ITextFrame.highlightText](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) gdy potrzebujesz podświetlić tekst pasujący do określonego wzorca w ramce tekstowej. Metoda stosuje kolor podświetlenia do pasujących fragmentów tekstu i może być używana razem z [ITextSearchOptions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextSearchOptions) aby kontrolować sposób wyszukiwania, na przykład aby dopasować tylko pełne wyrazy.

Poniższy przykład kodu podświetla wszystkie wystąpienia znaków **"try"** oraz następnie podświetla tylko pełne słowo **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Pobierz pierwszy kształt z pierwszego slajdu.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Podświetl słowo "try" w kształcie.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Podświetl słowo "to" w kształcie.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Podświetlony tekst](highlighted_text.png)

## **Podświetlanie tekstu przy użyciu wyrażeń regularnych**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) podświetla dopasowania tekstu znalezione przy użyciu wyrażenia regularnego.

Poniższy przykład kodu podświetla wszystkie słowa zawierające **siedem lub więcej znaków**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Podświetl wszystkie słowa składające się z siedmiu lub więcej znaków.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Podświetlony tekst przy użyciu wyrażenia regularnego](highlighted_text_using_regex.png)

## **Ustawienie koloru tła tekstu**

Użyj [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) aby ustawić domyślny kolor podświetlenia dla akapitu, lub użyj [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) dla poszczególnych fragmentów tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw kolor podświetlenia dla całego akapitu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Szary akapit](gray_paragraph.png)

Poniższy przykład kodu demonstruje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ustaw kolor podświetlenia dla fragmentu tekstu.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Szare fragmenty tekstu](gray_text_portions.png)

## **Wyrównanie akapitów tekstu**

Użyj [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowane, wyrównane do lewej, do prawej, justowane i tak dalej.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw wyrównanie akapitu do środka.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Wyrównany akapit](aligned_paragraph.png)

## **Ustawienie przezroczystości tekstu**

Przezroczystość tekstu jest kontrolowana przez składnik alfa koloru przypisanego do [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). W poniższych przykładach `alpha = 50` jest wartością kanału alfa ARGB w skali 0‑255, a nie procentem przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw kolor wypełnienia tekstu na kolor przezroczysty.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Przezroczysty akapit](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ustaw przezroczystość fragmentu tekstu.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Przezroczyste fragmenty tekstu](transparent_text_portions.png)

## **Ustawienie odstępu między znakami w tekście**

Użyj [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) aby zwiększyć lub zmniejszyć odstęp między znakami w ramce tekstowej.

Poniższy kod Java pokazuje, jak zwiększyć odstęp znaków w **całym akapicie**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Uwaga: użyj wartości ujemnych, aby zmniejszyć odstęp między znakami.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zwiększ odstęp między znakami.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Odstęp znaków w akapicie](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak zwiększyć odstęp znaków w **fragmentach tekstu z pogrubioną czcionką**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Uwaga: użyj wartości ujemnych, aby zmniejszyć odstęp między znakami.
            portion.getPortionFormat().setSpacing(3); // Zwiększ odstęp między znakami.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Odstęp znaków w fragmentach tekstu](character_spacing_in_text_portions.png)

### **Wyłączenie kerningu dla konkretnych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściślej niż ten sam tekst wyświetlany w PowerPoint. Może się to zdarzyć, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet jeśli czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby w takich przypadkach uzyskać wyjście bardziej zbliżone do PowerPoint, możesz wyłączyć kerning dla fragmentów tekstu używających dotkniętej czcionki. Ustaw [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) na wartość znacznie większą niż rzeczywisty rozmiar czcionki:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To ustawienie zapobiega stosowaniu kerningu do pasujących fragmentów tekstu i może pomóc dopasować renderowanie Aspose.Slides do wizualnego wyniku PowerPoint dla czcionek dotkniętych tym zachowaniem specyficznym dla PowerPoint.

## **Zarządzanie właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu za pomocą [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) lub na poszczególnych fragmentach za pomocą [IPortionFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPortionFormat).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: stosuje rozmiar czcionki, pogrubienie, kursywę, podkreślenie kropkowane oraz czcionkę Times New Roman do wszystkich fragmentów w akapicie.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw właściwości czcionki dla akapitu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Times New Roman"));

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Właściwości czcionki dla akapitu](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **fragmentów tekstu z pogrubioną czcionką**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ustaw właściwości czcionki dla fragmentu tekstu.
            portion.getPortionFormat().setFontHeight(13);
            portion.getPortionFormat().setFontItalic(NullableBool.True);
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted);
            portion.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
        }
    }

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Właściwości czcionki dla fragmentów tekstu](font_properties_for_text_portions.png)

## **Ustawienie obrotu tekstu**

Użyj [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) aby ustawić predefiniowaną orientację tekstu w kształcie.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na `Vertical270`, co obraca tekst **o 90 stopni w lewo**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Obrót tekstu](text_rotation.png)

## **Ustawienie własnego obrotu dla ramek tekstowych**

Użyj [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) aby ustawić własny kąt obrotu dla [ITextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrame).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w kształcie:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Własny obrót tekstu](custom_text_rotation.png)

## **Ustawienie odstępu wierszy w akapitach**

Aspose.Slides udostępnia [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-), oraz [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) do kontrolowania odstępów w akapitach. Właściwości te są używane w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp wierszy jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić odstęp wierszy w punktach.

Poniższy przykład kodu pokazuje, jak określić odstęp wierszy w akapicie:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Odstęp wierszy w akapicie](line_spacing.png)

## **Ustawienie typu autoskalowania dla ramek tekstowych**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst się zmniejsza, wypływa poza obszar, czy automatycznie zmienia rozmiar kształtu.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustawienie kotwicy ramek tekstowych**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, na przykład na górze, w środku lub na dole.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustawienie tabulacji tekstu**

Użyj [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) oraz [IParagraphFormat.getTabs](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) aby skonfigurować tabulatory w akapicie.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Tabulatory w akapicie](paragraph_tabs.png)

## **Ustawienie języka korekty**

Aspose.Slides udostępnia [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-), co pozwala ustawić język korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla fragmentu tekstu:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ustaw identyfikator języka korekty.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustawienie języka domyślnego**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) aby określić domyślny język dla tekstu tworzonego podczas ładowania lub tworzenia prezentacji.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj nowy prostokątny kształt z tekstem.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Sprawdź język pierwszego fragmentu.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ustawienie domyślnego stylu tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 pt dla całego tekstu we wszystkich slajdach nowej prezentacji.

```java
Presentation presentation = new Presentation();
try {
    // Pobierz format akapitu najwyższego poziomu.
    IParagraphFormat paragraphFormat = presentation.getDefaultTextStyle().getLevel(0);

    if (paragraphFormat != null) {
        paragraphFormat.getDefaultPortionFormat().setFontHeight(14);
        paragraphFormat.getDefaultPortionFormat().setFontBold(NullableBool.True);
    }

    presentation.save("default_text_style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Wyodrębnianie tekstu z efektem wielkich liter**

W PowerPoint zastosowanie efektu czcionki **All Caps** powoduje wyświetlanie tekstu wielkimi literami na slajdzie, nawet jeśli początkowo został wpisany małymi literami. Gdy pobierasz taki fragment tekstu przy użyciu Aspose.Slides, biblioteka zwraca tekst dokładnie tak, jak został wprowadzony. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/TextCapType) i przekształć zwrócony ciąg na wielkie litery, gdy wartość to `All`.

Załóżmy, że mamy następujące pole tekstowe na pierwszym slajdzie pliku sample2.pptx.

![Efekt All Caps](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortion textPortion = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);

    System.out.println("Original text: " + textPortion.getText());

    IPortionFormatEffectiveData textFormat = textPortion.getPortionFormat().getEffective();
    if (textFormat.getTextCapType() == TextCapType.All) {
        String text = textPortion.getText().toUpperCase();
        System.out.println("All-Caps effect: " + text);
    }
} finally {
    presentation.dispose();
}
```

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [ITable](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ITable). Przeglądaj komórki i aktualizuj każdą komórkę za pomocą [ICell.getTextFrame](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ICell#getTextFrame--) oraz formatowanie akapitu za pomocą [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Jak zastosować gradientowy kolor do tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Ustaw [IFillFormat.setFillType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) na [FillType.Gradient](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/FillType) i skonfiguruj przystanki gradientu, kierunek oraz przezroczystość.