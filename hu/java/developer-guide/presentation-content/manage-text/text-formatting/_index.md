---
title: Prezentáció szövegének formázása Java-ban
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/java/text-formatting/
keywords:
- szöveg kiemelése
- reguláris kifejezés
- bekezdés igazítása
- szövegstílus
- szöveg háttér
- szöveg átlátszósága
- karaktertávolság
- betűtípus tulajdonságok
- betűtípus család
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sortávolság
- automatikus illesztés beállítása
- szövegdoboz horgony
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

Ez a cikk bemutatja, hogyan formázható szöveg PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával. Kitér a kiemelésre, háttérszínekre, átlátszóságra, karaktertávolságra, betűtípus‑tulajdonságokra, forgatásra, bekezdés‑távolságra, automatikus illesztésre, szöveg‑horgonyzásra, tabulátor‑állomásokra és nyelvi beállításokra.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Szöveg kiemelése**

Használja az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-) metódust, ha egy szövegdobozban egy adott mintának megfelelő szöveget kell kiemelni. A metódus kiemelési színt alkalmaz a megtalált szövegrészekre, és a [TextSearchOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/) segítségével szabályozható a keresés módja, például csak teljes szavakra való egyezés.

Az alábbi kódrészlet kiemeli a **"try"** összes előfordulását, majd csak a teljes **"to"** szót.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    // Szerezze meg az első alakzatot az első diáról.
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Emelje ki a "try" szót az alakzatban.
    shape.getTextFrame().highlightText("try", Color.LIGHT_GRAY);

    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);

    // Emelje ki a "to" szót az alakzatban.
    shape.getTextFrame().highlightText("to", Color.MAGENTA, searchOptions, null);

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódus a reguláris kifejezéssel található egyezéseket emeli ki. Java‑ban ez az API az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) felületén érhető el.

Az alábbi kódrészlet kiemeli az összes olyan szót, amely **hétt vagy több karaktert** tartalmaz:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape shape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    java.util.regex.Pattern regex = java.util.regex.Pattern.compile("\\b[^\\s]{7,}\\b");

    // Emelje ki a hét vagy több karakterből álló összes szót.
    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, null);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust, ha a bekezdés alapértelmezett kiemelési színét szeretné beállítani, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust egyedi szövegrétegekhez.

Az alábbi kódrészlet a **teljes bekezdés** háttérszínét állítja be:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a teljes bekezdés kiemelési színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet **félkövér betűtípussal** rendelkező szövegrétegek háttérszínét mutatja be:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
                // Állítsa be a szövegréteg kiemelési színét.
                portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY);
        }
    }

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke szövegrétegek](gray_text_portions.png)

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a szövegdobozon belüli bekezdés‑igazításhoz. Az érték lehet középre, balra, jobbra, sorkizárás stb.

Az alábbi kódrészlet a bekezdést **középre** igazítja:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

A szöveg átlátszóságát a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getFillFormat--)‑hez rendelt szín alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa‑csatorna érték 0‑255 skálán, nem százalékos átlátszóság.

Az alábbi kódrészlet a **teljes bekezdés** átlátszóságát állítja be:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Az alábbi kódrészlet **félkövér betűtípusú** szövegrétegek átlátszóságát mutatja be:

```java
int alpha = 50;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Állítsa be a szövegréteg átlátszóságát.
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

![Az átlátszó szövegrétegek](transparent_text_portions.png)

## **Karaktertávolság beállítása szövegnél**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Java‑kód a **teljes bekezdés** karaktertávolságát növeli:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdés karaktertávolsága](character_spacing_in_paragraph.png)

Az alábbi kódrészlet **félkövér betűtípusú** szövegrétegek karaktertávolságát növeli:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékek használata a karaktertávolság összenyomásához.
            portion.getPortionFormat().setSpacing(3); // Karaktertávolság növelése.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szövegrétegek karaktertávolsága](character_spacing_in_text_portions.png)

### **Kerning letiltása egyes betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint‑ban megjelenített változat. Ennek oka, hogy a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még ha a betűtípus tartalmazza is a megfelelő kerning információkat és a PowerPoint beállításaiban engedélyezve van.

Az ilyen esetekben a renderelt kimenet PowerPoint‑hoz való közelebb hozásához letilthatja a kerninget a problémás betűtípust használó szövegrétegeknél. Állítsa be az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél lényegesen nagyobbra:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrétegekre, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetével való egyeztetésében azoknál a betűtípusoknál, amelyeket ez a PowerPoint‑specifikus viselkedés érint.

## **Szöveg betűtípus‑tulajdonságainak kezelése**

A betűtípus‑tulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyedi részekre az [IPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/) segítségével.

Az alábbi kód a teljes bekezdés betűtípusát és stílusát állítja be: betűméret, félkövér, dőlt, pontozott aláhúzás és a Times New Roman betűtípus minden részére.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a bekezdés betűtípus tulajdonságait.
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

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűtípusú** szövegrétegekre:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Állítsa be a szövegréteg betűtípus tulajdonságait.
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

![A szövegrétegek betűtípus‑tulajdonságai](font_properties_for_text_portions.png)

## **Szöveg forgatása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust, ha előre definiált szövegorientációt szeretne beállítani egy alakzaton belül.

Az alábbi kódrészlet a szövegorientációt `Vertical270`‑re állítja, ami **90 fokkal óramutatóval ellenkező irányba** forgatja a szöveget:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270);

    presentation.save("text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szöveg forgatása](text_rotation.png)

## **Egyedi forgatás szövegdobozoknál**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust, ha egyedi forgatási szöget szeretne beállítani egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) számára.

Az alábbi kódrészlet a szövegdobozt 3 fokkal óramutatóval egyirányban forgatja az alakzaton belül:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setRotationAngle(3);

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az egyedi szövegforgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés távolságait. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban (pt) adható meg.

Az alábbi kódrészlet bemutatja a sortávolság megadását a bekezdésen belül:

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    paragraph.getParagraphFormat().setSpaceWithin(200);

    presentation.save("line_spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A bekezdés sortávolsága](line_spacing.png)

## **Automatikus illesztés típusa szövegdobozoknál**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedjen a szöveg, ha meghaladja a tárolójának határait. Ezzel szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy a forma automatikusan átméreteződjön.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape);

    presentation.save("autofit_type.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegdoboz horgonyának beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) határozza meg, hogyan helyezkedjen el a szöveg függőlegesen egy alakzaton belül, például felül, középen vagy alul.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    autoShape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom);

    presentation.save("text_anchor.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szöveg tabuláció beállítása**

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a tabulátorállomások konfigurálásához egy bekezdésben.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

Az Aspose.Slides biztosítja a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, amely lehetővé teszi a helyesírás‑ és nyelvtan‑ellenőrzés nyelvének beállítását egy szövegréteghez. A nyelv határozza meg, hogy milyen nyelven történik a helyesírás‑ és nyelvtani ellenőrzés a PowerPointban.

Az alábbi kódrészlet megmutatja, hogyan állítsa be a helyesírás‑nyelvet egy szövegréteghez:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    FontData font = new FontData("SimSun");

    Portion textPortion = new Portion();
    textPortion.getPortionFormat().setComplexScriptFont(font);
    textPortion.getPortionFormat().setEastAsianFont(font);
    textPortion.getPortionFormat().setLatinFont(font);

    // Állítsa be a helyesírási nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1.");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust, ha az előadás betöltése vagy létrehozása közben létrehozott szöveg alapértelmezett nyelvét szeretné definiálni.

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("en-US");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Adjunk hozzá egy új téglalap alakzatot szöveggel.
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

Az előadás szintjén az alapértelmezett szövegformázás alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi kódrészlet egy új előadásban minden dián a szöveget 14 pt méretű, félkövér betűtípussal állítja be alapértelmezettként.

```java
Presentation presentation = new Presentation();
try {
    // Szerezze meg a legfelső szintű bekezdésformátumot.
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

PowerPoint‑ban az **All Caps** betűhatás alkalmazása nagybetűs megjelenést kölcsönöz a szövegnek, még ha eredetileg kisbetűvel lett beírva is. Az Aspose.Slides‑szal történő kinyeréskor a könyvtár a ténylegesen beírt szöveget adja vissza. A megjelenített szöveghez való igazításhoz ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textcaptype/) értékét, és ha `All`, akkor alakítsa a visszakapott karakterláncot nagybetűssé.

Tegyük fel, hogy a **sample2.pptx** első diáján a következő szövegdoboz található.

![Az All Caps hatás](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerje ki a **All Caps** hatással rendelkező szöveget:

```java
Presentation presentation = new Presentation("sample2.pptx");
try {
    IAutoShape autoShape = (IAutoShape)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
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

**Hogyan módosítható a szöveg egy dián lévő táblázatban?**

A táblázat szövegének módosításához használja az [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itable/) felületet. Iteráljon a cellákon, és frissítse a cellákat az [ICell.getTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/#getTextFrame--) segítségével, a bekezdésformázást pedig az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getParagraphFormat--) metódussal.

**Hogyan alkalmazhatunk színátmenetet a szövegre egy PowerPoint dián?**

A színátmenethez használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa be az [IFillFormat.setFillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/) típusra, majd konfigurálja a gradient‑állomásokat, az irányt és az átlátszóságot.