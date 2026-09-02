---
title: Μετατροπή PPT σε PPTX σε Android
linktitle: PPT σε PPTX
type: docs
weight: 20
url: /el/androidjava/convert-ppt-to-pptx/
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
- Android
- Java
- Aspose.Slides
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX σε Android με Aspose.Slides. Περιλαμβάνει παραδείγματα Java για μετατροπή ενός αρχείου και σε παρτίδες, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιά δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides for Android via Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/), έπειτα καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και τις πόρους της.

```java
// Φορτώστε την παλαιά παρουσίαση PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Αποθηκεύστε την παρουσίαση σε μορφή PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η επέκταση του αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το επιχείρημα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/#Pptx) το κάνει. Κρατήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, ώστε μια αποτυχημένη μετατροπή να μην σταματήσει το υπόλοιπο batch.

```java
java.io.File inputDirectory = new java.io.File("input");
java.io.File outputDirectory = new java.io.File("output");
if (!outputDirectory.exists() && !outputDirectory.mkdirs()) {
    throw new IllegalStateException("Cannot create the output directory: " + outputDirectory);
}

java.io.File[] inputFiles = inputDirectory.listFiles((directory, name) -> name.toLowerCase(java.util.Locale.ROOT).endsWith(".ppt"));
if (inputFiles == null) {
    throw new IllegalStateException("Cannot read the input directory: " + inputDirectory);
}

for (java.io.File inputFile : inputFiles) {
    String inputPath = inputFile.getPath();
    String fileName = inputFile.getName();
    String outputFileName = fileName.substring(0, fileName.length() - 4) + ".pptx";
    String outputPath = new java.io.File(outputDirectory, outputFileName).getPath();
    com.aspose.slides.Presentation presentation = null;

    try {
        presentation = new com.aspose.slides.Presentation(inputPath);
        presentation.save(outputPath, com.aspose.slides.SaveFormat.Pptx);
        System.out.println("Converted: " + inputPath);
    } catch (Exception exception) {
        System.err.println("Failed: " + inputPath + " (" + exception.getMessage() + ")");
    } finally {
        if (presentation != null) {
            presentation.dispose();
        }
    }
}
```

Για παραγωγικά φορτία εργασίας, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα αποτυχόντων αρχείων σε μια ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία προστατευμένα με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσπελάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Password-Protected Presentations](/androidjava/password-protected-presentation/) για φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλαιές Χαρακτηριστικά**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τα layout, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε χαρακτηριστικό με ακριβώς τον ίδιο τρόπο. Ένα παλαιό χαρακτηριστικό που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα γραφικά, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα μέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με δυνατότητα μακροεντολών, οπότε χρησιμοποιήστε μια κατάλληλη ροή εργασίας με μακροεντολές όταν το VBA πρέπει να παραμένει διαθέσιμο. Επίσης, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές και εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου θα ανοιχθεί ή θα αποδοθεί η μετατρεπόμενη παρουσίαση.

Για σημαντικά έγγραφα, ανοίξτε ξανά το παραγόμενο PPTX προγραμματιστικά και επιθεωρήστε τους βασικούς αριθμούς διαφανειών και το περιεχόμενο, στη συνέχεια συγκρίνετε την εμφάνισή του και τη συμπεριφορά προβολής διαφανειών στον προοριζόμενο προβάλλον. Μην θεωρείτε μια επιτυχημένη κλήση του [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ως απόδειξη ότι κάθε παλαιό χαρακτηριστικό έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να χρησιμοποιήσετε PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλαγεί με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκευτεί σε μορφή που είναι πιο εύκολη για εξέταση και ανάκτηση από το παλαιό δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή εφεδρικής αντιγραφής μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Εάν χρειάζεστε PDF, HTML, εικόνες, XPS ή κάποιον άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες για συγκεκριμένες μορφές στο [Convert Presentations to Multiple Formats](/slides/el/androidjava/convert-presentation/) αντί να υποθέτετε ότι όλα τα προορισμοί διατηρούν επεξεργάσιμα χαρακτηριστικά PowerPoint.

## **Διαδικτυακός Μετρωπέας**

Για περιστασιακό αρχείο ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία batch ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το Android via Java API.

## **Σχετικά Άρθρα**

- [PPT vs PPTX](/slides/el/androidjava/ppt-vs-pptx/)
- [Αποθήκευση Παρουσιών στο Android](/slides/el/androidjava/save-presentation/)
- [Υποστηριζόμενες Μορφές Αρχείων](/slides/el/androidjava/supported-file-formats/)
- [Άνοιγμα Παρουσιών στο Android](/slides/el/androidjava/open-presentation/)

## **FAQ**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Το Aspose.Slides for Android via Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Η μετατροπή PPT σε PPTX θα διατηρήσει όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε παλαιό ή μη υποστηριζόμενο χαρακτηριστικό. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, μέσα, εξειδικευμένες κινούμενες εικόνες ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα PPT αρχείο προστατευμένο με κωδικό;**

Ναι, εάν παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Η έλλειψη ή λανθασμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να επαληθεύσετε το PPTX στους προγράμματα προβολής και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει αντίγραφο επαναφοράς αν κάποιο παλαιό χαρακτηριστικό μετατραπεί διαφορετικά.