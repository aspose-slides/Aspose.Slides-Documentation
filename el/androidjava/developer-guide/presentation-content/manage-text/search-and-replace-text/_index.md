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
- callback αποτελέσματος
- πλαίσιο κειμένου
- αναφορά ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Αναζητήστε, επισημάνετε και αντικαταστήστε κείμενο σε παρουσιάσεις PowerPoint, συλλέγοντας κάθε αντιστοίχηση με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java μπορεί να αναζητήσει, να επισήμανει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε όλη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιεί μια εφαρμογή για κάθε αντιστοίχιση μέσω μιας κλήσης επιστροφής αποτελεσμάτων. Αυτό καθιστά δυνατό το να ενημερώνεται μια παρουσίαση και ταυτόχρονα να δημιουργείται ένα αρχείο audit που περιέχει το αντίστοιχο κείμενο, το περιβάλλον του, τη θέση, το πλαίσιο κειμένου και τον αριθμό διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, σβήσιμο, ελέγχους ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα «sample.pptx», το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το παρακάτω κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή Περιοχής Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε μεθόδους στο [IPresentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/) για να επεξεργαστείτε όλο το κείμενο που είναι εφαρμόσιμο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Επισήμανση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) | [IPresentation.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση κυριολεκτικού κειμένου | [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση αντιστοιχίσεων κανονικής έκφρασης | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [IPresentation.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Διαμόρφωση Αντιστοίχισης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/) για να ελέγχετε την αντιστοίχιση:

- Το [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) περιορίζει τις αντιστοιχίες σε ολόκληρες λέξεις.
- Το [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ελέγχει αν πρέπει να ταιριάζει η διάκριση πεζών‑κεφαλαίων.
- Το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) περιλαμβάνει τις σημειώσεις διαφανειών στις λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, έτσι οι κανόνες αντιστοίχισης όπως η διάκριση πεζών‑κεφαλαίων και τα σύνορα λέξεων ορίζονται από την έκφραση και τις σημαίες της.

## **Αναγνώριση Ιδιοκτήτη Πλαισίου Κειμένου**

Γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [ITextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/) ενώ αναζητούν, αντικαθιστούν, επικυρώνουν ή εξάγουν κείμενο. Χρησιμοποιήστε τα [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentShape--) και [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentCell--) για να προσδιορίσετε ποιο αντικείμενο παρουσίασης είναι ιδιοκτήτης του πλαισίου κειμένου.

| Ιδιοκτήτης πλαισίου κειμένου | `getParentShape` | `getParentCell` |
|---|---|---|
| Ένα AutoShape ή κάποιο άλλο σχήμα που περιέχει κείμενο | Το ιδιοκτησιακό [IShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ishape/) | `null` |
| Ένα κελί πίνακα | `null` | Το ιδιοκτησιακό [ICell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/icell/) |

Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Η κλήση τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας θα πρέπει να ελέγχει και τις δύο τιμές για `null` και να αντιμετωπίζει την πιθανότητα να μην είναι διαθέσιμος κανένας ιδιοκτήτης.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) για να διατρέξει τα πλαίσια κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης Java και τη διαφάνεια που τα περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και γραμμής που ξεκινούν από το μηδέν και τη διαφάνεια που τα περιέχει.

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

Για περιεχόμενο SmartArt, διατρέξτε τα σχήματα στο [ISmartArtNode.getShapes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartartnode/#getShapes--) και αποκτήστε πρόσβαση σε κάθε [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--). Το πλαίσιο κειμένου μπορεί να εντοπιστεί προς το συσχετισμένο σχήμα μέσω του [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentShape--), ενώ το [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει `null`. Συνεπώς, ο κλάδος σχήματος στο παράδειγμα διαχειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Callback**

Εφαρμόστε το [IFindResultCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifindresultcallback/) για να λαμβάνετε ειδοποίηση για κάθε αντιστοίχιση. Η μέθοδός του [IFindResultCallback.foundResult](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) παρέχει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο και τη θέση της αντιστοίχισης.

Το callback δεν λαμβάνει άμεσα τον αριθμό διαφάνειας. Η υλοποίηση παρακάτω το αποσπά από τη γονική διαφάνεια και επίσης επεξεργάζεται κείμενο που βρέθηκε στις σημειώσεις διαφάνειας. Ένα nullable `Integer` επιτρέπει στο ίδιο μοντέλο αποτελεσμάτων να αντιπροσωπεύει κείμενο που σχετίζεται με άλλους τύπους διαφανειών.

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

Για λειτουργίες αντικατάστασης, `foundText` περιέχει το αρχικό αντιστοιχισμένο κείμενο, ώστε το callback να μπορεί να καταγράψει ακριβώς ποιες όροι αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για να επισήμανετε αντιστοιχίσεις κυριολεκτικού κειμένου σε ένα πλαίσιο κειμένου. Περάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και ένα callback για τη συλλογή λεπτομερειών αντιστοιχίας.

Ο κώδικας παρακάτω επισήμανει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισήμανει μόνο τη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στο ίδιο callback.

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

    // Επισήμανε κάθε εμφάνιση του "try" στο πλαίσιο κειμένου.
    shape.getTextFrame().highlightText("try", substringHighlightColor, substringSearchOptions, callback);

    TextSearchOptions wholeWordSearchOptions = new TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    int wholeWordHighlightColor = Color.rgb(238, 130, 238);

    // Επισήμανε μόνο τη πλήρη λέξη "to".
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

## **Επισήμανση Κειμένου Με Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) επισήμανε τα ταιριαστά κείμενα που βρέθηκαν από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισήμανε όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες και συγκέντρωσε κάθε αντιστοιχία:

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

## **Επισήμανση Κειμένου Σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [IPresentation.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [IPresentation.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-) για να αναζητήσετε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισήμανε έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email, κρατώντας ξεχωριστές συλλογές αποτελεσμάτων για τις δύο αναζητήσεις.

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

Χρησιμοποιήστε το [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για κυριολεκτικό κείμενο και το [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για αντικατάσταση βάσει προτύπου. Αυτές οι μέθοδοι ενημερώνουν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, διατηρώντας τη μορφοποίηση του περιβάλλοντος τμήματος αντί να επανακατασκευάσουν το πλαίσιο κειμένου από μια ακατέργαστη συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης. Το ίδιο callback καταγράφει τους αρχικούς όρους που ταιριάχθηκαν και στις δύο λειτουργίες.

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

Αν μια αντιστοίχιση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου Σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [IPresentation.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [IPresentation.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και σβήσιμο.

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

## **Ομαδοποίηση Αντιστοιχιών για Αναφορά**

Καθώς κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιήσουν τις αντιστοιχίες για ελεγκτικές, αναφορικές ή ανασκοπικές ροές εργασίας. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και στη συνέχεια ανά πλαίσιο κειμένου:

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

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Αποκτήστε το πλαίσιο κειμένου του σχήματος και καλέστε [ITextFrame.highlightText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.lang.Integer-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.lang.Integer-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ή [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι επιπέδου παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου.

**Πώς μπορώ να ταιριάξω ολοκληρωμένες λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) και το [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) σε `true` και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε τα σύνορα λέξεων και τη διάκριση πεζών‑κεφαλαίων στην ίδια την Java `Pattern`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου επιπέδου παρουσίασης. Η υλοποίηση του callback που φαίνεται παραπάνω αντιστοιχίζει μια αντιστοίχιση σε διαφάνεια σημειώσεων πίσω στον αριθμό της γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώσω την παρουσίαση για δεύτερη φορά;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifindresultcallback/) στη λειτουργία επισήμανσης ή αντικατάστασης. Το callback λαμβάνει κάθε αντιστοίχιση κατά τη διάρκεια της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το πηγαίο κείμενο, το αντιστοιχισμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον παραγόμενο αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Τα [ITextFrame.replaceText](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) τροποποιούν το αντιστοιχισμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση του περιβάλλοντος τμήματος. Αν μια αντιστοίχιση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να εξασφαλίσετε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.