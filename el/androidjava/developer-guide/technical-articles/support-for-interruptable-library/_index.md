---
title: Διακοπή μακροχρόνιων λειτουργιών παρουσίασης στο Android
linktitle: Διακοπή λειτουργιών παρουσίασης
type: docs
weight: 120
url: /el/androidjava/support-for-interruptable-library/
keywords:
- διακόψιμες λειτουργίες
- token διακοπής
- token ακύρωσης
- μακροχρόνια εργασία
- διακοπή εργασίας
- PowerPoint
- OpenDocument
- παρουσίαση
- Android
- Java
- Aspose.Slides
description: "Μάθετε πώς να ακυρώνετε μακροχρόνιες λειτουργίες παρουσίασης στο Aspose.Slides για Android μέσω Java και να επιστρέφετε μερικό αποτέλεσμα κατά την εξαγωγή διαφανειών σε βρόχο."
---
## **Επισκόπηση**

Το Aspose.Slides for Android μέσω Java μπορεί να διακόψει μεγάλες διαρκείς λειτουργίες όπως η φόρτωση, η αποθήκευση και η απόδοση παρουσιάσεων. Η εφαρμογή σας μπορεί να χρησιμοποιήσει το ίδιο token διακοπής για να σταματήσει έναν βρόχο πριν αρχίσει να επεξεργάζεται την επόμενη διαφάνεια.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/), λάβετε το token του με [getToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#getToken--), και περάστε το token στην [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Περνέστε τις επιλογές φόρτωσης στον [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Για να ζητήσετε ακύρωση, καλέστε [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) στο αντικείμενο. Μια λειτουργία που μπορεί να διακοπεί σταματά όταν παρατηρήσει το αίτημα.

Το παράδειγμα μετατρέπει το `sample.pptx` σε `sample.ppt` σε ένα νήμα παρασκηνίου. Το νήμα που κάνει την κλήση περιμένει έως 10 δευτερόλεπτα για την ολοκλήρωση της μετατροπής. Αν η μετατροπή εξακολουθεί να εκτελείται, ζητά ακύρωση και περιμένει το νήμα εργασίας να τερματιστεί.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.io.File;

public class InterruptConversion {
    // Κλήση από νήμα παρασκηνίου και πέρασμα του context.getFilesDir(), το οποίο περιέχει το sample.pptx.
    public static void run(File directory) throws InterruptedException {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.ppt");
        InterruptionTokenSource source = new InterruptionTokenSource();
        Thread worker = new Thread(() -> {
            LoadOptions options = new LoadOptions();
            options.setInterruptionToken(source.getToken());
            try {
                Presentation presentation = new Presentation(input.getAbsolutePath(), options);
                try {
                    presentation.save(output.getAbsolutePath(), SaveFormat.Ppt);
                } finally {
                    presentation.dispose();
                }
            } catch (OperationCanceledException canceled) {
                System.out.println("Conversion canceled");
            }
        });

        worker.start();
        worker.join(10000);
        if (worker.isAlive()) {
            source.interrupt();
            worker.join();
        }
    }
}
```

## **Σύνδεση χρονοδιακοπής Java με Aspose.Slides**

Για να θέσετε όριο χρόνου σε μια λειτουργία παρουσίασης, χρησιμοποιήστε ένα [ScheduledExecutorService](https://developer.android.com/reference/java/util/concurrent/ScheduledExecutorService) για να καλέσετε [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) όταν λήξει η χρονοδιακοπή. Το παράδειγμα επιτρέπει 20 δευτερόλεπτα για τη φόρτωση του `sample.pptx` και την εξαγωγή του σε `sample.pdf`. Αν η εξαγωγή ολοκληρωθεί νωρίτερα, η εφαρμογή ακυρώνει το προγραμματισμένο αίτημα.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;
import java.io.File;

public class TimedPdfExport {
    // Κλήση από νήμα παρασκηνίου και πέρασμα του context.getFilesDir(), το οποίο περιέχει το sample.pptx.
    public static void run(File directory) {
        File input = new File(directory, "sample.pptx");
        File output = new File(directory, "sample.pdf");
        InterruptionTokenSource source = new InterruptionTokenSource();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(source.getToken());

        ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
        ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
        try {
            Presentation presentation = new Presentation(input.getAbsolutePath(), options);
            try {
                presentation.save(output.getAbsolutePath(), SaveFormat.Pdf);
            } finally {
                presentation.dispose();
            }
        } catch (OperationCanceledException canceled) {
            System.out.println("Presentation processing was canceled");
        } finally {
            timeout.cancel(false);
            timer.shutdown();
        }
    }
}
```

## **Διακοπή πριν από την επεξεργασία της επόμενης διαφάνειας**

Χρησιμοποιήστε το ίδιο [IInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/) για την παρουσίαση και για τον βρόχο που εξάγει τις διαφάνειές της. Ελέγξτε το [isInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) πριν από κάθε εξαγωγή. Αν ο καλών μπορεί να χρησιμοποιήσει μερικό αποτέλεσμα, επιστρέψτε τους αριθμούς διαφάνειας για τις εξαγωγές που ολοκληρώθηκαν επιτυχώς.

Χρησιμοποιήστε μια παρουσίαση με όνομα `sample.pptx` που περιέχει τουλάχιστον δύο διαφάνειες. Η υπερφόρτωση [Presentation.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int---int-) που δέχεται έναν πίνακα αριθμών διαφάνειας ξεκινά από το 1. Το παράδειγμα αποθηκεύει κάθε διαφάνεια σε ξεχωριστό PDF και ζητά ακύρωση αμέσως μετά την καταγραφή της πρώτης επιτυχούς εξαγωγής.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;
import java.io.File;

public class SlideExporter {
    private static List<Integer> exportSlides(File directory, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        File input = new File(directory, "sample.pptx");
        Presentation presentation = new Presentation(input.getAbsolutePath(), options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    File output = new File(directory, "slide-" + number + ".pdf");
                    presentation.save(output.getAbsolutePath(), new int[] { number }, SaveFormat.Pdf);
                } catch (OperationCanceledException canceled) {
                    if (token.isInterruptionRequested()) {
                        break;
                    }
                    throw canceled;
                }

                completed.add(number);
                if (number == 1) {
                    source.interrupt();
                }
            }
            return completed;
        } finally {
            presentation.dispose();
        }
    }

    // Κλήση από νήμα παρασκηνίου και πέρασμα του context.getFilesDir(), το οποίο περιέχει το sample.pptx.
    public static void run(File directory) {
        InterruptionTokenSource source = new InterruptionTokenSource();
        List<Integer> completed = exportSlides(directory, source);
        System.out.println("Completed: " + completed);
    }
}
```

Το παράδειγμα γράφει το `slide-1.pdf` και εκτυπώνει `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Ο βρόχος παρατηρεί το αίτημα πριν ξεκινήσει η διαφάνεια 2. Αν η ακύρωση έρθει κατά τη διάρκεια αποθήκευσης, ο βρόχος εξέρχεται πριν καταγράψει τη διαφάνεια ως ολοκληρωμένη.

Αν ο καλών χρειάζεται να διαχειριστεί την ακύρωση, αντικαταστήστε τον έλεγχο και το `break` στην κορυφή του βρόχου με `token.throwIfInterruptionRequested()`. Αφαιρέστε το `try`/`catch` γύρω από την αποθήκευση ώστε η ακύρωση κατά την εξαγωγή να φτάσει και στον καλούντα. Με τα ίδια δεδομένα, το παράδειγμα εκτυπώνει μόνο `Starting slide 1` και γράφει το `slide-1.pdf`. Στην αρχή της δεύτερης επανάληψης, το [throwIfInterruptionRequested](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) ρίχνει το `com.aspose.slides.exceptions.OperationCanceledException` πριν ξεκινήσει η επόμενη εξαγωγή. Η μέθοδος δεν επιστρέφει λίστα.

## **Συχνές ερωτήσεις**

**Πότε θα πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν μια λειτουργία υπερβαίνει το όριο χρόνου σας ή όταν η εφαρμογή σας δεν χρειάζεται πλέον το αποτέλεσμα.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/);**

Η πηγή επιτρέπει στην εφαρμογή σας να ζητήσει ακύρωση. Το token επιτρέπει στο Aspose.Slides και στην εφαρμογή σας να ελέγξουν το αίτημα.

**Μπορώ να ακυρώσω μια λειτουργία από ένα χρονομετρητή Java;**

Ναι. Προγραμματίστε μια κλήση στο [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) στην πηγή που είναι συνδεδεμένη με την παρουσίαση.

**Ποιες λειτουργίες μπορώ να διακόψω;**

Μπορείτε να διακόψετε τη φόρτωση, αποθήκευση και απόδοση. Περάστε το token στον [Presentation constructor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) μέσω του [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Η παρουσίαση μπορεί τότε να παρατηρήσει την ακύρωση κατά τις επόμενες λειτουργίες, όπως αποθήκευση σε PDF.

**Σταματάει η λειτουργία άμεσα;**

Η ακύρωση είναι συνεργατική. Μια λειτουργία ελέγχει το token περιοδικά και σταματά όταν παρατηρήσει το αίτημα.

**Τι συμβαίνει αν καλέσω [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) μετά το τέλος μιας λειτουργίας;**

Η ολοκληρωμένη λειτουργία διατηρεί το αποτέλεσμα της.

**Μπορούν πολλαπλές λειτουργίες να μοιράζονται ένα [InterruptionTokenSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/);**

Ναι. Καλώντας το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interruptiontokensource/#interrupt--) ζητάται ακύρωση για κάθε λειτουργία που χρησιμοποιεί token από αυτήν την πηγή. Χρησιμοποιήστε ξεχωριστή πηγή για κάθε λειτουργία που θέλετε να ακυρώνετε ανεξάρτητα.