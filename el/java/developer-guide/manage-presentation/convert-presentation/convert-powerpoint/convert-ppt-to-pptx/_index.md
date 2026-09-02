---
title: Μετατροπή PPT σε PPTX σε Java
linktitle: PPT σε PPTX
type: docs
weight: 20
url: /el/java/convert-ppt-to-pptx/
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
- Java
- Aspose.Slides
description: "Μετατρέψτε παλαιά αρχεία PPT σε PPTX σε Java με το Aspose.Slides. Περιλαμβάνει παραδείγματα Java για μετατροπή ενός αρχείου και δέσμης, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παλαιότερη δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides for Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το αρχείο προέλευσης με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), στη συνέχεια καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και τις πηγές της.

```java
// Φορτώστε την παλαιότερη παρουσίαση PPT.
com.aspose.slides.Presentation presentation = new com.aspose.slides.Presentation("presentation.ppt");
try {
    // Αποθηκεύστε την παρουσίαση σε μορφή PPTX.
    presentation.save("presentation.pptx", com.aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Η κατάληξη του αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικούς τους διαδρόμους εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το ακόλουθο παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, έτσι μια αποτυχία μετατροπής δεν σταματά το υπόλοιπο σύνολο.

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

Για παραγωγικές εργασίες, καταγράψτε την πλήρη εξαίρεση, αποφασίστε εάν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία προστατευμένα με κωδικό πρόσβασης που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμοι διαδρόμοι και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε το [Password-Protected Presentations](/slides/el/java/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Παλιές Λειτουργίες**

Η μετατροπή συνήθως διατηρεί τις διαφάνειες, τα master, τα σχέδια, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα γραφήματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε λειτουργία με ακριβώς τον ίδιο τρόπο. Μια παλαιότερη λειτουργία που δεν έχει ισοδύναμο στο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατραπέν αρχείο όταν περιέχει κινήσεις, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελεγκτές ActiveX, ενσωματωμένα πολυμέσα, σπάνιες γραμματοσειρές ή μακροεντολές VBA. Ένα απλό αρχείο PPTX δεν είναι μορφή με υποστήριξη μακροεντολών, γι' αυτό χρησιμοποιήστε μια κατάλληλη διαδικασία με υποστήριξη μακροεντολών όταν το VBA πρέπει να παραμείνει διαθέσιμο. Επίσης, επαληθεύστε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι είναι παρόντες στο περιβάλλον όπου η μετατραπέν παρουσίαση θα ανοίξει ή θα αποδοθεί.

Για σημαντικά έγγραφα, ξανανοίξτε το παραγόμενο PPTX προγραμματιστικά και εξετάστε τα βασικά πλήθη διαφανειών και το περιεχόμενο, μετά συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στον προγραμματισμένο προβάλλον. Μην θεωρείτε μια επιτυχημένη κλήση του [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ως απόδειξη ότι κάθε παλαιότερη λειτουργία έχει ακριβή αναπαράσταση στο PPTX.

## **Πότε να Χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, θα ανταλλάσσεται με συστήματα που δουλεύουν με πακέτα Open XML ή θα αποθηκευτεί σε μορφή που είναι πιο εύκολη στην επιθεώρηση και ανάκτηση από το παλαιό δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή αντιγράφου επαναφοράς μέχρι η μετατραπέν παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Εάν χρειάζεστε PDF, HTML, εικόνες, XPS ή άλλη μορφή εξόδου, χρησιμοποιήστε τις οδηγίες για συγκεκριμένη μορφή στο [Convert Presentations to Multiple Formats](/slides/el/java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν δυνατότητες επεξεργασίας του PowerPoint.

## **Online Μετατροπέας**

Για περιστασιακά αρχεία ή γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε τον [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλαμβανόμενες μετατροπές, επεξεργασία δέσμης ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το Java API.

## **Σχετικά Άρθρα**

- [PPT vs PPTX](/slides/el/java/ppt-vs-pptx/)
- [Αποθήκευση Παρουσιάσεων σε Java](/slides/el/java/save-presentation/)
- [Υποστηριζόμενες Μορφές Αρχείων](/slides/el/java/supported-file-formats/)
- [Άνοιγμα Παρουσιάσεων σε Java](/slides/el/java/open-presentation/)

## **Συχνές Ερωτήσεις**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς την εγκατάσταση του Microsoft PowerPoint;**

Ναι. Το Aspose.Slides for Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε παλαιότερη ή μη υποστηριζόμενη λειτουργία. Ελέγξτε το παραγόμενο αρχείο όταν περιλαμβάνει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσια, εξειδικευμένες κινήσεις ή σπάνιες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT που προστατεύεται με κωδικό;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό πρόσβασης κατά τη φόρτωση του αρχείου. Ένας ελλιπής ή λανθασμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Θα πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να επαληθεύσετε το PPTX στους προβολείς και τις εργασίες που σας ενδιαφέρουν. Αυτό παρέχει αντίγραφο επαναφοράς εάν μια παλαιότερη λειτουργία μετατρέπεται διαφορετικά.