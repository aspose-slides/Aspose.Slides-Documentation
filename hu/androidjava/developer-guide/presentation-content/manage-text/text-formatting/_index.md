---
title: Prezentáció szövegének formázása Androidon
linktitle: Szövegformázás
type: docs
weight: 50
url: /hu/androidjava/text-formatting/
keywords:
- bekezdés igazítása
- szöveg stílusa
- szöveg háttere
- szöveg átlátszósága
- karakterköz
- betűtulajdonságok
- betűcsalád
- szöveg forgatása
- forgatási szög
- szövegdoboz
- sorköz
- automatikus méretezés tulajdonsága
- szövegdoboz rögzítése
- szöveg tabuláció
- alapértelmezett nyelv
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Formázza és stilizálja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java segítségével. Testreszabhatja a betűtípusokat, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet formázni a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java-on keresztül. Bemutatja a háttérszíneket, átlátszóságot, karakterközök beállítását, betűtulajdonságokat, forgatást, bekezdésközöket, automatikus méretezést, szöveg rögzítését, tabulátorpozíciókat és nyelvi beállításokat.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A literal szöveg vagy reguláris kifejezés egyezéseinek megtalálásához és kiemeléséhez lásd a [Keresés és csere szöveg](/slides/hu/androidjava/search-and-replace-text/).

## **Szöveg háttérszín beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust, hogy beállítsa egy bekezdés alapértelmezett kiemelési színét, vagy használja az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust egyedi szövegrészekhez.

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín a **teljes bekezdés** esetén:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a kiemelési színt a teljes bekezdéshez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan állítható be a háttérszín **félkövér betűtípussal rendelkező szövegrészek** esetén:

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

## **Szöveg bekezdések igazítása**

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre, balra, jobbra igazított, sorkizárt stb.

Az alábbi kódrészlet bemutatja, hogyan igazítható a bekezdés a **középre**:

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

![A középre igazított bekezdés](aligned_paragraph.png)

## **Szöveg átlátszóság beállítása**

A szöveg átlátszóságát a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) számára beállított szín alfa komponense szabályozza. Az alábbi példákban az `alpha = 50` egy ARGB alfa csatorna érték 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság a **teljes bekezdés** esetén:

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

Az alábbi kódrészlet bemutatja, hogyan alkalmazható átlátszóság **félkövér betűtípussal rendelkező szövegrészek** esetén:

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

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közötti térköz növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Java kód bemutatja, hogyan növelhető a karakterköz a **teljes bekezdés** esetén:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: A karakterköz összenyomásához negatív értékeket használjon.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Bővíti a karakterközt.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karakterköz a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet bemutatja, hogyan növelhető a karakterköz **félkövér betűtípussal rendelkező szövegrészek** esetén:

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
            portion.getPortionFormat().setSpacing(3); // Bővíti a karakterközt.
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

Bizonyos esetekben az Aspose.Slides által megjelenített szöveg kissé szorosabbnak tűnhet, mint a PowerPoint-ban megjelenített ugyanaz a szöveg. Ez azért fordulhat elő, mert a PowerPoint bizonyos betűtípusok esetén figyelmen kívül hagyhatja a kerning adatokat, még akkor is, ha a betűtípus tartalmaz érvényes kerning információt és a kerning be van kapcsolva a PowerPoint beállításaiban.

Az ilyen esetekben, hogy a megjelenített kimenet közelebb legyen a PowerPoint-hoz, letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa be az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét a tényleges betűméretnél lényegesen nagyobbra:

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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelését a PowerPoint vizuális kimenetéhez igazítani a PowerPoint-specifikus viselkedés által érintett betűtípusok esetén.

## **Szöveg betűtulajdonságok kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten a [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) segítségével vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/) segítségével.

Az alábbi kód beállítja a betűtípust és a szövegstílust a teljes bekezdésre: alkalmazza a betűméretet, félkövér, dőlt, pontozott aláhúzást, valamint a Times New Roman betűtípust a bekezdés összes részére.

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

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűtípussal rendelkező szövegrészek** esetén:

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

## **Szöveg forgatás beállítása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust egy előre meghatározott szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet beállítja a szövegorientációt az alakzatban a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textverticaltype/) értékre, amely a szöveget **90 fokkal óramutató járásával ellentétes irányba** forgat:

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

## **Egyéni forgatás beállítása szövegdobozokhoz**

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust, hogy egyedi forgatási szöget állítson be egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) számára.

Az alábbi kódrészlet 3 fokkal forgatja a szövegdobozt az alakzatban óramutató járásával megegyező irányba:

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

![Az egyéni szöveg forgatás](custom_text_rotation.png)

## **Bekezdés sortávolságának beállítása**

Az Aspose.Slides biztosítja a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-), és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokat a bekezdésköz szabályozásához. Ezeket a tulajdonságokat a következőképpen használhatja:

* Pozitív érték használata a sortávolság sormagasság százalékában történő megadásához.
* Negatív érték használata a sortávolság pontban történő megadásához.

Az alábbi kódrészlet bemutatja, hogyan adható meg a sortávolság a bekezdésen belül:

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

## **Automatikus méretezés típus beállítása szövegdobozokhoz**

[ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) meghatározza, hogyan viselkedjen a szöveg, ha meghaladja a tároló határait. Ennek segítségével szabályozható, hogy a szöveg zsugorodjon, túlcsorduljon vagy automatikusan átméretezze az alakzatot.

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

A sorok számolásához automatikus sortördelés után, és hogy a szöveg vagy az alakzat szélessége hogyan változtatja az eredményt, tekintse meg a [Renderelt sorok számlálása](/slides/hu/androidjava/manage-paragraph/). A sorok száma önmagában nem jelzi, hogy a szöveg túllépi-e a tárolót.

## **Szövegdoboz rögzítésének beállítása**

[ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) meghatározza, hogyan helyezkedjen el függőlegesen a szöveg egy alakzatban, például felül, középen vagy alul.

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

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és a [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a bekezdés tabulátorpozícióinak konfigurálásához.

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

## **Javítási nyelv beállítása**

Az Aspose.Slides biztosítja az [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódust, amely lehetővé teszi a javítási nyelv beállítását egy szövegrészhez. A javítási nyelv határozza meg a PowerPoint helyesírás- és nyelvhelyesség-ellenőrzéshez használt nyelvet.

Az alábbi kódrészlet bemutatja, hogyan állítható be a javítási nyelv egy szövegrészhez:

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

    // Állítsa be a javítási nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust, hogy meghatározza a betöltés vagy prezentáció létrehozása során létrehozott szöveg alapértelmezett nyelvét.

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

Az alapértelmezett szövegformázás prezentáció szintű alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi kódrészlet bemutatja, hogyan állítható be egy alapértelmezett félkövér betűtípus 14 pt mérettel az új prezentáció minden diáján lévő összes szöveghez.

```java
import com.aspose.slides.*;

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

## **Szöveg kinyerése minden nagybetűs effektussal**

PowerPointban az **All Caps** (Minden nagybetű) betűeffektus alkalmazása a szöveget nagybetűvel jeleníti meg a dián, még akkor is, ha eredetileg kisbetűvel írták. Amikor ilyen szövegrészt kér le az Aspose.Slides, a könyvtár pontosan úgy adja vissza a szöveget, ahogy beírták. A megjelenített szöveghez igazításhoz alakítsa a visszakapott karakterláncot nagybetűssé, amikor az érték [TextCapType.All](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textcaptype/) van.

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz található:

![A Minden nagybetű effektus](all_caps_effect.png)

Az alábbi kódrészlet bemutatja, hogyan nyerhető ki a szöveg a **Minden nagybetű** effektussal alkalmazva:

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

**Hogyan módosítható a szöveg egy táblázatban egy dián?**

A táblázat szövegének módosításához egy dián, használja az [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) interfészt. Iterálja végig a cellákat, és frissítse minden cellát az [ICell.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/#getTextFrame--) segítségével, valamint a bekezdésformázást az [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) metódussal.

**Hogyan lehet színátmenetes színt alkalmazni szövegre egy PowerPoint-dián?**

A színátmenetes szín szövegre való alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa be az [IFillFormat.setFillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) típusra, és konfigurálja a színátmenet állomásait, irányát és átlátszóságát.