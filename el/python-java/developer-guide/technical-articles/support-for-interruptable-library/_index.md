---
title: Υποστήριξη για Βιβλιοθήκη με Δυνατότητα Διακοπής
type: docs
weight: 120
url: /el/python-java/support-for-interruptable-library/
keywords:
- βιβλιοθήκη με δυνατότητα διακοπής
- διακριτικό διακοπής
- διακριτικό ακύρωσης
- εργασία μεγάλης διάρκειας
- διακοπή εργασίας
- PowerPoint
- OpenDocument
- παρουσίαση
- Python
- Java
- Aspose.Slides
description: "Καθιστά τις εργασίες μεγάλης διάρκειας ακυρώσιμες με το Aspose.Slides για Python μέσω Java. Διακόψτε την απόδοση και τις μετατροπές για PowerPoint και OpenDocument με ασφάλεια, με παραδείγματα."
---
## **Επισκόπηση**

Το Aspose.Slides παρέχει έναν μηχανισμό επεξεργασίας με δυνατότητα διακοπής για ενέργειες παρουσίασης μεγάλης διάρκειας, όπως απο-σειριοποίηση, σειριοποίηση και απόδοση. Αυτός ο μηχανισμός βασίζεται στις κλάσεις [InterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/).

Ένα [InterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontoken/) μπορεί να εκχωρηθεί στο [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/) και να περαστεί στον κατασκευαστή της [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/). Όταν κληθεί η μέθοδος [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/#interrupt), η συσχετισμένη εργασία μεγάλης διάρκειας διακόπτεται.

## **Βιβλιοθήκη με Δυνατότητα Διακοπής**

Το Aspose.Slides for Python via Java παρέχει τις κλάσεις [InterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/). Επιτρέπουν τη διακοπή εργασιών μεγάλης διάρκειας όπως απο-σειριοποίηση, σειριοποίηση και απόδοση.

- Το [InterruptionTokenSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/) είναι η πηγή του (των) token(s) που περνιούνται στο [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setInterruptionToken).
- Όταν κληθεί το [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/#setInterruptionToken) και το αντίστοιχο αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/python-java/aspose.slides/loadoptions/) περαστεί στον κατασκευαστή της [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/), η κλήση του [InterruptionTokenSource.interrupt](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/#interrupt) διακόπτει οποιαδήποτε εργασία μεγάλης διάρκειας που σχετίζεται με εκείνη τη [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/).

Το παρακάτω απόσπασμα κώδικα δείχνει πώς να διακόψετε μια εκτελούμενη εργασία:

```python
from concurrent.futures import ThreadPoolExecutor
import time

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import InterruptionTokenSource, LoadOptions, Presentation, SaveFormat


token_source = InterruptionTokenSource()


def convert_presentation():
    load_options = LoadOptions()
    load_options.setInterruptionToken(token_source.getToken())

    presentation = Presentation("sample.pptx", load_options)
    try:
        presentation.save("sample.ppt", SaveFormat.Ppt)
    finally:
        presentation.dispose()


with ThreadPoolExecutor(max_workers=1) as executor:
    conversion_task = executor.submit(convert_presentation)  # Εκτελέστε τη δράση σε ξεχωριστό νήμα.
    time.sleep(10)  # Λήξη χρονικού ορίου.
    token_source.interrupt()  # Διακοπή της μετατροπής.
    conversion_task.result()
```

## **Συχνές Ερωτήσεις**

**Ποιος είναι ο σκοπός της βιβλιοθήκης διακοπής του Aspose.Slides;**

Παρέχει έναν μηχανισμό για τη διακοπή λειτουργιών μεγάλης διάρκειας — όπως η φόρτωση, η αποθήκευση ή η απόδοση παρουσιάσεων — προτού ολοκληρωθούν. Αυτό είναι χρήσιμο όταν ο χρόνος επεξεργασίας πρέπει να περιοριστεί ή η εργασία δεν χρειάζεται πλέον.

**Ποια είναι η διαφορά μεταξύ [InterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/);**

- Το [InterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontoken/) περνιέται στο API του Aspose.Slides και ελέγχεται κατά τη διάρκεια λειτουργιών μεγάλης διάρκειας.
- Το [InterruptionTokenSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/) χρησιμοποιείται στον κώδικά σας για τη δημιουργία token και την ενεργοποίηση διακοπών καλώντας τη μέθοδο [interrupt](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/#interrupt).

**Ποιες εργασίες μπορούν να διακοπούν;**

Οποιαδήποτε εργασία του Aspose.Slides που δέχεται ένα [InterruptionToken](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontoken/) — όπως η φόρτωση μιας παρουσίασης με τη [Presentation](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/) ή η αποθήκευση με τη [Presentation.save](https://reference.aspose.com/slides/el/python-java/aspose.slides/presentation/#save) — μπορεί να διακοπεί.

**Συμβαίνει η διακοπή αμέσως;**

Όχι. Η διακοπή είναι συνεργατική: η λειτουργία ελέγχει περιοδικά το token και σταματά αμέσως μόλις διαπιστώσει ότι το [interrupt](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/#interrupt) έχει κληθεί.

**Τι συμβαίνει αν καλέσω το [interrupt](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/#interrupt) αφού η εργασία έχει ήδη ολοκληρωθεί;**

Τίποτα — η κλήση δεν έχει καμία επίδραση αν η αντίστοιχη εργασία έχει ήδη τελειώσει.

**Μπορώ να ξαναχρησιμοποιήσω το ίδιο [InterruptionTokenSource](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/) για πολλές εργασίες;**

Ναι — αλλά αφού καλέσετε το [interrupt](https://reference.aspose.com/slides/el/python-java/aspose.slides/interruptiontokensource/#interrupt) σε αυτήν την πηγή, όλες οι εργασίες που χρησιμοποιούν τα tokens της θα διακοπούν. Χρησιμοποιήστε ξεχωριστές πηγές token για ανεξάρτητη διαχείριση των εργασιών.