---
title: Szöveg keresése és cseréje PowerPoint prezentációkban Java nyelven
linktitle: Szöveg keresése és cseréje
type: docs
weight: 55
url: /hu/java/search-and-replace-text/
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
- Java
- Aspose.Slides
description: "Szöveget keres, kiemel és cserél PowerPoint prezentációkban, miközben az Aspose.Slides for Java segítségével minden egyezést összegyűjt."
---
## **Áttekintés**

Aspose.Slides for Java képes keresni, kiemelni és helyettesíteni szöveget egy adott szövegkeretben vagy egy teljes bemutatóban. Minden művelet eredményvisszahíváson keresztül értesítheti az alkalmazást minden egyezésről. Ez lehetővé teszi a bemutató frissítését, miközben audit nyomot épít, amely tartalmazza a megtalált szöveget, annak kontextusát, pozícióját, szövegkeretét és a dia számát.

Ezek a képességek hasznosak felülvizsgálat, sötétítés, terminológiai ellenőrzések, sablontakarítás és automatizált jelentéskészítési munkafolyamatok esetén.

Az alábbi első példákban egy "sample.pptx" nevű fájlt használunk, amely az első dián egyetlen szövegdobozt tartalmaz a következő szöveggel:

![Minta szöveg](sample_text.png)

## **Válassza ki a keresési tartományt**

Használjon metódusokat az [ITextFrame] felületén a művelet egy szövegkeretre való korlátozásához. Használjon metódusokat a [Presentation] felületén a bemutatóban található összes alkalmazható szöveg feldolgozásához.

| Művelet | Egy szövegkeret | Teljes bemutató |
|---|---|---|
| Literális szöveg kiemelése | [ITextFrame.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris kifejezés egyezéseinek kiemelése | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Literális szöveg helyettesítése | [ITextFrame.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Reguláris kifejezés egyezéseinek helyettesítése | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Szövegillesztés beállítása**

Literális szöveg műveleteknél a [TextSearchOptions] használható a keresés szabályozásához:

- [TextSearchOptions.setWholeWordsOnly] korlátozza a találatokat teljes szavakra.
- [TextSearchOptions.setCaseSensitive] határozza meg, hogy a karakterek kis- és nagybetűje legyen egyező.
- [TextSearchOptions.setIncludeNotes] a dia megjegyzéseket is belefoglalja a bemutató szintű keresésbe, helyettesítésbe és kiemelésbe.

A reguláris kifejezésekkel végzett műveletek Java `Pattern`-t használnak, így a keresési szabályok, például a kis- és nagybetű érzékenység és a szóhatárok, a kifejezés és annak flag-jei által vannak meghatározva.

## **A szövegkeret tulajdonosának azonosítása**

Általános szövegfeldolgozó munkafolyamatok gyakran kapnak egy [ITextFrame] objektumot keresés, helyettesítés, validálás vagy exportálás során. Használja az [ITextFrame.getParentShape] és az [ITextFrame.getParentCell] metódusokat annak meghatározásához, hogy melyik bemutató objektum birtokolja a szövegkeretet.

A várt értékek a tulajdonostól függnek:

| A szövegkeret tulajdonosa | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape vagy egy másik szöveget tartalmazó alakzat | A birtokló [IShape] | `null` |
| Táblázat cella | `null` | A birtokló [ICell] |

Mindkét metódus csak olvasási navigációt biztosít. Meghívásuk nem mozgatja a szövegkeretet, és nem változtatja meg a tulajdonost. Általános kód esetén ellenőrizni kell mindkét értéket `null`-ra, és kezelni kell, ha egyik tulajdonos sem elérhető.

A következő példa a [SlideUtil.getAllTextFrames] használatával iterálja a bemutató szövegkereteit. Alakzatok esetén a alakzat nevét, Java futási típusát és a tartalmazó diát jelenti. Táblázat cellák esetén a nullától induló oszlop- és sor‑koordinátákat, valamint a tartalmazó diát jelzi.

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

SmartArt tartalom esetén iteráljon a [ISmartArtNode.getShapes] alakzatokon, és érje el minden [ISmartArtShape.getTextFrame] elemet. A szövegkeret a [ITextFrame.getParentShape] segítségével visszakövethető a kapcsolódó alakzatra, míg a [ITextFrame.getParentCell] `null`‑t ad. Ezért a példában a forma ága szintén kezeli a SmartArt csomópontok szövegét.

## **Találati információk gyűjtése visszahívással**

Valósítsa meg az [IFindResultCallback] interfészt, hogy minden egyezésről értesítést kapjon. Az [IFindResultCallback.foundResult] metódusa a kapcsolódó szövegkeretet, a forrás szöveget, a megtalált szöveget és a találat pozícióját biztosítja.

A visszahívás nem kap közvetlenül diaszámot. Az alábbi implementáció a szülő diából származtatja azt, és kezeli a dia jegyzetekben talált szöveget is. Egy nullable `Integer` lehetővé teszi, hogy ugyanaz a modell a más típusú diákhoz kapcsolódó szöveget is képviselje.

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

Helyettesítési műveleteknél a `foundText` az eredeti megtalált szöveget tartalmazza, így a visszahívás pontosan rögzítheti, mely kifejezéseket cserélték le.

## **Szöveg kiemelése**

Használja az [ITextFrame.highlightText] metódust a literális szöveg egyezéseinek kiemelésére egy szövegkeretben. Adjon meg [TextSearchOptions] objektumot a keresés szabályozásához és egy visszahívást a találati részletek gyűjtéséhez.

Az alábbi kódrészlet kiemeli a **"try"** karakterek minden előfordulását, majd csak a teljes **"to"** szót. Mindkét keresés a találatokat ugyanarra a visszahívásra jelenti.

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

    // Kiemeli csak a teljes "to" szót.
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

Az [ITextFrame.highlightRegex] metódus kiemeli a reguláris kifejezéssel megtalált szövegegyezéseket egy szövegkeretben.

A következő kód kiemeli az összes, legalább hét karaktert tartalmazó szót, és gyűjti az egyes egyezéseket:

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

![A reguláris kifejezéssel kiemelt szöveg](highlighted_text_using_regex.png)

## **Szöveg kiemelése a teljes bemutatóban**

Használja a [Presentation.highlightText] és a [Presentation.highlightRegex] metódusokat a bemutató összes alkalmazható szövegkeretének kereséséhez. Az alábbi példa kiemel egy literális kifejezést és az összes e‑mail címet, miközben a két kereséshez külön eredménygyűjteményeket tart.

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

Használja az [ITextFrame.replaceText] metódust literális szöveg esetén, és az [ITextFrame.replaceRegex] metódust minta alapú helyettesítéshez. Ezek a metódusok a meglévő szövegkeretben frissítik a megtalált szöveget, megtartva a környező rész formázását, ahelyett, hogy a szövegkeretet egy egyszerű sztringből újjáépítenék.

A következő példa egységesíti egy helyesírási változatot, majd lecseréli a verziócímkéket. Ugyanaz a visszahívás rögzíti mindkét művelet által megtalált eredeti kifejezéseket.

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

Ha egy egyezés különböző formázású részeket fed le, ellenőrizze a kimenetet, hogy megerősítse, melyik formázás legyen alkalmazva a helyettesített szövegre.

## **Szöveg cseréje a teljes bemutatóban**

Használja a [Presentation.replaceText] és a [Presentation.replaceRegex] metódusokat a bemutatón belüli azonos műveletek alkalmazásához. Ez hasznos sablon tisztításához, terminológiai frissítésekhez és sötétítéshez.

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

Mivel minden eredmény tárolja a diaszámot és a szövegkeretet, az alkalmazások csoportosíthatják a találatokat audit, jelentéskészítés vagy felülvizsgálati munkafolyamatok céljából. A következő példa először diánként, majd szövegkeret szerint csoportosítja a gyűjtött eredményeket:

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

**Hogyan kereshetek csak egy szövegdobozban a teljes bemutató helyett?**

Szerezze meg az alakzat szövegkeretét, és hívja meg az [ITextFrame.highlightText], [ITextFrame.highlightRegex], [ITextFrame.replaceText] vagy [ITextFrame.replaceRegex] metódusokat azon a szövegkereten. A bemutató‑szintű metódusok az összes alkalmazható szövegkeretet dolgozzák fel.

**Hogyan egyeztessek teljes szavakat a megfelelő nagybetűkkel?**

Állítsa a [TextSearchOptions.setWholeWordsOnly] és a [TextSearchOptions.setCaseSensitive] értékeket `true`‑ra, és adja át az opciókat egy literális szöveg kiemelés vagy helyettesítés metódusának. Reguláris kifejezések esetén határozza meg a szóhatárokat és a nagybetű érzékenységet a Java `Pattern`‑ben.

**Tartalmazhatja a keresés és helyettesítés a dia jegyzetek szövegét is?**

Igen. Állítsa a [TextSearchOptions.setIncludeNotes] értéket `true`‑ra, amikor bemutató‑szintű literális szöveg műveletet használ. A fenti visszahívás implementációja a jegyzetdia egyezést visszakapcsolja a szülő dia számához.

**Hogyan készítsek jelentést anélkül, hogy a bemutatót másodszor beolvasnám?**

Adjon át egy [IFindResultCallback] implementációt a kiemelési vagy helyettesítési művelethez. A visszahívás minden egyezést megkap a művelet futása közben, így az alkalmazás tárolhatja a forrás szöveget, a megtalált szöveget, a pozíciót, a szövegkeretet és a származtatott diaszámot későbbi csoportosítás vagy exportálás céljából.

**Megőrződik a szöveg formázása a helyettesítés során?**

Az [ITextFrame.replaceText] és az [ITextFrame.replaceRegex] módosítja a megtalált szöveget a meglévő szövegkereten belül, megtartva a környező rész formázását. Ha egy egyezés többféle formázású részt fed le, ellenőrizze a kimenetet, hogy a helyettesítés a kívánt stílust használja.