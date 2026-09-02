---
title: Recherche et remplacement de texte dans les présentations PowerPoint sur Android
linktitle: Recherche et remplacement de texte
type: docs
weight: 55
url: /fr/androidjava/search-and-replace-text/
keywords:
- texte de recherche
- texte en surbrillance
- texte de remplacement
- expression régulière
- rappel de résultat
- cadre de texte
- rapport d'audit
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Recherchez, mettez en surbrillance et remplacez du texte dans les présentations PowerPoint tout en collectant chaque correspondance avec Aspose.Slides pour Android via Java."
---
## **Aperçu**

Aspose.Slides for Android via Java peut rechercher, mettre en surbrillance et remplacer du texte dans un cadre de texte individuel ou dans l’ensemble d’une présentation. Chaque opération peut également notifier une application à chaque correspondance via un rappel de résultat. Cela permet de mettre à jour une présentation tout en créant simultanément une trace d’audit contenant le texte correspondant, son contexte, sa position, le cadre de texte et le numéro de diapositive.

Ces capacités sont utiles pour la révision, la rédaction, les contrôles de terminologie, le nettoyage de modèles et les flux de travail de rapports automatisés.

Dans les premiers exemples ci‑dessous, nous utilisons un fichier nommé **"sample.pptx"**, qui contient une seule zone de texte sur la première diapositive avec le texte suivant :

![Texte d’exemple](sample_text.png)

## **Choisir la portée de la recherche**

Utilisez les méthodes de [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) pour limiter une opération à un cadre de texte. Utilisez les méthodes de [IPresentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/) pour traiter tout le texte applicable dans la présentation.

| Opération | Un cadre de texte | Présentation entière |
|---|---|---|
| Mettre en surbrillance du texte littéral | [ITextFrame.highlightText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Mettre en surbrillance les correspondances d’expression régulière | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Remplacer du texte littéral | [ITextFrame.replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Remplacer les correspondances d’expression régulière | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Configurer la recherche de texte**

Pour les opérations de texte littéral, utilisez [TextSearchOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/) afin de contrôler la correspondance :

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) limite les correspondances aux mots complets.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) détermine si la casse doit correspondre.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) inclut les notes de diapositive dans les opérations de recherche, de remplacement et de mise en surbrillance au niveau de la présentation.

Les opérations d’expression régulière utilisent un `Pattern` Java, de sorte que les règles de correspondance telles que la sensibilité à la casse et les limites de mots sont définies par l’expression et ses indicateurs.

## **Collecter les informations de correspondance avec un rappel**

Implémentez [IFindResultCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifindresultcallback/) pour recevoir une notification pour chaque correspondance. Sa méthode [IFindResultCallback.foundResult](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) fournit le cadre de texte concerné, le texte source, le texte correspondant et la position de la correspondance.

Le rappel ne reçoit pas directement le numéro de diapositive. L’implémentation ci‑dessous le dérive de la diapositive parente et traite également le texte trouvé dans les notes de diapositive. Un `Integer` nullable permet au même modèle de résultat de représenter du texte associé à d’autres types de diapositives.

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

Pour les opérations de remplacement, `foundText` contient le texte original correspondant, de sorte que le rappel peut enregistrer exactement les termes qui ont été remplacés.

## **Mettre en surbrillance du texte**

Utilisez la méthode [ITextFrame.highlightText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour mettre en surbrillance les correspondances de texte littéral dans un cadre de texte. Passez un [TextSearchOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/) pour contrôler la recherche et un rappel pour collecter les détails des correspondances.

L’exemple de code ci‑dessous met en surbrillance toutes les occurrences des caractères **"try"** puis ne met en surbrillance que le mot complet **"to"**. Les deux recherches rapportent leurs correspondances au même rappel.

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

    // Mettre en surbrillance chaque occurrence de "try" dans le cadre de texte.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

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

Le résultat :

![Le texte mis en surbrillance](highlighted_text.png)

## **Mettre en surbrillance du texte avec des expressions régulières**

La méthode [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) met en surbrillance les correspondances de texte trouvées par une expression régulière dans un cadre de texte.

Le code suivant met en surbrillance tous les mots contenant sept caractères ou plus et collecte chaque correspondance :

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

Le résultat :

![Le texte mis en surbrillance à l’aide d’une expression régulière](highlighted_text_using_regex.png)

## **Mettre en surbrillance du texte dans toute la présentation**

Utilisez [IPresentation.highlightText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [IPresentation.highlightRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) pour rechercher tous les cadres de texte applicables dans une présentation. L’exemple suivant met en surbrillance un terme littéral et toutes les adresses e‑mail tout en conservant des collections de résultats distinctes pour les deux recherches.

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

## **Remplacer du texte dans un cadre de texte**

Utilisez [ITextFrame.replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) pour le texte littéral et [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour le remplacement basé sur un motif. Ces méthodes mettent à jour le texte correspondant au sein du cadre de texte existant, qui conserve le formatage des parties environnantes au lieu de reconstruire le cadre de texte à partir d’une chaîne simple.

L’exemple suivant standardise une variante orthographique puis remplace les libellés de version. Le même rappel enregistre les termes originaux correspondant aux deux opérations.

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

Si une correspondance s’étend sur des parties ayant des formatages différents, examinez la sortie pour confirmer quel format doit être appliqué au texte de remplacement.

## **Remplacer du texte dans toute la présentation**

Utilisez [IPresentation.replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [IPresentation.replaceRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) pour appliquer les mêmes opérations à l’ensemble de la présentation. Ceci est utile pour le nettoyage de modèles, les mises à jour de terminologie et la rédaction.

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

## **Regrouper les correspondances pour les rapports**

Comme chaque résultat stocke son numéro de diapositive et son cadre de texte, les applications peuvent regrouper les correspondances pour des audits, des rapports ou des flux de travail de révision. L’exemple suivant groupe les résultats collectés d’abord par diapositive puis par cadre de texte :

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

**Comment rechercher uniquement une zone de texte au lieu de toute la présentation ?**

Obtenez le cadre de texte de la forme et appelez [ITextFrame.highlightText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ou [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) sur ce cadre de texte. Les méthodes au niveau de la présentation traitent toutes les zones de texte applicables.

**Comment faire correspondre des mots complets avec la bonne capitalisation ?**

Réglez [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) et [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) sur `true`, et passez les options à une méthode de mise en surbrillance ou de remplacement de texte littéral. Pour les expressions régulières, définissez les limites de mots et la sensibilité à la casse dans le `Pattern` Java lui‑même.

**La recherche et le remplacement peuvent‑ils inclure le texte des notes de diapositive ?**

Oui. Réglez [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) sur `true` lors de l’utilisation d’une opération littérale au niveau de la présentation. L’implémentation du rappel présentée ci‑dessus associe une correspondance dans une diapositive de notes à son numéro de diapositive parent.

**Comment créer un rapport sans analyser la présentation une seconde fois ?**

Passez une implémentation de [IFindResultCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ifindresultcallback/) à l’opération de mise en surbrillance ou de remplacement. Le rappel reçoit chaque correspondance pendant l’exécution de l’opération, de sorte que l’application puisse stocker le texte source, le texte correspondant, la position, le cadre de texte et le numéro de diapositive dérivé pour un regroupement ou une exportation ultérieure.

**Le remplacement de texte conserve‑t‑il son formatage ?**

[ITextFrame.replaceText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) et [ITextFrame.replaceRegex](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) modifient le texte correspondant à l’intérieur du cadre de texte existant et conservent le formatage des portions environnantes. Si une correspondance s’étend sur des portions avec des formatages différents, inspectez le résultat pour vous assurer que le remplacement utilise le style souhaité.