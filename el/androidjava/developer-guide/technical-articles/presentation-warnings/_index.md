---
title: Διαχείριση Προειδοποιήσεων Παρουσίασης σε Android
type: docs
weight: 90
url: /el/androidjava/presentation-warnings/
aliases:
- /androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback προειδοποίησης
- πολιτική προειδοποίησης
- απώλεια δεδομένων
- διαφθορά πηγής
- θέμα συμβατότητας
- αντικατάσταση γραμματοσειράς
- ψηφιακή υπογραφή
- φόρτωση παρουσίασης
- απόδοση παρουσίασης
- μετατροπή παρουσίασης
- αποθήκευση παρουσίασης
- PowerPoint
- OpenDocument
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να συλλέγετε, ταξινομείτε και ενεργείτε σε προειδοποιήσεις κατά τη φόρτωση, την απόδοση, τη μετατροπή και την αποθήκευση παρουσιάσεων με το Aspose.Slides για Android μέσω Java."
---
## **Επισκόπηση**

Aspose.Slides μπορεί να αναφέρει ανακτήσιμα προβλήματα κατά τη φόρτωση, την απόδοση, τη μετατροπή ή την αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένες εγγραφές πηγής, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειράς και περιορισμούς του προορισμού μορφής. Ένα callback προειδοποίησης επιτρέπει σε μια εφαρμογή να καταγράψει αυτές τις συνθήκες και να αποφασίσει αν η τρέχουσα λειτουργία μπορεί να συνεχιστεί.

Υλοποιήστε το [IWarningCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarningcallback/) interface και εξετάστε τις τιμές [getWarningType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) και [getDescription](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) που παρέχονται μέσω του [IWarningInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarninginfo/). Επιστρέψτε το [ReturnAction.Continue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/returnaction/#Continue) για να αποδεχθείτε την προειδοποίηση ή το [ReturnAction.Abort](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/returnaction/#Abort) για να σταματήσετε τη λειτουργία.

Χρησιμοποιήστε το [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) για προειδοποιήσεις που προκύπτουν κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις επιλογών απόδοσης και εξαγωγής κληρονομούν το [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφάνειας, τη μετατροπή και την αποθήκευση. Επειδή η προειδοποίηση δεν προσδιορίζει τη λειτουργία της εφαρμογής, συσχετίστε κάθε instance callback με ένα στάδιο λειτουργίας όταν δημιουργείτε μια ενιαία αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Μία προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακάμψει εάν το callback επιστρέψει `ReturnAction.Continue`. Μία εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να διαχειριστούν από πολιτική προειδοποίησης.

Η επιστροφή `ReturnAction.Abort` ζητά από τον dispatcher προειδοποιήσεων να τερματίσει την τρέχουσα λειτουργία σηκώνοντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και τη μορφή παρουσίασης. Για παράδειγμα, η φόρτωση μπορεί να προκύψει με [PptxReadException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxreadexception/) ή [PptReadException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptreadexception/), ενώ η αποθήκευση ή εξαγωγή μπορεί να προκύψει με [PptxException](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/pptxexception/). Διαχειριστείτε την εξαίρεση στα όρια της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποιήσεων για να καθορίσετε εάν η πολιτική της εφαρμογής προκάλεσε τον τερματισμό αντί να βασίζεστε σε έναν υποτύπο εξαίρεσης ή μήνυμα. Το callback καταγράφει την προειδοποίηση πριν επιστρέψει `ReturnAction.Abort`, εξασφαλίζοντας ότι ο λόγος παραμένει διαθέσιμος στην εφαρμογή.

## **Κατηγορίες Προειδοποιήσεων**

Η κλάση [WarningType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/) παρέχει ακέραιους σταθερούς για τις ακόλουθες κατηγορίες:

| Τύπος προειδοποίησης | Νόημα | Τυπική πολιτική |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/#SourceFileCorruption) | Η πηγαία παρουσίαση περιέχει φθορές που μπορούν να κάνουν ένα έγγραφο αποθηκευμένο στην αρχική του μορφή μη χρησιμοποιήσιμο. | Απόρριψη. |
| [DataLoss](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/#DataLoss) | Κείμενο, διαγράμματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή την αποθήκευση. | Απόρριψη. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/#MajorFormattingLoss) | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Απόρριψη σε αυστηρή λειτουργία επαλήθευσης· διαφορετικά καταγραφή και συνέχεια. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/#MinorFormattingLoss) | Μπορεί να προκύψει περιορισμένη διαφορά μορφοποίησης. | Καταγραφή για διάγνωση και συνέχεια. |
| [CompatibilityIssue](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/#CompatibilityIssue) | Το αποτέλεσμα μπορεί να μην ανοίξει ή να συμπεριφερθεί σωστά σε ορισμένες εφαρμογές ή παλαιότερες εκδόσεις. | Καταγραφή και συνέχεια εκτός εάν η συμβατότητα είναι υποχρεωτική. |
| [UnexpectedContent](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/warningtype/#UnexpectedContent) | Η πηγή περιέχει μη υποστηριζόμενο ή μη αναγνωρίσιμο περιεχόμενο του οποίου η επίδραση ενδέχεται να μην είναι ακόμη γνωστή. | Καταγραφή και συνέχεια, ή αντιμετώπιση ως σφάλμα σε αυστηρή πολιτική. |

Η κατηγορία πρέπει να καθοδηγεί την απόφαση πολιτικής. Αποθηκεύστε την τιμή που επιστρέφεται από το [getDescription](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarninginfo/#getDescription--) για διαγνωστικούς σκοπούς, αλλά μην εξαρτάστε από τη διατύπωσή της για λογική της εφαρμογής, επειδή το κείμενο του μηνύματος μπορεί να διαφέρει μεταξύ σεναρίων προειδοποίησης και εκδόσεων του προϊόντος.

## **Συλλογή και Κατηγοριοποίηση Προειδοποιήσεων**

Το παρακάτω παράδειγμα χρησιμοποιεί μία αναφορά σε επίπεδο εφαρμογής για ολόκληρη τη διαδικασία επεξεργασίας. Μία ξεχωριστή instance callback επισημαίνει προειδοποιήσεις από τη φόρτωση, την απόδοση, τη μετατροπή σε PDF και την αποθήκευση PPTX. Η πολιτική ακυρώνει σε περίπτωση φθορών πηγής ή απώλειας δεδομένων, προαιρετικά ακυρώνει σε περίπτωση μεγάλης απώλειας μορφοποίησης και συνεχίζει για τις υπόλοιπες προειδοποιήσεις.

Τοποθετήστε το `input.pptx` σε έναν εγγράψιμο κατάλογο εφαρμογής και περάστε αυτόν τον κατάλογο στη μέθοδο `PresentationWarningExample.run`. Το παράδειγμα αποθηκεύει τα αποτελέσματά του στον ίδιο κατάλογο. Εκτελέστε την επεξεργασία παρουσίασης σε νήμα του παρασκηνίου για να διατηρήσετε το Android UI ανταποκρινόμενο.

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
import java.io.File;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

public class PresentationWarningExample {
    public static void run(File dataDirectory) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        File inputFile = new File(dataDirectory, "input.pptx");
        boolean completed = processPresentation(inputFile.getAbsolutePath(), dataDirectory, report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, dataDirectory, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, dataDirectory, report, policy);
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

    private static boolean renderFirstSlide(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
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
                File outputFile = new File(dataDirectory, "slide-1.png");
                image.save(outputFile.getAbsolutePath(), ImageFormat.Png);
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

    private static boolean convertToPdf(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "converted.pdf");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, File dataDirectory, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            File outputFile = new File(dataDirectory, "validated-output.pptx");
            presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx, options);
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

Περνάτε `false` για το `abortOnMajorFormattingLoss` κατά την κατασκευή του `WarningPolicy` εφόσον οι μεγάλες διαφορές μορφοποίησης είναι αποδεκτές. Τα ζητήματα συμβατότητας, η μικρή απώλεια μορφοποίησης και το μη αναμενόμενο περιεχόμενο παραμένουν στην αναφορά ακόμη και όταν η λειτουργία συνεχίζει. Επεκτείνετε το `WarningPolicy.getAction` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποιήσεων**

- **Digital signatures:** Μία υπο signed παρουσίαση μπορεί να δημιουργήσει προειδοποίηση κατά τη φόρτωση ότι η υπογραφή της θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτήν την κατάσταση `DataLoss` μέσω του [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/ipresentationsignedwarninginfo/). Ένα callback στο στάδιο φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχθεί ρητά την αναφερόμενη απώλεια.
- **Font substitution:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί ενώ μια διαφάνεια αποδίδεται ή εξάγεται. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, έτσι η αυστηρή πολιτική παραπάνω ακυρώνει ακόμη και αν η εφαρμογή θεωρεί την αντικατάσταση οπτικά αποδεκτή. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά μη διαθέσιμη στο χρόνο εκτέλεσης. Η περιγραφή της προειδοποίησης προσδιορίζει την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/androidjava/font-substitution/) πριν επαναλάβετε.
- **Unsupported or unexpected content:** Ένας φορτωτής μπορεί να συναντήσει εγγραφές παρουσίασης ή δυνατότητες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν `UnexpectedContent`, ή πιο σοβαρή κατηγορία όταν γνωστοί είναι οι επηρεαζόμενοι δεδομένα ή μορφοποίηση.
- **Format compatibility:** Η αποθήκευση σε άλλη μορφή παρουσίασης μπορεί να παραλείψει χαρακτηριστικά ή να δημιουργήσει αποτέλεσμα που συμπεριφέρεται διαφορετικά σε ορισμένες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερους από οκτώ οριζόντιους ή οκτώ κάθετους οδηγούς σχεδίασης σε κληρονομική PPT αναφέρει `CompatibilityIssue`. Το callback στο στάδιο αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να την απορρίψει εάν απαιτείται η διατήρηση όλων των οδηγών.
- **Loading behavior:** Οι επιλογές φόρτωσης και οι κληρονομικές συμπεριφορές μπορούν επίσης να παράγουν προειδοποιήσεις. Για παράδειγμα, το [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) προσδιορίζει τη χρήση μιας ξεπερασμένης συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το έγγραφο πηγής, τη μορφή προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην υποθέτετε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μία μόνο κατηγορία.

## **Ασφαλής Διαχείριση Ακυρωμένων Λειτουργιών**

Όταν ένα callback επιστρέφει `ReturnAction.Abort`, μην χρησιμοποιείτε ένα αντικείμενο που απέτυχε να φορτωθεί και μην υποθέτετε ότι το αποτέλεσμα από την απόδοση ή αποθήκευση είναι πλήρες. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία ενός αρχείου εξόδου αλλά πριν η διαδικασία ολοκληρωθεί.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε ξεχωριστό μονοπάτι, όπως `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο μετά την επιτυχή ολοκλήρωση της λειτουργίας, εφόσον η αναφορά προειδοποιήσεων ικανοποιεί την πολιτική της εφαρμογής και το αποτέλεσμα μπορεί να ανοιχτεί και να ελεγχθεί. Αυτό αποτρέπει την αντικατάσταση ενός έγκυρου αρχείου πηγής με μερικό ή απορριφθέν αποτέλεσμα.

Μια κενή αναφορά προειδοποιήσεων δεν αποτελεί εγγύηση ότι κάθε χαρακτηριστικό πηγής διατηρήθηκε. Εφαρμόστε τυχόν επιπλέον ελέγχους περιεχομένου και οπτικούς ελέγχους που απαιτούνται από την εφαρμογή. Δείτε επίσης [Άνοιγμα Παρουσιάσεων](/slides/el/androidjava/open-presentation/) και [Αποθήκευση Παρουσιάσεων](/slides/el/androidjava/save-presentation/).

## **Συχνές Ερωτήσεις**

**Μπορεί ένα callback προειδοποίησης να διαχειριστεί κάθε σφάλμα του Aspose.Slides;**

Όχι. Διαχειρίζεται μόνο τις ανακτήσιμες συνθήκες που αναφέρονται ως προειδοποιήσεις. Οι εξαιρέσεις που εμφανίζονται ανεξάρτητα από το callback πρέπει να αντιμετωπίζονται από την εφαρμογή γύρω από την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Εγγυάται η επιστροφή `ReturnAction.Continue` το ίδιο αποτέλεσμα;**

Όχι. Επιτρέπει μόνο τη συνέχεια της επεξεργασίας. Η αναφερόμενη κατάσταση μπορεί ακόμη να προκαλέσει διαφορές σε δεδομένα, μορφοποίηση ή συμβατότητα, επομένως εξετάστε τους συλλεγμένους τύπους προειδοποιήσεων και περιγραφές.

**Πώς μπορεί μια εφαρμογή να ταυτοποιήσει τη λειτουργία που παρήγαγε την προειδοποίηση;**

Δημιουργήστε μια instance callback για κάθε λειτουργία και αποθηκεύστε ένα στάδιο που ορίζεται από την εφαρμογή μαζί με τις τιμές που επιστρέφονται από τα [getWarningType](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarninginfo/#getWarningType--) και [getDescription](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/iwarninginfo/#getDescription--), όπως φαίνεται στο παράδειγμα.