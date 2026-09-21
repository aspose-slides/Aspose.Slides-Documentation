---
title: Διαχείριση πεδίων κειμένου σε παρουσιάσεις PowerPoint σε Java
linktitle: Πεδία Κειμένου
type: docs
weight: 52
url: /el/java/text-fields/
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
- Java
- Aspose.Slides
description: "Δημιουργήστε, ελέγξτε, τροποποιήστε και αφαιρέστε πεδία κειμένου σε παρουσιάσεις PowerPoint με το Aspose.Slides για Java. Διατηρήστε τη μορφοποίηση και επαληθεύστε τα αποθηκευμένα αρχεία PPTX και PPT."
---
## **Επισκόπηση**

Μια παράγραφος κειμένου αποτελείται από τμήματα. Ένα συνηθισμένο [IPortion](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/) περιέχει κυριολεκτικό κείμενο· ένα τμήμα πεδίου επίσης διαθέτει ένα [IField](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifield/) του οποίου ο τύπος προσδιορίζει μια αυτόματα ενημερωμένη τιμή, όπως αριθμός διαφάνειας ή ημερομηνία. Δύο τμήματα μπορούν να εμφανίζουν τους ίδιους χαρακτήρες, ενώ μόνο ένα περιέχει πεδίο.

Χρησιμοποιήστε το [IPortion.getField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#getField--) για να τα διακρίνετε: είναι `null` για συνηθισμένο κείμενο. Το [IPortion.addField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-) μετατρέπει ένα υπάρχον τμήμα σε πεδίο. Διατηρήστε μια ετικέτα και τη δυναμική της τιμή σε ξεχωριστά τμήματα ώστε η μετατροπή της τιμής να μην αντικαθιστά επίσης την ετικέτα.

Αυτός ο οδηγός καλύπτει τα πεδία μέσα στο κείμενο, τη μορφοποίησή τους και την αποθήκευση τους σε PPTX και PPT. Για πλαίσια κειμένου και παραγράφους, δείτε το [Manage Text](/slides/el/java/manage-text/).

## **Δημιουργία Πεδίου Αριθμού Διαφάνειας**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα πλαίσιο κειμένου που περιέχει μια κυριολεκτική ετικέτα `Slide ` ακολουθούμενη από έναν αυτόματα ενημερωμένο αριθμό. Ορίζει το μέγεθος, το βάρος και το χρώμα του αριθμού πριν προσθέσει το πεδίο, στη συνέχεια ανοίγει ξανά την αποθηκευμένη παρουσίαση και ελέγχει τον τύπο του πεδίου, το κείμενο και τη μορφοποίηση. Δεν απαιτείται αρχείο εισόδου.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 240, 50);
    shape.addTextFrame("Slide ");
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);

    Portion numberPortion = new Portion();
    Color numberColor = new Color(0, 0, 139);
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
        formattingPreserved &= format.getFillFormat().getSolidFillColor().getColor().getRGB() == numberColor.getRGB();

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

Η νέα παρουσίαση ξεκινά με αριθμό διαφάνειας 1, έτσι το κείμενο είναι `Slide 1`, και και οι δύο έλεγχοι εμφανίζουν `true`. Ο αριθμός παραμένει πεδίο μετά το άνοιγμα ξανά· δεν είναι κυριολεκτικό `1`. Οι μετατροπές τύπων και οι δείκτες στην επαλήθευση αναφέρονται στο σχήμα και στα τμήματα που δημιουργήθηκαν από αυτό το παράδειγμα.

## **Επιλογή Τύπου Πεδίου**

[FieldType](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/) υλοποιεί το [IFieldType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifieldtype/) και παρέχει τις παρακάτω μεθόδους για λήψη προκαθορισμένων τιμών. Περνάτε την κατάλληλη τιμή στο [addField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#addField-com.aspose.slides.IFieldType-).

| Μέθοδος | Σκοπός |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getSlideNumber--) | Ο τρέχων αριθμός διαφάνειας. |
| [getDateTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getDateTime--) | Ημερομηνία/ώρα με το προεπιλεγμένο φορμάτ της εφαρμογής απόδοσης. |
| [getDateTime1](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getDateTime1--)–[getDateTime9](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getDateTime9--) | Προκαθορισμένη ημερομηνία ή συνδυασμένες μορφές ημερομηνίας/ώρας. |
| [getDateTime10](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getDateTime10--)–[getDateTime13](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getDateTime13--) | Προκαθορισμένες μορφές ώρας, με επιλογές για δευτερόλεπτα και 12‑ώρο ρολόι. |
| [getHeader](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getHeader--) | Ένα πεδίο κεφαλίδας· δείτε παρακάτω τους περιορισμούς του placeholder και της μορφοποίησης. |
| [getFooter](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getFooter--) | Ένα πεδίο υποσέλιδου. |

Για παράδειγμα, [getDateTime3](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#getDateTime3--) αντιπροσωπεύει μια ημέρα, το πλήρες όνομα του μήνα και το έτος στα Αγγλικά. Αυτά είναι προκαθορισμένες μορφές πεδίου, όχι τυχαίες αλφαριθμητικές συμβολοσειρές μορφοποίησης Java. Η γλώσσα που ορίζεται με [setLanguageId](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) και η εφαρμογή που επεξεργάζεται την παρουσίαση μπορούν να επηρεάσουν το εμφανιζόμενο αποτέλεσμα.

## **Δημιουργία Πεδίου από Εσωτερική Συμβολοσειρά**

Η υπερφόρτωση με συμβολοσειρά του [addField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#addField-java.lang.String-) δέχεται έναν εσωτερικό ταυτοποιητή πεδίου. Χρησιμοποιήστε το όταν διατηρείτε έναν ταυτοποιητή που παρέχεται από άλλη εφαρμογή και δεν έχει προκαθορισμένη τιμή. Μπορείτε επίσης να δημιουργήσετε ένα [FieldType](https://reference.aspose.com/slides/el/java/com.aspose.slides/fieldtype/#FieldType-java.lang.String-) από τον ταυτοποιητή. Το [IFieldType.getInternalString](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifieldtype/#getInternalString--) αποκαλύπτει αυτόν τον ταυτοποιητή για έλεγχο.

Αυτό το παράδειγμα αποθηκεύει ένα πεδίο ειδικό για την εφαρμογή `custom-report-id` με εναλλακτικό κείμενο `Report-042`. Ο ταυτοποιητής δεν καταγράφει κανένα υπολογισμό: το Aspose.Slides δεν δημιουργεί αναγνωριστικά αναφοράς για άγνωστους τύπους. Η εφαρμογή που καταλαβαίνει αυτόν τον ταυτοποιητή πρέπει να παρέχει τη σημασία του και να ενημερώνει την τιμή του.

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

Μετά από αυτόν τον γύρο PPTX, ο τύπος είναι `custom-report-id` και το κείμενο είναι `Report-042`. Η μετάδοση μιας συμβολοσειράς όπως `yyyy-MM-dd` θα ονομάσει έναν τύπο πεδίου· δεν θα διαμορφώσει προσαρμοσμένη μορφή ημερομηνίας. Για σταθερή ημερομηνία σε αυθαίρετη μορφή, χρησιμοποιήστε συνηθισμένο κείμενο.

## **Επιθεώρηση, Τροποποίηση και Απομάκρυνση Πεδίων Ημερομηνίας/Ώρας**

Αλλάξτε ένα υπάρχον πεδίο μέσω του [IField.setType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifield/#setType-com.aspose.slides.IFieldType-). Ελέγξτε ότι το πεδίο υπάρχει πριν αποκτήσετε πρόσβαση στον τύπο του. Για να σταματήσετε τις αυτόματες ενημερώσεις, καλέστε το [IPortion.removeField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#removeField--). Αυτό διατηρεί το τμήμα και το τρέχον κείμενό του ενώ αφαιρεί τη συσχέτιση με το πεδίο. Εάν χρειάζεστε μια συγκεκριμένη σταθερή τιμή, εκχωρήστε αυτό το κείμενο μετά την αφαίρεση του πεδίου.

Για τη ρύθμιση API που σχετίζεται με την επεξεργασία πεδίων ημερομηνίας/ώρας, δείτε το [Presentation.setCurrentDateTime](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#setCurrentDateTime-java.util.Date-). Το παρακάτω παράδειγμα χρησιμοποιεί μια ρητή ημερομηνία έγκρισης όταν μετατρέπει ένα πεδίο σε συνηθισμένο κείμενο.

Κατεβάστε το [sample.pptx](sample.pptx) και τοποθετήστε το στον εργασιακό φάκελο. Περιέχει δύο ονομασμένα σχήματα κειμένου, `UpdatedAt` και `ApprovedDate`, το καθένα με πεδίο ημερομηνίας/ώρας, καθώς και ετικέτες συνηθισμένου κειμένου. Το παρακάτω παράδειγμα διασχίζει τα σχήματα κειμένου ανώτερου επιπέδου σε κανονικές διαφάνειες. Αλλάζει τα πεδία ημερομηνίας/ώρας σε μορφή «μακρά ημερομηνία» και τα κάνει πλάγια, διατηρώντας τις άλλες μορφοποιήσεις τους. Μόνο τα πεδία στο `ApprovedDate` γίνονται σταθερό κείμενο.

Το δείγμα αναγνωρίζει τους ενσωματωμένους εσωτερικούς ταυτοποιητές `datetime` και `datetime1` έως `datetime13`. Οι ομάδες, πίνακες, σημειώσεις, διατάξεις και master απαιτούν διαπλοκή των δικών τους περιεκτών κειμένου και βρίσκονται εκτός του πεδίου αυτού του παραδείγματος.

```java
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    LocalDate approvalDate = LocalDate.of(2030, 4, 5);
    DateTimeFormatter dateFormat = DateTimeFormatter.ofPattern("dd MMMM yyyy", Locale.US);

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
                        String fixedDate = approvalDate.format(dateFormat);
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

Μετά το άνοιγμα ξανά, το `UpdatedAt` έχει τύπο `datetime3` και παραμένει δυναμικό. Το `ApprovedDate` δεν έχει πεδίο και περιέχει `05 April 2030`. Και τα δύο τμήματα ημερομηνίας είναι πλάγια, και το αρχικό μέγεθος γραμματοσειράς, η έντονη ρύθμιση και το χρώμα παραμένουν αμετάβλητα. Οι ετικέτες συνηθισμένου κειμένου δεν έχουν αλλάξει. Η επαλήθευση διαβάζει το πρώτο τμήμα των δύο γνωστών σχημάτων στο παρεχόμενο δείγμα.

## **Διατήρηση Μορφοποίησης Κειμένου**

Δουλέψτε με το υπάρχον τμήμα όταν προσθέτετε ένα πεδίο, αλλάζετε τον τύπο του ή το αφαιρείτε. Αυτές οι λειτουργίες διατηρούν τη μορφοποίηση του τμήματος. Χρησιμοποιήστε το [IPortion.getPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#getPortionFormat--) για να αλλάξετε μόνο τις απαιτούμενες ιδιότητες, όπως κάνουν τα παραδείγματα για το χρώμα ή την πλάγια γραφή.

Αποφύγετε την ανασυγκρότηση ενός ολόκληρου πλαισίου κειμένου μόνο για την ενημέρωση ενός πεδίου: κάτι τέτοιο μπορεί να χάσει τα αρχικά όρια των τμημάτων και τη δική τους μορφοποίηση. Επίσης, διακρίνετε τη ρητά ορισμένη μορφοποίηση από τη μορφοποίηση που κληρονομείται από την παράγραφο, τη διάταξη ή το θέμα. Δείτε το [Text Formatting](/slides/el/java/text-formatting/) για πιο εκτεταμένες επιλογές μορφοποίησης.

## **Πεδία και Placeholder Κεφαλίδας/Υποσέλιδου**

Ένα πεδίο αποτελεί μέρος ενός τμήματος κειμένου. Ένα placeholder είναι ένα σχήμα με ρόλο παρουσίασης, όπως υποσέλιδο ή αριθμός διαφάνειας. Η προσθήκη πεδίου σε συμβατικό πλαίσιο κειμένου δεν μετατρέπει αυτό το σχήμα σε placeholder.

Οι διαχειριστές κεφαλίδας/υποσέλιδου ελέγχουν το κείμενο και την ορατότητα των placeholder σε διαφάνειες, διατάξεις και master, συμπεριλαμβανομένης της διάδοσης σε εξαρτημένες διαφάνειες. Ένα πεδίο αριθμού σε προσαρμοσμένο πλαίσιο κειμένου μπορεί επομένως να είναι χρήσιμο ακόμα και όταν δεν χρησιμοποιείτε το placeholder αριθμού διαφάνειας. Αντίθετα, η αλλαγή της ορατότητας του placeholder δεν αφαιρεί ένα πεδίο από ένα ασυσχέτιστο πλαίσιο κειμένου.

Οι προκαθορισμένοι τύποι κεφαλίδας και υποσέλιδου δεν δημιουργούν τα αντίστοιχα placeholders ούτε παρέχουν το περιεχόμενό τους. Συγκεκριμένα, μια κανονική διαφάνεια PowerPoint δεν έχει placeholder κεφαλίδας· οι κεφαλίδες ανήκουν στις σελίδες σημειώσεων και στα φυλλάδια. Μην υποθέτετε ότι ένα πεδίο κεφαλίδας ή υποσέλιδου σε τυχαίο σχήμα θα λαμβάνει αυτόματα το κείμενο που έχει ρυθμιστεί μέσω του διαχειριστή placeholder. Για αυτή τη ροή εργασίας, δείτε το [Presentation Headers and Footers](/slides/el/java/presentation-header-and-footer/).

## **Περιορισμοί PPTX και PPT**

Ελέγξτε τόσο τον τύπο του πεδίου όσο και το κείμενο που προκύπτει μετά από αποθήκευση και άνοιγμα ξανά. Η διατήρηση ενός ταυτοποιητή δεν αποδεικνύει ότι μια εφαρμογή μπορεί να υπολογίσει ή να εμφανίσει την τιμή του.

| Μορφή | Συμπεριφορά πεδίου και περιορισμοί |
|---|---|
| PPTX | Αποθηκεύει εσωτερικούς ταυτοποιητές πεδίου μαζί με το κείμενο του πεδίου. Σε ελέγχους γύρου, οι προκαθορισμένοι τύποι και ο προσαρμοσμένος ταυτοποιητής που χρησιμοποιήθηκε παραπάνω διατηρήθηκαν μετά την αποθήκευση και το άνοιγμα ξανά. Ο άγνωστος προσαρμοσμένος τύπος κράτησε το εναλλακτικό του κείμενο· δεν απέκτησε λογική αυτόματου υπολογισμού. Μια άλλη εφαρμογή μπορεί να αντιμετωπίσει διαφορετικά μη υποστηριζόμενους ταυτοποιητές. |
| PPT | Χρησιμοποιεί παλιές αναπαραστάσεις πεδίου και έχει πιο περιορισμένη συμβατότητα. Σε ελέγχους γύρου, τα πεδία αριθμού διαφάνειας και τα προκαθορισμένα πεδία ημερομηνίας/ώρας διατηρήθηκαν μετά την αποθήκευση και το άνοιγμα ξανά. Ένα προσαρμοσμένο πεδίο σε συνηθισμένο πλαίσιο κειμένου διαφάνειας άνοιξε ξανά με τον ταυτοποιητή του αλλά με `*` ως κείμενο· ένα πεδίο κεφαλίδας στο ίδιο πλαίσιο παρήγαγε επίσης `*`. Μην βασίζεστε σε προσαρμοσμένα πεδία ή σε μη υποστηριζόμενα πλαίσια πεδίου που διατηρούν το ορατό κείμενό τους. |

Για φορητό, σταθερό αποτέλεσμα, μετατρέψτε τα μη υποστηριζόμενα πεδία σε συνηθισμένο κείμενο και ορίστε ρητά την τιμή που θέλετε πριν από την αποθήκευση. Αυτό διατηρεί το επιλεγμένο κείμενο αλλά σταματά σκόπιμα τις αυτόματες ενημερώσεις. Δοκιμάστε επίσης την εφαρμογή-στόχο όταν η δική της επανυπολογισμός πεδίου αποτελεί μέρος της ροής εργασίας σας.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω αν ένας εμφανιζόμενος αριθμός ή ημερομηνία είναι πεδίο;**

Εξετάστε το [IPortion.getField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#getField--). Μια μη-μηδενική τιμή καθορίζει ότι είναι πεδίο· το μόνο εμφανιζόμενο κείμενο δεν μπορεί να το δείξει.

**Αφαιρεί η αφαίρεση ενός πεδίου το κείμενο ή τη μορφοποίηση του;**

Όχι. Το [removeField](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportion/#removeField--) μετατρέπει το υπάρχον τμήμα σε συνηθισμένο κείμενο. Εκχωρήστε ρητή τιμή μετά εάν χρειάζεστε μια συγκεκριμένη παγωμένη ημερομηνία ή εναλλακτική τιμή.

**Μπορεί μια εσωτερική συμβολοσειρά να ορίσει νέα μορφή ημερομηνίας ή τύπο;**

Όχι. Αναγνωρίζει έναν τύπο πεδίου. Ένας άγνωστος ταυτοποιητής δεν παρέχει αξιολογητή ή μοτίβο μορφοποίησης ημερομηνίας Java. Χρησιμοποιήστε έναν υποστηριζόμενο προκαθορισμένο τύπο ή μορφοποιήστε την τιμή εσείς ως συνηθισμένο κείμενο.

**Γιατί να ελέγξετε ξανά μια παρουσίαση μετά την αποθήκευση;**

Οι ταυτοποιητές πεδίου, το υπολογισμένο κείμενο και η μορφοποίηση είναι ξεχωριστά πράγματα που πρέπει να επαληθευτούν. Η μετατροπή μορφής μπορεί να αλλάξει το ορατό αποτέλεσμα ακόμη και όταν ο ταυτοποιητής πεδίου παραμένει.