---
title: Μετατροπή PPT σε PPTX με Java
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
description: "Μετατροπή παλαιών αρχείων PPT σε PPTX με Java και Aspose.Slides. Περιλαμβάνει παραδείγματα Java για μετατροπή ενός αρχείου και μαζική μετατροπή, διαχείριση σφαλμάτων και σημειώσεις ακρίβειας."
---
## **Επισκόπηση**

Το PPT είναι η παραδοσιακή δυαδική μορφή του PowerPoint, ενώ το PPTX είναι η νεότερη μορφή Open XML. Το Aspose.Slides for Java μπορεί να φορτώσει ένα αρχείο PPT και να το αποθηκεύσει ως PPTX χωρίς το Microsoft PowerPoint. Αυτό το άρθρο δείχνει πώς να μετατρέψετε ένα αρχείο ή έναν φάκελο αρχείων και εξηγεί τι πρέπει να ελέγξετε μετά τη μετατροπή.

## **Μετατροπή αρχείου PPT σε PPTX**

Φορτώστε το πηγαίο αρχείο με την κλάση [Presentation](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/), στη συνέχεια καλέστε το [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) με το [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/#Pptx). Το μπλοκ `finally` απελευθερώνει την παρουσίαση και τους πόρους της.

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

Η επέκταση του αρχείου δεν επιλέγει από μόνη της τη μορφή εξόδου· το όρισμα [SaveFormat.Pptx](https://reference.aspose.com/slides/el/java/com.aspose.slides/saveformat/#Pptx) το κάνει. Διατηρήστε διαφορετικές τις διαδρομές εισόδου και εξόδου εάν χρειάζεται να διατηρήσετε το αρχικό αρχείο PPT.

## **Μετατροπή πολλαπλών αρχείων PPT**

Το παρακάτω παράδειγμα μετατρέπει κάθε αρχείο `.ppt` σε έναν φάκελο. Κάθε αρχείο επεξεργάζεται ανεξάρτητα, ώστε μια αποτυχία μετατροπής να μην σταματά το υπόλοιπο batch.

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

Για παραγωγικά φορτία εργασίας, καταγράψτε την πλήρη εξαίρεση, αποφασίστε αν ένα υπάρχον αρχείο εξόδου μπορεί να αντικατασταθεί, και γράψτε τα ονόματα των αποτυχημένων αρχείων σε μια ουρά επανάληψης ή ελέγχου. Κατεστραμμένα αρχεία, αρχεία προστατευμένα με κωδικό που ανοίγονται χωρίς τον απαιτούμενο κωδικό, μη προσβάσιμα μονοπάτια και μη υποστηριζόμενο περιεχόμενο μπορούν όλα να προκαλέσουν αποτυχία μετατροπής. Δείτε [Password-Protected Presentations](/java/password-protected-presentation/) για τη φόρτωση κρυπτογραφημένων αρχείων.

## **Ακρίβεια και Χαρακτηριστικά Κληρονομιάς**

Η μετατροπή κανονικά διατηρεί τις διαφάνειες, τα master, τις διατάξεις, το κείμενο, τα σχήματα, τις εικόνες, τους πίνακες και τα διαγράμματα. Ωστόσο, τα PPT και PPTX δεν αντιπροσωπεύουν κάθε χαρακτηριστικό με ακριβώς τον ίδιο τρόπο. Ένα χαρακτηριστικό κληρονομιάς που δεν έχει ισοδύναμο PPTX ή δεν υποστηρίζεται από τη βιβλιοθήκη, μπορεί να κανονικοποιηθεί, να παραλειφθεί ή να εμφανιστεί διαφορετικά.

Ελέγξτε το μετατρεπόμενο αρχείο όταν περιέχει κινήσεις, μεταβάσεις, ενσωματωμένα ή συνδεδεμένα αντικείμενα OLE, ελέγχους ActiveX, ενσωματωμένα πολυμέσα, ασυνήθιστα γραμματοσειρές ή μακροεντολές VBA. Έ ένα απλό αρχείο PPTX δεν είναι μορφή με δυνατότητα μακροεντολών, επομένως χρησιμοποιήστε κατάλληλη ροή εργασίας με δυνατότητα μακροεντολών όταν η VBA πρέπει να παραμείνει διαθέσιμη. Επίσης, βεβαιωθείτε ότι οι απαιτούμενες γραμματοσειρές και οι εξωτερικοί πόροι υπάρχουν στο περιβάλλον όπου η μετατρεπόμενη παρουσίαση θα ανοίξει ή θα αποδοθεί.

Για σημαντικά έγγραφα, ανοίξτε εκ νέου το παραγόμενο PPTX προγραμματισμένα και ελέγξτε βασικούς αριθμούς διαφανειών και περιεχόμενο, έπειτα συγκρίνετε την εμφάνιση και τη συμπεριφορά της παρουσίασης στον προορισμένο προβολέα. Μην θεωρείτε μια επιτυχημένη κλήση [Presentation.save](https://reference.aspose.com/slides/el/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ως απόδειξη ότι κάθε χαρακτηριστικό κληρονομιάς έχει ακριβή αναπαράσταση PPTX.

## **Πότε να Χρησιμοποιήσετε το PPTX**

Χρησιμοποιήστε το PPTX όταν η παρουσίαση θα επεξεργαστεί σε τρέχουσες εκδόσεις του PowerPoint, ανταλλάσσεται με συστήματα που δουλεύουν με πακέτα Open XML, ή αποθηκεύεται σε μορφή που είναι πιο εύκολη για έλεγχο και ανάκτηση από το παλαιό δυαδικό PPT. Διατηρήστε το αρχικό PPT ως αρχείο αρχειοθέτησης ή εφεδρικό αντίγραφο μέχρι η μετατρεπόμενη παρουσίαση να περάσει τους ελέγχους ακρίβειας.

Αν χρειάζεστε PDF, HTML, εικόνες, XPS ή κάποιο άλλο τύπο εξόδου, χρησιμοποιήστε τις προσαρμοσμένες οδηγίες μορφής στο [Convert Presentations to Multiple Formats](/java/convert-presentation/) αντί να υποθέτετε ότι όλοι οι προορισμοί διατηρούν επεξεργάσιμα χαρακτηριστικά PowerPoint.

## **Online Μετατροπέας**

Για ένα περιστασιακό αρχείο ή μια γρήγορη σύγκριση, μπορείτε να χρησιμοποιήσετε το [online PPT to PPTX converter](https://products.aspose.app/slides/el/conversion/ppt-to-pptx). Για επαναλήψιμες μετατροπές, επεξεργασία batch ή διαχείριση σφαλμάτων σε επίπεδο εφαρμογής, χρησιμοποιήστε το Java API.

## **Related Articles**

- [PPT vs PPTX](/java/ppt-vs-pptx/)
- [Save Presentations in Java](/java/save-presentation/)
- [Supported File Formats](/java/supported-file-formats/)
- [Open Presentations in Java](/java/open-presentation/)

## **FAQ**

**Μπορώ να μετατρέψω PPT σε PPTX χωρίς εγκατεστημένο το Microsoft PowerPoint;**

Ναι. Aspose.Slides for Java φορτώνει και αποθηκεύει αρχεία παρουσίασης χωρίς να απαιτεί το Microsoft PowerPoint.

**Θα διατηρήσει η μετατροπή PPT σε PPTX όλο το περιεχόμενο ακριβώς;**

Διατηρεί το κοινό περιεχόμενο της παρουσίασης, αλλά η ακριβής ακρίβεια δεν εγγυάται για κάθε κληρονομικό ή μη υποστηριζόμενο χαρακτηριστικό. Εξετάστε το παραγόμενο αρχείο όταν περιέχει μακροεντολές, αντικείμενα OLE ή ActiveX, πολυμέσα, εξειδικευμένες κινήσεις ή ασυνήθιστες γραμματοσειρές.

**Μπορώ να μετατρέψω ένα αρχείο PPT προστατευμένο με κωδικό;**

Ναι, εφόσον παρέχετε τον σωστό κωδικό κατά τη φόρτωση του αρχείου. Έλλειψη ή εσφαλμένος κωδικός προκαλεί αποτυχία της λειτουργίας φόρτωσης.

**Θα πρέπει να διαγράψω το αρχείο PPT μετά τη μετατροπή;**

Διατηρήστε το αρχικό μέχρι να έχετε επαληθεύσει το PPTX στους προβολείς και τις ροές εργασίας που σας ενδιαφέρουν. Αυτό παρέχει αντίγραφο επαναφοράς εάν ένα χαρακτηριστικό κληρονομιάς μετατραπεί διαφορετικά.