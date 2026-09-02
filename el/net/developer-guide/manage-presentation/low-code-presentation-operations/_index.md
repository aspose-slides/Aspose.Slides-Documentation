---
title: Λειτουργίες Παρουσίασης Χαμηλού Κώδικα σε .NET
linktitle: API Χαμηλού Κώδικα
type: docs
weight: 50
url: /el/net/low-code-presentation-operations/
keywords:
- API παρουσίασης χαμηλού κώδικα
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
description: "Χρησιμοποιήστε το API χαμηλού κώδικα Aspose.Slides σε .NET για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να πραγματοποιήσετε επανάληψη μέσω του περιεχομένου, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων [Aspose.Slides.LowCode](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/) παρέχει στατικές βοηθητικές κλάσεις για συνηθισμένες λειτουργίες παρουσίασης. Αυτοί οι βοηθοί ενσωματώνουν συχνά χρησιμοποιούμενες ροές εργασίας του αντικειμενικού μοντέλου σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέψετε ή να συγχωνεύσετε αρχεία, να επεξεργαστείτε στοιχεία παρουσίασης, να συλλέξετε σχήματα και να αφαιρέσετε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθητικές λειτουργίες low-code είναι πιο χρήσιμες όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/el/net/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο στα μεμονωμένα διαφάνειες, master, διατάξεις, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων της παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρήση |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείου προς αρχείο. |
| [Merger](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/merger/) | Συνδυασμός ολοκληρωμένων αρχείων παρουσίασης του ίδιου φορμάτ. |
| [ForEach](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/) | Εκτέλεση μιας ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων master και διατάξεων και μείωση ενσωματωμένων δεδομένων γραμματοσειρών. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε το [Convert.AutoByExtension](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/autobyextension/) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή της μορφής εξαγωγής. Η μέθοδος ανοίγει την πηγαία παρουσίαση, καθορίζει τη απαιτούμενη μορφή από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/) προσφέρει επίσης ειδικές μεθόδους για εξαγωγή σε PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες αντικειμενικό μοντέλο όταν χρειάζεται να επανεξετάσετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να διαμορφώσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον επιλεγμένο βοηθό. Δείτε το [Convert Presentation](/slides/el/net/convert-presentation/) για ροές εργασίας και επιλογές ειδικές για κάθε μορφή.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε το [Merger.Process](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/merger/process/) για να συνδυάσετε ολοκληρωμένα αρχεία παρουσίασης με μια κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν το ίδιο φορμάτ αρχείου.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Αυτός ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα ενιαίο αποτέλεσμα χωρίς να τις επιλέγετε ή να τις χαρτογραφείτε ξεχωριστά. Χρησιμοποιήστε το πλήρες αντικειμενικό μοντέλο όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε ένα προορισμό master ή διάταξης, να διατηρήσετε ενότητες ρητά ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/slides/el/net/merge-presentation/) για αυτές τις περιπτώσεις.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/) καλεί μια ανάκληση για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει την ένθετη επανάληψη συλλογών και είναι βολική για έλεγχο ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί τα [ForEach.Slide](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/paragraph/), και [ForEach.Portion](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/portion/) για να επιθεωρήσετε τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η περιήγηση σχήματος και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και διατάξεις διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσες επαναλήψεις συλλογής όταν η σειρά περιήγησης, η πρώιμη έξοδος, το φιλτράρισμα πριν την κλήση της ανάκλησης ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε το [Collect.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για ανάκληση για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτράρεται, μετράται ή επεξεργάζεται περισσότερες φορές.

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

Χρησιμοποιήστε το [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/) αντ' αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί άμεσα και δεν χρειάζεται να διατηρήσετε το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) αφαιρεί τις διαφάνειες διάταξης που δεν αναφέρονται από καμία κανονική διαφάνεια.  
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) αφαιρεί τις master διαφάνειες που δεν χρησιμοποιούνται πια.  
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/compressembeddedfonts/) αφαιρεί τους αχρησιμοποίητους χαρακτήρες από τις ενσωματωμένες γραμματοσειρές.  

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

Αφαιρέστε πρώτα τις αχρησιμοποίητες διατάξεις πριν τα αχρησιμοποίητα master, ώστε ένα master που γίνεται αμεριδέντο μετά τον καθαρισμό των διατάξεων να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν ίσως χρειαστείτε αργότερα τα αρχικά master, διατάξεις ή πλήρη ενσωματωμένα δεδομένα γραμματοσειρών. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/slides/el/net/slide-master/) και το [Embedded Font](/slides/el/net/embedded-font/).

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το low-code API αντί του πλήρους αντικειμενικού μοντέλου;**

Χρησιμοποιήστε τους βοηθούς low-code όταν μια τυπική λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο στα μεμονωμένα στοιχεία. Χρησιμοποιήστε το πλήρες αντικειμενικό μοντέλο όταν χρειάζεστε να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε τις σχέσεις master‑layout, να επιθεωρήσετε ενδιάμεση κατάσταση ή να διαμορφώσετε συμπεριφορά που δεν εκτίθεται από τον βοηθό.

**Μπορεί το Merger να συνδυάσει παρουσιάσεις σε διαφορετικά φορμάτ αρχείων;**

Όχι. Το [Merger.Process](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/merger/process/) απαιτεί οι εισερχόμενες παρουσιάσεις να είναι στο ίδιο φορμάτ. Μετατρέψτε πρώτα τα αρχεία εισόδου σε ένα κοινό φορμάτ, για παράδειγμα με το [Convert.AutoByExtension](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/convert/autobyextension/), και έπειτα συγχωνεύστε τα μετατρεπόμενα αρχεία.

**Επεξεργάζεται το ForEach τα master, layout και notes διαφάνειες;**

Το [ForEach.Slide](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/slide/) διασχίζει τις κανονικές διαφάνειες της παρουσίασης. Οι εργασίες [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/paragraph/), και [ForEach.Portion](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/portion/) σε όλη την παρουσίαση περιλαμβάνουν από προεπιλογή τις κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο στο `true` για να συμπεριληφθούν και οι notes διαφάνειες.

**Ποια είναι η διαφορά μεταξύ ForEach.Shape και Collect.Shapes;**

Χρησιμοποιήστε το [ForEach.Shape](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/shape/) για να επεξεργαστείτε κάθε σχήμα άμεσα μέσω μιας ανάκλησης. Χρησιμοποιήστε το [Collect.Shapes](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε ένα επαναληπτικό αποτέλεσμα που μπορεί να διατηρηθεί, να φιλτραριστεί, να μετρηθεί ή να επεξεργαστεί πολλαπλές φορές.

**Κάνει πάντα το Compress το αρχείο παρουσίασης μικρότερο;**

Όχι απαραίτητα. Το αποτέλεσμα εξαρτάται από το αν η παρουσίαση περιέχει αχρησιμοποίητες διατάξεις, αχρησιμοποίητα master ή ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες. Εάν δεν υπάρχουν τέτοια στοιχεία, οι αντίστοιχες λειτουργίες [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/) μπορεί να μην μειώσουν το μέγεθος του αρχείου.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνουν οι ForEach ή Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε μια ανάκληση [ForEach](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/foreach/) ή την εκτέλεση του [Compress](https://reference.aspose.com/slides/el/net/aspose.slides.lowcode/compress/), καλέστε το [Presentation.Save](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Μετατροπή Παρουσίασης](/slides/el/net/convert-presentation/)
- [Συγχώνευση Παρουσιάσεων](/slides/el/net/merge-presentation/)
- [Slide Master](/slides/el/net/slide-master/)
- [Διαχείριση Πλαισίου Κειμένου](/slides/el/net/manage-textbox/)
- [Ενσωματωμένη Γραμματοσειρά](/slides/el/net/embedded-font/)