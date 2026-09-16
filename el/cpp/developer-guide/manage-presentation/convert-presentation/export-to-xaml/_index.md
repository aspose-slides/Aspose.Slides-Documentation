---
title: Εξαγωγή Παρουσιάσεων σε XAML με C++
linktitle: Παρουσίαση σε XAML
type: docs
weight: 30
url: /el/cpp/export-to-xaml/
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
- C++
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML με C++ χρησιμοποιώντας το Aspose.Slides—γρήγορη, χωρίς Office λύση που διατηρεί αμετάβλητη τη διάταξή σας."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει μια σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/), συμπεριλαμβανομένης της εξαγωγής κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές συχνές ερωτήσεις σχετικά με τις εφεδρικές γραμματοσειρές, τη συμβατότητα στοίβας XAML και τη συμπεριφορά εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βασισμένη σε XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως το WPF (Windows Presentation Foundation), το UWP (Universal Windows Platform) και το Xamarin.Forms.

Μπορείτε να εργαστείτε με αρχεία XAML σε οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα απευθείας.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Ρυθμίσεις**

Το παρακάτω παράδειγμα C++ δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
presentation->Save(xamlOptions);
```

Από προεπιλογή, οι εξαγόμενες διαφάνειες αποθηκεύονται σε έναν υποφάκελο `pres` του τρέχοντος καταλόγου εργασίας της διεργασίας, όπως επιστρέφεται από το [Directory::GetCurrentDirectory](https://reference.aspose.com/slides/el/cpp/system.io/directory/getcurrentdirectory/). Ο φάκελος δημιουργείται αυτόματα και τυχόν απαιτούμενες εικόνες αποθηκεύονται επίσης εκεί.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του πηγαίου αρχείου χωρίς την επέκτασή του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.ο.κ. Ακόμη και αν περάσετε μια απόλυτη διαδρομή στην εισροή παρουσίασης, ο φάκελος εξόδου δημιουργείται σχετικά με τον τρέχοντα κατάλογο εργασίας, όχι δίπλα στο αρχείο εισόδου.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Ρυθμίσεις**

Χρησιμοποιήστε τη διεπαφή [IXamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/ixamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη τοποθεσία, υλοποιήστε το [IXamlOutputSaver](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/ixamloutputsaver/) και περάστε μια παρουσία της υλοποίησής σας στη μέθοδο [set_OutputSaver](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) του [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, περάστε `true` στη μέθοδο [set_ExportHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/), όπως φαίνεται στο παρακάτω παράδειγμα C++:

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/XamlOptions.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;

auto presentation = System::MakeObject<Presentation>(u"pres.pptx");
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);
presentation->Save(xamlOptions);
```

## **Καταγραφή Όλων των Παραγόμενων Αρθρωμάτων XAML**

Μια εξαγωγή XAML μπορεί να παράγει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια, καθώς και ξεχωριστές εικόνες και υποστηρικτικούς πόρους. Περάστε ένα προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/ixamloutputsaver/) στη μέθοδο [XamlOptions::set_OutputSaver](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/set_outputsaver/) για να λάβετε αυτά τα αρχεία αντί της προεπιλεγμένης αποθήκευσης στο σύστημα αρχείων. Ξεκινήστε την εξαγωγή με την έκδοση της μεθόδου [Presentation::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides/presentation/save/) που δέχεται επιλογές XAML.

### **Κατανόηση του Κύκλου Ζωής των Callback**

Ο εξαγωγέας καλεί τη μέθοδο [IXamlOutputSaver::Save](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/ixamloutputsaver/save/) ξεχωριστά για κάθε παραγόμενο αρχείο:

- `path` προσδιορίζει το αρχείο και μπορεί να περιλαμβάνει σχετικούς καταλόγους. Διατηρήστε αυτήν την πληροφορία επειδή το XAML μπορεί να αναφερθεί σε πόρους χρησιμοποιώντας σχετικές διαδρομές.
- `data` περιέχει τα byte του αρχείου. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιηθούν ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος να διατηρήσει ή να αποθηκεύσει τα δεδομένα πριν επιστρέψει. Τα παραδείγματα αντιγράφουν κάθε πίνακα byte σε μνήμη που ανήκει στην εφαρμογή.
- Θεωρήστε την εξαγωγή επιτυχημένη μόνο όταν η λειτουργία αποθήκευσης της παρουσίασης ολοκληρωθεί και κάθε callback έχει τερματιστεί επιτυχώς. Μην αγνοείτε σφάλματα αποθήκευσης ή ξεκινάτε εγγραφές παρασκηνίου που δεν παρακολουθούνται. Αν η επίμονη αποθήκευση συμβεί αργότερα, αναφέρετε τη συνολική επιτυχία μόνο αφού ολοκληρωθεί και αυτό το βήμα.

Το [XamlOptions::set_ExportHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) εφαρμόζεται επίσης σε προσαρμοσμένο αποθηκευτή. Η προεπιλεγμένη τιμή, `false`, εξαιρεί τα XAML έγγραφα κρυφών διαφανειών. Ορίζοντάς το σε `true` τα συμπεριλαμβάνει μαζί με όλους τους πόρους που απαιτούνται για την εξαγωγή τους. Ο αριθμός των πόρων εξαρτάται από την παρουσίαση· μην υποθέτετε ένα callback ανά διαφάνεια ή σταθερή σειρά εκτέλεσης.

### **Εξαγωγή στη Μνήμη και Επιθεώρηση των Αρχείων**

Αυτό το πλήρες παράδειγμα φορτώνει το `pres.pptx`, συλλέγει κάθε αρχείο σε ένα [Dictionary<String, ArrayPtr<uint8_t>>](https://reference.aspose.com/slides/el/cpp/system.collections.generic/dictionary/), και εκτυπώνει το όνομα, τον τύπο και το μέγεθος σε byte. Διατηρεί ακριβώς τα παρεχόμενα ονόματα. Διπλά ονόματα προκαλούν την αποτυχία συλλογής αντί να αντικαταστήσουν σιωπηλά ένα αρχείο.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/io/path.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace System::Text;

class InMemoryXamlExample
{
    class MemoryXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<MemoryXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(true);
        presentation->Save(options);

        auto inspectXamlText = false;
        for (const auto& artifact : saver->Artifacts)
        {
            auto extension = Path::GetExtension(artifact.get_Key()).ToLowerInvariant();
            auto isXaml = extension == u".xaml";
            auto isImage = extension == u".png" || extension == u".jpg" || extension == u".jpeg" || extension == u".gif" || extension == u".bmp" || extension == u".tif" || extension == u".tiff" || extension == u".svg";
            String kind = isXaml ? u"slide XAML" : isImage ? u"image" : u"supporting resource";
            Console::WriteLine(u"{0}: {1} bytes ({2})", artifact.get_Key(), artifact.get_Value()->get_Length(), kind);

            // Αποκωδικοποίηση μόνο του XAML, και μόνο όταν απαιτείται κειμενική επιθεώρηση.
            if (isXaml && inspectXamlText)
            {
                auto markup = Encoding::get_UTF8()->GetString(artifact.get_Value());
                Console::WriteLine(markup);
            }
        }
    }
};
```

Καλέστε τη μέθοδο `InMemoryXamlExample::Run` από την εφαρμογή σας. Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα αρχεία, συμπεριλαμβανομένων των άγνωστων τύπων πόρων. Αφήστε τα byte αμετάβλητα όταν τα αποθηκεύετε ή τα μεταδίδετε. Χρησιμοποιήστε το [Encoding::GetString](https://reference.aspose.com/slides/el/cpp/system.text/encoding/getstring/) με κωδικοποίηση UTF-8 μόνο για XAML που απαιτεί επεξεργασία κειμένου.

### **Συσκευασία των Συλλεγμένων Αρχείων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματα και γράφει τα αρχικά byte σε ένα αρχείο ZIP. Ένα μοναδικό όνομα αρχείου διαχωρίζει τα συγχρόνως τρελαζόμενα έργα εξαγωγής. Οι καταχωρήσεις ZIP χρησιμοποιούν μπροστινά κάθετους και διατηρούν σχετικούς καταλόγους. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτονται ολόκληρα πριν εγγραφούν.

```cpp
#include <DOM/Presentation.h>
#include <Export/Xaml/IXamlOutputSaver.h>
#include <Export/Xaml/XamlOptions.h>
#include <system/array.h>
#include <system/collections/dictionary.h>
#include <system/console.h>
#include <system/string_comparer.h>
#include <system/guid.h>
#include <system/io/file_access.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/path.h>
#include <zip/zip_file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export::Xaml;
using namespace System;
using namespace System::Collections::Generic;
using namespace System::IO;
using namespace Aspose::Zip;

class ZipXamlExample
{
    class CollectedXamlSaver : public IXamlOutputSaver
    {
    public:
        using ArtifactDictionary = Dictionary<String, ArrayPtr<uint8_t>>;
        SharedPtr<ArtifactDictionary> Artifacts = MakeObject<ArtifactDictionary>(StringComparer::get_Ordinal());

        void Save(String path, ArrayPtr<uint8_t> data) override
        {
            auto retainedData = data->Clone();
            Artifacts->Add(path, retainedData);
        }
    };

public:
    static void Run()
    {
        auto saver = MakeObject<CollectedXamlSaver>();
        auto presentation = MakeObject<Presentation>(u"pres.pptx");
        auto options = MakeObject<XamlOptions>();
        options->set_OutputSaver(saver);
        options->set_ExportHiddenSlides(false);
        presentation->Save(options);

        auto entries = MakeObject<Dictionary<String, ArrayPtr<uint8_t>>>(StringComparer::get_OrdinalIgnoreCase());
        for (const auto& artifact : saver->Artifacts)
        {
            auto entryName = artifact.get_Key().Replace(u'\\', u'/');
            auto segments = entryName.Split(u'/');
            auto unsafeName = entryName.StartsWith(u"/", StringComparison::Ordinal) || entryName.Contains(u":");
            for (const auto& segment : segments)
            {
                unsafeName |= String::IsNullOrWhiteSpace(segment) || segment == u"." || segment == u"..";
            }

            if (unsafeName || entries->ContainsKey(entryName))
            {
                Console::WriteLine(u"Export rejected: unsafe or duplicate artifact name: {0}", artifact.get_Key());
                return;
            }
            entries->Add(entryName, artifact.get_Value());
        }

        auto jobId = Guid::NewGuid();
        auto archivePath = u"xaml-" + jobId.ToString(u"N") + u".zip";
        auto archive = MakeObject<ZipFile>();
        for (const auto& artifact : entries)
        {
            auto fileName = Path::GetFileName(artifact.get_Key());
            auto directoryName = Path::GetDirectoryName(artifact.get_Key()).Replace(u'\\', u'/');
            archive->AddEntry(fileName, directoryName, artifact.get_Value());
        }

        auto output = MakeObject<FileStream>(archivePath, FileMode::CreateNew, FileAccess::Write);
        archive->Save(output);
        output->Close();
        archive->Dispose();

        // Η αποθήκευση ολοκληρώνει τον κατάλογο ZIP· κλείστε το αρχείο πριν αναφέρετε την επιτυχία.
        Console::WriteLine(u"Saved {0} artifacts to {1}", entries->get_Count(), archivePath);
    }
};
```

Καλέστε τη μέθοδο `ZipXamlExample::Run` από την εφαρμογή σας. Το παράδειγμα χρησιμοποιεί το `Aspose::Zip::ZipFile` του περιβάλλοντος C++ για να γράψει ένα τοπικό αρχείο ZIP· ο εξαγωγέας δεν γράφει ξεχωριστά αρχεία XAML ή εικόνας. Για αποθήκευση απομακρυσμένα, αντικαταστήστε το στάδιο εγγραφής του αρχείου με μεταφορτώσεις των συλλεγμένων πινάκων byte. Χρησιμοποιήστε ένα αναγνωριστικό εργασίας εξαγωγής συν τον πλήρη σχετικό όρο αρχείου ως κλειδί blob, ή αποθηκεύστε το αναγνωριστικό, το σχετικό όνομα και τα δυαδικά δεδομένα σε μια γραμμή βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο αφού ολοκληρωθούν όλες οι μεταφορτώσεις ή η συναλλαγή της βάσης δεδομένων ολοκληρωθεί. Καθαρίστε τμηματική έξοδο αν η αποθήκευση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να αποθηκεύει κάθε αρχείο απευθείας στην αποθήκη της εφαρμογής ώστε να αποφεύγεται η διατήρηση ενός επιπλέον αντιγράφου της πλήρους εξαγωγής στη μνήμη. Ο εξαγωγέας εξακολουθεί να συλλέγει όλα τα παραγόμενα αρχεία στη μνήμη πριν καλέσει τον αποθηκευτή. Κρατήστε κάθε callback συγχρονισμένο από την άποψη του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός έχει αποδεχθεί τα byte και επιτρέψτε τις αποτυχίες να φτάσουν στον καλούντα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τα διαχωριστικά διαδρομών όταν απαιτείται από τον προορισμό, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το [Path::GetFileName](https://reference.aspose.com/slides/el/cpp/system.io/path/getfilename/) εκτός αν κάθε παραγόμενο όνομα είναι γνωστό ότι είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονομάτων ειδική για τον προορισμό. Όταν γράφετε ξεχωριστά αρχεία, απορρίψτε διαδρόμους που ξεκινούν από ρίζα και τμήματα διαδρομής, επιλύστε τον προορισμό με το [Path::GetFullPath](https://reference.aspose.com/slides/el/cpp/system.io/path/getfullpath/), και βεβαιωθείτε ότι παραμένει κάτω από τον προοριζόμενο φάκελο εξαγωγής, συμπεριλαμβανομένου του διαχωριστή φακέλου στον έλεγχο περιεχομένου. Χρησιμοποιήστε έναν φάκελο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς συνδέσμους που θα μπορούσαν να αναπροσανατολίσουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας πεζών-κεφαλαίων του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και επιθεωρήστε τις αναφορές πόρων βάσει αρχείου, όπως τα χαρακτηριστικά `Source` ή `ImageSource` εικόνας. Επίλυση κάθε σχετικού URI έναντι του καταλόγου του περιέχοντος αρχείου XAML, κανονικοποίηση του προκύπτοντος ονόματος αποθήκευσης και επιβεβαίωση ότι το αντίστοιχο κλειδί λεξικού, η καταχώρηση ZIP ή το αποθηκευμένο αντικείμενο υπάρχει. Θεωρήστε ξεχωριστά τις εξωτερικές URI και τις εκφράσεις σήμανσης XAML από τα ονόματα αρχείων.

Για παράδειγμα, αν το `pres/Slide_1.xaml` αναφέρει `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα διακόψει αυτή τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα της εργασίας και κάντε αυτά τα URLs πόρων προσβάσιμα στον καταναλωτή XAML. Ανοίξτε ξανά το τελικό ZIP για να επαληθεύσετε τα ονόματα των καταχωρίσεων και τα byte των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο στόχο XAML για να βεβαιωθείτε ότι οι εικόνες επιλύονται σωστά.

## **FAQ**

**Πώς μπορώ να εξασφαλίσω προβλέψιμες γραμματοσειρές αν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο σύστημα;**

Χρησιμοποιήστε το [set_DefaultRegularFont](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) στο [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/) — χρησιμοποιείται ως εφεδρική γραμματοσειρά κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει την εφεδρική γραμματοσειρά ή ότι η γραμματοσειρά θα είναι διαθέσιμη στο τελικό μηχάνημα. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται από το XAML είναι διαθέσιμες στο περιβάλλον προβολής.

**Απευθύνεται το εξαγόμενο XAML μόνο στο WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο στοχευμένο περιβάλλον σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την προεπιλεγμένη εξαγωγή τους;**

Από προεπιλογή, οι κρυφές διαφάνειες δεν συμπεριλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [set_ExportHiddenSlides](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) στο [XamlOptions](https://reference.aspose.com/slides/el/cpp/aspose.slides.export.xaml/xamloptions/) — κρατήστε το απενεργοποιημένο εάν δεν χρειάζεστε την εξαγωγή τους.