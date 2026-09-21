---
title: Διαχείριση Πεδίων Κειμένου σε Παρουσιάσεις PowerPoint στο Android
linktitle: Πεδία Κειμένου
type: docs
weight: 52
url: /el/androidjava/text-fields/
keywords:
- πεδίο κειμένου
- αυτόματο κείμενο
- αριθμός διαφάνειας
- ημερομηνία και ώρα
- κεφαλίδα
- υποσέλιδο
- τμήμα κειμένου
- PowerPoint
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Δημιουργήστε, ελέγξτε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides για Android μέσω Java. Διατηρήστε τη μορφοποίηση και επαληθεύστε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Ένα κείμενο παραγράφου αποτελείται από τμήματα. Ένα συνηθισμένο [IPortion](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου διαθέτει επίσης ένα [IField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifield/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωνόμενη τιμή, όπως ο αριθμός διαφάνειας ή η ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε το [IPortion.getField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getField--) για να τα ξεχωρίσετε: επιστρέφει `null` για συνηθισμένο κείμενο. Το [IPortion.addField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Διατηρήστε μια ετικέτα και την δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης την ετικέτα.

Αυτός ο οδηγός καλύπτει τα πεδία μέσα στο κείμενο, τη μορφοποίησή τους και την αποθήκευση σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε το [Manage Text](/slides/el/androidjava/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει μια κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωνόμενο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, στη συνέχεια ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    int numberColor = Color.rgb(0, 0, 139);
    numberPortion.getPortionFormat().setFontHeight(24);
    numberPortion.getPortionFormat().setFontBold(NullableBool.True);
    numberPortion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    numberPortion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(numberColor);
    paragraph.getPortions().add(numberPortion);
    numberPortion.addField(FieldType.getSlideNumber());

    presentation.save("slide_number.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("slide_number.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedNumber = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(1);
        IField savedField = savedNumber.getField();
        boolean hasNumberField = savedField != null && FieldType.getSlideNumber().getInternalString().equals(savedField.getType().getInternalString());
        IPortionFormat format = savedNumber.getPortionFormat();
        boolean formattingPreserved = format.getFontHeight() == 24 && format.getFontBold() == NullableBool.True;
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor() == numberColor;

        System.out.println("Text: " + savedShape.getTextFrame().getText());
        System.out.println("Slide number field: " + hasNumberField);
        System.out.println("Formatting preserved: " + formattingPreserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Η νέα παρουσίαση ξεκινάει με αριθμό διαφάνειας 1, έτσι το κείμενο είναι `Slide 1`, και και οι δύο έλεγχοι εμφανίζουν `true`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα· δεν είναι η κυριολεκτική τιμή `1`. Οι μετατροπές τύπου και τα ευρετήρια στην επαλήθευση αναφέρονται στο σχήμα και τα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

Το [FieldType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/) υλοποιεί το [IFieldType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifieldtype/) και παρέχει τις ακόλουθες μεθόδους για λήψη προκαθορισμένων τιμών. Περνάτε τη σχετική τιμή στο [addField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Μέθοδος | Σκοπός |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getSlideNumber--) | Ο τρέχων αριθμός διαφάνειας. |
| [getDateTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getDateTime--) | Ημερομηνία/ώρα στη προεπιλεγμένη μορφή της εφαρμογής απόδοσης. |
| [getDateTime1](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getDateTime9--) | Προκαθορισμένη μορφή ημερομηνίας ή συνδυασμένη μορφή ημερομηνίας/ώρας. |
| [getDateTime10](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getDateTime13--) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ωρο ρολόι. |
| [getHeader](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getHeader--) | Πεδίο κεφαλίδας· δείτε τα σύμβολα και τους περιορισμούς μορφής παρακάτω. |
| [getFooter](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getFooter--) | Πεδίο υποσέλιδου. |

Για παράδειγμα, το [getDateTime3](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#getDateTime3--) αντιπροσωπεύει μια ημέρα, το πλήρες όνομα του μήνα και το έτος στα αγγλικά. Πρόκειται για προκαθορισμένες μορφές πεδίου, όχι αυθαίρετες συμβολοσειρές μορφοποίησης ημερομηνίας Java. Η γλώσσα που ορίζεται με το [setLanguageId](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση της μεθόδου [addField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#addField-java.lang.String-) που δέχεται συμβολοσειρά αποδέχεται έναν εσωτερικό αναγνωριστικό πεδίου. Χρησιμοποιήστε το όταν θέλετε να διατηρήσετε έναν αναγνωριστικό που παρέχεται από άλλη εφαρμογή και δεν έχει προκαθορισμένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) από το αναγνωριστικό. Η μέθοδος [IFieldType.getInternalString](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifieldtype/#getInternalString--) αποκαλύπτει αυτό το αναγνωριστικό για επιθεώρηση.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο `custom-report-id` ειδικό για την εφαρμογή με το κείμενο εναλλακτικού κειμένου `Report-042`. Το αναγνωριστικό δεν καταγράφει κάποιον υπολογισμό: το Aspose.Slides δεν δημιουργεί ID αναφορών για άγνωστο τύπο. Η εφαρμογή που καταλαβαίνει αυτό το αναγνωριστικό πρέπει να παρέχει τη σημασία του και να ενημερώνει την τιμή του.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 50);
    shape.addTextFrame("Report-042");
    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.addField("custom-report-id");

    presentation.save("custom_field.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom_field.pptx");
    try {
        IAutoShape savedShape = (IAutoShape) reopened.getSlides().get_Item(0).getShapes().get_Item(0);
        IPortion savedPortion = savedShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
        IField savedField = savedPortion.getField();
        String typeName = savedField == null ? "ordinary text" : savedField.getType().getInternalString();
        System.out.println("Type: " + typeName);
        System.out.println("Text: " + savedPortion.getText());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Μετά από αυτή τη διαδρομή PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η μεταβίβαση μιας συμβολοσειράς όπως `yyyy-MM-dd` θα ονομαζόταν τύπο πεδίου· δεν θα ρυθμίζει προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε συνηθισμένο κείμενο.

## **Επιθεώρηση, Τροποποίηση και Αφαίρεση Πεδία Ημερομηνίας/Ώρας**

Αλλάξτε ένα υπάρχον πεδίο μέσω του [IField.setType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Ελέγξτε ότι το πεδίο υπάρχει πριν προσπελάσετε τον τύπο του. Για να σταματήσετε τις αυτόματες ενημερώσεις, καλέστε το [IPortion.removeField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#removeField--). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη συσχέτιση με το πεδίο. Εάν χρειάζεστε μια συγκεκριμένη στατική τιμή, ορίστε αυτό το κείμενο μετά την αφαίρεση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης κατά τη μετατροπή ενός πεδίου σε συνηθισμένο κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον τρέχον φάκελο εργασίας. Περιέχει δύο ονομαστικά σχήματα κειμένου, `UpdatedAt` και `ApprovedDate`, το καθένα με πεδίο ημερομηνίας/ώρας, καθώς και ετικέτες συνηθισμένου κειμένου. Το παρακάτω παράδειγμα διατρέχει τα κορυφαία σχήματα κειμένου σε κανονικές διαφάνειες. Αλλάζει τα πεδία ημερομηνίας/ώρας σε μορφή ημερομηνίας πλήρους μορφής και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις. Μόνο τα πεδία στο `ApprovedDate` γίνονται στατικό κείμενο.

Το δείγμα αναγνωρίζει τα ενσωματωμένα εσωτερικά αναγνωριστικά `datetime` και `datetime1` έως `datetime13`. Οι ομάδες, πίνακες, σημειώσεις, διατάξεις και κύριοι προτύποι απαιτούν περεμπάσεις στα δικά τους δοχεία κειμένου και δεν περιλαμβάνονται σε αυτό το παράδειγμα.

```java
import java.util.Calendar;
import java.text.SimpleDateFormat;
import java.util.Locale;
import java.util.Date;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    Calendar approvalDate = Calendar.getInstance();
    approvalDate.clear();
    approvalDate.set(2030, Calendar.APRIL, 5);
    SimpleDateFormat dateFormat = new SimpleDateFormat("dd MMMM yyyy", Locale.US);

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }

            for (IParagraph paragraph : textShape.getTextFrame().getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    IField field = portion.getField();
                    if (field == null) {
                        continue;
                    }

                    String typeName = field.getType().getInternalString();
                    boolean isDateTime = typeName != null && typeName.matches("datetime([1-9]|1[0-3])?");
                    if (!isDateTime) {
                        continue;
                    }

                    field.setType(FieldType.getDateTime3());
                    portion.getPortionFormat().setLanguageId("en-US");
                    portion.getPortionFormat().setFontItalic(NullableBool.True);

                    if ("ApprovedDate".equals(textShape.getName())) {
                        portion.removeField();
                        Date dateValue = approvalDate.getTime();
                        String fixedDate = dateFormat.format(dateValue);
                        portion.setText(fixedDate);
                    }
                }
            }
        }
    }

    presentation.save("updated_dates.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("updated_dates.pptx");
    try {
        for (IShape shape : reopened.getSlides().get_Item(0).getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }
            IAutoShape textShape = (IAutoShape) shape;
            if (textShape.getTextFrame() == null) {
                continue;
            }
            if (!"UpdatedAt".equals(textShape.getName()) && !"ApprovedDate".equals(textShape.getName())) {
                continue;
            }

            IPortion portion = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
            IField field = portion.getField();
            String typeName = field == null ? "ordinary text" : field.getType().getInternalString();
            System.out.println(textShape.getName() + ": " + typeName + "; " + portion.getText());
            System.out.println("Italic: " + portion.getPortionFormat().getFontItalic());
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Μετά το ξανά άνοιγμα, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα παραμένουν αμετάβλητα. Οι ετικέτες συνηθισμένου κειμένου δεν έχουν αλλάξει. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Εργαστείτε με το υπάρχον τμήμα όταν προσθέτετε ένα πεδίο, αλλάζετε τον τύπο του ή το αφαιρείτε. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση του τμήματος. Χρησιμοποιήστε το [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getPortionFormat--) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως τα παραδείγματα κάνουν για χρώμα ή πλάγια γραφή.

Αποφύγετε την ανακατασκευή ολόκληρου πλαισίου κειμένου μόνο για την ενημέρωση ενός πεδίου: κάτι τέτοιο μπορεί να χάσει τα αρχικά όρια τμημάτων και τη δική τους μορφοποίηση. Επίσης διακρίνετε τη ρητά ορισμένη μορφοποίηση από αυτή που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/androidjava/text-formatting/) για ευρύτερες επιλογές μορφοποίησης.

## **Πεδία και Σύμβολα Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο αποτελεί μέρος ενός τμήματος κειμένου. Ένα σύμβολο (placeholder) είναι ένα σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε ένα συνηθισμένο πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε σύμβολο.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο των συμβόλων και την ορατότητά τους στις διαφάνειες, τις διατάξεις και τα κύρια πρότυπα, συμπεριλαμβανομένης της διάδοσης σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμη και όταν δεν χρησιμοποιείτε το σύμβολο αριθμού διαφάνειας. Αντίστροφα, η αλλαγή της ορατότητας του συμβόλου δεν αφαιρεί ένα πεδίο από ένα άσχετο πλαίσιο κειμένου.

Οι προκαθορισμένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα σύμβολα ή παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει σύμβολο κεφαλίδας· οι κεφαλίδες ανήκουν στις σελίδες σημειώσεων και στα φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε τυχαίο σχήμα θα αποκτήσει αυτόματα το κείμενο που διαμορφώνεται μέσω του διαχειριστή συμβόλων. Για αυτή τη ροή εργασίας, δείτε το [Presentation Headers and Footers](/slides/el/androidjava/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το προκύπτον κείμενο μετά την αποθήκευση και το άνοιγμα ξανά. Η διατήρηση ενός αναγνωριστικού δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά και περιορισμοί πεδίου |
|---|---|
| PPTX | Αποθηκεύει εσωτερικά αναγνωριστικά πεδίου μαζί με το κείμενο του πεδίου. Σε ελέγχους round‑trip, οι προκαθορισμένοι τύποι και το προσαρμοσμένο αναγνωριστικό που χρησιμοποιήθηκε παραπάνω επιβίωσαν μετά την αποθήκευση και το ξανά άνοιγμα. Ο άγνωστος προσαρμοσμένος τύπος διατήρησε το εναλλακτικό κείμενό του· δεν απέκτησε αυτόματη λογική υπολογισμού. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει τα μη υποστηριζόμενα αναγνωριστικά διαφορετικά. |
| PPT | Χρησιμοποιεί παλαιότερες αναπαραστάσεις πεδίου και έχει πιο περιορισμένη συμβατότητα. Σε ελέγχους round‑trip, οι αριθμοί διαφάνειας και τα προκαθορισμένα πεδία ημερομηνίας/ώρας επιβίωσαν μετά την αποθήκευση και το ξανά άνοιγμα. Ένα προσαρμοσμένο πεδίο σε συνηθισμένο πλαίσιο κειμένου διαφάνειας άνοιξε ξανά με το αναγνωριστικό του αλλά με κείμενο `*`; ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο παρήγαγε επίσης `*`. Μην βασίζεστε σε προσαρμοσμένα πεδία ή μη υποστηριζόμενα συμφραζόμενα πεδίου που διατηρούν το ορατό κείμενό τους. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε τα μη υποστηριζόμενα πεδία σε συνηθισμένο κείμενο και ορίστε ρητά την τιμή που επιθυμείτε πριν την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά εκούσια τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή-στόχο όταν η δική της επανυπολογισμός πεδίου αποτελεί μέρος της ροής εργασίας σας.

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να καταλάβω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**

Εξετάστε το [IPortion.getField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#getField--). Μια μη‑μηδενική τιμή προσδιορίζει πεδίο· το εμφανιζόμενο κείμενο μόνο δεν μπορεί να το αποδείξει.

**Αφαιρεί η αφαίρεση ενός πεδίου το κείμενο ή τη μορφοποίησή του;**

Όχι. Το [removeField](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iportion/#removeField--) μετατρέπει το υπάρχον τμήμα σε συνηθισμένο κείμενο. Ορίστε μια ρητή τιμή μετά εάν χρειάζεστε συγκεκριμένη παγωμένη ημερομηνία ή εναλλακτικό κείμενο.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**

Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένα άγνωστο αναγνωριστικό δεν παρέχει αξιολογητή ή μοτίβο μορφοποίησης ημερομηνίας Java. Χρησιμοποιήστε έναν υποστηριζόμενο προκαθορισμένο τύπο ή μορφοποιήστε την τιμή μόνοι σας ως συνηθισμένο κείμενο.

**Γιατί να ελέγξετε ξανά μια παρουσίαση μετά την αποθήκευση;**

Τα αναγνωριστικά πεδίου, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά στοιχεία για επαλήθευση. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμα και αν το αναγνωριστικό πεδίου παραμένει.