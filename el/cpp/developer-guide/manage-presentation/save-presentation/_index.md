---
title: Αποθήκευση παρουσιάσεων σε C++
linktitle: Αποθήκευση παρουσίασης
type: docs
weight: 80
url: /el/cpp/save-presentation/
keywords:
- αποθήκευση PowerPoint
- αποθήκευση OpenDocument
- αποθήκευση παρουσίασης
- αποθήκευση διαφάνειας
- αποθήκευση PPT
- αποθήκευση PPTX
- αποθήκευση ODP
- παρουσίαση σε αρχείο
- παρουσίαση σε ροή
- προκαθορισμένος τύπος προβολής
- Αυστηρή μορφή Office Open XML
- Λειτουργία Zip64
- ανανέωση μικρογραφίας
- πρόοδος αποθήκευσης
- C++
- Aspose.Slides
description: "Ανακαλύψτε πώς να αποθηκεύετε παρουσιάσεις σε C++ με χρήση Aspose.Slides—εξαγωγή σε PowerPoint ή OpenDocument διατηρώντας τη διάταξη, τις γραμματοσειρές και τα εφέ."
---
## **Επισκόπηση**

[Open Presentations in C++](/slides/el/cpp/open-presentation/) περιέγραψε πώς να χρησιμοποιήσετε την κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) για το άνοιγμα μιας παρουσίασης. Αυτό το άρθρο εξηγεί πώς να δημιουργήσετε και να αποθηκεύσετε παρουσιάσεις. Η κλάση [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) περιέχει το περιεχόμενο μιας παρουσίασης. Είτε δημιουργείτε μια παρουσίαση από το μηδέν είτε τροποποιείτε μια υπάρχουσα, θα θέλετε να την αποθηκεύσετε όταν τελειώσετε. Με το Aspose.Slides για C++ μπορείτε να αποθηκεύσετε σε **αρχείο** ή **ροή**. Αυτό το άρθρο εξηγεί τις διαφορετικές μεθόδους αποθήκευσης μιας παρουσίασης.

## **Αποθήκευση παρουσιάσεων σε αρχεία**

Αποθηκεύστε μια παρουσίαση σε αρχείο καλώντας τη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Πιέστε το όνομα αρχείου και τη μορφή αποθήκευσης στη μέθοδο. Το παρακάτω παράδειγμα δείχνει πώς να αποθηκεύσετε μια παρουσίαση με το Aspose.Slides.

```cpp
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Κάντε κάποια εργασία εδώ...

// Αποθηκεύστε την παρουσίαση σε αρχείο.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Αποθήκευση παρουσιάσεων σε ροές**

Μπορείτε να αποθηκεύσετε μια παρουσίαση σε ροή περνώντας μια έξοδο ροής στη μέθοδο `Save` της κλάσης [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/). Μια παρουσίαση μπορεί να γραφτεί σε πολλούς τύπους ροής. Στο παρακάτω παράδειγμα, δημιουργούμε μια νέα παρουσίαση και την αποθηκεύουμε σε ροή αρχείου.

```cpp
// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Αποθηκεύστε την παρουσίαση στη ροή.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Αποθήκευση παρουσιάσεων με προκαθορισμένο τύπο προβολής**

Το Aspose.Slides σας επιτρέπει να ορίσετε την αρχική προβολή που χρησιμοποιεί το PowerPoint όταν ανοίγει η παραγόμενη παρουσίαση μέσω της κλάσης [ViewProperties](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/). Χρησιμοποιήστε τη μέθοδο [set_LastView](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewproperties/set_lastview/) με μια τιμή από την απαρίθμηση [ViewType](https://reference.aspose.com/slides/el/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Αποθήκευση παρουσιάσεων σε αυστηρή μορφή Office Open XML**

Το Aspose.Slides σας επιτρέπει να αποθηκεύσετε μια παρουσίαση στη μορφή Strict Office Open XML. Χρησιμοποιήστε την κλάση [PptxOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/) και ορίστε την ιδιότητα conformance κατά την αποθήκευση. Αν ορίσετε `Conformance.Iso29500_2008_Strict`, το αρχείο εξόδου αποθηκεύεται στη μορφή Strict Office Open XML.

Το παρακάτω παράδειγμα δημιουργεί μια παρουσίαση και την αποθηκεύει στη μορφή Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Δημιουργήστε ένα στιγμιότυπο της κλάσης Presentation που αντιπροσωπεύει ένα αρχείο παρουσίασης.
auto presentation = MakeObject<Presentation>();

// Αποθηκεύστε την παρουσίαση στη μορφή Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Αποθήκευση παρουσιάσεων σε μορφή Office Open XML σε λειτουργία Zip64**

Ένα αρχείο Office Open XML είναι ένα αρχείο ZIP που επιβάλλει περιορισμούς 4 GB (2^32 bytes) στο ασυμπίεστο μέγεθος οποιουδήποτε αρχείου, στο συμπιεσμένο μέγεθος οποιουδήποτε αρχείου και στο συνολικό μέγεθος του αρχείου, καθώς επίσης περιορίζει το αρχείο σε 65 535 (2^16‑1) αρχεία. Οι επεκτάσεις μορφής ZIP64 αυξάνουν αυτούς τους περιορισμούς σε 2^64.

Η μέθοδος [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) σας επιτρέπει να επιλέξετε πότε να χρησιμοποιήσετε τις επεκτάσεις μορφής ZIP64 κατά την αποθήκευση ενός αρχείου Office Open XML.

Αυτή η μέθοδος μπορεί να χρησιμοποιηθεί με τους ακόλουθους τρόπους:

- `IfNecessary` χρησιμοποιεί τις επεκτάσεις μορφής ZIP64 μόνο εάν η παρουσίαση υπερβαίνει τους περιορισμούς που αναφέρθηκαν παραπάνω. Αυτή είναι η προεπιλεγμένη λειτουργία.
- `Never` δεν χρησιμοποιεί ποτέ επεκτάσεις μορφής ZIP64.
- `Always` πάντα χρησιμοποιεί επεκτάσεις μορφής ZIP64.

Ο παρακάτω κώδικας δείχνει πώς να αποθηκεύσετε μια παρουσίαση ως PPTX με ενεργοποιημένες τις επεκτάσεις μορφής ZIP64:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Όταν αποθηκεύετε με `Zip64Mode.Never`, ρίχνεται μια [PptxException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxexception/) εάν η παρουσίαση δεν μπορεί να αποθηκευτεί σε μορφή ZIP32.
{{% /alert %}}

## **Αποθήκευση παρουσιάσεων χωρίς ανανέωση της μικρογραφίας**

Η μέθοδος [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) ελέγχει τη δημιουργία μικρογραφίας κατά την αποθήκευση μιας παρουσίασης σε PPTX:

- Αν οριστεί σε `true`, η μικρογραφία ανανεώνεται κατά την αποθήκευση. Αυτό είναι η προεπιλογή.
- Αν οριστεί σε `false`, η τρέχουσα μικρογραφία διατηρείται. Εάν η παρουσίαση δεν έχει μικρογραφία, δεν δημιουργείται καμία.

Στον παρακάτω κώδικα, η παρουσίαση αποθηκεύεται σε PPTX χωρίς να ανανεωθεί η μικρογραφία της.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Αυτή η επιλογή βοηθά στη μείωση του χρόνου που απαιτείται για την αποθήκευση μιας παρουσίασης σε μορφή PPTX.
{{% /alert %}}

## **Αποθήκευση ενημερώσεων προόδου σε ποσοστό**

Το interface [IProgressCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprogresscallback/) χρησιμοποιείται μέσω της μεθόδου `set_ProgressCallback` που εκτίθεται από το interface [ISaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/isaveoptions/) και την αφηρημένη κλάση [SaveOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/). Αναθέστε μια υλοποίηση [IProgressCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/iprogresscallback/) με `set_ProgressCallback` για να λαμβάνετε ενημερώσεις προόδου αποθήκευσης σε ποσοστό.

Τα παρακάτω αποσπάσματα κώδικα δείχνουν πώς να χρησιμοποιήσετε το `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Χρησιμοποιήστε την τιμή ποσοστού προόδου εδώ.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Η Aspose έχει δημιουργήσει μια [δωρεάν εφαρμογή PowerPoint Splitter](https://products.aspose.app/slides/el/splitter) χρησιμοποιώντας το δικό της API. Η εφαρμογή σας επιτρέπει να χωρίσετε μια παρουσίαση σε πολλά αρχεία αποθηκεύοντας επιλεγμένες διαφάνειες ως νέα αρχεία PPTX ή PPT.
{{% /alert %}}

## **Συχνές Ερωτήσεις**

**Υποστηρίζεται η "γρήγορη αποθήκευση" (αύξητική αποθήκευση) ώστε να γράφονται μόνο οι αλλαγές;**

Όχι. Η αποθήκευση δημιουργεί το πλήρες αρχείο προορισμού κάθε φορά· η αύξητική "γρήγορη αποθήκευση" δεν υποστηρίζεται.

**Είναι ασφαλές ως προς το νήμα (thread‑safe) να αποθηκεύουμε το ίδιο αντικείμενο Presentation από πολλαπλά νήματα;**

Όχι. Ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/) [δεν είναι thread‑safe](/slides/el/cpp/multithreading/); αποθηκεύστε το από ένα μόνο νήμα.

**Τι συμβαίνει με τους υπερσυνδέσμους και τα εξωτερικά συνδεδεμένα αρχεία κατά την αποθήκευση;**

[Hyperlinks](/slides/el/cpp/manage-hyperlinks/) διατηρούνται. Τα εξωτερικά συνδεδεμένα αρχεία (π.χ. βίντεο μέσω σχετικών διαδρομών) δεν αντιγράφονται αυτόματα· βεβαιωθείτε ότι οι αναφερόμενες διαδρομές παραμένουν προσπελάσιμες.

**Μπορώ να ορίσω/αποθηκεύσω μεταδεδομένα εγγράφου (Συγγραφέας, Τίτλος, Εταιρεία, Ημερομηνία);**

Ναι. Οι τυπικές [document properties](/slides/el/cpp/presentation-properties/) υποστηρίζονται και θα γραφούν στο αρχείο κατά την αποθήκευση.