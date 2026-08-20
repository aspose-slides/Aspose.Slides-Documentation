---
title: Μετατροπή PPT σε PPTX στο Android
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
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX στο Android με Aspose.Slides. Περιλαμβάνει παραδείγματα Java για μετατροπή ενός αρχείου και παρτίδας, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides για Android μέσω Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/) . Στη συνέχεια, καλέστε τη μέθοδο [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/#Pptx) . Το τμήμα `finally` απελευθερώνει την παρουσίαση και τις πόρους της.

```java
// Φόρτωση της παλαιάς παρουσίασης PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Αποθήκευση της παρουσίασης σε μορφή PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η επέκταση του αρχείου δεν επιλέγει τη μορφή εξόδου από μόνη της· το επιχείρημα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχημένη μετατροπή δεν διακόπτει το υπόλοιπο πακέτο.

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

Για εργασίες παραγωγής, καταγράψτε την πλήρη εξαίρεση, αποφασίστε εάν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί, και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμες διαδρομές και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Password-Protected Presentations](/androidjava/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλαιές Λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε λειτουργία με ακριβώς τον ίδιο τρόπο. Μια παλαιότερη λειτουργία που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραληφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινούμενα σχέδια, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, έλεγχο ActiveX, ενσωματωμένα πολυμέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή που υποστηρίζει μακροεντολές, επομένως χρησιμοποιήστε κατάλληλη ροή εργασίας με μακροεντολές όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επιβεβαιώστε επίσης ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου θα ανοιχτεί ή θα αποδοθεί η μετατρεπόμενη παρουσίαση.

Για σημαντικά έγγραφα, ανοίξτε εκ νέου το παραγόμενο PPTX προγραμματιστικά και επιθεωρήστε τους κύριους αριθμούς διαφανειών και το περιεχόμενο, έπειτα συγκρίνετε την εμφάνισή του και τη συμπεριφορά της παρουσίασης στο προοριζόμενο πρόγραμμα προβολής. Μην θεωρείτε μια επιτυχημένη κλήση [Presentation.save](https://reference.aspose.com/slides/el/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) απόδειξη ότι κάθε παλαιότερη λειτουργία έχει ακριβή αναπαράσταση σε PPTX.

## **Πότε να Χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλασσθεί με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκευτεί σε μορφή που είναι πιο εύκολη στην επιθεώρηση και ανάκτηση σε σχέση με το παλαιό δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή αντιγράφου επαναφοράς μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε αντί αυτού PDF, HTML, εικόνες, XPS ή κάποιον άλλο τύπο εξόδου, χρησιμοποιήστε τις οδηγίες ειδικές για τη μορφή στο [Convert Presentations to Multiple Formats](/androidjava/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν τις επεξεργάσιμες λειτουργίες του PowerPoint.

## **Online Μετατροπέας**

Για περιστασιακό αρχείο ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία παρτίδων ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το Android μέσω Java API.

## **Σχετικά Άρθρα**

- [PPT vs PPTX](/androidjava/ppt-vs-pptx/)
- [Αποθήκευση Παρουσιάσεων σε Android](/androidjava/save-presentation/)
- [Υποστηριζόμενες Μορφές Αρχείων](/androidjava/supported-file-formats/)
- [Άνοιγμα Παρουσιάσεων σε Android](/androidjava/open-presentation/)

## **ΣΥΧΝΕΣ ΕΡΩΤΗΣΕΙΣ**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς να είναι εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Το Aspose.Slides για Android μέσω Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν είναι εγγυημένη για κάθε παλαιότερη ή μη υποστηριζόμενη λειτουργία. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένες κινήσεις ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT με κωδικό προστασίας;**

Ναι, εάν παρέχετε τον σωστό κωδικό κατά τη φόρτωση του αρχείου. Η έλλειψη ή λανθασμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Θα πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να ελέγξετε το PPTX στους προβολείς και τις ροές εργασιών που σας ενδιαφέρουν. Αυτό παρέχει ένα αντίγραφο επαναφοράς εάν μια παλαιότερη λειτουργία μετατραπεί διαφορετικά.