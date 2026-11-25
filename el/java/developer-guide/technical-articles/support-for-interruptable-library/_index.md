---
title: Διακοπή λειτουργιών παρουσίασης μεγάλης διάρκειας σε Java
linktitle: Διακοπή λειτουργιών παρουσίασης
type: docs
weight: 120
url: /el/java/support-for-interruptable-library/
keywords:
- λειτουργίες με δυνατότητα διακοπής
- διακοπτικό token
- token ακύρωσης
- εργασία μεγάλης διάρκειας
- διακοπή εργασίας
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να ακυρώνετε λειτουργίες παρουσίασης μεγάλης διάρκειας στο Aspose.Slides for Java και να επιστρέφετε μερικό αποτέλεσμα κατά την εξαγωγή διαφανειών σε βρόχο."
---
## **Επισκόπηση**

Aspose.Slides for Java μπορεί να διακόψει λειτουργίες μεγάλης διάρκειας, όπως τη φόρτωση, την αποθήκευση και την απόδοση παρουσιάσεων. Η εφαρμογή σας μπορεί να χρησιμοποιήσει το ίδιο διακοπτικό token για να σταματήσει έναν βρόχο πριν ξεκινήσει την επεξεργασία της επόμενης διαφάνειας.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/), αποκτήστε το token του με [getToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#getToken--), και περάστε το token στο [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Περνείμετε τις επιλογές φόρτωσης στον [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-). Για να ζητήσετε ακύρωση, καλέστε [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) στον πηγαίο αντικείμενο. Μια λειτουργία που μπορεί να διακοπεί σταματά όταν παρατηρεί το αίτημα.

Το παράδειγμα μετατρέπει το `sample.pptx` σε `sample.ppt` σε ένα νήμα παρασκηνίου. Το νήμα που καλεί περιμένει έως 10 δευτερόλεπτα για την ολοκλήρωση της μετατροπής. Εάν η μετατροπή εξακολουθεί να εκτελείται, ζητά ακύρωση και περιμένει να κλείσει ο εργαζόμενος.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;

InterruptionTokenSource source = new InterruptionTokenSource();
Thread worker = new Thread(() -> {
    LoadOptions options = new LoadOptions();
    options.setInterruptionToken(source.getToken());
    try {
        Presentation presentation = new Presentation("sample.pptx", options);
        try {
            presentation.save("sample.ppt", SaveFormat.Ppt);
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
```

## **Σύνδεση χρονοπεριορισμού Java με Aspose.Slides**

Για να ορίσετε χρονικό όριο σε μια λειτουργία παρουσίασης, χρησιμοποιήστε ένα [ScheduledExecutorService](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/util/concurrent/ScheduledExecutorService.html) για να καλέσετε [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) όταν λήξει το χρονικό όριο. Το παράδειγμα επιτρέπει 20 δευτερόλεπτα για τη φόρτωση του `sample.pptx` και την εξαγωγή του σε `sample.pdf`. Εάν η εξαγωγή ολοκληρωθεί νωρίς, η εφαρμογή ακυρώνει το προγραμματισμένο αίτημα.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.concurrent.*;

InterruptionTokenSource source = new InterruptionTokenSource();
LoadOptions options = new LoadOptions();
options.setInterruptionToken(source.getToken());

ScheduledExecutorService timer = Executors.newSingleThreadScheduledExecutor();
ScheduledFuture<?> timeout = timer.schedule(source::interrupt, 20, TimeUnit.SECONDS);
try {
    Presentation presentation = new Presentation("sample.pptx", options);
    try {
        presentation.save("sample.pdf", SaveFormat.Pdf);
    } finally {
        presentation.dispose();
    }
} catch (OperationCanceledException canceled) {
    System.out.println("Presentation processing was canceled");
} finally {
    timeout.cancel(false);
    timer.shutdown();
}
```

## **Διακοπή πριν από την επεξεργασία της επόμενης διαφάνειας**

Χρησιμοποιήστε το ίδιο [IInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/) για την παρουσίαση και τον βρόχο που εξάγει τις διαφάνειες της. Ελέγξτε το [isInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#isInterruptionRequested--) πριν από κάθε εξαγωγή. Εάν ο καλούντας μπορεί να χρησιμοποιήσει μερικό αποτέλεσμα, επιστρέψτε τους αριθμούς διαφανειών για τις εξαγορές που ολοκληρώθηκαν επιτυχώς.

Χρησιμοποιήστε μια παρουσίαση με όνομα `sample.pptx` που περιέχει τουλάχιστον δύο διαφάνειες. Η υπερφόρτωση του [Presentation.save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int---int-) που δέχεται έναν πίνακα αριθμών διαφανειών μετράει από το 1. Το παράδειγμα αποθηκεύει κάθε διαφάνεια σε ξεχωριστό PDF και ζητά ακύρωση αμέσως μετά την καταγραφή της πρώτης επιτυχούς εξαγωγής.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.OperationCanceledException;
import java.util.ArrayList;
import java.util.List;

class SlideExporter {
    List<Integer> exportSlides(String path, InterruptionTokenSource source) {
        List<Integer> completed = new ArrayList<>();
        IInterruptionToken token = source.getToken();
        LoadOptions options = new LoadOptions();
        options.setInterruptionToken(token);
        Presentation presentation = new Presentation(path, options);
        try {
            for (int number = 1; number <= presentation.getSlides().size(); number++) {
                if (token.isInterruptionRequested()) {
                    break;
                }

                System.out.println("Starting slide " + number);
                try {
                    presentation.save("slide-" + number + ".pdf", new int[] { number }, SaveFormat.Pdf);
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
}

InterruptionTokenSource source = new InterruptionTokenSource();
SlideExporter exporter = new SlideExporter();
List<Integer> completed = exporter.exportSlides("sample.pptx", source);
System.out.println("Completed: " + completed);
```

Το παράδειγμα γράφει το `slide-1.pdf` και εκτυπώνει `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Ο βρόχος παρατηρεί το αίτημα πριν ξεκινήσει τη διαφάνεια 2. Εάν η ακύρωση φτάσει κατά τη διάρκεια μιας αποθήκευσης, ο βρόχος εξέρχεται πριν καταγράψει αυτή τη διαφάνεια ως ολοκληρωμένη.

Εάν ο καλούντας χρειάζεται να διαχειριστεί την ακύρωση, αντικαταστήστε τον έλεγχο και το `break` στην αρχή του βρόχου με `token.throwIfInterruptionRequested()`. Αφαιρέστε το `try`/`catch` γύρω από την αποθήκευση ώστε η ακύρωση κατά τη διάρκεια μιας εξαγωγής να φτάσει επίσης στον καλούντα. Με την ίδια είσοδο, το παράδειγμα εκτυπώνει μόνο `Starting slide 1` και γράφει `slide-1.pdf`. Στην αρχή της δεύτερης επανάληψης, το [throwIfInterruptionRequested](https://reference.aspose.com/slides/java/com.aspose.slides/iinterruptiontoken/#throwIfInterruptionRequested--) ρίχνει το `com.aspose.slides.exceptions.OperationCanceledException` πριν αρχίσει η επόμενη εξαγωγή. Η μέθοδος δεν επιστρέφει λίστα.

## **FAQ**

**Πότε πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν μια λειτουργία υπερβαίνει το χρονικό σας όριο ή όταν η εφαρμογή σας δεν χρειάζεται πλέον το αποτέλεσμα.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/)?**

Η πηγή επιτρέπει στην εφαρμογή σας να ζητήσει ακύρωση. Το token επιτρέπει στο Aspose.Slides και στην εφαρμογή σας να ελέγχουν για αυτό το αίτημα.

**Μπορώ να ακυρώσω μια λειτουργία από χρονόμετρο Java;**

Ναι. Προγραμματίστε μια κλήση στο [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) στην πηγή που σχετίζεται με την παρουσίαση.

**Ποιες λειτουργίες μπορώ να διακόψω;**

Μπορείτε να διακόψετε τη φόρτωση, την αποθήκευση και την απόδοση. Περνείμετε το token στον [Presentation constructor](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#Presentation-java.lang.String-com.aspose.slides.LoadOptions-) μέσω του [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-). Η παρουσίαση μπορεί τότε να παρατηρήσει την ακύρωση κατά τη διάρκεια επόμενων λειτουργιών, όπως η αποθήκευση σε PDF.

**Σταματάει η λειτουργία αμέσως;**

Η ακύρωση είναι συνεργατική. Μια λειτουργία ελέγχει το token περιοδικά και σταματά όταν παρατηρεί το αίτημα.

**What happens if I call [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) after an operation finishes?**

Η ολοκληρωμένη λειτουργία διατηρεί το αποτέλεσμα της.

**Μπορείσαν πολλαπλές λειτουργίες να μοιραστούν ένα [InterruptionTokenSource](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/);**

Ναι. Καλώντας το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/java/com.aspose.slides/interruptiontokensource/#interrupt--) ζητάται ακύρωση για κάθε λειτουργία που χρησιμοποιεί ένα token από εκείνη την πηγή. Χρησιμοποιήστε ξεχωριστή πηγή για κάθε λειτουργία που θέλετε να ακυρώσετε ανεξάρτητα.