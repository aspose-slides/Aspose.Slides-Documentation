---
title: Szöveg keresése és cseréje PowerPoint-prezentációkban Java-ban
linktitle: Szöveg keresése és cseréje
type: docs
weight: 55
url: /hu/java/search-and-replace-text/
keywords:
- szöveg keresése
- szöveg kiemelése
- szöveg cseréje
- reguláris kifejezés
- eredmény‑callback
- szövegkeret
- audit jelentés
- PowerPoint
- OpenDocument
- prezentáció
- Java
- Aspose.Slides
description: "Szöveg keresése, kiemelése és cseréje PowerPoint prezentációkban, miközben minden egyezést összegyűjt az Aspose.Slides for Java segítségével."
---
## **Áttekintés**

Az Aspose.Slides for Java képes keresni, kiemelni és cserélni a szöveget egyetlen szövegkeretben vagy egy teljes prezentációban. Minden művelet az eredmény‑callback segítségével értesítheti az alkalmazást minden egyezésről. Ennek köszönhetően frissíthető a prezentáció, miközben egy audit‑napló is épül, amely tartalmazza a megtalált szöveget, annak környezetét, pozícióját, a szövegkeretet és a dia számát.

Ezek a lehetőségek hasznosak felülvizsgálat, érzékeny adatok kitakarása, terminológia‑ellenőrzés, sablon‑tisztítás és automatizált jelentéskészítési munkafolyamatok során.

Az alábbi első példákban egy „sample.pptx” nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Keresse ki a keresés hatókörét**

Használja az [ITextFrame](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/) metódusait, ha egy műveletet csak egy szövegkeretre szeretne korlátozni. Használja a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) metódusait, ha a prezentáció összes alkalmazható szövegét szeretné feldolgozni.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Literális szöveg kiemelése | [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris kifejezés egyezéseinek kiemelése | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Literális szöveg cseréje | [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris kifejezés egyezéseinek cseréje | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Szövegillesztés konfigurálása**

Literális‑szöveg műveleteknél használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/) osztályt az illesztés szabályainak vezérléséhez:

- A [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) csak teljes szavakra korlátozza a találatokat.
- A [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) szabályozza, hogy a kis‑ és nagybetűknek egyezniük kell‑e.
- A [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) a dia‑jegyzeteket is belefoglalja a prezentáció‑szintű keresésbe, csere‑ és kiemelés‑műveletekbe.

A reguláris‑kifejezés műveletek Java `Pattern`‑t használnak, így az illesztési szabályok (például a kis‑ és nagybetűk érzékenysége, szómagasság) a kifejezésben és annak flagjeiben vannak meghatározva.

## **Találati információk gyűjtése callback‑kel**

Valósítsa meg az [IFindResultCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifindresultcallback/) interfészt, hogy minden egyezésről értesítést kapjon. A [IFindResultCallback.foundResult](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) metódusa visszaadja a kapcsolódó szövegkeretet, a forrásszöveget, a megtalált szöveget és a pozíciót.

A callback nem kap közvetlenül dia‑számot. Az alábbi megvalósítás a szülő dia alapján határozza meg azt, és kezeli a jegyzetekben talált szöveget is. Egy nullable `Integer` lehetővé teszi, hogy ugyanaz a modell más dia‑típusokhoz is használható legyen.

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

    private static Integer getSlideNumber(ITextFrame textFrame) {
        if (!(textFrame instanceof TextFrame)) {
            return null;
        }

        IBaseSlide parentSlide = ((TextFrame) textFrame).getSlide();

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

Csere‑műveleteknél a `foundText` tartalmazza az eredeti megtalált szöveget, így a callback pontosan rögzítheti, mely kifejezéseket cserélték.

## **Szöveg kiemelése**

Használja az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a literális‑szöveg egyezéseinek kiemelésére egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/)‑t a keresés szabályozásához, valamint egy callback‑t a találatok részleteinek gyűjtéséhez.

Az alábbi kódrészlet kiemeli a **„try”** karakterlánc minden előfordulását, majd csak a teljes **„to”** szót. Mindkét keresés az ugyanazt a callback‑t használja.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    TextSearchCallback callback = new TextSearchCallback();

    TextSearchOptions substringSearchOptions = new TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    Color substringHighlightColor = new Color(173, 216, 230);

    // Kiemeli a "try" minden előfordulását a szövegkeretben.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

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

## **Reguláris kifejezésekkel történő szövegkiemelés**

Az [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódus a reguláris kifejezéssel megtalált szövegeket emeli ki egy szövegkeretben.

Az alábbi kód kiemeli a hét vagy több karaktert tartalmazó összes szót, és minden egyezést gyűjt.

```java
import com.aspose.slides.*;
import java.awt.Color;
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

## **Prezentáción belüli szövegkiemelés**

Használja a [Presentation.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) metódusokat a prezentáció összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa egy literális kifejezést és az összes e‑mail címet emeli ki, miközben külön eredménygyűjteményeket tart fenn a két kereséshez.

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.regex.Pattern;

Presentation presentation = new Presentation("presentation.pptx");
try {
    TextSearchCallback termCallback = new TextSearchCallback();
    TextSearchOptions searchOptions = new TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    presentation.highlightText("confidential", Color.ORANGE, searchOptions, termCallback);

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

Használja az [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust literális szöveghez, valamint az [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-)‑t minta‑alapú cseréhez. Ezek a metódusok a megtalált szöveget az adott szövegkereten belül frissítik, megtartva a környező rész formázását, a teljes keret újraépítése helyett.

Az alábbi példa egységesíti a helyesírási változatot, majd cseréli a verziócímkéket. Ugyanaz a callback rögzíti mindkét művelet által megtalált eredeti kifejezéseket.

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

Ha egy egyezés több, különböző formázású részre terjed ki, ellenőrizze a kimenetet, hogy melyik formázás legyen alkalmazva a csere‑szövegre.

## **Szöveg cseréje egy teljes prezentációban**

Használja a [Presentation.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és a [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokat a műveletek prezentáció‑szintű alkalmazásához. Ez hasznos sablon‑tisztításhoz, terminológia‑frissítéshez és adatkitakaráshoz.

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

Mivel minden eredmény tárolja a dia számát és a szövegkeretet, az alkalmazások csoportosíthatják a találatokat audit, jelentés vagy felülvizsgálati munkafolyamatokhoz. Az alábbi példa először diánként, majd szövegkeretenként csoportosítja a gyűjtött eredményeket:

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

**Hogyan kereshetek csak egy szövegdobozban a teljes prezentáció helyett?**

Szerezze be az alakzat szövegkeretét, és hívja meg az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) vagy [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokkal azon a szövegkereten. A prezentáció‑szintű metódusok az összes alkalmazható szövegkeretet dolgozzák fel.

**Hogyan illeszthetem csak a teljes szavakat a megfelelő nagybetűkkel?**

Állítsa a [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) és a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) értékét `true`‑ra, majd adja át az opciókat egy literális‑szöveg kiemelő vagy csere metódusnak. Reguláris kifejezéseknél definiálja a szóhatárokat és a kis‑/nagybetű érzékenységet a Java `Pattern`‑ben.

**A keresés és csere magában foglalhatja a dia‑jegyzetek szövegét is?**

Igen. Állítsa a [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) értékét `true`‑ra, amikor prezentáció‑szintű literális‑szöveg műveletet használ. A fent bemutatott callback‑implementáció a jegyzet‑dián talált egyezést visszakapcsolja a szülő dia számához.

**Hogyan hozhatok létre jelentést anélkül, hogy újra beolvasnám a prezentációt?**

Adjon át egy [IFindResultCallback](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ifindresultcallback/) implementációt a kiemelés vagy csere műveletnek. A callback minden egyezést megkap a művelet futása közben, így az alkalmazás tárolhatja a forrásszöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott dia számot későbbi csoportosításhoz vagy exportáláshoz.

**A szövegcserélés megtartja-e a formázást?**

Az [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és az [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) módosítja a megtalált szöveget a meglévő szövegkereten belül, és megőrzi a környező rész formázását. Ha egy egyezés különböző formázású részeket fed le, ellenőrizze az eredményt, hogy a csere a kívánt stílust használja-e.