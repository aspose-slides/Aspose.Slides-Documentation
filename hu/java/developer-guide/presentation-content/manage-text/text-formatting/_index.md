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
- szöveg átlátszósága
- karakterköz
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegkeret
- sortávolság
- automatikus méretezés tulajdonság
- szövegkeret horgony
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával. Tárgyalja a háttérszíneket, átlátszóságot, karakterközöket, betűtípus‑tulajdonságokat, forgatást, bekezdés‑közöket, automatikus méretezési viselkedést, szöveg‑horgonyozást, tabulátor‑állásokat és nyelvi beállításokat.

Hacsak másként nincs megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdése az alább látható szöveget tartalmazza. A diák és az alakzat indexei nulláral kezdődnek. A félkövér részeket kiválasztó példák a hatékony formázást alkalmazzák, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

Az eredeti szöveg vagy reguláris kifejezés egyezéseinek kereséséhez és kiemeléséhez tekintse meg a [Szöveg keresése és cseréje](/slides/hu/java/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust az egyes szövegrészekhez.

Az alábbi példa egy világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részeken megadott explicit kiemelési színek felülírják ezt az alapértelmezést:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a kiemelési színt az egész bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípusú szövegrészek** számára:

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
            // Állítsa be a kiemelési színt a szövegrészhez.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
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

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához egy szövegkeretben. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

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

## **Betűtípusok igazítása egy soron belül**

Használja az [IParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setFontAlignment-int-) metódust a különböző betűméretű szövegrészek függőleges igazításához egy sorban. Ez a beállítás az egész bekezdésre vonatkozik, és a soron belüli igazítást szabályozza.

Az alábbi önálló példa négy címkével ellátott szövegdobozt hoz létre egy dián. Minden bekezdés ugyanazt a szöveget tartalmazza 18, 36 és 54 pontos mérettel, különböző betűigazítással. Az Arial betűtípust használja, letiltja az automatikus méretezést és a sortörést, és a szövegkereteket úgy méretezi, hogy egy sor férjen el bennük.

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

![Alapvonal, felső, közép és alsó betűigazítás összehasonlítása vegyes betűméretekkel](font_alignment.png)

A betűigazítás betűmetrikákat használ, ezért az egyes betűk látható szélén nem feltétlenül illeszkednek pontosan egymáshoz. A példa nagybetűt és egy lejjebb nyúló karaktert is tartalmaz, hogy szemléltesse az alapvonal és az alsó igazítás közti különbséget. A betűtípus elérhetősége, helyettesítése, a használt karakterek és a betűméretek különbsége befolyásolják az eredményt. A keret méretei, margók, sorköz, sortörés és automatikus méretezés szintén hatással vannak a megjelenésre; a módok összehasonlításakor ugyanazokat a betűtípusokat és elrendezési beállításokat használja.

Ez a beállítás különbözik a [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódustól, amely a vízszintes bekezdés‑igazítást szabályozza, valamint a [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) metódustól, amely a szövegtömb függőleges pozícióját a alakzaton belül állítja be. A felső indexszel és alsó indexszel történő formázás az [IBasePortionFormat.setEscapement](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setEscapement-float-) segítségével az egyes részeket az alapvonalhoz képest mozdítja el, a bekezdés sorainak betűigazítását nem változtatja meg.

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) színének alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 skálán, nem átlátszósági százalék.

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

![Az átlátszó bekezdés](transparent_paragraph.png)

A következő kódrészlet azt mutatja, hogyan alkalmazható átlátszóság **félkövér betűtípusú szövegrészekre**:

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

![Az átlátszó szövegrészek](transparent_text_portions.png)

## **Karakterköz beállítása a szövegben**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek szorosabbá teszik a szöveget.

Az alábbi Java‑kód azt mutatja, hogyan növelhető a karakterköz a **teljes bekezdésben**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karakterköz növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet azt mutatja, hogyan növelhető a karakterköz **félkövér betűtípusú szövegrészekben**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékek használata a karakterköz összenyomásához.
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

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabbnak tűnhet, mint a PowerPointban megjelenő szöveg. Ez azért történhet, mert a PowerPoint néha figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információkat, és a PowerPoint beállításaiban a kerning engedélyezve van.

A renderelt kimenet PowerPoint‑hoz közeli alakításához letilthatja a kerninget azokban a szövegrészekben, amelyek az érintett betűtípust használják. Állítsa be az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél nagyobbra. Ez a példa a “presentation.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Ellenőrzi a hatékony betűneveket, beleértve az örökölt betűtípusokat, és 100‑pontos küszöböt állít be a Roboto‑t használó részekhez. Ez letiltja a kerninget azokra a részekre, amelyek betűmérete 100 pont alatti:

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

Az alacsonyabb küszöb alatt lévő egyező szöveg esetén ez a beállítás megakadályozza a kerninget, és segíthet az Aspose.Slides renderelését a PowerPoint‑hoz hasonló vizuális kimenettel összehangolni azokra a betűtípusokra, amelyekre ez a PowerPoint‑specifikus viselkedés hatással van.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságokat beállíthatja bekezdés‑szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) segítségével, vagy egyes részeknél az [IPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iportionformat/) használatával.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12‑pont Times New Roman‑ra állítja félkövér, dőlt és pontozott aláhúzással. Az egyes részekre alkalmazott explicit formázás felülírja ezeket az alapértelmezéseket:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a bekezdés betűtípus‑tulajdonságait.
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

Az alábbi példa 13‑pont Times New Roman‑t, dőlt formázást és pontozott aláhúzást alkalmaz azon részekre, amelyek hatékony formázása félkövér:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Állítsa be a szövegrész betűtípus‑tulajdonságait.
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

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust egy alakzatban előre definiált szövegtájolás beállításához.

Az alábbi kódrészlet a szöveg tájolását a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/java/com.aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal óramutatóval ellentétesen** forgatja a szöveget:

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

## **Egyéni forgatás beállítása szövegkeretekhez**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egy [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) egyedi forgatási szögének beállításához.

Az alábbi kódrészlet a szövegkeretet 3 fokkal óramutatóval megyőlegesen forgatja az alakzatban:

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

![Az egyéni szöveg forgatása](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokkal biztosítja a bekezdés‑közötti távolság szabályozását. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi példa a bekezdésen belüli távolságot a sormagasság 200 %-ára (dupla sortávolság) állítja:

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

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Sorok tördelésének szabályozása**

A bekezdés soreltörési szabályai szűk szövegblokkok és olyan prezentációk esetén hasznosak, ahol latin és kelet‑ázsiai szöveg keveredik. Az alábbi módszerek az [IParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/) tagjai, ezért egy teljes bekezdésre vonatkoznak:

- A [setLatinLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) a latin soreltörési szabályokat vezérli. Vegyes szöveg esetén ennek módosítása a kelet‑ázsiai szöveg és írásjelek betörésének helyét is befolyásolhatja.
- A [setEastAsianLineBreak](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) a kelet‑ázsiai soreltörési szabályokat szabályozza, beleértve a sor elején és végén lévő karakterek korlátozásait.

Ezen szabályok nem helyettesítik az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setWrapText-byte-) metódust, amely automatikus sortörést engedélyez a szövegkeretben. A szabályok a layout‑ot befolyásolják, amikor a sortörés megtörténik; nem illesztenek be sorvég‑karaktereket. Egy explicit sortörés új sort hoz létre a bekezdésben a rendelkezésre álló szélességtől függetlenül.

Az alábbi önálló példa egy szűk szövegblokkot hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési opciót explicit módon beállítja, és a “line_breaking.pptx” fájlt menti. A szabályok teszteléséhez módosítsa a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24‑pont Arial‑t és SimSun‑t használ 160‑pont széles kerettel és nulla vízszintes szövegkeret‑margin-nel. Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) metódust a [TextAutofitType.None](https://reference.aspose.com/slides/java/com.aspose.slides/textautofittype/) értékkel hívja meg, hogy a szövegméret és a keretméretek fixen maradjanak:

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

## **Függőleges írásjelek kezelése**

Az [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy az elegendő írásjelek a sor jobb szélén túl nyúljanak, ahelyett, hogy a következő sorban foglalnák el a helyet. Ez az egész bekezdésre vonatkozik, és eltér a függőleges behúzástól.

Az alábbi önálló példa 100‑pont széles szövegkeretben engedélyezi a függőleges írásjelek használatát, és a “hanging_punctuation.pptx” fájlt menti. 24‑pont Arial és nulla vízszintes szövegkeret‑margin mellett a végpont a “sentence” szó után marad, és a jobb szél fölé nyúlik. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/java/com.aspose.slides/nullablebool/) értékre az összehasonlításhoz: ebben a beállításban a pont külön sorba kerül. A sortörés engedélyezett, az automatikus méretezés letiltott, hogy a rendelkezésre álló szélesség fix maradjon.

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

Nem minden írásjel függőleges lehet. A fent leírt [betűtípus‑ és elrendezési feltételek](#control-line-breaking) szintén alkalmazandók erre az összehasonlításra: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus méretezés módosítása eltüntetheti a látható különbséget.

## **AutoFit típus beállítása szövegkeretekhez**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) meghatározza, hogyan viselkedjen a szöveg, ha túllépi a tároló határait. Ezzel vezérelhető, hogy a szöveg zsugorodjon, kicsússzon vagy a alakzat automatikusan átméreteződjön. Az alábbi példa úgy állítja be a alakzatot, hogy a szöveghez igazodva átméreteződjön, és a “autofit_type.pptx” fájlba menti a végeredményt:

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

Az automatikus sortörés utáni sorok számolásához és a szöveg vagy az alakzat szélességének változásának hatásainak megtekintéséhez lásd a [Count Rendered Lines](/slides/hu/java/manage-paragraph/) oldalt. A sorok száma önmagában nem mutatja, hogy a szöveg kilóg-e a tárolóból.

## **Szövegkeretek horgonypontjának beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) meghatározza, hogyan helyeződjön el a szöveg függőlegesen egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljára horgonyozza, majd a “text_anchor.pptx” fájlba menti:

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

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a bekezdés tabulátor‑állásainak konfigurálásához. Az alábbi példa az alapértelmezett tabulátor‑intervallumot 100 pontra állítja, és egy balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tabulátor‑karaktereket tartalmazó szövegre hatnak.

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

## **Helyesírási nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódus segítségével lehetővé teszi a szövegrész helyesírási nyelvének beállítását. A helyesírási nyelv határozza meg, hogy a PowerPoint milyen nyelvet használ a helyesírás- és nyelvtani ellenőrzéshez.

Az alábbi példa a “presentation.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián, és legalább egy bekezdést tartalmaz. Az első bekezdés tartalmát “1。”‑re cseréli, a betűtípust SimSunra állítja, és a Simplified Chinese helyesírási nyelvet (`zh-CN`) rendeli hozzá. A végeredményt a “proofing_language.pptx” fájlba menti:

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

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy olyan prezentációt hoz létre, amelynek alapértelmezett szövegnyelve az amerikai angol, hozzáad egy szövegdobozt, és az első szövegrész nyelvi kódjaként `en-US`‑t ír ki.

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

    // Ellenőrizze az első szövegrész nyelvét.
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    System.out.println(portion.getPortionFormat().getLanguageId());
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett szövegstílus beállítása**

A prezentáció szintjén az alapértelmezett szövegformázás alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi példa 14‑pont félkövér betűtípust állít be az új prezentáció felső‑szintű bekezdéseihez, majd a “default_text_style.pptx” fájlba menti. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak nincs egy specifikusabb formázás, amely felülírja őket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Szerezze be a felső szintű bekezdésformátumot.
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

## **Szöveg kinyerése a minden nagybetűs hatással**

PowerPointban a **All Caps** (Minden nagybetű) betűhatás alkalmazása azt eredményezi, hogy a szöveg a dián nagybetűsen jelenik meg, még akkor is, ha eredetileg kisbetűkkel lett beírva. Az Aspose.Slides‑szel történő lekérdezéskor a könyvtár pontosan úgy adja vissza a szöveget, ahogy be lett gépelve. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/java/com.aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték **All**.

Ez a példa a “sample2.pptx” fájlt igényli, amelynek első alakzata egy szövegdoboz az első dián. Az első bekezdés első része “Hello, Aspose!”‑t tartalmaz **All Caps** hatással, ahogy az alább látható:

![A minden nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a szöveg a **All Caps** hatással:

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

A táblázat szövegének módosításához használja az [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse minden cellát az [ICell.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/icell/#getTextFrame--) és a bekezdésformázást az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazhatok színátmenetes színt a PowerPoint‑dián lévő szövegre?**

A színátmenetes szín alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa az [IFillFormat.setFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/java/com.aspose.slides/filltype/) típusra, és konfigurálja a színátmenet‑állásokat, irányt és átlátszóságot.