---
title: Recherche et remplacement de texte dans les présentations PowerPoint en Java
linktitle: Recherche et remplacement de texte
type: docs
weight: 55
url: /fr/java/search-and-replace-text/
keywords:
- recherche de texte
- mise en surbrillance du texte
- remplacement de texte
- expression régulière
- rappel de résultat
- trame de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Rechercher, mettre en surbrillance et remplacer du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides for Java."
---
## **Aperçu**

Aspose.Slides for Java peut rechercher, mettre en surbrillance et remplacer du texte dans une trame de texte individuelle ou dans l'ensemble d'une présentation. Chaque opération peut également notifier une application de chaque correspondance via un rappel de résultat. Cela permet de mettre à jour une présentation tout en créant simultanément une piste d'audit contenant le texte correspondant, son contexte, sa position, la trame de texte et le numéro de diapositive.

Ces fonctionnalités sont utiles pour la révision, la censure, la vérification de la terminologie, le nettoyage de modèles et les flux de travail de génération de rapports automatisés.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé "sample.pptx", qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d'exemple](sample_text.png)

## **Choisir la portée de recherche**

Utilisez les méthodes de [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) pour limiter une opération à une trame de texte. Utilisez les méthodes de [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) pour traiter tout le texte applicable dans la présentation.

| Opération | Une trame de texte | Toute la présentation |
|---|---|---|
| Mettre en surbrillance du texte littéral | [ITextFrame.highlightText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Mettre en surbrillance les correspondances d'expression régulière | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Remplacer le texte littéral | [ITextFrame.replaceText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Remplacer les correspondances d'expression régulière | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurer la correspondance du texte**

Pour les opérations de texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/) pour contrôler la correspondance :

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limite les correspondances aux mots complets.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) contrôle si la casse des caractères doit correspondre.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclut les notes de diapositives dans les opérations de recherche, de remplacement et de mise en surbrillance au niveau de la présentation.

Les opérations d'expression régulière utilisent un `Pattern` Java, de sorte que les règles de correspondance telles que la sensibilité à la casse et les limites de mots sont définies par l'expression et ses indicateurs.

## **Collecter les informations de correspondance avec un rappel**

Implémentez [IFindResultCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifindresultcallback/) pour recevoir une notification pour chaque correspondance. Sa méthode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fournit la trame de texte concernée, le texte source, le texte correspondant et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de diapositive. L'implémentation ci‑dessous le déduit de la diapositive parente et gère également le texte trouvé dans les notes de diapositives. Un `Integer` nullable permet au même modèle de résultat de représenter du texte associé à d'autres types de diapositives.

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

Pour les opérations de remplacement, `foundText` contient le texte original correspondant, de sorte que le rappel peut enregistrer exactement quels termes ont été remplacés.

## **Mettre en surbrillance du texte**

Utilisez la méthode [ITextFrame.highlightText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour mettre en surbrillance les correspondances de texte littéral dans une trame de texte. Passez [TextSearchOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/) pour contrôler la recherche et un rappel pour collecter les détails des correspondances.

Le code d'exemple ci‑dessous met en surbrillance toutes les occurrences des caractères **"try"** puis met en surbrillance uniquement le mot complet **"to"**. Les deux recherches signalent leurs correspondances au même rappel.

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

    // Mettre en surbrillance chaque occurrence de "try" dans la trame de texte.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Mettre en surbrillance uniquement le mot complet "to".
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

![Le texte mis en surbrillance](highlighted_text.png)

## **Mettre en surbrillance du texte à l'aide d'expressions régulières**

La méthode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) met en surbrillance les correspondances de texte trouvées par une expression régulière dans une trame de texte.

Le code suivant met en surbrillance tous les mots contenant sept caractères ou plus et collecte chaque correspondance :

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

![Le texte mis en surbrillance à l'aide de l'expression régulière](highlighted_text_using_regex.png)

## **Mettre en surbrillance du texte dans une présentation**

Utilisez [Presentation.highlightText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [Presentation.highlightRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) pour rechercher toutes les trames de texte applicables dans une présentation. L'exemple suivant met en surbrillance un terme littéral et toutes les adresses e‑mail tout en conservant des collections de résultats séparées pour les deux recherches.

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

## **Remplacer du texte dans une trame de texte**

Utilisez [ITextFrame.replaceText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour du texte littéral et [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour un remplacement basé sur un motif. Ces méthodes mettent à jour le texte correspondant au sein de la trame de texte existante, qui conserve la mise en forme de la partie environnante au lieu de reconstruire la trame de texte à partir d'une chaîne simple.

L'exemple suivant normalise une variante d'orthographe puis remplace les libellés de version. Le même rappel enregistre les termes originaux correspondants aux deux opérations.

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

Si une correspondance s'étend sur des parties avec des mises en forme différentes, examinez le résultat pour confirmer la mise en forme à appliquer au texte de remplacement.

## **Remplacer du texte dans une présentation**

Utilisez [Presentation.replaceText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [Presentation.replaceRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour appliquer les mêmes opérations dans toute la présentation. Cela est utile pour le nettoyage de modèles, la mise à jour de la terminologie et la censure.

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

## **Grouper les correspondances pour les rapports**

Comme chaque résultat conserve son numéro de diapositive et sa trame de texte, les applications peuvent regrouper les correspondances pour l'audit, les rapports ou les flux de travail de révision. L'exemple suivant regroupe les résultats collectés d'abord par diapositive puis par trame de texte :

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

**Comment puis‑je rechercher uniquement une zone de texte au lieu de toute la présentation ?**

Obtenez la trame de texte de la forme et appelez [ITextFrame.highlightText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sur cette trame de texte. Les méthodes au niveau de la présentation traitent toutes les trames de texte applicables à la place.

**Comment puis‑je faire correspondre des mots complets avec la bonne capitalisation ?**

Définissez [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) et [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) sur `true`, et transmettez les options à une méthode de mise en surbrillance ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse dans le `Pattern` Java lui‑-même.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositives ?**

Oui. Réglez [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sur `true` lors de l'utilisation d'une opération de texte littéral au niveau de la présentation. L'implémentation du rappel présentée ci‑dessus fait correspondre une correspondance dans une diapositive de notes au numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez une implémentation de [IFindResultCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ifindresultcallback/) à l'opération de mise en surbrillance ou de remplacement. Le rappel reçoit chaque correspondance pendant l'exécution de l'opération, de sorte que l'application peut stocker le texte source, le texte correspondant, la position, la trame de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement du texte conserve‑t‑il sa mise en forme ?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifient le texte correspondant au sein de la trame de texte existante et conservent la mise en forme de la partie environnante. Si une correspondance s'étend sur des parties avec des mises en forme différentes, examinez le résultat afin de vous assurer que le remplacement utilise le style souhaité.