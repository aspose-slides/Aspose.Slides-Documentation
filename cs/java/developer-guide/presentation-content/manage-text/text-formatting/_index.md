---
title: Formátování textu prezentace v Javě
linktitle: Formátování textu
type: docs
weight: 50
url: /cs/java/text-formatting/
keywords:
- zarovnání odstavce
- styl textu
- pozadí textu
- průhlednost textu
- mezery mezi znaky
- vlastnosti písma
- rodina písma
- otočení textu
- úhel otočení
- textový rámec
- řádkování
- automatické přizpůsobení
- ukotvení textového rámce
- tabulace textu
- výchozí jazyk
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Formátujte a stylizujte text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Javu. Přizpůsobte písma, barvy, zarovnání a další."
---
## **Přehled**

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písma, otáčení, odstupy odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné části, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro nalezení a zvýraznění doslovného textu nebo shod regulárních výrazů viz [Vyhledat a nahradit text](/slides/cs/java/search-and-replace-text/).

## **Nastavit barvu pozadí textu**

Použijte [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pro jednotlivé části textu.

Následující příklad nastavuje světle šedé zvýraznění jako výchozí pro první odstavec. Výslovně nastavené barvy zvýraznění u jednotlivých částí mají přednost před tímto výchozím nastavením:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Níže uvedený ukázkový kód demonstruje, jak nastavit barvu pozadí pro **části textu s tučným písmem**:

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
            // Nastavit barvu zvýraznění pro část textu.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedé části textu](gray_text_portions.png)

## **Zarovnat odstavce textu**

Použijte [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a tak dále.

Níže uvedený ukázkový kód ukazuje, jak zarovnat odstavec na **střed**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

## **Zarovnat písma v řádku**

Použijte [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) k vertikálnímu zarovnání částí textu s různými velikostmi písma v řádku. Toto nastavení se vztahuje na celý odstavec a řídí zarovnání v každém jeho řádku.

Níže uvedený samostatný příklad vytvoří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text v 18, 36 a 54 bodech s jiným zarovnáním písma. Používá Arial, vypíná automatické přizpůsobení a zalamování a udržuje textové rámečky dostatečně velké pro jediný řádek.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] alignments = { FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom };
    String[] alignmentNames = { "Baseline", "Top", "Center", "Bottom" };
    float[] fontSizes = { 18f, 36f, 54f };

    for (int i = 0; i < alignments.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);

        IParagraph label = textFrame.getParagraphs().get_Item(0);
        label.setText(alignmentNames[i]);
        label.getParagraphFormat().setAlignment(TextAlignment.Left);
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14);
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setFontAlignment(alignments[i]);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(new FontData("Arial"));
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        for (float fontSize : fontSizes) {
            Portion portion = new Portion("Ag ");
            portion.getPortionFormat().setFontHeight(fontSize);
            paragraph.getPortions().add(portion);
        }

        textFrame.getParagraphs().add(paragraph);
    }

    presentation.save("font_alignment.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Porovnání zarovnání podélně, nahoře, ve středu a dole s různými velikostmi písma](font_alignment.png)

Zarovnání písma používá metriky písma, takže viditelné okraje jednotlivých znaků se nemusí přesně zarovnat. Příklad zahrnuje jak velké písmeno, tak znak s dolním výsuvem, aby ukázal rozdíl mezi zarovnáním na základní čáře a dole. Dostupnost a náhrada písma, použité znaky a rozdíl ve velikostech písma ovlivňují výsledek. Rozměry rámce, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů použijte stejná písma a nastavení rozvržení.

Toto nastavení se liší od [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), který řídí vodorovné zarovnání odstavce, a od [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), který vertikálně umisťuje textový blok uvnitř tvaru. Formátování horního a spodního indexu pomocí [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) posouvá jednotlivé části relativně k základní čáře místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavit průhlednost textu**

Průhlednost textu se řídí alfa složkou barvy přiřazené pomocí [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). V níže uvedených příkladech je `alpha = 50` hodnota alfa kanálu ARGB ve škále 0–255, nikoli procento průhlednosti.

Ukázkový kód níže ukazuje, jak použít průhlednost na **celý odstavec**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Další ukázkový kód ukazuje, jak použít průhlednost na **části textu s tučným písmem**:

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
            // Nastavit průhlednost textové části.
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

![Průhledné části textu](transparent_text_portions.png)

## **Nastavit mezery mezi znaky textu**

Použijte [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) k rozšíření nebo zúžení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty text zúží.

Následující Java kód ukazuje, jak rozšířit mezery mezi znaky v **celém odstavci**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty k zmenšení mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Zvětšit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázkový kód níže ukazuje, jak rozšířit mezery mezi znaky v **částech textu s tučným písmem**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty k zmenšení mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3); // Zvětšit mezeru mezi znaky.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v částech textu](character_spacing_in_text_portions.png)

### **Zakázat kerning pro konkrétní písma**

V některých případech může text vykreslený pomocí Aspose.Slides vypadat mírně těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určitá písma, i když písmo obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Pro zbližení výstupu k PowerPointu v takových případech můžete zakázat kerning pro části textu, které používají dotčené písmo. Nastavte [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) na hodnotu větší než skutečná velikost písma. Tento příklad vyžaduje soubor „presentation.pptx“ s textovým polem jako prvním tvarem na prvním snímku. Kontroluje efektivní názvy písem, včetně zděděných, a nastavuje práh 100 bodů pro části používající Roboto. Tím se zakáže kerning pro odpovídající části s velikostí písma pod 100 bodů:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) {
        for (IPortion portion : paragraph.getPortions()) {
            IPortionFormatEffectiveData portionFormat = portion.getPortionFormat().getEffective();

            if ((portionFormat.getLatinFont() != null &&
                 portionFormat.getLatinFont().getFontName().equals(targetFont)) ||
                (portionFormat.getEastAsianFont() != null &&
                 portionFormat.getEastAsianFont().getFontName().equals(targetFont)) ||
                (portionFormat.getComplexScriptFont() != null &&
                 portionFormat.getComplexScriptFont().getFontName().equals(targetFont))) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci přizpůsobit vykreslování Aspose.Slides vizuálnímu výstupu PowerPointu u písem ovlivněných tímto specifickým chováním PowerPointu.

## **Spravovat vlastnosti písma textu**

Vlastnosti písma lze nastavit na úrovni odstavce pomocí [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) nebo na jednotlivých částech pomocí [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

Následující příklad nastavuje výchozí písmo prvního odstavce na 12bodový Times New Roman s tučným, kurzívním a tečkovaným podtržením. Výslovné formátování na jednotlivých částech má přednost před těmito výchozími nastaveními.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Následující příklad aplikuje 13bodový Times New Roman, kurzívu a tečkované podtržení na části, jejichž efektivní formátování je tučné:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Nastavit vlastnosti písma pro část textu.
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

![Vlastnosti písma pro části textu](font_properties_for_text_portions.png)

## **Kontrola normalizace výšky textu**

Použijte [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) když reprodukujete typografii šablony nebo zkoumáte rozdíly ve výšce znaků. V PowerPointu povolení normalizace roztahuje nebo zmenší jednotlivé znaky ve vertikálním směru, aby měly jednotnou viditelnou výšku v rámci textové části. Nezaručuje stejnou výšku textu napříč různými písmy.

Nastavte vlastnost na [NullableBool.True nebo False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) , aby se normalizace explicitně povolila nebo zakázala. `NullableBool.NotDefined` ponechá místní nastavení nenastavené, takže část zdědí hodnotu, například z [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) odstavce. To neznamená `False`. Použijte [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) a přečtěte [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) , abyste získali vyřešenou boolovskou hodnotu.

Následující samostatný příklad vyžaduje nainstalované **Arial**. Vytváří dva textové bloky obsahující stejné velké a malé písmena, dolní výsuvy a diakritické znaky ve velikosti 54 bodů. Oba odstavce mají výchozí povolenou normalizaci. Horní část ji explicitně zakazuje; spodní část ji dědí. Velikosti rámců, okraje a odstup odstavců jsou identické, s vypnutým zalamováním a automatickým přizpůsobením, aby bylo srovnání konzistentní. Příklad vypíše `False: false` a `NotDefined: true` a poté uloží „text_height_normalization.pptx“.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.False, NullableBool.NotDefined };
    String[] settingNames = { "False", "NotDefined" };

    for (int i = 0; i < settings.length; i++) {
        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 60 + i * 200, 660, 150);
        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame textFrame = shape.getTextFrame();
        textFrame.setText("Hxgjpq ÅÉ 0123");
        textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
        textFrame.getTextFrameFormat().setWrapText(NullableBool.False);
        textFrame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top);
        textFrame.getTextFrameFormat().setMarginTop(0);
        textFrame.getTextFrameFormat().setMarginLeft(0);

        IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceBefore(0);
        paragraph.getParagraphFormat().setSpaceAfter(0);
        paragraph.getParagraphFormat().setSpaceWithin(100);
        paragraph.getParagraphFormat().getDefaultPortionFormat().setNormaliseHeight(NullableBool.True);

        IPortion portion = paragraph.getPortions().get_Item(0);
        FontData font = new FontData("Arial");
        portion.getPortionFormat().setLatinFont(font);
        portion.getPortionFormat().setFontHeight(54);
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
        portion.getPortionFormat().setNormaliseHeight(settings[i]);

        System.out.println(settingNames[i] + ": " + portion.getPortionFormat().getEffective().getNormaliseHeight());
    }

    presentation.save("text_height_normalization.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Porovnání níže bylo exportováno ze uložené prezentace. Horní řádek má normalizaci zakázanou (`False`); spodní řádek dědí povolené nastavení (`NotDefined` → `True`). Pro reprodukci tohoto vzhledu mějte nainstalováno Arial.

![Arial 54bodový text s vypnutou normalizací nahoře a zděděnou zapnutou normalizací dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by měnila přiřazenou hodnotu [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) , která udává velikost písma v bodech. Odstavec [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) řídí řádkování, zatímco textový rám [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) kontroluje, jak se text nebo jeho kontejner přizpůsobuje. Tato nastavení mají různé účely a mohou nezávisle ovlivnit celkové rozvržení. Další informace o formátování odstavců a dědičnosti najdete v [Manage Paragraph](/slides/cs/java/manage-paragraph/).

## **Použít a odstranit přeškrtnutí**

Použijte [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) na část textu k zobrazení oprav, zrušených výrazů nebo předchozích cen bez odstranění původního textu. Nastavte ji na [TextStrikethroughType.Single nebo Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) , pro jednu nebo dvě čáry přes text.

K odstranění přeškrtnutí předávejte [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) . Tím se efekt explicitně zakáže, i když okolní formátování určuje přeškrtnutí. Naopak [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) ponechá místní nastavení nedefinované, což umožní části zdědit formátování, například z odstavce. Nezaručuje, že je přeškrtnutí odstraněno. Použijte [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) , abyste přečetli výsledné formátování včetně zděděných hodnot.

Následující samostatný příklad vytvoří tři srovnání cen. Každý odstavec má oddělené části pro štítek, předchozí cenu a aktuální cenu, takže jen předchozí cena je ovlivněna. V prvním řádku se aplikuje a poté odstraní přeškrtnutí; ostatní řádky zachovávají jednoduché a dvojité přeškrtnutí. Změna tohoto nastavení zachovává text a jeho další formátování, včetně tučné předchozí ceny.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 620, 220);
    shape.getFillFormat().setFillType(FillType.NoFill);
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    shape.getTextFrame().getParagraphs().clear();

    String[] labels = { "None: ", "Single: ", "Double: " };

    for (String label : labels) {
        Paragraph paragraph = new Paragraph();
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left);
        paragraph.getParagraphFormat().setSpaceAfter(20);

        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        format.setFontHeight(28);
        FontData font = new FontData("Arial");
        format.setLatinFont(font);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion labelPortion = new Portion(label);
        paragraph.getPortions().add(labelPortion);

        Portion previousPrice = new Portion("$100");
        previousPrice.getPortionFormat().setFontBold(NullableBool.True);
        paragraph.getPortions().add(previousPrice);
        Portion currentPrice = new Portion(" → $80");
        paragraph.getPortions().add(currentPrice);

        shape.getTextFrame().getParagraphs().add(paragraph);
    }

    IParagraphCollection paragraphs = shape.getTextFrame().getParagraphs();

    // Použít přeškrtnutí, pak jej explicitně odstranit z první předchozí ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek, shora dolů: žádné přeškrtnutí, jednoduché přeškrtnutí a dvojité přeškrtnutí.

![Předchozí ceny bez přeškrtnutí, s jednoduchým přeškrtnutím a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavit otáčení textu**

Použijte [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) , abyste nastavili předdefinovanou orientaci textu uvnitř tvaru.

Následující ukázkový kód nastavuje orientaci textu v tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), což otáčí text **o 90 stupňů proti směru hodinových ručiček**:

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

![Otáčení textu](text_rotation.png)

## **Zobrazit číslice vedle sebe ve svislém textu**

Pro udržení dvouciferného čísla pohromadě ve svislém japonském štítku vložte obě číslice do jedné textové části a zavolejte na ní [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) . Příklad používá [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) a 40bodové MS Gothic pro oba štítky. Pouze hodnota [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) , předaná číselné části, se liší.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    byte[] settings = { NullableBool.True, NullableBool.False };
    float x = 120;

    for (byte kumimoji : settings) {
        IAutoShape label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 48, 120, 420);
        label.getFillFormat().setFillType(FillType.NoFill);
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

        ITextFrame frame = label.addTextFrame("");
        frame.getTextFrameFormat().setTextVerticalType(TextVerticalType.EastAsianVertical);

        IParagraph paragraph = frame.getParagraphs().get_Item(0);
        IPortionFormat format = paragraph.getParagraphFormat().getDefaultPortionFormat();
        FontData font = new FontData("MS Gothic");
        format.setLatinFont(font);
        format.setEastAsianFont(font);
        format.setFontHeight(40);
        format.getFillFormat().setFillType(FillType.Solid);
        format.getFillFormat().getSolidFillColor().setColor(Color.BLACK);

        Portion digits = new Portion("12");
        digits.getPortionFormat().setKumimoji(kumimoji);
        
        paragraph.getPortions().clear();
        paragraph.getPortions().add(new Portion("令和"));
        paragraph.getPortions().add(digits);
        paragraph.getPortions().add(new Portion("年"));

        x += 240;
    }
    presentation.save("vertical_date.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

V PowerPointu levý štítek (`True`) zobrazuje číslice svisle a vedle sebe mezi 和 a 年. V pravém štítku (`False`) je dvojice otočena o 90 stupňů po směru hodinových ručiček. Ostatní japonské znaky zůstávají svislé v obou štítcích.

![Porovnání svislých datových štítků v PowerPointu s svislými číslicemi vlevo a otočenými číslicemi vpravo.](vertical_date.png)

## **Nastavit vlastní otáčení pro textové rámečky**

Použijte [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) , abyste nastavili vlastní úhel otáčení pro [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

Následující ukázkový kód otáčí textový rám o 3 stupně po směru hodinových ručiček uvnitř tvaru:

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

![Vlastní otáčení textu](custom_text_rotation.png)

## **Nastavit řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-) , [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) a [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) , pro řízení odstupů odstavců. Tyto vlastnosti se používají následovně:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad nastavuje vnitřní odstup v první odstavci na 200 % výšky řádku (dvojité řádkování):

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

## **Řídit zalamování řádků**

Pravidla pro zalamování řádků odstavce jsou užitečná v úzkých textových blocích a prezentacích, které kombinují latinku a východoasijské texty. Následující metody patří do [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) , takže se vztahují na celý odstavec:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) řídí pravidla zalamování latinského textu. V smíšeném textu může změna také ovlivnit, kde se zalamuje sousední východoasijský text a interpunkce.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) řídí pravidla zalamování východoasijského textu, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) , která umožňuje automatické zalamování v textovém rámečku. Ovlivňují rozvržení při zalamování; nevkládají znaky pro zalomení řádku. Explicitní zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínštinu a latinku. Explicitně nastaví obě možnosti zalamování řádků a uloží „line_breaking.pptx“. Pro experimentování s některým pravidlem změňte odpovídající hodnotu při zachování ostatních nastavení. Příklad používá 24bodové Arial a SimSun s šířkou rámce 160 bodů a nulovými horizontálními okraji textového rámce. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) je voláno s [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) , aby velikost textu a rozměry rámce zůstaly pevné.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("中文排版测试，PowerPoint 中文演示。");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    FontData eastAsianFont = new FontData("SimSun");
    format.getDefaultPortionFormat().setEastAsianFont(eastAsianFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setLatinLineBreak(NullableBool.False);
    format.setEastAsianLineBreak(NullableBool.True);

    presentation.save("line_breaking.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Řídit visící interpunkci**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) umožňuje oprávněné interpunkci přesáhnout pravý okraj řádku textu místo aby zabírala další řádek. Platí pro celý odstavec a liší se od visícího odsazení.

Následující samostatný příklad zapíná visící interpunkci v 100bodovém širokém textovém rámečku a uloží „hanging_punctuation.pptx“. S 24bodovým Arial a nulovými horizontálními okraji textového rámce zůstane poslední tečka za „sentence“ a přesáhne pravý okraj textu. Nastavte vlastnost na [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) , aby se porovnalo: s těmito nastaveními tečka zabírá samostatný řádek. Zalamování je povoleno a automatické přizpůsobení je vypnuto, aby byla šířka pevná.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200);
    shape.getFillFormat().setFillType(FillType.NoFill);

    ITextFrame textFrame = shape.getTextFrame();
    textFrame.getTextFrameFormat().setWrapText(NullableBool.True);
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.None);
    textFrame.getTextFrameFormat().setMarginLeft(0);
    textFrame.getTextFrameFormat().setMarginRight(0);

    IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
    paragraph.setText("Simple text, next sentence.");

    IParagraphFormat format = paragraph.getParagraphFormat();
    format.setAlignment(TextAlignment.Left);
    format.getDefaultPortionFormat().setFontHeight(24);
    FontData latinFont = new FontData("Arial");
    format.getDefaultPortionFormat().setLatinFont(latinFont);
    format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    format.setHangingPunctuation(NullableBool.True);

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ne každá interpunkční značka může viset. [Podmínky písma a rozvržení popsané výše](#control-line-breaking) se také vztahují na toto srovnání: změna písma, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může rozdíl odstranit.

## **Nastavit typ automatického přizpůsobení pro textové rámečky**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenší, přetéká nebo automaticky mění velikost tvaru. Následující příklad nastaví tvar tak, aby se změnil podle textu, a uloží výsledek do „autofit_type.pptx“.

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak změna šířky textu nebo tvaru ovlivní výsledek, viz [Count Rendered Lines](/slides/cs/java/manage-paragraph/). Počet řádků samotný neukazuje, zda text přesahuje svůj kontejner.

## **Nastavit ukotvení textových rámečků**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) určuje, jak je text umístěn vertikálně uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke spodnímu okraji první části a uloží výsledek do „text_anchor.pptx“.

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

## **Nastavit tabulaci textu**

Použijte [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) , abyste nakonfigurovali tabulátory v odstavci. Následující příklad nastavuje výchozí interval tabulátoru na 100 bodů a přidává levý tabulátor na 30 bodech. Tato nastavení ovlivňují text obsahující tabulátory.

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

## **Nastavit jazyk kontroly**

Aspose.Slides poskytuje [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) , což umožňuje nastavit jazyk kontroly pravopisu pro část textu. Jazyk kontroly určuje jazyk používaný pro kontrolu pravopisu a gramatiky v PowerPointu.

Následující příklad vyžaduje „presentation.pptx“ s textovým polem jako prvním tvarem na prvním snímku a alespoň jedním odstavcem. Nahrazuje obsah prvního odstavce textem „1。」“ , nastaví SimSun jako jeho písmo a přiřadí jazyk kontroly Simplified Chinese (`zh-CN`). Výsledek uloží do „proofing_language.pptx“:

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

    // Nastavit Id jazykové kontroly.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kopírovat metadata jazyka**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) , tak [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) . Následující samostatný příklad vytvoří zdrojovou část s US English jako jazykem a francouzštinou jako alternativním jazykem a zkopíruje text a identifikátory do části v nové prezentaci.

```java
import com.aspose.slides.*;

Portion source = new Portion("Hello! Bonjour!");
source.getPortionFormat().setLanguageId("en-US");
source.getPortionFormat().setAlternativeLanguageId("fr-FR");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion destination = new Portion();
    destination.setText(source.getText());
    destination.getPortionFormat().setLanguageId(source.getPortionFormat().getLanguageId());
    // Pokud zdroj nemá alternativní jazyk, null vymaže hodnotu v cíli.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení "fr-FR". Alternativní identifikátor bude pak `null` a stejné kopírovací prohlášení zachová jeho nepřítomnost, aniž by zavádělo výchozí hodnotu, i když cíl měl předtím přiřazený alternativní jazyk.

Tyto identifikátory jsou uložena jako jazyková metadata. Jejich zachování nestanovuje, který slovník PowerPoint použije pro kontrolu pravopisu nebo gramatiky.

## **Nastavit výchozí jazyk**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) , abyste definovali výchozí jazyk pro text vytvořený při načítání nebo tvorbě prezentace. Následující příklad vytvoří prezentaci s US English jako výchozím jazykem textu, přidá textové pole a vypíše `en-US` pro jeho první část textu.

```java
import com.aspose.slides.*;

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

## **Nastavit výchozí styl textu**

Pro použití výchozího formátování textu na úrovni prezentace použijte [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) .

Následující příklad nastaví 14bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží jej do „default_text_style.pptx“. Text může tyto výchozí hodnoty zdědit, pokud nejsou přepsány konkrétnějším formátováním.

```java
import com.aspose.slides.*;

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

## **Extrahovat text s efektem Všech Velkých Písmen**

V PowerPointu aplikace efektu **All Caps** (všechna velká písmena) způsobí, že se text na snímku zobrazuje velkými písmeny, i když byl původně zadán malými. Když takovou část textu získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Aby se shodoval se zobrazeným textem, zkontrolujte [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) a převoděte vrácený řetězec na velká písmena, pokud je hodnota `All`.

Tento příklad vyžaduje „sample2.pptx“ s textovým polem jako prvním tvarem na prvním snímku. První část prvního odstavce obsahuje „Hello, Aspose!“ s aplikovaným efektem All Caps, jak je zobrazeno níže.

![Efekt All Caps](all_caps_effect.png)

Níže uvedený ukázkový kód ukazuje, jak extrahovat text s aplikovaným efektem **All Caps**:

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

## **FAQ**

**Jak mohu upravit text v tabulce na snímku?**

K úpravě textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) a formátování odstavců pomocí [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) .

**Jak mohu použít gradientní barvu na text na snímku PowerPointu?**

K aplikaci gradientní barvy na text použijte [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) . Nastavte [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) a nakonfigurujte gradientní zastávky, směr a průhlednost.

Související funkce: [Formátovat text v prezentacích](/slides/cs/features/text-formatting/).