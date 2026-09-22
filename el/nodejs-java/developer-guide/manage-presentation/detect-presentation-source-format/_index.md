---
title: Καθορισμός της Αρχικής Μορφής Παρουσίασης στο Node.js
linktitle: Μορφή Πηγής
type: docs
weight: 35
url: /el/nodejs-java/detect-presentation-source-format/
keywords:
- μορφή πηγής
- ανίχνευση μορφής παρουσίασης
- PowerPoint
- OpenDocument
- παρουσίαση
- PPT
- PPTX
- Node.js
- JavaScript
- Aspose.Slides
description: "Διαβάστε την αρχική μορφή μιας φορτωμένης παρουσίασης στο Node.js με το Aspose.Slides για Node.js μέσω Java, συγκρίνετε τα API ανίχνευσης και διαχειριστείτε αρχεία, ροές και παλαιές μορφές."
---
## **Επισκόπηση**

Αφού φορτώσετε μια παρουσίαση, καλέστε τη μέθοδο [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSourceFormat) για να καθορίσετε την αρχική της μορφή. Χρησιμοποιήστε τη όταν η επόμενη επεξεργασία εξαρτάται από τη μορφή από την οποία φορτώθηκε η τρέχουσα παρουσίαση.

Η πηγαία μορφή διαφέρει από το [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) που επιλέγεται για το αρχείο εξόδου. Η αποθήκευση σε άλλη μορφή δεν αλλάζει την πηγαία μορφή της υπάρχουσας παρουσίασης.

## **Ανάγνωση της Πηγαίας Μορφής Αρχείου**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pptx`. Φορτώνει το αρχείο και επιλέγει μια πολιτική επεξεργασίας της εφαρμογής χρησιμοποιώντας [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSourceFormat), αντί του ονόματος αρχείου. Αλλάξτε τη διαδρομή εισόδου για να δοκιμάσετε άλλες μορφές. Το παράδειγμα εκτυπώνει την επιλεγμένη πολιτική· αντικαταστήστε τα μηνύματα με τη λογική της εφαρμογής σας.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
        case aspose.SourceFormat.Pps:
        case aspose.SourceFormat.Pot:
            console.log("Use the legacy PowerPoint processing policy.");
            break;
        case aspose.SourceFormat.Pptx:
            console.log("Use the standard PPTX processing policy.");
            break;
        default:
            console.log("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Αναγνώριση των Υποστηριζόμενων Τιμών**

Η κλάση [SourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sourceformat/) ορίζει ακέραιες σταθερές που διακρίνουν τις ακόλουθες μορφές παρουσίασης. Οι επεκτάσεις παρακάτω είναι συμβατικές επεκτάσεις, όχι ανασύνθεση του αρχικού ονόματος αρχείου.

| Τιμή SourceFormat | Επέκταση | Μορφή |
| --- | --- | --- |
| `Ppt` | `.ppt` | Παρουσίαση PowerPoint 97–2003 |
| `Pptx` | `.pptx` | Παρουσίαση Office Open XML |
| `Pptm` | `.pptm` | Παρουσίαση Office Open XML με μακροεντολές |
| `Pps` | `.pps` | Παρουσίαση διαφάνειων PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | Παρουσίαση διαφάνειων Office Open XML |
| `Ppsm` | `.ppsm` | Παρουσίαση διαφάνειων Office Open XML με μακροεντολές |
| `Pot` | `.pot` | Πρότυπο PowerPoint 97–2003 |
| `Potx` | `.potx` | Πρότυπο Office Open XML |
| `Potm` | `.potm` | Πρότυπο Office Open XML με μακροεντολές |
| `Odp` | `.odp` | Παρουσίαση OpenDocument |
| `Otp` | `.otp` | Πρότυπο παρουσίασης OpenDocument |
| `Fodp` | `.fodp` | Παρουσίαση Flat XML ODF |
| `Xml` | `.xml` | Παρουσίαση PowerPoint XML |

## **Ανάγνωση της Πηγαίας Μορφής από Ροή (Stream)**

Αυτό το παράδειγμα απαιτεί ένα υπάρχον αρχείο `sample.pps`. Η ανάγνωση των byte του σε μνήμη ροής μοντελοποιεί είσοδο που λαμβάνεται χωρίς όνομα αρχείου, όπως τιμή βάσης δεδομένων ή ανεβασμένο πίνακα byte. Ο κατασκευαστής [Presentation](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/) δέχεται μόνο τη ροή.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const buffer = fs.readFileSync("sample.pps");
const bytes = java.newArray("byte", Array.from(buffer));
const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
try {
    const presentation = new aspose.Presentation(stream);
    try {
        console.log("Source format: " + presentation.getSourceFormat());
    } finally {
        presentation.dispose();
    }
} finally {
    stream.close();
}
```

Τα PPT, PPS και POT χρησιμοποιούν την ίδια υποκείμενη δυαδική μορφή. Όταν φορτώνεται με διαδρομή αρχείου, η επέκταση μπορεί να βοηθήσει στη διάκριση μεταξύ διαφάνειας ή προτύπου. Χωρίς όνομα αρχείου, το περιεχόμενο PPS και POT μπορεί να αναφερθεί ως `SourceFormat.Ppt`; το παράδειγμα PPS παραπάνω εκτυπώνει την ακέραια τιμή του `SourceFormat.Ppt`.

Εάν η εφαρμογή σας πρέπει να διατηρήσει αυτή τη διάκριση, κρατήστε το αρχικό όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά. Η επέκταση αποτελεί χρήσιμο στοιχείο για αυτά τα παλαιά υποτυπώματα, αλλά δεν πρέπει να είναι η μοναδική βάση για την ταυτοποίηση αυθαίρετου περιεχομένου παρουσίασης.

## **Σύγκριση Ανίχνευσης Πριν και Μετά τη Φόρτωση**

Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) και το [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationinfo/#getLoadFormat) όταν χρειάζεται να ελέγξετε ένα αρχείο πριν φορτωθεί το πλήρες μοντέλο αντικειμένων παρουσίασης. Χρησιμοποιήστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSourceFormat) όταν η παρουσίαση υπάρχει ήδη.

Αυτό το παράδειγμα απαιτεί `sample.pptx` και εκτυπώνει τις ακέραιες τιμές των `LoadFormat.Pptx` και `SourceFormat.Pptx`, αντίστοιχα. Σε παραγωγή, επιλέξτε το API που ταιριάζει στο στάδιο επεξεργασίας· μια ήδη φορτωμένη παρουσίαση δεν απαιτεί δεύτερο έλεγχο μόνο για να ληφθεί η πηγαία της μορφή.

```javascript
const aspose = require("aspose.slides.via.java");

const path = "sample.pptx";
const information = aspose.PresentationFactory.getInstance().getPresentationInfo(path);
console.log("Before loading: " + information.getLoadFormat());

const presentation = new aspose.Presentation(path);
try {
    console.log("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Τα αποτελέσματα χρησιμοποιούν σταθερές από διαφορετικές κλάσεις: [LoadFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/loadformat/) και [SourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sourceformat/). Μην συγκρίνετε τις αριθμητικές τιμές τους ή υποθέτετε ότι κάθε μορφή έχει τα ίδια αποτελέσματα ανίχνευσης. Το PowerPoint XML μπορεί να αναφερθεί ως `LoadFormat.Unknown` πριν τη φόρτωση και ως `SourceFormat.Xml` μετά τη φόρτωση.

## **Διαχωρισμός Πηγαίας και Εξόδου Μορφής**

Αυτό το παράδειγμα απαιτεί `sample.pptx` και γράφει `converted.odp`. Εκτυπώνει την ακέραια τιμή του `SourceFormat.Pptx` τόσο πριν όσο και μετά την αποθήκευση της αρχικής παρουσίασης. Μόνο η νέα παρουσίαση που φορτώνεται από το αρχείο εξόδου ODP αναφέρει `Odp`.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    console.log("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", aspose.SaveFormat.Odp);
    console.log("After saving: " + presentation.getSourceFormat());

    const reopened = new aspose.Presentation("converted.odp");
    try {
        console.log("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Μια παρουσίαση που δημιουργείται από το μηδέν με `new Presentation()` αναφέρει `SourceFormat.Pptx`. Δεν έχει αρχείο εισόδου: αυτή είναι η προεπιλεγμένη τιμή για μια νεοδημιουργημένη παρουσίαση, όχι ένδειξη ότι φορτώθηκε αρχείο PPTX. Καταγράψτε αν η εφαρμογή σας δημιούργησε ή φόρτωσε την παρουσίαση ξεχωριστά εάν αυτή η διάκριση έχει σημασία.

## **Αντιστοίχιση Πηγαίας Μορφής σε Επέκταση**

Το παρακάτω παράδειγμα απαιτεί `sample.pptx`. Αντιστοιχίζει κάθε τρέχουσα υποστηριζόμενη τιμή [SourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/sourceformat/) σε συμβατική επέκταση, χωρίς ανάλυση του ονόματος αρχείου εισόδου. Η εναλλακτική λύση αποφεύγει την αθόρυβη ανάθεση επέκτασης σε μη αναγνωρισμένη τιμή.

```javascript
const aspose = require("aspose.slides.via.java");

const presentation = new aspose.Presentation("sample.pptx");
try {
    let extension;
    switch (presentation.getSourceFormat()) {
        case aspose.SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case aspose.SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case aspose.SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case aspose.SourceFormat.Pps:
            extension = ".pps";
            break;
        case aspose.SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case aspose.SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case aspose.SourceFormat.Pot:
            extension = ".pot";
            break;
        case aspose.SourceFormat.Potx:
            extension = ".potx";
            break;
        case aspose.SourceFormat.Potm:
            extension = ".potm";
            break;
        case aspose.SourceFormat.Odp:
            extension = ".odp";
            break;
        case aspose.SourceFormat.Otp:
            extension = ".otp";
            break;
        case aspose.SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case aspose.SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    console.log(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Αυτή η αντιστοίχιση δεν μετατρέπει αρχείο ούτε επαναφέρει ένα παλαιό υποτύπο PPS/POT που χάθηκε κατά τη φόρτωση από ροή. Για πραγματική αποθήκευση, επιλέξτε ρητά ένα [SaveFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/saveformat/) ή χρησιμοποιήστε τη μετατροπή που φαίνεται στο [Save Presentations in Their Original Format](/slides/el/nodejs-java/save-presentation/#save-presentations-in-their-original-format).

## **Επαλήθευση Μορφών με Αποθήκευση και Επανάληψη Άνοιγματος**

Αυτό το αυτόνομο παράδειγμα δημιουργεί μια παρουσίαση και γράφει τρία αρχεία στον τρέχοντα φάκελο, αντικαθιστώντας αρχεία με τα ίδια ονόματα. Επανανοίγει κάθε έξοδο τόσο με διαδρομή όσο και μέσω μνήμης ροής. Για PPTX και ODP, και οι δύο διαδρομές αναφέρουν τη αποθηκευμένη μορφή. Για PPS, η φόρτωση με διαδρομή αναφέρει `Pps`, ενώ η φόρτωση των ίδιων byte χωρίς όνομα αρχείου αναφέρει `Ppt`.

```javascript
const aspose = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");

const presentation = new aspose.Presentation();
try {
    const formats = [aspose.SaveFormat.Pptx, aspose.SaveFormat.Odp, aspose.SaveFormat.Pps];
    const extensions = ["pptx", "odp", "pps"];

    for (let i = 0; i < formats.length; i++) {
        const path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        const fromFile = new aspose.Presentation(path);
        try {
            const buffer = fs.readFileSync(path);
            const bytes = java.newArray("byte", Array.from(buffer));
            const stream = java.newInstanceSync("java.io.ByteArrayInputStream", bytes);
            try {
                const fromStream = new aspose.Presentation(stream);
                try {
                    console.log(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            } finally {
                stream.close();
            }
        } finally {
            fromFile.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

Ο παρακάτω πίνακας συνοψίζει την αναγνώριση πηγαίας μορφής για παρουσιάσεις με αντίστοιχες επεκτάσεις. Τα ονόματα δηλώνουν τις σταθερές· τα παραδείγματα JavaScript εκτυπώνουν τις ακέραιες τιμές τους:

| Αποθηκευμένη μορφή | SourceFormat από διαδρομή αρχείου | SourceFormat από ροή χωρίς όνομα |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` αντίστοιχα | ίδια με τη διαδρομή |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` αντίστοιχα | ίδια με τη διαδρομή |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` αντίστοιχα | ίδια με τη διαδρομή |
| ODP, OTP | `Odp`, `Otp` αντίστοιχα | ίδια με τη διαδρομή |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Το περιεχόμενο PPS/POT αναγνωρίζεται ως `Ppt` για ροές χωρίς όνομα. Ο πίνακας περιγράφει την αναγνώριση μορφής, όχι τη διατήρηση όλων των χαρακτηριστικών παρουσίασης κατά τη μετατροπή.

## **Συχνές Ερωτήσεις (FAQ)**

**Αλλάζει η αποθήκευση σε ODP την πηγαία μορφή μιας παρουσίασης που φορτώθηκε από PPTX;**

Όχι. Η υπάρχουσα παρουσίαση εξακολουθεί να αναφέρει `Pptx`. Μια παρουσίαση που φορτώνεται από το αποθηκευμένο αρχείο ODP αναφέρει `Odp`.

**Μπορεί μια ροή πάντα να διακρίνει μια παλαιά παρουσίαση, διαφάνεια και πρότυπο;**

Όχι. Τα PPT, PPS και POT μοιράζονται την ίδια δυαδική μορφή. Κρατήστε το όνομα αρχείου ή τα μεταδεδομένα υποτύπου ξεχωριστά όταν αυτή η διάκριση απαιτείται.

**Ποιο API πρέπει να χρησιμοποιήσω εάν η παρουσίαση είναι ήδη φορτωμένη;**

Διαβάστε το [Presentation.getSourceFormat](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentation/#getSourceFormat). Χρησιμοποιήστε το [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/el/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) για έλεγχο πριν τη φόρτωση.