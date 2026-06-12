---
title: Formátování textu prezentace v Javě
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/java/text-formatting/
keywords:
- zvýraznění textu
- regulární výraz
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- rozestup znaků
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otáčení
- textový rámeček
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámečku
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java. Pokrývá zvýrazňování, barvy pozadí, průhlednost, rozestupy znaků, vlastnosti písma, otáčení, rozestupy odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V níže uvedených příkladech použijeme soubor s názvem **"sample.pptx"**, který obsahuje jediný textový rámeček na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvýraznění textu**

Použijte metodu [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-), když potřebujete zvýraznit text, který odpovídá konkrétnímu vzorku v textovém rámečku. Metoda použije barvu zvýraznění na odpovídající úseky textu a může být použita společně s [TextSearchOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/) pro řízení způsobu vyhledávání, například pro shodu pouze celých slov.

Ukázkový kód níže zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní pouze celé slovo **"to"**.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Získat první tvar z první snímku.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Zvýraznit slovo "try" v tvaru.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Zvýraznit slovo "to" v tvaru.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) zvýrazní shody textu nalezené regulárním výrazem. V Javě je toto API k dispozici na rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).

Ukázkový kód níže zvýrazní všechna slova, která obsahují **sedm nebo více znaků**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Zvýraznit všechna slova s délkou sedm nebo více znaků.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) pro nastavení výchozí barvy zvýraznění odstavce, nebo [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pro jednotlivé textové úseky.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavit barvu zvýraznění pro celý odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Ukázkový kód níže demonstruje, jak nastavit barvu pozadí pro **textové úseky s tučným písmem**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavit barvu zvýraznění pro textový úsek.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedé textové úseky](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) pro nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku atd.

Následující ukázkový kód ukazuje, jak zarovnat odstavec **na střed**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavit zarovnání odstavce na střed.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Zarovnaný odstavec](aligned_paragraph.png)

## **Nastavení průhlednosti textu**

Průhlednost textu se řídí alfa‑komponentou barvy přiřazené k metodě [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). V níže uvedených příkladech je `alpha = 50` hodnota kanálu ARGB v rozsahu 0‑255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavit barvu výplně textu na průhlednou barvu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **textové úseky s tučným písmem**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavit průhlednost textového úseku.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledné textové úseky](transparent_text_portions.png)

## **Nastavení rozestupu znaků v textu**

Použijte [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) pro rozšíření nebo zmenšení mezery mezi znaky v textovém rámečku.

Následující Java kód ukazuje, jak rozšířit rozestup znaků v **celém odstavci**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty pro zmenšení rozestupu znaků.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozšířit rozestup znaků.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Rozestup znaků v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit rozestup znaků v **textových úsecích s tučným písmem**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty pro zmenšení rozestupu znaků.
            portion.getPortionFormat().setSpacing(3); // Rozšířit rozestup znaků.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Rozestup znaků v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázání kerningu pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu u určitých písem, i když písmo obsahuje platné informace o kerningu a kerning je v PowerPointu zapnutý.

Aby výstup lépe odpovídal PowerPointu, můžete zakázat kerning pro textové úseky, které používají dotčené písmo. Nastavte [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) na hodnotu podstatně vyšší než skutečná velikost písma:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající textové úseky a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u písem, na která se tato PowerPoint‑specifická chování vztahuje.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) nebo na jednotlivých úsecích pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iportionformat/).

Následující kód nastavuje písmo a styl textu pro **celý odstavec**: aplikuje velikost písma, tučné, kurzívu, tečkované podtržení a písmo Times New Roman na všechny úseky v odstavci.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavit vlastnosti písma pro odstavec.
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

Ukázkový kód níže aplikuje podobné vlastnosti na **textové úseky s tučným písmem**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavit vlastnosti písma pro textový úsek.
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

## **Nastavení otáčení textu**

Použijte [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) pro nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na `Vertical270`, což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Otáčení textu](text_rotation.png)

## **Vlastní otáčení textových rámců**

Použijte [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) pro nastavení vlastního úhlu otáčení pro [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/).

Ukázkový kód níže otáčí textový rámec o 3 stupně po směru hodinových ručiček uvnitř tvaru:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Vlastní otáčení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje metody [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) a [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) pro řízení řádkování odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

Metoda [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) určuje, jak se text chová, když přesahuje hranice svého kontejneru. Použijte ji k řízení, zda se text zmenší, přeteče nebo automaticky změní velikost tvaru.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení ukotvení textových rámců**

Metoda [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení tabulátorů textu**

Použijte [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraphformat/#getTabs--) pro konfiguraci tabulátorů v odstavci.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Nastavení jazykové kontroly (proofing)**

Aspose.Slides poskytuje [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), který umožňuje nastavit jazyk pro kontrolu pravopisu a gramatiky u textového úseku. Tento jazyk určuje, jaký jazyk bude použit pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující ukázkový kód ukazuje, jak nastavit jazyk kontroly pro textový úsek:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Nastavit Id jazykové kontroly.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k definování výchozího jazyka pro text vytvářený při načítání nebo vytváření prezentace.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidat nový obdélníkový tvar s textem.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Zkontrolovat jazyk první části.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího textového stylu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Následující ukázkový kód ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro veškerý text napříč snímky v nové prezentaci.

```java
Presentation presentation = new Presentation();
try {
    // Získat formát odstavce nejvyšší úrovně.
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

## **Extrahování textu s efektem VŠECHNA PÍSMENA VYPNUTÁ (All Caps)**

V PowerPointu aplikace efektu **All Caps** způsobí, že se text na snímku zobrazí velkými písmeny, i když byl původně zadán malými. Při načítání takového textového úseku pomocí Aspose.Slides knihovna vrátí text přesně tak, jak byl zadán. Pro dosažení zobrazeného textu zkontrolujte [TextCapType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textcaptype/) a v případě, že je hodnota `All`, převést vrácený řetězec na velká písmena.

Předpokládejme, že na první snímku souboru **sample2.pptx** máme následující textový rámeček.

![Efekt All Caps](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.getTextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icell/#getTextFrame--) a formátování odstavců prostřednictvím [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Jak aplikovat barevný přechod na text v PowerPoint snímku?**

Pro aplikaci barevného přechodu na text použijte [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Nastavte [IFillFormat.setFillType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/cs/java/com.aspose.slides/filltype/) a nakonfigurujte přechodové zastávky, směr a průhlednost.