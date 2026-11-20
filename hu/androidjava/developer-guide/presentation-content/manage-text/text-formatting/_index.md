---
title: Prezentáció szövegének formázása Androidon
linktitle: Szöveg formázása
type: docs
weight: 50
url: /hu/androidjava/text-formatting/
keywords:
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sorköz
- automatikus illesztés tulajdonság
- szövegdoboz horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázható a szöveg PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android for Java használatával. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdésközöket, automatikus illesztést, szöveg‑horgonyozást, tabulátor‑állásokat és nyelvi beállításokat.

Kivéve ha másként van megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dia első alakzatán egy szövegdoboz található, amelynek első bekezdése a lenti szöveget tartalmazza. A dia‑ és alakzat‑indexek nullán‑indulóak. A félkövér részeket kiválasztó példák hatékony formázást használnak, beleértve az öröklött félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezések megtalálásához és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/androidjava/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelés‑szín beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust egyedi szövedrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott kiemelés szín felülírja ezt az alapértelmezést:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a teljes bekezdés kiemelés színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűvel** rendelkező **szövedrészek** számára:

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

![A szürke szövegrészek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet azt mutatja, hogyan igazítható a bekezdés **középre**:

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

![Az igazított bekezdés](aligned_paragraph.png)

## **Betűk igazítása egy soron belül**

Használja az [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és a sorokban lévő szövegrészek igazítását szabályozza.

Az alábbi önálló példa négy címkézett szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontban, eltérő betű‑igazítással. Az Arial‑t használja, letiltja az automatikus illesztést és a tördelést, és a szövegdobozok elég nagyok ahhoz, hogy egy sorba férjenek.

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

![Alap‑vonal, felső, középső és alsó betűigazítás kevert betűméretekkel](font_alignment.png)

A betűigazítás a betűmetrikákat használja, így az egyes betűk látható szélei nem feltétlenül illeszkednek pontosan egymáshoz. A példa tartalmaz egy nagybetűt és egy alsónyúlványt, hogy megmutassa a különbséget az alap‑vonal és az alul‑igazítás között. A betűk elérhetősége és helyettesítése, a használt karakterek, valamint a betűméret‑különbségek befolyásolják az eredményt. A keretméretek, margók, sorköz, tördelés és automatikus illesztés is hat a elrendezésre; a módok összehasonlításakor használja ugyanazokat a betűket és elrendezési beállításokat.

Ez a beállítás különbözik az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódustól, amely a vízszintes bekezdés‑igazítást szabályozza, valamint az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metódustól, amely a szövegblokk függőleges pozícionálását határozza meg az alakzaton belül. A [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) használatával a felső‑ és alsó‑indexelés egyedi részeket mozgat az alapvonalhoz képest, nem a bekezdés sorainak betűigazítását állítja be.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszósága a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--)‑nek hozzárendelt szín alfa‑komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet azt mutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a szöveg kitöltő színét átlátszó színre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet azt mutatja, hogyan alkalmazható átlátszóság **félkövér betűvel** rendelkező szövegrészekre:

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

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása szöveghez**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti térköz növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pontnyi távolságot adnak hozzá; a negatív értékek szűkítik a szöveget.

Az alábbi Java‑kód azt mutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: A karakterköz összenyomásához negatív értékeket használjon.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan növelhető a karakterköz **félkövér betűvel** rendelkező szövegrészekben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: A karakterköz összenyomásához negatív értékeket használjon.
            portion.getPortionFormat().setSpacing(3); // Karakterköz növelése.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása bizonyos betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint‑ban megjelenő szöveg. Ez akkor fordul elő, amikor a PowerPoint figyelmen kívül hagyja bizonyos betűtípusok kerning adatait, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint‑beállításokban engedélyezve van a kerning.

Az ilyen esetekben a PowerPoint‑hoz hasonlóbb megjelenés érdekében letilthatja a kerninget az érintett betűtípusokat használó szövegrészeknél. Állítsa az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél nagyobbra. Ez a példa a „presentation.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be a Roboto‑t használó részeknél. Ez letiltja a kerninget azokban a részekben, ahol a betűméret kisebb, mint 100 pont:

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

A küszöb alatti egyező szövegnél ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelését a PowerPoint‑vizuális kimenetéhez igazítani az ilyen PowerPoint‑specifikus viselkedés által érintett betűtípusoknál.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés‑szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) segítségével.

Az alábbi példa az első bekezdés alapértelmezett betűtípusát 12 pont Times New Roman‑ra állítja be félkövér, dőlt és pontozott aláhúzással. Az egyes részeken megadott formázás felülírja ezeket az alapértelmezéseket:

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

![A bekezdés betűtípus‑tulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pont Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azokban a részekben, amelyek hatékony formázása félkövér:

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

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szövegmagasság normalizálásának vezérlése**

Használja az [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) metódust sablon‑tipográfia reprodukálásakor vagy a karaktermagasság‑különbségek vizsgálatakor. PowerPointban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egységes látható magasságot adjon a szövegrésznek. Nem garantálja a különböző betűk egyenlő magasságát.

Állítsa a tulajdonságot a [NullableBool.True vagy False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) értékek egyikére a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` helyi beállítást üresen hagyja, így a rész örökli az értéket, például a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--)‑ből. Nem ugyanaz, mint a `False`. Használja az [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--)‑t és a [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--)‑t a feloldott Boolean érték lekéréséhez.

Az alábbi önálló példa **Arial**‑t igényel. Két szöveglapot hoz létre, amelyek ugyanazt a nagy‑ és kisbetűs karakterkészletet, lejjebbnyúló betűket és ékezetes karaktereket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezésben engedélyezi a normalizálást. A felső rész kifejezetten letiltja; az alsó rész örökli. A keretméretek, margók és bekezdés‑közök azonosak, a tördelés és automatikus illesztés le van tiltva a konzisztens összehasonlításért. A példa kiírja a `False: false` és `NotDefined: true` értékeket, majd elmenti a „text_height_normalization.pptx” fájlt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

Az alábbi összehasonlítás a mentett prezentációból lett exportálva. A felső sorban a normalizálás le van tiltva (`False`); az alsó sor örökli az engedélyezett beállítást (`NotDefined` → `True`). A megjelenés reprodukálásához telepítve legyen az Arial.

![Arial 54‑pontos szöveg normalizálás nélkül felül és örökölt normalizálással alul](text_height_normalization.png)

A normalizálás a karaktermagasságot változtatja anélkül, hogy megváltoztatná a hozzárendelt [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) értéket, amely a betűméretet pontban adja meg. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) szabályozza a sorközöket, míg a szövegdoboz [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) szabályozza, hogyan igazítja magát a szöveg vagy a tároló. Ezek a beállítások eltérő célokat szolgálnak, és önállóan befolyásolhatják az elrendezést. A bekezdés‑formázás és öröklődés részleteiért lásd a [Manage Paragraph](/slides/hu/androidjava/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használja az [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) metódust egy szövegrész áthúzásához, hogy módosításokat, törölt kifejezéseket vagy korábbi árakat jelenítsen meg a szöveg törlése nélkül. Állítsa a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) értékre egy vagy két vonal megjelenítéséhez.

Az áthúzás eltávolításához adja meg a [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a effektet, még ha a környező formázás áthúzást is meghatározna. Ezzel szemben a [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) helyi beállítást üresen hagyja, lehetővé téve, hogy a rész örökölje a formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás eltűnik. Használja az [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--)‑t a végső formázás, köztük az örökölt értékek lekérdezéséhez.

Az alábbi önálló példa három ár‑összehasonlítást hoz létre. Minden bekezdésben külön részek vannak a címke, a korábbi ár és a jelenlegi ár számára, így csak a korábbi ár érintett. Az első sor alkalmazza, majd eltávolítja az áthúzást; a többi sor egy‑ és dupla‑áthúzást tart meg. Ennek a beállításnak a módosítása megőrzi a szöveget és további formázását, beleértve a félkövér korábbi árat is.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

    // Alkalmazza az áthúzást, majd kifejezetten távolítsa el az első előző árból.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény felülről lefelé: nincs áthúzás, egyszeres áthúzás és dupla áthúzás.

![Korábbi árak áthúzás nélkül, egyszeres áthúzással és dupla áthúzással](strikethrough.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust a szöveg előre definiált tájolásának beállításához egy alakzaton belül.

Az alábbi kódrészlet a szöveg tájolását a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal balra** forgatja a szöveget:

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

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egy egyéni forgásszög beállításához egy [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal óramutató járásával megegyező irányban forgatja az alakzaton belül:

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

![Az egyéni szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés‑távolságot. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sor‑távolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sor‑távolság pontban adható meg.

Az alábbi példa a első bekezdésen belüli távolságot a sormagasság 200 %-ára (dupla sorköz) állítja be:

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

![A sor‑távolság a bekezdésben](line_spacing.png)

## **Sortörés vezérlése**

A bekezdés sortörési szabályai szűk szövegtáblákban és latin‑ és kelet‑ázsiai szöveget keverő prezentációkban hasznosak. A következő metódusok az [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) részei, ezért egész bekezdésre vonatkoznak:

- A [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) a latin sortörési szabályokat szabályozza. Vegyes szövegben a módosítás hatással lehet a szomszédos kelet‑ázsiai szöveg és írásjel tördelésére is.
- A [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) a kelet‑ázsiai sortörési szabályokat szabályozza, beleértve a sor elején és végén lévő karakterek korlátozását.

Ezek a szabályok nem helyettesítik a [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) metódust, amely a szövegdobozon belüli automatikus tördelést engedélyezi. A tördelés során befolyásolják a layoutot; nem szúrnak be sortörés‑karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa egy szűk szövegtáblát hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, és elmenti a „line_breaking.pptx” fájlt. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial‑t és SimSun‑t használ 160 pontos keretszélességgel és nulla vízszintes szövegdoboz‑margóval. A [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) értékkel van meghívva, hogy a szövegméret és a keretméretek rögzítve maradjanak.

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

## **Függőleges írásjelek vezérlése**

Az [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy a jogosult írásjelek a szövegsor jobb szélén túlnyúljanak ahelyett, hogy a következő sorba kerülnek. Ez az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa engedélyezi a függőleges írásjelek használatát egy 100 pontos széles szövegdobozban, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial és nulla vízszintes szövegdoboz‑margók mellett a végpont a „sentence” szó után marad, és a jobb szöveg‑szél túlra nyúlik. Állítsa a tulajdonságot a [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) értékre az összehasonlításhoz: ezekkel a beállításokkal a pont egy külön sorba kerül. A tördelés engedélyezett, az automatikus illesztés le van tiltva a rendelkezésre álló szélesség rögzítése érdekében.

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

Nem minden írásjel függőleges lehet. A fentebb leírt [betű‑ és layout‑feltételek](#control-line-breaking) szintén érvényesek erre az összehasonlításra: a betű, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) meghatározza, hogyan viselkedjen a szöveg, ha meghaladja a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, kikerüljön vagy a forma automatikusan átméreteződjön. Az alábbi példa a forma automatikus átméretezését állítja be, hogy a szöveghez igazodjon, és az eredményt a „autofit_type.pptx” fájlba menti.

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

Az automatikus tördelés után a sorok számlálásához és a szöveg‑ vagy forma‑szélesség változásának megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/androidjava/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg kikerült‑e a tárolóból.

## **Szövegdoboz horgonyának beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) meghatározza, hogyan helyezkedjen el a szöveg függőlegesen egy alakzaton belül, például fent, középen vagy lent. Az alábbi példa a szöveget az első alakzat aljához rögzíti, és az eredményt a „text_anchor.pptx” fájlba menti.

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

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat tabulátor‑állások beállításához egy bekezdésben. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontra. Ezek a beállítások a tabulátor‑karaktert tartalmazó szövegre hatnak.

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

![A bekezdés tabulátorai](paragraph_tabs.png)

## **Helyesírás‑nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódusával lehetővé teszi a helyesírás‑nyelv beállítását egy szövegrészhez. A helyesírás‑nyelv határozza meg, hogy a PowerPoint milyen nyelvet használjon a helyesírás‑ és nyelvtanellenőrzéshez.

Az alábbi példa a „presentation.pptx” fájlt igényli, amely első alakzata egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. A első bekezdés tartalmát „1。”‑re cseréli, a betűtípust SimSun‑ra állítja, és a Simplified Chinese (`zh-CN`) helyesírás‑nyelvet rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

Többnyelvű szöveg sablonból másolásakor meg kell őrizni mind a [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) , mind a [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) értékeket. Az alábbi önálló példa egy forrás‑részt hoz létre, amelynek nyelve az amerikai angol, alternatív nyelve a francia, és a szöveget és az azonosítókat egy új prezentációban lévő részhez másolja.

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

Ha a forrásnak nincs alternatív nyelve, hagyja el a `"fr-FR"` hozzárendelését. Ebben az esetben az alternatív azonosító `null`, és ugyanaz a másolási utasítás megőrzi annak hiányát, anélkül, hogy alapértelmezett értéket vezetne be, még ha a célhely korábban alternatív nyelvet is tartalmazott.

Ezek az azonosítók nyelvi metaadatként vannak tárolva. A megőrzésük nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás‑ vagy nyelvtan‑ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a szöveg alapértelmezett nyelvének meghatározásához prezentáció betöltésekor vagy létrehozásakor. Az alábbi példa az amerikai angolt állítja be alapértelmezett szövegnyelvként, egy szövegdobozt ad hozzá, és az első szövegrésznek `en-US`‑t ír ki.

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjunk hozzá egy új téglalap alakzatot szöveggel.
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50);
    shape.getTextFrame().setText("Sample text");

    // Ellenőrizze az első szövegrész nyelvét.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén az alapértelmezett szövegformázás alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi példa 14 pontos félkövér betűt állít be alapértelmezettként a felső‑szintű bekezdésekhez egy új prezentációban, és elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nem írja felül őket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Kérje le a legfelső szintű bekezdésformátumot.
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

## **Szöveg kinyerése all‑caps hatással**

PowerPointban az **All Caps** betűhatás alkalmazása a szöveget nagybetűsnek jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírva. Amikor az Aspose.Slides ilyen szövegrészt lekéri, a könyvtár pontosan úgy adja vissza a szöveget, ahogyan be lett gépelve. A megjelenített szövegnek megfelelően ellenőrizze a [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha a érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Első bekezdésének első része a „Hello, Aspose!” szöveget tartalmazza, az All Caps hatás alkalmazásával, ahogy az alább látható.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a **All Caps** hatással rendelkező szöveg:

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

**Hogyan módosítható a táblázat szövege egy dián?**

A dián lévő táblázat szövegének módosításához használja az [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse az egyes cellákat az [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) és a bekezdés‑formázást az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazható színátmenet a szövegre egy PowerPoint dián?**

A színátmenet színének alkalmazásához a szövegre használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa a [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) típusra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.