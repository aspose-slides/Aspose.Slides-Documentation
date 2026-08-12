---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint στο Android
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/androidjava/search-and-replace-text/
keywords:
- αναζήτηση κειμένου
- επισήμανση κειμένου
- αντικατάσταση κειμένου
- κανονική έκφραση
- κλήση επιστροφής αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint ενώ καταγράφετε κάθε αντιστοίχηση με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides για Android μέσω Java μπορεί να αναζητήσει, να υπογραμμίσει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιήσει μια εφαρμογή για κάθε αντιστοίχηση μέσω μιας κλήσης επιστροφής αποτελέσματος. Αυτό καθιστά δυνατή την ενημέρωση μιας παρουσίασης και ταυτόχρονα τη δημιουργία ενός ίχνος ελέγχου που περιλαμβάνει το αντιστοιχισμένο κείμενο, το περιεχόμενό του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπου και αυτοματοποιημένες ροές εργασίας αναφορών.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το παρακάτω κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλέξτε το Πεδίο Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήτε μεθόδους στο [IPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/) για να επεξεργαστείτε όλο το εφαρμόσιμο κείμενο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Επισήμανση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση κυριολεκτικού κειμένου | [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Διαμόρφωση Αντιστοίχισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/) για να ελέγξετε την αντιστοίχιση:

- Το [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) περιορίζει τις αντιστοιχίσεις σε ολόκληρες λέξεις.
- Το [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ελέγχει αν πρέπει να ταιριάζει η διάκριση πεζών‑κεφαλαίων.
- Το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) περιλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες τακτικών εκφράσεων χρησιμοποιούν ένα Java `Pattern`, έτσι οι κανόνες αντιστοίχισης όπως η διάκριση πεζών‑κεφαλαίων και τα όρια λέξεων ορίζονται από την έκφραση και τις σημαδοποιήσεις της.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Callback**

Υλοποιήστε το [IFindResultCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifindresultcallback/) για να λαμβάνετε ειδοποίηση για κάθε αντιστοίχηση. Η μέθοδος [IFindResultCallback.foundResult](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση της αντιστοίχισης.

Η κλήση επιστροφής δεν λαμβάνει απευθεία τον αριθμό της διαφάνειας. Η υλοποίηση παρακάτω τον εξάγει από τη γονική διαφάνεια και επίσης διαχειρίζεται κείμενο που βρίσκεται στις σημειώσεις διαφάνειας. Ένα nullable `Integer` επιτρέπει στο ίδιο μοντέλο αποτελεσμάτων να αναπαριστά κείμενο που σχετίζεται με άλλους τύπους διαφάνειας.

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

Για λειτουργίες αντικατάστασης, το `foundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, έτσι η κλήση επιστροφής μπορεί να καταγράψει ακριβώς ποιες λέξεις αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για να επισημάνετε τις αντιστοιχίσεις κυριολεκτικού κειμένου σε ένα πλαίσιο κειμένου. Περνάτε το [TextSearchOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και μια κλήση επιστροφής για τη συλλογή λεπτομερειών της αντιστοίχισης.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη πλήρη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίσεις τους στην ίδια κλήση επιστροφής.

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

    // Επ�ισμαÂνε κάθε εμφάνιση του "try" στο πλαίσιο κειμένου.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Επ�ισμαÂνε μόνο τη πλήρη λέξη "to".
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

Το αποτέλεσμα:

![Το επισημασμένο κείμενο](highlighted_text.png)

## **Επισήμανση Κειμένου με Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) επισημαίνει τις αντιστοιχίσεις κειμένου που βρέθηκαν από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συλλέγει κάθε αντιστοίχηση:

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

Το αποτέλεσμα:

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τις [IPresentation.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [IPresentation.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, διατηρώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

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

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για κυριολεκτικό κείμενο και το [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου, διατηρώντας τη μορφοποίηση του γύρω τμήματος αντί να ξαναδημιουργήσουν το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα τυποποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης. Η ίδια κλήση επιστροφής καταγράφει τις αρχικές λέξεις που αντιστοιχίστηκαν και από τις δύο λειτουργίες.

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

Εάν μια αντιστοίχηση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Ολόκληρη την Παρουσίαση**

Χρησιμοποιήστε τις [IPresentation.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [IPresentation.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

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

## **Ομαδοποίηση Αντιστοιχίσεων για Αναφορά**

Επειδή κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίες για ελέγχους, αναφορές ή ροές εργασίας ανασκόπησης. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και μετά ανά πλαίσιο κειμένου:

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

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ή [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι επιπέδου παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου αντί για αυτό.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) και το [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) σε `true` και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και τη διάκριση πεζών‑κεφαλαίων μέσα στο ίδιο το Java `Pattern`.

**Μπορούν η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου επιπέδου παρουσίασης. Η υλοποίηση της κλήσης επιστροφής που φαίνεται παραπάνω αντιστοιχίζει μια αντιστοίχηση σε διαφάνεια σημειώσεων πίσω στον αριθμό της γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω ξανά την παρουσίαση;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifindresultcallback/) στη λειτουργία επισήμανσης ή αντικατάστασης. Η κλήση επιστροφής λαμβάνει κάθε αντιστοίχηση κατά τη διάρκεια της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προκύπτοντα αριθμό διαφάνειας για μετέπεις ομαδοποιήσεις ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Οι [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) τροποποιούν το αντιστοιχισμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου και διατηρούν τη μορφοποίηση του γύρω τμήματος. Εάν μια αντιστοίχηση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να διασφαλίσετε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.