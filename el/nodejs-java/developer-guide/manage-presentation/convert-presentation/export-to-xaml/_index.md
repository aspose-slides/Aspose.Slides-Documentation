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
description: "Μετατρέψτε τις διαφάνειες PowerPoint και OpenDocument σε XAML με JavaScript χρησιμοποιώντας το Aspose.Slides—γρήγορη λύση χωρίς Office που διατηρεί το σχεδιασμό σας αμετάβλητο."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει μια σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές κοινές ερωτήσεις σχετικά με εφεδρικές γραμματοσειρές, συμβατότητα του XAML stack και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βασισμένη στο XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως το WPF (Windows Presentation Foundation), το UWP (Universal Windows Platform) και το Xamarin.Forms.

Μπορείτε να εργαστείτε με αρχεία XAML σε έναν οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα απευθείας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Επιλογές**

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

Από προεπιλογή, οι εξαγόμενες διαφάνειες αποθηκεύονται σε έναν υποφάκελο `input` του τρέχοντος καταλόγου εργασίας της διεργασίας. Ο φάκελος δημιουργείται αυτόματα και τυχόν απαραίτητα εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχείου προέλευσης χωρίς την επέκτασή του. Στο Aspose.Slides for Node.js via Java 26.8, η εξαγωγή του `input.pptx` παράγει μια ένθετη διαδρομή όπως `input/input/Slide_1.xaml`. Διατηρήστε τις πλήρως δημιουργημένες διαδρομές όταν διαχειρίζεστε την έξοδο. Η προεπιλεγμένη έξοδος είναι σχετική με τον τρέχοντα κατάλογο εργασίας, όχι απαραίτητα παράλληλη με το αρχείο εισόδου.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Επιλογές**

Χρησιμοποιήστε το [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloptions/) interface για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη θέση, υλοποιήστε το [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) και περάστε ένα στιγμιότυπο της υλοποίησής σας στη μέθοδο [setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) του [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, καλέστε το [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) με `true`, όπως φαίνεται στο παρακάτω παράδειγμα JavaScript:

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

Μια εξαγωγή XAML μπορεί να παραγάγει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια, καθώς και ξεχωριστές εικόνες και υποστηρικτικούς πόρους. Ανάθετε έναν προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/) στο [XamlOptions.setOutputSaver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setOutputSaver) για να λαμβάνετε αυτά τα αντικείμενα αντί της προεπιλεγμένης αποθήκευσης στο σύστημα αρχείων. Ξεκινήστε την εξαγωγή με την XAML‑specific [Presentation.save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save) overload που δέχεται επιλογές XAML.

Στο Node.js, υλοποιήστε τη διεπαφή Java με `java.newProxy` από το πακέτο `java` που χρησιμοποιεί το Aspose.Slides. Κρατήστε τον διαμεσολαβητή προσβάσιμο μέχρι να ολοκληρωθεί η εξαγωγή.

### **Κατανόηση του Κύκλου Ζωής Callback**

Ο εξαγωγέας καλεί το [IXamlOutputSaver.save](https://reference.aspose.com/slides/java/com.aspose.slides/ixamloutputsaver/#save-java.lang.String-byte:A-) ξεχωριστά για κάθε παραγόμενο αντικείμενο:

- `path` προσδιορίζει το αντικείμενο και μπορεί να περιέχει σχετικούς καταλόγους. Διατηρήστε αυτήν την πληροφορία, καθώς το XAML μπορεί να αναφέρεται σε πόρους μέσω σχετικών διαδρομών.
- `data` περιέχει τα byte του αντικειμένου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιηθούν ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για τη διατήρηση ή την αποθήκευση των δεδομένων πριν επιστρέψει. Τα παραδείγματα αντιγράφουν κάθε Java byte array σε έναν buffer του Node.js που ανήκει στην εφαρμογή.
- Θεωρήστε την εξαγωγή επιτυχής μόνο όταν η λειτουργία αποθήκευσης της παρουσίασης επιστραφεί και κάθε callback έχει ολοκληρωθεί επιτυχώς. Μην αγνοείτε σφάλματα αποθήκευσης ή μη παρατηρημένες εγγραφές στο παρασκήνιο. Εάν η διατήρηση συμβαίνει μετά, αναφέρετε συνολική επιτυχία μόνο αφού ολοκληρωθεί και αυτό το βήμα.

[XamlOptions.setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) ισχύει επίσης για προσαρμοσμένο αποθηκευτή. Η προεπιλεγμένη τιμή, `false`, εξαιρεί έγγραφα XAML κρυφών διαφανειών. Η παράδοση του `true` τις συμπεριλαμβάνει καθώς και τυχόν πόρους που απαιτούνται για την εξαγωγή τους. Οι αριθμοί πόρων εξαρτώνται από την παρουσίαση· μην υποθέτετε ένα callback ανά διαφάνεια ή σταθερή σειρά callbacks.

### **Εξαγωγή στη Μνήμη και Έλεγχος των Αντικειμένων**

Αυτό το πλήρες παράδειγμα φορτώνει το `input.pptx`, συλλέγει κάθε αντικείμενο σε έναν χάρτη JavaScript ονομάτων προς buffers και εκτυπώνει το όνομα, τον τύπο και το μέγεθος σε byte. Διατηρεί ακριβώς τα παρεχόμενα ονόματα. Τα διπλότυπα ονόματα σηματοδοτούν τη συλλογή ως άκυρη αντί να αντικαθιστούν σιωπηρά ένα αντικείμενο. Το παράδειγμα ελέγχει αυτό πριν χρησιμοποιήσει τα αποτελέσματα.

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

        // Αποκωδικοποίηση μόνο XAML, και μόνο όταν απαιτείται κειμενική επιθεώρηση.
        if (isXaml && inspectXamlText) {
            console.log(data.toString("utf8"));
        }
    }
}
```

Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αντικείμενα, συμπεριλαμβανομένων άγνωστων τύπων πόρων. Αφήστε τα byte αμετάβλητα κατά την αποθήκευση ή τη μετάδοση. Χρησιμοποιήστε αποκωδικοποίηση UTF-8 μόνο για XAML που χρειάζεται κειμενική επεξεργασία.

### **Συσκευασία Συλλεγμένων Αντικειμένων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συγκεντρώνει την εξαγωγή, επικυρώνει τα ονόματα και γράφει τα αρχικά byte σε ένα αρχείο ZIP χρησιμοποιώντας τη γέφυρα Java. Το ZIP δημιουργείται στη μνήμη πριν αποθηκευτεί στο δίσκο. Ένα μοναδικό όνομα αρχειοθέτη διαχωρίζει τα ταυτόχρονα τρέχοντα έργα εξαγωγής. Οι καταχωρήσεις ZIP χρησιμοποιούν μπροστιγές κάθετες γραμμές και διατηρούν τους σχετικούς καταλόγους. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτουν όλο το πακέτο πριν γραφτεί.

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
            const bytes = java.newArray("byte", Array.from(data));
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

Το παράδειγμα χρησιμοποιεί το [ZipOutputStream](https://docs.oracle.com/javase/8/docs/api/java/util/zip/ZipOutputStream.html) για να γράψει ένα τοπικό αρχείο· ο εξαγωγέας δεν γράφει χαλαρά αρχεία XAML ή εικόνων. Για απομακρυσμένη αποθήκευση, αντικαταστήστε το στάδιο εγγραφής του αρχείου με ανεβάσματα των συλλεγμένων byte arrays. Χρησιμοποιήστε έναν αναγνωριστικό εργασίας εξαγωγής μαζί με το πλήρες σχετικό όνομα του αντικειμένου ως κλειδί blob ή αποθηκεύστε τον αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε γραμμή βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο μετά την ολοκλήρωση όλων των ανεβάσμάτων ή τη δέσμευση της συναλλαγής. Καθαρίστε μερική έξοδο εάν η διατήρηση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να διατηρήσει κάθε αντικείμενο άμεσα στην αποθήκευση της εφαρμογής, ώστε να αποφευχθεί η διατήρηση ενός επιπλέον αντιγράφου ολόκληρης της εξαγωγής στη μνήμη της εφαρμογής. Κρατήστε κάθε callback σύμφωνο από την προοπτική του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός έχει αποδεχθεί τα byte και επιτρέψτε τις αποτυχίες να φτάσουν στον καλούντα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τους διαχωριστές διαδρομών όταν απαιτείται από τον προορισμό, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το βασικό όνομα εκτός εάν κάθε παραγόμενο όνομα είναι γνωστό ότι είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονόματος ειδική για τον προορισμό. Κατά την εγγραφή χαλαρών αρχείων, απορρίψτε ριζικές διαδρομές και τμήματα που προωθούν την πλοήγηση προς τα πάνω, επιλύστε τον προορισμό σε απόλυτη διαδρομή και επιβεβαιώστε ότι παραμένει κάτω από τον προοριζόμενο φάκελο εξαγωγής, συμπεριλαμβανομένου του διαχωριστικού καταλόγου στον έλεγχο περιεχομένου. Χρησιμοποιήστε φάκελο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να μεταβιβάσουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας πεζών‑κεφαλαίων του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και επιθεωρήστε τις αναφορές πόρων βάσει αρχείου, όπως τα χαρακτηριστικά `Source` ή `ImageSource` εικόνων. Εξακριβώστε κάθε σχετικό URI έναντι του καταλόγου του περιέχοντος αντικειμένου XAML, κανονικοποιήστε το προκύπτον όνομα αποθήκευσης και επιβεβαιώστε ότι υπάρχει το αντίστοιχο κλειδί χάρτη, καταχώρηση ZIP ή αποθηκευμένο αντικείμενο. Θεωρήστε ξεχωριστά τις εξωτερικές URI και τις εκφράσεις σήμανσης XAML από τα σχετικά ονόματα αρχείων.

Για παράδειγμα, αν το `input/Slide_1.xaml` κάνει αναφορά στο `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `input/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα σπάσει τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε αυτά τα URL πόρων προσβάσιμα στον καταναλωτή XAML. Ανοίξτε ξανά το ολοκληρωμένο ZIP για να επαληθεύσετε τα ονόματα καταχωρήσεων και τα byte των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο περιβάλλον XAML-στόχο για να επιβεβαιώσετε ότι οι εικόνες επιλύονται σωστά.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στον υπολογιστή;**

Καλέστε το [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) στο [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — χρησιμοποιείται ως γραμματοσειρά εφεδρείας κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει τη γραμματοσειρά εφεδρείας ή ότι η γραμματοσειρά θα είναι διαθέσιμη στον προορισμό. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται στο XAML είναι διαθέσιμες στο περιβάλλον όπου εμφανίζεται.

**Η εξαγόμενη XAML προορίζεται μόνο για WPF ή μπορεί να χρησιμοποιηθεί και σε άλλους XAML stacks;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλους XAML stacks, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο περιβάλλον-στόχο σας.

**Υποστηρίζονται κρυφές διαφάνειες και πώς μπορώ να τις αποτρέψω από την εξαγωγή εξ ορισμού;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν περιλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/#setExportHiddenSlides) στο [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — κρατήστε το απενεργοποιημένο εάν δεν χρειάζεται να τις εξάγετε.