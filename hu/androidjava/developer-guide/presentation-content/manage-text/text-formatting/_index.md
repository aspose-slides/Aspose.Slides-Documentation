---
title: Prezentáció szövegének formázása Androidon
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/androidjava/text-formatting/
keywords:
- szöveg kiemelése
- reguláris kifejezés
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszóság
- karaktertávolság
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sorköz
- automatikus méretezés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java segítségével. Testreszabhatja a betűtípusokat, színeket, igazítást és még sok mást."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java API-jával. Kitér a kiemelésre, háttérszínekre, átlátszóságra, karaktertávolságra, betűtípus‑beállításokra, forgatásra, bekezdés távolságokra, automatikus méretezésre, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozban a következő szöveget tartalmazza:

![Minta szöveg](sample_text.png)

## **Szöveg kiemelése**

Használja a [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame#highlightText-java.lang.String-java.lang.Integer-) metódust, amikor egy adott mintára illeszkedő szöveget kell kiemelni egy szövegdobozban. A metódus a megfelelő szövegrészekhez kiemelő színt alkalmaz, és a [ITextSearchOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextSearchOptions) segítségével szabályozható a keresés módja, például csak teljes szavakra történő illesztés.

Az alábbi kódrészlet mindegyik **„try”** karakterlánc előfordulását kiemeli, majd csak a teljes **„to”** szót.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Az első dia első alakzatának lekérése.
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // A "try" szót emeli ki az alakzatban.
    shape.getTextFrame().highlightText("try", Color.rgb(173, 216, 230));

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // A "to" szót emeli ki az alakzatban.
    int violetColor = Color.rgb(238, 130, 238);
    shape.getTextFrame().highlightText("to", violetColor, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) metódus a reguláris kifejezéssel megtalált egyezéseket emeli ki.

Az alábbi kódrészlet minden **legalább hét karakterből álló** szót kiemeli:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Az összes legalább hét karakterből álló szót emeli ki.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg háttérszín beállítása**

Használja a [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelő színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#getHighlightColor--) metódust egyedi szövegrészekhez.

Az alábbi kódrészlet megmutatja, hogyan állítható be a **teljes bekezdés** háttérszíne:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a teljes bekezdés kiemelési színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a **félkövér betűtípussal rendelkező** szövegrészek háttérszíne:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Állítsa be a kiemelési színt a szövegrészhez.
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

## **Szövegbekezdések igazítása**

Használja a [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#setAlignment-byte-) metódust a szövegdobozban lévő bekezdés igazításához. Az érték lehet középre, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet megmutatja, hogyan igazítható a bekezdés **középre**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

A szöveg átlátszóságát a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) színének alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték a 0‑255 skálán, nem százalékos átlátszóság.

Az alábbi kódrészlet megmutatja, hogyan alkalmazható átlátszóság a **teljes bekezdésre**:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Az alábbi kódrészlet megmutatja, hogyan alkalmazható átlátszóság **félkövér betűtípussal rendelkező** szövegrészekre:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

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

## **Karaktertávolság beállítása a szövegben**

Használja a [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Java kód megmutatja, hogyan növelhető a karaktertávolság a **teljes bekezdésben**:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használata a karaktertávolság szűkítéséhez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet megmutatja, hogyan növelhető a karaktertávolság **félkövér betűtípussal rendelkező** szövegrészekben:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékek használata a karaktertávolság szűkítéséhez.
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

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPointban megjelenő szöveg. Ez akkor fordul elő, ha a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt, és a PowerPoint beállításaiban engedélyezve van a kerning.

Az ilyen esetekben a készített kimenetet a PowerPoint-hoz közelebb hozhatja, ha letiltja a kerninget az érintett betűtípusú szövegrészeknél. Állítsa be az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#setKerningMinimalSize-float-) értékét lényegesen nagyobbra, mint a tényleges betűméret:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    String targetFont = "Roboto";

    for (int paragraphIndex = 0; paragraphIndex < autoShape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
        IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

        for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
            IPortion portion = paragraph.getPortions().get_Item(portionIndex);
            IFontData latinFont = portion.getPortionFormat().getLatinFont();
            IFontData eastAsianFont = portion.getPortionFormat().getEastAsianFont();
            IFontData complexScriptFont = portion.getPortionFormat().getComplexScriptFont();

            boolean usesTargetFont =
                    latinFont != null && targetFont.equals(latinFont.getFontName()) ||
                    eastAsianFont != null && targetFont.equals(eastAsianFont.getFontName()) ||
                    complexScriptFont != null && targetFont.equals(complexScriptFont.getFontName());

            if (usesTargetFont) {
                portion.getPortionFormat().setKerningMinimalSize(100);
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ez a beállítás meggátolja a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelésének a PowerPoint által használt megjelenéshez igazításában azoknál a betűtípusoknál, amelyeket a PowerPoint speciális viselkedése érint.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés szinten a [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#getDefaultPortionFormat--) vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPortionFormat) segítségével.

Az alábbi kód a teljes bekezdés betűtípusát és stílusát állítja be: betűméret, félkövér, dőlt, pontozott aláhúzás és a Times New Roman betűtípus alkalmazása minden részre a bekezdésben.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűtípussal rendelkező** szövegrészekre:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (int portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
        IPortion portion = paragraph.getPortions().get_Item(portionIndex);

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

![A szövegrészek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja a [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setTextVerticalType-byte-) metódust, hogy előre definiált szöveg‑orientációt állítson be egy alakzatban.

Az alábbi kódrészlet a szöveg‑orientációt `Vertical270`‑re állítja, ez **90 fokkal óramutató járásával ellentétesen** forgatja a szöveget:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja a [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setRotationAngle-float-) metódust, hogy egyedi forgatási szöget állítson be egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrame)-hez.

Az alábbi kódrészlet a szövegdobozt **3 fokkal** az óramutató járásával megegyező irányban forgatja az alakzatban:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés távolságait. Ezeket a tulajdonságokat a következő módon kell használni:

* Pozitív érték esetén a sortávolság a sormagasság százalékában kerül megadásra.
* Negatív érték esetén a sortávolság pontban kerül megadásra.

Az alábbi kódrészlet megmutatja, hogyan adható meg a sortávolság a bekezdésen belül:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sortávolság a bekezdésen belül](line_spacing.png)

## **Automatikus méretezés típusának beállítása szövegdobozokhoz**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy a forma automatikusan átméreteződjön.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegdoboz rögzítési pontjának beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITextFrameFormat#setAnchoringType-byte-) meghatározza, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például felül, középen vagy alul.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szöveg tabuláció beállítása**

Használja a [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#setDefaultTabSize-float-) és a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraphFormat#getTabs--) metódusokat a bekezdés tabulátorainak konfigurálásához.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

## **Helyesírás‑ellenőrzés nyelvének beállítása**

Az Aspose.Slides a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#setLanguageId-java.lang.String-) metódussal lehetővé teszi a helyesírás‑ellenőrzés nyelvének beállítását egy szövegrészhez. A nyelv határozza meg, hogy a PowerPoint milyen nyelven végez helyesírás‑ és nyelvtani ellenőrzést.

Az alábbi kódrészlet megmutatja, hogyan állítható be a helyesírás‑ellenőrzés nyelve egy szövegrészhez:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Állítsa be egy helyesírási nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/LoadOptions#setDefaultTextLanguage-java.lang.String-) metódust, hogy meghatározza az alapértelmezett nyelvet a prezentáció betöltése vagy létrehozása során létrehozott szöveghez.

```java
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

Az egész prezentáció szintjén alkalmazandó alapértelmezett szövegformázáshoz használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IPresentation#getDefaultTextStyle--) metódust.

Az alábbi kódrészlet egy alapértelmezett **félkövér** betűtípust állít be 14 pt mérettel az összes dián egy új prezentációban.

```java
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

## **Szöveg kinyerése nagybetűs hatással**

A PowerPointben a **All Caps** (nagybetűs) betűhatás alkalmazása a szöveget nagybetűben jeleníti meg a dián, még akkor is, ha a szöveget eredetileg kisbetűkkel írták. Az Aspose.Slides‑kel ilyen szövegrészt lekérve a könyvtár a beírt szöveget adja vissza. A megjelenített szöveghez való illesztéshez ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/TextCapType) értékét, és ha az `All`, akkor konvertálja a visszakapott karakterláncot nagybetűssé.

Tegyük fel, hogy a **sample2.pptx** első diáján a következő szövegdoboz található.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet megmutatja, hogyan nyerhető ki a szöveg a **All Caps** hatással:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**Hogyan módosítható egy táblázat szövege egy dián?**

A táblázat szövegének módosításához egy dián használja az [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ITable) interfészt. Iteráljon a cellákon, és frissítse őket a [ICell.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ICell#getTextFrame--) segítségével, a bekezdésformázást pedig az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IParagraph#getParagraphFormat--) metódussal.

**Hogyan alkalmazhatók gradient színek a szövegre egy PowerPoint dián?**

Gradient szín alkalmazásához használja a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IBasePortionFormat#getFillFormat--) metódust. Állítsa be az [IFillFormat.setFillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IFillFormat#setFillType-int-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/FillType)-ra, és konfigurálja a gradient állomásokat, irányt és átlátszóságot.