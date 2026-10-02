---
title: Prezentáció szövegének formázása Androidon
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/androidjava/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegkeret
- sorköz
- automatikus méretezés tulajdonság
- szövegkeret horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Formázza és alakítsa a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java használatával. Testreszabhatja a betűket, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java-on keresztül. Kitér a háttérszínekre, átlátszóságra, karakterközökre, betűtulajdonságokra, forgatásra, bekezdésközökre, automatikus igazításra, szöveghelyzetre, tabulátorokra és nyelvi beállításokra.

Ha nincs másként megjegyezve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzata egy szövegdoboz, és az első bekezdése a lenti szöveget tartalmazza. Mind a diák, mind az alakzat indexei nulláról indulnak. A félkövér szövegrészeket kiválasztó példák a hatékony formázást használják, beleértve az örökölt félkövér formázást:

![Sample text](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés találatainak megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/androidjava/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust az egyes szövegrészekhez.

Az alábbi példában a könnyű szürke kiemelés lesz az első bekezdés alapértelmezett színe. Az egyes részeken megadott kiemelési színek felülbírálják ezt az alapértelmezettet:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a kiemelés színét a teljes bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The gray paragraph](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel rendelkező szöveg-részek** számára:

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
            // Állítsa be a kiemelés színét a szövegrészhez.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LTGRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The gray text portions](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához a szövegkereten belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet azt mutatja be, hogyan igazítható a bekezdés **középre**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a bekezdés igazítását középre.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center);

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The aligned paragraph](aligned_paragraph.png)

## **Betűk igazítása soron belül**

Használja az [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) metódust a soron belül lévő, különböző betűméretű szövegrészek függőleges igazításához. Ez a beállítás az egész bekezdésre vonatkozik, és minden sorában az igazítást szabályozza.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pont méretben, különböző betűigazítással. Az Arial betűtípust használja, letiltja az automatikus méretezést és a tördelést, és a szövegkereteket úgy méretezi, hogy egy sor elférjen bennük.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

A betűigazítás a betűmetrikákat használja, így az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan egymáshoz. A példa tartalmaz egy nagybetűt és egy alsó részgörbét, hogy megmutassa a baseline és a bottom igazítás közti különbséget. A betűtípus elérhetősége, a karakterek és a betűméretkülönbségek is befolyásolják az eredményt. A keret méretei, margói, sorköz, tördelés és az automatikus méretezés szintén hatnak a megjelenésre; a módok összehasonlításához használjon azonos betűtípusokat és elrendezési beállításokat.

Ez a beállítás eltér a [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódustól, amely a vízszintes bekezdésigazítást szabályozza, valamint az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metódustól, amely a szövegblokk függőleges elhelyezkedését határozza meg az alakzaton belül. A [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) segítségével végzett felső- és alsó indexelés egyes részeket a baseline-hez képest mozdít el, a bekezdés sorainak betűigazítását nem változtatja.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) színek alfa komponense vezérli. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték 0–255 skálán, nem pedig átlátszósági százalék.

Az alábbi kódrészlet azt mutatja be, hogyan alkalmazható átlátszóság a **teljes bekezdés**-re:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a szöveg kitöltési színét áttetsző színre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent paragraph](transparent_paragraph.png)

Az alábbi kódrészlet azt mutatja be, hogyan alkalmazható átlátszóság **félkövér betűvel rendelkező szöveg-részek**-re:

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
            // Állítsa be a szövegrész átlátszóságát.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));
        }
    }

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The transparent text portions](transparent_text_portions.png)

## **Karakterköz beállítása szövegnél**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti térköz növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pontnyi távolságot adnak hozzá; a negatív értékek szűkítik a szöveget.

Az alábbi Java kódrészlet azt mutatja be, hogyan növelhető a karakterköz **teljes bekezdés**-ben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékekkel a karakterköz összehúzható.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Növeli a karakterközt.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The character spacing in the paragraph](character_spacing_in_paragraph.png)

Az alábbi kódrészlet azt mutatja be, hogyan növelhető a karakterköz **félkövér betűvel rendelkező szöveg-részek**-ben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékekkel a karakterköz összehúzható.
            portion.getPortionFormat().setSpacing(3); // Növeli a karakterközt.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![The character spacing in the text portions](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusokhoz**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg szorultabbnak tűnhet, mint a PowerPointban megjelenő azonos szöveg. Ez azért fordulhat elő, mert a PowerPoint egyes betűtípusok kerningadatait figyelmen kívül hagyhatja, még akkor is, ha a betűtípus tartalmaz érvényes kerninginformációt, és a PowerPoint beállításaiban a kerning engedélyezve van.

Az ilyen esetekben a PowerPoint megjelenéséhez közelebb hozhatja a renderelt kimenetet, ha letiltja a kerninget olyan szöveg-részeknél, amelyek az érintett betűtípust használják. Állítsa az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél nagyobbra. Ebben a példában a "presentation.pptx" fájlnak kell tartalmaznia egy szövegdobozt, amely az első alakzat az első dián. A hatékony betűneveket (beleértve az örökölt betűket) ellenőrzi, és 100 pontos küszöböt állít be a Roboto-t használó részekhez. Ez letiltja a kerninget azokra a részekre, amelyek betűmérete 100 pont alatt van:

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

A küszöb alatti egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez való igazításában, ha a betűtípusra ez a PowerPoint‑specifikus viselkedés vonatkozik.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók a bekezdés szintjén az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyes részeken az [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) segítségével.

Az alábbi példa a első bekezdés alapértelmezett betűjét 12 pontos Times New Roman-ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott formázás felülírja ezeket az alapértelmezéseket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a bekezdés betűtulajdonságait.
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

Az alábbi példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazását mutatja a hatékonyan félkövérként formázott részekre:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Állítsa be a betűtulajdonságokat a szövegrészhez.
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

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) értékre állítja, amely a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egy [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) egyéni forgatási szögének beállításához.

Az alábbi kódrészlet 3 fokkal óramutató járásával megegyező irányban forgatja el a szövegkeretet az alakzaton belül:

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

## **Bekezdés sorközének beállítása**

Az Aspose.Slides biztosítja az [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokat a bekezdésköz szabályozásához. Ezeket a tulajdonságokat a következőképpen használhatja:

* Pozitív érték megadása a sorköz a sor magasságának százalékában.
* Negatív érték megadása a sorköz pontban.

Az alábbi példa a első bekezdésen belüli sorközöt a sor magasság 200 %-ára (dupla sorköz) állítja:

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

## **Sorszétválasztás szabályainak vezérlése**

A bekezdés sorszétválasztási szabályai szűk szövegdobozokban és kevert latin‑kelet-ázsiai szövegeket tartalmazó prezentációkban lehetnek hasznosak. Az alábbi módszerek az [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) részei, így egy egész bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) a latin sorszétválasztási szabályokat szabályozza. Vegyes szöveg esetén ennek módosítása megváltoztathatja a kelet‑ázsiai szöveg és írásjelek sorvégi elhelyezkedését is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) a kelet‑ázsiai sorszétválasztási szabályokat szabályozza, beleértve azoknak a karaktereknek a korlátozását, amelyek egy sor elején vagy végén állhatnak.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) beállítást, amely automatikus tördelést engedélyez a szövegkeretben. A szabályok a megjelenést befolyásolják, amikor a tördelés megtörténik; nem szúrnak be sortörés karaktert. Egy explicit sor‑törés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sorszétválasztási opciót kifejezetten beállítja, és a „line_breaking.pptx” fájlt menti. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pontos keretszélességgel és nulla vízszintes szövegkeret‑margóval. Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) a [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) értékre van állítva, így a szövegméret és a keretméretek rögzítve maradnak:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Függő írásjelek vezérlése**

Az [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy a jogosult írásjelek a sor jobb szélén túlra nyúljanak, ahelyett, hogy a következő sorba kerülnének. A teljes bekezdésre vonatkozik, és különbözik a függő behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a függő írásjeleket, majd elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial‑t és nulla vízszintes szövegkeret‑margót használva a pont a „sentence” után marad, és a jobb szövegél túlra nyúlik. Állítsa a tulajdonságot a [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorba kerül. A tördelés engedélyezett, az automatikus méretezés letiltott, hogy a rendelkezésre álló szélesség rögzítve maradjon.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Nem minden írásjel futhat fel. A [fenti betű‑ és elrendezési feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés módosítása eltüntetheti a látható különbséget.

## **Autofit típus beállítása szövegkeretekhez**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) meghatározza, hogy a szöveg hogyan viselkedik, ha meghaladja a tárolójának határait. Ezzel szabályozhatja, hogy a szöveg zsugorodjon, túlcsorduljon vagy automatikusan átméretezze az alakzatot. Az alábbi példa úgy konfigurálja a alakzatot, hogy a szöveghez igazodva méretezze újra, majd a „autofit_type.pptx” fájlba menti az eredményt:

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

Az automatikus tördelés utáni sorszám meghatározásához és a szöveg‑ vagy alakzatszélesség változásának hatásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/androidjava/manage-paragraph/). A sorszám önmagában nem mutatja, hogy a szöveg túlcsordul-e a tárolóból.

## **Szövegkeretek horgonyának beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) határozza meg, hogy a szöveg hogyan helyezkedik el függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljára rögzíti, majd a „text_anchor.pptx” fájlba menti az eredményt:

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

## **Szöveg tabulációjának beállítása**

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a tabulátorok beállításához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor karaktereket tartalmazó szövegre hatnak.

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

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, amely lehetővé teszi a szövegrész helyesírási és nyelvtani ellenőrzéséhez használt nyelv beállítását a PowerPointban.

Az alábbi példa a „presentation.pptx” fájlt igényli, amelynek első diáján első alakzata egy szövegdoboz, és legalább egy bekezdése van. A első bekezdés tartalmát „1。”‑re cseréli, a betűtípusa SimSun, a nyelvi ellenőrzés pedig a Simplified Chinese (`zh-CN`). A „proofing_language.pptx” fájlba menti az eredményt:

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

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a betöltés vagy létrehozás során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvéje az amerikai angol, egy szövegdobozt ad hozzá, és az első szövegrész nyelvét `en-US`‑ként írja ki.

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

    // Ellenőrizze az első rész nyelvét.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén az alapértelmezett szövegformázás alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi példa egy 14 pontos félkövér betűt állít be az új prezentáció felső‑szintű bekezdései alapértelmezett stílusaként, majd a „default_text_style.pptx” fájlba menti. A szöveg ezeket az alapértelmezéseket örökölheti, hacsak egy specifikusabb formázás nem írja felül őket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Lekéri a felső szintű bekezdés formátumát.
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

## **Szöveg kinyerése nagykapitális hatással**

A PowerPointban a **All Caps** betűhatás alkalmazása azt eredményezi, hogy a szöveg a dián nagybetűvel jelenik meg, még akkor is, ha eredetileg kisbetűvel írták. Az Aspose.Slides‑szel ilyen szövegrészt lekérve a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) értékét, és a visszaadott karakterláncot nagybetűsre alakítsa, ha az érték **All**.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján első alakzata egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyre az All Caps hatás alkalmazva van, ahogy alább látható.

![The All Caps effect](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **All Caps** hatás alkalmazásával:

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

**Hogyan módosíthatok szöveget egy dián lévő táblázatban?**

A szöveg módosításához egy dián lévő táblázatban használja az [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse minden cellát az [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) segítségével, illetve a bekezdésformázást az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa az [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) típusra, és konfigurálja a színátmenet‑állomásokat, irányt és átlátszóságot.