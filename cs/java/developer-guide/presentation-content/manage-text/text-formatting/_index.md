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
- mezera mezi znaky
- vlastnosti písma
- rodina písma
- rotace textu
- úhel rotace
- textový rámec
- řádkování
- vlastnost automatického přizpůsobení
- ukotvení textového rámce
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

Tento článek ukazuje, jak formátovat text v prezentacích PowerPoint a OpenDocument pomocí Aspose.Slides pro Java. Pokrývá barvy pozadí, průhlednost, mezery mezi znaky, vlastnosti písem, rotaci, řádkování odstavců, chování automatického přizpůsobení, ukotvení textu, tabulátory a nastavení jazyka.

Pokud není uvedeno jinak, příklady používají [sample.pptx](sample.pptx). První tvar na jeho první snímku je textové pole a jeho první odstavec obsahuje text zobrazený níže. Indexy snímků i tvarů jsou nulové. Příklady, které vybírají tučné úseky, používají efektivní formátování, včetně zděděného tučného formátování:

![Ukázkový text](sample_text.png)

Pro vyhledání a zvýraznění doslovného textu nebo shod regulárního výrazu viz [Vyhledávání a nahrazování textu](/slides/cs/java/search-and-replace-text/).

## **Nastavení barvy pozadí textu**

Použijte [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) k nastavení výchozí barvy zvýraznění pro odstavec nebo použijte [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) pro jednotlivé úseky textu.

Následující příklad nastaví světle šedé zvýraznění jako výchozí pro první odstavec. Explicitní barvy zvýraznění na jednotlivých úsecích mají přednost před touto výchozí hodnotou:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte barvu zvýraznění pro celý odstavec.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Šedý odstavec](gray_paragraph.png)

Ukázka níže demonstruje, jak nastavit barvu pozadí pro **textové úseky s tučným písmem**:

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
            // Nastavte barvu zvýraznění pro textový úsek.
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

Použijte [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) k nastavení zarovnání odstavce v textovém rámečku. Hodnota může být centrovaná, zarovnaná vlevo, vpravo, do bloku a podobně.

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

## **Zarovnání fontů v řádku**

Použijte [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) k vertikálnímu zarovnání úseků textu s různou velikostí písma v řádku. Toto nastavení se vztahuje na celý odstavec a řídí zarovnání v každém jeho řádku.

Následující samostatný příklad vytvoří čtyři označená textová pole na jednom snímku. Každý odstavec obsahuje stejný text ve velikostech 18, 36 a 54 bodů s odlišným zarovnáním písma. Používá Arial, zakazuje automatické přizpůsobení a zalamování a udržuje rámečky dostatečně velké pro jediný řádek.

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

![Porovnání zarovnání Baseline, Top, Center a Bottom při smíšených velikostech fontu](font_alignment.png)

Zarovnání písma používá fontové metriky, takže viditelné okraje jednotlivých znaků se nemusí přesně zarovnat. Příklad zahrnuje velké písmeno i znak s dolním výčnem, aby ukázal rozdíl mezi zarovnáním na základní linii a dole. Dostupnost písma a jeho náhrada, použité znaky a rozdíl ve velikostech fontu ovlivňují výsledek. Rozměry rámečků, okraje, řádkování, zalamování a automatické přizpůsobení také ovlivňují rozvržení; při porovnávání režimů používejte stejná písma a nastavení rozvržení.

Toto nastavení se liší od [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-), které řídí vodorovné zarovnání odstavce, a od [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-), které vertikálně umisťuje textový blok uvnitř tvaru. Formátování horního a dolního indexu pomocí [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) posouvá jednotlivé úseky relativně k základní linii místo nastavení zarovnání písma pro řádky odstavce.

## **Nastavení průhlednosti textu**

Průhlednost textu je řízena alfa složkou barvy přiřazené k [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). V příkladech níže `alpha = 50` představuje hodnotu kanálu alfa ARGB v rozsahu 0–255, ne procento průhlednosti.

Následující ukázka kódu ukazuje, jak aplikovat průhlednost na **celý odstavec**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Nastavte barvu výplně textu na průhlednou barvu.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Průhledný odstavec](transparent_paragraph.png)

Následující ukázka kódu ukazuje, jak aplikovat průhlednost na **textové úseky s tučným písmem**:

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
            // Nastavte průhlednost textového úseku.
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

## **Nastavení mezery mezi znaky textu**

Použijte [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) k rozšíření nebo zmenšení mezery mezi znaky v textovém poli. Příklady přidávají 3 body mezery; záporné hodnoty text zmenšují.

Následující Java kód ukazuje, jak rozšířit mezeru mezi znaky v **celém odstavci**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Poznámka: Použijte záporné hodnoty ke zkompresování mezery mezi znaky.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Rozšířit mezeru mezi znaky.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek:

![Mezera mezi znaky v odstavci](character_spacing_in_paragraph.png)

Ukázka kódu níže ukazuje, jak rozšířit mezeru mezi znaky v **textových úsecích s tučným písmem**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Poznámka: Použijte záporné hodnoty ke zkomprimování mezery mezi znaky.
            portion.getPortionFormat().setSpacing(3); // Rozšířit mezeru mezi znaky.
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

V některých případech může text vykreslený Aspose.Slides vypadat o něco těsněji než stejný text zobrazený v PowerPointu. K tomu může dojít, protože PowerPoint může ignorovat data kerningu pro určité fonty, i když font obsahuje platné informace o kerningu a kerning je v nastavení PowerPointu povolen.

Aby výstup byl vizuálně blíže PowerPointu, můžete zakázat kerning pro úseky textu, které používají dotčený font. Nastavte [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) na hodnotu větší než skutečná velikost fontu. Tento příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na prvním snímku. Kontroluje efektivní názvy fontů, včetně zděděných, a nastavuje prah 100 bodů pro úseky používající Roboto. Tím se zakáže kerning pro odpovídající úseky s velikostí písma pod 100 bodů:

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

Pro text pod prahem toto nastavení zabraňuje kerningu a může pomoci sladit vykreslování Aspose.Slides s vizuálním výstupem PowerPointu u fontů, na které se toto chování PowerPointu vztahuje.

## **Správa vlastností fontu textu**

Vlastnosti fontu lze nastavit na úrovni odstavce pomocí [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) nebo na jednotlivých úsecích pomocí [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/).

Následující příklad nastaví výchozí font prvního odstavce na Times New Roman 12 bodů s tučným, kurzívovým a tečkovaným podtržením. Explicitní formátování na jednotlivých úsecích má přednost před těmito výchozími hodnotami:

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

![Vlastnosti fontu pro odstavec](font_properties_for_paragraph.png)

Následující příklad aplikuje Times New Roman 13 bodů, kurzívu a tečkované podtržení na úseky, jejichž efektivní formátování je tučné:

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

![Vlastnosti fontu pro textové úseky](font_properties_for_text_portions.png)

## **Řízení normalizace výšky textu**

Použijte [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) při reprodukci typografie šablony nebo při zkoumání rozdílů ve výšce znaků. V PowerPointu povolení normalizace protahuje nebo stlačuje jednotlivé znaky vertikálně tak, aby měly jednotnou viditelnou výšku v rámci úseku textu. Nezaručuje však stejnou výšku textu napříč různými fonty.

Nastavte vlastnost na [NullableBool.True nebo False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) pro explicitní povolení nebo zakázání normalizace. `NullableBool.NotDefined` ponechává lokální nastavení nevyplněné, takže úsek zdědí hodnotu například z [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) odstavce. To neznamená `False`. Použijte [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) a přečtěte [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) pro získání vyřešené boolovské hodnoty.

Následující samostatný příklad vyžaduje nainstalovaný **Arial**. Vytvoří dva textové bloky obsahující stejná velká písmena, malá písmena, dolní výčny a diakritiku ve velikosti 54 bodů. Oba odstavce mají výchozí povolenou normalizaci. Horní úsek ji explicitně zakazuje; spodní úsek ji dědí. Velikosti rámečků, okraje a řádkování jsou identické, s vypnutým zalamováním a automatickým přizpůsobením pro zachování konzistence porovnání. Příklad vypíše `False: false` a `NotDefined: true` a uloží soubor "text_height_normalization.pptx".

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

Porovnání níže bylo exportováno ze uložené prezentace. Horní řada má normalizaci zakázanou (`False`); spodní řada ji dědí (`NotDefined` → `True`). Pro reprodukci vzhledu mějte nainstalovaný Arial.

![Arial 54‑bodový text s normalizací zakázanou nahoře a děděnou normalizací povolenou dole](text_height_normalization.png)

Normalizace mění výšku znaků, aniž by měnila přiřazenou hodnotu [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) udávající velikost písma v bodech. Odstavec [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) řídí řádkování, zatímco [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) textového rámečku určuje, jak se text nebo jeho kontejner přizpůsobuje. Tato nastavení slouží různým účelům a mohou nezávisle ovlivnit celkové rozvržení. Více o formátování odstavců a dědičnosti viz [Správa odstavců](/slides/cs/java/manage-paragraph/).

## **Použití a odstranění přeškrtnutí**

Použijte [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) na úsek textu k zobrazení oprav, zrušených výrazů nebo předchozích cen bez smazání originálního textu. Nastavte jej na [TextStrikethroughType.Single nebo Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) pro jednu nebo dvě čáry přes text.

Pro odstranění přeškrtnutí použijte [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None). Tím se explicitně zakáže efekt, i když okolní formátování přeškrtnutí určuje. Naopak [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) ponechává lokální nastavení nedefinované, takže úsek může zdědit formátování, například z odstavce. To nezaručuje, že přeškrtnutí bude odstraněno. Použijte [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) pro přečtení výsledného formátování včetně zděděných hodnot.

Následující samostatný příklad vytvoří tři srovnání cen. Každý odstavec má samostatné úseky pro popisek, předchozí cenu a aktuální cenu, takže pouze předchozí cena je ovlivněna. První řada aplikuje a poté odstraní přeškrtnutí; ostatní řady zachovávají jednoduché a dvojité přeškrtnutí. Změna tohoto nastavení zachovává text i jeho další formátování, včetně tučné předchozí ceny.

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

    // Aplikujte přeškrtnutí, poté jej výslovně odeberte od první předchozí ceny.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Výsledek, shora dolů: bez přeškrtnutí, s jednoduchým přeškrtnutím a s dvojitým přeškrtnutím.

![Předchozí ceny bez přeškrtnutí, s jednoduchým přeškrtnutím a s dvojitým přeškrtnutím](strikethrough.png)

## **Nastavení rotace textu**

Použijte [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) k nastavení předdefinované orientace textu v rámci tvaru.

Následující ukázkový kód nastaví orientaci textu v tvaru na [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/), což otáčí text **90 stupňů proti směru hodinových ručiček**:

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

![Rotace textu](text_rotation.png)

## **Nastavení vlastní rotace pro textové rámečky**

Použijte [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) k nastavení vlastní úhlu rotace pro [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).

Ukázkový kód níže otáčí textový rámek o **3 stupně po směru hodinových ručiček** uvnitř tvaru:

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

![Vlastní rotace textu](custom_text_rotation.png)

## **Nastavení řádkování odstavců**

Aspose.Slides poskytuje [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) a [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) pro řízení řádkování odstavců. Tyto vlastnosti se používají takto:

* Použijte kladnou hodnotu k určení řádkování jako procenta výšky řádku.
* Použijte zápornou hodnotu k určení řádkování v bodech.

Následující příklad nastaví mezeru v rámci prvního odstavce na 200 % výšky řádku (dvojité řádkování):

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

## **Řízení zalamování řádků**

Pravidla zalamování řádků odstavce jsou užitečná v úzkých textových blocích a v prezentacích, které kombinují latinku a východoasijské texty. Následující metody patří do [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/), takže se vztahují na celý odstavec:

- [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) řídí pravidla zalamování řádků pro latinku. V smíšeném textu může změna také ovlivnit, kde se zalamuje sousední východoasijský text a interpunkce.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) řídí pravidla zalamování řádků pro východoasijské jazyky, včetně omezení znaků na začátku a konci řádku.

Tato pravidla nenahrazují [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-), které povoluje automatické zalamování v textovém rámečku. Ovlivňují rozložení, když k zalamování dochází; nevkládají znaky pro nový řádek. Výslovné zalomení řádku vynutí nový řádek v odstavci nezávisle na dostupné šířce.

Následující samostatný příklad vytvoří úzký textový blok obsahující čínštinu a latinku. Nastaví oba parametry zalamování řádků výslovně a uloží soubor "line_breaking.pptx". Pro experimentování s jedním z pravidel změňte odpovídající hodnotu při zachování ostatních nastavení. Příklad používá Arial 24 bodů a SimSun s šířkou rámečku 160 bodů a nulovými horizontálními okraji textového rámečku. [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) je voláno s [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/), aby velikost textu a rozměry rámečku zůstaly pevné.

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

## **Řízení zavěšené interpunkce**

[IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) umožňuje oprávněné interpunkci přesahovat pravý okraj řádku textu místo aby zabírala další řádek. Používá se na celý odstavec a liší se od zavěšeného odsazení.

Následující samostatný příklad povolí zavěšenou interpunkci v textovém rámečku o šířce 100 bodů a uloží soubor "hanging_punctuation.pptx". S Arial 24 bodů a nulovými horizontálními okraji textového rámečku poslední tečka zůstane po slově "sentence" a přesahuje pravý okraj textu. Nastavte vlastnost na [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) pro srovnání: s tímto nastavením tečka zabírá samostatný řádek. Zalamování je povoleno a automatické přizpůsobení vypnuto, aby byla šířka stále stejná.

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

Ne každá interpunkční značka může zavěsit. Podmínky fontu a rozvržení popsané výše ([Řízení zalamování řádků](#control-line-breaking)) platí také pro toto srovnání: změna fontu, dostupné šířky, okrajů nebo nastavení automatického přizpůsobení může odstranit viditelný rozdíl.

## **Nastavení typu automatického přizpůsobení pro textové rámečky**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) určuje, jak se text chová, když přesáhne hranice svého kontejneru. Použijte jej k řízení, zda se text zmenšuje, přetéká nebo automaticky mění velikost tvaru. Následující příklad konfiguruje tvar tak, aby se přizpůsobil textu, a uloží výsledek do souboru "autofit_type.pptx".

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

Pro spočítání řádků po automatickém zalomení a zjištění, jak se mění šířka textu nebo tvar, viz [Počítání vykreslených řádků](/slides/cs/java/manage-paragraph/). Samotný počet řádků neudává, zda text přesahuje svůj kontejner.

## **Nastavení ukotvení textových rámečků**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) určuje, jak je text vertikálně umístěn uvnitř tvaru, například nahoře, uprostřed nebo dole. Následující příklad ukotví text ke spodní části prvního tvaru a uloží výsledek do souboru "text_anchor.pptx".

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

## **Nastavení tabulace textu**

Použijte [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) k nastavení tabulátorů v odstavci. Následující příklad nastaví výchozí interval tabulátoru na 100 bodů a přidá levě zarovnaný tabulátor na 30 bodů. Tato nastavení ovlivňují text obsahující znak tabulátoru.

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

![Záložky odstavce](paragraph_tabs.png)

## **Nastavení jazyka kontroly pravopisu**

Aspose.Slides poskytuje [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-), který umožňuje nastavit jazyk kontroly pravopisu pro úsek textu. Jazyk kontroly určuje jazyk použitého pravopisného a gramatického kontroléra v PowerPointu.

Následující příklad vyžaduje soubor "presentation.pptx" s textovým polem jako prvním tvarem na první slide a alespoň jedním odstavcem. Nahradí obsah prvního odstavce textem "1。", nastaví jako písmo SimSun a přiřadí jazyk kontroly zjednodušené čínštiny (`zh-CN`). Výsledek uloží do souboru "proofing_language.pptx":

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

    // Nastavte Id jazyka kontroly pravopisu.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Kopírování metadat jazyka**

Při kopírování vícejazyčného textu ze šablony zachovejte jak [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--), tak [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--). Následující samostatný příklad vytvoří zdrojový úsek s jazykem US English a alternativním jazykem French a zkopíruje text a identifikátory do úseku v nové prezentaci.

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

Pro vyzkoušení zdroje bez alternativního jazyka vynechte přiřazení `"fr-FR"`. Alternativní identifikátor pak bude `null` a stejný příkaz pro kopírování zachová jeho nepřítomnost, aniž by zaváděl výchozí hodnotu, i kdyby cíl dříve měl alternativní jazyk přiřazen.

Tyto identifikátory jsou uloženy jako jazyková metadata. Zachování neznamená, který slovník PowerPoint vybere pro pravopis nebo gramatiku.

## **Nastavení výchozího jazyka**

Použijte [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) k definování výchozího jazyka pro text vytvářený během načítání nebo tvorby prezentace. Následující příklad vytvoří prezentaci s výchozím jazykem US English, přidá textové pole a vytiskne `en-US` pro jeho první úsek textu.

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

    // Zkontrolujte jazyk prvního úseku.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Nastavení výchozího stylu textu**

Pro nastavení výchozího formátování textu na úrovni prezentace použijte [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--).

Následující příklad nastaví 14‑bodové tučné písmo jako výchozí pro odstavce nejvyšší úrovně v nové prezentaci a uloží jej jako "default_text_style.pptx". Text může tyto výchozí hodnoty zdědit, pokud nejsou přepsány specifickějším formátováním.

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

## **Extrahování textu s efektem Všechna velká**

V PowerPointu způsobí aplikace efektu **Všechna velká** na písmo, že text vypadá na snímku velkými písmeny, i když byl původně zadán malými. Když takový úsek získáte pomocí Aspose.Slides, knihovna vrátí text přesně tak, jak byl zadán. Pro shodu s zobrazeným textem zkontrolujte [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) a při hodnotě `All` převěďte vrácený řetězec na velká písmena.

Tento příklad vyžaduje soubor "sample2.pptx" s textovým polem jako prvním tvarem na první slide. První odstavec jeho prvního úseku obsahuje "Hello, Aspose!" s aplikovaným efektem Všechna velká, jak je znázorněno níže.

![Efekt Všechna velká](all_caps_effect.png)

Ukázka kódu níže ukazuje, jak extrahovat text s aplikovaným efektem **Všechna velká**:

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

**Jak mohu upravit text v tabulce na snímku?**

Pro úpravu textu v tabulce na snímku použijte [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/). Procházejte buňky a aktualizujte každou buňku pomocí [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) a formátování odstavce pomocí [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--).

**Jak mohu použít gradientovou barvu na text v PowerPoint snímku?**

Pro aplikaci gradientové barvy na text použijte [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--). Nastavte [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) na [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) a nakonfigurujte gradientové zastavení, směr a průhlednost.

Související funkce: [Formátování textu v snímcích](/slides/cs/features/text-formatting/).