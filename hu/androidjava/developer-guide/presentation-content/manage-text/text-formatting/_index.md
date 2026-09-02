---
title: "Prezentáció szövegének formázása Androidon"
linktitle: "Szöveg formázása"
type: docs
weight: 50
url: /hu/androidjava/text-formatting/
keywords:
  - "bekezdés igazítása"
  - "szöveg stílusa"
  - "szöveg háttér"
  - "szöveg átlátszóság"
  - "karakter távolság"
  - "betűtulajdonságok"
  - "betűcsalád"
  - "szöveg forgatás"
  - "forgatási szög"
  - "szövegkeret"
  - "sortávolság"
  - "automatikus méretezés tulajdonsága"
  - "szövegkeret rögzítése"
  - "szöveg tabuláció"
  - "alapértelmezett nyelv"
  - "PowerPoint"
  - "OpenDocument"
  - "prezentáció"
  - "Android"
  - "Java"
  - "Aspose.Slides"
description: "Formázza és stílusozza a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java segítségével. Testreszabhatja a betűket, színeket, igazítást és egyebeket."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatja a szöveget PowerPoint és OpenDocument prezentációkban az Aspose.Slides for Android Java-on keresztül. Kitér a háttérszínekre, átlátszóságra, karaktertávolságra, betűtulajdonságokra, forgatásra, bekezdéstávolságra, automatikus méretezésre, szöveg rögzítésére, tabulátorokra és nyelvi beállításokra.

Az alábbi példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

A szó szerinti szöveg vagy reguláris kifejezés egyezéseinek kereséséhez és kiemeléséhez tekintse meg a [Keresés és szöveg csere](/slides/hu/androidjava/search-and-replace-text/) oldalt.

## **Szöveg háttérszínének beállítása**

Használja az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódust a bekezdés alapértelmezett kiemelési színének beállításához, vagy az [IBasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getHighlightColor--) metódust egyedi szövegrészekhez.

Az alábbi kódrészlet a **teljes bekezdés** háttérszínének beállítását mutatja:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Állítsa be a teljes bekezdés kiemelésének színét.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LTGRAY);

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A szürke bekezdés](gray_paragraph.png)

Az alábbi kódrészlet **félkövér betűkkel** ellátott szövegrészek háttérszínének beállítását mutatja:

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
            // Állítsa be a szövegrész kiemelésének színét.
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

Használja az [IParagraphFormat.setAlignment](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setAlignment-int-) metódust a bekezdés igazításának beállításához egy szövegdobozon belül. Az érték lehet középre igazított, balra, jobbra, sorkizárt stb.

Az alábbi kódrészlet a bekezdés **középre** igazítását mutatja:

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

A szöveg átlátszósága a [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) szín alfa komponensén keresztül szabályozható. Az alábbi példákban az `alpha = 50` egy ARGB alfa-csatorna érték a 0–255 skálán, nem átlátszósági százalék.

Az alábbi kódrészlet a **teljes bekezdés** átlátszóságának beállítását mutatja:

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

Az alábbi kódrészlet **félkövér betűkkel** ellátott szövegrészek átlátszóságának beállítását mutatja:

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

## **Karaktertávolság beállítása a szövegben**

Használja az [IBasePortionFormat.setSpacing](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setSpacing-float-) metódust a karakterek közti távolság növelésére vagy csökkentésére egy szövegdobozban.

Az alábbi Java‑kód a **teljes bekezdés** karaktertávolságának növelését mutatja:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    // Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3); // Karaktertávolság növelése.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A karaktertávolság a bekezdésben](character_spacing_in_paragraph.png)

Az alábbi kódrészlet **félkövér betűkkel** ellátott szövegrészek karaktertávolságának növelését mutatja:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = (IAutoShape)slide.getShapes().get_Item(0);
    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);

    for (IPortion portion : paragraph.getPortions()) {
        if (portion.getPortionFormat().getEffective().getFontBold()) {
            // Megjegyzés: Negatív értékek használata a karaktertávolság csökkentéséhez.
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

### **Kerning letiltása meghatározott betűtípusokhoz**

Bizonyos esetekben az Aspose.Slides által renderelt szöveg kissé szorosabb lehet, mint a PowerPoint‑ban megjelenített változat. Ez azért fordulhat elő, mert a PowerPoint bizonyos betűtípusoknál figyelmen kívül hagyja a kerning adatokat, még ha a betűtípus tartalmaz érvényes kerning információt és a PowerPoint beállításaiban engedélyezve is van.

Az ilyen esetekben a PowerPoint‑hoz közeli megjelenés érdekében letilthatja a kerninget azoknál a szövegrészeknél, amelyek az érintett betűtípust használják. Állítsa be az [IBasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setKerningMinimalSize-float-) értékét lényegesen nagyobbra a tényleges betűméretnél:

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

Ez a beállítás megakadályozza a kerning alkalmazását a megfelelő szövegrészekre, és segíthet az Aspose.Slides renderelésének a PowerPoint vizuális kimenetéhez igazításában az ilyen PowerPoint‑specifikus viselkedésű betűtípusok esetén.

## **Szöveg betűtulajdonságainak kezelése**

A betűtulajdonságok beállíthatók bekezdés szinten az [IParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) vagy egyedi részeknél az [IPortionFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iportionformat/) segítségével.

Az alábbi kód a teljes bekezdés betűtípusát és stílusát állítja be: betűméretet, félkövér, dőlt, pontozott aláhúzást és a Times New Roman betűtípust alkalmazza minden részen.

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

Az alábbi kódrészlet hasonló tulajdonságokat alkalmaz **félkövér betűkkel** ellátott szövegrészekre:

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

## **Szöveg forgatásának beállítása**

Használja az [ITextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setTextVerticalType-byte-) metódust egy előre definiált szövegorientáció beállításához egy alakzatban.

Az alábbi kódrészlet a szövegorientációt a [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textverticaltype/) értékre állítja, amely **90 fokkal** a balra forgatja a szöveget:

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

Használja az [ITextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setRotationAngle-float-) metódust egy egyéni forgatási szög megadásához egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) számára.

Az alábbi kódrészlet a szövegkeretet 3 fokkal forgatja az óramutató járásával megegyező irányban az alakzatban:

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

## **Bekezdések sortávolságának beállítása**

Az Aspose.Slides a [IParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceAfter-float-), [IParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceBefore-float-) és [IParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setSpaceWithin-float-) metódusokkal szabályozza a bekezdés távolságait. Ezek a tulajdonságok a következőképpen használhatók:

* Pozitív érték esetén a sortávolság a sormagasság százalékában adható meg.
* Negatív érték esetén a sortávolság pontban adható meg.

Az alábbi kódrészlet a sortávolság beállítását mutatja a bekezdésen belül:

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

## **Automatikus méretezés típusának beállítása szövegkeretekhez**

Az [ITextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAutofitType-byte-) határozza meg, hogyan viselkedik a szöveg, ha túllépi a tároló határait. Használja a szöveg zsugorításának, túlcsordulásának vagy az alakzat automatikus átméretezésének vezérlésére.

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

## **Szövegkeretek rögzítésének beállítása**

Az [ITextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframeformat/#setAnchoringType-byte-) határozza meg, hogyan helyezkedik el a szöveg függőlegesen egy alakzatban, például felül, középen vagy alul.

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

Használja az [IParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#setDefaultTabSize-float-) és az [IParagraphFormat.getTabs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraphformat/#getTabs--) metódusokat a tabulátorok konfigurálásához egy bekezdésben.

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

## **Javító nyelv beállítása**

Az Aspose.Slides a [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) metódussal lehetővé teszi a hibajavító nyelv beállítását egy szövegrészhez. A hibajavító nyelv határozza meg, mely nyelvet használja a helyesírás- és nyelvhelyesség-ellenőrzés a PowerPointban.

Az alábbi kódrészlet a hibajavító nyelv beállítását mutatja egy szövegrészhez:

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

    // Állítsa be a hibajavító nyelv azonosítóját.
    textPortion.getPortionFormat().setLanguageId("zh-CN");

    textPortion.setText("1。");
    paragraph.getPortions().add(textPortion);

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Alapértelmezett nyelv beállítása**

Használja a [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) metódust a prezentáció betöltése vagy létrehozása során létrehozott szöveg alapértelmezett nyelvének meghatározásához.

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

Az alapértelmezett szövegformázás prezentációszinten való alkalmazásához használja az [IPresentation.getDefaultTextStyle](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#getDefaultTextStyle--) metódust.

Az alábbi kódrészlet egy alapértelmezett félkövér, 14 pt méretű betűtípust állít be minden dián megjelenő szöveghez egy új prezentációban.

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

## **Szöveg kinyerése nagybetűs hatással**

PowerPointban a **Nagybetűs** betűhatás alkalmazása azt eredményezi, hogy a szöveg a dián nagybetűkkel jelenik meg, még ha eredetileg kisbetűvel is lett beírva. Az Aspose.Slides-szel történő kinyeréskor a könyvtár a szöveget pontosan úgy adja vissza, ahogy beírták. A megjelenített szöveghez igazításhoz konvertálja a visszakapott karakterláncot nagybetűssé, ha az érték [TextCapType.All](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textcaptype/) .

Tegyük fel, hogy a sample2.pptx fájl első diáján a következő szövegdoboz található.

![A nagybetűs hatás](all_caps_effect.png)

Az alábbi kódrészlet a **Nagybetűs** hatású szöveg kinyerését mutatja:

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

**Hogyan módosítható a szöveg egy táblázatban a dián?**

A táblázatban lévő szöveg módosításához használja az [ITable](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itable/) felületet. Iteráljon a cellákon, és frissítse őket az [ICell.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/#getTextFrame--) és a [IParagraph.getParagraphFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iparagraph/#getParagraphFormat--) segítségével.

**Hogyan alkalmazható színátmenet a szövegre egy PowerPoint dián?**

Színátmenet alkalmazásához használja az [IBasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ibaseportionformat/#getFillFormat--) metódust. Állítsa be az [IFillFormat.setFillType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) értékét a [FillType.Gradient](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/filltype/) típusra, és konfigurálja a gradientállomásokat, irányt és átlátszóságot.