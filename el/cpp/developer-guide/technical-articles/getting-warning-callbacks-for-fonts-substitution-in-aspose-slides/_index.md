---
title: Λήψη κλήσεων προειδοποίησης για αντικατάσταση γραμματοσειρών
type: docs
weight: 70
url: /el/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- κλήση προειδοποίησης
- αντικατάσταση γραμματοσειράς
- διαδικασία απόδοσης
- PowerPoint
- OpenDocument
- παρουσίαση
- C++
- Aspose.Slides
description: "Μάθετε πώς να λαμβάνετε κλήσεις προειδοποίησης για αντικατάσταση γραμματοσειράς στο Aspose.Slides για C++ και να εμφανίζετε τις παρουσιάσεις PowerPoint και OpenDocument με ακρίβεια."
---
## **Εισαγωγή**

Το Aspose.Slides for C++ σάς επιτρέπει να λαμβάνετε κλήσεις προειδοποίησης για αντικατάσταση γραμματοσειράς όταν μια απαιτούμενη γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα κατά την απόδοση. Αυτές οι κλήσεις βοηθούν στη διάγνωση προβλημάτων με ελλείπουσες ή μη προσβάσιμες γραμματοσειρές.

## **Ενεργοποίηση κλήσεων προειδοποίησης**

Το Aspose.Slides for C++ παρέχει απλά API για τη λήψη κλήσεων προειδοποίησης κατά την απόδοση των διαφανειών παρουσίασης. Ακολουθήστε τα παρακάτω βήματα για να ρυθμίσετε τις κλήσεις προειδοποίησης:

1. Δημιουργήστε μια προσαρμοσμένη κλάση κλήσης που υλοποιεί τη διεπαφή [IWarningCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/iwarningcallback/) για τη διαχείριση προειδοποιήσεων.
1. Ορίστε την κλήση προειδοποίησης χρησιμοποιώντας κλάσεις επιλογών όπως [RenderingOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/htmloptions/), και άλλες.
1. Φορτώστε μια παρουσίαση που χρησιμοποιεί γραμματοσειρά που δεν είναι διαθέσιμη στο στόχο μηχάνημα.
1. Δημιουργήστε μια μικρογραφία διαφάνειας ή εξάγετε την παρουσίαση για να παρατηρήσετε το αποτέλεσμα.

**Προσαρμοσμένη κλάση κλήσης προειδοποίησης:**

```cpp
#include <Warnings/IWarningCallback.h>

class FontWarningHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontWarningHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss)
    {
        Console::WriteLine(warning->get_Description());
    }

    return ReturnAction::Continue;
}

// Παράδειγμα εξόδου:
//
// Η γραμματοσειρά θα αντικατασταθεί από XYZ σε {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Δημιουργία μικρογραφίας διαφάνειας:**

```cpp
// Ρυθμίστε μια κλήση προειδοποίησης για τη διαχείριση προειδοποιήσεων σχετικών με γραμματοσειρές κατά την απόδοση των διαφανειών.
auto options = MakeObject<RenderingOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
auto presentation = MakeObject<Presentation>(u"sample.pptx");
    
// Δημιουργήστε μια μικρογραφία εικόνας για κάθε διαφάνεια στην παρουσίαση.
for(auto&& slide : presentation->get_Slides())
{
    // Αποκτήστε τη μικρογραφία της διαφάνειας χρησιμοποιώντας τις καθορισμένες επιλογές απόδοσης.
    auto image = slide->GetImage(options);
    // ...

    image->Dispose();
}

presentation->Dispose();
```

**Εξαγωγή σε μορφή PDF:**

```cpp
// Ρυθμίστε μια κλήση προειδοποίησης για τη διαχείριση προειδοποιήσεων σχετικών με γραμματοσειρές κατά την εξαγωγή PDF.
auto options = MakeObject<PdfOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Εξάγετε την παρουσίαση ως PDF.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Pdf, options);
// ...

stream->Dispose();
presentation->Dispose();
```

**Εξαγωγή σε μορφή HTML:**

```cpp
// Ρυθμίστε μια κλήση προειδοποίησης για τη διαχείριση προειδοποιήσεων σχετικών με γραμματοσειρές κατά την εξαγωγή HTML.
auto options = MakeObject<HtmlOptions>();
options->set_WarningCallback(MakeObject<FontWarningHandler>());

// Φορτώστε την παρουσίαση από τη συγκεκριμένη διαδρομή αρχείου.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Εξάγετε την παρουσίαση σε μορφή HTML.
auto stream = MakeObject<MemoryStream>();
presentation->Save(stream, SaveFormat::Html, options);
// ...

stream->Dispose();
presentation->Dispose();
```