---
title: Ανάκτηση και Ενημέρωση Πληροφοριών Παρουσίασης σε JavaScript
linktitle: Πληροφορίες Παρουσίασης
type: docs
weight: 30
url: /el/nodejs-java/examine-presentation/
keywords:
- μορφή παρουσίασης
- ιδιότητες παρουσίασης
- ιδιότητες εγγράφου
- λήψη ιδιοτήτων
- ανάγνωση ιδιοτήτων
- αλλαγή ιδιοτήτων
- τροποποίηση ιδιοτήτων
- ενημέρωση ιδιοτήτων
- εξέταση PPTX
- εξέταση PPT
- εξέταση ODP
- PowerPoint
- OpenDocument
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Εξερευνήστε τις διαφάνειες, τη δομή και τα μεταδεδομένα σε παρουσιάσεις PowerPoint και OpenDocument χρησιμοποιώντας JavaScript για πιο γρήγορες αναλύσεις και πιο έξυπνους ελέγχους περιεχομένου."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να εντοπίσει τη μορφή μιας παρουσίασης και να διαβάσει τα μεταδεδομένα του εγγράφου χωρίς να δημιουργήσει ένα πλήρες μοντέλο αντικειμένων παρουσίασης. Αυτό είναι χρήσιμο όταν χρειάζεται να ταξινομήσετε αρχεία, να δημιουργήσετε ένα απόθεμα ή να ελέγξετε τις ιδιότητες πριν αποφασίσετε αν θα φορτώσετε και θα επεξεργαστείτε το περιεχόμενο της παρουσίασης.

Αυτό το άρθρο δείχνει ελαφρύ έλεγχο μέσω του [PresentationFactory](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/) και του [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/), καθώς και στοχευμένες ενημερώσεις μέσω του [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/).

## **Έλεγχος Μορφής Παρουσίασης**

Αν ήδη έχετε φορτωμένη παρουσίαση, δείτε το [Καθορισμός της Αρχικής Μορφής Παρουσίασης](/slides/el/nodejs-java/detect-presentation-source-format/) για εντοπισμό μετά τη φόρτωση και τους περιορισμούς των παλαιών ροών PPT, PPS και POT.

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) για να ελέγξετε ένα αρχείο χωρίς να δημιουργήσετε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Η μέθοδος [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/getloadformat/) αναφέρει τη μορφή που εντοπίστηκε, όπως PPTX, PPT ή ODP.

```javascript
const aspose = require("aspose.slides.via.java");

const fileNames = ["pres.pptx", "pres.ppt", "pres.odp"];

for (const fileName of fileNames) {
    const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(fileName);
    const loadFormat = presentationInfo.getLoadFormat();
    let formatName = `Other (${loadFormat})`;

    if (loadFormat === aspose.LoadFormat.Pptx) {
        formatName = "PPTX";
    } else if (loadFormat === aspose.LoadFormat.Ppt) {
        formatName = "PPT";
    } else if (loadFormat === aspose.LoadFormat.Odp) {
        formatName = "ODP";
    }

    console.log(`${fileName}: ${formatName}`);
}
```

## **Δημιουργία Ελαφρού Αποθέματος Παρουσιάσεων**

Όταν επεξεργάζεστε πολλά αρχεία παρουσίασης, μπορεί να χρειάζεστε ένα συμπαγές απόθεμα για επικύρωση, ευρετηρίαση ή σύστημα διαχείρισης εγγράφων. Σε αυτή τη περίπτωση, χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) για να λάβετε ένα αντικείμενο [PresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/) και, στη συνέχεια, καλέστε το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) για να διαβάσετε τα μεταδεδομένα του εγγράφου. Αυτή η προσέγγιση δεν δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) ούτε απαιτεί να διασχίσετε το πλήρες μοντέλο αντικειμένων παρουσίασης.

Οι εκτεταμένες ιδιότητες που εκτίθενται από το [DocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/) παρέχουν τις ακόλουθες τιμές αποθέματος:

| Μέθοδος | Τιμή αποθέματος |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getSlides) | Συνολικός αριθμός διαφανειών. |
| [getHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) | Αριθμός κρυφών διαφανειών. |
| [getNotes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getNotes) | Αριθμός διαφανειών που περιέχουν σημειώσεις. |
| [getParagraphs](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getParagraphs) | Συνολικός αριθμός παραγράφων, όταν διατίθεται. |
| [getWords](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getWords) | Συνολικός αριθμός λέξεων. |
| [getMultimediaClips](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getMultimediaClips) | Συνολικός αριθμός ηχητικών και βίντεο κλιπ. |

Το παρακάτω παράδειγμα διαβάζει αυτές τις τιμές χωρίς να δημιουργεί ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) και εκτυπώνει ένα συμπαγές απόθεμα. Συνδυάζει επίσης το [DocumentProperties.getHeadingPairs](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getHeadingPairs) με το [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) για την εμφάνιση ομάδων περιεχομένου όπως γραμματοσειρές, θέματα και τίτλοι διαφανειών.

```javascript
const path = require("path");
const aspose = require("aspose.slides.via.java");

const filePath = "sample.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(filePath);
const documentProperties = presentationInfo.readDocumentProperties();

const loadFormat = presentationInfo.getLoadFormat();
let formatName = `Other (${loadFormat})`;

if (loadFormat === aspose.LoadFormat.Pptx) {
    formatName = "PPTX";
} else if (loadFormat === aspose.LoadFormat.Ppt) {
    formatName = "PPT";
} else if (loadFormat === aspose.LoadFormat.Odp) {
    formatName = "ODP";
}

console.log(`File: ${path.basename(filePath)}`);
console.log(`Format: ${formatName}`);
console.log(`Title: ${documentProperties.getTitle()}`);
console.log(`Author: ${documentProperties.getAuthor()}`);
console.log("Statistics:");
console.log(`  Slides: ${documentProperties.getSlides()}`);
console.log(`  Hidden slides: ${documentProperties.getHiddenSlides()}`);
console.log(`  Slides with notes: ${documentProperties.getNotes()}`);
console.log(`  Paragraphs: ${documentProperties.getParagraphs()}`);
console.log(`  Words: ${documentProperties.getWords()}`);
console.log(`  Multimedia clips: ${documentProperties.getMultimediaClips()}`);

const headingPairs = documentProperties.getHeadingPairs() || [];
const titlesOfParts = documentProperties.getTitlesOfParts() || [];
let partIndex = 0;

if (headingPairs.length === 0 || titlesOfParts.length === 0) {
    console.log("Content groups: not available");
} else {
    console.log("Content groups:");

    for (const headingPair of headingPairs) {
        const partCount = headingPair.getCount();
        console.log(`  ${headingPair.getName()} (${partCount})`);

        for (let partOffset = 0; partOffset < partCount && partIndex < titlesOfParts.length; partOffset++) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }

    if (partIndex < titlesOfParts.length) {
        console.log("  Other parts:");

        while (partIndex < titlesOfParts.length) {
            console.log(`    - ${titlesOfParts[partIndex]}`);
            partIndex++;
        }
    }
}
```

Κάθε [HeadingPair](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/headingpair/) παρέχει ένα όνομα ομάδας μέσω του [HeadingPair.getName](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/headingpair/#getName) και τον αριθμό των στοιχείων στην ομάδα μέσω του [HeadingPair.getCount](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/headingpair/#getCount). Το [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getTitlesOfParts) επιστρέφει έναν επίπεδο, διατεταγμένο πίνακα, οπότε χρησιμοποιήστε τον αριθμό των διαδοχικών τίτλων που καθορίζονται από κάθε ζεύγος επικεφαλίδων.

### **Αποθηκευμένα Μεταδεδομένα και Περιορισμοί Μορφής**

Οι ιδιότητες αποθέματος που επιστρέφει το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) αντικατοπτρίζουν τα μεταδεδομένα που είναι διαθέσιμα στο πηγαίο έγγραφο. Το Aspose.Slides δεν φορτώνει και δεν διασχίζει το μοντέλο αντικειμένων παρουσίασης για να επανυπολογίσει αυτές τις τιμές για αυτήν την κλήση. Οι ελλιπείς ιδιότητες αναπαριστώνται από προεπιλεγμένες τιμές και οι αποθηκευμένες τιμές μπορεί να είναι παλαιές εάν η εφαρμογή που αποθήκευσε τελευταία φορά το αρχείο δεν ενημέρωσε τις ιδιότητες του εγγράφου.

- **PPTX:** Η μορφή παρέχει εκτεταμένες ιδιότητες εγγράφου για αριθμούς διαφανειών, σημειώσεων, κρυφών διαφανειών, παραγράφων, λέξεων και πολυμέσων, καθώς και ζεύγη επικεφαλίδων και τίτλους τμημάτων. Η διαθεσιμότητα εξαρτάται από τις ιδιότητες που έγραψε ο δημιουργός του εγγράφου.
- **PPT:** Η δυαδική μορφή μπορεί να αποθηκεύσει αντίστοιχες ιδιότητες σύνοψης εγγράφου. Εάν μια ιδιότητα λείπει ή δεν έχει ενημερωθεί από τον δημιουργό του εγγράφου, το Aspose.Slides επιστρέφει την αποθηκευμένη ή προεπιλεγμένη τιμή αντί να την υπολογίσει από τις διαφάνειες.
- **ODP:** Τα μεταδεδομένα OpenDocument παρέχουν γενικά στατιστικά εγγράφου, όπως αριθμούς σελίδων, παραγράφων και λέξεων, αλλά αυτές οι τιμές δεν αντιστοιχούν σε κάθε εκτεταμένη ιδιότητα ειδική του PowerPoint. Οι μεταδεδομένα για κρυφές διαφάνειες, σημειώσεις, πολυμέσα, ζεύγη επικεφαλίδων και τίτλους τμημάτων μπορεί να μην είναι διαθέσιμα, και οι ιδιότητες αποθέματος μπορεί να επιστρέψουν προεπιλεγμένες τιμές. Μην θεωρείτε μηδενική τιμή ή κενό πίνακα ως απόδειξη ότι το αντίστοιχο περιεχόμενο λείπει.

Χρησιμοποιήστε την ελαφριά προσέγγιση μεταδεδομένων για αποθέματα και προκαταρκτικούς ελέγχους. Φορτώστε την παρουσίαση και ελέγξτε το ζωντανό μοντέλο αντικειμένων όταν το αποτέλεσμα πρέπει να αντικατοπτρίζει αλλαγές στη μνήμη ή όταν χρειάζεται να επαληθεύσετε το πραγματικό περιεχόμενο της παρουσίασης.

## **Ενημέρωση Ιδιοτήτων Παρουσίασης**

Οι ιδιότητες που επιστρέφει το [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/) μπορούν επίσης να αλλάξουν χωρίς τη δημιουργία ενός αντικειμένου [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/). Εφαρμόστε τις αλλαγές με το [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/updatedocumentproperties/) και, στη συνέχεια, γράψτε την σύνδεση παρουσίασης με το [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/writebindedpresentation/).

Η παρακάτω εικόνα δείχνει τις αρχικές ιδιότητες του εγγράφου της παρουσίασης PowerPoint.

![Αρχικές ιδιότητες εγγράφου της παρουσίασης PowerPoint](input_properties.png)

Το παρακάτω παράδειγμα αλλάζει τον τίτλο και την ώρα τελευταίας αποθήκευσης και γράφει το αποτέλεσμα σε νέο αρχείο:

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");

const sourceFile = "sample.pptx";
const outputFile = "sample_with_updated_properties.pptx";
const presentationInfo = aspose.PresentationFactory.getInstance().getPresentationInfo(sourceFile);
const documentProperties = presentationInfo.readDocumentProperties();

documentProperties.setTitle("Quarterly sales report");
documentProperties.setLastSavedTime(java.newInstanceSync("java.util.Date"));

presentationInfo.updateDocumentProperties(documentProperties);
const outputStream = java.newInstanceSync("java.io.FileOutputStream", outputFile);
try {
    presentationInfo.writeBindedPresentation(outputStream);
} finally {
    outputStream.close();
}
```

Η παρακάτω εικόνα δείχνει τις τροποποιημένες ιδιότητες του εγγράφου της παρουσίασης PowerPoint.

![Τροποποιημένες ιδιότητες εγγράφου της παρουσίασης PowerPoint](output_properties.png)

## **Χρήσιμοι Σύνδεσμοι**

Για συναφείς ελέγχους ασφαλείας και ρυθμίσεις προστασίας, δείτε τα παρακάτω άρθρα:

- [Προστασία Παρουσιάσεων με Κωδικό](/slides/el/nodejs-java/password-protected-presentation/)
- [Προστασία Γραφής Παρουσιάσεων](/slides/el/nodejs-java/write-protected-presentation/)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Πώς μπορώ να ελέγξω αν οι γραμματοσειρές είναι ενσωματωμένες και ποιες είναι;**

Φορτώστε την παρουσίαση και χρησιμοποιήστε το [Presentation.getFontsManager](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getfontsmanager/). Καλέστε το [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getembeddedfonts/) για να λάβετε τις ενσωματωμένες γραμματοσειρές και το [FontsManager.getFonts](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/fontsmanager/getfonts/) για να λάβετε τις γραμματοσειρές που χρησιμοποιεί η παρουσίαση. Συγκρίνετε τα δύο αποτελέσματα για να βρείτε γραμματοσειρές που απαιτούνται για την απόδοση αλλά δεν είναι ενσωματωμένες.

**Πώς μπορώ γρήγορα να διαπιστώσω αν το αρχείο έχει κρυφές διαφάνειες και πόσες;**

Όταν τα αποθηκευμένα μεταδεδομένα εγγράφου είναι επαρκή, διαβάστε το [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/documentproperties/#getHiddenSlides) μέσω του [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/getpresentationinfo/) και του [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/readdocumentproperties/). Αυτό είναι κατάλληλο για ελαφρύ απόθεμα. Εάν η παρουσίαση έχει τροποποιηθεί στη μνήμη, τα αποθηκευμένα μεταδεδομένα μπορεί να λείπουν ή να είναι παλαιά· ή αν χρειάζεται να επαληθεύσετε τις ζωντανές τιμές, επαναλάβετε μέσω του [Presentation.getSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslides/) και ελέγξτε τη μέθοδο [Slide.getHidden](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slide/gethidden/) για κάθε διαφάνεια.

**Μπορώ να ανιχνεύσω αν χρησιμοποιείται προσαρμοσμένο μέγεθος διαφάνειας και προσανατολισμός, και αν διαφέρουν από τις προεπιλογές;**

Ναι. Φορτώστε την παρουσίαση και καλέστε το [Presentation.getSlideSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslidesize/). Χρησιμοποιήστε τις μεθόδους [SlideSize.getType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/gettype/), [SlideSize.getSize](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/getsize/), και [SlideSize.getOrientation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/slidesize/getorientation/) για να συγκρίνετε τις τρέχουσες ρυθμίσεις με τις προδιαγεγραμμένες και τις διαστάσεις.

**Υπάρχει γρήγορος τρόπος να δω αν τα γραφήματα αναφέρονται σε εξωτερικές πηγές δεδομένων;**

Ναι. Εντοπίστε κάθε [Chart](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chart/) και καλέστε το [ChartData.getDataSourceType](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getdatasourcetype/). Για εξωτερικό βιβλίο εργασίας, καλέστε το [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/). Ο τύπος πηγής δεδομένων και η διαδρομή αναγνωρίζουν μια εξωτερική αναφορά, αλλά η επαλήθευση της διαθεσιμότητας του στόχου απαιτεί ξεχωριστό έλεγχο πόρων.

**Πώς μπορώ να αξιολογήσω «βαριές» διαφάνειες που μπορεί να καθυστερούν την απόδοση ή την εξαγωγή PDF;**

Δεν υπάρχει μια μοναδική ιδιότητα πολυπλοκότητας. Διασχίστε το [Presentation.getSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/getslides/) και τη συλλογή [BaseSlide.getShapes](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/baseslide/#getShapes) για κάθε διαφάνεια. Χρησιμοποιήστε τους αριθμούς σχημάτων και την παρουσία μεγάλων εικόνων, εφέ, κινούμενων σχεδίων ή πολυμέσων ως δείκτες φίλτρανσης, και μετρήστε μια αντιπροσωπευτική απόδοση ή εξαγωγή πριν θεωρήσετε μια διαφάνεια ως επιβεβαιωμένο εμπόδιο απόδοσης.