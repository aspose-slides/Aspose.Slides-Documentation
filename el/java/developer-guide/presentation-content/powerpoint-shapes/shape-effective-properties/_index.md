---
title: Λήψη Αποτελεσματικών Ιδιοτήτων Σχήματος από Παρουσιάσεις σε Java
linktitle: Αποτελεσματικές Ιδιότητες
type: docs
weight: 50
url: /el/java/shape-effective-properties/
keywords:
- ιδιότητες σχήματος
- ιδιότητες κάμερας
- σύστημα φωτισμού
- σχήμα λοξότμησης
- πλαίσιο κειμένου
- στυλ κειμένου
- ύψος γραμματοσειράς
- μορφή γεμίσματος
- PowerPoint
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να χρησιμοποιείτε το Aspose.Slides για Java ώστε να διακρίνετε την τοπική, κληρονομημένη και αποτελεσματική μορφοποίηση σχήματος σε παρουσιάσεις PowerPoint."
---
## **Κατανόηση Τοπικών, Κληρονομημένων και Αποτελεσματικών Ιδιοτήτων**

Η μορφοποίηση του PowerPoint μπορεί να προέρχεται από πολλαπλές πηγές. Η τιμή που αποθηκεύεται απευθείας σε ένα αντικείμενο είναι η **τοπική τιμή** του. Αν η τιμή αυτή δεν είναι ορισμένη, το PowerPoint εξετάζει τις γονικές πηγές μορφοποίησης, όπως η προεπιλογή παραγράφου, ένα στυλ κειμένου, μια διάταξη ή η κύρια διαφάνεια, ένα θέμα ή οι προεπιλογές σε επίπεδο παρουσίασης. Αυτές οι τιμές είναι **κληρονομημένες τιμές**. Η τιμή που παραμένει μετά την επίλυση ολόκληρης της ιεραρχίας είναι η **αποτελεσματική τιμή** — η τιμή που χρησιμοποιείται για την απόδοση του αντικειμένου.

Για παράδειγμα, ένα τμήμα κειμένου μπορεί να μην ορίζει το δικό του ύψος γραμματοσειράς. Η τοπική του τιμή [getFontHeight](https://reference.aspose.com/slides/el/java/com.aspose.slides/ibaseportionformat/#getFontHeight--) είναι wtedy `Float.NaN`, που σημαίνει «δεν ορίστηκε εδώ». Το τμήμα μπορεί να κληρονομήσει ένα ύψος από την παράγραφό του, το προεπιλεγμένο στυλ κειμένου της παρουσίασης ή άλλη εφαρμοστέα πηγή. Η κλήση του [getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/#getEffective--) στο μορφότυπο του τμήματος επιστρέφει το τελικό επίλυτο ύψος.

Χρησιμοποιήστε τα δύο είδη δεδομένων μορφοποίησης για διαφορετικούς σκοπούς:

- Αναγνώστε ή αλλάξτε ένα τοπικό αντικείμενο μορφοποίησης, όπως [IPortionFormat](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/), όταν χρειάζεται να ελέγξετε πού ορίζεται μια τιμή.
- Αναγνώστε ένα αντικείμενο αποτελεσματικών δεδομένων, όπως [IPortionFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformateffectivedata/), όταν χρειάζεστε το τελικό, εμφανιζόμενο αποτέλεσμα. Τα αποτελεσματικά δεδομένα είναι μόνο για ανάγνωση.

## **Σύγκριση Τοπικών, Κληρονομημένων και Αποτελεσματικών Τιμών**

Το παρακάτω πλήρες παράδειγμα δημιουργεί ένα σχήμα και εφαρμόζει ύψη γραμματοσειράς σε επίπεδο παρουσίασης, παραγράφου και τμήματος. Κάθε βήμα εκτυπώνει τις τιμές που ορίζονται σε αυτά τα επίπεδα και την προκύπτουσα αποτελεσματική τιμή για το ίδιο τμήμα κειμένου. Επίσης δείχνει γιατί τα αποτελεσματικά δεδομένα πρέπει να διαβαστούν ξανά μετά από αλλαγές μορφοποίησης.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80, false);
            ITextFrame textFrame = shape.addTextFrame("Effective formatting");
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            // Ορίστε κληρονομημένες τιμές σε δύο διαφορετικά επίπεδα.
            presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(20);
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(28);

            printFontHeights("The portion inherits from the paragraph", presentation, paragraph, portion);

            // Μια τοπική τιμή στο τμήμα αντικαθιστά και τις δύο κληρονομημένες τιμές.
            portion.getPortionFormat().setFontHeight(36);
            printFontHeights("A local value overrides inherited values", presentation, paragraph, portion);

            // Η αλλαγή μιας κληρονομημένης τιμής δεν αντικαθιστά μια υπάρχουσα τοπική τιμή.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(30);
            printFontHeights("The local value still has priority", presentation, paragraph, portion);

            // Καθαρίστε την τοπική τιμή. Το τμήμα τώρα κληρονομεί ξανά από την παράγραφο.
            portion.getPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The local value is cleared", presentation, paragraph, portion);

            // Καθαρίστε την τιμή της παραγράφου. Η προεπιλογή της παρουσίασης τώρα παρέχει το αποτέλεσμα.
            paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(Float.NaN);
            printFontHeights("The paragraph value is cleared", presentation, paragraph, portion);

            presentation.save("effective-properties.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static void printFontHeights(String caption, Presentation presentation, IParagraph paragraph, IPortion portion) {
        float presentationValue = presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().getFontHeight();
        float paragraphValue = paragraph.getParagraphFormat().getDefaultPortionFormat().getFontHeight();
        float localValue = portion.getPortionFormat().getFontHeight();

        // Διαβάστε τα αποτελεσματικά δεδομένα μετά τις προηγούμενες αλλαγές.
        float effectiveValue = portion.getPortionFormat().getEffective().getFontHeight();

        System.out.println(caption);
        System.out.println("  Presentation default: " + formatLocalValue(presentationValue));
        System.out.println("  Paragraph default:    " + formatLocalValue(paragraphValue));
        System.out.println("  Portion local:        " + formatLocalValue(localValue));
        System.out.println("  Portion effective:    " + effectiveValue);
    }

    private static String formatLocalValue(float value) {
        return Float.isNaN(value) ? "<not set>" : Float.toString(value);
    }
}
```

Η προτεραιότητα σε αυτό το παράδειγμα είναι η τοπική μορφοποίηση του τμήματος, μετά η μορφοποίηση της παραγράφου και τέλος η προεπιλογή της παρουσίασης. Άλλα αντικείμενα μπορεί να έχουν διαφορετικές αλυσίδες κληρονομικότητας, αλλά η αρχή είναι η ίδια: μια πιο συγκεκριμένη ρητή τιμή κερδίζει, και το [getEffective](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/#getEffective--) επιστρέφει το τελικό αποτέλεσμα.

## **Λήψη Αποτελεσματικών Ιδιοτήτων Κειμένου**

Η μορφοποίηση κειμένου είναι κατανεμημένη σε διάφορα αντικείμενα:

- [ITextFrameFormat.getEffective()](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextframeformat/#getEffective--) επιλύει τις ιδιότητες του πλαισίου κειμένου όπως περιθώρια, αγκύρωση, αυτόματη προσαρμογή και κάθετη κατεύθυνση κειμένου.
- [ITextStyle.getEffective()](https://reference.aspose.com/slides/el/java/com.aspose.slides/itextstyle/#getEffective--) επιλύει τη μορφοποίηση παραγράφου για κάθε επίπεδο στυλ κειμένου.
- [IParagraphFormat.getEffective()](https://reference.aspose.com/slides/el/java/com.aspose.slides/iparagraphformat/#getEffective--) επιλύει τις ιδιότητες παραγράφου όπως στοίχιση, εσοχή και κουκκίδες.
- [IPortionFormat.getEffective()](https://reference.aspose.com/slides/el/java/com.aspose.slides/iportionformat/#getEffective--) επιλύει τις ιδιότητες χαρακτήρων όπως ύψος γραμματοσειράς, γραμματοσειρά, χρώμα, έντονη και πλάγια γραφή.

Για το επόμενο παράδειγμα, το `text-formatting.pptx` πρέπει να περιέχει τουλάχιστον μία διαφάνεια και ένα [AutoShape](https://reference.aspose.com/slides/el/java/com.aspose.slides/autoshape/) με μη κενό πλαίσιο κειμένου. Το AutoShape μπορεί να εμφανιστεί σε οποιαδήποτε θέση στη συλλογή σχημάτων· ο κώδικας αναζητά ένα κατάλληλο αντικείμενο και το επαληθεύει πριν τη χρήση.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("text-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            IAutoShape shape = findAutoShapeWithText(presentation.getSlides().get_Item(0));
            if (shape == null) {
                throw new IllegalStateException("The first slide must contain an AutoShape with non-empty text.");
            }

            ITextFrame textFrame = shape.getTextFrame();
            IParagraph paragraph = textFrame.getParagraphs().get_Item(0);
            IPortion portion = paragraph.getPortions().get_Item(0);

            ITextFrameFormatEffectiveData textFrameEffective = textFrame.getTextFrameFormat().getEffective();
            IParagraphFormatEffectiveData paragraphEffective = paragraph.getParagraphFormat().getEffective();
            IPortionFormatEffectiveData portionEffective = portion.getPortionFormat().getEffective();

            System.out.println("Text frame margins:");
            System.out.println("  Left: " + textFrameEffective.getMarginLeft());
            System.out.println("  Top: " + textFrameEffective.getMarginTop());
            System.out.println("  Right: " + textFrameEffective.getMarginRight());
            System.out.println("  Bottom: " + textFrameEffective.getMarginBottom());
            System.out.println("Paragraph alignment: " + paragraphEffective.getAlignment());
            System.out.println("Font height: " + portionEffective.getFontHeight());
            System.out.println("Bold: " + portionEffective.getFontBold());

            ITextStyleEffectiveData effectiveTextStyle = textFrame.getTextFrameFormat().getTextStyle().getEffective();
            for (int level = 0; level < 9; level++) {
                IParagraphFormatEffectiveData levelEffective = effectiveTextStyle.getLevel(level);
                System.out.println("Level " + level + " indent: " + levelEffective.getIndent());
            }
        } finally {
            presentation.dispose();
        }
    }

    private static IAutoShape findAutoShapeWithText(ISlide slide) {
        for (IShape candidate : slide.getShapes()) {
            if (candidate instanceof IAutoShape && hasNonEmptyText((IAutoShape)candidate)) {
                return (IAutoShape)candidate;
            }
        }
        return null;
    }

    private static boolean hasNonEmptyText(IAutoShape shape) {
        if (shape.getTextFrame() == null) {
            return false;
        }
        if (shape.getTextFrame().getParagraphs().getCount() == 0) {
            return false;
        }
        return shape.getTextFrame().getParagraphs().get_Item(0).getPortions().getCount() > 0;
    }
}
```

## **Λήψη Αποτελεσματικών 3Δ Ιδιοτήτων**

Το [IThreeDFormat.getEffective()](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformat/#getEffective--) επιστρέφει ένα αντικείμενο [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformateffectivedata/) που ομαδοποιεί όλες τις επιλυμένες ρυθμίσεις 3Δ. Οι μέθοδοι [getCamera](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformateffectivedata/#getCamera--), [getLightRig](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformateffectivedata/#getLightRig--), [getBevelTop](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformateffectivedata/#getBevelTop--), και [getBevelBottom](https://reference.aspose.com/slides/el/java/com.aspose.slides/ithreedformateffectivedata/#getBevelBottom--) εκθέτουν τα αντίστοιχα αποτελεσματικά δεδομένα. Η ανάγνωση αυτών των σχετικών ρυθμίσεων μαζί καθιστά πιο εύκολο να κατανοηθεί η τελική 3Δ εμφάνιση ενός σχήματος.

Για αυτό το παράδειγμα, το `shape-3d.pptx` πρέπει να περιέχει τουλάχιστον ένα σχήμα στην πρώτη του διαφάνεια. Εφαρμόστε ρυθμίσεις 3Δ κάμερας, φωτισμού ή κλίσης σε αυτό το σχήμα εάν θέλετε η έξοδος να περιέχει τιμές διαφορετικές από τις προεπιλογές.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("shape-3d.pptx");
        try {
            if (presentation.getSlides().size() == 0 || presentation.getSlides().get_Item(0).getShapes().size() == 0) {
                throw new IllegalStateException("The first slide must contain a shape.");
            }

            IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
            IThreeDFormatEffectiveData threeDEffective = shape.getThreeDFormat().getEffective();

            System.out.println("Camera:");
            System.out.println("  Type: " + threeDEffective.getCamera().getCameraType());
            System.out.println("  Field of view: " + threeDEffective.getCamera().getFieldOfViewAngle());
            System.out.println("  Zoom: " + threeDEffective.getCamera().getZoom());

            System.out.println("Light rig:");
            System.out.println("  Type: " + threeDEffective.getLightRig().getLightType());
            System.out.println("  Direction: " + threeDEffective.getLightRig().getDirection());

            System.out.println("Top bevel:");
            System.out.println("  Type: " + threeDEffective.getBevelTop().getBevelType());
            System.out.println("  Width: " + threeDEffective.getBevelTop().getWidth());
            System.out.println("  Height: " + threeDEffective.getBevelTop().getHeight());
        } finally {
            presentation.dispose();
        }
    }
}
```

## **Λήψη Αποτελεσματικής Μορφοποίησης Πίνακα**

Η μορφοποίηση πίνακα μπορεί να προέρχεται από το στυλ πίνακα και από μορφοποιήσεις που εφαρμόζονται σε ολόκληρο τον πίνακα, μια στήλη, μια γραμμή ή ένα μεμονωμένο κελί. Σε συγκρούσεις μεταξύ ρητά ορισμένων γεμίσεων, η προτεραιότητα είναι κελί, γραμμή, στήλη και μετά ολόκληρος ο πίνακας. Η αποτελεσματική μορφή ενός κελιού είναι η τελική μορφή που χρησιμοποιείται για τη σχεδίαση του κελιού.

Για αυτό το παράδειγμα, το `table-formatting.pptx` πρέπει να περιέχει τουλάχιστον έναν πίνακα στην πρώτη του διαφάνεια. Ο πίνακας πρέπει να έχει τουλάχιστον μία γραμμή και μία στήλη. Ο κώδικας αναζητά ένα [ITable](https://reference.aspose.com/slides/el/java/com.aspose.slides/itable/) αντί να υποθέτει ότι το `getShapes().get_Item(0)` είναι πίνακας.

```java
import com.aspose.slides.*;

public class Main {
    public static void main(String[] args) {
        Presentation presentation = new Presentation("table-formatting.pptx");
        try {
            if (presentation.getSlides().size() == 0) {
                throw new IllegalStateException("The presentation contains no slides.");
            }

            ITable table = findTable(presentation.getSlides().get_Item(0));
            if (table == null) {
                throw new IllegalStateException("The first slide must contain a table.");
            }
            if (table.getRows().size() == 0 || table.getColumns().size() == 0) {
                throw new IllegalStateException("The table must contain at least one cell.");
            }

            ITableFormatEffectiveData tableEffective = table.getTableFormat().getEffective();
            IRowFormatEffectiveData rowEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
            IColumnFormatEffectiveData columnEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
            ICellFormatEffectiveData cellEffective = table.get_Item(0, 0).getCellFormat().getEffective();

            System.out.println("Table fill: " + tableEffective.getFillFormat().getFillType());
            System.out.println("Row fill: " + rowEffective.getFillFormat().getFillType());
            System.out.println("Column fill: " + columnEffective.getFillFormat().getFillType());
            System.out.println("Final cell fill: " + cellEffective.getFillFormat().getFillType());
        } finally {
            presentation.dispose();
        }
    }

    private static ITable findTable(ISlide slide) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                return (ITable)shape;
            }
        }
        return null;
    }
}
```

Εάν χρειάζεστε το χρώμα αντί μόνο του τύπου γέμισης, ελέγξτε πρώτα το αποτελεσματικό [getFillType](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformateffectivedata/#getFillType--), και στη συνέχεια διαβάστε τη μέθοδο που εφαρμόζεται σε εκείνο τον τύπο — για παράδειγμα, το [getSolidFillColor](https://reference.aspose.com/slides/el/java/com.aspose.slides/ifillformateffectivedata/#getSolidFillColor--) για μια στερεή γέμιση.

## **Επαναδιαβάστε τα Αποτελεσματικά Δεδομένα Μετά τις Αλλαγές**

Τα αποτελεσματικά δεδομένα περιγράφουν την ιεραρχία μορφοποίησης τη στιγμή που επιλύονται. Καλέστε ξανά το `getEffective` μετά από αλλαγή οτιδήποτε μπορεί να συμμετέχει σε αυτήν την ιεραρχία, συμπεριλαμβανομένου:

- της τοπικής μορφοποίησης του αντικειμένου·
- των προεπιλογών παραγράφου ή πλαισίου κειμένου·
- ενός στυλ πίνακα, πίνακα, στήλης, γραμμής ή μορφοποίησης κελιού·
- μορφοποίηση διάταξης ή κύριας διαφάνειας·
- δεδομένων θέματος ή προεπιλογών σε επίπεδο παρουσίασης·
- της διάταξης ή του κύριου που έχουν εκχωρηθεί σε μια διαφάνεια.

Μην κρατάτε ένα αντικείμενο αποτελεσματικών δεδομένων ως μόνιμη φωτογραφία. Το Aspose.Slides ενδέχεται να αποθηκεύει κάποια αποτελεσματικά δεδομένα σε εσωτερική προσωρινή μνήμη, και μια μεταγενέστερη κλήση `getEffective` μπορεί να ανανεώσει αυτά τα δεδομένα. Εάν χρειάζεστε να συγκρίνετε τιμές πριν και μετά από μια αλλαγή, αντιγράψτε τις απαραίτητες τιμές (όπως ύψος γραμματοσειράς, χρώμα, στοίχιση ή πλάτος κλίσης) σε δικές σας μεταβλητές πριν κάνετε την αλλαγή.

Για να αλλάξετε μια τιμή, ενημερώστε το κατάλληλο τοπικό αντικείμενο μορφοποίησης και στη συνέχεια καλέστε το `getEffective` για να επαληθεύσετε το αποτέλεσμα. Τα αντικείμενα αποτελεσματικών δεδομένων είναι μόνο για ανάγνωση.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να καταλάβω ποιο επίπεδο παρείχε μια αποτελεσματική τιμή;**

Τα αποτελεσματικά δεδομένα περιέχουν τη τελική τιμή, όχι την πηγή της. Εξετάστε τα σχετικά τοπικά αντικείμενα ξεκινώντας από το πιο συγκεκριμένο επίπεδο προς τα έξω. Για το κείμενο, αυτό μπορεί να περιλαμβάνει το τμήμα, την παράγραφο, το πλαίσιο κειμένου, τη διάταξη, τον κύριο, το θέμα και τις προεπιλογές παρουσίασης. Απροσδιόριστες τιμές όπως `Float.NaN` ή `null` υποδεικνύουν ότι η αναζήτηση συνεχίζεται σε άλλο επίπεδο.

**Τι συμβαίνει όταν κανένα επίπεδο δεν ορίζει μια ιδιότητα;**

Το Aspose.Slides επιλύει την κατάλληλη προεπιλογή του PowerPoint ή της βιβλιοθήκης. Η επιλυμένη τιμή εμφανίζεται στα αποτελεσματικά δεδομένα παρά το ότι κανένα τοπικό αντικείμενο δεν την ορίζει ρητά.

**Γιατί μερικές φορές μια αποτελεσματική τιμή ισούται με τη τοπική τιμή;**

Η τοπική τιμή κέρδισε τον υπολογισμό κληρονομικότητας. Αυτό είναι αναμενόμενο όταν η ιδιότητα ορίζεται ρητά στο αντικείμενο και κανένας πιο συγκεκριμένος κανόνας δεν την παρακάμψει.

**Πότε πρέπει να χρησιμοποιήσω τοπικά δεδομένα αντί για αποτελεσματικά δεδομένα;**

Χρησιμοποιήστε τοπικά δεδομένα για να ελέγξετε ή να επεξεργαστείτε ένα συγκεκριμένο επίπεδο μορφοποίησης. Χρησιμοποιήστε αποτελεσματικά δεδομένα όταν χρειάζεστε την τελική εμφάνιση μετά την κληρονομικότητα, τους κανόνες θέματος και τα εφαρμοστέα στυλ. Το [πλήρες παράδειγμα σύγκρισης](#compare-local-inherited-and-effective-values) δείχνει και τα δύο στην ίδια ροή εργασίας.