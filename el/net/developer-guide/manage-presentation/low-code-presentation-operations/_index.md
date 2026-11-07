---
title: Λειτουργίες Παρουσίασης Low-Code σε .NET
linktitle: API Low-Code
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
- αφαίρεση αχρησιμοποίητων layout διαφανειών
- συμπίεση ενσωματωμένων γραμματοσειρών
- PowerPoint
- OpenDocument
- παρουσίαση
- .NET
- C#
- Aspose.Slides
description: "Χρησιμοποιήστε το low-code API του Aspose.Slides σε .NET για να μετατρέψετε και να συγχωνεύσετε παρουσιάσεις, να επαναλάβετε το περιεχόμενο, να συλλέξετε σχήματα και να μειώσετε το μέγεθος της παρουσίασης."
---
## **Επισκόπηση**

Ο χώρος ονομάτων [Aspose.Slides.LowCode](https://reference.aspose.com/slides/net/aspose.slides.lowcode/) παρέχει στατικές βοηθητικές κλάσεις για κοινές λειτουργίες παρουσιάσεων. Αυτοί οι βοηθοί περιτυλίγουν συχνά χρησιμοποιούμενες ροές εργασίας του μοντέλου αντικειμένων σε εστιασμένες μεθόδους, ώστε να μπορείτε να μετατρέψετε ή να συγχωνεύετε αρχεία, να επεξεργάζεστε στοιχεία παρουσίασης, να συλλέγετε σχήματα και να αφαιρέσετε αχρησιμοποίητο περιεχόμενο με λιγότερο κώδικα.

Οι βοηθοί low-code είναι πιο χρήσιμοι όταν η λειτουργία εφαρμόζεται σε ολόκληρο το αρχείο ή την παρουσίαση και η προεπιλεγμένη ροή εργασίας ταιριάζει με τις απαιτήσεις σας. Χρησιμοποιήστε το πλήρες [Aspose.Slides object model](https://reference.aspose.com/slides/net/aspose.slides/) όταν χρειάζεστε λεπτομερή έλεγχο πάνω σε μεμονωμένες διαφάνειες, master, layouts, σχήματα, ρυθμίσεις εξαγωγής ή σχέσεις μεταξύ των στοιχείων παρουσίασης.

Ο παρακάτω πίνακας συνοψίζει τους διαθέσιμους βοηθούς:

| Βοηθός | Χρησιμοποιήστε το για |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) | Μετατροπή μιας παρουσίασης σε άλλη μορφή με άμεση κλήση αρχείο‑σε‑αρχείο. |
| [Merger](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/) | Συνδυασμός ολοκληρωμένων αρχείων παρουσίασης του ίδιου τύπου. |
| [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) | Εκτέλεση ενέργειας για κάθε διαφάνεια, σχήμα, παράγραφο ή τμήμα κειμένου. |
| [Collect](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/) | Ανάκτηση σχημάτων από ολόκληρη την παρουσίαση για επαναλαμβανόμενη επεξεργασία ή ανάλυση. |
| [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) | Αφαίρεση αχρησιμοποίητων master/layouts, μείωση ενσωματωμένων δεδομένων γραμματοσειράς και συμπίεση εικόνων. |

## **Μετατροπή Παρουσίασης**

Χρησιμοποιήστε [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/) όταν η επέκταση του αρχείου εξόδου είναι επαρκής για την επιλογή του μορφότυπου εξαγωγής. Η μέθοδος ανοίγει την πηγαία παρουσίαση, καθορίζει τον απαιτούμενο μορφότυπο από τη διαδρομή εξόδου και γράφει το αποτέλεσμα.

```csharp
using Aspose.Slides.LowCode;

Convert.AutoByExtension("input.pptx", "output.pdf");
```

Η κλάση [Convert](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/) παρέχει επίσης αφιερωμένες μεθόδους για έξοδο PDF, SVG, JPEG, PNG και TIFF. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να ελέγξετε ή να τροποποιήσετε την παρουσίαση πριν από την εξαγωγή ή να ρυθμίσετε μια επιλογή εξαγωγής που δεν εκτίθεται από τον βοηθό. Δείτε το [Convert Presentation](/slides/el/net/convert-presentation/) για εργασίες και επιλογές εξειδικευμένων μορφότυπων.

## **Συγχώνευση Παρουσιάσεων**

Χρησιμοποιήστε [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) για να συνδυάσετε ολοκληρωμένα αρχεία παρουσίασης με μία κλήση. Οι εισερχόμενες παρουσιάσεις πρέπει να έχουν τον ίδιο τύπο αρχείου.

```csharp
using Aspose.Slides.LowCode;

var inputFiles = new[] { "part-1.pptx", "part-2.pptx" };
Merger.Process(inputFiles, "merged.pptx");
```

Ο βοηθός είναι κατάλληλος όταν όλες οι διαφάνειες πρέπει να προσαρτηθούν σε ένα αποτέλεσμα χωρίς την επιλογή ή την επαναχαρτογράφηση τους μεμονωμένα. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να συγχωνεύσετε επιλεγμένες διαφάνειες, να εφαρμόσετε προορισμό master ή layout, να διατηρήσετε ρητά τις ενότητες ή να εναρμονίσετε διαφορετικά μεγέθη διαφανειών. Δείτε το [Merge Presentations](/slides/el/net/merge-presentation/) για αυτά τα σενάρια.

## **Επανάληψη Στοιχείων Παρουσίασης**

Η κλάση [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) καλεί μια λειτουργία επιστροφής κλήσης (callback) για κάθε ζητούμενο τύπο στοιχείου παρουσίασης. Αποφεύγει ένθετες βρόχους συλλογών και είναι βολική για έλεγχο ή αλλαγές μορφοποίησης σε όλη την παρουσίαση.

Το παρακάτω παράδειγμα χρησιμοποιεί [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/), [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) και [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) για να ελέγξει τα αντίστοιχα στοιχεία:

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

Από προεπιλογή, η διάσχιση σχημάτων και κειμένου σε όλη την παρουσίαση περιλαμβάνει κανονικές, master και layout διαφάνειες. Οι υπερφορτώσεις με παράμετρο `includeNotes` μπορούν επίσης να επεξεργαστούν διαφάνειες σημειώσεων. Χρησιμοποιήστε άμεσους βρόχους συλλογής όταν η σειρά διάσχισης, η πρώιμη έξοδος, το φιλτράρισμα πριν την κλήση της λειτουργίας ή ο λεπτομερής έλεγχος γονέα‑παιδιού είναι σημαντικά.

## **Συλλογή Σχημάτων**

Χρησιμοποιήστε [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε μια συλλογή όλων των σχημάτων σε μια παρουσίαση αντί για κλήση επιστροφής για κάθε σχήμα. Αυτό είναι χρήσιμο όταν το ίδιο σύνολο θα φιλτραριστεί, μετρηθεί ή υποβληθεί σε επεξεργασία περισσότερες από μία φορές.

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

Χρησιμοποιήστε [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) αντί αυτού όταν κάθε σχήμα μπορεί να επεξεργαστεί αμέσως και δεν χρειάζεται να διατηρηθεί το συλλεγμένο αποτέλεσμα.

## **Συμπίεση Περιεχομένου Παρουσίασης**

Η κλάση [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) μπορεί να αφαιρέσει αχρησιμοποίητα δομικά στοιχεία και να μειώσει τα ενσωματωμένα δεδομένα γραμματοσειρών:

- [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) αφαιρεί διαφάνειες layout που δεν αναφέρονται από καμία κανονική διαφάνεια.
- [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) αφαιρεί master διαφάνειες που δεν χρησιμοποιούνται πια.
- [Compress.CompressEmbeddedFonts](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressembeddedfonts/) αφαιρεί αχρησιμοποίητους χαρακτήρες από ενσωματωμένες γραμματοσειρές.

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

Αφαιρέστε πρώτα τα αχρησιμοποίητα layouts πριν τα αχρησιμοποίητα masters, ώστε ένα master που γίνεται αχρησιμοποίητο μετά τον καθαρισμό των layouts να μπορεί επίσης να αφαιρεθεί. Αποθηκεύστε την βελτιστοποιημένη παρουσίαση σε νέο αρχείο εάν μπορεί να χρειαστείτε τα αρχικά masters, layouts ή τα πλήρη ενσωματωμένα δεδομένα γραμματοσειράς αργότερα. Για περισσότερες λεπτομέρειες, δείτε το [Slide Master](/slides/el/net/slide-master/) και το [Embedded Font](/slides/el/net/embedded-font/).

### **Συμπίεση Ολόκληρης Παρουσίασης**

Το Aspose.Slides για .NET 26.11 προσθέτει το [Compress.CompressPresentation](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compresspresentation/). Συνδυάζει την αφαίρεση αχρησιμοποίητων layout/master διαφανειών, την υποστροφή ενσωματωμένων γραμματοσειρών στα χρησιμοποιούμενα χαρακτήρες και τη συμπίεση εικόνων στα 150 DPI. Χρησιμοποιήστε τις ατομικές λειτουργίες παραπάνω όταν πρέπει να ελέγξετε ποιες αλλαγές εφαρμόζονται.

Εγκαταστήστε το [Aspose.Slides for .NET](/slides/el/net/installation/) 26.11 ή νεότερη έκδοση και παρέχετε `input.pptx`. Αποθηκεύστε σε ξεχωριστό αρχείο: αφαιρεμένα layouts, χαρακτήρες γραμματοσειράς και περικομμένα pixel εικόνας μπορεί να χρειαστούν για επερχόμενη επεξεργασία.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressPresentation(presentation);
presentation.Save("compressed.pptx", SaveFormat.Pptx);
```

### **Συμπίεση Εικόνων σε Επιλεγμένη Ανάλυση**

Χρησιμοποιήστε [Compress.CompressImages](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/compressimages/) για να επεξεργαστείτε επιλέξιμες εικόνες χωρίς να αφαιρέσετε επίσης layouts ή να υποστέλλετε γραμματοσειρές. Αυτό το παράδειγμα χρησιμοποιεί 96 DPI· επιλέξτε άλλη τιμή [PicturesCompression](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) για τις ανάγκες εξόδου σας.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");
Compress.CompressImages(presentation, PicturesCompression.Dpi96);
presentation.Save("compressed-images.pptx", SaveFormat.Pptx);
```

Και οι δύο βοηθοί χρησιμοποιούν το παρακάτω πεδίο επεξεργασίας εικόνων:

| Περιεχόμενο | Επεξεργασία |
| --- | --- |
| Raster εικόνες και γεμίσματα εικόνας σχήματος σε κανονικές, master και layout διαφάνειες, συμπεριλαμβανομένων ομαδοποιημένων σχημάτων | Επιλέξιμες για συμπίεση. |
| Εικόνες που είναι ήδη στην ή κάτω από την ζητούμενη ανάλυση | Δεν αναβάλλονται. Τα περικομμένα τμήματα μπορούν ακόμη να αφαιρεθούν. |
| Περικομμένες περιοχές εικόνας | Τα κρυφά pixel αφαιρούνται μόνιμα και οι μετατοπίσεις περικοπής επαναφέρουν. |
| Υπόβαθρα διαφάνειας και γεμίσματα κελιών πίνακα | Δεν επεξεργάζονται από αυτούς τους βοηθούς. |
| Εσωτερικά Chart/SmartArt, GIF και διανυσματικές μορφές όπως SVG, EMF και WMF | Εκτός του τεκμηριωμένου πεδίου συμπίεσης εικόνων. |

Στην έκδοση 26.11, το [PicturesCompression.DocumentResolution](https://reference.aspose.com/slides/net/aspose.slides.export/picturescompression/) αποφεύγει την υποδειγματική μείωση ανάλυσης μιας μη περικομμένης εικόνας, αλλά **δεν διατηρεί τα περικομμένα pixel**. Μια περικομμένη εικόνα μπορεί ακόμη να ξαναγραφτεί με τα κρυφά τμήματα αφαιρεμένα. Κανένας από τους βοηθούς δεν προσφέρει επιλογή διατήρησης περικοπής. Για ατομικό έλεγχο, δείτε το [παράδειγμα συμπίεσης ανά εικόνα](/slides/el/net/examples/optimization-batch/compression/).

Συγκρίνετε την εμφάνιση και το μέγεθος του αρχείου προτού αντικαταστήσετε το πρωτότυπο. Η εξοικονόμηση εξαρτάται από τις πηγές εικόνων, το εμφανιζόμενο μέγεθός τους και το αχρησιμοποίητο περιεχόμενο· η συμπίεση δεν εγγυάται μικρότερο αρχείο. Δείτε τα [Embedded Fonts](/slides/el/net/embedded-font/) για τις συνέπειες της υποστροφής γραμματοσειρών.

## **Συχνές Ερωτήσεις**

**Πότε πρέπει να χρησιμοποιήσω το low-code API αντί του πλήρους μοντέλου αντικειμένων;**

Χρησιμοποιήστε τους βοηθούς low-code όταν μια τυπική λειτουργία εφαρμόζεται σε πλήρες αρχείο ή παρουσίαση και δεν απαιτεί λεπτομερή έλεγχο των μεμονωμένων στοιχείων. Χρησιμοποιήστε το πλήρες μοντέλο αντικειμένων όταν χρειάζεται να επιλέξετε συγκεκριμένες διαφάνειες, να ελέγξετε σχέσεις master και layout, να ελέγξετε ενδιάμεση κατάσταση ή να ρυθμίσετε συμπεριφορά που ο βοηθός δεν εκθέτει.

**Μπορεί ο Merger να συνδυάσει παρουσιάσεις σε διαφορετικούς τύπους αρχείων;**

Όχι. Το [Merger.Process](https://reference.aspose.com/slides/net/aspose.slides.lowcode/merger/process/) απαιτεί εισερχόμενες παρουσιάσεις στον ίδιο τύπο αρχείου. Μετατρέψτε πρώτα τα αρχεία εισόδου σε κοινό τύπο, για παράδειγμα με το [Convert.AutoByExtension](https://reference.aspose.com/slides/net/aspose.slides.lowcode/convert/autobyextension/), και έπειτα συγχωνεύστε τα μετατρεμμένα αρχεία.

**Επεξεργάζεται το ForEach master, layout και διαφάνειες σημειώσεων;**

Το [ForEach.Slide](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/slide/) διατρέχει τις κανονικές διαφάνειες της παρουσίασης. Τα [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/), [ForEach.Paragraph](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/paragraph/) και [ForEach.Portion](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/portion/) περιλαμβάνουν από προεπιλογή κανονικές, master και layout διαφάνειες. Χρησιμοποιήστε τις υπερφορτώσεις τους με `includeNotes` ορισμένο σε `true` για να συμπεριλάβετε διαφάνειες σημειώσεων.

**Ποια είναι η διαφορά μεταξύ ForEach.Shape και Collect.Shapes;**

Χρησιμοποιήστε το [ForEach.Shape](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/shape/) για να επεξεργαστείτε κάθε σχήμα αμέσως μέσω μιας κλήσης επιστροφής. Χρησιμοποιήστε το [Collect.Shapes](https://reference.aspose.com/slides/net/aspose.slides.lowcode/collect/shapes/) όταν χρειάζεστε ένα συλλεκτικό αποτέλεσμα που μπορεί να διατηρηθεί, φιλτραριστεί, μετρηθεί ή διαδιαστεί πολλαπλές φορές.

**Κάνει πάντα η Compress το αρχείο παρουσίασης μικρότερο;**

Όχι απαραίτητα. Η εξοικονόμηση εξαρτάται από αχρησιμοποίητα layouts/masters, ενσωματωμένες γραμματοσειρές με αχρησιμοποίητους χαρακτήρες και εικόνες που ωφελούνται από συμπίεση. Οι βοηθοί [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/) μπορεί να αφήσουν το μέγεθος αμετάβλητο ή ακόμη και να το αυξήσουν για ορισμένες εισόδους. Συγκρίνετε τόσο το μέγεθος όσο και την ποιότητα απόδοσης και διατηρήστε το πρωτότυπο.

**Αποθηκεύονται αυτόματα οι αλλαγές που κάνουν τα ForEach ή Compress;**

Όχι. Αυτοί οι βοηθοί λειτουργούν στο φορτωμένο αντικείμενο [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) στη μνήμη. Μετά την αλλαγή στοιχείων σε κλήση επιστροφής [ForEach](https://reference.aspose.com/slides/net/aspose.slides.lowcode/foreach/) ή την εκτέλεση [Compress](https://reference.aspose.com/slides/net/aspose.slides.lowcode/compress/), καλέστε το [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) για να γράψετε το αποτέλεσμα.

## **Σχετικά Άρθρα**

- [Convert Presentation](/slides/el/net/convert-presentation/)
- [Merge Presentations](/slides/el/net/merge-presentation/)
- [Slide Master](/slides/el/net/slide-master/)
- [Manage Text Box](/slides/el/net/manage-textbox/)
- [Embedded Font](/slides/el/net/embedded-font/)