---
title: Διακοπή μακροχρόνιων λειτουργιών παρουσίασης σε PHP
linktitle: Διακοπή λειτουργιών παρουσίασης
type: docs
weight: 120
url: /el/php-java/support-for-interruptable-library/
keywords:
- διακριτικό διακοπής
- ακύρωση
- χρονικό όριο μετατροπής
- εξαγωγή διαφάνειας
- PowerPoint
- PHP
- Aspose.Slides
description: "Μάθετε πώς να ακυρώσετε τη μετατροπή μιας παρουσίασης με χρονόμετρο και να επιστρέψετε τις διαφάνειες που εξήχθησαν πριν από την ακύρωση με το Aspose.Slides για PHP μέσω Java."
---
## **Επισκόπηση**

Το Aspose.Slides for PHP μέσω Java μπορεί να διακόψει μακροχρόνιες λειτουργίες όπως η φόρτωση, η αποθήκευση και η απόδοση παρουσιάσεων. Σε έναν βρόχο που εξάγει μία διαφάνεια τη φορά, το ίδιο token επιτρέπει στην εφαρμογή σας να σταματήσει πριν από την επόμενη διαφάνεια και να επιστρέψει μια λίστα με τις ολοκληρωμένες εξαγωγές.

Και οι δύο παραδείγματα PHP υποθέτουν ότι η εκκίνηση σας καλεί `define(\"JAVA_PREFER_VALUES\", 1);` πριν φορτώσει το `Java.inc` της γέφυρας, και στη συνέχεια φορτώνει το `aspose.slides.php`. Αυτή η ρύθμιση επιτρέπει στο PHP να εντοπίζει εξαιρέσεις Java κατά τη διάρκεια της κλήσης. Τα παραδείγματα εξετάζουν την αιτία της περιτυλιγμένης εξαίρεσης ώστε άλλα σφάλματα μετατροπής να φτάνουν στον καλούντα.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/), αποκτήστε το token του με το [InterruptionTokenSource::getToken](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#getToken) και περάστε το στο [LoadOptions::setInterruptionToken](https://reference.aspose.com/slides/php-java/aspose.slides/loadoptions/#setInterruptionToken). Παρέχετε αυτές τις επιλογές κατά τη δημιουργία του [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/). Καλώντας το [InterruptionTokenSource::interrupt](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontokensource/#interrupt) ζητείται η ακύρωση. Μια εκτελούμενη λειτουργία σταματά όταν παρατηρήσει το αίτημα.

### **Ορισμός χρόνου λήξης μετατροπής**

Ενώ το PHP περιμένει για μια συγχρονισμένη φόρτωση ή αποθήκευση μέσω της γέφυρας PHP/Java, ένας χρονομετρητής Java μπορεί να ζητήσει ακύρωση σε ξεχωριστό νήμα. Αποθηκεύστε τον παρακάτω βοηθητικό κώδικα ως `ConversionTimeout.java`, μεταγλωττίστε τον με το JAR του Aspose.Slides στο classpath, και κάντε τη μεταγλωττισμένη κλάση διαθέσιμη στη γέφυρα υπό το όνομα πακέτου της, `example.ConversionTimeout`.

```java
package example;

import com.aspose.slides.InterruptionTokenSource;
import java.util.Timer;
import java.util.TimerTask;

public class ConversionTimeout {
    public static Timer start(InterruptionTokenSource source, long milliseconds) {
        Timer timer = new Timer(true);
        timer.schedule(new TimerTask() {
            @Override
            public void run() {
                source.interrupt();
            }
        }, milliseconds);
        return timer;
    }
}
```

Αφού η γέφυρα και το wrapper Aspose.Slides PHP φορτωθούν, εκτελέστε το παρακάτω παράδειγμα με το `sample.pptx` στον τρέχοντα κατάλογο της διαδικασίας Java, ή χρησιμοποιήστε απόλυτες διαδρομές προσβάσιμες σε αυτή τη διαδικασία. Το όριο των 20 δευτερολέπτων καλύπτει τόσο τη φόρτωση όσο και την εξαγωγή σε PDF. Αν η μετατροπή ολοκληρωθεί νωρίτερα, το PHP ακυρώνει τον χρονομετρητή. Για να μετατρέψετε στη παλαιότερη μορφή PowerPoint με όριο 10 δευτερολέπτων, χρησιμοποιήστε `sample.ppt`, `SaveFormat::Ppt` και `10000` χιλιοστά του δευτερολέπτου.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$source = new InterruptionTokenSource();
$token = $source->getToken();
$options = new LoadOptions();
$options->setInterruptionToken($token);
$timer = java("example.ConversionTimeout")->start($source, 20000);
try {
    $presentation = new Presentation("sample.pptx", $options);
    try {
        $token->throwIfInterruptionRequested();
        $presentation->save("sample.pdf", SaveFormat::Pdf);
        $token->throwIfInterruptionRequested();
        echo "Conversion completed\n";
    } finally {
        $presentation->dispose();
    }
} catch (JavaException $error) {
    if (!java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
        throw $error;
    }
    echo "Conversion canceled\n";
} finally {
    $timer->cancel();
}
```

## **Διακοπή πριν την επεξεργασία της επόμενης διαφάνειας**

Ελέγξτε το [InterruptionToken::isInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#isInterruptionRequested) πριν από κάθε εξαγωγή. Η υπερφόρτωση του [Presentation::save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save) για επιλεγμένες διαφάνειες δέχεται αριθμούς διαφανειών που ξεκινούν από το 1. Περάστε έναν μονοστοιχειώδη πίνακα για να δημιουργήσετε ξεχωριστό PDF για κάθε διαφάνεια.

Χρησιμοποιήστε ένα `sample.pptx` με τουλάχιστον δύο διαφάνειες. Για να δείξετε την ακύρωση μεταξύ των εξαγωγών, το παράδειγμα το ζητά αμέσως μετά την καταγραφή της πρώτης διαφάνειας.

```php
use aspose\slides\InterruptionTokenSource;
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function exportSlides($path, $source) {
    $completed = [];
    $token = $source->getToken();
    $options = new LoadOptions();
    $options->setInterruptionToken($token);
    $presentation = new Presentation($path, $options);
    try {
        $count = java_values($presentation->getSlides()->size());
        for ($number = 1; $number <= $count; $number++) {
            if (java_values($token->isInterruptionRequested())) {
                break;
            }

            try {
                $presentation->save("slide-$number.pdf", [$number], SaveFormat::Pdf);
                $token->throwIfInterruptionRequested();
            } catch (JavaException $error) {
                if (java_instanceof($error->getCause(), java("com.aspose.slides.exceptions.OperationCanceledException"))) {
                    break;
                }
                throw $error;
            }

            $completed[] = $number;
            if ($number === 1) {
                $source->interrupt();
            }
        }
        return $completed;
    } finally {
        $presentation->dispose();
    }
}

$source = new InterruptionTokenSource();
$completed = exportSlides("sample.pptx", $source);
echo "Completed: " . json_encode($completed) . "\n";
```

Το παράδειγμα δημιουργεί το `slide-1.pdf` και εκτυπώνει `Completed: [1]`. Η δεύτερη επανάληψη βλέπει το αίτημα πριν ξεκινήσει άλλη εξαγωγή. Εάν η ακύρωση συμβεί κατά την αποθήκευση, η λίστα περιέχει μόνο τις προηγούμενες επιβεβαιωμένες εξαγωγές. Μια διακοπείσα αποθήκευση μπορεί να αφήσει ένα άσυλο αρχείο στον δίσκο.

Για να μεταβιβάσετε την ακύρωση στον καλούντα, αντικαταστήστε τον έλεγχο στην αρχή του βρόχου με `$token->throwIfInterruptionRequested();` και αφαιρέστε το εσωτερικό `try`/`catch`, διατηρώντας την αποθήκευση και τον έλεγχο που το ακολουθεί. Με τα ίδια δεδομένα, το [InterruptionToken::throwIfInterruptionRequested](https://reference.aspose.com/slides/php-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) ρίχνει εξαίρεση πριν από τη διαφάνεια 2 και ο καλών δεν λαμβάνει λίστα.

## **Συχνές ερωτήσεις**

**Πότε πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν λήξει μια προθεσμία ή όταν ο καλούντας δεν χρειάζεται πλέον το αποτέλεσμα. Ένα αίτημα που γίνει μετά το τέλος μιας λειτουργίας αφήνει το αποτέλεσμα αμετάβλητο.

**Πώς διαφέρουν η πηγή και το token;**

Η πηγή επιτρέπει σε μια εφαρμογή να ζητήσει ακύρωση. Το token επιτρέπει στο Aspose.Slides και στον κώδικα της εφαρμογής να παρατηρήσουν αυτό το αίτημα.

**Μπορούν πολλαπλές λειτουργίες να μοιράζονται μια πηγή;**

Ναι. Ένα αίτημα ισχύει για όλες τις λειτουργίες που χρησιμοποιούν tokens από αυτήν την πηγή. Δημιουργήστε ξεχωριστές πηγές για λειτουργίες που απαιτούν ανεξάρτητη ακύρωση.