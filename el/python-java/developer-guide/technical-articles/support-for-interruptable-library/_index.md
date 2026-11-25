---
title: Διακοπή μακροχρόνιων λειτουργιών παρουσίασης σε Python
linktitle: Διακοπή λειτουργιών παρουσίασης
type: docs
weight: 120
url: /el/python-java/support-for-interruptable-library/
keywords:
- λειτουργίες με δυνατότητα διακοπής
- token διακοπής
- token ακύρωσης
- μακροχρόνια εργασία
- διακοπή εργασίας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Μάθετε πώς να ακυρώνετε μακροχρόνιες λειτουργίες παρουσίασης στο Aspose.Slides για Python μέσω Java και να επιστρέφετε μερικό αποτέλεσμα κατά την εξαγωγή διαφάνειων σε βρόχο."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω Java μπορεί να διακόψει μακροχρόνιες λειτουργίες, όπως η φόρτωση, η αποθήκευση και η απόδοση παρουσιάσεων. Η εφαρμογή σας μπορεί να χρησιμοποιήσει το ίδιο token διακοπής για να σταματήσει έναν βρόχο πριν αρχίσει η επεξεργασία της επόμενης διαφάνειας.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/), λάβετε το token του με [getToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#getToken), και περάστε το token στο [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Περάστε τις επιλογές φόρτωσης στον [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/). Για να ζητήσετε ακύρωση, καλέστε το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) στην πηγή. Μια διακοπτόμενη λειτουργία σταματά όταν παρατηρήσει το αίτημα. Χρησιμοποιήστε `jpype.JClass` για να πιάσετε την εξαίρεση Java `com.aspose.slides.exceptions.OperationCanceledException` στην Python.

Το παράδειγμα μετατρέπει το `sample.pptx` σε `sample.ppt` σε ένα νήμα στο παρασκήνιο. Το νήμα που καλεί περιμένει έως 10 δευτερόλεπτα για να ολοκληρωθεί η μετατροπή. Αν η μετατροπή συνεχίζει να εκτελείται, ζητά ακύρωση και περιμένει το νήμα εργασίας να τερματιστεί.

```python
from concurrent.futures import ThreadPoolExecutor, TimeoutError

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def convert_presentation(source):
    options = LoadOptions()
    options.setInterruptionToken(source.getToken())
    try:
        presentation = Presentation("sample.pptx", options)
        try:
            presentation.save("sample.ppt", SaveFormat.Ppt)
        finally:
            presentation.dispose()
    except OperationCanceledException:
        print("Conversion canceled")


source = InterruptionTokenSource()
with ThreadPoolExecutor(max_workers=1) as executor:
    conversion = executor.submit(convert_presentation, source)
    try:
        conversion.result(timeout=10)
    except TimeoutError:
        source.interrupt()
        conversion.result()
```

## **Σύνδεση Χρονικού Ορίου Python με Aspose.Slides**

Για να ορίσετε χρονικό όριο σε μια λειτουργία παρουσίασης, χρησιμοποιήστε ένα [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) για να καλέσετε το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) όταν λήξει το χρονικό όριο. Το παράδειγμα επιτρέπει 20 δευτερόλεπτα για να φορτώσετε το `sample.pptx` και να το εξάγετε σε `sample.pdf`. Αν η εξαγωγή ολοκληρωθεί νωρίτερα, η εφαρμογή ακυρώνει το προγραμματισμένο αίτημα.

```python
from threading import Timer

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")

source = InterruptionTokenSource()
options = LoadOptions()
options.setInterruptionToken(source.getToken())

timer = Timer(20, source.interrupt)
timer.start()
try:
    presentation = Presentation("sample.pptx", options)
    try:
        presentation.save("sample.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
except OperationCanceledException:
    print("Presentation processing was canceled")
finally:
    timer.cancel()
    timer.join()
```

## **Διακοπή Πριν από την Επεξεργασία της Επόμενης Διαφάνειας**

Χρησιμοποιήστε το ίδιο [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) για την παρουσίαση και τον βρόχο που εξάγει τις διαφάνειές της. Ελέγξτε το [isInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#isInterruptionRequested) πριν από κάθε εξαγωγή. Εάν ο καλών μπορεί να χρησιμοποιήσει ένα μερικό αποτέλεσμα, επιστρέψτε τους αριθμούς διαφάνειας για τις εξαγωγές που ολοκληρώθηκαν επιτυχώς.

Χρησιμοποιήστε μια παρουσίαση με όνομα `sample.pptx` που περιέχει τουλάχιστον δύο διαφάνειες. Η υπερφόρτωση [Presentation.save](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#save) που δέχεται ένα Java `int[]` χρησιμοποιεί αριθμούς διαφάνειας ξεκινώντας από το 1. Χρησιμοποιήστε `jpype.JArray(jpype.JInt)` για να δημιουργήσετε αυτό το σύστημα σε Python. Το παράδειγμα αποθηκεύει κάθε διαφάνεια σε ξεχωριστό PDF και ζητά ακύρωση αμέσως μετά την καταγραφή της πρώτης επιτυχημένης εξαγωγής.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat

OperationCanceledException = jpype.JClass("com.aspose.slides.exceptions.OperationCanceledException")


def export_slides(path, source):
    completed = []
    token = source.getToken()
    options = LoadOptions()
    options.setInterruptionToken(token)
    presentation = Presentation(path, options)
    try:
        for number in range(1, presentation.getSlides().size() + 1):
            if token.isInterruptionRequested():
                break

            print(f"Starting slide {number}")
            slide_numbers = jpype.JArray(jpype.JInt)([number])
            try:
                presentation.save(f"slide-{number}.pdf", slide_numbers, SaveFormat.Pdf)
            except OperationCanceledException:
                if token.isInterruptionRequested():
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()
        return completed
    finally:
        presentation.dispose()


source = InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Το παράδειγμα γράφει το `slide-1.pdf` και εκτυπώνει το `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Ο βρόχος παρατηρεί το αίτημα πριν ξεκινήσει τη διαφάνεια 2. Αν η ακύρωση φτάσει κατά τη διάρκεια μιας αποθήκευσης, ο βρόχος εξέρχεται πριν καταγράψει αυτή τη διαφάνεια ως ολοκληρωμένη.

Εάν ο καλών χρειάζεται να χειριστεί την ακύρωση, αντικαταστήστε τον έλεγχο και το `break` στην αρχή του βρόχου με `token.throwIfInterruptionRequested()`. Αφαιρέστε το `try`/`except` γύρω από την αποθήκευση ώστε η ακύρωση κατά τη διάρκεια μιας εξαγωγής να φθάνει επίσης στον καλούντα. Με τα ίδια δεδομένα εισόδου, το παράδειγμα εκτυπώνει μόνο `Starting slide 1` και γράφει το `slide-1.pdf`. Στην αρχή της δεύτερης επανάληψης, το [throwIfInterruptionRequested](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested) προκαλεί εξαίρεση `com.aspose.slides.exceptions.OperationCanceledException` πριν ξεκινήσει η επόμενη εξαγωγή. Η εξαίρεση διαδίδεται στον καλούντα πριν η συνάρτηση μπορέσει να επιστρέψει τη λίστα.

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν μια λειτουργία υπερβαίνει το χρονικό όριο ή όταν η εφαρμογή σας δεν χρειάζεται πλέον το αποτέλεσμα.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/);**

Η πηγή επιτρέπει στην εφαρμογή σας να ζητήσει ακύρωση. Το token επιτρέπει στο Aspose.Slides και στην εφαρμογή σας να ελέγξουν αν έχει γίνει το αίτημα.

**Μπορώ να ακυρώσω μια λειτουργία από χρονοδιακόπτη Python;**

Ναι. Προγραμματίστε κλήση του [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) στην πηγή που σχετίζεται με την παρουσίαση.

**Ποιες λειτουργίες μπορώ να διακόψω;**

Μπορείτε να διακόψετε τη φόρτωση, την αποθήκευση και την απόδοση. Περάστε το token στον [Presentation constructor](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) μέσω του [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setInterruptionToken). Η παρουσίαση μπορεί τότε να παρατηρήσει την ακύρωση κατά τις επόμενες λειτουργίες, όπως η αποθήκευση σε PDF.

**Σταματάει η λειτουργία αμέσως;**

Η ακύρωση είναι συνεργατική. Μια λειτουργία ελέγχει το token περιοδικά και σταματά όταν παρατηρήσει το αίτημα.

**Τι συμβαίνει αν καλέσω το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) μετά το τέλος μιας λειτουργίας;**

Η ολοκληρωμένη λειτουργία διατηρεί το αποτέλεσμα της.

**Μπορούν πολλές λειτουργίες να μοιράζονται ένα [InterruptionTokenSource](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/);**

Ναι. Καλώντας το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-java/aspose.slides/interruptiontokensource/#interrupt) ζητάται ακύρωση για κάθε λειτουργία που χρησιμοποιεί token από αυτήν την πηγή. Χρησιμοποιήστε ξεχωριστή πηγή για κάθε λειτουργία που θέλετε να ακυρώσετε ανεξάρτητα.