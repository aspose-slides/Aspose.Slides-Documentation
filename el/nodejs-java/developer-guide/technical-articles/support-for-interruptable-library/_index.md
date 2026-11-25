---
title: Διακοπή λειτουργιών παρουσίασης μεγάλης διάρκειας σε Node.js
linktitle: Διακοπή λειτουργιών παρουσίασης
type: docs
weight: 120
url: /el/nodejs-java/support-for-interruptable-library/
keywords:
- λειτουργίες διακοπής
- διακριτικό διακοπής
- διακριτικό ακύρωσης
- χρονικό όριο μετατροπής
- PowerPoint
- OpenDocument
- Node.js
- JavaScript
- Aspose.Slides
description: "Ακυρώστε λειτουργίες παρουσίασης μεγάλης διάρκειας στο Aspose.Slides για Node.js μέσω Java, ορίστε χρονικό όριο μετατροπής και παρακολουθήστε τις διαφάνειες που εξάχθηκαν πριν από την ακύρωση."
---
## **Επισκόπηση**

Το Aspose.Slides για Node.js μέσω Java υποστηρίζει την ακύρωση κατά τη φόρτωση, αποθήκευση ή απόδοση μιας παρουσίασης. Μπορείτε επίσης να ελέγχετε το ίδιο διακριτικό στον δικό σας βρόχο εξαγωγής για να σταματήσετε πριν από την επόμενη διαφάνεια και να επιστρέψετε τους αριθμούς των διαφανειών που έχουν ήδη αποθηκευτεί.

## **Διακοπή λειτουργίας παρουσίασης**

Δημιουργήστε ένα [InterruptionTokenSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/), αποκτήστε το διακριτικό του με [getToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#getToken) και περάστε το στο [LoadOptions.setInterruptionToken](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadoptions/#setInterruptionToken). Χρησιμοποιήστε αυτές τις επιλογές όταν δημιουργείτε το [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/). Καλώντας [interrupt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontokensource/#interrupt) στην πηγή ζητάται η ακύρωση της τρέχουσας λειτουργίας. Το Aspose.Slides σταματά όταν ελέγξει ξανά το διακριτικό.

### **Ορισμός χρονικού ορίου μετατροπής**

Το παρακάτω παράδειγμα επιτρέπει 20 δευτερόλεπτα για το άνοιγμα του `sample.pptx` και την αποθήκευσή του ως `sample.pdf`. Τanto ο κατασκευαστής όσο και η αποθήκευση εκτελούνται ασύγχρονα μέσω της γέφυρας Java, ώστε ο χρονοδιακόπτης Node.js να μπορεί να ενεργοποιηθεί κατά τη διάρκεια οποιασδήποτε λειτουργίας. Το παράδειγμα ελέγχει το διακριτικό μετά τη φόρτωση και ξανά μετά την αποθήκευση, επειδή μια κλήση βιβλιοθήκης μπορεί να επιστρέψει μετά από αίτηση ακύρωσης. Απελευθερώνει την παρουσίαση όταν η λειτουργία ολοκληρωθεί και καθαρίζει τον χρονοδιακόπτη εάν η μετατροπή ολοκληρωθεί νωρίτερα. Εάν γίνει ακύρωση κατά τη διάρκεια μιας αποθήκευσης, το αρχείο εξόδου μπορεί να υπάρχει ήδη και να είναι ελλιπές.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");
const { promisify } = require("node:util");

async function convertWithTimeout(inputPath, outputPath, format, timeoutMs) {
    const source = new slides.InterruptionTokenSource();
    const options = new slides.LoadOptions();
    const token = source.getToken();
    options.setInterruptionToken(token);
    const createInstance = promisify(java.newInstance.bind(java));
    const timer = setTimeout(() => source.interrupt(), timeoutMs);
    let presentation = null;
    try {
        presentation = await createInstance("com.aspose.slides.Presentation", inputPath, options);
        token.throwIfInterruptionRequested();
        const save = promisify(presentation.saveAsync.bind(presentation));
        await save(outputPath, format);
        token.throwIfInterruptionRequested();
        console.log("Conversion completed");
    } catch (error) {
        if (error.cause?.getClass().getName() !== "com.aspose.slides.exceptions.OperationCanceledException") {
            throw error;
        }
        console.log("Conversion canceled");
    } finally {
        clearTimeout(timer);
        if (presentation) {
            presentation.dispose();
        }
    }
}

convertWithTimeout("sample.pptx", "sample.pdf", slides.SaveFormat.Pdf, 20000).catch(error => {
    console.error(error);
    process.exitCode = 1;
});
```

Για να μετατρέψετε στην παλαιότερη μορφή PowerPoint με όριο 10 δευτερολέπτων, περάστε το `"sample.ppt"`, `slides.SaveFormat.Ppt` και `10000` ως τα τρία τελευταία ορίσματα.

## **Σταματήστε πριν την επεξεργασία της επόμενης διαφάνειας**

Χρησιμοποιήστε το [isInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#isInterruptionRequested) πριν από κάθε εξαγωγή όταν ο καλών μπορεί να χρησιμοποιήσει μερικό αποτέλεσμα. Η υπερφόρτωση του [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) για επιλεγμένες διαφάνειες δέχεται έναν Java `int[]` με αριθμούς διαφανειών που ξεκινούν από το 1. Καταγράψτε κάθε αριθμό μόνο αφού το PDF της αποθηκευτεί επιτυχώς.

Εκτελέστε το παράδειγμα με μια παρουσίαση με όνομα `sample.pptx` που περιέχει τουλάχιστον δύο διαφάνειες. Για να επιδείξετε την ακύρωση μεταξύ εξαγώσεων, το παράδειγμα τη ζητά αμέσως μετά την αποθήκευση της πρώτης διαφάνειας.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function exportSlides(path, source) {
    const completed = [];
    const token = source.getToken();
    const options = new slides.LoadOptions();
    options.setInterruptionToken(token);
    const presentation = new slides.Presentation(path, options);
    try {
        const count = presentation.getSlides().size();
        for (let number = 1; number <= count; number++) {
            if (token.isInterruptionRequested()) {
                break;
            }

            console.log("Starting slide " + number);
            const selection = java.newArray("int", [number]);
            try {
                presentation.save("slide-" + number + ".pdf", selection, slides.SaveFormat.Pdf);
            } catch (error) {
                if (error.cause?.getClass().getName() === "com.aspose.slides.exceptions.OperationCanceledException") {
                    break;
                }
                throw error;
            }

            if (token.isInterruptionRequested()) {
                break;
            }
            completed.push(number);
            if (number === 1) {
                source.interrupt();
            }
        }
        return completed;
    } finally {
        presentation.dispose();
    }
}

const source = new slides.InterruptionTokenSource();
const completed = exportSlides("sample.pptx", source);
console.log("Completed: " + JSON.stringify(completed));
```

Το παράδειγμα γράφει το `slide-1.pdf` και εκτυπώνει `Starting slide 1` ακολουθούμενο από `Completed: [1]`. Ο βρόχος παρατηρεί την ακύρωση πριν ξεκινήσει η διαφάνεια 2. Εάν η ίδια η αποθήκευση διακοπεί, η επιστρεφόμενη λίστα περιέχει μόνο τις προηγούμενες επιτυχείς εξαγωγές.

Για να επιτρέψετε στον καλούντα να χειριστεί την ακύρωση ως σφάλμα, αντικαταστήστε τον έλεγχο και το `break` στην αρχή του βρόχου με το [throwIfInterruptionRequested](https://reference.aspose.com/slides/nodejs-java/aspose.slides/interruptiontoken/#throwIfInterruptionRequested), που καλείται ως `token.throwIfInterruptionRequested()`. Χρησιμοποιήστε τον ίδιο έλεγχο ρίψης μετά την αποθήκευση και αφαιρέστε το `try`/`catch` γύρω του. Με την ίδια είσοδο, το πρώτο PDF γράφεται ακόμη, και η δεύτερη επανάληψη ρίχνει εξαίρεση πριν η συνάρτηση μπορέσει να επιστρέψει λίστα.

## **FAQ**

**Πότε πρέπει να ζητήσω ακύρωση;**

Ζητήστε ακύρωση όταν λήξει μια προθεσμία ή όταν η εφαρμογή δεν χρειάζεται πλέον το αποτέλεσμα. Η φόρτωση, η αποθήκευση και η απόδοση μπορούν όλες να χρησιμοποιήσουν το διακριτικό που περνιέται στην παρουσίαση κατά την κατασκευή.

**Πώς διαφέρουν η πηγή και το διακριτικό;**

Η πηγή επιτρέπει στην εφαρμογή να ζητήσει ακύρωση. Το διακριτικό επιτρέπει στο Aspose.Slides και στον κώδικά σας να ελέγχουν για αυτήν την αίτηση.

**Μπορεί ένας χρονοδιακόπτης Node.js να διακόψει μια συγχρονική αποθήκευση;**

Μια συγχρονική αποθήκευση αποκλείει τη JavaScript στο νήμα που καλείται. Χρησιμοποιήστε τις ασύγχρονες κλήσεις της γέφυρας Java που φαίνονται στο παράδειγμα χρονικού ορίου, ώστε ο χρονοδιακόπτης να μπορεί να ζητήσει ακύρωση ενώ η αποθήκευση εκτελείται.

**Η ακύρωση έχει άμεση ισχύ;**

Η ακύρωση είναι συνεργατική. Μια λειτουργία που εκτελείται σταματά όταν παρατηρήσει το αίτημα. Μια λειτουργία που έχει ήδη ολοκληρωθεί διατηρεί το αποτέλεσμα της.

**Μπορούν πολλαπλές λειτουργίες να μοιράζονται μια πηγή;**

Ναι. Καλώντας το `interrupt()` ζητάται ακύρωση για κάθε λειτουργία που χρησιμοποιεί ένα διακριτικό από αυτήν την πηγή. Χρησιμοποιήστε ξεχωριστή πηγή για κάθε λειτουργία που θέλετε να ακυρώσετε ανεξάρτητα.