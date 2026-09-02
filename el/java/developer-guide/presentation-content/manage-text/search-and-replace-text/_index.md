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
- έκθεση ελέγχου
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Αναζήτηση, επισήμανση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint ενώ συλλέγονται όλες οι αντιστοιχίες με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Aspose.Slides for Java μπορεί να αναζητήσει, να επισημάνει και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη μια παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιήσει μια εφαρμογή για κάθε αντιστοίχιση μέσω μιας κλήσης επιστροφής αποτελέσματος. Αυτό καθιστά δυνατό το να ενημερώσετε μια παρουσίαση και ταυτόχρονα να δημιουργήσετε ένα αρχείο ελέγχου που περιέχει το κείμενο που ταιριάζει, το συμφραζόμενο, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ελέγχους, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφορών.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το παρακάτω κείμενο:

![Δείγμα κειμένου](sample_text.png)

## **Επιλογή Πεδίο Αναζήτησης**

Χρησιμοποιήστε τις μεθόδους στο [ITextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε τις μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/) για να επεξεργαστείτε όλα τα εφαρμόσιμα κείμενα στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Επιδείξτε κυριολεκτικό κείμενο | [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Επιδείξτε αντιστοιχίες κανονικής έκφρασης | [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Αντικαταστήστε κυριολεκτικό κείμενο | [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Αντικαταστήστε αντιστοιχίες κανονικής έκφρασης | [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Διαμόρφωση Ταίριαξης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/) για να ελέγξετε το ταίριασμα:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) περιορίζει τις αντιστοιχίες σε πλήρεις λέξεις.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ελέγχει αν η περίπτωση των χαρακτήρων πρέπει να ταιριάζει.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) περιλαμβάνει τις σημειώσεις διαφάνειας στις λειτουργίες αναζήτησης, αντικατάστασης και επισημάνσεως σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, έτσι οι κανόνες ταίριαξης όπως η ευαισθησία στην κεφαλαία/μικρά γράμματα και τα όρια λέξεων ορίζονται από την έκφραση και τις σημαίες της.

## **Αναγνώριση Ιδιοκτήτη Πλαισίου Κειμένου**

Οι γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [ITextFrame] κατά την αναζήτηση, αντικατάσταση, επαλήθευση ή εξαγωγή κειμένου. Χρησιμοποιήστε τα [ITextFrame.getParentShape] και [ITextFrame.getParentCell] για να προσδιορίσετε ποιο αντικείμενο παρουσίασης κατέχει το πλαίσιο κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον ιδιοκτήτη:

| Ιδιοκτήτης πλαισίου κειμένου | `getParentShape` | `getParentCell` |
|---|---|---|
| Ένα AutoShape ή άλλο σχήμα που περιέχει κείμενο | Το ιδιόκτητο [IShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/ishape/) | `null` |
| Κελί πίνακα | `null` | Το ιδιόκτητο [ICell](https://reference.aspose.com/slides/el/java/com.aspose.slides/icell/) |

Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Η κλήση τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον ιδιοκτήτη του. Ο γενικός κώδικας πρέπει να ελέγχει και τις δύο τιμές για `null` και να διαχειρίζεται την πιθανότητα να μην υπάρχει διαθέσιμος κανένας ιδιοκτήτης.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/el/java/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) για να επαναλάβει τα πλαίσια κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης Java και τη διαφάνεια που τα περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και γραμμής με βάση το μηδέν και τη διαφάνεια που τα περιέχει.

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

Για περιεχόμενο SmartArt, επαναλάβετε τα σχήματα σε [ISmartArtNode.getShapes](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartartnode/#getShapes--) και αποκτήστε το καθένα μέσω [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/java/com.aspose.slides/ismartartshape/#getTextFrame--). Το πλαίσιο κειμένου μπορεί να ανιχνευθεί στο σχετικό σχήμα μέσω [ITextFrame.getParentShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentShape--), ενώ το [ITextFrame.getParentCell](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#getParentCell--) επιστρέφει `null`. Συνεπώς, ο κλάδος σχήματος στο παράδειγμα χειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή Πληροφοριών Αντιστοίχησης με Callback**

Εφαρμόστε το [IFindResultCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifindresultcallback/) για να λαμβάνετε ειδοποίηση για κάθε αντιστοίχιση. Η μέθοδος [IFindResultCallback.foundResult](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifindresultcallback/#foundResult-com.aspose.slides.ITextFrame-java.lang.String-java.lang.String-int-) παρέχει το σχετικό πλαίσιο κειμένου, το κείμενο προέλευσης, το κείμενο που ταιριάζει και τη θέση της αντιστοίχισης.

Το callback δεν λαμβάνει άμεσα τον αριθμό της διαφάνειας. Η παρακάτω υλοποίηση τον εξάγει από τη γονική διαφάνεια και χειρίζεται επίσης κείμενο που βρίσκεται στις σημειώσεις διαφάνειας. Ένα nullable `Integer` επιτρέπει στο ίδιο μοντέλο αποτελέσματος να αναπαριστά κείμενο που σχετίζεται με άλλους τύπους διαφάνειας.

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

Για λειτουργίες αντικατάστασης, το `foundText` περιέχει το αρχικό κείμενο που ταιριάζει, ώστε το callback να μπορεί να καταγράψει ακριβώς ποιοι όροι αντικαταστάθηκαν.

## **Επισημάνετε Κείμενο**

Χρησιμοποιήστε τη μέθοδο [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για να επισημάνετε κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Περάστε το [TextSearchOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/) για να ελέγξετε την αναζήτηση και ένα callback για να συλλέξετε τις λεπτομέρειες της αντιστοίχισης.

Το παρακάτω παράδειγμα κώδικα επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και έπειτα επισημαίνει μόνο τη πλήρη λέξη **"to"**. Και οι δύο αναζητήσεις αναφέρουν τις αντιστοιχίες τους στο ίδιο callback.

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

    // Επισημάνετε μόνο τη πλήρη λέξη "to".
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

## **Επισημάνετε Κείμενο Χρησιμοποιώντας Κανονικές Εκφράσεις**

Η μέθοδος [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) επισημαίνει τις αντιστοιχίες κειμένου που βρέθηκαν από μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

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

## **Επισημάνετε Κείμενο σε Όλη την Παρουσίαση**

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

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για κυριολεκτικό κείμενο και το [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για αντικατάσταση βασισμένη σε μοτίβο. Αυτές οι μέθοδοι ενημερώνουν το ταιριασμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου, διατηρώντας τη μορφοποίηση των γύρω τμημάτων αντί να ξαναδημιουργούν το πλαίσιο κειμένου από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλαγή ορθογραφίας και στη συνέχεια αντικαθιστά ετικέτες έκδοσης. Το ίδιο callback καταγράφει τους αρχικούς όρους που ταιριάζουν και στις δύο λειτουργίες.

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

Εάν μια αντιστοίχιση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε την έξοδο για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [Presentation.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή.

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

Δεδομένου ότι κάθε αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιήσουν τις αντιστοιχίσεις για ελέγχους, αναφορές ή ροές εργασίας ελέγχου. Το παρακάτω παράδειγμα ομαδοποιεί τα συλλεγμένα αποτελέσματα πρώτα ανά διαφάνεια και μετά ανά πλαίσιο κειμένου:

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

Λάβετε το πλαίσιο κειμένου του σχήματος και καλέστε το [ITextFrame.highlightText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [ITextFrame.highlightRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) ή [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) στο συγκεκριμένο πλαίσιο κειμένου. Οι μέθοδοι σε επίπεδο παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε τα [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) και [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) σε `true` και περάστε τις επιλογές σε μέθοδο κυριολεκτικού κειμένου για επισημάνωση ή αντικατάσταση. Για κανονικές εκφράσεις, ορίστε τα όρια λέξεων και την ευαισθησία σε κεφαλαία/μικρά γράμματα απευθείας στο Java `Pattern`.

**Μπορούν η αναζήτηση και η αντικατάσταση να περιλαμβάνουν κείμενο στις σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/java/com.aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου σε επίπεδο παρουσίασης. Η υλοποίηση του callback που εμφανίζεται παραπάνω αντιστοιχίζει μια αντιστοίχιση σε διαφάνεια σημειώσεων στον γονικό της αριθμό διαφάνειας.

**Πώς μπορώ να δημιουργήσω μια αναφορά χωρίς να σαρώνω τη παρουσίαση δεύτερη φορά;**

Περάστε μια υλοποίηση του [IFindResultCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifindresultcallback/) στη λειτουργία επισημάνσεως ή αντικατάστασης. Το callback λαμβάνει κάθε αντιστοίχιση κατά την εκτέλεση της λειτουργίας, ώστε η εφαρμογή να μπορεί να αποθηκεύσει το κείμενο προέλευσης, το ταιριασμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προέκταση αριθμό διαφάνειας για μετέπειτα ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Οι [ITextFrame.replaceText](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [ITextFrame.replaceRegex](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) τροποποιούν το ταιριασμένο κείμενο μέσα στο υπάρχον πλαίσιο κειμένου και διατηρούν τη μορφοποίηση των γύρω τμημάτων. Εάν μια αντιστοίχιση καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα ώστε η αντικατάσταση να χρησιμοποιεί το επιθυμητό στυλ.