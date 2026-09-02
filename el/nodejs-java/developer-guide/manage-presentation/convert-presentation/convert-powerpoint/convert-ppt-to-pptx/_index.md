---
title: Μετατροπή PPT σε PPTX σε Node.js
linktitle: PPT σε PPTX
type: docs
weight: 20
url: /el/nodejs-java/convert-ppt-to-pptx/
keywords:
- μετατροπή PowerPoint
- μετατροπή παρουσίασης
- μετατροπή διαφάνειας
- μετατροπή PPT
- PPT σε PPTX
- αποθήκευση PPT ως PPTX
- εξαγωγή PPT σε PPTX
- PowerPoint
- παρουσίαση
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX σε Node.js με Aspose.Slides. Περιλαμβάνει παραδείγματα JavaScript για μετατροπή μονής αρχείου και παρτίδας, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides για Node.js μέσω Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), έπειτα καλέστε την [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και εκδίδει τους πόρους της.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Φορτώνει την κληρονομική παρουσίαση PPT.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Αποθηκεύει την παρουσίαση σε μορφή PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κατάληξη αρχείου δεν επιλέγει τη μορφή εξόδου από μόνη της· το όρισμα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχημένη μετατροπή δεν σταματά το υπόλοιπο σύνολο.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const inputDirectory = "input";
const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
    .filter(entry => entry.isFile() && path.extname(entry.name).toLowerCase() === ".ppt")
    .map(entry => entry.name);

for (const fileName of inputFiles) {
    const inputPath = path.join(inputDirectory, fileName);
    const outputFileName = path.basename(fileName, path.extname(fileName)) + ".pptx";
    const outputPath = path.join(outputDirectory, outputFileName);
    let presentation = null;

    try {
        presentation = new aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, aspose.slides.SaveFormat.Pptx);
        console.log("Converted: " + inputPath);
    } catch (error) {
        console.error("Failed: " + inputPath + " (" + error.message + ")");
    } finally {
        if (presentation !== null) {
            presentation.dispose();
        }
    }
}
```

Για εργασίες παραγωγής, καταγράψτε το πλήρες σφάλμα, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανάληψης ή επανεξέτασης. Κατεστραμμένα αρχεία, αρχεία με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και ακατοπινόητο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε την ενότητα [Παρουσιάσεις με προστασία κωδικού](/nodejs-java/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και παλαιές δυνατότητες**

Η μετατροπή συνήθως διατηρεί διαφάνειες, κύριες διαφάνειες, διατάξεις, κείμενο, σχήματα, εικόνες, πίνακες και γραφήματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε δυνατότητα με ακριβώς τον ίδιο τρόπο. Μια παλαιότερη δυνατότητα που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα σχέδια, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα πολυμέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, γι’ αυτό χρησιμοποιήστε μια κατάλληλη ροή εργασίας με υποστήριξη μακροεντολών όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοίξει ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε ξανά το παραγόμενο PPTX προγραμματιστικά και εξετάστε τον αριθμό των κύριων διαφανειών και το περιεχόμενο, στη συνέχεια συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στο προοριζόμενο πρόγραμμα προβολής. Μην θεωρείτε μια επιτυχημένη κλήση [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) ως απόδειξη ότι κάθε παλαιότερη δυνατότητα έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να χρησιμοποιήσετε PPTX**

Χρησιμοποιήστε PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλάσσεται με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκεύεται σε μορφή που είναι πιο εύκολο να επιθεωρηθεί και να ανακτηθεί από το παλαιότερο δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχείου ή αντιγράφου επαναφοράς μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε PDF, HTML, εικόνες, XPS ή κάποιο άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες για συγκεκριμένες μορφές στην ενότητα [Μετατροπή παρουσιάσεων σε πολλαπλές μορφές](/nodejs-java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν επεξεργάσιμες δυνατότητες PowerPoint.

## **Μετατροπέας online**

Για ένα περιστασιακό αρχείο ή μια γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online μετατροπέας PPT σε PPTX](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία παρτίδων ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το API Node.js μέσω Java.

## **Σχετικά άρθρα**

- [PPT vs PPTX](/nodejs-java/ppt-vs-pptx/)
- [Αποθήκευση παρουσιάσεων σε Node.js](/nodejs-java/save-presentation/)
- [Υποστηριζόμενες μορφές αρχείων](/nodejs-java/supported-file-formats/)
- [Άνοιγμα παρουσιάσεων σε Node.js](/nodejs-java/open-presentation/)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς εγκατεστημένο Microsoft PowerPoint;**

Ναι. Το Aspose.Slides για Node.js μέσω Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε παλαιότερη ή μη υποστηριζόμενη δυνατότητα. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένα κινούμενα σχέδια ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα PPT αρχείο με προστασία κωδικού;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Ένας ελλιπής ή λάθος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Θα πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να έχετε επαληθεύσει το PPTX στους προγράμματα προβολής και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει ένα αντίγραφο επαναφοράς σε περίπτωση που μια παλαιότερη δυνατότητα μετατραπεί διαφορετικά.