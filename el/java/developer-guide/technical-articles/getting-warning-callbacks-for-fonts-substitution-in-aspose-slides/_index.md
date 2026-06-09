---
title: Λήψη κλήσεων επιστροφής προειδοποίησης για αντικατάσταση γραμματοσειράς
type: docs
weight: 90
url: /el/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- κλήση επιστροφής προειδοποίησης
- αντικατάσταση γραμματοσειράς
- διαδικασία απόδοσης
- PowerPoint
- OpenDocument
- παρουσίαση
- Java
- Aspose.Slides
description: "Μάθετε πώς να λαμβάνετε κλήσεις επιστροφής προειδοποίησης για αντικατάσταση γραμματοσειράς στο Aspose.Slides for Java και να εμφανίζετε παρουσιάσεις PowerPoint και OpenDocument με ακρίβεια."
---
## **Εισαγωγή**

Το Aspose.Slides for Java σάς επιτρέπει να λαμβάνετε κλήσεις επιστροφής προειδοποιήσεων για αντικατάσταση γραμματοσειράς όταν μια απαιτούμενη γραμματοσειρά δεν είναι διαθέσιμη στη συσκευή κατά την απόδοση. Αυτές οι κλήσεις βοηθούν στη διάγνωση προβλημάτων με ελλείπουσες ή μη προσβάσιμες γραμματοσειρές.

## **Ενεργοποίηση κλήσεων επιστροφής προειδοποιήσεων**

Το Aspose.Slides for Java παρέχει απλές API για τη λήψη κλήσεων επιστροφής προειδοποιήσεων κατά την απόδοση των διαφανειών παρουσίασης. Ακολουθήστε τα παρακάτω βήματα για να ρυθμίσετε τις κλήσεις προειδοποίησης:

1. Δημιουργήστε μια προσαρμοσμένη κλάση κλήσης επιστροφής που υλοποιεί τη διεπαφή [IWarningCallback](https://reference.aspose.com/slides/el/java/com.aspose.slides/iwarningcallback/) για την επεξεργασία προειδοποιήσεων.
1. Ορίστε την κλήση προειδοποίησης χρησιμοποιώντας κλάσεις επιλογών όπως [RenderingOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/java/com.aspose.slides/htmloptions/) και άλλες.
1. Φορτώστε μια παρουσίαση που χρησιμοποιεί μια γραμματοσειρά μη διαθέσιμη στη στοχευόμενη συσκευή.
1. Δημιουργήστε μια μικρογραφία διαφάνειας ή εξάγετε την παρουσίαση για να παρατηρήσετε το αποτέλεσμα.

**Προσαρμοσμένη κλάση κλήσης επιστροφής προειδοποίησης:**  
```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Παράδειγμα εξόδου:
//
// Η γραμματοσειρά θα αντικατασταθεί από XYZ σε {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Δημιουργία μικρογραφίας διαφάνειας:**  
```java
// Ρυθμίστε μια κλήση επιστροφής προειδοποίησης για να διαχειριστείτε προειδοποιήσεις σχετικές με γραμματοσειρές κατά την απόδοση των διαφανειών.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Δημιουργήστε μια εικόνα μικρογραφίας για κάθε διαφάνεια στην παρουσίαση.
    for (ISlide slide : presentation.getSlides()) {
        // Λάβετε την εικόνα μικρογραφίας της διαφάνειας χρησιμοποιώντας τις συγκεκριμένες επιλογές απόδοσης.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Εξαγωγή σε μορφή PDF:**  
```java
// Ρυθμίστε μια κλήση επιστροφής προειδοποίησης για να διαχειριστείτε προειδοποιήσεις σχετικές με γραμματοσειρές κατά την εξαγωγή PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Εξαγάγετε την παρουσίαση ως PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Εξαγωγή σε μορφή HTML:**  
```java
// Ρυθμίστε μια κλήση επιστροφής προειδοποίησης για να διαχειριστείτε προειδοποιήσεις σχετικές με γραμματοσειρές κατά την εξαγωγή HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Εξαγάγετε την παρουσίαση σε μορφή HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```