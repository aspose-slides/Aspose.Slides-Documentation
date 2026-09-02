---
title: Αποδοτική συγχώνευση παρουσιάσεων στο .NET
linktitle: Συγχώνευση παρουσιάσεων
type: docs
weight: 40
url: /el/net/merge-presentation/
keywords:
- συγχώνευση PowerPoint
- συγχώνευση παρουσιάσεων
- συγχώνευση διαφανειών
- συγχώνευση PPT
- συγχώνευση PPTX
- συγχώνευση ODP
- συνδυασμός PowerPoint
- συνδυασμός παρουσιάσεων
- συνδυασμός διαφανειών
- συνδυασμός PPT
- συνδυασμός PPTX
- συνδυασμός ODP
- .NET
- C#
- Aspose.Slides
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument στο .NET κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου της διαφάνειας, διατηρώντας ενότητες και διαχειριζόμενοι προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Παρουσίαση](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι το [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/), που μπορεί να διατηρήσει τη μορφοποίηση της αρχικής διαφάνειας ή να συνδέσει τη κλωνοποιημένη διαφάνεια με έναν master ή layout στην προορισμένη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προορισμένη παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προορισμένη παρουσίαση·
- ομαλοποίηση διαφορετικών μεγεθών διαφανειών πριν τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολοκληρωμένη ροή εργασίας·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών πρόσβασης, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει Masters και Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και τον master της. Γι' αυτόν τον λόγο, η υπερφόρτωση κλωνοποίησης που θα επιλέξετε καθορίζει πώς η συγχωνευμένη διαφάνεια ενσωματώνεται στην προορισμένη παρουσίαση.

Χρησιμοποιήστε το [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) με έναν από τους παρακάτω τρόπους:

- `AddClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της πηγής. Όταν απαιτείται, ο master της πηγής μπορεί να κλωνοποιηθεί αυτόματα στην προορισμένη παρουσίαση. Το Aspose.Slides παρακολουθεί αυτόματα κλωνοποιημένους masters ώστε διαδοχικές διαφάνειες που χρησιμοποιούν τον ίδιο master πηγής να μην προκαλούν πολλαπλή κλωνοποίηση του master.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια με έναν συγκεκριμένο προορισμένο [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/). Το Aspose.Slides αναζητά αντίστοιχο layout κάτω από αυτόν τον master με βάση τον τύπο ή το όνομα του layout.
- `AddClone(sourceSlide, destinationLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια απευθείας με ένα συγκεκριμένο προορισμένο [ILayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/).

Ο master ή το layout που περνιέται σε μια υπερφόρτωση `AddClone` πρέπει να ανήκει στην **προορισμένη** παρουσίαση, όχι στην πηγή.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγή στην προορισμένη παρουσίαση. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, τον master και τις σχέσεις layout.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

Η προκύπτουσα παρουσίαση μπορεί να περιέχει πολλαπλούς masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση πηγής διατηρείται επί γνώμης.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Στο παρακάτω παράδειγμα εισάγονται μόνο οι επιλεγμένοι δείκτες διαφανειών από την πηγή.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

Επικυρώστε τους δείκτες διαφανειών πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Master Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθήσουν έναν master που ήδη ανήκει στην προορισμένη παρουσίαση.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από τον καθορισμένο master αντιστοιχίζοντας τον τύπο ή το όνομα του layout της πηγής. Εάν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το layout της πηγής κλωνοποιείται ώστε η διαφάνεια να μπορεί να προστεθεί. Εάν είναι `false`, εξαίρεση [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/) ρίχνεται.

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισάγει επιπλέον layout στον master προορισμού.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Layout Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) όταν γνωρίζετε ακριβώς ποιο layout προορισμού πρέπει να χρησιμοποιήσουν οι εισαγόμενες διαφάνειες.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

Η εφαρμογή ενός layout προορισμού αλλάζει τη σχέση κληρονομικού layout· δεν επανασχεδιάζει το περιεχόμενο της διαφάνειας πηγής. Εάν τα layout πηγής και προορισμού έχουν διαφορετικές δομές placeholders, ελέγξτε το αποτέλεσμα για να βεβαιωθείτε ότι η κληρονομική μορφοποίηση και η συμπεριφορά των placeholders είναι κατάλληλες.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Συνεπώς τα σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός του ορατού χώρου της διαφάνειας.

Μία πρακτική προσέγγιση είναι η αλλαγή μεγέθους της πηγής πριν την κλωνοποίηση. Η μέθοδος [SlideSize.SetSize](https://reference.aspose.com/slides/el/net/aspose.slides/slidesize/setsize/) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/net/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να χωρέσει στο ζητούμενο μέγεθος.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο παρουσίασης πηγής στη μνήμη. Εάν χρειάζεστε την αρχική παρουσίαση πηγής αμετάβλητη για άλλες λειτουργίες, ανοίξτε μια ξεχωριστή παρουσίαση για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίας**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν αναδημιουργεί την ιεραρχία ενοτήτων της πηγής. Εάν οι ενότητες έχουν σημασία στο τελικό αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προορισμένη παρουσίαση και κλωνοποιήστε τις διαφάνειες σ’ αυτές ρητά με το [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/).

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στο καθορισμένο τμήμα προορισμού. Για να διατηρηθούν πολλές ενότητες πηγής, δημιουργήστε ξανά αυτές τις ενότητες στον προορισμό και αντιστοιχίστε κάθε διαφάνεια πηγής στην αντίστοιχη ενότητα προορισμού.

## **Ασφαλής Συγχώνευση Πολλαπλών Παρουσιάσεων**

Το παρακάτω παράδειγμα από άκρο σε άκρο χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, ομαλοποιεί το μέγεθος διαφάνειας κάθε επιπλέον πηγής, κρατά κάθε πηγή ανοιχτή μόνο όσο γίνεται η αντιγραφή της, και αποθηκεύει το τελικό αρχείο μόλις ολοκληρωθεί.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

Αυτό αποτελεί μια χρήσιμη βάση για τη διατήρηση της μορφοποίησης πηγής των εισαγόμενων διαφανειών. Εάν η έξοδός σας πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `AddClone(slide)` με την κατάλληλη υπερφόρτωση master ή layout προορισμού που παρουσιάστηκε νωρίτερα.

## **Πρακτικές Σκέψεις**

### **Masters, Layouts και Αξιοπιστία Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί να φέρει αυτόματα έναν απαιτούμενο master πηγής στην προορισμένη παρουσίαση. Το Aspose.Slides διατηρεί ένα εσωτερικό μητρώο για αυτόματα κλωνοποιημένους masters ώστε να αποφεύγεται η επανειλημμένη κλωνοποίηση του ίδιου master. Οι χειροκίνητα κλωνοποιημένοι masters δεν καταγράφονται σε αυτό το μητρώο, γι' αυτό αποφύγετε την προ-κλωνοποίηση των masters εκτός εάν χρειάζεστε άμεσο έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγχει την τελική εμφάνιση, επιλέξτε ρητά έναν master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια διαφάνειας συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται μια διαφάνεια. Το Aspose.Slides προσφέρει επίσης εξειδικευμένα API για [σημειώσεις παρουσίασης](https://docs.aspose.com/slides/el/net/presentation-notes/) και [σχόλια παρουσίασης](https://docs.aspose.com/slides/el/net/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, ελέγξτε τη συγχωνευμένη παρουσίαση επειδή οι masters σημειώσεων είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των αρχείων πηγής. Για διαδικασίες ελέγχου, ελέγξτε επίσης τους συγγραφείς σχολίων και τις αλληλουχίες σχολίων μετά τη συγχώνευση αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε την ίδια τη διαφάνεια αντί να αντιγράψετε μόνο τα ορατά σχήματα, ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και συνδεδεμένοι πόροι πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τις URL των συνδεδεμένων πόρων στο περιβάλλον όπου θα ανοίξει η συγχωνευμένη παρουσίαση.

Το Aspose.Slides παρακολουθεί αυτόματα τους κλωνοποιημένους masters, αλλά αυτό δεν αποτελεί γενική εγγύηση ότι τα ίδια δυαδικά αρχεία από ανεξάρτητες πηγές θα αφαιρεθούν αυτόματα. Εάν το μέγεθος του αρχείου εξόδου είναι σημαντικό, ελέγξτε το συγχωνευμένο πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε έμμεση αφαίρεση διπλοτύπων.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται σε επίπεδο παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ μηχανών, μην υποθέτετε ότι η κλωνοποίηση διαφανειών από μόνη της εγγυάται ότι κάθε απαραίτητη γραμματοσειρά είναι διαθέσιμη στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getembeddedfonts/) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο [Ενσωμάτωση Γραμματοσειρών σε Παρουσιάσεις](https://docs.aspose.com/slides/el/net/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε δικαίωμα να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα αρχεία πηγής· οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Κωδικό Πρόσβασης**

Μια πηγή με κωδικό πρόσβασης πρέπει να ανοίξει επιτυχώς πριν κλωνοποιηθούν οι διαφάνειές της. Παρέχετε τον κωδικό μέσω του [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Το άνοιγμα μιας κρυπτογραφημένης πηγής δεν εφαρμόζει αυτόματα την ίδια προστασία στην προορισμένη παρουσίαση. Ρυθμίστε την προστασία εξόδου ξεχωριστά όταν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Μεγάλες παρουσιάσεις που περιέχουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορούν να καταναλώσουν σημαντική μνήμη. Το [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/blobmanagementoptions/) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Διαχείριση BLOB Παρουσιάσεων](https://docs.aspose.com/slides/el/net/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, απελευθερώστε κάθε παρουσίαση πηγής μόλις ολοκληρωθεί η συγχώνευσή της και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματικότητας**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε παρουσίαση περιορισμένη σε μία λειτουργία συγχώνευσης. Εάν παράγετε παράλληλες ανεξάρτητες εργασίες, χρησιμοποιήστε ανεξάρτητα αντικείμενα παρουσίασης και ακολουθήστε τις οδηγίες [πολυνηματικότητας του Aspose.Slides](https://docs.aspose.com/slides/el/net/multithreading/).

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διατηρήσω το αρχικό σχέδιο κάθε παρουσίασης πηγής;**

Χρησιμοποιήστε το [`AddClone(sourceSlide)`](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) χωρίς να παρέχετε master ή layout προορισμού. Το Aspose.Slides μπορεί αυτόματα να κλωνοποιήσει τον master πηγής όταν απαιτείται από τη διαφάνεια που εισάγεται.

**Πώς μπορώ να κάνω τις εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που δέχεται έναν master προορισμού. Δώστε έναν master από την προορισμένη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε διαφάνεια πηγής σε ένα κατάλληλο layout κάτω από αυτόν τον master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master προορισμού;**

Χρησιμοποιήστε ένα συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να ακολουθεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει μεταξύ των layouts του master βάσει του τύπου ή του ονόματος του layout πηγής.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της πηγής πρώτα όταν χρειάζεστε προβλέψιμη τοποθέτηση, π.χ. με το [SlideSize.SetSize](https://reference.aspose.com/slides/el/net/aspose.slides/slidesize/setsize/) και το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/net/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω αρχεία PPT, PPTX και ODP σε ένα αρχείο;**

Ναι. Φορτώστε κάθε παρουσίαση πηγής, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε μια προορισμένη παρουσίαση και αποθηκεύστε την προορισμένη σε μορφή που υποστηρίζεται. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το σύνθετο περιεχόμενο μετά από συγχωνεύσεις μεταξύ διαφορετικών φορμάτ. Δείτε τις [Υποστηριζόμενες Μορφές Αρχείων](https://docs.aspose.com/slides/el/net/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι, από έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) όταν η δομή ενοτήτων πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται με τη κλωνοποιημένη διαφάνεια. Για ροές εργασίας που εξαρτώνται από το στυλ του master σημειώσεων, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα επειδή αυτά τα σενάρια αφορούν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι γίνεται με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, οπότε τα αρχεία-στόχοι ή οι URL πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυάνονται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή στο τελικό αρχείο;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την υλοποίηση γραμματοσειρών. Ελέγξτε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο με κωδικό πρόσβασης;**

Ανοίξτε το με το σωστό [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/), στη συνέχεια κλωνοποιήστε τις διαφάνειες κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς να χειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε διαχείριση BLOB όταν μεγάλα δυαδικά αντικείμενα κυριαρχούν στη μνήμη, προτιμήστε τη φόρτωση από διαδρομές αρχείων για πολύ μεγάλα αρχεία, απελευθερώστε γρήγορα τις πηγές και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να κλωνοποιήσω διαφάνειες από πολλαπλά νήματα;**

Μην χρησιμοποιείτε μία παρουσίαση [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη σε ξεχωριστές παρουσίες.