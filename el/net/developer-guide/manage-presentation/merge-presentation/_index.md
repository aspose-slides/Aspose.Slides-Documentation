---
title: Αποτελεσματική Συγχώνευση Παρουσιάσεων στο .NET
linktitle: Συγχώνευση Παρουσιάσεων
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
description: "Μάθετε πώς να συγχωνεύετε παρουσιάσεις PowerPoint και OpenDocument στο .NET κλωνοποιώντας διαφάνειες, ελέγχοντας masters και layouts, αλλάζοντας το μέγεθος του περιεχομένου των διαφανειών, διατηρώντας ενότητες και διαχειρίζοντας προστατευμένα ή μεγάλα αρχεία."
---
## **Επισκόπηση**

Το Aspose.Slides for .NET συγχωνεύει παρουσιάσεις κλωνοποιώντας διαφάνειες από μία [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) σε άλλη. Η κύρια λειτουργία είναι η [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/), η οποία μπορεί να διατηρήσει τη μορφοποίηση της πηγαίας διαφάνειας ή να συνδέσει τη κλωνοποιημένη διαφάνεια με ένα master ή layout στην προοριζόμενη παρουσίαση.

Αυτό το άρθρο καλύπτει τις πιο συνηθισμένες ροές εργασίας συγχώνευσης:

- συγχώνευση όλων των διαφανειών διατηρώντας τη μορφοποίηση της πηγής·
- συγχώνευση επιλεγμένων διαφανειών·
- εφαρμογή master από την προοριζόμενη παρουσίαση·
- εφαρμογή συγκεκριμένου layout από την προοριζόμενη παρουσίαση·
- εξομάλυνση διαφορετικών μεγεθών διαφανειών πριν τη συγχώνευση·
- προσθήκη κλωνοποιημένων διαφανειών σε ενότητα·
- συγχώνευση πολλαπλών παρουσιάσεων σε μία ολοκληρωμένη διαδικασία·
- διαχείριση masters, πόρων, σημειώσεων, σχολίων, πολυμέσων, γραμματοσειρών, κωδικών, μεγάλων αρχείων και θεμάτων πολυνηματικότητας.

## **Πώς η Κλωνοποίηση Διαφανειών Επηρεάζει Masters και Layouts**

Μια διαφάνεια κληρονομεί μεγάλο μέρος της εμφάνισής της από το layout και το master της. Για αυτόν τον λόγο, η υπερφόρτωση κλωνοποίησης που επιλέγετε καθορίζει πώς θα ενσωματωθεί η συγχωνευμένη διαφάνεια στην προοριζόμενη παρουσίαση.

Χρησιμοποιήστε την [ISlideCollection.AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) με έναν από τους παρακάτω τρόπους:

- `AddClone(sourceSlide)` — διατηρεί το layout και τη μορφοποίηση της πηγαίας διαφάνειας. Όταν απαιτείται, το πηγαίο master μπορεί να κλωνοποιηθεί αυτόματα στην προοριζόμενη παρουσίαση. Το Aspose.Slides καταγράφει αυτόματα κλωνοποιημένα masters ώστε επαναλαμβανόμενες διαφάνειες που χρησιμοποιούν το ίδιο πηγαίο master να μην κλωνοποιούν το master ξανά.
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια με ένα συγκεκριμένο προοριζόμενο [IMasterSlide](https://reference.aspose.com/slides/el/net/aspose.slides/imasterslide/). Το Aspose.Slides αναζητά ένα ταιριαστό layout κάτω από αυτό το master με βάση τον τύπο ή το όνομα του layout.
- `AddClone(sourceSlide, destinationLayout)` — συνδέει τη κλωνοποιημένη διαφάνεια απευθείας με ένα συγκεκριμένο προοριζόμενο [ILayoutSlide](https://reference.aspose.com/slides/el/net/aspose.slides/ilayoutslide/).

Το master ή το layout που παρέχεται σε μια υπερφόρτωση `AddClone` πρέπει να ανήκει στην **προοριζόμενη** παρουσίαση, όχι στην πηγαία παρουσίαση.

## **Συγχώνευση Ολόκληρων Παρουσιάσεων και Διατήρηση Μορφοποίησης Πηγής**

Η πιο απλή συγχώνευση αντιγράφει κάθε διαφάνεια από την πηγαία παρουσίαση στην προοριζόμενη. Αυτή είναι η κατάλληλη επιλογή όταν οι εισαγόμενες διαφάνειες πρέπει να διατηρήσουν το αρχικό θέμα, master και σχέσεις layout.

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

Η προκύπτουσα παρουσίαση ενδέχεται να περιέχει πολλαπλά masters όταν η πηγή και ο προορισμός χρησιμοποιούν διαφορετικά σχέδια. Αυτό είναι αναμενόμενο όταν η μορφοποίηση της πηγής διατηρείται σκόπιμα.

## **Συγχώνευση Επιλεγμένων Διαφανειών**

Δεν χρειάζεται να κλωνοποιήσετε κάθε διαφάνεια. Το παρακάτω παράδειγμα εισάγει μόνο τις επιλεγμένες διαφάνειες από την πηγαία παρουσίαση.

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

Επαληθεύστε τους δείκτες διαφανειών πριν την κλωνοποίηση όταν προέρχονται από είσοδο χρήστη ή εξωτερική διαμόρφωση.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Master Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) όταν οι εισαγόμενες διαφάνειες πρέπει να ακολουθούν ένα master που ήδη ανήκει στην προοριζόμενη παρουσίαση.

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

Το Aspose.Slides επιλέγει ένα κατάλληλο layout κάτω από το καθορισμένο master ταιριάσκοντας τον τύπο ή το όνομα του πηγαίου layout. Εάν δεν υπάρχει κατάλληλο layout και το `allowCloneMissingLayout` είναι `true`, το πηγαίο layout κλωνοποιείται ώστε η διαφάνεια να προστεθεί. Εάν είναι `false`, ρίχνεται μια [PptxEditException](https://reference.aspose.com/slides/el/net/aspose.slides/pptxeditexception/).

Χρησιμοποιήστε `false` όταν θέλετε η συγχώνευση να αποτύχει αντί να εισαχθεί ένα επιπλέον layout στο προοριζόμενο master.

## **Συγχώνευση Διαφανειών Χρησιμοποιώντας Συγκεκριμένο Layout Προορισμού**

Χρησιμοποιήστε την υπερφόρτωση [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) όταν γνωρίζετε ακριβώς ποιο προοριζόμενο layout πρέπει να χρησιμοποιήσουν οι εισαγόμενες διαφάνειες.

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

Η εφαρμογή ενός προοριζόμενου layout αλλάζει τη κληρονομημένη σχέση layout· δεν επανασχεδιάζει το περιεχόμενο της πηγαίας διαφάνειας. Εάν τα layout της πηγής και του προορισμού έχουν διαφορετικές δομές placeholders, εξετάστε το αποτέλεσμα για να επιβεβαιώσετε ότι η κληρονομημένη μορφοποίηση και η συμπεριφορά των placeholders είναι κατάλληλη.

## **Συγχώνευση Παρουσιάσεων με Διαφορετικά Μεγέθη Διαφανειών**

Παρουσιάσεις με διαφορετικές διαστάσεις διαφάνειας μπορούν να συγχωνευτούν, αλλά η κλωνοποίηση μιας διαφάνειας σε παρουσίαση με άλλο μέγεθος δεν επανασχεδιάζει αυτόματα το περιεχόμενό της για το νέο καμβά. Έτσι, σχήματα μπορεί να εμφανιστούν μετατοπισμένα, κλιμακωμένα απρόσμενα ή εκτός ορατής περιοχής της διαφάνειας.

Μια πρακτική προσέγγιση είναι να αλλάξετε το μέγεθος της πηγαίας παρουσίασης πριν την κλωνοποίηση. Η μέθοδος [SlideSize.SetSize](https://reference.aspose.com/slides/el/net/aspose.slides/slidesize/setsize/) μπορεί να κλιμακώσει το υπάρχον περιεχόμενο ενώ αλλάζει τις διαστάσεις της διαφάνειας. Το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/net/aspose.slides/slidesizescaletype/) κλιμακώνει το περιεχόμενο ώστε να ταιριάζει στο ζητούμενο μέγεθος.

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

Η αλλαγή μεγέθους τροποποιεί το αντικείμενο της πηγαίας παρουσίασης στη μνήμη. Εάν χρειάζεστε την αρχική πηγή αμετάβλητη για άλλες λειτουργίες, ανοίξτε ένα ξεχωριστό αντίInstance για τη συγχώνευση.

## **Συγχώνευση Διαφανειών σε Ενότητα Παρουσίασης**

Ο βασικός βρόχος κλωνοποίησης διαφανειών δεν επαναδημιουργεί τη ιεραρχία ενοτήτων της πηγαίας παρουσίασης. Εάν οι ενότητες έχουν σημασία στο τελικό αποτέλεσμα, δημιουργήστε ή επιλέξτε ενότητες στην προοριζόμενη παρουσίαση και κλωνοποιήστε διαφάνειες σε αυτές ρητά με το [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/).

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

Οι κλωνοποιημένες διαφάνειες προσαρτώνται στην καθορισμένη προοριζόμενη ενότητα. Για να διατηρήσετε πολλές πηγαίες ενότητες, κάντε επανάληψη στα [Presentation.Sections](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/sections/), ανακτήστε τις τρέχουσες διαφάνειες κάθε πηγής με το [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/el/net/aspose.slides/isection/getslideslistofsection/), ξαναδημιουργήστε τις ενότητες στον προορισμό και κλωνοποιήστε κάθε διαφάνεια στην αντίστοιχη προοριζόμενη ενότητα. Δείτε το [Manage Slide Sections](/slides/el/net/slide-section/) για πλήρες παράδειγμα επανάληψης ενοτήτων, συμπεριλαμβανομένων των κενών ενοτήτων και των δομικών αλλαγών.

## **Ασφαλής Συγχώνευση Πολλαπλών Παρουσιάσεων**

Το παρακάτω ολοκληρωμένο παράδειγμα χρησιμοποιεί την πρώτη παρουσίαση ως προορισμό, εξομαλύνει το μέγεθος διαφάνειας κάθε πρόσθετης πηγής, κρατά κάθε πηγή ανοιχτή μόνο όσο αντιγράφεται και αποθηκεύει το τελικό αρχείο μια μόνο φορά.

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

Αυτή είναι μια χρήσιμη βάση για διατήρηση της μορφοποίησης πηγής των εισαγόμενων διαφανειών. Εάν το τελικό σας αποτέλεσμα πρέπει να χρησιμοποιεί ένα ενιαίο θέμα προορισμού, αντικαταστήστε την απλή κλήση `AddClone(slide)` με την κατάλληλη υπερφόρτωση master ή layout που παρουσιάστηκε νωρίτερα.

## **Πρακτικές Παρατηρήσεις**

### **Masters, Layouts και Πιστότητα Μορφοποίησης**

Η προεπιλεγμένη κλωνοποίηση διαφανειών μπορεί αυτόματα να φέρει ένα απαιτούμενο master πηγής στην προοριζόμενη παρουσίαση. Το Aspose.Slides διατηρεί εσωτερικό μητρώο για τα αυτόματα κλωνοποιημένα masters ώστε να αποφεύγεται η πολλαπλή κλωνοποίηση του ίδιου master. Τα χειροκίνητα κλωνοποιημένα masters δεν καταγράφονται σε αυτό το μητρώο, γι' αυτό αποφεύγετε την προ-κλωνοποίηση masters εκτός εάν χρειάζεστε άμεσο έλεγχο της δομής του master.

Μην υποθέτετε ότι δύο masters ή layouts με το ίδιο όνομα είναι οπτικά ισοδύναμα. Εάν ένα εταιρικό πρότυπο πρέπει να ελέγξει την τελική εμφάνιση, επιλέξτε ρητά ένα master ή layout προορισμού και επαληθεύστε το αποτέλεσμα μετά τη συγχώνευση.

### **Σημειώσεις και Σχόλια**

Οι σημειώσεις ομιλητή και τα σχόλια στις διαφάνειες συνδέονται με το περιεχόμενο της διαφάνειας και αντιγράφονται όταν κλωνοποιείται η διαφάνεια. Το Aspose.Slides παρέχει επίσης ειδικά API για [presentation notes](/slides/el/net/presentation-notes/) και [presentation comments](/slides/el/net/presentation-comments/).

Εάν η μορφοποίηση της σελίδας σημειώσεων είναι σημαντική, επαληθεύστε την συγχωνευμένη παρουσίαση επειδή οι masters σημειώσεων είναι αντικείμενα επιπέδου παρουσίασης και μπορεί να διαφέρουν μεταξύ των αρχείων πηγής. Για διεργασίες ελέγχου, επαληθεύστε επίσης τους συγγραφείς σχολίων και τα νήματα σχολίων μετά τη συνένωση αρχείων από διαφορετικούς συγγραφείς ή πρότυπα.

### **Εικόνες, Ήχος, Βίντεο, Αντικείμενα OLE και Εξωτερικοί Σύνδεσμοι**

Οι διαφάνειες μπορούν να αναφέρονται σε πόρους επιπέδου παρουσίασης όπως εικόνες, ενσωματωμένο ήχο, ενσωματωμένο βίντεο και δεδομένα OLE. Κλωνοποιήστε τη διαφάνεια ολοκληρωτικά αντί να αντιγράφετε μόνο τα ορατά σχήματα, ώστε το Aspose.Slides να διατηρήσει τις σχέσεις της διαφάνειας με τους πόρους της.

Οι ενσωματωμένοι και σύνδεσμοι πόρων πρέπει να αντιμετωπίζονται διαφορετικά. Ένας συνδεδεμένος ήχος, βίντεο, αντικείμενο OLE ή υπερσύνδεσμος παραμένει εξαρτημένος από τον εξωτερικό του προορισμό· η κλωνοποίηση μιας διαφάνειας δεν μετατρέπει έναν εξωτερικό σύνδεσμο σε ενσωματωμένο περιεχόμενο. Δοκιμάστε τις διαδρομές και τις διευθύνσεις URL των εξωτερικών πόρων στο περιβάλλον όπου θα ανοιχτεί η συγχωνευμένη παρουσίαση.

Το Aspose.Slides καταγράφει αυτόματα κλωνοποιημένα masters, αλλά αυτό δεν πρέπει να θεωρείται γενική εγγύηση ότι παρόμοιο δυαδικό περιεχόμενο από άσχετες πηγές θα αφαιρεθεί αυτόματα. Εάν το μέγεθος του αρχείου εξόδου είναι κρίσιμο, εξετάστε το τελικό πακέτο και μετρήστε το αποτέλεσμα αντί να βασίζεστε σε μηχανισμούς αυτόματης αποσυμπίεσης.

### **Ενσωματωμένες Γραμματοσειρές και Διαθεσιμότητα Γραμματοσειρών**

Οι γραμματοσειρές διαχειρίζονται επιπέδου παρουσίασης. Εάν η τυπογραφία πρέπει να παραμείνει συνεπής μεταξύ των μηχανημάτων, μην υποθέτετε ότι η κλωνοποίηση διαφανειών εξασφαλίζει την παρουσία κάθε απαιτούμενης γραμματοσειράς στο περιβάλλον προορισμού. Μπορείτε να ελέγξετε τις ενσωματωμένες γραμματοσειρές με το [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/el/net/aspose.slides/fontsmanager/getembeddedfonts/) και να διαχειριστείτε την ενσωμάτωση όπως περιγράφεται στο [Embed Fonts in Presentations](/slides/el/net/embedded-font/).

Επιβεβαιώστε επίσης ότι έχετε το δικαίωμα να ενσωματώσετε τις γραμματοσειρές που χρησιμοποιούν τα αρχεία πηγής· οι άδειες γραμματοσειρών μπορεί να περιορίζουν την ενσωμάτωση.

### **Παρουσιάσεις με Κωδικό Πρόσβασης**

Μια πηγαία παρουσίαση προστατευμένη με κωδικό πρέπει να ανοίξει επιτυχώς πριν τις διαφάνειές της κλωνοποιήσετε. Παρέχετε τον κωδικό μέσω του [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/).

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

Το άνοιγμα ενός κρυπτογραφημένου αρχείου δεν εφαρμόζει αυτόματα την ίδια προστασία στην προοριζόμενη παρουσίαση. Διαμορφώστε την προστασία εξόδου ξεχωριστά εάν απαιτείται.

### **Μεγάλες Παρουσιάσεις και Χρήση Μνήμης**

Οι μεγάλες παρουσιάσεις που περιλαμβάνουν εικόνες υψηλής ανάλυσης, ήχο, βίντεο ή άλλα μεγάλα δυαδικά αντικείμενα μπορεί να καταναλώνουν σημαντική μνήμη. Το [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/blobmanagementoptions/) παρέχει ελέγχους για τη διαχείριση BLOB και τη χρήση προσωρινών αρχείων. Δείτε το [Manage Presentation BLOBs](/slides/el/net/manage-blob/) για στρατηγικές μεγάλων αρχείων.

Για μεγάλα αρχεία, προτιμήστε τη φόρτωση από διαδρομές αρχείων όταν είναι δυνατόν, απελευθερώστε κάθε πηγαία παρουσίαση αμέσως μετά τη συγχώνευση και αποφύγετε την επαναλαμβανόμενη αποθήκευση ενδιάμεσων αποτελεσμάτων εκτός εάν η ροή εργασίας απαιτεί σημεία ελέγχου.

### **Ασφάλεια Πολυνηματικότητας**

Μην φορτώνετε, τροποποιείτε, αποθηκεύετε ή κλωνοποιείτε το ίδιο αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) ταυτόχρονα από πολλαπλά νήματα. Κρατήστε κάθε παρουσίαση περιορισμένη σε μία λειτουργία συγχώνευσης. Εάν παράγετε ανεξάρτητες εργασίες παράλληλα, χρησιμοποιήστε ανεξάρτητα αντικείμενα παρουσίασης και ακολουθήστε τις οδηγίες πολυνηματικότητας του [Aspose.Slides multithreading guidance](/slides/el/net/multithreading/).

## **Συχνές Ερωτήσεις**

**Πώς μπορώ να διατηρήσω το αρχικό σχεδιασμό κάθε πηγαίας παρουσίασης;**

Χρησιμοποιήστε το [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) χωρίς να παρέχετε master ή layout προορισμού. Το Aspose.Slides μπορεί να κλωνοποιήσει αυτόματα το πηγαίο master όταν απαιτείται από την εισαγόμενη διαφάνεια.

**Πώς κάνω ώστε οι εισαγόμενες διαφάνειες να χρησιμοποιούν το θέμα προορισμού;**

Χρησιμοποιήστε την υπερφόρτωση που αποδέχεται ένα master προορισμού. Παρέχετε ένα master από την προοριζόμενη παρουσίαση, όχι από την πηγή. Το Aspose.Slides θα προσπαθήσει να αντιστοιχίσει κάθε πηγαία διαφάνεια σε ένα κατάλληλο layout κάτω από αυτό το master.

**Πότε πρέπει να χρησιμοποιήσω συγκεκριμένο layout προορισμού αντί για master προορισμού;**

Χρησιμοποιήστε συγκεκριμένο layout όταν κάθε εισαγόμενη διαφάνεια πρέπει να χρησιμοποιεί ένα γνωστό layout. Χρησιμοποιήστε master όταν θέλετε το Aspose.Slides να επιλέξει μεταξύ των layout του master με βάση τον τύπο ή το όνομα του πηγαίου layout.

**Μπορούν να συγχωνευτούν παρουσιάσεις με διαφορετικά μεγέθη διαφανειών;**

Ναι, αλλά το περιεχόμενο της διαφάνειας δεν επανασχεδιάζεται αυτόματα για τις διαστάσεις προορισμού. Αλλάξτε το μέγεθος της πηγαίας παρουσίασης πρώτα όταν χρειάζεται προβλεπόμενη τοποθέτηση, για παράδειγμα με το [SlideSize.SetSize](https://reference.aspose.com/slides/el/net/aspose.slides/slidesize/setsize/) και το [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/el/net/aspose.slides/slidesizescaletype/).

**Μπορώ να συγχωνεύσω PPT, PPTX και ODP παρουσιάσεις σε ένα αρχείο;**

Ναι. Φορτώστε κάθε πηγαία παρουσίαση, κλωνοποιήστε τις απαιτούμενες διαφάνειες σε έναν προορισμό και αποθηκεύστε τον προορισμό σε υποστηριζόμενη μορφή εξόδου. Επειδή οι μορφές παρουσίασης δεν υποστηρίζουν ακριβώς το ίδιο σύνολο λειτουργιών, επαληθεύστε το πολύπλοκο περιεχόμενο μετά τη διαμορφωτική συγχώνευση. Δείτε τις [Supported File Formats](/slides/el/net/supported-file-formats/).

**Διατηρούνται αυτόματα οι ενότητες πηγής;**

Όχι, με έναν βασικό βρόχο που κλωνοποιεί μόνο διαφάνειες. Δημιουργήστε τις απαιτούμενες ενότητες στον προορισμό και χρησιμοποιήστε την υπερφόρτωση ενότητας του [AddClone](https://reference.aspose.com/slides/el/net/aspose.slides/islidecollection/addclone/) όταν η δομή ενότητας πρέπει να διατηρηθεί.

**Διατηρούνται οι σημειώσεις ομιλητή και τα σχόλια;**

Αντιγράφονται μαζί με τη κλωνοποιημένη διαφάνεια. Για ροές εργασίας που εξαρτώνται από το στυλ του master σημειώσεων, τους συγγραφείς σχολίων ή τα νήματα ανασκόπησης, επαληθεύστε το συγχωνευμένο αποτέλεσμα, καθώς αυτά τα σενάρια περιλαμβάνουν δομές επιπέδου παρουσίασης καθώς και περιεχόμενο διαφάνειας.

**Τι συμβαίνει με ήχο, βίντεο, αντικείμενα OLE και υπερσυνδέσμους;**

Το ενσωματωμένο περιεχόμενο μεταφέρεται ως μέρος των σχέσεων πόρων της κλωνοποιημένης διαφάνειας. Οι εξωτερικοί σύνδεσμοι παραμένουν εξωτερικοί, επομένως τα αρχεία-στόχοι ή οι URL τους πρέπει να είναι διαθέσιμα μετά τη συγχώνευση.

**Εγγυώνται οι ενσωματωμένες γραμματοσειρές από κάθε πηγή να είναι διαθέσιμες στη συγχωνευμένη παρουσίαση;**

Μην βασίζεστε μόνο στην κλωνοποίηση διαφανειών για την ανάπτυξη γραμματοσειρών. Εξετάστε τις ενσωματωμένες γραμματοσειρές του προορισμού και διαχειριστείτε ρητά την ενσωμάτωση ή τη διαθεσιμότητα εξωτερικών γραμματοσειρών όταν η τυπογραφία είναι σημαντική.

**Πώς συγχωνεύω ένα αρχείο με κωδικό πρόσβασης;**

Ανοίξτε το με το σωστό [LoadOptions.Password](https://reference.aspose.com/slides/el/net/aspose.slides/loadoptions/password/), στη συνέχεια κλωνοποιήστε τις διαφάνειες κανονικά. Η προστασία εξόδου ρυθμίζεται ξεχωριστά.

**Πώς πρέπει να χειριστώ πολύ μεγάλες παρουσιάσεις;**

Χρησιμοποιήστε τη διαχείριση BLOB όταν μεγάλα δυαδικά αντικείμενα κυριαρχούν στη μνήμη, προτιμήστε τη φόρτωση από διαδρομή αρχείου για πολύ μεγάλα αρχεία, απελευθερώστε γρήγορα τις πηγές και αποθηκεύστε το τελικό αποτέλεσμα μόνο όταν είναι απαραίτητο.

**Μπορώ να συγχωνεύσω διαφάνειες από πολλαπλά νήματα;**

Μην χρησιμοποιείτε ένα αντικείμενο [Presentation](https://reference.aspose.com/slides/el/net/aspose.slides/presentation/) ταυτόχρονα από πολλά νήματα. Κρατήστε κάθε λειτουργία συγχώνευσης απομονωμένη σε δικά της αντικείμενα παρουσίασης.