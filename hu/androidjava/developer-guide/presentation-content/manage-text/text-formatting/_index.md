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
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegkeret
- sorköz
- automatikus illesztés tulajdonság
- szövegkeret rögzítése
- szövegtabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Formázza és formálja a szöveget a PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java használatával. Testreszabhatja a betűket, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók a szövegek PowerPoint és OpenDocument előadásban az Aspose.Slides for Android Java-n keresztül használva. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdésközre, automatikus illesztés viselkedésére, szövegre vonatkozó rögzítésre, tabulátorokra és nyelvi beállításokra.

Ha nincs másképp megjelölve, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzata egy szövegdoboz, és annak első bekezdése az alább látható szöveget tartalmazza. Mind a diák, mind az alakzat indexei nulla-alapúak. A félkövér részeket választó példák hatékony formázást használnak, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés találatainak kereséséhez és kiemeléséhez lásd a [Szöveg keresése és cseréje](/slides/hu/androidjava/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelés színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust az egyedi szövegrészekhez.

A következő példa világosszürke kiemelést állít be alapértelmezettnek az első bekezdéshez. Az egyes részeknél megadott explicit kiemelés színek felülbírálják ezt az alapértelmezettet:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be az egész bekezdés kiemelés színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

A lenti kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűkkel rendelkező szövegrészek** számára:

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
            // Állítsa be a szövegrész kiemelés színét.
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

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához a szövegkereten belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

A következő kódrészlet bemutatja, hogyan igazítható a bekezdés a **középre**:

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

## **Betűk igazítása soron belül**

Használja az [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) metódust a különböző betűméretű szövegrészek függőleges igazításához egy soron belül. Ez a beállítás az egész bekezdésre vonatkozik, és szabályozza az egyes sorokban lévő igazítást.

A következő önálló példa négy feliratos szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos méretben, különböző betűigazítással. Arial betűtípust használ, letiltja az automatikus illesztést és a sortörést, és a szövegkereteket elegendő méretűre állítja ahhoz, hogy egy sor elférjen:

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

![A betűigazítás (alapvonal, felső, középső, alsó) összehasonlítása vegyes betűméretekkel](font_alignment.png)

A beállítás a betűmetrikákat használja, ezért az egyes betűk látható szélei nem feltétlenül rakodnak pontosan egymáshoz. A példa tartalmaz egy nagybetűt és egy lejjebb nyúló karaktert, hogy megmutassa a baseline és az alja közti különbséget. A betűtípusok elérhetősége és helyettesítése, a felhasznált karakterek, valamint a betűméretek közti különbség mind befolyásolják az eredményt. A keret méretei, margói, sorköz, sortörés és automatikus illesztés is hatással vannak a elrendezésre; a módok összehasonlításakor ugyanazokat a betűket és elrendezési beállításokat használja.

Ez a beállítás különbözik a [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódustól, amely a vízszintes bekezdésigazítást szabályozza, illetve az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metódustól, amely a szövegtömb függőleges pozícióját határozza meg az alakzaton belül. A [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setEscapement-float-) metódussal történő felső- vagy alsó indexelés a betűrészleteket a baseline-hoz képest mozgatja, nem pedig a bekezdés soraira vonatkozó betűigazítást állítja be.

## **Szöveg átlátszóság beállítása**

A szöveg átlátszóságát a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--)-hez rendelt szín alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem átlátszósági százalék.

A lenti kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** esetén:

```java
import com.aspose.slides.*;
import android.graphics.Color;

int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a szöveg kitöltőszínét átlátszó színre.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.argb(alpha, 0, 0, 0));

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet bemutatja, hogyan alkalmazható átlátszóság **félkövér betűkkel rendelkező szövegrészek** esetén:

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

## **Karaktertávolság beállítása a szöveghez**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek összenyomják a szöveget.

A következő Java kód mutatja, hogyan növelhető a karaktertávolság a **teljes bekezdés** esetén:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használatával a karaktertávolság összehúzható.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Bővíti a karaktertávolságot.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

A lenti kódrészlet bemutatja, hogyan növelhető a karaktertávolság **félkövér betűkkel rendelkező szövegrészek** esetén:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékek használatával a karaktertávolság összehúzható.
            portion.getPortionFormat().setSpacing(3); // Bővíti a karaktertávolságot.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Specifikus betűtípusok kerningjének letiltása**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint-ban megjelenő változat. Ez akkor fordul elő, ha a PowerPoint figyelmen kívül hagyja egyes betűtípusok kerning adatait, még akkor is, ha a betűtípus érvényes kerning információt tartalmaz, és a PowerPoint beállításaiban be van kapcsolva a kerning.

Az ilyen helyzetekben a renderelt kimenet PowerPoint közelségének növelése érdekében letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűket, és 100 pontos küszöböt állít be azoknál a részeknél, amelyek a Roboto betűtípust használják. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

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

Az alatti küszöb alatt lévő egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelésének vizuális egyezésében a PowerPoint kimenetével az érintett betűtípusoknál.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) segítségével, vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/) használatával.

A következő példa az első bekezdés alapértelmezett betűjét 12 pontos Times New Romanra állítja be félkövér, dőlt és pontozott aláhúzással. Az egyes részekre alkalmazott explicit formázás felülbírálja ezeket az alapértelmezéseket:

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

![A betűtulajdonságok a bekezdéshez](font_properties_for_paragraph.png)

A következő példa 13 pontos Times New Roman, dőlt formázás és pontozott aláhúzás alkalmazásával formázza azokat a részeket, amelyek hatékony formázása félkövér:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Állítsa be a szövegrész betűtulajdonságait.
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

![A betűtulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **A szöveg magasság normalizálásának vezérlése**

Használja az [IBasePortionFormat.setNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setNormaliseHeight-byte-) metódust sablon tipográfia reprodukálásához vagy a karaktermagasság eltérések vizsgálatához. PowerPointban a normalizálás engedélyezése függőlegesen nyújtja vagy összenyomja az egyes karaktereket, hogy egyenletes látható magasságot adjon a szövegrésznek. Nem garantálja, hogy a különböző betűtípusok szövegei azonos magasságúak lesznek.

Állítsa a tulajdonságot a [NullableBool.True vagy False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) értékekre a normalizálás kifejezett engedélyezéséhez vagy letiltásához. A `NullableBool.NotDefined` helyi beállítást nem definiálja, így a rész az értékét örökli, például a bekezdés [getDefaultPortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) beállításából. Ez nem azt jelenti, hogy `False`. Használja az [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) és olvassa el az [IBasePortionFormatEffectiveData.getNormaliseHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformateffectivedata/#getNormaliseHeight--) értékét a feloldott logikai értékhez.

A következő önálló példa **Arial** telepítését igényli. Két szövegtömböt hoz létre, amelyek ugyanazokat a nagybetűket, kisbetűket, lejjebb nyúló karaktereket és ékezetes karaktereket tartalmazzák 54 pontban. Mindkét bekezdés alapértelmezés szerint engedélyezi a normalizálást. A felső részlet kifejezetten letiltja, az alsó részlet örökli. A keretméretek, margók és bekezdésközök azonosak, a sortörés és az automatikus illesztés letiltva van a konzisztens összehasonlítás érdekében. A példa kiírja a `False: false` és `NotDefined: true` értékeket, majd menti a **text_height_normalization.pptx** fájlt:

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

Az alábbi összehasonlítás a mentett bemutatóból lett exportálva. A felső sor normalizálás nélkül (`False`), az alsó sor örökli a bekapcsolt beállítást (`NotDefined` → `True`). Az eredmény reprodukálásához telepítve legyen az Arial.

![Arial 54-pontos szöveg normalizálás nélkül fent és örökölt normalizálással lent](text_height_normalization.png)

A normalizálás a karaktermagasságot módosítja anélkül, hogy megváltoztatná a hozzárendelt [getFontHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFontHeight--) értéket, amely a betűméretet határozza meg pontban. A bekezdés [setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) a sortávolságot szabályozza, míg a szövegkeret [setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) a szöveg vagy annak tárolója méretezését irányítja. Ezek a beállítások különböző célokat szolgálnak, és önállóan is befolyásolhatják a teljes elrendezést. A bekezdésformázás és öröklődés részletes leírásáért tekintse meg a [Bekezdés kezelése](/slides/hu/androidjava/manage-paragraph/) oldalt.

## **Áthúzás alkalmazása és eltávolítása**

Használja az [IBasePortionFormat.setStrikethroughType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setStrikethroughType-byte-) metódust egy szövegrésznél, ha javításokat, törölt kifejezéseket vagy korábbi árakat szeretne megjeleníteni a szövegben az eredeti szöveg törlése nélkül. Állítsa a [TextStrikethroughType.Single vagy Double](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/) értékre, ha egy vagy két vonalat szeretne a szöveg fölé.

Az áthúzás eltávolításához adja meg a [TextStrikethroughType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#None) értéket. Ez kifejezetten letiltja a hatást, még akkor is, ha a környező formázás áthúzást tartalmaz. Ezzel szemben a [TextStrikethroughType.NotDefined](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textstrikethroughtype/#NotDefined) helyi beállítást nem definiálja, így a rész örökölheti a formázást, például a bekezdéstől. Nem garantálja, hogy az áthúzás eltávolításra kerül. Használja az [IPortionFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--) metódust a végső formázás, beleértve az örökölt értékek lekérdezéséhez.

A következő önálló példa három árösszehasonlítást hoz létre. Minden bekezdésnek külön részei vannak a címkének, a korábbi árnak és a jelenlegi árnak, így csak a korábbi ár érintett. Az első sor áthúzást alkalmaz, majd eltávolít, a többi sor egyes és dupla áthúzást tart meg. Ennek a beállításnak a módosítása megőrzi a szöveget és egyéb formázását, beleértve a félkövér korábbi árat.

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

    // Alkalmazza az áthúzást, majd kifejezetten eltávolítja azt az első előző árból.
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(0).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.None);

    paragraphs.get_Item(1).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Single);
    paragraphs.get_Item(2).getPortions().get_Item(1).getPortionFormat().setStrikethroughType(TextStrikethroughType.Double);

    presentation.save("strikethrough.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény felülről lefelé: nincs áthúzás, egyes áthúzás, dupla áthúzás.

![Korábbi árak áthúzás nélkül, egyes áthúzással és dupla áthúzással](strikethrough.png)

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust, hogy előre definiált szövegorientációt állítson be egy alakzaton belül.

A következő kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

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

## **Számjegyek egymás mellett megjelenítése függőleges szövegben**

Kétjegyű szám függőleges japán címkében való egyben tartásához tegye mindkét számjegyet egy szövegrészbe, és hívja meg az [IBasePortionFormat.setKumimoji](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setKumimoji-byte-) metódust azon a részen. A példa a [TextVerticalType.EastAsianVertical](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textverticaltype/#EastAsianVertical) és 40 pontos MS Gothic betűtípust használ mindkét címkéhez. A numerikus részhez átadott [NullableBool](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) érték a különbség.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

PowerPointban a bal címke (`True`) a számjegyeket függőlegesen és egymás mellett jeleníti meg a 和 és 年 között. A jobb címke (`False`) esetén a párosítás **90 fokkal óramutató járásával megegyezően** forog. A környező japán karakterek mindkét címkén álló helyzetben maradnak.

![PowerPoint összehasonlítás függőleges dátumcímkékkel: bal oldalon álló számjegyek, jobb oldalon forgatott számjegyek](vertical_date.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust, hogy egyéni forgatási szöget állítson be egy [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) számára.

Az alábbi kódrészlet 3 fokos óramutató járásával megegyező forgatást alkalmaz a szövegdobozra az alakzaton belül:

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

## **Bekezdés sorközének beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés sorközét. Ezeket a tulajdonságokat a következőképpen lehet használni:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

A következő példa a első bekezdés sorközét a sormagasság 200 %-ára (dupla sorköz) állítja be:

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

![A sorköz a bekezdésen belül](line_spacing.png)

## **Sortörés szabályainak vezérlése**

A bekezdés sortörés szabályai szűk szövegdobozokban és olyan bemutatókban hasznosak, ahol a latin és az ázsiai szöveg keveredik. A következő metódusok az [IParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/) tagjai, ezért egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) szabályozza a latin sortörés szabályait. Vegyes szöveg esetén a módosítás befolyásolhatja a szomszédos ázsiai szöveg és írásjelek sortörésének helyét is.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) szabályozza az ázsiai sortörés szabályait, beleértve a sor elején és végén megengedett karakterek korlátozását.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) metódust, amely automatikus sortörést engedélyez a szövegdobozon belül. A sortörési szabályok a layoutot befolyásolják, amikor a sortörés bekövetkezik; karaktereket vagy sortörő jeleket nem helyeznek be. Egy explicit sortörés új sort kényszerít a bekezdésen belül, függetlenül a rendelkezésre álló szélességtől.

A következő önálló példa szűk szövegdobozt hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, majd elmenti a **line_breaking.pptx** fájlt. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűket, 160 pontos keretszélességet és nulla horizontális szövegdoboz margót használ. Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metódus a [TextAutofitType.None](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textautofittype/) értékkel van meghívva, hogy a szövegméret és a keretméretek rögzítve maradjanak.

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

Az [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy az elegendő írásjelek a sor jobb szélén túl nyúljanak, ahelyett, hogy a következő sorba kerülnek. A beállítás az egész bekezdésre vonatkozik, és eltér a függőleges behúzástól.

A következő önálló példa 100 pont széles szövegdobozban engedélyezi a függőleges írásjelek használatát, majd elmenti a **hanging_punctuation.pptx** fájlt. 24 pontos Arialrel és nulla horizontális szövegdoboz margóval a végső pont a "sentence" után marad, és a jobb szövegszegmens fölé nyúlik. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/androidjava/com.aspose.slides/nullablebool/) értékre a összehasonlításhoz: ezekkel a beállításokkal a pont külön sorba kerül. A sortörés engedélyezett, az automatikus illesztés letiltott a szélesség fixen tartásához.

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

Nem minden írásjel függhet fel. A fenti **font and layout conditions** leírása (lásd a [Sortörés szabályainak vezérlése](#control-line-breaking) részt) szintén érvényes erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható különbséget.

## **Automatikus illesztés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha túllépi a tároló határait. Ezzel szabályozhatja, hogy a szöveg összezsugorodjon, kilógjon vagy a forma automatikusan átméreteződjön. A következő példa a formát a szöveghez igazítandóan méretezi, és elmenti az eredményt a **autofit_type.pptx** fájlba.

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy a forma szélességének változásának megtekintéséhez tekintse meg a [Megjelenített sorok számlálása](/slides/hu/androidjava/manage-paragraph/) oldalt. A sorok száma önmagában nem jelzi, hogy a szöveg túllépi-e a tárolót.

## **Szövegdobozok rögzítésének beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) határozza meg, hogyan helyezkedik el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. A következő példa a szöveget az első alakzat aljára rögzíti, és elmenti a **text_anchor.pptx** fájlt.

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

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a bekezdés tabulátorainak konfigurálásához. A következő példa az alapértelmezett tabulátor-intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor karaktereket tartalmazó szövegre hatnak.

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

## **Helyesírás-ellenőrzési nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, amely lehetővé teszi a szövegrész helyesírás-ellenőrzési nyelvének beállítását. A helyesírás-ellenőrzési nyelv határozza meg a PowerPointban a helyesírás- és nyelvtani ellenőrzés nyelvét.

A következő példa a **presentation.pptx** fájlt igényli, amelynek első diáján egy szövegdoboz az első alakzatként, és legalább egy bekezdéssel rendelkezik. Lecseréli az első bekezdés tartalmát „1。」” szövegre, a SimSun betűtípust állítja be, és a `zh-CN` (egyszerűsített kínai) helyesírás-ellenőrzési nyelvet rendeli hozzá. Az eredményt a **proofing_language.pptx** fájlba menti:

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

Többnyelvű szöveg sablonból való másolásakor meg kell őrizni mind az [IBasePortionFormat.getLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getLanguageId--) , mind az [IBasePortionFormat.getAlternativeLanguageId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getAlternativeLanguageId--) értékeket. A következő önálló példa egy forrásrészt hoz létre, amelynek nyelve az amerikai angol, alternatív nyelve a francia, és átviszi a szöveget és az azonosítókat egy új prezentáció egy részére.

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

Ha a forrásnak nincs alternatív nyelve, hagyja el a `"fr-FR"` hozzárendelést. Ebben az esetben az alternatív azonosító `null`, és a másolás utasítás megőrzi ennek hiányát anélkül, hogy alapértelmezett értéket vezetne be, még akkor is, ha a célhelyen korábban már lett beállítva alternatív nyelv.

Ezek az azonosítók nyelvi metaadatként vannak tárolva. A megtartásuk nem határozza meg, hogy a PowerPoint melyik szótárat használja a helyesírás- vagy nyelvtani ellenőrzéshez.

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a prezentáció betöltése vagy létrehozása közben létrehozandó szöveg alapértelmezett nyelvének meghatározásához. A következő példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvként az amerikai angolt (en‑US) állítja be, egy szövegdobozt ad hozzá, és kiírja az első szövegrésznek `en-US` értékét.

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

    // Ellenőrizzük az első szövegrész nyelvét.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén alapértelmezett szöveges formázás alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

A következő példa 14 pontos félkövér betűt állít be alapértelmezettként az új prezentáció felső szintű bekezdéseihez, majd elmenti a **default_text_style.pptx** fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, kivéve ha specifikusabb formázás felülbírálja őket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Lekérjük a legfelső szintű bekezdésformátumot.
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

## **Szöveg kinyerése nagybetűs hatással**

PowerPointban a **All Caps** betűhatás alkalmazása a szöveg megjelenését nagybetűssé teszi a diaon, még ha eredetileg kisbetűkkel lett beírás. Amikor az Aspose.Slides-pel ilyen szövegrészt kér le, a könyvtár pontosan a beírt szöveget adja vissza. A megjelenő szöveghez a [TextCapType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textcaptype/) ellenőrzésével és a visszakapott karakterlánc nagybetűssé alakításával kell egyezni, ha az érték `All`.

Ez a példa a **sample2.pptx** fájlt igényli, amelynek első diáján egy szövegdoboz az első alakzatként. Az első bekezdés első része a **Hello, Aspose!** szöveget tartalmazza, amelyre az All Caps hatás van alkalmazva, az alábbiak szerint.

![A nagybetűs hatás](all_caps_effect.png)

A lenti kódrészlet bemutatja, hogyan nyerhető ki a **All Caps** hatással rendelkező szöveg:

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

**Hogyan módosíthatom a szöveget egy dián lévő táblázatban?**

A szöveg módosításához egy dián lévő táblázatban használja a [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse az egyes cellákat az [ICell.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icell/#getTextFrame--) segítségével, valamint a bekezdésformázást az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) metódussal.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához a szövegre használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa az [IFillFormat.setFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/androidjava/com.aspose.slides/filltype/) típusra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.