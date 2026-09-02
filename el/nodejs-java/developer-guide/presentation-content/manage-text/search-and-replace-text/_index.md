---
title: Αναζήτηση και Αντικατάσταση Κειμένου σε Παρουσιάσεις PowerPoint σε JavaScript
linktitle: Αναζήτηση και Αντικατάσταση Κειμένου
type: docs
weight: 55
url: /el/nodejs-java/search-and-replace-text/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Αναζήτηση, επισήμανση και αντικατάσταση κειμένου σε παρουσιάσεις PowerPoint ενώ συλλέγετε κάθε αντιστοιχία με Aspose.Slides for Node.js via Java."
---
## **Επισκόπηση**

Aspose.Slides for Node.js via Java μπορεί να αναζητά, να επισήμανε και να αντικαταστήσει κείμενο σε ένα μεμονωμένο πλαίσιο κειμένου ή σε ολόκληρη την παρουσίαση. Κάθε λειτουργία μπορεί επίσης να ειδοποιήσει μια εφαρμογή για κάθε αντιστοιχία μέσω μιας κλήσης επιστροφής αποτελέσματος. Αυτό καθιστά εφικτή την ενημέρωση μιας παρουσίασης και ταυτόχρονα τη δημιουργία μιας αλυσίδας ελέγχου που περιέχει το ταιριασμένο κείμενο, το πλαίσιο του, τη θέση, το πλαίσιο κειμένου και τον αριθμό της διαφάνειας.

Αυτές οι δυνατότητες είναι χρήσιμες για ανασκόπηση, διαγραφή, έλεγχο ορολογίας, καθαρισμό προτύπων και αυτοματοποιημένες ροές εργασίας αναφοράς.

Στα πρώτα παραδείγματα παρακάτω, χρησιμοποιούμε ένα αρχείο με όνομα "sample.pptx", το οποίο περιέχει ένα μόνο πλαίσιο κειμένου στην πρώτη διαφάνεια με το ακόλουθο κείμενο:

![Sample text](sample_text.png)

## **Επιλογή Πεδίου Αναζήτησης**

Χρησιμοποιήστε μεθόδους στο [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) για να περιορίσετε μια λειτουργία σε ένα πλαίσιο κειμένου. Χρησιμοποιήστε μεθόδους στο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) για να επεξεργαστείτε όλο το κείμενο που είναι εφαρμόσιμο στην παρουσίαση.

| Λειτουργία | Ένα πλαίσιο κειμένου | Ολόκληρη η παρουσίαση |
|---|---|---|
| Επισήμανση κυριολεκτικού κειμένου | [TextFrame.highlightText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Επισήμανση ταιριάσεων κανονικής έκφρασης | [TextFrame.highlightRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) | [Presentation.highlightRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση κυριολεκτικού κειμένου | [TextFrame.replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) |
| Αντικατάσταση ταιριάσεων κανονικής έκφρασης | [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) | [Presentation.replaceRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) |

## **Διαμόρφωση Ταίριαξης Κειμένου**

Για λειτουργίες κυριολεκτικού κειμένου, χρησιμοποιήστε το [TextSearchOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/) για έλεγχο της ταίριαξης:

- [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) περιορίζει τις αντιστοιχίες σε ολόκληρες λέξεις.
- [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) ελέγχει εάν η περίπτωσή των χαρακτήρων πρέπει να ταιριάζει.
- [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) περιλαμβάνει σημειώσεις διαφάνειας σε λειτουργίες αναζήτησης, αντικατάστασης και επισήμανσης σε επίπεδο παρουσίασης.

Οι λειτουργίες κανονικής έκφρασης χρησιμοποιούν ένα Java `Pattern`, επομένως οι κανόνες ταίριαξης όπως η ευαισθησία σε πεζά/κεφαλαία και τα όρια λέξης ορίζονται από την έκφραση και τις σημαίες της.

## **Αναγνώριση Κατόχου Πλαισίου Κειμένου**

Γενικές ροές επεξεργασίας κειμένου συχνά λαμβάνουν ένα [TextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/) ενώ αναζητούν, αντικαθιστούν, επικυρώνουν ή εξάγουν κείμενο. Χρησιμοποιήστε το [TextFrame.getParentShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentShape--) και το [TextFrame.getParentCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentCell--) για να προσδιορίσετε ποιο αντικείμενο παρουσίασης κατέχει το πλαίσιο κειμένου.

Οι αναμενόμενες τιμές εξαρτώνται από τον κάτοχο:

| Κατοχέας πλαισίου κειμένου | `getParentShape` | `getParentCell` |
|---|---|---|
| AutoShape ή άλλο σχήμα που περιέχει κείμενο | Το ιδιοκτησιακό [Shape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/shape/) | `null` |
| Κελί πίνακα | `null` | Το ιδιοκτησιακό [Cell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/cell/) |

Και οι δύο μέθοδοι παρέχουν πλοήγηση μόνο για ανάγνωση. Η κλήση τους δεν μετακινεί το πλαίσιο κειμένου ούτε αλλάζει τον κάτοχό του. Ο γενικός κώδικας πρέπει να ελέγχει και τις δύο τιμές για `null` και να διαχειρίζεται την πιθανότητα να μην είναι διαθέσιμος κανένας κάτοχος.

Το παρακάτω παράδειγμα χρησιμοποιεί το [SlideUtil.getAllTextFrames](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slideutil/#getAllTextFrames-aspose.slides.IPresentation-boolean-) για επανάληψη μέσω των πλαισίων κειμένου σε μια παρουσίαση. Για σχήματα, αναφέρει το όνομα του σχήματος, τον τύπο χρόνου εκτέλεσης Java και τη διαφάνεια που το περιέχει. Για κελιά πίνακα, αναφέρει τις συντεταγμένες στήλης και σειράς (μηδενική αρίθμηση) και τη διαφάνεια που το περιέχει.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideLabel(baseSlide) {
    if (java.instanceOf(baseSlide, "com.aspose.slides.Slide")) {
        return "slide " + baseSlide.getSlideNumber();
    }

    if (java.instanceOf(baseSlide, "com.aspose.slides.NotesSlide")) {
        return "notes for slide " + baseSlide.getParentSlide().getSlideNumber();
    }

    return baseSlide.getClass().getSimpleName();
}

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const textFrames = aspose.slides.SlideUtil.getAllTextFrames(presentation, false);

    for (let index = 0; index < textFrames.length; index++) {
        const textFrame = textFrames[index];
        const ownerShape = textFrame.getParentShape();
        if (ownerShape !== null) {
            const shapeName = ownerShape.getName() === "" ? "(unnamed)" : ownerShape.getName();
            const shapeType = ownerShape.getClass().getSimpleName();
            const slideLabel = getSlideLabel(ownerShape.getSlide());
            console.log("Shape: " + shapeName + "; type: " + shapeType + "; " + slideLabel);
            continue;
        }

        const ownerCell = textFrame.getParentCell();
        if (ownerCell !== null) {
            const slideLabel = getSlideLabel(ownerCell.getSlide());
            console.log("Table cell: column " + ownerCell.getFirstColumnIndex() + ", row " + ownerCell.getFirstRowIndex() + "; " + slideLabel);
            continue;
        }

        console.log("The text frame owner is not available as a shape or table cell.");
    }
} finally {
    presentation.dispose();
}
```

Για περιεχόμενο SmartArt, επαναλάβετε μέσω των σχημάτων στο [SmartArtNode.getShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartnode/#getShapes--) και αποκτήστε το κάθε [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/smartartshape/#getTextFrame--). Το πλαίσιο κειμένου μπορεί να εντοπιστεί στο σχετικό του σχήμα μέσω του [TextFrame.getParentShape](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentShape--), ενώ το [TextFrame.getParentCell](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getParentCell--) επιστρέφει `null`. Συνεπώς, ο κλάδος σχήματος στο παράδειγμα διαχειρίζεται επίσης κείμενο από κόμβους SmartArt.

## **Συλλογή Πληροφοριών Αντιστοιχίας με Callback**

Δημιουργήστε έναν διαμεσολαβητή Java για την κλήση επιστροφής αποτελεσμάτων ώστε να λαμβάνετε ειδοποίηση για κάθε αντιστοιχία. Η συνάρτηση proxy λαμβάνει το σχετικό πλαίσιο κειμένου, το πηγαίο κείμενο, το ταιριασμένο κείμενο και τη θέση της αντιστοιχίας.

Η κλήση επιστροφής δεν λαμβάνει άμεσα αριθμό διαφάνειας. Η υλοποίηση παρακάτω το προκύπτει μέσω του σχήματος ή του κελιού πίνακα που κατέχει το πλαίσιο κειμένου, με το [TextFrame.getSlide](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#getSlide--) ως εναλλακτική. Επίσης διαχειρίζεται κείμενο που βρίσκεται σε σημειώσεις διαφάνειας.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

function createTextSearchCallback(results) {
    return java.newProxy("com.aspose.slides.IFindResultCallback", {
        foundResult: function(textFrame, sourceText, foundText, textPosition) {
            results.push({
                textFrame: textFrame,
                sourceText: sourceText,
                foundText: foundText,
                textPosition: textPosition,
                slideNumber: getSlideNumber(textFrame)
            });
        }
    });
}
```

Για λειτουργίες αντικατάστασης, το `foundText` περιέχει το αρχικό ταιριασμένο κείμενο, ώστε η κλήση επιστροφής να μπορεί να καταγράψει ακριβώς ποιες λέξεις αντικαταστάθηκαν.

## **Επισήμανση Κειμένου**

Χρησιμοποιήστε τη μέθοδο [TextFrame.highlightText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για να επισήμανετε κυριολεκτικές αντιστοιχίες κειμένου σε ένα πλαίσιο κειμένου. Πέρασμα του [TextSearchOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/) ελέγχει την αναζήτηση.

Το παράδειγμα κώδικα παρακάτω επισημαίνει όλες τις εμφανίσεις των χαρακτήρων **"try"** και στη συνέχεια επισημαίνει μόνο τη πλήρη λέξη **"to"**.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const substringSearchOptions = new aspose.slides.TextSearchOptions();
    substringSearchOptions.setCaseSensitive(false);
    const substringHighlightColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    // Επισήμανση κάθε εμφάνισης του "try" στο πλαίσιο κειμένου.
    shape.getTextFrame().highlightText(
        "try", substringHighlightColor, substringSearchOptions, null);

    const wholeWordSearchOptions = new aspose.slides.TextSearchOptions();
    wholeWordSearchOptions.setWholeWordsOnly(true);
    wholeWordSearchOptions.setCaseSensitive(false);
    const wholeWordHighlightColor = java.getStaticFieldValue("java.awt.Color", "MAGENTA");

    // Επισήμανση μόνο της πλήρους λέξης "to".
    shape.getTextFrame().highlightText(
        "to", wholeWordHighlightColor, wholeWordSearchOptions, null);

    presentation.save("highlighted_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The highlighted text](highlighted_text.png)

## **Επισήμανση Κειμένου με Κανονικές Εκφράσεις**

Η μέθοδος [TextFrame.highlightRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) επισημαίνει ταιριάσεις κειμένου που βρέθηκαν με μια κανονική έκφραση σε ένα πλαίσιο κειμένου.

Ο παρακάτω κώδικας επισημαίνει όλες τις λέξεις που περιέχουν επτά ή περισσότερους χαρακτήρες:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const regex = Pattern.compile("\\b[^\\s]{7,}\\b");
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    shape.getTextFrame().highlightRegex(regex, highlightColor, null);

    presentation.save(
        "highlighted_text_using_regex.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Το αποτέλεσμα:

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Επισήμανση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.highlightText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [Presentation.highlightRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-) για αναζήτηση σε όλα τα εφαρμόσιμα πλαίσια κειμένου σε μια παρουσίαση. Το παρακάτω παράδειγμα επισημαίνει έναν κυριολεκτικό όρο και όλες τις διευθύνσεις email:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);
    const termHighlightColor = java.getStaticFieldValue("java.awt.Color", "ORANGE");

    presentation.highlightText(
        "confidential", termHighlightColor, searchOptions, null);

    const emailRegex = Pattern.compile(
        "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b",
        Pattern.CASE_INSENSITIVE);
    const emailHighlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightRegex(emailRegex, emailHighlightColor, null);
    presentation.save("highlighted_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Αντικατάσταση Κειμένου σε Πλαίσιο Κειμένου**

Χρησιμοποιήστε το [TextFrame.replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) για κυριολεκτικό κείμενο και το [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για αντικατάσταση με βάση πρότυπο. Αυτές οι μέθοδοι ενημερώνουν το ταιριασμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου, διατηρώντας τη μορφοποίηση του περιβάλλοντος κειμένου αντί να δημιουργούν εκ νέου το πλαίσιο από μια απλή συμβολοσειρά.

Το παρακάτω παράδειγμα ενοποιεί μια παραλλακτική ορθογραφία και στη συνέχεια αντικαθιστά ετικέτες εκδόσεων:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(false);

    shape.getTextFrame().replaceText(
        "colour", "color", searchOptions, null);

    const versionRegex = Pattern.compile(
        "\\bv\\d+(?:\\.\\d+)*\\b", Pattern.CASE_INSENSITIVE);
    shape.getTextFrame().replaceRegex(versionRegex, "current version", null);

    presentation.save("updated_text_frame.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Εάν μία αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, ελέγξτε το αποτέλεσμα για να επιβεβαιώσετε ποια μορφοποίηση πρέπει να εφαρμοστεί στο κείμενο αντικατάστασης.

## **Αντικατάσταση Κειμένου σε Όλη την Παρουσίαση**

Χρησιμοποιήστε τα [Presentation.replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [Presentation.replaceRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) για να εφαρμόσετε τις ίδιες λειτουργίες σε όλη την παρουσίαση. Αυτό είναι χρήσιμο για καθαρισμό προτύπων, ενημερώσεις ορολογίας και διαγραφή ευαίσθητων στοιχείων.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const Pattern = java.import("java.util.regex.Pattern");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setWholeWordsOnly(true);
    searchOptions.setCaseSensitive(true);

    presentation.replaceText(
        "Contoso", "Example Corp", searchOptions, null);

    const accountNumberRegex = Pattern.compile("\\bACCT-\\d{6}\\b");
    presentation.replaceRegex(accountNumberRegex, "ACCT-REDACTED", null);

    presentation.save("updated_presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ομαδοποίηση Αντιστοιχιών για Αναφορά**

Επειδή κάθε συλλεγμένο αποτέλεσμα αποθηκεύει τον αριθμό της διαφάνειας και το πλαίσιο κειμένου, οι εφαρμογές μπορούν να ομαδοποιούν τις αντιστοιχίες για ελέγχους, αναφορές ή ροές εργασίας ανασκόπησης. Το παρακάτω παράδειγμα ομαδοποιεί τα αποτελέσματα πρώτα ανά διαφάνεια και στη συνέχεια ανά πλαίσιο κειμένου:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getSlideNumber(textFrame) {
    const parentShape = textFrame.getParentShape();
    const parentCell = textFrame.getParentCell();
    let parentSlide = textFrame.getSlide();
    if (parentShape !== null) {
        parentSlide = parentShape.getSlide();
    } else if (parentCell !== null) {
        parentSlide = parentCell.getSlide();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.Slide")) {
        return parentSlide.getSlideNumber();
    }

    if (java.instanceOf(parentSlide, "com.aspose.slides.NotesSlide")) {
        return parentSlide.getParentSlide().getSlideNumber();
    }

    return null;
}

const results = [];
const callback = java.newProxy("com.aspose.slides.IFindResultCallback", {
    foundResult: function(textFrame, sourceText, foundText, textPosition) {
        results.push({
            textFrame: textFrame,
            sourceText: sourceText,
            foundText: foundText,
            textPosition: textPosition,
            slideNumber: getSlideNumber(textFrame)
        });
    }
});

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const searchOptions = new aspose.slides.TextSearchOptions();
    searchOptions.setCaseSensitive(false);
    const highlightColor = java.getStaticFieldValue("java.awt.Color", "YELLOW");

    presentation.highlightText(
        "confidential", highlightColor, searchOptions, callback);

    const matchesBySlide = new Map();

    for (const result of results) {
        const slideLabel = result.slideNumber === null ? "Other" : result.slideNumber;

        if (!matchesBySlide.has(slideLabel)) {
            matchesBySlide.set(slideLabel, new Map());
        }

        const matchesByTextFrame = matchesBySlide.get(slideLabel);
        if (!matchesByTextFrame.has(result.textFrame)) {
            matchesByTextFrame.set(result.textFrame, []);
        }

        matchesByTextFrame.get(result.textFrame).push(result);
    }

    for (const [slideLabel, matchesByTextFrame] of matchesBySlide) {
        console.log("Slide: " + slideLabel);

        for (const [textFrame, textFrameMatches] of matchesByTextFrame) {
            console.log("  Text frame: " + textFrame.getText());

            for (const result of textFrameMatches) {
                console.log(
                    "    '" + result.foundText + "' at position " +
                    result.textPosition + "; context: '" + result.sourceText + "'");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να αναζητήσω μόνο ένα πλαίσιο κειμένου αντί για ολόκληρη την παρουσίαση;**

Λάβετε το πλαίσιο κειμένου του σχήματος και καλέστε το [TextFrame.highlightText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#highlightText-java.lang.String-java.awt.Color-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), [TextFrame.highlightRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#highlightRegex-java.util.regex.Pattern-java.awt.Color-com.aspose.slides.IFindResultCallback-), [TextFrame.replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-), ή [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) σε αυτό το πλαίσιο κειμένου. Οι μέθοδοι επιπέδου παρουσίασης επεξεργάζονται όλα τα εφαρμόσιμα πλαίσια κειμένου.

**Πώς μπορώ να ταιριάξω πλήρεις λέξεις με τη σωστή κεφαλαιοποίηση;**

Ορίστε το [TextSearchOptions.setWholeWordsOnly](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/#setWholeWordsOnly-boolean-) και το [TextSearchOptions.setCaseSensitive](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/#setCaseSensitive-boolean-) σε `true`, και περάστε τις επιλογές σε μια μέθοδο επισήμανσης ή αντικατάστασης κυριολεκτικού κειμένου. Για κανονικές εκφράσεις, ορίστε όρια λέξεων και ευαισθησία σε πεζά/κεφαλαία στην ίδια τη Java `Pattern`.

**Μπορεί η αναζήτηση και η αντικατάσταση να περιλαμβάνει κείμενο σε σημειώσεις διαφάνειας;**

Ναι. Ορίστε το [TextSearchOptions.setIncludeNotes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textsearchoptions/#setIncludeNotes-boolean-) σε `true` όταν χρησιμοποιείτε μια λειτουργία κυριολεκτικού κειμένου επιπέδου παρουσίασης. Η υλοποίηση της κλήσης επιστροφής που φαίνεται παραπάνω αντιστοιχίζει μια αντιστοιχία σε μια σημείωση διαφάνειας στον αριθμό της γονικής διαφάνειας.

**Πώς μπορώ να δημιουργήσω αναφορά χωρίς να σαρώσω ξανά την παρουσίαση;**

Περάστε έναν διαμεσολαβητή Java για την κλήση επιστροφής αποτελέσματος στη λειτουργία επισήμανσης ή αντικατάστασης. Η κλήση επιστροφής λαμβάνει κάθε αντιστοιχία κατά την εκτέλεση της λειτουργίας, ώστε η εφαρμογή να αποθηκεύει το πηγαίο κείμενο, το ταιριασμένο κείμενο, τη θέση, το πλαίσιο κειμένου και τον προεξαχθέντα αριθμό διαφάνειας για μεταγενέστερη ομαδοποίηση ή εξαγωγή.

**Διατηρεί η αντικατάσταση κειμένου τη μορφοποίησή του;**

Τα [TextFrame.replaceText](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceText-java.lang.String-java.lang.String-com.aspose.slides.ITextSearchOptions-com.aspose.slides.IFindResultCallback-) και [TextFrame.replaceRegex](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/textframe/#replaceRegex-java.util.regex.Pattern-java.lang.String-com.aspose.slides.IFindResultCallback-) τροποποιούν το ταιριασμένο κείμενο εντός του υπάρχοντος πλαισίου κειμένου και διατηρούν τη μορφοποίηση του περιβάλλοντος τμήματος. Εάν μια αντιστοιχία καλύπτει τμήματα με διαφορετική μορφοποίηση, εξετάστε το αποτέλεσμα για να βεβαιωθείτε ότι η αντικατάσταση χρησιμοποιεί το επιθυμητό στυλ.