---
title: Διαχείριση πεδίων κειμένου σε παρουσιάσεις PowerPoint με JavaScript
linktitle: Πεδία Κειμένου
type: docs
weight: 52
url: /el/nodejs-java/text-fields/
keywords:
- πεδίο κειμένου
- αυτόματο κείμενο
- αριθμός διαφάνειας
- ημερομηνία και ώρα
- κεφαλίδα
- υποσέλιδο
- μερίδα κειμένου
- PowerPoint
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Δημιουργήστε, ελέγξτε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides για Node.js μέσω Java. Διατηρήστε τη μορφοποίηση και επαληθεύστε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Ένα κείμενο παραγράφου αποτελείται από μερίδες. Μία απλή [Portion](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/) περιέχει κυριολεκτικό κείμενο· μια μερίδα πεδίου έχει επίσης ένα [Field](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/field/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωμένη τιμή, όπως αριθμός διαφάνειας ή ημερομηνία. Δύο μερίδες μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο μία περιέχει πεδίο.

Χρησιμοποιήστε το [Portion.getField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#getField) για να τις διακρίνετε: επιστρέφει `null` για απλό κείμενο. Το [Portion.addField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#addField) μετατρέπει μια υπάρχουσα μερίδα σε πεδίο. Διατηρήστε μια ετικέτα και την δυναμική της τιμή σε ξεχωριστές μερίδες ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης και την ετικέτα.

Αυτός ο οδηγός καλύπτει τα πεδία μέσα στο κείμενο, τη μορφοποίησή τους και την αποθήκευση σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε την ενότητα [Manage Text](/slides/el/nodejs-java/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει την κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, στη συνέχεια ξαναανοίγει την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    const numberPortion = new aspose.slides.Portion();
    const numberColor = java.newInstanceSync("java.awt.Color", 0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    numberPortion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(aspose.slides.FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("slide_number.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        const savedField = savedNumber.getField();
        const hasNumberField = savedField != null && aspose.slides.FieldType.getSlideNumber().getInternalString() === savedField.getType().getInternalString();
        const format = savedNumber.getPortionFormat();
        let formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == aspose.slides.NullableBool.True;
        formattingPreserved = formattingPreserved && format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

        console.log("Text: " + savedShape.getTextFrame().getText());
        console.log("Slide number field: " + hasNumberField);
        console.log("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, έτσι το κείμενο είναι `Slide 1`, και και οι δύο έλεγχοι εμφανίζουν `true`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα· δεν είναι κυριολεκτικό `1`. Οι δείκτες στην επαλήθευση αναφέρονται στο σχήμα και τις μερίδες που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

Το [FieldType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/) παρέχει τις ακόλουθες μεθόδους για να λάβετε προκαθορισμένες τιμές. Μεταβιβάστε την κατάλληλη τιμή στο [addField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#addField).

| Μέθοδος | Σκοπός |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getSlideNumber) | Ο τρέχων αριθμός διαφάνειας. |
| [getDateTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getDateTime) | Η ημερομηνία/ώρα με τη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [getDateTime1](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getDateTime9) | Προκαθορισμένες μορφές ημερομηνίας ή συνδυασμένων ημερομηνίας/ώρας. |
| [getDateTime10](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getDateTime13) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ώροφη ώρα. |
| [getHeader](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getHeader) | Ένα πεδίο κεφαλίδας· δείτε τις περιορισμούς του placeholder και της μορφής παρακάτω. |
| [getFooter](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getFooter) | Ένα πεδίο υποσέλιδου. |

Για παράδειγμα, το [getDateTime3](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getDateTime3) αντιπροσωπεύει μια ημέρα, το πλήρες όνομα του μήνα και το έτος στα Αγγλικά. Πρόκειται για προκαθορισμένες μορφές πεδίου, όχι αυθαίρετες συμβολοσειρές μορφοποίησης ημερομηνίας. Η γλώσσα που ορίζεται με το [setLanguageId](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseportionformat/#setLanguageId) και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση με συμβολοσειρά του [addField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#addField) δέχεται έναν εσωτερικό ταυτοποιητή πεδίου. Χρησιμοποιήστε το όταν διατηρείτε έναν ταυτοποιητή που παρέχεται από άλλη εφαρμογή και δεν έχει προκαθορισμένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/) από τον ταυτοποιητή. Το [FieldType.getInternalString](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fieldtype/#getInternalString) εκθέτει αυτόν τον ταυτοποιητή για εξέταση.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο `custom-report-id` ειδικό για την εφαρμογή με το εναλλακτικό κείμενο `Report-042`. Ο ταυτοποιητής δεν εγγράφει κανένα υπολογισμό: το Aspose.Slides δεν δημιουργεί IDs αναφοράς για άγνωστο τύπο. Η εφαρμογή που καταλαβαίνει αυτόν τον ταυτοποιητή πρέπει να παρέχει το νόημά του και να ενημερώνει την τιμή του.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("custom_field.pptx");
    try {
        const savedShape = reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        const savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        const savedField = savedPortion.getField();
        const typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        console.log("Type: " + typeName);
        console.log("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Μετά από αυτόν τον κύκλο PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η μεταβίβαση μιας συμβολοσειράς όπως `yyyy-MM-dd` θα ονόμαζε έναν τύπο πεδίου· δεν θα ρυθμίζει προσαρμοσμένη μορφή ημερομηνίας. Για μια σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε απλό κείμενο.

## **Επιθεώρηση, Τροποποίηση και Αφαίρεση Πεδίων Ημερομηνίας/Ώρας**

Αλλάξτε ένα υπάρχον πεδίο μέσω του [Field.setType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/field/#setType). Ελέγξτε ότι το πεδίο υπάρχει πριν προσπελάσετε τον τύπο του. Για να διακόψετε τις αυτόματες ενημερώσεις, καλέστε το [Portion.removeField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#removeField). Αυτό διατηρεί τη μερίδα και το τρέχον κείμενό της ενώ αφαιρεί τη σύνδεση του πεδίου. Εάν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, αντιστοιχίστε αυτό το κείμενο μετά την αφαίρεση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#setCurrentDateTime). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης κατά τη μετατροπή ενός πεδίου σε απλό κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον τρέχον κατάλογο εργασίας. Περιέχει δύο ονομαστικά σχήματα κειμένου, `UpdatedAt` και `ApprovedDate`, το καθένα με πεδίο ημερομηνίας/ώρας, καθώς και απλές ετικέτες κειμένου. Το παρακάτω παράδειγμα διασχίζει τα κορυφαία σχήματα κειμένου σε κανονικές διαφάνειες. Μετατρέπει τα πεδία ημερομηνίας/ώρας σε μορφή μακραίας ημερομηνίας και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις. Μόνο τα πεδία στο `ApprovedDate` γίνονται σταθερό κείμενο.

Η ημερομηνία έγκρισης είναι 5 Απριλίου 2030· οι δείκτες μήνα της JavaScript ξεκινούν από το μηδέν, έτσι ο Απρίλιος είναι `3`. Χρησιμοποιείται UTC τόσο για τη δημιουργία όσο και για τη μορφοποίηση ώστε η ημερομηνία να είναι ανεξάρτητη από τη ζώνη ώρας του τοπικού περιβάλλοντος.

Το δείγμα αναγνωρίζει τους ενσωματωμένους εσωτερικούς ταυτοποιητές `datetime` και `datetime1` έως `datetime13`. Οι ομάδες, πίνακες, σημειώσεις, διατάξεις και βασικά θέματα απαιτούν διαπέραση των δικών τους περιεκτών κειμένου και δεν καλύπτονται από αυτό το παράδειγμα.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const approvalDate = new Date(Date.UTC(2030, 3, 5));
    const dateFormat = new Intl.DateTimeFormat("en-GB", { day: "2-digit", month: "long", year: "numeric", timeZone: "UTC" });

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }

            for (let paragraphIndex = 0; paragraphIndex < shape.getTextFrame().getParagraphs().getCount(); paragraphIndex++) {
                const paragraph = shape.getTextFrame().getParagraphs().get_Item(paragraphIndex);
                for (let portionIndex = 0; portionIndex < paragraph.getPortions().getCount(); portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    const field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    const typeName = field.getType().getInternalString();
                    const isDateTime = typeName != null && /^datetime([1-9]|1[0-3])?$/.test(typeName);
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(aspose.slides.FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

                    if (shape.getName() === "ApprovedDate") {
                        portion.removeField();
                        const fixedDate = dateFormat.format(approvalDate);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("updated_dates.pptx");
    try {
        for (let shapeIndex = 0; shapeIndex < reopened.getSlides().get_Item(0).getShapes().size(); shapeIndex++) {
            const shape = reopened.getSlides().get_Item(0).getShapes().get_Item(shapeIndex);
            if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                continue;
            }
            if (shape.getTextFrame() == null) {
                continue;
            }
            if (shape.getName() !== "UpdatedAt" && shape.getName() !== "ApprovedDate") {
                continue;
            }

            const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            const field = portion.getField();
            const typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            console.log(shape.getName() + ": " + typeName + "; " + portion.getText());
            console.log("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Μετά το ξανά άνοιγμα, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και οι δύο μερίδες ημερομηνίας είναι πλάγιες, και το αρχικό μέγεθος γραμματοσειράς, το έντονο στυλ και το χρώμα παραμένουν αμετάβλητα. Οι απλές ετικέτες κειμένου παραμένουν αμετάβλητες. Η επαλήθευση διαβάζει την πρώτη μερίδα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Εργαστείτε με την υπάρχουσα μερίδα όταν προσθέτετε ένα πεδίο, αλλάζετε τον τύπο του ή το αφαιρείτε. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση της μερίδας. Χρησιμοποιήστε το [Portion.getPortionFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#getPortionFormat) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως τα παραδείγματα δείχνουν για χρώμα ή πλάγια.

Αποφύγετε την αναδημιουργία ολόκληρου πλαισίου κειμένου μόνο για την ενημέρωση ενός πεδίου: κάτι τέτοιο μπορεί να χαθούν τα αρχικά όρια της μερίδας και η μορφοποίηση τους. Επίσης διακρίνετε τη ρητά ορισμένη μορφοποίηση από αυτή που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε τη σελίδα [Text Formatting](/slides/el/nodejs-java/text-formatting/) για ευρύτερες επιλογές μορφοποίησης.

## **Πεδία και Αντικαταστάτες Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο είναι μέρος μιας μερίδας κειμένου. Ένας placeholder είναι ένα σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη ενός πεδίου σε ένα απλό πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε placeholder.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο του placeholder και την ορατότητά του σε διαφάνειες, διατάξεις και master, συμπεριλαμβανομένης της διάδοσης σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί έτσι να είναι χρήσιμο ακόμη και αν δεν χρησιμοποιείτε το placeholder του αριθμού διαφάνειας. Αντίστροφα, η αλλαγή της ορατότητας του placeholder δεν αφαιρεί ένα πεδίο από ένα μη συναφή πλαίσιο κειμένου.

Οι προεπιλεγμένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα placeholders ή δεν παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει placeholder κεφαλίδας· οι κεφαλίδες ανήκουν στις σελίδες σημειώσεων και στα φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε τυχαίο σχήμα θα λάβει αυτόματα το κείμενο που έχει ρυθμιστεί μέσω του διαχειριστή placeholder. Για αυτή τη ροή εργασίας, δείτε την ενότητα [Presentation Headers and Footers](/slides/el/nodejs-java/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το προκύπτον κείμενο μετά την αποθήκευση και το άνοιγμα. Η διατήρηση ενός ταυτοποιητή δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά πεδίου και περιορισμοί |
|---|---|
| PPTX | Αποθηκεύει εσωτερικούς ταυτοποιητές πεδίου μαζί με το κείμενο του πεδίου. Σε ελέγχους κυκλικής αναίρεσης, οι προκαθορισμένοι τύποι και ο προσαρμοσμένος ταυτοποιητής που χρησιμοποιήθηκε παραπάνω επιβίωσαν μετά την αποθήκευση και το άνοιγμα. Ο άγνωστος προσαρμοσμένος τύπος διατήρησε το εναλλακτικό του κείμενο· δεν απέκτησε λογική αυτόματου υπολογισμού. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει μη υποστηριζόμενους ταυτοποιητές διαφορετικά. |
| PPT | Χρησιμοποιεί παλαιές αναπαραστάσεις πεδίων και έχει πιο περιορισμένη συμβατότητα. Σε ελέγχους κυκλικής αναίρεσης, τα πεδία αριθμού διαφάνειας και οι προκαθορισμένοι τύποι ημερομηνίας/ώρας επιβίωσαν μετά την αποθήκευση και το άνοιγμα. Ένα προσαρμοσμένο πεδίο σε απλό πλαίσιο κειμένου στην διαφάνεια άνοιξε ξανά με τον ταυτοποιητή του αλλά με `*` ως κείμενο· ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο παρήγαγε επίσης `*`. Μην βασίζεστε στο ότι προσαρμοσμένα πεδία ή μη υποστηριζόμενα συμφραζόμενα πεδίων θα διατηρήσουν το ορατό κείμενό τους. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε μη υποστηριζόμενα πεδία σε απλό κείμενο και αντιστοιχίστε ρητά την τιμή που θέλετε πριν την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά σκόπιμα τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή προορισμού όταν η δική της επανυπολογιστική λογική πεδίου είναι μέρος της ροής εργασίας σας.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**  
Ελέγξτε το [Portion.getField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#getField). Μια τιμή διαφορετική του `null` προσδιορίζει πεδίο· το εμφανιζόμενο κείμενο από μόνο του δεν μπορεί να το αποδείξει.

**Αφαιρεί η αφαίρεση ενός πεδίου το κείμενο ή τη μορφοποίηση του;**  
Όχι. Η μέθοδος [removeField](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/portion/#removeField) μετατρέπει την υπάρχουσα μερίδα σε απλό κείμενο. Αν χρειάζεστε μια συγκεκριμένη «παγωμένη» ημερομηνία ή εναλλακτική τιμή, αντιστοιχίστε τη μετά την αφαίρεση του πεδίου.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**  
Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένας άγνωστος ταυτοποιητής δεν παρέχει αξιολογητή ή μοτίβο μορφοποίησης ημερομηνίας. Χρησιμοποιήστε έναν υποστηριζόμενο προκαθορισμένο τύπο ή μορφοποιήστε την τιμή εσείς ως απλό κείμενο.

**Γιατί να ελέγξω ξανά την παρουσίαση μετά την αποθήκευση;**  
Οι ταυτοποιητές πεδίου, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά στοιχεία που πρέπει να επαληθευτούν. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν ο ταυτοποιητής πεδίου παραμένει.