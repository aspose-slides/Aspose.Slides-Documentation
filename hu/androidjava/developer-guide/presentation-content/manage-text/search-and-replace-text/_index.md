---
title: PowerPoint-prezentációk szövegének keresése és cseréje Androidon
linktitle: Szöveg keresése és cseréje
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
description: "Szöveg keresése, kiemelése és cseréje PowerPoint-prezentációkban, miközben az Aspose.Slides for Android via Java minden találatot gyűjt."
---
## **Áttekintés**

Az Aspose.Slides for Android via Java képes keresni, kiemelni és cserélni a szöveget egy egyedi szövegkeretben vagy egy teljes prezentációban. Minden művelet értesítheti az alkalmazást minden találatról egy eredmény‑visszahíváson keresztül. Ez lehetővé teszi a prezentáció frissítését, miközben egy audit‑nyomvonalat épít fel, amely tartalmazza a megtalált szöveget, annak kontextusát, pozícióját, a szövegkeretet és a dia számát.

Ezek a képességek hasznosak felülvizsgálathoz, sötétítéshez, terminológiai ellenőrzésekhez, sablon‑takarításhoz és automatizált jelentési munkafolyamatokhoz.

Az alábbi első példákban a „sample.pptx” nevű fájlt használjuk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Sample text](sample_text.png)

## **Keresési hatókör kiválasztása**

Használja az [ITextFrame](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/) metódusait egy művelet korlátozásához egy szövegkeretre. Használja az [IPresentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/) metódusait a prezentációban található összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes prezentáció |
|---|---|---|
| Literális szöveg kiemelése | [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris‑kifejezés egyezések kiemelése | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Literális szöveg cseréje | [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris‑kifejezés egyezések cseréje | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Szövegillesztés konfigurálása**

Literális‑szöveges műveletekhez használja a [TextSearchOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/) osztályt a keresés szabályozásához:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) korlátozza a találatokat teljes szavakra.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) szabályozza, hogy a karakterek nagy‑ és kisbetűje egyezzen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) belefoglalja a diák jegyzeteit a prezentáció‑szintű keresésbe, csere‑ és kiemelés‑műveletekbe.

A reguláris‑kifejezéses műveletek egy Java `Pattern`‑t használnak, így az egyezés szabályait – például a nagybetűérzékenységet és a szóhatárokat – a kifejezés és annak flagjei határozzák meg.

## **Gyűjtse össze a találatok információit visszahívással**

Implementálja a [IFindResultCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifindresultcallback/) interfészt, hogy minden egyezésről értesítést kapjon. Az [IFindResultCallback.foundResult](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) metódusa a kapcsolódó szövegkeretet, a forrásszöveget, a megtalált szöveget és a találat pozícióját adja vissza.

A visszahívás nem kap közvetlenül dia számot. Az alábbi megvalósítás a szülő diához rendeli azt, és kezeli a diaszövegjegyzetekben található szöveget is. Egy nullable `Integer` lehetővé teszi, hogy ugyanaz a modell a többi dia típushoz tartozó szöveget is képviselje.

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

Csere‑műveleteknél a `foundText` a eredeti megtalált szöveget tartalmazza, így a visszahívás pontosan rögzítheti, melyik kifejezést cserélték le.

## **Szöveg kiemelése**

Használja az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust a literális‑szöveg egyezések kiemeléséhez egy szövegkeretben. Adja át a [TextSearchOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/)‑t a keresés szabályozásához és egy visszahívást a találati adatok gyűjtéséhez.

Az alábbi kódrészlet minden **„try”** karakter előfordulást kiemeli, majd csak a teljes **„to”** szót. Mindkét keresés ugyanabba a visszahívásba jelenti a találatokat.

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

    // Emelje ki a "try" minden előfordulását a szövegkeretben.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Emelje ki csak a teljes "to" szót.
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

![The highlighted text](highlighted_text.png)

## **Szöveg kiemelése reguláris kifejezésekkel**

Az [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) metódus reguláris kifejezéssel megtalált szövegegyezéseket emeli ki egy szövegkeretben.

Az alábbi kód kiemeli az összes hét vagy több karaktert tartalmazó szót, és összegyűjti az egyes egyezéseket:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Szöveg kiemelése egy teljes prezentációban**

Használja az [IPresentation.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és az [IPresentation.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) metódusokat a prezentáció összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa kiemel egy literális kifejezést és minden e‑mail címet, miközben a két kereséshez külön‑külön gyűjti a találatokat.

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

Használja az [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) metódust literális szöveghez, és az [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódust mintára alapozott cserehez. Ezek a módszerek a meglévő szövegkereten belül frissítik a megtalált szöveget, megtartva a környező rész formázását a tiszta karakterláncból való újraépítés helyett.

Az alábbi példa egységesíti egy helyesírási változatot, majd lecseréli a verziócímkéket. Ugyanaz a visszahívás rögzíti mindkét művelet által megtalált eredeti kifejezéseket.

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

Ha egy találat különböző formázású részeket fed le, ellenőrizze a kimenetet, hogy melyik formázás legyen alkalmazva a csere‑szövegre.

## **Szöveg cseréje a teljes prezentációban**

Használja az [IPresentation.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és az [IPresentation.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokat a műveletek teljes prezentációra kiterjesztéséhez. Ez hasznos sablon‑takarításhoz, terminológiai frissítésekhez és sötétítéshez.

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

Mivel minden eredmény tárolja a dia számát és a szövegkeretet, az alkalmazások a találatokat audit, jelentés vagy felülvizsgálati munkafolyamatokhoz csoportosíthatják. Az alábbi példa először diánként, majd szövegkeretenként csoportosítja a gyűjtött eredményeket:

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

## **FAQ**

**Hogyan kereshetek csak egy szövegdobozban a teljes prezentáció helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg az [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), vagy [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) metódusokon azon a szövegkereten. A prezentáció‑szintű metódusok az összes alkalmazható szövegkeretet feldolgozzák.

**Hogyan egyeztessek teljes szavakat a megfelelő nagybetűkkel?**

Állítsa a [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) és a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) értékét `true`‑ra, és adja át a beállításokat egy literális‑szöveget kiemelő vagy cserélő metódusnak. Reguláris kifejezéseknél határozza meg a szóhatárokat és a nagybetűérzékenységet a Java `Pattern`‑ben.

**Tartalmazhatja a keresés és csere a diák jegyzeteiben lévő szöveget is?**

Igen. Állítsa a [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) értékét `true`‑ra, amikor prezentáció‑szintű literális‑szöveg műveletet használ. A fenti visszahívás‑megvalósítás a jegyzet‑diában található egyezést visszakapcsolja a szülő dia számához.

**Hogyan készíthetek jelentést anélkül, hogy a prezentációt újra átnézném?**

Adjon át egy [IFindResultCallback](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ifindresultcallback/) implementációt a kiemelés vagy csere műveletnek. A visszahívás a művelet futása közben minden egyezést megkap, így az alkalmazás eltárolhatja a forrásszöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott dia számot későbbi csoportosításhoz vagy exportáláshoz.

**Megőrzi a szöveg formázását a csere során?**

Az [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) és az [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) módosítja a megtalált szöveget a meglévő szövegkereten belül, és megtartja a környező rész formázását. Ha egy találat különböző formázású részeket foglal magába, ellenőrizze az eredményt, hogy a csere a kívánt stílust alkalmazza.