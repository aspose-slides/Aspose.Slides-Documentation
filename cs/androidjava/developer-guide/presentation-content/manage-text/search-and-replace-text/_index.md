---
title: Vyhledávání a nahrazování textu v prezentacích PowerPoint na Androidu
linktitle: Vyhledávání a nahrazování textu
type: docs
weight: 55
url: /cs/androidjava/search-and-replace-text/
keywords:
- vyhledávání textu
- zvýraznění textu
- nahrazení textu
- regulární výraz
- zpětné volání výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v prezentacích PowerPoint a při tom shromažďujte každou shodu pomocí Aspose.Slides pro Android přes Java."
---
## **Přehled**

Aspose.Slides for Android via Java dokáže vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámci nebo v celé prezentaci. Každá operace může také aplikaci upozornit na každou shodu pomocí zpětného volání výsledku. To umožňuje aktualizovat prezentaci a současně vytvářet auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné při revizi, redakci, kontrolách terminologie, úklidu šablon a automatizovaných pracovních postupech pro reportování.

V prvních příkladech níže používáme soubor nazvaný "sample.pptx", který obsahuje jedinou textovou oblast na prvním snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah hledání**

Použijte metody na [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) pro omezení operace na jeden textový rámec. Použijte metody na [IPresentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/) pro zpracování celého textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zvýraznit shody regulárního výrazu | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Nahradit doslovný text | [ITextFrame.replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Nahradit shody regulárního výrazu | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Nastavení shody textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/) k řízení shody:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) omezuje shody na celá slova.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) určuje, zda se musí shodovat velikost písmen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) zahrnuje poznámky ke snímkům při vyhledávání, nahrazování a zvýrazňování na úrovni prezentace.

Operace s regulárními výrazy používají Java `Pattern`, takže pravidla shody, jako je rozlišení velkých a malých písmen a ohraničení slov, jsou definována výrazem a jeho příznaky.

## **Identifikace vlastníka textového rámce**

Obecné pracovní postupy pro zpracování textu často získají objekt [ITextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/) během vyhledávání, nahrazování, validace nebo exportu textu. Použijte [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentShape--) a [ITextFrame.getParentCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentCell--) k určení, který objekt prezentace vlastní textový rámec.

Očekávané hodnoty závisí na vlastníkovi:

| Vlastník textového rámce | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape nebo jiný tvar obsahující text | Vlastní [IShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ishape/) | `null` |
| Buňka tabulky | `null` | Vlastní [ICell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icell/) |

Obě metody poskytují pouze čtení navigace. Volání neprovádí přesun textového rámce ani nezmění jeho vlastníka. Obecný kód by měl kontrolovat obě hodnoty na `null` a ošetřit možnost, že žádný vlastník není dostupný.

Následující příklad používá [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) k iteraci přes textové rámce v prezentaci. Pro tvary vypisuje název tvaru, typ Java runtime a snímek, ve kterém se nachází. Pro buňky tabulky vypisuje nulové sloupce a řádky a příslušný snímek.

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

Pro obsah SmartArt iterujte přes tvary v [ISmartArtNode.getShapes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartartnode/#getShapes--) a přistupujte k každému [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Textový rámec lze sledovat k přidruženému tvaru pomocí [ITextFrame.getParentShape](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentShape--), zatímco [ITextFrame.getParentCell](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#getParentCell--) vrací `null`. Proto větev tvarů v příkladu také zpracovává text ze SmartArt uzlů.

## **Shromažďování informací o shodách pomocí zpětného volání**

Implementujte [IFindResultCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifindresultcallback/) pro získání upozornění na každou shodu. Jeho metoda [IFindResultCallback.foundResult](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) poskytuje související textový rámec, zdrojový text, nalezený text a pozici shody.

Zpětné volání nedostává přímo číslo snímku. Implementace níže jej odvozuje z rodičovského snímku a také zpracovává text nalezený v poznámkách ke snímkům. Nullable `Integer` umožňuje stejnému modelu výsledku reprezentovat text spojený s jinými typy snímků.

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

U operací nahrazování `foundText` obsahuje původní nalezený text, takže zpětné volání může zaznamenat přesně, které termíny byly nahrazeny.

## **Zvýraznění textu**

Použijte metodu [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) k zvýraznění doslovných shod v textovém rámci. Předávejte [TextSearchOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/) pro řízení vyhledávání a zpětné volání pro shromažďování podrobností o shodách.

Následující ukázkový kód zvýrazní všechna výskyty řetězce **"try"** a poté zvýrazní jen celé slovo **"to"**. Obě vyhledávání zaznamenávají své shody do stejného zpětného volání.

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

    // Zvýrazněte každý výskyt "try" v textovém rámci.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Zvýrazněte pouze celé slovo "to".
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

Výsledek:

![Zvýrazněný text](highlighted_text.png)

## **Zvýraznění textu pomocí regulárních výrazů**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) zvýrazní textové shody nalezené regulárním výrazem v textovém rámci.

Následující kód zvýrazní všechna slova obsahující sedm a více znaků a shromažďuje každou shodu:

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

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznění textu v celé prezentaci**

Použijte [IPresentation.highlightText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [IPresentation.highlightRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) pro vyhledání všech relevantních textových rámců v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy a přitom udržuje samostatné kolekce výsledků pro obě vyhledávání.

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

## **Nahrazení textu v textovém rámci**

Použijte [ITextFrame.replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pro doslovný text a [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pro nahrazení na základě vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámci, který si zachovává formátování okolních částí místo přestavby textového rámce z prostého řetězce.

Následující příklad sjednotí variantu pravopisu a poté nahradí štítky verzí. Stejné zpětné volání zaznamenává původní termíny nalezené oběma operacemi.

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

Pokud jedna shoda zasahuje do částí s odlišným formátováním, zkontrolujte výstup, abyste potvrdili, které formátování by se mělo použít pro nahrazený text.

## **Nahrazení textu v celé prezentaci**

Použijte [IPresentation.replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [IPresentation.replaceRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pro aplikaci stejných operací na celou prezentaci. To je užitečné při úklidu šablon, aktualizaci terminologie a redakci.

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

## **Seskupení shod pro reportování**

Protože každý výsledek uchovává číslo snímku a textový rámec, aplikace mohou shody seskupit pro audit, reportování nebo revizi. Následující příklad seskupí shromážděné výsledky nejprve podle snímku a poté podle textového rámce:

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

**Jak mohu vyhledávat jen v jednom textovém poli místo celé prezentace?**

Získejte textový rámec tvaru a zavolejte na něm [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), nebo [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tomto textovém rámci. Metody na úrovni prezentace zpracovávají všechny relevantní textové rámce.

**Jak mohu shodovat celá slova s korrektním rozlišením velkých a malých písmen?**

Nastavte [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` a předávejte možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. Pro regulární výrazy definujte ohraničení slov a rozlišení velkých/malých písmen přímo v Java `Pattern`.

**Mohou vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true`, když používáte operaci na úrovni prezentace s doslovným textem. Implementace zpětného volání uvedená výše mapuje shodu v poznámce zpět na číslo nadřazeného snímku.

**Jak mohu vytvořit report bez druhého procházení prezentace?**

Předávejte implementaci [IFindResultCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ifindresultcallback/) do operace zvýraznění nebo nahrazení. Zpětné volání přijímá každou shodu během provádění operace, takže aplikace může uložit zdrojový text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupení nebo export.

**Zachovává nahrazení textu jeho formátování?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) mění nalezený text v existujícím textovém rámci a zachovávají formátování okolních částí. Pokud shoda zasahuje do částí s odlišným formátováním, zkontrolujte výsledek, aby nahrazený text použil požadovaný styl.