---
title: "Διακοπή Μακροχρόνιων Λειτουργιών Παρουσίασης σε Python"
linktitle: "Διακοπή Λειτουργιών Παρουσίασης"
type: docs
weight: 150
url: /el/python-net/support-for-interruptable-library/
keywords:
- "λειτουργίες με δυνατότητα διακοπής"
- "διακριτικό διακοπής"
- "ακύρωση εξαγωγής PDF"
- PowerPoint
- Python
- Aspose.Slides
description: "Μάθετε πώς να ακυρώσετε μια μετατροπή παρουσίασης σε Python και να επιστρέψετε τη λίστα των διαφανειών που ολοκλήρωσαν την εξαγωγή πριν από την ακύρωση."
---
## **Επισκόπηση**

Το Aspose.Slides for Python μέσω .NET υποστηρίζει συνεργατική ακύρωση κατά τη διάρκεια μακροχρόνιων λειτουργιών όπως η φόρτωση, η αποθήκευση και η απόδοση παρουσιάσεων. Όταν εξάγετε διαφάνειες μεμονωμένα, μπορείτε επίσης να ελέγχετε για ακύρωση μεταξύ των διαφανειών και να επιστρέφετε τους αριθμούς των διαφανειών που ολοκλήρωσαν την εξαγωγή.

## **Ακύρωση Μετατροπής Παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/), αντιστοιχίστε το [token](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/token/) στο [LoadOptions.interruption_token](https://reference.aspose.com/slides/python-net/aspose.slides/loadoptions/interruption_token/), και περάστε τις επιλογές στον [Presentation constructor](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/__init__/). Το token ισχύει για την παρουσίαση καθ' όλη τη διάρκεια ζωής της. Για να ζητήσετε ακύρωση από την εφαρμογή σας, καλέστε το [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontokensource/interrupt/).

Το παράδειγμα μετατρέπει το `sample.pptx` σε `sample.pdf`. Ένα [threading.Timer](https://docs.python.org/3/library/threading.html#threading.Timer) καλεί το `source.interrupt` μετά από 20 δευτερόλεπτα. Η εκκίνηση του χρονομετρητή πριν το άνοιγμα του αρχείου κάνει το όριο χρόνου να ισχύει τόσο για τη φόρτωση όσο και για την αποθήκευση. Μια εφαρμογή με κουμπί Ακύρωση μπορεί να κληθεί την ίδια μέθοδο από τον διαχειριστή συμβάντων της.

```python
from threading import Timer

import aspose.slides as slides

source = slides.InterruptionTokenSource()
options = slides.LoadOptions()
options.interruption_token = source.token
timer = Timer(20, source.interrupt)

timer.start()
try:
    with slides.Presentation("sample.pptx", options) as presentation:
        options.interruption_token.throw_if_interruption_requested()
        presentation.save("sample.pdf", slides.export.SaveFormat.PDF)
finally:
    timer.cancel()
    timer.join()
```

Ο σαφής έλεγχος μετά τη φόρτωση παραλείπει την εξαγωγή εάν το χρονικό όριο έχει ήδη λήξει. Εάν η φόρτωση ή η αποθήκευση παρατηρήσει το αίτημα, η εξαίρεση ακύρωσης φτάνει στον καλούντα. Μια αποθήκευση μπορεί επίσης να ολοκληρωθεί πριν την παρατηρήσει, οπότε το PDF είναι πλήρες.

## **Διακοπή Πριν Από την Επεξεργασία της Επόμενης Διαφάνειας**

Ελέγξτε το [InterruptionToken.is_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/is_interruption_requested/) πριν από κάθε εξαγωγή. Το [Presentation.save](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/save/) δέχεται μια λίστα αριθμών διαφανειών που ξεκινούν από το 1. Προσθέστε έναν αριθμό στη λίστα ολοκληρωμένων μόνο αφού το PDF του αποθηκευτεί επιτυχώς.

Χρησιμοποιήστε ένα αρχείο με όνομα `sample.pptx` που περιέχει τουλάχιστον δύο διαφάνειες. Για να είναι το αποτέλεσμα επαναλήψιμο, το παράδειγμα ζητά ακύρωση αμέσως μόλις ολοκληρωθεί η διαφάνεια 1. Σε μια εφαρμογή, το αίτημα μπορεί να προέλθει από άλλο νήμα ενώ μια διαφάνεια αποθηκεύεται.

```python
import aspose.slides as slides


def export_slides(path, source):
    completed = []
    token = source.token
    options = slides.LoadOptions()
    options.interruption_token = token

    with slides.Presentation(path, options) as presentation:
        for number in range(1, len(presentation.slides) + 1):
            if token.is_interruption_requested:
                break

            print(f"Starting slide {number}")
            try:
                presentation.save(f"slide-{number}.pdf", [number], slides.export.SaveFormat.PDF)
            except slides.AsposeSlidesException as error:
                if token.is_interruption_requested and "System.OperationCanceledException" in str(error):
                    break
                raise

            completed.append(number)
            if number == 1:
                source.interrupt()

    return completed


source = slides.InterruptionTokenSource()
completed = export_slides("sample.pptx", source)
print(f"Completed: {completed}")
```

Το παράδειγμα γράφει το `slide-1.pdf` και εκτυπώνει `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Η επόμενη επανάληψη βλέπουν το αίτημα πριν ξεκινήσει η διαφάνεια 2. Εάν η ακύρωση διακόψει μια αποθήκευση, ο διαχειριστής εξαιρέσεων επιστρέφει τους αριθμούς που καταγράφηκαν από προηγούμενες επαναλήψεις. Άλλα σφάλματα εξαγωγής φτάνουν στον καλούντα.

Εάν ο καλών πρέπει να διαχειριστεί την ακύρωση ως εξαίρεση, αντικαταστήστε τον έλεγχο και το `break` στην αρχή του βρόχου με το [token.throw_if_interruption_requested](https://reference.aspose.com/slides/python-net/aspose.slides/interruptiontoken/throw_if_interruption_requested/). Επίσης αφαιρέστε το `try`/`except` γύρω από την αποθήκευση. Με τα ίδια δεδομένα εισόδου, η διαφάνεια 1 αποθηκεύεται και η δεύτερη επανάληψη προκαλεί μια εξαίρεση ακύρωσης πριν ξεκινήσει η διαφάνεια 2.

## **Συχνές Ερωτήσεις**

**Πότε ένα αίτημα ακύρωσης τίθεται σε ισχύ?**

Μια διακόψιμη λειτουργία ελέγχει το token της περιοδικά. Σταματά όταν παρατηρήσει το αίτημα. Μια λειτουργία που έχει ήδη ολοκληρωθεί διατηρεί το αποτέλεσμα της.

**Ποια είναι η διαφορά μεταξύ της πηγής και του token;**

Η πηγή επιτρέπει στην εφαρμογή σας να ζητήσει ακύρωση. Το token επιτρέπει τόσο στην παρουσίαση όσο και στον δικό σας κώδικα να ελέγχουν για αυτό το αίτημα.

**Μπορούν πολλές λειτουργίες να μοιράζονται την ίδια πηγή;**

Ναι. Η κλήση του `interrupt` ζητά ακύρωση για κάθε λειτουργία που χρησιμοποιεί ένα token από αυτήν την πηγή. Δώστε σε κάθε λειτουργία τη δική της πηγή αν χρειάζεται να την ακυρώσετε ανεξάρτητα.