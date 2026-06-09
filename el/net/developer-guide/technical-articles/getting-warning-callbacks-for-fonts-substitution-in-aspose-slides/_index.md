---
title: Λήψη κλήσεων προειδοποίησης για αντικατάσταση γραμματοσειρών σε .NET
type: docs
weight: 120
url: /el/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- κλήση προειδοποίησης
- αντικατάσταση γραμματοσειράς
- διαδικασία απόδοσης
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να λαμβάνετε κλήσεις προειδοποίησης για αντικατάσταση γραμματοσειρών στο Aspose.Slides για .NET και να προβάλετε με ακρίβεια παρουσιάσεις PowerPoint και OpenDocument."
---
## **Εισαγωγή**

Το Aspose.Slides for .NET σάς επιτρέπει να λαμβάνετε κλήσεις προειδοποίησης για αντικατάσταση γραμματοσειράς όταν μια απαιτούμενη γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα κατά τη διαδικασία απόδοσης. Αυτές οι κλήσεις βοηθούν στη διάγνωση προβλημάτων με ελλείπουσες ή μη προσβάσιμες γραμματοσειρές.

## **Ενεργοποίηση κλήσεων προειδοποίησης**

Το Aspose.Slides for .NET παρέχει απλές API για τη λήψη κλήσεων προειδοποίησης κατά την απόδοση διαφανειών παρουσίασης. Ακολουθήστε τα παρακάτω βήματα για να διαμορφώσετε τις κλήσεις προειδοποίησης:

1. Δημιουργήστε μια προσαρμοσμένη κλάση κλήσης που υλοποιεί τη διεπαφή [IWarningCallback](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/iwarningcallback/) για τη διαχείριση των προειδοποιήσεων.
1. Ορίστε την κλήση προειδοποίησης χρησιμοποιώντας κλάσεις επιλογών όπως [RenderingOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export/htmloptions/), και άλλες.
1. Φορτώστε μια παρουσίαση που χρησιμοποιεί μια γραμματοσειρά που δεν είναι διαθέσιμη στο στόχο μηχάνημα.
1. Δημιουργήστε μια μικρογραφία διαφάνειας ή εξάγετε την παρουσίαση για να παρατηρήσετε το αποτέλεσμα.

**Προσαρμοσμένη κλάση κλήσης προειδοποίησης:**

```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Παράδειγμα εξόδου:
//
// Η γραμματοσειρά θα αντικατασταθεί από XYZ σε {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Δημιουργία μικρογραφίας διαφάνειας:**

```c#
// Ρυθμίστε μια κλήση προειδοποίησης για το χειρισμό προειδοποιήσεων σχετικών με γραμματοσειρές κατά την απόδοση των διαφανειών.
var options = new RenderingOptions();
options.WarningCallback = new FontWarningHandler();

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
using var presentation = new Presentation("sample.pptx");

// Δημιουργήστε μια εικόνα μικρογραφίας για κάθε διαφάνεια στην παρουσίαση.
foreach (var slide in presentation.Slides)
{
    // Λάβετε την εικόνα μικρογραφίας της διαφάνειας χρησιμοποιώντας τις καθορισμένες επιλογές απόδοσης.
    using var image = slide.GetImage(options);
    // ...
}
```

**Εξαγωγή σε μορφή PDF:**

```c#
// Ρυθμίστε μια κλήση προειδοποίησης για το χειρισμό προειδοποιήσεων σχετικών με γραμματοσειρές κατά την εξαγωγή σε PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
using var presentation = new Presentation("sample.pptx");

// Εξάγετε την παρουσίαση ως PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```

**Εξαγωγή σε μορφή HTML:**

```c#
// Ρυθμίστε μια κλήση προειδοποίησης για το χειρισμό προειδοποιήσεων σχετικών με γραμματοσειρές κατά την εξαγωγή σε HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
using var presentation = new Presentation("sample.pptx");

// Εξάγετε την παρουσίαση σε μορφή HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```