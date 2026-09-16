---
title: Εξαγωγή Παρουσιάσεων σε XAML με JavaScript
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/nodejs-java/export-to-xaml/
keywords:
- εξαγωγή PowerPoint
- εξαγωγή OpenDocument
- εξαγωγή παρουσίασης
- μετατροπή PowerPoint
- μετατροπή OpenDocument
- μετατροπή παρουσίασης
- PowerPoint σε XAML
- OpenDocument σε XAML
- παρουσίαση σε XAML
- PPT σε XAML
- PPTX σε XAML
- ODP σε XAML
- αποθήκευση PPT ως XAML
- αποθήκευση PPTX ως XAML
- αποθήκευση ODP ως XAML
- εξαγωγή PPT σε XAML
- εξαγωγή PPTX σε XAML
- εξαγωγή ODP σε XAML
- Node.js
- JavaScript
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML με JavaScript χρησιμοποιώντας το Aspose.Slides—γρήγορη, χωρίς Office λύση που διατηρεί την διάταξή σας αμετάβλητη."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και επιδεικνύει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές κοινές ερωτήσεις σχετικές με εναλλακτικές γραμματοσειρές, συμβατότητα στο XAML stack και συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βασισμένη σε XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) και Xamarin.Forms.

Μπορείτε να εργάζεστε με αρχεία XAML σε οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα απευθείας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Ρυθμίσεις**

Το παρακάτω παράδειγμα JavaScript δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

Από προεπιλογή, οι εξαγώμενες διαφάνειες αποθηκεύονται σε έναν υποφάκελο `input` του τρέχοντος καταλόγου εργασίας της διεργασίας. Ο φάκελος δημιουργείται αυτόματα, και τυχόν απαιτούμενες εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχείου προέλευσης χωρίς την επέκτασή του. Στο Aspose.Slides for Node.js via Java 26.8, η εξαγωγή του `input.pptx` δημιουργεί μια ένθετη διαδρομή όπως `input/input/Slide_1.xaml`. Διατηρήστε τις πλήρως παραγόμενες διαδρομές όταν χειρίζεστε την έξοδο. Η προεπιλεγμένη έξοδος είναι σχετική με τον τρέχοντα κατάλογο εργασίας, αντί να είναι απαραίτητα δίπλα στο αρχείο εισόδου.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Ρυθμίσεις**

Χρησιμοποιήστε τη διεπαφή [IXamlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη θέση, υλοποιήστε το [IXamlOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/) και περάστε μια παρουσία της υλοποίησής σας στη μέθοδο [setOutputSaver](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) του [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, καλέστε το [setExportHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) με `true`, όπως φαίνεται στο παρακάτω παράδειγμα JavaScript:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    presentation.save(xamlOptions);
} finally {
    presentation.dispose();
}
```

## **Καταγραφή Όλων των Παραγόμενων Αντικειμένων XAML**

Μια εξαγωγή XAML μπορεί να δημιουργήσει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια συν ξεχωριστές εικόνες και βοηθητικούς πόρους. Αναθέστε ένα προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/) στο [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) για να λαμβάνετε αυτά τα αντικείμενα αντί να χρησιμοποιείτε τον προεπιλεγμένο αποθηκευτή του συστήματος αρχείων. Ξεκινήστε την εξαγωγή με την XAML‑συγκεκριμένη υπερφόρτωση [Presentation.save](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#save) η οποία δέχεται επιλογές XAML.

Στο Node.js, υλοποιήστε τη διεπαφή Java με `java.newProxy` από το πακέτο `java` που χρησιμοποιείται από το Aspose.Slides. Κρατήστε το proxy προσβάσιμο μέχρι να ολοκληρωθεί η εξαγωγή.

### **Κατανόηση του Κύκλου Ζωής Callback**

Ο εξαγωγέας καλεί το [IXamlOutputSaver.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) ξεχωριστά για κάθε παραγόμενο αντικείμενο:

- `path` προσδιορίζει το αντικείμενο και μπορεί να περιλαμβάνει σχετικούς καταλόγους. Διατηρήστε αυτήν την πληροφορία επειδή το XAML μπορεί να αναφέρεται σε πόρους χρησιμοποιώντας σχετικές διαδρομές.
- `data` περιέχει τα byte του αντικειμένου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιηθούν ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για τη διατήρηση ή την αποθήκευση των δεδομένων πριν επιστρέψει. Τα παραδείγματα αντιγράφουν κάθε Java byte array σε ένα buffer Node.js που ανήκει στην εφαρμογή.
- Θεωρείτε την εξαγωγή επιτυχημένη μόνο όταν η λειτουργία αποθήκευσης της παρουσίασης επιστρέψει και κάθε callback έχει ολοκληρωθεί επιτυχώς. Μην αγνοείτε σφάλματα αποθήκευσης ή ξεκινάτε ανεπίβλεπτες εγγραφές στο παρασκήνιο. Αν η διατήρηση συμβεί αργότερα, αναφέρετε τη συνολική επιτυχία μόνο μετά το βήμα αυτό επίσης να έχει ολοκληρωθεί.

Το [XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) εφαρμόζεται επίσης σε προσαρμοσμένο αποθηκευτή. Η προεπιλεγμένη ρύθμιση, `false`, εξαιρεί τα έγγραφα XAML κρυφών διαφανειών. Η μεταβίβαση του `true` τα περιλαμβάνει μαζί με τυχόν πόρους που απαιτούνται για την εξαγωγή τους. Οι αριθμοί πόρων εξαρτώνται από την παρουσίαση· μην υποθέτετε ένα callback ανά διαφάνεια ή σταθερή σειρά callbacks.

### **Εξαγωγή στη Μνήμη και Έλεγχος των Αντικειμένων**

Αυτό το πλήρες παράδειγμα φορτώνει το `input.pptx`, συλλέγει κάθε αντικείμενο σε έναν χάρτη JavaScript ονομάτων σε buffers, και εκτυπώνει το όνομα, τον τύπο και το μέγεθος σε byte. Διατηρεί ακριβώς τα παρεχόμενα ονόματα. Τα διπλά ονόματα σηματοδοτούν τη συλλογή ως άκυρη αντί να αντικαθιστούν σιωπηλά ένα αντικείμενο. Το παράδειγμα ελέγχει αυτό πριν χρησιμοποιήσει τα αποτελέσματα.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(true);
    presentation.save(options);
} finally {
    presentation.dispose();
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const inspectXamlText = false;
    for (const [name, data] of artifacts) {
        const isXaml = /\.xaml$/i.test(name);
        const isImage = /\.(png|jpg|jpeg|gif|bmp|tif|tiff|svg)$/i.test(name);
        const kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
        console.log(name + ": " + data.length + " bytes (" + kind + ")");

        // Αποκωδικοποιήστε μόνο το XAML, και μόνο όταν απαιτείται κειμενική επιθεώρηση.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων άγνωστων τύπων πόρων. Αφήστε τα byte αμετάβλητα όταν τα αποθηκεύετε ή τα μεταδίδετε. Χρησιμοποιήστε αποκωδικοποίηση UTF‑8 μόνο για XAML που χρειάζεται κειμενική επεξεργασία.

### **Συσκευασία Συλλεγμένων Αντικειμένων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματά της και γράφει τα αρχικά bytes σε αρχείο ZIP χρησιμοποιώντας τη γέφυρα Java. Το ZIP δημιουργείται στη μνήμη πριν αποθηκευτεί στον δίσκο. Ένα μοναδικό όνομα αρχείου διαχωρίζει ταυτόχρονες εργασίες εξαγωγής. Οι καταχωρήσεις ZIP χρησιμοποιούν μπροστιγούς κάθετους (forward slashes) και διατηρούν σχετικούς καταλόγους. Τα μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπουν ολόκληρο το πακέτο πριν γραφτεί.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const artifacts = new Map();
let valid = true;
const saver = java.newProxy("com.aspose.slides.IXamlOutputSaver", {
    save: function(path, data) {
        const name = String(path);
        if (artifacts.has(name)) {
            valid = false;
            console.error("Export rejected: duplicate artifact name: " + name);
            return;
        }
        const retainedData = Buffer.from(data);
        artifacts.set(name, retainedData);
    }
});

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.XamlOptions();
    options.setOutputSaver(saver);
    options.setExportHiddenSlides(false);
    presentation.save(options);
} finally {
    presentation.dispose();
}

const entries = new Map();
const entryNames = new Set();
for (const [name, data] of artifacts) {
    const entryName = name.replace(/\\/g, "/");
    const segments = entryName.split("/");
    const unsafeName = entryName.startsWith("/") || entryName.includes(":") || segments.some(segment => segment.trim() === "" || segment === "." || segment === "..");
    const comparisonName = entryName.toLowerCase();
    if (unsafeName || entryNames.has(comparisonName)) {
        valid = false;
        console.error("Export rejected: unsafe or duplicate artifact name: " + name);
        break;
    }
    entryNames.add(comparisonName);
    entries.set(entryName, data);
}

if (!valid) {
    console.error("Export rejected: the artifact collection is invalid.");
} else {
    const fs = require("node:fs");
    const crypto = require("node:crypto");
    const archivePath = "xaml-" + crypto.randomUUID() + ".zip";
    const output = java.newInstanceSync("java.io.ByteArrayOutputStream");
    const archive = java.newInstanceSync("java.util.zip.ZipOutputStream", output);
    try {
        for (const [name, data] of entries) {
            const entry = java.newInstanceSync("java.util.zip.ZipEntry", name);
            archive.putNextEntry(entry);
            const signedBytes = Array.from(data, value => value > 127 ? value - 256 : value);
            const bytes = java.newArray("byte", signedBytes);
            archive.write(bytes);
            archive.closeEntry();
        }
    } finally {
        archive.close();
    }

    // Το κλείσιμο ολοκληρώνει τον κατάλογο ZIP πριν το αρχείο αποθηκευθεί.
    const archiveData = Buffer.from(output.toByteArray());
    try {
        fs.writeFileSync(archivePath, archiveData, { flag: "wx" });
        console.log("Saved " + entries.size + " artifacts to " + archivePath);
    } catch (error) {
        console.error("Archive persistence failed: " + error.message);
    }
}
```

Το παράδειγμα χρησιμοποιεί το [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) για να γράψει ένα τοπικό αρχείο. Ο εξαγωγέας από μόνος του δεν γράφει ξεχωριστά αρχεία XAML ή εικόνας. Για απομακρυσμένη αποθήκευση, αντικαταστήστε το στάδιο εγγραφής αρχείου με ανεβάσματα των συλλεχθέντων byte arrays. Χρησιμοποιήστε ένα αναγνωριστικό εργασίας εξαγωγής συν το πλήρες σχετικό όνομα αντικειμένου ως κλειδί blob, ή αποθηκεύστε το αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε μια γραμμή βάσης δεδομένων. Δημοσιεύστε τη δουλειά μόνο μετά το πέρας όλων των ανεβάσμάτων ή την επιβεβαίωση της συναλλαγής βάσης. Καθαρίστε την ενδιάμεση έξοδο αν η διατήρηση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να διατηρεί κάθε αντικείμενο απευθείας στην αποθήκη της εφαρμογής ώστε να αποφεύγεται η διατήρηση αντίγραφου ολόκληρης της εξαγωγής στη μνήμη. Διατηρήστε κάθε callback συγχρονισμένο από τη σκοπιά του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός έχει αποδεχθεί τα byte, και επιτρέψτε τα σφάλματα να φτάσουν στον καλούντα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τους διαχωριστές διαδρομών όταν ο προορισμός το απαιτεί, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το όνομα αρχείου εκτός αν κάθε παραγόμενο όνομα είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικυρωμένη επικύρωση ονομάτων ανάλογα με τον προορισμό. Όταν γράφετε ξεχωριστά αρχεία, απορρίψτε διαδρομές με ριζικό (rooted) μονοπάτι και τμήματα traversal, επιλύστε τον προορισμό σε απόλυτη διαδρομή, και βεβαιωθείτε ότι παραμένει κάτω από τον προορισμένο κατάλογο εξαγωγής, συμπεριλαμβανομένου του διαχωριστή καταλόγου στον έλεγχο περιέκτη. Χρησιμοποιήστε έναν κατάλογο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να αναπροσανατολίσουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας πεζών‑κεφαλαίων του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και ελέγξτε τις αναφορές πόρων βάσει αρχείου, όπως χαρακτηριστικά `Source` ή `ImageSource` εικόνας. Επίλυση κάθε σχετικού URI έναντι του καταλόγου του σχετικού αντικειμένου XAML, κανονικοποίηση του προκύπτοντος ονόματος αποθήκευσης, και επιβεβαίωση ότι το αντίστοιχο κλειδί του χάρτη, η καταχώρηση ZIP ή το αποθηκευμένο αντικείμενο υπάρχει. Θεωρήστε τα εξωτερικά URI και τις εκφράσεις σήμανσης XAML ξεχωριστά από τα σχετικά ονόματα αρχείων. Για παράδειγμα, αν το `input/Slide_1.xaml` αναφέρει `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `input/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα σπάσει τη σχέση αυτή. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε αυτά τα URLs πόρων προσβάσιμα στον καταναλωτή XAML. Ανοίξτε ξανά το ολοκληρωμένο ZIP για επαλήθευση των ονομάτων καταχώρησης και των byte των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο στοχευμένο περιβάλλον XAML για επιβεβαίωση ότι οι εικόνες λύνουν σωστά.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές αν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα;**

Κάλετε το [setDefaultRegularFont](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) στο [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/) — χρησιμοποιείται ως γραμματοσειρά εφεδρείας κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει τη γραμματοσειρά εφεδρείας ή ότι η γραμματοσειρά είναι διαθέσιμη στο τελικό μηχάνημα. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται στο XAML είναι διαθέσιμες στο περιβάλλον όπου εμφανίζεται.

**Απευθύνεται το εξαχθέν XAML μόνο σε WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο στοχευμένο περιβάλλον σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να τις αποτρέψω από την προεπιλεγμένη εξαγωγή;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν συμπεριλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) στο [XamlOptions](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/xamloptions/) — κρατήστε το απενεργοποιημένο αν δεν χρειάζεστε την εξαγωγή τους.