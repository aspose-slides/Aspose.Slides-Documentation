---
title: Formatowanie tekstu prezentacji w Javie
linktitle: Formatowanie tekstu
type: docs
weight: 50
url: /pl/java/text-formatting/
keywords:
- wyrównanie akapitu
- styl tekstu
- tło tekstu
- przezroczystość tekstu
- odstępy między znakami
- właściwości czcionki
- rodzina czcionek
- obrót tekstu
- kąt obrotu
- ramka tekstowa
- odstęp wierszy
- właściwość autofit
- kotwica ramki tekstowej
- tabulacja tekstu
- domyślny język
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Formatuj i stylizuj tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides dla Javy. Dostosuj czcionki, kolory, wyrównanie i inne."
---
## **Przegląd**

Ten artykuł pokazuje, jak formatować tekst w prezentacjach PowerPoint i OpenDocument przy użyciu Aspose.Slides for Java. Obejmuje kolory tła, przezroczystość, odstępy między znakami, właściwości czcionki, obrót, odstępy akapitów, zachowanie autofit, kotwiczenie tekstu, tabulatory i ustawienia języka.

W poniższych przykładach użyjemy pliku o nazwie „sample.pptx”, który zawiera jedno pole tekstowe na pierwszym slajdzie z następującym tekstem:

![Sample text](sample_text.png)

Aby znaleźć i podświetlić dosłowny tekst lub dopasowania wyrażeń regularnych, zobacz [Search and Replace Text](/slides/pl/java/search-and-replace-text/).

## **Ustaw kolor tła tekstu**

Użyj [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) aby ustawić domyślny kolor podświetlenia dla akapitu lub użyj [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) dla poszczególnych fragmentów tekstu.

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **całego akapitu**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw kolor podświetlenia dla całego akapitu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The gray paragraph](gray_paragraph.png)

Poniższy przykład kodu pokazuje, jak ustawić kolor tła dla **fragmentów tekstu z pogrubioną czcionką**:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ustaw kolor podświetlenia dla fragmentu tekstu.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The gray text portions](gray_text_portions.png)

## **Wyrównaj akapity tekstu**

Użyj [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) aby ustawić wyrównanie akapitu w ramce tekstowej. Wartość może być wyśrodkowana, wyrównana do lewej, do prawej, wyjustowana itp.

Poniższy przykład kodu pokazuje, jak wyrównać akapit do **środka**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw wyrównanie akapitu na środku.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The aligned paragraph](aligned_paragraph.png)

## **Ustaw przezroczystość tekstu**

Przezroczystość tekstu jest kontrolowana przez komponent alfa koloru przypisanego do [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). W poniższych przykładach `alpha = 50` to wartość kanału alfa ARGB w skali 0‑255, a nie procent przezroczystości.

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **całego akapitu**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Ustaw kolor wypełnienia tekstu na przezroczysty kolor.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The transparent paragraph](transparent_paragraph.png)

Poniższy przykład kodu pokazuje, jak zastosować przezroczystość do **fragmentów tekstu z pogrubioną czcionką**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Ustaw przezroczystość fragmentu tekstu.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The transparent text portions](transparent_text_portions.png)

## **Ustaw odstępy między znakami w tekście**

Użyj [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) aby zwiększyć lub zmniejszyć odstępy między znakami w polu tekstowym.

Poniższy kod Java pokazuje, jak zwiększyć odstępy między znakami w **całym akapicie**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zwiększ odstęp między znakami.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Poniższy przykład kodu pokazuje, jak zwiększyć odstępy między znakami w **fragmentach tekstu z pogrubioną czcionką**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Uwaga: użyj wartości ujemnych, aby skompresować odstęp między znakami.
            portion.getPortionFormat().setSpacing(3); // Zwiększ odstęp między znakami.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Wyłącz kerning dla określonych czcionek**

W niektórych przypadkach tekst renderowany przez Aspose.Slides może wyglądać nieco ściśniej niż ten sam tekst wyświetlany w PowerPoint. Może się tak stać, ponieważ PowerPoint może ignorować dane kerningu dla niektórych czcionek, nawet gdy czcionka zawiera prawidłowe informacje o kerningu i kerning jest włączony w ustawieniach PowerPoint.

Aby w takich przypadkach uzyskać renderowany wynik bliższy PowerPoint, możesz wyłączyć kerning dla fragmentów tekstu używających danej czcionki. Ustaw [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) na wartość znacząco większą niż rzeczywisty rozmiar czcionki:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormat portionFormat = portion.getPortionFormat();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portionFormat.setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

To ustawienie zapobiega stosowaniu kerningu do pasujących fragmentów tekstu i może pomóc wyrównać renderowanie Aspose.Slides z wizualnym wynikiem PowerPoint dla czcionek dotkniętych tym zachowaniem specyficznym dla PowerPoint.

## **Zarządzaj właściwościami czcionki tekstu**

Właściwości czcionki można ustawić na poziomie akapitu poprzez [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) lub na poszczególnych fragmentach poprzez [IPortionFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iportionformat/).

Poniższy kod ustawia czcionkę i styl tekstu dla całego akapitu: zastosowuje rozmiar czcionki, pogrubienie, kursywę, kreskowane podkreślenie oraz czcionkę Times New Roman do wszystkich fragmentów w akapicie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Wynik:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Poniższy przykład kodu stosuje podobne właściwości do **fragmentów tekstu z pogrubioną czcionką**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

Wynik:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Ustaw obrót tekstu**

Użyj [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) aby ustawić predefiniowaną orientację tekstu w obrębie kształtu.

Poniższy przykład kodu ustawia orientację tekstu w kształcie na `Vertical270`, co obraca tekst **o 90 stopni przeciwnie do ruchu wskazówek zegara**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The text rotation](text_rotation.png)

## **Ustaw niestandardowy obrót ramek tekstowych**

Użyj [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) aby ustawić niestandardowy kąt obrotu dla [ITextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframe/).

Poniższy przykład kodu obraca ramkę tekstową o 3 stopnie zgodnie z ruchem wskazówek zegara w obrębie kształtu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The custom text rotation](custom_text_rotation.png)

## **Ustaw odstępy wierszy w akapitach**

Aspose.Slides udostępnia [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), oraz [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-), aby kontrolować odstępy w akapitach. Właściwości te są używane w następujący sposób:

* Użyj wartości dodatniej, aby określić odstęp wierszy jako procent wysokości wiersza.
* Użyj wartości ujemnej, aby określić odstęp wierszy w punktach.

Poniższy przykład kodu pokazuje, jak określić odstęp wierszy w akapicie:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The line spacing within the paragraph](line_spacing.png)

## **Ustaw typ dopasowania automatycznego dla ramek tekstowych**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) określa, jak tekst zachowuje się, gdy przekracza granice swojego kontenera. Użyj go, aby kontrolować, czy tekst zmniejsza się, wycieka poza granice lub automatycznie zmienia rozmiar kształtu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby policzyć linie po automatycznym zawijaniu i zobaczyć, jak zmienia się szerokość tekstu lub kształtu, zobacz [Count Rendered Lines](/slides/pl/java/manage-paragraph/). Samo liczenie linii nie wskazuje, czy tekst wykracza poza swój kontener.

## **Ustaw kotwicę ramek tekstowych**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definiuje, jak tekst jest pozycjonowany pionowo wewnątrz kształtu, np. na górze, w środku lub na dole.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw tabulację tekstu**

Użyj [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) oraz [IParagraphFormat.getTabs](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraphformat/#getTabs--) aby skonfigurować tabulatory w akapicie.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setDefaultTabSize(100);
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left);

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wynik:

![The paragraph tabs](paragraph_tabs.png)

## **Ustaw język korekty**

Aspose.Slides udostępnia [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), co umożliwia ustawienie języka korekty dla fragmentu tekstu. Język korekty określa język używany do sprawdzania pisowni i gramatyki w PowerPoint.

Poniższy przykład kodu pokazuje, jak ustawić język korekty dla fragmentu tekstu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Ustaw Id języka korekty.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślny język**

Użyj [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pl/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) aby zdefiniować domyślny język dla tekstu tworzonego podczas wczytywania lub tworzenia prezentacji.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Dodaj nowy kształt prostokątny z tekstem.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Sprawdź język pierwszego fragmentu.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Ustaw domyślny styl tekstu**

Aby zastosować domyślne formatowanie tekstu na poziomie prezentacji, użyj [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Poniższy przykład kodu pokazuje, jak ustawić domyślną pogrubioną czcionkę o rozmiarze 14 punktów dla całego tekstu na slajdach w nowej prezentacji.

```java
import com.aspose.slides.*;

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

## **Wyodrębnij tekst z efektem wielkich liter**

W PowerPoint zastosowanie efektu czcionki **All Caps** sprawia, że tekst wyświetla się wielkimi literami na slajdzie, nawet jeśli został wpisany małymi literami. Gdy pobierasz taki fragment tekstu przy pomocy Aspose.Slides, biblioteka zwraca tekst dokładnie taki, jaki został wprowadzony. Aby dopasować wyświetlany tekst, sprawdź [TextCapType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/textcaptype/) i przekształć zwrócony ciąg na wielkie litery, gdy wartość wynosi `All`.

Załóżmy, że mamy następujące pole tekstowe na pierwszym slajdzie pliku sample2.pptx.

![The All Caps effect](all_caps_effect.png)

Poniższy przykład kodu pokazuje, jak wyodrębnić tekst z zastosowanym efektem **All Caps**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Wyjście:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **FAQ**

**Jak zmodyfikować tekst w tabeli na slajdzie?**

Aby zmodyfikować tekst w tabeli na slajdzie, użyj [ITable](https://reference.aspose.com/slides/pl/java/com.aspose.slides/itable/). Iteruj przez komórki i aktualizuj każdą komórkę za pomocą [ICell.getTextFrame](https://reference.aspose.com/slides/pl/java/com.aspose.slides/icell/#getTextFrame--) oraz formatowanie akapitu za pomocą [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Jak zastosować kolor gradientowy do tekstu w slajdzie PowerPoint?**

Aby zastosować gradientowy kolor do tekstu, użyj [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Ustaw [IFillFormat.setFillType](https://reference.aspose.com/slides/pl/java/com.aspose.slides/ifillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/pl/java/com.aspose.slides/filltype/) i skonfiguruj punkty gradientu, kierunek oraz przezroczystość.