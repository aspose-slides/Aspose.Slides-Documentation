---
title: Szöveg keresése és cseréje PowerPoint prezentációkban Androidon
linktitle: Keresés és csere szöveg
type: docs
weight: 55
url: /hu/androidjava/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény visszahívás
- szövegkeret
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Szöveg keresése, kiemelése és cseréje PowerPoint prezentációkban, miközben minden egyezést összegyűjt az Aspose.Slides for Android via Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes keresni, kiemelni és helyettesíteni a szöveget egy adott szövegkeretben vagy egy teljes prezentációban. Minden művelet értesítheti az alkalmazást minden egyezésről egy eredmény‑visszahíváson keresztül. Ez lehetővé teszi a prezentáció frissítését, miközben egy audit‑naplót épít fel, amely tartalmazza a megtalált szöveget, annak környezetét, pozícióját, a szövegkeretet és a dia számát.

Ezek a lehetőségek hasznosak felülvizsgálat, pirosítás, terminológiai ellenőrzés, sablon‑takarítás és automatizált jelentési munkafolyamatok esetén.

Az alábbi első példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Keresési hatókör kiválasztása**

Használja az [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) metódusait egy művelet korlátozásához egy szövegkeretre. Használja az [IPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/) metódusait a prezentációban lévő összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Literális szöveg kiemelése | [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris‑kifejezés egyezés kiemelése | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Literális szöveg helyettesítése | [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris‑kifejezés egyezés helyettesítése | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Szövegillesztés konfigurálása**

Legismertebb szövegre vonatkozó műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/) osztályt a kezeléshez:

- A [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) csak teljes szavakra korlátozza az egyezéseket.
- A [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) határozza meg, hogy a karakterek nagy‑kis betűi egyezzenek‑e.
- A [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) a diára vonatkozó keresés, helyettesítés és kiemelés műveletekbe belevonja a dia‑megjegyzéseket is.

A reguláris‑kifejezéseken alapuló műveletek Java `Pattern`‑t használnak, így a szabályok (pl. kis‑nagybetű érzékenység, szóhatárok) a kifejezésben és azok jelzőiben vannak definiálva.

## **A szövegkeret tulajdonosának azonosítása**

Az általános szövegfeldolgozó munkafolyamatok gyakran kapnak egy [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) objektumot keresés, helyettesítés, validálás vagy exportálás közben. Használja a [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) és a [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) metódusokat annak meghatározásához, hogy melyik prezentációobjektum birtokolja a szövegkeretet.

A várt értékek a tulajdonostól függenek:

| Szövegkeret tulajdonosa | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape vagy más szöveget tartalmazó alakzat | A tulajdonos [IShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishape/) | `null` |
| Táblázat cella | `null` | A tulajdonos [ICell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/icell/) |

Mindkét metódus csak olvasható navigációt biztosít. Meghívásuk nem mozgatja a szövegkeretet, és nem változtatja meg a tulajdonost. Az általános kódnak mindkét értéket ellenőriznie kell `null`‑ra, és fel kell készülnie arra, hogy egyik sem áll rendelkezésre.

Az alábbi példa a [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) metódust használja a prezentációban lévő szövegkeretek iterálásához. Alakzatok esetén a forma nevét, a Java futási típusát és a tartalmazó diát jelenti. Táblázat cellák esetén a nulla‑bázisú oszlop‑ és sor‑koordinátákat és a tartalmazó diát jeleníti meg.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, false);

    for (ITextFrame textFrame : textFrames) {
        IShape ownerShape = textFrame.getParentShape();
        if (ownerShape != null) {
            String shapeName = ownerShape.getName().isEmpty() ? "(unnamed)" : ownerShape.getName();
            String shapeType = ownerShape.getClass().getSimpleName();
            IBaseSlide baseSlide = ownerShape.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        ICell ownerCell = textFrame.getParentCell();
        if (ownerCell != null) {
            IBaseSlide baseSlide = ownerCell.getSlide();
            String slideLabel;
            if (baseSlide instanceof ISlide) {
                slideLabel = "slide " + ((ISlide) baseSlide).getSlideNumber();
            } else if (baseSlide instanceof INotesSlide) {
                slideLabel = "notes for slide " + ((INotesSlide) baseSlide).getParentSlide().getSlideNumber();
            } else {
                slideLabel = baseSlide.getClass().getSimpleName();
            }
            System.out.println("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        System.out.println("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

SmartArt tartalom esetén iteráljon a [ISmartArtNode.getShapes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartartnode/#getShapes--) alakzatok között, és érje el minden [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) elemet. A szövegkeret a [ITextFrame.getParentShape](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentShape--) segítségével köthető vissza a kapcsolódó alakzathoz, míg a [ITextFrame.getParentCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#getParentCell--) `null`‑t ad vissza. Ezért a példában a forma ága a SmartArt‑csomópontok szövegét is kezeli.

## **Találati információk összegyűjtése visszahívással**

Implementálja az [IFindResultCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifindresultcallback/) interfészt, hogy minden egyezésről értesítést kapjon. Ennek a [IFindResultCallback.foundResult](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) metódusa biztosítja a kapcsolódó szövegkeretet, a forrás‑szöveget, a megtalált szöveget és a találat pozícióját.

A visszahívás közvetlenül nem kapja meg a dia számát; az alábbi megvalósítás a szülő‑diából származtatja, és kezeli a dia‑megjegyzésekben talált szöveget is. Egy nullable `Integer` lehetővé teszi, hogy ugyanaz a modell a többi dia‑típussal kapcsolatos szöveget is reprezentálja.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

final class TextMatch {
    private final ITextFrame textFrame;
    private final String sourceText;
    private final String foundText;
    private final int textPosition;
    private final Integer slideNumber;

    TextMatch(ITextFrame textFrame, String sourceText, String foundText, int textPosition, Integer slideNumber) {
        this.textFrame = textFrame;
        this.sourceText = sourceText;
        this.foundText = foundText;
        this.textPosition = textPosition;
        this.slideNumber = slideNumber;
    }

    ITextFrame getTextFrame() {
        return textFrame;
    }

    String getSourceText() {
        return sourceText;
    }

    String getFoundText() {
        return foundText;
    }

    int getTextPosition() {
        return textPosition;
    }

    Integer getSlideNumber() {
        return slideNumber;
    }
}

final class TextSearchCallback implements IFindResultCallback {
    private final List<TextMatch> results = new ArrayList<TextMatch>();

    List<TextMatch> getResults() {
        return results;
    }

    @Override
    public void foundResult(ITextFrame textFrame, String sourceText, String foundText, int textPosition) {
        Integer slideNumber = getSlideNumber(textFrame);
        TextMatch result = new TextMatch(textFrame, sourceText, foundText, textPosition, slideNumber);
        results.add(result);
    }

    private Integer getSlideNumber(ITextFrame textFrame) {
        IShape parentShape = textFrame.getParentShape();
        ICell parentCell = textFrame.getParentCell();
        IBaseSlide parentSlide = parentShape != null ? parentShape.getSlide() : parentCell != null ? parentCell.getSlide() : textFrame.getSlide();

        if (parentSlide instanceof ISlide) {
            return ((ISlide) parentSlide).getSlideNumber();
        }

        if (parentSlide instanceof INotesSlide) {
            return ((INotesSlide) parentSlide).getParentSlide().getSlideNumber();
        }

        return null;
    }
}
```

Helyettesítési műveletek esetén a `foundText` a eredeti, megtalált szöveget tartalmazza, így a visszahívás pontosan rögzítheti, melyik kifejezést cserélték le.

## **Szöveg kiemelése**

Használja az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a literális szöveg egyezéseinek kiemelésére egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/) objektumot a keresés vezérléséhez, valamint egy visszahívást a találati részletek gyűjtéséhez.

Az alábbi kódrészlet kiemeli a **„try”** karakterlánc minden előfordulását, majd csak a teljes **„to”** szót. Mindkét keresés ugyanarra a visszahívásra jelenti az egyezéseket.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    int substringHighlightColor = Color.rgb(173, 216, 230);

    // A "try" szöveg minden előfordulását kiemeli a szövegkeretben.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Csak a teljes "to" szót emeli ki.
    shape.getTextFrame().highlightText("to", wholeWordHighlightColor, wholeWordSearchOptions, callback);

    for (TextMatch result : callback.getResults()) {
        System.out.println("Found '" + result.getFoundText() + "' at position " +
                result.getTextPosition() + " on slide " + result.getSlideNumber() + ".");
    }

    presentation.save("highlighted_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) metódus reguláris kifejezéssel megtalált szövegegyezéseket emel ki egy szövegkeretben.

Az alábbi kód kiemeli az összes hét vagy több karaktert tartalmazó szót, és minden egyezést összegyűjt:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    Pattern regex = Pattern.compile("\\b[^\\s]{7,}\\b");

    shape.getTextFrame().highlightRegex(regex, Color.YELLOW, callback);

    presentation.save("highlighted_text_using_regex.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A kiemelt szöveg reguláris kifejezéssel](highlighted_text_using_regex.png)

## **Szöveg kiemelése prezentációon keresztül**

Használja a [IPresentation.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [IPresentation.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) metódusokat az összes alkalmazható szövegkeret kereséséhez egy prezentációban. Az alábbi példa kiemel egy literális kifejezést és az összes e‑mail címet, miközben külön eredménygyűjteményeket tart fenn a két kereséshez.

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    int termHighlightColor = Color.rgb(255, 165, 0);
    presentation.highlightText("confidential", termHighlightColor, searchOptions, termCallback);

    TextSearchCallback emailCallback = new TextSearchCallback();
    Pattern emailRegex = Pattern.compile(
            "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
            Pattern.CASE_INSENSITIVE);

    presentation.highlightRegex(emailRegex, Color.YELLOW, emailCallback);
    presentation.save("highlighted_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szöveg cseréje egy szövegkeretben**

Használja az [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust literális szöveghez, illetve az [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódust mintára alapozott helyettesítéshez. Ezek a metódusok a megtalált szöveget a meglévő szövegkereten belül módosítják, megtartva a környező rész formázását, ahelyett, hogy a szövegkeretet egy egyszerű karakterláncból építenék újra.

Az alábbi példa egységesíti egy helyesírási variánst, majd lecseréli a verziócímkéket. Ugyanaz a visszahívás rögzíti mindkét művelet által talált eredeti kifejezéseket.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText("colour", "color", searchOptions, callback);

    Pattern versionRegex = Pattern.compile("\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", callback);

    presentation.save("updated_text_frame.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ha egy egyezés több, eltérő formázású részt is átfed, ellenőrizze a kimenetet, hogy megtudja, melyik formázás legyen alkalmazva a helyettesített szövegre.

## **Szöveg cseréje prezentációon keresztül**

Használja a [IPresentation.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [IPresentation.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokat a műveletek prezentáció‑szintű alkalmazásához. Ez hasznos sablon‑takarítás, terminológiai frissítés és pirosítás esetén.

```java
import com.aspose.slides.*;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback callback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText("Contoso", "Example Corp", searchOptions, callback);

    Pattern accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", callback);

    presentation.save("updated_presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Találatok csoportosítása jelentéshez**

Mivel minden eredmény tárolja a dia számát és a szövegkeretet, az alkalmazások csoportosíthatják az egyezéseket audit, jelentés vagy felülvizsgálat céljából. Az alábbi példa először diánként, majd szövegkeretként csoportosítja a gyűjtött eredményeket:

```java
import com.aspose.slides.ITextFrame;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;

Map<Integer, Map<ITextFrame, List<TextMatch>>> matchesBySlide =
        new LinkedHashMap<Integer, Map<ITextFrame, List<TextMatch>>>();

for (TextMatch result : callback.getResults()) {
    Integer slideNumber = result.getSlideNumber();
    Map<ITextFrame, List<TextMatch>> matchesByTextFrame = matchesBySlide.get(slideNumber);

    if (matchesByTextFrame == null) {
        matchesByTextFrame = new LinkedHashMap<ITextFrame, List<TextMatch>>();
        matchesBySlide.put(slideNumber, matchesByTextFrame);
    }

    ITextFrame textFrame = result.getTextFrame();
    List<TextMatch> textFrameMatches = matchesByTextFrame.get(textFrame);

    if (textFrameMatches == null) {
        textFrameMatches = new java.util.ArrayList<TextMatch>();
        matchesByTextFrame.put(textFrame, textFrameMatches);
    }

    textFrameMatches.add(result);
}

for (Map.Entry<Integer, Map<ITextFrame, List<TextMatch>>> slideEntry : matchesBySlide.entrySet()) {
    String slideLabel = slideEntry.getKey() == null ? "Other" : slideEntry.getKey().toString();
    System.out.println("Slide: " + slideLabel);

    for (Map.Entry<ITextFrame, List<TextMatch>> textFrameEntry : slideEntry.getValue().entrySet()) {
        System.out.println("  Text frame: " + textFrameEntry.getKey().getText());

        for (TextMatch result : textFrameEntry.getValue()) {
            System.out.println("    '" + result.getFoundText() + "' at position " +
                    result.getTextPosition() + "; context: '" + result.getSourceText() + "'");
        }
    }
}
```

## **GYIK**

**Hogyan tudok csak egy szövegdobozban keresni a teljes prezentáció helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), vagy [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokon azon a szövegkereten. A prezentáció‑szintű metódusok az összes alkalmazható szövegkeretet feldolgozzák.

**Hogyan tudok teljes szavakat egyezni a megfelelő nagy‑kis betűkkel?**

Állítsa a [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) és a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) értékét `true`‑ra, és adja át ezeket a literális szöveg kiemelés vagy helyettesítés metódusának. Reguláris kifejezéseknél definiálja a szóhatárokat és a kis‑nagybetű érzékenységet magában a Java `Pattern`‑ben.

**A keresés és a helyettesítés magában foglalhatja a dia‑megjegyzések szövegét is?**

Igen. Állítsa a [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) értékét `true`‑ra, amikor prezentáció‑szintű literális szöveg műveletet használ. A fentebb bemutatott visszahívás‑megvalósítás egy jegyzet‑diában talált egyezést visszafejezi a szülő‑dia számához.

**Hogyan készíthetek jelentést anélkül, hogy a prezentációt újra beolvasnám?**

Adj egy [IFindResultCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifindresultcallback/) megvalósítást a kiemelés vagy helyettesítés műveletéhez. A visszahívás minden egyezést megkap a művelet futása közben, így az alkalmazás el tudja tárolni a forrás‑szöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott dia számot későbbi csoportosításhoz vagy exportáláshoz.

**A szöveg helyettesítése megőrzi a formázását?**

Az [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és az [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) módosítja a megtalált szöveget a meglévő szövegkereten belül, és megtartja a környező rész formázását. Ha egy egyezés több, különböző formázású részt fed le, ellenőrizze az eredményt, hogy a helyettesítés a kívánt stílust használja‑e.