---
title: Prezentáció szövegének formázása Java-ban
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/java/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtípus tulajdonságai
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegkeret
- sorköz
- automatikus illesztés tulajdonsága
- szövegkeret horgony
- szöveg tabulációja
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával. Testreszabja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Java használatával. Kitér a háttérszínekre, átlátszóságra, karakterközökra, betűtípus‑tulajdonságokra, forgatásra, bekezdésközökre, automatikus illesztés viselkedésére, szövegtördelésre, tabulátorokra és nyelvi beállításokra.

Kivéve, ha másként van feltüntetve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzata egy szövegdoboz, és az első bekezdése tartalmazza az alább látható szöveget. A diák és az alakzat indexei nullával kezdődnek. A félkövér részeket kijelölő példák hatékony formázást használnak, beleértve a örökölt félkövér formázást:

![Sample text](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/java/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelés színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust az egyes szöverrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott kiemelés felülírja ezt az alapértelmezést:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // A teljes bekezdés kiemelés színének beállítása.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The gray paragraph](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel** rendelkező szövegrészekhez:

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
            // A szövegrész kiemelés színének beállítása.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The gray text portions](gray_text_portions.png)

## **Bekezdések igazítása**

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet azt mutatja, hogyan igazítható a bekezdés **középre**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // A bekezdés igazításának beállítása középre.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The aligned paragraph](aligned_paragraph.png)

## **Betűk igazítása soron belül**

Használja az [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) metódust a soron belüli, különböző betűméretű szövegrészek függőleges igazításához. Ez a beállítás a teljes bekezdésre vonatkozik, és minden sorra alkalmazott igazítást szabályozza.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus méretezést és a sortörést, és a szövegkereteket olyan méretűre állítja, hogy csak egy sor férjen bele.

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

Az eredmény:

![Comparison of Baseline, Top, Center, and Bottom font alignment with mixed font sizes](font_alignment.png)

A betűigazítás a betűmetrikákat használja, ezért az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan egymáshoz. A példa tartalmaz egy nagybetűt és egy lejjebb nyúló karaktert, hogy megmutassa a baseline és a bottom igazítás közti különbséget. A betűtípus elérhetősége, helyettesítése, a használt karakterek és a betűméretek közti különbség mind hatással van az eredményre. A keretméretek, margók, sortávolság, sortörés és automatikus illesztés is befolyásolják a elrendezést; a módok összehasonlításakor használjon ugyanazt a betűtípust és elrendezési beállításokat.

Ez a beállítás eltér a [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódustól, amely a vízszintes bekezdés‑igazítást szabályozza, illetve az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metódustól, amely a szövegtömb függőleges pozícióját állítja be az alakzaton belül. A [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) segítségével alkalmazott felső‑ vagy alsó indexelés egyedi részeket mozdít el a baseline‑hoz képest, a bekezdés sorainak betűigazítása helyett.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) által kapott szín alfa komponensén keresztül állítható. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték 0–255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódrészlet azt mutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a szöveg kitöltőszínét átlátszó színre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent paragraph](transparent_paragraph.png)

A következő kódrészlet azt mutatja, hogyan alkalmazható átlátszóság **félkövér betűvel** rendelkező szövegrészekre:

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
            // Állítsa be a szövegrész átlátszóságát.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 0, alpha));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent text portions](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; negatív értékek sűrítik a szöveget.

Az alábbi Java kód megmutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékekkel lehet a karakterközt szűkíteni.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelhető a karakterköz **félkövér betűvel** rendelkező szövegrészekben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékekkel lehet a karakterközt szűkíteni.
            portion.getPortionFormat().setSpacing(3); // Karakterköz növelése.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kicsit szorosabbnak tűnhet, mint a PowerPointban megjelenő szöveg. Ez akkor fordulhat elő, ha a PowerPoint figyelmen kívül hagyja egyes betűtípusok kerning adatait, még ha a betűtípus tartalmaz érvényes kerning információt, és a PowerPoint beállításaiban a kerning engedélyezve van is.

Az ilyen esetekben a kerning letiltásával a szövegrészeken, amelyek az érintett betűtípust használják, a renderelt eredmény közelebb kerülhet a PowerPoint megjelenéséhez. Állítsa a [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét egy a tényleges betűméretnél nagyobb számra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pont küszöbértéket állít be a Roboto betűtípust használó részeknél. Ez a 100 pont alatti betűmérettel rendelkező megfelelő részeknél letiltja a kerninget:

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

Az alacsonyabb küszöb alatti szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint által a betűtípusra vonatkozó specifikus viselkedéshez igazításában.

## **Szöveg betűtípus‑tulajdonságok kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyedi részeken az [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman‑ra állítja be, félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott explicit formázás felülírja ezeket az alapértelmezéseket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // A bekezdés betűtulajdonságainak beállítása.
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

Az eredmény:

![The font properties for the paragraph](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azokban a részekben, amelyek hatékony formázása félkövér:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // A szövegrész betűtulajdonságainak beállítása.
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

Az eredmény:

![The font properties for text portions](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának szabályozása**

Használja az [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) metódust sablon tipográfia reprodukálásakor vagy a karaktermagasságok közti eltérések vizsgálatakor. PowerPoint‑ban a normalizálás engedélyezése függőlegesen nyújtja vagy zsugorítja az egyes karaktereket, hogy az adott szövegrészben egységes látható magasságot kapjanak. Nem garantálja, hogy a különböző betűtípusok szövege ugyanakkora magasságú lesz.

Állítsa a tulajdonságot a [NullableBool.True vagy False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) értékekre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` helyi beállítást értelmetlenül hagyja, így a rész a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) értékét örökli, de ez nem jelenti a `False` értéket. Használja az [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) és a [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) metódusokat a feloldott logikai érték lekéréséhez.

Az alábbi önálló példa **Arial** betűtípus telepítését igényli. Két szövegtömböt hoz létre, amelyek ugyanazokat a nagy- és kisbetűs betűket, lejjebb nyúló karaktereket és ékezetes karaktereket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezetten engedélyezi a normalizálást. A felső rész kifejezetten letiltja, az alsó rész örökli. A keretméretek, margók és bekezdésközök azonosak, a sortörés és az automatikus illesztés le van tiltva a konzisztens összehasonlítás érdekében. A példa a `False: false` és `NotDefined: true` értékeket írja ki, majd elmenti a „text_height_normalization.pptx” fájlt.

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

Az alábbi összehasonlítás a mentett prezentációból származik. A felső sorban a normalizálás le van tiltva (`False`); az alsó sorban örökli az engedélyezett beállítást (`NotDefined` → `True`). A megjelenés reprodukálásához telepítve kell legyen az Arial.

![Arial 54-point text with normalization disabled above and inherited normalization enabled below](text_height_normalization.png)

A normalizálás megváltoztatja a karaktermagasságot anélkül, hogy a [getFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) értéke módosulna, amely a betűméretet pontban adja meg. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) sorközét, a szövegkeret [setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) tulajdonsága pedig a szöveg vagy a konténer méretezését szabályozza. Ezek a beállítások különböző célokra szolgálnak, és önállóan is befolyásolhatják az elrendezést. További információ a bekezdés formázásáról és öröklődéséről a [Manage Paragraph](/slides/hu/java/manage-paragraph/) oldalon található.

## **Áthúzás alkalmazása és eltávolítása**

Használja az [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) metódust egy szövegrészen, hogy hibajavításokat, törölt kifejezéseket vagy korábbi árakat jelenítsen meg a szöveg törlés nélkül. Állítsa a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/) értékre egy vagy két áthúzást a szöveg felett.

Az áthúzás eltávolításához adja meg a [TextStrikethroughType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a hatást, még akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/java/com.aspose.slides/textstrikethroughtype/#NotDefined) helyi beállítást nem definiálja, lehetővé téve a rész számára, hogy a bekezdéstől örökölje a formázást. Ez nem garantálja az áthúzás eltávolítását. Használja az [IPortionFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/#getEffective--) metódust a végső, akár örökölt formázás lekérdezéséhez.

Az alábbi önálló példa három árösszehasonlítást hoz létre. Minden bekezdésnek külön részei vannak a címke, a korábbi ár és a jelenlegi ár számára, így csak a korábbi árra van hatással. Az első sorban alkalmazza, majd eltávolítja az áthúzást; a többi sorban egy- és dupla áthúzás marad. Ennek a beállításnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat.

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

    // Alkalmazz áthúzást, majd kifejezetten távolítsd el az első előző árból.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény felülről lefelé: nincs áthúzás, egyetlen áthúzás, és dupla áthúzás.

![Previous prices without strikethrough, with single strikethrough, and with double strikethrough](strikethrough.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegtájolás beállításához egy alakzaton belül.

Az alábbi kódrészlet a szöveg tájolását a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal óramutató‑ellenes irányba** forgatja:

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

Az eredmény:

![The text rotation](text_rotation.png)

## **Számjegyek egymás melletti megjelenítése függőleges szövegben**

Kétjegyű szám függőleges japán címke esetén a számjegyeket egyetlen szövegrészben kell elhelyezni, majd hívja a [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) metódust azon a részén. A példa a [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/#EastAsianVertical) beállítást és 40 pontos MS Gothic betűtípust használ mindkét címkéhez. A numerikus részhez átadott [NullableBool](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) érték a két címke között különbözik.

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

PowerPointban a bal oldali címke (`True`) a számjegyeket függőlegesen állítja, egymás mellett a 和 és 年 karakterek között. A jobb címke (`False`) esetén a pár 90 fokkal óramutató‑irányban van elforgatva. A környező japán karakterek mindkét címkén álló helyzetben maradnak.

![PowerPoint comparison of vertical date labels with upright digits on the left and rotated digits on the right.](vertical_date.png)

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egy [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) egyéni forgatási szögének beállításához.

Az alábbi kódrészlet a szövegkeretet 3 fokkal óramutató‑irányban forgatja az alakzaton belül:

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

Az eredmény:

![The custom text rotation](custom_text_rotation.png)

## **Bekezdések sorközének beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdésközöket. Ezeket a következőképp használja:

* Pozitív érték esetén a sorköz a sormagasság százalékában adható meg.
* Negatív érték esetén a sorköz pontokban adható meg.

Az alábbi példa a első bekezdés sorközét a sormagasság 200 %-ára (duplázott sorköz) állítja:

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

Az eredmény:

![The line spacing within the paragraph](line_spacing.png)

## **Sorok tördelésének szabályozása**

A bekezdés sorok tördelésének szabályai szűk szövegblokkok és latin‑kelet-ázsiai keveréssel rendelkező prezentációk esetén hasznosak. A következő módszerek az [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) részei, így egy teljes bekezdésre vonatkoznak:

- A [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) szabályozza a latin szövegek sortörését. Kevert szöveg esetén ez befolyásolhatja a szomszédos kelet‑ázsiai szöveg és írásjelek tördelését is.
- A [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) szabályozza a kelet‑ázsiai szövegek sortörését, beleértve a sor elején és végén álló karakterek korlátozásait.

E szabályok nem helyettesítik a [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) metódust, amely automatikus sortörést engedélyez a szövegkeretben. Ők a layoutra hatnak, amikor a sortörés megtörténik; nem szúrnak be sortörés‑karaktert. Egy explicit sortörés új sort hoz létre a bekezdésben, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, majd a „line_breaking.pptx” fájlt menti. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűket használ, a keret szélessége 160 pont, a szövegkeret vízszintes margói pedig nulla. Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metódus a [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) értékre van állítva, hogy a szövegméret és a keret mérete rögzítve maradjon.

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

## **Függőleges idézőjelek kezelése**

Az [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy az elegendő pontozási jelek a sor jobb szélén túlnyúljanak, ahelyett, hogy a következő sorba kerülnének. A beállítás a teljes bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a függőleges idézőjelet, majd a „hanging_punctuation.pptx” fájlt menti. 24 pontos Arial betűtípussal és nulla vízszintes szövegkeret‑margóval a végpont a „sentence” után marad, és túlnyúlik a jobb szövegszegmensen. Állítsa a tulajdonságot a [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) értékre az összehasonlításhoz: ebben az esetben a pont egy külön sorba kerül. A sortörés engedélyezve van, az automatikus illesztés le van tiltva a rendelkezésre álló szélesség rögzítése érdekében.

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

Nem minden írásjel függőlegesen kiállhat. Az [a fentebb leírt betűtípus‑ és layout‑feltételek](#control-line-breaking) szintén alkalmazandók erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusa szövegkeretekhez**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) meghatározza, hogyan viselkedjen a szöveg, ha túllépi a tároló határait. Ennek segítségével szabályozható, hogy a szöveg zsugorodjon, kifolyjon vagy a forma automatikusan átméreteződjön. Az alábbi példa a formát beállítja úgy, hogy a forma mérete a szöveghez igazodjon, majd a „autofit_type.pptx” fájlt menti.

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

Az automatikusan történt sortörés utáni sorok számának és a szöveg vagy forma szélességének változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg kifolyik‑e a tárolóból.

## **Szövegkeretek horgonyának beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) határozza meg, hogyan helyezkedjen el a szöveg függőlegesen egy alakzaton belül, például felül, középen vagy alul. Az alábbi példa a szöveget a első alakzat aljára horgonyozza, majd a „text_anchor.pptx” fájlt menti.

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

## **Tabulátorok beállítása szövegben**

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a bekezdés tabulátor‑állásainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy 30 pontnál balra igazított tabulátort ad hozzá. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szöveget érintik.

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

Az eredmény:

![The paragraph tabs](paragraph_tabs.png)

## **Helyesírás‑ellenőrzési nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódussal teszi lehetővé a szövegrész helyesírás‑ellenőrzési nyelvének beállítását. A helyesírás‑ellenőrzési nyelv határozza meg, melyik nyelv kerül felhasználásra a PowerPointban a helyesírás‑ és nyelvtani ellenőrzéshez.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz, és legalább egy bekezdést tartalmaz. A első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSun‑ra állítja, és a Simplified Chinese helyesírás‑ellenőrzési nyelvet (`zh-CN`) rendeli hozzá. A változtatásokat a „proofing_language.pptx” fájlba menti:

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

    // Állítsa be a helyesírási nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Nyelvi metaadatok másolása**

Többnyelvű szöveg sablonból történő másolásakor meg kell őrizni a [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getLanguageId--) és a [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) értékeket. Az alábbi önálló példa egy forrásrészt hoz létre, amelynek elsődleges nyelve az amerikai angol, alternatív nyelve a francia, majd a szöveget és az azonosítókat egy új prezentációban egy másik részre másolja.

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
        // Ha a forrásnak nincs alternatív nyelve, a null törli a cél értékét.
    destination.getPortionFormat().setAlternativeLanguageId(source.getPortionFormat().getAlternativeLanguageId());
    paragraph.getPortions().add(destination);

    presentation.save("copied_language_metadata.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha nincs alternatív nyelv a forrásban, hagyja el a `"fr-FR"` érték hozzárendelését. Ebben az esetben az alternatív azonosító `null`, és a másolási utasítás megőrzi ennek hiányát anélkül, hogy alapértelmezett értéket hozna létre, még ha a célhely már rendelkezik alternatív nyelvvel is.

Ezek az azonosítók nyelvi metaadatként tárolódnak. Megőrzésük nem határozza meg, melyik szótárat használja a PowerPoint a helyesírás‑ vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvként az amerikai angolt (`en-US`) használja, szövegdobozt ad hozzá, majd az első szövegrész nyelvét kiírja.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Új téglalap alakzat hozzáadása szöveggel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Az első szövegrész nyelvének ellenőrzése.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén történő alapértelmezett szövegformázáshoz használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként a legfelső szintű bekezdésekhez egy új prezentációban, majd a „default_text_style.pptx” fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nem írja felül őket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // A legfelső szintű bekezdésformátum lekérése.
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

## **Szöveg kinyerése All‑Caps hatással**

PowerPointban az **All Caps** betűhatás alkalmazásával a szöveg a dián nagybetűként jelenik meg, még ha eredetileg kisbetűkkel lett beírva is. Az Aspose.Slides‑kel ilyen szövegrészt lekérve a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) értékét, és a visszakapott karakterláncot nagybetűssé konvertálja, amikor a típus `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyre az All Caps hatás alkalmazva van, az alábbi ábrán láthatóan.

![The All Caps effect](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a **All Caps** hatással ellátott szöveg:

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

Kimenet:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **GYIK**

**Hogyan módosítható szöveg egy táblázatban egy dián?**

A táblázat szövegének módosításához használja az [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse őket az [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) segítségével, a bekezdés‑formázást pedig az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) metódussal.

**Hogyan alkalmazhatok színátmenetes színt szövegre egy PowerPoint dián?**

A színátmenetes szín alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa a [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) típusra, és konfigurálja a színátmenet‑állomásokat, irányt és átlátszóságot.

Kapcsolódó funkció: [Format text within slides](/slides/hu/features/text-formatting/).