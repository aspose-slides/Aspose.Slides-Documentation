---
title: Διαχείριση Προειδοποιήσεων Παρουσίασης σε Java
type: docs
weight: 90
url: /el/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- κλήση προειδοποίησης
- πολιτική προειδοποίησης
- απώλεια δεδομένων
- καταστροφή πηγής
- ζήτημα συμβατότητας
- αντικατάσταση γραμματοσειράς
- ψηφιακή υπογραφή
- φόρτωση παρουσίασης
- απόδοση παρουσίασης
- μετατροπή παρουσίασης
- αποθήκευση παρουσίασης
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Μάθετε πώς να συλλέγετε, ταξινομείτε και αντιδράτε σε προειδοποιήσεις κατά τη φόρτωση, απόδοση, μετατροπή και αποθήκευση παρουσιάσεων με το Aspose.Slides για Java."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναφέρει προβλήματα που είναι ανακτήσιμα κατά τη φόρτωση, την απόδοση, τη μετατροπή ή την αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένες πηγές αρχείων, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειρών και περιορισμούς του μορφότυπου προορισμού. Μια κλήση προειδοποίησης επιτρέπει σε μια εφαρμογή να καταγράψει αυτές τις συνθήκες και να αποφασίσει εάν η τρέχουσα λειτουργία μπορεί να συνεχιστεί.

Υλοποιήστε το interface [IWarningCallback] και εξετάστε τις τιμές [getWarningType] και [getDescription] που παρέχονται μέσω του [IWarningInfo]. Επιστρέψτε το [ReturnAction.Continue] για να αποδεχτείτε την προειδοποίηση ή το [ReturnAction.Abort] για να διακόψετε τη λειτουργία.

Χρησιμοποιήστε το [LoadOptions.setWarningCallback] για προειδοποιήσεις που προκύπτουν κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις επιλογών απόδοσης και εξαγωγής κληρονομούν το [SaveOptions.setWarningCallback], το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφανειών, τη μετατροπή και την αποθήκευση. Επειδή η προειδοποίηση δεν ταυτοποιεί τη λειτουργία της εφαρμογής, συνδέστε κάθε αντικείμενο κλήσης με ένα στάδιο λειτουργίας όταν δημιουργείτε μια ενιαία αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Μια προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακάμψει εάν η κλήση επιστρέψει `ReturnAction.Continue`. Μία εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να διαχειριστούν από πολιτική προειδοποίησης.

Η επιστροφή του `ReturnAction.Abort` ζητά από το διαχειριστή προειδοποιήσεων να τερματίσει την τρέχουσα λειτουργία πετάγοντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και το μορφότυπο παρουσίασης. Για παράδειγμα, η φόρτωση μπορεί να αποδώσει μια [PptxReadException] ή [PptReadException], ενώ η αποθήκευση ή η εξαγωγή μπορεί να αποδώσει μια [PptxException]. Διαχειριστείτε την εξαίρεση στο όριο της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποίησης για να προσδιορίσετε εάν η πολιτική της εφαρμογής προκάλεσε το τερματισμό, αντί να βασιστείτε σε έναν υποτύπο εξαίρεσης ή μήνυμα. Η κλήση καταγράφει την προειδοποίηση πριν επιστρέψει `ReturnAction.Abort`, εξασφαλίζοντας ότι ο λόγος παραμένει διαθέσιμος στην εφαρμογή.

## **Κατηγορίες Προειδοποιήσεων**

Η κλάση [WarningType] παρέχει ακέραιους σταθερούς για τις ακόλουθες κατηγορίες:

| Τύπος προειδοποίησης | Σημασία | Τυπική πολιτική |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/el/java/com.aspose.slides/warningtype/#SourceFileCorruption) | Η πηγαία παρουσίαση περιέχει κακόβουλη καταστροφή που μπορεί να καταστήσει αχρησιμοποίητο ένα έγγραφο που αποθηκεύεται στην αρχική του μορφή. | Διακοπή. |
| [DataLoss](https://reference.aspose.com/slides/el/java/com.aspose.slides/warningtype/#DataLoss) | Κείμενο, γραφήματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή την αποθήκευση. | Διακοπή. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/el/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Διακοπή σε αυστηρή λειτουργία επικύρωσης· διαφορετικά καταγραφή και συνέχεια. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/el/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Μπορεί να εμφανιστεί περιορισμένη διαφορά μορφοποίησης. | Καταγραφή για διαγνωστικούς σκοπούς και συνέχεια. |
| [CompatibilityIssue](https://reference.aspose.com/slides/el/java/com.aspose.slides/warningtype/#CompatibilityIssue) | Το αποτέλεσμα μπορεί να μην ανοίξει ή να συμπεριφέρεται σωστά σε ορισμένες εφαρμογές ή παλαιότερες εκδόσεις. | Καταγραφή και συνέχεια εκτός εάν η συμβατότητα είναι υποχρεωτική. |
| [UnexpectedContent](https://reference.aspose.com/slides/el/java/com.aspose.slides/warningtype/#UnexpectedContent) | Η πηγή περιέχει μη υποστηριζόμενο ή μη αναγνωρισμένο περιεχόμενο του οποίου η επίδραση ενδέχεται να μην είναι ακόμη γνωστή. | Καταγραφή και συνέχεια, ή αντιμετώπιση ως σφάλμα σε αυστηρή πολιτική. |

Η κατηγορία πρέπει να καθοδηγεί την απόφαση πολιτικής. Αποθηκεύστε την τιμή που επιστρέφεται από [getDescription] για διαγνωστικούς σκοπούς, αλλά μην βασίζεστε στη διατύπωσή της για λογική της εφαρμογής, καθώς το κείμενο του μηνύματος μπορεί να διαφέρει μεταξύ σεναρίων προειδοποίησης και εκδόσεων του προϊόντος.

## **Συλλογή και Κατάταξη Προειδοποιήσεων**

Το παρακάτω παράδειγμα χρησιμοποιεί μία αναφορά επιπέδου εφαρμογής για ολόκληρη τη διαδικασία επεξεργασίας. Ένα ξεχωριστό αντικείμενο κλήσης επισημαίνει προειδοποιήσεις από τη φόρτωση, την απόδοση, τη μετατροπή PDF και την αποθήκευση PPTX. Η πολιτική διακόπτει σε περίπτωση κακής πηγής ή απώλειας δεδομένων, προαιρετικά διακόπτει σε περίπτωση μεγάλης απώλειας μορφοποίησης και συνεχίζει για άλλες προειδοποιήσεις.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Πηγαίνετε `false` για το `abortOnMajorFormattingLoss` κατά τη δημιουργία του `WarningPolicy` εάν οι μεγάλες διαφορές μορφοποίησης είναι αποδεκτές. Τα ζητήματα συμβατότητας, η μικρή απώλεια μορφοποίησης και το μη αναμενόμενο περιεχόμενο παραμένουν στην αναφορά ακόμη και όταν η λειτουργία συνεχίζεται. Επεκτείνετε το `WarningPolicy.getAction` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποιήσεων**

Οι προειδοποιήσεις μπορούν να εμφανιστούν σε διαφορετικά στάδια ενός ροής εργασίας:

- **Ψηφιακές υπογραφές:** Μια υπογεγραμμένη παρουσίαση μπορεί να παράγει προειδοποίηση κατά τη φόρτωση ότι η υπογραφή της θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτήν την κατάσταση `DataLoss` μέσω του [IPresentationSignedWarningInfo]. Μια κλήση στο στάδιο φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχθεί ρητά την αναφερόμενη απώλεια.
- **Αντικατάσταση γραμματοσειράς:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί ενώ μια διαφάνεια αποδίδεται ή εξάγεται. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, έτσι η αυστηρή πολιτική παραπάνω διακόπτει ακόμη και αν η εφαρμογή θα θεωρούσε την αντικατάσταση αποδεκτή οπτικά. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά που δεν είναι διαθέσιμη στο χρόνο εκτέλεσης. Η περιγραφή της προειδοποίησης αναφέρει την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή τους [font substitution rules](/slides/el/java/font-substitution/) πριν ξαναπροσπαθήσετε.
- **Μη υποστηριζόμενο ή μη αναμενόμενο περιεχόμενο:** Ένας φορτωτής μπορεί να συναντήσει εγγραφές παρουσίασης ή λειτουργίες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν `UnexpectedContent` ή μια πιο σοβαρή κατηγορία όταν γνωρίζεται ότι τα δεδομένα ή η μορφοποίηση επηρεάζονται.
- **Συμβατότητα μορφότυπου:** Η αποθήκευση σε διαφορετικό μορφότυπο παρουσίασης μπορεί να παραλείψει λειτουργίες ή να παράγει ένα αποτέλεσμα που συμπεριφέρεται διαφορετικά σε ορισμένες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερους από οκτώ οριζόντιους ή οριζόντιους οδηγούς σχεδίασης σε παλαιό PPT αναφέρει `CompatibilityIssue`. Η κλήση στο στάδιο αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να την απορρίψει εάν απαιτείται η διατήρηση όλων των οδηγών.
- **Συμπεριφορά φόρτωσης:** Οι επιλογές φόρτωσης και οι παλαιές συμπεριφορές μπορούν επίσης να παράγουν προειδοποιήσεις. Για παράδειγμα, το [IObsoletePresLockingBehaviorWarningInfo] εντοπίζει τη χρήση μιας παρωχημένης συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το πηγαίο έγγραφο, τον μορφότυπο προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην υποθέτετε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μία μόνο κατηγορία.

## **Ασφαλής Διαχείριση Διακομμένων Λειτουργιών**

Όταν μια κλήση επιστρέφει `ReturnAction.Abort`, μην χρησιμοποιείτε ένα αντικείμενο που δεν φορτώθηκε και μην υποθέτετε ότι η έξοδος απόδοση ή αποθήκευσης είναι πλήρης. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία του αρχείου εξόδου αλλά πριν ολοκληρωθεί.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε διαφορετική διαδρομή, όπως `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο αφού η λειτουργία ολοκληρωθεί επιτυχώς, η αναφορά προειδοποιήσεων ικανοποιεί την πολιτική της εφαρμογής και η έξοδος μπορεί να ανοιχθεί και να ελεγχθεί. Έτσι αποφεύγετε την αντικατάσταση ενός έγκυρου πηγαίου αρχείου με ένα μερικό ή απορριφθέν αποτέλεσμα.

Μία κενή αναφορά προειδοποιήσεων δεν εγγυάται ότι κάθε πηγαία λειτουργία διατηρήθηκε. Εφαρμόστε τυχόν πρόσθετους ελέγχους περιεχομένου και οπτικούς ελέγχους που απαιτούνται από την εφαρμογή. Δείτε επίσης [Open Presentations](/slides/el/java/open-presentation/) και [Save Presentations](/slides/el/java/save-presentation/).

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορεί μια κλήση προειδοποίησης να χειριστεί κάθε σφάλμα του Aspose.Slides;**

Οχι. Διαχειρίζεται μόνο επανακτήσιμες συνθήκες που αναφέρονται ως προειδοποιήσεις. Οι εξαιρέσεις που εμφανίζονται ανεξάρτητα από την κλήση πρέπει να αντιμετωπιστούν από την εφαρμογή κατά την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Η επιστροφή του `ReturnAction.Continue` εγγυάται το ίδιο ακριβώς αποτέλεσμα;**

Οχι. Επιτρέπει μόνο τη συνέχιση της επεξεργασίας. Η αναφερόμενη κατάσταση μπορεί ακόμη να προκαλέσει διαφορές στα δεδομένα, τη μορφοποίηση ή τη συμβατότητα, επομένως ελέγξτε τους συλλεγμένους τύπους προειδοποιήσεων και τις περιγραφές τους.

**Πώς μπορεί μια εφαρμογή να προσδιορίσει τη λειτουργία που παρήγαγε την προειδοποίηση;**

Δημιουργήστε ένα αντικείμενο κλήσης για κάθε λειτουργία και αποθηκεύστε ένα στάδιο ορισμένο από την εφαρμογή μαζί με τις τιμές που επιστρέφουν οι [getWarningType] και [getDescription], όπως φαίνεται στο παράδειγμα.