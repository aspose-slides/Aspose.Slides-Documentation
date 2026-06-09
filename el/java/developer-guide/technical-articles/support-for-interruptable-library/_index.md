---
title: Υποστήριξη για τη Διακόψιμη βιβλιοθήκη
type: docs
weight: 120
url: /el/java/support-for-interruptable-library/
keywords:
- διακόψιμη βιβλιοθήκη
- token διακοπής
- token ακύρωσης
- μακροχρόνια εργασία
- εργασία διακοπής
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Καθιστά τις μακροχρόνιες εργασίες ακυρώσιμες με το Aspose.Slides για Java. Διακόπτετε με ασφάλεια την απόδοση και τις μετατροπές για PowerPoint και OpenDocument, με παραδείγματα."
---
## **Επισκόπηση**

Aspose.Slides παρέχει έναν μη διακοπτόμενο μηχανισμό επεξεργασίας για μακροχρόνιες εργασίες παρουσίασης, όπως αποσειροποίηση, σειροποίηση και απόδοση. Αυτός ο μηχανισμός βασίζεται στις κλάσεις `InterruptionToken` και `InterruptionTokenSource`.

Ένα `InterruptionToken` μπορεί να εκχωρηθεί στο `LoadOptions` και να περαστεί στον κατασκευαστή `Presentation`. Όταν κληθεί το `InterruptionTokenSource.interrupt()`, η σχετική μακροχρόνια εργασία διακόπτεται.

## **Διακόψιμη βιβλιοθήκη**

Στο [Aspose.Slides 18.4](https://releases.aspose.com/slides/el/java/release-notes/2018/aspose-slides-for-java-18-4-release-notes/), εισάγαμε τις κλάσεις [InterruptionToken](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontoken/) και [InterruptionTokenSource](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/). Σας επιτρέπουν να διακόπτετε μακροχρόνιες εργασίες όπως αποσειροποίηση, σειροποίηση και απόδοση.

- [InterruptionTokenSource](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/) είναι η πηγή των token(s) που περνιούνται στο [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-).
- Όταν ο [ILoadOptions.setInterruptionToken](https://reference.aspose.com/slides/el/java/com.aspose.slides/iloadoptions/#setInterruptionToken-com.aspose.slides.IInterruptionToken-) ορίζεται και το αντικείμενο [LoadOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/loadoptions/) περνιέται στον κατασκευαστή [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), η κλήση του [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/#interrupt--) διακόπτει οποιαδήποτε μακροχρόνια εργασία που σχετίζεται με αυτό το [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/).

```java
final InterruptionTokenSource tokenSource = new InterruptionTokenSource();

Runnable interruption = new Runnable() {
    public void run() {
        LoadOptions loadOptions = new LoadOptions();
        loadOptions.setInterruptionToken(tokenSource.getToken());

        Presentation presentation = new Presentation("sample.pptx", loadOptions);
        try{
            presentation.save("sample.ppt", SaveFormat.Ppt);
        }
        finally {
            presentation.dispose();
        }
    }
};

Thread thread = new Thread(interruption);
thread.start();          // εκτελέστε τη δράση σε ξεχωριστό νήμα
Thread.sleep(10000);     // χρονικό όριο
tokenSource.interrupt(); // διακόψτε τη μετατροπή
```

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Ποιος είναι ο σκοπός της βιβλιοθήκης διακοπής του Aspose.Slides;**

Παρέχει έναν μηχανισμό για τη διακοπή μακροχρόνιων λειτουργιών — όπως η φόρτωση, η αποθήκευση ή η απόδοση παρουσιάσεων — προτού ολοκληρωθούν. Αυτό είναι χρήσιμο όταν πρέπει να περιοριστεί ο χρόνος επεξεργασίας ή όταν η εργασία δεν χρειάζεται πια.

**Ποια είναι η διαφορά μεταξύ του [InterruptionToken](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontoken/) και του [InterruptionTokenSource](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/);**

- `InterruptionToken` περνιέται στο API του Aspose.Slides και ελέγχεται κατά τη διάρκεια των μακροχρόνιων λειτουργιών.
- `InterruptionTokenSource` χρησιμοποιείται στον κώδικά σας για τη δημιουργία tokens και την έναυση διακοπών καλώντας `Interrupt()`.

**Ποιες εργασίες μπορούν να διακοπούν;**

Οποιαδήποτε εργασία Aspose.Slides που δέχεται ένα [InterruptionToken](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontoken/) — όπως η φόρτωση μιας παρουσίασης με `Presentation(path, loadOptions)` ή η αποθήκευση με `Presentation.save(...)` — μπορεί να διακοπεί.

**Συμβαίνει η διακοπή άμεσα;**

Όχι. Η διακοπή είναι συνεργατική: η λειτουργία ελέγχει περιοδικά το token και σταματά αμέσως μόλις εντοπίσει ότι το [Interrupt()](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/#interrupt--) έχει κληθεί.

**Τι συμβαίνει αν καλέσω το [Interrupt()](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/#interrupt--) μετά την ολοκλήρωση μιας εργασίας;**

Τίποτα — η κλήση δεν έχει καμία επίδραση εάν η αντίστοιχη εργασία έχει ήδη ολοκληρωθεί.

**Μπορώ να επαναχρησιμοποιήσω το ίδιο [InterruptionTokenSource](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/) για πολλαπλές εργασίες;**

Ναι — αλλά αφού καλέσετε το [Interrupt()](https://reference.aspose.com/slides/el/java/com.aspose.slides/interruptiontokensource/#interrupt--) σε αυτήν την πηγή, όλες οι εργασίες που χρησιμοποιούν τα tokens της θα διακοπούν. Χρησιμοποιήστε ξεχωριστές πηγές token για να διαχειριστείτε τις εργασίες ανεξάρτητα.