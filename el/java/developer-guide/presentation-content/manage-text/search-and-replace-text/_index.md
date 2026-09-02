---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint σε Java
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/java/search-and-replace-text/
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
- Java
- Aspose.Slides
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint, συλλέγοντας κάθε αντιστοίχηση με το Aspose.Slides for Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Java μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη μια παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιεί μια εφαρμογή για κάθε αντιστοίχηση μέσω μιας κλήσης αποτελέσματος. Αυτό καθιστά δυνατή την ενημέρωση μιας παρουσίασης και ταυτόχρονα τη δημιουργία ενός μητρώου ελέγχου που περιέχει το αντιστοιχισμένο κείμενο, το περιεχόμενό του, τη θέση, το πλαίσιο κειμένου και τον αριθμό διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ελέγχους, διαγράφηση, ελέγχους ορολογίας, εκκαθάριση προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μοναδικό πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή πεδίου αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) για περιορισμό μιας λειτουργίας σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) για επεξεργασία όλου του κειμένου που εφαρμόζεται στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Επισήμανση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση κυριολεκτικού κειμένου | [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Διαμόρφωση αντιστοίχισης κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/) για έλεγχο της αντιστοίχισης:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) περιορίζει τις αντιστοιχίσεις σε ολοκληρωμένες λέξεις.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ελέγχει αν πρέπει να ταιριάζει το χαρακτήρα κεφαλαίων/μικρών.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) περιλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, έτσι οι κανόνες αντιστοίχισης όπως η ευαισθησία κεφαλαίων/μικρών και τα όρια λέξεων ορίζονται από την έκφραση και τις σημαίες της.

## **Συλλογή πληροφοριών αντιστοιχίσεων με κλήση επιστροφής**

Υλοποιήστε το [IFindResultCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifindresultcallback/) για να λαμβάνετε ειδοποίηση για κάθε αντιστοίχηση. Η μέθοδος [IFindResultCallback.foundResult](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση της αντιστοίχισης.

Η κλήση επιστροφής δεν λαμβάνει απευθείας τον αριθμό της διαφάνειας. Η υλοποίηση παρακάτω τον προεξάγει από τη γονική διαφάνεια και επίσης διαχειρίζεται κείμενο που βρίσκεται σε σημειώσεις διαφάνειας. Ένα nullable `Integer` επιτρέπει στο ίδιο μοντέλο αποτελεσμάτων να αναπαριστά κείμενο που σχετίζεται με άλλους τύπους διαφάνειας.

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

Για λειτουργίες αντικατάστασης, το `foundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, έτσι η κλήση επιστροφής μπορεί να καταγράψει ακριβώς ποιοι όροι αντικαταστάθηκαν.

## **Επισήμανση κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για να επισημάνετε τις κυριολεκτικές αντιστοιχίσεις σε ένα πλαίσιο κειμένου. Περνάτε το [TextSearchOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και μια κλήση επιστροφής για τη συλλογή λεπτομερειών αντιστοίχισης.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο την ολοκληρωμένη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίσεις τους στην ίδια κλήση επιστροφής.

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

    // Επισημάνετε κάθε εμφάνιση του "try" στο πλαίσιο κειμένου.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    Color wholeWordHighlightColor = new Color(238, 130, 238);

    // Επισημάνετε μόνο την ολοκληρωμένη λέξη "to".
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

## **Επισήμανση κειμένου με χρήση κανονικών εκφράσεων**

Η μέθοδος [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) επισημαίνει τις αντιστοιχίσεις κειμένου που βρέθηκαν με μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συλλέγει κάθε αντιστοίχηση:

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

Το αποτέλεσμα:

![Το επισημασμένο κείμενο χρησιμοποιώντας την κανονική έκφραση](highlighted_text_using_regex.png)

## **Επισήμανση κειμένου σε ολόκληρη την παρουσίαση**

Χρησιμοποιήστε τα [Presentation.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [Presentation.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, διατηρώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

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

## **Αντικατάσταση κειμένου σε πλαίσιο κειμένου**

Χρησιμοποιήστε το [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για κυριολεκτικό κείμενο και το [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, το οποίο διατηρεί τη μορφοποίηση του γύρω τμήματος αντί να δημιουργεί το πλαίσιο κειμένου εκ νέου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα τυποποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες εκδόσεων. Η ίδια κλήση επιστροφής καταγράφει τους αρχικούς όρους που αντιστοιχίστηκαν και από τις δύο λειτουργίες.

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

## **Αντικατάσταση κειμένου σε ολόκληρη την παρουσίαση**

Χρησιμοποιήστε τα [Presentation.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [Presentation.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για εκκαθάριση προτύπων, ενημερώσεις ορολογίας και διαγράφηση.

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

## **Ομαδοποίηση αντιστοιχίσεων για αναφορά**

Καθώς κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίσεις για ελεγκτικούς, αναφορικούς ή επανεξεταστικούς κύκλους εργασίας. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και μετά ανά πλαίσιο κειμένου:

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

## **Συχνές ερωτήσεις**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε το [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ή το [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι επιπέδου παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου αντί για αυτό.

**Πώς μπορώ να αντιστοιχίσω ολοκληρωμένες λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε τα [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) και [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) σε `true` και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την κεφαλαιοποίηση στην ίδια τη Java `Pattern`.

**Μπορούν η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο σε σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης. Η υλοποίηση της κλήσης επιστροφής που εμφανίζεται παραπάνω αντιστοιχίζει μια αντιστοίχηση σε διαφάνεια σημειώσεων στον αριθμό της γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω τη παρουσίαση δεύτερη φορά;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifindresultcallback/) στην λειτουργία επισήμανσης ή αντικατάστασης. Η κλήση επιστροφής λαμβάνει κάθε αντιστοίχηση κατά τη διάρκεια της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προεξαχθέντα αριθμό διαφάνειας για μεταγενέστερη ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Τα [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) τροποποιούν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση του γύρω τμήματος. Εάν μια αντιστοίχηση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα ώστε η αντικατάσταση να χρησιμοποιεί το επιθυμητό στυλ.