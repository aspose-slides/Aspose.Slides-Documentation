---
title: Διαχείριση Προειδοποιήσεων Παρουσίασης σε C++
type: docs
weight: 70
url: /el/cpp/presentation-warnings/
aliases:
- /cpp/λήψη-προειδοποιήσεων-κλήσεων-για-αντικατάσταση-γραμματοσειρών-στο-aspose-slides/
keywords:
- κλήση προειδοποίησης
- πολιτική προειδοποίησης
- απώλεια δεδομένων
- καταστροφή πηγής
- ζήτημα συμβατότητας
- αντικατάσταση γραμματοσειράς
- ψηφιακή υπογραφή
- φόρτωση παρουσίασης
- απόδοση παρουσίασης
- μετατροπή παρουσίασης
- αποθήκευση παρουσίασης
- PowerPoint
- OpenDocument
- C++
- Aspose.Slides
description: "Μάθετε πώς να συλλέγετε, να κατηγοριοποιείτε και να ενεργείτε σε προειδοποιήσεις κατά τη φόρτωση, την απόδοση, τη μετατροπή και την αποθήκευση παρουσιάσεων με το Aspose.Slides για C++."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναφέρει ανακτήσιμα προβλήματα κατά τη φόρτωση, την απόδοση, τη μετατροπή ή την αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένα αρχεία πηγής, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειράς και περιορισμούς του μορφότυπου προορισμού. Μια συνάρτηση κλήσης προειδοποίησης επιτρέπει σε μια εφαρμογή να καταγράφει αυτές τις συνθήκες και να αποφασίζει εάν η τρέχουσα λειτουργία μπορεί να συνεχιστεί.

Εφαρμόστε τη διεπαφή [IWarningCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/iwarningcallback/) και εξετάστε τις μεθόδους [IWarningInfo::get_WarningType](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/iwarninginfo/get_warningtype/) και [IWarningInfo::get_Description](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/iwarninginfo/get_description/) που παρέχονται μέσω του [IWarningInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/iwarninginfo/). Επιστρέψτε το [ReturnAction::Continue](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/returnaction/) για να αποδεχθείτε την προειδοποίηση ή `ReturnAction::Abort` για να διακόψετε τη λειτουργία.

Χρησιμοποιήστε το [LoadOptions::set_WarningCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides/loadoptions/set_warningcallback/) για προειδοποιήσεις που εμφανίζονται κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις επιλογών απόδοσης και εξαγωγής κληρονομούν το [SaveOptions::set_WarningCallback](https://reference.aspose.com/slides/el/cpp/aspose.slides.export/saveoptions/set_warningcallback/), το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφάνειας, τη μετατροπή και την αποθήκευση. Δεδομένου ότι η προειδοποίηση δεν προσδιορίζει τη λειτουργία της εφαρμογής, συσχετίστε κάθε παρουσία κλήσης με ένα στάδιο λειτουργίας όταν δημιουργείτε μια ενιαία αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Μια προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακάμψει εάν η κλήση επιστρέψει `ReturnAction::Continue`. Μια εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να επεξεργαστούν από πολιτική προειδοποίησης.

Η επιστροφή `ReturnAction::Abort` ζητά από το σύστημα διανομής προειδοποιήσεων να τερματίσει τη τρέχουσα λειτουργία ρίχνοντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και το μορφότυπο παρουσίασης. Για παράδειγμα, η φόρτωση μπορεί να προκαλέσει μια [PptxReadException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxreadexception/) ή [PptReadException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptreadexception/), ενώ η αποθήκευση ή εξαγωγή μπορεί να προκαλέσει μια [PptxException](https://reference.aspose.com/slides/el/cpp/aspose.slides/pptxexception/). Χειριστείτε την εξαίρεση στο όριο της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποιήσεων για να καθορίσετε εάν η πολιτική της εφαρμογής προκάλεσε τον τερματισμό, αντί να βασίζεστε σε έναν υποτύπο εξαίρεσης ή σε μήνυμα. Η κλήση καταγράφει την προειδοποίηση πριν επιστρέψει `ReturnAction::Abort`, διασφαλίζοντας ότι ο λόγος παραμένει διαθέσιμος στην εφαρμογή.

## **Κατηγορίες Προειδοποιήσεων**

Η απαρίθμηση [WarningType](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/warningtype/) παρέχει τις παρακάτω κατηγορίες:

| Τύπος προειδοποίησης | Σημασία | Τυπική πολιτική |
| --- | --- | --- |
| `SourceFileCorruption` | Η παρουσίαση πηγής περιέχει ζημιά που μπορεί να καταστήσει αχρήστο ένα έγγραφο αποθηκευμένο στην αρχική του μορφή. | Διακοπή. |
| `DataLoss` | Κείμενο, διαγράμματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή αποθήκευση. | Διακοπή. |
| `MajorFormattingLoss` | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Διακοπή σε αυστηρή λειτουργία επικύρωσης· διαφορετικά καταγραφή και συνέχεια. |
| `MinorFormattingLoss` | Μπορεί να παρουσιαστεί περιορισμένη διαφορά μορφοποίησης. | Καταγραφή για διάγνωση και συνέχεια. |
| `CompatibilityIssue` | Το αποτέλεσμα μπορεί να μην ανοίξει ή να συμπεριφέρεται σωστά σε ορισμένες εφαρμογές ή παλαιότερες εκδόσεις. | Καταγραφή και συνέχεια εκτός εάν η συμβατότητα είναι υποχρεωτική. |
| `UnexpectedContent` | Η πηγή περιέχει μη υποστηριζόμενο ή μη αναγνωρισμένο περιεχόμενο του οποίου η επίδραση ενδέχεται να μην είναι ακόμη γνωστή. | Καταγραφή και συνέχεια, ή αντιμετώπιση ως σφάλμα σε αυστηρή πολιτική. |

Η κατηγορία πρέπει να καθοδηγεί την απόφαση πολιτικής. Αποθηκεύστε την περιγραφή της προειδοποίησης για διάγνωση, αλλά μην βασίζεστε στη διατύπωσή της για λογική της εφαρμογής, επειδή το κείμενο μπορεί να διαφέρει μεταξύ σεναρίων προειδοποίησης και εκδόσεων του προϊόντος.

## **Συλλογή και Κατάταξη Προειδοποιήσεων**

Το παρακάτω παράδειγμα χρησιμοποιεί μία αναφορά επιπέδου εφαρμογής για ολόκληρη τη σειρά επεξεργασίας. Ένα ξεχωριστό αντικείμενο κλήσης ετικετοφορεί τις προειδοποιήσεις από τη φόρτωση, την απόδοση, τη μετατροπή σε PDF και την αποθήκευση PPTX. Η πολιτική διακόπτει σε περίπτωση ζημιάς πηγής ή απώλειας δεδομένων, προαιρετικά διακόπτει σε περίπτωση μεγάλης απώλειας μορφοποίησης και συνεχίζει για άλλες προειδοποιήσεις.

```cpp
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/PptxOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/exception.h>
#include <system/scope_guard.h>
#include <system/smart_ptr.h>
#include <system/string.h>
#include <memory>
#include <vector>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

struct WarningEntry
{
    String Stage;
    WarningType Type;
    String Description;
};

class WarningReport
{
public:
    const std::vector<WarningEntry>& GetEntries() const
    {
        return entries;
    }

    void Add(const String& stage, const SharedPtr<IWarningInfo>& warning)
    {
        entries.push_back({stage, warning->get_WarningType(), warning->get_Description()});
    }

private:
    std::vector<WarningEntry> entries;
};

class WarningPolicy
{
public:
    explicit WarningPolicy(bool abortOnMajorFormattingLoss)
        : abortOnMajorFormattingLoss(abortOnMajorFormattingLoss)
    {
    }

    ReturnAction GetAction(WarningType warningType) const
    {
        if (warningType == WarningType::SourceFileCorruption || warningType == WarningType::DataLoss)
        {
            return ReturnAction::Abort;
        }

        if (warningType == WarningType::MajorFormattingLoss && abortOnMajorFormattingLoss)
        {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }

private:
    bool abortOnMajorFormattingLoss;
};

class ReportingWarningCallback : public IWarningCallback
{
public:
    ReportingWarningCallback(const String& stage, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
        : stage(stage), report(report), policy(policy)
    {
    }

    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        report->Add(stage, warning);
        return policy.GetAction(warning->get_WarningType());
    }

private:
    String stage;
    std::shared_ptr<WarningReport> report;
    WarningPolicy policy;
};

class PresentationWarningExample
{
public:
    static void Run()
    {
        auto report = std::make_shared<WarningReport>();
        auto policy = WarningPolicy(true);
        auto completed = ProcessPresentation(u"input.pptx", report, policy);

        Console::WriteLine(completed ? u"Processing completed." : u"Processing stopped.");

        for (const auto& entry : report->GetEntries())
        {
            Console::WriteLine(u"[{0}] {1}: {2}", entry.Stage, entry.Type, entry.Description);
        }
    }

private:
    static bool ProcessPresentation(const String& inputPath, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto loadOptions = MakeObject<LoadOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Loading", report, policy);
            loadOptions->set_WarningCallback(callback);

            auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
            auto cleanup = MakeScopeGuard([&presentation] { presentation->Dispose(); });

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Loading stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool RenderFirstSlide(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            if (presentation->get_Slides()->get_Count() == 0)
            {
                Console::WriteLine(u"Rendering stopped: the presentation has no slides.");
                return false;
            }

            auto options = MakeObject<RenderingOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Rendering", report, policy);
            options->set_WarningCallback(callback);

            auto image = presentation->get_Slide(0)->GetImage(options);
            auto cleanup = MakeScopeGuard([&image] { image->Dispose(); });
            image->Save(u"slide-1.png", ImageFormat::Png);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Rendering stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool ConvertToPdf(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PdfOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Conversion", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"converted.pdf", SaveFormat::Pdf, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Conversion stopped: {0}", exception->get_Message());
            return false;
        }
    }

    static bool SaveValidatedCopy(const SharedPtr<Presentation>& presentation, const std::shared_ptr<WarningReport>& report, const WarningPolicy& policy)
    {
        try
        {
            auto options = MakeObject<PptxOptions>();
            auto callback = MakeObject<ReportingWarningCallback>(u"Saving", report, policy);
            options->set_WarningCallback(callback);

            presentation->Save(u"validated-output.pptx", SaveFormat::Pptx, options);
            return true;
        }
        catch (Exception& exception)
        {
            Console::WriteLine(u"Saving stopped: {0}", exception->get_Message());
            return false;
        }
    }
};

PresentationWarningExample::Run();
```

Ορίστε `abortOnMajorFormattingLoss` στο `false` όταν οι μεγάλες διαφορές μορφοποίησης θεωρούνται αποδεκτές. Τα ζητήματα συμβατότητας, η μικρή απώλεια μορφοποίησης και το απρόσμενο περιεχόμενο παραμένουν στην αναφορά ακόμη και όταν η λειτουργία συνεχίζεται. Επεκτείνετε το `WarningPolicy::GetAction` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποίησης**

Οι προειδοποιήσεις μπορούν να εμφανιστούν σε διάφορα στάδια μιας ροής εργασίας:

- **Ψηφιακές υπογραφές:** Μια υπογεγραμμένη παρουσίαση μπορεί να παράγει προειδοποίηση κατά τη φόρτωση ότι η υπογραφή της θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτήν την κατάσταση `DataLoss` μέσω του [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/ipresentationsignedwarninginfo/). Μια κλήση στα στάδια φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχθεί ρητά την αναφερόμενη απώλεια.
- **Αντικατάσταση γραμματοσειράς:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί κατά την απόδοση ή εξαγωγή μιας διαφάνειας. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, έτσι η αυστηρή πολιτική παραπάνω διακόπτει ακόμη και αν η εφαρμογή θεωρούσε την αντικατάσταση οπτικά αποδεκτή. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά μη διαθέσιμη στο χρόνο εκτέλεσης. Η περιγραφή της προειδοποίησης ταυτοποιεί την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή [κανόνες αντικατάστασης γραμματοσειρών](/slides/el/cpp/font-substitution/) πριν ξαναπροσπαθήσετε.
- **Μη υποστηριζόμενο ή απρόσμενο περιεχόμενο:** Ένας φορτωτής μπορεί να συναντήσει αρχεία παρουσίασης ή λειτουργίες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν `UnexpectedContent` ή μια πιο σοβαρή κατηγορία όταν τα δεδομένα ή η μορφοποίηση είναι γνωστό ότι επηρεάζονται.
- **Συμβατότητα μορφότυπου:** Η αποθήκευση σε διαφορετικό μορφότυπο παρουσίασης μπορεί να παραλείψει λειτουργίες ή να παράγει αποτέλεσμα που συμπεριφέρεται διαφορετικά σε ορισμένες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερους από οκτώ οριζόντιους ή κάθετους οδηγούς σχεδίασης σε παλαιό PPT αναφέρει `CompatibilityIssue`. Η κλήση στα στάδια αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να την απορρίψει εάν απαιτείται η διατήρηση όλων των οδηγών.
- **Συμπεριφορά φόρτωσης:** Οι επιλογές φόρτωσης και οι παλαιότερες συμπεριφορές μπορούν επίσης να παράγουν προειδοποιήσεις. Για παράδειγμα, το [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/el/cpp/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) εντοπίζει τη χρήση μιας παρωχημένης συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το έγγραφο πηγής, το μορφότυπο προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην υποθέτετε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μία μόνο κατηγορία.

## **Ασφαλής Διαχείριση Ακυρωμένων Λειτουργιών**

Όταν μια κλήση επιστρέψει `ReturnAction::Abort`, μην χρησιμοποιείτε ένα αντικείμενο που απέτυχε να φορτωθεί και μην υποθέτετε ότι η έξοδος απόδοσης ή αποθήκευσης είναι πλήρης. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία ενός αρχείου εξόδου αλλά πριν ολοκληρωθεί.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε ξεχωριστό μονοπάτι, π.χ. `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο αφού η λειτουργία ολοκληρωθεί επιτυχώς, η αναφορά προειδοποιήσεων ικανοποιήσει την πολιτική της εφαρμογής και το αρχείο μπορεί να ανοίξει και να ελεγχθεί. Αυτό αποτρέπει την αντικατάσταση ενός έγκυρου αρχείου πηγής με ένα μερικό ή απορριφθέν αποτέλεσμα.

Μια κενή αναφορά προειδοποιήσεων δεν αποτελεί εγγύηση ότι κάθε δυνατότητα της πηγής διατηρήθηκε. Εφαρμόστε τυχόν επιπλέον ελέγχους περιεχομένου και οπτικούς ελέγχους που απαιτούνται από την εφαρμογή. Δείτε επίσης [Άνοιγμα Παρουσιάσεων](/slides/el/cpp/open-presentation/) και [Αποθήκευση Παρουσιάσεων](/slides/el/cpp/save-presentation/).

## **FAQ**

**Μπορεί μια συνάρτηση κλήσης προειδοποίησης να χειριστεί κάθε σφάλμα του Aspose.Slides;**

Όχι. Αντιμετωπίζει μόνο ανακτήσιμες συνθήκες που αναφέρονται ως προειδοποιήσεις. Εξαιρέσεις που εμφανίζονται ανεξάρτητα από τη κλήση πρέπει να διαχειριστούν από την εφαρμογή γύρω από την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Η επιστροφή `ReturnAction::Continue` εγγυάται το ίδιο αποτέλεσμα;**

Όχι. Επιτρέπει μόνο τη συνέχιση της επεξεργασίας. Η αναφερόμενη κατάσταση μπορεί ακόμη να προκαλέσει διαφορές δεδομένων, μορφοποίησης ή συμβατότητας, επομένως ελέγξτε τους συλλεγμένους τύπους και περιγραφές προειδοποιήσεων.

**Πώς μπορεί μια εφαρμογή να προσδιορίσει τη λειτουργία που παρήγαγε μια προειδοποίηση;**

Δημιουργήστε μια παρουσία κλήσης για κάθε λειτουργία και αποθηκεύστε ένα στάδιο που ορίζεται από την εφαρμογή μαζί με τον τύπο και την περιγραφή της προειδοποίησης, όπως φαίνεται στο παράδειγμα.