---
title: Formátování textu prezentace na Androidu
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/androidjava/text-formatting/
keywords:
- zvýraznit text
- regulární výraz
- zarovnat odstavec
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
- textový rámeček
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámečku
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy. Popisuje zvýrazňování, barvy pozadí, průhlednost, rozestup znaků, vlastnosti písma, otáčení, odsazení odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor s názvem "sample.pptx", který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvýraznit text**

Použijte metodu [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) když potřebujete zvýraznit text, který odpovídá konkrétnímu vzorku v rámci textového rámečku. Metoda aplikuje barvu zvýraznění na odpovídající úryvky textu a lze ji použít spolu s [ITextSearchOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextSearchOptions) k řízení způsobu provádění vyhledávání, například pro shodu pouze celých slov.

Cílový kód níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Získá první tvar z první snímku.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Zvýrazní slovo "try" v tvaru.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Zvýrazní slovo "to" v tvaru.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) zvýrazňuje shody textu nalezené regulárním výrazem.

Níže uvedený příklad kódu zvýrazní všechna slova, která obsahují **sedm a více znaků**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Zvýrazní všechna slova s délkou alespoň sedmi znaků.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Nastavit barvu pozadí textu**

Použijte [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) , abyste nastavili výchozí barvu zvýraznění pro odstavec, nebo použijte [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) pro jednotlivé textové úseky.

Následující příklad kódu ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak nastavit barvu pozadí pro **textové úseky se tučným písmem**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavte barvu zvýraznění pro textový úsek.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedé úseky textu](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) , abyste nastavili zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, zarovnaná do bloku a podobně.

Následující příklad kódu ukazuje, jak zarovnat odstavec na **střed**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte zarovnání odstavce na střed.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavit průhlednost textu**

Průhlednost textu se řídí pomocí alfa komponenty barvy přiřazené k [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu v ARGB na škále 0‑255, ne procento průhlednosti.

Níže uvedený příklad kódu ukazuje, jak použít průhlednost na **celý odstavec**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte barvu výplně textu na průhlednou barvu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující příklad kódu ukazuje, jak použít průhlednost na **textové úseky s tučným písmem**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavte průhlednost textového úseku.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledné úseky textu](transparent_text_portions.png)

## **Nastavit mezery mezi znaky textu**

Použijte [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) , abyste rozšířili nebo zúžili mezery mezi znaky v textovém rámečku.

Následující Java kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty pro zmenšení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezery mezi znaky v odstavci](character_spacing_in_paragraph.png)

Níže uvedený příklad kódu ukazuje, jak rozšířit mezery mezi znaky v **textových úsecích s tučným písmem**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty pro zmenšení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3); // Rozšířit mezeru mezi znaky.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezery mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby bylo vykreslené výstupní zobrazení v takových případech bližší PowerPointu, můžete pro textové úseky používající dané písmo zakázat kerning. Nastavte [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) na hodnotu podstatně vyšší než skutečná velikost písma:

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

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) nebo na jednotlivých úsecích pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPortionFormat).

Následující kód nastaví písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučný, kurzíva, tečkované podtržení a písmo Times New Roman na všechny úseky v odstavci.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte vlastnosti písma pro odstavec.
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

Výsledek:

![Vlastnosti písma pro odstavec](font_properties_for_paragraph.png)

Níže uvedený příklad kódu použije podobné vlastnosti na **textové úseky s tučným písmem**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavte vlastnosti písma pro textový úsek.
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

Výsledek:

![Vlastnosti písma pro textové úseky](font_properties_for_text_portions.png)

## **Nastavit rotaci textu**

Použijte [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) , abyste nastavili předdefinovanou orientaci textu uvnitř tvaru.

Následující příklad kódu nastaví orientaci textu v tvaru na `Vertical270`, což otočí text **o 90 stupňů proti směru hodinových ručiček**:

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

Výsledek:

![Rotace textu](text_rotation.png)

## **Nastavit vlastní rotaci pro textové rámečky**

Použijte [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) , abyste nastavili vlastní úhel rotace pro [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrame).

Níže uvedený příklad kódu otáčí textový rámeček o 3 stupně ve směru hodinových ručiček uvnitř tvaru:

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

Výsledek:

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-), a [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) , pro řízení odsazení odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad kódu ukazuje, jak specifikovat řádkování v odstavci:

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

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavit typ automatického přizpůsobení pro textové rámečky**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přeteče nebo automaticky mění velikost tvaru.

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

## **Nastavit kotvu textových rámečků**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

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

## **Nastavit tabulaci textu**

Použijte [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) , abyste nakonfigurovali tabulátory v odstavci.

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

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavit jazyk kontroly pravopisu**

Aspose.Slides poskytuje [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) , který vám umožňuje nastavit jazyk kontroly pravopisu pro textový úsek. Jazyk kontroly pravopisu určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad kódu ukazuje, jak nastavit jazyk kontroly pravopisu pro textový úsek:

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

    // Nastavte ID jazykové kontroly.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) , abyste definovali výchozí jazyk pro text vytvořený během načítání nebo vytváření prezentace.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte nový obdélníkový tvar s textem.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Zkontrolujte jazyk prvního úseku.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Nastavit výchozí styl textu**

Pro použití výchozího formátování textu na úrovni prezentace použijte [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--).

Následující příklad kódu ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro celý text napříč snímky v nové prezentaci.

```java
Presentation presentation = new Presentation();
try {
    // Získejte formát odstavce nejvyšší úrovně.
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

## **Extrahovat text s efektem Všech velkých písmen**

V PowerPointu aplikace efektu **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně napsán malými. Když takový úsek textu načtete pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro sladění se zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/TextCapType) a převádějte vrácený řetězec na velká písmena, pokud je hodnota `All`.

Řekněme, že máme následující textový rámeček na první snímku souboru sample2.pptx.

![Efekt Všech velkých písmen](all_caps_effect.png)

Níže uvedený příklad kódu ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ITable). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.getTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ICell#getTextFrame--) a formátování odstavců pomocí [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--).

**Jak aplikovat gradientní barvu na text v PowerPoint snímku?**

Pro aplikaci gradientní barvy na text použijte [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--). Nastavte [IFillFormat.setFillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) na [FillType.Gradient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/FillType) a nakonfigurujte gradientní úseky, směr a průhlednost.