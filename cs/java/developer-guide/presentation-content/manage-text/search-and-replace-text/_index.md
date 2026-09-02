---
title: Vyhledávat a nahrazovat text v PowerPoint prezentacích v Javě
linktitle: Vyhledávat a nahrazovat text
type: docs
weight: 55
url: /cs/java/search-and-replace-text/
keywords:
- vyhledat text
- zvýraznit text
- nahradit text
- regulární výraz
- zpětné volání výsledku
- textový rámec
- auditní zpráva
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Vyhledávejte, zvýrazňujte a nahrazujte text v PowerPoint prezentacích a současně sbírejte každou shodu pomocí Aspose.Slides pro Javu."
---
## **Přehled**

Aspose.Slides for Java může vyhledávat, zvýrazňovat a nahrazovat text v jednotlivém textovém rámci nebo v celé prezentaci. Každá operace může také upozornit aplikaci na každou shodu pomocí zpětného volání výsledku. To umožňuje aktualizovat prezentaci a zároveň vytvářet auditní stopu obsahující nalezený text, jeho kontext, pozici, textový rámec a číslo snímku.

Tyto možnosti jsou užitečné pro revizi, redakci, kontrolu terminologie, čištění šablon a automatizované pracovní postupy reportování.

V prvních níže uvedených příkladech používáme soubor pojmenovaný "sample.pptx", který obsahuje jedinou textovou oblast na první snímku s následujícím textem:

![Ukázkový text](sample_text.png)

## **Zvolte rozsah vyhledávání**

Použijte metody na [ITextFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/) k omezení operace na jeden textový rámec. Použijte metody na [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/) pro zpracování veškerého použitelného textu v prezentaci.

| Operace | Jeden textový rámec | Celá prezentace |
|---|---|---|
| Zvýraznit doslovný text | [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Zvýraznit shody regulárního výrazu | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Nahradit doslovný text | [ITextFrame.replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Nahradit shody regulárního výrazu | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Konfigurace porovnávání textu**

Pro operace s doslovným textem použijte [TextSearchOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/) k řízení porovnávání:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) omezuje shody na celá slova.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) určuje, zda musí odpovídat velikost písmen.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) zahrnuje poznámky ke snímkům do vyhledávání, nahrazování a zvýrazňování na úrovni prezentace.

Operace s regulárním výrazem používají v Javě `Pattern`, takže pravidla porovnání jako citlivost na velikost písmen a hranice slov jsou definována výrazem a jeho příznaky.

## **Sbírat informace o shodách pomocí zpětného volání**

Implementujte [IFindResultCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifindresultcallback/), aby jste dostávali upozornění na každou shodu. Jeho metoda [IFindResultCallback.foundResult](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) poskytuje související textový rámec, původní text, nalezený text a pozici shody.

Zpětné volání nedostává číslo snímku přímo. Níže uvedená implementace jej získává z nadřazeného snímku a také zpracovává text nalezený v poznámkách ke snímkům. Nullable `Integer` umožňuje stejnému modelu výsledku reprezentovat text spojený s jinými typy snímků.

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

U operací nahrazování `foundText` obsahuje původní nalezený text, takže zpětné volání může přesně zaznamenat, které výrazy byly nahrazeny.

## **Zvýraznit text**

Použijte metodu [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), aby jste zvýraznili shody doslovného textu v textovém rámci. Předávejte [TextSearchOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/) k řízení vyhledávání a zpětné volání pro sběr podrobností o shodách.

Níže uvedený příklad kódu zvýrazní všechny výskyty znaků **"try"** a poté zvýrazní jen celé slovo **"to"**. Obě vyhledávání hlásí své shody stejnému zpětnému volání.

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

    // Zvýraznit každý výskyt "try" v textovém rámci.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Zvýraznit pouze celé slovo "to".
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

## **Zvýraznit text pomocí regulárních výrazů**

Metoda [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) zvýrazní shody textu nalezené regulárním výrazem v textovém rámci.

Následující kód zvýrazní všechna slova obsahující sedm a více znaků a shromáždí každou shodu:

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

Výsledek:

![Zvýrazněný text pomocí regulárního výrazu](highlighted_text_using_regex.png)

## **Zvýraznit text v celé prezentaci**

Použijte [Presentation.highlightText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [Presentation.highlightRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) pro prohledání všech použitelných textových rámců v prezentaci. Následující příklad zvýrazní doslovný termín a všechny e‑mailové adresy a zároveň zachová samostatné kolekce výsledků pro obě vyhledávání.

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

## **Nahradit text v textovém rámci**

Použijte [ITextFrame.replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pro doslovný text a [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pro nahrazování založené na vzoru. Tyto metody aktualizují nalezený text v existujícím textovém rámci, přičemž zachovávají formátování okolních částí místo přestavby textového rámce z prostého řetězce.

Následující příklad sjednotí variantu pravopisu a poté nahradí označení verzí. Stejné zpětné volání zaznamenává původní termíny nalezené oběma operacemi.

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

Pokud jedna shoda zahrnuje části s odlišným formátováním, zkontrolujte výstup a potvrďte, které formátování má být použito pro nahrazovaný text.

## **Nahradit text v celé prezentaci**

Použijte [Presentation.replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [Presentation.replaceRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) aby jste aplikovali stejné operace v celé prezentaci. To je užitečné pro čištění šablon, aktualizace terminologie a redakci.

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

## **Seskupit shody pro reportování**

Protože každý výsledek ukládá číslo snímku a textový rámec, aplikace mohou shody seskupovat pro audit, reportování nebo revizní pracovní postupy. Následující příklad seskupí shromážděné výsledky nejprve podle snímku a poté podle textového rámce:

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

## **Často kladené otázky**

**Jak mohu vyhledávat jen v jedné textové oblasti místo celé prezentace?**

Získejte textový rámec tvaru a zavolejte [ITextFrame.highlightText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), nebo [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) na tomto textovém rámci. Metody na úrovni prezentace zpracují všechny použitelné textové rámce.

**Jak mohu porovnat celá slova s správnou kapitalizací?**

Nastavte [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) a [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) na `true` a předávejte tyto možnosti metodě pro zvýraznění nebo nahrazení doslovného textu. U regulárních výrazů definujte hranice slov a citlivost na velikost písmen přímo v Java `Pattern`.

**Může vyhledávání a nahrazování zahrnovat text v poznámkách ke snímkům?**

Ano. Nastavte [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/cs/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) na `true` při použití operace doslovného textu na úrovni prezentace. Implementace zpětného volání uvedená výše mapuje shodu v poznámkovém snímku zpět na číslo nadřazeného snímku.

**Jak mohu vytvořit report bez druhého průchodu prezentací?**

Předáte implementaci [IFindResultCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ifindresultcallback/) do operace zvýraznění nebo nahrazení. Zpětné volání přijímá každou shodu během provádění operace, takže aplikace může uložit původní text, nalezený text, pozici, textový rámec a odvozené číslo snímku pro pozdější seskupení nebo export.

**Zachovává nahrazování textu jeho formátování?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) a [ITextFrame.replaceRegex](https://reference.aspose.com/slides/cs/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) upravují nalezený text v existujícím textovém rámci a zachovávají formátování okolních částí. Pokud shoda zahrnuje části s různým formátováním, prohlédněte výsledek a ujistěte se, že nahrazení používá požadovaný styl.