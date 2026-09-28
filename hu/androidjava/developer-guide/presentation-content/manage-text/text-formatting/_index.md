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
- karaktertávolság
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegkeret
- sortávolság
- automatikus illesztés tulajdonság
- szövegkeret rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Android Java-on keresztül. Testreszabhatja a betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet szöveget formázni PowerPoint és OpenDocument bemutatókban az Aspose.Slides for Android Java-on keresztül. Kiterjed a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdés távolságára, automatikus illesztés viselkedésére, szöveg rögzítésre, tabulátorokra és nyelvi beállításokra.

Ha nincs másként megadva, a példák a [sample.pptx](sample.pptx) fájlt használják. Az első dián az első alakzat egy szövegdoboz, és az első bekezdése tartalmazza az alább látható szöveget. A dia- és alakzat indexelése nulláról indul. A félkövér részleteket tartalmazó példák a tényleges formázást használják, beleértve az örökölt félkövér formázást:

![Minta szöveg](sample_text.png)

Az szó szerinti szöveg vagy reguláris kifejezés találatainak kereséséhez és kiemeléséhez lásd a [Search and Replace Text](/slides/hu/androidjava/search-and-replace-text/) oldalt.

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) egyedi szövegrészekhez.

Az alábbi példa világosszürke kiemelést állít be alapértelmezettként az első bekezdéshez. Az egyes részekre beállított explicit kiemelési színek felülírják ezt az alapértelmezést:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a kiemelt színt a teljes bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürkész bekezdés](gray_paragraph.png)

Az alábbi kódpélda bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal rendelkező szövegrészek** számára:

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
        // Állítsa be a kiemelt színt a szövegrészhez.
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

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) a bekezdés igazításának beállításához egy szövegkereten belül. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódpélda megmutatja, hogyan igazítsa a bekezdést **középre**:

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

## **Szöveg átlátszóságának beállítása**

A szöveg átlátszóságát az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) által kapott szín alfa komponensével szabályozzák. Az alábbi példákban az `alpha = 5` egy 0‑255 skálájú ARGB alfa‑csatorna érték, nem átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan alkalmazzon átlátszóságot a **teljes bekezdésre**:

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

![Átlátszó bekezdés](transparent_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan alkalmazzon átlátszóságot **félkövér betűtípussal rendelkező szövegrészekre**:

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

![Átlátszó szövegrészek](transparent_text_portions.png)

## **Karaktertávolság beállítása szövegnél**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy szűkítésére egy szövegdobozban. A példák 3 pont távolságot adnak hozzá; a negatív értékek szűkítik a szöveget.

Az alábbi Java kód megmutatja, hogyan növelje a karaktertávolságot a **teljes bekezdésben**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használata a karaktertávolság szorításához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan növelje a karaktertávolságot **félkövér betűtípussal rendelkező szövegrészekben**:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékek használata a karaktertávolság szorításához.
            portion.getPortionFormat().setSpacing(3); // Karaktertávolság növelése.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő azonos szöveg. Ez akkor történhet, ha a PowerPoint figyelmen kívül hagyja egyes betűtípusok kerning adatait, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve van a kerning.

Az ilyen esetekben a kerning letiltásával a szövegrészeknél, amelyek az érintett betűtípust használják, a renderelt kimenet közelebb kerülhet a PowerPoint megjelenítéséhez. Állítsa az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél nagyobbra. Ez a példa a "presentation.pptx" fájlt igényli, amelynek az első diáján az első alakzat egy szövegdoboz. Ellenőrzi a tényleges betűneveket, beleértve az örökölt betűket, és 100 pont küszöböt állít be azokhoz a részekhez, amelyek a Roboto betűtípust használják. Ez letiltja a kerninget a 100 pont alatti betűmérettel rendelkező egyező részeknél:

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

A küszöb alatti egyező szövegnél ez a beállítás megakadályozza a kerninget, és segíthet összehangolni az Aspose.Slides megjelenítését a PowerPoint vizuális kimenetével az erre a PowerPoint‑specifikus viselkedésre ható betűtípusok esetén.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/) segítségével.

Az alábbi példa a első bekezdés alapértelmezett betűtípusát 12 pontos Times New Roman-ra állítja be félkövér, dőlt és pontozott aláhúzással. Az egyedi részeken megadott explicit formázás felülírja ezeket az alapértelmezéseket:

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

![A bekezdés betűtulajdonságai](font_properties_for_paragraph.png)

Az alábbi példa 13 pontos Times New Roman-t, dőlt formázást és pontozott aláhúzást alkalmaz olyan részekre, amelyek tényleges formázása félkövér:

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

![A szövegrészek betűtulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegorientáció beállításához egy alakzaton belül.

Az alábbi kódpélda a szöveg orientációját a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textverticaltype/) értékre állítja, ami a szöveget **90 fokkal óramutató járásával ellentétesen** forgatja:

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

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egy egyéni forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) számára.

Az alábbi kódpélda a szövegkeretet **3 fokkal** az alakzaton belül óramutató járásával megegyezően forgatja:

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

![Egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides biztosítja az [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokat a bekezdés sortávolságának szabályozásához. Ezeket a következőképpen használják:

* Pozitív érték esetén a sortávolság a sormagasság százalékában kerül megadni.
* Negatív érték esetén a sortávolság pontban kerül megadni.

Az alábbi példa az első bekezdés sortávolságát a sormagasság **200 %**‑ára (dupla sortávolság) állítja be:

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

![A bekezdés sortávolsága](line_spacing.png)

## **Sorok tördelésének szabályozása**

A bekezdés sorok tördelésének szabályai szűk szövegrétegekben és olyan bemutatókban hasznosak, ahol latin és kelet-ázsiai szöveg keveredik. Az alábbi módszerek az [IParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/) részei, így egy teljes bekezdésre vonatkoznak:

- [setLatinLineBreak](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setLatinLineBreak-byte-) szabályozza a latin szöveg tördelését. Vegyes szöveg esetén ennek módosítása a szomszédos kelet‑ázsiai szöveg és írásjelek tördelését is befolyásolhatja.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setEastAsianLineBreak-byte-) szabályozza a kelet‑ázsiai szöveg tördelését, beleértve a sor elején és végén lévő karakterek korlátozását.

Ezek a szabályok nem helyettesítik az [ITextFrameFormat.setWrapText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setWrapText-byte-) beállítást, amely automatikus sortörést engedélyez a szövegkeretben. Ők a tördeléskor befolyásolják a elrendezést; nem szúrnak be sortörés karaktert. Egy explicite sortörés új sort hoz létre a bekezdésben, függetlenül a rendelkezésre álló szélességtől.

Az alábbi önálló példa szűk szövegréteget hoz létre, amely kínai és latin szöveget tartalmaz. Mindkét sortörési beállítást explicit módon megadja, és elmenti a „line_breaking.pptx” fájlt. A szabályok kipróbálásához változtassa meg a megfelelő értéket, miközben a másik beállítást változatlanul hagyja. A példa 24 pontos Arial és SimSun betűket használ, 160 pontos keret szélességet és nullás vízszintes szövegkeret‑marginokat. Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) [TextAutofitType.None](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textautofittype/) értékkel van meghívva, hogy a szövegméret és a keret méretei rögzítve maradjanak:

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

## **Függőleges írásjelek kezelése**

Az [IParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setHangingPunctuation-byte-) lehetővé teszi, hogy egy bizonyos írásjel a sor jobb szélén túlnyúljon, ahelyett, hogy a következő sorra kerülne. Ez az egész bekezdésre vonatkozik, és különbözik a függőleges behúzástól.

Az alábbi önálló példa 100 pont széles szövegkeretben engedélyezi a függőleges írásjelet, és elmenti a „hanging_punctuation.pptx” fájlt. 24 pontos Arial és nullás vízszintes szövegkeret‑marginok mellett a végpont a „sentence” szó után marad, és túlnyúlik a jobb szövegszélre. Állítsa a tulajdonságot [NullableBool.False](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/nullablebool/) értékre a összehasonlításhoz: ebben az esetben a pont külön sorban jelenik meg. A sortörés engedélyezve van, az automatikus illesztés letiltva, hogy a rendelkezésre álló szélesség rögzített maradjon.

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

Nem minden írásjel függőképes. A látható eredmény a betűtípus elérhetőségétől és az elrendezéstől függ: a betűtípus, a rendelkezésre álló szélesség, a margók vagy az automatikus illesztés módosítása eltüntetheti a látható eltérést.

## **Szövegkeretek automatikus illesztésének típusa**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) meghatározza, hogy a szöveg hogyan viselkedjen, ha meghaladja a tartálya határait. Ezzel szabályozható, hogy a szöveg kisebb legyen, túlcsorduljon vagy a shape automatikusan átméreteződjön. Az alábbi példa a shape‑et úgy konfigurálja, hogy a szöveghez igazodva méretezze át, majd elmenti a „autofit_type.pptx” fájlt.

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

A sorok számolásához automatikus sortörés után és a szöveg vagy a shape szélességének változása esetén, lásd a [Count Rendered Lines](/slides/hu/androidjava/manage-paragraph/). A sorok száma önmagában nem jelzi, hogy a szöveg túlcsordul-e a tartályból.

## **Szövegkeretek rögzítésének beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) meghatározza, hogy a szöveg vertikálisan hogyan helyezkedjen el egy alakzaton belül, például a tetején, közepén vagy alján. Az alábbi példa a szöveget az első alakzat aljához rögzíti, majd elmenti a „text_anchor.pptx” fájlt.

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

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a tabulátorok konfigurálásához egy bekezdésben. Az alábbi példa a default tabulátort 100 pontra állítja, és balra igazított tabulátort ad hozzá 30 pontnál. Ezek a beállítások a tab karaktert tartalmazó szövegre vonatkoznak.

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

## **Ellenőrző nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, amellyel egy szövegrész helyesírási nyelvét állíthatja be. A helyesírási nyelv meghatározza, hogy a PowerPoint milyen nyelvet használ a helyesírás‑ és nyelvhelyességi ellenőrzéshez.

Az alábbi példa a "presentation.pptx" fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz, és legalább egy bekezdést tartalmaz. Lecseréli az első bekezdés tartalmát „1。”‑re, a betűtípust SimSun-ra állítja, és a Simplified Chinese ellenőrző nyelvet (`zh-CN`) rendeli hozzá. Az eredményt a „proofing_language.pptx” fájlba menti:

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

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a betöltés vagy létrehozás során létrehozott szöveg alapértelmezett nyelvének meghatározásához. Az alábbi példa egy prezentációt hoz létre, amelynek alapértelmezett szövegnyelvként az amerikai angolt (US English) állítja be, egy szövegdobozt ad hozzá, és az első szövegrész nyelvi kódjaként `en-US`‑t ír ki.

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

A prezentáció szintjén az alapértelmezett szövegformázás alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi példa 14 pontos félkövér betűtípust állít be alapértelmezettként a felső szintű bekezdésekhez egy új prezentációban, majd elmenti a „default_text_style.pptx” fájlt. A szöveg örökölheti ezeket az alapértelmezéseket, hacsak egy specifikusabb formázás nem írja felül őket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Szerezze meg a legfelső szintű bekezdés formátumát.
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

## **Szöveg kinyerése nagybetűs hatással (All‑Caps)**

PowerPointban a **All Caps** betűhatás alkalmazása a szöveget nagybetűvel jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel lett beírva. Amikor az Aspose.Slides visszaad egy ilyen szövegrészt, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beütötték. A megjelenített szöveghez való illeszkedéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textcaptype/) értékét, és szükség esetén alakítsa a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Ez a példa a „sample2.pptx” fájlt igényli, amelynek első diáján az első alakzat egy szövegdoboz. Az első bekezdés első része a „Hello, Aspose!” szöveget tartalmazza, amelyre az All Caps hatás van alkalmazva, ahogy alább látható.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódpélda megmutatja, hogyan nyerje ki a szöveget a **All Caps** hatással:

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

A táblázat szövegének módosításához használja az [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és minden cellát frissítsen az [ICell.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/#getTextFrame--) segítségével, valamint a bekezdésformázást az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazhatok színátmenetet a szövegre egy PowerPoint dián?**

A színátmenet alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa be az [IFillFormat.setFillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) típusra, és konfigurálja a gradient‑állomásokat, irányt és átlátszóságot.