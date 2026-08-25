---
title: Μετατροπή PPT σε PPTX στο Node.js
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
description: "Μετατρέψτε παλαιά αρχεία PPT σε PPTX στο Node.js με το Aspose.Slides. Περιλαμβάνει παραδείγματα JavaScript για μετατροπή ενός αρχείου ή δέσμης, χειρισμό σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides για Node.js μέσω Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/), έπειτα καλέστε την [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/). Η εντολή `finally` απελευθερώνει την παρουσίαση και τις πόρους της.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Φορτώστε την κληρονομική παρουσίαση PPT.
let presentation = new aspose.slides.Presentation("presentation.ppt");
try {
    // Αποθηκεύστε την παρουσίαση σε μορφή PPTX.
    presentation.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η επέκταση του αρχείου δεν επιλέγει την μορφή εξόδου από μόνη της· το όρισμα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

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

Για παραγωγικά φορτία εργασίας, καταγράψτε το πλήρες σφάλμα, αποφασίστε εάν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί, και γράψτε τα ονόματα των αποτυχημένων αρχείων σε ουρά επανάληψης ή ανασκόπησης. Κατεστραμμένα αρχεία, αρχεία με προστασία κωδικού πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Password-Protected Presentations](/slides/el/nodejs-java/password-protected-presentation/) για φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Κληρονομικά Χαρακτηριστικά**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε χαρακτηριστικό με την ακριβώς ίδια μορφή. Ένα κληρονομικό χαρακτηριστικό που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα γραφικά, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα μέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, γι' αυτό χρησιμοποιήστε μια κατάλληλη ροή εργασίας με υποστήριξη μακροεντολών όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, επαληθεύστε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι είναι παρόντες στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοίξει ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε ξανά το δημιουργημένο PPTX προγραμματιστικά και ελέγξτε τον αριθμό διαφανειών και το περιεχόμενο, στη συνέχεια συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στον προοριζόμενο προβολέα. Μην θεωρείτε μια επιτυχημένη κλήση της [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) ως απόδειξη ότι κάθε κληρονομικό χαρακτηριστικό έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να χρησιμοποιήσετε PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, ανταλλαγεί με συστήματα που δουλεύουν με πακέτα Open XML ή αποθηκεύεται σε μορφή που είναι πιο εύκολη στην επιθεώρηση και αποκατάσταση από το κληρονομικό δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή αντιγράφου επαναφοράς μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε PDF, HTML, εικόνες, XPS ή άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες για συγκεκριμένη μορφή στο [Convert Presentations to Multiple Formats](/slides/el/nodejs-java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν επεξεργάσιμα χαρακτηριστικά του PowerPoint.

## **Διαδικτυακός Μετατροπέας**

Για περιστασιακό αρχείο ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία σε δέσμη ή χειρισμό σφαλμάτων επιπέδου εφαρμογής, χρησιμοποιήστε το API Node.js μέσω Java.

## **Συναφή Άρθρα**

- [PPT vs PPTX](/slides/el/nodejs-java/ppt-vs-pptx/)
- [Αποθήκευση παρουσιάσεων σε Node.js](/slides/el/nodejs-java/save-presentation/)
- [Υποστηριζόμενες μορφές αρχείων](/slides/el/nodejs-java/supported-file-formats/)
- [Άνοιγμα παρουσιάσεων σε Node.js](/slides/el/nodejs-java/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς εγκατεστημένο Microsoft PowerPoint;**

Ναι. Το Aspose.Slides για Node.js μέσω Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε κληρονομικό ή μη υποστηριζόμενο χαρακτηριστικό. Ελέγξτε το δημιουργημένο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, μέσα, εξειδικευμένα γραφικά ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT με προστασία κωδικού;**

Ναι, εάν παρέχετε τον σωστό κωδικό κατά τη φόρτωση του αρχείου. Ένας ελλιπής ή λανθασμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να επιβεβαιώσετε το PPTX στους προβολείς και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει ένα αντίγραφο επαναφοράς εάν κάποιο κληρονομικό χαρακτηριστικό μετατραπεί διαφορετικά.