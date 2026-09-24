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
- betűtulajdonságok
- betűcsalád
- szöveg forgatás
- forgatási szög
- szövegdoboz
- sorköz
- automatikus illeszkedés tulajdonság
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Formázza és formálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával. Testreszabhatja a betűket, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget a PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Java használatával. Kitér a háttérszínekre, átlátszóságra, karakterközre, betűtulajdonságokra, forgatásra, bekezdésközre, automatikus illeszkedés viselkedésére, szövegszerkesztésre, tabulátorokra és nyelvi beállításokra.

Az alábbi példákban egy "sample.pptx" nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek megtalálásához és kiemeléséhez lásd [Szöveg keresése és cseréje](/slides/hu/java/search-and-replace-text/).

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust egyedi szövegrészekhez.

Az alábbi kódpélda megmutatja, hogyan állítható be a háttérszín a **teljes bekezdés** esetén:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Az alábbi kódpélda bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal rendelkező szövegrészek** esetén:

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
            // Állítsa be a szövegrész kiemelési színét.
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

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához egy szövegdobozban. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódpélda megmutatja, hogyan igazítható a bekezdés **középre**:

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

A szöveg átlátszóságát a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) által kapott szín alfa komponense vezérli. Az alábbi példákban a `alpha = 50` egy ARGB alfa csatorna érték a 0‑255 skálán, nem átlátszósági százalék.

Az alábbi kódpélda megmutatja, hogyan lehet átlátszóságot alkalmazni a **teljes bekezdés**-re:

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

Az alábbi kódpélda megmutatja, hogyan lehet átlátszóságot alkalmazni **félkövér betűtípussal rendelkező szövegrészek**-re:

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

## **Karakterköz beállítása szövegnél**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közötti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Java kód megmutatja, hogyan lehet növelni a karakterközt a **teljes bekezdés**-ben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: használjon negatív értékeket a karakterköz összenyomásához.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Növeli a karakterközt.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódpélda megmutatja, hogyan lehet növelni a karakterközt **félkövér betűtípussal rendelkező szövegrészek**-ben:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: használjon negatív értékeket a karakterköz összenyomásához.
            portion.getPortionFormat().setSpacing(3); // Növeli a karakterközt.
        }
    }

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a szövegrészekben](character_spacing_in_text_portions.png)

### **Kerning letiltása adott betűtípusoknál**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg valamivel szorosabbnak tűnhet, mint a PowerPoint-ban megjelenített szöveg. Ennek oka lehet, hogy a PowerPoint figyelmen kívül hagyja a kerning adatokat bizonyos betűtípusoknál, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a kerning be van kapcsolva a PowerPoint beállításaiban.

Az ilyen esetekben a renderelt kimenet PowerPoint-hoz való közelebb hozásához letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa be az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét lényegesen nagyobbra, mint a tényleges betűméret:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
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

Ez a beállítás megakadályozza, hogy a kerning alkalmazásra kerüljön a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez való igazításában az érintett betűtípusok esetén.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyes szövegrészeknél a [IPortionFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iportionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a teljes bekezdéshez: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást, valamint a Times New Roman betűtípust a bekezdés minden szövegrészére.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a betűtulajdonságokat a bekezdéshez.
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

Az alábbi kódpélda hasonló tulajdonságokat alkalmaz **félkövér betűtípussal rendelkező szövegrészek**-re:

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

![A betűtulajdonságok a szövegrészekhez](font_properties_for_text_portions.png)

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust előre definiált szövegtájolás beállításához egy alakzatban.

Az alábbi kódpélda a szöveg tájolását `Vertical270`-re állítja az alakzatban, amely a szöveget **90 fokkal óramutató járásával ellentétesen** forgat:

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

## **Egyedi forgatás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egyedi forgatási szög beállításához egy [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) esetén.

Az alábbi kódpélda a szövegdobozt 3 fokkal óramutató járásával megegyező irányban forgatja az alakzatban:

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

![Az egyedi szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides biztosítja a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokat a bekezdés távolságainak vezérléséhez. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték használata a sortávolság a sor magasságának százalékaként való megadásához.
* Negatív érték használata a sortávolság pontokban való megadásához.

Az alábbi kódpélda megmutatja, hogyan adható meg a sortávolság a bekezdésen belül:

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

## **Automatikus illeszkedés típusának beállítása szövegdobozokhoz**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha meghaladja a tároló határait. Használja annak szabályozására, hogy a szöveg zsugorodjon, túllépjen, vagy a forma automatikusan átméreteződjön.

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

A sorok számolásához az automatikus sortörés után, és hogy a szöveg vagy forma szélessége hogyan változtatja az eredményt, lásd a [Renderelt sorok számolása](/slides/hu/java/manage-paragraph/). A sorok száma önmagában nem mutatja meg, hogy a szöveg túlnyúlik-e a tárolóban.

## **Szövegdobozok rögzítésének beállítása**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) határozza meg, hogy a szöveg hogyan helyezkedik el függőlegesen egy alakzatban, például felül, középen vagy alul.

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

## **Szöveg tabuláció beállítása**

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a bekezdés tabulátorok beállításához.

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

Az Aspose.Slides biztosítja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, amely lehetővé teszi a szövegrész ellenőrző nyelvének beállítását. Az ellenőrző nyelv határozza meg a helyesírás- és nyelvtan-ellenőrzéshez használt nyelvet a PowerPointban.

Az alábbi kódpélda megmutatja, hogyan állítható be egy szövegrész ellenőrző nyelve:

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

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához.

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

Az alapértelmezett szövegformázás alkalmazásához a prezentáció szintjén használja a [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi kódpélda megmutatja, hogyan állítható be egy alapértelmezett félkövér betűtípus 14 pt mérettel az új prezentáció minden diáján lévő szöveghez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Szerezze meg a felső szintű bekezdésformátumot.
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

A PowerPointban a **Minden nagybetű** betűtípus-effektus alkalmazásával a szöveg nagybetűs megjelenik a dián, még akkor is, ha eredetileg kisbetűvel lett beírva. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan a beírt szöveget adja vissza. A megjelenített szöveghez igazodva ellenőrizze a [TextCapType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textcaptype/) értékét, és konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték `All`.

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz található:

![A Minden nagybetű hatás](all_caps_effect.png)

Az alábbi kódpélda megmutatja, hogyan nyerhető ki a szöveg a **Minden nagybetű** hatással:

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

**Hogyan módosítható a szöveg egy diában lévő táblázatban?**

A szöveg módosításához egy diában lévő táblázatban használja az [ITable](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itable/) interfészt. Iteráljon a cellákon, és frissítse minden cellát az [ICell.getTextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/icell/#getTextFrame--) segítségével, valamint a bekezdésformázást a [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/iparagraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazható színátmenet a szövegre egy PowerPoint dián?**

A szövegre színátmenet alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa be az [IFillFormat.setFillType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifillformat/#setFillType-byte-) értékét [FillType.Gradient](https://reference.aspose.com/slides/hu/java/com.aspose.slides/filltype/)‑ra, és konfigurálja a gradient állomásokat, irányt és átlátszóságot.