---
title: Λειτουργίες Παρουσίασης Low-Code σε .NET
linktitle: Low-Code API
type: docs
weight: 50
url: /el/net/low-code-presentation-operations/
keywords:
- API παρουσίασης low-code
- μετατροπή παρουσίασης
- συγχώνευση παρουσιάσεων
- επανάληψη διαφανειών
- επανάληψη σχημάτων
- επανάληψη κειμένου
- συλλογή σχημάτων
- συμπίεση παρουσίασης
- αφαίρεση αχρησιμοποίητων master διαφανειών
- αφαίρεση αχρησιμοποίητων διαφανειών διάταξης
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Χρησιμοποιήστε το low-code API του Aspose.Slides σε .NET για να μετατρέπετε και να συγχωνεύετε παρουσιάσεις, να επαναλαμβάνετε το περιεχόμενο, να συλλέγετε σχήματα και να μειώνετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων [Aspose.Slides.LowCode](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/) παρέχει στατικές κλάσεις βοηθητικών λειτουργιών για κοινές εργασίες παρουσίασης. Αυτοί οι βοηθοί ενσωματώνουν συχνά χρησιμοποιούμενες ροές εργασίας του αντικειμενοστραφούς μοντέλου σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέπετε ή να ενοποιείτε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρείτε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί low‑code είναι πιο χρήσιμοι όταν η ενέργεια εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει στις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/net/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων της παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε διαφορετική μορφή με άμεση κλήση αρχείου‑προς‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/merger/) | Συνένωση πλήρων αρχείων παρουσίασης της ίδιας μορφής. |
| [ForEach](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειράς. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε [Convert.AutoByExtension](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/autobyextension/) όταν η κατάληξη του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγή παρουσίασης, καθορίζει τη ζητούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/) παρέχει επίσης ειδικές μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες αντικειμενοστραφές μοντέλο όταν χρειάζεται να εξετάσετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/net/convert-presentation/) για ροές εργασίας και επιλογές συγκεκριμένων μορφών.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε [Merger.Process](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/merger/process/) για να συνδυάσετε πλήρη αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν την ίδια μορφή αρχείου.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προστεθούν σε ένα αποτέλεσμα χωρίς την επιλογή ή την επανασχεδίασή τους μεμονωμένα. Χρησιμοποιήστε το πλήρες αντικειμενοστραφές μοντέλο όταν πρέπει να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμό master ή διάταξης, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/net/merge-presentation/) για αυτά τα σενάρια.

## **Διέλευση Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/) καλεί μια συνάρτηση επιστροφής για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ενσωματωμένους βρόχους συλλογής και είναι βολική για επιθεώρηση ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί τα [ForEach.Slide](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/paragraph/) και [ForEach.Portion](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/portion/) για να επιθεωρήσουν τα αντίστοιχα στοιχεία:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

ForEach.Slide(presentation, (slide, index) =>
{
    Console.WriteLine($"Slide {index}: {slide.Shapes.Count} shapes");
});

ForEach.Shape(presentation, (shape, slide, index) =>
{
    Console.WriteLine($"Shape {index} on {slide.GetType().Name}: {shape.Name}");
});

ForEach.Paragraph(presentation, (paragraph, slide, index) =>
{
    Console.WriteLine($"Paragraph {index} on {slide.GetType().Name}: {paragraph.Text}");
});

ForEach.Portion(presentation, (portion, paragraph, slide, index) =>
{
    Console.WriteLine($"Portion {index} on {slide.GetType().Name}: {portion.Text}");
});
```

Από προεπιλογή, η διαδρομή σχήματος και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με μια παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διέλευσης, η πρώιμη έξοδος, το φιλτράρισμα πριν από την κλήση ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε [Collect.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για κλήση επιστροφής για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, μετράται ή επεξεργάζεται περισσότερες από μία φορές.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
var shapes = Collect.Shapes(presentation);

foreach (var shape in shapes)
{
    Console.WriteLine($"{shape.Name}: {shape.GetType().Name}");
}
```

Χρησιμοποιήστε [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/) αντ’ αυτού όταν κάθε σχήμα μπορεί να αντιμετωπιστεί άμεσα και δεν χρειάζεται να διατηρήσετε το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειράς:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) αφαιρεί διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πλέον.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/compressembeddedfonts/) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
Compress.RemoveUnusedMasterSlides(presentation);
Compress.CompressEmbeddedFonts(presentation);

presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τις αχρησιμοποίητες master, ώστε μια master που γίνει ακαταχώρητη μετά τον καθαρισμό διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν ενδέχεται να χρειαστείτε αργότερα τους αρχικούς masters, διατάξεις ή το πλήρες ενσωματωμένο σύνολο γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/net/slide-master/) και το [Embedded Font](/net/embedded-font/).

## **ΣΥΝΕΧΩΣ ΕΡΩΤΗΣΕΙΣ**

**Πότε πρέπει να χρησιμοποιήσω το low‑code API αντί του πλήρους αντικειμενοστραφούς μοντέλου;**

Χρησιμοποιήστε τους βοηθούς low‑code όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο πάνω σε μεμονωμένα στοιχεία. Χρησιμοποιήστε το πλήρες αντικειμενοστραφές μοντέλο όταν πρέπει να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master‑layout, να επιθεωρήσετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις σε διαφορετικές μορφές αρχείων;**

Όχι. Το [Merger.Process](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/merger/process/) απαιτεί τις εισερχόμενες παρουσιάσεις να είναι στην ίδια μορφή. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινή μορφή, για παράδειγμα με το [Convert.AutoByExtension](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/autobyextension/), και έπειτα συγχωνεύστε τα μετατραπέντα αρχεία.

**Επεξεργάζεται το ForEach master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.Slide](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/slide/) διέρχεται από τις κανονικές διαφάνειες της παρουσίασης. Η λειτουργία [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/paragraph/) και [ForEach.Portion](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/portion/) σε επίπεδο παρουσίασης περιλαμβάνει από προεπιλογή κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε και τις διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.Shape και Collect.Shapes;**

Χρησιμοποιήστε το [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/) για άμεση επεξεργασία κάθε σχήματος μέσω κλήσης επιστροφής. Χρησιμοποιήστε το [Collect.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε ένα επαναχρησιμοποιήσιμο αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή διαπεραστεί πολλές φορές.

**Κάνει πάντα η Compress το αρχείο παρουσίασης μικρότερο;**

Όχι απαραίτητα. Το αποτέλεσμα εξαρτάται από το εάν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητους masters ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν τέτοια στοιχεία, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που γίνονται από το ForEach ή το Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν πάνω στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) στη μνήμη. Μετά την τροποποίηση των στοιχείων σε μια κλήση επιστροφής [ForEach](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/) ή μετά την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/), καλέστε το [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/net/convert-presentation/)
- [Merge Presentations](/net/merge-presentation/)
- [Slide Master](/net/slide-master/)
- [Manage Text Box](/net/manage-textbox/)
- [Embedded Font](/net/embedded-font/)