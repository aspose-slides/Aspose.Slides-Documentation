---
title: "Διαχείριση Προειδοποιήσεων Παρουσίασης σε .NET"
type: docs
weight: 120
url: /el/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- "callback προειδοποίησης"
- "πολιτική προειδοποίησης"
- "απώλεια δεδομένων"
- "φθορά πηγής"
- "ζήτημα συμβατότητας"
- "αντικατάσταση γραμματοσειράς"
- "ψηφιακή υπογραφή"
- "φόρτωση παρουσίασης"
- "απόδοση παρουσίασης"
- "μετατροπή παρουσίασης"
- "αποθήκευση παρουσίασης"
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να συλλέγετε, κατηγοριοποιείτε και αντιμετωπίζετε τις προειδοποιήσεις κατά τη φόρτωση, απόδοση, μετατροπή και αποθήκευση παρουσιάσεων με το Aspose.Slides για .NET."
---
## **Επισκόπηση**

Το Aspose.Slides μπορεί να αναφέρει ανακτήσιμα προβλήματα κατά τη φόρτωση, απόδοση, μετατροπή ή αποθήκευση μιας παρουσίασης. Παραδείγματα περιλαμβάνουν κατεστραμμένα αρχεία πηγής, περιεχόμενο που δεν μπορεί να διατηρηθεί, αντικατάσταση γραμματοσειράς και περιορισμούς του μορφότυπου προορισμού. Ένα callback προειδοποίησης επιτρέπει στην εφαρμογή να καταγράψει αυτές τις συνθήκες και να αποφασίσει εάν η τρέχουσα λειτουργία μπορεί να συνεχιστεί.

Εφαρμόστε το [IWarningCallback](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/iwarningcallback/) interface και εξετάστε τις ιδιότητες [WarningType](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/iwarninginfo/warningtype/) και [Description](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/iwarninginfo/description/) που παρέχονται μέσω του [IWarningInfo](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/iwarninginfo/). Επιστρέψτε το [ReturnAction.Continue](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/returnaction/) για αποδοχή της προειδοποίησης ή `ReturnAction.Abort` για διακοπή της λειτουργίας.

Χρησιμοποιήστε το [LoadOptions.WarningCallback](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/warningcallback/) για προειδοποιήσεις που προκύπτουν κατά το άνοιγμα μιας παρουσίασης. Οι κλάσεις ρυθμίσεων απόδοσης και εξαγωγής κληρονομούν το [SaveOptions.WarningCallback](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/warningcallback/), το οποίο λαμβάνει προειδοποιήσεις από την απόδοση διαφανειών, τη μετατροπή και την αποθήκευση. Επειδή η προειδοποίηση δεν προσδιορίζει τη λειτουργία της εφαρμογής, συσχετίστε κάθε instance του callback με ένα στάδιο λειτουργίας όταν δημιουργείτε μια συνδυαστική αναφορά.

## **Προειδοποιήσεις και Εξαιρέσεις**

Μια προειδοποίηση περιγράφει μια κατάσταση από την οποία το Aspose.Slides μπορεί να ανακάμψει εφόσον το callback επιστρέψει `ReturnAction.Continue`. Μία εξαίρεση σημαίνει ότι η ζητούμενη λειτουργία δεν μπορεί να ολοκληρωθεί κανονικά· οι εξαιρέσεις δεν μετατρέπονται σε προειδοποιήσεις και δεν μπορούν να διαχειριστούν από πολιτική προειδοποίησης.

Η επιστροφή του `ReturnAction.Abort` ζητά από το διαχειριστή προειδοποιήσεων να τερματίσει τη λειτουργία εγείροντας μια εξαίρεση. Η δημόσια εξαίρεση εξαρτάται από τη λειτουργία και το μορφότυπο παρουσίασης. Για παράδειγμα, κατά τη φόρτωση μπορεί να εμφανιστεί η [PptxReadException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxreadexception/) ή η [PptReadException](https://reference.aspose.com/slides/el/net/aspose.slides/pptreadexception/), ενώ κατά την αποθήκευση ή εξαγωγή μπορεί να εμφανιστεί η [PptxException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxexception/). Διαχειριστείτε την εξαίρεση στα όρια της λειτουργίας και χρησιμοποιήστε την αναφορά προειδοποιήσεων για να καθορίσετε εάν η πολιτική της εφαρμογής προκάλεσε τον τερματισμό, αντί να βασίζεστε μόνο σε έναν τύπο εξαίρεσης ή μήνυμα. Το callback καταγράφει την προειδοποίηση πριν επιστρέψει `ReturnAction.Abort`, διασφαλίζοντας ότι το αίτιο παραμένει διαθέσιμο στην εφαρμογή.

## **Κατηγορίες Προειδοποιήσεων**

Η απαρίθμηση [WarningType](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/warningtype/) παρέχει τις παρακάτω κατηγορίες:

| Τύπος προειδοποίησης | Σημασία | Τυπική πολιτική |
| --- | --- | --- |
| `SourceFileCorruption` | Η πηγή της παρουσίασης περιέχει φθορές που μπορούν να κάνουν ένα έγγραφο αποθηκευμένο στο αρχικό του μορφότυπο αχρησιμοποίητο. | Απόρριψη. |
| `DataLoss` | Κείμενο, διαγράμματα, εικόνες ή άλλα δεδομένα μπορεί να λείπουν μετά τη φόρτωση ή αποθήκευση. | Απόρριψη. |
| `MajorFormattingLoss` | Η παρουσίαση μπορεί να χάσει σημαντική μορφοποίηση. | Απόρριψη σε αυστηρή λειτουργία επικύρωσης· διαφορετικά καταγραφή και συνέχεια. |
| `MinorFormattingLoss` | Μπορεί να εμφανιστεί περιορισμένη διαφορά μορφοποίησης. | Καταγραφή για διαγνωστικούς σκοπούς και συνέχεια. |
| `CompatibilityIssue` | Το αποτέλεσμα μπορεί να μην ανοίξει ή να λειτουργήσει σωστά σε ορισμένες εφαρμογές ή παλαιότερες εκδόσεις. | Καταγραφή και συνέχεια εκτός εάν η συμβατότητα είναι υποχρεωτική. |
| `UnexpectedContent` | Η πηγή περιέχει περιεχόμενο που δεν υποστηρίζεται ή δεν αναγνωρίζεται και το αποτέλεσμα μπορεί ακόμη να μην είναι γνωστό. | Καταγραφή και συνέχεια ή αντιμετώπιση ως σφάλμα σε αυστηρή πολιτική. |

Η κατηγορία πρέπει να καθοδηγεί την απόφαση πολιτικής. Αποθηκεύστε το `Description` για διαγνωστικούς σκοπούς, αλλά μην βασίζεστε στην ακριβή διατύπωση του για λογική εφαρμογής, καθώς το κείμενο του μηνύματος μπορεί να διαφέρει μεταξύ σεναρίων προειδοποίησης και εκδόσεων προϊόντος.

## **Συλλογή και Κατηγοριοποίηση Προειδοποιήσεων**

Το παρακάτω παράδειγμα χρησιμοποιεί μια αναφορά επιπέδου εφαρμογής για ολόκληρη τη γραμμή επεξεργασίας. Ένα ξεχωριστό instance του callback ετικετοφορεί τις προειδοποιήσεις από φόρτωση, απόδοση, μετατροπή PDF και αποθήκευση PPTX. Η πολιτική απορρίπτει σε περίπτωση φθοράς πηγής ή απώλειας δεδομένων, προαιρετικά απορρίπτει σε περίπτωση σοβαρής απώλειας μορφοποίησης και συνεχίζει για τις υπόλοιπες προειδοποιήσεις.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

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
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Ορίστε το `abortOnMajorFormattingLoss` σε `false` όταν οι μεγάλες διαφορές μορφοποίησης είναι αποδεκτές. Τα ζητήματα συμβατότητας, οι μικρές απώλειες μορφοποίησης και το μη αναμενόμενο περιεχόμενο παραμένουν στην αναφορά ακόμη και όταν η λειτουργία συνεχίζει. Επεκτείνετε το `WarningPolicy.GetAction` εάν η εφαρμογή πρέπει να απορρίψει οποιαδήποτε από αυτές τις κατηγορίες.

## **Κοινά Σενάρια Προειδοποίησης**

Οι προειδοποιήσεις μπορούν να εμφανιστούν σε διαφορετικά στάδια μιας ροής εργασίας:

- **Digital signatures:** Μια υπογεγραμμένη παρουσίαση μπορεί να παράγει προειδοποίηση κατά τη φόρτωση ότι η υπογραφή της θα χαθεί κατά την επεξεργασία. Το Aspose.Slides αναφέρει αυτή την κατάσταση `DataLoss` μέσω του [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Ένα callback στο στάδιο φόρτωσης επιτρέπει στην εφαρμογή να απορρίψει το αρχείο ή να αποδεχθεί ρητά την αναφερθέντα απώλεια.
- **Font substitution:** Μια μη διαθέσιμη γραμματοσειρά μπορεί να αντικατασταθεί ενώ μια διαφάνεια αποδίδεται ή εξάγεται. Οι προειδοποιήσεις αντικατάστασης γραμματοσειράς αναφέρονται ως `DataLoss`, οπότε η αυστηρή πολιτική παραπάνω απορρίπτει ακόμη και αν η εφαρμογή θεωρεί την αντικατάσταση αποδεκτή οπτικά. Για να παρατηρήσετε αυτή τη συμπεριφορά, χρησιμοποιήστε μια παρουσίαση εισόδου που περιέχει κείμενο σε γραμματοσειρά μη διαθέσιμη στο runtime. Η περιγραφή της προειδοποίησης προσδιορίζει την αντικατάσταση· ρυθμίστε τις απαιτούμενες γραμματοσειρές ή τους [font substitution rules](/slides/el/net/font-substitution/) πριν προσπαθήσετε ξανά.
- **Unsupported or unexpected content:** Ένας φορτωτής μπορεί να βρει εγγραφές παρουσίασης ή δυνατότητες που δεν αναγνωρίζει. Τέτοιες προειδοποιήσεις μπορεί να χρησιμοποιούν το `UnexpectedContent`, ή μια πιο σοβαρή κατηγορία όταν είναι γνωστό ότι επηρεάζονται δεδομένα ή μορφοποίηση.
- **Format compatibility:** Η αποθήκευση σε διαφορετικό μορφότυπο παρουσίασης μπορεί να παραλείψει δυνατότητες ή να παράγει αποτέλεσμα που συμπεριφέρεται διαφορετικά σε ορισμένες εφαρμογές. Για παράδειγμα, η αποθήκευση μιας παρουσίασης με περισσότερους από οκτώ οριζόντιους ή κάθετους οδηγούς σχεδίασης σε παλαιό PPT αναφέρει `CompatibilityIssue`. Το callback στο στάδιο αποθήκευσης μπορεί να καταγράψει την απώλεια και να συνεχίσει, ή να την απορρίψει εάν η διατήρηση όλων των οδηγών είναι απαραίτητη.
- **Loading behavior:** Οι επιλογές φόρτωσης και οι παλιές συμπεριφορές μπορούν επίσης να παράγουν προειδοποιήσεις. Για παράδειγμα, το [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/el/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) εντοπίζει τη χρήση μιας παρωχημένης συμπεριφοράς κλειδώματος παρουσίασης ως `CompatibilityIssue`.

Οι προειδοποιήσεις εξαρτώνται από το έγγραφο πηγής, τον μορφότυπο προορισμού, τη λειτουργία και την έκδοση του Aspose.Slides. Μην θεωρείτε ότι κάθε αρχείο παράγει προειδοποίηση ή ότι ένα σενάριο αντιστοιχεί πάντα σε μία μόνο κατηγορία.

## **Ασφαλής Διαχείριση Απορριπτόμενων Λειτουργιών**

Όταν ένα callback επιστρέφει `ReturnAction.Abort`, μην χρησιμοποιήσετε ένα αντικείμενο που δεν φορτώθηκε και μην υποθέτετε ότι η απόδοση ή το αποθηκευμένο αποτέλεσμα είναι πλήρες. Η λειτουργία μπορεί να τερματιστεί μετά τη δημιουργία ενός αρχείου εξόδου αλλά πριν ολοκληρωθεί η διαδικασία.

Αποθηκεύστε τα επικυρωμένα αποτελέσματα σε διαφορετική διαδρομή, όπως `validated-output.pptx`. Αντικαταστήστε μια υπάρχουσα παρουσίαση μόνο αφού η λειτουργία ολοκληρωθεί επιτυχώς, η αναφορά προειδοποιήσεων ικανοποιεί την πολιτική της εφαρμογής και το αποτέλεσμα μπορεί να ανοιχτεί και να ελεγχθεί. Αυτό αποτρέπει την αντικατάσταση ενός έγκυρου αρχείου πηγής με ένα μερικό ή απορριφθέν αποτέλεσμα.

Μια κενή αναφορά προειδοποίησης δεν αποτελεί εγγύηση ότι κάθε δυνατότητα πηγής διατηρήθηκε. Εφαρμόστε τυχόν πρόσθετους ελέγχους περιεχομένου και οπτικούς ελέγχους που απαιτούνται από την εφαρμογή. Δείτε επίσης το [Open Presentations](/slides/el/net/open-presentation/) και το [Save Presentations](/slides/el/net/save-presentation/).

## **ΣΥΧΝΟΤΕΡΕΣ ΕΡΩΤΗΣΕΙΣ (FAQ)**

**Μπορεί ένα callback προειδοποίησης να διαχειριστεί κάθε σφάλμα του Aspose.Slides;**

Όχι. Διαχειρίζεται μόνο τις ανακτήσιμες συνθήκες που αναφέρονται ως προειδοποιήσεις. Οι εξαιρέσεις που προκύπτουν ανεξάρτητα από το callback πρέπει να αντιμετωπιστούν από την εφαρμογή γύρω από την κλήση φόρτωσης, απόδοσης, μετατροπής ή αποθήκευσης.

**Εγγυάται η επιστροφή του `ReturnAction.Continue` την ταυτόσημη έξοδο;**

Όχι. Επιτρέπει μόνο τη συνέχιση της επεξεργασίας. Η αναφερθείσα κατάσταση μπορεί ακόμη να προκαλέσει διαφορές στα δεδομένα, τη μορφοποίηση ή τη συμβατότητα, επομένως εξετάστε τους τύπους προειδοποιήσεων και τις περιγραφές που συλλέχθηκαν.

**Πώς μπορεί μια εφαρμογή να αναγνωρίσει τη λειτουργία που παρήγαγε μια προειδοποίηση;**

Δημιουργήστε ένα instance του callback για κάθε λειτουργία και αποθηκεύστε ένα στάδιο ορισμένο από την εφαρμογή μαζί με το `WarningType` και το `Description`, όπως φαίνεται στο παράδειγμα.