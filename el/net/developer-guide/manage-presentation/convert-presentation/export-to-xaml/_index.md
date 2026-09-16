---
title: Export Presentations to XAML in .NET
linktitle: Presentation to XAML
type: docs
weight: 30
url: /el/net/export-to-xaml/
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
- .NET
- C#
- Aspose.Slides
description: "Μετατρέψτε διαφάνειες PowerPoint και OpenDocument σε XAML στο .NET χρησιμοποιώντας το Aspose.Slides—γρήγορη, χωρίς Office λύση που διατηρεί το σχεδιάσμα σας ανέπαφο."
---
## **Επισκόπηση**

Αυτό το άρθρο εξηγεί πώς να εξάγετε παρουσιάσεις PowerPoint σε XAML χρησιμοποιώντας το Aspose.Slides. Περιλαμβάνει σύντομη εισαγωγή στο XAML, δείχνει πώς να αποθηκεύσετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις και παρουσιάζει πώς να προσαρμόσετε την εξαγωγή μέσω [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/), συμπεριλαμβανομένης της εξαγωγής των κρυφών διαφανειών. Το άρθρο επίσης απαντά σε μερικές συχνές ερωτήσεις σχετικά με τις εναλλακτικές γραμματοσειρές, τη συμβατότητα των XAML στοίβων και τη συμπεριφορά της εξαγωγής κρυφών διαφανειών.

## **Σχετικά με το XAML**

Το XAML είναι μια γλώσσα σήμανσης βασισμένη σε XML που χρησιμοποιείται για την περιγραφή διεπαφών χρήστη σε πλαίσια όπως το WPF (Windows Presentation Foundation), το UWP (Universal Windows Platform) και το Xamarin.Forms.

Μπορείτε να δουλέψετε με αρχεία XAML σε οπτικό σχεδιαστή ή να γράψετε και να επεξεργαστείτε το σήμα άμεσα.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προεπιλεγμένες Ρυθμίσεις**

Το παρακάτω παράδειγμα C# δείχνει πώς να εξάγετε μια παρουσίαση σε XAML με τις προεπιλεγμένες ρυθμίσεις:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions();
presentation.Save(xamlOptions);
```

Προεπιλεγμένα, οι εξαγόμενες διαφάνειες αποθηκεύονται σε υποφάκελο `pres` του τρέχοντος καταλόγου εργασίας της διαδικασίας, όπως επιστρέφεται από [Directory.GetCurrentDirectory](https://learn.microsoft.com/en-us/dotnet/api/system.io.directory.getcurrentdirectory). Ο φάκελος δημιουργείται αυτόματα, και τυχόν απαιτούμενες εικόνες αποθηκεύονται εκεί επίσης.

Το όνομα του φακέλου εξόδου λαμβάνεται από το όνομα του αρχείου προέλευσης χωρίς την επέκτασή του. Για το `pres.pptx`, τα αρχεία εξόδου ονομάζονται `pres/Slide_1.xaml`, `pres/Slide_2.xaml` κ.λπ. Ακόμη και αν περάσετε απόλυτη διαδρομή στην είσοδο, ο φάκελος εξόδου δημιουργείται σχετικά με τον τρέχοντα κατάλογο εργασίας, όχι παράλληλα με το αρχείο εισόδου.

## **Εξαγωγή Παρουσιάσεων σε XAML με Προσαρμοσμένες Ρυθμίσεις**

Χρησιμοποιήστε τη διεπαφή [IXamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/ixamloptions/) για να ελέγξετε πώς το Aspose.Slides εξάγει μια παρουσίαση σε XAML.

Για να αποθηκεύσετε την έξοδο σε προσαρμοσμένη τοποθεσία, υλοποιήστε το [IXamlOutputSaver](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/ixamloutputsaver/) και ορίστε μια παρουσία της υλοποίησής σας στην ιδιότητα [OutputSaver](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/outputsaver/) του [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/).

Για να συμπεριλάβετε κρυφές διαφάνειες στην έξοδο XAML, ορίστε την ιδιότητα [ExportHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) σε `true`, όπως φαίνεται στο παρακάτω παράδειγμα C#:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

using var presentation = new Presentation("pres.pptx");
var xamlOptions = new XamlOptions { ExportHiddenSlides = true };
presentation.Save(xamlOptions);
```

## **Συλλογή Όλων των Δημιουργημένων Αρθρωμάτων XAML**

Μια εξαγωγή XAML μπορεί να δημιουργήσει ένα έγγραφο XAML για κάθε εξαγόμενη διαφάνεια καθώς και ξεχωριστές εικόνες και βοηθητικούς πόρους. Αντιστοιχίστε ένα προσαρμοσμένο [IXamlOutputSaver](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/ixamloutputsaver/) στο [XamlOptions.OutputSaver](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/outputsaver/) για να λαμβάνετε αυτά τα αρθρώματα αντί της προεπιλεγμένης αποθήκευσης στο σύστημα αρχείων. Ξεκινήστε την εξαγωγή με την καθορισμένη για XAML μέθοδο [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) που δέχεται επιλογές XAML.

### **Κατανόηση του Κύκλου Ζωής των Callback**

Ο εξαγωγέας καλεί το [IXamlOutputSaver.Save](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/ixamloutputsaver/save/) ξεχωριστά για κάθε δημιουργημένο άρθρωμα:

- `path` αναγνωρίζει το άρθρωμα και μπορεί να περιλαμβάνει σχετικούς καταλόγους. Διατηρήστε αυτή την πληροφορία γιατί το XAML μπορεί να αναφέρει πόρους με σχετικές διαδρομές.
- `data` περιέχει τα byte του αρθρωματος. Οι εικόνες και άλλοι δυαδικοί πόροι δεν πρέπει να αποκωδικοποιούνται ως κείμενο.
- Ο αποθηκευτής είναι υπεύθυνος για την διατήρηση ή την αποθήκευση των δεδομένων πριν επιστρέψει. Τα παραδείγματα αντιγράφουν κάθε πίνακα byte σε μνήμη που ανήκει στην εφαρμογή.
- Θεωρείστε την εξαγωγή επιτυχημένη μόνο όταν η λειτουργία αποθήκευσης της παρουσίασης ολοκληρωθεί και όλα τα callbacks έχουν ολοκληρωθεί επιτυχώς. Μην υποτιμάτε σφάλματα αποθήκευσης ή μην εκκινείτε αθέατες εγγραφές στο παρασκήνιο. Αν η αποθήκευση γίνει αργότερα, αναφέρετε την συνολική επιτυχία μόνο αφού ολοκληρωθεί και αυτό το βήμα.

[XamlOptions.ExportHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) εφαρμόζεται επίσης σε προσαρμοσμένο αποθηκευτή. Η προεπιλεγμένη τιμή του, `false`, εξαιρεί τα XAML έγγραφα κρυφών διαφανειών. Ορίζοντας το σε `true` τα συμπεριλαμβάνει μαζί με τυχόν πόρους που απαιτούνται για την εξαγωγή τους. Ο αριθμός των πόρων εξαρτάται από την παρουσίαση· μην υποθέτετε ένα callback ανά διαφάνεια ή μια σταθερή σειρά callbacks.

### **Εξαγωγή στη Μνήμη και Επιθεώρηση των Αρθρωμάτων**

Αυτό το πλήρες παράδειγμα φορτώνει το `pres.pptx`, συλλέγει κάθε άρθρωμα σε ένα [Dictionary<string, byte[]>](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2) και τυπώνει το όνομά του, τον τύπο και το μέγεθος σε byte. Διατηρεί ακριβώς τα παρεχόμενα ονόματα. Τα διπλότυπα ονόματα προκαλούν αποτυχία της συλλογής αντί να παρακάμπτουν αθόρυβα ένα άρθρωμα.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class InMemoryXamlExample
{
    public static void Run()
    {
        var saver = new MemoryXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = true };
        presentation.Save(options);

        bool inspectXamlText = false;
        foreach (var artifact in saver.Artifacts)
        {
            var extension = Path.GetExtension(artifact.Key).ToLowerInvariant();
            bool isXaml = extension == ".xaml";
            bool isImage = extension is ".png" or ".jpg" or ".jpeg" or ".gif" or ".bmp" or ".tif" or ".tiff" or ".svg";
            var kind = isXaml ? "slide XAML" : isImage ? "image" : "supporting resource";
            Console.WriteLine($"{artifact.Key}: {artifact.Value.Length} bytes ({kind})");

            // Αποκωδικοποίηση μόνο XAML και μόνο όταν απαιτείται κειμενική επιθεώρηση.
            if (isXaml && inspectXamlText)
            {
                var markup = Encoding.UTF8.GetString(artifact.Value);
                Console.WriteLine(markup);
            }
        }
    }

    private sealed class MemoryXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Καλέστε το `InMemoryXamlExample.Run` από την εφαρμογή σας. Οι έλεγχοι επέκτασης είναι χρήσιμοι για επιθεώρηση· διατηρήστε όλα τα άρθρωματα, συμπεριλαμβανομένων των άγνωστων τύπων πόρων. Αφήστε τα byte αμετάβλητα κατά την αποθήκευση ή τη μετάδοση. Χρησιμοποιήστε το [Encoding.UTF8.GetString](https://learn.microsoft.com/en-us/dotnet/api/system.text.encoding.getstring) μόνο για XAML που χρειάζεται επεξεργασία κειμένου.

### **Συμπίεση των Συλλεγμένων Αρθρωμάτων σε Αρχείο ZIP**

Αυτό το ανεξάρτητο παράδειγμα συλλέγει την εξαγωγή, επικυρώνει τα ονόματά της και γράφει τα αρχικά byte σε αρχείο ZIP. Ένα μοναδικό όνομα αρχειοθήκης χωρίζει ταυτόχρονες εργασίες εξαγωγής. Οι καταχωρίσεις ZIP χρησιμοποιούν μπροστιγές κάθετες τάξεις και διατηρούν τους σχετικούς καταλόγους. Μη ασφαλή ονόματα ή ονόματα που συγκρούονται μετά την κανονικοποίηση απορρίπτουν ολόκληρο το πακέτο πριν γραφτεί.

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Aspose.Slides;
using Aspose.Slides.Export.Xaml;

public static class ZipXamlExample
{
    public static void Run()
    {
        var saver = new CollectedXamlSaver();
        using var presentation = new Presentation("pres.pptx");
        var options = new XamlOptions { OutputSaver = saver, ExportHiddenSlides = false };
        presentation.Save(options);

        var entries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);
        foreach (var artifact in saver.Artifacts)
        {
            var entryName = artifact.Key.Replace('\\', '/');
            var segments = entryName.Split('/');
            bool unsafeName = entryName.StartsWith("/", StringComparison.Ordinal) || entryName.Contains(':');
            foreach (var segment in segments)
            {
                unsafeName |= string.IsNullOrWhiteSpace(segment) || segment == "." || segment == "..";
            }

            if (unsafeName || !entries.TryAdd(entryName, artifact.Value))
            {
                Console.WriteLine($"Export rejected: unsafe or duplicate artifact name: {artifact.Key}");
                return;
            }
        }

        var archivePath = $"xaml-{Guid.NewGuid():N}.zip";
        using (var output = new FileStream(archivePath, FileMode.CreateNew, FileAccess.Write))
        using (var archive = new ZipArchive(output, ZipArchiveMode.Create))
        {
            foreach (var artifact in entries)
            {
                var entry = archive.CreateEntry(artifact.Key, CompressionLevel.Optimal);
                using var entryStream = entry.Open();
                entryStream.Write(artifact.Value, 0, artifact.Value.Length);
            }
        }

        // Ο φάκελος ZIP έχει ολοκληρωθεί με την αποδέσμευση πριν αναφερθεί η επιτυχία.
        Console.WriteLine($"Saved {entries.Count} artifacts to {archivePath}");
    }

    private sealed class CollectedXamlSaver : IXamlOutputSaver
    {
        public Dictionary<string, byte[]> Artifacts { get; } = new Dictionary<string, byte[]>(StringComparer.Ordinal);

        public void Save(string path, byte[] data)
        {
            var retainedData = (byte[])data.Clone();
            Artifacts.Add(path, retainedData);
        }
    }
}
```

Καλέστε το `ZipXamlExample.Run` από την εφαρμογή σας. Το παράδειγμα χρησιμοποιεί το [ZipArchive](https://learn.microsoft.com/en-us/dotnet/api/system.io.compression.ziparchive) για να γράψει ένα τοπικό αρχείο· ο εξαγωγέας ο ίδιος δεν γράφει ξεχωριστά αρχεία XAML ή εικόνας. Για αποθήκευση απομακρυσμένα, αντικαταστήστε το στάδιο εγγραφής αρχείου με ανεβάσματα των συλλεγμένων πινάκων byte. Χρησιμοποιήστε ένα αναγνωριστικό εργασίας εξαγωγής συν το πλήρες σχετικό όνομα αρθρωματος ως κλειδί blob, ή αποθηκεύστε το αναγνωριστικό εργασίας, το σχετικό όνομα και τα δυαδικά δεδομένα σε γραμμή βάσης δεδομένων. Δημοσιεύστε την εργασία μόνο αφού ολοκληρωθούν όλα τα ανεβάσματα ή η συναλλαγή βάσης δεδομένων υπογράψει. Καθαρίστε μερική έξοδο αν η αποθήκευση αποτύχει.

Για μεγάλες παρουσιάσεις, ένας προσαρμοσμένος αποθηκευτής μπορεί να αποθηκεύει κάθε άρθρωμα απευθείας στην αποθήκευση της εφαρμογής ώστε να αποφευχθεί η διατήρηση ενός επιπλέον αντιγράφου ολόκληρης της εξαγωγής στη μνήμη της εφαρμογής. Ο εξαγωγέας εξακολουθεί να συλλέγει όλα τα δημιουργημένα άρθρωματα στη μνήμη πριν καλέσει τον αποθηκευτή. Διατηρήστε κάθε callback συγχρονισμένο από την οπτική του εξαγωγέα: επιστρέψτε μόνο αφού ο προορισμός έχει αποδεχθεί τα byte και επιτρέψτε στις αποτυχίες να φτάσουν στον καλούντα.

### **Διατήρηση Ονομάτων Πόρων και Επαλήθευση Αναφορών**

- Κανονικοποιήστε τους διαχωριστές διαδρομών όταν ο προορισμός το απαιτεί, αλλά διατηρήστε τους σχετικούς καταλόγους. Μην χρησιμοποιείτε μόνο το [Path.GetFileName](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfilename) εκτός εάν κάθε δημιουργημένο όνομα είναι μοναδικό και οι αναφορές πόρων παραμένουν έγκυρες.
- Εφαρμόστε επικύρωση ονομάτων ειδική για τον προορισμό. Όταν γράφετε ξεχωριστά αρχεία, απορρίψτε ριζικές διαδρομές και τμήματα διαπλοκής, επιλύστε τον προορισμό με το [Path.GetFullPath](https://learn.microsoft.com/en-us/dotnet/api/system.io.path.getfullpath) και βεβαιωθείτε ότι παραμένει κάτω από τον προβλεπόμενο φάκελο εξαγωγής, συμπεριλαμβανομένου του διαχωριστή κατά τον έλεγχο περιέλειας. Χρησιμοποιήστε ένα φάκελο ελεγχόμενο από την εφαρμογή χωρίς συμβολικούς δεσμούς που θα μπορούσαν να ανακατευθύνουν τις εγγραφές.
- Χρησιμοποιήστε ξεχωριστό αποθηκευτή και χώρο ονομάτων αποθήκευσης για κάθε εργασία εξαγωγής. Εντοπίστε συγκρούσεις μετά την κανονικοποίηση των διαχωριστών και σύμφωνα με τους κανόνες ευαισθησίας πεζών-κεφαλαίων του προορισμού.
- Πριν τη δημοσίευση, αναλύστε κάθε έγγραφο XAML ως XML και εξετάστε τις αναφορές πόρων βασισμένες σε αρχεία, όπως οι ιδιότητες `Source` ή `ImageSource` εικόνας. Επίλυση κάθε σχετικού URI έναντι του καταλόγου του σχετικού αρθρωματος XAML, κανονικοποίηση του προκύπτοντος ονόματος αποθήκευσης και επιβεβαίωση ότι το αντίστοιχο κλειδί λεξικού, καταχώριση ZIP ή αποθηκευμένο αντικείμενο υπάρχει. Θεωρήστε εξωτερικά URI και εκφράσεις σήμανσης XAML ξεχωριστά από τα σχετικά ονόματα αρχείων.

Για παράδειγμα, εάν το `pres/Slide_1.xaml` αναφέρει `images/image1.png`, ο αποθηκευμένος πόρος πρέπει να είναι διαθέσιμος ως `pres/images/image1.png`. Η διατήρηση μόνο του `image1.png` θα σπάσει αυτή τη σχέση. Για αποθήκευση αντικειμένων, διατηρήστε την ίδια δομή κάτω από το πρόθεμα εργασίας και κάντε τα URLs πόρων προσβάσιμα στον καταναλωτή XAML. Ανοίξτε ξανά το ολοκληρωμένο ZIP για να επαληθεύσετε τα ονόματα καταχωρίσεων και τα byte των πόρων, και φορτώστε αντιπροσωπευτικές διαφάνειες στο στοχευμένο περιβάλλον XAML για να βεβαιωθείτε ότι οι εικόνες επιλύονται σωστά.

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διασφαλίσω προβλέψιμες γραμματοσειρές εάν η αρχική γραμματοσειρά δεν είναι διαθέσιμη στο μηχάνημα;**

Ορίστε το [DefaultRegularFont](https://reference.aspose.com/slides/el/net/aspose.slides.export/saveoptions/defaultregularfont/) στο [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/) — χρησιμοποιείται ως εναλλακτική γραμματοσειρά κατά την εξαγωγή όταν η αρχική λείπει. Αυτό δεν εγγυάται ότι το παραγόμενο XAML θα αναφέρει τη γραμματοσειρά εναλλακτική ή ότι η γραμματοσειρά θα είναι διαθέσιμη στο στόχο. Βεβαιωθείτε ότι οι γραμματοσειρές που αναφέρονται στο XAML είναι διαθέσιμες στο περιβάλλον όπου εμφανίζεται.

**Απευθύνεται το εξαγόμενο XAML μόνο σε WPF ή μπορεί να χρησιμοποιηθεί και σε άλλες στοίβες XAML;**

Το Aspose.Slides εξάγει XAML για WPF μέσω του δημόσιου API του. Η συμβατότητα με άλλες στοίβες XAML, όπως UWP και Xamarin.Forms, δεν είναι εγγυημένη. Δοκιμάστε το παραγόμενο σήμα στο στοχευμένο περιβάλλον σας.

**Υποστηρίζονται οι κρυφές διαφάνειες και πώς μπορώ να αποτρέψω την εξαγωγή τους από προεπιλογή;**

Προεπιλεγμένα, οι κρυφές διαφάνειες δεν συμπεριλαμβάνονται. Μπορείτε να ελέγξετε αυτή τη συμπεριφορά μέσω του [ExportHiddenSlides](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) στο [XamlOptions](https://reference.aspose.com/slides/el/net/aspose.slides.export.xaml/xamloptions/) — κρατήστε το απενεργοποιημένο εάν δεν χρειάζεται να τις εξάγετε.