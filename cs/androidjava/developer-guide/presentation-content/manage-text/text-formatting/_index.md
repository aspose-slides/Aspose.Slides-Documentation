---
title: Formátování textu prezentace na Androidu
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/androidjava/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezera mezi znaky
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otočení
- textový rám
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámu
- tabelace textu
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Android prostřednictvím Javy. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otočení, mezery odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

V příkladech níže použijeme soubor nazvaný "sample.pptx", který obsahuje jedinou textovou oblast na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Hledat a nahradit text](/slides/cs/androidjava/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) k nastavení výchozí barvy zvýraznění pro odstavec, nebo použijte [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pro jednotlivé úseky textu.

Následující ukázkový kód ukazuje, jak nastavit barvu pozadí pro **celý odstavec**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Ukázkový kód níže demonstruje, jak nastavit barvu pozadí pro **textové úseky s tučným písmem**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![Šedé textové úseky](gray_text_portions.png)

## **Zarovnání odstavců textu**

Použijte [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a podobně.

Následující ukázkový kód ukazuje, jak zarovnat odstavec na **střed**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **Nastavení průhlednosti textu**

Průhlednost textu je řízena alfa‑komponentou barvy přiřazené pomocí [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). V příkladech níže je `alpha = 50` hodnota kanálu alfa ARGB na stupnici 0–255, ne procento průhlednosti.

Ukázkový kód níže ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Následující ukázkový kód ukazuje, jak aplikovat průhlednost na **textové úseky s tučným písmem**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

![Průhledné textové úseky](transparent_text_portions.png)

## **Nastavení mezery mezi znaky textu**

Použijte [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) k rozšíření nebo zúžení mezery mezi znaky v textovém poli.

Následující Java kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zvětšit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezeru mezi znaky v **textových úsecích s tučným písmem**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty ke zmenšení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3); // Zvětšit mezeru mezi znaky.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v textových úsecích](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní fonty**

V některých případech může text vykreslený Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určité fonty, i když font obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup lépe odpovídal PowerPointu, můžete zakázat kerning pro textové úseky, které používají dotčený font. Nastavte [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) na hodnotu podstatně větší než skutečná velikost písma:

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

Toto nastavení zabraňuje aplikaci kerningu na odpovídající textové úseky a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu pro fonty, na které se toto chování specifické pro PowerPoint vztahuje.

## **Správa vlastností písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) nebo na jednotlivých úsecích pomocí [IPortionFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iportionformat/).

Následující kód nastavuje písmo a styl textu pro celý odstavec: aplikuje velikost písma, tučnost, kurzívu, tečkované podtržení a font Times New Roman na všechny úseky v odstavci.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Ukázkový kód níže aplikuje podobné vlastnosti na **textové úseky s tučným písmem**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
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

## **Nastavení otočení textu**

Použijte [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) k nastavení předdefinované orientace textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

Výsledek:

![Otočení textu](text_rotation.png)

## **Nastavení vlastního otočení pro textové rámy**

Použijte [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) k nastavení vlastního úhlu otočení pro [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/).

Ukázkový kód níže otáčí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

Výsledek:

![Vlastní otočení textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) a [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) k řízení mezery odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu pro určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu pro určení řádkování v bodech.

Následující ukázkový kód ukazuje, jak specifikovat řádkování v odstavci:

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

Výsledek:

![Řádkování v odstavci](line_spacing.png)

## **Nastavení typu automatického přizpůsobení pro textové rámy**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přeteče nebo automaticky mění velikost tvaru.

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak se mění šířka textu nebo tvaru, viz [Počet vykreslených řádků](/slides/cs/androidjava/manage-paragraph/). Samotný počet řádků neznamená, že text přetéká svůj kontejner.

## **Nastavení ukotvení textových rámců**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) definuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole.

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

## **Nastavení tabelace textu**

Použijte [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) k nastavení tabulátorů v odstavci.

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

Výsledek:

![Tabulátory odstavce](paragraph_tabs.png)

## **Nastavení jazykové kontroly**

Aspose.Slides poskytuje [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), což umožňuje nastavit jazykovou kontrolu pro textový úsek. Jazyková kontrola určuje jazyk použitého pravopisu a gramatické kontroly v PowerPointu.

Následující ukázkový kód ukazuje, jak nastavit jazykovou kontrolu pro textový úsek:

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

    // Nastavte Id jazykové kontroly.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k definování výchozího jazyka pro text vytvářený během načítání nebo tvorby prezentace.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Přidejte nový obdélníkový tvar s textem.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Zkontrolujte jazyk první části.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího stylu textu**

Pro aplikaci výchozího formátování textu na úrovni celé prezentace použijte [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Následující ukázkový kód ukazuje, jak nastavit výchozí tučné písmo o velikosti 14 pt pro veškerý text napříč snímky v nové prezentaci.

```java
import com.aspose.slides.*;

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

## **Extrahování textu s efektem Všechna velká písmena**

V PowerPointu aplikace efektu **All Caps** způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takový úsek textu získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu s tím, co je zobrazeno, převádějte vrácený řetězec na velká písmena, když je hodnota [TextCapType.All](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textcaptype/) použita.

Řekněme, že máme na první snímku souboru sample2.pptx následující textové pole.

![Efekt Všechna velká písmena](all_caps_effect.png)

Ukázkový kód níže ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

Výstup:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Často kladené otázky**

**Jak upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku přes [ICell.getTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icell/#getTextFrame--) a formátování odstavců přes [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Jak aplikovat přechodovou barvu na text v PowerPoint snímku?**

Pro aplikaci přechodové barvy na text použijte [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--). Nastavte [IFillFormat.setFillType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/filltype/) a nakonfigurujte zastávky gradientu, směr a průhlednost.